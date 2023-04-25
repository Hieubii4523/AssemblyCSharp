using System;

// Token: 0x02000008 RID: 8
public class AuctionScreen : PaintListScreen
{
	// Token: 0x06000013 RID: 19 RVA: 0x0000C450 File Offset: 0x0000A650
	public AuctionScreen(mVector vec) : base(0, vec, string.Empty, 320, 200)
	{
		this.wSub = MotherCanvas.w - 148 - 40;
		int num = 0;
		bool flag = GameCanvas.isTouch && this.wSub < 250;
		if (flag)
		{
			num = (250 - this.wSub) / 2;
			this.wSub = 250;
		}
		bool flag2 = !GameCanvas.isTouch;
		if (flag2)
		{
			this.wSub = MotherCanvas.w - 20;
			this.yLechCmd = 10;
			this.ySub += 10;
		}
		this.col[0] = 0;
		this.col[1] = this.wSub / 9 * 3;
		this.col[2] = this.col[1] + this.wSub / 9 * 2;
		this.col[3] = this.col[2] + this.wSub / 9 * 2;
		this.xSub = MotherCanvas.hw - this.wSub / 2 - num;
		this.hBegin = 35;
		this.hItem = 38;
		this.hContent = this.hSub - this.hBegin - 10;
		this.textrong = T.danhSachTrong;
		this.timeBegin = mSystem.currentTimeMillis();
		this.cmdInfoPlayer.indexMenu = 10;
		this.vecMenu.removeAllElements();
		bool flag3 = !GameCanvas.isTouch;
		if (flag3)
		{
			this.vecMenu.addElement(this.cmdMenu);
		}
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.cmdClose.setPos(this.xSub + this.wSub, this.ySub + 11 + 8, MainTab.fraCloseTab, string.Empty);
		}
		else
		{
			this.vecMenu.addElement(this.cmdClose);
		}
		base.setPosVecMenu(this.vecMenu);
		this.strShow = new string[this.vecPlayer.size()][];
		for (int i = 0; i < this.vecPlayer.size(); i++)
		{
			InfoMemList infoMemList = (InfoMemList)this.vecPlayer.elementAt(i);
			iCommand iCommand = new iCommand(T.dauGia, 7, i, this);
			iCommand.setPos(this.xSub + this.col[1] + 26 + 10, this.ySub + this.hBegin + (this.hItem + this.gap) * i + 26, AvMain.fraCmdNhanNapThe, iCommand.caption);
			bool flag4 = infoMemList.isOwn == 1;
			if (flag4)
			{
				iCommand.setTypeRed();
			}
			this.vecCmdDauGia.addElement(iCommand);
			iCommand iCommand2 = new iCommand(T.cmdBuy, 8, i, this);
			iCommand2.setPos(this.xSub + this.col[2] + 26 + 10, this.ySub + this.hBegin + (this.hItem + this.gap) * i + 26, AvMain.fraCmdNhanNapThe, iCommand2.caption);
			this.vecCmdGiaChot.addElement(iCommand2);
			iCommand iCommand3 = new iCommand(T.nhanQuest, 9, i, this);
			iCommand3.setPos(this.xSub + this.col[1] + 26 + 10, this.ySub + this.hBegin + (this.hItem + this.gap) * i + 26, AvMain.fraCmdNhanNapThe, iCommand3.caption);
			iCommand3.setTypeGreen();
			this.vecCmdNhan.addElement(iCommand3);
			this.strShow[i] = mFont.tahoma_7b_brown.splitFontArray(infoMemList.item.name, this.col[1] - 5 - this.sizeItem);
		}
	}

	// Token: 0x06000014 RID: 20 RVA: 0x0000C84C File Offset: 0x0000AA4C
	public override void commandPointer(int index, int subIndex)
	{
		InfoMemList infoMemList = (InfoMemList)this.vecPlayer.elementAt(subIndex);
		switch (index)
		{
		case 2:
			GlobalService.gI().Send_Type(-91, 4);
			break;
		case 7:
			GlobalService.gI().Send_Type_ID(-91, 1, (sbyte)infoMemList.id);
			break;
		case 8:
			GlobalService.gI().Send_Type_ID(-91, 3, (sbyte)infoMemList.id);
			break;
		case 9:
			GlobalService.gI().Send_Type_ID(-91, 2, (sbyte)infoMemList.id);
			break;
		case 10:
			infoMemList = (InfoMemList)this.vecPlayer.elementAt(this.idSelect);
			ItemInfo.instance = new ItemInfo(this.type, infoMemList);
			ItemInfo.instance.Show(this);
			break;
		}
		base.commandPointer(index, subIndex);
	}

	// Token: 0x06000015 RID: 21 RVA: 0x0000C938 File Offset: 0x0000AB38
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

	// Token: 0x06000016 RID: 22 RVA: 0x0000C9AC File Offset: 0x0000ABAC
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
				mVector.addElement(this.cmdInfoPlayer);
				bool flag3 = this.memCur.isOwn == 1;
				if (flag3)
				{
					iCommand o = (iCommand)this.vecCmdNhan.elementAt(this.idSelect);
					mVector.addElement(o);
				}
				iCommand o2 = (iCommand)this.vecCmdDauGia.elementAt(this.idSelect);
				iCommand o3 = (iCommand)this.vecCmdGiaChot.elementAt(this.idSelect);
				mVector.addElement(o2);
				mVector.addElement(o3);
			}
		}
		GameCanvas.menu.startAt(mVector, 2, menu);
	}

	// Token: 0x06000017 RID: 23 RVA: 0x0000CAAC File Offset: 0x0000ACAC
	public override void paint(mGraphics g)
	{
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.paint(g);
		}
		GameCanvas.resetTrans(g);
		this.paintBg(g);
		this.cmdClose.paint(g, this.cmdClose.xCmd, this.cmdClose.yCmd);
		int num = this.xSub + 10;
		int num2 = this.ySub + this.hBegin;
		base.setClip(g);
		bool flag2 = this.vecPlayer.size() == 0;
		if (flag2)
		{
			mFont.tahoma_7_black.drawString(g, this.textrong, this.xSub + this.wSub / 2, this.ySub + (this.hSub - 20) / 2, 2);
		}
		else
		{
			bool flag3 = this.idSelect >= 0;
			if (flag3)
			{
				this.paintSelect(g, num, num2 - 1, this.wSub - 20);
			}
			for (int i = 0; i < this.vecPlayer.size(); i++)
			{
				bool flag4 = num2 - this.list.cmx + this.hItem >= this.hBegin + this.ySub && num2 - this.list.cmx - this.hItem <= this.hBegin + this.hContent + this.ySub;
				if (flag4)
				{
					InfoMemList mem = (InfoMemList)this.vecPlayer.elementAt(i);
					this.paintInfo(g, mem, num, num2, i, this.wSub - 20);
				}
				num2 += this.hItem + this.gap;
			}
		}
		mGraphics.resetTransAndroid(g);
		g.restoreCanvas();
		GameCanvas.resetTrans(g);
		bool flag5 = this.vecMenu != null;
		if (flag5)
		{
			for (int j = 0; j < this.vecMenu.size(); j++)
			{
				iCommand iCommand = (iCommand)this.vecMenu.elementAt(j);
				iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
			}
		}
		bool flag6 = this.right != null;
		if (flag6)
		{
			this.right.paint(g, this.right.xCmd, this.right.yCmd);
		}
		MainTab.paintMoney(g, MotherCanvas.w - 78, 4 + GameScreen.h12plus);
		for (int k = 0; k < AuctionScreen.vecEff.size(); k++)
		{
			MainEffect mainEffect = (MainEffect)AuctionScreen.vecEff.elementAt(k);
			bool flag7 = mainEffect != null && !mainEffect.isRemove && !mainEffect.isStop;
			if (flag7)
			{
				mainEffect.paint(g);
			}
		}
	}

	// Token: 0x06000018 RID: 24 RVA: 0x0000CD7C File Offset: 0x0000AF7C
	public override void paintInfo(mGraphics g, InfoMemList mem, int xpaint, int ypaint, int i, int wpaint)
	{
		bool flag = mem == null;
		if (!flag)
		{
			g.setColor(14203529);
			base.paintBgMemListPhatLenh(g, xpaint, ypaint, wpaint, this.hItem);
			mem.item.paint(g, xpaint + 4 + this.sizeItem / 2, ypaint + 4 + this.sizeItem / 2, this.sizeItem);
			bool flag2 = this.yLechCmd == 0 && this.strShow[i] != null;
			if (flag2)
			{
				int num = ypaint + 5;
				for (int j = 0; j < this.strShow[i].Length; j++)
				{
					mFont.tahoma_7b_brown.drawString(g, this.strShow[i][j], xpaint + 2 + 33, num, 0);
					num += 12;
				}
			}
			int num2 = xpaint;
			bool flag3 = !GameCanvas.isTouch;
			if (flag3)
			{
				num2 = this.xSub;
			}
			AvMain.fraMoney.drawFrame(8, num2 + this.col[1] + 2, ypaint + 2 + this.yLechCmd, 0, 0, g);
			AvMain.Font3dColor(g, mem.item.priceDauGia.ToString() + string.Empty, num2 + this.col[1] + 15, ypaint + 3 + this.yLechCmd, 0, 5);
			mFont mFont = mFont.tahoma_7b_black;
			bool isSmallScreen = GameCanvas.isSmallScreen;
			if (isSmallScreen)
			{
				mFont = mFont.tahoma_7_black;
			}
			bool flag4 = mem.item.timeRemain == -1;
			if (flag4)
			{
				mFont.tahoma_7b_red.drawString(g, T.chuaMo, num2 + this.col[3] + (wpaint - this.col[3]) / 2, ypaint + 13, 2);
			}
			else
			{
				mFont.drawString(g, Interface_Game.ConvertTimeToStr(mem.item.timeRemain), num2 + this.col[3] + (wpaint - this.col[3]) / 2, ypaint + 13, 2);
			}
			bool flag5 = mem.item.giaChot > 0;
			if (flag5)
			{
				AvMain.fraMoney.drawFrame(8, num2 + this.col[2] + 2, ypaint + 2 + this.yLechCmd, 0, 0, g);
				AvMain.Font3dColor(g, mem.item.giaChot.ToString() + string.Empty, num2 + this.col[2] + 15, ypaint + 3 + this.yLechCmd, 0, 5);
			}
			else
			{
				mFont.tahoma_7_black.drawString(g, "---", num2 + this.col[2] + 26, ypaint + 13, 2);
			}
			bool isTouch = GameCanvas.isTouch;
			if (isTouch)
			{
				bool flag6 = mem.item.timeRemain > 0 || mem.isOwn == 0;
				if (flag6)
				{
					iCommand iCommand = (iCommand)this.vecCmdDauGia.elementAt(i);
					iCommand.paintCmd1Frame(g, iCommand.xCmd, iCommand.yCmd);
				}
				else
				{
					bool flag7 = mem.isOwn == 1;
					if (flag7)
					{
						iCommand iCommand2 = (iCommand)this.vecCmdNhan.elementAt(i);
						iCommand2.paintCmd1Frame(g, iCommand2.xCmd, iCommand2.yCmd);
					}
				}
				bool flag8 = mem.item.giaChot > 0;
				if (flag8)
				{
					iCommand iCommand3 = (iCommand)this.vecCmdGiaChot.elementAt(i);
					iCommand3.paintCmd1Frame(g, iCommand3.xCmd, iCommand3.yCmd);
				}
			}
			bool flag9 = mem.item.timeRemain <= 0 && mem.item.timeRemain != -1;
			if (flag9)
			{
				g.drawImage(AvMain.imgComplete, xpaint + this.sizeItem + 8, ypaint + 1, 0);
			}
		}
	}

	// Token: 0x06000019 RID: 25 RVA: 0x0000906E File Offset: 0x0000726E
	public override void paintSelect(mGraphics g, int xbegin, int ybegin, int wFocus)
	{
		g.setColor(11936290);
		g.drawRect(xbegin - 1, ybegin + this.idSelect * (this.hItem + this.gap), wFocus + 1, this.hItem + 1);
	}

	// Token: 0x0600001A RID: 26 RVA: 0x0000D124 File Offset: 0x0000B324
	public override void paintBg(mGraphics g)
	{
		base.paintPaper(g, this.xSub, this.ySub, this.wSub, this.hSub, this.wSub, (int)AvMain.PAPER_NORMAL);
		g.setColor(15972174);
		g.fillRoundRect(this.xSub + 5, this.ySub + 12, this.wSub - 10, 16, 4, 4);
		AvMain.FontBorderColor(g, (!GameCanvas.isTouch) ? T.tenVP : T.tenVatPham, this.xSub + this.col[0] + (this.col[1] - this.col[0]) / 2, this.ySub + 14, 2, 6, 5);
		AvMain.FontBorderColor(g, (!GameCanvas.isTouch) ? T.dGia : T.dauGia, this.xSub + this.col[1] + (this.col[2] - this.col[1]) / 2, this.ySub + 14, 2, 6, 5);
		AvMain.FontBorderColor(g, (!GameCanvas.isTouch) ? T.gChot : T.giaChot, this.xSub + this.col[2] + (this.col[3] - this.col[2]) / 2, this.ySub + 14, 2, 6, 5);
		AvMain.FontBorderColor(g, (!GameCanvas.isTouch) ? T.tGian : T.thoiGianCon, this.xSub + this.col[3] + (this.wSub - this.col[3]) / 2 - 5, this.ySub + 14, 2, 6, 5);
	}

	// Token: 0x0600001B RID: 27 RVA: 0x0000D2B4 File Offset: 0x0000B4B4
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
		for (int j = 0; j < this.vecPlayer.size(); j++)
		{
			InfoMemList infoMemList = (InfoMemList)this.vecPlayer.elementAt(j);
			bool flag11 = infoMemList.item.timeRemain > 0;
			if (flag11)
			{
				iCommand iCommand2 = (iCommand)this.vecCmdDauGia.elementAt(j);
				iCommand2.updatePointerInList(this.list.cmx);
				bool flag12 = infoMemList.item.giaChot > 0;
				if (flag12)
				{
					iCommand2 = (iCommand)this.vecCmdGiaChot.elementAt(j);
					iCommand2.updatePointerInList(this.list.cmx);
				}
			}
			else
			{
				bool flag13 = infoMemList.isOwn == 1;
				if (flag13)
				{
					iCommand iCommand3 = (iCommand)this.vecCmdNhan.elementAt(j);
					iCommand3.updatePointerInList(this.list.cmx);
				}
			}
		}
		bool flag14 = !GameCanvas.isPointerSelect || this.vecPlayer.size() <= 0 || !GameCanvas.isPoint(this.xSub, this.ySub + this.hBegin, this.wSub, this.hContent);
		if (!flag14)
		{
			GameCanvas.isPointerSelect = false;
			int num = (GameCanvas.py - (this.ySub + this.hBegin) + this.list.cmx) / (this.hItem + this.gap);
			bool flag15 = num >= 0 && num < this.vecPlayer.size();
			if (flag15)
			{
				bool flag16 = this.idSelect != num;
				if (flag16)
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

	// Token: 0x0600001C RID: 28 RVA: 0x0000D628 File Offset: 0x0000B828
	public override void setCamera()
	{
		int limX = this.vecPlayer.size() * (this.hItem + this.gap) - this.hContent + this.miniItem;
		this.list = new ListNew(this.xSub + 10, this.ySub + this.hBegin, this.wSub - 20, this.hContent, 0, 0, limX, true);
		this.list.setToX((this.idSelect + 1) * (this.hItem + this.gap) - this.hContent / 2);
	}

	// Token: 0x0600001D RID: 29 RVA: 0x0000D6C0 File Offset: 0x0000B8C0
	public override void update()
	{
		base.update();
		bool flag = GameCanvas.timeNow - this.timeBegin >= 1000L;
		if (flag)
		{
			this.timeBegin += 1000L;
			for (int i = 0; i < this.vecPlayer.size(); i++)
			{
				InfoMemList infoMemList = (InfoMemList)this.vecPlayer.elementAt(i);
				bool flag2 = infoMemList.item.timeRemain > 0;
				if (flag2)
				{
					infoMemList.item.timeRemain--;
				}
			}
		}
		for (int j = 0; j < AuctionScreen.vecEff.size(); j++)
		{
			MainEffect mainEffect = (MainEffect)AuctionScreen.vecEff.elementAt(j);
			bool flag3 = mainEffect != null && !mainEffect.isRemove && !mainEffect.isStop;
			if (flag3)
			{
				mainEffect.update();
			}
		}
	}

	// Token: 0x0600001E RID: 30 RVA: 0x0000D7BC File Offset: 0x0000B9BC
	public void SetNewValueDauGia(sbyte id, short idPlayer, int curPrice, int time)
	{
		mSystem.outz(string.Concat(new string[]
		{
			"id = ",
			id.ToString(),
			" Set new value dau gia = ",
			curPrice.ToString(),
			" time = ",
			time.ToString()
		}));
		for (int i = 0; i < this.vecPlayer.size(); i++)
		{
			InfoMemList infoMemList = (InfoMemList)this.vecPlayer.elementAt(i);
			bool flag = infoMemList.id == (int)id;
			if (flag)
			{
				bool flag2 = idPlayer == GameScreen.player.ID;
				if (flag2)
				{
					infoMemList.isOwn = 1;
					iCommand iCommand = (iCommand)this.vecCmdDauGia.elementAt(i);
					iCommand.setTypeRed();
				}
				else
				{
					infoMemList.isOwn = 0;
					iCommand iCommand2 = (iCommand)this.vecCmdDauGia.elementAt(i);
					iCommand2.setTypeButton(iCommand.BTT_NOR);
				}
				infoMemList.item.priceDauGia = curPrice;
				infoMemList.item.timeRemain = time;
				break;
			}
		}
	}

	// Token: 0x0600001F RID: 31 RVA: 0x0000D8D0 File Offset: 0x0000BAD0
	public static void addEffectNumImage(string content, int x, int y, sbyte typeColor, FrameImage fra, int frame)
	{
		EffectNum effectNum = new EffectNum(content, x, y, (int)typeColor, fra, frame);
		int num = GameScreen.find_Index_Stop(AuctionScreen.vecEff);
		bool flag = num == AuctionScreen.vecEff.size();
		if (flag)
		{
			AuctionScreen.vecEff.addElement(effectNum);
		}
		else
		{
			AuctionScreen.vecEff.setElementAt(effectNum, num);
		}
	}

	// Token: 0x04000002 RID: 2
	public const sbyte TYPE_LIST = 0;

	// Token: 0x04000003 RID: 3
	public const sbyte TYPE_DAU_GIA = 1;

	// Token: 0x04000004 RID: 4
	public const sbyte TYPE_NHAN = 2;

	// Token: 0x04000005 RID: 5
	public const sbyte TYPE_GIA_CHOT = 3;

	// Token: 0x04000006 RID: 6
	public const sbyte TYPE_CLOSE = 4;

	// Token: 0x04000007 RID: 7
	public static AuctionScreen instance;

	// Token: 0x04000008 RID: 8
	private mVector vecCmdDauGia = new mVector();

	// Token: 0x04000009 RID: 9
	private mVector vecCmdGiaChot = new mVector();

	// Token: 0x0400000A RID: 10
	private mVector vecCmdNhan = new mVector();

	// Token: 0x0400000B RID: 11
	public static mVector vecEff = new mVector();

	// Token: 0x0400000C RID: 12
	private int[] col = new int[4];

	// Token: 0x0400000D RID: 13
	private int yLechCmd;

	// Token: 0x0400000E RID: 14
	private int sizeItem = 29;

	// Token: 0x0400000F RID: 15
	private long timeBegin;

	// Token: 0x04000010 RID: 16
	private string[][] strShow;

	// Token: 0x04000011 RID: 17
	private int gap = 2;
}
