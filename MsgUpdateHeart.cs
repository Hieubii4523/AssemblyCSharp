using System;

// Token: 0x020000AE RID: 174
public class MsgUpdateHeart : ScreenUpgrade
{
	// Token: 0x06000A7D RID: 2685 RVA: 0x000D5280 File Offset: 0x000D3480
	public MsgUpdateHeart()
	{
		this.w = 150;
		this.h = 190 + GameCanvas.hCommand;
		this.x = MotherCanvas.hw - this.w / 2;
		this.y = MotherCanvas.hh - this.h / 2 - 5;
		this.ylech = 10;
		bool flag = !GameCanvas.isTouch;
		if (flag)
		{
			this.h -= 30;
			this.ylech += 12;
		}
		this.vecCmd = new mVector();
		this.cmdClose = new iCommand(T.close, 0, this);
		this.cmdUpgrade = new iCommand(T.mo, 1, this);
		this.vecCmd.addElement(this.cmdClose);
		this.vecCmd.addElement(this.cmdUpgrade);
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.cmdClose.setPos(this.x + this.w / 2 + 60, this.y + 20, MainTab.fraCloseTab3, string.Empty);
			this.cmdUpgrade.setPos(this.x + this.w / 2, this.y + this.h - GameCanvas.hCommand + 5, MainTab.fraCmdMo, string.Empty);
			this.backCMD = this.cmdClose;
			this.okCMD = this.cmdUpgrade;
		}
		else
		{
			this.cmdClose = AvMain.setPosCMD(this.cmdClose, 2);
			this.cmdUpgrade = AvMain.setPosCMD(this.cmdUpgrade, 0);
			this.right = this.cmdClose;
			this.center = this.cmdUpgrade;
		}
		MainItem mainItem = (MainItem)GameScreen.player.hashEquip.get(string.Empty + 7.ToString());
		bool flag2 = mainItem != null && mainItem.typeSpec == 1;
		if (flag2)
		{
			this.itemHeart = mainItem;
		}
	}

	// Token: 0x06000A7E RID: 2686 RVA: 0x000D54B8 File Offset: 0x000D36B8
	public override void commandPointer(int index, int subIndex)
	{
		if (index != 0)
		{
			if (index == 1)
			{
				GlobalService.gI().Upgrade_Item(15, -1, 0);
				this.stepUpgrade = 2;
				this.tickStep = 0;
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
		}
	}

	// Token: 0x06000A7F RID: 2687 RVA: 0x000D552C File Offset: 0x000D372C
	public override void paint(mGraphics g)
	{
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.paint(g);
		}
		GameCanvas.resetTrans(g);
		Interface_Game.paintInfoPlayer_Short(g, MotherCanvas.hw - 160, 3 + GameScreen.h12plus, true, mFont.tahoma_7_black);
		base.paintPaper(g, MotherCanvas.hw - this.w / 2, this.y, this.w, this.h, this.w, (int)AvMain.PAPER_LAW);
		this.paintInfoHeart(g);
		bool flag2 = AvMain.imgEff_Law == null;
		if (flag2)
		{
			base.load_Img_Law();
		}
		g.drawImage(AvMain.imgEff_Law[7], this.x + this.w / 2, this.y + 20, 3);
		g.drawImage(AvMain.imgEff_Law[0], this.x + this.w / 2, this.y + this.h / 2 + this.ylech, 3);
		bool flag3 = this.stepUpgrade == 0 || this.stepUpgrade == 2;
		if (flag3)
		{
			g.drawRegion(AvMain.imgEff_Law[6], 0, 50 * this.mplayFrameNormal[this.playHeart], 48, 50, 0, (float)(this.x + this.w / 2), (float)(this.y + this.h / 2 + this.ylech), 3);
		}
		else
		{
			bool flag4 = this.stepUpgrade == 1;
			if (flag4)
			{
				bool flag5 = this.playHeart < 115 || GameCanvas.gameTick % 3 != 0;
				if (flag5)
				{
					bool flag6 = this.play1_0 > 0;
					if (flag6)
					{
						g.drawRegion(AvMain.imgEff_Law[1], 0, 55 - this.play1_0, this.play1_0, this.play1_0, 0, (float)(this.x + this.w / 2 - 55), (float)(this.y + this.h / 2 + this.ylech - this.play1_0), 0);
					}
					bool flag7 = this.play1_1 > 0;
					if (flag7)
					{
						g.drawRegion(AvMain.imgEff_Law[1], 55, 0, this.play1_1, this.play1_1, 0, (float)(this.x + this.w / 2), (float)(this.y + this.h / 2 + this.ylech - 55), 0);
					}
					bool flag8 = this.play1_2 > 0;
					if (flag8)
					{
						g.drawRegion(AvMain.imgEff_Law[1], 110 - this.play1_2, 55, this.play1_2, this.play1_2, 0, (float)(this.x + this.w / 2 + 55 - this.play1_2), (float)(this.y + this.h / 2 + this.ylech), 0);
					}
					bool flag9 = this.play1_3 > 0;
					if (flag9)
					{
						g.drawRegion(AvMain.imgEff_Law[1], 55 - this.play1_3, 110 - this.play1_3, this.play1_3, this.play1_3, 0, (float)(this.x + this.w / 2 - this.play1_3), (float)(this.y + this.h / 2 + this.ylech + 55 - this.play1_3), 0);
					}
					bool flag10 = this.play2 > 0;
					if (flag10)
					{
						g.drawRegion(AvMain.imgEff_Law[2], 0, 0, 90, this.play2, 0, (float)(this.x + this.w / 2 - 45), (float)(this.y + this.h / 2 + this.ylech - 45), 0);
					}
					bool flag11 = this.play3_0 > 0;
					if (flag11)
					{
						g.drawRegion(AvMain.imgEff_Law[3], 0, 0, this.play3_0, this.play3_0, 0, (float)(this.x + this.w / 2 - 32), (float)(this.y + this.h / 2 + this.ylech - 32), 0);
					}
					bool flag12 = this.play3_1 > 0;
					if (flag12)
					{
						g.drawRegion(AvMain.imgEff_Law[3], 62, 0, 2, this.play3_1, 0, (float)(this.x + this.w / 2 + 32 - 2), (float)(this.y + this.h / 2 + this.ylech - 32), 0);
						g.drawRegion(AvMain.imgEff_Law[3], 0, 62, this.play3_1, 2, 0, (float)(this.x + this.w / 2 - 32), (float)(this.y + this.h / 2 + this.ylech + 32 - 2), 0);
					}
					bool flag13 = this.play4_0 > 0;
					if (flag13)
					{
						g.drawRegion(AvMain.imgEff_Law[4], 32 - this.play4_0, 0, this.play4_0, this.play4_0, 0, (float)(this.x + this.w / 2 - this.play4_0), (float)(this.y + this.h / 2 + this.ylech - 32), 0);
					}
					bool flag14 = this.play4_1 > 0;
					if (flag14)
					{
						g.drawRegion(AvMain.imgEff_Law[4], 0, 32, this.play4_1, this.play4_1, 0, (float)(this.x + this.w / 2 - 32), (float)(this.y + this.h / 2 + this.ylech), 0);
					}
					bool flag15 = this.play4_2 > 0;
					if (flag15)
					{
						g.drawRegion(AvMain.imgEff_Law[4], 32, 64 - this.play4_2, this.play4_2, this.play4_2, 0, (float)(this.x + this.w / 2), (float)(this.y + this.h / 2 + this.ylech + 32 - this.play4_2), 0);
					}
					bool flag16 = this.play4_3 > 0;
					if (flag16)
					{
						g.drawRegion(AvMain.imgEff_Law[4], 64 - this.play4_3, 32 - this.play4_3, this.play4_3, this.play4_3, 0, (float)(this.x + this.w / 2 + 32 - this.play4_3), (float)(this.y + this.h / 2 + this.ylech - this.play4_3), 0);
					}
				}
				g.drawRegion(AvMain.imgEff_Law[6], 0, 50 * this.mplayFrameUpgrade[this.playHeart], 48, 50, 0, (float)(this.x + this.w / 2), (float)(this.y + this.h / 2 + this.ylech), 3);
			}
		}
		g.drawImage(AvMain.imgEff_Law[5], this.x + this.w / 2, this.y + this.h / 2 + this.ylech, 3);
		GameCanvas.resetTrans(g);
		for (int i = 0; i < this.vecEff.size(); i++)
		{
			MainEffect mainEffect = (MainEffect)this.vecEff.elementAt(i);
			bool flag17 = mainEffect.levelPaint != -1;
			if (flag17)
			{
				mainEffect.paint(g);
				mainEffect.paint(g, 0, 0);
			}
		}
		bool flag18 = this.stepUpgrade == 0 && this.vecCmd != null;
		if (flag18)
		{
			for (int j = 0; j < this.vecCmd.size(); j++)
			{
				iCommand iCommand = (iCommand)this.vecCmd.elementAt(j);
				iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
			}
		}
	}

	// Token: 0x06000A80 RID: 2688 RVA: 0x000D5CB4 File Offset: 0x000D3EB4
	private void paintInfoHeart(mGraphics g)
	{
		bool flag = this.itemHeart != null;
		if (flag)
		{
			mFont.tahoma_7b_white.drawString(g, T.cuonghoa + ": +" + this.itemHeart.LvUpgrade.ToString(), this.x + 10, this.y + 33, 0);
			mFont.tahoma_7b_white.drawString(g, T.chetac + this.itemHeart.valueCheTac.ToString(), this.x + 10, this.y + 33 + GameCanvas.hText, 0);
		}
	}

	// Token: 0x06000A81 RID: 2689 RVA: 0x000D5D50 File Offset: 0x000D3F50
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
		bool flag2 = this.stepUpgrade == 2;
		if (flag2)
		{
			this.tickStep++;
			bool flag3 = this.tickStep >= 80;
			if (flag3)
			{
				this.stepUpgrade = 0;
			}
		}
		this.playHeart++;
		bool flag4 = this.stepUpgrade == 0 || this.stepUpgrade == 2;
		if (flag4)
		{
			bool flag5 = this.playHeart >= this.mplayFrameNormal.Length;
			if (flag5)
			{
				this.playHeart = 0;
			}
		}
		else
		{
			bool flag6 = this.stepUpgrade != 1;
			if (!flag6)
			{
				this.play1_0 = this.playHeart * 5;
				bool flag7 = this.play1_0 > 55;
				if (flag7)
				{
					this.play1_0 = 55;
				}
				this.play1_1 = (this.playHeart - 11) * 5;
				bool flag8 = this.play1_1 > 55;
				if (flag8)
				{
					this.play1_1 = 55;
				}
				this.play1_2 = (this.playHeart - 22) * 5;
				bool flag9 = this.play1_2 > 55;
				if (flag9)
				{
					this.play1_2 = 55;
				}
				this.play1_3 = (this.playHeart - 33) * 5;
				bool flag10 = this.play1_3 > 55;
				if (flag10)
				{
					this.play1_3 = 55;
				}
				this.play2 = (this.playHeart - 44) * 5;
				bool flag11 = this.play2 > 90;
				if (flag11)
				{
					this.play2 = 90;
				}
				this.play3_0 = (this.playHeart - 59) * 5;
				bool flag12 = this.play3_0 > 63;
				if (flag12)
				{
					this.play3_0 = 63;
				}
				this.play3_1 = (this.playHeart - 72) * 5;
				bool flag13 = this.play3_1 > 64;
				if (flag13)
				{
					this.play3_1 = 64;
				}
				this.play4_0 = (this.playHeart - 85) * 5;
				bool flag14 = this.play4_0 > 32;
				if (flag14)
				{
					this.play4_0 = 32;
				}
				this.play4_1 = (this.playHeart - 91) * 5;
				bool flag15 = this.play4_1 > 32;
				if (flag15)
				{
					this.play4_1 = 32;
				}
				this.play4_2 = (this.playHeart - 97) * 5;
				bool flag16 = this.play4_2 > 32;
				if (flag16)
				{
					this.play4_2 = 32;
				}
				this.play4_3 = (this.playHeart - 103) * 5;
				bool flag17 = this.play4_3 > 32;
				if (flag17)
				{
					this.play4_3 = 32;
				}
				bool flag18 = this.playHeart >= this.mplayFrameUpgrade.Length;
				if (flag18)
				{
					this.playHeart = 0;
					this.play1_0 = 0;
					this.play1_1 = 0;
					this.play2 = 0;
					this.stepUpgrade = 0;
					MainItem mainItem = (MainItem)GameScreen.player.hashEquip.get(string.Empty + 7.ToString());
					bool flag19 = mainItem != null && mainItem.typeSpec == 1;
					if (flag19)
					{
						this.itemHeart = mainItem;
					}
					GameCanvas.Start_Normal_Only_CmdClose_DiaLog(this.text);
				}
				bool flag20 = this.playHeart >= this.mplayFrameUpgrade.Length - 50 && this.playHeart <= this.mplayFrameUpgrade.Length - 20 && this.playHeart % 5 == 0;
				if (flag20)
				{
					mSound.playSound(7, mSound.volumeSound);
					base.createEff(10, 0, this.x + this.w / 2, this.y + this.h / 2 + 5, this.x + this.w / 2, this.y + this.h / 2 + 5);
				}
				bool flag21 = this.playHeart != this.mplayFrameUpgrade.Length - 20;
				if (!flag21)
				{
					bool flag22 = this.Step == 16;
					if (flag22)
					{
						mSound.playSound(28, mSound.volumeSound);
						int subtype = 0;
						bool flag23 = GameCanvas.language == 1;
						if (flag23)
						{
							subtype = 2;
						}
						base.createEff(79, subtype, this.x + this.w / 2, this.y + this.h / 2 + this.ylech, this.x + this.w / 2, this.y + this.h / 2 + this.ylech);
						base.createEff(76, 0, this.x + this.w / 2, this.y + this.h / 2 + this.ylech, this.x + this.w / 2, this.y + this.h / 2 + this.ylech);
						base.createEff(53, 0, this.x + this.w / 2, this.y + this.h / 2 + this.ylech, this.x + this.w / 2, this.y + this.h / 2 + this.ylech);
					}
					else
					{
						bool flag24 = this.Step == 17;
						if (flag24)
						{
							mSound.playSound(29, mSound.volumeSound);
							int subtype2 = 1;
							bool flag25 = GameCanvas.language == 1;
							if (flag25)
							{
								subtype2 = 3;
							}
							base.createEff(79, subtype2, this.x + this.w / 2, this.y + this.h / 2 + this.ylech, this.x + this.w / 2, this.y + this.h / 2 + this.ylech);
							base.createEff(77, 0, this.x + this.w / 2, this.y + this.h / 2 + this.ylech, this.x + this.w / 2, this.y + this.h / 2 + this.ylech);
						}
					}
				}
			}
		}
	}

	// Token: 0x06000A82 RID: 2690 RVA: 0x000D63B0 File Offset: 0x000D45B0
	public override void updatePointer()
	{
		bool flag = this.stepUpgrade == 0 && this.vecCmd != null;
		if (flag)
		{
			for (int i = 0; i < this.vecCmd.size(); i++)
			{
				iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
				iCommand.updatePointer();
			}
		}
	}

	// Token: 0x06000A83 RID: 2691 RVA: 0x000D6410 File Offset: 0x000D4610
	public override void updatekey()
	{
		bool flag = this.stepUpgrade == 0;
		if (flag)
		{
			base.updatekeySuper();
		}
	}

	// Token: 0x06000A84 RID: 2692 RVA: 0x000D6434 File Offset: 0x000D4634
	public void updateStepUpgrade(sbyte type, string text)
	{
		bool flag = type == 16 || type == 17;
		if (flag)
		{
			this.playHeart = 0;
			this.play1_0 = 0;
			this.play1_1 = 0;
			this.play2 = 0;
			this.stepUpgrade = 1;
			this.Step = (int)type;
		}
		this.text = text;
		bool flag2 = this.cmdUpgrade != null;
		if (flag2)
		{
			this.cmdUpgrade.isSelect = false;
			this.cmdUpgrade.frameCmd = 0;
		}
	}

	// Token: 0x04001069 RID: 4201
	public const sbyte STEP_NORMAL = 0;

	// Token: 0x0400106A RID: 4202
	public const sbyte STEP_UPGRADE = 1;

	// Token: 0x0400106B RID: 4203
	public const sbyte STEP_WAIT_UPGRADE = 2;

	// Token: 0x0400106C RID: 4204
	public new static MsgUpdateHeart instance;

	// Token: 0x0400106D RID: 4205
	private string text = string.Empty;

	// Token: 0x0400106E RID: 4206
	private MainItem itemHeart;

	// Token: 0x0400106F RID: 4207
	private int ylech;

	// Token: 0x04001070 RID: 4208
	private new iCommand cmdUpgrade;

	// Token: 0x04001071 RID: 4209
	private int[] mplayFrameNormal = new int[]
	{
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		2,
		2,
		2,
		2,
		2,
		2,
		2
	};

	// Token: 0x04001072 RID: 4210
	private int[] mplayFrameUpgrade = new int[]
	{
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		2,
		2,
		2,
		2,
		2,
		2,
		2,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		2,
		2,
		2,
		2,
		2,
		2,
		2,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		2,
		2,
		2,
		2,
		2,
		2,
		2,
		1,
		1,
		1,
		1,
		1,
		2,
		2,
		2,
		2,
		0,
		0,
		0,
		0,
		1,
		1,
		1,
		2,
		2,
		2,
		0,
		0,
		1,
		1,
		2,
		2,
		0,
		1,
		2,
		0,
		1,
		2,
		0,
		1,
		2,
		0,
		1,
		2,
		0,
		1,
		2,
		0,
		1,
		2,
		0,
		1,
		2,
		0,
		1,
		2,
		0,
		1,
		2,
		0,
		1,
		2,
		0,
		1,
		2,
		0,
		1,
		2,
		0,
		1,
		2,
		0,
		1,
		2,
		0,
		1,
		2,
		0,
		1,
		2,
		0,
		1,
		2,
		0,
		1,
		2,
		0,
		1,
		2,
		0,
		1,
		2,
		0,
		1,
		2,
		0,
		1,
		2,
		0,
		1,
		2,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		2,
		2,
		2,
		2,
		2,
		2,
		2
	};

	// Token: 0x04001073 RID: 4211
	private int stepUpgrade;

	// Token: 0x04001074 RID: 4212
	private int playHeart;

	// Token: 0x04001075 RID: 4213
	private int play1_0;

	// Token: 0x04001076 RID: 4214
	private int play1_1;

	// Token: 0x04001077 RID: 4215
	private int play1_2;

	// Token: 0x04001078 RID: 4216
	private int play1_3;

	// Token: 0x04001079 RID: 4217
	private int play2;

	// Token: 0x0400107A RID: 4218
	private int play3_0;

	// Token: 0x0400107B RID: 4219
	private int play3_1;

	// Token: 0x0400107C RID: 4220
	private int play4_0;

	// Token: 0x0400107D RID: 4221
	private int play4_1;

	// Token: 0x0400107E RID: 4222
	private int play4_2;

	// Token: 0x0400107F RID: 4223
	private int play4_3;
}
