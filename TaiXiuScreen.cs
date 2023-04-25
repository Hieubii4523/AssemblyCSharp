using System;

// Token: 0x02000106 RID: 262
public class TaiXiuScreen : LuckyScreen
{
	// Token: 0x06000F3B RID: 3899 RVA: 0x00125B44 File Offset: 0x00123D44
	public TaiXiuScreen(string name, int tongTai, int tongXiu, int daCuoc, sbyte cua, short time)
	{
		this.nameList = name;
		this.tongTienTai = tongTai;
		this.tongTienXiu = tongXiu;
		this.daCuoc = daCuoc;
		this.cua = cua;
		this.countDown = time;
		this.w = 260;
		this.h = 215;
		this.x = MotherCanvas.hw - this.w / 2;
		this.y = MotherCanvas.hh - this.h / 2;
		this.cmdClose = new iCommand(T.close, -1, this);
		this.cmdDatCuoc = new iCommand(T.datCuoc, 1, this);
		this.cmdTatTay = new iCommand(T.tatTay, 2, this);
		this.cmdDatCuoc.setPos(this.x + this.w / 4, this.y + 190, null, T.datCuoc);
		this.cmdTatTay.setPos(this.x + this.w / 4 * 3, this.y + 190, null, T.tatTay);
		this.vecCmd = new mVector();
		this.vecCmd.addElement(this.cmdDatCuoc);
		this.vecCmd.addElement(this.cmdTatTay);
		this.vecCmd.addElement(this.cmdClose);
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.cmdClose.setPos(this.x + this.w / 2 + 60, this.y + 10 + 8, MainTab.fraCloseTab, string.Empty);
		}
		else
		{
			this.right = this.cmdClose;
		}
		this.fraTaiXiu = new FrameImage(mImage.createImage("/interface/taixiu.png"), 4);
		this.fraXucXac = new FrameImage(mImage.createImage("/interface/xucxac.png"), 6);
		this.cmdCuocTai = new iCommand(T.datCuoc + " " + T.tai, 11, this);
		this.cmdCuocXiu = new iCommand(T.datCuoc + " " + T.xiu, 12, this);
		this.cmdDatCuocTai = new iCommand(T.datCuoc, 111, this);
		this.cmdDatCuocXiu = new iCommand(T.datCuoc, 121, this);
		this.cmdTTTai = new iCommand(T.tatTay + " " + T.tai, 21, this);
		this.cmdTTT1m = new iCommand(T.tatTay + " " + T.tai + " 1M", 31, this);
		this.cmdTTT2m = new iCommand(T.tatTay + " " + T.tai + " 2M", 32, this);
		this.cmdTTT3m = new iCommand(T.tatTay + " " + T.tai + " 3M", 33, this);
		this.cmdTTT4m = new iCommand(T.tatTay + " " + T.tai + " 4M", 34, this);
		this.cmdTTT5m = new iCommand(T.tatTay + " " + T.tai + " 5M", 35, this);
		this.cmdTTXiu = new iCommand(T.tatTay + " " + T.xiu, 22, this);
		this.cmdTTX1m = new iCommand(T.tatTay + " " + T.xiu + " 1M", 41, this);
		this.cmdTTX2m = new iCommand(T.tatTay + " " + T.xiu + " 2M", 42, this);
		this.cmdTTX3m = new iCommand(T.tatTay + " " + T.xiu + " 3M", 43, this);
		this.cmdTTX4m = new iCommand(T.tatTay + " " + T.xiu + " 4M", 44, this);
		this.cmdTTX5m = new iCommand(T.tatTay + " " + T.xiu + " 5M", 45, this);
		this.timeBegin = mSystem.currentTimeMillis();
		this.timeUpdate = mSystem.currentTimeMillis();
		this.index1 = CRes.random(6);
		this.index2 = CRes.random(6);
		this.index3 = CRes.random(6);
		this.indexShowKq = -1;
		this.StepQuaySo = 0;
	}

	// Token: 0x06000F3C RID: 3900 RVA: 0x00125FFC File Offset: 0x001241FC
	public override void paint(mGraphics g)
	{
		bool flag = this.lastScreen != null;
		if (flag)
		{
			this.lastScreen.paint(g);
		}
		GameCanvas.resetTrans(g);
		MainTab.paintMoney(g, MotherCanvas.w - 78, 4 + GameScreen.h12plus, false);
		base.paintPaper(g, this.x, this.y, this.w, this.h, this.w, (int)AvMain.PAPER_NORMAL);
		g.setColor(14203529);
		g.fillRoundRect(this.x + this.w / 2 - 60, this.y + 10, 120, 16, 4, 4);
		AvMain.FontBorderColor(g, this.nameList, this.x + this.w / 2, this.y + 12, 2, 6, 5);
		AvMain.FontBorderColor(g, this.countDown.ToString() + string.Empty, MotherCanvas.hw, this.y + 35, 2, 1, 7);
		int num = this.x + this.w / 4 - 15;
		int num2 = this.y + 60;
		this.fraTaiXiu.drawFrame(0, num, num2, 0, 3, g);
		AvMain.paintRect(g, num - 30, num2 + 40, 60, 15, 1, 4);
		string st = (this.tongTienTai >= 1000000) ? AvMain.getMoneyShortText((long)this.tongTienTai) : AvMain.getDotNumber((long)this.tongTienTai);
		mFont.tahoma_7_yellow.drawString(g, st, num, num2 + 40 + 2, 2);
		int num3 = this.x + this.w / 4 * 3 + 15;
		this.fraTaiXiu.drawFrame(2, num3, num2, 0, 3, g);
		AvMain.paintRect(g, num3 - 30, num2 + 40, 60, 15, 1, 4);
		st = ((this.tongTienXiu >= 1000000) ? AvMain.getMoneyShortText((long)this.tongTienXiu) : AvMain.getDotNumber((long)this.tongTienXiu));
		mFont.tahoma_7_yellow.drawString(g, st, num3, num2 + 40 + 2, 2);
		int num4 = MotherCanvas.hw + 2;
		num2 = this.y + 150;
		mFont.tahoma_7_black.drawString(g, T.daCuoc, num4, num2, 1);
		mFont.tahoma_7_red.drawString(g, AvMain.getDotNumber((long)this.daCuoc), num4 + 2, num2, 0);
		mFont.tahoma_7_black.drawString(g, T.cua, num4, num2 + 15, 1);
		bool flag2 = this.cua == -1;
		if (flag2)
		{
			mFont.tahoma_7_red.drawString(g, "...", num4 + 2, num2 + 15, 0);
		}
		else
		{
			bool flag3 = this.cua == 0;
			if (flag3)
			{
				mFont.tahoma_7_red.drawString(g, T.xiu, num4 + 2, num2 + 15, 0);
			}
			else
			{
				mFont.tahoma_7_red.drawString(g, T.tai, num4 + 2, num2 + 15, 0);
			}
		}
		num4 = MotherCanvas.hw;
		num2 = this.y + 60;
		bool flag4 = this.StepQuaySo == 4;
		if (flag4)
		{
			num2 = this.y + 100;
			this.fraXucXac.drawFrame((int)(this.x1 - 1), num4 - 18, num2 - 5, 0, 3, g);
			this.fraXucXac.drawFrame((int)(this.x2 - 1), num4 + 20, num2 + 5, 0, 3, g);
			this.fraXucXac.drawFrame((int)(this.x3 - 1), num4 - 5, num2 + 20, 0, 3, g);
			bool flag5 = this.kq != -1;
			if (flag5)
			{
				num2 = this.y + 60;
				bool flag6 = this.kq == 1;
				if (flag6)
				{
					this.fraTaiXiu.drawFrame(1, num, num2, 0, 3, g);
				}
				else
				{
					bool flag7 = this.kq == 0;
					if (flag7)
					{
						this.fraTaiXiu.drawFrame(3, num3, num2, 0, 3, g);
					}
				}
			}
		}
		else
		{
			bool flag8 = this.StepQuaySo != 4;
			if (flag8)
			{
				num2 = this.y + 100;
				this.fraXucXac.drawFrame(this.index1, num4 - 18, num2 - 5, 0, 3, g);
				this.fraXucXac.drawFrame(this.index2, num4 + 20, num2 + 5, 0, 3, g);
				this.fraXucXac.drawFrame(this.index3, num4 - 5, num2 + 20, 0, 3, g);
				bool flag9 = this.indexShowKq != -1;
				if (flag9)
				{
					num2 = this.y + 60;
					bool flag10 = this.indexShowKq == 1;
					if (flag10)
					{
						this.fraTaiXiu.drawFrame(1, num, num2, 0, 3, g);
					}
					else
					{
						bool flag11 = this.indexShowKq == 0;
						if (flag11)
						{
							this.fraTaiXiu.drawFrame(3, num3, num2, 0, 3, g);
						}
					}
				}
			}
		}
		for (int i = 0; i < this.vecCmd.size(); i++)
		{
			iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
			iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
		}
		base.paintEff(g, 0);
	}

	// Token: 0x06000F3D RID: 3901 RVA: 0x001264F8 File Offset: 0x001246F8
	public override void commandPointer(int index, int subIndex)
	{
		if (index <= 21)
		{
			if (index <= 11)
			{
				switch (index)
				{
				case -1:
				{
					bool flag = this.lastScreen != null;
					if (flag)
					{
						this.lastScreen.Show(this.lastScreen.lastScreen);
					}
					else
					{
						GameCanvas.gameScr.Show();
					}
					break;
				}
				case 0:
					break;
				case 1:
				{
					mVector mVector = new mVector();
					mVector.addElement(this.cmdCuocTai);
					mVector.addElement(this.cmdCuocXiu);
					GameCanvas.menu.startAt(mVector, 2, T.datCuoc);
					break;
				}
				case 2:
				{
					mVector mVector2 = new mVector();
					mVector2.addElement(this.cmdTTTai);
					mVector2.addElement(this.cmdTTXiu);
					GameCanvas.menu.startAt(mVector2, 2, T.tatTay);
					break;
				}
				default:
					if (index == 11)
					{
						this.input = GameCanvas.Start_Input_Dialog(T.nhapSoTien, this.cmdDatCuocTai, true, T.datCuoc + " " + T.tai);
						GameCanvas.subDialog = this.input;
					}
					break;
				}
			}
			else if (index != 12)
			{
				if (index == 21)
				{
					mVector mVector3 = new mVector();
					mVector3.addElement(this.cmdTTT1m);
					mVector3.addElement(this.cmdTTT2m);
					mVector3.addElement(this.cmdTTT3m);
					mVector3.addElement(this.cmdTTT4m);
					mVector3.addElement(this.cmdTTT5m);
					GameCanvas.menu.startAt(mVector3, 2, T.tatTay + " " + T.tai);
				}
			}
			else
			{
				this.input = GameCanvas.Start_Input_Dialog(T.nhapSoTien, this.cmdDatCuocXiu, true, T.datCuoc + " " + T.xiu);
				GameCanvas.subDialog = this.input;
			}
		}
		else if (index <= 45)
		{
			if (index != 22)
			{
				switch (index)
				{
				case 31:
					GlobalService.gI().TaiXiu(0, 1, 1000000, 1, 1);
					break;
				case 32:
					GlobalService.gI().TaiXiu(0, 1, 2000000, 1, 1);
					break;
				case 33:
					GlobalService.gI().TaiXiu(0, 1, 3000000, 1, 1);
					break;
				case 34:
					GlobalService.gI().TaiXiu(0, 1, 4000000, 1, 1);
					break;
				case 35:
					GlobalService.gI().TaiXiu(0, 1, 5000000, 1, 1);
					break;
				case 41:
					GlobalService.gI().TaiXiu(0, 1, 1000000, 0, 1);
					break;
				case 42:
					GlobalService.gI().TaiXiu(0, 1, 2000000, 0, 1);
					break;
				case 43:
					GlobalService.gI().TaiXiu(0, 1, 3000000, 0, 1);
					break;
				case 44:
					GlobalService.gI().TaiXiu(0, 1, 4000000, 0, 1);
					break;
				case 45:
					GlobalService.gI().TaiXiu(0, 1, 5000000, 0, 1);
					break;
				}
			}
			else
			{
				mVector mVector4 = new mVector();
				mVector4.addElement(this.cmdTTX1m);
				mVector4.addElement(this.cmdTTX2m);
				mVector4.addElement(this.cmdTTX3m);
				mVector4.addElement(this.cmdTTX4m);
				mVector4.addElement(this.cmdTTX5m);
				GameCanvas.menu.startAt(mVector4, 2, T.tatTay + " " + T.xiu);
			}
		}
		else if (index != 111)
		{
			if (index == 121)
			{
				int num = 0;
				try
				{
					num = int.Parse(this.input.tfInput.getText());
					bool flag2 = num < 0;
					if (flag2)
					{
						num = 0;
					}
				}
				catch (Exception)
				{
					num = 0;
				}
				GameCanvas.end_Dialog();
				bool flag3 = num / 1000 > 0 && num % 1000 == 0 && num <= 500000;
				if (flag3)
				{
					GlobalService.gI().TaiXiu(0, 1, num, 0, 0);
				}
				else
				{
					GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.vuiLongNhapSoChan);
				}
			}
		}
		else
		{
			int num2 = 0;
			try
			{
				num2 = int.Parse(this.input.tfInput.getText());
				bool flag4 = num2 < 0;
				if (flag4)
				{
					num2 = 0;
				}
			}
			catch (Exception)
			{
				num2 = 0;
			}
			GameCanvas.end_Dialog();
			bool flag5 = num2 / 1000 > 0 && num2 % 1000 == 0 && num2 <= 500000;
			if (flag5)
			{
				GlobalService.gI().TaiXiu(0, 1, num2, 1, 0);
			}
			else
			{
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.vuiLongNhapSoChan);
			}
		}
	}

	// Token: 0x06000F3E RID: 3902 RVA: 0x001269F0 File Offset: 0x00124BF0
	public override void update()
	{
		base.update();
		bool flag = GameCanvas.timeNow - this.timeBegin >= 1000L && this.countDown > 0;
		if (flag)
		{
			this.timeBegin = GameCanvas.timeNow;
			this.countDown -= 1;
			bool flag2 = this.countDown == 0;
			if (flag2)
			{
				this.isSendSv = true;
			}
		}
		bool flag3 = this.isSendSv && GameCanvas.timeNow - this.timeBegin >= 3000L;
		if (flag3)
		{
			GlobalService.gI().TaiXiu(0, 2);
			this.isSendSv = false;
		}
		bool flag4 = GameCanvas.timeNow - this.timeUpdate >= 5000L;
		if (flag4)
		{
			this.timeUpdate = GameCanvas.timeNow;
			GlobalService.gI().TaiXiu(0, 3);
		}
	}

	// Token: 0x06000F3F RID: 3903 RVA: 0x00126ACC File Offset: 0x00124CCC
	public override void updatePointer()
	{
		bool flag = this.vecCmd != null;
		if (flag)
		{
			for (int i = 0; i < this.vecCmd.size(); i++)
			{
				iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
				iCommand.updatePointer();
			}
		}
		base.updatePointer();
	}

	// Token: 0x06000F40 RID: 3904 RVA: 0x00126B28 File Offset: 0x00124D28
	private void IncreaseIndexShowKq()
	{
		this.indexShowKq++;
		bool flag = this.indexShowKq > 1;
		if (flag)
		{
			this.indexShowKq = 0;
		}
		mSound.playSound(51, mSound.volumeSound);
		this.index1 = CRes.random(6);
		this.index2 = CRes.random(6);
		this.index3 = CRes.random(6);
	}

	// Token: 0x06000F41 RID: 3905 RVA: 0x00126B8C File Offset: 0x00124D8C
	public override void UpdateStepQuaySo()
	{
		this.tickAction++;
		bool flag = this.StepQuaySo == 1;
		if (flag)
		{
			bool flag2 = this.tickAction >= 0;
			if (flag2)
			{
				bool flag3 = this.tickAction < 12;
				if (flag3)
				{
					bool flag4 = this.tickAction % 6 == 0;
					if (flag4)
					{
						this.IncreaseIndexShowKq();
					}
				}
				else
				{
					bool flag5 = this.tickAction < 20;
					if (flag5)
					{
						bool flag6 = this.tickAction % 4 == 0;
						if (flag6)
						{
							this.IncreaseIndexShowKq();
						}
					}
					else
					{
						bool flag7 = this.tickAction % 3 == 0;
						if (flag7)
						{
							this.IncreaseIndexShowKq();
						}
					}
				}
			}
			bool flag8 = this.tickAction >= 100;
			if (flag8)
			{
				this.StepQuaySo = 3;
				this.tickAction = 0;
			}
		}
		else
		{
			bool flag9 = this.StepQuaySo == 3;
			if (flag9)
			{
				bool flag10 = this.tickAction >= 0;
				if (flag10)
				{
					bool flag11 = this.tickAction < 20;
					if (flag11)
					{
						bool flag12 = this.tickAction % 4 == 0;
						if (flag12)
						{
							this.IncreaseIndexShowKq();
						}
					}
					else
					{
						bool flag13 = this.tickAction % 6 == 0;
						if (flag13)
						{
							this.IncreaseIndexShowKq();
						}
					}
				}
				bool flag14 = this.tickAction > 50 && this.indexShowKq == (int)this.kq;
				if (flag14)
				{
					this.StepQuaySo = 4;
					this.tickAction = 0;
				}
			}
			else
			{
				bool flag15 = this.StepQuaySo != 4;
				if (!flag15)
				{
					bool flag16 = this.tickAction == 200;
					if (flag16)
					{
						this.StepQuaySo = 0;
						this.tickAction = 0;
						this.indexShowKq = -1;
						GlobalService.gI().TaiXiu(0, 0);
					}
					bool flag17 = this.tickAction != 1;
					if (!flag17)
					{
						int num = 10;
						bool flag18 = this.cua != -1;
						if (flag18)
						{
							bool flag19 = this.kq == this.cua;
							if (flag19)
							{
								mSound.playSound(28, mSound.volumeSound);
								int subtype = 0;
								this.createEff(177, subtype, this.x + this.w / 2, this.y + this.h / 2 + num, this.x + this.w / 2, this.y + this.h / 2 + num);
								this.createEff(76, 0, this.x + this.w / 2, this.y + this.h / 2 + num, this.x + this.w / 2, this.y + this.h / 2 + num);
							}
							else
							{
								bool flag20 = this.kq != this.cua;
								if (flag20)
								{
									mSound.playSound(29, mSound.volumeSound);
									int subtype2 = 1;
									this.createEff(177, subtype2, this.x + this.w / 2, this.y + this.h / 2 + num, this.x + this.w / 2, this.y + this.h / 2 + num);
									this.createEff(77, 0, this.x + this.w / 2, this.y + this.h / 2 + num, this.x + this.w / 2, this.y + this.h / 2 + num);
								}
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x06000F42 RID: 3906 RVA: 0x00126F24 File Offset: 0x00125124
	public void SetXucXac(sbyte kq, sbyte x1, sbyte x2, sbyte x3, bool isEff)
	{
		this.kq = kq;
		this.x1 = x1;
		this.x2 = x2;
		this.x3 = x3;
		this.isEffKq = isEff;
		if (isEff)
		{
			this.StepQuaySo = 1;
			this.tickAction = 0;
		}
		this.index1 = (int)(x1 - 1);
		this.index2 = (int)(x2 - 1);
		this.index3 = (int)(x3 - 1);
	}

	// Token: 0x06000F43 RID: 3907 RVA: 0x0000C1C5 File Offset: 0x0000A3C5
	public void SetDatCuoc(int tongTai, int tongXiu, int daCuoc, sbyte cua)
	{
		this.tongTienTai = tongTai;
		this.tongTienXiu = tongXiu;
		this.daCuoc = daCuoc;
		this.cua = cua;
	}

	// Token: 0x06000F44 RID: 3908 RVA: 0x0000C1E5 File Offset: 0x0000A3E5
	public void SetUpdateTaiXiu(int tongTai, int tongXiu)
	{
		this.tongTienTai = tongTai;
		this.tongTienXiu = tongXiu;
	}

	// Token: 0x06000F45 RID: 3909 RVA: 0x0007D8AC File Offset: 0x0007BAAC
	public void createEff(short type, int subtype, int x, int y, int xto, int yto)
	{
		Effect_End o = new Effect_End(type, (sbyte)subtype, x, y, xto, yto, 0, null);
		this.vecEff.addElement(o);
	}

	// Token: 0x0400197F RID: 6527
	public string nameList = string.Empty;

	// Token: 0x04001980 RID: 6528
	public new static TaiXiuScreen instance;

	// Token: 0x04001981 RID: 6529
	private new int x;

	// Token: 0x04001982 RID: 6530
	private new int y;

	// Token: 0x04001983 RID: 6531
	private new int w;

	// Token: 0x04001984 RID: 6532
	private new int h;

	// Token: 0x04001985 RID: 6533
	private new iCommand cmdClose;

	// Token: 0x04001986 RID: 6534
	private iCommand cmdDatCuoc;

	// Token: 0x04001987 RID: 6535
	private iCommand cmdTatTay;

	// Token: 0x04001988 RID: 6536
	private iCommand cmdCuocTai;

	// Token: 0x04001989 RID: 6537
	private iCommand cmdCuocXiu;

	// Token: 0x0400198A RID: 6538
	private iCommand cmdDatCuocTai;

	// Token: 0x0400198B RID: 6539
	private iCommand cmdDatCuocXiu;

	// Token: 0x0400198C RID: 6540
	private iCommand cmdTTTai;

	// Token: 0x0400198D RID: 6541
	private iCommand cmdTTXiu;

	// Token: 0x0400198E RID: 6542
	private iCommand cmdTTT1m;

	// Token: 0x0400198F RID: 6543
	private iCommand cmdTTT2m;

	// Token: 0x04001990 RID: 6544
	private iCommand cmdTTT3m;

	// Token: 0x04001991 RID: 6545
	private iCommand cmdTTT4m;

	// Token: 0x04001992 RID: 6546
	private iCommand cmdTTT5m;

	// Token: 0x04001993 RID: 6547
	private iCommand cmdTTX1m;

	// Token: 0x04001994 RID: 6548
	private iCommand cmdTTX2m;

	// Token: 0x04001995 RID: 6549
	private iCommand cmdTTX3m;

	// Token: 0x04001996 RID: 6550
	private iCommand cmdTTX4m;

	// Token: 0x04001997 RID: 6551
	private iCommand cmdTTX5m;

	// Token: 0x04001998 RID: 6552
	private FrameImage fraTaiXiu;

	// Token: 0x04001999 RID: 6553
	private FrameImage fraXucXac;

	// Token: 0x0400199A RID: 6554
	private int tongTienTai = 1600000;

	// Token: 0x0400199B RID: 6555
	private int tongTienXiu = 160000;

	// Token: 0x0400199C RID: 6556
	private int daCuoc = 600000;

	// Token: 0x0400199D RID: 6557
	private short countDown = 60;

	// Token: 0x0400199E RID: 6558
	private sbyte cua = -1;

	// Token: 0x0400199F RID: 6559
	private sbyte kq = 1;

	// Token: 0x040019A0 RID: 6560
	private sbyte x1 = 1;

	// Token: 0x040019A1 RID: 6561
	private sbyte x2 = 2;

	// Token: 0x040019A2 RID: 6562
	private sbyte x3 = 3;

	// Token: 0x040019A3 RID: 6563
	private InputDialog input;

	// Token: 0x040019A4 RID: 6564
	private long timeBegin;

	// Token: 0x040019A5 RID: 6565
	private long timeUpdate;

	// Token: 0x040019A6 RID: 6566
	public bool isEffKq;

	// Token: 0x040019A7 RID: 6567
	private bool isSendSv;

	// Token: 0x040019A8 RID: 6568
	private int indexShowKq = -1;

	// Token: 0x040019A9 RID: 6569
	private int index1;

	// Token: 0x040019AA RID: 6570
	private int index2 = 1;

	// Token: 0x040019AB RID: 6571
	private int index3 = 2;
}
