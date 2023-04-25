using System;

// Token: 0x02000078 RID: 120
public class MainEvent : PaintListScreen
{
	// Token: 0x06000724 RID: 1828 RVA: 0x0009A010 File Offset: 0x00098210
	public MainEvent(sbyte type, mVector vec) : base(type, vec, T.cmdEvent, 180, 180)
	{
		this.hContent = this.hSub - GameCanvas.hCommand - 10;
		bool flag = !GameCanvas.isTouch;
		if (flag)
		{
			this.hContent -= iCommand.hButtonCmdNor;
		}
		this.setCamera();
		this.cmdSetEvent = new iCommand(T.view, 15, this);
		this.cmdAddfriend = new iCommand(T.addFriend, 16, this);
		this.cmdAddParty = new iCommand(T.chapnhan, 17, this);
		this.cmdDelEvent = new iCommand(T.del, 18, this);
		MainEvent.cmdFight = new iCommand(T.chapnhan, 19, this);
		this.cmdTrade = new iCommand(T.chapnhan, 20, this);
		this.cmdAcceptAddParty = new iCommand(T.chapnhan, 21, this);
		this.cmdInfoEnemy = new iCommand(T.info, 22, this);
		this.cmdTroChuyen = new iCommand(T.view, 23, this);
		this.cmdAcceptClan = new iCommand(T.chapnhan, 24, this);
		this.cmdAcceptFightClan = new iCommand(T.chapnhan, 25, 0, this);
		this.cmdCancelFightClan = new iCommand(T.cancel, 25, 1, this);
		this.cmdAcceptSudo = new iCommand(T.chapnhan, 26, this);
		this.vecMenu.removeAllElements();
		bool flag2 = !GameCanvas.isTouch;
		if (flag2)
		{
			this.vecMenu.addElement(this.cmdSetEvent);
		}
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.right = this.cmdClose;
		}
		else
		{
			this.vecMenu.addElement(this.cmdClose);
		}
		this.backCMD = this.cmdClose;
		this.okCMD = this.cmdSetEvent;
		this.idCommand = 0;
		this.isDelEvent = true;
		this.setPosCmdNew(0, this.vecMenu);
	}

	// Token: 0x06000725 RID: 1829 RVA: 0x0009A1F8 File Offset: 0x000983F8
	public override void beginShow()
	{
		bool flag = !GameCanvas.isTouch;
		if (flag)
		{
			this.idCommand = 0;
		}
		this.setPosCmdNew(0, this.vecMenu);
	}

	// Token: 0x06000726 RID: 1830 RVA: 0x0009A22C File Offset: 0x0009842C
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 2:
		{
			GameScreen.setNumMess();
			bool flag = this.lastScreen != null;
			if (flag)
			{
				this.lastScreen.Show(this.lastScreen.lastScreen);
			}
			else
			{
				GameCanvas.gameScr.Show();
			}
			return;
		}
		case 15:
		{
			bool flag2 = this.idSelect >= 0 && this.idSelect < this.vecPlayer.size();
			if (flag2)
			{
				this.memCur = (InfoMemList)this.vecPlayer.elementAt(this.idSelect);
			}
			bool flag3 = this.memCur != null;
			if (flag3)
			{
				this.memCur.setAction();
			}
			return;
		}
		case 16:
		{
			bool flag4 = this.memCur != null;
			if (flag4)
			{
				GlobalService.gI().Friend(3, this.memCur.id);
				this.vecPlayer.removeElement(this.memCur);
				base.updateInfo();
				GameCanvas.end_Dialog();
			}
			return;
		}
		case 17:
		{
			bool flag5 = this.memCur != null;
			if (flag5)
			{
				GlobalService.gI().Party(4, (short)this.memCur.id);
				this.vecPlayer.removeElement(this.memCur);
				base.updateInfo();
				GameCanvas.end_Dialog();
			}
			return;
		}
		case 18:
			this.delMem(this.memCur);
			GameCanvas.end_Dialog();
			return;
		case 19:
		{
			bool flag6 = this.memCur != null;
			if (flag6)
			{
				GlobalService.gI().Fight(1, (short)this.memCur.id, this.memCur.typeFight);
				this.vecPlayer.removeElement(this.memCur);
				base.updateInfo();
				GameCanvas.end_Dialog();
			}
			return;
		}
		case 20:
		{
			bool flag7 = this.memCur != null;
			if (flag7)
			{
				GlobalService.gI().Trade(6, (short)this.memCur.id, 0, 1, string.Empty);
				this.vecPlayer.removeElement(this.memCur);
				base.updateInfo();
				GameCanvas.end_Dialog();
			}
			return;
		}
		case 21:
		{
			bool flag8 = this.memCur != null;
			if (flag8)
			{
				GlobalService.gI().Party(6, (short)this.memCur.id);
				this.vecPlayer.removeElement(this.memCur);
				base.updateInfo();
				GameCanvas.end_Dialog();
			}
			return;
		}
		case 22:
		{
			bool flag9 = this.memCur != null;
			if (flag9)
			{
				GameCanvas.gameScr.ShowInfoOtherPlayer(this.memCur.name);
				MsgOtherCharInfo.infoFight = this.memCur;
			}
			break;
		}
		case 23:
		{
			bool flag10 = this.memCur != null && GameCanvas.currentScreen != GameCanvas.chatTabScr;
			if (flag10)
			{
				GameCanvas.chatTabScr.addNewChat(this.memCur.name, string.Empty, string.Empty, 0, true);
				GameCanvas.chatTabScr.Show(GameCanvas.currentScreen);
			}
			return;
		}
		case 24:
		{
			bool flag11 = this.memCur != null;
			if (flag11)
			{
				GlobalService.gI().Clan_CMD(12, string.Empty, (int)((short)this.memCur.id), 0);
			}
			break;
		}
		case 25:
		{
			bool flag12 = this.memCur != null;
			if (flag12)
			{
				GlobalService.gI().Clan_Fight((subIndex == 0) ? 1 : 2, (short)this.memCur.id, this.memCur.typeFight);
				GameCanvas.end_Dialog();
			}
			break;
		}
		case 26:
		{
			bool flag13 = this.memCur != null;
			if (flag13)
			{
				GlobalService.gI().Sudo_CMD(18, this.memCur.name, (int)((short)this.memCur.id), 0);
			}
			break;
		}
		}
		base.commandPointer(index, subIndex);
	}

	// Token: 0x06000727 RID: 1831 RVA: 0x0000A9B5 File Offset: 0x00008BB5
	public override void doMenuTouchPlayer()
	{
		this.cmdSetEvent.perform();
	}

	// Token: 0x06000728 RID: 1832 RVA: 0x0009A644 File Offset: 0x00098844
	public override void doMenu()
	{
		bool flag = this.vecPlayer.size() == 0 || this.idSelect < 0 || this.idSelect >= this.vecPlayer.size();
		if (!flag)
		{
			this.memCur = (InfoMemList)this.vecPlayer.elementAt(this.idSelect);
			bool flag2 = this.memCur != null && this.memCur.id != (int)GameScreen.player.ID;
			if (flag2)
			{
				mVector mVector = new mVector();
				mVector.addElement(this.cmdSetEvent);
				bool flag3 = this.idSelect != 0;
				if (flag3)
				{
					mVector.addElement(this.cmdDelEvent);
				}
				GameCanvas.menu.startAt(mVector, 2, this.memCur.name);
			}
		}
	}

	// Token: 0x06000729 RID: 1833 RVA: 0x0000A9C4 File Offset: 0x00008BC4
	public void setMemCur(InfoMemList mem)
	{
		this.memCur = mem;
	}

	// Token: 0x0600072A RID: 1834 RVA: 0x0009A71C File Offset: 0x0009891C
	public static void paintShort(mGraphics g, int x, int y, InfoMemList mem)
	{
		bool flag = mem != null;
		if (flag)
		{
			int num = x - MainEvent.wShort / 2;
			AvMain.paintRect(g, num, y, MainEvent.wShort, MainEvent.hShort, 1, 2);
			MainEvent.fraEvent.drawFrame((int)mem.indexIconEvent, num + 15, y + MainEvent.hShort / 2, 0, 3, g);
			mFont.tahoma_7b_black.drawString(g, mem.name, num + 30, y + GameCanvas.hText / 2, 0);
			mFont.tahoma_7_black.drawString(g, mem.info, num + 35, y + GameCanvas.hText / 2 * 3, 0);
		}
	}

	// Token: 0x0600072B RID: 1835 RVA: 0x0009A7BC File Offset: 0x000989BC
	public override void paintInfo(mGraphics g, InfoMemList mem, int xpaint, int ypaint, int i, int wsub)
	{
		bool flag = mem != null;
		if (flag)
		{
			string name = mem.name;
			mFont.tahoma_7b_black.drawString(g, name, xpaint + 25, ypaint, 0);
			mFont.tahoma_7_black.drawString(g, mem.info, xpaint + 30, ypaint + GameCanvas.hText, 0);
			MainEvent.fraEvent.drawFrame((int)mem.indexIconEvent, xpaint + 10, ypaint + this.hItem / 2, 0, 3, g);
			bool isNew = mem.isNew;
			if (isNew)
			{
				g.drawImage(MainEvent.imgNew, xpaint + 10 + 8, ypaint + this.hItem / 2 - 8, 3);
			}
			bool flag2 = i < this.vecPlayer.size() - 1;
			if (flag2)
			{
				this.paintLine(g, xpaint, ypaint - 6, wsub);
			}
			bool flag3 = i != 0 && GameCanvas.isTouch;
			if (flag3)
			{
				g.drawImage(AvMain.imgIconDel, xpaint + wsub, ypaint + this.hItem / 2, 3);
			}
		}
	}

	// Token: 0x0600072C RID: 1836 RVA: 0x0009A8B8 File Offset: 0x00098AB8
	public void paintLine(mGraphics g, int xpaint, int ypaint, int wsub)
	{
		g.setColor(AvMain.colorMenu[4]);
		g.fillRect(xpaint + 4, ypaint + 3 + this.hItem - 1, wsub - 8, 2);
		g.fillRect(xpaint + 4 + 1, ypaint + 3 + this.hItem - 2, wsub - 8 - 2, 4);
	}

	// Token: 0x0600072D RID: 1837 RVA: 0x0009A910 File Offset: 0x00098B10
	public override void delMem(InfoMemList mem)
	{
		bool flag = mem != null;
		if (flag)
		{
			bool isNew = mem.isNew;
			if (isNew)
			{
				mem.isNew = false;
			}
			bool flag2 = mem.typeEvent == 2;
			if (flag2)
			{
				GameCanvas.chatTabScr.checkRemoveTab(mem.name);
			}
			this.vecPlayer.removeElement(mem);
			base.updateInfo();
			bool flag3 = GameCanvas.isTouchNoOrPC();
			if (flag3)
			{
				this.idSelect = AvMain.resetSelect(this.idSelect, this.vecPlayer.size() - 1, false);
			}
			GameScreen.setNumMess();
		}
	}

	// Token: 0x04000AD9 RID: 2777
	public iCommand cmdSetEvent;

	// Token: 0x04000ADA RID: 2778
	public iCommand cmdAddfriend;

	// Token: 0x04000ADB RID: 2779
	public iCommand cmdAddParty;

	// Token: 0x04000ADC RID: 2780
	public iCommand cmdDelEvent;

	// Token: 0x04000ADD RID: 2781
	public iCommand cmdTrade;

	// Token: 0x04000ADE RID: 2782
	public iCommand cmdAcceptAddParty;

	// Token: 0x04000ADF RID: 2783
	public iCommand cmdInfoEnemy;

	// Token: 0x04000AE0 RID: 2784
	public iCommand cmdTroChuyen;

	// Token: 0x04000AE1 RID: 2785
	public iCommand cmdAcceptClan;

	// Token: 0x04000AE2 RID: 2786
	public iCommand cmdAcceptFightClan;

	// Token: 0x04000AE3 RID: 2787
	public iCommand cmdCancelFightClan;

	// Token: 0x04000AE4 RID: 2788
	public iCommand cmdAcceptSudo;

	// Token: 0x04000AE5 RID: 2789
	public static iCommand cmdFight;

	// Token: 0x04000AE6 RID: 2790
	public static FrameImage fraEvent;

	// Token: 0x04000AE7 RID: 2791
	public static mImage imgNew;

	// Token: 0x04000AE8 RID: 2792
	public static int wShort = 120;

	// Token: 0x04000AE9 RID: 2793
	public static int hShort = 40;
}
