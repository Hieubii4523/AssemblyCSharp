using System;

// Token: 0x020000B5 RID: 181
public class MyRandom
{
	// Token: 0x06000ADF RID: 2783 RVA: 0x0000B6CF File Offset: 0x000098CF
	public MyRandom()
	{
		this.r = new Random();
	}

	// Token: 0x06000AE0 RID: 2784 RVA: 0x000D75F0 File Offset: 0x000D57F0
	public int nextInt()
	{
		return this.r.Next();
	}

	// Token: 0x06000AE1 RID: 2785 RVA: 0x000D7610 File Offset: 0x000D5810
	public int nextInt(int a)
	{
		return this.r.Next(a);
	}

	// Token: 0x06000AE2 RID: 2786 RVA: 0x000D7630 File Offset: 0x000D5830
	public int nextInt(int a, int b)
	{
		return this.r.Next(a, b);
	}

	// Token: 0x040010A6 RID: 4262
	public Random r;
}
