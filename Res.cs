using System;

// Token: 0x020000DB RID: 219
public class Res
{
	// Token: 0x06000D33 RID: 3379 RVA: 0x00103260 File Offset: 0x00101460
	public static short mCos(int angle)
	{
		return Res.mCosa[angle];
	}

	// Token: 0x06000D34 RID: 3380 RVA: 0x0010327C File Offset: 0x0010147C
	public static short mSin(int angle)
	{
		return Res.mSina[angle];
	}

	// Token: 0x06000D35 RID: 3381 RVA: 0x00103298 File Offset: 0x00101498
	public static void init()
	{
		Res.cosa = new short[91];
		Res.tana = new int[91];
		for (int i = 0; i <= 90; i++)
		{
			Res.cosa[i] = Res.sina[90 - i];
			bool flag = Res.cosa[i] == 0;
			if (flag)
			{
				Res.tana[i] = int.MaxValue;
			}
			else
			{
				Res.tana[i] = ((int)Res.sina[i] << 10) / (int)Res.cosa[i];
			}
		}
	}

	// Token: 0x06000D36 RID: 3382 RVA: 0x00103320 File Offset: 0x00101520
	public static int sin(int a)
	{
		a = Res.fixangle(a);
		bool flag = a >= 0 && a < 90;
		int result;
		if (flag)
		{
			result = (int)Res.sina[a];
		}
		else
		{
			bool flag2 = a >= 90 && a < 180;
			if (flag2)
			{
				result = (int)Res.sina[180 - a];
			}
			else
			{
				bool flag3 = a >= 180 && a < 270;
				if (flag3)
				{
					result = (int)(-(int)Res.sina[a - 180]);
				}
				else
				{
					result = (int)(-(int)Res.sina[360 - a]);
				}
			}
		}
		return result;
	}

	// Token: 0x06000D37 RID: 3383 RVA: 0x001033B4 File Offset: 0x001015B4
	public static int cos(int a)
	{
		a = Res.fixangle(a);
		bool flag = a >= 0 && a < 90;
		int result;
		if (flag)
		{
			result = (int)Res.cosa[a];
		}
		else
		{
			bool flag2 = a >= 90 && a < 180;
			if (flag2)
			{
				result = (int)(-(int)Res.cosa[180 - a]);
			}
			else
			{
				bool flag3 = a >= 180 && a < 270;
				if (flag3)
				{
					result = (int)(-(int)Res.cosa[a - 180]);
				}
				else
				{
					result = (int)Res.cosa[360 - a];
				}
			}
		}
		return result;
	}

	// Token: 0x06000D38 RID: 3384 RVA: 0x00103448 File Offset: 0x00101648
	public static int tan(int a)
	{
		a = Res.fixangle(a);
		bool flag = a >= 0 && a < 90;
		int result;
		if (flag)
		{
			result = Res.tana[a];
		}
		else
		{
			bool flag2 = a >= 90 && a < 180;
			if (flag2)
			{
				result = -Res.tana[180 - a];
			}
			else
			{
				bool flag3 = a >= 180 && a < 270;
				if (flag3)
				{
					result = Res.tana[a - 180];
				}
				else
				{
					result = -Res.tana[360 - a];
				}
			}
		}
		return result;
	}

	// Token: 0x06000D39 RID: 3385 RVA: 0x001034DC File Offset: 0x001016DC
	public static int atan(int a)
	{
		for (int i = 0; i <= 90; i++)
		{
			bool flag = Res.tana[i] >= a;
			if (flag)
			{
				return i;
			}
		}
		return 0;
	}

	// Token: 0x06000D3A RID: 3386 RVA: 0x0010351C File Offset: 0x0010171C
	public static int angle(int dx, int dy)
	{
		bool flag = dx != 0;
		int num;
		if (flag)
		{
			int a = global::Math.abs((dy << 10) / dx);
			num = Res.atan(a);
			bool flag2 = dy >= 0 && dx < 0;
			if (flag2)
			{
				num = 180 - num;
			}
			bool flag3 = dy < 0 && dx < 0;
			if (flag3)
			{
				num = 180 + num;
			}
			bool flag4 = dy < 0 && dx >= 0;
			if (flag4)
			{
				num = 360 - num;
			}
		}
		else
		{
			num = ((dy <= 0) ? 270 : 90);
		}
		return num;
	}

	// Token: 0x06000D3B RID: 3387 RVA: 0x001035B4 File Offset: 0x001017B4
	public static int fixangle(int angle)
	{
		bool flag = angle >= 360;
		if (flag)
		{
			angle -= 360;
		}
		bool flag2 = angle < 0;
		if (flag2)
		{
			angle += 360;
		}
		return angle;
	}

	// Token: 0x06000D3C RID: 3388 RVA: 0x001035F4 File Offset: 0x001017F4
	public static int xetVX(int goc, int d)
	{
		return Res.cos(Res.fixangle(goc)) * d >> 10;
	}

	// Token: 0x06000D3D RID: 3389 RVA: 0x00103618 File Offset: 0x00101818
	public static int xetVY(int goc, int d)
	{
		return Res.sin(Res.fixangle(goc)) * d >> 10;
	}

	// Token: 0x06000D3E RID: 3390 RVA: 0x0010363C File Offset: 0x0010183C
	public static int random(int a, int b)
	{
		bool flag = a == b;
		int result;
		if (flag)
		{
			result = a;
		}
		else
		{
			result = a + Res.r.nextInt(b - a);
		}
		return result;
	}

	// Token: 0x06000D3F RID: 3391 RVA: 0x0007C15C File Offset: 0x0007A35C
	public static int s2tick(int currentTimeMillis)
	{
		int num = currentTimeMillis * 16 / 1000;
		bool flag = currentTimeMillis * 16 % 1000 >= 5;
		if (flag)
		{
			num++;
		}
		return num;
	}

	// Token: 0x06000D40 RID: 3392 RVA: 0x0010366C File Offset: 0x0010186C
	public static int distance(int x1, int y1, int x2, int y2)
	{
		return Res.sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
	}

	// Token: 0x06000D41 RID: 3393 RVA: 0x00103694 File Offset: 0x00101894
	public static int sqrt(int a)
	{
		bool flag = a <= 0;
		int result;
		if (flag)
		{
			result = 0;
		}
		else
		{
			int num = (a + 1) / 2;
			int num2;
			do
			{
				num2 = num;
				num = num / 2 + a / (2 * num);
			}
			while (global::Math.abs(num2 - num) > 1);
			result = num;
		}
		return result;
	}

	// Token: 0x06000D42 RID: 3394 RVA: 0x001036DC File Offset: 0x001018DC
	public static int rnd(int a)
	{
		return Res.r.nextInt(a);
	}

	// Token: 0x06000D43 RID: 3395 RVA: 0x001036FC File Offset: 0x001018FC
	public static int rnd(int a, int b)
	{
		bool flag = Res.r.nextInt(2) == 0;
		int result;
		if (flag)
		{
			result = a;
		}
		else
		{
			result = b;
		}
		return result;
	}

	// Token: 0x06000D44 RID: 3396 RVA: 0x0007C244 File Offset: 0x0007A444
	public static int abs(int i)
	{
		return (i <= 0) ? (-i) : i;
	}

	// Token: 0x06000D45 RID: 3397 RVA: 0x0007C260 File Offset: 0x0007A460
	public static bool inRect(int x1, int y1, int width, int height, int x2, int y2)
	{
		return x2 >= x1 && x2 <= x1 + width && y2 >= y1 && y2 <= y1 + height;
	}

	// Token: 0x06000D46 RID: 3398 RVA: 0x00103728 File Offset: 0x00101928
	public static string[] split(string original, string separator, int count)
	{
		int num = original.IndexOf(separator);
		bool flag = num >= 0;
		string[] array;
		if (flag)
		{
			array = Res.split(original.Substring(num + separator.Length), separator, count + 1);
		}
		else
		{
			array = new string[count + 1];
			num = original.Length;
		}
		array[count] = original.Substring(0, num);
		return array;
	}

	// Token: 0x06000D47 RID: 3399 RVA: 0x00103788 File Offset: 0x00101988
	public static Image rotateImage(Image src, int angle, mGraphics g, int x, int y, bool isRGB)
	{
		return src;
	}

	// Token: 0x04001499 RID: 5273
	private static short[] mSina = new short[]
	{
		0,
		174,
		348,
		523,
		697,
		871,
		1045,
		1218,
		1391,
		1564,
		1736,
		1908,
		2079,
		2249,
		2419,
		2588,
		2756,
		2923,
		3090,
		3255,
		3420,
		3583,
		3746,
		3907,
		4067,
		4226,
		4383,
		4539,
		4694,
		4848,
		4999,
		5150,
		5299,
		5446,
		5591,
		5735,
		5877,
		6018,
		6156,
		6293,
		6427,
		6560,
		6691,
		6819,
		6946,
		7071,
		7193,
		7313,
		7431,
		7547,
		7660,
		7771,
		7880,
		7986,
		8090,
		8191,
		8290,
		8386,
		8480,
		8571,
		8660,
		8746,
		8829,
		8910,
		8987,
		9063,
		9135,
		9205,
		9271,
		9335,
		9396,
		9455,
		9510,
		9563,
		9612,
		9659,
		9702,
		9743,
		9781,
		9816,
		9848,
		9876,
		9902,
		9925,
		9945,
		9961,
		9975,
		9986,
		9993,
		9998,
		10000,
		9998,
		9993,
		9986,
		9975,
		9961,
		9945,
		9925,
		9902,
		9876,
		9848,
		9816,
		9781,
		9743,
		9702,
		9659,
		9612,
		9563,
		9510,
		9455,
		9396,
		9335,
		9271,
		9205,
		9135,
		9063,
		8987,
		8910,
		8829,
		8746,
		8660,
		8571,
		8480,
		8386,
		8290,
		8191,
		8090,
		7986,
		7880,
		7771,
		7660,
		7547,
		7431,
		7313,
		7193,
		7071,
		6946,
		6819,
		6691,
		6560,
		6427,
		6293,
		6156,
		6018,
		5877,
		5735,
		5591,
		5446,
		5299,
		5150,
		4999,
		4848,
		4694,
		4539,
		4383,
		4226,
		4067,
		3907,
		3746,
		3583,
		3420,
		3255,
		3090,
		2923,
		2756,
		2588,
		2419,
		2249,
		2079,
		1908,
		1736,
		1564,
		1391,
		1218,
		1045,
		871,
		697,
		523,
		348,
		174,
		12246,
		-174,
		-348,
		-523,
		-697,
		-871,
		-1045,
		-1218,
		-1391,
		-1564,
		-1736,
		-1908,
		-2079,
		-2249,
		-2419,
		-2588,
		-2756,
		-2923,
		-3090,
		-3255,
		-3420,
		-3583,
		-3746,
		-3907,
		-4067,
		-4226,
		-4383,
		-4539,
		-4694,
		-4848,
		-5000,
		-5150,
		-5299,
		-5446,
		-5591,
		-5735,
		-5877,
		-6018,
		-6156,
		-6293,
		-6427,
		-6560,
		-6691,
		-6819,
		-6946,
		-7071,
		-7193,
		-7313,
		-7431,
		-7547,
		-7660,
		-7771,
		-7880,
		-7986,
		-8090,
		-8191,
		-8290,
		-8386,
		-8480,
		-8571,
		-8660,
		-8746,
		-8829,
		-8910,
		-8987,
		-9063,
		-9135,
		-9205,
		-9271,
		-9335,
		-9396,
		-9455,
		-9510,
		-9563,
		-9612,
		-9659,
		-9702,
		-9743,
		-9781,
		-9816,
		-9848,
		-9876,
		-9902,
		-9925,
		-9945,
		-9961,
		-9975,
		-9986,
		-9993,
		-9998,
		-10000,
		-9998,
		-9993,
		-9986,
		-9975,
		-9961,
		-9945,
		-9925,
		-9902,
		-9876,
		-9848,
		-9816,
		-9781,
		-9743,
		-9702,
		-9659,
		-9612,
		-9563,
		-9510,
		-9455,
		-9396,
		-9335,
		-9271,
		-9205,
		-9135,
		-9063,
		-8987,
		-8910,
		-8829,
		-8746,
		-8660,
		-8571,
		-8480,
		-8386,
		-8290,
		-8191,
		-8090,
		-7986,
		-7880,
		-7771,
		-7660,
		-7547,
		-7431,
		-7313,
		-7193,
		-7071,
		-6946,
		-6819,
		-6691,
		-6560,
		-6427,
		-6293,
		-6156,
		-6018,
		-5877,
		-5735,
		-5591,
		-5446,
		-5299,
		-5150,
		-5000,
		-4848,
		-4694,
		-4539,
		-4383,
		-4226,
		-4067,
		-3907,
		-3746,
		-3583,
		-3420,
		-3255,
		-3090,
		-2923,
		-2756,
		-2588,
		-2419,
		-2249,
		-2079,
		-1908,
		-1736,
		-1564,
		-1391,
		-1218,
		-1045,
		-871,
		-697,
		-523,
		-348,
		-174
	};

	// Token: 0x0400149A RID: 5274
	private static short[] mCosa = new short[]
	{
		10000,
		9998,
		9993,
		9986,
		9975,
		9961,
		9945,
		9925,
		9902,
		9876,
		9848,
		9816,
		9781,
		9743,
		9702,
		9659,
		9612,
		9563,
		9510,
		9455,
		9396,
		9335,
		9271,
		9205,
		9135,
		9063,
		8987,
		8910,
		8829,
		8746,
		8660,
		8571,
		8480,
		8386,
		8290,
		8191,
		8090,
		7986,
		7880,
		7771,
		7660,
		7547,
		7431,
		7313,
		7193,
		7071,
		6946,
		6819,
		6691,
		6560,
		6427,
		6293,
		6156,
		6018,
		5877,
		5735,
		5591,
		5446,
		5299,
		5150,
		5000,
		4848,
		4694,
		4539,
		4383,
		4226,
		4067,
		3907,
		3746,
		3583,
		3420,
		3255,
		3090,
		2923,
		2756,
		2588,
		2419,
		2249,
		2079,
		1908,
		1736,
		1564,
		1391,
		1218,
		1045,
		871,
		697,
		523,
		348,
		174,
		1232,
		-174,
		-348,
		-523,
		-697,
		-871,
		-1045,
		-1218,
		-1391,
		-1564,
		-1736,
		-1908,
		-2079,
		-2249,
		-2419,
		-2588,
		-2756,
		-2923,
		-3090,
		-3255,
		-3420,
		-3583,
		-3746,
		-3907,
		-4067,
		-4226,
		-4383,
		-4539,
		-4694,
		-4848,
		-4999,
		-5150,
		-5299,
		-5446,
		-5591,
		-5735,
		-5877,
		-6018,
		-6156,
		-6293,
		-6427,
		-6560,
		-6691,
		-6819,
		-6946,
		-7071,
		-7193,
		-7313,
		-7431,
		-7547,
		-7660,
		-7771,
		-7880,
		-7986,
		-8090,
		-8191,
		-8290,
		-8386,
		-8480,
		-8571,
		-8660,
		-8746,
		-8829,
		-8910,
		-8987,
		-9063,
		-9135,
		-9205,
		-9271,
		-9335,
		-9396,
		-9455,
		-9510,
		-9563,
		-9612,
		-9659,
		-9702,
		-9743,
		-9781,
		-9816,
		-9848,
		-9876,
		-9902,
		-9925,
		-9945,
		-9961,
		-9975,
		-9986,
		-9993,
		-9998,
		-1,
		-9998,
		-9993,
		-9986,
		-9975,
		-9961,
		-9945,
		-9925,
		-9902,
		-9876,
		-9848,
		-9816,
		-9781,
		-9743,
		-9702,
		-9659,
		-9612,
		-9563,
		-9510,
		-9455,
		-9396,
		-9335,
		-9271,
		-9205,
		-9135,
		-9063,
		-8987,
		-8910,
		-8829,
		-8746,
		-8660,
		-8571,
		-8480,
		-8386,
		-8290,
		-8191,
		-8090,
		-7986,
		-7880,
		-7771,
		-7660,
		-7547,
		-7431,
		-7313,
		-7193,
		-7071,
		-6946,
		-6819,
		-6691,
		-6560,
		-6427,
		-6293,
		-6156,
		-6018,
		-5877,
		-5735,
		-5591,
		-5446,
		-5299,
		-5150,
		-5000,
		-4848,
		-4694,
		-4539,
		-4383,
		-4226,
		-4067,
		-3907,
		-3746,
		-3583,
		-3420,
		-3255,
		-3090,
		-2923,
		-2756,
		-2588,
		-2419,
		-2249,
		-2079,
		-1908,
		-1736,
		-1564,
		-1391,
		-1218,
		-1045,
		-871,
		-697,
		-523,
		-348,
		-174,
		-18369,
		174,
		348,
		523,
		697,
		871,
		1045,
		1218,
		1391,
		1564,
		1736,
		1908,
		2079,
		2249,
		2419,
		2588,
		2756,
		2923,
		3090,
		3255,
		3420,
		3583,
		3746,
		3907,
		4067,
		4226,
		4383,
		4539,
		4694,
		4848,
		5000,
		5150,
		5299,
		5446,
		5591,
		5735,
		5877,
		6018,
		6156,
		6293,
		6427,
		6560,
		6691,
		6819,
		6946,
		7071,
		7193,
		7313,
		7431,
		7547,
		7660,
		7771,
		7880,
		7986,
		8090,
		8191,
		8290,
		8386,
		8480,
		8571,
		8660,
		8746,
		8829,
		8910,
		8987,
		9063,
		9135,
		9205,
		9271,
		9335,
		9396,
		9455,
		9510,
		9563,
		9612,
		9659,
		9702,
		9743,
		9781,
		9816,
		9848,
		9876,
		9902,
		9925,
		9945,
		9961,
		9975,
		9986,
		9993,
		9998
	};

	// Token: 0x0400149B RID: 5275
	private static short[] sina = new short[]
	{
		0,
		18,
		36,
		54,
		71,
		89,
		107,
		125,
		143,
		160,
		178,
		195,
		213,
		230,
		248,
		265,
		282,
		299,
		316,
		333,
		350,
		367,
		384,
		400,
		416,
		433,
		449,
		465,
		481,
		496,
		512,
		527,
		543,
		558,
		573,
		587,
		602,
		616,
		630,
		644,
		658,
		672,
		685,
		698,
		711,
		724,
		737,
		749,
		761,
		773,
		784,
		796,
		807,
		818,
		828,
		839,
		849,
		859,
		868,
		878,
		887,
		896,
		904,
		912,
		920,
		928,
		935,
		943,
		949,
		956,
		962,
		968,
		974,
		979,
		984,
		989,
		994,
		998,
		1002,
		1005,
		1008,
		1011,
		1014,
		1016,
		1018,
		1020,
		1022,
		1023,
		1023,
		1024,
		1024
	};

	// Token: 0x0400149C RID: 5276
	private static short[] cosa;

	// Token: 0x0400149D RID: 5277
	private static int[] tana;

	// Token: 0x0400149E RID: 5278
	public static MyRandom r = new MyRandom();
}
