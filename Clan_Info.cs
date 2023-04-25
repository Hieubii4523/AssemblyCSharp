using System;

// Token: 0x02000017 RID: 23
public class Clan_Info : ChatDetail
{
	// Token: 0x060000E0 RID: 224 RVA: 0x000093F6 File Offset: 0x000075F6
	public Clan_Info(string name, sbyte type, MainClan clan) : base(name, type)
	{
		this.clan = clan;
	}

	// Token: 0x060000E1 RID: 225 RVA: 0x000181F4 File Offset: 0x000163F4
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

	// Token: 0x060000E2 RID: 226 RVA: 0x000182CC File Offset: 0x000164CC
	public override void setPos(int xBe, int yBe, int wCon, int hCon, int miniItem, int hchat)
	{
		this.xBe = xBe;
		this.yBe = yBe;
		this.wCon = wCon;
		this.hCon = hCon;
		this.miniItem = miniItem;
		this.hChat = hchat;
		this.wItem = GameCanvas.hText + 4;
		Clan_Info.fontpaint = mFont.tahoma_7_white;
		Clan_Info.fontInfo = mFont.tahoma_7b_white;
		this.posValueName = new int[T.mNameClan.Length];
		for (int i = 0; i < T.mNameClan.Length; i++)
		{
			this.posValueName[i] = Clan_Info.fontpaint.getWidth(T.mNameClan[i]);
		}
		this.strInfo = null;
		bool flag = this.clan != null;
		if (flag)
		{
			this.getmStrInfo(this.clan.strVoice, wCon - 6);
		}
		int num = T.mNameClan.Length + 3 + T.mAttribute.Length;
		this.hplus = 2;
		bool flag2 = this.strInfo != null;
		if (flag2)
		{
			this.hplus = this.strInfo.Length;
		}
		bool flag3 = this.hplus < 2;
		if (flag3)
		{
			this.hplus = 2;
		}
		num += this.hplus;
		this.CamDetailChat = new ListNew(xBe, yBe, wCon, hCon, this.wItem, 0, num * this.wItem + 5 - hCon, true);
		this.idSelect = 0;
		this.cmdAttri = new iCommand(T.congDiem, 1, this);
		this.cmdStatus = new iCommand(T.thongbao, 2, this);
		this.cmdLevelUp = new iCommand(T.levelUp, 3, this);
	}

	// Token: 0x060000E3 RID: 227 RVA: 0x00009427 File Offset: 0x00007627
	public void getmStrInfo(string str, int w)
	{
		this.strInfo = Clan_Info.fontInfo.splitFontArray(str, w);
	}

	// Token: 0x060000E4 RID: 228 RVA: 0x00018454 File Offset: 0x00016654
	public override void paint(mGraphics g)
	{
		g.setClip(this.xBe - this.miniItem, this.yBe - 2, this.wCon + this.miniItem * 2, this.hCon + 2);
		g.saveCanvas();
		g.ClipRec(this.xBe - this.miniItem, this.yBe - 2, this.wCon + this.miniItem * 2, this.hCon + 2);
		g.translate(0, -this.CamDetailChat.cmx);
		int num = this.yBe;
		int num2 = this.xBe + 2;
		base.paintBorder(g, 3, -1, 0, this.wItem * 4, num, this.idSelect == 0);
		g.drawRegion(AvMain.imgBannerClan, 0, 0, 51, 20, 0, (float)(this.xBe + this.wCon / 2 - 51), (float)(num + 1), 0);
		g.drawRegion(AvMain.imgBannerClan, 0, 0, 51, 20, 2, (float)(this.xBe + this.wCon / 2), (float)(num + 1), 0);
		mFont.tahoma_7b_black.drawString(g, T.tabInfo, num2 + this.wCon / 2, num + 3, 2);
		num += this.wItem + 2;
		for (int i = 0; i < 3; i++)
		{
			Clan_Info.fontpaint.drawString(g, T.mNameClan[i], num2, num, 0);
			switch (i)
			{
			case 0:
				Clan_Info.fontInfo.drawString(g, this.clan.name, num2 + this.posValueName[i], num, 0);
				break;
			case 1:
				Clan_Info.fontInfo.drawString(g, this.clan.nameCaption, num2 + this.posValueName[i], num, 0);
				break;
			case 2:
			{
				MainImage iconClanBig = Potion.getIconClanBig(this.clan.idIcon);
				bool flag = iconClanBig == null || iconClanBig.img == null;
				if (!flag)
				{
					bool flag2 = iconClanBig.frame == -1;
					if (flag2)
					{
						iconClanBig.set_Frame();
					}
					bool flag3 = iconClanBig.frame <= 1;
					if (flag3)
					{
						g.drawImage(iconClanBig.img, num2 + this.posValueName[i] + 11, num + 4, 3);
					}
					else
					{
						int num3 = (this.framepaint < (int)(iconClanBig.frame - 1)) ? 3 : 15;
						bool flag4 = CRes.abs(GameCanvas.gameTick - this.lastTick) > num3;
						if (flag4)
						{
							this.framepaint++;
							bool flag5 = this.framepaint >= (int)iconClanBig.frame;
							if (flag5)
							{
								this.framepaint = 0;
							}
							this.lastTick = GameCanvas.gameTick;
						}
						g.drawRegion(iconClanBig.img, 0, this.framepaint * (int)iconClanBig.w, (int)iconClanBig.w, (int)iconClanBig.w, 0, (float)(num2 + this.posValueName[i] + 11), (float)(num + 4), 3);
					}
				}
				break;
			}
			}
			num += this.wItem;
		}
		base.paintBorder(g, 0, -1, 0, this.wItem * 5, num, this.idSelect == 1);
		g.drawRegion(AvMain.imgBannerClan, 0, 20, 51, 20, 0, (float)(this.xBe + this.wCon / 2 - 51), (float)(num + 1), 0);
		g.drawRegion(AvMain.imgBannerClan, 0, 20, 51, 20, 2, (float)(this.xBe + this.wCon / 2), (float)(num + 1), 0);
		mFont.tahoma_7b_black.drawString(g, T.chiso, num2 + this.wCon / 2, num + 3, 2);
		num += this.wItem + 2;
		bool flag6 = this.clan.isLevelUp > 0 && Player.ChucInCLan == 0;
		if (flag6)
		{
			bool flag7 = AvMain.fraClanLevelUp == null;
			if (flag7)
			{
				AvMain.fraClanLevelUp = LoadImageStatic.loadFraImage("/interface/clanlevelup.png", 12, 12);
			}
			AvMain.fraClanLevelUp.drawFrame(GameCanvas.gameTick / 3 % AvMain.fraClanLevelUp.nFrame, num2 + this.wCon / 5 * 2 - 8, num + 5, 0, 3, g);
		}
		for (int j = 3; j < 7; j++)
		{
			Clan_Info.fontpaint.drawString(g, T.mNameClan[j], num2, num, 0);
			switch (j)
			{
			case 3:
			{
				bool flag8 = this.clan.isLevelUp == 2 && Player.ChucInCLan == 0;
				if (flag8)
				{
					Clan_Info.fontInfo.drawString(g, T.trungsinh, num2 + this.wCon / 5 * 2, num, 0);
				}
				else
				{
					Clan_Info.fontpaint.drawString(g, T.kinhnghiem, num2 + this.wCon / 5 * 2, num, 0);
					int width = Clan_Info.fontpaint.getWidth(T.kinhnghiem);
					Clan_Info.fontInfo.drawString(g, this.clan.xp.ToString() + "/" + this.clan.maxXp.ToString(), num2 + this.wCon / 5 * 2 + width, num, 0);
				}
				Clan_Info.fontInfo.drawString(g, string.Empty + this.clan.level.ToString(), num2 + this.posValueName[j], num, 0);
				break;
			}
			case 4:
			{
				Clan_Info.fontInfo.drawString(g, this.clan.numMem.ToString() + "/" + this.clan.maxNumMem.ToString(), num2 + this.posValueName[j], num, 0);
				Clan_Info.fontpaint.drawString(g, T.hoatdong, num2 + this.wCon / 5 * 2, num, 0);
				int width2 = Clan_Info.fontpaint.getWidth(T.hoatdong);
				Clan_Info.fontInfo.drawString(g, this.clan.countAction.ToString() + string.Empty, num2 + this.wCon / 5 * 2 + width2, num, 0);
				break;
			}
			case 5:
			{
				Clan_Info.fontpaint.drawString(g, T.captrungsinh, num2 + this.wCon / 5 * 2, num, 0);
				int width3 = Clan_Info.fontpaint.getWidth(T.captrungsinh);
				Clan_Info.fontInfo.drawString(g, this.clan.trungsinh.ToString() + string.Empty, num2 + this.wCon / 5 * 2 + width3, num, 0);
				Clan_Info.fontInfo.drawString(g, string.Empty + this.clan.rank.ToString(), num2 + this.posValueName[j], num, 0);
				break;
			}
			case 6:
			{
				Clan_Info.fontInfo.drawString(g, this.clan.rubiClan.ToString() + string.Empty, num2 + this.posValueName[j], num, 0);
				Clan_Info.fontpaint.drawString(g, T.bery + ": ", num2 + this.wCon / 5 * 2, num, 0);
				int width4 = Clan_Info.fontpaint.getWidth(T.bery + ": ");
				Clan_Info.fontInfo.drawString(g, this.clan.beryClan.ToString() + string.Empty, num2 + this.wCon / 5 * 2 + width4, num, 0);
				break;
			}
			}
			num += this.wItem;
		}
		base.paintBorder(g, 0, -1, 0, this.wItem * (T.mAttribute.Length + 1), num, this.idSelect == 2);
		g.drawRegion(AvMain.imgBannerClan, 0, 20, 51, 20, 0, (float)(this.xBe + this.wCon / 2 - 51), (float)(num + 1), 0);
		g.drawRegion(AvMain.imgBannerClan, 0, 20, 51, 20, 2, (float)(this.xBe + this.wCon / 2), (float)(num + 1), 0);
		mFont.tahoma_7b_black.drawString(g, T.tabAttribute, num2 + this.wCon / 2, num + 3, 2);
		int num4 = 0;
		bool flag9 = this.clan.pointAttri > 0;
		if (flag9)
		{
			mFont.tahoma_7_yellow.drawString(g, "+" + this.clan.pointAttri.ToString(), num2 + this.wCon - 2, num + 3, 1);
			num4 = 1;
		}
		num += this.wItem + 2;
		for (int k = 0; k < T.mAttribute.Length; k++)
		{
			Clan_Info.fontpaint.drawString(g, T.mAttribute[k], num2 + 55, num, 1);
			Interface_Game.PaintHPMP(g, 103, (int)this.clan.numAttribute[k], this.clan.maxAttri, num2 + 59, num + 1, 0, 10, this.wCon - 80, 0, false, 0, false, 0);
			bool flag10 = Player.ChucInCLan == 0;
			if (flag10)
			{
				g.drawRegion(AvMain.imgPlusClan, 0, num4 * 12, 12, 12, 0, (float)(num2 + this.wCon - 10), (float)(num + 6), 3);
				bool flag11 = this.idSelect == 2 && GameCanvas.gameTick % 10 > 6 && k == this.indexFocusAtt;
				if (flag11)
				{
					g.drawRegion(AvMain.imgPlusClan, 0, 0, 12, 12, 0, (float)(num2 + this.wCon - 10), (float)(num + 6), 3);
				}
			}
			num += this.wItem;
		}
		base.paintBorder(g, 1, -1, 0, this.wItem * (this.hplus + 1), num, this.idSelect == 3);
		g.drawRegion(AvMain.imgBannerClan, 0, 40, 51, 20, 0, (float)(this.xBe + this.wCon / 2 - 51), (float)(num + 1), 0);
		g.drawRegion(AvMain.imgBannerClan, 0, 40, 51, 20, 2, (float)(this.xBe + this.wCon / 2), (float)(num + 1), 0);
		mFont.tahoma_7b_black.drawString(g, T.mNameClan[7], num2 + this.wCon / 2, num + 3, 2);
		num += this.wItem + 3;
		bool flag12 = this.strInfo != null;
		if (flag12)
		{
			for (int l = 0; l < this.strInfo.Length; l++)
			{
				Clan_Info.fontInfo.drawString(g, this.strInfo[l], num2 + 2, num, 0);
				num += this.wItem;
			}
		}
		mGraphics.resetTransAndroid(g);
		g.restoreCanvas();
		base.paint(g);
	}

	// Token: 0x060000E5 RID: 229 RVA: 0x0000943C File Offset: 0x0000763C
	public override void update()
	{
		this.CamDetailChat.moveCamera();
	}

	// Token: 0x060000E6 RID: 230 RVA: 0x00018ED8 File Offset: 0x000170D8
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

	// Token: 0x060000E7 RID: 231 RVA: 0x000190D4 File Offset: 0x000172D4
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

	// Token: 0x060000E8 RID: 232 RVA: 0x0001926C File Offset: 0x0001746C
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

	// Token: 0x060000E9 RID: 233 RVA: 0x00019320 File Offset: 0x00017520
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

	// Token: 0x04000178 RID: 376
	private int[] posValueName;

	// Token: 0x04000179 RID: 377
	private static mFont fontpaint;

	// Token: 0x0400017A RID: 378
	private static mFont fontInfo;

	// Token: 0x0400017B RID: 379
	public MainClan clan;

	// Token: 0x0400017C RID: 380
	public string[] strInfo;

	// Token: 0x0400017D RID: 381
	public iCommand cmdStatus;

	// Token: 0x0400017E RID: 382
	public iCommand cmdAttri;

	// Token: 0x0400017F RID: 383
	public iCommand cmdLevelUp;

	// Token: 0x04000180 RID: 384
	private int indexFocusAtt;

	// Token: 0x04000181 RID: 385
	private InputDialog input;

	// Token: 0x04000182 RID: 386
	private int hplus = 2;

	// Token: 0x04000183 RID: 387
	private int lastTick;

	// Token: 0x04000184 RID: 388
	private int framepaint;

	// Token: 0x04000185 RID: 389
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
