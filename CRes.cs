using System;

// Token: 0x0200001F RID: 31
public class CRes
{
	// Token: 0x0600012A RID: 298 RVA: 0x0001B8AC File Offset: 0x00019AAC
	public static void loadSinCos()
	{
		CRes.cos = new short[91];
		CRes.tan = new int[91];
		for (int i = 0; i <= 90; i++)
		{
			CRes.cos[i] = CRes.sin[90 - i];
			bool flag = CRes.cos[i] == 0;
			if (flag)
			{
				CRes.tan[i] = 1000000000;
			}
			else
			{
				CRes.tan[i] = ((int)CRes.sin[i] << 10) / (int)CRes.cos[i];
			}
		}
	}

	// Token: 0x0600012B RID: 299 RVA: 0x0001B934 File Offset: 0x00019B34
	public static int getsin(int a)
	{
		a = CRes.fixangle(a);
		bool flag = a >= 0 && a < 90;
		int result;
		if (flag)
		{
			result = (int)CRes.sin[a];
		}
		else
		{
			bool flag2 = a >= 90 && a < 180;
			if (flag2)
			{
				result = (int)CRes.sin[180 - a];
			}
			else
			{
				bool flag3 = a >= 180 && a < 270;
				if (flag3)
				{
					result = (int)(-(int)CRes.sin[a - 180]);
				}
				else
				{
					result = (int)(-(int)CRes.sin[360 - a]);
				}
			}
		}
		return result;
	}

	// Token: 0x0600012C RID: 300 RVA: 0x0001B9C8 File Offset: 0x00019BC8
	public static int getcos(int a)
	{
		a = CRes.fixangle(a);
		bool flag = a >= 0 && a < 90;
		int result;
		if (flag)
		{
			result = (int)CRes.cos[a];
		}
		else
		{
			bool flag2 = a >= 90 && a < 180;
			if (flag2)
			{
				result = (int)(-(int)CRes.cos[180 - a]);
			}
			else
			{
				bool flag3 = a >= 180 && a < 270;
				if (flag3)
				{
					result = (int)(-(int)CRes.cos[a - 180]);
				}
				else
				{
					result = (int)CRes.cos[360 - a];
				}
			}
		}
		return result;
	}

	// Token: 0x0600012D RID: 301 RVA: 0x0001BA5C File Offset: 0x00019C5C
	public static int gettan(int a)
	{
		bool flag = a >= 0 && a < 90;
		int result;
		if (flag)
		{
			result = CRes.tan[a];
		}
		else
		{
			bool flag2 = a >= 90 && a < 180;
			if (flag2)
			{
				result = -CRes.tan[180 - a];
			}
			else
			{
				bool flag3 = a >= 180 && a < 270;
				if (flag3)
				{
					result = CRes.tan[a - 180];
				}
				else
				{
					result = -CRes.tan[360 - a];
				}
			}
		}
		return result;
	}

	// Token: 0x0600012E RID: 302 RVA: 0x0001BAE8 File Offset: 0x00019CE8
	public static int atan(int a)
	{
		for (int i = 0; i <= 90; i++)
		{
			bool flag = CRes.tan[i] >= a;
			if (flag)
			{
				return i;
			}
		}
		return 0;
	}

	// Token: 0x0600012F RID: 303 RVA: 0x0001BB28 File Offset: 0x00019D28
	public static int angle(int dx, int dy)
	{
		bool flag = dx != 0;
		int num;
		if (flag)
		{
			int a = CRes.abs((dy << 10) / dx);
			num = CRes.atan(a);
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

	// Token: 0x06000130 RID: 304 RVA: 0x0001BBC0 File Offset: 0x00019DC0
	public static int fixangle(int angle)
	{
		bool flag = angle >= 360;
		if (flag)
		{
			angle %= 360;
		}
		bool flag2 = angle < 0;
		if (flag2)
		{
			angle = 360 + angle % 360;
		}
		return angle;
	}

	// Token: 0x06000131 RID: 305 RVA: 0x0001BC08 File Offset: 0x00019E08
	public static int subangle(int a1, int a2)
	{
		int num = a2 - a1;
		bool flag = num < -180;
		int result;
		if (flag)
		{
			result = num + 360;
		}
		else
		{
			bool flag2 = num > 180;
			if (flag2)
			{
				result = num - 360;
			}
			else
			{
				result = num;
			}
		}
		return result;
	}

	// Token: 0x06000132 RID: 306 RVA: 0x0001BC50 File Offset: 0x00019E50
	public static int abs(int a)
	{
		bool flag = a < 0;
		int result;
		if (flag)
		{
			result = -a;
		}
		else
		{
			result = a;
		}
		return result;
	}

	// Token: 0x06000133 RID: 307 RVA: 0x0001BC74 File Offset: 0x00019E74
	public static long absLong(long a)
	{
		bool flag = a < 0L;
		long result;
		if (flag)
		{
			result = -a;
		}
		else
		{
			result = a;
		}
		return result;
	}

	// Token: 0x06000134 RID: 308 RVA: 0x0001BC98 File Offset: 0x00019E98
	public static int random(int a)
	{
		bool flag = a <= 1;
		int result;
		if (flag)
		{
			mSystem.outloi("random <0");
			result = 0;
		}
		else
		{
			result = CRes.r.nextInt(a);
		}
		return result;
	}

	// Token: 0x06000135 RID: 309 RVA: 0x0001BCD0 File Offset: 0x00019ED0
	public static int random_Am_0(int a)
	{
		bool flag = a <= 1;
		if (flag)
		{
			a = 1;
			mSystem.outloi("random a<=0");
		}
		int num = 0;
		while (num == 0)
		{
			num = CRes.r.nextInt(a);
			bool flag2 = CRes.random(2) == 0;
			if (flag2)
			{
				num = -num;
			}
		}
		return num;
	}

	// Token: 0x06000136 RID: 310 RVA: 0x0001BD2C File Offset: 0x00019F2C
	public static int random_Am(int a, int b)
	{
		bool flag = b <= a;
		if (flag)
		{
			mSystem.outloi("lỗi random am b<=a");
			b = a + 1;
		}
		int num = a + CRes.r.nextInt(b - a);
		bool flag2 = CRes.random(2) == 0;
		if (flag2)
		{
			num = -num;
		}
		return num;
	}

	// Token: 0x06000137 RID: 311 RVA: 0x0001BD80 File Offset: 0x00019F80
	public static int random(int a, int b)
	{
		bool flag = b <= a;
		if (flag)
		{
			mSystem.outloi("lỗi random b<=a");
			b = a + 1;
		}
		return a + CRes.r.nextInt(b - a);
	}

	// Token: 0x06000138 RID: 312 RVA: 0x0001BDC0 File Offset: 0x00019FC0
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
			while (CRes.abs(num2 - num) > 1);
			result = num;
		}
		return result;
	}

	// Token: 0x06000139 RID: 313 RVA: 0x0001BE08 File Offset: 0x0001A008
	public static int setDis(int x1, int y1, int x2, int y2)
	{
		return CRes.abs(x1 - x2) + CRes.abs(y1 - y2);
	}

	// Token: 0x0600013A RID: 314 RVA: 0x0001BE2C File Offset: 0x0001A02C
	public static void saveRMS(string name, sbyte[] data)
	{
		try
		{
			GameMidlet.saveRMS(name, data);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x0600013B RID: 315 RVA: 0x0001BE5C File Offset: 0x0001A05C
	public static sbyte[] loadRMS(string name)
	{
		return GameMidlet.loadRMS(name);
	}

	// Token: 0x0600013C RID: 316 RVA: 0x0001BE74 File Offset: 0x0001A074
	public static void saveRMSPlayer(string name, sbyte[] data)
	{
		try
		{
			bool flag = GameScreen.player != null;
			if (flag)
			{
				GameMidlet.saveRMS(GameScreen.player.name + name, data);
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x0600013D RID: 317 RVA: 0x0001BEC0 File Offset: 0x0001A0C0
	public static sbyte[] loadRMSPlayer(string name)
	{
		bool flag = GameScreen.player != null;
		sbyte[] result;
		if (flag)
		{
			result = GameMidlet.loadRMS(GameScreen.player.name + name);
		}
		else
		{
			result = null;
		}
		return result;
	}

	// Token: 0x0600013E RID: 318 RVA: 0x000094EC File Offset: 0x000076EC
	public static void quickSortMemList(mVector actors)
	{
		CRes.recQuickSortMemList(actors, 0, actors.size() - 1);
	}

	// Token: 0x0600013F RID: 319 RVA: 0x0001BEF8 File Offset: 0x0001A0F8
	private static void recQuickSortMemList(mVector actors, int left, int right)
	{
		try
		{
			bool flag = right - left > 0;
			if (flag)
			{
				InfoMemList infoMemList = (InfoMemList)actors.elementAt(right);
				int rank = infoMemList.rank;
				int num = CRes.partitionItMemList(actors, left, right, rank);
				CRes.recQuickSortMemList(actors, left, num - 1);
				CRes.recQuickSortMemList(actors, num + 1, right);
			}
		}
		catch (Exception)
		{
			mSystem.outloi("loi Cres 1");
		}
	}

	// Token: 0x06000140 RID: 320 RVA: 0x0001BF6C File Offset: 0x0001A16C
	private static int partitionItMemList(mVector actors, int left, int right, int pivot)
	{
		int num = left - 1;
		int num2 = right;
		int result;
		try
		{
			for (;;)
			{
				bool flag = ((InfoMemList)actors.elementAt(++num)).rank >= pivot;
				if (flag)
				{
					while (num2 > 0 && ((InfoMemList)actors.elementAt(--num2)).rank > pivot)
					{
					}
					bool flag2 = num >= num2;
					if (flag2)
					{
						break;
					}
					CRes.swapMemList(actors, num, num2);
				}
			}
			CRes.swapMemList(actors, num, right);
			result = num;
		}
		catch (Exception)
		{
			mSystem.outloi("loi Cres 2");
			result = num;
		}
		return result;
	}

	// Token: 0x06000141 RID: 321 RVA: 0x0001C020 File Offset: 0x0001A220
	private static void swapMemList(mVector actors, int dex1, int dex2)
	{
		object obj = actors.elementAt(dex2);
		bool flag = ((InfoMemList)actors.elementAt(dex2)).rank != ((InfoMemList)actors.elementAt(dex1)).rank;
		if (flag)
		{
			actors.setElementAt(actors.elementAt(dex1), dex2);
			actors.setElementAt(obj, dex1);
		}
	}

	// Token: 0x06000142 RID: 322 RVA: 0x000094FF File Offset: 0x000076FF
	public static void quickSort(mVector actors)
	{
		CRes.recQuickSort(actors, 0, actors.size() - 1);
	}

	// Token: 0x06000143 RID: 323 RVA: 0x0001C07C File Offset: 0x0001A27C
	private static void recQuickSort(mVector actors, int left, int right)
	{
		try
		{
			bool flag = right - left > 0;
			if (flag)
			{
				MainObject mainObject = (MainObject)actors.elementAt(right);
				int ySort = mainObject.ySort;
				int num = CRes.partitionIt(actors, left, right, ySort);
				CRes.recQuickSort(actors, left, num - 1);
				CRes.recQuickSort(actors, num + 1, right);
			}
		}
		catch (Exception)
		{
			mSystem.outloi("loi Cres 1");
		}
	}

	// Token: 0x06000144 RID: 324 RVA: 0x0001C0F0 File Offset: 0x0001A2F0
	private static int partitionIt(mVector actors, int left, int right, int pivot)
	{
		int num = left - 1;
		int num2 = right;
		int result;
		try
		{
			for (;;)
			{
				bool flag = ((MainObject)actors.elementAt(++num)).ySort >= pivot;
				if (flag)
				{
					while (num2 > 0 && ((MainObject)actors.elementAt(--num2)).ySort > pivot)
					{
					}
					bool flag2 = num >= num2;
					if (flag2)
					{
						break;
					}
					CRes.swap(actors, num, num2);
				}
			}
			CRes.swap(actors, num, right);
			result = num;
		}
		catch (Exception)
		{
			mSystem.outloi("loi Cres 2");
			result = num;
		}
		return result;
	}

	// Token: 0x06000145 RID: 325 RVA: 0x0001C1A4 File Offset: 0x0001A3A4
	private static void swap(mVector actors, int dex1, int dex2)
	{
		object obj = actors.elementAt(dex2);
		bool flag = ((MainObject)actors.elementAt(dex2)).ySort != ((MainObject)actors.elementAt(dex1)).ySort;
		if (flag)
		{
			actors.setElementAt(actors.elementAt(dex1), dex2);
			actors.setElementAt(obj, dex1);
		}
	}

	// Token: 0x06000146 RID: 326 RVA: 0x0001C200 File Offset: 0x0001A400
	public static bool CheckDelRMS(string str)
	{
		bool flag = str.Length >= 9;
		if (flag)
		{
			string text = str.Substring(0, 9);
			bool flag2 = text.CompareTo("SUB_image") == 0;
			if (flag2)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000147 RID: 327 RVA: 0x0001C248 File Offset: 0x0001A448
	public static string getDay(int time)
	{
		bool flag = time >= 1440;
		string result;
		if (flag)
		{
			result = (time / 1440).ToString() + " " + T.day;
		}
		else
		{
			bool flag2 = time > 60;
			if (flag2)
			{
				result = (time / 60).ToString() + " " + T.hour;
			}
			else
			{
				result = time.ToString() + " " + T.minute;
			}
		}
		return result;
	}

	// Token: 0x06000148 RID: 328 RVA: 0x0001C2CC File Offset: 0x0001A4CC
	public static bool setVaCham(int x, int y, int w, int h, int x2, int y2, int w2, int h2)
	{
		return (x >= x2 && x <= x2 + w2 && y > y2 && y < y2 + h2) || (x2 >= x && x2 <= x + w && y2 >= y && y2 <= y + h) || (x >= x2 && x <= x2 + w2 && y2 >= y && y2 <= y + h) || (x2 >= x && x2 <= x + w && y > y2 && y < y2 + h2);
	}

	// Token: 0x06000149 RID: 329 RVA: 0x0001C354 File Offset: 0x0001A554
	public static bool setVaCham(Boat b, Boat b2)
	{
		return CRes.setVaCham(b.xset, b.yset, b.wset, b.hset, b2.xset, b2.yset, b2.wset, b2.hset);
	}

	// Token: 0x04000268 RID: 616
	public const string sign = "checkmodhaitac:android:isolatedSplits=true";

	// Token: 0x04000269 RID: 617
	private static short[] sin = new short[]
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

	// Token: 0x0400026A RID: 618
	public static MyHashTable hashWeapon = new MyHashTable();

	// Token: 0x0400026B RID: 619
	public static short[] cos;

	// Token: 0x0400026C RID: 620
	public static int[] tan;

	// Token: 0x0400026D RID: 621
	public static MyRandom r = new MyRandom();
}
