using System;

// Token: 0x02000062 RID: 98
public class ItemMap : MainItemMap
{
	// Token: 0x0600063D RID: 1597 RVA: 0x0000A5F9 File Offset: 0x000087F9
	public ItemMap(short IDItem, short IDImage, int dx, int dy, int[][] Block, sbyte layer) : base(IDItem, IDImage, dx, dy, Block, layer)
	{
		this.TypeItem = 0;
	}

	// Token: 0x0600063E RID: 1598 RVA: 0x0000A61A File Offset: 0x0000881A
	public void setInfoItem(int x, int y)
	{
		this.x = x;
		this.y = y;
		this.ySort = y;
	}

	// Token: 0x0600063F RID: 1599 RVA: 0x0008B9EC File Offset: 0x00089BEC
	public override void paint(mGraphics g)
	{
		MainImage image = this.getImage();
		bool flag = this.typeEff >= 0;
		if (flag)
		{
			this.paintFrist(g);
		}
		bool flag2 = !GameScreen.isOpenDao && (this.IDImage == 259 || this.IDImage == 263);
		if (flag2)
		{
			bool flag3 = ItemMap.imgGate == null;
			if (flag3)
			{
				ItemMap.loadgate();
			}
			g.drawImage(ItemMap.imgGate, this.x + this.dx, this.y + this.dy, 0);
		}
		else
		{
			bool flag4 = image.img != null;
			if (flag4)
			{
				g.drawImage(image.img, this.x + this.dx, this.y + this.dy, 0);
			}
		}
		bool flag5 = this.typeEff >= 0;
		if (flag5)
		{
			this.paintLast(g);
		}
	}

	// Token: 0x06000640 RID: 1600 RVA: 0x000090B5 File Offset: 0x000072B5
	private void paintLast(mGraphics g)
	{
	}

	// Token: 0x06000641 RID: 1601 RVA: 0x0008BADC File Offset: 0x00089CDC
	private void paintFrist(mGraphics g)
	{
		sbyte b = this.typeEff;
		sbyte b2 = b;
		if (b2 != 0)
		{
			if (b2 == 1)
			{
				bool flag = this.imgEff == null;
				if (flag)
				{
					this.imgEff = new FrameImage(391, 28, 13);
				}
				else
				{
					bool flag2 = this.stepEff == 0;
					if (flag2)
					{
						this.imgEff.drawFrame(0, this.x + this.dx + 11, this.y + this.dy + 14, 0, 3, g);
						bool flag3 = GameCanvas.gameTick % 200 == 140;
						if (flag3)
						{
							this.stepEff = 1;
						}
					}
					else
					{
						bool flag4 = GameCanvas.gameTick % 200 == 190 || GameCanvas.gameTick % 200 == 195;
						if (flag4)
						{
							this.imgEff.drawFrame(0, this.x + this.dx + 11, this.y + this.dy + 14, 0, 3, g);
						}
						bool flag5 = GameCanvas.gameTick % 200 == 199;
						if (flag5)
						{
							this.stepEff = 0;
						}
					}
				}
			}
		}
		else
		{
			bool flag6 = this.imgEff == null;
			if (flag6)
			{
				this.imgEff = new FrameImage(391, 28, 13);
			}
			else
			{
				this.imgEff.drawFrame(0, this.x + this.dx + 11, this.y + this.dy + 14, 0, 3, g);
			}
		}
	}

	// Token: 0x06000642 RID: 1602 RVA: 0x0000A632 File Offset: 0x00008832
	public static void loadgate()
	{
		ItemMap.imgGate = mImage.createImage("/bg/gate.png");
	}

	// Token: 0x06000643 RID: 1603 RVA: 0x0008BC6C File Offset: 0x00089E6C
	public MainImage getImage()
	{
		return ObjectData.getImageAll(this.IDImage, ObjectData.HashImageItemMap, 0);
	}

	// Token: 0x040008E8 RID: 2280
	public const sbyte LIGHT_0 = 0;

	// Token: 0x040008E9 RID: 2281
	public const sbyte LIGHT_1 = 1;

	// Token: 0x040008EA RID: 2282
	public static mImage imgGate;

	// Token: 0x040008EB RID: 2283
	private FrameImage imgEff;

	// Token: 0x040008EC RID: 2284
	public sbyte typeEff = -1;

	// Token: 0x040008ED RID: 2285
	public sbyte stepEff;
}
