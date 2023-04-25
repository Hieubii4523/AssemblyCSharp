using System;

// Token: 0x02000046 RID: 70
public class idSaveImage
{
	// Token: 0x06000541 RID: 1345 RVA: 0x0000A266 File Offset: 0x00008466
	public idSaveImage(short id, sbyte[] msbyte)
	{
		this.id = id;
		this.mbytImage = msbyte;
	}

	// Token: 0x06000542 RID: 1346 RVA: 0x0000A27E File Offset: 0x0000847E
	public idSaveImage(string name, sbyte[] msbyte)
	{
		this.name = name;
		this.mbytImage = msbyte;
	}

	// Token: 0x0400077E RID: 1918
	public short id;

	// Token: 0x0400077F RID: 1919
	public sbyte[] mbytImage;

	// Token: 0x04000780 RID: 1920
	public string name;
}
