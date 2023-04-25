using System;

// Token: 0x0200005B RID: 91
public class Item : MainItem
{
	// Token: 0x06000615 RID: 1557 RVA: 0x0000A508 File Offset: 0x00008708
	public Item(sbyte typeItem, short ID, short idIcon, string name, sbyte isTrade) : base(typeItem, ID, idIcon, name, isTrade)
	{
		this.indexSort = 3;
	}

	// Token: 0x06000616 RID: 1558 RVA: 0x0008A78C File Offset: 0x0008898C
	public Item(sbyte typeItem, short ID, short idIcon, string name, short timeUse, short maxTimeUse, short ruby) : base(typeItem, ID, idIcon, name, 0)
	{
		this.timeUse = (int)timeUse;
		bool flag = timeUse > 0;
		if (flag)
		{
			this.setTimeMarket((int)(timeUse * 60));
		}
		this.maxTimeUse = maxTimeUse;
		this.priceRuby = ruby;
	}

	// Token: 0x06000617 RID: 1559 RVA: 0x0008A7D8 File Offset: 0x000889D8
	public void setDataItem(short Lv, sbyte charClass, sbyte colorName, int timeUse, sbyte typeEquip, sbyte LvUp, sbyte numLoKham, short[] mdakham, short valueChetac, sbyte isHoanMy, sbyte valueKichAn)
	{
		this.Lv_RQ = Lv;
		this.charClass = charClass;
		this.colorName = colorName;
		this.timeUse = timeUse;
		this.typeEquip = typeEquip;
		this.LvUpgrade = LvUp;
		bool flag = this.LvUpgrade > 0;
		if (flag)
		{
			this.namepaint = this.name + " +" + this.LvUpgrade.ToString();
		}
		else
		{
			this.namepaint = this.name;
		}
		this.numLoKham = numLoKham;
		this.mDaKham = mdakham;
		this.valueCheTac = valueChetac;
		this.isHoanMy = isHoanMy;
		this.valueKickAn = valueKichAn;
		bool flag2 = this.idIcon == 242 && colorName == 0;
		if (flag2)
		{
			this.colorName = this.LvUpgrade / 10;
			this.typeSpec = 1;
		}
	}

	// Token: 0x06000618 RID: 1560 RVA: 0x0008A8AC File Offset: 0x00088AAC
	public void setInfoItem(MainInfoItem[] mInfoItem, int sizeMainInfo)
	{
		this.vecInfo.removeAllElements();
		bool flag = false;
		bool flag2 = this.valueKickAn >= 0;
		if (flag2)
		{
			string dataKichAn = MainItem.getDataKichAn(this);
			string[] array = mFont.tahoma_7_black.splitFontArray(dataKichAn, this.wInfo);
			for (int i = 0; i < array.Length; i++)
			{
				this.addInfo(array[i], 2);
			}
		}
		this.addInfo(T.thongtincoban, 5, infoShow.HARDCODE_PAINT_CENTER);
		bool flag3 = this.typeEquip != 10 && this.typeSpec != 1;
		if (flag3)
		{
			this.addInfo(T.Lv + ": " + this.Lv_RQ.ToString(), ((int)this.Lv_RQ > GameScreen.player.Lv) ? 3 : 4, infoShow.HARDCODE_CHECK_LVRQ);
		}
		this.addInfo(T.chetac + this.valueCheTac.ToString(), 0);
		bool flag4 = this.isTrade == 2;
		if (flag4)
		{
			this.addInfo(T.khoagiaodich, 3);
		}
		bool flag5 = this.LvUpgrade >= 11 && this.LvUpgrade <= 15 && this.typeSpec != 1;
		if (flag5)
		{
			this.addInfo(T.thongtinfullset, 5, infoShow.HARDCODE_PAINT_CENTER);
			sbyte color = 7;
			this.addInfo(T.fullset + this.LvUpgrade.ToString(), color, 90 + this.LvUpgrade);
			for (int j = 0; j < (int)(this.LvUpgrade - 10); j++)
			{
				sbyte b = (sbyte)(101 + j);
				bool flag6 = b > 105;
				if (flag6)
				{
					b = 105;
				}
				this.addInfo(T.mFullSet[j], color, b);
				bool flag7 = j == 4;
				if (flag7)
				{
					this.addInfo(T.mFullSet[j + 1], color, b);
				}
			}
		}
		this.addInfo(T.thongtinchiso, 5, infoShow.HARDCODE_PAINT_CENTER_CHI_SO);
		for (int k = 0; k < mInfoItem.Length; k++)
		{
			base.addInfo((short)mInfoItem[k].id, mInfoItem[k].value, mInfoItem[k].colorMain);
			bool flag8 = k == sizeMainInfo - 1 && sizeMainInfo < mInfoItem.Length;
			if (flag8)
			{
				this.addInfo(T.thongtindakham, 5, infoShow.HARDCODE_PAINT_CENTER);
			}
		}
		bool flag9 = flag;
		if (flag9)
		{
			this.mInfoItemSave = mInfoItem;
		}
		else
		{
			this.mInfoItemSave = null;
		}
	}

	// Token: 0x06000619 RID: 1561 RVA: 0x0008AB34 File Offset: 0x00088D34
	public void setInfoItemSell(MainInfoItem[] mInfoItem)
	{
		this.vecInfo.removeAllElements();
		bool flag = this.charClass > 0 && !Player.isClazz(this.charClass);
		if (flag)
		{
			this.addInfo(T.mClazz[(int)this.charClass], 6);
		}
		this.addInfo(T.Lv + this.Lv_RQ.ToString(), ((int)this.Lv_RQ > GameScreen.player.Lv) ? 6 : 4);
		for (int i = 0; i < mInfoItem.Length; i++)
		{
			base.addInfoSell((short)mInfoItem[i].id, mInfoItem[i].value);
		}
	}

	// Token: 0x0600061A RID: 1562 RVA: 0x0008ABE0 File Offset: 0x00088DE0
	public override mVector getActionInven(sbyte type)
	{
		mVector mVector = new mVector();
		bool flag = type == 0;
		if (flag)
		{
			mVector.addElement(GameCanvas.tabInven.cmdUseItem);
			mVector.addElement(GameCanvas.tabInven.cmdRemoveItem);
		}
		else
		{
			bool flag2 = type == 1;
			if (flag2)
			{
				mVector.addElement(GameCanvas.tabInven.cmdSellItem);
				mVector.addElement(GameCanvas.tabInven.cmdSellAll);
			}
			else
			{
				bool flag3 = type == 2;
				if (flag3)
				{
					mVector.addElement(GameCanvas.tabInven.cmdSetChestItem);
				}
				else
				{
					bool flag4 = type == 5;
					if (flag4)
					{
						mVector.addElement(GameCanvas.tabInvenMarket.cmdSellMarket);
					}
				}
			}
		}
		return mVector;
	}

	// Token: 0x0600061B RID: 1563 RVA: 0x0008AC94 File Offset: 0x00088E94
	public override mVector getActionShop(sbyte typeShop)
	{
		mVector mVector = new mVector();
		mVector.addElement(TabShop.cmdBuyItem);
		return mVector;
	}

	// Token: 0x0600061C RID: 1564 RVA: 0x0008ACBC File Offset: 0x00088EBC
	public override mVector getActionChest()
	{
		mVector mVector = new mVector();
		mVector.addElement(TabChest.cmdGetItem);
		mVector.addElement(TabChest.cmdUpgrade);
		return mVector;
	}

	// Token: 0x0600061D RID: 1565 RVA: 0x0008ACF0 File Offset: 0x00088EF0
	public override mVector getActionUpgrade()
	{
		mVector mVector = new mVector();
		bool flag = ScreenUpgrade.instance != null;
		if (flag)
		{
			mVector.addElement(ScreenUpgrade.instance.cmdBovao);
		}
		return mVector;
	}

	// Token: 0x0600061E RID: 1566 RVA: 0x0008AD28 File Offset: 0x00088F28
	public override mVector getActionSplit()
	{
		mVector mVector = new mVector();
		bool flag = SplitScreen.instance != null;
		if (flag)
		{
			mVector.addElement(SplitScreen.instance.cmdBovao);
		}
		return mVector;
	}

	// Token: 0x0600061F RID: 1567 RVA: 0x0008AD60 File Offset: 0x00088F60
	public override MainImage getImage()
	{
		return ObjectData.getImageAll(this.idIcon, ObjectData.hashImageItem, 3000);
	}

	// Token: 0x06000620 RID: 1568 RVA: 0x0008AD8C File Offset: 0x00088F8C
	public MainImage getImageRuong()
	{
		return ObjectData.getImageAll(this.idIcon, ObjectData.HashImageOtherNew, 23000);
	}

	// Token: 0x06000621 RID: 1569 RVA: 0x0000A520 File Offset: 0x00008720
	public override void paint(mGraphics g, int x, int y, int w)
	{
		base.paint(g, x, y, w);
	}

	// Token: 0x06000622 RID: 1570 RVA: 0x0008ADB8 File Offset: 0x00088FB8
	public void paintRuong(mGraphics g, int x, int y, int w)
	{
		MainImage imageRuong = this.getImageRuong();
		bool flag = imageRuong != null && imageRuong.img != null;
		if (flag)
		{
			g.drawImage(imageRuong.img, x, y, 3);
		}
		else
		{
			AvMain.imgLoadImage.drawFrame(GameCanvas.gameTick % AvMain.imgLoadImage.nFrame, x, y, 0, 3, g);
		}
		bool flag2 = !GameCanvas.lowGraphic;
		if (flag2)
		{
			g.drawImage(AvMain.mImgRoomW[3], x, y - w / 2, 3);
		}
		bool flag3 = this.timeUse > 0;
		if (flag3)
		{
			bool flag4 = !GameCanvas.lowGraphic;
			if (flag4)
			{
				g.drawRegion(AvMain.mImgRoomW[2], 0, GameCanvas.gameTick / 12 % 4 * 11, 11, 11, 0, (float)(x - 22), (float)(y - w / 2), 3);
			}
			this.marketTime.paintCountDownTicketHour(g, mFont.tahoma_7_white, x - 6, y - w / 2 - 5, 0);
		}
		else
		{
			bool flag5 = this.timeUse == 0;
			if (flag5)
			{
				mFont.tahoma_7b_yellow.drawString(g, T.open, x, y - w / 2 - 5, 2);
			}
			else
			{
				string text = ((int)(this.maxTimeUse / 60)).ToString() + "h";
				bool flag6 = this.maxTimeUse % 60 != 0;
				if (flag6)
				{
					text = text + ((int)(this.maxTimeUse % 60)).ToString() + "'";
				}
				mFont.tahoma_7b_white.drawString(g, text, x, y - w / 2 - 5, 2);
			}
		}
	}

	// Token: 0x06000623 RID: 1571 RVA: 0x0000A52F File Offset: 0x0000872F
	public override void setTimeMarket(int time)
	{
		this.timeUse = time;
		this.marketTime.setCountDown(time);
	}

	// Token: 0x06000624 RID: 1572 RVA: 0x0008AF40 File Offset: 0x00089140
	public static void CheckAddDataKichAn()
	{
		for (int i = 0; i < Item.vecItemKichAnCheckInfo.size(); i++)
		{
			Item item = (Item)Item.vecItemKichAnCheckInfo.elementAt(i);
			string dataKichAn = MainItem.getDataKichAn(item);
			bool flag = dataKichAn.Length > 0;
			if (flag)
			{
				item.setInfoItem(item.mInfoItemSave);
				Item.vecItemKichAnCheckInfo.removeElement(item);
				i--;
			}
		}
	}

	// Token: 0x040008E0 RID: 2272
	public static mVector vecItemKichAnCheckInfo = new mVector("Item.vecItemKichAnCheckInfo");

	// Token: 0x040008E1 RID: 2273
	private MainInfoItem[] mInfoItemSave;
}
