using System;

// Token: 0x02000030 RID: 48
public class FrameImage
{
	// Token: 0x0600036E RID: 878 RVA: 0x0006F608 File Offset: 0x0006D808
	public FrameImage(mImage img, int width, int height)
	{
		this.imgFrame = img;
		this.frameWidth = width;
		this.frameHeight = height;
		this.nFrame = mImage.getImageHeight(img.image) / height;
	}

	// Token: 0x0600036F RID: 879 RVA: 0x0006F65C File Offset: 0x0006D85C
	public FrameImage(mImage img, int width, int height, int maxNumFrame)
	{
		this.imgFrame = img;
		this.frameWidth = width;
		this.frameHeight = height;
		this.maxNumFrame = maxNumFrame;
		this.nFrame = mImage.getImageWidth(this.imgFrame.image) / width * maxNumFrame;
	}

	// Token: 0x06000370 RID: 880 RVA: 0x0006F6C0 File Offset: 0x0006D8C0
	public FrameImage(mImage img, int width, int height, int maxNumFrame, sbyte frameSuper)
	{
		this.indexSuper = (int)frameSuper;
		this.imgFrame = img;
		this.frameWidth = width;
		this.frameHeight = height;
		this.maxNumFrame = maxNumFrame;
		this.nFrame = mImage.getImageWidth(this.imgFrame.image) / width * maxNumFrame;
	}

	// Token: 0x06000371 RID: 881 RVA: 0x0006F72C File Offset: 0x0006D92C
	public FrameImage(int ID, int width, int height)
	{
		this.Id = ID;
		this.frameWidth = width;
		this.frameHeight = height;
		this.imgFrame = this.getImage();
		bool flag = this.imgFrame != null && this.imgFrame.image != null;
		if (flag)
		{
			this.nFrame = mImage.getImageHeight(this.imgFrame.image) / height;
			this.maxNumFrame = this.nFrame;
		}
	}

	// Token: 0x06000372 RID: 882 RVA: 0x0006F7BC File Offset: 0x0006D9BC
	public FrameImage(mImage img, int numframe)
	{
		this.imgFrame = img;
		this.nFrame = numframe;
		this.maxNumFrame = this.nFrame;
		this.frameWidth = mImage.getImageWidth(this.imgFrame.image);
		this.frameHeight = mImage.getImageHeight(this.imgFrame.image) / numframe;
	}

	// Token: 0x06000373 RID: 883 RVA: 0x0006F830 File Offset: 0x0006DA30
	public FrameImage(int ID, int numframe)
	{
		this.Id = ID;
		this.nFrame = numframe;
		this.maxNumFrame = this.nFrame;
		this.imgFrame = this.getImage();
		this.isFormFrame = true;
		bool flag = this.imgFrame != null && this.imgFrame.image != null;
		if (flag)
		{
			this.frameWidth = mImage.getImageWidth(this.imgFrame.image);
			this.frameHeight = mImage.getImageHeight(this.imgFrame.image) / numframe;
		}
	}

	// Token: 0x06000374 RID: 884 RVA: 0x0006F8D4 File Offset: 0x0006DAD4
	public FrameImage(int ID, int width, int height, int width2, int height2)
	{
		this.Id = ID;
		bool lowGraphic = GameCanvas.lowGraphic;
		if (lowGraphic)
		{
			this.frameWidth = width2;
			this.frameHeight = height2;
			this.lowG = true;
		}
		else
		{
			this.frameWidth = width;
			this.frameHeight = height;
		}
		this.imgFrame = this.getImage();
		bool flag = this.imgFrame != null && this.imgFrame.image != null;
		if (flag)
		{
			this.nFrame = mImage.getImageHeight(this.imgFrame.image) / this.frameHeight;
			this.maxNumFrame = this.nFrame;
		}
	}

	// Token: 0x06000375 RID: 885 RVA: 0x00009AE1 File Offset: 0x00007CE1
	public FrameImage(int ID, int width, int height, int maxNumFrame)
	{
		this.createFrameImgNew(ID, width, height, maxNumFrame);
	}

	// Token: 0x06000376 RID: 886 RVA: 0x0006F990 File Offset: 0x0006DB90
	public FrameImage(mImage img, int ID, int width, int height, int maxNumFrame)
	{
		this.Id = ID;
		this.frameWidth = width;
		this.frameHeight = height;
		this.maxNumFrame = maxNumFrame;
		this.imgFrame = img;
		bool flag = this.imgFrame != null && this.imgFrame.image != null;
		if (flag)
		{
			this.nFrame = mImage.getImageWidth(this.imgFrame.image) / width * maxNumFrame;
		}
	}

	// Token: 0x06000377 RID: 887 RVA: 0x00009B0C File Offset: 0x00007D0C
	public FrameImage(int ID, int width, int height, sbyte maxNumFrame, sbyte frameSuper)
	{
		this.indexSuper = (int)frameSuper;
		this.createFrameImgNew(ID, width, height, (int)maxNumFrame);
	}

	// Token: 0x06000378 RID: 888 RVA: 0x0006FA1C File Offset: 0x0006DC1C
	public FrameImage(int ID, int width, int height, int width2, int height2, int maxNumFrame)
	{
		this.Id = ID;
		bool lowGraphic = GameCanvas.lowGraphic;
		if (lowGraphic)
		{
			this.frameWidth = width2;
			this.frameHeight = height2;
			this.lowG = true;
		}
		else
		{
			this.frameWidth = width;
			this.frameHeight = height;
		}
		this.maxNumFrame = maxNumFrame;
		this.imgFrame = this.getImage();
		bool flag = this.imgFrame != null && this.imgFrame.image != null;
		if (flag)
		{
			this.nFrame = mImage.getImageWidth(this.imgFrame.image) / this.frameWidth * maxNumFrame;
		}
	}

	// Token: 0x06000379 RID: 889 RVA: 0x0006FAD4 File Offset: 0x0006DCD4
	public void createFrameImgNew(int ID, int width, int height, int maxNumFrame)
	{
		this.Id = ID;
		this.frameWidth = width;
		this.frameHeight = height;
		this.maxNumFrame = maxNumFrame;
		this.imgFrame = this.getImage();
		bool flag = this.imgFrame != null && this.imgFrame.image != null;
		if (flag)
		{
			this.nFrame = mImage.getImageWidth(this.imgFrame.image) / width * maxNumFrame;
		}
	}

	// Token: 0x0600037A RID: 890 RVA: 0x0006FB48 File Offset: 0x0006DD48
	public void drawFrame(int idx, int x, int y, int trans, int orthor, mGraphics g)
	{
		bool flag = this.imgFrame == null;
		if (flag)
		{
			this.imgFrame = this.getImage();
			bool flag2 = this.imgFrame != null && this.imgFrame.image != null;
			if (flag2)
			{
				bool flag3 = this.isFormFrame;
				if (flag3)
				{
					this.frameWidth = mImage.getImageWidth(this.imgFrame.image);
					this.frameHeight = mImage.getImageHeight(this.imgFrame.image) / this.nFrame;
				}
				else
				{
					this.nFrame = mImage.getImageHeight(this.imgFrame.image) / this.frameHeight;
					this.maxNumFrame = this.nFrame;
				}
			}
		}
		else
		{
			bool flag4 = idx >= 0 && idx < this.nFrame;
			if (flag4)
			{
				g.drawRegion(this.imgFrame, 0, idx * this.frameHeight, this.frameWidth, this.frameHeight, trans, (float)x, (float)y, orthor);
			}
		}
	}

	// Token: 0x0600037B RID: 891 RVA: 0x0006FC44 File Offset: 0x0006DE44
	public mImage getImageFrame()
	{
		bool flag = this.imgFrame != null;
		mImage result;
		if (flag)
		{
			result = this.imgFrame;
		}
		else
		{
			bool flag2 = this.lowG;
			if (flag2)
			{
				this.imgFrame = ObjectData.getImageAll((short)this.Id, ObjectData.HashImageEffClientLow, 25000).img;
			}
			else
			{
				this.imgFrame = ObjectData.getImageAll((short)this.Id, ObjectData.HashImageEffClient, 24000).img;
			}
			result = this.imgFrame;
		}
		return result;
	}

	// Token: 0x0600037C RID: 892 RVA: 0x0006FCC8 File Offset: 0x0006DEC8
	public mImage getImage()
	{
		bool flag = this.lowG;
		mImage img;
		if (flag)
		{
			img = ObjectData.getImageAll((short)this.Id, ObjectData.HashImageEffClientLow, 25000).img;
		}
		else
		{
			img = ObjectData.getImageAll((short)this.Id, ObjectData.HashImageEffClient, 24000).img;
		}
		return img;
	}

	// Token: 0x0600037D RID: 893 RVA: 0x0006FD20 File Offset: 0x0006DF20
	public void drawFrameNew_BeginSuper(int idx, int x, int y, int trans, int orthor, mGraphics g)
	{
		int num = idx + this.indexSuper * this.maxNumFrame;
		bool flag = this.imgFrame == null;
		if (flag)
		{
			this.imgFrame = this.getImage();
			bool flag2 = this.imgFrame != null && this.imgFrame.image != null;
			if (flag2)
			{
				bool flag3 = this.isFormFrame;
				if (flag3)
				{
					this.frameWidth = mImage.getImageWidth(this.imgFrame.image);
					this.frameHeight = mImage.getImageHeight(this.imgFrame.image) / this.nFrame;
				}
				else
				{
					this.nFrame = mImage.getImageWidth(this.imgFrame.image) / this.frameWidth * this.maxNumFrame;
				}
			}
		}
		else
		{
			bool flag4 = num >= 0 && num < this.nFrame;
			if (flag4)
			{
				g.drawRegion(this.imgFrame, num / this.maxNumFrame * this.frameWidth, num % this.maxNumFrame * this.frameHeight, this.frameWidth, this.frameHeight, trans, (float)x, (float)y, orthor);
			}
		}
	}

	// Token: 0x0600037E RID: 894 RVA: 0x0006FE3C File Offset: 0x0006E03C
	public void drawFrameNew(int idx, int x, int y, int trans, int orthor, mGraphics g)
	{
		bool flag = this.imgFrame == null;
		if (flag)
		{
			this.imgFrame = this.getImage();
			bool flag2 = this.imgFrame != null && this.imgFrame.image != null;
			if (flag2)
			{
				bool flag3 = this.isFormFrame;
				if (flag3)
				{
					this.frameWidth = mImage.getImageWidth(this.imgFrame.image);
					this.frameHeight = mImage.getImageHeight(this.imgFrame.image) / this.nFrame;
				}
				else
				{
					this.nFrame = mImage.getImageWidth(this.imgFrame.image) / this.frameWidth * this.maxNumFrame;
				}
			}
		}
		else
		{
			bool flag4 = idx >= 0 && idx < this.nFrame;
			if (flag4)
			{
				g.drawRegion(this.imgFrame, idx / this.maxNumFrame * this.frameWidth, idx % this.maxNumFrame * this.frameHeight, this.frameWidth, this.frameHeight, trans, (float)x, (float)y, orthor);
			}
		}
	}

	// Token: 0x04000565 RID: 1381
	public int frameWidth;

	// Token: 0x04000566 RID: 1382
	public int frameHeight;

	// Token: 0x04000567 RID: 1383
	public int nFrame = 1;

	// Token: 0x04000568 RID: 1384
	public int maxNumFrame = 1;

	// Token: 0x04000569 RID: 1385
	public int indexSuper;

	// Token: 0x0400056A RID: 1386
	public mImage imgFrame;

	// Token: 0x0400056B RID: 1387
	private int Id = -1;

	// Token: 0x0400056C RID: 1388
	private bool lowG;

	// Token: 0x0400056D RID: 1389
	private bool isFormFrame;
}
