using System;

// Token: 0x0200008E RID: 142
public class MapGotoSky
{
	// Token: 0x060008F7 RID: 2295 RVA: 0x000BADA4 File Offset: 0x000B8FA4
	public static void setPos()
	{
		MapGotoSky.hMax = 700;
		MapGotoSky.wMax = 480;
		MapGotoSky.x = 140;
		MapGotoSky.y = MapGotoSky.hMax - 120;
		MapGotoSky.w = 170;
		MapGotoSky.h = 504;
		MapGotoSky.LoadImage();
		MapGotoSky.vecEff_Song_Ria.removeAllElements();
		for (int i = 0; i <= MapGotoSky.h / 24; i++)
		{
			Point point = new Point(MapGotoSky.x + 1, MapGotoSky.y - 24 - i * 24);
			point.dis = 2;
			point.f = CRes.random(MapGotoSky.fraEffSky0.nFrame * 2);
			point.vy = -8;
			MapGotoSky.vecEff_Song_Ria.addElement(point);
			Point point2 = new Point(MapGotoSky.x - 1 + MapGotoSky.w, MapGotoSky.y - 24 - i * 24);
			point2.dis = 0;
			point2.f = CRes.random(MapGotoSky.fraEffSky0.nFrame * 2);
			point2.vy = -8;
			MapGotoSky.vecEff_Song_Ria.addElement(point2);
		}
		MapGotoSky.vecEff_Song_Giua.removeAllElements();
		for (int j = 0; j < MotherCanvas.h / 60; j++)
		{
			Point point3 = new Point(MapGotoSky.x + 12, MapGotoSky.y - 15);
			bool flag = j > 0;
			if (flag)
			{
				point3.y -= 80 * j + CRes.random(40);
			}
			point3.frame = 0;
			point3.vy = -8;
			MapGotoSky.vecEff_Song_Giua.addElement(point3);
		}
		MapGotoSky.vecEff_Song_Nho.removeAllElements();
		for (int k = 0; k < MotherCanvas.h / 60; k++)
		{
			Point point4 = new Point(MapGotoSky.x - 24 + CRes.random(MapGotoSky.w + 48), MapGotoSky.y - 15 - CRes.random(MapGotoSky.h));
			point4.frame = 0;
			point4.vy = -CRes.random(7, 12);
			MapGotoSky.vecEff_Song_Nho.addElement(point4);
		}
		MapGotoSky.vecEff_Song_Keo.removeAllElements();
		for (int l = 0; l < 12; l++)
		{
			Point point5 = new Point(MapGotoSky.x - 24 + CRes.random(MapGotoSky.w + 48), MapGotoSky.y + 40);
			bool flag2 = point5.x - MapGotoSky.x < (MapGotoSky.w + 36) / 3;
			if (flag2)
			{
				point5.frame = 1;
				point5.dis = 0;
				point5.vx = 2;
			}
			else
			{
				bool flag3 = point5.x - MapGotoSky.x > (MapGotoSky.w + 36) / 3 * 2;
				if (flag3)
				{
					point5.frame = 1;
					point5.dis = 2;
					point5.vx = CRes.random_Am_0(2);
				}
				else
				{
					point5.frame = 0;
					point5.dis = 0;
					point5.vx = -2;
				}
			}
			point5.vy = -7;
			MapGotoSky.vecEff_Song_Keo.addElement(point5);
		}
		MapGotoSky.vecEff_Song_Bien.removeAllElements();
		for (int m = 0; m < MapGotoSky.w / LoadMap.wTile + 5; m++)
		{
			Point point6 = new Point((MapGotoSky.x / 24 - 2) * 24 + m * 24, MapGotoSky.y / 24 * 24);
			point6.frame = CRes.random((MapGotoSky.fraEffSky5.nFrame + 1) * 2);
			point6.dis = ((CRes.random(5) != 0) ? 2 : 0);
			MapGotoSky.vecEff_Song_Bien.addElement(point6);
			Point point7 = new Point((MapGotoSky.x / 24 - 2) * 24 + m * 24, (MapGotoSky.y / 24 + 1) * 24);
			point7.frame = CRes.random((MapGotoSky.fraEffSky5.nFrame + 1) * 2);
			point7.dis = ((CRes.random(5) != 0) ? 2 : 0);
			MapGotoSky.vecEff_Song_Bien.addElement(point7);
			bool flag4 = m != 0 && m != MapGotoSky.w / LoadMap.wTile + 4;
			if (flag4)
			{
				Point point8 = new Point((MapGotoSky.x / 24 - 2) * 24 + m * 24, (MapGotoSky.y / 24 + 2) * 24);
				point8.frame = CRes.random((MapGotoSky.fraEffSky5.nFrame + 1) * 2);
				point8.dis = ((CRes.random(5) != 0) ? 2 : 0);
				MapGotoSky.vecEff_Song_Bien.addElement(point8);
				bool flag5 = m <= 2 || m >= MapGotoSky.w / LoadMap.wTile;
				if (flag5)
				{
					Point point9 = new Point((MapGotoSky.x / 24 - 2) * 24 + m * 24, (MapGotoSky.y / 24 - 1) * 24);
					point9.frame = CRes.random((MapGotoSky.fraEffSky5.nFrame + 1) * 2);
					point9.dis = ((CRes.random(5) != 0) ? 2 : 0);
					MapGotoSky.vecEff_Song_Bien.addElement(point9);
				}
			}
		}
		MapGotoSky.vecEff_Song_Bien_Nho.removeAllElements();
		for (int n = 0; n <= MapGotoSky.wMax / LoadMap.wTile; n++)
		{
			for (int num = 0; num <= 160 / LoadMap.wTile; num++)
			{
				Point point10 = new Point(n * LoadMap.wTile, MapGotoSky.hMax - 160 + num * LoadMap.wTile);
				point10.frame = CRes.random(14);
				point10.fSmall = CRes.random(6);
				point10.dis = CRes.random(5);
				point10.vx = 0;
				point10.vy = 0;
				MapGotoSky.vecEff_Song_Bien_Nho.addElement(point10);
			}
		}
		MapGotoSky.vecEff_May.removeAllElements();
		MapGotoSky.vecEff_Die.removeAllElements();
		MapGotoSky.mGo = mSystem.new_M_Int(MapGotoSky.mPosGotoSky.Length, 2);
		for (int num2 = 0; num2 < MapGotoSky.mPosGotoSky.Length; num2++)
		{
			MapGotoSky.mGo[num2] = new int[2];
			MapGotoSky.mGo[num2][0] = MapGotoSky.mPosGotoSky[num2][0];
			MapGotoSky.mGo[num2][1] = MapGotoSky.hMax - 30 - MapGotoSky.mPosGotoSky[num2][1];
		}
		for (int num3 = 0; num3 <= 10; num3++)
		{
			Point point11 = new Point(num3 * 45, MapGotoSky.hMax - 30 - 550 - 20);
			point11.frame = 0;
			MapGotoSky.vecEff_May_Goto.addElement(point11);
		}
		for (int num4 = 0; num4 <= 5; num4++)
		{
			Point point12 = new Point(num4 * 86, MapGotoSky.hMax - 30 - 550 - 6 - 25);
			point12.frame = 1;
			MapGotoSky.vecEff_May_Goto.addElement(point12);
		}
		for (int num5 = 0; num5 <= 6; num5++)
		{
			Point point13 = new Point(num5 * 70, MapGotoSky.hMax - 30 - 550 - 20 - 20);
			point13.frame = 2;
			MapGotoSky.vecEff_May_Goto.addElement(point13);
		}
		GameCanvas.loadMapScr.mItemMap = null;
		MapGotoSky.stepMove = 0;
		GameScreen.player.setSpeed(2, 2);
		GameScreen.player.x = 50;
		GameScreen.player.y = MapGotoSky.hMax - 30;
		GameScreen.player.Dir = 2;
		GameScreen.player.type_left_right = 2;
		GameScreen.player.boatSea = new Boat(GameScreen.player.ID, GameScreen.player.x, GameScreen.player.y, 0, (sbyte)GameScreen.player.type_left_right);
		GameScreen.player.boatSea.setPartImage(GameScreen.player.myBoat, GameScreen.player.typePirate);
		GameScreen.player.toX = MapGotoSky.mGo[MapGotoSky.stepMove][0];
		GameScreen.player.toY = MapGotoSky.mGo[MapGotoSky.stepMove][1];
		GameScreen.player.isMoveNor = true;
		MainScreen.cameraMain.xCam = 0;
		MainScreen.cameraMain.yCam = 0;
		MainScreen.cameraMain.setAll(MapGotoSky.wMax - MotherCanvas.w, MapGotoSky.hMax - MotherCanvas.h, GameScreen.player.x - MotherCanvas.hw, GameScreen.player.y - MotherCanvas.hh);
		MapGotoSky.isBeginEffBoat = false;
		MapGotoSky.isStopUpdateCamera = false;
		MapGotoSky.tickGo = 0;
		MapGotoSky.valueGo = 0;
		MapOff_RedLine.timeRedline = 0;
		MapOff_RedLine.timebegin = 0L;
	}

	// Token: 0x060008F8 RID: 2296 RVA: 0x000BB660 File Offset: 0x000B9860
	public static void LoadImage()
	{
		MapGotoSky.fraEffSky0 = new FrameImage(mImage.createImage("/bg/eff_sky0.png"), 24, 24);
		MapGotoSky.fraEffSky1 = new FrameImage(mImage.createImage("/bg/eff_sky1.png"), 24, 24);
		MapGotoSky.fraEffSky2 = new FrameImage(mImage.createImage("/bg/eff_sky2.png"), 36, 32);
		MapGotoSky.fraEffSky3 = new FrameImage(mImage.createImage("/bg/eff_sky3.png"), 24, 24);
		MapGotoSky.fraEffSky4 = new FrameImage(mImage.createImage("/bg/eff_sky4.png"), 24, 24);
		MapGotoSky.fraEffSky5 = new FrameImage(mImage.createImage("/bg/sea1.png"), 24, 24);
		MapGotoSky.fraEffSky6 = new FrameImage(mImage.createImage("/bg/sea2.png"), 24, 24);
		MapGotoSky.fraEffSky7 = new FrameImage(mImage.createImage("/bg/redline6.png"), 48, 48);
		for (int i = 0; i < MapGotoSky.mcloud.Length; i++)
		{
			MapGotoSky.mcloud[i] = mImage.createImage("/bg/cloud" + i.ToString() + ".png");
		}
		for (int j = 0; j < MapGotoSky.mcloudGoto.Length; j++)
		{
			MapGotoSky.mcloudGoto[j] = mImage.createImage("/bg/goto" + j.ToString() + ".png");
		}
	}

	// Token: 0x060008F9 RID: 2297 RVA: 0x0000AF51 File Offset: 0x00009151
	public static void paint(mGraphics g)
	{
		MapGotoSky.paintEff(g);
	}

	// Token: 0x060008FA RID: 2298 RVA: 0x000BB7A4 File Offset: 0x000B99A4
	public static void paintEff(mGraphics g)
	{
		g.setColor(4367095);
		g.fillRect(0, MapGotoSky.hMax - 200, MapGotoSky.wMax, 200);
		bool flag = GameCanvas.mapBack != null;
		if (flag)
		{
			GameCanvas.mapBack.paint(g);
		}
		for (int i = 0; i < MapGotoSky.vecEff_Song_Bien_Nho.size(); i++)
		{
			Point point = (Point)MapGotoSky.vecEff_Song_Bien_Nho.elementAt(i);
			bool flag2 = point.frame / 2 < 7;
			if (flag2)
			{
				bool flag3 = point.fSmall == 0;
				if (flag3)
				{
					MapGotoSky.fraEffSky5.drawFrame(point.frame / 2, point.x, point.y, (point.dis == 0) ? 2 : 0, 0, g);
				}
				else
				{
					MapGotoSky.fraEffSky6.drawFrame((3 + point.frame / 2) % MapGotoSky.fraEffSky6.nFrame, point.x, point.y, (point.dis == 0) ? 2 : 0, 0, g);
				}
			}
		}
		for (int j = 0; j < MapGotoSky.vecEff_Song_Bien.size(); j++)
		{
			Point point2 = (Point)MapGotoSky.vecEff_Song_Bien.elementAt(j);
			bool flag4 = point2.frame / 2 < MapGotoSky.fraEffSky5.nFrame;
			if (flag4)
			{
				MapGotoSky.fraEffSky5.drawFrame(point2.frame / 2, point2.x, point2.y, point2.dis, 0, g);
			}
		}
		for (int k = 0; k < MapGotoSky.vecEff_May.size(); k++)
		{
			Point point3 = (Point)MapGotoSky.vecEff_May.elementAt(k);
			bool flag5 = point3.dis != 0;
			if (flag5)
			{
				g.drawImage(MapGotoSky.mcloud[point3.frame], point3.x, point3.y, 3);
			}
		}
		bool flag6 = GameScreen.player.typeMoveGotoSky == 3;
		if (flag6)
		{
			g.setColor(14284799);
			g.fillRect(MainScreen.cameraMain.xCam, MapGotoSky.hMax - 30 - 550 - 60, MotherCanvas.w, 40);
			for (int l = 0; l < MapGotoSky.vecEff_May_Goto.size(); l++)
			{
				Point point4 = (Point)MapGotoSky.vecEff_May_Goto.elementAt(l);
				bool flag7 = point4.frame == 0 && (point4.x + 25 > MainScreen.cameraMain.xCam || point4.x - 25 < MainScreen.cameraMain.xCam + MotherCanvas.w);
				if (flag7)
				{
					g.drawImage(MapGotoSky.mcloudGoto[0], point4.x, point4.y, 0);
				}
			}
		}
		g.setColor(5555965);
		g.fillRect(MapGotoSky.x + 3, MapGotoSky.y - MapGotoSky.h, MapGotoSky.w - 6, MapGotoSky.h - 24);
		for (int m = 0; m < 7; m++)
		{
			MapGotoSky.fraEffSky3.drawFrame(MapGotoSky.mPlayFrameBottom[m] + GameCanvas.gameTick / 2 % 2, MapGotoSky.x + 1 + m * 24, MapGotoSky.y - 24, 0, 0, g);
		}
		for (int n = 0; n < MapGotoSky.vecEff_Song_Ria.size(); n++)
		{
			Point point5 = (Point)MapGotoSky.vecEff_Song_Ria.elementAt(n);
			MapGotoSky.fraEffSky0.drawFrame(point5.f / 2 % MapGotoSky.fraEffSky0.nFrame, point5.x, point5.y, point5.dis, 3, g);
		}
		for (int num = 0; num < MapGotoSky.vecEff_Song_Giua.size(); num++)
		{
			Point point6 = (Point)MapGotoSky.vecEff_Song_Giua.elementAt(num);
			for (int num2 = 0; num2 < 7; num2++)
			{
				MapGotoSky.fraEffSky1.drawFrame(MapGotoSky.mPlayFrameSong[num2], point6.x + num2 * 24, point6.y, 0, 3, g);
			}
		}
		for (int num3 = 0; num3 < MapGotoSky.vecEff_Song_Nho.size(); num3++)
		{
			Point point7 = (Point)MapGotoSky.vecEff_Song_Nho.elementAt(num3);
			MapGotoSky.fraEffSky2.drawFrame(point7.f / 2 % MapGotoSky.fraEffSky2.nFrame, point7.x, point7.y, 0, 3, g);
		}
		for (int num4 = 0; num4 < MapGotoSky.vecEff_Song_Keo.size(); num4++)
		{
			Point point8 = (Point)MapGotoSky.vecEff_Song_Keo.elementAt(num4);
			MapGotoSky.fraEffSky4.drawFrame(point8.frame * 4 + point8.fSmall, point8.x, point8.y, point8.dis, 3, g);
		}
		GameScreen.player.paintGotoSky(g);
		for (int num5 = 0; num5 < MapGotoSky.vecEff_Die.size(); num5++)
		{
			Point point9 = (Point)MapGotoSky.vecEff_Die.elementAt(num5);
			MapGotoSky.fraEffSky4.drawFrame(point9.frame * 4 + point9.fSmall, point9.x, point9.y, point9.dis, 3, g);
		}
		for (int num6 = 0; num6 < MapGotoSky.vecEff_May.size(); num6++)
		{
			Point point10 = (Point)MapGotoSky.vecEff_May.elementAt(num6);
			bool flag8 = point10.dis == 0;
			if (flag8)
			{
				g.drawImage(MapGotoSky.mcloud[point10.frame], point10.x, point10.y, 3);
			}
		}
		bool flag9 = GameScreen.player.typeMoveGotoSky == 3;
		if (flag9)
		{
			for (int num7 = 0; num7 < MapGotoSky.vecEff_May_Goto.size(); num7++)
			{
				Point point11 = (Point)MapGotoSky.vecEff_May_Goto.elementAt(num7);
				bool flag10 = point11.frame != 0 && (point11.x + 45 > MainScreen.cameraMain.xCam || point11.x - 45 < MainScreen.cameraMain.xCam + MotherCanvas.w);
				if (flag10)
				{
					g.drawImage(MapGotoSky.mcloudGoto[point11.frame], point11.x, point11.y, 0);
				}
			}
		}
		GameCanvas.resetTrans(g);
		bool flag11 = ReadMessenge.mImgCapredLine != null;
		if (flag11)
		{
			g.setColor(0);
			g.drawRect(MotherCanvas.hw - 40 - 1, MapOff_RedLine.yPaintAudition - 20 - 1, 81, 8);
			int num8 = (int)((long)MapOff_RedLine.timeRedline - (GameCanvas.timeNow - MapOff_RedLine.timebegin));
			bool flag12 = num8 <= 0 && GameScreen.player.typeMoveGotoSky == 1;
			if (flag12)
			{
				num8 = 0;
			}
			Interface_Game.PaintHPMP(g, 1, num8, MapOff_RedLine.timeRedline, MotherCanvas.hw - 40, MapOff_RedLine.yPaintAudition - 20, 0, 7, 80, 4, false, 0, false, 0);
			MapGotoSky.paintAudition(g);
		}
		bool flag13 = !GameCanvas.isTouch;
		if (!flag13)
		{
			g.drawImage(Interface_Game.imgMove[0], Interface_Game.xPointMove, Interface_Game.yPointMove, 3);
			for (int num9 = 0; num9 < 4; num9++)
			{
				bool flag14 = Interface_Game.timePointer > 0 && GameScreen.interfaceGame.mKeyMove[num9] == Interface_Game.keyPoint;
				if (flag14)
				{
					GameScreen.interfaceGame.paintMoveTouch(g, num9);
				}
			}
		}
	}

	// Token: 0x060008FB RID: 2299 RVA: 0x000BBF6C File Offset: 0x000BA16C
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
			g.drawRegion(AvMain.imgCombo, x, 0, Interface_Game.wComboSkill, Interface_Game.wComboSkill, 0, (float)(num + i * Interface_Game.wComboSkill - Interface_Game.wComboSkill / 2), (float)(MapOff_RedLine.yPaintAudition - Interface_Game.wComboSkill / 2), 0);
			g.drawImage(ReadMessenge.mImgCapredLine[i], num + i * Interface_Game.wComboSkill, MapOff_RedLine.yPaintAudition, 3);
			bool flag3 = num3 <= Player.indexAudition;
			if (flag3)
			{
				g.drawRegion(AvMain.imgDelay, 0, 0, Interface_Game.wComboSkill, Interface_Game.wComboSkill, 0, (float)(num + i * Interface_Game.wComboSkill - Interface_Game.wComboSkill / 2), (float)(MapOff_RedLine.yPaintAudition - Interface_Game.wComboSkill / 2), 0);
			}
		}
	}

	// Token: 0x060008FC RID: 2300 RVA: 0x000BC088 File Offset: 0x000BA288
	public static void update()
	{
		MapGotoSky.tickGo++;
		bool flag = MapGotoSky.tickGo == 2000;
		if (flag)
		{
			MapGotoSky.valueGo = 10;
		}
		else
		{
			bool flag2 = MapGotoSky.tickGo == 2500;
			if (flag2)
			{
				MapGotoSky.valueGo = 15;
			}
			else
			{
				bool flag3 = MapGotoSky.tickGo == 3500;
				if (flag3)
				{
					MapGotoSky.valueGo = 20;
				}
			}
		}
		MapGotoSky.updateEff();
		MapGotoSky.updateActionPlayer();
		bool flag4 = GameScreen.player.typeMoveGotoSky == 1;
		if (flag4)
		{
			MapGotoSky.updateKeyAudition();
		}
		GameScreen.player.updateMapGotoSky();
		MainScreen.cameraMain.UpdateCameraGameScreen();
		bool flag5 = Interface_Game.timePointer > 0;
		if (flag5)
		{
			Interface_Game.timePointer--;
		}
	}

	// Token: 0x060008FD RID: 2301 RVA: 0x000BC148 File Offset: 0x000BA348
	public static void updateActionPlayer()
	{
		bool flag = GameScreen.player.typeMoveGotoSky == 0;
		if (flag)
		{
			bool flag2 = MapGotoSky.stepMove >= MapGotoSky.mGo.Length || CRes.abs(GameScreen.player.x - MapGotoSky.mGo[MapGotoSky.stepMove][0]) >= 10 || CRes.abs(GameScreen.player.y - MapGotoSky.mGo[MapGotoSky.stepMove][1]) >= 10;
			if (!flag2)
			{
				MapGotoSky.stepMove++;
				bool flag3 = MapGotoSky.stepMove >= MapGotoSky.mGo.Length;
				if (flag3)
				{
					GameScreen.player.vx = 0;
					GameScreen.player.vy = 0;
					GameScreen.player.typeMoveGotoSky = 1;
				}
				else
				{
					MapGotoSky.SetPosNextMove();
					bool flag4 = MapGotoSky.stepMove == 1;
					if (flag4)
					{
						MapGotoSky.isBeginEffBoat = true;
						GameScreen.player.setSpeed(4, 4);
					}
				}
			}
		}
		else
		{
			bool flag5 = GameScreen.player.typeMoveGotoSky == 1;
			if (flag5)
			{
				bool flag6 = CRes.abs(GameScreen.player.x - GameScreen.player.toX) < 4 && CRes.abs(GameScreen.player.y - GameScreen.player.toY) < 4 && CRes.random(25) == 0;
				if (flag6)
				{
					GameScreen.player.toX = MapGotoSky.x + 20 + CRes.random(MapGotoSky.w - 76);
				}
			}
			else
			{
				bool flag7 = GameScreen.player.typeMoveGotoSky != 3;
				if (!flag7)
				{
					bool flag8 = MapGotoSky.stepMove < MapGotoSky.mGo.Length && CRes.abs(GameScreen.player.x - MapGotoSky.mGo[MapGotoSky.stepMove][0]) < 10 && CRes.abs(GameScreen.player.y - MapGotoSky.mGo[MapGotoSky.stepMove][1]) < 10;
					if (flag8)
					{
						MapGotoSky.stepMove++;
						bool flag9 = MapGotoSky.stepMove < MapGotoSky.mGo.Length;
						if (flag9)
						{
							MapGotoSky.SetPosNextMove();
						}
					}
					bool flag10 = MainScreen.cameraMain.yTo <= MapGotoSky.hMax - 30 - 540 - 45;
					if (flag10)
					{
						MainScreen.cameraMain.yTo = MapGotoSky.hMax - 30 - 540 - 45;
						MapGotoSky.isStopUpdateCamera = true;
					}
				}
			}
		}
	}

	// Token: 0x060008FE RID: 2302 RVA: 0x0000AF5B File Offset: 0x0000915B
	public static void SetPosNextMove()
	{
		GameScreen.player.toX = MapGotoSky.mGo[MapGotoSky.stepMove][0];
		GameScreen.player.toY = MapGotoSky.mGo[MapGotoSky.stepMove][1];
		GameScreen.player.isMoveNor = true;
	}

	// Token: 0x060008FF RID: 2303 RVA: 0x000BC3B4 File Offset: 0x000BA5B4
	public static void updateEff()
	{
		for (int i = 0; i < MapGotoSky.vecEff_Song_Ria.size(); i++)
		{
			Point point = (Point)MapGotoSky.vecEff_Song_Ria.elementAt(i);
			point.y += point.vy;
			point.f++;
			bool flag = point.y < MapGotoSky.y - MapGotoSky.h;
			if (flag)
			{
				point.y = MapGotoSky.y - 24;
			}
		}
		int j = 0;
		while (j < MapGotoSky.vecEff_Song_Giua.size())
		{
			Point point2 = (Point)MapGotoSky.vecEff_Song_Giua.elementAt(j);
			point2.y += point2.vy;
			point2.f++;
			bool flag2 = point2.y < MapGotoSky.y - MapGotoSky.h;
			if (flag2)
			{
				bool flag3 = point2.frame == 0;
				if (flag3)
				{
					point2.y = MapGotoSky.y - 15;
				}
				else
				{
					MapGotoSky.vecEff_Song_Giua.removeElementAt(j);
					j--;
				}
			}
			IL_107:
			j++;
			continue;
			goto IL_107;
		}
		for (int k = 0; k < MapGotoSky.vecEff_Song_Nho.size(); k++)
		{
			Point point3 = (Point)MapGotoSky.vecEff_Song_Nho.elementAt(k);
			point3.y += point3.vy;
			point3.f++;
			bool flag4 = point3.y < MapGotoSky.y - MapGotoSky.h;
			if (flag4)
			{
				MapGotoSky.vecEff_Song_Nho.removeElementAt(k);
				k--;
			}
		}
		for (int l = 0; l < MapGotoSky.vecEff_Song_Nho.size(); l++)
		{
			Point point4 = (Point)MapGotoSky.vecEff_Song_Nho.elementAt(l);
			point4.y += point4.vy;
			point4.f++;
			bool flag5 = point4.y < MapGotoSky.y - MapGotoSky.h;
			if (flag5)
			{
				MapGotoSky.vecEff_Song_Nho.removeElementAt(l);
				l--;
			}
		}
		for (int m = 0; m < MapGotoSky.vecEff_Song_Keo.size(); m++)
		{
			Point point5 = (Point)MapGotoSky.vecEff_Song_Keo.elementAt(m);
			point5.y += point5.vy;
			point5.x += point5.vx;
			point5.f++;
			bool flag6 = point5.f < 4;
			if (flag6)
			{
				point5.fSmall = point5.f;
			}
			else
			{
				bool flag7 = point5.f <= 6;
				if (flag7)
				{
					point5.fSmall = 3;
				}
				else
				{
					bool flag8 = point5.f > 6 && point5.f < 10;
					if (flag8)
					{
						point5.fSmall = 9 - point5.f;
					}
					else
					{
						point5.fSmall = 0;
					}
				}
			}
			bool flag9 = point5.y < MapGotoSky.y - 24;
			if (flag9)
			{
				MapGotoSky.vecEff_Song_Keo.removeElementAt(m);
				m--;
			}
		}
		for (int n = 0; n < MapGotoSky.vecEff_Song_Bien.size(); n++)
		{
			Point point6 = (Point)MapGotoSky.vecEff_Song_Bien.elementAt(n);
			point6.frame++;
			bool flag10 = point6.frame / 2 >= MapGotoSky.fraEffSky5.nFrame && CRes.random(4) == 0;
			if (flag10)
			{
				point6.frame = 0;
				point6.dis = ((CRes.random(5) != 0) ? 2 : 0);
			}
		}
		for (int num = 0; num < MapGotoSky.vecEff_Song_Bien_Nho.size(); num++)
		{
			Point point7 = (Point)MapGotoSky.vecEff_Song_Bien_Nho.elementAt(num);
			point7.frame++;
			bool flag11 = point7.frame / 2 >= MapGotoSky.fraEffSky5.nFrame && CRes.random(10) == 0;
			if (flag11)
			{
				point7.frame = 0;
				point7.fSmall = CRes.random(6);
				point7.dis = CRes.random(5);
			}
		}
		for (int num2 = 0; num2 < MapGotoSky.vecEff_May.size(); num2++)
		{
			Point point8 = (Point)MapGotoSky.vecEff_May.elementAt(num2);
			point8.update();
			bool flag12 = point8.x < MainScreen.cameraMain.xCam - 50 || point8.y > MainScreen.cameraMain.yCam + MotherCanvas.h + 15;
			if (flag12)
			{
				MapGotoSky.vecEff_May.removeElementAt(num2);
				num2--;
			}
		}
		bool flag13 = CRes.random(20) == 0;
		if (flag13)
		{
			Point point9 = new Point(MapGotoSky.x + 18, MapGotoSky.y - 15);
			point9.frame = 1;
			point9.vy = -CRes.random(6, 10);
			MapGotoSky.vecEff_Song_Giua.addElement(point9);
		}
		bool flag14 = CRes.random(5) == 0;
		if (flag14)
		{
			Point point10 = new Point(MapGotoSky.x + 18 + CRes.random(MapGotoSky.w - 36), MapGotoSky.y - 15 - CRes.random(10));
			point10.frame = 0;
			point10.vy = -CRes.random(7, 12);
			MapGotoSky.vecEff_Song_Nho.addElement(point10);
		}
		bool flag15 = CRes.random(3) == 0;
		if (flag15)
		{
			int num3 = CRes.random(2, 4);
			for (int num4 = 0; num4 < num3; num4++)
			{
				Point point11 = new Point(MapGotoSky.x - 24 + CRes.random(MapGotoSky.w + 48), MapGotoSky.y + 40);
				bool flag16 = point11.x - MapGotoSky.x < (MapGotoSky.w + 36) / 3;
				if (flag16)
				{
					point11.frame = 1;
					point11.dis = 0;
					point11.vx = 1;
				}
				else
				{
					bool flag17 = point11.x - MapGotoSky.x > (MapGotoSky.w + 36) / 3 * 2;
					if (flag17)
					{
						point11.frame = 1;
						point11.dis = 2;
						point11.vx = CRes.random_Am_0(2);
					}
					else
					{
						point11.frame = 0;
						point11.dis = 0;
						point11.vx = -1;
					}
				}
				point11.vy = -7;
				MapGotoSky.vecEff_Song_Keo.addElement(point11);
			}
		}
		bool flag18 = MapGotoSky.tickGo > 1000 && CRes.random(30 - MapGotoSky.valueGo) == 0;
		if (flag18)
		{
			Point point12 = new Point();
			point12.x = MainScreen.cameraMain.xCam + 10 + CRes.random(MotherCanvas.w);
			point12.y = MainScreen.cameraMain.yCam - 10;
			point12.vx = -CRes.random(2);
			point12.vy = 2;
			point12.frame = CRes.random(3);
			point12.dis = CRes.random(4);
			MapGotoSky.vecEff_May.addElement(point12);
		}
	}

	// Token: 0x06000900 RID: 2304 RVA: 0x000BA5A8 File Offset: 0x000B87A8
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

	// Token: 0x06000901 RID: 2305 RVA: 0x000BCB20 File Offset: 0x000BAD20
	public static void setTypeMoveredLine(sbyte type)
	{
		GameScreen.player.typeMoveGotoSky = (int)type;
		bool flag = type == 2;
		if (flag)
		{
			GameScreen.player.vy = -12;
			GameScreen.player.vx = -8;
			GameScreen.player.boatSea.vecEff.removeAllElements();
			MapGotoSky.isStopUpdateCamera = true;
			for (int i = 0; i < 3; i++)
			{
				Point point = new Point();
				point.x = GameScreen.player.x + CRes.random_Am_0(15);
				point.y = GameScreen.player.y + CRes.random_Am_0(5);
			}
		}
		else
		{
			bool flag2 = type == 3;
			if (flag2)
			{
				MapGotoSky.stepMove = 0;
				MapGotoSky.mGo = mSystem.new_M_Int(MapGotoSky.mPosGotoSky.Length, 2);
				for (int j = 0; j < MapGotoSky.mPosWinSky.Length; j++)
				{
					MapGotoSky.mGo[j] = new int[2];
					MapGotoSky.mGo[j][0] = MapGotoSky.mPosWinSky[j][0];
					MapGotoSky.mGo[j][1] = MapGotoSky.hMax - 30 - MapGotoSky.mPosWinSky[j][1];
				}
				GameScreen.player.toX = MapGotoSky.mGo[MapGotoSky.stepMove][0];
				GameScreen.player.toY = MapGotoSky.mGo[MapGotoSky.stepMove][1];
			}
		}
	}

	// Token: 0x04000E67 RID: 3687
	public static int x = 140;

	// Token: 0x04000E68 RID: 3688
	public static int y = MotherCanvas.h - 100;

	// Token: 0x04000E69 RID: 3689
	public static int w;

	// Token: 0x04000E6A RID: 3690
	public static int h;

	// Token: 0x04000E6B RID: 3691
	public static int stepMove = 0;

	// Token: 0x04000E6C RID: 3692
	public static int hMax;

	// Token: 0x04000E6D RID: 3693
	public static int wMax;

	// Token: 0x04000E6E RID: 3694
	public static mVector vecEff_Song_Ria = new mVector("MapGotoSky.Song_Ria");

	// Token: 0x04000E6F RID: 3695
	public static mVector vecEff_Song_Giua = new mVector("MapGotoSky.Song_Giua");

	// Token: 0x04000E70 RID: 3696
	public static mVector vecEff_Song_Nho = new mVector("MapGotoSky.Song_Nho");

	// Token: 0x04000E71 RID: 3697
	public static mVector vecEff_Song_Keo = new mVector("MapGotoSky.Song_Keo");

	// Token: 0x04000E72 RID: 3698
	public static mVector vecEff_Song_Bien = new mVector("MapGotoSky.Song_Bien");

	// Token: 0x04000E73 RID: 3699
	public static mVector vecEff_Song_Bien_Nho = new mVector("MapGotoSky.Song_Bien_Nho");

	// Token: 0x04000E74 RID: 3700
	public static mVector vecEff_May = new mVector("MapGotoSky.May");

	// Token: 0x04000E75 RID: 3701
	public static mVector vecEff_Die = new mVector("MapGotoSky.Die");

	// Token: 0x04000E76 RID: 3702
	public static mVector vecEff_May_Goto = new mVector("MapGotoSky.May_Goto");

	// Token: 0x04000E77 RID: 3703
	public static FrameImage fraEffSky0;

	// Token: 0x04000E78 RID: 3704
	public static FrameImage fraEffSky1;

	// Token: 0x04000E79 RID: 3705
	public static FrameImage fraEffSky2;

	// Token: 0x04000E7A RID: 3706
	public static FrameImage fraEffSky3;

	// Token: 0x04000E7B RID: 3707
	public static FrameImage fraEffSky4;

	// Token: 0x04000E7C RID: 3708
	public static FrameImage fraEffSky5;

	// Token: 0x04000E7D RID: 3709
	public static FrameImage fraEffSky6;

	// Token: 0x04000E7E RID: 3710
	public static FrameImage fraEffSky7;

	// Token: 0x04000E7F RID: 3711
	public static mImage[] mcloud = new mImage[3];

	// Token: 0x04000E80 RID: 3712
	public static mImage[] mcloudGoto = new mImage[3];

	// Token: 0x04000E81 RID: 3713
	public static int[] mPlayFrameSong = new int[]
	{
		0,
		1,
		1,
		1,
		1,
		1,
		2
	};

	// Token: 0x04000E82 RID: 3714
	public static int[] mPlayFrameBottom = new int[]
	{
		0,
		2,
		2,
		2,
		2,
		2,
		4
	};

	// Token: 0x04000E83 RID: 3715
	public static int[][] mPosGotoSky = new int[][]
	{
		new int[]
		{
			180,
			90
		},
		new int[]
		{
			220,
			120
		},
		new int[]
		{
			200,
			190
		},
		new int[]
		{
			244,
			270
		},
		new int[]
		{
			184,
			320
		}
	};

	// Token: 0x04000E84 RID: 3716
	public static int[][] mGo;

	// Token: 0x04000E85 RID: 3717
	public static int[][] mPosWinSky = new int[][]
	{
		new int[]
		{
			244,
			420
		},
		new int[]
		{
			184,
			600
		}
	};

	// Token: 0x04000E86 RID: 3718
	public static bool isBeginEffBoat = false;

	// Token: 0x04000E87 RID: 3719
	public static bool isStopUpdateCamera = false;

	// Token: 0x04000E88 RID: 3720
	public static int tickGo = 0;

	// Token: 0x04000E89 RID: 3721
	public static int valueGo;
}
