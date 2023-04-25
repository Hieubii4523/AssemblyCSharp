using System;

// Token: 0x020000A6 RID: 166
public class MsgInfoMemClan : MsgDialog
{
	// Token: 0x06000A37 RID: 2615 RVA: 0x000CED70 File Offset: 0x000CCF70
	public MsgInfoMemClan(InfoMemList mem)
	{
		this.mem = mem;
		bool flag = mem == null;
		if (!flag)
		{
			this.cmdList.removeAllElements();
			this.cmdClose = new iCommand(T.close, 1, this);
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
				this.cmdList.addElement(this.cmdDonate);
				this.cmdList.addElement(this.cmdGiaoTiep);
			}
			else
			{
				bool flag3 = Player.ChucInCLan == 0;
				if (flag3)
				{
					this.cmdInven = new iCommand(T.Khobang, 14, this);
					this.cmdList.addElement(this.cmdInven);
					this.cmdWorld = new iCommand(T.WorldChanel, 15, this);
					this.cmdList.addElement(this.cmdWorld);
					this.cmdIconClan = new iCommand(T.khoHuyHieu, 17, this);
					this.cmdList.addElement(this.cmdIconClan);
				}
				else
				{
					bool flag4 = Player.ChucInCLan == 1;
					if (flag4)
					{
						this.cmdInven = new iCommand(T.Khobang, 14, this);
						this.cmdList.addElement(this.cmdInven);
						this.cmdLeave = new iCommand(T.leaveClan, 11, this);
						this.cmdList.addElement(this.cmdLeave);
						this.cmdWorld = new iCommand(T.WorldChanel, 15, this);
						this.cmdList.addElement(this.cmdWorld);
					}
					else
					{
						this.cmdLeave = new iCommand(T.leaveClan, 11, this);
						this.cmdList.addElement(this.cmdLeave);
					}
				}
				this.cmdGopRuby = new iCommand(T.donggop, 12, this);
				this.cmdList.addElement(this.cmdGopRuby);
			}
			bool flag5 = !GameCanvas.isTouch;
			if (flag5)
			{
				this.cmdList.addElement(this.cmdClose);
			}
			this.wDia = 160;
			this.hDia = 140;
			bool flag6 = Player.ChucInCLan == 1 || Player.ChucInCLan == 0;
			if (flag6)
			{
				this.hDia += GameCanvas.hCommand + 10;
			}
			else
			{
				bool flag7 = !GameCanvas.isTouch;
				if (flag7)
				{
					this.hDia += GameCanvas.hCommand + 10;
				}
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

	// Token: 0x06000A38 RID: 2616 RVA: 0x000CF104 File Offset: 0x000CD304
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
			bool flag = Player.ChucInCLan == 0 || Player.ChucInCLan == 1;
			if (flag)
			{
				mVector.addElement(this.cmdPhongChuc);
				mVector.addElement(this.cmdKick);
			}
			GameCanvas.menu.startAt(mVector, 2, this.mem.name);
			break;
		}
		case 3:
			GlobalService.gI().Clan_CMD(1, this.mem.name, (int)((short)this.mem.id), 0);
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
			GlobalService.gI().Clan_CMD(4, string.Empty, (int)((short)this.mem.id), 0);
			GameCanvas.end_Dialog();
			break;
		case 10:
			GameCanvas.Start_Normal_DiaLog(T.banmuon + this.mem.name + " " + T.khoibang, new iCommand(T.kickClan, 3, this), true);
			break;
		case 11:
			GameCanvas.Start_Normal_DiaLog(T.banmuon + T.khoibang, new iCommand(T.leaveClan, 9, this), true);
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

	// Token: 0x06000A39 RID: 2617 RVA: 0x000CF574 File Offset: 0x000CD774
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
		mFont.tahoma_7b_black.drawString(g, this.mem.getCaptionClan(this.mem.chucInClan), num2 + this.miniItem * 2 + 16, num + GameCanvas.hText - 1, 0);
		mFont.tahoma_7b_black.drawString(g, T.capdo + ": " + this.mem.Lv.ToString(), num2, num + GameCanvas.hText * 2 - 1, 0);
		mFont.tahoma_7b_black.drawString(g, T.tangqua + ": " + this.mem.numTangqua.ToString(), num2, num + GameCanvas.hText * 3 - 1, 0);
		mFont.tahoma_7b_black.drawString(g, T.nhiemvu + ": " + this.mem.numQuest.ToString(), num2, num + GameCanvas.hText * 4 - 1, 0);
		mFont.tahoma_7b_black.drawString(g, string.Concat(new string[]
		{
			T.donggop,
			": ",
			this.mem.gopRuby.ToString(),
			" ",
			T.ruby
		}), num2, num + GameCanvas.hText * 5 - 1, 0);
		mFont.tahoma_7b_black.drawString(g, string.Concat(new string[]
		{
			T.congHien,
			": ",
			this.mem.congHien.ToString(),
			" ",
			T.diem
		}), num2, num + GameCanvas.hText * 6 - 1, 0);
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

	// Token: 0x06000A3A RID: 2618 RVA: 0x000CF88C File Offset: 0x000CDA8C
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

	// Token: 0x06000A3B RID: 2619 RVA: 0x000CF8D0 File Offset: 0x000CDAD0
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

	// Token: 0x06000A3C RID: 2620 RVA: 0x000CFA9C File Offset: 0x000CDC9C
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

	// Token: 0x04001007 RID: 4103
	private InfoMemList mem;

	// Token: 0x04001008 RID: 4104
	private int sizeBanner = 120;

	// Token: 0x04001009 RID: 4105
	private iCommand cmdGiaoTiep;

	// Token: 0x0400100A RID: 4106
	private iCommand cmdKick;

	// Token: 0x0400100B RID: 4107
	private iCommand cmdPhongChuc;

	// Token: 0x0400100C RID: 4108
	private iCommand cmdDonate;

	// Token: 0x0400100D RID: 4109
	private iCommand cmdInfo;

	// Token: 0x0400100E RID: 4110
	private iCommand cmdChat;

	// Token: 0x0400100F RID: 4111
	private iCommand cmdAddFriend;

	// Token: 0x04001010 RID: 4112
	private iCommand cmdLeave;

	// Token: 0x04001011 RID: 4113
	private iCommand cmdGopRuby;

	// Token: 0x04001012 RID: 4114
	private iCommand cmdInven;

	// Token: 0x04001013 RID: 4115
	private iCommand cmdWorld;

	// Token: 0x04001014 RID: 4116
	private iCommand cmdIconClan;

	// Token: 0x04001015 RID: 4117
	private InputDialog input;
}
