using System;
using System.Collections;

// Token: 0x020000C0 RID: 192
public class ObjectData
{
	// Token: 0x06000B4F RID: 2895 RVA: 0x000DAE78 File Offset: 0x000D9078
	public static MainImage getImageOther(short id, short type)
	{
		return ObjectData.getImageAll(id + type, ObjectData.HashImageOtherNew, 23000);
	}

	// Token: 0x06000B50 RID: 2896 RVA: 0x000DAEA0 File Offset: 0x000D90A0
	public static MainImage getImageAll(short id, MyHashTable hash, short typeImage)
	{
		return ObjectData.getImageAll(id, string.Empty + id.ToString(), hash, typeImage);
	}

	// Token: 0x06000B51 RID: 2897 RVA: 0x000DAECC File Offset: 0x000D90CC
	public static MainImage getImageAll(short id, string strId, MyHashTable hash, short typeImage)
	{
		bool flag = id == -1;
		MainImage result;
		if (flag)
		{
			result = null;
		}
		else
		{
			MainImage mainImage = (MainImage)hash.get(strId);
			bool flag2 = mainImage == null;
			if (flag2)
			{
				mainImage = new MainImage();
				hash.put(string.Empty + id.ToString(), mainImage);
				mainImage.img = ObjectData.getFromRms(id, (int)typeImage, hash);
				mainImage.set_W_H();
			}
			mainImage.count = GameCanvas.timeNow / 1000L;
			bool flag3 = mainImage.img == null;
			if (flag3)
			{
				mainImage.timeImageNull++;
				bool flag4 = mainImage.timeImageNull >= 200;
				if (flag4)
				{
					GlobalService.gI().load_image(id, typeImage);
					mainImage.timeImageNull = 0;
				}
			}
			result = mainImage;
		}
		return result;
	}

	// Token: 0x06000B52 RID: 2898 RVA: 0x000DAF98 File Offset: 0x000D9198
	public static mImage getFromRms(short id, int typeImage, MyHashTable myhash)
	{
		mImage mImage = null;
		sbyte[] array = null;
		bool flag = GameMidlet.DEVICE == 4 || (GameMidlet.DEVICE != 0 && typeImage == 24000);
		if (flag)
		{
			mImage = ObjectData.getImageServerIOS(mImage, id, typeImage, myhash);
			bool flag2 = mImage != null && mImage.image != null;
			if (flag2)
			{
				return mImage;
			}
		}
		bool flag3 = typeImage == 10000 && id > 10000;
		if (flag3)
		{
			typeImage = 26000;
			id -= 10000;
		}
		bool flag4 = ObjectData.setIdOK(id) && id >= 0;
		if (flag4)
		{
			array = CRes.loadRMS("SUB_image" + ((int)id + typeImage).ToString());
		}
		bool flag5 = array == null;
		mImage result;
		if (flag5)
		{
			bool flag6 = id >= 0;
			if (flag6)
			{
				GlobalService.gI().load_image(id, (short)typeImage);
			}
			result = mImage;
		}
		else
		{
			try
			{
				result = mImage.createImage(array, 0, array.Length);
			}
			catch (Exception)
			{
				bool flag7 = id >= 0;
				if (flag7)
				{
					GlobalService.gI().load_image(id, (short)typeImage);
				}
				result = null;
			}
		}
		return result;
	}

	// Token: 0x06000B53 RID: 2899 RVA: 0x000DB0C8 File Offset: 0x000D92C8
	public static mImage getImageServerIOS(mImage img, short id, int typeImage, MyHashTable myhash)
	{
		string url = string.Empty;
		if (!true)
		{
		}
		string text;
		if (typeImage != 4000)
		{
			if (typeImage != 8000)
			{
				if (typeImage != 24000)
				{
					text = myhash.linkImage + id.ToString() + ".png";
				}
				else
				{
					text = "/eff/g" + id.ToString() + ".png";
				}
			}
			else
			{
				text = ((id >= 500) ? ("/server/boat/" + ((int)(id - 500)).ToString() + ".png") : ("/server/boat_part/" + id.ToString() + ".png"));
			}
		}
		else
		{
			text = ((id >= 500) ? ("/server/skill_small/" + ((int)(id - 500)).ToString() + ".png") : ("/server/skill/" + id.ToString() + ".png"));
		}
		if (!true)
		{
		}
		url = text;
		mImage result;
		try
		{
			img = mImage.createImage(url);
			result = img;
		}
		catch (Exception)
		{
			result = null;
		}
		return result;
	}

	// Token: 0x06000B54 RID: 2900 RVA: 0x000DB1E4 File Offset: 0x000D93E4
	public static bool setIdOK(short id)
	{
		return GameMidlet.DEVICE != 0 && GameMidlet.DEVICE != 4;
	}

	// Token: 0x06000B55 RID: 2901 RVA: 0x000DB218 File Offset: 0x000D9418
	public static void setToRms(sbyte[] mimg, short id)
	{
		try
		{
			CRes.saveRMS("SUB_image" + id.ToString(), mimg);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000B56 RID: 2902 RVA: 0x000DB258 File Offset: 0x000D9458
	public static void saveImageToRmsAndroid(sbyte[] mimg, string name)
	{
		try
		{
			CRes.saveRMS("Main_Image_" + name, mimg);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000B57 RID: 2903 RVA: 0x000DB294 File Offset: 0x000D9494
	public static void checkDelHash(MyHashTable hash, int time, bool isTrue)
	{
		bool flag = GameMidlet.DEVICE == 4 && !isTrue;
		if (!flag)
		{
			mVector mVector = new mVector();
			if (isTrue)
			{
				hash.clear();
			}
			else
			{
				IDictionaryEnumerator enumerator = hash.GetEnumerator();
				while (enumerator.MoveNext())
				{
					MainImage mainImage = (MainImage)enumerator.Value;
					bool flag2 = mainImage.count != -1L && GameCanvas.timeNow / 1000L - mainImage.count > (long)time;
					if (flag2)
					{
						string o = (string)enumerator.Key;
						mVector.addElement(o);
					}
				}
				for (int i = 0; i < mVector.size(); i++)
				{
					hash.remove((string)mVector.elementAt(i));
				}
			}
		}
	}

	// Token: 0x06000B58 RID: 2904 RVA: 0x000DB36C File Offset: 0x000D956C
	public static void checkDelHash_Data(MyHashTable hash, int time, bool isTrue)
	{
		bool flag = GameMidlet.DEVICE == 4 && !isTrue;
		if (!flag)
		{
			mVector mVector = new mVector();
			if (isTrue)
			{
				hash.clear();
			}
			else
			{
				IDictionaryEnumerator enumerator = hash.GetEnumerator();
				while (enumerator.MoveNext())
				{
					EffectData effectData = (EffectData)enumerator.Value;
					bool flag2 = effectData.count != -1L && GameCanvas.timeNow / 1000L - effectData.count > (long)time;
					if (flag2)
					{
						string o = (string)enumerator.Key;
						mVector.addElement(o);
					}
				}
				for (int i = 0; i < mVector.size(); i++)
				{
					hash.remove((string)mVector.elementAt(i));
				}
			}
		}
	}

	// Token: 0x040010E8 RID: 4328
	public const sbyte T_CHAR_PART = 7;

	// Token: 0x040010E9 RID: 4329
	public const short ITEMMAP = 0;

	// Token: 0x040010EA RID: 4330
	public const short MONSTER = 1000;

	// Token: 0x040010EB RID: 4331
	public const short POTION = 2000;

	// Token: 0x040010EC RID: 4332
	public const short ITEM = 3000;

	// Token: 0x040010ED RID: 4333
	public const short SKILL = 4000;

	// Token: 0x040010EE RID: 4334
	public const short SKILL_SMALL = 4500;

	// Token: 0x040010EF RID: 4335
	public const short NPC = 5000;

	// Token: 0x040010F0 RID: 4336
	public const short QUEST_POTION = 6000;

	// Token: 0x040010F1 RID: 4337
	public const short MATERIAL_POTION = 6500;

	// Token: 0x040010F2 RID: 4338
	public const short ICON_CLAN = 7000;

	// Token: 0x040010F3 RID: 4339
	public const short BOAT = 8000;

	// Token: 0x040010F4 RID: 4340
	public const short ITEM_OTHER = 9000;

	// Token: 0x040010F5 RID: 4341
	public const short CHAR_PART = 10000;

	// Token: 0x040010F6 RID: 4342
	public const short FASHION = 20000;

	// Token: 0x040010F7 RID: 4343
	public const short SKILL_COMBO = 21000;

	// Token: 0x040010F8 RID: 4344
	public const short ICON_CLAN_BIG = 22000;

	// Token: 0x040010F9 RID: 4345
	public const short IMAGE_OTHER_NEW = 23000;

	// Token: 0x040010FA RID: 4346
	public const short IMAGE_EFF_CLIENT = 24000;

	// Token: 0x040010FB RID: 4347
	public const short IMAGE_EFF_CLIENT_LOW = 25000;

	// Token: 0x040010FC RID: 4348
	public const short CHAR_PART_VER2 = 26000;

	// Token: 0x040010FD RID: 4349
	public const short GHOST = 999;

	// Token: 0x040010FE RID: 4350
	public const short OTHER_BIG_BOSS = 0;

	// Token: 0x040010FF RID: 4351
	public const short OTHER_TILE = 20;

	// Token: 0x04001100 RID: 4352
	public const short OTHER_TILE_WATER = 70;

	// Token: 0x04001101 RID: 4353
	public static mVector vecSaveImage = new mVector("ObjectData.vecSaveImage");

	// Token: 0x04001102 RID: 4354
	public static MyHashTable HashImageItemMap = new MyHashTable("/server/item_map/");

	// Token: 0x04001103 RID: 4355
	public static MyHashTable HashImageMonster = new MyHashTable("/server/monster/");

	// Token: 0x04001104 RID: 4356
	public static MyHashTable hashImageItem = new MyHashTable("/server/items/");

	// Token: 0x04001105 RID: 4357
	public static MyHashTable hashImagePotion = new MyHashTable("/server/potion/");

	// Token: 0x04001106 RID: 4358
	public static MyHashTable hashImageSkill = new MyHashTable("/server/skill/");

	// Token: 0x04001107 RID: 4359
	public static MyHashTable hashImageSkillSmall = new MyHashTable("/server/skill_small/");

	// Token: 0x04001108 RID: 4360
	public static MyHashTable hashImageNPC = new MyHashTable("/server/npc/");

	// Token: 0x04001109 RID: 4361
	public static MyHashTable hashImageQuestPotion = new MyHashTable("/server/questitem/");

	// Token: 0x0400110A RID: 4362
	public static MyHashTable hashImageMaterialPotion = new MyHashTable("/server/material/");

	// Token: 0x0400110B RID: 4363
	public static MyHashTable hashImageIconClan = new MyHashTable("/server/Clan/");

	// Token: 0x0400110C RID: 4364
	public static MyHashTable hashImageIconClanBig = new MyHashTable("/server/ClanBig/");

	// Token: 0x0400110D RID: 4365
	public static MyHashTable hashImageBoat = new MyHashTable();

	// Token: 0x0400110E RID: 4366
	public static MyHashTable hashImageItemOther = new MyHashTable("/server/dialog/");

	// Token: 0x0400110F RID: 4367
	public static MyHashTable HashImageCharPart = new MyHashTable("/server/char_part/Small");

	// Token: 0x04001110 RID: 4368
	public static MyHashTable HashImageFashion = new MyHashTable("/server/itemFashion/");

	// Token: 0x04001111 RID: 4369
	public static MyHashTable HashImageOtherNew = new MyHashTable("/server/hinhtonghop/");

	// Token: 0x04001112 RID: 4370
	public static MyHashTable HashImageEffClient = new MyHashTable("/eff/");

	// Token: 0x04001113 RID: 4371
	public static MyHashTable HashImageEffClientLow = new MyHashTable("/efflow/");
}
