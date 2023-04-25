using System;
using UnityEngine;

// Token: 0x020000BB RID: 187
internal class Net
{
	// Token: 0x06000B32 RID: 2866 RVA: 0x000D95B4 File Offset: 0x000D77B4
	public static void update()
	{
		bool flag = Net.www != null && Net.www.isDone;
		if (flag)
		{
			string text = string.Empty;
			bool flag2 = Net.www.error == null || Net.www.error.Equals(string.Empty);
			if (flag2)
			{
				text = Net.www.text;
			}
			Net.www = null;
			bool flag3 = Net.h != null;
			if (flag3)
			{
				Net.h.perform(text);
			}
		}
	}

	// Token: 0x06000B33 RID: 2867 RVA: 0x000D9638 File Offset: 0x000D7838
	public static void connectHTTP(string link, IKAction h)
	{
		bool flag = Net.www != null;
		if (flag)
		{
			Cout.LogError("GET HTTP BUSY");
		}
		Net.www = new WWW(link);
		Net.h = h;
	}

	// Token: 0x040010C3 RID: 4291
	public static WWW www;

	// Token: 0x040010C4 RID: 4292
	public static IKAction h;
}
