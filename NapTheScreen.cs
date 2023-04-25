using System;

// Token: 0x020000BA RID: 186
public class NapTheScreen : PaintListScreen
{
	// Token: 0x06000B26 RID: 2854 RVA: 0x000D87C8 File Offset: 0x000D69C8
	public NapTheScreen(mVector vec, int ruby) : base(0, vec, T.nameListNapThe, 200, 180)
	{
		this.rubyDaNap = ruby;
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
		this.hBegin = 55;
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
					iCommand.setTypeRed();
				}
				else
				{
					iCommand = new iCommand(T.daNhan, 9, i, this);
					iCommand.setTypeGreen();
				}
			}
			iCommand.setPos(this.xSub + 150, this.ySub + this.hBegin + this.hItem * i + 28, AvMain.fraCmdNhanNapThe, iCommand.caption);
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

	// Token: 0x06000B27 RID: 2855 RVA: 0x000D8A7C File Offset: 0x000D6C7C
	public void setCmdDaNhanIndex(sbyte id)
	{
		iCommand iCommand = (iCommand)this.vecCmd.elementAt((int)id);
		iCommand.caption = T.daNhan;
		iCommand.indexMenu = 9;
		iCommand.setTypeGreen();
	}

	// Token: 0x06000B28 RID: 2856 RVA: 0x000D8AB8 File Offset: 0x000D6CB8
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 7:
		{
			bool flag = subIndex != -1;
			if (flag)
			{
				this.idSelect = subIndex;
			}
			InfoMemList mem = (InfoMemList)this.vecPlayer.elementAt(this.idSelect);
			NapTheInfo.instance = new NapTheInfo(this.type, mem);
			NapTheInfo.instance.Show(GameCanvas.gameScr);
			break;
		}
		case 8:
		{
			this.idSelect = subIndex;
			InfoMemList infoMemList = (InfoMemList)this.vecPlayer.elementAt(this.idSelect);
			GlobalService.gI().Send_Nhan_NapTheScr(1, (sbyte)infoMemList.id);
			break;
		}
		case 9:
		{
			this.idSelect = subIndex;
			InfoMemList infoMemList2 = (InfoMemList)this.vecPlayer.elementAt(this.idSelect);
			GlobalService.gI().Send_Nhan_NapTheScr(1, (sbyte)infoMemList2.id);
			break;
		}
		}
		base.commandPointer(index, subIndex);
	}

	// Token: 0x06000B29 RID: 2857 RVA: 0x0000C938 File Offset: 0x0000AB38
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

	// Token: 0x06000B2A RID: 2858 RVA: 0x000D8BA8 File Offset: 0x000D6DA8
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

	// Token: 0x06000B2B RID: 2859 RVA: 0x000D8C3C File Offset: 0x000D6E3C
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

	// Token: 0x06000B2C RID: 2860 RVA: 0x000D8EC4 File Offset: 0x000D70C4
	public override void paintInfo(mGraphics g, InfoMemList mem, int xpaint, int ypaint, int i, int wsub)
	{
		bool flag = mem != null;
		if (flag)
		{
			g.setColor(14203529);
			g.fillRect(xpaint, ypaint, wsub, 48);
			g.setColor(11506025);
			g.fillRect(xpaint + 2, ypaint + 2, wsub - 4, 11);
			AvMain.Font3dColor(g, string.Concat(new string[]
			{
				T.tichLuyNap,
				" ",
				Interface_Game.ConvertNumToStr(mem.quaNapThe.cost),
				" ",
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

	// Token: 0x06000B2D RID: 2861 RVA: 0x0000B79D File Offset: 0x0000999D
	public override void paintSelect(mGraphics g, int xbegin, int ybegin, int wFocus)
	{
		g.setColor(11936290);
		g.drawRect(xbegin - 1, ybegin + this.idSelect * this.hItem, wFocus + 1, 49);
	}

	// Token: 0x06000B2E RID: 2862 RVA: 0x000D90D4 File Offset: 0x000D72D4
	public override void paintBg(mGraphics g)
	{
		base.paintPaper(g, this.xSub, this.ySub, this.wSub, this.hSub, this.wSub, (int)AvMain.PAPER_NORMAL);
		g.setColor(15972174);
		g.fillRoundRect(this.xSub + 20, this.ySub + 16, this.wSub - 40, 16, 4, 4);
		AvMain.FontBorderColor(g, this.nameList, this.xSub + this.wSub / 2, this.ySub + 18, 2, 6, 5);
		AvMain.FontBorderColor(g, T.vnd + " :", this.xSub + this.wSub / 2 - 2, this.ySub + 37, 1, 1, 7);
		mFont.tahoma_7b_black.drawString(g, Interface_Game.ConvertNumToStr(this.rubyDaNap), this.xSub + this.wSub / 2 + 2, this.ySub + 38, 0);
	}

	// Token: 0x06000B2F RID: 2863 RVA: 0x000D91CC File Offset: 0x000D73CC
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

	// Token: 0x06000B30 RID: 2864 RVA: 0x000D9240 File Offset: 0x000D7440
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

	// Token: 0x06000B31 RID: 2865 RVA: 0x000D9530 File Offset: 0x000D7730
	public override void setCamera()
	{
		int limX = this.vecPlayer.size() * this.hItem - this.hContent + 2;
		this.list = new ListNew(this.xSub + 20, this.ySub + GameCanvas.hCommand, this.wSub - 40, this.hContent, 0, 0, limX, true);
		this.list.setToX((this.idSelect + 1) * this.hItem - this.hContent / 2);
	}

	// Token: 0x040010BA RID: 4282
	public const sbyte TYPE_LIST = 0;

	// Token: 0x040010BB RID: 4283
	public const sbyte TYPE_NHAN = 1;

	// Token: 0x040010BC RID: 4284
	public const sbyte TYPE_DA_NHAN = 2;

	// Token: 0x040010BD RID: 4285
	public static NapTheScreen instance;

	// Token: 0x040010BE RID: 4286
	private int rubyDaNap;

	// Token: 0x040010BF RID: 4287
	private mVector vecCmd = new mVector();

	// Token: 0x040010C0 RID: 4288
	private int wCmdNhan;

	// Token: 0x040010C1 RID: 4289
	private Scroll scroll = new Scroll();

	// Token: 0x040010C2 RID: 4290
	private int wPaintQua = 93;
}
