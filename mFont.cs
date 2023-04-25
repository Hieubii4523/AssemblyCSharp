using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000095 RID: 149
public class mFont
{
	// Token: 0x06000947 RID: 2375 RVA: 0x000C0FDC File Offset: 0x000BF1DC
	public mFont(sbyte id, sbyte colorP)
	{
		string text = "chelthm";
		bool flag = (id > 0 && id < 10) || id == 19 || id == 31;
		if (flag)
		{
			text = "fontbu";
			this.sizef = 8;
			this.yAdd = 3;
			bool flag2 = mGraphics.zoomLevel == 1;
			if (flag2)
			{
				text = "fontx1";
				this.sizef = 11;
				this.yAdd = 2;
			}
		}
		else
		{
			bool flag3 = id >= 10 && id <= 18;
			if (flag3)
			{
				text = "fontnho";
				this.yAdd = 4;
				this.sizef = 9;
				bool flag4 = mGraphics.zoomLevel == 1;
				if (flag4)
				{
					text = "fontx1";
					this.sizef = 9;
					this.yAdd = 2;
				}
			}
			else
			{
				bool flag5 = id > 24;
				if (flag5)
				{
					text = "fontbu";
					this.sizef = 10;
					this.yAdd = 5;
					bool flag6 = mGraphics.zoomLevel == 1;
					if (flag6)
					{
						text = "fontx1";
						this.sizef = 11;
						this.yAdd = 2;
					}
				}
			}
		}
		this.id = id;
		this.idPhong = colorP;
		text = "FontSys/" + text;
		this.myFont = (Font)Resources.Load(text);
		bool flag7 = id < 25;
		if (flag7)
		{
			this.color1 = this.setColorFontPhong(colorP);
			this.color2 = this.setColorFontPhong(colorP);
		}
		else
		{
			this.color1 = this.bigColor((int)id);
			this.color2 = this.bigColor((int)id);
		}
		this.wO = this.getWidthExactOf("o");
	}

	// Token: 0x06000948 RID: 2376 RVA: 0x000C11A0 File Offset: 0x000BF3A0
	public static void loadmFont()
	{
		mFont.gI = new mFont(0, 0);
		mFont.tahoma_7b_red = new mFont(1, 6);
		mFont.tahoma_7b_blue = new mFont(2, 4);
		mFont.tahoma_7b_white = new mFont(3, 0);
		mFont.tahoma_7b_yellow = new mFont(4, 5);
		mFont.tahoma_7b_black = new mFont(5, 7);
		mFont.tahoma_7b_green = new mFont(7, 1);
		mFont.tahoma_7b_violet = new mFont(7, 2);
		mFont.tahoma_7b_orange = new mFont(7, 3);
		mFont.tahoma_7b_brown = new mFont(8, 8);
		mFont.tahoma_7_yellow = new mFont(13, 5);
		mFont.tahoma_7_red = new mFont(15, 6);
		mFont.tahoma_7_blue = new mFont(16, 4);
		mFont.tahoma_7_green = new mFont(17, 1);
		mFont.tahoma_7_white = new mFont(18, 0);
		mFont.tahoma_7_black = new mFont(18, 7);
		mFont.tahoma_7_violet = new mFont(18, 2);
		mFont.tahoma_7_orange = new mFont(18, 3);
		mFont.tahoma_7_brown = new mFont(18, 8);
		mFont.number_yellow = new mFont(20, 5);
		mFont.number_red = new mFont(21, 6);
		mFont.number_green = new mFont(22, 1);
		mFont.number_orange = new mFont(24, 3);
		mFont.bigNumber_red = new mFont(25, 0);
		mFont.bigNumber_yellow = new mFont(26, 0);
		mFont.bigNumber_green = new mFont(27, 0);
		mFont.bigNumber_While = new mFont(28, 0);
		mFont.bigNumber_blue = new mFont(29, 0);
		mFont.bigNumber_orange = new mFont(30, 0);
		mFont.fontBigBorder = new mFont(31, 0);
		mFont.font_f12_White = new mFont(32, 0);
		mFont.tahoma_7_white_Border = new mFont(33, 0);
		mFont.tahoma_7b_yellow_Border = new mFont(34, 0);
		mFont.nameFontRed = mFont.tahoma_7b_red;
		mFont.nameFontYellow = mFont.tahoma_7_yellow;
		mFont.nameFontGreen = mFont.tahoma_7_green;
		mFont.yAddFont = 1;
		bool flag = mGraphics.zoomLevel == 1;
		if (flag)
		{
			mFont.yAddFont = -3;
		}
	}

	// Token: 0x06000949 RID: 2377 RVA: 0x000C138C File Offset: 0x000BF58C
	public Color setColor(int rgb)
	{
		int num = rgb & 255;
		int num2 = rgb >> 8 & 255;
		int num3 = rgb >> 16 & 255;
		float b = (float)num / 256f;
		float g = (float)num2 / 256f;
		float r = (float)num3 / 256f;
		return new Color(r, g, b);
	}

	// Token: 0x0600094A RID: 2378 RVA: 0x000C13E4 File Offset: 0x000BF5E4
	public Color bigColor(int id)
	{
		Color[] array = new Color[]
		{
			Color.red,
			Color.yellow,
			Color.green,
			Color.white,
			this.setColor(40404),
			Color.red,
			Color.white,
			Color.white,
			Color.red,
			Color.red
		};
		return array[id - 25];
	}

	// Token: 0x0600094B RID: 2379 RVA: 0x0000B0CE File Offset: 0x000092CE
	public void setColorByID(int ID)
	{
		this.color1 = this.setColor(mFont.colorJava[ID]);
		this.color2 = this.setColor(mFont.colorJava[ID]);
	}

	// Token: 0x0600094C RID: 2380 RVA: 0x0000B0F7 File Offset: 0x000092F7
	public void setColorByIDPhong(int ID)
	{
		this.color1 = this.setColor(mFont.colorPhong[ID]);
		this.color2 = this.setColor(mFont.colorPhong[ID]);
	}

	// Token: 0x0600094D RID: 2381 RVA: 0x000C1488 File Offset: 0x000BF688
	public void setTypePaint(mGraphics g, string st, int x, int y, int align, sbyte idFont)
	{
		sbyte colorByIDPhong = this.idPhong;
		bool flag = idFont > 0;
		if (flag)
		{
			colorByIDPhong = idFont;
		}
		x--;
		bool flag2 = this.id > 24;
		if (flag2)
		{
			Color[] array = new Color[]
			{
				this.setColor(6029312),
				this.setColor(7169025),
				this.setColor(7680),
				this.setColor(0),
				this.setColor(9264),
				this.setColor(6029312),
				this.setColor(5127485),
				this.setColor(5127485),
				this.setColor(6029312),
				this.setColor(6029312)
			};
			this.color1 = array[(int)(this.id - 25)];
			this.color2 = array[(int)(this.id - 25)];
			this._drawString(g, st, x + 1, y, align);
			this._drawString(g, st, x - 1, y, align);
			this._drawString(g, st, x, y - 1, align);
			this._drawString(g, st, x, y + 1, align);
			this._drawString(g, st, x + 1, y + 1, align);
			this._drawString(g, st, x + 1, y - 1, align);
			this._drawString(g, st, x - 1, y - 1, align);
			this._drawString(g, st, x - 1, y + 1, align);
			this.color1 = this.bigColor((int)this.id);
			this.color2 = this.bigColor((int)this.id);
		}
		else
		{
			this.setColorByIDPhong((int)colorByIDPhong);
		}
		this._drawString(g, st, x, y - this.yAdd, align);
	}

	// Token: 0x0600094E RID: 2382 RVA: 0x000C1674 File Offset: 0x000BF874
	public Color setColorFont(sbyte id)
	{
		return this.setColor(mFont.colorJava[(int)id]);
	}

	// Token: 0x0600094F RID: 2383 RVA: 0x000C1694 File Offset: 0x000BF894
	public Color setColorFontPhong(sbyte id)
	{
		return this.setColor(mFont.colorPhong[(int)id]);
	}

	// Token: 0x06000950 RID: 2384 RVA: 0x0000B120 File Offset: 0x00009320
	public void drawString(mGraphics g, string st, int x, int y, int align)
	{
		this.setTypePaint(g, st, x, y, align, 0);
	}

	// Token: 0x06000951 RID: 2385 RVA: 0x0000B132 File Offset: 0x00009332
	public void drawString(mGraphics g, string st, int x, int y, int align, mFont font)
	{
		this.setTypePaint(g, st, x, y + 1, align, font.id);
		this.setTypePaint(g, st, x, y, align, 0);
	}

	// Token: 0x06000952 RID: 2386 RVA: 0x000C16B4 File Offset: 0x000BF8B4
	public mVector splitFontVector(string src, int lineWidth)
	{
		mVector mVector = new mVector();
		string text = string.Empty;
		for (int i = 0; i < src.Length; i++)
		{
			bool flag = src[i] == '\n' || src[i] == '\b';
			if (flag)
			{
				mVector.addElement(text);
				text = string.Empty;
			}
			else
			{
				text += src[i].ToString();
				bool flag2 = this.getWidth(text) > lineWidth;
				if (flag2)
				{
					int num = text.Length - 1;
					while (num >= 0 && text[num] != ' ')
					{
						num--;
					}
					bool flag3 = num < 0;
					if (flag3)
					{
						num = text.Length - 1;
					}
					mVector.addElement(text.Substring(0, num));
					i = i - (text.Length - num) + 1;
					text = string.Empty;
				}
				bool flag4 = i == src.Length - 1 && !text.Trim().Equals(string.Empty);
				if (flag4)
				{
					mVector.addElement(text);
				}
			}
		}
		return mVector;
	}

	// Token: 0x06000953 RID: 2387 RVA: 0x000C17F0 File Offset: 0x000BF9F0
	public static mVector splitFontVector(string src, char c)
	{
		mVector mVector = new mVector();
		string text = string.Empty;
		char[] array = src.ToCharArray();
		for (int i = 0; i < src.Length; i++)
		{
			bool flag = array[i] == c;
			if (flag)
			{
				mVector.addElement(text);
				text = string.Empty;
			}
			else
			{
				text += array[i].ToString();
				bool flag2 = i == src.Length - 1 && !text.Trim().Equals(string.Empty);
				if (flag2)
				{
					mVector.addElement(text);
				}
			}
		}
		return mVector;
	}

	// Token: 0x06000954 RID: 2388 RVA: 0x000C1894 File Offset: 0x000BFA94
	public string splitFirst(string str)
	{
		string text = string.Empty;
		bool flag = false;
		for (int i = 0; i < str.Length; i++)
		{
			bool flag2 = !flag;
			if (flag2)
			{
				string text2 = str.Substring(i);
				text = ((!this.compare(text2, " ")) ? (text + text2) : (text + str[i].ToString() + "-"));
				flag = true;
			}
			else
			{
				bool flag3 = str[i] == ' ';
				if (flag3)
				{
					flag = false;
				}
			}
		}
		return text;
	}

	// Token: 0x06000955 RID: 2389 RVA: 0x000C192C File Offset: 0x000BFB2C
	public string[] splitStrInLine(string src, int lineWidth)
	{
		ArrayList arrayList = this.splitStrInLineA(src, lineWidth);
		string[] array = new string[arrayList.Count];
		for (int i = 0; i < arrayList.Count; i++)
		{
			array[i] = (string)arrayList[i];
		}
		return array;
	}

	// Token: 0x06000956 RID: 2390 RVA: 0x000C197C File Offset: 0x000BFB7C
	public ArrayList splitStrInLineA(string src, int lineWidth)
	{
		ArrayList arrayList = new ArrayList();
		int num = 0;
		int num2 = 0;
		int length = src.Length;
		bool flag = length < 5;
		ArrayList result;
		if (flag)
		{
			arrayList.Add(src);
			result = arrayList;
		}
		else
		{
			string text = string.Empty;
			try
			{
				for (;;)
				{
					bool flag2 = this.getWidthNotExactOf(text) < lineWidth;
					if (flag2)
					{
						text += src[num2].ToString();
						num2++;
						bool flag3 = src[num2] != '\n';
						if (flag3)
						{
							bool flag4 = num2 < length - 1;
							if (flag4)
							{
								continue;
							}
							num2 = length - 1;
						}
					}
					bool flag5 = num2 != length - 1 && src[num2 + 1] != ' ';
					if (flag5)
					{
						int num3 = num2;
						while (src[num2 + 1] != '\n' && (src[num2 + 1] != ' ' || src[num2] == ' ') && num2 != num)
						{
							num2--;
						}
						bool flag6 = num2 == num;
						if (flag6)
						{
							num2 = num3;
						}
					}
					string text2 = src.Substring(num, num2 + 1 - num);
					bool flag7 = text2[0] == '\n';
					if (flag7)
					{
						text2 = text2.Substring(1, text2.Length - 1);
					}
					bool flag8 = text2[text2.Length - 1] == '\n';
					if (flag8)
					{
						text2 = text2.Substring(0, text2.Length - 1);
					}
					arrayList.Add(text2);
					bool flag9 = num2 != length - 1;
					if (!flag9)
					{
						goto IL_1C4;
					}
					num = num2 + 1;
					while (num != length - 1 && src[num] == ' ')
					{
						num++;
					}
					bool flag10 = num == length - 1;
					if (flag10)
					{
						break;
					}
					num2 = num;
					text = string.Empty;
				}
				return arrayList;
				IL_1C4:
				result = arrayList;
			}
			catch (Exception ex)
			{
				Cout.LogWarning(string.Concat(new string[]
				{
					"EXCEPTION WHEN REAL SPLIT ",
					src,
					"\nend=",
					num2.ToString(),
					"\n",
					ex.Message,
					"\n",
					ex.StackTrace
				}));
				arrayList.Add(src);
				result = arrayList;
			}
		}
		return result;
	}

	// Token: 0x06000957 RID: 2391 RVA: 0x000C1BE0 File Offset: 0x000BFDE0
	public string[] splitFontArray(string src, int lineWidth)
	{
		mVector mVector = this.splitFontVector(src, lineWidth);
		string[] array = new string[mVector.size()];
		for (int i = 0; i < mVector.size(); i++)
		{
			array[i] = (string)mVector.elementAt(i);
		}
		return array;
	}

	// Token: 0x06000958 RID: 2392 RVA: 0x000C1C30 File Offset: 0x000BFE30
	public bool compare(string strSource, string str)
	{
		for (int i = 0; i < strSource.Length; i++)
		{
			bool flag = (string.Empty + strSource[i].ToString()).Equals(str);
			if (flag)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000959 RID: 2393 RVA: 0x000C1C84 File Offset: 0x000BFE84
	public int getWidth(string s)
	{
		return this.getWidthExactOf(s);
	}

	// Token: 0x0600095A RID: 2394 RVA: 0x000C1CA0 File Offset: 0x000BFEA0
	public int getWidthExactOf(string s)
	{
		int result;
		try
		{
			result = (int)new GUIStyle
			{
				font = this.myFont,
				fontSize = this.sizef * mGraphics.zoomLevel
			}.CalcSize(new GUIContent(s)).x / mGraphics.zoomLevel;
		}
		catch (Exception ex)
		{
			Cout.LogError(string.Concat(new string[]
			{
				"GET WIDTH OF ",
				s,
				" FAIL.\n",
				ex.Message,
				"\n",
				ex.StackTrace
			}));
			result = this.getWidthNotExactOf(s);
		}
		return result;
	}

	// Token: 0x0600095B RID: 2395 RVA: 0x000C1D4C File Offset: 0x000BFF4C
	public int getWidthNotExactOf(string s)
	{
		return s.Length * this.wO / mGraphics.zoomLevel;
	}

	// Token: 0x0600095C RID: 2396 RVA: 0x000C1D74 File Offset: 0x000BFF74
	public int getHeight()
	{
		bool flag = this.height > 0;
		int result;
		if (flag)
		{
			result = this.height / mGraphics.zoomLevel;
		}
		else
		{
			GUIStyle guistyle = new GUIStyle();
			guistyle.font = this.myFont;
			guistyle.fontSize = this.sizef * mGraphics.zoomLevel;
			try
			{
				this.height = (int)guistyle.CalcSize(new GUIContent("Adg")).y + 2;
			}
			catch (Exception ex)
			{
				Cout.LogError("FAIL GET HEIGHT " + ex.StackTrace);
				this.height = 20;
			}
			result = this.height / mGraphics.zoomLevel;
		}
		return result;
	}

	// Token: 0x0600095D RID: 2397 RVA: 0x000C1E2C File Offset: 0x000C002C
	public void _drawString(mGraphics g, string st, int x0, int y0, int align)
	{
		y0 += mFont.yAddFont;
		GUIStyle guistyle = new GUIStyle(GUI.skin.label);
		guistyle.font = this.myFont;
		guistyle.fontSize = this.sizef * mGraphics.zoomLevel;
		float num = 0f;
		float num2 = 0f;
		switch (align)
		{
		case 0:
			num = (float)x0;
			num2 = (float)y0;
			guistyle.alignment = TextAnchor.UpperLeft;
			break;
		case 1:
			num = (float)(x0 - MotherCanvas.w);
			num2 = (float)y0;
			guistyle.alignment = TextAnchor.UpperRight;
			break;
		case 2:
		case 3:
			num = (float)(x0 - MotherCanvas.w / 2);
			num2 = (float)y0;
			guistyle.alignment = TextAnchor.UpperCenter;
			break;
		}
		guistyle.normal.textColor = this.color1;
		g.drawString(st, (int)num, (int)num2, guistyle);
	}

	// Token: 0x0600095E RID: 2398 RVA: 0x000C1F00 File Offset: 0x000C0100
	public static string[] splitStringSv(string _text, string _searchStr)
	{
		int num = 0;
		int startIndex = 0;
		int length = _searchStr.Length;
		int num2 = _text.IndexOf(_searchStr, startIndex);
		while (num2 != -1)
		{
			startIndex = num2 + length;
			num2 = _text.IndexOf(_searchStr, startIndex);
			num++;
		}
		string[] array = new string[num + 1];
		int num3 = _text.IndexOf(_searchStr);
		int num4 = 0;
		int num5 = 0;
		while (num3 != -1)
		{
			array[num5] = _text.Substring(num4, num3 - num4);
			num4 = num3 + length;
			num3 = _text.IndexOf(_searchStr, num4);
			num5++;
		}
		array[num5] = _text.Substring(num4, _text.Length - num4);
		return array;
	}

	// Token: 0x0600095F RID: 2399 RVA: 0x000090B5 File Offset: 0x000072B5
	public void reloadImage()
	{
	}

	// Token: 0x06000960 RID: 2400 RVA: 0x000090B5 File Offset: 0x000072B5
	public void freeImage()
	{
	}

	// Token: 0x06000961 RID: 2401 RVA: 0x000C1FB8 File Offset: 0x000C01B8
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

	// Token: 0x04000EE5 RID: 3813
	public const sbyte LEFT = 0;

	// Token: 0x04000EE6 RID: 3814
	public const sbyte RIGHT = 1;

	// Token: 0x04000EE7 RID: 3815
	public const sbyte CENTER = 2;

	// Token: 0x04000EE8 RID: 3816
	public const sbyte RED = 0;

	// Token: 0x04000EE9 RID: 3817
	public const sbyte YELLOW = 1;

	// Token: 0x04000EEA RID: 3818
	public const sbyte GREEN = 2;

	// Token: 0x04000EEB RID: 3819
	public const sbyte FATAL = 3;

	// Token: 0x04000EEC RID: 3820
	public const sbyte MISS = 4;

	// Token: 0x04000EED RID: 3821
	public const sbyte ORANGE = 5;

	// Token: 0x04000EEE RID: 3822
	public const sbyte ADDMONEY = 6;

	// Token: 0x04000EEF RID: 3823
	public const sbyte MISS_ME = 7;

	// Token: 0x04000EF0 RID: 3824
	public const sbyte FATAL_ME = 8;

	// Token: 0x04000EF1 RID: 3825
	public const sbyte GREY = 8;

	// Token: 0x04000EF2 RID: 3826
	public const sbyte HP = 9;

	// Token: 0x04000EF3 RID: 3827
	public const sbyte MP = 10;

	// Token: 0x04000EF4 RID: 3828
	private int space;

	// Token: 0x04000EF5 RID: 3829
	private Image imgFont;

	// Token: 0x04000EF6 RID: 3830
	private string strFont;

	// Token: 0x04000EF7 RID: 3831
	private int[][] fImages;

	// Token: 0x04000EF8 RID: 3832
	public static int yAddFont;

	// Token: 0x04000EF9 RID: 3833
	public static int[] colorPhong = new int[]
	{
		16777215,
		6741809,
		11830015,
		16686378,
		7511551,
		16580155,
		16711680,
		1250067,
		11957553
	};

	// Token: 0x04000EFA RID: 3834
	public static int[] colorJava = new int[]
	{
		0,
		16711680,
		6520319,
		16777215,
		16755200,
		5449989,
		21285,
		52224,
		7386228,
		16771788,
		0,
		65535,
		21285,
		16776960,
		5592405,
		16742263,
		33023,
		8701737,
		15723503,
		7999781,
		16768815,
		14961237,
		4124899,
		4671303,
		16096312,
		16711680,
		16755200,
		52224,
		16777215,
		6520319,
		16096312
	};

	// Token: 0x04000EFB RID: 3835
	public static mFont gI;

	// Token: 0x04000EFC RID: 3836
	public static mFont tahoma_7b_red;

	// Token: 0x04000EFD RID: 3837
	public static mFont tahoma_7b_blue;

	// Token: 0x04000EFE RID: 3838
	public static mFont tahoma_7b_white;

	// Token: 0x04000EFF RID: 3839
	public static mFont tahoma_7b_yellow;

	// Token: 0x04000F00 RID: 3840
	public static mFont tahoma_7b_black;

	// Token: 0x04000F01 RID: 3841
	public static mFont tahoma_7b_violet;

	// Token: 0x04000F02 RID: 3842
	public static mFont tahoma_7b_orange;

	// Token: 0x04000F03 RID: 3843
	public static mFont tahoma_7b_green;

	// Token: 0x04000F04 RID: 3844
	public static mFont tahoma_7b_brown;

	// Token: 0x04000F05 RID: 3845
	public static mFont tahoma_7_red;

	// Token: 0x04000F06 RID: 3846
	public static mFont tahoma_7_blue;

	// Token: 0x04000F07 RID: 3847
	public static mFont tahoma_7_white;

	// Token: 0x04000F08 RID: 3848
	public static mFont tahoma_7_yellow;

	// Token: 0x04000F09 RID: 3849
	public static mFont tahoma_7_black;

	// Token: 0x04000F0A RID: 3850
	public static mFont tahoma_7_violet;

	// Token: 0x04000F0B RID: 3851
	public static mFont tahoma_7_orange;

	// Token: 0x04000F0C RID: 3852
	public static mFont tahoma_7_green;

	// Token: 0x04000F0D RID: 3853
	public static mFont tahoma_7_brown;

	// Token: 0x04000F0E RID: 3854
	public static mFont number_yellow;

	// Token: 0x04000F0F RID: 3855
	public static mFont number_red;

	// Token: 0x04000F10 RID: 3856
	public static mFont number_green;

	// Token: 0x04000F11 RID: 3857
	public static mFont number_orange;

	// Token: 0x04000F12 RID: 3858
	public static mFont bigNumber_red;

	// Token: 0x04000F13 RID: 3859
	public static mFont bigNumber_While;

	// Token: 0x04000F14 RID: 3860
	public static mFont bigNumber_yellow;

	// Token: 0x04000F15 RID: 3861
	public static mFont bigNumber_green;

	// Token: 0x04000F16 RID: 3862
	public static mFont bigNumber_orange;

	// Token: 0x04000F17 RID: 3863
	public static mFont bigNumber_blue;

	// Token: 0x04000F18 RID: 3864
	public static mFont fontBigBorder;

	// Token: 0x04000F19 RID: 3865
	public static mFont font_f12_White;

	// Token: 0x04000F1A RID: 3866
	public static mFont tahoma_7_white_Border;

	// Token: 0x04000F1B RID: 3867
	public static mFont tahoma_7b_yellow_Border;

	// Token: 0x04000F1C RID: 3868
	public static mFont nameFontRed;

	// Token: 0x04000F1D RID: 3869
	public static mFont nameFontYellow;

	// Token: 0x04000F1E RID: 3870
	public static mFont nameFontGreen;

	// Token: 0x04000F1F RID: 3871
	public Font myFont;

	// Token: 0x04000F20 RID: 3872
	private int height;

	// Token: 0x04000F21 RID: 3873
	private int wO;

	// Token: 0x04000F22 RID: 3874
	public Color color1 = Color.white;

	// Token: 0x04000F23 RID: 3875
	public Color color2 = Color.gray;

	// Token: 0x04000F24 RID: 3876
	public sbyte id;

	// Token: 0x04000F25 RID: 3877
	public sbyte idPhong;

	// Token: 0x04000F26 RID: 3878
	public int fstyle;

	// Token: 0x04000F27 RID: 3879
	public string st1 = "áàảãạăắằẳẵặâấầẩẫậéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵđÁÀẢÃẠĂẮẰẲẴẶÂẤẦẨẪẬÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴĐ";

	// Token: 0x04000F28 RID: 3880
	public string st2 = "¸µ¶·¹¨¾»¼½Æ©ÊÇÈÉËÐÌÎÏÑªÕÒÓÔÖÝ×ØÜÞãßáâä«èåæçé¬íêëìîóïñòô­øõö÷ùýúûüþ®¸µ¶·¹¡¾»¼½Æ¢ÊÇÈÉËÐÌÎÏÑ£ÕÒÓÔÖÝ×ØÜÞãßáâä¤èåæçé¥íêëìîóïñòô¦øõö÷ùýúûüþ§";

	// Token: 0x04000F29 RID: 3881
	public static char xu = '`';

	// Token: 0x04000F2A RID: 3882
	public static char luong = '~';

	// Token: 0x04000F2B RID: 3883
	public static char huyChuong = '¢';

	// Token: 0x04000F2C RID: 3884
	public static string xuStr = "`";

	// Token: 0x04000F2D RID: 3885
	public static string luongStr = "~";

	// Token: 0x04000F2E RID: 3886
	public static string huyChuongStr = "¢";

	// Token: 0x04000F2F RID: 3887
	public static char[] nguyenLieu = new char[]
	{
		'¤',
		'¥'
	};

	// Token: 0x04000F30 RID: 3888
	public static string[] nguyenLieuStr = new string[]
	{
		"¤",
		"¥"
	};

	// Token: 0x04000F31 RID: 3889
	private int yAdd;

	// Token: 0x04000F32 RID: 3890
	private int sizef = 10;
}
