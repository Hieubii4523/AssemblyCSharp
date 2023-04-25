using System;

// Token: 0x020000B7 RID: 183
public class MyStream
{
	// Token: 0x06000AFE RID: 2814 RVA: 0x000D7A4C File Offset: 0x000D5C4C
	public static DataInputStream readFile(string path)
	{
		path = Main.res + path;
		DataInputStream result;
		try
		{
			result = DataInputStream.getResourceAsStream(path);
		}
		catch (Exception)
		{
			result = null;
		}
		return result;
	}
}
