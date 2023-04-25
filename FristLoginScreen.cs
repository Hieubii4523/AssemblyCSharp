using System;

// Token: 0x02000032 RID: 50
public class FristLoginScreen : MainScreen
{
	// Token: 0x06000385 RID: 901 RVA: 0x00070278 File Offset: 0x0006E478
	public FristLoginScreen()
	{
		this.cmdBegin = new iCommand(T.loadGame, 0, 0, this);
		SaveRms.userLast = string.Empty;
		bool flag = CRes.loadRMS("MAIN_user_last") != null;
		if (flag)
		{
			GameCanvas.saveRms.loadUserLast();
		}
		else
		{
			GameCanvas.IndexServer = GameCanvas.strListServer[(int)GameCanvas.language].Length - 1;
		}
		bool flag2 = GameCanvas.IndexServer >= GameCanvas.strListServer[(int)GameCanvas.language].Length;
		if (flag2)
		{
			GameCanvas.IndexServer = GameCanvas.strListServer[(int)GameCanvas.language].Length - 1;
		}
		FristLoginScreen.cmdRegister = new iCommand(T.register, 3, this);
		this.cmdServer = new iCommand(T.server + "\n" + GameCanvas.strListServer[(int)GameCanvas.language][GameCanvas.IndexServer], 4, this);
		this.valueBegin = (GameCanvas.strListServer[(int)GameCanvas.language].Length - 1) * 38;
		this.getVecBegin();
		bool flag3 = LoginScreen.yPaintLogo == 0;
		if (flag3)
		{
			LoginScreen.yPaintLogo = LoginScreen.hLogo;
		}
	}

	// Token: 0x06000386 RID: 902 RVA: 0x00070394 File Offset: 0x0006E594
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
		this.idCommand = 0;
		bool flag3 = !GameCanvas.isTouch || GameCanvas.isTouchAndKey();
		if (flag3)
		{
			for (int i = 0; i < this.vecCmd.size(); i++)
			{
				iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
				bool flag4 = i == this.idCommand;
				if (flag4)
				{
					iCommand.isSelect = true;
				}
				else
				{
					iCommand.isSelect = false;
				}
			}
		}
		bool flag5 = GameCanvas.currentScreen != null && GameCanvas.currentScreen != GameCanvas.loginScr && GameCanvas.currentScreen != GameCanvas.fristLoginScr;
		if (flag5)
		{
			LoginScreen.beginShowChar();
		}
		LoginScreen.loadCharPart();
		base.Show();
		mSound.playMus(3, mSound.volumeMusic, true);
	}

	// Token: 0x06000387 RID: 903 RVA: 0x000092E5 File Offset: 0x000074E5
	public override void setxyPlus12()
	{
		GameCanvas.xPlus12 = 2;
		GameCanvas.yPlus12 = 2;
	}

	// Token: 0x06000388 RID: 904 RVA: 0x000704B0 File Offset: 0x0006E6B0
	public void setBeginGame()
	{
		bool flag = CRes.loadRMS("MAIN_user_pass") != null;
		if (flag)
		{
			GameCanvas.loginScr.Show();
			GameCanvas.loginScr.doLogin(true, 0, GameCanvas.loginScr.tfUser.getText(), GameCanvas.loginScr.tfPass.getText());
		}
		else
		{
			this.setNewAcc(false);
			this.getVecBegin();
		}
	}

	// Token: 0x06000389 RID: 905 RVA: 0x0007051C File Offset: 0x0006E71C
	public void setNewAcc(bool isCheckDataOK)
	{
		sbyte[] array = CRes.loadRMS("MAIN_frist_login");
		bool flag = array == null && !isCheckDataOK;
		if (!flag)
		{
			ListChar_Screen.IndexCharSelected = -1;
			FristLoginScreen.userNew = string.Empty;
			try
			{
				ByteArrayInputStream bis = new ByteArrayInputStream(array);
				DataInputStream dataInputStream = new DataInputStream(bis);
				FristLoginScreen.userNew = dataInputStream.readUTF();
				bool flag2 = dataInputStream.available() > 0;
				if (flag2)
				{
					GameCanvas.IndexServer = (int)dataInputStream.readByte();
				}
			}
			catch (Exception)
			{
				FristLoginScreen.userNew = string.Empty;
			}
			mSystem.outz("4");
			GameCanvas.loginScr.doLogin(true, 1, FristLoginScreen.userNew, string.Empty);
		}
	}

	// Token: 0x0600038A RID: 906 RVA: 0x000705D0 File Offset: 0x0006E7D0
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
		{
			ListChar_Screen.IndexCharSelected = -1;
			FristLoginScreen.userNew = string.Empty;
			sbyte[] array = CRes.loadRMS("MAIN_frist_login");
			bool flag = array != null;
			if (flag)
			{
				try
				{
					ByteArrayInputStream bis = new ByteArrayInputStream(array);
					DataInputStream dataInputStream = new DataInputStream(bis);
					FristLoginScreen.userNew = dataInputStream.readUTF();
					bool flag2 = dataInputStream.available() > 0;
					if (flag2)
					{
						GameCanvas.IndexServer = (int)dataInputStream.readByte();
					}
				}
				catch (Exception)
				{
					FristLoginScreen.userNew = string.Empty;
				}
			}
			GameCanvas.loginScr.doLogin(true, 1, FristLoginScreen.userNew, string.Empty);
			break;
		}
		case 1:
			GameCanvas.loginScr.Show();
			break;
		case 2:
			GameCanvas.loginScr.doLogin(true, 1, string.Empty, string.Empty);
			break;
		case 3:
		{
			string[] array2 = new string[FristLoginScreen.input.mtfInput.Length];
			for (int i = 0; i < array2.Length; i++)
			{
				bool flag3 = FristLoginScreen.input.mtfInput[i].getText().Length > 0;
				if (flag3)
				{
					array2[i] = FristLoginScreen.input.mtfInput[i].getText();
				}
				else
				{
					array2[i] = string.Empty;
				}
			}
			GlobalService.gI().RegisterNew(array2);
			break;
		}
		case 4:
		{
			bool flag4 = GameCanvas.strListServer[(int)GameCanvas.language].Length == 1;
			if (flag4)
			{
				return;
			}
			this.vecCmd.removeAllElements();
			for (int j = 0; j < GameCanvas.strListServer[(int)GameCanvas.language].Length; j++)
			{
				iCommand iCommand = new iCommand(T.server + "\n" + GameCanvas.strListServer[(int)GameCanvas.language][j], 5, j, this);
				iCommand.setPos(MotherCanvas.hw - this.valueBegin + j * 76, MotherCanvas.h - 60, null, iCommand.caption);
				iCommand.setTypeSpec();
				this.vecCmd.addElement(iCommand);
			}
			break;
		}
		case 5:
			GameCanvas.IndexServer = subIndex;
			this.getVecBegin();
			break;
		}
		base.commandPointer(index, subIndex);
	}

	// Token: 0x0600038B RID: 907 RVA: 0x0007082C File Offset: 0x0006EA2C
	private void getVecBegin()
	{
		this.vecCmd.removeAllElements();
		bool flag = SaveRms.userLast.Length > 0;
		if (flag)
		{
			this.cmdBegin.caption = T.loadGame + "\n " + SaveRms.userLast;
			this.cmdBegin.setPos(MotherCanvas.hw - 38, MotherCanvas.h - 98, null, this.cmdBegin.caption);
			this.cmdBegin.setTypeSpec();
			this.vecCmd.addElement(this.cmdBegin);
			this.cmdNewGame = new iCommand(T.newGame, 2, 0, this);
			this.cmdNewGame.setPos(MotherCanvas.hw + 38, MotherCanvas.h - 98, null, this.cmdNewGame.caption);
			this.cmdNewGame.setTypeSpec();
			this.vecCmd.addElement(this.cmdNewGame);
			this.cmdChangeAcc = new iCommand(T.changeAcc, 1, 0, this);
			this.cmdChangeAcc.setPos(MotherCanvas.hw - 38, MotherCanvas.h - 46, null, this.cmdChangeAcc.caption);
			this.cmdChangeAcc.setTypeSpec();
			this.vecCmd.addElement(this.cmdChangeAcc);
			this.cmdServer.caption = T.server + "\n" + GameCanvas.strListServer[(int)GameCanvas.language][GameCanvas.IndexServer];
			this.cmdServer.setPos(MotherCanvas.hw + 38, MotherCanvas.h - 46, null, this.cmdServer.caption);
			this.cmdServer.setTypeSpec();
			this.vecCmd.addElement(this.cmdServer);
		}
		else
		{
			this.cmdNewGame = new iCommand(T.newGame, 2, 0, this);
			this.cmdNewGame.setPos(MotherCanvas.hw - 76, MotherCanvas.h - 60, null, this.cmdNewGame.caption);
			this.cmdNewGame.setTypeSpec();
			this.vecCmd.addElement(this.cmdNewGame);
			this.cmdChangeAcc = new iCommand(T.changeAcc, 1, 0, this);
			this.cmdChangeAcc.setPos(MotherCanvas.hw, MotherCanvas.h - 60, null, this.cmdChangeAcc.caption);
			this.cmdChangeAcc.setTypeSpec();
			this.vecCmd.addElement(this.cmdChangeAcc);
			this.cmdServer.caption = T.server + "\n" + GameCanvas.strListServer[(int)GameCanvas.language][GameCanvas.IndexServer];
			this.cmdServer.setPos(MotherCanvas.hw + 76, MotherCanvas.h - 60, null, this.cmdServer.caption);
			this.cmdServer.setTypeSpec();
			this.vecCmd.addElement(this.cmdServer);
		}
		this.idCommand = 0;
		bool flag2 = GameCanvas.isTouch && !GameCanvas.isTouchAndKey();
		if (!flag2)
		{
			for (int i = 0; i < this.vecCmd.size(); i++)
			{
				iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
				bool flag3 = i == this.idCommand;
				if (flag3)
				{
					iCommand.isSelect = true;
				}
				else
				{
					iCommand.isSelect = false;
				}
			}
		}
	}

	// Token: 0x0600038C RID: 908 RVA: 0x00070B80 File Offset: 0x0006ED80
	public override void paint(mGraphics g)
	{
		bool flag = GameCanvas.mapBack != null;
		if (flag)
		{
			GameCanvas.mapBack.paintBgLogin(g);
			GameCanvas.mapBack.paintObjFristLogin(g);
			GameCanvas.mapBack.paintObjLastLogin(g);
		}
		LoginScreen.paintShowchar(g);
		LoginScreen.paintLogo(g, MotherCanvas.hw);
		GameCanvas.resetTrans(g);
		for (int i = 0; i < this.vecCmd.size(); i++)
		{
			iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
			iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
		}
		base.paint(g);
	}

	// Token: 0x0600038D RID: 909 RVA: 0x00009B3F File Offset: 0x00007D3F
	public override void update()
	{
		LoginScreen.updateYPaintLogo(LoginScreen.hLogo);
		LoginScreen.updateCharShow();
	}

	// Token: 0x0600038E RID: 910 RVA: 0x00070C24 File Offset: 0x0006EE24
	public override void updatekey()
	{
		int num = this.vecCmd.size();
		bool flag = (!GameCanvas.isTouch || GameCanvas.isTouchAndKey()) && num > 0;
		if (flag)
		{
			int num2 = this.idCommand;
			bool flag2 = GameCanvas.keyMove(0);
			if (flag2)
			{
				this.idCommand--;
				GameCanvas.ClearkeyMove(0);
			}
			else
			{
				bool flag3 = GameCanvas.keyMove(2);
				if (flag3)
				{
					this.idCommand++;
					GameCanvas.clearKeyHold(6);
					GameCanvas.ClearkeyMove(2);
				}
			}
			this.idCommand = AvMain.resetSelect(this.idCommand, num - 1, false);
			bool flag4 = num2 != this.idCommand && (!GameCanvas.isTouch || GameCanvas.isTouchAndKey());
			if (flag4)
			{
				for (int i = 0; i < num; i++)
				{
					iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
					bool flag5 = i == this.idCommand;
					if (flag5)
					{
						iCommand.isSelect = true;
					}
					else
					{
						iCommand.isSelect = false;
					}
				}
			}
		}
		bool flag6 = GameCanvas.keyMyHold[5];
		if (flag6)
		{
			GameCanvas.clearKeyHold(5);
			bool flag7 = this.vecCmd != null && this.idCommand < this.vecCmd.size();
			if (flag7)
			{
				((iCommand)this.vecCmd.elementAt(this.idCommand)).perform();
			}
		}
		base.updatekey();
		this.updatekeyPC();
	}

	// Token: 0x0600038F RID: 911 RVA: 0x00070DA0 File Offset: 0x0006EFA0
	public override void updatePointer()
	{
		for (int i = 0; i < this.vecCmd.size(); i++)
		{
			iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
			iCommand.updatePointer();
		}
		base.updatePointer();
	}

	// Token: 0x04000572 RID: 1394
	public iCommand cmdBegin;

	// Token: 0x04000573 RID: 1395
	public iCommand cmdChangeAcc;

	// Token: 0x04000574 RID: 1396
	public iCommand cmdServer;

	// Token: 0x04000575 RID: 1397
	public iCommand cmdNewGame;

	// Token: 0x04000576 RID: 1398
	private mVector vecCmd = new mVector();

	// Token: 0x04000577 RID: 1399
	public static string userNew = string.Empty;

	// Token: 0x04000578 RID: 1400
	public static InputDialog input;

	// Token: 0x04000579 RID: 1401
	public static iCommand cmdRegister;

	// Token: 0x0400057A RID: 1402
	private int valueBegin;

	// Token: 0x0400057B RID: 1403
	private int idCommand;
}
