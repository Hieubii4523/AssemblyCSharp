using System;

// Token: 0x020000C2 RID: 194
public class ObjMove
{
	// Token: 0x06000B5E RID: 2910 RVA: 0x0000B83E File Offset: 0x00009A3E
	public ObjMove(sbyte cat, short id, short x, short y)
	{
		this.typeObj = cat;
		this.id = id;
		this.x = x;
		this.y = y;
	}

	// Token: 0x0400111E RID: 4382
	public sbyte typeObj;

	// Token: 0x0400111F RID: 4383
	public short id;

	// Token: 0x04001120 RID: 4384
	public short x;

	// Token: 0x04001121 RID: 4385
	public short y;

	// Token: 0x04001122 RID: 4386
	public bool isRemove;
}
