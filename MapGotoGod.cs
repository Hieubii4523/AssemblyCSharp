using System;

// Token: 0x0200008D RID: 141
public class MapGotoGod
{
	// Token: 0x060008E9 RID: 2281 RVA: 0x000B9FA4 File Offset: 0x000B81A4
	public static void setPos()
	{
		MapGotoGod.vxHardCode = 6;
		MapGotoGod.xCamOffline = 0;
		MapGotoGod.right = 0;
		MapGotoGod.createAxe = 0;
		MapGotoGod.tickAxe = 15;
		MapGotoGod.finalMove = 0;
		MapGotoGod.finalAxe = 0;
		MapOff_RedLine.timeRedline = 0;
		MapOff_RedLine.timebegin = 0L;
		MapGotoGod.vecAxe.removeAllElements();
		GameCanvas.loadMapScr.mItemMap = null;
		MainScreen.cameraMain.xCam = 0;
		MainScreen.cameraMain.yCam = 0;
		GameScreen.player.x = MapGotoGod.xHardCode;
		GameScreen.player.y = MapGotoGod.yHardCode;
		GameScreen.player.Dir = 2;
		GameScreen.player.type_left_right = 2;
		GameScreen.player.boatSea = new Boat(GameScreen.player.ID, GameScreen.player.x, GameScreen.player.y, 0, (sbyte)GameScreen.player.type_left_right);
		GameScreen.player.boatSea.setPartImage(GameScreen.player.myBoat, GameScreen.player.typePirate);
		GameScreen.player.setSpeed(2, 2);
		GameScreen.player.isMoveNor = true;
		ObjectData.getImageOther((short)MapGotoGod.idTile, 20);
		bool flag = LoadMapScreen.isMapSky != 1;
		if (flag)
		{
			LoadMapScreen.isMapSky = 1;
			LoadImageStatic.loadImageEffBoat();
		}
		MapGotoGod.maxX = MotherCanvas.w / MapGotoGod.wTile + 1;
		MapGotoGod.maxY = MotherCanvas.h / MapGotoGod.wTile + 1;
		MapGotoGod.mapW = 45;
		MapGotoGod.mapH = 18;
		MapGotoGod.imgTile = null;
		MapGotoGod.imgTileWater = null;
		MapGotoGod.mLockMap = new sbyte[]
		{
			8,
			11,
			8,
			8,
			5,
			5,
			20,
			20,
			13,
			13,
			8,
			8,
			4,
			4,
			4,
			7,
			4,
			4,
			7,
			7,
			25,
			42,
			9,
			12,
			5,
			5,
			8,
			8,
			9,
			12
		};
		MapGotoGod.fWater = (int)MapGotoGod.mLockMap[MapGotoGod.idTile * 2];
		MapGotoGod.fStand = (int)MapGotoGod.mLockMap[MapGotoGod.idTile * 2 + 1];
		MapGotoGod.mapPaint = new int[]
		{
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			25,
			23,
			24,
			25,
			23,
			24,
			25,
			23,
			24,
			25,
			23,
			24,
			25,
			23,
			24,
			25,
			23,
			24,
			25,
			23,
			24,
			25,
			23,
			24,
			25,
			23,
			24,
			25,
			23,
			24,
			25,
			23,
			24,
			25,
			23,
			24,
			25,
			23,
			24,
			25,
			23,
			24,
			25,
			24,
			25,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			11,
			9,
			10,
			9,
			10,
			22,
			20,
			21,
			22,
			20,
			21,
			22,
			20,
			21,
			22,
			20,
			21,
			22,
			20,
			21,
			22,
			20,
			21,
			22,
			20,
			21,
			22,
			20,
			21,
			22,
			20,
			21,
			22,
			20,
			21,
			22,
			20,
			21,
			22,
			20,
			21,
			22,
			20,
			21,
			22,
			20,
			21,
			22,
			21,
			22,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19,
			19
		};
	}

	// Token: 0x060008EA RID: 2282 RVA: 0x0000AF43 File Offset: 0x00009143
	public static void setTypeMoveredLine(sbyte type)
	{
		GameScreen.player.typeMoveGotoSky = (int)type;
	}

	// Token: 0x060008EB RID: 2283 RVA: 0x000090B5 File Offset: 0x000072B5
	public static void SetPosNextMove()
	{
	}

	// Token: 0x060008EC RID: 2284 RVA: 0x000BA180 File Offset: 0x000B8380
	public static void update()
	{
		bool flag = GameCanvas.mapBack != null;
		if (flag)
		{
			GameCanvas.mapBack.update();
		}
		MapGotoGod.xCamOffline -= MapGotoGod.vxHardCode;
		MapGotoGod.updateActionPlayer();
		MapGotoGod.addAxe();
		MapGotoGod.updateAxe();
		bool flag2 = GameScreen.player.typeMoveGotoSky == 1;
		if (flag2)
		{
			MapGotoGod.updateKeyAudition();
		}
		GameScreen.player.updateMapGotoGod(MapGotoGod.finalMove);
		bool flag3 = Interface_Game.timePointer > 0;
		if (flag3)
		{
			Interface_Game.timePointer--;
		}
	}

	// Token: 0x060008ED RID: 2285 RVA: 0x000BA20C File Offset: 0x000B840C
	public static void updateActionPlayer()
	{
		bool flag = GameScreen.player.typeMoveGotoSky == 0;
		if (flag)
		{
			GameScreen.player.typeMoveGotoSky = 1;
		}
		else
		{
			bool flag2 = GameScreen.player.typeMoveGotoSky == 1;
			if (flag2)
			{
				bool flag3 = CRes.abs(GameScreen.player.x - GameScreen.player.toX) < 4 && CRes.abs(GameScreen.player.y - GameScreen.player.toY) < 4 && CRes.random(25) == 0 && MapGotoGod.createAxe == 0;
				if (flag3)
				{
					bool flag4 = MapGotoGod.right == 0;
					if (flag4)
					{
						MapGotoGod.right = 1;
						GameScreen.player.toX = MapGotoGod.xHardCode + MapGotoGod.range;
						MapGotoGod.createAxe = 1;
					}
					else
					{
						MapGotoGod.right = 0;
						GameScreen.player.toX = MapGotoGod.xHardCode - MapGotoGod.range;
						MapGotoGod.createAxe = 1;
					}
				}
			}
			else
			{
				bool flag5 = GameScreen.player.typeMoveGotoSky == 2;
				if (flag5)
				{
					bool flag6 = MapGotoGod.finalAxe == 0;
					if (flag6)
					{
						GameScreen.player.toX = MapGotoGod.xHardCode;
						MapGotoGod.createAxe = 1;
						MapGotoGod.tickAxe = 15;
						MapGotoGod.finalAxe = 1;
					}
				}
				else
				{
					bool flag7 = GameScreen.player.typeMoveGotoSky != 3;
					if (flag7)
					{
					}
				}
			}
		}
	}

	// Token: 0x060008EE RID: 2286 RVA: 0x000BA360 File Offset: 0x000B8560
	private static void addAxe()
	{
		bool flag = MapGotoGod.createAxe == 0;
		if (!flag)
		{
			bool flag2 = MapGotoGod.tickAxe > 0;
			if (flag2)
			{
				MapGotoGod.tickAxe--;
			}
			else
			{
				MapGotoGod.createAxe = 0;
				MapGotoGod.tickAxe = 15;
				Point point = new Point();
				point.dis = 0;
				bool flag3 = GameScreen.player.typeMoveGotoSky == 2;
				if (flag3)
				{
					point.x2 = -MotherCanvas.w / 2;
					point.subType = 1;
				}
				else
				{
					bool flag4 = MapGotoGod.right == 0;
					if (flag4)
					{
						point.x2 = -MotherCanvas.w / 2 + MapGotoGod.range * 2;
					}
					else
					{
						point.x2 = -MotherCanvas.w / 2 - MapGotoGod.range * 2;
					}
				}
				MapGotoGod.vecAxe.addElement(point);
			}
		}
	}

	// Token: 0x060008EF RID: 2287 RVA: 0x000BA430 File Offset: 0x000B8630
	private static void updateAxe()
	{
		for (int i = 0; i < MapGotoGod.vecAxe.size(); i++)
		{
			Point point = (Point)MapGotoGod.vecAxe.elementAt(i);
			bool flag = point.subType == 1;
			if (flag)
			{
				bool flag2 = point.y + point.y2 + MapGotoGod.imgAxe.h < MapGotoGod.yHardCode;
				if (flag2)
				{
					point.dis += 6;
				}
				else
				{
					bool flag3 = MapGotoGod.finalMove == 0;
					if (flag3)
					{
						MapGotoGod.finalMove = 1;
						MapGotoGod.vxHardCode = 0;
						GameScreen.player.vx = -4;
						GameScreen.player.vy = -4;
					}
				}
			}
			else
			{
				point.dis += 6;
			}
			Point pointOnCircle = MapGotoGod.getPointOnCircle(MotherCanvas.w, MotherCanvas.h, point.dis, MotherCanvas.w / 2);
			point.x = pointOnCircle.x;
			point.y = pointOnCircle.y;
			bool flag4 = point.dis >= 225;
			if (flag4)
			{
				MapGotoGod.vecAxe.removeElement(point);
				i--;
			}
		}
	}

	// Token: 0x060008F0 RID: 2288 RVA: 0x000BA55C File Offset: 0x000B875C
	private static Point getPointOnCircle(int width, int height, int degress, int radius)
	{
		int num = width / 2;
		int num2 = height / 2;
		int a = degress - 90;
		int x = num + CRes.getcos(a) * radius / 1000;
		int y = num2 + CRes.getsin(a) * radius / 1000;
		return new Point(x, y);
	}

	// Token: 0x060008F1 RID: 2289 RVA: 0x000BA5A8 File Offset: 0x000B87A8
	private static void updateKeyAudition()
	{
		bool flag = GameCanvas.keyMove(1);
		if (flag)
		{
			GlobalService.gI().Red_Line(3, 1);
			GameCanvas.ClearkeyMove(1);
			Player.indexAudition++;
		}
		else
		{
			bool flag2 = GameCanvas.keyMove(2);
			if (flag2)
			{
				GlobalService.gI().Red_Line(3, 2);
				GameCanvas.ClearkeyMove(2);
				Player.indexAudition++;
			}
			else
			{
				bool flag3 = GameCanvas.keyMove(3);
				if (flag3)
				{
					GlobalService.gI().Red_Line(3, 3);
					GameCanvas.ClearkeyMove(3);
					Player.indexAudition++;
				}
				else
				{
					bool flag4 = GameCanvas.keyMove(0);
					if (flag4)
					{
						GlobalService.gI().Red_Line(3, 0);
						GameCanvas.ClearkeyMove(0);
						Player.indexAudition++;
					}
				}
			}
		}
	}

	// Token: 0x060008F2 RID: 2290 RVA: 0x000BA670 File Offset: 0x000B8870
	public static void paint(mGraphics g)
	{
		bool flag = MapGotoGod.imgAxe == null;
		if (flag)
		{
			MapGotoGod.imgAxe = mImage.createImage("/bg/axe.png");
			MapGotoGod.imgAxe.setWH();
		}
		bool flag2 = GameCanvas.mapBack != null;
		if (flag2)
		{
			GameCanvas.mapBack.paint(g);
		}
		int num = MainScreen.cameraMain.xCam / MapGotoGod.wTile - 1;
		int num2 = MainScreen.cameraMain.yCam / MapGotoGod.wTile - 1;
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
		int num3 = num + MapGotoGod.maxX + 2;
		int num4 = num2 + MapGotoGod.maxY + 2;
		bool flag5 = num3 > MapGotoGod.mapW;
		if (flag5)
		{
			num3 = MapGotoGod.mapW;
		}
		bool flag6 = num4 > MapGotoGod.mapH;
		if (flag6)
		{
			num4 = MapGotoGod.mapH;
		}
		bool flag7 = (MapGotoGod.imgTileWater == null || MapGotoGod.imgTileWater.img == null) && !GameCanvas.lowGraphic;
		if (flag7)
		{
			MapGotoGod.imgTileWater = ObjectData.getImageOther((short)MapGotoGod.idTile, 70);
		}
		bool flag8 = MapGotoGod.imgTile == null || MapGotoGod.imgTile.img == null;
		if (flag8)
		{
			MapGotoGod.imgTile = ObjectData.getImageOther((short)MapGotoGod.idTile, 20);
			g.setColor(15445332);
			g.fillRect(MainScreen.cameraMain.xCam, MainScreen.cameraMain.yCam, MotherCanvas.w, MotherCanvas.h);
		}
		else
		{
			for (int i = num; i < num3; i++)
			{
				for (int j = num2; j < num4; j++)
				{
					int num5 = j * MapGotoGod.mapW + i;
					bool flag9 = num5 >= MapGotoGod.mapPaint.Length;
					if (!flag9)
					{
						int num6 = MapGotoGod.mapPaint[num5] - 1;
						int k;
						for (k = i * MapGotoGod.wTile + MapGotoGod.xCamOffline; k <= -MapGotoGod.wTile; k += num3 * MapGotoGod.wTile)
						{
						}
						bool flag10 = !GameCanvas.lowGraphic && num6 >= MapGotoGod.fWater - 1 && num6 < MapGotoGod.fStand - 1 && GameCanvas.gameTick % 14 < 7;
						if (flag10)
						{
							int num7 = 0;
							bool flag11 = GameCanvas.gameTick / 14 % 2 == 0;
							if (flag11)
							{
								num7 = MapGotoGod.fStand - MapGotoGod.fWater;
							}
							bool flag12 = MapGotoGod.imgTileWater != null && MapGotoGod.imgTileWater.img != null;
							if (flag12)
							{
								g.drawRegion(MapGotoGod.imgTileWater.img, (num7 + num6 - (MapGotoGod.fWater - 1)) / 10 * MapGotoGod.wTile, (num7 + num6 - (MapGotoGod.fWater - 1)) % 10 * MapGotoGod.wTile, MapGotoGod.wTile, MapGotoGod.wTile, 0, (float)k, (float)(j * MapGotoGod.wTile), 0);
							}
						}
						else
						{
							bool flag13 = num6 > -1 && MapGotoGod.imgTile != null && MapGotoGod.imgTile.img != null;
							if (flag13)
							{
								g.drawRegion(MapGotoGod.imgTile.img, num6 / 10 * MapGotoGod.wTile, num6 % 10 * MapGotoGod.wTile, MapGotoGod.wTile, MapGotoGod.wTile, 0, (float)k, (float)(j * MapGotoGod.wTile), 0);
							}
						}
					}
				}
			}
			for (int l = 0; l < MapGotoGod.vecAxe.size(); l++)
			{
				Point point = (Point)MapGotoGod.vecAxe.elementAt(l);
				bool flag14 = point.y < GameScreen.player.y;
				if (flag14)
				{
					MapGotoGod.paintAxe(g, point);
				}
			}
			GameScreen.player.paintGotoSky(g);
			for (int m = 0; m < MapGotoGod.vecAxe.size(); m++)
			{
				Point point2 = (Point)MapGotoGod.vecAxe.elementAt(m);
				bool flag15 = point2.y >= GameScreen.player.y;
				if (flag15)
				{
					MapGotoGod.paintAxe(g, point2);
				}
			}
			GameCanvas.resetTrans(g);
			bool flag16 = ReadMessenge.mImgCapredLine != null;
			if (flag16)
			{
				g.setColor(0);
				g.drawRect(MotherCanvas.hw - 40 - 1, MapGotoGod.yPaintAudition - 20 - 1, 81, 8);
				int num8 = (int)((long)MapOff_RedLine.timeRedline - (GameCanvas.timeNow - MapOff_RedLine.timebegin));
				bool flag17 = num8 <= 0 && GameScreen.player.typeMoveGotoSky == 1;
				if (flag17)
				{
					num8 = 0;
				}
				Interface_Game.PaintHPMP(g, 1, num8, MapOff_RedLine.timeRedline, MotherCanvas.hw - 40, MapGotoGod.yPaintAudition - 20, 0, 7, 80, 4, false, 0, false, 0);
				MapGotoGod.paintAudition(g);
			}
			bool flag18 = !GameCanvas.isTouch;
			if (!flag18)
			{
				g.drawImage(Interface_Game.imgMove[0], Interface_Game.xPointMove, Interface_Game.yPointMove, 3);
				for (int n = 0; n < 4; n++)
				{
					bool flag19 = Interface_Game.timePointer > 0 && GameScreen.interfaceGame.mKeyMove[n] == Interface_Game.keyPoint;
					if (flag19)
					{
						GameScreen.interfaceGame.paintMoveTouch(g, n);
					}
				}
			}
		}
	}

	// Token: 0x060008F3 RID: 2291 RVA: 0x000BAB94 File Offset: 0x000B8D94
	public static void paintAxe(mGraphics g, Point p)
	{
		int num = p.x + p.x2;
		int num2 = p.y + p.y2 + MapGotoGod.imgAxe.h / 2;
		for (int i = -1; i < 2; i++)
		{
			g.drawLine(MotherCanvas.w / 4 + p.x2 + i, -MotherCanvas.h / 2 + i, num + i, num2 - MapGotoGod.imgAxe.h / 2 + i);
		}
		g.drawImage(MapGotoGod.imgAxe, num, num2, 33);
	}

	// Token: 0x060008F4 RID: 2292 RVA: 0x000BAC24 File Offset: 0x000B8E24
	public static void paintAudition(mGraphics g)
	{
		int num = MotherCanvas.hw - ReadMessenge.mImgCapredLine.Length / 2 * Interface_Game.wComboSkill;
		int num2 = ReadMessenge.mImgCapredLine.Length;
		for (int i = 0; i < num2; i++)
		{
			int num3 = i;
			int x = Interface_Game.wComboSkill;
			bool flag = num3 == 0;
			if (flag)
			{
				x = 0;
			}
			else
			{
				bool flag2 = num3 == num2 - 1;
				if (flag2)
				{
					x = Interface_Game.wComboSkill * 2;
				}
			}
			g.drawRegion(AvMain.imgCombo, x, 0, Interface_Game.wComboSkill, Interface_Game.wComboSkill, 0, (float)(num + i * Interface_Game.wComboSkill - Interface_Game.wComboSkill / 2), (float)(MapGotoGod.yPaintAudition - Interface_Game.wComboSkill / 2), 0);
			g.drawImage(ReadMessenge.mImgCapredLine[i], num + i * Interface_Game.wComboSkill, MapGotoGod.yPaintAudition, 3);
			bool flag3 = num3 <= Player.indexAudition;
			if (flag3)
			{
				g.drawRegion(AvMain.imgDelay, 0, 0, Interface_Game.wComboSkill, Interface_Game.wComboSkill, 0, (float)(num + i * Interface_Game.wComboSkill - Interface_Game.wComboSkill / 2), (float)(MapGotoGod.yPaintAudition - Interface_Game.wComboSkill / 2), 0);
			}
		}
	}

	// Token: 0x04000E4E RID: 3662
	public static mVector vecAxe = new mVector("MapGotoGod.Axe");

	// Token: 0x04000E4F RID: 3663
	public static int wTile = 24;

	// Token: 0x04000E50 RID: 3664
	public static int idTile = 14;

	// Token: 0x04000E51 RID: 3665
	public static mImage imgAxe;

	// Token: 0x04000E52 RID: 3666
	public static int mapW;

	// Token: 0x04000E53 RID: 3667
	public static int mapH;

	// Token: 0x04000E54 RID: 3668
	public static int maxX;

	// Token: 0x04000E55 RID: 3669
	public static int maxY;

	// Token: 0x04000E56 RID: 3670
	public static MainImage imgTile;

	// Token: 0x04000E57 RID: 3671
	public static MainImage imgTileWater;

	// Token: 0x04000E58 RID: 3672
	public static int[] mapPaint;

	// Token: 0x04000E59 RID: 3673
	public static sbyte[] mLockMap;

	// Token: 0x04000E5A RID: 3674
	public static int yHardCode = MotherCanvas.h / 6 * 4;

	// Token: 0x04000E5B RID: 3675
	public static int xHardCode = MotherCanvas.w / 2;

	// Token: 0x04000E5C RID: 3676
	public static int vxHardCode = 6;

	// Token: 0x04000E5D RID: 3677
	public static int range = MotherCanvas.w / 6;

	// Token: 0x04000E5E RID: 3678
	public static int yPaintAudition = MotherCanvas.h - 20;

	// Token: 0x04000E5F RID: 3679
	private static int fStand;

	// Token: 0x04000E60 RID: 3680
	private static int fWater;

	// Token: 0x04000E61 RID: 3681
	private static int xCamOffline;

	// Token: 0x04000E62 RID: 3682
	private static sbyte right;

	// Token: 0x04000E63 RID: 3683
	private static sbyte createAxe;

	// Token: 0x04000E64 RID: 3684
	private static int tickAxe;

	// Token: 0x04000E65 RID: 3685
	private static sbyte finalMove;

	// Token: 0x04000E66 RID: 3686
	private static sbyte finalAxe;
}
