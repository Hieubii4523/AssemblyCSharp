using System;

// Token: 0x0200006E RID: 110
public class LoadMapScreen : MainScreen
{
	// Token: 0x060006A9 RID: 1705 RVA: 0x000923CC File Offset: 0x000905CC
	public override void Show()
	{
		LoadMapScreen.countLoadMap += 1;
		LoadMapScreen.isNextMap = false;
		GameCanvas.menuCur.isShowMenu = false;
		LoadMapScreen.isPaintBack = true;
		GameScreen.isShowNameSUPER_BOSS = true;
		GameScreen.isShowNameXpArena = false;
		GameScreen.isShowNameWW = false;
		GameScreen.checkRemoveImage(1, LoadMapScreen.countLoadMap % 2 == 1);
		base.Show();
		bool lowGraphic = GameCanvas.lowGraphic;
		if (lowGraphic)
		{
			AvMain.imgLg = null;
		}
		this.time = GameCanvas.timeNow;
		bool isPaintInfoFocus = Interface_Game.isPaintInfoFocus;
		if (isPaintInfoFocus)
		{
			Interface_Game.isPaintInfoFocus = false;
		}
		GameCanvas.saveImage.start();
		GameScreen.VecEffect.removeAllElements();
		GameScreen.VecNum.removeAllElements();
		GameScreen.vecObjMove.removeAllElements();
		GameScreen.isPvPNew = false;
		GameScreen.objPvPNew = null;
		Interface_Game.typeTitleRoomFight = 0;
		Interface_Game.vecClanDam.removeAllElements();
		this.tick = 0;
		this.tickPaintMap = 0;
		GameCanvas.mapBack = null;
		GameScreen.ClanDao = null;
		bool flag = !GameCanvas.isLowGraOrWP_PvP() && GameMidlet.DEVICE != 0 && GameMidlet.DEVICE != 4;
		if (flag)
		{
			bool flag2 = GameCanvas.mapLogin == null;
			if (flag2)
			{
				GameCanvas.mapLogin = new MapBackGround();
			}
			GameCanvas.mapLogin.setBGLoading();
		}
		GameScreen.vecBigBossLittleGraden.removeAllElements();
		bool flag3 = GameCanvas.loadmap.mapLang();
		if (flag3)
		{
			Interface_Game.mImgPvPType = null;
			MapOff_RedLine.mImgMapOffline = null;
			AvMain.imgTimePvpSmall = null;
			AvMain.imgTimePvp = null;
		}
		bool flag4 = GameCanvas.loadmap.idMap >= 988 && GameCanvas.loadmap.idMap <= 995;
		if (flag4)
		{
			Interface_Game.indexPaintTable = 1;
		}
		else
		{
			bool flag5 = GameCanvas.loadmap.idMap == 999 || GameCanvas.loadmap.idMap == 997 || GameCanvas.loadmap.idMap == 1000 || GameCanvas.loadmap.idMap == 1001;
			if (flag5)
			{
				Interface_Game.indexPaintTable = 0;
			}
		}
		GameScreen.checkRemoveImage(2, LoadMapScreen.countLoadMap % 2 == 0);
		this.checkDelInstance();
		MapGotoSky.isBeginEffBoat = false;
		LoadMapScreen.isSuperBoss = false;
	}

	// Token: 0x060006AA RID: 1706 RVA: 0x0000A7D9 File Offset: 0x000089D9
	private void checkDelInstance()
	{
		ListDungeon.instance = null;
		CreateChar_Screen.instance = null;
		PartyScreen.instance = null;
		PlayerListServer.instance = null;
		PvPScreen.instance = null;
		ScreenUpgrade.instance = null;
		SplitScreen.instance = null;
		TradeScreen.instance = null;
		ScreenJoinItem.instance = null;
	}

	// Token: 0x060006AB RID: 1707 RVA: 0x000092E5 File Offset: 0x000074E5
	public override void setxyPlus12()
	{
		GameCanvas.xPlus12 = 2;
		GameCanvas.yPlus12 = 2;
	}

	// Token: 0x060006AC RID: 1708 RVA: 0x000925E4 File Offset: 0x000907E4
	public override void paint(mGraphics g)
	{
		try
		{
			GameCanvas.resetTrans(g);
			g.setColor(0);
			g.fillRect(0, 0, MotherCanvas.w, MotherCanvas.h);
			bool flag = GameCanvas.mapLogin != null && LoadMapScreen.isPaintBack && !GameCanvas.isLowGraOrWP_PvP() && GameMidlet.DEVICE != 0 && GameMidlet.DEVICE != 4;
			if (flag)
			{
				GameCanvas.mapLogin.paintBgLoading(g);
				GameCanvas.mapLogin.paintObjLoading(g);
			}
			bool flag2 = !GameCanvas.lowGraphic;
			if (flag2)
			{
				LoginScreen.paintLogo(g, MotherCanvas.hw);
			}
			bool flag3 = !GameCanvas.lowGraphic;
			if (flag3)
			{
				AvMain.fraBtBanhlai.drawFrame(LoginScreen.frameBanhlai, MotherCanvas.w - 30, MotherCanvas.h - 30, 0, 3, g);
			}
			else
			{
				MsgDialog.fraImgWaiting.drawFrame(GameCanvas.gameTick % MsgDialog.fraImgWaiting.nFrame, MotherCanvas.w - MsgDialog.fraImgWaiting.frameWidth, MotherCanvas.h - MsgDialog.fraImgWaiting.frameHeight, 0, 3, g);
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x060006AD RID: 1709 RVA: 0x00092704 File Offset: 0x00090904
	public override void update()
	{
		try
		{
			LoginScreen.updateYPaintLogo(LoginScreen.hLogo);
			LoginScreen.updateBanhLai();
			this.tick++;
			bool flag = GameCanvas.mapLogin != null && LoadMapScreen.isPaintBack && !GameCanvas.isLowGraOrWP_PvP() && GameMidlet.DEVICE != 0 && GameMidlet.DEVICE != 4;
			if (flag)
			{
				GameCanvas.mapLogin.updateCloudLogin();
				GameCanvas.mapLogin.updateBoat();
			}
			bool flag2 = !LoadMapScreen.isNextMap || !LoadMapScreen.isLoadDataMon || (SaveImageRMS.vecSaveImage.size() > 20 && (GameCanvas.timeNow - this.time) / 1000L <= 15L);
			if (!flag2)
			{
				GameScreen.checkRemoveImage(3, LoadMapScreen.countLoadMap % 2 == 1);
				bool flag3 = LoadMapScreen.isPaintBack;
				if (flag3)
				{
					this.tickPaintMap++;
					bool flag4 = this.tickPaintMap > 10;
					if (flag4)
					{
						LoadMapScreen.isPaintBack = false;
						this.tickPaintMap = 0;
					}
				}
				else
				{
					for (int i = 0; i < GameScreen.vecPlayers.size(); i++)
					{
						MainObject mainObject = (MainObject)GameScreen.vecPlayers.elementAt(i);
						bool flag5 = mainObject == null || mainObject.isRemove;
						if (flag5)
						{
							GameScreen.vecPlayers.removeElement(mainObject);
							i--;
						}
					}
					bool flag6 = this.mItemMap != null;
					if (flag6)
					{
						GameCanvas.loadmap.load_ItemMap(this.mItemMap);
					}
					GameScreen.player.posTransRoad = null;
					GameScreen.player.skillCurrent = null;
					GameScreen.player.plashNow = null;
					GameScreen.player.Action = 0;
					GameScreen.player.resetAction();
					GameScreen.player.typeActionBoat = 0;
					GameScreen.player.toX = GameScreen.player.x;
					GameScreen.player.toY = GameScreen.player.y;
					GameScreen.checkRemoveImage(4, LoadMapScreen.countLoadMap % 2 == 0);
					bool isPet = GameScreen.player.isPet;
					if (isPet)
					{
						MainObject pet = MainObject.getPet(GameScreen.player.ID);
						if (pet != null)
						{
							pet.setXYPet(GameScreen.player.x, GameScreen.player.y);
						}
					}
					Interface_Game.HPMap = -1;
					Interface_Game.maxHPMap = -1;
					Interface_Game.watchMap.timeCountDown = 0;
					Interface_Game.watchMap.valueLeft = 0;
					Interface_Game.watchMap.valueright = 0;
					Interface_Game.watchRevice.timeCountDown = 0;
					Player.setStart_EndAutoFire(false);
					bool flag7 = LoadMap.specMap == 3;
					if (flag7)
					{
						Player.indexPosMapTrain = CRes.random(MainObject.mPosMapTrain.Length);
						GameScreen.player.posTransRoad = GameCanvas.loadmap.updateFindRoad(MainObject.mPosMapTrain[Player.indexPosMapTrain][0], MainObject.mPosMapTrain[Player.indexPosMapTrain][1], GameScreen.player.x / LoadMap.wTile, GameScreen.player.y / LoadMap.wTile, 200, GameScreen.player);
					}
					bool flag8 = LoadMap.specMap == 4;
					if (flag8)
					{
						this.goToMapSea();
					}
					else
					{
						bool flag9 = GameScreen.typeViewPlayer == 0 && LoadMap.isOnlineMap && this.checkMapDontshow();
						if (flag9)
						{
							bool flag10 = LoadMapScreen.typeChangeMap == 2;
							if (flag10)
							{
								bool flag11 = GameScreen.player.x < 100 || GameScreen.player.x > GameCanvas.loadmap.maxWMap - 100;
								if (flag11)
								{
									int num = GameScreen.player.x / 24 * 24;
									bool flag12 = GameScreen.player.x < 100;
									if (flag12)
									{
										GameScreen.player.x = 0;
									}
									else
									{
										GameScreen.player.x = GameCanvas.loadmap.maxWMap - LoadMap.wTile;
									}
									GameScreen.player.toX = GameScreen.player.x;
									GameScreen.player.toY = GameScreen.player.y;
									GameScreen.player.posTransRoad = GameCanvas.loadmap.updateFindRoad(num / LoadMap.wTile, GameScreen.player.y / LoadMap.wTile, GameScreen.player.x / LoadMap.wTile, GameScreen.player.y / LoadMap.wTile, 20, GameScreen.player);
									GameScreen.player.countAutoMove = 1;
									Player.isSendMove = false;
									bool flag13 = GameScreen.player.posTransRoad == null || GameScreen.player.posTransRoad.Length > 20;
									if (flag13)
									{
										GameScreen.player.x = num;
										Player.isSendMove = true;
									}
								}
							}
							else
							{
								bool flag14 = LoadMapScreen.typeChangeMap == 1;
								if (flag14)
								{
									GameScreen.addEffectEnd_ObjTo(32, 0, GameScreen.player.x, GameScreen.player.y, GameScreen.player.ID, GameScreen.player.typeObject, (sbyte)GameScreen.player.type_left_right, GameScreen.player);
								}
							}
						}
					}
					Player.isSendMove = false;
					bool flag15 = GameCanvas.mapBack == null;
					if (flag15)
					{
						GameCanvas.mapBack = new MapBackGround();
					}
					GameCanvas.mapBack.setBackGround(LoadMapScreen.IDBack, LoadMapScreen.HBack);
					bool flag16 = GameScreen.effMap != null && GameScreen.effMap.type == 1 && GameCanvas.mapBack != null;
					if (flag16)
					{
						GameCanvas.mapBack.setSkySnow();
					}
					bool flag17 = LoadMap.specMap == 8;
					if (flag17)
					{
						MapGotoSky.setTypeMoveredLine(0);
						MapGotoSky.SetPosNextMove();
						Player.boatKeyParty = null;
					}
					bool flag18 = LoadMap.specMap == 12;
					if (flag18)
					{
						MapGotoGod.setTypeMoveredLine(0);
						MapGotoGod.SetPosNextMove();
						Player.boatKeyParty = null;
					}
					LoadMap.Area = this.area;
					GameCanvas.gameScr.Show();
					Interface_Game.timeShowNameMap = 0;
					GameCanvas.hLoad = MotherCanvas.h / 4 * 3;
					Interface_Game.wtable = mFont.tahoma_7b_white.getWidth(LoadMap.getNameMap(GameCanvas.loadmap.idMap)) + 20;
					bool flag19 = Interface_Game.wtable < 100;
					if (flag19)
					{
						Interface_Game.wtable = 100;
					}
					this.setMapSea();
					GlobalService.gI().changeMapOk();
					bool flag20 = GameScreen.vecHelp == null;
					if (flag20)
					{
						GameScreen.vecHelp = new mVector();
						bool flag21 = GameScreen.indexHelp >= 0;
						if (flag21)
						{
							MainHelp.setNextHelp(false);
						}
					}
					bool flag22 = GameCanvas.loadmap.idMap == 1 && GameScreen.indexHelp == 14;
					if (flag22)
					{
						GameScreen.addHelp(14, 0);
					}
					LoadMapScreen.PlayMusicLang();
					LoadMap.mStrNameMapNPC = mFont.tahoma_7_white.splitFontArray(LoadMap.getNameMap(GameCanvas.loadmap.idMap), 70);
					GlobalService.gI().Update_Num_Player_Map();
					bool flag23 = GameCanvas.loadmap.idMap == 130;
					if (flag23)
					{
						GameScreen.player.Dir = 0;
						GameScreen.player.type_left_right = 0;
					}
					else
					{
						bool flag24 = GameCanvas.loadmap.idMap == 129;
						if (flag24)
						{
							GameScreen.player.Dir = 2;
							GameScreen.player.type_left_right = 2;
						}
					}
					bool flag25 = Player.StepAutoRe == 3;
					if (flag25)
					{
						Player.StepAutoRe = 0;
					}
					bool flag26 = GameCanvas.loadmap.mapLang();
					if (flag26)
					{
						Player.xBeginAuto = 0;
						Player.yBeginAuto = 0;
					}
					this.CheckHuongDanVaoLang();
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x060006AE RID: 1710 RVA: 0x00092E60 File Offset: 0x00091060
	private void CheckHuongDanVaoLang()
	{
		bool flag = GameScreen.player.Lv < 50 && GameScreen.indexHDVaoLang < T.mHuongdanVaoLang.Length;
		if (flag)
		{
			bool flag2 = false;
			bool flag3 = GameCanvas.loadmap.idMap == 9 && GameScreen.player.Lv < 20 && GameScreen.indexHDVaoLang <= 0;
			if (flag3)
			{
				flag2 = true;
				GameScreen.indexHDVaoLang = 1;
			}
			else
			{
				bool flag4 = GameCanvas.loadmap.idMap == 17 && GameScreen.indexHDVaoLang <= 1 && GameScreen.player.Lv < 30;
				if (flag4)
				{
					flag2 = true;
					GameScreen.indexHDVaoLang = 2;
				}
				else
				{
					bool flag5 = GameCanvas.loadmap.idMap == 25 && GameScreen.indexHDVaoLang <= 2 && GameScreen.player.Lv < 40;
					if (flag5)
					{
						flag2 = true;
						GameScreen.indexHDVaoLang = 3;
					}
					else
					{
						bool flag6 = GameCanvas.loadmap.idMap == 33 && GameScreen.indexHDVaoLang <= 3;
						if (flag6)
						{
							flag2 = true;
							GameScreen.indexHDVaoLang = 4;
						}
						else
						{
							bool flag7 = GameCanvas.loadmap.idMap == 41 && GameScreen.indexHDVaoLang <= 4;
							if (flag7)
							{
								flag2 = true;
								GameScreen.indexHDVaoLang = 5;
							}
							else
							{
								bool flag8 = GameCanvas.loadmap.idMap == 49 && GameScreen.indexHDVaoLang <= 5;
								if (flag8)
								{
									flag2 = true;
									GameScreen.indexHDVaoLang = 6;
								}
							}
						}
					}
				}
			}
			bool flag9 = flag2 && GameScreen.indexHDVaoLang < T.mHuongdanVaoLang.Length;
			if (flag9)
			{
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.mHuongdanVaoLang[GameScreen.indexHDVaoLang - 1]);
				GlobalService.gI().Save_RMS_Server(1, 8, new sbyte[]
				{
					(sbyte)GameScreen.indexHDVaoLang
				});
			}
		}
	}

	// Token: 0x060006AF RID: 1711 RVA: 0x00093020 File Offset: 0x00091220
	private bool checkMapDontshow()
	{
		bool flag = GameCanvas.loadmap.idMap == 157 || GameCanvas.loadmap.idMap == 159 || GameCanvas.loadmap.idMap == 161;
		return !flag;
	}

	// Token: 0x060006B0 RID: 1712 RVA: 0x00093074 File Offset: 0x00091274
	private void goToMapSea()
	{
		Skill_Info skill_Info = null;
		for (int i = 0; i < Player.vecListSkill.size(); i++)
		{
			Skill_Info skill_Info2 = (Skill_Info)Player.vecListSkill.elementAt(i);
			bool flag = skill_Info2.typeSkill == 4;
			if (flag)
			{
				skill_Info = skill_Info2;
				break;
			}
		}
		bool flag2 = skill_Info != null;
		if (flag2)
		{
			MainSkill mainSkill = new MainSkill(skill_Info.ID, skill_Info.typeEffSkill);
			mainSkill.indexHotKey = skill_Info.indexHotKey;
			mainSkill.idIcon = skill_Info.idIcon;
			mainSkill.isBuff = false;
			for (int j = 0; j < Player.hotkeyPlayer.Length; j++)
			{
				bool flag3 = true;
				for (int k = 0; k < Player.hotkeyPlayer[j].Length; k++)
				{
					int num = k;
					int num2 = num;
					int num3 = num2;
					if (num3 != 0)
					{
						if (num3 == 2)
						{
							num = 0;
						}
					}
					else
					{
						num = 2;
					}
					Hotkey hotkey = Player.hotkeyPlayer[j][num];
					bool flag4 = hotkey.skill != null && hotkey.skill.typeBuff == 0;
					if (flag4)
					{
						bool flag5 = flag3;
						if (flag5)
						{
							Player.hotkeyPlayer[j][num].setSkill(mainSkill, mainSkill.idIcon);
							flag3 = false;
						}
						else
						{
							Player.hotkeyPlayer[j][num].skill = null;
						}
					}
				}
			}
		}
		else
		{
			for (int l = 0; l < Player.hotkeyPlayer.Length; l++)
			{
				for (int m = 0; m < Player.hotkeyPlayer[l].Length; m++)
				{
					Hotkey hotkey2 = Player.hotkeyPlayer[l][m];
					bool flag6 = hotkey2.skill != null;
					if (flag6)
					{
						Player.hotkeyPlayer[l][m].skill = null;
					}
				}
			}
		}
	}

	// Token: 0x060006B1 RID: 1713 RVA: 0x00093258 File Offset: 0x00091458
	private void setMapSea()
	{
		bool flag = LoadMap.mSea == null || GameScreen.typeViewPlayer != 0;
		if (!flag)
		{
			for (int i = 0; i < LoadMap.mSea.Length; i++)
			{
				bool flag2 = (int)LoadMap.mSea[i][0] == GameCanvas.loadmap.idMap && (int)LoadMap.mSea[i][1] == GameCanvas.loadmap.idLastMap;
				if (flag2)
				{
					GameScreen.player.setActionSea((sbyte)LoadMap.mSea[i][2], (int)LoadMap.mSea[i][3], (int)LoadMap.mSea[i][4]);
					break;
				}
			}
		}
	}

	// Token: 0x060006B2 RID: 1714 RVA: 0x000932F4 File Offset: 0x000914F4
	public static void PlayMusicLang()
	{
		try
		{
			int type;
			switch (GameCanvas.loadmap.idMap)
			{
			case 0:
			case 3:
			case 4:
			case 5:
			case 6:
			case 8:
			case 14:
			case 16:
			case 22:
			case 24:
			case 30:
			case 34:
			case 35:
			case 36:
			case 37:
			case 38:
			case 40:
			case 46:
			case 48:
			case 54:
			case 70:
			case 71:
			case 72:
			case 73:
			case 74:
			case 75:
			case 76:
			case 80:
			case 81:
				type = 5;
				goto IL_1FD;
			case 1:
			case 9:
			case 17:
			case 25:
			case 79:
			case 107:
				type = 2;
				goto IL_1FD;
			case 2:
			case 10:
			case 11:
			case 12:
			case 13:
			case 18:
			case 19:
			case 20:
			case 21:
			case 26:
			case 27:
			case 28:
			case 29:
			case 42:
			case 43:
			case 44:
			case 45:
			case 50:
			case 51:
			case 52:
			case 53:
				type = 4;
				goto IL_1FD;
			case 7:
			case 15:
			case 23:
			case 31:
			case 39:
			case 47:
			case 63:
			case 64:
			case 68:
			case 78:
			case 84:
			case 85:
			case 86:
			case 87:
			case 88:
			case 89:
			case 90:
				type = 6;
				goto IL_1FD;
			case 33:
			case 41:
			case 49:
			case 66:
			case 83:
			case 113:
				type = 0;
				goto IL_1FD;
			case 69:
				type = 1;
				goto IL_1FD;
			}
			type = 4;
			IL_1FD:
			mSound.stopSoundAll();
			mSound.playMus(type, mSound.volumeMusic, true);
		}
		catch (Exception)
		{
			mSystem.outloi("load bat am thanh");
		}
	}

	// Token: 0x040009B6 RID: 2486
	public static bool isNextMap;

	// Token: 0x040009B7 RID: 2487
	public static bool isLoadDataMon;

	// Token: 0x040009B8 RID: 2488
	public static bool isPaintBack = true;

	// Token: 0x040009B9 RID: 2489
	public static bool isSuperBoss;

	// Token: 0x040009BA RID: 2490
	private long time;

	// Token: 0x040009BB RID: 2491
	public sbyte[] mItemMap;

	// Token: 0x040009BC RID: 2492
	public static sbyte IDBack;

	// Token: 0x040009BD RID: 2493
	public static sbyte typeChangeMap;

	// Token: 0x040009BE RID: 2494
	public static short HBack;

	// Token: 0x040009BF RID: 2495
	private int tick;

	// Token: 0x040009C0 RID: 2496
	private int tickPaintMap;

	// Token: 0x040009C1 RID: 2497
	public static sbyte isMapSky = -1;

	// Token: 0x040009C2 RID: 2498
	public static sbyte countLoadMap;

	// Token: 0x040009C3 RID: 2499
	public sbyte area = -1;
}
