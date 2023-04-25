using System;

// Token: 0x020000D6 RID: 214
public class QuayOcSenScreen : LuckyScreen
{
	// Token: 0x06000C39 RID: 3129 RVA: 0x000E9EC4 File Offset: 0x000E80C4
	public QuayOcSenScreen()
	{
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
		LuckyScreen.mImgVongquay = null;
		this.loadImgVongQuay();
		this.cmdClose = new iCommand(T.close, -1, this);
		this.cmdQuayOcSen = new iCommand(string.Empty, 1, 4, this);
		this.cmdQuay = new iCommand(string.Empty, 1, 3, this);
		this.cmdQuayOcSen.setPos(this.xButton, this.yButton + this.wButton + 30, this.fraImgBuy, string.Empty);
		this.cmdQuay.setPos(this.xButton, this.yButton + this.wButton * 2 + 25, this.fraImg1Lan, string.Empty);
		this.vecCmd = new mVector();
		this.vecCmd.addElement(this.cmdQuayOcSen);
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
		base.setPotion();
		this.mItemShow = null;
		this.isClockwise = false;
	}

	// Token: 0x06000C3A RID: 3130 RVA: 0x000EA12C File Offset: 0x000E832C
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
		{
			GlobalService.gI().Quay_oc_sen((sbyte)subIndex);
			this.isClockwise = !this.isClockwise;
			bool flag2 = subIndex == 4;
			if (flag2)
			{
				this.typeQuay = 4;
			}
			else
			{
				this.typeQuay = 3;
			}
			break;
		}
		}
	}

	// Token: 0x06000C3B RID: 3131 RVA: 0x000EA1C8 File Offset: 0x000E83C8
	public override void setPosPotion()
	{
		for (int i = 0; i < LuckyScreen.mListItemLucky.size(); i++)
		{
			MainItem mainItem = (MainItem)LuckyScreen.mListItemLucky.elementAt(i);
			bool flag = i < 16;
			if (flag)
			{
				mainItem.x = this.xQuay + CRes.getcos(CRes.fixangle(i * 360 / 16)) * 66 / 1000;
				mainItem.y = this.yQuay + CRes.getsin(CRes.fixangle(i * 360 / 16)) * 66 / 1000;
			}
			else
			{
				mainItem.x = this.xQuay + 1 + CRes.getcos(CRes.fixangle(30 + i * 360 / 6)) * 32 / 1000;
				mainItem.y = this.yQuay + CRes.getsin(CRes.fixangle(30 + i * 360 / 6)) * 32 / 1000;
			}
		}
	}

	// Token: 0x06000C3C RID: 3132 RVA: 0x000EA2C8 File Offset: 0x000E84C8
	public override void loadImgVongQuay()
	{
		bool flag = LuckyScreen.mImgVongquay == null;
		if (flag)
		{
			LuckyScreen.mImgVongquay = new mImage[6];
			for (int i = 0; i < LuckyScreen.mImgVongquay.Length; i++)
			{
				LuckyScreen.mImgVongquay[i] = mImage.createImage("/interface/lucky" + i.ToString() + ".png");
			}
		}
		bool flag2 = this.fraImgBuy == null;
		if (flag2)
		{
			this.fraImgBuy = new FrameImage(mImage.createImage("/interface/oc_sen.png"), 28, 27);
			this.fraImg1Lan = new FrameImage(mImage.createImage("/interface/lucky6.png"), 40, 42);
			this.fraImg5Lan = new FrameImage(mImage.createImage("/interface/lucky7.png"), 40, 42);
		}
		bool flag3 = QuayOcSenScreen.imgPhatSang != null;
		if (flag3)
		{
		}
	}

	// Token: 0x06000C3D RID: 3133 RVA: 0x000EA394 File Offset: 0x000E8594
	public override void paint(mGraphics g)
	{
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.paint(g);
		}
		GameCanvas.resetTrans(g);
		bool flag2 = !GameCanvas.isSmallScreen;
		if (flag2)
		{
			AvMain.paintBG_AChi(g, this.x, this.y, this.w, this.h, 0);
		}
		AvMain.FontBorderColor(g, this.title, MotherCanvas.hw, this.y - 20, 2, 6, 5);
		this.paintVongQuay(g);
		for (int i = 0; i < this.vecCmd.size(); i++)
		{
			iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
			iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
		}
		MainTab.paintMoney(g, MotherCanvas.w - 78, 4 + GameScreen.h12plus, false);
		base.paintEff(g, 0);
	}

	// Token: 0x06000C3E RID: 3134 RVA: 0x000EA480 File Offset: 0x000E8680
	public override void paintVongQuay(mGraphics g)
	{
		bool flag = LuckyScreen.mImgVongquay == null;
		if (flag)
		{
			this.loadImgVongQuay();
		}
		else
		{
			bool flag2 = QuayOcSenScreen.imgOcSen == null;
			if (flag2)
			{
				MainImage imageAll = ObjectData.getImageAll(800, ObjectData.HashImageOtherNew, 23000);
				bool flag3 = imageAll != null;
				if (flag3)
				{
					QuayOcSenScreen.imgOcSen = imageAll.img;
				}
			}
			bool flag4 = QuayOcSenScreen.imgOcSen != null;
			if (flag4)
			{
				g.drawImage(QuayOcSenScreen.imgOcSen, this.xButton, this.yButton, 3);
			}
			AvMain.FontBorderSmall(g, string.Empty + this.updateNumve().ToString(), this.xButton + 1, this.yButton + 13, 2, 5);
			bool flag5 = (this.StepQuaySo == 3 || this.StepQuaySo == 4) && LuckyScreen.mListItemLucky != null;
			if (flag5)
			{
				for (int i = -1; i < 2; i++)
				{
					int num = this.indexShowPotion + i;
					int num2 = LuckyScreen.mListItemLucky.size();
					bool flag6 = num < 0;
					if (flag6)
					{
						num = num2 + num;
					}
					else
					{
						bool flag7 = num >= num2;
						if (flag7)
						{
							num -= num2;
						}
					}
					MainItem mainItem = (MainItem)LuckyScreen.mListItemLucky.elementAt(num);
					mainItem.paintAllItem(g, this.xQuay, this.yQuay - i * 14, 24, 0, 0);
				}
			}
			int num3 = 0;
			int num4 = 0;
			bool flag8 = this.StepQuaySo == 5;
			if (flag8)
			{
				num3 = this.mPlayVongQuayTo[this.tickVongQuay];
				num4 = this.mPlayVongQuayNho[this.tickVongQuay];
			}
			g.drawRegion(LuckyScreen.mImgVongquay[0], num3 * 95, 0, 95, 190, 0, (float)(this.xQuay - 94), (float)(this.yQuay - 94), 0);
			g.drawRegion(LuckyScreen.mImgVongquay[0], num3 * 95, 0, 95, 190, 2, (float)this.xQuay, (float)(this.yQuay - 94), 0);
			g.drawRegion(LuckyScreen.mImgVongquay[1], 0, num4 * 99, 99, 99, 0, (float)this.xQuay, (float)this.yQuay, 3);
			bool flag9 = this.StepQuaySo == 1 || this.StepQuaySo == 0;
			if (flag9)
			{
				g.drawRegion(LuckyScreen.mImgVongquay[4], 0, 33, 33, 33, 0, (float)this.xQuay, (float)this.yQuay, 3);
			}
			else
			{
				bool flag10 = this.StepQuaySo == 2;
				if (flag10)
				{
					int yQuay = this.yQuay;
					bool flag11 = this.tickAction > 23;
					if (flag11)
					{
						g.drawRegion(LuckyScreen.mImgVongquay[4], 0, 33, 33, 33, 0, (float)this.xQuay, (float)(this.yQuay + 1), 3);
						g.drawRegion(LuckyScreen.mImgVongquay[4], 0, 0, 33, 33, 0, (float)this.xQuay, (float)this.yQuay, 3);
					}
					else
					{
						g.drawRegion(LuckyScreen.mImgVongquay[2], 0, this.mPlayVongTrungTam[this.tickVongQuay] * 33, 33, 33, 0, (float)this.xQuay, (float)yQuay, 3);
					}
				}
				else
				{
					g.drawRegion(LuckyScreen.mImgVongquay[4], 0, 0, 33, 33, 0, (float)this.xQuay, (float)this.yQuay, 3);
				}
			}
			bool flag12 = this.StepQuaySo != 5;
			if (flag12)
			{
				for (int j = 0; j < LuckyScreen.mListItemLucky.size(); j++)
				{
					MainItem mainItem2 = (MainItem)LuckyScreen.mListItemLucky.elementAt(j);
					bool flag13 = j < 16 && j % 2 != 0;
					if (flag13)
					{
						AvMain.fraBorderSkill.drawFrame(0, mainItem2.x, mainItem2.y, 0, 3, g);
					}
					bool flag14 = j == this.indexShowPotion;
					if (flag14)
					{
						bool flag15 = QuayOcSenScreen.imgPhatSang == null;
						if (flag15)
						{
							MainImage imageAll2 = ObjectData.getImageAll(801, ObjectData.HashImageOtherNew, 23000);
							bool flag16 = imageAll2 != null;
							if (flag16)
							{
								QuayOcSenScreen.imgPhatSang = imageAll2.img;
							}
						}
						bool flag17 = QuayOcSenScreen.imgPhatSang != null;
						if (flag17)
						{
							g.drawRegion(QuayOcSenScreen.imgPhatSang, 0, 0, 27, 27, 0, (float)mainItem2.x, (float)mainItem2.y, 3);
						}
					}
					bool flag18 = this.mNhan != null && this.mNhan[j] == 1;
					if (flag18)
					{
						g.drawRegion(LuckyScreen.mImgVongquay[3], 0, 0, 33, 33, 0, (float)mainItem2.x, (float)mainItem2.y, 3);
					}
					else
					{
						mainItem2.paintAllItem(g, mainItem2.x, mainItem2.y, 24, 0, 0);
					}
				}
			}
			bool flag19 = this.StepQuaySo != 5;
			if (!flag19)
			{
				g.drawRegion(LuckyScreen.mImgVongquay[2], 0, this.mPlayVongTrungTam[this.tickVongQuay] * 33, 33, 33, 0, (float)this.xQuay, (float)this.yQuay, 3);
				bool flag20 = this.tickVongQuay % 2 == 0;
				if (flag20)
				{
					bool flag21 = QuayOcSenScreen.imgPhatSang == null;
					if (flag21)
					{
						MainImage imageAll3 = ObjectData.getImageAll(801, ObjectData.HashImageOtherNew, 23000);
						bool flag22 = imageAll3 != null;
						if (flag22)
						{
							QuayOcSenScreen.imgPhatSang = imageAll3.img;
						}
					}
					bool flag23 = QuayOcSenScreen.imgPhatSang != null;
					if (flag23)
					{
						g.drawImage(QuayOcSenScreen.imgPhatSang, this.xQuay, this.yQuay, 3);
					}
				}
				MainItem mainItem3 = (MainItem)LuckyScreen.mListItemLucky.elementAt(this.indexShowPotion);
				mainItem3.paintAllItem(g, this.xQuay, this.yQuay, 24, 0, 0);
			}
		}
	}

	// Token: 0x06000C3F RID: 3135 RVA: 0x000EAA30 File Offset: 0x000E8C30
	public override void UpdateStepQuaySo()
	{
		this.tickAction++;
		bool flag = this.StepQuaySo == 1;
		if (flag)
		{
			bool flag2 = this.countRemainGift < 1;
			if (flag2)
			{
				this.StepQuaySo = 4;
				this.tickAction = 20;
				return;
			}
			bool flag3 = this.tickAction == 5;
			if (flag3)
			{
				bool flag4 = this.typeQuay == 4;
				if (flag4)
				{
					this.vecEff.addElement(GameScreen.createEffEnd(78, 1, this.cmdQuayOcSen.xCmd, this.cmdQuayOcSen.yCmd, this.xQuay - 5, this.yQuay - 5));
				}
				else
				{
					this.vecEff.addElement(GameScreen.createEffEnd(78, 2, this.cmdQuay.xCmd, this.cmdQuay.yCmd, this.xQuay - 5, this.yQuay - 5));
				}
			}
			bool flag5 = this.tickAction == 33;
			if (flag5)
			{
				this.StepQuaySo = 2;
				this.tickAction = -10;
				this.tickVongQuay = 0;
				this.vecEff.addElement(GameScreen.createEffEnd(53, 0, this.xQuay, this.yQuay, this.xQuay, this.yQuay));
			}
			bool flag6 = this.tickAction >= 100;
			if (flag6)
			{
				this.StepQuaySo = 2;
				this.tickAction = -10;
				this.tickVongQuay = 0;
				this.vecEff.addElement(GameScreen.createEffEnd(53, 0, this.xQuay, this.yQuay, this.xQuay, this.yQuay));
			}
		}
		else
		{
			bool flag7 = this.StepQuaySo == 2;
			if (flag7)
			{
				bool flag8 = this.tickAction >= 0;
				if (flag8)
				{
					this.tickVongQuay++;
				}
				bool flag9 = this.tickVongQuay >= this.mPlayVongTrungTam.Length;
				if (flag9)
				{
					this.tickVongQuay = this.mPlayVongTrungTam.Length - 1;
				}
				bool flag10 = this.tickAction >= 30;
				if (flag10)
				{
					this.StepQuaySo = 3;
					this.tickAction = -5;
					this.tickVongQuay = 0;
				}
			}
			else
			{
				bool flag11 = this.StepQuaySo == 3;
				if (flag11)
				{
					bool flag12 = this.tickAction >= 0;
					if (flag12)
					{
						int indexShowPotion = this.indexShowPotion;
						bool flag13 = this.tickAction < 12;
						if (flag13)
						{
							bool flag14 = this.tickAction % 6 == 0;
							if (flag14)
							{
								this.IncreaseIndexShowPotion();
							}
						}
						else
						{
							bool flag15 = this.tickAction < 20;
							if (flag15)
							{
								bool flag16 = this.tickAction % 4 == 0;
								if (flag16)
								{
									this.IncreaseIndexShowPotion();
								}
							}
							else
							{
								bool flag17 = this.tickAction % 3 == 0;
								if (flag17)
								{
									this.IncreaseIndexShowPotion();
								}
							}
						}
						bool flag18 = this.indexShowPotion != indexShowPotion;
						if (flag18)
						{
							mSound.playSound(51, mSound.volumeSound);
						}
					}
					bool flag19 = this.tickVongQuay % 15 == 0;
					if (flag19)
					{
						mSound.playSound(49, mSound.volumeSound);
					}
					bool flag20 = this.tickAction >= 100;
					if (flag20)
					{
						this.StepQuaySo = 4;
						this.tickAction = 0;
					}
				}
				else
				{
					bool flag21 = this.StepQuaySo == 4;
					if (flag21)
					{
						bool flag22 = this.tickAction >= 0;
						if (flag22)
						{
							int indexShowPotion2 = this.indexShowPotion;
							bool flag23 = this.tickAction < 10;
							if (flag23)
							{
								bool flag24 = this.tickAction % 4 == 0;
								if (flag24)
								{
									this.IncreaseIndexShowPotion();
								}
							}
							else
							{
								bool flag25 = this.tickAction % 6 == 0;
								if (flag25)
								{
									this.IncreaseIndexShowPotion();
								}
							}
							bool flag26 = this.indexShowPotion != indexShowPotion2;
							if (flag26)
							{
								mSound.playSound(51, mSound.volumeSound);
							}
						}
						bool flag27 = this.tickAction > 15 && this.indexShowPotion == (int)this.indexQuaySo;
						if (flag27)
						{
							MainItem mainItem = (MainItem)LuckyScreen.mListItemLucky.elementAt((int)this.indexQuaySo);
							this.vecEff.addElement(GameScreen.createEffEnd(53, 0, mainItem.x, mainItem.y, mainItem.x, mainItem.y));
							this.StepQuaySo = 5;
							this.vecEff.addElement(GameScreen.createEffEnd(78, 1, mainItem.x, mainItem.y, this.xQuay, this.yQuay));
							this.tickAction = 0;
						}
						bool flag28 = this.tickVongQuay % 15 == 0;
						if (flag28)
						{
							mSound.playSound(49, mSound.volumeSound);
						}
					}
					else
					{
						bool flag29 = this.StepQuaySo == 5;
						if (flag29)
						{
							bool flag30 = this.tickAction >= 0 && this.tickAction % 4 == 0;
							if (flag30)
							{
								this.tickVongQuay++;
							}
							bool flag31 = this.tickVongQuay >= this.mPlayVongQuayTo.Length;
							if (flag31)
							{
								this.tickVongQuay = this.mPlayVongQuayTo.Length - 1;
							}
							bool flag32 = this.tickAction == 24;
							if (flag32)
							{
								this.vecEff.addElement(GameScreen.createEffEnd(53, 0, this.xQuay, this.yQuay, this.xQuay, this.yQuay));
							}
							bool flag33 = this.tickAction == 34;
							if (flag33)
							{
								MainItem mainItem2 = (MainItem)LuckyScreen.mListItemLucky.elementAt((int)this.indexQuaySo);
								MainImage image = mainItem2.getImage();
								bool flag34 = image != null && image.img != null;
								if (flag34)
								{
									bool flag35 = image.frame == -1;
									if (flag35)
									{
										image.set_Frame();
									}
									base.addEffectNumImage(" x " + Interface_Game.ConvertNumToStr(mainItem2.numInt), this.xQuay, this.yQuay, 3, new FrameImage(image.img, (int)image.frame), 0);
								}
							}
							bool flag36 = this.tickAction == 70;
							if (flag36)
							{
								this.StepQuaySo = 0;
								this.tickAction = 0;
								bool flag37 = this.indexQuaySo >= 0 && (int)this.indexQuaySo < this.mNhan.Length;
								if (flag37)
								{
									this.mNhan[(int)this.indexQuaySo] = 1;
								}
								bool flag38 = this.countRemainGift > 0;
								if (flag38)
								{
									this.IncreaseIndexShowPotion();
								}
							}
						}
					}
				}
			}
		}
		bool flag39 = LuckyScreen.mListItemLucky != null;
		if (flag39)
		{
			bool flag40 = this.indexShowPotion >= LuckyScreen.mListItemLucky.size();
			if (flag40)
			{
				this.indexShowPotion = 0;
			}
			bool flag41 = this.indexShowPotion < 0;
			if (flag41)
			{
				this.indexShowPotion = LuckyScreen.mListItemLucky.size() - 1;
			}
		}
	}

	// Token: 0x06000C40 RID: 3136 RVA: 0x000EB0E8 File Offset: 0x000E92E8
	public void SetmNhan(sbyte[] m)
	{
		this.mNhan = m;
		for (int i = 0; i < this.mNhan.Length; i++)
		{
			bool flag = this.mNhan[i] == 0;
			if (flag)
			{
				this.countRemainGift++;
			}
		}
	}

	// Token: 0x06000C41 RID: 3137 RVA: 0x000EB138 File Offset: 0x000E9338
	public void SetIndexQuaySo(sbyte index)
	{
		bool flag = this.indexQuaySo != index;
		if (flag)
		{
			this.indexQuaySo = index;
			this.countRemainGift--;
			mSound.playSound(48, mSound.volumeSound);
			this.StepQuaySo = 1;
			this.tickAction = 0;
		}
	}

	// Token: 0x06000C42 RID: 3138 RVA: 0x000EB188 File Offset: 0x000E9388
	private void IncreaseIndexShowPotion()
	{
		do
		{
			this.indexShowPotion += (this.isClockwise ? 1 : -1);
			bool flag = this.indexShowPotion >= LuckyScreen.mListItemLucky.size();
			if (flag)
			{
				this.indexShowPotion = 0;
			}
			bool flag2 = this.indexShowPotion < 0;
			if (flag2)
			{
				this.indexShowPotion = LuckyScreen.mListItemLucky.size() - 1;
			}
		}
		while (this.mNhan[this.indexShowPotion] == 1);
	}

	// Token: 0x06000C43 RID: 3139 RVA: 0x000EB208 File Offset: 0x000E9408
	public override int updateNumve()
	{
		bool flag = this.vequay == null || LuckyScreen.isUpdateVe;
		if (flag)
		{
			for (int i = 0; i < Player.vecInventory.size(); i++)
			{
				MainItem mainItem = (MainItem)Player.vecInventory.elementAt(i);
				bool flag2 = mainItem.typeObject == 4 && mainItem.ID == 441;
				if (flag2)
				{
					this.vequay = mainItem;
					LuckyScreen.isUpdateVe = false;
					break;
				}
			}
		}
		bool flag3 = this.vequay != null;
		int result;
		if (flag3)
		{
			result = (int)this.vequay.numPotion;
		}
		else
		{
			result = 0;
		}
		return result;
	}

	// Token: 0x0400134F RID: 4943
	public const sbyte STEP_SHOW_KETQUA = 5;

	// Token: 0x04001350 RID: 4944
	public const sbyte TYPE_XOAY_RUBY = 3;

	// Token: 0x04001351 RID: 4945
	public const sbyte TYPE_XOAY_OC_SEN = 4;

	// Token: 0x04001352 RID: 4946
	public new static QuayOcSenScreen instance;

	// Token: 0x04001353 RID: 4947
	private iCommand cmdQuayOcSen;

	// Token: 0x04001354 RID: 4948
	private sbyte indexQuaySo = -1;

	// Token: 0x04001355 RID: 4949
	private bool isClockwise;

	// Token: 0x04001356 RID: 4950
	private static mImage imgPhatSang;

	// Token: 0x04001357 RID: 4951
	private static mImage imgOcSen;

	// Token: 0x04001358 RID: 4952
	private sbyte[] mNhan;

	// Token: 0x04001359 RID: 4953
	public string title = string.Empty;

	// Token: 0x0400135A RID: 4954
	private int countRemainGift;

	// Token: 0x0400135B RID: 4955
	private MainItem vequay;
}
