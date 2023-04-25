using System;

// Token: 0x020000A4 RID: 164
public class MsgDialogTrangTri : MsgDialog
{
	// Token: 0x06000A26 RID: 2598 RVA: 0x0000B391 File Offset: 0x00009591
	public MsgDialogTrangTri()
	{
	}

	// Token: 0x06000A27 RID: 2599 RVA: 0x0000B3A6 File Offset: 0x000095A6
	public MsgDialogTrangTri(sbyte typeTrangTri)
	{
		this.typeTrangTri = typeTrangTri;
	}

	// Token: 0x06000A28 RID: 2600 RVA: 0x000CDAA0 File Offset: 0x000CBCA0
	public void setInfoTrangTri(short[][] mpos)
	{
		this.wDia = 220;
		this.hDia = 200;
		this.xDia = MotherCanvas.hw - this.wDia / 2;
		this.yDia = MotherCanvas.hh - this.hDia / 2;
		this.mpos = mpos;
		this.cmdList.removeAllElements();
		this.mSoLuong = new sbyte[this.mpos.Length];
		this.cmdTrangTri = new iCommand(T.trangtri, 0, this);
		this.cmdDoiQua = new iCommand(T.doiqua, 1, this);
		this.cmdClose = new iCommand(T.close, -1, this);
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.cmdClose.setPos(this.xDia + this.wDia - 13, this.yDia + 11, MainTab.fraCloseTab, string.Empty);
			this.cmdList.addElement(this.cmdClose);
			bool flag = this.cmdDoiQua != null;
			if (flag)
			{
				this.cmdDoiQua.setPos(GameCanvas.wCommand - 3, MotherCanvas.h - iCommand.hButtonCmdNor / 2 + 2, null, this.cmdDoiQua.caption);
				this.cmdList.addElement(this.cmdDoiQua);
			}
			bool flag2 = this.cmdTrangTri != null;
			if (flag2)
			{
				this.cmdTrangTri.setPos(MotherCanvas.w - GameCanvas.wCommand + 3, MotherCanvas.h - iCommand.hButtonCmdNor / 2 + 2, null, this.cmdTrangTri.caption);
				this.cmdList.addElement(this.cmdTrangTri);
			}
			this.backCMD = this.cmdClose;
			this.okCMD = this.cmdDoiQua;
			this.menuCMD = this.cmdTrangTri;
		}
		else
		{
			this.left = this.cmdTrangTri;
			this.center = this.cmdDoiQua;
			this.right = this.cmdClose;
		}
		this.meff.removeAllElements();
		this.isFullEvent = false;
	}

	// Token: 0x06000A29 RID: 2601 RVA: 0x000CDC9C File Offset: 0x000CBE9C
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case -1:
			GameCanvas.end_Dialog();
			break;
		case 0:
			GlobalService.gI().cmd_TrangTri(this.typeTrangTri, 0);
			break;
		case 1:
			GlobalService.gI().cmd_TrangTri(this.typeTrangTri, 1);
			break;
		}
	}

	// Token: 0x06000A2A RID: 2602 RVA: 0x000CDCF4 File Offset: 0x000CBEF4
	public override void paint(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		int num = this.yDia + this.hDia / 2;
		int num2 = this.xDia + this.wDia / 2;
		bool flag = this.typeTrangTri == MsgDialogTrangTri.TT_LO_SUOI;
		if (flag)
		{
			base.paintPaper_UpDown(g, this.xDia, this.yDia, this.wDia, this.hDia, this.wDia);
		}
		else
		{
			base.paintBgDialogTrangTri(g, this.xDia, this.yDia, this.wDia, this.hDia);
		}
		bool flag2 = this.isFullEvent;
		if (flag2)
		{
			for (int i = 0; i < this.meff.size(); i++)
			{
				Effect_End effect_End = (Effect_End)this.meff.elementAt(i);
				effect_End.paint(g);
			}
		}
		for (int j = this.mpos.Length - 1; j >= 0; j--)
		{
			MainImage imageAll = ObjectData.getImageAll(this.mpos[j][0], ObjectData.hashImageItemOther, 9000);
			bool flag3 = imageAll != null && imageAll.img != null;
			if (flag3)
			{
				bool flag4 = this.isFullEvent && this.mpos[j][5] < 0;
				if (flag4)
				{
					int num3 = (int)(imageAll.h / this.mpos[j][1]);
					g.drawRegion(imageAll.img, 0, GameCanvas.gameTickChia4 % (int)this.mpos[j][1] * num3, (int)imageAll.w, num3, 0, (float)(num2 + (int)this.mpos[j][2]), (float)(num + (int)this.mpos[j][3]), (int)this.mpos[j][4]);
				}
				else
				{
					bool flag5 = !this.isFullEvent && this.mpos[j][5] >= 0;
					if (flag5)
					{
						bool flag6 = this.mpos[j][1] > 2;
						if (flag6)
						{
							int num4 = (int)(imageAll.h / this.mpos[j][1]);
							g.drawRegion(imageAll.img, 0, GameCanvas.gameTickChia4 % (int)this.mpos[j][1] * num4, (int)imageAll.w, num4, 0, (float)(num2 + (int)this.mpos[j][2]), (float)(num + (int)this.mpos[j][3]), (int)this.mpos[j][4]);
						}
						else
						{
							int num5 = (int)(imageAll.h / this.mpos[j][1]);
							int num6 = 0;
							bool flag7 = this.mpos[j][1] == 2 && (short)this.mSoLuong[j] == this.mpos[j][5];
							if (flag7)
							{
								num6 = 1;
							}
							g.drawRegion(imageAll.img, 0, num6 * num5, (int)imageAll.w, num5, 0, (float)(num2 + (int)this.mpos[j][2]), (float)(num + (int)this.mpos[j][3]), (int)this.mpos[j][4]);
							bool flag8 = this.mpos[j][5] > 1 && (short)this.mSoLuong[j] < this.mpos[j][5];
							if (flag8)
							{
								mFont.tahoma_7b_black.drawString(g, this.mSoLuong[j].ToString() + "/" + this.mpos[j][5].ToString(), num2 + (int)this.mpos[j][2] + (int)this.mpos[j][6], num + (int)this.mpos[j][3] + (int)this.mpos[j][7], 2);
							}
						}
					}
				}
			}
		}
		bool flag9 = this.isFullEvent;
		if (flag9)
		{
			MainImage imageAll2 = ObjectData.getImageAll(192, ObjectData.HashImageEffClient, 24000);
			bool flag10 = imageAll2 != null && imageAll2.img != null;
			if (flag10)
			{
				int num7 = (int)(imageAll2.h / 2);
				g.drawRegion(imageAll2.img, 0, GameCanvas.gameTickChia4 / 2 % 2 * num7, (int)imageAll2.w, num7, 0, (float)(num2 - 71), (float)(num - 58), 3);
				g.drawRegion(imageAll2.img, 0, GameCanvas.gameTickChia4 / 2 % 2 * num7, (int)imageAll2.w, num7, 0, (float)(num2 + 70), (float)(num - 58), 3);
			}
		}
		GameCanvas.resetTrans(g);
		bool flag11 = this.cmdList != null;
		if (flag11)
		{
			for (int k = 0; k < this.cmdList.size(); k++)
			{
				iCommand iCommand = (iCommand)this.cmdList.elementAt(k);
				iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
			}
		}
		base.paintCmd(g);
	}

	// Token: 0x06000A2B RID: 2603 RVA: 0x000CE1B4 File Offset: 0x000CC3B4
	public override void update()
	{
		base.update();
		bool flag = this.isFullEvent && GameCanvas.gameTick % 6 == 0;
		if (flag)
		{
			int num = CRes.random(5);
			for (int i = 0; i < num; i++)
			{
				int x = CRes.random(this.xDia + 50, this.xDia + this.wDia - 50);
				int y = CRes.random(this.yDia + 50, this.yDia + this.wDia - 50);
				this.meff.addElement(new Effect_End(169, 0, x, y, 0));
			}
		}
		for (int j = 0; j < this.meff.size(); j++)
		{
			Effect_End effect_End = (Effect_End)this.meff.elementAt(j);
			effect_End.update();
			bool isStop = effect_End.isStop;
			if (isStop)
			{
				this.meff.removeElement(effect_End);
				j--;
			}
		}
	}

	// Token: 0x06000A2C RID: 2604 RVA: 0x000CE2BC File Offset: 0x000CC4BC
	public void updateDataTrangTri(short[] mId, sbyte[] mvalue)
	{
		bool flag = mId == null || mId.Length == 0;
		if (flag)
		{
			this.isFullEvent = false;
		}
		else
		{
			for (int i = 0; i < mId.Length; i++)
			{
				for (int j = 0; j < this.mpos.Length; j++)
				{
					bool flag2 = this.mpos[j][0] == mId[i];
					if (flag2)
					{
						bool flag3 = (short)mvalue[i] > this.mpos[j][5];
						if (flag3)
						{
							this.mSoLuong[j] = (sbyte)this.mpos[j][5];
						}
						else
						{
							this.mSoLuong[j] = mvalue[i];
						}
						ref sbyte ptr = ref mvalue[i];
						ptr -= this.mSoLuong[j];
						bool flag4 = mvalue[i] == 0;
						if (flag4)
						{
							break;
						}
					}
				}
			}
			bool flag5 = true;
			for (int k = 0; k < this.mpos.Length; k++)
			{
				bool flag6 = (short)this.mSoLuong[k] < this.mpos[k][5];
				if (flag6)
				{
					flag5 = false;
					break;
				}
			}
			this.isFullEvent = flag5;
		}
	}

	// Token: 0x04000FF9 RID: 4089
	public static sbyte TT_BANH_TET;

	// Token: 0x04000FFA RID: 4090
	public static sbyte TT_LO_SUOI = 4;

	// Token: 0x04000FFB RID: 4091
	private sbyte typeTrangTri;

	// Token: 0x04000FFC RID: 4092
	private short[][] mpos;

	// Token: 0x04000FFD RID: 4093
	private sbyte[] mSoLuong;

	// Token: 0x04000FFE RID: 4094
	private iCommand cmdTrangTri;

	// Token: 0x04000FFF RID: 4095
	private iCommand cmdDoiQua;

	// Token: 0x04001000 RID: 4096
	private bool isFullEvent;

	// Token: 0x04001001 RID: 4097
	private mVector meff = new mVector();
}
