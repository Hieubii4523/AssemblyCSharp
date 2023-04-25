using System;

// Token: 0x02000101 RID: 257
public class TabQuest : MainTab
{
	// Token: 0x06000EF4 RID: 3828 RVA: 0x00120E70 File Offset: 0x0011F070
	public TabQuest(string name)
	{
		this.nameTab = name;
		this.list = new ListNew();
		this.indexIconTab = 4;
		this.wItemCur = 32;
		bool isBigScreen = this.isBigScreen;
		if (isBigScreen)
		{
			this.wItemCur = 36;
		}
		this.initCmd();
		this.marName = new MarqueeText(this.wCur - (this.miniItem + 16 + 14));
		this.marInfo = new MarqueeText(this.wCur - (this.miniItem + 16 + 20));
		this.maxPaint = this.hCur / this.wItemCur + 1;
	}

	// Token: 0x06000EF5 RID: 3829 RVA: 0x00120F38 File Offset: 0x0011F138
	public override void beginFocus()
	{
		int limX = Player.vecQuest.size() * this.wItemCur - this.hCur + this.miniItem * 3;
		this.list = new ListNew(this.xCurBegin, this.yCurBegin, this.wCur, this.hCur, 0, 0, limX, true);
		this.scrQuest.setInfo(this.xCurBegin + this.wCur + this.miniItem, this.yCurBegin + this.miniItem / 2, this.hCur - this.miniItem * 2, 8809550);
		bool flag = GameCanvas.isTouchNoOrPC();
		if (flag)
		{
			this.IdSelect = 0;
			bool flag2 = Player.vecQuest.size() > 0;
			if (flag2)
			{
				this.getQuestCur(this.IdSelect);
				bool flag3 = this.questCur != null;
				if (flag3)
				{
					this.center = this.questCur.getCmeTabQuest();
				}
			}
			else
			{
				this.center = null;
			}
			this.okCMD = this.center;
		}
		else
		{
			this.IdSelect = -1;
		}
	}

	// Token: 0x06000EF6 RID: 3830 RVA: 0x0000C0EB File Offset: 0x0000A2EB
	private void initCmd()
	{
		TabQuest.cmdShow = new iCommand(T.show, 0, this);
	}

	// Token: 0x06000EF7 RID: 3831 RVA: 0x00121048 File Offset: 0x0011F248
	public override void commandPointer(int index, int subIndex)
	{
		bool flag = index == 0 && this.questCur != null;
		if (flag)
		{
			this.showDialogQuest();
		}
	}

	// Token: 0x06000EF8 RID: 3832 RVA: 0x00121074 File Offset: 0x0011F274
	public override void paint(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		AvMain.paintRect(g, this.xCurBegin, this.yCurBegin, this.wCur, this.hCur - this.miniItem, 0, 4);
		g.saveCanvas();
		g.ClipRec(this.xCurBegin - 1, this.yCurBegin + 1, this.wCur + 2, this.hCur - 1 - this.miniItem - 1);
		this.setClip(g);
		int num = this.miniItem * 2;
		int num2 = this.miniItem + 16;
		int num3 = this.list.cmx / this.wItemCur;
		int num4 = num3 + this.maxPaint;
		num += this.wItemCur * num3;
		for (int i = num3; i < num4; i++)
		{
			bool flag = i >= 0 && i < Player.vecQuest.size();
			if (flag)
			{
				MainQuest mainQuest = (MainQuest)Player.vecQuest.elementAt(i);
				AvMain.fraQuest.drawFrame((int)(mainQuest.statusQuest + 1), num2 + 6, num + this.wItemCur / 4, 0, 3, g);
				bool flag2 = (this.marName.isRun || this.marInfo.isRun) && this.IdSelect == i && GameCanvas.currentScreen.setCurTypetab(1) && this.list.cmx == this.list.cmtoX;
				if (flag2)
				{
					g.setClip(num2 + 14, num - 2, this.marName.maxW, this.wItemCur);
					bool flag3 = mainQuest.statusQuest == 0;
					if (flag3)
					{
						mFont.tahoma_7_blue.drawString(g, T.newquest + ((mainQuest.typeMainSub != 0) ? string.Empty : mainQuest.getMainSub()), num2 + 14 - this.marName.xplus, num - 2, 0);
					}
					else
					{
						mFont.tahoma_7b_white.drawString(g, mainQuest.name + mainQuest.getMainSub(), num2 + 14 - this.marName.xplus, num - 2, 0);
					}
					mFont.tahoma_7_white.drawString(g, mainQuest.strNPC_Map, num2 + 20 - this.marInfo.xplus, num + GameCanvas.hText - 2 - 2, 0);
					this.setClip(g);
				}
				else
				{
					bool flag4 = mainQuest.statusQuest == 0;
					if (flag4)
					{
						mFont.tahoma_7_blue.drawString(g, T.newquest + ((mainQuest.typeMainSub != 0) ? string.Empty : mainQuest.getMainSub()), num2 + 14, num - 2, 0);
					}
					else
					{
						mFont.tahoma_7b_white.drawString(g, mainQuest.name + mainQuest.getMainSub(), num2 + 14, num - 2, 0);
					}
					mFont.tahoma_7_white.drawString(g, mainQuest.strNPC_Map, num2 + 20, num + GameCanvas.hText - 2 - 2, 0);
				}
				bool flag5 = this.IdSelect == i && GameCanvas.currentScreen.setCurTypetab(1);
				if (flag5)
				{
					g.drawRegion(AvMain.imgSelect, 0, 0, 12, 16, 4, (float)(num2 - GameCanvas.gameTick / 2 % 3), (float)(num + 4), mGraphics.VCENTER | mGraphics.RIGHT);
				}
			}
			num += this.wItemCur;
		}
		bool flag6 = GameCanvas.currentScreen.setCurTypetab(1);
		if (flag6)
		{
			base.paint(g);
			bool flag7 = this.list.cmxLim > 0;
			if (flag7)
			{
				this.scrQuest.paint(g);
			}
		}
		mGraphics.resetTransAndroid(g);
		g.restoreCanvas();
	}

	// Token: 0x06000EF9 RID: 3833 RVA: 0x00121418 File Offset: 0x0011F618
	public void setClip(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		g.setClip(this.xCurBegin - 1, this.yCurBegin + 1, this.wCur + 2, this.hCur - 1 - this.miniItem - 1);
		g.translate(this.xCurBegin, this.yCurBegin);
		g.translate(0, -this.list.cmx);
	}

	// Token: 0x06000EFA RID: 3834 RVA: 0x00121484 File Offset: 0x0011F684
	public override void update()
	{
		this.list.moveCamera();
		this.scrQuest.setYScrool(this.list.cmx, this.list.cmxLim);
		this.marName.update2();
		this.marInfo.update();
	}

	// Token: 0x06000EFB RID: 3835 RVA: 0x001214D8 File Offset: 0x0011F6D8
	public override void updatekey()
	{
		bool flag = false;
		bool flag2 = GameCanvas.keyMove(1);
		if (flag2)
		{
			this.IdSelect--;
			GameCanvas.ClearkeyMove(1);
			flag = true;
		}
		else
		{
			bool flag3 = GameCanvas.keyMove(3);
			if (flag3)
			{
				this.IdSelect++;
				GameCanvas.ClearkeyMove(3);
				flag = true;
			}
		}
		bool flag4 = GameCanvas.keyMove(0) || GameCanvas.keyMove(2);
		if (flag4)
		{
			GameCanvas.currentScreen.setTypeTab(0);
			GameCanvas.ClearkeyMove(0);
			GameCanvas.ClearkeyMove(2);
		}
		bool flag5 = flag;
		if (flag5)
		{
			this.IdSelect = AvMain.resetSelect(this.IdSelect, Player.vecQuest.size() - 1, false);
			this.getQuestCur(this.IdSelect);
			bool flag6 = this.questCur != null;
			if (flag6)
			{
				this.center = this.questCur.getCmeTabQuest();
				this.okCMD = this.center;
			}
			bool flag7 = GameCanvas.isTouchNoOrPC();
			if (flag7)
			{
				this.list.setToX((this.IdSelect + 1) * this.wItemCur - this.hCur / 2);
			}
		}
		base.updatekey();
	}

	// Token: 0x06000EFC RID: 3836 RVA: 0x00121600 File Offset: 0x0011F800
	public override void updatePointer()
	{
		this.list.update_Pos_UP_DOWN();
		bool flag = GameCanvas.isPointerSelect && Player.vecQuest.size() > 0 && GameCanvas.isPoint(this.xCurBegin, this.yCurBegin, this.wCur, this.hCur);
		if (flag)
		{
			int num = (GameCanvas.py - this.yCurBegin + this.list.cmx) / this.wItemCur;
			bool flag2 = num >= 0 && num < Player.vecQuest.size();
			if (flag2)
			{
				bool flag3 = num == this.IdSelect;
				if (flag3)
				{
					this.showDialogQuest();
				}
				else
				{
					this.IdSelect = num;
				}
				this.getQuestCur(this.IdSelect);
				this.center = this.questCur.getCmeTabQuest();
			}
			GameCanvas.isPointerSelect = false;
		}
		base.updatePointer();
	}

	// Token: 0x06000EFD RID: 3837 RVA: 0x001216E0 File Offset: 0x0011F8E0
	public void getQuestCur(int id)
	{
		this.questCur = (MainQuest)Player.vecQuest.elementAt(id);
		bool flag = this.questCur != null;
		if (flag)
		{
			string str = this.questCur.name + this.questCur.getMainSub();
			bool flag2 = this.questCur.statusQuest == 0;
			if (flag2)
			{
				str = T.newquest;
			}
			this.marName.setdata(str, mFont.tahoma_7b_black);
			this.marInfo.setdata(this.questCur.strNPC_Map, mFont.tahoma_7_black);
		}
	}

	// Token: 0x06000EFE RID: 3838 RVA: 0x00121778 File Offset: 0x0011F978
	public void showDialogQuest()
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setinfoQuest(this.questCur, false);
		GameCanvas.Start_Current_Dialog(msgDialog);
	}

	// Token: 0x04001935 RID: 6453
	private ListNew list;

	// Token: 0x04001936 RID: 6454
	private MainQuest questCur;

	// Token: 0x04001937 RID: 6455
	public static iCommand cmdShow;

	// Token: 0x04001938 RID: 6456
	private MarqueeText marName = new MarqueeText(0);

	// Token: 0x04001939 RID: 6457
	private MarqueeText marInfo = new MarqueeText(0);

	// Token: 0x0400193A RID: 6458
	private Scroll scrQuest = new Scroll();

	// Token: 0x0400193B RID: 6459
	private int maxPaint;

	// Token: 0x0400193C RID: 6460
	public static bool isNewQuest;
}
