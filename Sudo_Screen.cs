using System;

// Token: 0x020000FA RID: 250
public class Sudo_Screen : ChatTabScreen
{
	// Token: 0x06000EB0 RID: 3760 RVA: 0x00119A54 File Offset: 0x00117C54
	public Sudo_Screen(MainSudo clan)
	{
		this.clan = clan;
		this.w = 240;
		this.h = 220;
		this.idSelect = 0;
		bool flag = this.w > MotherCanvas.w;
		if (flag)
		{
			this.w = MotherCanvas.w;
		}
		bool flag2 = this.h > MotherCanvas.h - GameCanvas.hCommand - 10;
		if (flag2)
		{
			this.h = MotherCanvas.h - GameCanvas.hCommand - 10;
		}
		this.x = MotherCanvas.hw - this.w / 2;
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.y = MotherCanvas.hh - this.h / 2;
		}
		else
		{
			this.y = MotherCanvas.hh - this.h / 2 - GameCanvas.hCommand / 2;
		}
		this.wItem = 24;
		this.xBe = this.x + this.wItem + this.miniItem;
		this.yBe = this.y + this.wItem + this.miniItem;
		this.hCon = this.h - this.wItem - this.miniItem - this.miniItem * 2;
		this.wCon = this.w - this.wItem * 2 - this.miniItem * 2;
		this.wPaintTab = (this.wCon + this.miniItem * 2) / 4;
		this.wCon = this.wPaintTab * 4 - this.miniItem * 2;
		this.hChat = this.hCon / GameCanvas.hText + 2;
		this.clanchat = new Sudo_Chat(T.chat, 3);
		this.clanchat.setPos(this.xBe, this.yBe, this.wCon, this.hCon, this.miniItem, this.hChat);
		this.member = new Sudo_Mem(T.anhem, 4);
		this.member.setPos(this.xBe, this.yBe, this.wCon, this.hCon, this.miniItem, this.hChat);
		this.vecTabChat.removeAllElements();
		this.vecTabChat.addElement(this.member);
		this.info = new Sudo_Info(T.info, 5, GameScreen.player.sudo);
		this.info.setPos(this.xBe, this.yBe, this.wCon, this.hCon, this.miniItem, this.hChat);
		this.vecTabChat.addElement(this.info);
		this.achi = new Clan_Cup(T.info, 5);
		this.achi.setPos(this.xBe, this.yBe, this.wCon, this.hCon, this.miniItem, this.hChat);
		this.xbegintab = this.x + this.w / 2 - this.vecTabChat.size() * this.wPaintTab / 2 - this.vecTabChat.size() % 2 * this.wPaintTab / 2;
		this.idSelect = 0;
		Sudo_Screen.cmdClose = new iCommand(T.close, 5, this);
		bool isTouch2 = GameCanvas.isTouch;
		if (isTouch2)
		{
			Sudo_Screen.cmdClose.setPos(this.x + this.w - 13, this.y + 13, MainTab.fraCloseTab, string.Empty);
		}
		else
		{
			Sudo_Screen.cmdClose = AvMain.setPosCMD(Sudo_Screen.cmdClose, 2);
			this.right = Sudo_Screen.cmdClose;
		}
		this.setAddCmd(null, -1);
		this.setData();
		this.backCMD = Sudo_Screen.cmdClose;
		GlobalService.gI().Send_Sudo(2);
		GlobalService.gI().Send_Sudo(3);
	}

	// Token: 0x06000EB1 RID: 3761 RVA: 0x00119E1C File Offset: 0x0011801C
	public void setData()
	{
		bool flag = this.clan != null;
		if (flag)
		{
			this.member.vecDetail = this.clan.vecMem;
			this.info.clan = this.clan;
			this.clanchat.vecDetail = this.clan.vecChatCLan;
			this.achi.vecDetail = this.clan.vecAchi;
		}
	}

	// Token: 0x06000EB2 RID: 3762 RVA: 0x00019FD4 File Offset: 0x000181D4
	public override void commandPointer(int index, int subIndex)
	{
		bool flag = index == 5;
		if (flag)
		{
			GameCanvas.gameScr.Show();
		}
	}

	// Token: 0x06000EB3 RID: 3763 RVA: 0x00119E8C File Offset: 0x0011808C
	public override void paint(mGraphics g)
	{
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.paint(g);
		}
		GameCanvas.resetTrans(g);
		MainTab.paintPaperTab(g, this.x, this.y, this.w, this.h);
		AvMain.paintRect(g, this.xBe - this.miniItem, this.yBe - this.miniItem, this.wCon + this.miniItem * 2 - 1, this.hCon + this.miniItem * 2, 0, 4);
		g.setClip(this.x + this.wItem / 2, this.y, this.w - this.wItem, this.wItem + this.miniItem * 2);
		g.saveCanvas();
		g.ClipRec(this.x + this.wItem / 2, this.y, this.w - this.wItem, this.wItem + this.miniItem * 2);
		for (int i = 0; i < this.vecTabChat.size(); i++)
		{
			ChatDetail chatDetail = (ChatDetail)this.vecTabChat.elementAt(i);
			int num = 0;
			bool flag2 = i == this.idSelect;
			if (flag2)
			{
				num = 1;
			}
			g.drawRegion(AvMain.imgTabClan, 0, num * 19, 25, 19, 0, (float)(this.xBe - this.miniItem + i * this.wPaintTab), (float)(this.y + this.wItem - 18), 0);
			g.drawRegion(AvMain.imgTabClan, 0, num * 19, 25, 19, 2, (float)(this.xBe - this.miniItem + i * this.wPaintTab + this.wPaintTab - 25), (float)(this.y + this.wItem - 18), 0);
			bool flag3 = i == 1;
			if (flag3)
			{
				AvMain.fraIconClan.drawFrame(8 + num, this.xBe - this.miniItem + i * this.wPaintTab + this.wPaintTab / 2, this.y + this.wItem / 2 + 3, 0, 3, g);
			}
			else
			{
				AvMain.fraIconClan.drawFrame((i + 1) * 2 + num, this.xBe - this.miniItem + i * this.wPaintTab + this.wPaintTab / 2, this.y + this.wItem / 2 + 3, 0, 3, g);
			}
			bool flag4 = chatDetail.isNew;
			if (flag4)
			{
				g.drawImage(MainEvent.imgNew, this.xBe - this.miniItem + i * this.wPaintTab + 5, this.y + 7, 0);
			}
		}
		mGraphics.resetTransAndroid(g);
		g.restoreCanvas();
		GameCanvas.resetTrans(g);
		bool flag5 = this.tabCur != null;
		if (flag5)
		{
			GameCanvas.resetTrans(g);
			this.tabCur.paint(g);
		}
		bool flag6 = !GameCanvas.isDialogOrMenuShow();
		if (flag6)
		{
			for (int j = 0; j < this.vecCmd.size(); j++)
			{
				iCommand iCommand = (iCommand)this.vecCmd.elementAt(j);
				iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
			}
		}
	}

	// Token: 0x06000EB4 RID: 3764 RVA: 0x0001A2EC File Offset: 0x000184EC
	public override void update()
	{
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.update();
		}
		bool flag2 = this.tabCur != null;
		if (flag2)
		{
			this.tabCur.update();
			bool flag3 = this.tabCur.isNew;
			if (flag3)
			{
				this.tabCur.isNew = false;
			}
		}
		MainTab.CDDonateClan.updateTimeCountDownTicket();
	}

	// Token: 0x06000EB5 RID: 3765 RVA: 0x0001A358 File Offset: 0x00018558
	public override void updatekey()
	{
		int idSelect = this.idSelect;
		bool flag = GameCanvas.keyMyHold[4];
		if (flag)
		{
			GameCanvas.clearKeyHold(4);
			bool flag2 = this.idSelect > 0;
			if (flag2)
			{
				this.idSelect--;
			}
		}
		else
		{
			bool flag3 = GameCanvas.keyMyHold[6];
			if (flag3)
			{
				GameCanvas.clearKeyHold(6);
				bool flag4 = this.idSelect < this.vecTabChat.size() - 1;
				if (flag4)
				{
					this.idSelect++;
				}
			}
		}
		bool flag5 = idSelect != this.idSelect;
		if (flag5)
		{
			this.getCurTab(this.idSelect);
		}
		bool flag6 = this.tabCur != null;
		if (flag6)
		{
			this.tabCur.updatekey();
		}
		base.updateCmd();
		this.updatekeyPC();
	}

	// Token: 0x06000EB6 RID: 3766 RVA: 0x0011A1D4 File Offset: 0x001183D4
	public override void updatePointer()
	{
		bool flag = this.vecCmd != null;
		if (flag)
		{
			for (int i = 0; i < this.vecCmd.size(); i++)
			{
				iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
				iCommand.updatePointer();
			}
		}
		bool flag2 = this.tabCur != null;
		if (flag2)
		{
			this.tabCur.updatePointer();
		}
		bool flag3 = GameCanvas.isPointerSelect && GameCanvas.isPointer(this.xBe - this.miniItem, this.y + this.wItem - 24, this.wCon + this.miniItem * 2, 28);
		if (flag3)
		{
			int num = (GameCanvas.px - (this.xBe - this.miniItem)) / this.wPaintTab;
			bool flag4 = num >= 0 && num < this.vecTabChat.size();
			if (flag4)
			{
				mSystem.outz("click tab " + num.ToString() + " vecTabChat.size() " + this.vecTabChat.size().ToString());
				this.idSelect = num;
				this.getCurTab(this.idSelect);
			}
			GameCanvas.isPointerSelect = false;
		}
	}

	// Token: 0x06000EB7 RID: 3767 RVA: 0x0011A314 File Offset: 0x00118514
	public override void getCurTab(int idSe)
	{
		this.idSelect = idSe;
		bool flag = idSe >= 0 && idSe <= this.vecTabChat.size();
		if (flag)
		{
			this.tabCur = (ChatDetail)this.vecTabChat.elementAt(idSe);
			this.setAddCmd(null, -1);
			this.tabCur.beginFocus();
		}
	}

	// Token: 0x06000EB8 RID: 3768 RVA: 0x0011A374 File Offset: 0x00118574
	public void setAddCmd(iCommand cmd, sbyte pos)
	{
		this.vecCmd.removeAllElements();
		this.vecCmd.addElement(Sudo_Screen.cmdClose);
		bool flag = pos == 1;
		if (flag)
		{
			this.left = cmd;
		}
		bool flag2 = pos == 0;
		if (flag2)
		{
			this.center = cmd;
		}
	}

	// Token: 0x06000EB9 RID: 3769 RVA: 0x000090B5 File Offset: 0x000072B5
	public void setCMDTabCur(iCommand cmd, sbyte pos)
	{
	}

	// Token: 0x06000EBA RID: 3770 RVA: 0x0001A5EC File Offset: 0x000187EC
	public static InfoMemList getMemInCLan(short Id)
	{
		bool flag = GameScreen.player.clan == null;
		InfoMemList result;
		if (flag)
		{
			result = null;
		}
		else
		{
			for (int i = 0; i < GameScreen.player.clan.vecMem.size(); i++)
			{
				InfoMemList infoMemList = (InfoMemList)GameScreen.player.clan.vecMem.elementAt(i);
				bool flag2 = infoMemList.id != -1 && infoMemList.id == (int)Id;
				if (flag2)
				{
					return infoMemList;
				}
			}
			result = null;
		}
		return result;
	}

	// Token: 0x06000EBB RID: 3771 RVA: 0x0001A678 File Offset: 0x00018878
	public static InfoMemList getMemInCLan(string name)
	{
		bool flag = GameScreen.player.clan == null;
		InfoMemList result;
		if (flag)
		{
			result = null;
		}
		else
		{
			for (int i = 0; i < GameScreen.player.clan.vecMem.size(); i++)
			{
				InfoMemList infoMemList = (InfoMemList)GameScreen.player.clan.vecMem.elementAt(i);
				bool flag2 = name.CompareTo(infoMemList.name) == 0;
				if (flag2)
				{
					return infoMemList;
				}
			}
			result = null;
		}
		return result;
	}

	// Token: 0x06000EBC RID: 3772 RVA: 0x0001A700 File Offset: 0x00018900
	public static void getRemoveMemInCLan(string name)
	{
		bool flag = GameScreen.player.clan == null;
		if (!flag)
		{
			for (int i = 0; i < GameScreen.player.clan.vecMem.size(); i++)
			{
				InfoMemList infoMemList = (InfoMemList)GameScreen.player.clan.vecMem.elementAt(i);
				bool flag2 = infoMemList.name.CompareTo(name) == 0;
				if (flag2)
				{
					GameScreen.player.clan.vecMem.removeElementAt(i);
					break;
				}
			}
		}
	}

	// Token: 0x06000EBD RID: 3773 RVA: 0x0011A3C4 File Offset: 0x001185C4
	public void setIsNewTab(ChatDetail tab)
	{
		bool flag = this.tabCur != null && this.tabCur != tab;
		if (flag)
		{
			tab.setIsNew(true);
		}
		Sudo_Screen.isNew = true;
	}

	// Token: 0x04001679 RID: 5753
	public const sbyte SUBCMD_SUDO_NHAN = 0;

	// Token: 0x0400167A RID: 5754
	public const sbyte SUBCMD_SUDO_HUY = 1;

	// Token: 0x0400167B RID: 5755
	public const sbyte SUBCMD_SUDO_LIST = 2;

	// Token: 0x0400167C RID: 5756
	public const sbyte SUBCMD_SUDO_INFO = 3;

	// Token: 0x0400167D RID: 5757
	public const sbyte SUBCMD_SUDO_INVITE = 4;

	// Token: 0x0400167E RID: 5758
	public const sbyte SUBCMD_SUDO_IS_ACTIVE = 5;

	// Token: 0x0400167F RID: 5759
	public const sbyte TYPE_INFO_PLAYER_SEND_INVITE = 7;

	// Token: 0x04001680 RID: 5760
	public const sbyte TYPE_INFO_PLAYER_CHAT = 8;

	// Token: 0x04001681 RID: 5761
	public const sbyte TYPE_INFO_SUDO_CHAT = 9;

	// Token: 0x04001682 RID: 5762
	public const sbyte TYPE_INFO_LEAVE_CLAN = 10;

	// Token: 0x04001683 RID: 5763
	public const sbyte TYPE_INFO_REMOVE_CHAT = 11;

	// Token: 0x04001684 RID: 5764
	public const sbyte TYPE_INFO_ADD_REMOVE_MEMBER = 12;

	// Token: 0x04001685 RID: 5765
	public const sbyte SUDO_INFO_PLAYER = 13;

	// Token: 0x04001686 RID: 5766
	public const sbyte CLIENT_TYPE_CHAT_SUDO = 15;

	// Token: 0x04001687 RID: 5767
	public const sbyte CLIENT_TYPE_KICK = 16;

	// Token: 0x04001688 RID: 5768
	public const sbyte CLIENT_TYPE_LEAVE = 17;

	// Token: 0x04001689 RID: 5769
	public const sbyte CLIENT_TYPE_APPCEPT_VISIT_SUDO = 18;

	// Token: 0x0400168A RID: 5770
	public const sbyte CLIENT_TYPE_VISIT_SUDO = 19;

	// Token: 0x0400168B RID: 5771
	public const sbyte CLIENT_TYPE_CANCEL_VITSI_SUDO = 20;

	// Token: 0x0400168C RID: 5772
	private int xbegintab;

	// Token: 0x0400168D RID: 5773
	public static iCommand cmdClose;

	// Token: 0x0400168E RID: 5774
	public MainSudo clan;

	// Token: 0x0400168F RID: 5775
	public static InfoMemList memCur;

	// Token: 0x04001690 RID: 5776
	public Sudo_Chat clanchat;

	// Token: 0x04001691 RID: 5777
	public Sudo_Mem member;

	// Token: 0x04001692 RID: 5778
	public Sudo_Info info;

	// Token: 0x04001693 RID: 5779
	public Clan_Cup achi;

	// Token: 0x04001694 RID: 5780
	public static bool isNew;

	// Token: 0x04001695 RID: 5781
	private mVector vecCmd = new mVector();
}
