using System;

// Token: 0x0200006F RID: 111
public class LoginScreen : MainScreen
{
	// Token: 0x060006B5 RID: 1717 RVA: 0x00093540 File Offset: 0x00091740
	public LoginScreen()
	{
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.hShowPaper = 120 + this.hItem + 2;
			this.hItem = 40;
			this.yLechNameServer = 4;
		}
		else
		{
			this.hShowPaper = 85 + this.hItem + 2;
		}
		this.sizeListServer = GameCanvas.strListServer[(int)GameCanvas.language].Length;
		LoginScreen.yBeginPaint = MotherCanvas.hh - this.hShowPaper / 2 + 23;
		this.tfUser = new TField(MotherCanvas.hw - 70, LoginScreen.yBeginPaint + 17, 140);
		this.tfUser.setStringNull(T.tfUserNull);
		this.tfIp = new TField(MotherCanvas.hw - 70, LoginScreen.yBeginPaint + 17 - this.hItem, 140);
		bool flag = CRes.loadRMS("MAIN_ip_last") != null;
		if (flag)
		{
			GameCanvas.strIP = SaveRms.loadIpLast().Trim();
			this.tfIp.setText(GameCanvas.strIP);
		}
		else
		{
			this.tfIp.setText("192.168.1.71");
		}
		this.tfPass = new TField(MotherCanvas.hw - 70, LoginScreen.yBeginPaint + 17 + this.hItem, 140);
		this.tfPass.setIputType(TField.INPUT_TYPE_PASSWORD);
		this.tfPass.setStringNull(T.tfPassNull);
		this.cmdFristLogin = new iCommand(T.newGame, 7, this);
		this.cmdLogin = new iCommand(T.login, 0, this);
		this.cmdMenu = new iCommand(T.menu, 1, this);
		this.cmdRegister = new iCommand(T.register, 3, this);
		this.cmdExitGame = new iCommand(T.exit, 4, this);
		this.cmdLowGraphic = new iCommand(T.on + T.lowGraphic, 6, this);
		this.cmdLastLogin = new iCommand(T.loadGame, 12, this);
		LoginScreen.cmdSound = new iCommand(T.amthanh, 13, this);
		this.cmdHelp = new iCommand(T.hotro, 10, this);
		this.cmdDelRMS = new iCommand(T.delRMS, 15, this);
		this.cmdOffBg = new iCommand(T.offBg, 18, this);
		bool lowGraphic = GameCanvas.lowGraphic;
		if (lowGraphic)
		{
			this.cmdLowGraphic.caption = T.off + T.lowGraphic;
		}
		this.cmdTaitho = new iCommand(T.on + T.taitho, 19, this);
		bool isTaiTho = GameCanvas.isTaiTho;
		if (isTaiTho)
		{
			this.cmdLowGraphic.caption = T.off + T.taitho;
		}
		this.cmdLogin = AvMain.setPosCMD(this.cmdLogin, 0);
		this.cmdRegister = AvMain.setPosCMD(this.cmdRegister, 0);
		this.cmdMenu = AvMain.setPosCMD(this.cmdMenu, 1);
		bool isTouch2 = GameCanvas.isTouch;
		if (isTouch2)
		{
			bool isTaiTho2 = GameCanvas.isTaiTho;
			if (isTaiTho2)
			{
				this.cmdMenu.setPos(30, MotherCanvas.h - 15, AvMain.fraIconMenu, string.Empty);
				this.cmdHelp.setPos(MotherCanvas.w - 30, MotherCanvas.h - 15, AvMain.fraIconHome, string.Empty);
			}
			else
			{
				this.cmdMenu.setPos(15, MotherCanvas.h - 15, AvMain.fraIconMenu, string.Empty);
				this.cmdHelp.setPos(MotherCanvas.w - 15, MotherCanvas.h - 15, AvMain.fraIconHome, string.Empty);
			}
			this.right = this.cmdHelp;
		}
		bool flag2 = GameCanvas.isTouchNoOrPC();
		if (flag2)
		{
			this.tfUser.setFocus(true);
		}
		bool isTouch3 = GameCanvas.isTouch;
		if (isTouch3)
		{
			this.cmdLogin.setPos(MotherCanvas.hw, LoginScreen.yBeginPaint + this.hShowPaper, AvMain.fraBtLogin, string.Empty);
			this.cmdLogin.isPlayframe = true;
			this.cmdRegister.setPosXY(MotherCanvas.hw, LoginScreen.yBeginPaint + this.hShowPaper - iCommand.hButtonCmdNor + 8);
		}
		this.left = this.cmdMenu;
		this.menuCMD = this.cmdMenu;
		this.setCmdClear();
		sbyte[] array = GameMidlet.loadRMS("Main_IPNEW");
		bool flag3 = array != null;
		if (flag3)
		{
			try
			{
				ByteArrayInputStream bis = new ByteArrayInputStream(array);
				DataInputStream dataInputStream = new DataInputStream(bis);
				GameCanvas.strIP = dataInputStream.readUTF();
				dataInputStream.close();
			}
			catch (Exception)
			{
			}
		}
		bool flag4 = LoginScreen.yPaintLogo == 0;
		if (flag4)
		{
			LoginScreen.yPaintLogo = LoginScreen.hLogo;
		}
	}

	// Token: 0x060006B6 RID: 1718 RVA: 0x0000A830 File Offset: 0x00008A30
	public override void Show(MainScreen last)
	{
		this.Show();
	}

	// Token: 0x060006B7 RID: 1719 RVA: 0x000092E5 File Offset: 0x000074E5
	public override void setxyPlus12()
	{
		GameCanvas.xPlus12 = 2;
		GameCanvas.yPlus12 = 2;
	}

	// Token: 0x060006B8 RID: 1720 RVA: 0x00093A10 File Offset: 0x00091C10
	public override void Show()
	{
		bool flag = GameScreen.vecHelp != null;
		if (flag)
		{
			GameScreen.vecHelp.removeAllElements();
		}
		bool flag2 = GameCanvas.mapBack == null;
		if (flag2)
		{
			GameCanvas.mapBack = new MapBackGround();
		}
		GameCanvas.mapBack.setBGLogin();
		GameScreen.player = null;
		Session_ME.gI().close();
		this.type = 0;
		this.setCmd();
		this.wShowPaper = 5;
		bool flag3 = GameCanvas.currentScreen != null && GameCanvas.currentScreen != GameCanvas.loginScr && GameCanvas.currentScreen != GameCanvas.fristLoginScr;
		if (flag3)
		{
			LoginScreen.beginShowChar();
		}
		LoginScreen.loadCharPart();
		base.Show();
		mSound.playMus(3, mSound.volumeMusic, true);
		LoginScreen.isNewShow = true;
	}

	// Token: 0x060006B9 RID: 1721 RVA: 0x0000A83A File Offset: 0x00008A3A
	public static void beginShowChar()
	{
		LoginScreen.vecOBJ.removeAllElements();
		LoginScreen.vecEff.removeAllElements();
	}

	// Token: 0x060006BA RID: 1722 RVA: 0x000090B5 File Offset: 0x000072B5
	public static void loadCharPart()
	{
	}

	// Token: 0x060006BB RID: 1723 RVA: 0x00093AD4 File Offset: 0x00091CD4
	public void setCmd()
	{
		bool flag = this.type == 0;
		if (flag)
		{
			this.center = this.cmdLogin;
		}
		else
		{
			this.center = this.cmdRegister;
		}
	}

	// Token: 0x060006BC RID: 1724 RVA: 0x00093B10 File Offset: 0x00091D10
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
		{
			bool istest = GameCanvas.istest;
			if (istest)
			{
				GameCanvas.strIP = this.tfIp.getText().Trim();
				GameCanvas.saveRms.saveIpLast(GameCanvas.strIP);
				mSystem.outz("connect ip " + GameCanvas.strIP);
			}
			bool flag = this.tfUser.getText().Trim().Length > 0 && this.tfPass.getText().Trim().Length > 0;
			if (flag)
			{
				ListChar_Screen.IndexCharSelected = -1;
				mSystem.outz("6");
				this.doLogin(true, 0, this.tfUser.getText(), this.tfPass.getText());
			}
			else
			{
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.checkRegister1);
			}
			break;
		}
		case 1:
		{
			mVector mVector = new mVector();
			SaveRms.userLast = string.Empty;
			GameCanvas.saveRms.loadUserLast();
			bool flag2 = SaveRms.userLast.Length > 0 && CRes.loadRMS("MAIN_user_pass") == null;
			if (flag2)
			{
				this.cmdLastLogin.caption = T.loadGame + " " + SaveRms.userLast;
				mVector.addElement(this.cmdLastLogin);
			}
			mVector.addElement(this.cmdFristLogin);
			bool flag3 = GameMidlet.DEVICE == 0 && !GameCanvas.isSuperLowGraphic;
			if (flag3)
			{
				mVector.addElement(this.cmdLowGraphic);
			}
			bool flag4 = !GameCanvas.isTouch;
			if (flag4)
			{
				mVector.addElement(this.cmdHelp);
			}
			mVector.addElement(LoginScreen.cmdSound);
			this.cmdOffBg.caption = T.on + T.offBg;
			bool flag5 = !GameCanvas.isOffBg;
			if (flag5)
			{
				this.cmdOffBg.caption = T.off + T.offBg;
			}
			mVector.addElement(this.cmdOffBg);
			bool flag6 = GameMidlet.DEVICE == 2 || GameMidlet.DEVICE == 4;
			if (flag6)
			{
				mVector.addElement(this.cmdDelRMS);
			}
			else
			{
				bool isTouch = GameCanvas.isTouch;
				if (isTouch)
				{
					this.cmdTaitho.caption = T.on + T.taitho;
					bool isTaiTho = GameCanvas.isTaiTho;
					if (isTaiTho)
					{
						this.cmdTaitho.caption = T.off + T.taitho;
					}
					mVector.addElement(this.cmdTaitho);
				}
			}
			bool flag7 = GameMidlet.DEVICE == 0 || GameCanvas.isAndroid();
			if (flag7)
			{
				mVector.addElement(this.cmdExitGame);
			}
			bool isIP_Local = GameScreen.isIP_Local;
			if (isIP_Local)
			{
				mVector.addElement(new iCommand("NHAP IP", 8, this));
				mVector.addElement(new iCommand("VŨ ĐỆ 146 port 23", 17, this));
			}
			bool flag8 = GameCanvas.strIP.Length > 0;
			if (flag8)
			{
				mVector.addElement(new iCommand("XOA IP", 14, this));
			}
			GameCanvas.menu.startAt(mVector, 0, T.menu);
			break;
		}
		case 2:
		{
			bool flag9 = this.type == 0;
			if (flag9)
			{
				this.type = 1;
			}
			else
			{
				this.type = 0;
			}
			this.setCmd();
			break;
		}
		case 3:
		{
			bool flag10 = this.tfUser.getText().Trim().Length > 0 && this.tfPass.getText().Trim().Length > 0;
			if (flag10)
			{
				GameCanvas.connect();
				GlobalService.gI().Register(this.tfUser.getText(), this.tfPass.getText());
				GameCanvas.clearAll();
			}
			else
			{
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.checkRegister1);
			}
			break;
		}
		case 4:
			GameCanvas.Start_Normal_DiaLog(T.hoiThoat, new iCommand(T.exit, 5, this), true);
			break;
		case 5:
			GameMidlet.instance.destroy();
			break;
		case 6:
		{
			GameCanvas.lowGraphic = !GameCanvas.lowGraphic;
			this.cmdLowGraphic.caption = T.on + T.lowGraphic;
			bool lowGraphic = GameCanvas.lowGraphic;
			if (lowGraphic)
			{
				this.cmdLowGraphic.caption = T.off + T.lowGraphic;
			}
			try
			{
				CRes.saveRMS("SUB_LOWGRAPHIC", new sbyte[]
				{
					GameCanvas.lowGraphic ? 1 : 0
				});
			}
			catch (Exception)
			{
			}
			LoadImageStatic.LoadLowGraphic();
			break;
		}
		case 7:
			ListChar_Screen.IndexCharSelected = -1;
			GameCanvas.loginScr.doLogin(true, 1, string.Empty, string.Empty);
			break;
		case 8:
			this.input = new InputDialog();
			this.input.setinfo("NHAP IP", new iCommand("OK", 9, this), false, "IP-PORT");
			GameCanvas.currentDialog = this.input;
			break;
		case 9:
			GameCanvas.strIP = this.input.tfInput.getText().Trim();
			this.saveIP_New();
			break;
		case 10:
		{
			mVector mVector2 = new mVector();
			mVector2.addElement(new iCommand(T.home, 11, 0, this));
			mVector2.addElement(new iCommand(T.forum, 11, 1, this));
			mVector2.addElement(new iCommand(T.fanpage, 11, 4, this));
			mVector2.addElement(new iCommand(T.changePassword, 11, 2, this));
			mVector2.addElement(new iCommand(T.getPassword, 11, 3, this));
			bool flag11 = GameMidlet.DEVICE == 6;
			if (flag11)
			{
				mVector2.addElement(new iCommand(T.rate, 11, 5, this));
			}
			GameCanvas.menu.startAt(mVector2, 2, T.hotro);
			break;
		}
		case 11:
		{
			string empty = string.Empty;
			bool flag12 = GameCanvas.language == 1;
			if (flag12)
			{
				switch (subIndex)
				{
				}
			}
			else
			{
				switch (subIndex)
				{
				}
			}
			break;
		}
		case 12:
			GameCanvas.fristLoginScr.cmdBegin.perform();
			break;
		case 13:
		{
			MsgSound msgSound = new MsgSound();
			msgSound.setinfoSound();
			GameCanvas.Start_Current_Dialog(msgSound);
			break;
		}
		case 14:
			GameCanvas.strIP = string.Empty;
			GameMidlet.delRMS("Main_IPNEW");
			break;
		case 15:
			GameCanvas.Start_Normal_DiaLog(T.closeDelRMS, new iCommand(T.del, 16, this), true);
			break;
		case 16:
		{
			LoginScreen.isCheckData = false;
			GameMidlet.delAllRms();
			GameCanvas.end_Dialog();
			bool flag13 = GameMidlet.DEVICE == 2;
			if (flag13)
			{
				GameCanvas.updateImageAndroidScr = new UpdateImageScreen();
				GameCanvas.updateImageAndroidScr.Show();
			}
			else
			{
				this.setData();
			}
			break;
		}
		case 17:
			GameCanvas.strIP = "192.168.1.146-20123";
			this.saveIP_New();
			break;
		case 18:
			GameCanvas.isOffBg = !GameCanvas.isOffBg;
			try
			{
				CRes.saveRMS("SUB_OFFBG", new sbyte[]
				{
					GameCanvas.isOffBg ? 1 : 0
				});
			}
			catch (Exception)
			{
			}
			break;
		case 19:
			GameCanvas.isTaiTho = !GameCanvas.isTaiTho;
			try
			{
				CRes.saveRMS("SUB_TAITHO", new sbyte[]
				{
					GameCanvas.isTaiTho ? 1 : 0
				});
			}
			catch (Exception)
			{
			}
			GameScreen.interfaceGame.setPosMenu_TaiTho();
			break;
		}
		base.commandPointer(index, subIndex);
	}

	// Token: 0x060006BD RID: 1725 RVA: 0x00094368 File Offset: 0x00092568
	private void saveIP_New()
	{
		bool flag = GameCanvas.strIP.Length == 0;
		if (flag)
		{
			GameMidlet.delRMS("Main_IPNEW");
		}
		else
		{
			string[] array = mFont.split(GameCanvas.strIP, "-");
			GameCanvas.Start_Normal_Only_CmdClose_DiaLog("IP:" + array[0] + "\nPORT:" + array[1]);
			ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
			DataOutputStream dataOutputStream = new DataOutputStream(byteArrayOutputStream);
			try
			{
				dataOutputStream.writeUTF(GameCanvas.strIP);
				GameMidlet.saveRMS("Main_IPNEW", byteArrayOutputStream.toByteArray());
				dataOutputStream.close();
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x060006BE RID: 1726 RVA: 0x0009440C File Offset: 0x0009260C
	public override void paint(mGraphics g)
	{
		try
		{
			bool flag = GameCanvas.mapBack != null;
			if (flag)
			{
				GameCanvas.mapBack.paintBgLogin(g);
				GameCanvas.mapBack.paintObjFristLogin(g);
				GameCanvas.mapBack.paintObjLastLogin(g);
			}
		}
		catch (Exception)
		{
		}
		LoginScreen.paintShowchar(g);
		base.paintPaper(g, MotherCanvas.hw - this.wShowPaper / 2, LoginScreen.yBeginPaint, this.wShowPaper, this.hShowPaper, this.maxWShow, (int)AvMain.PAPER_NORMAL);
		GameCanvas.resetTrans(g);
		LoginScreen.paintLogo(g, MotherCanvas.hw);
		mFont.tahoma_7_black.drawString(g, "Ver: 1.2.3", MotherCanvas.w - 2, 2 + GameScreen.h12plus, 1);
		mFont.tahoma_7_black.drawString(g, "No: 1", MotherCanvas.w - 2, 4 + GameScreen.h12plus + GameCanvas.hText / 2, 1);
		GameCanvas.resetTrans(g);
		g.setClip(MotherCanvas.hw - this.wShowPaper / 2, 0, this.wShowPaper, MotherCanvas.h);
		g.saveCanvas();
		g.ClipRec(MotherCanvas.hw - this.wShowPaper / 2, 0, this.wShowPaper, MotherCanvas.h);
		bool istest = GameCanvas.istest;
		if (istest)
		{
			this.tfIp.paint(g, MotherCanvas.hw - this.wShowPaper / 2 < this.tfUser.x);
			g.restoreCanvas();
			g.setClip(MotherCanvas.hw - this.wShowPaper / 2, 0, this.wShowPaper, MotherCanvas.h);
			g.saveCanvas();
			g.ClipRec(MotherCanvas.hw - this.wShowPaper / 2, 0, this.wShowPaper, MotherCanvas.h);
		}
		this.tfUser.paint(g, MotherCanvas.hw - this.wShowPaper / 2 < this.tfUser.x);
		g.restoreCanvas();
		g.setClip(MotherCanvas.hw - this.wShowPaper / 2, 0, this.wShowPaper, MotherCanvas.h);
		g.saveCanvas();
		g.ClipRec(MotherCanvas.hw - this.wShowPaper / 2, 0, this.wShowPaper, MotherCanvas.h);
		this.tfPass.paint(g, MotherCanvas.hw - this.wShowPaper / 2 < this.tfPass.x);
		g.restoreCanvas();
		GameCanvas.resetTrans(g);
		this.paintListServer(g);
		bool flag2 = this.idSelect != 2 && this.idSelect != -2;
		if (flag2)
		{
			bool flag3 = GameCanvas.isTouch && !GameCanvas.lowGraphic;
			if (flag3)
			{
				AvMain.fraBtBanhlai.drawFrame(LoginScreen.frameBanhlai, this.cmdLogin.xCmd, this.cmdLogin.yCmd, 0, 3, g);
			}
			base.paint(g);
		}
	}

	// Token: 0x060006BF RID: 1727 RVA: 0x000946EC File Offset: 0x000928EC
	public static void paintLogo(mGraphics g, int x)
	{
		bool flag = AvMain.imgLg == null;
		if (flag)
		{
			LoadImageStatic.loadImageLanguage();
		}
		g.drawImage(AvMain.imgLg, x, LoginScreen.yPaintLogo, 3);
		bool flag2 = GameCanvas.language == 0 && !GameCanvas.lowGraphic && !GameCanvas.isDeviceStore() && GameCanvas.IndexServer <= 2;
		if (flag2)
		{
			bool flag3 = MotherCanvas.h >= 240;
			if (flag3)
			{
				AvMain.fraIconServer.drawFrame(GameCanvas.IndexServer, x + 35, LoginScreen.yPaintLogo + 20, 0, 3, g);
			}
			else
			{
				Interface_Game.fraBorderNoti.drawFrame(GameCanvas.IndexServer + 1, x + 34, LoginScreen.yPaintLogo + 17, 0, 3, g);
			}
		}
	}

	// Token: 0x060006C0 RID: 1728 RVA: 0x000947A4 File Offset: 0x000929A4
	public static void updateYPaintLogo(int y)
	{
		bool flag = LoginScreen.yPaintLogo > y;
		if (flag)
		{
			LoginScreen.yPaintLogo -= 2;
			bool flag2 = LoginScreen.yPaintLogo < y;
			if (flag2)
			{
				LoginScreen.yPaintLogo = y;
			}
		}
		else
		{
			bool flag3 = LoginScreen.yPaintLogo < y;
			if (flag3)
			{
				LoginScreen.yPaintLogo += 2;
				bool flag4 = LoginScreen.yPaintLogo > y;
				if (flag4)
				{
					LoginScreen.yPaintLogo = y;
				}
			}
		}
	}

	// Token: 0x060006C1 RID: 1729 RVA: 0x00094810 File Offset: 0x00092A10
	public void paintListServer(mGraphics g)
	{
		bool flag = this.sizeListServer > 2 && LoginScreen.dy == 0;
		if (flag)
		{
			LoginScreen.dy = -15 * this.sizeListServer;
		}
		bool flag2 = this.idSelect != 2;
		if (flag2)
		{
			AvMain.paintRect(g, this.tfPass.x, this.tfPass.y + this.hItem, this.tfPass.width, this.tfPass.height, 0, (this.idSelect != -2) ? 1 : 0);
			mFont.tahoma_7b_black.drawString(g, T.server + " " + GameCanvas.strListServer[(int)GameCanvas.language][GameCanvas.IndexServer], this.tfPass.x + 4, this.tfPass.y + this.tfPass.height - 16 + this.hItem - this.yLechNameServer, 0);
			g.drawRegion(AvMain.imgArrowListServer, 0, ((this.idSelect != -2) ? 1 : 0) * 10, 15, 10, 0, (float)(this.tfPass.x + this.tfPass.width - 12), (float)(this.tfPass.y + this.hItem + this.tfPass.height / 2), 3);
		}
		else
		{
			AvMain.paintRect(g, this.tfPass.x, this.tfPass.y + this.hItem + LoginScreen.dy, this.tfPass.width, this.tfPass.height * this.sizeListServer - 1, 0, 0);
			for (int i = 0; i < this.sizeListServer; i++)
			{
				bool flag3 = i > 0;
				if (flag3)
				{
					g.setColor(12609544);
					g.drawRect(this.tfPass.x + 6, this.tfPass.y + this.hItem + i * this.tfPass.height - 1 + LoginScreen.dy, this.tfPass.width - 12, 1);
				}
				bool flag4 = GameCanvas.isTouchNoOrPC() && i == GameCanvas.IndexServer;
				if (flag4)
				{
					g.setColor(14194752);
					g.fillRect(this.tfPass.x + 3, this.tfPass.y + this.hItem + GameCanvas.IndexServer * this.tfPass.height + 3 + LoginScreen.dy, this.tfPass.width - 4, this.tfPass.height - 6);
				}
				string text = T.server + " " + GameCanvas.strListServer[(int)GameCanvas.language][i];
				bool flag5 = i > 0 && i == GameCanvas.strListServer[(int)GameCanvas.language].Length - 1;
				if (flag5)
				{
					int width = mFont.tahoma_7b_black.getWidth(text);
					AvMain.fraNew.drawFrame(GameCanvas.gameTick / 5 % AvMain.fraNew.nFrame, this.tfPass.x + 4 + width + 16, this.tfPass.y + this.tfPass.height - 16 + this.hItem + i * this.tfPass.height - this.yLechNameServer + 4 + LoginScreen.dy, 0, 3, g);
				}
				mFont.tahoma_7b_black.drawString(g, text, this.tfPass.x + 4, this.tfPass.y + this.tfPass.height - 16 + this.hItem + i * this.tfPass.height - this.yLechNameServer + LoginScreen.dy, 0);
			}
		}
	}

	// Token: 0x060006C2 RID: 1730 RVA: 0x00094BD0 File Offset: 0x00092DD0
	public static void paintShowchar(mGraphics g)
	{
		CRes.quickSort(LoginScreen.vecOBJ);
		for (int i = 0; i < LoginScreen.vecOBJ.size(); i++)
		{
			MainObject mainObject = (MainObject)LoginScreen.vecOBJ.elementAt(i);
			mainObject.paint(g);
			mainObject.ySort = mainObject.y;
		}
		for (int j = 0; j < LoginScreen.vecEff.size(); j++)
		{
			MainEffect mainEffect = (MainEffect)LoginScreen.vecEff.elementAt(j);
			mainEffect.paint(g);
		}
	}

	// Token: 0x060006C3 RID: 1731 RVA: 0x00094C64 File Offset: 0x00092E64
	public static void updateCharShow()
	{
		for (int i = 0; i < LoginScreen.vecOBJ.size(); i++)
		{
			MainObject mainObject = (MainObject)LoginScreen.vecOBJ.elementAt(i);
			mainObject.updateLoginShow();
			bool isRemove = mainObject.isRemove;
			if (isRemove)
			{
				LoginScreen.vecOBJ.removeElement(mainObject);
				i--;
			}
		}
		for (int j = 0; j < LoginScreen.vecEff.size(); j++)
		{
			MainEffect mainEffect = (MainEffect)LoginScreen.vecEff.elementAt(j);
			mainEffect.update();
			bool isStop = mainEffect.isStop;
			if (isStop)
			{
				LoginScreen.vecEff.removeElement(mainEffect);
				j--;
			}
		}
		bool flag = CRes.random(20) == 0 && LoginScreen.vecOBJ.size() < MotherCanvas.w / 80;
		if (flag)
		{
			LoginScreen.addObjShow(false);
		}
		bool flag2 = LoginScreen.isNewShow;
		if (flag2)
		{
			LoginScreen.isNewShow = false;
			for (int k = 0; k < 3; k++)
			{
				LoginScreen.addObjShow(true);
			}
		}
	}

	// Token: 0x060006C4 RID: 1732 RVA: 0x00094D80 File Offset: 0x00092F80
	public override void update()
	{
		LoginScreen.updateYPaintLogo(LoginScreen.yBeginPaint / 2);
		LoginScreen.updateBanhLai();
		bool flag = this.wShowPaper < this.maxWShow;
		if (flag)
		{
			this.wShowPaper += this.vShow;
			bool flag2 = this.wShowPaper > this.maxWShow;
			if (flag2)
			{
				this.wShowPaper = this.maxWShow;
				this.vShow = 15;
			}
			bool flag3 = this.vShow < 100;
			if (flag3)
			{
				this.vShow += 15;
				bool flag4 = this.vShow > 100;
				if (flag4)
				{
					this.vShow = 100;
				}
			}
		}
		bool flag5 = GameCanvas.mapBack != null;
		if (flag5)
		{
			GameCanvas.mapBack.updateCloudLogin();
		}
		this.tfIp.update();
		this.tfUser.update();
		this.tfPass.update();
		LoginScreen.updateCharShow();
		bool flag6 = MsgDialog.isAuroReconect && GameCanvas.gameTick % 100 == 0 && (GameCanvas.currentDialog == null || GameCanvas.currentDialog.type != 9);
		if (flag6)
		{
			string info = T.disconnect;
			bool flag7 = GameCanvas.infoDisConnect != null && GameCanvas.infoDisConnect.Length > 10;
			if (flag7)
			{
				info = GameCanvas.infoDisConnect;
				GameCanvas.infoDisConnect = string.Empty;
			}
			mVector mVector = new mVector();
			mVector.addElement(GameScreen.cmdReConnect);
			mVector.addElement(GameCanvas.gameScr.cmdExit);
			mSystem.outz("start here");
			GameCanvas.Start_ReConect_DiaLog(info, mVector, false);
		}
	}

	// Token: 0x060006C5 RID: 1733 RVA: 0x00094F18 File Offset: 0x00093118
	public static void updateBanhLai()
	{
		int num = CRes.random(20);
		bool flag = LoginScreen.tickBanhLai < 40;
		if (flag)
		{
			LoginScreen.tickBanhLai++;
			bool flag2 = LoginScreen.tickBanhLai == 40;
			if (flag2)
			{
				bool flag3 = LoginScreen.frameBanhlai != 1;
				if (flag3)
				{
					LoginScreen.frameBanhlai = 1;
				}
				LoginScreen.tickBanhLai = 0;
			}
		}
		bool flag4 = num == 0;
		if (flag4)
		{
			bool flag5 = LoginScreen.frameBanhlai == 0 || LoginScreen.frameBanhlai == 2;
			if (flag5)
			{
				LoginScreen.frameBanhlai = 1;
			}
			else
			{
				bool flag6 = CRes.random(2) == 0;
				if (flag6)
				{
					LoginScreen.frameBanhlai = 0;
				}
				else
				{
					LoginScreen.frameBanhlai = 2;
				}
			}
			LoginScreen.tickBanhLai = 0;
		}
	}

	// Token: 0x060006C6 RID: 1734 RVA: 0x00094FCC File Offset: 0x000931CC
	public override void updatekey()
	{
		bool flag = this.idSelect == -2;
		if (flag)
		{
			bool flag2 = GameCanvas.keyMyHold[5];
			if (flag2)
			{
				this.idSelect = 2;
				GameCanvas.clearKeyPressed(5);
				GameCanvas.clearKeyHold(5);
			}
		}
		else
		{
			bool flag3 = this.idSelect == 2 && GameCanvas.keyMyHold[5];
			if (flag3)
			{
				this.idSelect = -2;
				GameCanvas.clearKeyPressed(5);
				GameCanvas.clearKeyHold(5);
			}
		}
		bool flag4 = GameCanvas.keyMyHold[8];
		if (flag4)
		{
			bool flag5 = this.idSelect == 2;
			if (flag5)
			{
				bool flag6 = GameCanvas.IndexServer < this.sizeListServer - 1;
				if (flag6)
				{
					this.setIndexServer(GameCanvas.IndexServer + 1);
				}
			}
			else
			{
				bool flag7 = this.idSelect == -2;
				if (flag7)
				{
					bool flag8 = GameCanvas.isTouchNoOrPC();
					if (flag8)
					{
						this.tfUser.setFocus(true);
					}
					this.tfPass.setFocus(false);
					this.idSelect = 0;
				}
				else
				{
					bool flag9 = this.tfUser.isFocused();
					if (flag9)
					{
						this.tfUser.setFocus(false);
						bool flag10 = GameCanvas.isTouchNoOrPC();
						if (flag10)
						{
							this.tfPass.setFocus(true);
						}
					}
					else
					{
						bool flag11 = this.tfPass.isFocused();
						if (flag11)
						{
							this.tfUser.setFocus(false);
							this.tfPass.setFocus(false);
							this.idSelect = -2;
						}
					}
				}
			}
			GameCanvas.clearKeyHold(8);
			this.setCmdClear();
		}
		else
		{
			bool flag12 = GameCanvas.keyMyHold[2];
			if (flag12)
			{
				bool flag13 = this.idSelect == 2;
				if (flag13)
				{
					bool flag14 = GameCanvas.IndexServer > 0;
					if (flag14)
					{
						this.setIndexServer(GameCanvas.IndexServer - 1);
					}
				}
				else
				{
					bool flag15 = this.idSelect == -2;
					if (flag15)
					{
						this.tfUser.setFocus(false);
						bool flag16 = GameCanvas.isTouchNoOrPC();
						if (flag16)
						{
							this.tfPass.setFocus(true);
						}
						this.idSelect = 0;
					}
					else
					{
						bool flag17 = this.tfUser.isFocused();
						if (flag17)
						{
							this.tfUser.setFocus(false);
							this.tfPass.setFocus(false);
							this.idSelect = -2;
						}
						else
						{
							bool flag18 = this.tfPass.isFocused();
							if (flag18)
							{
								bool flag19 = GameCanvas.isTouchNoOrPC();
								if (flag19)
								{
									this.tfUser.setFocus(true);
								}
								this.tfPass.setFocus(false);
							}
						}
					}
				}
				GameCanvas.clearKeyHold(2);
				this.setCmdClear();
			}
		}
		base.updatekey();
		this.updatekeyPC();
	}

	// Token: 0x060006C7 RID: 1735 RVA: 0x00095264 File Offset: 0x00093464
	public override void updatePointer()
	{
		bool flag = this.idSelect == 2;
		if (flag)
		{
			for (int i = 0; i < this.sizeListServer; i++)
			{
				bool flag2 = GameCanvas.isPointSelect(this.tfPass.x, this.tfPass.y + this.hItem + i * this.tfPass.height + LoginScreen.dy, this.tfPass.width, this.tfPass.height);
				if (flag2)
				{
					this.setIndexServer(i);
					this.idSelect = -1;
					GameCanvas.isPointerSelect = false;
				}
			}
			bool flag3 = GameCanvas.isPointSelect(0, 0, MotherCanvas.w, MotherCanvas.h);
			if (flag3)
			{
				this.idSelect = -1;
				GameCanvas.isPointerSelect = false;
			}
		}
		else
		{
			bool flag4 = GameCanvas.isPointSelect(this.tfPass.x, this.tfPass.y + this.hItem, this.tfPass.width, this.tfPass.height);
			if (flag4)
			{
				this.idSelect = 2;
				GameCanvas.isPointerSelect = false;
			}
		}
		base.updatePointer();
		this.tfUser.updatePointer();
		this.tfIp.updatePointer();
		this.tfPass.updatePointer();
	}

	// Token: 0x060006C8 RID: 1736 RVA: 0x000953A4 File Offset: 0x000935A4
	public void setIndexServer(int index)
	{
		bool flag = index >= 0 && index < this.sizeListServer;
		if (flag)
		{
			GameCanvas.IndexServer = index;
			bool flag2 = Session_ME.gI().isConnected();
			if (flag2)
			{
				Session_ME.gI().close();
			}
		}
	}

	// Token: 0x060006C9 RID: 1737 RVA: 0x000953EC File Offset: 0x000935EC
	public void doLogin(bool isGetData, sbyte typeLogin, string user, string pass)
	{
		GameCanvas.connect();
		if (isGetData)
		{
			this.setData();
		}
		bool flag = !LoginScreen.isCheckData;
		if (flag)
		{
			GlobalService.gI().CheckVersion();
			GameCanvas.Start_Waiting_Connect_DiaLog(T.checkVersion, false);
		}
		else
		{
			GlobalService.gI().Login(user, pass, typeLogin);
			GameCanvas.Start_Waiting_Connect_DiaLog(T.doingLogin, true);
			bool flag2 = typeLogin >= 0;
			if (flag2)
			{
				Player.StepAutoRe = 3;
			}
		}
		bool flag3 = GameMidlet.DEVICE == 4;
		if (flag3)
		{
			ObjectData.checkDelHash(ObjectData.HashImageCharPart, 120, true);
		}
	}

	// Token: 0x060006CA RID: 1738 RVA: 0x00095484 File Offset: 0x00093684
	public override void keyPress(int keyCode)
	{
		bool flag = this.tfUser.isFocused();
		if (flag)
		{
			this.tfUser.keyPressed(keyCode);
		}
		else
		{
			bool flag2 = this.tfPass.isFocused();
			if (flag2)
			{
				this.tfPass.keyPressed(keyCode);
			}
		}
	}

	// Token: 0x060006CB RID: 1739 RVA: 0x000954D0 File Offset: 0x000936D0
	public void setData()
	{
		GlobalService.gI().get_DATA(4);
		GlobalService.gI().get_DATA(10);
		GlobalService.gI().get_DATA(8);
		GlobalService.gI().get_DATA(21);
		GlobalService.gI().get_DATA(30);
		bool flag = !GlobalService.isGetKichAn;
		if (flag)
		{
			GlobalService.gI().get_DATA(26);
		}
		bool flag2 = !GlobalService.isGetMaterial;
		if (flag2)
		{
			GlobalService.gI().get_DATA(11);
		}
		bool flag3 = LoadMap.mSea == null;
		if (flag3)
		{
			GlobalService.gI().get_DATA(13);
		}
		bool flag4 = ScreenUpgrade.mItemUpgrade == null;
		if (flag4)
		{
			GlobalService.gI().get_DATA(19);
		}
		bool flag5 = GameCanvas.clockServer == 0L;
		if (flag5)
		{
			GlobalService.gI().get_DATA(17);
		}
	}

	// Token: 0x060006CC RID: 1740 RVA: 0x000955A8 File Offset: 0x000937A8
	public void setCmdClear()
	{
		bool flag = !GameCanvas.isTouch;
		if (flag)
		{
			bool flag2 = this.tfUser.isFocused();
			if (flag2)
			{
				this.right = this.tfUser.cmdClear;
			}
			else
			{
				bool flag3 = this.tfPass.isFocused();
				if (flag3)
				{
					this.right = this.tfPass.cmdClear;
				}
			}
		}
	}

	// Token: 0x060006CD RID: 1741 RVA: 0x0009560C File Offset: 0x0009380C
	public static void addObjShow(bool isNew)
	{
		bool flag = LoginScreen.isLoadDataCharShowOk && !GameCanvas.lowGraphic;
		if (flag)
		{
			LoginScreen.idRan += 1;
			Other_Player other_Player = new Other_Player(LoginScreen.idRan, 0, string.Empty, 0, 0);
			bool flag2 = CRes.random(2) == 0;
			if (flag2)
			{
				other_Player.x = -CRes.random(10, 40);
				other_Player.Dir = 2;
			}
			else
			{
				other_Player.x = MotherCanvas.w + CRes.random(10, 40);
				other_Player.Dir = 0;
			}
			if (isNew)
			{
				other_Player.x = CRes.random(10, MotherCanvas.w - 10);
			}
			other_Player.setSpeed(7, 7);
			other_Player.y = MotherCanvas.h - CRes.random(10, 50);
			other_Player.xAnchor = other_Player.x;
			other_Player.toX = other_Player.x;
			other_Player.toY = other_Player.y;
			other_Player.clazz = (sbyte)(1 + CRes.random(5));
			other_Player = CreateChar_Screen.setCharClass(other_Player, true);
			other_Player.isInfo = true;
			LoginScreen.vecOBJ.addElement(other_Player);
		}
	}

	// Token: 0x060006CE RID: 1742 RVA: 0x00095724 File Offset: 0x00093924
	public static void addEffectEnd(short type, int subtype, int x, int y, sbyte dir, MainObject objEff)
	{
		Effect_End o = new Effect_End(type, (sbyte)subtype, x, y, dir, objEff);
		LoginScreen.vecEff.addElement(o);
	}

	// Token: 0x060006CF RID: 1743 RVA: 0x00095750 File Offset: 0x00093950
	public override bool keyBack()
	{
		bool flag = !base.keyBack() && this.cmdExitGame != null && GameMidlet.DEVICE != 4;
		if (flag)
		{
			this.cmdExitGame.perform();
		}
		return false;
	}

	// Token: 0x040009C4 RID: 2500
	public const sbyte LOGIN = 0;

	// Token: 0x040009C5 RID: 2501
	public const sbyte REGISTER = 1;

	// Token: 0x040009C6 RID: 2502
	public sbyte type;

	// Token: 0x040009C7 RID: 2503
	public static bool isCheckData = false;

	// Token: 0x040009C8 RID: 2504
	public TField tfUser;

	// Token: 0x040009C9 RID: 2505
	public TField tfPass;

	// Token: 0x040009CA RID: 2506
	public TField tfIp;

	// Token: 0x040009CB RID: 2507
	private iCommand cmdLogin;

	// Token: 0x040009CC RID: 2508
	private iCommand cmdMenu;

	// Token: 0x040009CD RID: 2509
	private iCommand cmdRegister;

	// Token: 0x040009CE RID: 2510
	private iCommand cmdExitGame;

	// Token: 0x040009CF RID: 2511
	private iCommand cmdLowGraphic;

	// Token: 0x040009D0 RID: 2512
	private iCommand cmdFristLogin;

	// Token: 0x040009D1 RID: 2513
	private iCommand cmdHelp;

	// Token: 0x040009D2 RID: 2514
	private iCommand cmdLastLogin;

	// Token: 0x040009D3 RID: 2515
	private iCommand cmdDelRMS;

	// Token: 0x040009D4 RID: 2516
	private iCommand cmdOffBg;

	// Token: 0x040009D5 RID: 2517
	private iCommand cmdTaitho;

	// Token: 0x040009D6 RID: 2518
	public static iCommand cmdSound;

	// Token: 0x040009D7 RID: 2519
	private mVector vecCmd = new mVector();

	// Token: 0x040009D8 RID: 2520
	public static int yBeginPaint = 0;

	// Token: 0x040009D9 RID: 2521
	private int hItem = 32;

	// Token: 0x040009DA RID: 2522
	private int idSelect;

	// Token: 0x040009DB RID: 2523
	private int sizeListServer;

	// Token: 0x040009DC RID: 2524
	private int yLechNameServer;

	// Token: 0x040009DD RID: 2525
	private InputDialog input;

	// Token: 0x040009DE RID: 2526
	public static mVector vecEff = new mVector("LoginScreen.vecEff");

	// Token: 0x040009DF RID: 2527
	public static mVector vecOBJ = new mVector("LoginScreen.vecOBJ");

	// Token: 0x040009E0 RID: 2528
	private static bool isNewShow = false;

	// Token: 0x040009E1 RID: 2529
	private static bool isLoadDataCharShowOk = false;

	// Token: 0x040009E2 RID: 2530
	public static int yPaintLogo;

	// Token: 0x040009E3 RID: 2531
	public static int dy = 0;

	// Token: 0x040009E4 RID: 2532
	private int wShowPaper;

	// Token: 0x040009E5 RID: 2533
	private int maxWShow = 180;

	// Token: 0x040009E6 RID: 2534
	private int vShow = 6;

	// Token: 0x040009E7 RID: 2535
	private int hShowPaper = 85;

	// Token: 0x040009E8 RID: 2536
	public static int hLogo = 50;

	// Token: 0x040009E9 RID: 2537
	public static int frameBanhlai = 0;

	// Token: 0x040009EA RID: 2538
	public static int tickBanhLai;

	// Token: 0x040009EB RID: 2539
	public static short idRan = 0;
}
