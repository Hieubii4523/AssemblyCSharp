using System;

// Token: 0x020000E5 RID: 229
public class ScreenMarket : MainTab
{
	// Token: 0x06000DB6 RID: 3510 RVA: 0x00109180 File Offset: 0x00107380
	public ScreenMarket(string nameTab, mVector vec, TabScreen tab, sbyte indexMarket)
	{
		this.ScrTab = tab;
		this.nameTab = nameTab;
		this.vecList = vec;
		this.indexMarket = indexMarket;
		this.setIconTab();
		MainTab.wItem = 28;
		bool isBigScreen = this.isBigScreen;
		if (isBigScreen)
		{
			MainTab.wItem = 32;
		}
		this.wItemCur = 44;
		int num = 0;
		bool flag = this.vecList != null;
		if (flag)
		{
			num = this.vecList.size();
		}
		int limX = num * this.wItemCur - this.hCur + this.miniItem * 3;
		this.list = new ListNew(this.xCurBegin, this.yCurBegin, this.wCur, this.hCur, 0, 0, limX, true);
		this.xCurBegin = tab.xbeginPaintTab + MainTab.wTab / 2 - this.wCur / 2 + 10;
		this.beginFocus();
		this.setCreateCmd();
	}

	// Token: 0x06000DB7 RID: 3511 RVA: 0x0010927C File Offset: 0x0010747C
	public void setCreateCmd()
	{
		this.cmdPlusItem = new iCommand(T.plus, 8, this);
		this.vecCmd.removeAllElements();
		bool flag = this.vecList == null;
		if (flag)
		{
			this.cmdUpdate = new iCommand(T.update, 2, this);
			AvMain.setPosCMD(this.cmdUpdate, 0);
			this.vecCmd.addElement(this.cmdUpdate);
			bool flag2 = !GameCanvas.isTouch;
			if (flag2)
			{
				this.center = this.cmdUpdate;
			}
			this.okCMD = this.cmdUpdate;
		}
		else
		{
			bool flag3 = this.indexMarket == 3;
			if (flag3)
			{
				this.cmdGet = new iCommand(T.cmdGet, 3, this);
				AvMain.setPosCMD(this.cmdGet, 0);
				this.cmdSell = new iCommand(T.sell, 6, this);
				AvMain.setPosCMD(this.cmdSell, 1);
				this.cmdCancleSell = new iCommand(T.stopSell, 5, this);
				AvMain.setPosCMD(this.cmdCancleSell, 1);
			}
			else
			{
				this.cmdBuy = new iCommand(T.cmdBuy, 0, this);
				AvMain.setPosCMD(this.cmdBuy, 0);
				this.cmdSelectPage = new iCommand(T.selectPage, 1, this);
				AvMain.setPosCMD(this.cmdSelectPage, 1);
				this.vecCmd.addElement(this.cmdBuy);
				this.vecCmd.addElement(this.cmdSelectPage);
				bool flag4 = !GameCanvas.isTouch;
				if (flag4)
				{
					this.left = this.cmdSelectPage;
					this.center = this.cmdBuy;
				}
				this.menuCMD = this.cmdSelectPage;
				this.okCMD = this.cmdBuy;
			}
		}
	}

	// Token: 0x06000DB8 RID: 3512 RVA: 0x00109424 File Offset: 0x00107624
	private void setIconTab()
	{
		bool flag = this.indexMarket == 0;
		if (flag)
		{
			this.indexIconTab = 9;
		}
		else
		{
			bool flag2 = this.indexMarket == 1;
			if (flag2)
			{
				this.indexIconTab = 10;
			}
			else
			{
				bool flag3 = this.indexMarket == 2;
				if (flag3)
				{
					this.indexIconTab = 11;
				}
				else
				{
					bool flag4 = this.indexMarket == 3;
					if (flag4)
					{
						this.indexIconTab = 7;
					}
					else
					{
						bool flag5 = this.indexMarket == 4;
						if (flag5)
						{
							this.indexIconTab = 0;
						}
						else
						{
							bool flag6 = this.indexMarket == 5;
							if (flag6)
							{
								this.indexIconTab = 12;
							}
							else
							{
								bool flag7 = this.indexMarket == 6;
								if (flag7)
								{
									this.indexIconTab = 13;
								}
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x06000DB9 RID: 3513 RVA: 0x001094E8 File Offset: 0x001076E8
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
		{
			bool flag = this.itemCur != null;
			if (flag)
			{
				GlobalService.gI().Market(0, this.indexMarket, this.itemCur.IDMarket, this.itemCur.typeObject, 1);
			}
			break;
		}
		case 1:
			GlobalService.gI().Market(8, this.indexMarket, 0, 0, 1);
			break;
		case 2:
			GlobalService.gI().Market(9, this.indexMarket, 0, 0, 1);
			break;
		case 3:
		{
			bool flag2 = this.itemCur != null;
			if (flag2)
			{
				GlobalService.gI().Market(5, this.indexMarket, this.itemCur.IDMarket, this.itemCur.typeObject, 1);
			}
			break;
		}
		case 4:
		{
			bool flag3 = this.itemCur != null;
			if (flag3)
			{
				GlobalService.gI().Market(7, this.indexMarket, this.itemCur.IDMarket, this.itemCur.typeObject, 1);
			}
			break;
		}
		case 5:
		{
			bool flag4 = this.itemCur != null;
			if (flag4)
			{
				GlobalService.gI().Market(6, this.indexMarket, this.itemCur.IDMarket, this.itemCur.typeObject, 1);
			}
			break;
		}
		case 6:
		{
			bool flag5 = this.itemCur != null;
			if (flag5)
			{
				bool flag6 = this.itemCur.typeObject == 3;
				if (flag6)
				{
					GlobalService.gI().Market(11, this.indexMarket, this.itemCur.IDMarket, this.itemCur.typeObject, 1);
				}
				else
				{
					GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.banPotion);
				}
			}
			break;
		}
		case 8:
		{
			bool flag7 = this.itemCur != null;
			if (flag7)
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
		}
	}

	// Token: 0x06000DBA RID: 3514 RVA: 0x001097B8 File Offset: 0x001079B8
	public override void beginFocus()
	{
		this.setCreateCmd();
		bool flag = GameCanvas.isTouchNoOrPC();
		if (flag)
		{
			this.IdSelect = 0;
			this.getItemCurNew();
		}
		else
		{
			this.IdSelect = -1;
		}
	}

	// Token: 0x06000DBB RID: 3515 RVA: 0x001097F4 File Offset: 0x001079F4
	public override void paint(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		AvMain.paintRect(g, this.xCurBegin, this.yCurBegin, this.wCur, this.hCur - this.miniItem, 0, 4);
		int num = this.miniItem;
		int num2 = 2;
		bool flag = this.vecCmd != null && GameCanvas.getShowCmd() && (GameCanvas.currentScreen.setCurTypetab(1) || GameCanvas.isTouch);
		if (flag)
		{
			for (int i = 0; i < this.vecCmd.size(); i++)
			{
				iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
				iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
			}
		}
		bool flag2 = this.vecList == null;
		if (flag2)
		{
			mFont.tahoma_7b_white.drawString(g, T.nullData, num2 + this.wCur / 2, num + MainTab.wItem + 2, 2);
			GameCanvas.resetTrans(g);
		}
		else
		{
			this.setClip(g);
			int num3 = this.list.cmx / this.wItemCur - 1;
			int num4 = this.hCur / this.wItemCur + 3 + num3;
			num += this.wItemCur * num3;
			for (int j = num3; j < num4; j++)
			{
				bool flag3 = j >= 0 && j < this.vecList.size();
				if (flag3)
				{
					g.setColor(14075832);
					g.drawRect(2, num + 1, this.wCur - 5, this.wItemCur - 2);
					bool flag4 = this.IdSelect == j && GameCanvas.currentScreen.setCurTypetab(1);
					if (flag4)
					{
						g.setColor(16777215);
						g.drawRect(3, num + 2, this.wCur - 7, this.wItemCur - 4);
					}
					MainItem mainItem = (MainItem)this.vecList.elementAt(j);
					mainItem.paint(g, num2 + MainTab.wItem / 2, num + MainTab.wItem / 2 + 1, MainTab.wItem);
					bool flag5 = mainItem.typeObject == 3;
					if (flag5)
					{
						AvMain.setTextColorName((int)mainItem.colorName).drawString(g, mainItem.name, num2 + MainTab.wItem + 2, num + MainTab.wItem / 2 - 3, 0);
					}
					else
					{
						string str = mainItem.numPotion.ToString() + string.Empty;
						bool flag6 = mainItem.typeObject == 4 && mainItem.ID == 0;
						if (flag6)
						{
							str += "M";
						}
						AvMain.setTextColorName((int)mainItem.colorName).drawString(g, str + " x " + mainItem.name, num2 + MainTab.wItem + 2, num + MainTab.wItem / 2 - 3, 0);
					}
					mFont.tahoma_7_yellow.drawString(g, T.price + " " + AvMain.getDotNumber((long)mainItem.priceVND), num2 + this.miniItem, num + MainTab.wItem, 0);
					bool flag7 = this.indexMarket == 3 && mainItem.typeMarket != 1;
					if (flag7)
					{
						bool flag8 = mainItem.typeMarket >= 0 && (int)mainItem.typeMarket < T.mtypeMarket.Length;
						if (flag8)
						{
							mFont.tahoma_7_yellow.drawString(g, T.mtypeMarket[(int)mainItem.typeMarket], num2 + this.wCur - 6, num + MainTab.wItem, 1);
						}
					}
					else
					{
						mainItem.marketTime.paintCountDownTicketHour(g, mFont.tahoma_7_white, num2 + this.wCur - 32, num + MainTab.wItem, 0);
					}
				}
				num += this.wItemCur;
			}
			mGraphics.resetTransAndroid(g);
			g.restoreCanvas();
			GameCanvas.resetTrans(g);
			bool flag9 = this.isShowInfo && GameCanvas.currentScreen.setCurTypetab(1) && this.itemCur != null;
			if (flag9)
			{
				base.ShowInfo(g, this.itemCur, this.vecInfoSS, 0, this.xInfo, this.yInfo, false, null, TabInventory.LvUpgradeSS);
				bool flag10 = this.cmdPlusItem != null;
				if (flag10)
				{
					this.cmdPlusItem.paintXY(g, this.cmdPlusItem.xCmd, this.cmdPlusItem.yCmd);
				}
			}
		}
		Interface_Game.paintEffShowMoney(g, MotherCanvas.hw - Interface_Game.wMoneyEff / 2, GameScreen.h12plus, false, 0);
	}

	// Token: 0x06000DBC RID: 3516 RVA: 0x00109C78 File Offset: 0x00107E78
	public void setClip(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		g.setClip(this.xCurBegin + 2, this.yCurBegin + 1, this.wCur - 4, this.hCur - 1 - this.miniItem - 1);
		g.saveCanvas();
		g.ClipRec(this.xCurBegin + 2, this.yCurBegin + 1, this.wCur - 4, this.hCur - 1 - this.miniItem - 1);
		g.translate(this.xCurBegin, this.yCurBegin);
		g.translate(0, -this.list.cmx);
	}

	// Token: 0x06000DBD RID: 3517 RVA: 0x00109D1C File Offset: 0x00107F1C
	public override void update()
	{
		bool flag = this.vecList != null;
		if (flag)
		{
			for (int i = 0; i < this.vecList.size(); i++)
			{
				MainItem mainItem = (MainItem)this.vecList.elementAt(i);
				mainItem.marketTime.updateTimeCountDownTicket();
				bool flag2 = mainItem.marketTime.timeCountDown <= 0 && mainItem.typeMarket == 1;
				if (flag2)
				{
					mainItem.typeMarket = 3;
				}
			}
		}
		this.list.moveCamera();
		bool flag3 = this.itemCur != null;
		if (flag3)
		{
			this.updateShowInfo();
			bool isRemove = this.itemCur.isRemove;
			if (isRemove)
			{
				this.itemCur = null;
				this.getItemCurNew();
			}
		}
	}

	// Token: 0x06000DBE RID: 3518 RVA: 0x00109DE4 File Offset: 0x00107FE4
	public override void updateShowInfo()
	{
		bool flag = !this.isShowInfo;
		if (flag)
		{
			this.timeShowInfo += 1;
			bool flag2 = this.timeShowInfo >= 5;
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

	// Token: 0x06000DBF RID: 3519 RVA: 0x00109E3C File Offset: 0x0010803C
	public override void updatekey()
	{
		bool flag = GameCanvas.keyMove(0) || GameCanvas.keyMove(2);
		if (flag)
		{
			GameCanvas.currentScreen.setTypeTab(0);
			GameCanvas.ClearkeyMove(0);
			GameCanvas.ClearkeyMove(2);
		}
		bool flag2 = false;
		int idSelect = this.IdSelect;
		bool flag3 = GameCanvas.keyMove(1);
		if (flag3)
		{
			this.IdSelect--;
			GameCanvas.ClearkeyMove(1);
			flag2 = true;
		}
		else
		{
			bool flag4 = GameCanvas.keyMove(3);
			if (flag4)
			{
				this.IdSelect++;
				GameCanvas.ClearkeyMove(3);
				flag2 = true;
			}
		}
		bool flag5 = this.vecList == null;
		if (flag5)
		{
			this.IdSelect = -1;
		}
		else
		{
			bool flag6 = flag2;
			if (flag6)
			{
				this.IdSelect = AvMain.resetSelect(this.IdSelect, this.vecList.size() - 1, false);
				bool flag7 = idSelect != this.IdSelect && this.IdSelect >= 0;
				if (flag7)
				{
					bool flag8 = GameCanvas.isTouchNoOrPC();
					if (flag8)
					{
						int num = this.IdSelect * this.wItemCur - this.hCur / 2;
						bool flag9 = this.IdSelect > 0;
						if (flag9)
						{
							num += this.wItemCur / 2;
						}
						this.list.setToX(num);
					}
					this.getItemCurNew();
					this.isShowInfo = false;
				}
			}
		}
		base.updatekey();
		this.updatekeyPC();
	}

	// Token: 0x06000DC0 RID: 3520 RVA: 0x00109FA4 File Offset: 0x001081A4
	public override void updatePointer()
	{
		this.list.update_Pos_UP_DOWN();
		bool flag = GameCanvas.isPointerSelect && this.vecList != null && this.vecList.size() > 0 && GameCanvas.isPoint(this.xCurBegin, this.yCurBegin, this.wCur, this.hCur);
		if (flag)
		{
			int num = (GameCanvas.py - this.yCurBegin + this.list.cmx) / this.wItemCur;
			bool flag2 = num == this.IdSelect;
			if (flag2)
			{
				this.IdSelect = num;
			}
			else
			{
				this.IdSelect = num;
				this.getItemCurNew();
			}
			GameCanvas.isPointerSelect = false;
		}
		bool flag3 = this.vecCmd != null;
		if (flag3)
		{
			for (int i = 0; i < this.vecCmd.size(); i++)
			{
				iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
				iCommand.updatePointer();
			}
		}
		bool flag4 = this.isShowInfo && this.cmdPlusItem != null;
		if (flag4)
		{
			this.cmdPlusItem.updatePointer();
		}
		base.updatePointer();
	}

	// Token: 0x06000DC1 RID: 3521 RVA: 0x0010A0CC File Offset: 0x001082CC
	public override void setPosInfo()
	{
		this.setPosInfo(this.itemCur, this.xCurBegin + MainTab.wTab + 24, this.yCurBegin + 2);
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.addButtonPlus();
		}
	}

	// Token: 0x06000DC2 RID: 3522 RVA: 0x0010A110 File Offset: 0x00108310
	public override void updateInfo()
	{
		bool flag = this.vecList != null;
		if (flag)
		{
			MainItem mainItem = (MainItem)this.vecList.elementAt(this.IdSelect);
			bool flag2 = mainItem != null && this.itemCur != null && mainItem != this.itemCur;
			if (flag2)
			{
				this.itemCur = mainItem;
				this.isShowInfo = false;
			}
		}
	}

	// Token: 0x06000DC3 RID: 3523 RVA: 0x0010A174 File Offset: 0x00108374
	public void getItemCurNew()
	{
		bool flag = this.vecList != null;
		if (flag)
		{
			this.isShowInfo = false;
			this.IdSelect = AvMain.resetSelect(this.IdSelect, this.vecList.size() - 1, false);
			this.itemCur = (MainItem)this.vecList.elementAt(this.IdSelect);
			bool flag2 = this.indexMarket == 3;
			if (flag2)
			{
				this.getCmd();
			}
			this.vecInfoSS = MainItem.getInfoSS(this.itemCur);
		}
	}

	// Token: 0x06000DC4 RID: 3524 RVA: 0x0010A1FC File Offset: 0x001083FC
	private void getCmd()
	{
		bool flag = this.indexMarket != 3;
		if (!flag)
		{
			this.vecCmd.removeAllElements();
			bool flag2 = !GameCanvas.isTouch;
			if (flag2)
			{
				this.center = null;
				this.left = null;
				this.right = null;
			}
			bool flag3 = this.itemCur == null;
			if (!flag3)
			{
				bool flag4 = this.itemCur.typeMarket == 1;
				if (flag4)
				{
					this.vecCmd.addElement(this.cmdCancleSell);
					bool flag5 = !GameCanvas.isTouch;
					if (flag5)
					{
						this.left = this.cmdCancleSell;
					}
					this.menuCMD = this.cmdCancleSell;
				}
				bool flag6 = this.itemCur.typeMarket == 0 || this.itemCur.typeMarket == 3 || this.itemCur.typeMarket == 4;
				if (flag6)
				{
					this.vecCmd.addElement(this.cmdGet);
					bool flag7 = this.itemCur.typeObject == 3;
					if (flag7)
					{
						this.vecCmd.addElement(this.cmdSell);
					}
					bool flag8 = !GameCanvas.isTouch;
					if (flag8)
					{
						bool flag9 = this.itemCur.typeObject == 3;
						if (flag9)
						{
							this.left = this.cmdSell;
						}
						this.center = this.cmdGet;
					}
					bool flag10 = this.itemCur.typeObject == 3;
					if (flag10)
					{
						this.menuCMD = this.cmdSell;
					}
					this.okCMD = this.cmdGet;
				}
				bool flag11 = this.itemCur.typeMarket == 2;
				if (flag11)
				{
					this.vecCmd.addElement(this.cmdGet);
					bool flag12 = !GameCanvas.isTouch;
					if (flag12)
					{
						this.center = this.cmdGet;
					}
					this.okCMD = this.cmdGet;
				}
			}
		}
	}

	// Token: 0x06000DC5 RID: 3525 RVA: 0x0010A3E0 File Offset: 0x001085E0
	public override void setData(mVector vec)
	{
		this.vecList = vec;
		int num = 0;
		bool flag = this.vecList != null;
		if (flag)
		{
			num = this.vecList.size();
		}
		int limX = num * this.wItemCur - this.hCur + this.miniItem * 3;
		this.list = new ListNew(this.xCurBegin, this.yCurBegin, this.wCur, this.hCur, 0, 0, limX, true);
		this.setCreateCmd();
		bool flag2 = this == this.ScrTab.tabCurrent;
		if (flag2)
		{
			this.beginFocus();
			this.getCmd();
		}
	}

	// Token: 0x06000DC6 RID: 3526 RVA: 0x0010A47C File Offset: 0x0010867C
	public sbyte getIndexMarket()
	{
		return this.indexMarket;
	}

	// Token: 0x06000DC7 RID: 3527 RVA: 0x0010A494 File Offset: 0x00108694
	public void addButtonPlus()
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
			bool flag3 = this.itemCur.LvUpgrade != mainItem.LvUpgrade;
			if (flag3)
			{
				this.cmdPlusItem = new iCommand(T.plus, 8, 0, this);
				int num = this.itemCur.hInfo - this.itemCur.hRunInfo;
				this.cmdPlusItem.setPos(this.xInfo + this.itemCur.wInfo - 10, this.yInfo + num - 10, AvMain.fraPlus, "  +" + mainItem.LvUpgrade.ToString());
			}
			else
			{
				this.cmdPlusItem.setPos(-50, -50, AvMain.fraPlus, string.Empty);
			}
		}
	}

	// Token: 0x04001510 RID: 5392
	public const sbyte INDEX_MARKET_WEA = 0;

	// Token: 0x04001511 RID: 5393
	public const sbyte INDEX_MARKET_AO = 1;

	// Token: 0x04001512 RID: 5394
	public const sbyte INDEX_MARKET_SUC = 2;

	// Token: 0x04001513 RID: 5395
	public const sbyte INDEX_MARKET_CHEST = 3;

	// Token: 0x04001514 RID: 5396
	public const sbyte INDEX_MARKET_INVEN = 4;

	// Token: 0x04001515 RID: 5397
	public const sbyte INDEX_MARKET_NGUYEN_LIEU = 5;

	// Token: 0x04001516 RID: 5398
	public const sbyte INDEX_MARKET_POTION = 6;

	// Token: 0x04001517 RID: 5399
	private mVector vecList;

	// Token: 0x04001518 RID: 5400
	private ListNew list;

	// Token: 0x04001519 RID: 5401
	private int maxPaint;

	// Token: 0x0400151A RID: 5402
	public MainItem itemCur;

	// Token: 0x0400151B RID: 5403
	public mVector vecCmd = new mVector();

	// Token: 0x0400151C RID: 5404
	public mVector vecInfoSS = new mVector();

	// Token: 0x0400151D RID: 5405
	public iCommand cmdBuy;

	// Token: 0x0400151E RID: 5406
	public iCommand cmdSelectPage;

	// Token: 0x0400151F RID: 5407
	public iCommand cmdClose;

	// Token: 0x04001520 RID: 5408
	public iCommand cmdSell;

	// Token: 0x04001521 RID: 5409
	public iCommand cmdGet;

	// Token: 0x04001522 RID: 5410
	public iCommand cmdUpdate;

	// Token: 0x04001523 RID: 5411
	public iCommand cmdMenu;

	// Token: 0x04001524 RID: 5412
	public iCommand cmdCancleSell;

	// Token: 0x04001525 RID: 5413
	public iCommand cmdPlusItem;

	// Token: 0x04001526 RID: 5414
	private InputDialog input;

	// Token: 0x04001527 RID: 5415
	private TabScreen ScrTab;
}
