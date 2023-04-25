using System;
using System.IO;
using System.Text;
using UnityEngine;

// Token: 0x020000B8 RID: 184
public class myWriter
{
	// Token: 0x06000B00 RID: 2816 RVA: 0x000D7A88 File Offset: 0x000D5C88
	public void writeSByte(sbyte value)
	{
		this.checkLenght(0);
		sbyte[] array = this.buffer;
		int num = this.posWrite;
		this.posWrite = num + 1;
		array[num] = value;
	}

	// Token: 0x06000B01 RID: 2817 RVA: 0x000D7AB8 File Offset: 0x000D5CB8
	public void writeSByteUncheck(sbyte value)
	{
		sbyte[] array = this.buffer;
		int num = this.posWrite;
		this.posWrite = num + 1;
		array[num] = value;
	}

	// Token: 0x06000B02 RID: 2818 RVA: 0x0000B727 File Offset: 0x00009927
	public void writeByte(sbyte value)
	{
		this.writeSByte(value);
	}

	// Token: 0x06000B03 RID: 2819 RVA: 0x0000B732 File Offset: 0x00009932
	public void writeByte(int value)
	{
		this.writeSByte((sbyte)value);
	}

	// Token: 0x06000B04 RID: 2820 RVA: 0x0000B73E File Offset: 0x0000993E
	public void writeChar(char value)
	{
		this.writeSByte(0);
		this.writeSByte((sbyte)value);
	}

	// Token: 0x06000B05 RID: 2821 RVA: 0x0000B732 File Offset: 0x00009932
	public void writeUnsignedByte(byte value)
	{
		this.writeSByte((sbyte)value);
	}

	// Token: 0x06000B06 RID: 2822 RVA: 0x000D7AE0 File Offset: 0x000D5CE0
	public void writeUnsignedByte(byte[] value)
	{
		this.checkLenght(value.Length);
		for (int i = 0; i < value.Length; i++)
		{
			this.writeSByteUncheck((sbyte)value[i]);
		}
	}

	// Token: 0x06000B07 RID: 2823 RVA: 0x000D7B18 File Offset: 0x000D5D18
	public void writeSByte(sbyte[] value)
	{
		this.checkLenght(value.Length);
		for (int i = 0; i < value.Length; i++)
		{
			this.writeSByteUncheck(value[i]);
		}
	}

	// Token: 0x06000B08 RID: 2824 RVA: 0x000D7B50 File Offset: 0x000D5D50
	public void writeShort(short value)
	{
		this.checkLenght(2);
		for (int i = 1; i >= 0; i--)
		{
			this.writeSByteUncheck((sbyte)(value >> i * 8));
		}
	}

	// Token: 0x06000B09 RID: 2825 RVA: 0x000D7B8C File Offset: 0x000D5D8C
	public void writeShort(int value)
	{
		this.checkLenght(2);
		short num = (short)value;
		for (int i = 1; i >= 0; i--)
		{
			this.writeSByteUncheck((sbyte)(num >> i * 8));
		}
	}

	// Token: 0x06000B0A RID: 2826 RVA: 0x000D7B50 File Offset: 0x000D5D50
	public void writeUnsignedShort(ushort value)
	{
		this.checkLenght(2);
		for (int i = 1; i >= 0; i--)
		{
			this.writeSByteUncheck((sbyte)(value >> i * 8));
		}
	}

	// Token: 0x06000B0B RID: 2827 RVA: 0x000D7BCC File Offset: 0x000D5DCC
	public void writeInt(int value)
	{
		this.checkLenght(4);
		for (int i = 3; i >= 0; i--)
		{
			this.writeSByteUncheck((sbyte)(value >> i * 8));
		}
	}

	// Token: 0x06000B0C RID: 2828 RVA: 0x000D7C08 File Offset: 0x000D5E08
	public void writeLong(long value)
	{
		this.checkLenght(8);
		for (int i = 7; i >= 0; i--)
		{
			this.writeSByteUncheck((sbyte)(value >> i * 8));
		}
	}

	// Token: 0x06000B0D RID: 2829 RVA: 0x0000B752 File Offset: 0x00009952
	public void writeBoolean(bool value)
	{
		this.writeSByte(value ? 1 : 0);
	}

	// Token: 0x06000B0E RID: 2830 RVA: 0x0000B752 File Offset: 0x00009952
	public void writeBool(bool value)
	{
		this.writeSByte(value ? 1 : 0);
	}

	// Token: 0x06000B0F RID: 2831 RVA: 0x000D7C44 File Offset: 0x000D5E44
	public void writeString(string value)
	{
		char[] array = value.ToCharArray();
		this.writeShort((short)array.Length);
		this.checkLenght(array.Length);
		for (int i = 0; i < array.Length; i++)
		{
			this.writeSByteUncheck((sbyte)array[i]);
		}
	}

	// Token: 0x06000B10 RID: 2832 RVA: 0x000D7C90 File Offset: 0x000D5E90
	public void writeUTF(string value)
	{
		Encoding unicode = Encoding.Unicode;
		Encoding encoding = Encoding.GetEncoding(65001);
		byte[] bytes = unicode.GetBytes(value);
		byte[] array = Encoding.Convert(unicode, encoding, bytes);
		this.writeShort((short)array.Length);
		this.checkLenght(array.Length);
		foreach (sbyte value2 in array)
		{
			this.writeSByteUncheck(value2);
		}
	}

	// Token: 0x06000B11 RID: 2833 RVA: 0x0000B727 File Offset: 0x00009927
	public void write(sbyte value)
	{
		this.writeSByte(value);
	}

	// Token: 0x06000B12 RID: 2834 RVA: 0x000D7D00 File Offset: 0x000D5F00
	public void write(ref sbyte[] data, int arg1, int arg2)
	{
		bool flag = data == null;
		if (!flag)
		{
			for (int i = 0; i < arg2; i++)
			{
				this.writeSByte(data[i + arg1]);
				bool flag2 = this.posWrite > this.buffer.Length;
				if (flag2)
				{
					break;
				}
			}
		}
	}

	// Token: 0x06000B13 RID: 2835 RVA: 0x0000B764 File Offset: 0x00009964
	public void write(sbyte[] value)
	{
		this.writeSByte(value);
	}

	// Token: 0x06000B14 RID: 2836 RVA: 0x000D7D50 File Offset: 0x000D5F50
	public sbyte[] getData()
	{
		bool flag = this.posWrite <= 0;
		sbyte[] result;
		if (flag)
		{
			result = null;
		}
		else
		{
			sbyte[] array = new sbyte[this.posWrite];
			for (int i = 0; i < this.posWrite; i++)
			{
				array[i] = this.buffer[i];
			}
			result = array;
		}
		return result;
	}

	// Token: 0x06000B15 RID: 2837 RVA: 0x000D7DA8 File Offset: 0x000D5FA8
	public void checkLenght(int ltemp)
	{
		bool flag = this.posWrite + ltemp > this.lenght;
		if (flag)
		{
			sbyte[] array = new sbyte[this.lenght + 1024 + ltemp];
			for (int i = 0; i < this.lenght; i++)
			{
				array[i] = this.buffer[i];
			}
			this.buffer = null;
			this.buffer = array;
			this.lenght += 1024 + ltemp;
		}
	}

	// Token: 0x06000B16 RID: 2838 RVA: 0x000D7E24 File Offset: 0x000D6024
	private static void convertString(string[] args)
	{
		string path = args[0];
		string path2 = args[1];
		using (StreamReader streamReader = new StreamReader(path, Encoding.Unicode))
		{
			using (StreamWriter streamWriter = new StreamWriter(path2, false, Encoding.UTF8))
			{
				myWriter.CopyContents(streamReader, streamWriter);
			}
		}
	}

	// Token: 0x06000B17 RID: 2839 RVA: 0x000D7E90 File Offset: 0x000D6090
	private static void CopyContents(TextReader input, TextWriter output)
	{
		char[] array = new char[8192];
		int count;
		while ((count = input.Read(array, 0, array.Length)) != 0)
		{
			output.Write(array, 0, count);
		}
		output.Flush();
		string message = output.ToString();
		Debug.Log(message);
	}

	// Token: 0x06000B18 RID: 2840 RVA: 0x000D7EE0 File Offset: 0x000D60E0
	public byte convertSbyteToByte(sbyte var)
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

	// Token: 0x06000B19 RID: 2841 RVA: 0x000D7F08 File Offset: 0x000D6108
	public byte[] convertSbyteToByte(sbyte[] var)
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

	// Token: 0x06000B1A RID: 2842 RVA: 0x0000B76F File Offset: 0x0000996F
	public void Close()
	{
		this.buffer = null;
	}

	// Token: 0x06000B1B RID: 2843 RVA: 0x0000B76F File Offset: 0x0000996F
	public void close()
	{
		this.buffer = null;
	}

	// Token: 0x040010AC RID: 4268
	public sbyte[] buffer = new sbyte[2048];

	// Token: 0x040010AD RID: 4269
	private int posWrite;

	// Token: 0x040010AE RID: 4270
	private int lenght = 2048;
}
