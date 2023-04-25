using System;

// Token: 0x0200008B RID: 139
public class Main_Attribute
{
	// Token: 0x060008C9 RID: 2249 RVA: 0x0000AEF1 File Offset: 0x000090F1
	public Main_Attribute(sbyte type, short value, short valueP, string name, MainInfoItem[] minfo)
	{
		this.type = type;
		this.value = value;
		this.valuePlus = valueP;
		this.name = name;
		this.minfo = minfo;
	}

	// Token: 0x04000DCE RID: 3534
	public sbyte type;

	// Token: 0x04000DCF RID: 3535
	public short value;

	// Token: 0x04000DD0 RID: 3536
	public short valuePlus;

	// Token: 0x04000DD1 RID: 3537
	public string name;

	// Token: 0x04000DD2 RID: 3538
	public MainInfoItem[] minfo;
}
