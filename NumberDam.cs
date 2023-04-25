using System;

// Token: 0x020000BE RID: 190
public class NumberDam
{
	// Token: 0x06000B45 RID: 2885 RVA: 0x000DA6EC File Offset: 0x000D88EC
	public static void paintSmall(mGraphics g, int value, int x, int y, int type)
	{
		FrameImage fraNum = NumberDam.getFraNum(type);
		bool flag = fraNum == null;
		if (flag)
		{
			NumberDam.loadImg(type);
		}
		else
		{
			int num = CRes.abs(value);
			sbyte b = NumberDam.checkLenght((long)num);
			int num2 = 8;
			int num3 = 0;
			if (type != 16)
			{
				if (type == 23)
				{
					num2 = 15;
					goto IL_66;
				}
				if (type != 25)
				{
					goto IL_66;
				}
			}
			num3 += 16;
			num2 = 12;
			IL_66:
			int num4 = 10;
			num3 += (int)(b - 1) * (num2 / 2);
			bool flag2 = value < 0;
			if (flag2)
			{
				num3 += 5;
			}
			for (int i = 0; i < (int)b; i++)
			{
				int num5 = num % num4;
				int idx = (int)((sbyte)(num5 / (num4 / 10)));
				num4 *= 10;
				fraNum.drawFrameNew(idx, x + num3, y, 0, 3, g);
				num3 -= num2;
				bool flag3 = type == 23 && i % 3 == 2;
				if (flag3)
				{
					num3 -= 2;
				}
			}
			bool flag4 = value < 0;
			if (flag4)
			{
				fraNum.drawFrameNew(11, x + num3 - 2, y, 0, 3, g);
			}
			if (type != 16)
			{
				if (type == 25)
				{
					num3 -= 28;
					bool flag5 = NumberDam.fraImgHapThu == null;
					if (flag5)
					{
						NumberDam.loadImg(type);
					}
					else
					{
						NumberDam.fraImgHapThu.drawFrame(GameCanvas.gameTick / 4 % NumberDam.fraImgHapThu.nFrame, x + num3, y, 0, 3, g);
					}
				}
			}
			else
			{
				num3 -= 10;
				bool flag6 = NumberDam.fraImgCri == null;
				if (flag6)
				{
					NumberDam.loadImg(type);
				}
				else
				{
					NumberDam.fraImgCri.drawFrame(GameCanvas.gameTick / 3 % NumberDam.fraImgCri.nFrame, x + num3, y, 0, 3, g);
				}
			}
		}
	}

	// Token: 0x06000B46 RID: 2886 RVA: 0x000DA8B4 File Offset: 0x000D8AB4
	public static void paintSmallWanted(mGraphics g, int value, int x, int y)
	{
		FrameImage fraNum = NumberDam.getFraNum(18);
		bool flag = fraNum == null;
		if (flag)
		{
			NumberDam.loadImg(18);
		}
		else
		{
			long num = (long)value * 100L;
			sbyte b = NumberDam.checkLenght(num);
			int num2 = 8;
			int num3 = 0;
			long num4 = 10L;
			num3 += (int)(b - 1) * (num2 / 2) + (int)((b - 1) / 3 * 3);
			for (int i = 0; i < (int)b; i++)
			{
				long num5 = num % num4;
				int idx = (int)(num5 / (num4 / 10L));
				num4 *= 10L;
				fraNum.drawFrameNew(idx, x + num3, y, 0, 3, g);
				bool flag2 = i % 3 == 2 && i < (int)(b - 1);
				if (flag2)
				{
					num3 -= 3;
					fraNum.drawFrameNew(10, x + num3, y, 0, 3, g);
				}
				num3 -= num2;
			}
		}
	}

	// Token: 0x06000B47 RID: 2887 RVA: 0x000DA988 File Offset: 0x000D8B88
	public static void paintStringBig(mGraphics g, int value, int x, int y, int type)
	{
		bool flag = type == 17;
		if (flag)
		{
			bool flag2 = NumberDam.fraImgMiss == null;
			if (flag2)
			{
				NumberDam.loadImg(type);
			}
			else
			{
				NumberDam.fraImgMiss.drawFrameNew(0, x, y, 0, 3, g);
			}
		}
	}

	// Token: 0x06000B48 RID: 2888 RVA: 0x000DA9D0 File Offset: 0x000D8BD0
	private static FrameImage getFraNum(int value)
	{
		if (!true)
		{
		}
		FrameImage result;
		switch (value)
		{
		case 13:
			result = NumberDam.fraImgSmallYellow;
			goto IL_A0;
		case 14:
			result = NumberDam.fraImgSmallRed;
			goto IL_A0;
		case 15:
			result = NumberDam.fraImgSmallWhite;
			goto IL_A0;
		case 16:
			result = NumberDam.fraImgBigRed;
			goto IL_A0;
		case 18:
			result = NumberDam.fraImgWanted;
			goto IL_A0;
		case 19:
			result = NumberDam.fraImgSmallViolet;
			goto IL_A0;
		case 20:
			result = NumberDam.fraImgSmallGreen;
			goto IL_A0;
		case 21:
			result = NumberDam.fraImgSmallEffRed;
			goto IL_A0;
		case 22:
			result = NumberDam.fraImgSmallEffBlue;
			goto IL_A0;
		case 23:
			result = NumberDam.fraImgSuperBig;
			goto IL_A0;
		case 25:
			result = NumberDam.fraImgSmallGreen;
			goto IL_A0;
		}
		result = null;
		IL_A0:
		if (!true)
		{
		}
		return result;
	}

	// Token: 0x06000B49 RID: 2889 RVA: 0x000DAA88 File Offset: 0x000D8C88
	public static sbyte checkLenght(long value)
	{
		bool flag = value < 10L;
		sbyte result;
		if (flag)
		{
			result = 1;
		}
		else
		{
			bool flag2 = value < 100L;
			if (flag2)
			{
				result = 2;
			}
			else
			{
				bool flag3 = value < 1000L;
				if (flag3)
				{
					result = 3;
				}
				else
				{
					bool flag4 = value < 10000L;
					if (flag4)
					{
						result = 4;
					}
					else
					{
						bool flag5 = value < 100000L;
						if (flag5)
						{
							result = 5;
						}
						else
						{
							bool flag6 = value < 1000000L;
							if (flag6)
							{
								result = 6;
							}
							else
							{
								bool flag7 = value < 10000000L;
								if (flag7)
								{
									result = 7;
								}
								else
								{
									bool flag8 = value < 100000000L;
									if (flag8)
									{
										result = 8;
									}
									else
									{
										bool flag9 = value < 1000000000L;
										if (flag9)
										{
											result = 9;
										}
										else
										{
											bool flag10 = value < 10000000000L;
											if (flag10)
											{
												result = 10;
											}
											else
											{
												result = 11;
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		return result;
	}

	// Token: 0x06000B4A RID: 2890 RVA: 0x000DAB6C File Offset: 0x000D8D6C
	private static void loadImg(int value)
	{
		switch (value)
		{
		case 13:
			NumberDam.fraImgSmallYellow = new FrameImage(237, 12, 12, 5);
			break;
		case 14:
			NumberDam.fraImgSmallRed = new FrameImage(235, 12, 12, 5);
			break;
		case 15:
			NumberDam.fraImgSmallWhite = new FrameImage(236, 12, 12, 5);
			break;
		case 16:
		case 23:
			NumberDam.fraImgSuperBig = new FrameImage(390, 22, 22, 5);
			NumberDam.fraImgBigRed = new FrameImage(231, 16, 16, 5);
			NumberDam.fraImgCri = new FrameImage(233, 32, 14);
			break;
		case 17:
			NumberDam.fraImgMiss = new FrameImage(232, 47, 14);
			break;
		case 18:
			NumberDam.fraImgWanted = new FrameImage(mImage.createImage("/interface/numwanted.png"), 7, 11, 5);
			break;
		case 19:
			NumberDam.fraImgSmallViolet = new FrameImage(234, 12, 12, 5);
			break;
		case 20:
			NumberDam.fraImgSmallGreen = new FrameImage(228, 12, 12, 5);
			break;
		case 21:
			NumberDam.fraImgSmallEffRed = new FrameImage(230, 12, 12, 5);
			break;
		case 22:
			NumberDam.fraImgSmallEffBlue = new FrameImage(229, 12, 12, 5);
			break;
		case 25:
			NumberDam.fraImgSmallGreen = new FrameImage(228, 12, 12, 5);
			NumberDam.fraImgHapThu = new FrameImage(399, 61, 16);
			break;
		}
	}

	// Token: 0x06000B4B RID: 2891 RVA: 0x000DAD08 File Offset: 0x000D8F08
	public static void paintSmallWantedPoster(mGraphics g, int value, int x, int y)
	{
		FrameImage fraNum = NumberDam.getFraNum(18);
		bool flag = fraNum == null;
		if (flag)
		{
			NumberDam.loadImg(18);
		}
		else
		{
			long num = (long)value;
			sbyte b = NumberDam.checkLenght(num);
			int num2 = 8;
			int num3 = 0;
			long num4 = 10L;
			num3 += (int)(b - 1) * (num2 / 2) + (int)((b - 1) / 3 * 3);
			for (int i = 0; i < (int)b; i++)
			{
				int idx = (int)(num % num4 / (num4 / 10L));
				num4 *= 10L;
				fraNum.drawFrameNew(idx, x + num3, y, 0, 3, g);
				bool flag2 = i % 3 == 2 && i < (int)(b - 1);
				if (flag2)
				{
					num3 -= 3;
					fraNum.drawFrameNew(10, x + num3, y, 0, 3, g);
				}
				num3 -= num2;
			}
		}
	}

	// Token: 0x040010D8 RID: 4312
	public static FrameImage fraImgSmallYellow;

	// Token: 0x040010D9 RID: 4313
	public static FrameImage fraImgSmallRed;

	// Token: 0x040010DA RID: 4314
	public static FrameImage fraImgSmallWhite;

	// Token: 0x040010DB RID: 4315
	public static FrameImage fraImgCri;

	// Token: 0x040010DC RID: 4316
	public static FrameImage fraImgMiss;

	// Token: 0x040010DD RID: 4317
	public static FrameImage fraImgBigRed;

	// Token: 0x040010DE RID: 4318
	public static FrameImage fraImgWanted;

	// Token: 0x040010DF RID: 4319
	public static FrameImage fraImgSmallViolet;

	// Token: 0x040010E0 RID: 4320
	public static FrameImage fraImgSmallGreen;

	// Token: 0x040010E1 RID: 4321
	public static FrameImage fraImgSmallEffRed;

	// Token: 0x040010E2 RID: 4322
	public static FrameImage fraImgSmallEffBlue;

	// Token: 0x040010E3 RID: 4323
	public static FrameImage fraImgSuperBig;

	// Token: 0x040010E4 RID: 4324
	public static FrameImage fraImgHapThu;
}
