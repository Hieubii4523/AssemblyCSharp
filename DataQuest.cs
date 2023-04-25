using System;

// Token: 0x02000023 RID: 35
public class DataQuest
{
	// Token: 0x06000171 RID: 369 RVA: 0x000096F4 File Offset: 0x000078F4
	public DataQuest(sbyte typeQ)
	{
		this.typeQuest = typeQ;
	}

	// Token: 0x06000172 RID: 370 RVA: 0x0001C740 File Offset: 0x0001A940
	public void SetDataQuest(short ID, short numM, short numC)
	{
		this.IDItem = ID;
		this.numMax = numM;
		this.numCur = numC;
		bool flag = this.numCur > this.numMax;
		if (flag)
		{
			this.numCur = this.numMax;
		}
		bool flag2 = this.typeQuest == 1;
		if (flag2)
		{
			this.nameItem = MainMonster.getCatalogyMonster((int)ID).name;
		}
		else
		{
			bool flag3 = this.typeQuest == 2;
			if (flag3)
			{
				this.nameItem = DataQuest.nameItemQuest[(int)ID];
			}
		}
	}

	// Token: 0x06000173 RID: 371 RVA: 0x0001C7C4 File Offset: 0x0001A9C4
	public void loadNameAgain()
	{
		bool flag = this.typeQuest == 1;
		if (flag)
		{
			this.nameItem = MainMonster.getCatalogyMonster((int)this.IDItem).name;
		}
	}

	// Token: 0x0400027D RID: 637
	public const sbyte Q_GET_ITEM = 2;

	// Token: 0x0400027E RID: 638
	public const sbyte Q_KILL_MONSTER = 1;

	// Token: 0x0400027F RID: 639
	public const sbyte Q_TRANPORTER = 3;

	// Token: 0x04000280 RID: 640
	public const sbyte Q_TALK = 0;

	// Token: 0x04000281 RID: 641
	public sbyte typeQuest;

	// Token: 0x04000282 RID: 642
	public short IDItem;

	// Token: 0x04000283 RID: 643
	public short numMax;

	// Token: 0x04000284 RID: 644
	public short numCur;

	// Token: 0x04000285 RID: 645
	public string nameItem = string.Empty;

	// Token: 0x04000286 RID: 646
	public static string[] nameItemQuest = new string[]
	{
		"aa",
		"bb",
		"cc",
		"dd",
		"ee",
		"ff",
		"gg",
		"hh",
		"jj"
	};
}
