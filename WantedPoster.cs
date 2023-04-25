using System;

// Token: 0x02000114 RID: 276
public class WantedPoster : SubScreen
{
	// Token: 0x06000FE0 RID: 4064 RVA: 0x00131108 File Offset: 0x0012F308
	public WantedPoster(sbyte type, InfoMemList mem) : base(type)
	{
		this.mem = mem;
		this.wSub = AvMain.wWanted;
		this.hSub = AvMain.hWanted;
		this.xSub = MotherCanvas.hw - this.wSub / 2;
		this.ySub = MotherCanvas.hh - this.hSub / 2;
		this.idCommand = 0;
		this.cmdClose = new iCommand(T.close, -1, this);
		this.cmdNhan = new iCommand(T.nhanQuest, 0, this);
		this.cmdHuy = new iCommand(T.cancel, 1, this);
		this.cmdNhanThuong = new iCommand(T.nhanThuong, 2, this);
		this.cmdXoa = new iCommand(T.del, 3, this);
		this.vecMenu.removeAllElements();
		bool flag = type == 1;
		if (flag)
		{
			this.vecMenu.addElement(this.cmdNhan);
		}
		else
		{
			bool flag2 = (type == 5 || type == 4) && mem.isWantedSuccess == 0;
			if (flag2)
			{
				this.vecMenu.addElement(this.cmdHuy);
			}
			else
			{
				bool flag3 = type == 4 && mem.isWantedSuccess == 1;
				if (flag3)
				{
					this.vecMenu.addElement(this.cmdNhanThuong);
				}
				else
				{
					bool flag4 = type == 5 && mem.isReceiveGift == 1;
					if (flag4)
					{
						this.vecMenu.addElement(this.cmdXoa);
					}
				}
			}
		}
		this.vecMenu.addElement(this.cmdClose);
		base.setPosVecMenu(this.vecMenu);
		this.setCharHpaint();
	}

	// Token: 0x06000FE1 RID: 4065 RVA: 0x001312A4 File Offset: 0x0012F4A4
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case -1:
			WantedList.instance.Show(GameCanvas.gameScr);
			break;
		case 0:
			GlobalService.gI().Send_Wanted_Poster(2, (short)this.mem.id);
			GameCanvas.gameScr.Show();
			break;
		case 1:
			GlobalService.gI().Send_Wanted_Poster_Action(this.type, (short)this.mem.id, 1);
			GameCanvas.gameScr.Show();
			break;
		case 2:
			GlobalService.gI().Send_Wanted_Poster_Action(this.type, (short)this.mem.id, 2);
			GameCanvas.gameScr.Show();
			break;
		case 3:
			GlobalService.gI().Send_Wanted_Poster_Action(5, (short)this.mem.id, 3);
			break;
		}
	}

	// Token: 0x06000FE2 RID: 4066 RVA: 0x00131384 File Offset: 0x0012F584
	public override void paint(mGraphics g)
	{
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.paint(g);
		}
		GameCanvas.resetTrans(g);
		this.paintBg(g, this.xSub, this.ySub);
		bool flag2 = this.vecMenu != null;
		if (flag2)
		{
			for (int i = 0; i < this.vecMenu.size(); i++)
			{
				iCommand iCommand = (iCommand)this.vecMenu.elementAt(i);
				iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
			}
		}
		this.paintInfo(g, this.xSub, this.ySub, this.wSub, this.hSub);
	}

	// Token: 0x06000FE3 RID: 4067 RVA: 0x0013143C File Offset: 0x0012F63C
	private void paintInfo(mGraphics g, int xpaint, int ypaint, int wpaint, int hpaint)
	{
		bool flag = this.mem != null && this.mem.charShow != null;
		if (flag)
		{
			g.translate(xpaint, ypaint);
			this.mem.charShow.paintCharShow(g, wpaint / 2, this.hCharShow, 1, false);
			AvMain.FontBorderColor(g, this.mem.charShow.name, wpaint / 2, 103, 2, 0, 8);
			NumberDam.paintSmallWantedPoster(g, this.mem.charShow.wanted, wpaint / 2 + 4, 128);
			g.translate(-xpaint, -ypaint);
		}
	}

	// Token: 0x06000FE4 RID: 4068 RVA: 0x001314E0 File Offset: 0x0012F6E0
	private void paintBg(mGraphics g, int xpaint, int ypaint)
	{
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			g.drawImage(AvMain.imgDemoWanted, xpaint, ypaint, 0);
		}
		else
		{
			base.paintWantedPaper(g, xpaint, ypaint, this.wSub, this.hSub);
			g.translate(xpaint, ypaint);
			g.drawImage(AvMain.imgTrangTri, this.wSub / 2, this.hSub * 4 / 31, mGraphics.HCENTER | mGraphics.VCENTER);
			g.setColor(13019772);
			g.fillRect(15, this.hSub * 7 / 31, this.wSub - 30, 52);
			g.fillRect(15, 100, this.wSub - 32, 16);
			g.setColor(10781286);
			g.fillRect(16, this.hSub * 7 / 31 + 1, this.wSub - 30, 50);
			g.fillRect(16, 101, this.wSub - 32, 14);
			g.drawImage(AvMain.mimgWanted[13], this.wSub / 2, 94, 3);
			g.drawImage(AvMain.mimgWanted[14], 23, 130, 3);
			g.drawImage(AvMain.mimgWanted[16], 7, 93, 0);
			g.drawRegion(AvMain.mimgWanted[16], 0, 0, 6, 46, 2, (float)(this.wSub - 13), 93f, 0);
			g.drawImage(AvMain.mimgWanted[15], 102, 145, 3);
			g.drawImage(AvMain.mimgWanted[17], 48, 144, 3);
			g.translate(-xpaint, -ypaint);
		}
	}

	// Token: 0x06000FE5 RID: 4069 RVA: 0x0013167C File Offset: 0x0012F87C
	public override void update()
	{
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.update();
		}
		base.update();
	}

	// Token: 0x06000FE6 RID: 4070 RVA: 0x001316AC File Offset: 0x0012F8AC
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
		bool flag7 = GameCanvas.keyMyHold[5];
		if (flag7)
		{
			GameCanvas.clearKeyHold(5);
			bool flag8 = this.vecMenu != null && this.idCommand < this.vecMenu.size();
			if (flag8)
			{
				((iCommand)this.vecMenu.elementAt(this.idCommand)).perform();
			}
		}
		this.updatekeyPC();
	}

	// Token: 0x06000FE7 RID: 4071 RVA: 0x00131820 File Offset: 0x0012FA20
	public override void updatePointer()
	{
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
	}

	// Token: 0x06000FE8 RID: 4072 RVA: 0x0013187C File Offset: 0x0012FA7C
	private void setCharHpaint()
	{
		bool flag = this.mem.charShow.hOne == 0;
		if (flag)
		{
			this.mem.charShow.setHeadBigBody();
			this.hCharShow = this.hSub * 7 / 31 + (this.hSub * 3 / 5 - this.hSub * 7 / 31) / 2 + this.mem.charShow.hOne / 2 - 7;
			bool flag2 = this.mem.charShow.hOne > 52;
			if (flag2)
			{
				this.hCharShow -= 3;
			}
		}
	}

	// Token: 0x04001A65 RID: 6757
	private InfoMemList mem;

	// Token: 0x04001A66 RID: 6758
	public static WantedPoster instance;

	// Token: 0x04001A67 RID: 6759
	private iCommand cmdClose;

	// Token: 0x04001A68 RID: 6760
	private iCommand cmdNhan;

	// Token: 0x04001A69 RID: 6761
	private iCommand cmdHuy;

	// Token: 0x04001A6A RID: 6762
	private iCommand cmdNhanThuong;

	// Token: 0x04001A6B RID: 6763
	private iCommand cmdXoa;

	// Token: 0x04001A6C RID: 6764
	private mVector vecMenu = new mVector();

	// Token: 0x04001A6D RID: 6765
	private int idCommand;

	// Token: 0x04001A6E RID: 6766
	private int hCharShow;
}
