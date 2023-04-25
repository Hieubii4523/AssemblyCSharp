using System;

// Token: 0x020000E8 RID: 232
public class ScreenUpgradeSkillDevil : ScreenUpgrade
{
	// Token: 0x06000DFE RID: 3582 RVA: 0x0010F3B8 File Offset: 0x0010D5B8
	public ScreenUpgradeSkillDevil()
	{
		this.typeRebuild = 9;
		this.nameScreen = T.upgradeDevilSkill;
		this.Step = 0;
		this.lech = 10;
		this.w = 290;
		this.h = 180;
		this.wInven = this.w / 2;
		this.hInven = this.h - this.lech * 3;
		this.wItem = 24;
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.wItem = 28;
		}
		bool flag = this.w > MotherCanvas.w;
		if (flag)
		{
			this.w = MotherCanvas.w;
		}
		bool flag2 = this.h > MotherCanvas.h - GameCanvas.hCommand * 2;
		if (flag2)
		{
			this.h = MotherCanvas.h - GameCanvas.hCommand * 2;
		}
		this.x = MotherCanvas.hw - this.w / 2;
		this.y = MotherCanvas.hh - this.h / 2 + 5;
		this.xInven = this.x + 5;
		this.yInven = this.y + 20;
		this.xTiLe = this.xInven + this.wInven + 4;
		this.vecSkill.removeAllElements();
		for (int i = 0; i < Player.vecListSkill.size(); i++)
		{
			Skill_Info skill_Info = (Skill_Info)Player.vecListSkill.elementAt(i);
			bool flag3 = skill_Info.Lv_RQ >= 0 && skill_Info.typeSkill == 1;
			if (flag3)
			{
				this.vecSkill.addElement(skill_Info);
			}
		}
		int limX = this.vecSkill.size() * this.wItemCur - this.hInven + 10;
		this.list = new ListNew(this.x, this.y + 30, this.w, this.hInven, 0, 0, limX, true);
		this.cmdClose = new iCommand(T.close, -1, this);
		this.cmdBovao = new iCommand(T.bovao, 0, this);
		this.cmdUpgrade = new iCommand(T.Upgrade, 1, this);
		bool isTouch2 = GameCanvas.isTouch;
		if (isTouch2)
		{
			this.cmdUpgrade.setPos(this.x + this.wInven + (this.w - this.lech * 3 - this.wInven) / 2 + this.wItem / 2, this.y + this.h - iCommand.hButtonCmdNor / 2 - 5, null, this.cmdUpgrade.caption);
			this.cmdClose.setPos(this.x + this.w - 15, this.y - 15 + 10 + 8, MainTab.fraCloseTab, string.Empty);
			this.cmdBovao = AvMain.setPosCMD(this.cmdBovao, 1);
			this.vecCmd.addElement(this.cmdClose);
			this.vecCmd.addElement(this.cmdUpgrade);
			this.vecCmd.addElement(this.cmdBovao);
			bool flag4 = GameCanvas.isTouchNoOrPC();
			if (flag4)
			{
				this.backCMD = this.cmdClose;
				this.menuCMD = this.cmdBovao;
				this.okCMD = this.cmdUpgrade;
			}
		}
		else
		{
			this.right = this.cmdClose;
			this.left = this.cmdBovao;
			this.center = this.cmdUpgrade;
		}
		int num = this.x + this.wInven + (this.w - this.lech * 3 - this.wInven) / 6;
		int num2 = this.y + this.h / 2 - this.wItem / 2;
		this.posUp = mSystem.new_M_Int(2, 2);
		this.posUp[0][0] = num;
		this.posUp[0][1] = num2;
		this.posUp[1][0] = num + (this.w - this.lech * 3 - this.wInven) / 6 * 4;
		this.posUp[1][1] = num2;
		this.marName = new MarqueeText(this.wInven - this.wItemCur - 10);
		this.begin();
	}

	// Token: 0x06000DFF RID: 3583 RVA: 0x0000BD99 File Offset: 0x00009F99
	public void begin()
	{
		ScreenUpgrade.mItemUpgrade = new MainItem[this.posUp.Length];
	}

	// Token: 0x06000E00 RID: 3584 RVA: 0x0010F800 File Offset: 0x0010DA00
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case -1:
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
		case 0:
		{
			bool flag2 = this.IdSelect >= 0 && this.IdSelect < this.vecSkill.size();
			if (flag2)
			{
				Skill_Info skill_Info = (Skill_Info)this.vecSkill.elementAt(this.IdSelect);
				GlobalService.gI().Devil_Upgrade(9, skill_Info.ID, 104, 0);
			}
			break;
		}
		case 1:
		{
			bool flag3 = ScreenUpgrade.mItemUpgrade[0] != null;
			if (flag3)
			{
				GlobalService.gI().Devil_Upgrade(12, ScreenUpgrade.mItemUpgrade[0].ID, ScreenUpgrade.mItemUpgrade[0].typeObject, 0);
			}
			break;
		}
		}
	}

	// Token: 0x06000E01 RID: 3585 RVA: 0x0010F8F8 File Offset: 0x0010DAF8
	public override void paint(mGraphics g)
	{
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.paint(g);
		}
		GameCanvas.resetTrans(g);
		this.paintBackGr(g);
		this.setClip(g);
		this.paintSkill(g);
		GameCanvas.resetTrans(g);
		Interface_Game.paintNumMess(g, -Interface_Game.xNumMess + 8, -Interface_Game.yNumMess + 3);
		base.paintEff(g, -1);
		this.paintPosItem(g);
		this.paintTiLe(g);
		bool flag2 = this.vecCmd != null && GameCanvas.getShowCmd();
		if (flag2)
		{
			for (int i = 0; i < this.vecCmd.size(); i++)
			{
				iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
				iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
			}
		}
		base.paintSuper(g);
		Interface_Game.paintEffShowMoney(g, MotherCanvas.hw - Interface_Game.wMoneyEff / 2, GameScreen.h12plus, true, 0);
		base.paintEff(g, 0);
	}

	// Token: 0x06000E02 RID: 3586 RVA: 0x0000BDAE File Offset: 0x00009FAE
	public override void paintTiLe(mGraphics g)
	{
		mFont.tahoma_7b_black.drawString(g, T.tile + "50%", this.xTiLe, this.yInven, 0);
	}

	// Token: 0x06000E03 RID: 3587 RVA: 0x0010FA00 File Offset: 0x0010DC00
	private void paintSkill(mGraphics g)
	{
		int num = this.miniItem;
		int num2 = 0;
		int num3 = this.list.cmx / this.wItemCur - 1;
		int num4 = this.hInven / this.wItemCur + 2 + num3;
		bool flag = this.IdSelect >= 0 && this.IdSelect < this.vecSkill.size();
		if (flag)
		{
			this.paintSelect(g);
		}
		for (int i = 0; i < this.vecSkill.size(); i++)
		{
			bool flag2 = i >= num3 && i <= num4;
			if (flag2)
			{
				Skill_Info skill_Info = (Skill_Info)this.vecSkill.elementAt(i);
				string name = skill_Info.name;
				skill_Info.paint(g, num + this.wItemCur / 2, num2 + this.wItemCur / 2);
				bool flag3 = i == 0;
				if (flag3)
				{
					g.setColor(14533533);
					g.fillRect(num + 1, num2 - 1, this.wInven - 1, 2);
					g.fillRect(num + 1 + this.wInven - 1, num2, 1, 2);
				}
				g.setColor(14533533);
				g.fillRect(num + 1, num2 + this.wItemCur - 1, this.wInven - 1, 2);
				g.fillRect(num + 1 + this.wInven - 1, num2 + this.wItemCur, 1, 2);
				bool flag4 = this.IdSelect == i && this.marName.isRun;
				if (flag4)
				{
					g.setClip(num + this.wItemCur + this.miniItem, num2, this.marName.maxW, this.wItemCur);
					mFont.tahoma_7b_white.drawString(g, name, num + this.wItemCur + this.miniItem - this.marName.xplus, num2 + this.miniItem / 2 + 1, 0);
					this.setClip(g);
				}
				else
				{
					mFont.tahoma_7b_white.drawString(g, name, num + this.wItemCur + this.miniItem, num2 + this.miniItem / 2 + 1, 0);
				}
				mFont.tahoma_7_black.drawString(g, string.Concat(new string[]
				{
					T.lvDevil,
					skill_Info.LvDevilSkill.ToString(),
					" + ",
					skill_Info.phanTramDevilSkill.ToString(),
					"%"
				}), num + this.wItemCur + this.miniItem, num2 + this.miniItem / 2 + GameCanvas.hText + 1, 0);
			}
			num2 += this.wItemCur;
		}
	}

	// Token: 0x06000E04 RID: 3588 RVA: 0x0010FCA8 File Offset: 0x0010DEA8
	public void setClip(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		g.setClip(this.x + 2, this.y + 20 + 2, this.wInven + 4, this.hInven - 1 - this.miniItem - 1 + 5);
		g.translate(this.x, this.y + 25);
		g.translate(0, -this.list.cmx);
	}

	// Token: 0x06000E05 RID: 3589 RVA: 0x0010FD1C File Offset: 0x0010DF1C
	public void paintSelect(mGraphics g)
	{
		g.setColor(14729352);
		g.fillRect(this.miniItem + 2, this.IdSelect * this.wItemCur + 2, this.wInven - 3, this.wItemCur - 4);
		g.fillRect(this.miniItem + this.wInven - 1, this.IdSelect * this.wItemCur + 3, 1, this.wItemCur - 5);
	}

	// Token: 0x06000E06 RID: 3590 RVA: 0x0010FD94 File Offset: 0x0010DF94
	public override void update()
	{
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.update();
		}
		this.list.moveCamera();
		for (int i = 0; i < this.vecEff.size(); i++)
		{
			MainEffect mainEffect = (MainEffect)this.vecEff.elementAt(i);
			mainEffect.update();
			bool isStop = mainEffect.isStop;
			if (isStop)
			{
				this.vecEff.removeElement(mainEffect);
				i--;
			}
		}
		this.setStep();
		this.marName.update2();
	}

	// Token: 0x06000E07 RID: 3591 RVA: 0x0000BDD9 File Offset: 0x00009FD9
	public override void setStep()
	{
		base.updateKHAM();
	}

	// Token: 0x06000E08 RID: 3592 RVA: 0x0010FE30 File Offset: 0x0010E030
	public override void updatekey()
	{
		bool flag = this.Step != 0;
		if (!flag)
		{
			bool flag2 = false;
			bool flag3 = GameCanvas.keyMove(1);
			if (flag3)
			{
				this.IdSelect--;
				GameCanvas.ClearkeyMove(1);
				flag2 = true;
			}
			else
			{
				bool flag4 = GameCanvas.keyMove(3);
				if (flag4)
				{
					this.IdSelect++;
					GameCanvas.ClearkeyMove(3);
					flag2 = true;
				}
			}
			bool flag5 = flag2;
			if (flag5)
			{
				int num = this.IdSelect * this.wItemCur - this.hInven / 2;
				bool flag6 = this.IdSelect > 0;
				if (flag6)
				{
					num += this.wItemCur / 2;
				}
				this.list.setToX(num);
				this.getItemCurNew();
			}
			base.updatekeySuper();
			this.updatekeyPC();
		}
	}

	// Token: 0x06000E09 RID: 3593 RVA: 0x0010FF00 File Offset: 0x0010E100
	public override void getItemCurNew()
	{
		this.IdSelect = AvMain.resetSelect(this.IdSelect, this.vecSkill.size() - 1, false);
		bool flag = this.IdSelect >= 0 && this.IdSelect < this.vecSkill.size();
		if (flag)
		{
			Skill_Info skill_Info = (Skill_Info)this.vecSkill.elementAt(this.IdSelect);
			this.marName.setdata(skill_Info.name, mFont.tahoma_7b_black);
		}
	}

	// Token: 0x06000E0A RID: 3594 RVA: 0x0010FF80 File Offset: 0x0010E180
	public override void updatePointer()
	{
		bool flag = this.Step != 0;
		if (!flag)
		{
			this.list.update_Pos_UP_DOWN();
			bool flag2 = GameCanvas.isPointSelect(this.x, this.y, this.wInven, this.hInven);
			if (flag2)
			{
				int num = (GameCanvas.py - this.yInven + this.list.cmx) / this.wItemCur;
				int num2 = this.vecSkill.size();
				bool flag3 = num >= 0 && num < num2;
				if (flag3)
				{
					GameCanvas.isPointerSelect = false;
					bool flag4 = num == this.IdSelect;
					if (flag4)
					{
						this.cmdBovao.perform();
					}
					else
					{
						this.isShowInfo = false;
						this.IdSelect = num;
						this.getItemCurNew();
					}
				}
				else
				{
					this.isShowInfo = false;
					this.IdSelect = -1;
				}
			}
			bool flag5 = this.vecCmd != null;
			if (flag5)
			{
				for (int i = 0; i < this.vecCmd.size(); i++)
				{
					iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
					iCommand.updatePointer();
				}
			}
			base.updatePointerSuper();
		}
	}

	// Token: 0x06000E0B RID: 3595 RVA: 0x001100B8 File Offset: 0x0010E2B8
	public override void updateNewUpgrade()
	{
		bool flag = ScreenUpgrade.mItemUpgrade[0] == null;
		if (!flag)
		{
			Skill_Info skill_Info = null;
			for (int i = 0; i < Player.vecListSkill.size(); i++)
			{
				Skill_Info skill_Info2 = (Skill_Info)Player.vecListSkill.elementAt(i);
				bool flag2 = skill_Info2.ID == ScreenUpgrade.mItemUpgrade[0].ID;
				if (flag2)
				{
					skill_Info = skill_Info2;
					break;
				}
			}
			bool flag3 = skill_Info == null;
			if (!flag3)
			{
				for (int j = 0; j < this.vecSkill.size(); j++)
				{
					Skill_Info skill_Info3 = (Skill_Info)this.vecSkill.elementAt(j);
					bool flag4 = skill_Info3.ID == ScreenUpgrade.mItemUpgrade[0].ID;
					if (flag4)
					{
						skill_Info3.LvDevilSkill = skill_Info.LvDevilSkill;
						skill_Info3.phanTramDevilSkill = skill_Info.phanTramDevilSkill;
						break;
					}
				}
			}
		}
	}

	// Token: 0x04001577 RID: 5495
	private mVector vecSkill = new mVector("ScreenUpgradeSkillDevil.vecSkill");

	// Token: 0x04001578 RID: 5496
	private int wItemCur = 34;

	// Token: 0x04001579 RID: 5497
	private int miniItem = 5;

	// Token: 0x0400157A RID: 5498
	private MarqueeText marName = new MarqueeText(0);

	// Token: 0x0400157B RID: 5499
	public new static ScreenUpgradeSkillDevil instance;
}
