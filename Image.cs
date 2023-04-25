using System;
using System.Threading;
using hqx;
using UnityEngine;

// Token: 0x02000049 RID: 73
public class Image
{
	// Token: 0x06000545 RID: 1349 RVA: 0x0007EF78 File Offset: 0x0007D178
	public static Image createEmptyImage()
	{
		return Image.__createEmptyImage();
	}

	// Token: 0x06000546 RID: 1350 RVA: 0x0007EF90 File Offset: 0x0007D190
	public static Image createImage(string path)
	{
		path = Main.res + path;
		path = Image.cutPng(path);
		Image image = null;
		Image result;
		try
		{
			image = Image.createImageUni(path);
			result = image;
		}
		catch (Exception)
		{
			result = image;
		}
		return result;
	}

	// Token: 0x06000547 RID: 1351 RVA: 0x0007EFD8 File Offset: 0x0007D1D8
	public static string cutPng(string str)
	{
		string result = str;
		bool flag = str.Contains(".png");
		if (flag)
		{
			result = str.Replace(".png", string.Empty);
		}
		return result;
	}

	// Token: 0x06000548 RID: 1352 RVA: 0x0007F010 File Offset: 0x0007D210
	public static Image createImageUni(string filename)
	{
		return Image.__createImage(filename);
	}

	// Token: 0x06000549 RID: 1353 RVA: 0x0007F028 File Offset: 0x0007D228
	public static Image createImageX(string filename)
	{
		return Image.__createImageX(filename);
	}

	// Token: 0x0600054A RID: 1354 RVA: 0x0007F040 File Offset: 0x0007D240
	public static Image createImage(byte[] imageData)
	{
		return Image.__createImage(imageData);
	}

	// Token: 0x0600054B RID: 1355 RVA: 0x0007F058 File Offset: 0x0007D258
	public static Image createImage(Image src, int x, int y, int w, int h, int transform)
	{
		return Image.__createImage(src, x, y, w, h, transform);
	}

	// Token: 0x0600054C RID: 1356 RVA: 0x0007F078 File Offset: 0x0007D278
	public static Image createImage(int w, int h)
	{
		return Image.__createImage(w, h);
	}

	// Token: 0x0600054D RID: 1357 RVA: 0x0007F094 File Offset: 0x0007D294
	public static Image createImage(Image img)
	{
		Image image = Image.createImage(img.w, img.h);
		image.texture = img.texture;
		image.texture.Apply();
		return image;
	}

	// Token: 0x0600054E RID: 1358 RVA: 0x0007F0D4 File Offset: 0x0007D2D4
	public static Image createImage(sbyte[] imageData, int offset, int lenght)
	{
		bool flag = offset + lenght > imageData.Length;
		Image result;
		if (flag)
		{
			result = null;
		}
		else
		{
			byte[] array = new byte[lenght];
			for (int i = 0; i < lenght; i++)
			{
				array[i] = Image.convertSbyteToByte(imageData[i + offset]);
			}
			result = Image.createImage(array);
		}
		return result;
	}

	// Token: 0x0600054F RID: 1359 RVA: 0x0007F128 File Offset: 0x0007D328
	public static byte convertSbyteToByte(sbyte var)
	{
		bool flag = var > 0;
		byte result;
		if (flag)
		{
			result = (byte)var;
		}
		else
		{
			result = (byte)((int)var + 256);
		}
		return result;
	}

	// Token: 0x06000550 RID: 1360 RVA: 0x0007F150 File Offset: 0x0007D350
	public static byte[] convertArrSbyteToArrByte(sbyte[] var)
	{
		byte[] array = new byte[var.Length];
		for (int i = 0; i < var.Length; i++)
		{
			bool flag = var[i] > 0;
			if (flag)
			{
				array[i] = (byte)var[i];
			}
			else
			{
				array[i] = (byte)((int)var[i] + 256);
			}
		}
		return array;
	}

	// Token: 0x06000551 RID: 1361 RVA: 0x0007F1A8 File Offset: 0x0007D3A8
	public static Image createRGBImage(int[] rbg, int w, int h, bool bl)
	{
		Image image = Image.createImage(w, h);
		Color[] array = new Color[rbg.Length];
		for (int i = 0; i < array.Length; i++)
		{
			ref Color ptr = ref array[i];
			ptr = Image.setColorFromRBG(rbg[i]);
		}
		image.texture.SetPixels(0, 0, w, h, array);
		image.texture.Apply();
		return image;
	}

	// Token: 0x06000552 RID: 1362 RVA: 0x0007F218 File Offset: 0x0007D418
	public static Color setColorFromRBG(int rgb)
	{
		int num = rgb & 255;
		int num2 = rgb >> 8 & 255;
		int num3 = rgb >> 16 & 255;
		float b = (float)num / 256f;
		float g = (float)num2 / 256f;
		float r = (float)num3 / 256f;
		return new Color(r, g, b);
	}

	// Token: 0x06000553 RID: 1363 RVA: 0x0007F270 File Offset: 0x0007D470
	public static void update()
	{
		bool flag = Image.status == 2;
		if (flag)
		{
			Image.status = 1;
			Image.imgTemp = Image.__createEmptyImage();
			Image.status = 0;
		}
		else
		{
			bool flag2 = Image.status == 3;
			if (flag2)
			{
				Image.status = 1;
				Image.imgTemp = Image.__createImage(Image.filenametemp);
				Image.status = 0;
			}
			else
			{
				bool flag3 = Image.status == 4;
				if (flag3)
				{
					Image.status = 1;
					Image.imgTemp = Image.__createImage(Image.datatemp);
					Image.status = 0;
				}
				else
				{
					bool flag4 = Image.status == 5;
					if (flag4)
					{
						Image.status = 1;
						Image.imgTemp = Image.__createImage(Image.imgSrcTemp, Image.xtemp, Image.ytemp, Image.wtemp, Image.htemp, Image.transformtemp);
						Image.status = 0;
					}
					else
					{
						bool flag5 = Image.status == 6;
						if (flag5)
						{
							Image.status = 1;
							Image.imgTemp = Image.__createImage(Image.wtemp, Image.htemp);
							Image.status = 0;
						}
						else
						{
							bool flag6 = Image.status == 7;
							if (flag6)
							{
								Image.status = 1;
								Image.imgTemp = Image.__createImage(Image.filenametemp);
								Image.status = 0;
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x06000554 RID: 1364 RVA: 0x0007F3A4 File Offset: 0x0007D5A4
	private static Image _createEmptyImage()
	{
		bool flag = Image.status != 0;
		Image result;
		if (flag)
		{
			Cout.LogError("CANNOT CREATE EMPTY IMAGE WHEN CREATING OTHER IMAGE");
			result = null;
		}
		else
		{
			Image.imgTemp = null;
			Image.status = 2;
			int i;
			for (i = 0; i < 500; i++)
			{
				Thread.Sleep(5);
				bool flag2 = Image.status == 0;
				if (flag2)
				{
					break;
				}
			}
			bool flag3 = i == 500;
			if (flag3)
			{
				Cout.LogError("TOO LONG FOR CREATE EMPTY IMAGE");
				Image.status = 0;
			}
			result = Image.imgTemp;
		}
		return result;
	}

	// Token: 0x06000555 RID: 1365 RVA: 0x0007F434 File Offset: 0x0007D634
	private static Image _createImage(string filename)
	{
		bool flag = Image.status != 0;
		Image result;
		if (flag)
		{
			Cout.LogError("CANNOT CREATE IMAGE " + filename + " WHEN CREATING OTHER IMAGE");
			result = null;
		}
		else
		{
			Image.imgTemp = null;
			Image.filenametemp = filename;
			Image.status = 3;
			int i;
			for (i = 0; i < 500; i++)
			{
				Thread.Sleep(5);
				bool flag2 = Image.status == 0;
				if (flag2)
				{
					break;
				}
			}
			bool flag3 = i == 500;
			if (flag3)
			{
				Cout.LogError("TOO LONG FOR CREATE IMAGE " + filename);
				Image.status = 0;
			}
			result = Image.imgTemp;
		}
		return result;
	}

	// Token: 0x06000556 RID: 1366 RVA: 0x0007F4DC File Offset: 0x0007D6DC
	private static Image _createImageX(string filename)
	{
		bool flag = Image.status != 0;
		Image result;
		if (flag)
		{
			Cout.LogError("CANNOT CREATE IMAGE " + filename + " WHEN CREATING OTHER IMAGE");
			result = null;
		}
		else
		{
			Image.imgTemp = null;
			Image.filenametemp = filename;
			Image.status = 7;
			int i;
			for (i = 0; i < 500; i++)
			{
				Thread.Sleep(5);
				bool flag2 = Image.status == 0;
				if (flag2)
				{
					break;
				}
			}
			bool flag3 = i == 500;
			if (flag3)
			{
				Cout.LogError("TOO LONG FOR CREATE IMAGE " + filename);
				Image.status = 0;
			}
			result = Image.imgTemp;
		}
		return result;
	}

	// Token: 0x06000557 RID: 1367 RVA: 0x0007F584 File Offset: 0x0007D784
	private static Image _createImage(byte[] imageData)
	{
		bool flag = Image.status != 0;
		Image result;
		if (flag)
		{
			Cout.LogError("CANNOT CREATE IMAGE(FromArray) WHEN CREATING OTHER IMAGE");
			result = null;
		}
		else
		{
			Image.imgTemp = null;
			Image.datatemp = imageData;
			Image.status = 4;
			int i;
			for (i = 0; i < 500; i++)
			{
				Thread.Sleep(5);
				bool flag2 = Image.status == 0;
				if (flag2)
				{
					break;
				}
			}
			bool flag3 = i == 500;
			if (flag3)
			{
				Cout.LogError("TOO LONG FOR CREATE IMAGE(FromArray)");
				Image.status = 0;
			}
			result = Image.imgTemp;
		}
		return result;
	}

	// Token: 0x06000558 RID: 1368 RVA: 0x0007F618 File Offset: 0x0007D818
	private static Image _createImage(Image src, int x, int y, int w, int h, int transform)
	{
		bool flag = Image.status != 0;
		Image result;
		if (flag)
		{
			Cout.LogError("CANNOT CREATE IMAGE(FromSrcPart) WHEN CREATING OTHER IMAGE");
			result = null;
		}
		else
		{
			Image.imgTemp = null;
			Image.imgSrcTemp = src;
			Image.xtemp = x;
			Image.ytemp = y;
			Image.wtemp = w;
			Image.htemp = h;
			Image.transformtemp = transform;
			Image.status = 5;
			int i;
			for (i = 0; i < 500; i++)
			{
				Thread.Sleep(5);
				bool flag2 = Image.status == 0;
				if (flag2)
				{
					break;
				}
			}
			bool flag3 = i == 500;
			if (flag3)
			{
				Cout.LogError("TOO LONG FOR CREATE IMAGE(FromSrcPart)");
				Image.status = 0;
			}
			result = Image.imgTemp;
		}
		return result;
	}

	// Token: 0x06000559 RID: 1369 RVA: 0x0007F6D0 File Offset: 0x0007D8D0
	private static Image _createImage(int w, int h)
	{
		bool flag = Image.status != 0;
		Image result;
		if (flag)
		{
			Cout.LogError("CANNOT CREATE IMAGE(w,h) WHEN CREATING OTHER IMAGE");
			result = null;
		}
		else
		{
			Image.imgTemp = null;
			Image.wtemp = w;
			Image.htemp = h;
			Image.status = 6;
			int i;
			for (i = 0; i < 500; i++)
			{
				Thread.Sleep(5);
				bool flag2 = Image.status == 0;
				if (flag2)
				{
					break;
				}
			}
			bool flag3 = i == 500;
			if (flag3)
			{
				Cout.LogError("TOO LONG FOR CREATE IMAGE(w,h)");
				Image.status = 0;
			}
			result = Image.imgTemp;
		}
		return result;
	}

	// Token: 0x0600055A RID: 1370 RVA: 0x0007F76C File Offset: 0x0007D96C
	public static byte[] loadData(string filename)
	{
		Image image = new Image();
		TextAsset textAsset = (TextAsset)Resources.Load(filename, typeof(TextAsset));
		bool flag = textAsset == null || textAsset.bytes == null || textAsset.bytes.Length == 0;
		if (flag)
		{
			throw new Exception("NULL POINTER EXCEPTION AT Image __createImage " + filename);
		}
		sbyte[] array = ArrayCast.cast(textAsset.bytes);
		Debug.LogError("CHIEU DAI MANG BYTE IMAGE CREAT = " + array.Length.ToString());
		return textAsset.bytes;
	}

	// Token: 0x0600055B RID: 1371 RVA: 0x0007F800 File Offset: 0x0007DA00
	private static Image __createImage(string filename)
	{
		Image image = new Image();
		Texture2D x = Resources.Load(filename) as Texture2D;
		bool flag = x == null;
		if (flag)
		{
			throw new Exception("NULL POINTER EXCEPTION AT Image __createImage " + filename);
		}
		image.texture = x;
		image.w = image.texture.width;
		image.h = image.texture.height;
		Image.setTextureQuality(image);
		return image;
	}

	// Token: 0x0600055C RID: 1372 RVA: 0x0007F874 File Offset: 0x0007DA74
	private static Image __createImageX(string filename)
	{
		Image image = new Image();
		Texture2D x = Resources.Load(filename) as Texture2D;
		bool flag = x == null;
		if (flag)
		{
			throw new Exception("NULL POINTER EXCEPTION AT Image __createImage " + filename);
		}
		Image result;
		try
		{
			image.texture = x;
			image.w = image.texture.width;
			image.h = image.texture.height;
			int[] array = new int[image.w * image.h];
			Color[] pixels = image.texture.GetPixels(0, 0, image.w, image.h);
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = Image.getIntByColor(pixels[i]);
			}
			int[] array2 = Hqx.HqxZoom(mGraphics.zoomLevel, array, image.w, image.h);
			int num = image.w * mGraphics.zoomLevel;
			int num2 = image.h * mGraphics.zoomLevel;
			image.texture = new Texture2D(num, num2);
			Color[] array3 = new Color[num * num2];
			for (int j = 0; j < array3.Length; j++)
			{
				ref Color ptr = ref array3[j];
				ptr = Image.getColor(array2[j]);
			}
			image.texture.SetPixels(array3);
			image.texture.Apply(false, false);
			image.w = num;
			image.h = num2;
			Image.setTextureQuality(image);
			result = image;
		}
		catch (Exception e)
		{
			Out.printError(e);
			result = image;
		}
		return result;
	}

	// Token: 0x0600055D RID: 1373 RVA: 0x0007FA24 File Offset: 0x0007DC24
	private static Image __createImage(byte[] imageData)
	{
		bool flag = imageData == null || imageData.Length == 0;
		Image result;
		if (flag)
		{
			Cout.LogError("Create Image from byte array fail");
			result = null;
		}
		else
		{
			Image image = new Image();
			try
			{
				image.texture.LoadImage(imageData);
				image.w = image.texture.width;
				image.h = image.texture.height;
				int[] array = new int[image.w * image.h];
				Color[] pixels = image.texture.GetPixels(0, 0, image.w, image.h);
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = Image.getIntByColor(pixels[i]);
				}
				int[] array2 = Hqx.HqxZoom(1, array, image.w, image.h);
				int num = image.w;
				int num2 = image.h;
				image.texture = new Texture2D(num, num2);
				Color[] array3 = new Color[num * num2];
				for (int j = 0; j < array3.Length; j++)
				{
					ref Color ptr = ref array3[j];
					ptr = Image.getColor(array2[j]);
				}
				image.texture.SetPixels(array3);
				image.texture.Apply(false, false);
				image.w = num;
				image.h = num2;
				Image.setTextureQuality(image);
				result = image;
			}
			catch (Exception)
			{
				Cout.LogError("CREAT IMAGE FROM ARRAY FAIL \n" + Environment.StackTrace);
				result = image;
			}
		}
		return result;
	}

	// Token: 0x0600055E RID: 1374 RVA: 0x0007FBCC File Offset: 0x0007DDCC
	public static Color getColor(int rgb)
	{
		int num = rgb & 255;
		int num2 = rgb >> 8 & 255;
		int num3 = rgb >> 16 & 255;
		int num4 = rgb >> 24 & 255;
		float b = (float)num / 256f;
		float g = (float)num2 / 256f;
		float r = (float)num3 / 256f;
		float a = (float)num4 / 256f;
		return new Color(r, g, b, a);
	}

	// Token: 0x0600055F RID: 1375 RVA: 0x0007FC40 File Offset: 0x0007DE40
	public static int getIntByColor(Color cl)
	{
		float num = cl.a * 255f;
		float num2 = cl.r * 255f;
		float num3 = cl.b * 255f;
		float num4 = cl.g * 255f;
		return ((int)num & 255) << 24 | ((int)num2 & 255) << 16 | ((int)num4 & 255) << 8 | ((int)num3 & 255);
	}

	// Token: 0x06000560 RID: 1376 RVA: 0x0007FCB4 File Offset: 0x0007DEB4
	private static Image __createImage(Image src, int x, int y, int w, int h, int transform)
	{
		Image image = new Image();
		image.texture = new Texture2D(w, h);
		y = src.texture.height - y - h;
		for (int i = 0; i < w; i++)
		{
			for (int j = 0; j < h; j++)
			{
				int num = i;
				bool flag = transform == 2;
				if (flag)
				{
					num = w - i;
				}
				int num2 = j;
				image.texture.SetPixel(i, j, src.texture.GetPixel(x + num, y + num2));
			}
		}
		image.texture.Apply();
		image.w = image.texture.width;
		image.h = image.texture.height;
		Image.setTextureQuality(image);
		return image;
	}

	// Token: 0x06000561 RID: 1377 RVA: 0x0007FD84 File Offset: 0x0007DF84
	private static Image __createEmptyImage()
	{
		return new Image();
	}

	// Token: 0x06000562 RID: 1378 RVA: 0x0007FD9C File Offset: 0x0007DF9C
	public static Image __createImage(int w, int h)
	{
		Image image = new Image();
		image.texture = new Texture2D(w, h, TextureFormat.RGBA32, false);
		Image.setTextureQuality(image);
		image.w = w;
		image.h = h;
		image.texture.Apply();
		return image;
	}

	// Token: 0x06000563 RID: 1379 RVA: 0x0007FDE8 File Offset: 0x0007DFE8
	public static int getImageWidth(Image image)
	{
		return image.getWidth();
	}

	// Token: 0x06000564 RID: 1380 RVA: 0x0007FE00 File Offset: 0x0007E000
	public static int getImageHeight(Image image)
	{
		return image.getHeight();
	}

	// Token: 0x06000565 RID: 1381 RVA: 0x0007FE18 File Offset: 0x0007E018
	public int getWidth()
	{
		return this.w;
	}

	// Token: 0x06000566 RID: 1382 RVA: 0x0007FE30 File Offset: 0x0007E030
	public int getHeight()
	{
		return this.h;
	}

	// Token: 0x06000567 RID: 1383 RVA: 0x0000A296 File Offset: 0x00008496
	private static void setTextureQuality(Image img)
	{
		Image.setTextureQuality(img.texture);
	}

	// Token: 0x06000568 RID: 1384 RVA: 0x0000A2A5 File Offset: 0x000084A5
	public static void setTextureQuality(Texture2D texture)
	{
		texture.anisoLevel = 0;
		texture.filterMode = FilterMode.Point;
		texture.mipMapBias = 0f;
		texture.wrapMode = TextureWrapMode.Clamp;
	}

	// Token: 0x06000569 RID: 1385 RVA: 0x0007FE48 File Offset: 0x0007E048
	public Color[] getColor()
	{
		return this.texture.GetPixels();
	}

	// Token: 0x0600056A RID: 1386 RVA: 0x0007FE18 File Offset: 0x0007E018
	public int getRealImageWidth()
	{
		return this.w;
	}

	// Token: 0x0600056B RID: 1387 RVA: 0x0007FE30 File Offset: 0x0007E030
	public int getRealImageHeight()
	{
		return this.h;
	}

	// Token: 0x0600056C RID: 1388 RVA: 0x0007FE68 File Offset: 0x0007E068
	public void getRGB(ref int[] data, int x1, int x2, int x, int y, int w, int h)
	{
		Color[] pixels = this.texture.GetPixels(x, this.h - 1 - y, w, h);
		for (int i = 0; i < pixels.Length; i++)
		{
			data[i] = mGraphics.getIntByColor(pixels[i]);
		}
	}

	// Token: 0x04000781 RID: 1921
	private const int INTERVAL = 5;

	// Token: 0x04000782 RID: 1922
	private const int MAXTIME = 500;

	// Token: 0x04000783 RID: 1923
	public Texture2D texture = new Texture2D(1, 1);

	// Token: 0x04000784 RID: 1924
	public static Image imgTemp;

	// Token: 0x04000785 RID: 1925
	public static string filenametemp;

	// Token: 0x04000786 RID: 1926
	public static byte[] datatemp;

	// Token: 0x04000787 RID: 1927
	public static Image imgSrcTemp;

	// Token: 0x04000788 RID: 1928
	public static int xtemp;

	// Token: 0x04000789 RID: 1929
	public static int ytemp;

	// Token: 0x0400078A RID: 1930
	public static int wtemp;

	// Token: 0x0400078B RID: 1931
	public static int htemp;

	// Token: 0x0400078C RID: 1932
	public static int transformtemp;

	// Token: 0x0400078D RID: 1933
	public int w;

	// Token: 0x0400078E RID: 1934
	public int h;

	// Token: 0x0400078F RID: 1935
	public static int status;

	// Token: 0x04000790 RID: 1936
	public Color colorBlend = Color.black;

	// Token: 0x04000791 RID: 1937
	public static int iA;
}
