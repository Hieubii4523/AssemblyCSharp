using System;

// Token: 0x020000D0 RID: 208
public class Point_Focus
{
	// Token: 0x06000BFA RID: 3066 RVA: 0x0000B9C8 File Offset: 0x00009BC8
	public Point_Focus(int x, int y, int toX, int toY, int maxdis)
	{
		this.x = x;
		this.y = y;
		this.toX = toX;
		this.toY = toY;
		this.maxdis = maxdis;
	}

	// Token: 0x06000BFB RID: 3067 RVA: 0x0000B9F7 File Offset: 0x00009BF7
	public Point_Focus(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	// Token: 0x06000BFC RID: 3068 RVA: 0x0000B6E4 File Offset: 0x000098E4
	public Point_Focus()
	{
	}

	// Token: 0x06000BFD RID: 3069 RVA: 0x0000BA0F File Offset: 0x00009C0F
	public void createNormal()
	{
		this.vx = CRes.random_Am(0, 5);
		this.vy = CRes.random_Am(0, 5);
	}

	// Token: 0x06000BFE RID: 3070 RVA: 0x000E75FC File Offset: 0x000E57FC
	public bool update()
	{
		bool flag = this.x < this.toX;
		if (flag)
		{
			bool flag2 = this.vx < 4;
			if (flag2)
			{
				this.vx++;
			}
		}
		else
		{
			bool flag3 = this.vx > -4;
			if (flag3)
			{
				this.vx--;
			}
		}
		bool flag4 = this.y < this.toY;
		if (flag4)
		{
			bool flag5 = this.vy < 4;
			if (flag5)
			{
				this.vy++;
			}
		}
		else
		{
			bool flag6 = this.vy > -4;
			if (flag6)
			{
				this.vy--;
			}
		}
		int a = this.toX - this.x;
		int a2 = this.toY - this.y;
		bool flag7 = CRes.abs(a) < this.maxdis && CRes.abs(a2) < this.maxdis;
		bool result;
		if (flag7)
		{
			this.vx = 0;
			this.vy = 0;
			result = true;
		}
		else
		{
			this.x += this.vx;
			this.y += this.vy;
			result = false;
		}
		return result;
	}

	// Token: 0x06000BFF RID: 3071 RVA: 0x0000BA2C File Offset: 0x00009C2C
	public void update_Vx_Vy()
	{
		this.f++;
		this.x += this.vx;
		this.y += this.vy;
	}

	// Token: 0x040012E1 RID: 4833
	public bool isSpeedUp;

	// Token: 0x040012E2 RID: 4834
	public sbyte Dir;

	// Token: 0x040012E3 RID: 4835
	public int x;

	// Token: 0x040012E4 RID: 4836
	public int y;

	// Token: 0x040012E5 RID: 4837
	public int dis;

	// Token: 0x040012E6 RID: 4838
	public int fRe;

	// Token: 0x040012E7 RID: 4839
	public int f;

	// Token: 0x040012E8 RID: 4840
	public int frame;

	// Token: 0x040012E9 RID: 4841
	public int vx;

	// Token: 0x040012EA RID: 4842
	public int vy;

	// Token: 0x040012EB RID: 4843
	public int toX;

	// Token: 0x040012EC RID: 4844
	public int toY;

	// Token: 0x040012ED RID: 4845
	public int maxdis;

	// Token: 0x040012EE RID: 4846
	public int vxMax;

	// Token: 0x040012EF RID: 4847
	public int vyMax;

	// Token: 0x040012F0 RID: 4848
	public int goc;

	// Token: 0x040012F1 RID: 4849
	public int typeSpec;

	// Token: 0x040012F2 RID: 4850
	public MainObject objMain;
}
