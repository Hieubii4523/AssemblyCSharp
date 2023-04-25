using System;

// Token: 0x02000090 RID: 144
public class MarqueeText
{
	// Token: 0x0600091B RID: 2331 RVA: 0x0000AFAC File Offset: 0x000091AC
	public MarqueeText(int maxW)
	{
		this.maxW = maxW;
	}

	// Token: 0x0600091C RID: 2332 RVA: 0x000BE3A8 File Offset: 0x000BC5A8
	public void setdata(string str, mFont font)
	{
		this.fontPaint = font;
		this.text = str;
		int width = font.getWidth(str);
		this.xplus = 0;
		this.time = 0;
		this.isLeftRight = false;
		bool flag = width > this.maxW;
		if (flag)
		{
			this.limit = width - this.maxW + 20;
			this.isRun = true;
		}
		else
		{
			this.isRun = false;
		}
	}

	// Token: 0x0600091D RID: 2333 RVA: 0x0000AFC4 File Offset: 0x000091C4
	public void paint(mGraphics g, int x, int y, int align)
	{
		this.fontPaint.drawString(g, this.text, x - this.xplus, y, align);
	}

	// Token: 0x0600091E RID: 2334 RVA: 0x000BE414 File Offset: 0x000BC614
	public void update()
	{
		bool flag = this.isRun;
		if (flag)
		{
			this.time++;
			bool flag2 = this.time > 10;
			if (flag2)
			{
				this.xplus += this.speed;
			}
			bool flag3 = this.xplus >= this.limit;
			if (flag3)
			{
				this.xplus = 0;
				this.time = 0;
			}
		}
		else
		{
			this.xplus = 0;
			this.time = 0;
		}
	}

	// Token: 0x0600091F RID: 2335 RVA: 0x000BE498 File Offset: 0x000BC698
	public void update2()
	{
		bool flag = this.isRun;
		if (flag)
		{
			this.time++;
			bool flag2 = this.time > 10;
			if (flag2)
			{
				bool flag3 = !this.isLeftRight;
				if (flag3)
				{
					this.xplus += this.speed;
				}
				else
				{
					this.xplus -= this.speed;
				}
			}
			bool flag4 = this.xplus > this.limit || this.xplus < -10;
			if (flag4)
			{
				this.isLeftRight = !this.isLeftRight;
			}
		}
		else
		{
			this.xplus = 0;
			this.time = 0;
		}
	}

	// Token: 0x06000920 RID: 2336 RVA: 0x000BE550 File Offset: 0x000BC750
	public int getxPlus()
	{
		return this.xplus;
	}

	// Token: 0x04000E9F RID: 3743
	public int limit;

	// Token: 0x04000EA0 RID: 3744
	public int maxW;

	// Token: 0x04000EA1 RID: 3745
	public int speed = 2;

	// Token: 0x04000EA2 RID: 3746
	public int xplus;

	// Token: 0x04000EA3 RID: 3747
	public int time;

	// Token: 0x04000EA4 RID: 3748
	public string text;

	// Token: 0x04000EA5 RID: 3749
	public bool isRun;

	// Token: 0x04000EA6 RID: 3750
	public mFont fontPaint;

	// Token: 0x04000EA7 RID: 3751
	public bool isLeftRight;
}
