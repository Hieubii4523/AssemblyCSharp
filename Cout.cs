using System;
using UnityEngine;

// Token: 0x0200001D RID: 29
public class Cout
{
	// Token: 0x06000115 RID: 277 RVA: 0x000090B5 File Offset: 0x000072B5
	public static void println(string s)
	{
	}

	// Token: 0x06000116 RID: 278 RVA: 0x000090B5 File Offset: 0x000072B5
	public static void Log(string str)
	{
	}

	// Token: 0x06000117 RID: 279 RVA: 0x000090B5 File Offset: 0x000072B5
	public static void LogError(string str)
	{
	}

	// Token: 0x06000118 RID: 280 RVA: 0x000090B5 File Offset: 0x000072B5
	public static void LogError2(string str)
	{
	}

	// Token: 0x06000119 RID: 281 RVA: 0x000094D2 File Offset: 0x000076D2
	public static void LogError3(string str)
	{
		Debug.LogError(str);
	}

	// Token: 0x0600011A RID: 282 RVA: 0x000090B5 File Offset: 0x000072B5
	public static void LogWarning(string str)
	{
	}

	// Token: 0x04000258 RID: 600
	public static int count;
}
