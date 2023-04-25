using System;

// Token: 0x020000D3 RID: 211
public class Potion : MainItem
{
	// Token: 0x06000C0E RID: 3086 RVA: 0x000E7CB0 File Offset: 0x000E5EB0
	public Potion(short Id, short idImage, string name, string info, short priceRuby)
	{
		this.ID = Id;
		this.idIcon = idImage;
		this.name = name;
		this.namepaint = name;
		this.info = info;
		this.priceRuby = priceRuby;
		this.typeObject = 4;
		this.isShop = true;
		base.setInfoPotion(info);
		this.isIconClan = true;
		bool flag = priceRuby == 0;
		if (flag)
		{
			this.nameUse = T.select;
		}
		else
		{
			this.nameUse = T.cmdBuy;
		}
	}

	// Token: 0x06000C0F RID: 3087 RVA: 0x0000BB1F File Offset: 0x00009D1F
	public Potion(short Id)
	{
		this.ID = Id;
	}

	// Token: 0x06000C10 RID: 3088 RVA: 0x0000BB30 File Offset: 0x00009D30
	public Potion(sbyte cat, short Id, short num, bool isShop)
	{
		this.typeObject = cat;
		this.ID = Id;
		this.numPotion = num;
		this.isShop = isShop;
	}

	// Token: 0x06000C11 RID: 3089 RVA: 0x0000BB57 File Offset: 0x00009D57
	public Potion(sbyte typeItem, short ID, short idIcon, string name, sbyte isTrade) : base(typeItem, ID, idIcon, name, isTrade)
	{
		this.indexSort = 0;
	}

	// Token: 0x06000C12 RID: 3090 RVA: 0x000E7D34 File Offset: 0x000E5F34
	public void setdata(int price, short priceRuby, short value, short timeActive, short timedelay, sbyte hp_mp, string nameUse)
	{
		this.price = price;
		this.priceRuby = priceRuby;
		this.value = value;
		this.timeActive = timeActive;
		this.timeDelayPotion = timedelay;
		this.Hp_Mp_Other = hp_mp;
		this.nameUse = nameUse;
		this.indexHotKey = (short)(500 + (int)this.Hp_Mp_Other);
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

	// Token: 0x06000C13 RID: 3091 RVA: 0x000E7DCC File Offset: 0x000E5FCC
	public static Potion Potion_Tem(sbyte typeItem, short ID, short idIcon, string name, string info, sbyte isTrade, short price, short priceRuby, sbyte Hp_Mp_Other, short timeDelay, short value, short timeactive, string nameUse)
	{
		return new Potion(typeItem, ID, idIcon, name, isTrade)
		{
			info = info,
			price = (int)price,
			priceRuby = priceRuby,
			Hp_Mp_Other = Hp_Mp_Other,
			timeDelayPotion = timeDelay,
			timeActive = timeactive,
			value = value,
			nameUse = nameUse,
			isUpdateTem = true
		};
	}

	// Token: 0x06000C14 RID: 3092 RVA: 0x000E7DCC File Offset: 0x000E5FCC
	public static Potion Update_Potion_Tem(sbyte typeItem, short ID, short idIcon, string name, string info, sbyte isTrade, int price, short priceRuby, sbyte Hp_Mp_Other, short timeDelay, short value, short timeactive, string nameUse)
	{
		return new Potion(typeItem, ID, idIcon, name, isTrade)
		{
			info = info,
			price = price,
			priceRuby = priceRuby,
			Hp_Mp_Other = Hp_Mp_Other,
			timeDelayPotion = timeDelay,
			timeActive = timeactive,
			value = value,
			nameUse = nameUse,
			isUpdateTem = true
		};
	}

	// Token: 0x06000C15 RID: 3093 RVA: 0x000E7E34 File Offset: 0x000E6034
	public override mVector getActionInven(sbyte type)
	{
		mVector mVector = new mVector();
		bool flag = type == 0;
		if (flag)
		{
			bool flag2 = this.nameUse.CompareTo("null") != 0;
			if (flag2)
			{
				GameCanvas.tabInven.cmdUsePotion.caption = this.nameUse;
				mVector.addElement(GameCanvas.tabInven.cmdUsePotion);
			}
			bool flag3 = this.Hp_Mp_Other == 1 || this.Hp_Mp_Other == 2 || this.Hp_Mp_Other == 40 || this.Hp_Mp_Other == 84 || this.Hp_Mp_Other == 100;
			if (flag3)
			{
				mVector.addElement(GameCanvas.tabInven.cmdSetHotKey);
			}
			bool flag4 = this.Hp_Mp_Other == 12;
			if (flag4)
			{
				mVector.addElement(GameCanvas.tabInven.cmdMenuMaterial);
			}
			else
			{
				mVector.addElement(GameCanvas.tabInven.cmdRemoveItem);
			}
		}
		else
		{
			bool flag5 = type == 1;
			if (flag5)
			{
				mVector.addElement(GameCanvas.tabInven.cmdMenuSellShop);
			}
			else
			{
				bool flag6 = type == 2;
				if (flag6)
				{
					mVector.addElement(GameCanvas.tabInven.cmdSetChestPotion);
					bool flag7 = this.ID >= 44 && this.ID <= 79;
					if (flag7)
					{
						mVector.addElement(GameCanvas.tabInven.cmdChucnang);
					}
				}
				else
				{
					bool flag8 = type == 4;
					if (flag8)
					{
						mVector.addElement(GameCanvas.tabInvenClan.cmdUsePotion);
					}
					else
					{
						bool flag9 = type == 5 && ((this.ID >= 310 && this.ID <= 315) || this.ID == 339 || this.canSell());
						if (flag9)
						{
							mVector.addElement(GameCanvas.tabInvenMarket.cmdSellMarket);
						}
					}
				}
			}
		}
		return mVector;
	}

	// Token: 0x06000C16 RID: 3094 RVA: 0x000E8008 File Offset: 0x000E6208
	public bool canSell()
	{
		bool flag = MainItem.ID_POTION_CAN_SELL != null;
		if (flag)
		{
			for (int i = 0; i < MainItem.ID_POTION_CAN_SELL.Length; i++)
			{
				bool flag2 = this.ID == MainItem.ID_POTION_CAN_SELL[i];
				if (flag2)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06000C17 RID: 3095 RVA: 0x000E805C File Offset: 0x000E625C
	public override mVector getActionShop(sbyte typeShop)
	{
		mVector mVector = new mVector();
		bool flag = typeShop == 101;
		if (flag)
		{
			mVector.addElement(TabShop.cmdChangeShip);
			mVector.addElement(TabShop.cmdShip);
		}
		else
		{
			bool isIconClan = this.isIconClan;
			if (isIconClan)
			{
				mVector.addElement(TabShop.cmdBuyIconClan);
			}
			else
			{
				mVector.addElement(TabShop.cmdBuyPotion);
			}
		}
		return mVector;
	}

	// Token: 0x06000C18 RID: 3096 RVA: 0x000E80C4 File Offset: 0x000E62C4
	public override mVector getActionChest()
	{
		mVector mVector = new mVector();
		mVector.addElement(TabChest.cmdGetPotion);
		bool flag = this.ID >= 44 && this.ID <= 79;
		if (flag)
		{
			mVector.addElement(TabChest.cmdChucnang);
		}
		else
		{
			mVector.addElement(TabChest.cmdUpgrade);
		}
		return mVector;
	}

	// Token: 0x06000C19 RID: 3097 RVA: 0x000E8128 File Offset: 0x000E6328
	public override mVector getActionSplit()
	{
		mVector mVector = new mVector();
		bool flag = SplitScreen.instance != null && SplitScreen.instance.cmdBovao != null && (SplitScreen.instance.typeRebuild == 1 || SplitScreen.instance.typeRebuild == 4 || SplitScreen.instance.typeRebuild == 8 || SplitScreen.instance.typeRebuild == 10 || SplitScreen.instance.typeRebuild == 11 || SplitScreen.instance.typeRebuild == 13 || SplitScreen.instance.typeRebuild == 14 || (SplitScreen.instance.typeRebuild == 2 && (this.ID == 323 || this.ID == 339)) || (SplitScreen.instance.typeRebuild == 19 && this.ID == 457) || SplitScreen.instance.typeRebuild == 21);
		if (flag)
		{
			mVector.addElement(SplitScreen.instance.cmdBovao);
		}
		return mVector;
	}

	// Token: 0x06000C1A RID: 3098 RVA: 0x000E8230 File Offset: 0x000E6430
	public override void paint(mGraphics g, int x, int y, int w)
	{
		bool isIconClan = this.isIconClan;
		if (isIconClan)
		{
			MainImage iconClan = Potion.getIconClan(this.idIcon);
			bool flag = iconClan != null && iconClan.img != null;
			if (flag)
			{
				base.paintImgItem(g, iconClan, x, y);
			}
			else
			{
				AvMain.imgLoadImage.drawFrame(GameCanvas.gameTick % AvMain.imgLoadImage.nFrame, x, y, 0, 3, g);
			}
		}
		else
		{
			base.paint(g, x, y, w);
			this.paintPotion(g, x, y, w);
			bool flag2 = (this.idIcon >= 210 && this.idIcon <= 239) || (this.idIcon >= 319 && this.idIcon <= 324);
			if (flag2)
			{
				AvMain.fraEffDasieucap.drawFrame(GameCanvas.gameTickChia4 % AvMain.fraEffDasieucap.nFrame, x, y, 0, 3, g);
			}
		}
	}

	// Token: 0x06000C1B RID: 3099 RVA: 0x000E8318 File Offset: 0x000E6518
	public override void paintQuay(mGraphics g, int x, int y, int w)
	{
		bool isIconClan = this.isIconClan;
		if (isIconClan)
		{
			MainImage iconClan = Potion.getIconClan(this.idIcon);
			bool flag = iconClan != null && iconClan.img != null;
			if (flag)
			{
				base.paintImgItem(g, iconClan, x, y);
			}
			else
			{
				AvMain.imgLoadImage.drawFrame(GameCanvas.gameTick % AvMain.imgLoadImage.nFrame, x, y, 0, 3, g);
			}
		}
		else
		{
			base.paint(g, x, y, w);
			this.paintNumPotionQuay(g, x, y, w, this.numPotion);
			bool flag2 = (this.idIcon >= 210 && this.idIcon <= 239) || (this.idIcon >= 319 && this.idIcon <= 324);
			if (flag2)
			{
				AvMain.fraEffDasieucap.drawFrame(GameCanvas.gameTickChia4 % AvMain.fraEffDasieucap.nFrame, x, y, 0, 3, g);
			}
		}
	}

	// Token: 0x06000C1C RID: 3100 RVA: 0x000E8408 File Offset: 0x000E6608
	public static MainImage getIconClan(short Id)
	{
		bool flag = Id == -1;
		MainImage result;
		if (flag)
		{
			result = null;
		}
		else
		{
			result = ObjectData.getImageAll(Id, ObjectData.hashImageIconClan, 7000);
		}
		return result;
	}

	// Token: 0x06000C1D RID: 3101 RVA: 0x000E8438 File Offset: 0x000E6638
	public static MainImage getIconClanBig(short Id)
	{
		bool flag = Id == -1;
		MainImage result;
		if (flag)
		{
			result = null;
		}
		else
		{
			result = ObjectData.getImageAll(Id, ObjectData.hashImageIconClanBig, 22000);
		}
		return result;
	}

	// Token: 0x06000C1E RID: 3102 RVA: 0x0000AB20 File Offset: 0x00008D20
	public void paintIconClan(mGraphics g, int x, int y, int w)
	{
		base.paint(g, x, y, w);
		this.paintPotion(g, x, y, w);
	}

	// Token: 0x06000C1F RID: 3103 RVA: 0x000E8468 File Offset: 0x000E6668
	public static Potion getTemplatePotion(short IdP)
	{
		Potion potion = (Potion)MainItem.hashPotionTem.get(string.Empty + IdP.ToString());
		bool flag = potion == null;
		if (flag)
		{
			potion = new Potion(IdP);
			MainItem.hashPotionTem.put(string.Empty + IdP.ToString(), potion);
			GlobalService.gI().GetTemplate(4, IdP);
		}
		return potion;
	}

	// Token: 0x06000C20 RID: 3104 RVA: 0x000E84D8 File Offset: 0x000E66D8
	public override MainImage getImage()
	{
		MainImage mainImage = null;
		MainImage result;
		try
		{
			bool flag = this.idIcon == -1;
			if (flag)
			{
				result = null;
			}
			else
			{
				mainImage = ObjectData.getImageAll(this.idIcon, ObjectData.hashImagePotion, 2000);
				result = mainImage;
			}
		}
		catch (Exception)
		{
			result = mainImage;
		}
		return result;
	}

	// Token: 0x06000C21 RID: 3105 RVA: 0x000E852C File Offset: 0x000E672C
	public override void paintHotkey(mGraphics g, int x, int y, int w, int ylech)
	{
		base.paint(g, x, y, w);
		bool flag = this.numPotion >= 0;
		if (flag)
		{
			g.drawImage(AvMain.imgBgnum, x, y + 18 + ylech, 3);
			mFont.tahoma_7_yellow.drawString(g, string.Empty + this.numPotion.ToString(), x, y + 13 + ylech, 2);
		}
	}

	// Token: 0x06000C22 RID: 3106 RVA: 0x000E8598 File Offset: 0x000E6798
	public override void Use_Item()
	{
		bool flag = this.typeObject == 8;
		if (flag)
		{
			GlobalService.gI().Clan_CMD(14, string.Empty, (int)this.ID, this.typeObject);
		}
		else
		{
			bool flag2 = this.Hp_Mp_Other == 40 && DelaySkill.getDelay((int)this.indexHotKey).isCoolDown();
			if (flag2)
			{
				short num = GameScreen.checkPokemon();
				bool flag3 = num == -1;
				if (flag3)
				{
					GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.noPokemon);
				}
				else
				{
					GlobalService.gI().Use_Poke(this.ID, num);
				}
				Player.setDelaySkill((int)this.indexHotKey, (int)this.timeDelayPotion, true, 0);
			}
			else
			{
				bool flag4 = (GameScreen.player.Action == 4 && (this.Hp_Mp_Other == 1 || this.Hp_Mp_Other == 2)) || !DelaySkill.getDelay((int)this.indexHotKey).isCoolDown();
				if (!flag4)
				{
					bool flag5 = this.Hp_Mp_Other == 1 && GameScreen.player.Hp == GameScreen.player.maxHp;
					if (flag5)
					{
						Interface_Game.addInfoPlayerNormal(T.HPFull, mFont.tahoma_7_white);
					}
					else
					{
						bool flag6 = this.Hp_Mp_Other == 2 && GameScreen.player.Mp == GameScreen.player.maxMp;
						if (flag6)
						{
							Interface_Game.addInfoPlayerNormal(T.MpFull, mFont.tahoma_7_white);
						}
						else
						{
							GlobalService.gI().Use_Potion(this.ID);
							bool flag7 = this.Hp_Mp_Other == 3 || this.Hp_Mp_Other == 4;
							if (flag7)
							{
								MsgShowGift.gift = this;
							}
							Player.setDelaySkill((int)this.indexHotKey, (int)this.timeDelayPotion, true, 0);
						}
					}
				}
			}
		}
	}

	// Token: 0x06000C23 RID: 3107 RVA: 0x000E874C File Offset: 0x000E694C
	public static void LoadDataPotion(DataInputStream iss, bool isSave, sbyte typePotion)
	{
		bool flag = iss == null;
		if (flag)
		{
			bool flag2 = typePotion == 4;
			if (flag2)
			{
				GlobalService.gI().get_DATA(25);
			}
			bool flag3 = typePotion == 8;
			if (flag3)
			{
				GlobalService.gI().get_DATA(18);
			}
		}
		else
		{
			try
			{
				short num = iss.readShort();
				for (int i = 0; i < (int)num; i++)
				{
					short id = iss.readShort();
					short idIcon = iss.readShort();
					string name = iss.readUTF();
					short indexInfoPotion = -1;
					string info = string.Empty;
					bool flag4 = typePotion == 4;
					if (flag4)
					{
						indexInfoPotion = iss.readShort();
					}
					else
					{
						info = iss.readUTF();
					}
					short price = iss.readShort();
					short priceRuby = iss.readShort();
					sbyte isTrade = iss.readByte();
					sbyte hp_Mp_Other = iss.readByte();
					short timeDelay = iss.readShort();
					short value = iss.readShort();
					short timeactive = iss.readShort();
					string nameUse = iss.readUTF();
					Potion potion = Potion.Potion_Tem(4, id, idIcon, name, info, isTrade, price, priceRuby, hp_Mp_Other, timeDelay, value, timeactive, nameUse);
					potion.indexInfoPotion = indexInfoPotion;
					bool flag5 = typePotion == 4;
					if (flag5)
					{
						MainItem.hashPotionTem.put(string.Empty + id.ToString(), potion);
					}
					bool flag6 = typePotion == 8;
					if (flag6)
					{
						MainItem.hashPotionClan.put(string.Empty + id.ToString(), potion);
					}
				}
				if (isSave)
				{
					bool flag7 = typePotion == 4;
					if (flag7)
					{
						GlobalService.VerPotion = iss.readShort();
						SaveRms.saveVer(GlobalService.VerPotion, "VerdataPotion");
					}
					bool flag8 = typePotion == 8;
					if (flag8)
					{
						GlobalService.verPotionClan = iss.readShort();
						SaveRms.saveVer(GlobalService.verPotionClan, "VerdataPotionClan");
					}
				}
				iss.close();
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x06000C24 RID: 3108 RVA: 0x000E8940 File Offset: 0x000E6B40
	public static void UpdateDataPotion(DataInputStream iss, bool isSave, sbyte typePotion)
	{
		bool flag = iss == null;
		if (flag)
		{
			bool flag2 = typePotion == 4;
			if (flag2)
			{
				GlobalService.gI().get_DATA(28);
			}
			bool flag3 = typePotion == 8;
			if (flag3)
			{
				GlobalService.gI().get_DATA(29);
			}
		}
		else
		{
			try
			{
				short num = iss.readShort();
				for (int i = 0; i < (int)num; i++)
				{
					short id = iss.readShort();
					short idIcon = iss.readShort();
					string name = iss.readUTF();
					short indexInfoPotion = -1;
					string info = string.Empty;
					bool flag4 = typePotion == 4;
					if (flag4)
					{
						indexInfoPotion = iss.readShort();
					}
					else
					{
						info = iss.readUTF();
					}
					int price = iss.readInt();
					short priceRuby = iss.readShort();
					sbyte isTrade = iss.readByte();
					sbyte hp_Mp_Other = iss.readByte();
					short timeDelay = iss.readShort();
					short value = iss.readShort();
					short timeactive = iss.readShort();
					string nameUse = iss.readUTF();
					Potion potion = Potion.Update_Potion_Tem(4, id, idIcon, name, info, isTrade, price, priceRuby, hp_Mp_Other, timeDelay, value, timeactive, nameUse);
					potion.indexInfoPotion = indexInfoPotion;
					bool flag5 = typePotion == 4;
					if (flag5)
					{
						MainItem.hashPotionTem.put(string.Empty + id.ToString(), potion);
					}
					bool flag6 = typePotion == 8;
					if (flag6)
					{
						MainItem.hashPotionClan.put(string.Empty + id.ToString(), potion);
					}
				}
				if (isSave)
				{
					bool flag7 = typePotion == 4;
					if (flag7)
					{
						GlobalService.VerPotion = iss.readShort();
						SaveRms.saveVer(GlobalService.VerPotion, "VerdataPotion");
					}
					bool flag8 = typePotion == 8;
					if (flag8)
					{
						GlobalService.verPotionClan = iss.readShort();
						SaveRms.saveVer(GlobalService.verPotionClan, "VerdataPotionClan");
					}
				}
				iss.close();
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x06000C25 RID: 3109 RVA: 0x000E8B34 File Offset: 0x000E6D34
	public static void LoadDataPotionTemplate(DataInputStream iss, sbyte typePotion)
	{
		try
		{
			short id = iss.readShort();
			short idIcon = iss.readShort();
			string name = iss.readUTF();
			short indexInfoPotion = -1;
			string info = string.Empty;
			bool flag = typePotion == 4;
			if (flag)
			{
				indexInfoPotion = iss.readShort();
			}
			else
			{
				info = iss.readUTF();
			}
			int price = iss.readInt();
			short priceRuby = iss.readShort();
			sbyte isTrade = iss.readByte();
			sbyte hp_Mp_Other = iss.readByte();
			short timeDelay = iss.readShort();
			short value = iss.readShort();
			short timeactive = iss.readShort();
			string nameUse = iss.readUTF();
			Potion potion = Potion.Update_Potion_Tem(4, id, idIcon, name, info, isTrade, price, priceRuby, hp_Mp_Other, timeDelay, value, timeactive, nameUse);
			potion.indexInfoPotion = indexInfoPotion;
			potion.isUpdateTem = true;
			bool flag2 = typePotion == 4;
			if (flag2)
			{
				MainItem.hashPotionTem.put(string.Empty + id.ToString(), potion);
			}
			bool flag3 = typePotion == 8;
			if (flag3)
			{
				MainItem.hashPotionClan.put(string.Empty + id.ToString(), potion);
			}
			iss.close();
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C26 RID: 3110 RVA: 0x000E8C6C File Offset: 0x000E6E6C
	public static void CheckAddDataTemplate()
	{
		for (int i = 0; i < Potion.vecPotionDonotData.size(); i++)
		{
			Potion potion = (Potion)Potion.vecPotionDonotData.elementAt(i);
			Potion potion2 = (Potion)MainItem.hashPotionTem.get(string.Empty + potion.ID.ToString());
			bool flag = potion2.isUpdateTem;
			if (flag)
			{
				potion.idIcon = potion2.idIcon;
				potion.name = potion2.name;
				potion.isTrade = potion2.isTrade;
				potion.setdata(potion2.price, potion2.priceRuby, potion2.value, potion2.timeActive, potion2.timeDelayPotion, potion2.Hp_Mp_Other, potion2.nameUse);
				bool flag2 = !potion.getInfoPotion(potion2.indexInfoPotion);
				if (flag2)
				{
					Potion.vecPotionDonotInfo.addElement(potion);
				}
				Potion.vecPotionDonotData.removeElementAt(i);
				i--;
			}
		}
	}

	// Token: 0x06000C27 RID: 3111 RVA: 0x000E8D6C File Offset: 0x000E6F6C
	public static void checkVecNonInfo(short index, string infonew)
	{
		for (int i = 0; i < Potion.vecPotionDonotInfo.size(); i++)
		{
			Potion potion = (Potion)Potion.vecPotionDonotInfo.elementAt(i);
			bool flag = potion.indexInfoPotion == index;
			if (flag)
			{
				potion.info = infonew;
				potion.setInfoPotion(infonew);
				Potion.vecPotionDonotInfo.removeElement(potion);
				i--;
			}
		}
	}

	// Token: 0x04001309 RID: 4873
	public const sbyte POTION_OTHER = 0;

	// Token: 0x0400130A RID: 4874
	public const sbyte POTION_HP = 1;

	// Token: 0x0400130B RID: 4875
	public const sbyte POTION_MP = 2;

	// Token: 0x0400130C RID: 4876
	public const sbyte POTION_RUONG = 3;

	// Token: 0x0400130D RID: 4877
	public const sbyte POTION_RUONG_THAN_BI = 4;

	// Token: 0x0400130E RID: 4878
	public const sbyte POTION_DA_KHAM = 12;

	// Token: 0x0400130F RID: 4879
	public const sbyte POTION_HP_MAXLV_PVP_NEW = 96;

	// Token: 0x04001310 RID: 4880
	public const sbyte POTION_MP_PVP_NEW = 97;

	// Token: 0x04001311 RID: 4881
	public const sbyte POTION_HP_PVP_NEW = 98;

	// Token: 0x04001312 RID: 4882
	public const sbyte POTION_EFF_HP = 99;

	// Token: 0x04001313 RID: 4883
	public const sbyte POTION_EFF_HP_2 = 100;

	// Token: 0x04001314 RID: 4884
	public const sbyte POTION_EFF_HP_MAX = 101;

	// Token: 0x04001315 RID: 4885
	public const sbyte POTION_HP_FOCUS = 102;

	// Token: 0x04001316 RID: 4886
	public const sbyte POTION_ATT_CLAN = 103;

	// Token: 0x04001317 RID: 4887
	public const sbyte POTION_HP_FOCUS_LOW = 104;

	// Token: 0x04001318 RID: 4888
	public const sbyte POTION_THONG_THAO = 105;

	// Token: 0x04001319 RID: 4889
	public const sbyte POTION_HP_FOCUS_MAX_LEVEL = 106;

	// Token: 0x0400131A RID: 4890
	public const sbyte POTION_POKE = 40;

	// Token: 0x0400131B RID: 4891
	public const sbyte POTION_THA_DEN = 84;

	// Token: 0x0400131C RID: 4892
	public const sbyte POTION_DOT_PHAO = 100;

	// Token: 0x0400131D RID: 4893
	public static mVector vecPotionDonotData = new mVector("Potion.vecPotionDonotData");

	// Token: 0x0400131E RID: 4894
	public static mVector vecPotionDonotInfo = new mVector("Potion.vecPotionDonotInfo");

	// Token: 0x0400131F RID: 4895
	public short timeActive;

	// Token: 0x04001320 RID: 4896
	public bool isUpdateTem;

	// Token: 0x04001321 RID: 4897
	public static MyHashTable hashInfoPotion = new MyHashTable();
}
