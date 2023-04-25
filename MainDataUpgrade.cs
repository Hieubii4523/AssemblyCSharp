using System;

// Token: 0x02000074 RID: 116
public class MainDataUpgrade
{
	// Token: 0x06000708 RID: 1800 RVA: 0x00099448 File Offset: 0x00097648
	public static void LoadDataUpgrade(DataInputStream iss, bool isSave)
	{
		bool flag = iss == null;
		if (flag)
		{
			GlobalService.gI().get_DATA(12);
		}
		else
		{
			try
			{
				sbyte b = iss.readByte();
				ScreenUpgrade.mTemMaterialUpgrade = new MainDataUpgrade[(int)b];
				for (int i = 0; i < (int)b; i++)
				{
					ScreenUpgrade.mTemMaterialUpgrade[i] = new MainDataUpgrade();
					ScreenUpgrade.mTemMaterialUpgrade[i].lv = iss.readByte();
					ScreenUpgrade.mTemMaterialUpgrade[i].per = iss.readShort();
					ScreenUpgrade.mTemMaterialUpgrade[i].preLv = iss.readByte();
					ScreenUpgrade.mTemMaterialUpgrade[i].beli = iss.readInt();
					ScreenUpgrade.mTemMaterialUpgrade[i].beli_white_green = iss.readInt();
					ScreenUpgrade.mTemMaterialUpgrade[i].ruby = iss.readShort();
					ScreenUpgrade.mTemMaterialUpgrade[i].perAtt = iss.readShort();
					sbyte b2 = iss.readByte();
					ScreenUpgrade.mTemMaterialUpgrade[i].mMaterial = new short[(int)b2][];
					for (int j = 0; j < (int)b2; j++)
					{
						ScreenUpgrade.mTemMaterialUpgrade[i].mMaterial[j] = new short[3];
						ScreenUpgrade.mTemMaterialUpgrade[i].mMaterial[j][2] = (short)iss.readByte();
						ScreenUpgrade.mTemMaterialUpgrade[i].mMaterial[j][0] = (short)iss.readByte();
						ScreenUpgrade.mTemMaterialUpgrade[i].mMaterial[j][1] = iss.readShort();
					}
				}
				if (isSave)
				{
					GlobalService.VerDataUpgrade = iss.readShort();
					SaveRms.saveVer(GlobalService.VerDataUpgrade, "VerdataUpgradeSave");
				}
				iss.close();
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x04000A8D RID: 2701
	public short[][] mMaterial;

	// Token: 0x04000A8E RID: 2702
	public int beli;

	// Token: 0x04000A8F RID: 2703
	public int beli_white_green;

	// Token: 0x04000A90 RID: 2704
	public short ruby;

	// Token: 0x04000A91 RID: 2705
	public short per;

	// Token: 0x04000A92 RID: 2706
	public short perAtt;

	// Token: 0x04000A93 RID: 2707
	public sbyte lv;

	// Token: 0x04000A94 RID: 2708
	public sbyte preLv;
}
