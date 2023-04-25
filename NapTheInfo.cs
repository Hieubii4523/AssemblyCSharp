using System;

// Token: 0x020000B9 RID: 185
public class NapTheInfo : SubScreen
{
	// Token: 0x06000B1D RID: 2845 RVA: 0x000D7F60 File Offset: 0x000D6160
	public NapTheInfo(sbyte type, InfoMemList mem) : base(type)
	{
		this.mem = mem;
		bool flag = NapTheScreen.instance.wSub > 180;
		if (flag)
		{
			this.wSub = NapTheScreen.instance.wSub - 20;
		}
		else
		{
			this.wSub = NapTheScreen.instance.wSub;
		}
		this.hSub = NapTheScreen.instance.hSub;
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

	// Token: 0x06000B1E RID: 2846 RVA: 0x000D8174 File Offset: 0x000D6374
	public override void commandPointer(int index, int subIndex)
	{
		if (index != -1)
		{
			if (index == 0)
			{
				GlobalService.gI().Send_Nhan_NapTheScr(1, (sbyte)this.mem.id);
			}
		}
		else
		{
			NapTheScreen.instance.Show(GameCanvas.gameScr);
		}
	}

	// Token: 0x06000B1F RID: 2847 RVA: 0x000D81C0 File Offset: 0x000D63C0
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

	// Token: 0x06000B20 RID: 2848 RVA: 0x000D82C4 File Offset: 0x000D64C4
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

	// Token: 0x06000B21 RID: 2849 RVA: 0x000D833C File Offset: 0x000D653C
	private void paintBg(mGraphics g, int xpaint, int ypaint)
	{
		base.paintPaper(g, this.xSub, this.ySub, this.wSub, this.hSub, this.wSub, (int)AvMain.PAPER_NORMAL);
		g.setColor(15972174);
		g.fillRoundRect(this.xSub + 10, this.ySub + 16, this.wSub - 20, 16, 4, 4);
		AvMain.FontBorderColor(g, T.phanThuongNap, this.xSub + this.wSub / 2, this.ySub + 18, 2, 6, 5);
		mFont.tahoma_7_black.drawString(g, string.Concat(new string[]
		{
			T.tichLuyNap,
			" ",
			Interface_Game.ConvertNumToStr(this.mem.quaNapThe.cost),
			" ",
			T.vnd
		}), xpaint, ypaint, 0);
		mFont.tahoma_7_black.drawString(g, T.nhanduoc, xpaint, ypaint + 14, 0);
		AvMain.paintRect(g, xpaint, ypaint + 30, this.wSub - 20 - this.miniItem, this.hContent, 0, 4);
	}

	// Token: 0x06000B22 RID: 2850 RVA: 0x000D845C File Offset: 0x000D665C
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

	// Token: 0x06000B23 RID: 2851 RVA: 0x000D84BC File Offset: 0x000D66BC
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

	// Token: 0x06000B24 RID: 2852 RVA: 0x000D86D0 File Offset: 0x000D68D0
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

	// Token: 0x06000B25 RID: 2853 RVA: 0x000D8738 File Offset: 0x000D6938
	private void setClip(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		g.setClip(this.xSub + 10, this.ySub + 68, this.wSub - 20 - this.miniItem, this.hContent);
		g.saveCanvas();
		g.ClipRec(this.xSub + 10, this.ySub + 68, this.wSub - 20 - this.miniItem, this.hContent);
		g.translate(0, -this.list.cmx);
	}

	// Token: 0x040010AF RID: 4271
	public static NapTheInfo instance;

	// Token: 0x040010B0 RID: 4272
	private ListNew list;

	// Token: 0x040010B1 RID: 4273
	private InfoMemList mem;

	// Token: 0x040010B2 RID: 4274
	private iCommand cmdClose;

	// Token: 0x040010B3 RID: 4275
	private iCommand cmdNhan;

	// Token: 0x040010B4 RID: 4276
	private mVector vecMenu = new mVector();

	// Token: 0x040010B5 RID: 4277
	private int idCommand;

	// Token: 0x040010B6 RID: 4278
	private int idSelect;

	// Token: 0x040010B7 RID: 4279
	private int hContent;

	// Token: 0x040010B8 RID: 4280
	private int miniItem;

	// Token: 0x040010B9 RID: 4281
	private Scroll scroll = new Scroll();
}
