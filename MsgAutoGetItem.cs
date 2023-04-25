using System;

// Token: 0x020000A0 RID: 160
public class MsgAutoGetItem : MsgDialog
{
	// Token: 0x060009F1 RID: 2545 RVA: 0x000C92C0 File Offset: 0x000C74C0
	public override void commandPointer(int index, int subIndex)
	{
		bool flag = index == 6;
		if (flag)
		{
			Player.isGetItem = true;
			this.isClose = true;
			GameCanvas.saveRms.SaveAutoGetItem();
		}
	}

	// Token: 0x060009F2 RID: 2546 RVA: 0x000C92F0 File Offset: 0x000C74F0
	public void setinfoAuto_Get_Item()
	{
		this.mAuto = new int[][]
		{
			new int[]
			{
				5,
				7,
				8,
				6
			},
			new int[]
			{
				5,
				1,
				2,
				6
			},
			new int[]
			{
				5,
				6
			}
		};
		this.fontDia = mFont.tahoma_7_black;
		base.beginDia();
		this.cmdList = new mVector();
		iCommand iCommand = new iCommand(T.xong, 6, this);
		this.cmdList.addElement(iCommand);
		this.okCMD = iCommand;
		this.wDia = MotherCanvas.w;
		bool flag = this.wDia > 210;
		if (flag)
		{
			this.wDia = 210;
		}
		bool flag2 = this.wDia < 190;
		if (flag2)
		{
			this.wDia = 190;
		}
		this.maxWShow = this.wDia;
		this.wShowPaper = 5;
		this.hItem = 28;
		this.wItem = 26;
		bool flag3 = this.wDia < 210;
		if (flag3)
		{
			this.wItem = 20;
		}
		this.hDia = 160;
		this.xDia = MotherCanvas.hw - this.wDia / 2;
		this.yDia = MotherCanvas.hh - this.hDia / 2 - 5;
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.miniItem = 28;
		}
		base.setPosCmdNew(-2, false);
	}

	// Token: 0x060009F3 RID: 2547 RVA: 0x000C945C File Offset: 0x000C765C
	public override void paint(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		int num = this.yDia;
		int num2 = this.xDia + 15;
		base.paintPaper(g, MotherCanvas.hw - this.wShowPaper / 2, num, this.wShowPaper, this.hDia, this.maxWShow, (int)AvMain.PAPER_NORMAL);
		g.setClip(MotherCanvas.hw - this.wShowPaper / 2, 0, this.wShowPaper, MotherCanvas.h);
		g.saveCanvas();
		g.ClipRec(MotherCanvas.hw - this.wShowPaper / 2, 0, this.wShowPaper, MotherCanvas.h);
		num += 12;
		g.setColor(15972174);
		g.fillRoundRect(this.xDia + 10, num, this.wDia - 20, 16, 4, 4);
		num += 3;
		AvMain.FontBorderColor(g, T.setting, this.xDia + this.wDia / 2, num, 2, 6, 5);
		num += this.hItem;
		bool flag = GameCanvas.isTouchNoOrPC();
		if (flag)
		{
			this.paintSelect(g, num2 + 3, num - this.hItem / 4 - 1, this.wDia - 36);
		}
		for (int i = 0; i < this.mAuto.Length; i++)
		{
			int num3 = num2 + 70;
			mFont.tahoma_7b_black.drawString(g, T.mAutoGetItem[i], num3 - 14, num, 1);
			for (int j = 0; j < this.mAuto[i].Length; j++)
			{
				bool flag2 = j == MsgAutoGetItem.mValue[i];
				if (flag2)
				{
					g.drawImage(AvMain.imgHotKey, num3, num + 6, 3);
				}
				bool flag3 = MsgDialog.fraAutoMpHp == null;
				if (flag3)
				{
					MsgDialog.fraAutoMpHp = new FrameImage(mImage.createImage("/interface/automphp.png"), 20, 20);
				}
				else
				{
					MsgDialog.fraAutoMpHp.drawFrame(this.mAuto[i][j], num3, num + 6, 0, 3, g);
				}
				num3 += this.wItem;
			}
			num += this.hItem;
		}
		base.paintInfoHelp(g);
		bool flag4 = this.cmdList != null;
		if (flag4)
		{
			for (int k = 0; k < this.cmdList.size(); k++)
			{
				iCommand iCommand = (iCommand)this.cmdList.elementAt(k);
				iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
			}
		}
		g.restoreCanvas();
	}

	// Token: 0x060009F4 RID: 2548 RVA: 0x000C96D8 File Offset: 0x000C78D8
	public void paintSelect(mGraphics g, int xbegin, int ybegin, int wFocus)
	{
		g.setColor(16774758);
		xbegin -= this.miniItem;
		g.fillRect(xbegin, ybegin + this.idSelect * this.hItem, wFocus + this.miniItem * 2, this.hItem);
	}

	// Token: 0x060009F5 RID: 2549 RVA: 0x000C9724 File Offset: 0x000C7924
	public override void update()
	{
		base.updateInfoHelp();
		bool isClose = this.isClose;
		if (isClose)
		{
			base.updateClose();
		}
		else
		{
			base.updateOpen();
			bool flag = GameCanvas.isTouchNoOrPC();
			if (flag)
			{
				this.updatekey();
			}
			this.updatePointer();
		}
	}

	// Token: 0x060009F6 RID: 2550 RVA: 0x000C9770 File Offset: 0x000C7970
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
				bool flag4 = this.idSelect < 2;
				if (flag4)
				{
					this.idSelect++;
				}
				GameCanvas.ClearkeyMove(3);
			}
			else
			{
				bool flag5 = GameCanvas.keyMove(0);
				if (flag5)
				{
					this.setSelect(-1);
					GameCanvas.ClearkeyMove(0);
				}
				else
				{
					bool flag6 = GameCanvas.keyMove(2);
					if (flag6)
					{
						this.setSelect(1);
						GameCanvas.ClearkeyMove(2);
					}
					else
					{
						bool flag7 = GameCanvas.keyMyHold[5];
						if (flag7)
						{
							GameCanvas.clearKeyHold(5);
							bool flag8 = this.cmdList != null && this.idCommand < this.cmdList.size();
							if (flag8)
							{
								((iCommand)this.cmdList.elementAt(this.idCommand)).perform();
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x060009F7 RID: 2551 RVA: 0x000C9880 File Offset: 0x000C7A80
	public void setSelect(int value)
	{
		MsgAutoGetItem.mValue[this.idSelect] += value;
		bool flag = MsgAutoGetItem.mValue[this.idSelect] > this.mAuto[this.idSelect].Length - 1;
		if (flag)
		{
			MsgAutoGetItem.mValue[this.idSelect] = this.mAuto[this.idSelect].Length - 1;
		}
		bool flag2 = MsgAutoGetItem.mValue[this.idSelect] < 0;
		if (flag2)
		{
			MsgAutoGetItem.mValue[this.idSelect] = 0;
		}
		base.setInfoHelp(T.mHelpGetItem[this.idSelect][MsgAutoGetItem.mValue[this.idSelect]]);
	}

	// Token: 0x060009F8 RID: 2552 RVA: 0x000C9928 File Offset: 0x000C7B28
	public override void updatePointer()
	{
		int num = this.yDia;
		int num2 = this.xDia + 15;
		num += 15;
		num += this.hItem;
		for (int i = 0; i < this.mAuto.Length; i++)
		{
			int num3 = num2 + 70;
			for (int j = 0; j < this.mAuto[i].Length; j++)
			{
				bool flag = GameCanvas.isPointSelect(num3 - this.wItem / 2, num + 6 - this.hItem / 2, this.wItem, this.hItem);
				if (flag)
				{
					MsgAutoGetItem.mValue[i] = j;
					GameCanvas.isPointerSelect = false;
					base.setInfoHelp(T.mHelpGetItem[i][j]);
					return;
				}
				num3 += this.wItem;
			}
			num += this.hItem;
		}
		base.updatePointer();
	}

	// Token: 0x04000FAC RID: 4012
	private int[][] mAuto;

	// Token: 0x04000FAD RID: 4013
	public static int[] mValue = new int[3];

	// Token: 0x04000FAE RID: 4014
	private int hItem;
}
