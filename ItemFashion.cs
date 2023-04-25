using System;

// Token: 0x0200005D RID: 93
public class ItemFashion : MainItem
{
	// Token: 0x0600062A RID: 1578 RVA: 0x0000A557 File Offset: 0x00008757
	public ItemFashion(short ID, short IDIcon, string name, string info, short[] wear)
	{
		this.ID = ID;
		this.idIcon = IDIcon;
		this.typeObject = 105;
		this.name = name;
		this.info = info;
		this.namepaint = name;
		this.mWearing = wear;
	}

	// Token: 0x0600062B RID: 1579 RVA: 0x0008B228 File Offset: 0x00089428
	public override void paint(mGraphics g, int x, int y, int w)
	{
		MainImage imageAll = base.getImageAll();
		base.paintColor(g, x, y, w);
		bool flag = imageAll != null && imageAll.img != null;
		if (flag)
		{
			base.paintImgItem(g, imageAll, x, y);
		}
		else
		{
			AvMain.imgLoadImage.drawFrame(GameCanvas.gameTick % AvMain.imgLoadImage.nFrame, x, y, 0, 3, g);
		}
		bool flag2 = this.LvUpgrade > 0;
		if (flag2)
		{
			AvMain.FontBorderColor(g, "+" + this.LvUpgrade.ToString(), x + MainTab.wItem / 2 - 2, y + MainTab.wItem / 2 - 9 - 2, 1, 6, 0);
		}
	}

	// Token: 0x0600062C RID: 1580 RVA: 0x0008B2D4 File Offset: 0x000894D4
	public override mVector getActionShop(sbyte typeShop)
	{
		mVector mVector = new mVector();
		bool flag = typeShop != 114 || this.price != 0 || this.priceRuby != 0;
		if (flag)
		{
			bool flag2 = this.price == 0 && this.priceRuby == 0;
			if (flag2)
			{
				bool flag3 = this.colorName == 4;
				if (flag3)
				{
					mVector.addElement(TabShop.cmdDonotUse);
				}
				else
				{
					mVector.addElement(TabShop.cmdUse);
				}
			}
			else
			{
				mVector.addElement(TabShop.cmdBuyHair);
			}
		}
		return mVector;
	}
}
