using System;

// Token: 0x02000016 RID: 22
public class Clan_Cup : ChatDetail
{
	// Token: 0x060000D5 RID: 213 RVA: 0x00009388 File Offset: 0x00007588
	public Clan_Cup(string name, sbyte type) : base(name, type)
	{
	}

	// Token: 0x060000D6 RID: 214 RVA: 0x00009394 File Offset: 0x00007594
	public override void setPos(int xBe, int yBe, int wCon, int hCon, int miniItem, int hchat)
	{
		this.xBe = xBe;
		this.yBe = yBe;
		this.wCon = wCon;
		this.hCon = hCon;
		this.miniItem = miniItem;
		this.hChat = hchat;
		this.updateCameraNew(0, 0);
	}

	// Token: 0x060000D7 RID: 215 RVA: 0x000093CD File Offset: 0x000075CD
	public override void beginFocus()
	{
		this.CamDetailChat.cmx = 0;
		this.CamDetailChat.cmtoX = 0;
		this.idSelect = 0;
		this.updateTime();
	}

	// Token: 0x060000D8 RID: 216 RVA: 0x00017C40 File Offset: 0x00015E40
	public override void paint(mGraphics g)
	{
		bool flag = this.tfchat != null;
		if (flag)
		{
			this.tfchat.paint(g);
		}
		g.setClip(this.xBe - this.miniItem, this.yBe - 2, this.wCon + this.miniItem * 2, this.hCon - ((this.tfchat == null) ? (-this.miniItem) : this.tfchat.height) + 2);
		g.saveCanvas();
		g.ClipRec(this.xBe - this.miniItem, this.yBe - 2, this.wCon + this.miniItem * 2, this.hCon - ((this.tfchat == null) ? (-this.miniItem) : this.tfchat.height) + 2);
		g.translate(0, -this.CamDetailChat.cmx);
		this.minChat = this.CamDetailChat.cmx / GameCanvas.hText - 8;
		bool flag2 = this.minChat < 0;
		if (flag2)
		{
			this.minChat = 0;
		}
		this.maxChat = this.minChat + this.hChat + 10;
		for (int i = this.minChat; i <= this.maxChat; i++)
		{
			bool flag3 = i < this.vecDetail.size() && i >= 0;
			if (flag3)
			{
				MainTextChat mainTextChat = (MainTextChat)this.vecDetail.elementAt(i);
				bool flag4 = mainTextChat.lenghtText > 0;
				if (flag4)
				{
					base.paintBorder(g, mainTextChat.typeBg, -1, 0, (int)mainTextChat.lenghtText * GameCanvas.hText - 3, this.yBe + i * GameCanvas.hText, false);
					AvMain.FontBorderColor(g, mainTextChat.text, this.xBe + this.miniItem + 2, this.yBe + i * GameCanvas.hText + 1, 0, (int)mainTextChat.color, 7);
				}
				else
				{
					bool flag5 = mainTextChat.timeBegin > -1L;
					if (flag5)
					{
						mFont.tahoma_7_black.drawString(g, mainTextChat.textTime, this.xBe - this.miniItem + this.wCon, this.yBe + i * GameCanvas.hText - 2, 1);
					}
					else
					{
						mFont.tahoma_7b_black.drawString(g, mainTextChat.text, this.xBe + this.miniItem + 2, this.yBe + i * GameCanvas.hText, 0);
					}
				}
				bool flag6 = mainTextChat.textRight.Length > 0;
				if (flag6)
				{
					mFont.tahoma_7_white.drawString(g, mainTextChat.textRight, this.xBe + this.wCon - this.miniItem, this.yBe + i * GameCanvas.hText + 1, 1);
				}
			}
		}
		mGraphics.resetTransAndroid(g);
		g.restoreCanvas();
	}

	// Token: 0x060000D9 RID: 217 RVA: 0x00017F20 File Offset: 0x00016120
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
		}
	}

	// Token: 0x060000DA RID: 218 RVA: 0x00017300 File Offset: 0x00015500
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

	// Token: 0x060000DB RID: 219 RVA: 0x00017F70 File Offset: 0x00016170
	public override void updatePointer()
	{
		this.CamDetailChat.update_Pos_UP_DOWN();
		bool flag = this.tfchat != null;
		if (flag)
		{
			this.tfchat.updatePointer();
		}
	}

	// Token: 0x060000DC RID: 220 RVA: 0x00017FA8 File Offset: 0x000161A8
	public void addOneChat(short IDChat, short IDMem, string name, string str, sbyte typeAction, long time)
	{
		InfoMemList memInCLan = Clan_Screen.getMemInCLan(name);
		string textRight = string.Empty;
		bool flag = memInCLan != null;
		if (flag)
		{
			textRight = memInCLan.getCaptionClan(memInCLan.chucInClan);
		}
		this.addStringClan(IDChat, str, name, textRight, 9, -1, IDMem, time);
	}

	// Token: 0x060000DD RID: 221 RVA: 0x00017FEC File Offset: 0x000161EC
	public override void addStringClan(short ID, string str, string nametext, string textRight, sbyte typeBg, sbyte IDEvent, short IdMem, long time)
	{
		bool flag = str.Length <= 0;
		if (!flag)
		{
			string src = string.Empty;
			src = nametext + "\n" + str;
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
						array2[0].lenghtText = (sbyte)(array2.Length + 1);
						array2[0].typeBg = typeBg;
					}
					this.vecDetail.addElement(array2[i]);
				}
				MainTextChat mainTextChat = new MainTextChat(string.Empty, 0);
				mainTextChat.timeBegin = time;
				mainTextChat.setTimePaint();
				this.vecDetail.addElement(mainTextChat);
			}
			base.setLim();
			bool flag4 = this.limY > 0;
			if (flag4)
			{
				this.updateCameraNew(array.Length, 1);
			}
		}
	}

	// Token: 0x060000DE RID: 222 RVA: 0x000180F0 File Offset: 0x000162F0
	public override void updatekey()
	{
		int idSelect = this.idSelect;
		bool flag = GameCanvas.keyMyHold[2];
		if (flag)
		{
			GameCanvas.clearKeyHold(2);
			bool flag2 = this.idSelect > 0;
			if (flag2)
			{
				this.idSelect--;
			}
		}
		else
		{
			bool flag3 = GameCanvas.keyMyHold[8];
			if (flag3)
			{
				GameCanvas.clearKeyHold(8);
				bool flag4 = this.idSelect < this.vecDetail.size() - 1;
				if (flag4)
				{
					this.idSelect++;
				}
			}
		}
		bool flag5 = idSelect != this.idSelect;
		if (flag5)
		{
			this.setXCam();
		}
		base.updatekey();
	}

	// Token: 0x060000DF RID: 223 RVA: 0x0001819C File Offset: 0x0001639C
	private void setXCam()
	{
		int num = this.idSelect * GameCanvas.hText;
		bool flag = num > this.CamDetailChat.cmxLim;
		if (flag)
		{
			this.idSelect = this.CamDetailChat.cmxLim / GameCanvas.hText + 1;
		}
		this.CamDetailChat.setToX(num);
	}

	// Token: 0x04000176 RID: 374
	private int minChat;

	// Token: 0x04000177 RID: 375
	private int maxChat;
}
