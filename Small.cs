using System;

// Token: 0x020000EF RID: 239
public class Small
{
	// Token: 0x06000E4E RID: 3662 RVA: 0x00113D3C File Offset: 0x00111F3C
	public Small(mImage img, int id)
	{
		this.img = img;
		this.id = id;
		this.timePaint = 0;
		this.timeUpdate = 0;
		bool flag = this.img != null && img.image != null;
		if (flag)
		{
			this.wimg = mImage.getImageWidth(img.image);
			this.himg = mImage.getImageHeight(img.image);
		}
	}

	// Token: 0x06000E4F RID: 3663 RVA: 0x000090B5 File Offset: 0x000072B5
	public void paint(mGraphics g, int transform, int x, int y, int anchor)
	{
	}

	// Token: 0x06000E50 RID: 3664 RVA: 0x000090B5 File Offset: 0x000072B5
	public void update()
	{
	}

	// Token: 0x040015C6 RID: 5574
	public mImage img;

	// Token: 0x040015C7 RID: 5575
	public int id;

	// Token: 0x040015C8 RID: 5576
	public int wimg;

	// Token: 0x040015C9 RID: 5577
	public int himg;

	// Token: 0x040015CA RID: 5578
	public int timePaint;

	// Token: 0x040015CB RID: 5579
	public int timeUpdate;
}
