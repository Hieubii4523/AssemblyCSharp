using System;

// Token: 0x0200002E RID: 46
public class Effect_UpLv_Item
{
	// Token: 0x06000366 RID: 870 RVA: 0x0006F008 File Offset: 0x0006D208
	public void paintUpgradeEffect(int x, int y, int upgrade, int w, mGraphics g, int lech, bool isBorder)
	{
		bool flag = upgrade <= 0;
		if (!flag)
		{
			this.lv = this.getValueUpgrade(upgrade);
			int num = 0;
			int num2 = this.lv;
			if (isBorder)
			{
				bool flag2 = upgrade >= 11;
				if (flag2)
				{
					g.setColor(this.colorBorder[GameCanvas.gameTick / 6 % 5][6]);
					g.drawRect(x - w / 2 - lech, y - w / 2 - lech, w, w);
				}
				else
				{
					g.setColor(this.colorBorder[num2][6]);
					g.drawRect(x - w / 2 - lech, y - w / 2 - lech, w, w);
				}
			}
			int[] array = (upgrade < 11) ? this.size : this.size15;
			for (int i = num; i < array.Length; i++)
			{
				int num3 = this.upgradeEffectX(GameCanvas.gameTick - i * this.wnew, w);
				bool flag3 = num3 != -1;
				if (flag3)
				{
					int num4 = x - w / 2 + num3;
					int num5 = y - w / 2 + this.upgradeEffectY(GameCanvas.gameTick - i * this.wnew, w);
					int num6 = i;
					bool flag4 = num6 > 5;
					if (flag4)
					{
						num6 = 5;
					}
					g.setColor(this.colorBorder[num2][num6]);
					int num7 = array[i];
					int num8 = 0;
					bool flag5 = num3 <= w && num7 == 2;
					if (flag5)
					{
						num8 = 1;
					}
					g.fillRect(num4 - num7 / 2 - lech, num5 - num7 / 2 - lech + num8, num7, num7);
				}
			}
			for (int j = num; j < array.Length; j++)
			{
				int num9 = this.upgradeEffectX2(GameCanvas.gameTick + w - j * this.wnew, w);
				bool flag6 = num9 != -1;
				if (flag6)
				{
					int num10 = x - w / 2 + num9;
					int num11 = y - w / 2 + this.upgradeEffectY(GameCanvas.gameTick + w - j * this.wnew, w);
					int num12 = j;
					bool flag7 = num12 > 5;
					if (flag7)
					{
						num12 = 5;
					}
					g.setColor(this.colorBorder[num2][num12]);
					int num13 = array[j];
					int num14 = 0;
					bool flag8 = num9 == 0 && num13 == 2;
					if (flag8)
					{
						num14 = 1;
					}
					g.fillRect(num10 - num13 / 2 - lech + num14, num11 - num13 / 2 - lech, num13, num13);
				}
			}
		}
	}

	// Token: 0x06000367 RID: 871 RVA: 0x0006F2A4 File Offset: 0x0006D4A4
	public int upgradeEffectY(int tick, int w)
	{
		int num = (tick + this.valueTest) % (4 * w);
		bool flag = 0 <= num && num < w;
		int result;
		if (flag)
		{
			result = 0;
		}
		else
		{
			bool flag2 = w <= num && num < w * 2;
			if (flag2)
			{
				result = num % w;
			}
			else
			{
				bool flag3 = w * 2 <= num && num < w * 3;
				if (flag3)
				{
					result = w;
				}
				else
				{
					result = w - num % w;
				}
			}
		}
		return result;
	}

	// Token: 0x06000368 RID: 872 RVA: 0x0006F310 File Offset: 0x0006D510
	public int upgradeEffectX(int tick, int w)
	{
		int num = (tick + this.valueTest) % (4 * w);
		bool flag = 0 <= num && num < w;
		int result;
		if (flag)
		{
			result = num % w;
		}
		else
		{
			bool flag2 = w <= num && num < w * 2;
			if (flag2)
			{
				result = w;
			}
			else
			{
				result = -1;
			}
		}
		return result;
	}

	// Token: 0x06000369 RID: 873 RVA: 0x0006F35C File Offset: 0x0006D55C
	public int upgradeEffectX2(int tick, int w)
	{
		int num = (tick + this.valueTest) % (4 * w);
		bool flag = w <= num && num < w * 2;
		int result;
		if (flag)
		{
			result = 0;
		}
		else
		{
			bool flag2 = w * 2 <= num && num < w * 3;
			if (flag2)
			{
				result = w - (w - num % w);
			}
			else
			{
				bool flag3 = this.valueTest == 0;
				if (flag3)
				{
					this.valueTest = w * 2;
				}
				else
				{
					this.valueTest = 0;
				}
				result = -1;
			}
		}
		return result;
	}

	// Token: 0x0600036A RID: 874 RVA: 0x0006F3D8 File Offset: 0x0006D5D8
	public int getValueUpgrade(int up)
	{
		bool flag = up <= 2;
		int result;
		if (flag)
		{
			result = 0;
		}
		else
		{
			bool flag2 = up <= 5;
			if (flag2)
			{
				result = 1;
			}
			else
			{
				bool flag3 = up <= 8;
				if (flag3)
				{
					result = 2;
				}
				else
				{
					bool flag4 = up <= 9;
					if (flag4)
					{
						result = 3;
					}
					else
					{
						bool flag5 = up <= 10;
						if (flag5)
						{
							result = 4;
						}
						else
						{
							bool flag6 = up <= 11;
							if (flag6)
							{
								result = 1;
							}
							else
							{
								bool flag7 = up <= 12;
								if (flag7)
								{
									result = 2;
								}
								else
								{
									bool flag8 = up <= 13;
									if (flag8)
									{
										result = 3;
									}
									else
									{
										bool flag9 = up <= 14;
										if (flag9)
										{
											result = 4;
										}
										else
										{
											result = 5;
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

	// Token: 0x0400055B RID: 1371
	private int wnew = 1;

	// Token: 0x0400055C RID: 1372
	private int[][] colorBorder = new int[][]
	{
		new int[]
		{
			16777215,
			16777215,
			15724527,
			15724527,
			12698049,
			12698049,
			10526880
		},
		new int[]
		{
			2684726,
			2684726,
			2481970,
			2481970,
			2213420,
			2213420,
			2529579
		},
		new int[]
		{
			11830015,
			11830015,
			10975725,
			10975725,
			10121178,
			10121178,
			8215216
		},
		new int[]
		{
			16580155,
			16580155,
			15264311,
			15264311,
			13948466,
			13948466,
			11184937
		},
		new int[]
		{
			16122935,
			16122935,
			14746675,
			14746675,
			13304878,
			13304878,
			11272999
		},
		new int[]
		{
			1832452,
			1832452,
			16122935,
			16122935,
			16777215,
			16777215,
			15724527
		},
		new int[]
		{
			1832452,
			1832452,
			16122935,
			2684726,
			16777215,
			16777215,
			15724527
		},
		new int[]
		{
			1832452,
			1832452,
			16122935,
			2684726,
			11830015,
			16777215,
			15724527
		}
	};

	// Token: 0x0400055D RID: 1373
	private int[] size = new int[]
	{
		2,
		1,
		1,
		1,
		1,
		1
	};

	// Token: 0x0400055E RID: 1374
	private int[] size15 = new int[]
	{
		2,
		2,
		1,
		1,
		1,
		1,
		1,
		1
	};

	// Token: 0x0400055F RID: 1375
	private int valueTest;

	// Token: 0x04000560 RID: 1376
	private int lv;
}
