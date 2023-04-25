using System;

// Token: 0x0200007A RID: 122
public class MainHelp : AvMain
{
	// Token: 0x06000730 RID: 1840 RVA: 0x0009A9A0 File Offset: 0x00098BA0
	public MainHelp(int type, int typeSub)
	{
		this.runText = new RunWord();
		this.type = type;
		this.typeSub = typeSub;
		this.isBreak = true;
		this.w = 100;
		this.fontPaint = mFont.tahoma_7_white;
		switch (type)
		{
		case 0:
			this.cmd = new iCommand(T.close, 2, this);
			GameCanvas.Start_Normal_DiaLog(T.mHelp[0], this.cmd, false);
			this.isRemove = true;
			break;
		case 1:
			this.str = T.mHelp[2];
			this.x = 100;
			this.y = 5;
			this.archor = 0;
			this.createPoint(this.x, this.y + 20, 0);
			GameScreen.indexHelp = type;
			GameCanvas.saveRms.SaveIndexHelp();
			break;
		case 2:
			this.setHotKey();
			break;
		case 3:
			this.setMove();
			break;
		case 4:
		{
			bool isTouch = GameCanvas.isTouch;
			if (isTouch)
			{
				bool flag = Interface_Game.typeTouch == 1;
				if (flag)
				{
					this.str = T.mHelp[8];
					this.x = MotherCanvas.hw;
					this.y = MotherCanvas.h - GameCanvas.hCommand * 2;
					this.archor = 33;
				}
				else
				{
					this.str = T.mHelp[10];
					this.x = Interface_Game.mPosOther[3][0] - 15;
					this.y = Interface_Game.mPosOther[3][1];
					this.archor = 1;
					this.createPoint(this.x, this.y + 20, 1);
				}
			}
			else
			{
				this.str = T.mHelp[9];
				this.x = MotherCanvas.hw;
				this.y = MotherCanvas.h - GameCanvas.hCommand * 2;
				this.archor = 33;
			}
			GameScreen.indexHelp = type;
			GameCanvas.saveRms.SaveIndexHelp();
			break;
		}
		case 5:
		{
			bool isTouch2 = GameCanvas.isTouch;
			if (isTouch2)
			{
				this.str = T.mHelp[18];
				this.x = Interface_Game.mPosOther[2][0] - 15;
				this.y = Interface_Game.mPosOther[2][1] + 20;
				this.archor = -1;
				this.createPoint(this.x, this.y - 5, 1);
			}
			else
			{
				this.str = T.mHelp[17];
				this.x = MotherCanvas.hw;
				this.y = MotherCanvas.h - GameCanvas.hCommand * 2;
				this.archor = 33;
			}
			GameScreen.indexHelp = type;
			GameCanvas.saveRms.SaveIndexHelp();
			break;
		}
		case 6:
		{
			bool isTouch3 = GameCanvas.isTouch;
			if (isTouch3)
			{
				this.str = T.mHelp[13];
				this.x = Interface_Game.mPosOther[1][0] + 35;
				this.y = Interface_Game.mPosOther[1][1];
				this.archor = 0;
				this.createPoint(this.x, this.y + 15, 0);
			}
			else
			{
				this.str = T.mHelp[12];
				this.x = MotherCanvas.hw;
				this.y = MotherCanvas.h - GameCanvas.hCommand * 2;
				this.archor = 33;
			}
			GameScreen.indexHelp = type;
			GameCanvas.saveRms.SaveIndexHelp();
			break;
		}
		case 7:
		{
			bool isTouch4 = GameCanvas.isTouch;
			if (isTouch4)
			{
				this.str = T.mHelp[15];
				this.x = Interface_Game.xNumMess + 35;
				this.y = Interface_Game.yNumMess;
				this.archor = 0;
				this.createPoint(this.x, this.y + 15, 0);
			}
			else
			{
				this.str = T.mHelp[14];
				this.x = Interface_Game.xNumMess + 35;
				this.y = Interface_Game.yNumMess;
				this.archor = 0;
				this.createPoint(this.x, this.y + 15, 0);
			}
			GameScreen.indexHelp = type;
			GameCanvas.saveRms.SaveIndexHelp();
			break;
		}
		case 8:
		{
			bool isTouch5 = GameCanvas.isTouch;
			if (isTouch5)
			{
				this.str = T.mHelp[20];
			}
			else
			{
				this.str = T.mHelp[19];
			}
			for (int i = 0; i < GameScreen.vecPlayers.size(); i++)
			{
				MainObject mainObject = (MainObject)GameScreen.vecPlayers.elementAt(i);
				bool flag2 = mainObject.typeObject == 3 || mainObject.typeObject == 4 || mainObject.typeObject == 7;
				if (flag2)
				{
					this.x = mainObject.x;
					this.y = mainObject.y - 40;
					this.archor = 33;
					this.createPoint(this.x, this.y, 3);
					this.isInMap = true;
					break;
				}
			}
			GameScreen.indexHelp = 9;
			GameCanvas.saveRms.SaveIndexHelp();
			break;
		}
		case 9:
		{
			bool isTouch6 = GameCanvas.isTouch;
			if (isTouch6)
			{
				this.str = T.mHelp[22];
				this.x = 100;
				this.y = 5;
				this.archor = 0;
				this.createPoint(this.x, this.y + 20, 0);
			}
			else
			{
				this.str = T.mHelp[21];
				this.x = 20;
				this.y = MotherCanvas.h - 30;
				this.archor = 2;
				this.createPoint(this.x, this.y, 3);
			}
			GameScreen.indexHelp = 10;
			GameCanvas.saveRms.SaveIndexHelp();
			break;
		}
		case 10:
			this.x = MotherCanvas.hw;
			this.y = MotherCanvas.h - GameCanvas.hCommand * 2;
			this.archor = 33;
			if (typeSub != 0)
			{
				if (typeSub == 1)
				{
					this.str = T.mHelp[24];
					int num = MainTab.xTab + MainTab.wTab / 2 - MainTab.wItem * MainTabShop.maxNumItemW / 2 + 10;
					int num2 = MainTab.yTab + 32;
					for (int j = 0; j < Player.vecInventory.size(); j++)
					{
						MainItem mainItem = (MainItem)Player.vecInventory.elementAt(j);
						bool flag3 = mainItem.typeObject == 4;
						if (flag3)
						{
							this.createPoint(num + j % MainTabShop.maxNumItemW * MainTab.wItem + MainTab.wItem / 2 + 14, num2 + j / MainTabShop.maxNumItemW * MainTab.wItem + MainTab.wItem / 2, 10);
							break;
						}
					}
				}
			}
			else
			{
				this.w = 140;
				this.str = T.mHelp[23];
				GameScreen.indexHelp = 10;
				GameCanvas.saveRms.SaveIndexHelp();
				this.createPoint(MainTab.xTab + 22 + 20, MainTab.yTab + 36, 0);
			}
			break;
		case 11:
			this.x = MotherCanvas.hw;
			this.y = MotherCanvas.h - GameCanvas.hCommand * 2;
			this.archor = 33;
			this.w = 140;
			switch (typeSub)
			{
			case 0:
			{
				bool flag4 = GameCanvas.currentScreen == GameCanvas.tabAllScr;
				if (flag4)
				{
					GameCanvas.tabAllScr.idSelect = 1;
					GameCanvas.tabAllScr.setTabSelect();
					GameCanvas.tabAllScr.tabCurrent.beginFocus();
				}
				this.str = T.mHelp[25];
				this.createPoint(MainTab.xTab + 22 + 20, MainTab.yTab + 36 + MainTab.hItemTab, 0);
				break;
			}
			case 1:
			{
				this.str = T.mHelp[26];
				int num3 = TabEquip.mposEquip[1][0] + 20;
				int num4 = TabEquip.mposEquip[1][1];
				this.createPoint(num3 + 12, num4 + 12, 10);
				break;
			}
			case 2:
				this.str = T.mHelp[27];
				break;
			}
			break;
		case 12:
			this.x = MotherCanvas.hw;
			this.y = MotherCanvas.h - GameCanvas.hCommand * 2;
			this.archor = 33;
			switch (typeSub)
			{
			case 0:
			{
				this.w = 140;
				this.str = T.mHelp[36];
				this.createPoint(MainTab.xTab + 22 + 20, MainTab.yTab + 36 + MainTab.hItemTab * 2, 0);
				bool flag5 = GameCanvas.currentScreen == GameCanvas.tabAllScr;
				if (flag5)
				{
					GameCanvas.tabAllScr.idSelect = 2;
					GameCanvas.tabAllScr.setTabSelect();
					GameCanvas.tabAllScr.tabCurrent.beginFocus();
				}
				break;
			}
			case 1:
				this.w = 140;
				this.str = T.mHelp[37];
				this.createPoint(MainTab.xTab + MainTab.wTab / 2 - (MainTab.wTab - 70) / 2 + 10 + (MainTab.wTab - 22) / 4, MainTab.yTab + 20, 0);
				break;
			case 2:
			{
				this.w = 140;
				this.str = T.mHelp[38];
				this.createPoint(MainTab.xTab + MainTab.wTab / 2 - (MainTab.wTab - 70) / 2 + 10 + (MainTab.wTab - 22) / 4 * 3, MainTab.yTab + 20, 0);
				bool flag6 = GameCanvas.currentScreen == GameCanvas.tabAllScr;
				if (flag6)
				{
					GameCanvas.tabAllScr.tabCurrent.updateChangeTabInfo();
				}
				break;
			}
			case 3:
				this.w = 140;
				this.str = T.mHelp[39];
				break;
			}
			break;
		case 13:
			this.x = MotherCanvas.hw;
			this.y = MotherCanvas.h - GameCanvas.hCommand * 2;
			this.archor = 33;
			this.w = 140;
			this.str = T.mHelp[32];
			break;
		case 14:
			this.x = MotherCanvas.hw;
			this.y = MotherCanvas.h - GameCanvas.hCommand * 2;
			this.archor = 33;
			switch (typeSub)
			{
			case 0:
				this.w = 140;
				this.str = T.mHelp[28];
				GameScreen.indexHelp = 14;
				GameCanvas.saveRms.SaveIndexHelp();
				break;
			case 1:
				this.str = T.mHelp[29];
				this.x = 100;
				this.y = 5;
				this.archor = 0;
				this.createPoint(this.x, this.y + 20, 0);
				break;
			case 2:
				this.str = T.mHelp[30];
				this.createPoint(MainTab.xTab + 22 + 20, MainTab.yTab + 36 + MainTab.hItemTab * 4, 0);
				break;
			case 3:
				this.str = T.mHelp[31];
				break;
			}
			break;
		case 15:
			this.x = MotherCanvas.hw;
			this.y = MotherCanvas.h - GameCanvas.hCommand * 2;
			this.archor = 33;
			if (typeSub != 0)
			{
				if (typeSub == 1)
				{
					this.w = 140;
					this.str = T.mHelp[34];
					this.createPoint(MainTab.xTab + MainTab.wTab / 2 - (MainTab.wTab - 70) / 2 + 10 + 40 + 20, MainTab.yTab + 32 + 24, 0);
				}
			}
			else
			{
				this.w = 140;
				this.str = T.mHelp[33];
				this.createPoint(MainTab.xTab + 22 + 20, MainTab.yTab + 36 + MainTab.hItemTab * 3, 0);
				bool flag7 = GameCanvas.currentScreen == GameCanvas.tabAllScr;
				if (flag7)
				{
					GameCanvas.tabAllScr.idSelect = 3;
					GameCanvas.tabAllScr.setTabSelect();
					GameCanvas.tabAllScr.tabCurrent.beginFocus();
				}
			}
			break;
		case 16:
			this.x = MotherCanvas.hw;
			this.y = MotherCanvas.h - GameCanvas.hCommand * 2;
			this.archor = 33;
			GameScreen.indexHelp = 17;
			GameCanvas.saveRms.SaveIndexHelp();
			if (typeSub != 0)
			{
				if (typeSub == 1)
				{
					bool isTouch7 = GameCanvas.isTouch;
					if (isTouch7)
					{
						this.w = 140;
						this.str = T.mHelp[41];
						this.archor = 0;
						this.x = Interface_Game.mPosOther[4][0] + 35;
						this.y = Interface_Game.mPosOther[4][1] + 35;
						this.createPoint(this.x, this.y, 0);
					}
					else
					{
						this.isRemove = true;
					}
				}
			}
			else
			{
				bool flag8 = !GameCanvas.isTouch;
				if (flag8)
				{
					this.w = 140;
					this.str = T.mHelp[40];
					this.createPoint(MainTab.xTab + 22 + 20, MainTab.yTab + 36 + MainTab.hItemTab * 5, 0);
					bool flag9 = GameCanvas.currentScreen == GameCanvas.tabAllScr;
					if (flag9)
					{
						GameCanvas.tabAllScr.idSelect = 5;
						GameCanvas.tabAllScr.setTabSelect();
						GameCanvas.tabAllScr.tabCurrent.beginFocus();
					}
				}
				else
				{
					this.isRemove = true;
				}
			}
			break;
		case 17:
			this.isRemove = true;
			break;
		case 18:
		{
			mVector mVector = new mVector();
			mVector.addElement(new iCommand(T.textHelp, 1, 1, this));
			mVector.addElement(new iCommand(T.boqua, 1, 0, this));
			GameCanvas.Start_Normal_DiaLog(T.mHelp[1], mVector, false);
			this.isRemove = true;
			break;
		}
		case 19:
			this.w = 140;
			this.x = MotherCanvas.hw;
			this.y = MotherCanvas.h - GameCanvas.hCommand * 2;
			this.archor = 33;
			this.str = T.mHelp[42];
			break;
		case 20:
			this.w = 140;
			this.x = MotherCanvas.hw;
			this.y = MotherCanvas.h - GameCanvas.hCommand * 2;
			this.archor = 33;
			this.str = T.mHelp[43];
			break;
		case 21:
			this.w = 140;
			this.x = MotherCanvas.hw;
			this.y = MotherCanvas.h - GameCanvas.hCommand * 2;
			this.archor = 33;
			this.str = T.mHelp[44];
			break;
		}
		bool flag10 = this.str != null;
		if (flag10)
		{
			this.strShow = this.fontPaint.splitFontArray(this.str, this.w);
			this.h = this.strShow.Length * GameCanvas.hText;
		}
		bool flag11 = this.archor == 0;
		if (flag11)
		{
			this.xbegin = this.x;
			this.ybegin = this.y;
		}
		else
		{
			bool flag12 = this.archor == 1;
			if (flag12)
			{
				this.xbegin = this.x - this.w;
				this.ybegin = this.y;
			}
			else
			{
				bool flag13 = this.archor == 33;
				if (flag13)
				{
					this.xbegin = this.x - this.w / 2;
					this.ybegin = this.y - this.h;
				}
				else
				{
					bool flag14 = this.archor == 3;
					if (flag14)
					{
						this.xbegin = this.x - this.w / 2;
						this.ybegin = this.y - this.h / 2;
					}
					else
					{
						bool flag15 = this.archor == -1;
						if (flag15)
						{
							this.xbegin = this.x - this.w;
							this.ybegin = this.y - this.h;
						}
						else
						{
							bool flag16 = this.archor == 2;
							if (flag16)
							{
								this.xbegin = this.x;
								this.ybegin = this.y - this.h;
							}
						}
					}
				}
			}
		}
		bool flag17 = this.str != null;
		if (flag17)
		{
			this.runText.startDialogChain(this.str, 0, this.xbegin + 3, this.ybegin + 3, this.w, this.fontPaint);
		}
		GameCanvas.clearAll();
	}

	// Token: 0x06000731 RID: 1841 RVA: 0x0009BA04 File Offset: 0x00099C04
	private void setMove()
	{
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			bool flag = Interface_Game.typeTouch == 1;
			if (flag)
			{
				this.str = T.mHelp[8];
				this.x = MotherCanvas.hw;
				this.y = MotherCanvas.h - GameCanvas.hCommand * 2;
				this.archor = 33;
			}
			else
			{
				this.str = T.mHelp[7];
				this.x = Interface_Game.xPointMove + 15;
				this.y = Interface_Game.yPointMove - 45;
				this.archor = 0;
				this.strShow = this.fontPaint.splitFontArray(this.str, this.w);
				this.h = this.strShow.Length * GameCanvas.hText;
				this.createPoint(this.x, this.y + this.h, 3);
			}
		}
		else
		{
			this.str = T.mHelp[6];
			this.x = MotherCanvas.hw;
			this.y = MotherCanvas.h - GameCanvas.hCommand * 2;
			this.archor = 33;
		}
		GameScreen.indexHelp = this.type;
		GameCanvas.saveRms.SaveIndexHelp();
	}

	// Token: 0x06000732 RID: 1842 RVA: 0x0009BB30 File Offset: 0x00099D30
	private void setHotKey()
	{
		bool flag = this.typeSub == 0;
		if (flag)
		{
			this.str = T.mHelp[3];
		}
		else
		{
			bool flag2 = this.typeSub == 1;
			if (flag2)
			{
				bool isTouch = GameCanvas.isTouch;
				if (isTouch)
				{
					this.str = T.mHelp[5];
				}
				else
				{
					this.str = T.mHelp[4];
				}
			}
		}
		this.strShow = this.fontPaint.splitFontArray(this.str, this.w);
		this.h = this.strShow.Length * GameCanvas.hText;
		bool isTouch2 = GameCanvas.isTouch;
		if (isTouch2)
		{
			bool flag3 = Interface_Game.typeTouch == 1;
			if (flag3)
			{
				this.x = Interface_Game.mPosKillCur[2][0];
				this.y = Interface_Game.mPosKillCur[2][1] - 30;
				this.archor = 33;
				this.createPoint(this.x, this.y, 5);
			}
			else
			{
				this.x = Interface_Game.mPosKillCur[1][0];
				this.y = Interface_Game.mPosKillCur[1][1] - 30;
				this.archor = 1;
				this.createPoint(this.x, this.y + this.h, 5);
			}
		}
		else
		{
			this.x = Interface_Game.mPosKillCur[2][0];
			this.y = Interface_Game.mPosKillCur[2][1] - 30;
			this.archor = 33;
			this.createPoint(this.x, this.y, 5);
		}
		GameScreen.indexHelp = this.type;
		GameCanvas.saveRms.SaveIndexHelp();
	}

	// Token: 0x06000733 RID: 1843 RVA: 0x0009BCC0 File Offset: 0x00099EC0
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
		{
			mVector mVector = new mVector();
			mVector.addElement(new iCommand(T.textHelp, 1, 1, this));
			mVector.addElement(new iCommand(T.boqua, 1, 0, this));
			GameCanvas.Start_Normal_DiaLog(T.mHelp[1], mVector, false);
			break;
		}
		case 1:
		{
			GameCanvas.end_Dialog();
			bool flag = subIndex == 1;
			if (flag)
			{
				GameScreen.indexHelp = 2;
				GameScreen.addHelp(1, 0);
			}
			else
			{
				GameScreen.indexHelp = -1;
			}
			GameCanvas.saveRms.SaveIndexHelp();
			break;
		}
		case 2:
			GameCanvas.end_Dialog();
			GameScreen.indexHelp = 18;
			GameCanvas.saveRms.SaveIndexHelp();
			GlobalService.gI().BeginGame();
			break;
		}
		base.commandPointer(index, subIndex);
	}

	// Token: 0x06000734 RID: 1844 RVA: 0x0009BD8C File Offset: 0x00099F8C
	public override void paint(mGraphics g)
	{
		int num = this.type;
		bool flag = this.strShow != null;
		if (flag)
		{
			AvMain.paintRect(g, this.xbegin, this.ybegin, this.w + 3, this.h, 1, 4);
			bool flag2 = this.runText != null;
			if (flag2)
			{
				this.runText.paintText(g, 0);
			}
		}
		bool flag3 = this.p != null;
		if (flag3)
		{
			bool flag4 = AvMain.imgHand == null;
			if (flag4)
			{
				AvMain.imgHand = mImage.createImage("/interface/hand.png");
			}
			else
			{
				g.drawRegion(AvMain.imgHand, 0, 0, 14, 16, this.p.dis, (float)this.p.x, (float)this.p.y, 3);
			}
		}
	}

	// Token: 0x06000735 RID: 1845 RVA: 0x0009BE58 File Offset: 0x0009A058
	public override void update()
	{
		bool flag = GameCanvas.currentDialog == null && GameCanvas.subDialog == null && !GameCanvas.menu.isShowMenu;
		if (flag)
		{
			this.updatekey();
			this.updatePointer();
		}
		bool flag2 = this.runText != null;
		if (flag2)
		{
			this.runText.updateDlg();
		}
		bool flag3 = this.p == null;
		if (!flag3)
		{
			this.p.f++;
			bool flag4 = this.p.f < 10;
			if (flag4)
			{
				this.p.x += this.p.vx;
				this.p.y += this.p.vy;
				bool flag5 = this.p.vx > 0;
				if (flag5)
				{
					this.p.vx--;
				}
				bool flag6 = this.p.vx < 0;
				if (flag6)
				{
					this.p.vx++;
				}
				bool flag7 = this.p.vy > 0;
				if (flag7)
				{
					this.p.vy--;
				}
				bool flag8 = this.p.vy < 0;
				if (flag8)
				{
					this.p.vy++;
				}
			}
			else
			{
				bool flag9 = this.p.f == 15;
				if (flag9)
				{
					this.p.x = this.p.toX;
					this.p.y = this.p.toY;
					this.p.vx = this.p.vxMax;
					this.p.vy = this.p.vyMax;
					this.p.f = 0;
				}
			}
		}
	}

	// Token: 0x06000736 RID: 1846 RVA: 0x0009C04C File Offset: 0x0009A24C
	public override void updatekey()
	{
		switch (this.type)
		{
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
		case 9:
		case 10:
		case 11:
		case 12:
		case 13:
		case 14:
		case 15:
		case 16:
		case 19:
		case 20:
		case 21:
		{
			bool flag = GameCanvas.AnyKey();
			if (flag)
			{
				this.setActionHelp();
			}
			break;
		}
		}
	}

	// Token: 0x06000737 RID: 1847 RVA: 0x0009C0D8 File Offset: 0x0009A2D8
	public override void updatePointer()
	{
		switch (this.type)
		{
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
		case 9:
		case 10:
		case 11:
		case 12:
		case 13:
		case 14:
		case 15:
		case 16:
		case 19:
		case 20:
		case 21:
		{
			bool isPointerSelect = GameCanvas.isPointerSelect;
			if (isPointerSelect)
			{
				this.setActionHelp();
			}
			break;
		}
		}
	}

	// Token: 0x06000738 RID: 1848 RVA: 0x0009C164 File Offset: 0x0009A364
	public void setActionHelp()
	{
		bool flag = this.runText != null && !this.runText.nextDlgStep();
		if (flag)
		{
			GameCanvas.clearAll();
		}
		else
		{
			switch (this.type)
			{
			case 1:
				GameScreen.addHelp(3, 0);
				this.isRemove = true;
				break;
			case 2:
			{
				bool flag2 = this.typeSub == 0;
				if (flag2)
				{
					GameScreen.addHelp(2, 1);
					this.isRemove = true;
				}
				else
				{
					bool flag3 = this.typeSub == 1;
					if (flag3)
					{
						this.isRemove = true;
					}
				}
				break;
			}
			case 3:
				GameScreen.addHelp(2, 0);
				this.isRemove = true;
				break;
			case 4:
				GameScreen.addHelp(5, 0);
				this.isRemove = true;
				break;
			case 5:
				GameScreen.addHelp(6, 0);
				this.isRemove = true;
				break;
			case 6:
				GameScreen.addHelp(7, 0);
				GameCanvas.chatTabScr.addNewChat(T.haitac, string.Empty, T.chucban, 0, false);
				this.isRemove = true;
				break;
			case 7:
				this.isRemove = true;
				GameScreen.indexHelp = 8;
				GameCanvas.saveRms.SaveIndexHelp();
				break;
			case 9:
				this.isRemove = true;
				break;
			case 10:
			{
				bool flag4 = this.typeSub == 0;
				if (flag4)
				{
					GameScreen.addHelp(10, 1);
					this.isRemove = true;
				}
				else
				{
					bool flag5 = this.typeSub == 1;
					if (flag5)
					{
						GameScreen.addHelp(11, 0);
						this.isRemove = true;
					}
				}
				break;
			}
			case 11:
			{
				bool flag6 = this.typeSub == 0;
				if (flag6)
				{
					GameScreen.addHelp(11, 1);
					this.isRemove = true;
				}
				else
				{
					bool flag7 = this.typeSub == 1;
					if (flag7)
					{
						GameScreen.addHelp(11, 2);
						this.isRemove = true;
					}
					else
					{
						bool flag8 = this.typeSub == 2;
						if (flag8)
						{
							GameScreen.indexHelp = 14;
							GameCanvas.saveRms.SaveIndexHelp();
							this.isRemove = true;
						}
					}
				}
				break;
			}
			case 12:
			{
				bool flag9 = this.typeSub == 0;
				if (flag9)
				{
					GameScreen.addHelp(12, 1);
					this.isRemove = true;
				}
				else
				{
					bool flag10 = this.typeSub == 1;
					if (flag10)
					{
						GameScreen.addHelp(12, 2);
						this.isRemove = true;
					}
					else
					{
						bool flag11 = this.typeSub == 2;
						if (flag11)
						{
							GameScreen.addHelp(12, 3);
							this.isRemove = true;
						}
						else
						{
							bool flag12 = this.typeSub == 3;
							if (flag12)
							{
								GameScreen.indexHelp = 16;
								GameCanvas.saveRms.SaveIndexHelp();
								this.isRemove = true;
							}
						}
					}
				}
				break;
			}
			case 13:
			{
				bool flag13 = this.typeSub == 0;
				if (flag13)
				{
					GameScreen.indexHelp = 15;
					GameCanvas.saveRms.SaveIndexHelp();
					this.isRemove = true;
				}
				break;
			}
			case 14:
			{
				bool flag14 = this.typeSub == 0;
				if (flag14)
				{
					this.isRemove = true;
				}
				else
				{
					bool flag15 = this.typeSub == 1;
					if (flag15)
					{
						this.isRemove = true;
					}
					else
					{
						bool flag16 = this.typeSub == 2;
						if (flag16)
						{
							GameScreen.addHelp(14, 3);
							this.isRemove = true;
						}
						else
						{
							bool flag17 = this.typeSub == 3;
							if (flag17)
							{
								GameScreen.indexHelp = 13;
								GameCanvas.saveRms.SaveIndexHelp();
								this.isRemove = true;
							}
						}
					}
				}
				break;
			}
			case 15:
			{
				bool flag18 = this.typeSub == 0;
				if (flag18)
				{
					GameScreen.addHelp(15, 1);
					this.isRemove = true;
				}
				else
				{
					bool flag19 = this.typeSub == 1;
					if (flag19)
					{
						GameScreen.addHelp(12, 0);
						this.isRemove = true;
					}
				}
				break;
			}
			case 16:
			{
				bool flag20 = this.typeSub == 0;
				if (flag20)
				{
					this.isRemove = true;
				}
				else
				{
					bool flag21 = this.typeSub == 1;
					if (flag21)
					{
						this.isRemove = true;
					}
				}
				break;
			}
			case 19:
			case 20:
			case 21:
				this.isRemove = true;
				break;
			}
		}
	}

	// Token: 0x06000739 RID: 1849 RVA: 0x0009C57C File Offset: 0x0009A77C
	public void createPoint(int x, int y, int ar)
	{
		this.p = new Point_Focus(x, y);
		this.p.toX = this.p.x;
		this.p.toY = this.p.y;
		switch (ar)
		{
		case 0:
			this.p.vx = -5;
			this.p.vy = 0;
			break;
		case 1:
			this.p.vx = 5;
			this.p.vy = 0;
			this.p.dis = 2;
			break;
		case 2:
			this.p.vx = 0;
			this.p.vy = -5;
			this.p.dis = 5;
			break;
		case 3:
		case 5:
		{
			this.p.vx = 0;
			this.p.vy = 5;
			bool flag = ar == 3;
			if (flag)
			{
				this.p.dis = 6;
			}
			else
			{
				this.p.dis = 7;
			}
			break;
		}
		case 10:
			this.p.vx = -3;
			this.p.vy = 0;
			break;
		}
		this.p.vxMax = this.p.vx;
		this.p.vyMax = this.p.vy;
	}

	// Token: 0x0600073A RID: 1850 RVA: 0x0009C6F4 File Offset: 0x0009A8F4
	public static bool checkIndexHelp(int typeCheck)
	{
		bool flag = GameScreen.vecHelp == null;
		bool result;
		if (flag)
		{
			result = false;
		}
		else
		{
			for (int i = 0; i < GameScreen.vecHelp.size(); i++)
			{
				MainHelp mainHelp = (MainHelp)GameScreen.vecHelp.elementAt(i);
				bool flag2 = mainHelp.type == typeCheck;
				if (flag2)
				{
					return true;
				}
			}
			result = false;
		}
		return result;
	}

	// Token: 0x0600073B RID: 1851 RVA: 0x0009C75C File Offset: 0x0009A95C
	public static void checkRemoveIndexHelp(int typeCheck)
	{
		bool flag = GameScreen.vecHelp == null;
		if (!flag)
		{
			for (int i = 0; i < GameScreen.vecHelp.size(); i++)
			{
				MainHelp mainHelp = (MainHelp)GameScreen.vecHelp.elementAt(i);
				bool flag2 = mainHelp.type == typeCheck;
				if (flag2)
				{
					GameScreen.vecHelp.removeElement(mainHelp);
				}
			}
		}
	}

	// Token: 0x0600073C RID: 1852 RVA: 0x0009C7C4 File Offset: 0x0009A9C4
	public static void setNextHelp(bool isHanhTrang)
	{
		bool flag = GameScreen.indexHelp < 0;
		if (!flag)
		{
			int indexHelp = GameScreen.indexHelp;
			int num = indexHelp;
			if (num != 2)
			{
				switch (num)
				{
				case 8:
					GameScreen.addHelp(8, 0);
					return;
				case 9:
					GameScreen.addHelp(9, 0);
					return;
				case 10:
					if (isHanhTrang)
					{
						GameScreen.addHelp(10, 0);
					}
					return;
				case 14:
				{
					bool flag2 = isHanhTrang && Player.vecQuest.size() > 0;
					if (flag2)
					{
						GameScreen.addHelp(14, 2);
						bool flag3 = GameCanvas.currentScreen == GameCanvas.tabAllScr;
						if (flag3)
						{
							GameCanvas.tabAllScr.idSelect = 4;
							GameCanvas.tabAllScr.setTabSelect();
							GameCanvas.tabAllScr.tabCurrent.beginFocus();
						}
					}
					return;
				}
				case 15:
					if (isHanhTrang)
					{
						GameScreen.addHelp(15, 0);
					}
					return;
				case 16:
				{
					bool flag4 = isHanhTrang && !GameCanvas.isTouch;
					if (flag4)
					{
						GameScreen.addHelp(16, 0);
					}
					return;
				}
				}
				GameScreen.addHelp(GameScreen.indexHelp, 0);
			}
			else
			{
				GameScreen.addHelp(4, 0);
				MainHelp.checkRemoveIndexHelp(2);
			}
		}
	}

	// Token: 0x04000AEB RID: 2795
	public const sbyte HELLO_1 = 0;

	// Token: 0x04000AEC RID: 2796
	public const sbyte MP_HP = 1;

	// Token: 0x04000AED RID: 2797
	public const sbyte HOT_KEY = 2;

	// Token: 0x04000AEE RID: 2798
	public const sbyte MOVE = 3;

	// Token: 0x04000AEF RID: 2799
	public const sbyte NEXT_FOCUS = 4;

	// Token: 0x04000AF0 RID: 2800
	public const sbyte CHANGE_HOT_KEY = 5;

	// Token: 0x04000AF1 RID: 2801
	public const sbyte CHAT = 6;

	// Token: 0x04000AF2 RID: 2802
	public const sbyte EVENT_M = 7;

	// Token: 0x04000AF3 RID: 2803
	public const sbyte GET_ITEM = 8;

	// Token: 0x04000AF4 RID: 2804
	public const sbyte INVENTORY = 9;

	// Token: 0x04000AF5 RID: 2805
	public const sbyte NEXT_INVENTORY = 10;

	// Token: 0x04000AF6 RID: 2806
	public const sbyte EQUIP = 11;

	// Token: 0x04000AF7 RID: 2807
	public const sbyte INFO = 12;

	// Token: 0x04000AF8 RID: 2808
	public const sbyte LV_UP = 13;

	// Token: 0x04000AF9 RID: 2809
	public const sbyte QUEST = 14;

	// Token: 0x04000AFA RID: 2810
	public const sbyte SKILL = 15;

	// Token: 0x04000AFB RID: 2811
	public const sbyte SETTING = 16;

	// Token: 0x04000AFC RID: 2812
	public const sbyte END = 17;

	// Token: 0x04000AFD RID: 2813
	public const sbyte BEGINNEW = 18;

	// Token: 0x04000AFE RID: 2814
	public const sbyte BUY_SELL = 19;

	// Token: 0x04000AFF RID: 2815
	public const sbyte UPGRADE = 20;

	// Token: 0x04000B00 RID: 2816
	public const sbyte BOSS = 21;

	// Token: 0x04000B01 RID: 2817
	private int x;

	// Token: 0x04000B02 RID: 2818
	private int y;

	// Token: 0x04000B03 RID: 2819
	private int w;

	// Token: 0x04000B04 RID: 2820
	private int h;

	// Token: 0x04000B05 RID: 2821
	private int type;

	// Token: 0x04000B06 RID: 2822
	private int typeSub;

	// Token: 0x04000B07 RID: 2823
	private int xbegin;

	// Token: 0x04000B08 RID: 2824
	private int ybegin;

	// Token: 0x04000B09 RID: 2825
	private int archor;

	// Token: 0x04000B0A RID: 2826
	private string str;

	// Token: 0x04000B0B RID: 2827
	private string[] strShow;

	// Token: 0x04000B0C RID: 2828
	public bool isBreak;

	// Token: 0x04000B0D RID: 2829
	public bool isRemove;

	// Token: 0x04000B0E RID: 2830
	public bool isInMap;

	// Token: 0x04000B0F RID: 2831
	private iCommand cmd;

	// Token: 0x04000B10 RID: 2832
	private mFont fontPaint;

	// Token: 0x04000B11 RID: 2833
	private Point_Focus p;

	// Token: 0x04000B12 RID: 2834
	private RunWord runText;
}
