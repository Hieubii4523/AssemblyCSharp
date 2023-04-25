using System;

// Token: 0x0200002B RID: 43
public class Effect_Map
{
	// Token: 0x060001F4 RID: 500 RVA: 0x0003195C File Offset: 0x0002FB5C
	public Effect_Map(sbyte type, sbyte level)
	{
		bool flag = type == 4;
		if (flag)
		{
			bool flag2 = LoadMapScreen.isMapSky == 1;
			if (flag2)
			{
				this.fraImg = new FrameImage(mImage.createImage("/bg/sea1fly.png"), 24, 24);
				this.fraImgSub = new FrameImage(mImage.createImage("/bg/sea2fly.png"), 24, 24);
			}
			else
			{
				this.fraImg = new FrameImage(mImage.createImage("/bg/sea1.png"), 24, 24);
				this.fraImgSub = new FrameImage(mImage.createImage("/bg/sea2.png"), 24, 24);
			}
			this.numNextFrame = 3;
		}
		else
		{
			this.type = type;
			this.vecEff.removeAllElements();
			int num = 8000;
			this.hRain = 5;
			bool flag3 = level >= 3;
			if (flag3)
			{
				this.hRain = 6;
			}
			if (type <= 3)
			{
				if (type != 1)
				{
					if (type != 3)
					{
						goto IL_122;
					}
					num = 2000;
					goto IL_122;
				}
			}
			else if (type != 6)
			{
				if (type != 8)
				{
					goto IL_122;
				}
				num = 1500;
				goto IL_122;
			}
			num = 3000;
			IL_122:
			int num2 = MotherCanvas.w * MotherCanvas.h / num;
			bool flag4 = level == 0;
			if (flag4)
			{
				num2 /= 4;
			}
			bool flag5 = level == 1;
			if (flag5)
			{
				num2 /= 2;
			}
			bool flag6 = level == 3;
			if (flag6)
			{
				num2 = num2 * 3 / 2;
			}
			bool flag7 = level == 4;
			if (flag7)
			{
				num2 *= 2;
			}
			bool flag8 = num2 <= 0;
			if (flag8)
			{
				num2 = 1;
			}
			this.randomSpeed();
			switch (type)
			{
			case 0:
				this.Plus = 30;
				this.fraImg = new FrameImage(mImage.createImage("/bg/leaf.png"), 11, 11);
				for (int i = 0; i < num2; i++)
				{
					Point point = new Point
					{
						x = MainScreen.cameraMain.xCam + this.Plus + CRes.random(MotherCanvas.w),
						y = MainScreen.cameraMain.yCam - this.Plus + CRes.random(MotherCanvas.h),
						vx = this.swingXSpeed,
						vy = this.YSpped
					};
					this.setCreate(point);
					this.vecEff.addElement(point);
				}
				break;
			case 1:
				this.Plus = 30;
				this.fraImg = new FrameImage(mImage.createImage("/bg/snow.png"), 7, 7);
				for (int j = 0; j < num2; j++)
				{
					Point point2 = new Point
					{
						x = MainScreen.cameraMain.xCam + this.Plus + CRes.random(MotherCanvas.w),
						y = MainScreen.cameraMain.yCam - this.Plus + CRes.random(MotherCanvas.h),
						vx = this.swingXSpeed,
						maxframe = this.fraImg.nFrame
					};
					this.setCreate(point2);
					this.vecEff.addElement(point2);
				}
				break;
			case 2:
			case 5:
			case 6:
			case 7:
			{
				this.Plus = 30;
				bool flag9 = type == 2;
				if (flag9)
				{
					this.fraImg = new FrameImage(mImage.createImage("/bg/flower.png"), 9, 10);
				}
				else
				{
					bool flag10 = type == 5;
					if (flag10)
					{
						this.fraImg = new FrameImage(mImage.createImage("/bg/flowermai.png"), 9, 10);
					}
					else
					{
						bool flag11 = type == 7;
						if (flag11)
						{
							this.fraImg = new FrameImage(mImage.createImage("/bg/flowerdao.png"), 9, 10);
						}
						else
						{
							this.fraImg = new FrameImage(mImage.createImage("/bg/flowerphao.png"), 7, 7);
						}
					}
				}
				for (int k = 0; k < num2; k++)
				{
					Point point3 = new Point
					{
						x = MainScreen.cameraMain.xCam + this.Plus + CRes.random(MotherCanvas.w),
						y = MainScreen.cameraMain.yCam - this.Plus + CRes.random(MotherCanvas.h),
						vx = this.swingXSpeed,
						vy = this.YSpped,
						maxframe = this.fraImg.nFrame
					};
					this.setCreate(point3);
					this.vecEff.addElement(point3);
				}
				break;
			}
			case 3:
			case 8:
				this.Plus = 10;
				this.fraImg = new FrameImage(mImage.createImage("/bg/rain.png"), 12, 7);
				for (int l = 0; l < num2; l++)
				{
					Point point4 = new Point
					{
						x = MainScreen.cameraMain.xCam + this.Plus + CRes.random(MotherCanvas.w),
						y = MainScreen.cameraMain.yCam - this.Plus + CRes.random(MotherCanvas.h),
						vx = this.swingXSpeed
					};
					this.setCreate(point4);
					this.vecEff.addElement(point4);
				}
				break;
			}
		}
	}

	// Token: 0x060001F5 RID: 501 RVA: 0x00031EA0 File Offset: 0x000300A0
	public void paintLast(mGraphics g)
	{
		switch (this.type)
		{
		case 0:
			for (int i = 0; i < this.vecEff.size(); i++)
			{
				Point point = (Point)this.vecEff.elementAt(i);
				this.fraImg.drawFrame((int)Effect_Map.frameLeaf[point.dis][(point.f + point.frame) % point.maxframe], point.x, point.y, 0, 3, g);
			}
			break;
		case 1:
		case 2:
		case 5:
		case 6:
		case 7:
			for (int j = 0; j < this.vecEff.size(); j++)
			{
				Point point2 = (Point)this.vecEff.elementAt(j);
				this.fraImg.drawFrame(point2.frame, point2.x, point2.y, 0, 3, g);
			}
			break;
		case 3:
		case 8:
			g.setColor(16777215);
			for (int k = 0; k < this.vecEff.size(); k++)
			{
				Point point3 = (Point)this.vecEff.elementAt(k);
				g.drawLine(point3.x, point3.y, point3.x - 1, point3.y + point3.h);
			}
			for (int l = 0; l < this.vecEffSub.size(); l++)
			{
				Point point4 = (Point)this.vecEffSub.elementAt(l);
				bool flag = !point4.isRemove;
				if (flag)
				{
					this.fraImg.drawFrame(point4.dis + point4.f / 3 % this.fraImg.nFrame, point4.x, point4.y, 0, 3, g);
				}
			}
			break;
		}
	}

	// Token: 0x060001F6 RID: 502 RVA: 0x000320B0 File Offset: 0x000302B0
	public void createSea(int x, int y)
	{
		Point point = new Point(x, y);
		point.frame = CRes.random(2);
		int num = CRes.random(20);
		point.dis = ((num >= 19) ? 2 : 0);
		point.fRe = 7 * this.numNextFrame;
		this.vecEff.addElement(point);
	}

	// Token: 0x060001F7 RID: 503 RVA: 0x00032104 File Offset: 0x00030304
	public void paintSea(mGraphics g)
	{
		for (int i = 0; i < this.vecEff.size(); i++)
		{
			Point point = (Point)this.vecEff.elementAt(i);
			bool flag = point.frame == 0;
			if (flag)
			{
				this.fraImg.drawFrame(point.f / this.numNextFrame % this.fraImg.nFrame, point.x, point.y, point.dis, 0, g);
			}
			else
			{
				this.fraImgSub.drawFrame(point.f / this.numNextFrame % this.fraImgSub.nFrame, point.x, point.y, point.dis, 0, g);
			}
		}
	}

	// Token: 0x060001F8 RID: 504 RVA: 0x000321CC File Offset: 0x000303CC
	public void updateSea()
	{
		for (int i = 0; i < this.vecEff.size(); i++)
		{
			Point point = (Point)this.vecEff.elementAt(i);
			point.f++;
			bool flag = point.f >= point.fRe;
			if (flag)
			{
				this.vecEff.removeElement(point);
				i--;
			}
		}
		bool flag2 = GameCanvas.gameTick % 5 != 0;
		if (!flag2)
		{
			int num = MainScreen.cameraMain.xCam / LoadMap.wTile - 1;
			int num2 = MainScreen.cameraMain.yCam / LoadMap.wTile - 1;
			bool flag3 = num < 0;
			if (flag3)
			{
				num = 0;
			}
			bool flag4 = num2 < 0;
			if (flag4)
			{
				num2 = 0;
			}
			int num3 = num + GameCanvas.loadmap.maxX + 2;
			int num4 = num2 + GameCanvas.loadmap.maxY + 2;
			bool flag5 = num3 > GameCanvas.loadmap.mapW;
			if (flag5)
			{
				num3 = GameCanvas.loadmap.mapW;
			}
			bool flag6 = num4 > GameCanvas.loadmap.mapH;
			if (flag6)
			{
				num4 = GameCanvas.loadmap.mapH;
			}
			for (int j = num; j < num3; j++)
			{
				for (int k = num2; k < num4; k++)
				{
					int num5 = GameCanvas.loadmap.mapType[k * GameCanvas.loadmap.mapW + j];
					bool flag7 = num5 == 2 && CRes.random(20) == 0;
					if (flag7)
					{
						this.createSea(j * LoadMap.wTile, k * LoadMap.wTile);
					}
				}
			}
		}
	}

	// Token: 0x060001F9 RID: 505 RVA: 0x00032384 File Offset: 0x00030584
	public void randomSpeed()
	{
		this.time = 0;
		this.timeSpeed = CRes.random(30, 100);
		switch (this.type)
		{
		case 0:
		case 2:
		case 5:
		case 6:
		case 7:
			this.YSpped = 1;
			this.swingXSpeed = -CRes.random(2, 5);
			break;
		case 1:
			this.swingXSpeed = -CRes.random(3, 6);
			break;
		case 3:
			this.swingXSpeed = -CRes.random(2, 4);
			break;
		case 8:
			this.swingXSpeed = -CRes.random(3, 5);
			break;
		}
	}

	// Token: 0x060001FA RID: 506 RVA: 0x00032428 File Offset: 0x00030628
	public void update()
	{
		this.time++;
		bool flag = false;
		bool flag2 = this.time > this.timeSpeed;
		if (flag2)
		{
			this.randomSpeed();
			flag = true;
		}
		this.setPos();
		switch (this.type)
		{
		case 0:
			for (int i = 0; i < this.vecEff.size(); i++)
			{
				Point point = (Point)this.vecEff.elementAt(i);
				bool flag3 = flag;
				if (flag3)
				{
					point.vx = this.swingXSpeed;
					point.vy = this.YSpped;
				}
				point.update();
				bool flag4 = point.dis == 0 && CRes.random(80) == 0;
				if (flag4)
				{
					point.dis = 1;
					point.maxframe = Effect_Map.frameLeaf[point.dis].Length;
				}
				else
				{
					bool flag5 = point.dis == 1 && point.f == 7 && CRes.random(3) == 0;
					if (flag5)
					{
						point.dis = 0;
						point.maxframe = Effect_Map.frameLeaf[point.dis].Length;
					}
				}
			}
			break;
		case 1:
			for (int j = 0; j < this.vecEff.size(); j++)
			{
				Point point2 = (Point)this.vecEff.elementAt(j);
				bool flag6 = flag;
				if (flag6)
				{
					point2.vx = this.swingXSpeed;
					bool flag7 = point2.vy == 1 && CRes.random(30) == 0;
					if (flag7)
					{
						point2.vy = 0;
					}
					else
					{
						bool flag8 = CRes.random(10) == 0 && point2.vy != 1;
						if (flag8)
						{
							point2.vy = 1;
						}
					}
				}
				point2.update();
			}
			break;
		case 2:
		case 5:
		case 6:
		case 7:
			for (int k = 0; k < this.vecEff.size(); k++)
			{
				Point point3 = (Point)this.vecEff.elementAt(k);
				bool flag9 = flag;
				if (flag9)
				{
					point3.vx = this.swingXSpeed;
					point3.vy = this.YSpped;
				}
				bool flag10 = CRes.random(5) == 0;
				if (flag10)
				{
					point3.frame = CRes.random(point3.maxframe);
				}
				point3.update();
			}
			break;
		case 3:
		case 8:
			for (int l = 0; l < this.vecEff.size(); l++)
			{
				Point point4 = (Point)this.vecEff.elementAt(l);
				bool flag11 = flag;
				if (flag11)
				{
					point4.vx = this.swingXSpeed;
				}
				point4.update();
				bool flag12 = CRes.random(40) != 0;
				if (!flag12)
				{
					int num = 200;
					int num2 = 1;
					bool flag13 = GameCanvas.mapBack != null;
					if (flag13)
					{
						num = GameCanvas.mapBack.hBack;
						bool flag14 = GameCanvas.loadmap.maxHMap > num;
						if (flag14)
						{
							num2 = CRes.random(GameCanvas.loadmap.maxHMap - num);
						}
					}
					Point point5 = new Point();
					point5.x = MainScreen.cameraMain.xCam + CRes.random(MotherCanvas.w);
					point5.y = num + num2;
					point5.frame = 1;
					point5.dis = ((CRes.random(4) != 0) ? 1 : 0) * 2;
					this.vecEffSub.addElement(point5);
					point4 = this.resetPos(point4);
				}
			}
			for (int m = 0; m < this.vecEffSub.size(); m++)
			{
				Point point6 = (Point)this.vecEffSub.elementAt(m);
				point6.f++;
				bool flag15 = point6.f >= 6;
				if (flag15)
				{
					bool isRemove = point6.isRemove;
					if (isRemove)
					{
						this.vecEffSub.removeElement(point6);
						m--;
					}
					else
					{
						point6.isRemove = true;
					}
				}
			}
			break;
		}
	}

	// Token: 0x060001FB RID: 507 RVA: 0x00032888 File Offset: 0x00030A88
	public void setPos()
	{
		switch (this.type)
		{
		case 0:
		case 1:
		case 2:
		case 5:
		case 6:
		case 7:
			for (int i = 0; i < this.vecEff.size(); i++)
			{
				Point point = (Point)this.vecEff.elementAt(i);
				bool flag = point.x < MainScreen.cameraMain.xCam - this.Plus || point.y > MainScreen.cameraMain.yCam + MotherCanvas.h + this.Plus;
				if (flag)
				{
					point = this.resetPos(point);
				}
				bool flag2 = point.x > MainScreen.cameraMain.xCam + MotherCanvas.w + this.Plus * 2;
				if (flag2)
				{
					point.x -= MotherCanvas.w + this.Plus;
				}
			}
			break;
		case 3:
		case 8:
			for (int j = 0; j < this.vecEff.size(); j++)
			{
				Point point2 = (Point)this.vecEff.elementAt(j);
				bool flag3 = point2.frame == 0;
				if (flag3)
				{
					bool flag4 = point2.x < MainScreen.cameraMain.xCam - this.Plus || point2.y > MainScreen.cameraMain.yCam + MotherCanvas.h + this.Plus;
					if (flag4)
					{
						point2 = this.resetPos(point2);
					}
					bool flag5 = point2.x > MainScreen.cameraMain.xCam + MotherCanvas.w + this.Plus * 2;
					if (flag5)
					{
						point2.x -= MotherCanvas.w + this.Plus;
					}
				}
			}
			break;
		}
	}

	// Token: 0x060001FC RID: 508 RVA: 0x00032A80 File Offset: 0x00030C80
	public Point resetPos(Point p)
	{
		switch (this.type)
		{
		case 0:
		case 1:
		case 2:
		case 5:
		case 6:
		case 7:
		{
			bool flag = CRes.random(3) != 0;
			if (flag)
			{
				p.x = MainScreen.cameraMain.xCam + MotherCanvas.w + CRes.random(this.Plus);
				p.y = MainScreen.cameraMain.yCam - this.Plus + CRes.random(MotherCanvas.h);
			}
			else
			{
				p.x = MainScreen.cameraMain.xCam + this.Plus + CRes.random(MotherCanvas.w);
				p.y = MainScreen.cameraMain.yCam - CRes.random(this.Plus);
			}
			this.setCreate(p);
			break;
		}
		case 3:
		case 8:
		{
			bool flag2 = CRes.random(3) == 0;
			if (flag2)
			{
				p.x = MainScreen.cameraMain.xCam + MotherCanvas.w + CRes.random(this.Plus);
				p.y = MainScreen.cameraMain.yCam - this.Plus + CRes.random(MotherCanvas.h);
			}
			else
			{
				p.x = MainScreen.cameraMain.xCam + this.Plus + CRes.random(MotherCanvas.w);
				p.y = MainScreen.cameraMain.yCam - CRes.random(this.Plus);
			}
			this.setCreate(p);
			break;
		}
		}
		return p;
	}

	// Token: 0x060001FD RID: 509 RVA: 0x00032C10 File Offset: 0x00030E10
	public Point setCreate(Point p)
	{
		switch (this.type)
		{
		case 0:
			p.levelPaint = CRes.random(10);
			p.dis = ((CRes.random(15) == 1) ? 1 : 0);
			p.maxframe = Effect_Map.frameLeaf[p.dis].Length;
			p.frame = CRes.random(p.maxframe);
			break;
		case 1:
			p.levelPaint = CRes.random(10);
			p.frame = CRes.random(p.maxframe);
			p.vy = ((CRes.random(10) > 0) ? 1 : 0);
			break;
		case 2:
		case 5:
		case 6:
		case 7:
			p.levelPaint = CRes.random(10);
			p.frame = CRes.random(p.maxframe);
			break;
		case 3:
		case 8:
			p.levelPaint = CRes.random(10);
			p.h = CRes.random(1, (int)this.hRain);
			p.vy = (int)this.hRain;
			p.frame = 0;
			break;
		}
		return p;
	}

	// Token: 0x040003AC RID: 940
	public const sbyte GREEN_LEAF = 0;

	// Token: 0x040003AD RID: 941
	public const sbyte SNOW = 1;

	// Token: 0x040003AE RID: 942
	public const sbyte FLOWER = 2;

	// Token: 0x040003AF RID: 943
	public const sbyte RAIN = 3;

	// Token: 0x040003B0 RID: 944
	public const sbyte SEA = 4;

	// Token: 0x040003B1 RID: 945
	public const sbyte MAI = 5;

	// Token: 0x040003B2 RID: 946
	public const sbyte PHAO = 6;

	// Token: 0x040003B3 RID: 947
	public const sbyte DAO = 7;

	// Token: 0x040003B4 RID: 948
	public const sbyte RAIN_THUNDER = 8;

	// Token: 0x040003B5 RID: 949
	public const sbyte DARK = 9;

	// Token: 0x040003B6 RID: 950
	private mVector vecEff = new mVector();

	// Token: 0x040003B7 RID: 951
	private mVector vecEffSub = new mVector();

	// Token: 0x040003B8 RID: 952
	public sbyte type;

	// Token: 0x040003B9 RID: 953
	public sbyte level;

	// Token: 0x040003BA RID: 954
	public sbyte hRain;

	// Token: 0x040003BB RID: 955
	private int swingXSpeed;

	// Token: 0x040003BC RID: 956
	private int YSpped;

	// Token: 0x040003BD RID: 957
	private int timeSpeed;

	// Token: 0x040003BE RID: 958
	private int time;

	// Token: 0x040003BF RID: 959
	private int numNextFrame;

	// Token: 0x040003C0 RID: 960
	public static sbyte[][] frameLeaf = new sbyte[][]
	{
		new sbyte[]
		{
			0,
			0,
			0,
			0,
			0,
			1,
			1,
			1,
			1,
			1,
			2,
			2,
			2,
			2,
			2,
			1,
			1,
			1,
			1,
			1
		},
		new sbyte[]
		{
			0,
			0,
			1,
			1,
			2,
			2,
			3,
			3,
			4,
			4,
			5,
			5,
			6,
			6,
			7,
			7
		}
	};

	// Token: 0x040003C1 RID: 961
	private FrameImage fraImg;

	// Token: 0x040003C2 RID: 962
	private FrameImage fraImgSub;

	// Token: 0x040003C3 RID: 963
	private int Plus;
}
