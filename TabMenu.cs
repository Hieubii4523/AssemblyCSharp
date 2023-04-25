using System;

// Token: 0x02000100 RID: 256
public class TabMenu : MainTab
{
	// Token: 0x06000EEC RID: 3820 RVA: 0x0012099C File Offset: 0x0011EB9C
	public TabMenu(string name, mVector vecmenu)
	{
		this.nameTab = name;
		this.wItemCur = GameCanvas.hCommand;
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.wItemCur = 32;
		}
		this.initCmd();
		this.menu.menuX = this.xCurBegin;
		this.menu.wUni = this.wCur;
		this.menu.menuH = this.hCur - this.miniItem * 3;
		this.menu.menuW = this.wItemCur;
		this.menu.menuY = this.yCurBegin;
		this.menu.menuTemY = this.menu.menuY;
		this.menu.startTabMenu(vecmenu);
		bool isTouch2 = GameCanvas.isTouch;
		if (isTouch2)
		{
			this.menu.menuSelectedItem = -1;
		}
		else
		{
			this.menu.menuSelectedItem = 0;
		}
		this.indexIconTab = 6;
	}

	// Token: 0x06000EED RID: 3821 RVA: 0x00120A98 File Offset: 0x0011EC98
	public override void beginFocus()
	{
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.menu.menuSelectedItem = -1;
		}
		else
		{
			this.menu.menuSelectedItem = 0;
		}
		this.menu.cmtoX = 0;
		this.menu.cmx = 0;
		this.menu.startTabMenu(GameCanvas.gameScr.getMenu());
	}

	// Token: 0x06000EEE RID: 3822 RVA: 0x000090B5 File Offset: 0x000072B5
	private void initCmd()
	{
	}

	// Token: 0x06000EEF RID: 3823 RVA: 0x00120AFC File Offset: 0x0011ECFC
	public override void paint(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		g.setClip(this.xCurBegin - 1, this.yCurBegin + 1, this.wCur + 2, this.hCur - 1 - this.miniItem - 1);
		g.saveCanvas();
		g.ClipRec(this.xCurBegin - 1, this.yCurBegin + 1, this.wCur + 2, this.hCur - 1 - this.miniItem - 1);
		g.translate(0, -this.menu.cmx);
		for (int i = 0; i < this.menu.menuItems.size() - 1; i++)
		{
			this.paintLine(g, i);
		}
		int num = this.menu.cmx / this.menu.menuW - 1;
		bool flag = num < 0;
		if (flag)
		{
			num = 0;
		}
		int num2 = num + this.menu.sizeMenu + 2;
		bool flag2 = num2 > this.menu.menuItems.size();
		if (flag2)
		{
			num2 = this.menu.menuItems.size();
			num = num2 - this.menu.sizeMenu - 2;
			bool flag3 = num < 0;
			if (flag3)
			{
				num = 0;
			}
		}
		bool flag4 = GameCanvas.currentScreen.setCurTypetab(1) && this.menu.menuSelectedItem > -1 && (!GameCanvas.isTouch || this.menu.timeShowSelect > 0);
		if (flag4)
		{
			this.paintSelect(g, this.menu.menuX + 10, this.menu.menuY + 7 + this.menu.menuSelectedItem * this.menu.menuW, this.menu.wUni - 20, this.menu.menuW - 8);
		}
		for (int j = num; j < num2; j++)
		{
			iCommand iCommand = (iCommand)this.menu.menuItems.elementAt(j);
			iCommand.paintCaptionImageMenu(g, this.menu.menuX + this.menu.wUni / 2, this.menu.menuY + 4 + this.menu.menuW / 4 + j * this.menu.menuW, 2, false);
		}
		mGraphics.resetTransAndroid(g);
		g.restoreCanvas();
		base.paint(g);
	}

	// Token: 0x06000EF0 RID: 3824 RVA: 0x00120D64 File Offset: 0x0011EF64
	public void paintLine(mGraphics g, int i)
	{
		g.setColor(AvMain.colorMenu[4]);
		g.fillRect(this.menu.menuX + 8, this.menu.menuY + 3 + this.menu.menuW + i * this.menu.menuW - 1, this.menu.wUni - 16, 2);
		g.fillRect(this.menu.menuX + 8 + 1, this.menu.menuY + 3 + this.menu.menuW + i * this.menu.menuW - 2, this.menu.wUni - 16 - 2, 4);
	}

	// Token: 0x06000EF1 RID: 3825 RVA: 0x0000C0CB File Offset: 0x0000A2CB
	public override void update()
	{
		this.menu.updateMenu();
		base.update();
	}

	// Token: 0x06000EF2 RID: 3826 RVA: 0x00120E1C File Offset: 0x0011F01C
	public override void updatekey()
	{
		bool flag = GameCanvas.keyMove(0) || GameCanvas.keyMove(2);
		if (flag)
		{
			GameCanvas.currentScreen.setTypeTab(0);
			GameCanvas.ClearkeyMove(0);
			GameCanvas.ClearkeyMove(2);
		}
		this.menu.updateMenuKey();
		base.updatekey();
	}

	// Token: 0x06000EF3 RID: 3827 RVA: 0x0000C0E1 File Offset: 0x0000A2E1
	public override void updatePointer()
	{
		base.updatePointer();
	}

	// Token: 0x04001934 RID: 6452
	private Menu menu = new Menu();
}
