using System;

// Token: 0x0200000B RID: 11
public class BlackList : PaintListScreen
{
	// Token: 0x0600005D RID: 93 RVA: 0x000091DA File Offset: 0x000073DA
	public BlackList(sbyte type, mVector vec, string name, sbyte page) : base(type, vec, name, 200, 180)
	{
		this.page = page;
		this.cmdUpdateBlackList = new iCommand(T.update, 14, this);
	}

	// Token: 0x0600005E RID: 94 RVA: 0x00012AD0 File Offset: 0x00010CD0
	public override void commandPointer(int index, int subIndex)
	{
		bool flag = index == 14;
		if (flag)
		{
			GameCanvas.gameScr.cmdBlackList.perform();
			this.isLoad = true;
		}
		else
		{
			base.commandPointer(index, subIndex);
		}
	}

	// Token: 0x0600005F RID: 95 RVA: 0x00012B10 File Offset: 0x00010D10
	public override void doMenuTouchPlayer()
	{
		bool flag = this.vecPlayer.size() == 0;
		if (!flag)
		{
			this.memCur = (InfoMemList)this.vecPlayer.elementAt(this.idSelect);
			bool flag2 = this.memCur != null && this.memCur.id != (int)GameScreen.player.ID;
			if (flag2)
			{
				mVector mVector = new mVector();
				mVector.addElement(this.cmdInfoPlayer);
				mVector.addElement(this.cmdMove);
				bool flag3 = mVector.size() > 0;
				if (flag3)
				{
					GameCanvas.menu.startAt(mVector, 2, this.memCur.name);
				}
			}
		}
	}

	// Token: 0x06000060 RID: 96 RVA: 0x00012BC4 File Offset: 0x00010DC4
	public override void doMenu()
	{
		mVector mVector = new mVector();
		string name = T.menu;
		bool flag = this.vecPlayer.size() > 0;
		if (flag)
		{
			this.memCur = (InfoMemList)this.vecPlayer.elementAt(this.idSelect);
			bool flag2 = this.memCur != null && !GameCanvas.isTouch;
			if (flag2)
			{
				mVector.addElement(this.cmdInfoPlayer);
				name = this.memCur.name;
			}
		}
		mVector.addElement(this.cmdUpdateBlackList);
		bool flag3 = !GameCanvas.isTouch;
		if (flag3)
		{
			mVector.addElement(this.cmdMove);
		}
		GameCanvas.menu.startAt(mVector, 2, name);
	}

	// Token: 0x06000061 RID: 97 RVA: 0x00012C78 File Offset: 0x00010E78
	public override void paintInfo(mGraphics g, InfoMemList mem, int xpaint, int ypaint, int i, int wsub)
	{
		bool flag = mem != null;
		if (flag)
		{
			string text = mem.name;
			bool flag2 = mem.Lv >= 0;
			if (flag2)
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" - ",
					T.Lv,
					" ",
					mem.Lv.ToString()
				});
			}
			AvMain.fraStatusOnline.drawFrame((int)mem.typeOnline, xpaint + 25, ypaint + 5, 0, 3, g);
			mFont.tahoma_7b_black.drawString(g, text, xpaint + 30, ypaint, 0);
			mFont.tahoma_7_black.drawString(g, mem.info, xpaint + 25, ypaint + GameCanvas.hText, 0);
			MainObject.paintHeadEveryWhere(g, mem.head, mem.hair, mem.hat, xpaint + 10, ypaint + this.hItem / 2 + 32, 0);
		}
	}

	// Token: 0x040000DF RID: 223
	private iCommand cmdUpdateBlackList;

	// Token: 0x040000E0 RID: 224
	private sbyte page;

	// Token: 0x040000E1 RID: 225
	public static BlackList instance;
}
