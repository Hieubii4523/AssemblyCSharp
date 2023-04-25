using System;

// Token: 0x0200004E RID: 78
public class InfoArchi
{
	// Token: 0x0600057C RID: 1404 RVA: 0x0000A35E File Offset: 0x0000855E
	public InfoArchi()
	{
	}

	// Token: 0x0600057D RID: 1405 RVA: 0x000800B0 File Offset: 0x0007E2B0
	public InfoArchi(string name, string info, int valueCur, int valueMax, short idIcon, sbyte typeReward)
	{
		this.name = name;
		this.info = info;
		this.valueMax = valueMax;
		this.valueCur = valueCur;
		this.idIcon = idIcon;
		this.typeReward = typeReward;
		int num = 260;
		bool flag = num > MotherCanvas.w;
		if (flag)
		{
			num = MotherCanvas.w;
		}
		num -= 130;
		this.maxLechInfo = mFont.tahoma_7_black.getWidth(info) - num;
		bool flag2 = this.maxLechInfo > 0;
		if (flag2)
		{
			this.maxLechInfo += 30;
		}
	}

	// Token: 0x0400079A RID: 1946
	public string name;

	// Token: 0x0400079B RID: 1947
	public string info;

	// Token: 0x0400079C RID: 1948
	public int valueMax;

	// Token: 0x0400079D RID: 1949
	public int valueCur;

	// Token: 0x0400079E RID: 1950
	public int maxLechInfo;

	// Token: 0x0400079F RID: 1951
	public short idIcon;

	// Token: 0x040007A0 RID: 1952
	public sbyte typeReward = -1;

	// Token: 0x040007A1 RID: 1953
	public static sbyte REWARD_OFF = -1;

	// Token: 0x040007A2 RID: 1954
	public static sbyte REWARD_DOING;

	// Token: 0x040007A3 RID: 1955
	public static sbyte REWARD_READY = 1;

	// Token: 0x040007A4 RID: 1956
	public static sbyte REWARD_GOT = 2;
}
