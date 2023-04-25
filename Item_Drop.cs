using System;

// Token: 0x02000064 RID: 100
public class Item_Drop : MainObject
{
	// Token: 0x06000648 RID: 1608 RVA: 0x0008BD60 File Offset: 0x00089F60
	public Item_Drop(short ID, sbyte type, string name, int x, int y, short IdIcon, sbyte color)
	{
		this.ID = ID;
		this.typeObject = type;
		this.name = name;
		bool flag = x < 48;
		if (flag)
		{
			x = 48;
		}
		bool flag2 = x > GameCanvas.loadmap.maxWMap - 48;
		if (flag2)
		{
			x = GameCanvas.loadmap.maxWMap - 48;
		}
		bool flag3 = y < 48;
		if (flag3)
		{
			y = 48;
		}
		bool flag4 = y > GameCanvas.loadmap.maxHMap - 48;
		if (flag4)
		{
			y = GameCanvas.loadmap.maxHMap - 48;
		}
		this.x = x;
		this.y = y;
		this.IdIcon = IdIcon;
		this.colorName = color;
		this.wOne = (this.hOne = -1);
		this.vx = CRes.random_Am(1, 5);
		this.vy = -CRes.random(3, 10);
		this.timeDrop = CRes.random(5, 12);
		this.vMax = 16;
		this.vySea = 4;
		this.dyShadow = 0;
		bool flag5 = this.typeObject == 4 && (IdIcon == 10 || IdIcon == 286);
		if (flag5)
		{
			this.dyShadow = 20;
		}
		this.timeAp = GameCanvas.timeNow;
		this.timeRemove = 60;
		this.isSend = false;
		this.typeDrop = 0;
	}

	// Token: 0x06000649 RID: 1609 RVA: 0x0008BEB8 File Offset: 0x0008A0B8
	public Item_Drop(short ID, sbyte type, string name, int x, int y, short IdIcon, sbyte color, int xto, int yto)
	{
		this.ID = ID;
		this.typeObject = type;
		this.name = name;
		bool flag = x < 48;
		if (flag)
		{
			x = 48;
		}
		bool flag2 = x > GameCanvas.loadmap.maxWMap - 48;
		if (flag2)
		{
			x = GameCanvas.loadmap.maxWMap - 48;
		}
		bool flag3 = y < 48;
		if (flag3)
		{
			y = 48;
		}
		bool flag4 = y > GameCanvas.loadmap.maxHMap - 48;
		if (flag4)
		{
			y = GameCanvas.loadmap.maxHMap - 48;
		}
		this.x = x;
		this.y = y;
		this.IdIcon = IdIcon;
		this.colorName = color;
		this.wOne = (this.hOne = -1);
		this.vMax = 8;
		this.timeAp = GameCanvas.timeNow;
		this.timeRemove = 60;
		this.isSend = false;
		this.typeDrop = 1;
		this.create_Speed(xto - x, yto - y, null);
	}

	// Token: 0x0600064A RID: 1610 RVA: 0x0008BFBC File Offset: 0x0008A1BC
	public Point_Focus create_Speed(int xdich, int ydich, Point_Focus p)
	{
		bool flag = ydich == 0;
		if (flag)
		{
			ydich = 1;
		}
		bool flag2 = xdich == 0;
		if (flag2)
		{
			xdich = 1;
		}
		int num = MainObject.getDistance(xdich, ydich) / this.vMax;
		bool flag3 = num == 0;
		if (flag3)
		{
			num = 1;
		}
		int num2 = xdich / num;
		int num3 = ydich / num;
		bool flag4 = CRes.abs(num2) > CRes.abs(xdich);
		if (flag4)
		{
			num2 = xdich;
		}
		bool flag5 = CRes.abs(num3) > CRes.abs(ydich);
		if (flag5)
		{
			num3 = ydich;
		}
		bool flag6 = p != null;
		if (flag6)
		{
			p.x = this.x;
			p.y = this.y;
			p.vx = num2;
			p.vy = num3;
			p.toX = this.toX;
			p.toY = this.toY;
			p.fRe = num;
		}
		else
		{
			this.timeDrop = num;
			this.vx = num2;
			this.vy = num3;
		}
		return p;
	}

	// Token: 0x0600064B RID: 1611 RVA: 0x0008C0B0 File Offset: 0x0008A2B0
	public override void paint(mGraphics g)
	{
		bool flag = this.isLittlegarden;
		if (flag)
		{
			this.paintXY(g, MainScreen.cameraMain.xCam + this.x, this.y);
		}
		else
		{
			MainImage img = this.getImg();
			bool flag2 = !this.isloadfra;
			if (flag2)
			{
				this.setFraImageVip(img);
			}
			bool flag3 = img.img != null;
			if (flag3)
			{
				bool flag4 = this.wOne < 0;
				if (flag4)
				{
					this.wOne = mImage.getImageWidth(img.img.image);
				}
				bool flag5 = this.hOne < 0;
				if (flag5)
				{
					this.hOne = mImage.getImageHeight(img.img.image);
				}
				int y = this.y;
				bool flag6 = this.timeDrop <= 0;
				if (flag6)
				{
					g.drawImage(AvMain.imgShadowSmall, this.x, y - this.dySea / 10 - 4 + this.dyShadow, mGraphics.BOTTOM | mGraphics.HCENTER);
				}
				bool flag7 = this.fraImgVip != null;
				if (flag7)
				{
					int num = GameCanvas.gameTick / 3 % this.fraImgVip.nFrame;
					this.fraImgVip.drawFrame((num <= this.fraImgVip.nFrame - 1) ? num : 0, this.x, this.y, 0, 3, g);
				}
				else
				{
					bool flag8 = this.dySea / 10 != 0;
					if (flag8)
					{
						g.drawRegion(img.img, 0, 0, this.wOne, this.hOne + this.dySea / 10, 0, (float)this.x, (float)y, mGraphics.BOTTOM | mGraphics.HCENTER);
					}
					else
					{
						g.drawImage(img.img, this.x, y, mGraphics.BOTTOM | mGraphics.HCENTER);
					}
				}
			}
			bool flag9 = Interface_Game.typeTouch == 1;
			if (flag9)
			{
				bool flag10 = !this.checkXp();
				if (flag10)
				{
					sbyte color = 0;
					bool flag11 = this.typeObject == 3;
					if (flag11)
					{
						color = this.colorName;
					}
					this.paintName(g, color, 0);
				}
			}
			else
			{
				bool flag12 = this.timeItemDropEvent > 0;
				if (flag12)
				{
					AvMain.FontBorderColor(g, "( " + this.timeItemDropEvent.ToString() + " )", this.x, this.y - this.dy - this.hOne - 18, 2, 6, 7);
				}
			}
		}
	}

	// Token: 0x0600064C RID: 1612 RVA: 0x0008C324 File Offset: 0x0008A524
	private bool checkXp()
	{
		return this.typeObject == 4 && (this.IdIcon == 10 || this.IdIcon == 286);
	}

	// Token: 0x0600064D RID: 1613 RVA: 0x0008C368 File Offset: 0x0008A568
	public void paintXY(mGraphics g, int x, int y)
	{
		MainImage img = this.getImg();
		bool flag = img == null || img.img == null;
		if (!flag)
		{
			bool flag2 = !this.isloadfra;
			if (flag2)
			{
				this.setFraImageVip(img);
			}
			bool flag3 = this.fraImgVip != null;
			if (flag3)
			{
				int num = GameCanvas.gameTick / 3 % this.fraImgVip.nFrame;
				this.fraImgVip.drawFrame((num <= this.fraImgVip.nFrame - 1) ? num : 0, x, y, 0, 3, g);
			}
			else
			{
				bool flag4 = this.hOne == 0;
				if (flag4)
				{
					this.hOne = mImage.getImageHeight(img.img.image);
				}
				g.drawImage(img.img, x, y, 3);
			}
		}
	}

	// Token: 0x0600064E RID: 1614 RVA: 0x0008C434 File Offset: 0x0008A634
	private void setFraImageVip(MainImage img)
	{
		bool flag = img != null && img.img != null;
		if (flag)
		{
			int imageWidth = mImage.getImageWidth(img.img.image);
			int imageHeight = mImage.getImageHeight(img.img.image);
			bool flag2 = imageHeight / 2 >= imageWidth;
			if (flag2)
			{
				this.fraImgVip = new FrameImage(img.img, imageWidth, imageWidth);
			}
			this.isloadfra = true;
			this.hOne = imageWidth;
		}
	}

	// Token: 0x0600064F RID: 1615 RVA: 0x0008C4AC File Offset: 0x0008A6AC
	public void paintAvatarFocus(mGraphics g, int xp, int yp)
	{
		MainImage img = this.getImg();
		bool flag = !this.isloadfra;
		if (flag)
		{
			this.setFraImageVip(img);
		}
		bool flag2 = img.img != null;
		if (flag2)
		{
			bool flag3 = this.hOne == 0;
			if (flag3)
			{
				this.hOne = mImage.getImageHeight(img.img.image);
			}
			g.drawImage(img.img, xp - 1, yp, 3);
		}
	}

	// Token: 0x06000650 RID: 1616 RVA: 0x0008C520 File Offset: 0x0008A720
	public override void paintName(mGraphics g, sbyte color, int isFocus)
	{
		bool flag = !GameScreen.getIsOffAdmin(0);
		if (flag)
		{
			bool flag2 = isFocus == 0;
			if (flag2)
			{
				AvMain.setTextColor((int)this.colorName).drawString(g, this.name, this.x, this.y - this.dy - this.hOne - 18, 2);
			}
			bool flag3 = this.timeItemDropEvent > 0;
			if (flag3)
			{
				AvMain.FontBorderColor(g, "( " + this.timeItemDropEvent.ToString() + " )", this.x, this.y - this.dy - this.hOne - 28, 2, 6, 7);
				AvMain.FontBorderColor(g, this.namePlayer, this.x, this.y - this.dy - this.hOne - 38, 2, 5, 7);
			}
		}
	}

	// Token: 0x06000651 RID: 1617 RVA: 0x0008C600 File Offset: 0x0008A800
	public MainImage getImg()
	{
		bool flag = this.IdIcon < 0;
		MainImage result;
		if (flag)
		{
			result = null;
		}
		else
		{
			bool flag2 = this.typeObject == 99;
			if (flag2)
			{
				result = Item_Drop.imgMainIconXp;
			}
			else
			{
				bool flag3 = this.typeObject == 3;
				if (flag3)
				{
					result = ObjectData.getImageAll(this.IdIcon, ObjectData.hashImageItem, 3000);
				}
				else
				{
					bool flag4 = this.typeObject == 4;
					if (flag4)
					{
						result = ObjectData.getImageAll(this.IdIcon, ObjectData.hashImagePotion, 2000);
					}
					else
					{
						bool flag5 = this.typeObject == 5;
						if (flag5)
						{
							result = ObjectData.getImageAll(this.IdIcon, ObjectData.hashImageQuestPotion, 6000);
						}
						else
						{
							bool flag6 = this.typeObject == 7;
							if (flag6)
							{
								result = ObjectData.getImageAll(this.IdIcon, ObjectData.hashImageMaterialPotion, 6500);
							}
							else
							{
								bool flag7 = this.typeObject == 109;
								if (flag7)
								{
									result = ObjectData.getImageAll(this.IdIcon, ObjectData.HashImageOtherNew, 23000);
								}
								else
								{
									bool flag8 = this.typeObject == 105;
									if (flag8)
									{
										result = ObjectData.getImageAll(this.IdIcon, ObjectData.HashImageFashion, 20000);
									}
									else
									{
										result = null;
									}
								}
							}
						}
					}
				}
			}
		}
		return result;
	}

	// Token: 0x06000652 RID: 1618 RVA: 0x0000A6BC File Offset: 0x000088BC
	public override void paintInfoFocus(mGraphics g, int xp, int yp)
	{
		AvMain.Font3dColor(g, this.name, xp + 48, yp, 1, this.colorName);
	}

	// Token: 0x06000653 RID: 1619 RVA: 0x0008C738 File Offset: 0x0008A938
	public override void update()
	{
		bool isRemove = this.isRemove;
		if (!isRemove)
		{
			bool flag = this.timeDrop > 0;
			if (flag)
			{
				this.x += this.vx;
				this.y += this.vy;
				bool flag2 = this.typeDrop == 0;
				if (flag2)
				{
					this.vy += 2;
				}
				this.timeDrop--;
			}
			bool flag3 = this.timeDrop == 0 && GameScreen.indexHelp == 8;
			if (flag3)
			{
				MainHelp.setNextHelp(false);
			}
			bool flag4 = this.isUpdateDrop;
			if (flag4)
			{
				this.timefly++;
				this.x += this.vx;
				this.y += this.vy;
				bool flag5 = this.timefly >= this.timeStopDrop;
				if (flag5)
				{
					this.isRemove = true;
				}
			}
			else
			{
				bool flag6 = this.timeDrop <= 0;
				if (flag6)
				{
					bool flag7 = this.timeDrop == 0;
					if (flag7)
					{
						this.vMax = 8;
					}
					bool flag8 = this.objMainFocus != null;
					if (flag8)
					{
						this.setVx_Vy_Item();
					}
					bool flag9 = this.bossLittle != null;
					if (flag9)
					{
						this.setVx_Vy_ItemLittle();
					}
				}
			}
			bool isSend = this.isSend;
			if (isSend)
			{
				this.timeGet++;
				bool flag10 = this.timeGet > 40;
				if (flag10)
				{
					this.isSend = false;
					this.timeGet = 0;
				}
			}
			bool flag11 = (GameCanvas.timeNow - this.timeAp) / 1000L >= (long)this.timeRemove;
			if (flag11)
			{
				this.isRemove = true;
			}
			bool flag12 = LoadMap.specMap == 4;
			if (flag12)
			{
				this.updateDySea();
			}
			bool flag13 = this.timeItemDropEvent > 0 && GameCanvas.timeNow - this.timeBeginItemDropEvent > 1000L;
			if (flag13)
			{
				this.timeItemDropEvent--;
				this.timeBeginItemDropEvent += 1000L;
			}
		}
	}

	// Token: 0x06000654 RID: 1620 RVA: 0x0008C960 File Offset: 0x0008AB60
	public override void updateDySea()
	{
		bool flag = CRes.random(40) == 0;
		if (flag)
		{
			bool flag2 = CRes.random(2) == 0;
			if (flag2)
			{
				this.vySea = 4;
			}
			else
			{
				this.vySea = -4;
			}
		}
		bool flag3 = this.dySea > 0 && this.vySea > 0;
		if (flag3)
		{
			this.vySea = -4;
		}
		else
		{
			bool flag4 = this.dySea < -50 && this.vySea < 0;
			if (flag4)
			{
				this.vySea = 4;
			}
		}
		this.dySea += this.vySea;
	}

	// Token: 0x06000655 RID: 1621 RVA: 0x0008C9FC File Offset: 0x0008ABFC
	public void setVx_Vy_Item()
	{
		this.toX = this.objMainFocus.x;
		this.toY = this.objMainFocus.y - this.objMainFocus.hOne / 2;
		int num = this.toX - this.x;
		int num2 = this.toY - this.y;
		bool flag = num2 == 0;
		if (flag)
		{
			num2 = 1;
		}
		bool flag2 = num == 0;
		if (flag2)
		{
			num = 1;
		}
		int num3 = MainObject.getDistance(num, num2) / this.vMax;
		bool flag3 = num3 == 0;
		if (flag3)
		{
			num3 = 1;
		}
		this.vx = num / num3;
		this.vy = num2 / num3;
		bool flag4 = CRes.abs(this.vx) > CRes.abs(num);
		if (flag4)
		{
			this.vx = num;
		}
		bool flag5 = CRes.abs(this.vy) > CRes.abs(num2);
		if (flag5)
		{
			this.vy = num2;
		}
		this.timefly = 0;
		this.timeStopDrop = num3 + 1;
		this.timeDrop = 0;
		this.isUpdateDrop = true;
	}

	// Token: 0x06000656 RID: 1622 RVA: 0x0008CB04 File Offset: 0x0008AD04
	public void setVx_Vy_ItemLittle()
	{
		bool flag = this.bossLittle.type == 0;
		if (flag)
		{
			this.toX = MotherCanvas.hw - 40;
		}
		else
		{
			this.toX = MotherCanvas.hw + 100;
		}
		this.toY = 60;
		this.x -= MainScreen.cameraMain.xCam;
		int num = this.toX - this.x;
		int num2 = this.toY - this.y;
		bool flag2 = num2 == 0;
		if (flag2)
		{
			num2 = 1;
		}
		bool flag3 = num == 0;
		if (flag3)
		{
			num = 1;
		}
		int num3 = MainObject.getDistance(num, num2) / this.vMax;
		bool flag4 = num3 == 0;
		if (flag4)
		{
			num3 = 1;
		}
		this.vx = num / num3;
		this.vy = num2 / num3;
		bool flag5 = CRes.abs(this.vx) > CRes.abs(num);
		if (flag5)
		{
			this.vx = num;
		}
		bool flag6 = CRes.abs(this.vy) > CRes.abs(num2);
		if (flag6)
		{
			this.vy = num2;
		}
		this.timefly = 0;
		this.timeStopDrop = num3 + 1;
		this.timeDrop = 0;
		this.isUpdateDrop = true;
		this.isLittlegarden = true;
	}

	// Token: 0x06000657 RID: 1623 RVA: 0x0000A6D8 File Offset: 0x000088D8
	public override void setTouchPoint()
	{
		this.setFireObject(2);
	}

	// Token: 0x06000658 RID: 1624 RVA: 0x0008CC38 File Offset: 0x0008AE38
	public void setOpenBox()
	{
		MsgShowGift msgShowGift = new MsgShowGift();
		msgShowGift.setinfoShow_Gift(1, this.name, T.phanthuong, this.mItemDrop, -1);
		GameCanvas.Start_Current_Dialog(msgShowGift);
		this.isRemove = true;
	}

	// Token: 0x06000659 RID: 1625 RVA: 0x0008CC74 File Offset: 0x0008AE74
	public override void setFireObject(int value)
	{
		bool flag = !this.isRemove;
		if (flag)
		{
			bool flag2 = this.namePlayer != string.Empty;
			if (flag2)
			{
				Item_Drop.currentSelectItemDrop = this;
				GlobalService.gI().Get_Item_Map(this.ID, this.typeObject);
				this.isSend = true;
			}
			else
			{
				bool flag3 = this.mItemDrop != null;
				if (flag3)
				{
					this.setOpenBox();
				}
				else
				{
					GlobalService.gI().Get_Item_Map(this.ID, this.typeObject);
					this.isSend = true;
				}
			}
		}
	}

	// Token: 0x040008F3 RID: 2291
	public const sbyte GIFT_DAILY_NORMAL = 0;

	// Token: 0x040008F4 RID: 2292
	public const sbyte GIFT_DAILY_CURRENT = 1;

	// Token: 0x040008F5 RID: 2293
	public const sbyte GIFT_DAILY_GOT = 2;

	// Token: 0x040008F6 RID: 2294
	public const sbyte GIFT_DAILY_MISS = 3;

	// Token: 0x040008F7 RID: 2295
	public static Item_Drop currentSelectItemDrop;

	// Token: 0x040008F8 RID: 2296
	private long timeAp;

	// Token: 0x040008F9 RID: 2297
	private int timefly;

	// Token: 0x040008FA RID: 2298
	private int timeDrop;

	// Token: 0x040008FB RID: 2299
	private int timeStopDrop;

	// Token: 0x040008FC RID: 2300
	private int timeGet;

	// Token: 0x040008FD RID: 2301
	public sbyte typeDrop;

	// Token: 0x040008FE RID: 2302
	public sbyte typeGiftDaily;

	// Token: 0x040008FF RID: 2303
	public int num;

	// Token: 0x04000900 RID: 2304
	private bool isUpdateDrop;

	// Token: 0x04000901 RID: 2305
	private bool isLittlegarden;

	// Token: 0x04000902 RID: 2306
	public static MainImage imgDefault;

	// Token: 0x04000903 RID: 2307
	public static MainImage imgMainIconXp;

	// Token: 0x04000904 RID: 2308
	public FrameImage fraImgVip;

	// Token: 0x04000905 RID: 2309
	public bool isloadfra;
}
