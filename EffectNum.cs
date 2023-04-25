using System;

// Token: 0x02000029 RID: 41
public class EffectNum : MainEffect
{
	// Token: 0x0600019C RID: 412 RVA: 0x0000983F File Offset: 0x00007A3F
	public EffectNum(string strContent, int x, int y, int typeColor)
	{
		this.createEffNum(strContent, x, y, typeColor);
	}

	// Token: 0x0600019D RID: 413 RVA: 0x0001E4E0 File Offset: 0x0001C6E0
	public EffectNum(string strContent, int x, int y, int typeColor, FrameImage fra, int frame)
	{
		bool flag = fra != null;
		if (flag)
		{
			this.fraImgEff = fra;
			this.frame = frame;
		}
		this.createEffNum(strContent, x, y, typeColor);
	}

	// Token: 0x0600019E RID: 414 RVA: 0x00009855 File Offset: 0x00007A55
	public EffectNum(int value, int valueAP, int x, int y, int typeColor)
	{
		this.createEffNum(value, valueAP, x, y, typeColor);
	}

	// Token: 0x0600019F RID: 415 RVA: 0x0001E51C File Offset: 0x0001C71C
	public void createEffNum(int value, int valueAP, int x, int y, int typeColor)
	{
		EffectNum.numPaintDam++;
		this.valueEffect = 1;
		this.isGravity = false;
		this.tick = 0;
		this.tickStop = 0;
		this.x = x;
		this.y = y;
		this.typeNum = typeColor;
		this.valueNum = value;
		this.valueAP = valueAP;
		this.vy = -CRes.random(7, 9);
		this.fRemove = CRes.random(26, 30);
		int num = EffectNum.numPaintDam % 9;
		bool flag = num % 3 != 0;
		if (flag)
		{
			bool flag2 = EffectNum.numPaintDam % 5 % 2 == 1;
			if (flag2)
			{
				this.vx = 3;
			}
			else
			{
				this.vx = -3;
			}
		}
		this.timeStop = 6 + num / 3;
		bool flag3 = this.typeNum != 16 && this.typeNum != 25;
		if (!flag3)
		{
			this.valuePaintDam = value;
			this.timeStop = 8;
			bool flag4 = value >= 1000000;
			if (flag4)
			{
				this.isTrieuDam = true;
				this.valuePaintDam = 500000;
				this.stepSuperDam = (value - this.valuePaintDam) / 10;
				bool flag5 = this.stepSuperDam > 300000;
				if (flag5)
				{
					this.stepSuperDam = 300000;
				}
				this.levelPaint = 1;
				this.fRemove += 20;
			}
		}
	}

	// Token: 0x060001A0 RID: 416 RVA: 0x0001E678 File Offset: 0x0001C878
	public void createEffNum(string strContent, int x, int y, int typeColor)
	{
		this.valueEffect = 1;
		this.isGravity = false;
		this.tick = 0;
		this.strContent = strContent;
		this.x = x;
		this.y = y;
		this.typeNum = typeColor;
		this.fontPaint = mFont.tahoma_7b_white;
		bool flag = this.typeNum < 0;
		if (flag)
		{
			this.fontPaint = AvMain.setTextColorName(-typeColor);
		}
		else if (typeColor <= 5)
		{
			if (typeColor == 1)
			{
				this.vy = -2;
				this.fRemove = 16;
				this.fontPaint = mFont.tahoma_7b_yellow;
				return;
			}
			if (typeColor == 5)
			{
				this.fontPaint = mFont.tahoma_7_white;
			}
		}
		else if (typeColor != 8)
		{
			if (typeColor == 10)
			{
				this.vy = -1;
				this.fRemove = CRes.random(25, 35);
				return;
			}
			if (typeColor == 24)
			{
				this.vy = -2;
				this.fRemove = 16;
				this.fontPaint = mFont.tahoma_7b_violet;
				return;
			}
		}
		else
		{
			this.fontPaint = AvMain.setTextColor(typeColor);
		}
		bool flag2 = this.isGravity;
		if (flag2)
		{
			this.vy = -CRes.random(8, 12);
			this.fRemove = CRes.random(24, 30);
		}
		else
		{
			this.vy = -2;
			this.fRemove = 20;
		}
	}

	// Token: 0x060001A1 RID: 417 RVA: 0x0001E7C4 File Offset: 0x0001C9C4
	public override void paint(mGraphics g)
	{
		int num = 0;
		bool flag = this.fraImgEff != null;
		if (flag)
		{
			num = this.fraImgEff.frameWidth / 2;
			int num2 = mFont.tahoma_7b_white.getWidth(this.strContent) / 2;
			this.fraImgEff.drawFrame(this.frame, this.x - num2, this.y + 5, 0, 3, g);
		}
		switch (this.typeNum)
		{
		case 1:
			mFont.tahoma_7b_black.drawString(g, this.strContent, this.x + num + 1, this.y + 1, 2);
			this.fontPaint.drawString(g, this.strContent, this.x + num, this.y, 2);
			return;
		case 2:
			AvMain.Font3dWhite(g, this.strContent, this.x + num, this.y, 2);
			return;
		case 3:
			AvMain.FontBorderColor(g, this.strContent, this.x + num, this.y, 2, 1, 7);
			return;
		case 4:
			AvMain.FontBorderColor(g, this.strContent, this.x + num, this.y, 2, 4, 7);
			return;
		case 5:
			AvMain.Font3dColor(g, this.strContent, this.x + num, this.y, 2, 1);
			return;
		case 6:
			mFont.tahoma_7b_red.drawString(g, this.strContent, this.x + num, this.y, 2);
			return;
		case 7:
			AvMain.Font3dColor(g, this.strContent, this.x + num, this.y, 2, 5);
			return;
		case 9:
			AvMain.Font3dColor(g, this.strContent, this.x + num, this.y, 2, 6);
			return;
		case 10:
			mFont.tahoma_7b_yellow.drawString(g, this.strContent, this.x + num, this.y, 2);
			return;
		case 13:
		case 14:
		case 15:
		case 20:
		{
			NumberDam.paintSmall(g, this.valueNum, this.x + num, this.y, this.typeNum);
			bool flag2 = this.valueAP > 0;
			if (flag2)
			{
				NumberDam.paintSmall(g, this.valueAP, this.x + num + 12, this.y + 12, 19);
			}
			return;
		}
		case 16:
		{
			bool flag3 = this.isTrieuDam && this.valuePaintDam == this.valueNum;
			if (flag3)
			{
				bool flag4 = this.tickSuperDam % 4 <= 3 || this.tickSuperDam >= 8;
				if (flag4)
				{
					NumberDam.paintSmall(g, this.valuePaintDam, this.x + num, this.y, 23);
				}
			}
			else
			{
				NumberDam.paintSmall(g, this.valuePaintDam, this.x + num, this.y, this.typeNum);
			}
			bool flag5 = this.valueAP > 0;
			if (flag5)
			{
				NumberDam.paintSmall(g, this.valueAP, this.x + num + 12, this.y + 16, 19);
			}
			return;
		}
		case 17:
		{
			NumberDam.paintStringBig(g, this.valueNum, this.x + num, this.y, this.typeNum);
			bool flag6 = this.valueAP > 0;
			if (flag6)
			{
				NumberDam.paintSmall(g, this.valueAP, this.x + num + 12, this.y + 14, 19);
			}
			return;
		}
		case 21:
		case 22:
		case 25:
			NumberDam.paintSmall(g, this.valueNum, this.x + num, this.y, this.typeNum);
			return;
		case 24:
			mFont.tahoma_7b_black.drawString(g, this.strContent, this.x + num + 1, this.y + 1, 2);
			this.fontPaint.drawString(g, this.strContent, this.x + num, this.y, 2);
			return;
		}
		this.fontPaint.drawString(g, this.strContent, this.x + num, this.y, 2);
	}

	// Token: 0x060001A2 RID: 418 RVA: 0x0001EC0C File Offset: 0x0001CE0C
	public override void update()
	{
		this.f++;
		this.x += this.vx;
		this.y += this.vy;
		bool flag = this.f >= this.fRemove;
		if (flag)
		{
			this.isStop = true;
		}
		bool flag2 = this.isTrieuDam;
		if (flag2)
		{
			bool flag3 = this.valuePaintDam < this.valueNum;
			if (flag3)
			{
				this.valuePaintDam += this.stepSuperDam + CRes.random(10) * 100;
			}
			else
			{
				this.tickSuperDam++;
			}
			bool flag4 = this.valuePaintDam > this.valueNum;
			if (flag4)
			{
				this.valuePaintDam = this.valueNum;
			}
		}
		bool flag5 = this.tick > 0;
		if (flag5)
		{
			this.tick--;
		}
		this.tickStop++;
		bool flag6 = this.typeNum == 14 || this.typeNum == 13 || this.typeNum == 15 || this.typeNum == 20 || this.typeNum == 21 || this.typeNum == 22 || this.typeNum == 17 || this.typeNum == 16 || this.typeNum == 25;
		if (flag6)
		{
			bool flag7 = this.typeNum != 16 && this.f > this.fRemove - 6;
			if (flag7)
			{
				this.vy = 3;
			}
			else
			{
				bool flag8 = this.tickStop >= this.timeStop && this.vy < 0;
				if (flag8)
				{
					int num = CRes.abs(this.vy) / 2;
					bool flag9 = num < 2;
					if (flag9)
					{
						num = 2;
					}
					this.vy += num;
					bool flag10 = this.vy >= 0;
					if (flag10)
					{
						this.vy = 0;
						this.vx = 0;
					}
				}
			}
		}
		else
		{
			bool flag11 = this.isGravity && this.tick <= 0;
			if (flag11)
			{
				this.vy++;
			}
			bool flag12 = this.vy == 0 && this.tick == 0;
			if (flag12)
			{
				this.tick = 5;
			}
		}
		bool flag13 = this.tickSuperDam >= 6;
		if (flag13)
		{
			this.vy = -1;
		}
	}

	// Token: 0x040002BD RID: 701
	public const sbyte COLOR_NORMAL = 0;

	// Token: 0x040002BE RID: 702
	public const sbyte COLOR_XP = 1;

	// Token: 0x040002BF RID: 703
	public const sbyte COLOR_FIRE = 2;

	// Token: 0x040002C0 RID: 704
	public const sbyte COLOR_PLUS_HP = 3;

	// Token: 0x040002C1 RID: 705
	public const sbyte COLOR_PLUS_MP = 4;

	// Token: 0x040002C2 RID: 706
	public const sbyte COLOR_PUT_ITEM = 5;

	// Token: 0x040002C3 RID: 707
	public const sbyte COLOR_FIRE_PERSON = 6;

	// Token: 0x040002C4 RID: 708
	public const sbyte COLOR_EFF_CRI = 7;

	// Token: 0x040002C5 RID: 709
	public const sbyte COLOR_OPTION = 8;

	// Token: 0x040002C6 RID: 710
	public const sbyte COLOR_EFF_MON_FIRE = 9;

	// Token: 0x040002C7 RID: 711
	public const sbyte COLOR_EFF_BELI = 10;

	// Token: 0x040002C8 RID: 712
	public const sbyte COLOR_FIRE_RED = 11;

	// Token: 0x040002C9 RID: 713
	public const sbyte COLOR_BIG_NUMBER_SMALL_Y = 13;

	// Token: 0x040002CA RID: 714
	public const sbyte COLOR_BIG_NUMBER_SMALL_R = 14;

	// Token: 0x040002CB RID: 715
	public const sbyte COLOR_BIG_NUMBER_SMALL_W = 15;

	// Token: 0x040002CC RID: 716
	public const sbyte COLOR_BIG_CRI = 16;

	// Token: 0x040002CD RID: 717
	public const sbyte COLOR_BIG_MISS = 17;

	// Token: 0x040002CE RID: 718
	public const sbyte COLOR_WANTED = 18;

	// Token: 0x040002CF RID: 719
	public const sbyte COLOR_BIG_NUMBER_SMALL_V = 19;

	// Token: 0x040002D0 RID: 720
	public const sbyte COLOR_BIG_NUMBER_SMALL_G = 20;

	// Token: 0x040002D1 RID: 721
	public const sbyte COLOR_BIG_NUMBER_SMALL_EFF_R = 21;

	// Token: 0x040002D2 RID: 722
	public const sbyte COLOR_BIG_NUMBER_SMALL_EFF_B = 22;

	// Token: 0x040002D3 RID: 723
	public const sbyte COLOR_SUPER_BIG_CRI = 23;

	// Token: 0x040002D4 RID: 724
	public const sbyte COLOR_XP_SKILL = 24;

	// Token: 0x040002D5 RID: 725
	public const sbyte COLOR_HAP_THU = 25;

	// Token: 0x040002D6 RID: 726
	private string strContent;

	// Token: 0x040002D7 RID: 727
	private int typeNum;

	// Token: 0x040002D8 RID: 728
	private int tick;

	// Token: 0x040002D9 RID: 729
	private int valueNum;

	// Token: 0x040002DA RID: 730
	private int valueAP;

	// Token: 0x040002DB RID: 731
	private int timeStop;

	// Token: 0x040002DC RID: 732
	private int tickStop;

	// Token: 0x040002DD RID: 733
	private int xlechAP;

	// Token: 0x040002DE RID: 734
	private int valuePaintDam;

	// Token: 0x040002DF RID: 735
	private int tickSuperDam;

	// Token: 0x040002E0 RID: 736
	private int stepSuperDam;

	// Token: 0x040002E1 RID: 737
	private mFont fontPaint;

	// Token: 0x040002E2 RID: 738
	private bool isGravity;

	// Token: 0x040002E3 RID: 739
	private bool isTrieuDam;

	// Token: 0x040002E4 RID: 740
	public static int numPaintDam;
}
