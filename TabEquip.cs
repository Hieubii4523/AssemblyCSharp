using System;

// Token: 0x020000FD RID: 253
public class TabEquip : MainTab
{
	// Token: 0x06000EC5 RID: 3781 RVA: 0x0011C9E0 File Offset: 0x0011ABE0
	public TabEquip(string name)
	{
		this.nameTab = name;
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.IdSelect = -1;
		}
		else
		{
			this.IdSelect = 0;
		}
		this.wItemCur = MainTab.hItemTab;
		bool isTouch2 = GameCanvas.isTouch;
		if (isTouch2)
		{
			bool isBigScreen = this.isBigScreen;
			if (isBigScreen)
			{
				this.wItemCur = 32;
			}
			else
			{
				this.wItemCur = 28;
			}
		}
		this.hCur3 = this.hCur / 3;
		this.wCur5 = this.wCur / 5;
		this.hTextTicket = GameCanvas.hText;
		int num = this.miniItem;
		bool flag = this.wItemCur > this.hCur / 6 + 1;
		if (flag)
		{
			this.wItemCur = this.hCur / 6 + 1;
		}
		bool flag2 = GameCanvas.isTouch && this.wItemCur < 23 && (!GameCanvas.isIos() || MotherCanvas.h >= 240);
		if (flag2)
		{
			this.wItemCur = 23;
			this.hsaiso = 3;
		}
		bool flag3 = this.wItemCur % 2 == 0;
		if (flag3)
		{
			this.wItemCur--;
		}
		this.hTextCur = GameCanvas.hText;
		bool isSmallScreen = GameCanvas.isSmallScreen;
		if (isSmallScreen)
		{
			num = 2;
			this.hTextCur = GameCanvas.hText - 4;
			this.hsaiso = 2;
		}
		this.xIn = this.xCurBegin + num;
		this.yIn = this.yCurBegin + this.hCur3 * 2 + num;
		TabEquip.maxEquip = 10;
		this.maxInfo = this.hCur3 / this.hTextCur;
		this.maxCol = (Player.InfoShortEquip.Length - 1) / this.maxInfo + 1;
		bool flag4 = this.maxCol <= 0;
		if (flag4)
		{
			this.maxCol = 1;
		}
		this.maxNumItem = 2;
		int num2 = TabEquip.maxEquip;
		bool flag5 = num2 > 8;
		if (flag5)
		{
			num2 = 8;
		}
		this.yE = this.yCurBegin + (this.hCur3 * 2 - ((num2 + 1) / 2 - 1) * this.wItemCur) / 2 - this.yplus * 3 / 2 - 2;
		this.xE = this.xCurBegin + this.wCur5 / 2 - this.wItemCur / 2;
		this.indexIconTab = 1;
		TabEquip.mposEquip = mSystem.new_M_Int(TabEquip.maxEquip, 2);
		for (int i = 0; i < TabEquip.mposEquip.Length; i++)
		{
			int num3 = i;
			int num4 = num3;
			if (num4 != 8)
			{
				if (num4 != 9)
				{
					TabEquip.mposEquip[i][0] = this.xE + i % 2 * (this.wCur5 * 4 + 3);
					TabEquip.mposEquip[i][1] = this.yE - this.wItemCur / 2 + i / 2 * (this.wItemCur + this.yplus) - this.hsaiso;
				}
				else
				{
					TabEquip.mposEquip[i][0] = this.xE + i % 2 * (this.wCur5 * 4 + 3) - this.wItemCur * 5 / 4;
					TabEquip.mposEquip[i][1] = this.yE - this.wItemCur / 2 + i / 2 * (this.wItemCur + this.yplus) - this.wItemCur * 5 / 4 - this.hsaiso;
				}
			}
			else
			{
				TabEquip.mposEquip[i][0] = this.xE + i % 2 * (this.wCur5 * 4 + 3) + this.wItemCur * 5 / 4;
				TabEquip.mposEquip[i][1] = this.yE - this.wItemCur / 2 + i / 2 * (this.wItemCur + this.yplus) - this.wItemCur * 5 / 4 - this.hsaiso;
			}
		}
		this.cmdChangeWear = new iCommand(T.change, 0, this);
		this.cmdChangeWear = AvMain.setPosCMD(this.cmdChangeWear, 0);
		this.cmdSetUniform = new iCommand(T.setUniform, 1, this);
		this.cmdSetUniform = AvMain.setPosCMD(this.cmdSetUniform, 1);
		this.cmdDelUniform = new iCommand(T.delUniorm, 3, this);
	}

	// Token: 0x06000EC6 RID: 3782 RVA: 0x0011CE10 File Offset: 0x0011B010
	public override void beginFocus()
	{
		this.isShowInfo = false;
		bool flag = GameCanvas.isTouchNoOrPC();
		if (flag)
		{
			this.IdSelect = 0;
			this.itemCur = (MainItem)GameScreen.player.hashEquip.get(string.Empty + this.IdSelect.ToString());
		}
		else
		{
			this.IdSelect = -1;
			this.itemCur = null;
		}
		this.center = this.cmdChangeWear;
		this.maxCol = (Player.InfoShortEquip.Length - 1) / this.maxInfo + 1;
		bool flag2 = this.maxCol <= 0;
		if (flag2)
		{
			this.maxCol = 1;
		}
		this.left = this.cmdSetUniform;
	}

	// Token: 0x06000EC7 RID: 3783 RVA: 0x0011CEC4 File Offset: 0x0011B0C4
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
		{
			bool flag = this.IdSelect >= 0;
			if (flag)
			{
				mVector listItem = this.getListItem();
				bool flag2 = listItem.size() == 0;
				if (flag2)
				{
					GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.nullChangeItem);
				}
				else
				{
					MsgListItem msgListItem = new MsgListItem();
					msgListItem.setinfoListItem(listItem, TabEquip.mposEquip[this.IdSelect][0], TabEquip.mposEquip[this.IdSelect][1] + MainTab.wItem / 2, this.wItemCur, (this.IdSelect % 2 == 0) ? 2 : 0);
					GameCanvas.Start_Current_Dialog(msgListItem);
				}
			}
			break;
		}
		case 1:
		{
			mVector mVector = new mVector();
			for (int i = 0; i < T.mColorUniform.Length; i++)
			{
				iCommand o = new iCommand(T.mColorUniform[i], 2, i, this);
				mVector.addElement(o);
			}
			mVector.addElement(this.cmdDelUniform);
			GameCanvas.menuCur.startAt(mVector, 2, T.setUniform);
			break;
		}
		case 2:
		{
			for (int j = 0; j < Player.vecUniform.size(); j++)
			{
				Uniform uniform = (Uniform)Player.vecUniform.elementAt(j);
				bool flag3 = (int)uniform.index == subIndex;
				if (flag3)
				{
					uniform.setUniform((sbyte)subIndex);
					Uniform.checkIndexItem(false);
					GameCanvas.saveRms.SaveUniform();
					return;
				}
			}
			Uniform uniform2 = new Uniform();
			uniform2.setUniform((sbyte)subIndex);
			Player.vecUniform.addElement(uniform2);
			Uniform.checkIndexItem(false);
			GameCanvas.saveRms.SaveUniform();
			break;
		}
		case 3:
			Player.vecUniform.removeAllElements();
			GameCanvas.saveRms.SaveUniform();
			Uniform.checkIndexItem(true);
			break;
		}
	}

	// Token: 0x06000EC8 RID: 3784 RVA: 0x0011D0A0 File Offset: 0x0011B2A0
	private mVector getListItem()
	{
		mVector mVector = new mVector();
		int num = (int)this.valueEquip[this.IdSelect];
		bool flag = this.itemCur != null;
		if (flag)
		{
			num = (int)this.itemCur.typeEquip;
		}
		for (int i = 0; i < Player.vecInventory.size(); i++)
		{
			MainItem mainItem = (MainItem)Player.vecInventory.elementAt(i);
			bool flag2 = mainItem.typeObject == 3 && (int)mainItem.typeEquip == num && (mainItem.charClass == 0 || mainItem.charClass == GameScreen.player.clazz);
			if (flag2)
			{
				mVector.addElement(mainItem);
			}
		}
		return mVector;
	}

	// Token: 0x06000EC9 RID: 3785 RVA: 0x0011D15C File Offset: 0x0011B35C
	public override void paint(mGraphics g)
	{
		int num = 0;
		bool isSmallScreen = GameCanvas.isSmallScreen;
		if (isSmallScreen)
		{
			num = 3;
		}
		AvMain.paintRect(g, this.xCurBegin + this.wCur / 2 - this.wCur5 * 3 / 2 - num, this.yCurBegin + this.miniItem - this.hsaiso, this.wCur5 * 3, this.hCur3 * 2 - this.miniItem * 2 + this.hsaiso, 0, 3);
		int num2 = this.xCurBegin + this.wCur / 2 - this.wCur5 * 3 / 2 - num + 3 + 14;
		int num3 = this.yCurBegin + this.miniItem + 4 - this.hsaiso;
		AvMain.fraMoney.drawFrame(2, num2 - 8, num3 + 5, 0, 3, g);
		bool flag = MainTab.CDTicket.timeCountDown <= 0 || MainTab.valuephantram < 60;
		if (flag)
		{
			mFont.tahoma_7_white.drawString(g, Player.ticket.ToString() + "/" + Player.maxTicket.ToString(), num2, num3, 0);
		}
		else
		{
			MainTab.CDTicket.paintCountDownTicketHour(g, mFont.tahoma_7_yellow, num2, num3, 0);
		}
		AvMain.fraMoney.drawFrame(4, num2 - 8, num3 + this.hTextTicket + 5, 0, 3, g);
		bool flag2 = MainTab.CDPvP.timeCountDown <= 0 || MainTab.valuephantram < 60;
		if (flag2)
		{
			mFont.tahoma_7_white.drawString(g, Player.PvPticket.ToString() + "/" + Player.maxPvPticket.ToString(), num2, num3 + this.hTextTicket, 0);
		}
		else
		{
			MainTab.CDPvP.paintCountDownTicketHour(g, mFont.tahoma_7_yellow, num2, num3 + this.hTextTicket, 0);
		}
		AvMain.fraMoney.drawFrame(3, num2 - 8, num3 + this.hTextTicket * 2 + 5, 0, 3, g);
		bool flag3 = MainTab.CDKeyBoss.timeCountDown <= 0 || MainTab.valuephantram < 60;
		if (flag3)
		{
			mFont.tahoma_7_white.drawString(g, Player.keyBoss.ToString() + "/" + Player.maxKeyboss.ToString(), num2, num3 + this.hTextTicket * 2, 0);
		}
		else
		{
			MainTab.CDKeyBoss.paintCountDownTicketHour(g, mFont.tahoma_7_yellow, num2, num3 + this.hTextTicket * 2, 0);
		}
		AvMain.fraMoney.drawFrame(6, num2 - 8, num3 + this.hTextTicket * 3 + 5, 0, 3, g);
		bool flag4 = MainTab.CDx2XP.timeCountDown <= 0;
		if (flag4)
		{
			mFont.tahoma_7_white.drawString(g, "00:00", num2, num3 + this.hTextTicket * 3, 0);
		}
		else
		{
			MainTab.CDx2XP.paintCountDownTicketHour(g, mFont.tahoma_7_yellow, num2, num3 + this.hTextTicket * 3, 0);
		}
		AvMain.fraMoney.drawFrame(5, num2 - 8, num3 + 5 + this.hTextTicket * 4, 0, 3, g);
		mFont.tahoma_7_white.drawString(g, string.Empty + GameScreen.player.pointPk.ToString(), num2, num3 + this.hTextTicket * 4, 0);
		for (int i = 0; i < TabEquip.maxEquip; i++)
		{
			int index = 3;
			bool flag5 = i < 8;
			if (flag5)
			{
				AvMain.paintRect(g, TabEquip.mposEquip[i][0] - 1, TabEquip.mposEquip[i][1] - 1, this.wItemCur - 2, this.wItemCur - 2, 0, index);
			}
			MainItem mainItem = (MainItem)GameScreen.player.hashEquip.get(string.Empty + i.ToString());
			bool flag6 = mainItem != null;
			if (flag6)
			{
				mainItem.paintColor(g, TabEquip.mposEquip[i][0] + this.wItemCur / 2 - 1, TabEquip.mposEquip[i][1] + this.wItemCur / 2 - 1, this.wItemCur - 3);
				mainItem.paint(g, TabEquip.mposEquip[i][0] + this.wItemCur / 2 - 1, TabEquip.mposEquip[i][1] + this.wItemCur / 2 - 1, this.wItemCur, 1);
			}
			else
			{
				bool flag7 = AvMain.fraEquip != null;
				if (flag7)
				{
					AvMain.fraEquip.drawFrame(i, TabEquip.mposEquip[i][0] + this.wItemCur / 2 - 1, TabEquip.mposEquip[i][1] + this.wItemCur / 2 - 1, 0, 3, g);
				}
			}
			bool flag8 = this.IdSelect == i && GameCanvas.currentScreen.setCurTypetab(1);
			if (flag8)
			{
				g.setColor(16777215);
				g.drawRect(TabEquip.mposEquip[i][0], TabEquip.mposEquip[i][1], this.wItemCur - 4, this.wItemCur - 4);
				g.drawRect(TabEquip.mposEquip[i][0] + 1, TabEquip.mposEquip[i][1] + 1, this.wItemCur - 6, this.wItemCur - 6);
			}
		}
		g.drawImage(MainObject.imgShadow, this.xCurBegin + this.wCur / 5 * 3 + 1 - num, this.yCurBegin + this.hCur3 + GameScreen.player.hOne / 4, 3);
		GameScreen.player.paintCharShow(g, this.xCurBegin + this.wCur / 5 * 3 - num, this.yCurBegin + this.hCur3 + GameScreen.player.hOne / 4, 0, true);
		AvMain.paintRect(g, this.xCurBegin, this.yCurBegin + this.hCur3 * 2, this.wCur, this.hCur3 - this.miniItem, 0, 4);
		bool flag9 = GameCanvas.isSmallScreen || (this.maxInfo == 2 && !GameCanvas.isIos());
		if (flag9)
		{
			for (int j = 0; j < Player.InfoShortEquip.Length; j++)
			{
				bool flag10 = GameCanvas.gameTick % 60 < 20;
				if (flag10)
				{
					mFont.tahoma_7_white.drawString(g, T.mNameShortInfo[j], this.xIn + j / this.maxInfo * this.wCur / this.maxCol, this.yIn + j % this.maxInfo * this.hTextCur, 0);
				}
				else
				{
					mFont.tahoma_7_white.drawString(g, string.Empty + Player.InfoShortEquip[j], this.xIn + j / this.maxInfo * this.wCur / this.maxCol, this.yIn + j % this.maxInfo * this.hTextCur, 0);
				}
			}
		}
		else
		{
			for (int k = 0; k < Player.InfoShortEquip.Length; k++)
			{
				mFont.tahoma_7_black.drawString(g, T.mNameShortInfo[k], this.xIn + k / this.maxInfo * this.wCur / this.maxCol, this.yIn + k % this.maxInfo * this.hTextCur, 0);
				mFont.tahoma_7_white.drawString(g, string.Empty + Player.InfoShortEquip[k], this.xIn + k / this.maxInfo * this.wCur / this.maxCol + 25, this.yIn + k % this.maxInfo * this.hTextCur, 0);
			}
		}
		GameCanvas.resetTrans(g);
		bool flag11 = GameCanvas.currentScreen.setCurTypetab(1) && !GameCanvas.menuCur.isShowMenu && GameCanvas.currentDialog == null && this.IdSelect >= 0;
		if (flag11)
		{
			bool flag12 = this.isShowInfo && this.itemCur != null;
			if (flag12)
			{
				base.ShowInfo(g, this.itemCur, null, 0, this.xInfo, this.yInfo, false, GameScreen.player, 0);
			}
			base.paint(g);
		}
	}

	// Token: 0x06000ECA RID: 3786 RVA: 0x0011D94C File Offset: 0x0011BB4C
	public override void update()
	{
		bool flag = this.itemCur != null;
		if (flag)
		{
			this.updateShowInfo();
		}
		MainTab.updateTimeCountDownTicket();
	}

	// Token: 0x06000ECB RID: 3787 RVA: 0x0011D978 File Offset: 0x0011BB78
	public override void updatekey()
	{
		bool flag = false;
		int idSelect = this.IdSelect;
		bool flag2 = GameCanvas.keyMove(0);
		if (flag2)
		{
			bool flag3 = this.IdSelect == 8;
			if (flag3)
			{
				this.IdSelect = 6;
			}
			else
			{
				bool flag4 = this.IdSelect % this.maxNumItem == 0;
				if (flag4)
				{
					GameCanvas.currentScreen.setTypeTab(0);
				}
				else
				{
					this.IdSelect--;
				}
			}
			GameCanvas.ClearkeyMove(0);
			flag = true;
		}
		else
		{
			bool flag5 = GameCanvas.keyMove(2);
			if (flag5)
			{
				bool flag6 = this.IdSelect == 9;
				if (flag6)
				{
					this.IdSelect = 7;
				}
				else
				{
					this.IdSelect++;
				}
				GameCanvas.ClearkeyMove(2);
				flag = true;
			}
			else
			{
				bool flag7 = GameCanvas.keyMove(1);
				if (flag7)
				{
					bool flag8 = this.IdSelect >= this.maxNumItem;
					if (flag8)
					{
						this.IdSelect -= this.maxNumItem;
					}
					GameCanvas.ClearkeyMove(1);
					flag = true;
				}
				else
				{
					bool flag9 = GameCanvas.keyMove(3);
					if (flag9)
					{
						bool flag10 = this.IdSelect < TabEquip.maxEquip - this.maxNumItem;
						if (flag10)
						{
							this.IdSelect += this.maxNumItem;
						}
						GameCanvas.ClearkeyMove(3);
						flag = true;
					}
				}
			}
		}
		bool flag11 = flag;
		if (flag11)
		{
			this.isShowInfo = false;
			this.IdSelect = AvMain.resetSelect(this.IdSelect, TabEquip.maxEquip - 1, false);
			bool flag12 = this.IdSelect == 8;
			if (flag12)
			{
				MainItem mainItem = (MainItem)GameScreen.player.hashEquip.get(string.Empty + this.IdSelect.ToString());
				bool flag13 = mainItem == null;
				if (flag13)
				{
					mainItem = (MainItem)GameScreen.player.hashEquip.get(string.Empty + 9.ToString());
					bool flag14 = mainItem == null;
					if (flag14)
					{
						this.IdSelect = idSelect;
						return;
					}
					this.IdSelect = 9;
				}
			}
			else
			{
				bool flag15 = this.IdSelect == 9;
				if (flag15)
				{
					MainItem mainItem2 = (MainItem)GameScreen.player.hashEquip.get(string.Empty + this.IdSelect.ToString());
					bool flag16 = mainItem2 == null;
					if (flag16)
					{
						mainItem2 = (MainItem)GameScreen.player.hashEquip.get(string.Empty + 8.ToString());
						bool flag17 = mainItem2 == null;
						if (flag17)
						{
							this.IdSelect = idSelect;
							return;
						}
						this.IdSelect = 8;
					}
				}
			}
			this.itemCur = (MainItem)GameScreen.player.hashEquip.get(string.Empty + this.IdSelect.ToString());
		}
		base.updatekey();
	}

	// Token: 0x06000ECC RID: 3788 RVA: 0x0011DC5C File Offset: 0x0011BE5C
	public override void updatePointer()
	{
		bool flag = GameCanvas.isPointSelect(this.xCurBegin, this.yCurBegin, this.wCur, this.hCur);
		if (flag)
		{
			for (int i = 0; i < TabEquip.maxEquip; i++)
			{
				bool flag2 = !GameCanvas.isPointSelect(TabEquip.mposEquip[i][0] - 2, TabEquip.mposEquip[i][1] - 2, this.wItemCur, this.wItemCur);
				if (!flag2)
				{
					bool flag3 = i == 8 || i == 9;
					if (flag3)
					{
						MainItem mainItem = (MainItem)GameScreen.player.hashEquip.get(string.Empty + i.ToString());
						bool flag4 = mainItem == null;
						if (flag4)
						{
							GameCanvas.isPointerSelect = false;
							break;
						}
					}
					bool flag5 = i != this.IdSelect;
					if (flag5)
					{
						this.IdSelect = i;
						this.itemCur = (MainItem)GameScreen.player.hashEquip.get(string.Empty + this.IdSelect.ToString());
						this.center = this.cmdChangeWear;
						this.okCMD = this.center;
						this.isShowInfo = false;
					}
					else
					{
						this.cmdChangeWear.perform();
					}
					GameCanvas.isPointerSelect = false;
					break;
				}
			}
		}
		base.updatePointer();
	}

	// Token: 0x06000ECD RID: 3789 RVA: 0x0011DDBC File Offset: 0x0011BFBC
	public override void setPosInfo()
	{
		bool flag = MotherCanvas.w >= 400;
		if (flag)
		{
			this.setPosInfo(this.itemCur, this.xCurBegin + MainTab.wTab, TabEquip.mposEquip[this.IdSelect][1] + 1);
		}
		else
		{
			bool flag2 = this.IdSelect % 2 == 0;
			if (flag2)
			{
				this.setPosInfo(this.itemCur, TabEquip.mposEquip[this.IdSelect][0] + this.wItemCur + this.itemCur.wInfo / 2 + 2, TabEquip.mposEquip[this.IdSelect][1] + this.wItemCur);
			}
			else
			{
				this.setPosInfo(this.itemCur, TabEquip.mposEquip[this.IdSelect][0] - this.itemCur.wInfo / 2 - 6, TabEquip.mposEquip[this.IdSelect][1] + this.wItemCur);
			}
		}
	}

	// Token: 0x06000ECE RID: 3790 RVA: 0x0011DEAC File Offset: 0x0011C0AC
	public override void updateInfo()
	{
		MainItem mainItem = (MainItem)GameScreen.player.hashEquip.get(string.Empty + this.IdSelect.ToString());
		bool flag = mainItem != null && this.itemCur != null && mainItem != this.itemCur;
		if (flag)
		{
			this.itemCur = mainItem;
			this.isShowInfo = false;
		}
	}

	// Token: 0x040018F3 RID: 6387
	private int hCur3;

	// Token: 0x040018F4 RID: 6388
	private int wCur5;

	// Token: 0x040018F5 RID: 6389
	private int maxInfo;

	// Token: 0x040018F6 RID: 6390
	private int maxNumItem;

	// Token: 0x040018F7 RID: 6391
	private int maxCol;

	// Token: 0x040018F8 RID: 6392
	public static int maxEquip = 10;

	// Token: 0x040018F9 RID: 6393
	private int yE;

	// Token: 0x040018FA RID: 6394
	private int xE;

	// Token: 0x040018FB RID: 6395
	private int xIn;

	// Token: 0x040018FC RID: 6396
	private int yIn;

	// Token: 0x040018FD RID: 6397
	private int hTextCur;

	// Token: 0x040018FE RID: 6398
	private int yplus;

	// Token: 0x040018FF RID: 6399
	private MainItem itemCur;

	// Token: 0x04001900 RID: 6400
	private iCommand cmdChangeWear;

	// Token: 0x04001901 RID: 6401
	private iCommand cmdSetUniform;

	// Token: 0x04001902 RID: 6402
	private iCommand cmdDelUniform;

	// Token: 0x04001903 RID: 6403
	public static int[][] mposEquip;

	// Token: 0x04001904 RID: 6404
	private int hTextTicket;

	// Token: 0x04001905 RID: 6405
	private int hsaiso;

	// Token: 0x04001906 RID: 6406
	public sbyte[] valueEquip = new sbyte[]
	{
		0,
		1,
		2,
		3,
		4,
		5,
		6,
		7,
		8
	};
}
