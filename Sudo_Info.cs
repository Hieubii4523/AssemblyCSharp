using System;

// Token: 0x020000F8 RID: 248
public class Sudo_Info : ChatDetail
{
	// Token: 0x06000E95 RID: 3733 RVA: 0x0000BFA4 File Offset: 0x0000A1A4
	public Sudo_Info(string name, sbyte type, MainSudo clan) : base(name, type)
	{
		this.clan = clan;
		Sudo_Info.instance = this;
	}

	// Token: 0x06000E96 RID: 3734 RVA: 0x001186E0 File Offset: 0x001168E0
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 1:
			GlobalService.gI().Clan_CMD(6, string.Empty, 1, (sbyte)this.indexFocusAtt);
			break;
		case 2:
			this.input = new InputDialog();
			this.input.setinfo(T.nhapcauthongbao, new iCommand(T.thongbao, 4, this), false, T.thongbaobang);
			GameCanvas.Start_Current_Dialog(this.input);
			break;
		case 3:
			GlobalService.gI().Clan_CMD(13, string.Empty, 0, 0);
			break;
		case 4:
		{
			string text = this.input.tfInput.getText();
			bool flag = text.Length > 0;
			if (flag)
			{
				GlobalService.gI().Clan_CMD(5, text, 0, 0);
			}
			GameCanvas.end_Dialog();
			break;
		}
		}
	}

	// Token: 0x06000E97 RID: 3735 RVA: 0x001187B8 File Offset: 0x001169B8
	public override void setPos(int xBe, int yBe, int wCon, int hCon, int miniItem, int hchat)
	{
		this.xBe = xBe;
		this.yBe = yBe;
		this.wCon = wCon;
		this.hCon = hCon;
		this.miniItem = miniItem;
		this.hChat = hchat;
		this.wItem = GameCanvas.hText + 4;
		Sudo_Info.fontpaint = mFont.tahoma_7_white;
		Sudo_Info.fontInfo = mFont.tahoma_7b_white;
		this.posValueName = new int[T.mNameClan.Length];
		for (int i = 0; i < T.mNameClan.Length; i++)
		{
			this.posValueName[i] = Sudo_Info.fontpaint.getWidth(T.mNameClan[i]);
		}
		this.strInfo = null;
		this.setHplus();
		this.idSelect = 0;
		this.cmdAttri = new iCommand(T.congDiem, 1, this);
		this.cmdStatus = new iCommand(T.thongbao, 2, this);
		this.cmdLevelUp = new iCommand(T.levelUp, 3, this);
	}

	// Token: 0x06000E98 RID: 3736 RVA: 0x001188A4 File Offset: 0x00116AA4
	public void setHplus()
	{
		int num = T.mNameClan.Length + 3 + T.mAttribute.Length;
		this.hplus = 2;
		bool flag = this.strInfo != null;
		if (flag)
		{
			this.hplus = Sudo_Info.vecInfoCanhan.size() - 3;
		}
		bool flag2 = this.hplus < 2;
		if (flag2)
		{
			this.hplus = 2;
		}
		num += this.hplus - 1;
		this.CamDetailChat = new ListNew(this.xBe, this.yBe, this.wCon, this.hCon, this.wItem, 0, num * this.wItem + 5 - this.hCon, true);
	}

	// Token: 0x06000E99 RID: 3737 RVA: 0x0000BFDB File Offset: 0x0000A1DB
	public void getmStrInfo(string str, int w)
	{
		this.strInfo = Sudo_Info.fontInfo.splitFontArray(str, w);
	}

	// Token: 0x06000E9A RID: 3738 RVA: 0x0011894C File Offset: 0x00116B4C
	public override void paint(mGraphics g)
	{
		g.setClip(this.xBe - this.miniItem, this.yBe - 2, this.wCon + this.miniItem * 2, this.hCon + 2);
		g.saveCanvas();
		g.ClipRec(this.xBe - this.miniItem, this.yBe - 2, this.wCon + this.miniItem * 2, this.hCon + 2);
		g.translate(0, -this.CamDetailChat.cmx);
		int num = this.yBe;
		int num2 = this.xBe + 2;
		base.paintBorder(g, 3, -1, 0, this.wItem * 6, num, this.idSelect == 0);
		g.drawRegion(AvMain.imgBannerClan, 0, 0, 51, 20, 0, (float)(this.xBe + this.wCon / 2 - 51), (float)(num + 1), 0);
		g.drawRegion(AvMain.imgBannerClan, 0, 0, 51, 20, 2, (float)(this.xBe + this.wCon / 2), (float)(num + 1), 0);
		mFont.tahoma_7b_black.drawString(g, T.player, num2 + this.wCon / 2, num + 3, 2);
		num += this.wItem + 2;
		AvMain.paintRect(g, num2 + this.wCon / 2 - 30, num, 60, 66, 0, 4);
		GameScreen.player.paintCharShow(g, num2 + this.wCon / 2, num + 40 + GameScreen.player.hOne / 4 + 5, 0, true);
		mFont.tahoma_7b_black.drawString(g, GameScreen.player.name, num2 + this.wCon / 2, num + 72, 2);
		num += this.wItem * 5;
		base.paintBorder(g, 0, -1, 0, this.wItem * 5, num, this.idSelect == 1);
		g.drawRegion(AvMain.imgBannerClan, 0, 20, 51, 20, 0, (float)(this.xBe + this.wCon / 2 - 51), (float)(num + 1), 0);
		g.drawRegion(AvMain.imgBannerClan, 0, 20, 51, 20, 2, (float)(this.xBe + this.wCon / 2), (float)(num + 1), 0);
		mFont.tahoma_7b_black.drawString(g, T.tabInfo, num2 + this.wCon / 2, num + 3, 2);
		num += this.wItem + 2;
		bool flag = Sudo_Info.vecInfoCanhan.size() > 0;
		if (flag)
		{
			for (int i = 0; i < 4; i++)
			{
				MainInfoItem mainInfoItem = (MainInfoItem)Sudo_Info.vecInfoCanhan.elementAt(i);
				switch (i)
				{
				case 0:
					mFont.tahoma_7b_yellow.drawString(g, mainInfoItem.name, num2 + 5, num, 0);
					break;
				case 1:
					mFont.tahoma_7_white.drawString(g, mainInfoItem.name, num2 + 5, num, 0);
					mFont.tahoma_7b_white.drawString(g, mainInfoItem.value.ToString() + string.Empty, num2 + 80, num, 0);
					break;
				case 2:
					mFont.tahoma_7_white.drawString(g, mainInfoItem.name, num2 + 5, num, 0);
					break;
				case 3:
					mFont.tahoma_7b_white.drawString(g, mainInfoItem.name, num2 + 5, num, 0);
					Interface_Game.PaintHPMP(g, 2, (int)this.exp, 100, this.xBe + this.wCon / 3, num, 0, this.miniItem * 2 + 2, this.wCon / 5 * 3, 1, false, 0, false, 0);
					break;
				}
				num += this.wItem;
			}
		}
		base.paintBorder(g, 1, -1, 0, this.wItem * (this.hplus * 2 + 1), num, this.idSelect == 3);
		g.drawRegion(AvMain.imgBannerClan, 0, 40, 51, 20, 0, (float)(this.xBe + this.wCon / 2 - 51), (float)(num + 1), 0);
		g.drawRegion(AvMain.imgBannerClan, 0, 40, 51, 20, 2, (float)(this.xBe + this.wCon / 2), (float)(num + 1), 0);
		mFont.tahoma_7b_black.drawString(g, T.chiso, num2 + this.wCon / 2, num + 3, 2);
		num += this.wItem + 2;
		bool flag2 = Sudo_Info.vecInfoCanhan.size() >= 4;
		if (flag2)
		{
			for (int j = 4; j < Sudo_Info.vecInfoCanhan.size(); j++)
			{
				MainInfoItem mainInfoItem2 = (MainInfoItem)Sudo_Info.vecInfoCanhan.elementAt(j);
				mFont.tahoma_7b_yellow.drawString(g, "- " + mainInfoItem2.name, num2 + 5, num, 0);
				num += this.wItem;
			}
		}
		mGraphics.resetTransAndroid(g);
		g.restoreCanvas();
		base.paint(g);
	}

	// Token: 0x06000E9B RID: 3739 RVA: 0x00118E04 File Offset: 0x00117004
	public void paintCaNhan(mGraphics g)
	{
		for (int i = 0; i < Sudo_Info.vecInfoCanhan.size(); i++)
		{
			MainInfoItem mainInfoItem = (MainInfoItem)Sudo_Info.vecInfoCanhan.elementAt(i);
			string text = mainInfoItem.name;
			bool flag = mainInfoItem.value != 0;
			if (flag)
			{
				text = text + " " + mainInfoItem.value.ToString();
			}
			mFont.tahoma_7_white.drawString(g, text, this.miniItem, this.miniItem + i * GameCanvas.hText, 0);
		}
	}

	// Token: 0x06000E9C RID: 3740 RVA: 0x0000943C File Offset: 0x0000763C
	public override void update()
	{
		this.CamDetailChat.moveCamera();
	}

	// Token: 0x06000E9D RID: 3741 RVA: 0x00118E90 File Offset: 0x00117090
	public override void updatePointer()
	{
		this.CamDetailChat.update_Pos_UP_DOWN();
		bool flag = !GameCanvas.isPointerSelect || !GameCanvas.isPoint(this.xBe, this.yBe, this.wCon, this.hCon);
		if (!flag)
		{
			int num = (T.mNameClan.Length + 1 + T.mAttribute.Length + 1) * this.wItem;
			bool flag2 = GameCanvas.isPointer(this.xBe, num - this.CamDetailChat.cmx + this.yBe, this.wCon, (this.hplus + 1) * this.wItem) && (Player.ChucInCLan == 0 || Player.ChucInCLan == 1);
			if (flag2)
			{
				this.cmdStatus.perform();
				GameCanvas.isPointerSelect = false;
			}
			num = 4 * this.wItem;
			bool flag3 = GameCanvas.isPointer(this.xBe, num - this.CamDetailChat.cmx + this.yBe, this.wCon, 5 * this.wItem) && Player.ChucInCLan == 0 && GameScreen.player.clan.isLevelUp > 0;
			if (flag3)
			{
				this.cmdLevelUp.perform();
				GameCanvas.isPointerSelect = false;
			}
			num = (T.mNameClan.Length + 2) * this.wItem;
			bool flag4 = GameCanvas.isPointer(this.xBe, num - this.CamDetailChat.cmx + this.yBe, this.wCon, T.mAttribute.Length * this.wItem) && GameScreen.player.clan.pointAttri > 0 && Player.ChucInCLan == 0;
			if (flag4)
			{
				int num2 = (GameCanvas.py - (num - this.CamDetailChat.cmx + this.yBe)) / this.wItem;
				bool flag5 = num2 >= 0 && num2 < T.mAttribute.Length;
				if (flag5)
				{
					GlobalService.gI().Clan_CMD(6, string.Empty, 1, (sbyte)num2);
				}
				GameCanvas.isPointerSelect = false;
			}
		}
	}

	// Token: 0x06000E9E RID: 3742 RVA: 0x0011908C File Offset: 0x0011728C
	public override void updatekey()
	{
		int idSelect = this.idSelect;
		bool flag = this.idSelect == 2 && Player.ChucInCLan == 0 && this.clan.pointAttri > 0;
		if (flag)
		{
			bool flag2 = GameCanvas.keyMyHold[2];
			if (flag2)
			{
				GameCanvas.clearKeyHold(2);
				bool flag3 = this.indexFocusAtt > 0;
				if (flag3)
				{
					this.indexFocusAtt--;
				}
				else
				{
					this.idSelect--;
					this.setXCam();
				}
			}
			else
			{
				bool flag4 = GameCanvas.keyMyHold[8];
				if (flag4)
				{
					GameCanvas.clearKeyHold(8);
					bool flag5 = this.indexFocusAtt < T.mAttribute.Length - 1;
					if (flag5)
					{
						this.indexFocusAtt++;
					}
					else
					{
						this.idSelect++;
						this.setXCam();
					}
				}
			}
		}
		else
		{
			bool flag6 = GameCanvas.keyMyHold[2];
			if (flag6)
			{
				GameCanvas.clearKeyHold(2);
				bool flag7 = this.idSelect > 0;
				if (flag7)
				{
					this.idSelect--;
				}
			}
			else
			{
				bool flag8 = GameCanvas.keyMyHold[8];
				if (flag8)
				{
					GameCanvas.clearKeyHold(8);
					bool flag9 = this.idSelect < 3;
					if (flag9)
					{
						this.idSelect++;
					}
				}
			}
			bool flag10 = idSelect != this.idSelect;
			if (flag10)
			{
				this.setXCam();
			}
		}
		bool flag11 = idSelect != this.idSelect;
		if (flag11)
		{
			this.center = null;
			this.setCmd();
		}
		base.updatekey();
	}

	// Token: 0x06000E9F RID: 3743 RVA: 0x00119224 File Offset: 0x00117424
	private void setCmd()
	{
		bool flag = this.idSelect == 2 && GameScreen.player.clan.pointAttri > 0 && Player.ChucInCLan == 0;
		if (flag)
		{
			this.center = this.cmdAttri;
		}
		else
		{
			bool flag2 = this.idSelect == 1 && GameScreen.player.clan.isLevelUp > 0 && Player.ChucInCLan == 0;
			if (flag2)
			{
				this.center = this.cmdLevelUp;
			}
			else
			{
				bool flag3 = this.idSelect == 3 && (Player.ChucInCLan == 0 || Player.ChucInCLan == 1);
				if (flag3)
				{
					this.center = this.cmdStatus;
				}
			}
		}
	}

	// Token: 0x06000EA0 RID: 3744 RVA: 0x001192D8 File Offset: 0x001174D8
	private void setXCam()
	{
		int toX = 0;
		bool flag = this.idSelect >= 0 && this.idSelect < this.hCam.Length;
		if (flag)
		{
			toX = this.hCam[this.idSelect] * this.wItem - this.hCon / 4;
		}
		bool flag2 = this.idSelect == 0;
		if (flag2)
		{
			toX = 0;
		}
		bool flag3 = this.idSelect == 3;
		if (flag3)
		{
			toX = this.CamDetailChat.cmxLim;
		}
		this.CamDetailChat.setToX(toX);
	}

	// Token: 0x04001660 RID: 5728
	public static Sudo_Info instance;

	// Token: 0x04001661 RID: 5729
	private int[] posValueName;

	// Token: 0x04001662 RID: 5730
	private static mFont fontpaint;

	// Token: 0x04001663 RID: 5731
	private static mFont fontInfo;

	// Token: 0x04001664 RID: 5732
	public MainSudo clan;

	// Token: 0x04001665 RID: 5733
	public string[] strInfo;

	// Token: 0x04001666 RID: 5734
	public iCommand cmdStatus;

	// Token: 0x04001667 RID: 5735
	public iCommand cmdAttri;

	// Token: 0x04001668 RID: 5736
	public iCommand cmdLevelUp;

	// Token: 0x04001669 RID: 5737
	private int indexFocusAtt;

	// Token: 0x0400166A RID: 5738
	private InputDialog input;

	// Token: 0x0400166B RID: 5739
	public short exp;

	// Token: 0x0400166C RID: 5740
	private int hplus = 2;

	// Token: 0x0400166D RID: 5741
	private int lastTick;

	// Token: 0x0400166E RID: 5742
	private int framepaint;

	// Token: 0x0400166F RID: 5743
	public static mVector vecInfoCanhan = new mVector();

	// Token: 0x04001670 RID: 5744
	private int[] hCam = new int[]
	{
		0,
		4,
		8,
		16,
		20,
		20
	};
}
