using System;
using UnityEngine;

// Token: 0x020000C4 RID: 196
public class Out
{
	// Token: 0x06000B6B RID: 2923 RVA: 0x0000B89B File Offset: 0x00009A9B
	public static void printLine(string text)
	{
		Debug.Log("aaa: " + text);
	}

	// Token: 0x06000B6C RID: 2924 RVA: 0x000094D2 File Offset: 0x000076D2
	public static void printError(Exception e)
	{
		Debug.LogError(e);
	}
}
