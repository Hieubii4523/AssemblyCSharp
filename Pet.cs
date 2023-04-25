using System;

// Token: 0x020000CA RID: 202
public class Pet : MainMonster
{
	// Token: 0x06000B8B RID: 2955 RVA: 0x0000B8EA File Offset: 0x00009AEA
	public Pet(short ID, short idMain, short idImage, sbyte type) : base(ID, idMain, idImage, type)
	{
		this.IDMainShiper = idMain;
		this.setDataPet(ID, idImage, type);
	}

	// Token: 0x06000B8C RID: 2956 RVA: 0x000DD8B8 File Offset: 0x000DBAB8
	public override void setDataPet(short ID, short idImage, sbyte type)
	{
		this.ID = ID;
		this.typePet = type;
		this.IdIcon = idImage;
		this.wOne = (this.hOne = -1);
		this.colorName = 5;
		this.objMainFocus = MainObject.get_Object((int)this.IDMainShiper, 0);
		bool flag = this.objMainFocus != null;
		if (flag)
		{
			this.setInfoObjMain();
		}
		this.f = 0;
		this.typeObject = 10;
		this.Action = 0;
		base.setSpeed(5, 5);
		this.typeShadow = 1;
		this.dyMovePet = 0;
		sbyte typePet = this.typePet;
		sbyte b = typePet;
		switch (b)
		{
		case 0:
			this.mActionMonSter = Pet.mChoper;
			this.mActionStandMonSter = Pet.mPlayStandChopper;
			this.nFrame = 9;
			break;
		case 1:
			this.mActionMonSter = MonsterWalk.mMonKungfu;
			this.mActionStandMonSter = MonsterWalk.mMonKungfu[0];
			this.nFrame = 9;
			break;
		case 2:
			this.mActionMonSter = Pet.mLasso;
			this.mActionStandMonSter = Pet.mLasso[0];
			this.nFrame = 5;
			break;
		case 3:
		case 5:
			this.mActionMonSter = Pet.mGhost;
			this.mActionStandMonSter = Pet.mGhost[0];
			this.nFrame = 6;
			base.setSpeed(3, 3);
			this.dyMain = 10;
			this.typeShadow = -1;
			this.dyMovePet = 10;
			break;
		case 4:
			this.mActionMonSter = Pet.mBat;
			this.mActionStandMonSter = Pet.mBat[0];
			this.nFrame = 3;
			this.dyMain = 20;
			this.dyMovePet = 15;
			break;
		default:
			if (b == 21)
			{
				base.setSpeed(6, 6);
				this.mActionMonSter = Pet.mDog;
				this.mActionStandMonSter = Pet.mDog[0];
				bool flag2 = this.IdIcon == 55 || this.IdIcon == 56;
				if (flag2)
				{
					this.nFrame = 7;
					this.mActionStandMonSter = Pet.mPlayStandDogVip;
					bool flag3 = this.IdIcon == 56;
					if (flag3)
					{
						this.typeShadow = 0;
					}
				}
				else
				{
					this.nFrame = 5;
				}
			}
			break;
		}
	}

	// Token: 0x06000B8D RID: 2957 RVA: 0x000DDAD8 File Offset: 0x000DBCD8
	public override void paint(mGraphics g)
	{
		MainImage imageAll = ObjectData.getImageAll(this.IdIcon, ObjectData.HashImageMonster, 1000);
		bool flag = LoadMap.specMap != 4 && this.typeShadow >= 0;
		if (flag)
		{
			this.paintShadowMonster(g, this.x, -3, (int)this.typeShadow);
		}
		bool flag2 = this.objMainFocus == null || (LoadMap.specMap == 4 && this.objMainFocus.Action == 4);
		if (!flag2)
		{
			int num = this.Action;
			bool flag3 = num > this.mActionMonSter.Length - 1;
			if (flag3)
			{
				num = 0;
			}
			bool flag4 = this.isPlayStand && this.Action == 0;
			if (flag4)
			{
				bool flag5 = this.f > this.mActionStandMonSter.Length - 1;
				if (flag5)
				{
					this.f = 0;
				}
			}
			else
			{
				bool flag6 = this.f > this.mActionMonSter[num].Length - 1;
				if (flag6)
				{
					this.f = 0;
				}
			}
			bool flag7 = imageAll.img != null;
			if (flag7)
			{
				bool flag8 = this.wOne < 0;
				if (flag8)
				{
					this.hOne = mImage.getImageHeight(imageAll.img.image) / this.nFrame;
					this.wOne = mImage.getImageWidth(imageAll.img.image);
				}
				int num2 = (!this.isPlayStand || this.Action != 0) ? this.mActionMonSter[num][this.f] : this.mActionStandMonSter[this.f];
				bool flag9 = this.Action != 4;
				if (flag9)
				{
					g.drawRegion(imageAll.img, 0, num2 * this.hOne, this.wOne, this.hOne, (this.Dir == 2) ? 2 : 0, (float)this.x, (float)(this.y - this.dyMain - this.objMainFocus.dySea / 10), mGraphics.BOTTOM | mGraphics.HCENTER);
				}
			}
			bool flag10 = LoadMap.specMap != 4;
			if (flag10)
			{
				AvMain.FontBorderSmall(g, this.objMainFocus.name, this.x, this.y - this.dyMain - 1 - this.hOne - 10, 2, (int)this.colorName);
			}
		}
	}

	// Token: 0x06000B8E RID: 2958 RVA: 0x000DDD28 File Offset: 0x000DBF28
	public override void update()
	{
		bool flag = this.objMainFocus == null;
		if (flag)
		{
			bool flag2 = GameCanvas.gameTick % 100 == 0;
			if (flag2)
			{
				this.objMainFocus = MainObject.get_Object((int)this.IDMainShiper, 0);
				bool flag3 = this.objMainFocus != null;
				if (flag3)
				{
					this.setInfoObjMain();
				}
			}
		}
		else
		{
			bool flag4 = this.f == 0 && this.Action == 0;
			if (flag4)
			{
				bool flag5 = CRes.random(6) == 0;
				if (flag5)
				{
					this.isPlayStand = true;
				}
				else
				{
					this.isPlayStand = false;
				}
			}
			this.x += this.vx;
			this.y += this.vy;
			base.updateActionMonSter(true);
			base.move_to_XY_Normal();
			bool flag6 = this.skillCurrent == null;
			if (flag6)
			{
				base.setNextSkill();
			}
			bool flag7 = this.Action == 0;
			if (flag7)
			{
				this.setBeginMove();
			}
			else
			{
				bool flag8 = this.Action == 1;
				if (flag8)
				{
					int distance = MainObject.getDistance(this.x, this.y, this.toX, this.toY);
					bool flag9 = distance <= 24;
					if (flag9)
					{
						this.setBeginMove();
					}
				}
			}
			bool flag10 = this.Action != 0 && this.isPlayStand;
			if (flag10)
			{
				this.isPlayStand = false;
			}
		}
	}

	// Token: 0x06000B8F RID: 2959 RVA: 0x000DDE90 File Offset: 0x000DC090
	public void setBeginMove()
	{
		bool flag = this.objMainFocus.typeActionBoat != 0;
		if (!flag)
		{
			bool flag2 = LoadMap.specMap == 4;
			if (flag2)
			{
				bool flag3 = this.objMainFocus.boatSea != null;
				if (flag3)
				{
					bool flag4 = this.objMainFocus.boatSea.Dir == 0;
					if (flag4)
					{
						this.x = this.objMainFocus.boatSea.x + 30;
					}
					else
					{
						this.x = this.objMainFocus.boatSea.x - 30;
					}
					this.y = this.objMainFocus.boatSea.y + 1;
					this.dy = 5;
					this.toX = this.x;
					this.toY = this.y;
					this.Dir = this.objMainFocus.boatSea.Dir;
				}
				bool flag5 = this.Action == 1;
				if (flag5)
				{
					this.Action = 0;
				}
			}
			else
			{
				bool flag6 = false;
				int distance = MainObject.getDistance(this.x, this.y, this.objMainFocus.x, this.objMainFocus.y);
				int num = CRes.random(100);
				bool flag7 = distance > 250;
				if (flag7)
				{
					base.setSpeed(14, 14);
					flag6 = true;
				}
				bool flag8 = !flag6 && distance > 150;
				if (flag8)
				{
					base.setSpeed(8, 8);
					flag6 = true;
				}
				bool flag9 = !flag6 && distance > 100;
				if (flag9)
				{
					base.setSpeed(this.vMax, this.vMax);
					flag6 = true;
				}
				bool flag10 = !flag6 && num < 2;
				if (flag10)
				{
					base.setSpeed(this.vMax, this.vMax);
					flag6 = true;
				}
				bool flag11 = !flag6 && distance > 48 && num < 25;
				if (flag11)
				{
					base.setSpeed(this.vMax, this.vMax);
					flag6 = true;
				}
				int num2 = 0;
				bool flag12 = !flag6;
				if (!flag12)
				{
					int num3;
					int num4;
					int tile;
					do
					{
						num2++;
						num3 = this.objMainFocus.x + CRes.random_Am(12, 48);
						num4 = this.objMainFocus.y + CRes.random_Am(12, 24);
						bool flag13 = this.Action == 1;
						if (flag13)
						{
							num4 = ((num2 >= 5) ? (this.objMainFocus.y + 12) : (this.objMainFocus.y - 12));
						}
						tile = GameCanvas.loadmap.getTile(num3, num4);
					}
					while (tile != 0 && tile != 2 && num2 < 10);
					this.toX = num3;
					this.toY = num4;
				}
			}
		}
	}

	// Token: 0x06000B90 RID: 2960 RVA: 0x000DE140 File Offset: 0x000DC340
	public void setInfoObjMain()
	{
		this.x = this.objMainFocus.x;
		this.y = this.objMainFocus.y - this.dyMovePet;
		this.toX = this.objMainFocus.x;
		this.toY = this.objMainFocus.y - this.dyMovePet;
		this.objMainFocus.isPet = true;
		bool flag = this.objMainFocus == GameScreen.player;
		if (flag)
		{
			this.colorName = 0;
		}
	}

	// Token: 0x06000B91 RID: 2961 RVA: 0x000DE1C8 File Offset: 0x000DC3C8
	public override void setPetActionFire()
	{
		bool flag = this.Action != 2 || this.Action != 4;
		if (flag)
		{
			this.Action = 2;
			this.f = 0;
		}
	}

	// Token: 0x0400115C RID: 4444
	public const sbyte PET_CHOPPER = 0;

	// Token: 0x0400115D RID: 4445
	public const sbyte PET_TOTO = 1;

	// Token: 0x0400115E RID: 4446
	public const sbyte PET_LASSO = 2;

	// Token: 0x0400115F RID: 4447
	public const sbyte PET_GHOST = 3;

	// Token: 0x04001160 RID: 4448
	public const sbyte PET_BAT = 4;

	// Token: 0x04001161 RID: 4449
	public const sbyte PET_GHOST_BROOK = 5;

	// Token: 0x04001162 RID: 4450
	public static int[][] mChoper = new int[][]
	{
		new int[]
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
			1,
			1,
			1,
			1,
			1
		},
		new int[]
		{
			3,
			3,
			3,
			4,
			4,
			4,
			5,
			5,
			5,
			6,
			6,
			6
		},
		new int[]
		{
			7,
			7,
			7,
			7,
			7,
			8,
			8,
			8
		},
		new int[]
		{
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
		},
		new int[]
		{
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
		}
	};

	// Token: 0x04001163 RID: 4451
	public static int[][] mLasso = new int[][]
	{
		new int[]
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
			1,
			1,
			1,
			1,
			1
		},
		new int[]
		{
			1,
			1,
			1,
			2,
			2,
			2,
			1,
			1,
			1,
			3,
			3,
			3
		},
		new int[]
		{
			1,
			1,
			4,
			4,
			4,
			4,
			4,
			4
		},
		new int[]
		{
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1
		},
		new int[]
		{
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1
		}
	};

	// Token: 0x04001164 RID: 4452
	public static int[][] mGhost = new int[][]
	{
		new int[]
		{
			0,
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
			1,
			2,
			2,
			2,
			2,
			2,
			2,
			1,
			1,
			1,
			1,
			1,
			1
		},
		new int[]
		{
			3,
			3,
			3,
			3,
			3,
			3,
			4,
			4,
			4,
			4,
			4,
			4,
			5,
			5,
			5,
			5,
			5,
			5
		},
		new int[]
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
			1,
			1,
			1
		},
		new int[]
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
			1,
			1,
			1
		},
		new int[]
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
			1,
			1,
			1
		}
	};

	// Token: 0x04001165 RID: 4453
	public static int[][] mBat = new int[][]
	{
		new int[]
		{
			0,
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
			1,
			2,
			2,
			2,
			2,
			2,
			2
		},
		new int[]
		{
			0,
			0,
			0,
			1,
			1,
			1,
			2,
			2,
			2
		},
		new int[]
		{
			0,
			0,
			0,
			1,
			1,
			1,
			2,
			2,
			2
		},
		new int[]
		{
			0,
			0,
			0,
			1,
			1,
			1,
			2,
			2,
			2
		},
		new int[]
		{
			0,
			0,
			0,
			1,
			1,
			1,
			2,
			2,
			2
		}
	};

	// Token: 0x04001166 RID: 4454
	public static int[][] mDog = new int[][]
	{
		new int[]
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
			1
		},
		new int[]
		{
			2,
			2,
			3,
			3,
			4,
			4
		},
		new int[]
		{
			2,
			2,
			3,
			3,
			4,
			4
		},
		new int[]
		{
			2,
			2,
			3,
			3,
			4,
			4
		},
		new int[]
		{
			2,
			2,
			3,
			3,
			4,
			4
		}
	};

	// Token: 0x04001167 RID: 4455
	public static int[] mPlayStandChopper = new int[]
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
		2,
		2,
		2,
		2,
		2
	};

	// Token: 0x04001168 RID: 4456
	public static int[] mPlayStandDogVip = new int[]
	{
		5,
		5,
		5,
		5,
		5,
		5,
		6,
		6,
		6,
		6,
		6,
		6,
		5,
		5,
		5,
		5,
		5,
		5,
		6,
		6,
		6,
		6,
		6,
		6,
		5,
		5,
		5,
		5,
		5,
		5,
		6,
		6,
		6,
		6,
		6,
		6
	};

	// Token: 0x04001169 RID: 4457
	private MainImage img;
}
