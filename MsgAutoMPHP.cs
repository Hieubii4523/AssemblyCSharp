using System;

// Token: 0x020000A1 RID: 161
public class MsgAutoMPHP : MsgDialog
{
	// Token: 0x060009FB RID: 2555 RVA: 0x000C9A08 File Offset: 0x000C7C08
	public override void commandPointer(int index, int subIndex)
	{
		bool flag = index == 4;
		if (flag)
		{
			Player.isMPHP = true;
			this.isClose = true;
			GameScreen.player.hpPoi = null;
			GameScreen.player.mpPoi = null;
			GameCanvas.saveRms.SaveAutoMp_Hp();
		}
	}

	// Token: 0x060009FC RID: 2556 RVA: 0x000C9A50 File Offset: 0x000C7C50
	public void setinfoAuto_MP_HP()
	{
		this.fontDia = mFont.tahoma_7_black;
		base.beginDia();
		this.cmdList = new mVector();
		iCommand iCommand = new iCommand(T.xong, 4, this);
		this.cmdList.addElement(iCommand);
		this.okCMD = iCommand;
		this.wDia = 160;
		this.maxWShow = this.wDia;
		this.wShowPaper = 5;
		this.wItem = 28;
		this.hDia = 160;
		this.xDia = MotherCanvas.hw - this.wDia / 2;
		this.yDia = MotherCanvas.hh - this.hDia / 2 - 5;
		base.setPosCmdNew(-2, false);
	}

	// Token: 0x060009FD RID: 2557 RVA: 0x000C9B04 File Offset: 0x000C7D04
	public override void paint(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		int num = this.yDia;
		int num2 = this.xDia + 30;
		base.paintPaper(g, MotherCanvas.hw - this.wShowPaper / 2, num, this.wShowPaper, this.hDia, this.maxWShow, (int)AvMain.PAPER_NORMAL);
		g.setClip(MotherCanvas.hw - this.wShowPaper / 2, 0, this.wShowPaper, MotherCanvas.h);
		g.saveCanvas();
		g.ClipRec(MotherCanvas.hw - this.wShowPaper / 2, 0, this.wShowPaper, MotherCanvas.h);
		num += 12;
		g.setColor(15972174);
		g.fillRoundRect(this.xDia + 10, num, this.wDia - 20, 16, 4, 4);
		num += 3;
		AvMain.FontBorderColor(g, T.setting, this.xDia + this.wDia / 2, num, 2, 6, 5);
		num += this.wItem;
		bool flag = GameCanvas.isTouchNoOrPC();
		if (flag)
		{
			this.paintSelect(g, num2, num - this.wItem / 4 - 1, 100 + this.wItem);
		}
		g.drawRegion(Interface_Game.imgIconMPHP, 0, 0, 10, 10, 0, (float)(num2 + 4), (float)(num + 6), 3);
		Interface_Game.PaintHPMP(g, 1, MsgAutoMPHP.hp * 10, 100, num2 + 10, num, 0, 12, 90, 1, false, 0, false, 0);
		num += this.wItem;
		g.drawRegion(Interface_Game.imgIconMPHP, 0, 10, 10, 10, 0, (float)(num2 + 4), (float)(num + 6), 3);
		Interface_Game.PaintHPMP(g, 2, MsgAutoMPHP.mp * 10, 100, num2 + 10, num, 0, 12, 90, 1, false, 0, false, 0);
		num += this.wItem;
		mFont.tahoma_7b_black.drawString(g, T.uutien, num2, num, 0);
		g.drawImage(AvMain.imgHotKey, num2 + 55 + 30 * MsgAutoMPHP.typeUu, num + 6, 3);
		bool flag2 = MsgDialog.fraAutoMpHp == null;
		if (flag2)
		{
			MsgDialog.fraAutoMpHp = new FrameImage(mImage.createImage("/interface/automphp.png"), 20, 20);
		}
		else
		{
			MsgDialog.fraAutoMpHp.drawFrame(0, num2 + 55, num + 6, 0, 3, g);
			MsgDialog.fraAutoMpHp.drawFrame(1, num2 + 85, num + 6, 0, 3, g);
		}
		base.paintInfoHelp(g);
		bool flag3 = this.cmdList != null;
		if (flag3)
		{
			for (int i = 0; i < this.cmdList.size(); i++)
			{
				iCommand iCommand = (iCommand)this.cmdList.elementAt(i);
				iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
			}
		}
		g.restoreCanvas();
	}

	// Token: 0x060009FE RID: 2558 RVA: 0x000C9DA8 File Offset: 0x000C7FA8
	public void paintSelect(mGraphics g, int xbegin, int ybegin, int wFocus)
	{
		g.setColor(16774758);
		xbegin -= this.wItem / 2;
		g.fillRect(xbegin + this.miniItem / 2, ybegin + this.idSelect * this.wItem, wFocus - this.miniItem / 2, this.wItem);
	}

	// Token: 0x060009FF RID: 2559 RVA: 0x000C9724 File Offset: 0x000C7924
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

	// Token: 0x06000A00 RID: 2560 RVA: 0x000C9E00 File Offset: 0x000C8000
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
		this.updatekeyPC();
	}

	// Token: 0x06000A01 RID: 2561 RVA: 0x000C9F18 File Offset: 0x000C8118
	public void setSelect(int value)
	{
		bool flag = this.idSelect == 0;
		if (flag)
		{
			MsgAutoMPHP.hp += value * 10;
			bool flag2 = MsgAutoMPHP.hp > 90;
			if (flag2)
			{
				MsgAutoMPHP.hp = 90;
			}
			bool flag3 = MsgAutoMPHP.hp < 0;
			if (flag3)
			{
				MsgAutoMPHP.hp = 0;
			}
			base.setInfoHelp(T.mHelpAutoMPHP[0] + MsgAutoMPHP.hp.ToString() + "%");
		}
		else
		{
			bool flag4 = this.idSelect == 1;
			if (flag4)
			{
				MsgAutoMPHP.mp += value * 10;
				bool flag5 = MsgAutoMPHP.mp > 90;
				if (flag5)
				{
					MsgAutoMPHP.mp = 90;
				}
				bool flag6 = MsgAutoMPHP.mp < 0;
				if (flag6)
				{
					MsgAutoMPHP.mp = 0;
				}
				base.setInfoHelp(T.mHelpAutoMPHP[1] + MsgAutoMPHP.mp.ToString() + "%");
			}
			else
			{
				bool flag7 = this.idSelect == 2;
				if (flag7)
				{
					MsgAutoMPHP.typeUu++;
					bool flag8 = MsgAutoMPHP.typeUu > 1;
					if (flag8)
					{
						MsgAutoMPHP.typeUu = 0;
					}
					base.setInfoHelp(T.mHelpAutoMPHP[2 + MsgAutoMPHP.typeUu]);
				}
			}
		}
	}

	// Token: 0x06000A02 RID: 2562 RVA: 0x000CA04C File Offset: 0x000C824C
	public override void updatePointer()
	{
		int num = this.yDia;
		int num2 = this.xDia + 30;
		num += 15 + this.wItem - this.wItem / 4;
		bool flag = GameCanvas.isPointLast(num2 + 10, num, 90, this.wItem);
		if (flag)
		{
			bool flag2 = GameCanvas.isPointerDown || GameCanvas.isPointerMove;
			if (flag2)
			{
				int select = (GameCanvas.px - (num2 + 10) + 5) / 9 * 10;
				MsgAutoMPHP.hp = AvMain.resetSelect(select, 90, false);
				base.setInfoHelp(T.mHelpAutoMPHP[0] + MsgAutoMPHP.hp.ToString() + "%");
			}
		}
		else
		{
			bool flag3 = GameCanvas.isPointLast(num2 + 10, num + this.wItem, 90, this.wItem);
			if (flag3)
			{
				bool flag4 = GameCanvas.isPointerDown || GameCanvas.isPointerMove;
				if (flag4)
				{
					int select2 = (GameCanvas.px - (num2 + 10) + 5) / 9 * 10;
					MsgAutoMPHP.mp = AvMain.resetSelect(select2, 90, false);
					base.setInfoHelp(T.mHelpAutoMPHP[1] + MsgAutoMPHP.mp.ToString() + "%");
				}
			}
			else
			{
				bool flag5 = GameCanvas.isPoint(num2 + 55 - 15, num + this.wItem * 2, 60, this.wItem) && GameCanvas.isPointerSelect;
				if (flag5)
				{
					bool flag6 = GameCanvas.px < num2 + 55 + 15;
					if (flag6)
					{
						MsgAutoMPHP.typeUu = 0;
					}
					else
					{
						MsgAutoMPHP.typeUu = 1;
					}
					GameCanvas.isPointerSelect = false;
					base.setInfoHelp(T.mHelpAutoMPHP[2 + MsgAutoMPHP.typeUu]);
				}
			}
		}
		base.updatePointer();
	}

	// Token: 0x04000FAF RID: 4015
	public static int mp = 30;

	// Token: 0x04000FB0 RID: 4016
	public static int hp = 30;

	// Token: 0x04000FB1 RID: 4017
	public static int typeUu;
}
