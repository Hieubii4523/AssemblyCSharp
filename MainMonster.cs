using System;

// Token: 0x02000080 RID: 128
public class MainMonster : MainObject
{
	// Token: 0x06000791 RID: 1937 RVA: 0x0000AB3B File Offset: 0x00008D3B
	public MainMonster(short ID, short idMain, short idImage, sbyte type)
	{
	}

	// Token: 0x06000792 RID: 1938 RVA: 0x0009ED38 File Offset: 0x0009CF38
	public MainMonster(short ID, int x, int y)
	{
		this.ID = ID;
		this.toX = x;
		this.toY = y;
		this.toXNew = x;
		this.toYNew = y;
		this.typeObject = 1;
	}

	// Token: 0x06000793 RID: 1939 RVA: 0x0000AB3B File Offset: 0x00008D3B
	public MainMonster(short ID, int IdCatMonster, sbyte typeMove, string name, int x, int y, int maxHP, int lv, CatalogyMonster cata)
	{
	}

	// Token: 0x06000794 RID: 1940 RVA: 0x0009EDA0 File Offset: 0x0009CFA0
	public static MainMonster createMonster(short ID, int x, int y, short IdCatMonster)
	{
		CatalogyMonster catalogyMonster = MainMonster.getCatalogyMonster((int)IdCatMonster);
		bool flag = catalogyMonster == null || !catalogyMonster.isTemplate;
		MainMonster result;
		if (flag)
		{
			mSystem.outloi("mon cat null");
			result = null;
		}
		else
		{
			bool flag2 = catalogyMonster.isHumanPart == 1;
			if (flag2)
			{
				result = new MonsterHuman(ID, x, y, catalogyMonster);
			}
			else
			{
				result = new MonsterWalk(ID, x, y, catalogyMonster);
			}
		}
		return result;
	}

	// Token: 0x06000795 RID: 1941 RVA: 0x0009EE00 File Offset: 0x0009D000
	public void paintAvatarFocus(mGraphics g, int x, int y)
	{
		MainImage imageAll = ObjectData.getImageAll((short)this.idCatMonster, ObjectData.HashImageMonster, 1000);
		bool flag = imageAll.img == null;
		if (!flag)
		{
			bool flag2 = this.wAvatar <= 0;
			if (flag2)
			{
				bool flag3 = this.wOne < 0;
				if (flag3)
				{
					this.hOne = mImage.getImageHeight(imageAll.img.image) / this.nFrame;
					this.wOne = mImage.getImageWidth(imageAll.img.image);
				}
				this.wAvatar = this.wOne;
				this.hAvatar = this.hOne;
				bool flag4 = this.wAvatar > 26;
				if (flag4)
				{
					this.wAvatar = 26;
				}
				bool flag5 = this.hAvatar > 26;
				if (flag5)
				{
					this.hAvatar = 26;
				}
			}
			g.drawRegion(imageAll.img, this.wOne / 2 - this.wAvatar / 2, 0, this.wAvatar, this.hAvatar, 0, (float)x, (float)y, 3);
		}
	}

	// Token: 0x06000796 RID: 1942 RVA: 0x0009EF0C File Offset: 0x0009D10C
	public void paintEffBoss(mGraphics g, int ylech)
	{
		bool flag = this.isTanHinh || GameCanvas.lowGraphic;
		if (!flag)
		{
			bool flag2 = this.typeBossMonster == 1 || this.typeBossMonster == 2;
			if (flag2)
			{
				int num = 0;
				bool flag3 = this.isHumanMonster == 1;
				if (flag3)
				{
					num = 2;
					bool flag4 = this.type_left_right == 2;
					if (flag4)
					{
						num = -2;
					}
				}
				AvMain.fraEffBoss.drawFrame((int)((this.typeBossMonster - 1) * 3) + GameCanvas.gameTick / 3 % 3, this.x + num, this.y + ylech, 0, 3, g);
			}
			bool flag5 = this.typeMoveMonster == 19 && this.IdIcon != 58;
			if (flag5)
			{
			}
		}
	}

	// Token: 0x06000797 RID: 1943 RVA: 0x0009EFCC File Offset: 0x0009D1CC
	public override void update()
	{
		bool flag = this.timeBeginUpdateMove >= 0;
		if (flag)
		{
			this.timeBeginUpdateMove--;
		}
		bool flag2 = this.isDie && this.Action != 4;
		if (flag2)
		{
			this.Action = 4;
			this.timedie = GameCanvas.timeNow;
		}
		bool flag3 = this.skillCurrent == null;
		if (flag3)
		{
			this.setNextSkill();
		}
		bool flag4 = this.Hp <= 0;
		if (flag4)
		{
			bool flag5 = this.Action != 4;
			if (flag5)
			{
				this.timezombie++;
			}
			bool flag6 = this.timezombie > 20;
			if (flag6)
			{
				this.Action = 4;
				this.timedie = GameCanvas.timeNow;
				this.timezombie = 0;
			}
		}
		this.x += this.vx;
		this.y += this.vy;
		bool flag7 = this.x < 0 || this.x > GameCanvas.loadmap.maxWMap;
		if (flag7)
		{
			this.x = GameCanvas.loadmap.maxWMap / 2;
		}
		this.getInfo();
		base.updateBuff();
		base.updateEffSpec();
		base.updateChatPopup(this.dhCharPopup);
	}

	// Token: 0x06000798 RID: 1944 RVA: 0x0009F120 File Offset: 0x0009D320
	public void updateDirFocusPlayer()
	{
		bool flag = this.Action != 1 && this.Action != 0;
		if (!flag)
		{
			int distance = MainObject.getDistance(this.x, this.y, GameScreen.player.x, GameScreen.player.y);
			bool flag2 = distance < LoadMap.wTile * 3;
			if (flag2)
			{
				bool flag3 = this.x < GameScreen.player.x;
				if (flag3)
				{
					this.type_left_right = 2;
				}
				else
				{
					this.type_left_right = 0;
				}
			}
			bool flag4 = distance < 24 && this.Action == 0;
			if (flag4)
			{
				bool flag5 = this.x < GameScreen.player.x;
				if (flag5)
				{
					this.toX = this.x - 24;
				}
				else
				{
					this.toX = this.x + 24;
				}
			}
		}
	}

	// Token: 0x06000799 RID: 1945 RVA: 0x0009F204 File Offset: 0x0009D404
	public virtual void updateEffMapSea()
	{
		for (int i = 0; i < this.vecEffMapSea.size(); i++)
		{
			Point point = (Point)this.vecEffMapSea.elementAt(i);
			point.f++;
			bool flag = point.f / 2 > 2;
			if (flag)
			{
				this.vecEffMapSea.removeElement(point);
				i--;
			}
		}
		bool flag2 = LoadMap.specMap == 4 && !GameCanvas.lowGraphic && this.Action == 1 && this.f % 3 == 0;
		if (flag2)
		{
			Point point2 = new Point(this.x + this.vx, this.y + this.vy);
			point2.dis = ((this.Dir == 2) ? 2 : 0);
			this.vecEffMapSea.addElement(point2);
		}
	}

	// Token: 0x0600079A RID: 1946 RVA: 0x0009F2E4 File Offset: 0x0009D4E4
	public void setNextSkill()
	{
		bool flag = this.vecSkillFires.size() > 0;
		if (flag)
		{
			this.skillCurrent = (Start_Skill)this.vecSkillFires.elementAt(0);
			this.objMainFocus = this.skillCurrent.objBefire;
			base.resetBeginFire();
			this.vecSkillFires.removeElementAt(0);
			this.timeBeginMoveAttack = GameCanvas.timeNow;
			bool flag2 = !this.isRunAttack;
			if (flag2)
			{
				this.skillCurrent.skill = this.Skilldefault;
				this.setDataBeginSkill(this.skillCurrent.skill, this.skillCurrent.vecObjBeFire);
			}
		}
	}

	// Token: 0x0600079B RID: 1947 RVA: 0x000090B5 File Offset: 0x000072B5
	public void paint()
	{
	}

	// Token: 0x0600079C RID: 1948 RVA: 0x0000AB6D File Offset: 0x00008D6D
	public override void paintOnlyShadown(mGraphics g)
	{
		g.drawImage(MainObject.imgShadow, this.x, this.y, 3);
	}

	// Token: 0x0600079D RID: 1949 RVA: 0x0009F390 File Offset: 0x0009D590
	public static CatalogyMonster getCatalogyMonster(int id)
	{
		CatalogyMonster catalogyMonster = (CatalogyMonster)MainMonster.hashMonsterTemplate.get(string.Empty + id.ToString());
		bool flag = catalogyMonster == null;
		if (flag)
		{
			catalogyMonster = new CatalogyMonster(id);
			catalogyMonster.timeRequest = GameCanvas.timeNow;
			MainMonster.hashMonsterTemplate.put(string.Empty + id.ToString(), catalogyMonster);
			GlobalService.gI().GetTemplate(1, (short)id);
		}
		bool flag2 = (GameCanvas.timeNow - catalogyMonster.timeRequest) / 1000L > 20L;
		if (flag2)
		{
			GlobalService.gI().GetTemplate(1, (short)id);
		}
		return catalogyMonster;
	}

	// Token: 0x0600079E RID: 1950 RVA: 0x0009F438 File Offset: 0x0009D638
	public void auto_Move()
	{
		bool flag = MainObject.getDistance(this.x, this.y, this.xAnchor, this.yAnchor) > this.limitMove + this.limitMove / 2;
		if (flag)
		{
			bool flag2 = !MainObject.isInScreen(this) && !base.setIsInScreen(this.xAnchor, this.yAnchor, this.wOne, this.hOne);
			if (flag2)
			{
				this.x = this.xAnchor;
				this.y = this.yAnchor;
				this.toX = this.xAnchor;
				this.toY = this.yAnchor;
			}
			else
			{
				this.toX = this.xAnchor;
				this.toY = this.yAnchor;
				base.move_to_XY();
			}
		}
		else
		{
			bool flag3 = !MainObject.isInScreen(this) && !base.setIsInScreen(this.xAnchor, this.yAnchor, this.wOne, this.hOne);
			if (flag3)
			{
				this.x = this.xAnchor;
				this.y = this.yAnchor;
				this.toX = this.xAnchor;
				this.toY = this.yAnchor;
			}
			else
			{
				this.timeMove += 1L;
				bool flag4 = this.Action == 4;
				if (!flag4)
				{
					bool flag5 = this.timeStand > 0L;
					if (flag5)
					{
						this.timeMove = 0L;
						this.Action = 0;
						this.vx = 0;
						this.vy = 0;
						this.timeStand -= 1L;
					}
					else
					{
						bool flag6 = MainObject.getDistance(this.x + this.vx, this.y + this.vy, GameScreen.player.x, GameScreen.player.y) < 50;
						if (flag6)
						{
							bool flag7 = this.Action == 1;
							if (flag7)
							{
								bool flag8 = (this.timeMove > (long)(this.timeAutoAction / 3) && CRes.random(20) == 0) || MainObject.getDistance(this.x + this.vx, this.y + this.vy, this.xAnchor, this.yAnchor) >= this.limitMove - this.vMax;
								if (flag8)
								{
									this.timeMove = 0L;
									this.Action = 0;
									this.vx = 0;
									this.vy = 0;
									bool flag9 = this.x > GameScreen.player.x;
									if (flag9)
									{
										this.Dir = 0;
									}
									else
									{
										this.Dir = 2;
									}
								}
							}
							else
							{
								bool flag10 = this.Action == 0 || CRes.random(30) == 0;
								if (flag10)
								{
									this.vx = 0;
									this.vy = 0;
									bool flag11 = this.timeMove > (long)this.timeAutoAction;
									if (flag11)
									{
										this.timeMove = 0L;
										this.Action = 1;
										this.Dir = CRes.random(4);
										this.setSpeed8Huong(this.vMax - 2);
									}
									bool flag12 = this.x > GameScreen.player.x;
									if (flag12)
									{
										this.Dir = 0;
									}
									else
									{
										this.Dir = 2;
									}
								}
							}
						}
						else
						{
							bool flag13 = this.Action == 1;
							if (flag13)
							{
								bool flag14 = (this.timeMove > (long)(this.timeAutoAction / 2) && CRes.random(this.timeRanChangeAction) == 0) || MainObject.getDistance(this.x + this.vx, this.y + this.vy, this.xAnchor, this.yAnchor) >= this.limitMove - this.vMax;
								if (flag14)
								{
									this.timeMove = 0L;
									this.Action = 0;
									this.vx = 0;
									this.vy = 0;
								}
							}
							else
							{
								bool flag15 = this.Action == 0;
								if (flag15)
								{
									this.vx = 0;
									this.vy = 0;
									bool flag16 = this.timeMove > (long)(this.timeAutoAction / 2) || CRes.random(this.timeRanChangeAction) == 0;
									if (flag16)
									{
										this.timeMove = 0L;
										this.Action = 1;
										this.Dir = CRes.random(4);
										this.setSpeed8Huong(this.vMax);
									}
								}
							}
						}
					}
					bool flag17 = MainObject.getDistance(this.x, this.y, this.xAnchor, this.yAnchor) <= this.limitMove;
					if (!flag17)
					{
						int num = CRes.abs(this.x - this.xAnchor);
						int num2 = CRes.abs(this.y - this.yAnchor);
						bool flag18 = num > num2;
						if (flag18)
						{
							bool flag19 = this.x > this.xAnchor;
							if (flag19)
							{
								this.Dir = 0;
							}
							else
							{
								this.Dir = 2;
							}
						}
						else
						{
							bool flag20 = this.y > this.yAnchor;
							if (flag20)
							{
								this.Dir = 1;
							}
							else
							{
								this.Dir = 3;
							}
						}
						this.setSpeed8Huong(this.vMax);
					}
				}
			}
		}
	}

	// Token: 0x0600079F RID: 1951 RVA: 0x0009F948 File Offset: 0x0009DB48
	public void setSpeed8Huong(int max)
	{
		int num = CRes.random_Am_0(3);
		bool flag = CRes.abs(num) > 1;
		if (flag)
		{
			max--;
		}
		switch (this.Dir)
		{
		case 0:
			this.vy = num;
			this.vx = -max;
			break;
		case 1:
			this.vy = -max;
			this.vx = num;
			break;
		case 2:
			this.vy = num;
			this.vx = max;
			break;
		case 3:
			this.vy = max;
			this.vx = num;
			break;
		}
		bool flag2 = this.vx == 0 && CRes.random(3) == 0;
		if (flag2)
		{
			this.timeMove = 0L;
			this.Action = 0;
			this.vx = 0;
			this.vy = 0;
		}
		bool flag3 = this.vx > 0;
		if (flag3)
		{
			this.Dir = 2;
		}
		else
		{
			this.Dir = 0;
		}
	}

	// Token: 0x060007A0 RID: 1952 RVA: 0x0009FA30 File Offset: 0x0009DC30
	public void autoMoveFire()
	{
		this.timeMove += 1L;
		bool flag = this.Action == 4;
		if (!flag)
		{
			bool flag2 = this.Action == 1;
			if (flag2)
			{
				bool flag3 = this.timeMove <= (long)this.timeAutoAction && CRes.random(16) != 0;
				if (!flag3)
				{
					this.timeMove = 0L;
					this.Action = 0;
					this.vx = 0;
					this.vy = 0;
					bool flag4 = this.objMainFocus != null;
					if (flag4)
					{
						bool flag5 = this.x > this.objMainFocus.x;
						if (flag5)
						{
							this.Dir = 0;
						}
						else
						{
							this.Dir = 2;
						}
					}
				}
			}
			else
			{
				bool flag6 = this.Action == 0;
				if (flag6)
				{
					this.vx = 0;
					this.vy = 0;
					bool flag7 = this.timeMove > (long)(this.timeAutoAction / 2) || CRes.random(12) == 0;
					if (flag7)
					{
						this.timeMove = 0L;
						this.Action = 1;
						this.Dir = CRes.random(4);
						base.getSpeedforRun(this.vMax);
					}
				}
			}
		}
	}

	// Token: 0x060007A1 RID: 1953 RVA: 0x0009FB60 File Offset: 0x0009DD60
	public void Move_to_Focus()
	{
		bool flag = this.skillCurrent == null;
		if (!flag)
		{
			bool flag2 = GameCanvas.timeNow - this.timeBeginMoveAttack > (long)this.timeMaxMoveAttack;
			if (flag2)
			{
				this.skillCurrent.skill = this.Skilldefault;
				this.setDataBeginSkill(this.skillCurrent.skill, this.skillCurrent.vecObjBeFire);
			}
			else
			{
				bool flag3 = this.skillCurrent.objBefire == null;
				if (flag3)
				{
					this.skillCurrent = null;
				}
				else
				{
					this.toX = this.skillCurrent.objBefire.x;
					this.toY = this.skillCurrent.objBefire.y;
					bool flag4 = MainObject.getDistance(this.x + this.vx, this.y + this.vy, this.skillCurrent.objBefire.x, this.skillCurrent.objBefire.y) <= this.limitAttack;
					if (flag4)
					{
						this.setDataBeginSkill(this.skillCurrent.skill, this.skillCurrent.vecObjBeFire);
					}
					else
					{
						bool flag5 = CRes.abs(this.x - this.toX) >= 4 || CRes.abs(this.y - this.toY) >= 4;
						if (flag5)
						{
							base.move_to_XY_Normal();
						}
					}
				}
			}
		}
	}

	// Token: 0x060007A2 RID: 1954 RVA: 0x0009FCC8 File Offset: 0x0009DEC8
	public override void updateActionFire()
	{
		bool flag = this.plashNow != null;
		if (flag)
		{
			int num = this.plashNow.update();
			bool flag2 = num == -1;
			if (flag2)
			{
				this.plashNow = null;
				bool flag3 = this.skillCurrent == null;
				if (flag3)
				{
					this.setNextSkill();
				}
				bool flag4 = this.skillCurrent == null;
				if (flag4)
				{
					this.Action = 0;
					this.resetAction();
				}
			}
			else
			{
				this.frame = num;
			}
		}
		else
		{
			this.Action = 0;
			this.resetAction();
		}
	}

	// Token: 0x060007A3 RID: 1955 RVA: 0x000090B5 File Offset: 0x000072B5
	public void Move_To_Player_Skill()
	{
	}

	// Token: 0x060007A4 RID: 1956 RVA: 0x0009FD54 File Offset: 0x0009DF54
	public override void Reveive()
	{
		bool flag = this.typeMoveMonster != 19;
		if (flag)
		{
			this.ReveiceMonster();
		}
		this.isRunAttack = false;
		this.objMainFocus = null;
		this.isFlyDie = false;
		this.vecSkillFires.removeAllElements();
		this.vecBuffCur.removeAllElements();
		this.vecEffspec.removeAllElements();
		base.setResetWearing();
		bool flag2 = this.isHumanMonster == 0;
		if (flag2)
		{
			base.resetXY();
		}
		this.frameDie = 0;
		this.timeBeginUpdateMove = -1;
		this.timeFreeFire = 0;
		this.timeBienmat = 10;
		this.timezombie = 0;
		this.f = 0;
		this.Action = 0;
		this.timeMove = 0L;
		this.isDie = false;
		this.vxDie = 0;
		this.vyDie = 0;
		this.Hp = this.maxHp;
		this.vyStyleDie = (this.vyStyleStand = 0);
	}

	// Token: 0x060007A5 RID: 1957 RVA: 0x0009FE40 File Offset: 0x0009E040
	public virtual void ReveiceMonster()
	{
		int num = 0;
		bool flag;
		do
		{
			this.x = this.xAnchor + CRes.random_Am_0(48);
			this.y = this.yAnchor + CRes.random_Am_0(48);
			int tile = GameCanvas.loadmap.getTile(this.x, this.y);
			flag = (tile != 1 && tile != -1);
			num++;
			bool flag2 = num > 15;
			if (flag2)
			{
				flag = true;
				this.x = this.xAnchor;
				this.y = this.yAnchor;
			}
		}
		while (!flag);
	}

	// Token: 0x060007A6 RID: 1958 RVA: 0x0009FED8 File Offset: 0x0009E0D8
	public void updateDieMonsterNormal()
	{
		bool flag = this.Action != 4;
		if (!flag)
		{
			this.frameDie++;
			bool isDie = this.isDie;
			if (!isDie)
			{
				this.x += this.vxDie;
				this.y += this.vyDie;
				bool flag2 = this.vyStyleDie > 0;
				if (flag2)
				{
					this.vyStyleDie -= 3;
					bool flag3 = this.vyStyleDie <= 0 && this.vyStyleStand > 2;
					if (flag3)
					{
						this.vyStyleStand -= 2;
						this.vyStyleDie = this.vyStyleStand;
						bool flag4 = CRes.abs(this.vxDie) > 1;
						if (flag4)
						{
							this.vxDie -= this.vxDie / CRes.abs(this.vxDie);
						}
						bool flag5 = CRes.abs(this.vyDie) > 1;
						if (flag5)
						{
							this.vyDie -= this.vyDie / CRes.abs(this.vyDie);
						}
					}
				}
				else
				{
					this.vxDie >>= 1;
					this.vyDie >>= 1;
				}
				bool flag6 = this.frameDie >= this.timeBienmat;
				if (flag6)
				{
					GameScreen.addEffectEnd(92, 0, this.x, this.y - this.hOne / 2, (sbyte)this.Dir, this);
					this.isDie = true;
				}
			}
		}
	}

	// Token: 0x060007A7 RID: 1959 RVA: 0x000A0068 File Offset: 0x0009E268
	public void setRevice()
	{
		bool flag = this.Action != 4;
		if (!flag)
		{
			bool flag2 = GameCanvas.gameTick % 10 == 0 && this.timeRevice != -2;
			if (flag2)
			{
				bool flag3 = this.timeRevice > 0;
				if (flag3)
				{
					bool flag4 = this.isDie && (GameCanvas.timeNow - this.timedie) / 1000L > (long)this.timeRevice;
					if (flag4)
					{
						this.Reveive();
					}
				}
				else
				{
					this.isRemove = true;
				}
			}
			bool flag5 = this.strChatPopup != null;
			if (flag5)
			{
				this.strChatPopup = null;
			}
		}
	}

	// Token: 0x060007A8 RID: 1960 RVA: 0x0000AB89 File Offset: 0x00008D89
	public void resetV()
	{
		this.vx = 0;
		this.vy = 0;
		this.toX = this.x;
		this.toY = this.y;
	}

	// Token: 0x060007A9 RID: 1961 RVA: 0x000090B5 File Offset: 0x000072B5
	public void startDie()
	{
	}

	// Token: 0x060007AA RID: 1962 RVA: 0x000A0114 File Offset: 0x0009E314
	public virtual void beginFire()
	{
		bool flag = this.skillCurrent != null && this.skillCurrent.skill != null && this.skillCurrent.vecObjBeFire != null;
		if (flag)
		{
			GameScreen.addEffectSkill(this.skillCurrent.skill, this, this.skillCurrent.vecObjBeFire);
			this.Action = 2;
			this.f = 0;
			this.skillCurrent = null;
		}
	}

	// Token: 0x060007AB RID: 1963 RVA: 0x000A0180 File Offset: 0x0009E380
	public override void beginDie(MainObject objFire)
	{
		this.timeBienmat = 10;
		this.Hp = 0;
		this.Action = 4;
		this.timedie = GameCanvas.timeNow;
		base.resetXY();
		bool flag = this.skillCurrent != null && this.skillCurrent.vecObjBeFire != null && this.Skilldefault != null;
		if (flag)
		{
			GameScreen.addEffectSkill(this.Skilldefault, this, this.skillCurrent.vecObjBeFire);
		}
		for (int i = 0; i < this.vecSkillFires.size(); i++)
		{
			this.skillCurrent = (Start_Skill)this.vecSkillFires.elementAt(i);
			bool flag2 = this.skillCurrent != null && this.skillCurrent.vecObjBeFire != null && this.Skilldefault != null;
			if (flag2)
			{
				GameScreen.addEffectSkill(this.Skilldefault, this, this.skillCurrent.vecObjBeFire);
			}
			this.vecSkillFires.removeElement(this.skillCurrent);
			i--;
		}
		this.skillCurrent = null;
		bool flag3 = this.typeMoveMonster == 19;
		if (flag3)
		{
			GameScreen.addEffectEnd(110, 0, this.x, this.y - 30, (sbyte)this.Dir, this);
			GameScreen.addEffectEnd(110, 0, this.x, this.y - 45, (sbyte)this.Dir, this);
			this.isDie = true;
			this.timeDie = 0L;
		}
		else
		{
			bool flag4 = objFire != null;
			if (flag4)
			{
				bool flag5 = this.isHumanMonster != 0;
				if (flag5)
				{
					base.beginDie(objFire);
				}
				else
				{
					MainMonster.startMonDeadFly(this, (int)objFire.ID, 0);
				}
			}
		}
	}

	// Token: 0x060007AC RID: 1964 RVA: 0x000A0324 File Offset: 0x0009E524
	public static void startMonDeadFly(MainMonster m, int attacker, int typeDie)
	{
		MainObject mainObject = MainObject.get_Object(attacker, 0);
		bool flag = mainObject == null;
		if (!flag)
		{
			int time = 10;
			int vyStyle = 0;
			bool flag2 = m == null;
			if (!flag2)
			{
				int num = 0;
				int num2 = 0;
				bool flag3 = mainObject != null;
				if (flag3)
				{
					num = (m.x - mainObject.x) * 2;
					num2 = (m.y - mainObject.y) * 2;
					while (MainObject.getDistance(num, num2) > 20)
					{
						num = num * 2 / 3;
						num2 = num2 * 2 / 3;
					}
					bool flag4 = typeDie == 1;
					if (flag4)
					{
						num *= 2;
						num2 *= 2;
					}
					else
					{
						bool flag5 = typeDie == 2;
						if (flag5)
						{
							while (MainObject.getDistance(num, num2) > 16)
							{
								num = num * 2 / 3;
								num2 = num2 * 2 / 3;
							}
							time = 20;
							vyStyle = 18;
						}
					}
				}
				m.DeadFly(num, num2, time, vyStyle);
			}
		}
	}

	// Token: 0x060007AD RID: 1965 RVA: 0x000A0414 File Offset: 0x0009E614
	public void DeadFly(int dx, int dy, int time, int vyStyle)
	{
		this.timedie = GameCanvas.timeNow;
		this.Action = 4;
		this.vx = 0;
		this.vy = 0;
		this.vxDie = dx;
		this.vyDie = dy;
		this.vyStyleDie = vyStyle;
		this.vyStyleStand = vyStyle;
		this.timeBienmat = time;
		this.isDie = false;
	}

	// Token: 0x060007AE RID: 1966 RVA: 0x0000ABB2 File Offset: 0x00008DB2
	public override void setDataBeginSkill(MainSkill skill, mVector vec)
	{
		this.beginFire();
	}

	// Token: 0x060007AF RID: 1967 RVA: 0x000A0470 File Offset: 0x0009E670
	public override void addSkillFire(MainSkill skill, mVector vec)
	{
		bool flag = this.skillCurrent != null;
		if (flag)
		{
			this.skillCurrent.beginSkill();
		}
		this.vecSkillFires.addElement(new Start_Skill(this, vec, skill));
		this.isRunAttack = true;
	}

	// Token: 0x060007B0 RID: 1968 RVA: 0x000A04B4 File Offset: 0x0009E6B4
	public override void setTouchPoint()
	{
		bool flag = this.Action != 4 && !GameCanvas.loadmap.mapLang() && (!this.isTru() || GameScreen.player.typePK != this.typePK);
		if (flag)
		{
			GameScreen.player.beginPlayerFirePoint();
		}
	}

	// Token: 0x060007B1 RID: 1969 RVA: 0x000A050C File Offset: 0x0009E70C
	public override void setFireObject(int value)
	{
		bool flag = this.Action != 4 && !GameCanvas.loadmap.mapLang() && (!this.isTru() || GameScreen.player.typePK != this.typePK);
		if (flag)
		{
			GameScreen.player.beginPlayerFire(value);
		}
	}

	// Token: 0x060007B2 RID: 1970 RVA: 0x000A0564 File Offset: 0x0009E764
	public void getInfo()
	{
		bool flag = !this.isInfo && GameCanvas.gameTick % 20 == 0 && (GameCanvas.timeNow - this.timeLoadInfo) / 1000L > 5L;
		if (flag)
		{
			this.timeLoadInfo = GameCanvas.timeNow;
			GlobalService.gI().monster_info(this.ID);
		}
		bool flag2 = !this.isLoadTemplate && GameCanvas.gameTick % 20 == 0;
		if (flag2)
		{
			CatalogyMonster catalogyMonster = MainMonster.getCatalogyMonster(this.idCatMonster);
			bool isTemplate = catalogyMonster.isTemplate;
			if (isTemplate)
			{
				this.loadInfoAgain(catalogyMonster);
			}
		}
	}

	// Token: 0x060007B3 RID: 1971 RVA: 0x000090B5 File Offset: 0x000072B5
	public void setAddEffElite()
	{
	}

	// Token: 0x060007B4 RID: 1972 RVA: 0x000A05FC File Offset: 0x0009E7FC
	public override int getTypeMoveMonster()
	{
		return (int)this.typeMoveMonster;
	}

	// Token: 0x060007B5 RID: 1973 RVA: 0x000A0614 File Offset: 0x0009E814
	public void updateEffElite()
	{
		bool flag = this.typeSpecMonSter == 1 && GameCanvas.gameTick % 300 == 0;
		if (flag)
		{
			GameScreen.addEffectEnd_Time(111, 0, this.x, this.y, this.ID, this.typeObject, (sbyte)this.Dir, this, 0);
		}
		for (int i = 0; i < this.vecEffElite.size(); i++)
		{
			MainEffect mainEffect = (MainEffect)this.vecEffElite.elementAt(i);
			mainEffect.update();
		}
	}

	// Token: 0x060007B6 RID: 1974 RVA: 0x000A06A4 File Offset: 0x0009E8A4
	public void paintEffElite(mGraphics g)
	{
		for (int i = 0; i < this.vecEffElite.size(); i++)
		{
			MainEffect mainEffect = (MainEffect)this.vecEffElite.elementAt(i);
			mainEffect.paint(g, this.x, this.y);
		}
	}

	// Token: 0x060007B7 RID: 1975 RVA: 0x000A06F4 File Offset: 0x0009E8F4
	public static void LoadInfoMonsterAgain()
	{
		for (int i = 0; i < GameScreen.vecPlayers.size(); i++)
		{
			MainObject mainObject = (MainObject)GameScreen.vecPlayers.elementAt(i);
			bool flag = mainObject.typeObject == 1 && !mainObject.isLoadTemplate;
			if (flag)
			{
				CatalogyMonster catalogyMonster = (CatalogyMonster)MainMonster.hashMonsterTemplate.get(string.Empty + mainObject.ID.ToString());
				bool isTemplate = catalogyMonster.isTemplate;
				if (isTemplate)
				{
					mainObject.loadInfoAgain(catalogyMonster);
				}
			}
		}
	}

	// Token: 0x04000B7E RID: 2942
	public const sbyte MONSTER_MOVE_12 = 0;

	// Token: 0x04000B7F RID: 2943
	public const sbyte MONSTER_MOVE_234 = 1;

	// Token: 0x04000B80 RID: 2944
	public const sbyte MONSTER_MOVE_2345 = 2;

	// Token: 0x04000B81 RID: 2945
	public const sbyte MONSTER_MOVE_012 = 3;

	// Token: 0x04000B82 RID: 2946
	public const sbyte MONSTER_MOVE_1234 = 4;

	// Token: 0x04000B83 RID: 2947
	public const sbyte MONSTER_MOVE_23 = 5;

	// Token: 0x04000B84 RID: 2948
	public const sbyte MONSTER_MOVE_123 = 6;

	// Token: 0x04000B85 RID: 2949
	public const sbyte MONSTER_MOVE_BUNHIN = 8;

	// Token: 0x04000B86 RID: 2950
	public const sbyte MONSTER_MOVE_0MOVE = 9;

	// Token: 0x04000B87 RID: 2951
	public const sbyte MONSTER_MOVE_01 = 10;

	// Token: 0x04000B88 RID: 2952
	public const sbyte MONSTER_MOVE_2343 = 11;

	// Token: 0x04000B89 RID: 2953
	public const sbyte MONSTER_MOVE_FLY = 12;

	// Token: 0x04000B8A RID: 2954
	public const sbyte MONSTER_MOVE_CHOPPER = 13;

	// Token: 0x04000B8B RID: 2955
	public const sbyte MONSTER_MOVE_BINGO = 14;

	// Token: 0x04000B8C RID: 2956
	public const sbyte MONSTER_MOVE_KUNGFU = 15;

	// Token: 0x04000B8D RID: 2957
	public const sbyte MONSTER_MOVE_BANANA = 16;

	// Token: 0x04000B8E RID: 2958
	public const sbyte MONSTER_MOVE_ICE_SNOW = 17;

	// Token: 0x04000B8F RID: 2959
	public const sbyte MONSTER_MOVE_POKEMON = 18;

	// Token: 0x04000B90 RID: 2960
	public const sbyte MONSTER_MOVE_TRU = 19;

	// Token: 0x04000B91 RID: 2961
	public const sbyte MONSTER_MOVE_BANH_KEM = 20;

	// Token: 0x04000B92 RID: 2962
	public const sbyte MONSTER_PET_DOG = 21;

	// Token: 0x04000B93 RID: 2963
	public const sbyte MONSTER_SPEC_NORMAL = 0;

	// Token: 0x04000B94 RID: 2964
	public const sbyte MONSTER_SPEC_MINI_BOSS = 1;

	// Token: 0x04000B95 RID: 2965
	public const sbyte MONSTER_SPEC_BOSS = 2;

	// Token: 0x04000B96 RID: 2966
	public int idCatMonster;

	// Token: 0x04000B97 RID: 2967
	public int timeAutoAction;

	// Token: 0x04000B98 RID: 2968
	public new int timeRemove;

	// Token: 0x04000B99 RID: 2969
	public int frameDie;

	// Token: 0x04000B9A RID: 2970
	public int timeBienmat;

	// Token: 0x04000B9B RID: 2971
	public int timeRanChangeAction = 24;

	// Token: 0x04000B9C RID: 2972
	public int limitMove;

	// Token: 0x04000B9D RID: 2973
	public int limitAttack;

	// Token: 0x04000B9E RID: 2974
	public int vyStyleDie;

	// Token: 0x04000B9F RID: 2975
	public int vyStyleStand;

	// Token: 0x04000BA0 RID: 2976
	public long timedie;

	// Token: 0x04000BA1 RID: 2977
	public long timeMove;

	// Token: 0x04000BA2 RID: 2978
	public long timeStand;

	// Token: 0x04000BA3 RID: 2979
	public static mVector VecCatalogyMonSter = new mVector("MainMonster.vecCatalogyMonSter");

	// Token: 0x04000BA4 RID: 2980
	public static MyHashTable hashMonsterTemplate = new MyHashTable();

	// Token: 0x04000BA5 RID: 2981
	public bool isRunAttack;

	// Token: 0x04000BA6 RID: 2982
	public bool isXuatHien;

	// Token: 0x04000BA7 RID: 2983
	public int timeMaxMoveAttack;

	// Token: 0x04000BA8 RID: 2984
	public long timeBeginMoveAttack;

	// Token: 0x04000BA9 RID: 2985
	public mVector vecEffMapSea = new mVector("MainMonster.vecEffMapSea");

	// Token: 0x04000BAA RID: 2986
	public mVector vecEffElite = new mVector("MainMonster.vecEffElite");

	// Token: 0x04000BAB RID: 2987
	public int timezombie;
}
