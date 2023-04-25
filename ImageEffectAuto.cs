using System;

// Token: 0x0200004B RID: 75
public class ImageEffectAuto
{
	// Token: 0x06000573 RID: 1395 RVA: 0x0000A307 File Offset: 0x00008507
	public ImageEffectAuto(int Id)
	{
		this.imageId = Id;
		this.img = mImage.createImage("/effauto/eff_" + Id.ToString() + ".png");
		this.timeRemove = GameCanvas.timeNow;
	}

	// Token: 0x06000574 RID: 1396 RVA: 0x00080038 File Offset: 0x0007E238
	public static mImage setImage(int Id)
	{
		ImageEffectAuto imageEffectAuto = (ImageEffectAuto)ImageEffectAuto.hashImageEffAuto.get(string.Empty + Id.ToString());
		bool flag = imageEffectAuto == null;
		if (flag)
		{
			imageEffectAuto = new ImageEffectAuto(Id);
			ImageEffectAuto.hashImageEffAuto.put(string.Empty + Id.ToString(), imageEffectAuto);
		}
		else
		{
			imageEffectAuto.timeRemove = GameCanvas.timeNow;
		}
		return imageEffectAuto.img;
	}

	// Token: 0x06000575 RID: 1397 RVA: 0x0000A344 File Offset: 0x00008544
	public static void SetRemoveAll()
	{
		ImageEffectAuto.hashImageEffAuto.clear();
	}

	// Token: 0x04000796 RID: 1942
	public static MyHashTable hashImageEffAuto = new MyHashTable();

	// Token: 0x04000797 RID: 1943
	private long timeRemove;

	// Token: 0x04000798 RID: 1944
	private int imageId;

	// Token: 0x04000799 RID: 1945
	private mImage img;
}
