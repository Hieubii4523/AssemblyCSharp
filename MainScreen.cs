using System;

// Token: 0x02000085 RID: 133
public class MainScreen : AvMain
{
	// Token: 0x0600087C RID: 2172 RVA: 0x0000ADE5 File Offset: 0x00008FE5
	public virtual void Show()
	{
		GameCanvas.clearKeyPressed();
		GameCanvas.menuCur.isShowMenu = false;
		GameCanvas.end_Dialog();
		GameCanvas.currentScreen = this;
		this.CheckClickCmd();
		this.setxyPlus12();
	}

	// Token: 0x0600087D RID: 2173 RVA: 0x000ACA94 File Offset: 0x000AAC94
	public virtual void Show(MainScreen screen)
	{
		bool flag = screen != null;
		if (flag)
		{
			this.lastScreen = screen;
		}
		GameCanvas.clearKeyPressed();
		GameCanvas.currentScreen = this;
		GameCanvas.end_Dialog();
		this.CheckClickCmd();
		this.setxyPlus12();
	}

	// Token: 0x0600087E RID: 2174 RVA: 0x000092E5 File Offset: 0x000074E5
	public virtual void setxyPlus12()
	{
		GameCanvas.xPlus12 = 2;
		GameCanvas.yPlus12 = 2;
	}

	// Token: 0x0600087F RID: 2175 RVA: 0x000ACAD4 File Offset: 0x000AACD4
	public void CheckClickCmd()
	{
		bool flag = this.left != null;
		if (flag)
		{
			this.left.timeSelect = 0;
		}
		bool flag2 = this.right != null;
		if (flag2)
		{
			this.right.timeSelect = 0;
		}
		bool flag3 = this.center != null;
		if (flag3)
		{
			this.center.timeSelect = 0;
		}
	}

	// Token: 0x06000880 RID: 2176 RVA: 0x000092C6 File Offset: 0x000074C6
	public override void paint(mGraphics g)
	{
		base.paint(g);
	}

	// Token: 0x06000881 RID: 2177 RVA: 0x000090B5 File Offset: 0x000072B5
	public override void update()
	{
	}

	// Token: 0x06000882 RID: 2178 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void keyPress(int keyCode)
	{
	}

	// Token: 0x06000883 RID: 2179 RVA: 0x000ACB34 File Offset: 0x000AAD34
	public virtual bool keyBack()
	{
		bool flag = GameCanvas.currentDialog != null || GameCanvas.subDialog != null;
		bool result;
		if (flag)
		{
			bool isBack = GameCanvas.currentDialog.isBack;
			if (isBack)
			{
				GameCanvas.end_Dialog();
			}
			result = true;
		}
		else
		{
			bool isShowMenu = GameCanvas.menuCur.isShowMenu;
			if (isShowMenu)
			{
				GameCanvas.menuCur.isShowMenu = false;
				result = true;
			}
			else
			{
				result = false;
			}
		}
		return result;
	}

	// Token: 0x06000884 RID: 2180 RVA: 0x000ACB98 File Offset: 0x000AAD98
	public void setTypeTab(sbyte type)
	{
		bool flag = GameCanvas.currentScreen == GameCanvas.tabAllScr;
		if (flag)
		{
			GameCanvas.tabAllScr.typeCurrent = type;
		}
		bool flag2 = GameCanvas.currentScreen == GameCanvas.tabShopScr;
		if (flag2)
		{
			GameCanvas.tabShopScr.typeCurrent = type;
		}
		bool flag3 = GameCanvas.currentScreen == GameCanvas.tabMarketScr;
		if (flag3)
		{
			GameCanvas.tabMarketScr.typeCurrent = type;
		}
	}

	// Token: 0x06000885 RID: 2181 RVA: 0x000ACC00 File Offset: 0x000AAE00
	public bool setCurTypetab(sbyte type)
	{
		bool flag = GameCanvas.currentScreen == GameCanvas.tabAllScr && GameCanvas.tabAllScr.typeCurrent == type;
		bool result;
		if (flag)
		{
			result = true;
		}
		else
		{
			bool flag2 = GameCanvas.currentScreen == GameCanvas.tabShopScr && GameCanvas.tabShopScr.typeCurrent == type;
			if (flag2)
			{
				result = true;
			}
			else
			{
				bool flag3 = GameCanvas.currentScreen == GameCanvas.tabMarketScr && GameCanvas.tabMarketScr.typeCurrent == type;
				result = flag3;
			}
		}
		return result;
	}

	// Token: 0x04000D42 RID: 3394
	private MainScreen mainScreen;

	// Token: 0x04000D43 RID: 3395
	public MainScreen lastScreen;

	// Token: 0x04000D44 RID: 3396
	public static Camera cameraMain;

	// Token: 0x04000D45 RID: 3397
	public static Camera cameraSub;
}
