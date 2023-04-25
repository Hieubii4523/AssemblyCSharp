using System;

// Token: 0x020000D4 RID: 212
public class PvPScreen : MainScreen
{
	// Token: 0x06000C29 RID: 3113 RVA: 0x000E8DD4 File Offset: 0x000E6FD4
	public PvPScreen()
	{
		this.w = 180;
		this.h = 190;
		this.x = MotherCanvas.hw - this.w / 2;
		this.y = MotherCanvas.hh - this.h / 2 + GameCanvas.hCommand / 2;
		this.yPaintChar = this.y + 78;
		this.cmdFind = new iCommand(T.find, 0, this);
		this.cmdCancle = new iCommand(T.cancel, 1, this);
		this.cmdReady = new iCommand(T.ready, 2, this);
		this.cmdFindCancle = new iCommand(T.findCancle, 3, this);
		bool flag = AvMain.imgPvpObjdef == null || AvMain.imgPvpVs == null || AvMain.imgPvpOk == null;
		if (flag)
		{
			LoadImageStatic.LoadImgPvP();
		}
	}

	// Token: 0x06000C2A RID: 3114 RVA: 0x000092E5 File Offset: 0x000074E5
	public override void setxyPlus12()
	{
		GameCanvas.xPlus12 = 2;
		GameCanvas.yPlus12 = 2;
	}

	// Token: 0x06000C2B RID: 3115 RVA: 0x000E8EB8 File Offset: 0x000E70B8
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
			GlobalService.gI().PvP(1);
			break;
		case 1:
		{
			GlobalService.gI().PvP(5);
			bool flag = this.lastScreen != null;
			if (flag)
			{
				this.lastScreen.Show(this.lastScreen.lastScreen);
			}
			break;
		}
		case 2:
			GlobalService.gI().PvP(4);
			break;
		case 3:
			GlobalService.gI().PvP(2);
			break;
		}
	}

	// Token: 0x06000C2C RID: 3116 RVA: 0x000E8F40 File Offset: 0x000E7140
	public void setAction(sbyte action)
	{
		this.isfind = false;
		this.vecCmd.removeAllElements();
		switch (action)
		{
		case 0:
		{
			this.xMoveEff = 0;
			this.vxMoveEff = 0;
			this.timeReady = 0;
			this.isMeReady = false;
			this.isOtherReady = false;
			this.objPvP = null;
			this.vecCmd.addElement(this.cmdFind);
			this.vecCmd.addElement(this.cmdCancle);
			this.setMStr(T.PvPOpen + " " + this.numPlayerWait.ToString() + T.soluongnguoicho);
			bool flag = PvPScreen.instance != null;
			if (flag)
			{
				PvPScreen.instance.Show(GameCanvas.gameScr);
			}
			break;
		}
		case 1:
			this.isfind = true;
			this.isMeReady = false;
			this.isOtherReady = false;
			this.vxMoveEff = 5;
			this.setMStr(T.PvPfind);
			this.vecCmd.addElement(this.cmdFindCancle);
			break;
		case 2:
			this.isMeReady = false;
			this.isOtherReady = false;
			this.vxMoveEff = -5;
			this.setMStr(T.PvPfindCancle);
			this.vecCmd.addElement(this.cmdFind);
			this.vecCmd.addElement(this.cmdCancle);
			this.timeReady = 0;
			break;
		case 3:
			this.timeBeginReady = GameCanvas.timeNow;
			this.timeReady = 30;
			this.setMStr(T.PvPfindOk);
			this.vecCmd.addElement(this.cmdReady);
			this.vecCmd.addElement(this.cmdCancle);
			break;
		case 4:
		{
			bool flag2 = this.isMeReady && this.isOtherReady;
			if (flag2)
			{
				this.timeReady = 0;
				this.setMStr(T.PvPready3);
			}
			else
			{
				bool flag3 = this.isMeReady;
				if (flag3)
				{
					this.timeReady = 0;
					this.setMStr(T.PvPready);
				}
				else
				{
					bool flag4 = this.isOtherReady;
					if (flag4)
					{
						this.vecCmd.addElement(this.cmdReady);
						this.vecCmd.addElement(this.cmdCancle);
						this.setMStr(T.PvPready2);
					}
				}
			}
			break;
		}
		case 6:
			this.isMeReady = false;
			this.isOtherReady = false;
			this.objPvP = null;
			this.vxMoveEff = -5;
			this.vecCmd.addElement(this.cmdFind);
			this.vecCmd.addElement(this.cmdCancle);
			this.timeReady = 0;
			break;
		}
		this.setPosCmd();
	}

	// Token: 0x06000C2D RID: 3117 RVA: 0x0000BB99 File Offset: 0x00009D99
	public void setMStr(string str)
	{
		this.mstrShow = mFont.tahoma_7_black.splitFontArray(str, this.w - 10);
	}

	// Token: 0x06000C2E RID: 3118 RVA: 0x0000BBB6 File Offset: 0x00009DB6
	public void setObjPvp(MainObject obj)
	{
		this.objPvP = obj;
		this.setCharClass(this.objPvP.clazz);
	}

	// Token: 0x06000C2F RID: 3119 RVA: 0x000E91E0 File Offset: 0x000E73E0
	public void setPosCmd()
	{
		this.idCommand = 0;
		bool flag = this.vecCmd.size() == 1;
		if (flag)
		{
			iCommand iCommand = (iCommand)this.vecCmd.elementAt(0);
			iCommand.setPos(MotherCanvas.hw, this.y + this.h - iCommand.hButtonCmdNor, null, iCommand.caption);
			bool flag2 = !GameCanvas.isTouch;
			if (flag2)
			{
				iCommand.isSelect = true;
			}
			this.okCMD = iCommand;
		}
		bool flag3 = this.vecCmd.size() == 2;
		if (flag3)
		{
			iCommand iCommand2 = (iCommand)this.vecCmd.elementAt(0);
			iCommand2.setPos(MotherCanvas.hw - iCommand.wButtonCmd / 2, this.y + this.h - iCommand.hButtonCmdNor, null, iCommand2.caption);
			bool flag4 = !GameCanvas.isTouch;
			if (flag4)
			{
				iCommand2.isSelect = true;
			}
			this.okCMD = iCommand2;
			iCommand iCommand3 = (iCommand)this.vecCmd.elementAt(1);
			iCommand3.setPos(MotherCanvas.hw + iCommand.wButtonCmd / 2, this.y + this.h - iCommand.hButtonCmdNor, null, iCommand3.caption);
			bool flag5 = !GameCanvas.isTouch;
			if (flag5)
			{
				iCommand3.isSelect = false;
			}
			this.backCMD = iCommand3;
		}
	}

	// Token: 0x06000C30 RID: 3120 RVA: 0x000E933C File Offset: 0x000E753C
	public override void paint(mGraphics g)
	{
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.paint(g);
		}
		GameCanvas.resetTrans(g);
		AvMain.paintBG_AChi(g, this.x - 12, this.y - 20, this.w + 24, this.h + 25, 2);
		GameScreen.player.paintCharShow(g, this.x + this.w / 2 - this.xMoveEff, this.yPaintChar, 2, true);
		mFont.tahoma_7_black.drawString(g, GameScreen.player.name, this.x + this.w / 2 - this.xMoveEff, this.yPaintChar - 60, 2);
		bool flag2 = this.objPvP != null;
		if (flag2)
		{
			this.objPvP.paintCharShow(g, this.x + this.w / 2 + this.xMoveEff, this.yPaintChar, 0, true);
			mFont.tahoma_7_black.drawString(g, this.objPvP.name, this.x + this.w / 2 + this.xMoveEff, this.yPaintChar - 60, 2);
		}
		else
		{
			bool flag3 = this.xMoveEff == this.w / 4 || this.vxMoveEff != 0;
			if (flag3)
			{
				g.drawImage(AvMain.imgPvpObjdef, this.x + this.w / 2 + this.xMoveEff, this.yPaintChar + 2, 33);
			}
		}
		bool flag4 = this.xMoveEff > 12;
		if (flag4)
		{
			g.drawImage(AvMain.imgPvpVs, this.x + this.w / 2, this.yPaintChar - 24, 3);
		}
		bool flag5 = this.isMeReady;
		if (flag5)
		{
			g.drawImage(AvMain.imgPvpOk, this.x + this.w / 2 - this.xMoveEff - 20, this.yPaintChar, 33);
		}
		bool flag6 = this.isOtherReady;
		if (flag6)
		{
			bool flag7 = AvMain.imgPvpOk == null;
			if (flag7)
			{
				LoadImageStatic.LoadImgPvP();
			}
			else
			{
				g.drawImage(AvMain.imgPvpOk, this.x + this.w / 2 + this.xMoveEff + 20, this.yPaintChar, 33);
			}
		}
		int num = this.yPaintChar + GameCanvas.hText / 2;
		mFont.tahoma_7_black.drawString(g, T.pointPvP + GameScreen.player.PointPvP.ToString(), this.x + 10, num, 0);
		num += GameCanvas.hText;
		mFont.tahoma_7_black.drawString(g, T.thangthua + GameScreen.player.mValuePvP[0].ToString() + "/" + GameScreen.player.mValuePvP[1].ToString(), this.x + 10, num, 0);
		num += GameCanvas.hText;
		bool flag8 = this.mstrShow != null;
		if (flag8)
		{
			for (int i = 0; i < this.mstrShow.Length; i++)
			{
				string text = this.mstrShow[i];
				bool flag9 = this.isfind;
				if (flag9)
				{
					bool flag10 = GameCanvas.gameTick % 20 < 5;
					if (flag10)
					{
						text += ".";
					}
					else
					{
						bool flag11 = GameCanvas.gameTick % 20 < 10;
						if (flag11)
						{
							text += "..";
						}
						else
						{
							bool flag12 = GameCanvas.gameTick % 20 < 15;
							if (flag12)
							{
								text += "...";
							}
						}
					}
				}
				bool flag13 = this.timeReady > 0 && i == this.mstrShow.Length - 1;
				if (flag13)
				{
					string str = text;
					text = str + " " + this.timeReady.ToString() + "s.";
				}
				mFont.tahoma_7_black.drawString(g, text, this.x + this.w / 2, num, 2);
				num += GameCanvas.hText;
			}
		}
		Interface_Game.paintEffShowMoney(g, MotherCanvas.hw - Interface_Game.wMoneyEff / 2, GameScreen.h12plus, false, 1);
		for (int j = 0; j < this.vecCmd.size(); j++)
		{
			iCommand iCommand = (iCommand)this.vecCmd.elementAt(j);
			iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
		}
	}

	// Token: 0x06000C31 RID: 3121 RVA: 0x000E97B0 File Offset: 0x000E79B0
	public override void update()
	{
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.update();
		}
		bool flag2 = this.vxMoveEff > 0;
		if (flag2)
		{
			bool flag3 = this.xMoveEff < this.w / 4;
			if (flag3)
			{
				this.xMoveEff += this.vxMoveEff;
			}
			else
			{
				this.vxMoveEff = 0;
				this.xMoveEff = this.w / 4;
			}
		}
		else
		{
			bool flag4 = this.vxMoveEff < 0;
			if (flag4)
			{
				bool flag5 = this.xMoveEff > 0;
				if (flag5)
				{
					this.xMoveEff += this.vxMoveEff;
				}
				else
				{
					this.xMoveEff = 0;
					this.vxMoveEff = 0;
				}
			}
		}
		bool flag6 = this.timeReady > 0 && GameCanvas.timeNow - this.timeBeginReady > 1000L;
		if (flag6)
		{
			this.timeReady -= 1;
			this.timeBeginReady += 1000L;
		}
	}

	// Token: 0x06000C32 RID: 3122 RVA: 0x000E98BC File Offset: 0x000E7ABC
	public override void updatekey()
	{
		int num = this.vecCmd.size();
		bool flag = !GameCanvas.isTouch && num > 0;
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
					GameCanvas.ClearkeyMove(2);
				}
			}
			this.idCommand = AvMain.resetSelect(this.idCommand, num - 1, false);
			bool flag4 = num2 != this.idCommand && GameCanvas.isTouchNoOrPC();
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
		bool flag6 = GameCanvas.keyMyHold[5] && this.idCommand < this.vecCmd.size();
		if (flag6)
		{
			((iCommand)this.vecCmd.elementAt(this.idCommand)).perform();
			GameCanvas.clearKeyHold(5);
		}
		this.updatekeyPC();
	}

	// Token: 0x06000C33 RID: 3123 RVA: 0x000E9A0C File Offset: 0x000E7C0C
	public override void updatePointer()
	{
		for (int i = 0; i < this.vecCmd.size(); i++)
		{
			iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
			iCommand.updatePointer();
		}
		base.updatePointer();
	}

	// Token: 0x06000C34 RID: 3124 RVA: 0x000E9A58 File Offset: 0x000E7C58
	public void setCharClass(sbyte clazz)
	{
		switch (clazz)
		{
		case 1:
			this.objPvP.head = 0;
			this.objPvP.hair = 1;
			this.objPvP.hat = -1;
			this.objPvP.body = 3;
			this.objPvP.leg = 4;
			this.objPvP.weapon = -1;
			break;
		case 2:
			this.objPvP.head = 0;
			this.objPvP.hair = 24;
			this.objPvP.hat = -1;
			this.objPvP.body = 26;
			this.objPvP.leg = 27;
			this.objPvP.weapon = 5;
			break;
		case 3:
			this.objPvP.head = 0;
			this.objPvP.hair = 28;
			this.objPvP.hat = -1;
			this.objPvP.body = 30;
			this.objPvP.leg = 31;
			this.objPvP.weapon = 180;
			break;
		case 4:
			this.objPvP.head = 0;
			this.objPvP.hair = 32;
			this.objPvP.hat = -1;
			this.objPvP.body = 34;
			this.objPvP.leg = 35;
			this.objPvP.weapon = 6;
			break;
		case 5:
			this.objPvP.head = 0;
			this.objPvP.hair = 36;
			this.objPvP.hat = -1;
			this.objPvP.body = 38;
			this.objPvP.leg = 39;
			this.objPvP.weapon = 7;
			break;
		}
	}

	// Token: 0x04001322 RID: 4898
	public const sbyte PVP_OPEN = 0;

	// Token: 0x04001323 RID: 4899
	public const sbyte PVP_FIND = 1;

	// Token: 0x04001324 RID: 4900
	public const sbyte PVP_FIND_CANCLE = 2;

	// Token: 0x04001325 RID: 4901
	public const sbyte PVP_FIND_OK = 3;

	// Token: 0x04001326 RID: 4902
	public const sbyte PVP_READY = 4;

	// Token: 0x04001327 RID: 4903
	public const sbyte PVP_CANCLE = 5;

	// Token: 0x04001328 RID: 4904
	public const sbyte PVP_ERROR = 6;

	// Token: 0x04001329 RID: 4905
	public int w;

	// Token: 0x0400132A RID: 4906
	public int h;

	// Token: 0x0400132B RID: 4907
	public int x;

	// Token: 0x0400132C RID: 4908
	public int y;

	// Token: 0x0400132D RID: 4909
	public int yPaintChar;

	// Token: 0x0400132E RID: 4910
	public int idCommand;

	// Token: 0x0400132F RID: 4911
	public int xMoveEff;

	// Token: 0x04001330 RID: 4912
	public int vxMoveEff;

	// Token: 0x04001331 RID: 4913
	public MainObject objPvP;

	// Token: 0x04001332 RID: 4914
	public string[] mstrShow;

	// Token: 0x04001333 RID: 4915
	public iCommand cmdFind;

	// Token: 0x04001334 RID: 4916
	public iCommand cmdCancle;

	// Token: 0x04001335 RID: 4917
	public iCommand cmdReady;

	// Token: 0x04001336 RID: 4918
	public iCommand cmdFindCancle;

	// Token: 0x04001337 RID: 4919
	public mVector vecCmd = new mVector();

	// Token: 0x04001338 RID: 4920
	public bool isMeReady;

	// Token: 0x04001339 RID: 4921
	public bool isOtherReady;

	// Token: 0x0400133A RID: 4922
	public bool isfind;

	// Token: 0x0400133B RID: 4923
	private long timeBeginReady;

	// Token: 0x0400133C RID: 4924
	public short timeReady;

	// Token: 0x0400133D RID: 4925
	public short numPlayerWait;

	// Token: 0x0400133E RID: 4926
	public static PvPScreen instance;
}
