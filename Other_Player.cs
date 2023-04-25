using System;

// Token: 0x020000C3 RID: 195
public class Other_Player : MainPlayer
{
	// Token: 0x06000B5F RID: 2911 RVA: 0x000DB5BC File Offset: 0x000D97BC
	public Other_Player(short ID, sbyte type, string name, int x, int y)
	{
		this.hOne = 52;
		bool flag = LoadMap.specMap == 4;
		if (flag)
		{
			base.setSpeed(4, 3);
			this.wOne = 100;
		}
		else
		{
			base.setSpeed(7, 7);
			this.wOne = 26;
		}
		this.typeObject = type;
		this.name = name;
		this.ID = ID;
		this.x = x;
		this.y = y;
		this.toX = x;
		this.toY = y;
		this.toXNew = x;
		this.toYNew = y;
		this.hIconFocus = 0;
		this.f = CRes.random(this.feStand.Length);
		this.Action = 0;
		this.colorName = 5;
		base.setWName();
	}

	// Token: 0x06000B60 RID: 2912 RVA: 0x000DB694 File Offset: 0x000D9894
	public override void setImgMonSterforOtherPlayer(sbyte typeMove)
	{
		this.wOne = 0;
		this.maxEffShip = 4;
		this.indexShip = 2;
		this.typeMoveMonster = typeMove;
		if (typeMove <= 13)
		{
			switch (typeMove)
			{
			case 0:
				this.nFrame = 5;
				this.mActionMonSter = MonsterWalk.mMon12;
				goto IL_115;
			case 1:
				this.nFrame = 7;
				this.mActionMonSter = MonsterWalk.mMon234;
				goto IL_115;
			case 2:
				this.nFrame = 8;
				this.mActionMonSter = MonsterWalk.mMon2345Long;
				goto IL_115;
			case 3:
				break;
			case 4:
				this.nFrame = 7;
				this.mActionMonSter = MonsterWalk.mMon1234;
				goto IL_115;
			default:
				if (typeMove == 13)
				{
					this.nFrame = 9;
					this.mActionMonSter = Pet.mChoper;
					goto IL_115;
				}
				break;
			}
		}
		else
		{
			if (typeMove == 17)
			{
				this.nFrame = 4;
				this.mActionMonSter = MonsterWalk.mMonLoSuoi;
				this.typeShadow = 0;
				goto IL_115;
			}
			if (typeMove == 19)
			{
				this.nFrame = 2;
				this.mActionMonSter = MonsterWalk.mMonTru;
				this.typeShadow = 0;
				goto IL_115;
			}
		}
		this.nFrame = 5;
		this.mActionMonSter = MonsterWalk.mMon012;
		IL_115:
		mSystem.outz(string.Concat(new string[]
		{
			"other_player ",
			this.name,
			" nFrame ",
			this.nFrame.ToString(),
			" type ",
			this.typeMoveMonster.ToString()
		}));
	}

	// Token: 0x06000B61 RID: 2913 RVA: 0x000DB804 File Offset: 0x000D9A04
	public override void paint(mGraphics g)
	{
		bool flag = !this.isInfo;
		if (flag)
		{
			bool flag2 = this.timeInviMove <= 0;
			if (flag2)
			{
			}
		}
		else
		{
			sbyte color = this.colorName;
			bool flag3 = Player.vecParty.size() > 0;
			if (flag3)
			{
				for (int i = 0; i < Player.vecParty.size(); i++)
				{
					InfoMemList infoMemList = (InfoMemList)Player.vecParty.elementAt(i);
					bool flag4 = infoMemList.name.CompareTo(this.name) == 0;
					if (flag4)
					{
						color = 4;
						break;
					}
				}
			}
			bool flag5 = Player.mSatnhan.Length != 0;
			if (flag5)
			{
				for (int j = 0; j < Player.mSatnhan.Length; j++)
				{
					bool flag6 = this.ID == Player.mSatnhan[j];
					if (flag6)
					{
						color = 6;
					}
				}
			}
			bool flag7 = base.isHuman();
			if (flag7)
			{
				bool flag8 = this.Action == 4;
				if (flag8)
				{
					bool flag9 = !this.isDie;
					if (flag9)
					{
						g.drawImage(MainObject.imgShadow, this.xDie + 1, this.yDie, 3);
						base.paintChar(g, this.xDie, this.yDie - this.dyDie);
					}
					else
					{
						bool flag10 = LoadMap.specMap != 4;
						if (flag10)
						{
							this.paintShadow(g, this.x);
						}
						g.drawRegion(AvMain.fraDiePlayer.imgFrame, 0, this.f / 5 % AvMain.fraDiePlayer.nFrame * AvMain.fraDiePlayer.frameHeight, AvMain.fraDiePlayer.frameWidth, AvMain.fraDiePlayer.frameHeight - 2 + this.dySea / 10, 0, (float)(this.x - 4), (float)(this.y - this.dy), mGraphics.BOTTOM | mGraphics.LEFT);
					}
				}
				else
				{
					base.paintCharAllPart(g, 0);
				}
			}
			else
			{
				bool flag11 = this.typeMoveMonster == 19;
				if (flag11)
				{
					bool flag12 = this.Action == 4;
					if (flag12)
					{
						bool flag13 = this.typeShadow >= 0;
						if (flag13)
						{
							this.paintShadowMonster(g, this.x, 0, (int)this.typeShadow);
						}
						MainImage imageAll = ObjectData.getImageAll(this.IdIcon, ObjectData.HashImageMonster, 1000);
						bool flag14 = imageAll != null && imageAll.img != null;
						if (flag14)
						{
							g.drawRegion(imageAll.img, 0, this.mActionMonSter[this.Action][this.f] * this.hOne, this.wOne, this.hOne, (this.Dir == 2) ? 2 : 0, (float)this.x, (float)(this.y - this.dy), mGraphics.BOTTOM | mGraphics.HCENTER);
						}
					}
					this.dy = 0;
				}
				bool flag15 = this.Action != 4;
				if (flag15)
				{
					this.paintImgMonSter(g);
				}
			}
			this.paintName(g, color, 0);
		}
	}

	// Token: 0x06000B62 RID: 2914 RVA: 0x000DBB1C File Offset: 0x000D9D1C
	public override void paintHideAvatar(mGraphics g)
	{
		bool flag = !this.isInfo;
		if (flag)
		{
			bool flag2 = this.timeInviMove <= 0;
			if (flag2)
			{
			}
		}
		else
		{
			sbyte color = this.colorName;
			bool flag3 = Player.vecParty.size() > 0;
			if (flag3)
			{
				for (int i = 0; i < Player.vecParty.size(); i++)
				{
					InfoMemList infoMemList = (InfoMemList)Player.vecParty.elementAt(i);
					bool flag4 = infoMemList.name.CompareTo(this.name) == 0;
					if (flag4)
					{
						color = 4;
						break;
					}
				}
			}
			bool flag5 = Player.mSatnhan.Length != 0;
			if (flag5)
			{
				for (int j = 0; j < Player.mSatnhan.Length; j++)
				{
					bool flag6 = this.ID == Player.mSatnhan[j];
					if (flag6)
					{
						color = 6;
					}
				}
			}
			bool flag7 = base.isHuman();
			if (flag7)
			{
				bool flag8 = this.Action == 4;
				if (flag8)
				{
					bool flag9 = !this.isDie;
					if (flag9)
					{
						g.drawImage(MainObject.imgShadow, this.xDie + 1, this.yDie, 3);
					}
					else
					{
						bool flag10 = LoadMap.specMap != 4;
						if (flag10)
						{
							this.paintShadow(g, this.x);
						}
						g.drawRegion(AvMain.fraDiePlayer.imgFrame, 0, this.f / 5 % AvMain.fraDiePlayer.nFrame * AvMain.fraDiePlayer.frameHeight, AvMain.fraDiePlayer.frameWidth, AvMain.fraDiePlayer.frameHeight - 2 + this.dySea / 10, 0, (float)(this.x - 4), (float)(this.y - this.dy), mGraphics.BOTTOM | mGraphics.LEFT);
					}
				}
				else
				{
					base.paintCharNoPart(g, 0);
				}
			}
			else
			{
				bool flag11 = this.typeMoveMonster == 19;
				if (flag11)
				{
					bool flag12 = this.Action == 4;
					if (flag12)
					{
						bool flag13 = this.typeShadow >= 0;
						if (flag13)
						{
							this.paintShadowMonster(g, this.x, 0, (int)this.typeShadow);
						}
						MainImage imageAll = ObjectData.getImageAll(this.IdIcon, ObjectData.HashImageMonster, 1000);
						bool flag14 = imageAll != null && imageAll.img != null;
						if (flag14)
						{
							g.drawRegion(imageAll.img, 0, this.mActionMonSter[this.Action][this.f] * this.hOne, this.wOne, this.hOne, (this.Dir == 2) ? 2 : 0, (float)this.x, (float)(this.y - this.dy), mGraphics.BOTTOM | mGraphics.HCENTER);
						}
					}
					this.dy = 0;
				}
				bool flag15 = this.Action != 4;
				if (flag15)
				{
					this.paintImgMonSter(g);
				}
			}
			this.paintName(g, color, 0);
		}
	}

	// Token: 0x06000B63 RID: 2915 RVA: 0x0000B865 File Offset: 0x00009A65
	public override void paintOnlyShadown(mGraphics g)
	{
		g.drawImage(MainObject.imgShadow, this.x, this.y, 3);
		g.drawImage(AvMain.imgHinhnhan, this.x, this.y, 33);
	}

	// Token: 0x06000B64 RID: 2916 RVA: 0x000DBE18 File Offset: 0x000DA018
	public void paintImgMonSter(mGraphics g)
	{
		bool flag = this.mActionMonSter == null;
		if (!flag)
		{
			MainImage imageAll = ObjectData.getImageAll(this.IdIcon, ObjectData.HashImageMonster, 1000);
			int num = this.Action;
			bool flag2 = (LoadMap.specMap == 4 || this.typeActionBoat != 0) && this.boatSea != null && this.Action == 1;
			if (flag2)
			{
				num = 0;
			}
			bool flag3 = num > this.mActionMonSter.Length - 1;
			if (flag3)
			{
				num = 0;
			}
			bool flag4 = this.f > this.mActionMonSter[num].Length - 1;
			if (flag4)
			{
				this.f = 0;
			}
			this.paintShadow(g);
			bool flag5 = imageAll.img == null;
			if (!flag5)
			{
				bool flag6 = this.wOne <= 0 || this.hOne <= 0;
				if (flag6)
				{
					this.hOne = mImage.getImageHeight(imageAll.img.image) / this.nFrame;
					this.wOne = mImage.getImageWidth(imageAll.img.image);
				}
				int num2 = this.y - this.dy;
				bool flag7 = (LoadMap.specMap == 4 || this.typeActionBoat != 0) && this.boatSea != null && this.boatSea.ID == this.ID;
				if (flag7)
				{
					this.boatSea.paintFrist(g);
					bool flag8 = this.dy == 0;
					if (flag8)
					{
						num2 = this.y - this.dySea / 10 + 5;
					}
					this.boatSea.paintHang(g);
					this.boatSea.paintBuom(g);
					this.boatSea.paintLastInMap(g);
				}
				else
				{
					g.drawRegion(imageAll.img, 0, this.mActionMonSter[num][this.f] * this.hOne, this.wOne, this.hOne, this.type_left_right, (float)this.x, (float)num2, mGraphics.BOTTOM | mGraphics.HCENTER);
					bool flag9 = this.state > 0;
					if (flag9)
					{
						bool flag10 = this.state == 1 || this.state == 3;
						if (flag10)
						{
							AvMain.fraTrongCay.drawFrame(0, this.x - 20, num2 - this.hOne / 2 - 5, 0, 3, g);
						}
						bool flag11 = this.state == 2 || this.state == 3;
						if (flag11)
						{
							AvMain.fraTrongCay.drawFrame(1, this.x + 20, num2 - this.hOne / 2 - 5, 0, 3, g);
						}
						bool flag12 = this.state == 4;
						if (flag12)
						{
							AvMain.fraTrongCay.drawFrame(2, this.x - 20, num2 - this.hOne / 2 - 5, 0, 3, g);
							AvMain.fraTrongCay.drawFrame(2, this.x + 20, num2 - this.hOne / 2 - 5, 0, 3, g);
							AvMain.fraTrongCay.drawFrame(2, this.x, num2 - this.hOne / 2 - 20, 0, 3, g);
						}
					}
				}
			}
		}
	}

	// Token: 0x06000B65 RID: 2917 RVA: 0x000DC12C File Offset: 0x000DA32C
	private void paintShadow(mGraphics g)
	{
		bool flag = this.IdIcon != 999;
		if (flag)
		{
			g.drawImage(AvMain.imgShadowSmall, this.x, this.y - 3, 3);
		}
	}

	// Token: 0x06000B66 RID: 2918 RVA: 0x000DC16C File Offset: 0x000DA36C
	public override void update()
	{
		bool flag = this.Action == 4;
		if (flag)
		{
			bool flag2 = base.isHuman();
			if (flag2)
			{
				base.updateActionPerson();
			}
		}
		else
		{
			bool flag3 = this.typeActionBoat != 0;
			if (flag3)
			{
				this.updateActionUpBoat();
				bool flag4 = this.Action != 5;
				if (flag4)
				{
					base.move_to_XY_Normal();
				}
			}
			base.checkRemoveBoat();
			bool flag5 = LoadMap.specMap == 3;
			if (flag5)
			{
				this.updateMapTrain();
			}
			this.getInfo();
			bool flag6 = base.isHuman();
			if (flag6)
			{
				base.updateActionPerson();
			}
			else
			{
				base.updateActionMonSter(false);
				base.updateDirPaint();
				bool flag7 = this.Action != 2;
				if (flag7)
				{
					base.updateDy();
				}
			}
			bool flag8 = this.skillCurrent == null && this.vecSkillFires.size() > 0;
			if (flag8)
			{
				this.skillCurrent = (Start_Skill)this.vecSkillFires.elementAt(0);
				base.resetBeginFire();
				base.getPosLast();
				this.vecSkillFires.removeElementAt(0);
			}
			bool flag9 = this.skillCurrent != null;
			if (flag9)
			{
				bool isRemove = this.skillCurrent.isRemove;
				if (isRemove)
				{
					this.skillCurrent = null;
				}
				else
				{
					bool flag10 = CRes.abs(this.x - this.toX) < this.vMax && CRes.abs(this.y - this.toY) < this.vMax;
					if (flag10)
					{
						base.moveToLastPos();
						this.skillCurrent.setMonsterMoveFire();
					}
				}
			}
			bool flag11 = !MainObject.isInScreen(this) && !base.setIsInScreen(this.toX, this.toY, this.wOne, this.hOne) && !base.setIsInScreen(this.toXNew, this.toYNew, this.wOne, this.hOne);
			if (flag11)
			{
				this.toX = this.toXNew;
				this.toY = this.toYNew;
				this.x = this.toX;
				this.y = this.toY;
				this.vx = 0;
				this.vy = 0;
				bool flag12 = this.Action != 4;
				if (flag12)
				{
					this.Action = 0;
				}
				return;
			}
			bool flag13 = this.typeActionBoat == 0 && this.Action != 2;
			if (flag13)
			{
				base.Move_to_Focus_Person();
				int tile = GameCanvas.loadmap.getTile(this.x + this.vx, this.y + this.vy);
				base.setMove(1, tile);
			}
		}
		base.update();
	}

	// Token: 0x06000B67 RID: 2919 RVA: 0x000DC418 File Offset: 0x000DA618
	public override void Giaotiep()
	{
		bool flag = this.typeObject == 2;
		if (flag)
		{
			base.GiaotiepNPC();
		}
		else
		{
			bool flag2 = this.typePlayer == 0;
			if (flag2)
			{
				base.GiaotiepOtherPlayer();
			}
			else
			{
				bool flag3 = this.typePlayer == 1;
				if (flag3)
				{
					base.addChat(T.playerSupport, true);
				}
				else
				{
					bool flag4 = this.typePlayer == 2;
					if (flag4)
					{
						base.addChat(T.playerShiper, true);
					}
				}
			}
		}
	}

	// Token: 0x06000B68 RID: 2920 RVA: 0x000DC490 File Offset: 0x000DA690
	public override void setTouchPoint()
	{
		bool flag = GameScreen.player.setFightPk(this);
		if (flag)
		{
			GameCanvas.isPointerSelect = false;
			GameScreen.player.beginPlayerFirePoint();
		}
		else
		{
			GameCanvas.isPointerSelect = false;
		}
	}

	// Token: 0x06000B69 RID: 2921 RVA: 0x000DC4CC File Offset: 0x000DA6CC
	public override void setFireObject(int value)
	{
		bool flag = GameScreen.player.setFightPk(this) && !GameCanvas.loadmap.mapLang();
		if (flag)
		{
			GameScreen.player.beginPlayerFire(value);
		}
		else
		{
			bool flag2 = value == 2;
			if (flag2)
			{
				this.Giaotiep();
			}
		}
	}

	// Token: 0x06000B6A RID: 2922 RVA: 0x000DC51C File Offset: 0x000DA71C
	public void getInfo()
	{
		bool flag = !this.isInfo && GameCanvas.gameTick % 20 == 0 && (GameCanvas.timeNow - this.timeLoadInfo) / 1000L > 10L;
		if (flag)
		{
			this.timeLoadInfo = GameCanvas.timeNow;
			GlobalService.gI().char_info(this.ID);
		}
	}

	// Token: 0x04001123 RID: 4387
	private mVector vecEffShip = new mVector("Other_Player.vecEffShip");
}
