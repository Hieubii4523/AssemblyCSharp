using System;

// Token: 0x02000086 RID: 134
public class MainSkill
{
	// Token: 0x06000887 RID: 2183 RVA: 0x000ACC84 File Offset: 0x000AAE84
	public MainSkill(short ID, short typeEff)
	{
		this.typeEffSkill = typeEff;
		this.ID = ID;
		bool flag = ID >= 1010 && ID <= 1014;
		if (flag)
		{
			this.isBuffSpecNew = true;
		}
	}

	// Token: 0x06000888 RID: 2184 RVA: 0x0000AE1C File Offset: 0x0000901C
	public void setTypeBuff(sbyte isBuff, short buff, short timebuff)
	{
		this.typeBuff = isBuff;
		this.typeEffBuff = buff;
		this.timebuff = timebuff;
		this.timeBegin = GameCanvas.timeNow;
	}

	// Token: 0x06000889 RID: 2185 RVA: 0x0000AE3F File Offset: 0x0000903F
	public void setPos(int x, int y, mVector vec, sbyte dir)
	{
		this.x = x;
		this.y = y;
		this.vecPos = vec;
		this.Dirbuff = dir;
	}

	// Token: 0x0600088A RID: 2186 RVA: 0x0000AE5F File Offset: 0x0000905F
	public void paint(mGraphics g, int x, int y, sbyte lvDevil)
	{
		Skill_Info.paintIcon(g, x, y, this.idIcon, lvDevil);
	}

	// Token: 0x0600088B RID: 2187 RVA: 0x000ACCDC File Offset: 0x000AAEDC
	public void getData()
	{
		bool flag = (int)this.typeEffSkill > MainSkill.mRangeSkill.Length - 1;
		if (flag)
		{
			this.range = 48;
		}
		else
		{
			this.range = (int)MainSkill.mRangeSkill[(int)this.typeEffSkill];
		}
	}

	// Token: 0x04000D46 RID: 3398
	public const sbyte BUFF_NULL = 0;

	// Token: 0x04000D47 RID: 3399
	public const sbyte BUFF_NOR = 1;

	// Token: 0x04000D48 RID: 3400
	public const sbyte BUFF_SPEC = 2;

	// Token: 0x04000D49 RID: 3401
	public const sbyte BUFF_SHOW = 3;

	// Token: 0x04000D4A RID: 3402
	public const sbyte BUFF_PLASH = 4;

	// Token: 0x04000D4B RID: 3403
	public short typeEffSkill;

	// Token: 0x04000D4C RID: 3404
	public short indexHotKey;

	// Token: 0x04000D4D RID: 3405
	public short idIcon;

	// Token: 0x04000D4E RID: 3406
	public short ID;

	// Token: 0x04000D4F RID: 3407
	public short typeEffBuff;

	// Token: 0x04000D50 RID: 3408
	public short timebuff;

	// Token: 0x04000D51 RID: 3409
	public short typeDevil;

	// Token: 0x04000D52 RID: 3410
	public int timeDelay;

	// Token: 0x04000D53 RID: 3411
	public int x;

	// Token: 0x04000D54 RID: 3412
	public int y;

	// Token: 0x04000D55 RID: 3413
	public long timeBegin;

	// Token: 0x04000D56 RID: 3414
	public mVector vecPos = new mVector("MainSkill.vecPos");

	// Token: 0x04000D57 RID: 3415
	public sbyte typeSub;

	// Token: 0x04000D58 RID: 3416
	public sbyte typeBuff;

	// Token: 0x04000D59 RID: 3417
	public sbyte Dirbuff;

	// Token: 0x04000D5A RID: 3418
	public sbyte lvDevil;

	// Token: 0x04000D5B RID: 3419
	public bool isBuff;

	// Token: 0x04000D5C RID: 3420
	public bool isBuffSpecNew;

	// Token: 0x04000D5D RID: 3421
	public int range;

	// Token: 0x04000D5E RID: 3422
	public int mana;

	// Token: 0x04000D5F RID: 3423
	public static short[] mRangeSkill = new short[]
	{
		100,
		120,
		100,
		32,
		100,
		100,
		100,
		120,
		80,
		100,
		120,
		120,
		120,
		64,
		48,
		48,
		48,
		48,
		120,
		120,
		80,
		48,
		100,
		48,
		64,
		48,
		100,
		100,
		64,
		100,
		32,
		120,
		48,
		48,
		100,
		100,
		120,
		120,
		48,
		100,
		48,
		100,
		120,
		120,
		48,
		48,
		100,
		100,
		100,
		120,
		120,
		48,
		48,
		100,
		100,
		120,
		120,
		80,
		80,
		80,
		80,
		120,
		120,
		100,
		48,
		60,
		60,
		60,
		60,
		60,
		60,
		84,
		84,
		32,
		48,
		84,
		48,
		120,
		32,
		32,
		32,
		60,
		60,
		60,
		60,
		60,
		60,
		60,
		48,
		60,
		32,
		32,
		84,
		84,
		48,
		84,
		84,
		84,
		84,
		48,
		72,
		72,
		84,
		48,
		84,
		48,
		84,
		48,
		84,
		84,
		84,
		48,
		48,
		84,
		84,
		72,
		48,
		72,
		48,
		84,
		72,
		60,
		60,
		60,
		60,
		60,
		60,
		60,
		48,
		48,
		48,
		48,
		48,
		120,
		120,
		120,
		120,
		120,
		120,
		120,
		120,
		120,
		120,
		60,
		60,
		120,
		120,
		360,
		60,
		60
	};
}
