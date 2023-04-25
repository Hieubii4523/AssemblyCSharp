using System;

// Token: 0x020000A9 RID: 169
public class MsgOtherCharInfo : MsgDialog
{
	// Token: 0x06000A4D RID: 2637 RVA: 0x000D0D48 File Offset: 0x000CEF48
	public MsgOtherCharInfo(MainObject obj)
	{
		this.obj = obj;
		this.cmdfight = null;
		bool flag = obj == null;
		if (!flag)
		{
			this.cmdList.removeAllElements();
			this.cmdClose = new iCommand(T.close, 1, this);
			this.cmdClose = AvMain.setPosCMD(this.cmdClose, 2);
			bool flag2 = MsgOtherCharInfo.infoFight != null && MsgOtherCharInfo.infoFight.name.CompareTo(this.obj.name) == 0;
			if (flag2)
			{
				this.cmdfight = new iCommand(T.chapnhan, 2, this);
				this.cmdfight = AvMain.setPosCMD(this.cmdfight, 0);
				this.cmdfight = AvMain.setPosCMD(this.cmdfight, 1);
				this.left = this.cmdfight;
			}
			this.right = this.cmdClose;
			this.wDia = 160;
			this.yLechChar = 0;
			bool flag3 = obj.hOne > 52;
			if (flag3)
			{
				this.yLechChar += obj.hOne - 52;
			}
			bool flag4 = obj.indexFullSet > 0;
			if (flag4)
			{
				this.yLechChar += 15;
			}
			this.hDia = 140;
			bool flag5 = this.yLechChar > 15;
			if (flag5)
			{
				this.hDia += this.yLechChar - 15;
			}
			this.xDia = MotherCanvas.hw - this.wDia / 2;
			this.yDia = MotherCanvas.hh - this.hDia / 2;
			this.wItem = 27;
			this.mposEquip = new int[TabEquip.maxEquip][];
			int num = this.yDia + this.wItem - 7 + 15;
			int num2 = this.xDia + this.wDia / 6 - this.wItem / 2;
			for (int i = 0; i < this.mposEquip.Length; i++)
			{
				this.mposEquip[i] = new int[2];
				int num3 = i;
				int num4 = num3;
				if (num4 != 8)
				{
					if (num4 != 9)
					{
						this.mposEquip[i][0] = num2 + i % 2 * (this.wDia / 3 * 2 + 2);
						this.mposEquip[i][1] = num - this.wItem / 2 + i / 2 * this.wItem;
					}
					else
					{
						this.mposEquip[i][0] = num2 + i % 2 * (this.wDia / 3 * 2 + 2) - this.wItem * 5 / 4;
						this.mposEquip[i][1] = num - this.wItem / 2 + i / 2 * this.wItem - this.wItem + this.wItem / 4;
					}
				}
				else
				{
					this.mposEquip[i][0] = num2 + i % 2 * (this.wDia / 3 * 2 + 2) + this.wItem * 5 / 4;
					this.mposEquip[i][1] = num - this.wItem / 2 + i / 2 * this.wItem - this.wItem + this.wItem / 4;
				}
			}
			bool isTouch = GameCanvas.isTouch;
			if (isTouch)
			{
				this.idSelect = -1;
				this.cmdClose.setPos(this.xDia + this.maxWShow / 2 + this.sizeBanner / 2, this.yDia - 20 + 8, MainTab.fraCloseTab, string.Empty);
				this.cmdList.addElement(this.cmdClose);
				bool flag6 = this.cmdfight != null;
				if (flag6)
				{
					this.cmdfight = AvMain.setPosCMD(this.cmdfight, 0);
					this.cmdList.addElement(this.cmdfight);
				}
			}
			else
			{
				this.hDia += 10;
				this.isShowInfo = false;
				this.itemCur = (MainItem)obj.hashEquip.get(string.Empty + this.idSelect.ToString());
			}
			this.backCMD = this.cmdClose;
			this.isCheckTop = false;
		}
	}

	// Token: 0x06000A4E RID: 2638 RVA: 0x000D1160 File Offset: 0x000CF360
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
			this.doMenu();
			MsgOtherCharInfo.infoFight = null;
			break;
		case 1:
			GameCanvas.end_Dialog();
			MsgOtherCharInfo.infoFight = null;
			break;
		case 2:
		{
			bool flag = MsgOtherCharInfo.infoFight == null;
			if (flag)
			{
				return;
			}
			GlobalService.gI().Fight(1, (short)MsgOtherCharInfo.infoFight.id, 0);
			bool flag2 = GameCanvas.eventScr.vecPlayer == null;
			if (flag2)
			{
				return;
			}
			for (int i = 0; i < GameCanvas.eventScr.vecPlayer.size(); i++)
			{
				InfoMemList infoMemList = (InfoMemList)GameCanvas.eventScr.vecPlayer.elementAt(i);
				bool flag3 = infoMemList == MsgOtherCharInfo.infoFight;
				if (flag3)
				{
					GameCanvas.eventScr.vecPlayer.removeElement(infoMemList);
					break;
				}
			}
			return;
		}
		}
		base.commandPointer(index, subIndex);
	}

	// Token: 0x06000A4F RID: 2639 RVA: 0x000090B5 File Offset: 0x000072B5
	private void doMenu()
	{
	}

	// Token: 0x06000A50 RID: 2640 RVA: 0x000D1258 File Offset: 0x000CF458
	public override void paint(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		int num = this.yDia + 4;
		int num2 = this.xDia + this.wDia / 2;
		base.paintPaper_UpDown(g, this.xDia - 5, this.yDia - 32, this.maxWShow + 10, this.hDia + 44, this.maxWShow + 10);
		g.setColor(15972174);
		g.fillRoundRect(this.xDia + this.wDia / 2 - this.sizeBanner / 2, this.yDia - 20, this.sizeBanner, 16, 4, 4);
		AvMain.FontBorderColor(g, this.obj.name, this.xDia + this.maxWShow / 2, this.yDia - 18, 2, 6, 5);
		g.setClip(MotherCanvas.hw - this.maxWShow / 2, this.yDia, this.maxWShow, this.hDia);
		g.saveCanvas();
		g.ClipRec(MotherCanvas.hw - this.maxWShow / 2, this.yDia, this.maxWShow, this.hDia);
		num += 4;
		bool flag = this.obj.clan != null;
		if (flag)
		{
			MainImage iconClan = Potion.getIconClan(this.obj.clan.idIcon);
			bool flag2 = iconClan != null && iconClan.img != null;
			if (flag2)
			{
				int num3 = -mFont.tahoma_7b_black.getWidth(this.obj.clan.name) / 2;
				bool flag3 = iconClan.frame == -1;
				if (flag3)
				{
					iconClan.set_Frame();
				}
				bool flag4 = iconClan.frame <= 1;
				if (flag4)
				{
					g.drawImage(iconClan.img, this.xDia + this.wDia / 2 + num3, num, 3);
				}
				else
				{
					int num4 = (this.framepaint < (int)(iconClan.frame - 1)) ? 3 : 15;
					bool flag5 = CRes.abs(GameCanvas.gameTick - this.lastTick) > num4;
					if (flag5)
					{
						this.framepaint++;
						bool flag6 = this.framepaint >= (int)iconClan.frame;
						if (flag6)
						{
							this.framepaint = 0;
						}
						this.lastTick = GameCanvas.gameTick;
					}
					g.drawRegion(iconClan.img, 0, this.framepaint * (int)iconClan.w, (int)iconClan.w, (int)iconClan.w, 0, (float)(this.xDia + this.wDia / 2 + num3), (float)num, 3);
				}
				num3 = 9;
				mFont.tahoma_7b_black.drawString(g, this.obj.clan.name, this.xDia + this.wDia / 2 + num3, num - 6, 2);
			}
		}
		num += 15;
		int num5 = 47;
		mImage image = (this.obj.Lv != 100) ? Interface_Game.imgIconMPHP : Interface_Game.imgIconMPHP2;
		g.drawImage(image, num2 - num5 + 7, num, 0);
		Interface_Game.PaintHPMP(g, 1, this.obj.Hp, this.obj.maxHp, num2 - num5 + 18, num, 0, 9, 66, 0, false, 0, false, (int)this.obj.lvHeart);
		num += 11;
		Interface_Game.PaintHPMP(g, 2, this.obj.Mp, this.obj.maxMp, num2 - num5 + 18, num, 0, 9, 66, 0, false, 0, false, 0);
		num += 9;
		bool flag7 = this.obj.Lv == 100;
		int num6;
		if (flag7)
		{
			mFont.tahoma_7_black.drawString(g, string.Concat(new string[]
			{
				this.obj.LvThongThao.ToString(),
				" + ",
				(this.obj.percentThongThao / 10).ToString(),
				",",
				(this.obj.percentThongThao % 10).ToString(),
				"%"
			}), num2 - num5 + 20, num, 0);
			num += 10;
			num6 = this.obj.percentThongThao / 10 * 70 / 100;
		}
		else
		{
			mFont.tahoma_7_black.drawString(g, string.Concat(new string[]
			{
				this.obj.Lv.ToString(),
				" + ",
				(this.obj.percentLv / 10).ToString(),
				",",
				(this.obj.percentLv % 10).ToString(),
				"%"
			}), num2 - num5 + 20, num, 0);
			num += 10;
			num6 = this.obj.percentLv / 10 * 70 / 100;
		}
		g.setColor(1258003);
		g.fillRect(num2 - num5 + 18, num, 65, 2);
		bool flag8 = num6 > 0;
		if (flag8)
		{
			g.setColor(3514158);
			g.fillRect(num2 - num5 + 18, num, num6, 2);
		}
		for (int i = 1; i < 5; i++)
		{
			g.setColor(16777215);
			g.fillRect(num2 - num5 + 18 + i * 13, num, 1, 2);
		}
		for (int j = 0; j < TabEquip.maxEquip; j++)
		{
			int index = 3;
			bool flag9 = j < 8;
			if (flag9)
			{
				AvMain.paintRect(g, this.mposEquip[j][0] - 1, this.mposEquip[j][1] - 1, this.wItem - 2, this.wItem - 2, 0, index);
			}
			MainItem mainItem = (MainItem)this.obj.hashEquip.get(string.Empty + j.ToString());
			bool flag10 = mainItem != null;
			if (flag10)
			{
				mainItem.paintColor(g, this.mposEquip[j][0] + this.wItem / 2 - 1, this.mposEquip[j][1] + this.wItem / 2 - 1, this.wItem - 3);
				mainItem.paint(g, this.mposEquip[j][0] + this.wItem / 2 - 1, this.mposEquip[j][1] + this.wItem / 2 - 1, this.wItem, 1);
			}
			bool flag11 = this.idSelect == j;
			if (flag11)
			{
				g.setColor(16777215);
				g.drawRect(this.mposEquip[j][0], this.mposEquip[j][1], this.wItem - 4, this.wItem - 4);
				g.drawRect(this.mposEquip[j][0] + 1, this.mposEquip[j][1] + 1, this.wItem - 6, this.wItem - 6);
			}
		}
		this.obj.paintThanhTich(g, num + 26 + this.yLechChar, this.xDia + this.wDia / 2);
		num += 50 + this.yLechChar;
		this.obj.paintCharShow(g, this.xDia + this.wDia / 2, num, 0, true);
		mGraphics.resetTransAndroid(g);
		g.restoreCanvas();
		GameCanvas.resetTrans(g);
		bool flag12 = this.cmdList != null;
		if (flag12)
		{
			for (int k = 0; k < this.cmdList.size(); k++)
			{
				iCommand iCommand = (iCommand)this.cmdList.elementAt(k);
				iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
			}
		}
		base.paintCmd(g);
		bool flag13 = this.isShowInfo && this.itemCur != null;
		if (flag13)
		{
			MainTab.paintInfoEveryWhere(g, this.itemCur, null, 0, this.xInfo, this.yInfo, this.itemCur.wInfo, this.itemCur.hInfo, false, this.obj, 0);
		}
	}

	// Token: 0x06000A51 RID: 2641 RVA: 0x000D1A58 File Offset: 0x000CFC58
	public override void update()
	{
		bool flag = this.itemCur != null && !this.isShowInfo;
		if (flag)
		{
			this.timeShowInfo++;
			bool flag2 = this.timeShowInfo >= 10;
			if (flag2)
			{
				this.isShowInfo = true;
				this.setPosInfo(this.itemCur, this.mposEquip[this.idSelect][0] + this.wItem / 2, this.mposEquip[this.idSelect][1] + this.wItem);
			}
		}
		bool flag3 = !this.isCheckTop;
		if (flag3)
		{
			this.isCheckTop = true;
			for (int i = 0; i < GameScreen.vecPlayers.size(); i++)
			{
				MainObject mainObject = (MainObject)GameScreen.vecPlayers.elementAt(i);
				bool flag4 = mainObject != null && !mainObject.isRemove && mainObject.typeObject == 0 && mainObject.name.CompareTo(this.obj.name) == 0;
				if (flag4)
				{
					this.obj.thanhtichLv = mainObject.thanhtichLv;
					this.obj.thanhtichPvP = mainObject.thanhtichPvP;
					bool flag5 = this.obj.thanhtichLv >= 0;
					if (flag5)
					{
						this.ylechthanhtich += 15;
					}
					bool flag6 = this.obj.thanhtichPvP >= 0;
					if (flag6)
					{
						this.ylechthanhtich += 15;
					}
					bool flag7 = this.ylechthanhtich > this.yLechChar;
					if (flag7)
					{
						this.yLechChar = this.ylechthanhtich;
					}
					return;
				}
			}
		}
		base.update();
	}

	// Token: 0x06000A52 RID: 2642 RVA: 0x000D1C10 File Offset: 0x000CFE10
	public override void updatekey()
	{
		bool flag = false;
		int idSelect = this.idSelect;
		bool flag2 = this.idSelect == -1 && (GameCanvas.keyMove(0) || GameCanvas.keyMove(2) || GameCanvas.keyMove(1) || GameCanvas.keyMove(3));
		if (flag2)
		{
			this.idSelect = 0;
			GameCanvas.clearKeyHold();
			flag = true;
		}
		bool flag3 = GameCanvas.keyMove(0);
		if (flag3)
		{
			this.idSelect--;
			GameCanvas.ClearkeyMove(0);
			flag = true;
		}
		else
		{
			bool flag4 = GameCanvas.keyMove(2);
			if (flag4)
			{
				this.idSelect++;
				GameCanvas.ClearkeyMove(2);
				flag = true;
			}
			else
			{
				bool flag5 = GameCanvas.keyMove(1);
				if (flag5)
				{
					bool flag6 = this.idSelect >= 2;
					if (flag6)
					{
						this.idSelect -= 2;
					}
					GameCanvas.ClearkeyMove(1);
					flag = true;
				}
				else
				{
					bool flag7 = GameCanvas.keyMove(3);
					if (flag7)
					{
						bool flag8 = this.idSelect < TabEquip.maxEquip - 2;
						if (flag8)
						{
							this.idSelect += 2;
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
			bool flag10 = this.idSelect == 8;
			if (flag10)
			{
				MainItem mainItem = (MainItem)this.obj.hashEquip.get(string.Empty + this.idSelect.ToString());
				bool flag11 = mainItem == null;
				if (flag11)
				{
					mainItem = (MainItem)this.obj.hashEquip.get(string.Empty + 9.ToString());
					bool flag12 = mainItem == null;
					if (flag12)
					{
						this.idSelect = idSelect;
						return;
					}
					this.idSelect = 9;
				}
			}
			else
			{
				bool flag13 = this.idSelect == 9;
				if (flag13)
				{
					MainItem mainItem2 = (MainItem)this.obj.hashEquip.get(string.Empty + this.idSelect.ToString());
					bool flag14 = mainItem2 == null;
					if (flag14)
					{
						mainItem2 = (MainItem)this.obj.hashEquip.get(string.Empty + 8.ToString());
						bool flag15 = mainItem2 == null;
						if (flag15)
						{
							this.idSelect = idSelect;
							return;
						}
						this.idSelect = 8;
					}
				}
			}
			bool flag16 = this.idSelect < 0 || this.idSelect >= TabEquip.maxEquip;
			if (flag16)
			{
				this.idSelect = -1;
				this.isShowInfo = false;
				this.itemCur = null;
			}
			else
			{
				bool flag17 = idSelect != this.idSelect;
				if (flag17)
				{
					this.isShowInfo = false;
					this.itemCur = (MainItem)this.obj.hashEquip.get(string.Empty + this.idSelect.ToString());
				}
			}
		}
		base.updatekey();
	}

	// Token: 0x06000A53 RID: 2643 RVA: 0x000D1F00 File Offset: 0x000D0100
	public override void updatePointer()
	{
		bool flag = this.cmdList != null;
		if (flag)
		{
			for (int i = 0; i < this.cmdList.size(); i++)
			{
				iCommand iCommand = (iCommand)this.cmdList.elementAt(i);
				iCommand.updatePointer();
			}
		}
		bool isPointerSelect = GameCanvas.isPointerSelect;
		if (isPointerSelect)
		{
			bool flag2 = true;
			for (int j = 0; j < TabEquip.maxEquip; j++)
			{
				bool flag3 = j == 8 || j == 9;
				if (flag3)
				{
					MainItem mainItem = (MainItem)GameScreen.player.hashEquip.get(string.Empty + j.ToString());
					bool flag4 = mainItem == null;
					if (flag4)
					{
						GameCanvas.isPointerSelect = false;
						break;
					}
				}
				bool flag5 = GameCanvas.isPointSelect(this.mposEquip[j][0] - 2, this.mposEquip[j][1] - 2, this.wItem, this.wItem);
				if (flag5)
				{
					flag2 = false;
					bool flag6 = j != this.idSelect;
					if (flag6)
					{
						this.idSelect = j;
						this.itemCur = (MainItem)this.obj.hashEquip.get(string.Empty + this.idSelect.ToString());
						this.isShowInfo = false;
					}
					GameCanvas.isPointerSelect = false;
					break;
				}
			}
			bool flag7 = flag2;
			if (flag7)
			{
				this.itemCur = null;
				this.isShowInfo = false;
				this.idSelect = -1;
			}
		}
		base.updatePointer();
	}

	// Token: 0x06000A54 RID: 2644 RVA: 0x000D2094 File Offset: 0x000D0294
	public void setPosInfo(MainItem item, int xbe, int ybe)
	{
		int num = 100;
		int num2 = 40;
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

	// Token: 0x0400102D RID: 4141
	private MainObject obj;

	// Token: 0x0400102E RID: 4142
	private int sizeBanner = 120;

	// Token: 0x0400102F RID: 4143
	private int timeShowInfo;

	// Token: 0x04001030 RID: 4144
	private int[][] mposEquip;

	// Token: 0x04001031 RID: 4145
	private MainItem itemCur;

	// Token: 0x04001032 RID: 4146
	private int xInfo;

	// Token: 0x04001033 RID: 4147
	private int yInfo;

	// Token: 0x04001034 RID: 4148
	private int ylechthanhtich;

	// Token: 0x04001035 RID: 4149
	private int yLechChar;

	// Token: 0x04001036 RID: 4150
	private bool isShowInfo;

	// Token: 0x04001037 RID: 4151
	private bool isCheckTop;

	// Token: 0x04001038 RID: 4152
	public static InfoMemList infoFight;

	// Token: 0x04001039 RID: 4153
	private iCommand cmdfight;

	// Token: 0x0400103A RID: 4154
	private int lastTick;

	// Token: 0x0400103B RID: 4155
	private int framepaint;
}
