using System;

// Token: 0x020000FE RID: 254
public class TabInfo : MainTab
{
	// Token: 0x06000ED0 RID: 3792 RVA: 0x0011DF14 File Offset: 0x0011C114
	public TabInfo(string name)
	{
		this.nameTab = name;
		this.xBeginInfo = this.wCur;
		this.initCmd();
		this.listInfo = new ListNew();
		this.indexIconTab = 2;
	}

	// Token: 0x06000ED1 RID: 3793 RVA: 0x0011DF8C File Offset: 0x0011C18C
	public override void beginFocus()
	{
		int limX = GameScreen.player.vecAllInfo.size() * GameCanvas.hText - this.hCur + this.miniItem * 2;
		this.listInfo = new ListNew(this.xCurBegin, this.yCurBegin, this.wCur, this.hCur, 0, 0, limX, true);
		this.scrInfo.setInfo(this.xCurBegin + this.wCur + this.miniItem, this.yCurBegin + this.miniItem / 2, this.hCur - this.miniItem * 2, 8809550);
		this.listInfo.cmx = this.lastCam;
		this.listInfo.cmtoX = this.lastCam;
		this.hItem = GameCanvas.hText * 4;
		limX = Player.mAttribute.Length * this.hItem - this.hCur + this.miniItem * 2 + GameCanvas.hText * 3 / 2;
		this.listAttri = new ListNew(this.xCurBegin, this.yCurBegin, this.wCur, this.hCur, 0, 0, limX, true);
		this.scrAttri.setInfo(this.xCurBegin + this.wCur + this.miniItem, this.yCurBegin + this.miniItem / 2, this.hCur - this.miniItem * 2, 8809550);
	}

	// Token: 0x06000ED2 RID: 3794 RVA: 0x0011E0EC File Offset: 0x0011C2EC
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
		{
			bool flag = this.IdSelect < 0 || this.IdSelect >= Player.mAttribute.Length || Player.mAttribute[this.IdSelect].value >= 80;
			if (!flag)
			{
				bool flag2 = Player.pointAttribute > 1;
				if (flag2)
				{
					mVector mVector = new mVector();
					int num = 0;
					for (int i = 0; i < this.mNumAttri.Length; i++)
					{
						int num2 = this.mNumAttri[i];
						bool flag3 = num2 > Player.pointAttribute;
						if (flag3)
						{
							num2 = Player.pointAttribute;
						}
						bool flag4 = num2 > (int)(80 - Player.mAttribute[this.IdSelect].value);
						if (flag4)
						{
							num2 = (int)(80 - Player.mAttribute[this.IdSelect].value);
						}
						iCommand iCommand = new iCommand("+" + num2.ToString(), 2, num2, this);
						bool isTouch = GameCanvas.isTouch;
						if (isTouch)
						{
							iCommand.levelSmall = 3;
						}
						bool flag5 = num != num2;
						if (flag5)
						{
							num = num2;
							mVector.addElement(iCommand);
						}
						bool flag6 = this.mNumAttri[i] >= Player.pointAttribute;
						if (flag6)
						{
							break;
						}
					}
					GameCanvas.Start_Normal_DiaLog_New(T.nhaptiemnang + T.mAttribute[this.IdSelect] + "?", mVector, true, T.tabAttribute);
				}
				else
				{
					bool flag7 = Player.pointAttribute == 1;
					if (flag7)
					{
						GlobalService.gI().Add_Point_Attribute((sbyte)this.IdSelect, 1);
					}
					else
					{
						GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.nullPointAttribute);
					}
				}
			}
			break;
		}
		case 1:
		{
			int num3 = 1;
			try
			{
				num3 = int.Parse(this.input.tfInput.getText());
				bool flag8 = num3 < 0;
				if (flag8)
				{
					num3 = 1;
				}
			}
			catch (Exception)
			{
				num3 = 1;
			}
			GlobalService.gI().Add_Point_Attribute((sbyte)this.IdSelect, (short)num3);
			GameCanvas.end_Dialog();
			break;
		}
		case 2:
			GlobalService.gI().Add_Point_Attribute((sbyte)this.IdSelect, (short)subIndex);
			GameCanvas.end_Dialog();
			break;
		}
	}

	// Token: 0x06000ED3 RID: 3795 RVA: 0x0011E338 File Offset: 0x0011C538
	public void initCmd()
	{
		this.cmdSetPoint = new iCommand(T.cmdSetPoint, 0, this);
		this.cmdSetPoint.setPos(MotherCanvas.hw, MotherCanvas.h - iCommand.hButtonCmdNor / 2, null, this.cmdSetPoint.caption);
		bool flag = this.levelTab == 1;
		if (flag)
		{
			bool flag2 = GameCanvas.isTouchNoOrPC();
			if (flag2)
			{
				this.center = this.cmdSetPoint;
				this.okCMD = this.center;
			}
		}
		else
		{
			this.center = null;
			this.okCMD = null;
		}
	}

	// Token: 0x06000ED4 RID: 3796 RVA: 0x0011E3C8 File Offset: 0x0011C5C8
	public override void paint(mGraphics g)
	{
		g.setColor(14203529);
		int idx = 0;
		bool flag = GameCanvas.currentScreen.setCurTypetab(1);
		if (flag)
		{
			bool flag2 = this.levelTab == 1;
			if (flag2)
			{
				g.fillRoundRect(MainTab.xTab + 22 + (MainTab.wTab - 22) / 2 - MainTab.wTab / 4 * 3 / 2, MainTab.yTab + 7, MainTab.wTab / 4 * 3 / 2, 16, 4, 4);
				idx = 2;
				AvMain.FontBorderColor(g, T.tabAttribute, MainTab.xTab + 22 + (MainTab.wTab - 22) / 2 + 15, MainTab.yTab + 9, 0, 6, 5);
				mFont.tahoma_7b_black.drawString(g, T.tabInfo, MainTab.xTab + 22 + (MainTab.wTab - 22) / 2 - 15, MainTab.yTab + 9, 1);
			}
			else
			{
				bool flag3 = this.levelTab == 0;
				if (flag3)
				{
					g.fillRoundRect(MainTab.xTab + 22 + (MainTab.wTab - 22) / 2, MainTab.yTab + 7, MainTab.wTab / 4 * 3 / 2, 16, 4, 4);
					idx = 1;
					mFont.tahoma_7b_black.drawString(g, T.tabAttribute, MainTab.xTab + 22 + (MainTab.wTab - 22) / 2 + 15, MainTab.yTab + 9, 0);
					AvMain.FontBorderColor(g, T.tabInfo, MainTab.xTab + 22 + (MainTab.wTab - 22) / 2 - 15, MainTab.yTab + 9, 1, 6, 5);
				}
			}
		}
		else
		{
			mFont.tahoma_7b_black.drawString(g, T.tabAttribute, MainTab.xTab + 22 + (MainTab.wTab - 22) / 2 + 15, MainTab.yTab + 9, 0);
			mFont.tahoma_7b_black.drawString(g, T.tabInfo, MainTab.xTab + 22 + (MainTab.wTab - 22) / 2 - 15, MainTab.yTab + 9, 1);
		}
		AvMain.fraTwoTab.drawFrame(idx, MainTab.xTab + 22 + (MainTab.wTab - 22) / 2, MainTab.yTab + 9 + 6, 0, 3, g);
		bool flag4 = Player.pointAttribute > 0 && GameCanvas.gameTick % 10 < 8;
		if (flag4)
		{
			g.drawImage(MainEvent.imgNew, MainTab.xTab + 22 + (MainTab.wTab - 22) / 2 + 9, MainTab.yTab + 9, 3);
		}
		GameCanvas.resetTrans(g);
		AvMain.paintRect(g, this.xCurBegin, this.yCurBegin, this.wCur, this.hCur - this.miniItem, 0, 4);
		g.setClip(this.xCurBegin - 1, this.yCurBegin + 1, this.wCur + 2, this.hCur - 1 - this.miniItem - 1);
		g.saveCanvas();
		g.ClipRec(this.xCurBegin - 1, this.yCurBegin + 1, this.wCur + 2, this.hCur - 1 - this.miniItem - 1);
		g.translate(this.xCurBegin, this.yCurBegin);
		bool flag5 = this.levelTab == 1;
		if (flag5)
		{
			g.translate(-this.xcur, -this.listAttri.cmx);
			this.paintTiemNang(g);
		}
		else
		{
			bool flag6 = this.levelTab == 0;
			if (flag6)
			{
				g.translate(-this.xcur, -this.listInfo.cmx);
				this.paintThongTin(g);
			}
		}
		mGraphics.resetTransAndroid(g);
		g.restoreCanvas();
	}

	// Token: 0x06000ED5 RID: 3797 RVA: 0x0011E744 File Offset: 0x0011C944
	public void paintTiemNang(mGraphics g)
	{
		bool flag = GameCanvas.isTouchNoOrPC();
		if (flag)
		{
			this.paintSelect(g);
		}
		int num = this.miniItem;
		int wCur = this.wCur;
		mFont.tahoma_7b_yellow.drawString(g, T.pointAttribute + ": " + Player.pointAttribute.ToString(), wCur + this.miniItem, num, 0);
		num += GameCanvas.hText + GameCanvas.hText / 2;
		bool flag2 = TabInfo.isshow;
		if (flag2)
		{
			for (int i = 0; i < Player.mAttribute.Length; i++)
			{
				Main_Attribute main_Attribute = Player.mAttribute[i];
				mFont.tahoma_7b_white.drawString(g, main_Attribute.name + ": " + main_Attribute.value.ToString(), wCur + this.miniItem, num, 0);
				bool flag3 = main_Attribute.valuePlus > 0;
				if (flag3)
				{
					int width = mFont.tahoma_7b_white.getWidth(main_Attribute.name + ": " + main_Attribute.value.ToString() + " ");
					mFont.tahoma_7b_blue.drawString(g, "+" + main_Attribute.valuePlus.ToString(), wCur + this.miniItem + width, num, 0);
				}
				for (int j = 0; j < main_Attribute.minfo.Length; j++)
				{
					string infoEveryWhere = MainItem.getInfoEveryWhere(main_Attribute.minfo[j]);
					mFont.tahoma_7_green.drawString(g, infoEveryWhere, wCur + this.miniItem * 2, num + (GameCanvas.hText - 2) * (j + 1), 0);
				}
				bool flag4 = !GameCanvas.isSmallScreen && !GameCanvas.lowGraphic;
				if (flag4)
				{
					int idx = 0;
					bool flag5 = Player.pointAttribute <= 0 || Player.mAttribute[i].value >= 80;
					if (flag5)
					{
						idx = 2;
					}
					else
					{
						bool flag6 = this.timefocus > 0 && i == this.IdSelect;
						if (flag6)
						{
							idx = 1;
						}
					}
					AvMain.fraButtonTiemNang.drawFrame(idx, wCur + this.wCur - AvMain.fraButtonTiemNang.frameHeight / 2 - (GameCanvas.hText * 3 - AvMain.fraButtonTiemNang.frameWidth / 2) / 2, num + GameCanvas.hText * 3 / 2 - this.miniItem / 2, 0, 3, g);
				}
				num += this.hItem;
			}
		}
		bool flag7 = GameCanvas.currentScreen.setCurTypetab(1);
		if (flag7)
		{
			base.paint(g);
			bool flag8 = this.listAttri.cmxLim > 0;
			if (flag8)
			{
				this.scrAttri.paint(g);
			}
		}
	}

	// Token: 0x06000ED6 RID: 3798 RVA: 0x0011E9EC File Offset: 0x0011CBEC
	public void paintThongTin(mGraphics g)
	{
		for (int i = 0; i < GameScreen.player.vecAllInfo.size(); i++)
		{
			MainInfoItem mainInfoItem = (MainInfoItem)GameScreen.player.vecAllInfo.elementAt(i);
			string infoEveryWhere = MainItem.getInfoEveryWhere(mainInfoItem);
			mFont.tahoma_7_white.drawString(g, infoEveryWhere, this.miniItem, this.miniItem + i * GameCanvas.hText, 0);
			bool flag = GameScreen.player.vecBuffCur.size() > 0;
			if (flag)
			{
				this.paintAttPlusBuff(g, infoEveryWhere, (int)mainInfoItem.id, this.miniItem + i * GameCanvas.hText);
			}
		}
		bool flag2 = GameCanvas.currentScreen.setCurTypetab(1);
		if (flag2)
		{
			base.paint(g);
			bool flag3 = this.listInfo.cmxLim > 0;
			if (flag3)
			{
				this.scrInfo.paint(g);
			}
		}
	}

	// Token: 0x06000ED7 RID: 3799 RVA: 0x0011EAD4 File Offset: 0x0011CCD4
	public void paintAttPlusBuff(mGraphics g, string text, int id, int y)
	{
		int num = 0;
		for (int i = 0; i < GameScreen.player.vecBuffCur.size(); i++)
		{
			MainBuff mainBuff = (MainBuff)GameScreen.player.vecBuffCur.elementAt(i);
			bool flag = mainBuff.vecInfoAtt.size() <= 0;
			if (!flag)
			{
				for (int j = 0; j < mainBuff.vecInfoAtt.size(); j++)
				{
					MainInfoItem mainInfoItem = (MainInfoItem)mainBuff.vecInfoAtt.elementAt(j);
					bool flag2 = (int)mainInfoItem.id == id;
					if (flag2)
					{
						num += mainInfoItem.value;
						break;
					}
				}
			}
		}
		for (int k = 0; k < GameScreen.player.vecAllInfoParty.size(); k++)
		{
			MainInfoItem mainInfoItem2 = (MainInfoItem)GameScreen.player.vecAllInfoParty.elementAt(k);
			bool flag3 = (int)mainInfoItem2.id == id;
			if (flag3)
			{
				num += mainInfoItem2.value;
				break;
			}
		}
		bool flag4 = num != 0;
		if (flag4)
		{
			int width = mFont.tahoma_7_white.getWidth(text);
			string st = string.Empty + MainItem.strGetPercent(num, MainItem.mNameAttributes[id].ispercent);
			bool flag5 = num > 0;
			if (flag5)
			{
				st = "+" + MainItem.strGetPercent(num, MainItem.mNameAttributes[id].ispercent);
				mFont.tahoma_7_green.drawString(g, st, this.miniItem * 2 + width, y, 0);
			}
			else
			{
				mFont.tahoma_7_red.drawString(g, st, this.miniItem * 2 + width, y, 0);
			}
		}
	}

	// Token: 0x06000ED8 RID: 3800 RVA: 0x0011EC88 File Offset: 0x0011CE88
	public void paintSelect(mGraphics g)
	{
		int num = this.miniItem / 2 + GameCanvas.hText * 3 / 2;
		int wCur = this.wCur;
		g.setColor(16446420);
		g.fillRect(wCur + this.miniItem / 2, num + this.IdSelect * this.hItem, 1, this.hItem);
		g.fillRect(wCur + this.wCur - this.miniItem / 2 - 1, num + this.IdSelect * this.hItem, 1, this.hItem);
		g.fillRect(wCur + this.miniItem / 2 + 1, num + this.IdSelect * this.hItem - 1, this.wCur - this.miniItem - 1, 1);
		g.fillRect(wCur + this.miniItem / 2 + 1, num + this.IdSelect * this.hItem + this.hItem, this.wCur - this.miniItem - 1, 1);
	}

	// Token: 0x06000ED9 RID: 3801 RVA: 0x0011ED80 File Offset: 0x0011CF80
	public override void update()
	{
		bool flag = this.levelTab == 0;
		if (flag)
		{
			this.listInfo.moveCamera();
			this.scrInfo.setYScrool(this.listInfo.cmx, this.listInfo.cmxLim);
		}
		else
		{
			bool flag2 = this.levelTab == 1;
			if (flag2)
			{
				this.listAttri.moveCamera();
				this.scrAttri.setYScrool(this.listAttri.cmx, this.listAttri.cmxLim);
			}
		}
		bool flag3 = this.timefocus > 0;
		if (flag3)
		{
			this.timefocus--;
		}
		bool flag4 = this.xcur < this.xto && this.levelTab == 1;
		if (flag4)
		{
			this.xcur += this.speed;
			this.speed += 10;
			bool flag5 = this.xcur > this.xto;
			if (flag5)
			{
				this.xcur = this.xto;
			}
		}
		bool flag6 = this.xcur > this.xto && this.levelTab == 0;
		if (flag6)
		{
			this.xcur -= this.speed;
			this.speed += 10;
			bool flag7 = this.xcur < this.xto;
			if (flag7)
			{
				this.xcur = this.xto;
			}
		}
	}

	// Token: 0x06000EDA RID: 3802 RVA: 0x0011EEF4 File Offset: 0x0011D0F4
	public override void updatekey()
	{
		bool flag = this.levelTab == 0;
		if (flag)
		{
			bool flag2 = GameCanvas.keyMove(1);
			if (flag2)
			{
				GameCanvas.ClearkeyMove(1);
				this.listInfo.setToX(this.listInfo.cmtoX - MainTab.wItem);
				this.lastCam = this.listInfo.cmtoX;
			}
			else
			{
				bool flag3 = GameCanvas.keyMove(3);
				if (flag3)
				{
					this.listInfo.setToX(this.listInfo.cmtoX + MainTab.wItem);
					this.lastCam = this.listInfo.cmtoX;
					GameCanvas.ClearkeyMove(3);
				}
				else
				{
					bool flag4 = GameCanvas.keyMove(0);
					if (flag4)
					{
						GameCanvas.currentScreen.setTypeTab(0);
						GameCanvas.ClearkeyMove(0);
					}
					else
					{
						bool flag5 = GameCanvas.keyMove(2);
						if (flag5)
						{
							GameCanvas.ClearkeyMove(2);
							this.levelTab = 1;
							this.xto = this.wCur;
							this.speed = 20;
							this.xcur = 0;
							this.initCmd();
						}
					}
				}
			}
		}
		else
		{
			bool flag6 = this.levelTab == 1;
			if (flag6)
			{
				bool flag7 = false;
				bool flag8 = GameCanvas.keyMove(1);
				if (flag8)
				{
					GameCanvas.ClearkeyMove(1);
					this.IdSelect--;
					flag7 = true;
				}
				else
				{
					bool flag9 = GameCanvas.keyMove(3);
					if (flag9)
					{
						GameCanvas.ClearkeyMove(3);
						this.IdSelect++;
						flag7 = true;
					}
					else
					{
						bool flag10 = GameCanvas.keyMove(0);
						if (flag10)
						{
							GameCanvas.ClearkeyMove(0);
							this.xto = 0;
							this.speed = 20;
							this.xcur = this.wCur;
							this.levelTab = 0;
							this.initCmd();
						}
					}
				}
				bool flag11 = flag7;
				if (flag11)
				{
					this.IdSelect = AvMain.resetSelect(this.IdSelect, Player.mAttribute.Length - 1, true);
					bool flag12 = GameCanvas.isTouchNoOrPC();
					if (flag12)
					{
						this.listAttri.setToX((this.IdSelect + 1) * this.hItem - this.hCur / 2);
					}
				}
			}
		}
		base.updatekey();
		this.updatekeyPC();
	}

	// Token: 0x06000EDB RID: 3803 RVA: 0x0011F10C File Offset: 0x0011D30C
	public override void updatePointer()
	{
		bool flag = GameCanvas.isPointSelect(MainTab.xTab + 22 + (MainTab.wTab - 22) / 2 - MainTab.wTab / 4 * 3 / 2 - 6, MainTab.yTab + 7, MainTab.wTab / 4 * 3 - 20, 28);
		if (flag)
		{
			GameCanvas.isPointerSelect = false;
			bool flag2 = this.levelTab == 0;
			if (flag2)
			{
				this.levelTab = 1;
				this.xto = this.wCur;
				this.xcur = 0;
			}
			else
			{
				bool flag3 = this.levelTab == 1;
				if (flag3)
				{
					this.levelTab = 0;
					this.xto = 0;
					this.xcur = this.wCur;
				}
			}
			this.speed = 20;
			this.initCmd();
		}
		bool flag4 = this.levelTab == 0;
		if (flag4)
		{
			this.listInfo.update_Pos_UP_DOWN();
		}
		else
		{
			bool flag5 = this.levelTab == 1;
			if (flag5)
			{
				this.listAttri.update_Pos_UP_DOWN();
				bool flag6 = GameCanvas.isPointerSelect && GameCanvas.isPoint(this.xCurBegin, this.yCurBegin, this.wCur, this.hCur);
				if (flag6)
				{
					int num = (GameCanvas.py - (this.yCurBegin + this.miniItem + GameCanvas.hText * 3 / 2) + this.listAttri.cmx) / this.hItem;
					bool flag7 = num >= 0 && num < Player.mAttribute.Length;
					if (flag7)
					{
						this.IdSelect = num;
						this.timefocus = 5;
						bool flag8 = Player.pointAttribute > 0;
						if (flag8)
						{
							this.cmdSetPoint.perform();
						}
					}
					GameCanvas.isPointerSelect = false;
				}
			}
		}
		base.updatePointer();
	}

	// Token: 0x06000EDC RID: 3804 RVA: 0x0000C066 File Offset: 0x0000A266
	public static void updateTabAttri(Main_Attribute[] att)
	{
		TabInfo.isshow = false;
		Player.mAttribute = att;
		TabInfo.isshow = true;
	}

	// Token: 0x06000EDD RID: 3805 RVA: 0x0011F2BC File Offset: 0x0011D4BC
	public override void updateChangeTabInfo()
	{
		bool flag = this.levelTab == 0;
		if (flag)
		{
			this.levelTab = 1;
		}
		else
		{
			this.levelTab = 0;
		}
		this.xto = this.wCur;
		this.speed = 20;
		this.xcur = 0;
		this.initCmd();
	}

	// Token: 0x04001907 RID: 6407
	public const int LEVEL_TIEMNANG = 1;

	// Token: 0x04001908 RID: 6408
	public const int LEVEL_THONGTIN = 0;

	// Token: 0x04001909 RID: 6409
	private iCommand cmdSetPoint;

	// Token: 0x0400190A RID: 6410
	private InputDialog input;

	// Token: 0x0400190B RID: 6411
	private ListNew listInfo;

	// Token: 0x0400190C RID: 6412
	private ListNew listAttri;

	// Token: 0x0400190D RID: 6413
	private int lastCam;

	// Token: 0x0400190E RID: 6414
	private int xBeginInfo;

	// Token: 0x0400190F RID: 6415
	private Scroll scrInfo = new Scroll();

	// Token: 0x04001910 RID: 6416
	private Scroll scrAttri = new Scroll();

	// Token: 0x04001911 RID: 6417
	private int xto;

	// Token: 0x04001912 RID: 6418
	private int xcur;

	// Token: 0x04001913 RID: 6419
	private int speed = 20;

	// Token: 0x04001914 RID: 6420
	private int hItem;

	// Token: 0x04001915 RID: 6421
	private int timefocus;

	// Token: 0x04001916 RID: 6422
	private int[] mNumAttri = new int[]
	{
		1,
		2,
		10
	};

	// Token: 0x04001917 RID: 6423
	public static bool isshow = true;
}
