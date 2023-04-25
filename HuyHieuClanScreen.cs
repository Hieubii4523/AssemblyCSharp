using System;

// Token: 0x02000042 RID: 66
public class HuyHieuClanScreen : LuckyScreen
{
	// Token: 0x0600050D RID: 1293 RVA: 0x0007CC7C File Offset: 0x0007AE7C
	public HuyHieuClanScreen()
	{
		this.StepQuaySo = 0;
		this.w = 280;
		this.h = 230;
		bool flag = this.h > MotherCanvas.h;
		if (flag)
		{
			this.h = MotherCanvas.h;
		}
		this.x = MotherCanvas.hw - this.w / 2;
		this.y = MotherCanvas.hh - this.h / 2;
		this.xQuay = this.x + 110;
		this.yQuay = this.y + this.h / 2 + 6;
		this.wButton = (this.h - 25) / 5 + 5;
		this.xButton = this.x + this.w - 50;
		this.yButton = this.y + 22 + this.wButton;
		this.loadImgVongQuay();
		this.cmdClose = new iCommand(T.close, -1, this);
		this.cmdQuay = new iCommand(string.Empty, 1, this);
		this.cmdQuay.setPos(this.xButton + 1, this.yButton + this.wButton * 5 / 2, this.fraImg1Lan, string.Empty);
		this.vecCmd = new mVector();
		this.vecCmd.addElement(this.cmdQuay);
		this.vecCmd.addElement(this.cmdClose);
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			int num = this.x + this.w - 13;
			bool flag2 = num > MotherCanvas.w - 9;
			if (flag2)
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
	}

	// Token: 0x0600050E RID: 1294 RVA: 0x0007CE6C File Offset: 0x0007B06C
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
			GlobalService.gI().Huy_hieu(3, 1, this.potionQuay.ID);
			break;
		}
	}

	// Token: 0x0600050F RID: 1295 RVA: 0x0007CEE8 File Offset: 0x0007B0E8
	public override void loadImgVongQuay()
	{
		bool flag = HuyHieuClanScreen.mImgHuyHieu == null;
		if (flag)
		{
			HuyHieuClanScreen.mImgHuyHieu = new mImage[3];
			for (int i = 0; i < HuyHieuClanScreen.mImgHuyHieu.Length; i++)
			{
				HuyHieuClanScreen.mImgHuyHieu[i] = mImage.createImage("/interface/huyhieu" + i.ToString() + ".png");
			}
		}
		this.fraImg1Lan = new FrameImage(mImage.createImage("/interface/lucky6.png"), 40, 42);
		this.fraRuong = new FrameImage(mImage.createImage("/interface/huyhieu3.png"), 12);
	}

	// Token: 0x06000510 RID: 1296 RVA: 0x0007CF7C File Offset: 0x0007B17C
	public override void paint(mGraphics g)
	{
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.paint(g);
		}
		GameCanvas.resetTrans(g);
		AvMain.paintBG_AChi(g, this.x, this.y, this.w, this.h, 0);
		AvMain.FontBorderColor(g, T.huyHieuHanhTrinh, MotherCanvas.hw, this.y - 20, 2, 6, 5);
		this.paintVongQuay(g);
		int num = this.yButton + this.wButton * 3 / 2;
		AvMain.paintRect(g, this.xButton - 16, num - 16, 32, 32, 1, 4);
		bool flag2 = this.potionQuay != null;
		if (flag2)
		{
			this.potionQuay.paintQuay(g, this.xButton, num, 32);
		}
		for (int i = 0; i < this.vecCmd.size(); i++)
		{
			iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
			iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
		}
		MainTab.paintMoney(g, MotherCanvas.w - 78, 4 + GameScreen.h12plus, false);
		base.paintEff(g, 0);
	}

	// Token: 0x06000511 RID: 1297 RVA: 0x0007D0B4 File Offset: 0x0007B2B4
	public override void paintVongQuay(mGraphics g)
	{
		bool flag = HuyHieuClanScreen.mImgHuyHieu == null;
		if (flag)
		{
			this.loadImgVongQuay();
		}
		else
		{
			g.drawImage(HuyHieuClanScreen.mImgHuyHieu[2], this.xButton, this.yButton, 3);
			mSystem.outz("numpotion quay " + this.potionQuay.numPotion.ToString());
			AvMain.FontBorderSmall(g, string.Empty + this.potionQuay.numPotion.ToString(), this.xButton + 1, this.yButton + 13, 2, 5);
			mFont.tahoma_7b_black.drawString(g, string.Empty + 0.ToString(), this.xButton + 1, this.yButton + 23, 2);
			int num = 0;
			int num2 = 0;
			bool flag2 = this.StepQuaySo == 3;
			if (flag2)
			{
				num = this.mPlayVongQuayTo[this.tickVongQuay];
				num2 = this.mPlayVongQuayNho[this.tickVongQuay];
			}
			g.drawRegion(HuyHieuClanScreen.mImgHuyHieu[0], num * 90, 0, 90, 180, 0, (float)(this.xQuay - 89), (float)(this.yQuay - 89), 0);
			g.drawRegion(HuyHieuClanScreen.mImgHuyHieu[0], num * 90, 0, 90, 180, 2, (float)this.xQuay, (float)(this.yQuay - 89), 0);
			g.drawRegion(HuyHieuClanScreen.mImgHuyHieu[1], 0, num2 * 105, 105, 105, 0, (float)this.xQuay, (float)this.yQuay, 3);
			this.fraRuong.drawFrame(this.tickRuong, this.xQuay + 3, this.yQuay - 8, 0, 3, g);
		}
	}

	// Token: 0x06000512 RID: 1298 RVA: 0x0007D258 File Offset: 0x0007B458
	public override void UpdateStepQuaySo()
	{
		bool flag = this.potionNhan != null;
		if (flag)
		{
			this.imgNhan = Potion.getIconClan(this.potionNhan.idIcon);
		}
		bool flag2 = this.imgNhan != null && this.imgNhan.img != null;
		if (flag2)
		{
			int imageWidth = mImage.getImageWidth(this.imgNhan.img.image);
			int imageHeight = mImage.getImageHeight(this.imgNhan.img.image);
			bool flag3 = imageHeight / 2 >= imageWidth;
			if (flag3)
			{
				this.fraNhan = new FrameImage(this.imgNhan.img, imageWidth, imageWidth);
			}
		}
		this.tickAction++;
		bool flag4 = this.StepQuaySo == 0;
		if (flag4)
		{
			this.tickRuong = this.tickAction / 4 % 6;
		}
		else
		{
			bool flag5 = this.StepQuaySo == 1;
			if (flag5)
			{
				this.tickRuong = 0;
				bool flag6 = this.tickAction == 5;
				if (flag6)
				{
					bool flag7 = this.typeQuay == 0;
					if (flag7)
					{
						this.vecEff.addElement(GameScreen.createEffEnd(78, 1, this.cmdQuay.xCmd, this.cmdQuay.yCmd, this.xQuay - 5, this.yQuay - 5));
					}
					else
					{
						this.vecEff.addElement(GameScreen.createEffEnd(78, 2, this.cmdQuay3Lan.xCmd, this.cmdQuay3Lan.yCmd, this.xQuay - 5, this.yQuay - 5));
					}
				}
				bool flag8 = this.tickAction == 33;
				if (flag8)
				{
					this.StepQuaySo = 2;
					this.tickAction = -10;
					this.tickVongQuay = 0;
					this.vecEff.addElement(GameScreen.createEffEnd(53, 0, this.xQuay, this.yQuay, this.xQuay, this.yQuay));
					this.indexOffPaint = 0;
				}
				bool flag9 = this.tickAction >= 100;
				if (flag9)
				{
					this.StepQuaySo = 2;
					this.tickAction = -10;
					this.tickVongQuay = 0;
					this.vecEff.addElement(GameScreen.createEffEnd(53, 0, this.xQuay, this.yQuay, this.xQuay, this.yQuay));
					this.indexOffPaint = 0;
				}
			}
			else
			{
				bool flag10 = this.StepQuaySo == 2;
				if (flag10)
				{
					bool flag11 = this.tickAction >= 0;
					if (flag11)
					{
						this.tickVongQuay++;
					}
					bool flag12 = this.tickVongQuay >= this.mPlayVongTrungTam.Length;
					if (flag12)
					{
						this.tickVongQuay = this.mPlayVongTrungTam.Length - 1;
					}
					bool flag13 = this.tickAction >= 10;
					if (flag13)
					{
						this.StepQuaySo = 3;
						this.tickAction = -5;
						this.tickVongQuay = 0;
					}
					bool flag14 = this.tickAction < 0;
					if (!flag14)
					{
						int indexOffPaint = this.indexOffPaint;
						bool flag15 = this.tickAction < 6;
						if (flag15)
						{
							bool flag16 = this.tickAction % 5 == 0;
							if (flag16)
							{
								this.indexOffPaint++;
							}
						}
						else
						{
							bool flag17 = this.tickAction < 16;
							if (flag17)
							{
								bool flag18 = this.tickAction % 3 == 0;
								if (flag18)
								{
									this.indexOffPaint++;
								}
							}
							else
							{
								bool flag19 = this.tickAction % 2 == 0;
								if (flag19)
								{
									this.indexOffPaint++;
								}
							}
						}
						bool flag20 = this.indexOffPaint != indexOffPaint;
						if (flag20)
						{
							mSound.playSound(51, mSound.volumeSound);
						}
					}
				}
				else
				{
					bool flag21 = this.StepQuaySo == 3;
					if (flag21)
					{
						bool flag22 = this.tickVongQuay % 15 == 0;
						if (flag22)
						{
							mSound.playSound(49, mSound.volumeSound);
						}
						bool flag23 = GameCanvas.gameTick % 2 == 0;
						if (flag23)
						{
							this.indexShowPotion++;
						}
						bool flag24 = LuckyScreen.mListItemLucky != null && this.indexShowPotion >= LuckyScreen.mListItemLucky.size();
						if (flag24)
						{
							this.indexShowPotion = 0;
						}
						bool flag25 = this.tickAction >= 0;
						if (flag25)
						{
							this.tickVongQuay++;
						}
						bool flag26 = this.tickVongQuay >= this.mPlayVongQuayTo.Length;
						if (flag26)
						{
							this.tickVongQuay = this.mPlayVongQuayTo.Length - 1;
						}
						bool flag27 = this.tickAction >= 100;
						if (flag27)
						{
							this.StepQuaySo = 4;
							this.tickAction = 0;
						}
					}
					else
					{
						bool flag28 = this.StepQuaySo != 4;
						if (!flag28)
						{
							this.indexOffPaint = 0;
							bool flag29 = this.tickAction < 36;
							if (flag29)
							{
								this.tickRuong = this.tickAction / 3;
							}
							bool flag30 = this.tickAction == 36;
							if (flag30)
							{
								Interface_Game.isPaintInfoServer = true;
								bool flag31 = !this.isThanhCong;
								if (flag31)
								{
									mSound.playSound(29, mSound.volumeSound);
									int subtype = 1;
									bool flag32 = GameCanvas.language == 1;
									if (flag32)
									{
										subtype = 3;
									}
									int num = 10;
									this.createEff(79, subtype, this.xQuay + 3, this.yQuay - 15 + num, this.xQuay + 3, this.yQuay - 15 + num);
									this.createEff(77, 0, this.xQuay + 3, this.yQuay - 15 + num, this.xQuay + 3, this.yQuay - 15 + num);
								}
								else
								{
									mSystem.outz("potionNhan cat " + this.potionNhan.typeObject.ToString() + " icon " + this.potionNhan.idIcon.ToString());
									this.createEff(53, 0, this.xQuay + 3, this.yQuay - 15, this.xQuay + 3, this.yQuay - 15);
									base.addEffectNumImage(string.Empty, this.xQuay + 3, this.yQuay - 15, 3, this.fraNhan, 0);
									this.isThanhCong = false;
								}
							}
							bool flag33 = this.tickAction == 100;
							if (flag33)
							{
								this.StepQuaySo = 0;
								this.tickAction = 0;
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x06000513 RID: 1299 RVA: 0x0007D8AC File Offset: 0x0007BAAC
	public void createEff(short type, int subtype, int x, int y, int xto, int yto)
	{
		Effect_End o = new Effect_End(type, (sbyte)subtype, x, y, xto, yto, 0, null);
		this.vecEff.addElement(o);
	}

	// Token: 0x04000743 RID: 1859
	public new static HuyHieuClanScreen instance;

	// Token: 0x04000744 RID: 1860
	private FrameImage fraRuong;

	// Token: 0x04000745 RID: 1861
	private static mImage[] mImgHuyHieu;

	// Token: 0x04000746 RID: 1862
	public MainItem potionQuay;

	// Token: 0x04000747 RID: 1863
	public Potion potionNhan;

	// Token: 0x04000748 RID: 1864
	public bool isThanhCong;

	// Token: 0x04000749 RID: 1865
	private MainImage imgNhan;

	// Token: 0x0400074A RID: 1866
	private FrameImage fraNhan;

	// Token: 0x0400074B RID: 1867
	private int tickRuong;
}
