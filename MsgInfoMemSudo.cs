using System;

// Token: 0x020000A7 RID: 167
public class MsgInfoMemSudo : MsgDialog
{
	// Token: 0x06000A3D RID: 2621 RVA: 0x000CFAF8 File Offset: 0x000CDCF8
	public MsgInfoMemSudo(InfoMemList mem)
	{
		this.mem = mem;
		bool flag = mem == null;
		if (!flag)
		{
			this.cmdList.removeAllElements();
			this.cmdClose = new iCommand(T.close, 1, this);
			mSystem.outz("mem.name = " + mem.name + " GameScreen.player.name " + GameScreen.player.name);
			bool flag2 = mem.name.CompareTo(GameScreen.player.name) != 0;
			if (flag2)
			{
				this.cmdGiaoTiep = new iCommand(T.Giaotiep, 2, this);
				this.cmdKick = new iCommand(T.kickClan, 10, this);
				this.cmdDonate = new iCommand(T.strDonate, 4, this);
				this.cmdInfo = new iCommand(T.strclanMyInfo, 5, this);
				this.cmdChat = new iCommand(T.TroChuyen, 6, this);
				this.cmdAddFriend = new iCommand(T.addFriend, 7, this);
				this.cmdPhongChuc = new iCommand(T.phongchuc, 8, this);
				this.cmdList.addElement(this.cmdGiaoTiep);
			}
			else
			{
				mSystem.outz("Player.ChucInSudo " + Player.ChucInSudo.ToString() + " mem.chucInSudo " + mem.chucInSudo.ToString());
				bool flag3 = Player.ChucInSudo != 1 && Player.ChucInSudo == 2;
				if (flag3)
				{
					this.cmdLeave = new iCommand(T.leaveSudo, 11, this);
					this.cmdList.addElement(this.cmdLeave);
				}
			}
			bool flag4 = !GameCanvas.isTouch;
			if (flag4)
			{
				this.cmdList.addElement(this.cmdClose);
			}
			this.wDia = 160;
			this.hDia = 140;
			bool flag5 = !GameCanvas.isTouch;
			if (flag5)
			{
				this.hDia += GameCanvas.hCommand + 10;
			}
			this.xDia = MotherCanvas.hw - this.wDia / 2;
			this.yDia = MotherCanvas.hh - this.hDia / 2;
			this.wItem = 27;
			base.setPosCmdNew(15, false);
			bool isTouch = GameCanvas.isTouch;
			if (isTouch)
			{
				this.cmdList.addElement(this.cmdClose);
				this.cmdClose.setPos(MotherCanvas.hw + (this.wDia - 50) / 2, this.yDia - GameCanvas.hCommand / 2, MainTab.fraCloseTab, string.Empty);
			}
			this.backCMD = this.cmdClose;
		}
	}

	// Token: 0x06000A3E RID: 2622 RVA: 0x000CFD80 File Offset: 0x000CDF80
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 1:
			GameCanvas.end_Dialog();
			break;
		case 2:
		{
			mVector mVector = new mVector();
			mVector.addElement(this.cmdInfo);
			mVector.addElement(this.cmdChat);
			mVector.addElement(this.cmdAddFriend);
			bool flag = Player.ChucInSudo == 1;
			if (flag)
			{
				mVector.addElement(this.cmdKick);
			}
			GameCanvas.menu.startAt(mVector, 2, this.mem.name);
			break;
		}
		case 3:
			GlobalService.gI().Sudo_CMD(16, this.mem.name, (int)((short)this.mem.id), 0);
			GameCanvas.end_Dialog();
			break;
		case 4:
			GlobalService.gI().Clan_CMD(2, this.mem.name, (int)((short)this.mem.id), 0);
			break;
		case 5:
			GameCanvas.gameScr.ShowInfoOtherPlayer(this.mem.name);
			break;
		case 6:
			GameCanvas.gameScr.ShowChatTab(this.mem.name);
			break;
		case 7:
			GlobalService.gI().Friend(0, this.mem.id);
			break;
		case 8:
		{
			mVector mVector2 = new mVector();
			bool flag2 = Player.ChucInCLan == 0;
			if (flag2)
			{
				iCommand o = new iCommand(T.thuyenpho, 13, 1, this);
				iCommand o2 = new iCommand(T.hoatieu, 13, 2, this);
				iCommand o3 = new iCommand(T.thanhvien, 13, 10, this);
				mVector2.addElement(o);
				mVector2.addElement(o2);
				mVector2.addElement(o3);
			}
			bool flag3 = Player.ChucInCLan == 1;
			if (flag3)
			{
				iCommand o4 = new iCommand(T.hoatieu, 13, 2, this);
				iCommand o5 = new iCommand(T.thanhvien, 13, 10, this);
				mVector2.addElement(o4);
				mVector2.addElement(o5);
			}
			GameCanvas.menu.startAt(mVector2, 2, this.mem.name);
			break;
		}
		case 9:
			GlobalService.gI().Sudo_CMD(17, string.Empty, (int)((short)this.mem.id), 0);
			GameCanvas.end_Dialog();
			break;
		case 10:
			GameCanvas.Start_Normal_DiaLog(T.banmuon + this.mem.name + " " + T.roiSudo, new iCommand(T.kickClan, 3, this), true);
			break;
		case 11:
			GameCanvas.Start_Normal_DiaLog(T.banmuon + T.roiSudo, new iCommand(T.leaveSudo, 9, this), true);
			break;
		case 12:
			GlobalService.gI().Clan_CMD(15, string.Empty, 0, 0);
			GameCanvas.end_Dialog();
			break;
		case 13:
			GlobalService.gI().Clan_CMD(3, this.mem.name, (int)((short)this.mem.id), (sbyte)subIndex);
			break;
		case 14:
		{
			GameCanvas.end_Dialog();
			GameCanvas.tabShopScr = new TabScreen(MainTab.xTab, 0);
			mVector mVector3 = new mVector();
			GameCanvas.tabShopScr.isShopClan = true;
			GameCanvas.tabInvenClan = new TabInventory(T.Khobang, Player.vecInvenClan, 4, MainTab.xTab);
			GameCanvas.tabInvenClan.initCmd();
			mVector3.addElement(GameCanvas.tabInvenClan);
			GameCanvas.tabShopScr.addVecTab(mVector3);
			GameCanvas.tabShopScr.idSelect = 0;
			GameCanvas.tabShopScr.Show(GameCanvas.ClanScr);
			GameCanvas.tabShopScr.typeCurrent = 1;
			GameCanvas.tabShopScr.setTabSelect();
			break;
		}
		case 15:
		{
			bool flag4 = this.input == null;
			if (flag4)
			{
				this.input = new InputDialog();
				iCommand cmd = new iCommand(T.chat, 16, this);
				this.input.setinfo(T.nhapNoiDung, cmd, false, T.WorldChanel);
			}
			else
			{
				this.input.tfInput.setText(string.Empty);
			}
			GameCanvas.Start_Sub_Dialog(this.input);
			break;
		}
		case 16:
			GlobalService.gI().World_Chanel(1, this.input.tfInput.getText());
			GameCanvas.end_Dialog();
			break;
		case 17:
			GlobalService.gI().Send_Type(-95, 1);
			break;
		}
	}

	// Token: 0x06000A3F RID: 2623 RVA: 0x000D01DC File Offset: 0x000CE3DC
	public override void paint(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		int num = this.yDia + 4;
		int num2 = this.xDia + this.miniItem * 3;
		base.paintPaper_UpDown(g, this.xDia - 5, this.yDia - 32, this.maxWShow + 10, this.hDia + 44, this.maxWShow + 10);
		g.setColor(15972174);
		g.fillRoundRect(this.xDia + this.wDia / 2 - this.sizeBanner / 2, this.yDia - 20, this.sizeBanner, 16, 4, 4);
		AvMain.FontBorderColor(g, T.info, this.xDia + this.maxWShow / 2, this.yDia - 18, 2, 6, 5);
		MainObject.paintHeadEveryWhere(g, this.mem.head, this.mem.hair, this.mem.hat, num2 + this.miniItem * 2, num + this.miniItem + 45, 2);
		AvMain.FontBorderColor(g, this.mem.name, num2 + this.miniItem * 2 + 16, num + this.miniItem / 2, 0, 0, 7);
		mFont.tahoma_7b_black.drawString(g, this.mem.getCaptionSudo(this.mem.chucInSudo), num2 + this.miniItem * 2 + 16, num + GameCanvas.hText - 1, 0);
		mFont.tahoma_7b_black.drawString(g, T.capdo + ": " + this.mem.Lv.ToString(), num2, num + GameCanvas.hText * 2 - 1, 0);
		mFont.tahoma_7b_black.drawString(g, T.diemSudo + ": " + this.mem.expSudo, num2, num + GameCanvas.hText * 3 - 1, 0);
		bool flag = this.cmdList != null;
		if (flag)
		{
			for (int i = 0; i < this.cmdList.size(); i++)
			{
				iCommand iCommand = (iCommand)this.cmdList.elementAt(i);
				iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
			}
		}
	}

	// Token: 0x06000A40 RID: 2624 RVA: 0x000CF88C File Offset: 0x000CDA8C
	public override void update()
	{
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
		}
	}

	// Token: 0x06000A41 RID: 2625 RVA: 0x000CF8D0 File Offset: 0x000CDAD0
	public override void updatekey()
	{
		bool flag = GameCanvas.keyMove(0);
		if (flag)
		{
			bool flag2 = this.idCommand > 0;
			if (flag2)
			{
				this.idCommand--;
			}
			else
			{
				this.idCommand = this.cmdList.size() - 1;
			}
			GameCanvas.ClearkeyMove(0);
		}
		else
		{
			bool flag3 = GameCanvas.keyMove(2);
			if (flag3)
			{
				bool flag4 = this.idCommand < this.cmdList.size() - 1;
				if (flag4)
				{
					this.idCommand++;
				}
				else
				{
					this.idCommand = 0;
				}
				GameCanvas.ClearkeyMove(2);
			}
			else
			{
				bool flag5 = GameCanvas.keyMyHold[5];
				if (flag5)
				{
					GameCanvas.clearKeyHold(5);
					bool flag6 = this.cmdList != null && this.idCommand < this.cmdList.size();
					if (flag6)
					{
						((iCommand)this.cmdList.elementAt(this.idCommand)).perform();
					}
				}
			}
		}
		bool flag7 = GameCanvas.isTouchNoOrPC();
		if (flag7)
		{
			bool flag8 = this.idCommand >= 0 && this.idCommand < this.cmdList.size();
			if (flag8)
			{
				iCommand iCommand = (iCommand)this.cmdList.elementAt(this.idCommand);
				bool flag9 = iCommand.caption.Length == 0;
				if (flag9)
				{
					this.idCommand = 0;
				}
			}
			for (int i = 0; i < this.cmdList.size(); i++)
			{
				iCommand iCommand2 = (iCommand)this.cmdList.elementAt(i);
				bool flag10 = i == this.idCommand;
				if (flag10)
				{
					iCommand2.isSelect = true;
				}
				else
				{
					iCommand2.isSelect = false;
				}
			}
		}
		this.updatekeyPC();
	}

	// Token: 0x06000A42 RID: 2626 RVA: 0x000CFA9C File Offset: 0x000CDC9C
	public override void updatePointer()
	{
		base.updatePointer();
		bool flag = this.cmdList != null;
		if (flag)
		{
			for (int i = 0; i < this.cmdList.size(); i++)
			{
				iCommand iCommand = (iCommand)this.cmdList.elementAt(i);
				iCommand.updatePointer();
			}
		}
	}

	// Token: 0x04001016 RID: 4118
	private InfoMemList mem;

	// Token: 0x04001017 RID: 4119
	private int sizeBanner = 120;

	// Token: 0x04001018 RID: 4120
	private iCommand cmdGiaoTiep;

	// Token: 0x04001019 RID: 4121
	private iCommand cmdKick;

	// Token: 0x0400101A RID: 4122
	private iCommand cmdPhongChuc;

	// Token: 0x0400101B RID: 4123
	private iCommand cmdDonate;

	// Token: 0x0400101C RID: 4124
	private iCommand cmdInfo;

	// Token: 0x0400101D RID: 4125
	private iCommand cmdChat;

	// Token: 0x0400101E RID: 4126
	private iCommand cmdAddFriend;

	// Token: 0x0400101F RID: 4127
	private iCommand cmdLeave;

	// Token: 0x04001020 RID: 4128
	private iCommand cmdGopRuby;

	// Token: 0x04001021 RID: 4129
	private iCommand cmdInven;

	// Token: 0x04001022 RID: 4130
	private iCommand cmdWorld;

	// Token: 0x04001023 RID: 4131
	private iCommand cmdIconClan;

	// Token: 0x04001024 RID: 4132
	private InputDialog input;
}
