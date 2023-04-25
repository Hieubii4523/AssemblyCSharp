using System;

// Token: 0x02000081 RID: 129
public class MainObject : AvMain
{
	// Token: 0x060007B9 RID: 1977 RVA: 0x000A0788 File Offset: 0x0009E988
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
		{
			mVector listQuestNPC = this.getListQuestNPC();
			mVector mVector = new mVector();
			for (int i = 0; i < listQuestNPC.size(); i++)
			{
				MainQuest mainQuest = (MainQuest)listQuestNPC.elementAt(i);
				bool flag = mainQuest.statusQuest == 2;
				if (flag)
				{
					GameCanvas.menuCur.isShowMenu = false;
					GameCanvas.menuCur.runText = null;
					mainQuest.beginQuest(this.ID);
					return;
				}
				iCommand iCommand = new iCommand(mainQuest.name + ((mainQuest.typeMainSub != 0) ? string.Empty : mainQuest.getMainSub()), 1, (int)mainQuest.ID, this);
				bool flag2 = mainQuest.idNPC == (int)this.ID;
				if (flag2)
				{
					iCommand.setFraCaption(AvMain.fraQuest, 1, (int)(mainQuest.statusQuest + 1), 3);
				}
				else
				{
					bool flag3 = mainQuest.statusQuest == 2 && mainQuest.idNPC_Sub == (int)this.ID;
					if (flag3)
					{
						iCommand.setFraCaption(AvMain.fraQuest, 1, 2, 3);
					}
				}
				mVector.addElement(iCommand);
			}
			GameCanvas.menu.startAt(mVector, 2, T.quest);
			break;
		}
		case 1:
		{
			MainQuest quest = MainQuest.getQuest((short)subIndex);
			if (quest != null)
			{
				quest.beginQuest(this.ID);
			}
			break;
		}
		case 2:
			GlobalService.gI().shop_NPC(this.ID);
			GameCanvas.menuCur.isShowMenu = false;
			break;
		case 3:
			GlobalService.gI().shop_NPC(this.ID);
			GameCanvas.menuCur.isShowMenu = false;
			break;
		case 4:
			GlobalService.gI().EventMoon(this.ID, 2);
			break;
		case 5:
			GlobalService.gI().EventMoon(this.ID, 2);
			break;
		}
	}

	// Token: 0x060007BA RID: 1978 RVA: 0x000090B5 File Offset: 0x000072B5
	public override void paint(mGraphics g)
	{
	}

	// Token: 0x060007BB RID: 1979 RVA: 0x000090B5 File Offset: 0x000072B5
	public override void paintHideAvatar(mGraphics g)
	{
	}

	// Token: 0x060007BC RID: 1980 RVA: 0x000A096C File Offset: 0x0009EB6C
	public virtual void paintOnlyShadown(mGraphics g)
	{
		g.drawImage(AvMain.imgHinhnhan, this.x, this.y, 33);
		bool flag = GameScreen.objFocus == null || this != GameScreen.objFocus;
		if (!flag)
		{
			sbyte color = this.colorName;
			bool flag2 = Player.vecParty.size() > 0;
			if (flag2)
			{
				for (int i = 0; i < Player.vecParty.size(); i++)
				{
					InfoMemList infoMemList = (InfoMemList)Player.vecParty.elementAt(i);
					bool flag3 = infoMemList.name.CompareTo(this.name) == 0;
					if (flag3)
					{
						color = 4;
						break;
					}
				}
			}
			bool flag4 = Player.mSatnhan.Length != 0;
			if (flag4)
			{
				for (int j = 0; j < Player.mSatnhan.Length; j++)
				{
					bool flag5 = this.ID == Player.mSatnhan[j];
					if (flag5)
					{
						color = 6;
					}
				}
			}
			this.paintName(g, color, 0);
		}
	}

	// Token: 0x060007BD RID: 1981 RVA: 0x000A0A70 File Offset: 0x0009EC70
	public void paintshadowFocus(mGraphics g, int ylech)
	{
		bool flag = GameScreen.typeViewPlayer == 0 && this == GameScreen.objFocus;
		if (flag)
		{
			int num = 2;
			bool flag2 = this.type_left_right == 2;
			if (flag2)
			{
				num = -2;
			}
			AvMain.fraShadowFocus.drawFrame(GameCanvas.gameTickChia4 % AvMain.fraShadowFocus.nFrame, this.x + num, this.y + ylech, 0, 3, g);
		}
	}

	// Token: 0x060007BE RID: 1982 RVA: 0x0000ABD7 File Offset: 0x00008DD7
	public virtual void paintShadow(mGraphics g, int xpaint)
	{
		this.paintShadow(g, xpaint, this.y);
	}

	// Token: 0x060007BF RID: 1983 RVA: 0x000A0AD8 File Offset: 0x0009ECD8
	public virtual void paintShadow(mGraphics g, int xpaint, int ypaint)
	{
		int num = 2;
		bool flag = this.type_left_right == 2;
		if (flag)
		{
			num = -2;
		}
		g.drawImage(MainObject.imgShadow, xpaint + num, ypaint, 3);
	}

	// Token: 0x060007C0 RID: 1984 RVA: 0x000A0B0C File Offset: 0x0009ED0C
	public virtual void paintShadowMonster(mGraphics g, int xpaint, int dyS, int type)
	{
		switch (type)
		{
		case 0:
			g.drawImage(MainObject.imgShadow, xpaint, this.y + dyS, 3);
			return;
		case 1:
			g.drawImage(AvMain.imgShadowSmall, xpaint, this.y + dyS, 3);
			return;
		case 2:
		{
			bool flag = MainObject.imgShadow2 == null;
			if (flag)
			{
				MainObject.imgShadow2 = LoadImageStatic.LoadNewInterface("/shadow2.png");
			}
			g.drawImage(MainObject.imgShadow2, xpaint, this.y + dyS, 3);
			return;
		}
		case 3:
			try
			{
				bool flag2 = MainObject.imgShadow3 == null;
				if (flag2)
				{
					MainObject.imgShadow3 = LoadImageStatic.LoadNewInterface("/shadow3.png");
				}
				g.drawImage(MainObject.imgShadow3, xpaint, this.y + dyS, 3);
				return;
			}
			catch (Exception)
			{
				return;
			}
			break;
		case 4:
			break;
		default:
			return;
		}
		g.drawRegion(MainObject.imgShadow, 0, 0, 18, 10, 0, (float)(xpaint - 9), (float)(this.y + dyS), 3);
		g.drawRegion(MainObject.imgShadow, 0, 0, 18, 10, 2, (float)(xpaint + 9), (float)(this.y + dyS), 3);
	}

	// Token: 0x060007C1 RID: 1985 RVA: 0x0000ABE9 File Offset: 0x00008DE9
	public void paintWhenBoatOther(mGraphics g, int x, int y)
	{
		this.paintChar(g, x, y);
	}

	// Token: 0x060007C2 RID: 1986 RVA: 0x000A0C40 File Offset: 0x0009EE40
	public void paintCharAllPart(mGraphics g, int typeSha)
	{
		this.paintshadowFocus(g, 0);
		int num = this.y - this.dy;
		bool flag = this.checkBoatSea() && this.boatSea != null && this.boatSea.ID == this.ID;
		if (flag)
		{
			this.boatSea.paintFrist(g);
			bool flag2 = this.dy == 0;
			if (flag2)
			{
				num = this.y - this.dySea / 10;
			}
			this.boatSea.paintBuom(g);
		}
		else
		{
			bool flag3 = !this.isTanHinh;
			if (flag3)
			{
				bool flag4 = this.typeObject == 1;
				if (flag4)
				{
					this.paintShadowMonster(g, this.x - this.dx, this.dyShadow, typeSha);
				}
				else
				{
					this.paintShadow(g, this.x - this.dx);
				}
			}
		}
		bool flag5 = !this.isTanHinh;
		if (flag5)
		{
			this.paintEffFashion(g, -1);
			this.paintBuffFirst(g, this.x - this.dx, num);
			this.paintEffSpecFirst(g);
			this.paintChar(g, this.x - this.dx, num);
		}
		bool flag6 = this.checkBoatSea() && this.boatSea != null && this.boatSea.ID == this.ID;
		if (flag6)
		{
			this.boatSea.paintLastInMap(g);
		}
		bool flag7 = !this.isTanHinh;
		if (flag7)
		{
			this.paintEffFashion(g, 0);
			this.paintBuffLast(g, this.x - this.dx, num);
			this.paintEffSpecLast(g);
		}
	}

	// Token: 0x060007C3 RID: 1987 RVA: 0x000A0DE4 File Offset: 0x0009EFE4
	public void paintCharNoPart(mGraphics g, int typeSha)
	{
		this.paintshadowFocus(g, 0);
		int num = this.y - this.dy;
		bool flag = this.checkBoatSea() && this.boatSea != null && this.boatSea.ID == this.ID;
		if (flag)
		{
			this.boatSea.paintFrist(g);
			bool flag2 = this.dy == 0;
			if (flag2)
			{
				num = this.y - this.dySea / 10;
			}
			this.boatSea.paintBuom(g);
		}
		else
		{
			bool flag3 = !this.isTanHinh;
			if (flag3)
			{
				bool flag4 = this.typeObject == 1;
				if (flag4)
				{
					this.paintShadowMonster(g, this.x - this.dx, this.dyShadow, typeSha);
				}
				else
				{
					this.paintShadow(g, this.x - this.dx);
				}
			}
		}
		bool flag5 = this.checkBoatSea() && this.boatSea != null && this.boatSea.ID == this.ID;
		if (flag5)
		{
			this.boatSea.paintLastInMap(g);
		}
	}

	// Token: 0x060007C4 RID: 1988 RVA: 0x000A0F04 File Offset: 0x0009F104
	public void paintBuffFirst(mGraphics g, int x, int y)
	{
		for (int i = 0; i < this.vecBuffCur.size(); i++)
		{
			MainBuff mainBuff = (MainBuff)this.vecBuffCur.elementAt(i);
			bool flag = mainBuff.levelPaint == -1;
			if (flag)
			{
				mainBuff.paint(g, x, y);
			}
		}
	}

	// Token: 0x060007C5 RID: 1989 RVA: 0x000A0F5C File Offset: 0x0009F15C
	public void paintBuffLast(mGraphics g, int x, int y)
	{
		for (int i = 0; i < this.vecBuffCur.size(); i++)
		{
			MainBuff mainBuff = (MainBuff)this.vecBuffCur.elementAt(i);
			bool flag = mainBuff.levelPaint != -1;
			if (flag)
			{
				mainBuff.paint(g, x, y);
			}
			mainBuff.paintLastSpec(g, x, y, this);
		}
	}

	// Token: 0x060007C6 RID: 1990 RVA: 0x000A0FC0 File Offset: 0x0009F1C0
	public void paintEffSpecLast(mGraphics g)
	{
		for (int i = 0; i < this.vecEffspec.size(); i++)
		{
			Effect_Spec effect_Spec = (Effect_Spec)this.vecEffspec.elementAt(i);
			bool flag = effect_Spec.levelPaint != -1;
			if (flag)
			{
				effect_Spec.paint(g);
			}
		}
	}

	// Token: 0x060007C7 RID: 1991 RVA: 0x000A1018 File Offset: 0x0009F218
	public void paintEffSpecFirst(mGraphics g)
	{
		for (int i = 0; i < this.vecEffspec.size(); i++)
		{
			Effect_Spec effect_Spec = (Effect_Spec)this.vecEffspec.elementAt(i);
			bool flag = effect_Spec.levelPaint == -1;
			if (flag)
			{
				effect_Spec.paint(g);
			}
			effect_Spec.paintFrist(g);
		}
	}

	// Token: 0x060007C8 RID: 1992 RVA: 0x000A1074 File Offset: 0x0009F274
	public virtual void paintName(mGraphics g, sbyte color, int isFocus)
	{
		bool isOffAdmin = GameScreen.getIsOffAdmin(0);
		if (!isOffAdmin)
		{
			bool flag = GameScreen.isShowNameSUPER_BOSS || (GameScreen.player != null && this == GameScreen.player) || (GameScreen.objFocus != null && this == GameScreen.objFocus) || isFocus < 0;
			if (flag)
			{
				int num = 0;
				bool flag2 = this.Action == 4;
				if (flag2)
				{
					num = 5;
				}
				int num2 = this.y - this.dy - this.hOne - 18 + num;
				string text = this.name;
				bool isShowIndex = GameScreen.isShowIndex;
				if (isShowIndex)
				{
					text = string.Concat(new string[]
					{
						this.name,
						" ",
						this.ID.ToString(),
						" f=",
						this.frame.ToString()
					});
				}
				bool flag3 = GameScreen.isShowNameXpArena && this.typeObject == 0 && isFocus >= 0;
				if (flag3)
				{
					text = this.xpArena.ToString() + string.Empty;
				}
				int num3 = 0;
				bool flag4 = GameScreen.isShowNameSetting || isFocus < 0;
				if (flag4)
				{
					int num4 = 0;
					bool flag5 = this.clan != null && (GameCanvas.currentScreen == GameCanvas.listCharScr || LoadMap.specMap != 4);
					if (flag5)
					{
						num4 = 1;
					}
					bool flag6 = this.rankWanted < 100 && this.rankWanted >= 0 && isFocus >= 0;
					if (flag6)
					{
						num4 += 2;
					}
					bool flag7 = num4 > 0;
					if (flag7)
					{
						int num5 = mFont.tahoma_7b_black.getWidth(this.name) / 2;
						bool flag8 = !this.checkMapChiemDao() && isFocus >= 0;
						if (flag8)
						{
							num5 = 0;
						}
						switch (num4)
						{
						case 1:
							num3 = 10;
							this.paintIconClan(g, this.x - num5, num2 + 5);
							break;
						case 2:
							num3 = -10;
							this.paintIconWanted(g, this.x + num5, num2 + 6);
							break;
						case 3:
							this.paintIconWanted(g, this.x + num5 + 10, num2 + 6);
							this.paintIconClan(g, this.x - num5 - 10, num2 + 5);
							break;
						}
					}
					bool flag9 = this.checkMapChiemDao() || isFocus < 0;
					if (flag9)
					{
						bool flag10 = isFocus >= 0 && !GameScreen.isShowNameXpArena && this != GameScreen.player;
						if (flag10)
						{
							bool flag11 = Player.vecParty.size() > 0;
							if (flag11)
							{
								for (int i = 0; i < Player.vecParty.size(); i++)
								{
									InfoMemList infoMemList = (InfoMemList)Player.vecParty.elementAt(i);
									bool flag12 = infoMemList.name.CompareTo(this.name) == 0;
									if (flag12)
									{
										color = 4;
										break;
									}
								}
							}
							bool flag13 = Player.mSatnhan.Length != 0;
							if (flag13)
							{
								for (int j = 0; j < Player.mSatnhan.Length; j++)
								{
									bool flag14 = this.ID == Player.mSatnhan[j];
									if (flag14)
									{
										color = 6;
										break;
									}
								}
							}
						}
						bool flag15 = GameScreen.isShowNameXpArena && this.typeObject == 0 && isFocus >= 0;
						if (flag15)
						{
							color = this.colorXPArena;
						}
						bool flag16 = GameScreen.isShowNameWW && this.typeObject == 0 && isFocus >= 0 && this.checkWW <= 0 && this.typePK >= 11 && this.typePK <= 13;
						if (flag16)
						{
							color = 7;
							mFont.tahoma_7b_black.drawString(g, text, this.x + num3, num2, 2);
						}
						else
						{
							bool flag17 = isFocus == 1;
							if (flag17)
							{
								AvMain.FontBorderColor(g, text, this.x + num3, num2, 2, (int)color, 7);
							}
							else
							{
								bool flag18 = this.typeColor7 == 1 && isFocus == 0;
								if (flag18)
								{
									AvMain.FontSevenColor(g, text, this.x + num3, num2, 2, -1);
								}
								else
								{
									bool lowGraphic = GameCanvas.lowGraphic;
									if (lowGraphic)
									{
										AvMain.setTextColorName((int)color).drawString(g, text, this.x + num3, num2, 2);
									}
									else
									{
										AvMain.Font3dColor(g, text, this.x + num3, num2, 2, color);
									}
								}
							}
						}
						bool flag19 = isFocus >= 0;
						if (flag19)
						{
							this.paintIconPerfect(g, this.x + num3, num2 + 14);
						}
						bool flag20 = this.timeLeft > 0;
						if (flag20)
						{
							AvMain.Font3dColor(g, Interface_Game.ConvertTimeToStr(this.timeLeft), this.x + num3, num2 - 15, 2, 5);
						}
					}
				}
			}
			bool flag21 = isFocus >= 0;
			if (flag21)
			{
				this.paintIconPk_ThanhTich(g);
			}
		}
	}

	// Token: 0x060007C9 RID: 1993 RVA: 0x000A1540 File Offset: 0x0009F740
	public void paintThanhTich(mGraphics g, int yBegin, int xBegin)
	{
		int num = 0;
		bool flag = this.thanhtichPvP >= 0;
		if (flag)
		{
			bool flag2 = this.thanhtichPvP == 0;
			if (flag2)
			{
				g.drawRegion(AvMain.mImgThanhTich[0], 0, GameCanvas.gameTickChia4 % 3 * 15, 63, 15, 0, (float)xBegin, (float)yBegin, 3);
				num += 14;
			}
			else
			{
				bool flag3 = this.thanhtichPvP >= 1 && this.thanhtichPvP <= 3;
				if (flag3)
				{
					g.drawRegion(AvMain.mImgThanhTich[0], 0, (int)((this.thanhtichPvP + 2) * 15), 63, 15, 0, (float)xBegin, (float)yBegin, 3);
					num += 12;
				}
			}
		}
		bool flag4 = this.thanhtichLv >= 0;
		if (flag4)
		{
			bool flag5 = this.thanhtichLv == 0;
			if (flag5)
			{
				g.drawRegion(AvMain.mImgThanhTich[1], 0, GameCanvas.gameTickChia4 % 3 * 15, 52, 15, 0, (float)xBegin, (float)(yBegin - num), 3);
				num += 14;
			}
			else
			{
				bool flag6 = this.thanhtichLv >= 1 && this.thanhtichLv <= 3;
				if (flag6)
				{
					g.drawRegion(AvMain.mImgThanhTich[1], 0, (int)((this.thanhtichLv + 2) * 15), 52, 15, 0, (float)xBegin, (float)(yBegin - num), 3);
					num += 12;
				}
			}
		}
	}

	// Token: 0x060007CA RID: 1994 RVA: 0x000A1684 File Offset: 0x0009F884
	private bool checkMapChiemDao()
	{
		bool flag = LoadMap.specMap != 11;
		bool result;
		if (flag)
		{
			result = true;
		}
		else
		{
			bool flag2 = GameScreen.player == null || GameScreen.player == this;
			if (flag2)
			{
				result = true;
			}
			else
			{
				bool flag3 = this.clan == null || GameScreen.player.clan == null;
				if (flag3)
				{
					result = false;
				}
				else
				{
					bool flag4 = GameScreen.player.clan.ID == this.clan.ID;
					result = flag4;
				}
			}
		}
		return result;
	}

	// Token: 0x060007CB RID: 1995 RVA: 0x000A1710 File Offset: 0x0009F910
	private void paintIconPerfect(mGraphics g, int xp, int yp)
	{
		bool flag = this.levelPerfect > 0;
		if (flag)
		{
			sbyte b = (sbyte)(GameCanvas.gameTick % 40 / 4);
			sbyte b2 = (sbyte)(GameCanvas.gameTick / 20 % (AvMain.fraEffItem.nFrame / 2));
			for (int i = 0; i < (int)this.levelPerfect; i++)
			{
				int idx = (int)(b2 * 2 + (((int)b == i) ? 1 : 0));
				AvMain.fraEffItem.drawFrame(idx, xp - (int)((this.levelPerfect - 1) * 3) + i * 6, yp, 0, 3, g);
			}
		}
	}

	// Token: 0x060007CC RID: 1996 RVA: 0x000A1798 File Offset: 0x0009F998
	public void paintLV(mGraphics g, sbyte color)
	{
		AvMain.Font3dColor(g, T.Lv + " " + this.Lv.ToString(), this.x, this.y - this.dy - this.hOne - 28, 2, color);
	}

	// Token: 0x060007CD RID: 1997 RVA: 0x0000ABF6 File Offset: 0x00008DF6
	public void paintIconQuest(mGraphics g, int x)
	{
		AvMain.fraQuest.drawFrame((int)this.typeQuest, x, this.y - this.hOne - 31, 0, 3, g);
	}

	// Token: 0x060007CE RID: 1998 RVA: 0x0000AC1E File Offset: 0x00008E1E
	public void paintIconNPC(mGraphics g, int x)
	{
		AvMain.fraIconNpc.drawFrame((int)this.typeIconNPC, x, this.y - this.hOne - 30, 0, 3, g);
	}

	// Token: 0x060007CF RID: 1999 RVA: 0x000A17E8 File Offset: 0x0009F9E8
	public void paintIconPk_ThanhTich(mGraphics g)
	{
		int num = 8;
		int num2 = this.y - this.hOne - this.dy - 25;
		int num3 = 0;
		bool flag = LoadMap.specMap == 11;
		if (flag)
		{
			num2 -= 3;
		}
		bool flag2 = this.typePirate > -1 && this.typePirate <= 2;
		if (flag2)
		{
			num -= 8;
		}
		bool flag3 = this.typePK >= 0;
		if (flag3)
		{
			num = ((this.typePK <= 10) ? (num - 8) : (num - 9));
		}
		bool flag4 = this.timeSafe > 0;
		if (flag4)
		{
			num -= 8;
		}
		bool flag5 = !GameScreen.isShowNameSetting && this.clan != null;
		if (flag5)
		{
			num -= 10;
			num2 += 10;
			this.paintIconClan(g, this.x + num, num2);
			num += 16;
		}
		bool flag6 = this.typePirate > -1 && this.typePirate <= 2;
		if (flag6)
		{
			AvMain.fraPirate.drawFrame((int)this.typePirate, this.x + num, num2, 0, 3, g);
			num += 16;
			num3 = 14;
		}
		bool flag7 = this.typePK >= 0;
		if (flag7)
		{
			bool flag8 = this.typePK > 10;
			if (flag8)
			{
				bool flag9 = AvMain.fraPk2 == null;
				if (flag9)
				{
					AvMain.fraPk2 = LoadImageStatic.loadFraImage("/interface/iconpk2.png", 16, 16);
				}
				else
				{
					AvMain.fraPk2.drawFrame((int)((this.typePK - 11) * 3) + GameCanvas.gameTick / 6 % 3, this.x + num, num2 - 1, 0, 3, g);
				}
				num += 18;
			}
			else
			{
				AvMain.fraPk.drawFrame((int)(this.typePK * 3) + GameCanvas.gameTick / 4 % 3, this.x + num, num2 + 1, 0, 3, g);
				num += 16;
			}
			num3 = 14;
		}
		bool flag10 = this.timeSafe > 0;
		if (flag10)
		{
			bool flag11 = AvMain.imgSafe == null;
			if (flag11)
			{
				AvMain.imgSafe = mImage.createImage("/interface/safe.png");
			}
			else
			{
				g.drawImage(AvMain.imgSafe, this.x + num, num2, 3);
			}
			num3 = 14;
		}
		this.paintThanhTich(g, num2 - num3 - 2, this.x);
	}

	// Token: 0x060007D0 RID: 2000 RVA: 0x000A1A20 File Offset: 0x0009FC20
	private void paintIconClan(mGraphics g, int x2, int y2)
	{
		MainImage iconClan = Potion.getIconClan(this.clan.idIcon);
		bool flag = iconClan == null || iconClan.img == null;
		if (!flag)
		{
			bool flag2 = this.clan.borderIconClan >= 1;
			if (flag2)
			{
				AvMain.fraBorderClan2.drawFrameNew((int)(this.clan.borderIconClan - 1) * AvMain.fraBorderClan2.maxNumFrame + GameCanvas.gameTick / 3 % AvMain.fraBorderClan2.maxNumFrame, x2, y2, 0, 3, g);
			}
			int num = -1;
			bool flag3 = this.clan.chucvu == 0;
			if (flag3)
			{
				num = 10;
			}
			else
			{
				bool flag4 = this.clan.chucvu == 1;
				if (flag4)
				{
					num = 2;
				}
			}
			iconClan.set_W_H();
			bool flag5 = num != -1;
			if (flag5)
			{
				MainItem.eff_UpLv_Clan.paintUpgradeEffect(x2 - 1, y2, num, (int)((iconClan.w > 15) ? (iconClan.w + 2) : 15), g, 0, true);
			}
			bool flag6 = iconClan.frame == -1;
			if (flag6)
			{
				iconClan.set_Frame();
			}
			bool flag7 = iconClan.frame <= 1;
			if (flag7)
			{
				g.drawImage(iconClan.img, x2, y2 + 1, 3);
			}
			else
			{
				int num2 = (this.framepaint < (int)(iconClan.frame - 1)) ? 3 : 15;
				bool flag8 = CRes.abs(GameCanvas.gameTick - this.lastTick) > num2;
				if (flag8)
				{
					this.framepaint++;
					bool flag9 = this.framepaint >= (int)iconClan.frame;
					if (flag9)
					{
						this.framepaint = 0;
					}
					this.lastTick = GameCanvas.gameTick;
				}
				g.drawRegion(iconClan.img, 0, this.framepaint * (int)iconClan.w, (int)iconClan.w, (int)iconClan.w, 0, (float)x2, (float)(y2 + 1), 3);
			}
		}
	}

	// Token: 0x060007D1 RID: 2001 RVA: 0x000A1BFC File Offset: 0x0009FDFC
	private void paintIconWanted(mGraphics g, int x, int y)
	{
		bool flag = this.rankWanted == 0;
		if (flag)
		{
			int num = GameCanvas.gameTick / 6 % 10;
			bool flag2 = num > 3;
			if (flag2)
			{
				num = 0;
			}
			AvMain.fraIconWanted.drawFrame(num, x, y, 0, 3, g);
		}
		else
		{
			bool flag3 = this.rankWanted == 1;
			if (flag3)
			{
				int num2 = GameCanvas.gameTick / 6 % 10;
				bool flag4 = num2 > 2;
				if (flag4)
				{
					num2 = 0;
				}
				AvMain.fraIconWanted.drawFrame(4 + num2, x, y, 0, 3, g);
			}
			else
			{
				bool flag5 = this.rankWanted == 2;
				if (flag5)
				{
					AvMain.fraIconWanted.drawFrame(7, x, y, 0, 3, g);
				}
				else
				{
					bool flag6 = this.rankWanted < 10;
					if (flag6)
					{
						AvMain.fraIconWanted.drawFrame(8, x, y, 0, 3, g);
					}
					else
					{
						AvMain.fraIconWanted.drawFrame(9, x, y, 0, 3, g);
					}
				}
			}
		}
	}

	// Token: 0x060007D2 RID: 2002 RVA: 0x000A1CE4 File Offset: 0x0009FEE4
	public void paintCharShow(mGraphics g, int x, int y, int Dirr, bool isNhip)
	{
		this.paintDataEff(g, x, y, 1);
		this.paintEffFullSet(g, x + 1, y, 0);
		int fr = this.feStand[0];
		if (isNhip)
		{
			fr = this.feStand[GameCanvas.gameTick % this.feStand.Length];
		}
		this.updateEye();
		this.paintBody(g, x, y, fr, 0, isNhip);
		this.paintEffFullSet_Last(g, x + 1, y + 1, 0);
		this.paintDataEff(g, x, y, 0);
	}

	// Token: 0x060007D3 RID: 2003 RVA: 0x0000AC46 File Offset: 0x00008E46
	public void paintCharSelect(mGraphics g, int x, int y, int Dirr, int fr)
	{
		this.updateEye();
		this.paintBody(g, x, y, fr, Dirr, true);
	}

	// Token: 0x060007D4 RID: 2004 RVA: 0x000A1D60 File Offset: 0x0009FF60
	public override void update()
	{
		bool flag = this.typeActionBoat != 0;
		if (flag)
		{
			this.tickJoinSea++;
			bool flag2 = this.tickJoinSea >= 250;
			if (flag2)
			{
				this.setNextSea();
				this.tickJoinSea = 0;
			}
		}
		bool flag3 = this.timeDragon > 0;
		if (flag3)
		{
			this.timeDragon--;
			bool flag4 = this.timeDragon == 0;
			if (flag4)
			{
				this.frameOneStep = 7;
			}
		}
		bool flag5 = this.timeBeginUpdateMove >= 0;
		if (flag5)
		{
			this.timeBeginUpdateMove--;
		}
		this.x += this.vx;
		this.y += this.vy;
		this.updateChatPopup(this.dhCharPopup);
		bool flag6 = this.timeInviMove > 0;
		if (flag6)
		{
			this.timeInviMove--;
			bool flag7 = this.timeInviMove == 1;
			if (flag7)
			{
				this.x = this.toX;
				this.y = this.toY;
			}
			bool flag8 = this.timeInviMove == 0;
			if (flag8)
			{
				this.isTanHinh = false;
			}
		}
		this.updateBuff();
		this.updateEye();
		this.updateEffSpec();
		bool flag9 = this.checkBoatSea() && this.boatSea != null && this.boatSea.ID == this.ID;
		if (flag9)
		{
			this.boatSea.updateBoat();
			this.updateDySea();
			bool flag10 = this.Action != 2 && this.Action != 4;
			if (flag10)
			{
				this.left_right_Sea = this.type_left_right;
			}
			bool flag11 = this.Action != 2;
			if (flag11)
			{
				this.boatSea.updateXY(this.x, this.y, this.dySea / 10, (sbyte)this.left_right_Sea);
			}
			bool flag12 = this.typeActionBoat != 0 && GameCanvas.loadmap.getTile(this.x, this.y) == 0;
			if (flag12)
			{
				this.setSpeed(7, 7);
				this.typeActionBoat = 0;
			}
		}
		this.setHpEff();
		this.setEffDie();
		bool flag13 = this.Action == 1;
		if (flag13)
		{
			this.tickSoundMove++;
			bool flag14 = this.tickSoundMove >= 20;
			if (flag14)
			{
				this.tickSoundMove = 0;
				bool flag15 = this == GameScreen.player || CRes.random(5) == 0;
				if (flag15)
				{
					bool flag16 = LoadMap.specMap == 4;
					if (flag16)
					{
						mSound.playSound(31, mSound.volumeSound);
					}
					else
					{
						mSound.playSound(30, mSound.volumeSound);
					}
				}
			}
		}
		bool flag17 = GameCanvas.gameTick % 10 == 0;
		if (flag17)
		{
			this.updateTimeSafe();
		}
		this.updateEffFashion();
		this.updateDataEff();
		bool flag18 = this.timeLeft >= 0 && GameCanvas.timeNow - this.timeBegin >= 1000L;
		if (flag18)
		{
			this.timeBegin += 1000L;
			this.timeLeft--;
		}
	}

	// Token: 0x060007D5 RID: 2005 RVA: 0x000A209C File Offset: 0x000A029C
	private void updateEffFashion()
	{
		for (int i = 0; i < this.vecEffFashion.size(); i++)
		{
			MainEffect mainEffect = (MainEffect)this.vecEffFashion.elementAt(i);
			mainEffect.update();
			bool flag = mainEffect.isStop;
			if (flag)
			{
				this.vecEffFashion.removeElementAt(i);
				i--;
			}
		}
		sbyte b = this.typeEfffashion;
		bool flag2 = b != 1;
		if (!flag2)
		{
			bool flag3 = this.Action == 0;
			if (flag3)
			{
				this.tickEffFashion--;
				bool flag4 = this.tickEffFashion < 0;
				if (flag4)
				{
					this.tickEffFashion = 10 + CRes.random(25);
					this.vecEffFashion.addElement(GameScreen.createEffectEnd_ObjTo(161, (this.clazz == 4) ? 1 : 0, this.x, this.y, this.ID, this.typeObject, (sbyte)this.Dir, this));
				}
			}
			else
			{
				bool flag5 = this.Action == 1 && GameCanvas.gameTick % 2 == 0;
				if (flag5)
				{
					this.vecEffFashion.addElement(GameScreen.createEffectEnd_ObjTo(160, (this.clazz == 4) ? 1 : 0, this.x, this.y, this.ID, this.typeObject, (sbyte)this.Dir, this));
				}
			}
		}
	}

	// Token: 0x060007D6 RID: 2006 RVA: 0x000A2200 File Offset: 0x000A0400
	public void paintDataEff(mGraphics g, int x, int y, int type)
	{
		for (int i = 0; i < this.vecDataEff.size(); i++)
		{
			DataSkillEff dataSkillEff = (DataSkillEff)this.vecDataEff.elementAt(i);
			bool flag = dataSkillEff != null;
			if (flag)
			{
				bool flag2 = type == 0;
				if (flag2)
				{
					dataSkillEff.paintTopEff(g, x, y, this.hOne);
				}
				bool flag3 = type == 1;
				if (flag3)
				{
					dataSkillEff.paintBottomEff(g, x, y, this.hOne);
				}
			}
		}
	}

	// Token: 0x060007D7 RID: 2007 RVA: 0x000A2280 File Offset: 0x000A0480
	public void paintEffFashion(mGraphics g, int levelpaint)
	{
		for (int i = 0; i < this.vecEffFashion.size(); i++)
		{
			MainEffect mainEffect = (MainEffect)this.vecEffFashion.elementAt(i);
			bool flag = mainEffect.levelPaint == levelpaint;
			if (flag)
			{
				mainEffect.paint(g);
			}
		}
	}

	// Token: 0x060007D8 RID: 2008 RVA: 0x000A22D4 File Offset: 0x000A04D4
	public virtual void updateTimeSafe()
	{
		bool flag = this.timeSafe > 0 && (GameCanvas.timeNow - this.timeBeginSafe) / 1000L > (long)this.timeSafe;
		if (flag)
		{
			this.timeSafe = 0;
		}
	}

	// Token: 0x060007D9 RID: 2009 RVA: 0x000A2318 File Offset: 0x000A0518
	public void updateLoginShow()
	{
		this.x += this.vx;
		this.y += this.vy;
		this.move_to_XY_Normal();
		this.updateActionPerLogin();
		this.updateDirPaint();
		bool flag = this.vx == 0 && this.vy == 0 && this.Action == 1;
		if (flag)
		{
			this.Action = 0;
			this.f = 0;
		}
		bool flag2 = this.boatSea != null;
		if (flag2)
		{
			bool flag3 = this.Action == 0 && CRes.random(20) == 0;
			if (flag3)
			{
				int num = CRes.random(40, 120);
				this.toX = this.x + ((this.xAnchor >= 0) ? (-num) : num);
				this.toY = this.y + CRes.random_Am(24, 48);
				bool flag4 = this.toY < MotherCanvas.h - 170;
				if (flag4)
				{
					this.toY = MotherCanvas.h - 170;
				}
				bool flag5 = this.toY > MotherCanvas.h - 100;
				if (flag5)
				{
					this.toY = MotherCanvas.h - 100;
				}
				this.Action = 1;
			}
		}
		else
		{
			bool flag6 = this.Action == 0 && CRes.random(40) == 0;
			if (flag6)
			{
				bool flag7 = CRes.random(2) == 0;
				if (flag7)
				{
					MainSkill skill = new MainSkill(0, this.IdEffShow);
					this.plashNow = new Plash(skill, this, null, true);
					this.resetBeginFire();
					this.Action = 2;
				}
				else
				{
					int num2 = CRes.random(40, 120);
					this.toX = this.x + ((this.xAnchor >= 0) ? (-num2) : num2);
					this.toY = this.y + CRes.random_Am(24, 48);
					bool flag8 = this.toY < MotherCanvas.h - 70;
					if (flag8)
					{
						this.toY = MotherCanvas.h - 70;
					}
					bool flag9 = this.toY > MotherCanvas.h;
					if (flag9)
					{
						this.toY = MotherCanvas.h;
					}
					this.Action = 1;
				}
			}
		}
		bool flag10 = this.xAnchor < 0 && this.x > MotherCanvas.w + 30;
		if (flag10)
		{
			this.isRemove = true;
		}
		else
		{
			bool flag11 = this.xAnchor > 0 & this.x < -30;
			if (flag11)
			{
				this.isRemove = true;
			}
		}
	}

	// Token: 0x060007DA RID: 2010 RVA: 0x000A259C File Offset: 0x000A079C
	public void setEffDie()
	{
		bool flag = this.Action == 4 && !this.isDie;
		if (flag)
		{
			bool flag2 = this.vxDie > 0;
			if (flag2)
			{
				this.vxDie += 2;
			}
			else
			{
				this.vxDie -= 2;
			}
			this.xDie += this.vxDie;
			this.yDie += this.vyDie;
			this.dyDie += 10;
			this.timeDie += 1L;
			bool flag3 = this.timeDie >= 20L;
			if (flag3)
			{
				this.isDie = true;
				this.timeDie = 0L;
			}
		}
	}

	// Token: 0x060007DB RID: 2011 RVA: 0x000A2660 File Offset: 0x000A0860
	public virtual void updateDySea()
	{
		bool flag = CRes.random(40) == 0;
		if (flag)
		{
			bool flag2 = CRes.random(2) == 0;
			if (flag2)
			{
				this.vySea = 4;
			}
			else
			{
				this.vySea = -4;
			}
		}
		bool flag3 = this.dySea > 0 && this.vySea > 0;
		if (flag3)
		{
			this.vySea = -4;
		}
		else
		{
			bool flag4 = this.dySea < -50 && this.vySea < 0;
			if (flag4)
			{
				this.vySea = 4;
				bool flag5 = this.Action == 1;
				if (flag5)
				{
					this.boatSea.addEffSea(this.x, this.y, 0, (this.type_left_right == 0) ? 2 : 0, 0);
				}
				else
				{
					this.boatSea.addEffSea(this.x, this.y, 1, 0, 0);
				}
			}
		}
		this.dySea += this.vySea;
		bool flag6 = this.Action == 1;
		if (flag6)
		{
			bool flag7 = GameCanvas.gameTick % 8 == 0;
			if (flag7)
			{
				this.boatSea.addEffSea(this.x, this.y, -1, (sbyte)this.type_left_right, 0);
			}
			bool flag8 = CRes.random(8) == 0;
			if (flag8)
			{
				this.boatSea.addEffSea(this.x, this.y, 0, (this.type_left_right == 0) ? 2 : 0, 0);
			}
			bool flag9 = GameCanvas.gameTick % 6 == 0;
			if (flag9)
			{
				this.boatSea.addEffSea(this.x, this.y, 2, (sbyte)this.type_left_right, 0);
			}
		}
		else
		{
			bool flag10 = CRes.random(20) == 0;
			if (flag10)
			{
				this.boatSea.addEffSea(this.x, this.y, 1, 0, 0);
			}
		}
		bool flag11 = this.vy != 0;
		if (flag11)
		{
			this.boatSea.setLevelPaint();
		}
	}

	// Token: 0x060007DC RID: 2012 RVA: 0x000A2850 File Offset: 0x000A0A50
	public void updateEffSpec()
	{
		for (int i = 0; i < this.vecEffspec.size(); i++)
		{
			Effect_Spec effect_Spec = (Effect_Spec)this.vecEffspec.elementAt(i);
			effect_Spec.update();
			bool flag = effect_Spec.isRemove;
			if (flag)
			{
				this.vecEffspec.removeElement(effect_Spec);
				bool flag2 = effect_Spec.typeEffect == 15;
				if (flag2)
				{
					this.SetXlechEffectBongToi();
				}
			}
		}
	}

	// Token: 0x060007DD RID: 2013 RVA: 0x000A28C8 File Offset: 0x000A0AC8
	public void updateBuff()
	{
		for (int i = 0; i < this.vecBuffCur.size(); i++)
		{
			MainBuff mainBuff = (MainBuff)this.vecBuffCur.elementAt(i);
			mainBuff.update();
			bool flag = mainBuff.isRemove;
			if (flag)
			{
				bool isDevil = mainBuff.isDevil;
				if (isDevil)
				{
					this.setResetWearing();
					this.addEffBuff(3, 166, 0);
				}
				this.vecBuffCur.removeElement(mainBuff);
				i--;
			}
		}
	}

	// Token: 0x060007DE RID: 2014 RVA: 0x000A294C File Offset: 0x000A0B4C
	public void updateChatPopup(int dh)
	{
		bool flag = this.strChatPopup != null;
		if (flag)
		{
			this.addChat(this.strChatPopup, true);
			this.strChatPopup = null;
		}
		bool flag2 = this.chat != null;
		if (flag2)
		{
			this.chat.updatePos(this.x, this.y - this.hOne - dh);
			bool flag3 = this.chat.setOff() || (this.typeObject == 1 && this.Action == 4);
			if (flag3)
			{
				this.chat = null;
			}
		}
	}

	// Token: 0x060007DF RID: 2015 RVA: 0x000A29E0 File Offset: 0x000A0BE0
	public void updateDy()
	{
		bool flag = this.dy > 0;
		if (flag)
		{
			this.vDy -= 2;
			this.dy += this.vDy;
		}
		bool flag2 = this.dy < 0;
		if (flag2)
		{
			this.dy = -this.dy;
			this.vDy = 0;
		}
		bool flag3 = this.dy < 3;
		if (flag3)
		{
			this.dy = 0;
		}
	}

	// Token: 0x060007E0 RID: 2016 RVA: 0x000A2A58 File Offset: 0x000A0C58
	public void updatevXEffAva()
	{
		bool flag = !this.returnAction() && this.vXEffAva != 0 && this.x + this.vXEffAva > 0 && this.x + this.vXEffAva < GameCanvas.loadmap.maxWMap;
		if (flag)
		{
			this.x += this.vXEffAva;
			this.vXEffAva /= 2;
			bool flag2 = this.vXEffAva == 0;
			if (flag2)
			{
				this.toX = this.x;
				this.toY = this.y;
			}
		}
	}

	// Token: 0x060007E1 RID: 2017 RVA: 0x000A2AF0 File Offset: 0x000A0CF0
	public void setMove(int MonWater, int t)
	{
		bool flag = this.typeActionBoat != 0;
		if (!flag)
		{
			bool flag2 = (t == 1 || t == -1) && this.timeFreeMove < 12;
			if (flag2)
			{
				this.vx = 0;
				this.vy = 0;
				this.isDirMove = !this.isDirMove;
				this.timeFreeMove++;
				bool flag3 = this.timeFreeMove >= 10;
				if (flag3)
				{
					this.timeFreeMove = 25;
				}
			}
			else
			{
				bool flag4 = this.timeFreeMove > 0;
				if (flag4)
				{
					this.timeFreeMove--;
				}
			}
		}
	}

	// Token: 0x060007E2 RID: 2018 RVA: 0x000A2B94 File Offset: 0x000A0D94
	public bool setIsInScreen(int x, int y, int wOne, int hOne)
	{
		bool flag = x < MainScreen.cameraMain.xCam - wOne || x > MainScreen.cameraMain.xCam + MotherCanvas.w + wOne || y < MainScreen.cameraMain.yCam - hOne / 2 || y > MainScreen.cameraMain.yCam + MotherCanvas.h + hOne * 3 / 2;
		return !flag;
	}

	// Token: 0x060007E3 RID: 2019 RVA: 0x000A2C04 File Offset: 0x000A0E04
	public static bool isInScreen(MainObject obj)
	{
		bool flag = obj.x < MainScreen.cameraMain.xCam - obj.wOne || obj.x > MainScreen.cameraMain.xCam + MotherCanvas.w + obj.wOne || obj.y < MainScreen.cameraMain.yCam - obj.hOne || obj.y > MainScreen.cameraMain.yCam + MotherCanvas.h + obj.hOne * 3 / 2;
		return !flag;
	}

	// Token: 0x060007E4 RID: 2020 RVA: 0x000A2C98 File Offset: 0x000A0E98
	public static int getDistance(int x, int y, int x2, int y2)
	{
		return MainObject.getDistance(x - x2, y - y2);
	}

	// Token: 0x060007E5 RID: 2021 RVA: 0x000A2CB8 File Offset: 0x000A0EB8
	public static int getDistance(int x, int y)
	{
		return CRes.sqrt(x * x + y * y);
	}

	// Token: 0x060007E6 RID: 2022 RVA: 0x000A2CD8 File Offset: 0x000A0ED8
	public static MainObject get_Object(int ID, sbyte tem)
	{
		for (int i = GameScreen.vecPlayers.size() - 1; i >= 0; i--)
		{
			bool flag = i != GameScreen.vecPlayers.size();
			if (flag)
			{
				MainObject mainObject = (MainObject)GameScreen.vecPlayers.elementAt(i);
				bool flag2 = mainObject != null && mainObject.typeObject == tem;
				if (flag2)
				{
					short num = mainObject.ID;
					bool flag3 = tem == 10;
					if (flag3)
					{
						num = mainObject.IDMainShiper;
					}
					bool flag4 = (int)num == ID;
					if (flag4)
					{
						bool flag5 = mainObject.isRemove || mainObject.isStop;
						MainObject result;
						if (flag5)
						{
							result = null;
						}
						else
						{
							result = mainObject;
						}
						return result;
					}
				}
			}
		}
		return null;
	}

	// Token: 0x060007E7 RID: 2023 RVA: 0x000A2D9C File Offset: 0x000A0F9C
	public void addChat(string str, bool isStop)
	{
		bool flag = this.chat == null;
		if (flag)
		{
			this.chat = new PopupChat();
		}
		short num = GlobalService.CheckEmotion(str);
		bool flag2 = num == -1;
		if (flag2)
		{
			this.chat.setChat(str, isStop);
		}
		else
		{
			this.chat.setChat(num);
		}
		this.chat.updatePos(this.x, this.y - this.hOne - 30);
	}

	// Token: 0x060007E8 RID: 2024 RVA: 0x000A2E18 File Offset: 0x000A1018
	public void addChatItem(short idIconChat, sbyte cat, short num)
	{
		try
		{
			bool flag = this.chat == null;
			if (flag)
			{
				this.chat = new PopupChat();
			}
			this.chat.setChatItem(idIconChat, cat, num);
			this.chat.updatePos(this.x, this.y - this.hOne - 30);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x060007E9 RID: 2025 RVA: 0x000A2E8C File Offset: 0x000A108C
	public void move_to_XY()
	{
		bool flag = CRes.abs(this.x - this.toX) > this.vMax;
		if (flag)
		{
			this.vy = 0;
			this.Action = 1;
			bool flag2 = CRes.abs(this.x - this.toX) > this.vMax;
			if (flag2)
			{
				bool flag3 = this.x > this.toX;
				if (flag3)
				{
					this.vx = -this.vMax;
					this.Dir = 0;
				}
				else
				{
					this.vx = this.vMax;
					this.Dir = 2;
				}
			}
			else
			{
				this.vx = this.toX - this.x;
			}
		}
		else
		{
			bool flag4 = CRes.abs(this.y - this.toY) > this.vMax;
			if (flag4)
			{
				this.vx = 0;
				this.Action = 1;
				bool flag5 = CRes.abs(this.y - this.toY) > this.vMax;
				if (flag5)
				{
					bool flag6 = this.y > this.toY;
					if (flag6)
					{
						bool flag7 = this.checkBoatSea();
						if (flag7)
						{
							this.vy = -this.vMaxYSea;
						}
						else
						{
							this.vy = -this.vMax;
						}
						this.Dir = 1;
					}
					else
					{
						bool flag8 = LoadMap.specMap == 4 || this.typeActionBoat != 0 || GameCanvas.currentScreen == GameCanvas.loginScr;
						if (flag8)
						{
							this.vy = this.vMaxYSea;
						}
						else
						{
							this.vy = this.vMax;
						}
						this.Dir = 3;
					}
				}
				else
				{
					this.vy = this.toY - this.y;
				}
			}
			else
			{
				this.vx = 0;
				this.vy = 0;
			}
		}
	}

	// Token: 0x060007EA RID: 2026 RVA: 0x000A305C File Offset: 0x000A125C
	public bool returnAction()
	{
		return this.isRemove || this.isStop || (this.typeObject == 0 && !this.isInfo);
	}

	// Token: 0x060007EB RID: 2027 RVA: 0x000A30A0 File Offset: 0x000A12A0
	public void paintHPFocus(mGraphics g)
	{
		bool flag = !this.isTanHinh;
		if (flag)
		{
			int num = this.y - this.dy - this.hOne - 4;
			int num2 = 40;
			int hrect = 4;
			bool flag2 = this.levelPerfect > 0;
			if (flag2)
			{
				num += 4;
			}
			int num3 = this.x - num2 / 2;
			num2 = 30;
			num3 = this.x - num2 / 2;
			sbyte type = 102;
			bool flag3 = this.Lv >= 100;
			if (flag3)
			{
				type = 106;
			}
			Interface_Game.PaintHPMP(g, type, this.Hp, this.maxHp, num3, num, 0, hrect, num2, -1, false, 0, false, (int)this.lvHeart);
		}
	}

	// Token: 0x060007EC RID: 2028 RVA: 0x000A3150 File Offset: 0x000A1350
	public void resetXY()
	{
		this.toX = this.x;
		this.toY = this.y;
		this.toXNew = this.x;
		this.toYNew = this.y;
		this.vx = 0;
		this.vy = 0;
	}

	// Token: 0x060007ED RID: 2029 RVA: 0x000A319C File Offset: 0x000A139C
	public virtual void beginDie(MainObject objFire)
	{
		this.resetAction();
		bool flag = this.isTanHinh;
		if (flag)
		{
			this.isTanHinh = false;
		}
		bool flag2 = this.Action != 4;
		if (flag2)
		{
			this.Action = 4;
		}
		bool flag3 = !this.isFlyDie;
		if (flag3)
		{
			this.isFlyDie = true;
			this.isDie = false;
			this.timeDie = 0L;
			this.xDie = this.x;
			this.yDie = this.y;
			this.vyDie = -12;
			this.dyDie = 0;
			bool flag4 = objFire == null || objFire.x < this.x;
			if (flag4)
			{
				this.vxDie = 12;
				GameScreen.addEffectEnd(82, 0, this.x + 10, this.y, 2, this);
			}
			else
			{
				this.vxDie = -12;
				GameScreen.addEffectEnd(82, 0, this.x - 10, this.y, 0, this);
			}
		}
	}

	// Token: 0x060007EE RID: 2030 RVA: 0x000A3290 File Offset: 0x000A1490
	public virtual void resetAction()
	{
		this.f = 0;
		this.vx = (this.vy = 0);
		this.toX = this.x;
		this.toY = this.y;
		bool flag = this.Action != 2 && this.Action != 4 && this.Action != 3;
		if (flag)
		{
			this.Action = 0;
			this.weapon_frame = 0;
		}
	}

	// Token: 0x060007EF RID: 2031 RVA: 0x000A3304 File Offset: 0x000A1504
	public void resetBeginFire()
	{
		this.vx = (this.vy = 0);
		this.toX = this.x;
		this.toY = this.y;
	}

	// Token: 0x060007F0 RID: 2032 RVA: 0x000A333C File Offset: 0x000A153C
	public void move_to_XY_Normal()
	{
		bool flag = this.isDirMove;
		if (flag)
		{
			bool flag2 = CRes.abs(this.x - this.toX) >= this.vMax;
			if (flag2)
			{
				this.moveX();
			}
			else
			{
				bool flag3 = CRes.abs(this.y - this.toY) >= this.vMax;
				if (flag3)
				{
					this.moveY();
				}
				else
				{
					this.vx = 0;
					this.vy = 0;
				}
			}
		}
		else
		{
			bool flag4 = CRes.abs(this.y - this.toY) >= this.vMax;
			if (flag4)
			{
				this.moveY();
			}
			else
			{
				bool flag5 = CRes.abs(this.x - this.toX) >= this.vMax;
				if (flag5)
				{
					this.moveX();
				}
				else
				{
					this.vx = 0;
					this.vy = 0;
				}
			}
		}
	}

	// Token: 0x060007F1 RID: 2033 RVA: 0x000A342C File Offset: 0x000A162C
	public void moveX()
	{
		this.vy = 0;
		this.Action = 1;
		bool flag = CRes.abs(this.x - this.toX) >= this.vMax;
		if (flag)
		{
			bool flag2 = this.x >= this.toX;
			if (flag2)
			{
				this.vx = -this.vMax;
				this.Dir = 0;
			}
			else
			{
				this.vx = this.vMax;
				this.Dir = 2;
			}
		}
		else
		{
			this.vx = this.toX - this.x;
		}
	}

	// Token: 0x060007F2 RID: 2034 RVA: 0x000A34C4 File Offset: 0x000A16C4
	public void moveY()
	{
		this.vx = 0;
		this.Action = 1;
		bool flag = CRes.abs(this.y - this.toY) >= this.vMax;
		if (flag)
		{
			bool flag2 = this.y > this.toY;
			if (flag2)
			{
				bool flag3 = this.checkBoatSea();
				if (flag3)
				{
					this.vy = -this.vMaxYSea;
				}
				else
				{
					this.vy = -this.vMax;
				}
				this.Dir = 1;
			}
			else
			{
				bool flag4 = this.checkBoatSea();
				if (flag4)
				{
					this.vy = this.vMaxYSea;
				}
				else
				{
					this.vy = this.vMax;
				}
				this.Dir = 3;
			}
		}
		else
		{
			this.vy = this.toY - this.y;
		}
	}

	// Token: 0x060007F3 RID: 2035 RVA: 0x000A3594 File Offset: 0x000A1794
	public void getSpeedforRun(int max)
	{
		switch (this.Dir)
		{
		case 0:
			this.vy = 0;
			this.vx = -max;
			break;
		case 1:
			this.vy = -max;
			this.vx = 0;
			break;
		case 2:
			this.vy = 0;
			this.vx = max;
			break;
		case 3:
			this.vy = max;
			this.vx = 0;
			break;
		}
	}

	// Token: 0x060007F4 RID: 2036 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void addSkillFire(MainSkill skill, mVector vec)
	{
	}

	// Token: 0x060007F5 RID: 2037 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void setDataBeginSkill(MainSkill skill, mVector vec)
	{
	}

	// Token: 0x060007F6 RID: 2038 RVA: 0x000A3608 File Offset: 0x000A1808
	public virtual void Reveive()
	{
		this.isFlyDie = false;
		this.vecSkillFires.removeAllElements();
		this.vecBuffCur.removeAllElements();
		this.vecEffspec.removeAllElements();
		this.setResetWearing();
		this.Action = 0;
		this.timeBeginUpdateMove = -1;
		this.Mp = this.maxMp;
		this.Hp = this.maxHp;
		GameScreen.addEffectEnd_ObjTo(83, 0, 0, 0, this.ID, this.typeObject, (sbyte)this.Dir, this);
		bool flag = this == GameScreen.player;
		if (flag)
		{
			GlobalService.gI().Obj_Move((short)this.x, (short)this.y);
		}
	}

	// Token: 0x060007F7 RID: 2039 RVA: 0x000A36B4 File Offset: 0x000A18B4
	public virtual void paintInfoFocus(mGraphics g, int xp, int yp)
	{
		int num = 0;
		int isNum = 3;
		int num2 = 0;
		bool isTaiTho = GameCanvas.isTaiTho;
		if (isTaiTho)
		{
			num2 = 5;
		}
		bool flag = this.typePK >= 11 && this.typePK <= 13;
		if (flag)
		{
			AvMain.paintnenFocus(g, MotherCanvas.w - this.wNameFocus - 4 - num2, yp - 1, this.wNameFocus, 45);
			mFont.tahoma_7_green.drawString(g, string.Empty + this.killWW.ToString(), MotherCanvas.w - this.wNameFocus / 2 - 3 - 4 - num2, yp + 32, 1);
			mFont.tahoma_7_red.drawString(g, string.Empty + this.deadWW.ToString(), MotherCanvas.w - this.wNameFocus / 2 - 3 + 4 - num2, yp + 32, 0);
			mFont.tahoma_7_white.drawString(g, "-", MotherCanvas.w - this.wNameFocus / 2 - 3 - num2, yp + 32, 2);
		}
		else
		{
			AvMain.paintnenFocus(g, MotherCanvas.w - this.wNameFocus - 4 - num2, yp - 1, this.wNameFocus, 36);
		}
		sbyte b = 102;
		bool flag2 = GameCanvas.isSmallScreen && this.typeObject != 2;
		if (flag2)
		{
			AvMain.Font3dWhite(g, this.name + " (" + this.Lv.ToString() + ")", xp + 48, yp, 1);
			yp += 13;
		}
		else
		{
			string str = this.name;
			bool flag3 = this.isNPC_Area() == 99;
			if (flag3)
			{
				str = T.Area + " " + LoadMap.getAreaPaint().ToString();
			}
			bool flag4 = this.typeObject != 2;
			if (flag4)
			{
				sbyte color = 0;
				bool flag5 = this.typeObject == 1;
				if (flag5)
				{
					int num3 = this.Lv - GameScreen.player.Lv;
					bool flag6 = num3 > 0;
					if (flag6)
					{
						color = ((num3 <= 2) ? 5 : ((num3 > 4) ? 6 : 3));
					}
				}
				isNum = 2;
				AvMain.Font3dColor(g, str, MotherCanvas.w - this.wNameFocus / 2 - 3 - num2, yp + 1, 2, color);
				yp += GameCanvas.hText;
				bool flag7 = this.Lv >= 100;
				if (flag7)
				{
					g.drawRegion(Interface_Game.imgIconMPHP2, 0, 22, 10, 11, 0, (float)(xp - 14), (float)(yp + 5), 3);
					AvMain.Font3dColor(g, string.Empty + this.LvThongThao.ToString(), xp - 1, yp - 3, 2, 1);
					b = 106;
				}
				else
				{
					AvMain.Font3dWhite(g, T.Lv + this.Lv.ToString(), xp - 6, yp - 3, 2);
				}
			}
			else
			{
				num = 14;
				AvMain.Font3dWhite(g, str, MotherCanvas.w - this.wNameFocus / 2 - 3 - num2, yp + 1, 2);
				yp += GameCanvas.hText;
			}
		}
		bool flag8 = this.isNPC_Area() == 99;
		if (flag8)
		{
			g.setColor(13350814);
			g.fillRect(xp + 8 - num - 2, yp - 1, 46, 8);
			Interface_Game.PaintHPMP(g, 102, (int)LoadMap.numPlayerMap, (int)LoadMap.maxnumPlayerMap, xp + 8 - num - 1, yp, 10, 6, 44, isNum, false, this.HpEff, false, 0);
		}
		else
		{
			bool flag9 = this.isNPC_Area() == 0 || this.isNPC_Area() == 2;
			if (flag9)
			{
				bool flag10 = LoadMap.mStrNameMapNPC != null;
				if (flag10)
				{
					int num4 = 0;
					int num5 = GameCanvas.hText;
					bool flag11 = LoadMap.mStrNameMapNPC.Length >= 2;
					if (flag11)
					{
						num4 = 3;
						num5 -= 3;
					}
					for (int i = 0; i < LoadMap.mStrNameMapNPC.Length; i++)
					{
						AvMain.Font3dSmall(g, LoadMap.mStrNameMapNPC[i], xp + 17, yp - num4 + (GameCanvas.hText - num4) * i, 2, 0);
					}
				}
			}
			else
			{
				g.setColor(13350814);
				g.fillRect(xp + 9 - num - 2, yp - 2, 46, 8);
				Interface_Game.PaintHPMP(g, (!GameCanvas.lowGraphic) ? b : 104, this.Hp, this.maxHp, xp + 9 - num - 1, yp - 1, 10, 6, 44, isNum, false, this.HpEff, false, (int)this.lvHeart);
			}
		}
	}

	// Token: 0x060007F8 RID: 2040 RVA: 0x000A3B0C File Offset: 0x000A1D0C
	public void paintChar(mGraphics g, int x, int y)
	{
		bool flag = false;
		int num = 1;
		bool flag2 = this.timeFullSet >= 40 || (this.timeFullSet > 34 && this.timeFullSet % 3 != 2) || this.indexFullSet >= 4;
		if (flag2)
		{
			bool flag3 = this.type_left_right == 2;
			if (flag3)
			{
				num = -1;
			}
			flag = true;
		}
		bool flag4 = flag;
		if (flag4)
		{
			this.paintEffFullSet(g, x + num, y, this.type_left_right);
		}
		this.paintDataEff(g, x, y, 1);
		bool flag5 = !this.checPaintByDataEff();
		if (flag5)
		{
			this.paintBody(g, x, y, this.frame, this.type_left_right, true);
		}
		bool flag6 = flag;
		if (flag6)
		{
			this.paintEffFullSet_Last(g, x + num, y + 1, this.type_left_right);
		}
		this.paintDataEff(g, x, y, 0);
	}

	// Token: 0x060007F9 RID: 2041 RVA: 0x000A3BDC File Offset: 0x000A1DDC
	public bool checPaintByDataEff()
	{
		bool flag = this.vecDataEff.size() == 0;
		bool result;
		if (flag)
		{
			result = false;
		}
		else
		{
			for (int i = 0; i < this.vecDataEff.size(); i++)
			{
				DataSkillEff dataSkillEff = (DataSkillEff)this.vecDataEff.elementAt(i);
				bool flag2 = dataSkillEff != null && dataSkillEff.typeMove == 2;
				if (flag2)
				{
					return true;
				}
			}
			result = false;
		}
		return result;
	}

	// Token: 0x060007FA RID: 2042 RVA: 0x000A3C50 File Offset: 0x000A1E50
	public void paintEffFullSet(mGraphics g, int x2, int y2, int typeLeftRight)
	{
		bool flag = this.indexFullSet <= 0;
		if (!flag)
		{
			int num = GameCanvas.gameTick / 5 % 3;
			int num2 = 0;
			bool flag2 = this.indexFullSet == 5;
			if (flag2)
			{
				for (int i = 2; i >= 0; i--)
				{
					bool flag3 = MainObject.mfraImgFullSet[2 + i] == null || MainObject.mfraImgFullSet[2 + i].imgFrame == null || MainObject.mfraImgFullSet[2 + i].imgFrame.image == null;
					if (flag3)
					{
						MainObject.mfraImgFullSet[2 + i] = new FrameImage(373 + i, 3);
					}
					else
					{
						bool flag4 = CRes.random(10) != 2;
						if (flag4)
						{
							bool flag5 = this.lechYHead != 0;
							if (flag5)
							{
								num2 = 6;
								g.drawRegion(MainObject.mfraImgFullSet[2 + i].imgFrame, 0, MainObject.mfraImgFullSet[2 + i].frameHeight - 8 + num * MainObject.mfraImgFullSet[2 + i].frameHeight, MainObject.mfraImgFullSet[2 + i].frameWidth, 8, this.type_left_right, (float)x2, (float)y2, 33);
							}
							MainObject.mfraImgFullSet[2 + i].drawFrame(num, x2, y2 - num2, this.type_left_right, 33, g);
						}
					}
				}
			}
			else
			{
				bool flag6 = MainObject.mfraImgFullSet[(int)(this.indexFullSet - 1)] == null || MainObject.mfraImgFullSet[(int)(this.indexFullSet - 1)].imgFrame == null || MainObject.mfraImgFullSet[(int)(this.indexFullSet - 1)].imgFrame.image == null;
				if (flag6)
				{
					MainObject.mfraImgFullSet[(int)(this.indexFullSet - 1)] = new FrameImage(370 + (int)this.indexFullSet, 3);
				}
				else
				{
					bool flag7 = this.lechYHead != 0;
					if (flag7)
					{
						num2 = 6;
						g.drawRegion(MainObject.mfraImgFullSet[(int)(this.indexFullSet - 1)].imgFrame, 0, MainObject.mfraImgFullSet[(int)(this.indexFullSet - 1)].frameHeight - 8 + num * MainObject.mfraImgFullSet[(int)(this.indexFullSet - 1)].frameHeight, MainObject.mfraImgFullSet[(int)(this.indexFullSet - 1)].frameWidth, 8, this.type_left_right, (float)x2, (float)y2, 33);
					}
					MainObject.mfraImgFullSet[(int)(this.indexFullSet - 1)].drawFrame(num, x2, y2 - num2, this.type_left_right, 33, g);
				}
			}
		}
	}

	// Token: 0x060007FB RID: 2043 RVA: 0x000A3EC0 File Offset: 0x000A20C0
	public void paintEffFullSet_Last(mGraphics g, int x2, int y2, int typeLeftRight)
	{
		bool flag = this.indexFullSet <= 0;
		if (!flag)
		{
			int num = GameCanvas.gameTickChia4 % 3;
			int num2 = 0;
			bool flag2 = MainObject.mfraImgFullSet[(int)(5 + this.indexFullSet - 1)] == null || MainObject.mfraImgFullSet[(int)(5 + this.indexFullSet - 1)].imgFrame == null || MainObject.mfraImgFullSet[(int)(5 + this.indexFullSet - 1)].imgFrame.image == null;
			if (flag2)
			{
				MainObject.mfraImgFullSet[(int)(5 + this.indexFullSet - 1)] = new FrameImage(375 + (int)this.indexFullSet, 3);
			}
			else
			{
				bool flag3 = this.lechYHead != 0;
				if (flag3)
				{
					g.drawRegion(MainObject.mfraImgFullSet[(int)(5 + this.indexFullSet - 1)].imgFrame, 0, MainObject.mfraImgFullSet[(int)(5 + this.indexFullSet - 1)].frameHeight - 8 + num * MainObject.mfraImgFullSet[(int)(5 + this.indexFullSet - 1)].frameHeight, MainObject.mfraImgFullSet[(int)(5 + this.indexFullSet - 1)].frameWidth, 8, this.type_left_right, (float)x2, (float)y2, 33);
				}
				MainObject.mfraImgFullSet[(int)(5 + this.indexFullSet - 1)].drawFrame(num, x2, y2 - num2, this.type_left_right, 33, g);
			}
		}
	}

	// Token: 0x060007FC RID: 2044 RVA: 0x000A4008 File Offset: 0x000A2208
	public void paintPhiPhong(mGraphics g)
	{
		MainImage imageAll = ObjectData.getImageAll(this.idparP, ObjectData.HashImageOtherNew, 23000);
		bool flag = imageAll != null && imageAll.img != null;
		if (flag)
		{
			int num = 1;
			int num2 = 1;
			int num3 = mImage.getImageWidth(imageAll.img.image) / num;
			int num4 = mImage.getImageHeight(imageAll.img.image) / num2;
			bool flag2 = this.FramePP >= 0 && (int)this.FramePP < num * num2;
			if (flag2)
			{
				int x = (int)this.FramePP / num2 * num3;
				int y = (int)this.FramePP % num2 * num4;
				int arg = (this.type_left_right == 2) ? 2 : 0;
				g.drawRegion(imageAll.img, x, y, this.wOne, this.hOne, arg, (float)this.x, (float)this.y, mGraphics.TOP | mGraphics.HCENTER);
			}
		}
	}

	// Token: 0x060007FD RID: 2045 RVA: 0x000A40F8 File Offset: 0x000A22F8
	public void updatePP()
	{
		bool flag = this.Action == 0 || this.Action == 1 || this.Action == 2;
		if (flag)
		{
			this.fPP += 1;
			bool flag2 = (int)this.fPP > MainObject.AR_FRAME_PP[this.Action].Length - 1;
			if (flag2)
			{
				this.fPP = 0;
			}
			this.FramePP = (short)MainObject.AR_FRAME_PP[this.Action][(int)this.fPP];
		}
	}

	// Token: 0x060007FE RID: 2046 RVA: 0x000A4178 File Offset: 0x000A2378
	public void paintBody(mGraphics g, int x, int y, int fr, int dirr, bool isEye)
	{
		int num = (dirr == 2) ? 2 : 0;
		int num2 = fr;
		bool flag = this.frameOneStep != -1;
		if (flag)
		{
			num2 = this.frameOneStep;
			this.ntickFrameOneStep++;
			bool flag2 = this.ntickFrameOneStep >= 2;
			if (flag2)
			{
				this.ntickFrameOneStep = 0;
				this.frameOneStep = -1;
			}
		}
		int num3 = 0;
		int arg = 0;
		bool flag3 = num == 0;
		int[] array;
		int num4;
		if (flag3)
		{
			array = this.mSortPaint;
			num4 = (int)(3 + this.dxEye);
		}
		else
		{
			array = this.mSortPaintRight;
			num3 = 24;
			arg = 2;
			num4 = (int)(-8 - this.dxEye);
		}
		foreach (int num5 in array)
		{
			mPart mPart = this.partLow(num5);
			int num6 = num5;
			bool flag4 = num5 == 6;
			if (flag4)
			{
				num6 = 3;
			}
			bool flag5 = (this.isDonotShowHat == 0 && this.isDragon && ((this.timeDragon <= 0 && num6 == 5) || (this.timeDragon > 0 && num6 == 4))) || mPart == null || mPart.pi == null;
			if (!flag5)
			{
				int num7 = y + MainObject.CharInfo[num2][num6][2] + (int)mPart.pi[MainObject.CharInfo[num2][num6][0]].dy;
				int num8 = (num != 0) ? (x - MainObject.CharInfo[num2][num6][1] - (int)mPart.pi[MainObject.CharInfo[num2][num6][0]].dx) : (x + MainObject.CharInfo[num2][num6][1] + (int)mPart.pi[MainObject.CharInfo[num2][num6][0]].dx);
				bool flag6 = num5 == 3 && this.lechYHead != 0 && this.clazz != 1 && this.clazz != 0;
				if (flag6)
				{
					num8 = ((num != 0) ? (num8 - (int)MainObject.fLechWeaponBigBody[(int)(this.clazz - 2)][num2 * 2]) : (num8 + (int)MainObject.fLechWeaponBigBody[(int)(this.clazz - 2)][num2 * 2]));
					num7 += (int)MainObject.fLechWeaponBigBody[(int)(this.clazz - 2)][num2 * 2 + 1];
				}
				bool flag7 = (num6 == 0 || num6 == 5 || num6 == 4) && (num6 != 0 || !this.isKoLechHead);
				if (flag7)
				{
					num7 += (int)this.lechYHead;
				}
				bool flag8 = num6 == 5 && (this.body == 950 || this.body == 963 || this.body == 972);
				if (flag8)
				{
					num7 -= 20;
					num8 = ((num != 0) ? (num8 + 5) : (num8 - 5));
				}
				short num9 = this.checkEffHair();
				short num10 = this.checkPlayFrameBody();
				short num11 = this.checkPlayFrameLeg();
				short num12 = this.checkPlayFrameWeapon();
				short num13 = this.checkPlayFrameHead();
				bool flag9 = true;
				bool flag10 = num5 == 5 && num9 >= 0 && this.checkCF(num2);
				if (flag10)
				{
					bool flag11 = this.imgEffHair == null || this.imgEffHair.img == null;
					if (flag11)
					{
						this.imgEffHair = ObjectData.getImageAll(num9, ObjectData.HashImageOtherNew, 23000);
					}
					bool flag12 = this.imgEffHair.img != null;
					if (flag12)
					{
						MainImage imageAll = ObjectData.getImageAll(mPart.pi[MainObject.CharInfo[num2][num6][0]].id, ObjectData.HashImageCharPart, 10000);
						bool flag13 = imageAll.img != null;
						if (flag13)
						{
							bool flag14 = this.nFrameEffHair == 0;
							if (flag14)
							{
								this.imgEffHair.img.w = mImage.getImageWidth(imageAll.img.image);
								this.imgEffHair.img.h = mImage.getImageHeight(imageAll.img.image);
								this.nFrameEffHair = mImage.getImageHeight(this.imgEffHair.img.image) / this.imgEffHair.img.h;
							}
							else
							{
								bool flag15 = GameCanvas.gameTickChia4 % (this.nFrameEffHair + 1) < this.nFrameEffHair;
								if (flag15)
								{
									g.drawRegion(this.imgEffHair.img, 0, this.imgEffHair.img.h * (GameCanvas.gameTickChia4 % (this.nFrameEffHair + 1)), this.imgEffHair.img.w, this.imgEffHair.img.h, num, (float)num8, (float)num7, num3);
									flag9 = false;
								}
							}
						}
					}
				}
				else
				{
					bool flag16 = num5 == 2 && num10 >= 0 && this.checkCFBody(num2) && !this.isBuffDevil;
					if (flag16)
					{
						bool flag17 = this.imgEffPlayBody == null || this.imgEffPlayBody.img == null;
						if (flag17)
						{
							this.imgEffPlayBody = ObjectData.getImageAll(num10, ObjectData.HashImageOtherNew, 23000);
						}
						bool flag18 = this.imgEffPlayBody.img != null;
						if (flag18)
						{
							MainImage imageAll2 = ObjectData.getImageAll(mPart.pi[MainObject.CharInfo[num2][num6][0]].id, ObjectData.HashImageCharPart, 10000);
							bool flag19 = imageAll2.img != null;
							if (flag19)
							{
								bool flag20 = this.nFrameEffBody == 0;
								if (flag20)
								{
									this.imgEffPlayBody.img.w = mImage.getImageWidth(this.imgEffPlayBody.img.image);
									this.imgEffPlayBody.img.h = mImage.getImageHeight(imageAll2.img.image);
									this.nFrameEffBody = mImage.getImageHeight(this.imgEffPlayBody.img.image) / this.imgEffPlayBody.img.h;
								}
								else
								{
									bool flag21 = this.mPlayframeBody[this.indexPlayMBody][this.tickPlayframeBody] < this.nFrameEffBody;
									if (flag21)
									{
										g.drawRegion(this.imgEffPlayBody.img, 0, this.imgEffPlayBody.img.h * this.mPlayframeBody[this.indexPlayMBody][this.tickPlayframeBody], this.imgEffPlayBody.img.w, this.imgEffPlayBody.img.h, num, (float)num8, (float)num7, num3);
										flag9 = false;
									}
								}
							}
						}
					}
					else
					{
						bool flag22 = num5 == 1 && num11 >= 0 && this.checkCFLeg(num2);
						if (flag22)
						{
							bool flag23 = this.imgEffPlayLeg == null || this.imgEffPlayLeg.img == null;
							if (flag23)
							{
								this.imgEffPlayLeg = ObjectData.getImageAll(num11, ObjectData.HashImageOtherNew, 23000);
							}
							bool flag24 = this.imgEffPlayLeg.img != null;
							if (flag24)
							{
								MainImage imageAll3 = ObjectData.getImageAll(mPart.pi[MainObject.CharInfo[num2][num6][0]].id, ObjectData.HashImageCharPart, 10000);
								bool flag25 = imageAll3.img != null;
								if (flag25)
								{
									bool flag26 = this.nFrameEffLeg == 0;
									if (flag26)
									{
										this.imgEffPlayLeg.img.w = mImage.getImageWidth(this.imgEffPlayLeg.img.image);
										this.imgEffPlayLeg.img.h = mImage.getImageHeight(imageAll3.img.image);
										this.nFrameEffLeg = mImage.getImageHeight(this.imgEffPlayLeg.img.image) / this.imgEffPlayLeg.img.h;
									}
									else
									{
										bool flag27 = this.mPlayframeBody[this.indexPlayMBody][this.tickPlayframeBody] < this.nFrameEffLeg;
										if (flag27)
										{
											g.drawRegion(this.imgEffPlayLeg.img, 0, this.imgEffPlayLeg.img.h * this.mPlayframeBody[this.indexPlayMBody][this.tickPlayframeBody], this.imgEffPlayLeg.img.w, this.imgEffPlayLeg.img.h, num, (float)num8, (float)num7, num3);
											flag9 = false;
										}
									}
								}
							}
						}
						else
						{
							bool flag28 = num5 == 0 && num13 >= 0 && this.checkCFHead(num2);
							if (flag28)
							{
								bool flag29 = this.imgEffHead == null || this.imgEffHead.img == null;
								if (flag29)
								{
									this.imgEffHead = ObjectData.getImageAll(num13, ObjectData.HashImageOtherNew, 23000);
								}
								bool flag30 = this.imgEffHead.img != null;
								if (flag30)
								{
									MainImage imageAll4 = ObjectData.getImageAll(mPart.pi[MainObject.CharInfo[num2][num6][0]].id, ObjectData.HashImageCharPart, 10000);
									bool flag31 = imageAll4.img != null;
									if (flag31)
									{
										bool flag32 = this.nFrameEffHead == 0;
										if (flag32)
										{
											this.imgEffHead.img.w = mImage.getImageWidth(imageAll4.img.image);
											this.imgEffHead.img.h = mImage.getImageHeight(imageAll4.img.image);
											this.nFrameEffHead = mImage.getImageHeight(this.imgEffHead.img.image) / this.imgEffHead.img.h;
										}
										else
										{
											bool flag33 = this.framePlayHead > 0;
											if (flag33)
											{
												g.drawRegion(this.imgEffHead.img, 0, this.imgEffHead.img.h * (this.framePlayHead - 1), this.imgEffHead.img.w, this.imgEffHead.img.h, num, (float)num8, (float)num7, num3);
												flag9 = false;
											}
										}
									}
								}
							}
							else
							{
								bool flag34 = ((num5 == 3 && this.weaponFashion == -1) || (num5 == 6 && this.weaponFashion != -1)) && num12 >= 0 && this.checkCFWeapon(num2);
								if (flag34)
								{
									bool flag35 = this.imgEffPlayWeapon == null || this.imgEffPlayWeapon.img == null;
									if (flag35)
									{
										this.imgEffPlayWeapon = ObjectData.getImageAll(num12, ObjectData.HashImageOtherNew, 23000);
									}
									bool flag36 = this.imgEffPlayWeapon.img != null;
									if (flag36)
									{
										MainImage imageAll5 = ObjectData.getImageAll(mPart.pi[MainObject.CharInfo[num2][num6][0]].id, ObjectData.HashImageCharPart, 10000);
										bool flag37 = imageAll5.img != null;
										if (flag37)
										{
											bool flag38 = this.nFrameEffWeapon == 0;
											if (flag38)
											{
												this.imgEffPlayWeapon.img.w = mImage.getImageWidth(this.imgEffPlayWeapon.img.image);
												this.imgEffPlayWeapon.img.h = mImage.getImageHeight(this.imgEffPlayWeapon.img.image) / 3;
												this.nFrameEffWeapon = mImage.getImageHeight(this.imgEffPlayWeapon.img.image) / this.imgEffPlayWeapon.img.h;
											}
											else
											{
												bool flag39 = this.mPlayframeBody[this.indexPlayWeapon][this.tickPlayframeWeapon] < this.nFrameEffWeapon;
												if (flag39)
												{
													g.drawRegion(this.imgEffPlayWeapon.img, 0, this.imgEffPlayWeapon.img.h * this.mPlayframeBody[this.indexPlayWeapon][this.tickPlayframeWeapon], this.imgEffPlayWeapon.img.w, this.imgEffPlayWeapon.img.h, num, (float)num8, (float)num7, num3);
													flag9 = false;
												}
											}
										}
									}
								}
							}
						}
					}
				}
				bool flag40 = flag9;
				if (flag40)
				{
					SmallImage.drawSmallImage(g, (int)mPart.pi[MainObject.CharInfo[num2][num6][0]].id, num8, num7, num, num3, num5);
				}
				bool flag41 = !GameCanvas.lowGraphic && isEye && this.checkCF(num2) && num6 == 0 && this.indexEye >= 0 && this.eye < 2;
				if (flag41)
				{
					g.drawRegion(AvMain.imgEye, (int)(this.indexEye * 5), this.eye * 5, 5, 5, arg, (float)(num8 + num4), (float)(num7 + 6 + (int)this.dyEye), 0);
					bool flag42 = this.head == 770;
					if (flag42)
					{
						g.drawRegion(AvMain.imgEye, (int)(this.indexEye * 5 + 2), this.eye * 5, 2, 5, arg, (float)(num8 + num4 + ((this.type_left_right != 0) ? 6 : -3)), (float)(num7 + 6 + (int)this.dyEye), 0);
					}
					else
					{
						bool flag43 = this.head == 769 && mGraphics.zoomLevel > 1;
						if (flag43)
						{
							g.drawRegion(AvMain.imgEye, (int)(this.indexEye * 5 + 2), this.eye * 5, 2, 5, arg, (float)(num8 + num4 + ((this.type_left_right != 0) ? 5 : -2)), (float)(num7 + 6 + (int)this.dyEye), 0);
						}
					}
				}
			}
		}
		short num14 = this.checkEffBody();
		bool flag44 = num14 < 0;
		if (!flag44)
		{
			bool flag45 = this.fraEffBody == null;
			if (flag45)
			{
				this.fraEffBody = new FrameImage((int)num14, this.frameEffBody);
			}
			else
			{
				bool flag46 = this.typeActionEffBody == (int)MainObject.EBODY_RANDOM_NORMAL;
				if (flag46)
				{
					int num15 = x + this.xEffBody;
					bool flag47 = this.type_left_right == 2;
					if (flag47)
					{
						num15 = x - this.xEffBody;
					}
					this.fraEffBody.drawFrame(this.framePlayEB, num15, y + this.yEffBody, this.type_left_right, 3, g);
				}
			}
		}
	}

	// Token: 0x060007FF RID: 2047 RVA: 0x000A4F04 File Offset: 0x000A3104
	private bool checkCF(int fr)
	{
		bool flag = fr == 17 || fr == 18 || fr == 53 || fr == 58 || fr == 59;
		return !flag;
	}

	// Token: 0x06000800 RID: 2048 RVA: 0x000A4F3C File Offset: 0x000A313C
	private bool checkCFHead(int fr)
	{
		return fr <= 7;
	}

	// Token: 0x06000801 RID: 2049 RVA: 0x000A4F60 File Offset: 0x000A3160
	private bool checkCFBody(int fr)
	{
		bool flag = GameCanvas.gameTick % 4 == 0;
		if (flag)
		{
			this.tickPlayframeBody++;
		}
		bool flag2 = this.tickPlayframeBody >= this.mPlayframeBody[this.indexPlayMBody].Length;
		if (flag2)
		{
			this.tickPlayframeBody = 0;
			this.indexPlayMBody = CRes.random(this.mPlayframeBody.Length);
		}
		return fr == 0 || fr == 1;
	}

	// Token: 0x06000802 RID: 2050 RVA: 0x000A4FE0 File Offset: 0x000A31E0
	private bool checkCFWeapon(int fr)
	{
		bool flag = GameCanvas.gameTick % 4 == 0;
		if (flag)
		{
			this.tickPlayframeWeapon++;
		}
		bool flag2 = this.tickPlayframeWeapon >= this.mPlayframeBody[this.indexPlayWeapon].Length;
		if (flag2)
		{
			this.tickPlayframeWeapon = 0;
			this.indexPlayWeapon = CRes.random(this.mPlayframeBody.Length);
		}
		return fr == 0 || fr == 1;
	}

	// Token: 0x06000803 RID: 2051 RVA: 0x000A5060 File Offset: 0x000A3260
	private bool checkCFLeg(int fr)
	{
		return fr == 0 || fr == 1;
	}

	// Token: 0x06000804 RID: 2052 RVA: 0x000A5088 File Offset: 0x000A3288
	private short checkEffBody()
	{
		for (int i = 0; i < MainObject.idEffBody.Length; i++)
		{
			bool flag = this.body != MainObject.idEffBody[i];
			if (!flag)
			{
				this.xEffBody = 3;
				this.yEffBody = -47;
				this.frameEffBody = 4;
				this.typeActionEffBody = (int)MainObject.EBODY_RANDOM_NORMAL;
				bool flag2 = GameCanvas.gameTick % 5 == 0 && CRes.random(6) != 0;
				if (flag2)
				{
					this.framePlayEB++;
					bool flag3 = this.framePlayEB >= 4;
					if (flag3)
					{
						this.framePlayEB = 0;
					}
				}
				return 384;
			}
		}
		return -1;
	}

	// Token: 0x06000805 RID: 2053 RVA: 0x000A5144 File Offset: 0x000A3344
	private short checkEffHair()
	{
		short num = this.hair;
		if (!true)
		{
		}
		short result;
		switch (num)
		{
		case 714:
			result = 200;
			break;
		case 715:
			result = 201;
			break;
		case 716:
			result = 202;
			break;
		case 717:
			result = 203;
			break;
		case 718:
			result = 204;
			break;
		default:
			switch (num)
			{
			case 771:
				result = 205;
				break;
			case 772:
				result = 206;
				break;
			case 773:
				result = 207;
				break;
			case 774:
				result = 208;
				break;
			case 775:
				result = 209;
				break;
			case 776:
				result = 210;
				break;
			case 777:
				result = 211;
				break;
			default:
				result = this.idHairbay;
				break;
			}
			break;
		}
		if (!true)
		{
		}
		return result;
	}

	// Token: 0x06000806 RID: 2054 RVA: 0x000A521C File Offset: 0x000A341C
	private short checkPlayFrameBody()
	{
		short num = this.body;
		if (!true)
		{
		}
		short result;
		if (num != 719)
		{
			if (num != 748)
			{
				if (num != 756)
				{
					result = this.idBodybay;
				}
				else
				{
					result = 302;
				}
			}
			else
			{
				result = 300;
			}
		}
		else
		{
			result = 301;
		}
		if (!true)
		{
		}
		return result;
	}

	// Token: 0x06000807 RID: 2055 RVA: 0x000A5280 File Offset: 0x000A3480
	private short checkPlayFrameLeg()
	{
		return this.idLegBay;
	}

	// Token: 0x06000808 RID: 2056 RVA: 0x000A5298 File Offset: 0x000A3498
	private short checkPlayFrameWeapon()
	{
		return this.idWeaponBay;
	}

	// Token: 0x06000809 RID: 2057 RVA: 0x000A52B0 File Offset: 0x000A34B0
	private short checkPlayFrameHead()
	{
		for (int i = 0; i < MainObject.idPlayFrameHead.Length; i++)
		{
			bool flag = this.head != MainObject.idPlayFrameHead[i];
			if (!flag)
			{
				this.tickEffHead++;
				bool flag2 = this.framePlayHead == 0;
				if (flag2)
				{
					bool flag3 = this.tickEffHead > 400 && CRes.random(60) == 0;
					if (flag3)
					{
						this.framePlayHead = 1;
						this.tickEffHead = 0;
					}
				}
				else
				{
					bool flag4 = this.framePlayHead == 1;
					if (flag4)
					{
						bool flag5 = this.tickEffHead > 4;
						if (flag5)
						{
							this.framePlayHead = 2;
							this.tickEffHead = 0;
						}
					}
					else
					{
						bool flag6 = this.framePlayHead == 2;
						if (flag6)
						{
							bool flag7 = this.tickEffHead > 120 && CRes.random(30) == 0;
							if (flag7)
							{
								this.framePlayHead = 0;
								this.tickEffHead = 0;
							}
						}
						else
						{
							this.framePlayHead = 0;
							this.tickEffHead = 0;
						}
					}
				}
				return 303;
			}
		}
		return -1;
	}

	// Token: 0x0600080A RID: 2058 RVA: 0x000A53DC File Offset: 0x000A35DC
	public mPart getpaint(int index)
	{
		mPart result = null;
		int num = -1;
		switch (index)
		{
		case 0:
			num = (int)this.head;
			break;
		case 1:
		{
			bool flag = this.isPaintLeg;
			if (flag)
			{
				num = (int)this.leg;
			}
			break;
		}
		case 2:
			num = (int)this.body;
			break;
		case 3:
		{
			bool flag2 = this.isPaintWeapon && (this.isDonotShowWeaponF == 1 || this.ischeckWeaponF());
			if (flag2)
			{
				num = (int)this.weapon;
			}
			break;
		}
		case 4:
		{
			bool flag3 = this.isDonotShowHat != 1 && (this.isDonotShowHat == 0 || this.isDragon);
			if (flag3)
			{
				num = (int)this.hat;
			}
			break;
		}
		case 5:
			num = (int)this.hair;
			break;
		case 6:
		{
			bool flag4 = this.ischeckWeaponF();
			if (flag4)
			{
				bool flag5 = this.isDonotShowWeaponF == 0;
				if (flag5)
				{
					num = (int)this.weaponFashion;
				}
			}
			else
			{
				bool flag6 = this.isPaintWeapon && this.isDonotShowWeaponF == 0;
				if (flag6)
				{
					num = (int)this.weaponFashion;
				}
			}
			break;
		}
		}
		bool flag7 = num >= 0;
		if (flag7)
		{
			result = CharPartInfo.getPart(num);
		}
		return result;
	}

	// Token: 0x0600080B RID: 2059 RVA: 0x000A5520 File Offset: 0x000A3720
	private bool ischeckWeaponF()
	{
		for (int i = 0; i < MainObject.idWeaponF.Length; i++)
		{
			bool flag = this.weaponFashion == MainObject.idWeaponF[i];
			if (flag)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0600080C RID: 2060 RVA: 0x000A5564 File Offset: 0x000A3764
	public mPart partLow(int index)
	{
		bool flag = this == GameScreen.player || !GameCanvas.isLowGraOrWP_PvP() || GameCanvas.gameScr == null || GameCanvas.currentScreen != GameCanvas.gameScr;
		mPart result;
		if (flag)
		{
			result = this.getpaint(index);
		}
		else
		{
			mPart mPart = null;
			bool flag2 = this.typeObject != 1;
			int num4;
			if (flag2)
			{
				int num3;
				if (index != 0)
				{
					sbyte b = this.clazz;
					if (!true)
					{
					}
					int num2;
					switch (b)
					{
					case 1:
					{
						if (!true)
						{
						}
						int num;
						switch (index)
						{
						case 1:
							num = 4;
							goto IL_C9;
						case 2:
							num = 3;
							goto IL_C9;
						case 3:
							num = (int)this.weapon;
							goto IL_C9;
						case 5:
							num = 1;
							goto IL_C9;
						}
						num = -1;
						IL_C9:
						if (!true)
						{
						}
						num2 = num;
						break;
					}
					case 2:
					{
						if (!true)
						{
						}
						int num;
						switch (index)
						{
						case 1:
							num = 27;
							goto IL_119;
						case 2:
							num = 26;
							goto IL_119;
						case 3:
							num = (int)this.weapon;
							goto IL_119;
						case 5:
							num = 24;
							goto IL_119;
						}
						num = -1;
						IL_119:
						if (!true)
						{
						}
						num2 = num;
						break;
					}
					case 3:
					{
						if (!true)
						{
						}
						int num;
						switch (index)
						{
						case 1:
							num = 31;
							goto IL_169;
						case 2:
							num = 30;
							goto IL_169;
						case 3:
							num = (int)this.weapon;
							goto IL_169;
						case 5:
							num = 28;
							goto IL_169;
						}
						num = -1;
						IL_169:
						if (!true)
						{
						}
						num2 = num;
						break;
					}
					case 4:
					{
						if (!true)
						{
						}
						int num;
						switch (index)
						{
						case 1:
							num = 35;
							goto IL_1B9;
						case 2:
							num = 34;
							goto IL_1B9;
						case 3:
							num = (int)this.weapon;
							goto IL_1B9;
						case 5:
							num = 32;
							goto IL_1B9;
						}
						num = -1;
						IL_1B9:
						if (!true)
						{
						}
						num2 = num;
						break;
					}
					case 5:
					{
						if (!true)
						{
						}
						int num;
						switch (index)
						{
						case 1:
							num = 39;
							goto IL_209;
						case 2:
							num = 38;
							goto IL_209;
						case 3:
							num = (int)this.weapon;
							goto IL_209;
						case 5:
							num = 36;
							goto IL_209;
						}
						num = -1;
						IL_209:
						if (!true)
						{
						}
						num2 = num;
						break;
					}
					default:
					{
						if (!true)
						{
						}
						int num;
						switch (index)
						{
						case 1:
							num = 4;
							goto IL_253;
						case 2:
							num = 3;
							goto IL_253;
						case 3:
							num = (int)this.weapon;
							goto IL_253;
						case 5:
							num = 1;
							goto IL_253;
						}
						num = -1;
						IL_253:
						if (!true)
						{
						}
						num2 = num;
						break;
					}
					}
					if (!true)
					{
					}
					num3 = num2;
				}
				else
				{
					num3 = 0;
				}
				num4 = num3;
			}
			else
			{
				bool flag3 = this.typeBossMonster != 0;
				if (flag3)
				{
					return this.getpaint(index);
				}
				if (!true)
				{
				}
				int num2;
				switch (index)
				{
				case 0:
					num2 = 8;
					break;
				case 1:
					num2 = 10;
					break;
				case 2:
					num2 = 9;
					break;
				case 3:
					num2 = (int)this.weapon;
					break;
				default:
					num2 = -1;
					break;
				}
				if (!true)
				{
				}
				num4 = num2;
			}
			bool flag4 = num4 >= 0;
			if (flag4)
			{
				mPart = CharPartInfo.getPart(num4);
			}
			result = mPart;
		}
		return result;
	}

	// Token: 0x0600080D RID: 2061 RVA: 0x000A585C File Offset: 0x000A3A5C
	public static mPart getOnePart(int value)
	{
		mPart result = null;
		bool flag = value > -1;
		if (flag)
		{
			result = CharPartInfo.getPart((int)((short)value));
		}
		return result;
	}

	// Token: 0x0600080E RID: 2062 RVA: 0x000A5884 File Offset: 0x000A3A84
	public static void paintOnePart(mGraphics g, int value, int index, int x, int y, int valueDy)
	{
		mPart onePart = MainObject.getOnePart(value);
		bool flag = onePart != null && onePart.pi != null;
		if (flag)
		{
			int num = 0;
			int num2 = 0;
			switch (valueDy)
			{
			case 0:
				num2 = MainObject.CharInfo[num][index][2];
				break;
			case 1:
				num2 = 0;
				break;
			case 2:
				num2 = MainObject.CharInfo[num][index][1];
				break;
			}
			SmallImage.drawSmallImage(g, (int)onePart.pi[MainObject.CharInfo[num][index][0]].id, x + MainObject.CharInfo[num][index][1] + (int)onePart.pi[MainObject.CharInfo[num][index][0]].dx, y + num2 + (int)onePart.pi[MainObject.CharInfo[num][index][0]].dy, 0, 0, value);
		}
	}

	// Token: 0x0600080F RID: 2063 RVA: 0x000A5954 File Offset: 0x000A3B54
	public virtual void paintHead(mGraphics g, int x, int y, int trans)
	{
		short num = -1;
		bool flag = this.isDonotShowHat == 0;
		if (flag)
		{
			num = this.hat;
		}
		MainObject.paintHeadEveryWhere(g, this.head, this.hair, num, x, y + 38, trans);
	}

	// Token: 0x06000810 RID: 2064 RVA: 0x000A5998 File Offset: 0x000A3B98
	public static void paintHeadEveryWhere(mGraphics g, short head, short hair, short hat, int x, int y, int trans)
	{
		int num = 0;
		for (int i = 0; i < 3; i++)
		{
			int num2 = MainObject.mSortPaintHead[i];
			mPart mPart = null;
			bool flag = i == 0 && head >= 0;
			if (flag)
			{
				mPart = CharPartInfo.getPart((int)head);
			}
			else
			{
				bool flag2 = i == 1 && hair >= 0;
				if (flag2)
				{
					mPart = CharPartInfo.getPart((int)hair);
				}
				else
				{
					bool flag3 = i == 2 && hat >= 0;
					if (flag3)
					{
						mPart = CharPartInfo.getPart((int)hat);
					}
				}
			}
			bool flag4 = mPart != null && mPart.pi != null;
			if (flag4)
			{
				bool flag5 = trans == 0;
				if (flag5)
				{
					SmallImage.drawSmallImage(g, (int)mPart.pi[MainObject.CharInfo[num][num2][0]].id, x + MainObject.CharInfo[num][num2][1] + (int)mPart.pi[MainObject.CharInfo[num][num2][0]].dx, y + MainObject.CharInfo[num][num2][2] + (int)mPart.pi[MainObject.CharInfo[num][num2][0]].dy, trans, 0, num2);
				}
				else
				{
					SmallImage.drawSmallImage(g, (int)mPart.pi[MainObject.CharInfo[num][num2][0]].id, x - MainObject.CharInfo[num][num2][1] - (int)mPart.pi[MainObject.CharInfo[num][num2][0]].dx, y + MainObject.CharInfo[num][num2][2] + (int)mPart.pi[MainObject.CharInfo[num][num2][0]].dy, trans, 24, num2);
				}
			}
		}
	}

	// Token: 0x06000811 RID: 2065 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void Giaotiep()
	{
	}

	// Token: 0x06000812 RID: 2066 RVA: 0x000A5B30 File Offset: 0x000A3D30
	public void GiaotiepNPC()
	{
		mVector mVector = new mVector();
		mVector.addElement(new iCommand(this.nameGiaotiep, 2, this));
		bool flag = this.getListQuestNPC().size() > 0;
		if (flag)
		{
			mVector.addElement(new iCommand(T.quest, 0, this));
		}
		GameCanvas.menu.startAt_NPC(mVector, this.chatNPC, (int)this.ID, this.typeObject, false, 0, false);
	}

	// Token: 0x06000813 RID: 2067 RVA: 0x000A5BA0 File Offset: 0x000A3DA0
	public void GiaotiepOtherPlayer()
	{
		GameScreen.objGiaotiep = GameScreen.objFocus;
		mVector mVector = new mVector();
		bool flag = ReadMessenge.ID_GiaoTiep_Server >= 0;
		if (flag)
		{
			GameCanvas.gameScr.cmdGiaotiepServer.caption = ReadMessenge.Str_GiaoTiep_Server;
			mVector.addElement(GameCanvas.gameScr.cmdGiaotiepServer);
		}
		mVector.addElement(GameCanvas.gameScr.cmdInfoPlayer);
		bool flag2 = GameCanvas.language == 0;
		if (flag2)
		{
			mVector.addElement(GameCanvas.gameScr.cmdTangRuby);
		}
		mVector.addElement(GameCanvas.gameScr.cmdInviteParty);
		mVector.addElement(GameCanvas.gameScr.cmdChatPlayer);
		mVector.addElement(GameCanvas.gameScr.cmdAddFriend);
		bool flag3 = GameScreen.typeMod == 1;
		if (flag3)
		{
			mVector.addElement(GameCanvas.gameScr.cmdLockChat);
		}
		mVector.addElement(GameCanvas.gameScr.cmdFight);
		mVector.addElement(GameCanvas.gameScr.cmdInviteTrade);
		bool flag4 = this.clan == null && GameScreen.player.clan != null;
		if (flag4)
		{
			mVector.addElement(GameCanvas.gameScr.cmdMoiVaoClan);
		}
		bool flag5 = this.clan != null && GameScreen.player.clan == null;
		if (flag5)
		{
			mVector.addElement(GameCanvas.gameScr.cmdXinVaoClan);
		}
		mVector.addElement(GameCanvas.gameScr.cmdBaisu);
		GameCanvas.menu.startAt(mVector, 2, T.Giaotiep);
	}

	// Token: 0x06000814 RID: 2068 RVA: 0x000A5D20 File Offset: 0x000A3F20
	public mVector getListQuestNPC()
	{
		mVector mVector = new mVector();
		for (int i = 0; i < Player.vecQuest.size(); i++)
		{
			MainQuest mainQuest = (MainQuest)Player.vecQuest.elementAt(i);
			bool flag = mainQuest.idNPC == (int)this.ID || mainQuest.idNPC_Sub == (int)this.ID;
			if (flag)
			{
				mVector.addElement(mainQuest);
			}
		}
		return mVector;
	}

	// Token: 0x06000815 RID: 2069 RVA: 0x000A5D98 File Offset: 0x000A3F98
	public virtual iCommand getCenterCmd()
	{
		return null;
	}

	// Token: 0x06000816 RID: 2070 RVA: 0x000A5DAC File Offset: 0x000A3FAC
	public void setResetWearing()
	{
		this.sethead(this.headMain);
		this.body = this.bodyMain;
		this.leg = this.legMain;
		this.sethair(this.hairMain);
		this.isBuffDevil = false;
		this.setHeadBigBody();
	}

	// Token: 0x06000817 RID: 2071 RVA: 0x000A5DFC File Offset: 0x000A3FFC
	public virtual void setWearing(short[] mWear)
	{
		this.weapon = mWear[0];
		this.hat = mWear[1];
		bool flag = this.hat == 0;
		if (flag)
		{
			this.hat = -1;
		}
		this.body = mWear[3];
		this.leg = mWear[5];
		this.headMain = this.head;
		this.bodyMain = this.body;
		this.legMain = this.leg;
		this.hairMain = this.hair;
		mSystem.outz(string.Concat(new string[]
		{
			"setWearing name=",
			this.name,
			" ",
			this.weapon.ToString(),
			"  ",
			this.hat.ToString(),
			"  ",
			this.body.ToString(),
			"  ",
			this.leg.ToString(),
			"  ",
			this.hair.ToString(),
			"  ",
			this.head.ToString()
		}));
		this.checkBuffDevil();
		this.checkEffWeapon();
		this.setHeadBigBody();
	}

	// Token: 0x06000818 RID: 2072 RVA: 0x000A5F38 File Offset: 0x000A4138
	public void sethead(short headset)
	{
		this.head = headset;
		this.nFrameEffHead = 0;
		short num = this.checkPlayFrameHead();
		this.imgEffHair = null;
		bool flag = num >= 0;
		if (flag)
		{
			this.imgEffHead = ObjectData.getImageAll(num, ObjectData.HashImageOtherNew, 23000);
		}
		this.setEye();
	}

	// Token: 0x06000819 RID: 2073 RVA: 0x0000AC5F File Offset: 0x00008E5F
	public void setBodySkill()
	{
		this.indexBodySkill = 0;
	}

	// Token: 0x0600081A RID: 2074 RVA: 0x000A5F8C File Offset: 0x000A418C
	public void sethair(short hairset)
	{
		this.nFrameEffHair = 0;
		this.hair = hairset;
		short num = this.checkEffHair();
		this.imgEffHair = null;
		bool flag = num >= 0;
		if (flag)
		{
			this.imgEffHair = ObjectData.getImageAll(num, ObjectData.HashImageOtherNew, 23000);
		}
	}

	// Token: 0x0600081B RID: 2075 RVA: 0x000A5FDC File Offset: 0x000A41DC
	public void setHeadBigBody()
	{
		this.fraEffBody = null;
		this.typeEfffashion = -1;
		this.nFrameEffBody = 0;
		this.imgEffPlayBody = null;
		bool flag = false;
		for (int i = 0; i < MainObject.ListLechHEAD.Length; i++)
		{
			bool flag2 = this.body == MainObject.ListLechHEAD[i];
			if (flag2)
			{
				flag = true;
			}
		}
		this.isKoLechHead = false;
		for (int j = 0; j < MainObject.ListKoLechHEAD.Length; j++)
		{
			bool flag3 = this.head == MainObject.ListKoLechHEAD[j];
			if (flag3)
			{
				this.isKoLechHead = true;
			}
		}
		bool flag4 = this.typeObject == 0;
		if (flag4)
		{
			this.isDragon = false;
			bool flag5 = this.isBuffDevil;
			if (flag5)
			{
				this.lechYHead = 0;
				this.hOne = 52;
			}
			else
			{
				bool flag6 = this.body == 950 || this.body == 963 || this.body == 972;
				if (flag6)
				{
					this.hOne = 72;
				}
				else
				{
					bool flag7 = flag;
					if (flag7)
					{
						this.lechYHead = -6;
						this.hOne = 62;
						bool flag8 = this.body == 748;
						if (flag8)
						{
							this.isDragon = true;
						}
						bool flag9 = this.body == 798;
						if (flag9)
						{
							short num = this.checkEffBody();
							bool flag10 = num >= 0;
							if (flag10)
							{
								this.fraEffBody = new FrameImage((int)num, this.frameEffBody);
							}
						}
					}
					else
					{
						this.lechYHead = 0;
						this.hOne = 52;
					}
				}
			}
			bool flag11 = this.body == 810 || this.body == 813;
			if (flag11)
			{
				this.typeEfffashion = 1;
			}
			short num2 = this.checkPlayFrameBody();
			bool flag12 = num2 != -1;
			if (flag12)
			{
				this.imgEffPlayBody = ObjectData.getImageAll(num2, ObjectData.HashImageOtherNew, 23000);
			}
		}
		mSystem.outz(string.Concat(new string[]
		{
			"body ",
			this.body.ToString(),
			" lechYHead = ",
			this.lechYHead.ToString(),
			" hone = ",
			this.hOne.ToString()
		}));
	}

	// Token: 0x0600081C RID: 2076 RVA: 0x000A6230 File Offset: 0x000A4430
	private void setEye()
	{
		bool flag = this.hat == 460;
		if (flag)
		{
			this.indexEye = -1;
		}
		else
		{
			bool flag2 = this.head == 0 || this.head == 487 || this.head == 488 || this.head == 489 || this.head == 573 || this.head == 574 || this.head == 575 || this.head == 614 || this.head == 769 || this.head == 770 || this.head == 768 || this.head == 731;
			if (flag2)
			{
				bool flag3 = mGraphics.zoomLevel <= 1;
				if (flag3)
				{
					bool flag4 = this.head == 573;
					if (flag4)
					{
						this.dxEye = 3;
						this.dyEye = 0;
						this.indexEye = 0;
					}
					else
					{
						bool flag5 = this.head == 574;
						if (flag5)
						{
							this.dxEye = 1;
							this.dyEye = -1;
							this.indexEye = 1;
						}
						else
						{
							bool flag6 = this.head == 575;
							if (flag6)
							{
								this.dxEye = 1;
								this.dyEye = 0;
								this.indexEye = 0;
							}
							else
							{
								bool flag7 = this.head == 731 || this.head == 614;
								if (flag7)
								{
									this.dxEye = 2;
									this.dyEye = -1;
									this.indexEye = 2;
								}
								else
								{
									bool flag8 = this.head == 768;
									if (flag8)
									{
										this.dxEye = 5;
										this.dyEye = -2;
										this.indexEye = 3;
									}
									else
									{
										bool flag9 = this.head == 769;
										if (flag9)
										{
											this.dxEye = 1;
											this.dyEye = -1;
											this.indexEye = 4;
										}
										else
										{
											bool flag10 = this.head == 770;
											if (flag10)
											{
												this.dxEye = 1;
												this.dyEye = 0;
												this.indexEye = 0;
											}
											else
											{
												this.dxEye = 0;
												this.dyEye = 0;
												this.indexEye = 0;
											}
										}
									}
								}
							}
						}
					}
				}
				else
				{
					bool flag11 = this.head == 573;
					if (flag11)
					{
						this.dxEye = 2;
						this.dyEye = 0;
						this.indexEye = 0;
					}
					else
					{
						bool flag12 = this.head == 574;
						if (flag12)
						{
							this.dxEye = 0;
							this.dyEye = 0;
							this.indexEye = 1;
						}
						else
						{
							bool flag13 = this.head == 575;
							if (flag13)
							{
								this.dxEye = 0;
								this.dyEye = -1;
								this.indexEye = 0;
							}
							else
							{
								bool flag14 = this.head == 731 || this.head == 614;
								if (flag14)
								{
									this.dxEye = 0;
									this.dyEye = -1;
									this.indexEye = 2;
								}
								else
								{
									bool flag15 = this.head == 768;
									if (flag15)
									{
										this.dxEye = 4;
										this.dyEye = -2;
										this.indexEye = 3;
									}
									else
									{
										bool flag16 = this.head == 769;
										if (flag16)
										{
											this.dxEye = 1;
											this.dyEye = -1;
											this.indexEye = 4;
										}
										else
										{
											bool flag17 = this.head == 770;
											if (flag17)
											{
												this.dxEye = 1;
												this.dyEye = -1;
												this.indexEye = 0;
											}
											else
											{
												this.dxEye = 0;
												this.dyEye = 0;
												this.indexEye = 0;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			else
			{
				this.indexEye = -1;
			}
		}
	}

	// Token: 0x0600081D RID: 2077 RVA: 0x000A65F8 File Offset: 0x000A47F8
	private void checkEffWeapon()
	{
		bool flag = this.clazz == 4;
		if (flag)
		{
			short num = this.weapon;
			short num2 = num;
			if (num2 <= 227)
			{
				if (num2 <= 177)
				{
					if (num2 != 6)
					{
						if (num2 != 177)
						{
							goto IL_AC;
						}
						goto IL_91;
					}
				}
				else
				{
					if (num2 == 182)
					{
						this.indexEff_1 = 1;
						goto IL_B5;
					}
					if (num2 != 227)
					{
						goto IL_AC;
					}
				}
			}
			else if (num2 <= 262)
			{
				if (num2 == 246)
				{
					goto IL_91;
				}
				if (num2 != 262)
				{
					goto IL_AC;
				}
				this.indexEff_1 = 3;
				goto IL_B5;
			}
			else if (num2 != 463)
			{
				if (num2 != 467)
				{
					goto IL_AC;
				}
				this.indexEff_1 = 4;
				goto IL_B5;
			}
			this.indexEff_1 = 0;
			goto IL_B5;
			IL_91:
			this.indexEff_1 = 2;
			goto IL_B5;
			IL_AC:
			this.indexEff_1 = 0;
			IL_B5:;
		}
		else
		{
			bool flag2 = this.clazz == 2;
			if (flag2)
			{
				short num3 = this.weapon;
				short num4 = num3;
				if (num4 <= 225)
				{
					if (num4 != 5)
					{
						if (num4 == 183)
						{
							this.indexEff_1 = 1;
							goto IL_14E;
						}
						if (num4 != 225)
						{
							goto IL_14E;
						}
					}
				}
				else if (num4 <= 260)
				{
					if (num4 != 244 && num4 != 260)
					{
						goto IL_14E;
					}
				}
				else if (num4 != 461)
				{
					if (num4 != 465)
					{
						goto IL_14E;
					}
					this.indexEff_1 = 2;
					goto IL_14E;
				}
				this.indexEff_1 = 0;
				IL_14E:;
			}
		}
	}

	// Token: 0x0600081E RID: 2078 RVA: 0x0000AC69 File Offset: 0x00008E69
	public virtual void setWearingMon(short[] mWear)
	{
		this.sethead(mWear[0]);
		this.body = mWear[1];
		this.leg = mWear[2];
		this.weapon = mWear[3];
	}

	// Token: 0x0600081F RID: 2079 RVA: 0x000A6754 File Offset: 0x000A4954
	public void checkBuffDevil()
	{
		for (int i = 0; i < this.vecBuffCur.size(); i++)
		{
			MainBuff mainBuff = (MainBuff)this.vecBuffCur.elementAt(i);
			bool flag = mainBuff.isDevil && !mainBuff.isRemove;
			if (flag)
			{
				this.sethead(mainBuff.head);
				this.body = mainBuff.body;
				this.leg = mainBuff.leg;
				this.sethair(-1);
				this.isBuffDevil = true;
				this.setHeadBigBody();
				break;
			}
		}
	}

	// Token: 0x06000820 RID: 2080 RVA: 0x000A67E8 File Offset: 0x000A49E8
	public void setWearingIsNull(short[] mWear)
	{
		bool flag = mWear[0] >= 0;
		if (flag)
		{
			this.weapon = mWear[0];
		}
		bool flag2 = mWear[1] == -2;
		if (flag2)
		{
			this.hat = -1;
		}
		else
		{
			bool flag3 = mWear[1] >= 0;
			if (flag3)
			{
				this.hat = mWear[1];
				bool flag4 = this.hat == 0;
				if (flag4)
				{
					this.hat = -1;
				}
			}
		}
		bool flag5 = mWear[3] >= 0;
		if (flag5)
		{
			this.body = mWear[3];
		}
		bool flag6 = mWear[5] >= 0;
		if (flag6)
		{
			this.leg = mWear[5];
		}
		bool flag7 = mWear[1] == -2;
		if (flag7)
		{
			this.sethair(-1);
		}
		else
		{
			bool flag8 = mWear[7] >= 0;
			if (flag8)
			{
				this.sethair(mWear[7]);
			}
		}
		bool flag9 = mWear[6] >= 0;
		if (flag9)
		{
			this.sethead(mWear[6]);
		}
	}

	// Token: 0x06000821 RID: 2081 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void setTouchPoint()
	{
	}

	// Token: 0x06000822 RID: 2082 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void setFireObject(int value)
	{
	}

	// Token: 0x06000823 RID: 2083 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void setImgMonSterforOtherPlayer(sbyte typeMove)
	{
	}

	// Token: 0x06000824 RID: 2084 RVA: 0x0000AC91 File Offset: 0x00008E91
	public void setSpeed(int vM, int vySeaM)
	{
		this.vMax = vM;
		this.vMaxYSea = vySeaM;
	}

	// Token: 0x06000825 RID: 2085 RVA: 0x000A68D8 File Offset: 0x000A4AD8
	public void setDirNew(sbyte typeEff)
	{
		bool flag = typeEff == 2;
		if (flag)
		{
			bool flag2 = this.x < 100;
			if (flag2)
			{
				this.toX = this.x;
				this.x = 0;
			}
			else
			{
				bool flag3 = this.x > GameCanvas.loadmap.maxWMap - 100;
				if (flag3)
				{
					this.toX = this.x;
					this.x = GameCanvas.loadmap.maxWMap;
				}
			}
		}
		else
		{
			bool flag4 = typeEff == 1;
			if (flag4)
			{
				this.isTanHinh = true;
				this.timeEffRemoveChar = 6;
				bool isShowNameSUPER_BOSS = GameScreen.isShowNameSUPER_BOSS;
				if (isShowNameSUPER_BOSS)
				{
					GameScreen.addEffectEnd_ObjTo(32, 0, this.x, this.y, this.ID, this.typeObject, (sbyte)this.type_left_right, null);
				}
			}
			else
			{
				bool flag5 = typeEff != 3;
				if (!flag5)
				{
					int xSea = 0;
					int num = -1;
					for (int i = 0; i < LoadMap.mSea.Length; i++)
					{
						bool flag6 = (int)LoadMap.mSea[i][0] == GameCanvas.loadmap.idMap;
						if (flag6)
						{
							xSea = (int)LoadMap.mSea[i][3];
							num = i;
							break;
						}
					}
					bool flag7 = num == -1;
					if (!flag7)
					{
						bool flag8 = GameScreen.vecBoat.size() > 0;
						if (flag8)
						{
							int num2 = 40;
							bool flag9 = GameScreen.vecBoat.size() > 6;
							if (flag9)
							{
								num2 = 20;
							}
							bool flag10 = GameScreen.vecBoat.size() > 10;
							if (flag10)
							{
								num2 = 5;
							}
							bool flag11 = GameScreen.vecBoat.size() > 0;
							if (flag11)
							{
								Boat boat = (Boat)GameScreen.vecBoat.elementAt(GameScreen.vecBoat.size() - 1);
								bool flag12 = num != -1;
								if (flag12)
								{
									xSea = boat.x + (int)LoadMap.mSea[num][5] * num2;
								}
							}
						}
						this.setActionSea((sbyte)LoadMap.mSea[num][2], xSea, (int)LoadMap.mSea[num][4]);
					}
				}
			}
		}
	}

	// Token: 0x06000826 RID: 2086 RVA: 0x000A6AE4 File Offset: 0x000A4CE4
	public void updateActionPerson()
	{
		this.f++;
		bool flag = this.Action != 0;
		if (flag)
		{
			this.timeFullSet = 0;
		}
		else
		{
			bool flag2 = this.timeFullSet < 100;
			if (flag2)
			{
				this.timeFullSet++;
			}
		}
		switch (this.Action)
		{
		case 0:
			this.actionStand();
			break;
		case 1:
		{
			int[] array = this.feRun;
			bool flag3 = this.checkBoatSea() && this.boatSea != null;
			if (flag3)
			{
				array = this.feStand;
			}
			else
			{
				bool flag4 = GameCanvas.gameTick % 3 == 0;
				if (flag4)
				{
					bool flag5 = GameCanvas.loadmap.getTile(this.x, this.y) == 0 && this.isInfo;
					if (flag5)
					{
						sbyte type = 0;
						int num = this.x;
						int num2 = this.y;
						int dir = this.type_left_right;
						sbyte b = this.stepLeg;
						this.stepLeg = b + 1;
						GameScreen.CreateEffOnMap(type, num, num2, dir, b);
					}
					bool flag6 = this.indexFullSet == 5;
					if (flag6)
					{
						short type2 = 157;
						int num3 = this.x;
						int num4 = this.y + 4;
						int dir2 = this.type_left_right;
						sbyte b = this.stepLeg;
						this.stepLeg = b + 1;
						GameScreen.CreateEffOnMapFullset(type2, num3, num4, dir2, b);
					}
					bool flag7 = this.stepLeg > 100;
					if (flag7)
					{
						this.stepLeg = 0;
					}
				}
			}
			bool flag8 = this.f > array.Length - 1;
			if (flag8)
			{
				this.f = 0;
			}
			bool flag9 = this.vx == 0 && this.vy == 0 && this.posTransRoad == null && !this.isMoveNor;
			if (flag9)
			{
				this.Action = 0;
				this.f = 0;
			}
			this.frame = array[this.f];
			break;
		}
		case 2:
			this.updateActionFire();
			break;
		case 3:
			this.updateAva();
			break;
		case 4:
			this.frame = 38;
			this.updateDy();
			return;
		case 5:
			this.frame = 60;
			break;
		}
		this.updateDirPaint();
		bool flag10 = this.Action == 2;
		if (!flag10)
		{
			this.updateDy();
			bool flag11 = !this.isPaintWeapon;
			if (flag11)
			{
				this.isPaintWeapon = true;
			}
			bool flag12 = !this.isPaintLeg;
			if (flag12)
			{
				this.isPaintLeg = true;
			}
			bool flag13 = this.isTanHinh;
			if (flag13)
			{
				bool flag14 = this.timeEffRemoveChar > 0;
				if (flag14)
				{
					this.timeEffRemoveChar--;
				}
				else
				{
					this.isTanHinh = false;
				}
			}
		}
	}

	// Token: 0x06000827 RID: 2087 RVA: 0x000A6D8C File Offset: 0x000A4F8C
	public void updateActionPerLogin()
	{
		this.f++;
		switch (this.Action)
		{
		case 0:
			this.actionStand();
			break;
		case 1:
		{
			int[] array = this.feRun;
			bool flag = this.checkBoatSea() && this.boatSea != null;
			if (flag)
			{
				array = this.feStand;
			}
			bool flag2 = this.f > array.Length - 1;
			if (flag2)
			{
				this.f = 0;
			}
			bool flag3 = this.vx == 0 && this.vy == 0 && this.posTransRoad == null;
			if (flag3)
			{
				this.Action = 0;
				this.f = 0;
			}
			this.frame = array[this.f];
			break;
		}
		case 2:
			this.updateActionFire();
			break;
		}
	}

	// Token: 0x06000828 RID: 2088 RVA: 0x000A6E64 File Offset: 0x000A5064
	public virtual void actionStand()
	{
		bool flag = this.f > this.feStand.Length - 1;
		if (flag)
		{
			this.f = 0;
		}
		this.frame = this.feStand[this.f];
	}

	// Token: 0x06000829 RID: 2089 RVA: 0x000A6EA4 File Offset: 0x000A50A4
	public void updateActionMonSter(bool isPet)
	{
		this.f++;
		bool flag = this.mActionMonSter == null;
		if (!flag)
		{
			int num = this.Action;
			bool flag2 = this.checkBoatSea() && this.boatSea != null && this.Action == 1;
			if (flag2)
			{
				num = 0;
			}
			bool flag3 = false;
			if (isPet)
			{
				bool flag4 = this.isPlayStand && this.Action == 0;
				if (flag4)
				{
					bool flag5 = this.f > this.mActionStandMonSter.Length - 1;
					if (flag5)
					{
						flag3 = true;
					}
				}
				else
				{
					bool flag6 = this.f > this.mActionMonSter[this.Action].Length - 1;
					if (flag6)
					{
						flag3 = true;
					}
				}
			}
			else
			{
				bool flag7 = this.f > this.mActionMonSter[num].Length - 1;
				if (flag7)
				{
					flag3 = true;
				}
			}
			bool flag8 = flag3;
			if (flag8)
			{
				this.f = 0;
				bool flag9 = this.Action == 3 || this.Action == 2;
				if (flag9)
				{
					this.Action = 0;
					this.vx = 0;
					this.vy = 0;
				}
			}
			bool flag10 = this.Action == 1 && this.vx == 0 && this.vy == 0;
			if (flag10)
			{
				this.Action = 0;
				this.f = 0;
			}
			bool flag11 = this.timeFreeFire > 0;
			if (flag11)
			{
				this.timeFreeFire--;
			}
		}
	}

	// Token: 0x0600082A RID: 2090 RVA: 0x000A701C File Offset: 0x000A521C
	public virtual void updateActionFire()
	{
		bool flag = this.plashNow == null;
		if (!flag)
		{
			this.tickfire++;
			int num = this.plashNow.update();
			bool flag2 = num == -1 || this.tickfire >= 200;
			if (flag2)
			{
				bool flag3 = GameScreen.player != null && this == GameScreen.player;
				if (flag3)
				{
					this.demFire++;
					bool flag4 = this.demFire >= 3;
					if (flag4)
					{
						GlobalService.gI().Obj_Move((short)this.x, (short)this.y);
						this.demFire = 0;
					}
				}
				this.plashNow = null;
				this.Action = 0;
				this.resetAction();
				this.tickfire = 0;
			}
			else
			{
				this.frame = num;
			}
		}
	}

	// Token: 0x0600082B RID: 2091 RVA: 0x000A70F8 File Offset: 0x000A52F8
	public void updateDirPaint()
	{
		bool flag = this.Dir == 1 || this.Dir == 2;
		if (flag)
		{
			bool flag2 = this.toX > this.x;
			if (flag2)
			{
				this.type_left_right = 2;
			}
			else
			{
				bool flag3 = this.toX < this.x;
				if (flag3)
				{
					this.type_left_right = 0;
				}
			}
		}
		bool flag4 = this.Dir == 0 && this.type_left_right == 2;
		if (flag4)
		{
			this.type_left_right = 0;
		}
		else
		{
			bool flag5 = this.Dir == 2 && this.type_left_right == 0;
			if (flag5)
			{
				this.type_left_right = 2;
			}
		}
	}

	// Token: 0x0600082C RID: 2092 RVA: 0x0000ACA2 File Offset: 0x00008EA2
	public virtual void updateAva()
	{
		this.Action = 0;
	}

	// Token: 0x0600082D RID: 2093 RVA: 0x000A71A0 File Offset: 0x000A53A0
	public void setTypeQuest()
	{
		this.typeQuest = 0;
		for (int i = 0; i < Player.vecQuest.size(); i++)
		{
			MainQuest mainQuest = (MainQuest)Player.vecQuest.elementAt(i);
			bool flag = mainQuest.idNPC == (int)this.ID;
			if (flag)
			{
				bool flag2 = this.typeQuest == 0;
				if (flag2)
				{
					bool flag3 = mainQuest.statusQuest == 0;
					if (flag3)
					{
						this.typeQuest = 1;
					}
					bool flag4 = mainQuest.statusQuest == 1;
					if (flag4)
					{
						this.typeQuest = 2;
					}
					bool flag5 = mainQuest.statusQuest == 2;
					if (flag5)
					{
						this.typeQuest = 3;
					}
				}
				else
				{
					bool flag6 = this.typeQuest == 1;
					if (flag6)
					{
						bool flag7 = mainQuest.statusQuest == 2;
						if (flag7)
						{
							this.typeQuest = 3;
						}
					}
					else
					{
						bool flag8 = this.typeQuest == 2;
						if (flag8)
						{
							bool flag9 = mainQuest.statusQuest == 0;
							if (flag9)
							{
								this.typeQuest = 1;
							}
							bool flag10 = mainQuest.statusQuest == 2;
							if (flag10)
							{
								this.typeQuest = 3;
							}
						}
					}
				}
			}
			else
			{
				bool flag11 = mainQuest.idNPC_Sub == (int)this.ID && this.typeQuest == 0;
				if (flag11)
				{
					this.typeQuest = 2;
				}
			}
			bool flag12 = this.typeQuest == 3;
			if (flag12)
			{
				break;
			}
		}
	}

	// Token: 0x0600082E RID: 2094 RVA: 0x000A7304 File Offset: 0x000A5504
	public void updateEye()
	{
		bool flag = this == GameScreen.player && Player.isGhost;
		if (flag)
		{
			this.eye = 1;
		}
		else
		{
			bool flag2 = this.eye < 2;
			if (flag2)
			{
				this.timeEye++;
				bool flag3 = this.timeEye > 1 && this.timeEye < 6;
				if (flag3)
				{
					this.eye = 1;
				}
				else
				{
					this.eye = 0;
				}
				bool flag4 = this.timeEye >= 8;
				if (flag4)
				{
					this.timeEye = 0;
					this.eye = 2;
					bool flag5 = this.clazz != 4;
					if (flag5)
					{
						this.endEye = CRes.random(50, 100);
					}
					else
					{
						this.endEye = CRes.random(20, 70);
					}
				}
			}
			else
			{
				this.timeEye++;
				bool flag6 = this.timeEye >= this.endEye;
				if (flag6)
				{
					this.timeEye = 0;
					this.eye = 0;
				}
			}
		}
	}

	// Token: 0x0600082F RID: 2095 RVA: 0x000A7410 File Offset: 0x000A5610
	public virtual void AddBuff(MainBuff buff)
	{
		for (int i = 0; i < this.vecBuffCur.size(); i++)
		{
			MainBuff mainBuff = (MainBuff)this.vecBuffCur.elementAt(i);
			bool flag = mainBuff.IdBuff == buff.IdBuff;
			if (flag)
			{
				this.vecBuffCur.removeElementAt(i);
				i--;
			}
		}
		buff.setYlech(this);
		this.vecBuffCur.addElement(buff);
	}

	// Token: 0x06000830 RID: 2096 RVA: 0x000A7488 File Offset: 0x000A5688
	public void setInfoMapTrain()
	{
		this.mSkillMapTrain = new short[]
		{
			21,
			34,
			38
		};
		MainObject.mPosMapTrain = new int[3][];
		this.tickMapTrain = CRes.random(70);
		for (int i = 0; i < MainPlayer.mPosTrainOther[0].Length; i++)
		{
			MainObject.mPosMapTrain[i] = new int[2];
			for (int j = 0; j < MainPlayer.mPosTrainOther[0][i].Length; j++)
			{
				MainObject.mPosMapTrain[i][j] = (int)MainPlayer.mPosTrainOther[0][i][j] + CRes.random_Am_0(2);
			}
		}
	}

	// Token: 0x06000831 RID: 2097 RVA: 0x000A7524 File Offset: 0x000A5724
	public virtual int isNPC_Area()
	{
		return 1;
	}

	// Token: 0x06000832 RID: 2098 RVA: 0x000A7538 File Offset: 0x000A5738
	public void addEffSpec(short type, short time)
	{
		int i = 0;
		while (i < this.vecEffspec.size())
		{
			Effect_Spec effect_Spec = (Effect_Spec)this.vecEffspec.elementAt(i);
			bool flag = effect_Spec.typeEffect == (int)type;
			if (flag)
			{
				bool flag2 = effect_Spec.getTimeEff() > time;
				if (flag2)
				{
					return;
				}
				this.vecEffspec.removeElement(effect_Spec);
				break;
			}
			else
			{
				i++;
			}
		}
		Effect_Spec effect_Spec2 = new Effect_Spec(this, type, time);
		this.vecEffspec.addElement(effect_Spec2);
		bool flag3 = effect_Spec2.typeEffect == 15;
		if (flag3)
		{
			this.SetXlechEffectBongToi();
			return;
		}
	}

	// Token: 0x06000833 RID: 2099 RVA: 0x000A75D4 File Offset: 0x000A57D4
	public void Move_to_Focus_Person()
	{
		bool flag = this.timeBeginUpdateMove == 0;
		if (flag)
		{
			this.toX = this.toXNew;
			this.toY = this.toYNew;
		}
		bool flag2 = this.x != this.toX || this.y != this.toY;
		if (flag2)
		{
			bool flag3 = CRes.abs(this.x - this.toX) > this.vMax || CRes.abs(this.y - this.toY) > this.vMax;
			if (flag3)
			{
				this.move_to_XY_Normal();
			}
			else
			{
				bool flag4 = this.Action != 2 && this.Action != 3 && this.Action != 4;
				if (flag4)
				{
					this.toX = this.x;
					this.toY = this.y;
					this.vx = 0;
					this.vy = 0;
					this.Action = 0;
				}
			}
		}
	}

	// Token: 0x06000834 RID: 2100 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void updateActionUpBoat()
	{
	}

	// Token: 0x06000835 RID: 2101 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void setActionSea(sbyte type, int xSea, int ySea)
	{
	}

	// Token: 0x06000836 RID: 2102 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void updateActionDown_2()
	{
	}

	// Token: 0x06000837 RID: 2103 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void updateActionUp_2()
	{
	}

	// Token: 0x06000838 RID: 2104 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void updateActionDown()
	{
	}

	// Token: 0x06000839 RID: 2105 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void updateActionUp()
	{
	}

	// Token: 0x0600083A RID: 2106 RVA: 0x000A76D0 File Offset: 0x000A58D0
	public bool isHuman()
	{
		bool flag = this.typePlayer == 2 || this.typePlayer == 3;
		return !flag;
	}

	// Token: 0x0600083B RID: 2107 RVA: 0x000A7704 File Offset: 0x000A5904
	public void setHpEff()
	{
		bool flag = this.HpEff > this.Hp;
		if (flag)
		{
			this.tickHpEff++;
			bool flag2 = this.speedHpEff <= 0;
			if (flag2)
			{
				this.speedHpEff = 20;
			}
			bool flag3 = this.speedHpEff < (this.HpEff - this.Hp) / 10;
			if (flag3)
			{
				this.speedHpEff = (this.HpEff - this.Hp) / 10;
			}
			bool flag4 = this.tickHpEff > 10;
			if (flag4)
			{
				this.HpEff -= this.speedHpEff;
			}
		}
		else
		{
			this.HpEff = this.Hp;
			this.speedHpEff = 0;
			this.tickHpEff = 0;
		}
	}

	// Token: 0x0600083C RID: 2108 RVA: 0x000A77C8 File Offset: 0x000A59C8
	public virtual int getTypeMoveMonster()
	{
		return -1;
	}

	// Token: 0x0600083D RID: 2109 RVA: 0x000A77DC File Offset: 0x000A59DC
	public void setWName()
	{
		this.wNameNPC = mFont.tahoma_7b_white.getWidth(this.name) + 8;
		this.wNameNPC += this.wNameNPC % 2;
		this.wNameFocus = this.wNameNPC + 6;
		bool flag = this.wNameFocus < 74;
		if (flag)
		{
			this.wNameFocus = 74;
		}
	}

	// Token: 0x0600083E RID: 2110 RVA: 0x000A7840 File Offset: 0x000A5A40
	public bool checkBoatSea()
	{
		return LoadMap.specMap == 4 || this.typeActionBoat != 0 || GameCanvas.currentScreen == GameCanvas.loginScr || (!LoadMap.isOnlineMap && (LoadMap.specMap == 5 || LoadMap.specMap == 8 || LoadMap.specMap == 12));
	}

	// Token: 0x0600083F RID: 2111 RVA: 0x000A78A4 File Offset: 0x000A5AA4
	public virtual void addEffBuff(sbyte typeBuff, short effBuff, short time)
	{
		mVector mVector = new mVector();
		Object_Effect_Skill object_Effect_Skill = new Object_Effect_Skill(this.ID, this.typeObject);
		object_Effect_Skill.setHP(0, this.Hp, 0);
		mVector.addElement(object_Effect_Skill);
		MainSkill mainSkill = new MainSkill(-1, effBuff);
		mainSkill.setTypeBuff(typeBuff, effBuff, time);
		this.addSkillFire(mainSkill, mVector);
	}

	// Token: 0x06000840 RID: 2112 RVA: 0x000A78FC File Offset: 0x000A5AFC
	public static MainObject getPet(short IDMain)
	{
		for (int i = 0; i < GameScreen.vecPlayers.size(); i++)
		{
			MainObject mainObject = (MainObject)GameScreen.vecPlayers.elementAt(i);
			bool flag = mainObject.typeObject == 10 && mainObject.IDMainShiper == IDMain;
			if (flag)
			{
				return mainObject;
			}
		}
		return null;
	}

	// Token: 0x06000841 RID: 2113 RVA: 0x0000ACAC File Offset: 0x00008EAC
	public void setXYPet(int x, int y)
	{
		this.x = x;
		this.y = y;
		this.toX = x;
		this.toY = y;
		this.dy = 0;
		this.Action = 0;
		this.f = 0;
	}

	// Token: 0x06000842 RID: 2114 RVA: 0x000A795C File Offset: 0x000A5B5C
	public void getPosLast()
	{
		ObjMove objMove = GameScreen.getObjMove(this.ID, this.typeObject);
		bool flag = objMove != null;
		if (flag)
		{
			this.xLast = (int)objMove.x;
			this.yLast = (int)objMove.y;
		}
	}

	// Token: 0x06000843 RID: 2115 RVA: 0x000A79A0 File Offset: 0x000A5BA0
	public void moveToLastPos()
	{
		bool flag = this.xLast >= 0 && this.yLast >= 0;
		if (flag)
		{
			bool flag2 = MainObject.getDistance(this.x, this.y, this.xLast, this.yLast) > 48;
			if (flag2)
			{
				GameScreen.addEffectEnd_ObjTo(56, 0, this.x, this.y, this.ID, this.typeObject, (sbyte)this.Dir, this);
				this.toX = this.xLast;
				this.toY = this.yLast;
				this.x = this.xLast;
				this.y = this.yLast;
			}
			this.xLast = -1;
			this.yLast = -1;
		}
	}

	// Token: 0x06000844 RID: 2116 RVA: 0x0000ACE0 File Offset: 0x00008EE0
	public void addEffFashion()
	{
		this.typeEfffashion = 5;
		this.vecEffFashion.addElement(new Effect_End(165, this));
	}

	// Token: 0x06000845 RID: 2117 RVA: 0x000A7A60 File Offset: 0x000A5C60
	public static DataSkillEff getDataSkillEff(int id)
	{
		bool flag = id == -1;
		DataSkillEff result;
		if (flag)
		{
			result = null;
		}
		else
		{
			result = (DataSkillEff)MainObject.ALL_DATA_SKILL_EFF.get(id.ToString() + string.Empty);
		}
		return result;
	}

	// Token: 0x06000846 RID: 2118 RVA: 0x000A7AA0 File Offset: 0x000A5CA0
	public void updateDataEff()
	{
		for (int i = 0; i < this.vecDataEff.size(); i++)
		{
			DataSkillEff dataSkillEff = (DataSkillEff)this.vecDataEff.elementAt(i);
			bool flag = dataSkillEff != null;
			if (flag)
			{
				dataSkillEff.update();
				bool wantDestroy = dataSkillEff.wantDestroy;
				if (wantDestroy)
				{
					this.vecDataEff.removeElementAt(i);
					i--;
				}
			}
		}
	}

	// Token: 0x06000847 RID: 2119 RVA: 0x000A7B0C File Offset: 0x000A5D0C
	public void addDataEff(short id, int time)
	{
		for (int i = 0; i < this.vecDataEff.size(); i++)
		{
			DataSkillEff dataSkillEff = (DataSkillEff)this.vecDataEff.elementAt(i);
			bool flag = dataSkillEff != null && dataSkillEff.idEff == id;
			if (flag)
			{
				this.vecDataEff.removeElementAt(i);
			}
		}
		DataSkillEff o = new DataSkillEff(id, time);
		this.vecDataEff.addElement(o);
	}

	// Token: 0x06000848 RID: 2120 RVA: 0x000A7B84 File Offset: 0x000A5D84
	public void addDataEff(short id, int time, sbyte typemove, sbyte loop)
	{
		for (int i = 0; i < this.vecDataEff.size(); i++)
		{
			DataSkillEff dataSkillEff = (DataSkillEff)this.vecDataEff.elementAt(i);
			bool flag = dataSkillEff != null && dataSkillEff.idEff == id;
			if (flag)
			{
				this.vecDataEff.removeElementAt(i);
			}
		}
		DataSkillEff o = new DataSkillEff(id, time, typemove, loop);
		this.vecDataEff.addElement(o);
	}

	// Token: 0x06000849 RID: 2121 RVA: 0x000A7BFC File Offset: 0x000A5DFC
	public void removeDataEff(short id)
	{
		for (int i = 0; i < this.vecDataEff.size(); i++)
		{
			DataSkillEff dataSkillEff = (DataSkillEff)this.vecDataEff.elementAt(i);
			bool flag = dataSkillEff != null && dataSkillEff.idEff == id;
			if (flag)
			{
				this.vecDataEff.removeElementAt(i);
			}
		}
	}

	// Token: 0x0600084A RID: 2122 RVA: 0x000A7C5C File Offset: 0x000A5E5C
	public void setbody()
	{
		this.nFrameEffBody = 0;
		short num = this.checkPlayFrameBody();
		bool flag = num != -1;
		if (flag)
		{
			this.imgEffPlayBody = ObjectData.getImageAll(num, ObjectData.HashImageOtherNew, 23000);
		}
	}

	// Token: 0x0600084B RID: 2123 RVA: 0x000A7C9C File Offset: 0x000A5E9C
	public void setLeg()
	{
		this.nFrameEffLeg = 0;
		short num = this.checkPlayFrameLeg();
		bool flag = num != -1;
		if (flag)
		{
			this.imgEffPlayLeg = ObjectData.getImageAll(num, ObjectData.HashImageOtherNew, 23000);
		}
	}

	// Token: 0x0600084C RID: 2124 RVA: 0x000A7CDC File Offset: 0x000A5EDC
	public void setWeapon()
	{
		this.nFrameEffWeapon = 0;
		short num = this.checkPlayFrameWeapon();
		bool flag = num != -1;
		if (flag)
		{
			this.imgEffPlayWeapon = ObjectData.getImageAll(num, ObjectData.HashImageOtherNew, 23000);
		}
	}

	// Token: 0x0600084D RID: 2125 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void setDataPet(short ID, short idImage, sbyte type)
	{
	}

	// Token: 0x0600084E RID: 2126 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void setPetActionFire()
	{
	}

	// Token: 0x0600084F RID: 2127 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void setNextSea()
	{
	}

	// Token: 0x06000850 RID: 2128 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void setPosEvent()
	{
	}

	// Token: 0x06000851 RID: 2129 RVA: 0x000090B5 File Offset: 0x000072B5
	public virtual void loadInfoAgain(CatalogyMonster cata)
	{
	}

	// Token: 0x06000852 RID: 2130 RVA: 0x000A7D1C File Offset: 0x000A5F1C
	public void setBodyBay(short id)
	{
		bool flag = id == -1 || id >= 300;
		if (flag)
		{
			this.idBodybay = id;
		}
		this.setbody();
	}

	// Token: 0x06000853 RID: 2131 RVA: 0x000A7D50 File Offset: 0x000A5F50
	public void setLegBay(short id)
	{
		bool flag = id == -1 || id >= 300;
		if (flag)
		{
			this.idLegBay = id;
		}
		this.setLeg();
	}

	// Token: 0x06000854 RID: 2132 RVA: 0x000A7D84 File Offset: 0x000A5F84
	public void setWeaponBay(short id)
	{
		bool flag = id == -1 || id >= 300;
		if (flag)
		{
			this.idWeaponBay = id;
		}
		this.setWeapon();
	}

	// Token: 0x06000855 RID: 2133 RVA: 0x000A7DB8 File Offset: 0x000A5FB8
	public void setHairBay(short id)
	{
		this.idHairbay = id;
		short num = this.checkEffHair();
		this.imgEffHair = null;
		bool flag = num >= 0;
		if (flag)
		{
			mSystem.outz("checkEffHair " + num.ToString());
			this.imgEffHair = ObjectData.getImageAll(num, ObjectData.HashImageOtherNew, 23000);
		}
	}

	// Token: 0x06000856 RID: 2134 RVA: 0x000734DC File Offset: 0x000716DC
	public virtual bool isTru()
	{
		return false;
	}

	// Token: 0x06000857 RID: 2135 RVA: 0x000A7E18 File Offset: 0x000A6018
	public void SetXlechEffectBongToi()
	{
		bool flag = this.vecEffspec.size() == 0;
		if (!flag)
		{
			mVector mVector = new mVector();
			for (int i = 0; i < this.vecEffspec.size(); i++)
			{
				Effect_Spec effect_Spec = (Effect_Spec)this.vecEffspec.elementAt(i);
				bool flag2 = effect_Spec.typeEffect == 15;
				if (flag2)
				{
					mVector.addElement(effect_Spec);
				}
			}
			bool flag3 = mVector.size() >= 2;
			if (flag3)
			{
				Effect_Spec effect_Spec2 = (Effect_Spec)this.vecEffspec.elementAt(0);
				effect_Spec2.SetXlech(-7);
				effect_Spec2 = (Effect_Spec)this.vecEffspec.elementAt(1);
				effect_Spec2.SetXlech(7);
			}
			else
			{
				bool flag4 = mVector.size() > 0;
				if (flag4)
				{
					Effect_Spec effect_Spec3 = (Effect_Spec)this.vecEffspec.elementAt(0);
					effect_Spec3.SetXlech(0);
				}
			}
		}
	}

	// Token: 0x04000BAC RID: 2988
	public const int DIR_UP = 1;

	// Token: 0x04000BAD RID: 2989
	public const int DIR_DOWN = 3;

	// Token: 0x04000BAE RID: 2990
	public const int DIR_LEFT = 0;

	// Token: 0x04000BAF RID: 2991
	public const int DIR_RIGHT = 2;

	// Token: 0x04000BB0 RID: 2992
	public const int AC_STAND = 0;

	// Token: 0x04000BB1 RID: 2993
	public const int AC_MOVE = 1;

	// Token: 0x04000BB2 RID: 2994
	public const int AC_FIRE = 2;

	// Token: 0x04000BB3 RID: 2995
	public const int AC_AVA = 3;

	// Token: 0x04000BB4 RID: 2996
	public const int AC_DIE = 4;

	// Token: 0x04000BB5 RID: 2997
	public const int AC_UP_BOAT = 5;

	// Token: 0x04000BB6 RID: 2998
	public const sbyte CAT_HAMMER_DIAL = -8;

	// Token: 0x04000BB7 RID: 2999
	public const sbyte CAT_PLAYER = 0;

	// Token: 0x04000BB8 RID: 3000
	public const sbyte CAT_MONSTER = 1;

	// Token: 0x04000BB9 RID: 3001
	public const sbyte CAT_NPC = 2;

	// Token: 0x04000BBA RID: 3002
	public const sbyte CAT_ITEM = 3;

	// Token: 0x04000BBB RID: 3003
	public const sbyte CAT_POTION = 4;

	// Token: 0x04000BBC RID: 3004
	public const sbyte CAT_POTION_QUEST = 5;

	// Token: 0x04000BBD RID: 3005
	public const sbyte CAT_MONEY = 6;

	// Token: 0x04000BBE RID: 3006
	public const sbyte CAT_POTION_MATERIAL = 7;

	// Token: 0x04000BBF RID: 3007
	public const sbyte CAT_POTION_CLAN = 8;

	// Token: 0x04000BC0 RID: 3008
	public const sbyte CAT_EFF_ITEM = 9;

	// Token: 0x04000BC1 RID: 3009
	public const sbyte CAT_PET = 10;

	// Token: 0x04000BC2 RID: 3010
	public const sbyte CAT_POTION_EVENT = 11;

	// Token: 0x04000BC3 RID: 3011
	public const sbyte CAT_DATA_ATTRI_KICH_AN = 96;

	// Token: 0x04000BC4 RID: 3012
	public const sbyte CAT_DATA_PLASH = 97;

	// Token: 0x04000BC5 RID: 3013
	public const sbyte CAT_DATA_ITEM_MAP = 98;

	// Token: 0x04000BC6 RID: 3014
	public const sbyte CAT_XP = 99;

	// Token: 0x04000BC7 RID: 3015
	public const sbyte CAT_IMAGE_OTHER = 100;

	// Token: 0x04000BC8 RID: 3016
	public const sbyte CAT_ITEM_BOAT = 102;

	// Token: 0x04000BC9 RID: 3017
	public const sbyte CAT_ITEM_HAIR = 103;

	// Token: 0x04000BCA RID: 3018
	public const sbyte CAT_ITEM_SKILL = 104;

	// Token: 0x04000BCB RID: 3019
	public const sbyte CAT_ITEM_FASHION = 105;

	// Token: 0x04000BCC RID: 3020
	public const sbyte CAT_ICON_CLAN = 107;

	// Token: 0x04000BCD RID: 3021
	public const sbyte CAT_ITEM_HEAD = 108;

	// Token: 0x04000BCE RID: 3022
	public const sbyte CAT_ITEM_WANTED = 109;

	// Token: 0x04000BCF RID: 3023
	public const sbyte CAT_ITEM_PET = 110;

	// Token: 0x04000BD0 RID: 3024
	public const sbyte PLAYER_NORMAL = 0;

	// Token: 0x04000BD1 RID: 3025
	public const sbyte PLAYER_SUPPORT = 1;

	// Token: 0x04000BD2 RID: 3026
	public const sbyte PLAYER_SHIPER = 2;

	// Token: 0x04000BD3 RID: 3027
	public const sbyte PLAYER_NPC_EVENT = 3;

	// Token: 0x04000BD4 RID: 3028
	public const sbyte PK_DOSAT = 0;

	// Token: 0x04000BD5 RID: 3029
	public const sbyte PK_SATNHAN = 1;

	// Token: 0x04000BD6 RID: 3030
	public const sbyte PK_DAUTRUONG = 2;

	// Token: 0x04000BD7 RID: 3031
	public const sbyte PK_CHIENDAU = 3;

	// Token: 0x04000BD8 RID: 3032
	public const sbyte PK_COLOR = 4;

	// Token: 0x04000BD9 RID: 3033
	public const sbyte CLASS_ALL = 0;

	// Token: 0x04000BDA RID: 3034
	public const sbyte CLASS_LUFFY = 1;

	// Token: 0x04000BDB RID: 3035
	public const sbyte CLASS_ZORO = 2;

	// Token: 0x04000BDC RID: 3036
	public const sbyte CLASS_SANJI = 3;

	// Token: 0x04000BDD RID: 3037
	public const sbyte CLASS_NAMI = 4;

	// Token: 0x04000BDE RID: 3038
	public const sbyte CLASS_USSOP = 5;

	// Token: 0x04000BDF RID: 3039
	public const sbyte CLASS_MONSTER = 6;

	// Token: 0x04000BE0 RID: 3040
	public const sbyte WEAR_WEAPON = 0;

	// Token: 0x04000BE1 RID: 3041
	public const sbyte WEAR_HAT = 1;

	// Token: 0x04000BE2 RID: 3042
	public const sbyte WEAR_DAY = 2;

	// Token: 0x04000BE3 RID: 3043
	public const sbyte WEAR_BODY = 3;

	// Token: 0x04000BE4 RID: 3044
	public const sbyte WEAR_RING = 4;

	// Token: 0x04000BE5 RID: 3045
	public const sbyte WEAR_LEG = 5;

	// Token: 0x04000BE6 RID: 3046
	public const sbyte WEAR_HEAD = 6;

	// Token: 0x04000BE7 RID: 3047
	public const sbyte WEAR_HAIR = 7;

	// Token: 0x04000BE8 RID: 3048
	public const sbyte ONE_PART_HAIR = 5;

	// Token: 0x04000BE9 RID: 3049
	public const sbyte ONE_PART_HEAD = 0;

	// Token: 0x04000BEA RID: 3050
	public const sbyte ACTIONBOAT_NORMAL = 0;

	// Token: 0x04000BEB RID: 3051
	public const sbyte ACTIONBOAT_UP = 1;

	// Token: 0x04000BEC RID: 3052
	public const sbyte ACTIONBOAT_DOWN = 2;

	// Token: 0x04000BED RID: 3053
	public const sbyte ACTIONBOAT_UP_2 = 3;

	// Token: 0x04000BEE RID: 3054
	public const sbyte ACTIONBOAT_DOWN_2 = 4;

	// Token: 0x04000BEF RID: 3055
	public const sbyte PIRATE_NORMAL = -1;

	// Token: 0x04000BF0 RID: 3056
	public const sbyte PIRATE_GOLD = 0;

	// Token: 0x04000BF1 RID: 3057
	public const sbyte PIRATE_WHITE = 1;

	// Token: 0x04000BF2 RID: 3058
	public const sbyte PIRATE_BLACK = 2;

	// Token: 0x04000BF3 RID: 3059
	public const sbyte BOSS_SUPER_BOSS = 1;

	// Token: 0x04000BF4 RID: 3060
	public const sbyte EFASHION_VALENTINE = 1;

	// Token: 0x04000BF5 RID: 3061
	public const sbyte EFASHION_WB_WOMEN = 2;

	// Token: 0x04000BF6 RID: 3062
	public const sbyte EFASHION_WB_MEN = 3;

	// Token: 0x04000BF7 RID: 3063
	public const sbyte EFASHION_DRAGON = 4;

	// Token: 0x04000BF8 RID: 3064
	public const sbyte EFASHION_RAU_DEN = 5;

	// Token: 0x04000BF9 RID: 3065
	private const sbyte MOVE_LEFT = 0;

	// Token: 0x04000BFA RID: 3066
	private const sbyte MOVE_RIGHT = 1;

	// Token: 0x04000BFB RID: 3067
	public string chatNPC = string.Empty;

	// Token: 0x04000BFC RID: 3068
	public string name = string.Empty;

	// Token: 0x04000BFD RID: 3069
	public string strChatPopup;

	// Token: 0x04000BFE RID: 3070
	public string namePlayer = string.Empty;

	// Token: 0x04000BFF RID: 3071
	public bool isDrop42;

	// Token: 0x04000C00 RID: 3072
	public string nameGiaotiep = string.Empty;

	// Token: 0x04000C01 RID: 3073
	public string npcChatMenu = string.Empty;

	// Token: 0x04000C02 RID: 3074
	public static string[] strHelp;

	// Token: 0x04000C03 RID: 3075
	public static int StepHelp = 0;

	// Token: 0x04000C04 RID: 3076
	public short ID;

	// Token: 0x04000C05 RID: 3077
	public short IdIcon;

	// Token: 0x04000C06 RID: 3078
	public short IDMainShiper;

	// Token: 0x04000C07 RID: 3079
	public short IdEffShow;

	// Token: 0x04000C08 RID: 3080
	public int[][] mActionMonSter;

	// Token: 0x04000C09 RID: 3081
	public int[] mActionStandMonSter;

	// Token: 0x04000C0A RID: 3082
	public short[] myBoat;

	// Token: 0x04000C0B RID: 3083
	public int[] mValuePvP;

	// Token: 0x04000C0C RID: 3084
	public Item_Drop[] mItemDrop;

	// Token: 0x04000C0D RID: 3085
	public sbyte typeMoveMonster;

	// Token: 0x04000C0E RID: 3086
	public short head = -1;

	// Token: 0x04000C0F RID: 3087
	public short body = -1;

	// Token: 0x04000C10 RID: 3088
	public short leg = -1;

	// Token: 0x04000C11 RID: 3089
	public short weapon = -1;

	// Token: 0x04000C12 RID: 3090
	public short hair = -1;

	// Token: 0x04000C13 RID: 3091
	public short hat = -1;

	// Token: 0x04000C14 RID: 3092
	public short weaponFashion = -1;

	// Token: 0x04000C15 RID: 3093
	public short headMain = -1;

	// Token: 0x04000C16 RID: 3094
	public short bodyMain = -1;

	// Token: 0x04000C17 RID: 3095
	public short legMain = -1;

	// Token: 0x04000C18 RID: 3096
	public short hairMain = -1;

	// Token: 0x04000C19 RID: 3097
	public int x;

	// Token: 0x04000C1A RID: 3098
	public int y;

	// Token: 0x04000C1B RID: 3099
	public int xLast;

	// Token: 0x04000C1C RID: 3100
	public int yLast;

	// Token: 0x04000C1D RID: 3101
	public int dx;

	// Token: 0x04000C1E RID: 3102
	public int dy;

	// Token: 0x04000C1F RID: 3103
	public int dyMain;

	// Token: 0x04000C20 RID: 3104
	public int dyMovePet;

	// Token: 0x04000C21 RID: 3105
	public int dySea;

	// Token: 0x04000C22 RID: 3106
	public int vySea;

	// Token: 0x04000C23 RID: 3107
	public int vx;

	// Token: 0x04000C24 RID: 3108
	public int vy;

	// Token: 0x04000C25 RID: 3109
	public int wOne;

	// Token: 0x04000C26 RID: 3110
	public int hOne;

	// Token: 0x04000C27 RID: 3111
	public int vMax;

	// Token: 0x04000C28 RID: 3112
	public int vMaxYSea;

	// Token: 0x04000C29 RID: 3113
	public int ySort;

	// Token: 0x04000C2A RID: 3114
	public int ysai;

	// Token: 0x04000C2B RID: 3115
	public int xsai;

	// Token: 0x04000C2C RID: 3116
	public int frame;

	// Token: 0x04000C2D RID: 3117
	public int frameOneStep = -1;

	// Token: 0x04000C2E RID: 3118
	public int toX;

	// Token: 0x04000C2F RID: 3119
	public int toY;

	// Token: 0x04000C30 RID: 3120
	public int toXNew;

	// Token: 0x04000C31 RID: 3121
	public int toYNew;

	// Token: 0x04000C32 RID: 3122
	public int weapon_frame;

	// Token: 0x04000C33 RID: 3123
	public int xStand;

	// Token: 0x04000C34 RID: 3124
	public int yStand;

	// Token: 0x04000C35 RID: 3125
	public int xAnchor;

	// Token: 0x04000C36 RID: 3126
	public int yAnchor;

	// Token: 0x04000C37 RID: 3127
	public int xSeaAnchor;

	// Token: 0x04000C38 RID: 3128
	public int ySeaAnchor;

	// Token: 0x04000C39 RID: 3129
	public int nFrame;

	// Token: 0x04000C3A RID: 3130
	public int wAvatar;

	// Token: 0x04000C3B RID: 3131
	public int hAvatar;

	// Token: 0x04000C3C RID: 3132
	public int hIconFocus;

	// Token: 0x04000C3D RID: 3133
	public int vXEffAva;

	// Token: 0x04000C3E RID: 3134
	public int xUpBoat;

	// Token: 0x04000C3F RID: 3135
	public int yUpBoat;

	// Token: 0x04000C40 RID: 3136
	public int wNameFocus = 60;

	// Token: 0x04000C41 RID: 3137
	public int wNameNPC;

	// Token: 0x04000C42 RID: 3138
	public int timeBeginUpdateMove;

	// Token: 0x04000C43 RID: 3139
	public int tickSoundMove;

	// Token: 0x04000C44 RID: 3140
	public int xpArena;

	// Token: 0x04000C45 RID: 3141
	public int timeItemDropEvent;

	// Token: 0x04000C46 RID: 3142
	public int checkWW;

	// Token: 0x04000C47 RID: 3143
	public int killWW;

	// Token: 0x04000C48 RID: 3144
	public int deadWW;

	// Token: 0x04000C49 RID: 3145
	public int dyShadow;

	// Token: 0x04000C4A RID: 3146
	public int tickEffHead;

	// Token: 0x04000C4B RID: 3147
	public int indexBodySkill;

	// Token: 0x04000C4C RID: 3148
	public int tickAfterSkill = 50;

	// Token: 0x04000C4D RID: 3149
	public int xDie;

	// Token: 0x04000C4E RID: 3150
	public int yDie;

	// Token: 0x04000C4F RID: 3151
	public int dyDie;

	// Token: 0x04000C50 RID: 3152
	public int vxDie;

	// Token: 0x04000C51 RID: 3153
	public int vyDie;

	// Token: 0x04000C52 RID: 3154
	public int Hp;

	// Token: 0x04000C53 RID: 3155
	public int HpEff;

	// Token: 0x04000C54 RID: 3156
	public int Mp;

	// Token: 0x04000C55 RID: 3157
	public int maxHp;

	// Token: 0x04000C56 RID: 3158
	public int maxMp;

	// Token: 0x04000C57 RID: 3159
	public int Lv;

	// Token: 0x04000C58 RID: 3160
	public int pointPk;

	// Token: 0x04000C59 RID: 3161
	public int percentLv;

	// Token: 0x04000C5A RID: 3162
	public int wanted;

	// Token: 0x04000C5B RID: 3163
	public int PointPvP;

	// Token: 0x04000C5C RID: 3164
	public int LvThongThao;

	// Token: 0x04000C5D RID: 3165
	public int percentThongThao;

	// Token: 0x04000C5E RID: 3166
	public int rankWanted = -1;

	// Token: 0x04000C5F RID: 3167
	public int Action;

	// Token: 0x04000C60 RID: 3168
	public int Dir;

	// Token: 0x04000C61 RID: 3169
	public int type_left_right;

	// Token: 0x04000C62 RID: 3170
	public int DirSpec;

	// Token: 0x04000C63 RID: 3171
	public int timeFreeMove;

	// Token: 0x04000C64 RID: 3172
	public int timeRevice;

	// Token: 0x04000C65 RID: 3173
	public int timeBeFire;

	// Token: 0x04000C66 RID: 3174
	public int tickMapTrain;

	// Token: 0x04000C67 RID: 3175
	public int timeFreeFire;

	// Token: 0x04000C68 RID: 3176
	public int timeEffRemoveChar;

	// Token: 0x04000C69 RID: 3177
	public int timeDragon;

	// Token: 0x04000C6A RID: 3178
	public int timeFullSet;

	// Token: 0x04000C6B RID: 3179
	public int timeOutScreen;

	// Token: 0x04000C6C RID: 3180
	public int f;

	// Token: 0x04000C6D RID: 3181
	public int dhCharPopup = 30;

	// Token: 0x04000C6E RID: 3182
	public int timeInviMove;

	// Token: 0x04000C6F RID: 3183
	public int timeSafe;

	// Token: 0x04000C70 RID: 3184
	public long timeBeginSafe;

	// Token: 0x04000C71 RID: 3185
	public long timeBeginItemDropEvent;

	// Token: 0x04000C72 RID: 3186
	public int timeRemove = 60;

	// Token: 0x04000C73 RID: 3187
	public int timeLeft = -1;

	// Token: 0x04000C74 RID: 3188
	public sbyte state;

	// Token: 0x04000C75 RID: 3189
	public MainSkill Skilldefault;

	// Token: 0x04000C76 RID: 3190
	public MainObject objMainFocus;

	// Token: 0x04000C77 RID: 3191
	public BigBossLittleGraden bossLittle;

	// Token: 0x04000C78 RID: 3192
	public static mImage imgShadow;

	// Token: 0x04000C79 RID: 3193
	public static mImage imgShadow2;

	// Token: 0x04000C7A RID: 3194
	public static mImage imgShadow3;

	// Token: 0x04000C7B RID: 3195
	public MyHashTable hashEquip = new MyHashTable();

	// Token: 0x04000C7C RID: 3196
	public PopupChat chat;

	// Token: 0x04000C7D RID: 3197
	public MainSkill skillMonDefault;

	// Token: 0x04000C7E RID: 3198
	public Start_Skill skillCurrent;

	// Token: 0x04000C7F RID: 3199
	public Plash plashNow;

	// Token: 0x04000C80 RID: 3200
	public sbyte downSpeedWater;

	// Token: 0x04000C81 RID: 3201
	public sbyte maxEffShip;

	// Token: 0x04000C82 RID: 3202
	public sbyte indexShip;

	// Token: 0x04000C83 RID: 3203
	public sbyte stepLeg;

	// Token: 0x04000C84 RID: 3204
	public sbyte colorXPArena;

	// Token: 0x04000C85 RID: 3205
	public sbyte levelPerfect;

	// Token: 0x04000C86 RID: 3206
	public sbyte typeShadow = -1;

	// Token: 0x04000C87 RID: 3207
	public sbyte countKick;

	// Token: 0x04000C88 RID: 3208
	public sbyte countAva;

	// Token: 0x04000C89 RID: 3209
	public sbyte lechYHead;

	// Token: 0x04000C8A RID: 3210
	public sbyte lvHeart;

	// Token: 0x04000C8B RID: 3211
	public sbyte clazz;

	// Token: 0x04000C8C RID: 3212
	public sbyte typeEffStand;

	// Token: 0x04000C8D RID: 3213
	public sbyte typeObject;

	// Token: 0x04000C8E RID: 3214
	public sbyte typeSpecMonSter;

	// Token: 0x04000C8F RID: 3215
	public sbyte colorName;

	// Token: 0x04000C90 RID: 3216
	public sbyte typePK = -1;

	// Token: 0x04000C91 RID: 3217
	public sbyte typePirate = -1;

	// Token: 0x04000C92 RID: 3218
	public sbyte DirNew;

	// Token: 0x04000C93 RID: 3219
	public sbyte typeQuest;

	// Token: 0x04000C94 RID: 3220
	public sbyte typeSpecCharList;

	// Token: 0x04000C95 RID: 3221
	public sbyte typePlayer;

	// Token: 0x04000C96 RID: 3222
	public sbyte indexTeam;

	// Token: 0x04000C97 RID: 3223
	public sbyte indexPaintView;

	// Token: 0x04000C98 RID: 3224
	public sbyte typeActionBoat;

	// Token: 0x04000C99 RID: 3225
	public sbyte isHumanMonster;

	// Token: 0x04000C9A RID: 3226
	public sbyte typeIconNPC;

	// Token: 0x04000C9B RID: 3227
	public sbyte isDonotShowHat;

	// Token: 0x04000C9C RID: 3228
	public sbyte typeBossMonster;

	// Token: 0x04000C9D RID: 3229
	public sbyte typePet;

	// Token: 0x04000C9E RID: 3230
	public sbyte typeColor7;

	// Token: 0x04000C9F RID: 3231
	public sbyte typeNpcEvent;

	// Token: 0x04000CA0 RID: 3232
	public sbyte isDonotShowWeaponF;

	// Token: 0x04000CA1 RID: 3233
	public sbyte indexEff_1;

	// Token: 0x04000CA2 RID: 3234
	public sbyte isPokemon;

	// Token: 0x04000CA3 RID: 3235
	public sbyte dxEye;

	// Token: 0x04000CA4 RID: 3236
	public sbyte dyEye;

	// Token: 0x04000CA5 RID: 3237
	public sbyte indexEye;

	// Token: 0x04000CA6 RID: 3238
	public sbyte demDonotPaint;

	// Token: 0x04000CA7 RID: 3239
	public sbyte indexFullSet;

	// Token: 0x04000CA8 RID: 3240
	public sbyte thanhtichPvP = -1;

	// Token: 0x04000CA9 RID: 3241
	public sbyte thanhtichLv = -1;

	// Token: 0x04000CAA RID: 3242
	public sbyte typeEfffashion = -1;

	// Token: 0x04000CAB RID: 3243
	public long timeLoadInfo;

	// Token: 0x04000CAC RID: 3244
	public long timeDie;

	// Token: 0x04000CAD RID: 3245
	public bool isDirMove;

	// Token: 0x04000CAE RID: 3246
	public bool isTanHinh;

	// Token: 0x04000CAF RID: 3247
	public bool isPaintWeapon = true;

	// Token: 0x04000CB0 RID: 3248
	public bool isPaintSpec;

	// Token: 0x04000CB1 RID: 3249
	public bool isPaintLeg = true;

	// Token: 0x04000CB2 RID: 3250
	public bool isPlayStand;

	// Token: 0x04000CB3 RID: 3251
	public bool isPet;

	// Token: 0x04000CB4 RID: 3252
	public bool isFlyDie;

	// Token: 0x04000CB5 RID: 3253
	public bool isDragon;

	// Token: 0x04000CB6 RID: 3254
	public bool isDie;

	// Token: 0x04000CB7 RID: 3255
	public bool isRemove;

	// Token: 0x04000CB8 RID: 3256
	public bool isStop;

	// Token: 0x04000CB9 RID: 3257
	public bool isInfo;

	// Token: 0x04000CBA RID: 3258
	public bool isLoadTemplate;

	// Token: 0x04000CBB RID: 3259
	public bool isParty;

	// Token: 0x04000CBC RID: 3260
	public bool isSend;

	// Token: 0x04000CBD RID: 3261
	public bool isMoveNor;

	// Token: 0x04000CBE RID: 3262
	public short[] posTransRoad;

	// Token: 0x04000CBF RID: 3263
	public short[] mSkillMapTrain;

	// Token: 0x04000CC0 RID: 3264
	public mVector vecSkillFires = new mVector("Mainobject.vecSkillFires");

	// Token: 0x04000CC1 RID: 3265
	public mVector vecBuffCur = new mVector("Mainobject.vecEffBuff");

	// Token: 0x04000CC2 RID: 3266
	public mVector vecEffspec = new mVector("Mainobject.vecEffspec");

	// Token: 0x04000CC3 RID: 3267
	public mVector vecTrade = new mVector("Mainobject.vecTrade");

	// Token: 0x04000CC4 RID: 3268
	public mVector vecEffFashion = new mVector("Mainobject.veceffFas");

	// Token: 0x04000CC5 RID: 3269
	public sbyte isTrade;

	// Token: 0x04000CC6 RID: 3270
	public int gem;

	// Token: 0x04000CC7 RID: 3271
	public int vnd;

	// Token: 0x04000CC8 RID: 3272
	public long beli;

	// Token: 0x04000CC9 RID: 3273
	public int bua;

	// Token: 0x04000CCA RID: 3274
	public int diemNap;

	// Token: 0x04000CCB RID: 3275
	public static int[][] mPosMapTrain = new int[][]
	{
		new int[]
		{
			5,
			10
		},
		new int[]
		{
			18,
			9
		},
		new int[]
		{
			24,
			12
		}
	};

	// Token: 0x04000CCC RID: 3276
	public MainClan clan;

	// Token: 0x04000CCD RID: 3277
	public MainSudo sudo;

	// Token: 0x04000CCE RID: 3278
	public Boat boatSea;

	// Token: 0x04000CCF RID: 3279
	public mVector vecDataEff = new mVector();

	// Token: 0x04000CD0 RID: 3280
	private int lastTick;

	// Token: 0x04000CD1 RID: 3281
	private int framepaint;

	// Token: 0x04000CD2 RID: 3282
	public int left_right_Sea;

	// Token: 0x04000CD3 RID: 3283
	public int tickJoinSea;

	// Token: 0x04000CD4 RID: 3284
	public long timeBegin;

	// Token: 0x04000CD5 RID: 3285
	private int tickEffFashion;

	// Token: 0x04000CD6 RID: 3286
	public static sbyte testEFF = 0;

	// Token: 0x04000CD7 RID: 3287
	public int vDy;

	// Token: 0x04000CD8 RID: 3288
	public static int[][][] CharInfo = new int[][][]
	{
		new int[][]
		{
			new int[]
			{
				0,
				-5,
				-42
			},
			new int[]
			{
				0,
				-11,
				-18
			},
			new int[]
			{
				0,
				-8,
				-30
			},
			new int[]
			{
				0,
				-15,
				-39
			},
			new int[]
			{
				0,
				-9,
				-44
			},
			new int[]
			{
				0,
				-8,
				-44
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				0,
				-5,
				-41
			},
			new int[]
			{
				0,
				-11,
				-18
			},
			new int[]
			{
				0,
				-8,
				-29
			},
			new int[]
			{
				0,
				-15,
				-38
			},
			new int[]
			{
				0,
				-9,
				-43
			},
			new int[]
			{
				0,
				-8,
				-43
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				0,
				-11,
				-40
			},
			new int[]
			{
				1,
				-18,
				-18
			},
			new int[]
			{
				1,
				-11,
				-31
			},
			new int[]
			{
				1,
				-18,
				-42
			},
			new int[]
			{
				0,
				-15,
				-42
			},
			new int[]
			{
				0,
				-14,
				-42
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				0,
				-11,
				-41
			},
			new int[]
			{
				2,
				-6,
				-18
			},
			new int[]
			{
				2,
				-7,
				-30
			},
			new int[]
			{
				2,
				-14,
				-43
			},
			new int[]
			{
				0,
				-15,
				-43
			},
			new int[]
			{
				0,
				-14,
				-43
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				0,
				-11,
				-43
			},
			new int[]
			{
				3,
				-6,
				-22
			},
			new int[]
			{
				3,
				-17,
				-37
			},
			new int[]
			{
				3,
				-17,
				-45
			},
			new int[]
			{
				0,
				-15,
				-45
			},
			new int[]
			{
				0,
				-14,
				-45
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				0,
				-11,
				-41
			},
			new int[]
			{
				4,
				-14,
				-20
			},
			new int[]
			{
				3,
				-17,
				-35
			},
			new int[]
			{
				4,
				-17,
				-43
			},
			new int[]
			{
				0,
				-15,
				-43
			},
			new int[]
			{
				0,
				-14,
				-43
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				0,
				-11,
				-42
			},
			new int[]
			{
				5,
				-5,
				-19
			},
			new int[]
			{
				2,
				-7,
				-31
			},
			new int[]
			{
				2,
				-14,
				-44
			},
			new int[]
			{
				0,
				-15,
				-44
			},
			new int[]
			{
				0,
				-14,
				-44
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				0,
				-11,
				-44
			},
			new int[]
			{
				6,
				-9,
				-23
			},
			new int[]
			{
				4,
				-13,
				-35
			},
			new int[]
			{
				5,
				-17,
				-46
			},
			new int[]
			{
				0,
				-15,
				-46
			},
			new int[]
			{
				0,
				-14,
				-46
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				1,
				-7,
				-40
			},
			new int[]
			{
				7,
				-12,
				-17
			},
			new int[]
			{
				5,
				-15,
				-29
			},
			new int[]
			{
				6,
				-22,
				-47
			},
			new int[]
			{
				0,
				-11,
				-42
			},
			new int[]
			{
				0,
				-10,
				-42
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				1,
				-7,
				-39
			},
			new int[]
			{
				7,
				-12,
				-17
			},
			new int[]
			{
				5,
				-15,
				-28
			},
			new int[]
			{
				6,
				-22,
				-46
			},
			new int[]
			{
				0,
				-11,
				-41
			},
			new int[]
			{
				0,
				-10,
				-41
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				3,
				-6,
				-39
			},
			new int[]
			{
				7,
				-12,
				-17
			},
			new int[]
			{
				5,
				-15,
				-28
			},
			new int[]
			{
				6,
				-22,
				-46
			},
			new int[]
			{
				0,
				-10,
				-41
			},
			new int[]
			{
				0,
				-9,
				-41
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				2,
				-7,
				-42
			},
			new int[]
			{
				6,
				-9,
				-18
			},
			new int[]
			{
				5,
				-15,
				-31
			},
			new int[]
			{
				7,
				-22,
				-43
			},
			new int[]
			{
				0,
				-11,
				-44
			},
			new int[]
			{
				0,
				-10,
				-44
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				1,
				-7,
				-41
			},
			new int[]
			{
				5,
				-4,
				-16
			},
			new int[]
			{
				5,
				-15,
				-30
			},
			new int[]
			{
				8,
				-22,
				-42
			},
			new int[]
			{
				0,
				-11,
				-43
			},
			new int[]
			{
				0,
				-10,
				-43
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				1,
				-10,
				-41
			},
			new int[]
			{
				8,
				-17,
				-18
			},
			new int[]
			{
				2,
				-6,
				-30
			},
			new int[]
			{
				9,
				-18,
				-32
			},
			new int[]
			{
				0,
				-14,
				-43
			},
			new int[]
			{
				0,
				-13,
				-43
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				1,
				-10,
				-42
			},
			new int[]
			{
				6,
				-8,
				-18
			},
			new int[]
			{
				2,
				-6,
				-31
			},
			new int[]
			{
				9,
				-18,
				-33
			},
			new int[]
			{
				0,
				-14,
				-44
			},
			new int[]
			{
				0,
				-13,
				-44
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				2,
				-13,
				-39
			},
			new int[]
			{
				9,
				-21,
				-18
			},
			new int[]
			{
				6,
				-19,
				-28
			},
			new int[]
			{
				10,
				-1,
				-31
			},
			new int[]
			{
				0,
				-17,
				-41
			},
			new int[]
			{
				0,
				-16,
				-41
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				2,
				-13,
				-39
			},
			new int[]
			{
				14,
				-9,
				-18
			},
			new int[]
			{
				6,
				-19,
				-28
			},
			new int[]
			{
				10,
				-1,
				-31
			},
			new int[]
			{
				0,
				-17,
				-41
			},
			new int[]
			{
				0,
				-16,
				-41
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				4,
				-13,
				-40
			},
			new int[]
			{
				9,
				-21,
				-18
			},
			new int[]
			{
				7,
				-19,
				-29
			},
			new int[]
			{
				11,
				5,
				-17
			},
			new int[]
			{
				1,
				-17,
				-42
			},
			new int[]
			{
				1,
				-16,
				-42
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				4,
				-13,
				-40
			},
			new int[]
			{
				14,
				-9,
				-18
			},
			new int[]
			{
				7,
				-19,
				-29
			},
			new int[]
			{
				11,
				5,
				-17
			},
			new int[]
			{
				1,
				-17,
				-42
			},
			new int[]
			{
				1,
				-16,
				-42
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				1,
				-10,
				-41
			},
			new int[]
			{
				8,
				-17,
				-18
			},
			new int[]
			{
				8,
				-2,
				-46
			},
			new int[]
			{
				12,
				-9,
				-55
			},
			new int[]
			{
				0,
				-14,
				-43
			},
			new int[]
			{
				0,
				-13,
				-43
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				1,
				-10,
				-41
			},
			new int[]
			{
				6,
				-8,
				-18
			},
			new int[]
			{
				8,
				-2,
				-46
			},
			new int[]
			{
				12,
				-9,
				-55
			},
			new int[]
			{
				0,
				-14,
				-43
			},
			new int[]
			{
				0,
				-13,
				-43
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				1,
				-10,
				-41
			},
			new int[]
			{
				8,
				-17,
				-18
			},
			new int[]
			{
				9,
				-2,
				-48
			},
			new int[]
			{
				13,
				-4,
				-56
			},
			new int[]
			{
				0,
				-14,
				-43
			},
			new int[]
			{
				0,
				-13,
				-43
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				1,
				-10,
				-41
			},
			new int[]
			{
				6,
				-8,
				-18
			},
			new int[]
			{
				9,
				-2,
				-48
			},
			new int[]
			{
				13,
				-4,
				-56
			},
			new int[]
			{
				0,
				-14,
				-43
			},
			new int[]
			{
				0,
				-13,
				-43
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				1,
				-12,
				-39
			},
			new int[]
			{
				8,
				-17,
				-18
			},
			new int[]
			{
				10,
				-4,
				-32
			},
			new int[]
			{
				14,
				4,
				-50
			},
			new int[]
			{
				0,
				-16,
				-41
			},
			new int[]
			{
				0,
				-15,
				-41
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				1,
				-12,
				-39
			},
			new int[]
			{
				6,
				-8,
				-18
			},
			new int[]
			{
				10,
				-4,
				-32
			},
			new int[]
			{
				14,
				4,
				-50
			},
			new int[]
			{
				0,
				-16,
				-41
			},
			new int[]
			{
				0,
				-15,
				-41
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				2,
				-10,
				-40
			},
			new int[]
			{
				9,
				-21,
				-18
			},
			new int[]
			{
				11,
				-18,
				-29
			},
			new int[]
			{
				15,
				5,
				-17
			},
			new int[]
			{
				0,
				-14,
				-42
			},
			new int[]
			{
				0,
				-13,
				-42
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				2,
				-10,
				-40
			},
			new int[]
			{
				14,
				-9,
				-18
			},
			new int[]
			{
				11,
				-18,
				-29
			},
			new int[]
			{
				15,
				5,
				-17
			},
			new int[]
			{
				0,
				-14,
				-42
			},
			new int[]
			{
				0,
				-13,
				-42
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				1,
				-5,
				-44
			},
			new int[]
			{
				10,
				-21,
				-27
			},
			new int[]
			{
				12,
				-9,
				-32
			},
			new int[]
			{
				16,
				-16,
				-41
			},
			new int[]
			{
				0,
				-9,
				-46
			},
			new int[]
			{
				0,
				-8,
				-46
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				2,
				-7,
				-44
			},
			new int[]
			{
				11,
				-23,
				-29
			},
			new int[]
			{
				13,
				-12,
				-32
			},
			new int[]
			{
				17,
				-17,
				-41
			},
			new int[]
			{
				0,
				-11,
				-46
			},
			new int[]
			{
				0,
				-10,
				-46
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				2,
				-7,
				-44
			},
			new int[]
			{
				12,
				-28,
				-25
			},
			new int[]
			{
				13,
				-12,
				-32
			},
			new int[]
			{
				17,
				-17,
				-41
			},
			new int[]
			{
				0,
				-11,
				-46
			},
			new int[]
			{
				0,
				-10,
				-46
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				2,
				-7,
				-44
			},
			new int[]
			{
				13,
				-17,
				-37
			},
			new int[]
			{
				13,
				-12,
				-32
			},
			new int[]
			{
				17,
				-17,
				-41
			},
			new int[]
			{
				0,
				-11,
				-46
			},
			new int[]
			{
				0,
				-10,
				-46
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				1,
				-7,
				-41
			},
			new int[]
			{
				8,
				-17,
				-18
			},
			new int[]
			{
				14,
				-16,
				-29
			},
			new int[]
			{
				18,
				-25,
				-42
			},
			new int[]
			{
				0,
				-11,
				-43
			},
			new int[]
			{
				0,
				-10,
				-43
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				1,
				-7,
				-41
			},
			new int[]
			{
				14,
				-9,
				-17
			},
			new int[]
			{
				14,
				-16,
				-29
			},
			new int[]
			{
				18,
				-25,
				-42
			},
			new int[]
			{
				0,
				-11,
				-43
			},
			new int[]
			{
				0,
				-10,
				-43
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				1,
				-4,
				-41
			},
			new int[]
			{
				8,
				-17,
				-18
			},
			new int[]
			{
				15,
				-11,
				-34
			},
			new int[]
			{
				19,
				-16,
				-47
			},
			new int[]
			{
				0,
				-8,
				-43
			},
			new int[]
			{
				0,
				-7,
				-43
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				1,
				-4,
				-41
			},
			new int[]
			{
				14,
				-9,
				-17
			},
			new int[]
			{
				15,
				-11,
				-34
			},
			new int[]
			{
				19,
				-16,
				-47
			},
			new int[]
			{
				0,
				-8,
				-43
			},
			new int[]
			{
				0,
				-7,
				-43
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				1,
				-7,
				-41
			},
			new int[]
			{
				8,
				-17,
				-18
			},
			new int[]
			{
				16,
				-19,
				-30
			},
			new int[]
			{
				20,
				-28,
				-43
			},
			new int[]
			{
				0,
				-11,
				-43
			},
			new int[]
			{
				0,
				-10,
				-43
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				1,
				-7,
				-41
			},
			new int[]
			{
				14,
				-9,
				-17
			},
			new int[]
			{
				16,
				-19,
				-30
			},
			new int[]
			{
				20,
				-28,
				-43
			},
			new int[]
			{
				0,
				-11,
				-43
			},
			new int[]
			{
				0,
				-10,
				-43
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				1,
				-4,
				-41
			},
			new int[]
			{
				8,
				-17,
				-18
			},
			new int[]
			{
				17,
				-15,
				-34
			},
			new int[]
			{
				21,
				-20,
				-48
			},
			new int[]
			{
				0,
				-8,
				-43
			},
			new int[]
			{
				0,
				-7,
				-43
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				1,
				-4,
				-41
			},
			new int[]
			{
				14,
				-9,
				-17
			},
			new int[]
			{
				17,
				-15,
				-34
			},
			new int[]
			{
				21,
				-20,
				-48
			},
			new int[]
			{
				0,
				-8,
				-43
			},
			new int[]
			{
				0,
				-7,
				-43
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				2,
				-7,
				-41
			},
			new int[]
			{
				8,
				-17,
				-18
			},
			new int[]
			{
				18,
				-13,
				-29
			},
			new int[]
			{
				22,
				-26,
				-31
			},
			new int[]
			{
				0,
				-11,
				-43
			},
			new int[]
			{
				0,
				-10,
				-43
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				2,
				-7,
				-41
			},
			new int[]
			{
				14,
				-9,
				-17
			},
			new int[]
			{
				18,
				-13,
				-29
			},
			new int[]
			{
				22,
				-26,
				-31
			},
			new int[]
			{
				0,
				-11,
				-43
			},
			new int[]
			{
				0,
				-10,
				-43
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				2,
				-2,
				-41
			},
			new int[]
			{
				9,
				-19,
				-18
			},
			new int[]
			{
				19,
				-9,
				-29
			},
			new int[]
			{
				23,
				-19,
				-39
			},
			new int[]
			{
				0,
				-6,
				-43
			},
			new int[]
			{
				0,
				-5,
				-43
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				2,
				-2,
				-41
			},
			new int[]
			{
				14,
				-8,
				-17
			},
			new int[]
			{
				19,
				-9,
				-29
			},
			new int[]
			{
				23,
				-19,
				-39
			},
			new int[]
			{
				0,
				-6,
				-43
			},
			new int[]
			{
				0,
				-5,
				-43
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				1,
				-13,
				-39
			},
			new int[]
			{
				1,
				-18,
				-17
			},
			new int[]
			{
				10,
				-5,
				-32
			},
			new int[]
			{
				14,
				3,
				-50
			},
			new int[]
			{
				0,
				-17,
				-41
			},
			new int[]
			{
				0,
				-16,
				-41
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				1,
				-13,
				-40
			},
			new int[]
			{
				2,
				-6,
				-18
			},
			new int[]
			{
				10,
				-5,
				-33
			},
			new int[]
			{
				14,
				3,
				-51
			},
			new int[]
			{
				0,
				-17,
				-42
			},
			new int[]
			{
				0,
				-16,
				-42
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				1,
				-13,
				-42
			},
			new int[]
			{
				3,
				-6,
				-22
			},
			new int[]
			{
				10,
				-5,
				-35
			},
			new int[]
			{
				14,
				3,
				-53
			},
			new int[]
			{
				0,
				-17,
				-44
			},
			new int[]
			{
				0,
				-16,
				-44
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				1,
				-13,
				-40
			},
			new int[]
			{
				4,
				-14,
				-19
			},
			new int[]
			{
				10,
				-5,
				-33
			},
			new int[]
			{
				14,
				3,
				-51
			},
			new int[]
			{
				0,
				-17,
				-42
			},
			new int[]
			{
				0,
				-16,
				-42
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				1,
				-13,
				-41
			},
			new int[]
			{
				5,
				-5,
				-19
			},
			new int[]
			{
				10,
				-5,
				-34
			},
			new int[]
			{
				14,
				3,
				-52
			},
			new int[]
			{
				0,
				-17,
				-43
			},
			new int[]
			{
				0,
				-16,
				-43
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				1,
				-13,
				-44
			},
			new int[]
			{
				6,
				-9,
				-23
			},
			new int[]
			{
				10,
				-5,
				-37
			},
			new int[]
			{
				14,
				3,
				-55
			},
			new int[]
			{
				0,
				-17,
				-46
			},
			new int[]
			{
				0,
				-16,
				-46
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				3,
				-3,
				-41
			},
			new int[]
			{
				8,
				-17,
				-18
			},
			new int[]
			{
				17,
				-14,
				-34
			},
			new int[]
			{
				21,
				-19,
				-48
			},
			new int[]
			{
				0,
				-7,
				-43
			},
			new int[]
			{
				0,
				-6,
				-43
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				3,
				-4,
				-41
			},
			new int[]
			{
				14,
				-9,
				-17
			},
			new int[]
			{
				17,
				-15,
				-34
			},
			new int[]
			{
				21,
				-20,
				-48
			},
			new int[]
			{
				0,
				-8,
				-43
			},
			new int[]
			{
				0,
				-7,
				-43
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				3,
				-4,
				-42
			},
			new int[]
			{
				5,
				-5,
				-19
			},
			new int[]
			{
				17,
				-15,
				-35
			},
			new int[]
			{
				21,
				-20,
				-49
			},
			new int[]
			{
				0,
				-8,
				-44
			},
			new int[]
			{
				0,
				-7,
				-44
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				2,
				-13,
				-39
			},
			new int[]
			{
				1,
				-18,
				-17
			},
			new int[]
			{
				6,
				-19,
				-28
			},
			new int[]
			{
				10,
				-1,
				-31
			},
			new int[]
			{
				0,
				-17,
				-41
			},
			new int[]
			{
				0,
				-16,
				-41
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				4,
				-13,
				-40
			},
			new int[]
			{
				1,
				-18,
				-17
			},
			new int[]
			{
				7,
				-19,
				-29
			},
			new int[]
			{
				11,
				5,
				-17
			},
			new int[]
			{
				1,
				-17,
				-42
			},
			new int[]
			{
				1,
				-16,
				-42
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				2,
				-10,
				-40
			},
			new int[]
			{
				1,
				-18,
				-17
			},
			new int[]
			{
				11,
				-18,
				-29
			},
			new int[]
			{
				15,
				5,
				-17
			},
			new int[]
			{
				0,
				-14,
				-42
			},
			new int[]
			{
				0,
				-13,
				-42
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				0,
				-17,
				-44
			},
			new int[]
			{
				11,
				-23,
				-29
			},
			new int[]
			{
				4,
				-19,
				-35
			},
			new int[]
			{
				5,
				-23,
				-46
			},
			new int[]
			{
				0,
				-21,
				-46
			},
			new int[]
			{
				0,
				-20,
				-46
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				2,
				-15,
				-44
			},
			new int[]
			{
				12,
				-28,
				-25
			},
			new int[]
			{
				4,
				-18,
				-34
			},
			new int[]
			{
				5,
				-22,
				-45
			},
			new int[]
			{
				0,
				-19,
				-46
			},
			new int[]
			{
				0,
				-18,
				-46
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				2,
				-20,
				-43
			},
			new int[]
			{
				12,
				-28,
				-25
			},
			new int[]
			{
				6,
				-26,
				-32
			},
			new int[]
			{
				10,
				-8,
				-35
			},
			new int[]
			{
				0,
				-24,
				-45
			},
			new int[]
			{
				0,
				-23,
				-45
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				4,
				-19,
				-44
			},
			new int[]
			{
				12,
				-28,
				-25
			},
			new int[]
			{
				7,
				-25,
				-33
			},
			new int[]
			{
				11,
				-1,
				-21
			},
			new int[]
			{
				1,
				-23,
				-46
			},
			new int[]
			{
				1,
				-22,
				-46
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				4,
				-19,
				-44
			},
			new int[]
			{
				11,
				-23,
				-29
			},
			new int[]
			{
				7,
				-25,
				-33
			},
			new int[]
			{
				11,
				-1,
				-21
			},
			new int[]
			{
				1,
				-23,
				-46
			},
			new int[]
			{
				1,
				-22,
				-46
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				1,
				-11,
				-40
			},
			new int[]
			{
				14,
				-9,
				-18
			},
			new int[]
			{
				1,
				-11,
				-31
			},
			new int[]
			{
				1,
				-18,
				-42
			},
			new int[]
			{
				0,
				-15,
				-42
			},
			new int[]
			{
				0,
				-14,
				-42
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		},
		new int[][]
		{
			new int[]
			{
				1,
				-8,
				-42
			},
			new int[]
			{
				0,
				-11,
				-18
			},
			new int[]
			{
				5,
				-16,
				-31
			},
			new int[]
			{
				6,
				-23,
				-49
			},
			new int[]
			{
				0,
				-12,
				-44
			},
			new int[]
			{
				0,
				-11,
				-44
			},
			new int[]
			{
				0,
				-29,
				-57
			}
		}
	};

	// Token: 0x04000CD9 RID: 3289
	public int[] feStand = new int[]
	{
		0,
		0,
		0,
		0,
		1,
		1,
		1,
		1,
		1,
		0,
		0,
		0,
		0
	};

	// Token: 0x04000CDA RID: 3290
	public int[] feRun = new int[]
	{
		2,
		2,
		2,
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
		6,
		7,
		7,
		7
	};

	// Token: 0x04000CDB RID: 3291
	public int[] feAva = new int[]
	{
		8,
		8,
		10,
		10,
		10,
		10
	};

	// Token: 0x04000CDC RID: 3292
	public int[][] fetest = new int[][]
	{
		new int[]
		{
			3,
			3,
			3,
			3,
			3,
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
			4,
			4,
			4,
			4,
			4,
			6,
			6,
			6,
			6,
			6,
			6,
			6,
			1,
			1,
			1,
			1,
			0,
			0,
			0,
			0,
			7,
			7,
			7,
			7,
			7,
			7,
			7,
			3,
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
			4,
			6,
			6,
			6,
			6,
			6,
			6,
			6,
			1,
			1,
			1,
			1,
			0,
			0,
			0,
			0
		},
		new int[]
		{
			0,
			0,
			27,
			27,
			27,
			27,
			27,
			27,
			28,
			28,
			28,
			27,
			27,
			27,
			27,
			27,
			27,
			27,
			27,
			27,
			27,
			27,
			27,
			29,
			29,
			29,
			1,
			1,
			1,
			1,
			0,
			0,
			0,
			0,
			1,
			1,
			1,
			1
		},
		new int[]
		{
			0,
			0,
			14,
			14,
			14,
			13,
			13,
			13,
			39,
			39,
			39,
			41,
			41,
			41,
			39,
			39,
			39,
			41,
			41,
			41,
			39,
			39,
			39,
			41,
			41,
			41
		}
	};

	// Token: 0x04000CDD RID: 3293
	public static sbyte[][] fLechWeaponBigBody = new sbyte[][]
	{
		new sbyte[]
		{
			0,
			-3,
			0,
			-3,
			0,
			-5,
			0,
			-5,
			0,
			-5,
			0,
			-5,
			0,
			-5,
			0,
			-5,
			0,
			-5,
			0,
			-5,
			0,
			-5,
			0,
			-5,
			0,
			-5,
			3,
			-6,
			3,
			-6,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			-11,
			0,
			-11,
			-1,
			-9,
			-1,
			-9,
			-2,
			-8,
			-2,
			-8,
			0,
			0,
			0,
			0,
			0,
			-5,
			0,
			-5,
			0,
			-5,
			0,
			-5,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			-2,
			-8,
			-2,
			-8,
			-2,
			-8,
			-2,
			-8,
			-2,
			-8,
			-2,
			-8,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			-5,
			0,
			-5,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			-5,
			0,
			-5
		},
		new sbyte[]
		{
			-1,
			-2,
			-1,
			-2,
			-3,
			-5,
			-2,
			-10,
			-2,
			-5,
			-2,
			-6,
			0,
			-9,
			0,
			-9,
			-6,
			-5,
			-6,
			-5,
			-6,
			-5,
			-5,
			-5,
			-5,
			-5,
			-2,
			-4,
			-2,
			-4,
			-2,
			-7,
			-2,
			-7,
			0,
			0,
			0,
			0,
			0,
			-9,
			0,
			-9,
			0,
			0,
			0,
			0,
			-2,
			-5,
			-2,
			-5,
			-2,
			-7,
			-2,
			-7,
			-2,
			-5,
			-2,
			-5,
			-2,
			-5,
			-2,
			-5,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			-2,
			-5,
			-2,
			-5,
			-2,
			-5,
			-2,
			-5,
			-2,
			-5,
			-2,
			-5,
			0,
			0,
			0,
			0,
			0,
			0,
			-2,
			-7,
			0,
			0,
			-2,
			-7,
			0,
			-9,
			0,
			-9,
			0,
			0,
			0,
			0,
			0,
			0,
			-2,
			-4,
			-5,
			-5
		},
		new sbyte[]
		{
			0,
			-9,
			0,
			-9,
			0,
			-7,
			0,
			-7,
			0,
			-7,
			0,
			-7,
			0,
			-7,
			0,
			-9,
			0,
			-6,
			0,
			-6,
			0,
			-6,
			0,
			-8,
			0,
			-7,
			-5,
			-11,
			-5,
			-11,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			-7,
			0,
			-7,
			0,
			-7,
			0,
			-7,
			0,
			-6,
			0,
			-6,
			0,
			0,
			0,
			0,
			-2,
			-7,
			-2,
			-7,
			-2,
			-7,
			-2,
			-7,
			-3,
			-5,
			-3,
			-5,
			-1,
			-5,
			-1,
			-5,
			-3,
			-6,
			-3,
			-6,
			-3,
			-6,
			-3,
			-6,
			-2,
			-6,
			-2,
			-6,
			0,
			-5,
			0,
			-5,
			0,
			-6,
			0,
			-6,
			0,
			-6,
			0,
			-6,
			0,
			-6,
			0,
			-6,
			-3,
			-6,
			-3,
			-6,
			-3,
			-6,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			-6,
			0,
			-6,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			9,
			0,
			6
		},
		new sbyte[]
		{
			2,
			-6,
			2,
			-6,
			-4,
			-4,
			-4,
			-4,
			-1,
			-5,
			-1,
			-5,
			-4,
			-4,
			-3,
			-6,
			-4,
			-6,
			-4,
			-6,
			-4,
			-6,
			-4,
			-6,
			-4,
			-6,
			-3,
			-6,
			-3,
			-6,
			-4,
			-6,
			-4,
			-6,
			0,
			0,
			0,
			0,
			0,
			-9,
			0,
			-9,
			0,
			0,
			0,
			0,
			4,
			-2,
			4,
			-2,
			0,
			0,
			0,
			0,
			-2,
			-6,
			-2,
			-6,
			-2,
			-6,
			-2,
			-6,
			-2,
			-6,
			-2,
			-6,
			-1,
			-5,
			-1,
			-5,
			-1,
			-6,
			-1,
			-6,
			-2,
			-6,
			-2,
			-6,
			0,
			-5,
			0,
			-5,
			-1,
			-5,
			-1,
			-5,
			4,
			-2,
			4,
			-2,
			4,
			-2,
			4,
			-2,
			4,
			-2,
			4,
			-2,
			-2,
			-6,
			-2,
			-6,
			-2,
			-6,
			-4,
			-6,
			0,
			0,
			0,
			0,
			-3,
			-6,
			-3,
			-6,
			-4,
			-6,
			0,
			0,
			0,
			0,
			-4,
			-4,
			-4,
			-6
		}
	};

	// Token: 0x04000CDE RID: 3294
	public static FrameImage[] mfraImgFullSet = new FrameImage[10];

	// Token: 0x04000CDF RID: 3295
	public int nFrameEffHair;

	// Token: 0x04000CE0 RID: 3296
	public int ntickFrameOneStep;

	// Token: 0x04000CE1 RID: 3297
	public int nFrameEffBody;

	// Token: 0x04000CE2 RID: 3298
	public int indexPlayMBody;

	// Token: 0x04000CE3 RID: 3299
	public int tickPlayframeBody;

	// Token: 0x04000CE4 RID: 3300
	public int nFrameEffHead;

	// Token: 0x04000CE5 RID: 3301
	public int tickPlayframeWeapon;

	// Token: 0x04000CE6 RID: 3302
	public int indexPlayWeapon;

	// Token: 0x04000CE7 RID: 3303
	public int framePlayHead;

	// Token: 0x04000CE8 RID: 3304
	public int nFrameEffLeg;

	// Token: 0x04000CE9 RID: 3305
	public int nFrameEffWeapon;

	// Token: 0x04000CEA RID: 3306
	private FrameImage fraEffBody;

	// Token: 0x04000CEB RID: 3307
	private MainImage imgEffHair;

	// Token: 0x04000CEC RID: 3308
	private MainImage imgEffHead;

	// Token: 0x04000CED RID: 3309
	private MainImage imgEffPlayBody;

	// Token: 0x04000CEE RID: 3310
	private MainImage imgEffPlayLeg;

	// Token: 0x04000CEF RID: 3311
	private MainImage imgEffPlayWeapon;

	// Token: 0x04000CF0 RID: 3312
	private int[][] mPlayframeBody = new int[][]
	{
		new int[]
		{
			0,
			0,
			1,
			1,
			2,
			2,
			0,
			0,
			1,
			1,
			2,
			2,
			1,
			1,
			0,
			0
		},
		new int[]
		{
			0,
			0,
			1,
			1,
			2,
			2,
			1,
			1,
			0,
			0,
			1,
			1,
			2,
			2,
			1,
			1,
			0,
			0
		},
		new int[]
		{
			0,
			0,
			1,
			1,
			2,
			2,
			2,
			2,
			1,
			1,
			1,
			1,
			2,
			2,
			2,
			2,
			1,
			1,
			2,
			2,
			1,
			1,
			2,
			2,
			1,
			1,
			0,
			0,
			0,
			0
		},
		new int[]
		{
			0,
			0,
			1,
			1,
			2,
			2,
			1,
			1,
			0,
			0,
			1,
			1,
			2,
			2,
			1,
			1,
			0,
			0
		},
		new int[]
		{
			0,
			0,
			1,
			1,
			2,
			2,
			1,
			1,
			0,
			0,
			0,
			0
		}
	};

	// Token: 0x04000CF1 RID: 3313
	public short idparP = -1;

	// Token: 0x04000CF2 RID: 3314
	public short FramePP;

	// Token: 0x04000CF3 RID: 3315
	public short fPP;

	// Token: 0x04000CF4 RID: 3316
	public static sbyte[][] AR_FRAME_PP = new sbyte[][]
	{
		new sbyte[0],
		new sbyte[0],
		new sbyte[0]
	};

	// Token: 0x04000CF5 RID: 3317
	private int xEffBody;

	// Token: 0x04000CF6 RID: 3318
	private int yEffBody;

	// Token: 0x04000CF7 RID: 3319
	private int frameEffBody;

	// Token: 0x04000CF8 RID: 3320
	private int typeActionEffBody;

	// Token: 0x04000CF9 RID: 3321
	private int framePlayEB;

	// Token: 0x04000CFA RID: 3322
	public static sbyte EBODY_RANDOM_NORMAL = 0;

	// Token: 0x04000CFB RID: 3323
	public static short[] idEffBody = new short[]
	{
		798,
		799,
		801,
		802
	};

	// Token: 0x04000CFC RID: 3324
	public short idHairbay = -1;

	// Token: 0x04000CFD RID: 3325
	public short idBodybay = -1;

	// Token: 0x04000CFE RID: 3326
	public short idLegBay = -1;

	// Token: 0x04000CFF RID: 3327
	public short idWeaponBay = -1;

	// Token: 0x04000D00 RID: 3328
	public static short[] idPlayFrameHead = new short[]
	{
		815
	};

	// Token: 0x04000D01 RID: 3329
	public int[] mSortPaint = new int[]
	{
		1,
		2,
		0,
		5,
		4,
		3,
		6
	};

	// Token: 0x04000D02 RID: 3330
	public int[] mSortPaintRight = new int[]
	{
		1,
		2,
		3,
		6,
		0,
		5,
		4
	};

	// Token: 0x04000D03 RID: 3331
	public static short[] idWeaponF = new short[]
	{
		803,
		804,
		805,
		806
	};

	// Token: 0x04000D04 RID: 3332
	public static int[] mSortPaintHead = new int[]
	{
		0,
		5,
		4
	};

	// Token: 0x04000D05 RID: 3333
	public static short[] ListLechHEAD = new short[]
	{
		719,
		748,
		751,
		756,
		798,
		799,
		801,
		802,
		849,
		851,
		894,
		896,
		950,
		963,
		972
	};

	// Token: 0x04000D06 RID: 3334
	public static short[] ListKoLechHEAD = new short[]
	{
		893,
		889
	};

	// Token: 0x04000D07 RID: 3335
	private bool isKoLechHead;

	// Token: 0x04000D08 RID: 3336
	private bool isBuffDevil;

	// Token: 0x04000D09 RID: 3337
	public bool isTestchoi;

	// Token: 0x04000D0A RID: 3338
	public int[] mActionShow;

	// Token: 0x04000D0B RID: 3339
	private int demFire;

	// Token: 0x04000D0C RID: 3340
	private int tickfire;

	// Token: 0x04000D0D RID: 3341
	public int endEye;

	// Token: 0x04000D0E RID: 3342
	public int eye = 2;

	// Token: 0x04000D0F RID: 3343
	public int timeEye;

	// Token: 0x04000D10 RID: 3344
	public sbyte stepUpboat;

	// Token: 0x04000D11 RID: 3345
	public sbyte tickTypeActionBoat;

	// Token: 0x04000D12 RID: 3346
	public int speedHpEff;

	// Token: 0x04000D13 RID: 3347
	public int tickHpEff;

	// Token: 0x04000D14 RID: 3348
	public static MyHashTable ALL_DATA_SKILL_EFF = new MyHashTable();
}
