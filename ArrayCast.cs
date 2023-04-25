using System;

// Token: 0x02000007 RID: 7
public class ArrayCast
{
	// Token: 0x0600000F RID: 15 RVA: 0x0000C3A8 File Offset: 0x0000A5A8
	public static sbyte[] cast(byte[] data)
	{
		sbyte[] array = new sbyte[data.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (sbyte)data[i];
		}
		return array;
	}

	// Token: 0x06000010 RID: 16 RVA: 0x0000C3E0 File Offset: 0x0000A5E0
	public static byte[] cast(sbyte[] data)
	{
		byte[] array = new byte[data.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (byte)data[i];
		}
		return array;
	}

	// Token: 0x06000011 RID: 17 RVA: 0x0000C418 File Offset: 0x0000A618
	public static char[] ToCharArray(sbyte[] data)
	{
		char[] array = new char[data.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (char)data[i];
		}
		return array;
	}
}
