using System;

// Token: 0x020000CF RID: 207
public class Point
{
	// Token: 0x06000BF4 RID: 3060 RVA: 0x0000B6E4 File Offset: 0x000098E4
	public Point()
	{
	}

	// Token: 0x06000BF5 RID: 3061 RVA: 0x0000B979 File Offset: 0x00009B79
	public Point(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	// Token: 0x06000BF6 RID: 3062 RVA: 0x0000B991 File Offset: 0x00009B91
	public void update()
	{
		this.f++;
		this.x += this.vx;
		this.y += this.vy;
	}

	// Token: 0x06000BF7 RID: 3063 RVA: 0x000E74B0 File Offset: 0x000E56B0
	public void paint(mGraphics g)
	{
		bool flag = !this.isRemove;
		if (flag)
		{
			int num = 0;
			bool flag2 = this.isSmall && this.f >= this.fSmall;
			if (flag2)
			{
				num = 1;
			}
			Point.FraEffInMap[this.color].drawFrame(this.frame / 2 + num, this.x, this.y, this.dis, 3, g);
		}
	}

	// Token: 0x06000BF8 RID: 3064 RVA: 0x000E7524 File Offset: 0x000E5724
	public void updateInMap()
	{
		this.f++;
		bool flag = this.maxframe > 1;
		if (flag)
		{
			this.frame++;
			bool flag2 = this.frame / 2 >= this.maxframe;
			if (flag2)
			{
				this.frame = 0;
			}
		}
		bool flag3 = this.f >= this.fRe;
		if (flag3)
		{
			this.isRemove = true;
		}
	}

	// Token: 0x06000BF9 RID: 3065 RVA: 0x000E759C File Offset: 0x000E579C
	public void updateObj()
	{
		bool flag = this.obj != null && this.obj.Action != 4 && !this.obj.returnAction();
		if (flag)
		{
			this.x = this.obj.x;
			this.y = this.obj.y;
		}
	}

	// Token: 0x040012C4 RID: 4804
	public int x;

	// Token: 0x040012C5 RID: 4805
	public int y;

	// Token: 0x040012C6 RID: 4806
	public int g;

	// Token: 0x040012C7 RID: 4807
	public int v;

	// Token: 0x040012C8 RID: 4808
	public int w;

	// Token: 0x040012C9 RID: 4809
	public int h;

	// Token: 0x040012CA RID: 4810
	public int color;

	// Token: 0x040012CB RID: 4811
	public int limitY;

	// Token: 0x040012CC RID: 4812
	public int vx;

	// Token: 0x040012CD RID: 4813
	public int vy;

	// Token: 0x040012CE RID: 4814
	public int x2;

	// Token: 0x040012CF RID: 4815
	public int y2;

	// Token: 0x040012D0 RID: 4816
	public int x0;

	// Token: 0x040012D1 RID: 4817
	public int y0;

	// Token: 0x040012D2 RID: 4818
	public int dis;

	// Token: 0x040012D3 RID: 4819
	public int f;

	// Token: 0x040012D4 RID: 4820
	public int fRe;

	// Token: 0x040012D5 RID: 4821
	public int frame;

	// Token: 0x040012D6 RID: 4822
	public int maxframe;

	// Token: 0x040012D7 RID: 4823
	public int fSmall;

	// Token: 0x040012D8 RID: 4824
	public int levelPaint;

	// Token: 0x040012D9 RID: 4825
	public int subType;

	// Token: 0x040012DA RID: 4826
	public mVector vecEffPoint;

	// Token: 0x040012DB RID: 4827
	public string name;

	// Token: 0x040012DC RID: 4828
	public bool isRemove;

	// Token: 0x040012DD RID: 4829
	public bool isSmall;

	// Token: 0x040012DE RID: 4830
	public static FrameImage[] FraEffInMap;

	// Token: 0x040012DF RID: 4831
	public FrameImage fraImgEff;

	// Token: 0x040012E0 RID: 4832
	public MainObject obj;
}
