using System;

// Token: 0x02000072 RID: 114
public class MainBuff
{
	// Token: 0x060006F3 RID: 1779 RVA: 0x00097250 File Offset: 0x00095450
	public MainBuff(short typeBuff)
	{
		this.IdBuff = typeBuff;
		this.levelPaint = 0;
		this.numNextframe = 6;
		int num = 12;
		short idBuff = this.IdBuff;
		short num2 = idBuff;
		if (num2 <= 2032)
		{
			if (num2 <= 2010)
			{
				switch (num2)
				{
				case 1002:
				{
					this.fraBuff = new FrameImage(110, 5, 5);
					bool flag = GameCanvas.isLowGraOrWP_PvP();
					if (flag)
					{
						num = 6;
					}
					for (int i = 0; i < num; i++)
					{
						Point point = new Point(CRes.random_Am_0(22), 8 + -CRes.random(18));
						point.frame = CRes.random(this.fraBuff.nFrame);
						point.x2 = point.x;
						point.y2 = point.y;
						point.vx = 0;
						point.vy = -CRes.random(2, 4);
						point.fRe = CRes.random(15, 20);
						this.vecEffBuff.addElement(point);
					}
					break;
				}
				case 1003:
					this.fraBuff = new FrameImage(90, 26, 19);
					break;
				case 1004:
				case 1005:
				case 1006:
				case 1007:
				case 1008:
				case 1009:
				case 1015:
				case 1016:
				case 1017:
				case 1018:
					break;
				case 1010:
				case 1011:
				case 1012:
				case 1013:
				case 1014:
				{
					this.fraBuff = new FrameImage(176, 3, 25, 1);
					num = 16;
					bool flag2 = GameCanvas.isLowGraOrWP_PvP();
					if (flag2)
					{
						num = 8;
					}
					this.maxsize = num;
					for (int j = 0; j < num; j++)
					{
						Point point2 = new Point();
						this.createPointNewBuff(point2);
						point2.vy = -5;
						this.vecEffBuff.addElement(point2);
					}
					break;
				}
				case 1019:
				case 1020:
				case 1021:
				case 1022:
				case 1023:
				{
					switch (typeBuff)
					{
					case 1019:
						this.color = 8890951;
						break;
					case 1020:
						this.color = 11960483;
						break;
					case 1021:
						this.color = 14784319;
						break;
					case 1022:
						this.color = 7310769;
						break;
					case 1023:
						this.color = 11807013;
						break;
					}
					num = 16;
					bool flag3 = GameCanvas.isLowGraOrWP_PvP();
					if (flag3)
					{
						num = 8;
					}
					this.maxsize = num;
					for (int k = 0; k < num; k++)
					{
						Point o = new Point
						{
							x = CRes.random_Am_0(15),
							y = 10 - CRes.random(40),
							dis = 1 + CRes.random(3),
							vy = -4
						};
						this.vecEffBuff.addElement(o);
					}
					break;
				}
				default:
					if (num2 != 2008)
					{
						if (num2 == 2010)
						{
							this.fraBuff = new FrameImage(105, 5, 5);
							this.fraBuff2 = new FrameImage(110, 5, 5);
							num = 16;
							bool flag4 = GameCanvas.isLowGraOrWP_PvP();
							if (flag4)
							{
								num = 8;
							}
							for (int l = 0; l < num; l++)
							{
								Point point3 = new Point();
								int num3 = l;
								point3.x = -16 + (num3 / 2 + 1) / 2 * 8;
								point3.y = 0;
								bool flag5 = num3 % 2 == 1;
								if (flag5)
								{
									point3.dis = 1;
									point3.y = -50;
									point3.frame = CRes.random(this.fraBuff2.nFrame);
								}
								else
								{
									point3.dis = 0;
									point3.frame = CRes.random(this.fraBuff.nFrame);
								}
								point3.x2 = point3.x;
								point3.y2 = point3.y;
								point3.vx = 0;
								bool flag6 = num3 % 2 == 1;
								if (flag6)
								{
									point3.vy = 5;
								}
								else
								{
									point3.vy = -5;
								}
								point3.fRe = 10;
								this.vecEffBuff.addElement(point3);
							}
						}
					}
					else
					{
						this.fraBuff = new FrameImage(105, 5, 5);
						num = 16;
						bool flag7 = GameCanvas.isLowGraOrWP_PvP();
						if (flag7)
						{
							num = 8;
						}
						for (int m = 0; m < num; m++)
						{
							Point point4 = new Point();
							int num4 = m;
							point4.frame = CRes.random(4);
							point4.x = -16 + (num4 % 8 + 1) / 2 * 8;
							point4.y = 0;
							bool flag8 = num4 % 2 == 1;
							if (flag8)
							{
								point4.y = -50;
							}
							point4.x2 = point4.x;
							point4.y2 = point4.y;
							point4.vx = 0;
							bool flag9 = num4 % 2 == 1;
							if (flag9)
							{
								point4.vy = 3;
							}
							else
							{
								point4.vy = -3;
							}
							point4.fRe = 20;
							bool flag10 = m >= 8;
							if (flag10)
							{
								point4.y = -25;
								point4.f = point4.fRe / 2;
							}
							this.vecEffBuff.addElement(point4);
						}
					}
					break;
				}
			}
			else if (num2 <= 2020)
			{
				if (num2 != 2017)
				{
					if (num2 - 2018 <= 2)
					{
						this.levelPaint = -1;
						this.numNextframe = 3;
						this.fraBuff = new FrameImage(203, 33, 24);
					}
				}
				else
				{
					this.numNextframe = 2;
					this.ylech = 5;
					this.fraBuff = new FrameImage(180, 32, 63);
				}
			}
			else if (num2 != 2028)
			{
				if (num2 == 2032)
				{
					this.fraBuff = new FrameImage(248, 40, 15);
					this.levelPaint = -1;
				}
			}
			else
			{
				this.fraBuff = new FrameImage(249, 42, 19);
				this.levelPaint = -1;
			}
		}
		else if (num2 <= 2053)
		{
			if (num2 != 2035)
			{
				if (num2 != 2042)
				{
					if (num2 == 2053)
					{
						this.mfraBuff = new FrameImage[]
						{
							new FrameImage(360, 32, 40),
							new FrameImage(361, 32, 40),
							new FrameImage(362, 32, 40),
							new FrameImage(363, 32, 40),
							new FrameImage(364, 32, 40),
							new FrameImage(365, 32, 40)
						};
						this.numNextframe = 2;
						this.levelPaint = -1;
						this.mPlayframe = new int[]
						{
							0,
							1,
							2,
							3,
							4,
							5
						};
					}
				}
				else
				{
					this.fraBuff = new FrameImage(250, 57, 57);
					this.numNextframe = 4;
					this.mPlayframe = new int[]
					{
						0,
						1,
						2,
						1
					};
					this.ylech = 10;
				}
			}
			else
			{
				this.fraBuff = new FrameImage(308, 43, 30);
				this.numNextframe = 2;
				this.levelPaint = -1;
			}
		}
		else if (num2 <= 2059)
		{
			if (num2 != 2054)
			{
				if (num2 == 2059)
				{
					this.fraBuff = new FrameImage(401, 46, 21);
					this.levelPaint = -1;
				}
			}
			else
			{
				this.createCharTeleport();
			}
		}
		else if (num2 != 2067)
		{
			if (num2 == 2070)
			{
				this.fraBuff = new FrameImage(424, 3);
				this.numNextframe = 3;
				this.levelPaint = -1;
			}
		}
		else
		{
			this.fraBuff = new FrameImage(425, 5);
			this.numNextframe = 3;
			this.levelPaint = -1;
		}
	}

	// Token: 0x060006F4 RID: 1780 RVA: 0x00097A80 File Offset: 0x00095C80
	private void createCharTeleport()
	{
		this.fRemove = 15;
		this.fraBuff = new FrameImage(mImage.createImage("/eff/n2.png"), 66, 15, 55, 1);
		this.fraBuff2 = new FrameImage(mImage.createImage("/eff/n3.png"), 67, 3, 25, 1);
		this.createPoint();
	}

	// Token: 0x060006F5 RID: 1781 RVA: 0x00097AD4 File Offset: 0x00095CD4
	public void createPoint()
	{
		for (int i = 0; i < 10; i++)
		{
			Point point = new Point(this.Cx + CRes.random_Am_0(20), this.Cy - CRes.random(30) + 10);
			point.vy = -2 - CRes.random(4);
			point.dis = 0;
			point.frame = CRes.random(this.fraBuff2.nFrame);
			point.fRe = CRes.random(12, 20);
			this.vecEffBuff.addElement(point);
		}
	}

	// Token: 0x060006F6 RID: 1782 RVA: 0x00097B64 File Offset: 0x00095D64
	public void setDevilBuff(short head, short body, short leg)
	{
		this.isDevil = true;
		this.head = head;
		this.body = body;
		this.leg = leg;
		mSystem.outz(string.Concat(new string[]
		{
			"head=",
			head.ToString(),
			"  body=",
			body.ToString(),
			"  leg=",
			leg.ToString()
		}));
	}

	// Token: 0x060006F7 RID: 1783 RVA: 0x00097BD8 File Offset: 0x00095DD8
	public void setObjc(MainObject obj)
	{
		bool flag = this.IdBuff == 2057;
		if (flag)
		{
			obj.addDataEff(3, this.timeBuff);
		}
	}

	// Token: 0x060006F8 RID: 1784 RVA: 0x0000A8A4 File Offset: 0x00008AA4
	public void setTimeBuff(int timebuff)
	{
		this.timeBegin = GameCanvas.timeNow;
		this.timeBuff = timebuff;
	}

	// Token: 0x060006F9 RID: 1785 RVA: 0x0000A8B9 File Offset: 0x00008AB9
	public void setData(short idIcon)
	{
		this.idIcon = idIcon;
	}

	// Token: 0x060006FA RID: 1786 RVA: 0x00097C08 File Offset: 0x00095E08
	public void setYlech(MainObject obj)
	{
		bool flag = obj != null;
		if (flag)
		{
			short idBuff = this.IdBuff;
			short num = idBuff;
			if (num != 1002)
			{
				if (num != 1003)
				{
					if (num == 2053)
					{
						this.ylech = -obj.hOne / 2 + 5;
					}
				}
				else
				{
					this.ylech = -obj.hOne / 2 + 5;
				}
			}
			else
			{
				this.ylech = 0;
			}
		}
	}

	// Token: 0x060006FB RID: 1787 RVA: 0x00097C78 File Offset: 0x00095E78
	public void paint(mGraphics g, int x, int y)
	{
		short idBuff = this.IdBuff;
		short num = idBuff;
		if (num <= 2032)
		{
			if (num <= 2010)
			{
				switch (num)
				{
				case 1002:
					break;
				case 1003:
					this.fraBuff.drawFrame(GameCanvas.gameTick / (int)this.numNextframe % this.fraBuff.nFrame, x + this.xlech, y + this.ylech, 0, 3, g);
					return;
				case 1004:
				case 1005:
				case 1006:
				case 1007:
				case 1008:
				case 1009:
				case 1015:
				case 1016:
				case 1017:
				case 1018:
					return;
				case 1010:
				case 1011:
				case 1012:
				case 1013:
				case 1014:
					for (int i = 0; i < this.vecEffBuff.size(); i++)
					{
						Point point = (Point)this.vecEffBuff.elementAt(i);
						this.fraBuff.drawFrameNew(point.frame + point.dis * 5, x + point.x, y + point.y, 0, 3, g);
					}
					return;
				case 1019:
				case 1020:
				case 1021:
				case 1022:
				case 1023:
					g.setColor(this.color);
					for (int j = 0; j < this.vecEffBuff.size(); j++)
					{
						Point point2 = (Point)this.vecEffBuff.elementAt(j);
						g.fillRect(x + point2.x, y + point2.y, point2.dis, point2.dis);
					}
					return;
				default:
					if (num != 2008)
					{
						if (num != 2010)
						{
							return;
						}
						for (int k = 0; k < this.vecEffBuff.size(); k++)
						{
							Point point3 = (Point)this.vecEffBuff.elementAt(k);
							bool flag = point3.dis == 0;
							if (flag)
							{
								this.fraBuff.drawFrame((point3.frame + point3.f) % this.fraBuff.nFrame, x + point3.x, y + point3.y, 0, 3, g);
							}
							else
							{
								this.fraBuff2.drawFrame((point3.frame + point3.f) % this.fraBuff2.nFrame, x + point3.x, y + point3.y, 0, 3, g);
							}
						}
						return;
					}
					break;
				}
				for (int l = 0; l < this.vecEffBuff.size(); l++)
				{
					Point point4 = (Point)this.vecEffBuff.elementAt(l);
					this.fraBuff.drawFrame((point4.frame + point4.f) % this.fraBuff.nFrame, x + point4.x, y + point4.y, 0, 3, g);
				}
			}
			else
			{
				switch (num)
				{
				case 2017:
				{
					int num2 = GameCanvas.gameTick / (int)this.numNextframe % (this.fraBuff.nFrame + 1);
					bool flag2 = num2 < this.fraBuff.nFrame;
					if (flag2)
					{
						this.fraBuff.drawFrame(num2, x + this.xlech, y + this.ylech, 0, 33, g);
					}
					break;
				}
				case 2018:
				{
					bool flag3 = GameCanvas.gameTick % 24 < 8;
					if (flag3)
					{
						this.fraBuff.drawFrame(GameCanvas.gameTick / (int)this.numNextframe % 2, x + this.xlech, y + this.ylech, 0, 3, g);
					}
					break;
				}
				case 2019:
				{
					bool flag4 = GameCanvas.gameTick % 24 >= 16;
					if (flag4)
					{
						this.fraBuff.drawFrame(4 + GameCanvas.gameTick / (int)this.numNextframe % 2, x + this.xlech, y + this.ylech, 0, 3, g);
					}
					break;
				}
				case 2020:
				{
					bool flag5 = GameCanvas.gameTick % 24 >= 8 && GameCanvas.gameTick % 24 < 16;
					if (flag5)
					{
						this.fraBuff.drawFrame(2 + GameCanvas.gameTick / (int)this.numNextframe % 2, x + this.xlech, y + this.ylech, 0, 3, g);
					}
					break;
				}
				default:
					if (num != 2028)
					{
						if (num == 2032)
						{
							for (int m = 0; m < this.vecEffBuff.size(); m++)
							{
								Point point5 = (Point)this.vecEffBuff.elementAt(m);
								bool flag6 = this.fraBuff.getImageFrame() != null;
								if (flag6)
								{
									g.drawRegion(this.fraBuff.getImageFrame(), 0, point5.frame * this.fraBuff.frameHeight, this.fraBuff.frameWidth, 8, 0, (float)(x + point5.x), (float)(y + point5.y - 7 + 3), 33);
								}
							}
						}
					}
					else
					{
						for (int n = 0; n < this.vecEffBuff.size(); n++)
						{
							Point point6 = (Point)this.vecEffBuff.elementAt(n);
							bool flag7 = this.fraBuff.getImageFrame() != null;
							if (flag7)
							{
								g.drawRegion(this.fraBuff.getImageFrame(), 0, point6.frame * this.fraBuff.frameHeight, this.fraBuff.frameWidth, 10, 0, (float)(x + point6.x), (float)(y + point6.y - 9 + 3), 33);
							}
						}
					}
					break;
				}
			}
		}
		else
		{
			if (num <= 2053)
			{
				if (num != 2035)
				{
					if (num == 2042)
					{
						int num3 = GameCanvas.gameTick / (int)this.numNextframe % this.mPlayframe.Length;
						this.fraBuff.drawFrame(this.mPlayframe[num3], x + this.xlech, y + this.ylech, 0, 33, g);
						return;
					}
					if (num != 2053)
					{
						return;
					}
					int num4 = GameCanvas.gameTick / (int)this.numNextframe % this.mPlayframe.Length;
					this.mfraBuff[this.mPlayframe[num4]].drawFrame(0, x + this.xlech, y + this.ylech, 0, 3, g);
					return;
				}
			}
			else if (num <= 2059)
			{
				if (num == 2054)
				{
					for (int num5 = 0; num5 < this.vecEffBuff.size(); num5++)
					{
						Point point7 = (Point)this.vecEffBuff.elementAt(num5);
						bool flag8 = point7.dis == 1;
						if (flag8)
						{
							this.fraBuff.drawFrameNew(point7.f / 2 % this.fraBuff.nFrame, point7.x, point7.y, 0, 33, g);
						}
						else
						{
							bool flag9 = point7.dis == 0;
							if (flag9)
							{
								this.fraBuff2.drawFrameNew((point7.frame + point7.f / 2) % this.fraBuff2.nFrame, point7.x, point7.y, 0, 3, g);
							}
						}
					}
					this.Cx = x;
					this.Cy = y;
					return;
				}
				if (num != 2059)
				{
					return;
				}
				for (int num6 = 0; num6 < this.vecEffBuff.size(); num6++)
				{
					Point point8 = (Point)this.vecEffBuff.elementAt(num6);
					bool flag10 = this.fraBuff.getImageFrame() != null;
					if (flag10)
					{
						g.drawRegion(this.fraBuff.getImageFrame(), 0, point8.frame * this.fraBuff.frameHeight, this.fraBuff.frameWidth, 10, 0, (float)(x + point8.x), (float)(y + point8.y - 5), 33);
					}
				}
				return;
			}
			else if (num != 2067 && num != 2070)
			{
				return;
			}
			this.fraBuff.drawFrame(GameCanvas.gameTick / (int)this.numNextframe % this.fraBuff.nFrame, x + this.xlech, y + this.ylech, 0, 3, g);
		}
	}

	// Token: 0x060006FC RID: 1788 RVA: 0x000984FC File Offset: 0x000966FC
	public void paintLastSpec(mGraphics g, int x, int y, MainObject obj)
	{
		short idBuff = this.IdBuff;
		short num = idBuff;
		if (num <= 2032)
		{
			if (num != 2028)
			{
				if (num == 2032)
				{
					for (int i = 0; i < this.vecEffBuff.size(); i++)
					{
						Point point = (Point)this.vecEffBuff.elementAt(i);
						bool flag = this.fraBuff.getImageFrame() != null;
						if (flag)
						{
							g.drawRegion(this.fraBuff.getImageFrame(), 0, point.frame * this.fraBuff.frameHeight + 8, this.fraBuff.frameWidth, 7, 0, (float)(x + point.x), (float)(y + point.y + 3), 33);
						}
					}
				}
			}
			else
			{
				for (int j = 0; j < this.vecEffBuff.size(); j++)
				{
					Point point2 = (Point)this.vecEffBuff.elementAt(j);
					bool flag2 = this.fraBuff.getImageFrame() != null;
					if (flag2)
					{
						g.drawRegion(this.fraBuff.getImageFrame(), 0, point2.frame * this.fraBuff.frameHeight + 10, this.fraBuff.frameWidth, 9, 0, (float)(x + point2.x), (float)(y + point2.y + 3), 33);
					}
				}
			}
		}
		else if (num != 2053)
		{
			if (num == 2059)
			{
				for (int k = 0; k < this.vecEffBuff.size(); k++)
				{
					Point point3 = (Point)this.vecEffBuff.elementAt(k);
					bool flag3 = this.fraBuff.getImageFrame() != null;
					if (flag3)
					{
						g.drawRegion(this.fraBuff.getImageFrame(), 0, point3.frame * this.fraBuff.frameHeight + 10, this.fraBuff.frameWidth, 11, 0, (float)(x + point3.x), (float)(y + point3.y + 5), 33);
					}
				}
			}
		}
		else
		{
			int num2 = GameCanvas.gameTick / (int)this.numNextframe % this.mPlayframe.Length;
			this.mfraBuff[this.mPlayframe[num2]].drawFrame(1, x + this.xlech, y + this.ylech, 0, 3, g);
		}
	}

	// Token: 0x060006FD RID: 1789 RVA: 0x00098780 File Offset: 0x00096980
	public void update()
	{
		short idBuff = this.IdBuff;
		short num = idBuff;
		if (num <= 2010)
		{
			if (num <= 1014)
			{
				if (num != 1002)
				{
					if (num - 1010 > 4)
					{
						goto IL_9E1;
					}
					for (int i = 0; i < this.vecEffBuff.size(); i++)
					{
						Point point = (Point)this.vecEffBuff.elementAt(i);
						point.x += point.vx;
						point.y += point.vy;
						bool flag = point.y <= -90;
						if (flag)
						{
							bool flag2 = i >= this.maxsize;
							if (flag2)
							{
								this.vecEffBuff.removeElementAt(i);
								i--;
							}
							else
							{
								this.createPointNewBuff(point);
							}
						}
					}
					goto IL_9E1;
				}
			}
			else
			{
				if (num - 1019 <= 4)
				{
					for (int j = 0; j < this.vecEffBuff.size(); j++)
					{
						Point point2 = (Point)this.vecEffBuff.elementAt(j);
						point2.x += point2.vx;
						point2.y += point2.vy;
						bool flag3 = point2.y <= -70;
						if (flag3)
						{
							bool flag4 = j >= this.maxsize;
							if (flag4)
							{
								this.vecEffBuff.removeElementAt(j);
								j--;
							}
							else
							{
								point2.x = CRes.random_Am_0(15);
								point2.y = 10 - CRes.random(40);
								point2.dis = 1 + CRes.random(3);
							}
						}
					}
					goto IL_9E1;
				}
				if (num != 2008 && num != 2010)
				{
					goto IL_9E1;
				}
			}
			for (int k = 0; k < this.vecEffBuff.size(); k++)
			{
				Point point3 = (Point)this.vecEffBuff.elementAt(k);
				point3.update();
				bool flag5 = point3.f >= point3.fRe;
				if (flag5)
				{
					point3.f = 0;
					point3.x = point3.x2;
					point3.y = point3.y2;
				}
			}
		}
		else
		{
			if (num <= 2028)
			{
				if (num == 2017)
				{
					bool flag6 = GameCanvas.gameTick / (int)this.numNextframe % (this.fraBuff.nFrame + 1) == this.fraBuff.nFrame;
					if (flag6)
					{
						bool flag7 = this.levelPaint != -1;
						if (flag7)
						{
							this.levelPaint = -1;
						}
						else
						{
							this.levelPaint = 0;
						}
					}
					goto IL_9E1;
				}
				if (num != 2028)
				{
					goto IL_9E1;
				}
			}
			else if (num != 2032)
			{
				if (num == 2054)
				{
					this.f++;
					bool flag8 = GameCanvas.gameTick % 5 == 0;
					if (flag8)
					{
						this.createPoint();
					}
					this.Cx += this.vy;
					bool flag9 = this.f == 6;
					if (flag9)
					{
						Point point4 = new Point(this.Cx, this.Cy);
						point4.vy = 0;
						point4.dis = 1;
						point4.frame = 0;
						point4.fRe = 10;
						this.vecEffBuff.addElement(point4);
					}
					bool flag10 = this.f == 8;
					if (flag10)
					{
						this.vy = -25;
					}
					for (int l = 0; l < this.vecEffBuff.size(); l++)
					{
						Point point5 = (Point)this.vecEffBuff.elementAt(l);
						point5.update();
						bool flag11 = point5.dis == 1;
						if (flag11)
						{
							point5.vy = this.vy;
						}
						bool flag12 = point5.f >= point5.fRe;
						if (flag12)
						{
							this.vecEffBuff.removeElement(point5);
							l--;
						}
					}
					bool flag13 = this.f < 10 && this.f % 3 == 2;
					if (flag13)
					{
						for (int m = 0; m < 4; m++)
						{
							Point point6 = new Point(this.Cx + CRes.random_Am_0(20), this.Cy - CRes.random(30) + 10);
							point6.vy = -2 - CRes.random(4);
							point6.dis = 0;
							point6.frame = CRes.random(this.fraBuff2.nFrame);
							point6.fRe = CRes.random(12, 20);
							this.vecEffBuff.addElement(point6);
						}
					}
					goto IL_9E1;
				}
				if (num != 2059)
				{
					goto IL_9E1;
				}
				this.f++;
				for (int n = 0; n < this.vecEffBuff.size(); n++)
				{
					Point point7 = (Point)this.vecEffBuff.elementAt(n);
					bool flag14 = point7.dis == 1;
					if (flag14)
					{
						point7.f++;
						bool flag15 = point7.f >= point7.fRe;
						if (flag15)
						{
							this.vecEffBuff.removeElement(point7);
							n--;
						}
					}
				}
				bool flag16 = this.f % 12 == 0;
				if (flag16)
				{
					Point point8 = new Point();
					point8.y = 4;
					point8.frame = 0;
					point8.dis = 1;
					point8.fRe = 8;
					this.vecEffBuff.addElement(point8);
				}
				else
				{
					bool flag17 = this.f % 12 == 2;
					if (flag17)
					{
						Point point9 = new Point();
						point9.y = 4;
						point9.frame = 0;
						point9.dis = 1;
						point9.fRe = 7;
						this.vecEffBuff.addElement(point9);
					}
					else
					{
						bool flag18 = this.f % 12 == 4;
						if (flag18)
						{
							Point point10 = new Point();
							point10.y = 4;
							point10.frame = 1;
							point10.dis = 1;
							point10.fRe = 6;
							this.vecEffBuff.addElement(point10);
						}
						else
						{
							bool flag19 = this.f % 12 == 6;
							if (flag19)
							{
								Point point11 = new Point();
								point11.y = 4;
								point11.frame = 2;
								point11.dis = 1;
								point11.fRe = 5;
								this.vecEffBuff.addElement(point11);
							}
							else
							{
								bool flag20 = this.f % 12 == 8;
								if (flag20)
								{
									Point point12 = new Point();
									point12.y = 4;
									point12.frame = 3;
									point12.dis = 1;
									point12.fRe = 4;
									this.vecEffBuff.addElement(point12);
								}
								else
								{
									bool flag21 = this.f % 12 == 10;
									if (flag21)
									{
										Point point13 = new Point();
										point13.y = 4;
										point13.frame = 3;
										point13.dis = 1;
										point13.fRe = 3;
										this.vecEffBuff.addElement(point13);
									}
								}
							}
						}
					}
				}
				goto IL_9E1;
			}
			this.f++;
			for (int num2 = 0; num2 < this.vecEffBuff.size(); num2++)
			{
				Point point14 = (Point)this.vecEffBuff.elementAt(num2);
				bool flag22 = point14.dis == 1;
				if (flag22)
				{
					point14.f++;
					bool flag23 = point14.f >= point14.fRe;
					if (flag23)
					{
						this.vecEffBuff.removeElement(point14);
						num2--;
					}
				}
			}
			bool flag24 = this.f % 12 == 0;
			if (flag24)
			{
				Point point15 = new Point();
				point15.y = 4;
				point15.frame = 0;
				point15.dis = 1;
				point15.fRe = 8;
				this.vecEffBuff.addElement(point15);
			}
			else
			{
				bool flag25 = this.f % 12 == 2;
				if (flag25)
				{
					Point point16 = new Point();
					point16.y = -2;
					point16.frame = 0;
					point16.dis = 1;
					point16.fRe = 7;
					this.vecEffBuff.addElement(point16);
				}
				else
				{
					bool flag26 = this.f % 12 == 4;
					if (flag26)
					{
						Point point17 = new Point();
						point17.y = -8;
						point17.frame = 1;
						point17.dis = 1;
						point17.fRe = 6;
						this.vecEffBuff.addElement(point17);
					}
					else
					{
						bool flag27 = this.f % 12 == 6;
						if (flag27)
						{
							Point point18 = new Point();
							point18.y = -14;
							point18.frame = 2;
							point18.dis = 1;
							point18.fRe = 5;
							this.vecEffBuff.addElement(point18);
						}
						else
						{
							bool flag28 = this.f % 12 == 8;
							if (flag28)
							{
								Point point19 = new Point();
								point19.y = -20;
								point19.frame = 3;
								point19.dis = 1;
								point19.fRe = 4;
								this.vecEffBuff.addElement(point19);
							}
							else
							{
								bool flag29 = this.f % 12 == 10;
								if (flag29)
								{
									Point point20 = new Point();
									point20.y = -26;
									point20.frame = 3;
									point20.dis = 1;
									point20.fRe = 3;
									this.vecEffBuff.addElement(point20);
								}
							}
						}
					}
				}
			}
		}
		IL_9E1:
		bool flag30 = GameCanvas.timeNow - this.timeBegin > (long)this.timeBuff;
		if (flag30)
		{
			this.isRemove = true;
		}
	}

	// Token: 0x060006FE RID: 1790 RVA: 0x00099194 File Offset: 0x00097394
	public Point createPointNewBuff(Point p)
	{
		p.frame = CRes.random(5);
		p.x = CRes.random_Am_0(15);
		p.y = 10 - CRes.random(40);
		bool flag = this.IdBuff == 1010;
		if (flag)
		{
			p.dis = 0;
		}
		else
		{
			bool flag2 = this.IdBuff == 1011;
			if (flag2)
			{
				p.dis = 1;
			}
			else
			{
				bool flag3 = this.IdBuff == 1012;
				if (flag3)
				{
					p.dis = 3;
				}
				else
				{
					bool flag4 = this.IdBuff == 1013;
					if (flag4)
					{
						p.dis = 2;
					}
					else
					{
						bool flag5 = this.IdBuff == 1014;
						if (flag5)
						{
							p.dis = 4;
						}
					}
				}
			}
		}
		return p;
	}

	// Token: 0x060006FF RID: 1791 RVA: 0x000090B5 File Offset: 0x000072B5
	public void paintHotKey(mGraphics g)
	{
	}

	// Token: 0x04000A39 RID: 2617
	public const short BUFF_0 = 1003;

	// Token: 0x04000A3A RID: 2618
	public const short BUFF_1 = 1002;

	// Token: 0x04000A3B RID: 2619
	public const short BUFF_2 = 1004;

	// Token: 0x04000A3C RID: 2620
	public const short BUFF_CAUSU = 2008;

	// Token: 0x04000A3D RID: 2621
	public const short BUFF_TUAN_LOC = 2010;

	// Token: 0x04000A3E RID: 2622
	public const short BUFF_NEW_LUFFY = 1010;

	// Token: 0x04000A3F RID: 2623
	public const short BUFF_NEW_ZORO = 1011;

	// Token: 0x04000A40 RID: 2624
	public const short BUFF_NEW_SANJI = 1012;

	// Token: 0x04000A41 RID: 2625
	public const short BUFF_NEW_NAMI = 1013;

	// Token: 0x04000A42 RID: 2626
	public const short BUFF_NEW_USSOP = 1014;

	// Token: 0x04000A43 RID: 2627
	public const short BUFF_DALTON = 2017;

	// Token: 0x04000A44 RID: 2628
	public const short BUFF_GLODEN_WEEK_DAM = 2018;

	// Token: 0x04000A45 RID: 2629
	public const short BUFF_GLODEN_WEEK_COMBO = 2020;

	// Token: 0x04000A46 RID: 2630
	public const short BUFF_GLODEN_WEEK_DEF = 2019;

	// Token: 0x04000A47 RID: 2631
	public const short BUFF_ICE = 2032;

	// Token: 0x04000A48 RID: 2632
	public const short BUFF_LAVA = 2028;

	// Token: 0x04000A49 RID: 2633
	public const short BUFF_LAVA_2 = 2042;

	// Token: 0x04000A4A RID: 2634
	public const short BUFF_COMBO_SKILL_GEAR_1 = 1019;

	// Token: 0x04000A4B RID: 2635
	public const short BUFF_COMBO_SKILL_GEAR_2 = 1020;

	// Token: 0x04000A4C RID: 2636
	public const short BUFF_COMBO_SKILL_GEAR_3 = 1021;

	// Token: 0x04000A4D RID: 2637
	public const short BUFF_COMBO_SKILL_GEAR_4 = 1022;

	// Token: 0x04000A4E RID: 2638
	public const short BUFF_COMBO_SKILL_GEAR_5 = 1023;

	// Token: 0x04000A4F RID: 2639
	public const short BUFF_PELL = 2037;

	// Token: 0x04000A50 RID: 2640
	public const short BUFF_LOL_KILL_BOSS = 2035;

	// Token: 0x04000A51 RID: 2641
	public const short BUFF_LUCCI = 2040;

	// Token: 0x04000A52 RID: 2642
	public const short BUFF_KILO = 2053;

	// Token: 0x04000A53 RID: 2643
	public const short BUFF_SOI = 2061;

	// Token: 0x04000A54 RID: 2644
	public const short BUFF_HUOU = 2064;

	// Token: 0x04000A55 RID: 2645
	public const short BUFF_XAPHONG = 2067;

	// Token: 0x04000A56 RID: 2646
	public const short BUFF_DOOR = 2070;

	// Token: 0x04000A57 RID: 2647
	public const short BUFF_FASHION_RAU_DEN = 2054;

	// Token: 0x04000A58 RID: 2648
	public const short BUFF_FASHION_RAU_DEN_2 = 2057;

	// Token: 0x04000A59 RID: 2649
	public const short BUFF_FASHION_INCREASE_DAMAGE = 2059;

	// Token: 0x04000A5A RID: 2650
	public short IdBuff;

	// Token: 0x04000A5B RID: 2651
	public short idIcon;

	// Token: 0x04000A5C RID: 2652
	public sbyte levelPaint;

	// Token: 0x04000A5D RID: 2653
	public int timeBuff;

	// Token: 0x04000A5E RID: 2654
	public int xlech;

	// Token: 0x04000A5F RID: 2655
	public int ylech;

	// Token: 0x04000A60 RID: 2656
	public int color;

	// Token: 0x04000A61 RID: 2657
	public int f;

	// Token: 0x04000A62 RID: 2658
	public int maxsize;

	// Token: 0x04000A63 RID: 2659
	private long timeBegin;

	// Token: 0x04000A64 RID: 2660
	private sbyte numNextframe = 1;

	// Token: 0x04000A65 RID: 2661
	private FrameImage fraBuff;

	// Token: 0x04000A66 RID: 2662
	private FrameImage fraBuff2;

	// Token: 0x04000A67 RID: 2663
	private FrameImage[] mfraBuff;

	// Token: 0x04000A68 RID: 2664
	public bool isRemove;

	// Token: 0x04000A69 RID: 2665
	public bool isDevil;

	// Token: 0x04000A6A RID: 2666
	public mVector vecInfoAtt = new mVector("MainBuff.vecInfoAtt");

	// Token: 0x04000A6B RID: 2667
	public mVector vecEffBuff = new mVector("MainBuff.vecEffBuff");

	// Token: 0x04000A6C RID: 2668
	public short head;

	// Token: 0x04000A6D RID: 2669
	public short body;

	// Token: 0x04000A6E RID: 2670
	public short leg;

	// Token: 0x04000A6F RID: 2671
	public short hair = -1;

	// Token: 0x04000A70 RID: 2672
	public int[] mPlayframe;

	// Token: 0x04000A71 RID: 2673
	private int fRemove;

	// Token: 0x04000A72 RID: 2674
	private int Cx;

	// Token: 0x04000A73 RID: 2675
	private int Cy;

	// Token: 0x04000A74 RID: 2676
	private int vy;
}
