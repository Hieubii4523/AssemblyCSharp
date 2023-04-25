using System;

namespace hqx
{
	// Token: 0x0200011B RID: 283
	public class RgbYuv
	{
		// Token: 0x06001025 RID: 4133 RVA: 0x0014FEA4 File Offset: 0x0014E0A4
		public static int getYuv(int rgb)
		{
			return RgbYuv.rgb2yuv(rgb);
		}

		// Token: 0x06001026 RID: 4134 RVA: 0x0014FEBC File Offset: 0x0014E0BC
		public static void hqxInit()
		{
			for (int i = 16777215; i >= 0; i--)
			{
				int num = (i & 16711680) >> 16;
				int num2 = (i & 65280) >> 8;
				int num3 = i & 255;
				int num4 = (int)(0.299 * (double)num + 0.587 * (double)num2 + 0.114 * (double)num3);
				int num5 = (int)(-0.169 * (double)num - 0.331 * (double)num2 + 0.5 * (double)num3) + 128;
				int num6 = (int)(0.5 * (double)num - 0.419 * (double)num2 - 0.081 * (double)num3) + 128;
				RgbYuv.RGBtoYUV[i] = (num4 << 16 | num5 << 8 | num6);
			}
		}

		// Token: 0x06001027 RID: 4135 RVA: 0x0014FFA4 File Offset: 0x0014E1A4
		public static int rgb2yuv(int c)
		{
			byte b = (byte)((c & 16711680) >> 16);
			byte b2 = (byte)((c & 65280) >> 8);
			byte b3 = (byte)(c & 255);
			byte b4 = (byte)(0.299 * (double)b + 0.587 * (double)b2 + 0.114 * (double)b3);
			byte b5 = (byte)(-0.169 * (double)b - 0.331 * (double)b2 + 0.5 * (double)b3 + 128.0);
			byte b6 = (byte)(0.5 * (double)b - 0.419 * (double)b2 - 0.081 * (double)b3 + 128.0);
			return (int)b4 << 16 | (int)b5 << 8 | (int)b6;
		}

		// Token: 0x06001028 RID: 4136 RVA: 0x0000C39E File Offset: 0x0000A59E
		public static void hqxDeinit()
		{
			RgbYuv.RGBtoYUV = null;
		}

		// Token: 0x04001A7F RID: 6783
		private const int rgbMask = 16777215;

		// Token: 0x04001A80 RID: 6784
		private static int[] RGBtoYUV;
	}
}
