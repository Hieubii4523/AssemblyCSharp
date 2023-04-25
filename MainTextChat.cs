using System;

// Token: 0x0200008A RID: 138
public class MainTextChat
{
	// Token: 0x060008C6 RID: 2246 RVA: 0x000AF480 File Offset: 0x000AD680
	public MainTextChat(string text, sbyte color)
	{
		this.text = text;
		this.color = color;
	}

	// Token: 0x060008C7 RID: 2247 RVA: 0x000AF4D0 File Offset: 0x000AD6D0
	public MainTextChat(string text, string textRight, sbyte color, sbyte colorBg, sbyte typeBg)
	{
		this.text = text;
		this.color = color;
		this.color = colorBg;
		this.typeBg = typeBg;
		this.textRight = textRight;
	}

	// Token: 0x060008C8 RID: 2248 RVA: 0x000AF538 File Offset: 0x000AD738
	public void setTimePaint()
	{
		long num = (GameCanvas.timeNow - this.timeBegin) / 1000L;
		bool flag = num < 60L;
		if (flag)
		{
			this.textTime = 1.ToString() + T.phuttruoc;
		}
		else
		{
			bool flag2 = num < 3600L;
			if (flag2)
			{
				this.textTime = (num / 60L).ToString() + T.phuttruoc;
			}
			else
			{
				bool flag3 = num < 86400L;
				if (flag3)
				{
					this.textTime = string.Concat(new string[]
					{
						(num / 3600L).ToString(),
						T.gio,
						" ",
						(num % 3600L / 60L).ToString(),
						T.phuttruoc
					});
				}
				else
				{
					bool flag4 = num < 604800L;
					if (flag4)
					{
						this.textTime = (num / 86400L).ToString() + " " + T.ngaytruoc;
					}
					else
					{
						this.textTime = T.hon1tuan;
					}
				}
			}
		}
	}

	// Token: 0x04000DC2 RID: 3522
	public string text;

	// Token: 0x04000DC3 RID: 3523
	public string textRight = string.Empty;

	// Token: 0x04000DC4 RID: 3524
	public string textTime = string.Empty;

	// Token: 0x04000DC5 RID: 3525
	public string nameText;

	// Token: 0x04000DC6 RID: 3526
	public sbyte color;

	// Token: 0x04000DC7 RID: 3527
	public sbyte typeLeftRight = -1;

	// Token: 0x04000DC8 RID: 3528
	public sbyte typeBg;

	// Token: 0x04000DC9 RID: 3529
	public sbyte typeEvent;

	// Token: 0x04000DCA RID: 3530
	public sbyte lenghtText;

	// Token: 0x04000DCB RID: 3531
	public long timeBegin = -1L;

	// Token: 0x04000DCC RID: 3532
	public short IDMem = -1;

	// Token: 0x04000DCD RID: 3533
	public short IdText;
}
