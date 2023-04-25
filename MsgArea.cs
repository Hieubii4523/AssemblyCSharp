using System;

// Token: 0x0200009E RID: 158
public class MsgArea : MsgDialog
{
	// Token: 0x060009E1 RID: 2529 RVA: 0x000C7C10 File Offset: 0x000C5E10
	public void setinfoChangeArea(sbyte[] mstatus, sbyte type)
	{
		this.mStatus = mstatus;
		this.typePaintArea = type;
		this.nameDialog = T.Area;
		bool flag = type == 1;
		if (flag)
		{
			this.nameDialog = T.page;
		}
		this.fontDia = mFont.tahoma_7_black;
		base.beginDia();
		this.wShowPaper = 5;
		this.wItem = 30;
		this.hItem = 30;
		this.sizeButton = 24;
		this.sizeBanner = 120;
		this.maxItemW = 5;
		bool flag2 = this.maxItemW > mstatus.Length;
		if (flag2)
		{
			this.maxItemW = mstatus.Length;
		}
		this.list = new ListNew(this.xDia, this.yDia, this.wDia, this.hDia, 0, 0, 0, true);
		this.wDia = this.maxItemW * this.wItem;
		bool flag3 = this.wDia < 120;
		if (flag3)
		{
			this.wDia = 120;
		}
		bool flag4 = this.sizeBanner > this.wDia - 20;
		if (flag4)
		{
			this.sizeBanner = this.wDia - 20;
		}
		this.maxWShow = this.wDia;
		this.xDia = MotherCanvas.hw - this.wDia / 2;
		this.hDia = ((mstatus.Length - 1) / this.maxItemW + 1) * this.hItem;
		this.cmdSelect = new iCommand(T.select, 0, this);
		this.cmdClose = new iCommand(T.close, 1, this);
		bool flag5 = this.hDia > 140;
		if (flag5)
		{
			int hDia = this.hDia;
			this.hDia = 140;
			this.yDia = MotherCanvas.hh - this.hDia / 2 - 5;
			this.list = new ListNew(this.xDia, this.yDia, this.wDia, 140, 0, 0, hDia - 140, true);
		}
		else
		{
			this.yDia = MotherCanvas.hh - this.hDia / 2 - 5;
		}
		bool flag6 = !GameCanvas.isTouch;
		if (flag6)
		{
			this.right = this.cmdClose;
			this.left = this.cmdSelect;
		}
		else
		{
			bool flag7 = GameCanvas.isTouchNoOrPC();
			if (flag7)
			{
				this.idSelect = 0;
			}
			else
			{
				this.idSelect = -1;
			}
			this.cmdClose.setPos(this.xDia + this.maxWShow / 2 + this.sizeBanner / 2, this.yDia - 20 + 8, MainTab.fraCloseTab, string.Empty);
		}
		this.backCMD = this.cmdClose;
		this.okCMD = this.cmdSelect;
		GameCanvas.isPointerSelect = false;
	}

	// Token: 0x060009E2 RID: 2530 RVA: 0x000C7EA4 File Offset: 0x000C60A4
	public override void commandPointer(int index, int subIndex)
	{
		if (index != 0)
		{
			if (index == 1)
			{
				GameCanvas.end_Dialog();
			}
		}
		else
		{
			bool flag = this.idSelect >= 0 && this.idSelect < this.mStatus.Length;
			if (flag)
			{
				bool flag2 = this.typePaintArea == 0;
				if (flag2)
				{
					GlobalService.gI().Select_Area(0, (sbyte)this.idSelect);
				}
				else
				{
					bool flag3 = this.typePaintArea == 1;
					if (flag3)
					{
						sbyte indexMarket = -1;
						bool flag4 = GameCanvas.currentScreen == GameCanvas.tabMarketScr;
						if (flag4)
						{
							MainTab mainTab = (MainTab)GameCanvas.tabMarketScr.vecTabs.elementAt(GameCanvas.tabMarketScr.idSelect);
							indexMarket = mainTab.indexMarket;
						}
						GlobalService.gI().Market(1, indexMarket, (short)this.idSelect, 0, 1);
					}
				}
			}
			GameCanvas.end_Dialog();
		}
		base.commandPointer(index, subIndex);
	}

	// Token: 0x060009E3 RID: 2531 RVA: 0x000C7F94 File Offset: 0x000C6194
	public override void paint(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		int num = this.yDia + 4;
		int num2 = this.xDia + 4;
		base.paintPaper(g, this.xDia - 5, this.yDia - 32, this.maxWShow + 10, this.hDia + 44, this.maxWShow + 10, (int)AvMain.PAPER_NORMAL);
		g.setColor(15972174);
		g.fillRoundRect(this.xDia + this.maxWShow / 2 - this.sizeBanner / 2, this.yDia - 20, this.sizeBanner, 16, 4, 4);
		AvMain.FontBorderColor(g, this.nameDialog, this.xDia + this.maxWShow / 2, this.yDia - 18, 2, 6, 5);
		g.setClip(MotherCanvas.hw - this.maxWShow / 2, this.yDia, this.maxWShow, this.hDia);
		g.saveCanvas();
		g.ClipRec(MotherCanvas.hw - this.maxWShow / 2, this.yDia, this.maxWShow, this.hDia);
		g.translate(0, -this.list.cmx);
		for (int i = 0; i < this.mStatus.Length; i++)
		{
			AvMain.paintRectButton(g, num2 + i % this.maxItemW * this.wItem, num + i / this.maxItemW * this.hItem, this.sizeButton, this.sizeButton, (this.idSelect == i) ? 1 : 0);
			sbyte color = 1;
			bool flag = this.mStatus[i] == 1;
			if (flag)
			{
				color = 3;
			}
			else
			{
				bool flag2 = this.mStatus[i] == 2;
				if (flag2)
				{
					color = 6;
				}
				else
				{
					bool flag3 = this.mStatus[i] == 3;
					if (flag3)
					{
						color = 2;
					}
				}
			}
			AvMain.FontBorderColor(g, string.Empty + (i + 1).ToString(), num2 + i % this.maxItemW * this.wItem + this.sizeButton / 2, num + i / this.maxItemW * this.hItem + GameCanvas.hText / 2, 2, (int)color, 7);
		}
		mGraphics.resetTransAndroid(g);
		g.restoreCanvas();
		GameCanvas.resetTrans(g);
		base.paintCmd(g);
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.cmdClose.paint(g, this.cmdClose.xCmd, this.cmdClose.yCmd);
		}
	}

	// Token: 0x060009E4 RID: 2532 RVA: 0x000C820C File Offset: 0x000C640C
	public override void update()
	{
		this.list.moveCamera();
		this.updatekey();
		this.updatePointer();
		bool flag = this.timePaintfocus > 0;
		if (flag)
		{
			this.timePaintfocus--;
			bool flag2 = GameCanvas.isTouch && this.timePaintfocus == 0;
			if (flag2)
			{
				this.idSelect = -1;
			}
		}
	}

	// Token: 0x060009E5 RID: 2533 RVA: 0x000C8274 File Offset: 0x000C6474
	public override void updatekey()
	{
		bool flag = false;
		bool flag2 = GameCanvas.keyMove(2);
		if (flag2)
		{
			this.idSelect++;
			GameCanvas.ClearkeyMove(2);
			flag = true;
		}
		else
		{
			bool flag3 = GameCanvas.keyMove(0);
			if (flag3)
			{
				this.idSelect--;
				GameCanvas.ClearkeyMove(0);
				flag = true;
			}
			else
			{
				bool flag4 = GameCanvas.keyMove(3);
				if (flag4)
				{
					this.idSelect += this.maxItemW;
					GameCanvas.ClearkeyMove(3);
					flag = true;
				}
				else
				{
					bool flag5 = GameCanvas.keyMove(1);
					if (flag5)
					{
						this.idSelect -= this.maxItemW;
						GameCanvas.ClearkeyMove(1);
						flag = true;
					}
					else
					{
						bool flag6 = GameCanvas.keyMyHold[5];
						if (flag6)
						{
							this.cmdSelect.perform();
							GameCanvas.clearKeyHold(5);
						}
					}
				}
			}
		}
		bool flag7 = flag;
		if (flag7)
		{
			this.idSelect = AvMain.resetSelect(this.idSelect, this.mStatus.Length - 1, true);
			this.list.setToX(this.idSelect / 3 * this.hItem - this.hDia / 2);
		}
		base.updatekey();
	}

	// Token: 0x060009E6 RID: 2534 RVA: 0x000C839C File Offset: 0x000C659C
	public override void updatePointer()
	{
		this.cmdClose.updatePointer();
		bool flag = GameCanvas.isPointerDown && GameCanvas.isPoint(this.xDia, this.yDia, this.wDia, this.hDia);
		if (flag)
		{
			int num = (GameCanvas.px - this.xDia) / this.wItem + (GameCanvas.py - this.yDia + this.list.cmx) / this.hItem * this.maxItemW;
			bool flag2 = num >= 0 && num < this.mStatus.Length;
			if (flag2)
			{
				this.idSelect = num;
				this.timePaintfocus = 10;
			}
		}
		bool isPointerMove = GameCanvas.isPointerMove;
		if (isPointerMove)
		{
			this.timePaintfocus = 0;
			this.idSelect = -1;
		}
		bool flag3 = GameCanvas.isPointSelect(this.xDia, this.yDia, this.wDia, this.hDia);
		if (flag3)
		{
			int num2 = (GameCanvas.px - this.xDia) / this.wItem + (GameCanvas.py - this.yDia + this.list.cmx) / this.hItem * this.maxItemW;
			bool flag4 = num2 >= 0 && num2 < this.mStatus.Length;
			if (flag4)
			{
				this.cmdSelect.perform();
			}
			GameCanvas.isPointerSelect = false;
		}
		this.list.update_Pos_UP_DOWN();
		base.updatePointer();
	}

	// Token: 0x04000F9A RID: 3994
	public const sbyte TYPE_AREA = 0;

	// Token: 0x04000F9B RID: 3995
	public const sbyte TYPE_PAGE_MARKET = 1;

	// Token: 0x04000F9C RID: 3996
	private sbyte[] mStatus;

	// Token: 0x04000F9D RID: 3997
	private int maxItemW;

	// Token: 0x04000F9E RID: 3998
	private int hItem;

	// Token: 0x04000F9F RID: 3999
	private int sizeButton;

	// Token: 0x04000FA0 RID: 4000
	private int sizeBanner;

	// Token: 0x04000FA1 RID: 4001
	private iCommand cmdSelect;

	// Token: 0x04000FA2 RID: 4002
	private sbyte typePaintArea;

	// Token: 0x04000FA3 RID: 4003
	public int timePaintfocus;
}
