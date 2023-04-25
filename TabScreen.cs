using System;

// Token: 0x02000102 RID: 258
public class TabScreen : MainScreen
{
	// Token: 0x06000EFF RID: 3839 RVA: 0x001217A4 File Offset: 0x0011F9A4
	public TabScreen(int xbegin, sbyte type)
	{
		this.xbeginPaintTab = xbegin;
		this.typeMarket = type;
		this.cmdClose = new iCommand(T.close, 0, this);
		int x = this.xbeginPaintTab + 22 + (MainTab.wTab - 22) / 2 - MainTab.wTab / 4 * 3 / 2 + MainTab.wTab / 4 * 3;
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.cmdClose.setPos(x, MainTab.yTab + 7 + 8, MainTab.fraCloseTab, string.Empty);
		}
		this.right = this.cmdClose;
		this.backCMD = this.cmdClose;
	}

	// Token: 0x06000F00 RID: 3840 RVA: 0x00121870 File Offset: 0x0011FA70
	public override void Show(MainScreen screen)
	{
		bool flag = !GameCanvas.isTouch;
		if (flag)
		{
			this.typeCurrent = 0;
			this.setTabSelect();
			this.endInfoTab();
		}
		else
		{
			this.typeCurrent = 1;
			this.setTabSelect();
			this.tabCurrent.beginFocus();
		}
		base.Show(screen);
	}

	// Token: 0x06000F01 RID: 3841 RVA: 0x000092E5 File Offset: 0x000074E5
	public override void setxyPlus12()
	{
		GameCanvas.xPlus12 = 2;
		GameCanvas.yPlus12 = 2;
	}

	// Token: 0x06000F02 RID: 3842 RVA: 0x001218C8 File Offset: 0x0011FAC8
	public override void commandPointer(int index, int subIndex)
	{
		bool flag = index != 0;
		if (!flag)
		{
			bool isTouch = GameCanvas.isTouch;
			if (isTouch)
			{
				this.lastScreen.Show(this.lastScreen.lastScreen);
				bool flag2 = GameScreen.indexHelp == 16;
				if (flag2)
				{
					GameScreen.addHelp(16, 1);
				}
			}
			else
			{
				bool flag3 = this.typeCurrent == 0;
				if (flag3)
				{
					this.lastScreen.Show(this.lastScreen.lastScreen);
				}
				else
				{
					bool flag4 = this.typeCurrent == 1;
					if (flag4)
					{
						this.typeCurrent = 0;
					}
				}
			}
		}
	}

	// Token: 0x06000F03 RID: 3843 RVA: 0x00121960 File Offset: 0x0011FB60
	public void addVecTab(mVector vec)
	{
		this.vecTabs = vec;
		bool flag = this.tabCurrent == null && this.vecTabs.size() > 0;
		if (flag)
		{
			this.tabCurrent = (MainTab)this.vecTabs.elementAt(0);
			this.idSelect = 0;
		}
	}

	// Token: 0x06000F04 RID: 3844 RVA: 0x001219B4 File Offset: 0x0011FBB4
	public override void paint(mGraphics g)
	{
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.paint(g);
		}
		GameCanvas.resetTrans(g);
		MainTab.paintBgTab(g, this.xbeginPaintTab, this.isShopClan, this.typeMarket);
		MainTab.paintListTab(g, this.xbeginPaintTab, this.vecTabs, this.idSelect);
		Interface_Game.paintNumMess(g, -Interface_Game.xNumMess + 8, 0);
		base.paint(g);
		bool flag2 = this.tabCurrent != null;
		if (flag2)
		{
			this.tabCurrent.paint(g);
			bool flag3 = this.tabCurrent.indexIconTab == 2 && GameCanvas.isTouch;
			if (flag3)
			{
				this.cmdClose.paint(g, this.cmdClose.xCmd, this.cmdClose.yCmd);
			}
		}
		for (int i = 0; i < TabScreen.vecEff.size(); i++)
		{
			MainEffect mainEffect = (MainEffect)TabScreen.vecEff.elementAt(i);
			bool flag4 = mainEffect != null && !mainEffect.isRemove && !mainEffect.isStop;
			if (flag4)
			{
				mainEffect.paint(g);
			}
		}
	}

	// Token: 0x06000F05 RID: 3845 RVA: 0x00121AE4 File Offset: 0x0011FCE4
	public override void update()
	{
		MainTab.timenhapnhay++;
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.update();
		}
		bool flag2 = !GameCanvas.isTouch;
		if (flag2)
		{
			bool flag3 = this.typeCurrent == 0;
			if (flag3)
			{
				bool flag4 = this.cmdClose.caption != T.close;
				if (flag4)
				{
					this.cmdClose.caption = T.close;
				}
			}
			else
			{
				bool flag5 = this.typeCurrent == 1 && this.cmdClose.caption != T.back;
				if (flag5)
				{
					this.cmdClose.caption = T.back;
				}
			}
		}
		bool flag6 = this.tabCurrent != null;
		if (flag6)
		{
			this.tabCurrent.update();
			bool flag7 = TabScreen.isRefresh;
			if (flag7)
			{
				TabScreen.isRefresh = false;
				this.tabCurrent.updateInfo();
			}
		}
		for (int i = 0; i < TabScreen.vecEff.size(); i++)
		{
			MainEffect mainEffect = (MainEffect)TabScreen.vecEff.elementAt(i);
			bool flag8 = mainEffect != null && !mainEffect.isRemove && !mainEffect.isStop;
			if (flag8)
			{
				mainEffect.update();
			}
		}
	}

	// Token: 0x06000F06 RID: 3846 RVA: 0x00121C38 File Offset: 0x0011FE38
	public override void updatekey()
	{
		bool flag = this.typeCurrent == 0;
		if (flag)
		{
			int num = this.idSelect;
			bool flag2 = GameCanvas.keyMove(1);
			if (flag2)
			{
				this.idSelect--;
				GameCanvas.ClearkeyMove(1);
			}
			else
			{
				bool flag3 = GameCanvas.keyMove(3);
				if (flag3)
				{
					this.idSelect++;
					GameCanvas.ClearkeyMove(3);
				}
			}
			bool flag4 = GameCanvas.keyMove(0) || GameCanvas.keyMove(2);
			if (flag4)
			{
				this.typeCurrent = 1;
				this.tabCurrent.beginFocus();
				GameCanvas.ClearkeyMove(0);
				GameCanvas.ClearkeyMove(2);
			}
			bool flag5 = num != this.idSelect;
			if (flag5)
			{
				MainTab.timenhapnhay = 0;
				this.idSelect = AvMain.resetSelect(this.idSelect, this.vecTabs.size() - 1, true);
				this.setTabSelect();
				this.endInfoTab();
				this.tabCurrent.beginFocus();
			}
		}
		else
		{
			bool flag6 = this.tabCurrent != null;
			if (flag6)
			{
				this.tabCurrent.updatekey();
			}
			bool flag7 = this.typeCurrent == 0;
			if (flag7)
			{
				this.endInfoTab();
			}
		}
		base.updatekey();
		this.updatekeyPC();
	}

	// Token: 0x06000F07 RID: 3847 RVA: 0x00121D78 File Offset: 0x0011FF78
	public override void updatePointer()
	{
		int x = this.xbeginPaintTab + 22 - MainTab.hItemTab / 2;
		int num = MainTab.yTab + 36 - MainTab.hItemTab / 2;
		bool flag = num + this.vecTabs.size() * MainTab.hItemTab > MainTab.yTab + MainTab.hTab;
		if (flag)
		{
			num = MainTab.yTab + MainTab.hTab / 2 - this.vecTabs.size() * MainTab.hItemTab / 2;
		}
		bool flag2 = GameCanvas.isPointSelect(x, num, MainTab.hItemTab, MainTab.hItemTab * this.vecTabs.size());
		if (flag2)
		{
			int num2 = (GameCanvas.py - num) / MainTab.hItemTab;
			int num3 = this.vecTabs.size();
			bool flag3 = num2 >= 0 && num2 < num3;
			if (flag3)
			{
				GameCanvas.isPointerSelect = false;
				bool flag4 = num2 != this.idSelect;
				if (flag4)
				{
					this.idSelect = num2;
					this.setTabSelect();
					this.tabCurrent.beginFocus();
				}
				bool flag5 = !GameCanvas.currentScreen.setCurTypetab(1);
				if (flag5)
				{
					GameCanvas.currentScreen.setTypeTab(1);
				}
			}
		}
		bool flag6 = this.tabCurrent != null;
		if (flag6)
		{
			this.tabCurrent.updatePointer();
		}
		base.updatePointer();
	}

	// Token: 0x06000F08 RID: 3848 RVA: 0x0000C0FF File Offset: 0x0000A2FF
	public void setTabSelect()
	{
		this.tabCurrent = (MainTab)this.vecTabs.elementAt(this.idSelect);
	}

	// Token: 0x06000F09 RID: 3849 RVA: 0x00121EC8 File Offset: 0x001200C8
	public void endInfoTab()
	{
		this.left = null;
		this.center = null;
		this.right = this.cmdClose;
		bool flag = this.tabCurrent != null;
		if (flag)
		{
			this.left = this.tabCurrent.setCmdEndInfo();
		}
	}

	// Token: 0x06000F0A RID: 3850 RVA: 0x00121F10 File Offset: 0x00120110
	public void updateInfo()
	{
		bool flag = this.tabCurrent != null;
		if (flag)
		{
			this.tabCurrent.updateInfo();
		}
	}

	// Token: 0x06000F0B RID: 3851 RVA: 0x00121F3C File Offset: 0x0012013C
	public static void addEffectNumImage(string content, int x, int y, sbyte typeColor, FrameImage fra, int frame)
	{
		EffectNum effectNum = new EffectNum(content, x, y, (int)typeColor, fra, frame);
		int num = GameScreen.find_Index_Stop(TabScreen.vecEff);
		bool flag = num == TabScreen.vecEff.size();
		if (flag)
		{
			TabScreen.vecEff.addElement(effectNum);
		}
		else
		{
			TabScreen.vecEff.setElementAt(effectNum, num);
		}
	}

	// Token: 0x06000F0C RID: 3852 RVA: 0x00121F94 File Offset: 0x00120194
	public override bool keyBack()
	{
		bool flag = !base.keyBack() && this.cmdClose != null;
		if (flag)
		{
			this.cmdClose.perform();
		}
		return false;
	}

	// Token: 0x06000F0D RID: 3853 RVA: 0x00121FD0 File Offset: 0x001201D0
	public void updateVecDataMarket(sbyte index, mVector vec)
	{
		bool flag = index < 0 || (int)index >= this.vecTabs.size();
		if (!flag)
		{
			for (int i = 0; i < this.vecTabs.size(); i++)
			{
				MainTab mainTab = (MainTab)this.vecTabs.elementAt(i);
				bool flag2 = mainTab.indexMarket == index;
				if (flag2)
				{
					mainTab.setData(vec);
					break;
				}
			}
		}
	}

	// Token: 0x0400193D RID: 6461
	public const sbyte TAB = 0;

	// Token: 0x0400193E RID: 6462
	public const sbyte INFO = 1;

	// Token: 0x0400193F RID: 6463
	public static bool isRefresh = false;

	// Token: 0x04001940 RID: 6464
	public mVector vecTabs = new mVector("TabScreen.vecTabs");

	// Token: 0x04001941 RID: 6465
	public static mVector vecEff = new mVector("TabScreen.vecEff");

	// Token: 0x04001942 RID: 6466
	public MainTab tabCurrent;

	// Token: 0x04001943 RID: 6467
	public iCommand cmdClose;

	// Token: 0x04001944 RID: 6468
	public sbyte typeCurrent;

	// Token: 0x04001945 RID: 6469
	public sbyte typeMarket;

	// Token: 0x04001946 RID: 6470
	public int idSelect;

	// Token: 0x04001947 RID: 6471
	public bool isShopClan;

	// Token: 0x04001948 RID: 6472
	public bool isFixscreen;

	// Token: 0x04001949 RID: 6473
	public int xbeginPaintTab;

	// Token: 0x0400194A RID: 6474
	private int[] mIndexMarket = new int[]
	{
		0,
		1,
		2,
		5,
		3,
		4
	};
}
