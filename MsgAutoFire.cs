using System;

// Token: 0x0200009F RID: 159
public class MsgAutoFire : MsgDialog
{
	// Token: 0x060009E8 RID: 2536 RVA: 0x000C8500 File Offset: 0x000C6700
	public override void commandPointer(int index, int subIndex)
	{
		bool flag = index != 9;
		if (!flag)
		{
			this.isClose = true;
			bool flag2 = this.valueFire == 0;
			if (flag2)
			{
				Player.typeAutoFireMain = 1;
				bool flag3 = Player.AutoFireCur == 2;
				if (flag3)
				{
					Player.AutoFireCur = 1;
				}
			}
			else
			{
				bool flag4 = this.valueFire == 1;
				if (flag4)
				{
					Player.typeAutoFireMain = 2;
					bool flag5 = Player.AutoFireCur == 1;
					if (flag5)
					{
						Player.AutoFireCur = 2;
					}
				}
				else
				{
					Player.typeAutoFireMain = -1;
					Player.AutoFireCur = -1;
				}
			}
			bool flag6 = MsgAutoFire.value != null;
			if (flag6)
			{
				Player.typeAutoBuff = 0;
				for (int i = 0; i < MsgAutoFire.value.Length; i++)
				{
					bool flag7 = MsgAutoFire.value[i][1] == 1;
					if (flag7)
					{
						Player.typeAutoBuff = 1;
					}
				}
			}
			Player.AutoRevice = (sbyte)this.valueRevice;
			GameCanvas.saveRms.SaveAutoFire();
		}
	}

	// Token: 0x060009E9 RID: 2537 RVA: 0x000C85F4 File Offset: 0x000C67F4
	public void setinfoAuto_Fire()
	{
		this.fontDia = mFont.tahoma_7b_black;
		base.beginDia();
		this.cmdList = new mVector();
		this.cmdOK = new iCommand(T.xong, 9, this);
		this.cmdList.addElement(this.cmdOK);
		this.wDia = MotherCanvas.w;
		bool flag = this.wDia > 180;
		if (flag)
		{
			this.wDia = 180;
		}
		this.maxWShow = this.wDia;
		this.wShowPaper = 5;
		this.hItem = 28;
		this.wItem = 24;
		this.hDia = 160;
		int num = 0;
		short[] array = new short[10];
		for (int i = 0; i < Player.vecListSkill.size(); i++)
		{
			Skill_Info skill_Info = (Skill_Info)Player.vecListSkill.elementAt(i);
			bool flag2 = skill_Info.Lv_RQ >= 0 && skill_Info.typeSkill == 2;
			if (flag2)
			{
				array[num] = skill_Info.ID;
				num++;
			}
		}
		bool flag3 = num > 0;
		if (flag3)
		{
			MsgAutoFire.value = new short[num][];
			for (int j = 0; j < MsgAutoFire.value.Length; j++)
			{
				MsgAutoFire.value[j] = new short[2];
				MsgAutoFire.value[j][0] = array[j];
				MsgAutoFire.value[j][1] = 1;
			}
		}
		bool flag4 = num > 3;
		if (flag4)
		{
			this.hDia += this.hItem;
		}
		this.xDia = MotherCanvas.hw - this.wDia / 2;
		this.yDia = MotherCanvas.hh - this.hDia / 2 - 5;
		this.indexBuff = 0;
		this.valueRevice = (int)Player.AutoRevice;
		this.xbeginSkill = this.fontDia.getWidth(T.fire);
		this.xbeginBuff = this.fontDia.getWidth(T.buff);
		base.setPosCmdNew(-2, false);
	}

	// Token: 0x060009EA RID: 2538 RVA: 0x000C87F0 File Offset: 0x000C69F0
	public override void paint(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		int num = this.yDia;
		int num2 = this.xDia + 15;
		base.paintPaper(g, MotherCanvas.hw - this.wShowPaper / 2, num, this.wShowPaper, this.hDia, this.maxWShow, (int)AvMain.PAPER_NORMAL);
		g.setClip(MotherCanvas.hw - this.wShowPaper / 2, 0, this.wShowPaper, MotherCanvas.h);
		g.saveCanvas();
		g.ClipRec(MotherCanvas.hw - this.wShowPaper / 2, 0, this.wShowPaper, MotherCanvas.h);
		num += 12;
		g.setColor(15972174);
		g.fillRoundRect(this.xDia + 10, num, this.wDia - 20, 16, 4, 4);
		num += 3;
		AvMain.FontBorderColor(g, T.setting, this.xDia + this.wDia / 2, num, 2, 6, 5);
		int num3 = (MsgAutoFire.value != null) ? ((MsgAutoFire.value.Length - 1) / 3) : 0;
		num += this.hItem;
		bool flag = GameCanvas.isTouchNoOrPC() && this.idSelect < 3;
		if (flag)
		{
			int h = this.hItem;
			int y = num - this.hItem / 4 - 1 + this.idSelect * this.hItem;
			bool flag2 = this.idSelect == 1;
			if (flag2)
			{
				h = this.hItem * (num3 + 1);
			}
			bool flag3 = this.idSelect == 2;
			if (flag3)
			{
				y = num - this.hItem / 4 - 1 + (this.idSelect + num3) * this.hItem;
			}
			this.paintSelect(g, this.xDia, y, this.wDia, h);
		}
		mFont.tahoma_7b_brown.drawString(g, T.fire, num2, num, 0);
		AvMain.Font3dColor(g, " " + T.mAutoFire[this.valueFire], num2 + this.xbeginSkill, num, 0, 0, 7);
		num += this.hItem;
		mFont.tahoma_7b_brown.drawString(g, T.buff, num2, num, 0);
		bool flag4 = MsgAutoFire.value == null;
		if (flag4)
		{
			mFont.tahoma_7_black.drawString(g, " " + T.buffnull, num2 + this.xbeginBuff, num, 0);
		}
		else
		{
			for (int i = 0; i < MsgAutoFire.value.Length; i++)
			{
				Skill_Info skillFromID = Skill_Info.getSkillFromID(MsgAutoFire.value[i][0]);
				int num4 = num2 + this.xbeginBuff + this.wItem / 2 + (this.wItem + 8) * (i % 3);
				int num5 = num + this.wItem / 4 + i / 3 * this.hItem;
				bool flag5 = this.idSelect == 1 && this.indexBuff == i;
				if (flag5)
				{
					g.setColor(16777215);
					g.drawRect(num4 - this.hItem / 2 - 1, num5 - this.hItem / 2 - 1, this.hItem + 1, this.hItem);
					g.setColor(0);
					g.drawRect(num4 - this.hItem / 2, num5 - this.hItem / 2, this.hItem - 2 + 1, this.hItem - 2);
				}
				Skill_Info.paintIcon(g, num4, num5, skillFromID.idIcon, skillFromID.LvDevilSkill);
				bool flag6 = MsgAutoFire.value[i][1] == 0;
				if (flag6)
				{
					AvMain.fraDelay2.drawFrame(0, num4, num5, 0, 3, g);
				}
			}
		}
		num += this.hItem * (num3 + 1);
		g.drawImage(AvMain.imgBorderCombo, num2 + 5, num + 5, 3);
		bool flag7 = this.valueRevice == 1;
		if (flag7)
		{
			AvMain.fraCheck.drawFrame(2, num2 + 5, num + 5, 0, 3, g);
		}
		mFont.tahoma_7b_brown.drawString(g, T.autoRevice, num2 + 15, num, 0);
		base.paintInfoHelp(g);
		bool flag8 = this.cmdList != null;
		if (flag8)
		{
			for (int j = 0; j < this.cmdList.size(); j++)
			{
				iCommand iCommand = (iCommand)this.cmdList.elementAt(j);
				iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
			}
		}
		g.restoreCanvas();
	}

	// Token: 0x060009EB RID: 2539 RVA: 0x0000B302 File Offset: 0x00009502
	public override void paintSelect(mGraphics g, int xbegin, int ybegin, int wFocus, int hFocus)
	{
		g.setColor(16774758);
		g.fillRect(xbegin + this.miniItem, ybegin, wFocus - this.miniItem * 2, hFocus);
	}

	// Token: 0x060009EC RID: 2540 RVA: 0x000C8C44 File Offset: 0x000C6E44
	public override void update()
	{
		base.updateInfoHelp();
		bool isClose = this.isClose;
		if (isClose)
		{
			base.updateClose();
		}
		else
		{
			base.updateOpen();
			bool flag = GameCanvas.isTouchNoOrPC();
			if (flag)
			{
				this.updatekey();
			}
			this.updatePointer();
			bool flag2 = GameCanvas.isTouchNoOrPC();
			if (flag2)
			{
				bool flag3 = this.idSelect == 3;
				if (flag3)
				{
					this.cmdOK.isSelect = true;
				}
				else
				{
					this.cmdOK.isSelect = false;
				}
			}
		}
	}

	// Token: 0x060009ED RID: 2541 RVA: 0x000C8CC4 File Offset: 0x000C6EC4
	public override void updatekey()
	{
		bool flag = GameCanvas.keyMove(1);
		if (flag)
		{
			bool flag2 = this.idSelect > 0;
			if (flag2)
			{
				this.idSelect--;
			}
			GameCanvas.ClearkeyMove(1);
		}
		else
		{
			bool flag3 = GameCanvas.keyMove(3);
			if (flag3)
			{
				bool flag4 = this.idSelect < 3;
				if (flag4)
				{
					this.idSelect++;
				}
				GameCanvas.ClearkeyMove(3);
			}
			else
			{
				bool flag5 = GameCanvas.keyMove(0);
				if (flag5)
				{
					this.setSelect(-1);
					GameCanvas.ClearkeyMove(0);
				}
				else
				{
					bool flag6 = GameCanvas.keyMove(2);
					if (flag6)
					{
						this.setSelect(1);
						GameCanvas.ClearkeyMove(2);
					}
					else
					{
						bool flag7 = GameCanvas.keyMyHold[5];
						if (flag7)
						{
							GameCanvas.clearKeyHold(5);
							bool flag8 = this.idSelect == 1;
							if (flag8)
							{
								bool flag9 = MsgAutoFire.value != null;
								if (flag9)
								{
									bool flag10 = MsgAutoFire.value[this.indexBuff][1] == 0;
									if (flag10)
									{
										MsgAutoFire.value[this.indexBuff][1] = 1;
									}
									else
									{
										MsgAutoFire.value[this.indexBuff][1] = 0;
									}
									Skill_Info skillFromID = Skill_Info.getSkillFromID(MsgAutoFire.value[this.indexBuff][0]);
									bool flag11 = skillFromID != null;
									if (flag11)
									{
										base.setInfoHelp(T.mHelpAutoFire[(int)(3 + MsgAutoFire.value[this.indexBuff][1])] + skillFromID.name);
									}
								}
							}
							else
							{
								bool flag12 = this.idSelect == 3 && this.cmdList != null && this.idCommand < this.cmdList.size();
								if (flag12)
								{
									((iCommand)this.cmdList.elementAt(this.idCommand)).perform();
								}
							}
						}
					}
				}
			}
		}
		this.updatekeyPC();
	}

	// Token: 0x060009EE RID: 2542 RVA: 0x000C8E9C File Offset: 0x000C709C
	public void setSelect(int plus)
	{
		bool flag = this.idSelect == 0;
		if (flag)
		{
			this.valueFire += plus;
			bool flag2 = this.valueFire < 0;
			if (flag2)
			{
				this.valueFire = 0;
			}
			bool flag3 = this.valueFire >= T.mAutoFire.Length;
			if (flag3)
			{
				this.valueFire = T.mAutoFire.Length - 1;
			}
			string text = T.mHelpAutoFire[this.valueFire];
			bool flag4 = this.valueFire == 1;
			if (flag4)
			{
				Skill_Info skill_Info = (Skill_Info)Player.vecListSkill.elementAt(0);
				bool flag5 = skill_Info != null;
				if (flag5)
				{
					text += skill_Info.name;
				}
			}
			base.setInfoHelp(text);
		}
		else
		{
			bool flag6 = this.idSelect == 1;
			if (flag6)
			{
				bool flag7 = MsgAutoFire.value != null;
				if (flag7)
				{
					this.indexBuff += plus;
					bool flag8 = this.indexBuff < 0;
					if (flag8)
					{
						this.indexBuff = 0;
					}
					bool flag9 = this.indexBuff >= MsgAutoFire.value.Length;
					if (flag9)
					{
						this.indexBuff = MsgAutoFire.value.Length - 1;
					}
				}
			}
			else
			{
				bool flag10 = this.idSelect == 2;
				if (flag10)
				{
					bool flag11 = this.valueRevice == 0;
					if (flag11)
					{
						this.valueRevice = 1;
					}
					else
					{
						this.valueRevice = 0;
					}
					base.setInfoHelp(T.helpAutoRevice);
				}
			}
		}
	}

	// Token: 0x060009EF RID: 2543 RVA: 0x000C9014 File Offset: 0x000C7214
	public override void updatePointer()
	{
		int num = this.yDia;
		int num2 = this.xDia + 15;
		num += 15 + this.wItem - this.wItem / 4;
		bool isPointerSelect = GameCanvas.isPointerSelect;
		if (isPointerSelect)
		{
			bool flag = GameCanvas.isPoint(num2 + 10, num, this.wDia, this.hItem);
			if (flag)
			{
				this.valueFire++;
				bool flag2 = this.valueFire >= T.mAutoFire.Length;
				if (flag2)
				{
					this.valueFire = 0;
				}
				string text = T.mHelpAutoFire[this.valueFire];
				GameCanvas.isPointerSelect = false;
				bool flag3 = this.valueFire == 1;
				if (flag3)
				{
					Skill_Info skill_Info = (Skill_Info)Player.vecListSkill.elementAt(0);
					bool flag4 = skill_Info != null;
					if (flag4)
					{
						text += skill_Info.name;
					}
				}
				base.setInfoHelp(text);
			}
			int num3 = (MsgAutoFire.value != null) ? ((MsgAutoFire.value.Length - 1) / 3) : 0;
			int num4 = (num3 + 1) * this.hItem;
			bool flag5 = GameCanvas.isPoint(num2 + 10, num + this.hItem, this.wDia, num4) && MsgAutoFire.value != null;
			if (flag5)
			{
				bool flag6 = MsgAutoFire.value != null;
				if (flag6)
				{
					for (int i = 0; i < MsgAutoFire.value.Length; i++)
					{
						int num5 = num2 + this.xbeginBuff + (this.wItem + 8) * (i % 3);
						int y = num + this.hItem - this.wItem / 4 + i / 3 * this.hItem;
						bool flag7 = GameCanvas.isPoint(num5 - 4, y, this.hItem + 8, this.hItem);
						if (flag7)
						{
							bool flag8 = MsgAutoFire.value[i][1] == 0;
							if (flag8)
							{
								MsgAutoFire.value[i][1] = 1;
							}
							else
							{
								MsgAutoFire.value[i][1] = 0;
							}
							Skill_Info skillFromID = Skill_Info.getSkillFromID(MsgAutoFire.value[i][0]);
							bool flag9 = skillFromID != null;
							if (flag9)
							{
								base.setInfoHelp(T.mHelpAutoFire[(int)(3 + MsgAutoFire.value[i][1])] + skillFromID.name);
							}
						}
					}
				}
				GameCanvas.isPointerSelect = false;
			}
			bool flag10 = GameCanvas.isPoint(num2, num + this.hItem + num4, this.wDia, this.hItem);
			if (flag10)
			{
				bool flag11 = this.valueRevice == 0;
				if (flag11)
				{
					this.valueRevice = 1;
				}
				else
				{
					this.valueRevice = 0;
				}
				base.setInfoHelp(T.helpAutoRevice);
				GameCanvas.isPointerSelect = false;
			}
		}
		base.updatePointer();
	}

	// Token: 0x04000FA4 RID: 4004
	private int hItem;

	// Token: 0x04000FA5 RID: 4005
	private int valueFire;

	// Token: 0x04000FA6 RID: 4006
	private int valueRevice;

	// Token: 0x04000FA7 RID: 4007
	public static short[][] value;

	// Token: 0x04000FA8 RID: 4008
	private int xbeginSkill;

	// Token: 0x04000FA9 RID: 4009
	private int xbeginBuff;

	// Token: 0x04000FAA RID: 4010
	private int indexBuff;

	// Token: 0x04000FAB RID: 4011
	private iCommand cmdOK;
}
