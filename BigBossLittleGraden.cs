using System;

// Token: 0x0200000A RID: 10
public class BigBossLittleGraden
{
	// Token: 0x06000057 RID: 87 RVA: 0x00011F20 File Offset: 0x00010120
	public BigBossLittleGraden(sbyte type)
	{
		this.type = (int)type;
		bool flag = type == 1;
		if (flag)
		{
			this.indexAction = 4;
			this.x = MotherCanvas.hw;
			this.y = -40;
			this.vxFire = -16;
			this.vxAva = 2;
			this.yInfo = 70;
			this.name = "Brogy";
			this.vyDie = 10;
			this.yDie = 35;
		}
		else
		{
			this.x = MotherCanvas.hw - 200;
			this.y = -40;
			this.vxFire = 16;
			this.vxAva = -2;
			this.yInfo = 42;
			this.name = "Dorry";
			this.yDie = 40;
			this.vyDie = 10;
		}
	}

	// Token: 0x06000058 RID: 88 RVA: 0x000122E8 File Offset: 0x000104E8
	public void paint(mGraphics g, int xCam)
	{
		for (int i = 0; i < this.mPlayFrame[this.indexAction + this.action].Length; i++)
		{
			int num = this.mPlayFrame[this.indexAction + this.action][i][0];
			MainImage imageOther = ObjectData.getImageOther((short)num, 0);
			bool flag = imageOther != null && imageOther.img != null;
			if (flag)
			{
				g.drawImage(imageOther.img, this.x + xCam + this.mPlayFrame[this.indexAction + this.action][i][1], this.y + this.yEff + this.mPlayFrame[this.indexAction + this.action][i][2], 0);
			}
		}
		for (int j = 0; j < this.vecEff.size(); j++)
		{
			MainEffect mainEffect = (MainEffect)this.vecEff.elementAt(j);
			mainEffect.paint(g, xCam, 0);
		}
	}

	// Token: 0x06000059 RID: 89 RVA: 0x000123F4 File Offset: 0x000105F4
	public void paintINFO(mGraphics g)
	{
		int num = this.yInfo + GameScreen.h12plus;
		int num2 = MotherCanvas.w - this.wNameFocus - 2;
		int width = mFont.tahoma_7b_black.getWidth(this.name);
		AvMain.paintnenFocusSmall(g, num2, num - 1, this.wNameFocus, 26);
		bool flag = this.type == 0;
		if (flag)
		{
			AvMain.fraPk.drawFrame(12 + GameCanvas.gameTick / 3 % 3, num2 + this.wNameFocus / 2 - width / 2 - 4, num + 6, 0, 3, g);
		}
		else
		{
			AvMain.fraPk.drawFrame(15 + GameCanvas.gameTick / 3 % 3, num2 + this.wNameFocus / 2 - width / 2 - 4, num + 6, 0, 3, g);
		}
		AvMain.Font3dWhite(g, this.name, num2 + this.wNameFocus / 2 + 6, num, 2);
		num += 13;
		Interface_Game.PaintHPMP(g, 1, this.hp, this.MaxHP, num2 + (this.wNameFocus - 44) / 2, num, 10, 4, 44, -1, false, 0, false, 0);
		num += 5;
		Interface_Game.PaintHPMP(g, 2, this.mp, this.MaxMP, num2 + (this.wNameFocus - 44) / 2, num, 10, 4, 44, -1, false, 0, false, 0);
	}

	// Token: 0x0600005A RID: 90 RVA: 0x0001252C File Offset: 0x0001072C
	public void update()
	{
		for (int i = 0; i < this.vecEff.size(); i++)
		{
			MainEffect mainEffect = (MainEffect)this.vecEff.elementAt(i);
			mainEffect.update();
			bool isStop = mainEffect.isStop;
			if (isStop)
			{
				this.vecEff.removeElement(mainEffect);
				i--;
			}
		}
		bool flag = (GameCanvas.gameTick % 5 == 0 && this.action != 3) || (GameCanvas.gameTick % 10 == 0 && this.action == 3);
		if (flag)
		{
			this.yEff += this.vyEff;
			bool flag2 = this.vyEff > 0;
			if (flag2)
			{
				bool flag3 = this.yEff >= 4;
				if (flag3)
				{
					this.vyEff = 0;
				}
			}
			else
			{
				bool flag4 = this.vyEff < 0;
				if (flag4)
				{
					bool flag5 = this.yEff <= 0;
					if (flag5)
					{
						this.vyEff = 0;
					}
				}
				else
				{
					bool flag6 = CRes.random(2) == 0;
					if (flag6)
					{
						bool flag7 = this.yEff > 0;
						if (flag7)
						{
							this.vyEff = -4;
						}
						else
						{
							this.vyEff = 4;
						}
					}
				}
			}
		}
		bool flag8 = this.action == 1;
		if (flag8)
		{
			bool flag9 = this.f < 5;
			if (flag9)
			{
				this.x += this.vxFire;
				bool flag10 = this.f == 2;
				if (flag10)
				{
					for (int j = 0; j < GameScreen.vecBigBossLittleGraden.size(); j++)
					{
						BigBossLittleGraden bigBossLittleGraden = (BigBossLittleGraden)GameScreen.vecBigBossLittleGraden.elementAt(j);
						bool flag11 = bigBossLittleGraden.type != this.type;
						if (flag11)
						{
							bigBossLittleGraden.setActionBigBoss(2);
							this.addEffFire(bigBossLittleGraden);
						}
					}
				}
			}
			else
			{
				bool flag12 = this.f >= 8 && this.f < 12;
				if (flag12)
				{
					this.x -= this.vxFire;
				}
				else
				{
					bool flag13 = this.f >= 12;
					if (flag13)
					{
						this.action = 0;
						bool flag14 = this.type == 1;
						if (flag14)
						{
							this.x = MotherCanvas.hw;
						}
						else
						{
							this.x = MotherCanvas.hw - 200;
						}
					}
				}
			}
		}
		else
		{
			bool flag15 = this.action == 2;
			if (flag15)
			{
				bool flag16 = this.f < 3;
				if (flag16)
				{
					this.x += this.vxAva;
				}
				else
				{
					bool flag17 = this.f < 6;
					if (flag17)
					{
						this.x -= this.vxAva;
					}
					else
					{
						bool flag18 = this.f >= 6;
						if (flag18)
						{
							this.action = 0;
							bool flag19 = this.type == 1;
							if (flag19)
							{
								this.x = MotherCanvas.hw;
							}
							else
							{
								this.x = MotherCanvas.hw - 200;
							}
						}
					}
				}
			}
			else
			{
				bool flag20 = this.action == 0;
				if (flag20)
				{
					bool flag21 = GameCanvas.gameTick % 100 == 0;
					if (flag21)
					{
						bool flag22 = this.type == 1;
						if (flag22)
						{
							this.x = MotherCanvas.hw;
						}
						else
						{
							this.x = MotherCanvas.hw - 200;
						}
					}
				}
				else
				{
					bool flag23 = this.action == 3 && this.y < this.yDie;
					if (flag23)
					{
						this.vyDie += 2;
						this.y += this.vyDie;
						bool flag24 = this.y > this.yDie;
						if (flag24)
						{
							this.y = this.yDie;
						}
					}
				}
			}
		}
		this.f++;
	}

	// Token: 0x0600005B RID: 91 RVA: 0x00012918 File Offset: 0x00010B18
	public void setActionBigBoss(sbyte action)
	{
		bool flag = this.action == 3;
		if (!flag)
		{
			bool flag2 = action == 3;
			if (flag2)
			{
				this.action = (int)action;
				this.f = 0;
				this.vyDie = 10;
			}
			else
			{
				bool flag3 = this.action == 0;
				if (flag3)
				{
					this.action = (int)action;
					this.f = 0;
				}
				else
				{
					bool flag4 = this.action == 2;
					if (flag4)
					{
						bool flag5 = this.type == 1;
						if (flag5)
						{
							this.x = MotherCanvas.hw;
						}
						else
						{
							this.x = MotherCanvas.hw - 200;
						}
						this.action = (int)action;
						this.f = 0;
					}
				}
			}
		}
	}

	// Token: 0x0600005C RID: 92 RVA: 0x000129C8 File Offset: 0x00010BC8
	public void addEffFire(BigBossLittleGraden obj)
	{
		bool flag = this.type == 0;
		if (flag)
		{
			obj.vecEff.addElement(GameScreen.CreateEffectEnd(100, 0, MotherCanvas.hw + 100, 60, 2, null));
			obj.vecEff.addElement(GameScreen.CreateEffectEnd(100, 0, MotherCanvas.hw + 115, 66, 2, null));
			EffectNum o = new EffectNum("-" + this.dam.ToString(), MotherCanvas.hw + 100, 60, 2);
			obj.vecEff.addElement(o);
		}
		else
		{
			obj.vecEff.addElement(GameScreen.CreateEffectEnd(100, 0, MotherCanvas.hw - 50, 40, 0, null));
			obj.vecEff.addElement(GameScreen.CreateEffectEnd(100, 0, MotherCanvas.hw - 65, 45, 0, null));
			EffectNum o2 = new EffectNum("-" + this.dam.ToString(), MotherCanvas.hw + 100, 60, 2);
			obj.vecEff.addElement(o2);
		}
	}

	// Token: 0x040000C5 RID: 197
	public const sbyte ACTION_BIG_BOSS_STAND = 0;

	// Token: 0x040000C6 RID: 198
	public const sbyte ACTION_BIG_BOSS_FIRE = 1;

	// Token: 0x040000C7 RID: 199
	public const sbyte ACTION_BIG_BOSS_AVA = 2;

	// Token: 0x040000C8 RID: 200
	public const sbyte ACTION_BIG_BOSS_DIE = 3;

	// Token: 0x040000C9 RID: 201
	public int type;

	// Token: 0x040000CA RID: 202
	public int x;

	// Token: 0x040000CB RID: 203
	public int y;

	// Token: 0x040000CC RID: 204
	public int yEff;

	// Token: 0x040000CD RID: 205
	public int indexAction;

	// Token: 0x040000CE RID: 206
	public int vyEff = 1;

	// Token: 0x040000CF RID: 207
	public int vxFire;

	// Token: 0x040000D0 RID: 208
	public int vxAva;

	// Token: 0x040000D1 RID: 209
	public int f;

	// Token: 0x040000D2 RID: 210
	public int wNameFocus = 54;

	// Token: 0x040000D3 RID: 211
	public int yInfo;

	// Token: 0x040000D4 RID: 212
	public int vyDie;

	// Token: 0x040000D5 RID: 213
	public int yDie;

	// Token: 0x040000D6 RID: 214
	public int action;

	// Token: 0x040000D7 RID: 215
	public int hp = 10;

	// Token: 0x040000D8 RID: 216
	public int MaxHP = 20;

	// Token: 0x040000D9 RID: 217
	public int mp = 10;

	// Token: 0x040000DA RID: 218
	public int MaxMP = 10;

	// Token: 0x040000DB RID: 219
	public int dam;

	// Token: 0x040000DC RID: 220
	public string name = string.Empty;

	// Token: 0x040000DD RID: 221
	private mVector vecEff = new mVector("BigBossLittleGraden.vecEff");

	// Token: 0x040000DE RID: 222
	private int[][][] mPlayFrame = new int[][][]
	{
		new int[][]
		{
			new int[]
			{
				0,
				0,
				62
			},
			new int[]
			{
				1,
				130,
				58
			},
			new int[]
			{
				2,
				17,
				74
			},
			new int[]
			{
				3,
				149,
				92
			}
		},
		new int[][]
		{
			new int[]
			{
				0,
				0,
				62
			},
			new int[]
			{
				3,
				140,
				32
			},
			new int[]
			{
				4,
				80,
				64
			},
			new int[]
			{
				5,
				65,
				17
			}
		},
		new int[][]
		{
			new int[]
			{
				0,
				0,
				62
			},
			new int[]
			{
				2,
				17,
				74
			},
			new int[]
			{
				3,
				144,
				50
			},
			new int[]
			{
				4,
				80,
				64
			}
		},
		new int[][]
		{
			new int[]
			{
				0,
				0,
				62
			},
			new int[]
			{
				1,
				130,
				58
			},
			new int[]
			{
				2,
				17,
				74
			},
			new int[]
			{
				3,
				149,
				92
			}
		},
		new int[][]
		{
			new int[]
			{
				6,
				52,
				73
			},
			new int[]
			{
				7,
				82,
				70
			},
			new int[]
			{
				8,
				28,
				18
			},
			new int[]
			{
				9,
				149,
				95
			}
		},
		new int[][]
		{
			new int[]
			{
				6,
				52,
				73
			},
			new int[]
			{
				9,
				149,
				95
			},
			new int[]
			{
				10,
				-77,
				65
			},
			new int[]
			{
				11,
				79,
				65
			}
		},
		new int[][]
		{
			new int[]
			{
				6,
				52,
				73
			},
			new int[]
			{
				9,
				149,
				95
			},
			new int[]
			{
				12,
				47,
				42
			},
			new int[]
			{
				13,
				83,
				73
			}
		},
		new int[][]
		{
			new int[]
			{
				6,
				52,
				73
			},
			new int[]
			{
				9,
				149,
				95
			},
			new int[]
			{
				12,
				47,
				42
			},
			new int[]
			{
				13,
				83,
				73
			}
		}
	};
}
