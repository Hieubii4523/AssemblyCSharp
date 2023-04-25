using System;
using System.Text;
using UnityEngine;

// Token: 0x020000B0 RID: 176
public class mSystem
{
	// Token: 0x06000AA7 RID: 2727 RVA: 0x000090B5 File Offset: 0x000072B5
	public static void closeBanner()
	{
	}

	// Token: 0x06000AA8 RID: 2728 RVA: 0x000090B5 File Offset: 0x000072B5
	public static void showBanner()
	{
	}

	// Token: 0x06000AA9 RID: 2729 RVA: 0x000090B5 File Offset: 0x000072B5
	public static void createAdmob()
	{
	}

	// Token: 0x06000AAA RID: 2730 RVA: 0x000090B5 File Offset: 0x000072B5
	public static void checkAdComlete()
	{
	}

	// Token: 0x06000AAB RID: 2731 RVA: 0x0000B574 File Offset: 0x00009774
	public static void paintPopUp2(mGraphics g, int x, int y, int w, int h)
	{
		g.fillRect(x, y, w + 10, h, 0, 90);
	}

	// Token: 0x06000AAC RID: 2732 RVA: 0x0000B589 File Offset: 0x00009789
	public static void arraycopy(sbyte[] scr, int scrPos, sbyte[] dest, int destPos, int lenght)
	{
		Array.Copy(scr, scrPos, dest, destPos, lenght);
	}

	// Token: 0x06000AAD RID: 2733 RVA: 0x000D6C40 File Offset: 0x000D4E40
	public static void arrayReplace(sbyte[] scr, int scrPos, ref sbyte[] dest, int destPos, int lenght)
	{
		bool flag = scr != null && dest != null && scrPos + lenght <= scr.Length;
		if (flag)
		{
			sbyte[] array = new sbyte[dest.Length + lenght];
			for (int i = 0; i < destPos; i++)
			{
				array[i] = dest[i];
			}
			for (int j = destPos; j < destPos + lenght; j++)
			{
				array[j] = scr[scrPos + j - destPos];
			}
			for (int k = destPos + lenght; k < array.Length; k++)
			{
				array[k] = dest[destPos + k - lenght];
			}
		}
	}

	// Token: 0x06000AAE RID: 2734 RVA: 0x000D6CE4 File Offset: 0x000D4EE4
	public static long currentTimeMillis()
	{
		DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
		return (DateTime.UtcNow.Ticks - dateTime.Ticks) / 10000L;
	}

	// Token: 0x06000AAF RID: 2735 RVA: 0x0000B598 File Offset: 0x00009798
	public static void freeData()
	{
		Resources.UnloadUnusedAssets();
		GC.Collect();
	}

	// Token: 0x06000AB0 RID: 2736 RVA: 0x000D6D24 File Offset: 0x000D4F24
	public static sbyte[] convertToSbyte(byte[] scr)
	{
		sbyte[] array = new sbyte[scr.Length];
		for (int i = 0; i < scr.Length; i++)
		{
			array[i] = (sbyte)scr[i];
		}
		return array;
	}

	// Token: 0x06000AB1 RID: 2737 RVA: 0x000D6D5C File Offset: 0x000D4F5C
	public static sbyte[] convertToSbyte(string scr)
	{
		ASCIIEncoding asciiencoding = new ASCIIEncoding();
		byte[] bytes = asciiencoding.GetBytes(scr);
		return mSystem.convertToSbyte(bytes);
	}

	// Token: 0x06000AB2 RID: 2738 RVA: 0x0007F150 File Offset: 0x0007D350
	public static byte[] convetToByte(sbyte[] scr)
	{
		byte[] array = new byte[scr.Length];
		for (int i = 0; i < scr.Length; i++)
		{
			bool flag = scr[i] > 0;
			if (flag)
			{
				array[i] = (byte)scr[i];
			}
			else
			{
				array[i] = (byte)((int)scr[i] + 256);
			}
		}
		return array;
	}

	// Token: 0x06000AB3 RID: 2739 RVA: 0x000D6D84 File Offset: 0x000D4F84
	public static char[] ToCharArray(sbyte[] scr)
	{
		char[] array = new char[scr.Length];
		for (int i = 0; i < scr.Length; i++)
		{
			array[i] = (char)scr[i];
		}
		return array;
	}

	// Token: 0x06000AB4 RID: 2740 RVA: 0x000D6DBC File Offset: 0x000D4FBC
	public static int currentHour()
	{
		return DateTime.Now.Hour;
	}

	// Token: 0x06000AB5 RID: 2741 RVA: 0x000090B5 File Offset: 0x000072B5
	public static void println(object str)
	{
	}

	// Token: 0x06000AB6 RID: 2742 RVA: 0x000090B5 File Offset: 0x000072B5
	public static void outz(object str)
	{
	}

	// Token: 0x06000AB7 RID: 2743 RVA: 0x0000B598 File Offset: 0x00009798
	public static void gc()
	{
		Resources.UnloadUnusedAssets();
		GC.Collect();
	}

	// Token: 0x06000AB8 RID: 2744 RVA: 0x000D6DDC File Offset: 0x000D4FDC
	public static int[][] new_M_Int(int value1, int value2)
	{
		int[][] array = new int[value1][];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new int[value2];
		}
		return array;
	}

	// Token: 0x06000AB9 RID: 2745 RVA: 0x000090B5 File Offset: 0x000072B5
	public static void outloi(object str)
	{
	}

	// Token: 0x06000ABA RID: 2746 RVA: 0x0000B598 File Offset: 0x00009798
	public static void gcc()
	{
		Resources.UnloadUnusedAssets();
		GC.Collect();
	}

	// Token: 0x06000ABB RID: 2747 RVA: 0x000090B5 File Offset: 0x000072B5
	public static void onConnectOK()
	{
	}

	// Token: 0x06000ABC RID: 2748 RVA: 0x000090B5 File Offset: 0x000072B5
	public static void onConnectionFail()
	{
	}

	// Token: 0x06000ABD RID: 2749 RVA: 0x000090B5 File Offset: 0x000072B5
	public static void onDisconnected()
	{
	}

	// Token: 0x04001093 RID: 4243
	public const int clientType = 4;

	// Token: 0x04001094 RID: 4244
	public const int JAVA = 1;

	// Token: 0x04001095 RID: 4245
	public const int ANDROID = 2;

	// Token: 0x04001096 RID: 4246
	public const int IP_JB = 3;

	// Token: 0x04001097 RID: 4247
	public const int PC = 4;

	// Token: 0x04001098 RID: 4248
	public const int IP_APPSTORE = 5;

	// Token: 0x04001099 RID: 4249
	public const int WINDOWS_PHONE = 6;

	// Token: 0x0400109A RID: 4250
	public const int GOOGLE_PLAY = 7;

	// Token: 0x0400109B RID: 4251
	public static string strAdmob;

	// Token: 0x0400109C RID: 4252
	public static bool loadAdOk;

	// Token: 0x0400109D RID: 4253
	public static string publicID;

	// Token: 0x0400109E RID: 4254
	public static string android_pack;
}
