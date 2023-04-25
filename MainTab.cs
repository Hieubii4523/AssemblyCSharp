using System;

// Token: 0x02000088 RID: 136
public class MainTab : AvMain
{
	// Token: 0x06000895 RID: 2197 RVA: 0x000ACEC8 File Offset: 0x000AB0C8
	public MainTab()
	{
		bool flag = MotherCanvas.h >= 300 && GameCanvas.isTouch;
		if (flag)
		{
			this.isBigScreen = true;
		}
		MainTab.xMoney = MotherCanvas.w - 77;
		MainTab.yMoney = 4;
		this.miniItem = 5;
		this.wInfo = 100;
		this.hInfo = 40;
		this.wCur = MainTab.wTab - 70;
		this.hCur = MainTab.hTab - 32;
		this.xCurBegin = MainTab.xTab + MainTab.wTab / 2 - this.wCur / 2 + 10;
		this.yCurBegin = MainTab.yTab + 32;
		bool flag2 = MainTab.bigInfo > 0;
		if (flag2)
		{
			MainTab.limitTimeShow = 1;
		}
		else
		{
			MainTab.limitTimeShow = 15;
		}
	}

	// Token: 0x06000896 RID: 2198 RVA: 0x000ACFA0 File Offset: 0x000AB1A0
	public void createValue()
	{
		bool flag = this.isBigScreen;
		if (flag)
		{
			MainTab.hTab = 240;
			MainTab.wTab = 260;
		}
		bool flag2 = MainTab.wTab > MotherCanvas.w;
		if (flag2)
		{
			MainTab.wTab = MotherCanvas.w;
		}
		bool flag3 = MainTab.hTab > MotherCanvas.h - 55 - GameCanvas.hCommand;
		if (flag3)
		{
			MainTab.hTab = MotherCanvas.h - 55 - GameCanvas.hCommand;
		}
		bool isShortH = GameCanvas.isShortH;
		if (isShortH)
		{
			MainTab.hTab += 30;
		}
		MainTab.hItemTab = 28;
		bool flag4 = MainTab.hItemTab * 8 > MainTab.hTab;
		if (flag4)
		{
			MainTab.hItemTab = MainTab.hTab / 8;
		}
		bool isSmallScreen = GameCanvas.isSmallScreen;
		if (isSmallScreen)
		{
			MainTab.hItemTab = 16;
		}
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			bool flag5 = this.isBigScreen;
			if (flag5)
			{
				MainTab.wItem = 32;
				MainTab.hItemTab = 30;
			}
			else
			{
				MainTab.wItem = 28;
				MainTab.hItemTab = 28;
			}
			bool flag6 = MainTab.hItemTab * 6 > MainTab.hTab;
			if (flag6)
			{
				MainTab.hItemTab = MainTab.hTab / 6;
			}
		}
		else
		{
			bool isSmallScreen2 = GameCanvas.isSmallScreen;
			if (isSmallScreen2)
			{
				MainTab.wItem = 20;
			}
			else
			{
				MainTab.wItem = 24;
			}
		}
		MainTabShop.maxNumItemW = (MainTab.wTab - 60) / MainTab.wItem;
		bool flag7 = MainTabShop.maxNumItemW > 6;
		if (flag7)
		{
			MainTabShop.maxNumItemW = 6;
		}
		MainTabShop.maxNumItemH = (MainTab.hTab - this.miniItem * 2) / MainTab.wItem;
		bool flag8 = MainTabShop.maxNumItemH > 6;
		if (flag8)
		{
			MainTabShop.maxNumItemH = 6;
		}
		MainTab.xTab = MotherCanvas.hw - MainTab.wTab / 2;
		MainTab.yTab = MotherCanvas.hh + 25 - GameCanvas.hCommand / 2 - MainTab.hTab / 2;
		bool isShortH2 = GameCanvas.isShortH;
		if (isShortH2)
		{
			MainTab.yTab -= 15;
		}
	}

	// Token: 0x06000897 RID: 2199 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void resize(int max)
	{
	}

	// Token: 0x06000898 RID: 2200 RVA: 0x000AD18C File Offset: 0x000AB38C
	public virtual void beginFocus()
	{
		this.isShowInfo = false;
		bool flag = GameCanvas.isTouchNoOrPC();
		if (flag)
		{
			this.IdSelect = 0;
		}
		else
		{
			this.IdSelect = -1;
		}
	}

	// Token: 0x06000899 RID: 2201 RVA: 0x000092C6 File Offset: 0x000074C6
	public virtual void paint(mGraphics g, int xbegin)
	{
		base.paint(g);
	}

	// Token: 0x0600089A RID: 2202 RVA: 0x000092C6 File Offset: 0x000074C6
	public override void paint(mGraphics g)
	{
		base.paint(g);
	}

	// Token: 0x0600089B RID: 2203 RVA: 0x000090B5 File Offset: 0x000072B5
	public override void update()
	{
	}

	// Token: 0x0600089C RID: 2204 RVA: 0x000092D1 File Offset: 0x000074D1
	public override void updatekey()
	{
		base.updatekey();
	}

	// Token: 0x0600089D RID: 2205 RVA: 0x0000AEA3 File Offset: 0x000090A3
	public override void updatePointer()
	{
		base.updatePointer();
	}

	// Token: 0x0600089E RID: 2206 RVA: 0x000AD1C0 File Offset: 0x000AB3C0
	public void ShowInfo(mGraphics g, MainItem itemCur, mVector infoSS, sbyte typeborder, int x, int y, bool isLv, MainObject obj, int lvUpPlus)
	{
		MainTab.paintInfoEveryWhere(g, itemCur, infoSS, typeborder, x, y, this.wInfo, this.hInfo, isLv, obj, lvUpPlus);
	}

	// Token: 0x0600089F RID: 2207 RVA: 0x000AD1F0 File Offset: 0x000AB3F0
	public static void paintInfoEveryWhere(mGraphics g, MainItem itemCur, mVector infoSS, sbyte typeborder, int x, int y, int w, int h, bool isLv, MainObject obj, int lvUpPlus)
	{
		int num = w;
		int num2 = h;
		bool flag = itemCur != null;
		if (flag)
		{
			num = itemCur.wInfo;
			num2 = itemCur.hInfo - itemCur.hRunInfo;
			int hRunInfo = itemCur.hRunInfo;
			int num3 = 40;
			bool flag2 = itemCur.valueKickAn >= 0;
			if (flag2)
			{
				num3 = 100;
			}
			bool flag3 = hRunInfo > 0;
			if (flag3)
			{
				bool flag4 = MainTab.timeRun >= num3;
				if (flag4)
				{
					MainTab.xRun++;
				}
				else
				{
					bool flag5 = MainTab.timeRun >= 0;
					if (flag5)
					{
						MainTab.xRun = 0;
					}
				}
				bool flag6 = MainTab.xRun * 2 / 3 > hRunInfo + GameCanvas.hText / 2;
				if (flag6)
				{
					bool flag7 = MainTab.timeRun > 0;
					if (flag7)
					{
						MainTab.timeRun = -70;
					}
					else
					{
						bool flag8 = MainTab.timeRun >= -10;
						if (flag8)
						{
							MainTab.xRun = 0;
							MainTab.timeRun = 0;
						}
					}
				}
				MainTab.timeRun++;
			}
			else
			{
				MainTab.xRun = -1;
				MainTab.timeRun = 0;
			}
		}
		else
		{
			MainTab.xRun = -1;
			MainTab.timeRun = 0;
		}
		AvMain.paintRect(g, x - 2, y - 2, num + 4, num2 + 4, 1, 6);
		sbyte b = 0;
		int num4 = 0;
		bool flag9 = itemCur.typelock == 1;
		if (flag9)
		{
			num4 = 4;
			b = 1;
		}
		bool flag10 = itemCur.charClass >= 1 && itemCur.charClass <= 5;
		if (flag10)
		{
			bool flag11 = itemCur.typelock == 1;
			if (flag11)
			{
				num4 = 0;
				b = 2;
			}
			else
			{
				num4 = -4;
				b = 1;
			}
		}
		if (isLv)
		{
			AvMain.Font3dColor(g, string.Concat(new string[]
			{
				itemCur.namepaint,
				" ",
				T.Lv,
				".",
				itemCur.Lv_RQ.ToString()
			}), x + num / 2 + num4, y, 2, itemCur.colorName);
		}
		else
		{
			bool flag12 = (itemCur.isHoanMy == 1 && itemCur.valueKickAn >= 0) || itemCur.colorName == 9;
			if (flag12)
			{
				AvMain.FontSevenColor(g, itemCur.namepaint, x + num / 2 + num4, y, 2, 7);
			}
			else
			{
				AvMain.Font3dColor(g, itemCur.namepaint, x + num / 2 + num4, y, 2, itemCur.colorName);
			}
		}
		int num5 = 0;
		bool flag13 = b > 0;
		if (flag13)
		{
			num5 = mFont.tahoma_7b_white.getWidth(itemCur.namepaint);
			num4 = ((b != 2) ? CRes.abs(num4) : 8);
		}
		bool flag14 = itemCur.typelock == 1;
		if (flag14)
		{
			g.drawImage(AvMain.imgInfoLock, x + num / 2 - num5 / 2 - num4, y + 5, 3);
		}
		bool flag15 = itemCur.charClass >= 1 && itemCur.charClass <= 5;
		if (flag15)
		{
			g.drawRegion(AvMain.imgInfoClass, 0, (int)((itemCur.charClass - 1) * 15), 15, 15, 0, (float)(x + num / 2 + num5 / 2 + num4), (float)(y + 5), 3);
		}
		int num6 = num2;
		bool flag16 = typeborder == 1;
		int num7;
		if (flag16)
		{
			num7 = y + MainTab.wItem;
			num6 -= MainTab.wItem;
		}
		else
		{
			num7 = y + GameCanvas.hText;
			num6 -= GameCanvas.hText;
		}
		bool flag17 = itemCur.isHoanMy == 1;
		if (flag17)
		{
			g.drawImage(AvMain.imgInfoStar, x + num / 2, num7 + 4, 3);
			num7 += 14;
			num6 -= 14;
		}
		bool flag18 = itemCur.mDaKham != null && itemCur.numLoKham > 0;
		if (flag18)
		{
			int num8 = (int)((itemCur.numLoKham - 1) * 22 / 2);
			for (int i = 0; i < (int)itemCur.numLoKham; i++)
			{
				bool flag19 = i >= (int)(itemCur.numLoKham - itemCur.numHoleDaDuc);
				if (flag19)
				{
					g.drawRegion(AvMain.imgDaKham, 0, 20, 20, 20, 0, (float)(x + num / 2 + i * 22 - num8), (float)(num7 + 10), 3);
				}
				else
				{
					g.drawRegion(AvMain.imgDaKham, 0, 0, 20, 20, 0, (float)(x + num / 2 + i * 22 - num8), (float)(num7 + 10), 3);
				}
				bool flag20 = itemCur.mDaKham != null && i <= itemCur.mDaKham.Length - 1;
				if (flag20)
				{
					Potion templatePotion = Potion.getTemplatePotion(itemCur.mDaKham[i]);
					bool isUpdateTem = templatePotion.isUpdateTem;
					if (isUpdateTem)
					{
						templatePotion.paint(g, x + num / 2 + i * 22 - num8, num7 + 10, 20);
					}
				}
			}
			num7 += 24;
			num6 -= 22;
		}
		bool flag21 = MainTab.xRun >= 0;
		if (flag21)
		{
			g.setClip(x, num7 - 2, num, num6);
			g.saveCanvas();
			g.ClipRec(x, num7 - 2, num, num6);
			g.translate(0, -(MainTab.xRun * 2 / 3));
		}
		for (int j = 0; j < itemCur.vecInfo.size(); j++)
		{
			infoShow infoShow = (infoShow)itemCur.vecInfo.elementAt(j);
			int num9 = 0;
			bool flag22 = itemCur.valueKickAn > 0 && j == 0;
			if (flag22)
			{
				MainImage imageAll = ObjectData.getImageAll((short)((int)itemCur.valueKickAn + 400), ObjectData.hashImageSkillSmall, 4500);
				bool flag23 = imageAll != null && imageAll.img != null;
				if (flag23)
				{
					g.drawImage(imageAll.img, x + 6, num7 + 5, 3);
					num9 = 12;
				}
			}
			bool flag24 = itemCur.typeObject == 105 && itemCur.LvUpgrade > 0 && j == itemCur.vecInfo.size() - 2;
			if (flag24)
			{
				AvMain.setTextColor(5).drawString(g, infoShow.getInfoFormID(), x + num9 + 4, num7, 0);
			}
			else
			{
				bool flag25 = infoShow.colorMain >= infoShow.HARDCODE_CHECK_FULLSET_1;
				if (flag25)
				{
					bool flag26 = obj != null && obj.indexFullSet + 100 >= infoShow.colorMain;
					if (flag26)
					{
						AvMain.setTextColor(1).drawString(g, infoShow.getInfoFormID(), x + num9 + 4, num7, 0);
					}
					else
					{
						AvMain.setTextColor((int)infoShow.color).drawString(g, infoShow.getInfoFormID(), x + num9 + 4, num7, 0);
					}
				}
				else
				{
					bool flag27 = infoShow.colorMain == infoShow.HARDCODE_PAINT_CENTER;
					if (flag27)
					{
						AvMain.setTextColor((int)infoShow.color).drawString(g, infoShow.getInfoFormID(), x + num9 + num / 2, num7, 2);
					}
					else
					{
						bool flag28 = infoShow.colorMain == infoShow.HARDCODE_PAINT_CENTER_CHI_SO;
						if (flag28)
						{
							int num10 = 0;
							bool flag29 = lvUpPlus > 0;
							if (flag29)
							{
								num10 = lvUpPlus;
							}
							else
							{
								bool flag30 = itemCur != null;
								if (flag30)
								{
									num10 = (int)itemCur.LvUpgrade;
								}
							}
							AvMain.setTextColor((int)infoShow.color).drawString(g, infoShow.getInfoFormID() + "+" + num10.ToString() + " ---", x + num9 + num / 2, num7, 2);
						}
						else
						{
							bool flag31 = infoShow.colorMain == infoShow.HARDCODE_INFO_CO_BAN;
							if (flag31)
							{
								int valueLvUp = 0;
								bool flag32 = lvUpPlus > 0;
								if (flag32)
								{
									valueLvUp = lvUpPlus;
								}
								else
								{
									bool flag33 = itemCur != null;
									if (flag33)
									{
										valueLvUp = (int)itemCur.LvUpgrade;
									}
								}
								string text = string.Empty;
								text = ((infoShow.id >= 0) ? MainItem.getInfoAttriSS((short)infoShow.id, infoShow.value, valueLvUp, (int)itemCur.LvUpgrade) : infoShow.strShow);
								AvMain.setTextColor((int)infoShow.color).drawString(g, text, x + num9 + 4, num7, 0);
								bool flag34 = infoSS != null && j < infoSS.size();
								if (flag34)
								{
									infoShow infoShow2 = (infoShow)infoSS.elementAt(j);
									int num11 = AvMain.setTextColor(6).getWidth(text) + 7;
									AvMain.setTextColor((int)infoShow2.color).drawString(g, infoShow2.strShow, x + num11, num7, 0);
								}
							}
							else
							{
								AvMain.setTextColor((int)infoShow.color).drawString(g, infoShow.getInfoFormID(), x + num9 + 4, num7, 0);
							}
						}
					}
				}
			}
			num7 += GameCanvas.hText;
		}
		bool flag35 = MainTab.xRun >= 0;
		if (flag35)
		{
			mGraphics.resetTransAndroid(g);
			g.restoreCanvas();
			GameCanvas.resetTrans(g);
		}
	}

	// Token: 0x060008A0 RID: 2208 RVA: 0x000090B5 File Offset: 0x000072B5
	public void setWHin()
	{
	}

	// Token: 0x060008A1 RID: 2209 RVA: 0x000ADA78 File Offset: 0x000ABC78
	public static void paintBgTab(mGraphics g, int xpaint, bool isClan, sbyte typePaper)
	{
		MainTab.paintInfo_Money_Player(g, isClan);
		bool flag = typePaper == 0;
		if (flag)
		{
			MainTab.paintPaperTab(g, xpaint, MainTab.yTab, MainTab.wTab, MainTab.hTab);
		}
		else
		{
			AvMain.paintBG_AChi(g, xpaint, MainTab.yTab, MainTab.wTab, MainTab.hTab, 0);
		}
	}

	// Token: 0x060008A2 RID: 2210 RVA: 0x000ADACC File Offset: 0x000ABCCC
	private static void paintInfo_Money_Player(mGraphics g, bool isClan)
	{
		bool flag = GameCanvas.isShortH && MainTabShop.instance.typeNPCShop != 118;
		if (flag)
		{
			Interface_Game.paintInfoPlayer_Short(g, MotherCanvas.hw - 160, 3 + GameScreen.h12plus, true, mFont.tahoma_7_black);
		}
		else
		{
			Interface_Game.paintInfoPlayer(g, 3, 3 + GameScreen.h12plus, true, mFont.tahoma_7_black);
			MainTab.paintMoney(g, MotherCanvas.w - 78, 4 + GameScreen.h12plus, isClan);
		}
	}

	// Token: 0x060008A3 RID: 2211 RVA: 0x000ADB48 File Offset: 0x000ABD48
	public static void paintPaperTab(mGraphics g, int x, int y, int w, int h)
	{
		g.setColor(MainTab.COLOR_NEN);
		g.fillRect(x + 9, y, w - 18, h);
		for (int i = 0; i < h - 39; i += 40)
		{
			g.drawRegion(MainTab.mImgTab[0], 0, 0, 20, 40, 2, (float)x, (float)(y + i), 0);
			g.drawImage(MainTab.mImgTab[0], x + w, y + i, mGraphics.RIGHT | mGraphics.TOP);
		}
		bool flag = h % 40 != 0;
		if (flag)
		{
			g.drawRegion(MainTab.mImgTab[0], 0, 0, 20, h % 40, 2, (float)x, (float)(y + h - h % 40), 0);
			g.drawRegion(MainTab.mImgTab[0], 0, 0, 20, h % 40, 0, (float)(x + w), (float)(y + h - h % 40), mGraphics.RIGHT | mGraphics.TOP);
		}
		g.setColor(MainTab.COLOR_BORDER);
		g.fillRect(x + 9, y - 1, w - 18, 1);
		g.fillRect(x + 9, y + h, w - 18, 1);
		g.drawRegion(MainTab.mImgTab[1], 0, 0, 9, 3, 3, (float)x, (float)(y - 3), 0);
		g.drawRegion(MainTab.mImgTab[1], 0, 0, 9, 3, 1, (float)(x + w), (float)(y - 3), mGraphics.RIGHT | mGraphics.TOP);
		g.drawRegion(MainTab.mImgTab[1], 0, 0, 9, 3, 2, (float)x, (float)(y + h), 0);
		g.drawRegion(MainTab.mImgTab[1], 0, 0, 9, 3, 0, (float)(x + w), (float)(y + h), mGraphics.RIGHT | mGraphics.TOP);
	}

	// Token: 0x060008A4 RID: 2212 RVA: 0x000ADCE8 File Offset: 0x000ABEE8
	public static void paintListTab(mGraphics g, int xpaint, mVector vec, int idSelect)
	{
		int num = xpaint + 22;
		int num2 = MainTab.yTab + 36;
		bool flag = num2 + vec.size() * MainTab.hItemTab > MainTab.yTab + MainTab.hTab + MainTab.hItemTab / 2;
		if (flag)
		{
			num2 = MainTab.yTab + MainTab.hTab / 2 - vec.size() * MainTab.hItemTab / 2 + MainTab.hItemTab / 2;
		}
		int num3 = 0;
		g.setColor(14203529);
		bool flag2 = GameCanvas.currentScreen.setCurTypetab(1);
		if (flag2)
		{
			g.setColor(15972174);
		}
		g.fillRoundRect(num + (MainTab.wTab - 22) / 2 - MainTab.wTab / 4 * 3 / 2 + num3, MainTab.yTab + 7, MainTab.wTab / 4 * 3 - num3, 16, 4, 4);
		bool flag3 = vec == null;
		if (!flag3)
		{
			for (int i = 0; i < vec.size(); i++)
			{
				MainTab mainTab = (MainTab)vec.elementAt(i);
				short id = (short)(200 + (int)mainTab.indexIconTab);
				bool isSmallScreen = GameCanvas.isSmallScreen;
				if (isSmallScreen)
				{
					id = (short)(260 + (int)mainTab.indexIconTab);
				}
				MainImage imageAll = ObjectData.getImageAll(id, ObjectData.hashImageItemOther, 9000);
				bool flag4 = imageAll != null && imageAll.img != null;
				if (flag4)
				{
					g.drawImage(imageAll.img, num, num2 + i * MainTab.hItemTab, 3);
				}
				bool flag5 = idSelect == i;
				if (flag5)
				{
					bool flag6 = GameCanvas.currentScreen.setCurTypetab(1) || MainTab.timenhapnhay % 16 < 7;
					if (flag6)
					{
						MainImage imageAll2 = ObjectData.getImageAll((short)(230 + (int)mainTab.indexIconTab), ObjectData.hashImageItemOther, 9000);
						bool flag7 = imageAll2 != null && imageAll2.img != null;
						if (flag7)
						{
							g.drawImage(imageAll2.img, num, num2 + i * MainTab.hItemTab, 3);
						}
					}
					bool flag8 = mainTab.indexIconTab != 2;
					if (flag8)
					{
						bool flag9 = GameCanvas.currentScreen.setCurTypetab(1);
						if (flag9)
						{
							AvMain.FontBorderColor(g, mainTab.nameTab, num + (MainTab.wTab - 22) / 2, MainTab.yTab + 9, 2, 6, 5);
						}
						else
						{
							mFont.tahoma_7b_black.drawString(g, mainTab.nameTab, num + (MainTab.wTab - 22) / 2, MainTab.yTab + 9, 2);
						}
					}
				}
				bool flag10 = ((mainTab.indexIconTab == 2 && Player.pointAttribute > 0) || (mainTab.indexIconTab == 3 && Player.isSkillready) || (mainTab.indexIconTab == 4 && TabQuest.isNewQuest) || (mainTab.indexIconTab == 6 && GameScreen.numMess > 0)) && GameCanvas.gameTick % 10 < 8;
				if (flag10)
				{
					g.drawImage(MainEvent.imgNew, num + 10, num2 - 10 + i * MainTab.hItemTab, 3);
				}
			}
		}
	}

	// Token: 0x060008A5 RID: 2213 RVA: 0x000ADFE4 File Offset: 0x000AC1E4
	public static void paintMoney(mGraphics g, int x, int y, bool isClan)
	{
		AvMain.paintRect(g, x, y, 74, 54, 1, 2);
		g.setColor(8086346);
		AvMain.fraMoney.drawFrame(0, x + 13, y + 7, 0, 3, g);
		if (isClan)
		{
			bool flag = GameScreen.player.clan != null;
			if (flag)
			{
				mFont.tahoma_7_yellow.drawString(g, AvMain.getDotNumber((long)GameScreen.player.clan.beryClan), x + 20, y + 2, 0);
			}
		}
		else
		{
			mFont.tahoma_7_yellow.drawString(g, AvMain.getDotNumber(Player.beliTest), x + 20, y + 2, 0);
		}
		int num = y + 13;
		g.fillRect(x + 5, num, 64, 1);
		AvMain.fraMoney.drawFrame(1, x + 13, num + 7, 0, 3, g);
		if (isClan)
		{
			bool flag2 = GameScreen.player.clan != null;
			if (flag2)
			{
				mFont.tahoma_7_yellow.drawString(g, AvMain.getDotNumber((long)GameScreen.player.clan.rubiClan), x + 20, num + 2, 0);
			}
		}
		else
		{
			mFont.tahoma_7_red.drawString(g, AvMain.getDotNumber((long)GameScreen.player.gem), x + 20, num + 2, 0);
		}
		num += 13;
		g.fillRect(x + 5, num, 64, 1);
		bool flag3 = !isClan;
		if (flag3)
		{
			AvMain.fraMoney.drawFrame(7, x + 12, num + 7, 0, 3, g);
			mFont.tahoma_7_green.drawString(g, AvMain.getDotNumber((long)GameScreen.player.vnd), x + 20, num + 2, 0);
			num += 13;
			g.fillRect(x + 5, num, 64, 1);
			AvMain.fraMoney.drawFrame(9, x + 12, num + 7, 0, 3, g);
			mFont.tahoma_7_yellow.drawString(g, AvMain.getDotNumber((long)GameScreen.player.diemNap), x + 20, num + 2, 0);
		}
	}

	// Token: 0x060008A6 RID: 2214 RVA: 0x000AE1CC File Offset: 0x000AC3CC
	public static void paintMoney(mGraphics g, int x, int y)
	{
		AvMain.paintRect(g, x, y, 74, 54, 1, 2);
		g.setColor(8086346);
		AvMain.fraMoney.drawFrame(0, x + 13, y + 7, 0, 3, g);
		mFont.tahoma_7_yellow.drawString(g, AvMain.getDotNumber(Player.beliTest), x + 20, y + 2, 0);
		int num = y + 13;
		g.fillRect(x + 5, num, 64, 1);
		AvMain.fraMoney.drawFrame(1, x + 13, num + 7, 0, 3, g);
		mFont.tahoma_7_red.drawString(g, AvMain.getDotNumber((long)GameScreen.player.gem), x + 20, num + 2, 0);
		num += 13;
		g.fillRect(x + 5, num, 64, 1);
		AvMain.fraMoney.drawFrame(7, x + 12, num + 7, 0, 3, g);
		mFont.tahoma_7_green.drawString(g, AvMain.getDotNumber((long)GameScreen.player.vnd), x + 20, num + 2, 0);
		num += 13;
		g.fillRect(x + 5, num, 64, 1);
		AvMain.fraMoney.drawFrame(8, x + 12, num + 7, 0, 3, g);
		mFont.tahoma_7_orange.drawString(g, AvMain.getDotNumber((long)GameScreen.player.bua), x + 20, num + 2, 0);
	}

	// Token: 0x060008A7 RID: 2215 RVA: 0x0000AEAD File Offset: 0x000090AD
	public static void updateTimeCountDownTicket()
	{
		MainTab.valuephantram = GameCanvas.gameTick % 120;
		MainTab.CDTicket.updateTimeCountDownTicket();
		MainTab.CDPvP.updateTimeCountDownTicket();
		MainTab.CDKeyBoss.updateTimeCountDownTicket();
		MainTab.CDx2XP.updateTimeCountDownTicket();
	}

	// Token: 0x060008A8 RID: 2216 RVA: 0x000AE314 File Offset: 0x000AC514
	public virtual void updateShowInfo()
	{
		bool flag = !this.isShowInfo;
		if (flag)
		{
			this.timeShowInfo += 1;
			bool flag2 = this.timeShowInfo >= MainTab.limitTimeShow;
			if (flag2)
			{
				this.isShowInfo = true;
				this.setPosInfo();
			}
		}
		else
		{
			this.timeShowInfo = 0;
		}
	}

	// Token: 0x060008A9 RID: 2217 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void setPosInfo()
	{
	}

	// Token: 0x060008AA RID: 2218 RVA: 0x000AE370 File Offset: 0x000AC570
	public virtual void setPosInfo(MainItem item, int xbe, int ybe)
	{
		int num = this.wInfo;
		int num2 = this.hInfo;
		bool flag = item != null;
		if (flag)
		{
			num = item.wInfo;
			num2 = item.hInfo - item.hRunInfo;
		}
		this.xInfo = xbe - num / 2;
		bool flag2 = this.xInfo + num > MotherCanvas.w - 4;
		if (flag2)
		{
			this.xInfo = MotherCanvas.w - num - 4;
		}
		bool flag3 = this.xInfo < 8;
		if (flag3)
		{
			this.xInfo = 8;
		}
		this.yInfo = ybe;
		bool flag4 = this.yInfo < MainTab.yTab + GameCanvas.hCommand;
		if (flag4)
		{
			this.yInfo = MainTab.yTab + GameCanvas.hCommand;
		}
		bool flag5 = this.yInfo + num2 > MotherCanvas.h - GameCanvas.hCommand - 8;
		if (flag5)
		{
			this.yInfo = MotherCanvas.h - GameCanvas.hCommand - num2 - 8;
		}
	}

	// Token: 0x060008AB RID: 2219 RVA: 0x000AE45C File Offset: 0x000AC65C
	public void endFocusInfo()
	{
		bool flag = GameCanvas.currentScreen == GameCanvas.tabAllScr;
		if (flag)
		{
			GameCanvas.tabAllScr.endInfoTab();
		}
	}

	// Token: 0x060008AC RID: 2220 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void updateInfo()
	{
	}

	// Token: 0x060008AD RID: 2221 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void updateBuyItem(short id, sbyte type)
	{
	}

	// Token: 0x060008AE RID: 2222 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void updateTrangBi()
	{
	}

	// Token: 0x060008AF RID: 2223 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void updateChangeTabInfo()
	{
	}

	// Token: 0x060008B0 RID: 2224 RVA: 0x000A5D98 File Offset: 0x000A3F98
	public virtual iCommand setCmdEndInfo()
	{
		return null;
	}

	// Token: 0x060008B1 RID: 2225 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void setData(mVector vec)
	{
	}

	// Token: 0x04000D79 RID: 3449
	public new const sbyte PAPER_NORMAL = 0;

	// Token: 0x04000D7A RID: 3450
	public const sbyte PAPER_MARKET = 1;

	// Token: 0x04000D7B RID: 3451
	public string nameTab;

	// Token: 0x04000D7C RID: 3452
	public int IdSelect;

	// Token: 0x04000D7D RID: 3453
	public sbyte indexIconTab;

	// Token: 0x04000D7E RID: 3454
	public int maxSize;

	// Token: 0x04000D7F RID: 3455
	public static int wItem;

	// Token: 0x04000D80 RID: 3456
	public static int xTab;

	// Token: 0x04000D81 RID: 3457
	public static int wTab = 225;

	// Token: 0x04000D82 RID: 3458
	public static int hTab = 194;

	// Token: 0x04000D83 RID: 3459
	public static int yTab;

	// Token: 0x04000D84 RID: 3460
	public static int hItemTab;

	// Token: 0x04000D85 RID: 3461
	public static int bigInfo = 0;

	// Token: 0x04000D86 RID: 3462
	public static int maxTypeTab = 9;

	// Token: 0x04000D87 RID: 3463
	public int wInfo;

	// Token: 0x04000D88 RID: 3464
	public int hInfo;

	// Token: 0x04000D89 RID: 3465
	public int xInfo;

	// Token: 0x04000D8A RID: 3466
	public int yInfo;

	// Token: 0x04000D8B RID: 3467
	public int wItemCur;

	// Token: 0x04000D8C RID: 3468
	public int xCurBegin;

	// Token: 0x04000D8D RID: 3469
	public int yCurBegin;

	// Token: 0x04000D8E RID: 3470
	public int wCur;

	// Token: 0x04000D8F RID: 3471
	public int hCur;

	// Token: 0x04000D90 RID: 3472
	public int miniItem;

	// Token: 0x04000D91 RID: 3473
	public int levelTab;

	// Token: 0x04000D92 RID: 3474
	public sbyte indexMarket = -1;

	// Token: 0x04000D93 RID: 3475
	public bool isShowInfo = true;

	// Token: 0x04000D94 RID: 3476
	public bool isBigScreen;

	// Token: 0x04000D95 RID: 3477
	public sbyte timeShowInfo;

	// Token: 0x04000D96 RID: 3478
	public static sbyte limitTimeShow = 0;

	// Token: 0x04000D97 RID: 3479
	public static int xMoney;

	// Token: 0x04000D98 RID: 3480
	public static int yMoney;

	// Token: 0x04000D99 RID: 3481
	public static mImage[] mImgTab;

	// Token: 0x04000D9A RID: 3482
	public static FrameImage fraCloseTab;

	// Token: 0x04000D9B RID: 3483
	public static FrameImage fraCloseTab2;

	// Token: 0x04000D9C RID: 3484
	public static FrameImage fraCmdMo;

	// Token: 0x04000D9D RID: 3485
	public static FrameImage fraCloseTab3;

	// Token: 0x04000D9E RID: 3486
	public static CountDownTicket CDTicket = new CountDownTicket();

	// Token: 0x04000D9F RID: 3487
	public static CountDownTicket CDPvP = new CountDownTicket();

	// Token: 0x04000DA0 RID: 3488
	public static CountDownTicket CDKeyBoss = new CountDownTicket();

	// Token: 0x04000DA1 RID: 3489
	public static CountDownTicket CDx2XP = new CountDownTicket();

	// Token: 0x04000DA2 RID: 3490
	public static CountDownTicket CDDonateClan = new CountDownTicket();

	// Token: 0x04000DA3 RID: 3491
	public static int xRun = -1;

	// Token: 0x04000DA4 RID: 3492
	public static int timeRun;

	// Token: 0x04000DA5 RID: 3493
	public static int COLOR_BORDER = 6967601;

	// Token: 0x04000DA6 RID: 3494
	public static int COLOR_NEN = 16377262;

	// Token: 0x04000DA7 RID: 3495
	public static int timenhapnhay = 0;

	// Token: 0x04000DA8 RID: 3496
	public static int valuephantram = 0;
}
