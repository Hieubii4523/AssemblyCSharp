using System;

// Token: 0x020000F7 RID: 247
public class Sudo_Chat : ChatDetail
{
	// Token: 0x06000E84 RID: 3716 RVA: 0x00009388 File Offset: 0x00007588
	public Sudo_Chat(string name, sbyte type) : base(name, type)
	{
	}

	// Token: 0x06000E85 RID: 3717 RVA: 0x0011786C File Offset: 0x00115A6C
	public override void setPos(int xBe, int yBe, int wCon, int hCon, int miniItem, int hchat)
	{
		this.xBe = xBe;
		this.yBe = yBe;
		this.wCon = wCon;
		this.hCon = hCon;
		this.miniItem = miniItem;
		this.hChat = hchat;
		this.tfchat = new TField(xBe + 60, yBe + hCon - TField.getHeight(), wCon - 60);
		this.tfchat.setStringNull(T.TroChuyen);
		this.tfchat.setFocus(true);
		this.updateCameraNew(0, 0);
		this.cmdView = new iCommand(T.view, 0, this);
		this.cmdChoVaoClan = new iCommand(T.chapnhan, 1, this);
		this.cmdTuChoiVaoClan = new iCommand(T.tuchoi, 2, this);
		this.cmdChat = new iCommand(T.chat, 3, this);
		bool flag = !GameCanvas.isTouch;
		if (flag)
		{
			this.center = this.cmdChat;
		}
	}

	// Token: 0x06000E86 RID: 3718 RVA: 0x00117950 File Offset: 0x00115B50
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
		{
			bool flag = this.memCur != null;
			if (flag)
			{
				mVector mVector = new mVector();
				mVector.addElement(this.cmdChoVaoClan);
				mVector.addElement(this.cmdTuChoiVaoClan);
				GameCanvas.Start_Normal_DiaLog(this.memCur.name + T.muonvaoClan, mVector, true);
			}
			break;
		}
		case 1:
		{
			GameCanvas.end_Dialog();
			bool flag2 = this.memCur != null;
			if (flag2)
			{
				GlobalService.gI().Sudo_CMD(18, this.memCur.name, this.memCur.idEvent, 0);
			}
			break;
		}
		case 2:
		{
			GameCanvas.end_Dialog();
			bool flag3 = this.memCur != null;
			if (flag3)
			{
				GlobalService.gI().Sudo_CMD(20, this.memCur.name, this.memCur.idEvent, 0);
			}
			break;
		}
		case 3:
			this.sendChat();
			break;
		}
	}

	// Token: 0x06000E87 RID: 3719 RVA: 0x00117A54 File Offset: 0x00115C54
	public override void beginFocus()
	{
		this.idSelect = this.vecDetail.size() - 1;
		for (int i = this.idSelect; i >= 0; i--)
		{
			MainTextChat mainTextChat = (MainTextChat)this.vecDetail.elementAt(i);
			bool flag = mainTextChat.lenghtText > 0;
			if (flag)
			{
				this.idSelect = i;
				break;
			}
		}
		this.checkRemoveChat();
		this.setXCam();
		this.updateTime();
	}

	// Token: 0x06000E88 RID: 3720 RVA: 0x00117AD0 File Offset: 0x00115CD0
	public override void paint(mGraphics g)
	{
		bool flag = this.tfchat != null;
		if (flag)
		{
			this.tfchat.paint(g);
		}
		AvMain.paintRect(g, this.xBe, this.yBe + this.hCon - TField.getHeight(), 60 - this.miniItem, TField.getHeight() + 1, 0, 1);
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			g.drawImage(AvMain.imgDonateClan, this.xBe + 30 - this.miniItem / 2, this.yBe + this.hCon - TField.getHeight() + 2 + 7, 3);
			bool flag2 = MainTab.CDDonateClan.timeCountDown <= 0;
			if (flag2)
			{
				mFont.tahoma_7_white.drawString(g, T.tangqua, this.xBe + 30 - this.miniItem / 2, this.yBe + this.hCon - TField.getHeight() + 17, 2);
			}
			else
			{
				MainTab.CDDonateClan.paintCountDownTicketHour(g, mFont.tahoma_7_white, this.xBe + 18 - this.miniItem / 2, this.yBe + this.hCon - TField.getHeight() + 17, 0);
			}
		}
		else
		{
			bool flag3 = MainTab.CDDonateClan.timeCountDown <= 0;
			if (flag3)
			{
				g.drawImage(AvMain.imgDonateClan, this.xBe + 10 - this.miniItem / 2, this.yBe + this.hCon - TField.getHeight() + 2 + 10, 3);
				mFont.tahoma_7_white.drawString(g, T.tangqua, this.xBe + 37 - this.miniItem / 2, this.yBe + this.hCon - TField.getHeight() + 17 - 12, 2);
			}
			else
			{
				g.drawImage(AvMain.imgDonateClan, this.xBe + 16 - this.miniItem / 2, this.yBe + this.hCon - TField.getHeight() + 2 + 10, 3);
				MainTab.CDDonateClan.paintCountDownTicketHour(g, mFont.tahoma_7_white, this.xBe + 39 - this.miniItem / 2, this.yBe + this.hCon - TField.getHeight() + 17 - 11, 0);
			}
		}
		g.setClip(this.xBe - this.miniItem, this.yBe - 2, this.wCon + this.miniItem * 2, this.hCon - ((this.tfchat == null) ? (-this.miniItem) : this.tfchat.height) + 2);
		g.saveCanvas();
		g.ClipRec(this.xBe - this.miniItem, this.yBe - 2, this.wCon + this.miniItem * 2, this.hCon - ((this.tfchat == null) ? (-this.miniItem) : this.tfchat.height) + 2);
		g.translate(0, -this.CamDetailChat.cmx);
		this.minChat = this.CamDetailChat.cmx / GameCanvas.hText - 4;
		bool flag4 = this.minChat < 0;
		if (flag4)
		{
			this.minChat = 0;
		}
		this.maxChat = this.minChat + this.hChat;
		for (int i = this.minChat; i <= this.maxChat; i++)
		{
			bool flag5 = i >= this.vecDetail.size() || i < 0;
			if (!flag5)
			{
				MainTextChat mainTextChat = (MainTextChat)this.vecDetail.elementAt(i);
				bool flag6 = mainTextChat.lenghtText > 0;
				if (flag6)
				{
					base.paintBorder(g, mainTextChat.typeBg, mainTextChat.typeLeftRight, this.miniItem, GameCanvas.hText * (int)mainTextChat.lenghtText - 2, this.yBe + i * GameCanvas.hText, i == this.idSelect);
					bool flag7 = mainTextChat.typeBg == 2;
					if (flag7)
					{
						AvMain.setTextColorName((int)mainTextChat.color).drawString(g, mainTextChat.text, this.xBe + this.miniItem + 2, this.yBe + i * GameCanvas.hText, 0);
					}
					else
					{
						AvMain.FontBorderColor(g, mainTextChat.text, this.xBe + this.miniItem + 2, this.yBe + i * GameCanvas.hText + 1, 0, (int)mainTextChat.color, 7);
					}
					bool flag8 = mainTextChat.typeEvent > -1 && MainClan.isPhongChuc();
					if (flag8)
					{
						AvMain.paintRect(g, this.xBe + this.miniItem + 2, this.yBe + i * GameCanvas.hText + (int)(mainTextChat.lenghtText - 1) * GameCanvas.hText - 2, 30, GameCanvas.hText - 5, 3, 1);
						mFont.tahoma_7_white.drawString(g, T.view, this.xBe + this.miniItem + 2 + 15, this.yBe + i * GameCanvas.hText + (int)(mainTextChat.lenghtText - 1) * GameCanvas.hText - 2, 2);
					}
				}
				else
				{
					bool flag9 = mainTextChat.timeBegin > -1L;
					if (flag9)
					{
						mFont.tahoma_7_black.drawString(g, mainTextChat.textTime, this.xBe - this.miniItem + this.wCon, this.yBe + i * GameCanvas.hText - 2, 1);
					}
					else
					{
						AvMain.setTextColorName((int)mainTextChat.color).drawString(g, mainTextChat.text, this.xBe + this.miniItem + 2, this.yBe + i * GameCanvas.hText, 0);
					}
				}
				bool flag10 = mainTextChat.textRight.Length > 0;
				if (flag10)
				{
					mFont.tahoma_7_white.drawString(g, mainTextChat.textRight, this.xBe + this.wCon - this.miniItem, this.yBe + i * GameCanvas.hText + 1, 1);
				}
			}
		}
		mGraphics.resetTransAndroid(g);
		g.restoreCanvas();
		base.paint(g);
	}

	// Token: 0x06000E89 RID: 3721 RVA: 0x001180E0 File Offset: 0x001162E0
	public override void update()
	{
		this.CamDetailChat.moveCamera();
		bool flag = this.tfchat != null;
		if (flag)
		{
			this.tfchat.update();
		}
		bool flag2 = GameCanvas.gameTick % 500 == 0;
		if (flag2)
		{
			this.updateTime();
			bool flag3 = this.CamDetailChat.cmx == this.CamDetailChat.cmxLim;
			if (flag3)
			{
				this.checkRemoveChat();
			}
		}
	}

	// Token: 0x06000E8A RID: 3722 RVA: 0x00017300 File Offset: 0x00015500
	public void updateTime()
	{
		for (int i = 0; i < this.vecDetail.size(); i++)
		{
			MainTextChat mainTextChat = (MainTextChat)this.vecDetail.elementAt(i);
			bool flag = mainTextChat.timeBegin > 0L;
			if (flag)
			{
				mainTextChat.setTimePaint();
			}
		}
	}

	// Token: 0x06000E8B RID: 3723 RVA: 0x00118158 File Offset: 0x00116358
	public override void updatekey()
	{
		int num = this.idSelect;
		bool flag = GameCanvas.keyMyHold[2];
		if (flag)
		{
			GameCanvas.clearKeyHold(2);
			bool flag2 = num > 0;
			if (flag2)
			{
				num--;
			}
		}
		else
		{
			bool flag3 = GameCanvas.keyMyHold[8];
			if (flag3)
			{
				GameCanvas.clearKeyHold(8);
				bool flag4 = num < this.vecDetail.size() - 1;
				if (flag4)
				{
					num++;
				}
			}
		}
		bool flag5 = num != this.idSelect;
		if (flag5)
		{
			MainTextChat mainTextChat = null;
			bool flag6 = num < this.idSelect;
			if (flag6)
			{
				for (int i = num; i >= 0; i--)
				{
					mainTextChat = (MainTextChat)this.vecDetail.elementAt(i);
					bool flag7 = mainTextChat.lenghtText > 0;
					if (flag7)
					{
						this.idSelect = i;
						break;
					}
				}
			}
			else
			{
				for (int j = num; j < this.vecDetail.size(); j++)
				{
					mainTextChat = (MainTextChat)this.vecDetail.elementAt(j);
					bool flag8 = mainTextChat.lenghtText > 0;
					if (flag8)
					{
						this.idSelect = j;
						break;
					}
				}
			}
			this.chatCur = mainTextChat;
			this.left = null;
			bool flag9 = MainClan.isPhongChuc();
			if (flag9)
			{
				this.getCmdEvent();
			}
			this.setXCam();
		}
		base.updatekey();
	}

	// Token: 0x06000E8C RID: 3724 RVA: 0x001182BC File Offset: 0x001164BC
	private void setXCam()
	{
		int num = this.idSelect;
		bool flag = this.chatCur != null;
		if (flag)
		{
			num += (int)this.chatCur.lenghtText;
		}
		int toX = num * GameCanvas.hText - this.hCon / 4;
		this.CamDetailChat.setToX(toX);
	}

	// Token: 0x06000E8D RID: 3725 RVA: 0x0011830C File Offset: 0x0011650C
	private void getCmdEvent()
	{
		bool flag = this.idSelect < 0 || this.idSelect >= this.vecDetail.size();
		if (!flag)
		{
			for (int i = this.idSelect; i >= 0; i--)
			{
				MainTextChat mainTextChat = (MainTextChat)this.vecDetail.elementAt(i);
				bool flag2 = mainTextChat.lenghtText > 0;
				if (flag2)
				{
					bool flag3 = mainTextChat.typeEvent < 0;
					if (flag3)
					{
						break;
					}
					bool flag4 = mainTextChat.typeEvent == 1;
					if (flag4)
					{
						this.memCur = new InfoMemList((int)mainTextChat.IDMem);
						this.memCur.name = mainTextChat.nameText;
						this.memCur.idEvent = (int)mainTextChat.IdText;
						this.left = this.cmdView;
					}
				}
			}
		}
	}

	// Token: 0x06000E8E RID: 3726 RVA: 0x001183EC File Offset: 0x001165EC
	public override void updatePointer()
	{
		this.CamDetailChat.update_Pos_UP_DOWN();
		bool flag = this.tfchat != null;
		if (flag)
		{
			this.tfchat.updatePointer();
		}
		bool flag2 = GameCanvas.isPointerSelect && this.vecDetail.size() > 0 && GameCanvas.isPoint(this.xBe, this.yBe, this.wCon, this.hCon);
		if (flag2)
		{
			GameCanvas.isPointerSelect = false;
			int num = (GameCanvas.py - this.yBe + this.CamDetailChat.cmx) / GameCanvas.hText;
			bool flag3 = num >= 0 && num < this.vecDetail.size();
			if (flag3)
			{
				this.idSelect = num;
				this.setEvent();
			}
		}
	}

	// Token: 0x06000E8F RID: 3727 RVA: 0x001184AC File Offset: 0x001166AC
	private void setEvent()
	{
		bool flag = this.idSelect < 0 || this.idSelect >= this.vecDetail.size();
		if (!flag)
		{
			for (int i = this.idSelect; i >= 0; i--)
			{
				MainTextChat mainTextChat = (MainTextChat)this.vecDetail.elementAt(i);
				bool flag2 = mainTextChat.lenghtText > 0;
				if (flag2)
				{
					this.idSelect = i;
					bool flag3 = mainTextChat.typeEvent >= 0 && mainTextChat.typeEvent == 1 && MainClan.isPhongChuc() && (Player.ChucInCLan == 0 || Player.ChucInCLan == 1 || Player.ChucInCLan == 2);
					if (flag3)
					{
						this.memCur = new InfoMemList((int)mainTextChat.IDMem);
						this.memCur.name = mainTextChat.nameText;
						this.memCur.idEvent = (int)mainTextChat.IdText;
						this.cmdView.perform();
					}
					break;
				}
			}
		}
	}

	// Token: 0x06000E90 RID: 3728 RVA: 0x000177B0 File Offset: 0x000159B0
	public override void addStringClan(short ID, string str, string nametext, string textRight, sbyte typeBg, sbyte IDEvent, short IdMem, long time)
	{
		bool flag = str.Length <= 0;
		if (!flag)
		{
			string src = string.Empty;
			src = ((typeBg == 2) ? (nametext + " " + str) : (nametext + "\n" + str));
			string[] array = mFont.tahoma_7b_white.splitFontArray(src, GameCanvas.chatTabScr.wCon - 12);
			MainTextChat[] array2 = base.addChatNew(array, 0);
			bool flag2 = array2 != null;
			if (flag2)
			{
				for (int i = 0; i < array2.Length; i++)
				{
					bool flag3 = i == 0;
					if (flag3)
					{
						bool flag4 = typeBg != 2;
						if (flag4)
						{
							array2[0].textRight = textRight;
							bool flag5 = typeBg == 1;
							if (flag5)
							{
								array2[0].typeLeftRight = 1;
							}
							else
							{
								bool flag6 = typeBg == 0;
								if (flag6)
								{
									array2[0].typeLeftRight = 2;
								}
							}
						}
						array2[0].lenghtText = (sbyte)(array2.Length + 1);
						array2[0].typeBg = typeBg;
						array2[0].typeEvent = IDEvent;
						array2[0].nameText = nametext;
						array2[0].IDMem = IdMem;
						bool flag7 = array2[0].text.CompareTo(GameScreen.player.name) == 0;
						if (flag7)
						{
							array2[0].text = T.ban;
							array2[0].color = 4;
						}
					}
					array2[i].IdText = ID;
					this.vecDetail.addElement(array2[i]);
				}
				MainTextChat mainTextChat = new MainTextChat(string.Empty, 0);
				mainTextChat.timeBegin = time;
				mainTextChat.setTimePaint();
				mainTextChat.IdText = ID;
				this.vecDetail.addElement(mainTextChat);
			}
			base.setLim();
			bool flag8 = this.limY > 0;
			if (flag8)
			{
				this.updateCameraNew(array.Length, 1);
			}
		}
	}

	// Token: 0x06000E91 RID: 3729 RVA: 0x00017984 File Offset: 0x00015B84
	public void addOneChat(short IDChat, short IDMem, string name, string str, sbyte typeAction, long time)
	{
		InfoMemList memInCLan = Clan_Screen.getMemInCLan(name);
		string textRight = string.Empty;
		bool flag = memInCLan != null;
		if (flag)
		{
			textRight = memInCLan.getCaptionClan(memInCLan.chucInClan);
		}
		bool flag2 = typeAction == -1;
		if (flag2)
		{
			bool flag3 = IDMem == GameScreen.player.ID;
			if (flag3)
			{
				this.addStringClan(IDChat, str, name, textRight, 1, -1, IDMem, time);
			}
			else
			{
				this.addStringClan(IDChat, str, name, textRight, 0, -1, IDMem, time);
			}
		}
		else
		{
			bool flag4 = typeAction == 1;
			if (flag4)
			{
				this.addStringClan(IDChat, str, name, string.Empty, 3, 1, IDMem, time);
			}
			else
			{
				bool flag5 = typeAction == -2;
				if (flag5)
				{
					this.addStringClan(IDChat, str, name, string.Empty, 2, -1, IDMem, time);
				}
				else
				{
					bool flag6 = typeAction == -3;
					if (flag6)
					{
						this.addStringClan(IDChat, str, T.thongbaobang, name, 3, -1, IDMem, time);
					}
					else
					{
						bool flag7 = typeAction == -4;
						if (flag7)
						{
							this.addStringClan(IDChat, str, name, textRight, 5, -1, IDMem, time);
						}
					}
				}
			}
		}
	}

	// Token: 0x06000E92 RID: 3730 RVA: 0x00017A90 File Offset: 0x00015C90
	public void RemoveChat(short id)
	{
		bool flag = false;
		for (int i = 0; i < this.vecDetail.size(); i++)
		{
			MainTextChat mainTextChat = (MainTextChat)this.vecDetail.elementAt(i);
			bool flag2 = mainTextChat.IdText == id;
			if (flag2)
			{
				this.vecDetail.removeElementAt(i);
				i--;
				flag = true;
			}
			else
			{
				bool flag3 = flag;
				if (flag3)
				{
					break;
				}
			}
		}
		int num = this.hCon;
		bool flag4 = this.tfchat != null;
		if (flag4)
		{
			num -= this.tfchat.height;
		}
		this.limY = this.vecDetail.size() * GameCanvas.hText - num;
		bool flag5 = this.limY > 0 && this.limY != this.CamDetailChat.cmxLim;
		if (flag5)
		{
			this.CamDetailChat.cmxLim = this.limY;
		}
	}

	// Token: 0x06000E93 RID: 3731 RVA: 0x001185B4 File Offset: 0x001167B4
	public void checkRemoveChat()
	{
		int num = 0;
		for (int i = this.vecDetail.size(); i >= 0; i--)
		{
			MainTextChat mainTextChat = (MainTextChat)this.vecDetail.elementAt(i);
			bool flag = mainTextChat != null;
			if (flag)
			{
				bool flag2 = num > 30;
				if (flag2)
				{
					this.vecDetail.removeElementAt(i);
				}
				else
				{
					bool flag3 = mainTextChat.lenghtText > 0;
					if (flag3)
					{
						num++;
					}
				}
			}
			else
			{
				this.vecDetail.removeElementAt(i);
			}
		}
		bool flag4 = num > 30;
		if (flag4)
		{
			base.setLim();
			bool flag5 = this.limY > 0;
			if (flag5)
			{
				this.updateCameraNew(0, 0);
			}
			this.setXCam();
		}
	}

	// Token: 0x06000E94 RID: 3732 RVA: 0x00118678 File Offset: 0x00116878
	public new void sendChat()
	{
		bool flag = this.tfchat != null && this.tfchat.getText().Length > 0 && this.typeChat == 3;
		if (flag)
		{
			GlobalService.gI().Sudo_CMD(15, this.tfchat.getText(), 0, 0);
			this.tfchat.setText(string.Empty);
		}
	}

	// Token: 0x04001653 RID: 5715
	public const sbyte EVENT_CHAT = -1;

	// Token: 0x04001654 RID: 5716
	public const sbyte EVENT_XIN_VAO_CLAN = 1;

	// Token: 0x04001655 RID: 5717
	public const sbyte EVENT_MAU_DO = -2;

	// Token: 0x04001656 RID: 5718
	public const sbyte EVENT_THONG_BAO = -3;

	// Token: 0x04001657 RID: 5719
	public const sbyte EVENT_DONATE = -4;

	// Token: 0x04001658 RID: 5720
	private iCommand cmdView;

	// Token: 0x04001659 RID: 5721
	private iCommand cmdChoVaoClan;

	// Token: 0x0400165A RID: 5722
	private iCommand cmdTuChoiVaoClan;

	// Token: 0x0400165B RID: 5723
	private iCommand cmdChat;

	// Token: 0x0400165C RID: 5724
	private InfoMemList memCur;

	// Token: 0x0400165D RID: 5725
	private MainTextChat chatCur;

	// Token: 0x0400165E RID: 5726
	private int minChat;

	// Token: 0x0400165F RID: 5727
	private int maxChat;
}
