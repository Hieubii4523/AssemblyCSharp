using System;

// Token: 0x02000051 RID: 81
public class infoShow
{
	// Token: 0x06000590 RID: 1424 RVA: 0x00080BB4 File Offset: 0x0007EDB4
	public infoShow(int id, int value, string str, sbyte color, sbyte colorMain)
	{
		this.strShow = str;
		this.id = id;
		this.value = value;
		this.color = color;
		this.colorMain = colorMain;
	}

	// Token: 0x06000591 RID: 1425 RVA: 0x0000A414 File Offset: 0x00008614
	public infoShow(int id, int value, sbyte color, sbyte colorMain)
	{
		this.id = id;
		this.value = value;
		this.color = color;
		this.colorMain = colorMain;
	}

	// Token: 0x06000592 RID: 1426 RVA: 0x00080C00 File Offset: 0x0007EE00
	public string getInfoFormID()
	{
		bool flag = this.id < 0;
		string result;
		if (flag)
		{
			result = this.strShow;
		}
		else
		{
			string str = MainItem.mNameAttributes[this.id].name + " ";
			result = str + MainItem.strGetPercent(this.value, MainItem.mNameAttributes[this.id].ispercent);
		}
		return result;
	}

	// Token: 0x040007E5 RID: 2021
	public string strShow = string.Empty;

	// Token: 0x040007E6 RID: 2022
	public sbyte color;

	// Token: 0x040007E7 RID: 2023
	public sbyte colorMain = -1;

	// Token: 0x040007E8 RID: 2024
	public int id;

	// Token: 0x040007E9 RID: 2025
	public int value;

	// Token: 0x040007EA RID: 2026
	public static sbyte HARDCODE_CHECK_LVRQ = -100;

	// Token: 0x040007EB RID: 2027
	public static sbyte HARDCODE_PAINT_CENTER = -99;

	// Token: 0x040007EC RID: 2028
	public static sbyte HARDCODE_PAINT_CENTER_CHI_SO = -98;

	// Token: 0x040007ED RID: 2029
	public static sbyte HARDCODE_INFO_CO_BAN = 100;

	// Token: 0x040007EE RID: 2030
	public static sbyte HARDCODE_CHECK_FULLSET_1 = 101;

	// Token: 0x040007EF RID: 2031
	public static sbyte HARDCODE_CHECK_FULLSET_2 = 102;

	// Token: 0x040007F0 RID: 2032
	public static sbyte HARDCODE_CHECK_FULLSET_3 = 103;

	// Token: 0x040007F1 RID: 2033
	public static sbyte HARDCODE_CHECK_FULLSET_4 = 104;

	// Token: 0x040007F2 RID: 2034
	public static sbyte HARDCODE_CHECK_FULLSET_5 = 105;
}
