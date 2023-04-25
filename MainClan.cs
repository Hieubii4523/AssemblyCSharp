using System;

// Token: 0x02000073 RID: 115
public class MainClan
{
	// Token: 0x06000700 RID: 1792 RVA: 0x00099260 File Offset: 0x00097460
	public MainClan()
	{
	}

	// Token: 0x06000701 RID: 1793 RVA: 0x000992C0 File Offset: 0x000974C0
	public MainClan(short ID, short idIcon, sbyte levelInClan)
	{
		this.ID = ID;
		this.idIcon = idIcon;
		this.chucvu = (int)levelInClan;
	}

	// Token: 0x06000702 RID: 1794 RVA: 0x00099338 File Offset: 0x00097538
	public MainClan(short ID, string name)
	{
		this.ID = ID;
		this.name = name;
		this.numAttribute = new short[5];
	}

	// Token: 0x06000703 RID: 1795 RVA: 0x000993B4 File Offset: 0x000975B4
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

	// Token: 0x06000704 RID: 1796 RVA: 0x0000A8C3 File Offset: 0x00008AC3
	public void setAttri(short[] mAttri)
	{
		this.numAttribute = mAttri;
	}

	// Token: 0x06000705 RID: 1797 RVA: 0x0000A8CD File Offset: 0x00008ACD
	public static void UpdateRankMe(sbyte level)
	{
		Player.ChucInCLan = level;
	}

	// Token: 0x06000706 RID: 1798 RVA: 0x0000A8D6 File Offset: 0x00008AD6
	public void updateListMem(mVector vec)
	{
		this.vecMem = vec;
	}

	// Token: 0x06000707 RID: 1799 RVA: 0x00099410 File Offset: 0x00097610
	public static bool isPhongChuc()
	{
		return Player.ChucInCLan == 0 || Player.ChucInCLan == 1 || Player.ChucInCLan == 2;
	}

	// Token: 0x04000A75 RID: 2677
	public string name;

	// Token: 0x04000A76 RID: 2678
	public string nameCaption;

	// Token: 0x04000A77 RID: 2679
	public string strVoice;

	// Token: 0x04000A78 RID: 2680
	public int level;

	// Token: 0x04000A79 RID: 2681
	public int numMem;

	// Token: 0x04000A7A RID: 2682
	public int maxNumMem;

	// Token: 0x04000A7B RID: 2683
	public int xp;

	// Token: 0x04000A7C RID: 2684
	public int maxXp;

	// Token: 0x04000A7D RID: 2685
	public int rank;

	// Token: 0x04000A7E RID: 2686
	public int chucvu;

	// Token: 0x04000A7F RID: 2687
	public int pointAttri;

	// Token: 0x04000A80 RID: 2688
	public int maxAttri = 20;

	// Token: 0x04000A81 RID: 2689
	public int rubiClan;

	// Token: 0x04000A82 RID: 2690
	public int beryClan;

	// Token: 0x04000A83 RID: 2691
	public int countAction;

	// Token: 0x04000A84 RID: 2692
	public short ID;

	// Token: 0x04000A85 RID: 2693
	public short idIcon = -1;

	// Token: 0x04000A86 RID: 2694
	public sbyte isLevelUp;

	// Token: 0x04000A87 RID: 2695
	public sbyte trungsinh;

	// Token: 0x04000A88 RID: 2696
	public sbyte borderIconClan;

	// Token: 0x04000A89 RID: 2697
	public mVector vecMem = new mVector("MainClan.vecMem");

	// Token: 0x04000A8A RID: 2698
	public mVector vecChatCLan = new mVector("MainClan.vecChatClan");

	// Token: 0x04000A8B RID: 2699
	public mVector vecAchi = new mVector("MainClan.vecAchi");

	// Token: 0x04000A8C RID: 2700
	public short[] numAttribute = new short[5];
}
