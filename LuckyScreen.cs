using System;

// Token: 0x02000070 RID: 112
public class LuckyScreen : MainScreen
{
	// Token: 0x060006D1 RID: 1745 RVA: 0x000957F0 File Offset: 0x000939F0
	public LuckyScreen()
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
		this.cmdClose = new iCommand(T.close, -1, this);
		this.cmdBuyTicket = new iCommand(string.Empty, 1, this);
		this.cmdQuay = new iCommand(string.Empty, 2, 1, this);
		this.cmdQuay3Lan = new iCommand(string.Empty, 2, 2, this);
		this.cmdBuyTicket.setPos(this.xButton, this.yButton + this.wButton + 5, this.fraImgBuy, string.Empty);
		this.cmdQuay.setPos(this.xButton, this.yButton + this.wButton * 2, this.fraImg1Lan, string.Empty);
		this.cmdQuay3Lan.setPos(this.xButton, this.yButton + this.wButton * 3, this.fraImg5Lan, string.Empty);
		this.vecCmd = new mVector();
		this.vecCmd.addElement(this.cmdBuyTicket);
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
		this.setPotion();
		this.mItemShow = null;
	}

	// Token: 0x060006D2 RID: 1746 RVA: 0x00095AE4 File Offset: 0x00093CE4
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
			GlobalService.gI().Quayso(4);
			break;
		case 2:
			GlobalService.gI().Quayso((sbyte)subIndex);
			break;
		}
	}

	// Token: 0x060006D3 RID: 1747 RVA: 0x00095B68 File Offset: 0x00093D68
	public void setPotion()
	{
		this.poi = null;
		for (int i = 0; i < Player.vecInventory.size(); i++)
		{
			MainItem mainItem = (MainItem)Player.vecInventory.elementAt(i);
			bool flag = mainItem.typeObject == 4 && mainItem.ID == 0;
			if (flag)
			{
				this.poi = mainItem;
				break;
			}
		}
	}

	// Token: 0x060006D4 RID: 1748 RVA: 0x00095BCC File Offset: 0x00093DCC
	public virtual void setPosPotion()
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
				mainItem.x = this.xQuay + 1 + CRes.getcos(CRes.fixangle(30 + i * 360 / 6)) * 32 / 1000;
				mainItem.y = this.yQuay + CRes.getsin(CRes.fixangle(30 + i * 360 / 6)) * 32 / 1000;
			}
		}
	}

	// Token: 0x060006D5 RID: 1749 RVA: 0x00095CC8 File Offset: 0x00093EC8
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
			AvMain.paintBG_Wanted_Room(g, this.x, this.y, this.w, this.h);
		}
		this.paintVongQuay(g);
		for (int i = 0; i < this.vecCmd.size(); i++)
		{
			iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
			iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
		}
		this.paintEff(g, 0);
	}

	// Token: 0x060006D6 RID: 1750 RVA: 0x00095D7C File Offset: 0x00093F7C
	public virtual void paintVongQuay(mGraphics g)
	{
		bool flag = LuckyScreen.mImgVongquay == null;
		if (flag)
		{
			this.loadImgVongQuay();
		}
		else
		{
			g.drawImage(LuckyScreen.mImgVongquay[5], this.xButton, this.yButton, 3);
			AvMain.FontBorderSmall(g, string.Empty + this.updateNumve().ToString(), this.xButton, this.yButton + 12, 2, 5);
			bool flag2 = this.StepQuaySo == 3 && LuckyScreen.mListItemLucky != null;
			if (flag2)
			{
				for (int i = -1; i < 2; i++)
				{
					int num = this.indexShowPotion + i;
					int num2 = LuckyScreen.mListItemLucky.size();
					bool flag3 = num < 0;
					if (flag3)
					{
						num = num2 + num;
					}
					else
					{
						bool flag4 = num >= num2;
						if (flag4)
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
			bool flag5 = this.StepQuaySo == 3;
			if (flag5)
			{
				num3 = this.mPlayVongQuayTo[this.tickVongQuay];
				num4 = this.mPlayVongQuayNho[this.tickVongQuay];
			}
			g.drawRegion(LuckyScreen.mImgVongquay[0], num3 * 95, 0, 95, 190, 0, (float)(this.xQuay - 94), (float)(this.yQuay - 94), 0);
			g.drawRegion(LuckyScreen.mImgVongquay[0], num3 * 95, 0, 95, 190, 2, (float)this.xQuay, (float)(this.yQuay - 94), 0);
			g.drawRegion(LuckyScreen.mImgVongquay[1], 0, num4 * 99, 99, 99, 0, (float)this.xQuay, (float)this.yQuay, 3);
			bool flag6 = this.StepQuaySo == 1 || this.StepQuaySo == 0;
			if (flag6)
			{
				g.drawRegion(LuckyScreen.mImgVongquay[3], 0, 0, 33, 33, 0, (float)this.xQuay, (float)this.yQuay, 3);
			}
			else
			{
				bool flag7 = this.StepQuaySo == 2;
				if (flag7)
				{
					int num5 = this.yQuay;
					bool flag8 = this.tickAction > 23;
					if (flag8)
					{
						g.drawRegion(LuckyScreen.mImgVongquay[4], 0, 33, 33, 33, 0, (float)this.xQuay, (float)(this.yQuay + 1), 3);
						g.drawRegion(LuckyScreen.mImgVongquay[4], 0, 0, 33, 33, 0, (float)this.xQuay, (float)this.yQuay, 3);
					}
					else
					{
						g.drawRegion(LuckyScreen.mImgVongquay[2], 0, this.mPlayVongTrungTam[this.tickVongQuay] * 33, 33, 33, 0, (float)this.xQuay, (float)num5, 3);
					}
				}
				else
				{
					g.drawRegion(LuckyScreen.mImgVongquay[4], 0, 0, 33, 33, 0, (float)this.xQuay, (float)this.yQuay, 3);
				}
			}
			bool flag9 = this.StepQuaySo != 2 && this.StepQuaySo != 0 && this.StepQuaySo != 1;
			if (!flag9)
			{
				for (int j = 0; j < LuckyScreen.mListItemLucky.size(); j++)
				{
					MainItem mainItem2 = (MainItem)LuckyScreen.mListItemLucky.elementAt(j);
					bool flag10 = j >= this.indexOffPaint;
					if (flag10)
					{
						mainItem2.paintAllItem(g, mainItem2.x, mainItem2.y, 24, 0, 0);
					}
				}
			}
		}
	}

	// Token: 0x060006D7 RID: 1751 RVA: 0x000960FC File Offset: 0x000942FC
	public void paintEff(mGraphics g, int level)
	{
		for (int i = 0; i < this.vecEff.size(); i++)
		{
			MainEffect mainEffect = (MainEffect)this.vecEff.elementAt(i);
			bool flag = level == 0 && mainEffect.levelPaint > -1;
			if (flag)
			{
				mainEffect.paint(g);
			}
			else
			{
				bool flag2 = mainEffect.levelPaint == -1;
				if (flag2)
				{
					mainEffect.paint(g);
				}
			}
		}
	}

	// Token: 0x060006D8 RID: 1752 RVA: 0x00096170 File Offset: 0x00094370
	public virtual void loadImgVongQuay()
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
			this.fraImgBuy = new FrameImage(mImage.createImage("/interface/lucky8.png"), 37, 27);
			this.fraImg1Lan = new FrameImage(mImage.createImage("/interface/lucky6.png"), 40, 42);
			this.fraImg5Lan = new FrameImage(mImage.createImage("/interface/lucky7.png"), 40, 42);
		}
	}

	// Token: 0x060006D9 RID: 1753 RVA: 0x0009622C File Offset: 0x0009442C
	public override void update()
	{
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.update();
		}
		for (int i = 0; i < this.vecEff.size(); i++)
		{
			MainEffect mainEffect = (MainEffect)this.vecEff.elementAt(i);
			mainEffect.update();
			bool isStop = mainEffect.isStop;
			if (isStop)
			{
				this.vecEff.removeElement(mainEffect);
				i--;
			}
		}
		this.UpdateStepQuaySo();
	}

	// Token: 0x060006DA RID: 1754 RVA: 0x000962B0 File Offset: 0x000944B0
	public virtual void UpdateStepQuaySo()
	{
		this.tickAction++;
		bool flag = this.StepQuaySo == 1;
		if (flag)
		{
			bool flag2 = this.tickAction == 5;
			if (flag2)
			{
				bool flag3 = this.typeQuay == 0;
				if (flag3)
				{
					this.vecEff.addElement(GameScreen.createEffEnd(78, 1, this.cmdQuay.xCmd, this.cmdQuay.yCmd, this.xQuay - 5, this.yQuay - 5));
				}
				else
				{
					this.vecEff.addElement(GameScreen.createEffEnd(78, 2, this.cmdQuay3Lan.xCmd, this.cmdQuay3Lan.yCmd, this.xQuay - 5, this.yQuay - 5));
				}
			}
			bool flag4 = this.tickAction == 33;
			if (flag4)
			{
				this.StepQuaySo = 2;
				this.tickAction = -10;
				this.tickVongQuay = 0;
				this.vecEff.addElement(GameScreen.createEffEnd(53, 0, this.xQuay, this.yQuay, this.xQuay, this.yQuay));
				this.indexOffPaint = 0;
			}
			bool flag5 = this.tickAction >= 100;
			if (flag5)
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
			bool flag6 = this.StepQuaySo == 2;
			if (flag6)
			{
				bool flag7 = this.tickAction >= 0;
				if (flag7)
				{
					this.tickVongQuay++;
				}
				bool flag8 = this.tickVongQuay >= this.mPlayVongTrungTam.Length;
				if (flag8)
				{
					this.tickVongQuay = this.mPlayVongTrungTam.Length - 1;
				}
				bool flag9 = this.tickAction >= 30;
				if (flag9)
				{
					this.StepQuaySo = 3;
					this.tickAction = -5;
					this.tickVongQuay = 0;
				}
				bool flag10 = this.tickAction < 0;
				if (!flag10)
				{
					int num = this.indexOffPaint;
					bool flag11 = this.tickAction < 6;
					if (flag11)
					{
						bool flag12 = this.tickAction % 5 == 0;
						if (flag12)
						{
							this.indexOffPaint++;
						}
					}
					else
					{
						bool flag13 = this.tickAction < 16;
						if (flag13)
						{
							bool flag14 = this.tickAction % 3 == 0;
							if (flag14)
							{
								this.indexOffPaint++;
							}
						}
						else
						{
							bool flag15 = this.tickAction % 2 == 0;
							if (flag15)
							{
								this.indexOffPaint++;
							}
						}
					}
					bool flag16 = this.indexOffPaint != num;
					if (flag16)
					{
						mSound.playSound(51, mSound.volumeSound);
					}
				}
			}
			else
			{
				bool flag17 = this.StepQuaySo == 3;
				if (flag17)
				{
					bool flag18 = this.tickVongQuay % 15 == 0;
					if (flag18)
					{
						mSound.playSound(49, mSound.volumeSound);
					}
					bool flag19 = GameCanvas.gameTick % 2 == 0;
					if (flag19)
					{
						this.indexShowPotion++;
					}
					bool flag20 = LuckyScreen.mListItemLucky != null && this.indexShowPotion >= LuckyScreen.mListItemLucky.size();
					if (flag20)
					{
						this.indexShowPotion = 0;
					}
					bool flag21 = this.tickAction >= 0;
					if (flag21)
					{
						this.tickVongQuay++;
					}
					bool flag22 = this.tickVongQuay >= this.mPlayVongQuayTo.Length;
					if (flag22)
					{
						this.tickVongQuay = this.mPlayVongQuayTo.Length - 1;
					}
					bool flag23 = this.tickAction >= 100;
					if (flag23)
					{
						this.StepQuaySo = 4;
						this.tickAction = 0;
					}
				}
				else
				{
					bool flag24 = this.StepQuaySo == 4;
					if (flag24)
					{
						this.indexOffPaint = 0;
						bool flag25 = this.tickAction >= 5;
						if (flag25)
						{
							this.StepQuaySo = 0;
							this.tickAction = 0;
						}
						MsgShowGift msgShowGift = new MsgShowGift();
						msgShowGift.setinfoShow_Gift(20, T.quaySo, string.Empty, this.mItemShow, -1);
						GameCanvas.Start_Current_Dialog(msgShowGift);
					}
				}
			}
		}
	}

	// Token: 0x060006DB RID: 1755 RVA: 0x000966E8 File Offset: 0x000948E8
	public override void updatekey()
	{
		bool flag = false;
		bool flag2 = GameCanvas.keyMove(1);
		if (flag2)
		{
			bool flag3 = this.idSelect > 0;
			if (flag3)
			{
				this.idSelect--;
			}
			GameCanvas.ClearkeyMove(1);
			flag = true;
		}
		else
		{
			bool flag4 = GameCanvas.keyMove(3);
			if (flag4)
			{
				bool flag5 = this.idSelect < 2;
				if (flag5)
				{
					this.idSelect++;
				}
				GameCanvas.ClearkeyMove(3);
				flag = true;
			}
		}
		bool flag6 = GameCanvas.keyMyHold[5] && this.idSelect != -1;
		if (flag6)
		{
			GameCanvas.clearKeyHold(5);
			iCommand iCommand = (iCommand)this.vecCmd.elementAt(this.idSelect);
			iCommand.perform();
		}
		bool flag7 = flag;
		if (flag7)
		{
			for (int i = 0; i < this.vecCmd.size(); i++)
			{
				iCommand iCommand2 = (iCommand)this.vecCmd.elementAt(i);
				bool flag8 = i == this.idSelect;
				if (flag8)
				{
					iCommand2.isPlayframe = true;
				}
				else
				{
					iCommand2.isPlayframe = false;
				}
			}
		}
		base.updatekey();
	}

	// Token: 0x060006DC RID: 1756 RVA: 0x00096814 File Offset: 0x00094A14
	public override void updatePointer()
	{
		bool flag = this.StepQuaySo != 0;
		if (!flag)
		{
			bool flag2 = this.vecCmd != null;
			if (flag2)
			{
				for (int i = 0; i < this.vecCmd.size(); i++)
				{
					iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
					iCommand.updatePointer();
				}
			}
			base.updatePointer();
		}
	}

	// Token: 0x060006DD RID: 1757 RVA: 0x00096880 File Offset: 0x00094A80
	public virtual int updateNumve()
	{
		bool flag = this.vequay == null || LuckyScreen.isUpdateVe;
		if (flag)
		{
			for (int i = 0; i < Player.vecInventory.size(); i++)
			{
				MainItem mainItem = (MainItem)Player.vecInventory.elementAt(i);
				bool flag2 = mainItem.typeObject == 4 && mainItem.ID == 232;
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

	// Token: 0x060006DE RID: 1758 RVA: 0x00096928 File Offset: 0x00094B28
	public void dataDialog(Item_Drop[] itemLucky)
	{
		mSystem.outz("itemLucky " + itemLucky.Length.ToString());
		this.mItemShow = null;
		this.mItemShow = itemLucky;
	}

	// Token: 0x060006DF RID: 1759 RVA: 0x00096960 File Offset: 0x00094B60
	public void addEffectNumImage(string content, int x, int y, sbyte typeColor, FrameImage fra, int frame)
	{
		EffectNum effectNum = new EffectNum(content, x, y, (int)typeColor, fra, frame);
		int num = GameScreen.find_Index_Stop(this.vecEff);
		bool flag = num == this.vecEff.size();
		if (flag)
		{
			this.vecEff.addElement(effectNum);
		}
		else
		{
			this.vecEff.setElementAt(effectNum, num);
		}
	}

	// Token: 0x040009EC RID: 2540
	public const sbyte STEP_WAIT_BEGIN = 0;

	// Token: 0x040009ED RID: 2541
	public const sbyte STEP_BEGIN = 1;

	// Token: 0x040009EE RID: 2542
	public const sbyte STEP_WAIT_QUAY = 2;

	// Token: 0x040009EF RID: 2543
	public const sbyte STEP_QUAY = 3;

	// Token: 0x040009F0 RID: 2544
	public const sbyte STEP_KETQUA = 4;

	// Token: 0x040009F1 RID: 2545
	public const sbyte TYPE_1 = 0;

	// Token: 0x040009F2 RID: 2546
	public const sbyte TYPE_3 = 1;

	// Token: 0x040009F3 RID: 2547
	public const short ID_TICKET = 0;

	// Token: 0x040009F4 RID: 2548
	public static LuckyScreen instance;

	// Token: 0x040009F5 RID: 2549
	public mVector vecCmd = new mVector();

	// Token: 0x040009F6 RID: 2550
	public mVector vecEff = new mVector("LuckyScreen.vecEff");

	// Token: 0x040009F7 RID: 2551
	protected int x;

	// Token: 0x040009F8 RID: 2552
	protected int y;

	// Token: 0x040009F9 RID: 2553
	protected int w;

	// Token: 0x040009FA RID: 2554
	protected int h;

	// Token: 0x040009FB RID: 2555
	protected int idSelect = -1;

	// Token: 0x040009FC RID: 2556
	protected int tickVongQuay;

	// Token: 0x040009FD RID: 2557
	protected int xQuay;

	// Token: 0x040009FE RID: 2558
	protected int yQuay;

	// Token: 0x040009FF RID: 2559
	protected int xButton;

	// Token: 0x04000A00 RID: 2560
	protected int yButton;

	// Token: 0x04000A01 RID: 2561
	protected int wButton;

	// Token: 0x04000A02 RID: 2562
	protected int indexShowPotion;

	// Token: 0x04000A03 RID: 2563
	public int tickAction;

	// Token: 0x04000A04 RID: 2564
	public int typeQuay;

	// Token: 0x04000A05 RID: 2565
	public int StepQuaySo;

	// Token: 0x04000A06 RID: 2566
	protected iCommand cmdClose;

	// Token: 0x04000A07 RID: 2567
	protected iCommand cmdQuay;

	// Token: 0x04000A08 RID: 2568
	protected iCommand cmdQuay3Lan;

	// Token: 0x04000A09 RID: 2569
	protected iCommand cmdBuyTicket;

	// Token: 0x04000A0A RID: 2570
	protected FrameImage fraImgBuy;

	// Token: 0x04000A0B RID: 2571
	protected FrameImage fraImg1Lan;

	// Token: 0x04000A0C RID: 2572
	protected FrameImage fraImg5Lan;

	// Token: 0x04000A0D RID: 2573
	private MainItem poi;

	// Token: 0x04000A0E RID: 2574
	public static mImage[] mImgVongquay;

	// Token: 0x04000A0F RID: 2575
	protected int[] mPlayVongTrungTam = new int[]
	{
		0,
		0,
		0,
		0,
		0,
		1,
		1,
		0,
		0,
		0,
		0,
		0,
		1,
		1,
		0,
		0,
		0,
		1,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0
	};

	// Token: 0x04000A10 RID: 2576
	protected int[] mPlayVongQuayTo = new int[]
	{
		0,
		0,
		0,
		1,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0,
		1,
		0
	};

	// Token: 0x04000A11 RID: 2577
	protected int[] mPlayVongQuayNho = new int[]
	{
		0,
		0,
		0,
		1,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1,
		0,
		0,
		1,
		1
	};

	// Token: 0x04000A12 RID: 2578
	public static mVector mListItemLucky;

	// Token: 0x04000A13 RID: 2579
	public int indexOffPaint;

	// Token: 0x04000A14 RID: 2580
	private MainItem vequay;

	// Token: 0x04000A15 RID: 2581
	public static bool isUpdateVe;

	// Token: 0x04000A16 RID: 2582
	public Item_Drop[] mItemShow;
}
