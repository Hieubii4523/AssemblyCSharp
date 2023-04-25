using System;

// Token: 0x02000104 RID: 260
public class TabSkill : MainTab
{
	// Token: 0x06000F1D RID: 3869 RVA: 0x0012343C File Offset: 0x0012163C
	public TabSkill(string name)
	{
		this.nameTab = name;
		this.initCmd();
		this.list = new ListNew();
		this.indexIconTab = 3;
		this.wItemCur = 32;
		bool isBigScreen = this.isBigScreen;
		if (isBigScreen)
		{
			this.wItemCur = 36;
		}
		this.marName = new MarqueeText(this.wCur - (this.wItemCur + this.miniItem * 2 + 3));
	}

	// Token: 0x06000F1E RID: 3870 RVA: 0x001234D4 File Offset: 0x001216D4
	public override void beginFocus()
	{
		this.skillCur = null;
		int limX = (Player.vecListSkill.size() + 1) * this.wItemCur - this.hCur + this.miniItem * 3 + this.wItemCur * 2;
		this.list = new ListNew(this.xCurBegin, this.yCurBegin, this.wCur, this.hCur, 0, 0, limX, true);
		this.scrSkill.setInfo(this.xCurBegin + this.wCur + this.miniItem, this.yCurBegin + this.miniItem / 2, this.hCur - this.miniItem * 2, 8809550);
		TabSkill.indexPassive = 0;
		TabSkill.indexJob = 0;
		TabSkill.numCurrentPassive = 0;
		for (int i = 0; i < Player.vecListSkill.size(); i++)
		{
			Skill_Info skill_Info = (Skill_Info)Player.vecListSkill.elementAt(i);
			bool flag = skill_Info.typeSkill == 1 || skill_Info.typeSkill == 4 || skill_Info.typeSkill == 2;
			if (flag)
			{
				TabSkill.indexPassive++;
				TabSkill.indexJob++;
			}
			else
			{
				bool flag2 = skill_Info.typeSkill == 3;
				if (flag2)
				{
					bool flag3 = skill_Info.Lv_RQ >= 0 && skill_Info.typeDevil == 0;
					if (flag3)
					{
						TabSkill.numCurrentPassive++;
					}
					TabSkill.indexJob++;
				}
			}
		}
		this.isShowInfo = false;
		bool flag4 = GameCanvas.isTouchNoOrPC();
		if (flag4)
		{
			this.IdSelect = 0;
			this.getSkillCur();
		}
		else
		{
			this.IdSelect = -1;
			this.setPosCmd(null);
		}
	}

	// Token: 0x06000F1F RID: 3871 RVA: 0x0000C141 File Offset: 0x0000A341
	private void initCmd()
	{
		TabSkill.cmdSetPoint = new iCommand(T.congDiem, 0, this);
		TabSkill.cmdSetHotKey = new iCommand(T.cmdHotKey, 3, this);
	}

	// Token: 0x06000F20 RID: 3872 RVA: 0x00123680 File Offset: 0x00121880
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
		{
			bool flag = this.skillCur != null;
			if (flag)
			{
				bool flag2 = Player.mLvSkill[(int)this.skillCur.indexHotKey] >= Skill_Info.maxLv;
				if (flag2)
				{
					GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.maxLvSkill);
					this.vecCmd = this.skillCur.getActionInven();
				}
				else
				{
					bool flag3 = Player.pointSkill > 1;
					if (flag3)
					{
						this.input = GameCanvas.Start_Input_Dialog(T.nhappoint, new iCommand(T.cmdSetPoint, 1, 0, this), true, T.congDiem);
						GameCanvas.subDialog = this.input;
					}
					else
					{
						bool flag4 = Player.pointSkill == 1;
						if (flag4)
						{
							this.commandPointer(2, 0);
						}
					}
				}
			}
			break;
		}
		case 1:
		{
			bool flag5 = this.skillCur == null;
			if (!flag5)
			{
				bool flag6 = subIndex == 0;
				if (flag6)
				{
					int num = 1;
					try
					{
						num = int.Parse(this.input.tfInput.getText());
						bool flag7 = num < 0;
						if (flag7)
						{
							num = 1;
						}
					}
					catch (Exception)
					{
						num = 1;
					}
					GlobalService.gI().Add_Point_Skill(this.skillCur.indexHotKey, (short)num);
					GameCanvas.end_Dialog();
				}
				else
				{
					GlobalService.gI().Add_Point_Skill(this.skillCur.indexHotKey, 1);
					GameCanvas.end_Dialog();
				}
			}
			break;
		}
		case 2:
			GameCanvas.Start_Normal_DiaLog(T.add1Point, new iCommand(T.congDiem, 1, 1, this), true);
			break;
		case 3:
		{
			bool flag8 = this.skillCur == null || this.skillCur.Lv_RQ <= 0;
			if (!flag8)
			{
				bool flag9 = this.skillCur != null && ((LoadMap.specMap == 4 && this.skillCur.typeSkill == 1) || (LoadMap.specMap != 4 && this.skillCur.typeSkill == 4));
				if (flag9)
				{
					GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.khongdungduocmapnay);
				}
				else
				{
					mVector mVector = new mVector();
					for (int i = 0; i < 6; i++)
					{
						bool flag10 = i != 2 && (GameCanvas.isTouch || i != 5);
						if (flag10)
						{
							iCommand o = GameCanvas.isTouch ? new iCommand(T.keys + " " + (i + 1).ToString(), 4, i, this) : ((!TField.isQwerty) ? new iCommand(T.keys + " " + (i * 2 + 1).ToString(), 4, i, this) : new iCommand(T.keys + " " + T.mKeyQty[i], 4, i, this));
							mVector.addElement(o);
						}
					}
					GameCanvas.menu.startAt(mVector, 2, T.cmdHotKey);
				}
			}
			break;
		}
		case 4:
		{
			bool flag11 = this.skillCur != null;
			if (flag11)
			{
				Player.setHotKey(subIndex, new MainSkill(this.skillCur.ID, -1)
				{
					indexHotKey = this.skillCur.indexHotKey,
					idIcon = this.skillCur.idIcon,
					isBuff = (this.skillCur.typeSkill == 2)
				}, null);
				Interface_Game.timePaintIconSkill = 100;
			}
			break;
		}
		}
	}

	// Token: 0x06000F21 RID: 3873 RVA: 0x00123A04 File Offset: 0x00121C04
	public override void paint(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		AvMain.paintRect(g, this.xCurBegin, this.yCurBegin, this.wCur, this.hCur - this.miniItem, 0, 4);
		g.saveCanvas();
		g.ClipRec(this.xCurBegin + 2, this.yCurBegin + 1, this.wCur - 4, this.hCur - 1 - this.miniItem - 1);
		this.setClip(g);
		int miniItem = this.miniItem;
		int num = 0;
		AvMain.Font3dWhite(g, T.skillActive, miniItem, num + this.wItemCur / 2 - 2, 0);
		num += this.wItemCur;
		bool flag = this.IdSelect >= 0 && this.IdSelect < Player.vecListSkill.size() && GameCanvas.currentScreen.setCurTypetab(1);
		if (flag)
		{
			this.paintSelect(g);
		}
		int num2 = this.list.cmx / this.wItemCur - 2;
		int num3 = this.hCur / this.wItemCur + 1 + num2;
		for (int i = 0; i < Player.vecListSkill.size(); i++)
		{
			bool flag2 = i >= num2 && i <= num3;
			if (flag2)
			{
				Skill_Info skill_Info = (Skill_Info)Player.vecListSkill.elementAt(i);
				string st = skill_Info.name;
				bool flag3 = skill_Info.Lv_RQ == -1;
				if (flag3)
				{
					AvMain.fraQuest.drawFrame(3, miniItem + this.wItemCur / 2, num + this.wItemCur / 2, 0, 3, g);
					st = T.skillnew;
				}
				else
				{
					skill_Info.paint(g, miniItem + this.wItemCur / 2, num + this.wItemCur / 2);
				}
				bool flag4 = skill_Info.Lv_RQ == (short)Skill_Info.maxLv;
				if (flag4)
				{
					st = skill_Info.name + T.max;
				}
				bool flag5 = skill_Info.Lv_RQ < 0;
				if (flag5)
				{
					mFont.tahoma_7b_blue.drawString(g, st, miniItem + this.wItemCur + this.miniItem, num + this.miniItem / 2 + 1, 0);
				}
				else
				{
					bool flag6 = this.IdSelect == i && GameCanvas.currentScreen.setCurTypetab(1) && this.marName.isRun;
					if (flag6)
					{
						g.setClip(miniItem + this.wItemCur + this.miniItem, num, this.marName.maxW - 1, this.wItemCur);
						mFont.tahoma_7b_white.drawString(g, st, miniItem + this.wItemCur + this.miniItem - this.marName.xplus, num + this.miniItem / 2 + 1, 0);
						this.setClip(g);
					}
					else
					{
						mFont.tahoma_7b_white.drawString(g, st, miniItem + this.wItemCur + this.miniItem, num + this.miniItem / 2 + 1, 0);
					}
				}
				bool flag7 = skill_Info.Lv_RQ == -1;
				if (flag7)
				{
					mFont.tahoma_7_blue.drawString(g, T.gapGrap, miniItem + this.wItemCur + this.miniItem, num + this.miniItem / 2 + GameCanvas.hText + 1, 0);
				}
				else
				{
					bool flag8 = skill_Info.typeDevil == 1;
					if (flag8)
					{
						string st2 = string.Empty;
						st2 = ((skill_Info.typeSkill == 1) ? T.devilfruitA : ((skill_Info.typeSkill != 3) ? T.devilfruitB : T.devilfruitP));
						mFont.tahoma_7_green.drawString(g, st2, miniItem + this.wItemCur + this.miniItem, num + this.miniItem / 2 + GameCanvas.hText + 1, 0);
					}
					else
					{
						bool flag9 = skill_Info.typeSkill == 3 || skill_Info.typeSkill == 2;
						if (flag9)
						{
							mFont.tahoma_7_green.drawString(g, string.Concat(new string[]
							{
								T.Lv,
								": ",
								skill_Info.Lv_RQ.ToString(),
								" ",
								skill_Info.getStrType()
							}), miniItem + this.wItemCur + this.miniItem, num + this.miniItem / 2 + GameCanvas.hText + 1, 0);
						}
						else
						{
							bool flag10 = skill_Info.Lv_RQ >= (short)Skill_Info.maxLv;
							if (flag10)
							{
								mFont.tahoma_7_green.drawString(g, T.maxLv, miniItem + this.wItemCur + this.miniItem, num + this.miniItem / 2 + GameCanvas.hText + 1, 0);
							}
							else
							{
								bool isSmallScreen = GameCanvas.isSmallScreen;
								if (isSmallScreen)
								{
									mFont.tahoma_7_green.drawString(g, string.Concat(new string[]
									{
										T.Lv,
										": ",
										skill_Info.Lv_RQ.ToString(),
										"+",
										MainItem.strGetPercent((int)skill_Info.percentLv, 1)
									}), miniItem + this.wItemCur + this.miniItem, num + this.miniItem / 2 + GameCanvas.hText + 1, 0);
								}
								else
								{
									mFont.tahoma_7_green.drawString(g, T.Lv + ": " + skill_Info.Lv_RQ.ToString(), miniItem + this.wItemCur + this.miniItem, num + this.miniItem / 2 + GameCanvas.hText + 1, 0);
									Interface_Game.PaintHPMP(g, 3, (int)skill_Info.percentLv, 100, miniItem + this.wItemCur * 2, num + this.miniItem / 2 + GameCanvas.hText + 1, 0, this.miniItem * 2, this.wCur / 2, 1, false, 0, false, 0);
								}
							}
						}
					}
					bool flag11 = skill_Info.phanTramDevilSkill > 0;
					if (flag11)
					{
						int num4 = (int)(skill_Info.phanTramDevilSkill / 5);
						num4 = ((num4 < 20) ? (num4 + 1) : ((num4 != 20) ? 22 : (num4 + 2)));
						g.drawRegion(AvMain.imgLvDevilSkill, 0, 22 - num4, 22, num4, 0, (float)(miniItem + this.wItemCur / 2), (float)(num + this.wItemCur / 2 + 11), 33);
					}
				}
			}
			num += this.wItemCur;
			bool flag12 = i == TabSkill.indexPassive - 1;
			if (flag12)
			{
				AvMain.Font3dWhite(g, string.Concat(new string[]
				{
					T.skillPassive,
					": ",
					TabSkill.numCurrentPassive.ToString(),
					"/",
					Player.numPassive.ToString()
				}), miniItem, num + this.wItemCur / 2 - 6, 0);
				num += this.wItemCur;
			}
			bool flag13 = i == TabSkill.indexJob - 1;
			if (flag13)
			{
				AvMain.Font3dWhite(g, T.skillJob, miniItem, num + this.wItemCur / 2 - 6, 0);
				num += this.wItemCur;
			}
		}
		mGraphics.resetTransAndroid(g);
		g.restoreCanvas();
		GameCanvas.resetTrans(g);
		bool flag14 = !GameCanvas.currentScreen.setCurTypetab(1);
		if (!flag14)
		{
			bool flag15 = this.list.cmxLim > 0;
			if (flag15)
			{
				this.scrSkill.paint(g);
			}
			bool flag16 = this.isShowInfo && this.skillCur != null;
			if (flag16)
			{
				bool isLv = false;
				bool flag17 = this.skillCur.typeSkill == 1 || this.skillCur.typeSkill == 4;
				if (flag17)
				{
					isLv = true;
				}
				base.ShowInfo(g, this.skillCur, null, 0, this.xInfo, this.yInfo, isLv, null, 0);
			}
			bool flag18 = this.vecCmd != null && GameCanvas.getShowCmd();
			if (flag18)
			{
				for (int j = 0; j < this.vecCmd.size(); j++)
				{
					iCommand iCommand = (iCommand)this.vecCmd.elementAt(j);
					iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
				}
			}
			base.paint(g);
		}
	}

	// Token: 0x06000F22 RID: 3874 RVA: 0x001241EC File Offset: 0x001223EC
	public void setClip(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		g.setClip(this.xCurBegin + 2, this.yCurBegin + 1, this.wCur - 4, this.hCur - 1 - this.miniItem - 1);
		g.translate(this.xCurBegin, this.yCurBegin);
		g.translate(0, -this.list.cmx);
	}

	// Token: 0x06000F23 RID: 3875 RVA: 0x00124258 File Offset: 0x00122458
	public void paintSelect(mGraphics g)
	{
		int num = this.wItemCur;
		bool flag = this.IdSelect >= TabSkill.indexPassive;
		if (flag)
		{
			num += this.wItemCur;
		}
		bool flag2 = this.IdSelect >= TabSkill.indexJob;
		if (flag2)
		{
			num += this.wItemCur;
		}
		g.setColor(16446420);
		g.fillRect(this.miniItem / 2, num + this.IdSelect * this.wItemCur, 1, this.wItemCur);
		g.fillRect(this.wCur - this.miniItem / 2 - 1, num + this.IdSelect * this.wItemCur, 1, this.wItemCur);
		g.fillRect(this.miniItem / 2 + 1, num + this.IdSelect * this.wItemCur - 1, this.wCur - this.miniItem - 1, 1);
		g.fillRect(this.miniItem / 2 + 1, num + this.IdSelect * this.wItemCur + this.wItemCur, this.wCur - this.miniItem - 1, 1);
	}

	// Token: 0x06000F24 RID: 3876 RVA: 0x00124374 File Offset: 0x00122574
	public override void update()
	{
		int cmx = this.list.cmx;
		this.list.moveCamera();
		this.scrSkill.setYScrool(this.list.cmx, this.list.cmxLim);
		bool flag = this.list.cmx != cmx || this.list.pointerIsDowning;
		if (flag)
		{
			this.isShowInfo = false;
		}
		else
		{
			bool flag2 = this.skillCur != null;
			if (flag2)
			{
				this.updateShowInfo();
			}
		}
		this.marName.update2();
	}

	// Token: 0x06000F25 RID: 3877 RVA: 0x0012440C File Offset: 0x0012260C
	public override void updatekey()
	{
		bool flag = false;
		bool flag2 = GameCanvas.keyMove(1);
		if (flag2)
		{
			this.IdSelect--;
			GameCanvas.ClearkeyMove(1);
			flag = true;
		}
		else
		{
			bool flag3 = GameCanvas.keyMove(3);
			if (flag3)
			{
				this.IdSelect++;
				GameCanvas.ClearkeyMove(3);
				flag = true;
			}
		}
		bool flag4 = GameCanvas.keyMove(0) || GameCanvas.keyMove(2);
		if (flag4)
		{
			GameCanvas.currentScreen.setTypeTab(0);
			GameCanvas.ClearkeyMove(0);
			GameCanvas.ClearkeyMove(2);
		}
		bool flag5 = flag;
		if (flag5)
		{
			this.IdSelect = AvMain.resetSelect(this.IdSelect, Player.vecListSkill.size() - 1, false);
			bool flag6 = this.IdSelect >= 0;
			if (flag6)
			{
				bool flag7 = GameCanvas.isTouchNoOrPC();
				if (flag7)
				{
					int num = (this.IdSelect + 2) * this.wItemCur - this.hCur / 2;
					bool flag8 = this.IdSelect >= TabSkill.indexPassive;
					if (flag8)
					{
						num += this.wItemCur;
					}
					bool flag9 = this.IdSelect >= TabSkill.indexJob;
					if (flag9)
					{
						num += this.wItemCur;
					}
					this.list.setToX(num);
				}
				this.getSkillCur();
				this.isShowInfo = false;
			}
			else
			{
				this.skillCur = null;
			}
		}
		base.updatekey();
		this.updatekeyPC();
	}

	// Token: 0x06000F26 RID: 3878 RVA: 0x00124578 File Offset: 0x00122778
	public override void updatePointer()
	{
		this.list.update_Pos_UP_DOWN();
		bool flag = GameCanvas.isPointerSelect && Player.vecListSkill.size() > 0 && GameCanvas.isPoint(this.xCurBegin, this.yCurBegin, this.wCur, this.hCur);
		if (flag)
		{
			int num = (GameCanvas.py - this.yCurBegin + this.list.cmx) / this.wItemCur;
			bool flag2 = num != 0 && num != TabSkill.indexPassive + 1 && num != TabSkill.indexJob + 1;
			if (flag2)
			{
				num = ((num > TabSkill.indexJob) ? (num - 3) : ((num <= TabSkill.indexPassive) ? (num - 1) : (num - 2)));
				bool flag3 = num != this.IdSelect && num >= 0 && num < Player.vecListSkill.size();
				if (flag3)
				{
					this.IdSelect = num;
					this.getSkillCur();
				}
			}
			GameCanvas.isPointerSelect = false;
		}
		bool flag4 = this.vecCmd != null;
		if (flag4)
		{
			for (int i = 0; i < this.vecCmd.size(); i++)
			{
				iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
				iCommand.updatePointer();
			}
		}
		base.updatePointer();
	}

	// Token: 0x06000F27 RID: 3879 RVA: 0x001246C0 File Offset: 0x001228C0
	public void getSkillCur()
	{
		bool flag = this.IdSelect < 0 || this.IdSelect >= Player.vecListSkill.size();
		if (!flag)
		{
			Skill_Info skill_Info = (Skill_Info)Player.vecListSkill.elementAt(this.IdSelect);
			bool flag2 = skill_Info.Lv_RQ == -1;
			if (flag2)
			{
				this.skillCur = null;
			}
			else
			{
				bool flag3 = this.skillCur == null || this.skillCur != skill_Info;
				if (flag3)
				{
					this.skillCur = skill_Info;
					bool flag4 = this.skillCur != null;
					if (flag4)
					{
						this.setPosCmd(this.skillCur.getActionInven());
					}
					this.marName.setdata(skill_Info.name, mFont.tahoma_7b_black);
				}
			}
		}
	}

	// Token: 0x06000F28 RID: 3880 RVA: 0x00124788 File Offset: 0x00122988
	public override void setPosInfo()
	{
		bool flag = this.skillCur.Lv_RQ != -1;
		if (flag)
		{
			bool flag2 = this.skillCur != null;
			if (flag2)
			{
				this.skillCur.setVecInfo(this.skillCur.wInfo);
			}
			this.setPosInfo(this.skillCur, this.xCurBegin + MainTab.wTab, this.yCurBegin + (this.IdSelect + 1) * this.wItemCur - this.list.cmx + 1 + this.miniItem * 2);
		}
	}

	// Token: 0x06000F29 RID: 3881 RVA: 0x0012481C File Offset: 0x00122A1C
	public void setPosCmd(mVector vec)
	{
		this.left = null;
		this.center = null;
		this.vecCmd.removeAllElements();
		bool flag = vec == null || MainTab.bigInfo > 0;
		if (!flag)
		{
			bool isTouch = GameCanvas.isTouch;
			if (isTouch)
			{
				this.vecCmd = vec;
				for (int i = 0; i < this.vecCmd.size(); i++)
				{
					iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
					iCommand = AvMain.setPosCMD(iCommand, i);
					bool flag2 = i == 0;
					if (flag2)
					{
						this.okCMD = iCommand;
					}
					bool flag3 = i == 1;
					if (flag3)
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
	}

	// Token: 0x0400195A RID: 6490
	private Skill_Info skillCur;

	// Token: 0x0400195B RID: 6491
	private mVector vecCmd = new mVector();

	// Token: 0x0400195C RID: 6492
	public static iCommand cmdSetPoint;

	// Token: 0x0400195D RID: 6493
	public static iCommand cmdSetHotKey;

	// Token: 0x0400195E RID: 6494
	private InputDialog input;

	// Token: 0x0400195F RID: 6495
	private ListNew list;

	// Token: 0x04001960 RID: 6496
	private ListNew listLong;

	// Token: 0x04001961 RID: 6497
	private MarqueeText marName = new MarqueeText(0);

	// Token: 0x04001962 RID: 6498
	private Scroll scrSkill = new Scroll();

	// Token: 0x04001963 RID: 6499
	public static int indexPassive;

	// Token: 0x04001964 RID: 6500
	public static int indexJob;

	// Token: 0x04001965 RID: 6501
	public static int numCurrentPassive;

	// Token: 0x04001966 RID: 6502
	public static int numbuffSkill;
}
