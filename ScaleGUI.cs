using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000E1 RID: 225
public class ScaleGUI
{
	// Token: 0x06000D93 RID: 3475 RVA: 0x00106334 File Offset: 0x00104534
	public static void initScaleGUI()
	{
		Cout.println("Init Scale GUI: Screen.w=" + Screen.width.ToString() + " Screen.h=" + Screen.height.ToString());
		ScaleGUI.WIDTH = (float)Screen.width;
		ScaleGUI.HEIGHT = (float)Screen.height;
		ScaleGUI.scaleScreen = false;
		bool flag = Screen.width <= 1200;
		if (flag)
		{
		}
	}

	// Token: 0x06000D94 RID: 3476 RVA: 0x001063A4 File Offset: 0x001045A4
	public static void BeginGUI()
	{
		bool flag = ScaleGUI.scaleScreen;
		if (flag)
		{
			ScaleGUI.stack.Add(GUI.matrix);
			Matrix4x4 rhs = default(Matrix4x4);
			float num = (float)Screen.width;
			float num2 = (float)Screen.height;
			float num3 = num / num2;
			Vector3 zero = Vector3.zero;
			float d = (num3 >= ScaleGUI.WIDTH / ScaleGUI.HEIGHT) ? ((float)Screen.height / ScaleGUI.HEIGHT) : ((float)Screen.width / ScaleGUI.WIDTH);
			rhs.SetTRS(zero, Quaternion.identity, Vector3.one * d);
			GUI.matrix *= rhs;
		}
	}

	// Token: 0x06000D95 RID: 3477 RVA: 0x00106450 File Offset: 0x00104650
	public static void EndGUI()
	{
		bool flag = ScaleGUI.scaleScreen;
		if (flag)
		{
			GUI.matrix = ScaleGUI.stack[ScaleGUI.stack.Count - 1];
			ScaleGUI.stack.RemoveAt(ScaleGUI.stack.Count - 1);
		}
	}

	// Token: 0x06000D96 RID: 3478 RVA: 0x0010649C File Offset: 0x0010469C
	public static float scaleX(float x)
	{
		bool flag = !ScaleGUI.scaleScreen;
		float result;
		if (flag)
		{
			result = x;
		}
		else
		{
			x = x * ScaleGUI.WIDTH / (float)Screen.width;
			result = x;
		}
		return result;
	}

	// Token: 0x06000D97 RID: 3479 RVA: 0x001064D0 File Offset: 0x001046D0
	public static float scaleY(float y)
	{
		bool flag = !ScaleGUI.scaleScreen;
		float result;
		if (flag)
		{
			result = y;
		}
		else
		{
			y = y * ScaleGUI.HEIGHT / (float)Screen.height;
			result = y;
		}
		return result;
	}

	// Token: 0x040014CF RID: 5327
	public static bool scaleScreen;

	// Token: 0x040014D0 RID: 5328
	public static float WIDTH;

	// Token: 0x040014D1 RID: 5329
	public static float HEIGHT;

	// Token: 0x040014D2 RID: 5330
	private static List<Matrix4x4> stack = new List<Matrix4x4>();
}
