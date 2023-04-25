using System;

// Token: 0x0200000F RID: 15
public class Camera
{
	// Token: 0x0600007B RID: 123 RVA: 0x00013B94 File Offset: 0x00011D94
	public void setAll(int xLimit, int yLimit, int xCam, int yCam)
	{
		this.xLimit = xLimit;
		this.yLimit = yLimit;
		bool flag = this.yLimit < 0;
		if (flag)
		{
			this.yLimit = 0;
		}
		bool flag2 = this.xLimit < 0;
		if (flag2)
		{
			this.xLimit = 0;
		}
		bool flag3 = xCam > xLimit;
		if (flag3)
		{
			xCam = xLimit;
		}
		bool flag4 = xCam < 0;
		if (flag4)
		{
			xCam = 0;
		}
		bool flag5 = yCam > yLimit;
		if (flag5)
		{
			yCam = yLimit;
		}
		bool flag6 = yCam < 0;
		if (flag6)
		{
			yCam = 0;
		}
		this.xCam = xCam;
		this.yCam = yCam;
		this.xTo = xCam;
		this.yTo = yCam;
	}

	// Token: 0x0600007C RID: 124 RVA: 0x00013C34 File Offset: 0x00011E34
	public void setAllTo(int xLimit, int yLimit, int xCam, int yCam)
	{
		this.xLimit = xLimit;
		this.yLimit = yLimit;
		bool flag = this.yLimit < 0;
		if (flag)
		{
			this.yLimit = 0;
		}
		bool flag2 = this.xLimit < 0;
		if (flag2)
		{
			this.xLimit = 0;
		}
		this.xTo = xCam;
		this.yTo = yCam;
	}

	// Token: 0x0600007D RID: 125 RVA: 0x00009256 File Offset: 0x00007456
	public void setCamera(int xCam, int yCam)
	{
		this.xCam = xCam;
		this.yCam = yCam;
		this.xTo = xCam;
		this.yTo = yCam;
	}

	// Token: 0x0600007E RID: 126 RVA: 0x00013C8C File Offset: 0x00011E8C
	public void setCameraWithLim(int xCam, int yCam, bool isRoom)
	{
		bool flag = xCam < 0;
		if (flag)
		{
			xCam = 0;
		}
		bool flag2 = xCam > this.xLimit;
		if (flag2)
		{
			xCam = this.xLimit;
		}
		if (isRoom)
		{
			bool flag3 = yCam < 0;
			if (flag3)
			{
				yCam = 0;
			}
		}
		else
		{
			bool flag4 = yCam < -50;
			if (flag4)
			{
				yCam = -50;
			}
		}
		bool flag5 = yCam > this.yLimit;
		if (flag5)
		{
			yCam = this.yLimit;
		}
		this.xCam = xCam;
		this.yCam = yCam;
		this.xTo = xCam;
		this.yTo = yCam;
	}

	// Token: 0x0600007F RID: 127 RVA: 0x00009275 File Offset: 0x00007475
	public void moveCamera(int xTo, int yTo)
	{
		this.xTo = xTo;
		this.yTo = yTo;
	}

	// Token: 0x06000080 RID: 128 RVA: 0x00013D1C File Offset: 0x00011F1C
	public void UpdateCamera()
	{
		bool flag = this.xCam != this.xTo;
		if (flag)
		{
			this.cmvx = this.xTo - this.xCam << 1;
			this.cmdx += this.cmvx;
			this.xCam += this.cmdx >> 4;
			this.cmdx &= 15;
			bool flag2 = this.xCam < 0;
			if (flag2)
			{
				this.xCam = 0;
			}
			bool flag3 = this.xCam > this.xLimit;
			if (flag3)
			{
				this.xCam = this.xLimit;
			}
		}
		bool flag4 = this.yCam != this.yTo;
		if (flag4)
		{
			this.cmvy = this.yTo - this.yCam << 1;
			this.cmdy += this.cmvy;
			this.yCam += this.cmdy >> 4;
			this.cmdy &= 15;
			bool flag5 = this.yCam < 0;
			if (flag5)
			{
				this.yCam = 0;
			}
			bool flag6 = this.yCam > this.yLimit;
			if (flag6)
			{
				this.yCam = this.yLimit;
			}
		}
	}

	// Token: 0x06000081 RID: 129 RVA: 0x00013E68 File Offset: 0x00012068
	public void UpdateCameraGameScreen()
	{
		bool flag = this.xCam != this.xTo;
		if (flag)
		{
			this.cmvx = this.xTo - this.xCam << 1;
			this.cmdx += this.cmvx;
			this.xCam += this.cmdx >> 4;
			this.cmdx &= 15;
			bool flag2 = this.xCam < 0;
			if (flag2)
			{
				this.xCam = 0;
			}
			bool flag3 = this.xCam > this.xLimit;
			if (flag3)
			{
				this.xCam = this.xLimit;
			}
		}
		bool flag4 = this.yCam != this.yTo;
		if (flag4)
		{
			this.cmvy = this.yTo - this.yCam << 1;
			this.cmdy += this.cmvy;
			this.yCam += this.cmdy >> 4;
			this.cmdy &= 15;
			bool flag5 = this.yCam > this.yLimit;
			if (flag5)
			{
				this.yCam = this.yLimit;
			}
		}
	}

	// Token: 0x04000104 RID: 260
	public static Camera instance;

	// Token: 0x04000105 RID: 261
	public int xCam;

	// Token: 0x04000106 RID: 262
	public int yCam;

	// Token: 0x04000107 RID: 263
	public int xTo;

	// Token: 0x04000108 RID: 264
	public int yTo;

	// Token: 0x04000109 RID: 265
	public int xLimit;

	// Token: 0x0400010A RID: 266
	public int yLimit;

	// Token: 0x0400010B RID: 267
	public long timeDelay;

	// Token: 0x0400010C RID: 268
	private int cmvx;

	// Token: 0x0400010D RID: 269
	private int cmdx;

	// Token: 0x0400010E RID: 270
	private int cmvy;

	// Token: 0x0400010F RID: 271
	private int cmdy;
}
