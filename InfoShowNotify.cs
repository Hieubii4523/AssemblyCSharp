using System;

// Token: 0x02000052 RID: 82
public class InfoShowNotify
{
	// Token: 0x06000594 RID: 1428 RVA: 0x0000A44D File Offset: 0x0000864D
	public InfoShowNotify(string str, sbyte type)
	{
		this.strShow = str;
		this.type = type;
	}

	// Token: 0x06000595 RID: 1429 RVA: 0x00080CB4 File Offset: 0x0007EEB4
	public void setValue(mFont f)
	{
		bool flag = this.strShow == null || this.strShow.Length == 0;
		if (flag)
		{
			this.isRemove = true;
		}
		else
		{
			this.time = 0;
			this.isRemove = false;
			this.setFont(f);
			bool flag2 = this.type == 10;
			if (flag2)
			{
				this.speed = 0;
				this.maxtime = 70;
				this.x = Interface_Game.wInfoServer / 2;
			}
			else
			{
				this.w = this.fontpaint.getWidth(this.strShow);
				bool flag3 = this.iconClan >= 0;
				if (flag3)
				{
					this.w += 30;
				}
				this.x = 0;
				this.maxtime = 500;
				this.y = 25;
				bool flag4 = this.w < Interface_Game.wInfoServer;
				if (flag4)
				{
					this.speed = 0;
					this.maxtime = 150;
					this.x = Interface_Game.wInfoServer / 2 + this.w / 2;
				}
				else
				{
					this.speed = 2;
				}
			}
		}
	}

	// Token: 0x06000596 RID: 1430 RVA: 0x00080DCC File Offset: 0x0007EFCC
	public void setFont(mFont f)
	{
		bool flag = f != null;
		if (flag)
		{
			this.fontpaint = f;
		}
		else
		{
			sbyte b = this.type;
			sbyte b2 = b;
			switch (b2)
			{
			case 0:
				this.fontpaint = mFont.tahoma_7_white;
				break;
			case 1:
				this.fontpaint = mFont.tahoma_7b_white;
				break;
			case 2:
				this.fontpaint = mFont.tahoma_7b_yellow;
				break;
			case 3:
			case 4:
				break;
			case 5:
				this.fontpaint = mFont.tahoma_7b_white;
				break;
			default:
				if (b2 == 10)
				{
					this.fontpaint = mFont.tahoma_7_white;
				}
				break;
			}
		}
	}

	// Token: 0x06000597 RID: 1431 RVA: 0x00080E60 File Offset: 0x0007F060
	public void update()
	{
		bool flag = this.isPaint;
		if (flag)
		{
			this.time++;
			this.x += this.speed;
		}
		bool flag2 = this.time > this.maxtime || this.x > this.w + Interface_Game.wInfoServer;
		if (flag2)
		{
			this.isRemove = true;
		}
		else
		{
			bool flag3 = this.y > 0;
			if (flag3)
			{
				this.y -= 10;
				bool flag4 = this.y < 0;
				if (flag4)
				{
					this.y = 0;
				}
			}
		}
	}

	// Token: 0x06000598 RID: 1432 RVA: 0x00080F04 File Offset: 0x0007F104
	public void paintQuickChat(mGraphics g, int x, int y)
	{
		bool flag = this.type == 3;
		if (flag)
		{
			AvMain.FontBorderSmall(g, this.strShow, x, y, 1, 0);
		}
		else
		{
			bool flag2 = this.type == 4;
			if (flag2)
			{
				AvMain.FontBorderSmall(g, this.strShow, x, y, 1, 5);
			}
		}
	}

	// Token: 0x040007F3 RID: 2035
	public const sbyte INFO_NOR = 0;

	// Token: 0x040007F4 RID: 2036
	public const sbyte INFO_IMP = 1;

	// Token: 0x040007F5 RID: 2037
	public const sbyte INFO_SPE = 2;

	// Token: 0x040007F6 RID: 2038
	public const sbyte INFO_LOL_MEM = 3;

	// Token: 0x040007F7 RID: 2039
	public const sbyte INFO_LOL_CAPTION = 4;

	// Token: 0x040007F8 RID: 2040
	public const sbyte INFO_FIGHT = 5;

	// Token: 0x040007F9 RID: 2041
	public const sbyte INFO_PLAYER = 10;

	// Token: 0x040007FA RID: 2042
	public string strShow;

	// Token: 0x040007FB RID: 2043
	public bool isRemove;

	// Token: 0x040007FC RID: 2044
	public bool isPaint = true;

	// Token: 0x040007FD RID: 2045
	public short iconClan = -1;

	// Token: 0x040007FE RID: 2046
	public mFont fontpaint = mFont.tahoma_7_white;

	// Token: 0x040007FF RID: 2047
	public int time;

	// Token: 0x04000800 RID: 2048
	public int x;

	// Token: 0x04000801 RID: 2049
	public int y;

	// Token: 0x04000802 RID: 2050
	public int w;

	// Token: 0x04000803 RID: 2051
	public int speed;

	// Token: 0x04000804 RID: 2052
	public int maxtime;

	// Token: 0x04000805 RID: 2053
	public sbyte type;
}
