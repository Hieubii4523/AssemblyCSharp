using System;

// Token: 0x02000012 RID: 18
public class ChatDetail : AvMain
{
	// Token: 0x06000090 RID: 144 RVA: 0x000146E4 File Offset: 0x000128E4
	public ChatDetail(string name, sbyte type)
	{
		this.name = name;
		this.typeChat = type;
		this.shortName = name;
		bool flag = name.Length >= 5;
		if (flag)
		{
			this.shortName = name.Substring(0, 5);
		}
		this.shortNameFocus = name;
		bool flag2 = name.Length >= 10;
		if (flag2)
		{
			this.shortNameFocus = name.Substring(0, 9) + "...";
		}
		bool flag3 = this.typeChat == 0;
		if (flag3)
		{
			this.tfchat = new TField(GameCanvas.chatTabScr.xBe, GameCanvas.chatTabScr.yBe + GameCanvas.chatTabScr.hCon - TField.getHeight() - GameCanvas.chatTabScr.miniItem / 2, GameCanvas.chatTabScr.wCon);
			this.tfchat.isCloseKey = false;
		}
		else
		{
			bool flag4 = this.typeChat == 2;
			if (flag4)
			{
				this.friend = name;
				this.name = T.addFriend;
			}
		}
		bool flag5 = name.CompareTo(T.tabBangHoi) == 0 || name.CompareTo(T.tabServer) == 0 || name.CompareTo(T.tabBangChu) == 0;
		if (flag5)
		{
			this.typeColorChat = 1;
		}
		else
		{
			this.typeColorChat = 0;
		}
		this.scrChat.setInfo(GameCanvas.chatTabScr.xBe + GameCanvas.chatTabScr.wCon + GameCanvas.chatTabScr.miniItem * 2, GameCanvas.chatTabScr.yBe, GameCanvas.chatTabScr.hCon, 8809550);
	}

	// Token: 0x06000091 RID: 145 RVA: 0x0001489C File Offset: 0x00012A9C
	public void addString(string str, string nametext, int color)
	{
		bool flag = str.Length <= 0;
		if (!flag)
		{
			string[] array = mFont.tahoma_7_white.splitFontArray(str, GameCanvas.chatTabScr.wCon);
			sbyte color2 = (color < 0) ? this.setColorText(nametext) : ((sbyte)color);
			MainTextChat[] array2 = this.addChatNew(array, color2);
			bool flag2 = array2 != null;
			if (flag2)
			{
				for (int i = 0; i < array2.Length; i++)
				{
					this.vecDetail.addElement(array2[i]);
				}
			}
			this.setLim();
			bool flag3 = this.limY > 0 && GameCanvas.currentScreen == GameCanvas.chatTabScr && GameCanvas.chatTabScr.tabCur != null && GameCanvas.chatTabScr.tabCur == this;
			if (flag3)
			{
				GameCanvas.chatTabScr.updateCameraNew(array.Length, 1);
			}
			bool flag4 = ((GameCanvas.chatTabScr.tabCur != null && GameCanvas.chatTabScr.tabCur != this) || GameCanvas.currentScreen != GameCanvas.chatTabScr) && this.name.CompareTo(T.tabServer) != 0;
			if (flag4)
			{
				this.isNew = true;
				this.timeNew = (sbyte)CRes.random(1, 11);
			}
		}
	}

	// Token: 0x06000092 RID: 146 RVA: 0x000149D0 File Offset: 0x00012BD0
	public void addStartChat(string nametext)
	{
		string text = string.Empty;
		bool flag = this.tfchat != null;
		if (flag)
		{
			text = this.tfchat.getText();
		}
		bool flag2 = text.Length > 0;
		if (flag2)
		{
			string[] array = mFont.tahoma_7_white.splitFontArray(GameScreen.player.name + ": " + text, GameCanvas.chatTabScr.wCon);
			MainTextChat[] array2 = this.addChatNew(array, this.setColorText(nametext));
			bool flag3 = array2 != null;
			if (flag3)
			{
				for (int i = 0; i < array2.Length; i++)
				{
					this.vecDetail.addElement(array2[i]);
				}
			}
			this.setLim();
			bool flag4 = GameCanvas.currentScreen == GameCanvas.chatTabScr && GameCanvas.chatTabScr.tabCur != null && GameCanvas.chatTabScr.tabCur == this;
			if (flag4)
			{
				GameCanvas.chatTabScr.updateCameraNew(array.Length, 1);
			}
			GlobalService.gI().chatTab(this.name, text);
		}
		bool flag5 = this.tfchat != null;
		if (flag5)
		{
			this.tfchat.setText(string.Empty);
		}
	}

	// Token: 0x06000093 RID: 147 RVA: 0x00014B00 File Offset: 0x00012D00
	public void setLim()
	{
		this.limY = this.vecDetail.size() * GameCanvas.hText - (GameCanvas.chatTabScr.hCon - ((this.typeChat == 0) ? (TField.getHeight() + 2) : 0));
		bool flag = this.limY < 0;
		if (flag)
		{
			this.limY = 0;
		}
	}

	// Token: 0x06000094 RID: 148 RVA: 0x00014B5C File Offset: 0x00012D5C
	public MainTextChat[] addChatNew(string[] mstr, sbyte color)
	{
		bool flag = mstr == null || mstr.Length == 0;
		MainTextChat[] result;
		if (flag)
		{
			result = null;
		}
		else
		{
			MainTextChat[] array = new MainTextChat[mstr.Length];
			for (int i = 0; i < mstr.Length; i++)
			{
				array[i] = new MainTextChat(mstr[i], color);
			}
			result = array;
		}
		return result;
	}

	// Token: 0x06000095 RID: 149 RVA: 0x00014BB0 File Offset: 0x00012DB0
	private sbyte setColorText(string name)
	{
		bool flag = this.typeColorChat == 1;
		sbyte result;
		if (flag)
		{
			result = ((this.indexColor % 2 != 0) ? this.colorServer() : 0);
			this.indexColor++;
		}
		else
		{
			bool flag2 = name.CompareTo(GameScreen.player.name) == 0;
			if (flag2)
			{
				result = 5;
			}
			else
			{
				bool flag3 = GameCanvas.IndexServer == 1;
				if (flag3)
				{
					return 1;
				}
				result = 0;
			}
		}
		return result;
	}

	// Token: 0x06000096 RID: 150 RVA: 0x00014C30 File Offset: 0x00012E30
	private sbyte colorServer()
	{
		bool flag = GameCanvas.IndexServer == 1;
		sbyte result;
		if (flag)
		{
			result = 1;
		}
		else
		{
			result = 5;
		}
		return result;
	}

	// Token: 0x06000097 RID: 151 RVA: 0x000092C6 File Offset: 0x000074C6
	public override void paint(mGraphics g)
	{
		base.paint(g);
	}

	// Token: 0x06000098 RID: 152 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void setPos(int xBe, int yBe, int wCon, int hCon, int miniItem, int hchat)
	{
	}

	// Token: 0x06000099 RID: 153 RVA: 0x000090B5 File Offset: 0x000072B5
	public override void update()
	{
	}

	// Token: 0x0600009A RID: 154 RVA: 0x000090B5 File Offset: 0x000072B5
	public override void updatePointer()
	{
	}

	// Token: 0x0600009B RID: 155 RVA: 0x000092D1 File Offset: 0x000074D1
	public override void updatekey()
	{
		base.updatekey();
	}

	// Token: 0x0600009C RID: 156 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void addStringClan(short ID, string str, string nametext, string textRight, sbyte typeBg, sbyte IDEvent, short IdMem, long time)
	{
	}

	// Token: 0x0600009D RID: 157 RVA: 0x00014C54 File Offset: 0x00012E54
	public virtual void updateCameraNew(int size, sbyte type)
	{
		int num = this.hCon;
		bool flag = this.tfchat != null;
		if (flag)
		{
			num -= this.tfchat.height;
		}
		bool flag2 = type == 1;
		if (flag2)
		{
			int cmtoX = this.CamDetailChat.cmtoX;
			int num2 = (cmtoX != 0 && cmtoX != this.CamDetailChat.cmxLim) ? ((cmtoX < this.CamDetailChat.cmxLim - this.hCon) ? 1 : 2) : 0;
			bool flag3 = this.CamDetailChat == null;
			if (flag3)
			{
				this.CamDetailChat = new ListNew(this.xBe, this.yBe, this.wCon, num, 0, 0, this.vecDetail.size() * GameCanvas.hText - num, true);
			}
			else
			{
				this.CamDetailChat.cmxLim = this.vecDetail.size() * GameCanvas.hText - num;
				bool flag4 = this.CamDetailChat.cmxLim < 0;
				if (flag4)
				{
					this.CamDetailChat.cmxLim = 0;
				}
			}
			int num3 = num2;
			int num4 = num3;
			if (num4 != 0)
			{
				if (num4 != 1)
				{
					this.CamDetailChat.setToX(cmtoX + size * GameCanvas.hText);
				}
				else
				{
					this.CamDetailChat.setToX(cmtoX);
					this.CamDetailChat.cmx = cmtoX;
				}
			}
			else
			{
				this.CamDetailChat.setToX(this.CamDetailChat.cmxLim);
			}
		}
		else
		{
			bool flag5 = type == 0;
			if (flag5)
			{
				this.CamDetailChat = new ListNew(this.xBe, this.yBe, this.wCon, num, 0, 0, this.vecDetail.size() * GameCanvas.hText - num, true);
				this.CamDetailChat.setToX(this.CamDetailChat.cmxLim);
				this.CamDetailChat.cmx = this.CamDetailChat.cmxLim;
				this.idSelect = this.vecDetail.size() - 1;
			}
		}
	}

	// Token: 0x0600009E RID: 158 RVA: 0x00014E40 File Offset: 0x00013040
	public void sendChat()
	{
		bool flag = this.tfchat != null && this.tfchat.getText().Length > 0 && this.typeChat == 3;
		if (flag)
		{
			GlobalService.gI().Clan_CMD(0, this.tfchat.getText(), 0, 0);
			this.tfchat.setText(string.Empty);
		}
	}

	// Token: 0x0600009F RID: 159 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void beginFocus()
	{
	}

	// Token: 0x060000A0 RID: 160 RVA: 0x00014EA8 File Offset: 0x000130A8
	public void paintBorder(mGraphics g, sbyte typeColorBg, sbyte typeChatLeftRight, int wLech, int hpaint, int ypaint, bool isfocus)
	{
		bool flag = !GameCanvas.isTouchNoOrPC();
		if (flag)
		{
			isfocus = false;
		}
		bool flag2 = typeColorBg < 0 || typeColorBg > 9;
		if (flag2)
		{
			typeColorBg = 4;
		}
		g.setColor(this.getColorBg(typeColorBg));
		int num = this.xBe - 2 + wLech;
		int num2 = ypaint - 1;
		int num3 = this.wCon + 4 - wLech * 2;
		g.fillRect(num, num2, num3, hpaint);
		bool flag3 = isfocus && GameCanvas.gameTick % 12 < 6;
		if (flag3)
		{
			typeColorBg = 10;
		}
		g.setColor(this.getColorBorderBg(typeColorBg));
		AvMain.fraBorderClan.drawFrame((int)(typeColorBg * 4), num, num2, 0, 0, g);
		AvMain.fraBorderClan.drawFrame((int)(typeColorBg * 4 + 1), num - this.miniItem + num3 + 1, num2, 0, 0, g);
		AvMain.fraBorderClan.drawFrame((int)(typeColorBg * 4 + 2), num, num2 + hpaint - 4, 0, 0, g);
		AvMain.fraBorderClan.drawFrame((int)(typeColorBg * 4 + 3), num - this.miniItem + num3 + 1, num2 + hpaint - 4, 0, 0, g);
		g.fillRect(num, ypaint + 3, 1, hpaint - 8);
		g.fillRect(num - 1 + num3, ypaint + 3, 1, hpaint - 8);
		g.fillRect(num + 4, ypaint - 1, num3 - 8, 1);
		g.fillRect(num + 4, ypaint + hpaint - 2, num3 - 8, 1);
		bool flag4 = typeChatLeftRight == 1;
		if (flag4)
		{
			g.drawRegion(AvMain.imgChatClan, 0, 7, 7, 7, 0, (float)(num - 6), (float)(num2 + 12), 0);
		}
		else
		{
			bool flag5 = typeChatLeftRight == 2;
			if (flag5)
			{
				g.drawRegion(AvMain.imgChatClan, 0, 0, 7, 7, 0, (float)(num + num3 - 1), (float)(num2 + 12), 0);
			}
		}
	}

	// Token: 0x060000A1 RID: 161 RVA: 0x00015054 File Offset: 0x00013254
	public int getColorBg(sbyte typecolor)
	{
		if (!true)
		{
		}
		int result;
		switch (typecolor)
		{
		case 0:
			result = 6526926;
			break;
		case 1:
			result = 8629951;
			break;
		case 2:
			result = 14834512;
			break;
		case 3:
			result = 14847037;
			break;
		case 4:
			result = 12093538;
			break;
		case 5:
			result = 8768101;
			break;
		case 6:
			result = 16441185;
			break;
		case 7:
			result = 14013137;
			break;
		case 8:
			result = 13072991;
			break;
		case 9:
			result = 15790320;
			break;
		default:
			result = 12093538;
			break;
		}
		if (!true)
		{
		}
		return result;
	}

	// Token: 0x060000A2 RID: 162 RVA: 0x000150F8 File Offset: 0x000132F8
	public int getColorBorderBg(sbyte typecolor)
	{
		if (!true)
		{
		}
		int result;
		switch (typecolor)
		{
		case 0:
			result = 2645913;
			break;
		case 1:
			result = 4027015;
			break;
		case 2:
			result = 10432038;
			break;
		case 3:
			result = 10574103;
			break;
		case 4:
			result = 9068345;
			break;
		case 5:
			result = 5807167;
			break;
		case 6:
			result = 14594092;
			break;
		case 7:
			result = 8749954;
			break;
		case 8:
			result = 10178612;
			break;
		case 9:
			result = 11645361;
			break;
		case 10:
			result = 0;
			break;
		default:
			result = 9068345;
			break;
		}
		if (!true)
		{
		}
		return result;
	}

	// Token: 0x060000A3 RID: 163 RVA: 0x000151A4 File Offset: 0x000133A4
	public int getColorBorderNumber(sbyte typecolor)
	{
		if (!true)
		{
		}
		int result;
		if (typecolor != 4)
		{
			if (typecolor != 5)
			{
				result = 9986635;
			}
			else
			{
				result = 4239412;
			}
		}
		else
		{
			result = 9986635;
		}
		if (!true)
		{
		}
		return result;
	}

	// Token: 0x060000A4 RID: 164 RVA: 0x000092DB File Offset: 0x000074DB
	public virtual void setIsNew(bool isnew)
	{
		this.isNew = isnew;
	}

	// Token: 0x04000122 RID: 290
	public const sbyte TYPE_CHAT = 0;

	// Token: 0x04000123 RID: 291
	public const sbyte TYPE_SERVER = 1;

	// Token: 0x04000124 RID: 292
	public const sbyte TYPE_ADDFRIEND = 2;

	// Token: 0x04000125 RID: 293
	public const sbyte TYPE_CLAN_CHAT = 3;

	// Token: 0x04000126 RID: 294
	public const sbyte TYPE_CLAN_MEM = 4;

	// Token: 0x04000127 RID: 295
	public const sbyte TYPE_CLAN_INFO = 5;

	// Token: 0x04000128 RID: 296
	public const sbyte TYPE_TROCHUYEN = 0;

	// Token: 0x04000129 RID: 297
	public const sbyte TYPE_BANGHOI_NHOM = 1;

	// Token: 0x0400012A RID: 298
	public const sbyte BG_BLUE_DARK = 0;

	// Token: 0x0400012B RID: 299
	public const sbyte BG_BLUE = 1;

	// Token: 0x0400012C RID: 300
	public const sbyte BG_RED = 2;

	// Token: 0x0400012D RID: 301
	public const sbyte BG_ORANGE = 3;

	// Token: 0x0400012E RID: 302
	public const sbyte BG_BROWN = 4;

	// Token: 0x0400012F RID: 303
	public const sbyte BG_GREEN = 5;

	// Token: 0x04000130 RID: 304
	public const sbyte BG_GOLD = 6;

	// Token: 0x04000131 RID: 305
	public const sbyte BG_SILVER = 7;

	// Token: 0x04000132 RID: 306
	public const sbyte BG_COPPER = 8;

	// Token: 0x04000133 RID: 307
	public const sbyte BG_WHITE = 9;

	// Token: 0x04000134 RID: 308
	public const sbyte BG_FOCUS = 10;

	// Token: 0x04000135 RID: 309
	public int x;

	// Token: 0x04000136 RID: 310
	public int y;

	// Token: 0x04000137 RID: 311
	public int miniItem = 5;

	// Token: 0x04000138 RID: 312
	public int xBe;

	// Token: 0x04000139 RID: 313
	public int yBe;

	// Token: 0x0400013A RID: 314
	public int wCon;

	// Token: 0x0400013B RID: 315
	public int hCon;

	// Token: 0x0400013C RID: 316
	public int wItem;

	// Token: 0x0400013D RID: 317
	public int hChat;

	// Token: 0x0400013E RID: 318
	public int idSelect;

	// Token: 0x0400013F RID: 319
	public ListNew CamDetailChat;

	// Token: 0x04000140 RID: 320
	public mVector vecDetail = new mVector("ChatDetail.vecDetail");

	// Token: 0x04000141 RID: 321
	public string name;

	// Token: 0x04000142 RID: 322
	public string friend;

	// Token: 0x04000143 RID: 323
	public string shortName;

	// Token: 0x04000144 RID: 324
	public string shortNameFocus;

	// Token: 0x04000145 RID: 325
	public sbyte timeNew = -1;

	// Token: 0x04000146 RID: 326
	public bool isNew;

	// Token: 0x04000147 RID: 327
	public TField tfchat;

	// Token: 0x04000148 RID: 328
	public sbyte typeChat;

	// Token: 0x04000149 RID: 329
	public int limY;

	// Token: 0x0400014A RID: 330
	private int indexColor;

	// Token: 0x0400014B RID: 331
	private sbyte typeColorChat;

	// Token: 0x0400014C RID: 332
	public Scroll scrChat = new Scroll();
}
