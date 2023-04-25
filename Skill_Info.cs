using System;

// Token: 0x020000ED RID: 237
public class Skill_Info : MainItem
{
	// Token: 0x06000E2D RID: 3629 RVA: 0x001110C0 File Offset: 0x0010F2C0
	public Skill_Info(short Index, short Id, short IdImage, sbyte type, sbyte typeBuff, string name, short typeEff, short range, short Lv)
	{
		this.indexSkillInServer = Index;
		this.ID = Id;
		this.idIcon = IdImage;
		this.typeSkill = type;
		this.typeBuff = typeBuff;
		this.name = name;
		this.range = range;
		this.typeEffSkill = typeEff;
		this.Lv_RQ = Lv;
		this.indexSort = this.typeSkill;
		bool flag = this.indexSort == 4;
		if (flag)
		{
			this.indexSort = 1;
		}
		int width = mFont.tahoma_7b_black.getWidth(name);
		bool flag2 = width > 120;
		if (flag2)
		{
			this.wInfo = width + 8;
		}
		bool flag3 = this.Lv_RQ > 0;
		if (flag3)
		{
			bool flag4 = this.Lv_RQ == 20;
			if (flag4)
			{
				this.namepaint = name + " + " + T.max;
			}
			else
			{
				this.namepaint = name + " +" + this.LvUpgrade.ToString();
			}
		}
		else
		{
			this.namepaint = name;
		}
		Skill_Info.plashTest = new Plash();
		Skill_Info.plashTest.getPlashData(Skill_Info.plashTest.getTypePlash(this.typeEffSkill));
		Skill_Info.plashTest = null;
	}

	// Token: 0x06000E2E RID: 3630 RVA: 0x00111200 File Offset: 0x0010F400
	public void getData(sbyte nTarget, short rangeLan, int Damage, short Manacost, int CoolDown, sbyte nkick, string Description, sbyte LvCur, short percentLv, sbyte typeDevil)
	{
		this.nTarget = nTarget;
		this.rangeLan = rangeLan;
		this.damage = Damage;
		this.manaLost = Manacost;
		this.timeDelay = CoolDown;
		this.nKick = nkick;
		this.info = Description;
		this.Lv_RQ = (short)LvCur;
		this.percentLv = percentLv;
		this.typeDevil = typeDevil;
	}

	// Token: 0x06000E2F RID: 3631 RVA: 0x0011125C File Offset: 0x0010F45C
	public void setVecInfo(int w)
	{
		this.vecInfo.removeAllElements();
		string[] array = mFont.tahoma_7b_black.splitFontArray(this.info, w);
		for (int i = 0; i < array.Length; i++)
		{
			this.addInfo(array[i], 0);
		}
		bool flag = this.LvDevilSkill > 0 || this.phanTramDevilSkill > 0;
		if (flag)
		{
			this.addInfo(string.Concat(new string[]
			{
				T.lvDevil,
				this.LvDevilSkill.ToString(),
				" + ",
				this.phanTramDevilSkill.ToString(),
				"%"
			}), 5);
		}
		bool flag2 = this.typeSkill == 2;
		if (flag2)
		{
			this.addInfo(T.typeSkill + ": " + T.mTypeSkill[(int)this.typeSkill], 0);
			this.addInfo(T.tacdung + ": " + T.mTacdung[(int)this.typeBuff], 0);
		}
		bool flag3 = this.typeSkill != 3 && this.typeSkill != 6;
		if (flag3)
		{
			bool flag4 = this.typeSkill != 2;
			if (flag4)
			{
				this.addInfo(T.damage + ": " + this.damage.ToString(), 0);
			}
			this.addInfo(T.manalost + ": " + this.manaLost.ToString(), 0);
			this.addInfo(T.target + ": " + this.nTarget.ToString(), 0);
			bool flag5 = this.nTarget > 1;
			if (flag5)
			{
				this.addInfo(T.rangeLan + ": " + this.rangeLan.ToString(), 0);
			}
			this.addInfo(T.delay + ": " + MainItem.getTimeDelay(this.timeDelay), 0);
		}
		int num = 0;
		int value = 0;
		int num2 = 0;
		int value2 = 0;
		int num3 = 0;
		for (int j = 0; j < this.vecAtt.size(); j++)
		{
			MainInfoItem mainInfoItem = (MainInfoItem)this.vecAtt.elementAt(j);
			bool flag6 = mainInfoItem.id >= 28 && mainInfoItem.id < 32;
			if (flag6)
			{
				bool flag7 = mainInfoItem.id == 28;
				if (flag7)
				{
					num2 = mainInfoItem.value;
				}
				else
				{
					bool flag8 = mainInfoItem.id == 29;
					if (flag8)
					{
						value = mainInfoItem.value;
					}
					else
					{
						bool flag9 = mainInfoItem.id == 30;
						if (flag9)
						{
							num = mainInfoItem.value;
						}
					}
				}
			}
			else
			{
				bool flag10 = mainInfoItem.id >= 64 && mainInfoItem.id <= 65;
				if (flag10)
				{
					bool flag11 = mainInfoItem.id == 64;
					if (flag11)
					{
						num3 = mainInfoItem.value;
					}
					else
					{
						bool flag12 = mainInfoItem.id == 65;
						if (flag12)
						{
							value2 = mainInfoItem.value;
						}
					}
				}
				else
				{
					base.addInfo((short)mainInfoItem.id, mainInfoItem.value, mainInfoItem.colorMain);
				}
			}
		}
		bool flag13 = num > 0;
		if (flag13)
		{
			string text = "null";
			bool flag14 = num2 >= 0 && num2 <= T.mEffSpec.Length;
			if (flag14)
			{
				text = T.mEffSpec[num2];
			}
			string src = string.Concat(new string[]
			{
				MainItem.strGetPercent(value, 1),
				" ",
				T.gay,
				" ",
				text,
				" ",
				T.trong,
				" ",
				MainItem.strGetPercent(num, 10)
			});
			string[] array2 = mFont.tahoma_7b_black.splitFontArray(src, w);
			for (int k = 0; k < array2.Length; k++)
			{
				this.addInfo(array2[k], 0);
			}
		}
		bool flag15 = num3 > 0;
		if (flag15)
		{
			string src2 = string.Concat(new string[]
			{
				MainItem.strGetPercent(value2, 1),
				" ",
				T.bocPhaAtt,
				" ",
				MainItem.strGetPercent(num3, 1)
			});
			string[] array3 = mFont.tahoma_7b_black.splitFontArray(src2, w);
			for (int l = 0; l < array3.Length; l++)
			{
				this.addInfo(array3[l], 0);
			}
		}
	}

	// Token: 0x06000E30 RID: 3632 RVA: 0x001116E4 File Offset: 0x0010F8E4
	public static MainImage getImage(short icon)
	{
		MainImage mainImage = null;
		MainImage result;
		try
		{
			mainImage = ObjectData.getImageAll(icon, ObjectData.hashImageSkill, 4000);
			result = mainImage;
		}
		catch (Exception)
		{
			result = mainImage;
		}
		return result;
	}

	// Token: 0x06000E31 RID: 3633 RVA: 0x00111724 File Offset: 0x0010F924
	public mVector getActionInven()
	{
		mVector mVector = new mVector();
		bool flag = this.Lv_RQ >= 0 && (this.typeSkill == 1 || this.typeSkill == 2 || this.typeSkill == 4);
		if (flag)
		{
			mVector.addElement(TabSkill.cmdSetHotKey);
		}
		return mVector;
	}

	// Token: 0x06000E32 RID: 3634 RVA: 0x0011177C File Offset: 0x0010F97C
	public void paint(mGraphics g, int x, int y)
	{
		MainImage image = Skill_Info.getImage(this.idIcon);
		bool flag = image != null && image.img != null;
		if (flag)
		{
			g.drawImage(image.img, x, y, 3);
			bool flag2 = (int)this.Lv_RQ > GameScreen.player.Lv;
			if (flag2)
			{
				g.drawRegion(AvMain.imgDelay, 0, 0, 20, 20, 0, (float)x, (float)y, 3);
			}
		}
		else
		{
			AvMain.imgLoadImage.drawFrame(GameCanvas.gameTick % AvMain.imgLoadImage.nFrame, x, y, 0, 3, g);
		}
		bool flag3 = this.LvDevilSkill > 0 && (int)(this.LvDevilSkill - 1) < AvMain.fraBorderSkill.nFrame;
		if (flag3)
		{
			AvMain.fraBorderSkill.drawFrame((int)(this.LvDevilSkill - 1), x, y, 0, 3, g);
		}
	}

	// Token: 0x06000E33 RID: 3635 RVA: 0x00111850 File Offset: 0x0010FA50
	public static void paintIcon(mGraphics g, int x, int y, short icon, sbyte lvDevil)
	{
		MainImage image = Skill_Info.getImage(icon);
		bool flag = image != null && image.img != null;
		if (flag)
		{
			g.drawImage(image.img, x, y, 3);
		}
		else
		{
			AvMain.imgLoadImage.drawFrame(GameCanvas.gameTick % AvMain.imgLoadImage.nFrame, x, y, 0, 3, g);
		}
		bool flag2 = lvDevil > 0 && (int)(lvDevil - 1) < AvMain.fraBorderSkill.nFrame;
		if (flag2)
		{
			AvMain.fraBorderSkill.drawFrame((int)(lvDevil - 1), x, y, 0, 3, g);
		}
	}

	// Token: 0x06000E34 RID: 3636 RVA: 0x001118E4 File Offset: 0x0010FAE4
	public static Skill_Info getSkillFromID(short Id)
	{
		try
		{
			for (int i = 0; i < Player.vecListSkill.size(); i++)
			{
				Skill_Info skill_Info = (Skill_Info)Player.vecListSkill.elementAt(i);
				bool flag = skill_Info.ID == Id;
				if (flag)
				{
					return skill_Info;
				}
			}
		}
		catch (Exception)
		{
		}
		return null;
	}

	// Token: 0x06000E35 RID: 3637 RVA: 0x0000BEAF File Offset: 0x0000A0AF
	public static void quickSortSkill(mVector actors)
	{
		Skill_Info.recQuickSort(actors, 0, actors.size() - 1);
	}

	// Token: 0x06000E36 RID: 3638 RVA: 0x00111950 File Offset: 0x0010FB50
	private static void recQuickSort(mVector actors, int left, int right)
	{
		try
		{
			bool flag = right - left > 0;
			if (flag)
			{
				Skill_Info skill_Info = (Skill_Info)actors.elementAt(right);
				int pivot = (int)skill_Info.typeSkill;
				int num = Skill_Info.partitionIt(actors, left, right, pivot);
				Skill_Info.recQuickSort(actors, left, num - 1);
				Skill_Info.recQuickSort(actors, num + 1, right);
			}
		}
		catch (Exception)
		{
			mSystem.outloi("loi Cres 1");
		}
	}

	// Token: 0x06000E37 RID: 3639 RVA: 0x001119C4 File Offset: 0x0010FBC4
	private static int partitionIt(mVector actors, int left, int right, int pivot)
	{
		int num = left - 1;
		int num2 = right;
		int result;
		try
		{
			for (;;)
			{
				bool flag = (int)((Skill_Info)actors.elementAt(++num)).typeSkill >= pivot;
				if (flag)
				{
					while (num2 > 0 && (int)((Skill_Info)actors.elementAt(--num2)).typeSkill > pivot)
					{
					}
					bool flag2 = num >= num2;
					if (flag2)
					{
						break;
					}
					Skill_Info.swap(actors, num, num2);
				}
			}
			Skill_Info.swap(actors, num, right);
			result = num;
		}
		catch (Exception)
		{
			result = num;
		}
		return result;
	}

	// Token: 0x06000E38 RID: 3640 RVA: 0x00111A6C File Offset: 0x0010FC6C
	private static void swap(mVector actors, int dex1, int dex2)
	{
		object obj = actors.elementAt(dex2);
		bool flag = ((Skill_Info)actors.elementAt(dex2)).typeSkill != ((Skill_Info)actors.elementAt(dex1)).typeSkill;
		if (flag)
		{
			actors.setElementAt(actors.elementAt(dex1), dex2);
			actors.setElementAt(obj, dex1);
		}
	}

	// Token: 0x06000E39 RID: 3641 RVA: 0x00111AC8 File Offset: 0x0010FCC8
	public string getStrType()
	{
		sbyte b = this.typeSkill;
		if (!true)
		{
		}
		string result;
		switch (b)
		{
		case 1:
			result = T.skillActive;
			goto IL_5E;
		case 2:
			result = T.skillBuff;
			goto IL_5E;
		case 3:
			result = T.skillPassive;
			goto IL_5E;
		case 4:
			result = T.skillActiveSea;
			goto IL_5E;
		case 6:
			result = T.skillJob;
			goto IL_5E;
		}
		result = string.Empty;
		IL_5E:
		if (!true)
		{
		}
		return result;
	}

	// Token: 0x040015A1 RID: 5537
	public const sbyte SKILL_ACTIVE = 1;

	// Token: 0x040015A2 RID: 5538
	public const sbyte SKILL_PASSIVE = 3;

	// Token: 0x040015A3 RID: 5539
	public const sbyte SKILL_BUFF = 2;

	// Token: 0x040015A4 RID: 5540
	public const sbyte SKILL_ACTIVE_SEA = 4;

	// Token: 0x040015A5 RID: 5541
	public const sbyte SKILL_JOB = 6;

	// Token: 0x040015A6 RID: 5542
	public const sbyte BUFF_ME = 1;

	// Token: 0x040015A7 RID: 5543
	public const sbyte BUFF_ME_FRIEND = 2;

	// Token: 0x040015A8 RID: 5544
	public const sbyte BUFF_ENEMY = 3;

	// Token: 0x040015A9 RID: 5545
	public const sbyte BUFF_ME_DEVIL = 4;

	// Token: 0x040015AA RID: 5546
	public const sbyte DEVIL_NONE = 0;

	// Token: 0x040015AB RID: 5547
	public const sbyte DEVIL_FRUIT = 1;

	// Token: 0x040015AC RID: 5548
	public sbyte typeSkill;

	// Token: 0x040015AD RID: 5549
	public sbyte typeBuff;

	// Token: 0x040015AE RID: 5550
	public sbyte typeDevil;

	// Token: 0x040015AF RID: 5551
	public short typeEffSkill;

	// Token: 0x040015B0 RID: 5552
	public short perEffSpec;

	// Token: 0x040015B1 RID: 5553
	public short timeEffSpec;

	// Token: 0x040015B2 RID: 5554
	public short indexSkillInServer;

	// Token: 0x040015B3 RID: 5555
	public sbyte idEffSpec;

	// Token: 0x040015B4 RID: 5556
	public sbyte nTarget;

	// Token: 0x040015B5 RID: 5557
	public sbyte nKick;

	// Token: 0x040015B6 RID: 5558
	public short range;

	// Token: 0x040015B7 RID: 5559
	public short manaLost;

	// Token: 0x040015B8 RID: 5560
	public short rangeLan;

	// Token: 0x040015B9 RID: 5561
	public short percentLv;

	// Token: 0x040015BA RID: 5562
	public static sbyte maxLv = 25;

	// Token: 0x040015BB RID: 5563
	public int timeDelay;

	// Token: 0x040015BC RID: 5564
	public int damage;

	// Token: 0x040015BD RID: 5565
	public mVector vecAtt = new mVector("Skill_Info.vecAtt");

	// Token: 0x040015BE RID: 5566
	public static Plash plashTest;
}
