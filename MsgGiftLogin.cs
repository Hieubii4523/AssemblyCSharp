using System;

// Token: 0x020000A5 RID: 165
public class MsgGiftLogin : MsgDialog
{
	// Token: 0x06000A2E RID: 2606 RVA: 0x000CE3E4 File Offset: 0x000CC5E4
	public void setinfoShow_GiftLogin(sbyte type, string name, string info, Item_Drop[] mitem, sbyte action, string nameCmd, MainItem itemMain)
	{
		this.type = (int)type;
		this.mItemgift = mitem;
		this.nameDialog = name;
		this.itemMain = itemMain;
		this.wItem = 46;
		this.wItemInterface = 22;
		this.wDia = 212;
		bool flag = this.wDia > MotherCanvas.w;
		if (flag)
		{
			this.wDia = MotherCanvas.w;
		}
		bool flag2 = mitem.Length < 4;
		if (flag2)
		{
			this.wDia = mitem.Length * 46 + 28;
		}
		this.hDia = ((mitem.Length - 1) / 4 + 2) * 46 + 5;
		bool flag3 = this.hDia > 200;
		if (flag3)
		{
			this.hDia = 200;
		}
		this.maxWShow = this.wDia;
		this.xDia = MotherCanvas.hw - this.wDia / 2;
		this.yDia = MotherCanvas.hh - this.hDia / 2 - 5;
		bool flag4 = mitem.Length / 4 >= 3;
		if (flag4)
		{
			int num = this.hDia - this.wItemInterface - this.wItemInterface / 2 - 10;
			this.list = new ListNew(this.xDia, this.wItemInterface + 10, this.wDia, num, 0, 0, ((mitem.Length - 1) / 4 + 1) * this.wItem - (num - 5), false);
		}
		iCommand iCommand = new iCommand(nameCmd, 14, (int)action, this);
		this.cmdList.addElement(iCommand);
		this.cmdClose = new iCommand(T.close, 10, this);
		bool flag5 = type == MsgGiftLogin.TYPE_BOX_CHOICE;
		if (flag5)
		{
			this.cmdClose = new iCommand(T.close, -1, this);
		}
		this.cmdList.addElement(this.cmdClose);
		bool flag6 = GameCanvas.isTouchNoOrPC();
		if (flag6)
		{
			this.center = iCommand;
			this.right = this.cmdClose;
			this.cmdClose = AvMain.setPosCMD(this.cmdClose, 2);
		}
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.cmdClose.setPos(this.xDia + this.wDia - 20, this.yDia + 19, MainTab.fraCloseTab, string.Empty);
		}
		iCommand = AvMain.setPosCMD(iCommand, 0);
		this.wShowPaper = this.wDia;
		this.idSelect = -1;
	}

	// Token: 0x06000A2F RID: 2607 RVA: 0x000CE624 File Offset: 0x000CC824
	public override void commandPointer(int index, int subIndex)
	{
		if (index != 14)
		{
			if (index != 16)
			{
				base.commandPointer(index, subIndex);
			}
			else
			{
				bool flag = this.itemMain != null;
				if (flag)
				{
					GlobalService.gI().Use_Item_BOX_CHOICE(this.itemMain.ID, this.itemMain.typeObject, (sbyte)this.idSelect);
				}
				GameCanvas.end_Dialog();
			}
		}
		else
		{
			bool flag2 = this.type == (int)MsgGiftLogin.TYPE_DAILY_GIFT;
			if (flag2)
			{
				GlobalService.gI().Daily_Login((sbyte)subIndex);
			}
			else
			{
				bool flag3 = this.type == (int)MsgGiftLogin.TYPE_BOX_CHOICE;
				if (flag3)
				{
					bool flag4 = this.idSelect >= 0 && this.idSelect <= this.mItemgift.Length - 1;
					if (flag4)
					{
						string[] args = new string[]
						{
							this.mItemgift[this.idSelect].name,
							this.itemMain.name
						};
						mVector mVector = new mVector();
						iCommand o = new iCommand(T.strconfirm, 16, this);
						mVector.addElement(o);
						GameCanvas.Start_Normal_DiaLog(GameMidlet.format(T.hoidoiqua, args), mVector, true);
					}
					else
					{
						GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.chuachonqua);
					}
				}
			}
		}
	}

	// Token: 0x06000A30 RID: 2608 RVA: 0x000CE76C File Offset: 0x000CC96C
	public override void paint(mGraphics g)
	{
		base.paintPaper(g, MotherCanvas.hw - this.wShowPaper / 2, this.yDia, this.wShowPaper, this.hDia, this.maxWShow, (int)AvMain.PAPER_NORMAL);
		GameCanvas.resetTrans(g);
		int num = this.yDia + this.wItemInterface + 10;
		this.paintBanner(g);
		AvMain.FontBorderColor(g, this.nameDialog, this.xDia + this.wDia / 2, this.yDia + 15, 2, 6, 5);
		AvMain.paintRect(g, this.xDia + 10, num, this.wDia - 20, this.hDia - this.wItemInterface - this.wItemInterface / 2 - 10, 0, 4);
		g.setClip(MotherCanvas.hw - this.wShowPaper / 2, num + 2, this.wShowPaper, this.hDia - this.wItemInterface - this.wItemInterface / 2 - 14);
		g.saveCanvas();
		g.ClipRec(MotherCanvas.hw - this.wShowPaper / 2, num + 2, this.wShowPaper, this.hDia - this.wItemInterface - this.wItemInterface / 2 - 14);
		bool flag = this.list != null;
		if (flag)
		{
			g.translate(0, -this.list.cmx);
		}
		for (int i = 0; i < this.mItemgift.Length; i++)
		{
			bool flag2 = this.list != null && (i / 4 < this.list.cmx / this.wItem || i / 4 >= (this.list.cmx + this.wItem / 2) / this.wItem + 4);
			if (!flag2)
			{
				int num2 = this.xDia + 14 + this.wItem / 2 + i % 4 * this.wItem + 2;
				int num3 = num + this.wItem / 2 + i / 4 * this.wItem + 5;
				Item_Drop item_Drop = this.mItemgift[i];
				sbyte index = 1;
				int color = 8148796;
				bool flag3 = item_Drop.typeGiftDaily == 1 || (this.type == (int)MsgGiftLogin.TYPE_BOX_CHOICE && this.idSelect == i);
				if (flag3)
				{
					index = 2;
					color = 2087750;
				}
				AvMain.paintImgButton(g, num2 - this.wItem / 2, num3 - this.wItem / 2, this.wItem - 4, this.wItem - 4, (int)index);
				bool flag4 = item_Drop.IdIcon >= 0;
				if (flag4)
				{
					item_Drop.paintXY(g, num2 + 3, num3 - 8);
					bool flag5 = item_Drop.typeGiftDaily == 2;
					if (flag5)
					{
						MsgDialog.fraAutoMpHp.drawFrame(4, num2 - 9, num3 - 8, 0, 3, g);
					}
					else
					{
						mFont.tahoma_7b_white.drawString(g, item_Drop.num.ToString() + string.Empty, num2 - 13, num3 - 12, 2);
					}
					g.setColor(color);
					g.fillRoundRect(num2 - this.wItem / 2 + 2, num3 + this.wItem / 2 - 15, this.wItem - 8, 10, 4, 4);
					mFont.tahoma_7_white.drawString(g, item_Drop.name, num2 - 2, num3 + this.wItem / 2 - 16, 2);
				}
			}
		}
		mGraphics.resetTransAndroid(g);
		g.restoreCanvas();
		GameCanvas.resetTrans(g);
		for (int j = 0; j < this.cmdList.size(); j++)
		{
			iCommand iCommand = (iCommand)this.cmdList.elementAt(j);
			iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
		}
	}

	// Token: 0x06000A31 RID: 2609 RVA: 0x0000B3CA File Offset: 0x000095CA
	private void paintBanner(mGraphics g)
	{
		g.setColor(15972174);
		g.fillRoundRect(this.xDia + 20, this.yDia + 12, this.wDia - 40, 16, 4, 4);
	}

	// Token: 0x06000A32 RID: 2610 RVA: 0x000CEB2C File Offset: 0x000CCD2C
	public override void update()
	{
		bool flag = this.list != null;
		if (flag)
		{
			this.list.moveCamera();
		}
		bool isClose = this.isClose;
		if (isClose)
		{
			base.updateClose();
		}
		else
		{
			base.updateOpen();
			bool flag2 = GameCanvas.isTouchNoOrPC();
			if (flag2)
			{
				this.updatekey();
			}
			this.updatePointer();
		}
	}

	// Token: 0x06000A33 RID: 2611 RVA: 0x000CEB8C File Offset: 0x000CCD8C
	public override void updatekey()
	{
		bool flag = this.list != null;
		if (flag)
		{
			bool flag2 = GameCanvas.keyMove(1);
			if (flag2)
			{
				GameCanvas.ClearkeyMove(1);
				this.list.setToX(this.list.cmtoX - GameCanvas.hText);
			}
			else
			{
				bool flag3 = GameCanvas.keyMove(3);
				if (flag3)
				{
					GameCanvas.ClearkeyMove(3);
					this.list.setToX(this.list.cmtoX + GameCanvas.hText);
				}
			}
		}
		bool flag4 = this.type == (int)MsgGiftLogin.TYPE_BOX_CHOICE;
		if (flag4)
		{
			bool flag5 = GameCanvas.keyMove(0);
			if (flag5)
			{
				GameCanvas.ClearkeyMove(0);
				bool flag6 = this.idSelect > 0;
				if (flag6)
				{
					this.idSelect--;
				}
				bool flag7 = this.idSelect == -1;
				if (flag7)
				{
					this.idSelect = 0;
				}
			}
			else
			{
				bool flag8 = GameCanvas.keyMove(2);
				if (flag8)
				{
					GameCanvas.ClearkeyMove(2);
					bool flag9 = this.idSelect < this.mItemgift.Length - 1;
					if (flag9)
					{
						this.idSelect++;
					}
				}
			}
		}
		this.updatekeyCMD();
	}

	// Token: 0x06000A34 RID: 2612 RVA: 0x000CECB4 File Offset: 0x000CCEB4
	public override void updatePointer()
	{
		bool flag = this.list != null;
		if (flag)
		{
			this.list.update_Pos_UP_DOWN();
		}
		bool flag2 = this.type == (int)MsgGiftLogin.TYPE_BOX_CHOICE;
		if (flag2)
		{
			int num = this.yDia + this.wItemInterface + 10;
			for (int i = 0; i < this.mItemgift.Length; i++)
			{
				int x = this.xDia + 14 + i % 4 * this.wItem + 2;
				int y = num + i / 4 * this.wItem + 5;
				bool flag3 = GameCanvas.isPointSelect(x, y, this.wItem, this.wItem);
				if (flag3)
				{
					this.idSelect = i;
				}
			}
		}
		base.updatePointer();
	}

	// Token: 0x04001002 RID: 4098
	private Item_Drop[] mItemgift;

	// Token: 0x04001003 RID: 4099
	private int wItemInterface = 22;

	// Token: 0x04001004 RID: 4100
	private MainItem itemMain;

	// Token: 0x04001005 RID: 4101
	public static sbyte TYPE_DAILY_GIFT;

	// Token: 0x04001006 RID: 4102
	public static sbyte TYPE_BOX_CHOICE = 1;
}
