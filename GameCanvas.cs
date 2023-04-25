using System;

// Token: 0x02000033 RID: 51
public class GameCanvas : MotherCanvas, IActionListener
{
	// Token: 0x06000391 RID: 913 RVA: 0x00009B5F File Offset: 0x00007D5F
	public GameCanvas(Context context) : base(context)
	{
		this.initGame();
	}

	// Token: 0x06000392 RID: 914 RVA: 0x00009B7C File Offset: 0x00007D7C
	public GameCanvas()
	{
		this.initGame();
	}

	// Token: 0x06000393 RID: 915 RVA: 0x00070DEC File Offset: 0x0006EFEC
	public void initGame()
	{
		sbyte[] array = CRes.loadRMS("Main_IPWORLD");
		bool flag = array != null;
		if (flag)
		{
			ByteArrayInputStream bis = new ByteArrayInputStream(array);
			DataInputStream dataInputStream = new DataInputStream(bis);
			try
			{
				GameCanvas.language = dataInputStream.readByte();
				dataInputStream.close();
			}
			catch (Exception)
			{
				GameCanvas.language = 0;
			}
		}
		bool flag2 = GameCanvas.language == 1;
		if (flag2)
		{
			T_E.loadT_E();
		}
		else
		{
			T.loadT();
		}
		GameCanvas.instance = this;
		TField.setVendorTypeMode(TField.NOKIA);
		GameCanvas.isTouch = base.hasPointerEvents();
		GameCanvas.Day_Night = GameCanvas.get_Day_Night();
		bool flag3 = MotherCanvas.w < 200 || MotherCanvas.h < 200;
		if (flag3)
		{
			GameCanvas.isSmallScreen = true;
			iCommand.wButtonCmd = 60;
			iCommand.hButtonCmdNor = 20;
			iCommand.hButtonCmdSpec = 46;
			Scroll.hRectScroll = 16;
		}
		GameCanvas.wCommand = 36;
		bool flag4 = GameCanvas.isTouch;
		if (flag4)
		{
			GameCanvas.wCommand = 40;
			GameCanvas.listPoint = new mVector();
			iCommand.hButtonCmdNor = 30;
			iCommand.hButtonCmdSpec = 46;
			iCommand.wButtonCmd = 70;
		}
		else
		{
			bool flag5 = GameCanvas.isSmallScreen;
			if (flag5)
			{
				GameCanvas.wCommand = 30;
			}
		}
		bool flag6 = GameMidlet.DEVICE != 0 && (mGraphics.zoomLevel > 1 || GameMidlet.DEVICE == 2);
		if (flag6)
		{
			mFont.loadmFont();
			this.isLoadFont = true;
		}
		sbyte[] array2 = CRes.loadRMS("Main_Load_Image_Android_OK");
		string text = string.Empty;
		bool flag7 = array2 != null;
		if (flag7)
		{
			ByteArrayInputStream bis2 = new ByteArrayInputStream(array2);
			DataInputStream dataInputStream2 = new DataInputStream(bis2);
			try
			{
				text = dataInputStream2.readUTF();
				dataInputStream2.close();
			}
			catch (Exception)
			{
				text = string.Empty;
			}
		}
		bool flag8 = text.CompareTo("1.2.3") == 0 || GameMidlet.DEVICE == 0 || GameMidlet.DEVICE == 4;
		if (flag8)
		{
			this.beginGame();
		}
		else
		{
			GameCanvas.updateImageAndroidScr = new UpdateImageScreen();
			GameCanvas.updateImageAndroidScr.Show();
		}
	}

	// Token: 0x06000394 RID: 916 RVA: 0x00071000 File Offset: 0x0006F200
	public void beginGame()
	{
		bool flag = !this.isLoadFont;
		if (flag)
		{
			mFont.loadmFont();
		}
		CRes.loadSinCos();
		mSound.init(7, 54);
		Player.hotkeyPlayer = new Hotkey[2][];
		for (int i = 0; i < Player.hotkeyPlayer.Length; i++)
		{
			Player.hotkeyPlayer[i] = new Hotkey[5];
			for (int j = 0; j < Player.hotkeyPlayer[i].Length; j++)
			{
				Player.hotkeyPlayer[i][j] = new Hotkey();
			}
		}
		bool flag2 = GameCanvas.language == 1;
		if (flag2)
		{
			for (int k = 0; k < GameMidlet.google_productIds.Length; k++)
			{
				GameMidlet.google_productIds[k] = GameMidlet.google_productIds_Eng[k];
			}
		}
		this.loadRMSGAME();
		LoadImageStatic.LoadAllImage();
		MsgDialog.hPlus = 15;
		MainScreen.cameraMain = new Camera();
		MainScreen.cameraSub = new Camera();
		GameCanvas.chatTabScr = new ChatTabScreen();
		GameCanvas.gameScr = new GameScreen();
		GameCanvas.loginScr = new LoginScreen();
		GameCanvas.loadmap = new LoadMap();
		GameCanvas.loadMapScr = new LoadMapScreen();
		bool flag3 = MotherCanvas.h < 220 && GameCanvas.isTouch;
		if (flag3)
		{
			GameCanvas.isShortH = true;
		}
		GameCanvas.addTabStart();
		GameCanvas.saveRms = new SaveRms();
		GameCanvas.saveRms.loadBeginGame();
		GameCanvas.fristLoginScr = new FristLoginScreen();
		GameCanvas.eventScr = new MainEvent(-3, Player.vecEvent);
		GameCanvas.fristLoginScr.Show();
		GameCanvas.fristLoginScr.setBeginGame();
	}

	// Token: 0x06000395 RID: 917 RVA: 0x00009B98 File Offset: 0x00007D98
	private void randomBilak()
	{
		this.bilak = new ScreenBilak();
		GameCanvas.currentScreen = this.bilak;
	}

	// Token: 0x06000396 RID: 918 RVA: 0x00071194 File Offset: 0x0006F394
	public static void addTabStart()
	{
		MainTab mainTab = new MainTab();
		mainTab.createValue();
		GameCanvas.tabAllScr = new TabScreen(MainTab.xTab, 0);
		mVector mVector = new mVector();
		GameCanvas.tabInven = new TabInventory(T.tabInven, Player.vecInventory, 0, MainTab.xTab);
		GameCanvas.tabInven.initCmd();
		mVector.addElement(GameCanvas.tabInven);
		TabEquip o = new TabEquip(T.tabEquip);
		mVector.addElement(o);
		TabInfo o2 = new TabInfo(T.tabInfo);
		mVector.addElement(o2);
		TabSkill o3 = new TabSkill(T.tabSkill);
		mVector.addElement(o3);
		TabQuest o4 = new TabQuest(T.tabQuest);
		mVector.addElement(o4);
		bool flag = !GameCanvas.isTouch;
		if (flag)
		{
			TabMenu o5 = new TabMenu(T.setting, GameCanvas.gameScr.getMenu());
			mVector.addElement(o5);
		}
		GameCanvas.tabAllScr.addVecTab(mVector);
	}

	// Token: 0x06000397 RID: 919 RVA: 0x00071284 File Offset: 0x0006F484
	public override void paint(mGraphics gx)
	{
		try
		{
			bool flag = GameCanvas.isTaiTho;
			if (flag)
			{
				this.g.setColor(0);
				this.g.fillRect(0, 0, MotherCanvas.w, MotherCanvas.h);
			}
			GameCanvas.currentScreen.paint(this.g);
			GameCanvas.resetTrans(this.g);
			bool flag2 = GameScreen.h12plus > 0;
			if (flag2)
			{
				this.g.setColor(0);
				this.g.fillRect(0, 0, MotherCanvas.w, GameScreen.h12plus);
				bool flag3 = AvMain.imgPlus12_2 == null;
				if (flag3)
				{
					AvMain.imgPlus12_2 = mImage.createImage("/interface/plus12_2.png");
				}
				else
				{
					this.g.drawImage(AvMain.imgPlus12_2, 0, 0, 0);
				}
				bool flag4 = mFont.tahoma_7_white != null;
				if (flag4)
				{
					mFont.tahoma_7_white.drawString(this.g, T.plus12, GameCanvas.xPlus12 + 13, 1, 0);
				}
			}
			bool flag5 = GameCanvas.subDialog != null;
			if (flag5)
			{
				GameCanvas.subDialog.paint(this.g);
			}
			bool flag6 = GameCanvas.currentDialog != null;
			if (flag6)
			{
				GameCanvas.currentDialog.paint(this.g);
			}
			else
			{
				bool isShowMenu = GameCanvas.menuCur.isShowMenu;
				if (isShowMenu)
				{
					GameCanvas.menuCur.paintMenu(this.g);
				}
				else
				{
					bool isShow = ChatTextField.isShow;
					if (isShow)
					{
						ChatTextField.gI().paint(this.g);
					}
				}
				Interface_Game.paintShowHelp(this.g, false);
			}
			bool flag7 = !GameScreen.getIsOffAdmin(2);
			if (flag7)
			{
				GameCanvas.resetTrans(this.g);
				Interface_Game.paintShowEvent(this.g);
				bool flag8 = GameScreen.player != null;
				if (flag8)
				{
					Interface_Game.paintInfoServer(this.g);
				}
			}
			GameCanvas.resetTrans(this.g);
			bool flag9 = GameCanvas.hLoad > 0;
			if (flag9)
			{
				this.g.setColor(0);
				this.g.fillRect(0, 0, MotherCanvas.w, MotherCanvas.h);
			}
			bool isShowText = GameScreen.isShowText;
			if (isShowText)
			{
				for (int i = 0; i < GameCanvas.vecTest.size(); i++)
				{
					string st = (string)GameCanvas.vecTest.elementAt(i);
					bool flag10 = i < 20;
					if (flag10)
					{
						mFont.tahoma_7b_black.drawString(this.g, st, 0, MotherCanvas.h - GameCanvas.hText - i * GameCanvas.hText, 0);
						mFont.tahoma_7b_white.drawString(this.g, st, -1, MotherCanvas.h - GameCanvas.hText - i * GameCanvas.hText - 1, 0);
					}
					else
					{
						mFont.tahoma_7b_black.drawString(this.g, st, MotherCanvas.w, MotherCanvas.h - GameCanvas.hText - (i - 20) * GameCanvas.hText, 1);
						mFont.tahoma_7b_white.drawString(this.g, st, MotherCanvas.w - 1, MotherCanvas.h - GameCanvas.hText - (i - 20) * GameCanvas.hText - 1, 1);
					}
				}
			}
			bool flag11 = GameCanvas.istest;
			if (flag11)
			{
				mFont.tahoma_7_black.drawString(this.g, "server test", 0, MotherCanvas.h - 20, 0);
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000398 RID: 920 RVA: 0x000715FC File Offset: 0x0006F7FC
	public static void addTest(string str)
	{
		GameCanvas.vecTest.addElement(str);
		bool flag = GameCanvas.vecTest.size() > 40;
		if (flag)
		{
			GameCanvas.vecTest.removeElementAt(0);
		}
	}

	// Token: 0x06000399 RID: 921 RVA: 0x00071638 File Offset: 0x0006F838
	public override void update()
	{
		try
		{
			GameCanvas.gameTick++;
			bool flag = GameCanvas.gameTick > 12000;
			if (flag)
			{
				GameCanvas.gameTick = 0;
			}
			GameCanvas.gameTickChia4 = GameCanvas.gameTick / 4;
			bool flag2 = GameCanvas.tickAction > 0;
			if (flag2)
			{
				GameCanvas.tickAction--;
			}
			bool flag3 = GameCanvas.gameTick % 5 == 0;
			if (flag3)
			{
				GameCanvas.timeNow = mSystem.currentTimeMillis();
			}
			bool flag4 = GameCanvas.hLoad > 0;
			if (flag4)
			{
				GameCanvas.hLoad -= MotherCanvas.h / 10;
			}
			Interface_Game.updateShowEvent();
			Interface_Game.updateInfoServer();
			bool isPvPNew = GameScreen.isPvPNew;
			if (isPvPNew)
			{
				Interface_Game.updateShowEvent();
				Interface_Game.updateInfoServer();
			}
			bool flag5 = GameCanvas.currentDialog != null;
			if (flag5)
			{
				GameCanvas.currentDialog.update();
			}
			else
			{
				Interface_Game.UpdateShowHelp(this.g);
				bool isShowMenu = GameCanvas.menuCur.isShowMenu;
				if (isShowMenu)
				{
					GameCanvas.menuCur.updateMenu();
					GameCanvas.menuCur.updateMenuKey();
				}
				else
				{
					bool flag6 = GameCanvas.subDialog != null;
					if (flag6)
					{
						GameCanvas.subDialog.update();
					}
					else
					{
						bool isShow = ChatTextField.isShow;
						if (isShow)
						{
							ChatTextField.gI().updatekey();
							ChatTextField.gI().updatePointer();
						}
						else
						{
							GameCanvas.currentScreen.updatekey();
							GameCanvas.currentScreen.updatePointer();
						}
					}
				}
			}
			GameCanvas.currentScreen.update();
			GameCanvas.isPointerClick = false;
			bool flag7 = GameScreen.timeResetCam > 0;
			if (flag7)
			{
				GameScreen.timeResetCam--;
				bool flag8 = GameScreen.timeResetCam == 0;
				if (flag8)
				{
					GameScreen.isMoveCamera = false;
				}
			}
			GameCanvas.isPointerSelect = false;
			Net.update();
			bool flag9 = GameCanvas.tickSelectChar > 0;
			if (flag9)
			{
				GameCanvas.tickSelectChar--;
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x0600039A RID: 922 RVA: 0x00071834 File Offset: 0x0006FA34
	public static GameCanvas gI()
	{
		return GameCanvas.instance;
	}

	// Token: 0x0600039B RID: 923 RVA: 0x0007184C File Offset: 0x0006FA4C
	public static void connect()
	{
		GameCanvas.isLoadImage = false;
		Session_ME.gI().setHandler(GlobalMessageHandler.gI());
		bool flag = GameCanvas.language == 1;
		if (!flag)
		{
			bool flag2 = GameCanvas.IndexServer == 0;
			if (!flag2)
			{
				bool flag3 = GameCanvas.IndexServer == 1;
				if (!flag3)
				{
					bool flag4 = GameCanvas.IndexServer == 2;
					if (flag4)
					{
					}
				}
			}
		}
		bool flag5 = GameMidlet.DEVICE != 0 && GameMidlet.DEVICE != 4;
		if (flag5)
		{
			bool flag6 = GameCanvas.language == 1;
			if (!flag6)
			{
				bool flag7 = GameCanvas.IndexServer == 0;
				if (!flag7)
				{
					bool flag8 = GameCanvas.IndexServer == 1;
					if (!flag8)
					{
						bool flag9 = GameCanvas.IndexServer == 2;
						if (flag9)
						{
						}
					}
				}
			}
		}
		string[] array = null;
		try
		{
			bool flag10 = GameCanvas.strIP.Length > 0;
			if (flag10)
			{
				array = mFont.split(GameCanvas.strIP, "-");
				mSystem.outz("nhap ip kieu moi ip=" + array[0] + " port=" + int.Parse(array[1]).ToString());
			}
		}
		catch (Exception)
		{
			array = null;
		}
		bool flag11 = array != null;
		string host;
		int port;
		if (flag11)
		{
			host = array[0];
			port = int.Parse(array[1]);
		}
		bool flag12 = GameCanvas.istest;
		if (flag12)
		{
			string text = (!(GameCanvas.strIP != string.Empty)) ? "localhost" : GameCanvas.strIP;
		}
		port = 2229;
		host = "14.225.217.115";
		Session_ME.gI().connect(host, port);
		GameCanvas.infoDisConnect = string.Empty;
	}

	// Token: 0x0600039C RID: 924 RVA: 0x00071A78 File Offset: 0x0006FC78
	public static void connectDownload()
	{
		GameCanvas.isLoadImage = true;
		Session_ME.gI().setHandler(GlobalMessageHandler.gI());
		int port = 2229;
		string host = "14.225.217.115";
		Session_ME.gI().connect(host, port);
	}

	// Token: 0x0600039D RID: 925 RVA: 0x00009BB1 File Offset: 0x00007DB1
	public static void resetTrans(mGraphics g)
	{
		g.translate(-g.getTranslateX(), -g.getTranslateY());
		g.setClip(0, 0, MotherCanvas.w, MotherCanvas.h);
	}

	// Token: 0x0600039E RID: 926 RVA: 0x00071AB8 File Offset: 0x0006FCB8
	public override void keyPressed(int keyCode)
	{
		GameCanvas.tickAction = 4500;
		Player.isAFK = false;
		MsgDialog.isAuroReconect = false;
		bool flag = Player.StepAutoRe == 5;
		if (flag)
		{
			Player.StepAutoRe = 4;
		}
		bool flag2 = TField.isQwerty && ((keyCode >= 48 && keyCode <= 57) || (keyCode >= 65 && keyCode <= 122) || keyCode == 10 || keyCode == 8 || keyCode == 13 || keyCode == 32);
		if (flag2)
		{
			GameCanvas.keyAsciiPress = keyCode;
		}
		this.mapKeyPress(keyCode);
	}

	// Token: 0x0600039F RID: 927 RVA: 0x00071B38 File Offset: 0x0006FD38
	public void mapKeyPress(int keyCode)
	{
		bool flag = GameCanvas.currentDialog != null;
		if (flag)
		{
			GameCanvas.currentDialog.keypress(keyCode);
		}
		else
		{
			bool flag2 = GameCanvas.subDialog != null;
			if (flag2)
			{
				GameCanvas.subDialog.keypress(keyCode);
			}
			else
			{
				bool isShow = ChatTextField.isShow;
				if (isShow)
				{
					ChatTextField.gI().keyPressed(keyCode);
				}
				else
				{
					GameCanvas.currentScreen.keyPress(keyCode);
				}
			}
		}
		bool flag3 = !GameScreen.isShowFocusTK && GameMidlet.DEVICE == 0 && GameCanvas.isTouch;
		if (flag3)
		{
			GameScreen.isShowFocusTK = true;
		}
		bool flag4 = GameCanvas.isSendChatpopup;
		if (flag4)
		{
			GameCanvas.isSendChatpopup = false;
		}
		else
		{
			bool flag5 = base.keyPressPc(keyCode);
			if (!flag5)
			{
				bool flag6 = TField.isQwerty && !ChatTextField.isShow;
				if (flag6)
				{
					bool flag7 = GameCanvas.keyAsciiPress == 114 || GameCanvas.keyAsciiPress == 82;
					if (flag7)
					{
						GameCanvas.keyMyHold[21] = true;
						GameCanvas.keyMyPressed[21] = true;
					}
					else
					{
						bool flag8 = GameCanvas.keyAsciiPress == 116 || GameCanvas.keyAsciiPress == 84;
						if (flag8)
						{
							GameCanvas.keyMyHold[23] = true;
							GameCanvas.keyMyPressed[23] = true;
						}
						else
						{
							bool flag9 = GameCanvas.keyAsciiPress == 121 || GameCanvas.keyAsciiPress == 89;
							if (flag9)
							{
								GameCanvas.keyMyHold[25] = true;
								GameCanvas.keyMyPressed[25] = true;
							}
							else
							{
								bool flag10 = GameCanvas.keyAsciiPress == 117 || GameCanvas.keyAsciiPress == 85;
								if (flag10)
								{
									GameCanvas.keyMyHold[27] = true;
									GameCanvas.keyMyPressed[27] = true;
								}
								else
								{
									bool flag11 = GameCanvas.keyAsciiPress == 105 || GameCanvas.keyAsciiPress == 73;
									if (flag11)
									{
										GameCanvas.keyMyHold[29] = true;
										GameCanvas.keyMyPressed[29] = true;
									}
								}
							}
						}
					}
				}
				switch (keyCode)
				{
				case -7:
					GameCanvas.keyMyHold[13] = true;
					GameCanvas.keyMyPressed[13] = true;
					goto IL_334;
				case -6:
					GameCanvas.keyMyHold[12] = true;
					GameCanvas.keyMyPressed[12] = true;
					goto IL_334;
				case -5:
					break;
				case -4:
					GameCanvas.keyMyHold[6] = true;
					GameCanvas.keyMyPressed[6] = true;
					goto IL_334;
				case -3:
					GameCanvas.keyMyHold[4] = true;
					GameCanvas.keyMyPressed[4] = true;
					goto IL_334;
				case -2:
					GameCanvas.keyMyHold[8] = true;
					GameCanvas.keyMyPressed[8] = true;
					goto IL_334;
				case -1:
					GameCanvas.keyMyHold[2] = true;
					GameCanvas.keyMyPressed[2] = true;
					goto IL_334;
				default:
					if (keyCode != 10)
					{
						switch (keyCode)
						{
						case 35:
							GameCanvas.keyMyHold[11] = true;
							GameCanvas.keyMyPressed[11] = true;
							goto IL_334;
						case 36:
						case 37:
						case 38:
						case 39:
						case 40:
						case 41:
						case 43:
						case 44:
						case 45:
						case 46:
						case 47:
							goto IL_334;
						case 42:
							GameCanvas.keyMyHold[10] = true;
							GameCanvas.keyMyPressed[10] = true;
							goto IL_334;
						case 48:
						case 49:
						case 50:
						case 51:
						case 52:
						case 53:
						case 54:
						case 55:
						case 56:
						case 57:
							GameCanvas.keyMyHold[keyCode - 28] = true;
							GameCanvas.keyMyPressed[keyCode - 28] = true;
							goto IL_334;
						default:
							goto IL_334;
						}
					}
					break;
				}
				GameCanvas.keyMyHold[5] = true;
				GameCanvas.keyMyPressed[5] = true;
				IL_334:;
			}
		}
	}

	// Token: 0x060003A0 RID: 928 RVA: 0x00071E7C File Offset: 0x0007007C
	public override void keyReleased(int keyCode)
	{
		bool isQwerty = TField.isQwerty;
		if (isQwerty)
		{
			GameCanvas.keyAsciiPress = 0;
		}
		this.mapKeyRelease(keyCode);
	}

	// Token: 0x060003A1 RID: 929 RVA: 0x00071EA4 File Offset: 0x000700A4
	public void mapKeyRelease(int keyCode)
	{
		base.keyReleasedPc(keyCode);
		switch (keyCode)
		{
		case -7:
			GameCanvas.keyMyHold[13] = false;
			return;
		case -6:
			GameCanvas.keyMyHold[12] = false;
			return;
		case -5:
			break;
		case -4:
			GameCanvas.keyMyHold[6] = false;
			GameCanvas.keyMyPressed[6] = false;
			return;
		case -3:
			GameCanvas.keyMyHold[4] = false;
			GameCanvas.keyMyPressed[4] = false;
			return;
		case -2:
			GameCanvas.keyMyHold[8] = false;
			GameCanvas.keyMyPressed[8] = false;
			return;
		case -1:
			GameCanvas.keyMyHold[2] = false;
			GameCanvas.keyMyPressed[2] = false;
			return;
		default:
			if (keyCode != 10)
			{
				switch (keyCode)
				{
				case 35:
					GameCanvas.keyMyHold[11] = false;
					return;
				case 36:
				case 37:
				case 38:
				case 39:
				case 40:
				case 41:
				case 43:
				case 44:
				case 45:
				case 46:
				case 47:
					return;
				case 42:
					GameCanvas.keyMyHold[10] = false;
					return;
				case 48:
				case 49:
				case 50:
				case 51:
				case 52:
				case 53:
				case 54:
				case 55:
				case 56:
				case 57:
					GameCanvas.keyMyHold[keyCode - 28] = false;
					return;
				default:
					return;
				}
			}
			break;
		}
		GameCanvas.keyMyHold[5] = false;
		GameCanvas.keyMyPressed[5] = false;
	}

	// Token: 0x060003A2 RID: 930 RVA: 0x00071FF0 File Offset: 0x000701F0
	public static bool isKeyPressed(int index)
	{
		return GameCanvas.keyMyPressed[index];
	}

	// Token: 0x060003A3 RID: 931 RVA: 0x00072014 File Offset: 0x00070214
	public void onPointerDragged(int x, int y)
	{
		GameCanvas.isPointerSelect = false;
		GameCanvas.px = x;
		GameCanvas.py = y;
		bool flag = GameCanvas.isPointerMove;
		if (flag)
		{
			GameCanvas.listPoint.addElement(new Position(x, y));
		}
		else
		{
			bool flag2 = CRes.abs(GameCanvas.px - GameCanvas.pxLast) >= 15 || CRes.abs(GameCanvas.py - GameCanvas.pyLast) >= 15;
			if (flag2)
			{
				GameCanvas.isPointerMove = true;
			}
		}
	}

	// Token: 0x060003A4 RID: 932 RVA: 0x00072090 File Offset: 0x00070290
	public void onPointerPressed(int x, int y)
	{
		Player.isAFK = false;
		MsgDialog.isAuroReconect = false;
		bool flag = Player.StepAutoRe == 5;
		if (flag)
		{
			Player.StepAutoRe = 4;
		}
		GameCanvas.tickAction = 4500;
		GameCanvas.isPointerDown = true;
		GameCanvas.isPointerMove = false;
		GameCanvas.isPointerSelect = false;
		GameCanvas.isPointerRelease = false;
		GameCanvas.isPointerEnd = false;
		GameCanvas.pxLast = x;
		GameCanvas.pyLast = y;
		GameCanvas.px = x;
		GameCanvas.py = y;
	}

	// Token: 0x060003A5 RID: 933 RVA: 0x00072100 File Offset: 0x00070300
	public void onPointerReleased(int x, int y)
	{
		bool flag = !GameCanvas.isPointerMove && !GameCanvas.isPointerEnd;
		if (flag)
		{
			GameCanvas.isPointerSelect = true;
		}
		GameCanvas.clearKeyHold();
		GameCanvas.clearKeyPressed();
		GameCanvas.isPointerDown = false;
		GameCanvas.isPointerRelease = true;
		GameCanvas.isPointerMove = false;
		GameCanvas.isPointerClick = true;
		GameCanvas.isPointerEnd = false;
		GameCanvas.px = x;
		GameCanvas.py = y;
	}

	// Token: 0x060003A6 RID: 934 RVA: 0x00072164 File Offset: 0x00070364
	public static void clearKeyPressed()
	{
		GameCanvas.isPointerRelease = false;
		GameCanvas.isPointerDown = false;
		for (int i = 0; i < GameCanvas.keyMyPressed.Length; i++)
		{
			GameCanvas.keyMyPressed[i] = false;
		}
	}

	// Token: 0x060003A7 RID: 935 RVA: 0x00009BDC File Offset: 0x00007DDC
	public static void clearKeyPressed(int keycode)
	{
		GameCanvas.isPointerRelease = false;
		GameCanvas.isPointerDown = false;
		GameCanvas.keyMyPressed[keycode] = false;
	}

	// Token: 0x060003A8 RID: 936 RVA: 0x000721A0 File Offset: 0x000703A0
	public static void clearKeyHold()
	{
		GameCanvas.isPointerRelease = false;
		GameCanvas.isPointerDown = false;
		for (int i = 0; i < GameCanvas.keyMyHold.Length; i++)
		{
			GameCanvas.keyMyHold[i] = false;
		}
	}

	// Token: 0x060003A9 RID: 937 RVA: 0x00009BF3 File Offset: 0x00007DF3
	public static void clearKeyHold(int keycode)
	{
		GameCanvas.isPointerRelease = false;
		GameCanvas.isPointerDown = false;
		GameCanvas.keyMyHold[keycode] = false;
	}

	// Token: 0x060003AA RID: 938 RVA: 0x000721DC File Offset: 0x000703DC
	public static void clearKeyReleased()
	{
		GameCanvas.isPointerDown = false;
		GameCanvas.isPointerRelease = false;
		for (int i = 0; i < GameCanvas.keyMyReleased.Length; i++)
		{
			GameCanvas.keyMyReleased[i] = false;
		}
	}

	// Token: 0x060003AB RID: 939 RVA: 0x00009C0A File Offset: 0x00007E0A
	public static void clearAll()
	{
		GameCanvas.clearKeyHold();
		GameCanvas.clearKeyPressed();
		GameCanvas.clearKeyReleased();
		GameCanvas.isPointerSelect = false;
		GameCanvas.isPointerMove = false;
		GameCanvas.isPointerClick = false;
		GameCanvas.isPointerDown = false;
	}

	// Token: 0x060003AC RID: 940 RVA: 0x00072218 File Offset: 0x00070418
	public static bool isPointer(int x, int y, int w, int h)
	{
		bool flag = !GameCanvas.isPointerDown && !GameCanvas.isPointerRelease;
		return !flag && GameCanvas.isPoint(x, y, w, h);
	}

	// Token: 0x060003AD RID: 941 RVA: 0x00072250 File Offset: 0x00070450
	public static bool isPointSelect(int x, int y, int w, int h)
	{
		bool flag = !GameCanvas.isPointerSelect;
		return !flag && GameCanvas.isPoint(x, y, w, h);
	}

	// Token: 0x060003AE RID: 942 RVA: 0x0007227C File Offset: 0x0007047C
	public static bool isPoint(int x, int y, int w, int h)
	{
		return GameCanvas.px >= x && GameCanvas.px <= x + w && GameCanvas.py >= y && GameCanvas.py <= y + h;
	}

	// Token: 0x060003AF RID: 943 RVA: 0x000722C4 File Offset: 0x000704C4
	public static bool isPointLast(int x, int y, int w, int h)
	{
		return GameCanvas.pxLast >= x && GameCanvas.pxLast <= x + w && GameCanvas.pyLast >= y && GameCanvas.pyLast <= y + h;
	}

	// Token: 0x060003B0 RID: 944 RVA: 0x0007230C File Offset: 0x0007050C
	public static void Start_Normal_DiaLog(string info, mVector vecCmd, bool isCmdClose)
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setinfo(info, vecCmd, isCmdClose, 0);
		GameCanvas.currentDialog = msgDialog;
	}

	// Token: 0x060003B1 RID: 945 RVA: 0x00072334 File Offset: 0x00070534
	public static void Start_ReConect_DiaLog(string info, mVector vecCmd, bool isCmdClose)
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setinfo(info, vecCmd, isCmdClose, 9);
		GameCanvas.currentDialog = msgDialog;
	}

	// Token: 0x060003B2 RID: 946 RVA: 0x0007235C File Offset: 0x0007055C
	public static void Start_Normal_DiaLog_New(string info, mVector vecCmd, bool isCmdClose, string name)
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setinfoNew(info, vecCmd, isCmdClose, name);
		GameCanvas.currentDialog = msgDialog;
	}

	// Token: 0x060003B3 RID: 947 RVA: 0x00072384 File Offset: 0x00070584
	public static void Start_Normal_DiaLog(string info, iCommand cmd, bool isCmdClose)
	{
		mVector mVector = new mVector();
		mVector.addElement(cmd);
		GameCanvas.Start_Normal_DiaLog(info, mVector, isCmdClose);
	}

	// Token: 0x060003B4 RID: 948 RVA: 0x000723AC File Offset: 0x000705AC
	public static void Start_Normal_Only_CmdClose_DiaLog(string info)
	{
		mVector vecCmd = new mVector();
		GameCanvas.Start_Normal_DiaLog(info, vecCmd, true);
	}

	// Token: 0x060003B5 RID: 949 RVA: 0x000723CC File Offset: 0x000705CC
	public static void Start_Waiting_DiaLog(string info, bool isCmdClose)
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setWaitinginfo(info, null, isCmdClose, 1, 0);
		GameCanvas.currentDialog = msgDialog;
	}

	// Token: 0x060003B6 RID: 950 RVA: 0x000723F4 File Offset: 0x000705F4
	public static void Start_Waiting_Connect_DiaLog(string info, bool isCmdClose)
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setWaitinginfo(info, null, isCmdClose, 8, 0);
		GameCanvas.currentDialog = msgDialog;
	}

	// Token: 0x060003B7 RID: 951 RVA: 0x0007241C File Offset: 0x0007061C
	public static void Start_Time_DiaLog(string info, bool isCmdClose, int time, mVector vec)
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setWaitinginfo(info, vec, isCmdClose, 6, time);
		GameCanvas.currentDialog = msgDialog;
	}

	// Token: 0x060003B8 RID: 952 RVA: 0x00072444 File Offset: 0x00070644
	public static InputDialog Start_Input_Dialog(string info, iCommand cmd, bool isNum, string name)
	{
		InputDialog inputDialog = new InputDialog();
		inputDialog.setinfo(info, cmd, isNum, name);
		return inputDialog;
	}

	// Token: 0x060003B9 RID: 953 RVA: 0x00072468 File Offset: 0x00070668
	public static InputDialog Start_Input_Dialog_Server(string[] info, string name, short Id)
	{
		InputDialog inputDialog = new InputDialog();
		inputDialog.setinfo(info, name, Id, null, string.Empty);
		return inputDialog;
	}

	// Token: 0x060003BA RID: 954 RVA: 0x00072494 File Offset: 0x00070694
	public static InputDialog Start_Input_Dialog_Server(string[] info, string name, iCommand cmd)
	{
		InputDialog inputDialog = new InputDialog();
		inputDialog.setinfo(info, name, 0, cmd, string.Empty);
		return inputDialog;
	}

	// Token: 0x060003BB RID: 955 RVA: 0x000724C0 File Offset: 0x000706C0
	public static InputDialog Start_ShopInput_Dialog(string info, iCommand cmd, bool isNum, int defValue, int price, string name, string xuluong)
	{
		InputDialog inputDialog = new InputDialog();
		inputDialog.setinfoSmallNew(info, cmd, isNum, defValue, price, name, xuluong);
		return inputDialog;
	}

	// Token: 0x060003BC RID: 956 RVA: 0x000724EC File Offset: 0x000706EC
	public static MsgArchiDaily Start_Archi_Dialog(string name, mVector vec)
	{
		MsgArchiDaily msgArchiDaily = new MsgArchiDaily();
		msgArchiDaily.setinfo(name, vec);
		return msgArchiDaily;
	}

	// Token: 0x060003BD RID: 957 RVA: 0x00072510 File Offset: 0x00070710
	public static MsgTableMatch Start_Match_Dialog(mVector vec)
	{
		MsgTableMatch msgTableMatch = new MsgTableMatch();
		msgTableMatch.setinfo(vec);
		return msgTableMatch;
	}

	// Token: 0x060003BE RID: 958 RVA: 0x00009C37 File Offset: 0x00007E37
	public static void Start_Current_Dialog(MainDialog dgl)
	{
		GameCanvas.currentDialog = dgl;
	}

	// Token: 0x060003BF RID: 959 RVA: 0x00009C40 File Offset: 0x00007E40
	public static void Start_Sub_Dialog(MainDialog dgl)
	{
		GameCanvas.subDialog = dgl;
	}

	// Token: 0x060003C0 RID: 960 RVA: 0x00009C49 File Offset: 0x00007E49
	public static void ShowMenu(Menu menu)
	{
		GameCanvas.menuCur = menu;
		mSound.playSound(1, mSound.volumeSound);
	}

	// Token: 0x060003C1 RID: 961 RVA: 0x00072534 File Offset: 0x00070734
	public static void end_Dialog()
	{
		GameCanvas.currentDialog = null;
		GameCanvas.subDialog = null;
		GameCanvas.clearKeyHold();
		GameCanvas.clearKeyPressed();
		bool flag = GameCanvas.currentScreen != null;
		if (flag)
		{
			GameCanvas.currentScreen.CheckClickCmd();
		}
	}

	// Token: 0x060003C2 RID: 962 RVA: 0x00072574 File Offset: 0x00070774
	public static void end_Cur_Dialog()
	{
		GameCanvas.currentDialog = null;
		GameCanvas.clearKeyHold();
		GameCanvas.clearKeyPressed();
		bool flag = GameCanvas.currentScreen != null;
		if (flag)
		{
			GameCanvas.currentScreen.CheckClickCmd();
		}
	}

	// Token: 0x060003C3 RID: 963 RVA: 0x000725B0 File Offset: 0x000707B0
	public static bool getShowCmd()
	{
		return !GameCanvas.menuCur.isShowMenu && GameCanvas.currentDialog == null && GameCanvas.subDialog == null;
	}

	// Token: 0x060003C4 RID: 964 RVA: 0x000090B5 File Offset: 0x000072B5
	public static void clearAllPointerEvent()
	{
	}

	// Token: 0x060003C5 RID: 965 RVA: 0x000090B5 File Offset: 0x000072B5
	public void perform(int idAction, object p)
	{
	}

	// Token: 0x060003C6 RID: 966 RVA: 0x000725EC File Offset: 0x000707EC
	public static bool keyMove(int Dir)
	{
		switch (Dir)
		{
		case 0:
		{
			bool flag = GameCanvas.keyMyHold[4] || GameCanvas.keyMyHold[24] || GameCanvas.keyMyHold[34];
			if (flag)
			{
				return true;
			}
			break;
		}
		case 1:
		{
			bool flag2 = GameCanvas.keyMyHold[2] || GameCanvas.keyMyHold[22] || GameCanvas.keyMyHold[32];
			if (flag2)
			{
				return true;
			}
			break;
		}
		case 2:
		{
			bool flag3 = GameCanvas.keyMyHold[6] || GameCanvas.keyMyHold[26] || GameCanvas.keyMyHold[36];
			if (flag3)
			{
				return true;
			}
			break;
		}
		case 3:
		{
			bool flag4 = GameCanvas.keyMyHold[8] || GameCanvas.keyMyHold[28] || GameCanvas.keyMyHold[38];
			if (flag4)
			{
				return true;
			}
			break;
		}
		}
		return false;
	}

	// Token: 0x060003C7 RID: 967 RVA: 0x000726D0 File Offset: 0x000708D0
	public static void ClearkeyMove(int Dir)
	{
		switch (Dir)
		{
		case 0:
			GameCanvas.keyMyHold[4] = false;
			GameCanvas.keyMyHold[24] = false;
			GameCanvas.keyMyHold[34] = false;
			break;
		case 1:
			GameCanvas.keyMyHold[2] = false;
			GameCanvas.keyMyHold[22] = false;
			GameCanvas.keyMyHold[32] = false;
			break;
		case 2:
			GameCanvas.keyMyHold[6] = false;
			GameCanvas.keyMyHold[26] = false;
			GameCanvas.keyMyHold[36] = false;
			break;
		case 3:
			GameCanvas.keyMyHold[8] = false;
			GameCanvas.keyMyHold[28] = false;
			GameCanvas.keyMyHold[38] = false;
			break;
		}
	}

	// Token: 0x060003C8 RID: 968 RVA: 0x0007276C File Offset: 0x0007096C
	public static bool keyActionUni(int action)
	{
		switch (action)
		{
		case 0:
		{
			bool flag = GameCanvas.UseKey(12) || GameCanvas.UseKey(40);
			if (flag)
			{
				return true;
			}
			break;
		}
		case 1:
		{
			bool flag2 = GameCanvas.UseKey(21) || GameCanvas.UseKey(31);
			if (flag2)
			{
				return true;
			}
			break;
		}
		case 2:
		{
			bool flag3 = GameCanvas.UseKey(13) || GameCanvas.UseKey(41);
			if (flag3)
			{
				return true;
			}
			break;
		}
		case 3:
		{
			bool flag4 = GameCanvas.UseKey(23) || GameCanvas.UseKey(33);
			if (flag4)
			{
				return true;
			}
			break;
		}
		case 4:
		{
			bool flag5 = GameCanvas.UseKey(42);
			if (flag5)
			{
				return true;
			}
			break;
		}
		case 5:
		{
			bool flag6 = GameCanvas.UseKey(5) || GameCanvas.UseKey(25) || GameCanvas.UseKey(35);
			if (flag6)
			{
				return true;
			}
			break;
		}
		case 6:
		{
			bool flag7 = GameCanvas.UseKey(20) || GameCanvas.UseKey(43);
			if (flag7)
			{
				return true;
			}
			break;
		}
		case 7:
		{
			bool flag8 = GameCanvas.UseKey(27) || GameCanvas.UseKey(37);
			if (flag8)
			{
				return true;
			}
			break;
		}
		case 8:
		{
			bool flag9 = GameCanvas.UseKey(11) || GameCanvas.UseKey(44);
			if (flag9)
			{
				return true;
			}
			break;
		}
		case 9:
		{
			bool flag10 = GameCanvas.UseKey(29) || GameCanvas.UseKey(39);
			if (flag10)
			{
				return true;
			}
			break;
		}
		case 10:
		{
			bool flag11 = GameCanvas.UseKey(10) || GameCanvas.UseKey(45);
			if (flag11)
			{
				return true;
			}
			break;
		}
		case 11:
		{
			bool flag12 = GameCanvas.UseKey(46);
			if (flag12)
			{
				return true;
			}
			break;
		}
		case 12:
		{
			bool flag13 = GameCanvas.UseKey(47);
			if (flag13)
			{
				return true;
			}
			break;
		}
		case 13:
		{
			bool flag14 = GameCanvas.UseKey(48);
			if (flag14)
			{
				return true;
			}
			break;
		}
		case 14:
		{
			bool flag15 = GameCanvas.UseKey(49);
			if (flag15)
			{
				return true;
			}
			break;
		}
		case 15:
		{
			bool flag16 = GameCanvas.UseKey(50);
			if (flag16)
			{
				return true;
			}
			break;
		}
		case 16:
		{
			bool flag17 = GameCanvas.UseKey(51);
			if (flag17)
			{
				return true;
			}
			break;
		}
		}
		return false;
	}

	// Token: 0x060003C9 RID: 969 RVA: 0x000729E0 File Offset: 0x00070BE0
	public static void ClearActionUni(int action)
	{
		switch (action)
		{
		case 0:
			GameCanvas.clearKeyHold(12);
			GameCanvas.clearKeyHold(40);
			break;
		case 1:
			GameCanvas.clearKeyHold(21);
			GameCanvas.clearKeyHold(31);
			break;
		case 2:
			GameCanvas.clearKeyHold(13);
			GameCanvas.clearKeyHold(41);
			break;
		case 3:
			GameCanvas.clearKeyHold(23);
			GameCanvas.clearKeyHold(33);
			break;
		case 4:
			GameCanvas.clearKeyHold(42);
			break;
		case 5:
			GameCanvas.clearKeyHold(5);
			GameCanvas.clearKeyHold(25);
			GameCanvas.clearKeyHold(35);
			break;
		case 6:
			GameCanvas.clearKeyHold(20);
			GameCanvas.clearKeyHold(43);
			break;
		case 7:
			GameCanvas.clearKeyHold(27);
			GameCanvas.clearKeyHold(37);
			break;
		case 8:
			GameCanvas.clearKeyHold(11);
			GameCanvas.clearKeyHold(44);
			break;
		case 9:
			GameCanvas.clearKeyHold(29);
			GameCanvas.clearKeyHold(39);
			break;
		case 10:
			GameCanvas.clearKeyHold(10);
			GameCanvas.clearKeyHold(45);
			GameCanvas.clearKeyPressed(10);
			GameCanvas.clearKeyPressed(45);
			break;
		case 11:
			GameCanvas.clearKeyHold(46);
			break;
		case 12:
			GameCanvas.clearKeyHold(47);
			break;
		case 13:
			GameCanvas.clearKeyHold(48);
			break;
		case 14:
			GameCanvas.clearKeyHold(49);
			break;
		case 15:
			GameCanvas.clearKeyHold(50);
			break;
		case 16:
			GameCanvas.clearKeyHold(51);
			break;
		}
	}

	// Token: 0x060003CA RID: 970 RVA: 0x00072B6C File Offset: 0x00070D6C
	public static bool UseKey(int value)
	{
		for (int i = 0; i < GameCanvas.keyMyHold.Length; i++)
		{
			bool flag = i == value && (GameCanvas.keyMyHold[i] || GameCanvas.keyMyPressed[i]);
			if (flag)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060003CB RID: 971 RVA: 0x00072BBC File Offset: 0x00070DBC
	public static bool AnyKey()
	{
		for (int i = 0; i < GameCanvas.keyMyHold.Length; i++)
		{
			bool flag = GameCanvas.keyMyHold[i] || GameCanvas.keyMyPressed[i];
			if (flag)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060003CC RID: 972 RVA: 0x00072C04 File Offset: 0x00070E04
	public static sbyte get_Day_Night()
	{
		sbyte result = GameCanvas.DAY;
		int hour = DateTime.Now.Hour;
		bool flag = hour >= 18 || hour < 6;
		if (flag)
		{
			result = GameCanvas.NIGHT;
		}
		return result;
	}

	// Token: 0x060003CD RID: 973 RVA: 0x00072C48 File Offset: 0x00070E48
	public static long getTime()
	{
		return GameCanvas.timeNow;
	}

	// Token: 0x060003CE RID: 974 RVA: 0x00072C60 File Offset: 0x00070E60
	public static bool isTouchAndKey()
	{
		return TField.isQwerty || GameMidlet.isPC || GameScreen.isShowFocusTK;
	}

	// Token: 0x060003CF RID: 975 RVA: 0x00072C94 File Offset: 0x00070E94
	public static bool isTouchNoOrPC()
	{
		return !GameCanvas.isTouch || GameCanvas.isTouchAndKey();
	}

	// Token: 0x060003D0 RID: 976 RVA: 0x00072CC0 File Offset: 0x00070EC0
	public static bool isIos()
	{
		return GameMidlet.DEVICE == 3 || GameMidlet.DEVICE == 6;
	}

	// Token: 0x060003D1 RID: 977 RVA: 0x00072CF0 File Offset: 0x00070EF0
	public static bool isAndroid()
	{
		return GameMidlet.DEVICE == 1 || GameMidlet.DEVICE == 5;
	}

	// Token: 0x060003D2 RID: 978 RVA: 0x00072D20 File Offset: 0x00070F20
	public static bool isDeviceStore()
	{
		return GameMidlet.DEVICE == 4 || GameMidlet.DEVICE == 5 || GameMidlet.DEVICE == 6;
	}

	// Token: 0x060003D3 RID: 979 RVA: 0x00072D58 File Offset: 0x00070F58
	public static bool isDialogOrMenuShow()
	{
		return GameCanvas.currentDialog != null || GameCanvas.subDialog != null || GameCanvas.menuCur.isShowMenu;
	}

	// Token: 0x060003D4 RID: 980 RVA: 0x00072D90 File Offset: 0x00070F90
	public static void dialogDisconect()
	{
		bool flag = GameCanvas.isLoadImage;
		if (!flag)
		{
			bool flag2 = GameMidlet.DEVICE == 2;
			if (flag2)
			{
				GameCanvas.isDisConnect = true;
			}
			else
			{
				string disconnect = T.disconnect;
				bool flag3 = GameCanvas.infoDisConnect != null && GameCanvas.infoDisConnect.Length > 10;
				if (flag3)
				{
					disconnect = GameCanvas.infoDisConnect;
					GameCanvas.infoDisConnect = string.Empty;
				}
				bool flag4 = false;
				mVector mVector = new mVector();
				bool flag5 = GameCanvas.currentScreen != GameCanvas.loginScr && GameCanvas.currentScreen != GameCanvas.loadMapScr;
				if (flag5)
				{
					mVector.addElement(GameScreen.cmdReConnect);
					flag4 = true;
				}
				mVector.addElement(GameCanvas.gameScr.cmdExit);
				bool flag6 = flag4;
				if (flag6)
				{
					GameCanvas.Start_ReConect_DiaLog(disconnect, mVector, false);
				}
				else
				{
					GameCanvas.Start_Normal_DiaLog(disconnect, mVector, false);
				}
			}
		}
	}

	// Token: 0x060003D5 RID: 981 RVA: 0x00072E6C File Offset: 0x0007106C
	public void loadRMSGAME()
	{
		sbyte[] array = CRes.loadRMS("SUB_TYPETOUCH");
		bool flag = array != null;
		if (flag)
		{
			ByteArrayInputStream bis = new ByteArrayInputStream(array);
			DataInputStream dataInputStream = new DataInputStream(bis);
			try
			{
				Interface_Game.typeTouch = dataInputStream.readByte();
				dataInputStream.close();
			}
			catch (Exception)
			{
			}
		}
		bool flag2 = GameCanvas.isSuperLowGraphic;
		if (flag2)
		{
			GameCanvas.lowGraphic = true;
		}
		else
		{
			bool flag3 = GameMidlet.DEVICE == 0;
			if (flag3)
			{
				sbyte[] array2 = CRes.loadRMS("SUB_LOWGRAPHIC");
				bool flag4 = array2 != null;
				if (flag4)
				{
					ByteArrayInputStream bis2 = new ByteArrayInputStream(array2);
					DataInputStream dataInputStream2 = new DataInputStream(bis2);
					try
					{
						GameCanvas.lowGraphic = (dataInputStream2.readByte() != 0);
						dataInputStream2.close();
					}
					catch (Exception)
					{
					}
				}
			}
		}
		sbyte[] array3 = CRes.loadRMS("SUB_OFFBG");
		bool flag5 = array3 != null;
		if (flag5)
		{
			ByteArrayInputStream bis3 = new ByteArrayInputStream(array3);
			DataInputStream dataInputStream3 = new DataInputStream(bis3);
			try
			{
				GameCanvas.isOffBg = (dataInputStream3.readByte() != 0);
				dataInputStream3.close();
			}
			catch (Exception)
			{
			}
		}
		sbyte[] array4 = CRes.loadRMS("Main_isQty");
		bool flag6 = array4 != null;
		if (flag6)
		{
			ByteArrayInputStream bis4 = new ByteArrayInputStream(array4);
			DataInputStream dataInputStream4 = new DataInputStream(bis4);
			try
			{
				TField.isQwerty = (dataInputStream4.readByte() == 1);
				dataInputStream4.close();
			}
			catch (Exception)
			{
			}
		}
		sbyte[] array5 = CRes.loadRMS("MAIN_SOUND");
		bool flag7 = array5 != null;
		if (flag7)
		{
			mSound.isMusic = (array5[0] == 1);
			mSound.isSound = (array5[1] == 1);
		}
		sbyte[] array6 = CRes.loadRMS("SUB_TAITHO");
		bool flag8 = array6 != null;
		if (flag8)
		{
			ByteArrayInputStream bis5 = new ByteArrayInputStream(array6);
			DataInputStream dataInputStream5 = new DataInputStream(bis5);
			try
			{
				GameCanvas.isTaiTho = (dataInputStream5.readByte() == 1);
				dataInputStream5.close();
			}
			catch (Exception)
			{
			}
		}
		sbyte[] array7 = CRes.loadRMS("SUB_SSITEM");
		bool flag9 = array7 != null;
		if (flag9)
		{
			ByteArrayInputStream bis6 = new ByteArrayInputStream(array7);
			DataInputStream dataInputStream6 = new DataInputStream(bis6);
			try
			{
				GameCanvas.isSSItem = dataInputStream6.readByte();
				dataInputStream6.close();
			}
			catch (Exception)
			{
			}
		}
		sbyte[] array8 = CRes.loadRMS("SUB_SPAM");
		bool flag10 = array8 != null;
		if (flag10)
		{
			ByteArrayInputStream bis7 = new ByteArrayInputStream(array8);
			DataInputStream dataInputStream7 = new DataInputStream(bis7);
			try
			{
				GameCanvas.isTypeSpam = dataInputStream7.readByte();
				dataInputStream7.close();
			}
			catch (Exception)
			{
				GameCanvas.isTypeSpam = 0;
			}
		}
	}

	// Token: 0x060003D6 RID: 982 RVA: 0x0007312C File Offset: 0x0007132C
	public static string getTextTime()
	{
		long num = mSystem.currentTimeMillis();
		return ((num / 1000L / 60L / 60L + 7L) % 24L).ToString() + "h " + (num / 1000L / 60L % 60L).ToString() + "'";
	}

	// Token: 0x060003D7 RID: 983 RVA: 0x0007318C File Offset: 0x0007138C
	public static int getHourTime()
	{
		long num = mSystem.currentTimeMillis();
		return (int)((num / 1000L / 60L / 60L + 7L) % 24L);
	}

	// Token: 0x060003D8 RID: 984 RVA: 0x000731BC File Offset: 0x000713BC
	public static bool isLowGraOrWP_PvP()
	{
		return GameCanvas.lowGraphic || (GameMidlet.DEVICE == 4 && (LoadMap.specMap == 2 || LoadMap.specMap == 6));
	}

	// Token: 0x0400057C RID: 1404
	public const string VERSION = "1.2.3";

	// Token: 0x0400057D RID: 1405
	public const string No = "1";

	// Token: 0x0400057E RID: 1406
	public const sbyte ACTION_UNI_TAB_SCREEN = 0;

	// Token: 0x0400057F RID: 1407
	public const sbyte ACTION_UNI_1 = 1;

	// Token: 0x04000580 RID: 1408
	public const sbyte ACTION_UNI_NEXT_FOCUS = 2;

	// Token: 0x04000581 RID: 1409
	public const sbyte ACTION_UNI_3 = 3;

	// Token: 0x04000582 RID: 1410
	public const sbyte ACTION_UNI_QUICK_MENU = 4;

	// Token: 0x04000583 RID: 1411
	public const sbyte ACTION_UNI_5 = 5;

	// Token: 0x04000584 RID: 1412
	public const sbyte ACTION_UNI_CHANGE_SKILL = 6;

	// Token: 0x04000585 RID: 1413
	public const sbyte ACTION_UNI_7 = 7;

	// Token: 0x04000586 RID: 1414
	public const sbyte ACTION_UNI_EVENT = 8;

	// Token: 0x04000587 RID: 1415
	public const sbyte ACTION_UNI_9 = 9;

	// Token: 0x04000588 RID: 1416
	public const sbyte ACTION_UNI_CHAT = 10;

	// Token: 0x04000589 RID: 1417
	public const sbyte ACTION_UNI_INVENTORY = 11;

	// Token: 0x0400058A RID: 1418
	public const sbyte ACTION_UNI_QUEST = 12;

	// Token: 0x0400058B RID: 1419
	public const sbyte ACTION_UNI_INFO = 13;

	// Token: 0x0400058C RID: 1420
	public const sbyte ACTION_UNI_SKILL = 14;

	// Token: 0x0400058D RID: 1421
	public const sbyte ACTION_UNI_FRIEND_LIST = 15;

	// Token: 0x0400058E RID: 1422
	public const sbyte ACTION_UNI_EQUIP = 16;

	// Token: 0x0400058F RID: 1423
	public const sbyte OLD_LEFT = 12;

	// Token: 0x04000590 RID: 1424
	public const sbyte OLD_RIGHT = 13;

	// Token: 0x04000591 RID: 1425
	public const sbyte NEW_LEFT = 40;

	// Token: 0x04000592 RID: 1426
	public const sbyte NEW_RIGHT = 41;

	// Token: 0x04000593 RID: 1427
	public const sbyte NEW_CENTER = 5;

	// Token: 0x04000594 RID: 1428
	public static sbyte Day_Night = 0;

	// Token: 0x04000595 RID: 1429
	public static sbyte language = 0;

	// Token: 0x04000596 RID: 1430
	public static bool lowGraphic = false;

	// Token: 0x04000597 RID: 1431
	public static bool isSuperLowGraphic = false;

	// Token: 0x04000598 RID: 1432
	public new static GameCanvas instance;

	// Token: 0x04000599 RID: 1433
	public static bool[] keyMyPressed = new bool[55];

	// Token: 0x0400059A RID: 1434
	public static bool[] keyMyReleased = new bool[55];

	// Token: 0x0400059B RID: 1435
	public static bool[] keyMyHold = new bool[55];

	// Token: 0x0400059C RID: 1436
	public static bool isMoto;

	// Token: 0x0400059D RID: 1437
	public static bool isBB = false;

	// Token: 0x0400059E RID: 1438
	public static bool isPointerDown = false;

	// Token: 0x0400059F RID: 1439
	public static bool isPointerRelease = false;

	// Token: 0x040005A0 RID: 1440
	public static bool isPointerSelect = false;

	// Token: 0x040005A1 RID: 1441
	public static bool isPointerMove = false;

	// Token: 0x040005A2 RID: 1442
	public static bool isPointerClick = false;

	// Token: 0x040005A3 RID: 1443
	public static bool isPointerEnd = false;

	// Token: 0x040005A4 RID: 1444
	public static bool isSmallScreen = false;

	// Token: 0x040005A5 RID: 1445
	public static bool isOffBg = false;

	// Token: 0x040005A6 RID: 1446
	public static bool isShortH = false;

	// Token: 0x040005A7 RID: 1447
	public static bool isTaiTho = false;

	// Token: 0x040005A8 RID: 1448
	public static bool isTouch;

	// Token: 0x040005A9 RID: 1449
	public static bool isDisConnect = false;

	// Token: 0x040005AA RID: 1450
	public static int px;

	// Token: 0x040005AB RID: 1451
	public static int py;

	// Token: 0x040005AC RID: 1452
	public static int pxLast;

	// Token: 0x040005AD RID: 1453
	public static int pyLast;

	// Token: 0x040005AE RID: 1454
	public static long timeNow = 0L;

	// Token: 0x040005AF RID: 1455
	public static long clockServer = 0L;

	// Token: 0x040005B0 RID: 1456
	public static int hCommand = 25;

	// Token: 0x040005B1 RID: 1457
	public static int hText = 15;

	// Token: 0x040005B2 RID: 1458
	public static int wCommand;

	// Token: 0x040005B3 RID: 1459
	public static int hLoad = 0;

	// Token: 0x040005B4 RID: 1460
	public static int gameTick;

	// Token: 0x040005B5 RID: 1461
	public static int gameTickChia4;

	// Token: 0x040005B6 RID: 1462
	public static int xPlus12;

	// Token: 0x040005B7 RID: 1463
	public static int yPlus12;

	// Token: 0x040005B8 RID: 1464
	public static int tickSelectChar = 0;

	// Token: 0x040005B9 RID: 1465
	public static int keyAsciiPress;

	// Token: 0x040005BA RID: 1466
	public static mVector listPoint;

	// Token: 0x040005BB RID: 1467
	public static sbyte DAY = 0;

	// Token: 0x040005BC RID: 1468
	public static sbyte NIGHT = 1;

	// Token: 0x040005BD RID: 1469
	public mGraphics g = new mGraphics();

	// Token: 0x040005BE RID: 1470
	public static MainScreen currentScreen;

	// Token: 0x040005BF RID: 1471
	public static MainDialog currentDialog;

	// Token: 0x040005C0 RID: 1472
	public static MainDialog subDialog;

	// Token: 0x040005C1 RID: 1473
	public static MainDialog DevilDialog;

	// Token: 0x040005C2 RID: 1474
	public static MainDialog showDialog;

	// Token: 0x040005C3 RID: 1475
	public static MsgDialogEvent EventDialog;

	// Token: 0x040005C4 RID: 1476
	public static MsgDialogTrangTri TrangTriDialog;

	// Token: 0x040005C5 RID: 1477
	public static GameScreen gameScr;

	// Token: 0x040005C6 RID: 1478
	public static LoadMap loadmap;

	// Token: 0x040005C7 RID: 1479
	public static ReadMessenge readMess = new ReadMessenge();

	// Token: 0x040005C8 RID: 1480
	public static LoginScreen loginScr;

	// Token: 0x040005C9 RID: 1481
	public static FristLoginScreen fristLoginScr;

	// Token: 0x040005CA RID: 1482
	public static MapBackGround mapBack;

	// Token: 0x040005CB RID: 1483
	public static MapBackGround mapLogin;

	// Token: 0x040005CC RID: 1484
	public static SaveImageRMS saveImage = new SaveImageRMS();

	// Token: 0x040005CD RID: 1485
	public static LoadMapScreen loadMapScr;

	// Token: 0x040005CE RID: 1486
	public static Menu menuCur = new Menu();

	// Token: 0x040005CF RID: 1487
	public static Menu menu = new Menu();

	// Token: 0x040005D0 RID: 1488
	public static ListChar_Screen listCharScr;

	// Token: 0x040005D1 RID: 1489
	public static TabScreen tabAllScr;

	// Token: 0x040005D2 RID: 1490
	public static TabScreen tabShopScr;

	// Token: 0x040005D3 RID: 1491
	public static TabScreen tabMarketScr;

	// Token: 0x040005D4 RID: 1492
	public static ChatTabScreen chatTabScr;

	// Token: 0x040005D5 RID: 1493
	public static MainEvent eventScr;

	// Token: 0x040005D6 RID: 1494
	public static SaveRms saveRms;

	// Token: 0x040005D7 RID: 1495
	public static TabInventory tabInven;

	// Token: 0x040005D8 RID: 1496
	public static TabInventory tabInvenClan;

	// Token: 0x040005D9 RID: 1497
	public static TabInventory tabInvenMarket;

	// Token: 0x040005DA RID: 1498
	public static UpdateImageScreen updateImageAndroidScr;

	// Token: 0x040005DB RID: 1499
	public static Clan_Screen ClanScr;

	// Token: 0x040005DC RID: 1500
	public static Sudo_Screen SudoScr;

	// Token: 0x040005DD RID: 1501
	public static mVector vecTest = new mVector("GameCanvas.vecTest");

	// Token: 0x040005DE RID: 1502
	private bool isLoadFont;

	// Token: 0x040005DF RID: 1503
	public static string infoDisConnect = string.Empty;

	// Token: 0x040005E0 RID: 1504
	public static string[][] strListServer = new string[][]
	{
		new string[]
		{
			"Chibi",
			"Chibi",
			"Chibi"
		},
		new string[]
		{
			"Global"
		}
	};

	// Token: 0x040005E1 RID: 1505
	public static int IndexServer = 0;

	// Token: 0x040005E2 RID: 1506
	public static int tickAction = 0;

	// Token: 0x040005E3 RID: 1507
	private ScreenBilak bilak;

	// Token: 0x040005E4 RID: 1508
	public static bool istest = false;

	// Token: 0x040005E5 RID: 1509
	public static bool isLoadImage = false;

	// Token: 0x040005E6 RID: 1510
	public static string strIP = string.Empty;

	// Token: 0x040005E7 RID: 1511
	public static int indexdownload = 0;

	// Token: 0x040005E8 RID: 1512
	public static bool isSendChatpopup = false;

	// Token: 0x040005E9 RID: 1513
	public static bool isQuickMenu = false;

	// Token: 0x040005EA RID: 1514
	public static sbyte isSSItem = 0;

	// Token: 0x040005EB RID: 1515
	public static sbyte isTypeSpam = 0;
}
