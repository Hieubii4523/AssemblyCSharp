using System;

// Token: 0x020000FF RID: 255
public class TabInventory : MainTabShop
{
	// Token: 0x06000EDF RID: 3807 RVA: 0x0000C083 File Offset: 0x0000A283
	public TabInventory(string name, mVector vec, sbyte typeInventory, int xTab) : base(name, vec, Player.maxInventory, xTab)
	{
		this.typeInventory = typeInventory;
		this.indexIconTab = 0;
	}

	// Token: 0x06000EE0 RID: 3808 RVA: 0x0000C0A4 File Offset: 0x0000A2A4
	public void setTypeInven(sbyte type)
	{
		this.typeInventory = type;
	}

	// Token: 0x06000EE1 RID: 3809 RVA: 0x0011F310 File Offset: 0x0011D510
	public void initCmd()
	{
		mSystem.outz("init tab type " + this.typeInventory.ToString());
		bool flag = this.typeInventory == 7;
		if (flag)
		{
			this.cmdUsePotion = new iCommand(T.cmdUse, 34, this);
			this.cmdDonotUse = new iCommand(T.thaora, 35, this);
			this.cmdMenu = new iCommand(T.select, 10, this);
		}
		else
		{
			bool flag2 = this.typeInventory == 6;
			if (flag2)
			{
				this.cmdUsePotion = new iCommand(T.cmdUse, 32, this);
				this.cmdDonotUse = new iCommand(T.thaora, 33, this);
				this.cmdMenu = new iCommand(T.select, 10, this);
			}
			else
			{
				bool flag3 = this.typeInventory == 4;
				if (flag3)
				{
					this.cmdUsePotion = new iCommand(T.cmdUse, 0, this);
					this.cmdMenu = new iCommand(T.select, 10, this);
				}
				else
				{
					bool flag4 = this.typeInventory == 5;
					if (flag4)
					{
						this.cmdSellMarket = new iCommand(T.sell, 27, this);
						this.cmdMenu = new iCommand(T.select, 10, this);
						this.cmdSellBeri = new iCommand(T.sellBeri, 29, this);
					}
					else
					{
						this.cmdUsePotion = new iCommand(T.cmdUse, 0, this);
						this.cmdSetHotKey = new iCommand(T.cmdHotKey, 1, this);
						this.cmdUseItem = new iCommand(T.cmdUse, 7, this);
						this.cmdSellItem = new iCommand(T.sell, 26, 0, this);
						this.cmdRemoveItem = new iCommand(T.remove, 26, 1, this);
						this.cmdSellAll = new iCommand(T.sellAll, 17, this);
						this.cmdSetChestItem = new iCommand(T.cmdset, 11, 0, this);
						this.cmdSetChestPotion = new iCommand(T.cmdset, 21, 0, this);
						this.cmdMenu = new iCommand(T.select, 10, this);
						this.cmdUpgradeItem = new iCommand(T.Upgrade, 18, this);
						this.cmdAutoMaterial = new iCommand(T.autoMaterial, 19, this);
						this.cmdAllMaterial = new iCommand(T.cattatca, 28, 0, this);
						this.cmdAllDiamond = new iCommand(T.cattatcaDa, 28, 1, this);
						this.cmdChucnang = new iCommand(T.cmdChucNang, 23, this);
						this.cmdMenuMaterial = new iCommand(T.select, 24, this);
						this.cmdMenuSellShop = new iCommand(T.select, 25, this);
						TabInventory.cmdSellWhite = new iCommand(T.itemWhite, 14, this);
						TabInventory.cmdSell_W_G = new iCommand(T.itemWhiteGreen, 15, this);
						TabInventory.cmdSellMore = new iCommand(T.sell, 16, this);
						this.cmdPlusItem = new iCommand(T.plus, 31, this);
					}
				}
			}
		}
	}

	// Token: 0x06000EE2 RID: 3810 RVA: 0x0011F5D4 File Offset: 0x0011D7D4
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
		{
			bool flag = this.itemCur != null && (this.itemCur.typeObject == 4 || this.itemCur.typeObject == 8);
			if (flag)
			{
				this.itemCur.Use_Item();
			}
			break;
		}
		case 1:
			this.getMenuHotKey();
			break;
		case 2:
		{
			bool flag2 = this.itemCur != null && this.itemCur.typeObject == 4;
			if (flag2)
			{
				Player.setHotKey(subIndex, null, this.itemCur);
				Interface_Game.timePaintIconSkill = 100;
			}
			break;
		}
		case 7:
		{
			bool flag3 = this.itemCur != null;
			if (flag3)
			{
				GlobalService.gI().Use_Item(this.itemCur.ID, this.itemCur.typeObject);
			}
			break;
		}
		case 8:
		{
			bool flag4 = this.itemCur == null;
			if (!flag4)
			{
				TabInventory.numSell = 1;
				bool flag5 = this.itemCur.typeObject != 3 && this.input != null;
				if (flag5)
				{
					try
					{
						TabInventory.numSell = (short)int.Parse(this.input.tfInput.getText());
						bool flag6 = TabInventory.numSell < 0;
						if (flag6)
						{
							TabInventory.numSell = 1;
						}
					}
					catch (Exception)
					{
						TabInventory.numSell = 1;
					}
					bool flag7 = TabInventory.numSell > this.itemCur.numPotion;
					if (flag7)
					{
						TabInventory.numSell = this.itemCur.numPotion;
					}
				}
				bool flag8 = subIndex == 0;
				if (flag8)
				{
					bool flag9 = this.itemCur.typeObject == 3;
					int num;
					if (flag9)
					{
						num = (int)(30 + ((short)(this.itemCur.colorName * 2) + this.itemCur.Lv_RQ / 10 + 1) * TabInventory.priceItemSell);
						bool flag10 = num > (int)TabInventory.maxPriceItemSell;
						if (flag10)
						{
							num = (int)TabInventory.maxPriceItemSell;
						}
					}
					else
					{
						num = (int)(TabInventory.numSell * TabInventory.pricePotionSell);
					}
					string info = GameMidlet.format(T.HoiSellENG, new string[]
					{
						TabInventory.numSell.ToString() + string.Empty,
						this.itemCur.name,
						num.ToString() + string.Empty,
						T.bery
					});
					GameCanvas.Start_Normal_DiaLog(info, new iCommand(T.sell, 9, 0, this), true);
				}
				else
				{
					string info2 = GameMidlet.format(T.HoiRemoveENG, new string[]
					{
						string.Empty + TabInventory.numSell.ToString(),
						this.itemCur.name
					});
					GameCanvas.Start_Normal_DiaLog(info2, new iCommand(T.remove, 9, 1, this), true);
				}
			}
			break;
		}
		case 9:
		{
			bool flag11 = this.itemCur != null;
			if (flag11)
			{
				GlobalService.gI().Sell_Item((sbyte)subIndex, this.itemCur.ID, this.itemCur.typeObject, TabInventory.numSell);
				GameCanvas.end_Dialog();
			}
			break;
		}
		case 10:
		{
			mVector menuActionItem = this.getMenuActionItem();
			bool flag12 = menuActionItem != null;
			if (flag12)
			{
				GameCanvas.menu.startAt(menuActionItem, 2, T.menu);
			}
			break;
		}
		case 11:
		{
			bool flag13 = this.itemCur != null;
			if (flag13)
			{
				GlobalService.gI().Chest(1, this.itemCur.ID, this.itemCur.typeObject, 1);
			}
			break;
		}
		case 12:
		{
			GameCanvas.end_Dialog();
			bool flag14 = this.itemCur != null;
			if (flag14)
			{
				bool flag15 = this.itemCur.numPotion == 1;
				if (flag15)
				{
					GlobalService.gI().Chest(1, this.itemCur.ID, this.itemCur.typeObject, 1);
				}
				else
				{
					this.input = GameCanvas.Start_Input_Dialog(T.nhapsoluong, new iCommand(T.cmdset, 13, 0, this), true, this.itemCur.namepaint);
				}
				GameCanvas.subDialog = this.input;
			}
			break;
		}
		case 13:
		{
			bool flag16 = this.itemCur == null;
			if (!flag16)
			{
				int num2 = 1;
				try
				{
					num2 = int.Parse(this.input.tfInput.getText());
					bool flag17 = num2 < 0;
					if (flag17)
					{
						num2 = 1;
					}
				}
				catch (Exception)
				{
					num2 = 1;
				}
				MainItem itemVec = MainItem.getItemVec(this.itemCur.typeObject, this.itemCur.ID, Player.vecInventory);
				bool flag18 = itemVec != null;
				if (flag18)
				{
					bool flag19 = num2 > (int)itemVec.numPotion;
					if (flag19)
					{
						num2 = (int)itemVec.numPotion;
					}
					GameCanvas.end_Dialog();
					GlobalService.gI().Chest(1, this.itemCur.ID, this.itemCur.typeObject, num2);
				}
			}
			break;
		}
		case 14:
			TabInventory.Sell_W(this.vecShop);
			break;
		case 15:
			TabInventory.Sell_W_G(this.vecShop);
			break;
		case 16:
			TabInventory.SellMore();
			break;
		case 17:
		{
			mVector mVector = new mVector();
			mVector.addElement(TabInventory.cmdSellWhite);
			mVector.addElement(TabInventory.cmdSell_W_G);
			GameCanvas.menu.startAt(mVector, 2, T.sellAll);
			break;
		}
		case 18:
		{
			bool flag20 = this.itemCur != null;
			if (flag20)
			{
				GlobalService.gI().Upgrade_Item(1, this.itemCur.ID, 0);
			}
			break;
		}
		case 19:
		{
			mVector mVector2 = new mVector();
			iCommand o = new iCommand(T.cmdNguyenlieu, 20, 1, this);
			mVector2.addElement(o);
			iCommand o2 = new iCommand(T.cmdDaKham, 20, 2, this);
			mVector2.addElement(o2);
			iCommand o3 = new iCommand(T.cmdCaHai, 20, 3, this);
			mVector2.addElement(o3);
			iCommand o4 = new iCommand(T.off, 20, 4, this);
			mVector2.addElement(o4);
			GameCanvas.Start_Normal_DiaLog(T.hoiAutoMaterial, mVector2, false);
			break;
		}
		case 20:
		{
			bool flag21 = subIndex == 4;
			if (flag21)
			{
				Player.isAutoMaterial = 0;
				GameCanvas.saveRms.SaveAutoMaterial();
				GameCanvas.end_Dialog();
			}
			else
			{
				Player.isAutoMaterial = (sbyte)subIndex;
				GameCanvas.saveRms.SaveAutoMaterial();
				bool flag22 = Player.isAutoMaterial == 1 || Player.isAutoMaterial == 3;
				if (flag22)
				{
					Player.SetMaterialToChest(7);
				}
				bool flag23 = Player.isAutoMaterial == 2 || Player.isAutoMaterial == 3;
				if (flag23)
				{
					Player.SetDiamondToChest();
				}
				GameCanvas.end_Dialog();
			}
			break;
		}
		case 21:
		{
			bool flag24 = this.itemCur != null;
			if (flag24)
			{
				bool flag25 = this.itemCur.numPotion == 1;
				if (flag25)
				{
					GlobalService.gI().Chest(1, this.itemCur.ID, this.itemCur.typeObject, 1);
				}
				else
				{
					mVector mVector3 = new mVector();
					iCommand o5 = new iCommand(T.allMaterial, 22, 0, this);
					mVector3.addElement(o5);
					iCommand o6 = new iCommand(T.soluong, 12, 0, this);
					mVector3.addElement(o6);
					GameCanvas.Start_Normal_DiaLog_New(T.muoncatbaonhieu + this.itemCur.namepaint, mVector3, true, this.itemCur.name);
				}
			}
			break;
		}
		case 22:
		{
			bool flag26 = this.itemCur != null;
			if (flag26)
			{
				bool flag27 = subIndex == 0;
				if (flag27)
				{
					GlobalService.gI().Chest(1, this.itemCur.ID, this.itemCur.typeObject, (int)this.itemCur.numPotion);
				}
				GameCanvas.end_Dialog();
			}
			break;
		}
		case 23:
		{
			mVector mVector4 = new mVector();
			mVector4.addElement(this.cmdAllMaterial);
			mVector4.addElement(this.cmdAllDiamond);
			mVector4.addElement(this.cmdAutoMaterial);
			GameCanvas.menu.startAt(mVector4, 2, T.menu);
			break;
		}
		case 24:
		{
			mVector mVector5 = new mVector();
			mVector5.addElement(this.cmdRemoveItem);
			GameCanvas.menu.startAt(mVector5, 2, T.menu);
			break;
		}
		case 25:
		{
			mVector mVector6 = new mVector();
			mVector6.addElement(this.cmdSellItem);
			GameCanvas.menu.startAt(mVector6, 2, T.menu);
			break;
		}
		case 26:
		{
			bool flag28 = this.itemCur.typeObject == 3;
			if (flag28)
			{
				this.commandPointer(8, subIndex);
			}
			else
			{
				bool flag29 = subIndex == 0;
				if (flag29)
				{
					this.input = GameCanvas.Start_Input_Dialog(T.nhapsoluong, new iCommand(T.sell, 8, 0, this), true, this.itemCur.namepaint);
				}
				else
				{
					this.input = GameCanvas.Start_Input_Dialog(T.nhapsoluong, new iCommand(T.remove, 8, 1, this), true, this.itemCur.namepaint);
				}
				GameCanvas.subDialog = this.input;
			}
			break;
		}
		case 27:
		{
			bool flag30 = this.itemCur != null;
			if (flag30)
			{
				bool flag31 = this.itemCur.typeObject == 3;
				if (flag31)
				{
					GlobalService.gI().Market(10, this.indexMarket, this.itemCur.ID, this.itemCur.typeObject, 1);
				}
				else
				{
					this.input = GameCanvas.Start_Input_Dialog(T.nhapsoluong, new iCommand(T.sell, 30, 1, this), true, this.itemCur.namepaint);
					GameCanvas.subDialog = this.input;
				}
			}
			break;
		}
		case 28:
		{
			bool flag32 = subIndex == 0;
			if (flag32)
			{
				Player.SetMaterialToChest(7);
			}
			bool flag33 = subIndex == 1;
			if (flag33)
			{
				Player.SetDiamondToChest();
			}
			break;
		}
		case 29:
			this.input = GameCanvas.Start_Input_Dialog(T.nhapsoluongBeri, new iCommand(T.sell, 30, 0, this), true, T.bery);
			GameCanvas.subDialog = this.input;
			break;
		case 30:
		{
			int num3 = 1;
			try
			{
				num3 = int.Parse(this.input.tfInput.getText());
				bool flag34 = num3 < 0;
				if (flag34)
				{
					num3 = 1;
				}
			}
			catch (Exception)
			{
				num3 = 1;
			}
			bool flag35 = subIndex == 0;
			if (flag35)
			{
				GlobalService.gI().Market(10, this.indexMarket, 0, 4, (short)num3);
			}
			else
			{
				bool flag36 = this.itemCur != null;
				if (flag36)
				{
					GlobalService.gI().Market(10, this.indexMarket, this.itemCur.ID, this.itemCur.typeObject, (short)num3);
				}
			}
			break;
		}
		case 31:
		{
			bool flag37 = GameCanvas.isSSItem == 0;
			if (flag37)
			{
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.huongdanss);
				try
				{
					CRes.saveRMS("SUB_SSITEM", new sbyte[]
					{
						1
					});
				}
				catch (Exception)
				{
				}
				GameCanvas.isSSItem = 1;
			}
			bool flag38 = this.itemCur != null;
			if (flag38)
			{
				MainItem mainItem = (MainItem)GameScreen.player.hashEquip.get(string.Empty + this.itemCur.typeEquip.ToString());
				if (subIndex != 0)
				{
					if (subIndex == 1)
					{
						TabInventory.LvUpgradeSS = 0;
						this.vecInfoSS = MainItem.getInfoSS(this.itemCur);
						this.cmdPlusItem.caption = "  +" + mainItem.LvUpgrade.ToString();
						this.cmdPlusItem.subIndex = 0;
					}
				}
				else
				{
					TabInventory.LvUpgradeSS = (int)mainItem.LvUpgrade;
					this.vecInfoSS = MainItem.getInfoSS(this.itemCur, TabInventory.LvUpgradeSS);
					this.cmdPlusItem.caption = "  +" + this.itemCur.LvUpgrade.ToString();
					this.cmdPlusItem.subIndex = 1;
				}
			}
			break;
		}
		case 32:
		{
			MainItem mainItem2 = (MainItem)this.vecShop.elementAt(this.IdSelect);
			GlobalService.gI().Huy_hieu(2, 1, mainItem2.idIcon);
			break;
		}
		case 33:
		{
			MainItem mainItem3 = (MainItem)this.vecShop.elementAt(this.IdSelect);
			GlobalService.gI().Huy_hieu(2, 0, mainItem3.idIcon);
			break;
		}
		case 34:
		{
			MainItem mainItem4 = (MainItem)this.vecShop.elementAt(this.IdSelect);
			GlobalService.gI().Send_Pet(4, 1, mainItem4.ID);
			break;
		}
		case 35:
		{
			MainItem mainItem5 = (MainItem)this.vecShop.elementAt(this.IdSelect);
			GlobalService.gI().Send_Pet(4, 0, mainItem5.ID);
			break;
		}
		}
	}

	// Token: 0x06000EE3 RID: 3811 RVA: 0x001202C4 File Offset: 0x0011E4C4
	public static void SellMore()
	{
		for (int i = 0; i < TabInventory.vecsell.size(); i++)
		{
			MainItem mainItem = (MainItem)TabInventory.vecsell.elementAt(i);
			GlobalService.gI().Sell_Item(0, mainItem.ID, mainItem.typeObject, 1);
		}
		GameCanvas.end_Dialog();
	}

	// Token: 0x06000EE4 RID: 3812 RVA: 0x00120320 File Offset: 0x0011E520
	public static void Sell_W(mVector vec)
	{
		TabInventory.vecsell.removeAllElements();
		for (int i = 0; i < vec.size(); i++)
		{
			MainItem mainItem = (MainItem)vec.elementAt(i);
			bool flag = mainItem.typeObject == 3 && mainItem.colorName == 0 && mainItem.typeEquip >= 0 && mainItem.typeEquip <= 5;
			if (flag)
			{
				TabInventory.vecsell.addElement(mainItem);
			}
		}
		bool flag2 = TabInventory.vecsell.size() > 0;
		if (flag2)
		{
			GameCanvas.Start_Normal_DiaLog(string.Concat(new string[]
			{
				T.muonban,
				TabInventory.vecsell.size().ToString(),
				" ",
				T.vatpham,
				" ",
				T.itemWhite,
				"?"
			}), TabInventory.cmdSellMore, true);
		}
		else
		{
			GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.noItemWhite);
		}
	}

	// Token: 0x06000EE5 RID: 3813 RVA: 0x0012041C File Offset: 0x0011E61C
	public static void Sell_W_G(mVector vec)
	{
		TabInventory.vecsell.removeAllElements();
		for (int i = 0; i < vec.size(); i++)
		{
			MainItem mainItem = (MainItem)vec.elementAt(i);
			bool flag = mainItem.typeObject == 3 && (mainItem.colorName == 0 || mainItem.colorName == 1) && mainItem.typeEquip >= 0 && mainItem.typeEquip <= 5;
			if (flag)
			{
				TabInventory.vecsell.addElement(mainItem);
			}
		}
		bool flag2 = TabInventory.vecsell.size() > 0;
		if (flag2)
		{
			GameCanvas.Start_Normal_DiaLog(string.Concat(new string[]
			{
				T.muonban,
				TabInventory.vecsell.size().ToString(),
				" ",
				T.vatpham,
				" ",
				T.itemWhiteGreen,
				"?"
			}), TabInventory.cmdSellMore, true);
		}
		else
		{
			GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.noItemWhiteGreen);
		}
	}

	// Token: 0x06000EE6 RID: 3814 RVA: 0x00120520 File Offset: 0x0011E720
	private void getMenuHotKey()
	{
		mVector mVector = new mVector();
		for (int i = 3; i < 5; i++)
		{
			iCommand o = (!GameCanvas.isTouch) ? ((!TField.isQwerty) ? new iCommand(T.keys + " " + (i * 2 + 1).ToString(), 2, i, this) : new iCommand(T.keys + " " + T.mKeyQty[i], 2, i, this)) : new iCommand(T.keys + " " + (i + 1).ToString(), 2, i, this);
			mVector.addElement(o);
		}
		GameCanvas.menu.startAt(mVector, 2, T.cmdHotKey);
	}

	// Token: 0x06000EE7 RID: 3815 RVA: 0x001205E4 File Offset: 0x0011E7E4
	public override mVector getMenuActionItem()
	{
		mVector mVector = null;
		MainItem mainItem = (MainItem)this.vecShop.elementAt(this.IdSelect);
		bool flag = mainItem != null;
		if (flag)
		{
			this.itemCur = mainItem;
			mVector = this.itemCur.getActionInven(this.typeInventory);
			bool flag2 = this.typeInventory == 0;
			if (flag2)
			{
				this.vecInfoSS = MainItem.getInfoSS(this.itemCur);
			}
			bool flag3 = this.typeInventory == 5;
			if (flag3)
			{
				bool flag4 = mVector == null;
				if (flag4)
				{
					mVector = new mVector();
				}
				mVector.addElement(this.cmdSellBeri);
			}
		}
		return mVector;
	}

	// Token: 0x06000EE8 RID: 3816 RVA: 0x00120688 File Offset: 0x0011E888
	public override void addButtonPlus()
	{
		TabInventory.LvUpgradeSS = 0;
		bool flag = this.itemCur == null || this.itemCur.typeObject != 3 || (this.itemCur.charClass != GameScreen.player.clazz && this.itemCur.charClass > 0);
		if (flag)
		{
			bool flag2 = this.cmdPlusItem != null;
			if (flag2)
			{
				this.cmdPlusItem.setPos(-50, -50, AvMain.fraPlus, string.Empty);
			}
		}
		else
		{
			MainItem mainItem = (MainItem)GameScreen.player.hashEquip.get(string.Empty + this.itemCur.typeEquip.ToString());
			bool flag3 = this.itemCur != null && mainItem != null && this.itemCur.LvUpgrade != mainItem.LvUpgrade;
			if (flag3)
			{
				this.cmdPlusItem = new iCommand(T.plus, 31, 0, this);
				int num = this.itemCur.hInfo - this.itemCur.hRunInfo;
				this.cmdPlusItem.setPos(this.xInfo + this.itemCur.wInfo - 10, this.yInfo + num - 10, AvMain.fraPlus, "  +" + mainItem.LvUpgrade.ToString());
			}
			else
			{
				bool flag4 = this.cmdPlusItem != null;
				if (flag4)
				{
					this.cmdPlusItem.setPos(-50, -50, AvMain.fraPlus, string.Empty);
				}
			}
		}
	}

	// Token: 0x06000EE9 RID: 3817 RVA: 0x0012080C File Offset: 0x0011EA0C
	public override void resize(int max)
	{
		this.maxSize = max;
		int limX = ((this.maxSize - 1) / MainTabShop.maxNumItemW + 1) * MainTab.wItem - this.hCur + this.miniItem;
		this.list = new ListNew(this.xCurBegin, this.yCurBegin, this.wCur, this.hCur, 0, 0, limX, true);
		this.scrShop.setInfo(this.xCurBegin + this.wCur + this.miniItem, this.yCurBegin + this.miniItem / 2, this.hCur - this.miniItem * 2, 8809550);
	}

	// Token: 0x06000EEA RID: 3818 RVA: 0x001208B0 File Offset: 0x0011EAB0
	public void Use(short idIcon)
	{
		mSystem.outz("Use " + idIcon.ToString() + " size Shop " + this.vecShop.size().ToString());
		for (int i = 0; i < this.vecShop.size(); i++)
		{
			MainItem mainItem = (MainItem)this.vecShop.elementAt(i);
			bool flag = this.typeInventory == 7;
			if (flag)
			{
				bool flag2 = mainItem.ID == idIcon;
				if (flag2)
				{
					this.IdSelect = i;
					mainItem.colorName = 1;
				}
				else
				{
					mainItem.colorName = 0;
				}
			}
			else
			{
				bool flag3 = mainItem.idIcon == idIcon;
				if (flag3)
				{
					this.IdSelect = i;
					mainItem.colorName = 1;
				}
				else
				{
					mainItem.colorName = 0;
				}
			}
		}
		this.isShowInfo = false;
		this.setPosCmd(this.getMenuActionItem());
	}

	// Token: 0x04001918 RID: 6424
	private sbyte typeInventory;

	// Token: 0x04001919 RID: 6425
	public iCommand cmdUsePotion;

	// Token: 0x0400191A RID: 6426
	public iCommand cmdSetHotKey;

	// Token: 0x0400191B RID: 6427
	public iCommand cmdUseItem;

	// Token: 0x0400191C RID: 6428
	public iCommand cmdRemoveItem;

	// Token: 0x0400191D RID: 6429
	public iCommand cmdSellItem;

	// Token: 0x0400191E RID: 6430
	public iCommand cmdSetChestItem;

	// Token: 0x0400191F RID: 6431
	public iCommand cmdSetChestPotion;

	// Token: 0x04001920 RID: 6432
	public iCommand cmdSellAll;

	// Token: 0x04001921 RID: 6433
	public iCommand cmdUpgradeItem;

	// Token: 0x04001922 RID: 6434
	public iCommand cmdAutoMaterial;

	// Token: 0x04001923 RID: 6435
	public iCommand cmdAllMaterial;

	// Token: 0x04001924 RID: 6436
	public iCommand cmdChucnang;

	// Token: 0x04001925 RID: 6437
	public iCommand cmdMenuMaterial;

	// Token: 0x04001926 RID: 6438
	public iCommand cmdMenuSellShop;

	// Token: 0x04001927 RID: 6439
	public iCommand cmdSellMarket;

	// Token: 0x04001928 RID: 6440
	public iCommand cmdAllDiamond;

	// Token: 0x04001929 RID: 6441
	public iCommand cmdSellBeri;

	// Token: 0x0400192A RID: 6442
	public iCommand cmdDonotUse;

	// Token: 0x0400192B RID: 6443
	public static iCommand cmdSellWhite;

	// Token: 0x0400192C RID: 6444
	public static iCommand cmdSell_W_G;

	// Token: 0x0400192D RID: 6445
	public static iCommand cmdSellMore;

	// Token: 0x0400192E RID: 6446
	public static short priceItemSell;

	// Token: 0x0400192F RID: 6447
	public static short maxPriceItemSell;

	// Token: 0x04001930 RID: 6448
	public static short pricePotionSell;

	// Token: 0x04001931 RID: 6449
	public static short numSell = 1;

	// Token: 0x04001932 RID: 6450
	public static mVector vecsell = new mVector("TabInventory.vecsell");

	// Token: 0x04001933 RID: 6451
	public static int LvUpgradeSS = 0;
}
