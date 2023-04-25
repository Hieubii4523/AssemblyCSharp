using System;

// Token: 0x020000AB RID: 171
public class MsgSound : MsgDialog
{
	// Token: 0x06000A64 RID: 2660 RVA: 0x000D3F88 File Offset: 0x000D2188
	public void setinfoSound()
	{
		this.fontDia = mFont.tahoma_7_black;
		base.beginDia();
		this.cmdList = new mVector();
		iCommand iCommand = new iCommand(T.xong, 12, this);
		this.cmdList.addElement(iCommand);
		this.okCMD = iCommand;
		this.wDia = 100;
		this.maxWShow = this.wDia;
		this.wShowPaper = 5;
		this.wItem = 28;
		this.hDia = 130;
		this.xDia = MotherCanvas.hw - this.wDia / 2;
		this.yDia = MotherCanvas.hh - this.hDia / 2 - 5;
		this.isMusicCur = mSound.isMusic;
		base.setPosCmdNew(-2, false);
	}

	// Token: 0x06000A65 RID: 2661 RVA: 0x000D4044 File Offset: 0x000D2244
	public override void commandPointer(int index, int subIndex)
	{
		bool flag = index == 12;
		if (flag)
		{
			CRes.saveRMS("MAIN_SOUND", new sbyte[]
			{
				mSound.isMusic ? 1 : 0,
				mSound.isSound ? 1 : 0
			});
			this.stopMusic();
			base.closeDialog();
		}
	}

	// Token: 0x06000A66 RID: 2662 RVA: 0x000D409C File Offset: 0x000D229C
	public void stopMusic()
	{
		bool flag = !mSound.isMusic;
		if (flag)
		{
			mSound.stopAll();
		}
		else
		{
			bool flag2 = !this.isMusicCur;
			if (flag2)
			{
				mSound.idCurent = -1;
				LoadMapScreen.PlayMusicLang();
			}
		}
	}

	// Token: 0x06000A67 RID: 2663 RVA: 0x000D40DC File Offset: 0x000D22DC
	public override void paint(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		int num = this.yDia;
		int num2 = this.xDia + 20;
		base.paintPaper(g, MotherCanvas.hw - this.wShowPaper / 2, num, this.wShowPaper, this.hDia, this.maxWShow, (int)AvMain.PAPER_NORMAL);
		g.setClip(MotherCanvas.hw - this.wShowPaper / 2, 0, this.wShowPaper, MotherCanvas.h);
		g.saveCanvas();
		g.ClipRec(MotherCanvas.hw - this.wShowPaper / 2, 0, this.wShowPaper, MotherCanvas.h);
		num += 12;
		g.setColor(15972174);
		g.fillRoundRect(this.xDia + 10, num, this.wDia - 20, 16, 4, 4);
		num += 3;
		AvMain.FontBorderColor(g, T.amthanh, this.xDia + this.wDia / 2, num, 2, 6, 5);
		num += this.wItem;
		bool flag = GameCanvas.isTouchNoOrPC();
		if (flag)
		{
			this.paintSelect(g, num2, num - this.wItem / 4 - 1, 58 + this.wItem);
		}
		g.drawImage(AvMain.imgBorderCombo, num2, num + 5, 3);
		mFont.tahoma_7b_black.drawString(g, T.nhacnen, num2 + 12, num, 0);
		bool isMusic = mSound.isMusic;
		if (isMusic)
		{
			AvMain.fraCheck.drawFrame(2, num2, num + 5, 0, 3, g);
		}
		num += this.wItem;
		g.drawImage(AvMain.imgBorderCombo, num2, num + 5, 3);
		bool isSound = mSound.isSound;
		if (isSound)
		{
			AvMain.fraCheck.drawFrame(2, num2, num + 5, 0, 3, g);
		}
		mFont.tahoma_7b_black.drawString(g, T.hieuung, num2 + 12, num, 0);
		bool flag2 = this.cmdList != null;
		if (flag2)
		{
			for (int i = 0; i < this.cmdList.size(); i++)
			{
				iCommand iCommand = (iCommand)this.cmdList.elementAt(i);
				iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
			}
		}
		g.restoreCanvas();
	}

	// Token: 0x06000A68 RID: 2664 RVA: 0x000C9DA8 File Offset: 0x000C7FA8
	public void paintSelect(mGraphics g, int xbegin, int ybegin, int wFocus)
	{
		g.setColor(16774758);
		xbegin -= this.wItem / 2;
		g.fillRect(xbegin + this.miniItem / 2, ybegin + this.idSelect * this.wItem, wFocus - this.miniItem / 2, this.wItem);
	}

	// Token: 0x06000A69 RID: 2665 RVA: 0x000C9724 File Offset: 0x000C7924
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

	// Token: 0x06000A6A RID: 2666 RVA: 0x000D42FC File Offset: 0x000D24FC
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
				bool flag4 = this.idSelect < 1;
				if (flag4)
				{
					this.idSelect++;
				}
				GameCanvas.ClearkeyMove(3);
			}
			else
			{
				bool flag5 = GameCanvas.keyMove(0) || GameCanvas.keyMove(2);
				if (flag5)
				{
					this.setSelect();
					GameCanvas.ClearkeyMove(0);
					GameCanvas.ClearkeyMove(2);
				}
				else
				{
					bool flag6 = GameCanvas.keyMyHold[5];
					if (flag6)
					{
						GameCanvas.clearKeyHold(5);
						bool flag7 = this.cmdList != null && this.idCommand < this.cmdList.size();
						if (flag7)
						{
							((iCommand)this.cmdList.elementAt(this.idCommand)).perform();
						}
					}
				}
			}
		}
		this.updatekeyPC();
	}

	// Token: 0x06000A6B RID: 2667 RVA: 0x000D4404 File Offset: 0x000D2604
	public void setSelect()
	{
		bool flag = this.idSelect == 0;
		if (flag)
		{
			mSound.isMusic = !mSound.isMusic;
		}
		else
		{
			bool flag2 = this.idSelect == 1;
			if (flag2)
			{
				mSound.isSound = !mSound.isSound;
			}
		}
	}

	// Token: 0x06000A6C RID: 2668 RVA: 0x000D444C File Offset: 0x000D264C
	public override void updatePointer()
	{
		int num = this.yDia;
		int xDia = this.xDia;
		num += 15 + this.wItem - this.wItem / 4;
		bool flag = GameCanvas.isPointSelect(xDia + 10, num, 80, this.wItem);
		if (flag)
		{
			mSound.isMusic = !mSound.isMusic;
		}
		else
		{
			bool flag2 = GameCanvas.isPointSelect(xDia + 10, num + this.wItem, 80, this.wItem);
			if (flag2)
			{
				mSound.isSound = !mSound.isSound;
			}
		}
		base.updatePointer();
	}

	// Token: 0x0400105F RID: 4191
	private bool isMusicCur;
}
