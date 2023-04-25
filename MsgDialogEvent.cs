using System;

// Token: 0x020000A3 RID: 163
public class MsgDialogEvent : MsgDialog
{
	// Token: 0x06000A20 RID: 2592 RVA: 0x000CD498 File Offset: 0x000CB698
	public void setInfoMerryCM()
	{
		this.wDia = 160;
		this.hDia = 150;
		this.xDia = MotherCanvas.hw - this.wDia / 2;
		this.yDia = MotherCanvas.hh - this.hDia / 2 - iCommand.hButtonCmdNor / 2;
		this.mpos = new int[][]
		{
			new int[]
			{
				50,
				1,
				0,
				-8,
				33,
				-1
			},
			new int[]
			{
				51,
				2,
				0,
				-103,
				3,
				0
			},
			new int[]
			{
				52,
				2,
				-12,
				-74,
				3,
				0
			},
			new int[]
			{
				53,
				2,
				4,
				-58,
				3,
				0
			},
			new int[]
			{
				54,
				2,
				-30,
				-28,
				3,
				0
			},
			new int[]
			{
				55,
				2,
				30,
				-28,
				3,
				0
			},
			new int[]
			{
				56,
				2,
				10,
				-83,
				3,
				1
			},
			new int[]
			{
				57,
				2,
				22,
				-53,
				3,
				1
			},
			new int[]
			{
				58,
				2,
				-19,
				-47,
				3,
				1
			},
			new int[]
			{
				59,
				2,
				0,
				-25,
				3,
				1
			},
			new int[]
			{
				60,
				2,
				-18,
				-8,
				3,
				2
			},
			new int[]
			{
				61,
				2,
				21,
				-12,
				3,
				2
			},
			new int[]
			{
				62,
				2,
				0,
				-120,
				3,
				3
			},
			new int[]
			{
				63,
				3,
				0,
				-8,
				33,
				-1
			}
		};
		this.cmdList.removeAllElements();
		this.mvalueCM = new int[this.mpos.Length];
		this.cmdTrangTri = new iCommand(T.trangtri, 0, this);
		this.cmdDoiQua = new iCommand(T.doiqua, 1, this);
		this.cmdClose = new iCommand(T.close, -1, this);
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.cmdClose.setPos(this.xDia + this.wDia - 13, this.yDia + 13, MainTab.fraCloseTab, string.Empty);
			this.cmdList.addElement(this.cmdClose);
			bool flag = this.cmdDoiQua != null;
			if (flag)
			{
				this.cmdDoiQua.setPos(this.xDia + this.wDia / 2 - iCommand.wButtonCmd / 2 - 2, this.yDia + this.hDia + iCommand.hButtonCmdNor, null, this.cmdDoiQua.caption);
				this.cmdList.addElement(this.cmdDoiQua);
			}
			bool flag2 = this.cmdTrangTri != null;
			if (flag2)
			{
				this.cmdTrangTri.setPos(this.xDia + this.wDia / 2 + iCommand.wButtonCmd / 2 + 2, this.yDia + this.hDia + iCommand.hButtonCmdNor, null, this.cmdTrangTri.caption);
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
	}

	// Token: 0x06000A21 RID: 2593 RVA: 0x000CD7D0 File Offset: 0x000CB9D0
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case -1:
			GameCanvas.end_Dialog();
			break;
		case 0:
			GlobalService.gI().cmd_Event(0);
			break;
		case 1:
			GlobalService.gI().cmd_Event(1);
			break;
		}
	}

	// Token: 0x06000A22 RID: 2594 RVA: 0x000CD81C File Offset: 0x000CBA1C
	public override void paint(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		int num = this.yDia + 140;
		int num2 = this.xDia + this.wDia / 2;
		base.paintPaper_UpDown(g, this.xDia - 5, this.yDia, this.maxWShow + 10, this.hDia, this.maxWShow + 10);
		for (int i = 0; i < this.mpos.Length; i++)
		{
			MainImage imageAll = ObjectData.getImageAll((short)this.mpos[i][0], ObjectData.hashImageItemOther, 9000);
			bool flag = i == this.mpos.Length - 1;
			if (flag)
			{
				bool flag2 = imageAll != null && imageAll.img != null && this.isFullEventCM;
				if (flag2)
				{
					int num3 = (int)imageAll.h / this.mpos[i][1];
					g.drawRegion(imageAll.img, 0, GameCanvas.gameTickChia4 % this.mpos[i][1] * num3, (int)imageAll.w, num3, 0, (float)(num2 + this.mpos[i][2]), (float)(num + this.mpos[i][3]), this.mpos[i][4]);
				}
			}
			else
			{
				bool flag3 = imageAll != null && imageAll.img != null;
				if (flag3)
				{
					int num4 = (int)imageAll.h / this.mpos[i][1];
					g.drawRegion(imageAll.img, 0, this.mvalueCM[i] * num4, (int)imageAll.w, num4, 0, (float)(num2 + this.mpos[i][2]), (float)(num + this.mpos[i][3]), this.mpos[i][4]);
				}
			}
		}
		GameCanvas.resetTrans(g);
		bool flag4 = this.cmdList != null;
		if (flag4)
		{
			for (int j = 0; j < this.cmdList.size(); j++)
			{
				iCommand iCommand = (iCommand)this.cmdList.elementAt(j);
				iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
			}
		}
		base.paintCmd(g);
	}

	// Token: 0x06000A23 RID: 2595 RVA: 0x0000B387 File Offset: 0x00009587
	public override void update()
	{
		base.update();
	}

	// Token: 0x06000A24 RID: 2596 RVA: 0x000CDA2C File Offset: 0x000CBC2C
	public void updateDataCM(sbyte[] mvalue)
	{
		bool flag = true;
		bool flag2 = mvalue == null || mvalue.Length == 0;
		if (!flag2)
		{
			for (int i = 0; i < mvalue.Length; i++)
			{
				bool flag3 = i + 1 < this.mvalueCM.Length;
				if (flag3)
				{
					this.mvalueCM[i + 1] = (int)mvalue[i];
				}
				bool flag4 = mvalue[i] == 0;
				if (flag4)
				{
					flag = false;
				}
			}
			this.isFullEventCM = flag;
		}
	}

	// Token: 0x04000FF4 RID: 4084
	private int[][] mpos;

	// Token: 0x04000FF5 RID: 4085
	private int[] mvalueCM;

	// Token: 0x04000FF6 RID: 4086
	private iCommand cmdTrangTri;

	// Token: 0x04000FF7 RID: 4087
	private iCommand cmdDoiQua;

	// Token: 0x04000FF8 RID: 4088
	private bool isFullEventCM;
}
