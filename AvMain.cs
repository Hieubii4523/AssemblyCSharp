using System;

// Token: 0x02000009 RID: 9
public class AvMain
{
	// Token: 0x06000021 RID: 33 RVA: 0x0000D928 File Offset: 0x0000BB28
	public virtual void paint(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		bool flag = GameCanvas.currentDialog == null && GameCanvas.subDialog == null && !GameCanvas.menuCur.isShowMenu;
		if (flag)
		{
			this.paintCmd(g);
		}
	}

	// Token: 0x06000022 RID: 34 RVA: 0x0000D928 File Offset: 0x0000BB28
	public virtual void paintHideAvatar(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		bool flag = GameCanvas.currentDialog == null && GameCanvas.subDialog == null && !GameCanvas.menuCur.isShowMenu;
		if (flag)
		{
			this.paintCmd(g);
		}
	}

	// Token: 0x06000023 RID: 35 RVA: 0x0000D96C File Offset: 0x0000BB6C
	public void paintCmd(mGraphics g)
	{
		bool flag = this.left != null;
		if (flag)
		{
			bool flag2 = this.left.xCmd > 0 && this.left.yCmd > 0;
			if (flag2)
			{
				this.left.paint(g, this.left.xCmd, this.left.yCmd);
			}
			else
			{
				this.left.paint(g, GameCanvas.wCommand - 3, MotherCanvas.h - iCommand.hButtonCmdNor / 2 + 2);
			}
		}
		bool flag3 = this.right != null;
		if (flag3)
		{
			this.right.paint(g, MotherCanvas.w - GameCanvas.wCommand + 3, MotherCanvas.h - iCommand.hButtonCmdNor / 2 + 2);
		}
		bool flag4 = this.center != null;
		if (flag4)
		{
			this.center.paint(g, MotherCanvas.hw, MotherCanvas.h - iCommand.hButtonCmdNor / 2 + 2);
		}
	}

	// Token: 0x06000024 RID: 36 RVA: 0x0000DA60 File Offset: 0x0000BC60
	public void paintOnlyCaption(mGraphics g)
	{
		bool flag = this.left != null;
		if (flag)
		{
			this.left.paintOnlyCaption(g, GameCanvas.wCommand / 3 * 2, MotherCanvas.h - iCommand.hButtonCmdNor / 2 - 1);
		}
		bool flag2 = this.right != null;
		if (flag2)
		{
			this.right.paintOnlyCaption(g, MotherCanvas.w - GameCanvas.wCommand / 3 * 2, MotherCanvas.h - iCommand.hButtonCmdNor / 2 - 1);
		}
		bool flag3 = this.center != null;
		if (flag3)
		{
			this.center.paintOnlyCaption(g, MotherCanvas.hw, MotherCanvas.h - iCommand.hButtonCmdNor / 2 - 1);
		}
	}

	// Token: 0x06000025 RID: 37 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void update()
	{
	}

	// Token: 0x06000026 RID: 38 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void commandTab(int index, int subIndex)
	{
	}

	// Token: 0x06000027 RID: 39 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void commandMenu(int index, int subIndex)
	{
	}

	// Token: 0x06000028 RID: 40 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void commandPointer(int index, int subIndex)
	{
	}

	// Token: 0x06000029 RID: 41 RVA: 0x0000DB0C File Offset: 0x0000BD0C
	public virtual void updatekey()
	{
		bool flag = GameCanvas.keyMyHold[5];
		if (flag)
		{
			bool flag2 = this.center != null;
			if (flag2)
			{
				GameCanvas.clearKeyPressed(5);
				GameCanvas.clearKeyHold(5);
				this.center.perform();
			}
		}
		else
		{
			bool flag3 = GameCanvas.keyMyHold[12];
			if (flag3)
			{
				bool flag4 = this.left != null;
				if (flag4)
				{
					GameCanvas.clearKeyPressed(12);
					GameCanvas.clearKeyHold(12);
					this.left.perform();
				}
			}
			else
			{
				bool flag5 = GameCanvas.keyMyHold[13] && this.right != null;
				if (flag5)
				{
					GameCanvas.clearKeyPressed(13);
					GameCanvas.clearKeyHold(13);
					this.right.perform();
				}
			}
		}
	}

	// Token: 0x0600002A RID: 42 RVA: 0x0000DBC8 File Offset: 0x0000BDC8
	public virtual void updatekeyPC()
	{
		bool flag = GameCanvas.UseKey(5);
		if (flag)
		{
			bool flag2 = this.okCMD != null;
			if (flag2)
			{
				GameCanvas.clearKeyPressed(5);
				GameCanvas.clearKeyHold(5);
				this.okCMD.perform();
			}
		}
		else
		{
			bool flag3 = GameCanvas.UseKey(40) || (GameCanvas.isTouch && GameCanvas.UseKey(12));
			if (flag3)
			{
				bool flag4 = this.menuCMD != null;
				if (flag4)
				{
					GameCanvas.clearKeyPressed(40);
					GameCanvas.clearKeyHold(40);
					this.menuCMD.perform();
				}
			}
			else
			{
				bool flag5 = (GameCanvas.UseKey(41) || (GameCanvas.isTouch && GameCanvas.UseKey(13))) && this.backCMD != null;
				if (flag5)
				{
					GameCanvas.clearKeyPressed(41);
					GameCanvas.clearKeyHold(41);
					this.backCMD.perform();
				}
			}
		}
	}

	// Token: 0x0600002B RID: 43 RVA: 0x0000DCAC File Offset: 0x0000BEAC
	public virtual void updatekeyPCForTField()
	{
		bool flag = GameCanvas.UseKey(5);
		if (flag)
		{
			bool flag2 = this.okCMD != null;
			if (flag2)
			{
				GameCanvas.clearKeyPressed(5);
				GameCanvas.clearKeyHold(5);
				this.okCMD.perform();
			}
		}
		else
		{
			bool flag3 = GameCanvas.isTouch && GameCanvas.UseKey(12);
			if (flag3)
			{
				bool flag4 = this.menuCMD != null;
				if (flag4)
				{
					GameCanvas.clearKeyPressed(12);
					GameCanvas.clearKeyHold(12);
					this.menuCMD.perform();
				}
			}
			else
			{
				bool flag5 = GameCanvas.isTouch && GameCanvas.UseKey(13) && this.backCMD != null;
				if (flag5)
				{
					GameCanvas.clearKeyPressed(13);
					GameCanvas.clearKeyHold(13);
					this.backCMD.perform();
				}
			}
		}
	}

	// Token: 0x0600002C RID: 44 RVA: 0x0000DD78 File Offset: 0x0000BF78
	public virtual void updatePointer()
	{
		bool flag = !GameCanvas.isTouch;
		if (!flag)
		{
			bool flag2 = this.left != null;
			if (flag2)
			{
				bool flag3 = this.left.isPosCmd();
				if (flag3)
				{
					this.left.updatePointer();
				}
				else
				{
					bool flag4 = GameCanvas.isPointSelect(0, MotherCanvas.h - GameCanvas.hCommand - 5, GameCanvas.wCommand * 2, GameCanvas.hCommand + 10);
					if (flag4)
					{
						this.left.perform();
					}
				}
			}
			bool flag5 = this.right != null;
			if (flag5)
			{
				bool flag6 = this.right.isPosCmd();
				if (flag6)
				{
					this.right.updatePointer();
				}
				else
				{
					bool flag7 = GameCanvas.isPointSelect(MotherCanvas.w - GameCanvas.wCommand * 2, MotherCanvas.h - GameCanvas.hCommand - 5, GameCanvas.wCommand * 2, GameCanvas.hCommand + 10);
					if (flag7)
					{
						this.right.perform();
					}
				}
			}
			bool flag8 = this.center != null;
			if (flag8)
			{
				bool flag9 = this.center.isPosCmd();
				if (flag9)
				{
					this.center.updatePointer();
				}
				else
				{
					bool flag10 = GameCanvas.isPointSelect(MotherCanvas.hw - GameCanvas.wCommand, MotherCanvas.h - GameCanvas.hCommand - 5, GameCanvas.wCommand * 2, GameCanvas.hCommand + 10);
					if (flag10)
					{
						this.center.perform();
					}
				}
			}
		}
	}

	// Token: 0x0600002D RID: 45 RVA: 0x0000DEE0 File Offset: 0x0000C0E0
	public static int resetSelect(int select, int max, bool isreset)
	{
		bool flag = select < 0;
		if (flag)
		{
			select = (isreset ? max : 0);
		}
		else
		{
			bool flag2 = select > max;
			if (flag2)
			{
				select = ((!isreset) ? max : 0);
			}
		}
		return select;
	}

	// Token: 0x0600002E RID: 46 RVA: 0x0000DF1C File Offset: 0x0000C11C
	public static void paintnenFocus(mGraphics g, int x, int y, int w, int h)
	{
		bool flag = w < 76;
		if (flag)
		{
			w = 76;
		}
		bool flag2 = h > 36;
		if (flag2)
		{
			bool flag3 = Interface_Game.imgInfoNew == null;
			if (flag3)
			{
				Interface_Game.imgInfoNew = LoadImageStatic.LoadNewInterface("/infonew.png");
			}
			bool flag4 = w == 76;
			if (flag4)
			{
				g.drawRegion(Interface_Game.imgInfoNew, 0, 0, 38, 45, 0, (float)x, (float)y, 0);
				g.drawRegion(Interface_Game.imgInfoNew, 54, 0, 38, 45, 0, (float)(x + 38), (float)y, 0);
			}
			else
			{
				g.drawRegion(Interface_Game.imgInfoNew, 18, 0, 74, 36, 0, (float)(x + w - 74), (float)y, 0);
				int num = w - 74;
				bool flag5 = num > 74;
				if (flag5)
				{
					num = 74;
				}
				g.drawRegion(Interface_Game.imgInfoNew, 0, 0, num, 36, 0, (float)x, (float)y, 0);
			}
		}
		else
		{
			bool flag6 = w == 76;
			if (flag6)
			{
				g.drawImage(AvMain.imgNenfocus, x, y, 0);
			}
			else
			{
				g.drawRegion(AvMain.imgNenfocus, 2, 0, 74, 36, 0, (float)(x + w - 74), (float)y, 0);
				int num2 = w - 74;
				bool flag7 = num2 > 74;
				if (flag7)
				{
					num2 = 74;
				}
				g.drawRegion(AvMain.imgNenfocus, 0, 0, num2, 36, 0, (float)x, (float)y, 0);
			}
		}
	}

	// Token: 0x0600002F RID: 47 RVA: 0x0000E064 File Offset: 0x0000C264
	public static void paintnenFocusSmall(mGraphics g, int x, int y, int w, int h)
	{
		bool flag = w > 72;
		if (flag)
		{
			w = 72;
		}
		bool flag2 = h > 32;
		if (flag2)
		{
			h = 32;
		}
		g.drawRegion(AvMain.imgNenfocus, 2, 2, w, h, 0, (float)x, (float)y, 0);
	}

	// Token: 0x06000030 RID: 48 RVA: 0x0000E0A8 File Offset: 0x0000C2A8
	public static void paintRect(mGraphics g, int xText, int yText, int wText, int hText, sbyte isborder, int index)
	{
		bool flag = index >= AvMain.colorRect.Length;
		if (flag)
		{
			index = (int)((sbyte)(AvMain.colorRect.Length - 1));
		}
		int num = index * 4;
		int num2 = 2;
		bool flag2 = isborder == 1;
		if (flag2)
		{
			g.setColor(16446420);
			g.fillRect(xText + 1, yText - 1, wText - 1, hText + 3);
			g.fillRect(xText, yText, wText + 1, hText + 1);
			g.fillRect(xText - 1, yText + 1, wText + 3, hText - 1);
			AvMain.fratf1.drawFrame(0, xText - num2, yText - num2, 0, 0, g);
			AvMain.fratf1.drawFrame(1, xText - num2, yText + hText - 3, 0, 0, g);
			AvMain.fratf1.drawFrame(2, xText + wText - 3, yText - num2, 0, 0, g);
			AvMain.fratf1.drawFrame(3, xText + wText - 3, yText + hText - 3, 0, 0, g);
		}
		else
		{
			bool flag3 = isborder == 3;
			if (flag3)
			{
				g.setColor(16049947);
				g.fillRect(xText + 1, yText - 1, wText - 1, hText + 3);
				g.fillRect(xText, yText, wText + 1, hText + 1);
				g.fillRect(xText - 1, yText + 1, wText + 3, hText - 1);
				AvMain.fratf1.drawFrame(4, xText - num2, yText - num2, 0, 0, g);
				AvMain.fratf1.drawFrame(5, xText - num2, yText + hText - 3, 0, 0, g);
				AvMain.fratf1.drawFrame(6, xText + wText - 3, yText - num2, 0, 0, g);
				AvMain.fratf1.drawFrame(7, xText + wText - 3, yText + hText - 3, 0, 0, g);
			}
		}
		g.setColor(AvMain.colorRect[index][0]);
		g.fillRect(xText + 4, yText, wText - 7, hText + 1);
		g.fillRect(xText, yText + 4, wText + 1, hText - 7);
		g.setColor(AvMain.colorRect[index][1]);
		g.fillRect(xText + 4, yText, wText - 7, 1);
		g.fillRect(xText, yText + 4, 1, hText - 7);
		bool flag4 = isborder == 2;
		if (flag4)
		{
			AvMain.fratf.drawFrame(num + 2, xText + wText - 3, yText - num2, 0, 0, g);
			AvMain.fratf.drawFrame(num + 3, xText + wText - 3, yText + hText - 3, 0, 0, g);
			AvMain.fratf.drawFrame(num, xText - num2, yText - num2, 0, 0, g);
			AvMain.fratf.drawFrame(num + 1, xText - num2, yText + hText - 3, 0, 0, g);
			g.setColor(AvMain.colorRect[index][1]);
			g.fillRect(xText + 1, yText + hText, wText - 1, 1);
			g.fillRect(xText + wText, yText + 1, 1, hText - 1);
		}
		else
		{
			AvMain.fratf.drawFrame(num + 2, xText + wText - 3, yText - num2, 0, 0, g);
			AvMain.fratf.drawFrame(num + 3, xText + wText - 3, yText + hText - 3, 0, 0, g);
			AvMain.fratf.drawFrame(num, xText - num2, yText - num2, 0, 0, g);
			AvMain.fratf.drawFrame(num + 1, xText - num2, yText + hText - 3, 0, 0, g);
		}
	}

	// Token: 0x06000031 RID: 49 RVA: 0x0000E3BC File Offset: 0x0000C5BC
	public static void paintDrawRect(mGraphics g, int xText, int yText, int wText, int hText)
	{
		g.setColor(16446420);
		g.fillRect(xText + 1, yText - 1, wText - 2, 1);
		g.fillRect(xText + 1, yText + hText, wText - 2, 1);
		g.fillRect(xText - 1, yText + 1, 1, hText - 2);
		g.fillRect(xText + wText, yText + 1, 1, hText - 2);
		g.fillRect(xText, yText, 1, 1);
		g.fillRect(xText + wText - 1, yText, 1, 1);
		g.fillRect(xText, yText + hText - 1, 1, 1);
		g.fillRect(xText + wText - 1, yText + hText - 1, 1, 1);
	}

	// Token: 0x06000032 RID: 50 RVA: 0x0000E45C File Offset: 0x0000C65C
	public static void paintRectButton(mGraphics g, int xText, int yText, int wText, int hText, int index)
	{
		bool flag = GameMidlet.DEVICE == 0;
		if (flag)
		{
			bool flag2 = index >= AvMain.colorRect.Length;
			if (flag2)
			{
				index = (int)((sbyte)(AvMain.colorRect.Length - 1));
			}
			g.setColor(AvMain.colorButton[index][4]);
			g.fillRect(xText, yText, wText, hText);
			g.fillRect(xText - 1, yText + 1, 1, hText - 2);
			g.fillRect(xText + 1, yText - 1, wText - 2, 1);
			g.fillRect(xText + wText - 1 + 1, yText + 1, 1, hText - 2);
			g.fillRect(xText + 1, yText + hText, wText - 2, 1);
			g.setColor(AvMain.colorButton[index][2]);
			g.fillRect(xText + 1, yText + 1, wText - 2, hText / 2 - 1);
			g.setColor(AvMain.colorButton[index][3]);
			g.fillRect(xText + 1, yText + 1 + hText / 2 - 1, wText - 2, hText - hText / 2 - 1);
			g.setColor(AvMain.colorButton[index][0]);
			g.fillRect(xText, yText + 1, 1, hText - 2);
			g.fillRect(xText + 1, yText, wText - 2, 1);
			g.setColor(AvMain.colorButton[index][1]);
			g.fillRect(xText + wText - 1, yText + 1, 1, hText - 2);
			g.fillRect(xText + 1, yText + hText - 1, wText - 2, 1);
		}
		else
		{
			AvMain.paintImgButton(g, xText, yText, wText, hText, index);
		}
	}

	// Token: 0x06000033 RID: 51 RVA: 0x0000E5D8 File Offset: 0x0000C7D8
	public static void paintImgButton(mGraphics g, int xText, int yText, int wText, int hText, int index)
	{
		wText += wText % 2;
		hText += hText % 2;
		bool flag = index >= AvMain.colorRect.Length;
		if (flag)
		{
			index = (int)((sbyte)(AvMain.colorRect.Length - 1));
		}
		g.setColor(AvMain.colorButton[index][2]);
		g.fillRect(xText + 2, yText + 2, wText - 4, hText - 4);
		g.drawRegion(AvMain.imgButton[0], 0, index * 20, 5, 5, 0, (float)xText, (float)yText, 0);
		g.drawRegion(AvMain.imgButton[0], 0, index * 20 + 5, 5, 5, 0, (float)(xText + wText), (float)yText, mGraphics.TOP | mGraphics.RIGHT);
		g.drawRegion(AvMain.imgButton[0], 0, index * 20 + 10, 5, 5, 0, (float)xText, (float)(yText + hText), mGraphics.BOTTOM | mGraphics.LEFT);
		g.drawRegion(AvMain.imgButton[0], 0, index * 20 + 15, 5, 5, 0, (float)(xText + wText), (float)(yText + hText), mGraphics.BOTTOM | mGraphics.RIGHT);
		g.setColor(AvMain.colorButton[index][3]);
		g.fillRect(xText + 3, yText + hText / 2, wText - 6, hText / 2 - 4);
		g.fillRect(xText + 4, yText + hText - 4, wText - 8, 1);
		g.drawRegion(AvMain.imgButton[1], 0, index * 12, 15, 6, 0, (float)(xText + 3), (float)(yText + 3), 0);
		g.drawRegion(AvMain.imgButton[1], 0, index * 12 + 6, 15, 6, 0, (float)(xText + wText - 3), (float)(yText + hText - 3), mGraphics.BOTTOM | mGraphics.RIGHT);
		g.setColor(AvMain.colorButton[index][4]);
		g.fillRect(xText + 3, yText, wText - 6, 1);
		g.fillRect(xText + 3, yText + hText - 1, wText - 6, 1);
		g.fillRect(xText, yText + 3, 1, hText - 6);
		g.fillRect(xText + wText - 1, yText + 3, 1, hText - 6);
		g.setColor(AvMain.colorButton[index][0]);
		g.fillRect(xText + 3, yText + 1, wText - 6, 1);
		g.fillRect(xText + 1, yText + 3, 1, hText - 6);
		g.setColor(AvMain.colorButton[index][1]);
		g.fillRect(xText + 3, yText + hText - 2, wText - 6, 1);
		g.fillRect(xText + wText - 2, yText + 3, 1, hText - 6);
	}

	// Token: 0x06000034 RID: 52 RVA: 0x0000E834 File Offset: 0x0000CA34
	public static void paintBG_AChi(mGraphics g, int x, int y, int w, int h, int type)
	{
		bool flag = AvMain.mimgBgA == null;
		if (flag)
		{
			mSystem.outz("paint bg low");
			AvMain.paintBG_AChi_Low(g, x + 16, y + 16, w - 32, h - 32, type);
		}
		else
		{
			int num = 0;
			int num2 = 0;
			int num3 = 36;
			int num4 = 72;
			if (type != 1)
			{
				if (type == 2)
				{
					num2 = 19;
					num3 = 32;
					num4 = 68;
				}
			}
			else
			{
				num2 = 22;
				num3 = 32;
				num4 = 68;
			}
			g.drawImage(AvMain.mimgBgA[num + num2], x, y, 0);
			g.drawImage(AvMain.mimgBgA[2 + num + num2], x + w - 36, y, 0);
			int num5 = (w - 73) / num3 + 1;
			for (int i = 0; i <= num5; i++)
			{
				bool flag2 = i == num5;
				if (flag2)
				{
					g.drawImage(AvMain.mimgBgA[1 + num + num2], x + w - num4, y, 0);
				}
				else
				{
					g.drawImage(AvMain.mimgBgA[1 + num + num2], x + num3 + i * num3, y, 0);
				}
			}
			num5 = (w - 73) / 36 + 1;
			for (int j = 0; j < num5; j++)
			{
				bool flag3 = j == num5 - 1;
				if (flag3)
				{
					g.drawImage(AvMain.mimgBgA[7 + num], x + w - 72, y + h - 38, 0);
				}
				else
				{
					g.drawImage(AvMain.mimgBgA[7 + num], x + 36 + j * 36, y + h - 38, 0);
				}
			}
			int num6 = (h - 36 - 39) / 38 + 1;
			for (int k = 0; k < num6; k++)
			{
				bool flag4 = k == num6 - 1;
				if (flag4)
				{
					g.drawImage(AvMain.mimgBgA[3 + num], x + 4, y + h - 76, 0);
					g.drawImage(AvMain.mimgBgA[5 + num], x + w - 4 - 36, y + h - 76, 0);
				}
				else
				{
					g.drawImage(AvMain.mimgBgA[3 + num], x + 4, y + 36 + k * 38, 0);
					g.drawImage(AvMain.mimgBgA[5 + num], x + w - 4 - 36, y + 36 + k * 38, 0);
				}
			}
			g.drawImage(AvMain.mimgBgA[4 + num], x + 4, y + h - 38, 0);
			g.drawImage(AvMain.mimgBgA[6 + num], x + w - 36 - 4, y + h - 38, 0);
			num = 8;
			int num7 = x + 12;
			int num8 = y + 22;
			bool flag5 = type == 2;
			if (flag5)
			{
				num8 = y + 26;
			}
			int num9 = h - 30;
			int num10 = w - 24;
			g.drawImage(AvMain.mimgBgA[num], num7, num8, 0);
			g.drawImage(AvMain.mimgBgA[2 + num], num7 + num10 - 36, num8, 0);
			num5 = (num10 - 73) / 36 + 1;
			for (int l = 0; l < num5; l++)
			{
				bool flag6 = l == num5 - 1;
				if (flag6)
				{
					g.drawImage(AvMain.mimgBgA[1 + num], num7 + num10 - 72, num8, 0);
					g.drawImage(AvMain.mimgBgA[7 + num], num7 + num10 - 72, num8 + num9 - 36, 0);
				}
				else
				{
					g.drawImage(AvMain.mimgBgA[1 + num], num7 + 36 + l * 36, num8, 0);
					g.drawImage(AvMain.mimgBgA[7 + num], num7 + 36 + l * 36, num8 + num9 - 36, 0);
				}
			}
			num6 = (num9 - 36 - 37) / 36 + 1;
			for (int m = 0; m < num6; m++)
			{
				bool flag7 = m == num6 - 1;
				if (flag7)
				{
					g.drawImage(AvMain.mimgBgA[3 + num], num7, num8 + num9 - 72, 0);
					g.drawImage(AvMain.mimgBgA[5 + num], num7 + num10 - 36, num8 + num9 - 72, 0);
				}
				else
				{
					g.drawImage(AvMain.mimgBgA[3 + num], num7, num8 + 36 + m * 36, 0);
					g.drawImage(AvMain.mimgBgA[5 + num], num7 + num10 - 36, num8 + 36 + m * 36, 0);
				}
			}
			g.drawImage(AvMain.mimgBgA[4 + num], num7, num8 + num9 - 36, 0);
			g.drawImage(AvMain.mimgBgA[6 + num], num7 + num10 - 36, num8 + num9 - 36, 0);
			g.setColor(16246726);
			g.fillRect(num7 + 35, num8 + 35, num10 - 70, num9 - 70);
			bool flag8 = type == 0;
			if (flag8)
			{
				g.drawImage(AvMain.mimgBgA[16], x + w / 2 - 84, y - 24, 0);
				g.drawImage(AvMain.mimgBgA[18], x + w / 2 + 84 - 24, y - 24, 0);
				for (int n = 0; n < 5; n++)
				{
					g.drawImage(AvMain.mimgBgA[17], x + w / 2 - 84 + 24 + n * 24, y - 24, 0);
				}
			}
		}
	}

	// Token: 0x06000035 RID: 53 RVA: 0x0000EDAC File Offset: 0x0000CFAC
	public static void paintThongThao(mGraphics g, int x, int y, int w, int h)
	{
		bool lowGraphic = GameCanvas.lowGraphic;
		if (lowGraphic)
		{
			AvMain.paintRectLowGraphic(g, x, y, w, h, 1);
		}
		else
		{
			bool flag = AvMain.mimgBgB == null;
			if (flag)
			{
				LoadImageStatic.loadImageBgB();
			}
			int num = 0;
			g.drawImage(AvMain.mimgBgB[num], x, y, 0);
			g.drawImage(AvMain.mimgBgB[2 + num], x + w - 36, y, 0);
			int num2 = (w - 73) / 36 + 1;
			for (int i = 0; i < num2; i++)
			{
				bool flag2 = i == num2 - 1;
				if (flag2)
				{
					g.drawImage(AvMain.mimgBgB[1 + num], x + w - 72, y, 0);
					g.drawImage(AvMain.mimgBgB[7 + num], x + w - 72, y + h - 36, 0);
				}
				else
				{
					g.drawImage(AvMain.mimgBgB[1 + num], x + 36 + i * 36, y, 0);
					g.drawImage(AvMain.mimgBgB[7 + num], x + 36 + i * 36, y + h - 36, 0);
				}
			}
			int num3 = (h - 36 - 37) / 36 + 1;
			for (int j = 0; j < num3; j++)
			{
				bool flag3 = j == num3 - 1;
				if (flag3)
				{
					g.drawImage(AvMain.mimgBgB[3 + num], x, y + h - 72, 0);
					g.drawImage(AvMain.mimgBgB[5 + num], x + w - 36, y + h - 72, 0);
				}
				else
				{
					g.drawImage(AvMain.mimgBgB[3 + num], x, y + 36 + j * 36, 0);
					g.drawImage(AvMain.mimgBgB[5 + num], x + w - 36, y + 36 + j * 36, 0);
				}
			}
			g.drawImage(AvMain.mimgBgB[4 + num], x, y + h - 36, 0);
			g.drawImage(AvMain.mimgBgB[6 + num], x + w - 36, y + h - 36, 0);
			g.setColor(15392973);
			g.fillRect(x + 35, y + 35, w - 70, h - 70);
		}
	}

	// Token: 0x06000036 RID: 54 RVA: 0x0000EFF0 File Offset: 0x0000D1F0
	public static void paintRuongVip(mGraphics g, int x, int y, int w, int h)
	{
		bool lowGraphic = GameCanvas.lowGraphic;
		if (lowGraphic)
		{
			AvMain.paintRectLowGraphic(g, x, y, w, h, 1);
		}
		else
		{
			bool flag = AvMain.mimgBgC == null;
			if (flag)
			{
				LoadImageStatic.loadImageBgC();
			}
			int num = 0;
			g.drawImage(AvMain.mimgBgC[num], x, y, 0);
			g.drawImage(AvMain.mimgBgC[2 + num], x + w - 46, y, 0);
			int num2 = (w - 93) / 46 + 1;
			for (int i = 0; i < num2; i++)
			{
				bool flag2 = i == num2 - 1;
				if (flag2)
				{
					g.drawImage(AvMain.mimgBgC[1 + num], x + w - 92, y, 0);
					g.drawImage(AvMain.mimgBgC[7 + num], x + w - 92, y + h - 46, 0);
				}
				else
				{
					g.drawImage(AvMain.mimgBgC[1 + num], x + 46 + i * 46, y, 0);
					g.drawImage(AvMain.mimgBgC[7 + num], x + 46 + i * 46, y + h - 46, 0);
				}
			}
			int num3 = (h - 46 - 47) / 46 + 1;
			for (int j = 0; j < num3; j++)
			{
				bool flag3 = j == num3 - 1;
				if (flag3)
				{
					g.drawImage(AvMain.mimgBgC[3 + num], x, y + h - 92, 0);
					g.drawImage(AvMain.mimgBgC[5 + num], x + w - 46, y + h - 72, 0);
				}
				else
				{
					g.drawImage(AvMain.mimgBgC[3 + num], x, y + 46 + j * 46, 0);
					g.drawImage(AvMain.mimgBgC[5 + num], x + w - 46, y + 46 + j * 46, 0);
				}
			}
			g.drawImage(AvMain.mimgBgC[4 + num], x, y + h - 46, 0);
			g.drawImage(AvMain.mimgBgC[6 + num], x + w - 46, y + h - 46, 0);
			g.setColor(16709599);
			g.fillRect(x + 45, y + 45, w - 90, h - 90);
		}
	}

	// Token: 0x06000037 RID: 55 RVA: 0x0000F234 File Offset: 0x0000D434
	public static void paintBG_Wanted_Room(mGraphics g, int x, int y, int w, int h)
	{
		bool flag = AvMain.mimgBgA == null;
		if (flag)
		{
			AvMain.paintBG_AChi_Low(g, x + 16, y + 16, w - 32, h - 32, 2);
		}
		else
		{
			int num = 0;
			int num2 = 19;
			int num3 = 32;
			int num4 = 68;
			g.setColor(14850638);
			g.fillRect(x + 36, y + 36, w - 72, h - 72);
			g.drawImage(AvMain.mimgBgA[num + num2], x, y, 0);
			g.drawImage(AvMain.mimgBgA[2 + num + num2], x + w - 36, y, 0);
			int num5 = (w - 73) / num3 + 1;
			for (int i = 0; i <= num5; i++)
			{
				bool flag2 = i == num5;
				if (flag2)
				{
					g.drawImage(AvMain.mimgBgA[1 + num + num2], x + w - num4, y, 0);
				}
				else
				{
					g.drawImage(AvMain.mimgBgA[1 + num + num2], x + num3 + i * num3, y, 0);
				}
			}
			num5 = (w - 73) / 36 + 1;
			for (int j = 0; j < num5; j++)
			{
				bool flag3 = j == num5 - 1;
				if (flag3)
				{
					g.drawImage(AvMain.mimgBgA[7 + num], x + w - 72, y + h - 38, 0);
				}
				else
				{
					g.drawImage(AvMain.mimgBgA[7 + num], x + 36 + j * 36, y + h - 38, 0);
				}
			}
			int num6 = (h - 36 - 39) / 38 + 1;
			for (int k = 0; k < num6; k++)
			{
				bool flag4 = k == num6 - 1;
				if (flag4)
				{
					g.drawImage(AvMain.mimgBgA[3 + num], x + 4, y + h - 76, 0);
					g.drawImage(AvMain.mimgBgA[5 + num], x + w - 4 - 36, y + h - 76, 0);
					g.drawImage(AvMain.mimgBgA[25 + num], x + w - 72 - 4 - 36, y + h - 76, 0);
					g.drawImage(AvMain.mimgBgA[25 + num], x + w - 36 - 4 - 36, y + h - 76, 0);
				}
				else
				{
					g.drawImage(AvMain.mimgBgA[3 + num], x + 4, y + 36 + k * 38, 0);
					g.drawImage(AvMain.mimgBgA[5 + num], x + w - 4 - 36, y + 36 + k * 38, 0);
					g.drawImage(AvMain.mimgBgA[25 + num], x + w - 72 - 4 - 36, y + 36 + k * 38, 0);
					g.drawImage(AvMain.mimgBgA[25 + num], x + w - 36 - 4 - 36, y + 36 + k * 38, 0);
				}
			}
			g.drawImage(AvMain.mimgBgA[4 + num], x + 4, y + h - 38, 0);
			g.drawImage(AvMain.mimgBgA[6 + num], x + w - 36 - 4, y + h - 38, 0);
		}
	}

	// Token: 0x06000038 RID: 56 RVA: 0x0000F550 File Offset: 0x0000D750
	public static void paintBG_AChi_Low(mGraphics g, int x, int y, int w, int h, int type)
	{
		bool flag = type == 0;
		if (flag)
		{
			AvMain.paintRectLowGraphic(g, x + w / 2 - 84, y - 5 - 16, 168, 22, 1);
			x += 10;
			w -= 20;
			y += 14;
			h -= 18;
		}
		AvMain.paintRectLowGraphic(g, x, y, w, h, type);
	}

	// Token: 0x06000039 RID: 57 RVA: 0x0000F5B0 File Offset: 0x0000D7B0
	public static void paintBG_WantedFull(mGraphics g, int x, int y)
	{
		bool flag = AvMain.imgWanted != null;
		if (flag)
		{
			g.drawImage(AvMain.imgWanted, x, y, 0);
		}
	}

	// Token: 0x0600003A RID: 58 RVA: 0x0000F5DC File Offset: 0x0000D7DC
	public static void paintBG_Wanted2(mGraphics g, int x, int y, int w, int h, int type)
	{
		bool flag = AvMain.demo != null;
		if (flag)
		{
			bool flag2 = GameMidlet.DEVICE > 0;
			if (flag2)
			{
				g.drawImage(AvMain.demo, x, y, 0);
			}
			else
			{
				AvMain.paintBGWanted(g, x, y, w, h);
			}
		}
	}

	// Token: 0x0600003B RID: 59 RVA: 0x0000F628 File Offset: 0x0000D828
	public static void paintBGWanted(mGraphics g, int x, int y, int w, int h)
	{
		g.drawImage(AvMain.mimgWanted2[8], x + 30, y + 30, 0);
		g.drawImage(AvMain.mimgWanted2[9], x + 30 + 30, y + 30, 0);
		g.drawImage(AvMain.mimgWanted2[10], x + 30 + 30 + 30, y + 30, 0);
		g.drawImage(AvMain.mimgWanted2[11], x + 30, y + 30 + 30, 0);
		g.drawImage(AvMain.mimgWanted2[8], x + 30 + 30, y + 30 + 30, 0);
		g.drawImage(AvMain.mimgWanted2[9], x + 30 + 30 + 30, y + 30 + 30, 0);
		g.drawImage(AvMain.mimgWanted2[10], x + 30, y + 30 + 30 + 30, 0);
		g.drawImage(AvMain.mimgWanted2[11], x + 30 + 30, y + 30 + 30 + 30, 0);
		g.drawImage(AvMain.mimgWanted2[8], x + 30 + 30 + 30, y + 30 + 30 + 30, 0);
		g.drawImage(AvMain.mimgWanted2[11], x + 30, y + 30 + 30 + 30 + 30, 0);
		g.drawImage(AvMain.mimgWanted2[8], x + 30 + 30, y + 30 + 30 + 30 + 30, 0);
		g.drawImage(AvMain.mimgWanted2[9], x + 30 + 30 + 30, y + 30 + 30 + 30 + 30, 0);
		g.drawImage(AvMain.mimgWanted2[7], x, y, 0);
		g.drawImage(AvMain.mimgWanted2[5], x, y + h - 30, 0);
		g.drawImage(AvMain.mimgWanted2[6], x + w - 30, y, 0);
		g.drawImage(AvMain.mimgWanted2[4], x + w - 30, y + h - 30, 0);
		g.drawImage(AvMain.mimgWanted2[22], x + 30, y, 0);
		g.drawImage(AvMain.mimgWanted2[23], x + 30 + 30, y, 0);
		g.drawImage(AvMain.mimgWanted2[24], x + 30 + 30 + 15, y, 0);
		g.drawImage(AvMain.mimgWanted2[25], x + 30 + 30 + 15 + 15, y, 0);
		g.drawImage(AvMain.mimgWanted2[17], x, y + 30, 0);
		g.drawImage(AvMain.mimgWanted2[18], x, y + 30 + 30, 0);
		g.drawImage(AvMain.mimgWanted2[19], x, y + 30 + 30 + 15, 0);
		g.drawImage(AvMain.mimgWanted2[20], x, y + 30 + 30 + 15 + 15, 0);
		g.drawImage(AvMain.mimgWanted2[21], x, y + 30 + 30 + 15 + 15 + 15, 0);
		g.drawImage(AvMain.mimgWanted2[21], x, y + 30 + 30 + 15 + 15 + 15 + 15, 0);
		g.drawImage(AvMain.mimgWanted2[0], x + 30, y + h - 30, 0);
		g.drawImage(AvMain.mimgWanted2[1], x + 30 + 30, y + h - 30, 0);
		g.drawImage(AvMain.mimgWanted2[2], x + 30 + 30 + 15, y + h - 30, 0);
		g.drawImage(AvMain.mimgWanted2[3], x + 30 + 30 + 15 + 15, y + h - 30, 0);
		g.drawImage(AvMain.mimgWanted2[12], x + w - 30, y + 30, 0);
		g.drawImage(AvMain.mimgWanted2[13], x + w - 30, y + 30 + 30, 0);
		g.drawImage(AvMain.mimgWanted2[14], x + w - 30, y + 30 + 30 + 15, 0);
		g.drawImage(AvMain.mimgWanted2[15], x + w - 30, y + 30 + 30 + 15 + 15, 0);
		g.drawImage(AvMain.mimgWanted2[15], x + w - 30, y + 30 + 30 + 15 + 15 + 15, 0);
		g.drawImage(AvMain.mimgWanted2[15], x + w - 30, y + 30 + 30 + 15 + 15 + 15 + 15, 0);
		g.drawImage(AvMain.mimgWanted2[26], x + w / 2, y + 20, 3);
		g.drawImage(AvMain.mimgWanted2[27], x + w / 2, y + 15 + 20, 3);
		g.drawImage(AvMain.mimgWanted2[27], x + w / 2, y + h - 15, 3);
		g.drawImage(AvMain.mimgWanted2[28], x + w / 2, y + 100, 3);
	}

	// Token: 0x0600003C RID: 60 RVA: 0x0000FAC4 File Offset: 0x0000DCC4
	public static void paintBG_Wanted(mGraphics g, int x, int y, int w, int h, int type)
	{
		int num = w;
		bool flag = AvMain.mimgWanted == null;
		if (flag)
		{
			num = 0;
		}
		switch (type)
		{
		case 0:
			AvMain.paintBG_Left_Right_Wanted(g, x - 14, y - 6, w, h, 0);
			AvMain.paintBG_Left_Right_Wanted(g, x - 8, y - 3, w, h, 0);
			break;
		case 1:
			AvMain.paintBG_Left_Right_Wanted(g, x + num + 14, y + 6, w, h, 1);
			AvMain.paintBG_Left_Right_Wanted(g, x + num + 8, y + 3, w, h, 1);
			break;
		case 2:
			AvMain.paintBG_Left_Right_Wanted(g, x - 8, y - 3, w, h, 0);
			AvMain.paintBG_Left_Right_Wanted(g, x + num + 8, y + 3, w, h, 1);
			break;
		}
		bool flag2 = AvMain.mimgWanted == null;
		if (flag2)
		{
			bool flag3 = GameMidlet.DEVICE > 0;
			if (flag3)
			{
				AvMain.paintBG_WantedFull(g, x, y);
			}
			else
			{
				AvMain.paintBG_AChi_Low(g, x, y, w, h, 5);
				AvMain.FontBorderColor(g, T.wanted, x + w / 2, y + GameCanvas.hCommand / 4, 2, 0, 7);
				g.setColor(9530962);
				g.fillRect(x + 16, y + 24, w - 32, 62);
				g.fillRect(x + 16, y + 98, w - 32, 20);
				g.drawImage(AvMain.imgBeri, x + 20, y + 130, 3);
			}
		}
		else
		{
			int num2 = 0;
			int num3 = 0;
			int num4 = 38;
			int num5 = 53;
			g.setColor(14402719);
			g.fillRect(x + 10, y + 10, w - 20, h - 20);
			g.drawImage(AvMain.mimgWanted[num2 + num3], x, y, 0);
			g.drawImage(AvMain.mimgWanted[2 + num2 + num3], x + w - 15, y, 0);
			int num6 = (w - 30) / num4;
			for (int i = 0; i <= num6; i++)
			{
				bool flag4 = i == num6;
				if (flag4)
				{
					g.drawImage(AvMain.mimgWanted[1 + num2 + num3], x + w - num5, y, 0);
					g.drawImage(AvMain.mimgWanted[7 + num2], x + w - num5, y + h - 15, 0);
				}
				else
				{
					g.drawImage(AvMain.mimgWanted[1 + num2 + num3], x + 15 + i * num4, y, 0);
					g.drawImage(AvMain.mimgWanted[7 + num2], x + 15 + i * num4, y + h - 15, 0);
				}
			}
			int num7 = (h - 30) / 40;
			for (int j = 0; j <= num7; j++)
			{
				bool flag5 = j == num7;
				if (flag5)
				{
					g.drawImage(AvMain.mimgWanted[3 + num2], x, y + h - 55, 0);
					g.drawImage(AvMain.mimgWanted[5 + num2], x + w - 15, y + h - 55, 0);
				}
				else
				{
					g.drawImage(AvMain.mimgWanted[3 + num2], x, y + 15 + j * 40, 0);
					g.drawImage(AvMain.mimgWanted[5 + num2], x + w - 15, y + 15 + j * 40, 0);
				}
			}
			g.drawImage(AvMain.mimgWanted[4 + num2], x, y + h - 15, 0);
			g.drawImage(AvMain.mimgWanted[6 + num2], x + w - 15, y + h - 15, 0);
			g.drawImage(AvMain.mimgWanted[12], x + w / 2, y + 12, 3);
			g.setColor(13019772);
			g.fillRect(x + 15, y + 22, w - 30, 66);
			g.fillRect(x + 15, y + 100, w - 32, 16);
			g.setColor(10781286);
			g.fillRect(x + 16, y + 23, w - 30, 64);
			g.fillRect(x + 16, y + 101, w - 32, 14);
			g.drawImage(AvMain.mimgWanted[13], x + w / 2, y + 94, 3);
			g.drawImage(AvMain.mimgWanted[14], x + 23, y + 130, 3);
			g.drawImage(AvMain.mimgWanted[16], x + 7, y + 93, 0);
			g.drawRegion(AvMain.mimgWanted[16], 0, 0, 6, 46, 2, (float)(x + w - 13), (float)(y + 93), 0);
			g.drawImage(AvMain.mimgWanted[15], x + 102, y + 145, 3);
			g.drawImage(AvMain.mimgWanted[17], x + 48, y + 144, 3);
		}
	}

	// Token: 0x0600003D RID: 61 RVA: 0x0000FF44 File Offset: 0x0000E144
	public static void paintBG_Left_Right_Wanted(mGraphics g, int x, int y, int w, int h, int type)
	{
		h = 154;
		bool lowGraphic = GameCanvas.lowGraphic;
		if (lowGraphic)
		{
			AvMain.paintBG_AChi_Low(g, x, y, w, h, 5);
		}
		else
		{
			bool flag = AvMain.mimgWanted == null;
			if (flag)
			{
				bool flag2 = GameMidlet.DEVICE > 0;
				if (flag2)
				{
					AvMain.paintBG_WantedFull(g, x, y);
				}
			}
			else
			{
				int num = 0;
				int num2 = 0;
				int num3 = x;
				int num4 = h;
				int num5 = 38;
				int num6 = 53;
				bool flag3 = type == 0;
				if (flag3)
				{
					g.drawImage(AvMain.mimgWanted[num + num2], num3, y, 0);
					g.drawImage(AvMain.mimgWanted[4 + num], num3, y + num4 - 15, 0);
					g.drawImage(AvMain.mimgWanted[2 + num], num3 + w - 15, y, 0);
				}
				else
				{
					num3 = x - 15;
					g.drawImage(AvMain.mimgWanted[2 + num + num2], num3, y, 0);
					g.drawImage(AvMain.mimgWanted[6 + num], num3, y + num4 - 15, 0);
					g.drawImage(AvMain.mimgWanted[4 + num], num3 - w + 15, y + num4 - 15, 0);
				}
				int num7 = (w - 30) / num5;
				for (int i = 0; i <= num7; i++)
				{
					bool flag4 = type == 0;
					if (flag4)
					{
						bool flag5 = i == num7;
						if (flag5)
						{
							g.drawImage(AvMain.mimgWanted[1 + num], num3 + w - num6, y, 0);
						}
						else
						{
							g.drawImage(AvMain.mimgWanted[1 + num], num3 + 15 + i * num5, y, 0);
						}
					}
					else
					{
						bool flag6 = i == num7;
						if (flag6)
						{
							g.drawImage(AvMain.mimgWanted[7 + num], num3 - w + 30, y + num4 - 15, 0);
						}
						else
						{
							g.drawImage(AvMain.mimgWanted[7 + num], num3 - 38 - i * num5, y + num4 - 15, 0);
						}
					}
				}
				int num8 = (num4 - 30) / 40;
				for (int j = 0; j <= num8; j++)
				{
					bool flag7 = j == num8;
					if (flag7)
					{
						bool flag8 = type == 0;
						if (flag8)
						{
							g.drawImage(AvMain.mimgWanted[3 + num], num3, y + num4 - 55, 0);
						}
						else
						{
							g.drawImage(AvMain.mimgWanted[5 + num], num3, y + num4 - 55, 0);
						}
					}
					else
					{
						bool flag9 = type == 0;
						if (flag9)
						{
							g.drawImage(AvMain.mimgWanted[3 + num], num3, y + 15 + j * 40, 0);
						}
						else
						{
							g.drawImage(AvMain.mimgWanted[5 + num], num3, y + 15 + j * 40, 0);
						}
					}
				}
			}
		}
	}

	// Token: 0x0600003E RID: 62 RVA: 0x000090B8 File Offset: 0x000072B8
	public void paintRectNice(mGraphics g, int x, int y, int w, int h, sbyte indexType)
	{
		g.setColor(4521779);
		g.fillRect(x, y, w, h);
	}

	// Token: 0x0600003F RID: 63 RVA: 0x000090D4 File Offset: 0x000072D4
	public static void paintRectLowGraphic(mGraphics g, int x, int y, int w, int h, int indexColor)
	{
		g.setColor(16446420);
		g.fillRect(x, y, w, h);
		g.setColor(AvMain.colorLow[indexColor]);
		g.fillRect(x + 1, y + 1, w - 2, h - 2);
	}

	// Token: 0x06000040 RID: 64 RVA: 0x00009112 File Offset: 0x00007312
	public static void Font3dWhite(mGraphics g, string str, int x, int y, int ar)
	{
		mFont.tahoma_7b_black.drawString(g, str, x + 1, y + 1, ar);
		mFont.tahoma_7b_white.drawString(g, str, x, y, ar);
	}

	// Token: 0x06000041 RID: 65 RVA: 0x0000913B File Offset: 0x0000733B
	public static void Font3dColor(mGraphics g, string str, int x, int y, int ar, sbyte color)
	{
		mFont.tahoma_7b_black.drawString(g, str, x + 1, y + 1, ar);
		AvMain.setTextColorName((int)color).drawString(g, str, x, y, ar);
	}

	// Token: 0x06000042 RID: 66 RVA: 0x00009166 File Offset: 0x00007366
	public static void Font3dSmall(mGraphics g, string str, int x, int y, int ar, sbyte color)
	{
		mFont.tahoma_7_black.drawString(g, str, x + 1, y + 1, ar);
		AvMain.setTextColor((int)color).drawString(g, str, x, y, ar);
	}

	// Token: 0x06000043 RID: 67 RVA: 0x00009191 File Offset: 0x00007391
	public static void Font3dColor(mGraphics g, string str, int x, int y, int ar, sbyte colorShadow, sbyte colorFont)
	{
		AvMain.setTextColorName((int)colorShadow).drawString(g, str, x + 1, y + 1, ar);
		AvMain.setTextColorName((int)colorFont).drawString(g, str, x, y, ar);
	}

	// Token: 0x06000044 RID: 68 RVA: 0x000091BE File Offset: 0x000073BE
	public virtual void paintSelect(mGraphics g, int x, int y, int w, int h)
	{
		g.setColor(16774758);
		g.fillRect(x, y, w, h);
	}

	// Token: 0x06000045 RID: 69 RVA: 0x000101F0 File Offset: 0x0000E3F0
	public static mFont setTextColor(int id)
	{
		if (!true)
		{
		}
		mFont result;
		switch (id)
		{
		case 0:
			result = mFont.tahoma_7_white;
			break;
		case 1:
			result = mFont.tahoma_7_green;
			break;
		case 2:
			result = mFont.tahoma_7_violet;
			break;
		case 3:
			result = mFont.tahoma_7_orange;
			break;
		case 4:
			result = mFont.tahoma_7_blue;
			break;
		case 5:
			result = mFont.tahoma_7_yellow;
			break;
		case 6:
			result = mFont.tahoma_7_red;
			break;
		case 7:
			result = mFont.tahoma_7_black;
			break;
		default:
			result = mFont.tahoma_7_white;
			break;
		}
		if (!true)
		{
		}
		return result;
	}

	// Token: 0x06000046 RID: 70 RVA: 0x0001027C File Offset: 0x0000E47C
	public static mFont setTextColorName(int id)
	{
		if (!true)
		{
		}
		mFont result;
		switch (id)
		{
		case 0:
			result = mFont.tahoma_7b_white;
			break;
		case 1:
			result = mFont.tahoma_7b_green;
			break;
		case 2:
			result = mFont.tahoma_7b_violet;
			break;
		case 3:
			result = mFont.tahoma_7b_orange;
			break;
		case 4:
			result = mFont.tahoma_7b_blue;
			break;
		case 5:
			result = mFont.tahoma_7b_yellow;
			break;
		case 6:
			result = mFont.tahoma_7b_red;
			break;
		case 7:
			result = mFont.tahoma_7b_black;
			break;
		case 8:
			result = mFont.tahoma_7b_brown;
			break;
		default:
			result = mFont.tahoma_7b_white;
			break;
		}
		if (!true)
		{
		}
		return result;
	}

	// Token: 0x06000047 RID: 71 RVA: 0x00010314 File Offset: 0x0000E514
	public void paintPaper(mGraphics g, int x, int y, int w, int h, int maxw, int type)
	{
		bool lowGraphic = GameCanvas.lowGraphic;
		if (lowGraphic)
		{
			AvMain.paintRect(g, x + 4, y + 4, w - 8, h - 8, 1, 3);
		}
		else
		{
			int color = 16312512;
			bool flag = type == (int)AvMain.PAPER_LAW;
			mImage[] array;
			if (flag)
			{
				bool flag2 = AvMain.imgPaper_Law == null;
				if (flag2)
				{
					this.load_Img_Law();
					return;
				}
				array = AvMain.imgPaper_Law;
				color = 10009570;
			}
			else
			{
				array = AvMain.imgPaper;
			}
			bool flag3 = h % 2 == 0;
			if (flag3)
			{
				h++;
			}
			g.setColor(color);
			g.fillRect(x, y + 5, w, h - 10);
			int num = 15;
			int num2 = w / 2 - 15;
			bool flag4 = num2 < 0;
			if (flag4)
			{
				num2 = 0;
			}
			for (int i = 0; i <= num2; i += 30)
			{
				g.drawImage(array[5], x + w / 2 + i - 15, y + 3, 0);
				g.drawImage(array[6], x + w / 2 + i - 15, y + h - 1 - 8, 0);
				bool flag5 = i != 0;
				if (flag5)
				{
					g.drawImage(array[5], x + w / 2 - i - 15, y + 3, 0);
					g.drawImage(array[6], x + w / 2 - i - 15, y + h - 1 - 8, 0);
				}
				num = i + 15;
			}
			int num3 = (w / 2 - 15) % 30;
			bool flag6 = num3 != 0 && num3 > 0;
			if (flag6)
			{
				g.drawRegion(array[5], 0, 0, num3, 8, 0, (float)(x + w / 2 + num), (float)(y + 3), 0);
				g.drawRegion(array[6], 0, 0, num3, 8, 0, (float)(x + w / 2 + num), (float)(y + h - 1 - 8), 0);
				g.drawRegion(array[5], 0, 0, num3, 8, 0, (float)(x + w / 2 - num - num3), (float)(y + 3), 0);
				g.drawRegion(array[6], 0, 0, num3, 8, 0, (float)(x + w / 2 - num - num3), (float)(y + h - 1 - 8), 0);
			}
			bool flag7 = w >= 20;
			if (flag7)
			{
				for (int j = 0; j < h - 38; j += 10)
				{
					g.drawRegion(array[7], 0, 0, 8, 10, 2, (float)(x + w), (float)(y + 19 + j), mGraphics.RIGHT | mGraphics.TOP);
				}
				g.drawRegion(array[3], 0, 0, 8, 16, 2, (float)(x + w), (float)(y + 3), mGraphics.RIGHT | mGraphics.TOP);
				g.drawRegion(array[4], 0, 0, 8, 17, 2, (float)(x + w), (float)(y + h - 2 - 16), mGraphics.RIGHT | mGraphics.TOP);
			}
			bool flag8 = w >= 20;
			if (flag8)
			{
				for (int k = 0; k < h - 37; k += 10)
				{
					g.drawImage(array[7], x, y + 19 + k, 0);
				}
				g.drawImage(array[3], x, y + 3, 0);
				g.drawImage(array[4], x, y + h - 2 - 16, 0);
			}
			for (int l = 0; l < h - 37; l += 10)
			{
				g.drawRegion(array[1], 0, 0, 14, 10, 2, (float)(x + w + 14), (float)(y + 19 + l), mGraphics.RIGHT | mGraphics.TOP);
			}
			g.drawRegion(array[0], 0, 0, 14, 19, 2, (float)(x + w + 14), (float)y, mGraphics.RIGHT | mGraphics.TOP);
			g.drawRegion(array[2], 0, 0, 14, 19, 2, (float)(x + w + 14), (float)(y + h - 19), mGraphics.RIGHT | mGraphics.TOP);
			for (int m = 0; m < h - 38; m += 10)
			{
				g.drawImage(array[1], x - 14, y + 19 + m, 0);
			}
			g.drawImage(array[0], x - 14, y, 0);
			g.drawImage(array[2], x - 14, y + h - 19, 0);
		}
	}

	// Token: 0x06000048 RID: 72 RVA: 0x0001072C File Offset: 0x0000E92C
	public void load_Img_Law()
	{
		AvMain.imgPaper_Law = new mImage[8];
		for (int i = 0; i < AvMain.imgPaper_Law.Length; i++)
		{
			AvMain.imgPaper_Law[i] = mImage.createImage("/interface/papern" + i.ToString() + ".png");
		}
		AvMain.imgEff_Law = new mImage[8];
		for (int j = 0; j < AvMain.imgEff_Law.Length; j++)
		{
			AvMain.imgEff_Law[j] = mImage.createImage("/interface/law" + j.ToString() + ".png");
		}
	}

	// Token: 0x06000049 RID: 73 RVA: 0x000107C4 File Offset: 0x0000E9C4
	public void paintPaper_UpDown(mGraphics g, int x, int y, int w, int h, int maxw)
	{
		bool flag = AvMain.imgPaperDoc == null;
		if (flag)
		{
			this.paintPaper(g, x, y - 4, w, h + 4, maxw, (int)AvMain.PAPER_NORMAL);
		}
		else
		{
			bool flag2 = w % 2 == 0;
			if (flag2)
			{
				w++;
			}
			for (int i = 0; i < w - 38; i += 10)
			{
				g.drawRegion(AvMain.imgPaperDoc[1], 0, 0, 10, 14, 0, (float)(x - 2 + 19 + i), (float)(y + 9), mGraphics.LEFT | mGraphics.BOTTOM);
			}
			g.drawRegion(AvMain.imgPaperDoc[2], 0, 0, 19, 14, 0, (float)(x - 1), (float)(y + 9), mGraphics.LEFT | mGraphics.BOTTOM);
			g.drawRegion(AvMain.imgPaperDoc[2], 0, 0, 19, 14, 2, (float)(x - 2 + w - 19), (float)(y + 9), mGraphics.LEFT | mGraphics.BOTTOM);
			g.setColor(16312512);
			g.fillRect(x + 5, y, w - 10, h);
			int num = 15;
			int num2 = h / 2 - 15;
			bool flag3 = num2 < 0;
			if (flag3)
			{
				num2 = 0;
			}
			for (int j = 0; j <= num2; j += 30)
			{
				g.drawRegion(AvMain.imgPaperDoc[6], 0, 0, 8, 30, 0, (float)(x + 3), (float)(y + h / 2 + j - 15), 0);
				g.drawRegion(AvMain.imgPaperDoc[6], 0, 0, 8, 30, 2, (float)(x + w - 1 - 8), (float)(y + h / 2 + j - 15), 0);
				bool flag4 = j != 0;
				if (flag4)
				{
					g.drawRegion(AvMain.imgPaperDoc[6], 0, 0, 8, 30, 0, (float)(x + 3), (float)(y + h / 2 - j - 15), 0);
					g.drawRegion(AvMain.imgPaperDoc[6], 0, 0, 8, 30, 2, (float)(x + w - 1 - 8), (float)(y + h / 2 - j - 15), 0);
				}
				num = j + 15;
			}
			int num3 = (h / 2 - 15) % 30;
			bool flag5 = num3 != 0 && num3 > 0;
			if (flag5)
			{
				g.drawRegion(AvMain.imgPaperDoc[6], 0, 0, 8, num3, 0, (float)(x + 3), (float)(y + h / 2 + num), 0);
				g.drawRegion(AvMain.imgPaperDoc[6], 0, 0, 8, num3, 2, (float)(x + w - 1 - 8), (float)(y + h / 2 + num), 0);
				g.drawRegion(AvMain.imgPaperDoc[6], 0, 0, 8, num3, 0, (float)(x + 3), (float)(y + h / 2 - num - num3), 0);
				g.drawRegion(AvMain.imgPaperDoc[6], 0, 0, 8, num3, 2, (float)(x + w - 1 - 8), (float)(y + h / 2 - num - num3), 0);
			}
			bool flag6 = h >= 20;
			if (flag6)
			{
				for (int k = 0; k < w - 38; k += 10)
				{
					g.drawRegion(AvMain.imgPaperDoc[7], 0, 0, 10, 8, 0, (float)(x + 19 + k), (float)y, 0);
				}
				g.drawRegion(AvMain.imgPaperDoc[4], 0, 0, 17, 8, 0, (float)(x + 3), (float)y, 0);
				g.drawRegion(AvMain.imgPaperDoc[4], 0, 0, 17, 8, 2, (float)(x + w - 2 - 16), (float)y, 0);
			}
			bool flag7 = h >= 20;
			if (flag7)
			{
				for (int l = 0; l < w - 38; l += 10)
				{
					g.drawRegion(AvMain.imgPaperDoc[7], 0, 0, 10, 8, 1, (float)(x + 19 + l), (float)(y + h), mGraphics.LEFT | mGraphics.BOTTOM);
				}
				g.drawRegion(AvMain.imgPaperDoc[4], 0, 0, 17, 8, 1, (float)(x + 3), (float)(y + h), mGraphics.LEFT | mGraphics.BOTTOM);
				g.drawRegion(AvMain.imgPaperDoc[4], 0, 0, 17, 8, 3, (float)(x + w - 2 - 16), (float)(y + h), mGraphics.LEFT | mGraphics.BOTTOM);
			}
			for (int m = 0; m < w - 38; m += 10)
			{
				g.drawRegion(AvMain.imgPaperDoc[1], 0, 0, 10, 14, 1, (float)(x + 2 + 19 + m), (float)(y + h), 0);
			}
			g.drawRegion(AvMain.imgPaperDoc[2], 0, 0, 19, 14, 1, (float)(x + 2), (float)(y + h), 0);
			g.drawRegion(AvMain.imgPaperDoc[2], 0, 0, 19, 14, 3, (float)(x + 2 + w - 19), (float)(y + h), 0);
		}
	}

	// Token: 0x0600004A RID: 74 RVA: 0x00010C38 File Offset: 0x0000EE38
	public static string getDotNumber(long m)
	{
		string text = string.Empty;
		bool flag = m < 0L;
		bool flag2 = flag;
		if (flag2)
		{
			m = -m;
		}
		long num = m / 1000L + 1L;
		int num2 = 0;
		while ((long)num2 < num)
		{
			bool flag3 = m >= 1000L;
			if (!flag3)
			{
				text = m.ToString() + text;
				break;
			}
			long num3 = m % 1000L;
			text = ((num3 != 0L) ? ((num3 >= 10L) ? ((num3 >= 100L) ? ("." + num3.ToString() + text) : (".0" + num3.ToString() + text)) : (".00" + num3.ToString() + text)) : (".000" + text));
			m /= 1000L;
			num2++;
		}
		bool flag4 = flag;
		if (flag4)
		{
			text = "-" + text;
		}
		return text;
	}

	// Token: 0x0600004B RID: 75 RVA: 0x00010D3C File Offset: 0x0000EF3C
	public static string getMoneyShortText(long m)
	{
		string empty = string.Empty;
		bool flag = m >= 1000000000L;
		string result;
		if (flag)
		{
			result = (m / 1000000000L).ToString() + "," + (m % 1000000000L / 100000000L).ToString() + "B";
		}
		else
		{
			bool flag2 = m > 1000000L;
			if (flag2)
			{
				result = (m / 1000000L).ToString() + "," + (m % 1000000L / 100000L).ToString() + "M";
			}
			else
			{
				result = AvMain.getDotNumber(m);
			}
		}
		return result;
	}

	// Token: 0x0600004C RID: 76 RVA: 0x00010DF0 File Offset: 0x0000EFF0
	public static void FontBorderColor(mGraphics g, string str, int x, int y, int ar, int color, int colorBorder)
	{
		AvMain.setTextColorName(colorBorder).drawString(g, str, x - 1, y - 1, ar);
		AvMain.setTextColorName(colorBorder).drawString(g, str, x - 1, y + 1, ar);
		AvMain.setTextColorName(colorBorder).drawString(g, str, x + 1, y - 1, ar);
		AvMain.setTextColorName(colorBorder).drawString(g, str, x + 1, y + 1, ar);
		AvMain.setTextColorName(colorBorder).drawString(g, str, x - 1, y, ar);
		AvMain.setTextColorName(colorBorder).drawString(g, str, x + 1, y, ar);
		AvMain.setTextColorName(colorBorder).drawString(g, str, x, y - 1, ar);
		AvMain.setTextColorName(colorBorder).drawString(g, str, x, y + 1, ar);
		AvMain.setTextColorName(color).drawString(g, str, x, y, ar);
	}

	// Token: 0x0600004D RID: 77 RVA: 0x00010EC4 File Offset: 0x0000F0C4
	public static void FontSevenColor(mGraphics g, string str, int x, int y, int ar, int colorBorder)
	{
		bool flag = colorBorder == -1;
		if (flag)
		{
			mFont.tahoma_7b_black.drawString(g, str, x + 1, y + 1, ar);
		}
		else
		{
			bool flag2 = colorBorder >= 0;
			if (flag2)
			{
				AvMain.setTextColorName(colorBorder).drawString(g, str, x - 1, y - 1, ar);
				AvMain.setTextColorName(colorBorder).drawString(g, str, x - 1, y + 1, ar);
				AvMain.setTextColorName(colorBorder).drawString(g, str, x + 1, y - 1, ar);
				AvMain.setTextColorName(colorBorder).drawString(g, str, x + 1, y + 1, ar);
				AvMain.setTextColorName(colorBorder).drawString(g, str, x - 1, y, ar);
				AvMain.setTextColorName(colorBorder).drawString(g, str, x + 1, y, ar);
				AvMain.setTextColorName(colorBorder).drawString(g, str, x, y - 1, ar);
				AvMain.setTextColorName(colorBorder).drawString(g, str, x, y + 1, ar);
			}
		}
		int textColorName = AvMain.mValue7Color[GameCanvas.gameTick / 7 % AvMain.mValue7Color.Length];
		AvMain.setTextColorName(textColorName).drawString(g, str, x, y, ar);
	}

	// Token: 0x0600004E RID: 78 RVA: 0x00010FE0 File Offset: 0x0000F1E0
	public static void FontBorderSmall(mGraphics g, string str, int x, int y, int ar, int color)
	{
		mFont.tahoma_7_black.drawString(g, str, x - 1, y, ar);
		mFont.tahoma_7_black.drawString(g, str, x + 1, y, ar);
		mFont.tahoma_7_black.drawString(g, str, x, y - 1, ar);
		mFont.tahoma_7_black.drawString(g, str, x, y + 1, ar);
		AvMain.setTextColor(color).drawString(g, str, x, y, ar);
	}

	// Token: 0x0600004F RID: 79 RVA: 0x00011050 File Offset: 0x0000F250
	public static void PaintName_Image(mGraphics g, short idIcon, string str, int x, int y, int ar, int color, int colorBorder)
	{
		int num = 0;
		MainImage image = Skill_Info.getImage(idIcon);
		bool flag = image != null && image.img != null;
		if (flag)
		{
			int imageWidth = mImage.getImageWidth(image.img.image);
			if (ar != 1)
			{
				if (ar != 2)
				{
					num = imageWidth + 2;
					g.drawImage(image.img, x, y + 5, mGraphics.VCENTER | mGraphics.LEFT);
				}
				else
				{
					int width = mFont.tahoma_7b_black.getWidth(str);
					num = imageWidth / 2 + 1;
					g.drawImage(image.img, x - width / 2 - 2, y + 5, 3);
				}
			}
			else
			{
				num = -2;
				g.drawImage(image.img, x, y + 5, mGraphics.VCENTER | mGraphics.LEFT);
			}
		}
		AvMain.FontBorderColor(g, str, x + num, y, ar, color, colorBorder);
	}

	// Token: 0x06000050 RID: 80 RVA: 0x00011130 File Offset: 0x0000F330
	public static iCommand setPosCMD(iCommand cmd, int pos)
	{
		switch (pos)
		{
		case 0:
			cmd.setPos(MotherCanvas.hw, MotherCanvas.h - iCommand.hButtonCmdNor / 2 + 2, null, cmd.caption);
			break;
		case 1:
		{
			bool isTaiTho = GameCanvas.isTaiTho;
			if (isTaiTho)
			{
				cmd.setPos(GameCanvas.wCommand - 3 + 5, MotherCanvas.h - iCommand.hButtonCmdNor / 2 + 2, null, cmd.caption);
			}
			else
			{
				cmd.setPos(GameCanvas.wCommand - 3, MotherCanvas.h - iCommand.hButtonCmdNor / 2 + 2, null, cmd.caption);
			}
			break;
		}
		case 2:
		{
			bool isTaiTho2 = GameCanvas.isTaiTho;
			if (isTaiTho2)
			{
				cmd.setPos(MotherCanvas.w - GameCanvas.wCommand + 3 - 5, MotherCanvas.h - iCommand.hButtonCmdNor / 2 + 2, null, cmd.caption);
			}
			else
			{
				cmd.setPos(MotherCanvas.w - GameCanvas.wCommand + 3, MotherCanvas.h - iCommand.hButtonCmdNor / 2 + 2, null, cmd.caption);
			}
			break;
		}
		}
		return cmd;
	}

	// Token: 0x06000051 RID: 81 RVA: 0x0001124C File Offset: 0x0000F44C
	public void paintWantedPaper(mGraphics g, int x, int y, int width, int height)
	{
		g.translate(x, y);
		int num = 0;
		int num2 = 0;
		int num3 = width - 30;
		int num4 = height - 30;
		int num5 = 0;
		for (int i = num2 + 30; i < num4; i += 30)
		{
			for (int j = num + 30; j < num3; j += 30)
			{
				g.drawImage(AvMain.imgGiua[num5], j, i, 0);
				num5++;
				bool flag = num5 >= AvMain.imgGiua.Length;
				if (flag)
				{
					num5 = 0;
				}
			}
		}
		num5 = 0;
		int k = num + 30;
		while (k < num3)
		{
			g.drawImage(AvMain.imgDuoi[num5], k, num4, 0);
			g.drawImage(AvMain.imgTren[num5], k, num2, 0);
			k += mImage.getImageWidth(AvMain.imgTren[num5].image);
			num5++;
			bool flag2 = num5 >= AvMain.imgTren.Length;
			if (flag2)
			{
				num5 = 0;
			}
		}
		num5 = 0;
		int l = num2 + 30;
		while (l < num4)
		{
			g.drawImage(AvMain.imgTrai[num5], num, l, 0);
			g.drawImage(AvMain.imgPhai[num5], num3, l, 0);
			l += mImage.getImageHeight(AvMain.imgTrai[num5].image);
			num5++;
			bool flag3 = num5 >= AvMain.imgTrai.Length;
			if (flag3)
			{
				num5 = 0;
			}
		}
		g.drawImage(AvMain.imgGoc[3], num3, num4, 0);
		g.drawImage(AvMain.imgGoc[2], num, num4, 0);
		g.drawImage(AvMain.imgGoc[1], num3, num2, 0);
		g.drawImage(AvMain.imgGoc[0], num, num2, 0);
		g.translate(-x, -y);
	}

	// Token: 0x06000052 RID: 82 RVA: 0x00011418 File Offset: 0x0000F618
	public void paintBgDialogTrangTri(mGraphics g, int x, int y, int width, int height)
	{
		g.translate(x, y);
		int num = 0;
		int num2 = 0;
		int num3 = width - 25;
		int num4 = height - 25;
		for (int i = num + 25; i < num3; i += 25)
		{
			g.drawImage(AvMain.imgDialogTrangTri[6], i, num4, 0);
			g.drawImage(AvMain.imgDialogTrangTri[1], i, num2, 0);
		}
		for (int j = num2 + 25; j < num4; j += 25)
		{
			g.drawImage(AvMain.imgDialogTrangTri[3], num, j, 0);
			g.drawImage(AvMain.imgDialogTrangTri[4], num3, j, 0);
		}
		g.drawImage(AvMain.imgDialogTrangTri[7], num3, num4, 0);
		g.drawImage(AvMain.imgDialogTrangTri[5], num, num4, 0);
		g.drawImage(AvMain.imgDialogTrangTri[2], num3, num2, 0);
		g.drawImage(AvMain.imgDialogTrangTri[0], num, num2, 0);
		num = 20;
		num2 = 20;
		num3 = width - 20;
		num4 = height - 20;
		g.setClip(num, num2, num3 - num, num4 - num2);
		g.saveCanvas();
		g.ClipRec(num, num2, num3 - num, num4 - num2);
		for (int k = num2; k < num4; k += 36)
		{
			for (int l = num; l < num3; l += 36)
			{
				g.drawImage(AvMain.imgDialogTrangTri[8], l, k, 0);
			}
		}
		g.restoreCanvas();
		GameCanvas.resetTrans(g);
		g.translate(x, y);
		num = 25;
		num2 = 25;
		num3 = width - 25 - 40;
		num4 = height - 25 - 40;
		for (int m = num + 40; m < num3; m += 40)
		{
			g.drawImage(AvMain.imgDialogTrangTri[15], m, num4, 0);
			g.drawImage(AvMain.imgDialogTrangTri[10], m, num2, 0);
		}
		for (int n = num2 + 40; n < num4; n += 40)
		{
			g.drawImage(AvMain.imgDialogTrangTri[12], num, n, 0);
			g.drawImage(AvMain.imgDialogTrangTri[13], num3, n, 0);
		}
		g.drawImage(AvMain.imgDialogTrangTri[16], num3, num4, 0);
		g.drawImage(AvMain.imgDialogTrangTri[14], num, num4, 0);
		g.drawImage(AvMain.imgDialogTrangTri[11], num3, num2, 0);
		g.drawImage(AvMain.imgDialogTrangTri[9], num, num2, 0);
		g.translate(-x, -y);
	}

	// Token: 0x06000053 RID: 83 RVA: 0x00011688 File Offset: 0x0000F888
	public void paintBgMemListPhatLenh(mGraphics g, int x, int y, int w, int h)
	{
		g.drawRegion(AvMain.imgKhungMem, 0, 0, 10, 10, 0, (float)x, (float)y, 0);
		g.drawRegion(AvMain.imgKhungMem, 0, 0, 10, 10, 2, (float)(x + w - 10), (float)y, 0);
		g.drawRegion(AvMain.imgKhungMem, 0, 0, 10, 10, 1, (float)x, (float)(y + h - 10), 0);
		g.drawRegion(AvMain.imgKhungMem, 0, 0, 10, 10, 7, (float)(x + w - 10), (float)(y + h - 10), 0);
		g.setColor(14203529);
		g.fillRect(x + 10, y, w - 20, h);
		g.fillRect(x, y + 10, w, h - 20);
	}

	// Token: 0x06000054 RID: 84 RVA: 0x00011740 File Offset: 0x0000F940
	public static void paintBg_WantedList(mGraphics g, int x, int y, int w, int h, int type, int wCmd)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 36;
		int num4 = 72;
		if (type != 1)
		{
			if (type == 2)
			{
				num2 = 19;
				num3 = 32;
				num4 = 68;
			}
		}
		else
		{
			num2 = 22;
			num3 = 32;
			num4 = 68;
		}
		int num5 = x - wCmd / 2;
		int num6 = w + wCmd;
		g.drawImage(AvMain.mimgBgA[num + num2], num5, y, 0);
		g.drawImage(AvMain.mimgBgA[2 + num + num2], num5 + num6 - 36, y, 0);
		int num7 = (num6 - 73) / num3 + 1;
		for (int i = 0; i <= num7; i++)
		{
			bool flag = i == num7;
			if (flag)
			{
				g.drawImage(AvMain.mimgBgA[1 + num + num2], num5 + num6 - num4, y, 0);
			}
			else
			{
				g.drawImage(AvMain.mimgBgA[1 + num + num2], num5 + num3 + i * num3, y, 0);
			}
		}
		num7 = (num6 - 73) / 36 + 1;
		for (int j = 0; j < num7; j++)
		{
			bool flag2 = j == num7 - 1;
			if (flag2)
			{
				g.drawImage(AvMain.mimgBgA[7 + num], num5 + num6 - 72, y + h - 38, 0);
			}
			else
			{
				g.drawImage(AvMain.mimgBgA[7 + num], num5 + 36 + j * 36, y + h - 38, 0);
			}
		}
		int num8 = (h - 36 - 39) / 38 + 1;
		for (int k = 0; k < num8; k++)
		{
			g.drawImage(AvMain.mimgBgA[3 + num], num5 + 4, y + 36 + k * 38, 0);
			g.drawImage(AvMain.mimgBgA[5 + num], num5 + num6 - 4 - 36, y + 36 + k * 38, 0);
			for (int l = num5 + 4 + 36; l <= x + 12 + wCmd / 2; l += 36)
			{
				g.drawImage(AvMain.mimgBgA[25], l, y + 36 + k * 38, 0);
			}
		}
		g.drawImage(AvMain.mimgBgA[4 + num], num5 + 4, y + h - 38, 0);
		g.drawImage(AvMain.mimgBgA[6 + num], num5 + num6 - 36 - 4, y + h - 38, 0);
		num5 = num5 + 4 + 10;
		int num9 = y + 22 + 2;
		int num10 = h - 30 - 2;
		num6 = x + 12 + wCmd / 2 - num5 - 10;
		g.drawRegion(AvMain.imgKhung[1], 0, 0, 20, 20, 0, (float)num5, (float)num9, 0);
		g.drawRegion(AvMain.imgKhung[1], 0, 0, 20, 20, 2, (float)(num5 + num6 - 20), (float)num9, 0);
		g.drawRegion(AvMain.imgKhung[1], 0, 0, 20, 20, 1, (float)num5, (float)(num9 + num10 - 20), 0);
		g.drawRegion(AvMain.imgKhung[1], 0, 0, 20, 20, 7, (float)(num5 + num6 - 20), (float)(num9 + num10 - 20), 0);
		g.setColor(9393716);
		g.fillRect(num5 + 20, num9, num6 - 40, num10);
		g.fillRect(num5, num9 + 20, num6, num10 - 40);
		num5 += 5;
		num9 += 13;
		for (int m = num9; m < num9 + num10 - 20; m += 30)
		{
			g.drawRegion(AvMain.imgKhung[0], 0, 0, 79, 22, 0, (float)num5, (float)m, 0);
		}
		num = 8;
		num5 = x + 12 + wCmd / 2;
		num9 = y + 22;
		bool flag3 = type == 2;
		if (flag3)
		{
			num9 = y + 26;
		}
		num10 = h - 30;
		num6 = w - 24;
		g.drawImage(AvMain.mimgBgA[num], num5, num9, 0);
		g.drawImage(AvMain.mimgBgA[2 + num], num5 + num6 - 36, num9, 0);
		num7 = (num6 - 73) / 36 + 1;
		for (int n = 0; n < num7; n++)
		{
			bool flag4 = n == num7 - 1;
			if (flag4)
			{
				g.drawImage(AvMain.mimgBgA[1 + num], num5 + num6 - 72, num9, 0);
				g.drawImage(AvMain.mimgBgA[7 + num], num5 + num6 - 72, num9 + num10 - 36, 0);
			}
			else
			{
				g.drawImage(AvMain.mimgBgA[1 + num], num5 + 36 + n * 36, num9, 0);
				g.drawImage(AvMain.mimgBgA[7 + num], num5 + 36 + n * 36, num9 + num10 - 36, 0);
			}
		}
		num8 = (num10 - 36 - 37) / 36 + 1;
		for (int num11 = 0; num11 < num8; num11++)
		{
			bool flag5 = num11 == num8 - 1;
			if (flag5)
			{
				g.drawImage(AvMain.mimgBgA[3 + num], num5, num9 + num10 - 72, 0);
				g.drawImage(AvMain.mimgBgA[5 + num], num5 + num6 - 36, num9 + num10 - 72, 0);
			}
			else
			{
				g.drawImage(AvMain.mimgBgA[3 + num], num5, num9 + 36 + num11 * 36, 0);
				g.drawImage(AvMain.mimgBgA[5 + num], num5 + num6 - 36, num9 + 36 + num11 * 36, 0);
			}
		}
		g.drawImage(AvMain.mimgBgA[4 + num], num5, num9 + num10 - 36, 0);
		g.drawImage(AvMain.mimgBgA[6 + num], num5 + num6 - 36, num9 + num10 - 36, 0);
		g.setColor(16246726);
		g.fillRect(num5 + 35, num9 + 35, num6 - 70, num10 - 70);
		bool flag6 = type == 0;
		if (flag6)
		{
			g.drawImage(AvMain.mimgBgA[16], x + w / 2 - 84, y - 24, 0);
			g.drawImage(AvMain.mimgBgA[18], x + w / 2 + 84 - 24, y - 24, 0);
			for (int num12 = 0; num12 < 5; num12++)
			{
				g.drawImage(AvMain.mimgBgA[17], x + w / 2 - 84 + 24 + num12 * 24, y - 24, 0);
			}
		}
	}

	// Token: 0x04000012 RID: 18
	public const sbyte COLOR_WHITE = 0;

	// Token: 0x04000013 RID: 19
	public const sbyte COLOR_BLUE = 4;

	// Token: 0x04000014 RID: 20
	public const sbyte COLOR_YELLOW = 5;

	// Token: 0x04000015 RID: 21
	public const sbyte COLOR_VIOLET = 2;

	// Token: 0x04000016 RID: 22
	public const sbyte COLOR_ORANGE = 3;

	// Token: 0x04000017 RID: 23
	public const sbyte COLOR_GREEN = 1;

	// Token: 0x04000018 RID: 24
	public const sbyte COLOR_RED = 6;

	// Token: 0x04000019 RID: 25
	public const sbyte COLOR_BLACK = 7;

	// Token: 0x0400001A RID: 26
	public const sbyte COLOR_BROWN = 8;

	// Token: 0x0400001B RID: 27
	public const sbyte COLOR_RAINBOW = 9;

	// Token: 0x0400001C RID: 28
	public const int LOR_NEN_TIEU_DE = 15972174;

	// Token: 0x0400001D RID: 29
	public const int LOR_FOCUS = 16774758;

	// Token: 0x0400001E RID: 30
	public const int LOR_NEN_TIEU_DE_LAW = 5408452;

	// Token: 0x0400001F RID: 31
	public const sbyte BOR_WHITE = 1;

	// Token: 0x04000020 RID: 32
	public const sbyte BOR_NO = 0;

	// Token: 0x04000021 RID: 33
	public const sbyte BOR_MENU = 2;

	// Token: 0x04000022 RID: 34
	public const sbyte BOR_YELLOW = 3;

	// Token: 0x04000023 RID: 35
	public const sbyte TYPE_ARCHI = 0;

	// Token: 0x04000024 RID: 36
	public const sbyte TYPE_TOP = 1;

	// Token: 0x04000025 RID: 37
	public const sbyte TYPE_PVP = 2;

	// Token: 0x04000026 RID: 38
	public const sbyte TYPE_LEFT_WANTED = 0;

	// Token: 0x04000027 RID: 39
	public const sbyte TYPE_RIGHT_WANTED = 1;

	// Token: 0x04000028 RID: 40
	public const sbyte TYPE_CENTER_WANTED = 2;

	// Token: 0x04000029 RID: 41
	public const sbyte TYPE_CENTER_ONLY = 3;

	// Token: 0x0400002A RID: 42
	public const sbyte POS_LEFT = 1;

	// Token: 0x0400002B RID: 43
	public const sbyte POS_RIGHT = 2;

	// Token: 0x0400002C RID: 44
	public const sbyte POS_CENTER = 0;

	// Token: 0x0400002D RID: 45
	public iCommand left;

	// Token: 0x0400002E RID: 46
	public iCommand right;

	// Token: 0x0400002F RID: 47
	public iCommand center;

	// Token: 0x04000030 RID: 48
	public iCommand backCMD;

	// Token: 0x04000031 RID: 49
	public iCommand menuCMD;

	// Token: 0x04000032 RID: 50
	public iCommand okCMD;

	// Token: 0x04000033 RID: 51
	public static int wimg;

	// Token: 0x04000034 RID: 52
	public static int wWanted = 130;

	// Token: 0x04000035 RID: 53
	public static int hWanted = 154;

	// Token: 0x04000036 RID: 54
	public static mImage imgSelect;

	// Token: 0x04000037 RID: 55
	public static mImage imgHotKey;

	// Token: 0x04000038 RID: 56
	public static mImage imgIconDel;

	// Token: 0x04000039 RID: 57
	public static mImage imgDieChar;

	// Token: 0x0400003A RID: 58
	public static mImage imgDelay;

	// Token: 0x0400003B RID: 59
	public static mImage imgLg;

	// Token: 0x0400003C RID: 60
	public static mImage imgEffCur;

	// Token: 0x0400003D RID: 61
	public static mImage imgBorderNum;

	// Token: 0x0400003E RID: 62
	public static mImage imgMess;

	// Token: 0x0400003F RID: 63
	public static mImage imgEye;

	// Token: 0x04000040 RID: 64
	public static mImage imgXp;

	// Token: 0x04000041 RID: 65
	public static mImage imgUpgrade;

	// Token: 0x04000042 RID: 66
	public static mImage imgJoin;

	// Token: 0x04000043 RID: 67
	public static mImage imgTrade;

	// Token: 0x04000044 RID: 68
	public static mImage imgcheck;

	// Token: 0x04000045 RID: 69
	public static mImage imgTrade2;

	// Token: 0x04000046 RID: 70
	public static mImage imgShadowSmall;

	// Token: 0x04000047 RID: 71
	public static mImage imgChat;

	// Token: 0x04000048 RID: 72
	public static mImage imgCombo;

	// Token: 0x04000049 RID: 73
	public static mImage imgBorderCombo;

	// Token: 0x0400004A RID: 74
	public static mImage imgHand;

	// Token: 0x0400004B RID: 75
	public static mImage imgPvpVs;

	// Token: 0x0400004C RID: 76
	public static mImage imgPvpOk;

	// Token: 0x0400004D RID: 77
	public static mImage imgPvpObjdef;

	// Token: 0x0400004E RID: 78
	public static mImage imgPlus12;

	// Token: 0x0400004F RID: 79
	public static mImage imgPlus12_2;

	// Token: 0x04000050 RID: 80
	public static mImage imgBgnum;

	// Token: 0x04000051 RID: 81
	public static mImage imgNenfocus;

	// Token: 0x04000052 RID: 82
	public static mImage imgBgnum2;

	// Token: 0x04000053 RID: 83
	public static mImage imgDaKham;

	// Token: 0x04000054 RID: 84
	public static mImage imgSafe;

	// Token: 0x04000055 RID: 85
	public static mImage imgTabClan;

	// Token: 0x04000056 RID: 86
	public static mImage imgChatClan;

	// Token: 0x04000057 RID: 87
	public static mImage imgDonateClan;

	// Token: 0x04000058 RID: 88
	public static mImage imgLvClan;

	// Token: 0x04000059 RID: 89
	public static mImage imgBannerClan;

	// Token: 0x0400005A RID: 90
	public static mImage imgPlusClan;

	// Token: 0x0400005B RID: 91
	public static mImage imgTimePvp;

	// Token: 0x0400005C RID: 92
	public static mImage imgTimePvpSmall;

	// Token: 0x0400005D RID: 93
	public static mImage imgBorderIcon;

	// Token: 0x0400005E RID: 94
	public static mImage imgReward;

	// Token: 0x0400005F RID: 95
	public static mImage imgStarMatch;

	// Token: 0x04000060 RID: 96
	public static mImage imgFightMatch;

	// Token: 0x04000061 RID: 97
	public static mImage imgWanted;

	// Token: 0x04000062 RID: 98
	public static mImage imgLock;

	// Token: 0x04000063 RID: 99
	public static mImage imgHinhnhan;

	// Token: 0x04000064 RID: 100
	public static mImage imgLvDevilSkill;

	// Token: 0x04000065 RID: 101
	public static mImage imgBeri;

	// Token: 0x04000066 RID: 102
	public static mImage imgArrowListServer;

	// Token: 0x04000067 RID: 103
	public static mImage imgInfoLock;

	// Token: 0x04000068 RID: 104
	public static mImage imgInfoClass;

	// Token: 0x04000069 RID: 105
	public static mImage imgInfoStar;

	// Token: 0x0400006A RID: 106
	public static mImage imgBannerRuong;

	// Token: 0x0400006B RID: 107
	public static mImage demo;

	// Token: 0x0400006C RID: 108
	public static mImage[] imgPaper;

	// Token: 0x0400006D RID: 109
	public static mImage[] imgButton;

	// Token: 0x0400006E RID: 110
	public static mImage[] mimgBgA;

	// Token: 0x0400006F RID: 111
	public static mImage[] imgPaperDoc;

	// Token: 0x04000070 RID: 112
	public static mImage[] mimgWanted;

	// Token: 0x04000071 RID: 113
	public static mImage[] mimgBgB;

	// Token: 0x04000072 RID: 114
	public static mImage[] mimgBgC;

	// Token: 0x04000073 RID: 115
	public static mImage[] mImgRoomW;

	// Token: 0x04000074 RID: 116
	public static mImage[] mImgDialogVongQuay;

	// Token: 0x04000075 RID: 117
	public static mImage[] mImgThanhTich;

	// Token: 0x04000076 RID: 118
	public static mImage[] imgPaper_Law;

	// Token: 0x04000077 RID: 119
	public static mImage[] imgEff_Law;

	// Token: 0x04000078 RID: 120
	public static mImage[] mimgWanted2;

	// Token: 0x04000079 RID: 121
	public static FrameImage fraPk;

	// Token: 0x0400007A RID: 122
	public static FrameImage fraPk2;

	// Token: 0x0400007B RID: 123
	public static FrameImage fraPirate;

	// Token: 0x0400007C RID: 124
	public static FrameImage fraQuest;

	// Token: 0x0400007D RID: 125
	public static FrameImage fratf;

	// Token: 0x0400007E RID: 126
	public static FrameImage fratf1;

	// Token: 0x0400007F RID: 127
	public static FrameImage fraMoveTo;

	// Token: 0x04000080 RID: 128
	public static FrameImage fraBorder;

	// Token: 0x04000081 RID: 129
	public static FrameImage fraCheck;

	// Token: 0x04000082 RID: 130
	public static FrameImage fraStatusArea;

	// Token: 0x04000083 RID: 131
	public static FrameImage imgLoadImage;

	// Token: 0x04000084 RID: 132
	public static FrameImage fraIconfocus;

	// Token: 0x04000085 RID: 133
	public static FrameImage fraStatusOnline;

	// Token: 0x04000086 RID: 134
	public static FrameImage fraButtonTiemNang;

	// Token: 0x04000087 RID: 135
	public static FrameImage fraTwoTab;

	// Token: 0x04000088 RID: 136
	public static FrameImage fraMoney;

	// Token: 0x04000089 RID: 137
	public static FrameImage fraLevelUp;

	// Token: 0x0400008A RID: 138
	public static FrameImage fraImgEffOnMap0;

	// Token: 0x0400008B RID: 139
	public static FrameImage fraDelay;

	// Token: 0x0400008C RID: 140
	public static FrameImage fraDelay2;

	// Token: 0x0400008D RID: 141
	public static FrameImage fraDiePlayer;

	// Token: 0x0400008E RID: 142
	public static FrameImage fraComboSkill;

	// Token: 0x0400008F RID: 143
	public static FrameImage fraEquip;

	// Token: 0x04000090 RID: 144
	public static FrameImage fraIconNpc;

	// Token: 0x04000091 RID: 145
	public static FrameImage fraShadowFocus;

	// Token: 0x04000092 RID: 146
	public static FrameImage fraEffBoss;

	// Token: 0x04000093 RID: 147
	public static FrameImage fraIconClan;

	// Token: 0x04000094 RID: 148
	public static FrameImage fraBorderClan;

	// Token: 0x04000095 RID: 149
	public static FrameImage fraBorderClan2;

	// Token: 0x04000096 RID: 150
	public static FrameImage fraAutoFire;

	// Token: 0x04000097 RID: 151
	public static FrameImage fraClanLevelUp;

	// Token: 0x04000098 RID: 152
	public static FrameImage fraEffItem;

	// Token: 0x04000099 RID: 153
	public static FrameImage fraEffItem2;

	// Token: 0x0400009A RID: 154
	public static FrameImage fraMatch;

	// Token: 0x0400009B RID: 155
	public static FrameImage fraEventMoon;

	// Token: 0x0400009C RID: 156
	public static FrameImage fraIconMoon;

	// Token: 0x0400009D RID: 157
	public static FrameImage fraIconTop;

	// Token: 0x0400009E RID: 158
	public static FrameImage fraBorderSkill;

	// Token: 0x0400009F RID: 159
	public static FrameImage fraThongThao;

	// Token: 0x040000A0 RID: 160
	public static FrameImage fraNenThongThao;

	// Token: 0x040000A1 RID: 161
	public static FrameImage fraBanhLai;

	// Token: 0x040000A2 RID: 162
	public static FrameImage fraBorderWanted;

	// Token: 0x040000A3 RID: 163
	public static FrameImage fraIconWanted;

	// Token: 0x040000A4 RID: 164
	public static FrameImage fraIconMenu;

	// Token: 0x040000A5 RID: 165
	public static FrameImage fraIconServer;

	// Token: 0x040000A6 RID: 166
	public static FrameImage fraUniform;

	// Token: 0x040000A7 RID: 167
	public static FrameImage fraBtLogin;

	// Token: 0x040000A8 RID: 168
	public static FrameImage fraBtBanhlai;

	// Token: 0x040000A9 RID: 169
	public static FrameImage fraNew;

	// Token: 0x040000AA RID: 170
	public static FrameImage fraIconHome;

	// Token: 0x040000AB RID: 171
	public static FrameImage fraEffOpen;

	// Token: 0x040000AC RID: 172
	public static FrameImage fraEffDasieucap;

	// Token: 0x040000AD RID: 173
	public static FrameImage fraPlus;

	// Token: 0x040000AE RID: 174
	public static FrameImage fraCmdNhanNapThe;

	// Token: 0x040000AF RID: 175
	public static FrameImage fraNauBanh;

	// Token: 0x040000B0 RID: 176
	public static FrameImage fraTrongCay;

	// Token: 0x040000B1 RID: 177
	public static mImage[] imgDuoi;

	// Token: 0x040000B2 RID: 178
	public static mImage[] imgGoc;

	// Token: 0x040000B3 RID: 179
	public static mImage[] imgGiua;

	// Token: 0x040000B4 RID: 180
	public static mImage[] imgPhai;

	// Token: 0x040000B5 RID: 181
	public static mImage[] imgTrai;

	// Token: 0x040000B6 RID: 182
	public static mImage[] imgTren;

	// Token: 0x040000B7 RID: 183
	public static mImage[] imgKhung;

	// Token: 0x040000B8 RID: 184
	public static mImage[] imgDialogTrangTri;

	// Token: 0x040000B9 RID: 185
	public static mImage imgTrangTri;

	// Token: 0x040000BA RID: 186
	public static mImage imgDemoWanted;

	// Token: 0x040000BB RID: 187
	public static mImage imgComplete;

	// Token: 0x040000BC RID: 188
	public static mImage imgKhungItem;

	// Token: 0x040000BD RID: 189
	public static mImage imgKhungMem;

	// Token: 0x040000BE RID: 190
	public static int[][] colorRect = new int[][]
	{
		new int[]
		{
			16298080,
			14190632
		},
		new int[]
		{
			14194752,
			12609544
		},
		new int[]
		{
			10719096,
			8086346
		},
		new int[]
		{
			11506025,
			6966058
		},
		new int[]
		{
			8809550,
			6966058
		},
		new int[]
		{
			15972174,
			14843656
		},
		new int[]
		{
			5982773,
			4731677
		}
	};

	// Token: 0x040000BF RID: 191
	public static int[][] colorButton = new int[][]
	{
		new int[]
		{
			6178867,
			4470312,
			8876379,
			7430736,
			16446420
		},
		new int[]
		{
			9464649,
			6573367,
			12889227,
			11310713,
			16446420
		},
		new int[]
		{
			10318923,
			7032887,
			13744793,
			12231812,
			16446420
		}
	};

	// Token: 0x040000C0 RID: 192
	private static int[] colorLow = new int[]
	{
		14075822,
		10259575,
		7365460,
		8944231,
		4932409,
		13151620
	};

	// Token: 0x040000C1 RID: 193
	public static int[] colorMenu = new int[]
	{
		4724752,
		16300104,
		9998456,
		14733496,
		14203529
	};

	// Token: 0x040000C2 RID: 194
	public static sbyte PAPER_NORMAL = 0;

	// Token: 0x040000C3 RID: 195
	public static sbyte PAPER_LAW = 1;

	// Token: 0x040000C4 RID: 196
	public static int[] mValue7Color = new int[]
	{
		6,
		3,
		5,
		1,
		4,
		0,
		2
	};
}
