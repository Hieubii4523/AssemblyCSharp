using System;

// Token: 0x02000060 RID: 96
public class ItemHuyHieu : MainItem
{
	// Token: 0x06000633 RID: 1587 RVA: 0x0000A5C3 File Offset: 0x000087C3
	public ItemHuyHieu(short ID, short IDIcon, string name, string info)
	{
		this.ID = ID;
		this.idIcon = IDIcon;
		this.typeObject = 107;
		this.name = name;
		this.info = info;
		this.namepaint = name;
	}

	// Token: 0x06000634 RID: 1588 RVA: 0x0008B498 File Offset: 0x00089698
	public override void paint(mGraphics g, int x, int y, int w)
	{
		base.paintColor(g, x, y, w);
		MainImage iconClan = Potion.getIconClan(this.idIcon);
		bool flag = iconClan != null && iconClan.img != null;
		if (flag)
		{
			base.paintImgItem(g, iconClan, x, y);
		}
		else
		{
			AvMain.imgLoadImage.drawFrame(GameCanvas.gameTick % AvMain.imgLoadImage.nFrame, x, y, 0, 3, g);
		}
	}

	// Token: 0x06000635 RID: 1589 RVA: 0x0008B504 File Offset: 0x00089704
	public override mVector getActionInven(sbyte typeShop)
	{
		mVector mVector = new mVector();
		bool flag = this.colorName == 1;
		if (flag)
		{
			mVector.addElement(GameCanvas.tabInvenClan.cmdDonotUse);
		}
		else
		{
			mVector.addElement(GameCanvas.tabInvenClan.cmdUsePotion);
		}
		return mVector;
	}
}
