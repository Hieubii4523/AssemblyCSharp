using System;

// Token: 0x020000D9 RID: 217
public class QuickMenu : Menu
{
	// Token: 0x06000C4F RID: 3151 RVA: 0x000EB8EC File Offset: 0x000E9AEC
	public static QuickMenu gI()
	{
		return (QuickMenu.instance != null) ? QuickMenu.instance : (QuickMenu.instance = new QuickMenu());
	}

	// Token: 0x06000C50 RID: 3152 RVA: 0x000EB918 File Offset: 0x000E9B18
	public void startAt()
	{
		base.beginMenu();
		this.isClose = false;
		this.cmdClose = new iCommand(string.Empty, -1, this);
		bool flag = GameCanvas.isTouchNoOrPC();
		if (flag)
		{
			this.menuSelectedItem = 0;
		}
		else
		{
			this.menuSelectedItem = -1;
		}
		this.menuItems = new mVector();
		for (int i = 0; i < QuickMenu.mValueCmd.Length; i++)
		{
			bool flag2 = QuickMenu.mValueCmd[i][0] <= 5 || (QuickMenu.mValueCmd[i][0] == 6 && Player.vecParty.size() > 0) || QuickMenu.mValueCmd[i][0] == 7 || QuickMenu.mValueCmd[i][0] == 8 || QuickMenu.mValueCmd[i][0] == 9 || QuickMenu.mValueCmd[i][0] == 12 || QuickMenu.mValueCmd[i][0] == 11 || (QuickMenu.mValueCmd[i][0] == 10 && GameScreen.player.clan != null) || QuickMenu.mValueCmd[i][0] == 13 || QuickMenu.mValueCmd[i][0] == 14 || QuickMenu.mValueCmd[i][0] == 15;
			if (flag2)
			{
				iCommand iCommand = new iCommand(this.getTextCmd(QuickMenu.mValueCmd[i][0]), QuickMenu.mValueCmd[i][0], this);
				iCommand.setFraCaption(QuickMenu.fraQuickMenu[QuickMenu.mValueCmd[i][1]]);
				this.menuItems.addElement(iCommand);
			}
		}
		this.wUni = 60;
		this.xEff = -40;
		this.menuW = 50;
		this.menuX = 0;
		bool isTaiTho = GameCanvas.isTaiTho;
		if (isTaiTho)
		{
			this.menuX = 30;
		}
		this.menuY = 0;
		this.list = new ListNew(this.menuX, this.menuY, this.menuW, MotherCanvas.h, 0, 0, this.menuItems.size() * this.menuW - MotherCanvas.h, true);
		base.resetBegin();
		this.isShowMenu = true;
		GameCanvas.ShowMenu(QuickMenu.gI());
		this.backCMD = this.cmdClose;
	}

	// Token: 0x06000C51 RID: 3153 RVA: 0x000EBB20 File Offset: 0x000E9D20
	public string getTextCmd(int index)
	{
		bool flag = index >= 0 && index < T.mQuickMenu.Length;
		string result;
		if (flag)
		{
			result = T.mQuickMenu[index];
		}
		else
		{
			result = T.select;
		}
		return result;
	}

	// Token: 0x06000C52 RID: 3154 RVA: 0x000EBB58 File Offset: 0x000E9D58
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case -1:
			this.isClose = true;
			break;
		case 0:
		{
			mVector mVector = new mVector();
			mVector.addElement(GameCanvas.gameScr.cmdFriendList);
			mVector.addElement(GameCanvas.gameScr.cmdBlackList);
			GameCanvas.menu.startAt(mVector, 2, T.danhsach);
			break;
		}
		case 1:
			GameCanvas.gameScr.cmdBlackList.perform();
			break;
		case 2:
			GameCanvas.gameScr.cmdAuto.perform();
			break;
		case 3:
		{
			mVector mVector2 = new mVector();
			mVector2.addElement(GameCanvas.gameScr.cmdSetPk);
			mVector2.addElement(GameCanvas.gameScr.cmdSetDosat);
			GameCanvas.menu.startAt(mVector2, 2, T.chonco);
			break;
		}
		case 4:
			GameCanvas.gameScr.cmdSetDosat.perform();
			break;
		case 5:
			GameCanvas.gameScr.cmdChangeTouch.perform();
			break;
		case 6:
			GameCanvas.gameScr.cmdParty.perform();
			break;
		case 7:
			GameCanvas.gameScr.cmdQuickChat.perform();
			break;
		case 8:
			GameCanvas.gameScr.cmdLogOut.perform();
			break;
		case 9:
			GameCanvas.gameScr.cmdShowWC.perform();
			break;
		case 10:
			GameCanvas.gameScr.cmdClan.perform();
			break;
		case 11:
		{
			bool flag = !GameCanvas.isIos();
			if (flag)
			{
				GameCanvas.gameScr.cmdBuyGem.perform();
			}
			break;
		}
		case 12:
			GameCanvas.gameScr.cmdUniform.perform();
			break;
		case 13:
			GameCanvas.gameScr.cmdDauGia.perform();
			break;
		case 14:
			GameCanvas.gameScr.cmdSudo.perform();
			break;
		case 15:
			GameCanvas.gameScr.cmdPet.perform();
			break;
		}
	}

	// Token: 0x06000C53 RID: 3155 RVA: 0x000EBD68 File Offset: 0x000E9F68
	public override void paintMenu(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		int num = this.menuX + this.xEff;
		for (int i = 0; i <= MotherCanvas.h / this.wUni; i++)
		{
			g.drawImage(QuickMenu.imgNenMenu, num, i * this.wUni, 0);
		}
		bool isTaiTho = GameCanvas.isTaiTho;
		if (isTaiTho)
		{
			for (int j = 0; j <= MotherCanvas.h / this.wUni; j++)
			{
				g.drawImage(QuickMenu.imgNenMenu, num - 60, j * this.wUni, 0);
			}
		}
		int num2 = 0;
		bool flag = this.xEff != 0;
		if (flag)
		{
			num2 = 1;
		}
		g.drawRegion(QuickMenu.imgTamGiac, 0, num2 * 24, 13, 24, 0, (float)(num + this.wUni), (float)(MotherCanvas.h / 2 - 12), 0);
		g.setColor(this.color[num2 * 2]);
		g.fillRect(num + this.wUni + 1, 0, 1, MotherCanvas.h / 2 - 12);
		g.fillRect(num + this.wUni + 1, MotherCanvas.h / 2 + 12, 1, MotherCanvas.h / 2 - 12);
		g.setColor(this.color[num2 * 2 + 1]);
		g.fillRect(num + this.wUni, 0, 1, MotherCanvas.h / 2 - 11);
		g.fillRect(num + this.wUni, MotherCanvas.h / 2 + 11, 1, MotherCanvas.h / 2 - 11);
		g.translate(0, -this.list.cmx);
		for (int k = 0; k < this.menuItems.size(); k++)
		{
			iCommand iCommand = (iCommand)this.menuItems.elementAt(k);
			sbyte focus = 0;
			bool flag2 = this.menuSelectedItem == k;
			if (flag2)
			{
				focus = 1;
			}
			iCommand.paintOnlyImage(g, num + this.wUni / 2, this.menuY + this.menuW / 2 + k * this.menuW - 5, focus);
			mFont.tahoma_7_white.drawString(g, iCommand.caption, num + this.wUni / 2, this.menuY + this.menuW / 2 + 7 + k * this.menuW, 2);
		}
	}

	// Token: 0x06000C54 RID: 3156 RVA: 0x000EBFC8 File Offset: 0x000EA1C8
	public override void updateMenu()
	{
		bool flag = !this.isClose;
		if (flag)
		{
			bool flag2 = this.xEff < 0;
			if (flag2)
			{
				this.xEff += this.speed;
			}
			this.list.moveCamera();
			this.updatePointer();
		}
		else
		{
			this.xEff -= this.speed;
			bool flag3 = this.xEff < -this.wUni;
			if (flag3)
			{
				this.isShowMenu = false;
			}
		}
	}

	// Token: 0x06000C55 RID: 3157 RVA: 0x000EC050 File Offset: 0x000EA250
	public override void updatePointer()
	{
		bool isPointerSelect = GameCanvas.isPointerSelect;
		if (isPointerSelect)
		{
			bool flag = !GameCanvas.isPoint(this.menuX, this.menuY, this.menuW, MotherCanvas.h);
			if (flag)
			{
				this.isClose = true;
			}
			else
			{
				int num = (this.list.cmx + GameCanvas.py) / this.menuW;
				bool flag2 = num >= 0 && num < this.menuItems.size();
				if (flag2)
				{
					iCommand iCommand = (iCommand)this.menuItems.elementAt(num);
					iCommand.perform();
					this.isShowMenu = false;
				}
			}
		}
		this.list.update_Pos_UP_DOWN();
		base.updatePointer();
	}

	// Token: 0x06000C56 RID: 3158 RVA: 0x000EC108 File Offset: 0x000EA308
	public override void updateMenuKey()
	{
		int menuSelectedItem = this.menuSelectedItem;
		bool flag = GameCanvas.keyMove(0) || GameCanvas.keyMove(1);
		if (flag)
		{
			this.menuSelectedItem--;
			GameCanvas.ClearkeyMove(0);
			GameCanvas.ClearkeyMove(1);
		}
		else
		{
			bool flag2 = GameCanvas.keyMove(2) || GameCanvas.keyMove(3);
			if (flag2)
			{
				this.menuSelectedItem++;
				GameCanvas.ClearkeyMove(2);
				GameCanvas.ClearkeyMove(3);
			}
		}
		this.menuSelectedItem = AvMain.resetSelect(this.menuSelectedItem, this.menuItems.size() - 1, false);
		bool flag3 = GameCanvas.keyMyHold[5];
		if (flag3)
		{
			GameCanvas.clearKeyHold(5);
			bool flag4 = this.menuSelectedItem < this.menuItems.size() && this.menuSelectedItem >= 0;
			if (flag4)
			{
				((iCommand)this.menuItems.elementAt(this.menuSelectedItem)).perform();
				this.isShowMenu = false;
			}
		}
		bool flag5 = menuSelectedItem != this.menuSelectedItem && GameCanvas.isTouchNoOrPC();
		if (flag5)
		{
			this.list.setToX((this.menuSelectedItem + 1) * this.menuW - MotherCanvas.h / 2);
		}
		this.updatekeyPC();
	}

	// Token: 0x04001360 RID: 4960
	public static QuickMenu instance;

	// Token: 0x04001361 RID: 4961
	public static FrameImage[] fraQuickMenu;

	// Token: 0x04001362 RID: 4962
	public static mImage imgNenMenu;

	// Token: 0x04001363 RID: 4963
	public static mImage imgTamGiac;

	// Token: 0x04001364 RID: 4964
	private ListNew list;

	// Token: 0x04001365 RID: 4965
	private bool isClose;

	// Token: 0x04001366 RID: 4966
	private int speed = 10;

	// Token: 0x04001367 RID: 4967
	private int xEff;

	// Token: 0x04001368 RID: 4968
	public static int[][] mValueCmd = new int[][]
	{
		new int[2],
		new int[]
		{
			12,
			12
		},
		new int[]
		{
			7,
			7
		},
		new int[]
		{
			2,
			2
		},
		new int[]
		{
			14,
			14
		},
		new int[]
		{
			15,
			15
		},
		new int[]
		{
			13,
			13
		},
		new int[]
		{
			3,
			3
		},
		new int[]
		{
			5,
			5
		},
		new int[]
		{
			6,
			6
		},
		new int[]
		{
			9,
			8
		},
		new int[]
		{
			11,
			11
		},
		new int[]
		{
			8,
			9
		}
	};

	// Token: 0x04001369 RID: 4969
	private int[] color = new int[]
	{
		9389312,
		16777215,
		16777215,
		16771856
	};
}
