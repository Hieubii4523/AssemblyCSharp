using System;
using System.Collections;

// Token: 0x0200004A RID: 74
public class ImageEffect
{
	// Token: 0x0600056E RID: 1390 RVA: 0x0007FEB8 File Offset: 0x0007E0B8
	public ImageEffect(int Id)
	{
		this.IdImage = Id;
		try
		{
			this.img = mImage.createImage("/eff/g" + Id.ToString() + ".png");
		}
		catch (Exception)
		{
		}
		this.timeRemove = GameCanvas.timeNow;
	}

	// Token: 0x0600056F RID: 1391 RVA: 0x0007FF1C File Offset: 0x0007E11C
	public static mImage setImage(int Id)
	{
		ImageEffect imageEffect = (ImageEffect)ImageEffect.hashImageEff.get(string.Empty + Id.ToString());
		bool flag = imageEffect == null;
		if (flag)
		{
			imageEffect = new ImageEffect(Id);
			ImageEffect.hashImageEff.put(string.Empty + Id.ToString(), imageEffect);
		}
		else
		{
			imageEffect.timeRemove = GameCanvas.timeNow;
		}
		return imageEffect.img;
	}

	// Token: 0x06000570 RID: 1392 RVA: 0x0007FF94 File Offset: 0x0007E194
	public static void SetRemove(short time)
	{
		mVector mVector = new mVector();
		IDictionaryEnumerator enumerator = ImageEffect.hashImageEff.GetEnumerator();
		while (enumerator.MoveNext())
		{
			ImageEffect imageEffect = (ImageEffect)enumerator.Value;
			bool flag = (GameCanvas.timeNow - imageEffect.timeRemove) / 1000L > (long)time;
			if (flag)
			{
				string o = (string)enumerator.Key;
				mVector.addElement(o);
			}
		}
		for (int i = 0; i < mVector.size(); i++)
		{
			ImageEffect.hashImageEff.Remove((string)mVector.elementAt(i));
		}
	}

	// Token: 0x06000571 RID: 1393 RVA: 0x0000A2ED File Offset: 0x000084ED
	public static void SetRemoveAll()
	{
		ImageEffect.hashImageEff.clear();
	}

	// Token: 0x04000792 RID: 1938
	public static MyHashTable hashImageEff = new MyHashTable();

	// Token: 0x04000793 RID: 1939
	private long timeRemove;

	// Token: 0x04000794 RID: 1940
	private int IdImage;

	// Token: 0x04000795 RID: 1941
	private mImage img;
}
