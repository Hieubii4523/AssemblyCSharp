using System;

// Token: 0x02000087 RID: 135
public class MainSudo
{
	// Token: 0x0600088D RID: 2189 RVA: 0x000ACD20 File Offset: 0x000AAF20
	public MainSudo()
	{
	}

	// Token: 0x0600088E RID: 2190 RVA: 0x000ACD80 File Offset: 0x000AAF80
	public MainSudo(short ID, sbyte levelInClan)
	{
		this.ID = ID;
		this.chucvu = (int)levelInClan;
	}

	// Token: 0x0600088F RID: 2191 RVA: 0x000ACDF0 File Offset: 0x000AAFF0
	public MainSudo(short ID, string name)
	{
		this.ID = ID;
		this.name = name;
		this.numAttribute = new short[5];
	}

	// Token: 0x06000890 RID: 2192 RVA: 0x000ACE6C File Offset: 0x000AB06C
	public void setData(short idIcon, string nameCaption, short level, int xp, int maxXP, sbyte numMem, sbyte maxNumMem, int rank, string strVoice)
	{
		this.idIcon = idIcon;
		this.nameCaption = nameCaption;
		this.level = (int)level;
		this.xp = xp;
		this.maxXp = maxXP;
		this.numMem = (int)numMem;
		this.maxNumMem = (int)maxNumMem;
		this.rank = rank;
		strVoice = GameMidlet.fixString(strVoice);
		this.strVoice = strVoice;
	}

	// Token: 0x06000891 RID: 2193 RVA: 0x0000AE8F File Offset: 0x0000908F
	public void setAttri(short[] mAttri)
	{
		this.numAttribute = mAttri;
	}

	// Token: 0x06000892 RID: 2194 RVA: 0x0000A8CD File Offset: 0x00008ACD
	public static void UpdateRankMe(sbyte level)
	{
		Player.ChucInCLan = level;
	}

	// Token: 0x06000893 RID: 2195 RVA: 0x0000AE99 File Offset: 0x00009099
	public void updateListMem(mVector vec)
	{
		this.vecMem = vec;
	}

	// Token: 0x06000894 RID: 2196 RVA: 0x00099410 File Offset: 0x00097610
	public static bool isPhongChuc()
	{
		return Player.ChucInCLan == 0 || Player.ChucInCLan == 1 || Player.ChucInCLan == 2;
	}

	// Token: 0x04000D60 RID: 3424
	public string name;

	// Token: 0x04000D61 RID: 3425
	public string nameCaption;

	// Token: 0x04000D62 RID: 3426
	public string strVoice;

	// Token: 0x04000D63 RID: 3427
	public string diemSudo;

	// Token: 0x04000D64 RID: 3428
	public int level;

	// Token: 0x04000D65 RID: 3429
	public int numMem;

	// Token: 0x04000D66 RID: 3430
	public int maxNumMem;

	// Token: 0x04000D67 RID: 3431
	public int xp;

	// Token: 0x04000D68 RID: 3432
	public int maxXp;

	// Token: 0x04000D69 RID: 3433
	public int rank;

	// Token: 0x04000D6A RID: 3434
	public int chucvu;

	// Token: 0x04000D6B RID: 3435
	public int pointAttri;

	// Token: 0x04000D6C RID: 3436
	public int maxAttri = 20;

	// Token: 0x04000D6D RID: 3437
	public int rubiClan;

	// Token: 0x04000D6E RID: 3438
	public int beryClan;

	// Token: 0x04000D6F RID: 3439
	public int countAction;

	// Token: 0x04000D70 RID: 3440
	public short ID;

	// Token: 0x04000D71 RID: 3441
	public short idIcon = -1;

	// Token: 0x04000D72 RID: 3442
	public sbyte isLevelUp;

	// Token: 0x04000D73 RID: 3443
	public sbyte trungsinh;

	// Token: 0x04000D74 RID: 3444
	public sbyte borderIconClan;

	// Token: 0x04000D75 RID: 3445
	public mVector vecMem = new mVector("MainClan.vecMem");

	// Token: 0x04000D76 RID: 3446
	public mVector vecChatCLan = new mVector("MainClan.vecChatClan");

	// Token: 0x04000D77 RID: 3447
	public mVector vecAchi = new mVector("MainClan.vecAchi");

	// Token: 0x04000D78 RID: 3448
	public short[] numAttribute = new short[5];
}
