using System;

// Token: 0x020000C9 RID: 201
public class PartyScreen : PaintListScreen
{
	// Token: 0x06000B83 RID: 2947 RVA: 0x000DD294 File Offset: 0x000DB494
	public PartyScreen(sbyte type, mVector vec) : base(type, vec, T.infoParty, 180, 180)
	{
		this.cmdRemoveMem = new iCommand(T.kickParty, 3, 0, this);
		this.cmdLeave = new iCommand(T.leave + " " + T.party, 7, 0, this);
		this.cmdCancelParty = new iCommand(T.cancel + " " + T.party, 8, 0, this);
		this.cmdChatParty = new iCommand(T.TroChuyen + " " + T.party, 9, 0, this);
		this.cmdInfoBuffParty = new iCommand(T.AttriParty, 10, 0, this);
		this.backCMD = this.cmdClose;
		this.okCMD = this.cmdMenuTouchPlayer;
		this.menuCMD = this.cmdMenu;
	}

	// Token: 0x06000B84 RID: 2948 RVA: 0x000DD36C File Offset: 0x000DB56C
	public static PartyScreen gI()
	{
		return (PartyScreen.instance != null) ? PartyScreen.instance : (PartyScreen.instance = new PartyScreen(-1, Player.vecParty));
	}

	// Token: 0x06000B85 RID: 2949 RVA: 0x000DD3A0 File Offset: 0x000DB5A0
	public override void beginShow()
	{
		bool flag = GameCanvas.isTouchNoOrPC();
		if (flag)
		{
			this.idCommand = 0;
		}
		this.setPosCmdNew(0, this.vecMenu);
	}

	// Token: 0x06000B86 RID: 2950 RVA: 0x000DD3D0 File Offset: 0x000DB5D0
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 3:
		{
			bool flag = this.memCur != null;
			if (flag)
			{
				GlobalService.gI().Party(2, (short)this.memCur.id);
			}
			return;
		}
		case 7:
			GlobalService.gI().Party(2, GameScreen.player.ID);
			return;
		case 8:
			GlobalService.gI().Party(3, GameScreen.player.ID);
			return;
		case 9:
			GameCanvas.chatTabScr.addNewChat(T.party, string.Empty, string.Empty, 0, true);
			GameCanvas.chatTabScr.Show(PartyScreen.gI());
			return;
		case 10:
		{
			MsgDialog msgDialog = new MsgDialog();
			msgDialog.setinfoParty(GameScreen.player.vecAllInfoParty);
			GameCanvas.Start_Current_Dialog(msgDialog);
			return;
		}
		}
		base.commandPointer(index, subIndex);
	}

	// Token: 0x06000B87 RID: 2951 RVA: 0x000DD4C8 File Offset: 0x000DB6C8
	public override void doMenuTouchPlayer()
	{
		bool flag = this.vecPlayer.size() == 0;
		if (!flag)
		{
			this.memCur = (InfoMemList)this.vecPlayer.elementAt(this.idSelect);
			bool flag2 = this.memCur != null && this.memCur.id != (int)GameScreen.player.ID;
			if (flag2)
			{
				mVector mVector = new mVector();
				InfoMemList mem = InfoMemList.getMem((int)GameScreen.player.ID, Player.vecParty);
				sbyte b = 1;
				bool flag3 = mem != null;
				if (flag3)
				{
					b = mem.isMain;
				}
				mVector.addElement(this.cmdInfoPlayer);
				mVector.addElement(this.cmdChat);
				mVector.addElement(this.cmdAddFriend);
				bool flag4 = b == 1;
				if (flag4)
				{
					mVector.addElement(this.cmdRemoveMem);
				}
				GameCanvas.menu.startAt(mVector, 2, this.memCur.name);
			}
		}
	}

	// Token: 0x06000B88 RID: 2952 RVA: 0x000DD5C4 File Offset: 0x000DB7C4
	public override void doMenu()
	{
		bool flag = this.vecPlayer.size() == 0;
		if (!flag)
		{
			this.memCur = (InfoMemList)this.vecPlayer.elementAt(this.idSelect);
			bool flag2 = this.memCur == null;
			if (!flag2)
			{
				mVector mVector = new mVector();
				mVector.addElement(this.cmdLeave);
				mVector.addElement(this.cmdChatParty);
				mVector.addElement(this.cmdInfoBuffParty);
				InfoMemList mem = InfoMemList.getMem((int)GameScreen.player.ID, Player.vecParty);
				sbyte b = 1;
				bool flag3 = mem != null;
				if (flag3)
				{
					b = mem.isMain;
				}
				bool flag4 = b == 1;
				if (flag4)
				{
					mVector.addElement(this.cmdCancelParty);
					bool flag5 = !GameCanvas.isTouch;
					if (flag5)
					{
						mVector.addElement(this.cmdRemoveMem);
					}
				}
				bool flag6 = !GameCanvas.isTouch;
				if (flag6)
				{
					mVector.addElement(this.cmdInfoPlayer);
					mVector.addElement(this.cmdChat);
					mVector.addElement(this.cmdAddFriend);
				}
				GameCanvas.menu.startAt(mVector, 2, this.memCur.name);
			}
		}
	}

	// Token: 0x06000B89 RID: 2953 RVA: 0x000DD6F8 File Offset: 0x000DB8F8
	public override void paintInfo(mGraphics g, InfoMemList mem, int xpaint, int ypaint, int i, int wsub)
	{
		string text = mem.name;
		bool flag = mem.Lv >= 0;
		if (flag)
		{
			text = text + " - " + mem.Lv.ToString();
		}
		bool flag2 = i == 0;
		if (flag2)
		{
			AvMain.Font3dColor(g, text, xpaint, ypaint, 0, 0, 7);
		}
		else
		{
			mFont.tahoma_7b_blue.drawString(g, text, xpaint, ypaint, 0);
		}
		Interface_Game.PaintHPMP(g, 1, mem.hp, mem.maxhp, xpaint, ypaint + 12, 0, 6, 66, -1, false, 0, false, 0);
		mFont.tahoma_7_black.drawString(g, string.Concat(new string[]
		{
			LoadMap.getNameMap((int)mem.idmap),
			" ",
			T.Area,
			" ",
			LoadMap.getShowArea((sbyte)mem.idArea).ToString()
		}), xpaint + this.miniItem, ypaint + 19, 0);
	}

	// Token: 0x06000B8A RID: 2954 RVA: 0x000DD7EC File Offset: 0x000DB9EC
	public override void update()
	{
		base.update();
		bool flag = GameCanvas.gameTick % 100 != 0;
		if (!flag)
		{
			for (int i = 0; i < GameScreen.vecPlayers.size(); i++)
			{
				MainObject mainObject = (MainObject)GameScreen.vecPlayers.elementAt(i);
				for (int j = 0; j < Player.vecParty.size(); j++)
				{
					InfoMemList infoMemList = (InfoMemList)Player.vecParty.elementAt(j);
					bool flag2 = infoMemList.id == (int)mainObject.ID && mainObject.typeObject == 0;
					if (flag2)
					{
						infoMemList.updateHP(mainObject.Hp, mainObject.maxHp, mainObject.Lv);
					}
				}
			}
		}
	}

	// Token: 0x04001156 RID: 4438
	private iCommand cmdRemoveMem;

	// Token: 0x04001157 RID: 4439
	private iCommand cmdLeave;

	// Token: 0x04001158 RID: 4440
	private iCommand cmdCancelParty;

	// Token: 0x04001159 RID: 4441
	private iCommand cmdChatParty;

	// Token: 0x0400115A RID: 4442
	private iCommand cmdInfoBuffParty;

	// Token: 0x0400115B RID: 4443
	public static PartyScreen instance;
}
