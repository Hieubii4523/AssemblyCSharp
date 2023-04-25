using System;

// Token: 0x0200007B RID: 123
public class MainImage
{
	// Token: 0x0600073D RID: 1853 RVA: 0x0000A9DE File Offset: 0x00008BDE
	public MainImage()
	{
	}

	// Token: 0x0600073E RID: 1854 RVA: 0x0009C90C File Offset: 0x0009AB0C
	public MainImage(mImage im)
	{
		this.img = im;
		this.count = 0L;
		this.w = (short)mImage.getImageWidth(im.image);
		this.h = (short)mImage.getImageHeight(im.image);
	}

	// Token: 0x0600073F RID: 1855 RVA: 0x0009C964 File Offset: 0x0009AB64
	public void set_W_H()
	{
		bool flag = this.img != null;
		if (flag)
		{
			this.w = (short)mImage.getImageWidth(this.img.image);
			this.h = (short)mImage.getImageHeight(this.img.image);
		}
	}

	// Token: 0x06000740 RID: 1856 RVA: 0x0009C9B0 File Offset: 0x0009ABB0
	public void set_Frame(int hOne)
	{
		bool flag = this.img != null;
		if (flag)
		{
			this.h = (short)mImage.getImageHeight(this.img.image);
			this.w = (short)mImage.getImageWidth(this.img.image);
			this.frame = (short)((int)this.h / hOne);
		}
	}

	// Token: 0x06000741 RID: 1857 RVA: 0x0009CA0C File Offset: 0x0009AC0C
	public void set_Frame()
	{
		bool flag = this.img != null;
		if (flag)
		{
			this.h = (short)mImage.getImageHeight(this.img.image);
			this.w = (short)mImage.getImageWidth(this.img.image);
			this.frame = ((this.w <= 0) ? 1 : (this.h / this.w));
		}
	}

	// Token: 0x04000B13 RID: 2835
	public mImage img;

	// Token: 0x04000B14 RID: 2836
	public short w;

	// Token: 0x04000B15 RID: 2837
	public short h;

	// Token: 0x04000B16 RID: 2838
	public short frame = -1;

	// Token: 0x04000B17 RID: 2839
	public long count = -1L;

	// Token: 0x04000B18 RID: 2840
	public int timeImageNull;
}
