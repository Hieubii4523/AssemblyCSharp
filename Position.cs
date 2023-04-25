using System;

// Token: 0x020000D2 RID: 210
public class Position
{
	// Token: 0x06000C09 RID: 3081 RVA: 0x0000BABB File Offset: 0x00009CBB
	public Position()
	{
		this.x = 0;
		this.y = 0;
	}

	// Token: 0x06000C0A RID: 3082 RVA: 0x0000BADA File Offset: 0x00009CDA
	public Position(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	// Token: 0x06000C0B RID: 3083 RVA: 0x0000BAF9 File Offset: 0x00009CF9
	public Position(int x, int y, int anchor)
	{
		this.x = x;
		this.y = y;
		this.anchor = anchor;
	}

	// Token: 0x06000C0C RID: 3084 RVA: 0x000E7C50 File Offset: 0x000E5E50
	public bool setDetectX(int xx, int num)
	{
		return CRes.abs(xx - this.x) <= num;
	}

	// Token: 0x06000C0D RID: 3085 RVA: 0x000E7C80 File Offset: 0x000E5E80
	public bool setDetectY(int yy, int num)
	{
		return CRes.abs(yy - this.y) <= num;
	}

	// Token: 0x04001304 RID: 4868
	public int x;

	// Token: 0x04001305 RID: 4869
	public int y;

	// Token: 0x04001306 RID: 4870
	public int anchor;

	// Token: 0x04001307 RID: 4871
	public sbyte depth;

	// Token: 0x04001308 RID: 4872
	public short index = -1;
}
