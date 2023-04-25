using System;

// Token: 0x02000019 RID: 25
public class Clan_Screen : ChatTabScreen
{
	// Token: 0x060000F6 RID: 246 RVA: 0x00019B9C File Offset: 0x00017D9C
	public Clan_Screen(MainClan clan)
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
		this.clanchat = new Clan_Chat(T.chat, 3);
		this.clanchat.setPos(this.xBe, this.yBe, this.wCon, this.hCon, this.miniItem, this.hChat);
		this.vecTabChat.removeAllElements();
		this.vecTabChat.addElement(this.clanchat);
		this.member = new Clan_Mem(T.anhem, 4);
		this.member.setPos(this.xBe, this.yBe, this.wCon, this.hCon, this.miniItem, this.hChat);
		this.vecTabChat.addElement(this.member);
		this.info = new Clan_Info(T.info, 5, GameScreen.player.clan);
		this.info.setPos(this.xBe, this.yBe, this.wCon, this.hCon, this.miniItem, this.hChat);
		this.vecTabChat.addElement(this.info);
		this.achi = new Clan_Cup(T.info, 5);
		this.achi.setPos(this.xBe, this.yBe, this.wCon, this.hCon, this.miniItem, this.hChat);
		this.vecTabChat.addElement(this.achi);
		this.xbegintab = this.x + this.w / 2 - this.vecTabChat.size() * this.wPaintTab / 2 - this.vecTabChat.size() % 2 * this.wPaintTab / 2;
		this.idSelect = 0;
		Clan_Screen.cmdClose = new iCommand(T.close, 5, this);
		bool isTouch2 = GameCanvas.isTouch;
		if (isTouch2)
		{
			Clan_Screen.cmdClose.setPos(this.x + this.w - 13, this.y + 13, MainTab.fraCloseTab, string.Empty);
		}
		else
		{
			Clan_Screen.cmdClose = AvMain.setPosCMD(Clan_Screen.cmdClose, 2);
			this.right = Clan_Screen.cmdClose;
		}
		this.setAddCmd(null, -1);
		this.setData();
		this.backCMD = Clan_Screen.cmdClose;
	}

	// Token: 0x060000F7 RID: 247 RVA: 0x00019F70 File Offset: 0x00018170
	public void setData()
	{
		this.member.vecDetail = this.clan.vecMem;
		this.info.clan = this.clan;
		this.clanchat.vecDetail = this.clan.vecChatCLan;
		this.achi.vecDetail = this.clan.vecAchi;
	}

	// Token: 0x060000F8 RID: 248 RVA: 0x00019FD4 File Offset: 0x000181D4
	public override void commandPointer(int index, int subIndex)
	{
		bool flag = index == 5;
		if (flag)
		{
			GameCanvas.gameScr.Show();
		}
	}

	// Token: 0x060000F9 RID: 249 RVA: 0x00019FF8 File Offset: 0x000181F8
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
			AvMain.fraIconClan.drawFrame(i * 2 + num, this.xBe - this.miniItem + i * this.wPaintTab + this.wPaintTab / 2, this.y + this.wItem / 2 + 3, 0, 3, g);
			bool flag3 = chatDetail.isNew;
			if (flag3)
			{
				g.drawImage(MainEvent.imgNew, this.xBe - this.miniItem + i * this.wPaintTab + 5, this.y + 7, 0);
			}
		}
		mGraphics.resetTransAndroid(g);
		g.restoreCanvas();
		GameCanvas.resetTrans(g);
		bool flag4 = this.tabCur != null;
		if (flag4)
		{
			GameCanvas.resetTrans(g);
			this.tabCur.paint(g);
		}
		bool flag5 = !GameCanvas.isDialogOrMenuShow();
		if (flag5)
		{
			for (int j = 0; j < this.vecCmd.size(); j++)
			{
				iCommand iCommand = (iCommand)this.vecCmd.elementAt(j);
				iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
			}
		}
	}

	// Token: 0x060000FA RID: 250 RVA: 0x0001A2EC File Offset: 0x000184EC
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

	// Token: 0x060000FB RID: 251 RVA: 0x0001A358 File Offset: 0x00018558
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

	// Token: 0x060000FC RID: 252 RVA: 0x0001A42C File Offset: 0x0001862C
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
			bool flag4 = num >= 0 && num <= this.vecTabChat.size();
			if (flag4)
			{
				this.idSelect = num;
				this.getCurTab(this.idSelect);
			}
			GameCanvas.isPointerSelect = false;
		}
	}

	// Token: 0x060000FD RID: 253 RVA: 0x0001A53C File Offset: 0x0001873C
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

	// Token: 0x060000FE RID: 254 RVA: 0x0001A59C File Offset: 0x0001879C
	public void setAddCmd(iCommand cmd, sbyte pos)
	{
		this.vecCmd.removeAllElements();
		this.vecCmd.addElement(Clan_Screen.cmdClose);
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

	// Token: 0x060000FF RID: 255 RVA: 0x000090B5 File Offset: 0x000072B5
	public void setCMDTabCur(iCommand cmd, sbyte pos)
	{
	}

	// Token: 0x06000100 RID: 256 RVA: 0x0001A5EC File Offset: 0x000187EC
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

	// Token: 0x06000101 RID: 257 RVA: 0x0001A678 File Offset: 0x00018878
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

	// Token: 0x06000102 RID: 258 RVA: 0x0001A700 File Offset: 0x00018900
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

	// Token: 0x06000103 RID: 259 RVA: 0x0001A790 File Offset: 0x00018990
	public void setIsNewTab(ChatDetail tab)
	{
		bool flag = this.tabCur != null && this.tabCur != tab;
		if (flag)
		{
			tab.setIsNew(true);
		}
		Clan_Screen.isNew = true;
	}

	// Token: 0x0400018B RID: 395
	private int xbegintab;

	// Token: 0x0400018C RID: 396
	public static iCommand cmdClose;

	// Token: 0x0400018D RID: 397
	public MainClan clan;

	// Token: 0x0400018E RID: 398
	public static InfoMemList memCur;

	// Token: 0x0400018F RID: 399
	public Clan_Chat clanchat;

	// Token: 0x04000190 RID: 400
	public Clan_Mem member;

	// Token: 0x04000191 RID: 401
	public Clan_Info info;

	// Token: 0x04000192 RID: 402
	public Clan_Cup achi;

	// Token: 0x04000193 RID: 403
	public static bool isNew;

	// Token: 0x04000194 RID: 404
	private mVector vecCmd = new mVector();
}
