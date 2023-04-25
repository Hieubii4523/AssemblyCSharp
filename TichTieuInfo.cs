using System;

// Token: 0x0200010A RID: 266
public class TichTieuInfo : SubScreen
{
	// Token: 0x06000F86 RID: 3974 RVA: 0x0012A150 File Offset: 0x00128350
	public TichTieuInfo(sbyte type, InfoMemList mem) : base(type)
	{
		this.mem = mem;
		bool flag = TichTieuScreen.instance.wSub > 180;
		if (flag)
		{
			this.wSub = TichTieuScreen.instance.wSub - 20;
		}
		else
		{
			this.wSub = TichTieuScreen.instance.wSub;
		}
		this.hSub = TichTieuScreen.instance.hSub;
		this.xSub = MotherCanvas.hw - this.wSub / 2;
		this.ySub = MotherCanvas.hh - this.hSub / 2;
		this.idCommand = 0;
		this.idSelect = 0;
		this.hItem = 29;
		this.miniItem = 5;
		this.hContent = this.hSub - 80 - iCommand.hButtonCmdNor;
		this.cmdClose = new iCommand(T.close, -1, this);
		this.vecMenu.removeAllElements();
		this.vecMenu.addElement(this.cmdClose);
		this.setPosCmdNew(0, this.vecMenu);
		int limX = (int)mem.quaNapThe.numQua * this.hItem - this.hContent + this.miniItem * 2;
		this.list = new ListNew(this.xSub + 10, this.ySub + 68, this.wSub - 20 - this.miniItem, this.hContent, 0, 0, limX, true);
		this.scroll.setInfo(this.xSub + this.wSub - 10, this.ySub + 69, this.hContent, 8809550);
		for (int i = 0; i < mem.quaNapThe.vecQua.size(); i++)
		{
			ItemQuaNT itemQuaNT = (ItemQuaNT)mem.quaNapThe.vecQua.elementAt(i);
			itemQuaNT.strShow = mFont.tahoma_7_white.splitFontArray(itemQuaNT.numPotion.ToString() + " " + itemQuaNT.name, this.wSub - 70);
		}
	}

	// Token: 0x06000F87 RID: 3975 RVA: 0x0012A364 File Offset: 0x00128564
	public override void commandPointer(int index, int subIndex)
	{
		if (index != -1)
		{
			if (index == 0)
			{
				GlobalService.gI().Send_Nhan_TichTieuScr(1, (sbyte)this.mem.id);
			}
		}
		else
		{
			TichTieuScreen.instance.Show(GameCanvas.gameScr);
		}
	}

	// Token: 0x06000F88 RID: 3976 RVA: 0x0012A3B0 File Offset: 0x001285B0
	public override void paint(mGraphics g)
	{
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.paint(g);
		}
		GameCanvas.resetTrans(g);
		this.paintBg(g, this.xSub + 10, this.ySub + 38);
		this.setClip(g);
		this.paintInfo(g, this.xSub + 10, this.ySub + 73);
		GameCanvas.resetTrans(g);
		mGraphics.resetTransAndroid(g);
		g.restoreCanvas();
		GameCanvas.resetTrans(g);
		bool flag2 = this.list.cmxLim > 0;
		if (flag2)
		{
			this.scroll.paint(g);
		}
		bool flag3 = this.vecMenu != null;
		if (flag3)
		{
			for (int i = 0; i < this.vecMenu.size(); i++)
			{
				iCommand iCommand = (iCommand)this.vecMenu.elementAt(i);
				iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
			}
		}
	}

	// Token: 0x06000F89 RID: 3977 RVA: 0x0012A4B4 File Offset: 0x001286B4
	private void paintInfo(mGraphics g, int xpaint, int ypaint)
	{
		bool flag = this.mem != null;
		if (flag)
		{
			for (int i = 0; i < (int)this.mem.quaNapThe.numQua; i++)
			{
				ItemQuaNT itemQuaNT = (ItemQuaNT)this.mem.quaNapThe.vecQua.elementAt(i);
				itemQuaNT.paintInfo(g, xpaint + this.miniItem, ypaint);
				ypaint += this.hItem;
			}
		}
	}

	// Token: 0x06000F8A RID: 3978 RVA: 0x0012A52C File Offset: 0x0012872C
	private void paintBg(mGraphics g, int xpaint, int ypaint)
	{
		base.paintPaper(g, this.xSub, this.ySub, this.wSub, this.hSub, this.wSub, (int)AvMain.PAPER_NORMAL);
		g.setColor(15972174);
		g.fillRoundRect(this.xSub + 10, this.ySub + 16, this.wSub - 20, 16, 4, 4);
		AvMain.FontBorderColor(g, T.phanthuong, this.xSub + this.wSub / 2, this.ySub + 18, 2, 6, 5);
		mFont.tahoma_7_black.drawString(g, T.tichTieuRuby + " " + Interface_Game.ConvertNumToStr(this.mem.quaNapThe.cost) + " ", xpaint, ypaint, 0);
		mFont.tahoma_7_black.drawString(g, T.nhanduoc, xpaint, ypaint + 14, 0);
		AvMain.paintRect(g, xpaint, ypaint + 30, this.wSub - 20 - this.miniItem, this.hContent, 0, 4);
	}

	// Token: 0x06000F8B RID: 3979 RVA: 0x0012A634 File Offset: 0x00128834
	public override void update()
	{
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.update();
		}
		base.update();
		this.list.moveCamera();
		this.scroll.setYScrool(this.list.cmx, this.list.cmxLim);
	}

	// Token: 0x06000F8C RID: 3980 RVA: 0x0012A694 File Offset: 0x00128894
	public override void updatekey()
	{
		bool flag = this.vecMenu != null;
		if (flag)
		{
			int num = this.vecMenu.size();
			bool flag2 = GameCanvas.isTouchNoOrPC() && num > 0;
			if (flag2)
			{
				int num2 = this.idCommand;
				bool flag3 = GameCanvas.keyMove(0);
				if (flag3)
				{
					this.idCommand--;
					GameCanvas.ClearkeyMove(0);
				}
				else
				{
					bool flag4 = GameCanvas.keyMove(2);
					if (flag4)
					{
						this.idCommand++;
						GameCanvas.ClearkeyMove(2);
					}
				}
				this.idCommand = AvMain.resetSelect(this.idCommand, num - 1, false);
				bool flag5 = num2 != this.idCommand && GameCanvas.isTouchNoOrPC();
				if (flag5)
				{
					for (int i = 0; i < num; i++)
					{
						iCommand iCommand = (iCommand)this.vecMenu.elementAt(i);
						bool flag6 = i == this.idCommand;
						if (flag6)
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
		}
		bool flag7 = false;
		bool flag8 = GameCanvas.keyMove(1);
		if (flag8)
		{
			this.idSelect--;
			GameCanvas.ClearkeyMove(1);
			flag7 = true;
		}
		else
		{
			bool flag9 = GameCanvas.keyMove(3);
			if (flag9)
			{
				this.idSelect++;
				GameCanvas.ClearkeyMove(3);
				flag7 = true;
			}
		}
		bool flag10 = flag7;
		if (flag10)
		{
			this.idSelect = AvMain.resetSelect(this.idSelect, (int)(this.mem.quaNapThe.numQua - 1), false);
			this.list.setToX((this.idSelect + 1) * this.hItem - this.hContent / 2);
		}
		bool flag11 = GameCanvas.keyMyHold[5];
		if (flag11)
		{
			GameCanvas.clearKeyHold(5);
			bool flag12 = this.vecMenu != null && this.idCommand < this.vecMenu.size();
			if (flag12)
			{
				((iCommand)this.vecMenu.elementAt(this.idCommand)).perform();
			}
		}
		this.updatekeyPC();
	}

	// Token: 0x06000F8D RID: 3981 RVA: 0x0012A8A8 File Offset: 0x00128AA8
	public override void updatePointer()
	{
		base.updatePointer();
		this.list.update_Pos_UP_DOWN();
		bool flag = this.vecMenu != null;
		if (flag)
		{
			for (int i = 0; i < this.vecMenu.size(); i++)
			{
				iCommand iCommand = (iCommand)this.vecMenu.elementAt(i);
				iCommand.updatePointer();
			}
		}
	}

	// Token: 0x06000F8E RID: 3982 RVA: 0x0012A910 File Offset: 0x00128B10
	private void setClip(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		g.setClip(this.xSub + 10, this.ySub + 68, this.wSub - 20 - this.miniItem, this.hContent);
		g.saveCanvas();
		g.ClipRec(this.xSub + 10, this.ySub + 68, this.wSub - 20 - this.miniItem, this.hContent);
		g.translate(0, -this.list.cmx);
	}

	// Token: 0x04001A09 RID: 6665
	public static TichTieuInfo instance;

	// Token: 0x04001A0A RID: 6666
	private ListNew list;

	// Token: 0x04001A0B RID: 6667
	private InfoMemList mem;

	// Token: 0x04001A0C RID: 6668
	private iCommand cmdClose;

	// Token: 0x04001A0D RID: 6669
	private iCommand cmdNhan;

	// Token: 0x04001A0E RID: 6670
	private mVector vecMenu = new mVector();

	// Token: 0x04001A0F RID: 6671
	private int idCommand;

	// Token: 0x04001A10 RID: 6672
	private int idSelect;

	// Token: 0x04001A11 RID: 6673
	private int hContent;

	// Token: 0x04001A12 RID: 6674
	private int miniItem;

	// Token: 0x04001A13 RID: 6675
	private Scroll scroll = new Scroll();
}
