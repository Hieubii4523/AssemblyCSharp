using System;

// Token: 0x0200005F RID: 95
public class ItemHead : MainItem
{
	// Token: 0x06000630 RID: 1584 RVA: 0x0000A595 File Offset: 0x00008795
	public ItemHead(short ID, short IDIcon, string name)
	{
		this.ID = ID;
		this.idIcon = IDIcon;
		this.typeObject = 103;
		this.name = name;
		this.namepaint = name;
	}

	// Token: 0x06000631 RID: 1585 RVA: 0x0008B454 File Offset: 0x00089654
	public override void paint(mGraphics g, int x, int y, int w)
	{
		this.value = this.idIcon;
		bool flag = this.idIcon == -1;
		if (flag)
		{
			this.value = 0;
		}
		MainObject.paintOnePart(g, (int)this.value, 5, x, y, 2);
	}

	// Token: 0x06000632 RID: 1586 RVA: 0x0008B404 File Offset: 0x00089604
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
}
