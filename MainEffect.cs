using System;

// Token: 0x02000076 RID: 118
public class MainEffect
{
	// Token: 0x0600070C RID: 1804 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void paint(mGraphics g)
	{
	}

	// Token: 0x0600070D RID: 1805 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void paint(mGraphics g, int x, int y)
	{
	}

	// Token: 0x0600070E RID: 1806 RVA: 0x00073788 File Offset: 0x00071988
	public virtual bool CreateEffectSkill()
	{
		return true;
	}

	// Token: 0x0600070F RID: 1807 RVA: 0x0000A8F0 File Offset: 0x00008AF0
	public virtual void update()
	{
		this.f++;
		this.x += this.vx;
		this.y += this.vy;
	}

	// Token: 0x06000710 RID: 1808 RVA: 0x0000A927 File Offset: 0x00008B27
	public void setPosition(int x, int y, int xto, int yto)
	{
		this.x = x;
		this.y = y;
		this.toX = xto;
		this.toY = yto;
	}

	// Token: 0x06000711 RID: 1809 RVA: 0x00099604 File Offset: 0x00097804
	public static bool isInScreen(int x, int y, int w, int h)
	{
		bool flag = x < MainScreen.cameraMain.xCam - w || x > MainScreen.cameraMain.xCam + MotherCanvas.w + w || y < MainScreen.cameraMain.yCam - h || y > MainScreen.cameraMain.yCam + MotherCanvas.h + h;
		return !flag;
	}

	// Token: 0x06000712 RID: 1810 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void replaceHP(mVector vec)
	{
	}

	// Token: 0x06000713 RID: 1811 RVA: 0x0009966C File Offset: 0x0009786C
	public Point_Focus create_Speed(int xdich, int ydich, Point_Focus p)
	{
		bool flag = ydich == 0;
		if (flag)
		{
			ydich = 1;
		}
		bool flag2 = xdich == 0;
		if (flag2)
		{
			xdich = 1;
		}
		int num = MainObject.getDistance(xdich, ydich) / this.vMax;
		bool flag3 = num == 0;
		if (flag3)
		{
			num = 1;
		}
		int a = xdich / num;
		int a2 = ydich / num;
		bool flag4 = CRes.abs(a) > CRes.abs(xdich);
		if (flag4)
		{
			a = xdich;
		}
		bool flag5 = CRes.abs(a2) > CRes.abs(ydich);
		if (flag5)
		{
			a2 = ydich;
		}
		bool flag6 = p != null;
		if (flag6)
		{
			p.x = this.x;
			p.y = this.y;
			p.vx = a;
			p.vy = a2;
			p.toX = this.toX;
			p.toY = this.toY;
			p.fRe = num;
		}
		else
		{
			this.fRemove = num;
			this.vx = a;
			this.vy = a2;
		}
		return p;
	}

	// Token: 0x06000714 RID: 1812 RVA: 0x00099760 File Offset: 0x00097960
	public Point_Focus create_Speed(int xdich, int ydich, Point_Focus p, int x, int y, int toX, int toY)
	{
		bool flag = ydich == 0;
		if (flag)
		{
			ydich = 1;
		}
		bool flag2 = xdich == 0;
		if (flag2)
		{
			xdich = 1;
		}
		int num = MainObject.getDistance(xdich, ydich) / this.vMax;
		bool flag3 = num == 0;
		if (flag3)
		{
			num = 1;
		}
		int a = xdich / num;
		int a2 = ydich / num;
		bool flag4 = CRes.abs(a) > CRes.abs(xdich);
		if (flag4)
		{
			a = xdich;
		}
		bool flag5 = CRes.abs(a2) > CRes.abs(ydich);
		if (flag5)
		{
			a2 = ydich;
		}
		bool flag6 = p != null;
		if (flag6)
		{
			p.x = x;
			p.y = y;
			p.vx = a;
			p.vy = a2;
			p.toX = toX;
			p.toY = toY;
			p.fRe = num;
		}
		else
		{
			this.fRemove = num;
			this.vx = a;
			this.vy = a2;
		}
		return p;
	}

	// Token: 0x06000715 RID: 1813 RVA: 0x00099844 File Offset: 0x00097A44
	public void setInfoNormal(MainObject objset)
	{
		bool flag = objset == null;
		if (flag)
		{
			this.goc_Arc = 0;
		}
		else
		{
			switch (objset.Dir)
			{
			case 0:
				this.goc_Arc = 180;
				break;
			case 1:
				this.goc_Arc = 270;
				break;
			case 2:
				this.goc_Arc = 0;
				break;
			case 3:
				this.goc_Arc = 90;
				break;
			}
		}
		this.va = 4096;
		this.vx = 0;
		this.vy = 0;
		this.life = 0;
		this.vx1000 = this.va * CRes.getcos(this.goc_Arc) >> 10;
		this.vy1000 = this.va * CRes.getsin(this.goc_Arc) >> 10;
	}

	// Token: 0x06000716 RID: 1814 RVA: 0x0009990C File Offset: 0x00097B0C
	public void setInfoNormalPhaoHoa(MainObject objset)
	{
		this.goc_Arc = 270;
		this.va = 4096;
		this.vx = 0;
		this.vy = 0;
		this.life = 0;
		this.vx1000 = this.va * CRes.getcos(this.goc_Arc) >> 10;
		this.vy1000 = this.va * CRes.getsin(this.goc_Arc) >> 10;
	}

	// Token: 0x06000717 RID: 1815 RVA: 0x0009997C File Offset: 0x00097B7C
	public bool updateAngleNormal(MainObject objset, int hPlus)
	{
		bool flag = objset == null;
		bool result;
		if (flag)
		{
			this.stopUpdateNormal();
			result = true;
		}
		else
		{
			int num = objset.x - this.x;
			int num2 = objset.y - (objset.hOne >> 1) - hPlus - this.y;
			this.life++;
			bool flag2 = (CRes.abs(num) < this.vMax / 1000 && CRes.abs(num2) < this.vMax / 1000) || this.life > this.fRemove;
			if (flag2)
			{
				this.stopUpdateNormal();
				result = true;
			}
			else
			{
				int num3 = CRes.angle(num, num2);
				bool flag3 = CRes.abs(num3 - this.goc_Arc) < 90 || num * num + num2 * num2 > 4096;
				if (flag3)
				{
					bool flag4 = CRes.abs(num3 - this.goc_Arc) < 15;
					if (flag4)
					{
						this.goc_Arc = num3;
					}
					else
					{
						bool flag5 = (num3 - this.goc_Arc >= 0 && num3 - this.goc_Arc < 180) || num3 - this.goc_Arc < -180;
						if (flag5)
						{
							this.goc_Arc = CRes.fixangle(this.goc_Arc + 15);
						}
						else
						{
							this.goc_Arc = CRes.fixangle(this.goc_Arc - 15);
						}
					}
				}
				bool flag6 = this.va < this.vMax;
				if (flag6)
				{
					this.va += 2048;
				}
				this.vx1000 = this.va * CRes.getcos(this.goc_Arc) >> 10;
				this.vy1000 = this.va * CRes.getsin(this.goc_Arc) >> 10;
				num += this.vx1000;
				int num4 = num >> 10;
				this.x += num4;
				num &= 1023;
				num2 += this.vy1000;
				int num5 = num2 >> 10;
				this.y += num5;
				num2 &= 1023;
				result = false;
			}
		}
		return result;
	}

	// Token: 0x06000718 RID: 1816 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void removeEff()
	{
	}

	// Token: 0x06000719 RID: 1817 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void stopUpdateNormal()
	{
	}

	// Token: 0x0600071A RID: 1818 RVA: 0x00099B90 File Offset: 0x00097D90
	public void setAva(int level, MainObject obj)
	{
		bool flag = obj == null || obj.returnAction();
		if (!flag)
		{
			bool flag2 = level == -1;
			if (flag2)
			{
				obj.vXEffAva = 0;
			}
			switch (level)
			{
			case 0:
			{
				bool flag3 = obj.dy == 0;
				if (flag3)
				{
					obj.dy = 12;
				}
				break;
			}
			case 1:
			{
				bool flag4 = this.Dir == 0;
				if (flag4)
				{
					obj.vXEffAva = -4;
				}
				else
				{
					obj.vXEffAva = 4;
				}
				bool flag5 = obj.dy == 0;
				if (flag5)
				{
					obj.dy = 16;
				}
				break;
			}
			case 2:
			{
				bool flag6 = this.Dir == 0;
				if (flag6)
				{
					obj.vXEffAva = -6;
				}
				else
				{
					obj.vXEffAva = 6;
				}
				bool flag7 = obj.dy == 0;
				if (flag7)
				{
					obj.dy = 20;
				}
				break;
			}
			}
			bool flag8 = LoadMap.specMap == 4;
			if (flag8)
			{
				obj.vXEffAva = 0;
			}
			bool flag9 = obj.typeObject == 1 && (obj.getTypeMoveMonster() == 9 || obj.getTypeMoveMonster() == 8 || obj.getTypeMoveMonster() == 19);
			if (flag9)
			{
				obj.vXEffAva = 0;
			}
			bool flag10 = obj.Action != 4 && obj.Action != 2 && obj.Hp > 0;
			if (flag10)
			{
				obj.Action = 3;
				obj.f = 0;
				obj.resetAction();
			}
			else
			{
				obj.vXEffAva = 0;
				obj.dy = 0;
			}
		}
	}

	// Token: 0x0600071B RID: 1819 RVA: 0x00099D18 File Offset: 0x00097F18
	public void setDy(int value, MainObject obj)
	{
		bool flag = obj != null && !obj.returnAction();
		if (flag)
		{
			obj.dy = value;
			bool flag2 = obj.Action != 4 && obj.Action != 2;
			if (flag2)
			{
				obj.Action = 3;
				obj.f = 0;
			}
		}
	}

	// Token: 0x0600071C RID: 1820 RVA: 0x0000A947 File Offset: 0x00008B47
	public void paint_Bullet(mGraphics g, FrameImage frm, int index, int x, int y, bool isMore, int fbegin)
	{
		frm.drawFrame(this.mImageBullet[index], x, y, this.mXoayBullet[index], 3, g);
	}

	// Token: 0x0600071D RID: 1821 RVA: 0x00099D70 File Offset: 0x00097F70
	public int setFrameAngle(int goc)
	{
		bool flag = goc <= 15 || goc > 345;
		int result;
		if (flag)
		{
			result = 12;
		}
		else
		{
			int num = (goc - 15) / 15 + 1;
			bool flag2 = num > 24;
			if (flag2)
			{
				num = 24;
			}
			result = this.mpaintone_Bullet[num];
		}
		return result;
	}

	// Token: 0x0600071E RID: 1822 RVA: 0x00099DBC File Offset: 0x00097FBC
	public void setAngle()
	{
		this.Dir = 0;
		bool flag = this.x < this.toX;
		if (flag)
		{
			this.Dir = 2;
		}
	}

	// Token: 0x04000A9E RID: 2718
	public const sbyte EFFECT_SKILL = 0;

	// Token: 0x04000A9F RID: 2719
	public const sbyte EFFECT_NUM = 1;

	// Token: 0x04000AA0 RID: 2720
	public const sbyte EFFECT_OUT = 2;

	// Token: 0x04000AA1 RID: 2721
	public int typeEffect;

	// Token: 0x04000AA2 RID: 2722
	public int valueEffect;

	// Token: 0x04000AA3 RID: 2723
	public int fRemove;

	// Token: 0x04000AA4 RID: 2724
	public int x;

	// Token: 0x04000AA5 RID: 2725
	public int y;

	// Token: 0x04000AA6 RID: 2726
	public int toX;

	// Token: 0x04000AA7 RID: 2727
	public int toY;

	// Token: 0x04000AA8 RID: 2728
	public int f;

	// Token: 0x04000AA9 RID: 2729
	public int frame;

	// Token: 0x04000AAA RID: 2730
	public int ysai;

	// Token: 0x04000AAB RID: 2731
	public int vMax;

	// Token: 0x04000AAC RID: 2732
	public int vx;

	// Token: 0x04000AAD RID: 2733
	public int vy;

	// Token: 0x04000AAE RID: 2734
	public int hOne;

	// Token: 0x04000AAF RID: 2735
	public int timeAddNum;

	// Token: 0x04000AB0 RID: 2736
	public int x1000;

	// Token: 0x04000AB1 RID: 2737
	public int y1000;

	// Token: 0x04000AB2 RID: 2738
	public int step;

	// Token: 0x04000AB3 RID: 2739
	public int am_duong;

	// Token: 0x04000AB4 RID: 2740
	public int CFrame;

	// Token: 0x04000AB5 RID: 2741
	public sbyte frameSuper;

	// Token: 0x04000AB6 RID: 2742
	public int xplus;

	// Token: 0x04000AB7 RID: 2743
	public int yplus;

	// Token: 0x04000AB8 RID: 2744
	public short timeEnd;

	// Token: 0x04000AB9 RID: 2745
	public sbyte Dir;

	// Token: 0x04000ABA RID: 2746
	public int levelPaint;

	// Token: 0x04000ABB RID: 2747
	public int indexEff_1;

	// Token: 0x04000ABC RID: 2748
	public long timeBegin;

	// Token: 0x04000ABD RID: 2749
	public int[] mframe;

	// Token: 0x04000ABE RID: 2750
	public bool isRemove;

	// Token: 0x04000ABF RID: 2751
	public bool isStop;

	// Token: 0x04000AC0 RID: 2752
	public bool isAddHP;

	// Token: 0x04000AC1 RID: 2753
	public FrameImage fraImgEff;

	// Token: 0x04000AC2 RID: 2754
	public FrameImage fraImgSubEff;

	// Token: 0x04000AC3 RID: 2755
	public FrameImage fraImgSub2Eff;

	// Token: 0x04000AC4 RID: 2756
	public FrameImage fraImgSub3Eff;

	// Token: 0x04000AC5 RID: 2757
	public FrameImage fraImgSub4Eff;

	// Token: 0x04000AC6 RID: 2758
	public MainObject objFireMain;

	// Token: 0x04000AC7 RID: 2759
	public MainObject objMainEff;

	// Token: 0x04000AC8 RID: 2760
	public bool isEff;

	// Token: 0x04000AC9 RID: 2761
	public sbyte numNextFrame = 1;

	// Token: 0x04000ACA RID: 2762
	public Point PointSpeed;

	// Token: 0x04000ACB RID: 2763
	public mVector vecObjsBeFire;

	// Token: 0x04000ACC RID: 2764
	public int life;

	// Token: 0x04000ACD RID: 2765
	public int goc_Arc;

	// Token: 0x04000ACE RID: 2766
	public int vx1000;

	// Token: 0x04000ACF RID: 2767
	public int vy1000;

	// Token: 0x04000AD0 RID: 2768
	public int va;

	// Token: 0x04000AD1 RID: 2769
	private int[] mImageBullet = new int[]
	{
		0,
		0,
		2,
		1,
		1,
		2,
		0,
		0,
		2,
		1,
		1,
		2,
		0,
		0,
		2,
		1,
		1,
		2,
		0,
		0,
		2,
		1,
		1,
		2
	};

	// Token: 0x04000AD2 RID: 2770
	private int[] mXoayBullet = new int[]
	{
		2,
		2,
		3,
		3,
		3,
		4,
		5,
		5,
		5,
		5,
		5,
		1,
		0,
		0,
		0,
		0,
		0,
		7,
		6,
		6,
		6,
		6,
		6,
		2
	};

	// Token: 0x04000AD3 RID: 2771
	private int[] mpaintone_Bullet = new int[]
	{
		12,
		11,
		10,
		9,
		8,
		7,
		6,
		5,
		4,
		3,
		2,
		1,
		0,
		23,
		22,
		21,
		20,
		19,
		18,
		17,
		16,
		15,
		14,
		13
	};
}
