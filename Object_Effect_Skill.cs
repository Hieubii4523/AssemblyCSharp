using System;

// Token: 0x020000C1 RID: 193
public class Object_Effect_Skill
{
	// Token: 0x06000B5B RID: 2907 RVA: 0x0000B7EA File Offset: 0x000099EA
	public Object_Effect_Skill(short Id, sbyte tem)
	{
		this.ID = Id;
		this.tem = tem;
	}

	// Token: 0x06000B5C RID: 2908 RVA: 0x000DB56C File Offset: 0x000D976C
	public Object_Effect_Skill(short Id, sbyte tem, MainSkill skill)
	{
		this.ID = Id;
		this.tem = tem;
		this.skillMonster = skill;
	}

	// Token: 0x06000B5D RID: 2909 RVA: 0x0000B826 File Offset: 0x00009A26
	public void setHP(int hpShow, int hpLast, int hpMagic)
	{
		this.hpShow = hpShow;
		this.hpLast = hpLast;
		this.hpMagic = hpMagic;
	}

	// Token: 0x04001114 RID: 4372
	public short ID;

	// Token: 0x04001115 RID: 4373
	public sbyte tem;

	// Token: 0x04001116 RID: 4374
	public int hpShow;

	// Token: 0x04001117 RID: 4375
	public int hpLast;

	// Token: 0x04001118 RID: 4376
	public int hpPlus;

	// Token: 0x04001119 RID: 4377
	public int hpMagic;

	// Token: 0x0400111A RID: 4378
	public int[] mEffTypePlus = new int[0];

	// Token: 0x0400111B RID: 4379
	public int[] mEff_HP_Plus = new int[0];

	// Token: 0x0400111C RID: 4380
	public int[] mEff_Time_Plus = new int[0];

	// Token: 0x0400111D RID: 4381
	public MainSkill skillMonster;
}
