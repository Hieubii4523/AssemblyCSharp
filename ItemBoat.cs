using System;

// Token: 0x0200005C RID: 92
public class ItemBoat : MainItem
{
	// Token: 0x06000626 RID: 1574 RVA: 0x0008AFB0 File Offset: 0x000891B0
	public ItemBoat(short ID, short IDIcon, short IdImage, string name, sbyte type)
	{
		this.ID = ID;
		this.idIcon = IDIcon + 500;
		this.idPart = IdImage;
		this.typeObject = 102;
		this.name = name;
		this.namepaint = name;
		this.typeBoat = type;
	}

	// Token: 0x06000627 RID: 1575 RVA: 0x0008B004 File Offset: 0x00089204
	public override MainImage getImage()
	{
		return ObjectData.getImageAll(this.idIcon, ObjectData.hashImageBoat, 8000);
	}

	// Token: 0x06000628 RID: 1576 RVA: 0x0008B030 File Offset: 0x00089230
	public static void paintPartBoat(mGraphics g, short idImage, int type, int x, int y, int dy, int Dir)
	{
		bool flag = type >= 100;
		if (flag)
		{
			int num = GameCanvas.gameTick / 6 % 2;
			int num2 = (Dir != 2) ? -4 : 4;
			Boat.fraPirateUnity.drawFrame((type - 100) * 2 + num, x + num2, y + Boat.hlech - 57 - dy, Dir, 33, g);
		}
		else
		{
			MainImage imageAll = ObjectData.getImageAll(idImage, ObjectData.hashImageBoat, 8000);
			bool flag2 = imageAll != null && imageAll.img != null;
			if (flag2)
			{
				int num3 = (Dir != 2) ? -11 : 11;
				bool flag3 = type == 0;
				if (flag3)
				{
					g.drawRegion(imageAll.img, 0, 0, (int)imageAll.w, (int)imageAll.h + dy, Dir, (float)x, (float)(y + Boat.hlech), 33);
				}
				bool flag4 = type == 1;
				if (flag4)
				{
					g.drawRegion(imageAll.img, 0, 0, (int)imageAll.w, (int)imageAll.h, Dir, (float)(x + num3), (float)(y + Boat.hlech - 15 - dy), 33);
				}
				bool flag5 = type == 2;
				if (flag5)
				{
					int num4 = GameCanvas.gameTick / 6 % 2;
					g.drawRegion(imageAll.img, 0, (int)(imageAll.h / 2) * num4, (int)imageAll.w, (int)(imageAll.h / 2), Dir, (float)(x + num3), (float)(y + Boat.hlech - 23 - dy), 33);
				}
				bool flag6 = type == 3;
				if (flag6)
				{
					num3 = 0;
					g.drawRegion(imageAll.img, 0, 0, (int)imageAll.w, (int)imageAll.h + dy, Dir, (float)(x + num3), (float)(y + Boat.hlech), 33);
				}
			}
		}
	}

	// Token: 0x06000629 RID: 1577 RVA: 0x0008B1D8 File Offset: 0x000893D8
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
			mVector.addElement(TabShop.cmdBuyItem);
		}
		return mVector;
	}
}
