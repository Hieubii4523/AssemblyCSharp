using System;

// Token: 0x02000059 RID: 89
public class ipKeyboard
{
	// Token: 0x0600060C RID: 1548 RVA: 0x0008A6D4 File Offset: 0x000888D4
	public static void openKeyBoard(string caption, int type, string text, IKAction action)
	{
		ipKeyboard.act = action;
		TouchScreenKeyboardType t = (type == 0 || type == 2) ? TouchScreenKeyboardType.ASCIICapable : TouchScreenKeyboardType.NumberPad;
		TouchScreenKeyboard.hideInput = false;
		ipKeyboard.tk = TouchScreenKeyboard.Open(text, t, false, false, type == 2, false, caption);
	}

	// Token: 0x0600060D RID: 1549 RVA: 0x0008A710 File Offset: 0x00088910
	public static void update()
	{
		try
		{
			bool flag = ipKeyboard.tk != null && ipKeyboard.tk.done;
			if (flag)
			{
				bool flag2 = ipKeyboard.act != null;
				if (flag2)
				{
					ipKeyboard.act.perform(ipKeyboard.tk.text);
				}
				ipKeyboard.tk.text = string.Empty;
				ipKeyboard.tk = null;
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x040008DB RID: 2267
	public static TouchScreenKeyboard tk;

	// Token: 0x040008DC RID: 2268
	public static int TEXT;

	// Token: 0x040008DD RID: 2269
	public static int NUMBERIC = 1;

	// Token: 0x040008DE RID: 2270
	public static int PASS = 2;

	// Token: 0x040008DF RID: 2271
	private static IKAction act;
}
