using System;

// Token: 0x02000067 RID: 103
public class Lazer : MainEffect
{
	// Token: 0x06000661 RID: 1633 RVA: 0x0008CEF8 File Offset: 0x0008B0F8
	public Lazer(sbyte type, int x, int y, int xTo, int yTo)
	{
		this.x = x;
		this.y = y;
		this.xlim = xTo;
		this.ylim = yTo;
		this.xkc = this.xlim - x;
		this.ykc = this.ylim - y;
		this.angle0 = CRes.angle(this.xkc, this.ykc);
		this.lim = 10;
		this.idColor = 0;
		this.time = 10;
	}

	// Token: 0x06000662 RID: 1634 RVA: 0x0000A6E3 File Offset: 0x000088E3
	public Lazer()
	{
	}

	// Token: 0x06000663 RID: 1635 RVA: 0x0008CF90 File Offset: 0x0008B190
	public override void paint(mGraphics g)
	{
		bool flag = (this.angle0 > 60 && this.angle0 < 120) || (this.angle0 > 240 && this.angle0 < 300);
		if (flag)
		{
			g.setColor(this.color[this.idColor]);
			for (int i = 0; i < this.lim; i++)
			{
				g.drawLine(this.x + i, this.y, this.x + i + this.xkc, this.y + this.ykc);
				g.drawLine(this.x - i, this.y, this.x - i + this.xkc, this.y + this.ykc);
			}
			g.setColor(16777215);
			for (int j = 0; j < this.lim / 2; j++)
			{
				g.drawLine(this.x + j, this.y, this.x + j + this.xkc, this.y + this.ykc);
				g.drawLine(this.x - j, this.y, this.x - j + this.xkc, this.y + this.ykc);
			}
		}
		else
		{
			g.setColor(this.color[this.idColor]);
			for (int k = 0; k < this.lim / 2; k++)
			{
				g.drawLine(this.x, this.y + k, this.x + this.xkc, this.y + this.ykc + k);
				g.drawLine(this.x, this.y - k, this.x + this.xkc, this.y + this.ykc - k);
			}
			g.setColor(16777215);
			for (int l = 0; l < this.lim / 2; l++)
			{
				g.drawLine(this.x, this.y + l, this.x + this.xkc, this.y + this.ykc + l);
				g.drawLine(this.x, this.y - l, this.x + this.xkc, this.y + this.ykc - l);
			}
		}
	}

	// Token: 0x06000664 RID: 1636 RVA: 0x0008D224 File Offset: 0x0008B424
	public void update2()
	{
		bool flag = this.time >= 0;
		if (flag)
		{
			this.time--;
		}
		bool flag2 = this.time <= 0;
		if (flag2)
		{
			this.removeEff();
		}
		this.lim--;
		bool flag3 = this.lim <= 0;
		if (flag3)
		{
			this.lim = this.maxlim;
		}
	}

	// Token: 0x06000665 RID: 1637 RVA: 0x0008D298 File Offset: 0x0008B498
	public override void update()
	{
		bool flag = this.type == 0;
		if (flag)
		{
			this.CFrame++;
			bool flag2 = this.CFrame > 2;
			if (flag2)
			{
				this.CFrame = 0;
			}
			this.time--;
			bool flag3 = this.time <= 0;
			if (flag3)
			{
				this.lim--;
			}
			bool flag4 = this.lim <= 0;
			if (flag4)
			{
				this.removeEff();
			}
		}
		bool flag5 = this.type == 1;
		if (flag5)
		{
			this.update2();
		}
	}

	// Token: 0x06000666 RID: 1638 RVA: 0x0000986D File Offset: 0x00007A6D
	public override void removeEff()
	{
		this.isStop = true;
		this.f = -1;
	}

	// Token: 0x0400091B RID: 2331
	private int angle0;

	// Token: 0x0400091C RID: 2332
	private int lim;

	// Token: 0x0400091D RID: 2333
	private new int x;

	// Token: 0x0400091E RID: 2334
	private new int y;

	// Token: 0x0400091F RID: 2335
	private int xlim;

	// Token: 0x04000920 RID: 2336
	private int ylim;

	// Token: 0x04000921 RID: 2337
	private int xkc;

	// Token: 0x04000922 RID: 2338
	private int ykc;

	// Token: 0x04000923 RID: 2339
	private int power;

	// Token: 0x04000924 RID: 2340
	private int time;

	// Token: 0x04000925 RID: 2341
	private int maxlim;

	// Token: 0x04000926 RID: 2342
	private int idColor;

	// Token: 0x04000927 RID: 2343
	private sbyte type;

	// Token: 0x04000928 RID: 2344
	private int[] color = new int[]
	{
		0,
		8388469,
		7710463,
		16711680
	};
}
