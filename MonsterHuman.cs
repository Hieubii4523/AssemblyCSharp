using System;

// Token: 0x02000099 RID: 153
public class MonsterHuman : MainMonster
{
	// Token: 0x060009B0 RID: 2480 RVA: 0x000C4838 File Offset: 0x000C2A38
	public MonsterHuman(short ID, int x, int y, CatalogyMonster cata) : base(ID, x, y)
	{
		this.timeLoadInfo = GameCanvas.timeNow;
		this.typeObject = 1;
		this.clazz = 6;
		this.idCatMonster = cata.idCat;
		this.ID = ID;
		this.xAnchor = x;
		this.yAnchor = y;
		this.x = x;
		this.y = y;
		this.toX = x;
		this.toY = y;
		this.toXNew = x;
		this.toYNew = y;
		this.downSpeedWater = 1;
		this.Dir = 0;
		this.hIconFocus = 0;
		bool flag = LoadMap.specMap == 4;
		if (flag)
		{
			base.setSpeed(4, 3);
			this.wOne = 100;
		}
		else
		{
			bool flag2 = LoadMap.specMap == 6;
			if (flag2)
			{
				base.setSpeed(3, 3);
				this.wOne = 26;
			}
			else
			{
				base.setSpeed(5, 5);
				this.wOne = 26;
			}
		}
		this.limitMove = 60;
		this.timeAutoAction = CRes.random(100, 150);
		this.timeRanChangeAction = 80;
		this.timeMaxMoveAttack = 3000;
		this.limitAttack = 30;
		this.xsai = 0;
		this.ysai = 0;
		bool isTemplate = cata.isTemplate;
		if (isTemplate)
		{
			this.loadInfoAgain(cata);
		}
		base.setWName();
		base.setAddEffElite();
	}

	// Token: 0x060009B1 RID: 2481 RVA: 0x000C4988 File Offset: 0x000C2B88
	private void setBoss()
	{
		bool flag = this.idCatMonster == 4;
		if (flag)
		{
			this.vMax = 4;
			this.limitMove = 80;
		}
	}

	// Token: 0x060009B2 RID: 2482 RVA: 0x000C49B4 File Offset: 0x000C2BB4
	public override void paint(mGraphics g)
	{
		bool flag = !this.isLoadTemplate;
		if (flag)
		{
			g.drawImage(AvMain.imgHinhnhan, this.x, this.y, 33);
		}
		else
		{
			bool flag2 = this.Action == 4;
			if (flag2)
			{
				bool flag3 = !this.isDie;
				if (flag3)
				{
					this.paintShadowMonster(g, this.xDie - 1, this.yDie, (int)this.typeShadow);
					base.paintChar(g, this.xDie, this.yDie - this.dyDie);
				}
			}
			else
			{
				bool flag4 = !this.isDie;
				if (flag4)
				{
					base.paintEffBoss(g, 0);
					base.paintCharAllPart(g, (int)this.typeShadow);
					base.paintEffElite(g);
				}
			}
		}
	}

	// Token: 0x060009B3 RID: 2483 RVA: 0x000C4A78 File Offset: 0x000C2C78
	public override void update()
	{
		base.updateActionPerson();
		bool flag = this.updateXuatHien();
		if (!flag)
		{
			bool flag2 = this.timeBeFire > 0;
			if (flag2)
			{
				this.timeBeFire--;
				this.vx = 0;
				this.vy = 0;
			}
			else
			{
				bool flag3 = this.Action != 4;
				if (flag3)
				{
					bool flag4 = this.skillCurrent != null;
					if (flag4)
					{
						bool flag5 = this.Action != 2;
						if (flag5)
						{
							base.move_to_XY_Normal();
						}
						bool isRemove = this.skillCurrent.isRemove;
						if (isRemove)
						{
							this.skillCurrent = null;
						}
						else
						{
							bool flag6 = CRes.abs(this.x - this.toX) < this.vMax && CRes.abs(this.y - this.toY) < this.vMax;
							if (flag6)
							{
								this.skillCurrent.setMonsterMoveFire();
							}
						}
					}
					else
					{
						bool flag7 = this.Action != 2 && this.Action != 3 && this.plashNow == null;
						if (flag7)
						{
							bool flag8 = !MainObject.isInScreen(this) && !base.setIsInScreen(this.toX, this.toY, this.wOne, this.hOne) && LoadMap.specMap != 6;
							if (flag8)
							{
								this.x = this.toX;
								this.y = this.toY;
								this.toX = this.toXNew;
								this.toY = this.toYNew;
								this.vx = 0;
								this.vy = 0;
								bool flag9 = this.Action != 4;
								if (flag9)
								{
									this.Action = 0;
								}
							}
							else
							{
								base.Move_to_Focus_Person();
							}
						}
						else
						{
							bool flag10 = this.plashNow != null && this.Action != 2;
							if (flag10)
							{
								this.Action = 2;
							}
						}
					}
					bool flag11 = this.Action != 2 && this.Action != 3;
					if (flag11)
					{
						int tile = GameCanvas.loadmap.getTile(this.x + this.vx, this.y + this.vy);
						base.setMove((int)this.downSpeedWater, tile);
					}
				}
			}
			base.setEffDie();
			base.setRevice();
			base.update();
			base.updateDy();
			base.updatevXEffAva();
			bool flag12 = LoadMap.specMap != 6;
			if (flag12)
			{
				base.updateDirFocusPlayer();
			}
			base.updateEffElite();
		}
	}

	// Token: 0x060009B4 RID: 2484 RVA: 0x0000AD30 File Offset: 0x00008F30
	public override void setDataBeginSkill(MainSkill skill, mVector vec)
	{
		this.plashNow = new Plash(skill, this, vec);
		base.resetBeginFire();
		this.Action = 2;
	}

	// Token: 0x060009B5 RID: 2485 RVA: 0x000C4D08 File Offset: 0x000C2F08
	public override void updateAva()
	{
		bool flag = this.f > this.feAva.Length - 1;
		if (flag)
		{
			this.Action = 0;
			this.f = 0;
			this.frame = this.feRun[this.f];
		}
		else
		{
			this.frame = this.feAva[this.f];
		}
	}

	// Token: 0x060009B6 RID: 2486 RVA: 0x000C4D68 File Offset: 0x000C2F68
	public override void beginFire()
	{
		bool flag = this.skillCurrent != null;
		if (flag)
		{
			this.setDataBeginSkill(this.skillCurrent.skill, this.skillCurrent.vecObjBeFire);
			this.skillCurrent.isRemove = true;
		}
	}

	// Token: 0x060009B7 RID: 2487 RVA: 0x000C4DB0 File Offset: 0x000C2FB0
	public bool updateXuatHien()
	{
		bool isXuatHien = this.isXuatHien;
		if (isXuatHien)
		{
			base.move_to_XY_Normal();
			this.x += this.vx;
			this.y += this.vy;
			bool flag = this.vx == 0 && this.vy == 0;
			if (flag)
			{
				base.setSpeed(5, 5);
				this.isXuatHien = false;
			}
		}
		else
		{
			bool flag2 = this.vMax > 5;
			if (flag2)
			{
				base.setSpeed(5, 5);
			}
		}
		return this.isXuatHien;
	}

	// Token: 0x060009B8 RID: 2488 RVA: 0x000C4E48 File Offset: 0x000C3048
	public override void ReveiceMonster()
	{
		this.isXuatHien = true;
		this.toXNew = this.x;
		this.toYNew = this.y;
		this.vx = 0;
		this.vy = 0;
		base.setSpeed(10, 10);
		int num = 0;
		bool flag;
		do
		{
			this.toX = this.xAnchor + CRes.random_Am_0(48);
			this.toY = this.yAnchor + CRes.random_Am_0(48);
			int tile = GameCanvas.loadmap.getTile(this.toX, this.toY);
			flag = (tile != 1 && tile != -1);
			num++;
			bool flag2 = num > 15;
			if (flag2)
			{
				flag = true;
				this.toX = this.xAnchor;
				this.toY = this.yAnchor;
			}
		}
		while (!flag);
		bool flag3 = CRes.random(2) == 0;
		if (flag3)
		{
			this.x = MainScreen.cameraMain.xCam - 30;
		}
		else
		{
			this.x = MainScreen.cameraMain.xCam + MotherCanvas.w + 30;
		}
		bool flag4 = this.x < 0;
		if (flag4)
		{
			this.x = 0;
		}
		bool flag5 = this.x > GameCanvas.loadmap.maxWMap;
		if (flag5)
		{
			this.x = GameCanvas.loadmap.maxWMap;
		}
		this.y = this.toY;
		bool flag6 = !base.setIsInScreen(this.toX, this.toY, this.wOne, this.hOne);
		if (flag6)
		{
			this.isXuatHien = false;
			base.setSpeed(5, 5);
			this.x = this.toX;
			this.y = this.toY;
		}
	}

	// Token: 0x060009B9 RID: 2489 RVA: 0x000C4FF8 File Offset: 0x000C31F8
	public override void loadInfoAgain(CatalogyMonster cata)
	{
		this.typeMoveMonster = cata.typeMove;
		this.name = cata.name;
		bool flag = this.LvThongThao > 0;
		if (flag)
		{
			this.name = cata.name + T.bat + this.LvThongThao.ToString();
		}
		this.maxHp = cata.maxHp;
		this.isHumanMonster = cata.isHumanPart;
		this.typeBossMonster = cata.typeMonster;
		this.Hp = cata.maxHp;
		this.Lv = cata.lv;
		this.hOne = (int)cata.hOne;
		base.sethead(cata.head);
		base.sethair(cata.hair);
		this.setWearing(cata.mWearing);
		bool flag2 = this.body == 778 || this.body == 781 || this.body == 784 || this.body == 788 || this.body == 791 || this.body == 794;
		if (flag2)
		{
			this.typeShadow = 4;
		}
		else
		{
			this.typeShadow = 0;
		}
		this.isLoadTemplate = true;
	}
}
