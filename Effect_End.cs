using System;

// Token: 0x0200002A RID: 42
public class Effect_End : MainEffect
{
	// Token: 0x060001A3 RID: 419 RVA: 0x0001EE80 File Offset: 0x0001D080
	public Effect_End(short type, sbyte subtype, int x, int y, int timeRe, sbyte Dir, MainObject objEff)
	{
		this.f = 0;
		this.typeEffect = (int)type;
		this.typeSub = subtype;
		this.x = x;
		this.y = y;
		this.Dir = Dir;
		this.timeRemove = timeRe;
		this.time = GameCanvas.timeNow;
		this.objMainEff = objEff;
		this.numNextFrame = 1;
		this.create_Effect();
	}

	// Token: 0x060001A4 RID: 420 RVA: 0x0001EF20 File Offset: 0x0001D120
	public Effect_End(short type, sbyte subtype, int x, int y, sbyte Dir, MainObject objEff)
	{
		this.f = 0;
		this.typeEffect = (int)type;
		this.typeSub = subtype;
		this.x = x;
		this.y = y;
		this.Dir = Dir;
		this.objMainEff = objEff;
		this.numNextFrame = 1;
		this.create_Effect();
	}

	// Token: 0x060001A5 RID: 421 RVA: 0x0001EFAC File Offset: 0x0001D1AC
	public Effect_End(short type, sbyte subtype, int x, int y, sbyte Dir)
	{
		this.f = 0;
		this.typeEffect = (int)type;
		this.typeSub = subtype;
		this.x = x;
		this.y = y;
		this.Dir = Dir;
		this.numNextFrame = 1;
		this.create_Effect();
	}

	// Token: 0x060001A6 RID: 422 RVA: 0x0001F030 File Offset: 0x0001D230
	public Effect_End(short type, sbyte subtype, int x, int y, int xTo, int yTo, sbyte Dir, MainObject objEff)
	{
		this.f = 0;
		this.typeEffect = (int)type;
		this.typeSub = subtype;
		this.x = x;
		this.y = y;
		this.toX = xTo;
		this.toY = yTo;
		this.Dir = Dir;
		this.objMainEff = objEff;
		this.numNextFrame = 1;
		this.create_Effect();
	}

	// Token: 0x060001A7 RID: 423 RVA: 0x0001F0CC File Offset: 0x0001D2CC
	public Effect_End(short type, MainObject objEff)
	{
		this.f = 0;
		this.typeEffect = (int)type;
		this.objMainEff = objEff;
	}

	// Token: 0x060001A8 RID: 424 RVA: 0x0001F12C File Offset: 0x0001D32C
	public Effect_End(short type, sbyte subtype, int x, int y, short Id, sbyte tem, sbyte Dir, MainObject objEff, int timeRe)
	{
		this.f = 0;
		this.typeEffect = (int)type;
		this.typeSub = subtype;
		this.x = x;
		this.y = y;
		this.Dir = Dir;
		this.objMainEff = objEff;
		this.objTo = MainObject.get_Object((int)Id, tem);
		bool flag = this.objTo == null;
		if (flag)
		{
			this.removeEff();
		}
		else
		{
			this.timeRemove = timeRe;
			this.time = GameCanvas.timeNow;
			this.toX = this.objTo.x;
			this.toY = this.objTo.y;
			base.setAngle();
			this.numNextFrame = 1;
			this.create_Effect();
		}
	}

	// Token: 0x060001A9 RID: 425 RVA: 0x0001F21C File Offset: 0x0001D41C
	public void create_Effect()
	{
		int xdich = this.toX - this.x;
		int ydich = this.toY - this.y;
		switch (this.typeEffect)
		{
		case 0:
			this.numNextFrame = 2;
			this.fRemove = 6;
			this.fraImgEff = new FrameImage(3, 30, 50);
			break;
		case 1:
			this.numNextFrame = 1;
			this.fRemove = 4;
			this.fraImgEff = new FrameImage(6, 38, 38);
			break;
		case 2:
			this.fraImgEff = new FrameImage(195, 40, 27, 40, 27);
			this.fraImgSubEff = new FrameImage(32, 45, 45, 34, 34);
			this.fRemove = 5;
			break;
		case 3:
			this.fraImgEff = new FrameImage(18, 20, 21);
			this.numNextFrame = 1;
			this.fRemove = 4;
			break;
		case 4:
		{
			this.fraImgEff = new FrameImage(19, 50, 54, 35, 38);
			bool flag = this.typeSub > 0;
			if (flag)
			{
				this.fraImgEff = new FrameImage(107, 50, 54, 38, 41);
				GameScreen.addEffectEnd(47, (int)(this.typeSub - 1), this.x, this.y, this.Dir, this.objMainEff);
			}
			this.numNextFrame = 1;
			this.fRemove = 5;
			break;
		}
		case 5:
			this.fraImgEff = new FrameImage(21, 20, 21);
			this.numNextFrame = 1;
			this.fRemove = 4;
			break;
		case 6:
		{
			this.vMax = 100;
			this.fraImgEff = new FrameImage(298, 24, 24, 6);
			bool flag2 = this.typeSub == 1 || this.typeSub == 2 || this.typeSub == 3;
			if (flag2)
			{
				bool flag3 = this.typeSub == 2 || this.typeSub == 3;
				if (flag3)
				{
					this.fraImgEff = new FrameImage(299, 26, 26, 2);
				}
				this.fraImgSubEff = new FrameImage(27, 24, 24);
				bool flag4 = this.typeSub == 3;
				if (flag4)
				{
					this.fraImgSub2Eff = new FrameImage(326, 26, 26, 3);
				}
			}
			bool flag5 = this.objMainEff != null;
			if (flag5)
			{
				this.indexEff_1 = (int)this.objMainEff.indexEff_1;
			}
			this.numNextFrame = 1;
			this.fRemove = CRes.random(12, 20);
			this.x *= 100;
			this.y *= 100;
			this.createEndBungmerang();
			break;
		}
		case 7:
		{
			this.objFireMain = this.objMainEff;
			this.fraImgEff = new FrameImage(12, 15, 15);
			this.vMax = 24;
			this.fRemove = 20;
			this.y -= 6;
			bool flag6 = this.Dir == 0;
			if (flag6)
			{
				this.x -= 20;
			}
			else
			{
				this.x += 20;
			}
			this.y = this.objFireMain.y - this.objFireMain.hOne / 2;
			break;
		}
		case 8:
			this.fraImgEff = new FrameImage(30, 38, 38);
			this.numNextFrame = 2;
			this.fRemove = 6;
			break;
		case 9:
			this.fraImgEff = new FrameImage(34, 62, 64, 45, 46);
			this.numNextFrame = 2;
			this.fRemove = 6;
			break;
		case 10:
			this.fraImgEff = new FrameImage(15 + CRes.random(3), 55, 55, 40, 40);
			this.numNextFrame = 2;
			this.fRemove = 6;
			break;
		case 11:
		{
			this.typeSub = (sbyte)(14 + CRes.random(2) * 2);
			Point point = new Point();
			point.x = this.x;
			point.y = this.y;
			point.fRe = 6;
			bool flag7 = this.typeSub == 14;
			if (flag7)
			{
				point.fraImgEff = new FrameImage((int)this.typeSub, 55, 55);
			}
			else
			{
				point.fraImgEff = new FrameImage((int)this.typeSub, 55, 55, 40, 40);
			}
			this.VecEff.addElement(point);
			this.numNextFrame = 2;
			this.fRemove = 6;
			GameScreen.addEffectEnd(93, 0, this.x, this.y, this.Dir, this.objMainEff);
			break;
		}
		case 12:
		{
			this.fraImgEff = new FrameImage(36, 28, 28);
			bool flag8 = this.typeSub == 1;
			if (flag8)
			{
				this.fraImgEff = new FrameImage(106, 28, 28);
				GameScreen.addEffectEnd(36, 0, this.x, this.y, this.Dir, this.objMainEff);
			}
			this.numNextFrame = 2;
			this.fRemove = 6;
			break;
		}
		case 13:
		{
			bool flag9 = this.objTo != null;
			if (flag9)
			{
				this.toX = this.objTo.x;
				this.toY = this.objTo.y - this.objTo.hOne / 2;
			}
			xdich = this.toX - this.x;
			ydich = this.toY - this.y;
			bool flag10 = this.typeSub == 3 || this.typeSub == 4 || this.typeSub == 5;
			if (flag10)
			{
				this.fraImgSubEff = new FrameImage(69, 14, 48);
				this.fraImgSub2Eff = new FrameImage(27, 24, 32);
				this.fraImgEff = new FrameImage(275, 35, 25);
				bool flag11 = this.typeSub == 4 || this.typeSub == 5;
				if (flag11)
				{
					this.fraImgEff = new FrameImage(318, 35, 25);
				}
				bool flag12 = this.typeSub == 5;
				if (flag12)
				{
					this.fraImgSubEff = new FrameImage(410, 3);
				}
			}
			else
			{
				bool flag13 = this.typeSub == 1 || this.typeSub == 2;
				if (flag13)
				{
					this.fraImgSubEff = new FrameImage(69, 14, 48);
					bool flag14 = this.typeSub == 2;
					if (flag14)
					{
						this.fraImgSub2Eff = new FrameImage(27, 24, 32);
					}
				}
				this.fraImgEff = new FrameImage(44, 25, 15);
			}
			this.numNextFrame = 1;
			this.vMax = 12;
			base.create_Speed(xdich, ydich, null);
			this.randomf = CRes.random(this.fraImgEff.nFrame);
			break;
		}
		case 14:
			this.fraImgEff = new FrameImage(42, 53, 48);
			this.vy = 4;
			this.fRemove = 4;
			this.numNextFrame = 2;
			break;
		case 15:
			this.objFireMain = this.objMainEff;
			this.fRemove = 15;
			break;
		case 16:
		{
			this.fRemove = 3;
			bool flag15 = this.typeSub < 0;
			if (flag15)
			{
				this.fraImgEff = new FrameImage(301, 80, 32, 3);
			}
			else
			{
				this.fraImgEff = new FrameImage(300, 80, 25, 3);
			}
			bool flag16 = this.objMainEff != null;
			if (flag16)
			{
				this.indexEff_1 = (int)this.objMainEff.indexEff_1;
			}
			this.numNextFrame = 2;
			this.vx = -4;
			bool flag17 = this.Dir == 2;
			if (flag17)
			{
				this.vx = 4;
			}
			break;
		}
		case 17:
			this.fraImgEff = new FrameImage(39, 53, 28);
			this.fRemove = (int)this.typeSub;
			this.levelPaint = -1;
			break;
		case 18:
			this.fraImgEff = new FrameImage(33, 62, 42, 40, 27);
			this.fRemove = 10;
			this.numNextFrame = 2;
			this.vy = -2;
			break;
		case 19:
		{
			bool flag18 = this.typeSub == 0;
			if (flag18)
			{
				this.fraImgEff = new FrameImage(14, 55, 55);
				this.fraImgSubEff = new FrameImage(15, 55, 55, 40, 40);
			}
			else
			{
				bool flag19 = this.typeSub == 1;
				if (flag19)
				{
					this.fraImgEff = new FrameImage(16, 55, 55, 40, 40);
					this.fraImgSubEff = new FrameImage(17, 55, 55, 40, 40);
				}
			}
			this.fRemove = 8;
			this.numNextFrame = 2;
			break;
		}
		case 20:
			this.fraImgEff = new FrameImage(49, 70, 70, 50, 50);
			this.numNextFrame = 2;
			this.fRemove = 6;
			this.randomf = CRes.random(8);
			break;
		case 21:
			this.createXuyenGiap();
			break;
		case 22:
			this.createHut_MP_HP();
			break;
		case 23:
			this.vMax = 14;
			this.createPhanDamage();
			base.create_Speed(xdich, ydich, null);
			break;
		case 24:
			this.createFocustouch();
			break;
		case 25:
		{
			bool flag20 = this.typeSub == 4;
			if (flag20)
			{
				this.fraImgEff = new FrameImage(281, 29, 50);
			}
			else
			{
				this.fraImgEff = new FrameImage(68, 28, 44);
				bool flag21 = this.typeSub == 1 || this.typeSub == 2 || this.typeSub == 3;
				if (flag21)
				{
					this.fraImgSubEff = new FrameImage(69, 14, 48);
					bool flag22 = this.typeSub == 2 || this.typeSub == 3;
					if (flag22)
					{
						this.fraImgSub2Eff = new FrameImage(27, 24, 32);
					}
				}
			}
			this.x1000 = this.x - 5;
			bool flag23 = this.Dir == 0;
			if (flag23)
			{
				this.x1000 = this.x + 5;
			}
			this.numNextFrame = 2;
			this.fRemove = 6;
			bool flag24 = this.typeSub == 3;
			if (flag24)
			{
				this.fRemove = 4;
			}
			break;
		}
		case 26:
		{
			bool flag25 = this.typeSub == 2;
			if (flag25)
			{
				this.fraImgEff = new FrameImage(278, 70, 70);
			}
			else
			{
				bool flag26 = this.typeSub == 3;
				if (flag26)
				{
					this.fraImgEff = new FrameImage(279, 70, 70);
				}
				else
				{
					bool flag27 = this.typeSub == 4;
					if (flag27)
					{
						this.fraImgEff = new FrameImage(420, 70, 70);
					}
					else
					{
						this.fraImgEff = new FrameImage(70, 52, 60, 36, 41);
					}
				}
			}
			this.numNextFrame = 1;
			this.fRemove = 6;
			this.mPlayFrame = new int[]
			{
				0,
				1,
				2,
				0,
				3
			};
			bool flag28 = this.typeSub == 1;
			if (flag28)
			{
				this.fRemove = 4;
				int[] array = new int[3];
				array[1] = 2;
				this.mPlayFrame = array;
			}
			break;
		}
		case 27:
		{
			bool flag29 = this.objTo != null;
			if (flag29)
			{
				this.toX = this.objTo.x;
				this.toY = this.objTo.y;
			}
			xdich = this.toX - this.x;
			ydich = this.toY - this.y;
			this.fraImgEff = new FrameImage(72, 32, 60);
			this.fraImgSubEff = new FrameImage(27, 24, 32);
			this.numNextFrame = 2;
			this.vMax = 12;
			base.create_Speed(xdich, ydich, null);
			break;
		}
		case 28:
		{
			this.numNextFrame = 1;
			this.fraImgEff = new FrameImage(9, 63, 21);
			this.fRemove = 24;
			this.vy = -3;
			bool flag30 = this.objFireMain != null;
			if (flag30)
			{
				this.x = this.objFireMain.x;
				this.y = this.objFireMain.y - this.objFireMain.hOne / 2;
			}
			GameScreen.addEffectEnd(50, 0, this.x, this.y, this.Dir, this.objMainEff);
			break;
		}
		case 29:
			this.x1000 = this.x;
			this.y1000 = this.y;
			this.fRemove = 20;
			this.fraImgEff = new FrameImage(74, 60, 74);
			this.fraImgSubEff = new FrameImage(75, 82, 25);
			this.fraImgSub2Eff = new FrameImage(18, 20, 21);
			break;
		case 30:
			this.indexColorStar = (int)this.typeSub;
			this.x1000 = this.x * 1000;
			this.y1000 = this.y * 1000;
			this.fRemove = CRes.random(4, 6);
			this.vMax = 5;
			this.xline = 10;
			this.yline = 20;
			this.maxsize = 4;
			this.create_Star_Line_In(this.vMax, this.xline, this.yline, 0, this.maxsize);
			break;
		case 31:
			this.createCharTeleport();
			break;
		case 32:
			this.createCharTeleportNew();
			break;
		case 33:
			this.fRemove = 8;
			this.objFireMain = this.objMainEff;
			break;
		case 34:
			this.fraImgEff = new FrameImage(104, 30, 30);
			this.numNextFrame = 2;
			this.fRemove = 6;
			break;
		case 35:
			this.fraImgEff = new FrameImage(89, 28, 44);
			this.numNextFrame = 2;
			this.fRemove = 6;
			break;
		case 36:
		{
			bool flag31 = this.typeSub == 1;
			if (flag31)
			{
				this.fraImgEff = new FrameImage(283, 22, 28);
			}
			else
			{
				this.fraImgEff = new FrameImage(78, 22, 28);
			}
			this.vx = CRes.random_Am_0(2);
			this.vy = -3;
			this.fRemove = CRes.random(7, 12);
			break;
		}
		case 37:
		{
			this.x1000 = this.x;
			this.y1000 = this.y;
			this.fRemove = 20;
			this.fraImgEff = new FrameImage(69, 14, 48);
			bool flag32 = this.typeSub == 1;
			if (flag32)
			{
				this.fraImgSubEff = new FrameImage(103, 35, 19, 35, 19);
				this.fraImgSub2Eff = new FrameImage(18, 20, 21);
			}
			else
			{
				this.fraImgSubEff = new FrameImage(102, 35, 19);
			}
			break;
		}
		case 38:
		{
			this.fRemove = 5;
			bool flag33 = this.typeSub == 1;
			if (flag33)
			{
				this.fraImgEff = new FrameImage(104, 30, 30);
			}
			else
			{
				bool flag34 = this.typeSub == 2;
				if (flag34)
				{
					this.fraImgEff = new FrameImage(243, 36, 36);
				}
				else
				{
					bool flag35 = this.typeSub == 3;
					if (flag35)
					{
						this.fraImgEff = new FrameImage(82, 30, 30);
					}
					else
					{
						this.fraImgEff = new FrameImage(82, 30, 30);
					}
				}
			}
			break;
		}
		case 39:
		{
			this.fRemove = 8;
			bool flag36 = this.objTo != null;
			if (flag36)
			{
				this.x = this.objTo.x;
				this.y = this.objTo.y - this.objTo.hOne - 20;
			}
			bool flag37 = this.typeSub == 3;
			if (flag37)
			{
				this.fraImgEff = new FrameImage(25, 80, 40);
			}
			else
			{
				bool flag38 = this.typeSub == 2;
				if (flag38)
				{
					this.fraImgEff = new FrameImage(328, 38, 27);
				}
				else
				{
					this.fraImgEff = new FrameImage(95, 32, 27);
				}
			}
			break;
		}
		case 40:
		{
			this.fRemove = 6;
			bool flag39 = this.objTo != null;
			if (flag39)
			{
				this.x = this.objTo.x;
				this.y = this.objTo.y - this.objTo.hOne - 20;
			}
			bool flag40 = this.typeSub == 2;
			if (flag40)
			{
				this.fraImgEff = new FrameImage(328, 38, 27);
				this.fraImgSubEff = new FrameImage(329, 56, 31);
			}
			else
			{
				this.fraImgEff = new FrameImage(95, 32, 27);
				this.fraImgSubEff = new FrameImage(97, 56, 31);
			}
			this.fraImgSub2Eff = new FrameImage(96, 28, 79, 1);
			break;
		}
		case 41:
			this.fRemove = 4;
			this.fraImgEff = new FrameImage(93, 64, 48, 41, 31);
			break;
		case 42:
			this.fRemove = 4;
			this.fraImgEff = new FrameImage(98, 78, 70, 56, 50);
			break;
		case 44:
			this.fRemove = 9;
			this.objFireMain = this.objMainEff;
			break;
		case 45:
			this.levelPaint = -1;
			this.fraImgEff = new FrameImage(168, 112, 69, 89, 55);
			this.fRemove = 8;
			this.numNextFrame = 2;
			break;
		case 46:
		case 159:
			this.createClassNami();
			break;
		case 47:
			this.create_Sanji6();
			break;
		case 48:
			this.createUssop9();
			break;
		case 49:
			this.createUssop10();
			break;
		case 50:
			this.createUssop11();
			break;
		case 51:
		{
			this.objFireMain = this.objMainEff;
			this.fRemove = 16;
			bool flag41 = this.Dir == 0;
			if (flag41)
			{
				this.x -= 20;
			}
			else
			{
				this.x += 20;
			}
			this.y = this.objFireMain.y - this.objFireMain.hOne / 2;
			this.fraImgSubEff = new FrameImage(23, 24, 24);
			this.fraImgEff = new FrameImage(27, 24, 24);
			break;
		}
		case 52:
			this.fraImgEff = new FrameImage(118, 62, 64, 47, 48);
			this.fRemove = 8;
			this.numNextFrame = 2;
			GameScreen.addEffectEnd(63, 0, this.x, this.y, this.Dir, this.objMainEff);
			break;
		case 53:
			this.fraImgEff = new FrameImage(121, 32, 32);
			this.fRemove = 12;
			this.numNextFrame = 2;
			break;
		case 54:
			this.createEND_Lu_S1_Final();
			break;
		case 55:
		{
			this.fraImgEff = new FrameImage(100, 15, 20);
			this.fRemove = 10;
			this.numNextFrame = 2;
			bool flag42 = this.objTo != null;
			if (flag42)
			{
				this.x = this.objTo.x;
				this.y = this.objTo.y;
			}
			break;
		}
		case 56:
		{
			this.fraImgEff = new FrameImage(8, 40, 47, 40, 47);
			this.fRemove = 4;
			bool flag43 = this.objTo != null && this.objTo.Action != 4;
			if (flag43)
			{
				this.objTo.isTanHinh = true;
			}
			break;
		}
		case 57:
			this.fraImgEff = new FrameImage(107, 50, 54, 38, 41);
			this.fRemove = 10;
			this.numNextFrame = 2;
			break;
		case 58:
			this.fraImgEff = new FrameImage(138, 62, 64, 47, 48);
			this.fRemove = 8;
			this.numNextFrame = 2;
			GameScreen.addEffectEnd(63, 0, this.x, this.y, this.Dir, this.objMainEff);
			break;
		case 59:
			this.createRock();
			break;
		case 60:
			this.createHachi2();
			break;
		case 61:
			this.numNextFrame = 1;
			this.fRemove = 4;
			this.fraImgEff = new FrameImage(143, 38, 38);
			break;
		case 62:
		{
			this.levelPaint = -1;
			bool flag44 = LoadMap.idTile == 2;
			if (flag44)
			{
				this.fraImgEff = new FrameImage(154, 20, 15);
			}
			else
			{
				this.fraImgEff = new FrameImage(151, 20, 15);
			}
			this.fRemove = CRes.abs(this.toX - this.x) / 10 + 20;
			bool flag45 = this.fRemove % 2 == 0;
			if (flag45)
			{
				this.fRemove++;
			}
			this.vx = 10;
			bool flag46 = this.toX < this.x;
			if (flag46)
			{
				this.vx = -10;
			}
			break;
		}
		case 63:
		{
			this.levelPaint = -1;
			bool flag47 = this.typeSub <= 2;
			if (flag47)
			{
				this.frame = CRes.random(3);
			}
			else
			{
				this.frame = (int)this.typeSub;
			}
			this.fraImgEff = new FrameImage(245, 25, 21, 3);
			this.fRemove = CRes.random(30, 50);
			break;
		}
		case 64:
		{
			bool flag48 = this.typeSub == 1;
			if (flag48)
			{
				this.fraImgEff = new FrameImage(279, 70, 70);
			}
			else
			{
				bool flag49 = this.typeSub == 2;
				if (flag49)
				{
					this.fraImgEff = new FrameImage(420, 70, 70);
				}
				else
				{
					this.fraImgEff = new FrameImage(169, 52, 60, 40, 46);
				}
			}
			this.numNextFrame = 1;
			this.fRemove = 4;
			break;
		}
		case 65:
			this.fraImgEff = new FrameImage(171, 153, 84, 100, 54);
			this.numNextFrame = 2;
			this.fRemove = 8;
			this.levelPaint = -1;
			break;
		case 66:
			this.levelPaint = -1;
			this.fraImgEff = new FrameImage(226, 13, 11, 3);
			this.fRemove = CRes.random(15, 20);
			break;
		case 68:
			this.fraImgEff = new FrameImage(177, 48, 56, 40, 47);
			this.fRemove = 8;
			this.numNextFrame = 2;
			GameScreen.addEffectEnd(59, 0, this.x, this.y - 10, this.Dir, this.objMainEff);
			break;
		case 69:
			this.timeBegin = GameCanvas.timeNow;
			this.createUrgot_4(2);
			this.timeEnd = 3000;
			break;
		case 70:
			this.fRemove = 40;
			this.createUrgot_4(5);
			break;
		case 71:
			this.fraImgEff = new FrameImage(190, 30, 30);
			this.fRemove = 6;
			this.numNextFrame = 2;
			break;
		case 72:
		{
			this.fRemove = 3;
			this.fraImgEff = new FrameImage(191, 60, 17);
			this.numNextFrame = 2;
			this.vx = -3;
			bool flag50 = this.Dir == 2;
			if (flag50)
			{
				this.vx = 3;
			}
			break;
		}
		case 73:
			this.vMax = 2;
			this.fRemove = CRes.abs(this.toX - this.x) / this.vMax + 1;
			break;
		case 74:
			this.vMax = 2;
			this.fRemove = CRes.abs(this.toX - this.x) / this.vMax + 1;
			this.levelPaint = -1;
			break;
		case 75:
			this.vMax = 5;
			this.fraImgEff = new FrameImage(192, 25, 25);
			this.fraImgSubEff = new FrameImage(51, 9, 9);
			this.fraImgSub2Eff = new FrameImage(52, 5, 5);
			xdich = this.toX - this.x;
			ydich = this.toY - this.y;
			base.create_Speed(xdich, ydich, null);
			break;
		case 76:
			this.create_Upgrade_Thanh_Cong();
			break;
		case 77:
			this.numNextFrame = 2;
			this.fraImgEff = new FrameImage(85, 34, 34, 28, 28);
			this.fRemove = 12;
			break;
		case 78:
			this.vMax = 8;
			this.fraImgEff = new FrameImage(192, 25, 25);
			this.fraImgSubEff = new FrameImage(51, 9, 9);
			this.fraImgSub2Eff = new FrameImage(52, 5, 5);
			xdich = this.toX - this.x;
			ydich = this.toY - this.y;
			base.create_Speed(xdich, ydich, null);
			break;
		case 79:
		{
			bool flag51 = AvMain.fraLevelUp == null;
			if (flag51)
			{
				AvMain.fraLevelUp = new FrameImage(mImage.createImage("/interface/levelup.png"), 115, 35);
			}
			this.fraImgEff = AvMain.fraLevelUp;
			this.vy = -3;
			bool flag52 = this.typeSub % 2 == 1;
			if (flag52)
			{
				this.vy = -2;
			}
			this.fRemove = 18;
			this.frame = (int)this.typeSub;
			break;
		}
		case 80:
			this.fraImgEff = new FrameImage(11, 40, 50);
			this.fRemove = 4;
			this.numNextFrame = 2;
			break;
		case 81:
			this.fraImgEff = new FrameImage(106, 28, 28);
			this.fRemove = 6;
			this.numNextFrame = 2;
			break;
		case 82:
			this.fraImgEff = new FrameImage(198, 40, 40);
			this.fraImgSubEff = new FrameImage(85, 34, 34, 28, 28);
			this.fRemove = 6;
			this.numNextFrame = 2;
			break;
		case 83:
			this.createRevice();
			break;
		case 84:
			this.createGet_Up();
			break;
		case 85:
			this.indexColorStar = (int)this.typeSub;
			this.x1000 = this.x * 1000;
			this.y1000 = this.y * 1000;
			this.fRemove = CRes.random(4, 6);
			this.vMax = 5;
			this.xline = 10;
			this.yline = 20;
			this.maxsize = 4;
			this.create_Star_Line_In(this.vMax, this.xline, this.yline, 10, this.maxsize);
			this.fraImgEff = new FrameImage(51, 9, 9);
			this.fraImgSubEff = new FrameImage(52, 5, 5);
			break;
		case 86:
			this.numNextFrame = 2;
			this.fRemove = 6;
			this.fraImgEff = new FrameImage(84, 64, 40);
			break;
		case 87:
			this.vMax = 100;
			this.fraImgEff = new FrameImage(80, 30, 15);
			this.numNextFrame = 2;
			this.fRemove = CRes.random(6, 12);
			this.x *= 100;
			this.y *= 100;
			this.createEndBungmerang();
			break;
		case 88:
			this.fraImgEff = new FrameImage(46, 70, 100, 49, 70);
			this.mPlayFrame = new int[]
			{
				0,
				0,
				0,
				1,
				1,
				1,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				3,
				3,
				3,
				4,
				4,
				4,
				4,
				4
			};
			this.fRemove = this.mPlayFrame.Length;
			GameScreen.addEffectEnd(17, CRes.random(20, 30), this.x, this.y, this.Dir, this.objMainEff);
			break;
		case 89:
			this.fraImgEff = new FrameImage(34, 62, 64, 45, 46);
			this.fRemove = 6;
			this.numNextFrame = 2;
			break;
		case 90:
		{
			bool flag53 = this.typeSub == 1;
			if (flag53)
			{
				this.fraImgEff = new FrameImage(195, 40, 27, 40, 27);
			}
			else
			{
				this.fraImgEff = new FrameImage(26, 40, 20);
			}
			this.numNextFrame = 2;
			this.fRemove = 4;
			break;
		}
		case 91:
			this.fRemove = 4;
			this.mPlayFrame = new int[]
			{
				4,
				3,
				2,
				0
			};
			this.fraImgEff = new FrameImage(121, 32, 32);
			break;
		case 92:
			this.fRemove = 4;
			this.mPlayFrame = new int[]
			{
				4,
				4,
				5,
				5
			};
			this.fraImgEff = new FrameImage(85, 34, 34, 28, 28);
			break;
		case 93:
			this.createEffectSkill1();
			break;
		case 95:
		{
			int num = CRes.random(5, 8);
			for (int i = 0; i < num; i++)
			{
				Point point2 = new Point(CRes.random_Am_0(20), CRes.random(10));
				point2.y2 = point2.y;
				point2.vy = -CRes.random(2, 4);
				this.VecEff.addElement(point2);
			}
			break;
		}
		case 96:
			this.createClassUssop();
			break;
		case 97:
			this.createClassZoro();
			break;
		case 98:
			this.fraImgEff = new FrameImage(92, 64, 126, 45, 89, 1);
			this.fraImgSubEff = new FrameImage(99, 32, 32);
			this.fRemove = 16;
			break;
		case 99:
			this.fraImgEff = new FrameImage(201, 64, 50, 45, 35);
			this.fraImgSubEff = new FrameImage(202, 40, 92, 30, 69, 1);
			this.fraImgSub2Eff = new FrameImage(99, 32, 32);
			this.fRemove = 12;
			break;
		case 100:
			this.fraImgEff = new FrameImage(144, 37, 55);
			this.numNextFrame = 3;
			this.fRemove = 6;
			break;
		case 101:
			this.createChopper();
			break;
		case 102:
			this.createKuromarimo();
			break;
		case 103:
			this.createMr3_1();
			break;
		case 104:
			this.createLittleHpBoss();
			break;
		case 105:
			this.createLittleDamBoss();
			break;
		case 106:
			this.fRemove = 10;
			this.fraImgEff = new FrameImage(101, 40, 47);
			break;
		case 107:
			this.createRock();
			break;
		case 108:
		{
			bool flag54 = GameCanvas.isLowGraOrWP_PvP();
			if (flag54)
			{
				this.isStop = true;
			}
			this.createPartical();
			break;
		}
		case 109:
		{
			bool flag55 = GameCanvas.isLowGraOrWP_PvP();
			if (flag55)
			{
				this.isStop = true;
			}
			this.fraImgEff = new FrameImage(223, 19, 15);
			this.numNextFrame = 2;
			this.fRemove = this.fraImgEff.nFrame * (int)this.numNextFrame;
			this.y -= this.fraImgEff.frameHeight;
			bool flag56 = this.Dir == 2;
			if (flag56)
			{
				this.x -= this.fraImgEff.frameWidth;
			}
			break;
		}
		case 110:
		case 115:
		{
			bool flag57 = GameCanvas.isLowGraOrWP_PvP();
			if (flag57)
			{
				this.isStop = true;
			}
			this.createRock();
			break;
		}
		case 111:
			this.fRemove = 60;
			this.fraImgEff = new FrameImage(238, 30, 73);
			this.fraImgSubEff = new FrameImage(67, 3, 25, 1);
			this.fraImgSub2Eff = new FrameImage(239, 38, 22, 38, 22);
			for (int j = 0; j < 3; j++)
			{
				Point point3 = new Point(CRes.random_Am_0(20), -5 + CRes.random(10));
				point3.vy = -CRes.random(12, 20);
				point3.frame = CRes.random(this.fraImgSubEff.nFrame);
				this.VecEff.addElement(point3);
			}
			break;
		case 112:
			this.levelPaint = -1;
			this.fraImgEff = new FrameImage(246, 49, 21, 35, 15, 4);
			this.fRemove = 40;
			break;
		case 113:
		{
			this.fraImgEff = new FrameImage(252, 62, 64, 40, 41);
			this.fraImgSubEff = new FrameImage(174, 40, 40, 4);
			this.vMax = 12;
			bool flag58 = this.typeSub == 2;
			if (flag58)
			{
				this.vMax = 14;
			}
			this.fRemove = 10;
			this.goc_Arc = CRes.random(90);
			break;
		}
		case 114:
		{
			this.vx = 3;
			bool flag59 = this.Dir == 0;
			if (flag59)
			{
				this.vx = -3;
			}
			this.fraImgEff = new FrameImage(259, 30, 14);
			this.fRemove = 4;
			this.numNextFrame = 2;
			break;
		}
		case 116:
		{
			bool flag60 = this.typeSub == 1;
			if (flag60)
			{
				this.levelPaint = -1;
			}
			this.fraImgEff = new FrameImage(268, 24, 32);
			this.fRemove = 20;
			break;
		}
		case 117:
		{
			this.levelPaint = -1;
			this.fraImgEff = new FrameImage(269, 24, 10);
			bool flag61 = CRes.random(3) == 0;
			if (flag61)
			{
				this.frame = 1;
			}
			this.fRemove = CRes.random(16, 30);
			break;
		}
		case 118:
			this.fraImgEff = new FrameImage(144, 37, 55);
			this.numNextFrame = 3;
			this.fRemove = 6;
			break;
		case 119:
			this.createEndLuS1L4();
			break;
		case 120:
			this.createUssopS3_Lv4();
			break;
		case 121:
			this.mPlayFrame = new int[]
			{
				15328484,
				16118000,
				16578808,
				16777215,
				16777215
			};
			this.fRemove = 16;
			break;
		case 122:
			this.fRemove = 10;
			this.numNextFrame = 2;
			this.fraImgEff = new FrameImage(289, 60, 60, 3);
			break;
		case 123:
		{
			this.fRemove = 8;
			this.numNextFrame = 2;
			this.fraImgEff = new FrameImage(290, 60, 60, 4);
			bool flag62 = this.typeSub > 3;
			if (flag62)
			{
				this.typeSub = 3;
			}
			break;
		}
		case 124:
			this.fraImgEff = new FrameImage(246, 49, 21, 4);
			this.mPlayFrame = new int[]
			{
				3,
				1,
				0,
				5,
				5,
				5,
				5,
				5,
				5,
				5,
				5,
				5,
				5,
				5,
				5,
				5,
				5,
				5,
				5,
				5,
				5,
				5,
				5,
				5,
				0,
				1,
				2,
				3
			};
			this.fRemove = this.mPlayFrame.Length;
			this.levelPaint = -1;
			break;
		case 125:
			this.mPlayFrame = new int[]
			{
				0,
				1,
				2,
				3,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				3,
				2,
				1,
				0
			};
			this.fRemove = this.mPlayFrame.Length;
			this.fraImgEff = new FrameImage(294, 57, 57, 3);
			break;
		case 126:
			this.create_Poke_Ok();
			break;
		case 127:
			this.create_Poke_Begin();
			break;
		case 128:
			this.create_Poke_Fail();
			break;
		case 129:
			this.create_Tru_Be();
			break;
		case 130:
			this.createLOL_Tru_Tren();
			break;
		case 131:
			this.fraImgEff = new FrameImage(306, 38, 22, 3);
			break;
		case 132:
		{
			this.fraImgEff = new FrameImage(309, 78, 70, 4);
			bool flag63 = this.typeSub == 0;
			if (flag63)
			{
				this.fRemove = 4;
				this.numNextFrame = 1;
				this.vx = -6;
				bool flag64 = this.Dir == 2;
				if (flag64)
				{
					this.vx = 6;
				}
			}
			else
			{
				this.fRemove = 16;
				this.numNextFrame = 1;
				this.vx = -16;
				bool flag65 = this.Dir == 2;
				if (flag65)
				{
					this.vx = 16;
				}
			}
			break;
		}
		case 133:
		{
			bool flag66 = this.typeSub == 1;
			if (flag66)
			{
				this.fraImgEff = new FrameImage(314, 96, 39);
			}
			else
			{
				this.fraImgEff = new FrameImage(312, 121, 77);
			}
			this.fRemove = 30;
			this.levelPaint = -1;
			break;
		}
		case 134:
			this.fraImgEff = new FrameImage(314, 96, 39);
			this.fraImgSubEff = new FrameImage(315, 77, 54, 3);
			this.fRemove = 30;
			this.levelPaint = -1;
			break;
		case 135:
		{
			this.fraImgEff = new FrameImage(320, 62, 44);
			this.fRemove = 4;
			this.numNextFrame = 2;
			this.vx = -20;
			bool flag67 = this.Dir == 2;
			if (flag67)
			{
				this.vx = 20;
			}
			break;
		}
		case 136:
			this.fraImgEff = new FrameImage(321, 52, 70, 3);
			this.numNextFrame = 1;
			this.mPlayFrameVip = new int[][]
			{
				new int[1],
				new int[]
				{
					3
				},
				new int[0],
				new int[0],
				new int[0],
				new int[]
				{
					1
				},
				new int[]
				{
					4
				},
				new int[0],
				new int[0],
				new int[0],
				new int[]
				{
					2
				},
				new int[]
				{
					5
				},
				new int[0],
				new int[]
				{
					3,
					2,
					1
				},
				new int[]
				{
					0,
					2,
					4
				},
				new int[]
				{
					3,
					5,
					4
				},
				new int[0],
				new int[]
				{
					3,
					2,
					1
				},
				new int[]
				{
					0,
					2,
					4
				},
				new int[]
				{
					3,
					5,
					4
				}
			};
			this.fRemove = this.mPlayFrameVip.Length;
			break;
		case 137:
			this.createZoro_S3();
			break;
		case 138:
			this.fRemove = 5;
			this.fraImgEff = new FrameImage(243, 36, 36, 4);
			break;
		case 139:
		{
			bool flag68 = this.typeSub == 1;
			if (flag68)
			{
				this.fraImgEff = new FrameImage(407, 52, 199, 1);
			}
			else
			{
				this.fraImgEff = new FrameImage(327, 38, 198, 1);
			}
			bool flag69 = this.typeSub == 1;
			if (flag69)
			{
				this.mPlayFrame = new int[]
				{
					0,
					0,
					-1,
					1,
					-1,
					0,
					0,
					-1,
					1,
					1
				};
			}
			else
			{
				this.mPlayFrame = new int[]
				{
					0,
					0,
					-1,
					1,
					-1,
					2,
					2,
					-1,
					3
				};
			}
			this.fRemove = this.mPlayFrame.Length;
			break;
		}
		case 140:
		case 167:
			this.create_US_S2_L5();
			break;
		case 141:
			this.frameSuper = this.typeSub;
			this.fraImgEff = new FrameImage(335, 80, 80, 2, this.frameSuper);
			this.fRemove = 8;
			this.numNextFrame = 2;
			break;
		case 142:
		{
			this.fraImgEff = new FrameImage(46, 70, 100, 49, 70);
			bool flag70 = this.typeSub == 1;
			if (flag70)
			{
				this.mPlayFrame = new int[]
				{
					0,
					0,
					1,
					1,
					1,
					1,
					1,
					1,
					1,
					1,
					1,
					1,
					1,
					4,
					4
				};
			}
			else
			{
				this.mPlayFrame = new int[]
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
					4,
					4
				};
			}
			this.fRemove = this.mPlayFrame.Length;
			GameScreen.addEffectEnd(17, CRes.random(20, 30), this.x, this.y, this.Dir, this.objMainEff);
			break;
		}
		case 143:
		{
			bool flag71 = this.typeSub >= 0 && this.typeSub <= 11;
			if (flag71)
			{
				this.fraImgEff = new FrameImage(338 + (int)this.typeSub, 1);
				this.fRemove = 30;
				this.vy = -9 + CRes.random_Am_0(3);
			}
			else
			{
				this.isStop = true;
			}
			break;
		}
		case 144:
			this.indexColorStar = (int)this.typeSub;
			this.levelPaint = -1;
			this.x1000 = this.x * 1000;
			this.y1000 = this.y * 1000;
			this.fRemove = CRes.random(4, 6);
			this.vMax = 7;
			this.xline = 15;
			this.yline = 20;
			this.maxsize = 8;
			this.create_Star_Line_In(this.vMax, this.xline, this.yline, 0, this.maxsize);
			break;
		case 145:
			this.indexColorStar = (int)this.typeSub;
			this.levelPaint = -1;
			this.x1000 = this.x * 1000;
			this.y1000 = this.y * 1000;
			this.fRemove = CRes.random(4, 6);
			this.vMax = 5;
			this.xline = 10;
			this.yline = 15;
			this.maxsize = 4;
			this.create_Star_Line_In(this.vMax, this.xline, this.yline, 0, this.maxsize);
			break;
		case 146:
		{
			this.fraImgEff = new FrameImage(85, 34, 34, 28, 28);
			int num2 = 30;
			for (int k = 0; k < 4; k++)
			{
				Point point4 = new Point(this.x * 1000, this.y * 1000);
				point4.vx = CRes.getcos(num2) * 7;
				point4.vy = CRes.getsin(num2) * 7;
				this.VecEff.addElement(point4);
				num2 = ((k != 0 && k != 2) ? (num2 + 60) : (num2 + 120));
			}
			num2 = 0;
			for (int l = 0; l < 4; l++)
			{
				Point point5 = new Point(this.x * 1000, this.y * 1000);
				point5.vx = CRes.getcos(num2) * 12;
				point5.vy = CRes.getsin(num2) * 12;
				this.VecEff.addElement(point5);
				num2 += 90;
			}
			this.fRemove = 10;
			break;
		}
		case 147:
			this.create_Lucci_L2();
			break;
		case 148:
			this.fraImgEff = new FrameImage(312, 121, 77);
			this.fRemove = 20;
			this.levelPaint = -1;
			break;
		case 149:
			this.fraImgEff = new FrameImage(327, 38, 198, 1);
			this.fRemove = 4;
			this.numNextFrame = 1;
			this.y = this.objTo.y;
			break;
		case 150:
			this.fraImgEff = new FrameImage(367, 35, 14);
			this.fRemove = 1000;
			this.numNextFrame = 2;
			this.y = this.objTo.y - this.objTo.hOne;
			break;
		case 151:
			this.fraImgEff = new FrameImage(87, 35, 35, 5);
			this.fRemove = 5;
			this.numNextFrame = 1;
			this.y = this.objTo.y - this.objTo.hOne / 2;
			break;
		case 152:
			this.fraImgEff = new FrameImage(368, 56, 92);
			this.fRemove = 1000;
			this.mPlayFrame = new int[]
			{
				-1,
				-1,
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1
			};
			this.y = this.objTo.y + 4;
			break;
		case 153:
		{
			this.fraImgEff = new FrameImage(369, 37, 59);
			this.fraImgSubEff = new FrameImage(370, 14, 16);
			this.fraImgSub2Eff = new FrameImage(221, 5, 5, 4);
			this.fRemove = 250;
			this.objTo.Action = 2;
			MainSkill skill = new MainSkill(9999, 256);
			this.objTo.plashNow = new Plash(skill, this.objTo, null);
			this.x = this.objTo.x + 3;
			bool flag72 = this.objTo.type_left_right == 0;
			if (flag72)
			{
				this.x = this.objTo.x - 3;
			}
			break;
		}
		case 154:
		case 155:
			this.create_upgrade6();
			break;
		case 156:
			this.fraImgEff = new FrameImage(381, 64, 35);
			this.vy = -6;
			this.y = this.objTo.y - this.objTo.hOne;
			this.y1000 = 0;
			this.fRemove = 1000;
			break;
		case 157:
		{
			this.fraImgEff = new FrameImage(382, 58, 80, 3);
			this.vx = CRes.random(3);
			bool flag73 = this.Dir == 0;
			if (flag73)
			{
				this.vx *= -1;
			}
			this.y -= GameCanvas.gameTick % 10 * 2;
			this.fRemove = 15;
			this.f = CRes.random(4);
			this.levelPaint = -1;
			break;
		}
		case 158:
		{
			this.Dir = (sbyte)this.objTo.type_left_right;
			this.fraImgEff = new FrameImage(385, 15, 27);
			this.fraImgSubEff = new FrameImage(386, 12, 22);
			this.fraImgSub2Eff = new FrameImage(221, 5, 5, 4);
			this.fraImgSub3Eff = new FrameImage(18, 20, 21);
			this.fRemove = 130;
			this.objTo.Action = 2;
			MainSkill skill2 = new MainSkill(9999, 257);
			this.y -= 15;
			this.objTo.plashNow = new Plash(skill2, this.objTo, null);
			this.x = this.objTo.x + 25;
			this.x1000 = this.x - 14;
			bool flag74 = this.Dir == 0;
			if (flag74)
			{
				this.x = this.objTo.x - 25;
				this.x1000 = this.x + 14;
			}
			this.y1000 = this.y;
			this.am_duong = 1;
			bool flag75 = this.Dir == 2;
			if (flag75)
			{
				this.am_duong = -1;
			}
			break;
		}
		case 160:
			this.create_EE_Valentine();
			break;
		case 161:
			this.create_EE_Valentine_stand();
			break;
		case 162:
			this.create_EE_LAW_HEART();
			break;
		case 163:
			this.fraImgEff = new FrameImage(392, 101, 44);
			this.levelPaint = -1;
			this.fRemove = 190;
			this.x1000 = this.x;
			this.y1000 = this.y + 24;
			this.timeBegin = GameCanvas.timeNow;
			break;
		case 164:
			this.create_Ice_Arc();
			this.levelPaint = -1;
			break;
		case 168:
			this.createUssopS3_Lv6();
			break;
		case 169:
			this.createEff_Firework();
			break;
		case 170:
			this.fraImgEff = new FrameImage(414, 8);
			this.fRemove = 16;
			this.levelPaint = -1;
			break;
		case 171:
			this.fraImgEff = new FrameImage(408, 4);
			this.fRemove = 8;
			this.numNextFrame = 2;
			break;
		case 172:
			this.fraImgEff = new FrameImage(402, 4);
			this.fRemove = 12;
			break;
		case 173:
			this.fraImgEff = new FrameImage(403, 2);
			this.fRemove = 4;
			break;
		case 174:
			this.fraImgEff = new FrameImage(411, 3);
			this.fRemove = 12;
			break;
		case 175:
		{
			this.fRemove = 15;
			bool flag76 = this.objTo != null;
			if (flag76)
			{
				this.x = this.objTo.x;
				this.y = this.objTo.y - this.objTo.hOne - 20;
			}
			this.fraImgEff = new FrameImage(25, 80, 40);
			this.fraImgSubEff = new FrameImage(329, 56, 31);
			this.fraImgSub2Eff = new FrameImage(238, 30, 73);
			this.fraImgSub3Eff = new FrameImage(195, 2);
			break;
		}
		case 176:
			this.fraImgEff = new FrameImage(71, 5);
			this.fRemove = 5;
			break;
		case 177:
		{
			bool flag77 = this.typeSub == 0;
			if (flag77)
			{
				this.fraImgEff = new FrameImage(mImage.createImage("/interface/pvp3_e.png"), 1);
			}
			else
			{
				bool flag78 = this.typeSub == 1;
				if (flag78)
				{
					this.fraImgEff = new FrameImage(mImage.createImage("/interface/pvp4_e.png"), 1);
				}
			}
			this.vy = -3;
			bool flag79 = this.typeSub % 2 == 1;
			if (flag79)
			{
				this.vy = -2;
			}
			this.fRemove = 18;
			this.frame = 0;
			break;
		}
		case 178:
		{
			this.fraImgEff = new FrameImage(mImage.createImage("/eff/goal.png"), 4);
			this.fRemove = 30;
			this.fraImgSub2Eff = new FrameImage(mImage.createImage("/eff/khungthanh.png"), 1);
			this.fraImgSubEff = new FrameImage(mImage.createImage("/eff/ball.png"), 4);
			this.x = this.objTo.x;
			this.y = this.objTo.y;
			this.toX = this.x + 200;
			this.toY = this.y - 30;
			this.vx = 5;
			this.vy = -1;
			this.vMax = 10;
			xdich = this.toX - this.x;
			ydich = this.toY - this.y - CRes.random(20);
			base.create_Speed(xdich, ydich, null);
			this.fRemove = 40;
			this.objTo.Dir = 2;
			this.objTo.Action = 2;
			MainSkill skill3 = new MainSkill(9999, 280);
			this.objTo.plashNow = new Plash(skill3, this.objTo, null);
			break;
		}
		}
	}

	// Token: 0x060001AA RID: 426 RVA: 0x00022424 File Offset: 0x00020624
	private void create_EE_LAW_HEART()
	{
		GameScreen.beginPaintSpec();
		MainSkill skill = new MainSkill(9999, 265);
		this.objTo.Action = 2;
		this.objTo.plashNow = new Plash(skill, this.objTo, null);
		bool flag = this.objTo == GameScreen.player;
		if (flag)
		{
			Player.isSendMove = false;
		}
		this.fraImgEff = new FrameImage(396, 20, 20);
		this.fraImgSubEff = new FrameImage(393, 110, 110);
		this.fraImgSub2Eff = new FrameImage(394, 126, 41);
		this.fraImgSub3Eff = new FrameImage(395, 69, 32);
		this.timeBegin = GameCanvas.timeNow;
		this.fRemove = 190;
		this.x1000 = this.x;
		this.y1000 = this.y + 24;
		this.x -= 30;
		this.y -= 60;
		this.vy = -2;
		this.vx = 0;
		GameScreen.addEffectEnd_ObjTo(163, 0, this.objTo.x, this.objTo.y, this.objTo.ID, this.objTo.typeObject, 0, this.objTo);
	}

	// Token: 0x060001AB RID: 427 RVA: 0x00022574 File Offset: 0x00020774
	private void create_EE_Valentine_stand()
	{
		this.fraImgEff = new FrameImage(388, 8, 7, 4);
		this.fraImgSubEff = new FrameImage(389, 11, 11, 2);
		this.frame = CRes.random(2);
		this.mPlayFrameVip = new int[][]
		{
			new int[]
			{
				1,
				1,
				1,
				1,
				0,
				1,
				0,
				1,
				1,
				1,
				1,
				1,
				0,
				1,
				0,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				1,
				0,
				1,
				0,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				0,
				1,
				0,
				1,
				1,
				1,
				0,
				1,
				0,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				0,
				1,
				0,
				1,
				1,
				1,
				0,
				1,
				0,
				1,
				1,
				1,
				0,
				1,
				0,
				1,
				1,
				1,
				0,
				1,
				0,
				1
			}
		};
		this.x = this.objTo.x + CRes.random_Am_0(10);
		this.y = this.objTo.y - this.objTo.hOne / 2 - CRes.random(10);
		this.vy = -2;
		this.vx = CRes.random_Am_0(3);
		this.randomf = -3 + CRes.random(6);
		this.randomf2 = CRes.random(this.mPlayFrameVip.Length);
		this.lengthM = this.mPlayFrameVip[this.randomf2].Length;
		this.fRemove = 25 + this.mPlayFrameVip[this.randomf2].Length;
		bool flag = CRes.random(5) == 0;
		if (flag)
		{
			this.levelPaint = -1;
		}
	}

	// Token: 0x060001AC RID: 428 RVA: 0x000226D0 File Offset: 0x000208D0
	private void create_EE_Valentine()
	{
		this.fraImgEff = new FrameImage(388, 8, 7, 4);
		for (int i = 0; i < 4; i++)
		{
			Point point = new Point();
			point.x = this.objTo.x + CRes.random_Am_0(5);
			point.y = this.objTo.y - this.objTo.hOne + 3 + i * 10 + CRes.random_Am_0(3) + GameCanvas.gameTick % 5 * 3;
			point.vx = -(2 + CRes.random(2));
			point.dis = 0;
			bool flag = this.objTo.type_left_right == 0;
			if (flag)
			{
				point.vx = 2 + CRes.random(2);
				point.dis = 2;
			}
			point.x += point.vx * 4;
			bool flag2 = CRes.random(4) == 0;
			if (flag2)
			{
				point.frame = CRes.random(4);
			}
			else
			{
				point.frame = 2 + CRes.random(2);
			}
			point.vy = -1;
			this.VecEff.addElement(point);
		}
		this.fRemove = 17;
		bool flag3 = CRes.random(5) != 0;
		if (flag3)
		{
			this.levelPaint = -1;
		}
	}

	// Token: 0x060001AD RID: 429 RVA: 0x00022814 File Offset: 0x00020A14
	private void create_upgrade6()
	{
		this.colorpaint = new int[]
		{
			15340368,
			14454331,
			16314661,
			3863335,
			2600435,
			1339473,
			13181375
		};
		this.vMax = 40;
		this.fRemove = 20;
		this.levelPaint = -1;
		int num = 270;
		for (int i = 0; i < 5; i++)
		{
			Point point = new Point();
			point.dis = num;
			point.x = CRes.getcos(CRes.fixangle(point.dis)) * this.vMax / 1000 + this.x;
			point.y = CRes.getsin(CRes.fixangle(point.dis)) * this.vMax / 1000 + this.y;
			this.VecEff.addElement(point);
			num += 72;
		}
		bool flag = this.typeEffect == 155;
		if (flag)
		{
			this.fraImgEff = new FrameImage(220, 9, 9, 4);
		}
	}

	// Token: 0x060001AE RID: 430 RVA: 0x00022908 File Offset: 0x00020B08
	private void create_Lucci_L2()
	{
		this.am_duong = 1;
		bool flag = this.Dir == 2;
		if (flag)
		{
			this.am_duong = -1;
		}
		this.fraImgEff = new FrameImage(274, 23, 74, 3);
		this.frame = 0;
		this.vx = this.am_duong * 12;
		this.x1000 = this.x;
		this.x = this.x1000 - this.am_duong * 24;
		this.fRemove = 20;
		bool flag2 = this.typeSub == 1;
		if (flag2)
		{
			this.fraImgSubEff = new FrameImage(273, 24, 24, 4);
			this.frame = 1;
		}
		bool flag3 = this.frame == 0;
		if (flag3)
		{
			this.mframe = new int[]
			{
				1,
				0,
				1,
				0,
				1,
				0,
				0,
				1,
				1,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2
			};
		}
		else
		{
			this.mframe = new int[]
			{
				1,
				0,
				1,
				0,
				1,
				0,
				0,
				1,
				2,
				2,
				3,
				3,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4
			};
		}
	}

	// Token: 0x060001AF RID: 431 RVA: 0x000229F8 File Offset: 0x00020BF8
	public override void paint(mGraphics g)
	{
		try
		{
			switch (this.typeEffect)
			{
			case 0:
			case 1:
			case 3:
			case 4:
			case 5:
			case 8:
			case 10:
			case 12:
			case 18:
			case 24:
			case 28:
			case 34:
			case 36:
			case 41:
			case 42:
			case 53:
			case 55:
			case 57:
			case 61:
			case 71:
			case 77:
			case 80:
			case 81:
			case 86:
			case 89:
			case 90:
			case 114:
			case 118:
			case 135:
			case 143:
			case 150:
			case 171:
				this.fraImgEff.drawFrame(this.f / (int)this.numNextFrame % this.fraImgEff.nFrame, this.x, this.y, (int)this.Dir, 3, g);
				break;
			case 2:
			{
				bool flag = this.f < 4;
				if (flag)
				{
					this.fraImgEff.drawFrame(this.f / 2, this.x, this.y - 5, 0, 3, g);
				}
				this.fraImgSubEff.drawFrame(this.f, this.x, this.y, 0, 33, g);
				break;
			}
			case 6:
			{
				bool flag2 = this.typeSub == 3;
				if (flag2)
				{
					int num;
					for (int i = 0; i < this.VecEff.size(); i = num + 1)
					{
						Point point = (Point)this.VecEff.elementAt(i);
						this.fraImgSub2Eff.drawFrameNew(this.indexEff_1 * this.fraImgEff.maxNumFrame + point.f % this.fraImgEff.maxNumFrame, point.x / 100, point.y / 100, 0, 3, g);
						num = i;
					}
				}
				this.fraImgEff.drawFrameNew(this.indexEff_1 * this.fraImgEff.maxNumFrame + this.f / (int)this.numNextFrame % this.fraImgEff.maxNumFrame, this.x / 100, this.y / 100, (int)this.Dir, 3, g);
				bool flag3 = this.fraImgSubEff != null;
				if (flag3)
				{
					this.fraImgSubEff.drawFrame(CRes.random(this.fraImgSubEff.nFrame), this.x / 100, this.y / 100, (int)this.Dir, 3, g);
				}
				break;
			}
			case 7:
			{
				int num;
				for (int j = 0; j < this.VecEff.size(); j = num + 1)
				{
					Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(j);
					base.paint_Bullet(g, this.fraImgEff, point_Focus.frame, point_Focus.x, point_Focus.y, false, 0);
					num = j;
				}
				break;
			}
			case 9:
			case 45:
			case 52:
			case 58:
			case 65:
			case 68:
			case 170:
				this.fraImgEff.drawFrame(this.f / (int)this.numNextFrame % this.fraImgEff.nFrame, this.x, this.y, (int)this.Dir, 33, g);
				break;
			case 11:
			{
				int num;
				for (int k = 0; k < this.VecEff.size(); k = num + 1)
				{
					Point point2 = (Point)this.VecEff.elementAt(k);
					point2.fraImgEff.drawFrame(point2.f / (int)this.numNextFrame % point2.fraImgEff.nFrame, point2.x, point2.y, 0, 3, g);
					num = k;
				}
				break;
			}
			case 13:
			{
				bool flag4 = this.fraImgSubEff != null;
				if (flag4)
				{
					int num;
					for (int l = 0; l < this.VecEff.size(); l = num + 1)
					{
						Point point3 = (Point)this.VecEff.elementAt(l);
						this.fraImgSubEff.drawFrame(point3.f % this.fraImgSubEff.nFrame, point3.x, point3.y, (int)this.Dir, 3, g);
						num = l;
					}
				}
				bool flag5 = this.f <= this.fRemove;
				if (flag5)
				{
					this.fraImgEff.drawFrame((this.f / (int)this.numNextFrame + this.randomf) % this.fraImgEff.nFrame, this.x, this.y, (int)this.Dir, 3, g);
					bool flag6 = this.fraImgSub2Eff != null;
					if (flag6)
					{
						this.fraImgSub2Eff.drawFrame(this.f % this.fraImgSub2Eff.nFrame, this.x, this.y, (int)this.Dir, 3, g);
					}
				}
				break;
			}
			case 14:
			{
				bool flag7 = this.f < 4;
				if (flag7)
				{
					this.fraImgEff.drawFrame(this.f / (int)this.numNextFrame, this.x, this.y, 0, 33, g);
				}
				break;
			}
			case 16:
				this.fraImgEff.drawFrameNew(this.indexEff_1 * this.fraImgEff.maxNumFrame + CRes.abs((int)this.typeSub), this.x, this.y, (int)this.Dir, 3, g);
				break;
			case 17:
			{
				int num2 = this.f;
				bool flag8 = this.f >= this.fRemove;
				if (flag8)
				{
					num2 = 2 - (this.f - this.fRemove) / 3;
				}
				else
				{
					bool flag9 = num2 > 2;
					if (flag9)
					{
						num2 = 2;
					}
				}
				this.fraImgEff.drawFrame(num2, this.x, this.y, 0, 3, g);
				break;
			}
			case 19:
			{
				bool flag10 = this.f < 6;
				if (flag10)
				{
					this.fraImgEff.drawFrame(this.f / (int)this.numNextFrame % this.fraImgEff.nFrame, this.x, this.y, (int)this.Dir, 3, g);
				}
				bool flag11 = this.f > 1;
				if (flag11)
				{
					this.fraImgSubEff.drawFrame((this.f - (int)(2 / this.numNextFrame)) % this.fraImgSubEff.nFrame, this.x, this.y, (int)this.Dir, 3, g);
				}
				break;
			}
			case 20:
				this.fraImgEff.drawFrame(this.f / (int)this.numNextFrame % this.fraImgEff.nFrame, this.x, this.y, this.randomf, 3, g);
				break;
			case 21:
			{
				int num;
				for (int m = 0; m < this.VecEff.size(); m = num + 1)
				{
					Point point4 = (Point)this.VecEff.elementAt(m);
					this.fraImgEff.drawFrame(point4.frame, point4.x, point4.y, 0, 3, g);
					num = m;
				}
				bool flag12 = this.f < 6;
				if (flag12)
				{
					this.fraImgSubEff.drawFrame(this.f / (int)this.numNextFrame % this.fraImgSubEff.nFrame, this.x, this.y, (int)this.Dir, 3, g);
				}
				break;
			}
			case 22:
			{
				int num;
				for (int n = 0; n < this.VecEff.size(); n = num + 1)
				{
					Point point5 = (Point)this.VecEff.elementAt(n);
					this.fraImgSubEff.drawFrame(point5.f / (int)this.numNextFrame % this.fraImgSubEff.nFrame, point5.x, point5.y, (int)this.Dir, 3, g);
					num = n;
				}
				bool flag13 = this.isUpdateNormal;
				if (flag13)
				{
					this.fraImgEff.drawFrame(this.f / (int)this.numNextFrame % this.fraImgEff.nFrame, this.x, this.y, (int)this.Dir, 3, g);
				}
				break;
			}
			case 23:
			{
				bool flag14 = this.f < 6;
				if (flag14)
				{
					this.fraImgSub2Eff.drawFrame((this.f / (int)this.numNextFrame + this.randomf) % this.fraImgSub2Eff.nFrame, this.x1000, this.y1000, (int)this.Dir, 3, g);
				}
				bool flag15 = this.f <= this.fRemove;
				if (flag15)
				{
					this.fraImgEff.drawFrame((this.f / (int)this.numNextFrame + this.randomf) % this.fraImgEff.nFrame, this.x, this.y, (int)this.Dir, 3, g);
				}
				int num;
				for (int num3 = 0; num3 < this.VecEff.size(); num3 = num + 1)
				{
					Point point6 = (Point)this.VecEff.elementAt(num3);
					this.fraImgSubEff.drawFrame(point6.f / (int)this.numNextFrame % this.fraImgSubEff.nFrame, point6.x, point6.y, (int)this.Dir, 3, g);
					num = num3;
				}
				break;
			}
			case 25:
			{
				this.fraImgEff.drawFrame(this.f / (int)this.numNextFrame % this.fraImgEff.nFrame, this.x, this.y, (int)this.Dir, 3, g);
				bool flag16 = this.typeSub != 1 && this.typeSub != 2 && this.typeSub != 3;
				if (!flag16)
				{
					bool flag17 = this.f < 4;
					if (flag17)
					{
						this.fraImgSubEff.drawFrame(this.f % this.fraImgSubEff.nFrame, this.x1000, this.y, (int)this.Dir, 3, g);
					}
					bool flag18 = this.typeSub == 2;
					if (flag18)
					{
						int num;
						for (int num4 = 0; num4 < this.VecEff.size(); num4 = num + 1)
						{
							Point point7 = (Point)this.VecEff.elementAt(num4);
							this.fraImgSub2Eff.drawFrame(point7.f % this.fraImgSub2Eff.nFrame, point7.x, point7.y, (int)this.Dir, 3, g);
							num = num4;
						}
					}
				}
				break;
			}
			case 26:
			{
				bool flag19 = this.f < this.mPlayFrame.Length;
				if (flag19)
				{
					this.fraImgEff.drawFrame(this.mPlayFrame[this.f], this.x, this.y, (int)this.Dir, mGraphics.BOTTOM | mGraphics.HCENTER, g);
				}
				bool flag20 = this.f > 0 && this.f < this.mPlayFrame.Length + 1;
				if (flag20)
				{
					this.fraImgEff.drawFrame(this.mPlayFrame[this.f - 1], this.x, this.y, (this.Dir == 0) ? 2 : 0, 33, g);
				}
				break;
			}
			case 27:
			{
				bool flag21 = this.f <= this.fRemove;
				if (flag21)
				{
					int num5 = this.f / 2;
					bool flag22 = num5 > (int)this.typeSub;
					if (flag22)
					{
						num5 = (int)this.typeSub;
					}
					this.fraImgEff.drawFrame(num5, this.x, this.y, (int)this.Dir, 3, g);
				}
				bool flag23 = this.typeSub == 2;
				if (flag23)
				{
					int num;
					for (int num6 = 0; num6 < this.VecEff.size(); num6 = num + 1)
					{
						Point point8 = (Point)this.VecEff.elementAt(num6);
						this.fraImgSubEff.drawFrame(point8.f % this.fraImgSubEff.nFrame, point8.x, point8.y, (int)this.Dir, 3, g);
						num = num6;
					}
				}
				break;
			}
			case 29:
			{
				bool flag24 = this.f >= 0 && this.f < 4;
				if (flag24)
				{
					this.fraImgEff.drawFrame(this.f / 2, this.x1000, this.y1000, (int)this.Dir, 3, g);
				}
				bool flag25 = this.f < this.fRemove && this.f > 1;
				if (flag25)
				{
					this.fraImgSubEff.drawFrame(0, this.x, this.y, (int)this.Dir, 3, g);
				}
				int num;
				for (int num7 = 0; num7 < this.VecEff.size(); num7 = num + 1)
				{
					Point point9 = (Point)this.VecEff.elementAt(num7);
					this.fraImgSub2Eff.drawFrame(point9.f % this.fraImgSub2Eff.nFrame, point9.x, point9.y, (int)this.Dir, 3, g);
					num = num7;
				}
				break;
			}
			case 30:
			{
				int num;
				for (int num8 = 0; num8 < this.VecEff.size(); num8 = num + 1)
				{
					Line line = (Line)this.VecEff.elementAt(num8);
					bool flag26 = line != null;
					if (flag26)
					{
						int color = 0;
						bool flag27 = num8 / 2 < this.colorpaint.Length;
						if (flag27)
						{
							color = this.colorpaint[num8 / 2];
						}
						g.setColor(color);
						g.drawLine(line.x0 / 1000, line.y0 / 1000, line.x1 / 1000, line.y1 / 1000);
						bool is2Line = line.is2Line;
						if (is2Line)
						{
							g.drawLine(line.x0 / 1000 + 1, line.y0 / 1000, line.x1 / 1000 + 1, line.y1 / 1000);
						}
					}
					num = num8;
				}
				break;
			}
			case 31:
			{
				int num;
				for (int num9 = 0; num9 < this.VecEff.size(); num9 = num + 1)
				{
					Point point10 = (Point)this.VecEff.elementAt(num9);
					bool flag28 = point10.dis == 1;
					if (flag28)
					{
						this.fraImgEff.drawFrameNew(point10.f / 2 % this.fraImgEff.nFrame, point10.x, point10.y, 0, 33, g);
					}
					else
					{
						bool flag29 = point10.dis == 0;
						if (flag29)
						{
							this.fraImgSubEff.drawFrameNew((point10.frame + point10.f / 2) % this.fraImgSubEff.nFrame, point10.x, point10.y, 0, 3, g);
						}
					}
					num = num9;
				}
				break;
			}
			case 32:
			{
				int num;
				for (int num10 = 0; num10 < this.VecEff.size(); num10 = num + 1)
				{
					Point point11 = (Point)this.VecEff.elementAt(num10);
					bool flag30 = this.fraImgEff.nFrame != 0;
					if (flag30)
					{
						bool flag31 = point11.dis == 1;
						if (flag31)
						{
							this.fraImgEff.drawFrameNew(this.fraImgEff.nFrame - point11.f / 2 % this.fraImgEff.nFrame, point11.x, point11.y, 0, 33, g);
						}
						else
						{
							bool flag32 = point11.dis == 0;
							if (flag32)
							{
								this.fraImgSubEff.drawFrameNew((point11.frame + point11.f / 2) % this.fraImgSubEff.nFrame, point11.x, point11.y, 0, 3, g);
							}
						}
					}
					num = num10;
				}
				break;
			}
			case 35:
				this.fraImgEff.drawFrame(this.f / (int)this.numNextFrame % this.fraImgEff.nFrame, this.x, this.y, (int)this.Dir, 3, g);
				break;
			case 37:
			{
				int num;
				for (int num11 = 0; num11 < this.VecEff.size(); num11 = num + 1)
				{
					Point point12 = (Point)this.VecEff.elementAt(num11);
					this.fraImgSub2Eff.drawFrame(point12.f % this.fraImgSub2Eff.nFrame, point12.x, point12.y, (int)this.Dir, 3, g);
					num = num11;
				}
				bool flag33 = this.f >= 0 && this.f < 6;
				if (flag33)
				{
					this.fraImgEff.drawFrame(this.f / 2, this.x1000, this.y1000, (int)this.Dir, 3, g);
				}
				bool flag34 = this.f < this.fRemove && this.f > 1;
				if (flag34)
				{
					int num12 = this.f / 2;
					bool flag35 = num12 > 2;
					if (flag35)
					{
						num12 = 2;
					}
					this.fraImgSubEff.drawFrame(num12, this.x, this.y, (int)this.Dir, 3, g);
				}
				break;
			}
			case 38:
			{
				int num;
				for (int num13 = 0; num13 < this.VecEff.size(); num13 = num + 1)
				{
					Point point13 = (Point)this.VecEff.elementAt(num13);
					this.fraImgEff.drawFrame(point13.f % this.fraImgEff.nFrame, point13.x, point13.y, (int)this.Dir, 3, g);
					num = num13;
				}
				break;
			}
			case 39:
			{
				int num14 = this.f;
				bool flag36 = num14 > 2;
				if (flag36)
				{
					num14 = 2 + CRes.random(2);
				}
				this.fraImgEff.drawFrame(num14, this.x, this.y, (int)this.Dir, 3, g);
				break;
			}
			case 40:
			{
				bool flag37 = this.f % 2 == 0;
				if (flag37)
				{
					this.fraImgSubEff.drawFrame(0, this.x, this.y + 12, (int)this.Dir, 3, g);
				}
				this.fraImgEff.drawFrame(3, this.x, this.y, (int)this.Dir, 3, g);
				bool flag38 = this.f % 2 != 0;
				if (!flag38)
				{
					bool flag39 = this.typeSub == 1 || this.typeSub == 2;
					if (flag39)
					{
						this.fraImgSub2Eff.drawFrameNew(0, this.x - 12, this.y + 12 + this.f * 14, (int)this.Dir, 33, g);
						bool flag40 = this.typeSub == 2;
						if (flag40)
						{
							this.fraImgSub2Eff.drawFrameNew(1, this.x + 12, this.y + 12 + this.f * 14, (int)this.Dir, 33, g);
						}
						else
						{
							this.fraImgSub2Eff.drawFrameNew(0, this.x + 12, this.y + 12 + this.f * 14, (int)this.Dir, 33, g);
						}
					}
					else
					{
						this.fraImgSub2Eff.drawFrameNew(0, this.x, this.y + 12 + this.f * 14, (int)this.Dir, 33, g);
					}
				}
				break;
			}
			case 46:
			case 159:
			{
				bool flag41 = this.f % 3 <= 1 || this.f >= 6;
				if (flag41)
				{
					this.fraImgEff.drawFrame(0, this.x, this.y, (int)this.Dir, 33, g);
				}
				bool flag42 = this.f >= 2 && this.f <= 7;
				if (flag42)
				{
					this.fraImgSubEff.drawFrame((this.f - 2) / 3, this.x, this.y + 5, (int)this.Dir, 33, g);
				}
				break;
			}
			case 47:
			{
				int num;
				for (int num15 = 0; num15 < this.VecEff.size(); num15 = num + 1)
				{
					Point point14 = (Point)this.VecEff.elementAt(num15);
					this.fraImgEff.drawFrame(point14.f / (int)this.numNextFrame % this.fraImgEff.nFrame, point14.x, point14.y, 0, 3, g);
					num = num15;
				}
				break;
			}
			case 48:
			case 50:
			{
				bool flag43 = this.f < 10;
				if (flag43)
				{
					this.fraImgEff.drawFrame(this.f / 2, this.x, this.y, (int)this.Dir, 3, g);
				}
				int num;
				for (int num16 = 0; num16 < this.VecEff.size(); num16 = num + 1)
				{
					Point point15 = (Point)this.VecEff.elementAt(num16);
					bool flag44 = point15.frame < 2;
					if (flag44)
					{
						this.fraImgSubEff.drawFrame(point15.f / 2 % this.fraImgSubEff.nFrame, point15.x, point15.y, 0, 3, g);
					}
					else
					{
						this.fraImgSub2Eff.drawFrame(point15.f / 2 % this.fraImgSubEff.nFrame, point15.x, point15.y, 0, 3, g);
					}
					num = num16;
				}
				break;
			}
			case 49:
				base.paint_Bullet(g, this.fraImgEff, this.frame, this.x, this.y, false, this.f % 2 * 3);
				break;
			case 51:
			{
				bool flag45 = this.f < this.fRemove;
				if (flag45)
				{
					this.fraImgSubEff.drawFrame(this.f % this.fraImgSubEff.nFrame, this.x, this.y, (int)this.Dir, 3, g);
					bool flag46 = this.fraImgEff != null;
					if (flag46)
					{
						this.fraImgEff.drawFrame(CRes.random(this.fraImgEff.nFrame), this.x, this.y, (int)this.Dir, 3, g);
					}
				}
				break;
			}
			case 54:
			{
				int num;
				for (int num17 = 0; num17 < this.VecEff.size(); num17 = num + 1)
				{
					Point point16 = (Point)this.VecEff.elementAt(num17);
					bool flag47 = this.typeSub == 1 || this.typeSub == 3 || this.typeSub == 10 || this.typeSub == 11 || this.typeSub == 12;
					if (flag47)
					{
						this.fraImgEff.drawFrame(3, point16.x, point16.y, (int)this.Dir, 3, g);
					}
					else
					{
						bool flag48 = this.typeSub >= 4 && this.typeSub <= 7;
						if (flag48)
						{
							this.fraImgEff.drawFrameNew(this.frame * this.fraImgEff.maxNumFrame + point16.f % this.fraImgEff.maxNumFrame, point16.x, point16.y, (int)this.Dir, 3, g);
						}
						else
						{
							bool flag49 = this.typeSub == 8;
							if (flag49)
							{
								this.fraImgEff.drawFrameNew((2 + num17 % 2) * this.fraImgEff.maxNumFrame + point16.f % this.fraImgEff.maxNumFrame, point16.x, point16.y, (int)this.Dir, 3, g);
							}
							else
							{
								bool flag50 = this.typeSub == 9;
								if (flag50)
								{
									this.fraImgEff.drawFrameNew((this.frame + num17 % 2) * this.fraImgEff.maxNumFrame + point16.f % this.fraImgEff.maxNumFrame, point16.x, point16.y, (int)this.Dir, 3, g);
								}
								else
								{
									this.fraImgEff.drawFrame(point16.f % this.fraImgEff.nFrame, point16.x, point16.y, (int)this.Dir, 3, g);
								}
							}
						}
					}
					num = num17;
				}
				bool flag51 = this.fraImgSubEff != null;
				if (flag51)
				{
					for (int num18 = 0; num18 < this.vecSubEff.size(); num18 = num + 1)
					{
						Point point17 = (Point)this.vecSubEff.elementAt(num18);
						this.fraImgSubEff.drawFrame(point17.f / 2 % this.fraImgSubEff.nFrame, point17.x, point17.y, (int)this.Dir, 33, g);
						num = num18;
					}
				}
				break;
			}
			case 56:
			{
				bool flag52 = this.f < 3;
				if (flag52)
				{
					this.fraImgEff.drawFrame(this.f, this.toX, this.toY, (int)this.Dir, mGraphics.BOTTOM | mGraphics.HCENTER, g);
				}
				else
				{
					this.fraImgEff.drawFrame(5 - this.f, this.x, this.y, (int)this.Dir, mGraphics.BOTTOM | mGraphics.HCENTER, g);
				}
				break;
			}
			case 59:
			case 107:
			{
				int num;
				for (int num19 = 0; num19 < this.VecEff.size(); num19 = num + 1)
				{
					Point point18 = (Point)this.VecEff.elementAt(num19);
					this.fraImgEff.drawFrame(point18.frame, point18.x, point18.y, 0, 3, g);
					num = num19;
				}
				break;
			}
			case 60:
			{
				int num;
				for (int num20 = 0; num20 < this.VecEff.size(); num20 = num + 1)
				{
					Point point19 = (Point)this.VecEff.elementAt(num20);
					this.fraImgEff.drawFrame(point19.frame, point19.x, point19.y, 0, 3, g);
					num = num20;
				}
				bool flag53 = this.typeSub == 2;
				if (flag53)
				{
					bool flag54 = this.f < this.fraImgSubEff.nFrame;
					if (flag54)
					{
						this.fraImgSubEff.drawFrame(this.f / (int)this.numNextFrame % this.fraImgSubEff.nFrame, this.x, this.y, (int)this.Dir, 3, g);
					}
				}
				else
				{
					bool flag55 = this.f < 6;
					if (flag55)
					{
						this.fraImgSubEff.drawFrame(this.f / (int)this.numNextFrame % this.fraImgSubEff.nFrame, this.x, this.y, (int)this.Dir, 3, g);
					}
				}
				break;
			}
			case 62:
			{
				int num;
				for (int num21 = 0; num21 < this.VecEff.size(); num21 = num + 1)
				{
					Point point20 = (Point)this.VecEff.elementAt(num21);
					int num22 = point20.frame;
					bool flag56 = this.f > this.fRemove - 4;
					if (flag56)
					{
						num22 += 3;
					}
					this.fraImgEff.drawFrame(num22, point20.x, point20.y, (int)this.Dir, 3, g);
					num = num21;
				}
				break;
			}
			case 63:
				this.paintNo_Dat_New(g);
				break;
			case 64:
				this.fraImgEff.drawFrame(this.f / (int)this.numNextFrame, this.x, this.y, 0, 3, g);
				this.fraImgEff.drawFrame(this.f / (int)this.numNextFrame, this.x, this.y, 2, 3, g);
				break;
			case 66:
			{
				int num23 = 0;
				bool flag57 = this.f < 2;
				if (flag57)
				{
					num23 = 1;
				}
				else
				{
					bool flag58 = this.f > this.fRemove - 4;
					if (flag58)
					{
						num23 = 2 - (this.fRemove - this.f) / 2;
					}
				}
				this.fraImgEff.drawFrameNew((int)(this.typeSub * 3) + num23, this.x, this.y, (int)this.Dir, 3, g);
				break;
			}
			case 69:
			case 70:
			{
				int num;
				for (int num24 = 0; num24 < this.VecEff.size(); num24 = num + 1)
				{
					Point point21 = (Point)this.VecEff.elementAt(num24);
					this.fraImgEff.drawFrame(point21.frame, this.objTo.x, this.objTo.y + point21.y, (int)this.Dir, 33, g);
					num = num24;
				}
				break;
			}
			case 72:
				this.fraImgEff.drawFrame(CRes.abs((int)this.typeSub), this.x, this.y, (int)this.Dir, 3, g);
				break;
			case 73:
				g.setColor(0);
				g.drawLine(this.x, this.y, this.toX, this.toY);
				break;
			case 74:
				g.setColor(16777215);
				g.drawLine(this.x, this.y, this.toX, this.toY);
				break;
			case 75:
			case 78:
			{
				int num;
				for (int num25 = 0; num25 < this.VecEff.size(); num25 = num + 1)
				{
					Point point22 = (Point)this.VecEff.elementAt(num25);
					bool flag59 = point22.frame == 0;
					if (flag59)
					{
						this.fraImgSubEff.drawFrame(point22.f % this.fraImgSubEff.nFrame, point22.x, point22.y, 0, 3, g);
					}
					else
					{
						this.fraImgSub2Eff.drawFrame(point22.f % this.fraImgSub2Eff.nFrame, point22.x, point22.y, 0, 3, g);
					}
					num = num25;
				}
				bool flag60 = this.f < this.fRemove + 10;
				if (flag60)
				{
					this.fraImgEff.drawFrame(this.f / 2 % 2, this.x, this.y, 0, 3, g);
				}
				break;
			}
			case 76:
			{
				int num;
				for (int num26 = 0; num26 < this.VecEff.size(); num26 = num + 1)
				{
					Point point23 = (Point)this.VecEff.elementAt(num26);
					bool flag61 = point23.frame == 0;
					if (flag61)
					{
						this.fraImgEff.drawFrame(point23.f % this.fraImgEff.nFrame, point23.x, point23.y, 0, 3, g);
					}
					else
					{
						this.fraImgSubEff.drawFrame(point23.f % this.fraImgSubEff.nFrame, point23.x, point23.y, 0, 3, g);
					}
					num = num26;
				}
				break;
			}
			case 79:
			{
				bool flag62 = this.f > 6 || this.f % 2 == 0;
				if (flag62)
				{
					this.fraImgEff.drawFrame(this.frame, this.x, this.y, 0, 3, g);
				}
				break;
			}
			case 82:
			{
				this.fraImgSubEff.drawFrame((this.f / (int)this.numNextFrame + 3) % this.fraImgSubEff.nFrame, this.x, this.y, (int)this.Dir, 33, g);
				bool flag63 = this.f < 4;
				if (flag63)
				{
					this.fraImgEff.drawFrame(this.f / (int)this.numNextFrame % this.fraImgEff.nFrame, this.x, this.y, (int)this.Dir, 33, g);
				}
				break;
			}
			case 83:
			{
				bool flag64 = this.f < 6;
				if (flag64)
				{
					this.fraImgSubEff.drawFrame(this.f, this.objTo.x, this.objTo.y - this.objTo.hOne / 2, (int)this.Dir, 3, g);
				}
				int num;
				for (int num27 = 0; num27 < this.VecEff.size(); num27 = num + 1)
				{
					Point point24 = (Point)this.VecEff.elementAt(num27);
					this.fraImgEff.drawFrame(point24.frame, this.objTo.x, this.objTo.y + point24.y, (int)this.Dir, 33, g);
					num = num27;
				}
				break;
			}
			case 84:
			{
				int num;
				for (int num28 = 0; num28 < this.VecEff.size(); num28 = num + 1)
				{
					Point point25 = (Point)this.VecEff.elementAt(num28);
					this.fraImgEff.drawFrame(point25.frame, point25.x, point25.y, point25.dis, 3, g);
					num = num28;
				}
				break;
			}
			case 85:
			{
				int num;
				for (int num29 = 0; num29 < this.VecEff.size(); num29 = num + 1)
				{
					Line line2 = (Line)this.VecEff.elementAt(num29);
					bool flag65 = line2 == null;
					if (!flag65)
					{
						bool flag66 = line2.type < 4;
						if (flag66)
						{
							this.fraImgEff.drawFrame(line2.f % this.fraImgEff.nFrame, line2.x0 / 1000, line2.y0 / 1000, 0, 3, g);
						}
						else
						{
							bool flag67 = line2.type < 8;
							if (flag67)
							{
								this.fraImgSubEff.drawFrame(line2.f % this.fraImgSubEff.nFrame, line2.x0 / 1000, line2.y0 / 1000, 0, 3, g);
							}
							else
							{
								int color2 = 0;
								bool flag68 = num29 / 2 < this.colorpaint.Length;
								if (flag68)
								{
									color2 = this.colorpaint[num29 / 2];
								}
								g.setColor(color2);
								g.drawLine(line2.x0 / 1000, line2.y0 / 1000, line2.x1 / 1000, line2.y1 / 1000);
								bool is2Line2 = line2.is2Line;
								if (is2Line2)
								{
									g.drawLine(line2.x0 / 1000 + 1, line2.y0 / 1000, line2.x1 / 1000 + 1, line2.y1 / 1000);
								}
							}
						}
					}
					num = num29;
				}
				break;
			}
			case 87:
				this.fraImgEff.drawFrame((int)(this.typeSub * 3 + 2), this.x / 100, this.y / 100, (int)this.Dir, 3, g);
				break;
			case 88:
			{
				bool flag69 = this.f < this.mPlayFrame.Length && this.fraImgEff.getImageFrame() != null;
				if (flag69)
				{
					g.drawRegion(this.fraImgEff.getImageFrame(), this.mPlayFrame[this.f] * this.fraImgEff.frameWidth, 0, this.fraImgEff.frameWidth, this.fraImgEff.frameHeight, 0, (float)this.x, (float)this.y, 33);
				}
				break;
			}
			case 91:
			case 92:
			{
				bool flag70 = this.f < this.mPlayFrame.Length;
				if (flag70)
				{
					this.fraImgEff.drawFrame(this.mPlayFrame[this.f], this.x, this.y, (int)this.Dir, 3, g);
				}
				break;
			}
			case 93:
			{
				int num;
				for (int num30 = 0; num30 < this.VecEff.size(); num30 = num + 1)
				{
					Point point26 = (Point)this.VecEff.elementAt(num30);
					this.fraImgEff.drawFrame(point26.frame, point26.x, point26.y, 0, 3, g);
					num = num30;
				}
				break;
			}
			case 96:
			{
				int num;
				for (int num31 = 0; num31 < this.VecEff.size(); num31 = num + 1)
				{
					Point_Focus point_Focus2 = (Point_Focus)this.VecEff.elementAt(num31);
					this.fraImgEff.drawFrame(this.f / 3 % 3, point_Focus2.x, point_Focus2.y, 0, 3, g);
					num = num31;
				}
				break;
			}
			case 97:
			{
				bool flag71 = this.f % 2 == 1;
				if (flag71)
				{
					this.fraImgSubEff.drawFrame(0, this.x, this.y, (int)this.Dir, 33, g);
				}
				else
				{
					this.fraImgEff.drawFrame(0, this.x, this.y, (int)this.Dir, 33, g);
				}
				break;
			}
			case 98:
			{
				bool flag72 = this.f < 12;
				if (flag72)
				{
					this.fraImgEff.drawFrameNew(this.f / 3, this.x, this.y, 0, 33, g);
				}
				int num;
				for (int num32 = 0; num32 < this.VecEff.size(); num32 = num + 1)
				{
					Point point27 = (Point)this.VecEff.elementAt(num32);
					this.fraImgSubEff.drawFrame(point27.f % 5, point27.x, point27.y, 0, 3, g);
					num = num32;
				}
				break;
			}
			case 99:
			{
				bool flag73 = this.f < 8;
				if (flag73)
				{
					this.fraImgSubEff.drawFrameNew(this.f / 2, this.x, this.y, 0, 33, g);
					this.fraImgEff.drawFrame(this.f / 2, this.x, this.y, 0, 33, g);
				}
				int num;
				for (int num33 = 0; num33 < this.VecEff.size(); num33 = num + 1)
				{
					Point point28 = (Point)this.VecEff.elementAt(num33);
					this.fraImgSub2Eff.drawFrame(point28.f % 5, point28.x, point28.y, 0, 3, g);
					num = num33;
				}
				break;
			}
			case 101:
			{
				int num;
				for (int num34 = 0; num34 < this.VecEff.size(); num34 = num + 1)
				{
					Point point29 = (Point)this.VecEff.elementAt(num34);
					bool flag74 = this.objTo != null;
					if (flag74)
					{
						this.fraImgEff.drawFrame(point29.f, this.objTo.x + point29.x, this.objTo.y + point29.y, 0, 3, g);
					}
					num = num34;
				}
				break;
			}
			case 102:
			{
				bool flag75 = this.f < 10;
				if (flag75)
				{
					this.fraImgEff.drawFrame(this.f / 2 % this.fraImgEff.nFrame, this.x, this.y, 0, 3, g);
				}
				else
				{
					bool flag76 = this.f < 26;
					if (flag76)
					{
						this.fraImgSubEff.drawFrame(this.f / 2 % 3, this.x, this.y, 0, 3, g);
					}
					else
					{
						this.fraImgSubEff.drawFrame(3 + this.f / 2 % 2, this.x, this.y, 0, 3, g);
					}
				}
				break;
			}
			case 103:
			{
				bool flag77 = this.f < this.mPlayFrame.Length && this.f >= 0;
				if (flag77)
				{
					this.fraImgEff.drawFrame(this.mPlayFrame[this.f], this.x, this.y, (int)this.Dir, 33, g);
				}
				break;
			}
			case 104:
			{
				int num;
				for (int num35 = 0; num35 < this.VecEff.size(); num35 = num + 1)
				{
					Point point30 = (Point)this.VecEff.elementAt(num35);
					this.fraImgEff.drawFrame(point30.f, MainScreen.cameraMain.xCam + point30.x, point30.y, 0, 3, g);
					num = num35;
				}
				break;
			}
			case 105:
			{
				int num;
				for (int num36 = 0; num36 < this.VecEff.size(); num36 = num + 1)
				{
					Point point31 = (Point)this.VecEff.elementAt(num36);
					this.fraImgEff.drawFrame(point31.frame, MainScreen.cameraMain.xCam + point31.x, point31.y, 0, 3, g);
					num = num36;
				}
				break;
			}
			case 106:
				this.fraImgEff.drawFrame(this.f / 2 % this.fraImgEff.nFrame, this.x, this.y, 0, 33, g);
				break;
			case 108:
			{
				int num;
				for (int num37 = 0; num37 < this.VecEff.size(); num37 = num + 1)
				{
					Point point32 = (Point)this.VecEff.elementAt(num37);
					bool flag78 = point32.dis != 0;
					if (flag78)
					{
						this.fraImgSubEff.drawFrameNew(point32.frame + (int)(this.typeSub * 4), point32.x, point32.y, 0, 3, g);
					}
					else
					{
						this.fraImgEff.drawFrameNew(point32.frame + (int)(this.typeSub * 4), point32.x, point32.y, 0, 3, g);
					}
					num = num37;
				}
				break;
			}
			case 109:
				this.fraImgEff.drawFrame(this.f / (int)this.numNextFrame % this.fraImgEff.nFrame, this.x, this.y, (int)this.Dir, 0, g);
				break;
			case 110:
			{
				int num;
				for (int num38 = 0; num38 < this.VecEff.size(); num38 = num + 1)
				{
					Point point33 = (Point)this.VecEff.elementAt(num38);
					bool flag79 = point33.subType == 1;
					if (flag79)
					{
						this.fraImgSubEff.drawFrameNew((int)(this.typeSub * 3) + point33.frame, point33.x, point33.y, 0, 3, g);
					}
					else
					{
						this.fraImgEff.drawFrameNew((int)(this.typeSub * 4) + point33.frame, point33.x, point33.y, 0, 3, g);
					}
					num = num38;
				}
				break;
			}
			case 111:
			{
				int num;
				for (int num39 = 0; num39 < 5; num39 = num + 1)
				{
					this.fraImgEff.drawFrame(0, this.x, this.y - num39 * this.fraImgEff.frameHeight + 5, CRes.random(2) * 2, 33, g);
					num = num39;
				}
				this.fraImgSub2Eff.drawFrame(this.f / 2 % this.fraImgSub2Eff.nFrame, this.x, this.y + 9, 0, 33, g);
				for (int num40 = 0; num40 < this.VecEff.size(); num40 = num + 1)
				{
					Point point34 = (Point)this.VecEff.elementAt(num40);
					this.fraImgSubEff.drawFrameNew(point34.frame, this.x + point34.x, this.y + point34.y, (int)this.Dir, 33, g);
					num = num40;
				}
				break;
			}
			case 112:
				this.fraImgEff.drawFrameNew((int)(this.typeSub * 4) + this.frame, this.x, this.y, (int)this.Dir, 3, g);
				break;
			case 113:
			{
				int num;
				for (int num41 = this.VecEff.size() - 1; num41 >= 0; num41 = num - 1)
				{
					Point point35 = (Point)this.VecEff.elementAt(num41);
					this.fraImgSubEff.drawFrameNew(point35.frame * this.fraImgSubEff.maxNumFrame + point35.f / 3 % this.fraImgSubEff.maxNumFrame, point35.x / 1000, point35.y / 1000, 0, 33, g);
					num = num41;
				}
				bool flag80 = this.f / 3 < this.fraImgEff.nFrame;
				if (flag80)
				{
					this.fraImgEff.drawFrame(this.f / 3, this.x, this.y, (int)this.Dir, 33, g);
				}
				break;
			}
			case 115:
			{
				this.fraImgSubEff.drawFrame(0, this.x, this.y, 0, 33, g);
				int num;
				for (int num42 = 0; num42 < this.VecEff.size(); num42 = num + 1)
				{
					Point point36 = (Point)this.VecEff.elementAt(num42);
					this.fraImgEff.drawFrame(point36.frame, point36.x, point36.y, 0, 3, g);
					num = num42;
				}
				break;
			}
			case 116:
			{
				int num;
				for (int num43 = 0; num43 < this.VecEff.size(); num43 = num + 1)
				{
					Point point37 = (Point)this.VecEff.elementAt(num43);
					this.fraImgEff.drawFrame(point37.f % this.fraImgEff.nFrame, point37.x, point37.y, 0, 3, g);
					num = num43;
				}
				break;
			}
			case 117:
			{
				bool flag81 = this.f > this.fRemove - 2 && this.f <= this.fRemove;
				if (flag81)
				{
					this.fraImgEff.drawFrame(this.fRemove - this.f, this.x, this.y, 0, 3, g);
				}
				else
				{
					this.fraImgEff.drawFrame(0, this.x, this.y, 0, 3, g);
				}
				break;
			}
			case 119:
			{
				int num;
				for (int num44 = 0; num44 < this.VecEff.size(); num44 = num + 1)
				{
					Point point38 = (Point)this.VecEff.elementAt(num44);
					bool flag82 = point38.f < this.mPlayFrame.Length;
					if (flag82)
					{
						this.fraImgEff.drawFrameNew(this.mPlayFrame[point38.f], point38.x, point38.y, 0, 3, g);
					}
					num = num44;
				}
				break;
			}
			case 120:
			{
				bool flag83 = this.f < 10;
				if (flag83)
				{
					this.fraImgEff.drawFrame(this.f / 2, this.x, this.y, (int)this.Dir, 3, g);
				}
				int num;
				for (int num45 = 0; num45 < this.VecEff.size(); num45 = num + 1)
				{
					Point point39 = (Point)this.VecEff.elementAt(num45);
					bool flag84 = point39.frame < 2;
					if (flag84)
					{
						this.fraImgSubEff.drawFrameNew(point39.fSmall * this.fraImgSubEff.maxNumFrame + point39.f / 2 % this.fraImgSubEff.maxNumFrame, point39.x, point39.y, 0, 3, g);
					}
					else
					{
						this.fraImgSub2Eff.drawFrameNew(point39.fSmall * this.fraImgSub2Eff.maxNumFrame + point39.f / 2 % this.fraImgSub2Eff.maxNumFrame, point39.x, point39.y, 0, 3, g);
					}
					num = num45;
				}
				break;
			}
			case 121:
			{
				this.frame = this.f / 2;
				bool flag85 = this.frame >= this.mPlayFrame.Length;
				if (flag85)
				{
					this.frame = this.mPlayFrame.Length - 1;
				}
				bool flag86 = this.f < 10 || this.f % 2 == 0;
				if (flag86)
				{
					g.setColor(this.mPlayFrame[this.frame]);
					g.fillRect(MainScreen.cameraMain.xCam, MainScreen.cameraMain.yCam, MotherCanvas.w, MotherCanvas.h);
				}
				break;
			}
			case 122:
				this.fraImgEff.drawFrameNew(this.f / (int)this.numNextFrame, this.x, this.y, (int)this.Dir, 3, g);
				break;
			case 123:
				this.fraImgEff.drawFrameNew((int)this.typeSub * this.fraImgEff.maxNumFrame + this.f / (int)this.numNextFrame, this.x, this.y, (int)this.Dir, 3, g);
				break;
			case 124:
			{
				bool flag87 = this.mPlayFrame[this.f] == 5;
				if (flag87)
				{
					bool flag88 = this.fraImgEff.getImageFrame() != null;
					if (flag88)
					{
						g.drawRegion(this.fraImgEff.getImageFrame(), 0, 0, 30, 21, 0, (float)(this.x - 15), (float)this.y, 3);
						g.drawRegion(this.fraImgEff.getImageFrame(), 19, 0, 30, 21, 0, (float)(this.x + 15), (float)this.y, 3);
					}
				}
				else
				{
					this.fraImgEff.drawFrameNew(this.mPlayFrame[this.f], this.x, this.y, 0, 3, g);
				}
				break;
			}
			case 125:
			{
				int num46 = this.x;
				bool flag89 = this.f < 3 || (this.f > 10 && this.f < 14);
				if (flag89)
				{
					num46 += CRes.random_Am_0(3);
				}
				this.fraImgEff.drawFrameNew(this.mPlayFrame[this.f], num46, this.y, 0, 33, g);
				break;
			}
			case 126:
			{
				bool flag90 = this.step == 0 || this.step == 3;
				if (flag90)
				{
					this.fraImgEff.drawFrame(this.frame * 2, this.x / 100, this.y / 100, (int)this.Dir, 3, g);
				}
				else
				{
					this.fraImgEff.drawFrame(this.frame * 2 + 1, this.x / 100, this.y / 100, (int)this.Dir, 3, g);
				}
				bool flag91 = this.frame == 1;
				if (flag91)
				{
					this.fraImgSubEff.drawFrame(this.frame / 2 % this.fraImgSubEff.nFrame, this.x1000, this.y1000, (int)this.Dir, 3, g);
				}
				int num;
				for (int num47 = 0; num47 < this.VecEff.size(); num47 = num + 1)
				{
					Point_Focus point_Focus3 = (Point_Focus)this.VecEff.elementAt(num47);
					bool flag92 = point_Focus3.frame == 0;
					if (flag92)
					{
						this.fraImgSubEff.drawFrame(point_Focus3.f / 2 % this.fraImgSubEff.nFrame, point_Focus3.x, point_Focus3.y, (int)this.Dir, 3, g);
					}
					bool flag93 = point_Focus3.frame == 1;
					if (flag93)
					{
						this.fraImgSub2Eff.drawFrame(0, point_Focus3.x, point_Focus3.y, (int)this.Dir, 3, g);
					}
					num = num47;
				}
				break;
			}
			case 127:
			{
				int num48 = this.y;
				bool flag94 = this.f < this.mposy.Length;
				if (flag94)
				{
					num48 -= this.mposy[this.f];
				}
				bool flag95 = this.typeSub % 10 > 3 && this.typeSub % 10 != 7;
				if (flag95)
				{
					this.fraImgEff.drawFrameNew(this.frame * 2 + this.f / 3 % 2, this.x, num48, 0, 3, g);
				}
				else
				{
					this.fraImgEff.drawFrameNew(this.frame * 2, this.x, num48, 0, 3, g);
				}
				break;
			}
			case 128:
				this.fraImgEff.drawFrame(this.frame * 2, this.x / 100, this.y / 100, (int)this.Dir, 3, g);
				break;
			case 130:
			{
				bool flag96 = this.objTo != null;
				if (flag96)
				{
					int num;
					for (int num49 = 0; num49 < this.VecEff.size(); num49 = num + 1)
					{
						Point point40 = (Point)this.VecEff.elementAt(num49);
						this.fraImgEff.drawFrameNew(point40.frame, this.objTo.x + point40.x, this.objTo.y + point40.y, 0, 33, g);
						num = num49;
					}
				}
				break;
			}
			case 131:
			{
				bool flag97 = this.objTo != null;
				if (flag97)
				{
					this.fraImgEff.drawFrameNew(3 + this.f / 2 % this.fraImgEff.maxNumFrame, this.objTo.x, this.objTo.y + 4, 0, 33, g);
				}
				break;
			}
			case 132:
			{
				bool flag98 = this.typeSub == 1;
				if (flag98)
				{
					this.fraImgEff.drawFrameNew((int)this.typeSub * this.fraImgEff.maxNumFrame + CRes.random(3), this.x, this.y, 0, 3, g);
				}
				else
				{
					this.fraImgEff.drawFrameNew((int)this.typeSub * this.fraImgEff.maxNumFrame + (3 - this.f), this.x, this.y, 0, 3, g);
				}
				break;
			}
			case 133:
			{
				int idx = 1;
				bool flag99 = this.f < 2 || this.f > this.fRemove - 3;
				if (flag99)
				{
					idx = 0;
				}
				this.fraImgEff.drawFrame(idx, this.x, this.y, 0, 3, g);
				break;
			}
			case 134:
			{
				int idx2 = 1;
				bool flag100 = this.f < 2 || this.f > this.fRemove - 3;
				if (flag100)
				{
					idx2 = 0;
					this.fraImgEff.drawFrame(idx2, this.x, this.y, 0, 3, g);
				}
				else
				{
					this.fraImgEff.drawFrame(idx2, this.x, this.y, 0, 3, g);
					this.fraImgSubEff.drawFrameNew((int)this.typeSub * this.fraImgSubEff.maxNumFrame + CRes.random(3), this.x - 38, this.y - 40, 0, 0, g);
				}
				break;
			}
			case 136:
			{
				bool flag101 = this.f < this.mPlayFrameVip.Length;
				if (flag101)
				{
					int num;
					for (int num50 = 0; num50 < this.mPlayFrameVip[this.f].Length; num50 = num + 1)
					{
						this.fraImgEff.drawFrameNew(this.mPlayFrameVip[this.f][num50], this.x, this.y, 0, 3, g);
						num = num50;
					}
				}
				break;
			}
			case 137:
			{
				int num;
				for (int num51 = 0; num51 < this.VecEff.size(); num51 = num + 1)
				{
					Point point41 = (Point)this.VecEff.elementAt(num51);
					this.fraImgEff.drawFrame(point41.f / 4 % this.fraImgEff.nFrame, point41.x, point41.y, (int)this.Dir, 33, g);
					num = num51;
				}
				break;
			}
			case 138:
			{
				int num;
				for (int num52 = 0; num52 < this.VecEff.size(); num52 = num + 1)
				{
					Point point42 = (Point)this.VecEff.elementAt(num52);
					this.fraImgEff.drawFrameNew(point42.frame * 4 + point42.f % this.fraImgEff.nFrame, point42.x, point42.y, (int)this.Dir, 3, g);
					num = num52;
				}
				break;
			}
			case 139:
			{
				bool flag102 = this.mPlayFrame[this.f] >= 0;
				if (flag102)
				{
					this.fraImgEff.drawFrameNew(this.mPlayFrame[this.f], this.x, this.y, 0, 33, g);
				}
				break;
			}
			case 140:
			case 167:
			{
				int num53 = CRes.random(2);
				int num;
				for (int num54 = 0; num54 < this.VecEff.size(); num54 = num + 1)
				{
					int num55 = num54 + num53;
					bool flag103 = num55 >= this.VecEff.size();
					if (flag103)
					{
						num55 = 0;
					}
					Point point43 = (Point)this.VecEff.elementAt(num55);
					bool flag104 = point43.frame == 1;
					if (flag104)
					{
						bool flag105 = this.f > this.fRemove - 2;
						if (flag105)
						{
							this.frame = 3;
						}
						else
						{
							this.frame = CRes.random(3);
						}
						bool flag106 = this.typeEffect == 140;
						if (flag106)
						{
							this.fraImgEff.drawFrameNew(this.frame, point43.x, point43.y, 0, 33, g);
						}
					}
					else
					{
						bool flag107 = this.f > this.fRemove - 2;
						if (flag107)
						{
							this.frame = 3;
						}
						else
						{
							this.frame = CRes.random(3);
						}
						int num56 = 0;
						int num57 = 0;
						bool flag108 = this.typeEffect == 167;
						if (flag108)
						{
							bool flag109 = this.Dir == 0;
							if (flag109)
							{
								num56 = 10;
							}
							else
							{
								bool flag110 = this.Dir == 2;
								if (flag110)
								{
									num56 = -10;
								}
							}
							num57 = 10;
						}
						this.fraImgSubEff.drawFrameNew(this.frame, point43.x + num56, point43.y + num57, 0, 33, g);
					}
					num = num54;
				}
				break;
			}
			case 141:
			{
				bool flag111 = this.f / (int)this.numNextFrame % 4 > 1;
				if (flag111)
				{
					this.fraImgEff.drawFrameNew(this.f / (int)this.numNextFrame % 4, this.x, this.y, (int)this.Dir, 33, g);
				}
				else
				{
					this.fraImgEff.drawFrameNew_BeginSuper(this.f / (int)this.numNextFrame % 4, this.x, this.y, (int)this.Dir, 33, g);
				}
				break;
			}
			case 142:
			{
				bool flag112 = this.f < this.mPlayFrame.Length && this.fraImgEff.getImageFrame() != null;
				if (flag112)
				{
					bool flag113 = this.mPlayFrame[this.f] == 4;
					if (flag113)
					{
						g.drawRegion(this.fraImgEff.getImageFrame(), this.mPlayFrame[this.f] * this.fraImgEff.frameWidth, this.fraImgEff.frameHeight - this.fraImgEff.frameHeight / 2, this.fraImgEff.frameWidth, this.fraImgEff.frameHeight / 2, 0, (float)this.x, (float)this.y, 33);
					}
					else
					{
						g.drawRegion(this.fraImgEff.getImageFrame(), this.mPlayFrame[this.f] * this.fraImgEff.frameWidth, 0, this.fraImgEff.frameWidth, this.fraImgEff.frameHeight, 0, (float)this.x, (float)this.y, 33);
					}
				}
				break;
			}
			case 146:
			{
				int num;
				for (int num58 = 0; num58 < this.VecEff.size(); num58 = num + 1)
				{
					Point point44 = (Point)this.VecEff.elementAt(num58);
					this.fraImgEff.drawFrame(3 + point44.f % 3, point44.x / 1000, point44.y / 1000, (int)this.Dir, 3, g);
					num = num58;
				}
				break;
			}
			case 147:
				this.paint_Lucci_L2(g);
				break;
			case 148:
				this.fraImgEff.drawFrameNew(0, this.x, this.y, 0, 3, g);
				break;
			case 149:
				this.fraImgEff.drawFrameNew(this.f / (int)this.numNextFrame % this.fraImgEff.nFrame, this.x, this.y, (int)this.Dir, 33, g);
				break;
			case 151:
				this.fraImgEff.drawFrameNew((int)this.typeSub * this.fraImgEff.maxNumFrame + this.f / (int)this.numNextFrame % this.fraImgEff.maxNumFrame, this.x, this.y, (int)this.Dir, 3, g);
				break;
			case 152:
			{
				bool flag114 = this.mPlayFrame[this.f % this.mPlayFrame.Length] >= 0;
				if (flag114)
				{
					this.fraImgEff.drawFrame(this.mPlayFrame[this.f % this.mPlayFrame.Length], this.x, this.y, (int)this.Dir, 33, g);
				}
				break;
			}
			case 153:
			{
				this.fraImgEff.drawFrame(this.frame, this.x, this.y, 0, 33, g);
				this.fraImgSubEff.drawFrame(CRes.random(4), this.x, this.y - 4, 0, 33, g);
				int num;
				for (int num59 = 0; num59 < this.VecEff.size(); num59 = num + 1)
				{
					Point point45 = (Point)this.VecEff.elementAt(num59);
					bool flag115 = CRes.random(2) == 0;
					if (flag115)
					{
						this.fraImgSub2Eff.drawFrameNew(CRes.random(4) + point45.frame * 4, point45.x, point45.y, (int)this.Dir, 3, g);
					}
					num = num59;
				}
				break;
			}
			case 154:
			{
				g.setColor(this.colorpaint[this.f % this.colorpaint.Length]);
				int num;
				for (int num60 = 0; num60 < this.VecEff.size(); num60 = num + 1)
				{
					Point point46 = (Point)this.VecEff.elementAt(num60);
					Point point47 = (num60 >= this.VecEff.size() - 1) ? ((Point)this.VecEff.elementAt(0)) : ((Point)this.VecEff.elementAt(num60 + 1));
					g.drawLine(point46.x, point46.y, point47.x, point47.y);
					num = num60;
				}
				break;
			}
			case 155:
			{
				g.setColor(this.colorpaint[this.f % this.colorpaint.Length]);
				int num;
				for (int num61 = 0; num61 < this.VecEff.size(); num61 = num + 1)
				{
					Point point48 = (Point)this.VecEff.elementAt(num61);
					this.fraImgEff.drawFrameNew(point48.f % 9 + this.f % this.fraImgEff.nFrame, point48.x, point48.y, 0, 3, g);
					num = num61;
				}
				break;
			}
			case 156:
				this.fraImgEff.drawFrame((int)GameCanvas.language, this.x, this.y + this.y1000, (int)this.Dir, 33, g);
				break;
			case 157:
			{
				bool flag116 = this.f >= 10;
				if (flag116)
				{
					this.fraImgEff.drawFrameNew(3 + (this.f - 10) / 2, this.x, this.y, (int)this.Dir, 33, g);
				}
				else
				{
					this.fraImgEff.drawFrameNew(this.f / 2 % 3, this.x, this.y, (int)this.Dir, 33, g);
				}
				break;
			}
			case 158:
			{
				bool flag117 = this.f < 35;
				if (flag117)
				{
					this.fraImgSubEff.drawFrame(0, this.x1000 - this.am_duong * 3, this.y1000 + 12, (int)this.Dir, 33, g);
				}
				this.fraImgEff.drawFrame(this.f / 3 % this.fraImgEff.nFrame, this.x, this.y + 5, (int)this.Dir, 33, g);
				bool flag118 = this.f < 30;
				if (flag118)
				{
					this.fraImgSub3Eff.drawFrame(CRes.random(4), this.x1000 - this.am_duong * 13, this.y1000 + 6 - this.f / 8, (int)this.Dir, 3, g);
				}
				int num;
				for (int num62 = 0; num62 < this.VecEff.size(); num62 = num + 1)
				{
					Point point49 = (Point)this.VecEff.elementAt(num62);
					bool flag119 = CRes.random(2) == 0;
					if (flag119)
					{
						this.fraImgSub2Eff.drawFrameNew(CRes.random(4) + point49.frame * 4, point49.x, point49.y, (int)this.Dir, 3, g);
					}
					num = num62;
				}
				break;
			}
			case 160:
			{
				int num;
				for (int num63 = 0; num63 < this.VecEff.size(); num63 = num + 1)
				{
					Point point50 = (Point)this.VecEff.elementAt(num63);
					bool flag120 = !point50.isRemove;
					if (flag120)
					{
						this.fraImgEff.drawFrameNew((int)this.typeSub * this.fraImgEff.maxNumFrame + point50.frame, point50.x, point50.y, point50.dis, 3, g);
					}
					num = num63;
				}
				break;
			}
			case 161:
			{
				bool flag121 = this.f < 20 - this.randomf;
				if (flag121)
				{
					this.fraImgEff.drawFrameNew((int)this.typeSub * this.fraImgEff.maxNumFrame + this.frame, this.x, this.y, 0, 3, g);
				}
				else
				{
					bool flag122 = this.f < 20 + this.lengthM - this.randomf;
					if (flag122)
					{
						this.fraImgSubEff.drawFrameNew((int)this.typeSub * this.fraImgSubEff.maxNumFrame + this.mPlayFrameVip[this.randomf2][this.f - (20 - this.randomf)], this.x, this.y, 0, 3, g);
					}
				}
				int num;
				for (int num64 = 0; num64 < this.VecEff.size(); num64 = num + 1)
				{
					Point point51 = (Point)this.VecEff.elementAt(num64);
					this.fraImgEff.drawFrameNew((int)this.typeSub * this.fraImgEff.maxNumFrame + point51.frame, point51.x / 100, point51.y / 100, 0, 3, g);
					num = num64;
				}
				break;
			}
			case 162:
			{
				bool flag123 = this.f > 115 && this.f < 165;
				if (flag123)
				{
					this.fraImgEff.drawFrame(this.f / 3 % this.fraImgEff.maxNumFrame, this.x / 100, this.y / 100, (int)this.Dir, 3, g);
				}
				bool flag124 = this.f >= 20 && this.f < 25;
				if (flag124)
				{
					bool flag125 = this.fraImgSubEff.getImageFrame() != null;
					if (flag125)
					{
						g.drawRegion(this.fraImgSubEff.getImageFrame(), 0, 0, this.fraImgSubEff.frameWidth, 30 + (this.f - 20) * 15, 0, (float)this.x1000, (float)this.y1000, 33);
					}
				}
				else
				{
					bool flag126 = this.f >= 25;
					if (flag126)
					{
						g.drawRegion(this.fraImgSubEff.getImageFrame(), 0, 0, this.fraImgSubEff.frameWidth, 90, 0, (float)this.x1000, (float)this.y1000, 33);
					}
				}
				this.fraImgSub2Eff.drawFrame(this.f / 3 % this.fraImgSub2Eff.maxNumFrame, this.x1000, this.y1000 + 5, (int)this.Dir, 33, g);
				bool flag127 = this.f < 60;
				if (flag127)
				{
					this.fraImgSub3Eff.drawFrame(0, this.x + CRes.random_Am_0(2), this.y, (int)this.Dir, 3, g);
				}
				break;
			}
			case 163:
				this.fraImgEff.drawFrame(this.f / 3 % this.fraImgEff.maxNumFrame, this.x1000, this.y1000 - 6, (int)this.Dir, 33, g);
				break;
			case 165:
				this.fraImgEff.drawFrame(this.CFrame, this.objMainEff.x, this.objMainEff.y - this.objMainEff.hOne / 2, 0, 3, g);
				break;
			case 168:
			{
				bool flag128 = this.f < 10;
				if (flag128)
				{
					this.fraImgEff.drawFrame(this.f / 2, this.x, this.y, (int)this.Dir, 3, g);
				}
				int num;
				for (int num65 = 0; num65 < this.VecEff.size(); num65 = num + 1)
				{
					Point point52 = (Point)this.VecEff.elementAt(num65);
					bool flag129 = point52.frame < 2;
					if (flag129)
					{
						this.fraImgSubEff.drawFrameNew(point52.fSmall * this.fraImgSubEff.maxNumFrame + point52.f / 2 % this.fraImgSubEff.maxNumFrame, point52.x, point52.y, 0, 3, g);
					}
					else
					{
						this.fraImgSub2Eff.drawFrameNew(point52.fSmall * this.fraImgSub2Eff.maxNumFrame + point52.f / 2 % this.fraImgSub2Eff.maxNumFrame, point52.x, point52.y, 0, 3, g);
					}
					num = num65;
				}
				break;
			}
			case 169:
			{
				bool flag130 = this.f < 10;
				if (flag130)
				{
					this.fraImgEff.drawFrame(this.f / 2, this.x, this.y, (int)this.Dir, 3, g);
				}
				break;
			}
			case 172:
				this.fraImgEff.drawFrameNew(this.f / 3, this.x, this.y, 0, 33, g);
				break;
			case 173:
				this.fraImgEff.drawFrame(this.f / 2, this.x, this.y, (int)this.Dir, 3, g);
				break;
			case 174:
				this.fraImgEff.drawFrame(this.f / 2 % this.fraImgEff.nFrame, this.objMainEff.x, this.objMainEff.y, 0, 33, g);
				break;
			case 175:
			{
				this.fraImgSub3Eff.drawFrame(this.f / 2 % this.fraImgSub3Eff.nFrame, this.x, this.y + 73 + 10, CRes.random(2) * 2, 33, g);
				this.fraImgSub2Eff.drawFrame(0, this.x, this.y, CRes.random(2) * 2, 17, g);
				bool flag131 = this.f % 2 == 0;
				if (flag131)
				{
					this.fraImgSubEff.drawFrame(0, this.x, this.y + 12, (int)this.Dir, 3, g);
				}
				this.fraImgEff.drawFrame(3, this.x, this.y, (int)this.Dir, 3, g);
				break;
			}
			case 176:
				this.fraImgEff.drawFrame(this.f, this.x, this.y, (int)this.Dir, 3, g);
				break;
			case 177:
			{
				bool flag132 = this.f > 6 || this.f % 2 == 0;
				if (flag132)
				{
					this.fraImgEff.drawFrame(this.frame, this.x, this.y, 0, 3, g);
				}
				break;
			}
			case 178:
			{
				bool flag133 = this.f > 15;
				if (flag133)
				{
					this.fraImgEff.drawFrame(this.f % this.fraImgEff.nFrame, this.toX, this.toY - 50, 0, 3, g);
				}
				this.fraImgSub2Eff.drawFrame(0, this.toX, this.toY, 0, 3, g);
				this.fraImgSubEff.drawFrame(this.f % this.fraImgSubEff.nFrame, this.x, this.y, 0, 3, g);
				break;
			}
			}
		}
		catch (Exception)
		{
			mSystem.outz("loi End typeeff=" + this.typeEffect.ToString());
		}
	}

	// Token: 0x060001B0 RID: 432 RVA: 0x0002782C File Offset: 0x00025A2C
	private void paint_Lucci_L2(mGraphics g)
	{
		bool flag = this.frame == 1;
		if (flag)
		{
			for (int i = 0; i < this.VecEff.size(); i++)
			{
				Point point = (Point)this.VecEff.elementAt(i);
				bool flag2 = this.fraImgSubEff != null && this.fraImgSubEff.imgFrame != null;
				if (flag2)
				{
					this.fraImgSubEff.drawFrameNew(CRes.random(this.fraImgSubEff.maxNumFrame), point.x, point.y, 0, 3, g);
				}
				this.fraImgEff.drawFrameNew(6 + point.frame, point.x, point.y, 0, 3, g);
			}
		}
		else
		{
			for (int j = 0; j < this.VecEff.size(); j++)
			{
				Point point2 = (Point)this.VecEff.elementAt(j);
				this.fraImgEff.drawFrameNew(6 + point2.frame, point2.x, point2.y, 0, 3, g);
			}
		}
		bool flag3 = this.f < this.fRemove;
		if (flag3)
		{
			this.fraImgEff.drawFrameNew(6 + this.mframe[this.f], this.x, this.y, (int)this.Dir, 3, g);
		}
	}

	// Token: 0x060001B1 RID: 433 RVA: 0x00027994 File Offset: 0x00025B94
	private void paintNo_Dat_New(mGraphics g)
	{
		int num = 0;
		bool flag = this.f < 2;
		if (flag)
		{
			num = 1;
		}
		else
		{
			bool flag2 = this.f > this.fRemove - 4;
			if (flag2)
			{
				num = 2 - (this.fRemove - this.f) / 2;
			}
		}
		this.fraImgEff.drawFrameNew(this.frame * 3 + num, this.x, this.y, (int)this.Dir, 3, g);
	}

	// Token: 0x060001B2 RID: 434 RVA: 0x00027A0C File Offset: 0x00025C0C
	public override void paint(mGraphics g, int xOBJ, int yOBJ)
	{
		int typeEffect = this.typeEffect;
		int num = typeEffect;
		if (num != 95)
		{
			if (num != 100)
			{
				if (num - 144 <= 1)
				{
					for (int i = 0; i < this.VecEff.size(); i++)
					{
						Line line = (Line)this.VecEff.elementAt(i);
						bool flag = line != null;
						if (flag)
						{
							int color = 0;
							bool flag2 = i / 2 < this.colorpaint.Length;
							if (flag2)
							{
								color = this.colorpaint[i / 2];
							}
							g.setColor(color);
							g.drawLine(xOBJ + line.x0 / 1000, yOBJ + line.y0 / 1000, xOBJ + line.x1 / 1000, yOBJ + line.y1 / 1000);
							bool is2Line = line.is2Line;
							if (is2Line)
							{
								g.drawLine(xOBJ + line.x0 / 1000 + 1, yOBJ + line.y0 / 1000, xOBJ + line.x1 / 1000 + 1, yOBJ + line.y1 / 1000);
							}
						}
					}
				}
			}
			else
			{
				this.fraImgEff.drawFrame(this.f / (int)this.numNextFrame % this.fraImgEff.nFrame, this.x + xOBJ, this.y + yOBJ, (int)this.Dir, 3, g);
			}
		}
		else
		{
			for (int j = 0; j < this.VecEff.size(); j++)
			{
				Point point = (Point)this.VecEff.elementAt(j);
				g.setColor(15009800);
				g.fillRect(point.x + xOBJ, point.y + yOBJ, 1, point.dis);
			}
		}
	}

	// Token: 0x060001B3 RID: 435 RVA: 0x00027BFC File Offset: 0x00025DFC
	public override void update()
	{
		int num = this.f;
		this.f = num + 1;
		switch (this.typeEffect)
		{
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 8:
		case 9:
		case 10:
		case 12:
		case 19:
		case 20:
		case 26:
		case 34:
		case 42:
		case 45:
		case 46:
		case 52:
		case 53:
		case 57:
		case 58:
		case 61:
		case 63:
		case 64:
		case 65:
		case 66:
		case 68:
		case 71:
		case 77:
		case 80:
		case 81:
		case 82:
		case 86:
		case 89:
		case 90:
		case 91:
		case 92:
		case 100:
		case 109:
		case 118:
		case 121:
		case 122:
		case 123:
		case 124:
		case 125:
		case 133:
		case 134:
		case 136:
		case 139:
		case 141:
		case 148:
		case 149:
		case 151:
		case 159:
		case 170:
		case 171:
		case 178:
		{
			this.x += this.vx;
			this.y += this.vy;
			bool flag = this.x > this.toX;
			if (flag)
			{
				this.x = this.toX;
				bool flag2 = this.y < this.toY + 20;
				if (flag2)
				{
					this.y += 5;
				}
			}
			bool flag3 = this.f >= this.fRemove;
			if (flag3)
			{
				this.removeEff();
			}
			return;
		}
		case 6:
		{
			bool flag4 = this.typeSub == 3;
			if (flag4)
			{
				for (int i = 0; i < this.VecEff.size(); i = num + 1)
				{
					Point point = (Point)this.VecEff.elementAt(i);
					Point point2 = point;
					Point point3 = point2;
					num = point2.f;
					point3.f = num + 1;
					bool flag5 = point.f >= this.fraImgSub2Eff.maxNumFrame;
					if (flag5)
					{
						this.VecEff.removeElementAt(i);
					}
					num = i;
				}
				bool flag6 = this.f < this.fRemove && this.f % 3 == 0 && !GameCanvas.lowGraphic;
				if (flag6)
				{
					Point o = new Point(this.x, this.y);
					this.VecEff.addElement(o);
				}
			}
			this.x += this.vx;
			this.y += this.vy;
			this.vy += this.vMax;
			bool flag7 = this.f >= this.fRemove && (this.typeSub != 3 || this.VecEff.size() == 0);
			if (flag7)
			{
				bool flag8 = this.typeEffect == 128;
				if (flag8)
				{
					GameScreen.addEffectEnd(92, 0, this.x / 100, this.y / 100, this.Dir, this.objMainEff);
				}
				this.removeEff();
			}
			return;
		}
		case 7:
		{
			for (int j = 0; j < this.VecEff.size(); j = num + 1)
			{
				Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(j);
				point_Focus.update_Vx_Vy();
				bool flag9 = point_Focus.f >= point_Focus.fRe;
				if (flag9)
				{
					this.VecEff.removeElement(point_Focus);
					LoginScreen.addEffectEnd(1, 0, point_Focus.toX, point_Focus.toY, this.Dir, this.objMainEff);
					num = j;
					j = num - 1;
				}
				num = j;
			}
			bool flag10 = this.f == 10 || this.f == 13 || this.f == 16 || this.f == 19;
			if (flag10)
			{
				this.toX = this.x + ((this.objFireMain.Dir != 0) ? 140 : -140);
				this.toY = this.y;
				base.setAngle();
				int num2 = this.toX - this.x;
				int num3 = this.toY - this.y;
				int frameAngle = CRes.angle(num2, num3);
				Point_Focus point_Focus2 = new Point_Focus();
				point_Focus2 = base.create_Speed(num2, num3, point_Focus2);
				point_Focus2.frame = base.setFrameAngle(frameAngle);
				this.VecEff.addElement(point_Focus2);
				LoginScreen.addEffectEnd(3, 0, this.x, this.y, this.Dir, this.objMainEff);
			}
			bool flag11 = this.f >= this.fRemove && this.VecEff.size() == 0;
			if (flag11)
			{
				this.removeEff();
			}
			return;
		}
		case 11:
			this.updateZoro4();
			return;
		case 13:
			this.updateENDLuffy1();
			return;
		case 14:
		case 18:
		{
			this.y += this.vy;
			bool flag12 = this.f >= this.fRemove;
			if (flag12)
			{
				this.removeEff();
			}
			return;
		}
		case 15:
		{
			int num4 = 5;
			bool flag13 = this.f == 5;
			if (flag13)
			{
				int num5 = 20;
				bool flag14 = this.Dir == 0;
				if (flag14)
				{
					num5 = -20;
				}
				LoginScreen.addEffectEnd(16, 1, this.x + num5, this.objMainEff.y - this.objFireMain.hOne / 2 - 10 + num4, this.Dir, this.objMainEff);
			}
			bool flag15 = this.f == 10;
			if (flag15)
			{
				int num6 = 30;
				bool flag16 = this.Dir == 0;
				if (flag16)
				{
					num6 = -30;
				}
				LoginScreen.addEffectEnd(16, 2, this.x + num6, this.objFireMain.y - this.objFireMain.hOne / 2 + num4, this.Dir, this.objMainEff);
			}
			bool flag17 = this.f == 15;
			if (flag17)
			{
				int num7 = 20;
				bool flag18 = this.Dir == 0;
				if (flag18)
				{
					num7 = -20;
				}
				LoginScreen.addEffectEnd(16, 1, this.x + num7, this.objFireMain.y - this.objFireMain.hOne / 2 - 10 + num4, this.Dir, this.objMainEff);
			}
			bool flag19 = this.f >= this.fRemove;
			if (flag19)
			{
				this.removeEff();
			}
			return;
		}
		case 16:
		case 72:
		{
			this.x += this.vx;
			bool flag20 = this.f >= this.fRemove;
			if (flag20)
			{
				this.removeEff();
			}
			return;
		}
		case 17:
		{
			bool flag21 = this.f >= this.fRemove + 6;
			if (flag21)
			{
				this.removeEff();
			}
			return;
		}
		case 21:
		case 105:
			this.updateXuyenGiap();
			return;
		case 22:
			this.updateHutMP_HP();
			return;
		case 23:
			this.updatePhanDamage();
			return;
		case 24:
			this.updateFocusTouch();
			return;
		case 25:
			this.updateLuffy_6();
			return;
		case 27:
			this.updateZoro9();
			return;
		case 28:
		{
			this.y += this.vy;
			bool flag22 = this.f >= this.fRemove;
			if (flag22)
			{
				this.removeEff();
			}
			bool flag23 = this.f % 6 == 3 && this.f < 16;
			if (flag23)
			{
				GameScreen.addEffectEnd(50, 0, this.x + CRes.random_Am_0(20), this.y, this.Dir, this.objMainEff);
			}
			bool flag24 = this.objTo != null && this.objTo.Action != 4;
			if (flag24)
			{
				this.x = this.objTo.x;
				this.y = this.objTo.y - this.objTo.hOne / 2;
			}
			return;
		}
		case 29:
			this.updateENDSanji2();
			return;
		case 30:
		case 144:
		case 145:
			this.updateLineIn();
			return;
		case 31:
		{
			this.y += this.vy;
			bool flag25 = this.f == 6;
			if (flag25)
			{
				Point point4 = new Point(this.x, this.y);
				point4.vy = 0;
				point4.dis = 1;
				point4.frame = 0;
				point4.fRe = 10;
				this.VecEff.addElement(point4);
			}
			bool flag26 = this.f == 8;
			if (flag26)
			{
				this.vy = -25;
			}
			for (int k = 0; k < this.VecEff.size(); k = num + 1)
			{
				Point point5 = (Point)this.VecEff.elementAt(k);
				point5.update();
				bool flag27 = point5.dis == 1;
				if (flag27)
				{
					point5.vy = this.vy;
				}
				bool flag28 = point5.f >= point5.fRe;
				if (flag28)
				{
					this.VecEff.removeElement(point5);
					num = k;
					k = num - 1;
				}
				num = k;
			}
			bool flag29 = this.f < 10 && this.f % 3 == 2;
			if (flag29)
			{
				for (int l = 0; l < 4; l = num + 1)
				{
					Point point6 = new Point(this.x + CRes.random_Am_0(20), this.y - CRes.random(30) + 10);
					point6.vy = -2 - CRes.random(4);
					point6.dis = 0;
					point6.frame = CRes.random(this.fraImgSubEff.nFrame);
					point6.fRe = CRes.random(12, 20);
					this.VecEff.addElement(point6);
					num = l;
				}
			}
			bool flag30 = this.f >= this.fRemove && this.VecEff.size() == 0;
			if (flag30)
			{
				this.removeEff();
			}
			return;
		}
		case 32:
		{
			bool flag31 = this.objTo != null && this.f > 5;
			if (flag31)
			{
				this.x = this.objTo.x;
				this.y = this.objTo.y;
			}
			bool flag32 = this.f < this.fRemove && (this.f % 3 == 2 || this.f < 3);
			if (flag32)
			{
				for (int m = 0; m < 4; m = num + 1)
				{
					Point point7 = new Point(this.x + CRes.random_Am_0(20), this.y + CRes.random(30) - 72);
					point7.vy = 2 + CRes.random(4);
					point7.dis = 0;
					point7.frame = CRes.random(this.fraImgSubEff.nFrame);
					point7.fRe = CRes.random(12, 20);
					this.VecEff.addElement(point7);
					num = m;
				}
			}
			bool flag33 = this.f == 5;
			if (flag33)
			{
				this.vy = 0;
			}
			this.y += this.vy;
			for (int n = 0; n < this.VecEff.size(); n = num + 1)
			{
				Point point8 = (Point)this.VecEff.elementAt(n);
				point8.update();
				bool flag34 = point8.dis == 1;
				if (flag34)
				{
					point8.vy = this.vy;
				}
				bool flag35 = point8.f >= point8.fRe;
				if (flag35)
				{
					this.VecEff.removeElement(point8);
					num = n;
					n = num - 1;
				}
				num = n;
			}
			bool flag36 = this.f >= this.fRemove && this.VecEff.size() == 0;
			if (flag36)
			{
				this.removeEff();
			}
			return;
		}
		case 33:
		{
			bool flag37 = this.f % 5 == 0;
			if (flag37)
			{
				int num8 = 28;
				bool flag38 = this.Dir == 0;
				if (flag38)
				{
					num8 = -28;
				}
				sbyte subtype = 2;
				LoginScreen.addEffectEnd(25, (int)subtype, this.objMainEff.x + num8, this.objMainEff.y - this.objMainEff.dy - this.objMainEff.hOne / 3 * 2 + 10, this.Dir, this.objMainEff);
			}
			bool flag39 = this.f >= this.fRemove;
			if (flag39)
			{
				this.removeEff();
			}
			return;
		}
		case 35:
		{
			bool flag40 = this.f >= this.fRemove && this.VecEff.size() == 0;
			if (flag40)
			{
				this.removeEff();
			}
			return;
		}
		case 36:
		{
			bool flag41 = this.f <= this.fRemove;
			if (flag41)
			{
				this.x += this.vx;
				this.y += this.vy;
			}
			bool flag42 = this.f > this.fRemove;
			if (flag42)
			{
				this.removeEff();
			}
			return;
		}
		case 37:
			this.updateSanji_5();
			return;
		case 38:
		case 138:
			this.updateNami_4();
			return;
		case 39:
		{
			bool flag43 = this.objTo != null;
			if (flag43)
			{
				this.x = this.objTo.x;
				this.y = this.objTo.y - this.objTo.hOne - 20;
			}
			bool flag44 = this.f <= this.fRemove;
			if (flag44)
			{
				return;
			}
			this.removeEff();
			bool flag45 = this.objTo != null;
			if (flag45)
			{
				bool flag46 = this.typeSub != 3;
				if (flag46)
				{
					GameScreen.addEffectEnd_ObjTo(40, (int)this.typeSub, this.objTo.x, this.objTo.y - this.objTo.hOne - 20, this.objTo.ID, this.objTo.typeObject, this.typeSub, this.objMainEff);
				}
				else
				{
					GameScreen.addEffectEnd_ObjTo(175, 0, this.objTo.x, this.objTo.y - this.objTo.hOne - 20, this.objTo.ID, this.objTo.typeObject, this.typeSub, this.objMainEff);
				}
				GameScreen.addEffectEnd(108, 8, this.objTo.x, this.objTo.y - this.objTo.hOne / 2, 0, this.objMainEff);
			}
			else
			{
				bool flag47 = this.typeSub != 3;
				if (flag47)
				{
					GameScreen.addEffectEnd(40, (int)this.typeSub, this.x, this.y, this.Dir, this.objMainEff);
				}
				else
				{
					GameScreen.addEffectEnd(175, 0, this.x, this.y, this.Dir, this.objMainEff);
				}
			}
			return;
		}
		case 40:
		{
			bool flag48 = this.objTo != null;
			if (flag48)
			{
				this.x = this.objTo.x;
				this.y = this.objTo.y - this.objTo.hOne - 20;
				bool flag49 = this.f == 4;
				if (flag49)
				{
					GameScreen.addEffectEnd(38, 0, this.objTo.x, this.objTo.y - this.objTo.hOne / 2, this.Dir, this.objMainEff);
				}
			}
			bool flag50 = this.f == 4 && !GameCanvas.lowGraphic;
			if (flag50)
			{
				int tile = GameCanvas.loadmap.getTile(this.x, this.y + 85);
				bool flag51 = tile == 0 || tile == 2;
				if (flag51)
				{
					GameScreen.addEffectEnd(63, 0, this.x - 10, this.y + 75, this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(110, 0, this.x, this.y + 75, this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(63, 0, this.x + 10, this.y + 75, this.Dir, this.objMainEff);
				}
			}
			bool flag52 = this.f > this.fRemove;
			if (flag52)
			{
				this.removeEff();
			}
			return;
		}
		case 41:
		{
			bool flag53 = this.typeSub == 1 && this.f == 1 && this.objTo != null;
			if (flag53)
			{
				this.x = this.objTo.x;
				this.y = this.objTo.y - this.objTo.hOne - 20;
				GameScreen.addEffectEnd_ObjTo(39, 0, this.objTo.x, this.objTo.y - this.objTo.hOne - 20, this.objTo.ID, this.objTo.typeObject, 0, this.objMainEff);
			}
			bool flag54 = this.f > this.fRemove;
			if (flag54)
			{
				this.removeEff();
			}
			return;
		}
		case 44:
		{
			bool flag55 = this.f % 4 == 0;
			if (flag55)
			{
				int num9 = 25;
				bool flag56 = this.Dir == 0;
				if (flag56)
				{
					num9 = -25;
				}
				LoginScreen.addEffectEnd(35, 0, this.objFireMain.x + num9, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 3 * 2 + 10, this.Dir, this.objMainEff);
			}
			bool flag57 = this.f >= this.fRemove;
			if (flag57)
			{
				this.removeEff();
			}
			return;
		}
		case 47:
		{
			for (int num10 = 0; num10 < this.VecEff.size(); num10 = num + 1)
			{
				Point point9 = (Point)this.VecEff.elementAt(num10);
				point9.update();
				bool flag58 = point9.f >= point9.fRe;
				if (flag58)
				{
					this.VecEff.removeElement(point9);
					num = num10;
					num10 = num - 1;
				}
				num = num10;
			}
			bool flag59 = this.VecEff.size() == 0;
			if (flag59)
			{
				this.removeEff();
			}
			return;
		}
		case 48:
		case 50:
		case 120:
		{
			for (int num11 = 0; num11 < this.VecEff.size(); num11 = num + 1)
			{
				Point point10 = (Point)this.VecEff.elementAt(num11);
				point10.update();
				Point point2 = point10;
				Point point11 = point2;
				num = point2.vy;
				point11.vy = num + 1;
				num = num11;
			}
			bool flag60 = this.f >= this.fRemove;
			if (flag60)
			{
				this.removeEff();
			}
			return;
		}
		case 49:
		{
			this.x += this.vx;
			this.y += this.vy;
			bool flag61 = this.f >= this.fRemove;
			if (flag61)
			{
				GameScreen.addEffectEnd(50, 0, this.objTo.x, this.objTo.y - this.objTo.hOne / 2, this.Dir, this.objMainEff);
				base.setAva(2, this.objTo);
				this.removeEff();
			}
			return;
		}
		case 51:
		{
			bool flag62 = this.f >= this.fRemove;
			if (flag62)
			{
				this.removeEff();
			}
			return;
		}
		case 54:
			this.updateLuffy_S1_Final();
			return;
		case 55:
		{
			bool flag63 = this.objTo != null;
			if (flag63)
			{
				this.x = this.objTo.x;
				this.y = this.objTo.y;
			}
			bool flag64 = this.f >= this.fRemove;
			if (flag64)
			{
				this.removeEff();
			}
			return;
		}
		case 56:
		{
			bool flag65 = this.f == 3 && this.objTo != null && this.objTo.Action != 4;
			if (flag65)
			{
				this.objTo.x = this.x;
				this.objTo.y = this.y;
				this.objTo.toX = this.x;
				this.objTo.toY = this.y;
			}
			bool flag66 = this.f >= this.fRemove;
			if (flag66)
			{
				this.objTo.isTanHinh = false;
				this.removeEff();
			}
			return;
		}
		case 59:
			this.updateRock();
			return;
		case 60:
		case 107:
		{
			for (int num12 = 0; num12 < this.VecEff.size(); num12 = num + 1)
			{
				Point point12 = (Point)this.VecEff.elementAt(num12);
				point12.update();
				num = num12;
			}
			bool flag67 = this.f >= this.fRemove;
			if (flag67)
			{
				this.removeEff();
			}
			return;
		}
		case 62:
		{
			bool flag68 = this.f <= this.fRemove - 20 && this.f % 2 == 1;
			if (flag68)
			{
				Point point13 = new Point(this.x, this.y);
				bool flag69 = this.f == 1;
				if (flag69)
				{
					point13.frame = 0;
				}
				else
				{
					bool flag70 = this.f == this.fRemove - 20;
					if (flag70)
					{
						point13.frame = 2;
					}
					else
					{
						point13.frame = 1;
					}
				}
				this.VecEff.addElement(point13);
			}
			this.x += this.vx;
			bool flag71 = this.f >= this.fRemove;
			if (flag71)
			{
				this.removeEff();
			}
			return;
		}
		case 69:
		case 83:
		{
			bool flag72 = GameCanvas.timeNow - this.timeBegin >= (long)this.timeEnd;
			if (flag72)
			{
				this.removeEff();
			}
			for (int num13 = 0; num13 < this.VecEff.size(); num13 = num + 1)
			{
				Point point14 = (Point)this.VecEff.elementAt(num13);
				bool flag73 = (point14.vy > 0 && point14.y >= 0) || (point14.vy < 0 && point14.y <= -30);
				if (flag73)
				{
					point14.vy = -point14.vy;
				}
				Point point2 = point14;
				point2.y += point14.vy;
				num = num13;
			}
			return;
		}
		case 70:
		{
			for (int num14 = 0; num14 < this.VecEff.size(); num14 = num + 1)
			{
				Point point15 = (Point)this.VecEff.elementAt(num14);
				bool flag74 = (point15.vy > 0 && point15.y >= 0) || (point15.vy < 0 && point15.y <= -30);
				if (flag74)
				{
					point15.vy = -point15.vy;
				}
				Point point2 = point15;
				point2.y += point15.vy;
				num = num14;
			}
			bool flag75 = this.f == 30;
			if (flag75)
			{
				this.objTo.x = this.toX;
				this.objTo.y = this.toY;
			}
			bool flag76 = this.f >= this.fRemove;
			if (flag76)
			{
				this.removeEff();
			}
			return;
		}
		case 73:
		case 74:
		{
			bool flag77 = this.typeSub == 3;
			if (flag77)
			{
				this.x += this.vMax;
				this.toY += this.vMax;
			}
			else
			{
				bool flag78 = this.typeSub == 0;
				if (flag78)
				{
					this.toX -= this.vMax;
					this.y += this.vMax;
				}
				else
				{
					bool flag79 = this.typeSub == 1;
					if (flag79)
					{
						this.x -= this.vMax;
						this.toY -= this.vMax;
					}
					else
					{
						bool flag80 = this.typeSub == 2;
						if (flag80)
						{
							this.toX += this.vMax;
							this.y -= this.vMax;
						}
						else
						{
							bool flag81 = this.typeSub == 4;
							if (flag81)
							{
								this.toX += this.vMax;
								this.y += this.vMax;
							}
						}
					}
				}
			}
			bool flag82 = this.f >= this.fRemove;
			if (flag82)
			{
				this.removeEff();
			}
			return;
		}
		case 75:
		case 78:
		{
			bool flag83 = this.f > 10;
			if (flag83)
			{
				this.x += this.vx;
				this.y += this.vy;
			}
			bool flag84 = this.typeSub != 1 && this.f < this.fRemove + 10;
			if (flag84)
			{
				int num15 = CRes.random(1, 4);
				bool flag85 = this.typeSub == 0;
				if (flag85)
				{
					num15 = 1;
				}
				for (int num16 = 0; num16 < num15; num16 = num + 1)
				{
					Point point16 = new Point(this.x + CRes.random_Am_0(4), this.y + CRes.random_Am_0(4));
					point16.frame = CRes.random(3);
					point16.vy = -1 + CRes.random(3);
					point16.vx = CRes.random_Am_0(2);
					point16.fRe = 8 + CRes.random(4);
					this.VecEff.addElement(point16);
					num = num16;
				}
			}
			for (int num17 = 0; num17 < this.VecEff.size(); num17 = num + 1)
			{
				Point point17 = (Point)this.VecEff.elementAt(num17);
				point17.update();
				Point point2 = point17;
				Point point18 = point2;
				num = point2.vy;
				point18.vy = num + 1;
				bool flag86 = point17.f >= point17.fRe;
				if (flag86)
				{
					this.VecEff.removeElement(point17);
					num = num17;
					num17 = num - 1;
				}
				num = num17;
			}
			bool flag87 = this.f >= this.fRemove + 10 && this.VecEff.size() == 0;
			if (flag87)
			{
				this.removeEff();
			}
			return;
		}
		case 76:
		{
			for (int num18 = 0; num18 < this.VecEff.size(); num18 = num + 1)
			{
				Point point19 = (Point)this.VecEff.elementAt(num18);
				point19.update();
				bool flag88 = point19.f >= point19.fRe;
				if (flag88)
				{
					this.VecEff.removeElement(point19);
					num = num18;
					num18 = num - 1;
				}
				num = num18;
			}
			bool flag89 = this.VecEff.size() == 0;
			if (flag89)
			{
				this.removeEff();
			}
			return;
		}
		case 79:
		{
			this.y += this.vy;
			bool flag90 = this.f >= this.fRemove;
			if (flag90)
			{
				this.removeEff();
			}
			return;
		}
		case 84:
		{
			for (int num19 = 0; num19 < this.VecEff.size(); num19 = num + 1)
			{
				Point point20 = (Point)this.VecEff.elementAt(num19);
				point20.update();
				bool flag91 = point20.f > point20.fRe;
				if (flag91)
				{
					bool flag92 = point20.f - point20.fRe == 2;
					if (flag92)
					{
						point20.frame = 2;
					}
					bool flag93 = point20.f - point20.fRe == 4;
					if (flag93)
					{
						point20.frame = 3;
					}
					bool flag94 = point20.f - point20.fRe == 6;
					if (flag94)
					{
						this.VecEff.removeElement(point20);
						num = num19;
						num19 = num - 1;
					}
				}
				num = num19;
			}
			bool flag95 = this.VecEff.size() == 0 && this.f >= this.fRemove;
			if (flag95)
			{
				this.removeEff();
			}
			return;
		}
		case 85:
			this.updateLineBuff();
			return;
		case 87:
		case 128:
		{
			this.x += this.vx;
			this.y += this.vy;
			this.vy += this.vMax;
			bool flag96 = this.f < this.fRemove;
			if (flag96)
			{
				return;
			}
			mSystem.outz("vo day 1 typesub = " + this.typeSub.ToString());
			bool flag97 = this.typeEffect == 128;
			if (flag97)
			{
				mSystem.outz("vo day 2 typesub = " + this.typeSub.ToString());
				bool flag98 = this.typeSub > 20;
				if (flag98)
				{
					GameScreen.addEffectEnd(4, 0, this.x / 100, this.y / 100, this.Dir, this.objMainEff);
				}
				else
				{
					GameScreen.addEffectEnd(92, 0, this.x / 100, this.y / 100, this.Dir, this.objMainEff);
				}
			}
			this.removeEff();
			return;
		}
		case 88:
		{
			this.y += this.vy;
			bool flag99 = this.vy == 0 && this.mPlayFrame[this.f] == 4;
			if (flag99)
			{
				this.vy = 3;
			}
			bool flag100 = this.f >= this.fRemove;
			if (flag100)
			{
				this.removeEff();
			}
			return;
		}
		case 93:
		{
			for (int num20 = 0; num20 < this.VecEff.size(); num20 = num + 1)
			{
				Point point21 = (Point)this.VecEff.elementAt(num20);
				point21.update();
				Point point2 = point21;
				Point point22 = point2;
				num = point2.vy;
				point22.vy = num + 1;
				bool flag101 = point21.f >= point21.fRe;
				if (flag101)
				{
					this.VecEff.removeElement(point21);
					num = num20;
					num20 = num - 1;
				}
				num = num20;
			}
			bool flag102 = this.f > 0 && this.VecEff.size() == 0;
			if (flag102)
			{
				this.removeEff();
			}
			return;
		}
		case 95:
			for (int num21 = 0; num21 < this.VecEff.size(); num21 = num + 1)
			{
				Point point23 = (Point)this.VecEff.elementAt(num21);
				point23.update();
				bool flag103 = point23.y < point23.y2 - 60;
				if (flag103)
				{
					point23.y = point23.y2;
				}
				num = num21;
			}
			return;
		case 96:
		{
			for (int num22 = 0; num22 < this.VecEff.size(); num22 = num + 1)
			{
				Point_Focus point_Focus3 = (Point_Focus)this.VecEff.elementAt(num22);
				Point_Focus point_Focus4 = point_Focus3;
				Point_Focus point_Focus5 = point_Focus4;
				num = point_Focus4.f;
				point_Focus5.f = num + 1;
				bool flag104 = point_Focus3.f < point_Focus3.fRe;
				if (flag104)
				{
					point_Focus4 = point_Focus3;
					point_Focus4.x += point_Focus3.vx;
					point_Focus4 = point_Focus3;
					point_Focus4.y += point_Focus3.vy;
				}
				else
				{
					bool flag105 = this.objTo != null;
					if (flag105)
					{
						point_Focus3.vx = 0;
						point_Focus3.vy = 0;
						point_Focus3.x = this.objTo.x;
						point_Focus3.y = this.objTo.y - this.objTo.hOne / 2;
					}
					bool flag106 = this.objTo == null || this.objTo.Action == 4 || this.objTo.returnAction();
					if (flag106)
					{
						this.VecEff.removeAllElements();
						this.removeEff();
					}
				}
				num = num22;
			}
			bool flag107 = GameCanvas.timeNow - this.time < (long)this.timeRemove;
			if (flag107)
			{
				return;
			}
			for (int num23 = 0; num23 < this.VecEff.size(); num23 = num + 1)
			{
				Point_Focus point_Focus6 = (Point_Focus)this.VecEff.elementAt(num23);
				for (int num24 = 0; num24 < 3; num24 = num + 1)
				{
					GameScreen.addEffectEnd(4, 0, point_Focus6.x - 20 + 20 * num24, point_Focus6.y - 20 + num24 % 2 * 20, this.Dir, this.objMainEff);
					num = num24;
				}
				num = num23;
			}
			this.VecEff.removeAllElements();
			this.removeEff();
			return;
		}
		case 97:
		{
			this.x += this.vx;
			this.y += this.vy;
			bool flag108 = this.f == this.fRemove && this.objTo != null;
			if (flag108)
			{
				GameScreen.addEffectEnd(35, 0, this.objTo.x, this.objTo.y - this.objTo.hOne / 2, this.Dir, this.objMainEff);
			}
			bool flag109 = this.f >= this.fRemove + 5;
			if (flag109)
			{
				this.removeEff();
			}
			return;
		}
		case 98:
		case 99:
		{
			bool flag110 = this.f % 3 == 0 && this.f <= this.fRemove - 5;
			if (flag110)
			{
				Point o2 = new Point(this.x + CRes.random_Am_0(30), this.y + CRes.random_Am_0(10));
				this.VecEff.addElement(o2);
			}
			bool flag111 = this.f >= this.fRemove && this.VecEff.size() == 0;
			if (flag111)
			{
				this.removeEff();
			}
			for (int num25 = 0; num25 < this.VecEff.size(); num25 = num + 1)
			{
				Point point24 = (Point)this.VecEff.elementAt(num25);
				Point point2 = point24;
				Point point25 = point2;
				num = point2.f;
				point25.f = num + 1;
				bool flag112 = point24.f >= 5;
				if (flag112)
				{
					this.VecEff.removeElement(point24);
					num = num25;
					num25 = num - 1;
				}
				num = num25;
			}
			return;
		}
		case 101:
		case 104:
		{
			bool flag113 = this.f == 3 || this.f == 6;
			if (flag113)
			{
				int num26 = CRes.random(4, 7);
				for (int num27 = 0; num27 < num26; num27 = num + 1)
				{
					Point point26 = new Point(this.x + CRes.random_Am_0(20), this.y + CRes.random_Am_0(10));
					point26.fRe = CRes.random(8, 11);
					point26.vy = -CRes.random(5, 7);
					this.VecEff.addElement(point26);
					num = num27;
				}
			}
			for (int num28 = 0; num28 < this.VecEff.size(); num28 = num + 1)
			{
				Point point27 = (Point)this.VecEff.elementAt(num28);
				point27.update();
				bool flag114 = point27.f > point27.fRe;
				if (flag114)
				{
					this.VecEff.removeElement(point27);
					num = num28;
					num28 = num - 1;
				}
				num = num28;
			}
			bool flag115 = this.VecEff.size() == 0 && this.f >= this.fRemove;
			if (flag115)
			{
				this.removeEff();
			}
			return;
		}
		case 102:
		{
			bool flag116 = this.objTo != null;
			if (flag116)
			{
				bool flag117 = this.typeSub == 0;
				if (flag117)
				{
					this.x = this.objTo.x + 6;
				}
				else
				{
					this.x = this.objTo.x - 6;
				}
				this.y = this.objTo.y - this.objTo.hOne / 2 + 14;
			}
			bool flag118 = this.f >= this.fRemove;
			if (flag118)
			{
				this.removeEff();
			}
			return;
		}
		case 103:
		{
			bool flag119 = this.f == 15;
			if (flag119)
			{
				this.levelPaint = -1;
			}
			bool flag120 = this.f >= this.fRemove;
			if (flag120)
			{
				this.removeEff();
			}
			return;
		}
		case 106:
		{
			bool flag121 = this.objTo != null && this.objTo.Action == 4;
			if (flag121)
			{
				this.objTo.Action = 2;
				this.objTo.frame = 10;
			}
			bool flag122 = this.f >= this.fRemove;
			if (flag122)
			{
				this.removeEff();
			}
			return;
		}
		case 108:
		{
			for (int num29 = 0; num29 < this.VecEff.size(); num29 = num + 1)
			{
				Point point28 = (Point)this.VecEff.elementAt(num29);
				bool flag123 = point28.f % 2 == 0;
				if (flag123)
				{
					Point point2 = point28;
					Point point29 = point2;
					num = point2.vy;
					point29.vy = num + 1;
				}
				point28.update();
				num = num29;
			}
			bool flag124 = this.f >= this.fRemove;
			if (flag124)
			{
				this.removeEff();
			}
			return;
		}
		case 110:
		case 115:
			this.updateRockNew();
			return;
		case 111:
		{
			bool flag125 = this.objTo != null;
			if (flag125)
			{
				this.x = this.objTo.x;
				this.y = this.objTo.y;
			}
			for (int num30 = 0; num30 < this.VecEff.size(); num30 = num + 1)
			{
				Point point30 = (Point)this.VecEff.elementAt(num30);
				point30.update();
				bool flag126 = point30.y < -210;
				if (flag126)
				{
					this.VecEff.removeElementAt(num30);
					num = num30;
					num30 = num - 1;
				}
				num = num30;
			}
			bool flag127 = this.f % 2 == 1;
			if (flag127)
			{
				for (int num31 = 0; num31 < 3; num31 = num + 1)
				{
					Point point31 = new Point(CRes.random_Am_0(20), -5 + CRes.random(10));
					point31.vy = -CRes.random(12, 20);
					point31.frame = CRes.random(this.fraImgSubEff.nFrame);
					this.VecEff.addElement(point31);
					num = num31;
				}
			}
			bool flag128 = this.f >= this.fRemove;
			if (flag128)
			{
				this.removeEff();
			}
			return;
		}
		case 112:
		{
			bool flag129 = this.f >= this.fRemove - 6;
			if (flag129)
			{
				this.frame = 3 - (this.fRemove - this.f) / 2;
			}
			else
			{
				this.frame = 0;
			}
			bool flag130 = this.f >= this.fRemove;
			if (flag130)
			{
				this.removeEff();
			}
			return;
		}
		case 113:
		{
			bool flag131 = this.f == 1;
			if (flag131)
			{
				GameScreen.addEffectEnd(63, 3, this.x, this.y, this.Dir, this.objMainEff);
			}
			bool flag132 = this.f < 8;
			if (flag132)
			{
				int num32 = 4;
				int num33 = -1;
				bool flag133 = this.typeSub == 1;
				if (flag133)
				{
					num32 = 5;
					num33 = 0;
				}
				else
				{
					bool flag134 = this.typeSub == 2;
					if (flag134)
					{
						num32 = 8;
					}
				}
				int num34 = 360 / num32;
				int num35 = CRes.random(num34);
				for (int num36 = 0; num36 < num32; num36 = num + 1)
				{
					Point point32 = new Point();
					point32.x = this.x * 1000 + CRes.getcos(CRes.fixangle(num35 + num34 * num36) + this.f * 5) * this.f * this.vMax;
					point32.y = this.y * 1000 + CRes.getsin(CRes.fixangle(num35 + num34 * num36) + this.f * 5) * this.f * (this.vMax - 4);
					point32.dis = this.f % 1;
					point32.fSmall = 1;
					bool flag135 = this.typeSub == 2;
					if (flag135)
					{
						bool flag136 = num36 % 2 == 0;
						if (flag136)
						{
							point32.frame = 1;
						}
					}
					else
					{
						bool flag137 = num33 == num36;
						if (flag137)
						{
							point32.frame = 1;
						}
					}
					this.VecEff.addElement(point32);
					num = num36;
				}
			}
			for (int num37 = 0; num37 < this.VecEff.size(); num37 = num + 1)
			{
				Point point33 = (Point)this.VecEff.elementAt(num37);
				Point point2 = point33;
				Point point34 = point2;
				num = point2.f;
				point34.f = num + 1;
				bool flag138 = point33.f == 1;
				if (flag138)
				{
					bool flag139 = point33.dis == 0;
					if (flag139)
					{
						int tile2 = GameCanvas.loadmap.getTile(point33.x / 1000, point33.y / 1000);
						bool flag140 = tile2 == 0 || tile2 == 2;
						if (flag140)
						{
							GameScreen.addEffectEnd(66, (point33.frame != 1) ? 1 : 0, point33.x / 1000, point33.y / 1000, this.Dir, this.objMainEff);
						}
						else
						{
							point33.isRemove = true;
						}
					}
					bool flag141 = CRes.random(6) == 0;
					if (flag141)
					{
						GameScreen.addEffectEnd(110, (point33.frame != 1) ? 1 : 0, point33.x / 1000, point33.y / 1000, this.Dir, this.objMainEff);
					}
				}
				bool flag142 = point33.f / 3 >= this.fraImgSubEff.maxNumFrame || point33.isRemove;
				if (flag142)
				{
					this.VecEff.removeElement(point33);
					num = num37;
					num37 = num - 1;
				}
				num = num37;
			}
			bool flag143 = this.f >= this.fRemove && this.VecEff.size() == 0;
			if (flag143)
			{
				this.removeEff();
			}
			return;
		}
		case 114:
		{
			this.x += this.vx;
			bool flag144 = this.f >= this.fRemove;
			if (flag144)
			{
				this.removeEff();
			}
			return;
		}
		case 116:
		{
			for (int num38 = 0; num38 < this.VecEff.size(); num38 = num + 1)
			{
				Point point35 = (Point)this.VecEff.elementAt(num38);
				point35.update();
				bool flag145 = point35.f >= point35.fRe;
				if (flag145)
				{
					this.VecEff.removeElement(point35);
					num = num38;
					num38 = num - 1;
				}
				num = num38;
			}
			bool flag146 = this.f % 5 == 1 && this.f < this.fRemove && CRes.random(2) == 0;
			if (flag146)
			{
				Point point36 = new Point();
				point36.x = this.x + CRes.random_Am_0(10);
				point36.y = this.y + CRes.random(20);
				point36.vx = CRes.random_Am_0(3);
				point36.vy = -CRes.random(3, 7);
				point36.fRe = CRes.random(12, 18);
				this.VecEff.addElement(point36);
			}
			bool flag147 = this.f % 4 == 1 && this.f < this.fRemove;
			if (flag147)
			{
				Point point37 = new Point();
				point37.x = this.x + CRes.random_Am_0(15);
				point37.y = this.y + CRes.random(20);
				point37.vx = CRes.random_Am_0(3);
				point37.vy = -CRes.random(3, 7);
				point37.fRe = CRes.random(4, 7);
				this.VecEff.addElement(point37);
			}
			bool flag148 = this.f >= this.fRemove && this.VecEff.size() == 0;
			if (flag148)
			{
				this.removeEff();
			}
			return;
		}
		case 117:
		{
			bool flag149 = this.f >= this.fRemove;
			if (flag149)
			{
				this.removeEff();
			}
			return;
		}
		case 119:
		{
			for (int num39 = 0; num39 < this.VecEff.size(); num39 = num + 1)
			{
				Point point38 = (Point)this.VecEff.elementAt(num39);
				point38.update();
				bool flag150 = point38.f >= point38.fRe;
				if (flag150)
				{
					this.VecEff.removeElementAt(num39);
					num = num39;
					num39 = num - 1;
				}
				num = num39;
			}
			bool flag151 = this.f % 3 == 0 && this.f < this.fRemove;
			if (flag151)
			{
				Point point39 = new Point();
				point39.x = this.x;
				point39.y = this.y;
				bool flag152 = this.Dir == 0;
				if (flag152)
				{
					point39.vx = -6;
				}
				else
				{
					point39.vx = 6;
				}
				point39.fRe = this.mPlayFrame.Length;
				this.VecEff.addElement(point39);
			}
			bool flag153 = this.f >= this.fRemove && this.VecEff.size() == 0;
			if (flag153)
			{
				this.removeEff();
			}
			return;
		}
		case 126:
		{
			for (int num40 = 0; num40 < this.VecEff.size(); num40 = num + 1)
			{
				Point_Focus point_Focus7 = (Point_Focus)this.VecEff.elementAt(num40);
				point_Focus7.update_Vx_Vy();
				bool flag154 = point_Focus7.f >= point_Focus7.fRe;
				if (flag154)
				{
					this.VecEff.removeElementAt(num40);
					num = num40;
					num40 = num - 1;
				}
				num = num40;
			}
			bool flag155 = this.step == 2 && this.VecEff.size() == 0;
			if (flag155)
			{
				this.step = 3;
				Point_Focus point_Focus8 = new Point_Focus();
				point_Focus8.frame = 1;
				point_Focus8.fRe = 8;
				point_Focus8.x = this.x / 100;
				point_Focus8.y = this.y / 100;
				point_Focus8.vy = -4;
				this.VecEff.addElement(point_Focus8);
				GameScreen.addEffectEnd(108, 7, this.x / 100 - 4, this.y / 100, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(108, 7, this.x / 100 + 4, this.y / 100, this.Dir, this.objMainEff);
			}
			bool flag156 = this.step == 1;
			if (flag156)
			{
				num = this.frame;
				this.frame = num + 1;
				bool flag157 = this.frame == 8;
				if (flag157)
				{
					this.step = 2;
					this.x1000 = this.objMainEff.x;
					this.y1000 = this.objMainEff.y - 15;
					Point_Focus point_Focus9 = new Point_Focus();
					int xdich = this.x / 100 - this.x1000;
					int ydich = this.y / 100 - this.y1000;
					point_Focus9.frame = 0;
					base.create_Speed(xdich, ydich, point_Focus9, this.x1000, this.y1000, this.x / 100, this.y / 100);
					this.VecEff.addElement(point_Focus9);
					this.objMainEff.isDie = true;
				}
			}
			bool flag158 = this.step == 0;
			if (flag158)
			{
				this.x += this.vx;
				this.y += this.vy;
				this.vy += this.vMax;
				bool flag159 = this.vy >= 0;
				if (flag159)
				{
					this.vx = 0;
					this.vy = 0;
					this.vMax = 6;
					this.step = 1;
					GameScreen.addEffectEnd(85, 0, this.x / 100, this.y / 100, 500, this.Dir, this.objMainEff);
					this.frame = 0;
				}
			}
			bool flag160 = this.f >= this.fRemove;
			if (flag160)
			{
				this.removeEff();
			}
			return;
		}
		case 127:
		{
			bool flag161 = this.f < 4;
			if (flag161)
			{
				this.objMainEff.frame = 33;
				bool flag162 = this.objTo.x < this.objMainEff.x;
				if (flag162)
				{
					this.objMainEff.type_left_right = (int)this.Dir;
				}
				else
				{
					this.objMainEff.type_left_right = (int)this.Dir;
				}
			}
			this.x += this.vx;
			this.y += this.vy;
			bool flag163 = this.f < this.fRemove;
			if (flag163)
			{
				return;
			}
			bool flag164 = this.typeSub >= 20;
			if (flag164)
			{
				mSystem.outz("vo day 02 typesub = " + this.typeSub.ToString());
				GameScreen.addEffectEnd(128, (int)this.typeSub, this.x, this.y, 0, this.objTo);
			}
			else
			{
				bool flag165 = this.typeSub % 10 > 3 && this.typeSub % 10 != 7;
				if (flag165)
				{
					bool flag166 = this.objTo != null;
					if (flag166)
					{
						bool flag167 = this.typeSub >= 10;
						if (flag167)
						{
							this.objTo.strChatPopup = T.gru;
						}
						else
						{
							this.objTo.strChatPopup = T.gaugau;
						}
					}
				}
				else
				{
					mSystem.outz("vo day 00 typesub = " + this.typeSub.ToString());
					bool flag168 = this.typeSub >= 10;
					if (flag168)
					{
						mSystem.outz("vo day 01 typesub = " + this.typeSub.ToString());
						GameScreen.addEffectEnd(128, (int)this.typeSub, this.x, this.y, 0, this.objTo);
					}
					else
					{
						mSystem.outz("vo day 02 typesub = " + this.typeSub.ToString());
						GameScreen.addEffectEnd(126, (int)this.typeSub, this.x, this.y, 0, this.objTo);
					}
				}
			}
			this.removeEff();
			return;
		}
		case 130:
		{
			for (int num41 = 0; num41 < this.VecEff.size(); num41 = num + 1)
			{
				Point point40 = (Point)this.VecEff.elementAt(num41);
				Point point2 = point40;
				point2.x += point40.vx;
				point2 = point40;
				point2.y += point40.vy;
				bool flag169 = point40.y <= -60;
				if (flag169)
				{
					this.VecEff.removeElementAt(num41);
					num = num41;
					num41 = num - 1;
				}
				num = num41;
			}
			bool flag170 = this.f % 10 == 0;
			if (flag170)
			{
				for (int num42 = 0; num42 < 5; num42 = num + 1)
				{
					Point point41 = new Point();
					point41.x = CRes.random_Am_0(15);
					point41.y = 10 - CRes.random(40);
					point41.dis = 1 + CRes.random(3);
					point41.vy = -4;
					point41.frame = CRes.random(12);
					this.VecEff.addElement(point41);
					num = num42;
				}
			}
			bool flag171 = (GameCanvas.timeNow - this.time) / 1000L >= (long)this.timeRemove || this.objTo == null;
			if (flag171)
			{
				this.removeEff();
			}
			return;
		}
		case 131:
		case 152:
		{
			bool flag172 = (GameCanvas.timeNow - this.time) / 1000L >= (long)this.timeRemove || this.objTo == null;
			if (flag172)
			{
				this.removeEff();
			}
			return;
		}
		case 132:
		{
			this.x += this.vx;
			bool flag173 = this.typeSub == 1 && this.vx <= 20;
			if (flag173)
			{
				this.vx -= 2;
				bool flag174 = this.Dir == 2;
				if (flag174)
				{
					this.vx += 2;
				}
			}
			bool flag175 = this.f >= this.fRemove;
			if (flag175)
			{
				this.removeEff();
			}
			return;
		}
		case 135:
		{
			this.x += this.vx;
			this.vx /= 2;
			bool flag176 = this.f >= this.fRemove;
			if (flag176)
			{
				this.removeEff();
			}
			return;
		}
		case 137:
		{
			for (int num43 = 0; num43 < this.VecEff.size(); num43 = num + 1)
			{
				Point point42 = (Point)this.VecEff.elementAt(num43);
				Point point2 = point42;
				point2.x += this.vx;
				point2 = point42;
				Point point43 = point2;
				num = point2.f;
				point43.f = num + 1;
				bool flag177 = point42.f >= point42.fRe;
				if (flag177)
				{
					this.VecEff.removeElementAt(num43);
					num = num43;
					num43 = num - 1;
				}
				num = num43;
			}
			bool flag178 = this.f >= this.fRemove;
			if (flag178)
			{
				this.removeEff();
			}
			return;
		}
		case 140:
		case 167:
		{
			for (int num44 = 0; num44 < this.VecEff.size(); num44 = num + 1)
			{
				Point point44 = (Point)this.VecEff.elementAt(num44);
				bool flag179 = CRes.random(3) == 0;
				if (flag179)
				{
					point44.x = this.x + CRes.random_Am_0(3);
					point44.y = this.y + CRes.random_Am_0(3);
				}
				num = num44;
			}
			bool flag180 = this.f >= this.fRemove;
			if (flag180)
			{
				this.removeEff();
			}
			return;
		}
		case 143:
		{
			this.y += this.vy;
			bool flag181 = this.vy < 0;
			if (flag181)
			{
				num = this.vy;
				this.vy = num + 1;
			}
			bool flag182 = this.f >= this.fRemove;
			if (flag182)
			{
				this.removeEff();
			}
			return;
		}
		case 146:
		{
			for (int num45 = 0; num45 < this.VecEff.size(); num45 = num + 1)
			{
				Point point45 = (Point)this.VecEff.elementAt(num45);
				point45.update();
				num = num45;
			}
			bool flag183 = this.f >= this.fRemove;
			if (flag183)
			{
				this.removeEff();
			}
			return;
		}
		case 147:
			this.update_Lucci_L2();
			return;
		case 150:
		{
			bool flag184 = this.objTo != null;
			if (flag184)
			{
				this.x = this.objTo.x;
				this.y = this.objTo.y - this.objTo.hOne;
			}
			bool flag185 = (GameCanvas.timeNow - this.time) / 1000L >= (long)this.timeRemove || this.objTo == null;
			if (flag185)
			{
				this.removeEff();
			}
			return;
		}
		case 153:
		{
			bool flag186 = this.f == 20;
			if (flag186)
			{
				this.frame = 1;
			}
			else
			{
				bool flag187 = this.f == 40;
				if (flag187)
				{
					this.frame = 2;
				}
				else
				{
					bool flag188 = this.f == 50;
					if (flag188)
					{
						this.vy = -1;
					}
					else
					{
						bool flag189 = this.f == 60;
						if (flag189)
						{
							this.vy = -2;
						}
					}
				}
			}
			bool flag190 = this.f >= 50;
			if (flag190)
			{
				bool flag191 = CRes.random(6) == 0;
				if (flag191)
				{
					this.vx = CRes.random_Am(1, 2);
				}
				else
				{
					this.vx = 0;
				}
			}
			else
			{
				bool flag192 = CRes.random(10) == 0;
				if (flag192)
				{
					this.vx = CRes.random_Am(1, 2);
				}
				else
				{
					this.vx = 0;
				}
			}
			for (int num46 = 0; num46 < this.VecEff.size(); num46 = num + 1)
			{
				Point point46 = (Point)this.VecEff.elementAt(num46);
				point46.update();
				bool flag193 = point46.x < MainScreen.cameraMain.xCam;
				if (flag193)
				{
					Point point2 = point46;
					point2.x += MotherCanvas.w;
				}
				else
				{
					bool flag194 = point46.x > MainScreen.cameraMain.xCam + MotherCanvas.w;
					if (flag194)
					{
						Point point2 = point46;
						point2.x -= MotherCanvas.w;
					}
				}
				bool flag195 = point46.f >= point46.fRe;
				if (flag195)
				{
					this.VecEff.removeElementAt(num46);
					num = num46;
					num46 = num - 1;
				}
				num = num46;
			}
			bool flag196 = this.f >= 140 && this.f <= 180;
			if (flag196)
			{
				for (int num47 = 0; num47 < MotherCanvas.w / 10 - 1; num47 = num + 1)
				{
					bool flag197 = CRes.random(4) == 0;
					if (flag197)
					{
						Point point47 = new Point(MainScreen.cameraMain.xCam + 5 + num47 * 10 + CRes.random(3), this.y);
						point47.vy = 5;
						point47.vx = CRes.random_Am_0(2);
						point47.fRe = MotherCanvas.h / 5 + CRes.random_Am_0(10);
						point47.frame = CRes.random(9);
						this.VecEff.addElement(point47);
					}
					num = num47;
				}
			}
			this.x += this.vx;
			this.y += this.vy;
			bool flag198 = this.f >= this.fRemove && this.VecEff.size() == 0;
			if (flag198)
			{
				this.removeEff();
			}
			return;
		}
		case 154:
		case 155:
		{
			for (int num48 = 0; num48 < this.VecEff.size(); num48 = num + 1)
			{
				Point point48 = (Point)this.VecEff.elementAt(num48);
				point48.x = CRes.getcos(CRes.fixangle(point48.dis)) * this.vMax / 1000 + this.x;
				point48.y = CRes.getsin(CRes.fixangle(point48.dis)) * this.vMax / 1000 + this.y;
				Point point2 = point48;
				point2.dis += 30;
				num = num48;
			}
			this.vMax -= 2;
			bool flag199 = this.f >= this.fRemove;
			if (flag199)
			{
				this.removeEff();
			}
			return;
		}
		case 156:
		{
			bool flag200 = (GameCanvas.timeNow - this.time) / 100L >= (long)this.timeRemove || this.objTo == null;
			if (flag200)
			{
				this.removeEff();
			}
			bool flag201 = this.objTo != null;
			if (flag201)
			{
				this.x = this.objTo.x;
				this.y = this.objTo.y - this.objTo.hOne;
			}
			this.y1000 += this.vy;
			bool flag202 = this.vy < 0;
			if (flag202)
			{
				num = this.vy;
				this.vy = num + 1;
			}
			return;
		}
		case 157:
		{
			this.x += this.vx;
			bool flag203 = this.f >= this.fRemove;
			if (flag203)
			{
				this.removeEff();
			}
			return;
		}
		case 158:
		{
			bool flag204 = this.f % 3 == 0 || this.f >= 30;
			if (flag204)
			{
				GameScreen.addEffectEnd(108, (int)((sbyte)CRes.random(7, 9)), this.x - this.am_duong * 5, this.y + 5, 0, this.objMainEff);
			}
			bool flag205 = this.f >= 30;
			if (flag205)
			{
				GameScreen.addEffectEnd(108, (int)((sbyte)CRes.random(7, 9)), this.x + this.am_duong * 5, this.y - 5, 0, this.objMainEff);
			}
			bool flag206 = this.f >= 30 && this.f <= 36;
			if (flag206)
			{
				this.vy -= 3;
				this.vx -= this.am_duong;
			}
			for (int num49 = 0; num49 < this.VecEff.size(); num49 = num + 1)
			{
				Point point49 = (Point)this.VecEff.elementAt(num49);
				point49.update();
				bool flag207 = point49.x < MainScreen.cameraMain.xCam;
				if (flag207)
				{
					Point point2 = point49;
					point2.x += MotherCanvas.w;
				}
				else
				{
					bool flag208 = point49.x > MainScreen.cameraMain.xCam + MotherCanvas.w;
					if (flag208)
					{
						Point point2 = point49;
						point2.x -= MotherCanvas.w;
					}
				}
				bool flag209 = point49.f >= point49.fRe;
				if (flag209)
				{
					this.VecEff.removeElementAt(num49);
					num = num49;
					num49 = num - 1;
				}
				num = num49;
			}
			bool flag210 = this.f == 50;
			if (flag210)
			{
				this.levelPaint = 0;
			}
			bool flag211 = this.f >= 40 && this.f <= 48 && this.f % 2 == 0 && !GameCanvas.lowGraphic;
			if (flag211)
			{
				int x = MainScreen.cameraMain.xCam + 20 + (this.f - 40) / 2 * (MotherCanvas.w / 5);
				bool flag212 = this.Dir == 2;
				if (flag212)
				{
					x = MainScreen.cameraMain.xCam + MotherCanvas.w - 20 - (this.f - 40) / 2 * (MotherCanvas.w / 5);
				}
				GameScreen.addEffectEnd(120, 0, x, MainScreen.cameraMain.yCam + 50, this.Dir, this.objMainEff);
			}
			bool flag213 = this.f >= 50 && this.f <= 54 && this.f % 2 == 0;
			if (flag213)
			{
				int x2 = MainScreen.cameraMain.xCam + 40 + (this.f - 50) / 2 * (MotherCanvas.w / 3);
				bool flag214 = this.Dir == 2;
				if (flag214)
				{
					x2 = MainScreen.cameraMain.xCam + MotherCanvas.w - 20 - (this.f - 50) / 2 * (MotherCanvas.w / 3);
				}
				GameScreen.addEffectEnd(120, 0, x2, MainScreen.cameraMain.yCam + 30, this.Dir, this.objMainEff);
			}
			bool flag215 = this.f >= 40 && this.f <= 90;
			if (flag215)
			{
				for (int num50 = 0; num50 < MotherCanvas.w / 10 - 1; num50 = num + 1)
				{
					bool flag216 = CRes.random(4) == 0;
					if (flag216)
					{
						Point point50 = new Point(MainScreen.cameraMain.xCam + 5 + num50 * 10 + CRes.random(3), MainScreen.cameraMain.yCam - 10);
						point50.vy = 5;
						point50.vx = CRes.random_Am_0(2);
						point50.fRe = MotherCanvas.h / 5 + CRes.random_Am_0(10);
						point50.frame = CRes.random(9);
						this.VecEff.addElement(point50);
					}
					num = num50;
				}
			}
			this.x += this.vx;
			this.y += this.vy;
			bool flag217 = this.f >= this.fRemove && this.VecEff.size() == 0;
			if (flag217)
			{
				this.removeEff();
			}
			return;
		}
		case 160:
		{
			for (int num51 = 0; num51 < this.VecEff.size(); num51 = num + 1)
			{
				Point point51 = (Point)this.VecEff.elementAt(num51);
				Point point2 = point51;
				point2.x += point51.vx;
				point2 = point51;
				point2.y += point51.vy;
				bool flag218 = this.f < 6 || this.f > 12;
				if (flag218)
				{
					point51.vy = -1;
				}
				else
				{
					point51.vy = 1;
				}
				bool flag219 = this.f > 10;
				if (flag219)
				{
					bool flag220 = num51 == 0 || num51 == this.VecEff.size() - 1;
					if (flag220)
					{
						point51.isRemove = true;
					}
					else
					{
						point51.frame = 2 + CRes.random(2);
					}
				}
				else
				{
					bool flag221 = this.f > 14 && num51 == 1;
					if (flag221)
					{
						point51.isRemove = true;
					}
				}
				num = num51;
			}
			bool flag222 = this.f >= this.fRemove;
			if (flag222)
			{
				this.removeEff();
			}
			return;
		}
		case 161:
		{
			for (int num52 = 0; num52 < this.VecEff.size(); num52 = num + 1)
			{
				Point point52 = (Point)this.VecEff.elementAt(num52);
				point52.update();
				bool flag223 = point52.f >= point52.fRe;
				if (flag223)
				{
					this.VecEff.removeElementAt(num52);
					num = num52;
					num52 = num - 1;
				}
				num = num52;
			}
			bool flag224 = this.f < 20 - this.randomf;
			if (flag224)
			{
				bool flag225 = CRes.random(4) == 0;
				if (flag225)
				{
					this.vx = -this.vx;
				}
			}
			else
			{
				bool flag226 = this.vx > 0;
				if (flag226)
				{
					num = this.vx;
					this.vx = num - 1;
				}
				bool flag227 = this.vx < 0;
				if (flag227)
				{
					num = this.vx;
					this.vx = num + 1;
				}
				bool flag228 = this.vy < 0;
				if (flag228)
				{
					num = this.vy;
					this.vy = num + 1;
				}
			}
			bool flag229 = this.f == 20 + this.lengthM - this.randomf;
			if (flag229)
			{
				int num53 = 7 + CRes.random(3);
				for (int num54 = 0; num54 < num53; num54 = num + 1)
				{
					Point point53 = new Point();
					point53.x = this.x * 100 + CRes.random_Am_0(200);
					point53.y = this.y * 100 + CRes.random_Am_0(200);
					point53.vx = CRes.random_Am_0(200);
					point53.vy = CRes.random_Am_0(200);
					point53.frame = 2 + CRes.random(2);
					point53.fRe = 6 + CRes.random(3);
					this.VecEff.addElement(point53);
					num = num54;
				}
			}
			this.x += this.vx;
			this.y += this.vy;
			bool flag230 = this.f >= this.fRemove && this.VecEff.size() == 0;
			if (flag230)
			{
				this.removeEff();
			}
			return;
		}
		case 162:
		{
			bool flag231 = this.f == 20;
			if (flag231)
			{
				this.vy = 0;
			}
			bool flag232 = this.f == 100 || this.f == 105 || this.f == 110;
			if (flag232)
			{
				mSound.playSound(7, mSound.volumeSound);
				GameScreen.addEffectEnd(10, 0, this.objTo.x, this.objTo.y - this.objTo.dy - this.objTo.hOne / 2, this.Dir, this.objTo);
			}
			bool flag233 = this.f > 30 && this.f < 120;
			if (flag233)
			{
				this.objTo.dy = (this.f - 20) / 10;
			}
			this.y += this.vy;
			this.x += this.vx;
			bool flag234 = this.f == 114;
			if (flag234)
			{
				this.x = this.objTo.x * 100;
				this.y = (this.objTo.y - this.objTo.dy - this.objTo.hOne / 2) * 100;
				this.vx = 50;
				bool flag235 = this.objTo.type_left_right == 0;
				if (flag235)
				{
					this.vx = -50;
				}
				this.vy = -15;
			}
			bool flag236 = this.f >= this.fRemove;
			if (flag236)
			{
				bool flag237 = this.objTo == GameScreen.player;
				if (flag237)
				{
					Player.isSendMove = true;
					GameCanvas.tabAllScr.idSelect = 1;
					GameCanvas.tabAllScr.Show(GameCanvas.gameScr);
					GameCanvas.tabAllScr.typeCurrent = 0;
					GameScreen.player.resetAction();
					GameCanvas.clearAll();
				}
				GameScreen.isPaintNormal();
				this.removeEff();
			}
			return;
		}
		case 163:
		{
			bool flag238 = this.f >= this.fRemove;
			if (flag238)
			{
				this.removeEff();
			}
			return;
		}
		case 164:
		{
			num = this.CFrame;
			this.CFrame = num + 1;
			bool flag239 = this.CFrame > 2;
			if (flag239)
			{
				this.CFrame = 0;
			}
			bool flag240 = true;
			int num55 = 0;
			while (num55 < this.VecEff.size())
			{
				Point point54 = (Point)this.VecEff.elementAt(num55);
				bool flag241 = point54.f == 0;
				if (flag241)
				{
					flag240 = false;
					bool flag242 = this.f >= this.fRemove;
					if (flag242)
					{
						point54.f = 1;
					}
					else
					{
						Point point2 = point54;
						point2.x += point54.vx;
						point2 = point54;
						point2.y += point54.vy;
					}
				}
				else
				{
					bool flag243 = point54.f > 0;
					if (flag243)
					{
						Point point2 = point54;
						Point point55 = point2;
						num = point2.f;
						point55.f = num + 1;
						bool flag244 = (point54.f - 1) / 2 >= 5;
						if (flag244)
						{
							point54.f = -1;
							this.VecEff.removeElement(point54);
						}
						flag240 = false;
					}
				}
				IL_550B:
				num = num55;
				num55 = num + 1;
				continue;
				goto IL_550B;
			}
			bool flag245 = flag240;
			if (flag245)
			{
				this.removeEff();
			}
			return;
		}
		case 165:
		{
			bool flag246 = GameCanvas.gameTick % 2 == 0;
			if (flag246)
			{
				num = this.CFrame;
				this.CFrame = num + 1;
			}
			bool flag247 = this.CFrame > 3;
			if (flag247)
			{
				this.CFrame = 0;
			}
			bool flag248 = this.objMainEff.typeEfffashion != 5;
			if (flag248)
			{
				this.removeEff();
			}
			return;
		}
		case 166:
		{
			num = this.tframe;
			this.tframe = num + 1;
			bool flag249 = this.tframe > this.arrFrame.Length;
			if (flag249)
			{
				this.tframe = 0;
				this.removeEff();
			}
			bool flag250 = this.tframe < this.arrFrame.Length - 1;
			if (flag250)
			{
				this.CFrame = this.arrFrame[this.tframe];
			}
			return;
		}
		case 168:
		{
			for (int num56 = 0; num56 < this.VecEff.size(); num56 = num + 1)
			{
				Point point56 = (Point)this.VecEff.elementAt(num56);
				point56.update();
				Point point2 = point56;
				Point point57 = point2;
				num = point2.vy;
				point57.vy = num + 1;
				num = num56;
			}
			bool flag251 = this.f >= this.fRemove;
			if (flag251)
			{
				this.removeEff();
			}
			return;
		}
		case 175:
		{
			bool flag252 = this.objTo != null;
			if (flag252)
			{
				this.x = this.objTo.x;
				this.y = this.objTo.y - this.objTo.hOne - 20;
				bool flag253 = this.f == 4;
				if (flag253)
				{
					GameScreen.addEffectEnd(38, 0, this.objTo.x, this.objTo.y - this.objTo.hOne / 2, this.Dir, this.objMainEff);
				}
			}
			bool flag254 = this.f == 4 && !GameCanvas.lowGraphic;
			if (flag254)
			{
				int tile3 = GameCanvas.loadmap.getTile(this.x, this.y + 85);
				bool flag255 = tile3 == 0 || tile3 == 2;
				if (flag255)
				{
					GameScreen.addEffectEnd(63, 0, this.x, this.y + 75, this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(110, 0, this.x, this.y + 75, this.Dir, this.objMainEff);
				}
			}
			bool flag256 = this.f > this.fRemove;
			if (flag256)
			{
				this.removeEff();
			}
			return;
		}
		case 177:
		{
			this.y += this.vy;
			bool flag257 = this.f >= this.fRemove;
			if (flag257)
			{
				this.removeEff();
			}
			return;
		}
		}
		bool flag258 = this.f >= this.fRemove;
		if (flag258)
		{
			this.removeEff();
		}
	}

	// Token: 0x060001B4 RID: 436 RVA: 0x0002D208 File Offset: 0x0002B408
	private void update_Lucci_L2()
	{
		this.x += this.vx;
		this.y += this.vy;
		bool flag = this.f == 2 || this.f == 4 || this.f == 6;
		if (flag)
		{
			this.x = this.x1000 - this.am_duong * 24;
		}
		bool flag2 = this.f >= 7 && this.vx <= 20;
		if (flag2)
		{
			this.vx += this.am_duong * 2;
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point = (Point)this.VecEff.elementAt(i);
			point.update();
			bool flag3 = this.frame == 0 && point.f == 2;
			if (flag3)
			{
				point.frame = 0;
			}
			bool flag4 = point.f >= point.fRe;
			if (flag4)
			{
				this.VecEff.removeElement(point);
				i--;
			}
		}
		bool flag5 = this.f < this.fRemove;
		if (flag5)
		{
			bool flag6 = this.frame == 1;
			if (flag6)
			{
				for (int j = 0; j <= this.mframe[this.f]; j++)
				{
					Point point2 = new Point();
					point2.x = this.x;
					point2.y = this.y - this.mframe[this.f] * 10 + j * 20;
					bool flag7 = this.mframe[this.f] < 2;
					if (flag7)
					{
						point2.fRe = 2;
					}
					else
					{
						bool flag8 = this.mframe[this.f] == 2;
						if (flag8)
						{
							bool flag9 = j == 1;
							if (flag9)
							{
								point2.fRe = 4;
							}
							else
							{
								point2.fRe = 2;
							}
						}
						else
						{
							bool flag10 = this.mframe[this.f] == 3;
							if (flag10)
							{
								bool flag11 = j == 1 || j == 2;
								if (flag11)
								{
									point2.fRe = 4;
								}
								else
								{
									point2.fRe = 2;
								}
							}
							else
							{
								switch (j)
								{
								case 1:
								case 3:
									point2.fRe = 4;
									break;
								case 2:
									point2.fRe = 6;
									break;
								default:
									point2.fRe = 2;
									break;
								}
							}
						}
					}
					this.VecEff.addElement(point2);
				}
			}
			else
			{
				bool flag12 = this.mframe[this.f] == 2;
				if (flag12)
				{
					Point point3 = new Point();
					point3.x = this.x;
					point3.y = this.y;
					point3.frame = 1;
					point3.fRe = 4;
					this.VecEff.addElement(point3);
				}
			}
		}
		bool flag13 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag13)
		{
			this.removeEff();
		}
	}

	// Token: 0x060001B5 RID: 437 RVA: 0x000090B5 File Offset: 0x000072B5
	public void endUpdate()
	{
	}

	// Token: 0x060001B6 RID: 438 RVA: 0x0002D53C File Offset: 0x0002B73C
	private void updateLuffy_6()
	{
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point = (Point)this.VecEff.elementAt(i);
			point.f++;
			bool flag = point.f >= 3;
			if (flag)
			{
				this.VecEff.removeElement(point);
				i--;
			}
		}
		bool flag2 = this.f >= this.fRemove;
		if (flag2)
		{
			bool flag3 = this.VecEff.size() == 0;
			if (flag3)
			{
				this.removeEff();
			}
		}
		else
		{
			bool flag4 = (this.typeSub == 2 || this.typeSub == 3) && this.f % 2 == 0;
			if (flag4)
			{
				Point o = new Point(this.x + CRes.random_Am_0(15), this.y + CRes.random_Am_0(20));
				this.VecEff.addElement(o);
			}
		}
	}

	// Token: 0x060001B7 RID: 439 RVA: 0x0002D63C File Offset: 0x0002B83C
	private void updateSanji_5()
	{
		bool flag = this.f == this.fRemove;
		if (flag)
		{
			base.setAva(1, this.objTo);
			bool flag2 = this.typeSub == 1;
			if (flag2)
			{
				GameScreen.addEffectEnd(25, 0, this.toX, this.toY, this.Dir, this.objMainEff);
			}
			else
			{
				GameScreen.addEffectEnd(8, 0, this.toX, this.toY, this.Dir, this.objMainEff);
			}
			GameScreen.addEffectEnd(93, 2, this.toX, this.toY, this.Dir, this.objMainEff);
		}
		bool flag3 = this.f >= this.fRemove;
		if (flag3)
		{
			bool flag4 = this.VecEff.size() == 0;
			if (flag4)
			{
				this.removeEff();
			}
		}
		else
		{
			bool flag5 = this.f >= 1;
			if (flag5)
			{
				bool flag6 = this.typeSub == 1;
				if (flag6)
				{
					Point o = new Point(this.x, this.y);
					this.VecEff.addElement(o);
				}
				this.x += this.vx;
				this.y += this.vy;
			}
		}
		bool flag7 = this.f == 1;
		if (flag7)
		{
			bool flag8 = this.objTo != null;
			if (flag8)
			{
				this.toY = this.objTo.y - this.objTo.hOne / 2;
			}
			int xdich = this.toX - this.x;
			int ydich = this.toY - this.y;
			this.vMax = 14;
			base.create_Speed(xdich, ydich, null);
			this.fRemove += 2;
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point = (Point)this.VecEff.elementAt(i);
			point.f++;
			bool flag9 = point.f >= 4;
			if (flag9)
			{
				this.VecEff.removeElement(point);
				i--;
			}
		}
	}

	// Token: 0x060001B8 RID: 440 RVA: 0x0002D874 File Offset: 0x0002BA74
	private void updateNami_4()
	{
		bool flag = this.f < this.fRemove && this.f % 2 == 0;
		if (flag)
		{
			Point point = new Point();
			point.x = this.x + CRes.random_Am_0(20);
			point.y = this.y + CRes.random_Am_0(20);
			bool flag2 = this.typeEffect == 138;
			if (flag2)
			{
				point.frame = CRes.random(2);
			}
			this.VecEff.addElement(point);
		}
		bool flag3 = this.f > this.fRemove && this.VecEff.size() == 0;
		if (flag3)
		{
			this.removeEff();
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point2 = (Point)this.VecEff.elementAt(i);
			point2.f++;
			bool flag4 = point2.f >= 6;
			if (flag4)
			{
				this.VecEff.removeElement(point2);
				i--;
			}
		}
	}

	// Token: 0x060001B9 RID: 441 RVA: 0x0002D998 File Offset: 0x0002BB98
	private void updateUssop_8()
	{
		bool flag = this.f >= 0 && this.objTo != null && CRes.random(2) == 0 && this.f < this.fRemove;
		if (flag)
		{
			this.x = this.objTo.x;
			this.y = this.objTo.y - this.objTo.hOne / 2;
			Point o = new Point(this.x + CRes.random_Am_0(20), this.y + CRes.random_Am_0(20));
			this.VecEff.addElement(o);
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point = (Point)this.VecEff.elementAt(i);
			point.f++;
			bool flag2 = point.f >= 5;
			if (flag2)
			{
				this.VecEff.removeElement(point);
				i--;
			}
		}
		bool flag3 = this.f > this.fRemove && this.VecEff.size() == 0;
		if (flag3)
		{
			this.removeEff();
		}
	}

	// Token: 0x060001BA RID: 442 RVA: 0x0002DAC8 File Offset: 0x0002BCC8
	private void updateLuffy_S1_Final()
	{
		bool flag = this.f >= this.fRemove;
		if (flag)
		{
			this.removeEff();
		}
		bool flag2 = this.f == 0;
		if (flag2)
		{
			int num = 0;
			for (int i = 0; i < 8; i++)
			{
				Point o = new Point(this.x + CRes.getcos(num) * 45 / 1000, this.y + CRes.getsin(num) * 35 / 1000);
				this.VecEff.addElement(o);
				num += 45;
			}
		}
		int num2 = 0;
		bool flag3 = this.f == 3;
		if (flag3)
		{
			int num3 = 0;
			for (int j = 0; j < 12; j++)
			{
				Point point = new Point(this.x + CRes.getcos(num3) * 75 / 1000, this.y + CRes.getsin(num3) * 45 / 1000);
				this.VecEff.addElement(point);
				bool flag4 = this.typeSub == 11 || this.typeSub == 12;
				if (flag4)
				{
					int tile = GameCanvas.loadmap.getTile(point.x, point.y);
					bool flag5 = tile == 0 || tile == 2;
					if (flag5)
					{
						this.vecSubEff.addElement(point);
						GameScreen.addEffectEnd(110, 0, point.x, point.y, this.Dir, this.objMainEff);
					}
				}
				num3 += 30;
			}
		}
		bool flag6 = this.f == 6 && this.typeSub != 12;
		if (flag6)
		{
			int num4 = 0;
			for (int k = 0; k < 24; k++)
			{
				num2++;
				Point point2 = new Point(this.x + CRes.getcos(num4) * 85 / 1000, this.y + CRes.getsin(num4) * 55 / 1000);
				this.VecEff.addElement(point2);
				bool flag7 = this.typeSub == 1;
				if (flag7)
				{
					int tile2 = GameCanvas.loadmap.getTile(point2.x, point2.y);
					bool flag8 = tile2 == 0 || tile2 == 2;
					if (flag8)
					{
						this.vecSubEff.addElement(point2);
						bool flag9 = num2 % 2 == 0;
						if (flag9)
						{
							GameScreen.addEffectEnd(110, 0, point2.x, point2.y, this.Dir, this.objMainEff);
						}
					}
				}
				num4 += 15;
			}
		}
		bool flag10 = this.f == 10 && this.typeSub == 11;
		if (flag10)
		{
			int num5 = 0;
			for (int l = 0; l < 32; l++)
			{
				num2++;
				Point point3 = new Point(this.x + CRes.getcos(num5) * 115 / 1000, this.y + CRes.getsin(num5) * 80 / 1000);
				this.VecEff.addElement(point3);
				bool flag11 = this.typeSub == 11;
				if (flag11)
				{
					int tile3 = GameCanvas.loadmap.getTile(point3.x, point3.y);
					bool flag12 = tile3 == 0 || tile3 == 2;
					if (flag12)
					{
						this.vecSubEff.addElement(point3);
						bool flag13 = num2 % 2 == 0;
						if (flag13)
						{
							GameScreen.addEffectEnd(110, 0, point3.x, point3.y, this.Dir, this.objMainEff);
						}
					}
				}
				num5 += 11;
			}
		}
		for (int m = 0; m < this.VecEff.size(); m++)
		{
			Point point4 = (Point)this.VecEff.elementAt(m);
			point4.f++;
			bool flag14 = point4.f >= 3;
			if (flag14)
			{
				this.VecEff.removeElement(point4);
				m--;
			}
		}
		num2 = 0;
		for (int n = 0; n < this.vecSubEff.size(); n++)
		{
			Point point5 = (Point)this.vecSubEff.elementAt(n);
			point5.f++;
			bool flag15 = point5.f >= 8;
			if (flag15)
			{
				bool flag16 = num2 % 2 == 0;
				if (flag16)
				{
					GameScreen.addEffectEnd(63, 0, point5.x, point5.y, this.Dir, this.objMainEff);
				}
				num2++;
				this.vecSubEff.removeElement(point5);
				n--;
			}
		}
	}

	// Token: 0x060001BB RID: 443 RVA: 0x0002DFA0 File Offset: 0x0002C1A0
	private void updateLineIn()
	{
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Line line = (Line)this.VecEff.elementAt(i);
			line.update();
			bool flag = this.f >= this.fRemove;
			if (flag)
			{
				this.VecEff.removeElement(line);
				i--;
			}
		}
		bool flag2 = this.f >= this.fRemove;
		if (flag2)
		{
			bool flag3 = GameCanvas.timeNow - this.time >= (long)this.timeRemove;
			if (flag3)
			{
				this.VecEff.removeAllElements();
				this.removeEff();
			}
			else
			{
				this.fRemove = CRes.random(4, 6);
				this.f = 0;
				this.create_Star_Line_In(this.vMax, this.xline, this.yline, 0, this.maxsize);
			}
		}
	}

	// Token: 0x060001BC RID: 444 RVA: 0x0002E090 File Offset: 0x0002C290
	private void updateLineBuff()
	{
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Line line = (Line)this.VecEff.elementAt(i);
			line.update();
			bool flag = this.f >= this.fRemove;
			if (flag)
			{
				this.VecEff.removeElement(line);
				i--;
			}
		}
		bool flag2 = this.f >= this.fRemove;
		if (flag2)
		{
			bool flag3 = GameCanvas.timeNow - this.time >= (long)this.timeRemove;
			if (flag3)
			{
				this.VecEff.removeAllElements();
				this.removeEff();
			}
			else
			{
				this.fRemove = CRes.random(4, 6);
				this.f = 0;
				this.create_Star_Line_In(this.vMax, this.xline, this.yline, 10, this.maxsize);
			}
		}
	}

	// Token: 0x060001BD RID: 445 RVA: 0x0002E180 File Offset: 0x0002C380
	private void updateENDSanji2()
	{
		bool flag = this.f == this.fRemove;
		if (flag)
		{
			base.setAva(1, this.objTo);
			GameScreen.addEffectEnd(25, 0, this.toX, this.toY, this.Dir, this.objMainEff);
		}
		bool flag2 = this.f >= this.fRemove;
		if (flag2)
		{
			bool flag3 = this.VecEff.size() == 0;
			if (flag3)
			{
				this.removeEff();
			}
		}
		else
		{
			bool flag4 = this.f >= 1;
			if (flag4)
			{
				Point o = new Point(this.x, this.y);
				this.VecEff.addElement(o);
				this.x += this.vx;
				this.y += this.vy;
			}
		}
		bool flag5 = this.f == 1;
		if (flag5)
		{
			bool flag6 = this.objTo != null;
			if (flag6)
			{
				this.toY = this.objTo.y - this.objTo.hOne / 2;
			}
			int xdich = this.toX - this.x;
			int ydich = this.toY - this.y;
			this.vMax = 14;
			base.create_Speed(xdich, ydich, null);
			this.fRemove += 2;
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point = (Point)this.VecEff.elementAt(i);
			point.f++;
			bool flag7 = point.f >= 4;
			if (flag7)
			{
				this.VecEff.removeElement(point);
				i--;
			}
		}
	}

	// Token: 0x060001BE RID: 446 RVA: 0x0002E350 File Offset: 0x0002C550
	private void updateENDLuffy1()
	{
		bool flag = this.f == this.fRemove && this.objTo != null;
		if (flag)
		{
			base.setAva(1, this.objTo);
			bool flag2 = this.typeSub == 5;
			if (flag2)
			{
				GameScreen.addEffectEnd(25, 4, this.toX, this.toY, this.Dir, this.objMainEff);
			}
			else
			{
				GameScreen.addEffectEnd(25, 0, this.toX, this.toY, this.Dir, this.objMainEff);
			}
		}
		bool flag3 = this.f >= this.fRemove;
		if (flag3)
		{
			bool flag4 = this.f == this.fRemove && this.objTo != null;
			if (flag4)
			{
				int subtype = 0;
				bool flag5 = this.typeSub == 5;
				if (flag5)
				{
					subtype = 3;
				}
				GameScreen.addEffectEnd(93, subtype, this.x, this.y, this.Dir, this.objMainEff);
			}
			bool flag6 = this.VecEff.size() == 0;
			if (flag6)
			{
				this.removeEff();
			}
		}
		else
		{
			bool flag7 = this.typeSub >= 1;
			if (flag7)
			{
				Point o = new Point(this.x, this.y);
				this.VecEff.addElement(o);
			}
			this.x += this.vx;
			this.y += this.vy;
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point = (Point)this.VecEff.elementAt(i);
			point.f++;
			bool flag8 = point.f >= 3;
			if (flag8)
			{
				this.VecEff.removeElement(point);
				i--;
			}
		}
	}

	// Token: 0x060001BF RID: 447 RVA: 0x0002E53C File Offset: 0x0002C73C
	private void updateZoro9()
	{
		bool flag = this.f == this.fRemove;
		if (flag)
		{
			base.setAva(1, this.objTo);
			bool flag2 = this.objTo != null;
			if (flag2)
			{
				GameScreen.addEffectEnd(19, (this.f / 3 != 0) ? 1 : 0, this.objTo.x, this.objTo.y - this.objTo.hOne / 2, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(93, 0, this.objTo.x, this.objTo.y - this.objTo.hOne / 2, this.Dir, this.objMainEff);
				bool flag3 = this.typeSub == 2;
				if (flag3)
				{
					GameScreen.addEffectEnd(108, 6, this.objTo.x, this.objTo.y - this.objTo.hOne / 2, this.Dir, this.objMainEff);
				}
			}
		}
		bool flag4 = this.f >= this.fRemove;
		if (flag4)
		{
			bool flag5 = this.VecEff.size() == 0;
			if (flag5)
			{
				this.removeEff();
			}
		}
		else
		{
			bool flag6 = this.typeSub == 2;
			if (flag6)
			{
				Point o = new Point(this.x, this.y - 16);
				this.VecEff.addElement(o);
				Point o2 = new Point(this.x, this.y + 16);
				this.VecEff.addElement(o2);
			}
			this.x += this.vx;
			this.y += this.vy;
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point = (Point)this.VecEff.elementAt(i);
			point.f++;
			bool flag7 = point.f >= 3;
			if (flag7)
			{
				this.VecEff.removeElement(point);
				i--;
			}
		}
	}

	// Token: 0x060001C0 RID: 448 RVA: 0x0002E770 File Offset: 0x0002C970
	private void updateFocusTouch()
	{
		bool flag = this.objTo != null;
		if (flag)
		{
			this.x = this.objTo.x;
			bool flag2 = this.typeSub == 0;
			if (flag2)
			{
				this.y = this.objTo.y - this.objTo.hOne / 2;
			}
			else
			{
				bool flag3 = this.typeSub == 1;
				if (flag3)
				{
					this.y = this.objTo.y - this.objTo.hOne - 8;
				}
			}
		}
		bool flag4 = this.f >= this.fRemove;
		if (flag4)
		{
			this.removeEff();
		}
	}

	// Token: 0x060001C1 RID: 449 RVA: 0x0002E81C File Offset: 0x0002CA1C
	private void updateXuyenGiap()
	{
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point = (Point)this.VecEff.elementAt(i);
			point.update();
			point.vy++;
		}
		bool flag = this.f >= this.fRemove;
		if (flag)
		{
			this.removeEff();
		}
	}

	// Token: 0x060001C2 RID: 450 RVA: 0x0002E88C File Offset: 0x0002CA8C
	private void updateRock()
	{
		bool flag = this.f == 10;
		if (flag)
		{
			this.levelPaint = -1;
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point = (Point)this.VecEff.elementAt(i);
			point.update();
			bool flag2 = point.f < point.fSmall;
			if (flag2)
			{
				point.vy++;
			}
			else
			{
				bool flag3 = point.f == point.fSmall;
				if (flag3)
				{
					point.vx = 0;
					point.vy = 0;
					int tile = GameCanvas.loadmap.getTile(point.x, point.y);
					bool flag4 = tile != 0 && tile != 2;
					if (flag4)
					{
						point.f = 100;
					}
				}
			}
			bool flag5 = point.f >= 100 || point.f >= point.fRe;
			if (flag5)
			{
				this.VecEff.removeElement(point);
				i--;
			}
		}
		bool flag6 = this.f >= this.fRemove;
		if (flag6)
		{
			this.removeEff();
		}
	}

	// Token: 0x060001C3 RID: 451 RVA: 0x0002E9C4 File Offset: 0x0002CBC4
	private void updateRockNew()
	{
		bool flag = this.f == 10;
		if (flag)
		{
			this.levelPaint = -1;
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point = (Point)this.VecEff.elementAt(i);
			point.update();
			bool flag2 = point.subType == 1;
			if (flag2)
			{
				bool flag3 = point.f > point.fRe - 2;
				if (flag3)
				{
					point.frame = 2 - (point.fRe - point.f);
				}
				bool flag4 = point.frame > 2 || point.frame < 0;
				if (flag4)
				{
					point.frame = 2;
				}
			}
			bool flag5 = point.f < point.fSmall;
			if (flag5)
			{
				point.vy++;
			}
			else
			{
				bool flag6 = point.f == point.fSmall;
				if (flag6)
				{
					point.vx = 0;
					point.vy = 0;
					int tile = GameCanvas.loadmap.getTile(point.x, point.y);
					bool flag7 = tile == 0 || tile == 2;
					if (flag7)
					{
						bool flag8 = this.typeEffect != 115 && CRes.random(2) == 0 && (point.frame == 2 || point.frame == 3);
						if (flag8)
						{
							point.subType = 1;
							point.frame = 0;
						}
					}
					else
					{
						point.f = 100;
					}
				}
			}
			bool flag9 = point.f >= 100 || point.f >= point.fRe;
			if (flag9)
			{
				this.VecEff.removeElement(point);
				i--;
			}
		}
		bool flag10 = (this.f >= this.fRemove && this.VecEff.size() == 0) || this.f >= 80;
		if (flag10)
		{
			this.removeEff();
		}
	}

	// Token: 0x060001C4 RID: 452 RVA: 0x0002EBC0 File Offset: 0x0002CDC0
	private void updatePhanDamage()
	{
		bool flag = this.f <= this.fRemove;
		if (flag)
		{
			for (int i = 0; i < 3; i++)
			{
				Point point = new Point(this.x + CRes.random_Am_0(4), this.y + CRes.random_Am_0(4));
				point.f = CRes.random(3);
				this.VecEff.addElement(point);
			}
			this.x += this.vx;
			this.y += this.vy;
		}
		bool flag2 = this.f == this.fRemove;
		if (flag2)
		{
			GameScreen.addEffectEnd(1, 0, this.toX, this.toY, this.Dir, this.objMainEff);
		}
		bool flag3 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag3)
		{
			this.removeEff();
		}
		for (int j = 0; j < this.VecEff.size(); j++)
		{
			Point point2 = (Point)this.VecEff.elementAt(j);
			point2.y += 2;
			point2.f++;
			bool flag4 = point2.f >= 4;
			if (flag4)
			{
				this.VecEff.removeElement(point2);
				j--;
			}
		}
	}

	// Token: 0x060001C5 RID: 453 RVA: 0x0002ED38 File Offset: 0x0002CF38
	private void updateZoro4()
	{
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point = (Point)this.VecEff.elementAt(i);
			point.f++;
			bool flag = point.f >= point.fRe;
			if (flag)
			{
				this.VecEff.removeElement(point);
				i--;
			}
		}
		bool flag2 = this.f == 2;
		if (flag2)
		{
			Point point2 = new Point();
			point2.x = this.x;
			point2.y = this.y;
			point2.fRe = 6;
			point2.fraImgEff = new FrameImage((int)(this.typeSub + 1), 55, 55);
			this.VecEff.addElement(point2);
		}
		bool flag3 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag3)
		{
			this.removeEff();
		}
	}

	// Token: 0x060001C6 RID: 454 RVA: 0x0002EE38 File Offset: 0x0002D038
	public void updateHutMP_HP()
	{
		bool flag = this.isUpdateNormal;
		if (flag)
		{
			bool flag2 = this.f % 2 == 0;
			if (flag2)
			{
				for (int i = 0; i < 3; i++)
				{
					Point point = new Point(this.x + CRes.random_Am_0(4), this.y + CRes.random_Am_0(4));
					point.f = CRes.random(3);
					this.VecEff.addElement(point);
				}
			}
			bool flag3 = this.f <= 5;
			if (flag3)
			{
				this.x += this.vx;
				this.y += this.vy;
			}
			bool flag4 = this.f == 5;
			if (flag4)
			{
				this.vx = 0;
				this.vy = 0;
			}
			bool flag5 = this.f == 10;
			if (flag5)
			{
				this.fRemove = 60;
				this.vMax = 10000;
				this.numNextFrame = 2;
				this.setInfoHutMPHP();
			}
			bool flag6 = this.f >= 10;
			if (flag6)
			{
				base.updateAngleNormal(this.objTo, 0);
			}
		}
		else
		{
			bool flag7 = this.VecEff.size() == 0;
			if (flag7)
			{
				this.removeEff();
				GameScreen.addEffectEnd(91, 0, this.x, this.y, this.Dir, this.objMainEff);
			}
		}
		for (int j = 0; j < this.VecEff.size(); j++)
		{
			Point point2 = (Point)this.VecEff.elementAt(j);
			point2.y += 2;
			point2.f++;
			bool flag8 = point2.f >= 6;
			if (flag8)
			{
				this.VecEff.removeElement(point2);
				j--;
			}
		}
	}

	// Token: 0x060001C7 RID: 455 RVA: 0x0002F020 File Offset: 0x0002D220
	public override void stopUpdateNormal()
	{
		bool flag = this.typeEffect == 22;
		if (flag)
		{
			this.isUpdateNormal = false;
		}
		else
		{
			this.removeEff();
		}
	}

	// Token: 0x060001C8 RID: 456 RVA: 0x0000986D File Offset: 0x00007A6D
	public override void removeEff()
	{
		this.isStop = true;
		this.f = -1;
	}

	// Token: 0x060001C9 RID: 457 RVA: 0x0002F050 File Offset: 0x0002D250
	private void createFocustouch()
	{
		this.x = this.objTo.x;
		bool flag = this.typeSub == 0;
		if (flag)
		{
			this.fraImgEff = new FrameImage(55, 32, 30);
			this.fRemove = 6;
			this.numNextFrame = 1;
			this.y = this.objTo.y - this.objTo.hOne / 2;
		}
		else
		{
			bool flag2 = this.typeSub == 1;
			if (flag2)
			{
				this.fraImgEff = new FrameImage(56, 28, 15);
				this.fRemove = 8;
				this.numNextFrame = 2;
				this.y = this.objTo.y - this.objTo.hOne - 8;
			}
		}
	}

	// Token: 0x060001CA RID: 458 RVA: 0x0002F10C File Offset: 0x0002D30C
	private void createPhanDamage()
	{
		this.fraImgSub2Eff = new FrameImage(50, 48, 48, 32, 32);
		this.numNextFrame = 2;
		this.fraImgEff = new FrameImage(0, 14, 14);
		this.fraImgSubEff = new FrameImage(52, 5, 5);
		this.x1000 = this.x;
		this.y1000 = this.y;
	}

	// Token: 0x060001CB RID: 459 RVA: 0x0002F170 File Offset: 0x0002D370
	private void createHut_MP_HP()
	{
		sbyte b = this.typeSub;
		sbyte b2 = b;
		if (b2 != 0)
		{
			if (b2 == 1)
			{
				this.fraImgEff = new FrameImage(53, 9, 9);
				this.fraImgSubEff = new FrameImage(54, 5, 5);
			}
		}
		else
		{
			this.fraImgEff = new FrameImage(51, 9, 9);
			this.fraImgSubEff = new FrameImage(52, 5, 5);
		}
		this.vx = CRes.random(2, 7);
		bool flag = this.Dir == 0;
		if (flag)
		{
			this.vx = -this.vx;
		}
		this.vy = -CRes.random(6, 10);
		this.fRemove = 30;
	}

	// Token: 0x060001CC RID: 460 RVA: 0x0002F218 File Offset: 0x0002D418
	private void createXuyenGiap()
	{
		bool flag = GameCanvas.isLowGraOrWP_PvP();
		if (flag)
		{
			this.removeEff();
		}
		else
		{
			this.numNextFrame = 2;
			this.fraImgEff = new FrameImage(48, 12, 11);
			this.fraImgSubEff = new FrameImage(30, 38, 38);
			this.fRemove = CRes.random(12, 16);
			int num = CRes.random(3, 7);
			for (int i = 0; i < num; i++)
			{
				Point point = new Point();
				point.x = this.x + CRes.random_Am_0(5);
				point.y = this.y + CRes.random_Am_0(7);
				point.frame = CRes.random(this.fraImgEff.nFrame);
				point.dis = CRes.random(2);
				point.vy = -CRes.random(6, 9);
				point.vx = CRes.random(1, 4);
				bool flag2 = i % 2 == 0;
				if (flag2)
				{
					point.vx = -point.vx;
				}
				this.VecEff.addElement(point);
			}
		}
	}

	// Token: 0x060001CD RID: 461 RVA: 0x0002F328 File Offset: 0x0002D528
	public void createEndBungmerang()
	{
		int num = 0;
		bool flag = this.typeSub == 1;
		if (flag)
		{
			num = 50;
		}
		this.vx = CRes.random_Am(150 + num, 400 + num * 2);
		this.vy = -CRes.random(700 + num, 1000 + num * 2);
	}

	// Token: 0x060001CE RID: 462 RVA: 0x0002F384 File Offset: 0x0002D584
	public void setInfoHutMPHP()
	{
		this.goc_Arc = 0;
		sbyte dir = this.Dir;
		sbyte b = dir;
		if (b != 0)
		{
			if (b == 2)
			{
				this.goc_Arc = 0;
			}
		}
		else
		{
			this.goc_Arc = 180;
		}
		this.va = 4096;
		this.vx = 0;
		this.vy = 0;
		this.life = 0;
		this.vx1000 = this.va * CRes.getcos(this.goc_Arc) >> 10;
		this.vy1000 = this.va * CRes.getsin(this.goc_Arc) >> 10;
	}

	// Token: 0x060001CF RID: 463 RVA: 0x0002F41C File Offset: 0x0002D61C
	private void create_Star_Line_In(int vline, int minline, int maxline, int numpoint, int numLine)
	{
		bool flag = this.f == -1;
		if (flag)
		{
			this.VecEff.removeAllElements();
		}
		this.colorpaint = new int[numLine];
		bool flag2 = maxline <= minline;
		if (flag2)
		{
			maxline = minline + 1;
		}
		for (int i = 0; i < numLine; i++)
		{
			bool flag3 = CRes.random(2) == 0;
			if (flag3)
			{
				this.colorpaint[i] = Effect_End.colorStar[this.indexColorStar][CRes.random(3)];
			}
			else
			{
				this.colorpaint[i] = Effect_End.colorStar[this.indexColorStar][2];
			}
		}
		for (int j = 0; j < numLine; j++)
		{
			Line line = new Line();
			int num = 5 + 180 / numLine * j;
			int num2 = 180 / numLine + 180 / numLine * j - 5;
			bool flag4 = num2 <= num;
			if (flag4)
			{
				num2 = num + 1;
			}
			int num3 = CRes.random(minline, maxline);
			int num4 = CRes.random(vline, vline + 3);
			int num5 = CRes.random(num, num2);
			int num6 = CRes.random(13, 23);
			bool flag5 = numLine == 8;
			if (flag5)
			{
				num6 = CRes.random(50, 70);
			}
			bool is2Line = CRes.random(4) == 0;
			num5 = CRes.fixangle(num5 % 360);
			line.setLine(this.x1000 - CRes.getsin(num5) * (num3 + num6), this.y1000 - CRes.getcos(num5) * (num3 + num6), this.x1000 - CRes.getsin(num5) * num6, this.y1000 - CRes.getcos(num5) * num6, CRes.getsin(num5) * num4, CRes.getcos(num5) * num4, is2Line);
			bool flag6 = numpoint > 1;
			if (flag6)
			{
				line.type = CRes.random(numpoint);
			}
			this.VecEff.addElement(line);
			line = new Line();
			num5 += 180 + CRes.random_Am(2, 5);
			num5 = CRes.fixangle(num5 % 360);
			line.setLine(this.x1000 - CRes.getsin(num5) * (num3 + num6), this.y1000 - CRes.getcos(num5) * (num3 + num6), this.x1000 - CRes.getsin(num5) * num6, this.y1000 - CRes.getcos(num5) * num6, CRes.getsin(num5) * num4, CRes.getcos(num5) * num4, is2Line);
			bool flag7 = numpoint > 1;
			if (flag7)
			{
				line.type = CRes.random(numpoint);
			}
			this.VecEff.addElement(line);
		}
	}

	// Token: 0x060001D0 RID: 464 RVA: 0x0002F6CC File Offset: 0x0002D8CC
	private void createUrgot_4(int value)
	{
		this.fraImgEff = new FrameImage(179, 54, 25);
		for (int i = 0; i < value; i++)
		{
			Point point = new Point();
			point.y = -CRes.random(30);
			point.vy = CRes.random_Am(3, 8);
			point.frame = 3 + CRes.random(3);
			this.VecEff.addElement(point);
		}
		this.toX = this.x;
		this.toY = this.y;
		this.x = this.objTo.x;
		this.y = this.objTo.y;
	}

	// Token: 0x060001D1 RID: 465 RVA: 0x0002F778 File Offset: 0x0002D978
	private void createRock()
	{
		this.fRemove = CRes.random(24, 40);
		this.fraImgEff = new FrameImage(139, 10, 10);
		int num = CRes.random(4, 8);
		this.fRemove = CRes.random(34, 60);
		bool flag = this.typeEffect == 107;
		if (flag)
		{
			this.fraImgEff = new FrameImage(162, 10, 20);
			num = CRes.random(3, 5);
			this.fRemove = CRes.random(10, 16);
		}
		else
		{
			bool flag2 = this.typeEffect == 110;
			if (flag2)
			{
				this.fraImgEff = new FrameImage(227, 10, 10, 4);
				this.fraImgSubEff = new FrameImage(226, 13, 11, 3);
				this.fRemove = CRes.random(34, 60);
			}
			else
			{
				bool flag3 = this.typeEffect == 115;
				if (flag3)
				{
					num = CRes.random(10, 14);
					this.fraImgEff = new FrameImage(262, 20, 15);
					this.fraImgSubEff = new FrameImage(261, 61, 33);
					this.fRemove = CRes.random(104, 130);
				}
			}
		}
		for (int i = 0; i < num; i++)
		{
			Point point = new Point();
			point.x = this.x + CRes.random_Am_0(5);
			point.y = this.y + CRes.random_Am_0(7);
			point.frame = CRes.random(this.fraImgEff.nFrame);
			point.fSmall = CRes.random(12, 16);
			point.dis = CRes.random(2);
			point.vy = CRes.random_Am(2, 5) - 6;
			point.vx = CRes.random(5);
			point.fRe = this.fRemove;
			bool flag4 = this.typeEffect == 110;
			if (flag4)
			{
				point.frame = CRes.random(4);
				point.fRe = this.fRemove;
			}
			else
			{
				bool flag5 = this.typeEffect == 115;
				if (flag5)
				{
					point.y -= 15;
					bool flag6 = i == 0;
					if (flag6)
					{
						point.frame = 3;
					}
					else
					{
						point.frame = CRes.random(3);
					}
					point.fSmall = CRes.random(8, 12);
					point.fRe = point.fSmall + CRes.random(70, 100);
					point.vx = 1 + CRes.random(5);
					this.levelPaint = -1;
				}
				else
				{
					bool flag7 = this.typeEffect == 107;
					if (flag7)
					{
						point.dis = CRes.random(2);
						point.vy = CRes.random_Am(2, 5);
						point.vx = CRes.random(2, 5);
					}
				}
			}
			bool flag8 = i % 2 == 0;
			if (flag8)
			{
				point.vx = -point.vx;
			}
			this.VecEff.addElement(point);
		}
	}

	// Token: 0x060001D2 RID: 466 RVA: 0x0002FA6C File Offset: 0x0002DC6C
	private void createHachi2()
	{
		this.fRemove = CRes.random(10, 14);
		int num = CRes.random(5, 9);
		bool flag = this.typeSub == 1;
		if (flag)
		{
			num = CRes.random(3, 7);
			this.fRemove = CRes.random(6, 10);
			this.fraImgSubEff = new FrameImage(79, 25, 25);
			this.fraImgEff = new FrameImage(142, 10, 10);
		}
		else
		{
			bool flag2 = this.typeSub == 2;
			if (flag2)
			{
				this.fraImgSubEff = new FrameImage(87, 35, 35, 28, 28);
				this.fraImgEff = new FrameImage(214, 8, 8);
			}
			else
			{
				this.fraImgSubEff = new FrameImage(141, 50, 54, 36, 39);
				this.fraImgEff = new FrameImage(142, 10, 10);
			}
		}
		for (int i = 0; i < num; i++)
		{
			Point point = new Point();
			point.x = this.x + CRes.random_Am_0(20);
			point.y = this.y + CRes.random_Am_0(20);
			point.frame = CRes.random(this.fraImgEff.nFrame);
			point.dis = CRes.random(2);
			point.vy = CRes.random_Am(1, 4);
			point.vx = CRes.random(1, 4);
			bool flag3 = i % 2 == 0;
			if (flag3)
			{
				point.vx = -point.vx;
			}
			this.VecEff.addElement(point);
		}
	}

	// Token: 0x060001D3 RID: 467 RVA: 0x0002FBFC File Offset: 0x0002DDFC
	private void createEND_Lu_S1_Final()
	{
		this.fraImgEff = new FrameImage(27, 24, 32);
		this.fRemove = 10;
		bool flag = GameCanvas.isLowGraOrWP_PvP() && this.typeSub >= 4;
		if (flag)
		{
			this.typeSub = 0;
		}
		bool flag2 = this.typeSub == 1 || this.typeSub == 11 || this.typeSub == 12;
		if (flag2)
		{
			this.fraImgEff = new FrameImage(99, 32, 32);
			this.fraImgSubEff = new FrameImage(138, 62, 64, 47, 48);
			this.fRemove = 14;
		}
		else
		{
			bool flag3 = this.typeSub == 2;
			if (flag3)
			{
				this.fraImgEff = new FrameImage(225, 24, 32);
			}
			else
			{
				bool flag4 = this.typeSub == 3;
				if (flag4)
				{
					this.fraImgEff = new FrameImage(85, 34, 34, 28, 28);
				}
				else
				{
					bool flag5 = this.typeSub >= 4 && this.typeSub <= 7;
					if (flag5)
					{
						this.frame = (int)(this.typeSub - 4);
						this.fraImgEff = new FrameImage(273, 24, 24, 4);
					}
					else
					{
						bool flag6 = this.typeSub == 8;
						if (flag6)
						{
							this.fraImgEff = new FrameImage(273, 24, 24, 4);
						}
						else
						{
							bool flag7 = this.typeSub == 9;
							if (flag7)
							{
								this.frame = 2;
								this.fraImgEff = new FrameImage(273, 24, 24, 4);
							}
							else
							{
								bool flag8 = this.typeSub == 10;
								if (flag8)
								{
									this.fraImgEff = new FrameImage(99, 32, 32);
								}
								else
								{
									bool flag9 = this.typeSub == 13;
									if (flag9)
									{
										this.fraImgEff = new FrameImage(104, 3);
									}
								}
							}
						}
					}
				}
			}
		}
		for (int i = 0; i < 3; i++)
		{
			Point o = new Point(this.x + CRes.random_Am_0(15), this.y + CRes.random_Am_0(15));
			this.VecEff.addElement(o);
		}
	}

	// Token: 0x060001D4 RID: 468 RVA: 0x0002FE24 File Offset: 0x0002E024
	private void createUssop11()
	{
		this.fraImgEff = new FrameImage(113, 25, 25);
		this.fraImgSubEff = new FrameImage(52, 5, 5);
		this.fRemove = 16;
		this.numNextFrame = 2;
		for (int i = 0; i < 10; i++)
		{
			Point point = new Point(this.x + CRes.random_Am_0(3), this.y + CRes.random_Am_0(3));
			point.vx = CRes.random_Am_0(5);
			point.vy = -5 + CRes.random_Am_0(5);
			point.f = CRes.random(4);
			this.VecEff.addElement(point);
		}
	}

	// Token: 0x060001D5 RID: 469 RVA: 0x0002FEC8 File Offset: 0x0002E0C8
	private void createUssop10()
	{
		this.fraImgEff = new FrameImage(112, 20, 14);
		this.vMax = 12;
		int num = this.toX - this.x;
		int num2 = this.toY - this.y;
		base.create_Speed(num, num2, null);
		int frameAngle = CRes.angle(num, num2);
		this.frame = base.setFrameAngle(frameAngle);
	}

	// Token: 0x060001D6 RID: 470 RVA: 0x0002FF2C File Offset: 0x0002E12C
	private void createUssop9()
	{
		bool flag = this.typeSub == 1;
		if (flag)
		{
			this.fraImgEff = new FrameImage(107, 50, 54, 38, 41);
		}
		else
		{
			this.fraImgEff = new FrameImage(108, 38, 38, 32, 32);
		}
		this.fraImgSubEff = new FrameImage(110, 5, 5);
		this.fraImgSub2Eff = new FrameImage(109, 9, 9);
		this.fRemove = 30;
		this.numNextFrame = 2;
		for (int i = 0; i < 30; i++)
		{
			Point point = new Point(this.x + CRes.random_Am_0(3), this.y + CRes.random_Am_0(3));
			point.vx = CRes.random_Am_0(5);
			point.vy = -5 + CRes.random_Am_0(5);
			point.f = CRes.random(4);
			bool flag2 = this.frame == 1;
			if (flag2)
			{
				point.frame = CRes.random(this.fraImgSubEff.nFrame);
			}
			else
			{
				point.frame = CRes.random((int)(2 + this.typeSub));
			}
			this.VecEff.addElement(point);
		}
	}

	// Token: 0x060001D7 RID: 471 RVA: 0x00030054 File Offset: 0x0002E254
	private void createUssopS3_Lv4()
	{
		bool flag = this.typeSub == 1;
		if (flag)
		{
			this.frame = 1;
		}
		else
		{
			bool flag2 = this.typeSub == 2;
			if (flag2)
			{
				this.frame = 0;
			}
			else
			{
				this.frame = CRes.random(2);
			}
		}
		bool flag3 = this.frame == 0;
		if (flag3)
		{
			this.fraImgEff = new FrameImage(108, 38, 38, 32, 32);
			this.fraImgSubEff = new FrameImage(110, 5, 5);
			this.fraImgSub2Eff = new FrameImage(109, 9, 9);
		}
		else
		{
			this.fraImgEff = new FrameImage(113, 25, 25);
			this.fraImgSubEff = new FrameImage(221, 5, 5, 4);
			this.fraImgSub2Eff = new FrameImage(220, 9, 9, 4);
		}
		this.fRemove = 30;
		this.numNextFrame = 2;
		for (int i = 0; i < 30; i++)
		{
			Point point = new Point(this.x + CRes.random_Am_0(3), this.y + CRes.random_Am_0(3));
			point.vx = CRes.random_Am_0(6);
			point.vy = -7 + CRes.random_Am_0(5);
			point.f = CRes.random(4);
			bool flag4 = this.frame == 1;
			if (flag4)
			{
				point.fSmall = CRes.random(9);
			}
			point.frame = CRes.random(3);
			this.VecEff.addElement(point);
		}
	}

	// Token: 0x060001D8 RID: 472 RVA: 0x000301D0 File Offset: 0x0002E3D0
	private void createUssopS3_Lv6()
	{
		bool flag = this.typeSub != 0;
		if (flag)
		{
			this.frame = (int)this.typeSub;
		}
		else
		{
			this.frame = CRes.random(3);
		}
		bool flag2 = this.frame == 1;
		if (flag2)
		{
			this.fraImgEff = new FrameImage(19, 5);
			this.fraImgSubEff = new FrameImage(110, 5, 5);
			this.fraImgSub2Eff = new FrameImage(109, 9, 9);
		}
		else
		{
			bool flag3 = this.frame == 2;
			if (flag3)
			{
				this.fraImgEff = new FrameImage(50, 3);
				this.fraImgSubEff = new FrameImage(109, 9, 9);
				this.fraImgSub2Eff = new FrameImage(220, 9, 9, 4);
			}
			else
			{
				this.fraImgEff = new FrameImage(113, 25, 25);
				this.fraImgSubEff = new FrameImage(221, 5, 5, 4);
				this.fraImgSub2Eff = new FrameImage(51, 9, 9);
			}
		}
		this.fRemove = 30;
		this.numNextFrame = 2;
		for (int i = 0; i < 30; i++)
		{
			Point point = new Point(this.x + CRes.random_Am_0(3), this.y + CRes.random_Am_0(3));
			point.vx = CRes.random_Am_0(6);
			point.vy = -7 + CRes.random_Am_0(5);
			point.f = CRes.random(4);
			bool flag4 = this.frame == 1;
			if (flag4)
			{
				point.fSmall = CRes.random(9);
			}
			point.frame = CRes.random(3);
			this.VecEff.addElement(point);
		}
	}

	// Token: 0x060001D9 RID: 473 RVA: 0x00030374 File Offset: 0x0002E574
	private void createEff_Firework()
	{
		this.frame = CRes.random(3);
		bool flag = this.frame == 0;
		if (flag)
		{
			this.fraImgEff = new FrameImage(108, 5);
		}
		else
		{
			bool flag2 = this.frame == 1;
			if (flag2)
			{
				this.fraImgEff = new FrameImage(50, 3);
			}
			else
			{
				this.fraImgEff = new FrameImage(113, 5);
			}
		}
		this.fRemove = 10;
	}

	// Token: 0x060001DA RID: 474 RVA: 0x000303E4 File Offset: 0x0002E5E4
	private void create_Sanji6()
	{
		this.fraImgEff = new FrameImage(78, 22, 28);
		int num = CRes.random_Am(1, 4);
		Point point = new Point(this.x, this.y);
		point.vx = num;
		point.vy = -3;
		point.fRe = CRes.random(7, 12);
		this.VecEff.addElement(point);
		point = new Point(this.x, this.y);
		point.vx = -num;
		point.vy = 3;
		point.fRe = CRes.random(7, 12);
		this.VecEff.addElement(point);
		bool flag = this.typeSub == 1;
		if (flag)
		{
			point = new Point(this.x, this.y);
			point.vx = -num;
			point.vy = -3;
			point.fRe = CRes.random(10, 14);
			this.VecEff.addElement(point);
			point = new Point(this.x, this.y);
			point.vx = num;
			point.vy = 3;
			point.fRe = CRes.random(10, 14);
			this.VecEff.addElement(point);
		}
	}

	// Token: 0x060001DB RID: 475 RVA: 0x0003050C File Offset: 0x0002E70C
	private void createEffectSkill1()
	{
		bool flag = GameCanvas.isLowGraOrWP_PvP();
		if (flag)
		{
			this.removeEff();
		}
		else
		{
			bool flag2 = this.typeSub == 3;
			if (flag2)
			{
				this.fraImgEff = new FrameImage(109, 4);
			}
			else
			{
				bool flag3 = this.typeSub == 2;
				if (flag3)
				{
					this.fraImgEff = new FrameImage(110, 5, 5);
				}
				else
				{
					bool flag4 = this.typeSub == 1;
					if (flag4)
					{
						this.fraImgEff = new FrameImage(52, 5, 5);
					}
					else
					{
						this.fraImgEff = new FrameImage(54, 5, 5);
					}
				}
			}
			int num = CRes.random(4, 7);
			for (int i = 0; i < num; i++)
			{
				Point point = new Point(this.x + CRes.random_Am_0(5), this.y + CRes.random_Am_0(5));
				point.vx = CRes.random_Am(1, 5);
				point.vy = -7 + CRes.random(1, 4);
				point.fRe = CRes.random(10, 14);
				point.frame = CRes.random(this.fraImgEff.nFrame);
				this.VecEff.addElement(point);
			}
		}
	}

	// Token: 0x060001DC RID: 476 RVA: 0x0003063C File Offset: 0x0002E83C
	private void createCharTeleportNew()
	{
		this.fRemove = 15;
		this.fraImgEff = new FrameImage(66, 15, 55, 1);
		this.fraImgSubEff = new FrameImage(67, 3, 25, 1);
		this.y -= 150;
		this.vy = 30;
		Point point = new Point(this.x, this.y);
		point.vy = this.vy;
		point.dis = 1;
		point.frame = 0;
		point.fRe = 10;
		this.VecEff.addElement(point);
	}

	// Token: 0x060001DD RID: 477 RVA: 0x000306D0 File Offset: 0x0002E8D0
	private void createCharTeleport()
	{
		this.fRemove = 15;
		this.fraImgEff = new FrameImage(66, 15, 55, 1);
		this.fraImgSubEff = new FrameImage(67, 3, 25, 1);
		for (int i = 0; i < 10; i++)
		{
			Point point = new Point(this.x + CRes.random_Am_0(20), this.y - CRes.random(30) + 10);
			point.vy = -2 - CRes.random(4);
			point.dis = 0;
			point.frame = CRes.random(this.fraImgSubEff.nFrame);
			point.fRe = CRes.random(12, 20);
			this.VecEff.addElement(point);
		}
	}

	// Token: 0x060001DE RID: 478 RVA: 0x0003078C File Offset: 0x0002E98C
	private void createGet_Up()
	{
		this.fraImgEff = new FrameImage(199, 30, 16);
		this.fRemove = 10;
		for (int i = 0; i < 4; i++)
		{
			Point point = new Point();
			point.x = this.x + CRes.random_Am_0(10);
			point.y = this.y + CRes.random_Am_0(5);
			point.vx = -2 + i % 2 * 4 + CRes.random_Am_0(2);
			point.vy = -1 + CRes.random_Am_0(3);
			point.frame = CRes.random(2);
			point.fRe = CRes.random(6, 10);
			this.VecEff.addElement(point);
		}
	}

	// Token: 0x060001DF RID: 479 RVA: 0x00030844 File Offset: 0x0002EA44
	private void createRevice()
	{
		this.timeBegin = GameCanvas.timeNow;
		this.fraImgEff = new FrameImage(179, 54, 25);
		this.fraImgSubEff = new FrameImage(121, 32, 32);
		this.timeEnd = 1000;
		for (int i = 0; i < 3; i++)
		{
			Point point = new Point();
			point.y = -CRes.random(30);
			point.vy = CRes.random_Am(3, 8);
			point.frame = 3 + CRes.random(3);
			this.VecEff.addElement(point);
		}
	}

	// Token: 0x060001E0 RID: 480 RVA: 0x000308DC File Offset: 0x0002EADC
	private void create_Upgrade_Thanh_Cong()
	{
		this.fraImgEff = new FrameImage(51, 9, 9);
		this.fraImgSubEff = new FrameImage(52, 5, 5);
		int num = CRes.random(25, 40);
		for (int i = 0; i < num; i++)
		{
			Point point = new Point(this.x + CRes.random_Am_0(6), this.y + CRes.random_Am_0(6));
			point.fRe = CRes.random(20, 30);
			point.vx = CRes.random_Am(1, 6);
			point.vy = CRes.random_Am(1, 6);
			point.frame = CRes.random(3);
			this.VecEff.addElement(point);
		}
	}

	// Token: 0x060001E1 RID: 481 RVA: 0x00030988 File Offset: 0x0002EB88
	private void createPartical()
	{
		this.fRemove = CRes.random(12, 18);
		this.fraImgSubEff = new FrameImage(220, 9, 9, 4);
		this.fraImgEff = new FrameImage(221, 5, 5, 4);
		int num = CRes.random(8, 12);
		for (int i = 0; i < num; i++)
		{
			Point point = new Point();
			point.x = this.x + CRes.random_Am_0(3);
			point.y = this.y + CRes.random_Am_0(5);
			point.frame = CRes.random(4);
			point.dis = CRes.random(3);
			point.vy = CRes.random_Am(1, 4) - 5;
			point.vx = CRes.random(6);
			bool flag = i % 2 == 0;
			if (flag)
			{
				point.vx = -point.vx;
			}
			this.VecEff.addElement(point);
		}
	}

	// Token: 0x060001E2 RID: 482 RVA: 0x00030A78 File Offset: 0x0002EC78
	private void createLittleDamBoss()
	{
		bool flag = this.typeSub == 0;
		if (flag)
		{
			this.x = MotherCanvas.w / 2 - 60;
		}
		else
		{
			this.x = MotherCanvas.w / 2 + 100;
		}
		this.y = 40;
		this.fRemove = CRes.random(16, 22);
		this.fraImgEff = new FrameImage(139, 10, 10);
		int num = CRes.random(5, 9);
		for (int i = 0; i < num; i++)
		{
			Point point = new Point();
			point.x = this.x + CRes.random_Am_0(5);
			point.y = this.y + CRes.random_Am_0(7);
			point.frame = CRes.random(this.fraImgEff.nFrame);
			point.dis = CRes.random(2);
			point.vy = -CRes.random(6, 9);
			point.vx = CRes.random(1, 4);
			bool flag2 = i % 2 == 0;
			if (flag2)
			{
				point.vx = -point.vx;
			}
			this.VecEff.addElement(point);
		}
	}

	// Token: 0x060001E3 RID: 483 RVA: 0x00030B9C File Offset: 0x0002ED9C
	private void createLittleHpBoss()
	{
		bool flag = this.typeSub == 0;
		if (flag)
		{
			this.x = MotherCanvas.w / 2 - 60;
		}
		else
		{
			this.x = MotherCanvas.w / 2 + 100;
		}
		this.y = 40;
		this.fraImgEff = new FrameImage(204, 7, 7);
		this.fRemove = 12;
		for (int i = 0; i < 6; i++)
		{
			Point point = new Point(this.x + CRes.random_Am_0(30), this.y + CRes.random_Am_0(10));
			point.fRe = CRes.random(8, 11);
			point.vy = -CRes.random(5, 7);
			this.VecEff.addElement(point);
		}
	}

	// Token: 0x060001E4 RID: 484 RVA: 0x00030C5C File Offset: 0x0002EE5C
	private void createMr3_1()
	{
		this.fraImgEff = new FrameImage(210, 63, 75, 44, 52);
		this.mPlayFrame = new int[]
		{
			0,
			0,
			1,
			1,
			1,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			1,
			1,
			0,
			0,
			0
		};
		this.fRemove = this.mPlayFrame.Length;
	}

	// Token: 0x060001E5 RID: 485 RVA: 0x00030CA8 File Offset: 0x0002EEA8
	private void createKuromarimo()
	{
		this.fraImgEff = new FrameImage(207, 14, 14);
		this.fraImgSubEff = new FrameImage(78, 22, 28);
		this.fRemove = 30;
		bool flag = this.objTo != null;
		if (flag)
		{
			bool flag2 = this.typeSub == 0;
			if (flag2)
			{
				this.x = this.objTo.x + 6;
			}
			else
			{
				this.x = this.objTo.x - 6;
			}
			this.y = this.objTo.y - this.objTo.hOne / 2 + 14;
		}
	}

	// Token: 0x060001E6 RID: 486 RVA: 0x00030D50 File Offset: 0x0002EF50
	public void createChopper()
	{
		this.fraImgEff = new FrameImage(204, 7, 7);
		this.fRemove = 12;
		for (int i = 0; i < 4; i++)
		{
			Point point = new Point(this.x + CRes.random_Am_0(20), this.y + CRes.random_Am_0(10));
			point.fRe = CRes.random(8, 11);
			point.vy = -CRes.random(5, 7);
			this.VecEff.addElement(point);
		}
	}

	// Token: 0x060001E7 RID: 487 RVA: 0x00030DD8 File Offset: 0x0002EFD8
	private void createClassZoro()
	{
		this.vMax = 18;
		int xdich = this.objTo.x - this.x;
		int ydich = this.objTo.y - this.y;
		base.create_Speed(xdich, ydich, null);
		this.fraImgEff = new FrameImage(10, 40, 47);
		this.fraImgSubEff = new FrameImage(183, 20, 54);
	}

	// Token: 0x060001E8 RID: 488 RVA: 0x00030E44 File Offset: 0x0002F044
	private void createClassUssop()
	{
		bool flag = this.objTo != null;
		if (flag)
		{
			this.y -= 25;
			this.vMax = 16;
			this.fraImgEff = new FrameImage(188, 9, 16);
			Point_Focus point_Focus = new Point_Focus();
			int xdich = this.objTo.x - this.x;
			int ydich = this.objTo.y - this.objTo.hOne / 2 - (this.y - this.objTo.dy);
			point_Focus = base.create_Speed(xdich, ydich, point_Focus, this.x, this.y, this.objTo.x, this.objTo.y - this.objTo.hOne / 2);
			this.VecEff.addElement(point_Focus);
		}
		else
		{
			this.isRemove = true;
		}
	}

	// Token: 0x060001E9 RID: 489 RVA: 0x00030F28 File Offset: 0x0002F128
	private void createClassNami()
	{
		this.fRemove = 8;
		bool flag = this.typeEffect == 159;
		if (flag)
		{
			this.fraImgEff = new FrameImage(387, 24, 240);
			this.fraImgSubEff = new FrameImage(26, 40, 20);
		}
		else
		{
			this.fraImgEff = new FrameImage(24, 15, 240);
			this.fraImgSubEff = new FrameImage(26, 40, 20);
		}
		GameScreen.addEffectEnd(59, 0, this.x, this.y, this.Dir, this.objMainEff);
	}

	// Token: 0x060001EA RID: 490 RVA: 0x00030FC4 File Offset: 0x0002F1C4
	private void create_US_S2_L5()
	{
		this.fraImgEff = new FrameImage(283, 22, 28);
		bool flag = this.typeEffect == 140;
		if (flag)
		{
			this.fraImgSubEff = new FrameImage(78, 22, 28);
		}
		else
		{
			this.fraImgSubEff = new FrameImage(78, 22, 28, 5);
		}
		this.x += CRes.random_Am_0(5);
		this.y += CRes.random_Am_0(5);
		Point point = new Point(this.x + CRes.random_Am_0(3), this.y + CRes.random_Am_0(3));
		point.frame = 0;
		this.VecEff.addElement(point);
		Point point2 = new Point(this.x + CRes.random_Am_0(3), this.y + CRes.random_Am_0(3));
		point2.frame = 1;
		this.VecEff.addElement(point2);
		this.fRemove = CRes.random(8, 20);
	}

	// Token: 0x060001EB RID: 491 RVA: 0x000310BC File Offset: 0x0002F2BC
	private void createZoro_S3()
	{
		this.vx = -10;
		bool flag = this.Dir == 2;
		if (flag)
		{
			this.vx = 10;
		}
		bool flag2 = this.typeSub == 1;
		if (flag2)
		{
			this.fraImgEff = new FrameImage(423, 32, 60);
		}
		else
		{
			this.fraImgEff = new FrameImage(322, 32, 60);
		}
		this.numNextFrame = 1;
		this.fRemove = 12;
		bool flag3 = this.typeSub == 0;
		if (flag3)
		{
			for (int i = 0; i < 3; i++)
			{
				Point point = new Point(this.x, this.y - 15 + i * 15);
				bool flag4 = this.Dir == 2;
				if (flag4)
				{
					point.x -= 6 * i;
				}
				else
				{
					point.x += 6 * i;
				}
				point.fRe = 12;
				this.VecEff.addElement(point);
				int num = point.x;
				num = ((this.Dir != 2) ? (num - 10) : (num + 10));
				GameScreen.addEffectEnd_ToX_ToY(62, 0, num, point.y - 17, num + 12 * this.vx, point.y - 17, this.Dir, this.objMainEff);
			}
		}
		else
		{
			bool flag5 = this.typeSub != 1;
			if (!flag5)
			{
				for (int j = 0; j < 4; j++)
				{
					Point point2 = new Point(this.x, this.y - 21 + j * 14);
					bool flag6 = this.Dir == 2;
					if (flag6)
					{
						point2.x -= 6 * j;
					}
					else
					{
						point2.x += 6 * j;
					}
					point2.fRe = 12;
					this.VecEff.addElement(point2);
					int num2 = point2.x;
					num2 = ((this.Dir != 2) ? (num2 - 10) : (num2 + 10));
					GameScreen.addEffectEnd_ToX_ToY(62, 0, num2, point2.y - 17, num2 + 12 * this.vx, point2.y - 17, this.Dir, this.objMainEff);
				}
			}
		}
	}

	// Token: 0x060001EC RID: 492 RVA: 0x00031320 File Offset: 0x0002F520
	private void createLOL_Tru_Tren()
	{
		this.fraImgEff = new FrameImage(307, 4, 5, 6);
		int num = 20;
		bool flag = GameCanvas.isLowGraOrWP_PvP();
		if (flag)
		{
			num = 10;
		}
		this.maxsize = num;
		for (int i = 0; i < num; i++)
		{
			Point point = new Point();
			point.x = CRes.random_Am_0(15);
			point.y = 10 - CRes.random(40);
			point.dis = 1 + CRes.random(3);
			point.vy = -4;
			point.frame = CRes.random(12);
			this.VecEff.addElement(point);
		}
	}

	// Token: 0x060001ED RID: 493 RVA: 0x000090B5 File Offset: 0x000072B5
	private void create_Tru_Be()
	{
	}

	// Token: 0x060001EE RID: 494 RVA: 0x000313C0 File Offset: 0x0002F5C0
	private void create_Poke_Ok()
	{
		this.fraImgEff = new FrameImage(302, 16);
		this.fraImgSubEff = new FrameImage(192, 25, 25);
		this.fraImgSub2Eff = new FrameImage(303, 49, 25);
		this.fRemove = 40;
		this.x *= 100;
		this.y *= 100;
		this.vx = CRes.random_Am(100, 300);
		this.vy = -CRes.random(600, 700);
		this.vMax = 50;
		this.frame = (int)(this.typeSub % 10);
	}

	// Token: 0x060001EF RID: 495 RVA: 0x00031470 File Offset: 0x0002F670
	private void create_Poke_Fail()
	{
		this.fraImgEff = new FrameImage(302, 16);
		this.fRemove = CRes.random(10, 16);
		this.x *= 100;
		this.y *= 100;
		this.vx = CRes.random_Am(200, 500);
		this.vy = -CRes.random(400, 600);
		this.vMax = 50;
		this.frame = (int)(this.typeSub % 10);
	}

	// Token: 0x060001F0 RID: 496 RVA: 0x00031500 File Offset: 0x0002F700
	private void create_Poke_Begin()
	{
		this.fraImgEff = new FrameImage(302, 16);
		this.fRemove = 40;
		this.vMax = 8;
		this.y = this.objMainEff.y - this.objMainEff.hOne / 2 + 6;
		this.frame = (int)(this.typeSub % 10);
		this.objMainEff.frame = 33;
		bool flag = this.objTo.x < this.objMainEff.x;
		if (flag)
		{
			this.Dir = 0;
			this.objMainEff.Dir = 0;
			this.x -= 10;
		}
		else
		{
			this.Dir = 2;
			this.objMainEff.Dir = 2;
			this.x += 10;
		}
		int xdich = this.objTo.x - this.x;
		int ydich = this.objTo.y - 10 - this.y;
		base.create_Speed(xdich, ydich, null);
		bool flag2 = this.fRemove <= 0;
		if (flag2)
		{
			this.fRemove = 1;
		}
		this.mposy = new int[this.fRemove];
		this.mposy[0] = 3;
		int num = this.fRemove / 2;
		for (int i = 1; i < this.mposy.Length; i++)
		{
			bool flag3 = i <= num;
			if (flag3)
			{
				this.mposy[i] = this.mposy[i - 1] + 3;
			}
			else
			{
				int num2 = this.mposy[i - 1] - 3;
				bool flag4 = num2 < 0;
				if (flag4)
				{
					num2 = 0;
				}
				this.mposy[i] = num2;
			}
		}
	}

	// Token: 0x060001F1 RID: 497 RVA: 0x000316B4 File Offset: 0x0002F8B4
	private void createEndLuS1L4()
	{
		this.fraImgEff = new FrameImage(274, 22, 74, 3);
		this.numNextFrame = 1;
		this.fRemove = 7;
		Point point = new Point();
		point.x = this.x;
		point.y = this.y;
		bool flag = this.Dir == 0;
		if (flag)
		{
			point.vx = -6;
		}
		else
		{
			point.vx = 6;
		}
		bool flag2 = this.typeSub == 1;
		if (flag2)
		{
			this.mPlayFrame = new int[]
			{
				3,
				4,
				4,
				4,
				3
			};
			this.fRemove = 5;
		}
		else
		{
			bool flag3 = this.typeSub == 2;
			if (flag3)
			{
				this.mPlayFrame = new int[]
				{
					3,
					4,
					4,
					3
				};
				this.fRemove = 4;
			}
			else
			{
				bool flag4 = this.typeSub == 3;
				if (flag4)
				{
					this.mPlayFrame = new int[]
					{
						0,
						4,
						2,
						6,
						2,
						4,
						0
					};
					bool flag5 = this.Dir == 0;
					if (flag5)
					{
						point.vx = -8;
					}
					else
					{
						point.vx = 8;
					}
				}
				else
				{
					bool flag6 = this.typeSub == 4;
					if (flag6)
					{
						this.mPlayFrame = new int[]
						{
							3,
							10,
							5,
							11,
							5,
							10,
							3
						};
						bool flag7 = this.Dir == 0;
						if (flag7)
						{
							point.vx = -4;
						}
						else
						{
							point.vx = 4;
						}
					}
					else
					{
						this.mPlayFrame = new int[]
						{
							0,
							1,
							2,
							2,
							2,
							1,
							0
						};
					}
				}
			}
		}
		point.fRe = this.mPlayFrame.Length;
		this.VecEff.addElement(point);
	}

	// Token: 0x060001F2 RID: 498 RVA: 0x0003185C File Offset: 0x0002FA5C
	private void create_Ice_Arc()
	{
		this.fRemove = 25;
		this.vMax = 5;
		for (int i = 0; i < 16; i++)
		{
			Point point = new Point();
			point.x = this.x * 1000;
			point.y = this.y * 1000;
			point.vx = 2 * CRes.getcos(225 * i / 10) * this.vMax;
			point.vy = CRes.getsin(225 * i / 10) * this.vMax;
			point.f = 0;
			this.VecEff.addElement(point);
		}
	}

	// Token: 0x040002E5 RID: 741
	public const sbyte END_LUFFY_2 = 0;

	// Token: 0x040002E6 RID: 742
	public const sbyte END_SANJI_1 = 1;

	// Token: 0x040002E7 RID: 743
	public const sbyte END_ZORO_1 = 86;

	// Token: 0x040002E8 RID: 744
	public const sbyte END_USSOP_1 = 3;

	// Token: 0x040002E9 RID: 745
	public const sbyte END_USSOP_2 = 4;

	// Token: 0x040002EA RID: 746
	public const sbyte END_USSOP_3 = 5;

	// Token: 0x040002EB RID: 747
	public const sbyte END_NAMI_1 = 6;

	// Token: 0x040002EC RID: 748
	public const sbyte END_NAMI_2 = 90;

	// Token: 0x040002ED RID: 749
	public const sbyte END_NAMI_3 = 8;

	// Token: 0x040002EE RID: 750
	public const sbyte END_ZORO_2 = 9;

	// Token: 0x040002EF RID: 751
	public const sbyte END_ZORO_3 = 10;

	// Token: 0x040002F0 RID: 752
	public const sbyte END_ZORO_4 = 11;

	// Token: 0x040002F1 RID: 753
	public const sbyte END_USSOP_4 = 12;

	// Token: 0x040002F2 RID: 754
	public const sbyte END_LUFFY_1 = 13;

	// Token: 0x040002F3 RID: 755
	public const sbyte END_ZORO_5 = 16;

	// Token: 0x040002F4 RID: 756
	public const sbyte END_ZORO_7 = 19;

	// Token: 0x040002F5 RID: 757
	public const sbyte END_CRI = 20;

	// Token: 0x040002F6 RID: 758
	public const sbyte END_XUYEN_GIAP = 21;

	// Token: 0x040002F7 RID: 759
	public const sbyte END_HUT_MP_HP = 22;

	// Token: 0x040002F8 RID: 760
	public const sbyte END_PHAN_DAMAGE = 23;

	// Token: 0x040002F9 RID: 761
	public const sbyte END_FOCUS_TOUCH = 24;

	// Token: 0x040002FA RID: 762
	public const sbyte END_LUFFY_6 = 25;

	// Token: 0x040002FB RID: 763
	public const sbyte END_ZORO_8 = 26;

	// Token: 0x040002FC RID: 764
	public const sbyte END_ZORO_9 = 27;

	// Token: 0x040002FD RID: 765
	public const sbyte END_SANJI_2 = 29;

	// Token: 0x040002FE RID: 766
	public const sbyte END_LINE_IN = 30;

	// Token: 0x040002FF RID: 767
	public const sbyte END_SANJI_3 = 35;

	// Token: 0x04000300 RID: 768
	public const sbyte END_SANJI_4 = 36;

	// Token: 0x04000301 RID: 769
	public const sbyte END_SANJI_5 = 37;

	// Token: 0x04000302 RID: 770
	public const sbyte END_NAMI_4 = 38;

	// Token: 0x04000303 RID: 771
	public const sbyte END_NAMI_5 = 39;

	// Token: 0x04000304 RID: 772
	public const sbyte END_NAMI_6 = 40;

	// Token: 0x04000305 RID: 773
	public const sbyte END_NAMI_7 = 41;

	// Token: 0x04000306 RID: 774
	public const sbyte END_NAMI_8 = 42;

	// Token: 0x04000307 RID: 775
	public const sbyte END_SANJI_6 = 47;

	// Token: 0x04000308 RID: 776
	public const sbyte END_USSOP_9 = 48;

	// Token: 0x04000309 RID: 777
	public const sbyte END_USSOP_10 = 49;

	// Token: 0x0400030A RID: 778
	public const sbyte END_USSOP_11 = 50;

	// Token: 0x0400030B RID: 779
	public const sbyte END_ALVIDA_1 = 89;

	// Token: 0x0400030C RID: 780
	public const sbyte END_ALVIDA_2 = 52;

	// Token: 0x0400030D RID: 781
	public const sbyte END_OPEN_BOX = 53;

	// Token: 0x0400030E RID: 782
	public const sbyte END_LUFFY_S1_FINAL = 54;

	// Token: 0x0400030F RID: 783
	public const sbyte END_PEARL_2 = 55;

	// Token: 0x04000310 RID: 784
	public const sbyte END_TELEPORT_BOSS = 56;

	// Token: 0x04000311 RID: 785
	public const sbyte END_DON_KRIEG_2 = 57;

	// Token: 0x04000312 RID: 786
	public const sbyte END_DON_KRIEG_3 = 58;

	// Token: 0x04000313 RID: 787
	public const sbyte END_ROCK = 59;

	// Token: 0x04000314 RID: 788
	public const sbyte END_HACHI_2 = 60;

	// Token: 0x04000315 RID: 789
	public const sbyte END_CHU_1 = 61;

	// Token: 0x04000316 RID: 790
	public const sbyte END_NUC_DAT = 62;

	// Token: 0x04000317 RID: 791
	public const sbyte END_NO_DAT = 63;

	// Token: 0x04000318 RID: 792
	public const sbyte END_ZORO_14 = 64;

	// Token: 0x04000319 RID: 793
	public const sbyte END_PAN_1 = 65;

	// Token: 0x0400031A RID: 794
	public const sbyte END_NO_DAT_NHO = 66;

	// Token: 0x0400031B RID: 795
	public const sbyte END_XERATH_1 = 68;

	// Token: 0x0400031C RID: 796
	public const sbyte END_URGOT_2 = 69;

	// Token: 0x0400031D RID: 797
	public const sbyte END_URGOT_4 = 70;

	// Token: 0x0400031E RID: 798
	public const sbyte END_MON_DANH_MANH = 71;

	// Token: 0x0400031F RID: 799
	public const sbyte END_MON_CHEM = 72;

	// Token: 0x04000320 RID: 800
	public const sbyte END_UPGRADE_1 = 73;

	// Token: 0x04000321 RID: 801
	public const sbyte END_UPGRADE_2 = 74;

	// Token: 0x04000322 RID: 802
	public const sbyte END_UPGRADE_3 = 75;

	// Token: 0x04000323 RID: 803
	public const sbyte END_UPGRADE_THANH_CONG = 76;

	// Token: 0x04000324 RID: 804
	public const sbyte END_UPGRADE_THAT_BAI = 77;

	// Token: 0x04000325 RID: 805
	public const sbyte END_UPGRADE_4 = 78;

	// Token: 0x04000326 RID: 806
	public const sbyte END_UPGRADE_5 = 79;

	// Token: 0x04000327 RID: 807
	public const sbyte END_TELEPORT = 80;

	// Token: 0x04000328 RID: 808
	public const sbyte END_USSOP_SEA_2 = 81;

	// Token: 0x04000329 RID: 809
	public const sbyte END_DIE_FLY = 82;

	// Token: 0x0400032A RID: 810
	public const sbyte END_REVICE = 83;

	// Token: 0x0400032B RID: 811
	public const sbyte END_GET_UP = 84;

	// Token: 0x0400032C RID: 812
	public const sbyte END_BUFF = 85;

	// Token: 0x0400032D RID: 813
	public const sbyte END_ACE_1 = 2;

	// Token: 0x0400032E RID: 814
	public const sbyte END_AOKIJI_1 = 14;

	// Token: 0x0400032F RID: 815
	public const sbyte END_AOKIJI_2 = 88;

	// Token: 0x04000330 RID: 816
	public const sbyte END_ICE = 17;

	// Token: 0x04000331 RID: 817
	public const sbyte END_SMOKE_1 = 18;

	// Token: 0x04000332 RID: 818
	public const sbyte END_UP_LV = 28;

	// Token: 0x04000333 RID: 819
	public const sbyte END_CHAR_TELEPORT_REMOVE = 31;

	// Token: 0x04000334 RID: 820
	public const sbyte END_CHAR_TELEPORT_NEW = 32;

	// Token: 0x04000335 RID: 821
	public const sbyte END_THUY_QUAI_1 = 87;

	// Token: 0x04000336 RID: 822
	public const sbyte END_THUY_QUAI_2 = 34;

	// Token: 0x04000337 RID: 823
	public const sbyte END_HP_MP = 91;

	// Token: 0x04000338 RID: 824
	public const sbyte END_MON_DIE = 92;

	// Token: 0x04000339 RID: 825
	public const sbyte END_EFFECT_SKILL_1 = 93;

	// Token: 0x0400033A RID: 826
	public const sbyte END_EFFECT_SKILL_UP_LV = 94;

	// Token: 0x0400033B RID: 827
	public const sbyte END_EFFECT_ELITE = 95;

	// Token: 0x0400033C RID: 828
	public const sbyte END_MON_VALENTINE = 45;

	// Token: 0x0400033D RID: 829
	public const sbyte END_SKILL_CLASS_NAMI = 46;

	// Token: 0x0400033E RID: 830
	public const sbyte END_SKILL_CLASS_USSOP = 96;

	// Token: 0x0400033F RID: 831
	public const sbyte END_SKILL_CLASS_ZORO = 97;

	// Token: 0x04000340 RID: 832
	public const sbyte END_CROCODILE_1 = 98;

	// Token: 0x04000341 RID: 833
	public const sbyte END_CROCODILE_2 = 99;

	// Token: 0x04000342 RID: 834
	public const sbyte END_BIG_BOSS = 100;

	// Token: 0x04000343 RID: 835
	public const sbyte END_CHOPPER_BUFF = 101;

	// Token: 0x04000344 RID: 836
	public const sbyte END_KUROMARIMO = 102;

	// Token: 0x04000345 RID: 837
	public const sbyte END_MR3_1 = 103;

	// Token: 0x04000346 RID: 838
	public const sbyte END_LITTLE_HP_BOSS = 104;

	// Token: 0x04000347 RID: 839
	public const sbyte END_LITTLE_DAM_BOSS = 105;

	// Token: 0x04000348 RID: 840
	public const sbyte END_WAPOL = 106;

	// Token: 0x04000349 RID: 841
	public const sbyte END_MR4_1 = 107;

	// Token: 0x0400034A RID: 842
	public const sbyte END_PARTICAL_VL = 108;

	// Token: 0x0400034B RID: 843
	public const sbyte END_PARTICAL_DUST = 109;

	// Token: 0x0400034C RID: 844
	public const sbyte END_ROCK_NEW = 110;

	// Token: 0x0400034D RID: 845
	public const sbyte END_SUPER_BOSS = 111;

	// Token: 0x0400034E RID: 846
	public const sbyte END_BIG_NO_DAT = 112;

	// Token: 0x0400034F RID: 847
	public const sbyte END_LAVA_1 = 113;

	// Token: 0x04000350 RID: 848
	public const sbyte END_MR2_1 = 114;

	// Token: 0x04000351 RID: 849
	public const sbyte END_EFF_BI_BE = 115;

	// Token: 0x04000352 RID: 850
	public const sbyte END_EFF_ICE_GOLEM = 116;

	// Token: 0x04000353 RID: 851
	public const sbyte END_EFF_ICE_SNOW = 117;

	// Token: 0x04000354 RID: 852
	public const sbyte END_PELL_1 = 118;

	// Token: 0x04000355 RID: 853
	public const sbyte END_LUFFY_S1_S4 = 119;

	// Token: 0x04000356 RID: 854
	public const sbyte END_USSOP_S3_LV4 = 120;

	// Token: 0x04000357 RID: 855
	public const sbyte END_ENEL_1 = 121;

	// Token: 0x04000358 RID: 856
	public const sbyte END_SATORI_1 = 122;

	// Token: 0x04000359 RID: 857
	public const sbyte END_SUPER_ATTACK = 123;

	// Token: 0x0400035A RID: 858
	public const sbyte END_OHM_1_1 = 124;

	// Token: 0x0400035B RID: 859
	public const sbyte END_OHM_1_2 = 125;

	// Token: 0x0400035C RID: 860
	public const sbyte END_POKE_OK = 126;

	// Token: 0x0400035D RID: 861
	public const sbyte END_POKE_BEGIN = 127;

	// Token: 0x0400035E RID: 862
	public const short END_POKE_FAIL = 128;

	// Token: 0x0400035F RID: 863
	public const short END_TRU_BE = 129;

	// Token: 0x04000360 RID: 864
	public const short END_LOL_TRU_TREN = 130;

	// Token: 0x04000361 RID: 865
	public const short END_LOL_TRU_DUOI = 131;

	// Token: 0x04000362 RID: 866
	public const short END_LUCCI_1 = 132;

	// Token: 0x04000363 RID: 867
	public const short END_DONG_DAT_1 = 133;

	// Token: 0x04000364 RID: 868
	public const short END_DONG_DAT_2 = 134;

	// Token: 0x04000365 RID: 869
	public const short END_ZORO_S1_L5 = 135;

	// Token: 0x04000366 RID: 870
	public const short END_ZORO_S2_L5 = 136;

	// Token: 0x04000367 RID: 871
	public const short END_ZORO_S3_L5 = 137;

	// Token: 0x04000368 RID: 872
	public const short END_NAMI_S1_L5 = 138;

	// Token: 0x04000369 RID: 873
	public const short END_NAMI_S2_L5 = 139;

	// Token: 0x0400036A RID: 874
	public const short END_USOPP_S2_L5 = 140;

	// Token: 0x0400036B RID: 875
	public const short END_ACE_1_L2 = 141;

	// Token: 0x0400036C RID: 876
	public const short END_AOKIJI_2_L2 = 142;

	// Token: 0x0400036D RID: 877
	public const short END_KICH_AN = 143;

	// Token: 0x0400036E RID: 878
	public const short END_LINE_IN_BIG = 144;

	// Token: 0x0400036F RID: 879
	public const short END_LINE_IN_OPEN_CHEST = 145;

	// Token: 0x04000370 RID: 880
	public const short END_SMOKER_L2 = 146;

	// Token: 0x04000371 RID: 881
	public const short END_LUCCI_L2 = 147;

	// Token: 0x04000372 RID: 882
	public const short END_KILO_L1 = 148;

	// Token: 0x04000373 RID: 883
	public const short END_CHOANG_SERVER = 149;

	// Token: 0x04000374 RID: 884
	public const short END_KIET_SUC_SERVER = 150;

	// Token: 0x04000375 RID: 885
	public const short END_BEGIN_EFF_CHIEM_DAO = 151;

	// Token: 0x04000376 RID: 886
	public const short END_KHANG_TAT_CA_SERVER = 152;

	// Token: 0x04000377 RID: 887
	public const short END_THA_DEN = 153;

	// Token: 0x04000378 RID: 888
	public const short END_UPGRADE_6 = 154;

	// Token: 0x04000379 RID: 889
	public const short END_UPGRADE_7 = 155;

	// Token: 0x0400037A RID: 890
	public const short END_TU_CHOI_TU_THAN = 156;

	// Token: 0x0400037B RID: 891
	public const short END_FIRE_FULL_SET = 157;

	// Token: 0x0400037C RID: 892
	public const short END_THA_PHAO_HOA = 158;

	// Token: 0x0400037D RID: 893
	public const short END_LIGHTING_RED = 159;

	// Token: 0x0400037E RID: 894
	public const short END_EF_VALENTINE_RUN = 160;

	// Token: 0x0400037F RID: 895
	public const short END_EF_VALENTINE_STAND = 161;

	// Token: 0x04000380 RID: 896
	public const short END_EF_LAW_HEART = 162;

	// Token: 0x04000381 RID: 897
	public const short END_EF_LAW_HEART_FRIST = 163;

	// Token: 0x04000382 RID: 898
	public const short END_EF_TRAI_AC_QUY_VU_TRU = 164;

	// Token: 0x04000383 RID: 899
	public const short END_EF_FASHION_RAU_DEN = 165;

	// Token: 0x04000384 RID: 900
	public const short END_EF_FASHION_RAU_DEN_2 = 166;

	// Token: 0x04000385 RID: 901
	public const short END_USOPP_S2_L6 = 167;

	// Token: 0x04000386 RID: 902
	public const short END_USSOP_S3_LV6 = 168;

	// Token: 0x04000387 RID: 903
	public const sbyte END_LUFFY_SHOW = 33;

	// Token: 0x04000388 RID: 904
	public const sbyte END_ZORO_SHOW = 15;

	// Token: 0x04000389 RID: 905
	public const sbyte END_SANJI_SHOW = 44;

	// Token: 0x0400038A RID: 906
	public const sbyte END_NAMI_SHOW = 51;

	// Token: 0x0400038B RID: 907
	public const sbyte END_USS_SHOW = 7;

	// Token: 0x0400038C RID: 908
	public const short END_FIREWORK = 169;

	// Token: 0x0400038D RID: 909
	public const short END_ZORO_XOAY_NUOC = 170;

	// Token: 0x0400038E RID: 910
	public const short END_GONG_DAM = 171;

	// Token: 0x0400038F RID: 911
	public const short END_DAP_DAT = 172;

	// Token: 0x04000390 RID: 912
	public const short END_RONG_TAP = 173;

	// Token: 0x04000391 RID: 913
	public const short END_LOI_NGUC = 174;

	// Token: 0x04000392 RID: 914
	public const short END_NAMI_S3_L6 = 175;

	// Token: 0x04000393 RID: 915
	public const short END_DOOR = 176;

	// Token: 0x04000394 RID: 916
	public const short END_TAIXIU = 177;

	// Token: 0x04000395 RID: 917
	public const short END_GOAL = 178;

	// Token: 0x04000396 RID: 918
	private sbyte typeSub;

	// Token: 0x04000397 RID: 919
	private mVector VecEff = new mVector();

	// Token: 0x04000398 RID: 920
	private mVector vecSubEff = new mVector();

	// Token: 0x04000399 RID: 921
	private int randomf;

	// Token: 0x0400039A RID: 922
	private int randomf2;

	// Token: 0x0400039B RID: 923
	private int lengthM;

	// Token: 0x0400039C RID: 924
	private MainObject objTo;

	// Token: 0x0400039D RID: 925
	private bool isUpdateNormal = true;

	// Token: 0x0400039E RID: 926
	private int[] mPlayFrame;

	// Token: 0x0400039F RID: 927
	private int[][] mPlayFrameVip;

	// Token: 0x040003A0 RID: 928
	private long time;

	// Token: 0x040003A1 RID: 929
	private int timeRemove;

	// Token: 0x040003A2 RID: 930
	private int[] mposy;

	// Token: 0x040003A3 RID: 931
	private int maxsize;

	// Token: 0x040003A4 RID: 932
	private int[][] mPaintEFF;

	// Token: 0x040003A5 RID: 933
	private int[] arrFrame = new int[]
	{
		0,
		0,
		0,
		1,
		1,
		1,
		2,
		2,
		2,
		3,
		3,
		3,
		4,
		4,
		4
	};

	// Token: 0x040003A6 RID: 934
	private int tframe;

	// Token: 0x040003A7 RID: 935
	public static int[][] colorStar = new int[][]
	{
		new int[]
		{
			16310304,
			16298056,
			16777215
		},
		new int[]
		{
			7045120,
			12643960,
			16777215
		},
		new int[]
		{
			2407423,
			11987199,
			16777215
		}
	};

	// Token: 0x040003A8 RID: 936
	private int[] colorpaint;

	// Token: 0x040003A9 RID: 937
	private int indexColorStar;

	// Token: 0x040003AA RID: 938
	private int xline;

	// Token: 0x040003AB RID: 939
	private int yline;
}
