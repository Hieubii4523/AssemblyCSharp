using System;

// Token: 0x0200006A RID: 106
public class ListDungeon : PaintListScreen
{
	// Token: 0x06000678 RID: 1656 RVA: 0x0008EADC File Offset: 0x0008CCDC
	public ListDungeon(sbyte type, mVector vec, string name) : base(type, vec, name, 180, 180)
	{
		this.cmdReady = new iCommand(T.ready, 0, this);
		this.cmdCancle = new iCommand(T.cancel, 1, this);
		this.vecMenu.removeAllElements();
		bool flag = ListDungeon.isKey;
		if (flag)
		{
			this.cmdReady.caption = T.start;
		}
		this.right = null;
		this.vecMenu.addElement(this.cmdReady);
		this.vecMenu.addElement(this.cmdCancle);
		this.setPosCmdNew(0, this.vecMenu);
	}

	// Token: 0x06000679 RID: 1657 RVA: 0x0008EB84 File Offset: 0x0008CD84
	public override void commandPointer(int index, int subIndex)
	{
		if (index != 0)
		{
			if (index != 1)
			{
				base.commandPointer(index, subIndex);
			}
			else
			{
				GlobalService.gI().Check_List_Pho_Bang(2);
				GameCanvas.gameScr.Show();
			}
		}
		else
		{
			GlobalService.gI().Check_List_Pho_Bang(1);
		}
	}

	// Token: 0x0600067A RID: 1658 RVA: 0x0008EBD4 File Offset: 0x0008CDD4
	public override void paintInfo(mGraphics g, InfoMemList mem, int xpaint, int ypaint, int i, int wsub)
	{
		string text = mem.name;
		bool flag = mem.Lv >= 0;
		if (flag)
		{
			text = text + " - " + mem.Lv.ToString();
		}
		g.drawImage(AvMain.imgBorderCombo, xpaint + 8, ypaint + 6, 3);
		bool flag2 = mem.typeOnline == 1;
		if (flag2)
		{
			AvMain.fraCheck.drawFrame(2, xpaint + 8, ypaint + 6, 0, 3, g);
		}
		bool flag3 = mem.typeOnline == 2;
		if (flag3)
		{
			AvMain.fraCheck.drawFrame(1, xpaint + 8, ypaint + 6, 0, 3, g);
		}
		AvMain.Font3dColor(g, text, xpaint + 20, ypaint, 0, 0, 7);
		mFont.tahoma_7_black.drawString(g, LoadMap.getNameMap((int)mem.idmap), xpaint + this.miniItem, ypaint + 17, 0);
	}

	// Token: 0x0400094E RID: 2382
	private iCommand cmdReady;

	// Token: 0x0400094F RID: 2383
	private iCommand cmdCancle;

	// Token: 0x04000950 RID: 2384
	public static mVector vecDungeon = new mVector("ListDungeon.vecDungeon");

	// Token: 0x04000951 RID: 2385
	public static bool isKey = false;

	// Token: 0x04000952 RID: 2386
	public static ListDungeon instance;
}
