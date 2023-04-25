using System;

// Token: 0x020000E9 RID: 233
public class Scroll
{
	// Token: 0x06000E0C RID: 3596 RVA: 0x0000BDE3 File Offset: 0x00009FE3
	public void setInfo(int x, int y, int h, int color)
	{
		this.x = x;
		this.y = y;
		this.h = h;
		this.color = color;
		Scroll.hRectScroll = Scroll.maxRectScroll;
		this.hScroll = h - Scroll.maxRectScroll;
	}

	// Token: 0x06000E0D RID: 3597 RVA: 0x001101A4 File Offset: 0x0010E3A4
	public void paint(mGraphics g)
	{
		g.setColor(this.color);
		g.fillRect(this.x - 2, this.y - 1, 3, 1);
		g.fillRect(this.x - 3, this.y, 1, this.h - 1);
		g.fillRect(this.x + 1, this.y, 1, this.h - 1);
		g.fillRect(this.x - 2, this.y + this.h - 1, 3, 1);
		bool flag = this.hEffScroll <= 0;
		if (flag)
		{
			g.fillRect(this.x - 2, this.y + this.yScroll, 3, Scroll.hRectScroll - CRes.abs(this.hEffScroll));
		}
		else
		{
			g.fillRect(this.x - 2, this.y + this.yScroll + CRes.abs(this.hEffScroll), 3, Scroll.hRectScroll - CRes.abs(this.hEffScroll));
		}
	}

	// Token: 0x06000E0E RID: 3598 RVA: 0x001102B4 File Offset: 0x0010E4B4
	public void setYScrool(int yS, int yMax)
	{
		bool flag = yMax <= 0;
		if (!flag)
		{
			this.yScroll = yS * this.hScroll / yMax;
			bool flag2 = this.yScroll >= 0 && this.yScroll <= this.hScroll;
			if (flag2)
			{
				this.hEffScroll = 0;
			}
			else
			{
				bool flag3 = this.yScroll > this.hScroll;
				if (flag3)
				{
					this.hEffScroll = (this.yScroll - this.hScroll) / 18;
					this.yScroll = this.hScroll;
				}
				bool flag4 = this.yScroll < 0;
				if (flag4)
				{
					this.hEffScroll = this.yScroll / 18;
					this.yScroll = 0;
				}
				this.sethEff();
			}
		}
	}

	// Token: 0x06000E0F RID: 3599 RVA: 0x00110370 File Offset: 0x0010E570
	public void sethEff()
	{
		bool flag = this.hEffScroll > 12;
		if (flag)
		{
			this.hEffScroll = 12;
		}
		else
		{
			bool flag2 = this.hEffScroll < -12;
			if (flag2)
			{
				this.hEffScroll = -12;
			}
		}
	}

	// Token: 0x0400157C RID: 5500
	private int x;

	// Token: 0x0400157D RID: 5501
	private int y;

	// Token: 0x0400157E RID: 5502
	private int h;

	// Token: 0x0400157F RID: 5503
	private int color;

	// Token: 0x04001580 RID: 5504
	private int yScroll;

	// Token: 0x04001581 RID: 5505
	private int hScroll;

	// Token: 0x04001582 RID: 5506
	public static int hRectScroll = 24;

	// Token: 0x04001583 RID: 5507
	public static int maxRectScroll = 24;

	// Token: 0x04001584 RID: 5508
	private int hEffScroll;
}
