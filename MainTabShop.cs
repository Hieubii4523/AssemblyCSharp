using System;

// Token: 0x02000089 RID: 137
public class MainTabShop : MainTab
{
	// Token: 0x060008B3 RID: 2227 RVA: 0x000AE514 File Offset: 0x000AC714
	public MainTabShop(string name, mVector vec)
	{
		MainTabShop.instance = this;
	}

	// Token: 0x060008B4 RID: 2228 RVA: 0x000AE568 File Offset: 0x000AC768
	public MainTabShop(string name, mVector vec, int maxSize, int xbegin)
	{
		MainTabShop.instance = this;
		this.nameTab = name;
		this.vecShop = vec;
		this.wCur = MainTab.wItem * MainTabShop.maxNumItemW;
		this.xCurBegin = xbegin + MainTab.wTab / 2 - this.wCur / 2 + 10;
		this.yCurBegin = MainTab.yTab + 32;
		this.maxSize = maxSize;
		int limX = ((maxSize - 1) / MainTabShop.maxNumItemW + 1) * MainTab.wItem - this.hCur + this.miniItem;
		this.list = new ListNew(this.xCurBegin, this.yCurBegin, this.wCur, this.hCur, 0, 0, limX, true);
		this.scrShop.setInfo(this.xCurBegin + this.wCur + this.miniItem, this.yCurBegin + this.miniItem / 2, this.hCur - this.miniItem * 2, 8809550);
	}

	// Token: 0x060008B5 RID: 2229 RVA: 0x000AE694 File Offset: 0x000AC894
	public override void beginFocus()
	{
		this.isShowInfo = false;
		this.timeShowInfo = 0;
		bool flag = GameCanvas.isTouchNoOrPC();
		if (flag)
		{
			this.IdSelect = 0;
			bool flag2 = this.vecShop.size() > 0;
			if (flag2)
			{
				this.setPosCmd(this.getMenuActionItem());
			}
		}
		else
		{
			this.IdSelect = -1;
			this.setPosCmd(null);
			this.itemCur = null;
			bool flag3 = this.typeNPCShop == 101;
			if (flag3)
			{
				this.IdSelect = 0;
				bool flag4 = this.vecShop.size() > 0;
				if (flag4)
				{
					this.setPosCmd(this.getMenuActionItem());
				}
			}
		}
		bool flag5 = MainTabShop.isSortInven;
		if (flag5)
		{
			this.vecShop = MainItem.SortVecItem(this.vecShop);
			MainTabShop.isSortInven = false;
		}
	}

	// Token: 0x060008B6 RID: 2230 RVA: 0x000AE75C File Offset: 0x000AC95C
	public override void paint(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		AvMain.paintRect(g, this.xCurBegin, this.yCurBegin, this.wCur, this.hCur - this.miniItem, 0, 3);
		g.setClip(this.xCurBegin - 1, this.yCurBegin + 1, this.wCur + 2, this.hCur - 1 - this.miniItem);
		g.saveCanvas();
		g.ClipRec(this.xCurBegin - 1, this.yCurBegin + 1, this.wCur + 2, this.hCur - 1 - this.miniItem);
		g.translate(this.xCurBegin, this.yCurBegin);
		g.translate(0, -this.list.cmx);
		for (int i = 0; i < this.vecShop.size(); i++)
		{
			bool flag = i / MainTabShop.maxNumItemW * MainTab.wItem + MainTab.wItem / 2 + MainTab.wItem / 2 - 2 < this.list.cmx || i / MainTabShop.maxNumItemW * MainTab.wItem + MainTab.wItem / 2 - MainTab.wItem / 2 + 2 > this.list.cmx + (this.hCur - 1 - this.miniItem);
			if (!flag)
			{
				MainItem mainItem = (MainItem)this.vecShop.elementAt(i);
				bool flag2 = mainItem.typeObject == 3 || mainItem.typeObject == 102 || mainItem.typeObject == 103;
				if (flag2)
				{
					mainItem.paintColor(g, i % MainTabShop.maxNumItemW * MainTab.wItem + MainTab.wItem / 2, i / MainTabShop.maxNumItemW * MainTab.wItem + MainTab.wItem / 2, MainTab.wItem);
				}
				mainItem.paint(g, i % MainTabShop.maxNumItemW * MainTab.wItem + MainTab.wItem / 2, i / MainTabShop.maxNumItemW * MainTab.wItem + MainTab.wItem / 2, MainTab.wItem);
				bool flag3 = mainItem.typeObject == 4 && this.indexIconTab == 0;
				if (flag3)
				{
					DelaySkill.getDelay((int)mainItem.indexHotKey).paint(g, i % MainTabShop.maxNumItemW * MainTab.wItem + 1, i / MainTabShop.maxNumItemW * MainTab.wItem + 1, MainTab.wItem - 1);
				}
				this.paintItemCur(g, mainItem, i % MainTabShop.maxNumItemW * MainTab.wItem + MainTab.wItem - 1, i / MainTabShop.maxNumItemW * MainTab.wItem + MainTab.wItem - 1);
				bool flag4 = this.IdSelect == i && GameCanvas.currentScreen.setCurTypetab(1);
				if (flag4)
				{
					g.setColor(16777215);
					g.drawRect(i % MainTabShop.maxNumItemW * MainTab.wItem + 1, i / MainTabShop.maxNumItemW * MainTab.wItem + 1, MainTab.wItem - 2, MainTab.wItem - 2);
					bool flag5 = !GameCanvas.isSmallScreen;
					if (flag5)
					{
						g.drawRect(i % MainTabShop.maxNumItemW * MainTab.wItem + 2, i / MainTabShop.maxNumItemW * MainTab.wItem + 2, MainTab.wItem - 4, MainTab.wItem - 4);
					}
				}
			}
		}
		bool flag6 = this.maxSize % MainTabShop.maxNumItemW != 0;
		if (flag6)
		{
			for (int j = this.maxSize; j < this.maxSize + (MainTabShop.maxNumItemW - this.maxSize % MainTabShop.maxNumItemW); j++)
			{
				g.drawRegion(AvMain.imgDelay, 0, 0, MainTab.wItem - 1, MainTab.wItem - 1, 0, (float)(j % MainTabShop.maxNumItemW * MainTab.wItem + 1), (float)(j / MainTabShop.maxNumItemW * MainTab.wItem + 1), 0);
			}
		}
		g.setColor(14075832);
		for (int k = 0; k < MainTabShop.maxNumItemW - 1; k++)
		{
			g.fillRect(MainTab.wItem + k * MainTab.wItem, 1, 1, MainTab.wItem * ((this.maxSize - 1) / MainTabShop.maxNumItemW + 1));
		}
		for (int l = 0; l <= (this.maxSize - 1) / MainTabShop.maxNumItemW + 1; l++)
		{
			g.fillRect(1, l * MainTab.wItem, this.wCur - 1, 1);
		}
		mGraphics.resetTransAndroid(g);
		g.restoreCanvas();
		GameCanvas.resetTrans(g);
		g.setColor(6966058);
		g.drawRect(this.xCurBegin, this.yCurBegin + 2, 0, this.hCur - this.miniItem - 4);
		this.paintShowBoat(g, MainTab.xTab + 22, MainTab.yTab + MainTab.hTab - 22);
		bool flag7 = !GameCanvas.currentScreen.setCurTypetab(1);
		if (!flag7)
		{
			bool flag8 = this.list.cmxLim > 0;
			if (flag8)
			{
				this.scrShop.paint(g);
			}
			bool flag9 = this.isShowInfo && this.itemCur != null;
			if (flag9)
			{
				base.ShowInfo(g, this.itemCur, this.vecInfoSS, 0, this.xInfo, this.yInfo, false, null, TabInventory.LvUpgradeSS);
				bool flag10 = this.cmdPlusItem != null;
				if (flag10)
				{
					this.cmdPlusItem.paintXY(g, this.cmdPlusItem.xCmd, this.cmdPlusItem.yCmd);
				}
			}
			bool flag11 = this.vecCmd != null && GameCanvas.getShowCmd();
			if (flag11)
			{
				for (int m = 0; m < this.vecCmd.size(); m++)
				{
					iCommand iCommand = (iCommand)this.vecCmd.elementAt(m);
					iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
				}
			}
			base.paint(g);
		}
	}

	// Token: 0x060008B7 RID: 2231 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void paintItemCur(mGraphics g, MainItem Item, int x, int y)
	{
	}

	// Token: 0x060008B8 RID: 2232 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void paintShowBoat(mGraphics g, int x, int y)
	{
	}

	// Token: 0x060008B9 RID: 2233 RVA: 0x000AED3C File Offset: 0x000ACF3C
	public override void update()
	{
		int cmx = this.list.cmx;
		this.list.moveCamera();
		this.scrShop.setYScrool(this.list.cmx, this.list.cmxLim);
		bool flag = this.list.cmx != cmx || this.list.pointerIsDowning;
		if (flag)
		{
			this.isShowInfo = false;
		}
		else
		{
			bool flag2 = this.itemCur != null;
			if (flag2)
			{
				this.updateShowInfo();
			}
		}
		bool flag3 = this.itemCur != null && this.itemCur.isRemove;
		if (flag3)
		{
			this.itemCur = null;
			this.getItemCurNew();
		}
		bool flag4 = MainTabShop.isUpdateItemShip;
		if (flag4)
		{
			this.updateItemShip();
		}
		this.updateInshop();
		bool flag5 = this.tickbuy > 0;
		if (flag5)
		{
			this.tickbuy--;
		}
	}

	// Token: 0x060008BA RID: 2234 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void updateInshop()
	{
	}

	// Token: 0x060008BB RID: 2235 RVA: 0x000AEE2C File Offset: 0x000AD02C
	public override void updatekey()
	{
		bool flag = false;
		bool flag2 = GameCanvas.keyMove(0);
		if (flag2)
		{
			bool flag3 = this.IdSelect % MainTabShop.maxNumItemW == 0;
			if (flag3)
			{
				GameCanvas.currentScreen.setTypeTab(0);
			}
			else
			{
				this.IdSelect--;
			}
			GameCanvas.ClearkeyMove(0);
			flag = true;
		}
		else
		{
			bool flag4 = GameCanvas.keyMove(2);
			if (flag4)
			{
				this.IdSelect++;
				GameCanvas.ClearkeyMove(2);
				flag = true;
			}
			else
			{
				bool flag5 = GameCanvas.keyMove(1);
				if (flag5)
				{
					bool flag6 = this.IdSelect >= MainTabShop.maxNumItemW;
					if (flag6)
					{
						this.IdSelect -= MainTabShop.maxNumItemW;
					}
					GameCanvas.ClearkeyMove(1);
					flag = true;
				}
				else
				{
					bool flag7 = GameCanvas.keyMove(3);
					if (flag7)
					{
						bool flag8 = this.IdSelect < this.vecShop.size() - MainTabShop.maxNumItemW;
						if (flag8)
						{
							this.IdSelect += MainTabShop.maxNumItemW;
						}
						GameCanvas.ClearkeyMove(3);
						flag = true;
					}
				}
			}
		}
		bool flag9 = flag;
		if (flag9)
		{
			this.getItemCurNew();
		}
		base.updatekey();
		this.updatekeyPC();
	}

	// Token: 0x060008BC RID: 2236 RVA: 0x000AEF5C File Offset: 0x000AD15C
	public override void updatePointer()
	{
		this.list.update_Pos_UP_DOWN();
		bool flag = GameCanvas.isPointSelect(this.xCurBegin, this.yCurBegin, this.wCur, this.hCur);
		if (flag)
		{
			int num = (GameCanvas.px - this.xCurBegin) / MainTab.wItem + (GameCanvas.py - this.yCurBegin + this.list.cmx) / MainTab.wItem * MainTabShop.maxNumItemW;
			int num2 = this.vecShop.size();
			bool flag2 = num >= 0 && num < num2;
			if (flag2)
			{
				GameCanvas.isPointerSelect = false;
				bool flag3 = num == this.IdSelect;
				if (flag3)
				{
					mSystem.outz("menu perform id " + this.IdSelect.ToString());
					this.cmdMenu.perform();
				}
				else
				{
					this.isShowInfo = false;
					this.IdSelect = num;
					this.setPosCmd(this.getMenuActionItem());
				}
				bool flag4 = !GameCanvas.currentScreen.setCurTypetab(1);
				if (flag4)
				{
					GameCanvas.currentScreen.setTypeTab(1);
				}
			}
			else
			{
				this.itemCur = null;
				this.isShowInfo = false;
				this.IdSelect = -1;
				this.setPosCmd(null);
			}
		}
		bool flag5 = this.vecCmd != null;
		if (flag5)
		{
			for (int i = 0; i < this.vecCmd.size(); i++)
			{
				iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
				iCommand.updatePointer();
			}
		}
		bool flag6 = this.isShowInfo && this.cmdPlusItem != null;
		if (flag6)
		{
			this.cmdPlusItem.updatePointer();
		}
		base.updatePointer();
	}

	// Token: 0x060008BD RID: 2237 RVA: 0x0009DE64 File Offset: 0x0009C064
	public virtual mVector getMenuActionItem()
	{
		return null;
	}

	// Token: 0x060008BE RID: 2238 RVA: 0x000AF114 File Offset: 0x000AD314
	public virtual void setPosCmd(mVector vec)
	{
		this.left = null;
		this.center = null;
		this.vecCmd.removeAllElements();
		bool flag = vec == null;
		if (!flag)
		{
			iCommand cmdLeft = this.getCmdLeft();
			bool flag2 = cmdLeft != null;
			if (flag2)
			{
				vec.addElement(cmdLeft);
			}
			bool flag3 = MainTab.bigInfo > 0;
			if (!flag3)
			{
				bool flag4 = vec.size() > 2;
				if (flag4)
				{
					bool isTouch = GameCanvas.isTouch;
					if (isTouch)
					{
						this.cmdMenu = AvMain.setPosCMD(this.cmdMenu, 0);
						this.vecCmd.addElement(this.cmdMenu);
						this.okCMD = this.cmdMenu;
					}
					else
					{
						this.center = this.cmdMenu;
					}
				}
				else
				{
					bool isTouch2 = GameCanvas.isTouch;
					if (isTouch2)
					{
						this.vecCmd = vec;
						for (int i = 0; i < this.vecCmd.size(); i++)
						{
							iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
							iCommand = AvMain.setPosCMD(iCommand, i);
							bool flag5 = i == 0;
							if (flag5)
							{
								this.okCMD = iCommand;
							}
							bool flag6 = i == 1;
							if (flag6)
							{
								this.menuCMD = iCommand;
							}
						}
					}
					else
					{
						for (int j = 0; j < vec.size(); j++)
						{
							iCommand iCommand2 = (iCommand)vec.elementAt(j);
							bool flag7 = j == 0;
							if (flag7)
							{
								this.center = iCommand2;
							}
							bool flag8 = j == 1;
							if (flag8)
							{
								this.left = iCommand2;
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x060008BF RID: 2239 RVA: 0x000A5D98 File Offset: 0x000A3F98
	public virtual iCommand getCmdLeft()
	{
		return null;
	}

	// Token: 0x060008C0 RID: 2240 RVA: 0x000AF2B0 File Offset: 0x000AD4B0
	public override void setPosInfo()
	{
		this.setPosInfo(this.itemCur, this.xCurBegin + MainTab.wTab, this.yCurBegin + (this.IdSelect / MainTabShop.maxNumItemW + 1) * MainTab.wItem - this.list.cmx + 4);
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.addButtonPlus();
		}
	}

	// Token: 0x060008C1 RID: 2241 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void addButtonPlus()
	{
	}

	// Token: 0x060008C2 RID: 2242 RVA: 0x000AF314 File Offset: 0x000AD514
	public override void updateInfo()
	{
		MainItem mainItem = (MainItem)this.vecShop.elementAt(this.IdSelect);
		bool flag = mainItem != null && this.itemCur != null && mainItem != this.itemCur;
		if (flag)
		{
			this.itemCur = mainItem;
			this.isShowInfo = false;
		}
	}

	// Token: 0x060008C3 RID: 2243 RVA: 0x000AF368 File Offset: 0x000AD568
	public virtual void getItemCurNew()
	{
		this.isShowInfo = false;
		this.IdSelect = AvMain.resetSelect(this.IdSelect, this.vecShop.size() - 1, false);
		this.list.setToX((this.IdSelect / MainTabShop.maxNumItemW + 1) * MainTab.wItem - this.hCur / 2);
		bool flag = this.IdSelect >= 0;
		if (flag)
		{
			this.setPosCmd(this.getMenuActionItem());
		}
	}

	// Token: 0x060008C4 RID: 2244 RVA: 0x000AF3E4 File Offset: 0x000AD5E4
	public virtual void updateItemShip()
	{
		MainTabShop.isUpdateItemShip = false;
		bool flag = this.itemCur == null || MainTabShop.itemShipCur == null;
		if (!flag)
		{
			for (int i = 0; i < this.vecShop.size(); i++)
			{
				MainItem mainItem = (MainItem)this.vecShop.elementAt(i);
				bool flag2 = mainItem.typeObject == MainTabShop.itemShipCur.typeObject && mainItem.ID == MainTabShop.itemShipCur.ID;
				if (flag2)
				{
					this.IdSelect = i;
					this.updateInfo();
					break;
				}
			}
		}
	}

	// Token: 0x04000DA9 RID: 3497
	public const sbyte INVENTORY = 0;

	// Token: 0x04000DAA RID: 3498
	public const sbyte INVENTORY_SHOP = 1;

	// Token: 0x04000DAB RID: 3499
	public const sbyte INVENTORY_CHEST = 2;

	// Token: 0x04000DAC RID: 3500
	public const sbyte INVENTORY_UPGRADE = 3;

	// Token: 0x04000DAD RID: 3501
	public const sbyte INVENTORY_CLAN = 4;

	// Token: 0x04000DAE RID: 3502
	public const sbyte INVENTORY_MARKET = 5;

	// Token: 0x04000DAF RID: 3503
	public const sbyte INVENTORY_HUYHIEU = 6;

	// Token: 0x04000DB0 RID: 3504
	public const sbyte INVENTORY_PET = 7;

	// Token: 0x04000DB1 RID: 3505
	public mVector vecShop = new mVector("MainTabShop.vecShop");

	// Token: 0x04000DB2 RID: 3506
	public mVector vecInfoSS = new mVector("MainTabShop.vecInfoSS");

	// Token: 0x04000DB3 RID: 3507
	public mVector vecCmd = new mVector();

	// Token: 0x04000DB4 RID: 3508
	public MainItem itemCur;

	// Token: 0x04000DB5 RID: 3509
	public static MainItem itemShipCur;

	// Token: 0x04000DB6 RID: 3510
	public static bool isUpdateItemShip;

	// Token: 0x04000DB7 RID: 3511
	public sbyte typeNPCShop;

	// Token: 0x04000DB8 RID: 3512
	public iCommand cmdMenu;

	// Token: 0x04000DB9 RID: 3513
	public iCommand cmdPlusItem;

	// Token: 0x04000DBA RID: 3514
	public InputDialog input;

	// Token: 0x04000DBB RID: 3515
	public static int maxNumItemW = 5;

	// Token: 0x04000DBC RID: 3516
	public static int maxNumItemH;

	// Token: 0x04000DBD RID: 3517
	public ListNew list;

	// Token: 0x04000DBE RID: 3518
	public Scroll scrShop = new Scroll();

	// Token: 0x04000DBF RID: 3519
	public static bool isSortInven;

	// Token: 0x04000DC0 RID: 3520
	public int tickbuy;

	// Token: 0x04000DC1 RID: 3521
	public static MainTabShop instance;
}
