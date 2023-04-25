using System;

// Token: 0x020000E3 RID: 227
public class ScreenDoiQua : MainScreen
{
	// Token: 0x06000DA1 RID: 3489 RVA: 0x00107754 File Offset: 0x00105954
	public ScreenDoiQua()
	{
		this.w = 240;
		this.h = 185;
		this.wItem = 24;
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.wItem = 28;
		}
		bool flag = this.w > MotherCanvas.w;
		if (flag)
		{
			this.w = MotherCanvas.w;
		}
		bool flag2 = this.h > MotherCanvas.h - GameCanvas.hCommand * 2;
		if (flag2)
		{
			this.h = MotherCanvas.h - GameCanvas.hCommand * 2;
		}
		this.x = MotherCanvas.hw - this.w / 2;
		this.y = MotherCanvas.hh - this.h / 2 + 5;
		this.cmdClose = new iCommand(T.close, -1, this);
		this.cmdNhan = new iCommand(T.doiqua, 0, this);
		bool isTouch2 = GameCanvas.isTouch;
		if (isTouch2)
		{
			this.cmdClose.setPos(this.x + this.w / 2 + 60, this.y - 15 + 10 + 8, MainTab.fraCloseTab, string.Empty);
			this.cmdNhan.setPos(MotherCanvas.hw, this.h + 8, null, T.doiqua);
			this.vecCmd.addElement(this.cmdClose);
			this.vecCmd.addElement(this.cmdNhan);
		}
		else
		{
			this.cmdClose.caption = T.close;
			this.cmdClose.setPos(MotherCanvas.hw - GameCanvas.wCommand / 2 - 18, this.y + this.h + 5 + GameCanvas.hCommand, null, T.close);
			this.cmdNhan.setPos(MotherCanvas.hw + GameCanvas.wCommand / 2 + 18, this.y + this.h + 5 + GameCanvas.hCommand, null, T.doiqua);
			this.right = this.cmdNhan;
			this.left = this.cmdClose;
		}
		this.PosX = new int[6];
		this.PosY = new int[6];
		for (int i = 0; i < this.PosX.Length; i++)
		{
			bool flag3 = i < this.PosX.Length / 2;
			if (flag3)
			{
				this.PosX[i] = this.x + this.w / 5 - 10;
				this.PosY[i] = this.y + this.h / 6 + (this.wItem + 3) * i;
			}
			else
			{
				this.PosX[i] = this.x + this.w / 5 + 3 + this.wItem - 10;
				this.PosY[i] = this.y + this.h / 6 + (this.wItem + 3) * (i - 3);
			}
		}
		this.Focus = -1;
		this.wsai = this.w / 2 - 13;
	}

	// Token: 0x06000DA2 RID: 3490 RVA: 0x00107A7C File Offset: 0x00105C7C
	public static ScreenDoiQua instance()
	{
		bool flag = ScreenDoiQua._instance == null;
		if (flag)
		{
			ScreenDoiQua._instance = new ScreenDoiQua();
		}
		return ScreenDoiQua._instance;
	}

	// Token: 0x06000DA3 RID: 3491 RVA: 0x00107AAC File Offset: 0x00105CAC
	public override void paint(mGraphics g)
	{
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.paint(g);
		}
		GameCanvas.resetTrans(g);
		this.paintBackGr(g);
		bool flag2 = this.vecCmd != null && GameCanvas.getShowCmd();
		if (flag2)
		{
			for (int i = 0; i < this.vecCmd.size(); i++)
			{
				iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
				iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
			}
		}
		this.paintEff(g, 0);
		base.paint(g);
	}

	// Token: 0x06000DA4 RID: 3492 RVA: 0x00107B50 File Offset: 0x00105D50
	public void paintBackGr(mGraphics g)
	{
		base.paintPaper(g, this.x, this.y - 17, this.w, this.h + 17, this.w, (int)AvMain.PAPER_NORMAL);
		g.setColor(14203529);
		g.fillRoundRect(this.x + this.w / 2 - 60, this.y - 15 + 10, 120, 16, 4, 4);
		AvMain.FontBorderColor(g, T.doiqua, this.x + this.w / 2, this.y - 15 + 12, 2, 6, 5);
		for (int i = 0; i < this.PosX.Length; i++)
		{
			AvMain.paintRect(g, this.PosX[i], this.PosY[i], this.wItem, this.wItem, 1, 0);
			AvMain.paintRect(g, this.PosX[i] + this.wsai, this.PosY[i], this.wItem, this.wItem, 1, 0);
			bool flag = this.Focus >= 0;
			if (flag)
			{
				g.setColor(16711680);
				bool flag2 = this.Type_Focus == 0;
				if (flag2)
				{
					g.drawRect(this.PosX[(int)this.Focus] + 1, this.PosY[(int)this.Focus] + 1, this.wItem - 2, this.wItem - 2);
				}
				else
				{
					g.drawRect(this.PosX[(int)this.Focus] + 1 + this.wsai, this.PosY[(int)this.Focus] + 1, this.wItem - 2, this.wItem - 2);
				}
			}
		}
		AvMain.FontBorderColor(g, T.doi, this.PosX[0] + this.wItem + 1, this.PosY[2] + this.wItem + 5, 2, 6, 7);
		AvMain.FontBorderColor(g, T.nhan, this.PosX[0] + this.wItem + 1 + this.wsai, this.PosY[2] + this.wItem + 5, 2, 1, 7);
	}

	// Token: 0x06000DA5 RID: 3493 RVA: 0x00107D70 File Offset: 0x00105F70
	public void paintEff(mGraphics g, int level)
	{
		for (int i = 0; i < this.vecEff.size(); i++)
		{
			MainEffect mainEffect = (MainEffect)this.vecEff.elementAt(i);
			mainEffect.paint(g);
		}
	}

	// Token: 0x06000DA6 RID: 3494 RVA: 0x00107DB4 File Offset: 0x00105FB4
	public override void commandPointer(int index, int subIndex)
	{
		if (index != -1)
		{
			if (index == 0)
			{
				this.createEff(75, 0, this.PosX[0] + this.wItem / 2, this.PosY[0] + this.wItem / 2, this.PosX[0] + this.wItem / 2, this.PosY[0] + this.wItem / 2);
			}
		}
		else
		{
			bool flag = this.lastScreen != null;
			if (flag)
			{
				this.lastScreen.Show(this.lastScreen.lastScreen);
			}
			else
			{
				GameCanvas.gameScr.Show();
			}
			this.vecEff.removeAllElements();
		}
	}

	// Token: 0x06000DA7 RID: 3495 RVA: 0x00107E68 File Offset: 0x00106068
	public override bool keyBack()
	{
		bool flag = !base.keyBack() && this.cmdClose != null;
		if (flag)
		{
			this.cmdClose.perform();
		}
		return false;
	}

	// Token: 0x06000DA8 RID: 3496 RVA: 0x00107EA4 File Offset: 0x001060A4
	public void updateEff()
	{
		for (int i = 0; i < this.vecEff.size(); i++)
		{
			MainEffect mainEffect = (MainEffect)this.vecEff.elementAt(i);
			mainEffect.update();
			bool isStop = mainEffect.isStop;
			if (isStop)
			{
				bool flag = mainEffect.typeEffect == 75;
				if (flag)
				{
					this.createEff(53, 0, this.PosX[0] + this.wsai + this.wItem / 2, this.PosY[0] + this.wItem / 2, this.PosX[0] + this.wsai + this.wItem / 2, this.PosY[0] + this.wItem / 2);
				}
				this.vecEff.removeElement(mainEffect);
				i--;
			}
		}
	}

	// Token: 0x06000DA9 RID: 3497 RVA: 0x00107F78 File Offset: 0x00106178
	public override void update()
	{
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.update();
		}
		this.updateEff();
	}

	// Token: 0x06000DAA RID: 3498 RVA: 0x00107FA8 File Offset: 0x001061A8
	public void createEff(short type, int subtype, int x, int y, int xto, int yto)
	{
		Effect_End o = new Effect_End(type, (sbyte)subtype, x, y, xto, yto, 0, null);
		this.vecEff.addElement(o);
	}

	// Token: 0x06000DAB RID: 3499 RVA: 0x00107FD8 File Offset: 0x001061D8
	public override void updatePointer()
	{
		bool flag = this.vecCmd != null;
		if (flag)
		{
			for (int i = 0; i < this.vecCmd.size(); i++)
			{
				iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
				iCommand.updatePointer();
			}
		}
		for (int j = 0; j < this.PosX.Length; j++)
		{
			bool flag2 = GameCanvas.isPointSelect(this.PosX[j], this.PosY[j], this.wItem, this.wItem);
			if (flag2)
			{
				this.Focus = (sbyte)j;
				this.Type_Focus = 0;
				GameCanvas.isPointerSelect = false;
			}
			bool flag3 = GameCanvas.isPointSelect(this.PosX[j] + this.wsai, this.PosY[j], this.wItem, this.wItem);
			if (flag3)
			{
				this.Focus = (sbyte)j;
				this.Type_Focus = 1;
				GameCanvas.isPointerSelect = false;
			}
		}
		base.updatePointer();
	}

	// Token: 0x040014E9 RID: 5353
	private int x;

	// Token: 0x040014EA RID: 5354
	private int y;

	// Token: 0x040014EB RID: 5355
	private int w;

	// Token: 0x040014EC RID: 5356
	private int h;

	// Token: 0x040014ED RID: 5357
	private int wItem;

	// Token: 0x040014EE RID: 5358
	private int wsai;

	// Token: 0x040014EF RID: 5359
	public mVector vecItemLose = new mVector();

	// Token: 0x040014F0 RID: 5360
	public mVector vecItemGif = new mVector();

	// Token: 0x040014F1 RID: 5361
	private mVector vecEff = new mVector();

	// Token: 0x040014F2 RID: 5362
	private int[] PosX;

	// Token: 0x040014F3 RID: 5363
	private int[] PosY;

	// Token: 0x040014F4 RID: 5364
	public sbyte Focus;

	// Token: 0x040014F5 RID: 5365
	public sbyte Type_Focus;

	// Token: 0x040014F6 RID: 5366
	public mVector vecCmd = new mVector();

	// Token: 0x040014F7 RID: 5367
	public iCommand cmdClose;

	// Token: 0x040014F8 RID: 5368
	public iCommand cmdNhan;

	// Token: 0x040014F9 RID: 5369
	public static ScreenDoiQua _instance;
}
