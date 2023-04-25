using System;

// Token: 0x020000E4 RID: 228
public class ScreenJoinItem : MainScreen
{
	// Token: 0x06000DAC RID: 3500 RVA: 0x001080E0 File Offset: 0x001062E0
	public void setInfoJoin(string info, MainItem[] mItem)
	{
		bool flag = mItem != null && mItem.Length != 0;
		if (flag)
		{
			this.mItem = mItem;
			this.cmdList = new mVector();
			this.cmdInputNum = new iCommand(T.soluong, 3, this);
			this.cmdList.addElement(this.cmdInputNum);
			this.cmdOk = new iCommand(T.join, 1, this);
			this.cmdList.addElement(this.cmdOk);
			this.cmdClose = new iCommand(T.close, 0, this);
			this.cmdList.addElement(this.cmdClose);
			this.cmdAgain = new iCommand(T.gheptiep, 4, this);
			this.wDia = MotherCanvas.w;
			bool flag2 = this.wDia > 210;
			if (flag2)
			{
				this.wDia = 210;
			}
			bool flag3 = this.wDia < 190;
			if (flag3)
			{
				this.wDia = 190;
			}
			this.hItem = 40;
			this.wItem = 28;
			bool flag4 = this.wDia < 210;
			if (flag4)
			{
				this.wItem = 20;
			}
			this.strinfo = mFont.tahoma_7_black.splitFontArray(info, this.wDia - 20);
			this.hDia = (this.strinfo.Length + 1) * GameCanvas.hText + (mItem.Length - 1) * this.hItem + iCommand.hButtonCmdNor + 40;
			bool flag5 = GameCanvas.isTouchNoOrPC();
			if (flag5)
			{
				this.hDia += iCommand.hButtonCmdNor;
			}
			this.xDia = MotherCanvas.hw - this.wDia / 2;
			this.yDia = MotherCanvas.hh - this.hDia / 2 - 5;
			int num = this.xDia + this.wDia / 2;
			int num2 = this.yDia + (this.strinfo.Length + 1) * GameCanvas.hText + 15;
			this.posItem = mSystem.new_M_Int(mItem.Length, 2);
			this.posItem[0][0] = num + this.wDia / 4 - this.wItem / 2;
			this.posItem[0][1] = num2 + (mItem.Length - 1) * this.hItem / 2;
			for (int i = 1; i < mItem.Length; i++)
			{
				this.posItem[i][0] = num - this.wDia / 4 - this.wItem / 2;
				this.posItem[i][1] = num2 + (i - 1) * this.hItem + this.hItem / 2;
			}
			this.idCommand = 0;
			bool flag6 = !GameCanvas.isTouchNoOrPC();
			if (flag6)
			{
				this.cmdInputNum.setPos(this.xDia + this.wDia / 2 - iCommand.wButtonCmd / 2 - 10, this.yDia + this.hDia - iCommand.hButtonCmdNor / 2 - 5, null, this.cmdInputNum.caption);
				this.cmdOk.setPos(this.xDia + this.wDia / 2 + iCommand.wButtonCmd / 2 + 10, this.yDia + this.hDia - iCommand.hButtonCmdNor / 2 - 5, null, this.cmdOk.caption);
				this.cmdClose.setPos(this.xDia + this.wDia - 10, this.yDia + 20, MainTab.fraCloseTab, string.Empty);
			}
			else
			{
				this.cmdInputNum.setPos(this.xDia + this.wDia / 2 - iCommand.wButtonCmd / 2 - 10, this.yDia + this.hDia - iCommand.hButtonCmdNor / 2 - 10 - iCommand.hButtonCmdNor, null, this.cmdInputNum.caption);
				this.cmdInputNum.isSelect = true;
				this.cmdOk.setPos(this.xDia + this.wDia / 2 + iCommand.wButtonCmd / 2 + 10, this.yDia + this.hDia - iCommand.hButtonCmdNor / 2 - 10 - iCommand.hButtonCmdNor, null, this.cmdOk.caption);
				this.cmdClose.setPos(this.xDia + this.wDia / 2, this.yDia + this.hDia + iCommand.hButtonCmdNor / 2 - 10 - iCommand.hButtonCmdNor, null, this.cmdClose.caption);
				this.cmdInputNum.isSelect = true;
				this.backCMD = this.cmdClose;
			}
			this.Step = 0;
			this.numJoin = 1;
		}
	}

	// Token: 0x06000DAD RID: 3501 RVA: 0x0010855C File Offset: 0x0010675C
	public void setItemJoin(MainItem item, sbyte ishardcode)
	{
		bool flag = this.mItem != null && this.mItem.Length != 0;
		if (flag)
		{
			this.mItem[0] = item;
			this.mItem[0].isRemove = true;
			for (int i = 1; i < this.mItem.Length; i++)
			{
				bool flag2 = ishardcode == 0;
				if (flag2)
				{
					this.mItem[i].numPotion = this.mItem[i].numPotion * this.mItem[0].numPotion;
				}
				else
				{
					this.mItem[i].numPotion = this.mItem[i].numPotion * this.numJoin;
				}
			}
		}
		this.Step = 1;
	}

	// Token: 0x06000DAE RID: 3502 RVA: 0x00108618 File Offset: 0x00106818
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
		{
			bool flag = this.lastScreen != null;
			if (flag)
			{
				this.lastScreen.Show(this.lastScreen.lastScreen);
			}
			else
			{
				GameCanvas.gameScr.Show();
			}
			break;
		}
		case 1:
		{
			bool flag2 = this.numJoin <= 0;
			if (flag2)
			{
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.chuanhapsoluong);
			}
			else
			{
				GameCanvas.end_Dialog();
				GameCanvas.Start_Waiting_DiaLog(T.pleaseWaiting, true);
				GlobalService.gI().Split_Item(1, 1, this.mItem[0].ID, this.mItem[0].typeObject, this.numJoin);
			}
			break;
		}
		case 2:
		{
			bool flag3 = this.mItem[0] == null;
			if (!flag3)
			{
				short num = 1;
				try
				{
					num = (short)int.Parse(this.input.tfInput.getText());
					bool flag4 = num <= 0;
					if (flag4)
					{
						num = 1;
					}
				}
				catch (Exception)
				{
					num = 1;
				}
				this.numJoin = num;
				GameCanvas.end_Dialog();
			}
			break;
		}
		case 3:
			this.input = GameCanvas.Start_Input_Dialog(T.nhapsoluongmuonghep, new iCommand(T.strconfirm, 2, 0, this), true, T.joinItem);
			GameCanvas.currentDialog = this.input;
			break;
		case 4:
			GameCanvas.end_Dialog();
			GlobalService.gI().Split_Item(1, 4, 0, 0, 0);
			break;
		default:
			base.commandPointer(index, subIndex);
			break;
		}
	}

	// Token: 0x06000DAF RID: 3503 RVA: 0x001087AC File Offset: 0x001069AC
	public override void paint(mGraphics g)
	{
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.paint(g);
		}
		GameCanvas.resetTrans(g);
		int num = this.yDia;
		int num2 = this.xDia + 15;
		base.paintPaper(g, MotherCanvas.hw - this.wDia / 2, num, this.wDia, this.hDia, this.wDia, (int)AvMain.PAPER_NORMAL);
		Interface_Game.paintNumMess(g, -Interface_Game.xNumMess + 8, -Interface_Game.yNumMess + 3);
		g.setClip(MotherCanvas.hw - this.wDia / 2, 0, this.wDia, MotherCanvas.h);
		g.saveCanvas();
		g.ClipRec(MotherCanvas.hw - this.wDia / 2, 0, this.wDia, MotherCanvas.h);
		num += 12;
		g.setColor(14203529);
		g.fillRoundRect(this.xDia + 10, num, this.wDia - 20, 16, 4, 4);
		num += 3;
		mFont.tahoma_7b_red.drawString(g, T.joinItem, this.xDia + this.wDia / 2, num, 2);
		num += GameCanvas.hText;
		for (int i = 0; i < this.strinfo.Length; i++)
		{
			mFont.tahoma_7_black.drawString(g, this.strinfo[i], MotherCanvas.w / 2, num + 10, 2);
			num += GameCanvas.hText;
		}
		bool flag2 = this.Step == 0;
		if (flag2)
		{
			bool flag3 = AvMain.imgJoin == null;
			if (flag3)
			{
				AvMain.imgJoin = mImage.createImage("/interface/muiten.png");
			}
			else
			{
				g.drawImage(AvMain.imgJoin, this.xDia + this.wDia / 2, this.posItem[0][1] + this.wItem / 2, 3);
			}
		}
		for (int j = 0; j < this.posItem.Length; j++)
		{
			AvMain.paintRect(g, this.posItem[j][0], this.posItem[j][1], this.wItem, this.wItem, 1, 3);
			bool flag4 = this.mItem[j] != null && !this.mItem[j].isRemove;
			if (flag4)
			{
				this.mItem[j].paintColor(g, this.posItem[j][0] + this.wItem / 2, this.posItem[j][1] + this.wItem / 2, this.wItem - 1);
				this.mItem[j].paintAllItem_Num1(g, this.posItem[j][0] + this.wItem / 2, this.posItem[j][1] + this.wItem / 2, this.wItem, 0, this.mItem[j].colorName, this.mItem[j].numPotion * this.numJoin);
			}
		}
		bool flag5 = this.cmdList != null;
		if (flag5)
		{
			for (int k = 0; k < this.cmdList.size(); k++)
			{
				iCommand iCommand = (iCommand)this.cmdList.elementAt(k);
				iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
			}
		}
		g.restoreCanvas();
		GameCanvas.resetTrans(g);
		for (int l = 0; l < this.vecEff.size(); l++)
		{
			MainEffect mainEffect = (MainEffect)this.vecEff.elementAt(l);
			bool flag6 = mainEffect.levelPaint > -1;
			if (flag6)
			{
				mainEffect.paint(g);
			}
		}
	}

	// Token: 0x06000DB0 RID: 3504 RVA: 0x00108B5C File Offset: 0x00106D5C
	public override void update()
	{
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.update();
		}
		bool flag2 = GameCanvas.currentDialog == null;
		if (flag2)
		{
			this.updatekey();
			this.updatePointer();
		}
		this.updateStep();
		for (int i = 0; i < this.vecEff.size(); i++)
		{
			MainEffect mainEffect = (MainEffect)this.vecEff.elementAt(i);
			mainEffect.update();
			bool isStop = mainEffect.isStop;
			if (isStop)
			{
				this.vecEff.removeElement(mainEffect);
				i--;
			}
		}
	}

	// Token: 0x06000DB1 RID: 3505 RVA: 0x00108C00 File Offset: 0x00106E00
	private void updateStep()
	{
		bool flag = this.Step != 1;
		if (!flag)
		{
			this.tickStep++;
			bool flag2 = this.tickStop == 0;
			if (flag2)
			{
				this.cmdList.removeAllElements();
				this.numJoin = 1;
				bool flag3 = this.tickStep % 10 == 0;
				if (flag3)
				{
					mSound.playSound(26, mSound.volumeSound);
					mSound.playSound(27, mSound.volumeSound);
					for (int i = 1; i < this.posItem.Length; i++)
					{
						this.vecEff.addElement(GameScreen.createEffEnd(78, 0, this.posItem[i][0] + this.wItem / 2, this.posItem[i][1] + this.wItem / 2, this.posItem[0][0] + this.wItem / 2, this.posItem[0][1] + this.wItem / 2));
						this.mItem[i].isRemove = true;
					}
					this.tickStop = this.tickStep + 11 + this.wDia / 2 / 8;
				}
			}
			else
			{
				bool flag4 = this.tickStep >= this.tickStop;
				if (flag4)
				{
					mSound.playSound(26, mSound.volumeSound);
					this.vecEff.addElement(GameScreen.createEffEnd(53, 0, this.posItem[0][0] + this.wItem / 2, this.posItem[0][1] + this.wItem / 2, this.posItem[0][0] + this.wItem / 2, this.posItem[0][1] + this.wItem / 2));
					this.Step = 2;
					this.tickStep = 0;
					this.tickStop = 0;
					this.numJoin = 1;
					bool flag5 = this.mItem != null && this.mItem.Length != 0;
					if (flag5)
					{
						this.mItem[0].isRemove = false;
					}
					this.cmdList.removeAllElements();
					this.cmdList.addElement(this.cmdAgain);
					this.cmdList.addElement(this.cmdClose);
					this.idCommand = 0;
					bool flag6 = !GameCanvas.isTouchNoOrPC();
					if (flag6)
					{
						this.cmdAgain.setPos(this.xDia + this.wDia / 2, this.yDia + this.hDia - iCommand.hButtonCmdNor / 2 - 5, null, this.cmdAgain.caption);
					}
					else
					{
						this.cmdAgain.setPos(this.xDia + this.wDia / 2 - iCommand.wButtonCmd / 2 - 10, this.yDia + this.hDia - 10 - iCommand.hButtonCmdNor, null, this.cmdAgain.caption);
						this.cmdAgain.isSelect = true;
						this.cmdClose.setPos(this.xDia + this.wDia / 2 + iCommand.wButtonCmd / 2 + 10, this.yDia + this.hDia - 10 - iCommand.hButtonCmdNor, null, this.cmdClose.caption);
					}
				}
			}
		}
	}

	// Token: 0x06000DB2 RID: 3506 RVA: 0x00108F28 File Offset: 0x00107128
	public override void updatekey()
	{
		bool flag = this.Step == 1;
		if (!flag)
		{
			bool flag2 = this.cmdList != null;
			if (flag2)
			{
				int num = this.cmdList.size();
				bool flag3 = GameCanvas.isTouchNoOrPC() && num > 0;
				if (flag3)
				{
					int num2 = this.idCommand;
					bool flag4 = GameCanvas.keyMove(0);
					if (flag4)
					{
						this.idCommand--;
						GameCanvas.ClearkeyMove(0);
					}
					else
					{
						bool flag5 = GameCanvas.keyMove(2);
						if (flag5)
						{
							this.idCommand++;
							GameCanvas.ClearkeyMove(2);
						}
					}
					this.idCommand = AvMain.resetSelect(this.idCommand, num - 1, false);
					iCommand iCommand = (iCommand)this.cmdList.elementAt(this.idCommand);
					bool flag6 = iCommand.caption.Length == 0;
					if (flag6)
					{
						this.idCommand = 0;
					}
					bool flag7 = num2 != this.idCommand && GameCanvas.isTouchNoOrPC();
					if (flag7)
					{
						for (int i = 0; i < num; i++)
						{
							iCommand iCommand2 = (iCommand)this.cmdList.elementAt(i);
							bool flag8 = i == this.idCommand;
							if (flag8)
							{
								iCommand2.isSelect = true;
							}
							else
							{
								iCommand2.isSelect = false;
							}
						}
					}
				}
			}
			bool flag9 = GameCanvas.keyMyHold[5];
			if (flag9)
			{
				GameCanvas.clearKeyHold(5);
				bool flag10 = this.cmdList != null && this.idCommand < this.cmdList.size();
				if (flag10)
				{
					((iCommand)this.cmdList.elementAt(this.idCommand)).perform();
				}
			}
			this.updatekeyPC();
		}
	}

	// Token: 0x06000DB3 RID: 3507 RVA: 0x001090E4 File Offset: 0x001072E4
	public override void updatePointer()
	{
		bool flag = this.Step != 1 && this.cmdList != null;
		if (flag)
		{
			for (int i = 0; i < this.cmdList.size(); i++)
			{
				iCommand iCommand = (iCommand)this.cmdList.elementAt(i);
				iCommand.updatePointer();
			}
		}
	}

	// Token: 0x06000DB4 RID: 3508 RVA: 0x00109144 File Offset: 0x00107344
	public override bool keyBack()
	{
		bool flag = !base.keyBack() && this.cmdClose != null;
		if (flag)
		{
			this.cmdClose.perform();
		}
		return false;
	}

	// Token: 0x040014FA RID: 5370
	private MainItem[] mItem;

	// Token: 0x040014FB RID: 5371
	private int hItem;

	// Token: 0x040014FC RID: 5372
	private int[][] posItem;

	// Token: 0x040014FD RID: 5373
	private InputDialog input;

	// Token: 0x040014FE RID: 5374
	private mVector cmdList;

	// Token: 0x040014FF RID: 5375
	private mVector vecEff = new mVector("ScreenJoinItem.vecEff");

	// Token: 0x04001500 RID: 5376
	private iCommand cmdClose;

	// Token: 0x04001501 RID: 5377
	private iCommand cmdOk;

	// Token: 0x04001502 RID: 5378
	private iCommand cmdInputNum;

	// Token: 0x04001503 RID: 5379
	private iCommand cmdAgain;

	// Token: 0x04001504 RID: 5380
	private int wDia;

	// Token: 0x04001505 RID: 5381
	private int wItem;

	// Token: 0x04001506 RID: 5382
	private int hDia;

	// Token: 0x04001507 RID: 5383
	private int xDia;

	// Token: 0x04001508 RID: 5384
	private int yDia;

	// Token: 0x04001509 RID: 5385
	private int idCommand;

	// Token: 0x0400150A RID: 5386
	private string[] strinfo;

	// Token: 0x0400150B RID: 5387
	public short numJoin = 1;

	// Token: 0x0400150C RID: 5388
	public static ScreenJoinItem instance;

	// Token: 0x0400150D RID: 5389
	private int Step;

	// Token: 0x0400150E RID: 5390
	private int tickStep;

	// Token: 0x0400150F RID: 5391
	private int tickStop;
}
