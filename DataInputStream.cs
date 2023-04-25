using System;
using System.Threading;
using UnityEngine;

// Token: 0x02000020 RID: 32
public class DataInputStream
{
	// Token: 0x0600014C RID: 332 RVA: 0x0000953F File Offset: 0x0000773F
	public DataInputStream(ByteArrayInputStream bis)
	{
		this.r = new myReader(bis.data);
	}

	// Token: 0x0600014D RID: 333 RVA: 0x0001C39C File Offset: 0x0001A59C
	public DataInputStream(string filename)
	{
		TextAsset textAsset = (TextAsset)Resources.Load(filename, typeof(TextAsset));
		this.r = new myReader(ArrayCast.cast(textAsset.bytes));
	}

	// Token: 0x0600014E RID: 334 RVA: 0x0000955A File Offset: 0x0000775A
	public DataInputStream(sbyte[] data)
	{
		this.r = new myReader(data);
	}

	// Token: 0x0600014F RID: 335 RVA: 0x0001C3E0 File Offset: 0x0001A5E0
	public static void update()
	{
		bool flag = DataInputStream.status == 2;
		if (flag)
		{
			DataInputStream.status = 1;
			DataInputStream.istemp = DataInputStream.__getResourceAsStream(DataInputStream.filenametemp);
			DataInputStream.status = 0;
		}
	}

	// Token: 0x06000150 RID: 336 RVA: 0x0001C418 File Offset: 0x0001A618
	public static DataInputStream getResourceAsStream(string filename)
	{
		return DataInputStream.__getResourceAsStream(filename);
	}

	// Token: 0x06000151 RID: 337 RVA: 0x0001C430 File Offset: 0x0001A630
	private static DataInputStream _getResourceAsStream(string filename)
	{
		bool flag = DataInputStream.status != 0;
		if (flag)
		{
			for (int i = 0; i < 500; i++)
			{
				Thread.Sleep(5);
				bool flag2 = DataInputStream.status == 0;
				if (flag2)
				{
					break;
				}
			}
			bool flag3 = DataInputStream.status != 0;
			if (flag3)
			{
				Debug.LogError("CANNOT GET INPUTSTREAM " + filename + " WHEN GETTING " + DataInputStream.filenametemp);
				return null;
			}
		}
		DataInputStream.istemp = null;
		DataInputStream.filenametemp = filename;
		DataInputStream.status = 2;
		int j;
		for (j = 0; j < 500; j++)
		{
			Thread.Sleep(5);
			bool flag4 = DataInputStream.status == 0;
			if (flag4)
			{
				break;
			}
		}
		bool flag5 = j == 500;
		DataInputStream result;
		if (flag5)
		{
			Debug.LogError("TOO LONG FOR CREATE INPUTSTREAM " + filename);
			DataInputStream.status = 0;
			result = null;
		}
		else
		{
			result = DataInputStream.istemp;
		}
		return result;
	}

	// Token: 0x06000152 RID: 338 RVA: 0x0001C524 File Offset: 0x0001A724
	private static DataInputStream __getResourceAsStream(string filename)
	{
		DataInputStream result;
		try
		{
			result = new DataInputStream(filename);
		}
		catch (Exception)
		{
			result = null;
		}
		return result;
	}

	// Token: 0x06000153 RID: 339 RVA: 0x0001C554 File Offset: 0x0001A754
	public short readShort()
	{
		return this.r.readShort();
	}

	// Token: 0x06000154 RID: 340 RVA: 0x0001C574 File Offset: 0x0001A774
	public int readInt()
	{
		return this.r.readInt();
	}

	// Token: 0x06000155 RID: 341 RVA: 0x0001C594 File Offset: 0x0001A794
	public int read()
	{
		return (int)this.r.readUnsignedByte();
	}

	// Token: 0x06000156 RID: 342 RVA: 0x00009570 File Offset: 0x00007770
	public void read(ref sbyte[] data)
	{
		this.r.read(ref data);
	}

	// Token: 0x06000157 RID: 343 RVA: 0x00009580 File Offset: 0x00007780
	public void close()
	{
		this.r.Close();
	}

	// Token: 0x06000158 RID: 344 RVA: 0x00009580 File Offset: 0x00007780
	public void Close()
	{
		this.r.Close();
	}

	// Token: 0x06000159 RID: 345 RVA: 0x0001C5B4 File Offset: 0x0001A7B4
	public string readUTF()
	{
		return this.r.readUTF();
	}

	// Token: 0x0600015A RID: 346 RVA: 0x0001C5D4 File Offset: 0x0001A7D4
	public sbyte readByte()
	{
		return this.r.readByte();
	}

	// Token: 0x0600015B RID: 347 RVA: 0x0001C5F4 File Offset: 0x0001A7F4
	public long readLong()
	{
		return this.r.readLong();
	}

	// Token: 0x0600015C RID: 348 RVA: 0x0001C614 File Offset: 0x0001A814
	public bool readBoolean()
	{
		return this.r.readBoolean();
	}

	// Token: 0x0600015D RID: 349 RVA: 0x0001C634 File Offset: 0x0001A834
	public int readUnsignedByte()
	{
		return (int)((byte)this.r.readByte());
	}

	// Token: 0x0600015E RID: 350 RVA: 0x0001C654 File Offset: 0x0001A854
	public int readUnsignedShort()
	{
		return (int)this.r.readUnsignedShort();
	}

	// Token: 0x0600015F RID: 351 RVA: 0x00009570 File Offset: 0x00007770
	public void readFully(ref sbyte[] data)
	{
		this.r.read(ref data);
	}

	// Token: 0x06000160 RID: 352 RVA: 0x0001C674 File Offset: 0x0001A874
	public int available()
	{
		return this.r.available();
	}

	// Token: 0x06000161 RID: 353 RVA: 0x0000958F File Offset: 0x0000778F
	internal void read(ref sbyte[] byteData, int p, int size)
	{
		throw new NotImplementedException();
	}

	// Token: 0x0400026E RID: 622
	private const int INTERVAL = 5;

	// Token: 0x0400026F RID: 623
	private const int MAXTIME = 500;

	// Token: 0x04000270 RID: 624
	public myReader r;

	// Token: 0x04000271 RID: 625
	public static DataInputStream istemp;

	// Token: 0x04000272 RID: 626
	private static int status;

	// Token: 0x04000273 RID: 627
	private static string filenametemp;
}
