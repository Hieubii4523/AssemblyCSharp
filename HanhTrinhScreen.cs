using System;

// Token: 0x0200003F RID: 63
public class HanhTrinhScreen : MainScreen
{
	// Token: 0x06000500 RID: 1280 RVA: 0x0007C4FC File Offset: 0x0007A6FC
	public HanhTrinhScreen()
	{
		this.w = 260;
		this.h = 215;
		this.x = MotherCanvas.hw - this.w / 2;
		this.y = MotherCanvas.hh - this.h / 2;
		this.cmdClose = new iCommand(T.close, -1, this);
		this.vecCmd.addElement(this.cmdClose);
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.cmdClose.setPos(this.x + this.w - 13, this.y + 13, MainTab.fraCloseTab, string.Empty);
		}
		else
		{
			this.right = this.cmdClose;
		}
	}

	// Token: 0x06000501 RID: 1281 RVA: 0x0007C5D4 File Offset: 0x0007A7D4
	public override void paint(mGraphics g)
	{
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.paint(g);
		}
		GameCanvas.resetTrans(g);
		AvMain.paintBG_AChi(g, this.x, this.y, this.w, this.h, 0);
		AvMain.FontBorderColor(g, this.nameList, MotherCanvas.hw, this.y - 20, 2, 6, 5);
		for (int i = 1; i < HanhTrinhScreen.mpos.Length; i++)
		{
			g.setColor(16711680);
			g.drawLine(this.x + HanhTrinhScreen.mpos[i][0], this.y + HanhTrinhScreen.mpos[i][1], this.x + HanhTrinhScreen.mpos[i - 1][0], this.y + HanhTrinhScreen.mpos[i - 1][1]);
		}
		for (int j = 0; j < HanhTrinhScreen.mpos.Length; j++)
		{
			bool flag2 = this.fraNen == null;
			if (flag2)
			{
				this.fraNen = new FrameImage(mImage.createImage("/interface/kham_hanh_trinh.png"), 2);
			}
			else
			{
				bool flag3 = this.mIcon[j] == -1;
				if (flag3)
				{
					this.fraNen.drawFrame(1, this.x + HanhTrinhScreen.mpos[j][0], this.y + HanhTrinhScreen.mpos[j][1], 0, 3, g);
				}
				else
				{
					this.fraNen.drawFrame(0, this.x + HanhTrinhScreen.mpos[j][0], this.y + HanhTrinhScreen.mpos[j][1], 0, 3, g);
				}
			}
			bool flag4 = this.mIcon[j] != -1;
			if (flag4)
			{
				MainImage imageAll = ObjectData.getImageAll(this.mIcon[j], ObjectData.hashImagePotion, 2000);
				bool flag5 = imageAll != null && imageAll.img != null;
				if (flag5)
				{
					g.drawImage(imageAll.img, this.x + HanhTrinhScreen.mpos[j][0], this.y + HanhTrinhScreen.mpos[j][1], 3);
				}
			}
			bool flag6 = HanhTrinhScreen.mpos[j][1] >= 175;
			if (flag6)
			{
				mFont.tahoma_7_black.drawString(g, this.mTenLang[j], this.x + HanhTrinhScreen.mpos[j][0], this.y + HanhTrinhScreen.mpos[j][1] + 13, 2);
			}
			else
			{
				mFont.tahoma_7_black.drawString(g, this.mTenLang[j], this.x + HanhTrinhScreen.mpos[j][0], this.y + HanhTrinhScreen.mpos[j][1] - 23, 2);
			}
		}
		for (int k = 0; k < this.vecCmd.size(); k++)
		{
			iCommand iCommand = (iCommand)this.vecCmd.elementAt(k);
			iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
		}
	}

	// Token: 0x06000502 RID: 1282 RVA: 0x0007C8C8 File Offset: 0x0007AAC8
	public override void commandPointer(int index, int subIndex)
	{
		bool flag = index == -1;
		if (flag)
		{
			bool flag2 = this.lastScreen != null;
			if (flag2)
			{
				this.lastScreen.Show(this.lastScreen.lastScreen);
			}
			else
			{
				GameCanvas.gameScr.Show();
			}
		}
	}

	// Token: 0x06000503 RID: 1283 RVA: 0x0007C918 File Offset: 0x0007AB18
	public override void updatePointer()
	{
		bool flag = this.vecCmd != null;
		if (flag)
		{
			for (int i = 0; i < this.vecCmd.size(); i++)
			{
				iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
				iCommand.updatePointer();
			}
		}
		base.updatePointer();
	}

	// Token: 0x04000735 RID: 1845
	public string nameList = string.Empty;

	// Token: 0x04000736 RID: 1846
	public static HanhTrinhScreen instance;

	// Token: 0x04000737 RID: 1847
	protected int x;

	// Token: 0x04000738 RID: 1848
	protected int y;

	// Token: 0x04000739 RID: 1849
	protected int w;

	// Token: 0x0400073A RID: 1850
	protected int h;

	// Token: 0x0400073B RID: 1851
	private static int[][] mpos = new int[][]
	{
		new int[]
		{
			50,
			55
		},
		new int[]
		{
			60,
			105
		},
		new int[]
		{
			45,
			155
		},
		new int[]
		{
			90,
			175
		},
		new int[]
		{
			110,
			125
		},
		new int[]
		{
			100,
			75
		},
		new int[]
		{
			150,
			45
		},
		new int[]
		{
			210,
			55
		},
		new int[]
		{
			165,
			95
		},
		new int[]
		{
			210,
			125
		},
		new int[]
		{
			160,
			155
		},
		new int[]
		{
			210,
			180
		}
	};

	// Token: 0x0400073C RID: 1852
	private FrameImage fraNen;

	// Token: 0x0400073D RID: 1853
	private iCommand cmdClose;

	// Token: 0x0400073E RID: 1854
	public mVector vecCmd = new mVector();

	// Token: 0x0400073F RID: 1855
	public string[] mTenLang;

	// Token: 0x04000740 RID: 1856
	public short[] mIcon;
}
