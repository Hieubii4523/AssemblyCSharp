using System;

// Token: 0x02000113 RID: 275
public class WantedList : PaintListScreen
{
	// Token: 0x06000FD0 RID: 4048 RVA: 0x00130244 File Offset: 0x0012E444
	public WantedList(sbyte type, mVector vec) : base(type, vec, string.Empty, 190, 180)
	{
		bool flag = type == 0;
		if (flag)
		{
			this.nameList = T.nameWantedList;
		}
		else
		{
			bool flag2 = type == 3;
			if (flag2)
			{
				this.nameList = T.nameWantedListDaPhat;
			}
		}
		this.page = 0;
		this.hItem = 42;
		this.textrong = T.danhSachTrong;
		this.SetListSize();
		this.SetIdListCmdSelect();
		this.cmdNext = new iCommand(T.nextpage, 12, this);
		this.cmdPre = new iCommand(T.prepage, 13, this);
		this.cmdInfoPlayer.indexMenu = 20;
		this.cmdDs = new iCommand(T.danhsach, 14, this);
		this.cmdPhat = new iCommand(T.daPhat, 15, this);
		this.cmdNhan = new iCommand(T.daNhan, 16, this);
		this.vecCmd.addElement(this.cmdDs);
		this.vecCmd.addElement(this.cmdPhat);
		this.vecCmd.addElement(this.cmdNhan);
		bool flag3 = GameMidlet.DEVICE > 0;
		if (flag3)
		{
			this.wDsCmd = 100;
			this.xSub += this.wDsCmd / 2;
			this.setPosDsCmd(this.xSub - this.wDsCmd + 19, this.ySub + 17);
			this.setDsCmdSelected();
		}
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.cmdClose.setPos(this.xSub + 20 + this.wSub - 34, this.ySub - 10, MainTab.fraCloseTab, string.Empty);
			this.right = this.cmdClose;
		}
		base.setPosVecMenu(this.vecMenu);
		bool flag4 = Interface_Game.mImgPvPNew == null;
		if (flag4)
		{
			Interface_Game.loadImgPvPNew();
		}
	}

	// Token: 0x06000FD1 RID: 4049 RVA: 0x0013042C File Offset: 0x0012E62C
	public override void commandPointer(int index, int subIndex)
	{
		bool flag = false;
		int num = (int)this.page;
		switch (index)
		{
		case 12:
		{
			this.page += 1;
			this.page = (sbyte)AvMain.resetSelect((int)this.page, this.countPage - 1, false);
			bool flag2 = num == (int)this.page;
			if (flag2)
			{
				GameCanvas.Start_Normal_DiaLog(T.dialogLastPage, new mVector(), true);
			}
			else
			{
				flag = true;
			}
			break;
		}
		case 13:
		{
			this.page -= 1;
			this.page = (sbyte)AvMain.resetSelect((int)this.page, this.countPage - 1, false);
			bool flag3 = num == (int)this.page;
			if (flag3)
			{
				GameCanvas.Start_Normal_DiaLog(T.dialogFirstPage, new mVector(), true);
			}
			else
			{
				flag = true;
			}
			break;
		}
		case 14:
			GlobalService.gI().Send_Wanted_Poster(0, -1);
			break;
		case 15:
			GlobalService.gI().Send_Wanted_Poster(3, -1);
			break;
		case 16:
			GlobalService.gI().Send_Wanted_Poster_Action(4, -1, 0);
			break;
		case 20:
		{
			bool flag4 = this.type == 0;
			if (flag4)
			{
				GlobalService.gI().Send_Wanted_Poster_Action(1, (short)this.memCur.id, 0);
			}
			else
			{
				bool flag5 = this.type == 3;
				if (flag5)
				{
					GlobalService.gI().Send_Wanted_Poster_Action(5, (short)this.memCur.id, 0);
				}
			}
			return;
		}
		}
		bool flag6 = flag;
		if (flag6)
		{
			this.idSelect = 0;
			this.SetListSize();
			base.updateInfo();
		}
		else
		{
			base.commandPointer(index, subIndex);
		}
	}

	// Token: 0x06000FD2 RID: 4050 RVA: 0x001305D8 File Offset: 0x0012E7D8
	public override void doMenuTouchPlayer()
	{
		bool flag = this.vecPlayer.size() != 0;
		if (flag)
		{
			this.memCur = (InfoMemList)this.vecPlayer.elementAt(this.idSelect + (int)(this.page * 10));
			bool flag2 = this.memCur != null;
			if (flag2)
			{
				mVector mVector = new mVector();
				mVector.addElement(this.cmdInfoPlayer);
				GameCanvas.menu.startAt(mVector, 2, this.memCur.charShow.name);
			}
		}
	}

	// Token: 0x06000FD3 RID: 4051 RVA: 0x00130660 File Offset: 0x0012E860
	public override void doMenu()
	{
		mVector mVector = new mVector();
		string name = T.menu;
		bool flag = this.vecPlayer.size() > 0;
		if (flag)
		{
			this.memCur = (InfoMemList)this.vecPlayer.elementAt(this.idSelect + (int)(this.page * 10));
			bool flag2 = this.memCur != null;
			if (flag2)
			{
				bool flag3 = GameMidlet.DEVICE == 0;
				if (flag3)
				{
					mVector.addElement(this.cmdInfoPlayer);
				}
				name = this.memCur.charShow.name;
			}
		}
		mVector.addElement(this.cmdNext);
		mVector.addElement(this.cmdPre);
		bool flag4 = GameMidlet.DEVICE == 0;
		if (flag4)
		{
			for (int i = 0; i < this.vecCmd.size(); i++)
			{
				bool flag5 = i != this.idDsCmdSelected;
				if (flag5)
				{
					mVector.addElement(this.vecCmd.elementAt(i));
				}
			}
		}
		GameCanvas.menu.startAt(mVector, 2, name);
	}

	// Token: 0x06000FD4 RID: 4052 RVA: 0x00130774 File Offset: 0x0012E974
	public override void paint(mGraphics g)
	{
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.paint(g);
		}
		bool flag2 = GameCanvas.currentScreen == GameCanvas.chatTabScr;
		if (!flag2)
		{
			GameCanvas.resetTrans(g);
			this.paintBg(g);
			g.setClip(this.xSub, this.ySub + GameCanvas.hCommand + this.miniItem, this.wSub, this.hContent - this.miniItem);
			g.saveCanvas();
			g.ClipRec(this.xSub, this.ySub + GameCanvas.hCommand + this.miniItem, this.wSub, this.hContent - this.miniItem);
			g.translate(0, -this.list.cmx);
			int num = this.xSub + 30;
			int num2 = this.ySub + GameCanvas.hCommand + 10;
			bool isLoad = this.isLoad;
			if (isLoad)
			{
				MsgDialog.fraImgWaiting.drawFrame(GameCanvas.gameTick / 6 % MsgDialog.fraImgWaiting.nFrame, this.xSub + this.wSub / 2, num2 + this.hItem, 0, 3, g);
			}
			else
			{
				bool flag3 = this.vecPlayer.size() == 0;
				if (flag3)
				{
					mFont.tahoma_7_black.drawString(g, this.textrong, this.xSub + this.wSub / 2, this.ySub + (this.hSub - 20) / 2, 2);
				}
				else
				{
					bool flag4 = this.idSelect >= 0;
					if (flag4)
					{
						this.paintSelect(g, num, num2 - 2, this.wSub - 40);
					}
					for (int i = 0; i < 10; i++)
					{
						bool flag5 = num2 - this.list.cmx + this.hItem >= GameCanvas.hCommand + this.ySub && num2 - this.list.cmx - this.hItem <= GameCanvas.hCommand + this.hContent + this.ySub;
						if (flag5)
						{
							InfoMemList mem = (InfoMemList)this.vecPlayer.elementAt(i + (int)(this.page * 10));
							this.paintInfo(g, mem, num, num2, i, this.wSub - 60);
						}
						num2 += this.hItem;
					}
				}
			}
			mGraphics.resetTransAndroid(g);
			g.restoreCanvas();
			GameCanvas.resetTrans(g);
			bool flag6 = this.vecMenu != null;
			if (flag6)
			{
				for (int j = 0; j < this.vecMenu.size(); j++)
				{
					iCommand iCommand = (iCommand)this.vecMenu.elementAt(j);
					iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
				}
			}
			bool flag7 = GameMidlet.DEVICE > 0;
			if (flag7)
			{
				for (int k = 0; k < this.vecCmd.size(); k++)
				{
					iCommand iCommand2 = (iCommand)this.vecCmd.elementAt(k);
					iCommand2.paint(g, iCommand2.xCmd, iCommand2.yCmd);
				}
			}
			bool flag8 = this.right != null;
			if (flag8)
			{
				this.right.paint(g, this.right.xCmd, this.right.yCmd);
			}
		}
	}

	// Token: 0x06000FD5 RID: 4053 RVA: 0x00130ADC File Offset: 0x0012ECDC
	public override void paintInfo(mGraphics g, InfoMemList mem, int xpaint, int ypaint, int i, int wsub)
	{
		bool flag = mem == null;
		if (!flag)
		{
			base.paintBgMemListPhatLenh(g, xpaint + 1, ypaint, this.wSub - 61, 39);
			int num = 42;
			xpaint += num;
			mFont.tahoma_7b_black.drawString(g, mem.charShow.name, xpaint, ypaint + 1, 0);
			bool flag2 = this.type == 0;
			if (flag2)
			{
				mFont.tahoma_7_black.drawString(g, T.wantedBy + ": " + mem.name, xpaint, ypaint + GameCanvas.hText - 2, 0);
			}
			else
			{
				bool flag3 = this.type == 3;
				if (flag3)
				{
					mFont.tahoma_7_black.drawString(g, T.nhanQuest + ": " + mem.namePlayerNhan, xpaint, ypaint + GameCanvas.hText - 2, 0);
				}
			}
			AvMain.fraMoney.drawFrame(0, xpaint - 1, ypaint + GameCanvas.hText * 2 - 6, 0, 0, g);
			mFont.tahoma_7_black.drawString(g, AvMain.getDotNumber((long)mem.charShow.wanted), xpaint + 12, ypaint + GameCanvas.hText * 2 - 5, 0);
			xpaint -= num;
			bool flag4 = this.type == 3 && mem.isWantedSuccess == 1;
			if (flag4)
			{
				g.drawImage(AvMain.imgComplete, xpaint + (this.wSub - 60) / 2 - 7, ypaint + 1, 0);
			}
			bool flag5 = this.type == 0;
			if (flag5)
			{
				bool flag6 = mem.typeOnline == 0;
				if (flag6)
				{
					g.drawRegion(Interface_Game.mImgPvPNew[3], 0, 14, 7, 7, 0, (float)(xpaint + this.wSub - 60 - 10 - 1), (float)(ypaint + GameCanvas.hText * 2 - 3), 0);
				}
				else
				{
					g.drawRegion(Interface_Game.mImgPvPNew[3], 0, 7, 7, 7, 0, (float)(xpaint + this.wSub - 60 - 10 - 1), (float)(ypaint + GameCanvas.hText * 2 - 3), 0);
				}
			}
			MainObject.paintHeadEveryWhere(g, mem.charShow.head, mem.charShow.hair, mem.charShow.hat, xpaint + 21, ypaint + this.hItem / 2 + 35 - 4, 0);
			g.drawRegion(Interface_Game.imgIconMPHP, 0, 22, 10, 11, 0, (float)(xpaint + 11), (float)(ypaint + GameCanvas.hText * 2 - 3), 0);
			mFont.tahoma_7_black.drawString(g, mem.charShow.Lv.ToString() + string.Empty, xpaint + 24, ypaint + GameCanvas.hText * 2 - 5, 0);
		}
	}

	// Token: 0x06000FD6 RID: 4054 RVA: 0x00130D64 File Offset: 0x0012EF64
	public override void paintBg(mGraphics g)
	{
		bool flag = GameMidlet.DEVICE == 0;
		if (flag)
		{
			AvMain.paintBG_AChi(g, this.xSub, this.ySub - 20, this.wSub, this.hSub + 20, 1);
		}
		else
		{
			AvMain.paintBg_WantedList(g, this.xSub - this.wDsCmd / 2, this.ySub - 20, this.wSub, this.hSub + 20, 1, 100);
		}
		mFont.tahoma_7b_brown.drawString(g, this.nameList, this.xSub + this.wSub / 2, this.ySub + GameCanvas.hCommand / 2 + 3, 2);
		mFont.tahoma_7b_black.drawString(g, T.page + ((int)(this.page + 1)).ToString() + "/" + this.countPage.ToString(), this.xSub + this.wSub / 2, this.ySub + this.hSub - GameCanvas.hCommand / 2 - 20, 2);
	}

	// Token: 0x06000FD7 RID: 4055 RVA: 0x0000C2CD File Offset: 0x0000A4CD
	public override void paintSelect(mGraphics g, int xbegin, int ybegin, int wFocus)
	{
		g.setColor(11936290);
		g.drawRect(xbegin, ybegin + this.idSelect * this.hItem + 1, this.wSub - 60, this.hItem - 2);
	}

	// Token: 0x06000FD8 RID: 4056 RVA: 0x0000C306 File Offset: 0x0000A506
	public override void updatekey()
	{
		base.updatekey();
		this.idSelect = AvMain.resetSelect(this.idSelect, this.listSize - 1, false);
	}

	// Token: 0x06000FD9 RID: 4057 RVA: 0x00130E6C File Offset: 0x0012F06C
	public override void updatePointer()
	{
		base.updatePointer();
		bool flag = GameMidlet.DEVICE == 0;
		if (!flag)
		{
			for (int i = 0; i < this.vecCmd.size(); i++)
			{
				bool flag2 = i != this.idDsCmdSelected;
				if (flag2)
				{
					iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
					iCommand.updatePointer();
				}
			}
		}
	}

	// Token: 0x06000FDA RID: 4058 RVA: 0x00130EDC File Offset: 0x0012F0DC
	public override void setCamera()
	{
		int limX = this.listSize * this.hItem - this.hContent + this.miniItem * 2;
		this.list = new ListNew(this.xSub, this.ySub + GameCanvas.hCommand, this.wSub, this.hContent, 0, 0, limX, true);
		this.list.setToX((this.idSelect + 1) * this.hItem - this.hContent / 2);
	}

	// Token: 0x06000FDB RID: 4059 RVA: 0x00130F5C File Offset: 0x0012F15C
	private void SetListSize()
	{
		this.listSize = this.vecPlayer.size() - (int)(this.page * 10);
		this.listSize = AvMain.resetSelect(this.listSize, (this.listSize < 10) ? this.listSize : 10, false);
		this.countPage = this.vecPlayer.size() / 10 + ((this.vecPlayer.size() % 10 != 0) ? 1 : 0);
		bool flag = this.countPage == 0;
		if (flag)
		{
			this.countPage = 1;
		}
	}

	// Token: 0x06000FDC RID: 4060 RVA: 0x00130FEC File Offset: 0x0012F1EC
	private void setPosDsCmd(int xbegin, int ybegin)
	{
		int num = ybegin;
		for (int i = 0; i < this.vecCmd.size(); i++)
		{
			iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
			iCommand.setPos(xbegin + 39, num + 11, AvMain.imgKhung[0], iCommand.caption, 2);
			num += 30;
		}
	}

	// Token: 0x06000FDD RID: 4061 RVA: 0x0000C32A File Offset: 0x0000A52A
	public override void setPosCmdNew(int yplus, mVector vecMenu)
	{
		this.xSub -= this.wDsCmd / 2;
		base.setPosCmdNew(yplus, vecMenu);
		this.xSub += this.wDsCmd / 2;
	}

	// Token: 0x06000FDE RID: 4062 RVA: 0x0013104C File Offset: 0x0012F24C
	private void setDsCmdSelected()
	{
		for (int i = 0; i < this.vecCmd.size(); i++)
		{
			iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
			bool flag = i == this.idDsCmdSelected;
			if (flag)
			{
				iCommand.frameCmd = 1;
				iCommand.isDisplay = true;
			}
			else
			{
				iCommand.frameCmd = 0;
				iCommand.isDisplay = false;
			}
		}
	}

	// Token: 0x06000FDF RID: 4063 RVA: 0x001310B8 File Offset: 0x0012F2B8
	private void SetIdListCmdSelect()
	{
		switch (this.type)
		{
		case 0:
			this.idDsCmdSelected = 0;
			break;
		case 3:
			this.idDsCmdSelected = 1;
			break;
		case 4:
			this.idDsCmdSelected = 2;
			break;
		}
	}

	// Token: 0x04001A4F RID: 6735
	public const sbyte TYPE_SEND_REFESH = 0;

	// Token: 0x04001A50 RID: 6736
	public const sbyte TYPE_VIEW_INFO = 1;

	// Token: 0x04001A51 RID: 6737
	public const sbyte TYPE_NHAN = 2;

	// Token: 0x04001A52 RID: 6738
	public const sbyte TYPE_VIEW_LIST_PHAT_LENH = 3;

	// Token: 0x04001A53 RID: 6739
	public const sbyte TYPE_VIEW_LIST_DA_NHAN = 4;

	// Token: 0x04001A54 RID: 6740
	public const sbyte TYPE_VIEW_INFO_PHAT_LENH = 5;

	// Token: 0x04001A55 RID: 6741
	public const sbyte ACTION_VIEW = 0;

	// Token: 0x04001A56 RID: 6742
	public const sbyte ACTION_CANCEL = 1;

	// Token: 0x04001A57 RID: 6743
	public const sbyte ACTION_NHAN_THUONG = 2;

	// Token: 0x04001A58 RID: 6744
	public const sbyte ACTION_REMOVE = 3;

	// Token: 0x04001A59 RID: 6745
	public static WantedList instance;

	// Token: 0x04001A5A RID: 6746
	private iCommand cmdNext;

	// Token: 0x04001A5B RID: 6747
	private iCommand cmdPre;

	// Token: 0x04001A5C RID: 6748
	private iCommand cmdDs;

	// Token: 0x04001A5D RID: 6749
	private iCommand cmdPhat;

	// Token: 0x04001A5E RID: 6750
	private iCommand cmdNhan;

	// Token: 0x04001A5F RID: 6751
	private mVector vecCmd = new mVector();

	// Token: 0x04001A60 RID: 6752
	private sbyte page;

	// Token: 0x04001A61 RID: 6753
	private int countPage;

	// Token: 0x04001A62 RID: 6754
	private int listSize;

	// Token: 0x04001A63 RID: 6755
	private int wDsCmd;

	// Token: 0x04001A64 RID: 6756
	private int idDsCmdSelected;
}
