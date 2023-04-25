using System;
using System.Collections;

// Token: 0x020000CD RID: 205
public class Player : MainPlayer
{
	// Token: 0x06000B9F RID: 2975 RVA: 0x000E10B8 File Offset: 0x000DF2B8
	public Player()
	{
		this.hOne = 52;
		this.wOne = 26;
		base.setSpeed(7, 7);
		this.x = MotherCanvas.w / 2;
		this.y = MotherCanvas.h / 2;
		this.Hp = 100;
		this.Mp = 100;
		this.maxHp = 100;
		this.maxMp = 100;
		this.percentLv = 0;
		this.hIconFocus = 0;
		this.Action = 0;
		Player.hotkeyPlayer = new Hotkey[2][];
		Player.hotkeyBuffPlayer = new Hotkey[6];
		for (int i = 0; i < Player.hotkeyPlayer.Length; i++)
		{
			Player.hotkeyPlayer[i] = new Hotkey[6];
			for (int j = 0; j < Player.hotkeyPlayer[i].Length; j++)
			{
				Player.hotkeyPlayer[i][j] = new Hotkey();
			}
		}
		this.myBoat = new short[]
		{
			4,
			5,
			6,
			7
		};
		this.mValuePvP = new int[2];
		this.PointPvP = 0;
	}

	// Token: 0x06000BA0 RID: 2976 RVA: 0x000E11E8 File Offset: 0x000DF3E8
	public override void paint(mGraphics g)
	{
		bool flag = GameScreen.typeViewPlayer == 1;
		if (!flag)
		{
			bool flag2 = this.Action == 4;
			if (flag2)
			{
				bool flag3 = !this.isDie;
				if (flag3)
				{
					g.drawImage(MainObject.imgShadow, this.xDie + 1, this.yDie, 3);
					base.paintChar(g, this.xDie, this.yDie - this.dyDie);
				}
				else
				{
					bool flag4 = LoadMap.specMap != 4;
					if (flag4)
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
			bool flag5 = !Player.isGhost && GameScreen.typePaintGameScreen != 1;
			if (flag5)
			{
				this.paintName(g, 0, 0);
			}
			bool isShowIndex = GameScreen.isShowIndex;
			if (isShowIndex)
			{
				mFont.tahoma_7b_black.drawString(g, this.x.ToString() + " - " + this.y.ToString(), this.x, this.y + 5, 2);
			}
		}
	}

	// Token: 0x06000BA1 RID: 2977 RVA: 0x000E1374 File Offset: 0x000DF574
	public void paintGotoSky(mGraphics g)
	{
		base.paintshadowFocus(g, 0);
		int y = this.y - this.dy;
		bool flag = Player.boatKeyParty != null;
		if (flag)
		{
			Player.boatKeyParty.paintFrist(g);
			bool flag2 = this.dy == 0;
			if (flag2)
			{
				y = this.y - this.dySea / 10;
			}
			Player.boatKeyParty.paintBuom(g);
		}
		else
		{
			bool flag3 = !this.isTanHinh;
			if (flag3)
			{
				this.paintShadow(g, this.x - this.dx);
			}
		}
		bool flag4 = !this.isTanHinh;
		if (flag4)
		{
			base.paintBuffFirst(g, this.x - this.dx, y);
			base.paintEffSpecFirst(g);
			int num = 7;
			int num2 = GameScreen.vecPlayers.size();
			for (int i = GameScreen.vecPlayers.size() - 1; i >= 0; i--)
			{
				MainObject mainObject = (MainObject)GameScreen.vecPlayers.elementAt(i);
				bool flag5 = mainObject != this;
				if (flag5)
				{
					mainObject.type_left_right = this.type_left_right;
					mainObject.paintWhenBoatOther(g, this.x - this.dx + num * num2, y);
					num2--;
				}
			}
			base.paintChar(g, this.x - this.dx, y);
		}
		bool flag6 = Player.boatKeyParty != null;
		if (flag6)
		{
			Player.boatKeyParty.paintLastInMap(g);
		}
		bool flag7 = !this.isTanHinh;
		if (flag7)
		{
			base.paintBuffLast(g, this.x - this.dx, y);
			base.paintEffSpecLast(g);
		}
	}

	// Token: 0x06000BA2 RID: 2978 RVA: 0x000090B5 File Offset: 0x000072B5
	public static void paintGhost(mGraphics g, int x, int y)
	{
	}

	// Token: 0x06000BA3 RID: 2979 RVA: 0x000E1520 File Offset: 0x000DF720
	public override void update()
	{
		bool flag = this.typeActionBoat != 0;
		if (flag)
		{
			this.updateActionUpBoat();
		}
		base.checkRemoveBoat();
		bool flag2 = this.check_Move_EffSpec();
		if (flag2)
		{
			this.vx = 0;
			this.vy = 0;
			bool flag3 = this.Action == 1;
			if (flag3)
			{
				this.Action = 0;
			}
			bool flag4 = this.skillCurrent != null;
			if (flag4)
			{
				bool isRemove = this.skillCurrent.isRemove;
				if (isRemove)
				{
					this.skillCurrent = null;
				}
				else
				{
					this.skillCurrent.beginSkill();
					bool flag5 = this.timeDragon <= 0;
					if (flag5)
					{
						this.frameOneStep = 20;
					}
					this.timeDragon = 150;
				}
			}
			bool flag6 = this.posTransRoad != null;
			if (flag6)
			{
				this.posTransRoad = null;
			}
			bool flag7 = this.checkEffSpec(1);
			if (flag7)
			{
				this.Dir = this.DirSpec;
			}
		}
		base.updateActionPerson();
		bool flag8 = this.Action != 2 && !this.isMoveNor;
		if (flag8)
		{
			base.setMove(true);
		}
		this.updatePlayer();
		this.setFocus(false);
		this.setCmdGame();
		this.setAutoPlayer();
		bool isMoveNor = this.isMoveNor;
		if (isMoveNor)
		{
			base.move_to_XY_Normal();
			bool flag9 = this.posTransRoad != null;
			if (flag9)
			{
				this.posTransRoad = null;
			}
			bool flag10 = CRes.abs(this.x - this.toX) < this.vMax && CRes.abs(this.y - this.toY) < this.vMax;
			if (flag10)
			{
				this.isMoveNor = false;
			}
		}
		else
		{
			bool flag11 = this.posTransRoad == null && this.skillCurrent != null;
			if (flag11)
			{
				bool isRemove2 = this.skillCurrent.isRemove;
				if (isRemove2)
				{
					this.skillCurrent = null;
				}
				else
				{
					this.skillCurrent.setMoveFire();
				}
			}
		}
		this.updateDelay();
		bool flag12 = !Player.isFocusNPC;
		if (flag12)
		{
			Player.timeFocusNPC++;
			bool flag13 = Player.timeFocusNPC > 60;
			if (flag13)
			{
				Player.isFocusNPC = true;
				Player.timeFocusNPC = 0;
			}
		}
		bool flag14 = GameScreen.isMoveCamEff && this.Action != 2;
		if (flag14)
		{
			GameScreen.isMoveCamEff = false;
		}
		this.updateMoney();
		bool flag15 = Player.StepAutoRe != 4 && Player.StepAutoRe != 3 && Player.StepAutoRe != 6;
		if (flag15)
		{
			this.StepAutoReconnect();
		}
		bool flag16 = this.isNauBanh;
		if (flag16)
		{
			this.tickNauBanh++;
			bool flag17 = this.tickNauBanh > 87;
			if (flag17)
			{
				GameCanvas.gameScr.setNauBanh(false);
				GlobalService.gI().VotBanhChung(1, 1, 3);
			}
		}
		base.update();
	}

	// Token: 0x06000BA4 RID: 2980 RVA: 0x000E17FC File Offset: 0x000DF9FC
	public void updateMapRedLine()
	{
		bool flag = this.boatSea != null;
		if (flag)
		{
			this.y += this.vy;
			this.x += this.vx;
			bool flag2 = this.tickChangeLine > 0;
			if (flag2)
			{
				this.tickChangeLine--;
			}
			bool flag3 = this.lineShowRedLineNext != this.lineShowRedLineCur;
			if (flag3)
			{
				this.tickmove = 6;
				bool flag4 = this.lineShowRedLineNext > this.lineShowRedLineCur;
				if (flag4)
				{
					this.vy = 4;
				}
				else
				{
					this.vy = -4;
				}
				this.lineShowRedLineCur = this.lineShowRedLineNext;
				this.tickChangeLine = 50;
			}
			bool flag5 = Player.isChangeLine;
			if (flag5)
			{
				bool flag6 = this.tickmove == 0;
				if (flag6)
				{
					this.y = MapOff_RedLine.yHarcodeMapRedLine - 48 + this.lineShowRedLineCur * 24;
				}
				bool flag7 = this.lineShowRedLineNext == 0;
				if (flag7)
				{
					this.lineShowRedLineNext = 1;
				}
				else
				{
					bool flag8 = this.lineShowRedLineNext == 3;
					if (flag8)
					{
						this.lineShowRedLineNext = 2;
					}
					else
					{
						bool flag9 = CRes.random(2) == 0;
						if (flag9)
						{
							this.lineShowRedLineNext++;
						}
						else
						{
							this.lineShowRedLineNext--;
						}
					}
				}
				Player.isChangeLine = false;
			}
			bool flag10 = this.boatSea != null;
			if (flag10)
			{
				this.boatSea.updateXY(this.x, this.y, 0, (sbyte)this.type_left_right);
			}
			bool flag11 = this.vy != 0;
			if (flag11)
			{
				this.boatSea.setLevelPaint();
			}
			bool flag12 = this.tickmove > 0;
			if (flag12)
			{
				this.tickmove--;
				bool flag13 = this.tickmove == 0;
				if (flag13)
				{
					this.vy = 0;
					this.y = MapOff_RedLine.yHarcodeMapRedLine - 48 + this.lineShowRedLineCur * 24;
				}
			}
			bool flag14 = GameCanvas.gameTick % 8 == 0;
			if (flag14)
			{
				this.boatSea.addEffSea(this.x, this.y, -1, (sbyte)this.type_left_right, -3);
			}
			bool flag15 = CRes.random(4) == 0;
			if (flag15)
			{
				this.boatSea.addEffSea(this.x, this.y, 0, (this.type_left_right == 0) ? 2 : 0, -3);
			}
			bool flag16 = GameCanvas.gameTick % 6 == 0;
			if (flag16)
			{
				this.boatSea.addEffSea(this.x, this.y, 2, (sbyte)this.type_left_right, -3);
			}
			bool flag17 = this.boatSea != null;
			if (flag17)
			{
				this.boatSea.updateBoat();
			}
			bool flag18 = this.tickChangeLine <= 0 && CRes.random(120) == 0 && this.lineShowRedLineCur == this.lineShowRedLineNext && this.typeMoveMapRedLine == 0;
			if (flag18)
			{
				bool flag19 = this.lineShowRedLineNext == 0;
				if (flag19)
				{
					this.lineShowRedLineNext = 1;
				}
				else
				{
					bool flag20 = this.lineShowRedLineNext == 3;
					if (flag20)
					{
						this.lineShowRedLineNext = 2;
					}
					else
					{
						bool flag21 = CRes.random(2) == 0;
						if (flag21)
						{
							this.lineShowRedLineNext++;
						}
						else
						{
							this.lineShowRedLineNext--;
						}
					}
				}
			}
			bool flag22 = this.typeMoveMapRedLine == 0 || this.typeMoveMapRedLine == 2;
			if (flag22)
			{
				for (int i = 0; i < MapOff_RedLine.vecDaBien.size(); i++)
				{
					Point point = (Point)MapOff_RedLine.vecDaBien.elementAt(i);
					bool flag23 = point.dis == this.lineShowRedLineNext && point.x + point.x2 > MapOff_RedLine.xHardCodeMapRedLine + 80 && point.x + point.x2 < MapOff_RedLine.xHardCodeMapRedLine + 120;
					if (flag23)
					{
						Player.isChangeLine = true;
						return;
					}
				}
				bool flag24 = Player.isShowDie == 2;
				if (flag24)
				{
					this.tickFinish++;
					bool flag25 = MapOff_RedLine.vecDaBien.size() == 0 || this.tickFinish > 100;
					if (flag25)
					{
						Player.isShowDie = 12;
						MapOff_RedLine.vxHardcodeRedLine = 0;
						GameScreen.player.vx = 5;
					}
				}
				bool flag26 = Player.isShowDie == 12 && this.x > MotherCanvas.w - 50;
				if (flag26)
				{
					MapOff_RedLine.changeFinish();
				}
			}
			else
			{
				bool flag27 = this.typeMoveMapRedLine == 1;
				if (flag27)
				{
					bool flag28 = Player.isShowDie == 0;
					if (flag28)
					{
						for (int j = 0; j < MapOff_RedLine.vecDaBien.size(); j++)
						{
							Point point2 = (Point)MapOff_RedLine.vecDaBien.elementAt(j);
							bool flag29 = point2.dis == this.lineShowRedLineNext && point2.x + point2.x2 > MapOff_RedLine.xHardCodeMapRedLine + 50 && point2.x + point2.x2 < MapOff_RedLine.xHardCodeMapRedLine + 65;
							if (flag29)
							{
								Player.isShowDie = 1;
								MapOff_RedLine.vxHardcodeRedLine = 0;
								GameScreen.player.vx = -3;
								bool flag30 = this.lineShowRedLineCur < 2;
								if (flag30)
								{
									GameScreen.player.vy = 1;
								}
								else
								{
									GameScreen.player.vy = -1;
								}
								return;
							}
						}
					}
					else
					{
						bool flag31 = Player.isShowDie == 1 && this.x < 0;
						if (flag31)
						{
							GlobalService.gI().Red_Line(1, 0);
							Player.isShowDie = 11;
						}
					}
				}
			}
		}
		base.updateEye();
		base.updateChatPopup(this.dhCharPopup);
	}

	// Token: 0x06000BA5 RID: 2981 RVA: 0x000E1DBC File Offset: 0x000DFFBC
	public void updateRedLineFinish()
	{
		this.vx = 3;
		bool flag = GameCanvas.gameTick % 10 == 0 && CRes.random(4) == 0;
		if (flag)
		{
			bool flag2 = this.vy == 0;
			if (flag2)
			{
				this.vy = 1;
			}
			else
			{
				this.vy = 0;
			}
		}
		this.y += this.vy;
		this.x += this.vx;
		bool flag3 = this.boatSea != null;
		if (flag3)
		{
			this.boatSea.updateXY(this.x, this.y, 0, (sbyte)this.type_left_right);
		}
		bool flag4 = this.vy != 0;
		if (flag4)
		{
			this.boatSea.setLevelPaint();
		}
		bool flag5 = GameCanvas.gameTick % 8 == 0;
		if (flag5)
		{
			this.boatSea.addEffSea(this.x, this.y, -1, (sbyte)this.type_left_right, -3);
		}
		bool flag6 = CRes.random(4) == 0;
		if (flag6)
		{
			this.boatSea.addEffSea(this.x, this.y, 0, (this.type_left_right == 0) ? 2 : 0, -3);
		}
		bool flag7 = GameCanvas.gameTick % 6 == 0;
		if (flag7)
		{
			this.boatSea.addEffSea(this.x, this.y, 2, (sbyte)this.type_left_right, -3);
		}
		bool flag8 = this.boatSea != null;
		if (flag8)
		{
			this.boatSea.updateBoat();
		}
		base.updateEye();
		base.updateChatPopup(this.dhCharPopup);
		bool flag9 = Player.isShowDie == 12 && this.x > MotherCanvas.w - 50;
		if (flag9)
		{
			GlobalService.gI().Red_Line(2, 0);
			Player.isShowDie = 22;
		}
	}

	// Token: 0x06000BA6 RID: 2982 RVA: 0x000E1F88 File Offset: 0x000E0188
	public void updateMapGotoSky()
	{
		bool flag = Player.boatKeyParty == null || !Player.boatKeyParty.loadDataOk;
		if (flag)
		{
			for (int i = GameScreen.vecPlayers.size() - 1; i >= 0; i--)
			{
				MainObject mainObject = (MainObject)GameScreen.vecPlayers.elementAt(i);
				bool flag2 = Player.vecParty.size() > 0;
				if (flag2)
				{
					InfoMemList infoMemList = (InfoMemList)Player.vecParty.elementAt(0);
					bool flag3 = infoMemList.id == (int)mainObject.ID;
					if (flag3)
					{
						bool loadDataOk = true;
						bool flag4 = Player.boatKeyParty == null;
						if (flag4)
						{
							Player.boatKeyParty = new Boat(mainObject.ID, mainObject.x, mainObject.y, 0, (sbyte)mainObject.type_left_right);
						}
						else
						{
							loadDataOk = false;
						}
						bool flag5 = mainObject.myBoat != null;
						if (flag5)
						{
							Player.boatKeyParty.setPartImage(mainObject.myBoat, mainObject.typePirate);
						}
						else
						{
							loadDataOk = false;
						}
						bool flag6 = mainObject.clan != null;
						if (flag6)
						{
							Player.boatKeyParty.idIconClan = mainObject.clan.idIcon;
						}
						else
						{
							loadDataOk = false;
						}
						Player.boatKeyParty.loadDataOk = loadDataOk;
					}
				}
			}
		}
		bool flag7 = Player.boatKeyParty != null;
		if (flag7)
		{
			bool flag8 = Player.boatKeyParty != null;
			if (flag8)
			{
				Player.boatKeyParty.updateXY(this.x, this.y, 0, (sbyte)this.type_left_right);
			}
			bool flag9 = this.vy != 0;
			if (flag9)
			{
				Player.boatKeyParty.setLevelPaint();
			}
			bool flag10 = this.typeMoveGotoSky != 2;
			if (flag10)
			{
				bool flag11 = GameCanvas.gameTick % 8 == 0;
				if (flag11)
				{
					Player.boatKeyParty.addEffSea(this.x, this.y, -1, (sbyte)this.type_left_right, -3);
				}
				bool flag12 = CRes.random(4) == 0;
				if (flag12)
				{
					Player.boatKeyParty.addEffSea(this.x, this.y, 0, (this.type_left_right == 0) ? 2 : 0, -3);
				}
				bool flag13 = GameCanvas.gameTick % 6 == 0;
				if (flag13)
				{
					Player.boatKeyParty.addEffSea(this.x, this.y, 2, (sbyte)this.type_left_right, -3);
				}
			}
			Player.boatKeyParty.updateBoat();
		}
		bool flag14 = this.typeMoveGotoSky == 0;
		if (flag14)
		{
			base.move_to_XY_Normal();
			this.y += this.vy;
			this.x += this.vx;
		}
		else
		{
			bool flag15 = this.typeMoveGotoSky == 1;
			if (flag15)
			{
				base.move_to_XY_Normal();
				this.y += this.vy;
				this.x += this.vx;
			}
			else
			{
				bool flag16 = this.typeMoveGotoSky == 2;
				if (flag16)
				{
					this.y += this.vy;
					this.x += this.vx;
					bool flag17 = this.vy < 10;
					if (flag17)
					{
						this.vy++;
					}
				}
				else
				{
					bool flag18 = this.typeMoveGotoSky == 3;
					if (flag18)
					{
						base.move_to_XY_Normal();
						this.y += this.vy;
						this.x += this.vx;
					}
				}
			}
		}
		bool flag19 = !MapGotoSky.isStopUpdateCamera;
		if (flag19)
		{
			MainScreen.cameraMain.moveCamera(GameScreen.player.x - MotherCanvas.w / 2, GameScreen.player.y - MotherCanvas.h / 3 * 2);
		}
		base.updateEye();
		base.updateEffSpec();
		base.updateBuff();
	}

	// Token: 0x06000BA7 RID: 2983 RVA: 0x000E2368 File Offset: 0x000E0568
	public void updateMapGotoGod(sbyte finalMove)
	{
		bool flag = Player.boatKeyParty == null || !Player.boatKeyParty.loadDataOk;
		if (flag)
		{
			for (int i = GameScreen.vecPlayers.size() - 1; i >= 0; i--)
			{
				MainObject mainObject = (MainObject)GameScreen.vecPlayers.elementAt(i);
				bool flag2 = Player.vecParty.size() > 0;
				if (flag2)
				{
					InfoMemList infoMemList = (InfoMemList)Player.vecParty.elementAt(0);
					bool flag3 = infoMemList.id == (int)mainObject.ID;
					if (flag3)
					{
						bool loadDataOk = true;
						bool flag4 = Player.boatKeyParty == null;
						if (flag4)
						{
							Player.boatKeyParty = new Boat(mainObject.ID, mainObject.x, mainObject.y, 0, (sbyte)mainObject.type_left_right);
						}
						else
						{
							loadDataOk = false;
						}
						bool flag5 = mainObject.myBoat != null;
						if (flag5)
						{
							Player.boatKeyParty.setPartImage(mainObject.myBoat, mainObject.typePirate);
						}
						else
						{
							loadDataOk = false;
						}
						bool flag6 = mainObject.clan != null;
						if (flag6)
						{
							Player.boatKeyParty.idIconClan = mainObject.clan.idIcon;
						}
						else
						{
							loadDataOk = false;
						}
						Player.boatKeyParty.loadDataOk = loadDataOk;
					}
				}
			}
		}
		bool flag7 = Player.boatKeyParty != null;
		if (flag7)
		{
			bool flag8 = Player.boatKeyParty != null;
			if (flag8)
			{
				Player.boatKeyParty.updateXY(this.x, this.y, 0, (sbyte)this.type_left_right);
			}
			bool flag9 = this.vy != 0;
			if (flag9)
			{
				Player.boatKeyParty.setLevelPaint();
			}
			bool flag10 = this.typeMoveGotoSky != 2;
			if (flag10)
			{
				bool flag11 = GameCanvas.gameTick % 8 == 0;
				if (flag11)
				{
					Player.boatKeyParty.addEffSea(this.x, this.y, -1, (sbyte)this.type_left_right, -3);
				}
				bool flag12 = CRes.random(4) == 0;
				if (flag12)
				{
					Player.boatKeyParty.addEffSea(this.x, this.y, 0, (this.type_left_right == 0) ? 2 : 0, -3);
				}
				bool flag13 = GameCanvas.gameTick % 6 == 0;
				if (flag13)
				{
					Player.boatKeyParty.addEffSea(this.x, this.y, 2, (sbyte)this.type_left_right, -3);
				}
			}
			Player.boatKeyParty.updateBoat();
		}
		bool flag14 = this.typeMoveGotoSky == 0;
		if (flag14)
		{
			base.move_to_XY_Normal();
			this.y += this.vy;
			this.x += this.vx;
		}
		else
		{
			bool flag15 = this.typeMoveGotoSky == 1;
			if (flag15)
			{
				base.move_to_XY_Normal();
				this.y += this.vy;
				this.x += this.vx;
			}
			else
			{
				bool flag16 = this.typeMoveGotoSky == 2;
				if (flag16)
				{
					bool flag17 = finalMove == 0;
					if (flag17)
					{
						base.move_to_XY_Normal();
						this.y += this.vy;
						this.x += this.vx;
					}
					else
					{
						this.y += this.vy;
						this.x += this.vx;
						bool flag18 = this.vy < 10;
						if (flag18)
						{
							this.vy++;
						}
					}
				}
				else
				{
					bool flag19 = this.typeMoveGotoSky == 3;
					if (flag19)
					{
						this.y += this.vy;
						this.x += this.vx;
						bool flag20 = this.vx < 4;
						if (flag20)
						{
							this.vx++;
						}
					}
				}
			}
		}
		base.updateEye();
		base.updateEffSpec();
		base.updateBuff();
	}

	// Token: 0x06000BA8 RID: 2984 RVA: 0x000E2760 File Offset: 0x000E0960
	public void setAutoPlayer()
	{
		this.tickdemHP++;
		this.tickdemMp++;
		bool flag = this.Action == 4 || this.Hp <= 0 || Player.isGhost;
		if (flag)
		{
			Player.setStart_EndAutoFire(false);
		}
		else
		{
			bool flag2 = Player.isMPHP;
			if (flag2)
			{
				bool flag3 = this.isUseMPHP(1);
				if (flag3)
				{
					bool flag4 = this.hpPoi == null || this.hpPoi.numPotion <= 0 || this.tickdemHP >= 500;
					if (flag4)
					{
						this.hpPoi = this.getPotionAuto(1);
						this.tickdemHP = 0;
					}
					bool flag5 = this.hpPoi != null && this.hpPoi.numPotion > 0;
					if (flag5)
					{
						this.hpPoi.Use_Item();
					}
				}
				bool flag6 = this.isUseMPHP(2);
				if (flag6)
				{
					bool flag7 = this.mpPoi == null || this.mpPoi.numPotion <= 0 || this.tickdemMp >= 500;
					if (flag7)
					{
						this.mpPoi = this.getPotionAuto(2);
						this.tickdemMp = 0;
					}
					bool flag8 = this.mpPoi != null && this.mpPoi.numPotion > 0;
					if (flag8)
					{
						this.mpPoi.Use_Item();
					}
				}
			}
			bool flag9 = Player.AutoFireCur >= 1 && this.Action != 2 && Interface_Game.isAutoFireInterface;
			if (flag9)
			{
				this.setAutoFire(Player.AutoFireCur == 2);
				bool flag10 = Player.typeAutoBuff == 1 && MsgAutoFire.value != null && GameCanvas.gameTick % 5 == 1;
				if (flag10)
				{
					this.updateAutoBuff();
				}
			}
			bool flag11 = Player.isGetItem;
			if (flag11)
			{
				this.autoGetItem();
			}
		}
	}

	// Token: 0x06000BA9 RID: 2985 RVA: 0x000E2930 File Offset: 0x000E0B30
	public void updateAutoBuff()
	{
		for (int i = 0; i < MsgAutoFire.value.Length; i++)
		{
			bool flag = MsgAutoFire.value[i][1] == 1;
			if (flag)
			{
				Skill_Info skillFromID = Skill_Info.getSkillFromID(MsgAutoFire.value[i][0]);
				bool flag2 = skillFromID != null && this.getManaNeedUse((int)skillFromID.manaLost) <= this.Mp && DelaySkill.getDelay((int)skillFromID.indexHotKey).isCoolDown() && this.beginPlayerFire(skillFromID);
				if (flag2)
				{
					break;
				}
			}
		}
	}

	// Token: 0x06000BAA RID: 2986 RVA: 0x000E29B4 File Offset: 0x000E0BB4
	private bool isUseMPHP(sbyte type)
	{
		bool flag = type == 1;
		if (flag)
		{
			bool flag2 = GameCanvas.loadmap.idMap == 986 || GameCanvas.loadmap.idMap == 985;
			if (flag2)
			{
				return false;
			}
			bool flag3 = this.Hp * 100 / this.maxHp <= MsgAutoMPHP.hp;
			if (flag3)
			{
				return true;
			}
		}
		else
		{
			bool flag4 = type == 2 && this.Mp * 100 / this.maxMp <= MsgAutoMPHP.mp;
			if (flag4)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000BAB RID: 2987 RVA: 0x000E2A50 File Offset: 0x000E0C50
	public MainItem getPotionAuto(sbyte mphp)
	{
		MainItem mainItem = null;
		for (int i = 0; i < Player.vecInventory.size(); i++)
		{
			MainItem mainItem2 = (MainItem)Player.vecInventory.elementAt(i);
			bool flag = mainItem2.typeObject == 4 && mphp == mainItem2.Hp_Mp_Other && mainItem2.numPotion > 0 && (mainItem == null || (MsgAutoMPHP.typeUu == 0 && mainItem2.value < mainItem.value) || (MsgAutoMPHP.typeUu == 1 && mainItem2.value > mainItem.value));
			if (flag)
			{
				mainItem = mainItem2;
			}
		}
		return mainItem;
	}

	// Token: 0x06000BAC RID: 2988 RVA: 0x000E2AF4 File Offset: 0x000E0CF4
	private void autoGetItem()
	{
		bool flag = GameCanvas.gameTick % 200 == 0;
		if (flag)
		{
			bool flag2 = Player.isFullInven;
			if (flag2)
			{
				Interface_Game.addInfoPlayerNormal(T.fullInven, mFont.tahoma_7_white);
				return;
			}
			int num = Player.vecInventory.size();
			bool flag3 = num >= Player.maxInventory;
			if (flag3)
			{
				Player.isFullInven = true;
			}
		}
		for (int i = 0; i < GameScreen.vecPlayers.size(); i++)
		{
			MainObject mainObject = (MainObject)GameScreen.vecPlayers.elementAt(i);
			bool flag4 = mainObject != null && !mainObject.isSend && mainObject.mItemDrop == null;
			if (flag4)
			{
				bool flag5 = false;
				bool flag6 = mainObject.namePlayer != string.Empty;
				if (flag6)
				{
					flag5 = false;
				}
				else
				{
					bool flag7 = mainObject.typeObject == 5 || mainObject.typeObject == 7;
					if (flag7)
					{
						flag5 = true;
					}
					else
					{
						bool flag8 = (mainObject.typeObject == 4 || mainObject.typeObject == 3) && this.setGetItem(mainObject);
						if (flag8)
						{
							flag5 = true;
						}
					}
				}
				bool flag9 = flag5 && MainObject.getDistance(this.x, this.y, mainObject.x, mainObject.y) < Player.wFocus;
				if (flag9)
				{
					GlobalService.gI().Get_Item_Map(mainObject.ID, mainObject.typeObject);
					mainObject.isSend = true;
				}
			}
		}
	}

	// Token: 0x06000BAD RID: 2989 RVA: 0x000E2C7C File Offset: 0x000E0E7C
	private bool setGetItem(MainObject obj)
	{
		bool flag = obj.typeObject == 4;
		if (flag)
		{
			bool flag2 = obj.colorName == 5;
			if (flag2)
			{
				bool flag3 = MsgAutoGetItem.mValue[2] == 0;
				if (flag3)
				{
					return true;
				}
			}
			else
			{
				bool flag4 = MsgAutoGetItem.mValue[1] == 3;
				if (flag4)
				{
					return false;
				}
				bool flag5 = MsgAutoGetItem.mValue[1] == 0;
				if (flag5)
				{
					return true;
				}
				bool flag6 = obj.colorName == 4 && MsgAutoGetItem.mValue[1] == 2;
				if (flag6)
				{
					return true;
				}
				bool flag7 = obj.colorName == 6 && MsgAutoGetItem.mValue[1] == 1;
				if (flag7)
				{
					return true;
				}
			}
		}
		else
		{
			bool flag8 = obj.typeObject == 3 && !Player.isFullInven;
			if (flag8)
			{
				bool flag9 = MsgAutoGetItem.mValue[0] == 3;
				if (flag9)
				{
					return false;
				}
				bool flag10 = MsgAutoGetItem.mValue[0] == 0;
				if (flag10)
				{
					return true;
				}
				bool flag11 = (int)obj.colorName > MsgAutoGetItem.mValue[0];
				if (flag11)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06000BAE RID: 2990 RVA: 0x000E2DA4 File Offset: 0x000E0FA4
	private void updateDelay()
	{
		IDictionaryEnumerator enumerator = Player.delaySkill.GetEnumerator();
		while (enumerator.MoveNext())
		{
			DelaySkill delaySkill = (DelaySkill)enumerator.Value;
			bool flag = delaySkill.value > -150;
			if (flag)
			{
				delaySkill.value -= (int)(GameCanvas.timeNow - delaySkill.timebegin);
				delaySkill.timebegin = GameCanvas.timeNow;
			}
		}
	}

	// Token: 0x06000BAF RID: 2991 RVA: 0x000E2E10 File Offset: 0x000E1010
	public void updatePlayer()
	{
		bool flag = LoadMap.specMap == 3;
		if (flag)
		{
			this.updateMapTrain();
		}
		bool flag2 = this.Hp <= 0;
		if (flag2)
		{
			this.Hp = 0;
			this.Mp = 0;
			bool flag3 = this.Action != 4;
			if (flag3)
			{
				bool flag4 = this.plashNow != null;
				if (flag4)
				{
					this.plashNow = null;
				}
				bool flag5 = this.skillCurrent != null;
				if (flag5)
				{
					this.skillCurrent.isRemove = true;
				}
				bool flag6 = this.posTransRoad != null;
				if (flag6)
				{
					this.posTransRoad = null;
				}
				Player.setStart_EndAutoFire(false);
				Interface_Game.vecEffCurrent.removeAllElements();
				this.setCmdGame();
				this.timeDie += 1L;
				bool flag7 = this.timeDie >= 40L;
				if (flag7)
				{
					this.beginDie(null);
				}
			}
			this.checkAutoRevice();
		}
		bool flag8 = this.posTransRoad != null;
		if (flag8)
		{
			this.updatePosTrans();
			base.move_to_XY();
		}
		else
		{
			bool flag9 = !Player.isSendMove;
			if (flag9)
			{
				Player.isSendMove = true;
				this.xStand = this.x;
				this.yStand = this.y;
			}
		}
		int distance = MainObject.getDistance(this.xStand, this.yStand, this.x, this.y);
		bool flag10 = distance >= 50 || this.timeStand > 20 || this.tickAfterSkill == 0;
		if (flag10)
		{
			this.xStand = this.x;
			this.yStand = this.y;
			bool flag11 = this.timeStand > 20;
			if (flag11)
			{
				this.timeStand = -1;
			}
			bool flag12 = this.tickAfterSkill == 0;
			if (flag12)
			{
				this.tickAfterSkill = -1;
			}
			bool flag13 = Player.isSendMove && !this.check_Move_EffSpec() && LoadMap.specMap != 3 && this.typeActionBoat == 0;
			if (flag13)
			{
				GlobalService.gI().Obj_Move((short)this.x, (short)this.y);
			}
		}
		bool flag14 = Player.msattam != null;
		if (flag14)
		{
			Player.mSatnhan = new short[Player.msattam.Length];
			for (int i = 0; i < Player.msattam.Length; i++)
			{
				Player.mSatnhan[i] = Player.msattam[i];
			}
			Player.msattam = null;
		}
		bool flag15 = LoadMap.specMap == 4 && this.boatSea != null && this.boatSea.ID == this.ID && GameCanvas.gameTick % 20 == 0;
		if (flag15)
		{
			this.setMoveBoatOther();
		}
	}

	// Token: 0x06000BB0 RID: 2992 RVA: 0x000E30BC File Offset: 0x000E12BC
	private void checkAutoRevice()
	{
		bool flag = Player.AutoRevice != 0;
		if (flag)
		{
			bool flag2 = Player.tickAutoRevice <= 0;
			if (flag2)
			{
				GlobalService.gI().Auto_revice(1);
				Player.tickAutoRevice = 100;
			}
			else
			{
				Player.tickAutoRevice -= 1;
			}
		}
	}

	// Token: 0x06000BB1 RID: 2993 RVA: 0x000E3110 File Offset: 0x000E1310
	private void setMoveBoatOther()
	{
		this.boatSea.boatSetVaCham(0, 0);
		for (int i = 0; i < GameScreen.vecPlayers.size(); i++)
		{
			MainObject mainObject = (MainObject)GameScreen.vecPlayers.elementAt(i);
			bool flag = mainObject == this || mainObject.boatSea == null || mainObject.boatSea.ID != mainObject.ID || mainObject.vx != 0 || mainObject.vy != 0;
			if (!flag)
			{
				mainObject.boatSea.boatSetVaCham(0, 0);
				bool flag2 = !CRes.setVaCham(this.boatSea, mainObject.boatSea);
				if (!flag2)
				{
					bool flag3 = CRes.abs(mainObject.xSeaAnchor - mainObject.x) < 48 && CRes.abs(mainObject.ySeaAnchor - mainObject.y) < 48;
					if (flag3)
					{
						mainObject.toX = mainObject.xSeaAnchor;
						mainObject.toY = mainObject.ySeaAnchor;
						mainObject.xSeaAnchor = mainObject.x;
						mainObject.ySeaAnchor = mainObject.y;
					}
					else
					{
						int num = mainObject.x;
						int num2 = mainObject.y;
						for (int j = 0; j < 4; j++)
						{
							num = mainObject.x + CRes.random_Am(24, 48);
							num2 = mainObject.y + CRes.random_Am(24, 48);
							int tile = GameCanvas.loadmap.getTile(num, num2);
							bool flag4 = !LoadMap.Tile_Stand(tile);
							if (flag4)
							{
								break;
							}
						}
						mainObject.toX = num;
						mainObject.toY = num2;
						mainObject.xSeaAnchor = mainObject.x;
						mainObject.ySeaAnchor = mainObject.y;
					}
				}
			}
		}
	}

	// Token: 0x06000BB2 RID: 2994 RVA: 0x000E32C8 File Offset: 0x000E14C8
	public override void updateMapTrain()
	{
		bool flag = GameCanvas.gameScr.left != GameCanvas.gameScr.cmdGetXpMapTrain || GameCanvas.gameScr.right != GameCanvas.gameScr.cmdThoatFormMapTrain;
		if (flag)
		{
			GameCanvas.gameScr.left = GameCanvas.gameScr.cmdGetXpMapTrain;
			GameCanvas.gameScr.right = GameCanvas.gameScr.cmdThoatFormMapTrain;
			this.center = null;
		}
		bool flag2 = GameCanvas.gameTick % 125 == 0;
		if (flag2)
		{
			GlobalService.gI().Get_Xp_Map_Train(0);
		}
		bool flag3 = (GameCanvas.gameTick % 75 == 0 || !this.isBeginTrain) && CRes.random(3) == 0 && this.Action != 2;
		if (flag3)
		{
			GameScreen.player.toX = GameScreen.player.x;
			GameScreen.player.toY = GameScreen.player.y;
			bool flag4 = GameScreen.player.posTransRoad != null;
			if (flag4)
			{
				GameScreen.player.countAutoMove = 1;
			}
			for (int i = 0; i < 10; i++)
			{
				int num = CRes.random(MainObject.mPosMapTrain.Length);
				bool flag5 = num != Player.indexPosMapTrain;
				if (flag5)
				{
					Player.indexPosMapTrain = num;
					break;
				}
			}
			this.posTransRoad = GameCanvas.loadmap.updateFindRoad(MainObject.mPosMapTrain[Player.indexPosMapTrain][0], MainObject.mPosMapTrain[Player.indexPosMapTrain][1], GameScreen.player.x / LoadMap.wTile, GameScreen.player.y / LoadMap.wTile, 200, this);
			Player.AutoFireCur = 0;
			this.isBeginTrain = true;
		}
		bool flag6 = this.posTransRoad == null;
		if (flag6)
		{
			Player.setStart_EndAutoFire(true);
		}
	}

	// Token: 0x06000BB3 RID: 2995 RVA: 0x000E348C File Offset: 0x000E168C
	private void updatePosTrans()
	{
		bool flag = CRes.abs(this.x - this.toX) > this.vMax || CRes.abs(this.y - this.toY) > this.vMax;
		if (!flag)
		{
			bool flag2 = this.countAutoMove > this.posTransRoad.Length - 1;
			if (flag2)
			{
				this.countAutoMove = 0;
				this.posTransRoad = null;
				this.xStopMove = 0;
				this.yStopMove = 0;
			}
			else
			{
				bool flag3 = this.countAutoMove == this.posTransRoad.Length - 1 && this.xStopMove > 0 && this.yStopMove > 0;
				if (flag3)
				{
					this.toX = this.xStopMove;
					this.toY = this.yStopMove;
				}
				else
				{
					sbyte b = (sbyte)(this.posTransRoad[this.countAutoMove] >> 8);
					sbyte b2 = (sbyte)(this.posTransRoad[this.countAutoMove] & 255);
					this.toX = (int)b * LoadMap.wTile + LoadMap.wTile / 2;
					this.toY = (int)b2 * LoadMap.wTile + LoadMap.wTile / 2;
				}
				this.countAutoMove++;
			}
		}
	}

	// Token: 0x06000BB4 RID: 2996 RVA: 0x000E35BC File Offset: 0x000E17BC
	public void updateKey()
	{
		bool flag = LoadMap.specMap == 3 || this.typeActionBoat != 0;
		if (!flag)
		{
			bool flag2 = !Player.isGhost;
			if (flag2)
			{
				bool flag3 = false;
				bool flag4 = this.Action != 4 && this.Action != 2 && this.Action != 3 && Player.isSendMove && this.posTransRoad == null && this.Hp > 0;
				if (flag4)
				{
					this.vx = 0;
					this.vy = 0;
					this.setKeyMoveNew();
					bool flag5 = this.vx == 0 && this.vy == 0;
					if (flag5)
					{
						bool flag6 = this.timeStand != -1;
						if (flag6)
						{
							this.timeStand++;
						}
					}
					else
					{
						flag3 = true;
						this.timeStand = 0;
						Player.setStart_EndAutoFire(false);
					}
				}
				bool flag7 = flag3;
				if (flag7)
				{
					this.skillCurrent = null;
				}
				bool flag8 = GameCanvas.keyActionUni(6) && GameScreen.objFocus != null;
				if (flag8)
				{
					GameCanvas.ClearActionUni(6);
					bool flag9 = !GameCanvas.loadmap.mapLang();
					if (flag9)
					{
						GameScreen.interfaceGame.selectPointer(2);
					}
				}
				bool flag10 = GameCanvas.keyActionUni(8);
				if (flag10)
				{
					GameCanvas.ClearActionUni(8);
					GameCanvas.gameScr.cmdEvent.perform();
				}
			}
			bool flag11 = GameCanvas.keyActionUni(1);
			if (flag11)
			{
				this.setActionHotKey(0);
			}
			else
			{
				bool flag12 = GameCanvas.keyActionUni(3);
				if (flag12)
				{
					this.setActionHotKey(1);
				}
				else
				{
					bool flag13 = GameCanvas.keyActionUni(5);
					if (flag13)
					{
						this.setActionHotKey(2);
					}
					else
					{
						bool flag14 = GameCanvas.keyActionUni(7);
						if (flag14)
						{
							this.setActionHotKey(3);
						}
						else
						{
							bool flag15 = GameCanvas.keyActionUni(9);
							if (flag15)
							{
								this.setActionHotKey(4);
							}
						}
					}
				}
			}
			bool flag16 = GameCanvas.keyActionUni(10);
			if (flag16)
			{
				GameCanvas.ClearActionUni(10);
				GameCanvas.gameScr.cmdChatPopup.perform();
			}
			bool flag17 = GameCanvas.keyMyHold[40] || (GameCanvas.isTouch && GameCanvas.keyMyHold[12]);
			if (flag17)
			{
				GameCanvas.clearKeyHold(40);
				GameCanvas.clearKeyHold(12);
				GameCanvas.gameScr.cmdInfoMe.perform();
			}
			bool flag18 = GameCanvas.keyMyHold[41] || (GameCanvas.isTouch && GameCanvas.keyMyHold[13]);
			if (flag18)
			{
				GameCanvas.clearKeyHold(41);
				GameCanvas.clearKeyHold(13);
				GameCanvas.gameScr.cmdNextFocus.perform();
			}
			bool flag19 = GameCanvas.keyActionUni(4);
			if (flag19)
			{
				GameCanvas.ClearActionUni(4);
				bool isTouch = GameCanvas.isTouch;
				if (isTouch)
				{
					Interface_Game.startQuickMenu();
				}
				else
				{
					this.actionPC(4);
				}
			}
			bool flag20 = GameCanvas.isTouchNoOrPC();
			if (flag20)
			{
				bool flag21 = GameCanvas.keyActionUni(11);
				if (flag21)
				{
					GameCanvas.ClearActionUni(11);
					this.actionPC(11);
				}
				else
				{
					bool flag22 = GameCanvas.keyActionUni(12);
					if (flag22)
					{
						GameCanvas.ClearActionUni(12);
						this.actionPC(12);
					}
					else
					{
						bool flag23 = GameCanvas.keyActionUni(13);
						if (flag23)
						{
							GameCanvas.ClearActionUni(13);
							this.actionPC(13);
						}
						else
						{
							bool flag24 = GameCanvas.keyActionUni(14);
							if (flag24)
							{
								GameCanvas.ClearActionUni(14);
								this.actionPC(14);
							}
							else
							{
								bool flag25 = GameCanvas.keyActionUni(16);
								if (flag25)
								{
									GameCanvas.ClearActionUni(16);
									this.actionPC(16);
								}
								else
								{
									bool flag26 = GameCanvas.keyActionUni(15);
									if (flag26)
									{
										GameCanvas.ClearActionUni(15);
										GameCanvas.gameScr.cmdFriendList.perform();
									}
								}
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x06000BB5 RID: 2997 RVA: 0x000E3960 File Offset: 0x000E1B60
	public void actionPC(sbyte type)
	{
		GlobalService.gI().Update_Pk_Point();
		GameCanvas.tabInven.setTypeInven(0);
		GameCanvas.tabAllScr.Show(GameCanvas.gameScr);
		this.resetAction();
		GameCanvas.clearAll();
		bool flag = GameCanvas.currentScreen == GameCanvas.tabAllScr;
		if (flag)
		{
			bool flag2 = type == 11;
			if (flag2)
			{
				GameCanvas.tabAllScr.idSelect = 0;
			}
			else
			{
				bool flag3 = type == 12;
				if (flag3)
				{
					GameCanvas.tabAllScr.idSelect = 4;
				}
				else
				{
					bool flag4 = type == 13;
					if (flag4)
					{
						GameCanvas.tabAllScr.idSelect = 2;
					}
					else
					{
						bool flag5 = type == 14;
						if (flag5)
						{
							GameCanvas.tabAllScr.idSelect = 3;
						}
						else
						{
							bool flag6 = type == 16;
							if (flag6)
							{
								GameCanvas.tabAllScr.idSelect = 1;
							}
							else
							{
								bool flag7 = type == 4 && GameCanvas.tabAllScr.vecTabs.size() == 6;
								if (flag7)
								{
									GameCanvas.tabAllScr.idSelect = 5;
								}
							}
						}
					}
				}
			}
			GameCanvas.tabAllScr.setTabSelect();
			GameCanvas.tabAllScr.tabCurrent.beginFocus();
		}
	}

	// Token: 0x06000BB6 RID: 2998 RVA: 0x000E3A80 File Offset: 0x000E1C80
	private void setKeyMoveNew()
	{
		for (int i = 0; i < 4; i++)
		{
			bool flag = GameCanvas.keyMove(i);
			if (flag)
			{
				bool flag2 = this.mindexkey[i] == -1;
				if (flag2)
				{
					this.mindexkey[i] = this.indexkey;
					this.indexkey++;
				}
			}
			else
			{
				this.mindexkey[i] = -1;
			}
		}
		int num = -1;
		int num2 = -1;
		for (int j = 0; j < this.mindexkey.Length; j++)
		{
			bool flag3 = this.mindexkey[j] > num;
			if (flag3)
			{
				num = this.mindexkey[j];
				num2 = j;
			}
		}
		bool flag4 = num2 > -1;
		if (flag4)
		{
			this.setKeyMoveNew(num2);
		}
		else
		{
			this.indexkey = 0;
		}
	}

	// Token: 0x06000BB7 RID: 2999 RVA: 0x000E3B50 File Offset: 0x000E1D50
	private void setKeyMoveNew(int valuemax)
	{
		switch (valuemax)
		{
		case 0:
			this.Action = 1;
			this.Dir = 0;
			this.vx = -this.vMax;
			this.vy = 0;
			break;
		case 1:
		{
			this.Action = 1;
			bool flag = LoadMap.specMap == 4;
			if (flag)
			{
				this.vy = -this.vMaxYSea;
			}
			else
			{
				this.vy = -this.vMax;
			}
			this.vx = 0;
			break;
		}
		case 2:
			this.Action = 1;
			this.Dir = 2;
			this.vx = this.vMax;
			this.vy = 0;
			break;
		case 3:
		{
			this.Action = 1;
			bool flag2 = LoadMap.specMap == 4;
			if (flag2)
			{
				this.vy = this.vMaxYSea;
			}
			else
			{
				this.vy = this.vMax;
			}
			this.vx = 0;
			break;
		}
		}
	}

	// Token: 0x06000BB8 RID: 3000 RVA: 0x000E3C40 File Offset: 0x000E1E40
	public void setFocus(bool allFocus)
	{
		bool flag = GameScreen.objFocus != null && ((GameScreen.objFocus.typeObject == 1 && (GameScreen.objFocus.Action == 4 || GameScreen.objFocus.isDie)) || MainObject.getDistance(GameScreen.objFocus.x, GameScreen.objFocus.y, this.x, this.y) > Player.wFocus + 60);
		if (flag)
		{
			GameScreen.objFocus = null;
			GameCanvas.gameScr.center = null;
			bool isPaintInfoFocus = Interface_Game.isPaintInfoFocus;
			if (isPaintInfoFocus)
			{
				Interface_Game.isPaintInfoFocus = false;
			}
		}
		bool flag2 = this.Action == 2 || this.Action == 4 || GameScreen.objFocus != null;
		if (!flag2)
		{
			int num = GameScreen.vecPlayers.size();
			bool flag3 = this.indexFocus > num - 1;
			if (flag3)
			{
				this.indexFocus = num - 1;
			}
			int num2 = 1000;
			int num3 = -1;
			MainObject mainObject = null;
			for (int i = 0; i < num; i++)
			{
				MainObject mainObject2 = (MainObject)GameScreen.vecPlayers.elementAt((i + this.indexFocus) % num);
				int distance = MainObject.getDistance(mainObject2.x, mainObject2.y, this.x, this.y);
				bool flag4 = distance <= Player.wFocus;
				if (flag4)
				{
					int num4 = this.setTypeFocus((int)mainObject2.typeObject);
					bool flag5 = num4 >= num3 && !this.CheckSkipFocus(mainObject2) && (mainObject2.typeObject != 2 || !allFocus) && (distance < num2 || num4 > num3);
					if (flag5)
					{
						mainObject = mainObject2;
						num2 = distance;
						this.indexFocus = i;
						num3 = num4;
					}
				}
			}
			bool flag6 = mainObject != null;
			if (flag6)
			{
				GameScreen.objFocus = mainObject;
				bool flag7 = !GameCanvas.isTouch;
				if (flag7)
				{
					GameCanvas.gameScr.center = GameScreen.objFocus.getCenterCmd();
				}
			}
		}
	}

	// Token: 0x06000BB9 RID: 3001 RVA: 0x000E3E30 File Offset: 0x000E2030
	private int setTypeFocus(int typeObj)
	{
		int result = -1;
		switch (typeObj)
		{
		case 0:
			result = 0;
			break;
		case 1:
			result = 1;
			break;
		case 2:
			result = 3;
			break;
		case 3:
		case 4:
			result = 2;
			break;
		}
		return result;
	}

	// Token: 0x06000BBA RID: 3002 RVA: 0x000E3E78 File Offset: 0x000E2078
	private bool CheckSkipFocus(MainObject obj)
	{
		return obj == GameScreen.player || ((obj.Action == 4 || obj.isDie) && obj.typeObject != 0) || obj.isRemove || (GameScreen.objFocus != null && obj == GameScreen.objFocus) || obj.typeObject == 10;
	}

	// Token: 0x06000BBB RID: 3003 RVA: 0x000E3EDC File Offset: 0x000E20DC
	public void nextFocus()
	{
		Player.setStart_EndAutoFire(false);
		bool flag = this.Action == 2;
		if (!flag)
		{
			int num = -1;
			bool flag2 = GameScreen.objFocus != null;
			if (flag2)
			{
				for (int i = 0; i < GameScreen.vecPlayers.size(); i++)
				{
					MainObject mainObject = (MainObject)GameScreen.vecPlayers.elementAt(i);
					bool flag3 = mainObject == GameScreen.objFocus;
					if (flag3)
					{
						num = i;
						break;
					}
				}
			}
			bool flag4 = this.typePK == 0;
			if (flag4)
			{
				bool flag5 = num >= 0;
				if (flag5)
				{
					for (int j = num; j < GameScreen.vecPlayers.size(); j++)
					{
						MainObject mainObject2 = (MainObject)GameScreen.vecPlayers.elementAt(j);
						bool flag6 = mainObject2.typeObject == 0 && !this.CheckSkipFocus(mainObject2) && MainObject.getDistance(mainObject2.x, mainObject2.y, this.x, this.y) < Player.wFocus;
						if (flag6)
						{
							GameScreen.objFocus = mainObject2;
							bool flag7 = !GameCanvas.isTouch;
							if (flag7)
							{
								GameCanvas.gameScr.center = GameScreen.objFocus.getCenterCmd();
							}
							return;
						}
					}
				}
				else
				{
					num = GameScreen.vecPlayers.size();
				}
			}
			bool flag8 = num >= 0;
			if (flag8)
			{
				for (int k = num; k < GameScreen.vecPlayers.size(); k++)
				{
					MainObject mainObject3 = (MainObject)GameScreen.vecPlayers.elementAt(k);
					bool flag9 = !this.CheckSkipFocus(mainObject3) && (this.typePK != 0 || mainObject3.typeObject != 0) && MainObject.getDistance(mainObject3.x, mainObject3.y, this.x, this.y) < Player.wFocus;
					if (flag9)
					{
						GameScreen.objFocus = mainObject3;
						bool flag10 = !GameCanvas.isTouch;
						if (flag10)
						{
							GameCanvas.gameScr.center = GameScreen.objFocus.getCenterCmd();
						}
						return;
					}
				}
			}
			else
			{
				num = GameScreen.vecPlayers.size();
			}
			for (int l = 0; l < num; l++)
			{
				MainObject mainObject4 = (MainObject)GameScreen.vecPlayers.elementAt(l);
				bool flag11 = !this.CheckSkipFocus(mainObject4) && (this.typePK != 0 || mainObject4.typeObject != 0) && MainObject.getDistance(mainObject4.x, mainObject4.y, this.x, this.y) < Player.wFocus;
				if (flag11)
				{
					GameScreen.objFocus = mainObject4;
					bool flag12 = !GameCanvas.isTouch;
					if (flag12)
					{
						GameCanvas.gameScr.center = GameScreen.objFocus.getCenterCmd();
					}
					break;
				}
			}
		}
	}

	// Token: 0x06000BBC RID: 3004 RVA: 0x000E41B8 File Offset: 0x000E23B8
	public void nextMonster()
	{
		int num = Player.wFocus * 3 / 2;
		MainObject mainObject = null;
		for (int i = 0; i < GameScreen.vecPlayers.size(); i++)
		{
			MainObject mainObject2 = (MainObject)GameScreen.vecPlayers.elementAt(i);
			bool flag = mainObject2 != null && mainObject2.Action != 4 && !mainObject2.isSend && mainObject2.typeObject != 10 && mainObject2.typeObject == 1;
			if (flag)
			{
				int distance = MainObject.getDistance(this.x, this.y, mainObject2.x, mainObject2.y);
				bool flag2 = distance < num;
				if (flag2)
				{
					num = distance;
					mainObject = mainObject2;
				}
			}
		}
		bool flag3 = mainObject != null;
		if (flag3)
		{
			GameScreen.objFocus = mainObject;
			this.demUnFire = 0;
		}
		else
		{
			this.demUnFire++;
		}
	}

	// Token: 0x06000BBD RID: 3005 RVA: 0x000E4294 File Offset: 0x000E2494
	public void setActionHotKey(int index)
	{
		GameCanvas.clearAll();
		bool flag = Player.isGhost;
		if (flag)
		{
			Point_Focus point_Focus = new Point_Focus();
			point_Focus.dis = index;
			Player.vecGhostInput.addElement(point_Focus);
			bool flag2 = Player.vecGhostInput.size() > 4;
			if (flag2)
			{
				Player.vecGhostInput.removeElementAt(0);
			}
			GlobalService.gI().ghost((sbyte)index);
		}
		else
		{
			bool flag3 = this.Action != 2 && this.Action != 4 && this.Hp > 0;
			if (flag3)
			{
				Hotkey hotkey = Player.hotkeyPlayer[(int)Player.currentTab][index];
				bool flag4 = hotkey.itemcur != null;
				if (flag4)
				{
					hotkey.itemcur.Use_Item();
				}
				else
				{
					bool flag5 = hotkey.skill != null && hotkey.skill.isBuff && !GameCanvas.loadmap.mapLang() && this.setSkillBuff(index, hotkey);
					if (flag5)
					{
						this.beginPlayerFire(index, hotkey);
					}
					else
					{
						bool flag6 = GameScreen.objFocus != null;
						if (flag6)
						{
							GameScreen.objFocus.setFireObject(index);
						}
					}
				}
			}
		}
	}

	// Token: 0x06000BBE RID: 3006 RVA: 0x000E43B4 File Offset: 0x000E25B4
	public void setActionHotKeyBuff(int index)
	{
		GameCanvas.clearAll();
		bool flag = this.Action != 2 && this.Action != 4 && this.Hp > 0;
		if (flag)
		{
			Hotkey hotkey = Player.hotkeyBuffPlayer[index];
			bool flag2 = hotkey != null && hotkey.skill != null && !GameCanvas.loadmap.mapLang() && this.setSkillBuff(index, hotkey);
			if (flag2)
			{
				this.beginPlayerFire(index, hotkey);
			}
		}
	}

	// Token: 0x06000BBF RID: 3007 RVA: 0x000E4428 File Offset: 0x000E2628
	private bool setSkillBuff(int index, Hotkey hot)
	{
		Skill_Info skillFromID = Skill_Info.getSkillFromID(hot.skill.ID);
		bool flag = skillFromID.typeSkill == 2;
		if (flag)
		{
			bool flag2 = skillFromID.typeBuff == 1 || skillFromID.typeBuff == 2;
			if (flag2)
			{
				return true;
			}
			bool flag3 = skillFromID.typeBuff == 3;
			if (flag3)
			{
				return this.setFightPk(GameScreen.objFocus);
			}
		}
		return false;
	}

	// Token: 0x06000BC0 RID: 3008 RVA: 0x000E4498 File Offset: 0x000E2698
	public void beginPlayerFirePoint()
	{
		bool flag = this.Action == 4 || this.Hp <= 0;
		if (!flag)
		{
			for (int i = 0; i < Player.hotkeyPlayer[0].Length; i++)
			{
				int num = i;
				bool flag2 = i == 0;
				if (flag2)
				{
					num = 2;
				}
				else
				{
					bool flag3 = i <= 2;
					if (flag3)
					{
						num = i - 1;
					}
				}
				Hotkey hotkey = Player.hotkeyPlayer[(int)Player.currentTab][num];
				bool flag4 = hotkey.skill != null;
				if (flag4)
				{
					Skill_Info skillFromID = Skill_Info.getSkillFromID(hotkey.skill.ID);
					DelaySkill delay = DelaySkill.getDelay((int)skillFromID.indexHotKey);
					bool flag5 = delay.isCoolDown() && this.Mp >= this.getManaNeedUse((int)skillFromID.manaLost);
					if (flag5)
					{
						this.beginPlayerFire(num, hotkey);
						break;
					}
				}
			}
		}
	}

	// Token: 0x06000BC1 RID: 3009 RVA: 0x000E4584 File Offset: 0x000E2784
	public bool beginPlayerFire(Skill_Info skill_info)
	{
		bool flag = skill_info == null;
		bool result;
		if (flag)
		{
			result = false;
		}
		else
		{
			Player.setStart_EndAutoFire(true);
			DelaySkill delay = DelaySkill.getDelay((int)skill_info.indexHotKey);
			bool flag2 = !delay.isCoolDown();
			if (flag2)
			{
				result = false;
			}
			else
			{
				bool flag3 = (LoadMap.specMap == 4 && skill_info.typeSkill == 1) || (LoadMap.specMap != 4 && skill_info.typeSkill == 4);
				if (flag3)
				{
					Interface_Game.addInfoPlayerNormal(T.khongdungduocmapnay, mFont.tahoma_7_white);
				}
				bool flag4 = this.Mp < this.getManaNeedUse((int)skill_info.manaLost);
				if (flag4)
				{
					Interface_Game.addInfoPlayerNormal(T.manaLost, mFont.tahoma_7_white);
					result = false;
				}
				else
				{
					bool flag5 = this.check_Fire_EffSpec();
					if (flag5)
					{
						result = false;
					}
					else
					{
						mVector mVector = new mVector();
						mVector = this.setSkillLan(skill_info);
						bool flag6 = LoadMap.specMap == 3;
						if (flag6)
						{
							for (int i = 0; i < mVector.size(); i++)
							{
								Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)mVector.elementAt(i);
								MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
								bool flag7 = mainObject != null;
								if (flag7)
								{
									object_Effect_Skill.setHP(mainObject.maxHp / 10, mainObject.Hp - mainObject.maxHp / 10, 0);
								}
							}
						}
						MainSkill mainSkill = this.createSkill(skill_info);
						bool flag8 = mainSkill == null || mVector.size() == 0;
						if (flag8)
						{
							result = false;
						}
						else
						{
							bool flag9 = skill_info.typeSkill == 1 || skill_info.typeSkill == 4;
							if (flag9)
							{
								this.objAutoFrist = GameScreen.objFocus;
							}
							this.skillCurrent = new Start_Skill(this, mVector, mainSkill);
							this.skillCurrent.setMoveFire();
							bool flag10 = this.checkEffSpec(8);
							if (flag10)
							{
								this.skillCurrent.isRemove = true;
							}
							result = true;
						}
					}
				}
			}
		}
		return result;
	}

	// Token: 0x06000BC2 RID: 3010 RVA: 0x000E4770 File Offset: 0x000E2970
	public int getManaNeedUse(int mana)
	{
		return mana + mana * (int)Player.TangManaUseSkill / 1000;
	}

	// Token: 0x06000BC3 RID: 3011 RVA: 0x000E4794 File Offset: 0x000E2994
	public void beginPlayerFire(int index)
	{
		Hotkey hot = Player.hotkeyPlayer[(int)Player.currentTab][index];
		this.beginPlayerFire(index, hot);
	}

	// Token: 0x06000BC4 RID: 3012 RVA: 0x000E47BC File Offset: 0x000E29BC
	public void beginPlayerFire(int index, Hotkey hot)
	{
		bool flag = hot.skill != null;
		if (flag)
		{
			Skill_Info skillFromID = Skill_Info.getSkillFromID(hot.skill.ID);
			this.beginPlayerFire(skillFromID);
		}
	}

	// Token: 0x06000BC5 RID: 3013 RVA: 0x000E47F4 File Offset: 0x000E29F4
	public void setCmdGame()
	{
		bool flag = GameScreen.typeViewPlayer == 0;
		if (flag)
		{
			bool flag2 = GameCanvas.currentScreen != GameCanvas.gameScr;
			if (!flag2)
			{
				bool flag3 = LoadMap.specMap == 3;
				if (flag3)
				{
					bool flag4 = GameCanvas.gameScr.left != GameCanvas.gameScr.cmdGetXpMapTrain || GameCanvas.gameScr.right != GameCanvas.gameScr.cmdThoatFormMapTrain;
					if (flag4)
					{
						GameCanvas.gameScr.left = GameCanvas.gameScr.cmdGetXpMapTrain;
						GameCanvas.gameScr.right = GameCanvas.gameScr.cmdThoatFormMapTrain;
						this.center = null;
					}
				}
				else
				{
					bool flag5 = this.Action == 4;
					if (flag5)
					{
						bool flag6 = !this.checkShowHoiSinh();
						if (!flag6)
						{
							bool flag7 = !GameCanvas.isTouch;
							if (flag7)
							{
								bool flag8 = GameCanvas.gameScr.left != GameCanvas.gameScr.cmdHoiSinh;
								if (flag8)
								{
									GameCanvas.gameScr.left = GameCanvas.gameScr.cmdHoiSinh;
								}
							}
							else
							{
								bool flag9 = GameCanvas.gameScr.center != GameCanvas.gameScr.cmdHoiSinh;
								if (flag9)
								{
									GameCanvas.gameScr.center = GameCanvas.gameScr.cmdHoiSinh;
									GameCanvas.gameScr.cmdHoiSinh = AvMain.setPosCMD(GameCanvas.gameScr.cmdHoiSinh, 0);
								}
							}
						}
					}
					else
					{
						bool flag10 = !GameCanvas.isTouch;
						if (flag10)
						{
							bool flag11 = GameCanvas.gameScr.left != GameCanvas.gameScr.cmdInfoMe;
							if (flag11)
							{
								GameCanvas.gameScr.left = GameCanvas.gameScr.cmdInfoMe;
							}
							bool flag12 = GameCanvas.gameScr.right != GameCanvas.gameScr.cmdNextFocus;
							if (flag12)
							{
								GameCanvas.gameScr.right = GameCanvas.gameScr.cmdNextFocus;
							}
						}
						else
						{
							bool flag13 = GameCanvas.gameScr.center == GameCanvas.gameScr.cmdHoiSinh || GameCanvas.gameScr.center == GameCanvas.gameScr.cmdVeLang;
							if (flag13)
							{
								GameCanvas.gameScr.center = null;
							}
						}
					}
				}
			}
		}
		else
		{
			bool flag14 = GameScreen.typeViewPlayer == 1;
			if (flag14)
			{
				bool flag15 = GameCanvas.gameScr.left != GameCanvas.gameScr.cmdSettingView;
				if (flag15)
				{
					GameCanvas.gameScr.left = GameCanvas.gameScr.cmdSettingView;
				}
				bool flag16 = GameCanvas.gameScr.right != GameCanvas.gameScr.cmdExitView;
				if (flag16)
				{
					GameCanvas.gameScr.right = GameCanvas.gameScr.cmdExitView;
				}
				bool flag17 = GameCanvas.gameScr.center != null;
				if (flag17)
				{
					GameCanvas.gameScr.center = null;
				}
			}
		}
	}

	// Token: 0x06000BC6 RID: 3014 RVA: 0x000E4ACC File Offset: 0x000E2CCC
	public bool checkShowHoiSinh()
	{
		bool flag = LoadMap.specMap == 1 || LoadMap.specMap == 2 || LoadMap.specMap == 10 || LoadMap.specMap == 11;
		return !flag;
	}

	// Token: 0x06000BC7 RID: 3015 RVA: 0x000E4B10 File Offset: 0x000E2D10
	public bool setFightPk(MainObject objset)
	{
		bool flag = objset == null || objset.returnAction() || objset.Action == 4;
		bool result;
		if (flag)
		{
			result = false;
		}
		else
		{
			bool flag2 = GameCanvas.loadmap.mapLang();
			if (flag2)
			{
				result = false;
			}
			else
			{
				bool flag3 = objset.typeObject == 1;
				if (flag3)
				{
					bool flag4 = !objset.isTru() || this.typePK != objset.typePK;
					result = flag4;
				}
				else
				{
					bool flag5 = objset.typeObject == 2;
					if (flag5)
					{
						result = false;
					}
					else
					{
						bool flag6 = this.typePirate != -1;
						if (flag6)
						{
							bool flag7 = objset.typePirate == this.typePirate && objset.IDMainShiper == this.ID;
							if (flag7)
							{
								return false;
							}
							bool flag8 = (this.typePirate == 0 || this.typePirate == 1) && objset.typePirate == 2;
							if (flag8)
							{
								return true;
							}
							bool flag9 = this.typePirate == 2 && objset.typePirate != -1;
							if (flag9)
							{
								return true;
							}
						}
						bool flag10 = objset.Lv < Player.LvMinPk;
						if (flag10)
						{
							result = false;
						}
						else
						{
							bool flag11 = this.typePK == 0;
							if (flag11)
							{
								result = true;
							}
							else
							{
								bool flag12 = objset.typePK == 0;
								if (flag12)
								{
									result = true;
								}
								else
								{
									bool flag13 = objset.typePK == 1;
									if (flag13)
									{
										result = true;
									}
									else
									{
										bool flag14 = this.typePK == 2 && objset.typePK >= 0;
										if (flag14)
										{
											result = true;
										}
										else
										{
											bool flag15 = this.typePK == 3 && !this.checkCungClan(objset) && objset.typePK >= 0;
											if (flag15)
											{
												result = true;
											}
											else
											{
												bool flag16 = this.typePK >= 4 && objset.typePK >= 0 && objset.typePK != this.typePK && objset.typePlayer != 2 && objset.typePlayer != 3;
												if (flag16)
												{
													result = true;
												}
												else
												{
													bool flag17 = this.typePK == 1;
													if (flag17)
													{
														for (int i = 0; i < Player.mSatnhan.Length; i++)
														{
															bool flag18 = objset.ID == Player.mSatnhan[i];
															if (flag18)
															{
																return true;
															}
														}
														result = false;
													}
													else
													{
														result = false;
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		return result;
	}

	// Token: 0x06000BC8 RID: 3016 RVA: 0x000E4D8C File Offset: 0x000E2F8C
	private bool checkCungClan(MainObject objset)
	{
		bool flag = this.clan == null;
		bool result;
		if (flag)
		{
			result = false;
		}
		else
		{
			bool flag2 = objset.clan == null;
			if (flag2)
			{
				result = false;
			}
			else
			{
				bool flag3 = this.clan.ID != objset.clan.ID;
				result = !flag3;
			}
		}
		return result;
	}

	// Token: 0x06000BC9 RID: 3017 RVA: 0x000E4DE8 File Offset: 0x000E2FE8
	public override void addSkillFire(MainSkill skill, mVector vec)
	{
		this.tickAfterSkill = 70;
		bool flag = GameScreen.indexHelp == 2;
		if (flag)
		{
			MainHelp.setNextHelp(false);
		}
		bool flag2 = vec != null;
		if (flag2)
		{
			for (int i = 0; i < vec.size(); i++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)vec.elementAt(i);
				bool flag3 = object_Effect_Skill.tem != 1;
				if (flag3)
				{
					break;
				}
				bool flag4 = object_Effect_Skill.hpLast <= 0;
				if (flag4)
				{
					try
					{
						MainQuest.updateDataQuestKillMon(object_Effect_Skill.ID);
					}
					catch (Exception)
					{
					}
				}
			}
		}
		bool isAdd = true;
		for (int j = 0; j < GameScreen.VecEffect.size(); j++)
		{
			MainEffect mainEffect = (MainEffect)GameScreen.VecEffect.elementAt(j);
			bool flag5 = mainEffect.valueEffect == 0 && !mainEffect.isAddHP && !mainEffect.isStop && mainEffect.typeEffect == (int)skill.typeEffSkill && mainEffect.timeAddNum == -1 && mainEffect.objFireMain != null && mainEffect.objFireMain == GameScreen.player;
			if (flag5)
			{
				mainEffect.replaceHP(vec);
				mainEffect.isEff = false;
				mainEffect.isAddHP = true;
				isAdd = false;
				break;
			}
		}
		Effect_Skill.setHP_New(vec, this, isAdd);
	}

	// Token: 0x06000BCA RID: 3018 RVA: 0x000E4F4C File Offset: 0x000E314C
	public static void setHotKey(int index, MainSkill skill, MainItem item)
	{
		bool flag = skill != null;
		if (flag)
		{
			Player.hotkeyPlayer[(int)Player.currentTab][index].setSkill(skill, skill.idIcon);
		}
		else
		{
			bool flag2 = item != null;
			if (flag2)
			{
				Player.hotkeyPlayer[(int)Player.currentTab][index].setPotion(item);
			}
		}
		bool flag3 = LoadMap.specMap != 4;
		if (flag3)
		{
			GameCanvas.saveRms.saveHotKey();
		}
	}

	// Token: 0x06000BCB RID: 3019 RVA: 0x000E4FBC File Offset: 0x000E31BC
	public static void setHotKeyBuff()
	{
		bool flag = !GameCanvas.isTouch || Player.vecListSkill == null;
		if (!flag)
		{
			bool flag2 = Player.hotkeyBuffPlayer == null;
			if (flag2)
			{
				Player.hotkeyBuffPlayer = new Hotkey[6];
			}
			for (int i = 0; i < Player.hotkeyBuffPlayer.Length; i++)
			{
				Player.hotkeyBuffPlayer[i] = null;
			}
			int num = 0;
			for (int j = 0; j < Player.vecListSkill.size(); j++)
			{
				Skill_Info skill_Info = (Skill_Info)Player.vecListSkill.elementAt(j);
				bool flag3 = skill_Info.Lv_RQ >= 0 && skill_Info.typeSkill == 2;
				if (flag3)
				{
					MainSkill mainSkill = new MainSkill(skill_Info.ID, skill_Info.typeEffSkill);
					Player.hotkeyBuffPlayer[num] = new Hotkey();
					mainSkill.indexHotKey = skill_Info.indexHotKey;
					Player.hotkeyBuffPlayer[num].setSkill(mainSkill, skill_Info.idIcon);
					num++;
				}
				bool flag4 = num == 6;
				if (flag4)
				{
					break;
				}
			}
		}
	}

	// Token: 0x06000BCC RID: 3020 RVA: 0x000E50D4 File Offset: 0x000E32D4
	public static void setDelaySkill(int index, int time, bool isNotCooldown, sbyte isSkill)
	{
		DelaySkill delay = DelaySkill.getDelay(index);
		bool flag = !isNotCooldown;
		if (flag)
		{
			bool flag2 = GameScreen.player.checkEffSpec(8);
			if (flag2)
			{
				time += time / 2;
			}
			time -= time * (int)Player.GiamCountDownCur / 1000;
		}
		bool flag3 = time < 1000;
		if (flag3)
		{
			time = 1000;
		}
		delay.timebegin = GameCanvas.timeNow;
		delay.value = time;
		delay.limit = time;
		delay.typeSkill = isSkill;
	}

	// Token: 0x06000BCD RID: 3021 RVA: 0x0000B941 File Offset: 0x00009B41
	public void setUseMana(int manause)
	{
		this.Mp -= this.getManaNeedUse(manause);
	}

	// Token: 0x06000BCE RID: 3022 RVA: 0x000E5154 File Offset: 0x000E3354
	public MainSkill createSkill(Skill_Info info)
	{
		bool flag = info == null;
		MainSkill result;
		if (flag)
		{
			result = null;
		}
		else
		{
			MainSkill mainSkill = new MainSkill(info.ID, info.typeEffSkill);
			bool flag2 = info.typeSkill == 2;
			if (flag2)
			{
				mainSkill.setTypeBuff(1, 46, 0);
			}
			mainSkill.range = (int)info.range;
			mainSkill.timeDelay = info.timeDelay;
			mainSkill.indexHotKey = info.indexHotKey;
			mainSkill.mana = (int)info.manaLost;
			mainSkill.typeDevil = (short)info.typeDevil;
			mainSkill.lvDevil = info.LvDevilSkill;
			result = mainSkill;
		}
		return result;
	}

	// Token: 0x06000BCF RID: 3023 RVA: 0x000E51E8 File Offset: 0x000E33E8
	public static bool isClazz(sbyte type)
	{
		return GameScreen.player.clazz == type || type == 0;
	}

	// Token: 0x06000BD0 RID: 3024 RVA: 0x000E5218 File Offset: 0x000E3418
	public mVector setSkillLan(Skill_Info skill)
	{
		mVector mVector = new mVector();
		bool flag = skill.typeSkill == 2;
		if (flag)
		{
			bool flag2 = skill.typeBuff == 1 || skill.typeBuff == 2 || skill.typeBuff == 2;
			if (flag2)
			{
				Object_Effect_Skill o = new Object_Effect_Skill(this.ID, this.typeObject);
				mVector.addElement(o);
			}
			bool flag3 = GameScreen.objFocus != null && ((skill.typeBuff == 2 && GameScreen.objFocus.typeObject == 0) || skill.typeBuff == 3);
			if (flag3)
			{
				Object_Effect_Skill o2 = new Object_Effect_Skill(GameScreen.objFocus.ID, GameScreen.objFocus.typeObject);
				mVector.addElement(o2);
			}
		}
		else
		{
			Object_Effect_Skill o3 = new Object_Effect_Skill(GameScreen.objFocus.ID, GameScreen.objFocus.typeObject);
			mVector.addElement(o3);
			sbyte typeObject = GameScreen.objFocus.typeObject;
			for (int i = 0; i < GameScreen.vecPlayers.size(); i++)
			{
				bool flag4 = mVector.size() >= (int)skill.nTarget;
				if (flag4)
				{
					break;
				}
				MainObject mainObject = (MainObject)GameScreen.vecPlayers.elementAt(i);
				bool flag5 = mainObject.typeObject == typeObject && mainObject != GameScreen.objFocus && this.setFightPk(mainObject) && MainObject.getDistance(GameScreen.objFocus.x, GameScreen.objFocus.y, mainObject.x, mainObject.y) <= 120;
				if (flag5)
				{
					Object_Effect_Skill o4 = new Object_Effect_Skill(mainObject.ID, typeObject);
					mVector.addElement(o4);
				}
			}
		}
		return mVector;
	}

	// Token: 0x06000BD1 RID: 3025 RVA: 0x000E53D8 File Offset: 0x000E35D8
	public void setAutoFire(bool isAutoNew)
	{
		bool flag = GameCanvas.gameTick % 5 != 0 || GameCanvas.timeNow - this.timeFristSkill <= 1000L || this.skillCurrent != null;
		if (!flag)
		{
			this.setDisAuto();
			bool flag2 = Player.isBack;
			if (flag2)
			{
				this.tickMaxBack++;
				bool flag3 = this.tickMaxBack > 200;
				if (flag3)
				{
					Player.isBack = false;
				}
			}
			else
			{
				this.tickMaxBack = 0;
				MainObject objFocus = GameScreen.objFocus;
				bool flag4 = objFocus != null && objFocus.typeObject == 0 && (this.objAutoFrist == null || this.objAutoFrist.typeObject == 0);
				if (flag4)
				{
					bool flag5 = !this.setFightPk(objFocus);
					if (flag5)
					{
						Player.AutoFireCur = 0;
						return;
					}
				}
				else
				{
					bool flag6 = objFocus == null || objFocus.returnAction() || objFocus.typeObject != 1 || objFocus.isDie || objFocus.Hp <= 0;
					if (flag6)
					{
						this.nextMonster();
						bool flag7 = GameScreen.objFocus != null;
						if (flag7)
						{
							bool flag8 = GameScreen.objFocus.typeObject != 1;
							if (flag8)
							{
								return;
							}
							GameScreen.addEffectEnd_ObjTo(24, 0, GameScreen.objFocus.x, GameScreen.objFocus.y, GameScreen.objFocus.ID, GameScreen.objFocus.typeObject, 0, null);
							Interface_Game.isPaintInfoFocus = true;
						}
					}
					objFocus = GameScreen.objFocus;
					bool flag9 = objFocus == null || objFocus.typeObject != 1;
					if (flag9)
					{
						return;
					}
				}
				int num = Player.hotkeyPlayer[0].Length;
				for (int i = 0; i < num; i++)
				{
					int num2 = (i + Player.IndexFire) % num;
					if (isAutoNew)
					{
						num2 = Player.IndexFire % num;
						Player.IndexFire = 2;
					}
					Hotkey hotkey = Player.hotkeyPlayer[(int)Player.currentTab][num2];
					bool flag10 = hotkey.skill != null && DelaySkill.getDelay((int)hotkey.skill.indexHotKey).isCoolDown();
					if (flag10)
					{
						Skill_Info skillFromID = Skill_Info.getSkillFromID(hotkey.skill.ID);
						bool flag11 = skillFromID.typeSkill != 2 && skillFromID != null && this.getManaNeedUse((int)skillFromID.manaLost) <= this.Mp;
						if (flag11)
						{
							GameScreen.objFocus.setFireObject(num2);
							this.timeFristSkill = GameCanvas.timeNow;
							bool flag12 = !isAutoNew;
							if (flag12)
							{
								Player.IndexFire = num2 + 1;
							}
							break;
						}
					}
					if (isAutoNew)
					{
						break;
					}
				}
			}
		}
	}

	// Token: 0x06000BD2 RID: 3026 RVA: 0x000E567C File Offset: 0x000E387C
	private void setDisAuto()
	{
		bool flag = Player.isBack;
		if (flag)
		{
			bool flag2 = MainObject.getDistance(this.x, this.y, Player.xBeginAuto, Player.yBeginAuto) <= LoadMap.wTile * 2;
			if (flag2)
			{
				Player.isBack = false;
			}
			bool flag3 = this.posTransRoad == null && this.Action == 0;
			if (flag3)
			{
				GameScreen.player.toX = GameScreen.player.x;
				GameScreen.player.toY = GameScreen.player.y;
				this.posTransRoad = GameCanvas.loadmap.updateFindRoad(Player.xBeginAuto / LoadMap.wTile, Player.yBeginAuto / LoadMap.wTile, this.x / LoadMap.wTile, this.y / LoadMap.wTile, 80, this);
				bool flag4 = this.posTransRoad != null && this.posTransRoad.Length > 80;
				if (flag4)
				{
					this.posTransRoad = null;
				}
			}
		}
		else
		{
			bool flag5 = this.objAutoFrist == null || GameScreen.objFocus == null || this.objAutoFrist != GameScreen.objFocus;
			if (flag5)
			{
				Player.distest = MainObject.getDistance(this.x, this.y, Player.xBeginAuto, Player.yBeginAuto);
				bool flag6 = Player.distest > Player.maxRangeAuto + 200;
				if (flag6)
				{
					Player.isBack = true;
				}
				else
				{
					bool flag7 = Player.distest > Player.maxRangeAuto + 100 && (GameScreen.objFocus == null || GameScreen.objFocus.Hp > GameScreen.objFocus.maxHp / 10 || GameScreen.objFocus.isHumanMonster == 0);
					if (flag7)
					{
						Player.isBack = true;
					}
					else
					{
						bool flag8 = Player.distest > Player.maxRangeAuto && (GameScreen.objFocus == null || GameScreen.objFocus.Hp > GameScreen.objFocus.maxHp - GameScreen.objFocus.maxHp / 20 || GameScreen.objFocus.isHumanMonster == 0);
						if (flag8)
						{
							Player.isBack = true;
						}
					}
				}
			}
		}
	}

	// Token: 0x06000BD3 RID: 3027 RVA: 0x000E5898 File Offset: 0x000E3A98
	public static void setStart_EndAutoFire(bool isAu)
	{
		if (isAu)
		{
			bool flag = Player.AutoFireCur != Player.typeAutoFireMain;
			if (flag)
			{
				Player.AutoFireCur = Player.typeAutoFireMain;
				Player.xBeginAuto = GameScreen.player.x;
				Player.yBeginAuto = GameScreen.player.y;
			}
		}
		else
		{
			bool flag2 = Player.AutoFireCur >= 1;
			if (flag2)
			{
				Player.AutoFireCur = 0;
			}
		}
	}

	// Token: 0x06000BD4 RID: 3028 RVA: 0x000E5904 File Offset: 0x000E3B04
	public bool checkEffSpec(short typeEff)
	{
		for (int i = 0; i < this.vecEffspec.size(); i++)
		{
			Effect_Spec effect_Spec = (Effect_Spec)this.vecEffspec.elementAt(i);
			bool flag = effect_Spec.typeEffect == (int)typeEff;
			if (flag)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000BD5 RID: 3029 RVA: 0x000E595C File Offset: 0x000E3B5C
	public bool check_Fire_EffSpec()
	{
		for (int i = 0; i < this.vecEffspec.size(); i++)
		{
			Effect_Spec effect_Spec = (Effect_Spec)this.vecEffspec.elementAt(i);
			bool flag = effect_Spec.typeEffect == 1 || effect_Spec.typeEffect == 5;
			if (flag)
			{
				return true;
			}
		}
		for (int j = 0; j < this.vecDataEff.size(); j++)
		{
			DataSkillEff dataSkillEff = (DataSkillEff)this.vecDataEff.elementAt(j);
			bool flag2 = dataSkillEff != null && dataSkillEff.typeMove == 1;
			if (flag2)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000BD6 RID: 3030 RVA: 0x000E5A10 File Offset: 0x000E3C10
	public bool check_Move_EffSpec()
	{
		for (int i = 0; i < this.vecEffspec.size(); i++)
		{
			Effect_Spec effect_Spec = (Effect_Spec)this.vecEffspec.elementAt(i);
			bool flag = effect_Spec.typeEffect == 1 || effect_Spec.typeEffect == 8;
			if (flag)
			{
				return true;
			}
		}
		for (int j = 0; j < this.vecDataEff.size(); j++)
		{
			DataSkillEff dataSkillEff = (DataSkillEff)this.vecDataEff.elementAt(j);
			bool flag2 = dataSkillEff != null && dataSkillEff.typeMove == 1;
			if (flag2)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000BD7 RID: 3031 RVA: 0x000E5AC4 File Offset: 0x000E3CC4
	public void updateMoney()
	{
		bool flag = Player.beliTest > this.beli;
		if (flag)
		{
			Interface_Game.tickeffShowMoney = 60;
			Interface_Game.typeShowMoney = 0;
			bool flag2 = Player.valueTestBeli == 0L;
			if (flag2)
			{
				Player.timeTestBeli = 0L;
				Player.valueTestBeli = (Player.beliTest - this.beli) / 10L;
				bool flag3 = Player.valueTestBeli < 100L;
				if (flag3)
				{
					Player.valueTestBeli = 100L;
				}
			}
			else
			{
				Player.beliTest -= Player.valueTestBeli;
				bool flag4 = Player.beliTest <= this.beli;
				if (flag4)
				{
					Player.beliTest = this.beli;
					Player.valueTestBeli = 0L;
					Player.timeTestBeli = 0L;
				}
			}
		}
		else
		{
			Player.beliTest = this.beli;
			Player.valueTestBeli = 0L;
			Player.timeTestBeli = 0L;
		}
	}

	// Token: 0x06000BD8 RID: 3032 RVA: 0x000E5B98 File Offset: 0x000E3D98
	public override void setPosUpBoat()
	{
		this.toX = this.x;
		this.toY = this.y;
		bool flag = this.typeActionBoat == 1;
		if (flag)
		{
			int num = this.xUpBoat - 24;
			int num2 = this.yUpBoat + 24;
			this.posTransRoad = GameCanvas.loadmap.updateFindRoad(num / LoadMap.wTile, num2 / LoadMap.wTile, this.x / LoadMap.wTile, this.y / LoadMap.wTile, 20, this);
			bool flag2 = this.posTransRoad == null || this.posTransRoad.Length > 20;
			if (flag2)
			{
				num = this.xUpBoat + 24;
				num2 = this.yUpBoat + 24;
				this.posTransRoad = GameCanvas.loadmap.updateFindRoad(num / LoadMap.wTile, num2 / LoadMap.wTile, this.x / LoadMap.wTile, this.y / LoadMap.wTile, 20, this);
			}
			bool flag3 = this.posTransRoad == null || this.posTransRoad.Length > 20;
			if (flag3)
			{
				this.posTransRoad = null;
				this.x = this.xUpBoat - 24;
				this.y = this.yUpBoat + 24;
			}
		}
		else
		{
			bool flag4 = this.typeActionBoat == 3;
			if (flag4)
			{
				int num3 = this.xUpBoat - 24;
				int num4 = this.yUpBoat - 48;
				this.posTransRoad = GameCanvas.loadmap.updateFindRoad(num3 / LoadMap.wTile, num4 / LoadMap.wTile, this.x / LoadMap.wTile, this.y / LoadMap.wTile, 20, this);
				bool flag5 = this.posTransRoad == null || this.posTransRoad.Length > 20;
				if (flag5)
				{
					num3 = this.xUpBoat + 24;
					num4 = this.yUpBoat - 48;
					this.posTransRoad = GameCanvas.loadmap.updateFindRoad(num3 / LoadMap.wTile, num4 / LoadMap.wTile, this.x / LoadMap.wTile, this.y / LoadMap.wTile, 20, this);
				}
				bool flag6 = this.posTransRoad == null || this.posTransRoad.Length > 20;
				if (flag6)
				{
					this.posTransRoad = null;
					this.x = this.xUpBoat - 24;
					this.y = this.yUpBoat - 48;
				}
			}
		}
	}

	// Token: 0x06000BD9 RID: 3033 RVA: 0x000E5DEC File Offset: 0x000E3FEC
	public override void setPosDownBoat()
	{
		this.toX = this.x;
		this.toY = this.y;
		int xUpBoat = this.xUpBoat;
		int yUpBoat = this.yUpBoat;
		this.posTransRoad = GameCanvas.loadmap.updateFindRoad(xUpBoat / LoadMap.wTile, yUpBoat / LoadMap.wTile, this.x / LoadMap.wTile, this.y / LoadMap.wTile, 20, this);
		GameScreen.player.countAutoMove = 1;
		bool flag = this.posTransRoad == null || this.posTransRoad.Length > 20;
		if (flag)
		{
			this.posTransRoad = null;
			this.x = this.xUpBoat;
			this.y = this.yUpBoat;
		}
	}

	// Token: 0x06000BDA RID: 3034 RVA: 0x000E5EA0 File Offset: 0x000E40A0
	public override void setNextSea()
	{
		bool isNondata = ReadMessenge.isNondata;
		if (isNondata)
		{
			GameCanvas.readMess.readChangeMapNonData(GameCanvas.readMess.msgLuu, GameCanvas.readMess.idMapLuu);
		}
		else
		{
			GameCanvas.readMess.readChangeMapNew(GameCanvas.readMess.msgLuu, GameCanvas.readMess.idMapLuu);
		}
		this.tickJoinSea = 0;
	}

	// Token: 0x06000BDB RID: 3035 RVA: 0x000E5F04 File Offset: 0x000E4104
	public override void setXtoYto(int xto, int yto)
	{
		this.toX = this.x;
		this.toY = this.y;
		this.posTransRoad = GameCanvas.loadmap.updateFindRoad(xto / LoadMap.wTile, yto / LoadMap.wTile, this.x / LoadMap.wTile, this.y / LoadMap.wTile, 30, this);
		GameScreen.player.countAutoMove = 1;
	}

	// Token: 0x06000BDC RID: 3036 RVA: 0x000E5F70 File Offset: 0x000E4170
	public static void SetMaterialToChest(sbyte type)
	{
		for (int i = 0; i < Player.vecInventory.size(); i++)
		{
			MainItem mainItem = (MainItem)Player.vecInventory.elementAt(i);
			bool flag = mainItem.typeObject == type;
			if (flag)
			{
				mSystem.outz("vo 5");
				GlobalService.gI().Chest(1, mainItem.ID, mainItem.typeObject, (int)mainItem.numPotion);
			}
		}
	}

	// Token: 0x06000BDD RID: 3037 RVA: 0x000E5FE4 File Offset: 0x000E41E4
	public static void SetMaterialToInven(sbyte type)
	{
		for (int i = 0; i < Player.vecChest.size(); i++)
		{
			MainItem mainItem = (MainItem)Player.vecChest.elementAt(i);
			bool flag = mainItem.typeObject == type;
			if (flag)
			{
				mSystem.outz("vo 6");
				GlobalService.gI().Chest(2, mainItem.ID, mainItem.typeObject, (int)mainItem.numPotion);
			}
		}
	}

	// Token: 0x06000BDE RID: 3038 RVA: 0x000E6058 File Offset: 0x000E4258
	public static void SetDiamondToChest()
	{
		for (int i = 0; i < Player.vecInventory.size(); i++)
		{
			MainItem mainItem = (MainItem)Player.vecInventory.elementAt(i);
			bool flag = mainItem.typeObject == 4 && ((mainItem.ID >= 44 && mainItem.ID <= 79) || (mainItem.ID >= 362 && mainItem.ID <= 367));
			if (flag)
			{
				mSystem.outz("vo 3");
				GlobalService.gI().Chest(1, mainItem.ID, mainItem.typeObject, (int)mainItem.numPotion);
			}
		}
	}

	// Token: 0x06000BDF RID: 3039 RVA: 0x000E610C File Offset: 0x000E430C
	public static void SetDiamondToInven()
	{
		for (int i = 0; i < Player.vecChest.size(); i++)
		{
			MainItem mainItem = (MainItem)Player.vecChest.elementAt(i);
			bool flag = mainItem.typeObject == 4 && ((mainItem.ID >= 44 && mainItem.ID <= 79) || (mainItem.ID >= 362 && mainItem.ID <= 367));
			if (flag)
			{
				mSystem.outz("vo 4");
				GlobalService.gI().Chest(2, mainItem.ID, mainItem.typeObject, (int)mainItem.numPotion);
			}
		}
	}

	// Token: 0x06000BE0 RID: 3040 RVA: 0x0000B958 File Offset: 0x00009B58
	public override void resetAction()
	{
		this.mindexkey = new int[]
		{
			-1,
			-1,
			-1,
			-1
		};
		base.resetAction();
	}

	// Token: 0x06000BE1 RID: 3041 RVA: 0x000E61C0 File Offset: 0x000E43C0
	public override void actionStand()
	{
		bool flag = this.tickAfterSkill > 0;
		if (flag)
		{
			this.tickAfterSkill--;
		}
		bool flag2 = this.f > this.feStand.Length - 1;
		if (flag2)
		{
			this.f = 0;
		}
		bool flag3 = Player.isGhost;
		if (flag3)
		{
			this.f = 0;
		}
		this.frame = this.feStand[this.f];
	}

	// Token: 0x06000BE2 RID: 3042 RVA: 0x000E6230 File Offset: 0x000E4430
	public static void SetGiamCountDown()
	{
		bool flag = Player.vecParty.size() == 0;
		if (flag)
		{
			Player.giamCountDownParty = 0;
		}
		Player.GiamCountDownCur = Player.giamCountDownParty + Player.giamCountDownAtt;
	}

	// Token: 0x06000BE3 RID: 3043 RVA: 0x000E6268 File Offset: 0x000E4468
	public override void updateTimeSafe()
	{
		bool flag = this.timeSafe > 0;
		if (flag)
		{
			int num = (int)(GameCanvas.timeNow - this.timeBeginSafe);
			bool flag2 = num > 1000;
			if (flag2)
			{
				this.timeSafe--;
				this.timeBeginSafe += 1000L;
			}
		}
	}

	// Token: 0x06000BE4 RID: 3044 RVA: 0x000E62C4 File Offset: 0x000E44C4
	public override void addEffBuff(sbyte typeBuff, short effBuff, short time)
	{
		bool flag = this.skillCurrent != null;
		if (flag)
		{
			this.skillCurrent.beginSkill();
		}
		mVector mVector = new mVector();
		Object_Effect_Skill object_Effect_Skill = new Object_Effect_Skill(this.ID, this.typeObject);
		object_Effect_Skill.setHP(0, this.Hp, 0);
		mVector.addElement(object_Effect_Skill);
		MainSkill mainSkill = new MainSkill(-1, effBuff);
		mainSkill.setTypeBuff(typeBuff, effBuff, time);
		this.setDataBeginSkill(mainSkill, mVector);
	}

	// Token: 0x06000BE5 RID: 3045 RVA: 0x000E6338 File Offset: 0x000E4538
	public void StepAutoReconnect()
	{
		bool flag = Player.StepAutoRe == 0;
		if (flag)
		{
			Player.tickAutoRe = 0;
			bool flag2 = GameCanvas.loadmap.mapLang();
			if (flag2)
			{
				Player.StepAutoRe = 4;
			}
			else
			{
				bool flag3 = Player.xBeginAuto != 0 && Player.yBeginAuto != 0;
				if (flag3)
				{
					Player.StepAutoRe = 1;
				}
				else
				{
					Player.StepAutoRe = 4;
				}
			}
		}
		else
		{
			bool flag4 = Player.StepAutoRe == 1;
			if (flag4)
			{
				GameScreen.player.toX = GameScreen.player.x;
				GameScreen.player.toY = GameScreen.player.y;
				this.posTransRoad = GameCanvas.loadmap.updateFindRoad(Player.xBeginAuto / LoadMap.wTile, Player.yBeginAuto / LoadMap.wTile, this.x / LoadMap.wTile, this.y / LoadMap.wTile, 200, this);
				Player.StepAutoRe = 2;
			}
			else
			{
				bool flag5 = Player.StepAutoRe == 2;
				if (flag5)
				{
					bool flag6 = this.posTransRoad == null;
					if (flag6)
					{
						this.nextMonster();
						Player.setStart_EndAutoFire(true);
						Player.StepAutoRe = 5;
						Player.strHethong = Player.strHethong + T.chathethong + GameCanvas.getTextTime() + "\n";
						GameCanvas.chatTabScr.addNewChat(T.hethong, string.Empty, Player.strHethong, 1, false);
					}
				}
				else
				{
					bool flag7 = Player.StepAutoRe != 5;
					if (!flag7)
					{
						Player.tickAutoRe++;
						bool flag8 = Player.tickAutoRe % 200 != 0;
						if (!flag8)
						{
							bool flag9 = Player.AutoFireCur != Player.typeAutoFireMain;
							if (flag9)
							{
								int num = 0;
								do
								{
									num++;
									this.nextMonster();
								}
								while (num != 10 && (GameScreen.objFocus == null || GameScreen.objFocus.typeObject != 1));
								Player.setStart_EndAutoFire(true);
								Player.tickAutoRe = 0;
							}
							else
							{
								Player.StepAutoRe = 4;
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x06000BE6 RID: 3046 RVA: 0x000E6540 File Offset: 0x000E4740
	public override void AddBuff(MainBuff buff)
	{
		for (int i = 0; i < this.vecBuffCur.size(); i++)
		{
			MainBuff mainBuff = (MainBuff)this.vecBuffCur.elementAt(i);
			bool flag = mainBuff.IdBuff == buff.IdBuff;
			if (flag)
			{
				this.vecBuffCur.removeElementAt(i);
				this.CheckBuffinEffCur(buff.IdBuff);
				i--;
			}
		}
		buff.setYlech(this);
		this.vecBuffCur.addElement(buff);
		Item_Skill_Eff item_Skill_Eff = new Item_Skill_Eff(buff.idIcon, buff.IdBuff, 1000);
		GameScreen.interfaceGame.addEffCurrent(item_Skill_Eff);
		Player.setDelaySkill((int)item_Skill_Eff.indexHotKey, buff.timeBuff, true, 0);
	}

	// Token: 0x06000BE7 RID: 3047 RVA: 0x000E65FC File Offset: 0x000E47FC
	public void CheckBuffinEffCur(short idbuff)
	{
		for (int i = 0; i < Interface_Game.vecEffCurrent.size(); i++)
		{
			MainItem mainItem = (MainItem)Interface_Game.vecEffCurrent.elementAt(i);
			bool flag = mainItem.typeObject == 9 && mainItem.ID == idbuff;
			if (flag)
			{
				mainItem.isRemove = true;
			}
		}
	}

	// Token: 0x06000BE8 RID: 3048 RVA: 0x000E665C File Offset: 0x000E485C
	public void TestSkill(short typeEffSkill)
	{
		Hotkey hotkey = Player.hotkeyPlayer[0][2];
		Skill_Info skillFromID = Skill_Info.getSkillFromID(hotkey.skill.ID);
		skillFromID.typeEffSkill = typeEffSkill;
		this.beginPlayerFire(skillFromID);
	}

	// Token: 0x0400123C RID: 4668
	public const int HARDCODE_INDEXPOTION = 500;

	// Token: 0x0400123D RID: 4669
	public const int HARDCODE_INDEXPASSIVE = 1000;

	// Token: 0x0400123E RID: 4670
	public const int HARDCODE_INDEX_EFF_SPEC = 1500;

	// Token: 0x0400123F RID: 4671
	public const sbyte RED_LINE_FREE = 0;

	// Token: 0x04001240 RID: 4672
	public const sbyte RED_LINE_DIE = 1;

	// Token: 0x04001241 RID: 4673
	public const sbyte RED_LINE_FINISH = 2;

	// Token: 0x04001242 RID: 4674
	public const sbyte GOTO_SKY_BEGIN = 0;

	// Token: 0x04001243 RID: 4675
	public const sbyte GOTO_CAPCHAR = 1;

	// Token: 0x04001244 RID: 4676
	public const sbyte GOTO_DIE = 2;

	// Token: 0x04001245 RID: 4677
	public const sbyte GOTO_FINISH = 3;

	// Token: 0x04001246 RID: 4678
	public const sbyte AUTO_RE_CHECK_MAP_LANG = 0;

	// Token: 0x04001247 RID: 4679
	public const sbyte AUTO_RE_SET_MOVE_CHECK_POINT = 1;

	// Token: 0x04001248 RID: 4680
	public const sbyte AUTO_RE_MOVE_TO_CHECK_POINT = 2;

	// Token: 0x04001249 RID: 4681
	public const sbyte AUTO_RE_DISCONECT = 3;

	// Token: 0x0400124A RID: 4682
	public const sbyte AUTO_RE_WAIT = 4;

	// Token: 0x0400124B RID: 4683
	public const sbyte AUTO_RE_CHECK_AUTO_OK = 5;

	// Token: 0x0400124C RID: 4684
	public const sbyte AUTO_RE_DONOT_AUTO = 6;

	// Token: 0x0400124D RID: 4685
	public static bool isSendMove = true;

	// Token: 0x0400124E RID: 4686
	public static bool isGhost = false;

	// Token: 0x0400124F RID: 4687
	public static sbyte AutoFireCur = 0;

	// Token: 0x04001250 RID: 4688
	public static sbyte currentTab = 0;

	// Token: 0x04001251 RID: 4689
	public static sbyte typeAutoBuff = 0;

	// Token: 0x04001252 RID: 4690
	public static sbyte typeAutoFireMain = 1;

	// Token: 0x04001253 RID: 4691
	public static sbyte AutoRevice = 0;

	// Token: 0x04001254 RID: 4692
	public static sbyte isGetDataClan = -1;

	// Token: 0x04001255 RID: 4693
	public int demUnFire;

	// Token: 0x04001256 RID: 4694
	public static int wFocus = 140;

	// Token: 0x04001257 RID: 4695
	public static int LvMinPk;

	// Token: 0x04001258 RID: 4696
	public static int pointSkill;

	// Token: 0x04001259 RID: 4697
	public static int pointAttribute = 10;

	// Token: 0x0400125A RID: 4698
	public static int pointMaxLevelAttri = 0;

	// Token: 0x0400125B RID: 4699
	public long timeLastSkill;

	// Token: 0x0400125C RID: 4700
	public static mVector vecInventory = new mVector("Player.vecInventory");

	// Token: 0x0400125D RID: 4701
	public static mVector vecChest = new mVector("Player.vecChest");

	// Token: 0x0400125E RID: 4702
	public static mVector vecInvenClan = new mVector("Player.vecInvenClan");

	// Token: 0x0400125F RID: 4703
	public static mVector vecMaxLevelAttri = new mVector("Player.vecMaxLevelAttri");

	// Token: 0x04001260 RID: 4704
	public static short[] mSatnhan = new short[5];

	// Token: 0x04001261 RID: 4705
	public static short[] msattam;

	// Token: 0x04001262 RID: 4706
	public static sbyte[] mLvSkill = new sbyte[4];

	// Token: 0x04001263 RID: 4707
	public static sbyte[] mLvSkillPlus = new sbyte[4];

	// Token: 0x04001264 RID: 4708
	public static Hotkey[][] hotkeyPlayer;

	// Token: 0x04001265 RID: 4709
	public static Hotkey[] hotkeyBuffPlayer;

	// Token: 0x04001266 RID: 4710
	public static MyHashTable delaySkill = new MyHashTable();

	// Token: 0x04001267 RID: 4711
	public static Main_Attribute[] mAttribute = new Main_Attribute[5];

	// Token: 0x04001268 RID: 4712
	public static short[] mComboSkill;

	// Token: 0x04001269 RID: 4713
	public static mVector vecListSkill = new mVector("Player.vecListSkill");

	// Token: 0x0400126A RID: 4714
	public static mVector vecQuest = new mVector("Player.vecQuest");

	// Token: 0x0400126B RID: 4715
	public static mVector vecGhostInput = new mVector("Player.vecGhostInput");

	// Token: 0x0400126C RID: 4716
	public static mVector vecUniform = new mVector("Player.vecUniform");

	// Token: 0x0400126D RID: 4717
	public static sbyte indexGhostServer = 0;

	// Token: 0x0400126E RID: 4718
	public static sbyte numPassive = 0;

	// Token: 0x0400126F RID: 4719
	public static sbyte ChucInCLan = 10;

	// Token: 0x04001270 RID: 4720
	public static sbyte ChucInSudo = 0;

	// Token: 0x04001271 RID: 4721
	public static sbyte isAutoMaterial;

	// Token: 0x04001272 RID: 4722
	public static string strTimeChange = string.Empty;

	// Token: 0x04001273 RID: 4723
	public static string strHethong = string.Empty;

	// Token: 0x04001274 RID: 4724
	public static bool isSkillready = false;

	// Token: 0x04001275 RID: 4725
	public static bool isAFK = false;

	// Token: 0x04001276 RID: 4726
	public static short idNPCQuestCur = 0;

	// Token: 0x04001277 RID: 4727
	public static short idFashion = -1;

	// Token: 0x04001278 RID: 4728
	public static MainQuest questMainNew = null;

	// Token: 0x04001279 RID: 4729
	public static Item[] mChestWanted = new Item[2];

	// Token: 0x0400127A RID: 4730
	public static int indexPosMapTrain = 0;

	// Token: 0x0400127B RID: 4731
	public static int maxInventory = 40;

	// Token: 0x0400127C RID: 4732
	public static int maxChest = 10;

	// Token: 0x0400127D RID: 4733
	public static int indexCombo = -1;

	// Token: 0x0400127E RID: 4734
	public static int indexAudition = -1;

	// Token: 0x0400127F RID: 4735
	public static int Chestgem = 0;

	// Token: 0x04001280 RID: 4736
	public static long Chestbeli = 0L;

	// Token: 0x04001281 RID: 4737
	public static short ticket = 0;

	// Token: 0x04001282 RID: 4738
	public static short keyBoss = 0;

	// Token: 0x04001283 RID: 4739
	public static short PvPticket = 0;

	// Token: 0x04001284 RID: 4740
	public static short maxTicket = 0;

	// Token: 0x04001285 RID: 4741
	public static short maxKeyboss = 0;

	// Token: 0x04001286 RID: 4742
	public static short maxPvPticket = 0;

	// Token: 0x04001287 RID: 4743
	public static MainQuest curQuest = null;

	// Token: 0x04001288 RID: 4744
	public static mVector vecParty = new mVector("Player.vecParty");

	// Token: 0x04001289 RID: 4745
	public static mVector vecFriendList = new mVector("Player.vecFriendList");

	// Token: 0x0400128A RID: 4746
	public static mVector vecEvent = new mVector("Player.vecEvent");

	// Token: 0x0400128B RID: 4747
	public static bool isFocusNPC;

	// Token: 0x0400128C RID: 4748
	public static int timeFocusNPC;

	// Token: 0x0400128D RID: 4749
	public static int[][] hardCodeShortInfo = new int[][]
	{
		new int[]
		{
			0,
			2,
			3,
			4,
			10,
			11,
			14
		},
		new int[7]
	};

	// Token: 0x0400128E RID: 4750
	public static string[] InfoShortEquip = new string[]
	{
		string.Empty,
		string.Empty,
		string.Empty,
		string.Empty,
		string.Empty,
		string.Empty
	};

	// Token: 0x0400128F RID: 4751
	public static bool isMPHP = true;

	// Token: 0x04001290 RID: 4752
	public static bool isGetItem = true;

	// Token: 0x04001291 RID: 4753
	public static int xBeginAuto;

	// Token: 0x04001292 RID: 4754
	public static int yBeginAuto;

	// Token: 0x04001293 RID: 4755
	public static bool isBack = false;

	// Token: 0x04001294 RID: 4756
	public static int maxRangeAuto = 200;

	// Token: 0x04001295 RID: 4757
	public static short giamCountDownAtt = 0;

	// Token: 0x04001296 RID: 4758
	public static short giamCountDownParty = 0;

	// Token: 0x04001297 RID: 4759
	public static short GiamCountDownCur = 0;

	// Token: 0x04001298 RID: 4760
	public static short tickAutoRevice = 100;

	// Token: 0x04001299 RID: 4761
	public static short TangManaUseSkill = 0;

	// Token: 0x0400129A RID: 4762
	public int tickNauBanh;

	// Token: 0x0400129B RID: 4763
	public bool isNauBanh;

	// Token: 0x0400129C RID: 4764
	public static Boat boatKeyParty = null;

	// Token: 0x0400129D RID: 4765
	public static int[] mframeghost = new int[]
	{
		0,
		0,
		1,
		1,
		2,
		2,
		2,
		2,
		1,
		1
	};

	// Token: 0x0400129E RID: 4766
	public int lineShowRedLineNext = 2;

	// Token: 0x0400129F RID: 4767
	public int lineShowRedLineCur = 2;

	// Token: 0x040012A0 RID: 4768
	public int tickmove;

	// Token: 0x040012A1 RID: 4769
	public int tickChangeLine;

	// Token: 0x040012A2 RID: 4770
	public int tickFinish;

	// Token: 0x040012A3 RID: 4771
	public int typeMoveMapRedLine;

	// Token: 0x040012A4 RID: 4772
	public static bool isChangeLine = false;

	// Token: 0x040012A5 RID: 4773
	public static int isShowDie = 0;

	// Token: 0x040012A6 RID: 4774
	public int typeMoveGotoSky;

	// Token: 0x040012A7 RID: 4775
	public MainItem hpPoi;

	// Token: 0x040012A8 RID: 4776
	public MainItem mpPoi;

	// Token: 0x040012A9 RID: 4777
	private int tickdemHP;

	// Token: 0x040012AA RID: 4778
	private int tickdemMp;

	// Token: 0x040012AB RID: 4779
	public static bool isFullInven = false;

	// Token: 0x040012AC RID: 4780
	public bool isBeginTrain;

	// Token: 0x040012AD RID: 4781
	private int indexkey;

	// Token: 0x040012AE RID: 4782
	private int[] mindexkey = new int[]
	{
		-1,
		-1,
		-1,
		-1
	};

	// Token: 0x040012AF RID: 4783
	private int indexFocus;

	// Token: 0x040012B0 RID: 4784
	private long timeFristSkill;

	// Token: 0x040012B1 RID: 4785
	public static int IndexFire = 0;

	// Token: 0x040012B2 RID: 4786
	private MainObject objAutoFrist;

	// Token: 0x040012B3 RID: 4787
	public int tickMaxBack;

	// Token: 0x040012B4 RID: 4788
	public static int distest = 0;

	// Token: 0x040012B5 RID: 4789
	public static long beliTest;

	// Token: 0x040012B6 RID: 4790
	public static long valueTestBeli;

	// Token: 0x040012B7 RID: 4791
	public static long timeTestBeli;

	// Token: 0x040012B8 RID: 4792
	public static bool isUpdateMonney = false;

	// Token: 0x040012B9 RID: 4793
	public static sbyte StepAutoRe = 0;

	// Token: 0x040012BA RID: 4794
	public static int tickAutoRe = 0;
}
