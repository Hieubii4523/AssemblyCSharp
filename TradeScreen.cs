using System;

// Token: 0x0200010E RID: 270
public class TradeScreen : ScreenUpgrade
{
	// Token: 0x06000F9E RID: 3998 RVA: 0x0000C26D File Offset: 0x0000A46D
	public TradeScreen(sbyte typeRebuild, int size) : base(typeRebuild, size)
	{
	}

	// Token: 0x06000F9F RID: 3999 RVA: 0x0012B71C File Offset: 0x0012991C
	public override void setStart(sbyte typeRe, int size)
	{
		bool flag = this.wItem * 8 > this.w - 30;
		if (flag)
		{
			this.wItem = (this.w - 30) / 8;
		}
		this.wInven -= this.wInven % this.wItem;
		this.xtest = this.x + this.wInven + (this.w - this.wInven) / 2 - (this.wItem + 2) * 2 + 5;
		this.ytest = this.yInven;
		this.posName_Money = mSystem.new_M_Int(4, 2);
		this.posName_Money[0][0] = this.xtest;
		this.posName_Money[0][1] = this.ytest;
		this.posName_Money[1][0] = this.xtest;
		this.posName_Money[1][1] = this.ytest + 18 + this.wItem + 1;
		this.posName_Money[2][0] = this.xtest;
		this.posName_Money[2][1] = this.ytest + 18 + this.wItem + 13;
		this.posName_Money[3][0] = this.xtest;
		this.posName_Money[3][1] = this.ytest + 18 + this.wItem + 15 + this.wItem + 18;
		this.posUp = mSystem.new_M_Int(8, 2);
		for (int i = 0; i < this.posUp.Length; i++)
		{
			this.posUp[i][0] = this.xtest + i % 4 * (this.wItem + 2);
			this.posUp[i][1] = this.ytest + 15 + i / 4 * (30 + this.wItem);
		}
		this.maxNumItemW = this.wInven / this.wItem;
		int limX = ((Player.maxInventory - 1) / this.maxNumItemW + 1) * this.wItem - this.hInven;
		this.list = new ListNew(this.xInven, this.yInven, this.wInven, this.hInven, 0, 0, limX, true);
		this.objMain = new MainObject();
		this.objMain.name = GameScreen.player.name;
		bool flag2 = this.objMain.name.Length > 12;
		if (flag2)
		{
			this.objMain.name = GameScreen.player.name.Substring(0, 8) + "...";
		}
		this.objTrade = new MainObject();
		this.input = new InputDialog();
		this.cmdBovao = new iCommand(T.bovao, 0, this);
		this.cmdLock = new iCommand(T.strlock, 1, this);
		this.cmdTradeMoney = new iCommand(T.tradeMoney, 2, this);
		this.cmdTrade = new iCommand(T.trade, 4, this);
		this.cmdCancel = new iCommand(T.cancel, 5, this);
		this.cmdChat = new iCommand(T.TroChuyen, 6, this);
		this.cmdMenu = new iCommand(T.menu, 8, this);
		this.cmdClose = new iCommand(T.close, -1, this);
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.cmdClose.setPos(this.x + this.w - 15, this.y - 15 + 10 + 8, MainTab.fraCloseTab, string.Empty);
			this.cmdLock.setPos(this.x + this.wInven + (this.w - this.wInven) / 2 - 4 + iCommand.wButtonCmd / 2 + 7, this.y + this.h - iCommand.hButtonCmdNor / 2 - 5, null, this.cmdLock.caption);
			this.cmdTradeMoney.setPos(this.x + this.wInven + (this.w - this.wInven) / 2 - iCommand.wButtonCmd / 2 + 4 + 7, this.y + this.h - iCommand.hButtonCmdNor / 2 - 5, null, this.cmdTradeMoney.caption);
			this.vecCmd.addElement(this.cmdLock);
			this.vecCmd.addElement(this.cmdTradeMoney);
			this.cmdCancel.setPos(this.x + this.wInven + (this.w - this.wInven) / 2 + iCommand.wButtonCmd / 2 - 4, this.y + this.h - iCommand.hButtonCmdNor / 2 - 5, null, this.cmdCancel.caption);
			this.cmdTrade.setPos(this.x + this.wInven + (this.w - this.wInven) / 2 - iCommand.wButtonCmd / 2 + 4 + 5, this.y + this.h - iCommand.hButtonCmdNor / 2 - 5, null, this.cmdTrade.caption);
			int width = mFont.tahoma_7b_black.getWidth(this.objMain.name);
			this.cmdChat.setPos(this.xtest + width + 13, this.ytest + 4, Interface_Game.imgOther[1], string.Empty, 2);
			this.vecCmd.addElement(this.cmdChat);
			this.setSmallCmd();
		}
		ScreenUpgrade.mItemUpgrade = new MainItem[this.posUp.Length];
		this.nameScreen = T.trade;
		bool flag3 = !GameCanvas.isTouch;
		if (flag3)
		{
			this.right = this.cmdClose;
			this.left = this.cmdBovao;
		}
		this.menuCMD = this.cmdBovao;
		this.okCMD = this.cmdMenu;
		this.backCMD = this.cmdClose;
	}

	// Token: 0x06000FA0 RID: 4000 RVA: 0x0012BCB8 File Offset: 0x00129EB8
	private void setSmallCmd()
	{
		for (int i = 0; i < this.vecCmd.size(); i++)
		{
			iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
			iCommand.levelSmall = 1;
		}
	}

	// Token: 0x06000FA1 RID: 4001 RVA: 0x0012BCFC File Offset: 0x00129EFC
	public void setNameObjTrade(string name)
	{
		this.objTrade.name = name;
		this.indexAreaSellect = 0;
		bool flag = GameCanvas.isTouchNoOrPC();
		if (flag)
		{
			this.IdSelect = 0;
		}
		else
		{
			this.IdSelect = -1;
		}
		bool flag2 = this.IdSelect >= 0;
		if (flag2)
		{
			this.setPosCmd(this.getMenuActionItem());
		}
	}

	// Token: 0x06000FA2 RID: 4002 RVA: 0x0012BD5C File Offset: 0x00129F5C
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case -1:
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
			GlobalService.gI().Trade(5, 0, 0, 1, string.Empty);
			break;
		}
		case 0:
		{
			bool flag2 = this.itemCur != null;
			if (flag2)
			{
				bool flag3 = this.itemCur.typeObject == 3 || this.setCurrentInTrade(this.itemCur);
				if (flag3)
				{
					GlobalService.gI().Trade(1, this.itemCur.ID, this.itemCur.typeObject, 1, string.Empty);
				}
				else
				{
					this.input.setinfo(T.nhapsoluongmuongiaodich, new iCommand(T.strconfirm, 3, 1, this), true, T.vatpham);
					GameCanvas.currentDialog = this.input;
				}
			}
			break;
		}
		case 1:
			GlobalService.gI().Trade(3, 0, 0, 1, string.Empty);
			break;
		case 2:
			this.input.setinfo(T.nhapsotien, new iCommand(T.strconfirm, 3, 0, this), true, T.tradeMoney);
			GameCanvas.currentDialog = this.input;
			break;
		case 3:
		{
			int num = 0;
			try
			{
				num = int.Parse(this.input.tfInput.getText());
				bool flag4 = num < 0;
				if (flag4)
				{
					num = 0;
				}
			}
			catch (Exception)
			{
				num = 0;
			}
			if (subIndex != 0)
			{
				if (subIndex == 1)
				{
					GlobalService.gI().Trade(1, this.itemCur.ID, this.itemCur.typeObject, num, string.Empty);
				}
			}
			else
			{
				GlobalService.gI().Trade(1, 0, 6, num, string.Empty);
			}
			GameCanvas.end_Dialog();
			this.input = new InputDialog();
			break;
		}
		case 4:
			GlobalService.gI().Trade(4, 0, 0, 1, string.Empty);
			break;
		case 5:
		{
			GlobalService.gI().Trade(5, 0, 0, 1, string.Empty);
			bool flag5 = this.lastScreen != null;
			if (flag5)
			{
				this.lastScreen.Show(this.lastScreen.lastScreen);
			}
			else
			{
				GameCanvas.gameScr.Show();
			}
			break;
		}
		case 6:
			this.input.setinfo(T.nhapNoiDung, new iCommand(T.chat, 7, this), false, T.TroChuyen);
			GameCanvas.currentDialog = this.input;
			break;
		case 7:
		{
			string text = this.input.tfInput.getText();
			bool flag6 = text != null && text.Length > 0;
			if (flag6)
			{
				GlobalService.gI().Trade(2, 0, 0, 1, text);
				this.objMain.strChatPopup = text;
			}
			GameCanvas.end_Dialog();
			this.input = new InputDialog();
			break;
		}
		case 8:
			this.getMenu();
			break;
		}
	}

	// Token: 0x06000FA3 RID: 4003 RVA: 0x0012C088 File Offset: 0x0012A288
	public override void paintTrade(mGraphics g)
	{
		mFont.tahoma_7b_black.drawString(g, this.objMain.name, this.posName_Money[0][0], this.posName_Money[0][1], 0);
		AvMain.fraMoney.drawFrame(0, this.posName_Money[1][0] + AvMain.fraMoney.frameWidth / 2, this.posName_Money[1][1] + 5, 0, 3, g);
		mFont.tahoma_7_black.drawString(g, AvMain.getDotNumber(this.objMain.beli), this.posName_Money[1][0] + AvMain.fraMoney.frameWidth + 1, this.posName_Money[1][1], 0);
		mFont.tahoma_7b_black.drawString(g, this.objTrade.name, this.posName_Money[2][0], this.posName_Money[2][1], 0);
		AvMain.fraMoney.drawFrame(0, this.posName_Money[3][0] + AvMain.fraMoney.frameWidth / 2, this.posName_Money[3][1] + 5, 0, 3, g);
		mFont.tahoma_7_black.drawString(g, AvMain.getDotNumber(this.objTrade.beli), this.posName_Money[3][0] + AvMain.fraMoney.frameWidth + 1, this.posName_Money[3][1], 0);
		bool flag = this.objMain.isTrade > 0;
		if (flag)
		{
			g.setColor(16711680);
			g.drawRect(this.xtest - 2, this.ytest - 2 + 15, (this.wItem + 2) * 4 + 4, this.wItem + 4);
		}
		bool flag2 = this.objMain.isTrade == 2;
		if (flag2)
		{
			g.setColor(255);
			g.drawRect(this.xtest - 3, this.ytest - 3 + 15, (this.wItem + 2) * 4 + 6, this.wItem + 6);
		}
		bool flag3 = this.objTrade.isTrade > 0;
		if (flag3)
		{
			g.setColor(16711680);
			g.drawRect(this.xtest - 2, this.ytest - 2 + 45 + this.wItem, (this.wItem + 2) * 4 + 4, this.wItem + 4);
		}
		bool flag4 = this.objTrade.isTrade == 2;
		if (flag4)
		{
			g.setColor(255);
			g.drawRect(this.xtest - 3, this.ytest - 3 + 45 + this.wItem, (this.wItem + 2) * 4 + 6, this.wItem + 6);
		}
	}

	// Token: 0x06000FA4 RID: 4004 RVA: 0x0012C314 File Offset: 0x0012A514
	public override void paintPosItem(mGraphics g)
	{
		for (int i = 0; i < this.posUp.Length; i++)
		{
			AvMain.paintRect(g, this.posUp[i][0], this.posUp[i][1], this.wItem, this.wItem, 1, 3);
		}
		for (int j = 0; j < this.objMain.vecTrade.size(); j++)
		{
			MainItem mainItem = (MainItem)this.objMain.vecTrade.elementAt(j);
			bool flag = mainItem.typeObject == 3;
			if (flag)
			{
				mainItem.paintColor(g, this.posUp[j][0] + this.wItem / 2, this.posUp[j][1] + this.wItem / 2, this.wItem);
			}
			mainItem.paint(g, this.posUp[j][0] + this.wItem / 2, this.posUp[j][1] + this.wItem / 2, this.wItem);
		}
		for (int k = 0; k < this.objTrade.vecTrade.size(); k++)
		{
			MainItem mainItem2 = (MainItem)this.objTrade.vecTrade.elementAt(k);
			bool flag2 = mainItem2.typeObject == 3;
			if (flag2)
			{
				mainItem2.paintColor(g, this.posUp[4 + k][0] + this.wItem / 2, this.posUp[4 + k][1] + this.wItem / 2, this.wItem);
			}
			mainItem2.paint(g, this.posUp[4 + k][0] + this.wItem / 2, this.posUp[4 + k][1] + this.wItem / 2, this.wItem);
		}
		bool flag3 = this.indexAreaSellect != 1;
		if (!flag3)
		{
			for (int l = 0; l < this.posUp.Length; l++)
			{
				bool flag4 = this.IdSelect == l;
				if (flag4)
				{
					g.setColor(16777215);
					g.drawRect(this.posUp[l][0] + 1, this.posUp[l][1] + 1, this.wItem - 2, this.wItem - 2);
					bool flag5 = !GameCanvas.isSmallScreen;
					if (flag5)
					{
						g.drawRect(this.posUp[l][0] + 2, this.posUp[l][1] + 2, this.wItem - 4, this.wItem - 4);
					}
				}
			}
		}
	}

	// Token: 0x06000FA5 RID: 4005 RVA: 0x0012C5BC File Offset: 0x0012A7BC
	public override void paintChat(mGraphics g)
	{
		bool flag = this.objMain.chat != null;
		if (flag)
		{
			this.objMain.chat.paint(g);
		}
		bool flag2 = this.objTrade.chat != null;
		if (flag2)
		{
			this.objTrade.chat.paint(g);
		}
	}

	// Token: 0x06000FA6 RID: 4006 RVA: 0x0012C618 File Offset: 0x0012A818
	public override void paintIconUpgrade(mGraphics g, int x, int y, MainItem item)
	{
		bool flag = this.setCurrentInTrade(item);
		if (flag)
		{
			bool flag2 = AvMain.imgTrade2 == null;
			if (flag2)
			{
				AvMain.imgTrade2 = mImage.createImage("/interface/icontrade2.png");
			}
			else
			{
				g.drawImage(AvMain.imgTrade2, x, y, mGraphics.BOTTOM | mGraphics.LEFT);
			}
		}
	}

	// Token: 0x06000FA7 RID: 4007 RVA: 0x0012C670 File Offset: 0x0012A870
	public override void update()
	{
		base.update();
		this.updateChatPopup(this.objMain);
		this.updateChatPopup(this.objTrade);
		bool flag = GameCanvas.isTouch && !GameCanvas.menu.isShowMenu && this.cmdChat.caption.Length > 0;
		if (flag)
		{
			this.cmdChat.caption = string.Empty;
		}
	}

	// Token: 0x06000FA8 RID: 4008 RVA: 0x0012C6E0 File Offset: 0x0012A8E0
	public override void updatekey()
	{
		bool flag = false;
		bool flag2 = this.indexAreaSellect == 0;
		if (flag2)
		{
			bool flag3 = GameCanvas.keyMove(0);
			if (flag3)
			{
				this.IdSelect--;
				GameCanvas.ClearkeyMove(0);
				flag = true;
			}
			else
			{
				bool flag4 = GameCanvas.keyMove(2);
				if (flag4)
				{
					bool flag5 = this.IdSelect % this.maxNumItemW == this.maxNumItemW - 1 || this.IdSelect >= Player.vecInventory.size() - 1;
					if (flag5)
					{
						this.indexAreaSellect = 1;
						this.IdSelect = 0;
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
					bool flag6 = GameCanvas.keyMove(1);
					if (flag6)
					{
						bool flag7 = this.IdSelect >= this.maxNumItemW;
						if (flag7)
						{
							this.IdSelect -= this.maxNumItemW;
						}
						GameCanvas.ClearkeyMove(1);
						flag = true;
					}
					else
					{
						bool flag8 = GameCanvas.keyMove(3);
						if (flag8)
						{
							bool flag9 = this.IdSelect < Player.vecInventory.size() - this.maxNumItemW;
							if (flag9)
							{
								this.IdSelect += this.maxNumItemW;
							}
							GameCanvas.ClearkeyMove(3);
							flag = true;
						}
					}
				}
			}
		}
		else
		{
			bool flag10 = this.indexAreaSellect == 1;
			if (flag10)
			{
				bool flag11 = GameCanvas.keyMove(0);
				if (flag11)
				{
					bool flag12 = this.IdSelect % 4 == 0;
					if (flag12)
					{
						this.indexAreaSellect = 0;
						this.IdSelect = 0;
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
					bool flag13 = GameCanvas.keyMove(2);
					if (flag13)
					{
						bool flag14 = this.IdSelect % 4 < 3;
						if (flag14)
						{
							this.IdSelect++;
							flag = true;
						}
						GameCanvas.ClearkeyMove(2);
					}
					else
					{
						bool flag15 = GameCanvas.keyMove(1);
						if (flag15)
						{
							bool flag16 = this.IdSelect >= 4;
							if (flag16)
							{
								this.IdSelect -= 4;
							}
							GameCanvas.ClearkeyMove(1);
							flag = true;
						}
						else
						{
							bool flag17 = GameCanvas.keyMove(3);
							if (flag17)
							{
								bool flag18 = this.IdSelect < 4;
								if (flag18)
								{
									this.IdSelect += 4;
								}
								GameCanvas.ClearkeyMove(3);
								flag = true;
							}
						}
					}
				}
			}
		}
		bool flag19 = flag;
		if (flag19)
		{
			this.getItemCurNew();
		}
		base.updatekey();
		this.updatekeyPC();
	}

	// Token: 0x06000FA9 RID: 4009 RVA: 0x0012C960 File Offset: 0x0012AB60
	public override void updatePointer()
	{
		bool flag = GameCanvas.isPointSelect(this.xInven, this.yInven, this.wInven, this.hInven);
		if (flag)
		{
			this.indexAreaSellect = 0;
		}
		else
		{
			for (int i = 0; i < this.posUp.Length; i++)
			{
				bool flag2 = GameCanvas.isPointSelect(this.posUp[i][0], this.posUp[i][1], this.wItem, this.wItem);
				if (flag2)
				{
					this.indexAreaSellect = 1;
					this.IdSelect = i;
					this.getItemCurNew();
					break;
				}
			}
		}
		base.updatePointer();
	}

	// Token: 0x06000FAA RID: 4010 RVA: 0x0012CA00 File Offset: 0x0012AC00
	public override void getItemCurNew()
	{
		this.isShowInfo = false;
		bool flag = this.indexAreaSellect == 0;
		if (flag)
		{
			this.IdSelect = AvMain.resetSelect(this.IdSelect, Player.vecInventory.size() - 1, false);
			bool flag2 = !GameCanvas.isTouch;
			if (flag2)
			{
				this.list.setToX((this.IdSelect / this.maxNumItemW + 1) * this.wItem - this.h / 2);
			}
		}
		bool flag3 = this.IdSelect >= 0;
		if (flag3)
		{
			this.setPosCmd(this.getMenuActionItem());
		}
	}

	// Token: 0x06000FAB RID: 4011 RVA: 0x0012CA9C File Offset: 0x0012AC9C
	public override mVector getMenuActionItem()
	{
		mVector result = null;
		bool flag = this.indexAreaSellect == 0;
		if (flag)
		{
			MainItem mainItem = (MainItem)Player.vecInventory.elementAt(this.IdSelect);
			bool flag2 = mainItem != null;
			if (flag2)
			{
				this.itemCur = mainItem;
			}
			bool flag3 = this.itemCur != null;
			if (flag3)
			{
				this.cmdBovao.caption = T.bovao;
				bool flag4 = this.setCurrentInTrade(this.itemCur);
				if (flag4)
				{
					this.cmdBovao.caption = T.layra;
				}
				result = this.itemCur.getActionTrade();
			}
		}
		else
		{
			bool flag5 = this.indexAreaSellect == 1;
			if (flag5)
			{
				this.itemCur = null;
				bool flag6 = this.IdSelect < 4;
				if (flag6)
				{
					bool flag7 = this.IdSelect < this.objMain.vecTrade.size();
					if (flag7)
					{
						MainItem mainItem2 = (MainItem)this.objMain.vecTrade.elementAt(this.IdSelect);
						bool flag8 = mainItem2 != null;
						if (flag8)
						{
							this.itemCur = mainItem2;
						}
					}
				}
				else
				{
					bool flag9 = this.IdSelect < 8 && this.IdSelect - 4 < this.objTrade.vecTrade.size();
					if (flag9)
					{
						MainItem mainItem3 = (MainItem)this.objTrade.vecTrade.elementAt(this.IdSelect - 4);
						bool flag10 = mainItem3 != null;
						if (flag10)
						{
							this.itemCur = mainItem3;
						}
					}
				}
			}
		}
		return result;
	}

	// Token: 0x06000FAC RID: 4012 RVA: 0x0012CC24 File Offset: 0x0012AE24
	public override void setPosCmd(mVector vec)
	{
		this.left = null;
		this.center = null;
		this.vecCmd.removeAllElements();
		bool flag = vec != null;
		if (flag)
		{
			bool isTouch = GameCanvas.isTouch;
			if (isTouch)
			{
				this.vecCmd = vec;
				for (int i = 0; i < this.vecCmd.size(); i++)
				{
					iCommand cmd = (iCommand)this.vecCmd.elementAt(i);
					bool flag2 = i == 0;
					if (flag2)
					{
						cmd = AvMain.setPosCMD(cmd, 1);
					}
					bool flag3 = i == 1;
					if (flag3)
					{
						cmd = AvMain.setPosCMD(cmd, 2);
					}
				}
			}
			else
			{
				for (int j = 0; j < vec.size(); j++)
				{
					iCommand iCommand = (iCommand)vec.elementAt(j);
					bool flag4 = j == 0;
					if (flag4)
					{
						this.center = iCommand;
					}
					bool flag5 = j == 1;
					if (flag5)
					{
						this.left = iCommand;
					}
				}
			}
		}
		bool isTouch2 = GameCanvas.isTouch;
		if (isTouch2)
		{
			this.vecCmd.addElement(this.cmdClose);
			this.vecCmd.addElement(this.cmdChat);
			bool flag6 = this.objMain.isTrade == 0;
			if (flag6)
			{
				this.vecCmd.addElement(this.cmdLock);
				this.vecCmd.addElement(this.cmdTradeMoney);
			}
			else
			{
				bool flag7 = this.objMain.isTrade == 1;
				if (flag7)
				{
					this.vecCmd.addElement(this.cmdTrade);
					this.vecCmd.addElement(this.cmdCancel);
				}
				else
				{
					bool flag8 = this.objMain.isTrade == 2;
					if (flag8)
					{
						this.vecCmd.addElement(this.cmdCancel);
					}
				}
			}
		}
		else
		{
			this.right = this.cmdClose;
			this.left = this.cmdMenu;
		}
		this.setSmallCmd();
	}

	// Token: 0x06000FAD RID: 4013 RVA: 0x000734DC File Offset: 0x000716DC
	public override bool isGetItemUpgrade(short Id, sbyte cat)
	{
		return false;
	}

	// Token: 0x06000FAE RID: 4014 RVA: 0x0000BF67 File Offset: 0x0000A167
	public override void updateNewUpgrade()
	{
		this.isShowInfo = false;
		this.getItemCurNew();
	}

	// Token: 0x06000FAF RID: 4015 RVA: 0x000090B5 File Offset: 0x000072B5
	public override void setStep()
	{
	}

	// Token: 0x06000FB0 RID: 4016 RVA: 0x0012CE14 File Offset: 0x0012B014
	public bool setCurrentInTrade(MainItem item)
	{
		for (int i = 0; i < this.objMain.vecTrade.size(); i++)
		{
			MainItem mainItem = (MainItem)this.objMain.vecTrade.elementAt(i);
			bool flag = mainItem.ID == item.ID && mainItem.typeObject == item.typeObject;
			if (flag)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000FB1 RID: 4017 RVA: 0x0012CE8C File Offset: 0x0012B08C
	public void setItem(sbyte ai, sbyte action, MainItem item)
	{
		MainObject mainObject = (ai != 0) ? this.objTrade : this.objMain;
		bool flag = action == 0;
		if (flag)
		{
			for (int i = 0; i < mainObject.vecTrade.size(); i++)
			{
				MainItem mainItem = (MainItem)mainObject.vecTrade.elementAt(i);
				bool flag2 = mainItem.ID == item.ID && mainItem.typeObject == item.typeObject;
				if (flag2)
				{
					mainObject.vecTrade.removeElement(mainItem);
					i--;
				}
			}
		}
		else
		{
			bool flag3 = action == 1;
			if (flag3)
			{
				mainObject.vecTrade.addElement(item);
			}
		}
		bool flag4 = ai == 0;
		if (flag4)
		{
			this.updateNewUpgrade();
		}
	}

	// Token: 0x06000FB2 RID: 4018 RVA: 0x0012CF4C File Offset: 0x0012B14C
	public void setLock()
	{
		for (int i = 0; i < this.vecCmd.size(); i++)
		{
			iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
			bool flag = iCommand != this.cmdClose;
			if (flag)
			{
				this.vecCmd.removeElement(iCommand);
				i--;
			}
		}
		this.vecCmd.addElement(this.cmdTrade);
		this.vecCmd.addElement(this.cmdCancel);
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.vecCmd.addElement(this.cmdChat);
		}
		this.setSmallCmd();
	}

	// Token: 0x06000FB3 RID: 4019 RVA: 0x0012CFF8 File Offset: 0x0012B1F8
	public void setTrade()
	{
		for (int i = 0; i < this.vecCmd.size(); i++)
		{
			iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
			bool flag = iCommand != this.cmdClose;
			if (flag)
			{
				this.vecCmd.removeElement(iCommand);
				i--;
			}
		}
		this.cmdCancel.setPos(this.x + this.wInven + (this.w - this.wInven) / 2, this.y + this.h - iCommand.hButtonCmdNor / 2 - 5, null, this.cmdCancel.caption);
		this.vecCmd.addElement(this.cmdCancel);
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.vecCmd.addElement(this.cmdChat);
		}
		this.setSmallCmd();
	}

	// Token: 0x06000FB4 RID: 4020 RVA: 0x0012D0DC File Offset: 0x0012B2DC
	public void getMenu()
	{
		mVector mVector = new mVector();
		this.cmdChat.caption = T.TroChuyen;
		mVector.addElement(this.cmdChat);
		bool flag = this.objMain.isTrade == 0;
		if (flag)
		{
			mVector.addElement(this.cmdTradeMoney);
			mVector.addElement(this.cmdLock);
		}
		else
		{
			bool flag2 = this.objMain.isTrade == 1;
			if (flag2)
			{
				mVector.addElement(this.cmdTrade);
				mVector.addElement(this.cmdCancel);
			}
			else
			{
				bool flag3 = this.objMain.isTrade == 2;
				if (flag3)
				{
					mVector.addElement(this.cmdCancel);
				}
			}
		}
		GameCanvas.menu.startAt(mVector, 2, T.cmdChucNang);
	}

	// Token: 0x06000FB5 RID: 4021 RVA: 0x0012D1A0 File Offset: 0x0012B3A0
	public void addChat(string str, MainObject obj)
	{
		bool flag = obj.chat == null;
		if (flag)
		{
			obj.chat = new PopupChat();
		}
		obj.chat.setChat(str, true);
		bool flag2 = obj == this.objMain;
		if (flag2)
		{
			obj.chat.updatePos(this.xtest + obj.chat.w / 2, this.posName_Money[0][1] - 5);
		}
		else
		{
			obj.chat.updatePos(this.xtest + obj.chat.w / 2, this.posName_Money[2][1] - 5);
		}
	}

	// Token: 0x06000FB6 RID: 4022 RVA: 0x0012D244 File Offset: 0x0012B444
	public void updateChatPopup(MainObject obj)
	{
		bool flag = obj.strChatPopup != null;
		if (flag)
		{
			this.addChat(obj.strChatPopup, obj);
			obj.strChatPopup = null;
		}
		bool flag2 = obj.chat != null && obj.chat.setOff();
		if (flag2)
		{
			obj.chat = null;
		}
	}

	// Token: 0x06000FB7 RID: 4023 RVA: 0x0012D29C File Offset: 0x0012B49C
	public override void setPosInfo()
	{
		bool flag = this.indexAreaSellect == 0;
		if (flag)
		{
			base.setPosInfo(this.itemCur, this.xInven, this.yInven + (this.IdSelect / this.maxNumItemW + 1) * this.wItem - this.list.cmx + 4);
		}
		else
		{
			bool flag2 = this.indexAreaSellect == 1;
			if (flag2)
			{
				base.setPosInfo(this.itemCur, this.xInven + this.wInven - this.itemCur.wInfo, this.yInven + 15 + this.IdSelect / 4 * (30 + this.wItem) - this.list.cmx + 4);
			}
		}
	}

	// Token: 0x06000FB8 RID: 4024 RVA: 0x0012D358 File Offset: 0x0012B558
	public override void paintlockTrade(mGraphics g, MainItem item, int x, int y)
	{
		bool flag = item.isTrade != 0;
		if (flag)
		{
			g.drawRegion(AvMain.imgDelay, 0, 0, this.wItem, this.wItem, 0, (float)x, (float)y, 3);
		}
	}

	// Token: 0x06000FB9 RID: 4025 RVA: 0x0012D398 File Offset: 0x0012B598
	public override bool keyBack()
	{
		bool flag = !base.keyBack() && this.cmdClose != null;
		if (flag)
		{
			this.cmdClose.perform();
		}
		return false;
	}

	// Token: 0x04001A26 RID: 6694
	public MainObject objMain;

	// Token: 0x04001A27 RID: 6695
	public MainObject objTrade;

	// Token: 0x04001A28 RID: 6696
	private int[][] posName_Money;

	// Token: 0x04001A29 RID: 6697
	private iCommand cmdTradeMoney;

	// Token: 0x04001A2A RID: 6698
	private iCommand cmdLock;

	// Token: 0x04001A2B RID: 6699
	private iCommand cmdTrade;

	// Token: 0x04001A2C RID: 6700
	private iCommand cmdChat;

	// Token: 0x04001A2D RID: 6701
	private iCommand cmdCancel;

	// Token: 0x04001A2E RID: 6702
	private new iCommand cmdMenu;

	// Token: 0x04001A2F RID: 6703
	private InputDialog input;

	// Token: 0x04001A30 RID: 6704
	private int xtest;

	// Token: 0x04001A31 RID: 6705
	private int ytest;

	// Token: 0x04001A32 RID: 6706
	public new static TradeScreen instance;
}
