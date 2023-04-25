using System;

// Token: 0x02000028 RID: 40
public class EffectData
{
	// Token: 0x06000199 RID: 409 RVA: 0x000097EA File Offset: 0x000079EA
	public EffectData(sbyte[] data, sbyte[] dataImg)
	{
		this.data = data;
		this.img = mImage.createImage(dataImg, 0, dataImg.Length);
	}

	// Token: 0x0600019A RID: 410 RVA: 0x00009813 File Offset: 0x00007A13
	public EffectData()
	{
	}

	// Token: 0x0600019B RID: 411 RVA: 0x00009825 File Offset: 0x00007A25
	public void setData(sbyte[] data, sbyte[] dataImg)
	{
		this.data = data;
		this.img = mImage.createImage(dataImg, 0, dataImg.Length);
	}

	// Token: 0x040002BA RID: 698
	public sbyte[] data;

	// Token: 0x040002BB RID: 699
	public long count = -1L;

	// Token: 0x040002BC RID: 700
	public mImage img;
}
