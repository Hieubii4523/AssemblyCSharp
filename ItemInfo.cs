using System;

// Token: 0x02000061 RID: 97
public class ItemInfo : SubScreen
{
	// Token: 0x06000636 RID: 1590 RVA: 0x0008B554 File Offset: 0x00089754
	public ItemInfo(sbyte type, InfoMemList mem) : base(type)
	{
		this.mem = mem;
		this.wSub = 160;
		this.hSub = 120;
		this.xSub = MotherCanvas.hw - this.wSub / 2;
		this.ySub = MotherCanvas.hh - this.hSub / 2;
		this.idCommand = 0;
		this.cmdClose = new iCommand(T.close, -1, this);
		this.vecMenu.addElement(this.cmdClose);
		this.setPosCmdNew(0, this.vecMenu);
		mem.item.strShow = mFont.tahoma_7_white.splitFontArray(mem.item.numPotion.ToString() + " " + mem.item.name, this.wSub - 20 - 32 - 15);
	}

	// Token: 0x06000637 RID: 1591 RVA: 0x0008B63C File Offset: 0x0008983C
	public override void commandPointer(int index, int subIndex)
	{
		bool flag = index == -1;
		if (flag)
		{
			AuctionScreen.instance.Show(GameCanvas.gameScr);
		}
	}

	// Token: 0x06000638 RID: 1592 RVA: 0x0008B664 File Offset: 0x00089864
	public override void paint(mGraphics g)
	{
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.paint(g);
		}
		this.paintInfo(g);
		GameCanvas.resetTrans(g);
		bool flag2 = this.vecMenu != null;
		if (flag2)
		{
			for (int i = 0; i < this.vecMenu.size(); i++)
			{
				iCommand iCommand = (iCommand)this.vecMenu.elementAt(i);
				iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
			}
		}
	}

	// Token: 0x06000639 RID: 1593 RVA: 0x0008B6F0 File Offset: 0x000898F0
	private void paintInfo(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		base.paintPaper(g, this.xSub, this.ySub, this.wSub, this.hSub, this.wSub, (int)AvMain.PAPER_NORMAL);
		g.setColor(15972174);
		g.fillRoundRect(this.xSub + 10, this.ySub + 16, this.wSub - 20, 16, 4, 4);
		AvMain.FontBorderColor(g, T.info, this.xSub + this.wSub / 2, this.ySub + 18, 2, 6, 5);
		AvMain.paintRect(g, this.xSub + 10, this.ySub + 40, this.wSub - 20, 32, 0, 4);
		bool flag = this.mem != null;
		if (flag)
		{
			GameCanvas.resetTrans(g);
			this.mem.item.paintInfo(g, this.xSub + 10, this.ySub + 40);
		}
	}

	// Token: 0x0600063A RID: 1594 RVA: 0x0008B7EC File Offset: 0x000899EC
	public override void updatePointer()
	{
		base.updatePointer();
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

	// Token: 0x0600063B RID: 1595 RVA: 0x0008B848 File Offset: 0x00089A48
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
		bool flag7 = GameCanvas.keyMyHold[5];
		if (flag7)
		{
			GameCanvas.clearKeyHold(5);
			bool flag8 = this.vecMenu != null && this.idCommand < this.vecMenu.size();
			if (flag8)
			{
				((iCommand)this.vecMenu.elementAt(this.idCommand)).perform();
			}
		}
		this.updatekeyPC();
	}

	// Token: 0x0600063C RID: 1596 RVA: 0x0008B9BC File Offset: 0x00089BBC
	public override void update()
	{
		base.update();
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.update();
		}
	}

	// Token: 0x040008E3 RID: 2275
	public static ItemInfo instance;

	// Token: 0x040008E4 RID: 2276
	private InfoMemList mem;

	// Token: 0x040008E5 RID: 2277
	private iCommand cmdClose;

	// Token: 0x040008E6 RID: 2278
	private mVector vecMenu = new mVector();

	// Token: 0x040008E7 RID: 2279
	private int idCommand;
}
