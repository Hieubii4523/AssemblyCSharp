using System;

// Token: 0x0200003B RID: 59
public class GMath
{
	// Token: 0x060004E2 RID: 1250 RVA: 0x0007C118 File Offset: 0x0007A318
	public static int random(int a, int b)
	{
		return a + GMath.r.nextInt(b - a);
	}

	// Token: 0x060004E3 RID: 1251 RVA: 0x0007C13C File Offset: 0x0007A33C
	public static double pitago(int dx, int dy)
	{
		return (double)GMath.sqrt(dx * dx + dy * dy);
	}

	// Token: 0x060004E4 RID: 1252 RVA: 0x0007C15C File Offset: 0x0007A35C
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

	// Token: 0x060004E5 RID: 1253 RVA: 0x0007C198 File Offset: 0x0007A398
	public static int distance(int a, int b)
	{
		return GMath.abs(a - b);
	}

	// Token: 0x060004E6 RID: 1254 RVA: 0x0007C1B4 File Offset: 0x0007A3B4
	public static int distance(int x1, int y1, int x2, int y2)
	{
		return GMath.sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
	}

	// Token: 0x060004E7 RID: 1255 RVA: 0x0007C1DC File Offset: 0x0007A3DC
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
			while (GMath.abs(num2 - num) > 1);
			result = num;
		}
		return result;
	}

	// Token: 0x060004E8 RID: 1256 RVA: 0x0007C224 File Offset: 0x0007A424
	public static int rnd(int a)
	{
		return GMath.r.nextInt(a);
	}

	// Token: 0x060004E9 RID: 1257 RVA: 0x0007C244 File Offset: 0x0007A444
	public static int abs(int i)
	{
		return (i <= 0) ? (-i) : i;
	}

	// Token: 0x060004EA RID: 1258 RVA: 0x0007C260 File Offset: 0x0007A460
	public static bool inRect(int x1, int y1, int width, int height, int x2, int y2)
	{
		return x2 >= x1 && x2 <= x1 + width && y2 >= y1 && y2 <= y1 + height;
	}

	// Token: 0x060004EB RID: 1259 RVA: 0x0007C290 File Offset: 0x0007A490
	public static string[] split(string original, string separator, int count)
	{
		int num = original.IndexOf(separator);
		bool flag = num >= 0;
		string[] array;
		if (flag)
		{
			array = GMath.split(original.Substring(num + separator.Length), separator, count + 1);
		}
		else
		{
			array = new string[count + 1];
			num = original.Length;
		}
		array[count] = original.Substring(0, num);
		return array;
	}

	// Token: 0x0400072B RID: 1835
	public static MyRandom r = new MyRandom();
}
