using System;

// Token: 0x020000CE RID: 206
public class PlayerListServer : PaintListScreen
{
	// Token: 0x06000BEA RID: 3050 RVA: 0x000E695C File Offset: 0x000E4B5C
	public PlayerListServer(sbyte type, mVector vec, string name, sbyte page) : base(type, vec, name, 200, 180)
	{
		this.page = page;
		this.cmdNext = new iCommand(T.nextpage, 12, this);
		this.cmdPre = new iCommand(T.prepage, 13, this);
		this.cmdUpdateBlackList = new iCommand(T.update, 14, this);
		this.cmdPosFightClan = new iCommand(T.sapxep, 15, this);
		this.cmdSendListMem = new iCommand(T.xong, 17, this);
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.cmdClose.setPos(this.xSub + 20 + this.wSub - 34, this.ySub - 10, MainTab.fraCloseTab, string.Empty);
			this.right = this.cmdClose;
		}
		bool flag = type == 15;
		if (flag)
		{
			this.cmdPosFightClan = AvMain.setPosCMD(this.cmdPosFightClan, 0);
			this.cmdSendListMem = AvMain.setPosCMD(this.cmdSendListMem, 1);
			this.center = this.cmdPosFightClan;
			this.left = this.cmdSendListMem;
			this.vecMenu.removeAllElements();
			this.vecMenu.addElement(this.cmdClose);
			bool flag2 = !GameCanvas.isTouch;
			if (flag2)
			{
				this.vecMenu.addElement(this.cmdPosFightClan);
			}
			this.vecMenu.addElement(this.cmdSendListMem);
		}
		else
		{
			this.setPosCmdNew(GameCanvas.hCommand + 12, this.vecMenu);
		}
	}

	// Token: 0x06000BEB RID: 3051 RVA: 0x000E6AE4 File Offset: 0x000E4CE4
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 12:
			GlobalService.gI().ListFromServer(3, this.type, this.page + 1);
			return;
		case 13:
			GlobalService.gI().ListFromServer(3, this.type, this.page - 1);
			return;
		case 14:
			GameCanvas.gameScr.cmdBlackList.perform();
			this.isLoad = true;
			return;
		case 15:
			this.getMenuSetPos();
			break;
		case 16:
		{
			bool flag = this.memCur == null;
			if (!flag)
			{
				int rank = this.memCur.rank;
				for (int i = 0; i < this.vecPlayer.size(); i++)
				{
					InfoMemList infoMemList = (InfoMemList)this.vecPlayer.elementAt(i);
					bool flag2 = infoMemList.rank == subIndex;
					if (flag2)
					{
						infoMemList.rank = rank;
					}
				}
				this.memCur.rank = subIndex;
			}
			break;
		}
		case 17:
			CRes.quickSortMemList(this.vecPlayer);
			GlobalService.gI().Clan_Fight_List_Mem(6, this.vecPlayer);
			this.cmdClose.perform();
			break;
		}
		base.commandPointer(index, subIndex);
	}

	// Token: 0x06000BEC RID: 3052 RVA: 0x000E6C38 File Offset: 0x000E4E38
	private void getMenuSetPos()
	{
		bool flag = this.memCur != null;
		if (flag)
		{
			mVector mVector = new mVector();
			int num = this.vecPlayer.size();
			for (int i = 0; i < num; i++)
			{
				iCommand o = new iCommand(T.viTri + (i + 1).ToString(), 16, i, this);
				mVector.addElement(o);
			}
			GameCanvas.menuCur.startAt(mVector, 2, T.sapxep);
		}
	}

	// Token: 0x06000BED RID: 3053 RVA: 0x000E6CB8 File Offset: 0x000E4EB8
	public override void doMenuTouchPlayer()
	{
		bool flag = this.vecPlayer.size() == 0;
		if (!flag)
		{
			this.memCur = (InfoMemList)this.vecPlayer.elementAt(this.idSelect);
			bool flag2 = this.type == 15;
			if (flag2)
			{
				this.getMenuSetPos();
			}
			else
			{
				bool flag3 = this.memCur != null && this.memCur.id != (int)GameScreen.player.ID;
				if (flag3)
				{
					mVector mVector = new mVector();
					bool flag4 = this.memCur.typeOnline == 1;
					if (flag4)
					{
						mVector.addElement(this.cmdInfoPlayer);
					}
					bool flag5 = this.type == 2;
					if (flag5)
					{
						mVector.addElement(this.cmdMove);
					}
					bool flag6 = mVector.size() > 0;
					if (flag6)
					{
						GameCanvas.menu.startAt(mVector, 2, this.memCur.name);
					}
				}
			}
		}
	}

	// Token: 0x06000BEE RID: 3054 RVA: 0x000E6DB4 File Offset: 0x000E4FB4
	public override void doMenu()
	{
		mVector mVector = new mVector();
		string name = T.menu;
		bool flag = this.vecPlayer.size() > 0;
		if (flag)
		{
			this.memCur = (InfoMemList)this.vecPlayer.elementAt(this.idSelect);
			bool flag2 = this.memCur != null && !GameCanvas.isTouch;
			if (flag2)
			{
				mVector.addElement(this.cmdInfoPlayer);
				name = this.memCur.name;
			}
		}
		bool flag3 = this.type == 7 || this.type == 6 || this.type == 4 || this.type == 11 || this.type == 12 || this.type == 13 || this.type == 14 || this.type == 17 || this.type == 16;
		if (flag3)
		{
			mVector.addElement(this.cmdNext);
			mVector.addElement(this.cmdPre);
		}
		else
		{
			bool flag4 = this.type == 2;
			if (flag4)
			{
				mVector.addElement(this.cmdUpdateBlackList);
				bool flag5 = !GameCanvas.isTouch;
				if (flag5)
				{
					mVector.addElement(this.cmdMove);
				}
			}
			else
			{
				bool flag6 = this.type == 15;
				if (flag6)
				{
					mVector.addElement(this.cmdPosFightClan);
				}
			}
		}
		GameCanvas.menu.startAt(mVector, 2, name);
	}

	// Token: 0x06000BEF RID: 3055 RVA: 0x000E6F18 File Offset: 0x000E5118
	public override void paintInfo(mGraphics g, InfoMemList mem, int xpaint, int ypaint, int i, int wsub)
	{
		bool flag = mem == null;
		if (!flag)
		{
			g.setColor(11834730);
			g.fillRect(xpaint, ypaint - 1, 28, 29);
			g.fillRect(xpaint + 32, ypaint - 1, this.wSub - 32 - 60, 29);
			g.setColor(9403484);
			g.fillRect(xpaint + 1, ypaint, 26, 27);
			g.fillRect(xpaint + 32 + 1, ypaint, this.wSub - 34 - 60, 27);
			this.paintIconTop(g, mem, xpaint, ypaint);
			int num = 32;
			xpaint += num;
			bool flag2 = PlayerListServer.typeClan(this.type);
			if (flag2)
			{
				MainImage iconClan = Potion.getIconClan(mem.idmap);
				bool flag3 = iconClan != null && iconClan.img != null;
				if (flag3)
				{
					bool flag4 = iconClan.frame == -1;
					if (flag4)
					{
						iconClan.set_Frame();
					}
					bool flag5 = iconClan.frame <= 1;
					if (flag5)
					{
						g.drawImage(iconClan.img, xpaint + 10, ypaint + 8, 3);
					}
					else
					{
						int num2 = (this.framepaint < (int)(iconClan.frame - 1)) ? 3 : 15;
						bool flag6 = CRes.abs(GameCanvas.gameTick - this.lastTick) > num2;
						if (flag6)
						{
							this.framepaint++;
							bool flag7 = this.framepaint >= (int)iconClan.frame;
							if (flag7)
							{
								this.framepaint = 0;
							}
							this.lastTick = GameCanvas.gameTick;
						}
						g.drawRegion(iconClan.img, 0, this.framepaint * (int)iconClan.w, (int)iconClan.w, (int)iconClan.w, 0, (float)(xpaint + 10), (float)(ypaint + 8), 3);
					}
				}
				mFont.tahoma_7b_black.drawString(g, mem.name, xpaint + 20, ypaint + 2, 0);
				mFont.tahoma_7_black.drawString(g, mem.info, xpaint + 2, ypaint + 1 + GameCanvas.hText, 0);
			}
			else
			{
				bool flag8 = this.type == 15;
				if (flag8)
				{
					string name = mem.name;
					bool isMe = mem.isMe;
					if (isMe)
					{
						AvMain.FontBorderColor(g, name, xpaint + 31 + 20, ypaint, 2, 0, 7);
					}
					else
					{
						mFont.tahoma_7b_black.drawString(g, name, xpaint + 30 + 20, ypaint, 2);
					}
					mFont.tahoma_7_black.drawString(g, mem.info, xpaint + 25 + 25, ypaint + GameCanvas.hText, 2);
				}
				else
				{
					string name2 = mem.name;
					AvMain.fraStatusOnline.drawFrame((int)mem.typeOnline, xpaint + 25, ypaint + 5, 0, 3, g);
					bool isMe2 = mem.isMe;
					if (isMe2)
					{
						AvMain.FontBorderColor(g, name2, xpaint + 31, ypaint, 0, 0, 7);
					}
					else
					{
						mFont.tahoma_7b_black.drawString(g, name2, xpaint + 30, ypaint, 0);
					}
					mFont.tahoma_7_black.drawString(g, mem.info, xpaint + 25, ypaint + GameCanvas.hText, 0);
					MainObject.paintHeadEveryWhere(g, mem.head, mem.hair, mem.hat, xpaint + 10, ypaint + this.hItem / 2 + 32, 0);
				}
			}
		}
	}

	// Token: 0x06000BF0 RID: 3056 RVA: 0x000E7248 File Offset: 0x000E5448
	private void paintIconTop(mGraphics g, InfoMemList mem, int x, int y)
	{
		bool flag = this.type == 15;
		if (flag)
		{
			mFont.tahoma_7b_white.drawString(g, (mem.rank + 1).ToString() + string.Empty, x + 14, y + 8, 2);
		}
		else
		{
			bool flag2 = mem.rank < 10;
			if (flag2)
			{
				bool flag3 = AvMain.fraIconTop == null;
				if (flag3)
				{
					AvMain.fraIconTop = new FrameImage(mImage.createImage("/interface/icontop.png"), 24, 24);
				}
				else
				{
					bool flag4 = mem.rank < 3;
					if (flag4)
					{
						AvMain.fraIconTop.drawFrame(mem.rank, x + 14, y + 14, 0, 3, g);
					}
					else
					{
						AvMain.fraIconTop.drawFrame(3, x + 14, y + 14, 0, 3, g);
					}
				}
			}
			else
			{
				mFont.tahoma_7b_white.drawString(g, (mem.rank + 1).ToString() + string.Empty, x + 14, y + 8, 2);
			}
		}
	}

	// Token: 0x06000BF1 RID: 3057 RVA: 0x000E7350 File Offset: 0x000E5550
	public override void paintBg(mGraphics g)
	{
		AvMain.paintBG_AChi(g, this.xSub, this.ySub - 20, this.wSub, this.hSub + 20, 1);
		mFont.tahoma_7b_brown.drawString(g, this.nameList, this.xSub + this.wSub / 2, this.ySub + GameCanvas.hCommand / 2 + 3, 2);
		bool flag = this.type != 15;
		if (flag)
		{
			mFont.tahoma_7b_black.drawString(g, T.page + ((int)(this.page + 1)).ToString(), this.xSub + this.wSub / 2, this.ySub + this.hSub - GameCanvas.hCommand / 2 - 20, 2);
		}
	}

	// Token: 0x06000BF2 RID: 3058 RVA: 0x000E7418 File Offset: 0x000E5618
	public override void paintSelect(mGraphics g, int xbegin, int ybegin, int wFocus)
	{
		g.setColor(11936290);
		g.fillRect(xbegin, ybegin + this.idSelect * this.hItem, 29, 30);
		g.fillRect(xbegin + 31, ybegin + this.idSelect * this.hItem, this.wSub - 32 - 60 + 1, 30);
	}

	// Token: 0x06000BF3 RID: 3059 RVA: 0x000E7478 File Offset: 0x000E5678
	public static bool typeClan(sbyte type)
	{
		return type == 6 || type == 11 || type == 12 || type == 14 || type == 13;
	}

	// Token: 0x040012BB RID: 4795
	private iCommand cmdNext;

	// Token: 0x040012BC RID: 4796
	private iCommand cmdPre;

	// Token: 0x040012BD RID: 4797
	private iCommand cmdUpdateBlackList;

	// Token: 0x040012BE RID: 4798
	private iCommand cmdPosFightClan;

	// Token: 0x040012BF RID: 4799
	private iCommand cmdSendListMem;

	// Token: 0x040012C0 RID: 4800
	private sbyte page;

	// Token: 0x040012C1 RID: 4801
	public static PlayerListServer instance;

	// Token: 0x040012C2 RID: 4802
	private int lastTick;

	// Token: 0x040012C3 RID: 4803
	private int framepaint;
}
