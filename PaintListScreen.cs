using System;

// Token: 0x020000C5 RID: 197
public class PaintListScreen : SubScreen
{
	// Token: 0x06000B6E RID: 2926 RVA: 0x000DC57C File Offset: 0x000DA77C
	public PaintListScreen(sbyte type, mVector vec, string name, int maxWSub, int H) : base(type)
	{
		this.vecPlayer = vec;
		this.textrong = T.textrong;
		this.nameList = name;
		this.wSub = MotherCanvas.w - 30;
		this.hItem = 34;
		bool flag = this.wSub > maxWSub;
		if (flag)
		{
			this.wSub = maxWSub;
		}
		this.hSub = H;
		bool flag2 = this.hSub > MotherCanvas.h - GameCanvas.hCommand;
		if (flag2)
		{
			this.hSub = MotherCanvas.h - GameCanvas.hCommand;
		}
		this.xSub = MotherCanvas.hw - this.wSub / 2;
		this.ySub = MotherCanvas.hh - this.hSub / 2;
		this.hContent = this.hSub - GameCanvas.hCommand - 10 - iCommand.hButtonCmdNor;
		this.cmdMenu = new iCommand(T.cmdChucNang, 0, 0, this);
		this.cmdClose = new iCommand(T.close, 2, 0, this);
		this.cmdMove = new iCommand(T.dichchuyen, -1, 0, this);
		this.cmdMenuTouchPlayer = new iCommand(T.menu, 100, 0, this);
		this.vecMenu.removeAllElements();
		this.vecMenu.addElement(this.cmdMenu);
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.cmdClose.setPos(this.xSub + 20 + this.wSub - 40, this.ySub + GameCanvas.hCommand / 2 - 2 + 8, MainTab.fraCloseTab, string.Empty);
			this.right = this.cmdClose;
		}
		else
		{
			this.vecMenu.addElement(this.cmdClose);
		}
		this.idCommand = 0;
		this.list = new ListNew();
		this.setPosCmdNew(0, this.vecMenu);
		this.cmdInfoPlayer = new iCommand(T.info, 4, 0, this);
		this.cmdChat = new iCommand(T.chat, 5, 0, this);
		this.cmdAddFriend = new iCommand(T.addFriend, 6, 0, this);
		this.backCMD = this.cmdClose;
		this.okCMD = this.cmdMenuTouchPlayer;
		this.menuCMD = this.cmdMenu;
	}

	// Token: 0x06000B6F RID: 2927 RVA: 0x000DC7C8 File Offset: 0x000DA9C8
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case -1:
		{
			bool flag = this.memCur != null;
			if (flag)
			{
				GlobalService.gI().Move_To_Player(0, this.memCur.id);
			}
			break;
		}
		case 0:
			this.doMenu();
			break;
		case 1:
			this.doMenuTouchPlayer();
			break;
		case 2:
		{
			bool flag2 = this.lastScreen != null;
			if (flag2)
			{
				this.lastScreen.Show(this.lastScreen.lastScreen);
			}
			else
			{
				GameCanvas.gameScr.Show();
			}
			break;
		}
		case 3:
			break;
		case 4:
		{
			bool flag3 = this.memCur != null;
			if (flag3)
			{
				GameCanvas.gameScr.ShowInfoOtherPlayer(this.memCur.name);
			}
			break;
		}
		case 5:
		{
			bool flag4 = this.memCur != null;
			if (flag4)
			{
				GameCanvas.chatTabScr.addNewChat(this.memCur.name, string.Empty, string.Empty, 0, true);
				GameCanvas.chatTabScr.Show(GameCanvas.gameScr);
			}
			break;
		}
		case 6:
		{
			bool flag5 = this.memCur != null;
			if (flag5)
			{
				GlobalService.gI().Friend(0, this.memCur.id);
			}
			break;
		}
		default:
			if (index == 100)
			{
				this.doMenuTouchPlayer();
			}
			break;
		}
	}

	// Token: 0x06000B70 RID: 2928 RVA: 0x000DC930 File Offset: 0x000DAB30
	public virtual void setCamera()
	{
		int limX = this.vecPlayer.size() * this.hItem - this.hContent + this.miniItem * 2;
		this.list = new ListNew(this.xSub, this.ySub + GameCanvas.hCommand, this.wSub, this.hContent, 0, 0, limX, true);
	}

	// Token: 0x06000B71 RID: 2929 RVA: 0x0000B8AF File Offset: 0x00009AAF
	public override void Show(MainScreen screen)
	{
		base.Show(screen);
		this.beginShow();
		this.updateInfo();
	}

	// Token: 0x06000B72 RID: 2930 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void beginShow()
	{
	}

	// Token: 0x06000B73 RID: 2931 RVA: 0x000DC990 File Offset: 0x000DAB90
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
			bool flag3 = this.isLoad;
			if (flag3)
			{
				MsgDialog.fraImgWaiting.drawFrame(GameCanvas.gameTick / 6 % MsgDialog.fraImgWaiting.nFrame, this.xSub + this.wSub / 2, num2 + this.hItem, 0, 3, g);
			}
			else
			{
				bool flag4 = this.vecPlayer.size() == 0;
				if (flag4)
				{
					mFont.tahoma_7_black.drawString(g, this.textrong, this.xSub + this.wSub / 2, this.ySub + this.hSub / 2, 2);
				}
				else
				{
					bool flag5 = this.idSelect >= 0 && (GameCanvas.isTouchNoOrPC() || this.timeShowFocus > 0);
					if (flag5)
					{
						this.paintSelect(g, num, num2 - 2, this.wSub - 40);
					}
					for (int i = 0; i < this.vecPlayer.size(); i++)
					{
						InfoMemList mem = (InfoMemList)this.vecPlayer.elementAt(i);
						this.paintInfo(g, mem, num, num2, i, this.wSub - 60);
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
			bool flag7 = this.right != null;
			if (flag7)
			{
				this.right.paint(g, this.right.xCmd, this.right.yCmd);
			}
		}
	}

	// Token: 0x06000B74 RID: 2932 RVA: 0x000DCC4C File Offset: 0x000DAE4C
	public virtual void paintBg(mGraphics g)
	{
		base.paintPaper_UpDown(g, this.xSub, this.ySub, this.wSub, this.hSub, this.hSub);
		g.setColor(15972174);
		g.fillRoundRect(this.xSub + 20, this.ySub + GameCanvas.hCommand / 2 - 2, this.wSub - 40, 16, 4, 4);
		mFont.tahoma_7b_red.drawString(g, this.nameList, this.xSub + this.wSub / 2, this.ySub + GameCanvas.hCommand / 2, 2);
	}

	// Token: 0x06000B75 RID: 2933 RVA: 0x000DCCEC File Offset: 0x000DAEEC
	public virtual void paintSelect(mGraphics g, int xbegin, int ybegin, int wFocus)
	{
		xbegin -= 10;
		g.setColor(12629427);
		g.fillRect(xbegin + this.miniItem / 2, ybegin + this.idSelect * this.hItem, wFocus - this.miniItem / 2, this.hItem);
	}

	// Token: 0x06000B76 RID: 2934 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void paintInfo(mGraphics g, InfoMemList mem, int xpaint, int ypaint, int i, int wsub)
	{
	}

	// Token: 0x06000B77 RID: 2935 RVA: 0x000DCD40 File Offset: 0x000DAF40
	public override void update()
	{
		this.list.moveCamera();
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.update();
		}
		bool flag2 = !GameCanvas.menuCur.isShowMenu && GameCanvas.currentDialog == null && this.timeShowFocus > 0;
		if (flag2)
		{
			this.timeShowFocus--;
		}
	}

	// Token: 0x06000B78 RID: 2936 RVA: 0x000DCDA8 File Offset: 0x000DAFA8
	public override void updatekey()
	{
		bool flag = this.vecMenu != null;
		if (flag)
		{
			int num = this.vecMenu.size();
			bool flag2 = GameCanvas.isTouchNoOrPC() && num > 0;
			if (flag2)
			{
				int num2 = this.idCommand;
				bool flag3 = GameCanvas.keyMove(0);
				if (flag3)
				{
					this.idCommand--;
					GameCanvas.ClearkeyMove(0);
				}
				else
				{
					bool flag4 = GameCanvas.keyMove(2);
					if (flag4)
					{
						this.idCommand++;
						GameCanvas.ClearkeyMove(2);
					}
				}
				this.idCommand = AvMain.resetSelect(this.idCommand, num - 1, false);
				bool flag5 = num2 != this.idCommand && GameCanvas.isTouchNoOrPC();
				if (flag5)
				{
					for (int i = 0; i < num; i++)
					{
						iCommand iCommand = (iCommand)this.vecMenu.elementAt(i);
						bool flag6 = i == this.idCommand;
						if (flag6)
						{
							iCommand.isSelect = true;
						}
						else
						{
							iCommand.isSelect = false;
						}
					}
				}
			}
		}
		bool flag7 = false;
		bool flag8 = GameCanvas.keyMove(1);
		if (flag8)
		{
			this.idSelect--;
			GameCanvas.ClearkeyMove(1);
			flag7 = true;
		}
		else
		{
			bool flag9 = GameCanvas.keyMove(3);
			if (flag9)
			{
				this.idSelect++;
				GameCanvas.ClearkeyMove(3);
				flag7 = true;
			}
		}
		bool flag10 = flag7;
		if (flag10)
		{
			this.idSelect = AvMain.resetSelect(this.idSelect, this.vecPlayer.size() - 1, false);
			this.list.setToX((this.idSelect + 1) * this.hItem - this.hContent / 2);
		}
		bool flag11 = GameCanvas.keyMyHold[5];
		if (flag11)
		{
			GameCanvas.clearKeyHold(5);
			bool flag12 = this.vecMenu != null && this.idCommand < this.vecMenu.size();
			if (flag12)
			{
				((iCommand)this.vecMenu.elementAt(this.idCommand)).perform();
			}
		}
		this.updatekeyPC();
	}

	// Token: 0x06000B79 RID: 2937 RVA: 0x000DCFB8 File Offset: 0x000DB1B8
	public override void updatePointer()
	{
		this.list.update_Pos_UP_DOWN();
		base.updatePointer();
		bool flag = this.vecMenu != null;
		if (flag)
		{
			for (int i = 0; i < this.vecMenu.size(); i++)
			{
				iCommand iCommand = (iCommand)this.vecMenu.elementAt(i);
				iCommand.updatePointer();
			}
		}
		bool flag2 = !GameCanvas.isPointerSelect || this.vecPlayer.size() <= 0 || !GameCanvas.isPoint(this.xSub, this.ySub + GameCanvas.hCommand, this.wSub, this.hContent);
		if (!flag2)
		{
			GameCanvas.isPointerSelect = false;
			int num = (GameCanvas.py - (this.ySub + GameCanvas.hCommand) + this.list.cmx) / this.hItem;
			bool flag3 = num < 0 || num >= this.vecPlayer.size();
			if (!flag3)
			{
				bool flag4 = this.isDelEvent;
				if (flag4)
				{
					bool flag5 = GameCanvas.px < this.xSub + 30 + (this.wSub - 60) + 15 && GameCanvas.px > this.xSub + 30 + (this.wSub - 60) - 15 && num > 0;
					if (flag5)
					{
						InfoMemList mem = (InfoMemList)this.vecPlayer.elementAt(num);
						this.delMem(mem);
					}
					else
					{
						this.idSelect = num;
						this.doMenuTouchPlayer();
						this.timeShowFocus = 5;
					}
				}
				else
				{
					this.idSelect = num;
					this.doMenuTouchPlayer();
					this.timeShowFocus = 5;
				}
			}
		}
	}

	// Token: 0x06000B7A RID: 2938 RVA: 0x000DD164 File Offset: 0x000DB364
	public void updateInfo()
	{
		this.setCamera();
		bool flag = !GameCanvas.isTouch;
		if (flag)
		{
			bool flag2 = this.vecPlayer.size() == 0;
			if (flag2)
			{
				this.idSelect = -1;
			}
			bool flag3 = this.idSelect >= this.vecPlayer.size();
			if (flag3)
			{
				this.idSelect = 0;
			}
		}
	}

	// Token: 0x06000B7B RID: 2939 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void doMenuTouchPlayer()
	{
	}

	// Token: 0x06000B7C RID: 2940 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void doMenu()
	{
	}

	// Token: 0x06000B7D RID: 2941 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void delMem(InfoMemList mem)
	{
	}

	// Token: 0x06000B7E RID: 2942 RVA: 0x000DD1C8 File Offset: 0x000DB3C8
	public override bool keyBack()
	{
		bool flag = !base.keyBack() && this.cmdClose != null;
		if (flag)
		{
			this.cmdClose.perform();
		}
		return false;
	}

	// Token: 0x06000B7F RID: 2943 RVA: 0x000DD204 File Offset: 0x000DB404
	public void setClip(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		g.setClip(this.xSub, this.ySub + this.hBegin - 1, this.wSub, this.hContent - this.miniItem);
		g.saveCanvas();
		g.ClipRec(this.xSub, this.ySub + this.hBegin - 1, this.wSub, this.hContent - this.miniItem);
		g.translate(0, -this.list.cmx);
	}

	// Token: 0x04001124 RID: 4388
	public const sbyte DUNGONE_LIST = -4;

	// Token: 0x04001125 RID: 4389
	public const sbyte EVENT_LIST = -3;

	// Token: 0x04001126 RID: 4390
	public const sbyte FRIEND_LIST = -2;

	// Token: 0x04001127 RID: 4391
	public const sbyte PARTY_LIST = -1;

	// Token: 0x04001128 RID: 4392
	public const sbyte BLACK_LIST = 2;

	// Token: 0x04001129 RID: 4393
	public const sbyte ID_GET_PAGE = 3;

	// Token: 0x0400112A RID: 4394
	public const sbyte PLAYER_LIST_LV = 4;

	// Token: 0x0400112B RID: 4395
	public const sbyte MEM_CLAN_LIST = 5;

	// Token: 0x0400112C RID: 4396
	public const sbyte CLAN_LIST = 6;

	// Token: 0x0400112D RID: 4397
	public const sbyte PLAYER_LIST_PVP = 7;

	// Token: 0x0400112E RID: 4398
	public const sbyte PLAYER_LIST_WANTED = 9;

	// Token: 0x0400112F RID: 4399
	public const sbyte TOP_CLAN_LEVEL_PLAYER = 11;

	// Token: 0x04001130 RID: 4400
	public const sbyte TOP_CLAN_PVP = 12;

	// Token: 0x04001131 RID: 4401
	public const sbyte TOP_CLAN_TRUY_NA = 13;

	// Token: 0x04001132 RID: 4402
	public const sbyte TOP_CLAN_THANH_TICH = 14;

	// Token: 0x04001133 RID: 4403
	public const sbyte LIST_MEM_FIGHT_CLAN = 15;

	// Token: 0x04001134 RID: 4404
	public const sbyte LIST_MEM_TOP_PHAO = 16;

	// Token: 0x04001135 RID: 4405
	public const sbyte LIST_MEM_FIGHT_SUPER_BOSS = 17;

	// Token: 0x04001136 RID: 4406
	public string textrong = string.Empty;

	// Token: 0x04001137 RID: 4407
	public int hContent;

	// Token: 0x04001138 RID: 4408
	public mVector vecMenu = new mVector();

	// Token: 0x04001139 RID: 4409
	public ListNew list;

	// Token: 0x0400113A RID: 4410
	public InfoMemList memCur;

	// Token: 0x0400113B RID: 4411
	public int timeShowFocus;

	// Token: 0x0400113C RID: 4412
	public int miniItem = 5;

	// Token: 0x0400113D RID: 4413
	public int idSelect;

	// Token: 0x0400113E RID: 4414
	public int idCommand;

	// Token: 0x0400113F RID: 4415
	public mVector vecPlayer;

	// Token: 0x04001140 RID: 4416
	public string nameList = string.Empty;

	// Token: 0x04001141 RID: 4417
	public iCommand cmdMenu;

	// Token: 0x04001142 RID: 4418
	public iCommand cmdClose;

	// Token: 0x04001143 RID: 4419
	public iCommand cmdInfoPlayer;

	// Token: 0x04001144 RID: 4420
	public iCommand cmdChat;

	// Token: 0x04001145 RID: 4421
	public iCommand cmdAddFriend;

	// Token: 0x04001146 RID: 4422
	public iCommand cmdMove;

	// Token: 0x04001147 RID: 4423
	public iCommand cmdMenuTouchPlayer;

	// Token: 0x04001148 RID: 4424
	public int hBegin;

	// Token: 0x04001149 RID: 4425
	public bool isLoad;

	// Token: 0x0400114A RID: 4426
	public bool isDelEvent;
}
