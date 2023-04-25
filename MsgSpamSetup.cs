using System;

// Token: 0x020000AC RID: 172
public class MsgSpamSetup : MsgDialog
{
	// Token: 0x06000A6E RID: 2670 RVA: 0x000D44D8 File Offset: 0x000D26D8
	public void setinfo()
	{
		MsgSpamSetup.valueSetup = new int[7];
		for (int i = 0; i < MsgSpamSetup.valueSetup.Length; i++)
		{
			bool flag = i != 0;
			if (flag)
			{
				MsgSpamSetup.valueSetup[i] = 1;
			}
		}
		this.wDia = 180;
		this.maxWShow = this.wDia;
		this.hItem = 24;
		this.wItem = 26;
		bool flag2 = this.wDia < 210;
		if (flag2)
		{
			this.wItem = 20;
		}
		this.hDia = 190;
		this.xDia = MotherCanvas.hw - this.wDia / 2;
		this.yDia = MotherCanvas.hh - this.hDia / 2 + 10;
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.miniItem = 28;
		}
		this.cmdList = new mVector();
		iCommand iCommand = new iCommand(T.xong, 15, this);
		bool flag3 = !GameCanvas.isTouch;
		if (flag3)
		{
			iCommand = (this.right = AvMain.setPosCMD(iCommand, 2));
		}
		else
		{
			iCommand.setPos(this.xDia + this.wDia + 3, this.yDia - 5, MainTab.fraCloseTab, string.Empty);
			this.backCMD = iCommand;
		}
		this.cmdList.addElement(iCommand);
	}

	// Token: 0x06000A6F RID: 2671 RVA: 0x000D4628 File Offset: 0x000D2828
	public override void paint(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		int num = this.yDia + this.hItem / 2;
		int num2 = this.xDia + 15;
		base.paintPaper(g, MotherCanvas.hw - this.wShowPaper / 2, this.yDia - 7, this.wShowPaper, this.hDia, this.maxWShow, (int)AvMain.PAPER_NORMAL);
		g.setClip(MotherCanvas.hw - this.wShowPaper / 2, 0, this.wShowPaper, MotherCanvas.h);
		g.saveCanvas();
		g.ClipRec(MotherCanvas.hw - this.wShowPaper / 2, 0, this.wShowPaper, MotherCanvas.h);
		bool flag = GameCanvas.isTouchNoOrPC();
		if (flag)
		{
			this.paintSelect(g, num2 + 3, num - this.hItem / 4 - 1, this.wDia - 36);
		}
		for (int i = 0; i < T.mSpam.Length; i++)
		{
			int num3 = num2 + 5;
			mFont.tahoma_7b_black.drawString(g, T.mSpam[i], num3 + 14, num, 0);
			g.drawRegion(AvMain.imgDaKham, 0, 0, 20, 20, 0, (float)num3, (float)(num + 6), 3);
			bool flag2 = MsgSpamSetup.valueSetup[i] == 1;
			if (flag2)
			{
				AvMain.fraCheck.drawFrame(2, num2 + 5, num + 5, 0, 3, g);
			}
			else
			{
				AvMain.fraCheck.drawFrame(1, num2 + 5, num + 5, 0, 3, g);
			}
			num += this.hItem;
		}
		base.paintInfoHelp(g);
		g.restoreCanvas();
		GameCanvas.resetTrans(g);
		bool flag3 = this.cmdList != null;
		if (flag3)
		{
			for (int j = 0; j < this.cmdList.size(); j++)
			{
				iCommand iCommand = (iCommand)this.cmdList.elementAt(j);
				iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
			}
		}
	}

	// Token: 0x06000A70 RID: 2672 RVA: 0x000D4818 File Offset: 0x000D2A18
	public void paintSelect(mGraphics g, int xbegin, int ybegin, int wFocus)
	{
		g.setColor(16774758);
		xbegin -= this.miniItem;
		g.fillRect(xbegin, ybegin + this.idSelect * this.hItem, wFocus + this.miniItem * 2, this.hItem);
	}

	// Token: 0x06000A71 RID: 2673 RVA: 0x000D4864 File Offset: 0x000D2A64
	public override void updatekey()
	{
		bool flag = GameCanvas.keyMove(1);
		if (flag)
		{
			bool flag2 = this.idSelect > 0;
			if (flag2)
			{
				this.idSelect--;
			}
			GameCanvas.ClearkeyMove(1);
		}
		else
		{
			bool flag3 = GameCanvas.keyMove(3);
			if (flag3)
			{
				bool flag4 = this.idSelect < MsgSpamSetup.valueSetup.Length;
				if (flag4)
				{
					this.idSelect++;
				}
				GameCanvas.ClearkeyMove(3);
			}
			else
			{
				bool flag5 = GameCanvas.keyMyHold[5];
				if (flag5)
				{
					GameCanvas.clearKeyHold(5);
					bool flag6 = MsgSpamSetup.valueSetup[this.idSelect] == 1;
					if (flag6)
					{
						MsgSpamSetup.valueSetup[this.idSelect] = 0;
					}
					else
					{
						MsgSpamSetup.valueSetup[this.idSelect] = 1;
					}
				}
			}
		}
	}

	// Token: 0x06000A72 RID: 2674 RVA: 0x000D492C File Offset: 0x000D2B2C
	public override void updatePointer()
	{
		int num = this.yDia + 5;
		int xDia = this.xDia;
		for (int i = 0; i < MsgSpamSetup.valueSetup.Length; i++)
		{
			int x = xDia + 5;
			bool flag = GameCanvas.isPointSelect(x, num, this.wDia - 25, this.hItem);
			if (flag)
			{
				bool flag2 = MsgSpamSetup.valueSetup[i] == 1;
				if (flag2)
				{
					MsgSpamSetup.valueSetup[i] = 0;
				}
				else
				{
					MsgSpamSetup.valueSetup[i] = 1;
				}
				GameCanvas.isPointerSelect = false;
				base.setInfoHelp(T.mHelpSpam[i]);
				this.idSelect = i;
				return;
			}
			num += this.hItem;
		}
		base.updatePointer();
	}

	// Token: 0x06000A73 RID: 2675 RVA: 0x000D49DC File Offset: 0x000D2BDC
	public static bool isCheckSpam(int index, string str)
	{
		bool flag = MsgSpamSetup.valueSetup == null;
		bool result;
		if (flag)
		{
			result = false;
		}
		else
		{
			bool flag2 = index < 0 || index >= MsgSpamSetup.valueSetup.Length;
			if (flag2)
			{
				result = false;
			}
			else
			{
				bool flag3 = MsgSpamSetup.valueSetup[0] == 1;
				if (flag3)
				{
					result = true;
				}
				else
				{
					bool flag4 = MsgSpamSetup.valueSetup[index] == 1;
					if (flag4)
					{
						result = false;
					}
					else
					{
						bool flag5 = index == 1;
						if (flag5)
						{
							bool isGetListFriend = FriendList.isGetListFriend;
							if (isGetListFriend)
							{
								for (int i = 0; i < Player.vecFriendList.size(); i++)
								{
									InfoMemList infoMemList = (InfoMemList)Player.vecFriendList.elementAt(i);
									bool flag6 = infoMemList.name.CompareTo(str) == 0;
									if (flag6)
									{
										return false;
									}
								}
							}
							else
							{
								bool flag7 = !MsgSpamSetup.isDontShowFriendList;
								if (flag7)
								{
									GlobalService.gI().Friend(2, 0);
									MsgSpamSetup.isDontShowFriendList = true;
								}
							}
							result = true;
						}
						else
						{
							bool flag8 = MsgSpamSetup.valueSetup[index] == 0;
							result = flag8;
						}
					}
				}
			}
		}
		return result;
	}

	// Token: 0x06000A74 RID: 2676 RVA: 0x000D4AFC File Offset: 0x000D2CFC
	public static void saveClose()
	{
		bool flag = MsgSpamSetup.valueSetup != null;
		if (flag)
		{
			CRes.saveRMS("SUB_SPAM", new sbyte[]
			{
				(sbyte)MsgSpamSetup.valueSetup[MsgSpamSetup.valueSetup.Length - 1]
			});
		}
	}

	// Token: 0x04001060 RID: 4192
	public const sbyte CHECK_CHAT = 1;

	// Token: 0x04001061 RID: 4193
	public const sbyte CHECK_ADD_FRIEND = 2;

	// Token: 0x04001062 RID: 4194
	public const sbyte CHECK_PARTY = 3;

	// Token: 0x04001063 RID: 4195
	public const sbyte CHECK_TRADE = 4;

	// Token: 0x04001064 RID: 4196
	public const sbyte CHECK_FIGHT = 5;

	// Token: 0x04001065 RID: 4197
	public static int[] valueSetup;

	// Token: 0x04001066 RID: 4198
	private int hItem;

	// Token: 0x04001067 RID: 4199
	public static bool isDontShowFriendList;
}
