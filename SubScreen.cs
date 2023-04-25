using System;

// Token: 0x020000F6 RID: 246
public class SubScreen : MainScreen
{
	// Token: 0x06000E7E RID: 3710 RVA: 0x0000BF93 File Offset: 0x0000A193
	public SubScreen(sbyte type)
	{
		this.type = type;
	}

	// Token: 0x06000E7F RID: 3711 RVA: 0x000092E5 File Offset: 0x000074E5
	public override void setxyPlus12()
	{
		GameCanvas.xPlus12 = 2;
		GameCanvas.yPlus12 = 2;
	}

	// Token: 0x06000E80 RID: 3712 RVA: 0x001174F8 File Offset: 0x001156F8
	public virtual void setPosCmdNew(int yplus, mVector vecMenu)
	{
		bool flag = vecMenu == null || vecMenu.size() <= 0;
		if (!flag)
		{
			int num = vecMenu.size();
			int num2 = num;
			int num3 = num2;
			if (num3 != 1)
			{
				if (num3 != 2)
				{
					this.w2cmd = 10;
					this.xBegin = this.xSub + this.wSub / 2 - this.w2cmd / 2 - iCommand.wButtonCmd / 2;
				}
				else
				{
					this.w2cmd = 10;
					this.xBegin = this.xSub + this.wSub / 2 - this.w2cmd / 2 - iCommand.wButtonCmd / 2;
				}
			}
			else
			{
				this.xBegin = this.xSub + this.wSub / 2;
				this.w2cmd = 0;
			}
			for (int i = 0; i < num; i++)
			{
				iCommand iCommand = (iCommand)vecMenu.elementAt(i);
				iCommand.isSelect = false;
				bool flag2 = num == 3 && i == 2;
				if (flag2)
				{
					iCommand.setPos(this.xSub + this.wSub / 2, this.ySub + this.hSub - iCommand.hButtonCmdNor - (num - 1) / 2 * (iCommand.hButtonCmdNor + 5) + iCommand.hButtonCmdNor / 2 + 2 + i / 2 * (iCommand.hButtonCmdNor + 5) + yplus - 5, null, iCommand.caption);
				}
				else
				{
					iCommand.setPos(this.xBegin + i % 2 * (iCommand.wButtonCmd + this.w2cmd), this.ySub + this.hSub - iCommand.hButtonCmdNor / 2 - ((num - 1) / 2 * iCommand.hButtonCmdNor + 5) + 2 + i / 2 * (iCommand.hButtonCmdNor + 5) + yplus - 5, null, iCommand.caption);
				}
				bool flag3 = i == 0 && !GameCanvas.isTouch;
				if (flag3)
				{
					iCommand.isSelect = true;
				}
			}
		}
	}

	// Token: 0x06000E81 RID: 3713 RVA: 0x001176DC File Offset: 0x001158DC
	public void setPosVecMenu(mVector vecMenu)
	{
		bool flag = vecMenu == null || vecMenu.size() <= 0;
		if (!flag)
		{
			int num = vecMenu.size();
			int num2 = num;
			int num3 = num2;
			if (num3 != 1)
			{
				if (num3 != 2)
				{
					this.w2cmd = 10;
					this.xBegin = this.xSub + this.wSub / 2 - this.w2cmd / 2 - iCommand.wButtonCmd / 2;
				}
				else
				{
					this.w2cmd = 10;
					this.xBegin = this.xSub + this.wSub / 2 - this.w2cmd / 2 - iCommand.wButtonCmd / 2;
				}
			}
			else
			{
				this.xBegin = this.xSub + this.wSub / 2;
				this.w2cmd = 0;
			}
			for (int i = 0; i < num; i++)
			{
				iCommand iCommand = (iCommand)vecMenu.elementAt(i);
				iCommand.isSelect = false;
				bool flag2 = num == 3 && i == 2;
				if (flag2)
				{
					iCommand.setPos(this.xSub + this.wSub / 2, MotherCanvas.h - iCommand.hButtonCmdNor / 2 + 2, null, iCommand.caption);
				}
				else
				{
					iCommand.setPos(this.xBegin + i % 2 * (iCommand.wButtonCmd + this.w2cmd), MotherCanvas.h - iCommand.hButtonCmdNor / 2 + 2, null, iCommand.caption);
				}
				bool flag3 = i == 0 && !GameCanvas.isTouch;
				if (flag3)
				{
					iCommand.isSelect = true;
				}
			}
		}
	}

	// Token: 0x06000E82 RID: 3714 RVA: 0x000090B5 File Offset: 0x000072B5
	public override void commandPointer(int index, int subIndex)
	{
	}

	// Token: 0x06000E83 RID: 3715 RVA: 0x000090B5 File Offset: 0x000072B5
	public override void paint(mGraphics g)
	{
	}

	// Token: 0x0400164B RID: 5707
	public sbyte type;

	// Token: 0x0400164C RID: 5708
	public int xSub;

	// Token: 0x0400164D RID: 5709
	public int ySub;

	// Token: 0x0400164E RID: 5710
	public int wSub;

	// Token: 0x0400164F RID: 5711
	public int hSub;

	// Token: 0x04001650 RID: 5712
	public int hItem;

	// Token: 0x04001651 RID: 5713
	public int xBegin;

	// Token: 0x04001652 RID: 5714
	public int w2cmd;
}
