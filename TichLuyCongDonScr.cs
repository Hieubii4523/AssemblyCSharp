using System;

// Token: 0x02000109 RID: 265
public class TichLuyCongDonScr : PaintListScreen
{
	// Token: 0x06000F79 RID: 3961 RVA: 0x00129418 File Offset: 0x00127618
	public TichLuyCongDonScr(mVector vec) : base(0, vec, T.tichLuyCongDon, 200, 180)
	{
		bool flag = !GameCanvas.isTouch;
		if (flag)
		{
			bool flag2 = this.wSub > 160;
			if (flag2)
			{
				this.wSub = 160;
			}
			this.xSub = MotherCanvas.hw - this.wSub / 2;
		}
		this.hBegin = 35;
		this.hItem = 53;
		this.hContent = this.hSub - this.hBegin - 10;
		this.vecMenu.removeAllElements();
		bool flag3 = !GameCanvas.isTouch;
		if (flag3)
		{
			this.vecMenu.addElement(this.cmdMenu);
		}
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.cmdClose.setPos(this.xSub + 20 + this.wSub - 36, this.ySub + 16 + 8, MainTab.fraCloseTab, string.Empty);
		}
		else
		{
			this.vecMenu.addElement(this.cmdClose);
		}
		this.cmdInfoPlayer.indexMenu = 7;
		this.cmdInfoPlayer.subIndex = -1;
		for (int i = 0; i < this.vecPlayer.size(); i++)
		{
			InfoMemList infoMemList = (InfoMemList)this.vecPlayer.elementAt(i);
			bool flag4 = infoMemList.quaNapThe.statusNhan == 0;
			iCommand iCommand;
			if (flag4)
			{
				iCommand = new iCommand(T.view, 7, i, this);
			}
			else
			{
				bool flag5 = infoMemList.quaNapThe.statusNhan == 1;
				if (flag5)
				{
					iCommand = new iCommand(T.nhanQuest, 8, i, this);
					iCommand.setTypeGreen();
				}
				else
				{
					iCommand = new iCommand(T.daNhan, 9, i, this);
					iCommand.setTypeRed();
				}
			}
			iCommand.setPos(this.xSub + 150, this.ySub + this.hBegin + this.hItem * i + 28 + 11, AvMain.fraCmdNhanNapThe, iCommand.caption);
			this.vecCmd.addElement(iCommand);
			bool flag6 = this.wCmdNhan == 0;
			if (flag6)
			{
				this.wCmdNhan = iCommand.wimgCmd;
			}
		}
		base.setPosVecMenu(this.vecMenu);
		this.scroll.setInfo(this.xSub + this.wSub - 20 + this.miniItem, this.ySub + this.hBegin - 1, this.hContent - this.miniItem, 8809550);
	}

	// Token: 0x06000F7A RID: 3962 RVA: 0x001296C8 File Offset: 0x001278C8
	public void setCmdDaNhanIndex(sbyte id)
	{
		iCommand iCommand = (iCommand)this.vecCmd.elementAt((int)id);
		iCommand.caption = T.daNhan;
		iCommand.indexMenu = 9;
		iCommand.setTypeGreen();
	}

	// Token: 0x06000F7B RID: 3963 RVA: 0x00129704 File Offset: 0x00127904
	public override void commandPointer(int index, int subIndex)
	{
		bool flag = index == 8;
		if (flag)
		{
			this.idSelect = subIndex;
			InfoMemList infoMemList = (InfoMemList)this.vecPlayer.elementAt(this.idSelect);
			GlobalService.gI().Send_Nhan_TichLuyCongDon(1, (short)infoMemList.quaNapThe.cost);
		}
		base.commandPointer(index, subIndex);
	}

	// Token: 0x06000F7C RID: 3964 RVA: 0x0000C938 File Offset: 0x0000AB38
	public override void doMenuTouchPlayer()
	{
		bool flag = this.vecPlayer.size() != 0;
		if (flag)
		{
			this.memCur = (InfoMemList)this.vecPlayer.elementAt(this.idSelect);
			bool flag2 = this.memCur != null;
			if (flag2)
			{
				mVector mVector = new mVector();
				mVector.addElement(this.cmdInfoPlayer);
				GameCanvas.menu.startAt(mVector, 2, T.info);
			}
		}
	}

	// Token: 0x06000F7D RID: 3965 RVA: 0x0012975C File Offset: 0x0012795C
	public override void doMenu()
	{
		mVector mVector = new mVector();
		string menu = T.menu;
		bool flag = this.vecPlayer.size() > 0;
		if (flag)
		{
			this.memCur = (InfoMemList)this.vecPlayer.elementAt(this.idSelect);
			bool flag2 = this.memCur != null && !GameCanvas.isTouch;
			if (flag2)
			{
				iCommand o = (iCommand)this.vecCmd.elementAt(this.idSelect);
				mVector.addElement(o);
			}
		}
		GameCanvas.menu.startAt(mVector, 2, menu);
	}

	// Token: 0x06000F7E RID: 3966 RVA: 0x001297F0 File Offset: 0x001279F0
	public override void paint(mGraphics g)
	{
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.paint(g);
		}
		bool flag2 = GameCanvas.currentScreen == GameCanvas.chatTabScr;
		if (!flag2)
		{
			GameCanvas.resetTrans(g);
			this.paintBg(g);
			this.cmdClose.paint(g, this.cmdClose.xCmd, this.cmdClose.yCmd);
			int num = this.xSub + 20;
			int num2 = this.ySub + this.hBegin;
			base.setClip(g);
			bool isLoad = this.isLoad;
			if (isLoad)
			{
				MsgDialog.fraImgWaiting.drawFrame(GameCanvas.gameTick / 6 % MsgDialog.fraImgWaiting.nFrame, this.xSub + this.wSub / 2, num2 + this.hItem, 0, 3, g);
			}
			else
			{
				bool flag3 = this.idSelect >= 0;
				if (flag3)
				{
					this.paintSelect(g, num, num2 - 1, this.wSub - 40);
				}
				for (int i = 0; i < this.vecPlayer.size(); i++)
				{
					bool flag4 = num2 - this.list.cmx + this.hItem >= this.hBegin + this.ySub && num2 - this.list.cmx - this.hItem <= this.hBegin + this.hContent + this.ySub;
					if (flag4)
					{
						InfoMemList mem = (InfoMemList)this.vecPlayer.elementAt(i);
						this.paintInfo(g, mem, num, num2, i, this.wSub - 40);
					}
					num2 += this.hItem;
				}
			}
			mGraphics.resetTransAndroid(g);
			g.restoreCanvas();
			GameCanvas.resetTrans(g);
			bool flag5 = this.list.cmxLim > 0;
			if (flag5)
			{
				this.scroll.paint(g);
			}
			bool flag6 = this.vecMenu != null;
			if (flag6)
			{
				for (int j = 0; j < this.vecMenu.size(); j++)
				{
					iCommand iCommand = (iCommand)this.vecMenu.elementAt(j);
					iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
				}
			}
			bool flag7 = this.right != null;
			if (flag7)
			{
				this.right.paint(g, this.right.xCmd, this.right.yCmd);
			}
		}
	}

	// Token: 0x06000F7F RID: 3967 RVA: 0x00129A78 File Offset: 0x00127C78
	public override void paintInfo(mGraphics g, InfoMemList mem, int xpaint, int ypaint, int i, int wsub)
	{
		bool flag = mem != null;
		if (flag)
		{
			g.setColor(14203529);
			g.fillRect(xpaint, ypaint, wsub, 59);
			g.setColor(11506025);
			g.fillRect(xpaint + 2, ypaint + 2, wsub - 4, 22);
			AvMain.FontBorderColor(g, T.vnd + " :", this.xSub + this.wSub / 2 - 2, ypaint + 2, 1, 1, 7);
			mFont.tahoma_7b_black.drawString(g, Interface_Game.ConvertNumToStr(mem.quaNapThe.rubyDaNap) + "K", this.xSub + this.wSub / 2 + 2, ypaint + 2, 0);
			ypaint += 11;
			AvMain.Font3dColor(g, string.Concat(new string[]
			{
				T.tichLuyNap,
				" ",
				Interface_Game.ConvertNumToStr(mem.quaNapThe.cost),
				"K ",
				T.vnd
			}), xpaint + wsub / 2, ypaint + 2, 2, 5);
			bool isTouch = GameCanvas.isTouch;
			if (isTouch)
			{
				iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
				iCommand.paintCmd1Frame(g, iCommand.xCmd, iCommand.yCmd);
			}
			int num = (!GameCanvas.isTouch) ? ((wsub - this.wPaintQua) / 2) : ((wsub - this.wPaintQua - this.wCmdNhan - 5) / 2);
			bool flag2 = num < 0;
			if (flag2)
			{
				num = 0;
			}
			int num2 = 29;
			bool flag3 = this.idSelect != i || ypaint - this.list.cmx + 16 <= this.ySub + this.hBegin || ypaint - this.list.cmx + 16 + num2 >= this.ySub + this.hBegin + this.hContent - this.miniItem;
			if (flag3)
			{
				mem.quaNapThe.isRun = false;
				mem.quaNapThe.paint(g, xpaint + num, ypaint + 2 + 14);
			}
			else
			{
				g.setClip(xpaint + num, ypaint, this.wPaintQua + 1, this.hItem);
				g.saveCanvas();
				g.ClipRec(xpaint + num, ypaint, this.wPaintQua + 1, this.hItem);
				mem.quaNapThe.isRun = true;
				mem.quaNapThe.paint(g, xpaint + num, ypaint + 2 + 14);
				g.restoreCanvas();
				base.setClip(g);
			}
		}
	}

	// Token: 0x06000F80 RID: 3968 RVA: 0x0000C23F File Offset: 0x0000A43F
	public override void paintSelect(mGraphics g, int xbegin, int ybegin, int wFocus)
	{
		g.setColor(11936290);
		g.drawRect(xbegin - 1, ybegin + this.idSelect * this.hItem, wFocus + 1, 60);
	}

	// Token: 0x06000F81 RID: 3969 RVA: 0x00129CF8 File Offset: 0x00127EF8
	public override void paintBg(mGraphics g)
	{
		base.paintPaper(g, this.xSub, this.ySub, this.wSub, this.hSub, this.wSub, (int)AvMain.PAPER_NORMAL);
		g.setColor(15972174);
		g.fillRoundRect(this.xSub + 20, this.ySub + 16, this.wSub - 40, 16, 4, 4);
		AvMain.FontBorderColor(g, this.nameList, this.xSub + this.wSub / 2, this.ySub + 18, 2, 6, 5);
	}

	// Token: 0x06000F82 RID: 3970 RVA: 0x00129D8C File Offset: 0x00127F8C
	public override void update()
	{
		base.update();
		for (int i = 0; i < this.vecPlayer.size(); i++)
		{
			InfoMemList infoMemList = (InfoMemList)this.vecPlayer.elementAt(i);
			infoMemList.quaNapThe.update();
		}
		this.scroll.setYScrool(this.list.cmx, this.list.cmxLim);
	}

	// Token: 0x06000F83 RID: 3971 RVA: 0x00129E00 File Offset: 0x00128000
	public override void updatePointer()
	{
		this.list.update_Pos_UP_DOWN();
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			bool flag = this.left != null;
			if (flag)
			{
				bool flag2 = this.left.isPosCmd();
				if (flag2)
				{
					this.left.updatePointer();
				}
				else
				{
					bool flag3 = GameCanvas.isPointSelect(0, MotherCanvas.h - GameCanvas.hCommand - 5, GameCanvas.wCommand * 2, GameCanvas.hCommand + 10);
					if (flag3)
					{
						this.left.perform();
					}
				}
			}
			bool flag4 = this.right != null;
			if (flag4)
			{
				bool flag5 = this.right.isPosCmd();
				if (flag5)
				{
					this.right.updatePointer();
				}
				else
				{
					bool flag6 = GameCanvas.isPointSelect(MotherCanvas.w - GameCanvas.wCommand * 2, MotherCanvas.h - GameCanvas.hCommand - 5, GameCanvas.wCommand * 2, GameCanvas.hCommand + 10);
					if (flag6)
					{
						this.right.perform();
					}
				}
			}
			bool flag7 = this.center != null;
			if (flag7)
			{
				bool flag8 = this.center.isPosCmd();
				if (flag8)
				{
					this.center.updatePointer();
				}
				else
				{
					bool flag9 = GameCanvas.isPointSelect(MotherCanvas.hw - GameCanvas.wCommand, MotherCanvas.h - GameCanvas.hCommand - 5, GameCanvas.wCommand * 2, GameCanvas.hCommand + 10);
					if (flag9)
					{
						this.center.perform();
					}
				}
			}
		}
		bool flag10 = this.vecMenu != null;
		if (flag10)
		{
			for (int i = 0; i < this.vecMenu.size(); i++)
			{
				iCommand iCommand = (iCommand)this.vecMenu.elementAt(i);
				iCommand.updatePointer();
			}
		}
		for (int j = 0; j < this.vecCmd.size(); j++)
		{
			int yBtn = this.ySub + this.hBegin + this.hItem * j + 28 - this.list.cmx;
			iCommand iCommand2 = (iCommand)this.vecCmd.elementAt(j);
			iCommand2.updatePointerNapThe(this.xSub + 150, yBtn);
		}
		bool flag11 = !GameCanvas.isPointerSelect || this.vecPlayer.size() <= 0 || !GameCanvas.isPoint(this.xSub, this.ySub + this.hBegin, this.wSub, this.hContent);
		if (!flag11)
		{
			GameCanvas.isPointerSelect = false;
			int num = (GameCanvas.py - (this.ySub + this.hBegin) + this.list.cmx) / this.hItem;
			bool flag12 = num >= 0 && num < this.vecPlayer.size();
			if (flag12)
			{
				bool flag13 = this.idSelect != num;
				if (flag13)
				{
					this.idSelect = num;
				}
				else
				{
					this.doMenuTouchPlayer();
				}
			}
		}
	}

	// Token: 0x06000F84 RID: 3972 RVA: 0x000D9530 File Offset: 0x000D7730
	public override void setCamera()
	{
		int limX = this.vecPlayer.size() * this.hItem - this.hContent + 2;
		this.list = new ListNew(this.xSub + 20, this.ySub + GameCanvas.hCommand, this.wSub - 40, this.hContent, 0, 0, limX, true);
		this.list.setToX((this.idSelect + 1) * this.hItem - this.hContent / 2);
	}

	// Token: 0x06000F85 RID: 3973 RVA: 0x0012A0F0 File Offset: 0x001282F0
	public void setUpdateCostRuby(short cost, int ruby)
	{
		for (int i = 0; i < this.vecPlayer.size(); i++)
		{
			InfoMemList infoMemList = (InfoMemList)this.vecPlayer.elementAt(i);
			bool flag = infoMemList.quaNapThe.cost == (int)cost;
			if (flag)
			{
				infoMemList.quaNapThe.rubyDaNap = ruby;
				break;
			}
		}
	}

	// Token: 0x04001A01 RID: 6657
	public const sbyte TYPE_LIST = 0;

	// Token: 0x04001A02 RID: 6658
	public const sbyte TYPE_NHAN = 1;

	// Token: 0x04001A03 RID: 6659
	public const sbyte TYPE_DA_NHAN = 2;

	// Token: 0x04001A04 RID: 6660
	public static TichLuyCongDonScr instance;

	// Token: 0x04001A05 RID: 6661
	private mVector vecCmd = new mVector();

	// Token: 0x04001A06 RID: 6662
	private int wCmdNhan;

	// Token: 0x04001A07 RID: 6663
	private Scroll scroll = new Scroll();

	// Token: 0x04001A08 RID: 6664
	private int wPaintQua = 93;
}
