using System;

// Token: 0x02000068 RID: 104
public class Line
{
	// Token: 0x06000667 RID: 1639 RVA: 0x0000A704 File Offset: 0x00008904
	public void setLine(int x0, int y0, int x1, int y1, int vx, int vy, bool is2Line)
	{
		this.x0 = x0;
		this.y0 = y0;
		this.x1 = x1;
		this.y1 = y1;
		this.vx = vx;
		this.vy = vy;
		this.is2Line = is2Line;
	}

	// Token: 0x06000668 RID: 1640 RVA: 0x0008D338 File Offset: 0x0008B538
	public void update()
	{
		this.x0 += this.vx;
		this.x1 += this.vx;
		this.y0 += this.vy;
		this.y1 += this.vy;
		this.f++;
	}

	// Token: 0x04000929 RID: 2345
	public int x0;

	// Token: 0x0400092A RID: 2346
	public int y0;

	// Token: 0x0400092B RID: 2347
	public int x1;

	// Token: 0x0400092C RID: 2348
	public int y1;

	// Token: 0x0400092D RID: 2349
	public int vx;

	// Token: 0x0400092E RID: 2350
	public int vy;

	// Token: 0x0400092F RID: 2351
	public int f;

	// Token: 0x04000930 RID: 2352
	public int fRe;

	// Token: 0x04000931 RID: 2353
	public int idColor;

	// Token: 0x04000932 RID: 2354
	public int type;

	// Token: 0x04000933 RID: 2355
	public bool is2Line;
}
