using System;

// Token: 0x02000055 RID: 85
public class Interface_Game
{
	// Token: 0x060005A9 RID: 1449 RVA: 0x00082394 File Offset: 0x00080594
	public void load_Image_Pointer()
	{
		bool flag = !GameCanvas.isTouch;
		if (flag)
		{
			Interface_Game.typeTouch = 0;
		}
		this.maxTimeChange = 5;
		Interface_Game.xFocus = MotherCanvas.w - 56;
		Interface_Game.hInfoServer = 20;
		Interface_Game.xNumMess = 38;
		Interface_Game.xAutoFire = MotherCanvas.w - 29;
		Interface_Game.yAutoFire = MotherCanvas.h - 170;
		bool flag2 = !GameCanvas.isTouch;
		if (flag2)
		{
			Interface_Game.xNumMess = 35;
		}
		Interface_Game.yNumMess = 50;
		Interface_Game.wInfoServer = 120;
		bool flag3 = MotherCanvas.w > 330;
		if (flag3)
		{
			Interface_Game.wInfoServer = 140;
		}
		bool flag4 = Interface_Game.wInfoServer > MotherCanvas.w - (Interface_Game.xNumMess * 2 + 40);
		if (flag4)
		{
			Interface_Game.wInfoServer = MotherCanvas.w - (Interface_Game.xNumMess * 2 + 40);
		}
		bool flag5 = Interface_Game.wInfoServer < 100;
		if (flag5)
		{
			Interface_Game.wInfoServer = 100;
		}
		bool flag6 = !GameCanvas.isTouch;
		if (flag6)
		{
			Interface_Game.xChat = 5;
			Interface_Game.yChat = 50;
		}
		bool flag7 = MotherCanvas.w >= 320;
		if (flag7)
		{
			Interface_Game.yInfoServer = 3;
			Interface_Game.xInfoServer = MotherCanvas.hw - Interface_Game.wInfoServer / 2;
		}
		else
		{
			Interface_Game.xInfoServer = MotherCanvas.hw - Interface_Game.wInfoServer / 2;
			Interface_Game.yInfoServer = 3;
			bool flag8 = Interface_Game.xInfoServer < 92;
			if (flag8)
			{
				Interface_Game.yInfoServer = 48;
				Interface_Game.xInfoServer = MotherCanvas.w - Interface_Game.wInfoServer - 3;
				Interface_Game.isSmallInfoServer = true;
			}
		}
		bool isSmallScreen = GameCanvas.isSmallScreen;
		if (isSmallScreen)
		{
			this.valueSmallScreen = 10;
		}
		Interface_Game.yNumMess -= this.valueSmallScreen;
		Interface_Game.yInfoServer -= this.valueSmallScreen;
		Interface_Game.yQuickChat = MotherCanvas.h - 50;
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			Interface_Game.wSkill = 32;
			Interface_Game.xPointMove = 55;
			Interface_Game.yPointMove = MotherCanvas.h - 55;
			Interface_Game.imgMove = new mImage[2];
			for (int i = 0; i < Interface_Game.imgMove.Length; i++)
			{
				Interface_Game.imgMove[i] = mImage.createImage("/point/move_" + i.ToString() + ".png");
			}
			for (int j = 0; j < Interface_Game.mPosMove.Length; j++)
			{
				Interface_Game.mPosMove[j][0] = Interface_Game.xPointMove + ((j < 2) ? (-Interface_Game.wArrowMove + Interface_Game.wArrowMove * 2 * (j % 2)) : 0);
				Interface_Game.mPosMove[j][1] = Interface_Game.yPointMove + ((j > 1) ? (-Interface_Game.wArrowMove + Interface_Game.wArrowMove * 2 * (j % 2)) : 0);
			}
			Interface_Game.imgFire = new mImage[3];
			for (int k = 0; k < Interface_Game.imgFire.Length; k++)
			{
				Interface_Game.imgFire[k] = mImage.createImage("/point/fire_" + k.ToString() + ".png");
			}
			Interface_Game.mPosOther[0][0] = 3;
			Interface_Game.mPosOther[0][1] = 3;
			Interface_Game.mPosOther[1][0] = 4;
			Interface_Game.mPosOther[1][1] = 46;
			Interface_Game.mPosOther[2][0] = MotherCanvas.w - 30;
			Interface_Game.mPosOther[2][1] = MotherCanvas.h - 30;
			Interface_Game.mPosOther[3][0] = MotherCanvas.w - 30;
			Interface_Game.mPosOther[3][1] = MotherCanvas.h - 145;
			Interface_Game.mPosOther[4][0] = -2;
			Interface_Game.mPosOther[4][1] = MotherCanvas.h / 2 - 20;
			Interface_Game.mPosOther[5][0] = 66;
			Interface_Game.mPosOther[5][1] = 45;
			Interface_Game.setPosTouch();
			this.setPosMenu_TaiTho();
			Interface_Game.imgOther = new mImage[6];
			for (int l = 0; l < Interface_Game.imgOther.Length; l++)
			{
				Interface_Game.imgOther[l] = mImage.createImage("/point/other_" + l.ToString() + ".png");
				bool flag9 = l == 0;
				if (flag9)
				{
					Interface_Game.mSizeImgOther[l][0] = 92;
					Interface_Game.mSizeImgOther[l][1] = 45;
				}
				else
				{
					Interface_Game.mSizeImgOther[l][0] = mImage.getImageWidth(Interface_Game.imgOther[l].image);
					Interface_Game.mSizeImgOther[l][1] = mImage.getImageHeight(Interface_Game.imgOther[l].image) / 2;
				}
			}
			QuickMenu.fraQuickMenu = new FrameImage[16];
			for (int m = 0; m < QuickMenu.fraQuickMenu.Length; m++)
			{
				QuickMenu.fraQuickMenu[m] = new FrameImage(mImage.createImage("/point/quick_" + m.ToString() + ".png"), 30, 30);
			}
			QuickMenu.imgNenMenu = mImage.createImage("/point/nenmenu.png");
			QuickMenu.imgTamGiac = mImage.createImage("/point/tamgiac.png");
		}
		this.loadPosLoL();
		this.setPosSkill();
		Interface_Game.setYTouch();
	}

	// Token: 0x060005AA RID: 1450 RVA: 0x00082880 File Offset: 0x00080A80
	public void setPosMenu_TaiTho()
	{
		Interface_Game.mPosOther[4][0] = -2;
		Interface_Game.mPosOther[0][0] = 3;
		Interface_Game.mPosOther[5][0] = 66;
		Interface_Game.xNumMess = 38;
		bool isTaiTho = GameCanvas.isTaiTho;
		if (isTaiTho)
		{
			Interface_Game.mPosOther[4][0] = 30;
			Interface_Game.mPosOther[0][0] = 8;
			Interface_Game.mPosOther[5][0] = 71;
			Interface_Game.xNumMess = 43;
		}
	}

	// Token: 0x060005AB RID: 1451 RVA: 0x000828E8 File Offset: 0x00080AE8
	public void loadPosLoL()
	{
		Interface_Game.xLoL = MotherCanvas.hw;
		Interface_Game.yLoL = 34 + GameScreen.h12plus;
		bool flag = MotherCanvas.w < 280;
		if (flag)
		{
			Interface_Game.xLoL = MotherCanvas.w - 52;
			Interface_Game.yLoL = 72 + GameScreen.h12plus;
		}
	}

	// Token: 0x060005AC RID: 1452 RVA: 0x0008293C File Offset: 0x00080B3C
	public void loadImageLOL()
	{
		Interface_Game.fraLol = new FrameImage[6];
		for (int i = 0; i < Interface_Game.fraLol.Length; i++)
		{
			Interface_Game.fraLol[i] = new FrameImage(mImage.createImage("/interface/lol" + i.ToString() + ".png"), 2);
		}
		bool flag = !GameCanvas.lowGraphic;
		if (flag)
		{
			Interface_Game.imgbgLoL = mImage.createImage("/interface/lol10.png");
		}
		Interface_Game.imgHoiSinhLoL = mImage.createImage("/interface/lol12.png");
	}

	// Token: 0x060005AD RID: 1453 RVA: 0x000829C4 File Offset: 0x00080BC4
	public static void setYTouch()
	{
		Interface_Game.mPosOther[0][1] = 3 + GameScreen.h12plus;
		Interface_Game.mPosOther[1][1] = 46 + GameScreen.h12plus;
		Interface_Game.mPosOther[5][1] = 45 + GameScreen.h12plus;
		Interface_Game.yNumMess = 50 + GameScreen.h12plus;
		bool isSmallScreen = GameCanvas.isSmallScreen;
		if (isSmallScreen)
		{
			Interface_Game.yNumMess -= 10;
		}
	}

	// Token: 0x060005AE RID: 1454 RVA: 0x00082A2C File Offset: 0x00080C2C
	public void paintInGame(mGraphics g)
	{
		bool flag = GameCanvas.isTouch && this.xShow < 75 && Interface_Game.vecClanDam != null && Interface_Game.vecClanDam.size() > 0;
		if (flag)
		{
			this.paintInfoClanDam(g);
		}
		else
		{
			bool flag2 = GameScreen.player != null && GameScreen.player.Action != 4;
			if (flag2)
			{
				bool flag3 = GameCanvas.isTouch && Interface_Game.typeTouch == 0;
				if (flag3)
				{
					g.drawImage(Interface_Game.imgMove[0], Interface_Game.xPointMove, Interface_Game.yPointMove, 3);
					for (int i = 0; i < 4; i++)
					{
						bool flag4 = Interface_Game.timePointer > 0 && this.mKeyMove[i] == Interface_Game.keyPoint;
						if (flag4)
						{
							this.paintMoveTouch(g, i);
						}
					}
				}
				Interface_Game.timePaintIconSkill = 90;
				bool flag5 = GameCanvas.loadmap.mapLang() && Interface_Game.timePaintIconSkill <= 0 && !Player.isGhost;
				if (flag5)
				{
					bool flag6 = Interface_Game.typeTouch == 0 && GameCanvas.isTouch && GameScreen.objFocus != null;
					if (flag6)
					{
						bool flag7 = AvMain.imgTrade == null;
						if (flag7)
						{
							AvMain.imgTrade = mImage.createImage("/interface/icontrade.png");
						}
						else
						{
							g.drawImage(AvMain.imgTrade, Interface_Game.mPosKillCur[2][0], Interface_Game.mPosKillCur[2][1], 3);
						}
					}
				}
				else
				{
					bool flag8 = Interface_Game.timePaintIconSkill > 0;
					if (flag8)
					{
						Interface_Game.timePaintIconSkill--;
					}
					bool flag9 = GameScreen.tickPvP <= 0;
					if (flag9)
					{
						for (int j = 0; j < Interface_Game.mPosKillCur.Length; j++)
						{
							int num = Interface_Game.mPosKillCur[j][0] + Interface_Game.mVChangTab[j][0] * this.timeChangeTab / 100;
							int num2 = Interface_Game.mPosKillCur[j][1] + Interface_Game.mVChangTab[j][1] * this.timeChangeTab / 100;
							bool flag10 = this.timeChangeTab == 0 && !GameCanvas.isTouch;
							if (flag10)
							{
								mFont.tahoma_7b_black.drawString(g, string.Empty + Interface_Game.mValueHotKey[j].ToString(), Interface_Game.mPosKillCur[j][0] - Interface_Game.wSkill / 2 + 9, Interface_Game.mPosKillCur[j][1], 0);
							}
							Hotkey hotkey = Player.hotkeyPlayer[(int)Player.currentTab][j];
							bool flag11 = false;
							bool flag12 = j == 2 && this.isPaintIconGiaotiep();
							if (flag12)
							{
								flag11 = true;
							}
							bool isGhost = Player.isGhost;
							if (isGhost)
							{
								g.drawImage(AvMain.imgHotKey, num, num2, 3);
							}
							else
							{
								bool isTouch = GameCanvas.isTouch;
								if (isTouch)
								{
									int num3 = 0;
									bool flag13 = Interface_Game.timePointer > 0 && Interface_Game.keyPoint == Interface_Game.mValueHotKey[j];
									if (flag13)
									{
										num3 = 1;
									}
									this.paintHotKey(g, hotkey, num, num2, 20, flag11);
									bool flag14 = hotkey.skill == null || hotkey.skill.lvDevil == 0 || flag11;
									if (flag14)
									{
										bool flag15 = j == 2 && Interface_Game.typeTouch == 0;
										if (flag15)
										{
											g.drawRegion(Interface_Game.imgFire[1], 0, num3 * 50, 50, 50, 0, (float)num, (float)num2, 3);
										}
										else
										{
											g.drawRegion(Interface_Game.imgFire[0], 0, num3 * 50, 50, 50, 0, (float)num, (float)num2, 3);
										}
									}
								}
								else
								{
									this.paintHotKey(g, hotkey, num, num2, 20, flag11);
									g.drawImage(AvMain.imgHotKey, num, num2, 3);
								}
							}
						}
						bool flag16 = !GameCanvas.loadmap.mapLang() && GameCanvas.isTouch && GameScreen.isShowSkillBuff;
						if (flag16)
						{
							for (int k = 0; k < Interface_Game.mPosKillBuff.Length; k++)
							{
								int num4 = Interface_Game.mPosKillBuff[k][0];
								int num5 = Interface_Game.mPosKillBuff[k][1];
								bool isTouch2 = GameCanvas.isTouch;
								if (isTouch2)
								{
									int num6 = 0;
									bool flag17 = Interface_Game.timePointer > 0 && Interface_Game.keyPoint == 200 + k;
									if (flag17)
									{
										num6 = 1;
									}
									Hotkey hotkey2 = Player.hotkeyBuffPlayer[k];
									bool flag18 = hotkey2 != null;
									if (flag18)
									{
										this.paintHotKey(g, hotkey2, num4, num5, 20, false);
										g.drawRegion(Interface_Game.imgFire[2], 0, num6 * 50, 50, 50, 0, (float)num4, (float)num5, 3);
									}
								}
							}
						}
					}
					bool flag19 = Player.mComboSkill != null && Player.mComboSkill.Length != 0 && !Player.isGhost && !GameCanvas.loadmap.mapLang();
					if (flag19)
					{
						this.paintComboSkill(g);
					}
				}
			}
			bool isTouch3 = GameCanvas.isTouch;
			if (isTouch3)
			{
				for (int l = 0; l < Interface_Game.mPosOther.Length; l++)
				{
					bool flag20 = l == 0 || (l == 2 && GameCanvas.loadmap.mapLang() && Interface_Game.timePaintIconSkill <= 0) || (l == 5 && GameScreen.player.clan == null);
					if (!flag20)
					{
						int num7 = 0;
						bool flag21 = Interface_Game.timePointer > 0 && Interface_Game.keyPoint == 100 + l;
						if (flag21)
						{
							num7 = 1;
						}
						bool flag22 = GameScreen.player.Action == 4 && l == 2;
						if (!flag22)
						{
							int num8 = Interface_Game.mPosOther[l][0];
							int num9 = Interface_Game.mPosOther[l][1];
							bool flag23 = l == 5 && Clan_Screen.isNew;
							if (flag23)
							{
								g.drawRegion(Interface_Game.imgOther[l], 0, num7 * Interface_Game.mSizeImgOther[l][1], Interface_Game.mSizeImgOther[l][0], Interface_Game.mSizeImgOther[l][1], 0, (float)num8, (float)(num9 + Interface_Game.numClan.yNum), 0);
								bool flag24 = GameCanvas.gameTick % 10 < 5;
								if (flag24)
								{
									g.drawImage(MainEvent.imgNew, num8, num9 + 3 + Interface_Game.numClan.yNum, 0);
								}
							}
							else
							{
								g.drawRegion(Interface_Game.imgOther[l], 0, num7 * Interface_Game.mSizeImgOther[l][1], Interface_Game.mSizeImgOther[l][0], Interface_Game.mSizeImgOther[l][1], 0, (float)num8, (float)num9, 0);
							}
						}
					}
				}
			}
			bool flag25 = GameCanvas.currentScreen == GameCanvas.gameScr;
			if (flag25)
			{
				this.paintVecBuffCurrent(g);
				bool flag26 = !GameCanvas.isTouch;
				if (flag26)
				{
					this.paintInfoClanDam(g);
				}
			}
			bool flag27 = this.timeChangeTab > 0;
			if (flag27)
			{
				this.paintChangTab(g);
			}
		}
	}

	// Token: 0x060005AF RID: 1455 RVA: 0x000830D8 File Offset: 0x000812D8
	public void paintVecEffKickAn(mGraphics g)
	{
		bool flag = Interface_Game.mCountKichAn == null;
		if (!flag)
		{
			int num = 12;
			int num2 = 3 + num / 2 + GameScreen.h12plus;
			bool isPvPNew = GameScreen.isPvPNew;
			if (isPvPNew)
			{
				num2 = Interface_Game.yNumMess + 22 + GameScreen.h12plus;
				num = 28;
				int num3 = 0;
				while (num3 < Interface_Game.mCountKichAn.Length && Interface_Game.mCountKichAn[num3] != null)
				{
					g.drawImage(AvMain.imgBgnum, 22 + num3 * num, num2, 3);
					Interface_Game.mCountKichAn[num3].paintHotkey(g, 12 + num3 * num, num2, 11, 0);
					AvMain.FontBorderSmall(g, string.Empty + Interface_Game.mCountKichAn[num3].numPotion.ToString(), 25 + num3 * num, num2 - 5, 2, (int)Interface_Game.mCountKichAn[num3].colorName);
					num3++;
				}
			}
			else
			{
				int num4 = 0;
				while (num4 < Interface_Game.mCountKichAn.Length && Interface_Game.mCountKichAn[num4] != null)
				{
					g.drawImage(AvMain.imgBgnum, 112, num2 + num * num4, 3);
					Interface_Game.mCountKichAn[num4].paintHotkey(g, 102, num2 + num * num4, 11, 0);
					AvMain.FontBorderSmall(g, string.Empty + Interface_Game.mCountKichAn[num4].numPotion.ToString(), 115, num2 + num * num4 - 5, 2, (int)Interface_Game.mCountKichAn[num4].colorName);
					num4++;
				}
			}
		}
	}

	// Token: 0x060005B0 RID: 1456 RVA: 0x00083260 File Offset: 0x00081460
	public bool isPaintIconGiaotiep()
	{
		bool flag = GameCanvas.loadmap.mapLang();
		bool result;
		if (flag)
		{
			result = true;
		}
		else
		{
			bool flag2 = !GameScreen.player.setFightPk(GameScreen.objFocus);
			result = flag2;
		}
		return result;
	}

	// Token: 0x060005B1 RID: 1457 RVA: 0x000832A4 File Offset: 0x000814A4
	public void paintMoveTouch(mGraphics g, int i)
	{
		switch (i)
		{
		case 0:
			g.drawRegion(Interface_Game.imgMove[1], 0, 34, 38, 34, 0, (float)Interface_Game.mPosMove[i][0], (float)Interface_Game.mPosMove[i][1], 3);
			break;
		case 1:
			g.drawRegion(Interface_Game.imgMove[1], 63, 34, 38, 34, 0, (float)Interface_Game.mPosMove[i][0], (float)Interface_Game.mPosMove[i][1], 3);
			break;
		case 2:
			g.drawRegion(Interface_Game.imgMove[1], 34, 0, 34, 38, 0, (float)Interface_Game.mPosMove[i][0], (float)Interface_Game.mPosMove[i][1], 3);
			break;
		case 3:
			g.drawRegion(Interface_Game.imgMove[1], 34, 63, 34, 38, 0, (float)Interface_Game.mPosMove[i][0], (float)Interface_Game.mPosMove[i][1], 3);
			break;
		}
	}

	// Token: 0x060005B2 RID: 1458 RVA: 0x0008338C File Offset: 0x0008158C
	public void paintViewGame(mGraphics g)
	{
		int num = 30;
		int num2 = 20;
		int num3 = MotherCanvas.w - 20;
		int num4 = 15;
		for (int i = 0; i < GameScreen.vecPlayers.size(); i++)
		{
			MainObject mainObject = (MainObject)GameScreen.vecPlayers.elementAt(i);
			bool flag = mainObject.indexTeam == 1;
			if (flag)
			{
				Interface_Game.PaintHPMP(g, 1, mainObject.Hp, mainObject.maxHp, num2 + 7, num4 + (int)mainObject.indexPaintView * num - 8, 0, 9, 66, 0, false, mainObject.HpEff, false, 0);
				Interface_Game.PaintHPMP(g, 2, mainObject.Mp, mainObject.maxMp, num2 + 7, num4 + (int)mainObject.indexPaintView * num + 11 - 8, 0, 9, 66, 0, false, 0, false, 0);
				bool flag2 = AvMain.fraBorder == null;
				if (flag2)
				{
					AvMain.fraBorder = new FrameImage(mImage.createImage("/interface/border.png"), 26, 26);
				}
				else
				{
					AvMain.fraBorder.drawFrame(0, num2 - 2, num4 + (int)mainObject.indexPaintView * num + 2, 0, 3, g);
				}
				mainObject.paintHead(g, num2 - 2, num4 + (int)mainObject.indexPaintView * num - 2, 2);
				mFont.tahoma_7b_white.drawString(g, string.Empty + mainObject.Lv.ToString(), num2 + 6, num4 + (int)mainObject.indexPaintView * num + 2, 2);
			}
			else
			{
				bool flag3 = mainObject.indexTeam == 2;
				if (flag3)
				{
					Interface_Game.PaintHPMP(g, 1, mainObject.Hp, mainObject.maxHp, num3 - 7 - 66, num4 + (int)mainObject.indexPaintView * num - 8, 0, 9, 66, 0, true, mainObject.HpEff, false, 0);
					Interface_Game.PaintHPMP(g, 2, mainObject.Mp, mainObject.maxMp, num3 - 7 - 66, num4 + (int)mainObject.indexPaintView * num + 11 - 8, 0, 9, 66, 0, true, 0, false, 0);
					bool flag4 = AvMain.fraBorder == null;
					if (flag4)
					{
						AvMain.fraBorder = new FrameImage(mImage.createImage("/interface/border.png"), 26, 26);
					}
					else
					{
						AvMain.fraBorder.drawFrame(0, num3 + 2, num4 + (int)mainObject.indexPaintView * num + 2, 0, 3, g);
					}
					mainObject.paintHead(g, num3 + 2, num4 + (int)mainObject.indexPaintView * num - 2, 0);
					mFont.tahoma_7b_white.drawString(g, string.Empty + mainObject.Lv.ToString(), num3 - 6, num4 + (int)mainObject.indexPaintView * num + 2, 2);
				}
			}
		}
	}

	// Token: 0x060005B3 RID: 1459 RVA: 0x00083620 File Offset: 0x00081820
	private void paintComboSkill(mGraphics g)
	{
		short[] mComboSkill = Player.mComboSkill;
		int num = mComboSkill.Length;
		int num2 = Interface_Game.wComboSkill;
		int num3 = Interface_Game.yBeginCombo;
		int num4 = Interface_Game.xBeginCombo - num * Interface_Game.wComboSkill / 2;
		bool flag = Interface_Game.checkPaintWatch();
		if (flag)
		{
			num3 += Interface_Game.wComboSkill;
		}
		bool flag2 = !Interface_Game.isCombo;
		if (flag2)
		{
			for (int i = 0; i < num; i++)
			{
				int num5 = i;
				num4 = Interface_Game.xBeginCombo + num5 * num2 - num / 2 * num2 - num % 2 * num2 / 2 + num2 / 2;
				int x = Interface_Game.wComboSkill;
				bool flag3 = num5 == 0;
				if (flag3)
				{
					x = 0;
				}
				else
				{
					bool flag4 = num5 == num - 1;
					if (flag4)
					{
						x = Interface_Game.wComboSkill * 2;
					}
				}
				g.drawRegion(AvMain.imgCombo, x, 0, Interface_Game.wComboSkill, Interface_Game.wComboSkill, 0, (float)(num4 - Interface_Game.wComboSkill / 2), (float)(num3 - Interface_Game.wComboSkill / 2), 0);
				bool flag5 = i <= Interface_Game.indexEffCombo && Interface_Game.timeEndCombo % 4 < 2;
				if (flag5)
				{
					g.setColor(14885955);
					g.fillRect(num4 - Interface_Game.wComboSkill / 2 + 2, num3 - Interface_Game.wComboSkill / 2 + 2, Interface_Game.wComboSkill - 4, Interface_Game.wComboSkill - 4);
				}
			}
			Interface_Game.timeEndCombo++;
			bool flag6 = Interface_Game.indexEffCombo < num;
			if (flag6)
			{
				Interface_Game.indexEffCombo++;
			}
			bool flag7 = Interface_Game.timeEndCombo >= num + 6;
			if (flag7)
			{
				Interface_Game.timeEndCombo = 0;
				Interface_Game.indexEffCombo = -1;
				Interface_Game.isCombo = true;
				Player.mComboSkill = null;
				Player.indexCombo = -1;
			}
		}
		else
		{
			bool flag8 = Interface_Game.timeCombo > 0;
			if (flag8)
			{
				Interface_Game.timeCombo--;
				for (int j = 0; j < num; j++)
				{
					int num6 = j;
					num4 = Interface_Game.xBeginCombo + num6 * num2 - num / 2 * num2 - num % 2 * num2 / 2 + num2 / 2;
					int x2 = Interface_Game.wComboSkill;
					bool flag9 = num6 == 0;
					if (flag9)
					{
						x2 = 0;
					}
					else
					{
						bool flag10 = num6 == num - 1;
						if (flag10)
						{
							x2 = Interface_Game.wComboSkill * 2;
						}
					}
					g.drawRegion(AvMain.imgCombo, x2, 0, Interface_Game.wComboSkill, Interface_Game.wComboSkill, 0, (float)(num4 - Interface_Game.wComboSkill / 2), (float)(num3 - Interface_Game.wComboSkill / 2), 0);
					bool flag11 = j == Interface_Game.indexEffCombo;
					if (flag11)
					{
						g.setColor(16777215);
						g.fillRect(num4 - Interface_Game.wComboSkill / 2, num3 - Interface_Game.wComboSkill / 2, Interface_Game.wComboSkill, Interface_Game.wComboSkill);
					}
					bool flag12 = j < Interface_Game.indexEffCombo;
					if (flag12)
					{
						Skill_Info.paintIcon(g, num4, num3, mComboSkill[num6], 0);
					}
				}
				Interface_Game.indexEffCombo++;
				bool flag13 = Interface_Game.indexEffCombo > num;
				if (flag13)
				{
					Interface_Game.timeCombo = 0;
					Interface_Game.indexEffCombo = -1;
				}
			}
			else
			{
				for (int k = 0; k < num; k++)
				{
					int num7 = k;
					num4 = Interface_Game.xBeginCombo + num7 * num2 - num / 2 * num2 - num % 2 * num2 / 2 + num2 / 2;
					int x3 = Interface_Game.wComboSkill;
					bool flag14 = num7 == 0;
					if (flag14)
					{
						x3 = 0;
					}
					else
					{
						bool flag15 = num7 == num - 1;
						if (flag15)
						{
							x3 = Interface_Game.wComboSkill * 2;
						}
					}
					g.drawRegion(AvMain.imgCombo, x3, 0, Interface_Game.wComboSkill, Interface_Game.wComboSkill, 0, (float)(num4 - Interface_Game.wComboSkill / 2), (float)(num3 - Interface_Game.wComboSkill / 2), 0);
					bool flag16 = k == Interface_Game.indexEffCombo;
					if (flag16)
					{
						AvMain.fraComboSkill.drawFrame(Interface_Game.frameCombo / 2, num4, num3, 0, 3, g);
						Interface_Game.frameCombo++;
						bool flag17 = Interface_Game.frameCombo / 2 >= 4;
						if (flag17)
						{
							Interface_Game.indexEffCombo = -1;
							Interface_Game.frameCombo = 0;
						}
					}
					else
					{
						Skill_Info.paintIcon(g, num4, num3, mComboSkill[num7], 0);
						bool flag18 = num7 <= Player.indexCombo;
						if (flag18)
						{
							g.drawRegion(AvMain.imgDelay, 0, 0, Interface_Game.wComboSkill, Interface_Game.wComboSkill, 0, (float)(num4 - Interface_Game.wComboSkill / 2), (float)(num3 - Interface_Game.wComboSkill / 2), 0);
						}
						bool flag19 = k == Player.indexCombo + 1;
						if (flag19)
						{
							g.drawImage(AvMain.imgBorderCombo, num4, num3, 3);
						}
					}
				}
			}
		}
	}

	// Token: 0x060005B4 RID: 1460 RVA: 0x00083A90 File Offset: 0x00081C90
	private void paintChangTab(mGraphics g)
	{
		for (int i = 0; i < Interface_Game.mPosKillCur.Length; i++)
		{
			int num = Interface_Game.mPosKillSub[i][0] - Interface_Game.mVChangTab[i][0] * this.timeChangeTab / 100;
			int num2 = Interface_Game.mPosKillSub[i][1] - Interface_Game.mVChangTab[i][1] * this.timeChangeTab / 100;
			Hotkey hotkey = Player.hotkeyPlayer[(int)Player.currentTab][i];
			bool isTouch = GameCanvas.isTouch;
			if (isTouch)
			{
				int num3 = 0;
				bool flag = Interface_Game.timePointer > 0 && Interface_Game.keyPoint == Interface_Game.mValueHotKey[i];
				if (flag)
				{
					num3 = 1;
				}
				this.paintHotKey(g, hotkey, num, num2, 20, false);
				bool flag2 = hotkey.skill == null || hotkey.skill.lvDevil == 0;
				if (flag2)
				{
					bool flag3 = i == 2 && Interface_Game.typeTouch == 0;
					if (flag3)
					{
						g.drawRegion(Interface_Game.imgFire[1], 0, num3 * 50, 50, 50, 0, (float)num, (float)num2, 3);
					}
					else
					{
						g.drawRegion(Interface_Game.imgFire[0], 0, num3 * 50, 50, 50, 0, (float)num, (float)num2, 3);
					}
				}
			}
			else
			{
				this.paintHotKey(g, hotkey, num, num2, 20, false);
				g.drawImage(AvMain.imgHotKey, num, num2, 3);
			}
		}
		this.timeChangeTab++;
		bool flag4 = this.timeChangeTab >= this.maxTimeChange;
		if (flag4)
		{
			this.timeChangeTab = 0;
			Player.currentTab = ((Player.currentTab == 0) ? 1 : 0);
		}
	}

	// Token: 0x060005B5 RID: 1461 RVA: 0x00083C28 File Offset: 0x00081E28
	private void paintHotKey(mGraphics g, Hotkey hot, int x, int y, int w, bool isPaintGiaotiep)
	{
		if (isPaintGiaotiep)
		{
			AvMain.fraQuest.drawFrame(2, x, y - 2 + GameCanvas.gameTick / 5 % 3, 0, 3, g);
		}
		else
		{
			hot.paint(g, x, y, w);
			DelaySkill.getDelay(hot.getIndexDelay()).paint(g, x - 10, y - 10, w);
		}
	}

	// Token: 0x060005B6 RID: 1462 RVA: 0x00083C88 File Offset: 0x00081E88
	public static void paintInfoPlayer(mGraphics g, int x, int y, bool isborder, mFont fontLv)
	{
		bool isTaiTho = GameCanvas.isTaiTho;
		if (isTaiTho)
		{
			x += 5;
		}
		mImage image = (GameScreen.player.Lv != 100) ? Interface_Game.imgIconMPHP : Interface_Game.imgIconMPHP2;
		if (isborder)
		{
			bool flag = GameCanvas.currentScreen == GameCanvas.gameScr && LoadMap.specMap == 7;
			if (flag)
			{
				bool flag2 = Interface_Game.imgInfoNew == null;
				if (flag2)
				{
					Interface_Game.imgInfoNew = LoadImageStatic.LoadNewInterface("/infonew.png");
				}
				g.drawImage(Interface_Game.imgInfoNew, x, y, 0);
			}
			else
			{
				bool flag3 = !GameCanvas.lowGraphic;
				if (flag3)
				{
					g.drawImage(Interface_Game.imgInfo, x, y, 0);
					g.drawImage(Interface_Game.imgHoavan, x + 3, y + 20, 0);
					g.drawRegion(Interface_Game.imgHoavan, 0, 0, 23, 23, 3, (float)(x + 66), (float)(y + 2), 0);
				}
				else
				{
					g.setColor(16246726);
					g.fillRect(x + 2, y, 88, 45);
				}
			}
			g.drawImage(image, x + 7, y + 7, 0);
			y += 7;
		}
		else
		{
			x -= 19;
		}
		Interface_Game.PaintHPMP(g, 1, GameScreen.player.Hp, GameScreen.player.maxHp, x + 18, y, 0, 9, 66, 0, false, GameScreen.player.HpEff, Interface_Game.isEffHP, (int)GameScreen.player.lvHeart);
		y += 11;
		Interface_Game.PaintHPMP(g, 2, GameScreen.player.Mp, GameScreen.player.maxMp, x + 18, y, 0, 9, 66, 0, false, 0, Interface_Game.isEffMP, 0);
		y += 8;
		bool flag4 = GameScreen.player.Lv == 100;
		int num;
		if (flag4)
		{
			fontLv.drawString(g, string.Concat(new string[]
			{
				GameScreen.player.LvThongThao.ToString(),
				" + ",
				(GameScreen.player.percentThongThao / 10).ToString(),
				",",
				(GameScreen.player.percentThongThao % 10).ToString(),
				"%"
			}), x + 20, y, 0);
			y += 10;
			num = GameScreen.player.percentThongThao / 10 * 65 / 100;
		}
		else
		{
			fontLv.drawString(g, string.Concat(new string[]
			{
				GameScreen.player.Lv.ToString(),
				" + ",
				(GameScreen.player.percentLv / 10).ToString(),
				",",
				(GameScreen.player.percentLv % 10).ToString(),
				"%"
			}), x + 20, y, 0);
			y += 10;
			num = GameScreen.player.percentLv / 10 * 65 / 100;
		}
		bool flag5 = num > 65;
		if (flag5)
		{
			num = 65;
		}
		g.setColor(1258003);
		g.fillRect(x + 18, y, 65, 2);
		bool flag6 = num > 0;
		if (flag6)
		{
			g.setColor(3514158);
			g.fillRect(x + 18, y, num, 2);
		}
		for (int i = 1; i < 5; i++)
		{
			g.setColor(16777215);
			g.fillRect(x + 18 + i * 13, y, 1, 2);
		}
	}

	// Token: 0x060005B7 RID: 1463 RVA: 0x00083FF0 File Offset: 0x000821F0
	public static void paintInfoPlayer_Short(mGraphics g, int x, int y, bool isborder, mFont fontLv)
	{
		mImage arg = (GameScreen.player.Lv != 100) ? Interface_Game.imgIconMPHP : Interface_Game.imgIconMPHP2;
		AvMain.paintRect(g, x, y, 320, 15, 1, 4);
		g.drawRegion(arg, 0, 0, 10, 11, 0, (float)(x + 8), (float)(y + 9), 3);
		Interface_Game.PaintHPMP(g, 1, GameScreen.player.Hp, GameScreen.player.maxHp, x + 15, y + 3, 0, 9, 66, 0, false, GameScreen.player.HpEff, Interface_Game.isEffHP, (int)GameScreen.player.lvHeart);
		g.drawRegion(arg, 0, 11, 10, 11, 0, (float)(x + 17 + 70), (float)(y + 9), 3);
		Interface_Game.PaintHPMP(g, 2, GameScreen.player.Mp, GameScreen.player.maxMp, x + 15 + 10 + 70, y + 3, 0, 9, 66, 0, false, 0, Interface_Game.isEffMP, 0);
		x += 165;
		int num = y + 7;
		AvMain.fraMoney.drawFrame(0, x + Interface_Game.mini + AvMain.fraMoney.frameWidth / 2 - 3, num, 0, 3, g);
		AvMain.fraMoney.drawFrame(1, x + Interface_Game.mini + AvMain.fraMoney.frameWidth / 2 + 45, num, 0, 3, g);
		AvMain.fraMoney.drawFrame(7, x + Interface_Game.mini + AvMain.fraMoney.frameWidth / 2 + 90, num, 0, 3, g);
		bool flag = GameScreen.player != null;
		if (flag)
		{
			mFont.tahoma_7_yellow.drawString(g, " " + AvMain.getMoneyShortText(Player.beliTest), x + Interface_Game.mini + AvMain.fraMoney.frameWidth - 4, num - 5, 0);
			mFont.tahoma_7_red.drawString(g, " " + AvMain.getDotNumber((long)GameScreen.player.gem), x + Interface_Game.mini + AvMain.fraMoney.frameWidth + 45, num - 5, 0);
			mFont.tahoma_7_green.drawString(g, " " + AvMain.getMoneyShortText((long)GameScreen.player.vnd), x + Interface_Game.mini + AvMain.fraMoney.frameWidth + 91, num - 5, 0);
		}
	}

	// Token: 0x060005B8 RID: 1464 RVA: 0x00084224 File Offset: 0x00082424
	public static void paintPvPNew(mGraphics g, MainObject objLeft, MainObject objRight)
	{
		int hw = MotherCanvas.hw;
		int num = 84;
		int num2 = 30;
		bool flag = Interface_Game.mImgPvPNew == null;
		if (flag)
		{
			Interface_Game.loadImgPvPNew();
		}
		else
		{
			g.drawImage(Interface_Game.mImgPvPNew[0], hw - num, num2, 3);
			g.drawRegion(Interface_Game.mImgPvPNew[0], 0, 0, 129, 40, 2, (float)(hw + num), (float)num2, 3);
			g.drawImage(Interface_Game.mImgPvPNew[4], hw, num2 - 12, 3);
			Interface_Game.watchMap.paintCountDownTicket(g, mFont.tahoma_7_white, hw + 1, num2 - 17, 2);
			bool flag2 = objLeft != null;
			if (flag2)
			{
				Interface_Game.PaintHPMP(g, (objLeft.Lv != 100) ? 98 : 96, objLeft.Hp, objLeft.maxHp, hw - 110, num2 - 16, 0, 9, 87, 0, false, objLeft.HpEff, true, 0);
				Interface_Game.PaintHPMP(g, 97, objLeft.Mp, objLeft.maxMp, hw - 112 + 5, num2 - 2, 0, 9, 50, 4, false, 0, true, 0);
				objLeft.paintHead(g, hw - 130, num2 - 4, 2);
				bool flag3 = objLeft.Lv < 100;
				if (flag3)
				{
					AvMain.Font3dSmall(g, objLeft.Lv.ToString() + string.Empty, hw - 116, num2 + 6, 2, 0);
				}
				else
				{
					AvMain.Font3dSmall(g, objLeft.LvThongThao.ToString() + string.Empty, hw - 115, num2 + 6, 2, 5);
				}
			}
			bool flag4 = objRight != null;
			if (flag4)
			{
				Interface_Game.PaintHPMP(g, (objRight.Lv != 100) ? 98 : 96, objRight.Hp, objRight.maxHp, hw + 24, num2 - 16, 0, 9, 87, 0, true, objRight.HpEff, true, 0);
				Interface_Game.PaintHPMP(g, 97, objRight.Mp, objRight.maxMp, hw + 57, num2 - 2, 0, 9, 50, 4, true, 0, true, 0);
				objRight.paintHead(g, hw + 130, num2 - 4, 0);
				bool flag5 = objRight.Lv < 100;
				if (flag5)
				{
					AvMain.Font3dSmall(g, objRight.Lv.ToString() + string.Empty, hw + 116, num2 + 6, 2, 0);
				}
				else
				{
					AvMain.Font3dSmall(g, objRight.LvThongThao.ToString() + string.Empty, hw + 117, num2 + 6, 2, 5);
				}
			}
			bool flag6 = Interface_Game.maxWin <= 0 || objLeft == null || objRight == null;
			if (!flag6)
			{
				for (int i = 1; i <= (int)Interface_Game.maxWin; i++)
				{
					bool flag7 = objLeft.typePK == 4;
					if (flag7)
					{
						g.drawRegion(Interface_Game.mImgPvPNew[3], 0, (Interface_Game.watchMap.valueLeft >= i) ? 14 : 0, 7, 7, 0, (float)(hw - 9 - i * 8), (float)num2, 3);
						g.drawRegion(Interface_Game.mImgPvPNew[3], 0, (Interface_Game.watchMap.valueright >= i) ? 7 : 0, 7, 7, 0, (float)(hw + 9 + i * 8), (float)num2, 3);
					}
					else
					{
						g.drawRegion(Interface_Game.mImgPvPNew[3], 0, (Interface_Game.watchMap.valueLeft >= i) ? 14 : 0, 7, 7, 0, (float)(hw + 9 + i * 8), (float)num2, 3);
						g.drawRegion(Interface_Game.mImgPvPNew[3], 0, (Interface_Game.watchMap.valueright >= i) ? 7 : 0, 7, 7, 0, (float)(hw - 9 - i * 8), (float)num2, 3);
					}
				}
			}
		}
	}

	// Token: 0x060005B9 RID: 1465 RVA: 0x0008459C File Offset: 0x0008279C
	public static void loadImgPvPNew()
	{
		Interface_Game.mImgPvPNew = new mImage[5];
		for (int i = 0; i < Interface_Game.mImgPvPNew.Length; i++)
		{
			Interface_Game.mImgPvPNew[i] = mImage.createImage("/interface/pvpnew" + i.ToString() + ".png");
		}
	}

	// Token: 0x060005BA RID: 1466 RVA: 0x000845F0 File Offset: 0x000827F0
	public static void paintEffShowMoney(mGraphics g, int x, int y, bool isShow, int type)
	{
		if (type != 0)
		{
			if (type == 1)
			{
				bool flag = isShow || y + Interface_Game.yEffShowMoney + 18 > 0;
				if (flag)
				{
					int num = y + Interface_Game.yEffShowMoney;
					if (isShow)
					{
						num = y;
					}
					AvMain.paintRect(g, x, num, Interface_Game.wMoneyEff, 18, 1, 3);
					num += 9;
					AvMain.fraMoney.drawFrame(2, x + Interface_Game.mini + AvMain.fraMoney.frameWidth / 2, num, 0, 3, g);
					AvMain.fraMoney.drawFrame(3, x + Interface_Game.mini + AvMain.fraMoney.frameWidth / 2 + 45, num, 0, 3, g);
					AvMain.fraMoney.drawFrame(4, x + Interface_Game.mini + AvMain.fraMoney.frameWidth / 2 + 93, num, 0, 3, g);
					bool flag2 = GameScreen.player != null;
					if (flag2)
					{
						mFont.tahoma_7_yellow.drawString(g, " " + Player.ticket.ToString(), x + Interface_Game.mini + AvMain.fraMoney.frameWidth, num - 5, 0);
						mFont.tahoma_7_yellow.drawString(g, " " + Player.keyBoss.ToString(), x + Interface_Game.mini + AvMain.fraMoney.frameWidth + 45, num - 5, 0);
						mFont.tahoma_7_yellow.drawString(g, " " + Player.PvPticket.ToString(), x + Interface_Game.mini + AvMain.fraMoney.frameWidth + 93, num - 5, 0);
					}
				}
			}
		}
		else
		{
			bool flag3 = isShow || y + Interface_Game.yEffShowMoney + 18 > 0;
			if (flag3)
			{
				int num2 = y + Interface_Game.yEffShowMoney;
				if (isShow)
				{
					num2 = y;
				}
				AvMain.paintRect(g, x, num2, Interface_Game.wMoneyEff, 18, 1, 4);
				num2 += 9;
				AvMain.fraMoney.drawFrame(0, x + Interface_Game.mini + AvMain.fraMoney.frameWidth / 2 - 3, num2, 0, 3, g);
				AvMain.fraMoney.drawFrame(1, x + Interface_Game.mini + AvMain.fraMoney.frameWidth / 2 + 45, num2, 0, 3, g);
				AvMain.fraMoney.drawFrame(7, x + Interface_Game.mini + AvMain.fraMoney.frameWidth / 2 + 90, num2, 0, 3, g);
				bool flag4 = GameScreen.player != null;
				if (flag4)
				{
					mFont.tahoma_7_yellow.drawString(g, " " + AvMain.getMoneyShortText(Player.beliTest), x + Interface_Game.mini + AvMain.fraMoney.frameWidth - 4, num2 - 5, 0);
					mFont.tahoma_7_red.drawString(g, " " + AvMain.getDotNumber((long)GameScreen.player.gem), x + Interface_Game.mini + AvMain.fraMoney.frameWidth + 45, num2 - 5, 0);
					mFont.tahoma_7_green.drawString(g, " " + AvMain.getMoneyShortText((long)GameScreen.player.vnd), x + Interface_Game.mini + AvMain.fraMoney.frameWidth + 91, num2 - 5, 0);
				}
			}
		}
		Interface_Game.updateEffShowMoney();
	}

	// Token: 0x060005BB RID: 1467 RVA: 0x00084924 File Offset: 0x00082B24
	public static void updateEffShowMoney()
	{
		bool flag = Interface_Game.tickeffShowMoney > 0;
		if (flag)
		{
			Interface_Game.tickeffShowMoney--;
			bool flag2 = Interface_Game.yEffShowMoney < 0;
			if (flag2)
			{
				Interface_Game.yEffShowMoney += 5;
				bool flag3 = Interface_Game.yEffShowMoney > 0;
				if (flag3)
				{
					Interface_Game.yEffShowMoney = 0;
				}
			}
		}
		else
		{
			bool flag4 = Interface_Game.yEffShowMoney > -25;
			if (flag4)
			{
				Interface_Game.yEffShowMoney -= 3;
				bool flag5 = Interface_Game.yEffShowMoney < -25;
				if (flag5)
				{
					Interface_Game.yEffShowMoney = -25;
				}
			}
		}
	}

	// Token: 0x060005BC RID: 1468 RVA: 0x000849B0 File Offset: 0x00082BB0
	public void paintVecBuffCurrent(mGraphics g)
	{
		Interface_Game.isEffHP = false;
		Interface_Game.isEffMP = false;
		int num = 0;
		for (int i = 0; i < Interface_Game.vecEffCurrent.size(); i++)
		{
			bool flag = i >= 10;
			if (!flag)
			{
				MainItem mainItem = (MainItem)Interface_Game.vecEffCurrent.elementAt(i);
				bool flag2 = mainItem == null || DelaySkill.getDelay((int)mainItem.indexHotKey).value <= 0;
				if (!flag2)
				{
					bool flag3 = mainItem.typeObject == 4;
					if (flag3)
					{
						bool flag4 = mainItem.Hp_Mp_Other == 1;
						if (flag4)
						{
							Interface_Game.isEffHP = true;
						}
						bool flag5 = mainItem.Hp_Mp_Other == 2;
						if (flag5)
						{
							Interface_Game.isEffMP = true;
						}
						mainItem.paintHotkey(g, Interface_Game.mPosEffCurrent[num][0], Interface_Game.mPosEffCurrent[num][1] - 4, 20, -4);
						DelaySkill.getDelay((int)mainItem.indexHotKey).paint(g, Interface_Game.mPosEffCurrent[num][0] - 10, Interface_Game.mPosEffCurrent[num][1] - 10 - 4, 20);
					}
					else
					{
						bool flag6 = mainItem.typeObject == 9;
						if (flag6)
						{
							mainItem.paintHotkey(g, Interface_Game.mPosEffCurrent[num][0], Interface_Game.mPosEffCurrent[num][1] - 4, 20, 0);
							g.drawImage(AvMain.imgBgnum, Interface_Game.mPosEffCurrent[num][0], Interface_Game.mPosEffCurrent[num][1] + 10, 3);
							DelaySkill.getDelay((int)mainItem.indexHotKey).paintOnlytime(g, Interface_Game.mPosEffCurrent[num][0] - 11, Interface_Game.mPosEffCurrent[num][1] - 1, 22, mainItem.colorName);
						}
					}
					num++;
				}
			}
		}
	}

	// Token: 0x060005BD RID: 1469 RVA: 0x00084B58 File Offset: 0x00082D58
	public static void paintIconFocus(mGraphics g)
	{
		bool flag = GameScreen.objFocus == null || GameScreen.objFocus.typeObject == 0 || GameScreen.objFocus.typeObject == 1 || GameScreen.objFocus.returnAction() || GameScreen.objFocus.isTanHinh;
		if (!flag)
		{
			MainObject objFocus = GameScreen.objFocus;
			bool flag2 = AvMain.fraIconfocus.nFrame == 1;
			if (flag2)
			{
				g.drawImage(AvMain.fraIconfocus.imgFrame, objFocus.x, objFocus.y - objFocus.hOne - objFocus.dy - objFocus.hIconFocus - GameCanvas.gameTick % 5, 3);
			}
			else
			{
				bool flag3 = Interface_Game.isNextFrame;
				if (flag3)
				{
					bool flag4 = GameCanvas.gameTick % 3 == 0;
					if (flag4)
					{
						Interface_Game.frameIconfocus++;
					}
					bool flag5 = Interface_Game.frameIconfocus >= AvMain.fraIconfocus.nFrame - 1;
					if (flag5)
					{
						Interface_Game.isNextFrame = false;
					}
				}
				else
				{
					bool flag6 = GameCanvas.gameTick % 3 == 0;
					if (flag6)
					{
						Interface_Game.frameIconfocus--;
					}
					bool flag7 = Interface_Game.frameIconfocus <= 0;
					if (flag7)
					{
						Interface_Game.isNextFrame = true;
					}
				}
				AvMain.fraIconfocus.drawFrame(Interface_Game.frameIconfocus, objFocus.x, objFocus.y - objFocus.hOne - objFocus.dy - objFocus.hIconFocus - 3, 0, 3, g);
			}
		}
	}

	// Token: 0x060005BE RID: 1470 RVA: 0x00084CC0 File Offset: 0x00082EC0
	public void paintInfoFocus(mGraphics g)
	{
		bool flag = GameScreen.objFocus != null && !GameScreen.objFocus.returnAction() && (GameScreen.objFocus.name.Length > 0 || GameScreen.objFocus.isNPC_Area() == 99);
		if (flag)
		{
			int num = Interface_Game.xFocus - 2;
			bool isTaiTho = GameCanvas.isTaiTho;
			if (isTaiTho)
			{
				num -= 5;
			}
			int yp = 4 + GameScreen.h12plus;
			GameScreen.objFocus.paintInfoFocus(g, num, yp);
		}
	}

	// Token: 0x060005BF RID: 1471 RVA: 0x00084D3C File Offset: 0x00082F3C
	public static void PaintHPMP(mGraphics g, sbyte type, int cur, int max, int x, int y, int plusHFont, int hrect, int wRect, int isNum, bool isflip, int hpEff, bool isUpdateEff, int LvHeart)
	{
		int num = cur;
		bool flag = isNum == 1;
		if (flag)
		{
			num = cur / 10;
		}
		int color = 13631520;
		int color2 = 5451296;
		bool flag2 = type < 0;
		if (flag2)
		{
			bool flag3 = CRes.abs((int)type) == 2;
			if (flag3)
			{
				color = 2264788;
				color2 = 4806486;
			}
		}
		else
		{
			bool flag4 = type == 2;
			if (flag4)
			{
				color = 2264788;
				color2 = 4806486;
			}
			else
			{
				bool flag5 = type == 3;
				if (flag5)
				{
					color = 3787037;
					color2 = 930311;
				}
				else
				{
					bool flag6 = type == 99;
					if (flag6)
					{
						color2 = 13631520;
						color = 2132744;
					}
					else
					{
						bool flag7 = type == 100;
						if (flag7)
						{
							color2 = 2132744;
							color = 2953937;
						}
						else
						{
							bool flag8 = type == 101;
							if (flag8)
							{
								color2 = 2953937;
								color = 1557973;
							}
							else
							{
								bool flag9 = type == 102 || type == 104 || type == 106;
								if (flag9)
								{
									int num2 = LvHeart / 10;
									bool flag10 = num2 < 0 && num2 >= Interface_Game.colorHPHeart.Length;
									if (flag10)
									{
										num2 = 0;
									}
									color = ((cur >= max / 10 || GameCanvas.gameTick % 5 >= 2) ? Interface_Game.colorHPHeart[num2][0] : Interface_Game.colorHPHeart[num2][2]);
									color2 = Interface_Game.colorHPHeart[num2][1];
								}
								else
								{
									bool flag11 = type == 103;
									if (flag11)
									{
										color = 6215679;
										color2 = 2928878;
										g.setColor(21978);
										g.fillRect(x - 1, y - 1, wRect + 2, hrect + 2);
									}
									else
									{
										bool flag12 = type == 98 || type == 97 || type == 96;
										if (flag12)
										{
											color = 6215679;
											color2 = 2928878;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		bool flag13 = type != 98 && type != 97 && type != 96;
		if (flag13)
		{
			g.setColor(color2);
			g.fillRect(x, y, wRect, hrect);
		}
		bool flag14 = max > 0 && num > 0;
		if (flag14)
		{
			int num3 = (max <= 1000000) ? (num * wRect / max) : (num / 1000 * wRect / (max / 1000));
			bool flag15 = num3 <= 0;
			if (flag15)
			{
				num3 = 1;
			}
			else
			{
				bool flag16 = num3 > wRect;
				if (flag16)
				{
					num3 = wRect;
				}
			}
			bool flag17 = hpEff > 0;
			if (flag17)
			{
				int num4 = (max <= 1000000) ? (hpEff * wRect / max) : (hpEff / 1000 * wRect / (max / 1000));
				bool flag18 = num4 <= 0;
				if (flag18)
				{
					num4 = 1;
				}
				else
				{
					bool flag19 = num4 > wRect;
					if (flag19)
					{
						num4 = wRect;
					}
				}
				bool flag20 = type == 98 || type == 97 || type == 96;
				if (flag20)
				{
					bool flag21 = (type == 98 || type == 96) && num4 > 0;
					if (flag21)
					{
						bool flag22 = !isflip;
						if (flag22)
						{
							g.drawRegion(Interface_Game.mImgPvPNew[1], 0, hrect + hrect, num4, hrect, 0, (float)x, (float)y, 0);
						}
						else
						{
							g.drawRegion(Interface_Game.mImgPvPNew[1], 0, hrect + hrect, num4, hrect, 2, (float)(x + (wRect - num4)), (float)y, 0);
						}
					}
				}
				else
				{
					g.setColor(0);
					bool flag23 = !isflip;
					if (flag23)
					{
						g.fillRect(x, y, num4, hrect);
					}
					else
					{
						g.fillRect(x + wRect - num4, y, num4, hrect);
					}
				}
			}
			g.setColor(color);
			bool flag24 = type == 98 || type == 97 || type == 96;
			if (flag24)
			{
				int y2 = 0;
				int num5 = 1;
				bool flag25 = type == 96;
				if (flag25)
				{
					y2 = hrect;
				}
				bool flag26 = type == 97;
				if (flag26)
				{
					num5 = 2;
				}
				bool flag27 = num3 > 0;
				if (flag27)
				{
					bool flag28 = !isflip;
					if (flag28)
					{
						g.drawRegion(Interface_Game.mImgPvPNew[num5], 0, y2, num3, hrect, 0, (float)x, (float)y, 0);
					}
					else
					{
						g.drawRegion(Interface_Game.mImgPvPNew[num5], 0, y2, num3, hrect, 2, (float)(x + (wRect - num3)), (float)y, 0);
					}
				}
			}
			else
			{
				bool flag29 = type < 0;
				if (flag29)
				{
					g.fillRect(x, y, num3, hrect);
				}
				else
				{
					bool flag30 = !isflip;
					if (flag30)
					{
						g.fillRect(x, y, num3, hrect);
					}
					else
					{
						g.fillRect(x + wRect - num3, y, num3, hrect);
					}
					bool flag31 = type == 106;
					if (flag31)
					{
						g.setColor(16120660);
						bool flag32 = !isflip;
						if (flag32)
						{
							g.fillRect(x, y, num3, 1);
						}
						else
						{
							g.fillRect(x + wRect - num3, y, num3, 1);
						}
					}
				}
				bool flag33 = isUpdateEff && num > Interface_Game.mcolorEffHp.Length * 2;
				if (flag33)
				{
					bool flag34 = type == 1;
					if (flag34)
					{
						bool flag35 = Interface_Game.vEffHP + Interface_Game.mcolorEffHp.Length * 2 - 1 <= num3;
						if (flag35)
						{
							for (int i = 0; i < Interface_Game.mcolorEffHp.Length; i++)
							{
								g.setColor(Interface_Game.mcolorEffHp[i]);
								int w = 2;
								bool flag36 = i == Interface_Game.mcolorEffHp.Length - 1;
								if (flag36)
								{
									w = 1;
								}
								g.fillRect(x + i * 2 + Interface_Game.vEffHP, y, w, hrect);
							}
						}
						Interface_Game.vEffHP += 2;
						bool flag37 = Interface_Game.vEffHP + Interface_Game.mcolorEffHp.Length * 2 > wRect;
						if (flag37)
						{
							Interface_Game.vEffHP = 0;
						}
					}
					else
					{
						bool flag38 = Interface_Game.vEffMP + Interface_Game.mcolorEffMp.Length * 2 - 1 <= num3;
						if (flag38)
						{
							for (int j = 0; j < Interface_Game.mcolorEffMp.Length; j++)
							{
								g.setColor(Interface_Game.mcolorEffMp[j]);
								int w2 = 2;
								bool flag39 = j == Interface_Game.mcolorEffMp.Length - 1;
								if (flag39)
								{
									w2 = 1;
								}
								g.fillRect(x + j * 2 + Interface_Game.vEffMP, y, w2, hrect);
							}
						}
						Interface_Game.vEffMP += 2;
						bool flag40 = Interface_Game.vEffMP + Interface_Game.mcolorEffMp.Length * 2 > wRect;
						if (flag40)
						{
							Interface_Game.vEffMP = 0;
						}
					}
				}
			}
		}
		string str = string.Empty + max.ToString();
		string str2 = string.Empty + cur.ToString();
		bool flag41 = max >= 1000000000;
		if (flag41)
		{
			str = (max / 1000000000).ToString() + "," + (max % 1000000000 / 100000000).ToString() + "B";
		}
		else
		{
			bool flag42 = max > 1000000;
			if (flag42)
			{
				str = (max / 1000000).ToString() + "," + (max % 1000000 / 100000).ToString() + "M";
			}
			else
			{
				bool flag43 = max >= 100000;
				if (flag43)
				{
					str = (max / 1000).ToString() + "k";
				}
			}
		}
		bool flag44 = cur >= 100000;
		if (flag44)
		{
			str2 = (cur / 1000).ToString() + "k";
		}
		switch (isNum)
		{
		case 0:
			mFont.tahoma_7_white.drawString(g, str2 + "/" + str, x + wRect / 2, y - 1 + plusHFont + (hrect - 9) / 2, 2);
			break;
		case 1:
			mFont.tahoma_7_white.drawString(g, MainItem.strGetPercent(cur, 1), x + wRect / 2, y - 1 + plusHFont + (hrect - 9) / 2, 2);
			break;
		case 2:
		{
			bool flag45 = type == 104;
			if (flag45)
			{
				int num6 = mFont.tahoma_7_black.getWidth(str2 + "/" + str) + 4;
				g.setColor(0);
				g.fillRect(x + wRect / 2 - 10 - num6 / 2, y - 1 + plusHFont + (hrect - 9) / 2, num6, 11);
			}
			AvMain.Font3dSmall(g, str2 + "/" + str, x + wRect / 2 - 10, y - 1 + plusHFont + (hrect - 9) / 2, 2, 0);
			break;
		}
		case 3:
			AvMain.Font3dSmall(g, str2 + "/" + str, x + wRect / 2, y - 1 + plusHFont + (hrect - 9) / 2, 2, 0);
			break;
		case 4:
			mFont.tahoma_7_white.drawString(g, str2 + string.Empty, x + wRect / 2, y - 1 + plusHFont + (hrect - 9) / 2, 2);
			break;
		}
	}

	// Token: 0x060005C0 RID: 1472 RVA: 0x00085630 File Offset: 0x00083830
	public static string ConvertNumToStr(int num)
	{
		string result = string.Empty + num.ToString();
		bool flag = num >= 1000000000;
		if (flag)
		{
			result = (num / 1000000000).ToString() + "," + (num % 1000000000 / 100000000).ToString() + "B";
		}
		else
		{
			bool flag2 = num >= 1000000;
			if (flag2)
			{
				result = string.Concat(new string[]
				{
					(num / 1000000).ToString(),
					",",
					(num % 1000000 / 100000).ToString(),
					(num % 100000 / 10000).ToString(),
					"M"
				});
			}
			else
			{
				bool flag3 = num >= 1000;
				if (flag3)
				{
					result = (num / 1000).ToString() + "k";
				}
			}
		}
		return result;
	}

	// Token: 0x060005C1 RID: 1473 RVA: 0x00085740 File Offset: 0x00083940
	public static string ConvertTimeToStr(int time)
	{
		bool flag = time < 0;
		string result;
		if (flag)
		{
			result = "00:00:00";
		}
		else
		{
			string str = string.Empty;
			str = ((time / 60 / 60 >= 10) ? (str + (time / 60 / 60).ToString()) : (str + "0" + (time / 60 / 60).ToString()));
			str += ":";
			str = ((time / 60 % 60 >= 10) ? (str + (time / 60 % 60).ToString()) : (str + "0" + (time / 60 % 60).ToString()));
			str += ":";
			bool flag2 = time % 60 < 10;
			if (flag2)
			{
				result = str + "0" + (time % 60).ToString();
			}
			else
			{
				result = str + (time % 60).ToString();
			}
		}
		return result;
	}

	// Token: 0x060005C2 RID: 1474 RVA: 0x0008583C File Offset: 0x00083A3C
	public static void paintHP_Thong_Thao(mGraphics g, int x, int y, int maxpaint, int hpEff, int max, bool isFocus)
	{
		int color = 11572345;
		int num = 0;
		if (isFocus)
		{
			color = 16775897;
			num = 2;
		}
		bool flag = AvMain.fraNenThongThao == null;
		if (flag)
		{
			AvMain.fraNenThongThao = LoadImageStatic.loadFraImage("/interface/thong_thao_2.png", 10, 12);
		}
		g.setColor(color);
		g.fillRect(x - 1, y, maxpaint + 2, 12);
		for (int i = 0; i <= (maxpaint - 1) / 10; i++)
		{
			bool flag2 = i < (maxpaint - 1) / 10;
			if (flag2)
			{
				AvMain.fraNenThongThao.drawFrame(num, x + i * 10, y, 0, 0, g);
			}
			else
			{
				g.drawRegion(AvMain.fraNenThongThao.imgFrame, 0, num * 12, (maxpaint - 1) % 10 + 1, 12, 0, (float)(x + i * 10), (float)y, 0);
			}
		}
		int num2 = hpEff * maxpaint / max;
		bool flag3 = num2 < 0;
		if (flag3)
		{
			num2 = 0;
		}
		else
		{
			bool flag4 = num2 > maxpaint;
			if (flag4)
			{
				num2 = maxpaint;
			}
		}
		bool flag5 = num2 > 0;
		if (flag5)
		{
			for (int j = 0; j <= (num2 - 1) / 10; j++)
			{
				bool flag6 = j < (num2 - 1) / 10;
				if (flag6)
				{
					AvMain.fraNenThongThao.drawFrame(1 + num, x + j * 10, y, 0, 0, g);
				}
				else
				{
					g.drawRegion(AvMain.fraNenThongThao.imgFrame, 0, 12 + num * 12, (num2 - 1) % 10 + 1, 12, 0, (float)(x + j * 10), (float)y, 0);
				}
			}
		}
		mFont.tahoma_7_white.drawString(g, hpEff.ToString() + "/" + max.ToString(), x + maxpaint / 2, y, 2);
	}

	// Token: 0x060005C3 RID: 1475 RVA: 0x000859F8 File Offset: 0x00083BF8
	public static void PaintLoadData(mGraphics g, int curupdate, int maxupdate, int xp, int yp, int wUpdate, int hUpdate, int hNum)
	{
		g.setColor(5002069);
		g.fillRect(xp - 5, yp + 1 + 15, wUpdate + 4, hUpdate - 2);
		g.fillRect(xp - 2, yp - 2 + 15, wUpdate - 2, hUpdate + 4);
		g.setColor(2698542);
		g.fillRect(xp - 4, yp + 15, wUpdate + 2, hUpdate);
		g.fillRect(xp - 4 + 1, yp + 14, wUpdate, 1);
		g.fillRect(xp - 4 + 1, yp + 15 + hUpdate, wUpdate, 1);
		g.setColor(3027507);
		g.fillRect(xp - 4 + 1, yp + 15, wUpdate, hUpdate);
		bool flag = maxupdate > 0 && curupdate > 0;
		if (flag)
		{
			int num = curupdate * wUpdate / maxupdate;
			bool flag2 = num <= 0;
			if (flag2)
			{
				num = 1;
			}
			else
			{
				bool flag3 = num > wUpdate;
				if (flag3)
				{
					num = wUpdate;
				}
			}
			g.setColor(10339648);
			g.fillRect(xp - 4 + 1, yp + 15, num, hUpdate);
		}
		g.setColor(2698542);
		g.fillRect(xp - 3, yp + hUpdate + 3, 1, 1);
		g.fillRect(xp - 3, yp + 14 + hUpdate, 1, 1);
		g.fillRect(xp + wUpdate - 4, yp + hUpdate + 3, 1, 1);
		g.fillRect(xp + wUpdate - 4, yp + 14 + hUpdate, 1, 1);
		mFont.tahoma_7b_white.drawString(g, curupdate.ToString() + "/" + maxupdate.ToString(), xp + wUpdate / 2 - 3, yp + hNum, 2);
	}

	// Token: 0x060005C4 RID: 1476 RVA: 0x00085B9C File Offset: 0x00083D9C
	public void updateInGame()
	{
		bool flag = Interface_Game.timePointer > 0;
		if (flag)
		{
			Interface_Game.timePointer--;
		}
		this.updateTouchVecNear();
		bool flag2 = LoadMap.specMap != 3;
		if (flag2)
		{
			this.TouchMoveIngame();
		}
	}

	// Token: 0x060005C5 RID: 1477 RVA: 0x0000A4A4 File Offset: 0x000086A4
	public void updateViewKhanGia()
	{
		this.updateMoveCamera();
	}

	// Token: 0x060005C6 RID: 1478 RVA: 0x00085BE4 File Offset: 0x00083DE4
	public void updateTouchVecNear()
	{
		bool flag = Interface_Game.timeShowNear <= 0 || !GameCanvas.isPointerSelect;
		if (!flag)
		{
			int num = 60;
			int num2 = GameCanvas.hText + 8;
			for (int i = 0; i < Interface_Game.vecfocus.size(); i++)
			{
				bool flag2 = GameCanvas.isPoint(MotherCanvas.w - 70, num + num2 * i, 70, num2);
				if (flag2)
				{
					GameCanvas.isPointerSelect = false;
					MainObject mainObject = (MainObject)Interface_Game.vecfocus.elementAt(i);
					bool flag3 = mainObject != null && !mainObject.returnAction();
					if (flag3)
					{
						GameScreen.objFocus = mainObject;
						GameScreen.objFocus.Giaotiep();
						Interface_Game.isPaintInfoFocus = true;
						Interface_Game.timeShowNear = 0;
					}
					break;
				}
			}
		}
	}

	// Token: 0x060005C7 RID: 1479 RVA: 0x00085CA8 File Offset: 0x00083EA8
	public void TouchMoveIngame()
	{
		Interface_Game.isMove = true;
		this.updateShowTime();
		for (int i = 0; i < Interface_Game.mPosOther.Length; i++)
		{
			bool flag = (i != 2 || !GameCanvas.loadmap.mapLang() || Interface_Game.timePaintIconSkill > 0) && (i != 5 || GameScreen.player.clan != null) && GameCanvas.isPoint(Interface_Game.mPosOther[i][0] - 2, Interface_Game.mPosOther[i][1] - 2, Interface_Game.mSizeImgOther[i][0] + 4, Interface_Game.mSizeImgOther[i][1] + 4);
			if (flag)
			{
				bool isPointerSelect = GameCanvas.isPointerSelect;
				if (isPointerSelect)
				{
					GameCanvas.isPointerSelect = false;
					this.selectPointer(i);
					Interface_Game.isMove = false;
					break;
				}
				bool flag2 = GameCanvas.isPointerDown || GameCanvas.isPointerMove;
				if (flag2)
				{
					Interface_Game.keyPoint = 100 + i;
					Interface_Game.timePointer = 3;
					break;
				}
			}
		}
		bool flag3 = GameCanvas.isPoint(Interface_Game.xNumMess, Interface_Game.yNumMess - 3, 22, 22);
		if (flag3)
		{
			bool isPointerSelect2 = GameCanvas.isPointerSelect;
			if (isPointerSelect2)
			{
				GameCanvas.isPointerSelect = false;
				this.selectPointer(7);
				Interface_Game.isMove = false;
			}
			else
			{
				bool flag4 = GameCanvas.isPointerDown || GameCanvas.isPointerMove;
				if (flag4)
				{
					Interface_Game.keyPoint = 106;
					Interface_Game.timePointer = 3;
				}
			}
		}
		bool flag5 = GameCanvas.isPoint(Interface_Game.xAutoFire, Interface_Game.yAutoFire - 3, 22, 22) && GameCanvas.isPointerSelect;
		if (flag5)
		{
			GameCanvas.isPointerSelect = false;
			this.selectPointer(6);
			Interface_Game.isMove = false;
		}
		bool flag6 = GameCanvas.isPointSelect(MotherCanvas.w - 74, 0, 74, 40) && GameScreen.objFocus != null && (GameScreen.objFocus.typeObject == 0 || GameScreen.objFocus.typeObject == 2);
		if (flag6)
		{
			GameCanvas.isPointerSelect = false;
			GameScreen.objFocus.Giaotiep();
		}
		bool flag7 = !Interface_Game.isMove;
		if (!flag7)
		{
			bool flag8 = this.timeChangeTab == 0;
			if (flag8)
			{
				for (int j = 0; j < Interface_Game.mPosKillCur.Length; j++)
				{
					bool flag9 = !GameCanvas.isPoint(Interface_Game.mPosKillCur[j][0] - Interface_Game.wSkill / 2, Interface_Game.mPosKillCur[j][1] - Interface_Game.wSkill / 2, Interface_Game.wSkill, Interface_Game.wSkill);
					if (!flag9)
					{
						bool isPointerSelect3 = GameCanvas.isPointerSelect;
						if (isPointerSelect3)
						{
							bool flag10 = GameScreen.objFocus == null;
							if (flag10)
							{
								Hotkey hotkey = Player.hotkeyPlayer[(int)Player.currentTab][j];
								bool flag11 = hotkey.skill != null && !hotkey.skill.isBuff;
								if (flag11)
								{
									GameScreen.player.setFocus(true);
								}
							}
							Player.IndexFire = j;
							GameScreen.player.setActionHotKey(j);
							break;
						}
						bool flag12 = GameCanvas.isPointerDown || GameCanvas.isPointerMove;
						if (flag12)
						{
							Interface_Game.keyPoint = Interface_Game.mValueHotKey[j];
							Interface_Game.timePointer = 3;
						}
					}
				}
				bool flag13 = !GameCanvas.loadmap.mapLang() && GameCanvas.isTouch && GameScreen.isShowSkillBuff;
				if (flag13)
				{
					for (int k = 0; k < Interface_Game.mPosKillBuff.Length; k++)
					{
						bool flag14 = GameCanvas.isPoint(Interface_Game.mPosKillBuff[k][0] - Interface_Game.wSkill / 2, Interface_Game.mPosKillBuff[k][1] - Interface_Game.wSkill / 2, Interface_Game.wSkill, Interface_Game.wSkill) && GameCanvas.isPointerSelect;
						if (flag14)
						{
							GameScreen.player.setActionHotKeyBuff(k);
							Interface_Game.keyPoint = 200 + k;
							Interface_Game.timePointer = 3;
							break;
						}
					}
				}
			}
			this.checkChangeMapPoint();
			bool flag15 = Interface_Game.typeTouch == 1;
			if (flag15)
			{
				this.moveTypeTouch();
			}
			else
			{
				bool flag16 = Interface_Game.typeTouch == 0;
				if (flag16)
				{
					this.moveTypeKeypad();
				}
			}
		}
	}

	// Token: 0x060005C8 RID: 1480 RVA: 0x00086088 File Offset: 0x00084288
	private void checkChangeMapPoint()
	{
		bool flag = this.tickCheckPoint > 0;
		if (flag)
		{
			this.tickCheckPoint--;
		}
		else
		{
			int x = GameCanvas.px + MainScreen.cameraMain.xCam;
			int y = GameCanvas.py + MainScreen.cameraMain.yCam;
			for (int i = 0; i < LoadMap.vecPointChange.size(); i++)
			{
				Point point = (Point)LoadMap.vecPointChange.elementAt(i);
				bool flag2 = MainObject.getDistance(point.x, point.y, x, y) < 28 && CRes.abs(GameScreen.player.x - point.x) < 48 && CRes.abs(GameScreen.player.y - point.y) < 72 && GameScreen.player.Hp > 0 && GameScreen.player.typeActionBoat == 0 && GameScreen.player.Action == 0;
				if (flag2)
				{
					this.tickCheckPoint = 20;
					GlobalService.gI().Obj_Move((short)point.x, (short)point.y);
				}
			}
		}
	}

	// Token: 0x060005C9 RID: 1481 RVA: 0x000861B4 File Offset: 0x000843B4
	public void moveTypeTouch()
	{
		bool isGhost = Player.isGhost;
		if (!isGhost)
		{
			int num = GameCanvas.px + MainScreen.cameraMain.xCam;
			int num2 = GameCanvas.py + MainScreen.cameraMain.yCam;
			MainObject mainObject = null;
			bool flag = GameCanvas.isPointerSelect && this.timeMove == 0;
			if (flag)
			{
				this.isFire = false;
				bool flag2 = MainObject.getDistance(num, num2, GameScreen.player.x, GameScreen.player.y) <= Player.wFocus - 15 || GameScreen.player.Action == 4;
				if (flag2)
				{
					mainObject = this.setObjectNear(num, num2);
				}
				bool flag3 = mainObject != null && mainObject.typeObject != 1;
				if (flag3)
				{
					Player.setStart_EndAutoFire(false);
				}
				bool flag4 = mainObject != null;
				if (flag4)
				{
					GameScreen.objFocus = mainObject;
					bool flag5 = MainObject.getDistance(mainObject.x, mainObject.y, GameScreen.player.x, GameScreen.player.y) <= Player.wFocus && GameScreen.player.Action != 4;
					if (flag5)
					{
						GameCanvas.isPointerSelect = false;
						GameScreen.objFocus.setTouchPoint();
						Interface_Game.isPaintInfoFocus = true;
						bool flag6 = GameScreen.player.setFightPk(GameScreen.objFocus);
						if (flag6)
						{
							int num3 = 0;
							GameScreen.addEffectEnd_ObjTo(24, (int)((sbyte)num3), GameScreen.objFocus.x, GameScreen.objFocus.y, GameScreen.objFocus.ID, GameScreen.objFocus.typeObject, 0, null);
							this.isFire = true;
						}
						this.posTam = null;
					}
				}
				int tile = GameCanvas.loadmap.getTile(num, num2);
				bool flag7 = tile == -1 || tile == 1;
				if (flag7)
				{
					int num4 = num - 24;
					int num5 = num2 + 24;
					bool flag8 = num2 + MainScreen.cameraMain.yCam > GameCanvas.loadmap.maxHMap - 140;
					if (flag8)
					{
						num5 = num2 - 24;
					}
					for (int i = 0; i < 3; i++)
					{
						int tile2 = GameCanvas.loadmap.getTile(num4 + i * 24, num5);
						bool flag9 = tile2 != -1 && tile2 != 1;
						if (flag9)
						{
							num = num4 + i * 24;
							num2 = num5;
							tile = GameCanvas.loadmap.getTile(num, num2);
							break;
						}
					}
				}
				bool flag10 = tile != -1 && tile != 1 && GameScreen.player.Action != 4;
				if (flag10)
				{
					bool flag11 = num > GameScreen.player.x;
					if (flag11)
					{
						this.dirTam = 2;
					}
					else
					{
						this.dirTam = 0;
					}
					this.posTam = GameCanvas.loadmap.updateFindRoad(num / LoadMap.wTile, num2 / LoadMap.wTile, GameScreen.player.x / LoadMap.wTile, GameScreen.player.y / LoadMap.wTile, 100, GameScreen.player);
					this.xmovetam = num;
					this.ymovetam = num2;
					bool flag12 = this.posTam != null && this.posTam.Length > 100;
					if (flag12)
					{
						this.posTam = null;
					}
					this.timeMove = 2;
				}
				else
				{
					this.posTam = null;
					bool flag13 = Interface_Game.vecfocus.size() > 0;
					if (flag13)
					{
						GameCanvas.isPointerSelect = false;
					}
				}
			}
			bool flag14 = this.timeMove > 0;
			if (flag14)
			{
				bool flag15 = this.timeMove == 1 && this.posTam != null && GameScreen.player.Action != 4 && GameScreen.player.Action != 2;
				if (flag15)
				{
					GameScreen.player.xStopMove = 0;
					GameScreen.player.yStopMove = 0;
					GameScreen.player.toX = GameScreen.player.x;
					GameScreen.player.toY = GameScreen.player.y;
					bool flag16 = GameScreen.player.posTransRoad != null;
					if (flag16)
					{
						GameScreen.player.countAutoMove = 2;
					}
					GameScreen.player.posTransRoad = this.posTam;
					GameScreen.player.Dir = this.dirTam;
					Interface_Game.setMoveTo(this.xmovetam, this.ymovetam);
					this.posTam = null;
					bool flag17 = !this.isFire;
					if (flag17)
					{
						Player.setStart_EndAutoFire(false);
						bool flag18 = Interface_Game.isPaintInfoFocus;
						if (flag18)
						{
							Interface_Game.isPaintInfoFocus = false;
						}
						bool flag19 = GameScreen.player.skillCurrent != null;
						if (flag19)
						{
							GameScreen.player.skillCurrent = null;
						}
					}
					GameCanvas.isPointerSelect = false;
				}
				this.timeMove--;
			}
			this.updateMoveCamera();
		}
	}

	// Token: 0x060005CA RID: 1482 RVA: 0x00086658 File Offset: 0x00084858
	public void updateMoveCamera()
	{
		bool flag = GameCanvas.currentScreen != GameCanvas.gameScr;
		if (!flag)
		{
			bool isPointerMove = GameCanvas.isPointerMove;
			if (isPointerMove)
			{
				bool flag2 = !GameScreen.isMoveCamera && (CRes.abs(GameCanvas.px - GameCanvas.pxLast) > 48 || CRes.abs(GameCanvas.py - GameCanvas.pyLast) > 48);
				if (flag2)
				{
					GameScreen.isMoveCamera = true;
				}
				GameScreen.xMoveCam = GameCanvas.px - GameCanvas.pxLast;
				GameScreen.yMoveCam = GameCanvas.py - GameCanvas.pyLast;
				GameScreen.timeResetCam = 40;
			}
			else
			{
				bool isPointerDown = GameCanvas.isPointerDown;
				if (isPointerDown)
				{
					GameScreen.xCur = MainScreen.cameraMain.xCam;
					GameScreen.yCur = MainScreen.cameraMain.yCam;
					GameScreen.xMoveCam = 0;
					GameScreen.yMoveCam = 0;
				}
			}
		}
	}

	// Token: 0x060005CB RID: 1483 RVA: 0x0008672C File Offset: 0x0008492C
	public void moveTypeKeypad()
	{
		bool flag = (GameCanvas.isPointerDown || GameCanvas.isPointerMove) && GameCanvas.isPointLast(Interface_Game.xPointMove - 2 * Interface_Game.wArrowMove, Interface_Game.yPointMove - 2 * Interface_Game.wArrowMove, Interface_Game.wArrowMove * 4, Interface_Game.wArrowMove * 4);
		if (flag)
		{
			int num = CRes.angle(GameCanvas.px - Interface_Game.xPointMove, GameCanvas.py - Interface_Game.yPointMove);
			int num2 = (num > 45 && num <= 135) ? 3 : ((num <= 135 || num > 225) ? ((num <= 225 || num > 315) ? 1 : 2) : 0);
			GameCanvas.clearKeyHold();
			GameCanvas.isPointerDown = true;
			GameCanvas.isPointerSelect = false;
			Interface_Game.keyPoint = this.mKeyMove[num2];
			GameCanvas.keyMyHold[Interface_Game.keyPoint] = true;
			Interface_Game.timePointer = 3;
			Player.setStart_EndAutoFire(false);
			bool flag2 = GameScreen.player.skillCurrent != null;
			if (flag2)
			{
				GameScreen.player.skillCurrent = null;
			}
		}
		bool flag3 = GameCanvas.isPointerSelect && !GameCanvas.isPointer(Interface_Game.xPointMove - 50, Interface_Game.yPointMove - 50, 100, 100);
		if (flag3)
		{
			int x = GameCanvas.px + MainScreen.cameraMain.xCam;
			int y = GameCanvas.py + MainScreen.cameraMain.yCam;
			MainObject mainObject = this.setObjectNear(x, y);
			bool flag4 = mainObject != null;
			if (flag4)
			{
				GameScreen.objFocus = mainObject;
				GameScreen.objFocus.setTouchPoint();
			}
		}
	}

	// Token: 0x060005CC RID: 1484 RVA: 0x000868AC File Offset: 0x00084AAC
	public void selectPointer(int select)
	{
		switch (select)
		{
		case 0:
			GameCanvas.gameScr.cmdInfoMe.perform();
			break;
		case 1:
			GameCanvas.gameScr.cmdChatPopup.perform();
			break;
		case 2:
		{
			bool flag = this.timeChangeTab > 0 || Player.isGhost || GameScreen.player.Action == 4;
			if (!flag)
			{
				this.timeChangeTab = 1;
				bool flag2 = !GameCanvas.isTouch || Interface_Game.typeTouch == 1;
				if (flag2)
				{
					for (int i = 0; i < Interface_Game.mVChangTab.Length; i++)
					{
						Interface_Game.mVChangTab[i][0] = 0;
						Interface_Game.mVChangTab[i][1] = (MotherCanvas.h - Interface_Game.mPosKillCur[i][1]) * 200 / this.maxTimeChange;
					}
				}
				else
				{
					for (int j = 0; j < Interface_Game.mVChangTab.Length; j++)
					{
						Interface_Game.mVChangTab[j][0] = (MotherCanvas.w - Interface_Game.mPosKillCur[j][0]) * 200 / this.maxTimeChange;
						Interface_Game.mVChangTab[j][1] = 0;
					}
				}
				GameCanvas.clearAll();
			}
			break;
		}
		case 3:
			GameCanvas.gameScr.cmdNextFocus.perform();
			break;
		case 4:
			Interface_Game.startQuickMenu();
			break;
		case 5:
			GameCanvas.gameScr.cmdClan.perform();
			break;
		case 6:
		{
			bool flag3 = !Interface_Game.isAutoFireInterface && Player.typeAutoFireMain == -1;
			if (flag3)
			{
				Interface_Game.addInfoPlayerNormal(T.caidatauto, mFont.tahoma_7_yellow);
			}
			else
			{
				Interface_Game.isAutoFireInterface = !Interface_Game.isAutoFireInterface;
			}
			break;
		}
		case 7:
			GameCanvas.eventScr.Show(GameCanvas.gameScr);
			break;
		}
	}

	// Token: 0x060005CD RID: 1485 RVA: 0x00086A84 File Offset: 0x00084C84
	private void setskillClass()
	{
		GameScreen.player.weapon = this.msetweapon[this.indexsetClass % 5];
		GameScreen.player.addChat(T.mClazz[this.indexsetClass % 5 + 1], true);
		GameCanvas.readMess.commandPointer(10, this.indexsetClass % 5);
		this.indexsetClass++;
	}

	// Token: 0x060005CE RID: 1486 RVA: 0x00086AEC File Offset: 0x00084CEC
	private void setSkillDevil()
	{
		GameScreen.player.addChat(this.msetSkillDevil[this.indexsetSkill % this.msetSkillDevil.Length], true);
		bool flag = this.indexsetSkill % this.msetSkillDevil.Length <= 5;
		if (flag)
		{
			for (int i = 0; i < Player.vecListSkill.size(); i++)
			{
				Skill_Info skill_Info = (Skill_Info)Player.vecListSkill.elementAt(i);
				skill_Info.typeEffSkill = (short)(227 + this.indexsetSkill % this.msetSkillDevil.Length);
				bool flag2 = i == 2;
				if (flag2)
				{
					break;
				}
			}
		}
		else
		{
			bool flag3 = this.indexsetSkill % this.msetSkillDevil.Length <= 16;
			if (flag3)
			{
				for (int j = 0; j < Player.vecListSkill.size(); j++)
				{
					Skill_Info skill_Info2 = (Skill_Info)Player.vecListSkill.elementAt(j);
					skill_Info2.typeEffSkill = (short)(234 + (this.indexsetSkill % this.msetSkillDevil.Length - 6));
					bool flag4 = j == 2;
					if (flag4)
					{
						break;
					}
				}
			}
			else
			{
				bool flag5 = this.indexsetSkill % this.msetSkillDevil.Length >= 17;
				if (flag5)
				{
					for (int k = 0; k < Player.vecListSkill.size(); k++)
					{
						Skill_Info skill_Info3 = (Skill_Info)Player.vecListSkill.elementAt(k);
						skill_Info3.typeEffSkill = (short)(251 + (this.indexsetSkill % this.msetSkillDevil.Length - 17));
						bool flag6 = k == 2;
						if (flag6)
						{
							break;
						}
					}
				}
			}
		}
		this.indexsetSkill++;
	}

	// Token: 0x060005CF RID: 1487 RVA: 0x00086CA4 File Offset: 0x00084EA4
	public void addInfo()
	{
		MsgGiftLogin msgGiftLogin = new MsgGiftLogin();
		string name = "Đổi quà";
		string empty = string.Empty;
		int num = 21;
		Item_Drop[] array = new Item_Drop[num];
		for (int i = 0; i < num; i++)
		{
			sbyte type = 4;
			string name2 = "ngày " + (i + 1).ToString();
			short idIcon = (short)i;
			int num2 = i + 1;
			sbyte color = 0;
			array[i] = new Item_Drop((short)i, type, name2, 0, 0, idIcon, color);
			array[i].num = num2;
			array[i].typeGiftDaily = 0;
			bool flag = i == 0;
			if (flag)
			{
			}
		}
		MainItem mainItem = new MainItem(4, 0, 0);
		mainItem.name = "test";
		msgGiftLogin.setinfoShow_GiftLogin(0, name, empty, array, 0, "Chọn", null);
		GameCanvas.Start_Sub_Dialog(msgGiftLogin);
	}

	// Token: 0x060005D0 RID: 1488 RVA: 0x0000A4AE File Offset: 0x000086AE
	public static void startQuickMenu()
	{
		QuickMenu.gI().startAt();
	}

	// Token: 0x060005D1 RID: 1489 RVA: 0x00086D80 File Offset: 0x00084F80
	public void setPosSkill()
	{
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			bool flag = Interface_Game.typeTouch == 0;
			if (flag)
			{
				Interface_Game.xBeginKill = MotherCanvas.w - 35;
				Interface_Game.yBeginKill = MotherCanvas.h - 50;
				int num = Interface_Game.gocBegin;
				int num2 = Interface_Game.gocBegin - 30;
				for (int i = 0; i < Interface_Game.mPosKillCur.Length; i++)
				{
					bool flag2 = i == 2;
					if (flag2)
					{
						Interface_Game.mPosKillCur[i][0] = Interface_Game.xBeginKill;
						Interface_Game.mPosKillCur[i][1] = Interface_Game.yBeginKill;
					}
					else
					{
						Interface_Game.mPosKillCur[i][0] = Interface_Game.xBeginKill + CRes.getcos(CRes.fixangle(num)) * Interface_Game.lSkill / 1000;
						Interface_Game.mPosKillCur[i][1] = Interface_Game.yBeginKill + CRes.getsin(CRes.fixangle(num)) * Interface_Game.lSkill / 1000;
						num -= 35;
					}
					Interface_Game.mPosKillBuff[i][0] = Interface_Game.xBeginKill + CRes.getcos(CRes.fixangle(num2)) * (Interface_Game.lSkill + 40) / 1000;
					Interface_Game.mPosKillBuff[i][1] = Interface_Game.yBeginKill + CRes.getsin(CRes.fixangle(num2)) * (Interface_Game.lSkill + 40) / 1000;
					num2 -= 20;
					Interface_Game.mPosKillSub[i][0] = MotherCanvas.w * 2 - Interface_Game.mPosKillCur[i][0];
					Interface_Game.mPosKillSub[i][1] = Interface_Game.mPosKillCur[i][1];
				}
				Interface_Game.xBeginKill = Interface_Game.wSkill / 2;
				Interface_Game.yBeginKill = 80;
				for (int j = 0; j < Interface_Game.mPosKillCur.Length; j++)
				{
					Interface_Game.mPosEffCurrent[j][0] = Interface_Game.xBeginKill;
					Interface_Game.mPosEffCurrent[j][1] = Interface_Game.yBeginKill + j * Interface_Game.wSkill;
					Interface_Game.mPosEffCurrent[j + 6][0] = Interface_Game.xBeginKill + Interface_Game.wSkill / 2;
					Interface_Game.mPosEffCurrent[j + 6][1] = Interface_Game.yBeginKill + j * Interface_Game.wSkill;
				}
			}
			else
			{
				bool flag3 = Interface_Game.typeTouch == 1;
				if (flag3)
				{
					Interface_Game.xBeginKill = MotherCanvas.w - Interface_Game.wSkill * 6 - Interface_Game.wSkill / 2;
					Interface_Game.yBeginKill = MotherCanvas.h - 24;
					for (int k = 0; k < Interface_Game.mPosKillCur.Length; k++)
					{
						Interface_Game.mPosKillCur[k][0] = Interface_Game.xBeginKill + k * Interface_Game.wSkill;
						Interface_Game.mPosKillCur[k][1] = Interface_Game.yBeginKill;
						Interface_Game.mPosKillSub[k][0] = Interface_Game.mPosKillCur[k][0];
						Interface_Game.mPosKillSub[k][1] = MotherCanvas.h * 2 - Interface_Game.mPosKillCur[k][1];
						Interface_Game.mPosEffCurrent[k][0] = Interface_Game.xBeginKill + k * Interface_Game.wSkill;
						Interface_Game.mPosEffCurrent[k][1] = Interface_Game.yBeginKill - Interface_Game.wSkill;
						Interface_Game.mPosEffCurrent[k + 6][0] = Interface_Game.xBeginKill + k * Interface_Game.wSkill;
						Interface_Game.mPosEffCurrent[k + 6][1] = Interface_Game.yBeginKill - Interface_Game.wSkill * 2 + 4;
					}
					Interface_Game.xBeginKill = Interface_Game.wSkill / 2;
					int num3 = Interface_Game.wSkill;
					bool isTaiTho = GameCanvas.isTaiTho;
					if (isTaiTho)
					{
						Interface_Game.xBeginKill += 10;
					}
					for (int l = 0; l < Interface_Game.mPosKillBuff.Length; l++)
					{
						Interface_Game.mPosKillBuff[l][0] = Interface_Game.xBeginKill + l % 3 * num3;
						Interface_Game.mPosKillBuff[l][1] = Interface_Game.yBeginKill - num3 * (l / 3);
					}
				}
			}
		}
		else
		{
			Interface_Game.xBeginKill = MotherCanvas.hw - 70;
			Interface_Game.yBeginKill = MotherCanvas.h - GameCanvas.hCommand - 5;
			for (int m = 0; m < Interface_Game.mPosKillCur.Length; m++)
			{
				Interface_Game.mPosKillCur[m][0] = Interface_Game.xBeginKill + m * Interface_Game.wSkill;
				Interface_Game.mPosKillCur[m][1] = Interface_Game.yBeginKill;
				Interface_Game.mPosKillSub[m][0] = Interface_Game.mPosKillCur[m][0];
				Interface_Game.mPosKillSub[m][1] = MotherCanvas.h * 2 - Interface_Game.mPosKillCur[m][1];
				Interface_Game.mPosEffCurrent[m][0] = Interface_Game.xBeginKill + m * Interface_Game.wSkill;
				Interface_Game.mPosEffCurrent[m][1] = Interface_Game.yBeginKill - Interface_Game.wSkill;
			}
		}
		Interface_Game.yBeginCombo = Interface_Game.yInfoServer + 40;
		Interface_Game.xBeginCombo = MotherCanvas.w / 2;
	}

	// Token: 0x060005D2 RID: 1490 RVA: 0x0008720C File Offset: 0x0008540C
	public static void setPosTouch()
	{
		bool flag = Interface_Game.typeTouch == 1;
		if (flag)
		{
			Interface_Game.mPosOther[2][1] = MotherCanvas.h - 37;
			Interface_Game.mPosOther[3][1] = MotherCanvas.h - 67;
			Interface_Game.yAutoFire = MotherCanvas.h - 92;
			Interface_Game.yQuickChat = MotherCanvas.h - 100;
		}
		else
		{
			bool flag2 = Interface_Game.typeTouch == 0;
			if (flag2)
			{
				Interface_Game.mPosOther[2][1] = MotherCanvas.h - 30;
				Interface_Game.mPosOther[3][1] = MotherCanvas.h - 145;
				Interface_Game.yAutoFire = MotherCanvas.h - 170;
				Interface_Game.yQuickChat = MotherCanvas.h - 94 - 74;
			}
		}
	}

	// Token: 0x060005D3 RID: 1491 RVA: 0x000872BC File Offset: 0x000854BC
	public MainObject setObjectNear(int x, int y)
	{
		MainObject mainObject = null;
		Interface_Game.vecfocus.removeAllElements();
		int num = this.minDisFocus;
		for (int i = 0; i < GameScreen.vecPlayers.size(); i++)
		{
			MainObject mainObject2 = (MainObject)GameScreen.vecPlayers.elementAt(i);
			bool flag = mainObject2 == null || mainObject2 == GameScreen.player || mainObject2.returnAction() || mainObject2.typeObject == 10 || (mainObject2.Action == 4 && mainObject2.typeObject == 1);
			if (!flag)
			{
				int distance = MainObject.getDistance(x, y, mainObject2.x, mainObject2.y - mainObject2.hOne / 2);
				bool flag2 = distance > this.minDisFocus;
				if (!flag2)
				{
					bool flag3 = mainObject == null;
					if (flag3)
					{
						mainObject = mainObject2;
						num = distance;
					}
					else
					{
						bool flag4 = mainObject.typeSpecMonSter != 1 && distance < num && mainObject.typeObject != 2;
						if (flag4)
						{
							mainObject = mainObject2;
							num = distance;
						}
					}
					bool flag5 = mainObject2.typeObject != 1 && !GameScreen.player.setFightPk(mainObject2) && (mainObject2.typeObject == 0 || mainObject.typeObject == 2);
					if (flag5)
					{
						bool flag6 = mainObject2.typeObject == 2;
						if (flag6)
						{
							Interface_Game.vecfocus.insertElementAt(mainObject2, 0);
						}
						else
						{
							bool flag7 = Interface_Game.vecfocus.size() < 5;
							if (flag7)
							{
								Interface_Game.vecfocus.addElement(mainObject2);
							}
						}
					}
					bool flag8 = !GameScreen.isShowNameSUPER_BOSS && mainObject2.typeSpecMonSter == 1;
					if (flag8)
					{
						mainObject = mainObject2;
					}
				}
			}
		}
		bool flag9 = Interface_Game.vecfocus.size() > 0;
		if (flag9)
		{
			this.createShowNear();
			bool flag10 = Interface_Game.vecfocus.size() > 1 && GameScreen.player.typePK == -1 && mainObject != null && mainObject.typeSpecMonSter != 1;
			if (flag10)
			{
				mainObject = null;
			}
		}
		return mainObject;
	}

	// Token: 0x060005D4 RID: 1492 RVA: 0x000874B0 File Offset: 0x000856B0
	public void addEffCurrent(MainItem itemAdd)
	{
		bool flag = itemAdd == null;
		if (!flag)
		{
			for (int i = 0; i < Interface_Game.vecEffCurrent.size(); i++)
			{
				MainItem mainItem = (MainItem)Interface_Game.vecEffCurrent.elementAt(i);
				bool flag2 = mainItem.typeObject == itemAdd.typeObject && mainItem.indexHotKey == itemAdd.indexHotKey;
				if (flag2)
				{
					Interface_Game.vecEffCurrent.removeElement(mainItem);
					i--;
				}
			}
			bool flag3 = itemAdd.typeObject == 4;
			if (flag3)
			{
				Interface_Game.vecEffCurrent.insertElementAt(itemAdd, 0);
			}
			else
			{
				Interface_Game.vecEffCurrent.addElement(itemAdd);
			}
		}
	}

	// Token: 0x060005D5 RID: 1493 RVA: 0x0000A4BC File Offset: 0x000086BC
	public static void addShowEvent(InfoMemList mem)
	{
		Interface_Game.vecEventShow.addElement(mem);
	}

	// Token: 0x060005D6 RID: 1494 RVA: 0x00087560 File Offset: 0x00085760
	public static void paintShowEvent(mGraphics g)
	{
		bool flag = Interface_Game.eventcur != null && GameScreen.isShowChat;
		if (flag)
		{
			MainEvent.paintShort(g, MotherCanvas.hw, Interface_Game.hShowEvent - MainEvent.hShort + GameScreen.h12plus, Interface_Game.eventcur);
		}
	}

	// Token: 0x060005D7 RID: 1495 RVA: 0x000875A8 File Offset: 0x000857A8
	public static void paintShowHelp(mGraphics g, bool isInmap)
	{
		bool flag = GameScreen.vecHelp == null;
		if (!flag)
		{
			for (int i = 0; i < GameScreen.vecHelp.size(); i++)
			{
				MainHelp mainHelp = (MainHelp)GameScreen.vecHelp.elementAt(i);
				bool flag2 = mainHelp.isInMap == isInmap;
				if (flag2)
				{
					mainHelp.paint(g);
					bool isBreak = mainHelp.isBreak;
					if (isBreak)
					{
						break;
					}
				}
			}
		}
	}

	// Token: 0x060005D8 RID: 1496 RVA: 0x0008761C File Offset: 0x0008581C
	public static void UpdateShowHelp(mGraphics g)
	{
		bool flag = GameScreen.vecHelp == null;
		if (!flag)
		{
			for (int i = 0; i < GameScreen.vecHelp.size(); i++)
			{
				MainHelp mainHelp = (MainHelp)GameScreen.vecHelp.elementAt(i);
				mainHelp.update();
				bool isRemove = mainHelp.isRemove;
				if (isRemove)
				{
					GameScreen.vecHelp.removeElement(mainHelp);
				}
				else
				{
					bool isBreak = mainHelp.isBreak;
					if (isBreak)
					{
						break;
					}
				}
			}
		}
	}

	// Token: 0x060005D9 RID: 1497 RVA: 0x00087698 File Offset: 0x00085898
	public static void updateShowEvent()
	{
		bool flag = Interface_Game.eventcur != null;
		if (flag)
		{
			Interface_Game.timeShowEvent++;
			bool flag2 = Interface_Game.timeShowEvent < Interface_Game.maxTimePaint;
			if (flag2)
			{
				bool flag3 = Interface_Game.hShowEvent < MainEvent.hShort + 3;
				if (flag3)
				{
					Interface_Game.hShowEvent += Interface_Game.speedShowEvent;
					bool flag4 = Interface_Game.hShowEvent > MainEvent.hShort + 3;
					if (flag4)
					{
						Interface_Game.hShowEvent = MainEvent.hShort + 3;
					}
				}
			}
			else
			{
				bool flag5 = Interface_Game.hShowEvent > 0;
				if (flag5)
				{
					Interface_Game.hShowEvent -= Interface_Game.speedShowEvent;
				}
				else
				{
					Interface_Game.eventcur = null;
				}
			}
			bool flag6 = GameCanvas.isTouch && GameCanvas.isPointSelect(MotherCanvas.hw - MainEvent.wShort / 2, Interface_Game.hShowEvent - MainEvent.hShort, MainEvent.wShort, MainEvent.hShort);
			if (flag6)
			{
				GameCanvas.isPointerSelect = false;
				InfoMemList @event = InfoMemList.getEvent(Interface_Game.eventcur.name, Interface_Game.eventcur.typeEvent);
				bool flag7 = @event != null;
				if (flag7)
				{
					GameCanvas.eventScr.memCur = @event;
				}
				@event.setAction();
				Interface_Game.eventcur = null;
			}
		}
		bool flag8 = Interface_Game.eventcur == null && Interface_Game.vecEventShow.size() > 0;
		if (flag8)
		{
			Interface_Game.eventcur = (InfoMemList)Interface_Game.vecEventShow.elementAt(0);
			Interface_Game.hShowEvent = 0;
			Interface_Game.timeShowEvent = 0;
			Interface_Game.vecEventShow.removeElementAt(0);
		}
	}

	// Token: 0x060005DA RID: 1498 RVA: 0x00087814 File Offset: 0x00085A14
	public static void paintInfoServer(mGraphics g)
	{
		int num = Interface_Game.yInfoServer;
		int num2 = Interface_Game.xInfoServer;
		num = ((LoadMap.specMap == 10) ? (num + (66 + GameScreen.h12plus)) : ((Interface_Game.checkPaintWatch() && Interface_Game.watchMap.typeTime == 4) ? (num + (50 + GameScreen.h12plus)) : ((Interface_Game.eventcur == null || !GameScreen.isShowChat) ? (num + GameScreen.h12plus) : (num + (Interface_Game.hShowEvent + GameScreen.h12plus)))));
		bool flag = Interface_Game.eventcur == null;
		if (flag)
		{
			num += Interface_Game.yEffShowMoney + 25;
		}
		bool flag2 = Interface_Game.infoSpec != null;
		if (flag2)
		{
			GameCanvas.resetTrans(g);
			Interface_Game.paintBackInfoServerNew(g, num2, num + Interface_Game.infoSpec.y, 3);
			g.setClip(num2, num + Interface_Game.infoSpec.y, Interface_Game.wInfoServer, Interface_Game.hInfoServer);
			g.saveCanvas();
			g.ClipRec(num2, num + Interface_Game.infoSpec.y, Interface_Game.wInfoServer, Interface_Game.hInfoServer);
			int num3 = 0;
			bool flag3 = Interface_Game.infoSpec.iconClan >= 0;
			if (flag3)
			{
				num2 -= 10;
				MainImage iconClan = Potion.getIconClan(Interface_Game.infoSpec.iconClan);
				bool flag4 = iconClan != null && iconClan.img != null;
				if (flag4)
				{
					bool flag5 = iconClan.frame == -1;
					if (flag5)
					{
						iconClan.set_Frame();
					}
					bool flag6 = iconClan.frame <= 1;
					if (flag6)
					{
						g.drawImage(iconClan.img, num2 + Interface_Game.wInfoServer - Interface_Game.infoSpec.x + 9, num + Interface_Game.infoSpec.y + Interface_Game.hInfoServer / 2 - 1, 3);
					}
					else
					{
						int num4 = (Interface_Game.framepaint_2 < (int)(iconClan.frame - 1)) ? 3 : 15;
						bool flag7 = CRes.abs(GameCanvas.gameTick - Interface_Game.lastTick_2) > num4;
						if (flag7)
						{
							Interface_Game.framepaint_2++;
							bool flag8 = Interface_Game.framepaint_2 >= (int)iconClan.frame;
							if (flag8)
							{
								Interface_Game.framepaint_2 = 0;
							}
							Interface_Game.lastTick_2 = GameCanvas.gameTick;
						}
						g.drawRegion(iconClan.img, 0, Interface_Game.framepaint_2 * (int)iconClan.w, (int)iconClan.w, (int)iconClan.w, 0, (float)(num2 + Interface_Game.wInfoServer - Interface_Game.infoSpec.x + 9), (float)(num + Interface_Game.infoSpec.y + Interface_Game.hInfoServer / 2 - 1), 3);
					}
				}
				num3 = 18;
			}
			bool lowGraphic = GameCanvas.lowGraphic;
			if (lowGraphic)
			{
				mFont.tahoma_7b_black.drawString(g, Interface_Game.infoSpec.strShow, num2 + Interface_Game.wInfoServer - Interface_Game.infoSpec.x + 1 + num3, num + Interface_Game.infoSpec.y + GameCanvas.hText / 4 + 1, 0);
			}
			Interface_Game.infoSpec.fontpaint.drawString(g, Interface_Game.infoSpec.strShow, num2 + Interface_Game.wInfoServer - Interface_Game.infoSpec.x + num3, num + Interface_Game.infoSpec.y + GameCanvas.hText / 4, 0);
			num += Interface_Game.hInfoServer + Interface_Game.infoSpec.y + 2;
			g.restoreCanvas();
		}
		bool flag9 = Interface_Game.infoFight != null;
		if (flag9)
		{
			GameCanvas.resetTrans(g);
			Interface_Game.paintBackInfoServerNew(g, num2, num + Interface_Game.infoFight.y, 5);
			g.setClip(num2, num + Interface_Game.infoFight.y, Interface_Game.wInfoServer, Interface_Game.hInfoServer);
			g.saveCanvas();
			g.ClipRec(num2, num + Interface_Game.infoFight.y, Interface_Game.wInfoServer, Interface_Game.hInfoServer);
			bool lowGraphic2 = GameCanvas.lowGraphic;
			if (lowGraphic2)
			{
				mFont.tahoma_7_black.drawString(g, Interface_Game.infoFight.strShow, num2 + Interface_Game.wInfoServer - Interface_Game.infoFight.x + 1, num + Interface_Game.infoFight.y + GameCanvas.hText / 4 + 1, 0);
			}
			Interface_Game.infoFight.fontpaint.drawString(g, Interface_Game.infoFight.strShow, num2 + Interface_Game.wInfoServer - Interface_Game.infoFight.x, num + Interface_Game.infoFight.y + GameCanvas.hText / 4, 0);
			num += Interface_Game.hInfoServer + Interface_Game.infoFight.y + 2;
			g.restoreCanvas();
		}
		bool flag10 = Interface_Game.isPaintInfoServer && Interface_Game.infoNormal != null;
		if (flag10)
		{
			GameCanvas.resetTrans(g);
			Interface_Game.paintBackInfoServerNew(g, num2, num + Interface_Game.infoNormal.y, 0);
			g.setClip(num2, num + Interface_Game.infoNormal.y, Interface_Game.wInfoServer, Interface_Game.hInfoServer);
			g.saveCanvas();
			g.ClipRec(num2, num + Interface_Game.infoNormal.y, Interface_Game.wInfoServer, Interface_Game.hInfoServer);
			bool lowGraphic3 = GameCanvas.lowGraphic;
			if (lowGraphic3)
			{
				mFont.tahoma_7_black.drawString(g, Interface_Game.infoNormal.strShow, num2 + Interface_Game.wInfoServer - Interface_Game.infoNormal.x + 1, num + Interface_Game.infoNormal.y + GameCanvas.hText / 4 + 1, 0);
			}
			Interface_Game.infoNormal.fontpaint.drawString(g, Interface_Game.infoNormal.strShow, num2 + Interface_Game.wInfoServer - Interface_Game.infoNormal.x, num + Interface_Game.infoNormal.y + GameCanvas.hText / 4, 0);
			num += Interface_Game.hInfoServer + Interface_Game.infoNormal.y + 2;
			g.restoreCanvas();
		}
		bool flag11 = Interface_Game.infoPlayer != null && !Interface_Game.infoPlayer.isRemove;
		if (flag11)
		{
			int num5 = MotherCanvas.hw;
			bool flag12 = Interface_Game.isSmallInfoServer;
			if (flag12)
			{
				num5 = MotherCanvas.w - Interface_Game.wShowInfoPlayer / 2 - 4;
			}
			GameCanvas.resetTrans(g);
			Interface_Game.paintBackInfoServer(g, num5, num + Interface_Game.infoPlayer.y, Interface_Game.wShowInfoPlayer);
			g.setClip(num5 - Interface_Game.wShowInfoPlayer / 2, num + Interface_Game.infoPlayer.y, Interface_Game.wShowInfoPlayer, Interface_Game.hInfoServer);
			g.saveCanvas();
			g.ClipRec(num5 - Interface_Game.wShowInfoPlayer / 2, num + Interface_Game.infoPlayer.y, Interface_Game.wShowInfoPlayer, Interface_Game.hInfoServer);
			bool lowGraphic4 = GameCanvas.lowGraphic;
			if (lowGraphic4)
			{
				AvMain.FontBorderSmall(g, Interface_Game.infoPlayer.strShow, num5 + 1, num + Interface_Game.infoPlayer.y + GameCanvas.hText / 4 + Interface_Game.yEffInfoPlayer, 2, 0);
			}
			else
			{
				Interface_Game.infoPlayer.fontpaint.drawString(g, Interface_Game.infoPlayer.strShow, num5, num + Interface_Game.infoPlayer.y + GameCanvas.hText / 4 + Interface_Game.yEffInfoPlayer, 2);
			}
			g.restoreCanvas();
		}
		GameCanvas.resetTrans(g);
	}

	// Token: 0x060005DB RID: 1499 RVA: 0x00087ED4 File Offset: 0x000860D4
	public static void paintBackInfoServerNew(mGraphics g, int x, int y, int type)
	{
		bool flag = Interface_Game.wInfoServer > 140;
		if (flag)
		{
			g.drawImage(Interface_Game.imgInfoServer, x, y, 0);
			g.drawRegion(Interface_Game.imgInfoServer, 0, 0, Interface_Game.wInfoServer - 140, 20, 0, (float)(x + 140), (float)y, 0);
		}
		else
		{
			g.drawRegion(Interface_Game.imgInfoServer, 0, 0, Interface_Game.wInfoServer, 20, 0, (float)x, (float)y, 0);
		}
		switch (type)
		{
		case 1:
			g.drawImage(Interface_Game.imgBorderNoti, x - 4, y + Interface_Game.hInfoServer / 2, 3);
			break;
		case 2:
			g.drawImage(Interface_Game.imgBorderNoti2, x - 4, y + Interface_Game.hInfoServer / 2, 3);
			break;
		case 3:
		{
			bool flag2 = GameCanvas.language == 0 && !GameCanvas.isDeviceStore();
			if (flag2)
			{
				Interface_Game.fraBorderNoti.drawFrame(GameCanvas.IndexServer + 1, x - 4, y + Interface_Game.hInfoServer / 2, 0, 3, g);
			}
			else
			{
				Interface_Game.fraBorderNoti.drawFrame(0, x - 4, y + Interface_Game.hInfoServer / 2, 0, 3, g);
			}
			break;
		}
		case 4:
		case 5:
			Interface_Game.fraBorderNoti.drawFrame(type, x - 4, y + Interface_Game.hInfoServer / 2, 0, 3, g);
			break;
		}
	}

	// Token: 0x060005DC RID: 1500 RVA: 0x00088020 File Offset: 0x00086220
	public static void paintBackInfoServer(mGraphics g, int x, int y, int w)
	{
		bool flag = w > 140 && w <= 280;
		if (flag)
		{
			g.drawImage(Interface_Game.imgInfoServer, x - w / 2, y, 0);
			g.drawRegion(Interface_Game.imgInfoServer, 0, 0, w - 140, 20, 0, (float)(x - w / 2 + 140), (float)y, 0);
		}
		else
		{
			g.drawRegion(Interface_Game.imgInfoServer, 0, 0, w, 20, 0, (float)(x - w / 2), (float)y, 0);
		}
	}

	// Token: 0x060005DD RID: 1501 RVA: 0x000880A4 File Offset: 0x000862A4
	public static void updateInfoServer()
	{
		bool flag = Interface_Game.infoSpec != null;
		if (flag)
		{
			Interface_Game.infoSpec.update();
			bool isRemove = Interface_Game.infoSpec.isRemove;
			if (isRemove)
			{
				Interface_Game.infoSpec = null;
			}
		}
		else
		{
			for (int i = 0; i < Interface_Game.vecInfoServer.size(); i++)
			{
				InfoShowNotify infoShowNotify = (InfoShowNotify)Interface_Game.vecInfoServer.elementAt(i);
				bool flag2 = infoShowNotify.type == 1 || infoShowNotify.type == 2;
				if (flag2)
				{
					Interface_Game.infoSpec = new InfoShowNotify(infoShowNotify.strShow, infoShowNotify.type);
					Interface_Game.infoSpec.setValue(infoShowNotify.fontpaint);
					Interface_Game.infoSpec.iconClan = infoShowNotify.iconClan;
					string str = string.Empty;
					bool flag3 = Interface_Game.infoSpec.iconClan >= 0;
					if (flag3)
					{
						str = T.Clan + " ";
					}
					GameCanvas.chatTabScr.addNewChat(T.tabServer, string.Empty, str + infoShowNotify.strShow, 1, false);
					Interface_Game.vecInfoServer.removeElement(infoShowNotify);
					break;
				}
			}
		}
		Interface_Game.infoNormal = Interface_Game.setUpdateInfoServer(Interface_Game.infoNormal, 0);
		Interface_Game.infoFight = Interface_Game.setUpdateInfoServer(Interface_Game.infoFight, 5);
		bool flag4 = Interface_Game.infoPlayer != null && !Interface_Game.infoPlayer.isRemove;
		if (flag4)
		{
			Interface_Game.infoPlayer.update();
			bool flag5 = Interface_Game.yEffInfoPlayer > 0;
			if (flag5)
			{
				Interface_Game.yEffInfoPlayer -= 2;
			}
		}
		for (int j = 0; j < Interface_Game.vecQuickChatLoL.size(); j++)
		{
			InfoShowNotify infoShowNotify2 = (InfoShowNotify)Interface_Game.vecQuickChatLoL.elementAt(j);
			infoShowNotify2.time++;
			bool flag6 = infoShowNotify2.time >= 200;
			if (flag6)
			{
				Interface_Game.vecQuickChatLoL.removeElementAt(j);
				j--;
			}
		}
	}

	// Token: 0x060005DE RID: 1502 RVA: 0x000882AC File Offset: 0x000864AC
	public static InfoShowNotify setUpdateInfoServer(InfoShowNotify infoInput, sbyte type)
	{
		bool flag = infoInput != null;
		if (flag)
		{
			infoInput.isPaint = Interface_Game.isPaintInfoServer;
			infoInput.update();
			bool isRemove = infoInput.isRemove;
			if (isRemove)
			{
				infoInput = null;
			}
		}
		else
		{
			for (int i = 0; i < Interface_Game.vecInfoServer.size(); i++)
			{
				InfoShowNotify infoShowNotify = (InfoShowNotify)Interface_Game.vecInfoServer.elementAt(i);
				bool flag2 = infoShowNotify.type == type;
				if (flag2)
				{
					infoInput = new InfoShowNotify(infoShowNotify.strShow, infoShowNotify.type);
					infoInput.setValue(infoShowNotify.fontpaint);
					GameCanvas.chatTabScr.addNewChat(T.tabServer, string.Empty, infoShowNotify.strShow, 1, false);
					Interface_Game.vecInfoServer.removeElement(infoShowNotify);
					break;
				}
			}
		}
		return infoInput;
	}

	// Token: 0x060005DF RID: 1503 RVA: 0x00088380 File Offset: 0x00086580
	public static void addInfoServer(InfoShowNotify info)
	{
		bool flag = info.type == 2;
		if (flag)
		{
			Interface_Game.vecInfoServer.insertElementAt(info, 0);
		}
		else
		{
			Interface_Game.vecInfoServer.addElement(info);
		}
	}

	// Token: 0x060005E0 RID: 1504 RVA: 0x000883BC File Offset: 0x000865BC
	public static void addInfoPlayerNormal(string str, mFont font)
	{
		Interface_Game.infoPlayer.strShow = str;
		Interface_Game.infoPlayer.setValue(font);
		Interface_Game.yEffInfoPlayer = 20;
		Interface_Game.wShowInfoPlayer = Interface_Game.infoPlayer.fontpaint.getWidth(Interface_Game.infoPlayer.strShow) + 4;
	}

	// Token: 0x060005E1 RID: 1505 RVA: 0x00088408 File Offset: 0x00086608
	public static void paintNumMess(mGraphics g, int xlech, int ylech)
	{
		int num = 0;
		bool flag = Interface_Game.timePointer > 0 && Interface_Game.keyPoint == 106;
		if (flag)
		{
			num = 1;
		}
		int num2 = Interface_Game.xNumMess + xlech;
		int num3 = Interface_Game.yNumMess + ylech;
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			g.drawRegion(AvMain.imgMess, 0, num * 16, 22, 16, 0, (float)num2, (float)(num3 + Interface_Game.numMess.yNum), 0);
		}
		else
		{
			g.drawImage(AvMain.imgMess, num2, num3 + Interface_Game.numMess.yNum, 0);
		}
		bool flag2 = !GameCanvas.isTouch && GameCanvas.currentScreen == GameCanvas.gameScr;
		if (flag2)
		{
			g.drawImage(AvMain.imgChat, Interface_Game.xChat, Interface_Game.yChat + GameScreen.h12plus, 0);
		}
		bool flag3 = GameScreen.numMess > 0;
		if (flag3)
		{
			int num4 = -3;
			bool isTouch2 = GameCanvas.isTouch;
			if (isTouch2)
			{
				num4 = 0;
			}
			string st = string.Empty + GameScreen.numMess.ToString();
			bool flag4 = GameScreen.numMess > 9;
			if (flag4)
			{
				st = "9+";
			}
			mFont.tahoma_7_black.drawString(g, st, num2 + num4, num3 + Interface_Game.numMess.yNum + 2, 2);
		}
		bool flag5 = GameCanvas.isTouch && GameCanvas.currentScreen == GameCanvas.gameScr;
		if (flag5)
		{
			int idx = 2;
			bool flag6 = !Interface_Game.isAutoFireInterface;
			if (flag6)
			{
				idx = 0;
			}
			else
			{
				bool flag7 = GameCanvas.gameTick % 12 < 7;
				if (flag7)
				{
					idx = 1;
				}
			}
			AvMain.fraAutoFire.drawFrame(idx, Interface_Game.xAutoFire, Interface_Game.yAutoFire, 0, 0, g);
		}
	}

	// Token: 0x060005E2 RID: 1506 RVA: 0x000885AC File Offset: 0x000867AC
	public static void updateNumMess()
	{
		bool flag = GameScreen.numMess > 0;
		if (flag)
		{
			Interface_Game.numMess.update();
		}
		else
		{
			Interface_Game.numMess.yNum = 0;
		}
		bool isNew = Clan_Screen.isNew;
		if (isNew)
		{
			Interface_Game.numClan.update();
		}
	}

	// Token: 0x060005E3 RID: 1507 RVA: 0x0000A4CB File Offset: 0x000086CB
	public static void setMoveTo(int x, int y)
	{
		Interface_Game.xMoveTo = x;
		Interface_Game.yMoveto = y;
		Interface_Game.timeMoveTo = 0;
	}

	// Token: 0x060005E4 RID: 1508 RVA: 0x000885F8 File Offset: 0x000867F8
	public static void updateMoveTo()
	{
		bool flag = Interface_Game.timeMoveTo < 10;
		if (flag)
		{
			Interface_Game.timeMoveTo++;
		}
	}

	// Token: 0x060005E5 RID: 1509 RVA: 0x00088624 File Offset: 0x00086824
	public static void paintMoveTo(mGraphics g)
	{
		bool flag = Interface_Game.timeMoveTo < 10 && AvMain.fraMoveTo != null;
		if (flag)
		{
			AvMain.fraMoveTo.drawFrame(Interface_Game.timeMoveTo / 2, Interface_Game.xMoveTo, Interface_Game.yMoveto, 0, 3, g);
		}
	}

	// Token: 0x060005E6 RID: 1510 RVA: 0x0008866C File Offset: 0x0008686C
	public void paintShowNameMap(mGraphics g)
	{
		bool flag = Interface_Game.maxHPMap > -1;
		if (flag)
		{
			int num = 42;
			g.setColor(13350814);
			g.fillRect(MotherCanvas.w - 60 - 2, num + 36 - 1, 58, 12);
			Interface_Game.PaintHPMP(g, 1, Interface_Game.HPMap, Interface_Game.maxHPMap, MotherCanvas.w - 60 - 1, num + 36, 0, 10, 56, 0, false, 0, false, 0);
		}
		bool flag2 = LoadMap.specMap != 10 && Interface_Game.checkPaintWatch();
		if (flag2)
		{
			this.paintWatchMap(g);
		}
		this.paintQuickChatLoL(g);
		bool flag3 = Interface_Game.watchRevice.timeCountDown > 0;
		if (flag3)
		{
			this.paintWatchRevice(g);
		}
		bool flag4 = Interface_Game.yShowNameMap > 0 && GameScreen.player != null && GameScreen.player.Lv > 1;
		if (flag4)
		{
			this.paintNameMap(g);
		}
		bool flag5 = Interface_Game.typeShowPvP >= 0;
		if (flag5)
		{
			this.paintShowtypePvP(g, MotherCanvas.hw, 80);
		}
		bool flag6 = LoadMap.specMap == 10;
		if (flag6)
		{
			this.paintInfoLoL(g);
		}
		bool isShowNameWW = GameScreen.isShowNameWW;
		if (isShowNameWW)
		{
			bool flag7 = Interface_Game.imgBorderWW == null;
			if (flag7)
			{
				Interface_Game.imgBorderWW = mImage.createImage("/interface/wwborder.png");
			}
			else
			{
				g.drawImage(Interface_Game.imgBorderWW, MotherCanvas.w / 2, 15 + GameScreen.h12plus, 3);
				mFont.tahoma_7_white.drawString(g, string.Empty + GameScreen.player.checkWW.ToString(), MotherCanvas.w / 2, 3 + GameScreen.h12plus, 2);
				mFont.tahoma_7b_green.drawString(g, string.Empty + GameScreen.player.killWW.ToString(), MotherCanvas.w / 2 - 12, 15 + GameScreen.h12plus, 2);
				mFont.tahoma_7b_red.drawString(g, string.Empty + GameScreen.player.deadWW.ToString(), MotherCanvas.w / 2 + 12, 15 + GameScreen.h12plus, 2);
			}
		}
	}

	// Token: 0x060005E7 RID: 1511 RVA: 0x0008887C File Offset: 0x00086A7C
	private void paintQuickChatLoL(mGraphics g)
	{
		for (int i = 0; i < Interface_Game.vecQuickChatLoL.size(); i++)
		{
			InfoShowNotify infoShowNotify = (InfoShowNotify)Interface_Game.vecQuickChatLoL.elementAt(i);
			infoShowNotify.paintQuickChat(g, MotherCanvas.w - 4, Interface_Game.yQuickChat - GameCanvas.hText - i * GameCanvas.hText);
		}
	}

	// Token: 0x060005E8 RID: 1512 RVA: 0x000888D8 File Offset: 0x00086AD8
	public static bool checkPaintWatch()
	{
		bool flag = Interface_Game.watchMap == null || GameCanvas.loadmap == null;
		bool result;
		if (flag)
		{
			result = false;
		}
		else
		{
			bool flag2 = Interface_Game.watchMap.timeCountDown > 0 || GameCanvas.loadmap.idMap == 995 || GameCanvas.loadmap.idMap == 997 || GameCanvas.loadmap.idMap == 997 || (GameCanvas.loadmap.idMap >= 988 && GameCanvas.loadmap.idMap >= 995);
			result = flag2;
		}
		return result;
	}

	// Token: 0x060005E9 RID: 1513 RVA: 0x0008897C File Offset: 0x00086B7C
	private void paintWatchMap(mGraphics g)
	{
		bool flag = GameCanvas.menuCur.isShowMenu || (GameCanvas.isTouch && this.xShow < 75 && Interface_Game.vecClanDam != null && Interface_Game.vecClanDam.size() > 0) || GameScreen.isPvPNew;
		if (!flag)
		{
			bool flag2 = Interface_Game.watchMap.typeTime == 4 || GameCanvas.loadmap.idMap == 995;
			if (flag2)
			{
				bool flag3 = Interface_Game.indexPaintTable == 1;
				if (flag3)
				{
					this.paintTableScoreLienTiep(g);
				}
				else
				{
					this.paintTableScoreNormal(g);
				}
			}
			else
			{
				int num = Interface_Game.wtable2;
				int num2 = 42;
				int num3 = MotherCanvas.w - num / 2 - 3;
				bool flag4 = !GameCanvas.isTouch && Interface_Game.vecClanDam != null && Interface_Game.vecClanDam.size() > 0;
				if (flag4)
				{
					num2 = 80;
					num3 = 35;
				}
				bool flag5 = Interface_Game.watchMap.typeTime == 2;
				if (flag5)
				{
					num = 54;
					num3 = MotherCanvas.w - num / 2;
					num2 = 94 + GameScreen.h12plus;
					bool flag6 = GameCanvas.loadmap.idMap >= 167 && GameCanvas.loadmap.idMap <= 175;
					if (flag6)
					{
						num2 = 42 + GameScreen.h12plus;
					}
					AvMain.paintnenFocusSmall(g, num3 - num / 2 - 2, num2 + 3, num, 27);
				}
				else
				{
					AvMain.paintRect(g, num3 - num / 2 - 1, num2, num, 32, 1, 4);
				}
				mFont.tahoma_7b_white.drawString(g, Interface_Game.watchMap.strInfo, num3, num2 + Interface_Game.hTextWatch / 5, 2);
				Interface_Game.watchMap.paintCountDownTicket(g, mFont.tahoma_7b_white, num3, num2 + Interface_Game.hTextWatch / 2 + Interface_Game.hTextWatch / 5 + 4, 2);
			}
		}
	}

	// Token: 0x060005EA RID: 1514 RVA: 0x00088B38 File Offset: 0x00086D38
	private void paintTableScoreNormal(mGraphics g)
	{
		int num = 136;
		int num2 = MotherCanvas.w / 2 + 8;
		bool flag = GameScreen.typeViewPlayer == 1;
		if (flag)
		{
			num2 = MotherCanvas.w / 2;
		}
		int num3 = 2 + GameScreen.h12plus;
		bool flag2 = MotherCanvas.w < 280;
		if (flag2)
		{
			bool flag3 = AvMain.imgTimePvpSmall == null;
			if (flag3)
			{
				AvMain.imgTimePvpSmall = mImage.createImage("/interface/timepvpsmall.png");
			}
			else
			{
				mImage image = AvMain.imgTimePvpSmall;
				num3 = 4;
				num = 84;
				g.drawImage(image, num2, 25 + num3, 3);
				AvMain.FontBorderColor(g, Interface_Game.watchMap.valueLeft.ToString() + string.Empty, num2 - num / 4, num3 + Interface_Game.hTextWatch / 5, 2, 6, 7);
				AvMain.FontBorderColor(g, Interface_Game.watchMap.valueright.ToString() + string.Empty, num2 + num / 4, num3 + Interface_Game.hTextWatch / 5, 2, 1, 7);
				Interface_Game.watchMap.paintCountDownTicket(g, mFont.tahoma_7_white, num2, num3 + Interface_Game.hTextWatch / 2 + Interface_Game.hTextWatch / 5 + 4 + 8, 2);
			}
		}
		else
		{
			bool flag4 = AvMain.imgTimePvp == null;
			if (flag4)
			{
				AvMain.imgTimePvp = mImage.createImage("/interface/timepvp.png");
			}
			else
			{
				mImage image = AvMain.imgTimePvp;
				g.drawImage(image, num2, 25 + num3, 3);
				AvMain.FontBorderColor(g, Interface_Game.watchMap.valueLeft.ToString() + string.Empty, num2 - num / 4, num3 + 5 + Interface_Game.hTextWatch / 5, 2, 6, 7);
				AvMain.FontBorderColor(g, Interface_Game.watchMap.valueright.ToString() + string.Empty, num2 + num / 4, num3 + Interface_Game.hTextWatch / 5 + 5, 2, 1, 7);
				Interface_Game.watchMap.paintCountDownTicket(g, mFont.tahoma_7_white, num2, num3 + Interface_Game.hTextWatch / 2 + Interface_Game.hTextWatch / 5 + 4 + 4, 2);
			}
		}
	}

	// Token: 0x060005EB RID: 1515 RVA: 0x00088D24 File Offset: 0x00086F24
	private void paintTableScoreLienTiep(mGraphics g)
	{
		int num = 136;
		int num2 = MotherCanvas.w / 2 + 8;
		bool flag = GameScreen.typeViewPlayer == 1;
		if (flag)
		{
			num2 = MotherCanvas.w / 2;
		}
		int num3 = 2 + GameScreen.h12plus;
		bool flag2 = MotherCanvas.w < 280;
		if (flag2)
		{
			bool flag3 = AvMain.imgTimePvpSmall == null;
			if (flag3)
			{
				AvMain.imgTimePvpSmall = mImage.createImage("/interface/timepvpsmall2.png");
			}
			else
			{
				mImage image = AvMain.imgTimePvpSmall;
				num3 = 4;
				num = 84;
				g.drawImage(image, num2, 25 + num3, 3);
				AvMain.FontBorderColor(g, Interface_Game.watchMap.valueLeft.ToString() + string.Empty, num2 - num / 4, num3 + Interface_Game.hTextWatch / 5, 2, 0, 7);
				AvMain.FontBorderColor(g, Interface_Game.watchMap.valueright.ToString() + string.Empty, num2 + num / 4, num3 + Interface_Game.hTextWatch / 5, 2, 0, 7);
				Interface_Game.watchMap.paintCountDownTicket(g, mFont.tahoma_7_white, num2, num3 + Interface_Game.hTextWatch / 2 + Interface_Game.hTextWatch / 5 + 4 + 8, 2);
			}
		}
		else
		{
			bool flag4 = AvMain.imgTimePvp == null;
			if (flag4)
			{
				AvMain.imgTimePvp = mImage.createImage("/interface/timepvp2.png");
			}
			else
			{
				mImage image = AvMain.imgTimePvp;
				g.drawImage(image, num2, 25 + num3, 3);
				AvMain.FontBorderColor(g, Interface_Game.watchMap.valueLeft.ToString() + string.Empty, num2 - num / 4, num3 + 5 + Interface_Game.hTextWatch / 5, 2, 0, 7);
				AvMain.FontBorderColor(g, Interface_Game.watchMap.valueright.ToString() + string.Empty, num2 + num / 4, num3 + Interface_Game.hTextWatch / 5 + 5, 2, 0, 7);
				Interface_Game.watchMap.paintCountDownTicket(g, mFont.tahoma_7_white, num2, num3 + Interface_Game.hTextWatch / 2 + Interface_Game.hTextWatch / 5 + 4 + 4, 2);
			}
		}
	}

	// Token: 0x060005EC RID: 1516 RVA: 0x00088F10 File Offset: 0x00087110
	private void paintWatchRevice(mGraphics g)
	{
		int num = 54;
		int num2 = 124 + GameScreen.h12plus;
		int num3 = MotherCanvas.w - num / 2 - 2;
		bool flag = LoadMap.specMap == 10;
		if (flag)
		{
			num2 = Interface_Game.yLoL + 28;
			num3 = Interface_Game.xLoL;
		}
		AvMain.paintnenFocusSmall(g, num3 - num / 2, num2 + 3, num, 27);
		mFont.tahoma_7b_white.drawString(g, Interface_Game.watchRevice.strInfo, num3, num2 + Interface_Game.hTextWatch / 5, 2);
		Interface_Game.watchRevice.paintCountDownTicket(g, mFont.tahoma_7b_white, num3, num2 + Interface_Game.hTextWatch / 2 + Interface_Game.hTextWatch / 5 + 4, 2);
	}

	// Token: 0x060005ED RID: 1517 RVA: 0x00088FB0 File Offset: 0x000871B0
	private void paintNameMap(mGraphics g)
	{
		AvMain.paintnenFocus(g, MotherCanvas.hw - Interface_Game.wtable / 2, Interface_Game.yShowNameMap + GameScreen.h12plus - 40, Interface_Game.wtable, 36);
		AvMain.Font3dColor(g, Interface_Game.nameMap, MotherCanvas.hw, Interface_Game.yShowNameMap + GameScreen.h12plus - 40 + GameCanvas.hText / 2, 2, 0);
		mFont.tahoma_7_white.drawString(g, string.Concat(new string[]
		{
			"- ",
			T.Area,
			" ",
			LoadMap.getShowArea(LoadMap.Area).ToString(),
			" -"
		}), MotherCanvas.hw, Interface_Game.yShowNameMap + GameScreen.h12plus - 40 + GameCanvas.hText * 3 / 2, 2);
	}

	// Token: 0x060005EE RID: 1518 RVA: 0x0008907C File Offset: 0x0008727C
	public void paintInfoLoL(mGraphics g)
	{
		bool flag = Interface_Game.fraLol == null;
		if (flag)
		{
			this.loadImageLOL();
		}
		bool flag2 = !GameCanvas.lowGraphic;
		if (flag2)
		{
			g.drawImage(Interface_Game.imgbgLoL, Interface_Game.xLoL, Interface_Game.yLoL, 3);
		}
		Interface_Game.watchMap.paintCountDownTicket(g, mFont.tahoma_7_white, Interface_Game.xLoL, Interface_Game.yLoL - 30, 2);
		AvMain.FontBorderSmall(g, string.Empty + Interface_Game.killLeft.ToString(), Interface_Game.xLoL - 37, Interface_Game.yLoL - 29, 2, 6);
		AvMain.FontBorderSmall(g, string.Empty + Interface_Game.truLeft.ToString(), Interface_Game.xLoL - 23, Interface_Game.yLoL - 28, 2, 6);
		AvMain.FontBorderSmall(g, string.Empty + Interface_Game.killRight.ToString(), Interface_Game.xLoL + 38, Interface_Game.yLoL - 29, 2, 1);
		AvMain.FontBorderSmall(g, string.Empty + Interface_Game.truRight.ToString(), Interface_Game.xLoL + 24, Interface_Game.yLoL - 28, 2, 1);
		bool flag3 = Interface_Game.valueHoiSinhLOL == 1;
		if (flag3)
		{
			g.drawImage(Interface_Game.imgHoiSinhLoL, Interface_Game.xLoL - 60, Interface_Game.yLoL - 8, 3);
		}
		for (int i = 0; i < Interface_Game.mValueLoL.Length; i++)
		{
			Interface_Game.fraLol[(int)Interface_Game.mValueLoL[i][0]].drawFrame((int)Interface_Game.mValueLoL[i][1], Interface_Game.xLoL - 35 + i / 3 * 35, Interface_Game.yLoL + 3 - 12 + 16 * (i % 3), 0, 3, g);
		}
	}

	// Token: 0x060005EF RID: 1519 RVA: 0x0008921C File Offset: 0x0008741C
	private void paintShowtypePvP(mGraphics g, int x, int y)
	{
		switch (Interface_Game.typeShowPvP)
		{
		case 0:
		case 2:
		case 3:
		case 4:
		{
			bool flag = Interface_Game.mImgPvPType == null;
			if (flag)
			{
				this.loadImagePvP();
			}
			else
			{
				g.drawImage(Interface_Game.mImgPvPType[(int)Interface_Game.typeShowPvP], x + Interface_Game.xShowEffPvP, y + Interface_Game.yShowEffPvP, 3);
			}
			break;
		}
		case 1:
		{
			bool flag2 = Interface_Game.mImgPvPType == null;
			if (flag2)
			{
				this.loadImagePvP();
			}
			else
			{
				int y2 = ((Interface_Game.tickShowPvP >= 75) ? 5 : ((Interface_Game.tickShowPvP >= 60) ? 4 : ((Interface_Game.tickShowPvP >= 50) ? 3 : ((Interface_Game.tickShowPvP >= 35) ? 2 : ((Interface_Game.tickShowPvP >= 25) ? 1 : 0))))) * 20;
				g.drawRegion(Interface_Game.mImgPvPType[1], 0, y2, 20, 20, 0, (float)(x + Interface_Game.xShowEffPvP), (float)(y + Interface_Game.yShowEffPvP), 3);
			}
			break;
		}
		}
	}

	// Token: 0x060005F0 RID: 1520 RVA: 0x00089318 File Offset: 0x00087518
	public void updateShowNameMap()
	{
		bool flag = Interface_Game.watchMap.timeCountDown > 0;
		if (flag)
		{
			Interface_Game.watchMap.updateTimeCountDownTicket();
		}
		bool flag2 = Interface_Game.watchRevice.timeCountDown > 0;
		if (flag2)
		{
			Interface_Game.watchRevice.updateTimeCountDownTicket();
		}
		bool flag3 = Interface_Game.timeShowNameMap >= 0;
		if (flag3)
		{
			Interface_Game.timeShowNameMap++;
			bool flag4 = Interface_Game.timeShowNameMap <= 80;
			if (flag4)
			{
				Interface_Game.yShowNameMap = MotherCanvas.h / 5 + 14;
				bool isSmallScreen = GameCanvas.isSmallScreen;
				if (isSmallScreen)
				{
					Interface_Game.yShowNameMap = 50;
				}
			}
			else
			{
				Interface_Game.speedShowNameMap -= 2;
				Interface_Game.yShowNameMap += Interface_Game.speedShowNameMap;
				bool flag5 = Interface_Game.yShowNameMap <= 0;
				if (flag5)
				{
					Interface_Game.timeShowNameMap = -1;
				}
			}
			bool flag6 = Interface_Game.timeShowNameMap == 80;
			if (flag6)
			{
				Interface_Game.speedShowNameMap = 8;
			}
		}
		bool flag7 = Interface_Game.typeShowPvP >= 0;
		if (flag7)
		{
			Interface_Game.updateTypePvP();
		}
	}

	// Token: 0x060005F1 RID: 1521 RVA: 0x00089420 File Offset: 0x00087620
	public static void paintShowNear(mGraphics g)
	{
		bool flag = Interface_Game.timeShowNear <= -5;
		if (!flag)
		{
			int num = 60;
			int num2 = GameCanvas.hText + 8;
			for (int i = 0; i < Interface_Game.vecfocus.size(); i++)
			{
				MainObject mainObject = (MainObject)Interface_Game.vecfocus.elementAt(i);
				string text = mainObject.name;
				bool flag2 = mainObject.isNPC_Area() == 99;
				if (flag2)
				{
					text = T.Area;
				}
				bool flag3 = text.Length > 11;
				if (flag3)
				{
					text = mainObject.name.Substring(0, 10);
				}
				sbyte isborder = 1;
				bool flag4 = mainObject.typeObject == 2;
				if (flag4)
				{
					isborder = 3;
				}
				int num3 = Interface_Game.xShowNear;
				AvMain.paintRect(g, num3, num + num2 * i, 68, num2 - 4, isborder, 4);
				bool flag5 = mainObject.isNPC_Area() == 1 && mainObject.typePlayer != 2 && mainObject.typePlayer != 3;
				if (flag5)
				{
					mFont.tahoma_7_white.drawString(g, text, num3 + 21, num + GameCanvas.hText / 4 + num2 * i, 0);
					mainObject.paintHead(g, num3 + 10, num + GameCanvas.hText / 2 + num2 * i, 2);
				}
				else
				{
					mFont.tahoma_7_white.drawString(g, text, num3 + 35, num + GameCanvas.hText / 4 + num2 * i, 2);
				}
			}
		}
	}

	// Token: 0x060005F2 RID: 1522 RVA: 0x00089590 File Offset: 0x00087790
	public void paintShowtime(mGraphics g)
	{
		bool flag = Interface_Game.vecClanDam != null && Interface_Game.vecClanDam.size() != 0 && !GameCanvas.menuCur.isShowMenu;
		if (flag)
		{
			int num = 0;
			bool flag2 = this.timepointer > 0 && this.isFocusTime;
			if (flag2)
			{
				num = 1;
			}
			bool flag3 = true;
			bool flag4 = this.xShow < 75;
			if (flag4)
			{
				flag3 = false;
			}
			bool flag5 = flag3;
			if (flag5)
			{
				g.drawRegion(Interface_Game.imgOther[4], 0, num * 40, 16, 40, 2, (float)(MotherCanvas.w - 14), (float)(MotherCanvas.h / 2 - 35), 0);
			}
		}
	}

	// Token: 0x060005F3 RID: 1523 RVA: 0x00089630 File Offset: 0x00087830
	public void paintInfoClanDam(mGraphics g)
	{
		bool flag = Interface_Game.vecClanDam == null || Interface_Game.vecClanDam.size() == 0;
		if (!flag)
		{
			int num = 60;
			int hText = GameCanvas.hText;
			for (int i = 0; i < Interface_Game.vecClanDam.size(); i++)
			{
				MainClan mainClan = (MainClan)Interface_Game.vecClanDam.elementAt(i);
				string text = mainClan.name;
				bool flag2 = text.Length > 11;
				if (flag2)
				{
					text = mainClan.name.Substring(0, 10);
				}
				sbyte isborder = 1;
				int num2 = MotherCanvas.w - 70 + (int)this.xShow;
				AvMain.paintRect(g, num2, num + hText * 2 * i, 68, hText * 2 - 4, isborder, 4);
				mFont.tahoma_7_white.drawString(g, text, num2 + 21, num + GameCanvas.hText / 4 + hText * 2 * i - 2, 0);
				MainImage iconClan = Potion.getIconClan(mainClan.idIcon);
				bool flag3 = iconClan != null && iconClan.img != null;
				if (flag3)
				{
					bool flag4 = iconClan.frame == -1;
					if (flag4)
					{
						iconClan.set_Frame();
					}
					bool flag5 = iconClan.frame <= 1;
					if (flag5)
					{
						g.drawImage(iconClan.img, num2 + 10, num + GameCanvas.hText / 2 + hText * 2 * i, 3);
					}
					else
					{
						int num3 = (this.framepaint < (int)(iconClan.frame - 1)) ? 3 : 15;
						bool flag6 = CRes.abs(GameCanvas.gameTick - this.lastTick) > num3;
						if (flag6)
						{
							this.framepaint++;
							bool flag7 = this.framepaint >= (int)iconClan.frame;
							if (flag7)
							{
								this.framepaint = 0;
							}
							this.lastTick = GameCanvas.gameTick;
						}
						g.drawRegion(iconClan.img, 0, this.framepaint * (int)iconClan.w, (int)iconClan.w, (int)iconClan.w, 0, (float)(num2 + 10), (float)(num + GameCanvas.hText / 2 + hText * 2 * i), 3);
					}
				}
				AvMain.FontBorderColor(g, string.Empty + mainClan.xp.ToString(), num2 + 34, num + hText * 2 * i + hText, 2, 6, 7);
			}
		}
	}

	// Token: 0x060005F4 RID: 1524 RVA: 0x00089880 File Offset: 0x00087A80
	public static void updateShowNear()
	{
		Interface_Game.timeShowNear--;
		bool flag = Interface_Game.timeShowNear > 0;
		if (flag)
		{
			bool flag2 = Interface_Game.xShowNear > MotherCanvas.w - 70;
			if (flag2)
			{
				Interface_Game.speedShowNear += 10;
				Interface_Game.xShowNear -= Interface_Game.speedShowNear;
				bool flag3 = Interface_Game.xShowNear < MotherCanvas.w - 70;
				if (flag3)
				{
					Interface_Game.xShowNear = MotherCanvas.w - 70;
					Interface_Game.speedShowNear = 0;
				}
			}
		}
		else
		{
			bool flag4 = Interface_Game.xShowNear < MotherCanvas.w;
			if (flag4)
			{
				Interface_Game.speedShowNear += 10;
				Interface_Game.xShowNear += Interface_Game.speedShowNear;
			}
		}
	}

	// Token: 0x060005F5 RID: 1525 RVA: 0x0000A4E0 File Offset: 0x000086E0
	private void createShowNear()
	{
		Interface_Game.xShowNear = MotherCanvas.w;
		Interface_Game.speedShowNear = 0;
		Interface_Game.timeShowNear = 80;
	}

	// Token: 0x060005F6 RID: 1526 RVA: 0x00089934 File Offset: 0x00087B34
	public static void setTypePvP(sbyte type)
	{
		Interface_Game.typeShowPvP = type;
		Interface_Game.yShowEffPvP = 0;
		Interface_Game.xShowEffPvP = 0;
		Interface_Game.demShowEffPvP = 0;
		switch (Interface_Game.typeShowPvP)
		{
		case 0:
			Interface_Game.tickShowPvP = 25;
			Interface_Game.xShowEffPvP = -MotherCanvas.w / 2;
			break;
		case 1:
			Interface_Game.tickShowPvP = 75;
			break;
		case 2:
			Interface_Game.tickShowPvP = 25;
			Interface_Game.xShowEffPvP = MotherCanvas.w / 2;
			break;
		case 3:
			Interface_Game.tickShowPvP = 60;
			Interface_Game.yShowEffPvP = MotherCanvas.h - 80;
			break;
		case 4:
			Interface_Game.yShowEffPvP = -80;
			Interface_Game.tickShowPvP = 60;
			break;
		}
	}

	// Token: 0x060005F7 RID: 1527 RVA: 0x000899D8 File Offset: 0x00087BD8
	public static void updateTypePvP()
	{
		Interface_Game.demShowEffPvP++;
		bool flag = Interface_Game.typeShowPvP == 0;
		if (flag)
		{
			bool flag2 = Interface_Game.demShowEffPvP < 10;
			if (flag2)
			{
				bool flag3 = Interface_Game.xShowEffPvP < 0;
				if (flag3)
				{
					Interface_Game.xShowEffPvP += 50;
					bool flag4 = Interface_Game.xShowEffPvP > 0;
					if (flag4)
					{
						Interface_Game.xShowEffPvP = 0;
					}
				}
			}
			else
			{
				bool flag5 = Interface_Game.demShowEffPvP > 20 && Interface_Game.xShowEffPvP < MotherCanvas.w;
				if (flag5)
				{
					Interface_Game.xShowEffPvP += 50;
				}
			}
		}
		else
		{
			bool flag6 = Interface_Game.typeShowPvP == 2;
			if (flag6)
			{
				bool flag7 = Interface_Game.demShowEffPvP < 10;
				if (flag7)
				{
					bool flag8 = Interface_Game.xShowEffPvP > 0;
					if (flag8)
					{
						Interface_Game.xShowEffPvP -= 80;
						bool flag9 = Interface_Game.xShowEffPvP < 0;
						if (flag9)
						{
							Interface_Game.xShowEffPvP = 0;
						}
					}
				}
				else
				{
					bool flag10 = Interface_Game.demShowEffPvP > 20 && Interface_Game.xShowEffPvP > -MotherCanvas.w;
					if (flag10)
					{
						Interface_Game.xShowEffPvP -= 50;
					}
				}
			}
			else
			{
				bool flag11 = Interface_Game.typeShowPvP == 3;
				if (flag11)
				{
					bool flag12 = Interface_Game.demShowEffPvP < 10 && Interface_Game.yShowEffPvP > 0;
					if (flag12)
					{
						Interface_Game.yShowEffPvP -= 80;
						bool flag13 = Interface_Game.yShowEffPvP < 0;
						if (flag13)
						{
							Interface_Game.yShowEffPvP = 0;
						}
					}
				}
				else
				{
					bool flag14 = Interface_Game.typeShowPvP == 4 && Interface_Game.demShowEffPvP < 10 && Interface_Game.yShowEffPvP < 0;
					if (flag14)
					{
						Interface_Game.yShowEffPvP += 10;
						bool flag15 = Interface_Game.yShowEffPvP > 0;
						if (flag15)
						{
							Interface_Game.yShowEffPvP = 0;
						}
					}
				}
			}
		}
		Interface_Game.tickShowPvP -= 1;
		bool flag16 = Interface_Game.tickShowPvP <= 0;
		if (flag16)
		{
			Interface_Game.typeShowPvP = -1;
		}
	}

	// Token: 0x060005F8 RID: 1528 RVA: 0x00089BBC File Offset: 0x00087DBC
	public void loadImagePvP()
	{
		Interface_Game.mImgPvPType = new mImage[5];
		for (int i = 0; i < Interface_Game.mImgPvPType.Length; i++)
		{
			bool flag = i != 1 && GameCanvas.language == 1;
			if (flag)
			{
				Interface_Game.mImgPvPType[i] = mImage.createImage("/interface/pvp" + i.ToString() + "_e.png");
			}
			else
			{
				Interface_Game.mImgPvPType[i] = mImage.createImage("/interface/pvp" + i.ToString() + ".png");
			}
		}
	}

	// Token: 0x060005F9 RID: 1529 RVA: 0x00089C4C File Offset: 0x00087E4C
	public void updateShowTime()
	{
		bool flag = Interface_Game.vecClanDam == null || Interface_Game.vecClanDam.size() == 0;
		if (!flag)
		{
			bool flag2 = GameCanvas.isPoint(MotherCanvas.w - 14, MotherCanvas.h / 2 - 35, 16, 40);
			if (flag2)
			{
				bool isPointerSelect = GameCanvas.isPointerSelect;
				if (isPointerSelect)
				{
					GameCanvas.isPointerSelect = false;
					this.isFocusTime = false;
					this.beginShow = true;
					this.isshowtime = true;
				}
				else
				{
					bool flag3 = GameCanvas.isPointerDown || GameCanvas.isPointerMove;
					if (flag3)
					{
						this.isFocusTime = true;
						this.timepointer = 3;
					}
				}
			}
			bool flag4 = (GameCanvas.isPointerClick || GameCanvas.isPointerDown) && this.xShow == 0;
			if (flag4)
			{
				this.beginShow = true;
				this.isshowtime = false;
			}
			bool flag5 = this.timepointer > 0;
			if (flag5)
			{
				this.timepointer--;
			}
			bool flag6 = this.beginShow;
			if (flag6)
			{
				bool flag7 = this.xShow == 0;
				if (flag7)
				{
					this.speedShow = 5;
				}
				bool flag8 = this.xShow == 75;
				if (flag8)
				{
					this.speedShow = -5;
				}
				this.xShow += this.speedShow;
				bool flag9 = this.xShow == 0 || this.xShow == 75;
				if (flag9)
				{
					this.beginShow = false;
				}
				bool flag10 = this.speedShow > 0 && this.xShow >= 75;
				if (flag10)
				{
					this.xShow = 75;
				}
				else
				{
					bool flag11 = this.speedShow < 0 && this.xShow <= 0;
					if (flag11)
					{
						this.xShow = 0;
					}
				}
			}
		}
	}

	// Token: 0x04000817 RID: 2071
	public const sbyte KEYPAD = 0;

	// Token: 0x04000818 RID: 2072
	public const sbyte TOUCH = 1;

	// Token: 0x04000819 RID: 2073
	public static mImage[] imgMove;

	// Token: 0x0400081A RID: 2074
	public static mImage[] imgFire;

	// Token: 0x0400081B RID: 2075
	public static mImage[] imgOther;

	// Token: 0x0400081C RID: 2076
	public static mImage[] mImgPvPType;

	// Token: 0x0400081D RID: 2077
	public static mImage[] mImgPvPNew;

	// Token: 0x0400081E RID: 2078
	public static mImage imgInfo;

	// Token: 0x0400081F RID: 2079
	public static mImage imgHoavan;

	// Token: 0x04000820 RID: 2080
	public static mImage imgIconMPHP;

	// Token: 0x04000821 RID: 2081
	public static mImage imgInfoServer;

	// Token: 0x04000822 RID: 2082
	public static mImage imgInfoNew;

	// Token: 0x04000823 RID: 2083
	public static mImage imgIconMPHP2;

	// Token: 0x04000824 RID: 2084
	public static mImage imgbgLoL;

	// Token: 0x04000825 RID: 2085
	public static mImage imgRankSkill;

	// Token: 0x04000826 RID: 2086
	public static mImage imgHoiSinhLoL;

	// Token: 0x04000827 RID: 2087
	public static mImage imgBorderWW;

	// Token: 0x04000828 RID: 2088
	public static mImage imgBorderNoti;

	// Token: 0x04000829 RID: 2089
	public static mImage imgBorderNoti2;

	// Token: 0x0400082A RID: 2090
	public static FrameImage fraBorderNoti;

	// Token: 0x0400082B RID: 2091
	public static FrameImage fraBorderNoti4;

	// Token: 0x0400082C RID: 2092
	public static int[][] mPosKillCur = mSystem.new_M_Int(6, 2);

	// Token: 0x0400082D RID: 2093
	public static int[][] mPosKillBuff = mSystem.new_M_Int(6, 2);

	// Token: 0x0400082E RID: 2094
	public static int[][] mPosKillSub = mSystem.new_M_Int(6, 2);

	// Token: 0x0400082F RID: 2095
	public static int[][] mPosMove = mSystem.new_M_Int(4, 2);

	// Token: 0x04000830 RID: 2096
	public static int[][] mPosOther = mSystem.new_M_Int(6, 2);

	// Token: 0x04000831 RID: 2097
	public static int[][] mSizeImgOther = mSystem.new_M_Int(6, 2);

	// Token: 0x04000832 RID: 2098
	public static int[][] mVChangTab = mSystem.new_M_Int(6, 2);

	// Token: 0x04000833 RID: 2099
	public static int[][] mPosEffCurrent = mSystem.new_M_Int(12, 2);

	// Token: 0x04000834 RID: 2100
	public int[] mKeyMove = new int[]
	{
		4,
		6,
		2,
		8
	};

	// Token: 0x04000835 RID: 2101
	private int[] mRotateMove = new int[]
	{
		2,
		0,
		3,
		1
	};

	// Token: 0x04000836 RID: 2102
	public static int[] mValueHotKey = new int[]
	{
		1,
		3,
		5,
		7,
		9,
		0
	};

	// Token: 0x04000837 RID: 2103
	public static short[][] mValueLoL = new short[][]
	{
		new short[]
		{
			1,
			1
		},
		new short[]
		{
			3,
			1
		},
		new short[]
		{
			1,
			1
		},
		new short[]
		{
			5,
			1
		},
		new short[]
		{
			0,
			1
		},
		new short[]
		{
			5,
			1
		},
		new short[]
		{
			2,
			1
		},
		new short[]
		{
			4,
			1
		},
		new short[]
		{
			2,
			1
		}
	};

	// Token: 0x04000838 RID: 2104
	public static int killLeft;

	// Token: 0x04000839 RID: 2105
	public static int truLeft;

	// Token: 0x0400083A RID: 2106
	public static int killRight;

	// Token: 0x0400083B RID: 2107
	public static int truRight;

	// Token: 0x0400083C RID: 2108
	public static int xPointMove;

	// Token: 0x0400083D RID: 2109
	public static int yPointMove;

	// Token: 0x0400083E RID: 2110
	public static int keyPoint;

	// Token: 0x0400083F RID: 2111
	public static int wArrowMove = 30;

	// Token: 0x04000840 RID: 2112
	public static int timePointer = 0;

	// Token: 0x04000841 RID: 2113
	private static int gocBegin = 285;

	// Token: 0x04000842 RID: 2114
	private static int lSkill = 50;

	// Token: 0x04000843 RID: 2115
	public static int xFocus;

	// Token: 0x04000844 RID: 2116
	public static int xBeginKill;

	// Token: 0x04000845 RID: 2117
	public static int yBeginKill;

	// Token: 0x04000846 RID: 2118
	public static int wSkill = 28;

	// Token: 0x04000847 RID: 2119
	public static int wMainSkill = 50;

	// Token: 0x04000848 RID: 2120
	public static int yInfoServer = 50;

	// Token: 0x04000849 RID: 2121
	public static int xInfoServer;

	// Token: 0x0400084A RID: 2122
	public static int hInfoServer;

	// Token: 0x0400084B RID: 2123
	public static int wInfoServer;

	// Token: 0x0400084C RID: 2124
	public static int xBeginCombo;

	// Token: 0x0400084D RID: 2125
	public static int yBeginCombo;

	// Token: 0x0400084E RID: 2126
	public static int xShowEffPvP;

	// Token: 0x0400084F RID: 2127
	public static int yShowEffPvP;

	// Token: 0x04000850 RID: 2128
	public static int xLoL;

	// Token: 0x04000851 RID: 2129
	public static int yLoL;

	// Token: 0x04000852 RID: 2130
	public static int yQuickChat;

	// Token: 0x04000853 RID: 2131
	private int timeMove;

	// Token: 0x04000854 RID: 2132
	private int timeChangeTab;

	// Token: 0x04000855 RID: 2133
	private int maxTimeChange;

	// Token: 0x04000856 RID: 2134
	public short[] posTam;

	// Token: 0x04000857 RID: 2135
	private int dirTam;

	// Token: 0x04000858 RID: 2136
	private bool isFocusTime;

	// Token: 0x04000859 RID: 2137
	private int timepointer;

	// Token: 0x0400085A RID: 2138
	public static bool isPaintInfoFocus;

	// Token: 0x0400085B RID: 2139
	public static sbyte typeTouch = 1;

	// Token: 0x0400085C RID: 2140
	public static sbyte typeShowPvP = -1;

	// Token: 0x0400085D RID: 2141
	public static sbyte tickShowPvP;

	// Token: 0x0400085E RID: 2142
	public static sbyte valueHoiSinhLOL;

	// Token: 0x0400085F RID: 2143
	public static sbyte typeTitleRoomFight = 0;

	// Token: 0x04000860 RID: 2144
	private static bool isMove = true;

	// Token: 0x04000861 RID: 2145
	public static mVector vecEffCurrent = new mVector("Interface.vecEffCurrent");

	// Token: 0x04000862 RID: 2146
	public static mVector vecEventShow = new mVector("Interface.vecEventShow");

	// Token: 0x04000863 RID: 2147
	public static mVector vecInfoServer = new mVector("Interface.vecInfoServer");

	// Token: 0x04000864 RID: 2148
	public static mVector vecQuickChatLoL = new mVector("Interface.vecQuickChatLoL");

	// Token: 0x04000865 RID: 2149
	public static int xMoveTo;

	// Token: 0x04000866 RID: 2150
	public static int yMoveto;

	// Token: 0x04000867 RID: 2151
	public static int timeMoveTo;

	// Token: 0x04000868 RID: 2152
	private int valueSmallScreen;

	// Token: 0x04000869 RID: 2153
	public static CountDownTicket watchMap = new CountDownTicket();

	// Token: 0x0400086A RID: 2154
	public static CountDownTicket watchRevice = new CountDownTicket();

	// Token: 0x0400086B RID: 2155
	public static bool isSmallInfoServer = false;

	// Token: 0x0400086C RID: 2156
	public static bool isPaintInfoServer = true;

	// Token: 0x0400086D RID: 2157
	public static FrameImage[] fraLol;

	// Token: 0x0400086E RID: 2158
	public static Item_Skill_Eff[] mCountKichAn;

	// Token: 0x0400086F RID: 2159
	public static short[][] mHardcodeSkill = new short[][]
	{
		new short[]
		{
			227
		},
		new short[]
		{
			228,
			229
		},
		new short[]
		{
			230,
			231
		},
		new short[]
		{
			232,
			234
		},
		new short[]
		{
			235,
			236
		},
		new short[]
		{
			237,
			238
		},
		new short[]
		{
			239,
			240
		},
		new short[]
		{
			241
		},
		new short[]
		{
			242
		},
		new short[]
		{
			243,
			244
		}
	};

	// Token: 0x04000870 RID: 2160
	public static string[] mCallSkill = new string[]
	{
		"Cau su",
		"Lửa",
		"Băng",
		"Khói",
		"Cát",
		"Sét",
		"Nham thạch",
		"Chim ưng",
		"Báo đóm",
		"Chấn thiên"
	};

	// Token: 0x04000871 RID: 2161
	public static int timePaintIconSkill = 0;

	// Token: 0x04000872 RID: 2162
	public static int wComboSkill = 17;

	// Token: 0x04000873 RID: 2163
	public static int timeCombo;

	// Token: 0x04000874 RID: 2164
	public static int indexEffCombo = -1;

	// Token: 0x04000875 RID: 2165
	public static int frameCombo;

	// Token: 0x04000876 RID: 2166
	public static int timeEndCombo;

	// Token: 0x04000877 RID: 2167
	public static bool isCombo = true;

	// Token: 0x04000878 RID: 2168
	private static bool isEffHP = false;

	// Token: 0x04000879 RID: 2169
	private static bool isEffMP = false;

	// Token: 0x0400087A RID: 2170
	private static int[] mcolorEffHp = new int[]
	{
		15411779,
		15615579,
		16673145,
		15411779
	};

	// Token: 0x0400087B RID: 2171
	private static int[] mcolorEffMp = new int[]
	{
		2794196,
		3127269,
		7064575,
		2794196
	};

	// Token: 0x0400087C RID: 2172
	public static sbyte maxWin = -1;

	// Token: 0x0400087D RID: 2173
	public static int wMoneyEff = 145;

	// Token: 0x0400087E RID: 2174
	public static int mini = 5;

	// Token: 0x0400087F RID: 2175
	public static int tickeffShowMoney = 0;

	// Token: 0x04000880 RID: 2176
	public static int yEffShowMoney;

	// Token: 0x04000881 RID: 2177
	public static int typeShowMoney;

	// Token: 0x04000882 RID: 2178
	private static int frameIconfocus = 0;

	// Token: 0x04000883 RID: 2179
	private static bool isNextFrame = true;

	// Token: 0x04000884 RID: 2180
	public static int[][] colorHPHeart = new int[][]
	{
		new int[]
		{
			13631520,
			5253670,
			13669790
		},
		new int[]
		{
			7186180,
			2439169,
			12508041
		},
		new int[]
		{
			11797622,
			5308981,
			13604283
		},
		new int[]
		{
			14646020,
			5582594,
			14469295
		},
		new int[]
		{
			7310769,
			140881,
			11584990
		},
		new int[]
		{
			217519,
			149793,
			10602161
		},
		new int[]
		{
			14725634,
			5589273,
			14472112
		},
		new int[]
		{
			307402,
			150873,
			11390932
		},
		new int[]
		{
			12518415,
			5046790,
			13610929
		},
		new int[]
		{
			3671496,
			1311304,
			11181773
		}
	};

	// Token: 0x04000885 RID: 2181
	public static int vEffHP = 0;

	// Token: 0x04000886 RID: 2182
	public static int vEffMP = 0;

	// Token: 0x04000887 RID: 2183
	private int tickCheckPoint;

	// Token: 0x04000888 RID: 2184
	private int xmovetam;

	// Token: 0x04000889 RID: 2185
	private int ymovetam;

	// Token: 0x0400088A RID: 2186
	private bool isFire;

	// Token: 0x0400088B RID: 2187
	public static int indexHardcodeSkill = 0;

	// Token: 0x0400088C RID: 2188
	private int indexsetClass;

	// Token: 0x0400088D RID: 2189
	private int indexsetSkill;

	// Token: 0x0400088E RID: 2190
	private short[] msetweapon = new short[]
	{
		-1,
		687,
		688,
		689,
		690
	};

	// Token: 0x0400088F RID: 2191
	private string[] msetSkillDevil = new string[]
	{
		"causu 1",
		"lửa 1",
		"lửa 2",
		"băng 1",
		"băng 2",
		"khói 1",
		"khói 2",
		"cát 1",
		"cát 2",
		"sét 1",
		"sét 2",
		"nham 1",
		"nham 2",
		"chim 1",
		"báo 1",
		"chấn thiên 1",
		"chấn thiên 2",
		"dao 1",
		"dao 2",
		"sáp 2",
		"sáp 1",
		"kilo 1"
	};

	// Token: 0x04000890 RID: 2192
	public static mVector vecfocus = new mVector("Interface.vecfocus");

	// Token: 0x04000891 RID: 2193
	private int minDisFocus = 40;

	// Token: 0x04000892 RID: 2194
	public static int hShowEvent = 0;

	// Token: 0x04000893 RID: 2195
	public static int timeShowEvent = 0;

	// Token: 0x04000894 RID: 2196
	public static int speedShowEvent = 6;

	// Token: 0x04000895 RID: 2197
	public static int maxTimePaint = 100;

	// Token: 0x04000896 RID: 2198
	public static InfoMemList eventcur = null;

	// Token: 0x04000897 RID: 2199
	public static InfoShowNotify infoFight = null;

	// Token: 0x04000898 RID: 2200
	public static InfoShowNotify infoNormal = null;

	// Token: 0x04000899 RID: 2201
	public static InfoShowNotify infoSpec = null;

	// Token: 0x0400089A RID: 2202
	public static InfoShowNotify infoPlayer = new InfoShowNotify(string.Empty, 10);

	// Token: 0x0400089B RID: 2203
	private static int wShowInfoPlayer = 0;

	// Token: 0x0400089C RID: 2204
	private static int lastTick_2 = 0;

	// Token: 0x0400089D RID: 2205
	private static int framepaint_2 = 0;

	// Token: 0x0400089E RID: 2206
	private static int yEffInfoPlayer = 0;

	// Token: 0x0400089F RID: 2207
	public static int xNumMess;

	// Token: 0x040008A0 RID: 2208
	public static int yNumMess;

	// Token: 0x040008A1 RID: 2209
	public static int xChat;

	// Token: 0x040008A2 RID: 2210
	public static int yChat;

	// Token: 0x040008A3 RID: 2211
	public static int xAutoFire;

	// Token: 0x040008A4 RID: 2212
	public static int yAutoFire;

	// Token: 0x040008A5 RID: 2213
	public static int xClan;

	// Token: 0x040008A6 RID: 2214
	public static int yClan;

	// Token: 0x040008A7 RID: 2215
	public static bool isAutoFireInterface = true;

	// Token: 0x040008A8 RID: 2216
	public static NumberMess numMess = new NumberMess();

	// Token: 0x040008A9 RID: 2217
	public static NumberMess numClan = new NumberMess();

	// Token: 0x040008AA RID: 2218
	public static int yShowNameMap = 0;

	// Token: 0x040008AB RID: 2219
	public static int speedShowNameMap = 0;

	// Token: 0x040008AC RID: 2220
	public static int timeShowNameMap;

	// Token: 0x040008AD RID: 2221
	public static int wtable;

	// Token: 0x040008AE RID: 2222
	public static int HPMap = -1;

	// Token: 0x040008AF RID: 2223
	public static int maxHPMap = -1;

	// Token: 0x040008B0 RID: 2224
	public static int wtable2 = 60;

	// Token: 0x040008B1 RID: 2225
	public static int hTextWatch = 20;

	// Token: 0x040008B2 RID: 2226
	public static string nameMap = string.Empty;

	// Token: 0x040008B3 RID: 2227
	public static int indexPaintTable = 0;

	// Token: 0x040008B4 RID: 2228
	public static int xShowNear;

	// Token: 0x040008B5 RID: 2229
	public static int speedShowNear;

	// Token: 0x040008B6 RID: 2230
	public static int timeShowNear = 0;

	// Token: 0x040008B7 RID: 2231
	public static mVector vecClanDam = new mVector("Interface.vecClanDam");

	// Token: 0x040008B8 RID: 2232
	public sbyte xShow = 75;

	// Token: 0x040008B9 RID: 2233
	public sbyte speedShow;

	// Token: 0x040008BA RID: 2234
	public bool beginShow;

	// Token: 0x040008BB RID: 2235
	private int lastTick;

	// Token: 0x040008BC RID: 2236
	private int framepaint;

	// Token: 0x040008BD RID: 2237
	public static int demShowEffPvP = 0;

	// Token: 0x040008BE RID: 2238
	public bool isshowtime;
}
