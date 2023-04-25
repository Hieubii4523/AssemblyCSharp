using System;

// Token: 0x0200006D RID: 109
public class LoadMap
{
	// Token: 0x06000691 RID: 1681 RVA: 0x000908A4 File Offset: 0x0008EAA4
	public LoadMap()
	{
		this.maxX = MotherCanvas.w / LoadMap.wTile + 1;
		this.maxY = MotherCanvas.h / LoadMap.wTile + 1;
		for (int i = 0; i < LoadMap.mItemMap.Length; i++)
		{
			LoadMap.mItemMap[i] = new mVector();
		}
	}

	// Token: 0x06000692 RID: 1682 RVA: 0x00090910 File Offset: 0x0008EB10
	public void loadmap(sbyte[] msbyte)
	{
		try
		{
			ByteArrayInputStream bis = new ByteArrayInputStream(msbyte);
			DataInputStream dataInputStream = new DataInputStream(bis);
			this.mapW = (int)dataInputStream.readByte();
			this.mapH = (int)dataInputStream.readByte();
			int num = (int)dataInputStream.readByte();
			bool flag = LoadMap.idTile != num;
			if (flag)
			{
				LoadMap.idTile = num;
				LoadMap.imgTile = null;
				LoadMap.imgTileWater = null;
				this.fWater = (int)LoadMap.mLockMap[LoadMap.idTile * 2];
				this.fStand = (int)LoadMap.mLockMap[LoadMap.idTile * 2 + 1];
				ObjectData.getImageOther((short)LoadMap.idTile, 20);
				bool flag2 = LoadMap.idTile == 11 || LoadMap.idTile == 14;
				if (flag2)
				{
					bool flag3 = LoadMapScreen.isMapSky != 1;
					if (flag3)
					{
						LoadMapScreen.isMapSky = 1;
						LoadImageStatic.loadImageEffBoat();
					}
					LoadMapScreen.isMapSky = 1;
				}
				else
				{
					bool flag4 = LoadMapScreen.isMapSky != 0;
					if (flag4)
					{
						LoadMapScreen.isMapSky = 0;
						LoadImageStatic.loadImageEffBoat();
					}
					LoadMapScreen.isMapSky = 0;
				}
			}
			this.maxWMap = this.mapW * LoadMap.wTile;
			this.maxHMap = this.mapH * LoadMap.wTile;
			this.limitW = this.maxWMap - MotherCanvas.w;
			this.limitH = this.maxHMap - MotherCanvas.h;
			MainScreen.cameraMain.setAll(this.limitW, this.limitH, GameScreen.player.x - MotherCanvas.hw, GameScreen.player.y - MotherCanvas.hh);
			this.mapPaint = new int[this.mapW * this.mapH];
			this.mapType = new int[this.mapW * this.mapH];
			this.mapFind = new sbyte[this.mapW][];
			for (int i = 0; i < this.mapW; i++)
			{
				this.mapFind[i] = new sbyte[this.mapH];
			}
			this.limitMap = this.mapW * this.mapH;
			for (int j = 0; j < this.mapW * this.mapH; j++)
			{
				sbyte b = dataInputStream.readByte();
				this.mapPaint[j] = (int)b;
				bool flag5 = (int)b >= this.fStand || b == 0;
				if (flag5)
				{
					this.mapType[j] = 1;
				}
				else
				{
					bool flag6 = (int)b >= this.fWater;
					if (flag6)
					{
						this.mapType[j] = 2;
					}
					else
					{
						this.mapType[j] = 0;
					}
				}
			}
		}
		catch (Exception)
		{
			mSystem.outloi("loi load map 2");
		}
	}

	// Token: 0x06000693 RID: 1683 RVA: 0x00090BD0 File Offset: 0x0008EDD0
	public void load_ItemMap(sbyte[] msbyte)
	{
		for (int i = 0; i < LoadMap.mItemMap.Length; i++)
		{
			LoadMap.mItemMap[i].removeAllElements();
		}
		try
		{
			ByteArrayInputStream bis = new ByteArrayInputStream(msbyte);
			DataInputStream dataInputStream = new DataInputStream(bis);
			short num = dataInputStream.readShort();
			for (int j = 0; j < (int)num; j++)
			{
				short id = dataInputStream.readShort();
				MainItemMap mainItemMap = this.get_Item(id);
				bool flag = mainItemMap == null;
				if (flag)
				{
					dataInputStream.readShort();
					dataInputStream.readShort();
				}
				else
				{
					short num2 = dataInputStream.readShort();
					short num3 = dataInputStream.readShort();
					bool flag2 = GameCanvas.isLowGraOrWP_PvP() && mainItemMap.layer != 2 && mainItemMap.Block.Length == 0 && mainItemMap.isLoadDataOk;
					if (!flag2)
					{
						ItemMap itemMap = new ItemMap(mainItemMap.IDItem, mainItemMap.IDImage, mainItemMap.dx, mainItemMap.dy, mainItemMap.Block, mainItemMap.layer);
						bool flag3 = mainItemMap.IDImage == 312;
						if (flag3)
						{
							itemMap.typeEff = 0;
							bool flag4 = j % 4 == 0;
							if (flag4)
							{
								itemMap.typeEff = 1;
							}
						}
						this.Block_TileMap_Item((int)num2, (int)num3, mainItemMap.Block);
						itemMap.setInfoItem((int)num2 * LoadMap.wTile, (int)num3 * LoadMap.wTile);
						bool flag5 = mainItemMap.layer == -1;
						if (flag5)
						{
							LoadMap.mItemMapNonData.addElement(itemMap);
						}
						else
						{
							itemMap.getImage();
							bool flag6 = mainItemMap.layer != 6;
							if (flag6)
							{
								LoadMap.mItemMap[(int)mainItemMap.layer].addElement(itemMap);
							}
						}
					}
				}
			}
			bool flag7 = !GameCanvas.isLowGraOrWP_PvP();
			if (flag7)
			{
				short num4 = dataInputStream.readShort();
				bool flag8 = num4 > 0;
				if (flag8)
				{
					for (int k = 0; k < (int)num4; k++)
					{
						int num5 = (int)dataInputStream.readByte();
						string text = string.Empty;
						for (int l = 0; l < num5; l++)
						{
							text += ((char)dataInputStream.readByte()).ToString();
						}
						num5 = (int)dataInputStream.readByte();
						string text2 = string.Empty;
						for (int m = 0; m < num5; m++)
						{
							text2 += ((char)dataInputStream.readByte()).ToString();
						}
						LoadMap.mItemMap[3].addElement(GameScreen.addEffectAuto(text, text2));
					}
				}
			}
			for (int n = 0; n < LoadMap.mItemMap.Length; n++)
			{
				CRes.quickSort(LoadMap.mItemMap[n]);
			}
		}
		catch (Exception)
		{
			mSystem.outloi("loi load map 3");
		}
	}

	// Token: 0x06000694 RID: 1684 RVA: 0x00090ECC File Offset: 0x0008F0CC
	public void paint(mGraphics g)
	{
		int num = MainScreen.cameraMain.xCam / LoadMap.wTile - 1;
		int num2 = MainScreen.cameraMain.yCam / LoadMap.wTile - 1;
		bool flag = num < 0;
		if (flag)
		{
			num = 0;
		}
		bool flag2 = num2 < 0;
		if (flag2)
		{
			num2 = 0;
		}
		int num3 = num + this.maxX + 2;
		int num4 = num2 + this.maxY + 2;
		bool flag3 = num3 > this.mapW;
		if (flag3)
		{
			num3 = this.mapW;
		}
		bool flag4 = num4 > this.mapH;
		if (flag4)
		{
			num4 = this.mapH;
		}
		bool flag5 = (LoadMap.imgTileWater == null || LoadMap.imgTileWater.img == null) && !GameCanvas.lowGraphic;
		if (flag5)
		{
			LoadMap.imgTileWater = ObjectData.getImageOther((short)LoadMap.idTile, 70);
		}
		bool flag6 = LoadMap.imgTile == null || LoadMap.imgTile.img == null;
		if (flag6)
		{
			LoadMap.imgTile = ObjectData.getImageOther((short)LoadMap.idTile, 20);
			g.setColor(15445332);
			g.fillRect(MainScreen.cameraMain.xCam, MainScreen.cameraMain.yCam, MotherCanvas.w, MotherCanvas.h);
		}
		else
		{
			for (int i = num; i < num3; i++)
			{
				for (int j = num2; j < num4; j++)
				{
					int num5 = j * this.mapW + i;
					bool flag7 = num5 >= this.mapPaint.Length;
					if (!flag7)
					{
						int num6 = this.mapPaint[num5] - 1;
						bool flag8 = !GameCanvas.lowGraphic && LoadMap.idTile == 3 && num6 >= 35 && num6 <= 37 && GameCanvas.gameTick % 14 < 7;
						if (flag8)
						{
							int num7 = 0;
							bool flag9 = GameCanvas.gameTick / 14 % 2 == 0;
							if (flag9)
							{
								num7 = 3;
							}
							bool flag10 = LoadMap.imgTileWater != null && LoadMap.imgTileWater.img != null;
							if (flag10)
							{
								g.drawRegion(LoadMap.imgTileWater.img, (num7 + num6 - 35) / 10 * LoadMap.wTile, (num7 + num6 - 35) % 10 * LoadMap.wTile, LoadMap.wTile, LoadMap.wTile, 0, (float)(i * LoadMap.wTile), (float)(j * LoadMap.wTile), 0);
							}
						}
						else
						{
							bool flag11 = !GameCanvas.lowGraphic && num6 >= this.fWater - 1 && num6 < this.fStand - 1 && GameCanvas.gameTick % 14 < 7 && LoadMap.idTile != 3;
							if (flag11)
							{
								int num8 = 0;
								bool flag12 = GameCanvas.gameTick / 14 % 2 == 0;
								if (flag12)
								{
									num8 = this.fStand - this.fWater;
								}
								bool flag13 = LoadMap.imgTileWater != null && LoadMap.imgTileWater.img != null;
								if (flag13)
								{
									g.drawRegion(LoadMap.imgTileWater.img, (num8 + num6 - (this.fWater - 1)) / 10 * LoadMap.wTile, (num8 + num6 - (this.fWater - 1)) % 10 * LoadMap.wTile, LoadMap.wTile, LoadMap.wTile, 0, (float)(i * LoadMap.wTile), (float)(j * LoadMap.wTile), 0);
								}
							}
							else
							{
								bool flag14 = num6 > -1 && LoadMap.imgTile != null && LoadMap.imgTile.img != null;
								if (flag14)
								{
									g.drawRegion(LoadMap.imgTile.img, num6 / 10 * LoadMap.wTile, num6 % 10 * LoadMap.wTile, LoadMap.wTile, LoadMap.wTile, 0, (float)(i * LoadMap.wTile), (float)(j * LoadMap.wTile), 0);
								}
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x06000695 RID: 1685 RVA: 0x000090B5 File Offset: 0x000072B5
	public void update()
	{
	}

	// Token: 0x06000696 RID: 1686 RVA: 0x00091288 File Offset: 0x0008F488
	public int getTile(int xset, int yset)
	{
		int num = yset / LoadMap.wTile * this.mapW + xset / LoadMap.wTile;
		bool flag = num > this.limitMap || xset < 0 || xset >= this.limitW + MotherCanvas.w || yset < 0 || yset >= this.limitH + MotherCanvas.h;
		int result;
		if (flag)
		{
			result = 1;
		}
		else
		{
			result = this.mapType[num];
		}
		return result;
	}

	// Token: 0x06000697 RID: 1687 RVA: 0x000912F8 File Offset: 0x0008F4F8
	public int getIndex(int xset, int yset)
	{
		return yset / LoadMap.wTile * this.mapW + xset / LoadMap.wTile;
	}

	// Token: 0x06000698 RID: 1688 RVA: 0x00091320 File Offset: 0x0008F520
	public MainItemMap get_Item(short id)
	{
		MainItemMap mainItemMap = (MainItemMap)LoadMap.hashMapItem.get(string.Empty + id.ToString());
		bool flag = mainItemMap == null;
		if (flag)
		{
			mainItemMap = new MainItemMap(id);
			mainItemMap.isLoadDataOk = false;
			LoadMap.hashMapItem.put(string.Empty + id.ToString(), mainItemMap);
			GlobalService.gI().GetTemplate(98, id);
			bool flag2 = LoadMap.demSendTem == 0;
			if (flag2)
			{
				LoadMap.demSendTem = 1000;
			}
			LoadMap.demSendTem++;
		}
		return mainItemMap;
	}

	// Token: 0x06000699 RID: 1689 RVA: 0x000913BC File Offset: 0x0008F5BC
	public void Block_TileMap_Item(int indexW, int indexH, int[][] mb)
	{
		try
		{
			for (int i = 0; i < mb.Length; i++)
			{
				bool flag = indexW + mb[i][0] >= 0 && indexW + mb[i][0] < this.mapW && indexH + mb[i][1] >= 0 && indexH + mb[i][1] < this.mapH;
				if (flag)
				{
					this.mapType[(indexH + mb[i][1]) * this.mapW + (indexW + mb[i][0])] = 1;
				}
			}
		}
		catch (Exception)
		{
			mSystem.outloi("loi load map 4");
		}
	}

	// Token: 0x0600069A RID: 1690 RVA: 0x0009145C File Offset: 0x0008F65C
	public static sbyte getAreaPaint()
	{
		return LoadMap.Area + 1;
	}

	// Token: 0x0600069B RID: 1691 RVA: 0x00091478 File Offset: 0x0008F678
	public static bool Tile_Stand(int type)
	{
		return type == -1 || type == 1;
	}

	// Token: 0x0600069C RID: 1692 RVA: 0x000914A0 File Offset: 0x0008F6A0
	public short[] updateFindRoad(int xF, int yF, int xTo, int yTo, int maxSize, MainObject objMain)
	{
		short[] array = this.updateFindRoad(xF, yF, xTo, yTo, maxSize, objMain, 0);
		bool flag = LoadMap.specMap == 4 && (array == null || array.Length > maxSize);
		if (flag)
		{
			array = this.updateFindRoad(xF, yF, xTo, yTo, maxSize, objMain, 1);
		}
		return array;
	}

	// Token: 0x0600069D RID: 1693 RVA: 0x000914F4 File Offset: 0x0008F6F4
	public short[] updateFindRoad(int xF, int yF, int xTo, int yTo, int maxSize, MainObject objMain, int numindex)
	{
		bool flag = MainObject.getDistance(xF * LoadMap.wTile, yF * LoadMap.wTile, xTo * LoadMap.wTile, yTo * LoadMap.wTile) <= LoadMap.wTile;
		short[] result;
		if (flag)
		{
			result = null;
		}
		else
		{
			bool flag2 = xF < 0 || yF < 0 || xF >= LoadMap.wTile * this.mapW || yF >= LoadMap.wTile * this.mapH;
			if (flag2)
			{
				result = null;
			}
			else
			{
				this.xStart = (int)((sbyte)this.cmxMini);
				this.yStart = (int)((sbyte)this.cmyMini);
				xF -= this.xStart;
				yF -= this.yStart;
				xTo -= this.xStart;
				yTo -= this.yStart;
				for (int i = 0; i < GameCanvas.loadmap.mapFind.Length; i++)
				{
					for (int j = 0; j < GameCanvas.loadmap.mapFind[i].Length; j++)
					{
						int num = (this.yStart + j) * GameCanvas.loadmap.mapW + (this.xStart + i);
						bool flag3 = num < GameCanvas.loadmap.mapType.Length - 1;
						if (flag3)
						{
							bool flag4 = objMain.typeActionBoat != 0;
							if (flag4)
							{
								GameCanvas.loadmap.mapFind[i][j] = 0;
							}
							else
							{
								bool flag5 = GameCanvas.loadmap.mapType[num] == 1 || GameCanvas.loadmap.mapType[num] == -1;
								if (flag5)
								{
									GameCanvas.loadmap.mapFind[i][j] = -1;
								}
								else
								{
									GameCanvas.loadmap.mapFind[i][j] = 0;
								}
							}
						}
					}
				}
				bool flag6 = LoadMap.specMap == 4 && numindex == 0;
				if (flag6)
				{
					for (int k = 0; k < GameScreen.vecPlayers.size(); k++)
					{
						MainObject mainObject = (MainObject)GameScreen.vecPlayers.elementAt(k);
						bool flag7 = mainObject != objMain && mainObject.boatSea != null && mainObject.boatSea.ID == mainObject.ID;
						if (flag7)
						{
							mainObject.boatSea.boatSetTouch();
							this.setBlockPlayer(mainObject.boatSea.xset, mainObject.boatSea.yset, mainObject.boatSea.wset, mainObject.boatSea.hset);
						}
					}
				}
				int num2 = xF;
				int num3 = yF;
				short num4 = (short)num2;
				short num5 = (short)num3;
				GameCanvas.loadmap.mapFind[num2][num3] = 1;
				short num6 = 2;
				int num7 = GameCanvas.loadmap.mapFind.Length;
				int num8 = GameCanvas.loadmap.mapFind[0].Length;
				int num9 = 0;
				for (;;)
				{
					num9++;
					bool flag8 = num9 > 1000;
					if (flag8)
					{
						break;
					}
					int num10 = -1;
					int num11 = -1;
					bool flag9 = num2 + 1 < num7 && GameCanvas.loadmap.mapFind[num2 + 1][num3] == 0;
					if (flag9)
					{
						GameCanvas.loadmap.mapFind[num2 + 1][num3] = (sbyte)num6;
						num10 = num2 + 1;
						num11 = num3;
					}
					bool flag10 = num2 - 1 >= 0 && GameCanvas.loadmap.mapFind[num2 - 1][num3] == 0;
					if (flag10)
					{
						GameCanvas.loadmap.mapFind[num2 - 1][num3] = (sbyte)num6;
						bool flag11 = num10 != -1;
						if (flag11)
						{
							bool flag12 = CRes.setDis(num10, num11, xTo, yTo) > CRes.setDis(num2 - 1, num3, xTo, yTo);
							if (flag12)
							{
								num10 = num2 - 1;
								num11 = num3;
							}
						}
						else
						{
							num10 = num2 - 1;
							num11 = num3;
						}
					}
					bool flag13 = num3 + 1 < num8 && GameCanvas.loadmap.mapFind[num2][num3 + 1] == 0;
					if (flag13)
					{
						GameCanvas.loadmap.mapFind[num2][num3 + 1] = (sbyte)num6;
						bool flag14 = num10 != -1;
						if (flag14)
						{
							bool flag15 = CRes.setDis(num10, num11, xTo, yTo) > CRes.setDis(num2, num3 + 1, xTo, yTo);
							if (flag15)
							{
								num10 = num2;
								num11 = num3 + 1;
							}
						}
						else
						{
							num10 = num2;
							num11 = num3 + 1;
						}
					}
					bool flag16 = num3 - 1 >= 0 && GameCanvas.loadmap.mapFind[num2][num3 - 1] == 0;
					if (flag16)
					{
						GameCanvas.loadmap.mapFind[num2][num3 - 1] = (sbyte)num6;
						bool flag17 = num10 != -1;
						if (flag17)
						{
							bool flag18 = CRes.setDis(num10, num11, xTo, yTo) > CRes.setDis(num2, num3 - 1, xTo, yTo);
							if (flag18)
							{
								num10 = num2;
								num11 = num3 - 1;
							}
						}
						else
						{
							num10 = num2;
							num11 = num3 - 1;
						}
					}
					int num12 = -1;
					bool flag19 = num10 != -1;
					if (flag19)
					{
						num12 = 0;
						num2 = num10;
						num3 = num11;
					}
					else
					{
						num3 = (num2 = 1000);
					}
					short num13 = 0;
					while ((int)num13 < num7)
					{
						short num14 = 0;
						while ((int)num14 < num8)
						{
							bool flag20 = GameCanvas.loadmap.mapFind[(int)num13][(int)num14] > 1 && this.setContinue((int)num13, (int)num14, GameCanvas.loadmap.mapFind) && (int)GameCanvas.loadmap.mapFind[(int)num13][(int)num14] + CRes.setDis((int)num13, (int)num14, xTo, yTo) < (int)num6 + CRes.setDis(num2, num3, xTo, yTo);
							if (flag20)
							{
								num2 = (int)num13;
								num3 = (int)num14;
								num6 = (short)GameCanvas.loadmap.mapFind[(int)num13][(int)num14];
								num12 = 0;
							}
							num14 += 1;
						}
						num13 += 1;
					}
					bool flag21 = num2 == xTo && num3 == yTo;
					if (flag21)
					{
						goto Block_39;
					}
					bool flag22 = num12 == 0;
					if (!flag22)
					{
						goto IL_5CE;
					}
					num6 += 1;
					bool flag23 = (int)num6 > maxSize;
					if (flag23)
					{
						goto Block_41;
					}
				}
				return new short[maxSize + 1];
				Block_39:
				bool flag24 = num6 >= 127;
				if (flag24)
				{
					return new short[maxSize + 1];
				}
				int num15 = 0;
				short[] array = new short[(int)num6];
				try
				{
					for (;;)
					{
						array[num15] = (short)((num2 << 8) + num3);
						bool flag25 = num2 + 1 < num7 && GameCanvas.loadmap.mapFind[num2 + 1][num3] == GameCanvas.loadmap.mapFind[num2][num3] - 1;
						if (flag25)
						{
							num2 = (int)((short)(num2 + 1));
						}
						else
						{
							bool flag26 = num2 - 1 >= 0 && GameCanvas.loadmap.mapFind[num2 - 1][num3] == GameCanvas.loadmap.mapFind[num2][num3] - 1;
							if (flag26)
							{
								num2 = (int)((short)(num2 - 1));
							}
							else
							{
								bool flag27 = num3 + 1 < num8 && GameCanvas.loadmap.mapFind[num2][num3 + 1] == GameCanvas.loadmap.mapFind[num2][num3] - 1;
								if (flag27)
								{
									num3 = (int)((short)(num3 + 1));
								}
								else
								{
									bool flag28 = num3 - 1 >= 0 && GameCanvas.loadmap.mapFind[num2][num3 - 1] == GameCanvas.loadmap.mapFind[num2][num3] - 1;
									if (flag28)
									{
										num3 = (int)((short)(num3 - 1));
									}
								}
							}
						}
						bool flag29 = num2 == (int)num4 && num3 == (int)num5;
						if (flag29)
						{
							break;
						}
						num15++;
					}
					array[(int)(num6 - 1)] = (short)((xF << 8) + yF);
					result = array;
				}
				catch (Exception)
				{
					result = new short[maxSize + 1];
				}
				return result;
				Block_41:
				return new short[(int)num6];
				IL_5CE:
				result = new short[maxSize + 1];
			}
		}
		return result;
	}

	// Token: 0x0600069E RID: 1694 RVA: 0x00091C74 File Offset: 0x0008FE74
	private bool setContinue(int i, int j, sbyte[][] mapFind)
	{
		bool flag = i + 1 < mapFind.Length && mapFind[i + 1][j] == 0;
		bool result;
		if (flag)
		{
			result = true;
		}
		else
		{
			bool flag2 = i - 1 >= 0 && mapFind[i - 1][j] == 0;
			if (flag2)
			{
				result = true;
			}
			else
			{
				bool flag3 = j + 1 < mapFind[i].Length && mapFind[i][j + 1] == 0;
				if (flag3)
				{
					result = true;
				}
				else
				{
					bool flag4 = j - 1 >= 0 && mapFind[i][j - 1] == 0;
					result = flag4;
				}
			}
		}
		return result;
	}

	// Token: 0x0600069F RID: 1695 RVA: 0x00091D00 File Offset: 0x0008FF00
	public void setBlockNPC(int x, int y, int w, int h)
	{
		for (int i = 0; i < w / 24; i++)
		{
			for (int j = 0; j < h / 24; j++)
			{
				int num = x - w / 2 + i * 24 + 13;
				int num2 = y - h / 2 + j * 24 + 13;
				bool flag = num >= 0 && num < this.maxWMap && num2 >= 0 && num2 < this.maxHMap;
				if (flag)
				{
					this.mapType[num2 / 24 * this.mapW + num / 24] = 1;
				}
			}
		}
	}

	// Token: 0x060006A0 RID: 1696 RVA: 0x00091D9C File Offset: 0x0008FF9C
	public void setBlockPlayer(int x, int y, int w, int h)
	{
		for (int i = 0; i <= w; i = i)
		{
			for (int j = 0; j <= h; j = j)
			{
				int num = x - w / 2 + i;
				int num2 = y - h / 2 + j;
				bool flag = j == h || j + 24 <= h;
				if (flag)
				{
					j += 24;
				}
				else
				{
					bool flag2 = j + 24 > h;
					if (flag2)
					{
						j = h;
					}
				}
				bool flag3 = num >= 0 && num < this.maxWMap && num2 >= 0 && num2 < this.maxHMap;
				if (flag3)
				{
					this.mapFind[num / 24][num2 / 24] = -1;
				}
			}
			bool flag4 = i == w || i + 24 <= w;
			if (flag4)
			{
				i += 24;
			}
			else
			{
				bool flag5 = i + 24 > w;
				if (flag5)
				{
					i = w;
				}
			}
		}
	}

	// Token: 0x060006A1 RID: 1697 RVA: 0x00091E90 File Offset: 0x00090090
	public bool mapLang()
	{
		for (int i = 0; i < LoadMap.mMapLang.Length; i++)
		{
			bool flag = this.idMap == (int)LoadMap.mMapLang[i];
			if (flag)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060006A2 RID: 1698 RVA: 0x00091ED4 File Offset: 0x000900D4
	public static void LoadNameMap(DataInputStream iss, bool isSave)
	{
		bool flag = iss == null;
		if (flag)
		{
			GlobalService.gI().get_DATA(6);
		}
		else
		{
			try
			{
				short num = iss.readShort();
				LoadMap.mNameMap = new string[(int)num];
				for (int i = 0; i < (int)num; i++)
				{
					LoadMap.mNameMap[i] = iss.readUTF();
				}
				if (isSave)
				{
					GlobalService.VerNameMap = iss.readShort();
					SaveRms.saveVer(GlobalService.VerNameMap, "VerdataNameMap");
				}
				iss.close();
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x060006A3 RID: 1699 RVA: 0x00091F70 File Offset: 0x00090170
	public static string getNameMap(int index)
	{
		bool flag = index >= LoadMap.mNameMap.Length;
		string result;
		if (flag)
		{
			result = string.Empty;
		}
		else
		{
			result = LoadMap.mNameMap[index];
		}
		return result;
	}

	// Token: 0x060006A4 RID: 1700 RVA: 0x00091FA4 File Offset: 0x000901A4
	public static void load_Table_Map(DataInputStream iss, bool isSave)
	{
		try
		{
			short num = iss.readShort();
			for (short num2 = 0; num2 < num; num2 += 1)
			{
				short idimage = iss.readShort();
				sbyte layer = iss.readByte();
				short dx = iss.readShort();
				short dy = iss.readShort();
				sbyte b = iss.readByte();
				int[][] array = new int[(int)b][];
				for (int i = 0; i < (int)b; i++)
				{
					array[i] = new int[2];
					array[i][0] = (int)iss.readByte();
					array[i][1] = (int)iss.readByte();
				}
				LoadMap.hashMapItem.put(string.Empty + num2.ToString(), new MainItemMap(num2, idimage, (int)dx, (int)dy, array, layer));
			}
			if (isSave)
			{
				GlobalService.VerItemMap = iss.readShort();
				SaveRms.saveVer(GlobalService.VerItemMap, "VerdataItemMap");
			}
			iss.close();
		}
		catch (Exception)
		{
			mSystem.outloi("loi load map 1");
		}
	}

	// Token: 0x060006A5 RID: 1701 RVA: 0x000920BC File Offset: 0x000902BC
	public void load_Table_Map(DataInputStream iss)
	{
		try
		{
			short iditem = iss.readShort();
			short idimage = iss.readShort();
			sbyte layer = iss.readByte();
			short dx = iss.readShort();
			short dy = iss.readShort();
			sbyte b = iss.readByte();
			int[][] array = new int[(int)b][];
			for (int i = 0; i < (int)b; i++)
			{
				array[i] = new int[2];
				array[i][0] = (int)iss.readByte();
				array[i][1] = (int)iss.readByte();
			}
			LoadMap.hashMapItem.put(string.Empty + iditem.ToString(), new MainItemMap(iditem, idimage, (int)dx, (int)dy, array, layer));
			iss.close();
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x060006A6 RID: 1702 RVA: 0x00092188 File Offset: 0x00090388
	public void checkSetItemMap()
	{
		for (int i = 0; i < LoadMap.mItemMapNonData.size(); i++)
		{
			ItemMap itemMap = (ItemMap)LoadMap.mItemMapNonData.elementAt(i);
			MainItemMap mainItemMap = this.get_Item(itemMap.IDItem);
			bool flag = !mainItemMap.isLoadDataOk;
			if (!flag)
			{
				bool flag2 = !GameCanvas.isLowGraOrWP_PvP() || mainItemMap.layer == 2 || mainItemMap.Block.Length != 0;
				if (flag2)
				{
					ItemMap itemMap2 = new ItemMap(itemMap.IDItem, mainItemMap.IDImage, mainItemMap.dx, mainItemMap.dy, mainItemMap.Block, mainItemMap.layer);
					this.Block_TileMap_Item(itemMap.x / 24, itemMap.y / 24, mainItemMap.Block);
					itemMap2.setInfoItem(itemMap.x, itemMap.y);
					itemMap2.getImage();
					bool flag3 = mainItemMap.IDImage == 312;
					if (flag3)
					{
						itemMap2.typeEff = 0;
						bool flag4 = i % 4 == 0;
						if (flag4)
						{
							itemMap2.typeEff = 1;
						}
					}
					bool flag5 = itemMap2.layer != 6;
					if (flag5)
					{
						LoadMap.mItemMap[(int)itemMap2.layer].addElement(itemMap2);
					}
				}
				LoadMap.mItemMapNonData.removeElementAt(i);
				i--;
			}
		}
	}

	// Token: 0x060006A7 RID: 1703 RVA: 0x000922E8 File Offset: 0x000904E8
	public static sbyte getShowArea(sbyte area)
	{
		return area + 1;
	}

	// Token: 0x04000969 RID: 2409
	public const int T_MAP_NULL = -1;

	// Token: 0x0400096A RID: 2410
	public const int T_MAP_NORMAL = 0;

	// Token: 0x0400096B RID: 2411
	public const int T_MAP_STAND = 1;

	// Token: 0x0400096C RID: 2412
	public const int T_MAP_SLOW = 2;

	// Token: 0x0400096D RID: 2413
	public const int MAP_NORMAL = 0;

	// Token: 0x0400096E RID: 2414
	public const int MAP_THACH_DAU = 1;

	// Token: 0x0400096F RID: 2415
	public const int MAP_PHO_BANG = 2;

	// Token: 0x04000970 RID: 2416
	public const int MAP_TRAIN = 3;

	// Token: 0x04000971 RID: 2417
	public const int MAP_SEA = 4;

	// Token: 0x04000972 RID: 2418
	public const int MAP_RED_LINE = 5;

	// Token: 0x04000973 RID: 2419
	public const int MAP_PHO_BANG_VUON_CAM = 6;

	// Token: 0x04000974 RID: 2420
	public const int MAP_PHO_BANG_LITTLE_GARDEN = 7;

	// Token: 0x04000975 RID: 2421
	public const int MAP_GOTO_SKY = 8;

	// Token: 0x04000976 RID: 2422
	public const int MAP_SAN_BOSS = 9;

	// Token: 0x04000977 RID: 2423
	public const int MAP_LOL = 10;

	// Token: 0x04000978 RID: 2424
	public const int MAP_CHIEM_DAO = 11;

	// Token: 0x04000979 RID: 2425
	public const int MAP_GOTO_GOD = 12;

	// Token: 0x0400097A RID: 2426
	public const int IDMAP_PVP = 995;

	// Token: 0x0400097B RID: 2427
	public const int IDMAP_ROOM_PVP_CLAN = 997;

	// Token: 0x0400097C RID: 2428
	public const int IDMAP_PVP_CLAN = 996;

	// Token: 0x0400097D RID: 2429
	public const int IDMAP_FIGHT_CLAN_ROOM_TRONG = 986;

	// Token: 0x0400097E RID: 2430
	public const int IDMAP_FIGHT_CLAN_ROOM_NGOAI = 987;

	// Token: 0x0400097F RID: 2431
	public const int IDMAP_FIGHT_CLAN_MAP_FIGHT = 985;

	// Token: 0x04000980 RID: 2432
	public const int IDMAP_CHO_CHIEM_DAO_1 = 158;

	// Token: 0x04000981 RID: 2433
	public const int IDMAP_CHO_CHIEM_DAO_2 = 160;

	// Token: 0x04000982 RID: 2434
	public const int IDMAP_CHO_CHIEM_DAO_3 = 162;

	// Token: 0x04000983 RID: 2435
	public const int IDMAP_DAU_CHIEM_DAO_1 = 157;

	// Token: 0x04000984 RID: 2436
	public const int IDMAP_DAU_CHIEM_DAO_2 = 159;

	// Token: 0x04000985 RID: 2437
	public const int IDMAP_DAU_CHIEM_DAO_3 = 161;

	// Token: 0x04000986 RID: 2438
	public static mVector vecPointChange = new mVector("Loadmap.vecPointChange");

	// Token: 0x04000987 RID: 2439
	public static MyHashTable hashMapItem = new MyHashTable();

	// Token: 0x04000988 RID: 2440
	public static mVector[] mItemMap = new mVector[6];

	// Token: 0x04000989 RID: 2441
	public static mVector mItemMapNonData = new mVector();

	// Token: 0x0400098A RID: 2442
	public static sbyte[] mLockMap;

	// Token: 0x0400098B RID: 2443
	public static short[] mMapLang;

	// Token: 0x0400098C RID: 2444
	public static short[][] mSea;

	// Token: 0x0400098D RID: 2445
	public static int[] mTranPointChangeMap = new int[]
	{
		5,
		4,
		1,
		0
	};

	// Token: 0x0400098E RID: 2446
	public int idMap;

	// Token: 0x0400098F RID: 2447
	public int idMapMini;

	// Token: 0x04000990 RID: 2448
	public int mapW;

	// Token: 0x04000991 RID: 2449
	public int mapH;

	// Token: 0x04000992 RID: 2450
	public int limitW;

	// Token: 0x04000993 RID: 2451
	public int limitH;

	// Token: 0x04000994 RID: 2452
	public int limitMap;

	// Token: 0x04000995 RID: 2453
	public int maxX;

	// Token: 0x04000996 RID: 2454
	public int maxY;

	// Token: 0x04000997 RID: 2455
	public int maxWMap;

	// Token: 0x04000998 RID: 2456
	public int maxHMap;

	// Token: 0x04000999 RID: 2457
	public int idLastMap;

	// Token: 0x0400099A RID: 2458
	public static int idTile = -1;

	// Token: 0x0400099B RID: 2459
	public string nameMap = string.Empty;

	// Token: 0x0400099C RID: 2460
	public static int wTile = 24;

	// Token: 0x0400099D RID: 2461
	public int[] mapPaint;

	// Token: 0x0400099E RID: 2462
	public int[] mapType;

	// Token: 0x0400099F RID: 2463
	public static int[] mStatusArea;

	// Token: 0x040009A0 RID: 2464
	public sbyte[][] mapFind;

	// Token: 0x040009A1 RID: 2465
	public static MainImage imgTile;

	// Token: 0x040009A2 RID: 2466
	public static MainImage imgTileWater;

	// Token: 0x040009A3 RID: 2467
	public static mImage imgTileSmall;

	// Token: 0x040009A4 RID: 2468
	public static int timeVibrateScreen = 0;

	// Token: 0x040009A5 RID: 2469
	public static int currentXp = 0;

	// Token: 0x040009A6 RID: 2470
	public static int maxXp = 0;

	// Token: 0x040009A7 RID: 2471
	public static sbyte Area = 0;

	// Token: 0x040009A8 RID: 2472
	public static sbyte MaxArea = 10;

	// Token: 0x040009A9 RID: 2473
	public static sbyte specMap = 0;

	// Token: 0x040009AA RID: 2474
	public static sbyte numPlayerMap;

	// Token: 0x040009AB RID: 2475
	public static sbyte maxnumPlayerMap;

	// Token: 0x040009AC RID: 2476
	public static string[] mNameMap = new string[]
	{
		"aa",
		"bb",
		"cc",
		"dd",
		"ee",
		"ff"
	};

	// Token: 0x040009AD RID: 2477
	public static string[] mStrNameMapNPC;

	// Token: 0x040009AE RID: 2478
	public static bool isOnlineMap = true;

	// Token: 0x040009AF RID: 2479
	private int fStand;

	// Token: 0x040009B0 RID: 2480
	private int fWater;

	// Token: 0x040009B1 RID: 2481
	public static int demSendTem = 0;

	// Token: 0x040009B2 RID: 2482
	private int xStart;

	// Token: 0x040009B3 RID: 2483
	private int yStart;

	// Token: 0x040009B4 RID: 2484
	private int cmxMini;

	// Token: 0x040009B5 RID: 2485
	private int cmyMini;
}
