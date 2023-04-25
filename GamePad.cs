using System;

// Token: 0x02000036 RID: 54
public class GamePad
{
	// Token: 0x060003FA RID: 1018 RVA: 0x00073670 File Offset: 0x00071870
	public GamePad()
	{
		this.R = 28;
		bool flag = MotherCanvas.w < 300;
		if (flag)
		{
			this.isSmallGamePad = true;
			this.isMediumGamePad = false;
			this.isLargeGamePad = false;
		}
		bool flag2 = MotherCanvas.w >= 300 && MotherCanvas.w <= 380;
		if (flag2)
		{
			this.isSmallGamePad = false;
			this.isMediumGamePad = true;
			this.isLargeGamePad = false;
		}
		bool flag3 = MotherCanvas.w > 380;
		if (flag3)
		{
			this.isSmallGamePad = false;
			this.isMediumGamePad = false;
			this.isLargeGamePad = true;
		}
		bool flag4 = !this.isLargeGamePad;
		if (flag4)
		{
			this.xZone = 0;
			this.wZone = MotherCanvas.hw;
			this.yZone = MotherCanvas.hh >> 1;
			this.hZone = MotherCanvas.h - 80;
		}
		else
		{
			this.xZone = 0;
			this.wZone = MotherCanvas.hw / 4 * 3 - 20;
			this.yZone = MotherCanvas.hh >> 1;
			this.hZone = MotherCanvas.h;
		}
	}

	// Token: 0x060003FB RID: 1019 RVA: 0x000090B5 File Offset: 0x000072B5
	public void update()
	{
	}

	// Token: 0x060003FC RID: 1020 RVA: 0x00073788 File Offset: 0x00071988
	private bool checkPointerMove(int distance)
	{
		return true;
	}

	// Token: 0x060003FD RID: 1021 RVA: 0x00009D1A File Offset: 0x00007F1A
	private void resetHold()
	{
		GameCanvas.clearKeyHold();
	}

	// Token: 0x060003FE RID: 1022 RVA: 0x000090B5 File Offset: 0x000072B5
	public void paint(mGraphics g)
	{
	}

	// Token: 0x060003FF RID: 1023 RVA: 0x0007379C File Offset: 0x0007199C
	public bool disableCheckDrag()
	{
		return this.isGamePad;
	}

	// Token: 0x06000400 RID: 1024 RVA: 0x000734DC File Offset: 0x000716DC
	public bool disableClickMove()
	{
		return false;
	}

	// Token: 0x04000607 RID: 1543
	private int xC;

	// Token: 0x04000608 RID: 1544
	private int yC;

	// Token: 0x04000609 RID: 1545
	private int xM;

	// Token: 0x0400060A RID: 1546
	private int yM;

	// Token: 0x0400060B RID: 1547
	private int xMLast;

	// Token: 0x0400060C RID: 1548
	private int yMLast;

	// Token: 0x0400060D RID: 1549
	private int R;

	// Token: 0x0400060E RID: 1550
	private int r;

	// Token: 0x0400060F RID: 1551
	private int d;

	// Token: 0x04000610 RID: 1552
	private int xTemp;

	// Token: 0x04000611 RID: 1553
	private int yTemp;

	// Token: 0x04000612 RID: 1554
	private int deltaX;

	// Token: 0x04000613 RID: 1555
	private int deltaY;

	// Token: 0x04000614 RID: 1556
	private int delta;

	// Token: 0x04000615 RID: 1557
	private int angle;

	// Token: 0x04000616 RID: 1558
	public int xZone;

	// Token: 0x04000617 RID: 1559
	public int yZone;

	// Token: 0x04000618 RID: 1560
	public int wZone;

	// Token: 0x04000619 RID: 1561
	public int hZone;

	// Token: 0x0400061A RID: 1562
	private bool isGamePad;

	// Token: 0x0400061B RID: 1563
	public bool isSmallGamePad;

	// Token: 0x0400061C RID: 1564
	public bool isMediumGamePad;

	// Token: 0x0400061D RID: 1565
	public bool isLargeGamePad;
}
