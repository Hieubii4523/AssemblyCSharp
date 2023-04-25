using System;

// Token: 0x0200008C RID: 140
public class MapBackGround
{
	// Token: 0x060008CA RID: 2250 RVA: 0x000AF664 File Offset: 0x000AD864
	public void setBackGround(sbyte type, short h)
	{
		this.mVecThunder.removeAllElements();
		this.mVecKhangia.removeAllElements();
		this.isEffKhangia = false;
		this.laboon = null;
		this.typeMap = type;
		bool flag = type == 35;
		if (flag)
		{
			this.hBack = (int)(700 - h);
		}
		else
		{
			this.hBack = GameCanvas.loadmap.maxHMap - (int)h;
		}
		this.yeff = 0;
		this.isNight = false;
		this.mImgCloudNight = null;
		bool flag2 = (GameCanvas.isLowGraOrWP_PvP() || GameCanvas.isOffBg) && this.checkDonotLow();
		if (flag2)
		{
			bool flag3 = h > 280;
			if (flag3)
			{
				h = 280;
				this.hBack = GameCanvas.loadmap.maxHMap - (int)h;
			}
			this.color = 9356287;
			this.colorMini = 4367095;
			bool flag4 = LoadMap.idTile == 11 || LoadMap.idTile == 14;
			if (flag4)
			{
				this.color = 15923962;
				this.colorMini = 15923962;
			}
			else
			{
				this.mHImg = new int[1];
				this.mHImg[0] = 96;
				this.mWImg = new int[this.mHImg.Length];
				this.mWImg[0] = 96;
				this.mSpeedImg = new int[this.mHImg.Length];
				this.mSpeedImg[0] = 8;
				this.mImg = new mImage[this.mHImg.Length];
				bool flag5 = this.typeMap == 18;
				if (flag5)
				{
					this.mImg[0] = mImage.createImage("/bg/login3.png");
					this.color = 6192006;
					this.colorMini = 2453679;
					this.isNight = true;
				}
				else
				{
					bool flag6 = this.typeMap == 20 || this.typeMap == 21 || this.typeMap == 41;
					if (flag6)
					{
						this.mImg[0] = mImage.createImage("/bg/b121.png");
						this.color = 14018038;
						this.colorMini = 14018038;
						this.mWImg[0] = 124;
						bool flag7 = this.typeMap == 21;
						if (flag7)
						{
							this.mHImg[0] = 45;
						}
						else
						{
							this.mHImg[0] = 55;
						}
						this.mSpeedImg[0] = 1;
					}
					else
					{
						this.mImg[0] = mImage.createImage("/bg/login1.png");
					}
				}
				this.mHBegin = new int[this.mHImg.Length];
				int num = 0;
				num += this.mHImg[0];
				this.mHBegin[0] = this.hBack - num;
			}
		}
		else
		{
			bool flag8 = this.lastMap != this.typeMap;
			if (flag8)
			{
				this.yplusCloud = 0;
				switch (this.typeMap)
				{
				case 0:
				{
					this.hLimit = 100;
					this.imgSky = mImage.createImage("/bg/sky0.png");
					this.hSky = 75;
					this.color = 10343167;
					this.colorMini = 43488;
					this.mHImg = new int[3];
					this.mHImg[0] = 70;
					this.mHImg[1] = -14;
					this.mHImg[2] = 55;
					this.mWImg = new int[this.mHImg.Length];
					this.mWImg[0] = 264;
					this.mWImg[1] = 264;
					this.mWImg[2] = 96;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 4;
					this.mSpeedImg[1] = 6;
					this.mSpeedImg[2] = 20;
					this.mImg = new mImage[this.mHImg.Length];
					for (int i = 0; i < this.mImg.Length; i++)
					{
						bool flag9 = i == 2;
						if (flag9)
						{
							this.mImg[i] = mImage.createImage("/bg/login1.png");
						}
						else
						{
							this.mImg[i] = mImage.createImage("/bg/b" + this.typeMap.ToString() + i.ToString() + ".png");
						}
					}
					bool flag10 = MapBackGround.fraChong == null || MapBackGround.fraChongNho == null;
					if (flag10)
					{
						MapBackGround.fraChong = new FrameImage(mImage.createImage("/bg/chong.png"), 50, 50);
						MapBackGround.fraChongNho = new FrameImage(mImage.createImage("/bg/chongnho.png"), 24, 24);
					}
					this.imgSeaLogin = new mImage[1];
					this.imgSeaLogin[0] = mImage.createImage("/bg/sea0.png");
					goto IL_3644;
				}
				case 1:
				case 16:
				case 35:
				{
					this.hLimit = 74;
					bool flag11 = type == 35;
					if (flag11)
					{
						this.imgSky = mImage.createImage("/bg/sky4.png");
						this.color = 4616312;
					}
					else
					{
						this.imgSky = mImage.createImage("/bg/sky0.png");
						this.color = 10343167;
					}
					this.hSky = 105;
					this.colorMini = 43488;
					this.mHImg = new int[2];
					this.mHImg[0] = 24;
					this.mHImg[1] = 72;
					this.mWImg = new int[this.mHImg.Length];
					this.mWImg[0] = 96;
					this.mWImg[1] = 96;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 2;
					this.mSpeedImg[1] = 4;
					this.mImg = new mImage[this.mHImg.Length];
					this.mImg[0] = mImage.createImage("/bg/b03.png");
					this.mImg[1] = mImage.createImage("/bg/login1.png");
					this.yplusCloud = -15;
					goto IL_3644;
				}
				case 2:
				case 45:
					this.hLimit = 80;
					this.imgSky = mImage.createImage("/bg/sky1.png");
					this.hSky = 55;
					this.color = 8309991;
					this.colorMini = 4367095;
					this.mHImg = new int[2];
					this.mHImg[0] = 72;
					this.mHImg[1] = -5;
					this.mWImg = new int[this.mHImg.Length];
					this.mWImg[0] = 219;
					this.mWImg[1] = 209;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 4;
					this.mSpeedImg[1] = 12;
					this.mImg = new mImage[4];
					for (int j = 0; j < 4; j++)
					{
						this.mImg[j] = mImage.createImage("/bg/b" + 2.ToString() + j.ToString() + ".png");
					}
					goto IL_3644;
				case 3:
					this.hLimit = 85;
					this.imgSky = mImage.createImage("/bg/sky1.png");
					this.hSky = 75;
					this.color = 8309991;
					this.colorMini = 7256539;
					this.mHImg = new int[3];
					this.mHImg[0] = 64;
					this.mHImg[1] = -23;
					this.mHImg[2] = 40;
					this.mWImg = new int[this.mHImg.Length];
					this.mWImg[0] = 234;
					this.mWImg[1] = 32;
					this.mWImg[2] = 209;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 4;
					this.mSpeedImg[1] = 8;
					this.mSpeedImg[2] = 20;
					this.mImg = new mImage[3];
					this.mImg[0] = mImage.createImage("/bg/b10.png");
					this.mImg[1] = mImage.createImage("/bg/b11.png");
					this.mImg[2] = mImage.createImage("/bg/b21.png");
					goto IL_3644;
				case 4:
					this.hLimit = 80;
					this.imgSky = mImage.createImage("/bg/sky1.png");
					this.hSky = 75;
					this.color = 8309991;
					this.colorMini = 4367095;
					this.mHImg = new int[2];
					this.mHImg[0] = 72;
					this.mHImg[1] = -5;
					this.mWImg = new int[this.mHImg.Length];
					this.mWImg[0] = 219;
					this.mWImg[1] = 209;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 4;
					this.mSpeedImg[1] = 12;
					this.mImg = new mImage[3];
					for (int k = 0; k < 3; k++)
					{
						this.mImg[k] = mImage.createImage("/bg/b" + 2.ToString() + k.ToString() + ".png");
					}
					goto IL_3644;
				case 5:
					this.hLimit = 70;
					this.imgSky = mImage.createImage("/bg/sky1.png");
					this.hSky = 55;
					this.color = 8309991;
					this.colorMini = 7256539;
					this.mHImg = new int[2];
					this.mHImg[0] = 60;
					this.mHImg[1] = 10;
					this.mWImg = new int[this.mHImg.Length];
					this.mWImg[0] = 237;
					this.mWImg[1] = 209;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 6;
					this.mSpeedImg[1] = 20;
					this.mImg = new mImage[this.mHImg.Length];
					this.mImg[0] = mImage.createImage("/bg/b50.png");
					this.mImg[1] = mImage.createImage("/bg/b21.png");
					goto IL_3644;
				case 6:
					this.hLimit = 96;
					this.imgSky = mImage.createImage("/bg/sky0.png");
					this.hSky = 35;
					this.color = 10343167;
					this.colorMini = 9356287;
					this.mHImg = new int[1];
					this.mHImg[0] = 96;
					this.mWImg = new int[this.mHImg.Length];
					this.mWImg[0] = 96;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 20;
					this.mImg = new mImage[this.mHImg.Length];
					this.mImg[0] = mImage.createImage("/bg/login1.png");
					goto IL_3644;
				case 7:
				case 26:
				case 47:
				{
					this.hLimit = 35;
					this.hSky = 80;
					this.color = 7920877;
					this.colorMini = 7984639;
					bool flag12 = this.typeMap == 26;
					if (flag12)
					{
						this.color = 2639445;
						this.colorMini = 2639445;
					}
					else
					{
						this.imgSky = mImage.createImage("/bg/sky2.png");
					}
					this.mHImg = new int[1];
					this.mHImg[0] = 35;
					this.mWImg = new int[this.mHImg.Length];
					this.mWImg[0] = 168;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 16;
					bool flag13 = this.typeMap == 47;
					if (flag13)
					{
						this.mImg = new mImage[3];
						this.mImg[0] = mImage.createImage("/bg/b40.png");
						this.mImg[1] = mImage.createImage("/bg/b40_n.png");
						this.mImg[2] = mImage.createImage("/bg/b23.png");
					}
					else
					{
						this.mImg = new mImage[2];
						this.mImg[0] = mImage.createImage("/bg/b40.png");
						this.mImg[1] = mImage.createImage("/bg/b40_n.png");
					}
					this.yplusCloud = -40;
					goto IL_3644;
				}
				case 8:
					this.hLimit = 96;
					this.imgSky = mImage.createImage("/bg/sky0.png");
					this.hSky = 35;
					this.color = 10343167;
					this.colorMini = 4367095;
					this.mHImg = new int[1];
					this.mHImg[0] = 96;
					this.mWImg = new int[this.mHImg.Length];
					this.mWImg[0] = 96;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 20;
					this.mImg = new mImage[4];
					this.mImg[0] = mImage.createImage("/bg/login1.png");
					this.mImg[3] = mImage.createImage("/bg/b23.png");
					this.valueTick = CRes.random(5, 10);
					this.valueEndTurn = CRes.random(12, 21) * 10;
					goto IL_3644;
				case 9:
					this.hLimit = 96;
					this.imgSky = mImage.createImage("/bg/sky0.png");
					this.hSky = 105;
					this.color = 10343167;
					this.colorMini = 429994;
					this.mHImg = new int[3];
					this.mHImg[0] = 24;
					this.mHImg[1] = 24;
					this.mHImg[2] = 48;
					this.mWImg = new int[this.mHImg.Length];
					this.mWImg[0] = 96;
					this.mWImg[1] = 24;
					this.mWImg[2] = 96;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 6;
					this.mSpeedImg[1] = 12;
					this.mSpeedImg[2] = 12;
					this.mImg = new mImage[3];
					this.mImg[2] = mImage.createImage("/bg/login1.png");
					this.mImg[1] = mImage.createImage("/bg/sea0.png");
					this.mImg[0] = mImage.createImage("/bg/b03.png");
					goto IL_3644;
				case 10:
					this.hLimit = 74;
					this.color = 9356287;
					this.colorMini = 43488;
					this.mHImg = new int[2];
					this.mHImg[0] = 24;
					this.mHImg[1] = 72;
					this.mWImg = new int[this.mHImg.Length];
					this.mWImg[0] = 96;
					this.mWImg[1] = 96;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 4;
					this.mSpeedImg[1] = 12;
					this.mImg = new mImage[this.mHImg.Length];
					this.mImg[0] = mImage.createImage("/bg/b03.png");
					this.mImg[1] = mImage.createImage("/bg/login1.png");
					goto IL_3644;
				case 11:
				case 27:
				{
					this.hLimit = 107;
					this.hSky = 45;
					this.color = 9029626;
					this.colorMini = 43488;
					bool flag14 = this.typeMap == 27;
					if (flag14)
					{
						this.color = 3557982;
					}
					else
					{
						this.imgSky = mImage.createImage("/bg/sky3.png");
					}
					this.mHImg = new int[1];
					this.mHImg[0] = 107;
					this.mWImg = new int[this.mHImg.Length];
					this.mWImg[0] = 240;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 4;
					this.mImg = new mImage[2];
					this.mImg[0] = mImage.createImage("/bg/b60.png");
					this.mImg[1] = mImage.createImage("/bg/b60_n.png");
					this.yplusCloud = -20;
					goto IL_3644;
				}
				case 12:
				case 13:
				case 14:
				case 24:
				case 25:
				{
					this.hLimit = 74;
					this.imgSky = mImage.createImage("/bg/sky0.png");
					this.hSky = 105;
					this.color = 10343167;
					this.colorMini = 43488;
					this.mHImg = new int[2];
					this.mHImg[0] = 24;
					this.mHImg[1] = 72;
					this.mWImg = new int[this.mHImg.Length];
					this.mWImg[0] = 96;
					this.mWImg[1] = 96;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 4;
					this.mSpeedImg[1] = 12;
					bool flag15 = this.typeMap == 12;
					if (flag15)
					{
						this.mImg = new mImage[4];
						this.mImg[0] = mImage.createImage("/bg/b03.png");
						this.mImg[1] = mImage.createImage("/bg/login1.png");
						this.mImg[2] = mImage.createImage("/bg/nui1.png");
						this.mImg[3] = mImage.createImage("/bg/nui2.png");
						this.PosObj = this.PosObj12;
					}
					else
					{
						bool flag16 = this.typeMap == 13;
						if (flag16)
						{
							this.mImg = new mImage[4];
							this.mImg[0] = mImage.createImage("/bg/b03.png");
							this.mImg[1] = mImage.createImage("/bg/login1.png");
							this.mImg[2] = mImage.createImage("/bg/boatnear.png");
							this.mImg[3] = mImage.createImage("/bg/boatfar.png");
							this.PosObj = this.PosObj13;
							bool flag17 = GameCanvas.loadmap.idMap == 191 && MapBackGround.fraWater7 == null;
							if (flag17)
							{
								MapBackGround.fraWater7 = new FrameImage(mImage.createImage("/bg/water7.png"), 3);
							}
						}
						else
						{
							bool flag18 = this.typeMap == 14;
							if (flag18)
							{
								this.mImg = new mImage[6];
								this.mImg[0] = mImage.createImage("/bg/b03.png");
								this.mImg[1] = mImage.createImage("/bg/login1.png");
								this.mImg[2] = mImage.createImage("/bg/nui1.png");
								this.mImg[3] = mImage.createImage("/bg/nui2.png");
								this.mImg[4] = mImage.createImage("/bg/boatnear.png");
								this.mImg[5] = mImage.createImage("/bg/boatfar.png");
								this.PosObj = this.PosObj14;
							}
							else
							{
								bool flag19 = this.typeMap == 24;
								if (flag19)
								{
									this.mImg = new mImage[6];
									this.mImg[0] = mImage.createImage("/bg/b03.png");
									this.mImg[1] = mImage.createImage("/bg/login1.png");
									this.mImg[2] = mImage.createImage("/bg/nui3.png");
									this.mImg[3] = mImage.createImage("/bg/nui4.png");
									this.mImg[4] = mImage.createImage("/bg/boatnear.png");
									this.mImg[5] = mImage.createImage("/bg/boatfar.png");
									this.PosObj = this.PosObj14;
								}
								else
								{
									bool flag20 = this.typeMap == 25;
									if (flag20)
									{
										this.mImg = new mImage[6];
										this.mImg[0] = mImage.createImage("/bg/b03.png");
										this.mImg[1] = mImage.createImage("/bg/login1.png");
										this.mImg[2] = mImage.createImage("/bg/nui5.png");
										this.mImg[3] = mImage.createImage("/bg/nui6.png");
										this.mImg[4] = mImage.createImage("/bg/boatnear.png");
										this.mImg[5] = mImage.createImage("/bg/boatfar.png");
										this.PosObj = this.PosObj14;
									}
								}
							}
						}
					}
					goto IL_3644;
				}
				case 15:
				case 41:
				case 60:
				case 61:
				{
					this.hLimit = 80;
					this.imgSky = mImage.createImage("/bg/sky6.png");
					this.hSky = 80;
					this.color = 7920877;
					this.colorMini = 429994;
					this.mHImg = new int[2];
					this.mHImg[1] = 30;
					this.mHImg[0] = 57;
					this.mWImg = new int[this.mHImg.Length];
					this.mWImg[1] = 209;
					this.mWImg[0] = 125;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[1] = 12;
					this.mSpeedImg[0] = 1;
					this.mImg = new mImage[3];
					bool flag21 = this.typeMap == 41 || this.typeMap == 61;
					if (flag21)
					{
						this.mImgCloud = null;
						this.color = 10668525;
						this.mImg[2] = mImage.createImage("/bg/b74.png");
						this.mImg[0] = mImage.createImage("/bg/b73.png");
					}
					else
					{
						this.mImg[2] = mImage.createImage("/bg/b71.png");
						this.mImg[1] = mImage.createImage("/bg/b21.png");
						this.mImg[0] = mImage.createImage("/bg/b70.png");
					}
					bool flag22 = this.typeMap == 60 || this.typeMap == 61;
					if (flag22)
					{
						goto IL_3644;
					}
					int num2 = 0;
					bool flag23 = MotherCanvas.w >= 480;
					if (flag23)
					{
						num2 = 34;
					}
					else
					{
						bool flag24 = MotherCanvas.w >= 320;
						if (flag24)
						{
							num2 = 24;
						}
					}
					for (int l = 0; l <= GameCanvas.loadmap.maxWMap / this.mWImg[0] + 1; l++)
					{
						int num3 = CRes.random(this.posKhanGia.Length);
						for (int m = 0; m < this.posKhanGia[num3].Length; m++)
						{
							Point_Focus point_Focus = new Point_Focus(GameCanvas.loadmap.maxWMap / 125 * 125 - l * this.mWImg[0] + (int)this.posKhanGia[num3][m][0] + GameCanvas.loadmap.limitW % 125 + num2, this.hBack - (int)this.posKhanGia[num3][m][1]);
							point_Focus.dis = CRes.random(6) * 2;
							this.mVecKhangia.addElement(point_Focus);
						}
					}
					goto IL_3644;
				}
				case 17:
					this.hLimit = 110;
					this.imgSky = mImage.createImage("/bg/sky0.png");
					this.hSky = 80;
					this.color = 10343167;
					this.colorMini = 9356287;
					this.mHImg = new int[1];
					this.mHImg[0] = 62;
					this.mWImg = new int[this.mHImg.Length];
					this.mWImg[0] = 48;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 1;
					this.fraImgNew = new FrameImage(144, 37, 55);
					this.mImg = new mImage[8];
					for (int n = 0; n < this.mImg.Length; n++)
					{
						int num4 = n;
						int num5 = num4;
						if (num5 != 6)
						{
							if (num5 != 7)
							{
								this.mImg[n] = mImage.createImage("/bg/b8" + n.ToString() + ".png");
							}
						}
						else
						{
							this.mImg[n] = mImage.createImage("/bg/boateff.png");
						}
					}
					this.laboon = new Point(140, 0);
					goto IL_3644;
				case 18:
				{
					this.isNight = true;
					this.mImgCloud = null;
					this.hLimit = 150;
					this.imgSky = mImage.createImage("/bg/sky4.png");
					this.hSky = 70;
					this.color = 4616312;
					this.colorMini = 4943991;
					this.mHImg = new int[2];
					this.mHImg[0] = 63;
					this.mHImg[1] = -12;
					this.mWImg = new int[this.mHImg.Length];
					this.mWImg[0] = 247;
					this.mWImg[1] = 91;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 1;
					this.mSpeedImg[1] = 2;
					this.mImg = new mImage[6];
					for (int num6 = 0; num6 < this.mImg.Length; num6++)
					{
						this.mImg[num6] = mImage.createImage("/bg/b9" + num6.ToString() + ".png");
					}
					int num7 = (GameCanvas.loadmap.maxWMap + 30) / 190 + 1;
					bool flag25 = num7 < 2;
					if (flag25)
					{
						num7 = 2;
					}
					this.posXuongRong = new Point[num7];
					for (int num8 = 0; num8 < this.posXuongRong.Length; num8++)
					{
						Point point = new Point(-30 + num8 * 190, 0);
						point.frame = (num8 + GameCanvas.loadmap.idMap) % 2;
						bool flag26 = (num8 + GameCanvas.loadmap.idMap) % 4 == 1;
						if (flag26)
						{
							point.isSmall = true;
						}
						this.posXuongRong[num8] = point;
					}
					num7 = (GameCanvas.loadmap.maxWMap - 90) / 190 + 1;
					bool flag27 = num7 < 2;
					if (flag27)
					{
						num7 = 2;
					}
					this.posXuongRong2 = new Point[num7];
					for (int num9 = 0; num9 < this.posXuongRong2.Length; num9++)
					{
						Point point2 = new Point(90 + num9 * 190, 0);
						bool flag28 = (num9 + GameCanvas.loadmap.idMap) % 4 == 3;
						if (flag28)
						{
							point2.isSmall = true;
						}
						this.posXuongRong2[num9] = point2;
					}
					goto IL_3644;
				}
				case 19:
					this.hLimit = 95;
					this.imgSky = mImage.createImage("/bg/sky5.png");
					this.hSky = 55;
					this.color = 8707577;
					this.colorMini = 7984639;
					this.mHImg = new int[2];
					this.mHImg[0] = 52;
					this.mHImg[1] = -12;
					this.mWImg = new int[this.mHImg.Length];
					this.mWImg[0] = 168;
					this.mWImg[1] = 168;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 8;
					this.mSpeedImg[1] = 24;
					this.mImg = new mImage[4];
					for (int num10 = 0; num10 < this.mImg.Length; num10++)
					{
						this.mImg[num10] = mImage.createImage("/bg/b10" + num10.ToString() + ".png");
					}
					goto IL_3644;
				case 20:
					this.hLimit = 120;
					this.imgSky = mImage.createImage("/bg/sky6.png");
					this.hSky = 50;
					this.color = 10668525;
					this.colorMini = 13819368;
					this.mHImg = new int[1];
					this.mHImg[0] = 135;
					this.mWImg = new int[this.mHImg.Length];
					this.mWImg[0] = 143;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 12;
					this.mImg = new mImage[5];
					for (int num11 = 0; num11 < this.mImg.Length; num11++)
					{
						this.mImg[num11] = mImage.createImage("/bg/b11" + num11.ToString() + ".png");
					}
					this.PosObj = this.PosObj15;
					this.PosObj2 = this.PosObj16;
					this.imgSpec = mImage.createImage("/bg/b121.png");
					this.yplusCloud = -20;
					goto IL_3644;
				case 21:
					this.hLimit = 120;
					this.imgSky = mImage.createImage("/bg/sky6.png");
					this.hSky = 110;
					this.color = 10668525;
					this.colorMini = 14018038;
					this.mHImg = new int[2];
					this.mHImg[0] = 43;
					this.mHImg[1] = 40;
					this.mWImg = new int[this.mHImg.Length];
					this.mWImg[0] = 124;
					this.mWImg[1] = 124;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 1;
					this.mSpeedImg[1] = 8;
					this.mImg = new mImage[2];
					for (int num12 = 0; num12 < this.mImg.Length; num12++)
					{
						this.mImg[num12] = mImage.createImage("/bg/b12" + num12.ToString() + ".png");
					}
					this.yplusCloud = -20;
					goto IL_3644;
				case 22:
				{
					this.hLimit = 120;
					bool flag29 = !GameCanvas.isLowGraOrWP_PvP() && !GameCanvas.isOffBg;
					if (flag29)
					{
						this.imgSky = mImage.createImage("/bg/sky6.png");
					}
					this.hSky = 65;
					this.color = 10668525;
					bool flag30 = GameCanvas.isLowGraOrWP_PvP() || GameCanvas.isOffBg;
					if (flag30)
					{
						this.color = 13819368;
					}
					this.colorMini = 13819368;
					this.mHImg = new int[1];
					this.mHImg[0] = 135;
					this.mWImg = new int[this.mHImg.Length];
					this.mWImg[0] = 143;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 12;
					this.mImg = new mImage[6];
					for (int num13 = 0; num13 < this.mImg.Length; num13++)
					{
						this.mImg[num13] = mImage.createImage("/bg/b11" + num13.ToString() + ".png");
					}
					this.PosObj = this.PosObj15;
					this.PosObj2 = this.PosObj16;
					this.imgSpec = mImage.createImage("/bg/b121.png");
					this.yplusCloud = -20;
					goto IL_3644;
				}
				case 23:
				{
					this.hLimit = 95;
					bool flag31 = !GameCanvas.lowGraphic && !GameCanvas.isOffBg;
					if (flag31)
					{
						this.imgSky = mImage.createImage("/bg/sky5.png");
					}
					this.hSky = 55;
					this.color = 8707577;
					this.colorMini = 7984639;
					this.mHImg = new int[2];
					this.mHImg[0] = 52;
					this.mHImg[1] = -12;
					this.mWImg = new int[this.mHImg.Length];
					this.mWImg[0] = 168;
					this.mWImg[1] = 168;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 8;
					this.mSpeedImg[1] = 24;
					this.mImg = new mImage[5];
					for (int num14 = 0; num14 < this.mImg.Length; num14++)
					{
						bool flag32 = num14 == 4;
						if (flag32)
						{
							this.mImg[num14] = mImage.createImage("/bg/b23.png");
						}
						else
						{
							this.mImg[num14] = mImage.createImage("/bg/b10" + num14.ToString() + ".png");
						}
					}
					goto IL_3644;
				}
				case 28:
					this.hLimit = 70;
					this.imgSky = mImage.createImage("/bg/sky7.png");
					this.hSky = 40;
					this.color = 37344;
					this.colorMini = 37344;
					this.mHImg = new int[1];
					this.mHImg[0] = 66;
					this.mWImg = new int[this.mHImg.Length];
					this.mWImg[0] = 126;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 2;
					this.mImg = new mImage[2];
					this.mImg[0] = mImage.createImage("/bg/b131.png");
					this.mImg[1] = mImage.createImage("/bg/b23.png");
					this.mImgCloud = null;
					goto IL_3644;
				case 29:
					this.hLimit = 80;
					this.imgSky = mImage.createImage("/bg/sky8.png");
					this.hSky = 70;
					this.color = 47092;
					this.colorMini = 16776621;
					this.mHImg = new int[2];
					this.mHImg[0] = 0;
					this.mHImg[1] = 20;
					this.mWImg = new int[this.mHImg.Length];
					this.mWImg[0] = 240;
					this.mWImg[1] = 190;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 2;
					this.mSpeedImg[1] = 8;
					this.mImg = new mImage[2];
					this.mImg[0] = mImage.createImage("/bg/b132.png");
					this.mImg[1] = mImage.createImage("/bg/b133.png");
					this.mImgCloud = null;
					this.yplusCloud = -20;
					goto IL_3644;
				case 30:
				case 32:
					this.hLimit = 80;
					this.imgSky = mImage.createImage("/bg/sky8.png");
					this.hSky = 70;
					this.color = 47092;
					this.colorMini = 16776621;
					this.mHImg = new int[2];
					this.mHImg[0] = 0;
					this.mHImg[1] = 20;
					this.mWImg = new int[this.mHImg.Length];
					this.mWImg[0] = 240;
					this.mWImg[1] = 190;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 4;
					this.mSpeedImg[1] = 12;
					this.mImg = new mImage[3];
					this.mImg[0] = mImage.createImage("/bg/b132.png");
					this.mImg[1] = mImage.createImage("/bg/b133.png");
					this.mImg[2] = mImage.createImage("/bg/b135.png");
					this.mImgCloud = null;
					this.yplusCloud = -20;
					goto IL_3644;
				case 31:
					this.hLimit = 70;
					this.imgSky = mImage.createImage("/bg/sky7.png");
					this.hSky = 75;
					this.color = 37344;
					this.colorMini = 16776368;
					this.mHImg = new int[2];
					this.mHImg[0] = 20;
					this.mHImg[1] = 20;
					this.mWImg = new int[this.mHImg.Length];
					this.mWImg[0] = 126;
					this.mWImg[1] = 190;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 2;
					this.mSpeedImg[1] = 8;
					this.mImg = new mImage[this.mHImg.Length];
					this.mImg[0] = mImage.createImage("/bg/b131.png");
					this.mImg[1] = mImage.createImage("/bg/b133.png");
					this.mImgCloud = null;
					goto IL_3644;
				case 33:
				{
					this.hLimit = 80;
					this.color = 12368081;
					this.colorMini = 12368081;
					bool flag33 = GameCanvas.loadmap.idMap >= 167 && GameCanvas.loadmap.idMap <= 176;
					if (flag33)
					{
						this.color = 791323;
						this.colorMini = 791323;
					}
					this.mHImg = new int[2];
					this.mHImg[0] = 20;
					this.mHImg[1] = 10;
					this.mWImg = new int[this.mHImg.Length];
					this.mWImg[0] = 82;
					this.mWImg[1] = 45;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 1;
					this.mSpeedImg[1] = 1;
					this.mImg = new mImage[2];
					this.mImg[0] = mImage.createImage("/bg/b140.png");
					this.mImg[1] = mImage.createImage("/bg/b141.png");
					this.mImgCloud = null;
					this.yplusCloud = -20;
					goto IL_3644;
				}
				case 36:
					this.hLimit = 80;
					this.imgSky = mImage.createImage("/bg/sky9.png");
					this.color = 9953276;
					this.hSky = 75;
					this.colorMini = 9953276;
					this.mHImg = new int[2];
					this.mHImg[0] = 70;
					this.mHImg[1] = -47;
					this.mWImg = new int[this.mHImg.Length];
					this.mWImg[0] = 168;
					this.mWImg[1] = 72;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 4;
					this.mSpeedImg[1] = 3;
					this.mImg = new mImage[this.mHImg.Length];
					this.mImg[0] = mImage.createImage("/bg/b151.png");
					this.mImg[1] = mImage.createImage("/bg/b150.png");
					this.yplusCloud = -5;
					goto IL_3644;
				case 37:
					this.hLimit = 80;
					this.imgSky = null;
					this.color = 15923962;
					this.hSky = 75;
					this.colorMini = 9953276;
					this.mHImg = new int[1];
					this.mHImg[0] = 70;
					this.mWImg = new int[1];
					this.mWImg[0] = 168;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 4;
					this.mImg = new mImage[7];
					for (int num15 = 0; num15 < this.mImg.Length; num15++)
					{
						bool flag34 = num15 == 6;
						if (flag34)
						{
							this.mImg[6] = mImage.createImage("/bg/b151.png");
						}
						else
						{
							this.mImg[num15] = mImage.createImage("/bg/b16" + num15.ToString() + ".png");
							this.mImg[num15].setWH();
						}
					}
					this.yplusCloud = -5;
					goto IL_3644;
				case 38:
					this.hLimit = 80;
					this.imgSky = null;
					this.color = 15923962;
					this.hSky = 75;
					this.colorMini = 9953276;
					this.mHImg = new int[1];
					this.mHImg[0] = 0;
					this.mWImg = new int[1];
					this.mWImg[0] = 168;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 2;
					this.mImg = new mImage[6];
					for (int num16 = 0; num16 < this.mImg.Length; num16++)
					{
						this.mImg[num16] = mImage.createImage("/bg/b16" + num16.ToString() + ".png");
						this.mImg[num16].setWH();
					}
					this.yplusCloud = -5;
					goto IL_3644;
				case 39:
					this.hLimit = 80;
					this.imgSky = null;
					this.color = 15923962;
					this.hSky = 75;
					this.colorMini = 9953276;
					this.mHImg = new int[1];
					this.mHImg[0] = 0;
					this.mWImg = new int[1];
					this.mWImg[0] = 168;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 4;
					this.mImg = new mImage[10];
					for (int num17 = 0; num17 < this.mImg.Length; num17++)
					{
						switch (num17)
						{
						case 6:
							this.mImg[num17] = mImage.createImage("/bg/b170.png");
							this.mImg[num17].setWH();
							break;
						case 7:
							this.mImg[num17] = mImage.createImage("/bg/b171.png");
							this.mImg[num17].setWH();
							break;
						case 8:
							this.mImg[num17] = mImage.createImage("/bg/b151.png");
							this.mImg[num17].setWH();
							break;
						case 9:
							this.mImg[num17] = mImage.createImage("/bg/b172.png");
							this.mImg[num17].setWH();
							break;
						default:
							this.mImg[num17] = mImage.createImage("/bg/b16" + num17.ToString() + ".png");
							this.mImg[num17].setWH();
							break;
						}
					}
					this.yplusCloud = -5;
					goto IL_3644;
				case 40:
				{
					this.hLimit = 96;
					this.imgSky = mImage.createImage("/bg/sky0.png");
					this.hSky = 35;
					this.color = 10343167;
					this.colorMini = 4367095;
					this.mHImg = new int[1];
					this.mHImg[0] = 96;
					this.mWImg = new int[this.mHImg.Length];
					this.mWImg[0] = 96;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 20;
					this.mImg = new mImage[3];
					this.mImg[0] = mImage.createImage("/bg/login1.png");
					this.mImg[1] = mImage.createImage("/bg/b23.png");
					this.mImg[2] = mImage.createImage("/bg/b72.png");
					this.valueTick = CRes.random(5, 10);
					this.valueEndTurn = CRes.random(12, 21) * 10;
					this.PosObj = new short[100][];
					int num18 = 0;
					for (int num19 = 0; num19 <= GameCanvas.loadmap.maxWMap / 120; num19++)
					{
						for (int num20 = 0; num20 < this.PosObj20.Length; num20++)
						{
							bool flag35 = CRes.random(5) != 0;
							if (flag35)
							{
								this.PosObj[num18] = new short[6];
								this.PosObj[num18][0] = (short)((int)this.PosObj20[num20] + CRes.random_Am_0(3) + num19 * 120);
								this.PosObj[num18][1] = (short)CRes.random(3);
								this.PosObj[num18][2] = (short)CRes.random(6);
								this.PosObj[num18][3] = 0;
								this.PosObj[num18][4] = 0;
								this.PosObj[num18][5] = 0;
								bool flag36 = (int)this.PosObj[num18][0] < GameCanvas.loadmap.maxWMap / 2;
								if (flag36)
								{
									this.PosObj[num18][5] = 2;
								}
								num18++;
							}
						}
					}
					this.PosObj[num18] = null;
					goto IL_3644;
				}
				case 42:
				{
					this.hLimit = 70;
					this.imgSky = mImage.createImage("/bg/sky7.png");
					this.hSky = 75;
					this.color = 37344;
					this.colorMini = 16776368;
					this.mHImg = new int[2];
					this.mHImg[0] = 20;
					this.mHImg[1] = 20;
					this.mWImg = new int[this.mHImg.Length];
					this.mWImg[0] = 126;
					this.mWImg[1] = 190;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 2;
					this.mSpeedImg[1] = 8;
					this.mImg = new mImage[3];
					this.mImg[0] = mImage.createImage("/bg/b131.png");
					this.mImg[1] = mImage.createImage("/bg/b133.png");
					this.mImg[2] = mImage.createImage("/bg/b72.png");
					this.mImgCloud = null;
					this.PosObj = new short[100][];
					int num21 = 0;
					for (int num22 = 0; num22 <= GameCanvas.loadmap.maxWMap / 120; num22++)
					{
						for (int num23 = 0; num23 < this.PosObj20.Length; num23++)
						{
							bool flag37 = CRes.random(5) != 0;
							if (flag37)
							{
								this.PosObj[num21] = new short[6];
								this.PosObj[num21][0] = (short)((int)this.PosObj20[num23] + CRes.random_Am_0(3) + num22 * 120);
								this.PosObj[num21][1] = (short)CRes.random(3);
								this.PosObj[num21][2] = (short)CRes.random(6);
								this.PosObj[num21][3] = 0;
								this.PosObj[num21][4] = 0;
								this.PosObj[num21][5] = 0;
								bool flag38 = (int)this.PosObj[num21][0] < GameCanvas.loadmap.maxWMap / 2;
								if (flag38)
								{
									this.PosObj[num21][5] = 2;
								}
								num21++;
							}
						}
					}
					this.PosObj[num21] = null;
					goto IL_3644;
				}
				case 43:
				case 62:
					this.hLimit = 70;
					this.imgSky = null;
					this.hSky = 75;
					this.color = 5594686;
					this.colorMini = 5594686;
					this.mHImg = new int[3];
					this.mHImg[0] = 15;
					this.mHImg[1] = 15;
					this.mHImg[2] = 15;
					this.mWImg = new int[this.mHImg.Length];
					this.mWImg[0] = 211;
					this.mWImg[1] = 211;
					this.mWImg[2] = 211;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 1;
					this.mSpeedImg[1] = 3;
					this.mSpeedImg[2] = 12;
					this.mImg = new mImage[9];
					for (int num24 = 0; num24 < this.mImg.Length; num24++)
					{
						this.mImg[num24] = mImage.createImage("/bg/b18" + num24.ToString() + ".png");
					}
					this.mImgCloud = null;
					goto IL_3644;
				case 44:
					this.hLimit = 100;
					this.imgSky = mImage.createImage("/bg/sky9.png");
					this.hSky = 130;
					this.color = 9953276;
					this.colorMini = 9953276;
					this.mHImg = new int[3];
					this.mHImg[0] = 24;
					this.mHImg[1] = 20;
					this.mHImg[2] = 40;
					this.mWImg = new int[this.mHImg.Length];
					this.mWImg[0] = 168;
					this.mWImg[1] = 212;
					this.mWImg[2] = 250;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 2;
					this.mSpeedImg[1] = 5;
					this.mSpeedImg[2] = 8;
					this.mImg = new mImage[6];
					for (int num25 = 0; num25 < this.mImg.Length; num25++)
					{
						switch (num25)
						{
						case 3:
							this.mImg[num25] = mImage.createImage("/bg/b170.png");
							this.mImg[num25].setWH();
							break;
						case 4:
							this.mImg[num25] = mImage.createImage("/bg/b171.png");
							this.mImg[num25].setWH();
							break;
						case 5:
							this.mImg[num25] = mImage.createImage("/bg/b172.png");
							this.mImg[num25].setWH();
							break;
						default:
							this.mImg[num25] = mImage.createImage("/bg/b19" + num25.ToString() + ".png");
							break;
						}
					}
					this.mImgCloud = null;
					goto IL_3644;
				case 46:
					this.hLimit = 80;
					this.imgSky = null;
					this.color = 15923962;
					this.hSky = 75;
					this.colorMini = 9953276;
					this.mHImg = new int[1];
					this.mHImg[0] = 0;
					this.mWImg = new int[1];
					this.mWImg[0] = 168;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 4;
					this.mImg = new mImage[2];
					for (int num26 = 0; num26 < this.mImg.Length; num26++)
					{
						this.mImg[num26] = mImage.createImage("/bg/b16" + (3 + num26).ToString() + ".png");
						this.mImg[num26].setWH();
					}
					goto IL_3644;
				case 51:
					this.hLimit = 74;
					this.imgSky = mImage.createImage("/bg/sky0.png");
					this.hSky = 105;
					this.color = 10343167;
					this.colorMini = 43488;
					this.mHImg = new int[2];
					this.mHImg[0] = 24;
					this.mHImg[1] = 72;
					this.mWImg = new int[this.mHImg.Length];
					this.mWImg[0] = 96;
					this.mWImg[1] = 96;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 4;
					this.mSpeedImg[1] = 12;
					this.mImg = new mImage[3];
					this.mImg[0] = mImage.createImage("/bg/b03.png");
					this.mImg[1] = mImage.createImage("/bg/login1.png");
					this.mImg[2] = mImage.createImage("/bg/b23.png");
					goto IL_3644;
				case 53:
					this.hLimit = 85;
					this.imgSky = mImage.createImage("/bg/sky1.png");
					this.hSky = 65;
					this.color = 8309991;
					this.colorMini = 7256539;
					this.mHImg = new int[3];
					this.mHImg[0] = 64;
					this.mHImg[1] = -30;
					this.mHImg[2] = 40;
					this.mWImg = new int[this.mHImg.Length];
					this.mWImg[0] = 234;
					this.mWImg[1] = 32;
					this.mWImg[2] = 209;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 4;
					this.mSpeedImg[1] = 8;
					this.mSpeedImg[2] = 20;
					this.mImg = new mImage[4];
					this.mImg[0] = mImage.createImage("/bg/b10.png");
					this.mImg[1] = mImage.createImage("/bg/b11.png");
					this.mImg[2] = mImage.createImage("/bg/b21.png");
					this.mImg[3] = mImage.createImage("/bg/b23.png");
					goto IL_3644;
				case 55:
					this.hLimit = 70;
					this.imgSky = mImage.createImage("/bg/sky1.png");
					this.hSky = 55;
					this.color = 8309991;
					this.colorMini = 7256539;
					this.mHImg = new int[2];
					this.mHImg[0] = 60;
					this.mHImg[1] = 10;
					this.mWImg = new int[this.mHImg.Length];
					this.mWImg[0] = 237;
					this.mWImg[1] = 209;
					this.mSpeedImg = new int[this.mHImg.Length];
					this.mSpeedImg[0] = 6;
					this.mSpeedImg[1] = 20;
					this.mImg = new mImage[3];
					this.mImg[0] = mImage.createImage("/bg/b50.png");
					this.mImg[1] = mImage.createImage("/bg/b21.png");
					this.mImg[2] = mImage.createImage("/bg/b23.png");
					goto IL_3644;
				case 63:
				{
					this.hLimit = 80;
					int num27 = 0;
					switch (GameCanvas.loadmap.idMap)
					{
					case 195:
						num27 = 12221098;
						break;
					case 196:
						num27 = 12693148;
						break;
					case 197:
						num27 = 15200189;
						break;
					case 198:
						num27 = 4277093;
						break;
					}
					this.color = num27;
					this.colorMini = num27;
					bool flag39 = GameCanvas.loadmap.idMap == 197;
					if (flag39)
					{
						this.mHImg = new int[2];
						this.mHImg[0] = 95;
						this.mHImg[1] = 140;
						this.mWImg = new int[this.mHImg.Length];
						this.mWImg[0] = 99;
						this.mWImg[1] = 99;
						this.mSpeedImg = new int[this.mHImg.Length];
						this.mSpeedImg[0] = 1;
						this.mSpeedImg[1] = 1;
						this.mImg = new mImage[this.mHImg.Length];
						this.mImg[0] = mImage.createImage("/bg/b" + (GameCanvas.loadmap.idMap - 2).ToString() + ".png");
						this.mImg[1] = mImage.createImage("/bg/b" + (GameCanvas.loadmap.idMap - 2).ToString() + ".png");
					}
					else
					{
						this.mHImg = new int[1];
						this.mHImg[0] = 60;
						this.mWImg = new int[this.mHImg.Length];
						this.mWImg[0] = 25;
						this.mSpeedImg = new int[this.mHImg.Length];
						this.mSpeedImg[0] = 1;
						this.mImg = new mImage[1];
						this.mImg[0] = mImage.createImage("/bg/b" + (GameCanvas.loadmap.idMap - 2).ToString() + ".png");
					}
					bool flag40 = GameCanvas.loadmap.idMap == 198;
					if (flag40)
					{
						this.mWImg[0] = 124;
					}
					this.mImgCloud = null;
					this.yplusCloud = -20;
					goto IL_3644;
				}
				}
				this.color = 9356287;
				this.colorMini = 4367095;
				this.mHImg = new int[1];
				this.mHImg[0] = 96;
				this.mWImg = new int[this.mHImg.Length];
				this.mWImg[0] = 96;
				this.mSpeedImg = new int[this.mHImg.Length];
				this.mSpeedImg[0] = 8;
				this.mImg = new mImage[this.mHImg.Length];
				this.mImg[0] = mImage.createImage("/bg/login1.png");
				this.mHBegin = new int[this.mHImg.Length];
				int num28 = 0;
				num28 += this.mHImg[0];
				this.mHBegin[0] = this.hBack - num28;
				return;
				IL_3644:;
			}
			else
			{
				bool flag41 = this.lastMap == 28 || this.lastMap == 29 || this.lastMap == 30;
				if (flag41)
				{
					bool flag42 = this.typeMap != 28 && this.typeMap != 29 && this.typeMap != 30;
					if (flag42)
					{
						this.mImgCloud = null;
					}
				}
				else
				{
					bool flag43 = this.typeMap == 28 || this.typeMap == 29 || this.typeMap == 30;
					if (flag43)
					{
						this.mImgCloud = null;
					}
				}
			}
			this.valueMyRandom = this.hBack - this.hLimit + this.yplusCloud;
			int num29 = 0;
			this.mHBegin = new int[this.mHImg.Length];
			for (int num30 = 0; num30 < this.mHImg.Length; num30++)
			{
				num29 += this.mHImg[num30];
				this.mHBegin[num30] = this.hBack - num29;
			}
			int num31 = GameCanvas.loadmap.maxWMap / 250;
			bool flag44 = (!GameCanvas.lowGraphic || this.typeMap == 33) && this.typeMap != 35 && this.typeMap != 43 && this.typeMap != 62;
			if (flag44)
			{
				this.PosCloud = new Point[3][];
				for (int num32 = 0; num32 < this.PosCloud.Length; num32++)
				{
					this.PosCloud[num32] = new Point[num31 + 1];
					for (int num33 = 0; num33 < this.PosCloud[num32].Length; num33++)
					{
						this.PosCloud[num32][num33] = new Point();
						this.PosCloud[num32][num33].x = CRes.random(GameCanvas.loadmap.maxWMap) * 100;
						this.PosCloud[num32][num33].y = this.valueMyRandom - 60 + num32 * 30 + ((num32 == 1) ? 5 : 0) + CRes.random_Am_0(10);
						this.PosCloud[num32][num33].vx = -60 / (num32 * 4 + 1);
						this.PosCloud[num32][num33].frame = num32 % 3;
					}
				}
			}
			this.lastMap = this.typeMap;
		}
	}

	// Token: 0x060008CB RID: 2251 RVA: 0x000B2F10 File Offset: 0x000B1110
	public bool checkDonotLow()
	{
		bool flag = this.typeMap == 8 || this.typeMap == 51 || this.typeMap == 17 || this.typeMap == 23 || this.typeMap == 22;
		return !flag;
	}

	// Token: 0x060008CC RID: 2252 RVA: 0x000B2F60 File Offset: 0x000B1160
	public void paint(mGraphics g)
	{
		bool flag = MainScreen.cameraMain.yCam < 0;
		if (flag)
		{
			g.setColor(this.color);
			g.fillRect(MainScreen.cameraMain.xCam, MainScreen.cameraMain.yCam, MotherCanvas.w, MotherCanvas.h);
		}
		bool flag2 = (GameCanvas.isLowGraOrWP_PvP() || GameCanvas.isOffBg) && this.checkDonotLow();
		if (flag2)
		{
			bool flag3 = MainScreen.cameraMain.yCam + this.yeff <= this.hBack;
			if (flag3)
			{
				g.setColor(this.color);
				g.fillRect(MainScreen.cameraMain.xCam, MainScreen.cameraMain.yCam, MotherCanvas.w, MotherCanvas.h);
			}
			bool flag4 = LoadMap.idTile != 11 && LoadMap.idTile != 14;
			if (flag4)
			{
				for (int i = MainScreen.cameraMain.xCam / this.mSpeedImg[0] % this.mWImg[0]; i < MotherCanvas.w + this.mWImg[0]; i += this.mWImg[0])
				{
					g.drawImage(this.mImg[0], MainScreen.cameraMain.xCam + MotherCanvas.w - i, this.mHBegin[0] + this.yeff, 0);
				}
				g.setColor(this.colorMini);
				g.fillRect(MainScreen.cameraMain.xCam, this.mHBegin[0] + this.yeff + 96, MotherCanvas.w, 40);
			}
		}
		else
		{
			bool flag5 = this.typeMap != 20;
			if (flag5)
			{
				bool flag6 = this.typeMap != 8 && this.typeMap != 40;
				if (flag6)
				{
					bool flag7 = MainScreen.cameraMain.yCam - this.yeff < this.mHBegin[this.mHBegin.Length - 1];
					if (flag7)
					{
						g.setColor(this.color);
						g.fillRect(MainScreen.cameraMain.xCam - GameScreen.dx, MainScreen.cameraMain.yCam - GameScreen.dy, MotherCanvas.w + GameScreen.dx, this.mHBegin[this.mHBegin.Length - 1] - MainScreen.cameraMain.yCam + this.yeff + GameScreen.dy + 10);
					}
				}
				else
				{
					bool flag8 = MainScreen.cameraMain.yCam - this.yeff < this.mHBegin[this.mHBegin.Length - 1];
					if (flag8)
					{
						g.setColor(this.color);
						g.fillRect(MainScreen.cameraMain.xCam, MainScreen.cameraMain.yCam - this.hEff, MotherCanvas.w, this.mHBegin[this.mHBegin.Length - 1] - MainScreen.cameraMain.yCam + this.hEff + this.yeff);
					}
				}
			}
			bool flag9 = this.typeMap != 20 && this.typeMap != 21 && this.typeMap != 22;
			if (flag9)
			{
				this.paintSky(g);
			}
			switch (this.typeMap)
			{
			case 0:
				for (int j = this.mWImg.Length - 1; j >= 0; j--)
				{
					for (int k = MainScreen.cameraMain.xCam / this.mSpeedImg[j] % this.mWImg[j]; k < MotherCanvas.w + this.mWImg[j]; k += this.mWImg[j])
					{
						g.drawImage(this.mImg[j], MainScreen.cameraMain.xCam + MotherCanvas.w - k, this.mHBegin[j] + this.yeff, 0);
						bool flag10 = j == 0;
						if (flag10)
						{
							MapBackGround.fraChong.drawFrame(GameCanvas.gameTick / 3 % MapBackGround.fraChong.nFrame, MainScreen.cameraMain.xCam + MotherCanvas.w - k + 187, this.mHBegin[j] + 7 + this.yeff, 0, 3, g);
						}
						bool flag11 = j == 1;
						if (flag11)
						{
							MapBackGround.fraChongNho.drawFrame(GameCanvas.gameTickChia4 % MapBackGround.fraChong.nFrame, MainScreen.cameraMain.xCam + MotherCanvas.w - k + 243, this.mHBegin[j] + 4 + this.yeff, 0, 3, g);
						}
					}
				}
				this.paintCloud(g);
				break;
			case 1:
			case 3:
			case 5:
			case 6:
			case 10:
			case 35:
				for (int l = this.mWImg.Length - 1; l >= 0; l--)
				{
					for (int m = MainScreen.cameraMain.xCam / this.mSpeedImg[l] % this.mWImg[l]; m < MotherCanvas.w + this.mWImg[l]; m += this.mWImg[l])
					{
						g.drawImage(this.mImg[l], MainScreen.cameraMain.xCam + MotherCanvas.w - m, this.mHBegin[l] + this.yeff, 0);
					}
				}
				this.paintCloud(g);
				break;
			case 2:
			case 4:
			case 45:
			{
				this.paintCloud(g);
				for (int n = MainScreen.cameraMain.xCam / this.mSpeedImg[1] % this.mWImg[1]; n < MotherCanvas.w + this.mWImg[1]; n += this.mWImg[1])
				{
					g.drawImage(this.mImg[1], MainScreen.cameraMain.xCam + MotherCanvas.w - n, this.mHBegin[1] + this.yeff, 0);
				}
				bool flag12 = this.typeMap != 45;
				if (flag12)
				{
					int x = MainScreen.cameraMain.xCam + 120 - MainScreen.cameraMain.xCam / 16;
					g.drawImage(this.mImg[2], x, this.hBack - 112 + this.yeff, 0);
				}
				for (int num = MainScreen.cameraMain.xCam / this.mSpeedImg[0] % this.mWImg[0]; num < MotherCanvas.w + this.mWImg[0]; num += this.mWImg[0])
				{
					g.drawImage(this.mImg[0], MainScreen.cameraMain.xCam + MotherCanvas.w - num, this.mHBegin[0] + this.yeff, 0);
				}
				break;
			}
			case 7:
			case 26:
			case 47:
				this.paintCloud(g);
				for (int num2 = MainScreen.cameraMain.xCam / this.mSpeedImg[0] % this.mWImg[0]; num2 < MotherCanvas.w + this.mWImg[0]; num2 += this.mWImg[0])
				{
					g.drawImage(this.mImg[0], MainScreen.cameraMain.xCam + MotherCanvas.w - num2, this.mHBegin[0] - 18 + this.yeff, 0);
					bool flag13 = this.typeMap == 26;
					if (flag13)
					{
						g.drawImage(this.mImg[1], MainScreen.cameraMain.xCam + MotherCanvas.w - num2, this.mHBegin[0] - 18 + this.yeff, 0);
					}
				}
				break;
			case 8:
				for (int num3 = MainScreen.cameraMain.xCam / this.mSpeedImg[0] % this.mWImg[0]; num3 < MotherCanvas.w + this.mWImg[0]; num3 += this.mWImg[0])
				{
					g.drawImage(this.mImg[0], MainScreen.cameraMain.xCam + MotherCanvas.w - num3, this.mHBegin[0] - this.hEff + this.yeff, 0);
				}
				this.paintCloud(g);
				break;
			case 9:
				this.paintCloud(g);
				for (int num4 = this.mWImg.Length - 1; num4 >= 0; num4--)
				{
					for (int num5 = MainScreen.cameraMain.xCam / this.mSpeedImg[num4] % this.mWImg[num4]; num5 < MotherCanvas.w + this.mWImg[num4]; num5 += this.mWImg[num4])
					{
						bool flag14 = num4 == 1;
						if (flag14)
						{
							g.drawRegion(this.mImg[num4], 0, 24 * (GameCanvas.gameTick / 8 % 2), 24, 24, 0, (float)(MainScreen.cameraMain.xCam + MotherCanvas.w - num5), (float)(this.mHBegin[num4] + this.yeff), 0);
						}
						else
						{
							g.drawImage(this.mImg[num4], MainScreen.cameraMain.xCam + MotherCanvas.w - num5, this.mHBegin[num4] + this.yeff, 0);
						}
					}
				}
				break;
			case 11:
			case 27:
				for (int num6 = MainScreen.cameraMain.xCam / this.mSpeedImg[0] % this.mWImg[0]; num6 < MotherCanvas.w + this.mWImg[0]; num6 += this.mWImg[0])
				{
					g.drawImage(this.mImg[0], MainScreen.cameraMain.xCam + MotherCanvas.w - num6, this.mHBegin[0] + this.yeff, 0);
					bool flag15 = this.typeMap == 27;
					if (flag15)
					{
						g.drawImage(this.mImg[1], MainScreen.cameraMain.xCam + MotherCanvas.w - num6, this.mHBegin[0] + this.yeff, 0);
					}
				}
				this.paintCloud(g);
				break;
			case 12:
			case 13:
			case 14:
			case 24:
			case 25:
			{
				for (int num7 = this.mHImg.Length - 1; num7 >= 0; num7--)
				{
					for (int num8 = MainScreen.cameraMain.xCam / this.mSpeedImg[num7] % this.mWImg[num7]; num8 < MotherCanvas.w + this.mWImg[num7]; num8 += this.mWImg[num7])
					{
						g.drawImage(this.mImg[num7], MainScreen.cameraMain.xCam + MotherCanvas.w - num8, this.mHBegin[num7] + this.yeff, 0);
					}
				}
				this.paintCloud(g);
				bool flag16 = this.PosObj != null;
				if (flag16)
				{
					int num9 = MainScreen.cameraMain.xCam - MainScreen.cameraMain.xCam / this.mSpeedImg[this.mSpeedImg.Length - 1];
					for (int num10 = 0; num10 < this.PosObj.Length; num10++)
					{
						g.drawImage(this.mImg[(int)this.PosObj[num10][0]], num9 + (int)this.PosObj[num10][1], this.hBack - 48 + this.yeff + (int)this.PosObj[num10][2], 33);
					}
				}
				bool flag17 = this.typeMap == 13 && GameCanvas.loadmap.idMap == 191;
				if (flag17)
				{
					MapBackGround.fraWater7.drawFrame(GameCanvas.gameTick / 3 % MapBackGround.fraWater7.nFrame, MainScreen.cameraMain.xCam + MotherCanvas.w / 2 - MainScreen.cameraMain.xCam / 4, 45 + this.yeff, 0, 3, g);
				}
				break;
			}
			case 15:
			case 41:
			case 60:
			case 61:
			{
				bool flag18 = this.typeMap == 15 || this.typeMap == 60;
				if (flag18)
				{
					for (int num11 = MainScreen.cameraMain.xCam / this.mSpeedImg[1] % this.mWImg[1]; num11 < MotherCanvas.w + this.mWImg[1]; num11 += this.mWImg[1])
					{
						g.drawImage(this.mImg[1], MainScreen.cameraMain.xCam + MotherCanvas.w - num11, this.mHBegin[1] + this.yeff, 0);
					}
				}
				for (int num12 = MainScreen.cameraMain.xCam / this.mSpeedImg[0] % this.mWImg[0]; num12 < MotherCanvas.w + this.mWImg[0] + GameCanvas.loadmap.maxWMap % 125; num12 += this.mWImg[0])
				{
					g.drawImage(this.mImg[0], MainScreen.cameraMain.xCam + MotherCanvas.w - num12 + GameCanvas.loadmap.maxWMap % 125, this.mHBegin[0] + this.yeff, 0);
				}
				bool flag19 = this.typeMap != 60 && this.typeMap != 61;
				if (flag19)
				{
					for (int num13 = 0; num13 < this.mVecKhangia.size(); num13++)
					{
						Point_Focus point_Focus = (Point_Focus)this.mVecKhangia.elementAt(num13);
						bool flag20 = point_Focus.x > MainScreen.cameraMain.xCam - 25 && point_Focus.x < MainScreen.cameraMain.xCam + MotherCanvas.w + 25;
						if (flag20)
						{
							g.drawRegion(this.mImg[2], 0, (point_Focus.dis + point_Focus.frame) * 15, 25, 15, 0, (float)point_Focus.x, (float)point_Focus.y, 33);
						}
					}
				}
				this.paintCloud(g);
				break;
			}
			case 16:
				g.setColor(this.color);
				g.fillRect(MainScreen.cameraMain.xCam, MainScreen.cameraMain.yCam, MotherCanvas.w, MotherCanvas.h);
				this.paintCloud(g);
				break;
			case 17:
			{
				bool flag21 = MainScreen.cameraMain.xCam < 220;
				if (flag21)
				{
					g.drawImage(this.mImg[5], 0, this.mHBegin[0] - 85, 0);
				}
				bool flag22 = this.laboon != null;
				if (flag22)
				{
					bool flag23 = this.laboon.f >= 20 && this.laboon.f <= 27 && this.fraImgNew != null;
					if (flag23)
					{
						this.fraImgNew.drawFrame((this.laboon.f - 20) / 4 % 2, this.laboon.x + 4, this.mHBegin[0] + this.laboon.y + 12, 0, 3, g);
					}
					g.drawImage(this.mImg[4], this.laboon.x, this.mHBegin[0] + this.laboon.y, 0);
					bool flag24 = this.laboon.f < 120;
					if (flag24)
					{
						g.drawRegion(this.mImg[6], 0, this.laboon.f / 4 % 2 * 12, 78, 12, 0, (float)this.laboon.x, (float)(this.mHBegin[0] - 2), 0);
					}
				}
				bool flag25 = MainScreen.cameraMain.xCam < 96;
				if (flag25)
				{
					g.drawImage(this.mImg[1], 0, this.mHBegin[0] - 30, 0);
				}
				for (int num14 = 0; num14 < GameCanvas.loadmap.maxWMap - 180; num14 += 96)
				{
					bool flag26 = 180 + num14 >= MainScreen.cameraMain.xCam - 96 && 180 + num14 <= MainScreen.cameraMain.xCam + MotherCanvas.w;
					if (flag26)
					{
						bool flag27 = num14 == 0;
						if (flag27)
						{
							g.drawImage(this.mImg[3], 180 + num14, this.mHBegin[0] - 30, 0);
						}
						else
						{
							g.drawImage(this.mImg[2], 180 + num14, this.mHBegin[0] - 30, 0);
						}
					}
				}
				for (int num15 = MainScreen.cameraMain.xCam / this.mSpeedImg[0] % this.mWImg[0]; num15 < MotherCanvas.w + this.mWImg[0]; num15 += this.mWImg[0])
				{
					g.drawImage(this.mImg[0], MainScreen.cameraMain.xCam + MotherCanvas.w - num15, this.mHBegin[0], 0);
				}
				this.paintCloud(g);
				break;
			}
			case 18:
			{
				int num16 = MainScreen.cameraMain.xCam / 8;
				for (int num17 = 0; num17 < this.posXuongRong2.Length; num17++)
				{
					bool flag28 = this.posXuongRong2[num17].x + num16 >= MainScreen.cameraMain.xCam - 145 && this.posXuongRong2[num17].x + num16 <= MainScreen.cameraMain.xCam + MotherCanvas.w && !this.posXuongRong2[num17].isSmall;
					if (flag28)
					{
						g.drawImage(this.mImg[4], this.posXuongRong2[num17].x + num16, this.mHBegin[0] + this.posXuongRong2[num17].y - 100 + 45 + this.yeff, 0);
					}
				}
				num16 = MainScreen.cameraMain.xCam / 6;
				for (int num18 = 0; num18 < this.posXuongRong.Length; num18++)
				{
					bool flag29 = this.posXuongRong[num18].x + num16 >= MainScreen.cameraMain.xCam - 145 && this.posXuongRong[num18].x + num16 <= MainScreen.cameraMain.xCam + MotherCanvas.w && !this.posXuongRong[num18].isSmall;
					if (flag29)
					{
						g.drawImage(this.mImg[2 + this.posXuongRong[num18].frame], this.posXuongRong[num18].x + num16, this.mHBegin[0] + this.posXuongRong[num18].y - 100 + 35 + this.yeff, 0);
					}
				}
				for (int num19 = 1; num19 >= 0; num19--)
				{
					for (int num20 = MainScreen.cameraMain.xCam / this.mSpeedImg[num19] % this.mWImg[num19]; num20 < MotherCanvas.w + this.mWImg[num19]; num20 += this.mWImg[num19])
					{
						g.drawImage(this.mImg[num19], MainScreen.cameraMain.xCam + MotherCanvas.w - num20, this.mHBegin[num19] + this.yeff, 0);
					}
				}
				num16 = MainScreen.cameraMain.xCam + 100 - MainScreen.cameraMain.xCam / 16;
				g.drawImage(this.mImg[5], num16 + MotherCanvas.w / 3, this.mHBegin[0] - 120, 0);
				this.paintCloudNight(g);
				break;
			}
			case 19:
			case 23:
			{
				bool flag30 = !GameCanvas.isLowGraOrWP_PvP() && !GameCanvas.isOffBg;
				if (flag30)
				{
					this.paintCloud(g);
				}
				for (int num21 = MainScreen.cameraMain.xCam / this.mSpeedImg[1] % this.mWImg[1]; num21 < MotherCanvas.w + this.mWImg[1]; num21 += this.mWImg[1])
				{
					g.drawImage(this.mImg[1], MainScreen.cameraMain.xCam + MotherCanvas.w - num21, this.mHBegin[1] + this.yeff, 0);
				}
				bool flag31 = !GameCanvas.isLowGraOrWP_PvP() && !GameCanvas.isOffBg;
				if (flag31)
				{
					int num22 = MainScreen.cameraMain.xCam + 60 - MainScreen.cameraMain.xCam / 12;
					g.drawImage(this.mImg[3], num22 + 120, this.hBack - 70 + this.yeff, 0);
					g.drawImage(this.mImg[2], num22, this.hBack - 90 + this.yeff, 0);
				}
				for (int num23 = MainScreen.cameraMain.xCam / this.mSpeedImg[0] % this.mWImg[0]; num23 < MotherCanvas.w + this.mWImg[0]; num23 += this.mWImg[0])
				{
					g.drawImage(this.mImg[0], MainScreen.cameraMain.xCam + MotherCanvas.w - num23, this.mHBegin[0] + this.yeff, 0);
				}
				break;
			}
			case 20:
			case 22:
			{
				g.setColor(this.color);
				g.fillRect(MainScreen.cameraMain.xCam, MainScreen.cameraMain.yCam, MotherCanvas.w, MotherCanvas.h);
				this.paintSky(g);
				g.setColor(this.colorMini);
				g.fillRect(MainScreen.cameraMain.xCam, this.mHBegin[0] + 30, MotherCanvas.w, 100);
				bool flag32 = !GameCanvas.isLowGraOrWP_PvP() && !GameCanvas.isOffBg;
				if (flag32)
				{
					int num24 = MainScreen.cameraMain.xCam + 80 - MainScreen.cameraMain.xCam / 24;
					for (int num25 = 0; num25 < this.PosObj.Length; num25++)
					{
						g.drawImage(this.mImg[(int)this.PosObj[num25][0]], num24 + (int)this.PosObj[num25][1], this.hBack - (int)this.PosObj[num25][2] - 100 + this.yeff, 0);
					}
					for (int num26 = MainScreen.cameraMain.xCam / this.mSpeedImg[0] % this.mWImg[0]; num26 < MotherCanvas.w + this.mWImg[0]; num26 += this.mWImg[0])
					{
						g.drawImage(this.mImg[0], MainScreen.cameraMain.xCam + MotherCanvas.w - num26, this.mHBegin[0] + this.yeff, 0);
					}
					num24 = MainScreen.cameraMain.xCam - MainScreen.cameraMain.xCam / 12;
					for (int num27 = 0; num27 < this.PosObj2.Length; num27++)
					{
						g.drawImage(this.mImg[4], num24 + (int)this.PosObj2[num27][1], this.hBack - (int)this.PosObj2[num27][2] + this.yeff - 45, 0);
					}
				}
				for (int num28 = MainScreen.cameraMain.xCam % 124; num28 < MotherCanvas.w + 124; num28 += 124)
				{
					g.drawImage(this.imgSpec, MainScreen.cameraMain.xCam + MotherCanvas.w - num28, this.mHBegin[0] + 80, 0);
				}
				bool flag33 = !GameCanvas.isLowGraOrWP_PvP() && !GameCanvas.isOffBg;
				if (flag33)
				{
					this.paintCloud(g);
				}
				break;
			}
			case 21:
			{
				g.setColor(this.color);
				g.fillRect(MainScreen.cameraMain.xCam, MainScreen.cameraMain.yCam, MotherCanvas.w, MotherCanvas.h);
				this.paintSky(g);
				g.setColor(this.colorMini);
				g.fillRect(MainScreen.cameraMain.xCam, this.mHBegin[1] + this.yeff + 4, MotherCanvas.w, 100);
				for (int num29 = MainScreen.cameraMain.xCam / this.mSpeedImg[1] % this.mWImg[1]; num29 < MotherCanvas.w + this.mWImg[1]; num29 += this.mWImg[1])
				{
					g.drawImage(this.mImg[1], MainScreen.cameraMain.xCam + MotherCanvas.w - num29, this.mHBegin[1] + this.yeff, 0);
				}
				int x2 = MainScreen.cameraMain.xCam + 200 - MainScreen.cameraMain.xCam / 8;
				g.drawImage(this.mImg[0], x2, this.hBack - 35 + this.yeff, 33);
				for (int num30 = MainScreen.cameraMain.xCam / this.mSpeedImg[0] % this.mWImg[0]; num30 < MotherCanvas.w + this.mWImg[0]; num30 += this.mWImg[0])
				{
					g.drawImage(this.mImg[1], MainScreen.cameraMain.xCam + MotherCanvas.w - num30, this.mHBegin[0] + this.yeff, 0);
				}
				this.paintCloud(g);
				break;
			}
			case 28:
				for (int num31 = MainScreen.cameraMain.xCam / this.mSpeedImg[0] % this.mWImg[0]; num31 < MotherCanvas.w + this.mWImg[0]; num31 += this.mWImg[0])
				{
					g.drawImage(this.mImg[0], MainScreen.cameraMain.xCam + MotherCanvas.w - num31, this.mHBegin[0] + this.yeff, 0);
				}
				this.paintCloud(g);
				break;
			case 29:
				g.setColor(this.colorMini);
				g.fillRect(MainScreen.cameraMain.xCam, this.mHBegin[0] + 20, MotherCanvas.w, 100);
				for (int num32 = 1; num32 >= 0; num32--)
				{
					for (int num33 = MainScreen.cameraMain.xCam / this.mSpeedImg[num32] % this.mWImg[num32]; num33 < MotherCanvas.w + this.mWImg[num32]; num33 += this.mWImg[num32])
					{
						g.drawImage(this.mImg[num32], MainScreen.cameraMain.xCam + MotherCanvas.w - num33, this.mHBegin[num32] + this.yeff, 0);
					}
				}
				this.paintCloud(g);
				break;
			case 30:
			{
				g.setColor(this.colorMini);
				g.fillRect(MainScreen.cameraMain.xCam, this.mHBegin[0] + 10, MotherCanvas.w, 100);
				for (int num34 = 1; num34 >= 0; num34--)
				{
					for (int num35 = MainScreen.cameraMain.xCam / this.mSpeedImg[num34] % this.mWImg[num34]; num35 < MotherCanvas.w + this.mWImg[num34]; num35 += this.mWImg[num34])
					{
						g.drawImage(this.mImg[num34], MainScreen.cameraMain.xCam + MotherCanvas.w - num35, this.mHBegin[num34] + this.yeff, 0);
					}
				}
				int num36 = MainScreen.cameraMain.xCam + 160 - MainScreen.cameraMain.xCam / 4;
				g.drawImage(this.mImg[2], num36, this.hBack - 75 + this.yeff, 0);
				g.drawRegion(this.mImg[2], 0, 0, 92, 125, 2, (float)(num36 + 92), (float)(this.hBack - 75 + this.yeff), 0);
				this.paintCloud(g);
				break;
			}
			case 31:
				g.setColor(this.colorMini);
				g.fillRect(MainScreen.cameraMain.xCam, this.mHBegin[0] + 10, MotherCanvas.w, 100);
				for (int num37 = this.mWImg.Length - 1; num37 >= 0; num37--)
				{
					for (int num38 = MainScreen.cameraMain.xCam / this.mSpeedImg[num37] % this.mWImg[num37]; num38 < MotherCanvas.w + this.mWImg[num37]; num38 += this.mWImg[num37])
					{
						g.drawImage(this.mImg[num37], MainScreen.cameraMain.xCam + MotherCanvas.w - num38, this.mHBegin[num37] + this.yeff, 0);
					}
				}
				this.paintCloud(g);
				break;
			case 32:
			{
				g.setColor(this.colorMini);
				g.fillRect(MainScreen.cameraMain.xCam, this.mHBegin[0] + 10, MotherCanvas.w, 100);
				for (int num39 = MainScreen.cameraMain.xCam / this.mSpeedImg[1] % this.mWImg[1]; num39 < MotherCanvas.w + this.mWImg[1]; num39 += this.mWImg[1])
				{
					g.drawImage(this.mImg[1], MainScreen.cameraMain.xCam + MotherCanvas.w - num39, this.mHBegin[1] + this.yeff, 0);
				}
				int num40 = MainScreen.cameraMain.xCam + 160 - MainScreen.cameraMain.xCam / 8;
				g.drawImage(this.mImg[2], num40, this.hBack - 85 + this.yeff, 0);
				g.drawRegion(this.mImg[2], 0, 0, 92, 125, 2, (float)(num40 + 92), (float)(this.hBack - 85 + this.yeff), 0);
				for (int num41 = MainScreen.cameraMain.xCam / this.mSpeedImg[0] % this.mWImg[0]; num41 < MotherCanvas.w + this.mWImg[0]; num41 += this.mWImg[0])
				{
					g.drawImage(this.mImg[0], MainScreen.cameraMain.xCam + MotherCanvas.w - num41, this.mHBegin[0] + this.yeff, 0);
				}
				this.paintCloud(g);
				break;
			}
			case 33:
			{
				bool flag34 = GameCanvas.loadmap.idMap >= 167 && GameCanvas.loadmap.idMap <= 176;
				if (!flag34)
				{
					for (int num42 = 1; num42 >= 0; num42--)
					{
						for (int num43 = MainScreen.cameraMain.xCam / this.mSpeedImg[num42] % this.mWImg[num42]; num43 < MotherCanvas.w + this.mWImg[num42]; num43 += this.mWImg[num42])
						{
							g.drawImage(this.mImg[num42], MainScreen.cameraMain.xCam + MotherCanvas.w - num43, this.mHBegin[num42] + this.yeff, 0);
						}
					}
				}
				break;
			}
			case 36:
				for (int num44 = this.mWImg.Length - 1; num44 >= 0; num44--)
				{
					for (int num45 = MainScreen.cameraMain.xCam / this.mSpeedImg[num44] % this.mWImg[num44]; num45 < MotherCanvas.w + this.mWImg[num44]; num45 += this.mWImg[num44])
					{
						g.drawImage(this.mImg[num44], MainScreen.cameraMain.xCam + MotherCanvas.w - num45, this.mHBegin[num44] + this.yeff, 0);
					}
				}
				this.paintCloud(g);
				break;
			case 37:
			{
				g.setColor(this.color);
				g.fillRect(MainScreen.cameraMain.xCam, MainScreen.cameraMain.yCam, MotherCanvas.w, MotherCanvas.h);
				int num46 = MainScreen.cameraMain.xCam + 120 - MainScreen.cameraMain.xCam / 8;
				for (int num47 = 0; num47 < this.PosObj17.Length; num47++)
				{
					g.drawRegion(this.mImg[(int)this.PosObj17[num47][0]], 0, 0, this.mImg[(int)this.PosObj17[num47][0]].w, this.mImg[(int)this.PosObj17[num47][0]].h, (int)this.PosObj17[num47][1], (float)(num46 + (int)this.PosObj17[num47][2]), (float)(this.hBack + this.yeff + (int)this.PosObj17[num47][3]), 3);
				}
				for (int num48 = MainScreen.cameraMain.xCam / this.mSpeedImg[0] % this.mWImg[0]; num48 < MotherCanvas.w + this.mWImg[0]; num48 += this.mWImg[0])
				{
					g.drawImage(this.mImg[6], MainScreen.cameraMain.xCam + MotherCanvas.w - num48, this.mHBegin[0] + this.yeff, 0);
				}
				this.paintCloud(g);
				break;
			}
			case 38:
			{
				g.setColor(this.color);
				g.fillRect(MainScreen.cameraMain.xCam, MainScreen.cameraMain.yCam, MotherCanvas.w, MotherCanvas.h);
				int num49 = MainScreen.cameraMain.xCam + 120 - MainScreen.cameraMain.xCam / 8;
				for (int num50 = 0; num50 < this.PosObj18.Length; num50++)
				{
					g.drawRegion(this.mImg[(int)this.PosObj18[num50][0]], 0, 0, this.mImg[(int)this.PosObj18[num50][0]].w, this.mImg[(int)this.PosObj18[num50][0]].h, (int)this.PosObj18[num50][1], (float)(num49 + (int)this.PosObj18[num50][2]), (float)(this.hBack + this.yeff + (int)this.PosObj18[num50][3]), 3);
				}
				this.paintCloud(g);
				break;
			}
			case 39:
			{
				g.setColor(this.color);
				g.fillRect(MainScreen.cameraMain.xCam, MainScreen.cameraMain.yCam, MotherCanvas.w, MotherCanvas.h);
				int num51 = MainScreen.cameraMain.xCam + 180 - MainScreen.cameraMain.xCam / 8;
				for (int num52 = 0; num52 < this.PosObj21.Length; num52++)
				{
					bool flag35 = this.PosObj21[num52][3] == 0;
					if (flag35)
					{
						g.drawRegion(this.mImg[9], 0, (int)(this.PosObj21[num52][2] * 18), 18, 18, 0, (float)(num51 + (int)this.PosObj21[num52][0]), (float)(this.hBack + this.yeff + (int)this.PosObj21[num52][1]), 3);
					}
				}
				for (int num53 = 0; num53 <= 5; num53++)
				{
					bool flag36 = num53 == 0;
					if (flag36)
					{
						g.drawRegion(this.mImg[6], 0, 0, this.mImg[6].w, this.mImg[6].h, 0, (float)num51, (float)(this.hBack + this.yeff - 23 - num53 * 47 + 30), 3);
					}
					else
					{
						g.drawRegion(this.mImg[7], 0, 0, this.mImg[7].w, this.mImg[7].h, 0, (float)num51, (float)(this.hBack + this.yeff - 23 - num53 * 47 + 30), 3);
					}
				}
				for (int num54 = 0; num54 < this.PosObj21.Length; num54++)
				{
					bool flag37 = this.PosObj21[num54][3] == 1;
					if (flag37)
					{
						g.drawRegion(this.mImg[9], 0, (int)(this.PosObj21[num54][2] * 18), 18, 18, 0, (float)(num51 + (int)this.PosObj21[num54][0]), (float)(this.hBack + this.yeff + (int)this.PosObj21[num54][1]), 3);
					}
				}
				for (int num55 = 0; num55 < this.PosObj19.Length; num55++)
				{
					g.drawRegion(this.mImg[(int)this.PosObj19[num55][0]], 0, 0, this.mImg[(int)this.PosObj19[num55][0]].w, this.mImg[(int)this.PosObj19[num55][0]].h, (int)this.PosObj19[num55][1], (float)(num51 + (int)this.PosObj19[num55][2]), (float)(this.hBack + this.yeff + (int)this.PosObj19[num55][3] + 30), 3);
				}
				for (int num56 = MainScreen.cameraMain.xCam / this.mSpeedImg[0] % this.mWImg[0]; num56 < MotherCanvas.w + this.mWImg[0]; num56 += this.mWImg[0])
				{
					g.drawImage(this.mImg[8], MainScreen.cameraMain.xCam + MotherCanvas.w - num56, this.mHBegin[0] + this.yeff, 0);
				}
				this.paintCloud(g);
				break;
			}
			case 40:
			{
				for (int num57 = MainScreen.cameraMain.xCam / this.mSpeedImg[0] % this.mWImg[0]; num57 < MotherCanvas.w + this.mWImg[0]; num57 += this.mWImg[0])
				{
					g.drawImage(this.mImg[0], MainScreen.cameraMain.xCam + MotherCanvas.w - num57, this.mHBegin[0] - this.hEff + this.yeff, 0);
				}
				this.paintCloud(g);
				int num58 = 0;
				while (num58 < this.PosObj.Length && this.PosObj[num58] != null)
				{
					bool flag38 = (int)(12 + this.PosObj[num58][0]) > MainScreen.cameraMain.xCam - 17 && (int)(12 + this.PosObj[num58][0]) < MainScreen.cameraMain.xCam + MotherCanvas.w + 17;
					if (flag38)
					{
						g.drawRegion(this.mImg[2], (int)(this.PosObj[num58][2] * 17), (int)(this.PosObj[num58][3] * 30), 17, 30, (int)this.PosObj[num58][5], (float)this.PosObj[num58][0], (float)(this.mHBegin[0] + 73 + (int)this.PosObj[num58][1]), 33);
					}
					num58++;
				}
				break;
			}
			case 42:
				g.setColor(this.colorMini);
				g.fillRect(MainScreen.cameraMain.xCam, this.mHBegin[0] + 10, MotherCanvas.w, 100);
				for (int num59 = this.mWImg.Length - 1; num59 >= 0; num59--)
				{
					for (int num60 = MainScreen.cameraMain.xCam / this.mSpeedImg[num59] % this.mWImg[num59]; num60 < MotherCanvas.w + this.mWImg[num59]; num60 += this.mWImg[num59])
					{
						g.drawImage(this.mImg[num59], MainScreen.cameraMain.xCam + MotherCanvas.w - num60, this.mHBegin[num59] + this.yeff, 0);
					}
				}
				this.paintCloud(g);
				break;
			case 43:
			{
				g.setColor(this.color);
				g.fillRect(MainScreen.cameraMain.xCam, MainScreen.cameraMain.yCam, MotherCanvas.w, MotherCanvas.h);
				for (int num61 = MainScreen.cameraMain.xCam / this.mSpeedImg[2] % this.mWImg[2]; num61 < MotherCanvas.w + this.mWImg[2]; num61 += this.mWImg[2])
				{
					g.drawImage(this.mImg[2], MainScreen.cameraMain.xCam + MotherCanvas.w - num61, this.mHBegin[2] + this.yeff, 0);
				}
				int num62 = MainScreen.cameraMain.xCam - MainScreen.cameraMain.xCam / 12;
				for (int num63 = 0; num63 < this.PosObj24.Length; num63++)
				{
					bool flag39 = num62 + (int)this.PosObj24[num63][0] >= MainScreen.cameraMain.xCam - 120 && num62 + (int)this.PosObj24[num63][0] <= MainScreen.cameraMain.xCam + MotherCanvas.w + 120;
					if (flag39)
					{
						g.drawImage(this.mImg[(int)this.PosObj24[num63][2]], num62 + (int)this.PosObj24[num63][0], this.mHBegin[2] + this.yeff + 40 + (int)this.PosObj24[num63][1], 33);
					}
				}
				for (int num64 = MainScreen.cameraMain.xCam / this.mSpeedImg[1] % this.mWImg[1]; num64 < MotherCanvas.w + this.mWImg[1]; num64 += this.mWImg[1])
				{
					g.drawImage(this.mImg[1], MainScreen.cameraMain.xCam + MotherCanvas.w - num64, this.mHBegin[1] + this.yeff, 0);
				}
				num62 = MainScreen.cameraMain.xCam - MainScreen.cameraMain.xCam / 3;
				for (int num65 = 0; num65 < this.PosObj23.Length; num65++)
				{
					bool flag40 = num62 + (int)this.PosObj23[num65][0] >= MainScreen.cameraMain.xCam - 120 && num62 + (int)this.PosObj23[num65][0] <= MainScreen.cameraMain.xCam + MotherCanvas.w + 120;
					if (flag40)
					{
						g.drawImage(this.mImg[(int)this.PosObj23[num65][2]], num62 + (int)this.PosObj23[num65][0], this.mHBegin[1] + this.yeff + 40 + (int)this.PosObj23[num65][1], 33);
					}
				}
				for (int num66 = MainScreen.cameraMain.xCam / this.mSpeedImg[0] % this.mWImg[0]; num66 < MotherCanvas.w + this.mWImg[0]; num66 += this.mWImg[0])
				{
					g.drawImage(this.mImg[0], MainScreen.cameraMain.xCam + MotherCanvas.w - num66, this.mHBegin[0] + this.yeff, 0);
				}
				num62 = MainScreen.cameraMain.xCam - MainScreen.cameraMain.xCam / 1;
				for (int num67 = 0; num67 < this.PosObj22.Length; num67++)
				{
					bool flag41 = num62 + (int)this.PosObj22[num67][0] >= MainScreen.cameraMain.xCam - 120 && num62 + (int)this.PosObj22[num67][0] <= MainScreen.cameraMain.xCam + MotherCanvas.w + 120;
					if (flag41)
					{
						g.drawImage(this.mImg[(int)this.PosObj22[num67][2]], num62 + (int)this.PosObj22[num67][0], this.mHBegin[0] + this.yeff + 40 + (int)this.PosObj22[num67][1], 33);
					}
				}
				this.paintCloud(g);
				break;
			}
			case 44:
			{
				int num68 = MainScreen.cameraMain.xCam + 180 - MainScreen.cameraMain.xCam / 12;
				for (int num69 = 0; num69 < this.PosObj21.Length; num69++)
				{
					bool flag42 = this.PosObj21[num69][3] == 0;
					if (flag42)
					{
						g.drawRegion(this.mImg[5], 0, (int)(this.PosObj21[num69][2] * 18), 18, 18, 0, (float)(num68 + (int)this.PosObj21[num69][0]), (float)(this.hBack + this.yeff + (int)this.PosObj21[num69][1]), 3);
					}
				}
				for (int num70 = 0; num70 <= 5; num70++)
				{
					bool flag43 = num70 == 0;
					if (flag43)
					{
						g.drawRegion(this.mImg[3], 0, 0, this.mImg[3].w, this.mImg[3].h, 0, (float)num68, (float)(this.hBack + this.yeff - 23 - num70 * 47 + 30), 3);
					}
					else
					{
						g.drawRegion(this.mImg[4], 0, 0, this.mImg[4].w, this.mImg[4].h, 0, (float)num68, (float)(this.hBack + this.yeff - 23 - num70 * 47 + 30), 3);
					}
				}
				for (int num71 = 0; num71 < this.PosObj21.Length; num71++)
				{
					bool flag44 = this.PosObj21[num71][3] == 1;
					if (flag44)
					{
						g.drawRegion(this.mImg[5], 0, (int)(this.PosObj21[num71][2] * 18), 18, 18, 0, (float)(num68 + (int)this.PosObj21[num71][0]), (float)(this.hBack + this.yeff + (int)this.PosObj21[num71][1]), 3);
					}
				}
				for (int num72 = this.mWImg.Length - 1; num72 >= 0; num72--)
				{
					for (int num73 = MainScreen.cameraMain.xCam / this.mSpeedImg[num72] % this.mWImg[num72]; num73 < MotherCanvas.w + this.mWImg[num72]; num73 += this.mWImg[num72])
					{
						g.drawImage(this.mImg[num72], MainScreen.cameraMain.xCam + MotherCanvas.w - num73, this.mHBegin[num72] + this.yeff, 0);
					}
				}
				this.paintCloud(g);
				break;
			}
			case 46:
			{
				g.setColor(this.color);
				g.fillRect(MainScreen.cameraMain.xCam, MainScreen.cameraMain.yCam, MotherCanvas.w, MotherCanvas.h);
				int num74 = MainScreen.cameraMain.xCam + 180 - MainScreen.cameraMain.xCam / 4;
				for (int num75 = 0; num75 < this.PosObj25.Length; num75++)
				{
					g.drawRegion(this.mImg[(int)this.PosObj25[num75][0]], 0, 0, this.mImg[(int)this.PosObj25[num75][0]].w, this.mImg[(int)this.PosObj25[num75][0]].h, (int)this.PosObj25[num75][1], (float)(num74 + (int)this.PosObj25[num75][2]), (float)(this.hBack + this.yeff + (int)this.PosObj25[num75][3] + 30), 3);
				}
				this.paintCloud(g);
				break;
			}
			case 51:
			case 53:
			case 55:
				for (int num76 = this.mWImg.Length - 1; num76 >= 0; num76--)
				{
					for (int num77 = MainScreen.cameraMain.xCam / this.mSpeedImg[num76] % this.mWImg[num76]; num77 < MotherCanvas.w + this.mWImg[num76]; num77 += this.mWImg[num76])
					{
						g.drawImage(this.mImg[num76], MainScreen.cameraMain.xCam + MotherCanvas.w - num77, this.mHBegin[num76] + this.yeff, 0);
					}
				}
				this.paintCloud(g);
				break;
			case 62:
			{
				g.setColor(this.color);
				g.fillRect(MainScreen.cameraMain.xCam, MainScreen.cameraMain.yCam, MotherCanvas.w, MotherCanvas.h);
				this.xCamOffline -= MapGotoGod.vxHardCode;
				int xCam = MainScreen.cameraMain.xCam;
				int num78 = xCam + this.xCamOffline;
				for (int num79 = num78 / this.mSpeedImg[2] % this.mWImg[2]; num79 < xCam + MotherCanvas.w + this.mWImg[2]; num79 += this.mWImg[2])
				{
					bool flag45 = num79 >= -this.mWImg[2];
					if (flag45)
					{
						g.drawImage(this.mImg[2], num79, this.mHBegin[2] + this.yeff, 0);
					}
				}
				int num80 = num78 / 12;
				while (num80 < xCam + MotherCanvas.w)
				{
					for (int num81 = 0; num81 < this.PosObj24.Length; num81++)
					{
						num80 += (int)this.PosObj24[num81][0];
						bool flag46 = num80 >= -30;
						if (flag46)
						{
							g.drawImage(this.mImg[(int)this.PosObj24[num81][2]], num80, this.mHBegin[2] + this.yeff + 40 + (int)this.PosObj24[num81][1], 33);
						}
					}
				}
				for (int num82 = num78 / this.mSpeedImg[1] % this.mWImg[1]; num82 < xCam + MotherCanvas.w + this.mWImg[1]; num82 += this.mWImg[1])
				{
					bool flag47 = num82 >= -this.mWImg[1];
					if (flag47)
					{
						g.drawImage(this.mImg[1], num82, this.mHBegin[1] + this.yeff, 0);
					}
				}
				int num83 = num78 / 3;
				while (num83 < xCam + MotherCanvas.w)
				{
					for (int num84 = 0; num84 < this.PosObj23.Length; num84++)
					{
						num83 += (int)this.PosObj23[num84][0];
						bool flag48 = num83 >= -30;
						if (flag48)
						{
							g.drawImage(this.mImg[(int)this.PosObj23[num84][2]], num83, this.mHBegin[1] + this.yeff + 40 + (int)this.PosObj23[num84][1], 33);
						}
					}
				}
				for (int num85 = num78 / this.mSpeedImg[0] % this.mWImg[0]; num85 < xCam + MotherCanvas.w + this.mWImg[0]; num85 += this.mWImg[0])
				{
					bool flag49 = num85 >= -this.mWImg[0];
					if (flag49)
					{
						g.drawImage(this.mImg[0], num85, this.mHBegin[0] + this.yeff, 0);
					}
				}
				int num86 = num78;
				while (num86 < xCam + MotherCanvas.w)
				{
					for (int num87 = 0; num87 < this.PosObj22.Length; num87++)
					{
						num86 += (int)this.PosObj22[num87][0];
						bool flag50 = num86 >= -30;
						if (flag50)
						{
							g.drawImage(this.mImg[(int)this.PosObj22[num87][2]], num86, this.mHBegin[0] + this.yeff + 40 + (int)this.PosObj22[num87][1], 33);
						}
					}
				}
				this.paintCloud(g);
				break;
			}
			case 63:
				for (int num88 = this.mHImg.Length - 1; num88 >= 0; num88--)
				{
					for (int num89 = MainScreen.cameraMain.xCam / this.mSpeedImg[num88] % this.mWImg[num88]; num89 < MotherCanvas.w + this.mWImg[num88]; num89 += this.mWImg[num88])
					{
						g.drawImage(this.mImg[num88], MainScreen.cameraMain.xCam + MotherCanvas.w - num89, this.mHBegin[num88] + this.yeff, 0);
					}
				}
				break;
			}
		}
	}

	// Token: 0x060008CD RID: 2253 RVA: 0x000B6564 File Offset: 0x000B4764
	public void paintLast(mGraphics g)
	{
		bool flag = (GameCanvas.isLowGraOrWP_PvP() || GameCanvas.isOffBg) && this.checkDonotLow();
		if (!flag)
		{
			sbyte b = this.typeMap;
			sbyte b2 = b;
			if (b2 <= 28)
			{
				if (b2 <= 8)
				{
					if (b2 != 2)
					{
						if (b2 != 8)
						{
							return;
						}
						bool flag2 = MainScreen.cameraMain.yCam > GameCanvas.loadmap.limitH - 40;
						if (flag2)
						{
							g.setColor(this.colorMini);
							g.fillRect(MainScreen.cameraMain.xCam, GameCanvas.loadmap.maxHMap - (20 + this.hEff), MotherCanvas.w, 20 + this.hEff);
							for (int i = MainScreen.cameraMain.xCam % 64; i < MotherCanvas.w + 64; i += 64)
							{
								g.drawRegion(this.mImg[3], 0, (i / 64 + GameCanvas.gameTickChia4) % 4 * 12, 64, 12, 0, (float)(MainScreen.cameraMain.xCam + MotherCanvas.w - i), (float)(GameCanvas.loadmap.maxHMap - 28 - this.hEff), 0);
							}
							for (int j = MainScreen.cameraMain.xCam % 64; j < MotherCanvas.w + 64 + 64; j += 64)
							{
								g.drawRegion(this.mImg[3], 0, (j / 64 + GameCanvas.gameTickChia4 + 2) % 4 * 12, 64, 12, 0, (float)(MainScreen.cameraMain.xCam + 12 + MotherCanvas.w - j), (float)(GameCanvas.loadmap.maxHMap - 12 - this.hEff), 0);
							}
						}
						return;
					}
				}
				else if (b2 - 22 > 1 && b2 != 28)
				{
					return;
				}
			}
			else if (b2 <= 42)
			{
				if (b2 == 40)
				{
					bool flag3 = MainScreen.cameraMain.yCam > GameCanvas.loadmap.limitH - 40;
					if (flag3)
					{
						g.setColor(this.colorMini);
						g.fillRect(MainScreen.cameraMain.xCam, GameCanvas.loadmap.maxHMap - (20 + this.hEff), MotherCanvas.w, 20 + this.hEff);
						for (int k = MainScreen.cameraMain.xCam % 64; k < MotherCanvas.w + 64; k += 64)
						{
							g.drawRegion(this.mImg[1], 0, (k / 64 + GameCanvas.gameTick / 4) % 4 * 12, 64, 12, 0, (float)(MainScreen.cameraMain.xCam + MotherCanvas.w - k), (float)(GameCanvas.loadmap.maxHMap - 28 - this.hEff), 0);
						}
						for (int l = MainScreen.cameraMain.xCam % 64; l < MotherCanvas.w + 64 + 64; l += 64)
						{
							g.drawRegion(this.mImg[1], 0, (l / 64 + GameCanvas.gameTick / 4 + 2) % 4 * 12, 64, 12, 0, (float)(MainScreen.cameraMain.xCam + 12 + MotherCanvas.w - l), (float)(GameCanvas.loadmap.maxHMap - 12 - this.hEff), 0);
						}
					}
					return;
				}
				if (b2 != 42)
				{
					return;
				}
				int num = 0;
				while (num < this.PosObj.Length && this.PosObj[num] != null)
				{
					bool flag4 = (int)(12 + this.PosObj[num][0]) > MainScreen.cameraMain.xCam - 17 && (int)(12 + this.PosObj[num][0]) < MainScreen.cameraMain.xCam + MotherCanvas.w + 17;
					if (flag4)
					{
						g.drawRegion(this.mImg[2], (int)(this.PosObj[num][2] * 17), (int)(this.PosObj[num][3] * 30), 17, 30, (int)this.PosObj[num][5], (float)(12 + this.PosObj[num][0]), (float)(this.mHBegin[0] - 30 + 73 + 90 + (int)this.PosObj[num][1]), 33);
					}
					num++;
				}
				return;
			}
			else
			{
				if (b2 == 45)
				{
					bool flag5 = MainScreen.cameraMain.yCam > GameCanvas.loadmap.limitH - 25;
					if (flag5)
					{
						g.setColor(this.colorMini);
						g.fillRect(MainScreen.cameraMain.xCam, GameCanvas.loadmap.maxHMap - (10 + this.hEff), MotherCanvas.w, 10 + this.hEff);
						this.paintSeaLast(g, this.mImg[this.mImg.Length - 1], 64, 12, 22);
					}
					return;
				}
				if (b2 != 47)
				{
					switch (b2)
					{
					case 51:
					case 53:
					case 55:
						break;
					case 52:
					case 54:
						return;
					default:
						return;
					}
				}
			}
			bool flag6 = MainScreen.cameraMain.yCam > GameCanvas.loadmap.limitH - 25;
			if (flag6)
			{
				g.setColor(this.colorMini);
				g.fillRect(MainScreen.cameraMain.xCam, GameCanvas.loadmap.maxHMap - (6 + this.hEff), MotherCanvas.w, 6 + this.hEff);
				this.paintSeaLast(g, this.mImg[this.mImg.Length - 1], 64, 12, 18);
			}
		}
	}

	// Token: 0x060008CE RID: 2254 RVA: 0x000B6ADC File Offset: 0x000B4CDC
	public void paintSeaLast(mGraphics g, mImage img, int w, int h, int hbegin)
	{
		for (int i = MainScreen.cameraMain.xCam % w; i < MotherCanvas.w + w; i += w)
		{
			g.drawRegion(img, 0, (i / w + GameCanvas.gameTickChia4) % 4 * h, w, h, 0, (float)(MainScreen.cameraMain.xCam + MotherCanvas.w - i), (float)(GameCanvas.loadmap.maxHMap - hbegin - this.hEff), 0);
		}
		for (int j = MainScreen.cameraMain.xCam % w; j < MotherCanvas.w + w + w; j += w)
		{
			g.drawRegion(img, 0, (j / w + GameCanvas.gameTickChia4 + 2) % 4 * h, w, h, 0, (float)(MainScreen.cameraMain.xCam + 12 + MotherCanvas.w - j), (float)(GameCanvas.loadmap.maxHMap - (hbegin - 10) - this.hEff), 0);
		}
	}

	// Token: 0x060008CF RID: 2255 RVA: 0x000B6BC4 File Offset: 0x000B4DC4
	public void paintSky(mGraphics g)
	{
		bool flag = this.imgSky == null;
		if (!flag)
		{
			for (int i = 0; i < MotherCanvas.w; i += 20)
			{
				g.drawImage(this.imgSky, MainScreen.cameraMain.xCam + i, this.mHBegin[0] - this.hSky, 0);
			}
			bool flag2 = MapBackGround.tickRanThunder <= 6 && MapBackGround.tickRanThunder != 4;
			if (flag2)
			{
				g.setColor(16251387);
				g.fillRect(MainScreen.cameraMain.xCam, MainScreen.cameraMain.yCam, MotherCanvas.w, MotherCanvas.h);
			}
			for (int j = 0; j < this.mVecThunder.size(); j++)
			{
				Point point = (Point)this.mVecThunder.elementAt(j);
				bool flag3 = point.f > point.fRe;
				if (flag3)
				{
					int num = 20 + (point.f - point.fRe) / 2 * 27;
					bool flag4 = num > 101;
					if (flag4)
					{
						num = 101;
					}
					g.drawRegion(this.imgThunder, 0, 0, 41, num, point.dis, (float)point.x, (float)(this.mHBegin[0] - this.hSky - 20 + point.y), 0);
				}
			}
		}
	}

	// Token: 0x060008D0 RID: 2256 RVA: 0x000B6D30 File Offset: 0x000B4F30
	public void update()
	{
		for (int i = 0; i < this.mVecThunder.size(); i++)
		{
			Point point = (Point)this.mVecThunder.elementAt(i);
			point.f++;
			bool flag = point.f == point.fRe - 1;
			if (flag)
			{
				point.x += MainScreen.cameraMain.xCam;
			}
			bool flag2 = point.f > point.fRe + 10;
			if (flag2)
			{
				point.f = 0;
				point.x = CRes.random(0, MotherCanvas.w);
				point.y = -CRes.random(40);
				point.dis = CRes.random(2) * 2;
				point.fRe = CRes.random(50, 150);
				bool flag3 = CRes.random(4) == 0;
				if (flag3)
				{
					mSound.playSound(53, mSound.volumeSound);
				}
			}
		}
		bool flag4 = this.mVecThunder.size() > 0;
		if (flag4)
		{
			MapBackGround.tickRanThunder++;
			bool flag5 = MapBackGround.tickRanThunder > 50 && CRes.random(60) == 0;
			if (flag5)
			{
				MapBackGround.tickRanThunder = 0;
			}
		}
		sbyte b = this.typeMap;
		sbyte b2 = b;
		if (b2 <= 15)
		{
			if (b2 != 2)
			{
				if (b2 == 8)
				{
					goto IL_27E;
				}
				if (b2 != 15)
				{
					goto IL_8EC;
				}
				goto IL_4CB;
			}
		}
		else if (b2 <= 23)
		{
			if (b2 == 17)
			{
				bool flag6 = this.laboon != null;
				if (flag6)
				{
					this.laboon.f++;
					this.laboon.x += this.laboon.vx;
					this.laboon.y += this.laboon.vy;
					bool flag7 = this.laboon.f == 10;
					if (flag7)
					{
						this.laboon.vx = -6;
						this.laboon.vy = -4;
					}
					bool flag8 = this.laboon.f == 20;
					if (flag8)
					{
						this.laboon.vx = 0;
						this.laboon.vy = 0;
						LoadMap.timeVibrateScreen = 8;
					}
					bool flag9 = this.laboon.f == 100;
					if (flag9)
					{
						this.laboon.vx = 5;
						this.laboon.vy = 3;
					}
					bool flag10 = this.laboon.f == 116;
					if (flag10)
					{
						this.laboon.vx = 0;
						this.laboon.vy = 0;
					}
					bool flag11 = this.laboon.f > 160 && CRes.random(40) == 0;
					if (flag11)
					{
						this.laboon.x = 140;
						this.laboon.y = 0;
						this.laboon.f = 0;
					}
				}
				goto IL_8EC;
			}
			if (b2 - 22 > 1)
			{
				goto IL_8EC;
			}
		}
		else
		{
			switch (b2)
			{
			case 40:
				goto IL_27E;
			case 41:
				goto IL_4CB;
			case 42:
			{
				bool flag12 = GameCanvas.isLowGraOrWP_PvP() || GameCanvas.isOffBg;
				if (flag12)
				{
					return;
				}
				int num = 0;
				while (num < this.PosObj.Length && this.PosObj[num] != null)
				{
					bool flag13 = this.PosObj[num][3] == 0;
					if (flag13)
					{
						bool flag14 = CRes.random(32) == 0;
						if (flag14)
						{
							this.PosObj[num][3] = 1;
							this.PosObj[num][4] = 0;
						}
					}
					else
					{
						this.PosObj[num][4] = this.PosObj[num][4] + 1;
						bool flag15 = this.PosObj[num][4] == 4;
						if (flag15)
						{
							this.PosObj[num][3] = 2;
						}
						else
						{
							bool flag16 = this.PosObj[num][4] == 8;
							if (flag16)
							{
								this.PosObj[num][3] = 0;
								bool flag17 = (int)this.PosObj[num][0] < GameScreen.player.x;
								if (flag17)
								{
									this.PosObj[num][5] = 2;
								}
								else
								{
									this.PosObj[num][5] = 0;
								}
							}
						}
					}
					num++;
				}
				goto IL_8EC;
			}
			case 43:
			case 44:
			case 46:
				goto IL_8EC;
			case 45:
			case 47:
				break;
			default:
				switch (b2)
				{
				case 51:
				case 53:
				case 55:
					break;
				case 52:
				case 54:
					goto IL_8EC;
				default:
					goto IL_8EC;
				}
				break;
			}
		}
		bool flag18 = !this.isEff;
		if (flag18)
		{
			bool flag19 = this.hEff < 6 && CRes.random(15) == 0;
			if (flag19)
			{
				this.hEff++;
			}
			bool flag20 = CRes.random(200) == 0;
			if (flag20)
			{
				this.isEff = true;
			}
		}
		else
		{
			bool flag21 = this.hEff > 0 && CRes.random(15) == 0;
			if (flag21)
			{
				this.hEff--;
			}
			bool flag22 = CRes.random(200) == 0;
			if (flag22)
			{
				this.isEff = false;
			}
		}
		goto IL_8EC;
		IL_27E:
		bool flag23 = this.typeMap == 40 && (GameCanvas.isLowGraOrWP_PvP() || GameCanvas.isOffBg);
		if (flag23)
		{
			return;
		}
		bool flag24 = !this.isEff;
		if (flag24)
		{
			bool flag25 = this.hEff < 12 && GameCanvas.gameTick % this.valueTick == 0;
			if (flag25)
			{
				this.hEff++;
			}
			bool flag26 = GameCanvas.gameTick % this.valueEndTurn == 0;
			if (flag26)
			{
				this.isEff = true;
				this.valueTick = CRes.random(5, 10);
				this.valueEndTurn = CRes.random(12, 21) * 10;
			}
		}
		else
		{
			bool flag27 = this.hEff > 0 && GameCanvas.gameTick % this.valueTick == 0;
			if (flag27)
			{
				this.hEff--;
			}
			bool flag28 = GameCanvas.gameTick % this.valueEndTurn == 0;
			if (flag28)
			{
				this.isEff = false;
				this.valueTick = CRes.random(5, 10);
				this.valueEndTurn = CRes.random(12, 21) * 10;
			}
		}
		bool flag29 = this.typeMap != 40;
		if (flag29)
		{
			goto IL_8EC;
		}
		int num2 = 0;
		while (num2 < this.PosObj.Length && this.PosObj[num2] != null)
		{
			bool flag30 = this.PosObj[num2][3] == 0;
			if (flag30)
			{
				bool flag31 = CRes.random(32) == 0;
				if (flag31)
				{
					this.PosObj[num2][3] = 1;
					this.PosObj[num2][4] = 0;
				}
			}
			else
			{
				this.PosObj[num2][4] = this.PosObj[num2][4] + 1;
				bool flag32 = this.PosObj[num2][4] == 4;
				if (flag32)
				{
					this.PosObj[num2][3] = 2;
				}
				else
				{
					bool flag33 = this.PosObj[num2][4] == 8;
					if (flag33)
					{
						this.PosObj[num2][3] = 0;
						bool flag34 = (int)this.PosObj[num2][0] < GameScreen.player.x;
						if (flag34)
						{
							this.PosObj[num2][5] = 2;
						}
						else
						{
							this.PosObj[num2][5] = 0;
						}
					}
				}
			}
			num2++;
		}
		goto IL_8EC;
		IL_4CB:
		for (int j = 0; j < this.mVecKhangia.size(); j++)
		{
			Point_Focus point_Focus = (Point_Focus)this.mVecKhangia.elementAt(j);
			bool flag35 = point_Focus.x <= MainScreen.cameraMain.xCam - 25 || point_Focus.x >= MainScreen.cameraMain.xCam + MotherCanvas.w + 25;
			if (!flag35)
			{
				point_Focus.f++;
				bool flag36 = point_Focus.frame == 1;
				if (flag36)
				{
					bool flag37 = point_Focus.f > 15;
					if (flag37)
					{
						point_Focus.frame = 0;
						point_Focus.f = 0;
					}
				}
				else
				{
					bool flag38 = point_Focus.frame != 0;
					if (!flag38)
					{
						bool flag39 = this.isEffKhangia;
						if (flag39)
						{
							bool flag40 = CRes.random(5) != 0;
							if (flag40)
							{
								point_Focus.f = 0;
								point_Focus.frame = 1;
							}
						}
						else
						{
							bool flag41 = CRes.random(30) == 0;
							if (flag41)
							{
								point_Focus.f = 0;
								point_Focus.frame = 1;
							}
						}
					}
				}
			}
		}
		bool flag42 = !this.isEffKhangia;
		if (flag42)
		{
			bool flag43 = CRes.random(100) == 0;
			if (flag43)
			{
				this.isEffKhangia = true;
			}
		}
		else
		{
			bool flag44 = CRes.random(2) == 0;
			if (flag44)
			{
				this.isEffKhangia = false;
			}
		}
		IL_8EC:
		bool flag45 = this.typeMap == 15 || this.typeMap == 41 || this.typeMap == 60 || this.typeMap == 61 || ((this.typeMap == 20 || this.typeMap == 21 || this.typeMap == 22) && GameCanvas.isLowGraOrWP_PvP()) || this.typeMap == 28 || this.typeMap == 31 || this.typeMap == 42 || this.typeMap == 33 || this.typeMap == 43 || this.typeMap == 63;
		if (flag45)
		{
			this.yeff = 0;
		}
		else
		{
			bool flag46 = this.typeMap == 6;
			if (flag46)
			{
				this.yeff = MainScreen.cameraMain.yCam / 12;
			}
			else
			{
				this.yeff = MainScreen.cameraMain.yCam / 6;
			}
		}
		bool flag47 = this.yeff < 0;
		if (flag47)
		{
			this.yeff = 0;
		}
	}

	// Token: 0x060008D1 RID: 2257 RVA: 0x000B771C File Offset: 0x000B591C
	public void paintCloud(mGraphics g)
	{
		bool flag = this.mImgCloud == null;
		if (flag)
		{
			this.loadImgCloud(false);
		}
		else
		{
			bool flag2 = this.PosCloud == null;
			if (!flag2)
			{
				int num = 0;
				bool flag3 = this.typeMap == 8;
				if (flag3)
				{
					num = this.hEff;
				}
				int num2 = MainScreen.cameraMain.xCam / this.mSpeedImg[this.mSpeedImg.Length - 1];
				for (int i = 0; i < this.PosCloud.Length; i++)
				{
					for (int j = 0; j < this.PosCloud[i].Length; j++)
					{
						g.drawImage(this.mImgCloud[this.PosCloud[i][j].frame], MainScreen.cameraMain.xCam - num2 + this.PosCloud[i][j].x / 100, this.PosCloud[i][j].y + this.yeff - num, mGraphics.VCENTER | mGraphics.LEFT);
					}
				}
			}
		}
	}

	// Token: 0x060008D2 RID: 2258 RVA: 0x000B7844 File Offset: 0x000B5A44
	public void paintCloudNight(mGraphics g)
	{
		bool flag = this.mImgCloudNight == null;
		if (flag)
		{
			this.loadImageCloudNight();
		}
		else
		{
			bool flag2 = this.PosCloud == null;
			if (!flag2)
			{
				int num = 0;
				bool flag3 = this.typeMap == 8 || this.typeMap == 40;
				if (flag3)
				{
					num = this.hEff;
				}
				int num2 = MainScreen.cameraMain.xCam / this.mSpeedImg[this.mSpeedImg.Length - 1];
				for (int i = 0; i < this.PosCloud.Length; i++)
				{
					for (int j = 0; j < this.PosCloud[i].Length; j++)
					{
						g.setColor(0);
						g.drawImage(this.mImgCloudNight[this.PosCloud[i][j].frame], MainScreen.cameraMain.xCam - num2 + this.PosCloud[i][j].x / 100, this.PosCloud[i][j].y + this.yeff - num, mGraphics.VCENTER | mGraphics.LEFT);
					}
				}
			}
		}
	}

	// Token: 0x060008D3 RID: 2259 RVA: 0x000B7980 File Offset: 0x000B5B80
	private void loadImageCloudNight()
	{
		this.mImgCloudNight = new mImage[3];
		for (int i = 0; i < this.mImgCloudNight.Length; i++)
		{
			this.mImgCloudNight[i] = mImage.createImage("/bg/cloud1" + i.ToString() + ".png");
		}
	}

	// Token: 0x060008D4 RID: 2260 RVA: 0x000B79D8 File Offset: 0x000B5BD8
	private void loadImgCloud(bool islogin)
	{
		bool flag = GameCanvas.isLowGraOrWP_PvP() || GameCanvas.isOffBg;
		if (!flag)
		{
			this.mImgCloud = new mImage[3];
			for (int i = 0; i < this.mImgCloud.Length; i++)
			{
				bool flag2 = GameScreen.effMap != null && GameScreen.effMap.type == 8;
				if (flag2)
				{
					this.mImgCloud[i] = mImage.createImage("/bg/cloud1" + i.ToString() + ".png");
					MapBackGround.IndexCloud = 1;
				}
				else
				{
					bool flag3 = !islogin && (this.typeMap == 28 || this.typeMap == 29 || this.typeMap == 30 || this.lastMap == 31 || this.lastMap == 42);
					if (flag3)
					{
						this.mImgCloud[i] = mImage.createImage("/bg/cloud2" + i.ToString() + ".png");
						MapBackGround.IndexCloud = 2;
					}
					else
					{
						bool flag4 = !islogin && (LoadMap.idTile == 11 || LoadMap.idTile == 14);
						if (flag4)
						{
							this.mImgCloud[i] = mImage.createImage("/bg/cloud3" + i.ToString() + ".png");
							MapBackGround.IndexCloud = 3;
						}
						else
						{
							this.mImgCloud[i] = mImage.createImage("/bg/cloud" + i.ToString() + ".png");
							MapBackGround.IndexCloud = 0;
						}
					}
				}
			}
		}
	}

	// Token: 0x060008D5 RID: 2261 RVA: 0x000B7B5C File Offset: 0x000B5D5C
	public void updateCloud()
	{
		bool flag = GameCanvas.isLowGraOrWP_PvP() || GameCanvas.isOffBg || this.PosCloud == null;
		if (!flag)
		{
			for (int i = 0; i < this.PosCloud.Length; i++)
			{
				for (int j = 0; j < this.PosCloud[i].Length; j++)
				{
					this.PosCloud[i][j].x += this.PosCloud[i][j].vx;
					bool flag2 = this.PosCloud[i][j].x / 100 < -80;
					if (flag2)
					{
						this.PosCloud[i][j].x = (GameCanvas.loadmap.mapW * LoadMap.wTile + CRes.random_Am_0(125)) * 100;
						this.PosCloud[i][j].y = this.valueMyRandom - 60 + i * 30 + CRes.random_Am_0(10) + ((i == 1) ? 5 : 0);
						this.PosCloud[i][j].vx = -60 / (i * 4 + 1);
						this.PosCloud[i][j].frame = i % 3;
					}
				}
			}
		}
	}

	// Token: 0x060008D6 RID: 2262 RVA: 0x000B7C98 File Offset: 0x000B5E98
	public void setBGLogin()
	{
		this.lastMap = -1;
		this.addObj();
		this.indexBg = 0;
		this.color = 10343167;
		this.PosCloud = null;
		bool flag = GameCanvas.Day_Night == GameCanvas.DAY;
		if (flag)
		{
			bool flag2 = MotherCanvas.h > 230;
			if (flag2)
			{
				this.PosCloud = new Point[3][];
				for (int i = 0; i < this.PosCloud.Length; i++)
				{
					int num = CRes.random(1, 3);
					this.PosCloud[i] = new Point[num];
					for (int j = 0; j < num; j++)
					{
						this.PosCloud[i][j] = new Point();
						this.PosCloud[i][j].x = CRes.random(MotherCanvas.w) * 100;
						this.PosCloud[i][j].y = MotherCanvas.h - 290 + i * 30 + CRes.random_Am_0(10) + ((i == 1) ? 5 : 0);
						this.PosCloud[i][j].vx = -CRes.random(100, 200) / (i * 4 + 1);
						this.PosCloud[i][j].frame = i % 3;
					}
				}
			}
		}
		else
		{
			this.indexBg = 2;
			this.color = 4616312;
			this.PosCloud = new Point[1][];
			for (int k = 0; k < 1; k++)
			{
				int num2 = MotherCanvas.w / 18;
				this.PosCloud[k] = new Point[num2];
				for (int l = 0; l < num2; l++)
				{
					this.PosCloud[k][l] = new Point();
					this.PosCloud[k][l].x = l % 5 * MotherCanvas.w / 5 + MotherCanvas.w / 10 + CRes.random_Am_0(MotherCanvas.w / 10);
					int num3 = MotherCanvas.h - 230;
					bool flag3 = num3 <= 0;
					if (flag3)
					{
						num3 = 1;
					}
					this.PosCloud[k][l].y = MotherCanvas.h - (230 + CRes.random(num3));
					this.PosCloud[k][l].frame = CRes.random(4) * 3;
					this.PosCloud[k][l].f = 4;
					this.PosCloud[k][l].isSmall = (CRes.random(100) == 0);
					bool isSmall = this.PosCloud[k][l].isSmall;
					if (isSmall)
					{
						this.PosCloud[k][l].f = CRes.random(4);
					}
				}
			}
		}
		this.loadBGLogin();
	}

	// Token: 0x060008D7 RID: 2263 RVA: 0x000B7F70 File Offset: 0x000B6170
	public void updateCloudLogin()
	{
		bool flag = GameCanvas.isLowGraOrWP_PvP() || GameCanvas.isOffBg || this.PosCloud == null;
		if (!flag)
		{
			bool flag2 = GameCanvas.Day_Night == GameCanvas.DAY;
			if (flag2)
			{
				for (int i = 0; i < this.PosCloud.Length; i++)
				{
					for (int j = 0; j < this.PosCloud[i].Length; j++)
					{
						this.PosCloud[i][j].x += this.PosCloud[i][j].vx;
						bool flag3 = this.PosCloud[i][j].x < -9000;
						if (flag3)
						{
							this.PosCloud[i][j].x = (MotherCanvas.w + 60 + CRes.random_Am_0(10)) * 100;
							this.PosCloud[i][j].vx = -CRes.random(100, 200) / (i * 4 + 1);
							this.PosCloud[i][j].frame = i % 3;
						}
					}
				}
			}
			else
			{
				for (int k = 0; k < this.PosCloud.Length; k++)
				{
					for (int l = 0; l < this.PosCloud[k].Length; l++)
					{
						bool isSmall = this.PosCloud[k][l].isSmall;
						if (isSmall)
						{
							this.PosCloud[k][l].f++;
							bool flag4 = this.PosCloud[k][l].f / 2 > 2;
							if (flag4)
							{
								this.PosCloud[k][l].isSmall = false;
								this.PosCloud[k][l].f = 4;
							}
						}
						else
						{
							bool flag5 = CRes.random(100) == 0;
							if (flag5)
							{
								this.PosCloud[k][l].frame = CRes.random(4) * 3;
								this.PosCloud[k][l].f = CRes.random(4);
								this.PosCloud[k][l].isSmall = true;
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x060008D8 RID: 2264 RVA: 0x000B81B0 File Offset: 0x000B63B0
	public void updateBoat()
	{
		bool flag = this.mPointObj == null;
		if (!flag)
		{
			this.mPointObj[0].x2 += this.mPointObj[0].vx;
			this.mPointObj[0].x = this.mPointObj[0].x2 / 100;
			bool flag2 = this.mPointObj[0].x < -100;
			if (flag2)
			{
				this.mPointObj[0].x2 = (MotherCanvas.w + 60 + CRes.random_Am_0(10)) * 100;
			}
			bool flag3 = CRes.random(40) == 0;
			if (flag3)
			{
				bool flag4 = CRes.random(2) == 0;
				if (flag4)
				{
					this.mPointObj[0].vy = 4;
				}
				else
				{
					this.mPointObj[0].vy = -4;
				}
			}
			bool flag5 = this.mPointObj[0].dis > 0 && this.mPointObj[0].vy > 0;
			if (flag5)
			{
				this.mPointObj[0].vy = -4;
			}
			else
			{
				bool flag6 = this.mPointObj[0].dis < -60 && this.mPointObj[0].vy < 0;
				if (flag6)
				{
					this.mPointObj[0].vy = 4;
				}
			}
			this.mPointObj[0].dis += this.mPointObj[0].vy;
		}
	}

	// Token: 0x060008D9 RID: 2265 RVA: 0x000B8320 File Offset: 0x000B6520
	public void addObj()
	{
		this.mPointObj = new Point[6];
		bool flag = MotherCanvas.w > 300;
		if (flag)
		{
			this.mPointObj = new Point[8];
		}
		this.mPointObj[0] = new Point(MotherCanvas.w - 40 + CRes.random_Am_0(20), MotherCanvas.h - 140 + CRes.random_Am_0(10));
		this.mPointObj[0].frame = 12;
		bool flag2 = GameCanvas.Day_Night == GameCanvas.DAY;
		if (flag2)
		{
			this.mPointObj[0].vx = -CRes.random(10, 30);
		}
		this.mPointObj[0].x2 = this.mPointObj[0].x * 100;
		this.mPointObj[1] = new Point(20 + CRes.random_Am_0(10), MotherCanvas.h - 25 + CRes.random_Am_0(10));
		this.mPointObj[1].frame = (int)(6 + GameCanvas.Day_Night * 4);
		this.mPointObj[2] = new Point(180 + CRes.random_Am_0(10), MotherCanvas.h - 8 + CRes.random_Am_0(10));
		this.mPointObj[2].frame = (int)(6 + GameCanvas.Day_Night * 4);
		this.mPointObj[3] = new Point(100 + CRes.random_Am_0(10), MotherCanvas.h - 30 + CRes.random_Am_0(10));
		this.mPointObj[3].frame = (int)(5 + GameCanvas.Day_Night * 4);
		this.mPointObj[4] = new Point(MotherCanvas.w - 25 + CRes.random_Am_0(10), MotherCanvas.h - 65 + CRes.random_Am_0(10));
		this.mPointObj[4].frame = 4;
		this.mPointObj[5] = new Point(20 + CRes.random_Am_0(10), MotherCanvas.h - 70 + CRes.random_Am_0(5));
		this.mPointObj[5].frame = 7;
		bool flag3 = MotherCanvas.w > 300;
		if (flag3)
		{
			this.mPointObj[6] = new Point(MotherCanvas.w / 2 + MotherCanvas.w / 3 + CRes.random_Am_0(10), MotherCanvas.h - 65 + CRes.random_Am_0(10));
			this.mPointObj[6].frame = 7;
			this.mPointObj[7] = new Point(MotherCanvas.w / 2 - MotherCanvas.w / 3 + CRes.random_Am_0(10), MotherCanvas.h - 70 + CRes.random_Am_0(5));
			this.mPointObj[7].frame = 4;
		}
	}

	// Token: 0x060008DA RID: 2266 RVA: 0x000B85A0 File Offset: 0x000B67A0
	public void setBGLoading()
	{
		this.lastMap = -1;
		this.indexBg = 0;
		this.color = 10343167;
		this.colorMini = 4367095;
		this.PosCloud = null;
		bool flag = GameCanvas.Day_Night == GameCanvas.DAY;
		if (flag)
		{
			this.imgSky = mImage.createImage("/bg/sky0.png");
			bool flag2 = MotherCanvas.h > 230;
			if (flag2)
			{
				this.PosCloud = new Point[3][];
				for (int i = 0; i < this.PosCloud.Length; i++)
				{
					int num = CRes.random(1, 3);
					this.PosCloud[i] = new Point[num];
					for (int j = 0; j < num; j++)
					{
						this.PosCloud[i][j] = new Point();
						this.PosCloud[i][j].x = CRes.random(MotherCanvas.w) * 100;
						this.PosCloud[i][j].y = MotherCanvas.h - 290 + 20 + i * 45 + CRes.random_Am_0(10) + ((i == 1) ? 5 : 0);
						this.PosCloud[i][j].vx = -CRes.random(100, 200) / (i * 4 + 1);
						this.PosCloud[i][j].frame = i % 3;
					}
				}
			}
		}
		else
		{
			this.imgSky = mImage.createImage("/bg/sky4.png");
			this.indexBg = 2;
			this.color = 4616312;
			this.colorMini = 3372977;
			this.PosCloud = new Point[1][];
			for (int k = 0; k < 1; k++)
			{
				int num2 = MotherCanvas.w / 14;
				this.PosCloud[k] = new Point[num2];
				for (int l = 0; l < num2; l++)
				{
					this.PosCloud[k][l] = new Point();
					this.PosCloud[k][l].x = l % 5 * MotherCanvas.w / 5 + MotherCanvas.w / 10 + CRes.random_Am_0(MotherCanvas.w / 10);
					int num3 = MotherCanvas.h - 230 + 55;
					bool flag3 = num3 <= 0;
					if (flag3)
					{
						num3 = 1;
					}
					this.PosCloud[k][l].y = MotherCanvas.h - (230 + CRes.random(num3)) + 55;
					this.PosCloud[k][l].frame = CRes.random(4) * 3;
					this.PosCloud[k][l].f = 4;
					this.PosCloud[k][l].isSmall = (CRes.random(100) == 0);
					bool isSmall = this.PosCloud[k][l].isSmall;
					if (isSmall)
					{
						this.PosCloud[k][l].f = CRes.random(4);
					}
				}
			}
		}
		this.mPointObj = new Point[1];
		this.mPointObj[0] = new Point(MotherCanvas.w - 40 + CRes.random_Am_0(20), MotherCanvas.h - 90 + CRes.random_Am_0(10));
		this.mPointObj[0].frame = 12;
		bool flag4 = GameCanvas.Day_Night == GameCanvas.DAY;
		if (flag4)
		{
			this.mPointObj[0].vx = -CRes.random(10, 30);
		}
		this.mPointObj[0].x2 = this.mPointObj[0].x * 100;
	}

	// Token: 0x060008DB RID: 2267 RVA: 0x000B8938 File Offset: 0x000B6B38
	public void paintBgLogin(mGraphics g)
	{
		g.setColor(this.color);
		g.fillRect(0, 0, MotherCanvas.w, MotherCanvas.h);
		bool flag = this.imgBgLogin == null;
		if (flag)
		{
			this.loadBGLogin();
		}
		else
		{
			bool flag2 = this.imgSky != null;
			if (flag2)
			{
				for (int i = 0; i < MotherCanvas.w; i += 20)
				{
					g.drawImage(this.imgSky, i, MotherCanvas.h - 160 - 115, 0);
				}
			}
			for (int j = 0; j < MotherCanvas.w; j += 96)
			{
				g.drawImage(this.imgBgLogin[(int)(1 + this.indexBg)], j, MotherCanvas.h - 191 - 82 + 34, 0);
			}
			for (int k = 0; k < MotherCanvas.w; k += 48)
			{
				g.drawImage(this.imgBgLogin[(int)this.indexBg], k, MotherCanvas.h - 191, 0);
			}
			for (int l = 0; l < MotherCanvas.w; l += 24)
			{
				g.drawRegion(this.imgSeaLogin[0], 0, GameCanvas.gameTick / 8 % 2 * 24, 24, 24, 0, (float)l, (float)(MotherCanvas.h - 191), 0);
			}
			bool flag3 = GameCanvas.Day_Night == GameCanvas.DAY;
			if (flag3)
			{
				this.paintCloudLogin(g);
			}
			else
			{
				this.paintStarLogin(g);
			}
		}
	}

	// Token: 0x060008DC RID: 2268 RVA: 0x000B8AC0 File Offset: 0x000B6CC0
	public void paintBgLoading(mGraphics g)
	{
		g.setColor(this.color);
		g.fillRect(0, 0, MotherCanvas.w, MotherCanvas.h);
		bool flag = this.imgSky != null;
		if (flag)
		{
			for (int i = 0; i < MotherCanvas.w; i += 20)
			{
				g.drawImage(this.imgSky, i, MotherCanvas.h - 100 - 115, 0);
			}
		}
		bool flag2 = this.imgBgLogin == null || this.imgSeaLogin == null;
		if (flag2)
		{
			this.loadBGLogin();
		}
		else
		{
			g.setColor(this.colorMini);
			g.fillRect(0, MotherCanvas.h - 140, MotherCanvas.w, 140);
			for (int j = 0; j < MotherCanvas.w; j += 48)
			{
				g.drawRegion(this.imgBgLogin[(int)this.indexBg], 0, 10, 48, 85, 0, (float)j, (float)(MotherCanvas.h - 191 + 90), 0);
			}
			for (int k = 0; k < MotherCanvas.w; k += 96)
			{
				g.drawRegion(this.imgBgLogin[(int)(1 + this.indexBg)], 0, 0, 96, 48, 0, (float)k, (float)(MotherCanvas.h - 191 - 82 + 34 + 55), 0);
			}
			for (int l = 0; l < MotherCanvas.w; l += 24)
			{
				g.drawRegion(this.imgSeaLogin[0], 0, GameCanvas.gameTick / 8 % 2 * 24, 24, 20, 0, (float)l, (float)(MotherCanvas.h - 191 + 55), 0);
			}
			bool flag3 = GameCanvas.Day_Night == GameCanvas.DAY;
			if (flag3)
			{
				this.paintCloudLogin(g);
			}
			else
			{
				this.paintStarLogin(g);
			}
		}
	}

	// Token: 0x060008DD RID: 2269 RVA: 0x000B8C98 File Offset: 0x000B6E98
	public void paintObjLastLogin(mGraphics g)
	{
		bool flag = this.imgBgLogin == null;
		if (flag)
		{
			this.loadBGLogin();
		}
		else
		{
			for (int i = 4; i < this.mPointObj.Length; i++)
			{
				bool flag2 = i != 0;
				if (flag2)
				{
					g.drawImage(this.imgBgLogin[this.mPointObj[i].frame], this.mPointObj[i].x, this.mPointObj[i].y, 33);
				}
			}
		}
	}

	// Token: 0x060008DE RID: 2270 RVA: 0x000B8D18 File Offset: 0x000B6F18
	public void paintObjFristLogin(mGraphics g)
	{
		bool flag = this.imgBgLogin == null;
		if (flag)
		{
			this.loadBGLogin();
		}
		else
		{
			for (int i = 0; i < 4; i++)
			{
				bool flag2 = i != 0;
				if (flag2)
				{
					g.drawImage(this.imgBgLogin[this.mPointObj[i].frame], this.mPointObj[i].x, this.mPointObj[i].y, 33);
				}
			}
		}
	}

	// Token: 0x060008DF RID: 2271 RVA: 0x000B8D90 File Offset: 0x000B6F90
	public void paintObjLoading(mGraphics g)
	{
		bool flag = this.imgBgLogin == null;
		if (flag)
		{
			this.loadBGLogin();
		}
		else
		{
			for (int i = 0; i < this.mPointObj.Length; i++)
			{
				bool flag2 = i == 0;
				if (!flag2)
				{
					g.drawRegion(this.imgBgLogin[this.mPointObj[i].frame], 0, 0, 90, 74 + this.mPointObj[i].dis / 24, 0, (float)this.mPointObj[i].x, (float)this.mPointObj[i].y, 33);
					bool flag3 = i == 0 && !GameCanvas.isLowGraOrWP_PvP();
					if (flag3)
					{
						bool flag4 = GameCanvas.Day_Night == GameCanvas.DAY;
						if (flag4)
						{
							g.drawRegion(Boat.imgEffSea, 0, 12 * (GameCanvas.gameTick / 8 % 2), 78, 12, 0, (float)this.mPointObj[i].x, (float)(this.mPointObj[i].y + 8), 33);
						}
						else
						{
							g.drawRegion(Boat.imgEffSea2, 0, 12 * (GameCanvas.gameTick / 8 % 2), 78, 12, 0, (float)this.mPointObj[i].x, (float)(this.mPointObj[i].y + 8), 33);
						}
					}
				}
			}
		}
	}

	// Token: 0x060008E0 RID: 2272 RVA: 0x000B8EE4 File Offset: 0x000B70E4
	private void paintStarLogin(mGraphics g)
	{
		bool flag = this.fraStar == null;
		if (flag)
		{
			this.loadImgStar();
		}
		else
		{
			bool flag2 = this.PosCloud == null;
			if (!flag2)
			{
				for (int i = 0; i < this.PosCloud.Length; i++)
				{
					for (int j = 0; j < this.PosCloud[i].Length; j++)
					{
						this.fraStar.drawFrame(this.PosCloud[i][j].frame + this.PosCloud[i][j].f / 2, this.PosCloud[i][j].x, this.PosCloud[i][j].y, 0, 3, g);
					}
				}
			}
		}
	}

	// Token: 0x060008E1 RID: 2273 RVA: 0x0000AF20 File Offset: 0x00009120
	private void loadImgStar()
	{
		this.fraStar = new FrameImage(mImage.createImage("/bg/star.png"), 5, 5);
	}

	// Token: 0x060008E2 RID: 2274 RVA: 0x000B8FAC File Offset: 0x000B71AC
	public void paintCloudLogin(mGraphics g)
	{
		try
		{
			bool flag = this.mImgCloud == null;
			if (flag)
			{
				this.loadImgCloud(true);
			}
			else
			{
				bool flag2 = this.PosCloud == null;
				if (!flag2)
				{
					for (int i = 0; i < this.PosCloud.Length; i++)
					{
						for (int j = 0; j < this.PosCloud[i].Length; j++)
						{
							g.drawImage(this.mImgCloud[this.PosCloud[i][j].frame], this.PosCloud[i][j].x / 100, this.PosCloud[i][j].y, 3);
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x060008E3 RID: 2275 RVA: 0x000B907C File Offset: 0x000B727C
	private void loadBGLogin()
	{
		bool flag = this.imgBgLogin == null || this.imgSeaLogin == null;
		if (flag)
		{
			this.imgBgLogin = new mImage[11];
			for (int i = 0; i < this.imgBgLogin.Length; i++)
			{
				bool flag2 = i != 8 && (GameCanvas.Day_Night != GameCanvas.NIGHT || (i != 0 && i != 1 && i != 5 && i != 6)) && (GameCanvas.Day_Night != GameCanvas.DAY || (i != 2 && i != 3 && i != 9 && i != 10));
				if (flag2)
				{
					this.imgBgLogin[i] = mImage.createImage("/bg/login" + i.ToString() + ".png");
				}
			}
			this.imgSeaLogin = new mImage[1];
			bool flag3 = GameCanvas.Day_Night == GameCanvas.DAY;
			if (flag3)
			{
				this.imgSeaLogin[0] = mImage.createImage("/bg/sea0.png");
				this.imgSky = mImage.createImage("/bg/sky0.png");
			}
			else
			{
				this.imgSeaLogin[0] = mImage.createImage("/bg/sea3.png");
				this.imgSky = mImage.createImage("/bg/sky4.png");
			}
		}
		bool flag4 = this.lastMap == 28 || this.lastMap == 29 || this.lastMap == 30 || this.lastMap == 31 || this.lastMap == 42;
		if (flag4)
		{
			this.mImgCloud = null;
		}
	}

	// Token: 0x060008E4 RID: 2276 RVA: 0x000B91F0 File Offset: 0x000B73F0
	public void setSkySnow()
	{
		bool flag = GameCanvas.loadmap.idMap != 69 && GameCanvas.loadmap.idMap != 113;
		if (flag)
		{
			this.imgSky = mImage.createImage("/bg/sky6.png");
			this.color = 10668525;
		}
	}

	// Token: 0x060008E5 RID: 2277 RVA: 0x000B9244 File Offset: 0x000B7444
	public void setSkyDragon()
	{
		bool flag = this.typeMap != 1 && this.typeMap != 18 && this.typeMap != 16 && this.typeMap != 35 && this.typeMap != 33 && this.typeMap != 63 && GameCanvas.loadmap.idMap != 113;
		if (flag)
		{
			this.color = 7839938;
			this.imgSky = mImage.createImage("/bg/sky10.png");
		}
		int num = MotherCanvas.w / 150 + 1;
		bool flag2 = num > 3;
		if (flag2)
		{
			num = 3;
		}
		for (int i = 0; i < num; i++)
		{
			Point point = new Point(CRes.random(0, MotherCanvas.w), -CRes.random(40));
			point.dis = CRes.random(2) * 2;
			point.fRe = CRes.random(100, 200);
			point.f = CRes.random(100);
			this.mVecThunder.addElement(point);
		}
		bool flag3 = this.imgThunder == null;
		if (flag3)
		{
			this.imgThunder = mImage.createImage("/bg/thunder.png");
		}
		this.loadImgCloud(false);
		MapBackGround.tickRanThunder = 10;
	}

	// Token: 0x060008E6 RID: 2278 RVA: 0x000B9378 File Offset: 0x000B7578
	public void setDark()
	{
		this.color = 2635073;
		this.imgSky = mImage.createImage("/bg/sky11.png");
		this.mImgCloud = new mImage[3];
		for (int i = 0; i < this.mImgCloud.Length; i++)
		{
			bool flag = GameScreen.effMap != null;
			if (flag)
			{
				this.mImgCloud[i] = mImage.createImage("/bg/cloud1" + i.ToString() + ".png");
				MapBackGround.IndexCloud = 1;
			}
		}
	}

	// Token: 0x060008E7 RID: 2279 RVA: 0x000B9400 File Offset: 0x000B7600
	public MapBackGround()
	{
		short[][] array = new short[3][];
		int num = 0;
		short[] array2 = new short[3];
		array2[0] = 2;
		array2[1] = 100;
		array[num] = array2;
		int num2 = 1;
		short[] array3 = new short[3];
		array3[0] = 3;
		array3[1] = 160;
		array[num2] = array3;
		int num3 = 2;
		short[] array4 = new short[3];
		array4[0] = 3;
		array4[1] = 280;
		array[num3] = array4;
		this.PosObj12 = array;
		this.PosObj13 = new short[][]
		{
			new short[]
			{
				2,
				40,
				10
			},
			new short[]
			{
				3,
				80,
				3
			},
			new short[]
			{
				3,
				180,
				1
			},
			new short[]
			{
				2,
				300,
				14
			}
		};
		short[][] array5 = new short[7][];
		int num4 = 0;
		short[] array6 = new short[3];
		array6[0] = 3;
		array6[1] = 80;
		array5[num4] = array6;
		int num5 = 1;
		short[] array7 = new short[3];
		array7[0] = 2;
		array7[1] = 140;
		array5[num5] = array7;
		int num6 = 2;
		short[] array8 = new short[3];
		array8[0] = 2;
		array8[1] = 260;
		array5[num6] = array8;
		array5[3] = new short[]
		{
			4,
			70,
			8
		};
		array5[4] = new short[]
		{
			5,
			20,
			1
		};
		array5[5] = new short[]
		{
			5,
			230,
			4
		};
		array5[6] = new short[]
		{
			4,
			290,
			10
		};
		this.PosObj14 = array5;
		this.PosObj15 = new short[][]
		{
			new short[]
			{
				1,
				0,
				47
			},
			new short[]
			{
				2,
				26,
				56
			},
			new short[]
			{
				3,
				62,
				75
			},
			new short[]
			{
				2,
				110,
				56
			},
			new short[]
			{
				1,
				144,
				47
			}
		};
		this.PosObj16 = new short[][]
		{
			new short[]
			{
				0,
				10,
				47
			},
			new short[]
			{
				0,
				45,
				50
			},
			new short[]
			{
				0,
				105,
				54
			},
			new short[]
			{
				0,
				120,
				57
			},
			new short[]
			{
				0,
				180,
				52
			},
			new short[]
			{
				0,
				210,
				48
			},
			new short[]
			{
				0,
				230,
				47
			},
			new short[]
			{
				0,
				280,
				50
			},
			new short[]
			{
				0,
				310,
				52
			},
			new short[]
			{
				0,
				30,
				32
			},
			new short[]
			{
				0,
				140,
				27
			},
			new short[]
			{
				0,
				205,
				30
			},
			new short[]
			{
				0,
				270,
				33
			}
		};
		this.PosObj17 = new short[][]
		{
			new short[]
			{
				2,
				0,
				-50,
				-180
			},
			new short[]
			{
				2,
				0,
				280,
				-210
			},
			new short[]
			{
				2,
				2,
				200,
				-200
			},
			new short[]
			{
				2,
				2,
				105,
				-175
			},
			new short[]
			{
				3,
				2,
				170,
				-125
			},
			new short[]
			{
				3,
				2,
				20,
				-240
			},
			new short[]
			{
				3,
				2,
				35,
				-75
			},
			new short[]
			{
				3,
				2,
				260,
				-95
			},
			new short[]
			{
				5,
				0,
				20,
				-235
			},
			new short[]
			{
				3,
				0,
				20,
				-200
			},
			new short[]
			{
				5,
				0,
				-60,
				-150
			},
			new short[]
			{
				0,
				0,
				110,
				-174
			},
			new short[]
			{
				1,
				2,
				16,
				-51
			},
			new short[]
			{
				1,
				2,
				-190,
				-54
			},
			new short[]
			{
				1,
				0,
				270,
				-56
			},
			new short[]
			{
				3,
				0,
				-339,
				-170
			},
			new short[]
			{
				4,
				0,
				-188,
				-157
			},
			new short[]
			{
				3,
				2,
				-65,
				-115
			},
			new short[]
			{
				4,
				2,
				105,
				-130
			},
			new short[]
			{
				4,
				0,
				260,
				-164
			},
			new short[]
			{
				4,
				0,
				300,
				-260
			},
			new short[]
			{
				4,
				0,
				200,
				-255
			}
		};
		short[][] array9 = new short[17][];
		array9[0] = new short[]
		{
			0,
			0,
			-127,
			-165
		};
		array9[1] = new short[]
		{
			2,
			0,
			20,
			-115
		};
		array9[2] = new short[]
		{
			4,
			0,
			25,
			-80
		};
		array9[3] = new short[]
		{
			2,
			2,
			260,
			-135
		};
		array9[4] = new short[]
		{
			3,
			2,
			262,
			-105
		};
		array9[5] = new short[]
		{
			4,
			2,
			222,
			-185
		};
		array9[6] = new short[]
		{
			4,
			0,
			160,
			-65
		};
		array9[7] = new short[]
		{
			4,
			0,
			-110,
			-45
		};
		array9[8] = new short[]
		{
			4,
			0,
			-80,
			-165
		};
		array9[9] = new short[]
		{
			5,
			2,
			56,
			-195
		};
		array9[10] = new short[]
		{
			0,
			2,
			192,
			-129
		};
		int num7 = 11;
		short[] array10 = new short[4];
		array10[0] = 1;
		array10[2] = -120;
		array9[num7] = array10;
		array9[12] = new short[]
		{
			1,
			2,
			110,
			0
		};
		array9[13] = new short[]
		{
			3,
			2,
			192,
			-95
		};
		array9[14] = new short[]
		{
			3,
			0,
			56,
			-160
		};
		array9[15] = new short[]
		{
			3,
			0,
			-127,
			-130
		};
		array9[16] = new short[]
		{
			4,
			2,
			-212,
			-75
		};
		this.PosObj18 = array9;
		this.PosObj19 = new short[][]
		{
			new short[]
			{
				5,
				0,
				-30,
				-12
			},
			new short[]
			{
				0,
				0,
				30,
				-10
			},
			new short[]
			{
				5,
				2,
				52,
				-195
			},
			new short[]
			{
				3,
				2,
				52,
				-160
			},
			new short[]
			{
				0,
				2,
				72,
				-120
			},
			new short[]
			{
				0,
				0,
				-106,
				-133
			},
			new short[]
			{
				2,
				0,
				-139,
				-190
			},
			new short[]
			{
				5,
				0,
				-180,
				-193
			},
			new short[]
			{
				3,
				0,
				72,
				-85
			},
			new short[]
			{
				3,
				0,
				-106,
				-100
			},
			new short[]
			{
				3,
				0,
				-180,
				-160
			},
			new short[]
			{
				2,
				2,
				190,
				-160
			},
			new short[]
			{
				4,
				0,
				200,
				-120
			},
			new short[]
			{
				3,
				0,
				180,
				-205
			},
			new short[]
			{
				3,
				0,
				-100,
				-205
			}
		};
		this.PosObj21 = new short[][]
		{
			new short[]
			{
				20,
				-42,
				1,
				0
			},
			new short[]
			{
				-24,
				-79,
				0,
				1
			},
			new short[]
			{
				-14,
				-167,
				3,
				1
			},
			new short[]
			{
				26,
				-178,
				2,
				0
			},
			new short[]
			{
				16,
				-115,
				1,
				1
			}
		};
		this.PosObj22 = new short[][]
		{
			new short[]
			{
				120,
				10,
				3
			},
			new short[]
			{
				250,
				-5,
				4
			},
			new short[]
			{
				380,
				3,
				3
			},
			new short[]
			{
				500,
				-10,
				3
			},
			new short[]
			{
				630,
				5,
				4
			},
			new short[]
			{
				750,
				8,
				3
			},
			new short[]
			{
				900,
				0,
				4
			}
		};
		this.PosObj23 = new short[][]
		{
			new short[]
			{
				60,
				5,
				5
			},
			new short[]
			{
				190,
				0,
				6
			},
			new short[]
			{
				320,
				-5,
				5
			},
			new short[]
			{
				450,
				3,
				6
			}
		};
		this.PosObj24 = new short[][]
		{
			new short[]
			{
				30,
				0,
				8
			},
			new short[]
			{
				110,
				-5,
				7
			},
			new short[]
			{
				200,
				5,
				7
			},
			new short[]
			{
				300,
				3,
				8
			}
		};
		this.PosObj25 = new short[][]
		{
			new short[]
			{
				0,
				2,
				52,
				-160
			},
			new short[]
			{
				0,
				0,
				72,
				-85
			},
			new short[]
			{
				1,
				0,
				-106,
				-100
			},
			new short[]
			{
				0,
				0,
				-180,
				-160
			},
			new short[]
			{
				1,
				0,
				200,
				-120
			},
			new short[]
			{
				0,
				0,
				180,
				-205
			},
			new short[]
			{
				1,
				0,
				-100,
				-205
			}
		};
		short[][][] array11 = new short[4][][];
		array11[0] = new short[][]
		{
			new short[]
			{
				73,
				16
			},
			new short[]
			{
				55,
				13
			},
			new short[]
			{
				28,
				9
			},
			new short[]
			{
				49,
				3
			},
			new short[]
			{
				40,
				1
			},
			new short[]
			{
				64,
				-2
			}
		};
		int num8 = 1;
		short[][] array12 = new short[5][];
		array12[0] = new short[]
		{
			53,
			17
		};
		array12[1] = new short[]
		{
			80,
			13
		};
		array12[2] = new short[]
		{
			57,
			4
		};
		array12[3] = new short[]
		{
			64,
			3
		};
		int num9 = 4;
		short[] array13 = new short[2];
		array13[0] = 33;
		array12[num9] = array13;
		array11[num8] = array12;
		array11[2] = new short[][]
		{
			new short[]
			{
				23,
				16
			},
			new short[]
			{
				65,
				15
			},
			new short[]
			{
				48,
				7
			},
			new short[]
			{
				77,
				-3
			}
		};
		int num10 = 3;
		short[][] array14 = new short[5][];
		array14[0] = new short[]
		{
			77,
			5
		};
		array14[1] = new short[]
		{
			55,
			4
		};
		array14[2] = new short[]
		{
			28,
			1
		};
		int num11 = 3;
		short[] array15 = new short[2];
		array15[0] = 43;
		array14[num11] = array15;
		array14[4] = new short[]
		{
			62,
			-2
		};
		array11[num10] = array14;
		this.posKhanGia = array11;
		this.PosObj20 = new short[]
		{
			16,
			30,
			40,
			65,
			76,
			84,
			98,
			108
		};
		this.lastMap = -1;
		base..ctor();
	}

	// Token: 0x04000DD3 RID: 3539
	private const sbyte IDBACK_0 = 0;

	// Token: 0x04000DD4 RID: 3540
	private const sbyte IDBACK_1 = 1;

	// Token: 0x04000DD5 RID: 3541
	private const sbyte IDBACK_2 = 2;

	// Token: 0x04000DD6 RID: 3542
	private const sbyte IDBACK_3 = 3;

	// Token: 0x04000DD7 RID: 3543
	private const sbyte IDBACK_4 = 4;

	// Token: 0x04000DD8 RID: 3544
	private const sbyte IDBACK_5 = 5;

	// Token: 0x04000DD9 RID: 3545
	private const sbyte IDBACK_6 = 6;

	// Token: 0x04000DDA RID: 3546
	private const sbyte IDBACK_7 = 7;

	// Token: 0x04000DDB RID: 3547
	private const sbyte IDBACK_8 = 8;

	// Token: 0x04000DDC RID: 3548
	private const sbyte IDBACK_9 = 9;

	// Token: 0x04000DDD RID: 3549
	private const sbyte IDBACK_10 = 10;

	// Token: 0x04000DDE RID: 3550
	private const sbyte IDBACK_11 = 11;

	// Token: 0x04000DDF RID: 3551
	private const sbyte IDBACK_12 = 12;

	// Token: 0x04000DE0 RID: 3552
	private const sbyte IDBACK_13 = 13;

	// Token: 0x04000DE1 RID: 3553
	private const sbyte IDBACK_14 = 14;

	// Token: 0x04000DE2 RID: 3554
	private const sbyte IDBACK_15 = 15;

	// Token: 0x04000DE3 RID: 3555
	private const sbyte IDBACK_16 = 16;

	// Token: 0x04000DE4 RID: 3556
	private const sbyte IDBACK_17 = 17;

	// Token: 0x04000DE5 RID: 3557
	private const sbyte IDBACK_18 = 18;

	// Token: 0x04000DE6 RID: 3558
	private const sbyte IDBACK_19 = 19;

	// Token: 0x04000DE7 RID: 3559
	private const sbyte IDBACK_20 = 20;

	// Token: 0x04000DE8 RID: 3560
	private const sbyte IDBACK_21 = 21;

	// Token: 0x04000DE9 RID: 3561
	private const sbyte IDBACK_22 = 22;

	// Token: 0x04000DEA RID: 3562
	private const sbyte IDBACK_23 = 23;

	// Token: 0x04000DEB RID: 3563
	private const sbyte IDBACK_24 = 24;

	// Token: 0x04000DEC RID: 3564
	private const sbyte IDBACK_25 = 25;

	// Token: 0x04000DED RID: 3565
	private const sbyte IDBACK_26 = 26;

	// Token: 0x04000DEE RID: 3566
	private const sbyte IDBACK_27 = 27;

	// Token: 0x04000DEF RID: 3567
	private const sbyte IDBACK_28 = 28;

	// Token: 0x04000DF0 RID: 3568
	private const sbyte IDBACK_29 = 29;

	// Token: 0x04000DF1 RID: 3569
	private const sbyte IDBACK_30 = 30;

	// Token: 0x04000DF2 RID: 3570
	private const sbyte IDBACK_31 = 31;

	// Token: 0x04000DF3 RID: 3571
	private const sbyte IDBACK_32 = 32;

	// Token: 0x04000DF4 RID: 3572
	private const sbyte IDBACK_33 = 33;

	// Token: 0x04000DF5 RID: 3573
	private const sbyte IDBACK_34 = 34;

	// Token: 0x04000DF6 RID: 3574
	private const sbyte IDBACK_35 = 35;

	// Token: 0x04000DF7 RID: 3575
	private const sbyte IDBACK_36 = 36;

	// Token: 0x04000DF8 RID: 3576
	private const sbyte IDBACK_37 = 37;

	// Token: 0x04000DF9 RID: 3577
	private const sbyte IDBACK_38 = 38;

	// Token: 0x04000DFA RID: 3578
	private const sbyte IDBACK_39 = 39;

	// Token: 0x04000DFB RID: 3579
	private const sbyte IDBACK_40 = 40;

	// Token: 0x04000DFC RID: 3580
	private const sbyte IDBACK_41 = 41;

	// Token: 0x04000DFD RID: 3581
	private const sbyte IDBACK_42 = 42;

	// Token: 0x04000DFE RID: 3582
	private const sbyte IDBACK_43 = 43;

	// Token: 0x04000DFF RID: 3583
	private const sbyte IDBACK_44 = 44;

	// Token: 0x04000E00 RID: 3584
	private const sbyte IDBACK_45 = 45;

	// Token: 0x04000E01 RID: 3585
	private const sbyte IDBACK_46 = 46;

	// Token: 0x04000E02 RID: 3586
	private const sbyte IDBACK_47 = 47;

	// Token: 0x04000E03 RID: 3587
	private const sbyte IDBACK_51 = 51;

	// Token: 0x04000E04 RID: 3588
	private const sbyte IDBACK_53 = 53;

	// Token: 0x04000E05 RID: 3589
	private const sbyte IDBACK_55 = 55;

	// Token: 0x04000E06 RID: 3590
	private const sbyte IDBACK_60 = 60;

	// Token: 0x04000E07 RID: 3591
	private const sbyte IDBACK_61 = 61;

	// Token: 0x04000E08 RID: 3592
	private const sbyte IDBACK_62 = 62;

	// Token: 0x04000E09 RID: 3593
	private const sbyte IDBACK_63 = 63;

	// Token: 0x04000E0A RID: 3594
	private sbyte typeMap;

	// Token: 0x04000E0B RID: 3595
	private sbyte[] mList3;

	// Token: 0x04000E0C RID: 3596
	private int[] mHImg;

	// Token: 0x04000E0D RID: 3597
	private int[] mWImg;

	// Token: 0x04000E0E RID: 3598
	private int[] mSpeedImg;

	// Token: 0x04000E0F RID: 3599
	private int[] mHBegin;

	// Token: 0x04000E10 RID: 3600
	private int maxsize;

	// Token: 0x04000E11 RID: 3601
	private int sizeScreen;

	// Token: 0x04000E12 RID: 3602
	private int hLimit;

	// Token: 0x04000E13 RID: 3603
	private int valueMyRandom;

	// Token: 0x04000E14 RID: 3604
	private int sizeScreen2;

	// Token: 0x04000E15 RID: 3605
	private int nX;

	// Token: 0x04000E16 RID: 3606
	private int hEff;

	// Token: 0x04000E17 RID: 3607
	private int valueTick = 3;

	// Token: 0x04000E18 RID: 3608
	private int valueEndTurn = 150;

	// Token: 0x04000E19 RID: 3609
	private int yplusCloud;

	// Token: 0x04000E1A RID: 3610
	private int hSky;

	// Token: 0x04000E1B RID: 3611
	public int hBack;

	// Token: 0x04000E1C RID: 3612
	public bool isEff;

	// Token: 0x04000E1D RID: 3613
	public bool isEffKhangia;

	// Token: 0x04000E1E RID: 3614
	public bool isNight;

	// Token: 0x04000E1F RID: 3615
	public static bool isBeginVyCloud;

	// Token: 0x04000E20 RID: 3616
	private mVector mVecKhangia = new mVector("MapBackGround.mvecKhangia");

	// Token: 0x04000E21 RID: 3617
	private mVector mVecThunder = new mVector();

	// Token: 0x04000E22 RID: 3618
	private Point[][] PosCloud;

	// Token: 0x04000E23 RID: 3619
	private Point laboon;

	// Token: 0x04000E24 RID: 3620
	private short[][] PosObj12;

	// Token: 0x04000E25 RID: 3621
	private short[][] PosObj13;

	// Token: 0x04000E26 RID: 3622
	private short[][] PosObj14;

	// Token: 0x04000E27 RID: 3623
	private short[][] PosObj15;

	// Token: 0x04000E28 RID: 3624
	private short[][] PosObj16;

	// Token: 0x04000E29 RID: 3625
	private short[][] PosObj17;

	// Token: 0x04000E2A RID: 3626
	private short[][] PosObj18;

	// Token: 0x04000E2B RID: 3627
	private short[][] PosObj19;

	// Token: 0x04000E2C RID: 3628
	private short[][] PosObj21;

	// Token: 0x04000E2D RID: 3629
	private short[][] PosObj22;

	// Token: 0x04000E2E RID: 3630
	private short[][] PosObj23;

	// Token: 0x04000E2F RID: 3631
	private short[][] PosObj24;

	// Token: 0x04000E30 RID: 3632
	private short[][] PosObj25;

	// Token: 0x04000E31 RID: 3633
	private short[][] PosObj;

	// Token: 0x04000E32 RID: 3634
	private short[][] PosObj2;

	// Token: 0x04000E33 RID: 3635
	private short[][][] posKhanGia;

	// Token: 0x04000E34 RID: 3636
	private short[] PosObj20;

	// Token: 0x04000E35 RID: 3637
	private mImage[] mImg;

	// Token: 0x04000E36 RID: 3638
	private mImage[] mImgCloud;

	// Token: 0x04000E37 RID: 3639
	private mImage[] imgBgLogin;

	// Token: 0x04000E38 RID: 3640
	private mImage[] imgSeaLogin;

	// Token: 0x04000E39 RID: 3641
	private mImage[] mImgCloudNight;

	// Token: 0x04000E3A RID: 3642
	private mImage[] mBigNPC;

	// Token: 0x04000E3B RID: 3643
	private mImage imgSpec;

	// Token: 0x04000E3C RID: 3644
	private mImage imgSky;

	// Token: 0x04000E3D RID: 3645
	private mImage imgThunder;

	// Token: 0x04000E3E RID: 3646
	private FrameImage fraStar;

	// Token: 0x04000E3F RID: 3647
	private FrameImage fraImgNew;

	// Token: 0x04000E40 RID: 3648
	public int color;

	// Token: 0x04000E41 RID: 3649
	public int colorMini;

	// Token: 0x04000E42 RID: 3650
	public sbyte lastMap;

	// Token: 0x04000E43 RID: 3651
	public static FrameImage fraChong;

	// Token: 0x04000E44 RID: 3652
	public static FrameImage fraChongNho;

	// Token: 0x04000E45 RID: 3653
	public static FrameImage fraWater7;

	// Token: 0x04000E46 RID: 3654
	public Point[] posXuongRong;

	// Token: 0x04000E47 RID: 3655
	public Point[] posXuongRong2;

	// Token: 0x04000E48 RID: 3656
	public int xCamOffline;

	// Token: 0x04000E49 RID: 3657
	private int yeff;

	// Token: 0x04000E4A RID: 3658
	public static int tickRanThunder = 10;

	// Token: 0x04000E4B RID: 3659
	public static int IndexCloud;

	// Token: 0x04000E4C RID: 3660
	private sbyte indexBg;

	// Token: 0x04000E4D RID: 3661
	private Point[] mPointObj;
}
