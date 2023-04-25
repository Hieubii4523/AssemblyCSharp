using System;

// Token: 0x0200002D RID: 45
public class Effect_Spec : MainEffect
{
	// Token: 0x0600035D RID: 861 RVA: 0x0006DBA8 File Offset: 0x0006BDA8
	public Effect_Spec(MainObject objMain, short type, short time)
	{
		this.objFireMain = objMain;
		this.typeEffect = (int)type;
		this.timeBegin = GameCanvas.timeNow;
		this.timeEff = time;
		mSystem.println("add eff " + this.typeEffect.ToString());
		switch (this.typeEffect)
		{
		case -2:
			this.fraImgEff = new FrameImage(156, 26, 50);
			this.dy = -objMain.hOne + 20;
			this.levelPaint = -1;
			break;
		case -1:
			this.fraImgEff = new FrameImage(155, 21, 28);
			this.dy = -objMain.hOne + 12;
			this.levelPaint = -1;
			break;
		case 1:
			this.objFireMain.DirSpec = this.objFireMain.Dir;
			this.fraImgEff = new FrameImage(158, 25, 12);
			this.dy = -objMain.hOne + 3;
			break;
		case 2:
			this.fraImgEff = new FrameImage(162, 10, 20);
			this.dy = -objMain.hOne + 35;
			this.dx = CRes.random_Am_0(8);
			this.vy = 2;
			break;
		case 3:
			this.createGiamTanCong();
			break;
		case 4:
			this.createGiamPhongThu();
			break;
		case 5:
			this.fraImgEff = new FrameImage(157, 10, 10);
			this.dy = -objMain.hOne + 3;
			for (int i = 0; i < 2; i++)
			{
				Point point = new Point
				{
					x = -5
				};
				bool flag = i == 1;
				if (flag)
				{
					point.x = 5;
				}
				point.y = this.dy;
				point.frame = i * 2;
				this.vecEff.addElement(point);
			}
			break;
		case 6:
			this.fraImgEff = new FrameImage(122, 16, 12);
			for (int j = 0; j < 3; j++)
			{
				Point o = new Point(this.objFireMain.x + CRes.random_Am_0(20), this.objFireMain.y - CRes.random(this.objFireMain.hOne + 10))
				{
					frame = CRes.random(3)
				};
				this.vecEff.addElement(o);
			}
			break;
		case 7:
		{
			this.fraImgEff = new FrameImage(160, 9, 14);
			this.dy = -objMain.hOne / 2;
			int num = CRes.random(2, 5);
			for (int k = 0; k < num; k++)
			{
				Point o2 = new Point(CRes.random_Am_0(10), this.dy + CRes.random_Am_0(15))
				{
					fRe = CRes.random(6, 10),
					frame = CRes.random(3) * 3,
					dis = CRes.random(3)
				};
				this.vecEff.addElement(o2);
			}
			break;
		}
		case 8:
			this.fraImgEff = new FrameImage(170, 32, 24);
			this.levelPaint = -1;
			break;
		case 9:
			this.fraImgEff = new FrameImage(163, 28, 31);
			break;
		case 10:
			this.fraImgEff = new FrameImage(164, 19, 19);
			this.dy = -objMain.hOne;
			break;
		case 11:
			this.fraImgEff = new FrameImage(350, 25, 44);
			this.mPlayFrameVip = new int[][]
			{
				new int[]
				{
					0,
					0,
					2,
					2,
					6,
					6,
					12,
					12,
					-1,
					-1,
					-1,
					-1
				},
				new int[]
				{
					0,
					0,
					1,
					1,
					1,
					1,
					2,
					2,
					0,
					0,
					0,
					0
				}
			};
			break;
		case 12:
			this.pMain = new Point(0, 0);
			this.pMain.vx = -4;
			this.pMain.vy = -15;
			this.fraImgEff = new FrameImage(220, 9, 9, 4);
			this.mPlayframe = new int[]
			{
				4,
				7,
				5,
				7
			};
			break;
		case 15:
			this.fraImgEff = new FrameImage(398, 19, 19);
			this.dy = -objMain.hOne + 1;
			break;
		case 18:
			this.fraImgEff = new FrameImage(400, 3);
			this.dy = -objMain.hOne;
			break;
		}
	}

	// Token: 0x0600035E RID: 862 RVA: 0x0006E0B4 File Offset: 0x0006C2B4
	private void createGiamTanCong()
	{
		this.fraImgEff = new FrameImage(159, 45, 12);
		this.dy = -this.objFireMain.hOne + 5;
		Point point = new Point(0, this.dy);
		point.vy = 2;
		this.vecEff.addElement(point);
	}

	// Token: 0x0600035F RID: 863 RVA: 0x0006E10C File Offset: 0x0006C30C
	private void createGiamPhongThu()
	{
		this.fraImgEff = new FrameImage(161, 35, 13);
		this.dy = -this.objFireMain.hOne + 10;
		Point point = new Point(0, this.dy);
		point.vy = 2;
		this.vecEff.addElement(point);
	}

	// Token: 0x06000360 RID: 864 RVA: 0x0006E164 File Offset: 0x0006C364
	public void paintFrist(mGraphics g)
	{
		switch (this.typeEffect)
		{
		case 3:
		case 4:
			for (int i = 0; i < this.vecEff.size(); i++)
			{
				Point point = (Point)this.vecEff.elementAt(i);
				this.fraImgEff.drawFrame(GameCanvas.gameTick / 2 % this.fraImgEff.nFrame / 2 * 2, this.objFireMain.x + point.x, this.objFireMain.y + point.y - this.fraImgEff.frameHeight / 2, 0, 3, g);
			}
			break;
		case 7:
			for (int j = 0; j < this.vecEff.size(); j++)
			{
				Point point2 = (Point)this.vecEff.elementAt(j);
				bool flag = point2.dis == 0;
				if (flag)
				{
					this.fraImgEff.drawFrame(point2.frame + point2.f / 2 % 3, this.objFireMain.x + point2.x, this.objFireMain.y + point2.y, 0, 3, g);
				}
			}
			break;
		case 8:
			this.fraImgEff.drawFrame(GameCanvas.gameTickChia4 % this.fraImgEff.nFrame, this.objFireMain.x, this.objFireMain.y + this.dy, 0, 3, g);
			break;
		case 12:
		{
			bool flag2 = this.pMain != null && this.pMain.vx > 0;
			if (flag2)
			{
				for (int k = 0; k < this.vecEff.size(); k++)
				{
					Point point3 = (Point)this.vecEff.elementAt(k);
					this.fraImgEff.drawFrameNew(this.mPlayframe[point3.f / 2], this.objFireMain.x + point3.x, this.objFireMain.y + point3.y / 10, 0, 3, g);
				}
			}
			break;
		}
		}
	}

	// Token: 0x06000361 RID: 865 RVA: 0x0006E3C4 File Offset: 0x0006C5C4
	public override void paint(mGraphics g)
	{
		switch (this.typeEffect)
		{
		case -2:
			this.fraImgEff.drawFrame(GameCanvas.gameTick / 3 % this.fraImgEff.nFrame, this.objFireMain.x, this.objFireMain.y + this.dy - GameCanvas.gameTick / 3 % 3 * 2, this.objFireMain.Dir, 3, g);
			break;
		case -1:
			this.fraImgEff.drawFrame(GameCanvas.gameTick / 3 % this.fraImgEff.nFrame, this.objFireMain.x, this.objFireMain.y + this.dy - GameCanvas.gameTick / 3 % 3, this.objFireMain.Dir, 3, g);
			break;
		case 1:
		case 10:
			this.fraImgEff.drawFrame(GameCanvas.gameTickChia4 % this.fraImgEff.nFrame, this.objFireMain.x, this.objFireMain.y + this.dy, 0, 3, g);
			break;
		case 2:
		{
			bool flag = this.tick <= this.fRemove;
			if (flag)
			{
				int num = this.tick / 2;
				bool flag2 = num > 2;
				if (flag2)
				{
					num = 2;
				}
				this.fraImgEff.drawFrame(num, this.objFireMain.x + this.dx, this.objFireMain.y + this.dy, 0, 3, g);
			}
			break;
		}
		case 3:
		case 4:
			for (int i = 0; i < this.vecEff.size(); i++)
			{
				Point point = (Point)this.vecEff.elementAt(i);
				this.fraImgEff.drawFrame(GameCanvas.gameTick / 2 % this.fraImgEff.nFrame / 2 * 2 + 1, this.objFireMain.x + point.x, this.objFireMain.y + point.y + this.fraImgEff.frameHeight / 2, 0, 3, g);
			}
			break;
		case 5:
			for (int j = 0; j < this.vecEff.size(); j++)
			{
				Point point2 = (Point)this.vecEff.elementAt(j);
				this.fraImgEff.drawFrame((GameCanvas.gameTick / 6 + point2.frame) % this.fraImgEff.nFrame, this.objFireMain.x + point2.x, this.objFireMain.y + point2.y, 0, 3, g);
			}
			break;
		case 6:
			this.paintDien_Giat(g);
			break;
		case 7:
			for (int k = 0; k < this.vecEff.size(); k++)
			{
				Point point3 = (Point)this.vecEff.elementAt(k);
				bool flag3 = point3.dis != 0;
				if (flag3)
				{
					this.fraImgEff.drawFrame(point3.frame + point3.f / 2 % 3, this.objFireMain.x + point3.x, this.objFireMain.y + point3.y, 0, 3, g);
				}
			}
			break;
		case 9:
			this.fraImgEff.drawFrame(GameCanvas.gameTickChia4 % this.fraImgEff.nFrame, this.objFireMain.x, this.objFireMain.y, 0, 33, g);
			break;
		case 11:
		{
			int num2 = this.f % this.mPlayFrameVip[0].Length;
			bool flag4 = this.mPlayFrameVip[0][num2] >= 0;
			if (flag4)
			{
				int num3 = this.mPlayFrameVip[0][num2];
				bool flag5 = this.objFireMain.type_left_right == 0;
				if (flag5)
				{
					num3 = -num3;
				}
				this.fraImgEff.drawFrame(this.mPlayFrameVip[1][num2], this.objFireMain.x - num3, this.objFireMain.y, (this.objFireMain.type_left_right == 0) ? 2 : 0, 33, g);
				this.fraImgEff.drawFrame(this.mPlayFrameVip[1][num2], this.objFireMain.x + num3, this.objFireMain.y, this.objFireMain.type_left_right, 33, g);
			}
			break;
		}
		case 12:
		{
			bool flag6 = this.pMain != null && this.pMain.vx < 0;
			if (flag6)
			{
				for (int l = 0; l < this.vecEff.size(); l++)
				{
					Point point4 = (Point)this.vecEff.elementAt(l);
					this.fraImgEff.drawFrameNew(this.mPlayframe[point4.f / 2], this.objFireMain.x + point4.x, this.objFireMain.y + point4.y / 10, 0, 3, g);
				}
			}
			break;
		}
		case 15:
			this.fraImgEff.drawFrame(GameCanvas.gameTickChia4 % this.fraImgEff.nFrame, this.objFireMain.x + this.dx, this.objFireMain.y + this.dy, 0, 3, g);
			break;
		case 18:
			this.fraImgEff.drawFrame(GameCanvas.gameTick / 2 % this.fraImgEff.nFrame, this.objFireMain.x + this.dx, this.objFireMain.y + this.dy, 0, 3, g);
			break;
		}
	}

	// Token: 0x06000362 RID: 866 RVA: 0x0006E9B4 File Offset: 0x0006CBB4
	private void paintDien_Giat(mGraphics g)
	{
		for (int i = 0; i < this.vecEff.size(); i++)
		{
			Point point = (Point)this.vecEff.elementAt(i);
			this.fraImgEff.drawFrame(point.frame * 2 + point.f / 2, this.objFireMain.x + point.x, this.objFireMain.y - point.y, point.dis, 3, g);
		}
	}

	// Token: 0x06000363 RID: 867 RVA: 0x0006EA3C File Offset: 0x0006CC3C
	public override void update()
	{
		bool flag = (GameCanvas.timeNow - this.timeBegin) / 100L >= (long)this.timeEff;
		if (flag)
		{
			this.isRemove = true;
		}
		else
		{
			switch (this.typeEffect)
			{
			case -2:
			case -1:
			case 1:
			case 5:
			case 9:
			case 10:
			case 15:
			case 18:
				return;
			case 2:
			{
				this.tick++;
				bool flag2 = this.tick >= this.fRemove && (CRes.random(20) == 0 || this.tick > this.fRemove + 15);
				if (flag2)
				{
					this.dx = CRes.random_Am_0(8);
					this.dy = -this.objFireMain.hOne + 35;
					this.fRemove = CRes.random(8, 14);
					this.tick = 0;
				}
				bool flag3 = this.tick >= 6;
				if (flag3)
				{
					this.dy += this.vy;
				}
				return;
			}
			case 3:
			case 4:
				for (int i = 0; i < this.vecEff.size(); i++)
				{
					Point point = (Point)this.vecEff.elementAt(i);
					point.update();
					bool flag4 = point.y < 0;
					if (!flag4)
					{
						bool flag5 = point.frame < 5;
						if (flag5)
						{
							point.y = 0;
							point.frame++;
							bool flag6 = point.frame == 2;
							if (flag6)
							{
								Point point2 = new Point(0, this.dy);
								point2.vy = 2;
								this.vecEff.addElement(point2);
							}
						}
						else
						{
							this.vecEff.removeElement(point);
							i--;
						}
					}
				}
				return;
			case 6:
			{
				bool flag7 = CRes.random(3) != 0;
				if (flag7)
				{
					for (int j = 0; j < 2; j++)
					{
						Point point3 = new Point(CRes.random_Am_0(15), CRes.random(this.objFireMain.hOne + 1));
						point3.frame = CRes.random(3);
						point3.dis = CRes.random(8);
						this.vecEff.addElement(point3);
					}
				}
				for (int k = 0; k < this.vecEff.size(); k++)
				{
					Point point4 = (Point)this.vecEff.elementAt(k);
					point4.f++;
					bool flag8 = point4.f >= 4;
					if (flag8)
					{
						this.vecEff.removeElement(point4);
						k--;
					}
				}
				return;
			}
			case 7:
			{
				bool flag9 = CRes.random(3) == 0 && this.vecEff.size() < 4;
				if (flag9)
				{
					int num = CRes.random(1, 4);
					for (int l = 0; l < num; l++)
					{
						Point point5 = new Point(CRes.random_Am_0(10), this.dy + CRes.random_Am_0(15));
						point5.fRe = CRes.random(6, 10);
						point5.frame = CRes.random(3) * 3;
						point5.vy = -CRes.random(2);
						point5.dis = CRes.random(3);
						this.vecEff.addElement(point5);
					}
				}
				for (int m = 0; m < this.vecEff.size(); m++)
				{
					Point point6 = (Point)this.vecEff.elementAt(m);
					point6.update();
					bool flag10 = point6.f > point6.fRe;
					if (flag10)
					{
						this.vecEff.removeElement(point6);
						m--;
					}
				}
				return;
			}
			case 11:
				this.f++;
				return;
			case 12:
			{
				for (int n = 0; n < this.vecEff.size(); n++)
				{
					Point point7 = (Point)this.vecEff.elementAt(n);
					point7.update();
					bool flag11 = point7.f >= 8;
					if (flag11)
					{
						this.vecEff.removeElement(point7);
						n--;
					}
				}
				this.pMain.update();
				bool flag12 = this.pMain.x < -16;
				if (flag12)
				{
					this.pMain.vx = 4;
				}
				bool flag13 = this.pMain.x > 16;
				if (flag13)
				{
					this.pMain.vx = -4;
				}
				bool flag14 = this.pMain.y < -500;
				if (flag14)
				{
					this.pMain.y = 0;
				}
				Point point8 = new Point(this.pMain.x, this.pMain.y);
				point8.vy = CRes.random(30);
				point8.f = 1;
				this.vecEff.addElement(point8);
				return;
			}
			}
			bool flag15 = GameCanvas.gameTick % 20 == 0;
			if (flag15)
			{
				GameScreen.addEffectNum(this.mtest[this.typeEffect], this.objFireMain.x, this.objFireMain.y - this.objFireMain.hOne, 5);
			}
		}
	}

	// Token: 0x06000364 RID: 868 RVA: 0x0006EFE0 File Offset: 0x0006D1E0
	public short getTimeEff()
	{
		return (short)((long)this.timeEff - (GameCanvas.timeNow - this.timeBegin));
	}

	// Token: 0x06000365 RID: 869 RVA: 0x00009AA9 File Offset: 0x00007CA9
	public void SetXlech(int xlech)
	{
		this.dx = xlech;
	}

	// Token: 0x04000542 RID: 1346
	public const sbyte CHOANG = 1;

	// Token: 0x04000543 RID: 1347
	public const sbyte CHAY_MAU = 2;

	// Token: 0x04000544 RID: 1348
	public const sbyte GIAM_TAN_CONG = 3;

	// Token: 0x04000545 RID: 1349
	public const sbyte GIAM_PHONG_THU = 4;

	// Token: 0x04000546 RID: 1350
	public const sbyte HOA_MAT = 5;

	// Token: 0x04000547 RID: 1351
	public const sbyte DIEN_GIAT = 6;

	// Token: 0x04000548 RID: 1352
	public const sbyte LUA_CHAY = 7;

	// Token: 0x04000549 RID: 1353
	public const sbyte TROI_CHAN = 8;

	// Token: 0x0400054A RID: 1354
	public const sbyte HUT_MANA = 9;

	// Token: 0x0400054B RID: 1355
	public const sbyte TRUNG_DOC = 10;

	// Token: 0x0400054C RID: 1356
	public const sbyte EFF_BAT_TU = 11;

	// Token: 0x0400054D RID: 1357
	public const sbyte EFF_CRITICAL_LT = 12;

	// Token: 0x0400054E RID: 1358
	public const sbyte LUA_PHAN_DAU = -1;

	// Token: 0x0400054F RID: 1359
	public const sbyte LUA_TOAN_THAN = -2;

	// Token: 0x04000550 RID: 1360
	public const sbyte DEC_DAMAGE = 15;

	// Token: 0x04000551 RID: 1361
	public const sbyte DEC_POWER = 18;

	// Token: 0x04000552 RID: 1362
	private int dy;

	// Token: 0x04000553 RID: 1363
	private int dx;

	// Token: 0x04000554 RID: 1364
	private short timeEff;

	// Token: 0x04000555 RID: 1365
	private mVector vecEff = new mVector();

	// Token: 0x04000556 RID: 1366
	private string[] mtest = new string[]
	{
		"0 co gi",
		"choang",
		"Chay Mau",
		"Giam tan cong",
		"giam phong thu",
		"Hoa Mat",
		"Điện giật",
		"Lửa cháy",
		"Trói chân",
		"hut mana",
		"Trúng độc"
	};

	// Token: 0x04000557 RID: 1367
	private int[][] mPlayFrameVip;

	// Token: 0x04000558 RID: 1368
	private int[] mPlayframe;

	// Token: 0x04000559 RID: 1369
	private Point pMain;

	// Token: 0x0400055A RID: 1370
	private int tick;
}
