using System;

// Token: 0x02000018 RID: 24
public class Clan_Mem : ChatDetail
{
	// Token: 0x060000EA RID: 234 RVA: 0x00009388 File Offset: 0x00007588
	public Clan_Mem(string name, sbyte type) : base(name, type)
	{
	}

	// Token: 0x060000EB RID: 235 RVA: 0x000193AC File Offset: 0x000175AC
	public override void setPos(int xBe, int yBe, int wCon, int hCon, int miniItem, int hchat)
	{
		this.xBe = xBe;
		this.yBe = yBe;
		this.wCon = wCon;
		this.hCon = hCon;
		this.miniItem = miniItem;
		this.hChat = hchat;
		this.wItem = 30;
		this.CamDetailChat = new ListNew(xBe, yBe, wCon, hCon, this.wItem, 0, this.vecDetail.size() * this.wItem - hCon, true);
		this.cmdView = new iCommand(T.view, 0, this);
		this.cmdUpdate = new iCommand(T.update, 1, this);
		bool flag = !GameCanvas.isTouch;
		if (flag)
		{
			this.center = this.cmdView;
			this.left = this.cmdUpdate;
		}
		this.okCMD = this.cmdView;
	}

	// Token: 0x060000EC RID: 236 RVA: 0x0000944B File Offset: 0x0000764B
	public override void beginFocus()
	{
		Clan_Mem.tickupdate = 0;
	}

	// Token: 0x060000ED RID: 237 RVA: 0x00019474 File Offset: 0x00017674
	public override void commandPointer(int index, int subIndex)
	{
		if (index != 0)
		{
			if (index == 1)
			{
				GlobalService.gI().Clan_CMD(17, string.Empty, 0, 0);
				Clan_Mem.tickupdate = 40;
			}
		}
		else
		{
			this.doMenuTouchPlayer();
		}
	}

	// Token: 0x060000EE RID: 238 RVA: 0x000194B8 File Offset: 0x000176B8
	public void setDataCam()
	{
		bool flag = this.CamDetailChat == null;
		if (flag)
		{
			this.CamDetailChat = new ListNew(this.xBe, this.yBe, this.wCon, this.hCon, this.wItem, 0, this.vecDetail.size() * this.wItem - this.hCon, true);
		}
		else
		{
			this.CamDetailChat.cmxLim = this.vecDetail.size() * this.wItem - this.hCon;
			bool flag2 = this.CamDetailChat.cmxLim < 0;
			if (flag2)
			{
				this.CamDetailChat.cmxLim = 0;
			}
		}
	}

	// Token: 0x060000EF RID: 239 RVA: 0x00019560 File Offset: 0x00017760
	public override void paint(mGraphics g)
	{
		g.setClip(this.xBe - this.miniItem, this.yBe - 2, this.wCon + this.miniItem * 2, this.hCon + 2);
		g.saveCanvas();
		g.ClipRec(this.xBe - this.miniItem, this.yBe - 2, this.wCon + this.miniItem * 2, this.hCon + 2);
		g.translate(0, -this.CamDetailChat.cmx);
		this.minChat = 0;
		this.maxChat = 0;
		bool flag = this.vecDetail != null;
		if (flag)
		{
			this.maxChat = this.vecDetail.size();
		}
		bool flag2 = Clan_Mem.tickupdate > 0;
		if (flag2)
		{
			MsgDialog.fraImgWaiting.drawFrame(GameCanvas.gameTick / 6 % MsgDialog.fraImgWaiting.nFrame, this.xBe + this.wCon / 2, this.yBe + this.hCon / 2, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
		}
		else
		{
			for (int i = this.minChat; i <= this.maxChat; i++)
			{
				bool flag3 = i < this.vecDetail.size() && i >= 0;
				if (flag3)
				{
					InfoMemList infoMemList = (InfoMemList)this.vecDetail.elementAt(i);
					int num = this.yBe + i * this.wItem;
					sbyte b = (infoMemList.name.CompareTo(GameScreen.player.name) != 0) ? 4 : 5;
					base.paintBorder(g, b, -1, 0, this.wItem - 2, num, i == this.idSelect);
					int num2 = this.xBe - 2;
					int num3 = this.wCon + 4;
					g.drawImage(AvMain.imgDonateClan, num2 + num3 - 47, num - 1 + 2, 0);
					g.setColor(base.getColorBorderNumber(b));
					g.fillRect(num2 + num3 - 51, num - 1 + 17, 22, 9);
					g.drawImage(AvMain.imgLvClan, num2 + num3 - 28, num - 1 + 1, 0);
					AvMain.FontBorderColor(g, infoMemList.name, this.xBe + this.miniItem * 2 + 16, num + this.miniItem / 2, 0, 0, 7);
					mFont.tahoma_7b_black.drawString(g, infoMemList.getCaptionClan(infoMemList.chucInClan), this.xBe + this.miniItem * 2 + 16 + 6, num + GameCanvas.hText - 1, 0);
					mFont.tahoma_7_white.drawString(g, infoMemList.numTangqua.ToString() + string.Empty, this.xBe - 2 + this.wCon + 4 - 40, num + 15, 2);
					mFont.tahoma_7b_white.drawString(g, infoMemList.Lv.ToString() + string.Empty, this.xBe - 2 + this.wCon + 4 - 15, num + 7, 2);
					MainObject.paintHeadEveryWhere(g, infoMemList.head, infoMemList.hair, infoMemList.hat, this.xBe + this.miniItem * 2 + 2, num + this.miniItem + 45, 2);
					AvMain.fraStatusOnline.drawFrame((int)infoMemList.typeOnline, this.xBe + this.miniItem * 2 + 16 + 1, num + this.miniItem + GameCanvas.hText, 0, 3, g);
				}
			}
			mGraphics.resetTransAndroid(g);
			g.restoreCanvas();
			base.paint(g);
		}
	}

	// Token: 0x060000F0 RID: 240 RVA: 0x000198FC File Offset: 0x00017AFC
	public override void update()
	{
		this.CamDetailChat.moveCamera();
		bool flag = Clan_Mem.tickupdate > 0;
		if (flag)
		{
			Clan_Mem.tickupdate--;
		}
	}

	// Token: 0x060000F1 RID: 241 RVA: 0x00019930 File Offset: 0x00017B30
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
		this.updatekeyPC();
	}

	// Token: 0x060000F2 RID: 242 RVA: 0x000199E0 File Offset: 0x00017BE0
	private void setXCam()
	{
		int toX = this.idSelect * this.wItem - this.hCon / 4;
		this.CamDetailChat.setToX(toX);
	}

	// Token: 0x060000F3 RID: 243 RVA: 0x00019A14 File Offset: 0x00017C14
	public override void updatePointer()
	{
		this.CamDetailChat.update_Pos_UP_DOWN();
		bool flag = GameCanvas.isPointerSelect && this.vecDetail.size() > 0 && GameCanvas.isPoint(this.xBe, this.yBe, this.wCon, this.hCon);
		if (flag)
		{
			GameCanvas.isPointerSelect = false;
			int num = (GameCanvas.py - this.yBe + this.CamDetailChat.cmx) / this.wItem;
			bool flag2 = num >= 0 && num < this.vecDetail.size();
			if (flag2)
			{
				this.idSelect = num;
				this.cmdView.perform();
			}
		}
		bool flag3 = GameCanvas.isPointerRelease && this.CamDetailChat.cmx < -this.wItem && Clan_Mem.tickupdate <= 0;
		if (flag3)
		{
			this.cmdUpdate.perform();
			GameCanvas.isPointerRelease = false;
		}
	}

	// Token: 0x060000F4 RID: 244 RVA: 0x00019B00 File Offset: 0x00017D00
	private void doMenuTouchPlayer()
	{
		bool flag = this.idSelect >= 0 && this.idSelect <= this.vecDetail.size();
		if (flag)
		{
			InfoMemList mem = (InfoMemList)this.vecDetail.elementAt(this.idSelect);
			MsgInfoMemClan dgl = new MsgInfoMemClan(mem);
			GameCanvas.Start_Sub_Dialog(dgl);
		}
	}

	// Token: 0x060000F5 RID: 245 RVA: 0x00019B5C File Offset: 0x00017D5C
	public void updateLimCam()
	{
		int num = this.vecDetail.size() * this.wItem - this.hCon;
		bool flag = num > 0;
		if (flag)
		{
			this.CamDetailChat.cmxLim = num;
		}
	}

	// Token: 0x04000186 RID: 390
	private iCommand cmdView;

	// Token: 0x04000187 RID: 391
	private iCommand cmdUpdate;

	// Token: 0x04000188 RID: 392
	private int minChat;

	// Token: 0x04000189 RID: 393
	private int maxChat;

	// Token: 0x0400018A RID: 394
	public static int tickupdate;
}
