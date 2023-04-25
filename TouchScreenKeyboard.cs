using System;

// Token: 0x0200010C RID: 268
public class TouchScreenKeyboard
{
	// Token: 0x06000F9B RID: 3995 RVA: 0x0012B708 File Offset: 0x00129908
	public static TouchScreenKeyboard Open(string text, TouchScreenKeyboardType t, bool b1, bool b2, bool type, bool b3, string caption)
	{
		return null;
	}

	// Token: 0x06000F9C RID: 3996 RVA: 0x000090B5 File Offset: 0x000072B5
	public static void Clear()
	{
	}

	// Token: 0x04001A1D RID: 6685
	public static bool hideInput;

	// Token: 0x04001A1E RID: 6686
	public static bool visible;

	// Token: 0x04001A1F RID: 6687
	public bool done;

	// Token: 0x04001A20 RID: 6688
	public bool active;

	// Token: 0x04001A21 RID: 6689
	public string text;
}
