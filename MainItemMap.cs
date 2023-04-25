using System;

// Token: 0x0200007E RID: 126
public class MainItemMap : MainObject
{
	// Token: 0x06000780 RID: 1920 RVA: 0x0000AB0F File Offset: 0x00008D0F
	public MainItemMap()
	{
	}

	// Token: 0x06000781 RID: 1921 RVA: 0x0009E7F8 File Offset: 0x0009C9F8
	public MainItemMap(short ID)
	{
		this.IDItem = ID;
		this.Block = mSystem.new_M_Int(0, 2);
		this.IDImage = -1;
		this.layer = -1;
		this.dx = 0;
		this.dy = 0;
		this.isLoadDataOk = false;
	}

	// Token: 0x06000782 RID: 1922 RVA: 0x0009E84C File Offset: 0x0009CA4C
	public MainItemMap(short IDItem, short IDImage, int dx, int dy, int[][] Block, sbyte layer)
	{
		this.IDItem = IDItem;
		this.IDImage = IDImage;
		this.dx = dx;
		this.dy = dy;
		this.Block = Block;
		this.layer = layer;
		this.isLoadDataOk = true;
	}

	// Token: 0x06000783 RID: 1923 RVA: 0x000090B5 File Offset: 0x000072B5
	public override void paint(mGraphics g)
	{
	}

	// Token: 0x06000784 RID: 1924 RVA: 0x000090B5 File Offset: 0x000072B5
	public override void update()
	{
	}

	// Token: 0x06000785 RID: 1925 RVA: 0x0009E89C File Offset: 0x0009CA9C
	public virtual bool isInScreen()
	{
		bool flag = (this.hOne == 0 || this.wOne == 0) && this.TypeItem != 1;
		if (flag)
		{
			MainImage imageAll = ObjectData.getImageAll(this.IDImage, ObjectData.HashImageItemMap, 0);
			bool flag2 = imageAll.img != null;
			if (flag2)
			{
				this.wOne = mImage.getImageWidth(imageAll.img.image);
				this.hOne = mImage.getImageHeight(imageAll.img.image);
			}
		}
		bool flag3 = this.x + this.dx + this.wOne < MainScreen.cameraMain.xCam || this.x + this.dx - this.wOne > MainScreen.cameraMain.xCam + MotherCanvas.w || this.y + this.dy + this.hOne < MainScreen.cameraMain.yCam || this.y + this.dy - this.hOne > MainScreen.cameraMain.yCam + MotherCanvas.h;
		return !flag3;
	}

	// Token: 0x04000B6E RID: 2926
	public const sbyte ITEM_MAP = 0;

	// Token: 0x04000B6F RID: 2927
	public const sbyte EFF_MAP = 1;

	// Token: 0x04000B70 RID: 2928
	public const sbyte BOAT_MAP = 1;

	// Token: 0x04000B71 RID: 2929
	public sbyte TypeItem;

	// Token: 0x04000B72 RID: 2930
	public sbyte layer;

	// Token: 0x04000B73 RID: 2931
	public short IDItem;

	// Token: 0x04000B74 RID: 2932
	public short IDImage;

	// Token: 0x04000B75 RID: 2933
	public int[][] Block;

	// Token: 0x04000B76 RID: 2934
	public mImage img;

	// Token: 0x04000B77 RID: 2935
	public bool isLoadDataOk = true;
}
