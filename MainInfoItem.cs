using System;

// Token: 0x0200007C RID: 124
public class MainInfoItem
{
	// Token: 0x06000742 RID: 1858 RVA: 0x0000A9F7 File Offset: 0x00008BF7
	public MainInfoItem(sbyte id, int value)
	{
		this.id = id;
		this.value = value;
	}

	// Token: 0x06000743 RID: 1859 RVA: 0x0000AA16 File Offset: 0x00008C16
	public MainInfoItem(sbyte id, int value, sbyte colorM)
	{
		this.id = id;
		this.value = value;
		this.colorMain = colorM;
	}

	// Token: 0x06000744 RID: 1860 RVA: 0x0000AA3C File Offset: 0x00008C3C
	public MainInfoItem(string name, sbyte color, sbyte percent)
	{
		this.name = name;
		this.color = color;
		this.ispercent = percent;
		this.colorMain = -1;
	}

	// Token: 0x06000745 RID: 1861 RVA: 0x0000AA69 File Offset: 0x00008C69
	public MainInfoItem(string name, int value)
	{
		this.name = name;
		this.value = value;
	}

	// Token: 0x04000B19 RID: 2841
	public sbyte id;

	// Token: 0x04000B1A RID: 2842
	public sbyte color;

	// Token: 0x04000B1B RID: 2843
	public sbyte ispercent;

	// Token: 0x04000B1C RID: 2844
	public sbyte colorMain = -1;

	// Token: 0x04000B1D RID: 2845
	public int value;

	// Token: 0x04000B1E RID: 2846
	public string name;
}
