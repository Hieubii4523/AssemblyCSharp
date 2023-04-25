using System;

// Token: 0x02000115 RID: 277
public class WantedScreen : MainScreen
{
	// Token: 0x06000FE9 RID: 4073 RVA: 0x0000C360 File Offset: 0x0000A560
	public WantedScreen()
	{
	}

	// Token: 0x06000FEA RID: 4074 RVA: 0x0013191C File Offset: 0x0012FB1C
	public WantedScreen(mVector vec, sbyte page, sbyte maxpage)
	{
		this.page = page;
		this.maxpage = maxpage;
		this.vecList = vec;
		this.w = AvMain.wWanted;
		this.h = AvMain.hWanted;
		this.x = MotherCanvas.hw - this.w / 2;
		this.y = MotherCanvas.hh - this.h / 2;
		this.cmdClose = new iCommand(T.close, -1, this);
		this.cmdClose = AvMain.setPosCMD(this.cmdClose, 2);
		this.right = this.cmdClose;
	}

	// Token: 0x06000FEB RID: 4075 RVA: 0x001319C0 File Offset: 0x0012FBC0
	public override void commandPointer(int index, int subIndex)
	{
		bool flag = index == -1 && this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.Show(this.lastScreen.lastScreen);
		}
	}

	// Token: 0x06000FEC RID: 4076 RVA: 0x001319FC File Offset: 0x0012FBFC
	public override void paint(mGraphics g)
	{
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.paint(g);
		}
		GameCanvas.resetTrans(g);
		this.paintBg(g, this.x, this.y);
		bool flag2 = this.idSelect >= 0 && this.idSelect < this.vecList.size();
		if (flag2)
		{
			InfoMemList mem = (InfoMemList)this.vecList.elementAt(this.idSelect);
			WantedScreen.paintInfo(g, mem, this.x, this.y, this.w, this.h);
		}
		base.paintCmd(g);
	}

	// Token: 0x06000FED RID: 4077 RVA: 0x00131AA8 File Offset: 0x0012FCA8
	public static void paintInfo(mGraphics g, InfoMemList mem, int xpaint, int ypaint, int wpaint, int hpaint)
	{
		bool flag = mem != null;
		if (flag)
		{
			AvMain.FontBorderColor(g, mem.name, xpaint + wpaint / 2, ypaint + 102, 2, 0, 8);
			bool flag2 = mem.charShow != null;
			if (flag2)
			{
				mem.charShow.paintCharShow(g, xpaint + wpaint / 2, ypaint + 80, 0, false);
				NumberDam.paintSmallWanted(g, mem.charShow.wanted, xpaint + wpaint / 2 + 4, ypaint + 130);
			}
		}
	}

	// Token: 0x06000FEE RID: 4078 RVA: 0x00131B24 File Offset: 0x0012FD24
	public void paintBg(mGraphics g, int xpaint, int ypaint)
	{
		sbyte type = 2;
		bool flag = this.vecList.size() == 1;
		if (flag)
		{
			type = 3;
		}
		else
		{
			bool flag2 = this.idSelect == 0;
			if (flag2)
			{
				type = 1;
			}
			else
			{
				bool flag3 = this.idSelect == this.vecList.size() - 1;
				if (flag3)
				{
					type = 0;
				}
			}
		}
		AvMain.paintBG_Wanted(g, xpaint, ypaint, this.w, this.h, (int)type);
	}

	// Token: 0x06000FEF RID: 4079 RVA: 0x0013167C File Offset: 0x0012F87C
	public override void update()
	{
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.update();
		}
		base.update();
	}

	// Token: 0x06000FF0 RID: 4080 RVA: 0x00131B94 File Offset: 0x0012FD94
	public override void updatekey()
	{
		bool flag = false;
		bool flag2 = GameCanvas.keyMove(0);
		if (flag2)
		{
			bool flag3 = this.idSelect > 0;
			if (flag3)
			{
				this.idSelect--;
			}
			GameCanvas.ClearkeyMove(0);
			flag = true;
		}
		else
		{
			bool flag4 = GameCanvas.keyMove(2);
			if (flag4)
			{
				bool flag5 = this.idSelect < this.vecList.size() - 1;
				if (flag5)
				{
					this.idSelect++;
				}
				GameCanvas.ClearkeyMove(2);
				flag = true;
			}
		}
		bool flag6 = flag;
		if (flag6)
		{
		}
		base.updatekey();
	}

	// Token: 0x06000FF1 RID: 4081 RVA: 0x00131C28 File Offset: 0x0012FE28
	public override void updatePointer()
	{
		base.updatePointer();
		bool flag = GameCanvas.isPointerSelect && GameCanvas.isPoint(0, 0, MotherCanvas.hw, MotherCanvas.h);
		if (flag)
		{
			GameCanvas.isPointerSelect = false;
			bool flag2 = this.idSelect > 0;
			if (flag2)
			{
				this.idSelect--;
			}
		}
		bool flag3 = GameCanvas.isPointerSelect && GameCanvas.isPoint(MotherCanvas.hw, 0, MotherCanvas.hw, MotherCanvas.h);
		if (flag3)
		{
			GameCanvas.isPointerSelect = false;
			bool flag4 = this.idSelect < this.vecList.size() - 1;
			if (flag4)
			{
				this.idSelect++;
			}
		}
	}

	// Token: 0x04001A6F RID: 6767
	private sbyte page;

	// Token: 0x04001A70 RID: 6768
	private sbyte maxpage;

	// Token: 0x04001A71 RID: 6769
	public static WantedScreen instance;

	// Token: 0x04001A72 RID: 6770
	private iCommand cmdClose;

	// Token: 0x04001A73 RID: 6771
	private int x;

	// Token: 0x04001A74 RID: 6772
	private int y;

	// Token: 0x04001A75 RID: 6773
	private int w;

	// Token: 0x04001A76 RID: 6774
	private int h;

	// Token: 0x04001A77 RID: 6775
	private int idSelect;

	// Token: 0x04001A78 RID: 6776
	private mVector vecList = new mVector();
}
