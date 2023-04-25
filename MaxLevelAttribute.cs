using System;

// Token: 0x02000092 RID: 146
public class MaxLevelAttribute
{
	// Token: 0x06000926 RID: 2342 RVA: 0x0000AFE5 File Offset: 0x000091E5
	public MaxLevelAttribute(int Id, string name, int value, int maxValue)
	{
		this.Id = Id;
		this.name = name;
		this.value = value;
		this.maxValue = maxValue;
	}

	// Token: 0x04000EA9 RID: 3753
	public int value;

	// Token: 0x04000EAA RID: 3754
	public int maxValue;

	// Token: 0x04000EAB RID: 3755
	public int Id;

	// Token: 0x04000EAC RID: 3756
	public string name;
}
