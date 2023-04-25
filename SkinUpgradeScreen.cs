using System;

// Token: 0x020000EE RID: 238
public class SkinUpgradeScreen : ScreenUpgrade
{
	// Token: 0x06000E3B RID: 3643 RVA: 0x00111B3C File Offset: 0x0010FD3C
	public SkinUpgradeScreen(sbyte typeRebuild, int size, mVector vecSkin1, mVector vecDa1) : base(typeRebuild, size)
	{
		mSystem.outz(string.Concat(new string[]
		{
			"SkinUpgradeScreen type ",
			typeRebuild.ToString(),
			" vecSkin ",
			SkinUpgradeScreen.vecSkin.size().ToString(),
			" vecDa ",
			SkinUpgradeScreen.vecDa.size().ToString()
		}));
		SkinUpgradeScreen.vecSkin = vecSkin1;
		SkinUpgradeScreen.vecDa = vecDa1;
		this.IdSelect = 0;
		this.idSelect2 = -1;
		this.wInven = this.w / 2;
		this.wInven -= this.wInven % this.wItem;
		this.hInven = this.h - this.lech * 3 - 5;
		this.maxNumItemW = this.wInven / this.wItem;
		this.xInven = this.x + this.w / 4 - this.wInven / 2 + 15;
		this.yInven = this.y + this.h / 2 - this.hInven / 2;
		this.yInven2 = this.yInven + this.hInven / 2 + 4;
		this.hInven = this.hInven / 2 - 4;
		int limX = ((SkinUpgradeScreen.vecSkin.size() - 1) / this.maxNumItemW + 1) * this.wItem - this.hInven;
		this.list = new ListNew(this.xInven, this.yInven, this.wInven, this.hInven, 0, 0, limX, true);
		limX = ((SkinUpgradeScreen.vecDa.size() - 1) / this.maxNumItemW + 1) * this.wItem - this.hInven;
		this.listDa = new ListNew(this.xInven, this.yInven2, this.wInven, this.hInven, 0, 0, limX, true);
		this.isShowInfo = false;
		ScreenUpgrade.valueTile = 0;
	}

	// Token: 0x06000E3C RID: 3644 RVA: 0x00111D28 File Offset: 0x0010FF28
	public override void paintInven(mGraphics g)
	{
		g.setClip(this.xInven - 1, this.yInven + 1, this.wInven + 2, this.hInven - 1);
		g.saveCanvas();
		g.ClipRec(this.xInven - 1, this.yInven + 1, this.wInven + 2, this.hInven - 1);
		g.translate(this.xInven, this.yInven);
		g.translate(0, -this.list.cmx);
		for (int i = 0; i < SkinUpgradeScreen.vecSkin.size(); i++)
		{
			MainItem mainItem = (MainItem)SkinUpgradeScreen.vecSkin.elementAt(i);
			bool flag = mainItem.typeObject == 105;
			if (flag)
			{
				mainItem.paintColor(g, i % this.maxNumItemW * this.wItem + this.wItem / 2, i / this.maxNumItemW * this.wItem + this.wItem / 2, this.wItem);
			}
			mainItem.paint(g, i % this.maxNumItemW * this.wItem + this.wItem / 2, i / this.maxNumItemW * this.wItem + this.wItem / 2, this.wItem);
			this.paintIconUpgrade(g, i % this.maxNumItemW * this.wItem + 3, i / this.maxNumItemW * this.wItem + this.wItem - 2, mainItem);
			this.paintlockTrade(g, mainItem, i % this.maxNumItemW * this.wItem + this.wItem / 2, i / this.maxNumItemW * this.wItem + this.wItem / 2);
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
		GameCanvas.resetTrans(g);
		AvMain.paintRect(g, this.xInven, this.yInven2, this.wInven, this.hInven, 0, 3);
		g.setClip(this.xInven - 1, this.yInven2 + 1, this.wInven + 2, this.hInven - 1);
		g.saveCanvas();
		g.ClipRec(this.xInven - 1, this.yInven2 + 1, this.wInven + 2, this.hInven - 1);
		g.translate(this.xInven, this.yInven2);
		g.translate(0, -this.listDa.cmx);
		for (int m = 0; m < SkinUpgradeScreen.vecDa.size(); m++)
		{
			MainItem mainItem2 = (MainItem)SkinUpgradeScreen.vecDa.elementAt(m);
			mainItem2.paint(g, m % this.maxNumItemW * this.wItem + this.wItem / 2, m / this.maxNumItemW * this.wItem + this.wItem / 2, this.wItem);
			this.paintIconUpgrade(g, m % this.maxNumItemW * this.wItem + 3, m / this.maxNumItemW * this.wItem + this.wItem - 2, mainItem2);
			this.paintlockTrade(g, mainItem2, m % this.maxNumItemW * this.wItem + this.wItem / 2, m / this.maxNumItemW * this.wItem + this.wItem / 2);
			bool flag5 = this.idSelect2 == m && this.indexAreaSellect == 0;
			if (flag5)
			{
				g.setColor(16777215);
				g.drawRect(m % this.maxNumItemW * this.wItem + 1, m / this.maxNumItemW * this.wItem + 1, this.wItem - 2, this.wItem - 2);
				bool flag6 = !GameCanvas.isSmallScreen;
				if (flag6)
				{
					g.drawRect(m % this.maxNumItemW * this.wItem + 2, m / this.maxNumItemW * this.wItem + 2, this.wItem - 4, this.wItem - 4);
				}
			}
		}
		bool flag7 = Player.maxInventory % this.maxNumItemW != 0;
		if (flag7)
		{
			for (int n = Player.maxInventory; n < Player.maxInventory + (this.maxNumItemW - Player.maxInventory % this.maxNumItemW); n++)
			{
				g.drawRegion(AvMain.imgDelay, 0, 0, this.wItem - 1, this.wItem - 1, 0, (float)(n % this.maxNumItemW * this.wItem + 1), (float)(n / this.maxNumItemW * this.wItem + 1), 0);
			}
		}
		g.setColor(14075832);
		for (int num = 0; num < this.maxNumItemW - 1; num++)
		{
			g.fillRect(this.wItem + num * this.wItem, 1, 1, this.wItem * ((Player.maxInventory - 1) / this.maxNumItemW + 1));
		}
		for (int num2 = 0; num2 <= (Player.maxInventory - 1) / this.maxNumItemW + 1; num2++)
		{
			g.fillRect(1, num2 * this.wItem, this.wInven - 1, 1);
		}
		mGraphics.resetTransAndroid(g);
		g.restoreCanvas();
		GameCanvas.resetTrans(g);
	}

	// Token: 0x06000E3D RID: 3645 RVA: 0x00112450 File Offset: 0x00110650
	public override void paintTiLe(mGraphics g)
	{
		bool flag = this.valueMayMan > 0 && ScreenUpgrade.mItemUpgrade[5] != null;
		if (flag)
		{
			mFont.tahoma_7b_black.drawString(g, string.Concat(new string[]
			{
				T.tile,
				ScreenUpgrade.valueTile.ToString(),
				"% + ",
				this.valueMayMan.ToString(),
				"%"
			}), this.xTiLe, this.yInven, 0);
		}
		else
		{
			mFont.tahoma_7b_black.drawString(g, T.tile + ScreenUpgrade.valueTile.ToString() + "%", this.xTiLe, this.yInven, 0);
		}
		int num = this.xInven + this.wInven + 20;
		int num2 = this.yInven + (this.hInven + 4) * 2 - 20;
		AvMain.paintRect(g, num, num2, Interface_Game.wMoneyEff - 50, 30, 1, 4);
		num2 += 9;
		AvMain.fraMoney.drawFrame(0, num + Interface_Game.mini + AvMain.fraMoney.frameWidth / 2 - 3, num2, 0, 3, g);
		AvMain.fraMoney.drawFrame(1, num + Interface_Game.mini + AvMain.fraMoney.frameWidth / 2 + 45, num2, 0, 3, g);
		AvMain.fraMoney.drawFrame(7, num + Interface_Game.mini + AvMain.fraMoney.frameWidth / 2 - 3, num2 + 15, 0, 3, g);
		mFont.tahoma_7_yellow.drawString(g, " " + AvMain.getMoneyShortText((long)ScreenUpgrade.valueMonney_1), num + Interface_Game.mini + AvMain.fraMoney.frameWidth - 4, num2 - 5, 0);
		mFont.tahoma_7_red.drawString(g, " " + AvMain.getDotNumber((long)ScreenUpgrade.valueMonney_2), num + Interface_Game.mini + AvMain.fraMoney.frameWidth + 45, num2 - 5, 0);
		mFont.tahoma_7_green.drawString(g, " " + AvMain.getMoneyShortText((long)ScreenUpgrade.valueMonney_3), num + Interface_Game.mini + AvMain.fraMoney.frameWidth - 4, num2 - 5 + 15, 0);
	}

	// Token: 0x06000E3E RID: 3646 RVA: 0x0011266C File Offset: 0x0011086C
	public override void paintBackGr(mGraphics g)
	{
		base.paintPaper(g, this.x, this.y - 17, this.w, this.h + 17, this.w, (int)AvMain.PAPER_NORMAL);
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
		bool flag3 = this.Step == 0;
		if (flag3)
		{
			AvMain.paintRect(g, this.xInven, this.yInven, this.wInven, this.hInven, 0, 3);
		}
		else
		{
			bool flag4 = this.Step != 0;
			if (flag4)
			{
				AvMain.paintRect(g, this.xInven, this.yInven, this.wInven, (this.hInven + 4) * 2, 0, 3);
				bool flag5 = this.fraEffUpgrade == null;
				if (flag5)
				{
					this.fraEffUpgrade = new FrameImage(mImage.createImage("/interface/effupgrade.png"), 58, 50);
				}
				this.fraEffUpgrade.drawFrame(this.frameEff % this.fraEffUpgrade.nFrame, this.xInven + this.wInven / 2 + 10, this.yInven + this.hInven, 0, 3, g);
			}
		}
	}

	// Token: 0x06000E3F RID: 3647 RVA: 0x0000BD31 File Offset: 0x00009F31
	private void loadImg()
	{
		this.imghoavan = mImage.createImage("/interface/u_hoavan.png");
		this.imgtron = mImage.createImage("/interface/u_tron.png");
	}

	// Token: 0x06000E40 RID: 3648 RVA: 0x00112924 File Offset: 0x00110B24
	public override void setPosInfo()
	{
		bool flag = this.IdSelect >= 0;
		if (flag)
		{
			base.setPosInfo(this.itemCur, this.xInven, this.yInven + (this.IdSelect / this.maxNumItemW + 1) * this.wItem - this.list.cmx + 4);
		}
		bool flag2 = this.idSelect2 >= 0;
		if (flag2)
		{
			base.setPosInfo(this.itemCur, this.xInven, this.yInven2 + (this.idSelect2 / this.maxNumItemW + 1) * this.wItem - this.listDa.cmx + 4);
		}
	}

	// Token: 0x06000E41 RID: 3649 RVA: 0x001129D4 File Offset: 0x00110BD4
	public override void update()
	{
		base.update();
		int cmx = this.listDa.cmx;
		this.listDa.moveCamera();
		bool flag = this.listDa.cmx != cmx || this.listDa.pointerIsDowning;
		if (flag)
		{
			this.isShowInfo = false;
		}
		else
		{
			bool flag2 = this.itemCur != null;
			if (flag2)
			{
				this.isShowInfo = false;
			}
		}
	}

	// Token: 0x06000E42 RID: 3650 RVA: 0x00112A44 File Offset: 0x00110C44
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
				int num2 = SkinUpgradeScreen.vecSkin.size();
				bool flag3 = num >= 0 && num < num2;
				if (flag3)
				{
					GameCanvas.isPointerSelect = false;
					bool flag4 = num == this.IdSelect;
					if (flag4)
					{
						bool flag5 = this.itemCur != null && this.cmdBovao != null;
						if (flag5)
						{
							this.cmdBovao.perform();
						}
					}
					else
					{
						this.isShowInfo = false;
						this.IdSelect = num;
						this.idSelect2 = -1;
						this.setPosCmd(this.getMenuActionItem());
						mSystem.outz("select " + this.IdSelect.ToString() + " select2 " + this.idSelect2.ToString());
					}
				}
				else
				{
					this.isShowInfo = false;
					this.IdSelect = -1;
					this.idSelect2 = -1;
					this.setPosCmd(null);
				}
			}
			this.listDa.update_Pos_UP_DOWN();
			bool flag6 = GameCanvas.isPointSelect(this.xInven, this.yInven2, this.wInven, this.hInven);
			if (flag6)
			{
				int num3 = (GameCanvas.px - this.xInven) / this.wItem + (GameCanvas.py - this.yInven2 + this.listDa.cmx) / this.wItem * this.maxNumItemW;
				int num4 = SkinUpgradeScreen.vecDa.size();
				bool flag7 = num3 >= 0 && num3 < num4;
				if (flag7)
				{
					GameCanvas.isPointerSelect = false;
					bool flag8 = num3 == this.idSelect2;
					if (flag8)
					{
						bool flag9 = this.itemCur != null && this.cmdBovao != null;
						if (flag9)
						{
							this.cmdBovao.perform();
						}
					}
					else
					{
						this.isShowInfo = false;
						this.idSelect2 = num3;
						this.IdSelect = -1;
						this.setPosCmd(this.getMenuActionItem());
						mSystem.outz("select " + this.IdSelect.ToString() + " select2 " + this.idSelect2.ToString());
					}
				}
				else
				{
					this.isShowInfo = false;
					this.idSelect2 = -1;
					this.IdSelect = -1;
					this.setPosCmd(null);
				}
			}
			bool flag10 = this.vecCmd != null;
			if (flag10)
			{
				for (int i = 0; i < this.vecCmd.size(); i++)
				{
					iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
					iCommand.updatePointer();
				}
			}
			bool flag11 = !GameCanvas.isTouch;
			if (!flag11)
			{
				bool flag12 = this.left != null;
				if (flag12)
				{
					bool flag13 = this.left.isPosCmd();
					if (flag13)
					{
						this.left.updatePointer();
					}
					else
					{
						bool flag14 = GameCanvas.isPointSelect(0, MotherCanvas.h - GameCanvas.hCommand - 5, GameCanvas.wCommand * 2, GameCanvas.hCommand + 10);
						if (flag14)
						{
							this.left.perform();
						}
					}
				}
				bool flag15 = this.right != null;
				if (flag15)
				{
					bool flag16 = this.right.isPosCmd();
					if (flag16)
					{
						this.right.updatePointer();
					}
					else
					{
						bool flag17 = GameCanvas.isPointSelect(MotherCanvas.w - GameCanvas.wCommand * 2, MotherCanvas.h - GameCanvas.hCommand - 5, GameCanvas.wCommand * 2, GameCanvas.hCommand + 10);
						if (flag17)
						{
							this.right.perform();
						}
					}
				}
				bool flag18 = this.center != null;
				if (flag18)
				{
					bool flag19 = this.center.isPosCmd();
					if (flag19)
					{
						this.center.updatePointer();
					}
					else
					{
						bool flag20 = GameCanvas.isPointSelect(MotherCanvas.hw - GameCanvas.wCommand, MotherCanvas.h - GameCanvas.hCommand - 5, GameCanvas.wCommand * 2, GameCanvas.hCommand + 10);
						if (flag20)
						{
							this.center.perform();
						}
					}
				}
			}
		}
	}

	// Token: 0x06000E43 RID: 3651 RVA: 0x00112EA0 File Offset: 0x001110A0
	public override mVector getMenuActionItem()
	{
		mVector mVector = new mVector();
		MainItem mainItem = null;
		bool flag = this.IdSelect >= 0;
		if (flag)
		{
			mainItem = (MainItem)SkinUpgradeScreen.vecSkin.elementAt(this.IdSelect);
		}
		else
		{
			bool flag2 = this.idSelect2 >= 0;
			if (flag2)
			{
				mainItem = (MainItem)SkinUpgradeScreen.vecDa.elementAt(this.idSelect2);
			}
		}
		bool flag3 = mainItem != null;
		if (flag3)
		{
			this.itemCur = mainItem;
			this.cmdBovao.caption = T.bovao;
			this.cmdBovao.subIndex = 1;
			bool flag4 = this.isGetItemUpgrade(this.itemCur.ID, this.itemCur.typeObject);
			if (flag4)
			{
				this.cmdBovao.caption = T.layra;
				this.cmdBovao.subIndex = 0;
			}
			mVector.addElement(this.cmdBovao);
		}
		return mVector;
	}

	// Token: 0x06000E44 RID: 3652 RVA: 0x00112F8C File Offset: 0x0011118C
	public override void getItemCurNew()
	{
		this.isShowInfo = false;
		bool flag = this.IdSelect >= 0;
		if (flag)
		{
			this.IdSelect = AvMain.resetSelect(this.IdSelect, SkinUpgradeScreen.vecSkin.size() - 1, false);
			bool flag2 = GameCanvas.isTouchNoOrPC();
			if (flag2)
			{
				this.list.setToX((this.IdSelect / this.maxNumItemW + 1) * this.wItem - this.hInven);
			}
			this.setPosCmd(this.getMenuActionItem());
		}
		bool flag3 = this.idSelect2 >= 0;
		if (flag3)
		{
			this.idSelect2 = AvMain.resetSelect(this.idSelect2, SkinUpgradeScreen.vecDa.size() - 1, false);
			bool flag4 = GameCanvas.isTouchNoOrPC();
			if (flag4)
			{
				this.listDa.setToX((this.idSelect2 / this.maxNumItemW + 1) * this.wItem - this.hInven);
			}
			this.setPosCmd(this.getMenuActionItem());
		}
	}

	// Token: 0x06000E45 RID: 3653 RVA: 0x00113084 File Offset: 0x00111284
	public override void commandPointer(int index, int subIndex)
	{
		base.commandPointer(index, subIndex);
		switch (index)
		{
		case 13:
		{
			bool flag = this.itemCur == null;
			if (!flag)
			{
				sbyte b = 0;
				bool flag2 = subIndex == 0;
				if (flag2)
				{
					b = this.GetItemUpgrade(this.itemCur.ID, this.itemCur.typeObject);
				}
				else
				{
					bool flag3 = this.itemCur.typeObject == 7;
					if (flag3)
					{
						b = 1;
					}
					else
					{
						bool flag4 = this.itemCur.typeObject == 105;
						if (flag4)
						{
							b = 0;
						}
						else
						{
							bool flag5 = this.itemCur.typeObject == 4;
							if (flag5)
							{
								b = -1;
								sbyte b2 = 2;
								while ((int)b2 < ScreenUpgrade.mItemUpgrade.Length)
								{
									bool flag6 = ScreenUpgrade.mItemUpgrade[(int)b2] == null;
									if (flag6)
									{
										b = b2;
										break;
									}
									b2 += 1;
								}
							}
						}
					}
				}
				bool flag7 = b > 0 && ScreenUpgrade.mItemUpgrade[0] == null;
				if (flag7)
				{
					GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.nullItemUpgrade);
				}
				else
				{
					bool flag8 = b >= 0;
					if (flag8)
					{
						GlobalService.gI().Upgrade_Skin(1, this.itemCur.typeObject, this.itemCur.ID, b, (sbyte)subIndex);
					}
				}
			}
			break;
		}
		case 14:
		{
			bool flag9 = ScreenUpgrade.mItemUpgrade[0] == null;
			if (flag9)
			{
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.nullItemUpgrade);
			}
			else
			{
				GlobalService.gI().Upgrade_Skin(4, ScreenUpgrade.mItemUpgrade[0].ID);
			}
			break;
		}
		case 15:
		{
			mVector mVector = new mVector();
			sbyte b3 = 0;
			while ((int)b3 < ScreenUpgrade.mItemUpgrade.Length)
			{
				bool flag10 = ScreenUpgrade.mItemUpgrade[(int)b3] != null;
				if (flag10)
				{
					mVector.addElement(ScreenUpgrade.mItemUpgrade[(int)b3]);
				}
				b3 += 1;
			}
			GlobalService.gI().Upgrade_Skin(2, mVector);
			GameCanvas.end_Dialog();
			break;
		}
		}
	}

	// Token: 0x06000E46 RID: 3654 RVA: 0x0011327C File Offset: 0x0011147C
	public void setInfo_money(int valueMonney_1, short valueMonney_2, int valueMonney_3)
	{
		int num = 0;
		bool flag = false;
		sbyte b = 1;
		while ((int)b < ScreenUpgrade.mItemUpgrade.Length)
		{
			bool flag2 = ScreenUpgrade.mItemUpgrade[(int)b] != null;
			if (flag2)
			{
				bool flag3 = ScreenUpgrade.mItemUpgrade[(int)b].typeObject == 7 && ScreenUpgrade.mItemUpgrade[(int)b].ID == 17;
				if (flag3)
				{
					flag = true;
				}
				else
				{
					num += (int)ScreenUpgrade.mItemUpgrade[(int)b].perSuc;
				}
				mSystem.outz("perSucc " + ScreenUpgrade.mItemUpgrade[(int)b].perSuc.ToString() + " tile = " + num.ToString());
			}
			b += 1;
		}
		ScreenUpgrade.valueTile = num - (int)(ScreenUpgrade.mItemUpgrade[0].LvUpgrade * 4);
		bool flag4 = flag;
		if (flag4)
		{
			ScreenUpgrade.valueTile *= 2;
		}
		bool flag5 = ScreenUpgrade.valueTile <= 0;
		if (flag5)
		{
			ScreenUpgrade.valueTile = 0;
		}
		mSystem.outz("valueTile = " + ScreenUpgrade.valueTile.ToString());
		bool flag6 = valueMonney_1 != 0 || valueMonney_2 != 0 || valueMonney_3 != 0;
		if (flag6)
		{
			ScreenUpgrade.valueMonney_1 = valueMonney_1;
			ScreenUpgrade.valueMonney_2 = (int)valueMonney_2;
			ScreenUpgrade.valueMonney_3 = valueMonney_3;
		}
	}

	// Token: 0x06000E47 RID: 3655 RVA: 0x001133B0 File Offset: 0x001115B0
	public sbyte GetItemUpgrade(short Id, sbyte cat)
	{
		sbyte b = 1;
		while ((int)b < ScreenUpgrade.mItemUpgrade.Length)
		{
			bool flag = ScreenUpgrade.mItemUpgrade[(int)b] != null && ScreenUpgrade.mItemUpgrade[(int)b].ID == Id && ScreenUpgrade.mItemUpgrade[(int)b].typeObject == cat;
			if (flag)
			{
				return b;
			}
			b += 1;
		}
		return -1;
	}

	// Token: 0x06000E48 RID: 3656 RVA: 0x00113410 File Offset: 0x00111610
	public override void paintIconUpgrade(mGraphics g, int x, int y, MainItem item)
	{
		for (int i = 0; i < ScreenUpgrade.mItemUpgrade.Length; i++)
		{
			bool flag = ScreenUpgrade.mItemUpgrade[i] != null && ScreenUpgrade.mItemUpgrade[i].ID == item.ID && ScreenUpgrade.mItemUpgrade[i].typeObject == item.typeObject;
			if (flag)
			{
				g.drawImage(AvMain.imgcheck, x, y, mGraphics.BOTTOM | mGraphics.LEFT);
			}
		}
	}

	// Token: 0x06000E49 RID: 3657 RVA: 0x0011348C File Offset: 0x0011168C
	public void setLvUpgradeItem(short idItem, sbyte level)
	{
		ScreenUpgrade.mItemUpgrade[0].LvUpgrade = level;
		sbyte b = 0;
		while ((int)b < SkinUpgradeScreen.vecSkin.size())
		{
			MainItem mainItem = (MainItem)SkinUpgradeScreen.vecSkin.elementAt((int)b);
			bool flag = mainItem.ID == idItem;
			if (flag)
			{
				mainItem.LvUpgrade = level;
				break;
			}
			b += 1;
		}
	}

	// Token: 0x06000E4A RID: 3658 RVA: 0x001134EC File Offset: 0x001116EC
	public override void setStep()
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
			base.updateEff();
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
					for (int i = this.indexStep; i < ScreenUpgrade.mItemUpgrade.Length; i++)
					{
						bool flag6 = ScreenUpgrade.mItemUpgrade[i] != null;
						if (flag6)
						{
							base.createEff(75, 0, this.posUp[i][0] + this.wItem / 2, this.posUp[i][1] + this.wItem / 2, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2);
							ScreenUpgrade.mItemUpgrade[i].isRemove = true;
							this.indexStep = i + 1;
							this.tickStop = this.tickStep + 11 + ((this.w - this.lech * 3 - this.wInven) / 2 - 15) / 5;
							break;
						}
					}
				}
				else
				{
					bool flag7 = this.tickStep < this.tickStop;
					if (!flag7)
					{
						bool flag8 = this.Step == 1;
						if (flag8)
						{
							mSound.playSound(28, mSound.volumeSound);
							int subtype = 0;
							bool flag9 = GameCanvas.language == 1;
							if (flag9)
							{
								subtype = 2;
							}
							base.createEff(79, subtype, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2);
							base.createEff(76, 0, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2);
							base.createEff(53, 0, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2);
						}
						else
						{
							bool flag10 = this.Step == 2;
							if (flag10)
							{
								mSound.playSound(29, mSound.volumeSound);
								int subtype2 = 1;
								bool flag11 = GameCanvas.language == 1;
								if (flag11)
								{
									subtype2 = 3;
								}
								base.createEff(79, subtype2, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2);
								base.createEff(77, 0, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2);
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
			bool flag12 = this.Step != 3;
			if (!flag12)
			{
				this.tickStep++;
				bool flag13 = this.tickStep >= this.tickStop;
				if (flag13)
				{
					this.Step = 0;
					this.tickStop = 0;
					this.tickStep = 0;
					this.indexStep = 1;
					GameCanvas.Start_Normal_Only_CmdClose_DiaLog(this.showServer);
					GlobalService.gI().Upgrade_Skin(1, ScreenUpgrade.mItemUpgrade[0].typeObject, ScreenUpgrade.mItemUpgrade[0].ID, 0, 1);
					for (int j = 0; j < ScreenUpgrade.mItemUpgrade.Length; j++)
					{
						ScreenUpgrade.mItemUpgrade[j] = null;
					}
				}
			}
		}
	}

	// Token: 0x06000E4B RID: 3659 RVA: 0x0011398C File Offset: 0x00111B8C
	public override void updatekey()
	{
		bool flag = this.Step != 0;
		if (!flag)
		{
			bool flag2 = false;
			bool flag3 = GameCanvas.keyMove(0);
			if (flag3)
			{
				bool flag4 = this.IdSelect > 0;
				if (flag4)
				{
					this.IdSelect--;
				}
				bool flag5 = this.idSelect2 > 0;
				if (flag5)
				{
					this.idSelect2--;
				}
				GameCanvas.ClearkeyMove(0);
				flag2 = true;
			}
			else
			{
				bool flag6 = GameCanvas.keyMove(2);
				if (flag6)
				{
					bool flag7 = this.IdSelect != -1 && this.IdSelect < SkinUpgradeScreen.vecSkin.size() - 1;
					if (flag7)
					{
						this.IdSelect++;
					}
					bool flag8 = this.idSelect2 != -1 && this.idSelect2 < SkinUpgradeScreen.vecDa.size() - 1;
					if (flag8)
					{
						this.idSelect2++;
					}
					GameCanvas.ClearkeyMove(2);
					flag2 = true;
				}
				else
				{
					bool flag9 = GameCanvas.keyMove(1);
					if (flag9)
					{
						bool flag10 = this.IdSelect >= this.maxNumItemW;
						if (flag10)
						{
							this.IdSelect -= this.maxNumItemW;
						}
						else
						{
							bool flag11 = this.idSelect2 >= this.maxNumItemW;
							if (flag11)
							{
								this.idSelect2 -= this.maxNumItemW;
							}
							else
							{
								bool flag12 = this.idSelect2 != -1 && this.idSelect2 < this.maxNumItemW;
								if (flag12)
								{
									this.idSelect2 = -1;
									this.IdSelect = SkinUpgradeScreen.vecSkin.size() - 1;
								}
							}
						}
						GameCanvas.ClearkeyMove(1);
						flag2 = true;
					}
					else
					{
						bool flag13 = GameCanvas.keyMove(3);
						if (flag13)
						{
							bool flag14 = this.IdSelect != -1 && this.IdSelect < SkinUpgradeScreen.vecSkin.size() - this.maxNumItemW;
							if (flag14)
							{
								this.IdSelect += this.maxNumItemW;
							}
							else
							{
								bool flag15 = this.idSelect2 != -1 && this.idSelect2 < SkinUpgradeScreen.vecDa.size() - this.maxNumItemW;
								if (flag15)
								{
									this.idSelect2 += this.maxNumItemW;
								}
								else
								{
									bool flag16 = this.IdSelect >= SkinUpgradeScreen.vecSkin.size() - this.maxNumItemW;
									if (flag16)
									{
										this.idSelect2 = 0;
										this.IdSelect = -1;
									}
								}
							}
							GameCanvas.ClearkeyMove(3);
							flag2 = true;
						}
					}
				}
			}
			bool flag17 = this.IdSelect >= 0 && this.IdSelect < SkinUpgradeScreen.vecSkin.size();
			if (flag17)
			{
				this.idSelect2 = -1;
			}
			bool flag18 = this.idSelect2 >= 0 && this.idSelect2 < SkinUpgradeScreen.vecDa.size();
			if (flag18)
			{
				this.IdSelect = -1;
			}
			bool flag19 = flag2;
			if (flag19)
			{
				this.getItemCurNew();
			}
			this.updatekeyPC();
		}
	}

	// Token: 0x06000E4C RID: 3660 RVA: 0x00113C84 File Offset: 0x00111E84
	public void SetValueMayMan()
	{
		mVector mVector = new mVector();
		sbyte b = 2;
		while ((int)b < ScreenUpgrade.mItemUpgrade.Length)
		{
			bool flag = ScreenUpgrade.mItemUpgrade[(int)b] != null;
			if (flag)
			{
				mVector.addElement(ScreenUpgrade.mItemUpgrade[(int)b]);
				mSystem.outz("add item " + b.ToString());
			}
			else
			{
				mSystem.outz("add item " + b.ToString() + " null");
			}
			b += 1;
		}
		bool flag2 = mVector.size() == 4;
		if (flag2)
		{
			GlobalService.gI().Upgrade_Skin(6, ScreenUpgrade.mItemUpgrade[0].ID, mVector);
		}
		else
		{
			this.valueMayMan = 0;
		}
	}

	// Token: 0x040015BF RID: 5567
	public new static SkinUpgradeScreen instance;

	// Token: 0x040015C0 RID: 5568
	public static mVector vecSkin = new mVector();

	// Token: 0x040015C1 RID: 5569
	public static mVector vecDa = new mVector();

	// Token: 0x040015C2 RID: 5570
	public ListNew listDa;

	// Token: 0x040015C3 RID: 5571
	private int yInven2;

	// Token: 0x040015C4 RID: 5572
	private int idSelect2;

	// Token: 0x040015C5 RID: 5573
	public static sbyte[] mTileCuongHoa = null;
}
