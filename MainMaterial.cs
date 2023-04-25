using System;

// Token: 0x0200007F RID: 127
public class MainMaterial : MainItem
{
	// Token: 0x06000786 RID: 1926 RVA: 0x0009E9BC File Offset: 0x0009CBBC
	public MainMaterial(sbyte Id, string name, sbyte type, sbyte idicon, int price, short priceRuby, sbyte isTrade)
	{
		this.ID = (short)Id;
		this.name = name;
		this.typeMaterial = type;
		this.idIcon = (short)idicon;
		this.price = price;
		this.priceRuby = priceRuby;
		this.isTrade = isTrade;
		bool flag = this.LvUpgrade > 0;
		if (flag)
		{
			this.namepaint = name + " +" + this.LvUpgrade.ToString();
		}
		else
		{
			this.namepaint = name;
		}
		this.getInfo();
	}

	// Token: 0x06000787 RID: 1927 RVA: 0x0009EA44 File Offset: 0x0009CC44
	public MainMaterial(sbyte typeObj, sbyte Id, string name, sbyte type, sbyte idicon, short num, int price, short priceRuby, sbyte isTrade)
	{
		this.typeObject = typeObj;
		this.ID = (short)Id;
		this.name = name;
		this.typeMaterial = type;
		this.idIcon = (short)idicon;
		this.numPotion = num;
		this.price = price;
		this.priceRuby = priceRuby;
		this.isTrade = isTrade;
		this.indexSort = 1;
		bool flag = this.LvUpgrade > 0;
		if (flag)
		{
			this.namepaint = name + " +" + this.LvUpgrade.ToString();
		}
		else
		{
			this.namepaint = name;
		}
	}

	// Token: 0x06000788 RID: 1928 RVA: 0x0009EADC File Offset: 0x0009CCDC
	public void getInfo()
	{
		bool flag = this.typeMaterial >= 0 && (int)this.typeMaterial < T.mMaterialInfo.Length;
		if (flag)
		{
			this.info = T.mMaterialInfo[(int)this.typeMaterial];
		}
		else
		{
			this.info = T.infoMaterialDefault;
		}
	}

	// Token: 0x06000789 RID: 1929 RVA: 0x0009EB2C File Offset: 0x0009CD2C
	public override MainImage getImage()
	{
		return ObjectData.getImageAll(this.idIcon, ObjectData.hashImageMaterialPotion, 6500);
	}

	// Token: 0x0600078A RID: 1930 RVA: 0x0009EB58 File Offset: 0x0009CD58
	public override mVector getActionInven(sbyte type)
	{
		mVector mVector = new mVector();
		bool flag = type == 0;
		if (flag)
		{
			mVector.addElement(GameCanvas.tabInven.cmdMenuMaterial);
		}
		else
		{
			bool flag2 = type == 1;
			if (flag2)
			{
				mVector.addElement(GameCanvas.tabInven.cmdSellItem);
			}
			else
			{
				bool flag3 = type == 2;
				if (flag3)
				{
					mVector.addElement(GameCanvas.tabInven.cmdSetChestPotion);
					mVector.addElement(GameCanvas.tabInven.cmdChucnang);
				}
				else
				{
					bool flag4 = type == 5 && (this.ID == 4 || this.ID == 10 || this.canSell());
					if (flag4)
					{
						mVector.addElement(GameCanvas.tabInvenMarket.cmdSellMarket);
					}
				}
			}
		}
		return mVector;
	}

	// Token: 0x0600078B RID: 1931 RVA: 0x0009EC1C File Offset: 0x0009CE1C
	public bool canSell()
	{
		bool flag = MainItem.ID_MATERIAL_CAN_SELL != null;
		if (flag)
		{
			for (int i = 0; i < MainItem.ID_MATERIAL_CAN_SELL.Length; i++)
			{
				bool flag2 = this.ID == MainItem.ID_MATERIAL_CAN_SELL[i];
				if (flag2)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600078C RID: 1932 RVA: 0x0009EC70 File Offset: 0x0009CE70
	public override mVector getActionUpgrade()
	{
		bool flag = this.getStar() || this.typeMaterial == 3 || this.typeMaterial == 7;
		mVector result;
		if (flag)
		{
			mVector mVector = new mVector();
			bool flag2 = ScreenUpgrade.instance != null;
			if (flag2)
			{
				mVector.addElement(ScreenUpgrade.instance.cmdBovao);
			}
			result = mVector;
		}
		else
		{
			result = null;
		}
		return result;
	}

	// Token: 0x0600078D RID: 1933 RVA: 0x0009DE3C File Offset: 0x0009C03C
	public override mVector getActionShop(sbyte typeShop)
	{
		mVector mVector = new mVector();
		mVector.addElement(TabShop.cmdBuyPotion);
		return mVector;
	}

	// Token: 0x0600078E RID: 1934 RVA: 0x0009ECD0 File Offset: 0x0009CED0
	public override mVector getActionChest()
	{
		mVector mVector = new mVector();
		mVector.addElement(TabChest.cmdGetPotion);
		mVector.addElement(TabChest.cmdChucnang);
		return mVector;
	}

	// Token: 0x0600078F RID: 1935 RVA: 0x0000AB20 File Offset: 0x00008D20
	public override void paint(mGraphics g, int x, int y, int w)
	{
		base.paint(g, x, y, w);
		this.paintPotion(g, x, y, w);
	}

	// Token: 0x06000790 RID: 1936 RVA: 0x0009ED04 File Offset: 0x0009CF04
	public override bool getStar()
	{
		return this.typeMaterial == 2 || this.typeMaterial == 4;
	}

	// Token: 0x04000B78 RID: 2936
	public const sbyte MATERIAL_UPGRADE = 0;

	// Token: 0x04000B79 RID: 2937
	public const sbyte MATERIAL_SPLIT = 1;

	// Token: 0x04000B7A RID: 2938
	public const sbyte MATERIAL_LUCKY = 2;

	// Token: 0x04000B7B RID: 2939
	public const sbyte MATERIAL_PROTECT = 3;

	// Token: 0x04000B7C RID: 2940
	public const sbyte MATERIAL_LUCKY_VIP = 4;

	// Token: 0x04000B7D RID: 2941
	public const sbyte MATERIAL_PROTECT_VER_2 = 7;
}
