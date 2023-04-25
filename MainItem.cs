using System;

// Token: 0x0200007D RID: 125
public class MainItem
{
	// Token: 0x06000746 RID: 1862 RVA: 0x0009CA78 File Offset: 0x0009AC78
	public MainItem()
	{
	}

	// Token: 0x06000747 RID: 1863 RVA: 0x0009CAEC File Offset: 0x0009ACEC
	public MainItem(sbyte type, short idIcon, short id, int num)
	{
		this.typeObject = type;
		this.idIcon = idIcon;
		this.ID = id;
		this.numInt = num;
		this.numPotion = 0;
	}

	// Token: 0x06000748 RID: 1864 RVA: 0x0009CB84 File Offset: 0x0009AD84
	public MainItem(sbyte type, short IdIcon, short ID)
	{
		this.typeObject = type;
		this.idIcon = IdIcon;
		this.ID = ID;
		this.numPotion = 0;
	}

	// Token: 0x06000749 RID: 1865 RVA: 0x0009CC14 File Offset: 0x0009AE14
	public MainItem(sbyte typeItem, short ID, short idIcon, string name, sbyte isTrade)
	{
		this.typeObject = typeItem;
		this.ID = ID;
		this.idIcon = idIcon;
		this.name = name;
		this.isTrade = isTrade;
		this.namepaint = name;
	}

	// Token: 0x0600074A RID: 1866 RVA: 0x0009CCB4 File Offset: 0x0009AEB4
	public MainItem(sbyte typeItem, short ID, short idIcon, short num, sbyte color, sbyte lvUp)
	{
		this.typeObject = typeItem;
		this.ID = ID;
		this.idIcon = idIcon;
		this.numPotion = num;
		this.colorName = color;
		this.LvUpgrade = lvUp;
		bool flag = this.LvUpgrade > 0;
		if (flag)
		{
			this.namepaint = this.name + " +" + this.LvUpgrade.ToString();
		}
		else
		{
			this.namepaint = this.name;
		}
	}

	// Token: 0x0600074B RID: 1867 RVA: 0x0009CD94 File Offset: 0x0009AF94
	public void setInfoPotion(string info)
	{
		bool flag = info.Length != 0;
		if (flag)
		{
			string[] array = mFont.tahoma_7_white.splitFontArray(info, this.wInfo);
			for (int i = 0; i < array.Length; i++)
			{
				this.addInfo(array[i], 0);
			}
			bool flag2 = !this.isShop || this.numPotion > 1;
			if (flag2)
			{
				this.addInfo(T.soluong + ": " + this.numPotion.ToString(), 0);
			}
		}
	}

	// Token: 0x0600074C RID: 1868 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void setInfoItem(MainInfoItem[] mInfoItem)
	{
	}

	// Token: 0x0600074D RID: 1869 RVA: 0x0009CE24 File Offset: 0x0009B024
	public void addInfoSell(short id, int value)
	{
		string text = MainItem.mNameAttributes[(int)id].name + " ";
		text = text + MainItem.strGetPercent(value, MainItem.mNameAttributes[(int)id].ispercent) + " + ?";
		int num = mFont.tahoma_7_black.getWidth(text) + 10;
		bool flag = num > this.wInfo;
		if (flag)
		{
			this.wInfo = num;
		}
		this.vecInfo.addElement(new infoShow((int)id, value, MainItem.mNameAttributes[(int)id].color, -1));
		this.updateHInfo();
	}

	// Token: 0x0600074E RID: 1870 RVA: 0x0009CEB4 File Offset: 0x0009B0B4
	public static string getInfoAttriSS(short id, int value, int valueLvUp, int valueLvCur)
	{
		string str = MainItem.mNameAttributes[(int)id].name + " ";
		int num = MainItem.valueSameUpgrade(value, valueLvCur, valueLvUp);
		return str + MainItem.strGetPercent(num, MainItem.mNameAttributes[(int)id].ispercent);
	}

	// Token: 0x0600074F RID: 1871 RVA: 0x0009CF00 File Offset: 0x0009B100
	public void addInfo(short id, int value, sbyte colorMain)
	{
		string text = MainItem.mNameAttributes[(int)id].name + " ";
		text += MainItem.strGetPercent(value, MainItem.mNameAttributes[(int)id].ispercent);
		int num = mFont.tahoma_7b_black.getWidth(text) + 4;
		bool flag = this.typelock == 1;
		if (flag)
		{
			num += 12;
		}
		bool flag2 = this.charClass >= 1;
		if (flag2)
		{
			num += 12;
		}
		bool flag3 = this.LvUpgrade > 0;
		if (flag3)
		{
			num += 16;
		}
		bool flag4 = num > this.wInfo;
		if (flag4)
		{
			this.wInfo = num;
		}
		sbyte color = MainItem.mNameAttributes[(int)id].color;
		bool flag5 = colorMain >= 0 && colorMain <= 8;
		if (flag5)
		{
			color = colorMain;
		}
		this.vecInfo.addElement(new infoShow((int)id, value, color, colorMain));
		this.updateHInfo();
	}

	// Token: 0x06000750 RID: 1872 RVA: 0x0009CFE8 File Offset: 0x0009B1E8
	public void addInfo(short id, int value, sbyte colorMain, sbyte percent)
	{
		string text = MainItem.mNameAttributes[(int)id].name + " ";
		text = ((percent == -1) ? (text + MainItem.strGetPercent(value, MainItem.mNameAttributes[(int)id].ispercent)) : (text + MainItem.strGetPercent(value, percent)));
		int num = mFont.tahoma_7b_black.getWidth(text) + 4;
		bool flag = this.typelock == 1;
		if (flag)
		{
			num += 12;
		}
		bool flag2 = this.charClass >= 1;
		if (flag2)
		{
			num += 12;
		}
		bool flag3 = this.LvUpgrade > 0;
		if (flag3)
		{
			num += 16;
		}
		bool flag4 = num > this.wInfo;
		if (flag4)
		{
			this.wInfo = num;
		}
		sbyte color = MainItem.mNameAttributes[(int)id].color;
		bool flag5 = colorMain >= 0 && colorMain <= 8;
		if (flag5)
		{
			color = colorMain;
		}
		this.vecInfo.addElement(new infoShow((int)id, value, color, colorMain));
		this.updateHInfo();
	}

	// Token: 0x06000751 RID: 1873 RVA: 0x0000AA88 File Offset: 0x00008C88
	public virtual void addInfo(string str, sbyte color)
	{
		this.vecInfo.addElement(new infoShow(-1, 0, str, color, -1));
		this.updateHInfo();
	}

	// Token: 0x06000752 RID: 1874 RVA: 0x0000AAA8 File Offset: 0x00008CA8
	public virtual void addInfo(string str, sbyte color, sbyte colorMain)
	{
		this.vecInfo.addElement(new infoShow(-1, 0, str, color, colorMain));
		this.updateHInfo();
	}

	// Token: 0x06000753 RID: 1875 RVA: 0x0000AAC8 File Offset: 0x00008CC8
	public void addInfoFrist(string str, sbyte color)
	{
		this.vecInfo.insertElementAt(new infoShow(-1, 0, str, color, -1), 0);
		this.updateHInfo();
	}

	// Token: 0x06000754 RID: 1876 RVA: 0x0009D0E8 File Offset: 0x0009B2E8
	public void updateHInfo()
	{
		this.hInfo = (this.vecInfo.size() + 1) * GameCanvas.hText;
		bool flag = this.numLoKham > 0;
		if (flag)
		{
			this.hInfo += 22;
		}
		bool flag2 = this.isHoanMy == 1;
		if (flag2)
		{
			this.hInfo += 14;
		}
		bool flag3 = this.hInfo > MainTab.hTab - GameCanvas.hCommand * 3 / 2;
		if (flag3)
		{
			this.hRunInfo = this.hInfo - (MainTab.hTab - GameCanvas.hCommand * 3 / 2);
		}
		else
		{
			this.hRunInfo = 0;
		}
	}

	// Token: 0x06000755 RID: 1877 RVA: 0x0009D190 File Offset: 0x0009B390
	public static string strGetPercent(int value, sbyte isPer)
	{
		string text = string.Empty;
		bool flag = isPer == 0;
		if (flag)
		{
			text += value.ToString();
		}
		else
		{
			bool flag2 = isPer == 1;
			if (flag2)
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					(value / 10).ToString(),
					",",
					(CRes.abs(value) % 10).ToString(),
					"%"
				});
			}
			else
			{
				bool flag3 = isPer == 2;
				if (flag3)
				{
					string text3 = text;
					text = string.Concat(new string[]
					{
						text3,
						(value / 100).ToString(),
						",",
						(CRes.abs(value) % 100).ToString(),
						"%"
					});
				}
				else
				{
					bool flag4 = isPer == 10;
					if (flag4)
					{
						string text4 = text;
						text = string.Concat(new string[]
						{
							text4,
							(value / 10).ToString(),
							",",
							(CRes.abs(value) % 10).ToString(),
							"s"
						});
					}
				}
			}
		}
		return text;
	}

	// Token: 0x06000756 RID: 1878 RVA: 0x0009D2CC File Offset: 0x0009B4CC
	public void paintColor(mGraphics g, int x, int y, int w)
	{
		bool flag = (int)(this.colorName * 32) + w <= mImage.getImageHeight(MainItem.imgColorItem.image);
		if (flag)
		{
			g.drawRegion(MainItem.imgColorItem, 0, (int)(this.colorName * 32), w, w, 0, (float)x, (float)y, 3);
		}
	}

	// Token: 0x06000757 RID: 1879 RVA: 0x0009D320 File Offset: 0x0009B520
	public virtual void paint(mGraphics g, int x, int y, int w)
	{
		MainImage image = this.getImage();
		bool flag = image != null && image.img != null;
		if (flag)
		{
			this.paintImgItem(g, image, x, y);
		}
		else
		{
			AvMain.imgLoadImage.drawFrame(GameCanvas.gameTick % AvMain.imgLoadImage.nFrame, x, y, 0, 3, g);
		}
		this.paintEff_LvUp(g, x, y, w, 0);
	}

	// Token: 0x06000758 RID: 1880 RVA: 0x0009D388 File Offset: 0x0009B588
	public virtual void paintNumPotion(mGraphics g, int x, int y, int w, short num)
	{
		bool flag = this.numPotionNeed > 0;
		if (flag)
		{
			g.drawImage(AvMain.imgBgnum, x + MainTab.wItem / 2 - 11, y + MainTab.wItem / 2 - 6, 3);
			mFont mFont = mFont.tahoma_7_yellow;
			bool flag2 = this.numPotionNeed > this.numPotion;
			if (flag2)
			{
				mFont = mFont.tahoma_7_red;
			}
			mFont.drawString(g, this.numPotion.ToString() + "/" + this.numPotionNeed.ToString(), x + MainTab.wItem / 2 - 11, y + MainTab.wItem / 2 - 9 - 2, 2);
		}
		else
		{
			bool flag3 = num > 1;
			if (flag3)
			{
				g.drawImage(AvMain.imgBgnum, x + MainTab.wItem / 2 - 11, y + MainTab.wItem / 2 - 6, 3);
				mFont.tahoma_7_yellow.drawString(g, string.Empty + num.ToString(), x + MainTab.wItem / 2 - 11, y + MainTab.wItem / 2 - 9 - 2, 2);
			}
		}
	}

	// Token: 0x06000759 RID: 1881 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void paintQuay(mGraphics g, int x, int y, int w)
	{
	}

	// Token: 0x0600075A RID: 1882 RVA: 0x0009D498 File Offset: 0x0009B698
	public virtual void paintNumPotionQuay(mGraphics g, int x, int y, int w, short num)
	{
		bool flag = this.numPotionNeed > 0;
		if (flag)
		{
			g.drawImage(AvMain.imgBgnum, x + MainTab.wItem / 2 - 11, y + MainTab.wItem / 2 - 6, 3);
			mFont mFont = mFont.tahoma_7_yellow;
			bool flag2 = this.numPotionNeed > this.numPotion;
			if (flag2)
			{
				mFont = mFont.tahoma_7_red;
			}
			mFont.drawString(g, this.numPotion.ToString() + "/" + this.numPotionNeed.ToString(), x + MainTab.wItem / 2 - 11, y + MainTab.wItem / 2 - 9 - 2, 2);
		}
		else
		{
			g.drawImage(AvMain.imgBgnum, x + MainTab.wItem / 2 - 11, y + MainTab.wItem / 2 - 6, 3);
			mFont.tahoma_7_yellow.drawString(g, string.Empty + num.ToString(), x + MainTab.wItem / 2 - 11, y + MainTab.wItem / 2 - 9 - 2, 2);
		}
	}

	// Token: 0x0600075B RID: 1883 RVA: 0x0000AAE9 File Offset: 0x00008CE9
	public virtual void paintPotion(mGraphics g, int x, int y, int w)
	{
		this.paintNumPotion(g, x, y, w, this.numPotion);
	}

	// Token: 0x0600075C RID: 1884 RVA: 0x0009D5A0 File Offset: 0x0009B7A0
	public void paint(mGraphics g, int x, int y, int w, int lech)
	{
		MainImage image = this.getImage();
		bool flag = image != null && image.img != null;
		if (flag)
		{
			this.paintImgItem(g, image, x, y);
		}
		else
		{
			AvMain.imgLoadImage.drawFrame(GameCanvas.gameTick % AvMain.imgLoadImage.nFrame, x, y, 0, 3, g);
		}
		this.paintEff_LvUp(g, x, y, w, lech);
	}

	// Token: 0x0600075D RID: 1885 RVA: 0x0009D60C File Offset: 0x0009B80C
	public void paintEffSub(mGraphics g, int x, int y, int w, int lech)
	{
		MainImage image = this.getImage();
		bool flag = image != null && image.img != null;
		if (flag)
		{
			this.paintImgItem(g, image, x, y);
		}
		else
		{
			AvMain.imgLoadImage.drawFrame(GameCanvas.gameTick % AvMain.imgLoadImage.nFrame, x, y, 0, 3, g);
		}
		bool flag2 = this.LvUpgrade > 0;
		if (flag2)
		{
			MainItem.eff_UpLv_Sub.paintUpgradeEffect(x, y, (int)this.LvUpgrade, w - 4, g, lech, true);
		}
	}

	// Token: 0x0600075E RID: 1886 RVA: 0x0009D694 File Offset: 0x0009B894
	public void paintEff_LvUp(mGraphics g, int x, int y, int w, int lech)
	{
		bool flag = this.indexUniform > -1 && this.indexUniform <= 2;
		if (flag)
		{
			AvMain.fraUniform.drawFrame((int)this.indexUniform, x - w / 2 + 2, y + w / 2 - 9, 0, 0, g);
		}
		bool flag2 = this.typelock == 1;
		if (flag2)
		{
			g.drawImage(AvMain.imgLock, x + w / 2 - 1 - 8, y - w / 2 + 2, 0);
		}
		bool flag3 = this.LvUpgrade > 0;
		if (flag3)
		{
			int upgrade = (int)this.LvUpgrade;
			bool flag4 = this.typeSpec == 1;
			if (flag4)
			{
				upgrade = (int)(this.LvUpgrade % 10);
			}
			MainItem.eff_UpLv.paintUpgradeEffect(x, y, upgrade, w - 4, g, lech, true);
		}
		bool flag5 = this.mDaKham == null;
		if (!flag5)
		{
			for (int i = 0; i < this.mDaKham.Length; i++)
			{
				int num = (int)((this.mDaKham[i] - 44) / 6);
				bool flag6 = this.mDaKham[i] >= 324 && this.mDaKham[i] <= 326;
				if (flag6)
				{
					num = GameCanvas.gameTick / 5 % 6;
				}
				else
				{
					bool flag7 = this.mDaKham[i] >= 241 && this.mDaKham[i] <= 270;
					if (flag7)
					{
						num = (int)((this.mDaKham[i] - 241) / 5);
					}
					else
					{
						bool flag8 = (this.mDaKham[i] >= 368 && this.mDaKham[i] <= 373) || (this.mDaKham[i] >= 362 && this.mDaKham[i] <= 367);
						if (flag8)
						{
							num = 6;
						}
					}
				}
				int num2 = x - w / 2 + 5 + i / 2 * 9;
				int num3 = y - w / 2 + 5;
				bool flag9 = i % 2 == 1;
				if (flag9)
				{
					num2 = x + w / 2 - 5 - i / 2 * 9;
					num3 = y + w / 2 - 5;
				}
				bool flag10 = num >= 0 && num < AvMain.fraEffItem.nFrame;
				if (flag10)
				{
					bool flag11 = (this.mDaKham[i] >= 241 && this.mDaKham[i] <= 270) || (this.mDaKham[i] >= 368 && this.mDaKham[i] <= 373);
					if (flag11)
					{
						AvMain.fraEffItem2.drawFrame(num * 2 + GameCanvas.gameTick / 5 % 2, num2, num3, 0, 3, g);
					}
					else
					{
						AvMain.fraEffItem.drawFrame(num * 2 + GameCanvas.gameTick / 5 % 2, num2, num3, 0, 3, g);
					}
				}
			}
		}
	}

	// Token: 0x0600075F RID: 1887 RVA: 0x0009D978 File Offset: 0x0009BB78
	public MainImage getImageAll()
	{
		MainImage result = null;
		bool flag = this.typeObject == 3;
		if (flag)
		{
			result = ObjectData.getImageAll(this.idIcon, ObjectData.hashImageItem, 3000);
		}
		bool flag2 = this.typeObject == 7;
		if (flag2)
		{
			result = ObjectData.getImageAll(this.idIcon, ObjectData.hashImageMaterialPotion, 6500);
		}
		bool flag3 = this.typeObject == 4;
		if (flag3)
		{
			result = ObjectData.getImageAll(this.idIcon, ObjectData.hashImagePotion, 2000);
		}
		bool flag4 = this.typeObject == 100;
		if (flag4)
		{
			result = ObjectData.getImageAll(this.idIcon, ObjectData.hashImageItemOther, 9000);
		}
		bool flag5 = this.typeObject == 104;
		if (flag5)
		{
			result = ObjectData.getImageAll(this.idIcon, ObjectData.hashImageSkill, 4000);
		}
		bool flag6 = this.typeObject == 105;
		if (flag6)
		{
			result = ObjectData.getImageAll(this.idIcon, ObjectData.HashImageFashion, 20000);
		}
		bool flag7 = this.typeObject == 110;
		if (flag7)
		{
			result = ObjectData.getImageAll(this.idIcon, ObjectData.HashImageOtherNew, 23000);
		}
		return result;
	}

	// Token: 0x06000760 RID: 1888 RVA: 0x0009DAA0 File Offset: 0x0009BCA0
	public void paintAllItem_Num1(mGraphics g, int x, int y, int w, int lech, sbyte color, short numPaint)
	{
		this.paintAllItem(g, x, y, w, lech, color, numPaint, true);
	}

	// Token: 0x06000761 RID: 1889 RVA: 0x0009DAC4 File Offset: 0x0009BCC4
	public void paintAllItem(mGraphics g, int x, int y, int w, int lech, sbyte color)
	{
		this.paintAllItem(g, x, y, w, lech, color, this.numPotion, true);
	}

	// Token: 0x06000762 RID: 1890 RVA: 0x0009DAEC File Offset: 0x0009BCEC
	public void paintAllItem(mGraphics g, int x, int y, int w, int lech, sbyte color, short numpaint, bool typePaintNum)
	{
		MainImage imageAll = this.getImageAll();
		bool flag = imageAll != null && imageAll.img != null;
		if (flag)
		{
			this.paintImgItem(g, imageAll, x, y);
		}
		else
		{
			AvMain.imgLoadImage.drawFrame(GameCanvas.gameTick % AvMain.imgLoadImage.nFrame, x, y, 0, 3, g);
		}
		bool flag2 = this.typeObject == 3;
		if (flag2)
		{
			AvMain.setTextColor((int)color).drawString(g, "Lv." + this.LvUpgrade.ToString(), x + MainTab.wItem / 2 - 2, y + MainTab.wItem / 2 - 9 - 2, 1);
		}
		else if (typePaintNum)
		{
			this.paintNumPotion(g, x, y, w, numpaint);
		}
		this.paintEff_LvUp(g, x, y, w, lech);
	}

	// Token: 0x06000763 RID: 1891 RVA: 0x0009DBB8 File Offset: 0x0009BDB8
	public void paintImgItem(mGraphics g, MainImage img, int x, int y)
	{
		bool flag = !this.isloadfra;
		if (flag)
		{
			this.setFraImageVip(img);
		}
		bool flag2 = this.fraImgVip != null;
		if (flag2)
		{
			int num = (this.framepaint < this.fraImgVip.nFrame - 1) ? 3 : 15;
			bool flag3 = CRes.abs(GameCanvas.gameTick - this.lastTick) > num;
			if (flag3)
			{
				this.framepaint++;
				bool flag4 = this.framepaint >= this.fraImgVip.nFrame;
				if (flag4)
				{
					this.framepaint = 0;
				}
				this.lastTick = GameCanvas.gameTick;
			}
			this.fraImgVip.drawFrame((this.framepaint <= this.fraImgVip.nFrame - 1) ? this.framepaint : 0, x, y, 0, 3, g);
		}
		else
		{
			g.drawImage(img.img, x, y, 3);
		}
	}

	// Token: 0x06000764 RID: 1892 RVA: 0x0009DCA8 File Offset: 0x0009BEA8
	private void setFraImageVip(MainImage img)
	{
		bool flag = img != null && img.img != null;
		if (flag)
		{
			int imageWidth = mImage.getImageWidth(img.img.image);
			int imageHeight = mImage.getImageHeight(img.img.image);
			bool flag2 = imageHeight / 2 >= imageWidth;
			if (flag2)
			{
				this.fraImgVip = new FrameImage(img.img, imageWidth, imageWidth);
			}
			this.isloadfra = true;
		}
	}

	// Token: 0x06000765 RID: 1893 RVA: 0x0000AAFE File Offset: 0x00008CFE
	public virtual void paintHotkey(mGraphics g, int x, int y, int w, int yLech)
	{
		this.paintAllItem(g, x, y, w, 0, 5);
	}

	// Token: 0x06000766 RID: 1894 RVA: 0x0009DD18 File Offset: 0x0009BF18
	public virtual MainImage getImage()
	{
		return this.getImageAll();
	}

	// Token: 0x06000767 RID: 1895 RVA: 0x0009DD30 File Offset: 0x0009BF30
	public static void removeUpdateItemVec(sbyte type, mVector vec)
	{
		for (int i = 0; i < vec.size(); i++)
		{
			MainItem mainItem = (MainItem)vec.elementAt(i);
			bool flag = mainItem.typeObject == type;
			if (flag)
			{
				vec.removeElement(mainItem);
				i--;
			}
		}
	}

	// Token: 0x06000768 RID: 1896 RVA: 0x0009DD80 File Offset: 0x0009BF80
	public static MainItem getItemVec(sbyte type, short id, mVector vec)
	{
		for (int i = 0; i < vec.size(); i++)
		{
			MainItem mainItem = (MainItem)vec.elementAt(i);
			bool flag = mainItem.typeObject == type && mainItem.ID == id;
			if (flag)
			{
				return mainItem;
			}
		}
		return null;
	}

	// Token: 0x06000769 RID: 1897 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void Use_Item()
	{
	}

	// Token: 0x0600076A RID: 1898 RVA: 0x0009DDD8 File Offset: 0x0009BFD8
	public virtual mVector getActionInven(sbyte type)
	{
		bool flag = this.typeObject == 110;
		mVector result;
		if (flag)
		{
			mVector mVector = new mVector();
			bool flag2 = this.colorName == 1;
			if (flag2)
			{
				mVector.addElement(GameCanvas.tabInvenClan.cmdDonotUse);
			}
			else
			{
				mVector.addElement(GameCanvas.tabInvenClan.cmdUsePotion);
			}
			result = mVector;
		}
		else
		{
			result = null;
		}
		return result;
	}

	// Token: 0x0600076B RID: 1899 RVA: 0x0009DE3C File Offset: 0x0009C03C
	public virtual mVector getActionShop(sbyte typeShop)
	{
		mVector mVector = new mVector();
		mVector.addElement(TabShop.cmdBuyPotion);
		return mVector;
	}

	// Token: 0x0600076C RID: 1900 RVA: 0x0009DE64 File Offset: 0x0009C064
	public virtual mVector getActionChest()
	{
		return null;
	}

	// Token: 0x0600076D RID: 1901 RVA: 0x0009DE64 File Offset: 0x0009C064
	public virtual mVector getActionUpgrade()
	{
		return null;
	}

	// Token: 0x0600076E RID: 1902 RVA: 0x0009DE64 File Offset: 0x0009C064
	public virtual mVector getActionSplit()
	{
		return null;
	}

	// Token: 0x0600076F RID: 1903 RVA: 0x0009DE78 File Offset: 0x0009C078
	public mVector getActionTrade()
	{
		mVector mVector = new mVector();
		bool flag = TradeScreen.instance != null;
		if (flag)
		{
			mVector.addElement(TradeScreen.instance.cmdBovao);
		}
		return mVector;
	}

	// Token: 0x06000770 RID: 1904 RVA: 0x0009DEB0 File Offset: 0x0009C0B0
	public static string getInfoEveryWhere(MainInfoItem info)
	{
		bool flag = info == null || (int)info.id >= MainItem.mNameAttributes.Length;
		string result;
		if (flag)
		{
			result = "null";
		}
		else
		{
			result = MainItem.mNameAttributes[(int)info.id].name + " " + MainItem.strGetPercent(info.value, MainItem.mNameAttributes[(int)info.id].ispercent);
		}
		return result;
	}

	// Token: 0x06000771 RID: 1905 RVA: 0x0009DF20 File Offset: 0x0009C120
	public static string getTimeDelay(int value)
	{
		return (value / 1000).ToString() + "," + (value % 1000 / 100).ToString() + "s";
	}

	// Token: 0x06000772 RID: 1906 RVA: 0x0009DF64 File Offset: 0x0009C164
	public static void LoadNameAttribute(DataInputStream iss, bool isSave)
	{
		bool flag = iss == null;
		if (flag)
		{
			GlobalService.gI().get_DATA(2);
		}
		else
		{
			try
			{
				short num = iss.readShort();
				MainItem.mNameAttributes = new MainInfoItem[(int)num];
				for (int i = 0; i < (int)num; i++)
				{
					MainItem.mNameAttributes[i] = new MainInfoItem(iss.readUTF(), iss.readByte(), iss.readByte());
				}
				if (isSave)
				{
					GlobalService.VerNameAtribute = iss.readShort();
					SaveRms.saveVer(GlobalService.VerNameAtribute, "VerdataAttri");
				}
				iss.close();
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x06000773 RID: 1907 RVA: 0x0009E010 File Offset: 0x0009C210
	public static mVector SortVecItem(mVector vec)
	{
		int num = vec.size();
		for (int i = 0; i < num - 1; i++)
		{
			int num2 = i;
			for (int j = i + 1; j < num; j++)
			{
				bool flag = ((MainItem)vec.elementAt(j)).indexSort < ((MainItem)vec.elementAt(num2)).indexSort;
				if (flag)
				{
					num2 = j;
				}
			}
			bool flag2 = num2 != i;
			if (flag2)
			{
				MainItem.swapItem(vec, i, num2);
			}
		}
		for (int k = 0; k < num - 1; k++)
		{
			int num2 = k;
			for (int l = k + 1; l < num; l++)
			{
				MainItem mainItem = (MainItem)vec.elementAt(l);
				bool flag3 = mainItem.typeObject == 4 && ((MainItem)vec.elementAt(l)).ID < ((MainItem)vec.elementAt(num2)).ID;
				if (flag3)
				{
					num2 = l;
				}
			}
			bool flag4 = num2 != k;
			if (flag4)
			{
				MainItem.swapItem(vec, k, num2);
			}
		}
		return vec;
	}

	// Token: 0x06000774 RID: 1908 RVA: 0x0009E148 File Offset: 0x0009C348
	private static void swapItem(mVector actors, int dex1, int dex2)
	{
		object obj = actors.elementAt(dex2);
		actors.setElementAt(actors.elementAt(dex1), dex2);
		actors.setElementAt(obj, dex1);
	}

	// Token: 0x06000775 RID: 1909 RVA: 0x0009E178 File Offset: 0x0009C378
	public static mVector getInfoSS(MainItem itemSet)
	{
		mVector mVector = new mVector();
		bool flag = itemSet == null || (itemSet.charClass != GameScreen.player.clazz && itemSet.charClass > 0) || itemSet.typeObject != 3;
		mVector result;
		if (flag)
		{
			result = null;
		}
		else
		{
			MainItem mainItem = (MainItem)GameScreen.player.hashEquip.get(string.Empty + itemSet.typeEquip.ToString());
			bool flag2 = mainItem != null;
			if (flag2)
			{
				for (int i = 0; i < itemSet.vecInfo.size(); i++)
				{
					infoShow infoShow = (infoShow)itemSet.vecInfo.elementAt(i);
					bool flag3 = false;
					bool flag4 = infoShow.id >= 0 && infoShow.colorMain == infoShow.HARDCODE_INFO_CO_BAN;
					if (flag4)
					{
						for (int j = 0; j < mainItem.vecInfo.size(); j++)
						{
							infoShow infoShow2 = (infoShow)mainItem.vecInfo.elementAt(j);
							bool flag5 = infoShow.id == infoShow2.id;
							if (flag5)
							{
								int num = infoShow.value - infoShow2.value;
								sbyte color = 6;
								string str = MainItem.strGetPercent(num, MainItem.mNameAttributes[infoShow.id].ispercent);
								bool flag6 = num >= 0;
								if (flag6)
								{
									str = "+" + MainItem.strGetPercent(num, MainItem.mNameAttributes[infoShow.id].ispercent);
									color = 1;
								}
								mVector.addElement(new infoShow(-1, num, str, color, -1));
								flag3 = true;
								break;
							}
						}
					}
					bool flag7 = !flag3;
					if (flag7)
					{
						mVector.addElement(new infoShow(-1, 0, string.Empty, 0, -1));
					}
				}
			}
			bool flag8 = mVector.size() == 0;
			if (flag8)
			{
				mVector = null;
			}
			result = mVector;
		}
		return result;
	}

	// Token: 0x06000776 RID: 1910 RVA: 0x0009E374 File Offset: 0x0009C574
	public static mVector getInfoSS(MainItem itemSet, int Plus)
	{
		mVector mVector = new mVector();
		bool flag = itemSet == null || (itemSet.charClass != GameScreen.player.clazz && itemSet.charClass > 0);
		mVector result;
		if (flag)
		{
			result = null;
		}
		else
		{
			MainItem mainItem = (MainItem)GameScreen.player.hashEquip.get(string.Empty + itemSet.typeEquip.ToString());
			bool flag2 = mainItem != null;
			if (flag2)
			{
				for (int i = 0; i < itemSet.vecInfo.size(); i++)
				{
					infoShow infoShow = (infoShow)itemSet.vecInfo.elementAt(i);
					bool flag3 = false;
					bool flag4 = infoShow.id >= 0 && infoShow.colorMain == infoShow.HARDCODE_INFO_CO_BAN;
					if (flag4)
					{
						for (int j = 0; j < mainItem.vecInfo.size(); j++)
						{
							infoShow infoShow2 = (infoShow)mainItem.vecInfo.elementAt(j);
							bool flag5 = infoShow.id == infoShow2.id;
							if (flag5)
							{
								int num = MainItem.valueSameUpgrade(infoShow.value, (int)itemSet.LvUpgrade, Plus) - infoShow2.value;
								sbyte color = 6;
								string str = MainItem.strGetPercent(num, MainItem.mNameAttributes[infoShow.id].ispercent);
								bool flag6 = num >= 0;
								if (flag6)
								{
									str = "+" + MainItem.strGetPercent(num, MainItem.mNameAttributes[infoShow.id].ispercent);
									color = 1;
								}
								mVector.addElement(new infoShow(-1, num, str, color, -1));
								flag3 = true;
								break;
							}
						}
					}
					bool flag7 = !flag3;
					if (flag7)
					{
						mVector.addElement(new infoShow(-1, 0, string.Empty, 0, -1));
					}
				}
			}
			bool flag8 = mVector.size() == 0;
			if (flag8)
			{
				mVector = null;
			}
			result = mVector;
		}
		return result;
	}

	// Token: 0x06000777 RID: 1911 RVA: 0x0009E574 File Offset: 0x0009C774
	public static int valueSameUpgrade(int value, int cur, int up)
	{
		bool flag = up == cur;
		int result;
		if (flag)
		{
			result = value;
		}
		else
		{
			int num = value * 100 / (MainItem.mValueUpgrade[cur] + 100);
			result = num + num * MainItem.mValueUpgrade[up] / 100;
		}
		return result;
	}

	// Token: 0x06000778 RID: 1912 RVA: 0x000734DC File Offset: 0x000716DC
	public virtual bool getStar()
	{
		return false;
	}

	// Token: 0x06000779 RID: 1913 RVA: 0x0000A52F File Offset: 0x0000872F
	public virtual void setTimeMarket(int time)
	{
		this.timeUse = time;
		this.marketTime.setCountDown(time);
	}

	// Token: 0x0600077A RID: 1914 RVA: 0x0009E5B4 File Offset: 0x0009C7B4
	public void CheckTimeSell()
	{
		bool flag = this.typeMarket == 1 && this.marketTime.timeCountDown <= 0;
		if (flag)
		{
			this.typeMarket = 3;
		}
	}

	// Token: 0x0600077B RID: 1915 RVA: 0x0009E5EC File Offset: 0x0009C7EC
	public static string getDataKichAn(Item item)
	{
		string text = string.Empty;
		text = (string)MainItem.hashAttriKichAn.get(string.Empty + item.valueKickAn.ToString());
		bool flag = text == null;
		if (flag)
		{
			MainItem.hashAttriKichAn.put(string.Empty + item.valueKickAn.ToString(), string.Empty);
			GlobalService.gI().GetTemplate(96, (short)item.valueKickAn);
			text = string.Empty;
		}
		bool flag2 = text.Length == 0;
		if (flag2)
		{
			Item.vecItemKichAnCheckInfo.addElement(item);
		}
		return text;
	}

	// Token: 0x0600077C RID: 1916 RVA: 0x0009E690 File Offset: 0x0009C890
	public short getIdMarket()
	{
		return this.IDMarket;
	}

	// Token: 0x0600077D RID: 1917 RVA: 0x0009E6A8 File Offset: 0x0009C8A8
	public bool getInfoPotion(short index)
	{
		bool flag = this.info == null || this.info.Length == 0;
		if (flag)
		{
			this.indexInfoPotion = index;
			this.info = MainItem.GetInfoPotion(this.indexInfoPotion);
			bool flag2 = this.info.Length == 0;
			if (flag2)
			{
				return false;
			}
		}
		this.setInfoPotion(this.info);
		return true;
	}

	// Token: 0x0600077E RID: 1918 RVA: 0x0009E718 File Offset: 0x0009C918
	public static string GetInfoPotion(short index)
	{
		string text = (string)Potion.hashInfoPotion.get(string.Empty + index.ToString());
		bool flag = text == null;
		string result;
		if (flag)
		{
			Potion.hashInfoPotion.put(string.Empty + index.ToString(), string.Empty);
			GlobalService.gI().getDataInfoPotion(index);
			result = string.Empty;
		}
		else
		{
			result = text;
		}
		return result;
	}

	// Token: 0x04000B1F RID: 2847
	public const sbyte MARKET_NORMAL = 0;

	// Token: 0x04000B20 RID: 2848
	public const sbyte MARKET_SELLING = 1;

	// Token: 0x04000B21 RID: 2849
	public const sbyte MARKET_SELLED = 2;

	// Token: 0x04000B22 RID: 2850
	public const sbyte MARKET_SELL_END = 3;

	// Token: 0x04000B23 RID: 2851
	public const sbyte MARKET_BUY_COMPLETE = 4;

	// Token: 0x04000B24 RID: 2852
	public const sbyte SPEC_HEART = 1;

	// Token: 0x04000B25 RID: 2853
	public int numInt = 1;

	// Token: 0x04000B26 RID: 2854
	public int x;

	// Token: 0x04000B27 RID: 2855
	public int y;

	// Token: 0x04000B28 RID: 2856
	public int timeUse;

	// Token: 0x04000B29 RID: 2857
	public int price;

	// Token: 0x04000B2A RID: 2858
	public int priceVND;

	// Token: 0x04000B2B RID: 2859
	public short ID;

	// Token: 0x04000B2C RID: 2860
	public short idIcon = -1;

	// Token: 0x04000B2D RID: 2861
	public short priceRuby;

	// Token: 0x04000B2E RID: 2862
	public short Lv_RQ;

	// Token: 0x04000B2F RID: 2863
	public short numPotion = 1;

	// Token: 0x04000B30 RID: 2864
	public short indexHotKey;

	// Token: 0x04000B31 RID: 2865
	public short idPart;

	// Token: 0x04000B32 RID: 2866
	public short maxTimeUse;

	// Token: 0x04000B33 RID: 2867
	public short indexInfoPotion;

	// Token: 0x04000B34 RID: 2868
	public short valueCheTac;

	// Token: 0x04000B35 RID: 2869
	public short IDMarket;

	// Token: 0x04000B36 RID: 2870
	public short numPotionNeed;

	// Token: 0x04000B37 RID: 2871
	public sbyte indexSort;

	// Token: 0x04000B38 RID: 2872
	public sbyte typeMaterial;

	// Token: 0x04000B39 RID: 2873
	public sbyte LvUpgrade;

	// Token: 0x04000B3A RID: 2874
	public sbyte typeBoat;

	// Token: 0x04000B3B RID: 2875
	public sbyte numLoKham;

	// Token: 0x04000B3C RID: 2876
	public sbyte typelock;

	// Token: 0x04000B3D RID: 2877
	public sbyte numHoleDaDuc;

	// Token: 0x04000B3E RID: 2878
	public sbyte LvDevilSkill;

	// Token: 0x04000B3F RID: 2879
	public sbyte phanTramDevilSkill;

	// Token: 0x04000B40 RID: 2880
	public sbyte indexUniform = -1;

	// Token: 0x04000B41 RID: 2881
	public sbyte isHoanMy;

	// Token: 0x04000B42 RID: 2882
	public sbyte valueKickAn;

	// Token: 0x04000B43 RID: 2883
	public sbyte typeSpec;

	// Token: 0x04000B44 RID: 2884
	public sbyte perSuc;

	// Token: 0x04000B45 RID: 2885
	public short[] mDaKham;

	// Token: 0x04000B46 RID: 2886
	public short[] mWearing;

	// Token: 0x04000B47 RID: 2887
	public string name;

	// Token: 0x04000B48 RID: 2888
	public string namepaint = string.Empty;

	// Token: 0x04000B49 RID: 2889
	public string info;

	// Token: 0x04000B4A RID: 2890
	public string nameUse;

	// Token: 0x04000B4B RID: 2891
	public mVector vecInfo = new mVector("MainItem.vecInfo");

	// Token: 0x04000B4C RID: 2892
	public sbyte isTrade;

	// Token: 0x04000B4D RID: 2893
	public sbyte charClass;

	// Token: 0x04000B4E RID: 2894
	public sbyte Hp_Mp_Other;

	// Token: 0x04000B4F RID: 2895
	public sbyte typeEquip;

	// Token: 0x04000B50 RID: 2896
	public int wInfo = 140;

	// Token: 0x04000B51 RID: 2897
	public int hInfo = 40;

	// Token: 0x04000B52 RID: 2898
	public short timeDelayPotion;

	// Token: 0x04000B53 RID: 2899
	public short value;

	// Token: 0x04000B54 RID: 2900
	public sbyte colorName;

	// Token: 0x04000B55 RID: 2901
	public sbyte typeObject;

	// Token: 0x04000B56 RID: 2902
	public sbyte typeMarket;

	// Token: 0x04000B57 RID: 2903
	public static MainInfoItem[] mNameAttributes;

	// Token: 0x04000B58 RID: 2904
	public static MyHashTable hashPotionTem = new MyHashTable();

	// Token: 0x04000B59 RID: 2905
	public static MyHashTable hashMaterialTem = new MyHashTable();

	// Token: 0x04000B5A RID: 2906
	public static MyHashTable hashPotionClan = new MyHashTable();

	// Token: 0x04000B5B RID: 2907
	public static MyHashTable hashAttriKichAn = new MyHashTable();

	// Token: 0x04000B5C RID: 2908
	public bool isRemove;

	// Token: 0x04000B5D RID: 2909
	public bool isIconClan;

	// Token: 0x04000B5E RID: 2910
	public bool isShop;

	// Token: 0x04000B5F RID: 2911
	public bool isPaint = true;

	// Token: 0x04000B60 RID: 2912
	public bool isRemoveVecEff;

	// Token: 0x04000B61 RID: 2913
	public static mImage imgColorItem;

	// Token: 0x04000B62 RID: 2914
	public FrameImage fraImgVip;

	// Token: 0x04000B63 RID: 2915
	public bool isloadfra;

	// Token: 0x04000B64 RID: 2916
	public static Effect_UpLv_Item eff_UpLv = new Effect_UpLv_Item();

	// Token: 0x04000B65 RID: 2917
	public static Effect_UpLv_Item eff_UpLv_Clan = new Effect_UpLv_Item();

	// Token: 0x04000B66 RID: 2918
	public static Effect_UpLv_Item eff_UpLv_Sub = new Effect_UpLv_Item();

	// Token: 0x04000B67 RID: 2919
	public CountDownTicket marketTime = new CountDownTicket();

	// Token: 0x04000B68 RID: 2920
	public static short[] ID_POTION_CAN_SELL;

	// Token: 0x04000B69 RID: 2921
	public static short[] ID_MATERIAL_CAN_SELL;

	// Token: 0x04000B6A RID: 2922
	public int hRunInfo;

	// Token: 0x04000B6B RID: 2923
	private int lastTick;

	// Token: 0x04000B6C RID: 2924
	private int framepaint;

	// Token: 0x04000B6D RID: 2925
	public static int[] mValueUpgrade = new int[]
	{
		0,
		10,
		20,
		30,
		45,
		60,
		75,
		90,
		110,
		130,
		150,
		150,
		150,
		150,
		150,
		150,
		150
	};
}
