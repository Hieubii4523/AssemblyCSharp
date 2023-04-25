using System;

// Token: 0x02000105 RID: 261
public class TabSuDo : MainTab
{
	// Token: 0x06000F2A RID: 3882 RVA: 0x00124924 File Offset: 0x00122B24
	public TabSuDo(string name)
	{
		TabSuDo.instance = this;
		this.nameTab = name;
		this.xBeginInfo = this.wCur;
		this.initCmd();
		this.listInfo = new ListNew();
		this.indexIconTab = 2;
	}

	// Token: 0x06000F2B RID: 3883 RVA: 0x001249A8 File Offset: 0x00122BA8
	public override void beginFocus()
	{
		int limX = TabSuDo.vecInfoCanhan.size() * GameCanvas.hText - this.hCur + this.miniItem * 2;
		this.listInfo = new ListNew(this.xCurBegin, this.yCurBegin, this.wCur, this.hCur, 0, 0, limX, true);
		this.scrInfo.setInfo(this.xCurBegin + this.wCur + this.miniItem, this.yCurBegin + this.miniItem / 2, this.hCur - this.miniItem * 2, 8809550);
		this.listInfo.cmx = this.lastCam;
		this.listInfo.cmtoX = this.lastCam;
		this.hItem = 48;
		limX = TabSuDo.vecSudo.size() * this.hItem - this.hCur + this.miniItem * 2 + GameCanvas.hText * 3 / 2;
		this.listSuDo = new ListNew(this.xCurBegin, this.yCurBegin, this.wCur, this.hCur, 0, 0, limX, true);
		this.scrAttri.setInfo(this.xCurBegin + this.wCur + this.miniItem, this.yCurBegin + this.miniItem / 2, this.hCur - this.miniItem * 2, 8809550);
	}

	// Token: 0x06000F2C RID: 3884 RVA: 0x00124B04 File Offset: 0x00122D04
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
		{
			bool flag = this.IdSelect < 0 || this.IdSelect >= TabSuDo.vecSudo.size() || Player.mAttribute[this.IdSelect].value >= 80;
			if (!flag)
			{
				bool flag2 = Player.pointAttribute > 1;
				if (flag2)
				{
					mVector mVector = new mVector();
					int num = 0;
					for (int i = 0; i < this.mNumAttri.Length; i++)
					{
						int num2 = this.mNumAttri[i];
						bool flag3 = num2 > Player.pointAttribute;
						if (flag3)
						{
							num2 = Player.pointAttribute;
						}
						bool flag4 = num2 > (int)(80 - Player.mAttribute[this.IdSelect].value);
						if (flag4)
						{
							num2 = (int)(80 - Player.mAttribute[this.IdSelect].value);
						}
						iCommand iCommand = new iCommand("+" + num2.ToString(), 2, num2, this);
						bool isTouch = GameCanvas.isTouch;
						if (isTouch)
						{
							iCommand.levelSmall = 3;
						}
						bool flag5 = num != num2;
						if (flag5)
						{
							num = num2;
							mVector.addElement(iCommand);
						}
						bool flag6 = this.mNumAttri[i] >= Player.pointAttribute;
						if (flag6)
						{
							break;
						}
					}
					GameCanvas.Start_Normal_DiaLog_New(T.nhaptiemnang + T.mAttribute[this.IdSelect] + "?", mVector, true, T.tabQheSudo);
				}
				else
				{
					bool flag7 = Player.pointAttribute == 1;
					if (flag7)
					{
						GlobalService.gI().Add_Point_Attribute((sbyte)this.IdSelect, 1);
					}
					else
					{
						GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.nullPointAttribute);
					}
				}
			}
			break;
		}
		case 1:
		{
			int num3 = 1;
			try
			{
				num3 = int.Parse(this.input.tfInput.getText());
				bool flag8 = num3 < 0;
				if (flag8)
				{
					num3 = 1;
				}
			}
			catch (Exception)
			{
				num3 = 1;
			}
			GlobalService.gI().Add_Point_Attribute((sbyte)this.IdSelect, (short)num3);
			GameCanvas.end_Dialog();
			break;
		}
		case 2:
			GlobalService.gI().Add_Point_Attribute((sbyte)this.IdSelect, (short)subIndex);
			GameCanvas.end_Dialog();
			break;
		}
	}

	// Token: 0x06000F2D RID: 3885 RVA: 0x00124D54 File Offset: 0x00122F54
	public void initCmd()
	{
		this.cmdSetPoint = new iCommand(T.cmdSetPoint, 0, this);
		this.cmdSetPoint.setPos(MotherCanvas.hw, MotherCanvas.h - iCommand.hButtonCmdNor / 2, null, this.cmdSetPoint.caption);
		bool flag = this.levelTab == 1;
		if (flag)
		{
			bool flag2 = GameCanvas.isTouchNoOrPC();
			if (flag2)
			{
				this.center = this.cmdSetPoint;
				this.okCMD = this.center;
			}
			this.hCur = MainTab.hTab - 32;
			this.yCurBegin = MainTab.yTab + 32;
			GlobalService.gI().Send_Sudo(2);
		}
		else
		{
			this.center = null;
			this.okCMD = null;
			this.hCur = MainTab.hTab - 32 - 80;
			this.yCurBegin = MainTab.yTab + 32 + 80;
			GlobalService.gI().Send_Sudo(3);
		}
		this.beginFocus();
	}

	// Token: 0x06000F2E RID: 3886 RVA: 0x00124E40 File Offset: 0x00123040
	public override void paint(mGraphics g)
	{
		g.setColor(14203529);
		int idx = 0;
		bool flag = GameCanvas.currentScreen.setCurTypetab(1);
		if (flag)
		{
			bool flag2 = this.levelTab == 1;
			if (flag2)
			{
				g.fillRoundRect(MainTab.xTab + 22 + (MainTab.wTab - 22) / 2 - MainTab.wTab / 4 * 3 / 2, MainTab.yTab + 7, MainTab.wTab / 4 * 3 / 2, 16, 4, 4);
				idx = 2;
				AvMain.FontBorderColor(g, T.tabQheSudo, MainTab.xTab + 22 + (MainTab.wTab - 22) / 2 + 15, MainTab.yTab + 9, 0, 6, 5);
				mFont.tahoma_7b_black.drawString(g, T.tabCanhan, MainTab.xTab + 22 + (MainTab.wTab - 22) / 2 - 15, MainTab.yTab + 9, 1);
			}
			else
			{
				bool flag3 = this.levelTab == 0;
				if (flag3)
				{
					g.fillRoundRect(MainTab.xTab + 22 + (MainTab.wTab - 22) / 2, MainTab.yTab + 7, MainTab.wTab / 4 * 3 / 2, 16, 4, 4);
					idx = 1;
					mFont.tahoma_7b_black.drawString(g, T.tabQheSudo, MainTab.xTab + 22 + (MainTab.wTab - 22) / 2 + 15, MainTab.yTab + 9, 0);
					AvMain.FontBorderColor(g, T.tabCanhan, MainTab.xTab + 22 + (MainTab.wTab - 22) / 2 - 15, MainTab.yTab + 9, 1, 6, 5);
					AvMain.paintRect(g, this.xCurBegin, this.yCurBegin, this.wCur, this.hCur - this.miniItem, 0, 4);
					int num = MainTab.yTab + 32;
					AvMain.paintRect(g, this.xCurBegin + this.wCur / 2 - 30, num, 60, 66, 0, 4);
					GameScreen.player.paintCharShow(g, this.xCurBegin + this.wCur / 2, num + 40 + GameScreen.player.hOne / 4 + 5, 0, true);
					mFont.tahoma_7b_black.drawString(g, GameScreen.player.name, this.xCurBegin + this.wCur / 2, num + 68, 2);
				}
			}
		}
		else
		{
			mFont.tahoma_7b_black.drawString(g, T.tabQheSudo, MainTab.xTab + 22 + (MainTab.wTab - 22) / 2 + 15, MainTab.yTab + 9, 0);
			mFont.tahoma_7b_black.drawString(g, T.tabCanhan, MainTab.xTab + 22 + (MainTab.wTab - 22) / 2 - 15, MainTab.yTab + 9, 1);
		}
		AvMain.fraTwoTab.drawFrame(idx, MainTab.xTab + 22 + (MainTab.wTab - 22) / 2, MainTab.yTab + 9 + 6, 0, 3, g);
		bool flag4 = Player.pointAttribute > 0 && GameCanvas.gameTick % 10 < 8;
		if (flag4)
		{
			g.drawImage(MainEvent.imgNew, MainTab.xTab + 22 + (MainTab.wTab - 22) / 2 + 9, MainTab.yTab + 9, 3);
		}
		GameCanvas.resetTrans(g);
		g.setClip(this.xCurBegin - 1, this.yCurBegin + 1, this.wCur + 2, this.hCur - 1 - this.miniItem - 1);
		g.saveCanvas();
		g.ClipRec(this.xCurBegin - 1, this.yCurBegin + 1, this.wCur + 2, this.hCur - 1 - this.miniItem - 1);
		g.translate(this.xCurBegin, this.yCurBegin);
		bool flag5 = this.levelTab == 1;
		if (flag5)
		{
			g.translate(-this.xcur, -this.listSuDo.cmx);
			this.paintSuDo(g);
		}
		else
		{
			bool flag6 = this.levelTab == 0;
			if (flag6)
			{
				g.translate(-this.xcur, -this.listInfo.cmx);
				this.paintCaNhan(g);
			}
		}
		mGraphics.resetTransAndroid(g);
		g.restoreCanvas();
	}

	// Token: 0x06000F2F RID: 3887 RVA: 0x00125244 File Offset: 0x00123444
	public void paintSuDo(mGraphics g)
	{
		bool flag = GameCanvas.isTouchNoOrPC();
		if (flag)
		{
			this.paintSelect(g);
		}
		int num = this.miniItem;
		int wCur = this.wCur;
		bool flag2 = TabSuDo.isshow;
		if (flag2)
		{
			for (int i = 0; i < TabSuDo.vecSudo.size(); i++)
			{
				InfoMemList mem = (InfoMemList)TabSuDo.vecSudo.elementAt(i);
				this.paintInfo(g, mem, wCur, num, i, this.wCur);
				num += this.hItem;
			}
		}
		bool flag3 = GameCanvas.currentScreen.setCurTypetab(1);
		if (flag3)
		{
			base.paint(g);
			bool flag4 = this.listSuDo.cmxLim > 0;
			if (flag4)
			{
				this.scrAttri.paint(g);
			}
		}
	}

	// Token: 0x06000F30 RID: 3888 RVA: 0x00125310 File Offset: 0x00123510
	public void paintInfo(mGraphics g, InfoMemList mem, int xpaint, int ypaint, int i, int wsub)
	{
		bool flag = mem != null;
		if (flag)
		{
			AvMain.paintRect(g, xpaint, ypaint, wsub - 1, 40, 0, 4);
			g.setColor(14203529);
			g.fillRect(xpaint + 45, ypaint + 2, wsub - 42 - 10, 14);
			mFont.tahoma_7b_black.drawString(g, mem.title, xpaint + 45 + (wsub - 52) / 2, ypaint + 3, 2);
			mFont.tahoma_7_white.drawString(g, mem.name, xpaint + 45 + (wsub - 52) / 2, ypaint + 22, 2);
			g.drawImage(AvMain.imgBorderIcon, xpaint + 4 + 16, ypaint + 4 + 16, 3);
			MainObject.paintHeadEveryWhere(g, mem.head, mem.hair, mem.hat, xpaint + 2 + 16, ypaint + 54, 0);
		}
	}

	// Token: 0x06000F31 RID: 3889 RVA: 0x001253E8 File Offset: 0x001235E8
	public void paintCaNhan(mGraphics g)
	{
		for (int i = 0; i < TabSuDo.vecInfoCanhan.size(); i++)
		{
			MainInfoItem mainInfoItem = (MainInfoItem)TabSuDo.vecInfoCanhan.elementAt(i);
			string text = mainInfoItem.name;
			bool flag = mainInfoItem.value != 0;
			if (flag)
			{
				text = text + " " + mainInfoItem.value.ToString();
			}
			mFont.tahoma_7_white.drawString(g, text, this.miniItem, this.miniItem + i * GameCanvas.hText, 0);
		}
		bool flag2 = GameCanvas.currentScreen.setCurTypetab(1);
		if (flag2)
		{
			base.paint(g);
			bool flag3 = this.listInfo.cmxLim > 0;
			if (flag3)
			{
				this.scrInfo.paint(g);
			}
		}
	}

	// Token: 0x06000F32 RID: 3890 RVA: 0x0000C166 File Offset: 0x0000A366
	public void paintSelect(mGraphics g, int xbegin, int ybegin, int wFocus)
	{
		g.setColor(11936290);
		g.drawRect(xbegin - 1, ybegin + this.idSelect * this.hItem, wFocus + 1, 49);
	}

	// Token: 0x06000F33 RID: 3891 RVA: 0x0011EAD4 File Offset: 0x0011CCD4
	public void paintAttPlusBuff(mGraphics g, string text, int id, int y)
	{
		int num = 0;
		for (int i = 0; i < GameScreen.player.vecBuffCur.size(); i++)
		{
			MainBuff mainBuff = (MainBuff)GameScreen.player.vecBuffCur.elementAt(i);
			bool flag = mainBuff.vecInfoAtt.size() <= 0;
			if (!flag)
			{
				for (int j = 0; j < mainBuff.vecInfoAtt.size(); j++)
				{
					MainInfoItem mainInfoItem = (MainInfoItem)mainBuff.vecInfoAtt.elementAt(j);
					bool flag2 = (int)mainInfoItem.id == id;
					if (flag2)
					{
						num += mainInfoItem.value;
						break;
					}
				}
			}
		}
		for (int k = 0; k < GameScreen.player.vecAllInfoParty.size(); k++)
		{
			MainInfoItem mainInfoItem2 = (MainInfoItem)GameScreen.player.vecAllInfoParty.elementAt(k);
			bool flag3 = (int)mainInfoItem2.id == id;
			if (flag3)
			{
				num += mainInfoItem2.value;
				break;
			}
		}
		bool flag4 = num != 0;
		if (flag4)
		{
			int width = mFont.tahoma_7_white.getWidth(text);
			string st = string.Empty + MainItem.strGetPercent(num, MainItem.mNameAttributes[id].ispercent);
			bool flag5 = num > 0;
			if (flag5)
			{
				st = "+" + MainItem.strGetPercent(num, MainItem.mNameAttributes[id].ispercent);
				mFont.tahoma_7_green.drawString(g, st, this.miniItem * 2 + width, y, 0);
			}
			else
			{
				mFont.tahoma_7_red.drawString(g, st, this.miniItem * 2 + width, y, 0);
			}
		}
	}

	// Token: 0x06000F34 RID: 3892 RVA: 0x001254B4 File Offset: 0x001236B4
	public void paintSelect(mGraphics g)
	{
		int num = this.miniItem / 2 + GameCanvas.hText * 3 / 2;
		int wCur = this.wCur;
		g.setColor(16446420);
		g.fillRect(wCur + this.miniItem / 2, num + this.IdSelect * this.hItem, 1, this.hItem);
		g.fillRect(wCur + this.wCur - this.miniItem / 2 - 1, num + this.IdSelect * this.hItem, 1, this.hItem);
		g.fillRect(wCur + this.miniItem / 2 + 1, num + this.IdSelect * this.hItem - 1, this.wCur - this.miniItem - 1, 1);
		g.fillRect(wCur + this.miniItem / 2 + 1, num + this.IdSelect * this.hItem + this.hItem, this.wCur - this.miniItem - 1, 1);
	}

	// Token: 0x06000F35 RID: 3893 RVA: 0x001255AC File Offset: 0x001237AC
	public override void update()
	{
		bool flag = this.levelTab == 0;
		if (flag)
		{
			this.listInfo.moveCamera();
			this.scrInfo.setYScrool(this.listInfo.cmx, this.listInfo.cmxLim);
		}
		else
		{
			bool flag2 = this.levelTab == 1;
			if (flag2)
			{
				this.listSuDo.moveCamera();
				this.scrAttri.setYScrool(this.listSuDo.cmx, this.listSuDo.cmxLim);
			}
		}
		bool flag3 = this.timefocus > 0;
		if (flag3)
		{
			this.timefocus--;
		}
		bool flag4 = this.xcur < this.xto && this.levelTab == 1;
		if (flag4)
		{
			this.xcur += this.speed;
			this.speed += 10;
			bool flag5 = this.xcur > this.xto;
			if (flag5)
			{
				this.xcur = this.xto;
			}
		}
		bool flag6 = this.xcur > this.xto && this.levelTab == 0;
		if (flag6)
		{
			this.xcur -= this.speed;
			this.speed += 10;
			bool flag7 = this.xcur < this.xto;
			if (flag7)
			{
				this.xcur = this.xto;
			}
		}
	}

	// Token: 0x06000F36 RID: 3894 RVA: 0x00125720 File Offset: 0x00123920
	public override void updatekey()
	{
		bool flag = this.levelTab == 0;
		if (flag)
		{
			bool flag2 = GameCanvas.keyMove(1);
			if (flag2)
			{
				GameCanvas.ClearkeyMove(1);
				this.listInfo.setToX(this.listInfo.cmtoX - MainTab.wItem);
				this.lastCam = this.listInfo.cmtoX;
			}
			else
			{
				bool flag3 = GameCanvas.keyMove(3);
				if (flag3)
				{
					this.listInfo.setToX(this.listInfo.cmtoX + MainTab.wItem);
					this.lastCam = this.listInfo.cmtoX;
					GameCanvas.ClearkeyMove(3);
				}
				else
				{
					bool flag4 = GameCanvas.keyMove(0);
					if (flag4)
					{
						GameCanvas.currentScreen.setTypeTab(0);
						GameCanvas.ClearkeyMove(0);
					}
					else
					{
						bool flag5 = GameCanvas.keyMove(2);
						if (flag5)
						{
							GameCanvas.ClearkeyMove(2);
							this.levelTab = 1;
							this.xto = this.wCur;
							this.speed = 20;
							this.xcur = 0;
							this.initCmd();
						}
					}
				}
			}
		}
		else
		{
			bool flag6 = this.levelTab == 1;
			if (flag6)
			{
				bool flag7 = false;
				bool flag8 = GameCanvas.keyMove(1);
				if (flag8)
				{
					GameCanvas.ClearkeyMove(1);
					this.IdSelect--;
					flag7 = true;
				}
				else
				{
					bool flag9 = GameCanvas.keyMove(3);
					if (flag9)
					{
						GameCanvas.ClearkeyMove(3);
						this.IdSelect++;
						flag7 = true;
					}
					else
					{
						bool flag10 = GameCanvas.keyMove(0);
						if (flag10)
						{
							GameCanvas.ClearkeyMove(0);
							this.xto = 0;
							this.speed = 20;
							this.xcur = this.wCur;
							this.levelTab = 0;
							this.initCmd();
						}
					}
				}
				bool flag11 = flag7;
				if (flag11)
				{
					this.IdSelect = AvMain.resetSelect(this.IdSelect, TabSuDo.vecSudo.size() - 1, true);
					bool flag12 = GameCanvas.isTouchNoOrPC();
					if (flag12)
					{
						this.listSuDo.setToX((this.IdSelect + 1) * this.hItem - this.hCur / 2);
					}
				}
			}
		}
		base.updatekey();
		this.updatekeyPC();
	}

	// Token: 0x06000F37 RID: 3895 RVA: 0x0012593C File Offset: 0x00123B3C
	public override void updatePointer()
	{
		bool flag = GameCanvas.isPointSelect(MainTab.xTab + 22 + (MainTab.wTab - 22) / 2 - MainTab.wTab / 4 * 3 / 2 - 6, MainTab.yTab + 7, MainTab.wTab / 4 * 3 - 20, 28);
		if (flag)
		{
			GameCanvas.isPointerSelect = false;
			bool flag2 = this.levelTab == 0;
			if (flag2)
			{
				this.levelTab = 1;
				this.xto = this.wCur;
				this.xcur = 0;
			}
			else
			{
				bool flag3 = this.levelTab == 1;
				if (flag3)
				{
					this.levelTab = 0;
					this.xto = 0;
					this.xcur = this.wCur;
				}
			}
			this.speed = 20;
			this.initCmd();
		}
		bool flag4 = this.levelTab == 0;
		if (flag4)
		{
			this.listInfo.update_Pos_UP_DOWN();
		}
		else
		{
			bool flag5 = this.levelTab == 1;
			if (flag5)
			{
				this.listSuDo.update_Pos_UP_DOWN();
				bool flag6 = GameCanvas.isPointerSelect && GameCanvas.isPoint(this.xCurBegin, this.yCurBegin, this.wCur, this.hCur);
				if (flag6)
				{
					int num = (GameCanvas.py - (this.yCurBegin + this.miniItem + GameCanvas.hText * 3 / 2) + this.listSuDo.cmx) / this.hItem;
					bool flag7 = num >= 0 && num < TabSuDo.vecSudo.size();
					if (flag7)
					{
						this.IdSelect = num;
						this.timefocus = 5;
						bool flag8 = Player.pointAttribute > 0;
						if (flag8)
						{
							this.cmdSetPoint.perform();
						}
					}
					GameCanvas.isPointerSelect = false;
				}
			}
		}
		base.updatePointer();
	}

	// Token: 0x06000F38 RID: 3896 RVA: 0x0000C194 File Offset: 0x0000A394
	public static void updateTabAttri(Main_Attribute[] att)
	{
		TabSuDo.isshow = false;
		Player.mAttribute = att;
		TabSuDo.isshow = true;
	}

	// Token: 0x06000F39 RID: 3897 RVA: 0x00125AF0 File Offset: 0x00123CF0
	public override void updateChangeTabInfo()
	{
		bool flag = this.levelTab == 0;
		if (flag)
		{
			this.levelTab = 1;
		}
		else
		{
			this.levelTab = 0;
		}
		this.xto = this.wCur;
		this.speed = 20;
		this.xcur = 0;
		this.initCmd();
	}

	// Token: 0x04001967 RID: 6503
	public const sbyte SUDO_LIST = 2;

	// Token: 0x04001968 RID: 6504
	public const sbyte SUDO_INFO = 3;

	// Token: 0x04001969 RID: 6505
	public const int LEVEL_SUDO = 1;

	// Token: 0x0400196A RID: 6506
	public const int LEVEL_CANHAN = 0;

	// Token: 0x0400196B RID: 6507
	public static TabSuDo instance;

	// Token: 0x0400196C RID: 6508
	private iCommand cmdSetPoint;

	// Token: 0x0400196D RID: 6509
	private InputDialog input;

	// Token: 0x0400196E RID: 6510
	private ListNew listInfo;

	// Token: 0x0400196F RID: 6511
	private ListNew listSuDo;

	// Token: 0x04001970 RID: 6512
	private int lastCam;

	// Token: 0x04001971 RID: 6513
	private int xBeginInfo;

	// Token: 0x04001972 RID: 6514
	private Scroll scrInfo = new Scroll();

	// Token: 0x04001973 RID: 6515
	private Scroll scrAttri = new Scroll();

	// Token: 0x04001974 RID: 6516
	private int xto;

	// Token: 0x04001975 RID: 6517
	private int xcur;

	// Token: 0x04001976 RID: 6518
	private int speed = 20;

	// Token: 0x04001977 RID: 6519
	private int hItem;

	// Token: 0x04001978 RID: 6520
	private int timefocus;

	// Token: 0x04001979 RID: 6521
	private int[] mNumAttri = new int[]
	{
		1,
		2,
		10
	};

	// Token: 0x0400197A RID: 6522
	private int idSelect;

	// Token: 0x0400197B RID: 6523
	public static mVector vecSudo = new mVector();

	// Token: 0x0400197C RID: 6524
	private int wPaintQua = 93;

	// Token: 0x0400197D RID: 6525
	public static mVector vecInfoCanhan = new mVector();

	// Token: 0x0400197E RID: 6526
	public static bool isshow = true;
}
