using System;

// Token: 0x0200005E RID: 94
public class ItemHair : MainItem
{
	// Token: 0x0600062D RID: 1581 RVA: 0x0008B364 File Offset: 0x00089564
	public ItemHair(short ID, short IDIcon, string name, sbyte typeObject)
	{
		this.ID = ID;
		this.idIcon = IDIcon;
		this.typeObject = typeObject;
		this.name = name;
		this.namepaint = name;
		bool flag = typeObject == 103;
		if (flag)
		{
			this.typePart = 5;
		}
		else
		{
			this.typePart = 0;
		}
	}

	// Token: 0x0600062E RID: 1582 RVA: 0x0008B3BC File Offset: 0x000895BC
	public override void paint(mGraphics g, int x, int y, int w)
	{
		this.value = this.idIcon;
		bool flag = this.idIcon == -1;
		if (flag)
		{
			this.value = 0;
		}
		MainObject.paintOnePart(g, (int)this.value, (int)this.typePart, x, y, 2);
	}

	// Token: 0x0600062F RID: 1583 RVA: 0x0008B404 File Offset: 0x00089604
	public override mVector getActionShop(sbyte typeShop)
	{
		mVector mVector = new mVector();
		bool flag = this.price == 0 && this.priceRuby == 0;
		if (flag)
		{
			mVector.addElement(TabShop.cmdUse);
		}
		else
		{
			mVector.addElement(TabShop.cmdBuyHair);
		}
		return mVector;
	}

	// Token: 0x040008E2 RID: 2274
	private sbyte typePart;
}
