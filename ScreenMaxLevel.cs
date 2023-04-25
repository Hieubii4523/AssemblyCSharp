using System;

// Token: 0x020000E6 RID: 230
public class ScreenMaxLevel : MainScreen
{
	// Token: 0x06000DC8 RID: 3528 RVA: 0x0010A5F8 File Offset: 0x001087F8
	public ScreenMaxLevel()
	{
		this.w = MotherCanvas.w - 10;
		this.h = MotherCanvas.h - 10;
		bool flag = this.w > 180;
		if (flag)
		{
			this.w = 180;
		}
		bool flag2 = this.h > 240;
		if (flag2)
		{
			this.h = 240;
		}
		this.x = MotherCanvas.hw - this.w / 2;
		this.y = MotherCanvas.hh - this.h / 2;
		this.wItemCur = 24;
		bool flag3 = !GameCanvas.isTouch;
		if (flag3)
		{
			this.wItemCur = 20;
		}
		this.cmdClose = new iCommand(T.close, 0, this);
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.cmdClose.setPos(this.x - 14 + this.w, this.y + 14, MainTab.fraCloseTab2, string.Empty);
		}
		this.right = this.cmdClose;
		this.backCMD = this.cmdClose;
	}

	// Token: 0x06000DC9 RID: 3529 RVA: 0x0010A710 File Offset: 0x00108910
	public static ScreenMaxLevel gI()
	{
		bool flag = ScreenMaxLevel.instance == null;
		if (flag)
		{
			ScreenMaxLevel.instance = new ScreenMaxLevel();
		}
		return ScreenMaxLevel.instance;
	}

	// Token: 0x06000DCA RID: 3530 RVA: 0x0010A740 File Offset: 0x00108940
	public override void commandPointer(int index, int subIndex)
	{
		bool flag = index == 0;
		if (flag)
		{
			GameCanvas.gameScr.Show();
		}
	}

	// Token: 0x06000DCB RID: 3531 RVA: 0x0010A764 File Offset: 0x00108964
	public void setData()
	{
		bool flag = this.h > (Player.vecMaxLevelAttri.size() + 2) * this.wItemCur + this.wItemCur / 4;
		if (flag)
		{
			this.h = (Player.vecMaxLevelAttri.size() + 2) * this.wItemCur + this.wItemCur / 4;
		}
		this.list = new ListNew(this.x, this.y + GameCanvas.hCommand * 2, this.w, this.h - GameCanvas.hCommand * 2, this.wItemCur, Player.vecMaxLevelAttri.size(), Player.vecMaxLevelAttri.size() * this.wItemCur - (this.h - GameCanvas.hCommand * 2), true);
	}

	// Token: 0x06000DCC RID: 3532 RVA: 0x0010A824 File Offset: 0x00108A24
	public override void paint(mGraphics g)
	{
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.paint(g);
		}
		GameCanvas.resetTrans(g);
		AvMain.paintThongThao(g, this.x, this.y, this.w, this.h);
		int num = this.y + this.wItemCur;
		int num2 = 25;
		bool flag2 = !GameCanvas.lowGraphic;
		if (flag2)
		{
			num2 = AvMain.fraThongThao.frameWidth / 2;
			AvMain.fraBanhLai.drawFrame(0, this.x + this.w / 2 - num2 - 12, num, 0, 3, g);
			AvMain.fraBanhLai.drawFrame(1, this.x + this.w / 2 + num2 + 12, num, 0, 3, g);
			AvMain.fraThongThao.drawFrame((GameCanvas.language != 0) ? 1 : 0, this.x + this.w / 2, num, 0, 3, g);
		}
		else
		{
			mFont.tahoma_7b_black.drawString(g, T.thongthao, this.x + this.w / 2, num, 2);
		}
		mFont.tahoma_7_yellow.drawString(g, GameScreen.player.LvThongThao.ToString() + string.Empty, this.x + this.w / 2 - num2 - 12 + 1, num - 5, 2);
		mFont.tahoma_7_white.drawString(g, Player.pointMaxLevelAttri.ToString() + string.Empty, this.x + this.w / 2 + num2 + 12 + 1, num - 5, 2);
		num += this.wItemCur + this.wItemCur / 4;
		bool flag3 = Player.vecMaxLevelAttri != null;
		if (flag3)
		{
			g.setClip(this.x, num - this.wItemCur / 4, this.w, this.h - GameCanvas.hCommand * 2 - this.wItemCur / 4);
			g.saveCanvas();
			g.ClipRec(this.x, num - this.wItemCur / 4, this.w, this.h - GameCanvas.hCommand * 2 - this.wItemCur / 4);
			bool flag4 = this.list.cmxLim != 0;
			if (flag4)
			{
				g.translate(0, -this.list.cmx);
			}
			int num3 = this.list.cmx / this.wItemCur - 2;
			bool flag5 = num3 < 0;
			if (flag5)
			{
				num3 = 0;
			}
			int num4 = this.h / this.wItemCur + 1 + num3;
			bool flag6 = num4 >= Player.vecMaxLevelAttri.size();
			if (flag6)
			{
				num4 = Player.vecMaxLevelAttri.size();
			}
			for (int i = num3; i < num4; i++)
			{
				MaxLevelAttribute maxLevelAttribute = (MaxLevelAttribute)Player.vecMaxLevelAttri.elementAt(i);
				mFont.tahoma_7b_black.drawString(g, MainItem.mNameAttributes[maxLevelAttribute.Id].name + ": ", this.x + 80, num - 4, 1);
				bool isFocus = false;
				bool flag7 = i == this.idSelect && GameCanvas.isTouchNoOrPC();
				if (flag7)
				{
					isFocus = true;
				}
				Interface_Game.paintHP_Thong_Thao(g, this.x + 80, num - 4, this.w - 90, maxLevelAttribute.value, maxLevelAttribute.maxValue, isFocus);
				num += this.wItemCur;
			}
			mGraphics.resetTransAndroid(g);
			g.restoreCanvas();
		}
		GameCanvas.resetTrans(g);
		bool flag8 = !GameCanvas.lowGraphic && AvMain.mimgBgB != null;
		if (flag8)
		{
			g.drawImage(AvMain.mimgBgB[8], this.x + this.w - 36, this.y + this.h - 36, 0);
		}
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.cmdClose.paint(g, this.cmdClose.xCmd, this.cmdClose.yCmd);
		}
		else
		{
			base.paintCmd(g);
		}
	}

	// Token: 0x06000DCD RID: 3533 RVA: 0x0010AC30 File Offset: 0x00108E30
	public override void update()
	{
		bool flag = this.list.cmxLim > 0;
		if (flag)
		{
			this.list.moveCamera();
		}
		bool flag2 = this.lastScreen != null;
		if (flag2)
		{
			this.lastScreen.update();
		}
	}

	// Token: 0x06000DCE RID: 3534 RVA: 0x0010AC7C File Offset: 0x00108E7C
	public override void updatekey()
	{
		bool flag = false;
		bool flag2 = GameCanvas.keyMove(1);
		if (flag2)
		{
			this.idSelect--;
			GameCanvas.ClearkeyMove(1);
			flag = true;
		}
		else
		{
			bool flag3 = GameCanvas.keyMove(3);
			if (flag3)
			{
				this.idSelect++;
				GameCanvas.ClearkeyMove(3);
				flag = true;
			}
			else
			{
				bool flag4 = GameCanvas.keyMyHold[5];
				if (flag4)
				{
					GameCanvas.clearKeyHold(5);
					this.setAction(this.idSelect);
				}
			}
		}
		bool flag5 = flag;
		if (flag5)
		{
			this.idSelect = AvMain.resetSelect(this.idSelect, Player.vecMaxLevelAttri.size() - 1, false);
			bool flag6 = this.list.cmxLim > 0;
			if (flag6)
			{
				this.list.setToX(this.idSelect * this.wItemCur - this.list.maxH / 2);
			}
		}
		base.updatekey();
	}

	// Token: 0x06000DCF RID: 3535 RVA: 0x0010AD64 File Offset: 0x00108F64
	public override void updatePointer()
	{
		bool flag = this.list.cmxLim > 0;
		if (flag)
		{
			this.list.update_Pos_UP_DOWN();
		}
		base.updatePointer();
		bool flag2 = !GameCanvas.isPointerSelect;
		if (!flag2)
		{
			int num = this.y + this.wItemCur * 2 - this.wItemCur / 2;
			bool flag3 = !GameCanvas.isPoint(this.x, this.y, this.w, this.h);
			if (!flag3)
			{
				int num2 = (GameCanvas.py - (num - this.list.cmx)) / this.wItemCur;
				bool flag4 = num2 >= 0 && num2 < Player.vecMaxLevelAttri.size();
				if (flag4)
				{
					this.idSelect = num2;
					bool flag5 = Player.pointMaxLevelAttri > 0;
					if (flag5)
					{
						this.setAction(this.idSelect);
					}
				}
				GameCanvas.isPointerSelect = false;
			}
		}
	}

	// Token: 0x06000DD0 RID: 3536 RVA: 0x0010AE50 File Offset: 0x00109050
	private void setAction(int ac)
	{
		bool flag = ac >= 0 && ac < Player.vecMaxLevelAttri.size();
		if (flag)
		{
			MaxLevelAttribute maxLevelAttribute = (MaxLevelAttribute)Player.vecMaxLevelAttri.elementAt(ac);
			GlobalService.gI().One_Point_Max_Level(0, (short)maxLevelAttribute.Id);
		}
	}

	// Token: 0x04001528 RID: 5416
	private int w;

	// Token: 0x04001529 RID: 5417
	private int h;

	// Token: 0x0400152A RID: 5418
	private int x;

	// Token: 0x0400152B RID: 5419
	private int y;

	// Token: 0x0400152C RID: 5420
	private int wItemCur;

	// Token: 0x0400152D RID: 5421
	private int idSelect;

	// Token: 0x0400152E RID: 5422
	public static ScreenMaxLevel instance;

	// Token: 0x0400152F RID: 5423
	public ListNew list;

	// Token: 0x04001530 RID: 5424
	private iCommand cmdClose;
}
