using System;

// Token: 0x0200008F RID: 143
public class MapOff_RedLine
{
	// Token: 0x06000904 RID: 2308 RVA: 0x000BCE3C File Offset: 0x000BB03C
	public static void setTypeMoveredLine(sbyte type)
	{
		GameScreen.player.typeMoveMapRedLine = (int)type;
		bool flag = type == 1;
		if (flag)
		{
			Point point = new Point();
			point.dis = GameScreen.player.lineShowRedLineNext;
			point.x = MotherCanvas.w + 48;
			point.y = MapOff_RedLine.yHarcodeMapRedLine - 48 + point.dis * 24 - (MotherCanvas.w - MapOff_RedLine.xHardCodeMapRedLine) / 48 * 10;
			point.frame = CRes.random(2);
			MapOff_RedLine.vecDaBien.addElement(point);
		}
		else
		{
			bool flag2 = type == 2;
			if (flag2)
			{
				Player.isShowDie = 2;
				GameScreen.player.tickFinish = 0;
			}
		}
	}

	// Token: 0x06000905 RID: 2309 RVA: 0x000BCEE4 File Offset: 0x000BB0E4
	public static void paintRedLine(mGraphics g)
	{
		bool flag = MapOff_RedLine.tickNoPaint > 0;
		if (flag)
		{
			MapOff_RedLine.tickNoPaint--;
		}
		else
		{
			bool flag2 = MapOff_RedLine.isFinish;
			if (flag2)
			{
				MapOff_RedLine.paintRedLine_Finish(g);
			}
			else
			{
				bool flag3 = MapOff_RedLine.mImgMapOffline == null;
				if (flag3)
				{
					MapOff_RedLine.loadImgRedLine();
				}
				bool flag4 = GameCanvas.mapBack != null;
				if (flag4)
				{
					GameCanvas.mapBack.paint(g);
				}
				int num = MotherCanvas.w / 48 + 2;
				int num2 = MapOff_RedLine.xOffline + MapOff_RedLine.xCamOffline % 48;
				int num3 = MapOff_RedLine.yOffline + MapOff_RedLine.yCamOffline % 10;
				for (int i = 0; i < num; i++)
				{
					g.drawImage(MapOff_RedLine.mImgMapOffline[2], num2 + i * 48, num3 - 128 - i * 10, 0);
				}
				int num4 = 0;
				for (int j = 0; j < num; j++)
				{
					g.drawRegion(MapOff_RedLine.mImgMapOffline[5], num4 % 3 * 24, 0, 48, 24, 0, (float)(num2 + j * 48), (float)(num3 - j * 10 - 6), 0);
					for (int k = 0; k <= (MotherCanvas.h - num3 + j * 10 + 6) / 24; k++)
					{
						num4++;
						g.drawRegion(MapOff_RedLine.mImgMapOffline[5], num4 % 3 * 24, 0, 48, 24, 0, (float)(num2 + j * 48), (float)(num3 - j * 10 - 6 + (k + 1) * 24), 0);
					}
					num4++;
				}
				for (int l = 0; l < MapOff_RedLine.vecSongTuong.size(); l++)
				{
					Point point = (Point)MapOff_RedLine.vecSongTuong.elementAt(l);
					g.drawRegion(MapOff_RedLine.mImgMapOffline[0], 0, point.frame * 24, 24, 24, 0, (float)(num2 + point.x), (float)(num3 + point.y - 24), 0);
				}
				for (int m = 0; m < MapOff_RedLine.vecSongBien.size(); m++)
				{
					Point point2 = (Point)MapOff_RedLine.vecSongBien.elementAt(m);
					bool isSmall = point2.isSmall;
					if (isSmall)
					{
						g.drawRegion(MapOff_RedLine.mImgMapOffline[1], 0, point2.frame * 24, 24, 24, 0, (float)(point2.x2 + point2.x + point2.x0), (float)(point2.y2 + point2.y + point2.y0), 0);
					}
				}
				for (int n = 0; n < MapOff_RedLine.vecDaBien.size(); n++)
				{
					Point point3 = (Point)MapOff_RedLine.vecDaBien.elementAt(n);
					bool flag5 = point3.dis < GameScreen.player.lineShowRedLineCur;
					if (flag5)
					{
						MapOff_RedLine.paintDa(g, point3);
					}
				}
				for (int num5 = 0; num5 < MapOff_RedLine.vecEffSongTuong.size(); num5++)
				{
					Point point4 = (Point)MapOff_RedLine.vecEffSongTuong.elementAt(num5);
					g.drawRegion(MapOff_RedLine.mImgMapOffline[6], 0, MapOff_RedLine.mPlayFrameSong[point4.fSmall] * 48, 48, 48, 0, (float)(point4.x + point4.x2), (float)(point4.y + point4.y2 - 3), 33);
				}
				GameScreen.player.paint(g);
				for (int num6 = 0; num6 < MapOff_RedLine.vecDaBien.size(); num6++)
				{
					Point point5 = (Point)MapOff_RedLine.vecDaBien.elementAt(num6);
					bool flag6 = point5.dis >= GameScreen.player.lineShowRedLineCur;
					if (flag6)
					{
						MapOff_RedLine.paintDa(g, point5);
					}
				}
				for (int num7 = 0; num7 < MapOff_RedLine.vecEffDie.size(); num7++)
				{
					Point point6 = (Point)MapOff_RedLine.vecEffDie.elementAt(num7);
					g.drawRegion(MapOff_RedLine.mImgMapOffline[6], 0, MapOff_RedLine.mPlayFrameSong[point6.fSmall] * 48, 48, 48, 0, (float)point6.x, (float)point6.y, 33);
				}
				bool flag7 = ReadMessenge.mImgCapredLine != null;
				if (flag7)
				{
					g.setColor(0);
					g.drawRect(MotherCanvas.hw - 40 - 1, MapOff_RedLine.yPaintAudition - 20 - 1, 81, 8);
					int num8 = (int)((long)MapOff_RedLine.timeRedline - (GameCanvas.timeNow - MapOff_RedLine.timebegin));
					bool flag8 = num8 <= 0 && GameScreen.player.typeMoveGotoSky == 1;
					if (flag8)
					{
						num8 = 0;
					}
					Interface_Game.PaintHPMP(g, 1, num8, MapOff_RedLine.timeRedline, MotherCanvas.hw - 40, MapOff_RedLine.yPaintAudition - 20, 0, 7, 80, 4, false, 0, false, 0);
					MapOff_RedLine.paintAudition(g);
				}
				bool flag9 = !GameCanvas.isTouch;
				if (!flag9)
				{
					g.drawImage(Interface_Game.imgMove[0], Interface_Game.xPointMove, Interface_Game.yPointMove, 3);
					for (int num9 = 0; num9 < 4; num9++)
					{
						bool flag10 = Interface_Game.timePointer > 0 && GameScreen.interfaceGame.mKeyMove[num9] == Interface_Game.keyPoint;
						if (flag10)
						{
							GameScreen.interfaceGame.paintMoveTouch(g, num9);
						}
					}
				}
			}
		}
	}

	// Token: 0x06000906 RID: 2310 RVA: 0x000BD430 File Offset: 0x000BB630
	public static void paintDa(mGraphics g, Point p)
	{
		bool flag = MapOff_RedLine.mImgMapOffline == null;
		if (flag)
		{
			MapOff_RedLine.loadImgRedLine();
		}
		g.drawImage(MapOff_RedLine.mImgMapOffline[3 + p.frame], p.x + p.x2, p.y + p.y2 + 10, 33);
		g.drawRegion(MapOff_RedLine.mImgMapOffline[6], 0, (2 + GameCanvas.gameTick / 3 % 2) * 48, 48, 48, 0, (float)(p.x + p.x2 - 24 + 6), (float)(p.y + p.y2 + 14), 33);
		bool isSmall = p.isSmall;
		if (isSmall)
		{
			g.drawRegion(MapOff_RedLine.mImgMapOffline[6], 0, MapOff_RedLine.mPlayFrameSong[p.fSmall] * 48, 48, 48, 0, (float)(p.x + p.x2 - 24 + p.fSmall * 3), (float)(p.y + p.y2 + 14), 33);
		}
	}

	// Token: 0x06000907 RID: 2311 RVA: 0x000BD52C File Offset: 0x000BB72C
	public static void loadImgRedLine()
	{
		MapOff_RedLine.mImgMapOffline = new mImage[8];
		for (int i = 0; i < MapOff_RedLine.mImgMapOffline.Length; i++)
		{
			bool flag = i == 5;
			if (flag)
			{
				MapOff_RedLine.mImgMapOffline[i] = mImage.createImage("/bg/b03.png");
			}
			else
			{
				MapOff_RedLine.mImgMapOffline[i] = mImage.createImage("/bg/redline" + i.ToString() + ".png");
			}
		}
	}

	// Token: 0x06000908 RID: 2312 RVA: 0x000BBF6C File Offset: 0x000BA16C
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

	// Token: 0x06000909 RID: 2313 RVA: 0x000BD5A0 File Offset: 0x000BB7A0
	public static void updateRedLine()
	{
		bool flag = MapOff_RedLine.isFinish;
		if (flag)
		{
			MapOff_RedLine.updateRedLine_Finish();
		}
		else
		{
			bool flag2 = GameCanvas.mapBack != null;
			if (flag2)
			{
				GameCanvas.mapBack.updateCloud();
			}
			bool flag3 = Interface_Game.timePointer > 0;
			if (flag3)
			{
				Interface_Game.timePointer--;
			}
			MapOff_RedLine.xCamOffline -= MapOff_RedLine.vxHardcodeRedLine;
			MapOff_RedLine.yCamOffline = -(MapOff_RedLine.xCamOffline * 5) / 24;
			MapOff_RedLine.updateSongTuong();
			MapOff_RedLine.updateSongBien();
			MapOff_RedLine.updateEffDie();
			MapOff_RedLine.updateEffSongTuong();
			MapOff_RedLine.addDaBien();
			MapOff_RedLine.updateDaBien();
			GameScreen.player.updateMapRedLine();
			MapOff_RedLine.updateKeyAudition();
			MapOff_RedLine.updateRedLineFail();
			MapOff_RedLine.addEffSongTuong();
			bool flag4 = GameScreen.player.typeMoveMapRedLine == 0;
			if (flag4)
			{
				bool flag5 = MapOff_RedLine.tickSendDie > 0;
				if (flag5)
				{
					MapOff_RedLine.tickSendDie--;
				}
				else
				{
					bool flag6 = (long)MapOff_RedLine.timeRedline - (GameCanvas.timeNow - MapOff_RedLine.timebegin) <= 0L;
					if (flag6)
					{
						GlobalService.gI().Red_Line(0, 10);
						MapOff_RedLine.tickSendDie = 40;
					}
				}
			}
		}
	}

	// Token: 0x0600090A RID: 2314 RVA: 0x000BD6C0 File Offset: 0x000BB8C0
	private static void updateEffDie()
	{
		for (int i = 0; i < MapOff_RedLine.vecEffDie.size(); i++)
		{
			Point point = (Point)MapOff_RedLine.vecEffDie.elementAt(i);
			point.update();
			bool flag = GameCanvas.gameTick % 2 == 0;
			if (flag)
			{
				point.fSmall++;
			}
			bool flag2 = point.fSmall >= MapOff_RedLine.mPlayFrameSong.Length;
			if (flag2)
			{
				MapOff_RedLine.vecEffDie.removeElement(point);
				i--;
			}
		}
	}

	// Token: 0x0600090B RID: 2315 RVA: 0x000BD74C File Offset: 0x000BB94C
	private static void updateEffSongTuong()
	{
		for (int i = 0; i < MapOff_RedLine.vecEffSongTuong.size(); i++)
		{
			Point point = (Point)MapOff_RedLine.vecEffSongTuong.elementAt(i);
			point.x2 -= MapOff_RedLine.vxHardcodeRedLine;
			point.y2 = -(point.x2 * 5) / 24;
			bool flag = GameCanvas.gameTick % 2 == 0;
			if (flag)
			{
				point.fSmall++;
			}
			bool flag2 = point.fSmall >= MapOff_RedLine.mPlayFrameSong.Length;
			if (flag2)
			{
				MapOff_RedLine.vecEffSongTuong.removeElement(point);
				i--;
			}
		}
	}

	// Token: 0x0600090C RID: 2316 RVA: 0x000BD7F8 File Offset: 0x000BB9F8
	private static void updateRedLineFail()
	{
		bool flag = (Player.isShowDie == 1 || Player.isShowDie == 11) && CRes.random(3) == 0;
		if (flag)
		{
			Point point = new Point();
			point.x = GameScreen.player.x + 10 + CRes.random_Am_0(30);
			point.y = GameScreen.player.y + 18 + CRes.random_Am_0(4);
			point.vx = GameScreen.player.vx;
			point.vy = GameScreen.player.vy;
			MapOff_RedLine.vecEffDie.addElement(point);
		}
	}

	// Token: 0x0600090D RID: 2317 RVA: 0x000BD890 File Offset: 0x000BBA90
	private static void addEffSongTuong()
	{
		bool flag = CRes.random(10) == 0;
		if (flag)
		{
			Point point = new Point();
			point.x = MapOff_RedLine.xOffline + CRes.random(MotherCanvas.w);
			point.y = MapOff_RedLine.yOffline - point.x / 24 * 5;
			MapOff_RedLine.vecEffSongTuong.addElement(point);
		}
	}

	// Token: 0x0600090E RID: 2318 RVA: 0x000BD8F0 File Offset: 0x000BBAF0
	private static void updateSongBien()
	{
		for (int i = 0; i < MapOff_RedLine.vecSongBien.size(); i++)
		{
			Point point = (Point)MapOff_RedLine.vecSongBien.elementAt(i);
			point.f++;
			bool flag = point.x2 == 0;
			if (flag)
			{
				point.x2 = MapOff_RedLine.xOffline;
				point.y2 = MapOff_RedLine.yOffline;
				point.x0 = 0;
				point.y0 = 0;
			}
			bool isSmall = point.isSmall;
			if (isSmall)
			{
				bool flag2 = point.f % 3 == 0;
				if (flag2)
				{
					point.frame++;
				}
				point.x0 -= 3;
				point.y0 = -(point.x0 * 5) / 24;
			}
			else
			{
				bool flag3 = CRes.random(100) == 0;
				if (flag3)
				{
					point.isSmall = true;
					point.x2 = MapOff_RedLine.xOffline;
					point.y2 = MapOff_RedLine.yOffline;
					point.x0 = 0;
					point.y0 = 0;
				}
			}
			bool flag4 = point.frame >= 7;
			if (flag4)
			{
				point.frame = 0;
				bool flag5 = CRes.random(100) == 0;
				if (flag5)
				{
					point.isSmall = true;
					point.x2 = MapOff_RedLine.xOffline;
					point.y2 = MapOff_RedLine.yOffline;
					point.x0 = 0;
					point.y0 = 0;
				}
				else
				{
					point.isSmall = false;
				}
			}
		}
	}

	// Token: 0x0600090F RID: 2319 RVA: 0x000BDA64 File Offset: 0x000BBC64
	private static void updateSongTuong()
	{
		for (int i = 0; i < MapOff_RedLine.vecSongTuong.size(); i++)
		{
			Point point = (Point)MapOff_RedLine.vecSongTuong.elementAt(i);
			point.f++;
			bool isSmall = point.isSmall;
			if (isSmall)
			{
				bool flag = point.f % 3 == 0;
				if (flag)
				{
					point.frame++;
				}
			}
			else
			{
				bool flag2 = CRes.random(5) == 0;
				if (flag2)
				{
					point.isSmall = true;
				}
			}
			bool flag3 = point.frame >= 7;
			if (flag3)
			{
				point.frame = 0;
				bool flag4 = CRes.random(3) == 0;
				if (flag4)
				{
					point.isSmall = true;
				}
				else
				{
					point.isSmall = false;
				}
			}
		}
	}

	// Token: 0x06000910 RID: 2320 RVA: 0x000BDB38 File Offset: 0x000BBD38
	public static void moveTypeKeypad()
	{
		bool flag = GameCanvas.isPointerSelect && GameCanvas.isPointLast(Interface_Game.xPointMove - 2 * Interface_Game.wArrowMove, Interface_Game.yPointMove - 2 * Interface_Game.wArrowMove, Interface_Game.wArrowMove * 4, Interface_Game.wArrowMove * 4);
		if (flag)
		{
			int num = CRes.angle(GameCanvas.px - Interface_Game.xPointMove, GameCanvas.py - Interface_Game.yPointMove);
			int num2 = (num > 45 && num <= 135) ? 3 : ((num <= 135 || num > 225) ? ((num <= 225 || num > 315) ? 1 : 2) : 0);
			GameCanvas.clearKeyHold();
			GameCanvas.isPointerDown = true;
			GameCanvas.isPointerSelect = false;
			Interface_Game.keyPoint = GameScreen.interfaceGame.mKeyMove[num2];
			Interface_Game.timePointer = 3;
			GameCanvas.keyMyHold[Interface_Game.keyPoint] = true;
		}
	}

	// Token: 0x06000911 RID: 2321 RVA: 0x000BDC14 File Offset: 0x000BBE14
	private static void updateKeyAudition()
	{
		bool flag = GameCanvas.keyMove(1);
		if (flag)
		{
			GlobalService.gI().Red_Line(0, 1);
			GameCanvas.ClearkeyMove(1);
			Player.indexAudition++;
		}
		else
		{
			bool flag2 = GameCanvas.keyMove(2);
			if (flag2)
			{
				GlobalService.gI().Red_Line(0, 2);
				GameCanvas.ClearkeyMove(2);
				Player.indexAudition++;
			}
			else
			{
				bool flag3 = GameCanvas.keyMove(3);
				if (flag3)
				{
					GlobalService.gI().Red_Line(0, 3);
					GameCanvas.ClearkeyMove(3);
					Player.indexAudition++;
				}
				else
				{
					bool flag4 = GameCanvas.keyMove(0);
					if (flag4)
					{
						GlobalService.gI().Red_Line(0, 0);
						GameCanvas.ClearkeyMove(0);
						Player.indexAudition++;
					}
				}
			}
		}
	}

	// Token: 0x06000912 RID: 2322 RVA: 0x000BDCDC File Offset: 0x000BBEDC
	public static void updateDaBien()
	{
		for (int i = 0; i < MapOff_RedLine.vecDaBien.size(); i++)
		{
			Point point = (Point)MapOff_RedLine.vecDaBien.elementAt(i);
			point.x2 -= MapOff_RedLine.vxHardcodeRedLine;
			point.y2 = -(point.x2 * 5) / 24;
			bool isSmall = point.isSmall;
			if (isSmall)
			{
				bool flag = GameCanvas.gameTick % 3 == 0;
				if (flag)
				{
					point.fSmall++;
					bool flag2 = point.fSmall >= MapOff_RedLine.mPlayFrameSong.Length;
					if (flag2)
					{
						point.isSmall = false;
					}
				}
			}
			else
			{
				bool flag3 = CRes.random(4) == 0;
				if (flag3)
				{
					point.fSmall = 0;
					point.isSmall = true;
				}
			}
			bool flag4 = point.x2 < -(MotherCanvas.w + 72);
			if (flag4)
			{
				MapOff_RedLine.vecDaBien.removeElement(point);
				i--;
			}
		}
	}

	// Token: 0x06000913 RID: 2323 RVA: 0x000BDDD8 File Offset: 0x000BBFD8
	public static void addDaBien()
	{
		bool flag = MapOff_RedLine.tickAddDa > 0;
		if (flag)
		{
			MapOff_RedLine.tickAddDa--;
		}
		else
		{
			bool flag2 = CRes.random(80) == 0 && Player.isShowDie == 0;
			if (flag2)
			{
				MapOff_RedLine.tickAddDa = 70;
				Point point = new Point();
				point.dis = GameScreen.player.lineShowRedLineNext;
				point.x = MotherCanvas.w + 48;
				point.y = MapOff_RedLine.yHarcodeMapRedLine - 48 + point.dis * 24 - (MotherCanvas.w - MapOff_RedLine.xHardCodeMapRedLine) / 48 * 10;
				point.frame = CRes.random(2);
				MapOff_RedLine.vecDaBien.addElement(point);
			}
		}
	}

	// Token: 0x06000914 RID: 2324 RVA: 0x000BDE8C File Offset: 0x000BC08C
	public static void paintRedLine_Finish(mGraphics g)
	{
		bool flag = GameCanvas.mapBack != null;
		if (flag)
		{
			GameCanvas.mapBack.paint(g);
		}
		bool flag2 = MapOff_RedLine.mImgMapOffline == null;
		if (flag2)
		{
			MapOff_RedLine.loadImgRedLine();
		}
		int num = MotherCanvas.w / 48 + 2;
		int num2 = MapOff_RedLine.xOffline + MapOff_RedLine.xCamOffline % 48;
		int num3 = MapOff_RedLine.yOffline + MapOff_RedLine.yCamOffline % 10;
		for (int i = 0; i < num; i++)
		{
			g.drawRegion(MapOff_RedLine.mImgMapOffline[2], 0, 0, 48, 128, 2, (float)(num2 + i * 48), (float)(num3 - 128 + i * 10), 0);
		}
		int num4 = 0;
		for (int j = 0; j < num; j++)
		{
			g.drawRegion(MapOff_RedLine.mImgMapOffline[5], num4 % 3 * 24, 0, 48, 24, 0, (float)(num2 + j * 48), (float)(num3 + j * 10 - 6), 0);
			for (int k = 0; k <= (MotherCanvas.h - num3 + j * 10 + 6) / 24; k++)
			{
				num4++;
				g.drawRegion(MapOff_RedLine.mImgMapOffline[5], num4 % 3 * 24, 0, 48, 24, 0, (float)(num2 + j * 48), (float)(num3 + j * 10 - 6 + (k + 1) * 24), 0);
			}
			num4++;
		}
		for (int l = 0; l < MapOff_RedLine.vecSongTuong.size(); l++)
		{
			Point point = (Point)MapOff_RedLine.vecSongTuong.elementAt(l);
			g.drawRegion(MapOff_RedLine.mImgMapOffline[7], 0, point.frame * 24, 24, 24, 0, (float)(num2 + point.x), (float)(num3 + point.y - 24), 0);
		}
		for (int m = 0; m < MapOff_RedLine.vecSongBien.size(); m++)
		{
			Point point2 = (Point)MapOff_RedLine.vecSongBien.elementAt(m);
			bool isSmall = point2.isSmall;
			if (isSmall)
			{
				g.drawRegion(MapOff_RedLine.mImgMapOffline[7], 0, point2.frame * 24, 24, 24, 0, (float)(point2.x2 + point2.x + point2.x0), (float)(point2.y2 + point2.y + point2.y0), 0);
			}
		}
		for (int n = 0; n < MapOff_RedLine.vecEffSongTuong.size(); n++)
		{
			Point point3 = (Point)MapOff_RedLine.vecEffSongTuong.elementAt(n);
			g.drawRegion(MapOff_RedLine.mImgMapOffline[6], 0, MapOff_RedLine.mPlayFrameSong[point3.fSmall] * 48, 48, 48, 0, (float)(point3.x + point3.x2), (float)(point3.y + point3.y2 - 3), 33);
		}
		GameScreen.player.paint(g);
	}

	// Token: 0x06000915 RID: 2325 RVA: 0x000BE17C File Offset: 0x000BC37C
	public static void updateRedLine_Finish()
	{
		bool flag = GameCanvas.mapBack != null;
		if (flag)
		{
			GameCanvas.mapBack.updateCloud();
		}
		MapOff_RedLine.xCamOffline -= MapOff_RedLine.vxHardcodeRedLine;
		MapOff_RedLine.yCamOffline = MapOff_RedLine.xCamOffline * 5 / 24;
		MapOff_RedLine.updateSongTuong();
		MapOff_RedLine.updateSongBien();
		MapOff_RedLine.addEffSongTuong_Finish();
		MapOff_RedLine.updateEffSongTuong_Finish();
		GameScreen.player.updateRedLineFinish();
	}

	// Token: 0x06000916 RID: 2326 RVA: 0x000BE1E8 File Offset: 0x000BC3E8
	private static void addEffSongTuong_Finish()
	{
		bool flag = CRes.random(10) == 0;
		if (flag)
		{
			Point point = new Point();
			point.x = MapOff_RedLine.xOffline + CRes.random(MotherCanvas.w);
			point.y = MapOff_RedLine.yOffline + point.x / 24 * 5;
			MapOff_RedLine.vecEffSongTuong.addElement(point);
		}
	}

	// Token: 0x06000917 RID: 2327 RVA: 0x000BE248 File Offset: 0x000BC448
	private static void updateEffSongTuong_Finish()
	{
		for (int i = 0; i < MapOff_RedLine.vecEffSongTuong.size(); i++)
		{
			Point point = (Point)MapOff_RedLine.vecEffSongTuong.elementAt(i);
			point.x2 -= MapOff_RedLine.vxHardcodeRedLine;
			point.y2 = point.x2 * 5 / 24;
			bool flag = GameCanvas.gameTick % 2 == 0;
			if (flag)
			{
				point.fSmall++;
			}
			bool flag2 = point.fSmall >= MapOff_RedLine.mPlayFrameSong.Length;
			if (flag2)
			{
				MapOff_RedLine.vecEffSongTuong.removeElement(point);
				i--;
			}
		}
	}

	// Token: 0x06000918 RID: 2328 RVA: 0x0000AF97 File Offset: 0x00009197
	public static void changeFinish()
	{
		GameCanvas.readMess.LoadRedLine(true);
		MapOff_RedLine.tickNoPaint = 5;
	}

	// Token: 0x04000E8A RID: 3722
	public static mImage[] mImgMapOffline;

	// Token: 0x04000E8B RID: 3723
	public static mVector vecSongTuong = new mVector("MapOff_RedLine.SongTuong");

	// Token: 0x04000E8C RID: 3724
	public static mVector vecSongBien = new mVector("MapOff_RedLine.SongBien");

	// Token: 0x04000E8D RID: 3725
	public static mVector vecDaBien = new mVector("MapOff_RedLine.DaBien");

	// Token: 0x04000E8E RID: 3726
	public static mVector vecEffDie = new mVector("MapOff_RedLine.EffDie");

	// Token: 0x04000E8F RID: 3727
	public static mVector vecEffSongTuong = new mVector("MapOff_RedLine.EffSongTuong");

	// Token: 0x04000E90 RID: 3728
	public static int xOffline;

	// Token: 0x04000E91 RID: 3729
	public static int yOffline;

	// Token: 0x04000E92 RID: 3730
	public static int xCamOffline;

	// Token: 0x04000E93 RID: 3731
	public static int yCamOffline;

	// Token: 0x04000E94 RID: 3732
	public static int timeRedline;

	// Token: 0x04000E95 RID: 3733
	public static int tickNoPaint = 0;

	// Token: 0x04000E96 RID: 3734
	public static int tickSendDie = 0;

	// Token: 0x04000E97 RID: 3735
	public static long timebegin;

	// Token: 0x04000E98 RID: 3736
	public static int yHarcodeMapRedLine = MotherCanvas.h / 5 * 4;

	// Token: 0x04000E99 RID: 3737
	public static int xHardCodeMapRedLine = MotherCanvas.w / 3;

	// Token: 0x04000E9A RID: 3738
	public static int vxHardcodeRedLine = 6;

	// Token: 0x04000E9B RID: 3739
	public static int[] mPlayFrameSong = new int[]
	{
		2,
		0,
		1,
		2,
		3
	};

	// Token: 0x04000E9C RID: 3740
	public static bool isFinish = false;

	// Token: 0x04000E9D RID: 3741
	public static int yPaintAudition = MotherCanvas.h - 20;

	// Token: 0x04000E9E RID: 3742
	public static int tickAddDa = 0;
}
