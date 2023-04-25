using System;

// Token: 0x02000063 RID: 99
public class ItemQuaNT : MainItem
{
	// Token: 0x06000644 RID: 1604 RVA: 0x0000A644 File Offset: 0x00008844
	public ItemQuaNT(string name, sbyte cat, short id, short num, sbyte color)
	{
		this.name = name;
		this.typeObject = cat;
		this.idIcon = id;
		this.numPotion = num;
		this.colorName = color;
	}

	// Token: 0x06000645 RID: 1605 RVA: 0x0000A67B File Offset: 0x0000887B
	public override void paint(mGraphics g, int x, int y, int w)
	{
		g.drawImage(AvMain.imgKhungItem, x, y, 3);
		base.paint(g, x, y, w);
		this.paintPotion(g, x, y, 3);
	}

	// Token: 0x06000646 RID: 1606 RVA: 0x0008BC90 File Offset: 0x00089E90
	public void paintInfo(mGraphics g, int x, int y)
	{
		MainImage image = this.getImage();
		bool flag = image != null && image.img != null;
		if (flag)
		{
			g.drawRegion(image.img, 0, 0, 20, 20, 0, (float)(x + 4), (float)(y + 4), 0);
		}
		bool flag2 = this.strShow == null;
		if (!flag2)
		{
			bool flag3 = this.strShow.Length == 1;
			if (flag3)
			{
				AvMain.Font3dColor(g, this.strShow[0], x + 30, y + 4 + 4, 0, this.colorName);
			}
			else
			{
				int num = y + 4;
				for (int i = 0; i < this.strShow.Length; i++)
				{
					AvMain.Font3dColor(g, this.strShow[i], x + 30, num, 0, this.colorName);
					num += 13;
				}
			}
		}
	}

	// Token: 0x06000647 RID: 1607 RVA: 0x0000A6A4 File Offset: 0x000088A4
	public void setDauGia(int money, int time, int giaChot)
	{
		this.priceDauGia = money;
		this.timeRemain = time;
		this.giaChot = giaChot;
	}

	// Token: 0x040008EE RID: 2286
	private int sizeItem = 29;

	// Token: 0x040008EF RID: 2287
	public string[] strShow;

	// Token: 0x040008F0 RID: 2288
	public int priceDauGia;

	// Token: 0x040008F1 RID: 2289
	public int timeRemain;

	// Token: 0x040008F2 RID: 2290
	public int giaChot;
}
