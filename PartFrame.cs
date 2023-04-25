using System;

// Token: 0x020000C7 RID: 199
public class PartFrame
{
	// Token: 0x06000B81 RID: 2945 RVA: 0x0000B8C8 File Offset: 0x00009AC8
	public PartFrame(int dx, int dy, int idSmall)
	{
		this.idSmallImg = (short)idSmall;
		this.dx = (short)dx;
		this.dy = (short)dy;
	}

	// Token: 0x0400114E RID: 4430
	public short idSmallImg;

	// Token: 0x0400114F RID: 4431
	public short dx;

	// Token: 0x04001150 RID: 4432
	public short dy;

	// Token: 0x04001151 RID: 4433
	public sbyte flip;

	// Token: 0x04001152 RID: 4434
	public sbyte onTop;
}
