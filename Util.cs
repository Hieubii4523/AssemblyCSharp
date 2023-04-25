using System;

// Token: 0x02000112 RID: 274
public class Util
{
	// Token: 0x06000FCA RID: 4042 RVA: 0x00073498 File Offset: 0x00071698
	public static DataInputStream loadFile(string path)
	{
		try
		{
			return DataInputStream.getResourceAsStream(Main.res + path);
		}
		catch (Exception e)
		{
			Out.printError(e);
		}
		return null;
	}

	// Token: 0x06000FCB RID: 4043 RVA: 0x00130184 File Offset: 0x0012E384
	public static int abs(int a)
	{
		return (a < 0) ? (-a) : a;
	}

	// Token: 0x06000FCC RID: 4044 RVA: 0x001301A0 File Offset: 0x0012E3A0
	public static sbyte[] readByteArray(Message msg)
	{
		try
		{
			int num = msg.reader().readInt();
			sbyte[] result = new sbyte[num];
			msg.reader().read(ref result);
			return result;
		}
		catch (Exception e)
		{
			Out.printError(e);
		}
		return null;
	}

	// Token: 0x06000FCD RID: 4045 RVA: 0x001301F8 File Offset: 0x0012E3F8
	public static sbyte[] readByteArray(DataInputStream dos)
	{
		try
		{
			int num = dos.readInt();
			sbyte[] result = new sbyte[num];
			dos.read(ref result);
			return result;
		}
		catch (Exception e)
		{
			Out.printError(e);
		}
		return null;
	}

	// Token: 0x06000FCE RID: 4046 RVA: 0x000C1FB8 File Offset: 0x000C01B8
	public static string[] split(string original, string separator)
	{
		mVector mVector = new mVector();
		for (int i = original.IndexOf(separator); i >= 0; i = original.IndexOf(separator))
		{
			mVector.addElement(original.Substring(0, i));
			original = original.Substring(i + separator.Length);
		}
		mVector.addElement(original);
		string[] array = new string[mVector.size()];
		bool flag = mVector.size() > 0;
		if (flag)
		{
			for (int j = 0; j < mVector.size(); j++)
			{
				array[j] = (string)mVector.elementAt(j);
			}
		}
		return array;
	}
}
