using System;

// Token: 0x02000098 RID: 152
public class mLine
{
	// Token: 0x060009AE RID: 2478 RVA: 0x0000B22F File Offset: 0x0000942F
	public mLine(int x1, int y1, int x2, int y2, int cl)
	{
		this.x1 = x1;
		this.y1 = y1;
		this.x2 = x2;
		this.y2 = y2;
		this.setColor(cl);
	}

	// Token: 0x060009AF RID: 2479 RVA: 0x000C47D8 File Offset: 0x000C29D8
	public void setColor(int rgb)
	{
		int num = rgb & 255;
		int num2 = rgb >> 8 & 255;
		int num3 = rgb >> 16 & 255;
		this.b = (float)num / 256f;
		this.g = (float)num2 / 256f;
		this.r = (float)num3 / 256f;
		this.a = 255f;
	}

	// Token: 0x04000F63 RID: 3939
	public int x1;

	// Token: 0x04000F64 RID: 3940
	public int x2;

	// Token: 0x04000F65 RID: 3941
	public int y1;

	// Token: 0x04000F66 RID: 3942
	public int y2;

	// Token: 0x04000F67 RID: 3943
	public float r;

	// Token: 0x04000F68 RID: 3944
	public float b;

	// Token: 0x04000F69 RID: 3945
	public float g;

	// Token: 0x04000F6A RID: 3946
	public float a;
}
