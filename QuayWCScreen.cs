using System;

// Token: 0x020000D7 RID: 215
public class QuayWCScreen : LuckyScreen
{
	// Token: 0x06000C44 RID: 3140 RVA: 0x000EB2B0 File Offset: 0x000E94B0
	public QuayWCScreen()
	{
		this.StepQuaySo = 0;
		this.w = 260;
		this.h = 215;
		this.x = MotherCanvas.hw - this.w / 2;
		this.y = MotherCanvas.hh - this.h / 2;
		this.xQuay = this.x + 100;
		this.yQuay = this.y + this.h / 2 + 12;
		this.wButton = (this.h - 25) / 5 + 5;
		this.xButton = this.x + this.w - 40;
		this.yButton = this.y + 15 + this.wButton;
		LuckyScreen.mImgVongquay = null;
		this.loadImgVongQuay();
		this.loadIconVongQuay();
		this.cmdClose = new iCommand(T.close, -1, this);
		this.cmdQuay = new iCommand(string.Empty, 2, 1, this);
		this.cmdQuay3Lan = new iCommand(string.Empty, 2, 2, this);
		this.cmdQuay.setPos(this.xButton, this.yButton + this.wButton * 2, this.fraImg1Lan, string.Empty);
		this.cmdQuay3Lan.setPos(this.xButton, this.yButton + this.wButton * 3, this.fraImg5Lan, string.Empty);
		this.vecCmd = new mVector();
		this.vecCmd.addElement(this.cmdQuay);
		this.vecCmd.addElement(this.cmdQuay3Lan);
		this.vecCmd.addElement(this.cmdClose);
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			int num = this.x + this.w - 13;
			bool flag = num > MotherCanvas.w - 9;
			if (flag)
			{
				num = MotherCanvas.w - 9;
			}
			this.cmdClose.setPos(num, this.y + 13, MainTab.fraCloseTab, string.Empty);
		}
		else
		{
			AvMain.setPosCMD(this.cmdClose, 2);
			this.right = this.cmdClose;
			this.idSelect = 1;
			this.cmdQuay.isPlayframe = true;
		}
		base.setPotion();
		this.mItemShow = null;
	}

	// Token: 0x06000C45 RID: 3141 RVA: 0x000EB4F0 File Offset: 0x000E96F0
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case -1:
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
			break;
		}
		case 1:
			GlobalService.gI().QuayWC(4);
			break;
		case 2:
			GlobalService.gI().QuayWC((sbyte)subIndex);
			break;
		}
	}

	// Token: 0x06000C46 RID: 3142 RVA: 0x000EB574 File Offset: 0x000E9774
	public override void setPosPotion()
	{
		for (int i = 0; i < LuckyScreen.mListItemLucky.size(); i++)
		{
			MainItem mainItem = (MainItem)LuckyScreen.mListItemLucky.elementAt(i);
			bool flag = i < 8;
			if (flag)
			{
				mainItem.x = this.xQuay + CRes.getcos(CRes.fixangle(i * 360 / 8)) * 66 / 1000;
				mainItem.y = this.yQuay + CRes.getsin(CRes.fixangle(i * 360 / 8)) * 66 / 1000;
			}
			else
			{
				bool flag2 = i % 2 == 0;
				if (flag2)
				{
					mainItem.x = this.xQuay + 1 + CRes.getcos(CRes.fixangle(30 + i / 2 * 360 / 6)) * 32 / 1000;
					mainItem.y = this.yQuay + CRes.getsin(CRes.fixangle(30 + i / 2 * 360 / 6)) * 32 / 1000;
				}
				else
				{
					mainItem.x = this.xQuay + 1 + CRes.getcos(CRes.fixangle(210 + i / 2 * 360 / 6)) * 32 / 1000;
					mainItem.y = this.yQuay + CRes.getsin(CRes.fixangle(210 + i / 2 * 360 / 6)) * 32 / 1000;
				}
			}
		}
	}

	// Token: 0x06000C47 RID: 3143 RVA: 0x000EB6EC File Offset: 0x000E98EC
	public override void loadImgVongQuay()
	{
		bool flag = LuckyScreen.mImgVongquay == null;
		if (flag)
		{
			LuckyScreen.mImgVongquay = new mImage[6];
			for (int i = 0; i < LuckyScreen.mImgVongquay.Length; i++)
			{
				bool flag2 = i != 5;
				if (flag2)
				{
					LuckyScreen.mImgVongquay[i] = mImage.createImage("/interface/lucky" + i.ToString() + ".png");
				}
			}
		}
		bool flag3 = this.fraImgBuy == null;
		if (flag3)
		{
			this.fraImgBuy = new FrameImage(mImage.createImage("/interface/lucky8.png"), 37, 27);
			this.fraImg1Lan = new FrameImage(mImage.createImage("/interface/lucky6.png"), 40, 42);
			this.fraImg5Lan = new FrameImage(mImage.createImage("/interface/lucky7.png"), 40, 42);
		}
	}

	// Token: 0x06000C48 RID: 3144 RVA: 0x000EB7B8 File Offset: 0x000E99B8
	public void loadIconVongQuay()
	{
		bool flag = LuckyScreen.mImgVongquay[5] == null && this.idIconVongQuay != -1;
		if (flag)
		{
			MainImage imageAll = ObjectData.getImageAll(this.idIconVongQuay, ObjectData.HashImageOtherNew, 23000);
			bool flag2 = imageAll != null;
			if (flag2)
			{
				LuckyScreen.mImgVongquay[5] = imageAll.img;
			}
		}
	}

	// Token: 0x06000C49 RID: 3145 RVA: 0x000EB814 File Offset: 0x000E9A14
	public override void paint(mGraphics g)
	{
		this.loadIconVongQuay();
		base.paint(g);
		mFont.tahoma_7b_black.drawString(g, "QUAY", this.xButton, this.yButton + this.wButton + 5 - 12, 2);
		AvMain.FontBorderSmall(g, string.Empty + this.numLanDaQuay.ToString(), this.xButton, this.yButton + this.wButton + 5, 2, 4);
	}

	// Token: 0x06000C4A RID: 3146 RVA: 0x000EB890 File Offset: 0x000E9A90
	public override int updateNumve()
	{
		return (int)this.numVe;
	}

	// Token: 0x0400135C RID: 4956
	public new static QuayWCScreen instance;

	// Token: 0x0400135D RID: 4957
	public short idIconVongQuay = -1;

	// Token: 0x0400135E RID: 4958
	public short numLanDaQuay;

	// Token: 0x0400135F RID: 4959
	public short numVe;
}
