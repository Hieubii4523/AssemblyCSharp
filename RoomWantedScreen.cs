using System;

// Token: 0x020000DD RID: 221
public class RoomWantedScreen : MainScreen
{
	// Token: 0x06000D60 RID: 3424 RVA: 0x00103E48 File Offset: 0x00102048
	public RoomWantedScreen()
	{
		this.w = 240;
		this.h = 215;
		this.x = MotherCanvas.hw - this.w / 2;
		this.y = MotherCanvas.hh - this.h / 2;
		bool flag = !GameCanvas.isTouch;
		if (flag)
		{
			this.y -= 18;
		}
		this.infoPlayer = new InfoMemList((int)GameScreen.player.ID);
		this.infoPlayer.name = GameScreen.player.name;
		this.infoPlayer.charShow = GameScreen.player;
		this.cmdClose = new iCommand(T.close, -1, this);
		this.cmdFind = new iCommand(T.find, 1, this);
		this.cmdCancle = new iCommand(T.findCancle, 2, this);
		this.cmdActionChest = new iCommand(T.open, 3, this);
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.cmdFind.setPos(this.x + 190, this.y + 169, null, this.cmdFind.caption);
			this.cmdCancle.setPos(this.x + 190, this.y + 169, null, this.cmdCancle.caption);
			this.cmdClose.setPos(this.x + this.w - 13, this.y + 13, MainTab.fraCloseTab, string.Empty);
		}
		else
		{
			AvMain.setPosCMD(this.cmdFind, 0);
			AvMain.setPosCMD(this.cmdCancle, 0);
			AvMain.setPosCMD(this.cmdClose, 2);
			AvMain.setPosCMD(this.cmdActionChest, 1);
			this.idSelect = 0;
		}
	}

	// Token: 0x06000D61 RID: 3425 RVA: 0x00104074 File Offset: 0x00102274
	public void setTimeCmdFind(int time)
	{
		bool flag = time > 0 && this.cmdFind != null;
		if (flag)
		{
			this.cmdFind.setTime(time);
		}
	}

	// Token: 0x06000D62 RID: 3426 RVA: 0x001040A8 File Offset: 0x001022A8
	public void setAction(sbyte ac)
	{
		this.vecCmd.removeAllElements();
		this.type = (int)ac;
		bool flag = ac == 0;
		if (flag)
		{
			RoomWantedScreen.instance.Show(GameCanvas.gameScr);
			RoomWantedScreen.instance.strShow = T.wantedClick;
			this.vecCmd.addElement(this.cmdFind);
			this.vecCmd.addElement(this.cmdClose);
			this.okCMD = this.cmdFind;
			this.backCMD = this.cmdClose;
			this.center = this.cmdFind;
			this.right = this.cmdClose;
			this.cmdFind.timeSelect = 0;
			this.cmdFind.isSelect = false;
		}
		else
		{
			bool flag2 = ac == 1;
			if (flag2)
			{
				RoomWantedScreen.instance.strShow = T.wantedWait;
				this.vecCmd.addElement(this.cmdCancle);
				this.vecCmd.addElement(this.cmdClose);
				this.okCMD = this.cmdCancle;
				this.backCMD = this.cmdClose;
				this.center = this.cmdCancle;
				this.right = this.cmdClose;
			}
			else
			{
				bool flag3 = ac == 2;
				if (flag3)
				{
					RoomWantedScreen.instance.strShow = T.wantedReady;
					this.okCMD = null;
					this.backCMD = null;
					this.center = null;
					this.right = null;
				}
				else
				{
					bool flag4 = ac == 3;
					if (flag4)
					{
						RoomWantedScreen.instance.strShow = T.wantedClick;
						this.vecCmd.addElement(this.cmdFind);
						this.vecCmd.addElement(this.cmdClose);
						this.okCMD = this.cmdFind;
						this.backCMD = this.cmdClose;
						this.center = this.cmdFind;
						this.right = this.cmdClose;
						this.cmdFind.timeSelect = 0;
						this.cmdFind.isSelect = false;
					}
				}
			}
		}
	}

	// Token: 0x06000D63 RID: 3427 RVA: 0x00104298 File Offset: 0x00102498
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case -1:
			GlobalService.gI().Room_Wanted(-1);
			GameCanvas.Start_Waiting_Connect_DiaLog(T.pleaseWaiting, true);
			break;
		case 1:
			GlobalService.gI().Room_Wanted(1);
			break;
		case 2:
			GlobalService.gI().Room_Wanted(3);
			break;
		case 3:
		{
			bool flag = Player.mChestWanted[this.idSelect] != null;
			if (flag)
			{
				GlobalService.gI().Chest_Wanted(0, Player.mChestWanted[this.idSelect].ID);
			}
			break;
		}
		}
		base.commandPointer(index, subIndex);
	}

	// Token: 0x06000D64 RID: 3428 RVA: 0x0010433C File Offset: 0x0010253C
	public override void paint(mGraphics g)
	{
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.paint(g);
		}
		GameCanvas.resetTrans(g);
		bool flag2 = !GameCanvas.isSmallScreen;
		if (flag2)
		{
			AvMain.paintBG_Wanted_Room(g, this.x, this.y, this.w, this.h);
		}
		bool lowGraphic = GameCanvas.lowGraphic;
		if (lowGraphic)
		{
			AvMain.paintBG_Wanted(g, this.x + 22, this.y + 30, AvMain.wWanted + 6, AvMain.hWanted, 3);
		}
		else
		{
			AvMain.paintBG_Wanted(g, this.x + 22, this.y + 30, AvMain.wWanted, AvMain.hWanted, 3);
		}
		WantedScreen.paintInfo(g, this.infoPlayer, this.x + 22, this.y + 30, AvMain.wWanted, AvMain.hWanted);
		AvMain.paintRect(g, this.x + 22, this.y + this.h - 22 - 5, this.w - 44, 20, 1, 1);
		string text = this.strShow;
		bool flag3 = this.type == 1;
		if (flag3)
		{
			for (int i = 0; i < GameCanvas.gameTick / 6 % 3; i++)
			{
				text += ".";
			}
		}
		mFont.tahoma_7b_white.drawString(g, text, this.x + this.w / 2, this.y + this.h - 12 - 6 - 5, 2);
		for (int j = 0; j < Player.mChestWanted.Length; j++)
		{
			bool lowGraphic2 = GameCanvas.lowGraphic;
			if (lowGraphic2)
			{
				g.setColor(8336436);
				g.drawRect(this.x + this.posChest[j][0] + 3 - 30, this.y + this.posChest[j][1] + 3 - 30, 54, 54);
				bool flag4 = j == this.idSelect;
				if (flag4)
				{
					g.setColor(16770418);
					g.drawRect(this.x + this.posChest[j][0] + 2 - 30, this.y + this.posChest[j][1] + 2 - 30, 56, 56);
				}
				bool flag5 = Player.mChestWanted[j] != null;
				if (flag5)
				{
					Player.mChestWanted[j].paintRuong(g, this.x + this.posChest[j][0] + 1, this.y + this.posChest[j][1], this.wpos);
				}
			}
			else
			{
				g.drawImage(AvMain.mImgRoomW[0], this.x + this.posChest[j][0], this.y + this.posChest[j][1], 3);
				bool flag6 = Player.mChestWanted[j] != null;
				if (flag6)
				{
					Player.mChestWanted[j].paintRuong(g, this.x + this.posChest[j][0] + 1, this.y + this.posChest[j][1], this.wpos);
				}
				else
				{
					g.drawImage(AvMain.mImgRoomW[1], this.x + this.posChest[j][0], this.y + this.posChest[j][1], 3);
				}
				bool flag7 = !GameCanvas.isTouch && j == this.idSelect;
				if (flag7)
				{
					g.drawRegion(AvMain.mImgRoomW[4], 0, 70 * (GameCanvas.gameTick / 4 % 2), 72, 70, 0, (float)(this.x + this.posChest[j][0]), (float)(this.y + this.posChest[j][1]), 3);
				}
			}
		}
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			for (int k = 0; k < this.vecCmd.size(); k++)
			{
				iCommand iCommand = (iCommand)this.vecCmd.elementAt(k);
				iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
			}
		}
		else
		{
			base.paint(g);
		}
	}

	// Token: 0x06000D65 RID: 3429 RVA: 0x00104768 File Offset: 0x00102968
	public override void update()
	{
		bool flag = this.cmdFind != null && this.cmdFind.timeSelect == 0;
		if (flag)
		{
			this.cmdFind.isSelect = false;
		}
		bool flag2 = this.lastScreen != null;
		if (flag2)
		{
			this.lastScreen.update();
		}
		for (int i = 0; i < Player.mChestWanted.Length; i++)
		{
			bool flag3 = Player.mChestWanted[i] != null && Player.mChestWanted[i].timeUse > 0 && Player.mChestWanted[i].marketTime.CheckUpdate() == 0;
			if (flag3)
			{
				Player.mChestWanted[i].timeUse = 0;
			}
		}
	}

	// Token: 0x06000D66 RID: 3430 RVA: 0x00104818 File Offset: 0x00102A18
	public override void updatekey()
	{
		bool flag = false;
		bool flag2 = GameCanvas.keyMove(1);
		if (flag2)
		{
			bool flag3 = this.idSelect > 0;
			if (flag3)
			{
				this.idSelect--;
			}
			GameCanvas.ClearkeyMove(1);
			flag = true;
		}
		else
		{
			bool flag4 = GameCanvas.keyMove(3);
			if (flag4)
			{
				bool flag5 = this.idSelect < 1;
				if (flag5)
				{
					this.idSelect++;
				}
				GameCanvas.ClearkeyMove(3);
				flag = true;
			}
		}
		bool flag6 = flag;
		if (flag6)
		{
			bool flag7 = Player.mChestWanted[this.idSelect] != null;
			if (flag7)
			{
				this.left = this.cmdActionChest;
				this.menuCMD = this.cmdActionChest;
			}
			else
			{
				this.left = null;
				this.menuCMD = null;
			}
		}
		base.updatekey();
	}

	// Token: 0x06000D67 RID: 3431 RVA: 0x001048E4 File Offset: 0x00102AE4
	public override void updatePointer()
	{
		for (int i = 0; i < this.posChest.Length; i++)
		{
			bool flag = GameCanvas.isPointerSelect && GameCanvas.isPoint(this.x + this.posChest[i][0] - this.wpos / 2, this.y + this.posChest[i][1] - this.wpos / 2, this.wpos, this.wpos);
			if (flag)
			{
				GameCanvas.isPointerSelect = false;
				this.idSelect = i;
				bool flag2 = Player.mChestWanted[i] != null;
				if (flag2)
				{
					this.cmdActionChest.perform();
				}
			}
		}
		for (int j = 0; j < this.vecCmd.size(); j++)
		{
			iCommand iCommand = (iCommand)this.vecCmd.elementAt(j);
			iCommand.updatePointer();
		}
		base.updatePointer();
	}

	// Token: 0x040014A4 RID: 5284
	public static RoomWantedScreen instance;

	// Token: 0x040014A5 RID: 5285
	public string strShow = string.Empty;

	// Token: 0x040014A6 RID: 5286
	public mVector vecCmd = new mVector();

	// Token: 0x040014A7 RID: 5287
	private InfoMemList infoPlayer;

	// Token: 0x040014A8 RID: 5288
	private int x;

	// Token: 0x040014A9 RID: 5289
	private int y;

	// Token: 0x040014AA RID: 5290
	private int w;

	// Token: 0x040014AB RID: 5291
	private int h;

	// Token: 0x040014AC RID: 5292
	private int wpos = 56;

	// Token: 0x040014AD RID: 5293
	private int idSelect = -1;

	// Token: 0x040014AE RID: 5294
	private int type;

	// Token: 0x040014AF RID: 5295
	private iCommand cmdClose;

	// Token: 0x040014B0 RID: 5296
	private iCommand cmdFind;

	// Token: 0x040014B1 RID: 5297
	private iCommand cmdCancle;

	// Token: 0x040014B2 RID: 5298
	private iCommand cmdActionChest;

	// Token: 0x040014B3 RID: 5299
	private int[][] posChest = new int[][]
	{
		new int[]
		{
			190,
			60
		},
		new int[]
		{
			190,
			125
		}
	};
}
