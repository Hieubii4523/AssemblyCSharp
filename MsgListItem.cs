using System;

// Token: 0x020000A8 RID: 168
public class MsgListItem : MsgDialog
{
	// Token: 0x06000A43 RID: 2627 RVA: 0x000D0408 File Offset: 0x000CE608
	public override void commandPointer(int index, int subIndex)
	{
		bool flag = index == 3;
		if (flag)
		{
			MainItem mainItem = (MainItem)this.listItem.elementAt(this.idSelect);
			bool flag2 = mainItem != null;
			if (flag2)
			{
				GlobalService.gI().Use_Item(mainItem.ID, mainItem.typeObject);
				GameCanvas.end_Dialog();
			}
		}
		else
		{
			base.commandPointer(index, subIndex);
		}
	}

	// Token: 0x06000A44 RID: 2628 RVA: 0x000D046C File Offset: 0x000CE66C
	public void setinfoListItem(mVector vec, int x, int y, int wItem, int dir)
	{
		this.dir = dir;
		this.listItem = vec;
		bool flag = this.listItem != null && this.listItem.size() != 0;
		if (flag)
		{
			this.cmdClose = new iCommand(T.close, -1, this);
			this.cmdClose = AvMain.setPosCMD(this.cmdClose, 2);
			this.cmdChangeEquip = new iCommand(T.tabEquip, 3, this);
			this.cmdChangeEquip = AvMain.setPosCMD(this.cmdChangeEquip, 0);
			this.wDia = wItem;
			this.hDia = this.listItem.size() * wItem;
			bool flag2 = this.hDia > wItem * 5;
			if (flag2)
			{
				this.hDia = wItem * 5;
			}
			this.xDia = x + wItem + 2;
			bool flag3 = dir == 0;
			if (flag3)
			{
				this.xDia = x - wItem - 4;
			}
			this.yDia = y - this.hDia / 2;
			bool flag4 = this.yDia < 2;
			if (flag4)
			{
				this.yDia = 2;
			}
			bool flag5 = this.yDia + this.hDia + 2 > MotherCanvas.h - GameCanvas.hCommand;
			if (flag5)
			{
				this.yDia = MotherCanvas.h - this.hDia - 2 - GameCanvas.hCommand;
			}
			this.list = new ListNew(this.xDia, this.yDia, this.wDia, this.hDia, 0, 0, this.listItem.size() * wItem - this.hDia, true);
			this.wItem = wItem;
			bool flag6 = GameCanvas.isTouchNoOrPC();
			if (flag6)
			{
				this.idSelect = 0;
				this.updateInfo();
				this.right = this.cmdClose;
				this.center = this.cmdChangeEquip;
				this.backCMD = this.right;
				this.okCMD = this.cmdChangeEquip;
			}
			else
			{
				this.idSelect = -1;
			}
		}
	}

	// Token: 0x06000A45 RID: 2629 RVA: 0x000D064C File Offset: 0x000CE84C
	public override void paint(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		AvMain.paintRect(g, this.xDia - 2, this.yDia - 2, this.wDia + 2, this.hDia + 2, 1, 2);
		g.setClip(this.xDia, this.yDia, this.wDia, this.hDia);
		g.saveCanvas();
		g.ClipRec(this.xDia, this.yDia, this.wDia, this.hDia);
		g.translate(0, -this.list.cmx);
		int num = this.list.cmx / this.wItem - 1;
		int num2 = num + this.hDia / this.wItem + 2;
		for (int i = num; i < num2; i++)
		{
			bool flag = i >= 0 && i < this.listItem.size();
			if (flag)
			{
				MainItem mainItem = (MainItem)this.listItem.elementAt(i);
				mainItem.paintColor(g, this.xDia + this.wItem / 2, this.yDia + this.wItem / 2 + i * this.wItem, this.wItem - 3);
				mainItem.paintEffSub(g, this.xDia + this.wItem / 2, this.yDia + this.wItem / 2 + i * this.wItem, this.wItem - 2, 1);
				mainItem.paintEff_LvUp(g, this.xDia + this.wItem / 2, this.yDia + this.wItem / 2 + i * this.wItem, this.wItem - 2, 1);
				AvMain.paintDrawRect(g, this.xDia + 1, this.yDia + 1 + this.wItem / 2 - this.wItem / 2 + i * this.wItem, this.wItem - 3, this.wItem - 3);
				bool flag2 = i == this.idSelect;
				if (flag2)
				{
					g.setColor(16777215);
					g.drawRect(this.xDia + 1, this.yDia + this.wItem / 2 - this.wItem / 2 + 1 + i * this.wItem, this.wItem - 4, this.wItem - 4);
					g.setColor(14353458);
					g.drawRect(this.xDia, this.yDia + this.wItem / 2 - this.wItem / 2 + i * this.wItem, this.wItem - 2, this.wItem - 2);
				}
			}
		}
		mGraphics.resetTransAndroid(g);
		g.restoreCanvas();
		GameCanvas.resetTrans(g);
		bool flag3 = this.itemCur != null;
		if (flag3)
		{
			MainTab.paintInfoEveryWhere(g, this.itemCur, this.vecInfoSS, 0, this.xInfo, this.yInfo, this.wInfo, this.hInfo, false, null, 0);
		}
		bool flag4 = !GameCanvas.menuCur.isShowMenu;
		if (flag4)
		{
			base.paintCmd(g);
		}
		bool flag5 = this.cmdList != null;
		if (flag5)
		{
			for (int j = 0; j < this.cmdList.size(); j++)
			{
				iCommand iCommand = (iCommand)this.cmdList.elementAt(j);
				iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
			}
		}
	}

	// Token: 0x06000A46 RID: 2630 RVA: 0x000D09C0 File Offset: 0x000CEBC0
	public override void update()
	{
		bool flag = this.list != null;
		if (flag)
		{
			this.list.moveCamera();
		}
		this.updatekey();
		this.updatePointer();
	}

	// Token: 0x06000A47 RID: 2631 RVA: 0x000D09F8 File Offset: 0x000CEBF8
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
		}
		bool flag4 = flag;
		if (flag4)
		{
			this.idSelect = AvMain.resetSelect(this.idSelect, this.listItem.size() - 1, false);
			this.updateInfo();
			this.list.setToX((this.idSelect + 1) * this.wItem - this.wDia / 2);
		}
		base.updatekey();
		this.updatekeyPC();
	}

	// Token: 0x06000A48 RID: 2632 RVA: 0x000D0AB0 File Offset: 0x000CECB0
	public override void updatePointer()
	{
		this.list.update_Pos_UP_DOWN();
		bool flag = GameCanvas.isPointSelect(this.xDia, this.yDia, this.wDia, this.hDia);
		if (flag)
		{
			int num = (GameCanvas.py - this.yDia + this.list.cmx) / this.wItem;
			bool flag2 = num == this.idSelect;
			if (flag2)
			{
				this.cmdChangeEquip.perform();
			}
			else
			{
				bool flag3 = num >= 0 && num < this.listItem.size();
				if (flag3)
				{
					this.idSelect = num;
					this.updateInfo();
				}
			}
			GameCanvas.isPointerSelect = false;
		}
		bool flag4 = GameCanvas.isPointerSelect && !GameCanvas.isPoint(this.xDia, this.yDia, this.wDia, this.hDia);
		if (flag4)
		{
			this.cmdClose.perform();
		}
	}

	// Token: 0x06000A49 RID: 2633 RVA: 0x000D0B98 File Offset: 0x000CED98
	public void setPosInfo()
	{
		int num = this.wItem * 2 + this.wInfo / 2;
		bool flag = this.dir == 0;
		if (flag)
		{
			num = -this.wItem - this.wInfo / 2 - 2;
		}
		this.setPosInfo(this.itemCur, this.xDia + num, this.yDia);
	}

	// Token: 0x06000A4A RID: 2634 RVA: 0x000D0BF8 File Offset: 0x000CEDF8
	public void setPosInfo(MainItem item, int xbe, int ybe)
	{
		int num = this.wInfo;
		int num2 = this.hInfo;
		bool flag = item != null;
		if (flag)
		{
			num = item.wInfo;
			num2 = item.hInfo;
		}
		this.xInfo = xbe - num / 2;
		bool flag2 = this.xInfo + num > MotherCanvas.w - 8;
		if (flag2)
		{
			this.xInfo = MotherCanvas.w - num - 8;
		}
		bool flag3 = this.xInfo < 8;
		if (flag3)
		{
			this.xInfo = 8;
		}
		this.yInfo = ybe;
		bool flag4 = this.yInfo + num2 > MotherCanvas.h - GameCanvas.hCommand - 8;
		if (flag4)
		{
			this.yInfo = MotherCanvas.h - GameCanvas.hCommand - num2 - 8;
		}
		bool flag5 = this.yInfo < 8;
		if (flag5)
		{
			this.yInfo = 8;
		}
	}

	// Token: 0x06000A4B RID: 2635 RVA: 0x000D0CC8 File Offset: 0x000CEEC8
	public void updateInfo()
	{
		bool flag = this.idSelect < 0 || this.idSelect >= this.listItem.size();
		if (flag)
		{
			this.itemCur = null;
		}
		else
		{
			MainItem mainItem = (MainItem)this.listItem.elementAt(this.idSelect);
			bool flag2 = mainItem != null;
			if (flag2)
			{
				this.itemCur = mainItem;
				this.vecInfoSS = MainItem.getInfoSS(this.itemCur);
				this.setPosInfo();
			}
		}
	}

	// Token: 0x04001025 RID: 4133
	private mVector listItem;

	// Token: 0x04001026 RID: 4134
	private MainItem itemCur;

	// Token: 0x04001027 RID: 4135
	private mVector vecInfoSS;

	// Token: 0x04001028 RID: 4136
	private int xInfo;

	// Token: 0x04001029 RID: 4137
	private int yInfo;

	// Token: 0x0400102A RID: 4138
	private int wInfo = 100;

	// Token: 0x0400102B RID: 4139
	private int hInfo = 40;

	// Token: 0x0400102C RID: 4140
	private int dir;
}
