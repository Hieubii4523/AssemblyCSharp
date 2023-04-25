using System;

// Token: 0x0200000C RID: 12
public class Boat : MainItemMap
{
	// Token: 0x06000062 RID: 98 RVA: 0x00012D60 File Offset: 0x00010F60
	public Boat(short ID, int x, int y, int dy, sbyte Dir)
	{
		this.wOne = 100;
		this.hOne = 70;
		this.ysai = -50;
		this.vySea = 3;
		this.ID = ID;
		this.y = y;
		this.ySort = y + this.ysai;
		this.dy = dy;
		this.Dir = (int)((Dir == 2) ? 2 : 0);
		this.x = x + ((Dir != 2) ? (-this.wlech) : this.wlech);
		bool flag = y < GameCanvas.loadmap.maxHMap - 100;
		if (flag)
		{
			this.levelPaintBoat = -1;
		}
		this.TypeItem = 1;
		this.setIconClan();
	}

	// Token: 0x06000063 RID: 99 RVA: 0x00012E6C File Offset: 0x0001106C
	public void setIconClan()
	{
		MainObject mainObject = MainObject.get_Object((int)this.ID, 0);
		bool flag = mainObject != null && mainObject.clan != null && GameCanvas.currentScreen != GameCanvas.listCharScr;
		if (flag)
		{
			this.idIconClan = mainObject.clan.idIcon;
		}
	}

	// Token: 0x06000064 RID: 100 RVA: 0x0000920C File Offset: 0x0000740C
	public void setPartImage(short[] mp, sbyte pirate)
	{
		this.mPartImage = mp;
		this.pirate = pirate;
	}

	// Token: 0x06000065 RID: 101 RVA: 0x00012EBC File Offset: 0x000110BC
	public override void paint(mGraphics g)
	{
		bool flag = this.isPaint;
		if (flag)
		{
			this.paintFrist(g);
			this.paintBuom(g);
			this.paintLastInMap(g);
		}
	}

	// Token: 0x06000066 RID: 102 RVA: 0x00012EF0 File Offset: 0x000110F0
	public override void update()
	{
		this.updateBoat();
		this.updateDySea();
		bool flag = this.tickDonotMove <= 0;
		if (flag)
		{
			this.resetY();
		}
		this.ySort = this.y + this.ysai;
	}

	// Token: 0x06000067 RID: 103 RVA: 0x00012F38 File Offset: 0x00011138
	public void updateXY(int x, int y, int dy, sbyte Dir)
	{
		this.y = y;
		this.dy = dy;
		this.Dir = (int)((Dir == 2) ? 2 : 0);
		this.x = x + ((Dir != 2) ? (-this.wlech) : this.wlech);
		this.boatSetVaCham(0, 0);
		this.tickDonotMove = 40;
	}

	// Token: 0x06000068 RID: 104 RVA: 0x00012F94 File Offset: 0x00011194
	public void paintFrist(mGraphics g)
	{
		for (int i = 0; i < this.vecEff.size(); i++)
		{
			Point point = (Point)this.vecEff.elementAt(i);
			bool flag = point.levelPaint != -1;
			if (!flag)
			{
				bool flag2 = point.frame == 2;
				if (flag2)
				{
					Boat.fraEffSea2.drawFrame(point.f / point.fSmall % Boat.fraEffSea2.nFrame, point.x, point.y, point.dis, 3, g);
				}
				else
				{
					bool flag3 = point.frame == -1;
					if (flag3)
					{
						FrameImage frameImage = Boat.fraEffSea;
						bool isBeginEffBoat = MapGotoSky.isBeginEffBoat;
						if (isBeginEffBoat)
						{
							frameImage = Boat.fraEffSea4;
						}
						frameImage.drawFrame(point.f / point.fSmall % frameImage.nFrame, this.x + ((this.Dir != 2) ? -37 : 37), this.y + this.dy / 2 + Boat.hlech - 3, this.Dir, 3, g);
					}
					else
					{
						FrameImage frameImage2 = Boat.fraEffSea;
						bool isBeginEffBoat2 = MapGotoSky.isBeginEffBoat;
						if (isBeginEffBoat2)
						{
							frameImage2 = Boat.fraEffSea4;
						}
						frameImage2.drawFrame(point.f / point.fSmall % frameImage2.nFrame, point.x, point.y, point.dis, 3, g);
					}
				}
			}
		}
		bool flag4 = this.mPartImage != null;
		if (flag4)
		{
			ItemBoat.paintPartBoat(g, this.mPartImage[0], 0, this.x, this.y, this.dy, this.Dir);
		}
	}

	// Token: 0x06000069 RID: 105 RVA: 0x0000921D File Offset: 0x0000741D
	public void paintBuom(mGraphics g)
	{
		this.paintBuom(g, this.idIconClan);
	}

	// Token: 0x0600006A RID: 106 RVA: 0x00013140 File Offset: 0x00011340
	public void paintBuom(mGraphics g, short iconClan)
	{
		bool flag = this.mPartImage == null;
		if (!flag)
		{
			ItemBoat.paintPartBoat(g, this.mPartImage[1], 1, this.x, this.y, this.dy, this.Dir);
			ItemBoat.paintPartBoat(g, this.mPartImage[2], 2, this.x, this.y, this.dy, this.Dir);
			bool flag2 = iconClan >= 0;
			if (flag2)
			{
				MainImage iconClanBig = Potion.getIconClanBig(iconClan);
				bool flag3 = iconClanBig != null && iconClanBig.img != null;
				if (flag3)
				{
					int num = GameCanvas.gameTick / 6 % 2;
					int num2 = -(16 - num);
					bool flag4 = this.Dir == 2;
					if (flag4)
					{
						num2 = 16 - num;
					}
					bool flag5 = iconClanBig.frame == -1;
					if (flag5)
					{
						iconClanBig.set_Frame();
					}
					bool flag6 = iconClanBig.frame <= 1;
					if (flag6)
					{
						g.drawImage(iconClanBig.img, this.x + num2, this.y - 30 - this.dy, 3);
					}
					else
					{
						int num3 = (this.framepaint < (int)(iconClanBig.frame - 1)) ? 3 : 15;
						bool flag7 = CRes.abs(GameCanvas.gameTick - this.lastTick) > num3;
						if (flag7)
						{
							this.framepaint++;
							bool flag8 = this.framepaint >= (int)iconClanBig.frame;
							if (flag8)
							{
								this.framepaint = 0;
							}
							this.lastTick = GameCanvas.gameTick;
						}
						g.drawRegion(iconClanBig.img, 0, this.framepaint * (int)iconClanBig.w, (int)iconClanBig.w, (int)iconClanBig.w, 0, (float)(this.x + num2), (float)(this.y - 30 - this.dy), 3);
					}
				}
			}
			int num4 = (int)this.pirate;
			bool flag9 = this.pirate == -1;
			if (flag9)
			{
				num4 = 3;
			}
			ItemBoat.paintPartBoat(g, 0, 100 + num4, this.x, this.y, this.dy, this.Dir);
		}
	}

	// Token: 0x0600006B RID: 107 RVA: 0x00013358 File Offset: 0x00011558
	public void paintHang(mGraphics g)
	{
		int num = (this.Dir != 2) ? 0 : 0;
		g.drawRegion(Boat.imgShip, 0, 0, 59, 39, this.Dir, (float)(this.x + num), (float)(this.y + Boat.hlech - 6 - this.dy), 33);
	}

	// Token: 0x0600006C RID: 108 RVA: 0x000133B0 File Offset: 0x000115B0
	public void paintLastInMap(mGraphics g)
	{
		sbyte day_night = GameCanvas.DAY;
		bool flag = GameCanvas.mapBack != null && GameCanvas.mapBack.isNight;
		if (flag)
		{
			day_night = GameCanvas.NIGHT;
		}
		this.paintLast(g, day_night);
	}

	// Token: 0x0600006D RID: 109 RVA: 0x000133F0 File Offset: 0x000115F0
	public void paintLast(mGraphics g, sbyte day_night)
	{
		bool flag = this.mPartImage != null;
		if (flag)
		{
			ItemBoat.paintPartBoat(g, this.mPartImage[3], 3, this.x, this.y, this.dy, this.Dir);
		}
		bool flag2 = !GameCanvas.lowGraphic;
		if (flag2)
		{
			this.paintEff(g, day_night);
		}
		bool flag3 = day_night == GameCanvas.NIGHT;
		if (!flag3)
		{
			for (int i = 0; i < this.vecEff.size(); i++)
			{
				Point point = (Point)this.vecEff.elementAt(i);
				bool flag4 = point.levelPaint <= -1;
				if (!flag4)
				{
					bool flag5 = point.frame == 2;
					if (flag5)
					{
						Boat.fraEffSea2.drawFrame(point.f / point.fSmall % Boat.fraEffSea2.nFrame, point.x, point.y, point.dis, 3, g);
					}
					else
					{
						bool flag6 = point.frame == -1;
						if (flag6)
						{
							FrameImage frameImage = Boat.fraEffSea;
							bool isBeginEffBoat = MapGotoSky.isBeginEffBoat;
							if (isBeginEffBoat)
							{
								frameImage = Boat.fraEffSea4;
							}
							frameImage.drawFrame(point.f / point.fSmall % frameImage.nFrame, this.x + ((this.Dir != 2) ? -37 : 37), this.y + this.dy / 2 + Boat.hlech - 3, this.Dir, 3, g);
						}
						else
						{
							FrameImage frameImage2 = Boat.fraEffSea;
							bool isBeginEffBoat2 = MapGotoSky.isBeginEffBoat;
							if (isBeginEffBoat2)
							{
								frameImage2 = Boat.fraEffSea4;
							}
							frameImage2.drawFrame(point.f / point.fSmall % frameImage2.nFrame, point.x, point.y, point.dis, 3, g);
						}
					}
				}
			}
		}
	}

	// Token: 0x0600006E RID: 110 RVA: 0x000135D8 File Offset: 0x000117D8
	public void paintEff(mGraphics g, sbyte day_night)
	{
		bool flag = day_night == GameCanvas.DAY;
		if (flag)
		{
			bool isBeginEffBoat = MapGotoSky.isBeginEffBoat;
			if (isBeginEffBoat)
			{
				bool flag2 = GameScreen.player.typeMoveGotoSky != 2;
				if (flag2)
				{
					g.drawRegion(Boat.imgEffSea3, 0, 12 * (GameCanvas.gameTick / 12 % 2), 78, 12, this.Dir, (float)this.x, (float)(this.y + Boat.hlech + 2), 3);
				}
			}
			else
			{
				g.drawRegion(Boat.imgEffSea, 0, 12 * (GameCanvas.gameTick / 12 % 2), 78, 12, this.Dir, (float)this.x, (float)(this.y + Boat.hlech + 2), 3);
			}
		}
		else
		{
			g.drawRegion(Boat.imgEffSea2, 0, 12 * (GameCanvas.gameTick / 12 % 2), 78, 12, this.Dir, (float)this.x, (float)(this.y + Boat.hlech + 2), 3);
		}
	}

	// Token: 0x0600006F RID: 111 RVA: 0x000136D4 File Offset: 0x000118D4
	public void updateBoat()
	{
		for (int i = 0; i < this.vecEff.size(); i++)
		{
			Point point = (Point)this.vecEff.elementAt(i);
			point.x += point.vx;
			point.f++;
			bool flag = point.f >= point.fRe;
			if (flag)
			{
				this.vecEff.removeElement(point);
			}
		}
		bool flag2 = this.tickDonotMove > 0;
		if (flag2)
		{
			this.tickDonotMove--;
		}
	}

	// Token: 0x06000070 RID: 112 RVA: 0x00013774 File Offset: 0x00011974
	public override void updateDySea()
	{
		bool flag = CRes.random(40) == 0;
		if (flag)
		{
			bool flag2 = CRes.random(2) == 0;
			if (flag2)
			{
				this.vySea = 3;
			}
			else
			{
				this.vySea = -3;
			}
		}
		bool flag3 = this.dySea > 0 && this.vySea > 0;
		if (flag3)
		{
			this.vySea = -3;
		}
		else
		{
			bool flag4 = this.dySea < -30 && this.vySea < 0;
			if (flag4)
			{
				this.vySea = 3;
			}
		}
		this.dySea += this.vySea;
		this.dy = this.dySea / 10;
	}

	// Token: 0x06000071 RID: 113 RVA: 0x00013820 File Offset: 0x00011A20
	public void addEffSea(int x, int y, int type, sbyte dis, int vx)
	{
		this.isSetLevelPaint = true;
		bool flag = !GameCanvas.lowGraphic;
		if (flag)
		{
			Point point = new Point();
			point.frame = type;
			switch (type)
			{
			case -1:
				point.x = this.x;
				point.y = this.y;
				point.vx = vx;
				point.fSmall = 3;
				break;
			case 0:
			{
				int num = CRes.random(20, 48);
				point.x = x + ((this.Dir != 2) ? (-num) : num);
				point.y = y + Boat.hlech - 3 + this.dy / 2;
				point.vx = vx;
				point.fSmall = 2;
				break;
			}
			case 1:
			{
				int num2 = CRes.random_Am_0(30);
				point.x = x + ((this.Dir != 2) ? (-this.wlech) : this.wlech) + num2;
				point.y = y + Boat.hlech - 3 + this.dy / 2;
				point.vx = vx;
				point.fSmall = 3;
				break;
			}
			case 2:
				point.x = x + ((this.Dir != 2) ? (-this.wlech) : this.wlech);
				point.y = y + Boat.hlech - 4 + this.dy / 2;
				point.vx = vx;
				point.fSmall = 3;
				point.levelPaint = -1;
				break;
			}
			point.dis = (int)dis;
			point.fRe = 7 * point.fSmall;
			this.vecEff.addElement(point);
		}
	}

	// Token: 0x06000072 RID: 114 RVA: 0x000139BC File Offset: 0x00011BBC
	public void setLevelPaint()
	{
		bool flag = this.isSetLevelPaint;
		if (flag)
		{
			for (int i = 0; i < this.vecEff.size(); i++)
			{
				Point point = (Point)this.vecEff.elementAt(i);
				point.levelPaint = -1;
			}
		}
		this.isSetLevelPaint = false;
	}

	// Token: 0x06000073 RID: 115 RVA: 0x00013A14 File Offset: 0x00011C14
	public void boatSetVaCham(int vx, int vy)
	{
		this.xset = this.x - ((this.Dir != 2) ? (-this.wlech + 10) : (this.wlech - 10)) - 30 + vx;
		this.wset = 60;
		this.yset = this.y + vy;
		this.hset = 8;
	}

	// Token: 0x06000074 RID: 116 RVA: 0x00013A70 File Offset: 0x00011C70
	public void boatSetTouch()
	{
		this.xset = this.x - ((this.Dir != 2) ? (-this.wlech + 15) : (this.wlech - 15)) - 14;
		this.wset = 90;
		this.yset = this.y - 6;
		this.hset = 12;
	}

	// Token: 0x06000075 RID: 117 RVA: 0x0000922E File Offset: 0x0000742E
	public void resetY()
	{
		this.y = ReadMessenge.yBoatMap;
	}

	// Token: 0x06000076 RID: 118 RVA: 0x00013ACC File Offset: 0x00011CCC
	public override bool isInScreen()
	{
		bool flag = this.x + this.dx + this.wOne / 2 < MainScreen.cameraMain.xCam || this.x + this.dx - this.wOne / 2 > MainScreen.cameraMain.xCam + MotherCanvas.w || this.y + this.dy + 10 < MainScreen.cameraMain.yCam || this.y + this.dy + 10 - this.hOne > MainScreen.cameraMain.yCam + MotherCanvas.h;
		return !flag;
	}

	// Token: 0x040000E2 RID: 226
	public const sbyte EFF_SONG_DAU_THUYEN_MOVE = -1;

	// Token: 0x040000E3 RID: 227
	public const sbyte EFF_SONG_MANG_THUYEN_MOVE = 0;

	// Token: 0x040000E4 RID: 228
	public const sbyte EFF_SONG_MANG_THUYEN_STAND = 1;

	// Token: 0x040000E5 RID: 229
	public const sbyte EFF_VET_NUOC_MANG_THUYEN_STAND = 2;

	// Token: 0x040000E6 RID: 230
	public short idIconClan = -1;

	// Token: 0x040000E7 RID: 231
	public bool isSetLevelPaint = true;

	// Token: 0x040000E8 RID: 232
	public bool isPaint = true;

	// Token: 0x040000E9 RID: 233
	public bool loadDataOk;

	// Token: 0x040000EA RID: 234
	public int wlech = 12;

	// Token: 0x040000EB RID: 235
	public int numNextFrame = 3;

	// Token: 0x040000EC RID: 236
	public static int hlech = 12;

	// Token: 0x040000ED RID: 237
	public sbyte levelPaintBoat;

	// Token: 0x040000EE RID: 238
	public sbyte pirate = 2;

	// Token: 0x040000EF RID: 239
	public static mImage imgShip;

	// Token: 0x040000F0 RID: 240
	public static mImage imgEffSea;

	// Token: 0x040000F1 RID: 241
	public static mImage imgEffSea2;

	// Token: 0x040000F2 RID: 242
	public static mImage imgEffSea3;

	// Token: 0x040000F3 RID: 243
	public static int[][] sizeImgBoat;

	// Token: 0x040000F4 RID: 244
	public static FrameImage fraEffSea;

	// Token: 0x040000F5 RID: 245
	public static FrameImage fraEffSea2;

	// Token: 0x040000F6 RID: 246
	public static FrameImage fraEffSea3;

	// Token: 0x040000F7 RID: 247
	public static FrameImage fraPirateUnity;

	// Token: 0x040000F8 RID: 248
	public static FrameImage fraEffSea4;

	// Token: 0x040000F9 RID: 249
	public mVector vecEff = new mVector("Boat.vecEff");

	// Token: 0x040000FA RID: 250
	public int xset;

	// Token: 0x040000FB RID: 251
	public int yset;

	// Token: 0x040000FC RID: 252
	public int wset;

	// Token: 0x040000FD RID: 253
	public int hset;

	// Token: 0x040000FE RID: 254
	public short[] mPartImage = new short[]
	{
		0,
		1,
		2,
		3
	};

	// Token: 0x040000FF RID: 255
	public int tickDonotMove = 40;

	// Token: 0x04000100 RID: 256
	private int lastTick;

	// Token: 0x04000101 RID: 257
	private int framepaint;
}
