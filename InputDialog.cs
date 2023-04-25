using System;

// Token: 0x02000053 RID: 83
public class InputDialog : MainDialog
{
	// Token: 0x06000599 RID: 1433 RVA: 0x00080F54 File Offset: 0x0007F154
	public InputDialog()
	{
		this.cmdClose = new iCommand(T.close, -1);
		InputDialog.cmdInputServer = new iCommand(T.xong, 0);
		InputDialog.istouchMore = 15;
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			InputDialog.hTouch = iCommand.hButtonCmdNor + 5;
		}
	}

	// Token: 0x0600059A RID: 1434 RVA: 0x00080FB4 File Offset: 0x0007F1B4
	public void closeDialog()
	{
		bool flag = GameCanvas.currentDialog != null;
		if (flag)
		{
			GameCanvas.currentDialog = null;
		}
		else
		{
			GameCanvas.subDialog = null;
		}
	}

	// Token: 0x0600059B RID: 1435 RVA: 0x00080FE0 File Offset: 0x0007F1E0
	public override void commandTab(int index, int subIndex)
	{
		if (index != -1)
		{
			if (index == 0)
			{
				bool flag = this.mtfInput != null;
				string[] array;
				if (flag)
				{
					array = new string[this.mtfInput.Length];
					for (int i = 0; i < this.mtfInput.Length; i++)
					{
						array[i] = this.mtfInput[i].getText();
					}
				}
				else
				{
					bool flag2 = this.tfInput == null;
					if (flag2)
					{
						return;
					}
					array = new string[]
					{
						this.tfInput.getText()
					};
				}
				GlobalService.gI().InputServer(this.IDInputserver, array);
				GameCanvas.end_Dialog();
				GameCanvas.Start_Waiting_DiaLog(T.pleaseWaiting, true);
			}
		}
		else
		{
			this.closeDialog();
		}
		base.commandTab(index, subIndex);
	}

	// Token: 0x0600059C RID: 1436 RVA: 0x000810B8 File Offset: 0x0007F2B8
	public void setinfo(string info, iCommand cmd, bool isNum, string nameInput)
	{
		this.listnew = null;
		this.isMore = false;
		this.isNew = false;
		this.left = null;
		this.right = null;
		this.center = null;
		bool flag = cmd == null;
		if (flag)
		{
			GameCanvas.currentDialog = null;
		}
		this.wDia = MotherCanvas.w - 30;
		bool flag2 = this.wDia > 200;
		if (flag2)
		{
			this.wDia = 200;
		}
		this.strinfo = this.fontInput.splitFontArray(info, this.wDia - 20);
		this.name = nameInput;
		this.hDia = 15 * this.strinfo.Length + 10 + TField.getHeight() + GameCanvas.hCommand;
		this.hDia += InputDialog.hTouch + InputDialog.istouchMore;
		this.xDia = MotherCanvas.hw - this.wDia / 2;
		this.yDia = MotherCanvas.h - GameCanvas.hCommand * 2 - this.hDia + 15;
		this.tfInput = new TField(this.xDia + 10, this.yDia + this.hDia - InputDialog.hTouch - (TField.getHeight() + 8), this.wDia - 20);
		this.tfInput.setMaxTextLenght(100);
		if (isNum)
		{
			this.tfInput.setIputType(TField.INPUT_TYPE_NUMERIC);
		}
		this.tfInput.setText(string.Empty);
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			cmd.setPos(this.xDia + this.wDia / 2, this.yDia + this.hDia - iCommand.hButtonCmdNor / 2 - 5, null, cmd.caption);
			this.cmdClose.setPos(this.xDia + this.wDia - 13, this.yDia + 13, MainTab.fraCloseTab, string.Empty);
			this.right = this.cmdClose;
			this.left = cmd;
			this.tfInput.title = info;
			bool flag3 = GameCanvas.isTouchNoOrPC();
			if (flag3)
			{
				this.tfInput.setFocus(true);
			}
			this.backCMD = this.right;
			this.okCMD = this.left;
		}
		else
		{
			this.center = cmd;
			this.left = this.cmdClose;
			this.tfInput.setFocus(true);
			this.right = this.tfInput.cmdClear;
		}
	}

	// Token: 0x0600059D RID: 1437 RVA: 0x00081320 File Offset: 0x0007F520
	public void setinfo(string[] info, string name, short Id, iCommand cmd, string strNote)
	{
		bool flag = cmd == null;
		if (flag)
		{
			cmd = InputDialog.cmdInputServer;
		}
		this.listnew = null;
		this.mStrNote = null;
		this.IDInputserver = Id;
		this.isMore = true;
		this.isNew = false;
		this.left = null;
		this.right = null;
		this.center = null;
		this.wDia = MotherCanvas.w - 30;
		bool flag2 = this.wDia > 160;
		if (flag2)
		{
			this.wDia = 160;
		}
		this.mtfInput = new TField[info.Length];
		this.strinfo = info;
		this.name = name;
		this.hDia = (TField.getHeight() + 18) * this.strinfo.Length + 6 + GameCanvas.hCommand;
		this.hDia += InputDialog.hTouch + InputDialog.istouchMore;
		bool flag3 = strNote != null && strNote.Length > 0;
		if (flag3)
		{
			this.mStrNote = mFont.tahoma_7b_red.splitFontArray(strNote, this.wDia - 10);
			this.hDia += GameCanvas.hText * this.mStrNote.Length;
		}
		int num = 0;
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			bool flag4 = this.hDia > MotherCanvas.h - GameCanvas.hCommand;
			if (flag4)
			{
				num = this.hDia;
				this.hDia = MotherCanvas.h - GameCanvas.hCommand;
			}
		}
		else
		{
			bool flag5 = this.hDia > MotherCanvas.h - GameCanvas.hCommand * 2;
			if (flag5)
			{
				num = this.hDia;
				this.hDia = MotherCanvas.h - GameCanvas.hCommand * 2;
			}
		}
		this.xDia = MotherCanvas.hw - this.wDia / 2;
		this.yDia = MotherCanvas.h - GameCanvas.hCommand * 2 - this.hDia + 15;
		bool flag6 = num > 0;
		if (flag6)
		{
			bool isTouch2 = GameCanvas.isTouch;
			if (isTouch2)
			{
				this.yDia = MotherCanvas.h - GameCanvas.hCommand - this.hDia + 15;
			}
			else
			{
				this.yDia = MotherCanvas.h - GameCanvas.hCommand * 2 - this.hDia + 15;
			}
			this.listnew = new ListNew(this.xDia, this.yDia, this.wDia, this.hDia, 0, 0, num - this.hDia, true);
		}
		for (int i = 0; i < this.mtfInput.Length; i++)
		{
			this.mtfInput[i] = new TField(this.xDia + 10, this.yDia + 8 + (TField.getHeight() + 18) * i + InputDialog.istouchMore + GameCanvas.hCommand, this.wDia - 20);
			this.mtfInput[i].setText(string.Empty);
		}
		bool isTouch3 = GameCanvas.isTouch;
		if (isTouch3)
		{
			this.cmdClose.setPos(this.xDia + this.wDia - 13, this.yDia + 13, MainTab.fraCloseTab, string.Empty);
			this.right = this.cmdClose;
			cmd.setPos(this.xDia + this.wDia / 2, this.yDia + this.hDia - iCommand.hButtonCmdNor / 2 - 3, null, cmd.caption);
			this.left = cmd;
			bool flag7 = GameCanvas.isTouchNoOrPC();
			if (flag7)
			{
				this.mtfInput[0].setFocus(true);
				this.backCMD = this.right;
				this.okCMD = this.left;
			}
		}
		else
		{
			this.center = cmd;
			this.left = this.cmdClose;
		}
		bool flag8 = !GameCanvas.isTouch;
		if (flag8)
		{
			this.mtfInput[0].setFocus(true);
			this.right = this.mtfInput[0].cmdClear;
		}
	}

	// Token: 0x0600059E RID: 1438 RVA: 0x000816F0 File Offset: 0x0007F8F0
	public void setNameDefaul(string[] str)
	{
		bool flag = this.mtfInput == null;
		if (!flag)
		{
			for (int i = 0; i < this.mtfInput.Length; i++)
			{
				bool flag2 = i < str.Length;
				if (flag2)
				{
					this.mtfInput[i].setText(str[i]);
				}
			}
		}
	}

	// Token: 0x0600059F RID: 1439 RVA: 0x00081744 File Offset: 0x0007F944
	public void settfNull(string[] strnull)
	{
		bool flag = this.mtfInput == null;
		if (!flag)
		{
			for (int i = 0; i < this.mtfInput.Length; i++)
			{
				bool flag2 = i < strnull.Length;
				if (flag2)
				{
					this.mtfInput[i].setStringNull(strnull[i]);
				}
			}
		}
	}

	// Token: 0x060005A0 RID: 1440 RVA: 0x00081798 File Offset: 0x0007F998
	public void setinfoSmallNew(string info, iCommand cmd, bool isNum, int defValue, int price, string name, string xuluong)
	{
		this.isMore = false;
		this.isNew = true;
		this.left = null;
		this.right = null;
		this.center = null;
		bool flag = cmd == null;
		if (flag)
		{
			GameCanvas.currentDialog = null;
		}
		this.price = price;
		this.info = info;
		this.name = name;
		this.xuluong = xuluong;
		this.wDia = MotherCanvas.w / 3 * 2;
		bool flag2 = this.wDia > 160;
		if (flag2)
		{
			this.wDia = 160;
		}
		string str = string.Concat(new string[]
		{
			"\n",
			T.price,
			" ",
			price.ToString(),
			" ",
			xuluong
		});
		this.strinfo = this.fontInput.splitFontArray(info + " " + str, this.wDia - 20);
		this.hDia = 15 * this.strinfo.Length + 10 + TField.getHeight() + GameCanvas.hCommand;
		this.hDia += InputDialog.hTouch + InputDialog.istouchMore;
		this.xDia = MotherCanvas.hw - this.wDia / 2;
		this.yDia = MotherCanvas.h - GameCanvas.hCommand * 2 - this.hDia + 15;
		int num = this.wDia - 100;
		bool flag3 = num < 40;
		if (flag3)
		{
			num = 40;
		}
		this.tfInput = new TField(this.xDia + this.wDia / 2 - num / 2, this.yDia + this.hDia - InputDialog.hTouch - (TField.getHeight() + 8), num);
		if (isNum)
		{
			this.tfInput.setIputType(TField.INPUT_TYPE_NUMERIC);
		}
		bool flag4 = defValue >= 0;
		if (flag4)
		{
			this.tfInput.setText(string.Empty + defValue.ToString());
		}
		this.strtam = this.tfInput.getText();
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			cmd.setPos(this.xDia + this.wDia / 2, this.yDia + this.hDia - iCommand.hButtonCmdNor / 2 - 5, null, cmd.caption);
			this.cmdClose.setPos(this.xDia + this.wDia - 17, this.yDia + 13, MainTab.fraCloseTab, string.Empty);
			this.right = this.cmdClose;
			this.left = cmd;
		}
		else
		{
			this.center = cmd;
			this.left = this.cmdClose;
			this.tfInput.setFocus(true);
			this.right = this.tfInput.cmdClear;
		}
	}

	// Token: 0x060005A1 RID: 1441 RVA: 0x00081A54 File Offset: 0x0007FC54
	public override void paint(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		AvMain.paintRect(g, this.xDia, this.yDia, this.wDia, this.hDia, 2, 4);
		g.setColor(15972174);
		g.fillRoundRect(this.xDia + 15, this.yDia + 5, this.wDia - 25, 16, 4, 4);
		mFont.tahoma_7b_black.drawString(g, this.name, this.xDia + this.wDia / 2, this.yDia + 7, 2);
		int num = this.yDia + InputDialog.istouchMore + GameCanvas.hCommand;
		bool flag = this.listnew != null;
		if (flag)
		{
			bool isTouch = GameCanvas.isTouch;
			if (isTouch)
			{
				g.setClip(this.xDia, num - GameCanvas.hCommand / 2, this.wDia, this.hDia - GameCanvas.hCommand * 2 - GameCanvas.hCommand / 2);
			}
			else
			{
				g.setClip(this.xDia, num - GameCanvas.hCommand / 2, this.wDia, this.hDia - GameCanvas.hCommand - GameCanvas.hCommand / 2);
			}
			g.saveCanvas();
			g.ClipRec(this.xDia, num - GameCanvas.hCommand / 2, this.wDia, this.hDia - GameCanvas.hCommand * 2 - GameCanvas.hCommand / 2);
			g.translate(0, -this.listnew.cmx);
		}
		bool flag2 = this.isMore;
		if (flag2)
		{
			for (int i = 0; i < this.mtfInput.Length; i++)
			{
				this.fontInput.drawString(g, this.strinfo[i], MotherCanvas.w / 2, num - 5 + i * (TField.getHeight() + 18), 2);
				this.mtfInput[i].paintNew(g);
			}
			bool flag3 = this.mStrNote != null;
			if (flag3)
			{
				int num2 = num - 5 + this.mtfInput.Length * (TField.getHeight() + 18);
				for (int j = 0; j < this.mStrNote.Length; j++)
				{
					mFont.tahoma_7b_white.drawString(g, this.mStrNote[j], this.xDia + 5, num2 + j * GameCanvas.hText, 0);
				}
			}
		}
		else
		{
			for (int k = 0; k < this.strinfo.Length; k++)
			{
				this.fontInput.drawString(g, this.strinfo[k], MotherCanvas.w / 2, num + k * 15 - 5, 2);
			}
			this.tfInput.paint(g);
		}
		bool flag4 = this.listnew != null;
		if (flag4)
		{
			mGraphics.resetTransAndroid(g);
			g.restoreCanvas();
			GameCanvas.resetTrans(g);
		}
		base.paintCmd(g);
	}

	// Token: 0x060005A2 RID: 1442 RVA: 0x00081D28 File Offset: 0x0007FF28
	public override void keypress(int keyCode)
	{
		bool flag = this.isMore;
		if (flag)
		{
			for (int i = 0; i < this.mtfInput.Length; i++)
			{
				bool flag2 = this.mtfInput[i].isFocused();
				if (flag2)
				{
					this.mtfInput[i].keyPressed(keyCode);
					break;
				}
			}
		}
		else
		{
			this.tfInput.keyPressed(keyCode);
		}
	}

	// Token: 0x060005A3 RID: 1443 RVA: 0x00081D90 File Offset: 0x0007FF90
	public override void update()
	{
		this.updatekey();
		this.updatePointer();
		bool flag = this.isMore;
		if (flag)
		{
			bool flag2 = this.listnew != null;
			if (flag2)
			{
				this.listnew.moveCamera();
			}
			for (int i = 0; i < this.mtfInput.Length; i++)
			{
				this.mtfInput[i].update();
			}
		}
		else
		{
			bool flag3 = this.tfInput != null;
			if (flag3)
			{
				this.tfInput.update();
				bool flag4 = !GameCanvas.isTouch && this.right != this.tfInput.cmdClear;
				if (flag4)
				{
					this.right = this.tfInput.cmdClear;
				}
				bool flag5 = this.isNew && this.tfInput.getText().CompareTo(this.strtam) != 0;
				if (flag5)
				{
					this.strtam = this.tfInput.getText();
					int num = 0;
					try
					{
						num = int.Parse(this.strtam);
					}
					catch (Exception)
					{
						num = 0;
					}
					string str = string.Concat(new string[]
					{
						"\n",
						T.price,
						" ",
						(this.price * num).ToString(),
						" ",
						this.xuluong
					});
					this.strinfo = this.fontInput.splitFontArray(this.info + " " + str, this.wDia - 20);
					this.hDia = 15 * this.strinfo.Length + 10 + TField.getHeight() + InputDialog.hTouch + InputDialog.istouchMore + GameCanvas.hCommand;
					int num2 = this.wDia - 100;
					bool flag6 = num2 < 40;
					if (flag6)
					{
						num2 = 40;
					}
					this.xDia = MotherCanvas.hw - this.wDia / 2;
					this.yDia = MotherCanvas.h - GameCanvas.hCommand * 2 - this.hDia + 15;
					this.numw = (this.wDia - 6) / 32;
					this.numh = (this.hDia - 6) / 32;
					this.tfInput.x = this.xDia + this.wDia / 2 - num2 / 2;
					this.tfInput.y = this.yDia + this.hDia - (TField.getHeight() + 8) - InputDialog.hTouch;
				}
			}
		}
		base.update();
	}

	// Token: 0x060005A4 RID: 1444 RVA: 0x00082024 File Offset: 0x00080224
	public override void updatekey()
	{
		bool flag = this.isMore;
		if (flag)
		{
			bool flag2 = GameCanvas.keyMyHold[8];
			if (flag2)
			{
				for (int i = 0; i < this.mtfInput.Length; i++)
				{
					bool flag3 = !this.mtfInput[i].isFocused();
					if (!flag3)
					{
						this.mtfInput[i].setFocus(false);
						bool flag4 = i < this.mtfInput.Length - 1;
						if (flag4)
						{
							this.mtfInput[i + 1].setFocus(true);
							bool flag5 = !GameCanvas.isTouch;
							if (flag5)
							{
								this.right = this.mtfInput[i + 1].cmdClear;
							}
							bool flag6 = this.listnew != null;
							if (flag6)
							{
								this.listnew.setToX((i + 1) * (TField.getHeight() + 18) - this.hDia / 4);
							}
						}
						else
						{
							this.mtfInput[0].setFocus(true);
							bool flag7 = !GameCanvas.isTouch;
							if (flag7)
							{
								this.right = this.mtfInput[0].cmdClear;
							}
							bool flag8 = this.listnew != null;
							if (flag8)
							{
								this.listnew.setToX(0);
							}
						}
						break;
					}
				}
				GameCanvas.clearKeyHold(8);
			}
			else
			{
				bool flag9 = GameCanvas.keyMyHold[2];
				if (flag9)
				{
					for (int j = 0; j < this.mtfInput.Length; j++)
					{
						bool flag10 = !this.mtfInput[j].isFocused();
						if (!flag10)
						{
							this.mtfInput[j].setFocus(false);
							bool flag11 = j > 0;
							if (flag11)
							{
								this.mtfInput[j - 1].setFocus(true);
								bool flag12 = this.listnew != null;
								if (flag12)
								{
									this.listnew.setToX((j - 1) * (TField.getHeight() + 18) - this.hDia / 4);
								}
							}
							else
							{
								this.mtfInput[this.mtfInput.Length - 1].setFocus(true);
								bool flag13 = this.listnew != null;
								if (flag13)
								{
									this.listnew.setToX(this.listnew.cmxLim);
								}
							}
							break;
						}
					}
					GameCanvas.clearKeyHold(2);
				}
			}
		}
		base.updatekey();
		this.updatekeyPC();
	}

	// Token: 0x060005A5 RID: 1445 RVA: 0x0008228C File Offset: 0x0008048C
	public override void updatePointer()
	{
		bool flag = this.isMore;
		if (flag)
		{
			bool flag2 = this.listnew != null;
			if (flag2)
			{
				this.listnew.update_Pos_UP_DOWN();
				int y = this.yDia + InputDialog.istouchMore + GameCanvas.hCommand / 2;
				bool flag3 = GameCanvas.isPoint(this.xDia, y, this.wDia, this.hDia - GameCanvas.hCommand * 2);
				if (flag3)
				{
					for (int i = 0; i < this.mtfInput.Length; i++)
					{
						this.mtfInput[i].updatePointer(this.listnew.cmx);
					}
				}
			}
			else
			{
				for (int j = 0; j < this.mtfInput.Length; j++)
				{
					this.mtfInput[j].updatePointer();
				}
			}
		}
		else
		{
			bool flag4 = this.tfInput != null;
			if (flag4)
			{
				this.tfInput.updatePointer();
			}
		}
		base.updatePointer();
	}

	// Token: 0x04000806 RID: 2054
	public TField tfInput;

	// Token: 0x04000807 RID: 2055
	private iCommand cmdClose;

	// Token: 0x04000808 RID: 2056
	public TField[] mtfInput;

	// Token: 0x04000809 RID: 2057
	private bool isMore;

	// Token: 0x0400080A RID: 2058
	private bool isNew;

	// Token: 0x0400080B RID: 2059
	private int price;

	// Token: 0x0400080C RID: 2060
	private string name;

	// Token: 0x0400080D RID: 2061
	private string info;

	// Token: 0x0400080E RID: 2062
	private string xuluong;

	// Token: 0x0400080F RID: 2063
	private string[] mStrNote;

	// Token: 0x04000810 RID: 2064
	private static int hTouch;

	// Token: 0x04000811 RID: 2065
	private static int istouchMore;

	// Token: 0x04000812 RID: 2066
	public short IDInputserver;

	// Token: 0x04000813 RID: 2067
	private mFont fontInput = mFont.tahoma_7_white;

	// Token: 0x04000814 RID: 2068
	public static iCommand cmdInputServer;

	// Token: 0x04000815 RID: 2069
	private ListNew listnew;

	// Token: 0x04000816 RID: 2070
	private string strtam;
}
