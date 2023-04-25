using System;

// Token: 0x020000F9 RID: 249
public class Sudo_Mem : ChatDetail
{
	// Token: 0x06000EA2 RID: 3746 RVA: 0x0000BFFC File Offset: 0x0000A1FC
	public Sudo_Mem(string name, sbyte type) : base(name, type)
	{
	}

	// Token: 0x06000EA3 RID: 3747 RVA: 0x00119364 File Offset: 0x00117564
	public override void setPos(int xBe, int yBe, int wCon, int hCon, int miniItem, int hchat)
	{
		this.xBe = xBe;
		this.yBe = yBe;
		this.wCon = wCon;
		this.hCon = hCon;
		this.miniItem = miniItem;
		this.hChat = hchat;
		this.wItem = 48;
		this.CamDetailChat = new ListNew(xBe, yBe, wCon, hCon, this.wItem, 0, Sudo_Mem.vecSudo.size() * this.wItem - hCon, true);
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

	// Token: 0x06000EA4 RID: 3748 RVA: 0x0000C018 File Offset: 0x0000A218
	public override void beginFocus()
	{
		Sudo_Mem.tickupdate = 0;
	}

	// Token: 0x06000EA5 RID: 3749 RVA: 0x0011942C File Offset: 0x0011762C
	public override void commandPointer(int index, int subIndex)
	{
		if (index != 0)
		{
			if (index == 1)
			{
				GlobalService.gI().Send_Sudo(2);
				Sudo_Mem.tickupdate = 40;
			}
		}
		else
		{
			this.doMenuTouchPlayer();
		}
	}

	// Token: 0x06000EA6 RID: 3750 RVA: 0x00119468 File Offset: 0x00117668
	public void setDataCam()
	{
		bool flag = this.CamDetailChat == null;
		if (flag)
		{
			this.CamDetailChat = new ListNew(this.xBe, this.yBe, this.wCon, this.hCon, this.wItem, 0, Sudo_Mem.vecSudo.size() * this.wItem - this.hCon, true);
		}
		else
		{
			this.CamDetailChat.cmxLim = Sudo_Mem.vecSudo.size() * this.wItem - this.hCon;
			bool flag2 = this.CamDetailChat.cmxLim < 0;
			if (flag2)
			{
				this.CamDetailChat.cmxLim = 0;
			}
		}
	}

	// Token: 0x06000EA7 RID: 3751 RVA: 0x0011950C File Offset: 0x0011770C
	public override void paint(mGraphics g)
	{
		g.setClip(this.xBe - this.miniItem, this.yBe - 2, this.wCon + this.miniItem * 2, this.hCon + 2);
		g.saveCanvas();
		g.ClipRec(this.xBe - this.miniItem, this.yBe - 2, this.wCon + this.miniItem * 2, this.hCon + 2);
		g.translate(0, -this.CamDetailChat.cmx);
		this.minChat = 0;
		this.maxChat = 0;
		bool flag = Sudo_Mem.vecSudo != null;
		if (flag)
		{
			this.maxChat = Sudo_Mem.vecSudo.size();
		}
		bool flag2 = Sudo_Mem.tickupdate > 0;
		if (flag2)
		{
			MsgDialog.fraImgWaiting.drawFrame(GameCanvas.gameTick / 6 % MsgDialog.fraImgWaiting.nFrame, this.xBe + this.wCon / 2, this.yBe + this.hCon / 2, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
		}
		else
		{
			for (int i = 0; i < Sudo_Mem.vecSudo.size(); i++)
			{
				int ypaint = this.yBe + i * this.wItem;
				int xpaint = this.xBe - 2;
				int wsub = this.wCon + 4;
				InfoMemList mem = (InfoMemList)Sudo_Mem.vecSudo.elementAt(i);
				this.paintInfo(g, mem, xpaint, ypaint, i, wsub);
			}
			mGraphics.resetTransAndroid(g);
			g.restoreCanvas();
			base.paint(g);
		}
	}

	// Token: 0x06000EA8 RID: 3752 RVA: 0x00119698 File Offset: 0x00117898
	public void paintInfo(mGraphics g, InfoMemList mem, int xpaint, int ypaint, int i, int wsub)
	{
		bool flag = mem != null;
		if (flag)
		{
			AvMain.paintRect(g, xpaint, ypaint, wsub - 1, 40, 1, 3);
			AvMain.paintRect(g, xpaint + 45, ypaint + 2, wsub - 42 - 10, 14, 1, 1);
			mFont.tahoma_7b_black.drawString(g, mem.title, xpaint + 45 + (wsub - 52) / 2, ypaint + 3, 2);
			mFont.tahoma_7b_white.drawString(g, mem.name, xpaint + 45 + (wsub - 52) / 2, ypaint + 22, 2);
			g.drawImage(AvMain.imgBorderIcon, xpaint + 4 + 16, ypaint + 4 + 16, 3);
			MainObject.paintHeadEveryWhere(g, mem.head, mem.hair, mem.hat, xpaint + 2 + 16, ypaint + 54, 0);
			AvMain.fraStatusOnline.drawFrame((int)mem.typeOnline, xpaint + 45 + (wsub - 52) / 10, ypaint + 22 + 6, 0, 3, g);
			g.drawImage(AvMain.imgLvClan, xpaint + 45 + (wsub - 52) / 5 * 4 + 5, ypaint + 22 - 5, 0);
			mFont.tahoma_7b_white.drawString(g, mem.Lv.ToString() + string.Empty, xpaint + 45 + (wsub - 52) / 5 * 4 + 18, ypaint + 22 + 2, 2);
		}
	}

	// Token: 0x06000EA9 RID: 3753 RVA: 0x001197EC File Offset: 0x001179EC
	public override void update()
	{
		this.CamDetailChat.moveCamera();
		bool flag = Sudo_Mem.tickupdate > 0;
		if (flag)
		{
			Sudo_Mem.tickupdate--;
		}
	}

	// Token: 0x06000EAA RID: 3754 RVA: 0x00119820 File Offset: 0x00117A20
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
				bool flag4 = this.idSelect < Sudo_Mem.vecSudo.size() - 1;
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

	// Token: 0x06000EAB RID: 3755 RVA: 0x000199E0 File Offset: 0x00017BE0
	private void setXCam()
	{
		int toX = this.idSelect * this.wItem - this.hCon / 4;
		this.CamDetailChat.setToX(toX);
	}

	// Token: 0x06000EAC RID: 3756 RVA: 0x001198D0 File Offset: 0x00117AD0
	public override void updatePointer()
	{
		this.CamDetailChat.update_Pos_UP_DOWN();
		bool flag = GameCanvas.isPointerSelect && Sudo_Mem.vecSudo.size() > 0 && GameCanvas.isPoint(this.xBe, this.yBe, this.wCon, this.hCon);
		if (flag)
		{
			GameCanvas.isPointerSelect = false;
			int num = (GameCanvas.py - this.yBe + this.CamDetailChat.cmx) / this.wItem;
			bool flag2 = num >= 0 && num < Sudo_Mem.vecSudo.size();
			if (flag2)
			{
				this.idSelect = num;
				this.cmdView.perform();
			}
		}
		bool flag3 = GameCanvas.isPointerRelease && this.CamDetailChat.cmx < -this.wItem && Sudo_Mem.tickupdate <= 0;
		if (flag3)
		{
			this.cmdUpdate.perform();
			GameCanvas.isPointerRelease = false;
		}
	}

	// Token: 0x06000EAD RID: 3757 RVA: 0x001199B8 File Offset: 0x00117BB8
	private void doMenuTouchPlayer()
	{
		bool flag = this.idSelect >= 0 && this.idSelect <= Sudo_Mem.vecSudo.size();
		if (flag)
		{
			InfoMemList mem = (InfoMemList)Sudo_Mem.vecSudo.elementAt(this.idSelect);
			MsgInfoMemSudo dgl = new MsgInfoMemSudo(mem);
			GameCanvas.Start_Sub_Dialog(dgl);
		}
	}

	// Token: 0x06000EAE RID: 3758 RVA: 0x00119A14 File Offset: 0x00117C14
	public void updateLimCam()
	{
		int num = Sudo_Mem.vecSudo.size() * this.wItem - this.hCon;
		bool flag = num > 0;
		if (flag)
		{
			this.CamDetailChat.cmxLim = num;
		}
	}

	// Token: 0x04001671 RID: 5745
	private iCommand cmdView;

	// Token: 0x04001672 RID: 5746
	private iCommand cmdUpdate;

	// Token: 0x04001673 RID: 5747
	private int minChat;

	// Token: 0x04001674 RID: 5748
	private int maxChat;

	// Token: 0x04001675 RID: 5749
	public static mVector vecSudo = new mVector();

	// Token: 0x04001676 RID: 5750
	private int wPaintQua = 93;

	// Token: 0x04001677 RID: 5751
	private int hItem = 48;

	// Token: 0x04001678 RID: 5752
	public static int tickupdate = 0;
}
