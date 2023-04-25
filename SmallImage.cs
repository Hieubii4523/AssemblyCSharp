using System;

// Token: 0x020000F0 RID: 240
public class SmallImage
{
	// Token: 0x06000E51 RID: 3665 RVA: 0x0000BEE7 File Offset: 0x0000A0E7
	public SmallImage(int id, int x, int y, int w, int h)
	{
		this.id = (short)id;
		this.x = (short)x;
		this.y = (short)y;
		this.w = (short)w;
		this.h = (short)h;
	}

	// Token: 0x06000E52 RID: 3666 RVA: 0x0000B6E4 File Offset: 0x000098E4
	public SmallImage()
	{
	}

	// Token: 0x06000E53 RID: 3667 RVA: 0x000090B5 File Offset: 0x000072B5
	public static void loadBigRMS()
	{
	}

	// Token: 0x06000E54 RID: 3668 RVA: 0x0000BF1B File Offset: 0x0000A11B
	public static void freeBig()
	{
		mSystem.gc();
	}

	// Token: 0x06000E55 RID: 3669 RVA: 0x0000BF1B File Offset: 0x0000A11B
	public static void loadBigImage()
	{
		mSystem.gc();
	}

	// Token: 0x06000E56 RID: 3670 RVA: 0x0000BF24 File Offset: 0x0000A124
	public static void init()
	{
		SmallImage.instance = null;
		SmallImage.instance = new SmallImage();
	}

	// Token: 0x06000E57 RID: 3671 RVA: 0x000090B5 File Offset: 0x000072B5
	public void readData(sbyte[] data)
	{
	}

	// Token: 0x06000E58 RID: 3672 RVA: 0x00113DAC File Offset: 0x00111FAC
	public static void readImage(sbyte[] data)
	{
		try
		{
			DataInputStream dataInputStream = new DataInputStream(new ByteArrayInputStream(data));
			int num = (int)dataInputStream.readShort();
			bool flag = num > 600;
			if (flag)
			{
				num = 600;
			}
			SmallImage.smallImg = new int[num][];
			for (int i = 0; i < num; i++)
			{
				SmallImage.smallImg[i] = new int[5];
				SmallImage.smallImg[i][0] = dataInputStream.readUnsignedByte();
				SmallImage.smallImg[i][1] = (int)dataInputStream.readShort();
				SmallImage.smallImg[i][2] = (int)dataInputStream.readShort();
				SmallImage.smallImg[i][3] = (int)dataInputStream.readShort();
				SmallImage.smallImg[i][4] = (int)dataInputStream.readShort();
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000E59 RID: 3673 RVA: 0x000090B5 File Offset: 0x000072B5
	public static void clearHastable()
	{
	}

	// Token: 0x06000E5A RID: 3674 RVA: 0x00113E74 File Offset: 0x00112074
	public static void drawSmallImage(mGraphics g, int id, int x, int y, int transform, int anchor, int index)
	{
		int num = 0;
		MainImage imageAll = ObjectData.getImageAll((short)id, ObjectData.HashImageCharPart, 10000);
		bool flag = imageAll.img != null;
		if (flag)
		{
			g.drawRegion(imageAll.img, 0, 0, (int)imageAll.w, (int)imageAll.h, transform, (float)(x + num), (float)y, anchor);
		}
	}

	// Token: 0x06000E5B RID: 3675 RVA: 0x000090B5 File Offset: 0x000072B5
	public static void update()
	{
	}

	// Token: 0x040015CC RID: 5580
	public static int[][] smallImg;

	// Token: 0x040015CD RID: 5581
	public static SmallImage instance;

	// Token: 0x040015CE RID: 5582
	public static mImage[] imgbig;

	// Token: 0x040015CF RID: 5583
	public static mImage imgEmpty;

	// Token: 0x040015D0 RID: 5584
	public static sbyte[] newSmallVersion;

	// Token: 0x040015D1 RID: 5585
	public short id;

	// Token: 0x040015D2 RID: 5586
	public short x;

	// Token: 0x040015D3 RID: 5587
	public short y;

	// Token: 0x040015D4 RID: 5588
	public short w;

	// Token: 0x040015D5 RID: 5589
	public short h;
}
