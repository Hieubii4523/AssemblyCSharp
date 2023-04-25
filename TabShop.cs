using System;

// Token: 0x02000103 RID: 259
public class TabShop : MainTabShop
{
	// Token: 0x06000F0F RID: 3855 RVA: 0x00122048 File Offset: 0x00120248
	public TabShop(string name, mVector vec, sbyte typeShop, int xTab) : base(name, vec, vec.size(), xTab)
	{
		this.typeNPCShop = typeShop;
		this.indexIconTab = 1;
		bool flag = typeShop == 6;
		if (flag)
		{
			this.indexIconTab = 8;
		}
		bool flag2 = this.typeNPCShop == 103;
		if (flag2)
		{
			this.addWearingHair(-1, 0);
		}
		else
		{
			bool flag3 = this.typeNPCShop == 112;
			if (flag3)
			{
				this.addWearingHair(-1, 0);
			}
			else
			{
				bool flag4 = this.typeNPCShop == 105 || this.typeNPCShop == 113 || this.typeNPCShop == 114;
				if (flag4)
				{
					this.addWearingFashion(-1, null);
				}
			}
		}
		TabShop.cmdShip = new iCommand(T.ship, 11, this);
		TabShop.cmdChangeShip = new iCommand(T.changeship, 12, this);
		TabShop.cmdUse = new iCommand(T.cmdUse, 13, this);
		TabShop.cmdDonotUse = new iCommand(T.thaora, 13, this);
		this.initCmd();
		this.beginFocus();
	}

	// Token: 0x06000F10 RID: 3856 RVA: 0x00122168 File Offset: 0x00120368
	public void initCmd()
	{
		this.cmdMenu = new iCommand(T.select, 10, this);
		mSystem.outz(this.typeNPCShop.ToString() + " pppppppppp");
		TabShop.cmdBuyHair = new iCommand(T.select, 3, 1, this);
		TabShop.cmdBuyPotion = new iCommand(T.cmdBuy, 4, this);
		TabShop.cmdBuyItem = new iCommand(T.cmdBuy, 3, 0, this);
		TabShop.cmdBuyIconClan = new iCommand(T.select, 3, 2, this);
		TabShop.cmdOpenRebuildItem = new iCommand(T.Upgrade, 15, this);
		TabShop.cmdOpenMenuDaKham = new iCommand(T.menu, 16, this);
		bool flag = this.typeNPCShop == 113 || this.typeNPCShop == 114;
		if (flag)
		{
			TabShop.cmdBuyHair = new iCommand(T.select, 3, 3, this);
		}
	}

	// Token: 0x06000F11 RID: 3857 RVA: 0x00122240 File Offset: 0x00120440
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 3:
		{
			bool flag = this.itemCur == null;
			if (!flag)
			{
				bool flag2 = this.typeNPCShop == 116 || this.typeNPCShop == 118;
				if (flag2)
				{
					GameCanvas.Start_Normal_DiaLog(T.banmuonchon + this.itemCur.namepaint + ".", new iCommand(T.doiqua, 5, 1, this), true);
				}
				else
				{
					switch (subIndex)
					{
					case 1:
					{
						string str = string.Concat(new string[]
						{
							T.price,
							" ",
							this.itemCur.price.ToString(),
							" ",
							T.bery,
							"."
						});
						bool flag3 = this.itemCur.price == 0;
						if (flag3)
						{
							str = string.Concat(new string[]
							{
								T.price,
								" ",
								this.itemCur.priceRuby.ToString(),
								" ",
								T.ruby,
								"."
							});
						}
						bool flag4 = this.itemCur.price <= 0 && this.itemCur.priceRuby <= 0;
						if (flag4)
						{
							str = string.Empty;
						}
						GameCanvas.Start_Normal_DiaLog(T.hoiMuaItem + this.itemCur.name + "?\n" + str, new iCommand(T.cmdBuy, 5, 1, this), true);
						break;
					}
					case 2:
					{
						bool flag5 = this.itemCur.priceRuby == 0;
						if (flag5)
						{
							GameCanvas.Start_Normal_DiaLog(T.banmuonchon + this.itemCur.name + T.lamcohieu, new iCommand(T.select, 5, 1, this), true);
						}
						else
						{
							GameCanvas.Start_Normal_DiaLog(string.Concat(new string[]
							{
								T.banmuonchon,
								this.itemCur.name,
								T.lamcohieu,
								" ",
								T.price,
								" ",
								this.itemCur.priceRuby.ToString(),
								" ",
								T.ruby,
								"."
							}), new iCommand(T.select, 5, 1, this), true);
						}
						break;
					}
					case 3:
						GameCanvas.Start_Normal_DiaLog(T.banmuonchon + this.itemCur.name + "?", new iCommand(T.select, 5, 1, this), true);
						break;
					default:
						GameCanvas.Start_Normal_DiaLog(T.hoiMuaItem + "1 " + this.itemCur.name + "?", new iCommand(T.cmdBuy, 5, 1, this), true);
						break;
					}
				}
			}
			break;
		}
		case 4:
		{
			bool flag6 = this.itemCur == null;
			if (!flag6)
			{
				bool flag7 = this.typeNPCShop == 116 || this.typeNPCShop == 118;
				if (flag7)
				{
					GameCanvas.Start_Normal_DiaLog(T.banmuonchon + this.itemCur.namepaint + ".", new iCommand(T.doiqua, 5, 1, this), true);
				}
				else
				{
					mVector mVector = new mVector();
					string str2 = string.Empty;
					str2 = ((this.itemCur.price <= 0) ? string.Concat(new string[]
					{
						"(",
						this.itemCur.priceRuby.ToString(),
						" ",
						T.ruby,
						" / 1 ",
						T.mon,
						")"
					}) : string.Concat(new string[]
					{
						"(",
						this.itemCur.price.ToString(),
						" ",
						T.bery,
						" / 1 ",
						T.mon,
						")"
					}));
					for (int i = 0; i < this.mNumBuyRuby.Length; i++)
					{
						iCommand iCommand = new iCommand("x" + this.mNumBuyRuby[i].ToString(), 14, this.mNumBuyRuby[i], this);
						bool isTouch = GameCanvas.isTouch;
						if (isTouch)
						{
							iCommand.levelSmall = 3;
						}
						mVector.addElement(iCommand);
					}
					string info = string.Empty;
					info = T.hoiMua + "\n" + str2;
					GameCanvas.Start_Normal_DiaLog_New(info, mVector, true, this.itemCur.name);
				}
			}
			break;
		}
		case 5:
		{
			bool flag8 = this.itemCur != null;
			if (flag8)
			{
				GlobalService.gI().Buy_Item_Potion(this.typeNPCShop, this.itemCur.ID, 1, this.itemCur.typeObject);
				GameCanvas.Start_Waiting_DiaLog(T.pleaseWaiting, true);
			}
			break;
		}
		case 6:
		{
			bool flag9 = this.itemCur == null;
			if (!flag9)
			{
				int num = 1;
				try
				{
					num = int.Parse(this.input.tfInput.getText());
					bool flag10 = num < 0;
					if (flag10)
					{
						num = 1;
					}
				}
				catch (Exception)
				{
					num = 1;
				}
				GameCanvas.end_Dialog();
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.pleaseWaiting);
				GlobalService.gI().Buy_Item_Potion(this.typeNPCShop, this.itemCur.ID, (short)num, this.itemCur.typeObject);
			}
			break;
		}
		case 10:
		{
			mVector menuActionItem = this.getMenuActionItem();
			bool flag11 = menuActionItem != null;
			if (flag11)
			{
				GameCanvas.menu.startAt(menuActionItem, 2, T.menu);
			}
			break;
		}
		case 11:
			GlobalService.gI().Ship(1);
			break;
		case 12:
			GlobalService.gI().Ship(0);
			break;
		case 13:
		{
			bool flag12 = this.itemCur != null;
			if (flag12)
			{
				GlobalService.gI().Use_Item(this.itemCur.ID, this.itemCur.typeObject);
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.pleaseWaiting);
			}
			break;
		}
		case 14:
		{
			bool flag13 = this.tickbuy <= 0;
			if (flag13)
			{
				GlobalService.gI().Buy_Item_Potion(this.typeNPCShop, this.itemCur.ID, (short)subIndex, this.itemCur.typeObject);
				this.tickbuy = 5;
			}
			else
			{
				mSystem.outloi("bo qua");
			}
			break;
		}
		case 15:
		{
			bool flag14 = ScreenUpgrade.curTypeShop == 18;
			if (flag14)
			{
				GlobalService.gI().Upgrade_Dial(7, 0, 0, 0);
			}
			else
			{
				bool flag15 = ScreenUpgrade.curTypeShop == 15;
				if (flag15)
				{
					GlobalService.gI().Upgrade_Super_Item(7, 0, 0, 0);
				}
				else
				{
					GlobalService.gI().Upgrade_Item(7, 0, 0);
				}
			}
			break;
		}
		case 16:
			this.getMenuDaKham();
			break;
		case 17:
			GlobalService.gI().Upgrade_Item((sbyte)subIndex, 0, 0);
			break;
		}
	}

	// Token: 0x06000F12 RID: 3858 RVA: 0x00122968 File Offset: 0x00120B68
	private void getMenuDaKham()
	{
		mVector mVector = new mVector();
		iCommand o = new iCommand(T.tabkhamda, 17, 9, this);
		mVector.addElement(o);
		iCommand o2 = new iCommand(T.tabupgradeDa, 17, 12, this);
		mVector.addElement(o2);
		iCommand o3 = new iCommand(T.tabdutlo, 17, 10, this);
		mVector.addElement(o3);
		iCommand o4 = new iCommand(T.tablayda, 17, 13, this);
		mVector.addElement(o4);
		GameCanvas.menuCur.startAt(mVector, 2, T.menu);
	}

	// Token: 0x06000F13 RID: 3859 RVA: 0x001229F0 File Offset: 0x00120BF0
	public override mVector getMenuActionItem()
	{
		mVector result = null;
		MainItem mainItem = (MainItem)this.vecShop.elementAt(this.IdSelect);
		bool flag = mainItem != null;
		if (flag)
		{
			this.itemCur = mainItem;
			bool flag2 = !this.isSelect;
			if (flag2)
			{
				return null;
			}
			result = this.itemCur.getActionShop(this.typeNPCShop);
			bool flag3 = this.typeNPCShop == 103;
			if (flag3)
			{
				this.addWearingHair(7, (int)this.itemCur.idIcon);
			}
			else
			{
				bool flag4 = this.typeNPCShop == 112;
				if (flag4)
				{
					this.addWearingHair(6, (int)this.itemCur.idIcon);
				}
				else
				{
					bool flag5 = this.typeNPCShop == 105 || this.typeNPCShop == 113 || this.typeNPCShop == 114;
					if (flag5)
					{
						this.addWearingFashion(7, this.itemCur.mWearing);
					}
				}
			}
		}
		else
		{
			bool flag6 = this.typeNPCShop == 103;
			if (flag6)
			{
				this.addWearingHair(7, (int)GameScreen.player.hair);
			}
			else
			{
				bool flag7 = this.typeNPCShop == 112;
				if (flag7)
				{
					this.addWearingHair(6, (int)GameScreen.player.head);
				}
				else
				{
					bool flag8 = this.typeNPCShop == 105;
					if (flag8)
					{
						this.addWearingFashion(-1, null);
					}
				}
			}
		}
		return result;
	}

	// Token: 0x06000F14 RID: 3860 RVA: 0x00122B50 File Offset: 0x00120D50
	public override void paintItemCur(mGraphics g, MainItem Item, int x, int y)
	{
		bool flag = MainTabShop.itemShipCur != null && Item.typeObject == MainTabShop.itemShipCur.typeObject && Item.ID == MainTabShop.itemShipCur.ID && this.typeNPCShop == 101;
		if (flag)
		{
			g.drawImage(AvMain.imgcheck, x, y, mGraphics.RIGHT | mGraphics.BOTTOM);
		}
	}

	// Token: 0x06000F15 RID: 3861 RVA: 0x00122BB8 File Offset: 0x00120DB8
	public override void paintShowBoat(mGraphics g, int x, int y)
	{
		bool flag = this.typeNPCShop == 102;
		if (flag)
		{
			bool flag2 = GameScreen.player.myBoat == null;
			if (!flag2)
			{
				for (int i = 0; i < GameScreen.player.myBoat.Length; i++)
				{
					bool flag3 = this.itemCur != null && i == (int)this.itemCur.typeBoat;
					if (flag3)
					{
						ItemBoat.paintPartBoat(g, this.itemCur.idPart, (int)this.itemCur.typeBoat, x, y, 0, 0);
					}
					else
					{
						ItemBoat.paintPartBoat(g, GameScreen.player.myBoat[i], i, x, y, 0, 0);
					}
				}
				ItemBoat.paintPartBoat(g, 0, 100, x, y, 0, 0);
			}
		}
		else
		{
			bool flag4 = this.typeNPCShop == 103 || this.typeNPCShop == 105 || this.typeNPCShop == 112 || this.typeNPCShop == 113 || this.typeNPCShop == 114;
			if (flag4)
			{
				TabShop.objPaint.paintShadow(g, x, y + 4);
				TabShop.objPaint.paintCharShow(g, x, y + 4, 0, true);
			}
		}
	}

	// Token: 0x06000F16 RID: 3862 RVA: 0x00122CDC File Offset: 0x00120EDC
	public override void updateBuyItem(short id, sbyte type)
	{
		for (int i = 0; i < this.vecShop.size(); i++)
		{
			MainItem mainItem = (MainItem)this.vecShop.elementAt(i);
			bool flag = mainItem.typeObject == type && mainItem.ID == id;
			if (flag)
			{
				mainItem.price = 0;
				mainItem.priceRuby = 0;
				mainItem.vecInfo.removeAllElements();
				mainItem.addInfoFrist(T.dasuhuu, 1);
				mainItem.isShop = true;
				bool flag2 = mainItem.info != null && mainItem.info.Length > 0;
				if (flag2)
				{
					mainItem.setInfoPotion(mainItem.info);
				}
				mainItem.colorName = 1;
				break;
			}
		}
	}

	// Token: 0x06000F17 RID: 3863 RVA: 0x00122DA0 File Offset: 0x00120FA0
	public override void updateTrangBi()
	{
		bool flag = this.typeNPCShop == 103 || this.typeNPCShop == 112;
		if (flag)
		{
			int num = (int)GameScreen.player.hair;
			bool flag2 = this.typeNPCShop == 112;
			if (flag2)
			{
				num = (int)GameScreen.player.head;
			}
			for (int i = 0; i < this.vecShop.size(); i++)
			{
				MainItem mainItem = (MainItem)this.vecShop.elementAt(i);
				bool flag3 = mainItem.price == 0 && mainItem.priceRuby == 0;
				if (flag3)
				{
					mainItem.vecInfo.removeAllElements();
					bool flag4 = (int)mainItem.idIcon == num;
					if (flag4)
					{
						mainItem.addInfoFrist(T.daTrangBi, 4);
						mainItem.colorName = 4;
					}
					else
					{
						mainItem.addInfoFrist(T.dasuhuu, 1);
						mainItem.colorName = 1;
					}
				}
			}
		}
		else
		{
			bool flag5 = this.typeNPCShop == 102;
			if (flag5)
			{
				for (int j = 0; j < this.vecShop.size(); j++)
				{
					MainItem mainItem2 = (MainItem)this.vecShop.elementAt(j);
					bool flag6 = mainItem2.price != 0 || mainItem2.priceRuby != 0;
					if (!flag6)
					{
						for (int k = 0; k < GameScreen.player.myBoat.Length; k++)
						{
							bool flag7 = (int)mainItem2.typeBoat == k;
							if (flag7)
							{
								mainItem2.vecInfo.removeAllElements();
								bool flag8 = mainItem2.idPart == GameScreen.player.myBoat[k];
								if (flag8)
								{
									mainItem2.colorName = 4;
									mainItem2.addInfoFrist(T.daTrangBi, 4);
								}
								else
								{
									mainItem2.colorName = 1;
									mainItem2.addInfoFrist(T.dasuhuu, 1);
								}
							}
						}
					}
				}
			}
			else
			{
				bool flag9 = this.typeNPCShop == 105 || this.typeNPCShop == 113;
				if (flag9)
				{
					for (int l = 0; l < this.vecShop.size(); l++)
					{
						MainItem mainItem3 = (MainItem)this.vecShop.elementAt(l);
						bool flag10 = mainItem3.price != 0 || mainItem3.priceRuby != 0;
						if (!flag10)
						{
							mainItem3.vecInfo.removeAllElements();
							bool flag11 = mainItem3.ID == Player.idFashion;
							if (flag11)
							{
								mainItem3.addInfoFrist(T.daTrangBi, 4);
								mainItem3.colorName = 4;
								mainItem3.isShop = true;
								bool flag12 = mainItem3.info.Length > 0;
								if (flag12)
								{
									mainItem3.setInfoPotion(mainItem3.info);
								}
							}
							else
							{
								mainItem3.addInfoFrist(T.dasuhuu, 1);
								mainItem3.colorName = 1;
								mainItem3.isShop = true;
								bool flag13 = mainItem3.info.Length > 0;
								if (flag13)
								{
									mainItem3.setInfoPotion(mainItem3.info);
								}
							}
						}
					}
				}
			}
		}
		this.setPosCmd(this.getMenuActionItem());
	}

	// Token: 0x06000F18 RID: 3864 RVA: 0x001230E8 File Offset: 0x001212E8
	public void addWearingHair(int type, int value)
	{
		if (type != -1)
		{
			if (type != 6)
			{
				if (type == 7)
				{
					TabShop.objPaint.sethair((short)value);
					this.hairEff = (short)value;
					TabShop.objPaint.nFrameEffHair = 0;
					TabShop.objPaint.nFrameEffHead = 0;
				}
			}
			else
			{
				TabShop.objPaint.sethead((short)value);
			}
		}
		else
		{
			bool flag = GameScreen.player != null;
			if (flag)
			{
				TabShop.objPaint.sethead(GameScreen.player.head);
				TabShop.objPaint.sethair(GameScreen.player.hair);
				TabShop.objPaint.body = GameScreen.player.body;
				TabShop.objPaint.leg = GameScreen.player.leg;
				TabShop.objPaint.weapon = GameScreen.player.weapon;
				TabShop.objPaint.clazz = GameScreen.player.clazz;
				TabShop.objPaint.nFrameEffHair = 0;
				TabShop.objPaint.nFrameEffHead = 0;
				TabShop.objPaint.setHeadBigBody();
			}
		}
	}

	// Token: 0x06000F19 RID: 3865 RVA: 0x00123200 File Offset: 0x00121400
	public void addWearingFashion(int type, short[] mwearing)
	{
		bool flag = GameScreen.player != null;
		if (flag)
		{
			TabShop.objPaint.sethead(GameScreen.player.head);
			TabShop.objPaint.sethair(GameScreen.player.hair);
			TabShop.objPaint.body = GameScreen.player.body;
			TabShop.objPaint.leg = GameScreen.player.leg;
			TabShop.objPaint.weapon = GameScreen.player.weapon;
			TabShop.objPaint.hat = GameScreen.player.hat;
			TabShop.objPaint.nFrameEffHair = 0;
			TabShop.objPaint.nFrameEffHead = 0;
			TabShop.objPaint.clazz = GameScreen.player.clazz;
			TabShop.objPaint.setHeadBigBody();
		}
		bool flag2 = type != -1;
		if (flag2)
		{
			TabShop.objPaint.setWearingIsNull(mwearing);
			TabShop.objPaint.clazz = GameScreen.player.clazz;
			TabShop.objPaint.setHeadBigBody();
		}
	}

	// Token: 0x06000F1A RID: 3866 RVA: 0x00123308 File Offset: 0x00121508
	public override iCommand getCmdLeft()
	{
		bool flag = this.typeNPCShop == 6;
		iCommand result;
		if (flag)
		{
			result = TabShop.cmdOpenRebuildItem;
		}
		else
		{
			bool flag2 = this.typeNPCShop == 111;
			if (flag2)
			{
				result = TabShop.cmdOpenMenuDaKham;
			}
			else
			{
				result = null;
			}
		}
		return result;
	}

	// Token: 0x06000F1B RID: 3867 RVA: 0x00123348 File Offset: 0x00121548
	public override void updateInshop()
	{
		bool flag = (this.typeNPCShop != 103 && this.typeNPCShop != 105 && this.typeNPCShop != 112 && this.typeNPCShop != 113 && this.typeNPCShop != 114) || TabShop.objPaint == null;
		if (!flag)
		{
			bool flag2 = GameCanvas.gameTick % 100 == 0;
			if (flag2)
			{
				bool flag3 = TabShop.objPaint.isDonotShowHat == 1;
				if (flag3)
				{
					TabShop.objPaint.isDonotShowHat = 0;
				}
				else
				{
					TabShop.objPaint.isDonotShowHat = 1;
				}
			}
			bool flag4 = this.typeNPCShop == 103 && this.hairEff == 772 && GameCanvas.gameTick % 60 == 0;
			if (flag4)
			{
				TabShop.objPaint.sethair(this.hairEff + this.demhairEff % 3);
				TabShop.objPaint.nFrameEffHair = 0;
				this.demhairEff += 1;
			}
		}
	}

	// Token: 0x0400194B RID: 6475
	public static iCommand cmdBuyItem;

	// Token: 0x0400194C RID: 6476
	public static iCommand cmdBuyPotion;

	// Token: 0x0400194D RID: 6477
	public static iCommand cmdShip;

	// Token: 0x0400194E RID: 6478
	public static iCommand cmdChangeShip;

	// Token: 0x0400194F RID: 6479
	public static iCommand cmdUse;

	// Token: 0x04001950 RID: 6480
	public static iCommand cmdDonotUse;

	// Token: 0x04001951 RID: 6481
	public static iCommand cmdBuyHair;

	// Token: 0x04001952 RID: 6482
	public static iCommand cmdBuyIconClan;

	// Token: 0x04001953 RID: 6483
	public static iCommand cmdOpenRebuildItem;

	// Token: 0x04001954 RID: 6484
	public static iCommand cmdOpenMenuDaKham;

	// Token: 0x04001955 RID: 6485
	public static MainObject objPaint = new MainObject();

	// Token: 0x04001956 RID: 6486
	public bool isSelect = true;

	// Token: 0x04001957 RID: 6487
	private int[] mNumBuyRuby = new int[]
	{
		1,
		5,
		20
	};

	// Token: 0x04001958 RID: 6488
	private short hairEff = -1;

	// Token: 0x04001959 RID: 6489
	private short demhairEff;
}
