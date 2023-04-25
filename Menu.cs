using System;

// Token: 0x02000093 RID: 147
public class Menu : AvMain
{
	// Token: 0x06000927 RID: 2343 RVA: 0x000BE5CC File Offset: 0x000BC7CC
	public void beginMenu()
	{
		this.cmdClose = new iCommand(T.close, 1, this);
		Menu.isLoadData = false;
		this.waitToPerform = 0;
		this.runText = null;
		this.right = null;
		this.SelectFocus = 0;
		this.menuSelectedItem = 0;
		this.menuItems.removeAllElements();
		this.backCMD = this.cmdClose;
	}

	// Token: 0x06000928 RID: 2344 RVA: 0x000BE630 File Offset: 0x000BC830
	public void startAt(mVector menuItems, int pos, string name)
	{
		this.beginMenu();
		Menu.isNPCMenu = 0;
		this.nameMenu = name;
		this.pos = pos;
		bool flag = menuItems == null || menuItems.size() == 0;
		if (!flag)
		{
			this.menuItems = menuItems;
			this.isShowMenu = true;
			bool flag2 = pos == -1;
			if (flag2)
			{
				this.menuItems.addElement(this.cmdClose);
				this.hPlus = 0;
				this.menuW = 60;
				this.menuH = 60;
				for (int i = 0; i < menuItems.size(); i++)
				{
					iCommand iCommand = (iCommand)menuItems.elementAt(i);
					int width = mFont.tahoma_7_yellow.getWidth(iCommand.caption);
					bool flag3 = width > this.menuW - 8;
					if (flag3)
					{
						iCommand.subCaption = mFont.tahoma_7b_yellow.splitFontArray(iCommand.caption, this.menuW - 8);
					}
				}
				this.wUni = menuItems.size() * this.menuW - 1;
				bool flag4 = this.wUni > MotherCanvas.w - 2;
				if (flag4)
				{
					this.wUni = MotherCanvas.w - 2;
				}
				this.menuX = MotherCanvas.hw - this.wUni / 2;
				bool flag5 = this.menuX < 1;
				if (flag5)
				{
					this.menuX = 1;
				}
				this.menuY = MotherCanvas.h - this.menuH - (GameCanvas.hCommand + 1);
				bool isTouch = GameCanvas.isTouch;
				if (isTouch)
				{
					this.menuY -= 3;
				}
				this.menuY += 27;
				this.menuTemY = this.menuY;
				this.cmxLim = this.menuItems.size() * this.menuW - MotherCanvas.w;
				bool flag6 = this.cmxLim < 0;
				if (flag6)
				{
					this.cmxLim = 0;
				}
				this.cmtoX = 0;
				this.cmx = 0;
				this.xc = 50;
			}
			else
			{
				this.menuW = GameCanvas.hCommand;
				bool isTouch2 = GameCanvas.isTouch;
				if (isTouch2)
				{
					this.menuW = 32;
				}
				this.sizeMenu = MotherCanvas.h / 4 * 3 / this.menuW - 1;
				this.wUni = MotherCanvas.w / 3;
				bool flag7 = this.wUni < mFont.tahoma_7b_white.getWidth(name) + 30;
				if (flag7)
				{
					this.wUni = mFont.tahoma_7b_white.getWidth(name) + 30;
				}
				this.hPlus = GameCanvas.hCommand;
				int num = 120;
				int num2 = 30;
				for (int j = 0; j < menuItems.size(); j++)
				{
					iCommand iCommand2 = (iCommand)menuItems.elementAt(j);
					int num3 = mFont.tahoma_7b_white.getWidth(iCommand2.caption) + num2;
					bool flag8 = num3 > num;
					if (flag8)
					{
						num = num3;
					}
					bool flag9 = iCommand2.wimgCaption > 0 && num3 + iCommand2.wimgCaption > num;
					if (flag9)
					{
						num = num3 + iCommand2.wimgCaption;
					}
				}
				bool flag10 = this.wUni < num;
				if (flag10)
				{
					this.wUni = num;
				}
				bool flag11 = this.wUni > MotherCanvas.w;
				if (flag11)
				{
					this.wUni = MotherCanvas.w;
				}
				this.cmtoX = 0;
				this.cmx = 0;
				iCommand iCommand3 = null;
				bool isTouch3 = GameCanvas.isTouch;
				if (isTouch3)
				{
					iCommand3 = this.cmdClose;
				}
				else
				{
					this.menuItems.addElement(this.cmdClose);
				}
				bool flag12 = menuItems.size() > this.sizeMenu;
				if (flag12)
				{
					this.menuH = this.sizeMenu * this.menuW + 8;
					this.cmxLim = (menuItems.size() - this.sizeMenu) * this.menuW;
				}
				else
				{
					this.menuH = menuItems.size() * this.menuW + 8;
					this.cmxLim = 0;
				}
				this.setPos();
				this.menuTemY = this.menuY;
				bool flag13 = iCommand3 != null;
				if (flag13)
				{
					iCommand3.setPos(this.menuX + this.wUni - 11, this.menuY - this.hPlus + GameCanvas.hCommand / 2 + 1 + 3, MainTab.fraCloseTab, string.Empty);
					this.right = iCommand3;
				}
			}
			bool flag14 = GameCanvas.isTouchNoOrPC();
			if (flag14)
			{
				this.menuSelectedItem = 0;
			}
			else
			{
				this.menuSelectedItem = -1;
			}
			Menu.isLoadData = true;
			this.resetBegin();
			GameCanvas.ShowMenu(GameCanvas.menu);
		}
	}

	// Token: 0x06000929 RID: 2345 RVA: 0x0000B00C File Offset: 0x0000920C
	public void updateMenuGame(mVector vec)
	{
		this.menuItems = vec;
	}

	// Token: 0x0600092A RID: 2346 RVA: 0x000BEAAC File Offset: 0x000BCCAC
	public void setinfoDynamic(mVector menulist, int pos, int idmenu, int idnpc, string name)
	{
		this.beginMenu();
		bool flag = menulist == null;
		if (!flag)
		{
			this.nameMenu = name;
			Menu.isNPCMenu = 0;
			this.IdMenu = idmenu;
			this.IdNpc = idnpc;
			this.pos = pos;
			this.isShowMenu = true;
			this.menuItems = new mVector();
			this.menuW = GameCanvas.hCommand;
			bool isTouch = GameCanvas.isTouch;
			if (isTouch)
			{
				this.menuW = 32;
			}
			this.sizeMenu = MotherCanvas.h / 4 * 3 / this.menuW - 1;
			this.wUni = MotherCanvas.w / 3;
			this.hPlus = GameCanvas.hCommand;
			int num = 120;
			bool flag2 = num < mFont.tahoma_7b_white.getWidth(name) + 45;
			if (flag2)
			{
				num = mFont.tahoma_7b_white.getWidth(name) + 45;
			}
			for (int i = 0; i < menulist.size(); i++)
			{
				iCommand iCommand = (iCommand)menulist.elementAt(i);
				iCommand.indexMenu = 2;
				iCommand.Pointer = this;
				int num2 = mFont.tahoma_7b_white.getWidth(iCommand.caption) + 30;
				bool flag3 = iCommand.fraImgCaption != null;
				if (flag3)
				{
					num2 += iCommand.fraImgCaption.frameWidth;
				}
				bool flag4 = iCommand.item != null;
				if (flag4)
				{
					num2 += 20;
				}
				bool flag5 = num2 > num;
				if (flag5)
				{
					num = num2;
				}
			}
			this.menuItems = menulist;
			iCommand iCommand2 = null;
			bool isTouch2 = GameCanvas.isTouch;
			if (isTouch2)
			{
				iCommand2 = this.cmdClose;
			}
			else
			{
				this.menuItems.addElement(this.cmdClose);
			}
			this.wUni = num;
			bool flag6 = this.wUni > MotherCanvas.w;
			if (flag6)
			{
				this.wUni = MotherCanvas.w;
			}
			bool flag7 = this.menuItems.size() > this.sizeMenu;
			if (flag7)
			{
				this.menuH = this.sizeMenu * this.menuW + 8;
				this.cmxLim = (this.menuItems.size() - this.sizeMenu) * this.menuW;
			}
			else
			{
				this.menuH = this.menuItems.size() * this.menuW + 8;
				this.cmxLim = 0;
			}
			this.cmtoX = 0;
			this.cmx = 0;
			this.setPos();
			this.menuTemY = this.menuY;
			bool flag8 = iCommand2 != null;
			if (flag8)
			{
				iCommand2.setPos(this.menuX + this.wUni - 8, this.menuY - this.hPlus + GameCanvas.hCommand / 2 + 1 + 3, MainTab.fraCloseTab, string.Empty);
				this.right = iCommand2;
			}
			bool flag9 = GameCanvas.isTouchNoOrPC();
			if (flag9)
			{
				this.menuSelectedItem = 0;
			}
			else
			{
				this.menuSelectedItem = -1;
			}
			Menu.isLoadData = true;
			this.resetBegin();
			GameCanvas.ShowMenu(GameCanvas.menu);
		}
	}

	// Token: 0x0600092B RID: 2347 RVA: 0x000BED98 File Offset: 0x000BCF98
	public void startAt_NPC(mVector menuItems, string name, int idNPC, sbyte typeO, bool isHelp, int archor, bool isDynamic)
	{
		this.beginMenu();
		Menu.isNPCMenu = 1;
		this.nameMenu = name;
		this.IdNpc = idNPC;
		Menu.IdNPCLast = idNPC;
		this.typeO = typeO;
		this.archorRunText = archor;
		bool flag = menuItems == null || menuItems.size() == 0;
		if (flag)
		{
			this.menuItems = new mVector();
		}
		else
		{
			this.menuItems = menuItems;
		}
		for (int i = 0; i < this.menuItems.size(); i++)
		{
			iCommand iCommand = (iCommand)this.menuItems.elementAt(i);
			bool flag2 = !isHelp;
			if (flag2)
			{
				iCommand.setTypeSpec();
			}
			if (isDynamic)
			{
				iCommand.indexMenu = 3;
				iCommand.subIndex = i;
				iCommand.Pointer = this;
			}
			bool flag3 = i == 0 && !GameCanvas.isTouch;
			if (flag3)
			{
				iCommand.isSelect = true;
			}
		}
		this.isShowMenu = true;
		this.menuW = GameCanvas.hCommand;
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.menuW = 32;
		}
		this.sizeMenu = 0;
		this.wUni = MotherCanvas.w - 10;
		bool flag4 = this.wUni > 300;
		if (flag4)
		{
			this.wUni = 300;
		}
		this.mStrTalk = mFont.tahoma_7_black.splitFontArray(name, this.wUni - 20);
		this.hPlus = GameCanvas.hCommand;
		this.cmtoX = 0;
		this.cmx = 0;
		int num = this.mStrTalk.Length;
		iCommand iCommand2 = this.cmdClose;
		bool flag5 = !isHelp;
		if (flag5)
		{
			iCommand2.setTypeSpec();
		}
		this.menuItems.addElement(iCommand2);
		this.menuH = (num + 2) * GameCanvas.hText + iCommand.hButtonCmdSpec + 5;
		this.cmxLim = 0;
		this.menuX = MotherCanvas.hw - this.wUni / 2;
		this.menuY = MotherCanvas.h - this.menuH - 10;
		this.menuTemY = this.menuY;
		this.runText = new RunWord();
		this.runText.startDialogChain(name, 0, this.menuX + 10, this.menuY + 10 + GameCanvas.hText, this.wUni - 20, mFont.tahoma_7_white);
		this.setPosNPC(iCommand.hButtonCmdSpec);
		bool flag6 = GameCanvas.isTouchNoOrPC();
		if (flag6)
		{
			this.menuSelectedItem = 0;
		}
		else
		{
			this.menuSelectedItem = -1;
		}
		Menu.isLoadData = true;
		this.resetBegin();
		GameCanvas.ShowMenu(GameCanvas.menu);
	}

	// Token: 0x0600092C RID: 2348 RVA: 0x000BF020 File Offset: 0x000BD220
	public void startAt_NPC_Quest(mVector menuItems, string name, int idNPC, sbyte typeO, bool isQuest, int archor)
	{
		this.beginMenu();
		Menu.isNPCMenu = 1;
		this.nameMenu = name;
		this.IdNpc = idNPC;
		Menu.IdNPCLast = idNPC;
		this.typeO = typeO;
		this.archorRunText = archor;
		bool flag = menuItems == null || menuItems.size() == 0;
		if (flag)
		{
			this.menuItems = new mVector();
		}
		else
		{
			this.menuItems = menuItems;
		}
		this.isShowMenu = true;
		this.menuW = GameCanvas.hCommand;
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.menuW = 32;
		}
		this.sizeMenu = 0;
		this.wUni = MotherCanvas.w - 10;
		bool flag2 = this.wUni > 300;
		if (flag2)
		{
			this.wUni = 300;
		}
		this.mStrTalk = mFont.tahoma_7_black.splitFontArray(name, this.wUni - 20);
		this.hPlus = GameCanvas.hCommand;
		this.cmtoX = 0;
		this.cmx = 0;
		int num = this.mStrTalk.Length;
		bool flag3 = !isQuest;
		if (flag3)
		{
			iCommand iCommand = this.cmdClose;
			iCommand.setTypeSpec();
			this.menuItems.addElement(iCommand);
		}
		else
		{
			bool flag4 = num < 3;
			if (flag4)
			{
				num = 3;
			}
		}
		this.menuH = (num + 2) * GameCanvas.hText + iCommand.hButtonCmdNor / 2;
		this.cmxLim = 0;
		this.menuX = MotherCanvas.hw - this.wUni / 2;
		this.menuY = MotherCanvas.h - this.menuH - 10;
		this.menuTemY = this.menuY;
		this.runText = new RunWord();
		this.runText.startDialogChain(name, 0, this.menuX + 10, this.menuY + 10 + GameCanvas.hText, this.wUni - 20, mFont.tahoma_7_white);
		for (int i = 0; i < menuItems.size(); i++)
		{
			iCommand iCommand2 = (iCommand)menuItems.elementAt(i);
			iCommand2.setPos(this.menuX + this.wUni - iCommand.wButtonCmd / 2, this.menuY + this.menuH - iCommand.hButtonCmdNor / 2, null, iCommand2.caption);
			iCommand2.setTypeNone(this.menuX, this.menuY, this.wUni, this.menuH);
			iCommand2.setIsEffTest(true);
		}
		bool flag5 = GameCanvas.isTouchNoOrPC();
		if (flag5)
		{
			this.menuSelectedItem = 0;
		}
		else
		{
			this.menuSelectedItem = -1;
		}
		Menu.isLoadData = true;
		this.resetBegin();
		GameCanvas.ShowMenu(GameCanvas.menu);
	}

	// Token: 0x0600092D RID: 2349 RVA: 0x000BF2B4 File Offset: 0x000BD4B4
	public void startTabMenu(mVector menuItems)
	{
		this.beginMenu();
		Menu.isNPCMenu = 0;
		this.menuSelectedItem = 0;
		this.menuItems = menuItems;
		this.isShowMenu = true;
		this.hPlus = GameCanvas.hCommand;
		this.sizeMenu = this.menuH / this.menuW;
		this.cmtoX = 0;
		this.cmx = 0;
		bool flag = this.sizeMenu - 1 < menuItems.size();
		if (flag)
		{
			this.cmxLim = menuItems.size() * this.menuW - this.menuH;
		}
		else
		{
			this.cmxLim = 0;
		}
		bool flag2 = this.cmxLim < 0;
		if (flag2)
		{
			this.cmxLim = 0;
		}
		bool flag3 = GameCanvas.isTouchNoOrPC();
		if (flag3)
		{
			this.menuSelectedItem = 0;
		}
		else
		{
			this.menuSelectedItem = -1;
		}
		Menu.isLoadData = true;
		this.resetBegin();
	}

	// Token: 0x0600092E RID: 2350 RVA: 0x000BF38C File Offset: 0x000BD58C
	public void resetBegin()
	{
		for (int i = 0; i < this.pointerDownLastX.Length; i++)
		{
			this.pointerDownLastX[i] = 0;
		}
		this.pointerDownTime = 0;
		this.pointerDownFirstX = 0;
		this.pointerIsDowning = false;
		this.isDownWhenRunning = false;
		this.waitToPerform = 0;
		this.cmRun = 0;
		this.timeShow = 0;
		bool flag = GameScreen.player != null;
		if (flag)
		{
			GameScreen.player.resetAction();
		}
	}

	// Token: 0x0600092F RID: 2351 RVA: 0x000BF408 File Offset: 0x000BD608
	public void setPosNPC(int hBut)
	{
		int num = this.menuItems.size();
		this.xBegin = num * ((iCommand.wButtonCmd + 6) / 2) - 3;
		for (int i = 0; i < num; i++)
		{
			iCommand iCommand = (iCommand)this.menuItems.elementAt(i);
			iCommand.setPos(this.menuX + iCommand.wButtonCmd / 2 + this.wUni / 2 - this.xBegin + i * (iCommand.wButtonCmd + 6), this.menuY + this.menuH - hBut / 2 - 5, null, iCommand.caption);
			bool flag = GameCanvas.isTouchNoOrPC() && i == 0;
			if (flag)
			{
				iCommand.isSelect = true;
			}
		}
	}

	// Token: 0x06000930 RID: 2352 RVA: 0x000BF4C4 File Offset: 0x000BD6C4
	public void setPos()
	{
		switch (this.pos)
		{
		case 0:
		{
			this.menuX = 2;
			this.menuY = MotherCanvas.h - GameCanvas.hCommand - this.menuH - 2;
			bool isTouch = GameCanvas.isTouch;
			if (isTouch)
			{
				this.menuY += GameCanvas.hCommand;
			}
			break;
		}
		case 1:
		{
			this.menuX = MotherCanvas.w - this.wUni - 2;
			this.menuY = MotherCanvas.h - GameCanvas.hCommand - this.menuH - 2;
			bool isTouch2 = GameCanvas.isTouch;
			if (isTouch2)
			{
				this.menuY += GameCanvas.hCommand;
			}
			break;
		}
		case 2:
		case 4:
			this.menuX = MotherCanvas.hw - this.wUni / 2;
			this.menuY = MotherCanvas.h / 2 - this.menuH / 2 - 2 + this.menuW / 2 + 6 - GameCanvas.hCommand / 2;
			break;
		case 3:
			this.menuX = 2;
			this.menuY = 2;
			break;
		}
	}

	// Token: 0x06000931 RID: 2353 RVA: 0x000BF5DC File Offset: 0x000BD7DC
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
		{
			iCommand iCommand = (iCommand)this.menuItems.elementAt(this.menuSelectedItem);
			bool flag = !iCommand.isDonotCloseMenu;
			if (flag)
			{
				this.isShowMenu = false;
			}
			this.perform(iCommand);
			break;
		}
		case 1:
			this.doCloseMenu();
			break;
		case 2:
			GlobalService.gI().Dynamic_Menu((short)this.IdNpc, (sbyte)this.IdMenu, (sbyte)this.menuSelectedItem);
			this.isShowMenu = false;
			GameCanvas.isPointerSelect = false;
			break;
		case 3:
			GlobalService.gI().Dynamic_Menu((short)this.IdNpc, (sbyte)this.IdMenu, (sbyte)subIndex);
			this.isShowMenu = false;
			GameCanvas.isPointerSelect = false;
			break;
		}
		base.commandPointer(index, subIndex);
	}

	// Token: 0x06000932 RID: 2354 RVA: 0x000BF6AC File Offset: 0x000BD8AC
	public virtual void updateMenuKey()
	{
		bool flag = !Menu.isPaint || !this.isShowMenu;
		if (!flag)
		{
			bool flag2 = this.timeShowSelect > 0;
			if (flag2)
			{
				this.timeShowSelect -= 1;
			}
			bool flag3 = false;
			bool flag4 = Menu.isNPCMenu == 1;
			if (flag4)
			{
				int num = this.menuSelectedItem;
				bool flag5 = GameCanvas.keyMove(0) || GameCanvas.keyMove(1);
				if (flag5)
				{
					this.menuSelectedItem--;
					GameCanvas.ClearkeyMove(0);
					GameCanvas.ClearkeyMove(1);
				}
				else
				{
					bool flag6 = GameCanvas.keyMove(2) || GameCanvas.keyMove(3);
					if (flag6)
					{
						this.menuSelectedItem++;
						GameCanvas.ClearkeyMove(2);
						GameCanvas.ClearkeyMove(3);
					}
				}
				this.menuSelectedItem = AvMain.resetSelect(this.menuSelectedItem, this.menuItems.size() - 1, false);
				bool flag7 = num != this.menuSelectedItem && GameCanvas.isTouchNoOrPC();
				if (flag7)
				{
					for (int i = 0; i < this.menuItems.size(); i++)
					{
						iCommand iCommand = (iCommand)this.menuItems.elementAt(i);
						bool flag8 = i == this.menuSelectedItem;
						if (flag8)
						{
							iCommand.isSelect = true;
						}
						else
						{
							iCommand.isSelect = false;
						}
					}
				}
				bool flag9 = GameCanvas.keyMyHold[5];
				if (flag9)
				{
					GameCanvas.clearKeyHold(5);
					bool flag10 = this.menuSelectedItem < this.menuItems.size() && this.menuSelectedItem >= 0;
					if (flag10)
					{
						((iCommand)this.menuItems.elementAt(this.menuSelectedItem)).perform();
					}
				}
			}
			else
			{
				bool flag11 = Menu.isNPCMenu == 0;
				if (flag11)
				{
					bool flag12 = this.pos == -1;
					if (flag12)
					{
						bool flag13 = GameCanvas.keyMove(0);
						if (flag13)
						{
							flag3 = true;
							this.menuSelectedItem--;
							bool flag14 = this.menuSelectedItem < 0;
							if (flag14)
							{
								this.menuSelectedItem = this.menuItems.size() - 1;
							}
							GameCanvas.ClearkeyMove(0);
						}
						else
						{
							bool flag15 = GameCanvas.keyMove(2);
							if (flag15)
							{
								flag3 = true;
								this.menuSelectedItem++;
								bool flag16 = this.menuSelectedItem > this.menuItems.size() - 1;
								if (flag16)
								{
									this.menuSelectedItem = 0;
								}
								GameCanvas.ClearkeyMove(2);
							}
						}
					}
					else
					{
						bool flag17 = GameCanvas.keyMove(1);
						if (flag17)
						{
							flag3 = true;
							this.menuSelectedItem--;
							bool flag18 = this.menuSelectedItem < 0;
							if (flag18)
							{
								this.menuSelectedItem = this.menuItems.size() - 1;
							}
							GameCanvas.ClearkeyMove(1);
						}
						else
						{
							bool flag19 = GameCanvas.keyMove(3);
							if (flag19)
							{
								flag3 = true;
								this.menuSelectedItem++;
								bool flag20 = this.menuSelectedItem > this.menuItems.size() - 1;
								if (flag20)
								{
									this.menuSelectedItem = 0;
								}
								GameCanvas.ClearkeyMove(3);
							}
						}
					}
				}
			}
			bool flag21 = flag3;
			if (flag21)
			{
				bool flag22 = this.pos == -1;
				if (flag22)
				{
					this.cmtoX = this.menuSelectedItem * this.menuW + this.menuW - MotherCanvas.w / 2;
				}
				else
				{
					this.cmtoX = (this.menuSelectedItem + 1) * this.menuW - this.menuH / 2;
				}
				bool flag23 = this.cmtoX > this.cmxLim;
				if (flag23)
				{
					this.cmtoX = this.cmxLim;
				}
				bool flag24 = this.cmtoX < 0;
				if (flag24)
				{
					this.cmtoX = 0;
				}
				bool flag25 = this.menuSelectedItem == this.menuItems.size() - 1 || this.menuSelectedItem == 0;
				if (flag25)
				{
					this.cmx = this.cmtoX;
				}
			}
			bool flag26 = Menu.isNPCMenu == 0;
			if (flag26)
			{
				bool flag27 = this.pos == -1;
				if (flag27)
				{
					this.updatePos_LEFT_RIGHT();
				}
				else
				{
					this.update_Pos_UP_DOWN();
				}
				bool flag28 = GameCanvas.isPointerSelect && GameCanvas.menuCur == this && !GameCanvas.isPoint(this.menuX - 5, this.menuTemY - 5 - this.hPlus, this.wUni + 10, this.menuH + 10 + this.hPlus);
				if (flag28)
				{
					this.doCloseMenu();
				}
			}
			else
			{
				bool flag29 = Menu.isNPCMenu == 2;
				if (flag29)
				{
					this.updatePos_LEFT_RIGHT();
					bool flag30 = GameCanvas.isPointerSelect && !GameCanvas.isPoint(this.menuX - 5, this.menuY - 5, this.wUni + 10, this.menuH + 10);
					if (flag30)
					{
						this.timeShow = -1;
					}
				}
			}
			base.updatekey();
			this.updatekeyPC();
		}
	}

	// Token: 0x06000933 RID: 2355 RVA: 0x000BFB90 File Offset: 0x000BDD90
	public void updatePos_LEFT_RIGHT()
	{
		bool isPointerDown = GameCanvas.isPointerDown;
		if (isPointerDown)
		{
			bool flag = !this.pointerIsDowning && GameCanvas.isPointer(this.menuX, this.menuY, this.wUni, this.menuH);
			if (flag)
			{
				for (int i = 0; i < this.pointerDownLastX.Length; i++)
				{
					this.pointerDownLastX[0] = GameCanvas.px;
				}
				this.pointerDownFirstX = GameCanvas.px;
				this.pointerIsDowning = true;
				this.isDownWhenRunning = (this.cmRun != 0);
				this.cmRun = 0;
			}
			else
			{
				bool flag2 = this.pointerIsDowning;
				if (flag2)
				{
					this.pointerDownTime++;
					bool flag3 = this.pointerDownTime > 5 && this.pointerDownFirstX == GameCanvas.px && !this.isDownWhenRunning;
					if (flag3)
					{
						this.pointerDownFirstX = -1000;
						this.menuSelectedItem = (this.cmtoX + GameCanvas.px - this.menuX) / this.menuW;
					}
					int num = GameCanvas.px - this.pointerDownLastX[0];
					bool flag4 = num != 0 && this.menuSelectedItem != -1;
					if (flag4)
					{
						this.menuSelectedItem = -1;
					}
					for (int j = this.pointerDownLastX.Length - 1; j > 0; j--)
					{
						this.pointerDownLastX[j] = this.pointerDownLastX[j - 1];
					}
					this.pointerDownLastX[0] = GameCanvas.px;
					this.cmtoX -= num;
					bool flag5 = this.cmtoX < 0;
					if (flag5)
					{
						this.cmtoX = 0;
					}
					bool flag6 = this.cmtoX > this.cmxLim;
					if (flag6)
					{
						this.cmtoX = this.cmxLim;
					}
					bool flag7 = this.cmx < 0 || this.cmx > this.cmxLim;
					if (flag7)
					{
						num /= 2;
					}
					this.cmx -= num;
				}
			}
		}
		bool flag8 = GameCanvas.isPointerClick && this.pointerIsDowning;
		if (flag8)
		{
			int a = GameCanvas.px - this.pointerDownLastX[0];
			GameCanvas.isPointerClick = false;
			bool flag9 = CRes.abs(a) < 20 && CRes.abs(GameCanvas.px - this.pointerDownFirstX) < 20 && !this.isDownWhenRunning;
			if (flag9)
			{
				this.cmRun = 0;
				this.cmtoX = this.cmx;
				this.pointerDownFirstX = -1000;
				this.menuSelectedItem = (this.cmtoX + GameCanvas.px - this.menuX) / this.menuW;
				this.pointerDownTime = 0;
				this.waitToPerform = 1;
			}
			else
			{
				bool flag10 = this.menuSelectedItem != -1 && this.pointerDownTime > 5;
				if (flag10)
				{
					this.pointerDownTime = 0;
					this.waitToPerform = 1;
				}
				else
				{
					bool flag11 = this.menuSelectedItem == -1 && !this.isDownWhenRunning;
					if (flag11)
					{
						bool flag12 = this.cmx < 0;
						if (flag12)
						{
							this.cmtoX = 0;
						}
						else
						{
							bool flag13 = this.cmx > this.cmxLim;
							if (flag13)
							{
								this.cmtoX = this.cmxLim;
							}
							else
							{
								int num2 = GameCanvas.px - this.pointerDownLastX[0] + (this.pointerDownLastX[0] - this.pointerDownLastX[1]) + (this.pointerDownLastX[1] - this.pointerDownLastX[2]);
								num2 = ((num2 > 10) ? 10 : ((num2 < -10) ? -10 : 0));
								this.cmRun = -num2 * 100;
							}
						}
					}
				}
			}
			this.pointerIsDowning = false;
			this.pointerDownTime = 0;
			GameCanvas.isPointerClick = false;
		}
		bool flag14 = GameCanvas.isPointerRelease && this.pointerIsDowning;
		if (flag14)
		{
			this.pointerIsDowning = false;
		}
	}

	// Token: 0x06000934 RID: 2356 RVA: 0x000BFF68 File Offset: 0x000BE168
	public void update_Pos_UP_DOWN()
	{
		bool flag = GameCanvas.keyMyPressed[5];
		if (flag)
		{
			GameCanvas.clearKeyHold();
			GameCanvas.clearKeyPressed();
			iCommand iCommand = (iCommand)this.menuItems.elementAt(this.menuSelectedItem);
			bool flag2 = !iCommand.isDonotCloseMenu;
			if (flag2)
			{
				this.doCloseMenu();
			}
			this.perform(iCommand);
		}
		else
		{
			bool flag3 = GameCanvas.keyMyPressed[12];
			if (flag3)
			{
				GameCanvas.clearKeyHold();
				GameCanvas.clearKeyPressed();
				iCommand iCommand2 = (iCommand)this.menuItems.elementAt(this.menuSelectedItem);
				bool flag4 = !iCommand2.isDonotCloseMenu;
				if (flag4)
				{
					this.doCloseMenu();
				}
				this.perform(iCommand2);
			}
		}
		bool isPointerDown = GameCanvas.isPointerDown;
		if (isPointerDown)
		{
			bool flag5 = !this.pointerIsDowning && GameCanvas.isPointer(this.menuX, this.menuY, this.wUni, this.menuH);
			if (flag5)
			{
				for (int i = 0; i < this.pointerDownLastX.Length; i++)
				{
					this.pointerDownLastX[0] = GameCanvas.py;
				}
				this.pointerDownFirstX = GameCanvas.py;
				this.pointerIsDowning = true;
				this.isDownWhenRunning = (this.cmRun != 0);
				this.cmRun = 0;
			}
			else
			{
				bool flag6 = this.pointerIsDowning;
				if (flag6)
				{
					this.pointerDownTime++;
					bool flag7 = this.pointerDownTime > this.valueTime && this.pointerDownFirstX == GameCanvas.py && !this.isDownWhenRunning;
					if (flag7)
					{
						this.pointerDownFirstX = -1000;
						this.menuSelectedItem = (this.cmtoX + GameCanvas.py - this.menuY) / this.menuW;
					}
					int num = GameCanvas.py - this.pointerDownLastX[0];
					bool flag8 = num != 0 && this.menuSelectedItem != -1;
					if (flag8)
					{
						this.menuSelectedItem = -1;
					}
					for (int j = this.pointerDownLastX.Length - 1; j > 0; j--)
					{
						this.pointerDownLastX[j] = this.pointerDownLastX[j - 1];
					}
					this.pointerDownLastX[0] = GameCanvas.py;
					this.cmtoX -= num;
					bool flag9 = this.cmtoX < 0;
					if (flag9)
					{
						this.cmtoX = 0;
					}
					bool flag10 = this.cmtoX > this.cmxLim;
					if (flag10)
					{
						this.cmtoX = this.cmxLim;
					}
					bool flag11 = this.cmx < 0 || this.cmx > this.cmxLim;
					if (flag11)
					{
						num /= 2;
					}
					this.cmx -= num;
				}
			}
		}
		bool flag12 = GameCanvas.isPointerClick && this.pointerIsDowning;
		if (flag12)
		{
			int a = GameCanvas.py - this.pointerDownLastX[0];
			GameCanvas.isPointerClick = false;
			bool flag13 = CRes.abs(a) < 20 && CRes.abs(GameCanvas.py - this.pointerDownFirstX) < 20 && !this.isDownWhenRunning && GameCanvas.isPointerSelect;
			if (flag13)
			{
				this.cmRun = 0;
				this.cmtoX = this.cmx;
				this.pointerDownFirstX = -1000;
				this.menuSelectedItem = (this.cmtoX + GameCanvas.py - this.menuY) / this.menuW;
				this.pointerDownTime = 0;
				this.waitToPerform = 1;
			}
			else
			{
				bool flag14 = this.menuSelectedItem != -1 && this.pointerDownTime > this.valueTime;
				if (flag14)
				{
					this.pointerDownTime = 0;
					this.waitToPerform = 1;
				}
				else
				{
					bool flag15 = this.menuSelectedItem == -1 && !this.isDownWhenRunning;
					if (flag15)
					{
						this.timeShowSelect = 0;
						bool flag16 = this.cmx < 0;
						if (flag16)
						{
							this.cmtoX = 0;
						}
						else
						{
							bool flag17 = this.cmx > this.cmxLim;
							if (flag17)
							{
								this.cmtoX = this.cmxLim;
							}
							else
							{
								int num2 = GameCanvas.py - this.pointerDownLastX[0] + (this.pointerDownLastX[0] - this.pointerDownLastX[1]) + (this.pointerDownLastX[1] - this.pointerDownLastX[2]);
								num2 = ((num2 > 10) ? 10 : ((num2 < -10) ? -10 : 0));
								this.cmRun = -num2 * 100;
							}
						}
					}
				}
			}
			this.pointerIsDowning = false;
			this.pointerDownTime = 0;
		}
		bool flag18 = this.menuSelectedItem != -1 && GameCanvas.isPointerDown && !GameCanvas.isPointerMove;
		if (flag18)
		{
			this.timeShowSelect = 5;
		}
		bool flag19 = GameCanvas.isPointerRelease && this.pointerIsDowning;
		if (flag19)
		{
			this.pointerIsDowning = false;
		}
	}

	// Token: 0x06000935 RID: 2357 RVA: 0x000C0424 File Offset: 0x000BE624
	public void moveCamera()
	{
		bool flag = this.cmRun != 0 && !this.pointerIsDowning;
		if (flag)
		{
			this.cmtoX += this.cmRun / 100;
			bool flag2 = this.cmtoX < 0;
			if (flag2)
			{
				this.cmtoX = 0;
			}
			else
			{
				bool flag3 = this.cmtoX > this.cmxLim;
				if (flag3)
				{
					this.cmtoX = this.cmxLim;
				}
				else
				{
					this.cmx = this.cmtoX;
				}
			}
			this.cmRun = this.cmRun * 9 / 10;
			bool flag4 = this.cmRun < 100 && this.cmRun > -100;
			if (flag4)
			{
				this.cmRun = 0;
			}
		}
		bool flag5 = this.cmx != this.cmtoX && !this.pointerIsDowning;
		if (flag5)
		{
			this.cmvx = this.cmtoX - this.cmx << 2;
			this.cmdx += this.cmvx;
			this.cmx += this.cmdx >> 4;
			this.cmdx &= 15;
		}
	}

	// Token: 0x06000936 RID: 2358 RVA: 0x000C0554 File Offset: 0x000BE754
	public virtual void paintMenu(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		bool flag = !Menu.isLoadData;
		if (!flag)
		{
			bool flag2 = Menu.isNPCMenu == 1;
			if (flag2)
			{
				this.paint_NPC_MENU(g);
			}
			else
			{
				bool flag3 = Menu.isNPCMenu != 0;
				if (!flag3)
				{
					base.paintPaper_UpDown(g, this.menuX - this.miniItem, this.menuTemY - GameCanvas.hCommand, this.wUni + this.miniItem * 2, this.menuH + GameCanvas.hCommand + this.miniItem, this.menuH + GameCanvas.hCommand + this.miniItem);
					g.setColor(15972174);
					g.fillRoundRect(this.menuX + this.miniItem, this.menuTemY - GameCanvas.hCommand + this.miniItem / 2 + 3, this.wUni - this.miniItem * 2, 16, 4, 4);
					AvMain.FontBorderColor(g, this.nameMenu, this.menuX + this.wUni / 2, this.menuTemY - this.hPlus + GameCanvas.hCommand / 4 + 1 + 3, 2, 6, 5);
					bool flag4 = !Menu.isPaint || this.pos == -1;
					if (!flag4)
					{
						g.setClip(this.menuX + 3, this.menuY + 3, this.wUni - 6, this.menuH - 6);
						g.saveCanvas();
						g.ClipRec(this.menuX + 3, this.menuY + 3, this.wUni - 6, this.menuH - 6);
						g.translate(0, -this.cmx);
						g.setColor(AvMain.colorMenu[4]);
						bool flag5 = this.pos == 2 || this.pos == 4 || this.pos == 0;
						if (flag5)
						{
							for (int i = 0; i < this.menuItems.size() - 1; i++)
							{
								this.paintLine(g, i);
							}
						}
						int num = this.cmx / this.menuW - 1;
						bool flag6 = num < 0;
						if (flag6)
						{
							num = 0;
						}
						int num2 = num + this.sizeMenu + 2;
						bool flag7 = num2 > this.menuItems.size();
						if (flag7)
						{
							num2 = this.menuItems.size();
							num = num2 - this.sizeMenu - 2;
							bool flag8 = num < 0;
							if (flag8)
							{
								num = 0;
							}
						}
						bool flag9 = this.menuSelectedItem > -1;
						if (flag9)
						{
							this.paintSelect(g, this.menuX + 10, this.menuY + 7 + this.menuSelectedItem * this.menuW, this.wUni - 20, this.menuW - 8);
						}
						for (int j = num; j < num2; j++)
						{
							iCommand iCommand = (iCommand)this.menuItems.elementAt(j);
							bool is3D = false;
							bool flag10 = this.menuSelectedItem == j;
							if (flag10)
							{
								is3D = true;
							}
							bool flag11 = this.pos == 2;
							if (flag11)
							{
								iCommand.paintCaptionImageMenu(g, this.menuX + this.wUni / 2, this.menuY + 6 + this.menuW / 4 + j * this.menuW, 2, is3D);
							}
							else
							{
								bool flag12 = this.pos == 0 || this.pos == 3;
								if (flag12)
								{
									iCommand.paintCaptionImageMenu(g, this.menuX + 12, this.menuY + 6 + this.menuW / 4 + j * this.menuW, 0, is3D);
								}
								else
								{
									bool flag13 = this.pos == 1;
									if (flag13)
									{
										iCommand.paintCaptionImageMenu(g, this.menuX + this.wUni - 6, this.menuY + 6 + this.menuW / 4 + j * this.menuW, 1, is3D);
									}
									else
									{
										bool flag14 = this.pos == 4;
										if (flag14)
										{
											iCommand.paintCaptionImageMenu(g, this.menuX + 12, this.menuY + 6 + this.menuW / 4 + j * this.menuW, 0, is3D);
										}
									}
								}
							}
						}
						mGraphics.resetTransAndroid(g);
						g.restoreCanvas();
						GameCanvas.resetTrans(g);
						base.paintCmd(g);
					}
				}
			}
		}
	}

	// Token: 0x06000937 RID: 2359 RVA: 0x000C09A4 File Offset: 0x000BEBA4
	public void paintLine(mGraphics g, int i)
	{
		g.setColor(AvMain.colorMenu[4]);
		g.fillRect(this.menuX + 8, this.menuY + 3 + this.menuW + i * this.menuW - 1, this.wUni - 16, 2);
		g.fillRect(this.menuX + 8 + 1, this.menuY + 3 + this.menuW + i * this.menuW - 2, this.wUni - 16 - 2, 4);
	}

	// Token: 0x06000938 RID: 2360 RVA: 0x000C0A2C File Offset: 0x000BEC2C
	private void paint_NPC_MENU(mGraphics g)
	{
		int num = this.menuX + 6;
		int y = this.menuY + 8;
		AvMain.paintRect(g, this.menuX, this.menuTemY, this.wUni, this.menuH, 2, 4);
		MainObject mainObject = MainObject.get_Object(this.IdNpc, this.typeO);
		bool flag = mainObject != null;
		if (flag)
		{
			AvMain.Font3dWhite(g, mainObject.name, num + 10, y, 0);
			bool flag2 = this.runText != null;
			if (flag2)
			{
				this.runText.paintText(g, this.archorRunText);
			}
			GameCanvas.resetTrans(g);
			for (int i = 0; i < this.menuItems.size(); i++)
			{
				iCommand iCommand = (iCommand)this.menuItems.elementAt(i);
				iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
			}
		}
	}

	// Token: 0x06000939 RID: 2361 RVA: 0x000C0B18 File Offset: 0x000BED18
	public void doCloseMenu()
	{
		bool flag = this == GameCanvas.menuCur;
		if (flag)
		{
			this.isShowMenu = false;
		}
		GameCanvas.isPointerSelect = false;
		GameCanvas.isPointerClick = false;
		GameCanvas.isPointerEnd = true;
	}

	// Token: 0x0600093A RID: 2362 RVA: 0x000C0B50 File Offset: 0x000BED50
	public virtual void updateMenu()
	{
		bool flag = this.timeShow > 0;
		if (flag)
		{
			this.timeShow += 1;
			bool flag2 = this.hShow < this.wUni;
			if (flag2)
			{
				this.hShow += this.menuH;
				bool flag3 = this.hShow >= this.wUni;
				if (flag3)
				{
					this.hShow = this.wUni;
					this.timeShow = 0;
				}
			}
		}
		else
		{
			bool flag4 = this.timeShow < 0;
			if (flag4)
			{
				this.timeShow -= 1;
				bool flag5 = this.hShow > 0;
				if (flag5)
				{
					this.hShow -= this.menuH;
					bool flag6 = this.hShow <= 0;
					if (flag6)
					{
						this.hShow = 0;
						this.timeShow = 0;
						this.doCloseMenu();
					}
				}
			}
		}
		bool flag7 = !Menu.isLoadData;
		if (!flag7)
		{
			this.moveCamera();
			bool flag8 = Menu.isNPCMenu == 1;
			if (flag8)
			{
				bool flag9 = this.runText != null;
				if (flag9)
				{
					this.runText.updateDlg();
				}
				for (int i = 0; i < this.menuItems.size(); i++)
				{
					iCommand iCommand = (iCommand)this.menuItems.elementAt(i);
					iCommand.updatePointer();
				}
			}
			else
			{
				bool flag10 = Menu.isNPCMenu == 2 && !GameCanvas.isPointerMove && this.timeShow == 0;
				if (flag10)
				{
					for (int j = 0; j < this.menuItems.size(); j++)
					{
						iCommand iCommand2 = (iCommand)this.menuItems.elementAt(j);
						iCommand2.updatePointerShow(this.cmx, 0);
					}
				}
			}
			bool flag11 = this.menuTemY > this.menuY;
			if (flag11)
			{
				int num = this.menuTemY - this.menuY >> 1;
				bool flag12 = num < 1;
				if (flag12)
				{
					num = 1;
				}
				this.menuTemY -= num;
			}
			bool flag13 = this.xc != 0;
			if (flag13)
			{
				this.xc >>= 1;
				bool flag14 = this.xc < 0;
				if (flag14)
				{
					this.xc = 0;
				}
			}
			bool flag15 = this.waitToPerform > 0;
			if (flag15)
			{
				this.waitToPerform--;
				bool flag16 = this.waitToPerform == 0;
				if (flag16)
				{
					bool flag17 = this.menuSelectedItem >= 0 && this.menuSelectedItem < this.menuItems.size();
					if (flag17)
					{
						iCommand iCommand3 = (iCommand)this.menuItems.elementAt(this.menuSelectedItem);
						bool flag18 = !iCommand3.isDonotCloseMenu;
						if (flag18)
						{
							bool flag19 = this == GameCanvas.menuCur;
							if (flag19)
							{
								this.isShowMenu = false;
							}
							else
							{
								this.doCloseMenu();
							}
						}
						this.perform(iCommand3);
						this.timeShowSelect = 5;
						GameCanvas.clearKeyHold();
						GameCanvas.clearKeyPressed();
						GameCanvas.isPointerEnd = true;
						GameCanvas.isPointerSelect = false;
					}
					else
					{
						bool flag20 = this == GameCanvas.menuCur;
						if (flag20)
						{
							this.isShowMenu = false;
						}
						else
						{
							this.doCloseMenu();
						}
					}
				}
			}
			base.updatePointer();
		}
	}

	// Token: 0x0600093B RID: 2363 RVA: 0x000C0EA4 File Offset: 0x000BF0A4
	public void perform(iCommand cmd)
	{
		bool flag = cmd != null;
		if (flag)
		{
			bool flag2 = cmd.action != null;
			if (flag2)
			{
				cmd.action.perform();
			}
			else
			{
				bool flag3 = cmd.Pointer != null;
				if (flag3)
				{
					cmd.Pointer.commandPointer(cmd.indexMenu, cmd.subIndex);
				}
				else
				{
					GameCanvas.currentScreen.commandMenu(cmd.indexMenu, cmd.subIndex);
				}
			}
			GameCanvas.isPointerSelect = false;
			mSound.playSound(0, mSound.volumeSound);
		}
	}

	// Token: 0x04000EAD RID: 3757
	public const sbyte NORMAL = 0;

	// Token: 0x04000EAE RID: 3758
	public const sbyte NPC_MENU = 1;

	// Token: 0x04000EAF RID: 3759
	public const sbyte QUICK_MENU = 2;

	// Token: 0x04000EB0 RID: 3760
	public bool isShowMenu;

	// Token: 0x04000EB1 RID: 3761
	public mVector menuItems = new mVector("Menu.menuItems");

	// Token: 0x04000EB2 RID: 3762
	public int menuSelectedItem;

	// Token: 0x04000EB3 RID: 3763
	public int SelectFocus;

	// Token: 0x04000EB4 RID: 3764
	public int menuX;

	// Token: 0x04000EB5 RID: 3765
	public int menuY;

	// Token: 0x04000EB6 RID: 3766
	public int menuW;

	// Token: 0x04000EB7 RID: 3767
	public int menuH;

	// Token: 0x04000EB8 RID: 3768
	public int menuTemY;

	// Token: 0x04000EB9 RID: 3769
	public int hPlus;

	// Token: 0x04000EBA RID: 3770
	public int cmtoX;

	// Token: 0x04000EBB RID: 3771
	public int cmx;

	// Token: 0x04000EBC RID: 3772
	public int cmdy;

	// Token: 0x04000EBD RID: 3773
	public int cmvy;

	// Token: 0x04000EBE RID: 3774
	public int cmxLim;

	// Token: 0x04000EBF RID: 3775
	public int xc;

	// Token: 0x04000EC0 RID: 3776
	public int pos;

	// Token: 0x04000EC1 RID: 3777
	public int sizeMenu;

	// Token: 0x04000EC2 RID: 3778
	private string nameMenu = string.Empty;

	// Token: 0x04000EC3 RID: 3779
	private string[] mStrTalk;

	// Token: 0x04000EC4 RID: 3780
	public RunWord runText;

	// Token: 0x04000EC5 RID: 3781
	public static bool isPaint = true;

	// Token: 0x04000EC6 RID: 3782
	public static bool isLoadData = true;

	// Token: 0x04000EC7 RID: 3783
	public static sbyte isNPCMenu;

	// Token: 0x04000EC8 RID: 3784
	public sbyte timeShowSelect;

	// Token: 0x04000EC9 RID: 3785
	public iCommand cmdClose;

	// Token: 0x04000ECA RID: 3786
	public static MainObject objSelect;

	// Token: 0x04000ECB RID: 3787
	public int IdMenu;

	// Token: 0x04000ECC RID: 3788
	public int IdNpc;

	// Token: 0x04000ECD RID: 3789
	public static int IdNPCLast;

	// Token: 0x04000ECE RID: 3790
	private sbyte typeO;

	// Token: 0x04000ECF RID: 3791
	private sbyte timeShow;

	// Token: 0x04000ED0 RID: 3792
	private int hShow;

	// Token: 0x04000ED1 RID: 3793
	private int maxShow;

	// Token: 0x04000ED2 RID: 3794
	private int archorRunText;

	// Token: 0x04000ED3 RID: 3795
	private int xBegin;

	// Token: 0x04000ED4 RID: 3796
	private int w2cmd;

	// Token: 0x04000ED5 RID: 3797
	public int wUni;

	// Token: 0x04000ED6 RID: 3798
	private int pointerDownTime;

	// Token: 0x04000ED7 RID: 3799
	private int pointerDownFirstX;

	// Token: 0x04000ED8 RID: 3800
	private int[] pointerDownLastX = new int[3];

	// Token: 0x04000ED9 RID: 3801
	private bool pointerIsDowning;

	// Token: 0x04000EDA RID: 3802
	private bool isDownWhenRunning;

	// Token: 0x04000EDB RID: 3803
	private int waitToPerform;

	// Token: 0x04000EDC RID: 3804
	private int cmRun;

	// Token: 0x04000EDD RID: 3805
	private int valueTime = 2;

	// Token: 0x04000EDE RID: 3806
	private int cmvx;

	// Token: 0x04000EDF RID: 3807
	private int cmdx;

	// Token: 0x04000EE0 RID: 3808
	private int miniItem = 10;
}
