using System;

// Token: 0x02000091 RID: 145
public class Math
{
	// Token: 0x06000921 RID: 2337 RVA: 0x0007C244 File Offset: 0x0007A444
	public static int abs(int i)
	{
		return (i <= 0) ? (-i) : i;
	}

	// Token: 0x06000922 RID: 2338 RVA: 0x000BE568 File Offset: 0x000BC768
	public static int min(int x, int y)
	{
		return (x >= y) ? y : x;
	}

	// Token: 0x06000923 RID: 2339 RVA: 0x000BE584 File Offset: 0x000BC784
	public static int max(int x, int y)
	{
		return (x <= y) ? y : x;
	}

	// Token: 0x06000924 RID: 2340 RVA: 0x000BE5A0 File Offset: 0x000BC7A0
	public static int pow(int data, int x)
	{
		int num = 1;
		for (int i = 0; i < x; i++)
		{
			num *= data;
		}
		return num;
	}

	// Token: 0x04000EA8 RID: 3752
	public const double PI = 3.141592653589793;
}
