using System;
using System.Threading;

// Token: 0x02000108 RID: 264
public class TField
{
	// Token: 0x06000F47 RID: 3911 RVA: 0x00126F8C File Offset: 0x0012518C
	public TField(MainScreen parentScr)
	{
		this.text = string.Empty;
		this.parentScr = parentScr;
		this.init();
		this.setFocus(false);
		this.setheightText();
	}

	// Token: 0x06000F48 RID: 3912 RVA: 0x00127048 File Offset: 0x00125248
	public TField()
	{
		this.text = string.Empty;
		this.init();
		this.setFocus(false);
		this.setheightText();
	}

	// Token: 0x06000F49 RID: 3913 RVA: 0x00127100 File Offset: 0x00125300
	public TField(int x, int y, int w, int h)
	{
		this.text = string.Empty;
		this.init();
		this.x = x;
		this.y = y;
		this.width = w;
		this.height = h;
	}

	// Token: 0x06000F4A RID: 3914 RVA: 0x001271C4 File Offset: 0x001253C4
	public TField(int x, int y, int width)
	{
		this.text = string.Empty;
		this.x = x;
		this.y = y;
		this.width = width;
		this.init();
		this.setFocus(false);
		this.setheightText();
	}

	// Token: 0x06000F4B RID: 3915 RVA: 0x00127290 File Offset: 0x00125490
	public TField(string text, int maxLen, int inputType)
	{
		this.text = text;
		this.maxTextLenght = maxLen;
		this.inputType = inputType;
		this.init();
		this.isTfield = true;
	}

	// Token: 0x06000F4C RID: 3916 RVA: 0x00127348 File Offset: 0x00125548
	public static bool setNormal(char ch)
	{
		bool flag = (ch < '0' || ch > '9') && (ch < 'A' || ch > 'Z') && (ch < 'a' || ch > 'z');
		return !flag;
	}

	// Token: 0x06000F4D RID: 3917 RVA: 0x0000C1F6 File Offset: 0x0000A3F6
	public void doChangeToTextBox()
	{
		this.setFocusWithKb(true);
	}

	// Token: 0x06000F4E RID: 3918 RVA: 0x0000C201 File Offset: 0x0000A401
	public void setStringNull(string str)
	{
		this.strnull = str;
	}

	// Token: 0x06000F4F RID: 3919 RVA: 0x00127388 File Offset: 0x00125588
	public static int getHeight()
	{
		bool isTouch = GameCanvas.isTouch;
		int result;
		if (isTouch)
		{
			result = 28;
		}
		else
		{
			result = 20;
		}
		return result;
	}

	// Token: 0x06000F50 RID: 3920 RVA: 0x001273AC File Offset: 0x001255AC
	public static void setVendorTypeMode(int mode)
	{
		bool flag = mode == TField.MOTO;
		if (flag)
		{
			TField.print[0] = "0";
			TField.print[10] = " *";
			TField.print[11] = "#";
			TField.changeModeKey = 35;
		}
		else
		{
			bool flag2 = mode == TField.NOKIA;
			if (flag2)
			{
				TField.print[0] = " 0";
				TField.print[10] = "*";
				TField.print[11] = "#";
				TField.changeModeKey = 35;
			}
			else
			{
				bool flag3 = mode == TField.ORTHER;
				if (flag3)
				{
					TField.print[0] = "0";
					TField.print[10] = "*";
					TField.print[11] = " #";
					TField.changeModeKey = 42;
				}
			}
		}
	}

	// Token: 0x06000F51 RID: 3921 RVA: 0x00127470 File Offset: 0x00125670
	public void init()
	{
		TField.CARET_HEIGHT = GameCanvas.hText + 1;
		this.cmdClear = new iCommand(T.del, 1000);
		bool isPC = GameMidlet.isPC;
		if (isPC)
		{
			TField.typeXpeed = 0;
		}
	}

	// Token: 0x06000F52 RID: 3922 RVA: 0x0000C20B File Offset: 0x0000A40B
	public void setW(int w)
	{
		this.width = w;
	}

	// Token: 0x06000F53 RID: 3923 RVA: 0x001274B0 File Offset: 0x001256B0
	public void clearKeyWhenPutText(int keyCode)
	{
		bool flag = keyCode == -8 && this.timeDelayKyCode <= 0;
		if (flag)
		{
			bool flag2 = this.timeDelayKyCode <= 0;
			if (flag2)
			{
				this.timeDelayKyCode = 1;
			}
			this.clear();
		}
	}

	// Token: 0x06000F54 RID: 3924 RVA: 0x001274F8 File Offset: 0x001256F8
	public void setheightText()
	{
		this.height = 20;
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.height = 28;
		}
	}

	// Token: 0x06000F55 RID: 3925 RVA: 0x00127524 File Offset: 0x00125724
	public void clearAllText()
	{
		this.text = string.Empty;
		bool flag = TField.kb != null;
		if (flag)
		{
			TField.kb.text = string.Empty;
		}
		this.caretPos = 0;
		this.setOffset(0);
		this.setPasswordTest();
	}

	// Token: 0x06000F56 RID: 3926 RVA: 0x00127570 File Offset: 0x00125770
	public void clear()
	{
		bool flag = this.caretPos > 0 && this.text.Length > 0;
		if (flag)
		{
			this.text = this.text.Substring(0, this.caretPos - 1);
			this.caretPos--;
			this.setOffset(0);
			this.setPasswordTest();
			bool flag2 = TField.kb != null;
			if (flag2)
			{
				TField.kb.text = this.text;
			}
		}
	}

	// Token: 0x06000F57 RID: 3927 RVA: 0x001275F4 File Offset: 0x001257F4
	public void clearAll()
	{
		bool flag = this.caretPos > 0 && this.text.Length > 0;
		if (flag)
		{
			this.text = this.text.Substring(0, this.text.Length - 1);
			this.caretPos--;
			this.setOffset();
			this.setPasswordTest();
			this.setFocusWithKb(true);
			bool flag2 = TField.kb != null;
			if (flag2)
			{
				TField.kb.text = string.Empty;
			}
		}
	}

	// Token: 0x06000F58 RID: 3928 RVA: 0x00127684 File Offset: 0x00125884
	public void setOffset()
	{
		bool flag = this.paintedText != null && mFont.tahoma_7b_white != null;
		if (flag)
		{
			bool flag2 = this.inputType == TField.INPUT_TYPE_PASSWORD;
			if (flag2)
			{
				this.paintedText = this.passwordText;
			}
			else
			{
				this.paintedText = this.text;
			}
			bool flag3 = this.offsetX < 0 && mFont.tahoma_7b_white.getWidth(this.paintedText) + this.offsetX < this.width - TField.TEXT_GAP_X - 13 - TField.typingModeAreaWidth;
			if (flag3)
			{
				this.offsetX = this.width - 10 - TField.typingModeAreaWidth - mFont.tahoma_7b_white.getWidth(this.paintedText);
			}
			bool flag4 = this.offsetX + mFont.tahoma_7b_white.getWidth(this.paintedText.Substring(0, this.caretPos)) <= 0;
			if (flag4)
			{
				this.offsetX = -mFont.tahoma_7b_white.getWidth(this.paintedText.Substring(0, this.caretPos));
				this.offsetX += 40;
			}
			else
			{
				bool flag5 = this.offsetX + mFont.tahoma_7b_white.getWidth(this.paintedText.Substring(0, this.caretPos)) >= this.width - 12 - TField.typingModeAreaWidth;
				if (flag5)
				{
					this.offsetX = this.width - 10 - TField.typingModeAreaWidth - mFont.tahoma_7b_white.getWidth(this.paintedText.Substring(0, this.caretPos)) - 2 * TField.TEXT_GAP_X;
				}
			}
			bool flag6 = this.offsetX > 0;
			if (flag6)
			{
				this.offsetX = 0;
			}
		}
	}

	// Token: 0x06000F59 RID: 3929 RVA: 0x00127838 File Offset: 0x00125A38
	public void keyPressedAny(int keyCode)
	{
		mSystem.outz("keyPressedAny " + keyCode.ToString());
		string[] array = (this.inputType != TField.INPUT_TYPE_PASSWORD && this.inputType != TField.INPUT_ALPHA_NUMBER_ONLY) ? TField.print : TField.printA;
		bool flag = keyCode == TField.lastKey;
		if (flag)
		{
			this.indexOfActiveChar = (this.indexOfActiveChar + 1) % array[keyCode - 48].Length;
			char c = array[keyCode - 48][this.indexOfActiveChar];
			object arg = (TField.mode == 0) ? char.ToLower(c) : ((TField.mode == 1) ? char.ToUpper(c) : ((TField.mode != 2) ? array[keyCode - 48][array[keyCode - 48].Length - 1] : char.ToUpper(c)));
			string str = this.text.Substring(0, this.caretPos - 1) + arg;
			bool flag2 = this.caretPos < this.text.Length;
			if (flag2)
			{
				str += this.text.Substring(this.caretPos, this.text.Length);
			}
			this.text = str;
			this.keyInActiveState = TField.MAX_TIME_TO_CONFIRM_KEY[TField.typeXpeed];
			this.setPasswordTest();
		}
		else
		{
			bool flag3 = this.text.Length < this.maxTextLenght;
			if (flag3)
			{
				bool flag4 = TField.mode == 1 && TField.lastKey != -1984;
				if (flag4)
				{
					TField.mode = 0;
				}
				this.indexOfActiveChar = 0;
				char c2 = array[keyCode - 48][this.indexOfActiveChar];
				object arg = (TField.mode == 0) ? char.ToLower(c2) : ((TField.mode == 1) ? char.ToUpper(c2) : ((TField.mode != 2) ? array[keyCode - 48][array[keyCode - 48].Length - 1] : char.ToUpper(c2)));
				string str2 = this.text.Substring(0, this.caretPos) + arg;
				bool flag5 = this.caretPos < this.text.Length;
				if (flag5)
				{
					str2 += this.text.Substring(this.caretPos, this.text.Length);
				}
				this.text = str2;
				this.keyInActiveState = TField.MAX_TIME_TO_CONFIRM_KEY[TField.typeXpeed];
				this.caretPos++;
				this.setPasswordTest();
				this.setOffset();
			}
		}
		TField.lastKey = keyCode;
	}

	// Token: 0x06000F5A RID: 3930 RVA: 0x00127AD4 File Offset: 0x00125CD4
	public void keyPressedAscii(int keyCode)
	{
		mSystem.outz("keyPressedAscii " + keyCode.ToString());
		bool flag = keyCode == 32;
		if (flag)
		{
			this.xSpace += 3;
		}
		else
		{
			this.xSpace = 0;
		}
		bool flag2 = (this.inputType == TField.INPUT_TYPE_PASSWORD || this.inputType == TField.INPUT_ALPHA_NUMBER_ONLY) && (keyCode < 48 || keyCode > 57) && (keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 122);
		if (!flag2)
		{
			bool flag3 = this.text.Length < this.maxTextLenght;
			if (flag3)
			{
				string str = this.text.Substring(0, this.caretPos) + ((char)keyCode).ToString();
				bool flag4 = this.caretPos < this.text.Length;
				if (flag4)
				{
					str += this.text.Substring(this.caretPos, this.text.Length - this.caretPos);
				}
				this.text = str;
				this.caretPos++;
				this.setPasswordTest();
				this.setOffset(0);
			}
			bool flag5 = TField.kb != null;
			if (flag5)
			{
				TField.kb.text = this.text;
			}
		}
	}

	// Token: 0x06000F5B RID: 3931 RVA: 0x00127C30 File Offset: 0x00125E30
	public static void setMode()
	{
		TField.mode++;
		bool flag = TField.mode > 3;
		if (flag)
		{
			TField.mode = 0;
		}
		TField.lastKey = TField.changeModeKey;
		TField.timeChangeMode = (long)(Environment.TickCount / 1000);
	}

	// Token: 0x06000F5C RID: 3932 RVA: 0x00127C7C File Offset: 0x00125E7C
	private void setDau()
	{
		this.timeDau = (long)(Environment.TickCount / 100);
		bool flag = this.indexDau == -1;
		if (flag)
		{
			for (int i = this.caretPos; i > 0; i--)
			{
				char c = this.text[i - 1];
				for (int j = 0; j < TField.printDau.Length; j++)
				{
					char c2 = TField.printDau[j];
					bool flag2 = c == c2;
					if (flag2)
					{
						this.indexTemplate = j;
						this.indexCong = 0;
						this.indexDau = i - 1;
						return;
					}
				}
			}
			this.indexDau = -1;
		}
		else
		{
			this.indexCong++;
			bool flag3 = this.indexCong >= 6;
			if (flag3)
			{
				this.indexCong = 0;
			}
			string str = this.text.Substring(0, this.indexDau);
			string str2 = this.text.Substring(this.indexDau + 1);
			string str3 = TField.printDau.Substring(this.indexTemplate + this.indexCong, 1);
			this.text = str + str3 + str2;
		}
	}

	// Token: 0x06000F5D RID: 3933 RVA: 0x00127DB0 File Offset: 0x00125FB0
	public bool keyPressed(int keyCode)
	{
		mSystem.outz("key " + keyCode.ToString() + " inputType " + this.inputType.ToString());
		bool flag = GameMidlet.isPC && keyCode == -8;
		bool result;
		if (flag)
		{
			this.clearKeyWhenPutText(-8);
			result = true;
		}
		else
		{
			int num = keyCode;
			int num2 = num;
			if (num2 <= -5)
			{
				if (num2 != -8)
				{
					if (num2 != -5)
					{
						goto IL_97;
					}
					bool flag2 = this.closeInput();
					if (flag2)
					{
						return true;
					}
					goto IL_97;
				}
			}
			else if (num2 != 8 && num2 != 204)
			{
				goto IL_97;
			}
			this.clear();
			return true;
			IL_97:
			bool flag3 = TField.isQwerty && keyCode >= 32;
			if (flag3)
			{
				this.keyPressedAscii(keyCode);
				result = false;
			}
			else
			{
				bool flag4 = keyCode == TField.changeDau && this.inputType == TField.INPUT_TYPE_ANY;
				if (flag4)
				{
					this.setDau();
					result = false;
				}
				else
				{
					bool flag5 = keyCode == 42;
					if (flag5)
					{
						keyCode = 58;
					}
					bool flag6 = keyCode == 35;
					if (flag6)
					{
						keyCode = 59;
					}
					bool flag7 = keyCode >= 48 && keyCode <= 59;
					if (flag7)
					{
						bool flag8 = this.inputType == TField.INPUT_TYPE_ANY || this.inputType == TField.INPUT_TYPE_PASSWORD || this.inputType == TField.INPUT_ALPHA_NUMBER_ONLY;
						if (flag8)
						{
							this.keyPressedAny(keyCode);
						}
						else
						{
							bool flag9 = this.inputType == TField.INPUT_TYPE_NUMERIC;
							if (flag9)
							{
								this.keyPressedAscii(keyCode);
								this.keyInActiveState = 1;
							}
						}
					}
					else
					{
						this.indexOfActiveChar = 0;
						TField.lastKey = -1984;
						bool flag10 = keyCode == 14 && !this.lockArrow;
						if (flag10)
						{
							bool flag11 = this.caretPos > 0;
							if (flag11)
							{
								this.caretPos--;
								this.setOffset(0);
								this.showCaretCounter = TField.MAX_SHOW_CARET_COUNER;
								return false;
							}
						}
						else
						{
							bool flag12 = keyCode == 15 && !this.lockArrow;
							if (flag12)
							{
								bool flag13 = this.caretPos < this.text.Length;
								if (flag13)
								{
									this.caretPos++;
									this.setOffset(0);
									this.showCaretCounter = TField.MAX_SHOW_CARET_COUNER;
									return false;
								}
							}
							else
							{
								bool flag14 = keyCode == 19;
								if (flag14)
								{
									this.clear();
									return false;
								}
								TField.lastKey = keyCode;
							}
						}
					}
					result = true;
				}
			}
		}
		return result;
	}

	// Token: 0x06000F5E RID: 3934 RVA: 0x0012802C File Offset: 0x0012622C
	public void setOffset(int index)
	{
		bool flag = this.inputType == TField.INPUT_TYPE_PASSWORD;
		if (flag)
		{
			this.paintedText = this.passwordText;
		}
		else
		{
			this.paintedText = this.text;
		}
		int num = mFont.tahoma_7b_white.getWidth(this.paintedText.Substring(0, this.caretPos));
		if (index != -1)
		{
			if (index != 1)
			{
				this.offsetX = -(num - (this.width - 12));
			}
			else
			{
				bool flag2 = num + this.offsetX > this.width - 25 && this.caretPos < this.paintedText.Length && this.caretPos > 0;
				if (flag2)
				{
					this.offsetX -= mFont.tahoma_7b_white.getWidth(this.paintedText.Substring(this.caretPos - 1, 1));
				}
			}
		}
		else
		{
			bool flag3 = num + this.offsetX < 15 && this.caretPos > 0 && this.caretPos < this.paintedText.Length;
			if (flag3)
			{
				this.offsetX += mFont.tahoma_7b_white.getWidth(this.paintedText.Substring(this.caretPos, 1));
			}
		}
		bool flag4 = this.offsetX > 0;
		if (flag4)
		{
			this.offsetX = 0;
		}
		else
		{
			bool flag5 = this.offsetX < 0;
			if (flag5)
			{
				int num2 = mFont.tahoma_7b_white.getWidth(this.paintedText) - (this.width - 12);
				bool flag6 = this.offsetX < -num2;
				if (flag6)
				{
					this.offsetX = -num2;
				}
			}
		}
	}

	// Token: 0x06000F5F RID: 3935 RVA: 0x000090B5 File Offset: 0x000072B5
	public void paintInputTf(mGraphics g, bool iss, int x, int y, int w, int h, int xText, int yText, string text, string info)
	{
	}

	// Token: 0x06000F60 RID: 3936 RVA: 0x001281D8 File Offset: 0x001263D8
	public void paint(mGraphics g)
	{
		bool flag = this.isFocused();
		mFont mFont = mFont.tahoma_7_black;
		int num = 0;
		bool flag2 = this.inputType == TField.INPUT_TYPE_PASSWORD;
		if (flag2)
		{
			this.paintedText = this.passwordText;
			num = 3;
		}
		else
		{
			this.paintedText = this.text;
		}
		int num2 = 0;
		g.setColor(12621920);
		this.timeFocus++;
		bool flag3 = flag;
		if (flag3)
		{
			int length = this.paintedText.Length;
			bool flag4 = length > 0 && this.caretPos > 0;
			if (flag4)
			{
				num2 = mFont.getWidth(this.paintedText.Substring(0, this.caretPos));
			}
		}
		byte index = 0;
		bool flag5 = !GameCanvas.isTouch && !flag;
		if (flag5)
		{
			index = 1;
		}
		AvMain.paintRect(g, this.x, this.y, this.width, this.height + 1, 0, (int)index);
		g.setClip(this.x + 2, this.y + 2, this.width - 4, this.height - 3);
		int translateX = g.getTranslateX();
		int translateY = g.getTranslateY();
		g.translate(-this.xCamText, 0);
		bool flag6 = this.paintedText.Length == 0;
		if (flag6)
		{
			num = 0;
			this.paintedText = this.strnull;
			mFont = mFont.tahoma_7_white;
		}
		mFont.drawString(g, this.paintedText, this.x + 4, this.y + this.height / 2 - 5 + num, 0);
		bool flag7 = flag && this.timeFocus % 16 > 12;
		if (flag7)
		{
			g.setColor(0);
			g.fillRect(this.x + 3 + num2 + this.xSpace, this.y + this.height / 2 - 7, 1, 14);
		}
		g.setClip(0, 0, MotherCanvas.w, MotherCanvas.h);
		GameCanvas.resetTrans(g);
		g.translate(translateX, translateY);
	}

	// Token: 0x06000F61 RID: 3937 RVA: 0x001283DC File Offset: 0x001265DC
	public void paintNew(mGraphics g)
	{
		bool flag = this.isFocused();
		mFont mFont = mFont.tahoma_7_black;
		int num = 0;
		bool flag2 = this.inputType == TField.INPUT_TYPE_PASSWORD;
		if (flag2)
		{
			this.paintedText = this.passwordText;
			num = 3;
		}
		else
		{
			this.paintedText = this.text;
		}
		int num2 = 0;
		g.setColor(12621920);
		this.timeFocus++;
		bool flag3 = flag;
		if (flag3)
		{
			int length = this.paintedText.Length;
			bool flag4 = length > 0 && this.caretPos > 0;
			if (flag4)
			{
				num2 = mFont.getWidth(this.paintedText.Substring(0, this.caretPos));
			}
		}
		byte index = 0;
		bool flag5 = !GameCanvas.isTouch && !flag;
		if (flag5)
		{
			index = 1;
		}
		AvMain.paintRect(g, this.x, this.y, this.width, this.height + 1, 0, (int)index);
		g.translate(-this.xCamText, 0);
		bool flag6 = this.paintedText.Length == 0;
		if (flag6)
		{
			num = 0;
			this.paintedText = this.strnull;
			mFont = mFont.tahoma_7_white;
		}
		mFont.drawString(g, this.paintedText, this.x + 4, this.y + this.height / 2 - 5 + num, 0);
		bool flag7 = flag && this.timeFocus % 16 > 12;
		if (flag7)
		{
			g.setColor(0);
			g.fillRect(this.x + 3 + num2 + this.xSpace, this.y + this.height / 2 - 7, 1, 14);
		}
	}

	// Token: 0x06000F62 RID: 3938 RVA: 0x00128584 File Offset: 0x00126784
	public void paint(mGraphics g, bool isSetClip)
	{
		bool flag = this.isFocused();
		mFont mFont = mFont.tahoma_7_black;
		int num = 0;
		bool flag2 = this.inputType == TField.INPUT_TYPE_PASSWORD;
		if (flag2)
		{
			this.paintedText = this.passwordText;
			num = 3;
		}
		else
		{
			this.paintedText = this.text;
		}
		int num2 = 0;
		g.setColor(12621920);
		this.timeFocus++;
		bool flag3 = flag;
		if (flag3)
		{
			int length = this.paintedText.Length;
			bool flag4 = length > 0 && this.caretPos > 0;
			if (flag4)
			{
				num2 = mFont.getWidth(this.paintedText.Substring(0, this.caretPos));
			}
		}
		byte index = 0;
		bool flag5 = !GameCanvas.isTouch && !flag;
		if (flag5)
		{
			index = 1;
		}
		AvMain.paintRect(g, this.x, this.y, this.width, this.height + 1, 0, (int)index);
		if (isSetClip)
		{
			g.setClip(this.x + 2, this.y + 2, this.width - 4, this.height - 3);
		}
		int translateX = g.getTranslateX();
		int translateY = g.getTranslateY();
		g.translate(-this.xCamText, 0);
		bool flag6 = this.paintedText.Length == 0;
		if (flag6)
		{
			num = 0;
			this.paintedText = this.strnull;
			mFont = mFont.tahoma_7_white;
		}
		mFont.drawString(g, this.paintedText, this.x + 4, this.y + this.height / 2 - 5 + num, 0);
		bool flag7 = flag && this.timeFocus % 16 > 12;
		if (flag7)
		{
			g.setColor(0);
			g.fillRect(this.x + 3 + num2 + this.xSpace, this.y + this.height / 2 - 7, 1, 14);
		}
		g.setClip(0, 0, MotherCanvas.w, MotherCanvas.h);
		GameCanvas.resetTrans(g);
		g.translate(translateX, translateY);
	}

	// Token: 0x06000F63 RID: 3939 RVA: 0x00128790 File Offset: 0x00126990
	public bool isFocused()
	{
		return this.isFocus;
	}

	// Token: 0x06000F64 RID: 3940 RVA: 0x001287A8 File Offset: 0x001269A8
	public string subString(string str, int index, int indexTo)
	{
		bool flag = index >= 0 && indexTo > str.Length - 1;
		string result;
		if (flag)
		{
			result = str.Substring(index);
		}
		else
		{
			bool flag2 = index < 0 || index > str.Length - 1 || indexTo < 0 || indexTo > str.Length - 1;
			if (flag2)
			{
				result = string.Empty;
			}
			else
			{
				string text = string.Empty;
				for (int i = index; i < indexTo; i++)
				{
					text += str[i].ToString();
				}
				result = text;
			}
		}
		return result;
	}

	// Token: 0x06000F65 RID: 3941 RVA: 0x00128840 File Offset: 0x00126A40
	private void setPasswordTest()
	{
		bool flag = this.inputType == TField.INPUT_TYPE_PASSWORD;
		if (flag)
		{
			this.passwordText = string.Empty;
			for (int i = 0; i < this.text.Length; i++)
			{
				this.passwordText += "*";
			}
			bool flag2 = this.keyInActiveState > 0 && this.caretPos > 0;
			if (flag2)
			{
				this.passwordText = this.passwordText.Substring(0, this.caretPos - 1) + this.text[this.caretPos - 1].ToString() + this.passwordText.Substring(this.caretPos, this.passwordText.Length);
			}
		}
	}

	// Token: 0x06000F66 RID: 3942 RVA: 0x00128914 File Offset: 0x00126B14
	public void update()
	{
		bool flag = this.isFocus;
		if (flag)
		{
			string s = (this.inputType != TField.INPUT_TYPE_PASSWORD) ? this.text : this.passwordText;
			this.xCamText = -this.width / 2 + this.caretPos * 5 + 4;
			int num = mFont.tahoma_7_black.getWidth(s) - this.width + 8;
			bool flag2 = this.xCamText > num;
			if (flag2)
			{
				this.xCamText = num;
			}
			bool flag3 = this.xCamText < 0;
			if (flag3)
			{
				this.xCamText = 0;
			}
		}
		else
		{
			this.xCamText = 0;
		}
		this.isPaintCarret = true;
		bool isPC = GameMidlet.isPC;
		if (isPC)
		{
			bool flag4 = this.timeDelayKyCode > 0;
			if (flag4)
			{
				this.timeDelayKyCode--;
			}
			bool flag5 = this.timeDelayKyCode <= 0;
			if (flag5)
			{
				this.timeDelayKyCode = 0;
			}
		}
		bool flag6 = TField.kb != null && TField.currentTField == this;
		if (flag6)
		{
			bool flag7 = TField.kb.text.Length < 40 && this.isFocus;
			if (flag7)
			{
				this.setText(TField.kb.text);
			}
			bool flag8 = TField.kb.done && this.cmdDoneAction != null;
			if (flag8)
			{
				this.cmdDoneAction.perform();
			}
		}
		this.counter++;
		bool flag9 = this.keyInActiveState > 0;
		if (flag9)
		{
			this.keyInActiveState--;
			bool flag10 = this.keyInActiveState == 0;
			if (flag10)
			{
				this.indexOfActiveChar = 0;
				bool flag11 = TField.mode == 1 && TField.lastKey != TField.changeModeKey && this.isFocus;
				if (flag11)
				{
					TField.mode = 0;
				}
				TField.lastKey = -1984;
				this.setPasswordTest();
			}
		}
		bool flag12 = this.showCaretCounter > 0;
		if (flag12)
		{
			this.showCaretCounter--;
		}
		bool flag13 = this.indexDau != -1 && (long)(Environment.TickCount / 100) - this.timeDau > 5L;
		if (flag13)
		{
			this.indexDau = -1;
		}
		bool flag14 = this.isOpenKey;
		if (flag14)
		{
			this.setFocusWithKb(true);
		}
	}

	// Token: 0x06000F67 RID: 3943 RVA: 0x00128B60 File Offset: 0x00126D60
	public bool closeInput()
	{
		bool isShow = ChatTextField.isShow;
		bool result;
		if (isShow)
		{
			bool flag = ChatTextField.gI().tfChat.getText().Length > 0;
			if (flag)
			{
				ChatTextField.gI().sendChat();
			}
			ChatTextField.gI().tfChat.setFocus(false);
			ChatTextField.isShow = false;
			GameCanvas.isSendChatpopup = true;
			result = true;
		}
		else
		{
			bool flag2 = GameCanvas.currentScreen == GameCanvas.chatTabScr;
			if (flag2)
			{
				bool flag3 = GameCanvas.chatTabScr.tabCur.tfchat != null;
				if (flag3)
				{
					GameCanvas.chatTabScr.tabCur.addStartChat(GameScreen.player.name);
				}
				result = true;
			}
			else
			{
				bool flag4 = GameCanvas.ClanScr != null && GameCanvas.currentScreen == GameCanvas.ClanScr && GameCanvas.ClanScr.tabCur.tfchat != null;
				if (flag4)
				{
					GameCanvas.ClanScr.tabCur.sendChat();
				}
				result = false;
			}
		}
		return result;
	}

	// Token: 0x06000F68 RID: 3944 RVA: 0x00128C54 File Offset: 0x00126E54
	public void setTextBox(int camY)
	{
		bool flag = GameCanvas.isPointerSelect && GameCanvas.isPoint(0, 0, MotherCanvas.w, MotherCanvas.h - GameCanvas.hCommand / 2);
		if (flag)
		{
			bool flag2 = GameCanvas.isPoint(this.x, this.y - 6 - camY, this.width, this.height + 12);
			if (flag2)
			{
				this.doChangeToTextBox();
			}
			else
			{
				this.setFocus(false);
			}
		}
	}

	// Token: 0x06000F69 RID: 3945 RVA: 0x00128CC8 File Offset: 0x00126EC8
	public void setFocus(bool isFocus)
	{
		bool flag = this.isFocus != isFocus;
		if (flag)
		{
			TField.mode = 0;
		}
		TField.lastKey = -1984;
		TField.timeChangeMode = (long)((int)(DateTime.Now.Ticks / 1000L));
		this.isFocus = isFocus;
		if (isFocus)
		{
			TField.currentTField = this;
			bool flag2 = TField.kb != null;
			if (flag2)
			{
				TField.kb.text = TField.currentTField.text;
			}
		}
	}

	// Token: 0x06000F6A RID: 3946 RVA: 0x00128D4C File Offset: 0x00126F4C
	public void setFocusWithKb(bool isFocus)
	{
		this.isOpenKey = false;
		bool flag = this.isFocus != isFocus;
		if (flag)
		{
			TField.mode = 0;
		}
		TField.lastKey = -1984;
		TField.timeChangeMode = (long)((int)(DateTime.Now.Ticks / 1000L));
		this.isFocus = isFocus;
		bool flag2 = isFocus;
		if (flag2)
		{
			TField.currentTField = this;
		}
		else
		{
			bool flag3 = TField.currentTField == this;
			if (flag3)
			{
				TField.currentTField = null;
			}
		}
		bool flag4 = Thread.CurrentThread.Name == Main.mainThreadName && TField.currentTField != null;
		if (flag4)
		{
			isFocus = true;
			TouchScreenKeyboard.hideInput = !TField.currentTField.showSubTextField;
			TouchScreenKeyboardType t = TouchScreenKeyboardType.ASCIICapable;
			bool flag5 = this.inputType == TField.INPUT_TYPE_NUMERIC;
			if (flag5)
			{
				t = TouchScreenKeyboardType.NumberPad;
			}
			bool type = false;
			bool flag6 = this.inputType == TField.INPUT_TYPE_PASSWORD;
			if (flag6)
			{
				type = true;
			}
			TField.kb = TouchScreenKeyboard.Open(TField.currentTField.text, t, false, false, type, false, TField.currentTField.name);
			bool flag7 = TField.kb != null;
			if (flag7)
			{
				TField.kb.text = TField.currentTField.text;
			}
			Cout.LogWarning("SHOW KEYBOARD FOR " + TField.currentTField.text);
		}
	}

	// Token: 0x06000F6B RID: 3947 RVA: 0x00128EA4 File Offset: 0x001270A4
	public string getText()
	{
		return this.text;
	}

	// Token: 0x06000F6C RID: 3948 RVA: 0x00128EBC File Offset: 0x001270BC
	public void clearKb()
	{
		bool flag = TField.kb != null;
		if (flag)
		{
			TField.kb.text = string.Empty;
		}
	}

	// Token: 0x06000F6D RID: 3949 RVA: 0x00128EE8 File Offset: 0x001270E8
	public void setText(string text)
	{
		bool flag = text != null;
		if (flag)
		{
			TField.lastKey = -1984;
			this.keyInActiveState = 0;
			this.indexOfActiveChar = 0;
			this.text = text;
			this.paintedText = text;
			bool flag2 = text == string.Empty;
			if (flag2)
			{
				TouchScreenKeyboard.Clear();
			}
			this.setPasswordTest();
			this.caretPos = text.Length;
			this.setOffset();
		}
	}

	// Token: 0x06000F6E RID: 3950 RVA: 0x00128F58 File Offset: 0x00127158
	public void insertText(string text)
	{
		this.text = this.text.Substring(0, this.caretPos) + text + this.text.Substring(this.caretPos);
		this.setPasswordTest();
		this.caretPos += text.Length;
		this.setOffset();
	}

	// Token: 0x06000F6F RID: 3951 RVA: 0x00128FB8 File Offset: 0x001271B8
	public int getMaxTextLenght()
	{
		return this.maxTextLenght;
	}

	// Token: 0x06000F70 RID: 3952 RVA: 0x0000C215 File Offset: 0x0000A415
	public void setMaxTextLenght(int maxTextLenght)
	{
		this.maxTextLenght = maxTextLenght;
	}

	// Token: 0x06000F71 RID: 3953 RVA: 0x00128FD0 File Offset: 0x001271D0
	public int getIputType()
	{
		return this.inputType;
	}

	// Token: 0x06000F72 RID: 3954 RVA: 0x0000C21F File Offset: 0x0000A41F
	public void setIputType(int iputType)
	{
		this.inputType = iputType;
	}

	// Token: 0x06000F73 RID: 3955 RVA: 0x00128FE8 File Offset: 0x001271E8
	public void perform(int idAction)
	{
		bool flag = idAction == 1000;
		if (flag)
		{
			this.clear();
		}
	}

	// Token: 0x06000F74 RID: 3956 RVA: 0x0012900C File Offset: 0x0012720C
	public void setPoiter()
	{
		this.isFocus = true;
		this.isOpenTextBox = true;
		GameCanvas.isPointerSelect = false;
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.doChangeToTextBox();
		}
	}

	// Token: 0x06000F75 RID: 3957 RVA: 0x00129040 File Offset: 0x00127240
	public iCommand setCmdClear()
	{
		return this.cmdClear;
	}

	// Token: 0x06000F76 RID: 3958 RVA: 0x0000C229 File Offset: 0x0000A429
	public void updatePointer()
	{
		this.setTextBox(0);
	}

	// Token: 0x06000F77 RID: 3959 RVA: 0x0000C234 File Offset: 0x0000A434
	public void updatePointer(int camY)
	{
		this.setTextBox(camY);
	}

	// Token: 0x040019AD RID: 6573
	public const sbyte KEY_LEFT = 14;

	// Token: 0x040019AE RID: 6574
	public const sbyte KEY_RIGHT = 15;

	// Token: 0x040019AF RID: 6575
	public const sbyte KEY_CLEAR = 19;

	// Token: 0x040019B0 RID: 6576
	public bool isFocus;

	// Token: 0x040019B1 RID: 6577
	public int x;

	// Token: 0x040019B2 RID: 6578
	public int y;

	// Token: 0x040019B3 RID: 6579
	public int width;

	// Token: 0x040019B4 RID: 6580
	public int height;

	// Token: 0x040019B5 RID: 6581
	public bool lockArrow;

	// Token: 0x040019B6 RID: 6582
	public bool justReturnFromTextBox;

	// Token: 0x040019B7 RID: 6583
	public bool paintFocus = true;

	// Token: 0x040019B8 RID: 6584
	public static int typeXpeed = 2;

	// Token: 0x040019B9 RID: 6585
	private static readonly int[] MAX_TIME_TO_CONFIRM_KEY = new int[]
	{
		30,
		14,
		11,
		9,
		6,
		4,
		2
	};

	// Token: 0x040019BA RID: 6586
	private static int CARET_HEIGHT = 0;

	// Token: 0x040019BB RID: 6587
	private static readonly int CARET_WIDTH = 1;

	// Token: 0x040019BC RID: 6588
	private static readonly int CARET_SHOWING_TIME = 5;

	// Token: 0x040019BD RID: 6589
	private static readonly int TEXT_GAP_X = 4;

	// Token: 0x040019BE RID: 6590
	private static readonly int MAX_SHOW_CARET_COUNER = 10;

	// Token: 0x040019BF RID: 6591
	public static readonly int INPUT_TYPE_ANY = 0;

	// Token: 0x040019C0 RID: 6592
	public static readonly int INPUT_TYPE_NUMERIC = 1;

	// Token: 0x040019C1 RID: 6593
	public static readonly int INPUT_TYPE_PASSWORD = 2;

	// Token: 0x040019C2 RID: 6594
	public static readonly int INPUT_ALPHA_NUMBER_ONLY = 3;

	// Token: 0x040019C3 RID: 6595
	private static string[] print = new string[]
	{
		" 0",
		".,@?!_1\"/$-():*+<=>;%&~#%^&*{}[];'/1",
		"abc2áàảãạâấầẩẫậăắằẳẵặ2",
		"def3đéèẻẽẹêếềểễệ3",
		"ghi4íìỉĩị4",
		"jkl5",
		"mno6óòỏõọôốồổỗộơớờởỡợ6",
		"pqrs7",
		"tuv8úùủũụưứừửữự8",
		"wxyz9ýỳỷỹỵ9",
		"*",
		"#"
	};

	// Token: 0x040019C4 RID: 6596
	private static string[] printA = new string[]
	{
		"0",
		"1",
		"abc2",
		"def3",
		"ghi4",
		"jkl5",
		"mno6",
		"pqrs7",
		"tuv8",
		"wxyz9",
		"0",
		"0"
	};

	// Token: 0x040019C5 RID: 6597
	private static string[] printBB = new string[]
	{
		" 0",
		"er1",
		"ty2",
		"ui3",
		"df4",
		"gh5",
		"jk6",
		"cv7",
		"bn8",
		"m9",
		"0",
		"0",
		"qw!",
		"as?",
		"zx",
		"op.",
		"l,"
	};

	// Token: 0x040019C6 RID: 6598
	private string text = string.Empty;

	// Token: 0x040019C7 RID: 6599
	private string passwordText = string.Empty;

	// Token: 0x040019C8 RID: 6600
	private string paintedText = string.Empty;

	// Token: 0x040019C9 RID: 6601
	private int caretPos;

	// Token: 0x040019CA RID: 6602
	private int counter;

	// Token: 0x040019CB RID: 6603
	private int maxTextLenght = 500;

	// Token: 0x040019CC RID: 6604
	private int offsetX;

	// Token: 0x040019CD RID: 6605
	private static int lastKey = -1984;

	// Token: 0x040019CE RID: 6606
	private int keyInActiveState;

	// Token: 0x040019CF RID: 6607
	private int indexOfActiveChar;

	// Token: 0x040019D0 RID: 6608
	private int showCaretCounter = TField.MAX_SHOW_CARET_COUNER;

	// Token: 0x040019D1 RID: 6609
	private int inputType = TField.INPUT_TYPE_ANY;

	// Token: 0x040019D2 RID: 6610
	public static bool isQwerty = true;

	// Token: 0x040019D3 RID: 6611
	public bool isCloseKey;

	// Token: 0x040019D4 RID: 6612
	public bool isOpenTextBox;

	// Token: 0x040019D5 RID: 6613
	public static int typingModeAreaWidth;

	// Token: 0x040019D6 RID: 6614
	public static int mode = 0;

	// Token: 0x040019D7 RID: 6615
	public static long timeChangeMode;

	// Token: 0x040019D8 RID: 6616
	public static readonly string[] modeNotify = new string[]
	{
		"abc",
		"Abc",
		"ABC",
		"123"
	};

	// Token: 0x040019D9 RID: 6617
	public static readonly int NOKIA = 0;

	// Token: 0x040019DA RID: 6618
	public static readonly int MOTO = 1;

	// Token: 0x040019DB RID: 6619
	public static readonly int ORTHER = 2;

	// Token: 0x040019DC RID: 6620
	public static readonly int BB = 3;

	// Token: 0x040019DD RID: 6621
	public static int changeModeKey = 11;

	// Token: 0x040019DE RID: 6622
	public static readonly sbyte abc = 0;

	// Token: 0x040019DF RID: 6623
	public static readonly sbyte Abc = 1;

	// Token: 0x040019E0 RID: 6624
	public static readonly sbyte ABC = 2;

	// Token: 0x040019E1 RID: 6625
	public static readonly sbyte number123 = 3;

	// Token: 0x040019E2 RID: 6626
	public static TField currentTField;

	// Token: 0x040019E3 RID: 6627
	public bool isTfield;

	// Token: 0x040019E4 RID: 6628
	public bool isPaintMouse = true;

	// Token: 0x040019E5 RID: 6629
	public string name = string.Empty;

	// Token: 0x040019E6 RID: 6630
	public string title = string.Empty;

	// Token: 0x040019E7 RID: 6631
	public string strnull = string.Empty;

	// Token: 0x040019E8 RID: 6632
	public string strInfo;

	// Token: 0x040019E9 RID: 6633
	public bool isOpenKey;

	// Token: 0x040019EA RID: 6634
	public iCommand cmdClear;

	// Token: 0x040019EB RID: 6635
	public iCommand cmdDoneAction;

	// Token: 0x040019EC RID: 6636
	private MainScreen parentScr;

	// Token: 0x040019ED RID: 6637
	private int timeDelayKyCode;

	// Token: 0x040019EE RID: 6638
	private int xSpace;

	// Token: 0x040019EF RID: 6639
	private int holdCount;

	// Token: 0x040019F0 RID: 6640
	public static int changeDau;

	// Token: 0x040019F1 RID: 6641
	private int indexDau = -1;

	// Token: 0x040019F2 RID: 6642
	private int indexTemplate;

	// Token: 0x040019F3 RID: 6643
	private int indexCong;

	// Token: 0x040019F4 RID: 6644
	private long timeDau;

	// Token: 0x040019F5 RID: 6645
	private static string printDau = "aáàảãạâấầẩẫậăắằẳẵặeéèẻẽẹêếềểễệiíìỉĩịoóòỏõọôốồổỗộơớờởỡợuúùủũụưứừửữựyýỳỷỹỵ";

	// Token: 0x040019F6 RID: 6646
	public static Image imgTf;

	// Token: 0x040019F7 RID: 6647
	public int timeFocus;

	// Token: 0x040019F8 RID: 6648
	public int xCamText;

	// Token: 0x040019F9 RID: 6649
	public int timePutKeyClearAll;

	// Token: 0x040019FA RID: 6650
	public int timeClearFirt;

	// Token: 0x040019FB RID: 6651
	public bool isPaintCarret;

	// Token: 0x040019FC RID: 6652
	public bool showSubTextField = true;

	// Token: 0x040019FD RID: 6653
	public static TouchScreenKeyboard kb;

	// Token: 0x040019FE RID: 6654
	public static int[][] BBKEY = new int[][]
	{
		new int[]
		{
			32,
			48
		},
		new int[]
		{
			49,
			69
		},
		new int[]
		{
			50,
			84
		},
		new int[]
		{
			51,
			85
		},
		new int[]
		{
			52,
			68
		},
		new int[]
		{
			53,
			71
		},
		new int[]
		{
			54,
			74
		},
		new int[]
		{
			55,
			67
		},
		new int[]
		{
			56,
			66
		},
		new int[]
		{
			57,
			77
		},
		new int[]
		{
			42,
			128
		},
		new int[]
		{
			35,
			137
		},
		new int[]
		{
			33,
			113
		},
		new int[]
		{
			63,
			97
		},
		new int[]
		{
			64,
			121,
			122
		},
		new int[]
		{
			46,
			111
		},
		new int[]
		{
			44,
			108
		}
	};

	// Token: 0x040019FF RID: 6655
	public static int xDu = 0;

	// Token: 0x04001A00 RID: 6656
	public bool isChangeFocus;
}
