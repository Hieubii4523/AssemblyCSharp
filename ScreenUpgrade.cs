using System;

// Token: 0x020000E7 RID: 231
public class ScreenUpgrade : MainScreen
{
	// Token: 0x06000DD1 RID: 3537 RVA: 0x0010AE9C File Offset: 0x0010909C
	public ScreenUpgrade()
	{
	}

	// Token: 0x06000DD2 RID: 3538 RVA: 0x0010AEF4 File Offset: 0x001090F4
	public ScreenUpgrade(sbyte typeRebuild, int size)
	{
		mSystem.outz("ScreenUpgrade type rebuild " + typeRebuild.ToString());
		this.typeRebuild = typeRebuild;
		this.vecInventory = Player.vecInventory;
		ScreenUpgrade.curTypeShop = this.typeRebuild;
		this.Step = 0;
		this.lech = 10;
		this.w = 290;
		this.h = 185;
		this.wItem = 24;
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.wItem = 28;
		}
		bool flag = this.w > MotherCanvas.w;
		if (flag)
		{
			this.w = MotherCanvas.w;
		}
		bool flag2 = this.h > MotherCanvas.h - GameCanvas.hCommand * 2;
		if (flag2)
		{
			this.h = MotherCanvas.h - GameCanvas.hCommand * 2;
		}
		this.x = MotherCanvas.hw - this.w / 2;
		this.y = MotherCanvas.hh - this.h / 2 + 5;
		this.wInven = this.w / 2;
		this.wInven -= this.wInven % this.wItem;
		this.hInven = this.h - this.lech * 3 - 5;
		this.maxNumItemW = this.wInven / this.wItem;
		this.xInven = this.x + this.w / 4 - this.wInven / 2 + 15;
		this.yInven = this.y + this.h / 2 - this.hInven / 2;
		int limX = ((Player.maxInventory - 1) / this.maxNumItemW + 1) * this.wItem - this.hInven;
		this.list = new ListNew(this.xInven, this.yInven, this.wInven, this.hInven, 0, 0, limX, true);
		this.cmdClose = new iCommand(T.close, -1, this);
		this.cmdShop = new iCommand(T.shopDa, 2, this);
		this.cmdMenu = new iCommand(T.menu, 3, this);
		bool isTouch2 = GameCanvas.isTouch;
		if (isTouch2)
		{
			this.cmdClose.setPos(this.x + this.w / 2 + 60, this.y - 15 + 10 + 8, MainTab.fraCloseTab, string.Empty);
			this.vecCmd.addElement(this.cmdClose);
			bool flag3 = typeRebuild != 18 && typeRebuild != 22;
			if (flag3)
			{
				AvMain.setPosCMD(this.cmdShop, 2);
				bool flag4 = typeRebuild != 6 && typeRebuild != 21;
				if (flag4)
				{
					this.vecCmd.addElement(this.cmdShop);
				}
				bool flag5 = GameCanvas.isTouchNoOrPC();
				if (flag5)
				{
					this.backCMD = this.cmdClose;
					this.menuCMD = this.cmdUpgrade;
				}
			}
			else
			{
				bool flag6 = GameCanvas.isTouchNoOrPC();
				if (flag6)
				{
					this.backCMD = this.cmdClose;
					this.menuCMD = this.cmdUpgrade;
				}
			}
		}
		else
		{
			this.cmdClose.caption = T.close + " " + T.Upgrade;
			this.right = this.cmdMenu;
			this.left = this.cmdUpgrade;
		}
		this.xTiLe = this.xInven + this.wInven + 4;
		this.setStart(typeRebuild, size);
		bool flag7 = typeRebuild == 20;
		if (flag7)
		{
			this.cmdUpgrade.caption = T.join;
		}
	}

	// Token: 0x06000DD3 RID: 3539 RVA: 0x0010B2AC File Offset: 0x001094AC
	public void getMenushop()
	{
		mVector mVector = new mVector();
		mVector.addElement(this.cmdShop);
		mVector.addElement(this.cmdClose);
		GameCanvas.menuCur.startAt(mVector, 2, T.Upgrade);
	}

	// Token: 0x06000DD4 RID: 3540 RVA: 0x000092E5 File Offset: 0x000074E5
	public override void setxyPlus12()
	{
		GameCanvas.xPlus12 = 2;
		GameCanvas.yPlus12 = 2;
	}

	// Token: 0x06000DD5 RID: 3541 RVA: 0x0010B2EC File Offset: 0x001094EC
	public virtual void setStart(sbyte typeRebuild, int size)
	{
		int num = this.x + this.wInven + (this.w - this.lech * 3 - this.wInven) / 2 + 10;
		int num2 = this.y + this.h / 2 - this.wItem / 2 - 10;
		bool flag = size < 0;
		if (flag)
		{
			int num3 = 270;
			int num4 = (this.w - this.lech * 3 - this.wInven) / 2 - 20;
			bool flag2 = num4 < this.wItem;
			if (flag2)
			{
				num4 = this.wItem;
			}
			this.nameScreen = T.cuonghoa;
			this.posUp = mSystem.new_M_Int(5, 2);
			bool flag3 = typeRebuild == 15;
			if (flag3)
			{
				this.posUp = mSystem.new_M_Int(6, 2);
				num2 += this.wItem / 4;
				this.nameScreen = T.sieuCuonghoa;
			}
			bool flag4 = typeRebuild == 18;
			if (flag4)
			{
				this.posUp = mSystem.new_M_Int(7, 2);
				num2 += this.wItem / 4;
				this.nameScreen = T.cuonghoaDIAL;
			}
			bool flag5 = typeRebuild == 22;
			if (flag5)
			{
				this.posUp = mSystem.new_M_Int(6, 2);
				num2 += this.wItem / 4;
				this.nameScreen = T.cuongHoaSkin;
				this.typeShowItem = 1;
				this.IdSelect = -1;
			}
			this.posUp[0][0] = num;
			this.posUp[0][1] = num2;
			bool flag6 = typeRebuild == 22;
			if (flag6)
			{
				num3 = 180;
			}
			for (int i = 1; i < this.posUp.Length; i++)
			{
				bool flag7 = typeRebuild == 18 || typeRebuild == 22;
				if (flag7)
				{
					this.posUp[i][0] = num + CRes.getsin(CRes.fixangle(num3)) * num4 / 1000;
					this.posUp[i][1] = num2 + CRes.getcos(CRes.fixangle(num3)) * num4 / 1000;
				}
				else
				{
					this.posUp[i][0] = num + CRes.getcos(CRes.fixangle(num3)) * num4 / 1000;
					this.posUp[i][1] = num2 + CRes.getsin(CRes.fixangle(num3)) * num4 / 1000;
				}
				num3 += 360 / (this.posUp.Length - 1);
			}
			this.cmdBovao = new iCommand(T.bovao, 0, this);
			this.cmdUpgrade = new iCommand(T.Upgrade, 1, this);
			bool flag8 = typeRebuild == 15;
			if (flag8)
			{
				this.cmdBovao = new iCommand(T.bovao, 4, this);
				this.cmdUpgrade = new iCommand(T.Upgrade, 5, this);
			}
			bool flag9 = typeRebuild == 18;
			if (flag9)
			{
				this.cmdBovao = new iCommand(T.bovao, 11, this);
				this.cmdUpgrade = new iCommand(T.Upgrade, 12, this);
			}
			bool flag10 = typeRebuild == 22;
			if (flag10)
			{
				this.cmdBovao = new iCommand(T.bovao, 13, this);
				this.cmdUpgrade = new iCommand(T.Upgrade, 14, this);
			}
			bool flag11 = typeRebuild != 18 && typeRebuild != 22 && GameCanvas.isTouch;
			if (flag11)
			{
				this.cmdUpgrade.setPos(this.posUp[0][0] + this.wItem / 2, this.y + this.h - iCommand.hButtonCmdNor / 2 - 10, null, this.cmdUpgrade.caption);
				this.vecCmd.addElement(this.cmdUpgrade);
			}
			bool flag12 = !GameCanvas.isTouch;
			if (flag12)
			{
				this.right = this.cmdMenu;
				this.left = this.cmdUpgrade;
			}
		}
		else
		{
			num = this.x + this.wInven + (this.w - this.lech * 3 - this.wInven) / 6 + 5;
			num2 = this.y + this.h / 2 - this.wItem / 2 - 5;
			int num5 = 3;
			this.posUp = mSystem.new_M_Int(size + 1, 2);
			int num6 = size % 2;
			int num7 = (size > num5) ? (num2 - (this.wItem + this.wItem / 4)) : ((num6 != 0) ? (num2 - size / 2 * (this.wItem + this.wItem / 4)) : (this.y + this.h / 2 - 5 - size / 2 * (this.wItem + this.wItem / 4)));
			for (int j = 0; j < this.posUp.Length; j++)
			{
				this.posUp[j][0] = num + j / num5 * (this.wItem + this.wItem / 4);
				this.posUp[j][1] = num7 + j % num5 * (this.wItem + this.wItem / 4);
				bool flag13 = j == this.posUp.Length - 1;
				if (flag13)
				{
					this.posUp[this.posUp.Length - 1][0] = num + (this.w - this.lech * 3 - this.wInven) / 6 * 4;
					this.posUp[this.posUp.Length - 1][1] = num2;
				}
			}
			this.cmdUpgrade = new iCommand(T.Upgrade, 10, this);
			this.left = this.cmdUpgrade;
		}
		ScreenUpgrade.mItemUpgrade = new MainItem[this.posUp.Length];
		bool flag14 = this.IdSelect >= 0;
		if (flag14)
		{
			this.getItemCurNew();
		}
	}

	// Token: 0x06000DD6 RID: 3542 RVA: 0x0010B860 File Offset: 0x00109A60
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
			break;
		}
		case 0:
		{
			bool flag2 = this.itemCur != null;
			if (flag2)
			{
				bool flag3 = this.itemCur.typeObject == 3;
				if (flag3)
				{
					GlobalService.gI().Upgrade_Item(4, this.itemCur.ID, 0);
				}
				else
				{
					bool flag4 = this.itemCur.typeObject == 7 && this.itemCur.getStar();
					if (flag4)
					{
						GlobalService.gI().Upgrade_Item(5, this.itemCur.ID, (sbyte)subIndex);
					}
					else
					{
						bool flag5 = this.itemCur.typeObject == 7 && this.itemCur.typeMaterial == 3;
						if (flag5)
						{
							GlobalService.gI().Upgrade_Item(6, this.itemCur.ID, (sbyte)subIndex);
						}
					}
				}
			}
			break;
		}
		case 1:
		{
			bool flag6 = ScreenUpgrade.mItemUpgrade[0] == null;
			if (flag6)
			{
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.nullItemUpgrade);
			}
			else
			{
				GlobalService.gI().Upgrade_Item(1, ScreenUpgrade.mItemUpgrade[0].ID, 0);
			}
			break;
		}
		case 2:
			GlobalService.gI().Upgrade_Item(8, 0, 0);
			break;
		case 3:
			this.getMenushop();
			break;
		case 4:
		{
			bool flag7 = this.itemCur == null;
			if (!flag7)
			{
				bool flag8 = this.itemCur.typeObject == 3;
				if (flag8)
				{
					GlobalService.gI().Upgrade_Super_Item(4, this.itemCur.ID, 0, 0);
				}
				else
				{
					bool flag9 = this.itemCur.typeObject == 7 && this.itemCur.getStar();
					if (flag9)
					{
						GlobalService.gI().Upgrade_Super_Item(5, this.itemCur.ID, (sbyte)subIndex, 1);
					}
					else
					{
						bool flag10 = this.itemCur.typeObject == 7 && this.itemCur.typeMaterial == 3;
						if (flag10)
						{
							bool flag11 = subIndex == 0;
							if (flag11)
							{
								GlobalService.gI().Upgrade_Super_Item(6, this.itemCur.ID, 0, 0);
							}
							else
							{
								this.input = new InputDialog();
								iCommand cmd = new iCommand(T.bovao, 6, this);
								this.input.setinfo(T.soluong, cmd, false, this.itemCur.namepaint);
								GameCanvas.Start_Current_Dialog(this.input);
							}
						}
						else
						{
							bool flag12 = this.itemCur.typeObject == 7 && this.itemCur.typeMaterial == 7;
							if (flag12)
							{
								GlobalService.gI().Upgrade_Super_Item(14, this.itemCur.ID, (sbyte)subIndex, 1);
							}
						}
					}
				}
			}
			break;
		}
		case 5:
		{
			bool flag13 = ScreenUpgrade.mItemUpgrade[0] == null;
			if (flag13)
			{
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.nullItemUpgrade);
			}
			else
			{
				GlobalService.gI().Upgrade_Super_Item(1, ScreenUpgrade.mItemUpgrade[0].ID, 0, 0);
			}
			break;
		}
		case 6:
		{
			bool flag14 = this.itemCur != null;
			if (flag14)
			{
				int num = 1;
				try
				{
					num = int.Parse(this.input.tfInput.getText());
					bool flag15 = num < 0;
					if (flag15)
					{
						num = 1;
					}
				}
				catch (Exception)
				{
					num = 1;
				}
				GlobalService.gI().Upgrade_Super_Item(6, this.itemCur.ID, 1, (sbyte)num);
			}
			GameCanvas.end_Cur_Dialog();
			break;
		}
		case 7:
		{
			bool flag16 = this.itemCur != null;
			if (flag16)
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
				GlobalService.gI().Upgrade_Dial(5, this.itemCur.ID, 1, (sbyte)num2);
			}
			GameCanvas.end_Cur_Dialog();
			break;
		}
		case 8:
		{
			bool flag18 = this.itemCur != null;
			if (flag18)
			{
				int num3 = 1;
				try
				{
					num3 = int.Parse(this.input.tfInput.getText());
					bool flag19 = num3 < 0;
					if (flag19)
					{
						num3 = 1;
					}
				}
				catch (Exception)
				{
					num3 = 1;
				}
				GlobalService.gI().Upgrade_Dial(6, this.itemCur.ID, 1, (sbyte)num3);
			}
			GameCanvas.end_Cur_Dialog();
			break;
		}
		case 10:
			GlobalService.gI().Devil_Upgrade(20, ScreenUpgrade.mItemUpgrade[ScreenUpgrade.mItemUpgrade.Length - 1].ID, ScreenUpgrade.mItemUpgrade[ScreenUpgrade.mItemUpgrade.Length - 1].typeObject, 0);
			break;
		case 11:
		{
			bool flag20 = this.itemCur == null;
			if (!flag20)
			{
				bool flag21 = this.itemCur.typeObject == 3;
				if (flag21)
				{
					GlobalService.gI().Upgrade_Dial(4, this.itemCur.ID, 0, 0);
				}
				else
				{
					bool flag22 = this.itemCur.typeObject == 7 && this.itemCur.getStar();
					if (flag22)
					{
						bool flag23 = subIndex == 0;
						if (flag23)
						{
							GlobalService.gI().Upgrade_Dial(5, this.itemCur.ID, 0, 0);
						}
						else
						{
							this.input = new InputDialog();
							iCommand cmd2 = new iCommand(T.bovao, 7, this);
							this.input.setinfo(T.soluong, cmd2, false, this.itemCur.namepaint);
							GameCanvas.Start_Current_Dialog(this.input);
						}
					}
					else
					{
						bool flag24 = this.itemCur.typeObject == 7 && this.itemCur.typeMaterial == 3;
						if (flag24)
						{
							bool flag25 = subIndex == 0;
							if (flag25)
							{
								GlobalService.gI().Upgrade_Dial(6, this.itemCur.ID, 0, 0);
							}
							else
							{
								this.input = new InputDialog();
								iCommand cmd3 = new iCommand(T.bovao, 8, this);
								this.input.setinfo(T.soluong, cmd3, false, this.itemCur.namepaint);
								GameCanvas.Start_Current_Dialog(this.input);
							}
						}
						else
						{
							bool flag26 = this.itemCur.typeObject == 7 && this.itemCur.typeMaterial == 7;
							if (flag26)
							{
								GlobalService.gI().Upgrade_Dial(14, this.itemCur.ID, (sbyte)subIndex, 1);
							}
						}
					}
				}
			}
			break;
		}
		case 12:
		{
			bool flag27 = ScreenUpgrade.mItemUpgrade[0] == null;
			if (flag27)
			{
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.nullItemUpgrade);
			}
			else
			{
				GlobalService.gI().Upgrade_Dial(1, ScreenUpgrade.mItemUpgrade[0].ID, 0, 0);
			}
			break;
		}
		}
	}

	// Token: 0x06000DD7 RID: 3543 RVA: 0x0010BF60 File Offset: 0x0010A160
	public override void paint(mGraphics g)
	{
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.paint(g);
		}
		GameCanvas.resetTrans(g);
		this.paintBackGr(g);
		bool flag2 = this.Step == 0;
		if (flag2)
		{
			this.paintInven(g);
		}
		else
		{
			bool flag3 = this.typeRebuild != 22;
			if (flag3)
			{
				bool flag4 = this.fraEffUpgrade == null;
				if (flag4)
				{
					this.fraEffUpgrade = new FrameImage(mImage.createImage("/interface/effupgrade.png"), 58, 50);
				}
				this.fraEffUpgrade.drawFrame(this.frameEff % this.fraEffUpgrade.nFrame, this.xInven + this.wInven / 2 + 10, this.yInven + this.hInven / 2, 0, 3, g);
			}
		}
		GameCanvas.resetTrans(g);
		Interface_Game.paintNumMess(g, -Interface_Game.xNumMess + 8, -Interface_Game.yNumMess + 3);
		this.paintEff(g, -1);
		this.paintTrade(g);
		this.paintPosItem(g);
		this.paintTiLe(g);
		bool flag5 = this.vecCmd != null && GameCanvas.getShowCmd();
		if (flag5)
		{
			for (int i = 0; i < this.vecCmd.size(); i++)
			{
				iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
				iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
			}
		}
		bool flag6 = this.isShowInfo && this.Step == 0 && this.itemCur != null;
		if (flag6)
		{
			MainTab.paintInfoEveryWhere(g, this.itemCur, null, 0, this.xInfo, this.yInfo, this.itemCur.wInfo, this.itemCur.hInfo, false, null, 0);
		}
		base.paint(g);
		Interface_Game.paintEffShowMoney(g, MotherCanvas.hw - Interface_Game.wMoneyEff / 2, GameScreen.h12plus, true, 0);
		this.paintChat(g);
		this.paintEff(g, 0);
	}

	// Token: 0x06000DD8 RID: 3544 RVA: 0x0010C160 File Offset: 0x0010A360
	public virtual void paintTiLe(mGraphics g)
	{
		bool flag = this.typeRebuild == 20;
		if (flag)
		{
			mFont.tahoma_7b_black.drawString(g, T.tile + ScreenUpgrade.valueTile.ToString() + "%", this.xTiLe, this.yInven, 0);
			int num = this.xInven + this.wInven + 20;
			int num2 = this.yInven + this.hInven - 20;
			AvMain.paintRect(g, num, num2, Interface_Game.wMoneyEff - 50, 30, 1, 4);
			num2 += 9;
			AvMain.fraMoney.drawFrame(0, num + Interface_Game.mini + AvMain.fraMoney.frameWidth / 2 - 3, num2, 0, 3, g);
			AvMain.fraMoney.drawFrame(1, num + Interface_Game.mini + AvMain.fraMoney.frameWidth / 2 + 45, num2, 0, 3, g);
			AvMain.fraMoney.drawFrame(7, num + Interface_Game.mini + AvMain.fraMoney.frameWidth / 2 - 3, num2 + 15, 0, 3, g);
			mFont.tahoma_7_yellow.drawString(g, " " + AvMain.getMoneyShortText((long)ScreenUpgrade.valueMonney_1), num + Interface_Game.mini + AvMain.fraMoney.frameWidth - 4, num2 - 5, 0);
			mFont.tahoma_7_red.drawString(g, " " + AvMain.getDotNumber((long)ScreenUpgrade.valueMonney_2), num + Interface_Game.mini + AvMain.fraMoney.frameWidth + 45, num2 - 5, 0);
			mFont.tahoma_7_green.drawString(g, " " + AvMain.getMoneyShortText((long)ScreenUpgrade.valueMonney_3), num + Interface_Game.mini + AvMain.fraMoney.frameWidth - 4, num2 - 5 + 15, 0);
		}
		else
		{
			bool flag2 = this.typeRebuild == 18;
			if (flag2)
			{
				mFont.tahoma_7b_black.drawString(g, T.tilerot + ScreenUpgrade.valueRotCap.ToString() + "%", this.xTiLe, this.yInven, 0);
				int num3 = this.xInven + this.wInven + 20;
				int num4 = this.yInven + this.hInven - 20;
				AvMain.paintRect(g, num3, num4, Interface_Game.wMoneyEff - 50, 30, 1, 4);
				num4 += 9;
				AvMain.fraMoney.drawFrame(0, num3 + Interface_Game.mini + AvMain.fraMoney.frameWidth / 2 - 3, num4, 0, 3, g);
				AvMain.fraMoney.drawFrame(1, num3 + Interface_Game.mini + AvMain.fraMoney.frameWidth / 2 + 45, num4, 0, 3, g);
				AvMain.fraMoney.drawFrame(7, num3 + Interface_Game.mini + AvMain.fraMoney.frameWidth / 2 - 3, num4 + 15, 0, 3, g);
				mFont.tahoma_7_yellow.drawString(g, " " + AvMain.getMoneyShortText((long)ScreenUpgrade.valueMonney_1), num3 + Interface_Game.mini + AvMain.fraMoney.frameWidth - 4, num4 - 5, 0);
				mFont.tahoma_7_red.drawString(g, " " + AvMain.getDotNumber((long)ScreenUpgrade.valueMonney_2), num3 + Interface_Game.mini + AvMain.fraMoney.frameWidth + 45, num4 - 5, 0);
				mFont.tahoma_7_green.drawString(g, " " + AvMain.getMoneyShortText((long)ScreenUpgrade.valueMonney_3), num3 + Interface_Game.mini + AvMain.fraMoney.frameWidth - 4, num4 - 5 + 15, 0);
			}
			else
			{
				bool flag3 = this.typeRebuild == 15 && ScreenUpgrade.mItemUpgrade[0] != null;
				if (flag3)
				{
					mFont.tahoma_7b_black.drawString(g, T.tilerot + ScreenUpgrade.valueRotCap.ToString() + "%", this.xTiLe, this.yInven, 0);
				}
				else
				{
					bool flag4 = ScreenUpgrade.mItemUpgrade[0] != null && (int)ScreenUpgrade.mItemUpgrade[0].LvUpgrade < ScreenUpgrade.mTileUpdate.Length;
					if (flag4)
					{
						bool flag5 = ScreenUpgrade.mItemUpgrade[1] != null;
						if (flag5)
						{
							mFont.tahoma_7b_black.drawString(g, string.Concat(new string[]
							{
								T.tile,
								((int)(ScreenUpgrade.mTileUpdate[(int)ScreenUpgrade.mItemUpgrade[0].LvUpgrade] / 10)).ToString(),
								"% + ",
								((int)ScreenUpgrade.mTileUpdate[(int)ScreenUpgrade.mItemUpgrade[0].LvUpgrade] / ScreenUpgrade.valueLucky).ToString(),
								"%"
							}), this.xTiLe, this.yInven, 0);
						}
						else
						{
							mFont.tahoma_7b_black.drawString(g, T.tile + ((int)(ScreenUpgrade.mTileUpdate[(int)ScreenUpgrade.mItemUpgrade[0].LvUpgrade] / 10)).ToString() + "%", this.xTiLe, this.yInven, 0);
						}
					}
				}
			}
		}
	}

	// Token: 0x06000DD9 RID: 3545 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void paintTrade(mGraphics g)
	{
	}

	// Token: 0x06000DDA RID: 3546 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void paintChat(mGraphics g)
	{
	}

	// Token: 0x06000DDB RID: 3547 RVA: 0x0010C638 File Offset: 0x0010A838
	public virtual void paintBackGr(mGraphics g)
	{
		base.paintPaper(g, this.x, this.y - 17, this.w, this.h + 17, this.w, (int)AvMain.PAPER_NORMAL);
		AvMain.paintRect(g, this.xInven, this.yInven, this.wInven, this.hInven, 0, 3);
		g.setColor(14203529);
		g.fillRoundRect(this.x + this.w / 2 - 60, this.y - 15 + 10, 120, 16, 4, 4);
		AvMain.FontBorderColor(g, this.nameScreen, this.x + this.w / 2, this.y - 15 + 12, 2, 6, 5);
		bool flag = this.typeRebuild == 15 || this.typeRebuild == 18 || this.typeRebuild == 22;
		if (flag)
		{
			bool flag2 = this.imghoavan == null;
			if (flag2)
			{
				this.loadImg();
			}
			g.drawRegion(this.imghoavan, 0, 0, 35, 35, 0, (float)(this.x + this.w - 35 - 10), (float)(this.y + this.h - 35 - 10), 0);
			g.drawRegion(this.imghoavan, 0, 0, 35, 35, 1, (float)(this.x + this.w - 35 - 10), (float)(this.y - 5), 0);
			g.drawRegion(this.imghoavan, 0, 0, 35, 35, 2, (float)(this.x + 10), (float)(this.y + this.h - 35 - 10), 0);
			g.drawRegion(this.imghoavan, 0, 0, 35, 35, 3, (float)(this.x + 10), (float)(this.y - 5), 0);
			g.drawImage(this.imgtron, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2, 3);
		}
		bool flag3 = this.typeRebuild != 21;
		if (!flag3)
		{
			MainImage imageOther = ObjectData.getImageOther(SplitScreen.instance.idMinimap, 0);
			bool flag4 = imageOther != null && imageOther.img != null;
			if (flag4)
			{
				g.drawImage(imageOther.img, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] - this.wItem / 6, 33);
			}
			bool flag5 = SplitScreen.instance.vecDaKhamHanhTrinh.size() > 0;
			if (flag5)
			{
				mFont.tahoma_7b_red.drawString(g, SplitScreen.instance.nameMinimap, this.posUp[0][0] + this.wItem / 2, this.yInven, 2);
			}
			else
			{
				mFont.tahoma_7b_black.drawString(g, SplitScreen.instance.nameMinimap, this.posUp[0][0] + this.wItem / 2, this.yInven, 2);
			}
			bool flag6 = ScreenUpgrade.mItemUpgrade[0] != null && ScreenUpgrade.mItemUpgrade[0].info != null;
			if (flag6)
			{
				string[] array = mFont.tahoma_7_black.splitFontArray(ScreenUpgrade.mItemUpgrade[0].info, 120);
				bool flag7 = array.Length == 1;
				if (flag7)
				{
					mFont.tahoma_7_black.drawString(g, ScreenUpgrade.mItemUpgrade[0].info, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem * 5 / 4, 2);
				}
				else
				{
					bool flag8 = array.Length > 1;
					if (flag8)
					{
						mFont.tahoma_7_black.drawString(g, array[0], this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem * 5 / 4 - 5, 2);
						mFont.tahoma_7_black.drawString(g, array[1], this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem * 5 / 4 + 5, 2);
					}
				}
			}
		}
	}

	// Token: 0x06000DDC RID: 3548 RVA: 0x0000BD31 File Offset: 0x00009F31
	private void loadImg()
	{
		this.imghoavan = mImage.createImage("/interface/u_hoavan.png");
		this.imgtron = mImage.createImage("/interface/u_tron.png");
	}

	// Token: 0x06000DDD RID: 3549 RVA: 0x0010CA44 File Offset: 0x0010AC44
	public virtual void paintPosItem(mGraphics g)
	{
		for (int i = 0; i < this.posUp.Length; i++)
		{
			AvMain.paintRect(g, this.posUp[i][0], this.posUp[i][1], this.wItem, this.wItem, 1, 3);
			bool flag = ScreenUpgrade.mItemUpgrade[i] == null || ScreenUpgrade.mItemUpgrade[i].isRemove;
			if (!flag)
			{
				ScreenUpgrade.mItemUpgrade[i].paintColor(g, this.posUp[i][0] + this.wItem / 2, this.posUp[i][1] + this.wItem / 2, this.wItem - 1);
				bool flag2 = this.typeRebuild == 20;
				if (flag2)
				{
					bool isPaint = ScreenUpgrade.mItemUpgrade[i].isPaint;
					if (isPaint)
					{
						ScreenUpgrade.mItemUpgrade[i].paintAllItem_Num1(g, this.posUp[i][0] + this.wItem / 2, this.posUp[i][1] + this.wItem / 2, this.wItem, 0, ScreenUpgrade.mItemUpgrade[i].colorName, ScreenUpgrade.mItemUpgrade[i].numPotion);
					}
				}
				else
				{
					ScreenUpgrade.mItemUpgrade[i].paintAllItem(g, this.posUp[i][0] + this.wItem / 2, this.posUp[i][1] + this.wItem / 2, this.wItem, 0, ScreenUpgrade.mItemUpgrade[i].colorName);
				}
			}
		}
		this.paintRectPlus(g);
	}

	// Token: 0x06000DDE RID: 3550 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void paintRectPlus(mGraphics g)
	{
	}

	// Token: 0x06000DDF RID: 3551 RVA: 0x0010CBC4 File Offset: 0x0010ADC4
	public void paintEff(mGraphics g, int level)
	{
		for (int i = 0; i < this.vecEff.size(); i++)
		{
			MainEffect mainEffect = (MainEffect)this.vecEff.elementAt(i);
			bool flag = level == 0 && mainEffect.levelPaint > -1;
			if (flag)
			{
				mainEffect.paint(g);
			}
			else
			{
				bool flag2 = mainEffect.levelPaint == -1;
				if (flag2)
				{
					mainEffect.paint(g);
				}
			}
		}
	}

	// Token: 0x06000DE0 RID: 3552 RVA: 0x0010CC38 File Offset: 0x0010AE38
	public virtual void paintIconUpgrade(mGraphics g, int x, int y, MainItem item)
	{
		for (int i = 0; i < ScreenUpgrade.mItemUpgrade.Length - 2; i++)
		{
			bool flag = ScreenUpgrade.mItemUpgrade[i] != null && ScreenUpgrade.mItemUpgrade[i].ID == item.ID && ScreenUpgrade.mItemUpgrade[i].typeObject == item.typeObject;
			if (flag)
			{
				g.drawImage(AvMain.imgcheck, x, y, mGraphics.BOTTOM | mGraphics.LEFT);
			}
		}
	}

	// Token: 0x06000DE1 RID: 3553 RVA: 0x0010CCB8 File Offset: 0x0010AEB8
	public virtual void paintInven(mGraphics g)
	{
		g.setClip(this.xInven - 1, this.yInven + 1, this.wInven + 2, this.hInven - 1);
		g.saveCanvas();
		g.ClipRec(this.xInven - 1, this.yInven + 1, this.wInven + 2, this.hInven - 1);
		g.translate(this.xInven, this.yInven);
		g.translate(0, -this.list.cmx);
		for (int i = 0; i < this.vecInventory.size(); i++)
		{
			MainItem mainItem = (MainItem)this.vecInventory.elementAt(i);
			bool flag = mainItem.typeObject == 3;
			if (flag)
			{
				mainItem.paintColor(g, i % this.maxNumItemW * this.wItem + this.wItem / 2, i / this.maxNumItemW * this.wItem + this.wItem / 2, this.wItem);
			}
			mainItem.paint(g, i % this.maxNumItemW * this.wItem + this.wItem / 2, i / this.maxNumItemW * this.wItem + this.wItem / 2, this.wItem);
			this.paintIconUpgrade(g, i % this.maxNumItemW * this.wItem + 3, i / this.maxNumItemW * this.wItem + this.wItem - 2, mainItem);
			this.paintlockTrade(g, mainItem, i % this.maxNumItemW * this.wItem + this.wItem / 2, i / this.maxNumItemW * this.wItem + this.wItem / 2);
			this.paintlockShow(g, mainItem, i % this.maxNumItemW * this.wItem + this.wItem / 2, i / this.maxNumItemW * this.wItem + this.wItem / 2);
			bool flag2 = this.IdSelect == i && this.indexAreaSellect == 0;
			if (flag2)
			{
				g.setColor(16777215);
				g.drawRect(i % this.maxNumItemW * this.wItem + 1, i / this.maxNumItemW * this.wItem + 1, this.wItem - 2, this.wItem - 2);
				bool flag3 = !GameCanvas.isSmallScreen;
				if (flag3)
				{
					g.drawRect(i % this.maxNumItemW * this.wItem + 2, i / this.maxNumItemW * this.wItem + 2, this.wItem - 4, this.wItem - 4);
				}
			}
		}
		bool flag4 = Player.maxInventory % this.maxNumItemW != 0;
		if (flag4)
		{
			for (int j = Player.maxInventory; j < Player.maxInventory + (this.maxNumItemW - Player.maxInventory % this.maxNumItemW); j++)
			{
				g.drawRegion(AvMain.imgDelay, 0, 0, this.wItem - 1, this.wItem - 1, 0, (float)(j % this.maxNumItemW * this.wItem + 1), (float)(j / this.maxNumItemW * this.wItem + 1), 0);
			}
		}
		g.setColor(14075832);
		for (int k = 0; k < this.maxNumItemW - 1; k++)
		{
			g.fillRect(this.wItem + k * this.wItem, 1, 1, this.wItem * ((Player.maxInventory - 1) / this.maxNumItemW + 1));
		}
		for (int l = 0; l <= (Player.maxInventory - 1) / this.maxNumItemW + 1; l++)
		{
			g.fillRect(1, l * this.wItem, this.wInven - 1, 1);
		}
		mGraphics.resetTransAndroid(g);
		g.restoreCanvas();
	}

	// Token: 0x06000DE2 RID: 3554 RVA: 0x0010D094 File Offset: 0x0010B294
	public virtual void paintlockShow(mGraphics g, MainItem item, int x, int y)
	{
		bool flag = false;
		bool flag2 = this.typeShowItem == 1;
		if (flag2)
		{
			bool flag3 = item.typeObject == -8;
			if (flag3)
			{
				flag = false;
			}
			else
			{
				bool flag4 = item.typeObject != 4 || item.ID < 44 || (item.ID > 79 && item.ID < 221) || (item.ID > 226 && item.ID < 241) || (item.ID > 270 && item.ID < 362) || (item.ID > 373 && item.ID < 493) || item.ID > 517;
				if (flag4)
				{
					flag = true;
				}
			}
		}
		else
		{
			bool flag5 = this.typeShowItem == 2;
			if (flag5)
			{
				bool flag6 = item.typeObject == -8;
				if (flag6)
				{
					flag = false;
				}
				else
				{
					bool flag7 = item.typeObject == 4;
					if (flag7)
					{
						bool flag8 = item.ID < 44 || (item.ID > 79 && item.ID < 221) || (item.ID > 226 && item.ID < 241) || (item.ID > 270 && item.ID < 362 && item.ID != 324 && item.ID != 325 && item.ID != 326) || item.ID > 373;
						if (flag8)
						{
							flag = true;
						}
					}
					else
					{
						bool flag9 = item.typeObject != 3;
						if (flag9)
						{
							flag = true;
						}
					}
				}
			}
			else
			{
				bool flag10 = this.typeShowItem == 3;
				if (flag10)
				{
					bool flag11 = item.typeObject == -8;
					if (flag11)
					{
						flag = false;
					}
					else
					{
						bool flag12 = item.typeObject != 3;
						if (flag12)
						{
							flag = true;
						}
					}
				}
				else
				{
					bool flag13 = this.typeShowItem == 4;
					if (flag13)
					{
						bool flag14 = item.typeObject != 3 && (item.typeObject != 4 || (item.ID != 323 && item.ID != 339));
						if (flag14)
						{
							flag = true;
						}
					}
					else
					{
						bool flag15 = this.typeShowItem == 5 && item.typeObject != 3 && (item.typeObject != 4 || item.ID != 457);
						if (flag15)
						{
							flag = true;
						}
					}
				}
			}
		}
		bool flag16 = flag;
		if (flag16)
		{
			g.drawRegion(AvMain.imgDelay, 0, 0, this.wItem, this.wItem, 0, (float)x, (float)y, 3);
		}
	}

	// Token: 0x06000DE3 RID: 3555 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void paintlockTrade(mGraphics g, MainItem item, int x, int y)
	{
	}

	// Token: 0x06000DE4 RID: 3556 RVA: 0x0010D358 File Offset: 0x0010B558
	public override void update()
	{
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.update();
		}
		int cmx = this.list.cmx;
		this.list.moveCamera();
		bool flag2 = this.list.cmx != cmx || this.list.pointerIsDowning;
		if (flag2)
		{
			this.isShowInfo = false;
		}
		else
		{
			bool flag3 = this.itemCur != null;
			if (flag3)
			{
				this.updateShowInfo();
			}
		}
		for (int i = 0; i < this.vecEff.size(); i++)
		{
			MainEffect mainEffect = (MainEffect)this.vecEff.elementAt(i);
			mainEffect.update();
			bool isStop = mainEffect.isStop;
			if (isStop)
			{
				this.vecEff.removeElement(mainEffect);
				i--;
			}
		}
		bool flag4 = this.Step != 0;
		if (flag4)
		{
			bool flag5 = this.frameEff == 0 && CRes.random(7) < 3;
			if (flag5)
			{
				this.isRunEff = true;
				this.frameEndEff = (1 + CRes.random(2)) * 3;
			}
			bool flag6 = this.isRunEff;
			if (flag6)
			{
				this.frameEff++;
			}
			bool flag7 = this.frameEff >= this.frameEndEff;
			if (flag7)
			{
				this.isRunEff = false;
				this.frameEff = 0;
			}
		}
		base.update();
		this.setStep();
	}

	// Token: 0x06000DE5 RID: 3557 RVA: 0x0010D4D0 File Offset: 0x0010B6D0
	public void updateShowInfo()
	{
		bool flag = !this.isShowInfo;
		if (flag)
		{
			this.timeShowInfo += 1;
			bool flag2 = this.timeShowInfo >= MainTab.limitTimeShow;
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

	// Token: 0x06000DE6 RID: 3558 RVA: 0x0010D52C File Offset: 0x0010B72C
	public virtual void setPosInfo()
	{
		this.setPosInfo(this.itemCur, this.xInven, this.yInven + (this.IdSelect / this.maxNumItemW + 1) * this.wItem - this.list.cmx + 4);
	}

	// Token: 0x06000DE7 RID: 3559 RVA: 0x0010D578 File Offset: 0x0010B778
	public void setPosInfo(MainItem item, int xbe, int ybe)
	{
		int num = 100;
		int num2 = 50;
		bool flag = item != null;
		if (flag)
		{
			num = item.wInfo;
			num2 = item.hInfo;
		}
		this.xInfo = xbe - num / 2;
		bool flag2 = this.xInfo + num > MotherCanvas.w - 8;
		if (flag2)
		{
			this.xInfo = MotherCanvas.w - num - 8;
		}
		bool flag3 = this.xInfo < 8;
		if (flag3)
		{
			this.xInfo = 8;
		}
		this.yInfo = ybe;
		bool flag4 = this.yInfo + num2 > MotherCanvas.h - GameCanvas.hCommand - 8;
		if (flag4)
		{
			this.yInfo = MotherCanvas.h - GameCanvas.hCommand - num2 - 8;
		}
		bool flag5 = this.yInfo < 8;
		if (flag5)
		{
			this.yInfo = 8;
		}
	}

	// Token: 0x06000DE8 RID: 3560 RVA: 0x0000BD54 File Offset: 0x00009F54
	public void paintSuper(mGraphics g)
	{
		base.paint(g);
	}

	// Token: 0x06000DE9 RID: 3561 RVA: 0x0010D640 File Offset: 0x0010B840
	public override void updatekey()
	{
		bool flag = this.Step != 0;
		if (!flag)
		{
			bool flag2 = false;
			bool flag3 = GameCanvas.keyMove(0);
			if (flag3)
			{
				this.IdSelect--;
				GameCanvas.ClearkeyMove(0);
				flag2 = true;
			}
			else
			{
				bool flag4 = GameCanvas.keyMove(2);
				if (flag4)
				{
					this.IdSelect++;
					GameCanvas.ClearkeyMove(2);
					flag2 = true;
				}
				else
				{
					bool flag5 = GameCanvas.keyMove(1);
					if (flag5)
					{
						bool flag6 = this.IdSelect >= this.maxNumItemW;
						if (flag6)
						{
							this.IdSelect -= this.maxNumItemW;
						}
						GameCanvas.ClearkeyMove(1);
						flag2 = true;
					}
					else
					{
						bool flag7 = GameCanvas.keyMove(3);
						if (flag7)
						{
							bool flag8 = this.IdSelect < this.vecInventory.size() - this.maxNumItemW;
							if (flag8)
							{
								this.IdSelect += this.maxNumItemW;
							}
							GameCanvas.ClearkeyMove(3);
							flag2 = true;
						}
					}
				}
			}
			bool flag9 = flag2;
			if (flag9)
			{
				this.getItemCurNew();
			}
			base.updatekey();
			this.updatekeyPC();
		}
	}

	// Token: 0x06000DEA RID: 3562 RVA: 0x000092D1 File Offset: 0x000074D1
	public void updatekeySuper()
	{
		base.updatekey();
	}

	// Token: 0x06000DEB RID: 3563 RVA: 0x0010D764 File Offset: 0x0010B964
	public override void updatePointer()
	{
		bool flag = this.Step != 0;
		if (!flag)
		{
			this.list.update_Pos_UP_DOWN();
			bool flag2 = GameCanvas.isPointSelect(this.xInven, this.yInven, this.wInven, this.hInven);
			if (flag2)
			{
				int num = (GameCanvas.px - this.xInven) / this.wItem + (GameCanvas.py - this.yInven + this.list.cmx) / this.wItem * this.maxNumItemW;
				int num2 = this.vecInventory.size();
				bool flag3 = num >= 0 && num < num2;
				if (flag3)
				{
					GameCanvas.isPointerSelect = false;
					bool flag4 = num == this.IdSelect;
					if (flag4)
					{
						bool flag5 = this.itemCur != null && (this.itemCur.typeObject == 3 || (this.itemCur.typeObject == 7 && (this.itemCur.getStar() || this.itemCur.typeMaterial == 3 || this.itemCur.typeMaterial == 7)) || (this.itemCur.typeObject == 4 && (this.itemCur.ID == 457 || this.itemCur.ID == 323 || this.itemCur.ID == 339))) && this.cmdBovao != null;
						if (flag5)
						{
							this.cmdBovao.perform();
						}
					}
					else
					{
						this.isShowInfo = false;
						this.IdSelect = num;
						this.setPosCmd(this.getMenuActionItem());
					}
				}
				else
				{
					this.isShowInfo = false;
					this.IdSelect = -1;
					this.setPosCmd(null);
				}
			}
			bool flag6 = this.vecCmd != null;
			if (flag6)
			{
				for (int i = 0; i < this.vecCmd.size(); i++)
				{
					iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
					iCommand.updatePointer();
				}
			}
			base.updatePointer();
		}
	}

	// Token: 0x06000DEC RID: 3564 RVA: 0x0010D974 File Offset: 0x0010BB74
	public virtual void getItemCurNew()
	{
		this.isShowInfo = false;
		this.IdSelect = AvMain.resetSelect(this.IdSelect, this.vecInventory.size() - 1, false);
		bool flag = GameCanvas.isTouchNoOrPC();
		if (flag)
		{
			this.list.setToX((this.IdSelect / this.maxNumItemW + 1) * this.wItem - this.h / 2);
		}
		bool flag2 = this.IdSelect >= 0;
		if (flag2)
		{
			this.setPosCmd(this.getMenuActionItem());
		}
	}

	// Token: 0x06000DED RID: 3565 RVA: 0x0010DA00 File Offset: 0x0010BC00
	public virtual mVector getMenuActionItem()
	{
		mVector result = null;
		MainItem mainItem = (MainItem)this.vecInventory.elementAt(this.IdSelect);
		bool flag = mainItem != null;
		if (flag)
		{
			bool flag2 = this.typeRebuild == 20;
			if (flag2)
			{
				this.itemCur = mainItem;
				return null;
			}
			this.itemCur = mainItem;
			this.cmdBovao.caption = T.bovao;
			this.cmdBovao.subIndex = 1;
			bool flag3 = this.isGetItemUpgrade(this.itemCur.ID, this.itemCur.typeObject);
			if (flag3)
			{
				this.cmdBovao.caption = T.layra;
				this.cmdBovao.subIndex = 0;
			}
		}
		bool flag4 = this.itemCur != null;
		if (flag4)
		{
			result = this.itemCur.getActionUpgrade();
		}
		bool flag5 = this.typeRebuild == 15 || this.typeRebuild == 18;
		if (flag5)
		{
			this.setRotCap();
		}
		return result;
	}

	// Token: 0x06000DEE RID: 3566 RVA: 0x0010DB00 File Offset: 0x0010BD00
	private void setRotCap()
	{
		bool flag = ScreenUpgrade.mItemUpgrade[0] != null && (ScreenUpgrade.mItemUpgrade[0].LvUpgrade == 10 || (this.typeRebuild == 18 && ScreenUpgrade.mItemUpgrade[0].LvUpgrade == 0));
		if (flag)
		{
			ScreenUpgrade.valueRotCap = 0;
		}
		else
		{
			bool flag2 = this.typeRebuild == 18;
			if (flag2)
			{
				ScreenUpgrade.valueRotCap = this.valueTileRotCap - this.valueBaoHiem;
				bool flag3 = ScreenUpgrade.mItemUpgrade[3] != null;
				if (flag3)
				{
					ScreenUpgrade.valueRotCap -= 20;
				}
			}
			else
			{
				int num = 0;
				bool flag4 = ScreenUpgrade.mItemUpgrade[2] != null;
				if (flag4)
				{
					num = (int)(ScreenUpgrade.mItemUpgrade[2].numPotion * 15);
				}
				bool flag5 = ScreenUpgrade.mItemUpgrade[3] != null;
				if (flag5)
				{
					num += 20;
				}
				bool flag6 = num > 80;
				if (flag6)
				{
					num = 80;
				}
				ScreenUpgrade.valueRotCap = 80 - num;
			}
		}
	}

	// Token: 0x06000DEF RID: 3567 RVA: 0x0010DBF0 File Offset: 0x0010BDF0
	public virtual void setPosCmd(mVector vec)
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
						cmd = (this.menuCMD = AvMain.setPosCMD(cmd, 1));
					}
					bool flag3 = i == 1;
					if (flag3)
					{
						iCommand iCommand = this.backCMD = AvMain.setPosCMD(cmd, 2);
					}
				}
			}
			else
			{
				for (int j = 0; j < vec.size(); j++)
				{
					iCommand iCommand2 = (iCommand)vec.elementAt(j);
					bool flag4 = j == 0;
					if (flag4)
					{
						this.center = iCommand2;
					}
					bool flag5 = j == 1;
					if (flag5)
					{
						this.left = iCommand2;
					}
				}
			}
		}
		bool isTouch2 = GameCanvas.isTouch;
		if (isTouch2)
		{
			bool flag6 = this.typeRebuild == 20;
			if (flag6)
			{
				this.vecCmd.addElement(this.cmdClose);
				this.left = this.cmdUpgrade;
				bool flag7 = GameCanvas.isTouchNoOrPC();
				if (flag7)
				{
					this.backCMD = this.cmdClose;
					this.okCMD = this.cmdUpgrade;
				}
			}
			else
			{
				bool flag8 = this.typeRebuild == 18 || this.typeRebuild == 22;
				if (flag8)
				{
					this.vecCmd.addElement(this.cmdClose);
					this.right = this.cmdUpgrade;
					bool flag9 = GameCanvas.isTouchNoOrPC();
					if (flag9)
					{
						this.backCMD = this.cmdClose;
						this.okCMD = this.cmdUpgrade;
					}
				}
				else
				{
					this.vecCmd.addElement(this.cmdClose);
					this.vecCmd.addElement(this.cmdUpgrade);
					iCommand cmdShopMore = this.getCmdShopMore();
					bool flag10 = cmdShopMore != null;
					if (flag10)
					{
						this.vecCmd.addElement(cmdShopMore);
					}
					bool flag11 = GameCanvas.isTouchNoOrPC();
					if (flag11)
					{
						this.backCMD = this.cmdClose;
						this.okCMD = this.cmdUpgrade;
					}
				}
			}
		}
		else
		{
			bool flag12 = this.typeRebuild == 20;
			if (flag12)
			{
				this.left = this.cmdUpgrade;
			}
			else
			{
				this.right = this.cmdMenu;
				this.left = this.cmdUpgrade;
			}
		}
	}

	// Token: 0x06000DF0 RID: 3568 RVA: 0x0010DE78 File Offset: 0x0010C078
	public virtual iCommand getCmdShopMore()
	{
		return this.cmdShop;
	}

	// Token: 0x06000DF1 RID: 3569 RVA: 0x0010DE90 File Offset: 0x0010C090
	public virtual bool isGetItemUpgrade(short Id, sbyte cat)
	{
		for (int i = 1; i < ScreenUpgrade.mItemUpgrade.Length; i++)
		{
			bool flag = ScreenUpgrade.mItemUpgrade[i] != null && ScreenUpgrade.mItemUpgrade[i].ID == Id && ScreenUpgrade.mItemUpgrade[i].typeObject == cat;
			if (flag)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000DF2 RID: 3570 RVA: 0x0010DEF0 File Offset: 0x0010C0F0
	public virtual void updateNewUpgrade()
	{
		this.isShowInfo = false;
		this.getItemCurNew();
		bool flag = ScreenUpgrade.mItemUpgrade[1] != null;
		if (flag)
		{
			MainItem itemVec = MainItem.getItemVec(7, ScreenUpgrade.mItemUpgrade[1].ID, this.vecInventory);
			bool flag2 = itemVec != null && itemVec.numPotion > 0;
			if (flag2)
			{
				GlobalService.gI().Upgrade_Item(5, itemVec.ID, 1);
			}
		}
		bool flag3 = ScreenUpgrade.mItemUpgrade[2] != null;
		if (flag3)
		{
			MainItem itemVec2 = MainItem.getItemVec(7, ScreenUpgrade.mItemUpgrade[2].ID, this.vecInventory);
			bool flag4 = itemVec2 != null && itemVec2.numPotion > 0;
			if (flag4)
			{
				GlobalService.gI().Upgrade_Item(6, itemVec2.ID, 1);
			}
		}
	}

	// Token: 0x06000DF3 RID: 3571 RVA: 0x0010DFB4 File Offset: 0x0010C1B4
	public virtual void setDataUpgrade()
	{
		bool flag = ScreenUpgrade.mItemUpgrade[0] == null;
		if (!flag)
		{
			MainDataUpgrade mainDataUpgrade = ScreenUpgrade.mTemMaterialUpgrade[(int)ScreenUpgrade.mItemUpgrade[0].LvUpgrade];
			for (int i = 3; i < ScreenUpgrade.mItemUpgrade.Length; i++)
			{
				ScreenUpgrade.mItemUpgrade[i] = null;
			}
			int num = 3;
			for (int j = 0; j < mainDataUpgrade.mMaterial.Length; j++)
			{
				MainMaterial mainMaterial = (MainMaterial)MainItem.hashMaterialTem.get(string.Empty + mainDataUpgrade.mMaterial[j][0].ToString());
				bool flag2 = (short)ScreenUpgrade.mItemUpgrade[0].colorName == mainDataUpgrade.mMaterial[j][2] || mainDataUpgrade.mMaterial[j][2] == -1;
				if (flag2)
				{
					sbyte color = 5;
					MainItem itemVec = MainItem.getItemVec(7, mainDataUpgrade.mMaterial[j][0], this.vecInventory);
					bool flag3 = itemVec == null || itemVec.numPotion < mainDataUpgrade.mMaterial[j][1];
					if (flag3)
					{
						color = 6;
					}
					MainItem mainItem = new MainItem(7, mainMaterial.ID, mainMaterial.idIcon, mainDataUpgrade.mMaterial[j][1], color, 0);
					ScreenUpgrade.mItemUpgrade[num] = mainItem;
					num++;
				}
			}
		}
	}

	// Token: 0x06000DF4 RID: 3572 RVA: 0x0010E108 File Offset: 0x0010C308
	public virtual void setStep()
	{
		bool flag = this.Step == 1 || this.Step == 2;
		if (flag)
		{
			bool flag2 = this.tickStep % 15 == 0;
			if (flag2)
			{
				mSound.playSound(27, mSound.volumeSound);
			}
			this.tickStep++;
			this.updateEff();
			bool flag3 = this.tickStep % 5 != 0;
			if (!flag3)
			{
				bool flag4 = this.indexStep < ScreenUpgrade.mItemUpgrade.Length;
				if (flag4)
				{
					bool flag5 = this.tickStep > 50;
					if (flag5)
					{
						this.indexStep = ScreenUpgrade.mItemUpgrade.Length;
					}
					bool flag6 = this.typeRebuild == 20;
					if (flag6)
					{
						for (int i = this.indexStep; i < ScreenUpgrade.mItemUpgrade.Length - 1; i++)
						{
							bool flag7 = ScreenUpgrade.mItemUpgrade[i] != null;
							if (flag7)
							{
								this.createEff(75, 0, this.posUp[i][0] + this.wItem / 2, this.posUp[i][1] + this.wItem / 2, this.posUp[ScreenUpgrade.mItemUpgrade.Length - 1][0] + this.wItem / 2, this.posUp[ScreenUpgrade.mItemUpgrade.Length - 1][1] + this.wItem / 2);
								ScreenUpgrade.mItemUpgrade[i].isPaint = false;
								this.indexStep = i + 1;
								this.tickStop = this.tickStep + 11 + ((this.w - this.lech * 3 - this.wInven) / 2 - 15) / 5;
								break;
							}
						}
					}
					else
					{
						for (int j = this.indexStep; j < ScreenUpgrade.mItemUpgrade.Length; j++)
						{
							bool flag8 = ScreenUpgrade.mItemUpgrade[j] != null;
							if (flag8)
							{
								this.createEff(75, 0, this.posUp[j][0] + this.wItem / 2, this.posUp[j][1] + this.wItem / 2, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2);
								ScreenUpgrade.mItemUpgrade[j].isRemove = true;
								this.indexStep = j + 1;
								this.tickStop = this.tickStep + 11 + ((this.w - this.lech * 3 - this.wInven) / 2 - 15) / 5;
								break;
							}
						}
					}
				}
				else
				{
					bool flag9 = this.tickStep < this.tickStop;
					if (!flag9)
					{
						bool flag10 = this.Step == 1;
						if (flag10)
						{
							mSound.playSound(28, mSound.volumeSound);
							int subtype = 0;
							bool flag11 = GameCanvas.language == 1;
							if (flag11)
							{
								subtype = 2;
							}
							bool flag12 = this.typeRebuild == 20;
							if (flag12)
							{
								this.createEff(79, subtype, this.posUp[this.posUp.Length - 1][0] + this.wItem / 2, this.posUp[this.posUp.Length - 1][1] + this.wItem / 2, this.posUp[this.posUp.Length - 1][0] + this.wItem / 2, this.posUp[this.posUp.Length - 1][1] + this.wItem / 2);
								this.createEff(76, 0, this.posUp[this.posUp.Length - 1][0] + this.wItem / 2, this.posUp[this.posUp.Length - 1][1] + this.wItem / 2, this.posUp[this.posUp.Length - 1][0] + this.wItem / 2, this.posUp[this.posUp.Length - 1][1] + this.wItem / 2);
							}
							else
							{
								this.createEff(79, subtype, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2);
								this.createEff(76, 0, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2);
							}
							this.createEff(53, 0, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2);
						}
						else
						{
							bool flag13 = this.Step == 2;
							if (flag13)
							{
								mSound.playSound(29, mSound.volumeSound);
								int subtype2 = 1;
								bool flag14 = GameCanvas.language == 1;
								if (flag14)
								{
									subtype2 = 3;
								}
								bool flag15 = this.typeRebuild == 20;
								if (flag15)
								{
									this.createEff(79, subtype2, this.posUp[this.posUp.Length - 1][0] + this.wItem / 2, this.posUp[this.posUp.Length - 1][1] + this.wItem / 2, this.posUp[this.posUp.Length - 1][0] + this.wItem / 2, this.posUp[this.posUp.Length - 1][1] + this.wItem / 2);
									this.createEff(77, 0, this.posUp[this.posUp.Length - 1][0] + this.wItem / 2, this.posUp[this.posUp.Length - 1][1] + this.wItem / 2, this.posUp[this.posUp.Length - 1][0] + this.wItem / 2, this.posUp[this.posUp.Length - 1][1] + this.wItem / 2);
								}
								else
								{
									this.createEff(79, subtype2, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2);
									this.createEff(77, 0, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2);
								}
							}
						}
						this.Step = 3;
						this.tickStep = 0;
						this.tickStop = 20;
					}
				}
			}
		}
		else
		{
			bool flag16 = this.Step != 3;
			if (!flag16)
			{
				this.tickStep++;
				bool flag17 = this.tickStep < this.tickStop;
				if (!flag17)
				{
					this.Step = 0;
					this.tickStop = 0;
					this.tickStep = 0;
					this.indexStep = 1;
					GameCanvas.Start_Normal_Only_CmdClose_DiaLog(this.showServer);
					bool flag18 = this.typeRebuild == 20;
					if (flag18)
					{
						this.indexStep = 0;
						for (int k = 0; k < ScreenUpgrade.mItemUpgrade.Length - 1; k++)
						{
							MainItem itemVec = MainItem.getItemVec(ScreenUpgrade.mItemUpgrade[k].typeObject, ScreenUpgrade.mItemUpgrade[k].ID, this.vecInventory);
							bool flag19 = itemVec != null;
							if (flag19)
							{
								ScreenUpgrade.mItemUpgrade[k].numPotion = itemVec.numPotion;
							}
							else
							{
								ScreenUpgrade.mItemUpgrade[k].numPotion = 0;
							}
							ScreenUpgrade.mItemUpgrade[k].isPaint = true;
						}
					}
					else
					{
						bool flag20 = this.typeRebuild == 18;
						if (flag20)
						{
							GlobalService.gI().Upgrade_Dial(4, ScreenUpgrade.mItemUpgrade[0].ID, 0, 0);
							for (int l = 0; l < ScreenUpgrade.mItemUpgrade.Length; l++)
							{
								ScreenUpgrade.mItemUpgrade[l] = null;
							}
						}
						else
						{
							bool flag21 = this.typeRebuild == 15;
							if (flag21)
							{
								GlobalService.gI().Upgrade_Super_Item(4, ScreenUpgrade.mItemUpgrade[0].ID, 0, 0);
								for (int m = 0; m < ScreenUpgrade.mItemUpgrade.Length; m++)
								{
									ScreenUpgrade.mItemUpgrade[m] = null;
								}
							}
							else
							{
								bool flag22 = this.typeRebuild != 12;
								if (flag22)
								{
									GlobalService.gI().Upgrade_Item(4, ScreenUpgrade.mItemUpgrade[0].ID, 0);
									this.updateNewUpgrade();
								}
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x06000DF5 RID: 3573 RVA: 0x0010EA14 File Offset: 0x0010CC14
	public void updateEff()
	{
		bool flag = this.typeRebuild == 20;
		if (!flag)
		{
			bool flag2 = this.typeRebuild == 15 || this.typeRebuild == 18 || this.typeRebuild == 22;
			if (flag2)
			{
				bool flag3 = GameCanvas.gameTick % 15 == 0 || GameCanvas.gameTick % 15 == 5;
				if (flag3)
				{
					this.createEff(154, 0, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2);
				}
			}
			else
			{
				bool flag4 = GameCanvas.gameTick % 15 == 0;
				if (flag4)
				{
					for (int i = 1; i < this.posUp.Length; i++)
					{
						bool flag5 = i == this.posUp.Length - 1;
						if (flag5)
						{
							this.createEff(73, i - 1, this.posUp[i][0] + this.wItem / 2, this.posUp[i][1] + this.wItem / 2, this.posUp[1][0] + this.wItem / 2, this.posUp[1][1] + this.wItem / 2);
						}
						else
						{
							this.createEff(73, i - 1, this.posUp[i][0] + this.wItem / 2, this.posUp[i][1] + this.wItem / 2, this.posUp[i + 1][0] + this.wItem / 2, this.posUp[i + 1][1] + this.wItem / 2);
						}
					}
				}
				bool flag6 = GameCanvas.gameTick % 15 != 5;
				if (!flag6)
				{
					for (int j = 1; j < this.posUp.Length; j++)
					{
						bool flag7 = j == this.posUp.Length - 1;
						if (flag7)
						{
							this.createEff(74, j - 1, this.posUp[j][0] + this.wItem / 2, this.posUp[j][1] + this.wItem / 2, this.posUp[1][0] + this.wItem / 2, this.posUp[1][1] + this.wItem / 2);
						}
						else
						{
							this.createEff(74, j - 1, this.posUp[j][0] + this.wItem / 2, this.posUp[j][1] + this.wItem / 2, this.posUp[j + 1][0] + this.wItem / 2, this.posUp[j + 1][1] + this.wItem / 2);
						}
					}
				}
			}
		}
	}

	// Token: 0x06000DF6 RID: 3574 RVA: 0x0010ECFC File Offset: 0x0010CEFC
	public void createEff(short type, int subtype, int x, int y, int xto, int yto)
	{
		Effect_End o = new Effect_End(type, (sbyte)subtype, x, y, xto, yto, 0, null);
		this.vecEff.addElement(o);
	}

	// Token: 0x06000DF7 RID: 3575 RVA: 0x0010ED2C File Offset: 0x0010CF2C
	public void createEff(short type, int subtype, int x, int y, int time)
	{
		Effect_End o = new Effect_End(type, (sbyte)subtype, x, y, time, 0, null);
		this.vecEff.addElement(o);
	}

	// Token: 0x06000DF8 RID: 3576 RVA: 0x0010ED58 File Offset: 0x0010CF58
	public override bool keyBack()
	{
		bool flag = !base.keyBack() && this.cmdClose != null;
		if (flag)
		{
			this.cmdClose.perform();
		}
		return false;
	}

	// Token: 0x06000DF9 RID: 3577 RVA: 0x0010ED94 File Offset: 0x0010CF94
	public void updateKHAM()
	{
		bool flag = this.Step == 1 || this.Step == 3;
		if (flag)
		{
			this.tickStep++;
			bool flag2 = this.tickStop == 0;
			if (flag2)
			{
				mSound.playSound(26, mSound.volumeSound);
				mSound.playSound(27, mSound.volumeSound);
				this.createEff(30, 0, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2, 1000);
				this.createEff(75, 0, this.posUp[1][0] + this.wItem / 2, this.posUp[1][1] + this.wItem / 2, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2);
				ScreenUpgrade.mItemUpgrade[1] = null;
				this.tickStop = this.tickStep + 11 + (this.w - this.lech * 3 - this.wInven) / 6 * 4 / 5;
			}
			else
			{
				bool flag3 = this.tickStep < this.tickStop;
				if (!flag3)
				{
					bool flag4 = this.typeRebuild == 8 || this.typeRebuild == 9 || this.typeRebuild == 13;
					if (flag4)
					{
						bool flag5 = this.Step == 1;
						if (flag5)
						{
							mSound.playSound(28, mSound.volumeSound);
							int subtype = 0;
							bool flag6 = GameCanvas.language == 1;
							if (flag6)
							{
								subtype = 2;
							}
							this.createEff(79, subtype, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2);
							this.createEff(76, 0, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2);
							this.createEff(53, 0, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2);
						}
						else
						{
							bool flag7 = this.Step == 3;
							if (flag7)
							{
								mSound.playSound(29, mSound.volumeSound);
								int subtype2 = 1;
								bool flag8 = GameCanvas.language == 1;
								if (flag8)
								{
									subtype2 = 3;
								}
								this.createEff(79, subtype2, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2);
								this.createEff(77, 0, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2);
							}
						}
					}
					else
					{
						mSound.playSound(26, mSound.volumeSound);
						this.createEff(53, 0, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2);
					}
					this.Step = 2;
					this.tickStep = 0;
					this.tickStop = 0;
				}
			}
		}
		else
		{
			bool flag9 = this.Step != 2 && this.Step != 4;
			if (!flag9)
			{
				this.tickStep++;
				bool flag10 = this.tickStep < 20;
				if (!flag10)
				{
					this.Step = 0;
					this.tickStep = 0;
					this.tickStop = 0;
					GameCanvas.Start_Normal_Only_CmdClose_DiaLog(this.showServer);
					bool flag11 = this.typeRebuild == 8 || this.typeRebuild == 13;
					if (flag11)
					{
						ScreenUpgrade.mItemUpgrade[0] = null;
						ScreenUpgrade.mItemUpgrade[1] = null;
					}
					else
					{
						bool flag12 = this.typeRebuild == 9;
						if (flag12)
						{
							this.updateNewUpgrade();
							bool flag13 = ScreenUpgrade.mItemUpgrade[0] != null;
							if (flag13)
							{
								GlobalService.gI().Devil_Upgrade(9, ScreenUpgrade.mItemUpgrade[0].ID, ScreenUpgrade.mItemUpgrade[0].typeObject, 1);
							}
							ScreenUpgrade.mItemUpgrade[0] = null;
							ScreenUpgrade.mItemUpgrade[1] = null;
						}
						else
						{
							bool flag14 = ScreenUpgrade.mItemUpgrade[0] == null;
							if (!flag14)
							{
								MainItem itemVec = MainItem.getItemVec(ScreenUpgrade.mItemUpgrade[0].typeObject, ScreenUpgrade.mItemUpgrade[0].ID, this.vecInventory);
								bool flag15 = this.typeRebuild == 10 || this.typeRebuild == 11;
								if (flag15)
								{
									bool flag16 = itemVec != null && this.Step == 4;
									if (flag16)
									{
										GlobalService.gI().rebuild_Item(this.typeRebuild, 1, ScreenUpgrade.mItemUpgrade[0].ID, ScreenUpgrade.mItemUpgrade[0].typeObject, 1);
									}
									else
									{
										ScreenUpgrade.mItemUpgrade[0] = null;
									}
								}
								else
								{
									bool flag17 = itemVec != null && itemVec.mDaKham != null && (int)itemVec.numLoKham > itemVec.mDaKham.Length;
									if (flag17)
									{
										GlobalService.gI().rebuild_Item(this.typeRebuild, 1, ScreenUpgrade.mItemUpgrade[0].ID, ScreenUpgrade.mItemUpgrade[0].typeObject, 1);
									}
									else
									{
										ScreenUpgrade.mItemUpgrade[0] = null;
									}
								}
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x06000DFA RID: 3578 RVA: 0x0000AEA3 File Offset: 0x000090A3
	public void updatePointerSuper()
	{
		base.updatePointer();
	}

	// Token: 0x06000DFB RID: 3579 RVA: 0x0000BD5F File Offset: 0x00009F5F
	public void setInfo_money(int valueTile, int valueMonney_1, int valueMonney_2, int valueMonney_3)
	{
		ScreenUpgrade.valueTile = valueTile;
		ScreenUpgrade.valueMonney_1 = valueMonney_1;
		ScreenUpgrade.valueMonney_2 = valueMonney_2;
		ScreenUpgrade.valueMonney_3 = valueMonney_3;
	}

	// Token: 0x06000DFC RID: 3580 RVA: 0x0000BD7B File Offset: 0x00009F7B
	public void setInfo(MainItem[] listItem)
	{
		ScreenUpgrade.mItemUpgrade = listItem;
		this.indexStep = 0;
	}

	// Token: 0x04001531 RID: 5425
	public const sbyte SHOWITEM_ONLY_DA_KHAM = 1;

	// Token: 0x04001532 RID: 5426
	public const sbyte SHOWITEM_ONLY_DA_KHAM_ITEM = 2;

	// Token: 0x04001533 RID: 5427
	public const sbyte SHOWITEM_ONLY_ITEM = 3;

	// Token: 0x04001534 RID: 5428
	public const sbyte SHOWITEM_ONLY_ITEM_AND_BUA = 4;

	// Token: 0x04001535 RID: 5429
	public const sbyte SHOWITEM_ONLY_ITEM_AND_HAMMER_DIAL = 5;

	// Token: 0x04001536 RID: 5430
	public int w;

	// Token: 0x04001537 RID: 5431
	public int h;

	// Token: 0x04001538 RID: 5432
	public int wItem;

	// Token: 0x04001539 RID: 5433
	public int x;

	// Token: 0x0400153A RID: 5434
	public int y;

	// Token: 0x0400153B RID: 5435
	public int lech;

	// Token: 0x0400153C RID: 5436
	public int IdSelect;

	// Token: 0x0400153D RID: 5437
	public int xInven;

	// Token: 0x0400153E RID: 5438
	public int yInven;

	// Token: 0x0400153F RID: 5439
	public int wInven;

	// Token: 0x04001540 RID: 5440
	public int hInven;

	// Token: 0x04001541 RID: 5441
	public int maxNumItemW;

	// Token: 0x04001542 RID: 5442
	public int xInfo;

	// Token: 0x04001543 RID: 5443
	public int yInfo;

	// Token: 0x04001544 RID: 5444
	public int xMid;

	// Token: 0x04001545 RID: 5445
	public int yMid;

	// Token: 0x04001546 RID: 5446
	public int[][] posUp;

	// Token: 0x04001547 RID: 5447
	public bool isShowInfo;

	// Token: 0x04001548 RID: 5448
	public ListNew list;

	// Token: 0x04001549 RID: 5449
	public mVector vecCmd = new mVector();

	// Token: 0x0400154A RID: 5450
	public MainItem itemCur;

	// Token: 0x0400154B RID: 5451
	public iCommand cmdBovao;

	// Token: 0x0400154C RID: 5452
	public iCommand cmdLucky;

	// Token: 0x0400154D RID: 5453
	public iCommand cmdClose;

	// Token: 0x0400154E RID: 5454
	public iCommand cmdUpgrade;

	// Token: 0x0400154F RID: 5455
	public iCommand cmdBoVaoAll;

	// Token: 0x04001550 RID: 5456
	public iCommand cmdShop;

	// Token: 0x04001551 RID: 5457
	public iCommand cmdMenu;

	// Token: 0x04001552 RID: 5458
	public iCommand cmdBovaoDasieucap;

	// Token: 0x04001553 RID: 5459
	public static MainItem[] mItemUpgrade;

	// Token: 0x04001554 RID: 5460
	public static MainDataUpgrade[] mTemMaterialUpgrade;

	// Token: 0x04001555 RID: 5461
	public mVector vecEff = new mVector("ScreenUpgrade.vecEff");

	// Token: 0x04001556 RID: 5462
	public string nameScreen = string.Empty;

	// Token: 0x04001557 RID: 5463
	public string showServer = string.Empty;

	// Token: 0x04001558 RID: 5464
	public int Step;

	// Token: 0x04001559 RID: 5465
	public int tickStep;

	// Token: 0x0400155A RID: 5466
	public int indexAreaSellect;

	// Token: 0x0400155B RID: 5467
	public int xTiLe;

	// Token: 0x0400155C RID: 5468
	public sbyte typeRebuild;

	// Token: 0x0400155D RID: 5469
	public static short[] mTileUpdate;

	// Token: 0x0400155E RID: 5470
	public static short[] mTileGhepĐa;

	// Token: 0x0400155F RID: 5471
	public static short[] mTileChuyenHoa;

	// Token: 0x04001560 RID: 5472
	public static sbyte curTypeShop = -1;

	// Token: 0x04001561 RID: 5473
	public FrameImage fraEffUpgrade;

	// Token: 0x04001562 RID: 5474
	public static ScreenUpgrade instance;

	// Token: 0x04001563 RID: 5475
	public sbyte typeShowItem;

	// Token: 0x04001564 RID: 5476
	private InputDialog input;

	// Token: 0x04001565 RID: 5477
	public mVector vecInventory = new mVector();

	// Token: 0x04001566 RID: 5478
	public static int valueLucky = 1;

	// Token: 0x04001567 RID: 5479
	public static int valueRotCap;

	// Token: 0x04001568 RID: 5480
	public int valueBaoHiem;

	// Token: 0x04001569 RID: 5481
	public int valueMayMan;

	// Token: 0x0400156A RID: 5482
	public mImage imghoavan;

	// Token: 0x0400156B RID: 5483
	public mImage imgtron;

	// Token: 0x0400156C RID: 5484
	public int frameEff;

	// Token: 0x0400156D RID: 5485
	public int frameEndEff;

	// Token: 0x0400156E RID: 5486
	private bool isRunEff;

	// Token: 0x0400156F RID: 5487
	public sbyte timeShowInfo;

	// Token: 0x04001570 RID: 5488
	public int indexStep = 1;

	// Token: 0x04001571 RID: 5489
	public int tickStop;

	// Token: 0x04001572 RID: 5490
	public static int valueTile;

	// Token: 0x04001573 RID: 5491
	public int valueTileRotCap;

	// Token: 0x04001574 RID: 5492
	public static int valueMonney_1;

	// Token: 0x04001575 RID: 5493
	public static int valueMonney_2;

	// Token: 0x04001576 RID: 5494
	public static int valueMonney_3;
}
