using System;

// Token: 0x0200001E RID: 30
public class CreateChar_Screen : MainScreen
{
	// Token: 0x0600011C RID: 284 RVA: 0x0001AC74 File Offset: 0x00018E74
	public CreateChar_Screen()
	{
		this.yBegin = MotherCanvas.h - 55;
		this.xBegin = MotherCanvas.hw - 40;
		this.tfNameChar = new TField(MotherCanvas.hw - 40, this.yBegin, 80);
		this.tfNameChar.setStringNull(T.tfNameCharNull);
		this.cmdCreate = new iCommand(T.create, 0, this);
		this.cmdexit = new iCommand(T.back, 1, this);
		bool flag = !GameCanvas.isTouch;
		if (flag)
		{
			this.cmdexit = AvMain.setPosCMD(this.cmdexit, 1);
			this.cmdCreate = AvMain.setPosCMD(this.cmdCreate, 2);
			this.center = this.cmdCreate;
			this.cmdCreate = AvMain.setPosCMD(this.cmdCreate, 0);
			this.right = this.tfNameChar.cmdClear;
			this.left = this.cmdexit;
		}
		else
		{
			this.cmdexit = AvMain.setPosCMD(this.cmdexit, 2);
			this.cmdCreate = AvMain.setPosCMD(this.cmdCreate, 1);
			this.left = this.cmdCreate;
			this.right = this.cmdexit;
			this.backCMD = this.cmdexit;
			this.okCMD = this.cmdCreate;
		}
		bool flag2 = GameCanvas.isTouchNoOrPC();
		if (flag2)
		{
			this.tfNameChar.setFocus(true);
		}
		bool flag3 = this.vecHeadShow.size() == 0;
		if (flag3)
		{
			for (int i = 1; i < 6; i++)
			{
				this.otherPl = new Other_Player(0, 0, string.Empty, 0, 0);
				this.otherPl.clazz = (sbyte)i;
				this.otherPl = CreateChar_Screen.setCharClass(this.otherPl, false);
				this.vecHeadShow.addElement(this.otherPl);
			}
		}
	}

	// Token: 0x0600011D RID: 285 RVA: 0x0001AE58 File Offset: 0x00019058
	public static CreateChar_Screen gI()
	{
		return (CreateChar_Screen.instance != null) ? CreateChar_Screen.instance : (CreateChar_Screen.instance = new CreateChar_Screen());
	}

	// Token: 0x0600011E RID: 286 RVA: 0x0001AE84 File Offset: 0x00019084
	public override void Show(MainScreen screen)
	{
		base.Show(screen);
		this.otherPl = new Other_Player(0, 0, string.Empty, MotherCanvas.hw, this.yBegin - 10);
		this.otherPl.clazz = (sbyte)CRes.random(1, 6);
		this.otherPl = CreateChar_Screen.setCharClass(this.otherPl, false);
		this.tfNameChar.setText(string.Empty);
	}

	// Token: 0x0600011F RID: 287 RVA: 0x000092E5 File Offset: 0x000074E5
	public override void setxyPlus12()
	{
		GameCanvas.xPlus12 = 2;
		GameCanvas.yPlus12 = 2;
	}

	// Token: 0x06000120 RID: 288 RVA: 0x0001AEF0 File Offset: 0x000190F0
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
		{
			bool flag = this.tfNameChar.getText().Length > 0;
			if (flag)
			{
				GlobalService.gI().Create_Char(this.tfNameChar.getText(), this.otherPl.clazz, this.otherPl.head, this.otherPl.hair);
			}
			else
			{
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.checkCreate);
			}
			break;
		}
		case 1:
		{
			bool flag2 = this.lastScreen != null;
			if (flag2)
			{
				this.lastScreen.Show(this.lastScreen.lastScreen);
			}
			else
			{
				GameCanvas.loginScr.Show();
			}
			break;
		}
		case 2:
		{
			Other_Player other_Player = this.otherPl;
			other_Player.clazz += 1;
			bool flag3 = this.otherPl.clazz > 5;
			if (flag3)
			{
				this.otherPl.clazz = 1;
			}
			this.otherPl = CreateChar_Screen.setCharClass(this.otherPl, false);
			break;
		}
		}
		base.commandPointer(index, subIndex);
	}

	// Token: 0x06000121 RID: 289 RVA: 0x0001B008 File Offset: 0x00019208
	public override void paint(mGraphics g)
	{
		bool flag = GameCanvas.mapBack != null;
		if (flag)
		{
			GameCanvas.mapBack.paintBgLogin(g);
			GameCanvas.mapBack.paintObjFristLogin(g);
			GameCanvas.mapBack.paintObjLastLogin(g);
		}
		for (int i = 0; i < this.vecHeadShow.size(); i++)
		{
			Other_Player other_Player = (Other_Player)this.vecHeadShow.elementAt(i);
			int idx = 0;
			bool flag2 = other_Player.clazz == this.otherPl.clazz;
			if (flag2)
			{
				idx = 1;
			}
			bool flag3 = AvMain.fraBorder == null;
			if (flag3)
			{
				AvMain.fraBorder = new FrameImage(mImage.createImage("/interface/border.png"), 26, 26);
			}
			else
			{
				AvMain.fraBorder.drawFrame(idx, this.wItem / 2, this.wItem / 2 + i * this.wItem + GameScreen.h12plus, 0, 3, g);
			}
			MainObject.paintHeadEveryWhere(g, other_Player.head, other_Player.hair, other_Player.hat, this.wItem / 2 + 2, this.wItem / 2 + i * this.wItem + 37 + GameScreen.h12plus, 2);
		}
		GameCanvas.resetTrans(g);
		this.tfNameChar.paint(g);
		this.otherPl.paintShadow(g, this.otherPl.x);
		this.otherPl.paintCharShow(g, this.otherPl.x, this.otherPl.y, 0, true);
		bool flag4 = this.otherPl.chat != null;
		if (flag4)
		{
			this.otherPl.chat.paint(g);
		}
		base.paint(g);
	}

	// Token: 0x06000122 RID: 290 RVA: 0x0001B1B8 File Offset: 0x000193B8
	public override void update()
	{
		this.tfNameChar.update();
		this.otherPl.updateChatPopup(10);
		bool flag = GameCanvas.mapBack != null;
		if (flag)
		{
			GameCanvas.mapBack.updateCloudLogin();
		}
	}

	// Token: 0x06000123 RID: 291 RVA: 0x0001B1FC File Offset: 0x000193FC
	public override void updatekey()
	{
		int num = (int)this.otherPl.clazz;
		base.updatekey();
		bool flag = GameCanvas.keyMyHold[8];
		if (flag)
		{
			GameCanvas.clearKeyHold(8);
			num++;
		}
		else
		{
			bool flag2 = GameCanvas.keyMyHold[2];
			if (flag2)
			{
				GameCanvas.clearKeyHold(2);
				num--;
			}
		}
		bool flag3 = num != (int)this.otherPl.clazz;
		if (flag3)
		{
			bool flag4 = num > 5;
			if (flag4)
			{
				this.otherPl.clazz = 1;
			}
			else
			{
				bool flag5 = num < 1;
				if (flag5)
				{
					this.otherPl.clazz = 5;
				}
				else
				{
					this.otherPl.clazz = (sbyte)num;
				}
			}
			this.otherPl = CreateChar_Screen.setCharClass(this.otherPl, false);
		}
	}

	// Token: 0x06000124 RID: 292 RVA: 0x0001B2BC File Offset: 0x000194BC
	public override void updatePointer()
	{
		this.tfNameChar.updatePointer();
		bool flag = GameCanvas.isPointSelect(0, GameScreen.h12plus, this.wItem, this.wItem * 5);
		if (flag)
		{
			int num = (GameCanvas.py - GameScreen.h12plus) / this.wItem;
			bool flag2 = num > 4;
			if (flag2)
			{
				num = 4;
			}
			this.otherPl.clazz = (sbyte)(num + 1);
			this.otherPl = CreateChar_Screen.setCharClass(this.otherPl, false);
			GameCanvas.isPointerSelect = false;
		}
		base.updatePointer();
	}

	// Token: 0x06000125 RID: 293 RVA: 0x000094DC File Offset: 0x000076DC
	public override void keyPress(int keyCode)
	{
		this.tfNameChar.keyPressed(keyCode);
	}

	// Token: 0x06000126 RID: 294 RVA: 0x0001B344 File Offset: 0x00019544
	public static Other_Player setCharClass(Other_Player other, bool isRan)
	{
		switch (other.clazz)
		{
		case 1:
			other.head = 0;
			if (isRan)
			{
				other.hair = CreateChar_Screen.RanPart(0, 0);
			}
			else
			{
				other.hair = 1;
			}
			if (isRan)
			{
				other.hat = CreateChar_Screen.RanPart(0, 1);
			}
			else
			{
				other.hat = -1;
			}
			if (isRan)
			{
				other.body = CreateChar_Screen.RanPart(0, 2);
			}
			else
			{
				other.body = 3;
			}
			if (isRan)
			{
				other.leg = CreateChar_Screen.RanPart(0, 3);
			}
			else
			{
				other.leg = 4;
			}
			other.weapon = -1;
			other.IdEffShow = 33;
			break;
		case 2:
			other.head = 0;
			if (isRan)
			{
				other.hair = CreateChar_Screen.RanPart(1, 0);
			}
			else
			{
				other.hair = 24;
			}
			if (isRan)
			{
				other.hat = CreateChar_Screen.RanPart(1, 1);
			}
			else
			{
				other.hat = -1;
			}
			if (isRan)
			{
				other.body = CreateChar_Screen.RanPart(1, 2);
			}
			else
			{
				other.body = 26;
			}
			if (isRan)
			{
				other.leg = CreateChar_Screen.RanPart(1, 3);
			}
			else
			{
				other.leg = 27;
			}
			other.weapon = 5;
			other.IdEffShow = 15;
			break;
		case 3:
			other.head = 0;
			if (isRan)
			{
				other.hair = CreateChar_Screen.RanPart(2, 0);
			}
			else
			{
				other.hair = 28;
			}
			if (isRan)
			{
				other.hat = CreateChar_Screen.RanPart(2, 1);
			}
			else
			{
				other.hat = -1;
			}
			if (isRan)
			{
				other.body = CreateChar_Screen.RanPart(2, 2);
			}
			else
			{
				other.body = 30;
			}
			if (isRan)
			{
				other.leg = CreateChar_Screen.RanPart(2, 3);
			}
			else
			{
				other.leg = 31;
			}
			other.weapon = 180;
			other.IdEffShow = 44;
			break;
		case 4:
			other.head = 0;
			if (isRan)
			{
				other.hair = CreateChar_Screen.RanPart(3, 0);
			}
			else
			{
				other.hair = 32;
			}
			if (isRan)
			{
				other.hat = CreateChar_Screen.RanPart(3, 1);
			}
			else
			{
				other.hat = -1;
			}
			if (isRan)
			{
				other.body = CreateChar_Screen.RanPart(3, 2);
			}
			else
			{
				other.body = 34;
			}
			if (isRan)
			{
				other.leg = CreateChar_Screen.RanPart(3, 3);
			}
			else
			{
				other.leg = 35;
			}
			other.weapon = 6;
			other.IdEffShow = 51;
			break;
		case 5:
			other.head = 0;
			other.hair = 36;
			other.hat = -1;
			other.body = 38;
			other.leg = 39;
			other.weapon = 7;
			other.IdEffShow = 7;
			break;
		case 6:
			other.head = 8;
			other.hair = -1;
			other.hat = 11;
			other.body = 9;
			other.leg = 10;
			other.weapon = -1;
			other.IdEffShow = 7;
			break;
		}
		bool flag = (int)other.clazz < T.mTalkChar.Length;
		if (flag)
		{
			other.strChatPopup = T.mTalkChar[(int)other.clazz];
		}
		return other;
	}

	// Token: 0x06000127 RID: 295 RVA: 0x0001B6A0 File Offset: 0x000198A0
	public static short RanPart(int clazz, int index)
	{
		return CreateChar_Screen.hardcodePart[clazz * 4 + index][CRes.random(CreateChar_Screen.hardcodePart[clazz * 4].Length)];
	}

	// Token: 0x06000128 RID: 296 RVA: 0x0001B6D0 File Offset: 0x000198D0
	public override bool keyBack()
	{
		bool flag = !base.keyBack() && this.cmdexit != null;
		if (flag)
		{
			this.cmdexit.perform();
		}
		return false;
	}

	// Token: 0x04000259 RID: 601
	public const int TOC = 0;

	// Token: 0x0400025A RID: 602
	public const int NON = 1;

	// Token: 0x0400025B RID: 603
	public const int AO = 2;

	// Token: 0x0400025C RID: 604
	public const int QUAN = 3;

	// Token: 0x0400025D RID: 605
	public static CreateChar_Screen instance;

	// Token: 0x0400025E RID: 606
	private TField tfNameChar;

	// Token: 0x0400025F RID: 607
	private iCommand cmdCreate;

	// Token: 0x04000260 RID: 608
	private iCommand cmdexit;

	// Token: 0x04000261 RID: 609
	private int xBegin;

	// Token: 0x04000262 RID: 610
	private int yBegin;

	// Token: 0x04000263 RID: 611
	private int h;

	// Token: 0x04000264 RID: 612
	private Other_Player otherPl;

	// Token: 0x04000265 RID: 613
	private mVector vecHeadShow = new mVector("CreateChar_Screen.vecHeadShow");

	// Token: 0x04000266 RID: 614
	private int wItem = 30;

	// Token: 0x04000267 RID: 615
	public static short[][] hardcodePart = new short[][]
	{
		new short[]
		{
			1,
			41
		},
		new short[]
		{
			-1,
			2,
			42
		},
		new short[]
		{
			3,
			43
		},
		new short[]
		{
			44,
			4
		},
		new short[]
		{
			45,
			24
		},
		new short[]
		{
			-1,
			46,
			25
		},
		new short[]
		{
			47,
			26
		},
		new short[]
		{
			48,
			27
		},
		new short[]
		{
			49,
			28
		},
		new short[]
		{
			-1,
			29,
			50
		},
		new short[]
		{
			30,
			51
		},
		new short[]
		{
			31,
			52
		},
		new short[]
		{
			32,
			53
		},
		new short[]
		{
			-1,
			33,
			58
		},
		new short[]
		{
			34,
			55
		},
		new short[]
		{
			35,
			56
		},
		new short[]
		{
			36,
			57
		},
		new short[]
		{
			-1,
			37
		},
		new short[]
		{
			38,
			59
		},
		new short[]
		{
			39,
			60
		}
	};
}
