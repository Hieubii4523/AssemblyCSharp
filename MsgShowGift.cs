using System;

// Token: 0x020000AA RID: 170
public class MsgShowGift : MsgDialog
{
	// Token: 0x06000A55 RID: 2645 RVA: 0x000D215C File Offset: 0x000D035C
	public void setinfoShow_Gift(sbyte type, string name, string info, Item_Drop[] mitem, short IdChest)
	{
		this.fraRuongVip = null;
		this.type = (int)type;
		this.mItemgift = mitem;
		this.nameDialog = name;
		this.idChest = IdChest;
		this.wItem = 22;
		this.vecEffUni.removeAllElements();
		this.fontDia = mFont.tahoma_7_black;
		this.timeShowEff = 0;
		base.beginDia();
		this.cmdList = new mVector();
		bool flag = type == 0 || type == 3;
		if (flag)
		{
			this.strphanthuong = T.phanthuong;
			this.indexShowItemBox = this.mItemgift.Length;
		}
		else
		{
			bool flag2 = type == 1 || type == 2 || type >= 10;
			if (flag2)
			{
				this.wItem = 26;
				this.strphanthuong = T.nhanduoc;
				this.indexShowItemBox = 0;
				bool flag3 = type >= 10 && type < 20;
				if (flag3)
				{
					this.typeBanner = type - 10;
				}
				bool flag4 = type == 1;
				if (flag4)
				{
					bool flag5 = this.checkRuongInInventory();
					if (flag5)
					{
						iCommand o = new iCommand(T.openNext, 11, this);
						this.cmdList.addElement(o);
					}
				}
				else
				{
					bool flag6 = type == 21;
					if (flag6)
					{
						this.fraRuongVip = null;
						this.indexShowItemBox = this.mItemgift.Length;
						MainImage imageAll = ObjectData.getImageAll(this.idChest, ObjectData.HashImageOtherNew, 23000);
						bool flag7 = imageAll != null && imageAll.img != null;
						if (flag7)
						{
							this.fraRuongVip = new FrameImage(imageAll.img, 2);
						}
						this.vecEffUni.addElement(GameScreen.createEffectEndTime(144, 1, MotherCanvas.hw, MotherCanvas.hh, 2300, 0, null));
					}
				}
			}
		}
		this.cmdClose = new iCommand(T.close, 10, this);
		this.cmdList.addElement(this.cmdClose);
		this.strinfo = null;
		this.wDia = 160;
		bool flag8 = mitem != null;
		if (flag8)
		{
			for (int i = 0; i < mitem.Length; i++)
			{
				string s = mitem[i].num.ToString() + " " + mitem[i].name;
				bool flag9 = mitem[i].typeObject == 3;
				if (flag9)
				{
					s = mitem[i].name;
				}
				int width = mFont.tahoma_7b_black.getWidth(s);
				bool flag10 = width + 60 > this.wDia;
				if (flag10)
				{
					this.wDia = width + 60;
				}
			}
		}
		bool flag11 = this.wDia > MotherCanvas.w;
		if (flag11)
		{
			this.wDia = MotherCanvas.w;
		}
		bool flag12 = type == 20;
		if (flag12)
		{
			this.wDia = 190;
			this.wItem = 44;
		}
		int num = 0;
		bool flag13 = info != null && info.Length > 0;
		if (flag13)
		{
			this.strinfo = this.fontDia.splitFontArray(info, this.wDia - 20);
			num = this.strinfo.Length;
		}
		this.hDia = GameCanvas.hText * num + MsgDialog.hPlus + (iCommand.hButtonCmdNor + this.wItem);
		this.hDia += GameCanvas.hCommand;
		bool flag14 = this.mItemgift != null;
		if (flag14)
		{
			bool flag15 = type == 3;
			if (flag15)
			{
				this.hDia += this.mItemgift.Length * 50;
				bool flag16 = mitem != null;
				if (flag16)
				{
					for (int j = 0; j < mitem.Length; j++)
					{
						this.typeBanner = (sbyte)(mitem[j].IdIcon - 500);
					}
				}
			}
			else
			{
				bool flag17 = type == 20;
				if (flag17)
				{
					this.hDia = (this.mItemgift.Length / 3 + 1) * this.wItem + iCommand.hButtonCmdNor;
				}
				else
				{
					this.hDia += this.mItemgift.Length * this.wItem;
				}
			}
		}
		bool flag18 = !GameCanvas.lowGraphic && (int)this.typeBanner >= AvMain.fraBorderWanted.nFrame;
		if (flag18)
		{
			this.typeBanner = (sbyte)(AvMain.fraBorderWanted.nFrame - 1);
		}
		this.maxWShow = this.wDia;
		this.wShowPaper = 5;
		this.xDia = MotherCanvas.hw - this.wDia / 2;
		this.yDia = MotherCanvas.hh - this.hDia / 2 - 5;
		base.setPosCmdNew(-2, false);
	}

	// Token: 0x06000A56 RID: 2646 RVA: 0x0000B431 File Offset: 0x00009631
	public void setCmdList(mVector vecCmd)
	{
		this.cmdList = vecCmd;
		base.setPosCmdNew(-2, false);
	}

	// Token: 0x06000A57 RID: 2647 RVA: 0x000D25E8 File Offset: 0x000D07E8
	public void setinfoShow_Gift_OnHead(sbyte type, string name, string info, Item_Drop[] mitem, short IdChest, MainObject obj)
	{
		this.fraRuongVip = null;
		this.type = (int)type;
		this.mItemgift = mitem;
		this.nameDialog = name;
		this.idChest = IdChest;
		this.objPaint = obj;
		this.speed = 3;
		bool flag = this.mItemgift.Length >= 5;
		if (flag)
		{
			this.speed = 4;
		}
		GameCanvas.chatTabScr.addNewChat(T.tabSieuBoss, string.Empty, "-- " + info + " --", 1, false, 0);
		for (int i = 0; i < this.mItemgift.Length; i++)
		{
			Item_Drop item_Drop = this.mItemgift[i];
			item_Drop.y = -(24 * i);
			string content = item_Drop.num.ToString() + " " + item_Drop.name;
			bool flag2 = item_Drop.typeObject == 3;
			if (flag2)
			{
				content = item_Drop.name;
			}
			GameCanvas.chatTabScr.addNewChat(T.tabSieuBoss, string.Empty, content, 1, false, 5);
		}
	}

	// Token: 0x06000A58 RID: 2648 RVA: 0x000D26EC File Offset: 0x000D08EC
	private bool checkRuongInInventory()
	{
		bool flag = MsgShowGift.gift == null;
		bool result;
		if (flag)
		{
			result = false;
		}
		else
		{
			for (int i = 0; i < Player.vecInventory.size(); i++)
			{
				MainItem mainItem = (MainItem)Player.vecInventory.elementAt(i);
				bool flag2 = mainItem.ID == MsgShowGift.gift.ID && mainItem.typeObject == MsgShowGift.gift.typeObject;
				if (flag2)
				{
					return mainItem.numPotion > 1;
				}
			}
			result = false;
		}
		return result;
	}

	// Token: 0x06000A59 RID: 2649 RVA: 0x000D2784 File Offset: 0x000D0984
	public override void paint(mGraphics g)
	{
		bool flag = this.type == 22;
		if (flag)
		{
			for (int i = 0; i < this.mItemgift.Length; i++)
			{
				Item_Drop item_Drop = this.mItemgift[i];
				bool flag2 = item_Drop.y < 0 || item_Drop.y >= 120;
				if (!flag2)
				{
					bool flag3 = item_Drop.typeObject == 99;
					if (flag3)
					{
						g.drawImage(AvMain.imgXp, this.objPaint.x, this.objPaint.y - 52 - item_Drop.y, 3);
						AvMain.setTextColor((int)item_Drop.colorName).drawString(g, " " + item_Drop.num.ToString() + item_Drop.name, this.objPaint.x + 14, this.objPaint.y - 56 - item_Drop.y, 0);
					}
					else
					{
						item_Drop.paintXY(g, this.objPaint.x, this.objPaint.y - 52 - item_Drop.y);
						string str = item_Drop.num.ToString() + " " + item_Drop.name;
						bool flag4 = item_Drop.typeObject == 3;
						if (flag4)
						{
							str = item_Drop.name;
						}
						AvMain.Font3dColor(g, str, this.objPaint.x + 15, this.objPaint.y - 56 - item_Drop.y, 0, item_Drop.colorName);
					}
				}
			}
		}
		else
		{
			GameCanvas.resetTrans(g);
			bool flag5 = this.type == 21 && (this.indexShow == 0 || this.indexShow == 1);
			if (flag5)
			{
				for (int j = 0; j < this.vecEffUni.size(); j++)
				{
					MainEffect mainEffect = (MainEffect)this.vecEffUni.elementAt(j);
					bool flag6 = mainEffect.levelPaint == -1;
					if (flag6)
					{
						mainEffect.paint(g, 0, 0);
					}
				}
				this.paintShowVip(g);
				GameCanvas.resetTrans(g);
			}
			else
			{
				bool flag7 = this.type == 21;
				if (flag7)
				{
					AvMain.paintRuongVip(g, MotherCanvas.hw - this.maxWShow / 2 - 4, this.yDia - 4, this.maxWShow + 8, this.hDia + 8);
					GameCanvas.resetTrans(g);
				}
				else
				{
					bool flag8 = this.type == 2 || this.type == 3 || (this.type >= 10 && this.type <= 19);
					if (flag8)
					{
						AvMain.paintThongThao(g, MotherCanvas.hw - this.maxWShow / 2, this.yDia, this.maxWShow, this.hDia);
						GameCanvas.resetTrans(g);
					}
					else
					{
						base.paintPaper(g, MotherCanvas.hw - this.wShowPaper / 2, this.yDia, this.wShowPaper, this.hDia, this.maxWShow, (int)AvMain.PAPER_NORMAL);
						GameCanvas.resetTrans(g);
						g.setClip(MotherCanvas.hw - this.wShowPaper / 2, 0, this.wShowPaper, MotherCanvas.h);
					}
				}
				this.paintBanner(g);
				AvMain.FontBorderColor(g, this.nameDialog, this.xDia + this.wDia / 2, this.yDia + 15, 2, 6, 5);
				int num = this.yDia + GameCanvas.hCommand + 10;
				bool flag9 = this.strinfo != null;
				if (flag9)
				{
					for (int k = 0; k < this.strinfo.Length; k++)
					{
						bool flag10 = k == 0 && this.type == 0;
						if (flag10)
						{
							mFont.tahoma_7b_black.drawString(g, this.strinfo[k], this.xDia + this.wDia / 2, num, 2);
						}
						else
						{
							this.fontDia.drawString(g, this.strinfo[k], this.xDia + 15, num, 0);
						}
						num += GameCanvas.hText;
					}
				}
				bool flag11 = this.mItemgift != null;
				if (flag11)
				{
					bool flag12 = this.type == 20;
					if (flag12)
					{
						this.paintItemQuaySo(g, num);
					}
					else
					{
						this.paintItemNormal(g, num);
					}
				}
				for (int l = 0; l < this.vecEffUni.size(); l++)
				{
					MainEffect mainEffect2 = (MainEffect)this.vecEffUni.elementAt(l);
					bool flag13 = mainEffect2.levelPaint != -1;
					if (flag13)
					{
						mainEffect2.paint(g);
						mainEffect2.paint(g, 0, 0);
					}
				}
				bool flag14 = this.cmdList != null;
				if (flag14)
				{
					for (int m = 0; m < this.cmdList.size(); m++)
					{
						iCommand iCommand = (iCommand)this.cmdList.elementAt(m);
						iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
					}
				}
			}
		}
	}

	// Token: 0x06000A5A RID: 2650 RVA: 0x000D2CA0 File Offset: 0x000D0EA0
	private void paintShowVip(mGraphics g)
	{
		bool flag = this.indexShow == 0;
		if (flag)
		{
			bool flag2 = this.fraRuongVip == null;
			if (!flag2)
			{
				int num = this.timeShowEff;
				bool flag3 = num >= this.mShowRuongVip.Length;
				if (!flag3)
				{
					int num2 = 0;
					int num3 = 0;
					bool flag4 = this.timeShowEff >= 10 && this.timeShowEff < 24;
					if (flag4)
					{
						num2 = CRes.random_Am_0(2);
						num3 = CRes.random_Am_0(2);
					}
					else
					{
						bool flag5 = this.timeShowEff >= 24;
						if (flag5)
						{
							num2 = CRes.random_Am_0(3);
							num3 = CRes.random_Am_0(2);
						}
					}
					for (int i = 0; i < 3; i++)
					{
						g.drawRegion(this.fraRuongVip.imgFrame, i % 3 * this.fraRuongVip.frameWidth / 3, 0, this.fraRuongVip.frameWidth / 3, this.fraRuongVip.frameHeight, 0, (float)(MotherCanvas.hw - this.fraRuongVip.frameWidth / 2 + i % 3 * (this.fraRuongVip.frameWidth / 3) + num2), (float)(MotherCanvas.hh - this.fraRuongVip.frameHeight / 2 + this.mShowRuongVip[num][i % 3] + num3), 0);
						bool flag6 = i == 1;
						if (flag6)
						{
							AvMain.fraEffOpen.drawFrame(this.timeShowEff % AvMain.fraEffOpen.nFrame, MotherCanvas.hw + num2, MotherCanvas.hh + num3, 0, 3, g);
						}
					}
				}
			}
		}
		else
		{
			bool flag7 = this.indexShow == 1 && this.fraRuongVip != null;
			if (flag7)
			{
				this.fraRuongVip.drawFrame(1, MotherCanvas.hw, MotherCanvas.hh, 0, 3, g);
			}
		}
	}

	// Token: 0x06000A5B RID: 2651 RVA: 0x000D2E6C File Offset: 0x000D106C
	private void paintItemNormal(mGraphics g, int ypaint)
	{
		this.fontDia.drawString(g, this.strphanthuong, this.xDia + 15, ypaint, 0);
		bool flag = this.type != 3;
		if (flag)
		{
			AvMain.paintRect(g, this.xDia + 10, ypaint + this.wItem / 2 + 5, this.wDia - 20, this.mItemgift.Length * this.wItem, 0, 4);
		}
		ypaint += this.wItem;
		this.yShowEff = ypaint;
		for (int i = 0; i < this.indexShowItemBox; i++)
		{
			bool flag2 = i >= this.mItemgift.Length;
			if (!flag2)
			{
				Item_Drop item_Drop = this.mItemgift[i];
				bool flag3 = this.type == 3;
				if (flag3)
				{
					item_Drop.paintXY(g, this.xDia + this.wDia / 2, ypaint + 16);
					ypaint += 50;
				}
				else
				{
					bool flag4 = item_Drop.typeObject == 99;
					if (flag4)
					{
						g.drawImage(AvMain.imgXp, this.xDia + 28, ypaint + this.wItem / 4 + 1, 3);
						AvMain.setTextColor((int)item_Drop.colorName).drawString(g, " " + item_Drop.num.ToString() + item_Drop.name, this.xDia + 42, ypaint, 0);
					}
					else
					{
						item_Drop.paintXY(g, this.xDia + 28, ypaint + this.wItem / 4);
						string str = item_Drop.num.ToString() + " " + item_Drop.name;
						bool flag5 = item_Drop.typeObject == 3;
						if (flag5)
						{
							str = item_Drop.name;
						}
						AvMain.Font3dColor(g, str, this.xDia + 43, ypaint, 0, item_Drop.colorName);
					}
					ypaint += this.wItem;
				}
			}
		}
	}

	// Token: 0x06000A5C RID: 2652 RVA: 0x000D304C File Offset: 0x000D124C
	public void paintBanner(mGraphics g)
	{
		bool flag = this.type == 21;
		if (flag)
		{
			g.setColor(15509578);
			g.fillRect(this.xDia + this.wDia / 2 - 45, this.yDia + 13, 90, 16);
			g.setColor(16770995);
			g.fillRect(this.xDia + this.wDia / 2 - 45, this.yDia + 14, 90, 14);
			g.setColor(16775390);
			g.fillRect(this.xDia + this.wDia / 2 - 45, this.yDia + 17, 90, 8);
			g.drawRegion(AvMain.imgBannerRuong, 0, 0, 16, 16, 0, (float)(this.xDia + this.wDia / 2 - 45 - 15), (float)(this.yDia + 11 + 2), 0);
			g.drawRegion(AvMain.imgBannerRuong, 0, 0, 16, 16, 2, (float)(this.xDia + this.wDia / 2 + 45 - 1), (float)(this.yDia + 11 + 2), 0);
		}
		else
		{
			bool flag2 = this.type == 20;
			if (flag2)
			{
				bool flag3 = AvMain.mImgDialogVongQuay == null;
				if (flag3)
				{
					this.loadmImg();
				}
				g.setColor(10451279);
				g.fillRect(this.xDia + this.wDia / 2 - 60, this.yDia + 13, 120, 16);
				g.setColor(12358501);
				g.fillRect(this.xDia + this.wDia / 2 - 60, this.yDia + 14, 120, 14);
				g.drawRegion(AvMain.mImgDialogVongQuay[0], 0, 0, 16, 16, 0, (float)(this.xDia + this.wDia / 2 - 60 - 15), (float)(this.yDia + 11 + 2), 0);
				g.drawRegion(AvMain.mImgDialogVongQuay[0], 0, 0, 16, 16, 2, (float)(this.xDia + this.wDia / 2 + 60 - 1), (float)(this.yDia + 11 + 2), 0);
			}
			else
			{
				bool flag4 = this.typeBanner >= 0 && !GameCanvas.lowGraphic;
				if (flag4)
				{
					g.setColor(MsgShowGift.colorBorder[(int)(this.typeBanner * 3)]);
					g.fillRect(this.xDia + 16, this.yDia + 11, this.wDia - 30, 20);
					g.setColor(MsgShowGift.colorBorder[(int)(this.typeBanner * 3 + 1)]);
					g.fillRect(this.xDia + 17, this.yDia + 12, this.wDia - 32, 18);
					g.setColor(MsgShowGift.colorBorder[(int)(this.typeBanner * 3 + 2)]);
					g.fillRect(this.xDia + 18, this.yDia + 13, this.wDia - 34, 16);
					AvMain.fraBorderWanted.drawFrame((int)this.typeBanner, this.xDia + 15, this.yDia + 11 + 10, 0, 3, g);
					AvMain.fraBorderWanted.drawFrame((int)this.typeBanner, this.xDia + 15 + (this.wDia - 28), this.yDia + 11 + 10, 2, 3, g);
				}
				else
				{
					g.setColor(15972174);
					g.fillRoundRect(this.xDia + 10, this.yDia + 12, this.wDia - 20, 16, 4, 4);
				}
			}
		}
	}

	// Token: 0x06000A5D RID: 2653 RVA: 0x000D33D0 File Offset: 0x000D15D0
	private void paintItemQuaySo(mGraphics g, int ypaint)
	{
		bool flag = AvMain.mImgDialogVongQuay == null;
		if (flag)
		{
			this.loadmImg();
		}
		for (int i = 0; i < this.mItemgift.Length / 3; i++)
		{
			g.setColor(MsgShowGift.colorBorderVongQuay[i % 2]);
			g.fillRect(this.xDia + this.wDia / 2 - 50, ypaint + i * this.wItem, 100, 36);
			g.setColor(MsgShowGift.colorBorderVongQuay[2 + i % 2]);
			g.fillRect(this.xDia + this.wDia / 2 - 50, ypaint + i * this.wItem, 100, 36);
			g.drawRegion(AvMain.mImgDialogVongQuay[1 + i % 2], 0, 0, 36, 36, 0, (float)(this.xDia + this.wDia / 2 - 80), (float)(ypaint + i * this.wItem), 0);
			g.drawRegion(AvMain.mImgDialogVongQuay[1 + i % 2], 0, 36, 36, 36, 0, (float)(this.xDia + this.wDia / 2 + 80 - 36), (float)(ypaint + i * this.wItem), 0);
			g.drawRegion(AvMain.mImgDialogVongQuay[4], 0, i * 17, 13, 17, 0, (float)(this.xDia + this.wDia / 2 - 70), (float)(ypaint + i * this.wItem + this.wItem / 2 - 5), 3);
		}
		for (int j = 0; j < this.mItemgift.Length; j++)
		{
			int num = this.xDia + this.wDia / 2 - this.wItem + this.wItem * (j % 3);
			int num2 = ypaint + this.wItem / 2 + this.wItem * (j / 3) - 4;
			g.drawRegion(AvMain.mImgDialogVongQuay[3], 0, j / 3 % 2 * 30, 30, 30, 0, (float)num, (float)num2, 3);
			bool flag2 = j >= this.indexShowItemBox;
			if (!flag2)
			{
				Item_Drop item_Drop = this.mItemgift[j];
				bool flag3 = item_Drop.IdIcon >= 0;
				if (flag3)
				{
					bool flag4 = item_Drop.typeObject == 99;
					if (flag4)
					{
						g.drawImage(AvMain.imgXp, num, num2 - 3, 3);
					}
					else
					{
						item_Drop.paintXY(g, num, num2 - 3);
					}
					AvMain.setTextColor((int)item_Drop.colorName).drawString(g, item_Drop.num.ToString() + string.Empty, num - 1, num2 + 3, 0);
				}
			}
		}
	}

	// Token: 0x06000A5E RID: 2654 RVA: 0x000D365C File Offset: 0x000D185C
	private void loadmImg()
	{
		AvMain.mImgDialogVongQuay = new mImage[5];
		for (int i = 0; i < AvMain.mImgDialogVongQuay.Length; i++)
		{
			AvMain.mImgDialogVongQuay[i] = mImage.createImage("/interface/diavongquay" + i.ToString() + ".png");
		}
	}

	// Token: 0x06000A5F RID: 2655 RVA: 0x000D36B0 File Offset: 0x000D18B0
	public override void update()
	{
		for (int i = 0; i < this.vecEffUni.size(); i++)
		{
			MainEffect mainEffect = (MainEffect)this.vecEffUni.elementAt(i);
			mainEffect.update();
			bool isStop = mainEffect.isStop;
			if (isStop)
			{
				this.vecEffUni.removeElement(mainEffect);
				i--;
			}
		}
		bool flag = this.type == 22;
		if (flag)
		{
			this.timeClose++;
			bool flag2 = this.mItemgift != null;
			if (flag2)
			{
				bool flag3 = true;
				for (int j = 0; j < this.mItemgift.Length; j++)
				{
					Item_Drop item_Drop = this.mItemgift[j];
					item_Drop.y += this.speed;
					bool flag4 = item_Drop.y < 0;
					if (flag4)
					{
						flag3 = false;
					}
				}
				bool flag5 = flag3;
				if (flag5)
				{
					this.countClose++;
					bool flag6 = this.countClose >= 40;
					if (flag6)
					{
						GameCanvas.showDialog = null;
					}
				}
			}
			else
			{
				GameCanvas.showDialog = null;
			}
			bool flag7 = this.timeClose >= 200;
			if (flag7)
			{
				GameCanvas.showDialog = null;
			}
		}
		else
		{
			bool isClose = this.isClose;
			if (isClose)
			{
				base.updateClose();
			}
			else
			{
				base.updateOpen();
				bool flag8 = GameCanvas.isTouchNoOrPC();
				if (flag8)
				{
					this.updatekey();
				}
				this.updatePointer();
				bool flag9 = this.type == 21;
				if (flag9)
				{
					this.timeShowEff++;
					bool flag10 = this.indexShow == 0;
					if (flag10)
					{
						bool flag11 = this.timeShowEff % 10 == 0 && this.timeShowEff <= 30;
						if (flag11)
						{
							mSound.playSound(27, mSound.volumeSound);
						}
						bool flag12 = this.timeShowEff >= this.mShowRuongVip.Length;
						if (flag12)
						{
							this.indexShow = 1;
							this.timeShowEff = 0;
							mSound.playSound(52, mSound.volumeSound);
						}
						bool flag13 = this.timeShowEff % 5 == 0 && this.fraRuongVip == null;
						if (flag13)
						{
							MainImage imageAll = ObjectData.getImageAll(this.idChest, ObjectData.HashImageOtherNew, 23000);
							bool flag14 = imageAll != null && imageAll.img != null;
							if (flag14)
							{
								this.fraRuongVip = new FrameImage(imageAll.img, 2);
							}
						}
					}
					else
					{
						bool flag15 = this.indexShow == 1 && this.timeShowEff >= 3;
						if (flag15)
						{
							this.indexShow = 2;
						}
					}
				}
				else
				{
					bool flag16 = this.type == 1 || this.type == 2 || (this.type >= 10 && this.type <= 19);
					if (flag16)
					{
						bool flag17 = this.indexShowItemBox < this.mItemgift.Length;
						if (flag17)
						{
							this.timeShowEff++;
							bool flag18 = this.timeShowEff % 10 == 2;
							if (flag18)
							{
								mSound.playSound(26, mSound.volumeSound);
								this.vecEffUni.addElement(GameScreen.CreateEffectEnd(53, 0, this.xDia + 30, this.yShowEff + this.indexShowItemBox * this.wItem, 0, null));
							}
							bool flag19 = this.timeShowEff % 10 == 0;
							if (flag19)
							{
								this.indexShowItemBox++;
							}
						}
					}
					else
					{
						bool flag20 = this.type == 20 && this.indexShowItemBox < this.mItemgift.Length;
						if (flag20)
						{
							this.timeShowEff++;
							bool flag21 = this.timeShowEff % 10 == 2;
							if (flag21)
							{
								int x = this.xDia + this.wDia / 2 - this.wItem + this.wItem * (this.indexShowItemBox % 3);
								int y = this.yDia + GameCanvas.hCommand + 10 + this.wItem / 2 + this.wItem * (this.indexShowItemBox / 3) - 4;
								mSound.playSound(47, mSound.volumeSound);
								this.vecEffUni.addElement(GameScreen.CreateEffectEnd(53, 0, x, y, 0, null));
							}
							bool flag22 = this.timeShowEff % 10 == 0;
							if (flag22)
							{
								this.indexShowItemBox++;
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x06000A60 RID: 2656 RVA: 0x000D3B2C File Offset: 0x000D1D2C
	public override void updatekey()
	{
		bool flag = this.type == 22 || (this.type == 21 && this.indexShow != 2);
		if (!flag)
		{
			int idCommand = this.idCommand;
			int num = this.cmdList.size();
			bool flag2 = GameCanvas.keyMove(0);
			if (flag2)
			{
				this.idCommand--;
				GameCanvas.ClearkeyMove(0);
			}
			else
			{
				bool flag3 = GameCanvas.keyMove(2);
				if (flag3)
				{
					this.idCommand++;
					GameCanvas.ClearkeyMove(2);
				}
			}
			this.idCommand = AvMain.resetSelect(this.idCommand, num - 1, false);
			bool flag4 = idCommand != this.idCommand && GameCanvas.isTouchNoOrPC();
			if (flag4)
			{
				iCommand iCommand = (iCommand)this.cmdList.elementAt(this.idCommand);
				bool flag5 = iCommand.caption.Length <= 0;
				if (flag5)
				{
					this.idCommand = 0;
				}
				for (int i = 0; i < num; i++)
				{
					iCommand iCommand2 = (iCommand)this.cmdList.elementAt(i);
					bool flag6 = i == this.idCommand;
					if (flag6)
					{
						iCommand2.isSelect = true;
					}
					else
					{
						iCommand2.isSelect = false;
					}
				}
			}
			bool flag7 = GameCanvas.keyMyHold[5];
			if (flag7)
			{
				GameCanvas.clearKeyHold(5);
				bool flag8 = this.cmdList != null && this.idCommand < this.cmdList.size();
				if (flag8)
				{
					((iCommand)this.cmdList.elementAt(this.idCommand)).perform();
				}
			}
		}
	}

	// Token: 0x06000A61 RID: 2657 RVA: 0x000D3CD8 File Offset: 0x000D1ED8
	public override void updatePointer()
	{
		bool flag = this.type != 22 && (this.type != 21 || this.indexShow == 2);
		if (flag)
		{
			base.updatePointer();
		}
	}

	// Token: 0x0400103C RID: 4156
	public const sbyte GIFT_QUEST = 0;

	// Token: 0x0400103D RID: 4157
	public const sbyte OPEN_BOX = 1;

	// Token: 0x0400103E RID: 4158
	public const sbyte OPEN_BOX_WANTED = 2;

	// Token: 0x0400103F RID: 4159
	public const sbyte GIFT_CHEST_WANTED = 3;

	// Token: 0x04001040 RID: 4160
	public const sbyte OPEN_BOX_WANTED_GO = 10;

	// Token: 0x04001041 RID: 4161
	public const sbyte OPEN_BOX_WANTED_VANG = 11;

	// Token: 0x04001042 RID: 4162
	public const sbyte OPEN_BOX_WANTED_MATHUAT = 12;

	// Token: 0x04001043 RID: 4163
	public const sbyte OPEN_BOX_WANTED_KHONGLO = 13;

	// Token: 0x04001044 RID: 4164
	public const sbyte OPEN_BOX_WANTED_SIEUMATHUAT = 14;

	// Token: 0x04001045 RID: 4165
	public const sbyte OPEN_BOX_WANTED_THANTHOAI = 15;

	// Token: 0x04001046 RID: 4166
	public const sbyte OPEN_BOX_QUAY_SO = 20;

	// Token: 0x04001047 RID: 4167
	public const sbyte OPEN_BOX_VIP = 21;

	// Token: 0x04001048 RID: 4168
	public const sbyte OPEN_BOX_ON_HEAD = 22;

	// Token: 0x04001049 RID: 4169
	public const sbyte OPEN_BOX_TYPE_ITEM_DROP = 23;

	// Token: 0x0400104A RID: 4170
	public const sbyte OPEN_BOX_TYPE_ITEM_DROP_2 = 24;

	// Token: 0x0400104B RID: 4171
	public const sbyte SHOW_RUONG = 0;

	// Token: 0x0400104C RID: 4172
	public const sbyte SHOW_OPEN_RUONG = 1;

	// Token: 0x0400104D RID: 4173
	public const sbyte SHOW_GIFT = 2;

	// Token: 0x0400104E RID: 4174
	private Item_Drop[] mItemgift;

	// Token: 0x0400104F RID: 4175
	private string strphanthuong = string.Empty;

	// Token: 0x04001050 RID: 4176
	private MainObject objPaint;

	// Token: 0x04001051 RID: 4177
	private int indexShowItemBox;

	// Token: 0x04001052 RID: 4178
	private int timeShowEff;

	// Token: 0x04001053 RID: 4179
	private int yShowEff;

	// Token: 0x04001054 RID: 4180
	private int speed;

	// Token: 0x04001055 RID: 4181
	private int countClose;

	// Token: 0x04001056 RID: 4182
	private int timeClose;

	// Token: 0x04001057 RID: 4183
	private short idChest;

	// Token: 0x04001058 RID: 4184
	private FrameImage fraRuongVip;

	// Token: 0x04001059 RID: 4185
	public static MainItem gift;

	// Token: 0x0400105A RID: 4186
	private sbyte typeBanner = -1;

	// Token: 0x0400105B RID: 4187
	private sbyte indexShow;

	// Token: 0x0400105C RID: 4188
	public static int[] colorBorder = new int[]
	{
		7351040,
		9062926,
		9062926,
		6619136,
		9175040,
		11993088,
		1377112,
		2494085,
		4202940,
		6829826,
		10115089,
		13403438,
		1049732,
		1179830,
		3742207,
		264001,
		1119857,
		1582026
	};

	// Token: 0x0400105D RID: 4189
	public static int[] colorBorderVongQuay = new int[]
	{
		15384971,
		13214061,
		15913633,
		13808516
	};

	// Token: 0x0400105E RID: 4190
	private int[][] mShowRuongVip = new int[][]
	{
		new int[]
		{
			-1,
			0,
			1
		},
		new int[]
		{
			-1,
			0,
			1
		},
		new int[3],
		new int[3],
		new int[]
		{
			1,
			0,
			-1
		},
		new int[]
		{
			1,
			0,
			-1
		},
		new int[]
		{
			-1,
			0,
			1
		},
		new int[]
		{
			-1,
			0,
			1
		},
		new int[3],
		new int[3],
		new int[]
		{
			1,
			0,
			-1
		},
		new int[]
		{
			1,
			0,
			-1
		},
		new int[]
		{
			-1,
			0,
			1
		},
		new int[]
		{
			-1,
			0,
			1
		},
		new int[3],
		new int[3],
		new int[]
		{
			1,
			0,
			-1
		},
		new int[]
		{
			1,
			0,
			-1
		},
		new int[]
		{
			-1,
			0,
			1
		},
		new int[3],
		new int[]
		{
			1,
			0,
			-1
		},
		new int[]
		{
			-1,
			0,
			1
		},
		new int[3],
		new int[]
		{
			1,
			0,
			-1
		},
		new int[]
		{
			-1,
			0,
			1
		},
		new int[3],
		new int[]
		{
			1,
			0,
			-1
		},
		new int[]
		{
			-1,
			0,
			1
		},
		new int[3],
		new int[]
		{
			1,
			0,
			-1
		},
		new int[3],
		new int[]
		{
			1,
			0,
			-1
		},
		new int[]
		{
			-1,
			0,
			1
		},
		new int[3],
		new int[]
		{
			1,
			0,
			-1
		},
		new int[]
		{
			-1,
			0,
			1
		},
		new int[3],
		new int[]
		{
			1,
			0,
			-1
		}
	};
}
