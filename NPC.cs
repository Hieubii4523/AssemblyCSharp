using System;

// Token: 0x020000BC RID: 188
public class NPC : MainObject
{
	// Token: 0x06000B35 RID: 2869 RVA: 0x000D9670 File Offset: 0x000D7870
	public NPC(string name, string namegt, short IDItem, short x, short y, sbyte wBlock, sbyte hBlock, sbyte typeNPC)
	{
		this.name = name;
		this.nameGiaotiep = namegt;
		this.ID = IDItem;
		this.x = (int)x;
		this.y = (int)y;
		this.typeObject = 2;
		this.typeNPC = typeNPC;
		this.Hp = 100;
		this.maxHp = 100;
		this.ysai = 0;
		this.Action = 0;
		GameCanvas.loadmap.setBlockNPC((int)x, (int)y, (int)wBlock, (int)hBlock);
		this.fMyRandom = (sbyte)CRes.random(7);
		this.colorName = 5;
		this.vySea = 4;
		base.setWName();
	}

	// Token: 0x06000B36 RID: 2870 RVA: 0x000D9714 File Offset: 0x000D7914
	public void setDataFrame(sbyte IDImage, sbyte nFrame)
	{
		this.IdIcon = (short)IDImage;
		this.nFrame = (int)nFrame;
		this.numnextframe = 7;
		bool flag = this.IdIcon == 36;
		if (flag)
		{
			this.hardcodehead = 12;
		}
		else
		{
			bool flag2 = this.IdIcon == 18;
			if (flag2)
			{
				this.hardcodehead = 18;
			}
			else
			{
				bool flag3 = this.IdIcon == 30;
				if (flag3)
				{
					this.hardcodexlechhead = -8;
					this.hardcodehead = 3;
				}
				else
				{
					bool flag4 = this.IdIcon == 31;
					if (flag4)
					{
						this.hardcodexlechhead = -10;
						this.hardcodehead = 13;
					}
					else
					{
						bool flag5 = this.IdIcon == 66;
						if (flag5)
						{
							this.dyShadow = 3;
							this.numnextframe = 12;
						}
						else
						{
							bool flag6 = this.IdIcon == 68;
							if (flag6)
							{
								this.hardcodehead = 6;
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x06000B37 RID: 2871 RVA: 0x000D97F0 File Offset: 0x000D79F0
	public override void paint(mGraphics g)
	{
		bool flag = this.isPerson == 1 || this.isPerson == 98;
		if (flag)
		{
			g.drawImage(MainObject.imgShadow, this.x + 1, this.y - 3 - this.dySea / 10 + this.dyShadow, 3);
		}
		bool flag2 = this.typeNPC == 1;
		if (flag2)
		{
			base.paintCharAllPart(g, 0);
		}
		else
		{
			bool flag3 = this.typeNPC == 0;
			if (flag3)
			{
				MainImage imageAll = ObjectData.getImageAll(this.IdIcon, ObjectData.hashImageNPC, 5000);
				bool flag4 = imageAll.img != null;
				if (flag4)
				{
					bool flag5 = this.wOne == 0;
					if (flag5)
					{
						this.hOne = mImage.getImageHeight(imageAll.img.image) / this.nFrame;
						this.wOne = mImage.getImageWidth(imageAll.img.image);
					}
					g.drawRegion(imageAll.img, 0, ((int)this.fMyRandom + GameCanvas.gameTick / this.numnextframe) % this.nFrame * this.hOne, this.wOne, this.hOne + this.dySea / 10, 0, (float)this.x, (float)this.y, 33);
				}
				bool flag6 = this.isPerson == 99;
				if (flag6)
				{
					int num = 0;
					bool flag7 = LoadMap.specMap == 4;
					if (flag7)
					{
						num = 3;
					}
					mFont.tahoma_7b_black.drawString(g, string.Empty + LoadMap.getShowArea(LoadMap.Area).ToString(), this.x, this.y - 22 - this.dySea / 10 - num, 2);
				}
				else
				{
					bool flag8 = this.isPerson == 98 && GameScreen.ClanDao != null;
					if (flag8)
					{
						MainImage iconClanBig = Potion.getIconClanBig(GameScreen.ClanDao.idIcon);
						bool flag9 = iconClanBig != null && iconClanBig.img != null;
						if (flag9)
						{
							int num2 = 0;
							bool flag10 = ((int)this.fMyRandom + GameCanvas.gameTick / this.numnextframe) % 2 == 1;
							if (flag10)
							{
								num2 = -2;
							}
							bool flag11 = iconClanBig.frame == -1;
							if (flag11)
							{
								iconClanBig.set_Frame();
							}
							bool flag12 = iconClanBig.frame <= 1;
							if (flag12)
							{
								g.drawImage(iconClanBig.img, this.x + num2 + 2, this.y - 52, 3);
							}
							else
							{
								int num3 = (this.framepaint < (int)(imageAll.frame - 1)) ? 3 : 15;
								bool flag13 = CRes.abs(GameCanvas.gameTick - this.lastTick) > num3;
								if (flag13)
								{
									this.framepaint++;
									bool flag14 = this.framepaint >= (int)imageAll.frame;
									if (flag14)
									{
										this.framepaint = 0;
									}
									this.lastTick = GameCanvas.gameTick;
								}
								g.drawRegion(iconClanBig.img, 0, this.framepaint * (int)iconClanBig.w, (int)iconClanBig.w, (int)iconClanBig.w, 0, (float)(this.x + num2 + 2), (float)(this.y - 52), 3);
							}
						}
					}
				}
				bool flag15 = this.typeNpcEvent > 0;
				if (flag15)
				{
					this.paintNpcEvent(g);
				}
				bool flag16 = this.ID == -993 && GameScreen.player.isNauBanh;
				if (flag16)
				{
					AvMain.fraNauBanh.drawFrame(2, this.x, this.y - this.hOne - 30, 0, 3, g);
					g.setColor(65394);
					g.fillRect(this.x + 20, this.y - this.hOne - 30 - 3, 3, 7);
					g.setColor(16580352);
					bool flag17 = GameScreen.player.tickNauBanh < 87;
					if (flag17)
					{
						g.fillRect(this.x - 43 + GameScreen.player.tickNauBanh, this.y - this.hOne - 30 - 3, 1, 7);
					}
				}
			}
		}
		bool flag18 = this.isPerson != 99 && this.isPerson != 98;
		if (flag18)
		{
			this.paintName(g, this.colorName, 0);
		}
	}

	// Token: 0x06000B38 RID: 2872 RVA: 0x000D9C40 File Offset: 0x000D7E40
	private void paintNpcEvent(mGraphics g)
	{
		bool flag = this.typeNpcEvent == 1;
		if (flag)
		{
			AvMain.fraEventMoon.drawFrameNew(NPC.hardCodeEventMoon[this.indexEventMoon][3] * 3, this.x + NPC.hardCodeEventMoon[this.indexEventMoon][1], this.y + NPC.hardCodeEventMoon[this.indexEventMoon][2] - 3 + ((int)this.fMyRandom + GameCanvas.gameTick / 7) % 2 * NPC.hardCodeEventMoon[this.indexEventMoon][4], 0, mGraphics.TOP | mGraphics.RIGHT, g);
		}
		bool flag2 = this.typeNpcEvent == 2;
		if (flag2)
		{
			AvMain.fraEventMoon.drawFrameNew(1 + GameCanvas.gameTick / 4 % 2 + NPC.hardCodeEventMoon[this.indexEventMoon][3] * 3, this.x + NPC.hardCodeEventMoon[this.indexEventMoon][1], this.y + NPC.hardCodeEventMoon[this.indexEventMoon][2] - 3 + ((int)this.fMyRandom + GameCanvas.gameTick / 7) % 2 * NPC.hardCodeEventMoon[this.indexEventMoon][4], 0, mGraphics.TOP | mGraphics.RIGHT, g);
		}
	}

	// Token: 0x06000B39 RID: 2873 RVA: 0x000D9D64 File Offset: 0x000D7F64
	public override void paintName(mGraphics g, sbyte color, int isFocus)
	{
		bool flag = GameScreen.getIsOffAdmin(0) || (GameScreen.objFocus != null && GameScreen.objFocus == this && isFocus == 0) || this.isPerson == 99 || this.isPerson == 98;
		if (!flag)
		{
			int num = 0;
			bool flag2 = this.Action == 4;
			if (flag2)
			{
				num = 5;
			}
			int num2 = this.y - this.dy - this.hOne - 18 + num;
			bool flag3 = this.wNameNPC > 51;
			if (flag3)
			{
				g.drawRegion(AvMain.imgCombo, 0, 2, 4, 13, 0, (float)(this.x - this.wNameNPC / 2 + 2), (float)(num2 + 6), 3);
				g.drawRegion(AvMain.imgCombo, 47, 2, 4, 13, 0, (float)(this.x + this.wNameNPC / 2 - 2), (float)(num2 + 6), 3);
				int num3 = (this.wNameNPC - 8) / 40;
				for (int i = 0; i <= (this.wNameNPC - 8) / 40; i++)
				{
					bool flag4 = i == num3;
					if (flag4)
					{
						g.drawRegion(AvMain.imgCombo, 4, 2, (this.wNameNPC - 8) % 40, 13, 0, (float)(this.x - this.wNameNPC / 2 + 4 + 20 + i * 40 - 20 + (this.wNameNPC - 8) % 40 / 2), (float)(num2 + 6), 3);
					}
					else
					{
						g.drawRegion(AvMain.imgCombo, 4, 2, 40, 13, 0, (float)(this.x - this.wNameNPC / 2 + 4 + 20 + i * 40), (float)(num2 + 6), 3);
					}
				}
			}
			else
			{
				g.drawRegion(AvMain.imgCombo, 0, 2, 51, 13, 0, (float)this.x, (float)(num2 + 6), 3);
			}
			int num4 = this.x;
			bool flag5 = this.typeQuest > 0;
			if (flag5)
			{
				num4 -= 10;
			}
			bool flag6 = this.typeIconNPC > -1;
			if (flag6)
			{
				base.paintIconNPC(g, num4);
				num4 += 20;
			}
			else
			{
				num4 = this.x;
			}
			bool flag7 = this.typeQuest > 0 && GameCanvas.gameTick % 14 < 12;
			if (flag7)
			{
				base.paintIconQuest(g, num4);
			}
			bool flag8 = isFocus == 1;
			if (flag8)
			{
				AvMain.FontBorderColor(g, this.name, this.x, num2, 2, (int)color, 7);
			}
			else
			{
				AvMain.Font3dColor(g, this.name, this.x, num2, 2, color);
			}
			base.paintIconPk_ThanhTich(g);
		}
	}

	// Token: 0x06000B3A RID: 2874 RVA: 0x000D9FE8 File Offset: 0x000D81E8
	public override void paintHead(mGraphics g, int x, int y, int trans)
	{
		bool flag = this.isPerson != 1;
		if (!flag)
		{
			bool flag2 = this.typeNPC == 1;
			if (flag2)
			{
				MainObject.paintHeadEveryWhere(g, this.head, this.hair, this.hat, x, y + 38, trans);
			}
			else
			{
				MainImage imageAll = ObjectData.getImageAll(this.IdIcon, ObjectData.hashImageNPC, 5000);
				bool flag3 = imageAll.img != null;
				if (flag3)
				{
					bool flag4 = this.wOne == 0;
					if (flag4)
					{
						this.hOne = mImage.getImageHeight(imageAll.img.image) / this.nFrame;
						this.wOne = mImage.getImageWidth(imageAll.img.image);
					}
					int num = 18;
					int num2 = 18;
					bool flag5 = num > this.hOne;
					if (flag5)
					{
						num = this.hOne;
					}
					bool flag6 = num2 > this.wOne;
					if (flag6)
					{
						num2 = this.wOne;
					}
					g.drawRegion(imageAll.img, this.wOne / 2 - num2 / 2 + this.hardcodexlechhead, this.hardcodehead, num2, num, 0, (float)x, (float)y, 3);
				}
			}
		}
	}

	// Token: 0x06000B3B RID: 2875 RVA: 0x000DA118 File Offset: 0x000D8318
	public override void updateDySea()
	{
		bool flag = this.ID == -119;
		if (!flag)
		{
			bool flag2 = CRes.random(40) == 0;
			if (flag2)
			{
				bool flag3 = CRes.random(2) == 0;
				if (flag3)
				{
					this.vySea = 4;
				}
				else
				{
					this.vySea = -4;
				}
			}
			bool flag4 = this.dySea > 0 && this.vySea > 0;
			if (flag4)
			{
				this.vySea = -4;
			}
			else
			{
				bool flag5 = this.dySea < -50 && this.vySea < 0;
				if (flag5)
				{
					this.vySea = 4;
				}
			}
			this.dySea += this.vySea;
		}
	}

	// Token: 0x06000B3C RID: 2876 RVA: 0x000DA1CC File Offset: 0x000D83CC
	public override void update()
	{
		base.updateActionPerson();
		base.updateChatPopup(this.dhCharPopup);
		bool flag = LoadMap.specMap == 4;
		if (flag)
		{
			this.updateDySea();
		}
		bool flag2 = GameScreen.objFocus != null && GameScreen.objFocus == this && this.isNPC_Area() == 99 && GameCanvas.gameTick % 100 == 0;
		if (flag2)
		{
			GlobalService.gI().Update_Num_Player_Map();
		}
	}

	// Token: 0x06000B3D RID: 2877 RVA: 0x000DA23C File Offset: 0x000D843C
	public override void Giaotiep()
	{
		mSystem.outz("vao day NPC giao tiep");
		bool flag = this.isPerson == 98;
		if (flag)
		{
			mSystem.outz("vao day 1111111");
			bool flag2 = GameScreen.ClanDao != null;
			if (flag2)
			{
				mSystem.outz("vao day 222222222 clan=" + GameScreen.player.clan.ID.ToString() + "  " + GameScreen.ClanDao.ID.ToString());
				bool flag3 = GameScreen.player.clan == null || GameScreen.player.clan.ID != GameScreen.ClanDao.ID;
				if (flag3)
				{
					mSystem.outz("vao day 333333");
					MsgDialog msgDialog = new MsgDialog();
					msgDialog.setinfoClan(GameScreen.ClanDao);
					GameCanvas.Start_Current_Dialog(msgDialog);
				}
				else
				{
					GlobalService.gI().shop_NPC(this.ID);
				}
			}
		}
		else
		{
			bool flag4 = this.isPerson != 2 && this.isPerson != 1;
			if (flag4)
			{
				GlobalService.gI().shop_NPC(this.ID);
			}
			else
			{
				base.GiaotiepNPC();
			}
		}
	}

	// Token: 0x06000B3E RID: 2878 RVA: 0x000DA368 File Offset: 0x000D8568
	public override iCommand getCenterCmd()
	{
		return GameScreen.cmdGiaoTiep;
	}

	// Token: 0x06000B3F RID: 2879 RVA: 0x000DA380 File Offset: 0x000D8580
	public override void setTouchPoint()
	{
		bool flag = Interface_Game.vecfocus.size() <= 1;
		if (flag)
		{
			this.setFireObject(2);
			Interface_Game.timeShowNear = 0;
		}
	}

	// Token: 0x06000B40 RID: 2880 RVA: 0x000DA3B4 File Offset: 0x000D85B4
	public override void setFireObject(int value)
	{
		bool flag = value == 2;
		if (flag)
		{
			this.Giaotiep();
		}
	}

	// Token: 0x06000B41 RID: 2881 RVA: 0x000DA3D4 File Offset: 0x000D85D4
	public override int isNPC_Area()
	{
		return (int)this.isPerson;
	}

	// Token: 0x06000B42 RID: 2882 RVA: 0x000DA3EC File Offset: 0x000D85EC
	public override void setPosEvent()
	{
		bool flag = this.typeNpcEvent != 1 && this.typeNpcEvent != 2;
		if (!flag)
		{
			for (int i = 0; i < NPC.hardCodeEventMoon.Length; i++)
			{
				bool flag2 = (int)this.IdIcon == NPC.hardCodeEventMoon[i][0];
				if (flag2)
				{
					this.indexEventMoon = i;
					break;
				}
			}
		}
	}

	// Token: 0x040010C5 RID: 4293
	public const sbyte NPC_THING = 0;

	// Token: 0x040010C6 RID: 4294
	public const sbyte NPC_PERSON = 1;

	// Token: 0x040010C7 RID: 4295
	public const sbyte NPC_PERSON_THING = 2;

	// Token: 0x040010C8 RID: 4296
	public const sbyte NPC_CLAN_DAO = 98;

	// Token: 0x040010C9 RID: 4297
	public const sbyte NPC_AREA = 99;

	// Token: 0x040010CA RID: 4298
	private sbyte typeNPC;

	// Token: 0x040010CB RID: 4299
	private sbyte fMyRandom;

	// Token: 0x040010CC RID: 4300
	private int numnextframe = 7;

	// Token: 0x040010CD RID: 4301
	private int hardcodehead;

	// Token: 0x040010CE RID: 4302
	private int hardcodexlechhead;

	// Token: 0x040010CF RID: 4303
	private int indexEventMoon;

	// Token: 0x040010D0 RID: 4304
	public sbyte isPerson;

	// Token: 0x040010D1 RID: 4305
	public static int[][] hardCodeEventMoon = new int[][]
	{
		new int[]
		{
			1,
			8,
			-19,
			0,
			1
		},
		new int[]
		{
			2,
			2,
			-24,
			1,
			1
		},
		new int[]
		{
			3,
			8,
			-21,
			1,
			1
		},
		new int[]
		{
			36,
			10,
			-22,
			3,
			1
		},
		new int[]
		{
			35,
			-10,
			-23,
			4,
			1
		},
		new int[]
		{
			34,
			5,
			-20,
			0,
			1
		},
		new int[]
		{
			33,
			-1,
			-22,
			1,
			1
		},
		new int[]
		{
			32,
			-7,
			-25,
			1,
			1
		},
		new int[]
		{
			29,
			6,
			-19,
			3,
			1
		},
		new int[]
		{
			28,
			8,
			-24,
			4,
			1
		},
		new int[]
		{
			27,
			-8,
			-17,
			2,
			0
		},
		new int[]
		{
			22,
			4,
			-25,
			0,
			1
		},
		new int[]
		{
			21,
			10,
			-20,
			1,
			1
		},
		new int[]
		{
			20,
			8,
			-22,
			1,
			1
		},
		new int[]
		{
			19,
			-8,
			-12,
			2,
			0
		},
		new int[]
		{
			18,
			8,
			-20,
			0,
			1
		},
		new int[]
		{
			17,
			0,
			-10,
			2,
			0
		},
		new int[]
		{
			16,
			8,
			-24,
			3,
			1
		},
		new int[]
		{
			15,
			-8,
			-17,
			2,
			0
		},
		new int[]
		{
			14,
			10,
			-21,
			4,
			1
		},
		new int[]
		{
			13,
			-12,
			-17,
			2,
			0
		},
		new int[]
		{
			12,
			10,
			-25,
			1,
			1
		},
		new int[]
		{
			11,
			-2,
			-23,
			1,
			1
		},
		new int[]
		{
			10,
			-8,
			-17,
			2,
			0
		},
		new int[]
		{
			9,
			-2,
			-19,
			1,
			1
		},
		new int[]
		{
			37,
			7,
			-27,
			3,
			1
		},
		new int[]
		{
			38,
			4,
			-25,
			4,
			1
		},
		new int[]
		{
			39,
			6,
			-27,
			1,
			1
		},
		new int[]
		{
			60,
			16,
			-10,
			2,
			0
		},
		new int[]
		{
			59,
			6,
			-22,
			0,
			1
		},
		new int[]
		{
			58,
			6,
			-22,
			3,
			1
		}
	};

	// Token: 0x040010D2 RID: 4306
	private int lastTick;

	// Token: 0x040010D3 RID: 4307
	private int framepaint;
}
