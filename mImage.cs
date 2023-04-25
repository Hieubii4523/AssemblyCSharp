using System;

// Token: 0x02000097 RID: 151
public class mImage
{
	// Token: 0x060009A0 RID: 2464 RVA: 0x00073574 File Offset: 0x00071774
	public static string getLink(string str)
	{
		return str;
	}

	// Token: 0x060009A1 RID: 2465 RVA: 0x000C4564 File Offset: 0x000C2764
	public static string getUrlImage(string str)
	{
		return str.Replace("/", "_");
	}

	// Token: 0x060009A2 RID: 2466 RVA: 0x000C4588 File Offset: 0x000C2788
	public void setWH()
	{
		bool flag = this.image != null;
		if (flag)
		{
			this.w = mImage.getImageWidth(this.image);
			this.h = mImage.getImageHeight(this.image);
		}
	}

	// Token: 0x060009A3 RID: 2467 RVA: 0x000C45C8 File Offset: 0x000C27C8
	public static mImage createImage(string url)
	{
		mSystem.outz("vào load image=" + url);
		mImage mImage = new mImage();
		mImage result;
		try
		{
			bool flag = GameMidlet.DEVICE > 0;
			if (flag)
			{
				sbyte[] array = CRes.loadRMS("Main_Image" + mImage.getUrlImage(url));
				bool flag2 = array != null;
				if (flag2)
				{
					mImage = mImage.createImage(array, 0, array.Length);
					return mImage;
				}
			}
			try
			{
				mImage.image = Image.createImage("/x" + mGraphics.zoomLevel.ToString() + url);
			}
			catch (Exception)
			{
			}
			bool flag3 = mImage.image == null;
			if (flag3)
			{
				result = null;
			}
			else
			{
				result = mImage;
			}
		}
		catch (Exception)
		{
			result = mImage;
		}
		return result;
	}

	// Token: 0x060009A4 RID: 2468 RVA: 0x000C4694 File Offset: 0x000C2894
	public static mImage createImageAll(string url)
	{
		mImage mImage = new mImage();
		try
		{
			mImage.image = Image.createImage(url);
		}
		catch (Exception)
		{
		}
		bool flag = mImage.image == null;
		mImage result;
		if (flag)
		{
			result = null;
		}
		else
		{
			result = mImage;
		}
		return result;
	}

	// Token: 0x060009A5 RID: 2469 RVA: 0x000C46E4 File Offset: 0x000C28E4
	public static mImage createImage(int w, int h)
	{
		return new mImage
		{
			image = Image.createImage(w * mGraphics.zoomLevel, h * mGraphics.zoomLevel)
		};
	}

	// Token: 0x060009A6 RID: 2470 RVA: 0x000C4718 File Offset: 0x000C2918
	public static mImage createImage(sbyte[] data, int w, int h)
	{
		return new mImage
		{
			image = Image.createImage(data, 0, data.Length)
		};
	}

	// Token: 0x060009A7 RID: 2471 RVA: 0x000C4744 File Offset: 0x000C2944
	public TemGraphics getGraphics()
	{
		return new TemGraphics();
	}

	// Token: 0x060009A8 RID: 2472 RVA: 0x000C475C File Offset: 0x000C295C
	public static int getImageWidth(Image image)
	{
		return image.getWidth() / mGraphics.zoomLevel;
	}

	// Token: 0x060009A9 RID: 2473 RVA: 0x000C477C File Offset: 0x000C297C
	public static int getImageHeight(Image image)
	{
		return image.getHeight() / mGraphics.zoomLevel;
	}

	// Token: 0x060009AA RID: 2474 RVA: 0x000090B5 File Offset: 0x000072B5
	public void getRGB(int[] rgbData, int offset, int scanlength, int x, int y, int width, int height)
	{
	}

	// Token: 0x060009AB RID: 2475 RVA: 0x000C479C File Offset: 0x000C299C
	public static mImage createRGBImage(int[] rgb, int width, int height, bool processAlpha)
	{
		return new mImage
		{
			image = Image.createRGBImage(rgb, width, height, processAlpha)
		};
	}

	// Token: 0x060009AC RID: 2476 RVA: 0x000C47C4 File Offset: 0x000C29C4
	public static mImage scaleImage(mImage img, int w, int h)
	{
		return img;
	}

	// Token: 0x04000F60 RID: 3936
	public Image image;

	// Token: 0x04000F61 RID: 3937
	public int w;

	// Token: 0x04000F62 RID: 3938
	public int h;
}
