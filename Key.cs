using System;

// Token: 0x02000066 RID: 102
public class Key
{
	// Token: 0x0600065E RID: 1630 RVA: 0x0008CE2C File Offset: 0x0008B02C
	public static void mapKeyPC()
	{
		bool isPC = GameMidlet.isPC;
		if (isPC)
		{
			Key.UP = 15;
			Key.DOWN = 16;
			Key.LEFT = 17;
			Key.RIGHT = 18;
		}
	}

	// Token: 0x04000906 RID: 2310
	public static int NUM0;

	// Token: 0x04000907 RID: 2311
	public static int NUM1 = 1;

	// Token: 0x04000908 RID: 2312
	public static int NUM2 = 2;

	// Token: 0x04000909 RID: 2313
	public static int NUM3 = 3;

	// Token: 0x0400090A RID: 2314
	public static int NUM4 = 4;

	// Token: 0x0400090B RID: 2315
	public static int NUM5 = 5;

	// Token: 0x0400090C RID: 2316
	public static int NUM6 = 6;

	// Token: 0x0400090D RID: 2317
	public static int NUM7 = 7;

	// Token: 0x0400090E RID: 2318
	public static int NUM8 = 8;

	// Token: 0x0400090F RID: 2319
	public static int NUM9 = 9;

	// Token: 0x04000910 RID: 2320
	public static int STAR = 10;

	// Token: 0x04000911 RID: 2321
	public static int BOUND = 11;

	// Token: 0x04000912 RID: 2322
	public static int UP = 12;

	// Token: 0x04000913 RID: 2323
	public static int DOWN = 13;

	// Token: 0x04000914 RID: 2324
	public static int LEFT = 14;

	// Token: 0x04000915 RID: 2325
	public static int RIGHT = 15;

	// Token: 0x04000916 RID: 2326
	public static int FIRE = 16;

	// Token: 0x04000917 RID: 2327
	public static int LEFT_SOFTKEY = 17;

	// Token: 0x04000918 RID: 2328
	public static int RIGHT_SOFTKEY = 18;

	// Token: 0x04000919 RID: 2329
	public static int CLEAR = 19;

	// Token: 0x0400091A RID: 2330
	public static int BACK = 20;
}
