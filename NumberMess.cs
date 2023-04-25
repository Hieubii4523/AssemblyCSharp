using System;

// Token: 0x020000BF RID: 191
public class NumberMess
{
	// Token: 0x06000B4D RID: 2893 RVA: 0x000DADD4 File Offset: 0x000D8FD4
	public void update()
	{
		bool flag = this.yNum == 0;
		if (flag)
		{
			bool flag2 = CRes.random(50) == 0;
			if (flag2)
			{
				this.vNum = -CRes.random(2, 4);
				this.isUpdatevNum = true;
			}
		}
		else
		{
			bool flag3 = this.yNum > 0;
			if (flag3)
			{
				this.isUpdatevNum = false;
				this.vNum = 0;
				this.yNum = 0;
			}
		}
		bool flag4 = this.isUpdatevNum || this.yNum != 0;
		if (flag4)
		{
			this.yNum += this.vNum;
		}
		this.vNum++;
	}

	// Token: 0x040010E5 RID: 4325
	public int yNum;

	// Token: 0x040010E6 RID: 4326
	public int vNum;

	// Token: 0x040010E7 RID: 4327
	public bool isUpdatevNum;
}
