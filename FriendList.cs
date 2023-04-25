using System;

// Token: 0x02000031 RID: 49
public class FriendList : PaintListScreen
{
	// Token: 0x0600037F RID: 895 RVA: 0x0006FF48 File Offset: 0x0006E148
	public FriendList(sbyte type, mVector vec) : base(type, vec, T.friendList, 200, 180)
	{
		this.cmdRemoveFriend = new iCommand(T.delFriend, 10, this);
		this.cmdRefresh = new iCommand(T.update, 11, this);
		this.vecMenu.removeAllElements();
		bool flag = !GameCanvas.isTouch;
		if (flag)
		{
			this.vecMenu.addElement(this.cmdMenu);
		}
		else
		{
			this.vecMenu.addElement(this.cmdRefresh);
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
		this.menuCMD = this.cmdMenu;
		this.okCMD = this.cmdMenu;
		this.idCommand = 0;
		this.setPosCmdNew(0, this.vecMenu);
	}

	// Token: 0x06000380 RID: 896 RVA: 0x0007003C File Offset: 0x0006E23C
	public static FriendList gI()
	{
		return (FriendList.instance != null) ? FriendList.instance : (FriendList.instance = new FriendList(-2, Player.vecFriendList));
	}

	// Token: 0x06000381 RID: 897 RVA: 0x00070070 File Offset: 0x0006E270
	public override void commandPointer(int index, int subIndex)
	{
		if (index != 10)
		{
			if (index != 11)
			{
				base.commandPointer(index, subIndex);
			}
			else
			{
				GlobalService.gI().Friend(2, 0);
			}
		}
		else
		{
			bool flag = this.memCur != null;
			if (flag)
			{
				GlobalService.gI().Friend(1, this.memCur.id);
			}
		}
	}

	// Token: 0x06000382 RID: 898 RVA: 0x000700D4 File Offset: 0x0006E2D4
	public override void doMenuTouchPlayer()
	{
		bool flag = this.vecPlayer.size() != 0 && this.idSelect >= 0 && this.idSelect < this.vecPlayer.size();
		if (flag)
		{
			this.memCur = (InfoMemList)this.vecPlayer.elementAt(this.idSelect);
			bool flag2 = this.memCur != null && this.memCur.id != (int)GameScreen.player.ID;
			if (flag2)
			{
				mVector mVector = new mVector();
				mVector.addElement(this.cmdInfoPlayer);
				mVector.addElement(this.cmdChat);
				mVector.addElement(this.cmdRemoveFriend);
				mVector.addElement(this.cmdMove);
				GameCanvas.menu.startAt(mVector, 2, this.memCur.name);
			}
		}
	}

	// Token: 0x06000383 RID: 899 RVA: 0x000701B0 File Offset: 0x0006E3B0
	public override void doMenu()
	{
		mVector mVector = new mVector();
		string name = T.menu;
		bool flag = this.idSelect >= 0 && this.idSelect < this.vecPlayer.size();
		if (flag)
		{
			this.memCur = (InfoMemList)this.vecPlayer.elementAt(this.idSelect);
			bool flag2 = this.memCur != null;
			if (flag2)
			{
				mVector.addElement(this.cmdInfoPlayer);
				mVector.addElement(this.cmdChat);
				mVector.addElement(this.cmdRemoveFriend);
				mVector.addElement(this.cmdMove);
				name = this.memCur.name;
			}
		}
		mVector.addElement(this.cmdRefresh);
		GameCanvas.menu.startAt(mVector, 2, name);
	}

	// Token: 0x06000384 RID: 900 RVA: 0x00012C78 File Offset: 0x00010E78
	public override void paintInfo(mGraphics g, InfoMemList mem, int xpaint, int ypaint, int i, int wsub)
	{
		bool flag = mem != null;
		if (flag)
		{
			string text = mem.name;
			bool flag2 = mem.Lv >= 0;
			if (flag2)
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" - ",
					T.Lv,
					" ",
					mem.Lv.ToString()
				});
			}
			AvMain.fraStatusOnline.drawFrame((int)mem.typeOnline, xpaint + 25, ypaint + 5, 0, 3, g);
			mFont.tahoma_7b_black.drawString(g, text, xpaint + 30, ypaint, 0);
			mFont.tahoma_7_black.drawString(g, mem.info, xpaint + 25, ypaint + GameCanvas.hText, 0);
			MainObject.paintHeadEveryWhere(g, mem.head, mem.hair, mem.hat, xpaint + 10, ypaint + this.hItem / 2 + 32, 0);
		}
	}

	// Token: 0x0400056E RID: 1390
	public static bool isGetListFriend;

	// Token: 0x0400056F RID: 1391
	private iCommand cmdRemoveFriend;

	// Token: 0x04000570 RID: 1392
	private iCommand cmdRefresh;

	// Token: 0x04000571 RID: 1393
	public static FriendList instance;
}
