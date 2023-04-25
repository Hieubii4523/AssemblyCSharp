using System;

// Token: 0x02000013 RID: 19
public class ChatTabScreen : MainScreen
{
	// Token: 0x060000A5 RID: 165 RVA: 0x000151E4 File Offset: 0x000133E4
	public ChatTabScreen()
	{
		bool flag = this.w > MotherCanvas.w;
		if (flag)
		{
			this.w = MotherCanvas.w;
		}
		bool flag2 = this.h > MotherCanvas.h - GameCanvas.hCommand - 10;
		if (flag2)
		{
			this.h = MotherCanvas.h - GameCanvas.hCommand - 10;
		}
		this.x = MotherCanvas.hw - this.w / 2;
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.y = MotherCanvas.hh - this.h / 2;
		}
		else
		{
			this.y = MotherCanvas.hh - this.h / 2 - GameCanvas.hCommand / 2;
		}
		this.wItem = 24;
		this.xBe = this.x + this.wItem + this.miniItem;
		this.yBe = this.y + this.wItem + this.miniItem;
		this.hCon = this.h - this.wItem - this.miniItem - this.miniItem * 2;
		this.wCon = this.w - this.wItem * 2 - this.miniItem * 2;
		this.hChat = this.hCon / GameCanvas.hText + 2;
		this.CamDetailChat = new ListNew();
		this.CamTab = new ListNew();
		this.wPaintTab = 60;
		this.cmdMenu = new iCommand(T.close, 0, this);
		bool isTouch2 = GameCanvas.isTouch;
		if (isTouch2)
		{
			this.cmdMenu.setPos(this.x + this.w - this.wItem / 2, this.y + this.wItem / 10 + this.miniItem / 2 + this.wItem / 5 * 2, MainTab.fraCloseTab, string.Empty);
		}
		else
		{
			this.cmdMenu = AvMain.setPosCMD(this.cmdMenu, 1);
		}
		this.left = this.cmdMenu;
		this.menuCMD = this.left;
		this.cmdCloseChat = new iCommand(T.close + " " + T.TroChuyen, 1, this);
		this.cmdCloseTab = new iCommand(T.close + " " + T.thistab, 2, this);
		this.cmdChat = new iCommand(T.chat, 3, this);
	}

	// Token: 0x060000A6 RID: 166 RVA: 0x000092E5 File Offset: 0x000074E5
	public override void setxyPlus12()
	{
		GameCanvas.xPlus12 = 2;
		GameCanvas.yPlus12 = 2;
	}

	// Token: 0x060000A7 RID: 167 RVA: 0x000092F4 File Offset: 0x000074F4
	public override void Show(MainScreen screen)
	{
		this.checkRemove();
		this.getCurTab(this.idSelect);
		base.Show(screen);
	}

	// Token: 0x060000A8 RID: 168 RVA: 0x00015468 File Offset: 0x00013668
	private void checkRemove()
	{
		for (int i = 0; i < this.vecTabChat.size(); i++)
		{
			ChatDetail chatDetail = (ChatDetail)this.vecTabChat.elementAt(i);
			bool flag = chatDetail.typeChat != 3 && chatDetail.typeChat != 5 && chatDetail.vecDetail.size() > 40;
			if (flag)
			{
				int num = chatDetail.vecDetail.size() - 30;
				for (int j = 0; j < num; j++)
				{
					chatDetail.vecDetail.removeElementAt(0);
				}
			}
		}
	}

	// Token: 0x060000A9 RID: 169 RVA: 0x00015508 File Offset: 0x00013708
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
			this.doMenu();
			break;
		case 1:
		{
			bool flag = this.lastScreen != null;
			if (flag)
			{
				this.lastScreen.Show(this.lastScreen.lastScreen);
			}
			else
			{
				GameCanvas.gameScr.Show();
			}
			break;
		}
		case 2:
		{
			bool flag2 = this.idSelect == 0;
			if (flag2)
			{
				this.cmdCloseChat.perform();
			}
			else
			{
				bool flag3 = this.idSelect >= 0 && this.idSelect < this.vecTabChat.size();
				if (flag3)
				{
					this.vecTabChat.removeElementAt(this.idSelect);
				}
				this.idSelect = AvMain.resetSelect(this.idSelect, this.vecTabChat.size() - 1, false);
				this.getCurTab(this.idSelect);
				bool flag4 = this.vecTabChat.size() == 1 && !GameCanvas.isTouch;
				if (flag4)
				{
					this.cmdMenu.caption = T.close;
				}
			}
			break;
		}
		case 3:
		{
			bool flag5 = this.tabCur != null && this.tabCur.tfchat != null;
			if (flag5)
			{
				this.tabCur.addStartChat(GameScreen.player.name);
			}
			break;
		}
		}
	}

	// Token: 0x060000AA RID: 170 RVA: 0x0001566C File Offset: 0x0001386C
	public void checkRemoveTab(string name)
	{
		for (int i = 0; i < this.vecTabChat.size(); i++)
		{
			ChatDetail chatDetail = (ChatDetail)this.vecTabChat.elementAt(i);
			bool flag = chatDetail.name.CompareTo(name) == 0;
			if (flag)
			{
				this.vecTabChat.removeElementAt(i);
				break;
			}
		}
		this.idSelect = AvMain.resetSelect(this.idSelect, this.vecTabChat.size() - 1, false);
	}

	// Token: 0x060000AB RID: 171 RVA: 0x00009313 File Offset: 0x00007513
	private void doMenu()
	{
		this.cmdCloseChat.perform();
	}

	// Token: 0x060000AC RID: 172 RVA: 0x000156EC File Offset: 0x000138EC
	public override void paint(mGraphics g)
	{
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.paint(g);
		}
		GameCanvas.resetTrans(g);
		MainTab.paintPaperTab(g, this.x, this.y, this.w, this.h);
		AvMain.paintRect(g, this.xBe - this.miniItem, this.yBe - this.miniItem, this.wCon + this.miniItem * 2, this.hCon + this.miniItem * 2, 0, 4);
		g.setClip(this.x + this.wItem / 2, this.y, this.w - this.wItem, this.wItem + this.miniItem * 2);
		g.saveCanvas();
		g.ClipRec(this.x + this.wItem / 2, this.y, this.w - this.wItem, this.wItem + this.miniItem * 2);
		g.translate(-this.CamTab.cmx, 0);
		int num = this.xBe;
		int num2 = 0;
		while (num2 < this.idSelect && num2 < this.vecTabChat.size())
		{
			ChatDetail chatDetail = (ChatDetail)this.vecTabChat.elementAt(num2);
			int index = 2;
			bool flag2 = chatDetail.isNew && ((int)chatDetail.timeNew + GameCanvas.gameTick) % 8 < 4;
			if (flag2)
			{
				index = 1;
			}
			AvMain.paintRect(g, num, this.y + this.wItem / 10 + this.miniItem / 2, this.wPaintTab / 2, this.wItem / 5 * 4, 1, index);
			mFont.tahoma_7_white.drawString(g, chatDetail.shortName, num + 2, this.y + this.wItem / 10 + this.miniItem / 2 + 2, 0);
			num += this.wPaintTab / 2;
			num2++;
		}
		int num3 = this.vecTabChat.size() - 1;
		while (num3 > this.idSelect && num3 < this.vecTabChat.size() && num3 >= 0)
		{
			ChatDetail chatDetail2 = (ChatDetail)this.vecTabChat.elementAt(num3);
			int index2 = 2;
			bool flag3 = chatDetail2.isNew && ((int)chatDetail2.timeNew + GameCanvas.gameTick) % 8 < 4;
			if (flag3)
			{
				index2 = 1;
			}
			AvMain.paintRect(g, this.xBe + this.wPaintTab / 2 + num3 * (this.wPaintTab / 2), this.y + this.wItem / 10 + this.miniItem / 2, this.wPaintTab / 2 + 1, this.wItem / 5 * 4, 1, index2);
			mFont.tahoma_7_white.drawString(g, chatDetail2.shortName, this.xBe + this.wPaintTab / 2 + num3 * (this.wPaintTab / 2) + 4, this.y + this.wItem / 10 + this.miniItem / 2 + 2, 0);
			num3--;
		}
		bool flag4 = this.tabCur != null;
		if (flag4)
		{
			AvMain.paintRect(g, this.xBe + this.wPaintTab / 2 * this.idSelect, this.y + this.wItem / 10 + this.miniItem / 2, this.wPaintTab, this.wItem / 5 * 4, 1, 4);
			int num4 = 0;
			bool flag5 = this.idSelect == 0 && !GameCanvas.isDeviceStore();
			if (flag5)
			{
				num4 = 9;
				Interface_Game.fraBorderNoti4.drawFrame((GameCanvas.language != 0) ? 3 : GameCanvas.IndexServer, this.xBe + this.wPaintTab / 2 * this.idSelect + 9, this.y + this.wItem / 10 + this.miniItem / 2 + 2 + 5, 0, 3, g);
			}
			mFont.tahoma_7b_white.drawString(g, this.tabCur.shortNameFocus, this.xBe + this.wPaintTab / 2 * this.idSelect + this.wPaintTab / 2 + num4, this.y + this.wItem / 10 + this.miniItem / 2 + 2, 2);
			mGraphics.resetTransAndroid(g);
			g.restoreCanvas();
			GameCanvas.resetTrans(g);
			bool flag6 = this.tabCur.tfchat != null;
			if (flag6)
			{
				this.tabCur.tfchat.paint(g);
			}
			g.setClip(this.xBe - this.miniItem, this.yBe - this.miniItem, this.wCon + this.miniItem * 2, this.hCon - ((this.tabCur.tfchat == null) ? (-this.miniItem) : this.tabCur.tfchat.height) + 2);
			g.saveCanvas();
			g.ClipRec(this.xBe - this.miniItem, this.yBe - this.miniItem, this.wCon + this.miniItem * 2, this.hCon - ((this.tabCur.tfchat == null) ? (-this.miniItem) : this.tabCur.tfchat.height) + 2);
			g.translate(0, -this.CamDetailChat.cmx);
			this.minChat = this.CamDetailChat.cmx / GameCanvas.hText - 2;
			bool flag7 = this.minChat < 0;
			if (flag7)
			{
				this.minChat = 0;
			}
			this.maxChat = this.minChat + this.hChat;
			for (int i = this.minChat; i <= this.maxChat; i++)
			{
				bool flag8 = i < this.tabCur.vecDetail.size() && i >= 0;
				if (flag8)
				{
					MainTextChat mainTextChat = (MainTextChat)this.tabCur.vecDetail.elementAt(i);
					AvMain.setTextColor((int)mainTextChat.color).drawString(g, mainTextChat.text, this.xBe, this.yBe + i * GameCanvas.hText, 0);
				}
			}
			mGraphics.resetTransAndroid(g);
			g.restoreCanvas();
		}
		base.paint(g);
		bool flag9 = this.tabCur != null && this.CamDetailChat.cmxLim > 0;
		if (flag9)
		{
			this.tabCur.scrChat.paint(g);
		}
	}

	// Token: 0x060000AD RID: 173 RVA: 0x00015D70 File Offset: 0x00013F70
	public override void update()
	{
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.update();
		}
		this.CamTab.moveCamera();
		this.CamDetailChat.moveCamera();
		bool flag2 = this.tabCur != null;
		if (flag2)
		{
			this.tabCur.scrChat.setYScrool(this.CamDetailChat.cmx, this.CamDetailChat.cmxLim);
		}
		bool flag3 = this.tabCur.tfchat != null;
		if (flag3)
		{
			this.tabCur.tfchat.update();
		}
		base.update();
	}

	// Token: 0x060000AE RID: 174 RVA: 0x00015E14 File Offset: 0x00014014
	public override void updatekey()
	{
		int num = this.idSelect;
		bool flag = GameCanvas.keyMyHold[4];
		if (flag)
		{
			GameCanvas.clearKeyHold(4);
			bool flag2 = this.idSelect > 0;
			if (flag2)
			{
				this.idSelect--;
			}
		}
		else
		{
			bool flag3 = GameCanvas.keyMyHold[6];
			if (flag3)
			{
				GameCanvas.clearKeyHold(6);
				bool flag4 = this.idSelect < this.vecTabChat.size() - 1;
				if (flag4)
				{
					this.idSelect++;
				}
			}
			else
			{
				bool flag5 = GameCanvas.keyMyHold[2];
				if (flag5)
				{
					GameCanvas.clearKeyHold(2);
					this.CamDetailChat.cmtoX -= GameCanvas.hText;
					bool flag6 = this.CamDetailChat.cmtoX < 0;
					if (flag6)
					{
						this.CamDetailChat.cmtoX = 0;
					}
				}
				else
				{
					bool flag7 = GameCanvas.keyMyHold[8];
					if (flag7)
					{
						GameCanvas.clearKeyHold(8);
						this.CamDetailChat.cmtoX += GameCanvas.hText;
						bool flag8 = this.CamDetailChat.cmtoX > this.CamDetailChat.cmxLim;
						if (flag8)
						{
							this.CamDetailChat.cmtoX = this.CamDetailChat.cmxLim;
						}
					}
				}
			}
		}
		bool flag9 = num != this.idSelect;
		if (flag9)
		{
			this.getCurTab(this.idSelect);
			this.CamTab.setToX(this.xBe + this.idSelect * this.wPaintTab / 2 + this.wPaintTab / 2 - this.w / 2);
		}
		this.updateCmd();
		this.updatekeyPCForTField();
	}

	// Token: 0x060000AF RID: 175 RVA: 0x000092D1 File Offset: 0x000074D1
	public void updateCmd()
	{
		base.updatekey();
	}

	// Token: 0x060000B0 RID: 176 RVA: 0x00015FBC File Offset: 0x000141BC
	public override void updatePointer()
	{
		this.CamTab.updatePos_LEFT_RIGHT();
		this.CamDetailChat.update_Pos_UP_DOWN();
		bool flag = GameCanvas.isPointSelect(this.x + this.wItem / 2, this.y, this.w - this.wItem, this.wItem + this.miniItem * 2);
		if (flag)
		{
			int num = (this.CamTab.cmx + GameCanvas.px - this.xBe) / (this.wPaintTab / 2);
			bool flag2 = num > this.idSelect;
			if (flag2)
			{
				num--;
			}
			bool flag3 = num >= 0 && num < this.vecTabChat.size() && num != this.idSelect;
			if (flag3)
			{
				this.getCurTab(num);
			}
		}
		bool flag4 = this.tabCur.tfchat != null;
		if (flag4)
		{
			this.tabCur.tfchat.updatePointer();
		}
		base.updatePointer();
	}

	// Token: 0x060000B1 RID: 177 RVA: 0x000160B0 File Offset: 0x000142B0
	public override void keyPress(int keyCode)
	{
		bool flag = this.tabCur.tfchat != null;
		if (flag)
		{
			this.tabCur.tfchat.keyPressed(keyCode);
		}
		base.keyPress(keyCode);
	}

	// Token: 0x060000B2 RID: 178 RVA: 0x000160EC File Offset: 0x000142EC
	public void updateCameraNew(int size, sbyte type)
	{
		int num = this.hCon;
		bool flag = this.tabCur.tfchat != null;
		if (flag)
		{
			num -= this.tabCur.tfchat.height;
		}
		bool flag2 = this.tabCur == null;
		if (!flag2)
		{
			bool flag3 = type == 1;
			if (flag3)
			{
				int cmtoX = this.CamDetailChat.cmtoX;
				int num2 = (cmtoX != 0 && cmtoX != this.CamDetailChat.cmxLim) ? ((cmtoX < this.CamDetailChat.cmxLim - this.hCon) ? 1 : 2) : 0;
				bool flag4 = this.CamDetailChat == null;
				if (flag4)
				{
					this.CamDetailChat = new ListNew(this.xBe, this.yBe, this.wCon, num, 0, 0, this.tabCur.vecDetail.size() * GameCanvas.hText - num, true);
				}
				else
				{
					this.CamDetailChat.cmxLim = this.tabCur.vecDetail.size() * GameCanvas.hText - num;
					bool flag5 = this.CamDetailChat.cmxLim < 0;
					if (flag5)
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
				bool flag6 = type == 0;
				if (flag6)
				{
					this.CamDetailChat = new ListNew(this.xBe, this.yBe, this.wCon, num, 0, 0, this.tabCur.vecDetail.size() * GameCanvas.hText - num, true);
					this.CamDetailChat.setToX(this.CamDetailChat.cmxLim);
					this.CamDetailChat.cmx = this.CamDetailChat.cmxLim;
				}
			}
		}
	}

	// Token: 0x060000B3 RID: 179 RVA: 0x000162F4 File Offset: 0x000144F4
	public void addNewChatCheckSpam(string name, string FristContent, string content, sbyte type, bool isFocus)
	{
		bool flag = MsgSpamSetup.isCheckSpam(2, name);
		if (flag)
		{
			for (int i = 0; i < this.vecTabChat.size(); i++)
			{
				ChatDetail chatDetail = (ChatDetail)this.vecTabChat.elementAt(i);
				bool flag2 = chatDetail.name.CompareTo(name) == 0;
				if (flag2)
				{
					this.addNewChat(name, FristContent, content, type, isFocus);
					break;
				}
			}
		}
		else
		{
			this.addNewChat(name, FristContent, content, type, isFocus);
		}
	}

	// Token: 0x060000B4 RID: 180 RVA: 0x00009322 File Offset: 0x00007522
	public void addNewChat(string name, string FristContent, string content, sbyte type, bool isFocus)
	{
		this.addNewChat(name, FristContent, content, type, isFocus, -1);
	}

	// Token: 0x060000B5 RID: 181 RVA: 0x00016378 File Offset: 0x00014578
	public void addNewChat(string name, string FristContent, string content, sbyte type, bool isFocus, int color)
	{
		bool flag = content == null;
		if (!flag)
		{
			bool flag2 = content.Length > 0;
			if (flag2)
			{
				string[] array = mFont.tahoma_7_white.splitFontArray(content, MainEvent.wShort - 50);
				string text = array[0];
				bool flag3 = array.Length > 1;
				if (flag3)
				{
					text += "...";
				}
				InfoMemList.setTypeEvent(-1, 2, name, text, 0, 0);
			}
			for (int i = 0; i < this.vecTabChat.size(); i++)
			{
				ChatDetail chatDetail = (ChatDetail)this.vecTabChat.elementAt(i);
				bool flag4 = chatDetail.name.CompareTo(name) == 0;
				if (flag4)
				{
					if (isFocus)
					{
						this.idSelect = i;
					}
					bool flag5 = content.Length > 0;
					if (flag5)
					{
						chatDetail.addString(FristContent + content, name, color);
					}
					return;
				}
			}
			ChatDetail chatDetail2 = new ChatDetail(name, type);
			bool flag6 = content.Length > 0;
			if (flag6)
			{
				chatDetail2.addString(FristContent + content, name, color);
			}
			this.vecTabChat.addElement(chatDetail2);
			if (isFocus)
			{
				this.idSelect = this.vecTabChat.size() - 1;
			}
			bool flag7 = !GameCanvas.isTouch;
			if (flag7)
			{
				this.cmdMenu.caption = T.close;
			}
			int num = (this.vecTabChat.size() + 1) * this.wPaintTab / 2 - this.wCon;
			bool flag8 = num > 0;
			if (flag8)
			{
				this.CamTab.cmxLim = num;
			}
		}
	}

	// Token: 0x060000B6 RID: 182 RVA: 0x000090B5 File Offset: 0x000072B5
	public void set_text_min_max()
	{
	}

	// Token: 0x060000B7 RID: 183 RVA: 0x00016520 File Offset: 0x00014720
	public virtual void getCurTab(int id)
	{
		this.idSelect = id;
		bool flag = this.idSelect < 0 || this.idSelect >= this.vecTabChat.size();
		if (!flag)
		{
			this.tabCur = (ChatDetail)this.vecTabChat.elementAt(this.idSelect);
			bool flag2 = GameCanvas.eventScr != null && GameCanvas.eventScr.vecPlayer != null;
			if (flag2)
			{
				for (int i = 0; i < GameCanvas.eventScr.vecPlayer.size(); i++)
				{
					InfoMemList infoMemList = (InfoMemList)GameCanvas.eventScr.vecPlayer.elementAt(i);
					bool flag3 = infoMemList.name.CompareTo(this.tabCur.name) == 0 && infoMemList.typeEvent == 2;
					if (flag3)
					{
						infoMemList.isNew = false;
						break;
					}
				}
			}
			this.tabCur.isNew = false;
			this.updateCameraNew(0, 0);
			this.getRightCmd();
			bool flag4 = this.tabCur.name.CompareTo(T.hethong) == 0;
			if (flag4)
			{
				Player.strHethong = string.Empty;
			}
		}
	}

	// Token: 0x060000B8 RID: 184 RVA: 0x0001664C File Offset: 0x0001484C
	public void updateCamTab()
	{
		this.CamTab = new ListNew(this.x, this.y, this.wCon, this.wItem + this.miniItem * 2, 0, 0, (this.vecTabChat.size() + 1) * this.wPaintTab / 2 - this.wCon, true);
	}

	// Token: 0x060000B9 RID: 185 RVA: 0x000166A8 File Offset: 0x000148A8
	public void getRightCmd()
	{
		bool flag = !GameCanvas.isTouchNoOrPC() || this.tabCur == null;
		if (!flag)
		{
			bool flag2 = this.tabCur.tfchat != null;
			if (flag2)
			{
				bool flag3 = !GameCanvas.isTouch;
				if (flag3)
				{
					this.right = this.tabCur.tfchat.cmdClear;
				}
				this.tabCur.tfchat.setFocus(true);
				this.center = this.cmdChat;
			}
			else
			{
				this.right = null;
				this.center = null;
			}
		}
	}

	// Token: 0x060000BA RID: 186 RVA: 0x00016738 File Offset: 0x00014938
	public override bool keyBack()
	{
		bool flag = !base.keyBack() && this.cmdCloseChat != null;
		if (flag)
		{
			this.cmdCloseChat.perform();
		}
		return false;
	}

	// Token: 0x0400014D RID: 333
	public const sbyte UPDATE = 1;

	// Token: 0x0400014E RID: 334
	public const sbyte NEW = 0;

	// Token: 0x0400014F RID: 335
	public int x;

	// Token: 0x04000150 RID: 336
	public int y;

	// Token: 0x04000151 RID: 337
	public int w = 225;

	// Token: 0x04000152 RID: 338
	public int h = 194;

	// Token: 0x04000153 RID: 339
	public int miniItem = 5;

	// Token: 0x04000154 RID: 340
	public int xBe;

	// Token: 0x04000155 RID: 341
	public int yBe;

	// Token: 0x04000156 RID: 342
	public int wCon;

	// Token: 0x04000157 RID: 343
	public int hCon;

	// Token: 0x04000158 RID: 344
	public int wItem;

	// Token: 0x04000159 RID: 345
	public int hChat;

	// Token: 0x0400015A RID: 346
	public int wPaintTab;

	// Token: 0x0400015B RID: 347
	public mVector vecTabChat = new mVector("ChatTabScreen.vecTabChat");

	// Token: 0x0400015C RID: 348
	public ChatDetail tabCur;

	// Token: 0x0400015D RID: 349
	public int idSelect;

	// Token: 0x0400015E RID: 350
	private ListNew CamDetailChat;

	// Token: 0x0400015F RID: 351
	private ListNew CamTab;

	// Token: 0x04000160 RID: 352
	private iCommand cmdMenu;

	// Token: 0x04000161 RID: 353
	private iCommand cmdCloseChat;

	// Token: 0x04000162 RID: 354
	private iCommand cmdCloseTab;

	// Token: 0x04000163 RID: 355
	private iCommand cmdChat;

	// Token: 0x04000164 RID: 356
	private int minChat;

	// Token: 0x04000165 RID: 357
	private int maxChat;
}
