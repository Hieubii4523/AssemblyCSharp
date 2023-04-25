using System;
using System.Collections;

// Token: 0x02000011 RID: 17
public class CharPartInfo
{
	// Token: 0x06000088 RID: 136 RVA: 0x0001431C File Offset: 0x0001251C
	public static void readPart(sbyte[] data)
	{
		DataInputStream dataInputStream = null;
		try
		{
			dataInputStream = new DataInputStream(new ByteArrayInputStream(data));
			int num = (int)dataInputStream.readShort();
			CharPartInfo.parts = new mPart[num];
			for (int i = 0; i < num; i++)
			{
				int type = (int)dataInputStream.readByte();
				CharPartInfo.parts[i] = new mPart(type);
				for (int j = 0; j < CharPartInfo.parts[i].pi.Length; j++)
				{
					CharPartInfo.parts[i].pi[j] = new PartImage();
					CharPartInfo.parts[i].pi[j].id = dataInputStream.readShort();
					CharPartInfo.parts[i].pi[j].dx = dataInputStream.readByte();
					CharPartInfo.parts[i].pi[j].dy = dataInputStream.readByte();
				}
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			try
			{
				dataInputStream.close();
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x06000089 RID: 137 RVA: 0x00014448 File Offset: 0x00012648
	public static void LoadDataCharPart(DataInputStream dis, int isSave)
	{
		bool flag = dis == null;
		if (flag)
		{
			GlobalService.gI().get_DATA(23);
		}
		else
		{
			try
			{
				short verCharPar = 0;
				bool flag2 = isSave >= 0;
				if (flag2)
				{
					verCharPar = dis.readShort();
				}
				int sizeImage = dis.readInt();
				CharPartInfo.loadImage(dis, sizeImage);
				dis.close();
				bool flag3 = isSave == 1;
				if (flag3)
				{
					GlobalService.VerCharPar = verCharPar;
					SaveRms.saveVer(GlobalService.VerCharPar, "VerdataCharPart");
				}
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x0600008A RID: 138 RVA: 0x000144D8 File Offset: 0x000126D8
	public static void loadImage(DataInputStream dis, int sizeImage)
	{
		try
		{
			sbyte[] data = null;
			bool flag = sizeImage > 0;
			if (flag)
			{
				data = new sbyte[sizeImage];
				dis.read(ref data);
			}
			SmallImage.readImage(data);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x0600008B RID: 139 RVA: 0x00014524 File Offset: 0x00012724
	public static void loadPart(DataInputStream dis, int sizePart)
	{
		try
		{
			sbyte[] data = null;
			bool flag = sizePart > 0;
			if (flag)
			{
				data = new sbyte[sizePart];
				dis.read(ref data);
			}
			CharPartInfo.readPart(data);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x0600008C RID: 140 RVA: 0x00014570 File Offset: 0x00012770
	public static mPart getPart(int index)
	{
		mPart mPart = (mPart)CharPartInfo.hashMyPart.get(string.Empty + index.ToString());
		bool flag = mPart == null;
		if (flag)
		{
			mPart = new mPart();
			CharPartInfo.hashMyPart.put(string.Empty + index.ToString(), mPart);
			GlobalService.gI().getDataPart((short)index);
		}
		mPart.count = GameCanvas.timeNow / 1000L;
		bool flag2 = mPart.pi == null;
		if (flag2)
		{
			mPart.timeNull++;
			bool flag3 = mPart.timeNull >= 200;
			if (flag3)
			{
				GlobalService.gI().getDataPart((short)index);
				mPart.timeNull = 0;
			}
		}
		return mPart;
	}

	// Token: 0x0600008D RID: 141 RVA: 0x0001463C File Offset: 0x0001283C
	public static void checkDelHashCharPart(MyHashTable hash, int time)
	{
		mVector mVector = new mVector();
		IDictionaryEnumerator enumerator = hash.GetEnumerator();
		while (enumerator.MoveNext())
		{
			mPart mPart = (mPart)enumerator.Value;
			bool flag = mPart.count != -1L && GameCanvas.timeNow / 1000L - mPart.count > (long)time;
			if (flag)
			{
				string o = (string)enumerator.Key;
				mVector.addElement(o);
			}
		}
		for (int i = 0; i < mVector.size(); i++)
		{
			hash.Remove((string)mVector.elementAt(i));
		}
	}

	// Token: 0x04000120 RID: 288
	public static mPart[] parts;

	// Token: 0x04000121 RID: 289
	public static MyHashTable hashMyPart = new MyHashTable();
}
