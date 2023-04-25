using System;

// Token: 0x02000010 RID: 16
public class CatalogyMonster
{
	// Token: 0x06000083 RID: 131 RVA: 0x00009286 File Offset: 0x00007486
	public CatalogyMonster(int id)
	{
		this.idCat = id;
	}

	// Token: 0x06000084 RID: 132 RVA: 0x00013F98 File Offset: 0x00012198
	public CatalogyMonster(int id, int lv, int maxHp, sbyte typeMove, string name, sbyte ishuman, short hOne, sbyte typeMonster)
	{
		this.idCat = id;
		this.lv = lv;
		this.maxHp = maxHp;
		this.typeMove = typeMove;
		this.name = name;
		this.isHumanPart = ishuman;
		this.hOne = hOne;
		this.typeMonster = typeMonster;
	}

	// Token: 0x06000085 RID: 133 RVA: 0x000092A2 File Offset: 0x000074A2
	public void addData(short head, short hair, short[] wearing)
	{
		this.head = head;
		this.hair = hair;
		this.mWearing = wearing;
	}

	// Token: 0x06000086 RID: 134 RVA: 0x00013FF8 File Offset: 0x000121F8
	public static void LoadDataMon(DataInputStream iss, bool isSave)
	{
		try
		{
			bool flag = iss == null;
			if (flag)
			{
				GlobalService.gI().get_DATA(15);
			}
			else
			{
				short num = iss.readShort();
				for (int i = 0; i < (int)num; i++)
				{
					short id = iss.readShort();
					string text = iss.readUTF();
					short num2 = iss.readShort();
					short num3 = iss.readShort();
					int num4 = iss.readInt();
					sbyte b = iss.readByte();
					sbyte b2 = iss.readByte();
					sbyte b3 = iss.readByte();
					CatalogyMonster catalogyMonster = new CatalogyMonster((int)id, (int)num2, num4, b, text, b2, num3, b3);
					bool flag2 = b2 == 1;
					if (flag2)
					{
						short num5 = iss.readShort();
						short num6 = iss.readShort();
						sbyte b4 = iss.readByte();
						short[] array = new short[(int)b4];
						for (int j = 0; j < array.Length; j++)
						{
							array[j] = -1;
						}
						for (int k = 0; k < (int)b4; k++)
						{
							sbyte b5 = iss.readByte();
							bool flag3 = b5 == 1;
							if (flag3)
							{
								array[k] = iss.readShort();
							}
						}
						catalogyMonster.addData(num5, num6, array);
					}
					else
					{
						catalogyMonster.idIcon = iss.readShort();
					}
					catalogyMonster.isTemplate = true;
					MainMonster.hashMonsterTemplate.put(string.Empty + id.ToString(), catalogyMonster);
				}
				LoadMapScreen.isLoadDataMon = true;
				if (isSave)
				{
					GlobalService.VerMonster = iss.readShort();
					SaveRms.saveVer(GlobalService.VerMonster, "VerdataMon");
				}
				iss.close();
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000087 RID: 135 RVA: 0x000141C0 File Offset: 0x000123C0
	public static void LoadDataMonTemplate(DataInputStream iss)
	{
		try
		{
			short id = iss.readShort();
			string text = iss.readUTF();
			short num = iss.readShort();
			short num2 = iss.readShort();
			int num3 = iss.readInt();
			sbyte b = iss.readByte();
			sbyte b2 = iss.readByte();
			sbyte b3 = iss.readByte();
			CatalogyMonster catalogyMonster = new CatalogyMonster((int)id, (int)num, num3, b, text, b2, num2, b3);
			bool flag = b2 == 1;
			if (flag)
			{
				short num4 = iss.readShort();
				short num5 = iss.readShort();
				sbyte b4 = iss.readByte();
				short[] array = new short[(int)b4];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = -1;
				}
				for (int j = 0; j < (int)b4; j++)
				{
					sbyte b5 = iss.readByte();
					bool flag2 = b5 == 1;
					if (flag2)
					{
						array[j] = iss.readShort();
					}
				}
				catalogyMonster.addData(num4, num5, array);
			}
			else
			{
				catalogyMonster.idIcon = iss.readShort();
			}
			catalogyMonster.isTemplate = true;
			MainMonster.hashMonsterTemplate.put(string.Empty + id.ToString(), catalogyMonster);
			iss.close();
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x04000110 RID: 272
	public const sbyte MON_NOR = 0;

	// Token: 0x04000111 RID: 273
	public const sbyte MON_HUMAN = 1;

	// Token: 0x04000112 RID: 274
	public int idCat;

	// Token: 0x04000113 RID: 275
	public int lv;

	// Token: 0x04000114 RID: 276
	public int maxHp;

	// Token: 0x04000115 RID: 277
	public sbyte typeMove;

	// Token: 0x04000116 RID: 278
	public sbyte isHumanPart;

	// Token: 0x04000117 RID: 279
	public sbyte typeMonster;

	// Token: 0x04000118 RID: 280
	public short head;

	// Token: 0x04000119 RID: 281
	public short hair;

	// Token: 0x0400011A RID: 282
	public short hOne;

	// Token: 0x0400011B RID: 283
	public short idIcon;

	// Token: 0x0400011C RID: 284
	public short[] mWearing;

	// Token: 0x0400011D RID: 285
	public string name = string.Empty;

	// Token: 0x0400011E RID: 286
	public bool isTemplate;

	// Token: 0x0400011F RID: 287
	public long timeRequest;
}
