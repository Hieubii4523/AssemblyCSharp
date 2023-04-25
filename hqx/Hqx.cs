using System;

namespace hqx
{
	// Token: 0x02000116 RID: 278
	public abstract class Hqx
	{
		// Token: 0x06000FF2 RID: 4082 RVA: 0x00131CD8 File Offset: 0x0012FED8
		protected static bool diff(int c1, int c2, int trY, int trU, int trV, int trA)
		{
			int yuv = RgbYuv.getYuv(c1);
			int yuv2 = RgbYuv.getYuv(c2);
			return global::Math.abs((yuv & Hqx.Ymask) - (yuv2 & Hqx.Ymask)) > trY || global::Math.abs((yuv & Hqx.Umask) - (yuv2 & Hqx.Umask)) > trU || global::Math.abs((yuv & Hqx.Vmask) - (yuv2 & Hqx.Vmask)) > trV || global::Math.abs((c1 >> 24) - (c2 >> 24)) > trA;
		}

		// Token: 0x06000FF3 RID: 4083 RVA: 0x00131D54 File Offset: 0x0012FF54
		public static int[] HqxZoom(int zoom, int[] source, int Xres, int Yres)
		{
			int[] array;
			switch (zoom)
			{
			case 2:
				array = new int[Xres * Yres * zoom * zoom];
				Hqx_2x.hq2x_32_rb(source, array, Xres, Yres);
				break;
			case 3:
				array = new int[Xres * Yres * zoom * zoom];
				Hqx_3x.hq3x_32_rb(source, array, Xres, Yres);
				break;
			case 4:
				array = new int[Xres * Yres * zoom * zoom];
				Hqx_4x.hq4x_32_rb(source, array, Xres, Yres);
				break;
			default:
				array = source;
				break;
			}
			return array;
		}

		// Token: 0x04001A79 RID: 6777
		private static int Ymask = 16711680;

		// Token: 0x04001A7A RID: 6778
		private static int Umask = 65280;

		// Token: 0x04001A7B RID: 6779
		private static int Vmask = 255;
	}
}
