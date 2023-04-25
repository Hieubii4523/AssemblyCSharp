using System;
using System.Text;
using UnityEngine;

// Token: 0x020000B6 RID: 182
public class myReader
{
	// Token: 0x06000AE3 RID: 2787 RVA: 0x0000B6E4 File Offset: 0x000098E4
	public myReader()
	{
	}

	// Token: 0x06000AE4 RID: 2788 RVA: 0x0000B6EE File Offset: 0x000098EE
	public myReader(sbyte[] data)
	{
		this.buffer = data;
	}

	// Token: 0x06000AE5 RID: 2789 RVA: 0x000D7650 File Offset: 0x000D5850
	public myReader(string filename)
	{
		TextAsset textAsset = (TextAsset)Resources.Load(filename, typeof(TextAsset));
		this.buffer = mSystem.convertToSbyte(textAsset.bytes);
	}

	// Token: 0x06000AE6 RID: 2790 RVA: 0x000D768C File Offset: 0x000D588C
	public sbyte readSByte()
	{
		bool flag = this.posRead < this.buffer.Length;
		if (flag)
		{
			sbyte[] array = this.buffer;
			int num = this.posRead;
			this.posRead = num + 1;
			return array[num];
		}
		this.posRead = this.buffer.Length;
		throw new Exception(" loi doc sbyte eof ");
	}

	// Token: 0x06000AE7 RID: 2791 RVA: 0x000D76E4 File Offset: 0x000D58E4
	public sbyte readsbyte()
	{
		return this.readSByte();
	}

	// Token: 0x06000AE8 RID: 2792 RVA: 0x000D76E4 File Offset: 0x000D58E4
	public sbyte readByte()
	{
		return this.readSByte();
	}

	// Token: 0x06000AE9 RID: 2793 RVA: 0x0000B6FF File Offset: 0x000098FF
	public void mark(int readlimit)
	{
		this.posMark = this.posRead;
	}

	// Token: 0x06000AEA RID: 2794 RVA: 0x0000B70E File Offset: 0x0000990E
	public void reset()
	{
		this.posRead = this.posMark;
	}

	// Token: 0x06000AEB RID: 2795 RVA: 0x000D76FC File Offset: 0x000D58FC
	public byte readUnsignedByte()
	{
		return myReader.convertSbyteToByte(this.readSByte());
	}

	// Token: 0x06000AEC RID: 2796 RVA: 0x000D771C File Offset: 0x000D591C
	public short readShort()
	{
		short num = 0;
		for (int i = 0; i < 2; i++)
		{
			num = (short)(num << 8);
			short num2 = num;
			short num3 = 255;
			sbyte[] array = this.buffer;
			int num4 = this.posRead;
			this.posRead = num4 + 1;
			num = (num2 | (num3 & array[num4]));
		}
		return num;
	}

	// Token: 0x06000AED RID: 2797 RVA: 0x000D7770 File Offset: 0x000D5970
	public ushort readUnsignedShort()
	{
		ushort num = 0;
		for (int i = 0; i < 2; i++)
		{
			num = (ushort)(num << 8);
			ushort num2 = num;
			ushort num3 = 255;
			sbyte[] array = this.buffer;
			int num4 = this.posRead;
			this.posRead = num4 + 1;
			num = (num2 | (num3 & array[num4]));
		}
		return num;
	}

	// Token: 0x06000AEE RID: 2798 RVA: 0x000D77C4 File Offset: 0x000D59C4
	public int readInt()
	{
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			num <<= 8;
			int num2 = num;
			int num3 = 255;
			sbyte[] array = this.buffer;
			int num4 = this.posRead;
			this.posRead = num4 + 1;
			num = (num2 | (num3 & array[num4]));
		}
		return num;
	}

	// Token: 0x06000AEF RID: 2799 RVA: 0x000D7814 File Offset: 0x000D5A14
	public long readLong()
	{
		long num = 0L;
		for (int i = 0; i < 8; i++)
		{
			num <<= 8;
			long num2 = num;
			long num3 = 255L;
			sbyte[] array = this.buffer;
			int num4 = this.posRead;
			this.posRead = num4 + 1;
			num = (num2 | (num3 & array[num4]));
		}
		return num;
	}

	// Token: 0x06000AF0 RID: 2800 RVA: 0x000D7864 File Offset: 0x000D5A64
	public bool readBool()
	{
		return this.readSByte() > 0;
	}

	// Token: 0x06000AF1 RID: 2801 RVA: 0x000D7864 File Offset: 0x000D5A64
	public bool readBoolean()
	{
		return this.readSByte() > 0;
	}

	// Token: 0x06000AF2 RID: 2802 RVA: 0x000D7880 File Offset: 0x000D5A80
	public string readString()
	{
		short num = this.readShort();
		byte[] array = new byte[(int)num];
		for (int i = 0; i < (int)num; i++)
		{
			array[i] = myReader.convertSbyteToByte(this.readSByte());
		}
		UTF8Encoding utf8Encoding = new UTF8Encoding();
		return utf8Encoding.GetString(array);
	}

	// Token: 0x06000AF3 RID: 2803 RVA: 0x000D7880 File Offset: 0x000D5A80
	public string readStringUTF()
	{
		short num = this.readShort();
		byte[] array = new byte[(int)num];
		for (int i = 0; i < (int)num; i++)
		{
			array[i] = myReader.convertSbyteToByte(this.readSByte());
		}
		UTF8Encoding utf8Encoding = new UTF8Encoding();
		return utf8Encoding.GetString(array);
	}

	// Token: 0x06000AF4 RID: 2804 RVA: 0x000D78D4 File Offset: 0x000D5AD4
	public string readUTF()
	{
		return this.readStringUTF();
	}

	// Token: 0x06000AF5 RID: 2805 RVA: 0x000D78EC File Offset: 0x000D5AEC
	public int read()
	{
		bool flag = this.posRead < this.buffer.Length;
		int result;
		if (flag)
		{
			result = (int)this.readSByte();
		}
		else
		{
			result = -1;
		}
		return result;
	}

	// Token: 0x06000AF6 RID: 2806 RVA: 0x000D7920 File Offset: 0x000D5B20
	public int read(ref sbyte[] data)
	{
		bool flag = data == null;
		int result;
		if (flag)
		{
			result = 0;
		}
		else
		{
			int num = 0;
			for (int i = 0; i < data.Length; i++)
			{
				data[i] = this.readSByte();
				bool flag2 = this.posRead > this.buffer.Length;
				if (flag2)
				{
					return -1;
				}
				num++;
			}
			result = num;
		}
		return result;
	}

	// Token: 0x06000AF7 RID: 2807 RVA: 0x000D7984 File Offset: 0x000D5B84
	public void readFully(ref sbyte[] data)
	{
		bool flag = data != null && data.Length + this.posRead <= this.buffer.Length;
		if (flag)
		{
			for (int i = 0; i < data.Length; i++)
			{
				data[i] = this.readSByte();
			}
		}
	}

	// Token: 0x06000AF8 RID: 2808 RVA: 0x000D79D8 File Offset: 0x000D5BD8
	public int available()
	{
		return this.buffer.Length - this.posRead;
	}

	// Token: 0x06000AF9 RID: 2809 RVA: 0x0007F128 File Offset: 0x0007D328
	public static byte convertSbyteToByte(sbyte var)
	{
		bool flag = var > 0;
		byte result;
		if (flag)
		{
			result = (byte)var;
		}
		else
		{
			result = (byte)((int)var + 256);
		}
		return result;
	}

	// Token: 0x06000AFA RID: 2810 RVA: 0x0007F150 File Offset: 0x0007D350
	public static byte[] convertSbyteToByte(sbyte[] var)
	{
		byte[] array = new byte[var.Length];
		for (int i = 0; i < var.Length; i++)
		{
			bool flag = var[i] > 0;
			if (flag)
			{
				array[i] = (byte)var[i];
			}
			else
			{
				array[i] = (byte)((int)var[i] + 256);
			}
		}
		return array;
	}

	// Token: 0x06000AFB RID: 2811 RVA: 0x0000B71D File Offset: 0x0000991D
	public void Close()
	{
		this.buffer = null;
	}

	// Token: 0x06000AFC RID: 2812 RVA: 0x0000B71D File Offset: 0x0000991D
	public void close()
	{
		this.buffer = null;
	}

	// Token: 0x06000AFD RID: 2813 RVA: 0x000D79FC File Offset: 0x000D5BFC
	public void read(ref sbyte[] data, int arg1, int arg2)
	{
		bool flag = data == null;
		if (!flag)
		{
			for (int i = 0; i < arg2; i++)
			{
				data[i + arg1] = this.readSByte();
				bool flag2 = this.posRead > this.buffer.Length;
				if (flag2)
				{
					break;
				}
			}
		}
	}

	// Token: 0x040010A7 RID: 4263
	public sbyte[] buffer;

	// Token: 0x040010A8 RID: 4264
	private int posRead;

	// Token: 0x040010A9 RID: 4265
	private int posMark;

	// Token: 0x040010AA RID: 4266
	private static string fileName;

	// Token: 0x040010AB RID: 4267
	private static int status;
}
