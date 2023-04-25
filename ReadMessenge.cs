using System;
using System.Collections;

// Token: 0x020000DA RID: 218
public class ReadMessenge : AvMain
{
	// Token: 0x06000C59 RID: 3161 RVA: 0x000EC348 File Offset: 0x000EA548
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
			GlobalService.gI().Choice_Dialog_server(ReadMessenge.IdDialog, (sbyte)subIndex);
			GameCanvas.end_Dialog();
			break;
		case 1:
		{
			bool flag = subIndex != 0;
			if (flag)
			{
				GlobalService.gI().Upgrade_Item(2, ReadMessenge.idItemUpgrade, (sbyte)subIndex);
			}
			GameCanvas.end_Dialog();
			break;
		}
		case 3:
		{
			MainObject.StepHelp++;
			bool flag2 = MainObject.StepHelp >= MainObject.strHelp.Length - 1;
			if (flag2)
			{
				GameCanvas.menu.startAt_NPC(null, MainObject.strHelp[MainObject.strHelp.Length - 1], subIndex, 2, true, 2, false);
			}
			else
			{
				mVector mVector = new mVector();
				iCommand o = new iCommand(T.next, 3, subIndex, this);
				mVector.addElement(o);
				GameCanvas.menu.startAt_NPC(mVector, MainObject.strHelp[MainObject.StepHelp], subIndex, 2, true, 2, false);
			}
			break;
		}
		case 4:
			GlobalService.gI().ChuyenHoa(3, ReadMessenge.idLvthap, ReadMessenge.idLvCao);
			GameCanvas.end_Dialog();
			break;
		case 5:
			switch (subIndex)
			{
			case 0:
				GameScreen.isPaintInterface = !GameScreen.isPaintInterface;
				break;
			case 1:
				GameScreen.isShowChat = !GameScreen.isShowChat;
				break;
			case 2:
				GameScreen.isShowName = !GameScreen.isShowName;
				break;
			case 3:
				GameScreen.isOffAll = !GameScreen.isOffAll;
				break;
			case 4:
				GameScreen.isShowIndex = !GameScreen.isShowIndex;
				break;
			case 5:
				GameScreen.isShowText = !GameScreen.isShowText;
				break;
			case 6:
				GameScreen.isIP_Local = !GameScreen.isIP_Local;
				break;
			case 7:
				GameScreen.isShowTextTab = !GameScreen.isShowTextTab;
				break;
			}
			break;
		case 6:
		{
			sbyte indexMarket = -1;
			bool flag3 = GameCanvas.currentScreen == GameCanvas.tabMarketScr;
			if (flag3)
			{
				indexMarket = (sbyte)GameCanvas.tabMarketScr.idSelect;
			}
			GlobalService.gI().Market(1, indexMarket, (short)subIndex, 0, 1);
			break;
		}
		case 7:
		{
			mVector mVector2 = new mVector();
			for (int i = 0; i < 5; i++)
			{
				iCommand o2 = new iCommand(T.mClazz[i + 1], 8, i, this);
				mVector2.addElement(o2);
			}
			GameCanvas.menu.startAt(mVector2, 2, "Select Class");
			break;
		}
		case 8:
			this.setEffSkill15(subIndex);
			break;
		case 9:
		{
			mVector mVector3 = new mVector();
			for (int j = 0; j < 5; j++)
			{
				iCommand o3 = new iCommand(T.mClazz[j + 1], 10, j, this);
				mVector3.addElement(o3);
			}
			GameCanvas.menu.startAt(mVector3, 2, "Select Class");
			break;
		}
		case 10:
			this.setEffSkill20(subIndex);
			break;
		case 11:
			GlobalService.gI().Clan_Fight(5, (short)subIndex, 0);
			break;
		case 12:
		{
			bool flag4 = subIndex != 0;
			if (flag4)
			{
				GlobalService.gI().Upgrade_Super_Item(2, ReadMessenge.idItemUpgrade, (sbyte)subIndex, 0);
			}
			GameCanvas.end_Dialog();
			break;
		}
		case 13:
			GlobalService.gI().Upgrade_Super_Item(2, ReadMessenge.idItemUpgrade, 0, 0);
			GameCanvas.end_Dialog();
			break;
		case 14:
		{
			mVector mVector4 = new mVector();
			for (int k = 0; k < 5; k++)
			{
				iCommand o4 = new iCommand(T.mClazz[k + 1], 16, k, this);
				mVector4.addElement(o4);
			}
			GameCanvas.menu.startAt(mVector4, 2, "Select Class");
			break;
		}
		case 15:
		{
			mVector mVector5 = new mVector();
			for (int l = 0; l < 5; l++)
			{
				iCommand o5 = new iCommand(T.mClazz[l + 1], 17, l, this);
				mVector5.addElement(o5);
			}
			GameCanvas.menu.startAt(mVector5, 2, "Select Class");
			break;
		}
		case 16:
			this.setEffSkill5(subIndex);
			break;
		case 17:
			this.setEffSkill10(subIndex);
			break;
		case 18:
			GlobalService.gI().Upgrade_Dial(2, ReadMessenge.idItemUpgrade, 0, 0);
			GameCanvas.end_Dialog();
			break;
		}
	}

	// Token: 0x06000C5A RID: 3162 RVA: 0x000EC790 File Offset: 0x000EA990
	private void setEffSkill5(int subIndex)
	{
		for (int i = 0; i < Player.vecListSkill.size(); i++)
		{
			Skill_Info skill_Info = (Skill_Info)Player.vecListSkill.elementAt(i);
			skill_Info.typeEffSkill = this.hardcodeSkill5[subIndex][i];
			bool flag = i == 2;
			if (flag)
			{
				break;
			}
		}
	}

	// Token: 0x06000C5B RID: 3163 RVA: 0x000EC7E8 File Offset: 0x000EA9E8
	private void setEffSkill10(int subIndex)
	{
		for (int i = 0; i < Player.vecListSkill.size(); i++)
		{
			Skill_Info skill_Info = (Skill_Info)Player.vecListSkill.elementAt(i);
			skill_Info.typeEffSkill = this.hardcodeSkill10[subIndex][i];
			bool flag = i == 2;
			if (flag)
			{
				break;
			}
		}
	}

	// Token: 0x06000C5C RID: 3164 RVA: 0x000EC840 File Offset: 0x000EAA40
	private void setEffSkill15(int subIndex)
	{
		for (int i = 0; i < Player.vecListSkill.size(); i++)
		{
			Skill_Info skill_Info = (Skill_Info)Player.vecListSkill.elementAt(i);
			skill_Info.typeEffSkill = this.hardcodeSkill15[subIndex][i];
			bool flag = i == 2;
			if (flag)
			{
				break;
			}
		}
	}

	// Token: 0x06000C5D RID: 3165 RVA: 0x000EC898 File Offset: 0x000EAA98
	private void setEffSkill20(int subIndex)
	{
		for (int i = 0; i < Player.vecListSkill.size(); i++)
		{
			Skill_Info skill_Info = (Skill_Info)Player.vecListSkill.elementAt(i);
			skill_Info.typeEffSkill = this.hardcodeSkill20[subIndex][i];
			bool flag = i == 2;
			if (flag)
			{
				break;
			}
		}
	}

	// Token: 0x06000C5E RID: 3166 RVA: 0x000EC8F0 File Offset: 0x000EAAF0
	public void ListChar(Message msg)
	{
		try
		{
			GameCanvas.saveRms.saveUserPass(GameCanvas.loginScr.tfUser.getText(), GameCanvas.loginScr.tfPass.getText());
			ListChar_Screen.vecListChar.removeAllElements();
			sbyte b = msg.reader().readByte();
			for (int i = 0; i < (int)b; i++)
			{
				short id = msg.reader().readShort();
				string name = msg.reader().readUTF();
				Other_Player other_Player = new Other_Player(id, 0, name, 0, 0);
				other_Player.clazz = msg.reader().readByte();
				other_Player.Lv = (int)msg.reader().readShort();
				other_Player.sethead(msg.reader().readShort());
				other_Player.sethair(msg.reader().readShort());
				short num = msg.reader().readShort();
				bool flag = num >= 0;
				if (flag)
				{
					other_Player.clan = new MainClan();
					other_Player.clan.idIcon = num;
					other_Player.clan.chucvu = 10;
				}
				sbyte b2 = msg.reader().readByte();
				short[] array = new short[(int)b2];
				for (int j = 0; j < array.Length; j++)
				{
					array[j] = -1;
				}
				for (int k = 0; k < (int)b2; k++)
				{
					sbyte b3 = msg.reader().readByte();
					bool flag2 = b3 == 1;
					if (flag2)
					{
						array[k] = msg.reader().readShort();
					}
				}
				other_Player.setWearing(array);
				other_Player.typeSpecCharList = msg.reader().readByte();
				bool flag3 = other_Player.typeSpecCharList != 0;
				if (flag3)
				{
					other_Player.timeDie = (long)msg.reader().readInt();
				}
				ListChar_Screen.vecListChar.addElement(other_Player);
			}
			bool flag4 = b == 0;
			if (flag4)
			{
				CreateChar_Screen.gI().Show(GameCanvas.loginScr);
			}
			else
			{
				ListChar_Screen.gI().Show();
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C5F RID: 3167 RVA: 0x000ECB24 File Offset: 0x000EAD24
	public void ChangeMap(Message msg)
	{
		try
		{
			ReadMessenge.actionChangeMap = 0;
			GameCanvas.loadmap.idLastMap = GameCanvas.loadmap.idMap;
			short num = msg.reader().readShort();
			bool flag = this.setMapSea((int)num);
			if (flag)
			{
				this.idMapLuu = num;
				this.msgLuu = msg;
				ReadMessenge.isNondata = false;
			}
			else
			{
				this.readChangeMapNew(msg, num);
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C60 RID: 3168 RVA: 0x000ECBA0 File Offset: 0x000EADA0
	private bool setMapSea(int id)
	{
		bool flag = LoadMap.mSea != null;
		if (flag)
		{
			for (int i = 0; i < LoadMap.mSea.Length; i++)
			{
				bool flag2 = (int)LoadMap.mSea[i][1] == id && (int)LoadMap.mSea[i][0] == GameCanvas.loadmap.idLastMap;
				if (flag2)
				{
					GameScreen.player.setActionSea((sbyte)(LoadMap.mSea[i][2] - 1), (int)LoadMap.mSea[i][3], (int)LoadMap.mSea[i][4]);
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06000C61 RID: 3169 RVA: 0x000ECC34 File Offset: 0x000EAE34
	public void readChangeMapNew(Message msg, short idmap)
	{
		try
		{
			GameCanvas.loadMapScr.Show();
			GameScreen.RemoveLoadMap();
			DataMap dataMap = new DataMap();
			GameCanvas.loadmap.idMap = (int)idmap;
			Interface_Game.nameMap = string.Empty;
			GameCanvas.loadMapScr.area = msg.reader().readByte();
			sbyte typeViewPlayer = msg.reader().readByte();
			GameScreen.player.posTransRoad = null;
			GameScreen.player.x = (int)msg.reader().readShort();
			GameScreen.player.y = (int)msg.reader().readShort();
			GameScreen.player.toX = GameScreen.player.x;
			GameScreen.player.toY = GameScreen.player.y;
			GameScreen.player.maxHp = msg.reader().readInt();
			GameScreen.player.Hp = msg.reader().readInt();
			GameScreen.player.maxMp = msg.reader().readInt();
			GameScreen.player.Mp = msg.reader().readInt();
			sbyte b = msg.reader().readByte();
			bool flag = LoadMap.specMap == 3;
			if (flag)
			{
				GameScreen.player.isBeginTrain = false;
			}
			else
			{
				bool flag2 = LoadMap.specMap == 4;
				if (flag2)
				{
					GameCanvas.saveRms.loadHotKey(SaveRms.datahotKeySkill);
				}
			}
			LoadMap.specMap = msg.reader().readByte();
			bool flag3 = LoadMap.specMap == 1 && this.check_IDMap_PVP();
			if (flag3)
			{
				GameScreen.tickPvP = 60;
			}
			bool flag4 = b == 1;
			if (flag4)
			{
				LoadMap.isOnlineMap = true;
				int num = msg.reader().readInt();
				sbyte[] array = null;
				bool flag5 = num > 0;
				if (flag5)
				{
					array = new sbyte[num];
					msg.reader().read(ref array);
				}
				dataMap.setDataMap(array);
				GameCanvas.loadmap.loadmap(array);
				int num2 = msg.reader().readInt();
				sbyte[] array2 = null;
				bool flag6 = num2 > 0;
				if (flag6)
				{
					array2 = new sbyte[num2];
					msg.reader().read(ref array2);
				}
				dataMap.setDataItemMap(array2);
				GameCanvas.loadMapScr.mItemMap = array2;
				LoadMap.vecPointChange.removeAllElements();
				sbyte b2 = msg.reader().readByte();
				dataMap.vecPointMap.removeAllElements();
				int i = 0;
				while (i < (int)b2)
				{
					Point point = new Point();
					point.name = msg.reader().readUTF();
					point.x = (int)msg.reader().readShort();
					point.y = (int)msg.reader().readShort();
					dataMap.vecPointMap.addElement(point);
					int num3 = 115;
					bool flag7 = (GameCanvas.loadmap.idMap == 158 || GameCanvas.loadmap.idMap == 160 || GameCanvas.loadmap.idMap == 162 || GameCanvas.loadmap.idMap == 164 || GameCanvas.loadmap.idMap == 166) && point.y < GameCanvas.loadmap.mapH * LoadMap.wTile - num3;
					if (flag7)
					{
						point.y -= 10;
						point.dis = 2;
						point.f = 2;
						point.x2 = point.x;
						point.y2 = point.y + 10;
						point.vy = -1;
						goto IL_57E;
					}
					bool flag8 = GameCanvas.loadmap.idMap == 157 || GameCanvas.loadmap.idMap == 159 || GameCanvas.loadmap.idMap == 161 || GameCanvas.loadmap.idMap == 163 || GameCanvas.loadmap.idMap == 165 || (((GameCanvas.loadmap.idMap >= 167 && GameCanvas.loadmap.idMap <= 176) || GameCanvas.loadmap.idMap == 190) && point.y <= 72);
					if (!flag8)
					{
						bool flag9 = point.x < num3;
						if (flag9)
						{
							point.dis = 0;
							point.x2 = point.x - 8;
							point.y2 = point.y - 18;
							point.f = 0;
							point.vx = -1;
						}
						else
						{
							bool flag10 = point.x > GameCanvas.loadmap.mapW * LoadMap.wTile - num3;
							if (flag10)
							{
								point.dis = 1;
								point.f = 1;
								point.x2 = point.x + 8;
								point.y2 = point.y - 18;
								point.vx = 1;
							}
							else
							{
								bool flag11 = point.y > GameCanvas.loadmap.mapH * LoadMap.wTile - num3 || GameCanvas.loadmap.idMap == 191;
								if (flag11)
								{
									point.dis = 3;
									point.f = 2;
									point.x2 = point.x;
									point.y2 = point.y - 20;
									point.vy = 1;
								}
								else
								{
									point.y -= 10;
									point.dis = 2;
									point.f = 2;
									point.x2 = point.x;
									point.y2 = point.y + 10;
									point.vy = -1;
								}
							}
						}
						goto IL_57E;
					}
					IL_58C:
					i++;
					continue;
					IL_57E:
					LoadMap.vecPointChange.addElement(point);
					goto IL_58C;
				}
			}
			bool flag12 = b == 0;
			if (flag12)
			{
				LoadMap.isOnlineMap = false;
				bool flag13 = LoadMap.specMap == 5;
				if (flag13)
				{
					this.LoadRedLine(false);
				}
				else
				{
					bool flag14 = LoadMap.specMap == 8;
					if (flag14)
					{
						MapGotoSky.setPos();
					}
					else
					{
						bool flag15 = LoadMap.specMap == 12;
						if (flag15)
						{
							MapGotoGod.setPos();
						}
					}
				}
			}
			LoadMapScreen.IDBack = msg.reader().readByte();
			LoadMapScreen.HBack = msg.reader().readShort();
			dataMap.IdBack = LoadMapScreen.IDBack;
			dataMap.hBack = LoadMapScreen.HBack;
			LoadMapScreen.isNextMap = true;
			bool flag16 = b == 1;
			if (flag16)
			{
				GameCanvas.gameScr.setTypeViewPlayer(typeViewPlayer);
			}
			sbyte b3 = msg.reader().readByte();
			sbyte level = msg.reader().readByte();
			LoadMapScreen.typeChangeMap = msg.reader().readByte();
			bool flag17 = b3 < 0 || GameCanvas.lowGraphic;
			if (flag17)
			{
				GameScreen.effMap = null;
			}
			else
			{
				GameScreen.effMap = new Effect_Map(b3, level);
			}
			bool flag18 = LoadMap.specMap == 3;
			if (flag18)
			{
				GlobalService.gI().Get_Xp_Map_Train(0);
				Player.AutoFireCur = Player.typeAutoFireMain;
				sbyte b4 = msg.reader().readByte();
				MainObject.mPosMapTrain = mSystem.new_M_Int((int)b4, 2);
				for (int j = 0; j < (int)b4; j++)
				{
					for (int k = 0; k < 2; k++)
					{
						MainObject.mPosMapTrain[j][k] = (int)msg.reader().readByte();
					}
				}
				Player.strTimeChange = msg.reader().readUTF();
			}
			Interface_Game.nameMap = msg.reader().readUTF();
			dataMap.nameMap = Interface_Game.nameMap;
			DataMap.hashDataMap.put(string.Empty + idmap.ToString(), dataMap);
			bool flag19 = LoadMap.specMap == 4;
			if (flag19)
			{
				GameScreen.player.boatSea = new Boat(GameScreen.player.ID, GameScreen.player.x, GameScreen.player.y, 0, (sbyte)GameScreen.player.type_left_right);
				GameScreen.player.setSpeed(4, 3);
				GameScreen.player.vySea = 4;
				bool flag20 = !GameCanvas.lowGraphic;
				if (flag20)
				{
					GameScreen.effSea = new Effect_Map(4, 0);
				}
			}
			else
			{
				bool flag21 = LoadMap.isOnlineMap && LoadMap.specMap != 5 && LoadMap.specMap != 8;
				if (flag21)
				{
					GameScreen.player.boatSea = null;
					GameScreen.player.setSpeed(7, 7);
					GameScreen.effSea = null;
				}
			}
		}
		catch (Exception)
		{
			GlobalService.gI().changeMapOk();
		}
	}

	// Token: 0x06000C62 RID: 3170 RVA: 0x000ED4AC File Offset: 0x000EB6AC
	public bool check_IDMap_PVP()
	{
		return GameCanvas.loadmap.idMap == 58 || GameCanvas.loadmap.idMap == 59 || GameCanvas.loadmap.idMap == 109 || GameCanvas.loadmap.idMap == 119 || GameCanvas.loadmap.idMap == 120 || GameCanvas.loadmap.idMap == 121 || GameCanvas.loadmap.idMap == 123;
	}

	// Token: 0x06000C63 RID: 3171 RVA: 0x000ED530 File Offset: 0x000EB730
	public void LoadRedLine(bool isFinish)
	{
		MapOff_RedLine.setTypeMoveredLine(0);
		GameCanvas.loadMapScr.mItemMap = null;
		MainScreen.cameraMain.xCam = 0;
		MainScreen.cameraMain.yCam = 0;
		MapOff_RedLine.xHardCodeMapRedLine = MotherCanvas.w / 3;
		if (isFinish)
		{
			MapOff_RedLine.isFinish = true;
			MapOff_RedLine.yHarcodeMapRedLine = MotherCanvas.h / 5 * 3;
			MapOff_RedLine.vxHardcodeRedLine = 8;
			GameScreen.player.x = 0;
			GameScreen.player.y = MapOff_RedLine.yHarcodeMapRedLine + 20;
		}
		else
		{
			MapOff_RedLine.isFinish = false;
			MapOff_RedLine.yHarcodeMapRedLine = MotherCanvas.h / 5 * 4;
			MapOff_RedLine.vxHardcodeRedLine = 6;
			GameScreen.player.x = MapOff_RedLine.xHardCodeMapRedLine;
			GameScreen.player.y = MapOff_RedLine.yHarcodeMapRedLine;
		}
		GameScreen.player.Dir = 2;
		GameScreen.player.type_left_right = 2;
		GameScreen.player.boatSea = new Boat(GameScreen.player.ID, GameScreen.player.x, GameScreen.player.y, 0, (sbyte)GameScreen.player.type_left_right);
		GameScreen.player.boatSea.setPartImage(GameScreen.player.myBoat, GameScreen.player.typePirate);
		Player.isChangeLine = false;
		Player.isShowDie = 0;
		GameScreen.player.lineShowRedLineCur = 2;
		GameScreen.player.lineShowRedLineNext = 2;
		MapOff_RedLine.xOffline = 0;
		MapOff_RedLine.yOffline = MapOff_RedLine.yHarcodeMapRedLine - 40;
		MapOff_RedLine.vecSongTuong.removeAllElements();
		MapOff_RedLine.vecSongBien.removeAllElements();
		MapOff_RedLine.vecDaBien.removeAllElements();
		MapOff_RedLine.vecEffDie.removeAllElements();
		MapOff_RedLine.vecEffSongTuong.removeAllElements();
		int num = MotherCanvas.w / 24 + 4;
		for (int i = 0; i < num; i++)
		{
			Point point = new Point();
			point.x = i * 24;
			if (isFinish)
			{
				point.y = i * 5;
			}
			else
			{
				point.y = -(i * 5);
			}
			point.frame = CRes.random(7);
			MapOff_RedLine.vecSongTuong.addElement(point);
		}
		for (int j = 0; j < MotherCanvas.w / 24 + 2; j++)
		{
			for (int k = 0; k <= (MotherCanvas.h - MapOff_RedLine.yOffline + j * 10 + 6) / 24; k++)
			{
				Point point2 = new Point();
				point2.x = j * 24;
				if (isFinish)
				{
					point2.y = j * 5 - 6 + k * 24;
				}
				else
				{
					point2.y = -j * 5 - 6 + k * 24;
				}
				point2.frame = CRes.random(7);
				bool flag = CRes.random(10) == 0;
				if (flag)
				{
					point2.isSmall = true;
				}
				MapOff_RedLine.vecSongBien.addElement(point2);
			}
		}
	}

	// Token: 0x06000C64 RID: 3172 RVA: 0x000ED80C File Offset: 0x000EBA0C
	public void ObjectMove(Message msg)
	{
		try
		{
			bool flag = !LoadMapScreen.isNextMap;
			if (!flag)
			{
				while (msg.reader().available() > 0)
				{
					sbyte cat = msg.reader().readByte();
					short id = msg.reader().readShort();
					short x = msg.reader().readShort();
					short y = msg.reader().readShort();
					bool flag2 = GameScreen.vecObjMove.size() <= 50;
					if (flag2)
					{
						ObjMove o = new ObjMove(cat, id, x, y);
						GameScreen.vecObjMove.addElement(o);
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C65 RID: 3173 RVA: 0x000ED8C0 File Offset: 0x000EBAC0
	public void loadImage(Message msg)
	{
		try
		{
			short num = msg.reader().readShort();
			sbyte[] array = new sbyte[msg.reader().available()];
			msg.reader().read(ref array);
			bool flag = ObjectData.setIdOK(num);
			if (flag)
			{
				SaveImageRMS.vecSaveImage.addElement(new idSaveImage(num, array));
			}
			mImage img = mImage.createImage(array, 0, array.Length);
			this.SetImage(img, num);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C66 RID: 3174 RVA: 0x000ED944 File Offset: 0x000EBB44
	public void LoadImageNew(Message msg)
	{
		try
		{
			sbyte type = msg.reader().readByte();
			short num = msg.reader().readShort();
			sbyte[] array = new sbyte[msg.reader().available()];
			msg.reader().read(ref array);
			bool flag = ObjectData.setIdOK(num);
			if (flag)
			{
				SaveImageRMS.vecSaveImage.addElement(new idSaveImage(num, array));
			}
			mImage img = mImage.createImage(array, 0, array.Length);
			this.SetImage(img, type, num);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C67 RID: 3175 RVA: 0x000ED9D8 File Offset: 0x000EBBD8
	public void SetImage(mImage img, sbyte type, short id)
	{
		bool flag = type == 7;
		if (flag)
		{
			ObjectData.HashImageCharPart.put(string.Empty + id.ToString(), new MainImage(img));
		}
	}

	// Token: 0x06000C68 RID: 3176 RVA: 0x000EDA14 File Offset: 0x000EBC14
	public void SetImage(mImage img, short id)
	{
		bool flag = id >= 26000;
		if (flag)
		{
			ObjectData.HashImageCharPart.put(string.Empty + ((int)(id - 26000 + 10000)).ToString(), new MainImage(img));
		}
		else
		{
			bool flag2 = id >= 25000;
			if (flag2)
			{
				ObjectData.HashImageEffClientLow.put(string.Empty + ((int)(id - 25000)).ToString(), new MainImage(img));
			}
			else
			{
				bool flag3 = id >= 24000;
				if (flag3)
				{
					ObjectData.HashImageEffClient.put(string.Empty + ((int)(id - 24000)).ToString(), new MainImage(img));
				}
				else
				{
					bool flag4 = id >= 23000;
					if (flag4)
					{
						ObjectData.HashImageOtherNew.put(string.Empty + ((int)(id - 23000)).ToString(), new MainImage(img));
					}
					else
					{
						bool flag5 = id >= 22000;
						if (flag5)
						{
							ObjectData.hashImageIconClanBig.put(string.Empty + ((int)(id - 22000)).ToString(), new MainImage(img));
						}
						else
						{
							bool flag6 = id >= 21000;
							if (flag6)
							{
								ObjectData.hashImageSkill.put(string.Empty + id.ToString(), new MainImage(img));
							}
							else
							{
								bool flag7 = id >= 20000;
								if (flag7)
								{
									ObjectData.HashImageFashion.put(string.Empty + ((int)(id - 20000)).ToString(), new MainImage(img));
								}
								else
								{
									bool flag8 = id >= 10000;
									if (flag8)
									{
										ObjectData.HashImageCharPart.put(string.Empty + ((int)(id - 10000)).ToString(), new MainImage(img));
									}
									else
									{
										bool flag9 = id >= 9000;
										if (flag9)
										{
											ObjectData.hashImageItemOther.put(string.Empty + ((int)(id - 9000)).ToString(), new MainImage(img));
										}
										else
										{
											bool flag10 = id >= 8000;
											if (flag10)
											{
												ObjectData.hashImageBoat.put(string.Empty + ((int)(id - 8000)).ToString(), new MainImage(img));
											}
											else
											{
												bool flag11 = id >= 7000;
												if (flag11)
												{
													ObjectData.hashImageIconClan.put(string.Empty + ((int)(id - 7000)).ToString(), new MainImage(img));
												}
												else
												{
													bool flag12 = id >= 6500;
													if (flag12)
													{
														ObjectData.hashImageMaterialPotion.put(string.Empty + ((int)(id - 6500)).ToString(), new MainImage(img));
													}
													else
													{
														bool flag13 = id >= 6000;
														if (flag13)
														{
															ObjectData.hashImageQuestPotion.put(string.Empty + ((int)(id - 6000)).ToString(), new MainImage(img));
														}
														else
														{
															bool flag14 = id >= 5000;
															if (flag14)
															{
																ObjectData.hashImageNPC.put(string.Empty + ((int)(id - 5000)).ToString(), new MainImage(img));
															}
															else
															{
																bool flag15 = id >= 4500;
																if (flag15)
																{
																	ObjectData.hashImageSkillSmall.put(string.Empty + ((int)(id - 4500)).ToString(), new MainImage(img));
																}
																else
																{
																	bool flag16 = id >= 4000;
																	if (flag16)
																	{
																		ObjectData.hashImageSkill.put(string.Empty + ((int)(id - 4000)).ToString(), new MainImage(img));
																	}
																	else
																	{
																		bool flag17 = id >= 3000;
																		if (flag17)
																		{
																			ObjectData.hashImageItem.put(string.Empty + ((int)(id - 3000)).ToString(), new MainImage(img));
																		}
																		else
																		{
																			bool flag18 = id >= 2000;
																			if (flag18)
																			{
																				ObjectData.hashImagePotion.put(string.Empty + ((int)(id - 2000)).ToString(), new MainImage(img));
																			}
																			else
																			{
																				bool flag19 = id >= 1000;
																				if (flag19)
																				{
																					ObjectData.HashImageMonster.put(string.Empty + ((int)(id - 1000)).ToString(), new MainImage(img));
																				}
																				else
																				{
																					ObjectData.HashImageItemMap.put(string.Empty + id.ToString(), new MainImage(img));
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x06000C69 RID: 3177 RVA: 0x000EDF20 File Offset: 0x000EC120
	public void char_info(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			sbyte b = msg.reader().readByte();
			MainObject mainObject = MainObject.get_Object((int)id, b);
			bool flag = mainObject != null;
			if (flag)
			{
				sbyte typePlayer = msg.reader().readByte();
				mainObject.typePirate = msg.reader().readByte();
				mainObject.typePK = msg.reader().readByte();
				sbyte b2 = msg.reader().readByte();
				mainObject.indexTeam = msg.reader().readByte();
				mainObject.name = msg.reader().readUTF();
				mainObject.typePlayer = typePlayer;
				mainObject.Lv = (int)msg.reader().readShort();
				mainObject.maxHp = msg.reader().readInt();
				mSystem.outz(string.Concat(new string[]
				{
					GameScreen.player.name,
					"char info name=",
					mainObject.name,
					" maxhp=",
					mainObject.maxHp.ToString(),
					" cat ",
					b.ToString(),
					" typePlayer ",
					mainObject.typePlayer.ToString()
				}));
				mainObject.Hp = msg.reader().readInt();
				mainObject.LvThongThao = (int)msg.reader().readShort();
				mainObject.rankWanted = msg.reader().readInt();
				mainObject.levelPerfect = msg.reader().readByte();
				bool flag2 = mainObject.typePlayer == 1;
				if (flag2)
				{
					mainObject.colorName = 4;
				}
				bool flag3 = mainObject.Hp <= 0;
				if (flag3)
				{
					mainObject.beginDie(null);
					mainObject.isDie = true;
				}
				else
				{
					mainObject.Action = 0;
				}
				bool flag4 = mainObject.typePlayer == 2 || mainObject.typePlayer == 3;
				if (flag4)
				{
					bool flag5 = b2 == 3;
					if (flag5)
					{
						b2 = -1;
					}
					mainObject.colorName = 4;
					bool flag6 = mainObject.typePlayer == 3;
					if (flag6)
					{
						mainObject.colorName = 2;
					}
					mainObject.IdIcon = msg.reader().readShort();
					sbyte imgMonSterforOtherPlayer = msg.reader().readByte();
					short idmainShiper = msg.reader().readShort();
					sbyte typePirate = msg.reader().readByte();
					mainObject.setSpeed(2, 2);
					mainObject.typePirate = typePirate;
					mainObject.IDMainShiper = idmainShiper;
					mainObject.setImgMonSterforOtherPlayer(imgMonSterforOtherPlayer);
					bool flag7 = LoadMap.specMap == 4;
					if (flag7)
					{
						mainObject.boatSea = new Boat(mainObject.ID, mainObject.x, mainObject.y, 0, (sbyte)mainObject.type_left_right);
						mainObject.vySea = 4;
					}
				}
				else
				{
					bool flag8 = LoadMap.specMap == 4;
					if (flag8)
					{
						mainObject.boatSea = new Boat(mainObject.ID, mainObject.x, mainObject.y, 0, (sbyte)mainObject.type_left_right);
						mainObject.setSpeed(4, 3);
						mainObject.wOne = 100;
						mainObject.vySea = 4;
					}
					else
					{
						mainObject.boatSea = null;
						mainObject.setSpeed(7, 7);
						mainObject.wOne = 26;
					}
					mainObject.clazz = msg.reader().readByte();
					mainObject.DirNew = msg.reader().readByte();
					bool flag9 = b == 2;
					if (flag9)
					{
						mainObject.nameGiaotiep = msg.reader().readUTF();
						mainObject.chatNPC = msg.reader().readUTF();
						mSystem.outz("NPC name " + mainObject.nameGiaotiep + " chat " + mainObject.chatNPC);
					}
					bool flag10 = msg.reader().available() > 0;
					if (flag10)
					{
						mainObject.lvHeart = msg.reader().readByte();
					}
					bool flag11 = LoadMap.specMap == 3;
					if (flag11)
					{
						GlobalService.gI().List_Skill_Map_Train(id);
						mainObject.setInfoMapTrain();
					}
					bool flag12 = GameScreen.typeViewPlayer == 1;
					if (flag12)
					{
						this.updateIndexView();
						bool flag13 = GameScreen.isSetObjdDefault && GameScreen.objView == null;
						if (flag13)
						{
							GameScreen.objView = mainObject;
						}
					}
				}
				mainObject.isInfo = true;
				mainObject.setDirNew(b2);
				mainObject.setWName();
				short bodyBay = -1;
				try
				{
					bodyBay = msg.reader().readShort();
				}
				catch (Exception)
				{
					bodyBay = -1;
				}
				mainObject.setBodyBay(bodyBay);
				short legBay = -1;
				try
				{
					legBay = msg.reader().readShort();
				}
				catch (Exception)
				{
					legBay = -1;
				}
				mainObject.setLegBay(legBay);
				short weaponBay = -1;
				try
				{
					weaponBay = msg.reader().readShort();
				}
				catch (Exception)
				{
					weaponBay = -1;
				}
				mainObject.setWeaponBay(weaponBay);
				short hairBay = -1;
				try
				{
					hairBay = msg.reader().readShort();
				}
				catch (Exception)
				{
					hairBay = -1;
				}
				mainObject.setHairBay(hairBay);
				mSystem.outz(string.Concat(new string[]
				{
					"char_info name = ",
					mainObject.name,
					" bay : ",
					bodyBay.ToString(),
					" ",
					legBay.ToString(),
					" ",
					weaponBay.ToString(),
					" ",
					hairBay.ToString()
				}));
			}
			else
			{
				mSystem.outloi("name null chang");
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C6A RID: 3178 RVA: 0x000EE4D0 File Offset: 0x000EC6D0
	public void updateIndexView()
	{
		sbyte b = 0;
		sbyte b2 = 0;
		for (int i = 0; i < GameScreen.vecPlayers.size(); i++)
		{
			MainObject mainObject = (MainObject)GameScreen.vecPlayers.elementAt(i);
			bool flag = mainObject.indexTeam == 1;
			if (flag)
			{
				mainObject.indexPaintView = b;
				b += 1;
			}
			else
			{
				bool flag2 = mainObject.indexTeam == 2;
				if (flag2)
				{
					mainObject.indexPaintView = b2;
					b2 += 1;
				}
			}
		}
	}

	// Token: 0x06000C6B RID: 3179 RVA: 0x000EE54C File Offset: 0x000EC74C
	public void remove_Char(Message msg)
	{
		try
		{
			short num = msg.reader().readShort();
			bool flag = msg.reader().available() == 0;
			if (!flag)
			{
				sbyte b = msg.reader().readByte();
				bool flag2 = num == GameScreen.player.ID;
				if (!flag2)
				{
					MainObject mainObject = MainObject.get_Object((int)num, 0);
					bool flag3 = mainObject == null || mainObject.isRemove;
					if (!flag3)
					{
						mainObject.isRemove = true;
						bool lowGraphic = GameCanvas.lowGraphic;
						if (lowGraphic)
						{
							GameScreen.checkObjRemoveInVecMove(num, 0);
						}
						else
						{
							switch (b)
							{
							case 1:
							{
								mainObject.timeEffRemoveChar = 8;
								bool isShowNameSUPER_BOSS = GameScreen.isShowNameSUPER_BOSS;
								if (isShowNameSUPER_BOSS)
								{
									GameScreen.addEffectEnd(31, 0, mainObject.x, mainObject.y, (sbyte)mainObject.type_left_right, null);
								}
								break;
							}
							case 2:
							{
								bool flag4 = mainObject.x < 100;
								if (flag4)
								{
									mainObject.timeEffRemoveChar = 10;
									mainObject.toX = 0;
								}
								else
								{
									bool flag5 = mainObject.x > GameCanvas.loadmap.maxWMap - 100;
									if (flag5)
									{
										mainObject.timeEffRemoveChar = 10;
										mainObject.toX = GameCanvas.loadmap.maxWMap;
									}
									else
									{
										GameScreen.addEffectEnd(80, 0, mainObject.x, mainObject.y - mainObject.hOne / 2, (sbyte)mainObject.type_left_right, null);
									}
								}
								break;
							}
							case 3:
							{
								bool flag6 = mainObject.typePlayer != 2 && mainObject.typePlayer != 3;
								if (flag6)
								{
									for (int i = 0; i < GameScreen.vecBoat.size(); i++)
									{
										Boat boat = (Boat)GameScreen.vecBoat.elementAt(i);
										bool flag7 = boat.ID != mainObject.ID;
										if (!flag7)
										{
											for (int j = 0; j < LoadMap.mSea.Length; j++)
											{
												bool flag8 = (int)LoadMap.mSea[j][0] == GameCanvas.loadmap.idMap;
												if (flag8)
												{
													mainObject.timeEffRemoveChar = 80;
													mainObject.setActionSea((sbyte)(LoadMap.mSea[j][2] - 1), boat.x, (int)LoadMap.mSea[j][4]);
													return;
												}
											}
											break;
										}
									}
									GameScreen.addEffectEnd(80, 0, mainObject.x, mainObject.y - mainObject.hOne / 2, (sbyte)mainObject.type_left_right, null);
								}
								else
								{
									mainObject.timeEffRemoveChar = 80;
								}
								break;
							}
							default:
								GameScreen.addEffectEnd(80, 0, mainObject.x, mainObject.y - mainObject.hOne / 2, (sbyte)mainObject.type_left_right, null);
								break;
							}
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C6C RID: 3180 RVA: 0x000EE828 File Offset: 0x000ECA28
	public void getData(Message msg)
	{
		try
		{
			switch (msg.reader().readByte())
			{
			case 2:
				this.Get_Name_Attributes(msg);
				break;
			case 3:
				this.Get_Skill_Player(msg);
				break;
			case 4:
			{
				sbyte b = msg.reader().readByte();
				LoadMap.mLockMap = new sbyte[(int)b];
				for (int i = 0; i < (int)b; i++)
				{
					LoadMap.mLockMap[i] = msg.reader().readByte();
				}
				break;
			}
			case 5:
				this.Get_Data_Char_Part(msg);
				break;
			case 6:
				this.Get_Data_Name_Map(msg);
				break;
			case 7:
				this.Get_Data_Name_Potion_Quest(msg);
				break;
			case 8:
				TabInventory.priceItemSell = msg.reader().readShort();
				TabInventory.maxPriceItemSell = msg.reader().readShort();
				TabInventory.pricePotionSell = msg.reader().readShort();
				break;
			case 9:
				this.Get_Data_Item_Map(msg);
				break;
			case 10:
			{
				sbyte b2 = msg.reader().readByte();
				LoadMap.mMapLang = new short[(int)b2];
				for (int j = 0; j < (int)b2; j++)
				{
					LoadMap.mMapLang[j] = msg.reader().readShort();
				}
				break;
			}
			case 11:
			{
				sbyte b3 = msg.reader().readByte();
				for (int k = 0; k < (int)b3; k++)
				{
					MainMaterial mainMaterial = new MainMaterial(msg.reader().readByte(), msg.reader().readUTF(), msg.reader().readByte(), msg.reader().readByte(), msg.reader().readInt(), msg.reader().readShort(), msg.reader().readByte());
					MainItem.hashMaterialTem.put(string.Empty + mainMaterial.ID.ToString(), mainMaterial);
				}
				GlobalService.isGetMaterial = true;
				break;
			}
			case 12:
				this.Get_Data_Upgrade(msg);
				break;
			case 13:
			{
				sbyte b4 = msg.reader().readByte();
				LoadMap.mSea = new short[(int)b4][];
				for (int l = 0; l < (int)b4; l++)
				{
					LoadMap.mSea[l] = new short[6];
					for (int m = 0; m < LoadMap.mSea[l].Length; m++)
					{
						LoadMap.mSea[l][m] = msg.reader().readShort();
					}
				}
				break;
			}
			case 15:
				this.Get_Monster_Tem(msg);
				break;
			case 17:
			{
				long num = msg.reader().readLong();
				GameCanvas.clockServer = num - GameCanvas.timeNow;
				break;
			}
			case 18:
				this.Get_Potion_Tem(msg, 8);
				break;
			case 19:
			{
				sbyte b5 = msg.reader().readByte();
				ScreenUpgrade.mTileUpdate = new short[(int)b5];
				for (int n = 0; n < (int)b5; n++)
				{
					ScreenUpgrade.mTileUpdate[n] = msg.reader().readShort();
				}
				sbyte b6 = msg.reader().readByte();
				ScreenUpgrade.mTileGhepĐa = new short[(int)b6];
				for (int num2 = 0; num2 < (int)b6; num2++)
				{
					ScreenUpgrade.mTileGhepĐa[num2] = msg.reader().readShort();
				}
				break;
			}
			case 21:
			{
				sbyte b7 = msg.reader().readByte();
				bool flag = b7 == 0;
				if (flag)
				{
					GameScreen.h12plus = 0;
					Interface_Game.setYTouch();
				}
				else
				{
					GameScreen.h12plus = 12;
					Interface_Game.setYTouch();
				}
				GameScreen.interfaceGame.loadPosLoL();
				break;
			}
			case 22:
			{
				sbyte b8 = msg.reader().readByte();
				bool flag2 = b8 == 1;
				if (flag2)
				{
					GameScreen.isShowNameXpArena = true;
				}
				else
				{
					bool flag3 = b8 == 0;
					if (flag3)
					{
						GameScreen.isShowNameSUPER_BOSS = false;
					}
					else
					{
						bool flag4 = b8 == 2;
						if (flag4)
						{
							GameScreen.isShowNameWW = true;
						}
					}
				}
				break;
			}
			case 23:
				this.Get_Data_Char_Part(msg);
				break;
			case 25:
				this.Get_Potion_Tem(msg, 4);
				break;
			case 26:
			{
				GlobalService.isGetKichAn = true;
				sbyte b9 = msg.reader().readByte();
				for (int num3 = 0; num3 < (int)b9; num3++)
				{
					string v = msg.reader().readUTF();
					MainItem.hashAttriKichAn.put(string.Empty + num3.ToString(), v);
				}
				break;
			}
			case 27:
			{
				sbyte b10 = msg.reader().readByte();
				bool flag5 = b10 == 1;
				if (flag5)
				{
					GameScreen.isOpenDao = true;
				}
				else
				{
					GameScreen.isOpenDao = false;
				}
				break;
			}
			case 28:
				this.Update_Potion_Tem(msg, 4);
				break;
			case 29:
				this.Update_Potion_Tem(msg, 4);
				break;
			case 30:
			{
				sbyte b11 = msg.reader().readByte();
				T.mEffSpec = new string[(int)b11];
				for (int num4 = 0; num4 < (int)b11; num4++)
				{
					T.mEffSpec[num4] = msg.reader().readUTF();
				}
				break;
			}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C6D RID: 3181 RVA: 0x000EED9C File Offset: 0x000ECF9C
	private void Get_Data_Upgrade(Message msg)
	{
		try
		{
			sbyte[] array = new sbyte[msg.reader().available()];
			msg.reader().read(ref array);
			ByteArrayInputStream bis = new ByteArrayInputStream(array);
			DataInputStream iss = new DataInputStream(bis);
			MainDataUpgrade.LoadDataUpgrade(iss, true);
			SaveRms.saveData(array, "dataUpgradeSave");
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C6E RID: 3182 RVA: 0x000EEE04 File Offset: 0x000ED004
	private void Get_Data_Name_Potion_Quest(Message msg)
	{
		try
		{
			sbyte[] array = new sbyte[msg.reader().available()];
			msg.reader().read(ref array);
			ByteArrayInputStream bis = new ByteArrayInputStream(array);
			DataInputStream iss = new DataInputStream(bis);
			MainQuest.LoadNamePotionQuest(iss, true);
			SaveRms.saveData(array, "dataNamePotionquest");
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C6F RID: 3183 RVA: 0x000EEE6C File Offset: 0x000ED06C
	private void Get_Data_Name_Map(Message msg)
	{
		try
		{
			sbyte[] array = new sbyte[msg.reader().available()];
			msg.reader().read(ref array);
			ByteArrayInputStream bis = new ByteArrayInputStream(array);
			DataInputStream iss = new DataInputStream(bis);
			LoadMap.LoadNameMap(iss, true);
			SaveRms.saveData(array, "dataNameMap");
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C70 RID: 3184 RVA: 0x000EEED4 File Offset: 0x000ED0D4
	private void Get_Data_Char_Part(Message msg)
	{
		try
		{
			sbyte[] array = new sbyte[msg.reader().available()];
			msg.reader().read(ref array);
			ByteArrayInputStream bis = new ByteArrayInputStream(array);
			DataInputStream dis = new DataInputStream(bis);
			CharPartInfo.LoadDataCharPart(dis, 1);
			SaveRms.saveData(array, "dataCharPart");
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C71 RID: 3185 RVA: 0x000EEF3C File Offset: 0x000ED13C
	private void Get_Name_Attributes(Message msg)
	{
		try
		{
			sbyte[] array = new sbyte[msg.reader().available()];
			msg.reader().read(ref array);
			ByteArrayInputStream bis = new ByteArrayInputStream(array);
			DataInputStream iss = new DataInputStream(bis);
			MainItem.LoadNameAttribute(iss, true);
			SaveRms.saveData(array, "dataAttri");
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C72 RID: 3186 RVA: 0x000EEFA4 File Offset: 0x000ED1A4
	private void Get_Potion_Tem(Message msg, sbyte typePotion)
	{
		try
		{
			sbyte[] array = new sbyte[msg.reader().available()];
			msg.reader().read(ref array);
			ByteArrayInputStream bis = new ByteArrayInputStream(array);
			DataInputStream iss = new DataInputStream(bis);
			Potion.UpdateDataPotion(iss, true, typePotion);
			bool flag = typePotion == 4;
			if (flag)
			{
				SaveRms.saveData(array, "dataPotion");
			}
			bool flag2 = typePotion == 8;
			if (flag2)
			{
				SaveRms.saveData(array, "dataPotionClan");
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C73 RID: 3187 RVA: 0x000EEFA4 File Offset: 0x000ED1A4
	private void Update_Potion_Tem(Message msg, sbyte typePotion)
	{
		try
		{
			sbyte[] array = new sbyte[msg.reader().available()];
			msg.reader().read(ref array);
			ByteArrayInputStream bis = new ByteArrayInputStream(array);
			DataInputStream iss = new DataInputStream(bis);
			Potion.UpdateDataPotion(iss, true, typePotion);
			bool flag = typePotion == 4;
			if (flag)
			{
				SaveRms.saveData(array, "dataPotion");
			}
			bool flag2 = typePotion == 8;
			if (flag2)
			{
				SaveRms.saveData(array, "dataPotionClan");
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C74 RID: 3188 RVA: 0x000EF030 File Offset: 0x000ED230
	public void Get_Monster_Tem(Message msg)
	{
		try
		{
			sbyte[] array = new sbyte[msg.reader().available()];
			msg.reader().read(ref array);
			ByteArrayInputStream bis = new ByteArrayInputStream(array);
			DataInputStream iss = new DataInputStream(bis);
			CatalogyMonster.LoadDataMon(iss, true);
			SaveRms.saveData(array, "dataMon");
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C75 RID: 3189 RVA: 0x000EF098 File Offset: 0x000ED298
	private void Get_Skill_Player(Message msg)
	{
		try
		{
			ReadMessenge.indexHotKeySkill = 0;
			Player.vecListSkill.removeAllElements();
			sbyte b = msg.reader().readByte();
			for (int i = 0; i < (int)b; i++)
			{
				Skill_Info skill_Info = this.readSkillInfo(msg);
				bool flag = skill_Info != null;
				if (flag)
				{
					skill_Info.indexHotKey = ReadMessenge.indexHotKeySkill;
					Player.vecListSkill.addElement(skill_Info);
					ReadMessenge.indexHotKeySkill += 1;
				}
			}
			Player.vecListSkill = MainItem.SortVecItem(Player.vecListSkill);
			GlobalService.gI().Save_RMS_Server(0, 0, null);
			Player.isSkillready = false;
			for (int j = 0; j < Player.vecListSkill.size(); j++)
			{
				Skill_Info skill_Info2 = (Skill_Info)Player.vecListSkill.elementAt(j);
				bool flag2 = skill_Info2.Lv_RQ == -1 && ((skill_Info2.typeSkill != 3 && skill_Info2.typeSkill != 6) || TabSkill.numCurrentPassive < (int)Player.numPassive);
				if (flag2)
				{
					Player.isSkillready = true;
					break;
				}
			}
			Player.setHotKeyBuff();
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C76 RID: 3190 RVA: 0x000EF1D0 File Offset: 0x000ED3D0
	public Skill_Info readSkillInfo(Message msg)
	{
		Skill_Info skill_Info = null;
		Skill_Info result;
		try
		{
			skill_Info = new Skill_Info(msg.reader().readShort(), msg.reader().readShort(), msg.reader().readShort(), msg.reader().readByte(), msg.reader().readByte(), msg.reader().readUTF(), msg.reader().readShort(), msg.reader().readShort(), 0);
			skill_Info.getData(msg.reader().readByte(), msg.reader().readShort(), msg.reader().readInt(), msg.reader().readShort(), msg.reader().readInt(), msg.reader().readByte(), msg.reader().readUTF(), msg.reader().readByte(), msg.reader().readShort(), msg.reader().readByte());
			skill_Info.vecAtt.removeAllElements();
			sbyte b = msg.reader().readByte();
			for (int i = 0; i < (int)b; i++)
			{
				MainInfoItem o = new MainInfoItem(msg.reader().readByte(), (int)msg.reader().readShort());
				skill_Info.vecAtt.addElement(o);
			}
			skill_Info.idEffSpec = msg.reader().readByte();
			bool flag = skill_Info.idEffSpec > 0;
			if (flag)
			{
				skill_Info.perEffSpec = msg.reader().readShort();
				skill_Info.timeEffSpec = msg.reader().readShort();
			}
			skill_Info.LvDevilSkill = msg.reader().readByte();
			skill_Info.phanTramDevilSkill = msg.reader().readByte();
			result = skill_Info;
		}
		catch (Exception)
		{
			result = skill_Info;
		}
		return result;
	}

	// Token: 0x06000C77 RID: 3191 RVA: 0x000EF39C File Offset: 0x000ED59C
	private void Get_Data_Item_Map(Message msg)
	{
		mSystem.outz("000000000000000000 Get_Data_Item_Map");
		try
		{
			sbyte[] array = new sbyte[msg.reader().available()];
			msg.reader().read(ref array);
			ByteArrayInputStream bis = new ByteArrayInputStream(array);
			DataInputStream iss = new DataInputStream(bis);
			LoadMap.load_Table_Map(iss, true);
			SaveRms.saveData(array, "dataItemMap");
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C78 RID: 3192 RVA: 0x000EF410 File Offset: 0x000ED610
	public void monsterInfo(Message msg)
	{
		try
		{
			bool flag = !LoadMapScreen.isNextMap;
			if (!flag)
			{
				short id = msg.reader().readShort();
				short idCatMonster = msg.reader().readShort();
				MainObject mainObject = MainObject.get_Object((int)id, 1);
				bool flag2 = mainObject != null;
				if (flag2)
				{
					mainObject.isRemove = true;
				}
				short x = msg.reader().readShort();
				short y = msg.reader().readShort();
				MainMonster mainMonster = MainMonster.createMonster(id, (int)x, (int)y, idCatMonster);
				bool flag3 = mainMonster == null;
				if (!flag3)
				{
					mainMonster.Lv = (int)msg.reader().readShort();
					mainMonster.Hp = msg.reader().readInt();
					mainMonster.maxHp = msg.reader().readInt();
					short typeEff = msg.reader().readShort();
					MainSkill mainSkill = mainMonster.Skilldefault = new MainSkill(-1, typeEff);
					mainMonster.timeRevice = (int)msg.reader().readShort();
					mainMonster.typeSpecMonSter = msg.reader().readByte();
					mainMonster.isInfo = true;
					bool flag4 = msg.reader().available() > 0;
					if (flag4)
					{
						mainMonster.LvThongThao = (int)msg.reader().readByte();
						bool flag5 = mainMonster.LvThongThao > 0;
						if (flag5)
						{
							mainMonster.name = mainMonster.name + T.bat + mainMonster.LvThongThao.ToString();
							mainMonster.setWName();
						}
					}
					GameScreen.addPlayer(mainMonster);
					bool flag6 = mainMonster.isPokemon > 0;
					if (flag6)
					{
						GameScreen.addEffectEnd_ObjTo(32, 0, mainMonster.x, mainMonster.y, mainMonster.ID, mainMonster.typeObject, (sbyte)mainMonster.Dir, null);
					}
					bool flag7 = mainMonster.isTru() && mainMonster.Hp <= 0;
					if (flag7)
					{
						mainMonster.isDie = true;
						mainMonster.timeDie = 0L;
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C79 RID: 3193 RVA: 0x000EF628 File Offset: 0x000ED828
	public void Fire_Object(Message msg)
	{
		try
		{
			bool isNextMap = LoadMapScreen.isNextMap;
			if (isNextMap)
			{
				bool flag = GameCanvas.lowGraphic && GameScreen.vecObjFire.size() > 20;
				if (flag)
				{
					GameScreen.vecObjFire.removeElementAt(1);
				}
				msg.isOld = 1;
				GameScreen.vecObjFire.addElement(msg);
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C7A RID: 3194 RVA: 0x000EF698 File Offset: 0x000ED898
	public void MonsterNoneFocus(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			MainMonster mainMonster = (MainMonster)MainObject.get_Object((int)id, 1);
			bool flag = mainMonster == null || mainMonster.returnAction();
			if (!flag)
			{
				bool flag2 = mainMonster.Action == 4;
				if (flag2)
				{
					bool flag3 = mainMonster.timeRevice < 0;
					if (flag3)
					{
						return;
					}
					mainMonster.Reveive();
				}
				bool flag4 = mainMonster.skillCurrent != null;
				if (flag4)
				{
					mainMonster.beginFire();
				}
				mainMonster.isRunAttack = false;
				mainMonster.objMainFocus = null;
				mainMonster.posTransRoad = null;
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C7B RID: 3195 RVA: 0x000EF740 File Offset: 0x000ED940
	public void diePlayer(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			sbyte b = msg.reader().readByte();
			short id2 = msg.reader().readShort();
			sbyte tem = msg.reader().readByte();
			short pointPk = msg.reader().readShort();
			MainObject mainObject = MainObject.get_Object((int)id2, tem);
			MainObject mainObject2 = MainObject.get_Object((int)id, b);
			bool flag = b == 0 && mainObject2 != null && !mainObject2.returnAction();
			if (flag)
			{
				mainObject2.pointPk = (int)pointPk;
			}
			bool flag2 = mainObject == null || mainObject.returnAction() || mainObject.Hp <= 0;
			if (!flag2)
			{
				mainObject.Hp = 0;
				mainObject.beginDie(mainObject2);
				bool flag3 = mainObject == GameScreen.player || (mainObject.typeObject == 0 && CRes.random(3) == 0);
				if (flag3)
				{
					bool flag4 = mainObject.clazz == 4;
					if (flag4)
					{
						mSound.playSound(36, mSound.volumeSound);
					}
					else
					{
						mSound.playSound(35, mSound.volumeSound);
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C7C RID: 3196 RVA: 0x000EF878 File Offset: 0x000EDA78
	public void Revice_Player(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			sbyte tem = msg.reader().readByte();
			MainObject mainObject = MainObject.get_Object((int)id, tem);
			bool flag = mainObject != null && !mainObject.returnAction();
			if (flag)
			{
				mainObject.maxHp = msg.reader().readInt();
				mainObject.maxMp = msg.reader().readInt();
				mainObject.Reveive();
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C7D RID: 3197 RVA: 0x000EF900 File Offset: 0x000EDB00
	public void Set_XP(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			MainObject mainObject = MainObject.get_Object((int)id, 0);
			bool flag = mainObject != null && !mainObject.returnAction();
			if (flag)
			{
				bool flag2 = mainObject.Lv == 100;
				if (flag2)
				{
					mainObject.percentThongThao = (int)msg.reader().readShort();
				}
				else
				{
					mainObject.percentLv = (int)msg.reader().readShort();
				}
				int num = msg.reader().readInt();
				bool flag3 = !GameCanvas.lowGraphic || mainObject == GameScreen.player;
				if (flag3)
				{
					GameScreen.addEffectNum(num.ToString() + "xp", mainObject.x, mainObject.y - mainObject.hOne, 1);
				}
				bool flag4 = mainObject == GameScreen.player && GameScreen.isShowTextTab;
				if (flag4)
				{
					GameCanvas.chatTabScr.addNewChat(T.tabTestAdmin, "+Xp: ", string.Empty + num.ToString(), 1, false);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C7E RID: 3198 RVA: 0x000EFA1C File Offset: 0x000EDC1C
	public void Set_XP_Skill(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			MainObject mainObject = MainObject.get_Object((int)id, 0);
			bool flag = mainObject != null && !mainObject.returnAction();
			if (flag)
			{
				int num = msg.reader().readInt();
				bool flag2 = !GameCanvas.lowGraphic || mainObject == GameScreen.player;
				if (flag2)
				{
					GameScreen.addEffectNum(num.ToString() + "xp", mainObject.x, mainObject.y - mainObject.hOne, 24);
				}
				bool flag3 = mainObject == GameScreen.player && GameScreen.isShowTextTab;
				if (flag3)
				{
					GameCanvas.chatTabScr.addNewChat(T.tabTestAdmin, "+XpSkill: ", string.Empty + num.ToString(), 1, false);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C7F RID: 3199 RVA: 0x000EFB04 File Offset: 0x000EDD04
	public void Get_Xp_Map_Train(Message msg)
	{
		try
		{
			LoadMap.currentXp = msg.reader().readInt();
			LoadMap.maxXp = msg.reader().readInt();
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C80 RID: 3200 RVA: 0x000EFB4C File Offset: 0x000EDD4C
	public void Main_char_Info(Message msg)
	{
		try
		{
			bool flag = GameScreen.player == null;
			if (flag)
			{
				GameScreen.player = new Player();
				ReadMessenge.resetPlayer();
			}
			GameScreen.player.ID = msg.reader().readShort();
			GameScreen.player.name = msg.reader().readUTF();
			GameCanvas.saveRms.saveUserLast(GameScreen.player.name);
			GameScreen.player.maxHp = msg.reader().readInt();
			GameScreen.player.maxMp = msg.reader().readInt();
			GameScreen.player.Hp = msg.reader().readInt();
			GameScreen.player.Mp = msg.reader().readInt();
			GameScreen.player.Lv = (int)msg.reader().readShort();
			GameScreen.player.percentLv = (int)msg.reader().readShort();
			GameScreen.player.LvThongThao = (int)msg.reader().readShort();
			GameScreen.player.percentThongThao = (int)msg.reader().readShort();
			GameScreen.player.rankWanted = msg.reader().readInt();
			GameScreen.player.clazz = msg.reader().readByte();
			GameScreen.player.isInfo = true;
			GameScreen.player.pointPk = msg.reader().readInt();
			Player.pointAttribute = (int)msg.reader().readShort();
			GameScreen.player.typePirate = msg.reader().readByte();
			Player.indexGhostServer = msg.reader().readByte();
			Player.numPassive = msg.reader().readByte();
			GameScreen.player.levelPerfect = msg.reader().readByte();
			Player.giamCountDownAtt = 0;
			this.readAttribute(msg);
			Player.pointSkill = (int)msg.reader().readShort();
			sbyte b = msg.reader().readByte();
			Player.mLvSkill = new sbyte[(int)b];
			Player.mLvSkillPlus = new sbyte[(int)b];
			for (int i = 0; i < Player.mLvSkill.Length; i++)
			{
				Player.mLvSkill[i] = msg.reader().readByte();
			}
			for (int j = 0; j < Player.mLvSkillPlus.Length; j++)
			{
				Player.mLvSkillPlus[j] = msg.reader().readByte();
			}
			GameScreen.player.vecAllInfo.removeAllElements();
			sbyte b2 = msg.reader().readByte();
			for (int k = 0; k < (int)b2; k++)
			{
				MainInfoItem mainInfoItem = new MainInfoItem(msg.reader().readByte(), msg.reader().readInt());
				bool flag2 = mainInfoItem.id <= 4 || mainInfoItem.id >= 10;
				if (flag2)
				{
					GameScreen.player.vecAllInfo.addElement(mainInfoItem);
				}
				for (int l = 0; l < Player.hardCodeShortInfo[0].Length; l++)
				{
					bool flag3 = (int)mainInfoItem.id == Player.hardCodeShortInfo[0][l];
					if (flag3)
					{
						Player.hardCodeShortInfo[1][l] = mainInfoItem.value;
					}
				}
				bool flag4 = mainInfoItem.id == 25;
				if (flag4)
				{
					Player.giamCountDownAtt = (short)mainInfoItem.value;
				}
			}
			Player.SetGiamCountDown();
			this.getInfoEquip();
			short bodyBay = -1;
			try
			{
				bodyBay = msg.reader().readShort();
			}
			catch (Exception)
			{
				bodyBay = -1;
			}
			GameScreen.player.setBodyBay(bodyBay);
			short legBay = -1;
			try
			{
				legBay = msg.reader().readShort();
			}
			catch (Exception)
			{
				legBay = -1;
			}
			GameScreen.player.setLegBay(legBay);
			short weaponBay = -1;
			try
			{
				weaponBay = msg.reader().readShort();
			}
			catch (Exception)
			{
				weaponBay = -1;
			}
			GameScreen.player.setWeaponBay(weaponBay);
			short hairBay = -1;
			try
			{
				hairBay = msg.reader().readShort();
			}
			catch (Exception)
			{
				hairBay = -1;
			}
			GameScreen.player.setHairBay(hairBay);
			mSystem.outz(string.Concat(new string[]
			{
				"Main_char_Info name = ",
				GameScreen.player.name,
				" bay : ",
				bodyBay.ToString(),
				" ",
				legBay.ToString(),
				" ",
				weaponBay.ToString(),
				" ",
				hairBay.ToString()
			}));
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C81 RID: 3201 RVA: 0x000F0040 File Offset: 0x000EE240
	public void readAttribute(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			Main_Attribute[] array = new Main_Attribute[(int)b];
			for (int i = 0; i < (int)b; i++)
			{
				string name = msg.reader().readUTF();
				short value = msg.reader().readShort();
				short valueP = msg.reader().readShort();
				sbyte b2 = msg.reader().readByte();
				MainInfoItem[] array2 = new MainInfoItem[(int)b2];
				for (int j = 0; j < array2.Length; j++)
				{
					array2[j] = new MainInfoItem(msg.reader().readByte(), msg.reader().readInt());
				}
				array[i] = new Main_Attribute((sbyte)i, value, valueP, name, array2);
			}
			TabInfo.updateTabAttri(array);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C82 RID: 3202 RVA: 0x000F0124 File Offset: 0x000EE324
	public void getInfoEquip()
	{
		Player.InfoShortEquip[0] = MainItem.strGetPercent(Player.hardCodeShortInfo[1][0], 0);
		Player.InfoShortEquip[1] = MainItem.strGetPercent(Player.hardCodeShortInfo[1][1], 1);
		Player.InfoShortEquip[2] = string.Empty + (Player.hardCodeShortInfo[1][2] + Player.hardCodeShortInfo[1][2] * Player.hardCodeShortInfo[1][3] / 1000).ToString();
		Player.InfoShortEquip[3] = MainItem.strGetPercent(Player.hardCodeShortInfo[1][4], 1);
		Player.InfoShortEquip[4] = MainItem.strGetPercent(Player.hardCodeShortInfo[1][5], 1);
		Player.InfoShortEquip[5] = MainItem.strGetPercent(Player.hardCodeShortInfo[1][6], 1);
	}

	// Token: 0x06000C83 RID: 3203 RVA: 0x000F01DC File Offset: 0x000EE3DC
	public static void resetPlayer()
	{
		GameCanvas.saveRms.saveUserPass(GameCanvas.loginScr.tfUser.getText(), GameCanvas.loginScr.tfPass.getText());
		GameScreen.vecPlayers.addElement(GameScreen.player);
		GameCanvas.chatTabScr.vecTabChat.removeAllElements();
		Player.vecParty.removeAllElements();
		Player.mSatnhan = new short[0];
		GameCanvas.tabAllScr.idSelect = 0;
		GameCanvas.tabAllScr.setTabSelect();
		GameCanvas.tabAllScr.tabCurrent.beginFocus();
		Interface_Game.vecEventShow.removeAllElements();
		Interface_Game.vecInfoServer.removeAllElements();
		Interface_Game.infoFight = null;
		Interface_Game.infoNormal = null;
		Interface_Game.infoSpec = null;
		Interface_Game.mCountKichAn = null;
		RoomWantedScreen.instance = null;
		LoadMap.hashMapItem.clear();
		LoadMap.demSendTem = 0;
		Player.vecEvent.removeAllElements();
		Player.vecChest.removeAllElements();
		Player.vecInventory.removeAllElements();
		Player.vecInvenClan.removeAllElements();
		Player.mComboSkill = null;
		Player.isAutoMaterial = 0;
		Player.isGhost = false;
		Player.beliTest = 0L;
		MainTab.CDKeyBoss.setCountDown(0);
		MainTab.CDPvP.setCountDown(0);
		MainTab.CDTicket.setCountDown(0);
		MainTab.CDx2XP.setCountDown(0);
		LoadMap.specMap = 0;
		GameScreen.indexHelp = -1;
		GameScreen.vecHelp = null;
		GameCanvas.chatTabScr.addNewChat(T.tabServer, string.Empty, T.thongbao, 1, false);
		GameCanvas.chatTabScr.getCurTab(0);
		GameCanvas.chatTabScr.updateCamTab();
		GameScreen.numMess = 0;
		FriendList.isGetListFriend = false;
		Player.isGetItem = true;
		Player.isMPHP = true;
		Player.typeAutoFireMain = 1;
		Player.AutoFireCur = 0;
		Player.isGetDataClan = -1;
		for (int i = 0; i < Player.mChestWanted.Length; i++)
		{
			Player.mChestWanted[i] = null;
		}
		GameScreen.player.clan = null;
		GameCanvas.ClanScr = null;
		MsgAutoFire.value = null;
		ScreenUpgradeSkillDevil.instance = null;
		Player.setStart_EndAutoFire(false);
		GlobalService.gI().Save_RMS_Server(0, 1, null);
		GlobalService.gI().Save_RMS_Server(0, 8, null);
		GlobalService.gI().Save_RMS_Server(0, 2, null);
		GlobalService.gI().Save_RMS_Server(0, 3, null);
		GlobalService.gI().Save_RMS_Server(0, 4, null);
		GlobalService.gI().Save_RMS_Server(0, 5, null);
		GlobalService.gI().Save_RMS_Server(0, 6, null);
		GlobalService.gI().Save_RMS_Server(0, 7, null);
		GlobalService.gI().Save_RMS_Server(0, 9, null);
		GlobalService.gI().Save_RMS_Server(0, 10, null);
		bool flag = Player.AutoRevice == 1;
		if (flag)
		{
			Interface_Game.addInfoPlayerNormal(T.dangbatauto, mFont.tahoma_7_white);
		}
	}

	// Token: 0x06000C84 RID: 3204 RVA: 0x000F0488 File Offset: 0x000EE688
	public void Dialog_More_server(Message msg)
	{
		bool flag = GameCanvas.currentScreen == GameCanvas.updateImageAndroidScr;
		if (flag)
		{
			GameCanvas.currentDialog = null;
			GameCanvas.subDialog = null;
		}
		else
		{
			try
			{
				ReadMessenge.IdDialog = msg.reader().readShort();
				sbyte b = msg.reader().readByte();
				string text = msg.reader().readUTF();
				string info = msg.reader().readUTF();
				mVector mVector = new mVector();
				sbyte b2 = msg.reader().readByte();
				for (int i = 0; i < (int)b2; i++)
				{
					string caption = msg.reader().readUTF();
					sbyte subType = msg.reader().readByte();
					iCommand iCommand = new iCommand(caption, 0, (int)subType, this);
					sbyte b3 = msg.reader().readByte();
					bool flag2 = b3 >= 0;
					if (flag2)
					{
						iCommand = this.setImgCmdNew(iCommand, b3);
					}
					mVector.addElement(iCommand);
				}
				bool flag3 = b == 0;
				if (flag3)
				{
					GameCanvas.Start_Normal_DiaLog(info, mVector, true);
				}
				else
				{
					bool flag4 = b == 1;
					if (flag4)
					{
						MsgDialog msgDialog = new MsgDialog();
						msgDialog.setinfoDownload(info, text);
						GameCanvas.Start_Current_Dialog(msgDialog);
					}
					else
					{
						bool flag5 = b == 2;
						if (flag5)
						{
							GameCanvas.Start_Normal_DiaLog(info, mVector, false);
						}
						else
						{
							bool flag6 = b == 3;
							if (flag6)
							{
								int time = msg.reader().readInt();
								GameCanvas.Start_Time_DiaLog(info, false, time, mVector);
							}
							else
							{
								bool flag7 = b == 4;
								if (flag7)
								{
									sbyte b4 = msg.reader().readByte();
									Item_Drop[] array = new Item_Drop[(int)b4];
									for (int j = 0; j < (int)b4; j++)
									{
										sbyte type = msg.reader().readByte();
										string name = msg.reader().readUTF();
										short idIcon = msg.reader().readShort();
										int num = msg.reader().readInt();
										sbyte color = msg.reader().readByte();
										array[j] = new Item_Drop((short)j, type, name, 0, 0, idIcon, color);
										array[j].num = num;
									}
									MsgShowGift msgShowGift = new MsgShowGift();
									msgShowGift.setinfoShow_Gift(1, text, info, array, -1);
									msgShowGift.setCmdList(mVector);
									GameCanvas.Start_Current_Dialog(msgShowGift);
								}
							}
						}
					}
				}
				GameMidlet.instance.removeEditText();
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x06000C85 RID: 3205 RVA: 0x000F06F8 File Offset: 0x000EE8F8
	private iCommand setImgCmdNew(iCommand cmd, sbyte IdImg)
	{
		MainItem item = new MainItem(100, (short)IdImg, 0);
		cmd.setItem(item);
		return cmd;
	}

	// Token: 0x06000C86 RID: 3206 RVA: 0x000F0720 File Offset: 0x000EE920
	public void Item_Drop(Message msg)
	{
		try
		{
			mVector mVector = new mVector();
			sbyte b = msg.reader().readByte();
			for (int i = 0; i < (int)b; i++)
			{
				short id = msg.reader().readShort();
				sbyte typeItem = msg.reader().readByte();
				short idIcon = msg.reader().readShort();
				sbyte colorName = msg.reader().readByte();
				string name = msg.reader().readUTF();
				mVector.addElement(new MainItem(typeItem, id, idIcon, name, 0)
				{
					colorName = colorName
				});
			}
			short id2 = msg.reader().readShort();
			sbyte tem = msg.reader().readByte();
			short id3 = msg.reader().readShort();
			int num = 456;
			int num2 = 240;
			MainObject mainObject = MainObject.get_Object((int)id2, tem);
			bool flag = mainObject != null;
			if (flag)
			{
				num = mainObject.x;
				num2 = mainObject.y;
			}
			else
			{
				MainObject mainObject2 = MainObject.get_Object((int)id3, 0);
				bool flag2 = mainObject2 != null;
				if (flag2)
				{
					num = mainObject2.x;
					num2 = mainObject2.y;
				}
			}
			bool flag3 = mVector.size() <= 3;
			if (flag3)
			{
				for (int j = 0; j < mVector.size(); j++)
				{
					MainItem mainItem = (MainItem)mVector.elementAt(j);
					Item_Drop obj = new Item_Drop(mainItem.ID, mainItem.typeObject, mainItem.name, num, num2, mainItem.idIcon, mainItem.colorName);
					GameScreen.addPlayer(obj);
				}
			}
			else
			{
				int num3 = 40;
				int num4 = 45;
				int num5 = CRes.random(num4);
				for (int k = 0; k < mVector.size(); k++)
				{
					int num6 = k;
					int num7 = num6;
					if (num7 != 8)
					{
						if (num7 != 20)
						{
							if (num7 == 36)
							{
								num3 = 100;
								num4 = 15;
								num5 = CRes.random(num4);
							}
						}
						else
						{
							num3 = 80;
							num4 = 22;
							num5 = CRes.random(num4);
						}
					}
					else
					{
						num3 = 60;
						num4 = 30;
						num5 = CRes.random(num4);
					}
					int xto = num + CRes.getcos(CRes.fixangle(num5)) * num3 / 1000;
					int yto = num2 + CRes.getsin(CRes.fixangle(num5)) * num3 / 1000;
					MainItem mainItem2 = (MainItem)mVector.elementAt(k);
					Item_Drop obj2 = new Item_Drop(mainItem2.ID, mainItem2.typeObject, mainItem2.name, num, num2, mainItem2.idIcon, mainItem2.colorName, xto, yto);
					GameScreen.addPlayer(obj2);
					num5 += num4;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C87 RID: 3207 RVA: 0x000F09F4 File Offset: 0x000EEBF4
	public void GetItemMap(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			sbyte b = msg.reader().readByte();
			short id2 = msg.reader().readShort();
			Item_Drop item_Drop = (Item_Drop)MainObject.get_Object((int)id, b);
			bool flag = item_Drop == null || item_Drop.returnAction();
			if (!flag)
			{
				MainObject mainObject = MainObject.get_Object((int)id2, 0);
				bool flag2 = mainObject != null && !mainObject.returnAction();
				if (flag2)
				{
					bool flag3 = mainObject == GameScreen.player;
					if (flag3)
					{
						bool flag4 = GameScreen.indexHelp == 9;
						if (flag4)
						{
							MainHelp.setNextHelp(false);
						}
						MainHelp.checkRemoveIndexHelp(8);
					}
					bool flag5 = !GameCanvas.lowGraphic || mainObject == GameScreen.player;
					if (flag5)
					{
						bool flag6 = item_Drop.typeObject == 4 && item_Drop.colorName == 5;
						if (flag6)
						{
							GameScreen.addEffectNumImage(item_Drop.name, mainObject.x, mainObject.y - mainObject.hOne / 2, 10, AvMain.fraMoney, 0);
						}
						else
						{
							bool flag7 = (item_Drop.typeObject == 3 || item_Drop.typeObject == 4) && item_Drop.colorName > 0;
							if (flag7)
							{
								GameScreen.addEffectNum(item_Drop.name, mainObject.x, mainObject.y - mainObject.hOne / 2, -item_Drop.colorName);
							}
							else
							{
								GameScreen.addEffectNum(item_Drop.name, mainObject.x, mainObject.y - mainObject.hOne / 2, 5);
							}
						}
					}
					item_Drop.objMainFocus = mainObject;
					bool flag8 = mainObject == GameScreen.player && b == 5;
					if (flag8)
					{
						MainQuest.updateDataQuestGetPotion(item_Drop.IdIcon);
					}
				}
				else
				{
					item_Drop.isRemove = true;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C88 RID: 3208 RVA: 0x000F0BE0 File Offset: 0x000EEDE0
	public void GetItemMapLittle(Message msg)
	{
		try
		{
			bool flag = LoadMap.specMap != 7;
			if (!flag)
			{
				short id = msg.reader().readShort();
				sbyte tem = msg.reader().readByte();
				sbyte b = msg.reader().readByte();
				Item_Drop item_Drop = (Item_Drop)MainObject.get_Object((int)id, tem);
				bool flag2 = item_Drop == null || item_Drop.returnAction();
				if (!flag2)
				{
					BigBossLittleGraden bigBossLittleGraden = null;
					for (int i = 0; i < GameScreen.vecBigBossLittleGraden.size(); i++)
					{
						BigBossLittleGraden bigBossLittleGraden2 = (BigBossLittleGraden)GameScreen.vecBigBossLittleGraden.elementAt(i);
						bool flag3 = bigBossLittleGraden2.type == (int)b;
						if (flag3)
						{
							bigBossLittleGraden = bigBossLittleGraden2;
							break;
						}
					}
					bool flag4 = bigBossLittleGraden != null;
					if (flag4)
					{
						item_Drop.bossLittle = bigBossLittleGraden;
					}
					else
					{
						item_Drop.isRemove = true;
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C89 RID: 3209 RVA: 0x000F0CD4 File Offset: 0x000EEED4
	public void remove_Obj(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			sbyte tem = msg.reader().readByte();
			MainObject mainObject = MainObject.get_Object((int)id, tem);
			bool flag = mainObject != GameScreen.player && mainObject != null && !mainObject.isRemove;
			if (flag)
			{
				mainObject.isRemove = true;
				mainObject.timeEffRemoveChar = 2;
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C8A RID: 3210 RVA: 0x000F0D48 File Offset: 0x000EEF48
	public void update_InVen_Or_Chest(Message msg, mVector vec, sbyte typeInvenOrChest)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			sbyte b2 = msg.reader().readByte();
			mSystem.outz(string.Concat(new string[]
			{
				"typeAction=",
				b.ToString(),
				" typeInven",
				b2.ToString(),
				"  typechest=",
				typeInvenOrChest.ToString()
			}));
			bool flag = b == 0;
			if (flag)
			{
				MainItem.removeUpdateItemVec(b2, vec);
				sbyte b3 = msg.reader().readByte();
				bool flag2 = b2 == 4 || b2 == 8;
				if (flag2)
				{
					for (int i = 0; i < (int)b3; i++)
					{
						Potion potion = this.readUpdatePotion(msg, false, b2);
						bool flag3 = potion != null;
						if (flag3)
						{
							vec.addElement(potion);
						}
					}
				}
				else
				{
					bool flag4 = b2 == 3;
					if (flag4)
					{
						for (int j = 0; j < (int)b3; j++)
						{
							Item item = this.readUpdateItem(msg, false);
							bool flag5 = item != null;
							if (flag5)
							{
								vec.addElement(item);
							}
						}
					}
					else
					{
						bool flag6 = b2 == 5;
						if (flag6)
						{
							for (int k = 0; k < (int)b3; k++)
							{
								Quest_Potion quest_Potion = this.readUpdateQuestPotion(msg);
								bool flag7 = quest_Potion != null;
								if (flag7)
								{
									vec.addElement(quest_Potion);
								}
							}
						}
						else
						{
							bool flag8 = b2 == 7;
							if (flag8)
							{
								for (int l = 0; l < (int)b3; l++)
								{
									MainMaterial mainMaterial = this.readUpdateMaterial(msg, false);
									bool flag9 = mainMaterial != null;
									if (flag9)
									{
										vec.addElement(mainMaterial);
									}
								}
							}
						}
					}
				}
			}
			else
			{
				bool flag10 = b == 1;
				if (flag10)
				{
					bool flag11 = b2 == 4 || b2 == 8;
					if (flag11)
					{
						Potion potion2 = this.readUpdatePotion(msg, false, b2);
						bool flag12 = potion2 == null;
						if (flag12)
						{
							return;
						}
						MainItem itemVec = MainItem.getItemVec(b2, potion2.ID, vec);
						bool flag13 = itemVec == null;
						if (flag13)
						{
							vec.addElement(potion2);
						}
						else
						{
							vec.setElementAt(potion2, vec.indexOf(itemVec));
						}
					}
					else
					{
						bool flag14 = b2 == 3;
						if (flag14)
						{
							Item item2 = this.readUpdateItem(msg, false);
							bool flag15 = item2 == null;
							if (flag15)
							{
								return;
							}
							MainItem itemVec2 = MainItem.getItemVec(b2, item2.ID, vec);
							bool flag16 = itemVec2 == null;
							if (flag16)
							{
								vec.addElement(item2);
							}
							else
							{
								vec.setElementAt(item2, vec.indexOf(itemVec2));
							}
						}
						else
						{
							bool flag17 = b2 == 5;
							if (flag17)
							{
								Quest_Potion quest_Potion2 = this.readUpdateQuestPotion(msg);
								bool flag18 = quest_Potion2 == null;
								if (flag18)
								{
									return;
								}
								MainItem itemVec3 = MainItem.getItemVec(b2, quest_Potion2.ID, vec);
								bool flag19 = itemVec3 == null;
								if (flag19)
								{
									vec.addElement(quest_Potion2);
								}
								else
								{
									vec.setElementAt(quest_Potion2, vec.indexOf(itemVec3));
								}
							}
							else
							{
								bool flag20 = b2 == 7;
								if (flag20)
								{
									MainMaterial mainMaterial2 = this.readUpdateMaterial(msg, false);
									bool flag21 = mainMaterial2 == null;
									if (flag21)
									{
										return;
									}
									MainItem itemVec4 = MainItem.getItemVec(b2, mainMaterial2.ID, vec);
									bool flag22 = itemVec4 == null;
									if (flag22)
									{
										vec.addElement(mainMaterial2);
									}
									else
									{
										vec.setElementAt(mainMaterial2, vec.indexOf(itemVec4));
									}
								}
							}
						}
					}
					MainTabShop.isSortInven = true;
				}
				else
				{
					bool flag23 = b == 2;
					if (flag23)
					{
						short num = msg.reader().readShort();
						MainItem itemVec5 = MainItem.getItemVec(b2, num, vec);
						bool flag24 = itemVec5 != null;
						if (flag24)
						{
							itemVec5.numPotion = 0;
							itemVec5.isRemove = true;
							vec.removeElement(itemVec5);
						}
						bool flag25 = typeInvenOrChest == 100 && b2 == 4;
						if (flag25)
						{
							for (int m = 0; m < Player.hotkeyPlayer.Length; m++)
							{
								for (int n = 0; n < Player.hotkeyPlayer[m].Length; n++)
								{
									Hotkey hotkey = Player.hotkeyPlayer[m][n];
									bool flag26 = hotkey.itemcur != null && hotkey.itemcur.ID == num;
									if (flag26)
									{
										hotkey.itemcur = null;
									}
								}
							}
						}
						bool flag27 = GameCanvas.currentScreen == GameCanvas.tabAllScr;
						if (flag27)
						{
							GameCanvas.tabInven.getItemCurNew();
						}
					}
					else
					{
						bool flag28 = b == 3;
						if (flag28)
						{
							long num2 = msg.reader().readLong();
							int num3 = msg.reader().readInt();
							bool flag29 = typeInvenOrChest == 100;
							if (flag29)
							{
								bool flag30 = false;
								short ticket = msg.reader().readShort();
								this.updateMoney(num2, num3, ticket);
								GameScreen.player.beli = num2;
								GameScreen.player.gem = num3;
								Player.ticket = ticket;
								Player.maxTicket = msg.reader().readShort();
								sbyte b4 = msg.reader().readByte();
								bool flag31 = (short)b4 != Player.PvPticket;
								if (flag31)
								{
									flag30 = true;
								}
								Player.maxPvPticket = (short)msg.reader().readByte();
								Player.PvPticket = (short)b4;
								sbyte b5 = msg.reader().readByte();
								bool flag32 = (short)b5 != Player.keyBoss;
								if (flag32)
								{
									flag30 = true;
								}
								Player.keyBoss = (short)b5;
								Player.maxKeyboss = (short)msg.reader().readByte();
								bool flag33 = flag30;
								if (flag33)
								{
									Interface_Game.tickeffShowMoney = 40;
									Interface_Game.typeShowMoney = 1;
								}
							}
							else
							{
								bool flag34 = typeInvenOrChest == 99;
								if (flag34)
								{
									Player.Chestbeli = num2;
									Player.Chestgem = num3;
								}
							}
							int num4 = msg.reader().readInt();
							bool flag35 = num4 != GameScreen.player.vnd && GameCanvas.tabMarketScr != null && GameCanvas.currentScreen == GameCanvas.tabMarketScr;
							if (flag35)
							{
								string content = string.Empty;
								content = ((GameScreen.player.vnd <= num4) ? ("+" + (num4 - GameScreen.player.vnd).ToString()) : ("-" + (GameScreen.player.vnd - num4).ToString()));
								TabScreen.addEffectNumImage(content, MainTab.xMoney - 20, MainTab.yMoney + 36, 10, AvMain.fraMoney, 7);
							}
							GameScreen.player.vnd = num4;
							int num5 = msg.reader().readInt();
							bool flag36 = num5 != GameScreen.player.bua && GameCanvas.currentScreen == AuctionScreen.instance;
							if (flag36)
							{
								string content2 = string.Empty;
								content2 = ((GameScreen.player.bua <= num5) ? ("+" + (num5 - GameScreen.player.bua).ToString()) : ("-" + (GameScreen.player.bua - num5).ToString()));
								AuctionScreen.addEffectNumImage(content2, MainTab.xMoney - 10, MainTab.yMoney + 36, 10, AvMain.fraMoney, 8);
							}
							GameScreen.player.bua = num5;
							int num6 = msg.reader().readInt();
							bool flag37 = num6 != GameScreen.player.diemNap && GameCanvas.currentScreen == AuctionScreen.instance;
							if (flag37)
							{
								string text = string.Empty;
								text = ((GameScreen.player.diemNap <= num6) ? ("+" + (num6 - GameScreen.player.diemNap).ToString()) : ("-" + (GameScreen.player.diemNap - num6).ToString()));
								mSystem.outz("Add effect num diemNap " + text);
								TabScreen.addEffectNumImage(text, MainTab.xMoney - 20, MainTab.yMoney + 36, 10, AvMain.fraMoney, 9);
							}
							GameScreen.player.diemNap = num6;
						}
						else
						{
							bool flag38 = b == 6;
							if (flag38)
							{
								bool flag39 = typeInvenOrChest == 100;
								if (flag39)
								{
									Player.maxInventory = (int)msg.reader().readShort();
									GameCanvas.tabAllScr.tabCurrent.resize(Player.maxInventory);
								}
								else
								{
									bool flag40 = typeInvenOrChest == 99;
									if (flag40)
									{
										Player.maxChest = (int)msg.reader().readShort();
										bool flag41 = GameCanvas.currentScreen == GameCanvas.tabShopScr;
										if (flag41)
										{
											for (int num7 = 0; num7 < GameCanvas.tabShopScr.vecTabs.size(); num7++)
											{
												MainTab mainTab = (MainTab)GameCanvas.tabShopScr.vecTabs.elementAt(num7);
												bool flag42 = mainTab.indexIconTab == 7;
												if (flag42)
												{
													mainTab.maxSize = Player.maxChest;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			TabScreen.isRefresh = true;
			bool flag43 = typeInvenOrChest == 100 && Player.isFullInven;
			if (flag43)
			{
				int num8 = Player.vecInventory.size();
				bool flag44 = num8 < Player.maxInventory;
				if (flag44)
				{
					Player.isFullInven = false;
				}
			}
			bool flag45 = MainTabShop.isSortInven && (GameCanvas.currentScreen == GameCanvas.tabAllScr || GameCanvas.currentScreen == GameCanvas.tabShopScr);
			if (flag45)
			{
				vec = MainItem.SortVecItem(vec);
				MainTabShop.isSortInven = false;
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C8B RID: 3211 RVA: 0x000F169C File Offset: 0x000EF89C
	public void updateMoney(long xu, int luong, short ticket)
	{
		string content = string.Empty;
		bool flag = GameScreen.player.beli != xu;
		if (flag)
		{
			content = ((GameScreen.player.beli <= xu) ? ("+" + (xu - GameScreen.player.beli).ToString()) : ("-" + (GameScreen.player.beli - xu).ToString()));
			bool flag2 = GameCanvas.currentScreen == GameCanvas.tabAllScr || GameCanvas.currentScreen == GameCanvas.tabShopScr;
			if (flag2)
			{
				TabScreen.addEffectNumImage(content, MainTab.xMoney - 20, MainTab.yMoney + 10, 10, AvMain.fraMoney, 0);
			}
			else
			{
				bool flag3 = GameCanvas.currentScreen == GameCanvas.gameScr;
				if (flag3)
				{
					GameScreen.addEffectNumImage(content, GameScreen.player.x, GameScreen.player.y - GameScreen.player.hOne, 10, AvMain.fraMoney, 0);
				}
			}
		}
		bool flag4 = GameScreen.player.gem != luong;
		if (flag4)
		{
			content = ((GameScreen.player.gem <= luong) ? ("+" + (luong - GameScreen.player.gem).ToString()) : ("-" + (GameScreen.player.gem - luong).ToString()));
			bool flag5 = GameCanvas.currentScreen == GameCanvas.tabAllScr || GameCanvas.currentScreen == GameCanvas.tabShopScr;
			if (flag5)
			{
				TabScreen.addEffectNumImage(content, MainTab.xMoney - 20, MainTab.yMoney + 23, 10, AvMain.fraMoney, 1);
			}
			else
			{
				bool flag6 = GameCanvas.currentScreen == GameCanvas.gameScr;
				if (flag6)
				{
					GameScreen.addEffectNumImage(content, GameScreen.player.x, GameScreen.player.y - GameScreen.player.hOne, 10, AvMain.fraMoney, 1);
					Interface_Game.tickeffShowMoney = 40;
					Interface_Game.typeShowMoney = 0;
				}
				else
				{
					bool flag7 = GameCanvas.currentScreen == QuayOcSenScreen.instance;
					if (flag7)
					{
						QuayOcSenScreen.instance.addEffectNumImage(content, MainTab.xMoney - 10, MainTab.yMoney + 36, 10, AvMain.fraMoney, 1);
					}
				}
			}
		}
		bool flag8 = Player.ticket > ticket && GameCanvas.currentScreen == GameCanvas.gameScr;
		if (flag8)
		{
			GameScreen.addEffectNumImage("-" + ((int)(Player.ticket - ticket)).ToString(), GameScreen.player.x, GameScreen.player.y - GameScreen.player.hOne, 10, AvMain.fraMoney, 2);
			Interface_Game.tickeffShowMoney = 40;
			Interface_Game.typeShowMoney = 1;
		}
	}

	// Token: 0x06000C8C RID: 3212 RVA: 0x000F1948 File Offset: 0x000EFB48
	public Potion readUpdatePotion(Message msg, bool isShop, sbyte cat)
	{
		Potion potion = null;
		Potion result;
		try
		{
			short num = msg.reader().readShort();
			short num2 = msg.reader().readShort();
			Potion potion2 = null;
			bool flag = cat == 4;
			if (flag)
			{
				potion2 = Potion.getTemplatePotion(num);
			}
			bool flag2 = cat == 8;
			if (flag2)
			{
				potion2 = (Potion)MainItem.hashPotionClan.get(string.Empty + num.ToString());
			}
			potion = null;
			bool isUpdateTem = potion2.isUpdateTem;
			if (isUpdateTem)
			{
				potion = new Potion(cat, num, potion2.idIcon, potion2.name, potion2.isTrade);
				potion.setdata(potion2.price, potion2.priceRuby, potion2.value, potion2.timeActive, potion2.timeDelayPotion, potion2.Hp_Mp_Other, potion2.nameUse);
				potion.numPotion = num2;
				potion.isShop = isShop;
				bool flag3 = cat == 8;
				if (flag3)
				{
					potion.info = potion2.info;
				}
				bool flag4 = !potion.getInfoPotion(potion2.indexInfoPotion);
				if (flag4)
				{
					Potion.vecPotionDonotInfo.addElement(potion);
				}
			}
			else
			{
				potion = new Potion(cat, num, num2, isShop);
				Potion.vecPotionDonotData.addElement(potion);
			}
			bool flag5 = num == 232;
			if (flag5)
			{
				LuckyScreen.isUpdateVe = true;
			}
			bool flag6 = num == 441;
			if (flag6)
			{
				LuckyScreen.isUpdateVe = true;
			}
			Hotkey.checkUpdatePotion(potion);
			result = potion;
		}
		catch (Exception)
		{
			result = potion;
		}
		return result;
	}

	// Token: 0x06000C8D RID: 3213 RVA: 0x000F1AD4 File Offset: 0x000EFCD4
	public ItemBoat readUpdateItemBoat(Message msg)
	{
		ItemBoat itemBoat = null;
		ItemBoat result;
		try
		{
			sbyte id = msg.reader().readByte();
			string name = msg.reader().readUTF();
			sbyte type = msg.reader().readByte();
			short idImage = msg.reader().readShort();
			short idicon = msg.reader().readShort();
			itemBoat = new ItemBoat((short)id, idicon, idImage, name, type);
			result = itemBoat;
		}
		catch (Exception)
		{
			result = itemBoat;
		}
		return result;
	}

	// Token: 0x06000C8E RID: 3214 RVA: 0x000F1B50 File Offset: 0x000EFD50
	public ItemHair readUpdateItemHair(Message msg, sbyte typeObj)
	{
		ItemHair itemHair = null;
		ItemHair result;
		try
		{
			sbyte id = msg.reader().readByte();
			string name = msg.reader().readUTF();
			sbyte b = msg.reader().readByte();
			short idicon = msg.reader().readShort();
			short num = msg.reader().readShort();
			itemHair = new ItemHair((short)id, idicon, name, typeObj);
			result = itemHair;
		}
		catch (Exception)
		{
			result = itemHair;
		}
		return result;
	}

	// Token: 0x06000C8F RID: 3215 RVA: 0x000F1BC8 File Offset: 0x000EFDC8
	public ItemFashion readUpdateItemFashion(Message msg)
	{
		ItemFashion itemFashion = null;
		ItemFashion result;
		try
		{
			sbyte id = msg.reader().readByte();
			string name = msg.reader().readUTF();
			string info = msg.reader().readUTF();
			short idicon = msg.reader().readShort();
			sbyte b = msg.reader().readByte();
			short[] array = new short[(int)b];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = msg.reader().readShort();
			}
			itemFashion = new ItemFashion((short)id, idicon, name, info, array);
			itemFashion.isShop = true;
			itemFashion.setInfoPotion(itemFashion.info);
			result = itemFashion;
		}
		catch (Exception)
		{
			result = itemFashion;
		}
		return result;
	}

	// Token: 0x06000C90 RID: 3216 RVA: 0x000F1C8C File Offset: 0x000EFE8C
	public MainMaterial readUpdateMaterial(Message msg, bool isShop)
	{
		MainMaterial mainMaterial = null;
		MainMaterial result;
		try
		{
			sbyte id = msg.reader().readByte();
			short num = msg.reader().readShort();
			MainMaterial mainMaterial2 = (MainMaterial)MainItem.hashMaterialTem.get(string.Empty + id.ToString());
			mainMaterial = new MainMaterial(7, id, mainMaterial2.name, mainMaterial2.typeMaterial, (sbyte)mainMaterial2.idIcon, num, mainMaterial2.price, mainMaterial2.priceRuby, mainMaterial2.isTrade);
			mainMaterial.isShop = isShop;
			mainMaterial.setInfoPotion(mainMaterial2.info);
			result = mainMaterial;
		}
		catch (Exception)
		{
			result = mainMaterial;
		}
		return result;
	}

	// Token: 0x06000C91 RID: 3217 RVA: 0x000F1D38 File Offset: 0x000EFF38
	public Item readUpdateItem(Message msg, bool isShop)
	{
		Item item = null;
		Item result;
		try
		{
			short num = msg.reader().readShort();
			string name = msg.reader().readUTF();
			sbyte charClass = msg.reader().readByte();
			sbyte typeEquip = msg.reader().readByte();
			short idIcon = msg.reader().readShort();
			short lv = msg.reader().readShort();
			sbyte lvUp = msg.reader().readByte();
			sbyte colorName = msg.reader().readByte();
			sbyte isTrade = msg.reader().readByte();
			sbyte typelock = msg.reader().readByte();
			sbyte numHoleDaDuc = msg.reader().readByte();
			int timeUse = msg.reader().readInt();
			short valueChetac = msg.reader().readShort();
			sbyte isHoanMy = msg.reader().readByte();
			sbyte valueKichAn = msg.reader().readByte();
			sbyte b = msg.reader().readByte();
			MainInfoItem[] array = new MainInfoItem[(int)b];
			for (int i = 0; i < (int)b; i++)
			{
				sbyte id = msg.reader().readByte();
				short value = msg.reader().readShort();
				array[i] = new MainInfoItem(id, (int)value);
				array[i].colorMain = infoShow.HARDCODE_INFO_CO_BAN;
			}
			sbyte b2 = msg.reader().readByte();
			MainInfoItem[] array2 = new MainInfoItem[(int)(b + b2)];
			for (int j = 0; j < (int)b; j++)
			{
				array2[j] = new MainInfoItem(array[j].id, array[j].value, array[j].colorMain);
			}
			for (int k = 0; k < (int)b2; k++)
			{
				sbyte b3 = msg.reader().readByte();
				short value2 = msg.reader().readShort();
				array2[k + (int)b] = new MainInfoItem(b3, (int)value2);
				bool flag = MainItem.mNameAttributes[(int)b3].color != 0;
				if (flag)
				{
					array2[k + (int)b].colorMain = MainItem.mNameAttributes[(int)b3].color;
				}
				else
				{
					array2[k + (int)b].colorMain = 4;
				}
			}
			sbyte numLoKham = msg.reader().readByte();
			sbyte b4 = msg.reader().readByte();
			short[] array3 = new short[(int)b4];
			for (int l = 0; l < (int)b4; l++)
			{
				array3[l] = msg.reader().readShort();
			}
			item = new Item(3, num, idIcon, name, isTrade);
			item.setDataItem(lv, charClass, colorName, timeUse, typeEquip, lvUp, numLoKham, array3, valueChetac, isHoanMy, valueKichAn);
			item.IDMarket = num;
			item.typelock = typelock;
			bool flag2 = item.typelock == 1;
			if (flag2)
			{
				item.isTrade = 1;
			}
			item.numHoleDaDuc = numHoleDaDuc;
			item.setInfoItem(array2, (int)b);
			result = item;
		}
		catch (Exception)
		{
			result = item;
		}
		return result;
	}

	// Token: 0x06000C92 RID: 3218 RVA: 0x000F2030 File Offset: 0x000F0230
	public Quest_Potion readUpdateQuestPotion(Message msg)
	{
		Quest_Potion quest_Potion = null;
		Quest_Potion result;
		try
		{
			short id = msg.reader().readShort();
			string name = msg.reader().readUTF();
			short numPotion = msg.reader().readShort();
			quest_Potion = new Quest_Potion(5, id, name);
			quest_Potion.numPotion = numPotion;
			quest_Potion.setInfoPotion(T.infoQuestPotion);
			result = quest_Potion;
		}
		catch (Exception)
		{
			result = quest_Potion;
		}
		return result;
	}

	// Token: 0x06000C93 RID: 3219 RVA: 0x0000BC37 File Offset: 0x00009E37
	public void update_Inventory(Message msg)
	{
		this.update_InVen_Or_Chest(msg, Player.vecInventory, 100);
	}

	// Token: 0x06000C94 RID: 3220 RVA: 0x000F20A0 File Offset: 0x000F02A0
	public void update_Chest(Message msg)
	{
		this.update_InVen_Or_Chest(msg, Player.vecChest, 99);
		mSystem.outz("update_Chest size vec = " + Player.vecChest.size().ToString());
	}

	// Token: 0x06000C95 RID: 3221 RVA: 0x0000BC49 File Offset: 0x00009E49
	public void update_Inven_Clan(Message msg)
	{
		this.update_InVen_Or_Chest(msg, Player.vecInvenClan, 110);
	}

	// Token: 0x06000C96 RID: 3222 RVA: 0x000F20E0 File Offset: 0x000F02E0
	public void use_Potion(Message msg)
	{
		try
		{
			short num = msg.reader().readShort();
			MainItem itemVec = MainItem.getItemVec(4, num, Player.vecInventory);
			bool flag = itemVec == null;
			if (!flag)
			{
				short num2 = itemVec.numPotion = msg.reader().readShort();
				bool flag2 = itemVec.Hp_Mp_Other == 1 || itemVec.Hp_Mp_Other == 2;
				if (flag2)
				{
					GameScreen.interfaceGame.addEffCurrent(itemVec);
				}
				bool flag3 = num2 > 0;
				if (!flag3)
				{
					GameScreen.player.hpPoi = null;
					GameScreen.player.mpPoi = null;
					Player.vecInventory.removeElement(itemVec);
					bool isFullInven = Player.isFullInven;
					if (isFullInven)
					{
						int num3 = Player.vecInventory.size();
						bool flag4 = num3 < Player.maxInventory;
						if (flag4)
						{
							Player.isFullInven = false;
						}
					}
					for (int i = 0; i < Player.hotkeyPlayer.Length; i++)
					{
						for (int j = 0; j < Player.hotkeyPlayer[i].Length; j++)
						{
							Hotkey hotkey = Player.hotkeyPlayer[i][j];
							bool flag5 = hotkey.itemcur != null && hotkey.itemcur.ID == num;
							if (flag5)
							{
								hotkey.itemcur = null;
							}
						}
					}
					bool flag6 = GameCanvas.currentScreen == GameCanvas.tabAllScr;
					if (flag6)
					{
						GameCanvas.tabInven.getItemCurNew();
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C97 RID: 3223 RVA: 0x000F2274 File Offset: 0x000F0474
	public void update_MP_HP(Message msg)
	{
		try
		{
			short num = msg.reader().readShort();
			sbyte b = msg.reader().readByte();
			MainObject mainObject = MainObject.get_Object((int)num, b);
			bool flag = mainObject == null || mainObject.returnAction();
			if (!flag)
			{
				mainObject.maxHp = msg.reader().readInt();
				int hp = msg.reader().readInt();
				int num2 = msg.reader().readInt();
				bool flag2 = num2 != 0;
				if (flag2)
				{
					string content = string.Empty + num2.ToString();
					bool flag3 = num2 > 0;
					if (flag3)
					{
						content = "+" + num2.ToString();
					}
					bool flag4 = mainObject == GameScreen.player;
					if (flag4)
					{
						GameScreen.addEffectNum(content, mainObject.x - 12, mainObject.y - mainObject.hOne / 4 * 3 - this.lechYNum, 3);
					}
				}
				mainObject.Hp = hp;
				bool flag5 = mainObject.Action == 4 && mainObject.Hp > 0;
				if (flag5)
				{
					mainObject.Reveive();
				}
				bool flag6 = b == 0;
				if (flag6)
				{
					for (int i = 0; i < Player.vecParty.size(); i++)
					{
						InfoMemList infoMemList = (InfoMemList)Player.vecParty.elementAt(i);
						bool flag7 = infoMemList.id == (int)num && b == 0;
						if (flag7)
						{
							infoMemList.updateHP(hp, mainObject.maxHp, mainObject.Lv);
						}
					}
				}
				bool flag8 = b != 1;
				if (flag8)
				{
					mainObject.maxMp = msg.reader().readInt();
					int mp = msg.reader().readInt();
					int num3 = msg.reader().readInt();
					bool flag9 = num3 != 0;
					if (flag9)
					{
						string content2 = string.Empty + num3.ToString();
						bool flag10 = num3 > 0;
						if (flag10)
						{
							content2 = "+" + num3.ToString();
						}
						bool flag11 = mainObject == GameScreen.player;
						if (flag11)
						{
							GameScreen.addEffectNum(content2, mainObject.x + 12, mainObject.y - mainObject.hOne / 4 * 3 - this.lechYNum, 4);
						}
					}
					mainObject.Mp = mp;
				}
				this.lechYNum += 10;
				bool flag12 = this.lechYNum > 20;
				if (flag12)
				{
					this.lechYNum = 0;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C98 RID: 3224 RVA: 0x000F2504 File Offset: 0x000F0704
	public void update_PK(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			sbyte b = msg.reader().readByte();
			sbyte typePirate = msg.reader().readByte();
			sbyte isDonotShowHat = msg.reader().readByte();
			MainObject mainObject = MainObject.get_Object((int)id, 0);
			bool flag = mainObject == null || mainObject.returnAction();
			if (!flag)
			{
				sbyte typePK = mainObject.typePK;
				mainObject.typePK = b;
				mainObject.typePirate = typePirate;
				mainObject.isDonotShowHat = isDonotShowHat;
				bool flag2 = mainObject == GameScreen.player;
				if (flag2)
				{
					GameCanvas.gameScr.cmdSetDosat.caption = T.Dosat;
					bool flag3 = b == 0;
					if (flag3)
					{
						GameCanvas.gameScr.cmdSetDosat.caption = T.tatDosat;
					}
					bool flag4 = LoadMap.specMap == 1;
					if (flag4)
					{
						GlobalService.gI().Set_PK(b, 1);
					}
					bool flag5 = typePK == 0;
					if (flag5)
					{
						Interface_Game.addInfoPlayerNormal(T.tatdosat, mFont.tahoma_7_yellow);
					}
					else
					{
						bool flag6 = b == 0;
						if (flag6)
						{
							Interface_Game.addInfoPlayerNormal(T.batdosat, mFont.tahoma_7_yellow);
						}
					}
				}
				short num = msg.reader().readShort();
				sbyte b2 = mainObject.isDonotShowWeaponF = msg.reader().readByte();
				b2 = (mainObject.typeColor7 = msg.reader().readByte());
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C99 RID: 3225 RVA: 0x000F268C File Offset: 0x000F088C
	public void update_List_Pk(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			Player.msattam = new short[(int)b];
			for (int i = 0; i < (int)b; i++)
			{
				Player.msattam[i] = msg.reader().readShort();
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C9A RID: 3226 RVA: 0x000F26F0 File Offset: 0x000F08F0
	public void Effect_Obj(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			short id = msg.reader().readShort();
			sbyte b2 = msg.reader().readByte();
			short num = msg.reader().readShort();
			MainObject mainObject = MainObject.get_Object((int)id, b2);
			bool flag = (mainObject == null || mainObject.returnAction()) && b < 16 && b > 18;
			if (!flag)
			{
				switch (b)
				{
				case 0:
				{
					bool flag2 = mainObject == GameScreen.player;
					if (flag2)
					{
						this.setHelp();
						this.setUpLv();
					}
					GameScreen.addEffectEnd_ObjTo(28, 0, mainObject.x, mainObject.y, mainObject.ID, mainObject.typeObject, (sbyte)mainObject.Dir, mainObject);
					break;
				}
				case 1:
				{
					bool flag3 = mainObject == GameScreen.player && (GameCanvas.currentScreen == GameCanvas.tabAllScr || GameCanvas.currentScreen == GameCanvas.tabShopScr);
					if (flag3)
					{
						GameCanvas.gameScr.Show();
					}
					mainObject.addEffBuff(3, 165, 0);
					break;
				}
				case 2:
				{
					short x = msg.reader().readShort() * 24;
					short y = msg.reader().readShort() * 24;
					mainObject.x = (int)x;
					mainObject.y = (int)y;
					mainObject.addEffBuff(3, 17, num);
					break;
				}
				case 3:
				{
					bool flag4 = mainObject != null;
					if (flag4)
					{
						GameScreen.addEffectEnd_ObjTo(46, 0, mainObject.x, mainObject.y, mainObject.ID, mainObject.typeObject, (sbyte)mainObject.Dir, mainObject);
					}
					break;
				}
				case 4:
				{
					short id2 = msg.reader().readShort();
					sbyte b3 = msg.reader().readByte();
					GameScreen.addEffectEnd_Time(96, 0, mainObject.x, mainObject.y, id2, b3, (sbyte)mainObject.Dir, mainObject, (int)num);
					break;
				}
				case 5:
				{
					short id2 = msg.reader().readShort();
					sbyte b3 = msg.reader().readByte();
					GameScreen.addEffectEnd_Time(97, 0, mainObject.x, mainObject.y, id2, b3, (sbyte)mainObject.Dir, mainObject, (int)num);
					break;
				}
				case 6:
				{
					short id2 = msg.reader().readShort();
					sbyte b3 = msg.reader().readByte();
					MainObject mainObject2 = MainObject.get_Object((int)id2, b3);
					bool flag5 = mainObject2 != null;
					if (flag5)
					{
						GameScreen.addEffectEnd_ObjTo(101, 0, mainObject2.x, mainObject2.y, mainObject2.ID, mainObject2.typeObject, 0, mainObject);
					}
					mainObject.setPetActionFire();
					break;
				}
				case 7:
					GameScreen.addEffectEnd_ObjTo(101, 0, mainObject.x, mainObject.y, mainObject.ID, mainObject.typeObject, 0, mainObject);
					break;
				case 8:
				{
					sbyte subType = msg.reader().readByte();
					GameScreen.addEffectEnd_ObjTo(104, (int)subType, mainObject.x, mainObject.y, mainObject.ID, mainObject.typeObject, 0, mainObject);
					break;
				}
				case 9:
				{
					sbyte subType2 = msg.reader().readByte();
					GameScreen.addEffectEnd_ObjTo(105, (int)subType2, mainObject.x, mainObject.y, mainObject.ID, mainObject.typeObject, 0, mainObject);
					break;
				}
				case 10:
					GameScreen.addEffectEnd_ObjTo(106, 0, mainObject.x, mainObject.y, mainObject.ID, mainObject.typeObject, 0, mainObject);
					break;
				case 11:
					GameScreen.addEffectEnd(115, 0, mainObject.x, mainObject.y, 0, 0, mainObject);
					break;
				case 12:
				{
					short id2 = msg.reader().readShort();
					sbyte b3 = msg.reader().readByte();
					short num2 = msg.reader().readShort();
					int subType3 = 0;
					short num3 = num2;
					short num4 = num3;
					if (num4 <= 193)
					{
						switch (num4)
						{
						case 180:
							subType3 = 0;
							break;
						case 181:
							subType3 = 1;
							break;
						case 182:
							subType3 = 2;
							break;
						default:
							if (num4 == 193)
							{
								subType3 = 3;
							}
							break;
						}
					}
					else
					{
						switch (num4)
						{
						case 233:
							subType3 = 4;
							break;
						case 234:
							subType3 = 5;
							break;
						case 235:
							subType3 = 6;
							break;
						default:
							if (num4 != 577)
							{
								if (num4 == 611)
								{
									subType3 = 24;
								}
							}
							else
							{
								subType3 = 7;
							}
							break;
						}
					}
					mSystem.outz("con song >>>" + num2.ToString() + " frame " + subType3.ToString());
					GameScreen.addEffectEnd_ObjTo(127, subType3, mainObject.x, mainObject.y, id2, b3, 0, mainObject);
					break;
				}
				case 13:
				{
					short id2 = msg.reader().readShort();
					sbyte b3 = msg.reader().readByte();
					short num5 = msg.reader().readShort();
					int subType4 = 10;
					short num6 = num5;
					short num7 = num6;
					if (num7 <= 193)
					{
						switch (num7)
						{
						case 180:
							subType4 = 10;
							break;
						case 181:
							subType4 = 11;
							break;
						case 182:
							subType4 = 12;
							break;
						default:
							if (num7 == 193)
							{
								subType4 = 13;
							}
							break;
						}
					}
					else
					{
						switch (num7)
						{
						case 233:
							subType4 = 14;
							break;
						case 234:
							subType4 = 15;
							break;
						case 235:
							subType4 = 16;
							break;
						default:
							if (num7 != 577)
							{
								if (num7 == 611)
								{
									subType4 = 24;
								}
							}
							else
							{
								subType4 = 17;
							}
							break;
						}
					}
					mSystem.outz("con song fali >>>" + num5.ToString() + " frame " + subType4.ToString());
					GameScreen.addEffectEnd_ObjTo(127, subType4, mainObject.x, mainObject.y, id2, b3, 0, mainObject);
					break;
				}
				case 14:
					GameScreen.addEffectEnd_Time(130, 0, mainObject.x, mainObject.y, id, b2, 0, mainObject, (int)num);
					break;
				case 15:
					GameScreen.addEffectEnd_Time(131, 0, mainObject.x, mainObject.y, id, b2, 0, mainObject, (int)num);
					break;
				case 16:
				{
					mSystem.outz("readMessage Eff_choang");
					short num8 = msg.reader().readShort();
					for (int i = 0; i < GameScreen.vecPlayers.size(); i++)
					{
						MainObject mainObject3 = (MainObject)GameScreen.vecPlayers.elementAt(i);
						bool flag6 = mainObject3.typeObject == 0 && (mainObject3.clan == null || num8 != mainObject3.clan.ID);
						if (flag6)
						{
							mainObject3.addEffSpec(1, num);
							GameScreen.addEffectEnd_Time(149, 0, mainObject3.x, mainObject3.y, mainObject3.ID, mainObject3.typeObject, 0, mainObject3, (int)num);
						}
					}
					break;
				}
				case 17:
				{
					short num8 = msg.reader().readShort();
					for (int j = 0; j < GameScreen.vecPlayers.size(); j++)
					{
						MainObject mainObject4 = (MainObject)GameScreen.vecPlayers.elementAt(j);
						bool flag7 = mainObject4.typeObject == 0 && (mainObject4.clan == null || mainObject4.clan.ID != num8);
						if (flag7)
						{
							GameScreen.addEffectEnd_Time(151, 0, mainObject4.x, mainObject4.y, mainObject4.ID, mainObject4.typeObject, 0, mainObject4, (int)num);
							GameScreen.addEffectEnd_Time(150, 0, mainObject4.x, mainObject4.y, mainObject4.ID, mainObject4.typeObject, 0, mainObject4, (int)(num / 10));
						}
					}
					break;
				}
				case 18:
				{
					short num8 = msg.reader().readShort();
					for (int k = 0; k < GameScreen.vecPlayers.size(); k++)
					{
						MainObject mainObject5 = (MainObject)GameScreen.vecPlayers.elementAt(k);
						bool flag8 = mainObject5.typeObject == 0 && mainObject5.clan != null && mainObject5.clan.ID == num8;
						if (flag8)
						{
							GameScreen.addEffectEnd_Time(151, 1, mainObject5.x, mainObject5.y, mainObject5.ID, mainObject5.typeObject, 0, mainObject5, (int)num);
							mainObject5.addEffSpec(11, num);
						}
					}
					break;
				}
				case 19:
					GameScreen.addEffectEnd(80, 0, mainObject.x, mainObject.y - mainObject.hOne / 2, 0, null);
					GameScreen.addEffectEnd_Time(152, 0, mainObject.x, mainObject.y, id, b2, 0, mainObject, (int)(num / 10));
					break;
				case 20:
				{
					bool flag9 = GameCanvas.currentScreen == GameCanvas.tabAllScr || GameCanvas.currentScreen == GameCanvas.tabShopScr;
					if (flag9)
					{
						GameCanvas.gameScr.Show();
					}
					GameScreen.addEffectEnd_ObjTo(153, 0, mainObject.x, mainObject.y, mainObject.ID, mainObject.typeObject, 0, mainObject);
					break;
				}
				case 21:
					GameScreen.addEffectEnd_Time(156, 0, mainObject.x, mainObject.y, mainObject.ID, mainObject.typeObject, 0, mainObject, (int)num);
					break;
				case 22:
					GameScreen.addEffectEnd_ObjTo(159, 0, mainObject.x, mainObject.y, mainObject.ID, mainObject.typeObject, (sbyte)mainObject.Dir, mainObject);
					break;
				case 23:
				{
					bool flag10 = GameCanvas.currentScreen == GameCanvas.tabAllScr || GameCanvas.currentScreen == GameCanvas.tabShopScr;
					if (flag10)
					{
						GameCanvas.gameScr.Show();
					}
					GameScreen.addEffectEnd_ObjTo(158, 0, mainObject.x, mainObject.y, mainObject.ID, mainObject.typeObject, 0, mainObject);
					break;
				}
				case 24:
					GameScreen.addEffectEnd_ObjTo(162, 0, mainObject.x, mainObject.y - 2, mainObject.ID, mainObject.typeObject, 0, mainObject);
					break;
				case 25:
				{
					bool flag11 = GameCanvas.currentScreen == GameCanvas.tabAllScr || GameCanvas.currentScreen == GameCanvas.tabShopScr;
					if (flag11)
					{
						GameCanvas.gameScr.Show();
					}
					GameScreen.addEffectEnd_ObjTo(178, 0, mainObject.x, mainObject.y, mainObject.ID, mainObject.typeObject, 0, mainObject);
					break;
				}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C9B RID: 3227 RVA: 0x000F31B8 File Offset: 0x000F13B8
	private void setUpLv()
	{
		for (int i = 0; i < Player.vecInventory.size(); i++)
		{
			MainItem mainItem = (MainItem)Player.vecInventory.elementAt(i);
			bool flag = mainItem.typeObject != 3 || (int)mainItem.Lv_RQ != GameScreen.player.Lv;
			if (!flag)
			{
				for (int j = 0; j < mainItem.vecInfo.size(); j++)
				{
					infoShow infoShow = (infoShow)mainItem.vecInfo.elementAt(j);
					bool flag2 = infoShow.colorMain == infoShow.HARDCODE_CHECK_LVRQ;
					if (flag2)
					{
						infoShow.color = 4;
					}
				}
			}
		}
	}

	// Token: 0x06000C9C RID: 3228 RVA: 0x000F3274 File Offset: 0x000F1474
	private void setHelp()
	{
		bool flag = GameScreen.indexHelp == 13;
		if (flag)
		{
			GameScreen.addHelp(13, 0);
		}
		else
		{
			bool flag2 = GameScreen.player.Lv == 20;
			if (flag2)
			{
				GameScreen.addHelp(19, 0);
			}
		}
	}

	// Token: 0x06000C9D RID: 3229 RVA: 0x000F32BC File Offset: 0x000F14BC
	public void List_NPC(Message msg)
	{
		GameScreen.RemoveAllNPC();
		try
		{
			sbyte b = msg.reader().readByte();
			bool flag = false;
			for (int i = 0; i < (int)b; i++)
			{
				short iditem = msg.reader().readShort();
				string name = msg.reader().readUTF();
				string namegt = msg.reader().readUTF();
				string chatNPC = msg.reader().readUTF();
				short x = msg.reader().readShort();
				short y = msg.reader().readShort();
				sbyte b2 = msg.reader().readByte();
				sbyte typeIconNPC = msg.reader().readByte();
				sbyte wBlock = msg.reader().readByte();
				sbyte hBlock = msg.reader().readByte();
				sbyte b3 = msg.reader().readByte();
				NPC npc = new NPC(name, namegt, iditem, x, y, wBlock, hBlock, b3);
				npc.isPerson = b2;
				npc.chatNPC = chatNPC;
				npc.typeIconNPC = typeIconNPC;
				bool flag2 = b3 == 0;
				if (flag2)
				{
					sbyte idimage = msg.reader().readByte();
					sbyte nFrame = msg.reader().readByte();
					npc.setDataFrame(idimage, nFrame);
				}
				else
				{
					npc.sethead(msg.reader().readShort());
					npc.sethair(msg.reader().readShort());
					npc.hOne = 52;
					npc.wOne = 26;
					bool flag3 = LoadMap.specMap == 4;
					if (flag3)
					{
						npc.wOne = 100;
					}
					sbyte b4 = msg.reader().readByte();
					short[] array = new short[(int)b4];
					for (int j = 0; j < array.Length; j++)
					{
						array[j] = -1;
					}
					for (int k = 0; k < (int)b4; k++)
					{
						sbyte b5 = msg.reader().readByte();
						bool flag4 = b5 == 1;
						if (flag4)
						{
							array[k] = msg.reader().readShort();
						}
					}
					npc.setWearing(array);
				}
				npc.isRemove = false;
				npc.isInfo = true;
				GameScreen.addPlayer(npc);
				npc.setTypeQuest();
				bool flag5 = b2 == 98 && !flag;
				if (flag5)
				{
					GlobalService.gI().get_Info_Clan_Dao();
					flag = true;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C9E RID: 3230 RVA: 0x000F3530 File Offset: 0x000F1730
	public void Shop_IconClanVip(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			mSystem.outz("Shop huy hieu action = " + b.ToString());
			bool flag = b == 0;
			if (flag)
			{
				string name = msg.reader().readUTF();
				short num = msg.reader().readShort();
				mVector mVector = new mVector();
				for (int i = 0; i < (int)num; i++)
				{
					short id = msg.reader().readShort();
					string name2 = msg.reader().readUTF();
					string info = msg.reader().readUTF();
					short idImage = msg.reader().readShort();
					string text = msg.reader().readUTF();
					Potion potion = new Potion(id, idImage, name2, info, 0);
					sbyte b2 = msg.reader().readByte();
					for (int j = 0; j < (int)b2; j++)
					{
						sbyte id2 = msg.reader().readByte();
						short value = msg.reader().readShort();
						potion.addInfo((short)id2, (int)value, infoShow.HARDCODE_INFO_CO_BAN, 1);
					}
					bool flag2 = potion != null;
					if (flag2)
					{
						bool flag3 = text != string.Empty;
						if (flag3)
						{
							potion.addInfo(text, 5);
						}
						bool flag4 = potion.price > 0;
						if (flag4)
						{
							potion.addInfoFrist(string.Concat(new string[]
							{
								T.price,
								" ",
								potion.price.ToString(),
								" ",
								T.bery
							}), 5);
						}
						else
						{
							bool flag5 = potion.priceRuby > 0;
							if (flag5)
							{
								potion.addInfoFrist(string.Concat(new string[]
								{
									T.price,
									" ",
									potion.priceRuby.ToString(),
									" ",
									T.ruby
								}), 5);
							}
						}
						mVector.addElement(potion);
					}
				}
				GameCanvas.tabShopScr = new TabScreen(MainTab.xTab, 0);
				mVector mVector2 = new mVector();
				GameCanvas.tabShopScr.isShopClan = true;
				GameCanvas.tabInven.setTypeInven(1);
				mVector2.addElement(new TabShop(name, mVector, 107, MainTab.xTab)
				{
					isSelect = false
				});
				GameCanvas.tabShopScr.addVecTab(mVector2);
				GameCanvas.tabShopScr.idSelect = 0;
				GameCanvas.tabShopScr.Show(GameCanvas.gameScr);
				GameCanvas.tabShopScr.typeCurrent = 1;
				GameCanvas.tabShopScr.setTabSelect();
			}
			else
			{
				bool flag6 = b == 1;
				if (flag6)
				{
					short num2 = msg.reader().readShort();
					mVector mVector3 = new mVector();
					for (int k = 0; k < (int)num2; k++)
					{
						short id3 = msg.reader().readShort();
						string name3 = msg.reader().readUTF();
						string info2 = msg.reader().readUTF();
						short idicon = msg.reader().readShort();
						ItemHuyHieu itemHuyHieu = new ItemHuyHieu(id3, idicon, name3, info2);
						sbyte b3 = msg.reader().readByte();
						bool flag7 = b3 == 1;
						if (flag7)
						{
							itemHuyHieu.addInfoFrist(T.daTrangBi, 1);
							itemHuyHieu.colorName = 1;
						}
						sbyte b4 = msg.reader().readByte();
						for (int l = 0; l < (int)b4; l++)
						{
							sbyte id4 = msg.reader().readByte();
							short value2 = msg.reader().readShort();
							itemHuyHieu.addInfo((short)id4, (int)value2, infoShow.HARDCODE_INFO_CO_BAN, 1);
						}
						mVector3.addElement(itemHuyHieu);
					}
					GameCanvas.tabShopScr = new TabScreen(MainTab.xTab, 0);
					mVector mVector4 = new mVector();
					GameCanvas.tabShopScr.isShopClan = true;
					GameCanvas.tabInvenClan = new TabInventory(T.khoHuyHieu, mVector3, 6, MainTab.xTab);
					GameCanvas.tabInvenClan.initCmd();
					mVector4.addElement(GameCanvas.tabInvenClan);
					GameCanvas.tabShopScr.addVecTab(mVector4);
					GameCanvas.tabShopScr.idSelect = 0;
					GameCanvas.tabShopScr.Show(GameCanvas.ClanScr);
					GameCanvas.tabShopScr.typeCurrent = 1;
					GameCanvas.tabShopScr.setTabSelect();
				}
				else
				{
					bool flag8 = b == 2;
					if (flag8)
					{
						short idIcon = msg.reader().readShort();
						mSystem.outz("action use idIcon " + idIcon.ToString());
						GameCanvas.tabInvenClan.Use(idIcon);
					}
					else
					{
						bool flag9 = b != 3;
						if (!flag9)
						{
							sbyte b5 = msg.reader().readByte();
							mSystem.outz("Mo shop huy hieu type = " + b5.ToString());
							bool flag10 = b5 == 0;
							if (flag10)
							{
								short id5 = msg.reader().readShort();
								short num3 = msg.reader().readShort();
								sbyte cat = msg.reader().readByte();
								short idIcon2 = msg.reader().readShort();
								mSystem.outz(string.Concat(new string[]
								{
									"id num cat icon = ",
									id5.ToString(),
									" , ",
									num3.ToString(),
									" , ",
									cat.ToString(),
									" , ",
									idIcon2.ToString()
								}));
								Potion potion2 = new Potion(cat, id5, num3, false);
								potion2.idIcon = idIcon2;
								HuyHieuClanScreen.instance = new HuyHieuClanScreen();
								HuyHieuClanScreen.instance.potionQuay = potion2;
								HuyHieuClanScreen.instance.Show(GameCanvas.gameScr);
							}
							else
							{
								bool flag11 = b5 == 1;
								if (flag11)
								{
									Interface_Game.isPaintInfoServer = false;
									HuyHieuClanScreen.instance.potionQuay.numPotion = msg.reader().readShort();
									short num4 = msg.reader().readShort();
									mSystem.outz("xu hanh trinh con lai = " + HuyHieuClanScreen.instance.potionQuay.numPotion.ToString());
									bool flag12 = num4 == -1;
									if (flag12)
									{
										HuyHieuClanScreen.instance.isThanhCong = false;
										mSound.playSound(48, mSound.volumeSound);
										HuyHieuClanScreen.instance.StepQuaySo = 1;
										HuyHieuClanScreen.instance.tickAction = 0;
									}
									else
									{
										sbyte typeItem = msg.reader().readByte();
										Potion potionNhan = new Potion(typeItem, -1, num4, string.Empty, 0);
										mSystem.outz("potionNhan type " + b5.ToString() + " icon " + num4.ToString());
										HuyHieuClanScreen.instance.potionNhan = potionNhan;
										HuyHieuClanScreen.instance.isThanhCong = true;
										mSound.playSound(48, mSound.volumeSound);
										HuyHieuClanScreen.instance.StepQuaySo = 1;
										HuyHieuClanScreen.instance.tickAction = 0;
									}
								}
							}
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000C9F RID: 3231 RVA: 0x000F3C0C File Offset: 0x000F1E0C
	public void Shop_NPC(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			string text = msg.reader().readUTF();
			sbyte b2 = msg.reader().readByte();
			short num = msg.reader().readShort();
			mSystem.outz(string.Concat(new string[]
			{
				"nhan shop day typeShop=",
				b.ToString(),
				" nameshop=",
				text,
				" typeitem=",
				b2.ToString(),
				"  size=",
				num.ToString()
			}));
			mVector mVector = new mVector();
			bool flag = b2 == 4 || b2 == 8;
			if (flag)
			{
				for (int i = 0; i < (int)num; i++)
				{
					Potion potion = this.readUpdatePotion(msg, true, b2);
					bool flag2 = potion != null;
					if (flag2)
					{
						bool flag3 = potion.price > 0;
						if (flag3)
						{
							potion.addInfoFrist(string.Concat(new string[]
							{
								T.price,
								" ",
								potion.price.ToString(),
								" ",
								T.bery
							}), 5);
						}
						else
						{
							bool flag4 = potion.priceRuby > 0;
							if (flag4)
							{
								potion.addInfoFrist(string.Concat(new string[]
								{
									T.price,
									" ",
									potion.priceRuby.ToString(),
									" ",
									T.ruby
								}), 5);
							}
						}
						mVector.addElement(potion);
					}
				}
			}
			else
			{
				bool flag5 = b2 == 3;
				if (flag5)
				{
					for (int j = 0; j < (int)num; j++)
					{
						Item item = this.readUpdateItem(msg, true);
						sbyte b3 = msg.reader().readByte();
						int price = msg.reader().readInt();
						bool flag6 = item != null;
						if (flag6)
						{
							item.price = price;
							item.addInfoFrist(string.Concat(new string[]
							{
								T.price,
								" ",
								item.price.ToString(),
								" ",
								(b3 != 0) ? T.ruby : T.bery
							}), 5);
							mVector.addElement(item);
						}
					}
				}
				else
				{
					bool flag7 = b2 == 7;
					if (flag7)
					{
						for (int k = 0; k < (int)num; k++)
						{
							MainMaterial mainMaterial = this.readUpdateMaterial(msg, true);
							bool flag8 = mainMaterial != null;
							if (flag8)
							{
								bool flag9 = mainMaterial.price > 0;
								if (flag9)
								{
									mainMaterial.addInfoFrist(string.Concat(new string[]
									{
										T.price,
										" ",
										mainMaterial.price.ToString(),
										" ",
										T.bery
									}), 5);
								}
								else
								{
									mainMaterial.addInfoFrist(string.Concat(new string[]
									{
										T.price,
										" ",
										mainMaterial.priceRuby.ToString(),
										" ",
										T.ruby
									}), 5);
								}
								mVector.addElement(mainMaterial);
							}
						}
					}
					else
					{
						bool flag10 = b2 == 102;
						if (flag10)
						{
							for (int l = 0; l < (int)num; l++)
							{
								ItemBoat itemBoat = this.readUpdateItemBoat(msg);
								itemBoat.price = msg.reader().readInt();
								itemBoat.priceRuby = msg.reader().readShort();
								bool flag11 = itemBoat == null;
								if (!flag11)
								{
									bool flag12 = itemBoat.price > 0;
									if (flag12)
									{
										itemBoat.addInfoFrist(string.Concat(new string[]
										{
											T.price,
											" ",
											itemBoat.price.ToString(),
											" ",
											T.bery
										}), 5);
									}
									else
									{
										bool flag13 = itemBoat.priceRuby > 0;
										if (flag13)
										{
											itemBoat.addInfoFrist(string.Concat(new string[]
											{
												T.price,
												" ",
												itemBoat.priceRuby.ToString(),
												" ",
												T.ruby
											}), 5);
										}
										else
										{
											bool flag14 = false;
											bool flag15 = GameScreen.player.myBoat != null;
											if (flag15)
											{
												for (int m = 0; m < GameScreen.player.myBoat.Length; m++)
												{
													bool flag16 = m == (int)itemBoat.typeBoat && itemBoat.idPart == GameScreen.player.myBoat[m];
													if (flag16)
													{
														itemBoat.addInfoFrist(T.daTrangBi, 4);
														itemBoat.colorName = 1;
														flag14 = true;
													}
												}
											}
											bool flag17 = !flag14;
											if (flag17)
											{
												itemBoat.addInfoFrist(T.dasuhuu, 1);
												itemBoat.colorName = 1;
											}
										}
									}
									mVector.addElement(itemBoat);
								}
							}
							GlobalService.gI().Update_Part_Boat();
						}
						else
						{
							bool flag18 = b2 == 103 || b2 == 108;
							if (flag18)
							{
								for (int n = 0; n < (int)num; n++)
								{
									int num2 = (int)GameScreen.player.hair;
									bool flag19 = b2 == 108;
									if (flag19)
									{
										num2 = (int)GameScreen.player.head;
									}
									ItemHair itemHair = this.readUpdateItemHair(msg, b2);
									bool flag20 = itemHair.idIcon == 772;
									if (flag20)
									{
										itemHair.isShop = true;
										itemHair.setInfoPotion(T.infotocvip);
									}
									itemHair.price = msg.reader().readInt();
									itemHair.priceRuby = msg.reader().readShort();
									bool flag21 = itemHair != null;
									if (flag21)
									{
										bool flag22 = itemHair.price > 0;
										if (flag22)
										{
											itemHair.addInfoFrist(string.Concat(new string[]
											{
												T.price,
												" ",
												itemHair.price.ToString(),
												" ",
												T.bery
											}), 5);
										}
										else
										{
											bool flag23 = itemHair.priceRuby > 0;
											if (flag23)
											{
												itemHair.addInfoFrist(string.Concat(new string[]
												{
													T.price,
													" ",
													itemHair.priceRuby.ToString(),
													" ",
													T.ruby
												}), 5);
											}
											else
											{
												bool flag24 = (int)itemHair.idIcon == num2;
												if (flag24)
												{
													itemHair.addInfoFrist(T.daTrangBi, 4);
													itemHair.colorName = 4;
												}
												else
												{
													itemHair.addInfoFrist(T.dasuhuu, 1);
													itemHair.colorName = 1;
												}
											}
										}
										mVector.addElement(itemHair);
									}
								}
							}
							else
							{
								bool flag25 = b2 == 105;
								if (flag25)
								{
									for (int num3 = 0; num3 < (int)num; num3++)
									{
										ItemFashion itemFashion = this.readUpdateItemFashion(msg);
										itemFashion.price = msg.reader().readInt();
										itemFashion.priceRuby = msg.reader().readShort();
										itemFashion.LvUpgrade = msg.reader().readByte();
										bool flag26 = itemFashion != null;
										if (flag26)
										{
											bool flag27 = itemFashion.price > 0;
											if (flag27)
											{
												itemFashion.addInfoFrist(string.Concat(new string[]
												{
													T.price,
													" ",
													itemFashion.price.ToString(),
													" ",
													T.bery
												}), 5);
											}
											else
											{
												bool flag28 = itemFashion.priceRuby > 0;
												if (flag28)
												{
													itemFashion.addInfoFrist(string.Concat(new string[]
													{
														T.price,
														" ",
														itemFashion.priceRuby.ToString(),
														" ",
														T.ruby
													}), 5);
												}
												else
												{
													bool flag29 = itemFashion.price == -2;
													if (flag29)
													{
														itemFashion.addInfoFrist(T.gift, 5);
													}
													else
													{
														bool flag30 = itemFashion.price == -1;
														if (flag30)
														{
															itemFashion.addInfoFrist(T.chuaban, 6);
															itemFashion.colorName = 6;
														}
														else
														{
															bool flag31 = itemFashion.ID == Player.idFashion && b != 114;
															if (flag31)
															{
																itemFashion.addInfoFrist(T.daTrangBi, 4);
																itemFashion.colorName = 4;
															}
															else
															{
																itemFashion.addInfoFrist(T.dasuhuu, 1);
																itemFashion.colorName = 1;
															}
														}
													}
												}
											}
											mVector.addElement(itemFashion);
										}
									}
								}
								else
								{
									bool flag32 = b2 == 107;
									if (flag32)
									{
										for (int num4 = 0; num4 < (int)num; num4++)
										{
											short id = msg.reader().readShort();
											short idImage = msg.reader().readShort();
											string name = msg.reader().readUTF();
											string info = msg.reader().readUTF();
											short priceRuby = msg.reader().readShort();
											Potion potion2 = new Potion(id, idImage, name, info, priceRuby);
											bool flag33 = potion2 != null;
											if (flag33)
											{
												bool flag34 = potion2.price > 0;
												if (flag34)
												{
													potion2.addInfoFrist(string.Concat(new string[]
													{
														T.price,
														" ",
														potion2.price.ToString(),
														" ",
														T.bery
													}), 5);
												}
												else
												{
													bool flag35 = potion2.priceRuby > 0;
													if (flag35)
													{
														potion2.addInfoFrist(string.Concat(new string[]
														{
															T.price,
															" ",
															potion2.priceRuby.ToString(),
															" ",
															T.ruby
														}), 5);
													}
												}
												mVector.addElement(potion2);
											}
										}
									}
									else
									{
										bool flag36 = b2 == 11;
										if (flag36)
										{
											for (int num5 = 0; num5 < (int)num; num5++)
											{
												MainItem mainItem = new MainItem();
												mainItem.ID = msg.reader().readShort();
												mainItem.typeObject = msg.reader().readByte();
												mainItem.namepaint = msg.reader().readUTF();
												mainItem.idIcon = msg.reader().readShort();
												string infoPotion = msg.reader().readUTF();
												mainItem.isShop = true;
												mainItem.setInfoPotion(infoPotion);
												mVector.addElement(mainItem);
											}
										}
									}
								}
							}
						}
					}
				}
			}
			TabShop tabShop = null;
			GameCanvas.tabShopScr = new TabScreen(MainTab.xTab, 0);
			mVector mVector2 = new mVector();
			bool flag37 = b == 110;
			if (flag37)
			{
				GameCanvas.tabShopScr.isShopClan = true;
				GameCanvas.tabInvenClan = new TabInventory(T.tabInven, Player.vecInvenClan, 4, MainTab.xTab);
				GameCanvas.tabInvenClan.initCmd();
				mVector2.addElement(GameCanvas.tabInvenClan);
			}
			else
			{
				bool flag38 = b2 != 107;
				if (flag38)
				{
					mVector2.addElement(GameCanvas.tabInven);
				}
				else
				{
					GameCanvas.tabShopScr.isShopClan = true;
				}
			}
			bool flag39 = b == 99;
			if (flag39)
			{
				GameCanvas.tabInven.setTypeInven(2);
				TabChest tabChest = new TabChest(text, Player.vecChest, MainTab.xTab);
				tabChest.initCmd();
				mVector2.addElement(tabChest);
			}
			else
			{
				GameCanvas.tabInven.setTypeInven(1);
				tabShop = new TabShop(text, mVector, b, MainTab.xTab);
				mVector2.addElement(tabShop);
			}
			GameCanvas.tabShopScr.addVecTab(mVector2);
			bool flag40 = b2 != 107;
			if (flag40)
			{
				GameCanvas.tabShopScr.idSelect = 1;
			}
			else
			{
				GameCanvas.tabShopScr.idSelect = 0;
			}
			GameCanvas.tabShopScr.Show(GameCanvas.gameScr);
			bool flag41 = b == 99;
			if (flag41)
			{
				GameCanvas.tabShopScr.typeCurrent = 0;
			}
			else
			{
				GameCanvas.tabShopScr.typeCurrent = 1;
			}
			GameCanvas.tabShopScr.setTabSelect();
			bool flag42 = b == 101;
			if (flag42)
			{
				if (tabShop != null)
				{
					tabShop.beginFocus();
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CA0 RID: 3232 RVA: 0x000F488C File Offset: 0x000F2A8C
	public void Dynamic_Menu(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			short num = msg.reader().readShort();
			sbyte b2 = msg.reader().readByte();
			string name = msg.reader().readUTF();
			sbyte b3 = msg.reader().readByte();
			mVector mVector = new mVector();
			for (int i = 0; i < (int)b3; i++)
			{
				iCommand iCommand = new iCommand(msg.reader().readUTF(), null);
				bool flag = b == 1;
				if (flag)
				{
					sbyte idImage = msg.reader().readByte();
					sbyte textColorName = msg.reader().readByte();
					iCommand = this.setfraIComment(b, (short)idImage, iCommand);
					iCommand.setFont(AvMain.setTextColorName((int)textColorName));
				}
				else
				{
					bool flag2 = b == 3;
					if (flag2)
					{
						short idP = msg.reader().readShort();
						sbyte b4 = msg.reader().readByte();
						bool flag3 = b4 == 7;
						if (flag3)
						{
							MainMaterial mainMaterial = (MainMaterial)MainItem.hashMaterialTem.get(string.Empty + idP.ToString());
							bool flag4 = mainMaterial != null;
							if (flag4)
							{
								MainItem item = new MainItem(b4, mainMaterial.idIcon, 0);
								iCommand.setItem(item);
							}
						}
						else
						{
							bool flag5 = b4 == 4;
							if (flag5)
							{
								Potion templatePotion = Potion.getTemplatePotion(idP);
								bool flag6 = templatePotion != null && templatePotion.isUpdateTem;
								if (flag6)
								{
									MainItem item2 = new MainItem(b4, templatePotion.idIcon, 0);
									iCommand.setItem(item2);
								}
							}
						}
					}
					else
					{
						bool flag7 = b == 4;
						if (flag7)
						{
							short idIcon = msg.reader().readShort();
							MainItem item3 = new MainItem(104, idIcon, 0);
							iCommand.setItem(item3);
						}
						else
						{
							bool flag8 = b == 5;
							if (flag8)
							{
								short idIcon2 = msg.reader().readShort();
								MainItem item4 = new MainItem(100, (short)i, idIcon2, 0, 0, 0);
								iCommand.setItem(item4);
							}
							else
							{
								bool flag9 = b == 6;
								if (flag9)
								{
									short idIcon3 = msg.reader().readShort();
									sbyte textColorName2 = msg.reader().readByte();
									MainItem item5 = new MainItem(100, (short)i, idIcon3, 0, 0, 0);
									iCommand.setItem(item5);
									iCommand.setFont(AvMain.setTextColorName((int)textColorName2));
								}
							}
						}
					}
				}
				mVector.addElement(iCommand);
			}
			bool flag10 = b == 2;
			if (flag10)
			{
				GameCanvas.menu.startAt_NPC(mVector, string.Empty, (int)num, 2, false, 0, true);
				GameCanvas.menu.IdMenu = (int)b2;
			}
			else
			{
				int pos = 2;
				bool flag11 = b == 1;
				if (flag11)
				{
					pos = 4;
				}
				GameCanvas.menu.setinfoDynamic(mVector, pos, (int)b2, (int)num, name);
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CA1 RID: 3233 RVA: 0x000F4B64 File Offset: 0x000F2D64
	public iCommand setfraIComment(sbyte type, short idImage, iCommand cmd)
	{
		bool flag = type == 1 && idImage >= 0;
		if (flag)
		{
			cmd.setFraCaption(AvMain.fraCheck, 1, (int)idImage, 0);
		}
		return cmd;
	}

	// Token: 0x06000CA2 RID: 3234 RVA: 0x000F4B9C File Offset: 0x000F2D9C
	public void List_Quest(Message msg)
	{
		try
		{
			mVector mVector = new mVector();
			sbyte b = msg.reader().readByte();
			bool flag = b == 0;
			if (flag)
			{
				sbyte b2 = msg.reader().readByte();
				for (int i = 0; i < (int)b2; i++)
				{
					MainQuest o = this.QuestAdd(msg);
					mVector.addElement(o);
				}
				sbyte b3 = msg.reader().readByte();
				for (int j = 0; j < (int)b3; j++)
				{
					MainQuest o2 = this.QuestCurrent(msg);
					mVector.addElement(o2);
				}
				sbyte b4 = msg.reader().readByte();
				for (int k = 0; k < (int)b4; k++)
				{
					MainQuest o3 = this.QuestFinish(msg);
					mVector.addElement(o3);
				}
				Player.vecQuest = mVector;
			}
			else
			{
				bool flag2 = b == 1;
				if (flag2)
				{
					sbyte b5 = msg.reader().readByte();
					MainQuest mainQuest = null;
					bool flag3 = b5 == 0;
					if (flag3)
					{
						mainQuest = this.QuestAdd(msg);
						bool flag4 = mainQuest.typeMainSub != 2;
						if (flag4)
						{
							Player.questMainNew = mainQuest;
						}
					}
					else
					{
						bool flag5 = b5 == 1;
						if (flag5)
						{
							mainQuest = this.QuestCurrent(msg);
							bool flag6 = GameScreen.indexHelp == 14;
							if (flag6)
							{
								GameScreen.addHelp(14, 1);
							}
						}
						else
						{
							bool flag7 = b5 == 2;
							if (flag7)
							{
								mainQuest = this.QuestFinish(msg);
								bool flag8 = GameScreen.indexHelp == 14;
								if (flag8)
								{
									GameScreen.addHelp(14, 1);
								}
							}
						}
					}
					MainQuest quest = MainQuest.getQuest(mainQuest.ID);
					bool flag9 = quest != null;
					if (flag9)
					{
						Player.vecQuest.removeElement(quest);
					}
					bool flag10 = mainQuest != null;
					if (flag10)
					{
						Player.vecQuest.addElement(mainQuest);
					}
				}
				else
				{
					bool flag11 = b == 2;
					if (flag11)
					{
						short id = msg.reader().readShort();
						MainQuest quest2 = MainQuest.getQuest(id);
						bool flag12 = quest2 != null;
						if (flag12)
						{
							Player.vecQuest.removeElement(quest2);
						}
					}
					else
					{
						bool flag13 = b == 5;
						if (flag13)
						{
							short id2 = msg.reader().readShort();
							MainQuest quest3 = MainQuest.getQuest(id2);
							bool flag14 = quest3 != null;
							if (flag14)
							{
								GameCanvas.end_Dialog();
								MsgDialog msgDialog = new MsgDialog();
								msgDialog.setinfoQuest(quest3, true);
								GameCanvas.Start_Current_Dialog(msgDialog);
							}
						}
					}
				}
			}
			for (int l = 0; l < GameScreen.vecPlayers.size(); l++)
			{
				MainObject mainObject = (MainObject)GameScreen.vecPlayers.elementAt(l);
				bool flag15 = mainObject.typeObject == 2;
				if (flag15)
				{
					mainObject.setTypeQuest();
				}
			}
			TabQuest.isNewQuest = false;
			for (int m = 0; m < Player.vecQuest.size(); m++)
			{
				MainQuest mainQuest2 = (MainQuest)Player.vecQuest.elementAt(m);
				bool flag16 = mainQuest2.statusQuest == 0 || mainQuest2.statusQuest == 2;
				if (flag16)
				{
					TabQuest.isNewQuest = true;
					break;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CA3 RID: 3235 RVA: 0x000F4ED8 File Offset: 0x000F30D8
	private MainQuest QuestFinish(Message msg)
	{
		MainQuest mainQuest = null;
		MainQuest result;
		try
		{
			short id = msg.reader().readShort();
			mainQuest = new MainQuest(id);
			mainQuest.statusQuest = 2;
			mainQuest.typeMainSub = msg.reader().readByte();
			mainQuest.typeActionQuest = msg.reader().readByte();
			mainQuest.name = msg.reader().readUTF();
			mainQuest.idNPC = (int)msg.reader().readShort();
			mainQuest.idNPC_Sub = (int)msg.reader().readShort();
			mainQuest.strTalk = msg.reader().readUTF();
			sbyte typeQ = msg.reader().readByte();
			DataQuest o = new DataQuest(typeQ);
			mainQuest.vecTypeQuest.addElement(o);
			mainQuest.strShowDialog = msg.reader().readUTF();
			mainQuest.strNPC_Map = msg.reader().readUTF();
			mainQuest.strNhacNho = msg.reader().readUTF();
			result = mainQuest;
		}
		catch (Exception)
		{
			result = mainQuest;
		}
		return result;
	}

	// Token: 0x06000CA4 RID: 3236 RVA: 0x000F4FDC File Offset: 0x000F31DC
	private MainQuest QuestCurrent(Message msg)
	{
		MainQuest mainQuest = null;
		MainQuest result;
		try
		{
			short id = msg.reader().readShort();
			mainQuest = new MainQuest(id);
			mainQuest.statusQuest = 1;
			mainQuest.typeMainSub = msg.reader().readByte();
			mainQuest.typeActionQuest = msg.reader().readByte();
			mainQuest.name = msg.reader().readUTF();
			mainQuest.idNPC = (int)msg.reader().readShort();
			mainQuest.strNhacNho = msg.reader().readUTF();
			mainQuest.strShowDialog = msg.reader().readUTF();
			sbyte b = msg.reader().readByte();
			for (int i = 0; i < (int)b; i++)
			{
				sbyte b2 = msg.reader().readByte();
				DataQuest dataQuest = new DataQuest(b2);
				bool flag = b2 == 2 || b2 == 1;
				if (flag)
				{
					dataQuest.SetDataQuest(msg.reader().readShort(), msg.reader().readShort(), msg.reader().readShort());
				}
				mainQuest.vecTypeQuest.addElement(dataQuest);
			}
			mainQuest.strNPC_Map = msg.reader().readUTF();
			mainQuest.idMapHelp = msg.reader().readShort();
			result = mainQuest;
		}
		catch (Exception)
		{
			result = mainQuest;
		}
		return result;
	}

	// Token: 0x06000CA5 RID: 3237 RVA: 0x000F513C File Offset: 0x000F333C
	private MainQuest QuestAdd(Message msg)
	{
		MainQuest mainQuest = null;
		MainQuest result;
		try
		{
			short id = msg.reader().readShort();
			mainQuest = new MainQuest(id);
			mainQuest.statusQuest = 0;
			mainQuest.typeMainSub = msg.reader().readByte();
			mainQuest.typeActionQuest = msg.reader().readByte();
			mainQuest.name = msg.reader().readUTF();
			mainQuest.idNPC = (int)msg.reader().readShort();
			mainQuest.strTalk = msg.reader().readUTF();
			sbyte typeQ = msg.reader().readByte();
			mainQuest.strShowDialog = msg.reader().readUTF();
			DataQuest o = new DataQuest(typeQ);
			mainQuest.vecTypeQuest.addElement(o);
			mainQuest.strNPC_Map = msg.reader().readUTF();
			mainQuest.lvRequest = msg.reader().readShort();
			result = mainQuest;
		}
		catch (Exception)
		{
			result = mainQuest;
		}
		return result;
	}

	// Token: 0x06000CA6 RID: 3238 RVA: 0x000F5230 File Offset: 0x000F3430
	public void get_Info_NPC(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			MainObject mainObject = MainObject.get_Object((int)id, 2);
			mainObject.IdIcon = msg.reader().readShort();
			mainObject.nameGiaotiep = msg.reader().readUTF();
			sbyte w = msg.reader().readByte();
			sbyte h = msg.reader().readByte();
			GameCanvas.loadmap.setBlockNPC(mainObject.x, mainObject.y, (int)w, (int)h);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CA7 RID: 3239 RVA: 0x000F52C0 File Offset: 0x000F34C0
	public void Party(Message msg)
	{
		try
		{
			int num = Player.vecParty.size();
			sbyte b = msg.reader().readByte();
			bool flag = b == 5;
			if (flag)
			{
				Player.vecParty.removeAllElements();
				sbyte b2 = msg.reader().readByte();
				for (int i = 0; i < (int)b2; i++)
				{
					short id = msg.reader().readShort();
					InfoMemList infoMemList = new InfoMemList((int)id);
					infoMemList.updateData(msg.reader().readUTF(), msg.reader().readShort(), msg.reader().readByte(), msg.reader().readByte());
					Player.vecParty.addElement(infoMemList);
				}
				for (int j = 0; j < GameScreen.vecPlayers.size(); j++)
				{
					MainObject mainObject = (MainObject)GameScreen.vecPlayers.elementAt(j);
					for (int k = 0; k < Player.vecParty.size(); k++)
					{
						InfoMemList infoMemList2 = (InfoMemList)Player.vecParty.elementAt(k);
						bool flag2 = infoMemList2.id == (int)mainObject.ID && mainObject.typeObject == 0;
						if (flag2)
						{
							infoMemList2.updateHP(mainObject.Hp, mainObject.maxHp, mainObject.Lv);
						}
					}
				}
			}
			else
			{
				bool flag3 = b == 1;
				if (flag3)
				{
					short num2 = msg.reader().readShort();
					InfoMemList infoMemList3 = InfoMemList.getMem((int)num2, Player.vecParty);
					bool flag4 = infoMemList3 == null;
					if (flag4)
					{
						infoMemList3 = new InfoMemList((int)num2);
						Player.vecParty.addElement(infoMemList3);
					}
					infoMemList3.updateData(msg.reader().readUTF(), msg.reader().readShort(), msg.reader().readByte(), msg.reader().readByte());
					for (int l = 0; l < GameScreen.vecPlayers.size(); l++)
					{
						MainObject mainObject2 = (MainObject)GameScreen.vecPlayers.elementAt(l);
						bool flag5 = num2 == mainObject2.ID && mainObject2.typeObject == 0;
						if (flag5)
						{
							infoMemList3.updateHP(mainObject2.Hp, mainObject2.maxHp, mainObject2.Lv);
						}
					}
				}
				else
				{
					bool flag6 = b == 2;
					if (flag6)
					{
						short id2 = msg.reader().readShort();
						InfoMemList mem = InfoMemList.getMem((int)id2, Player.vecParty);
						bool flag7 = mem != null;
						if (flag7)
						{
							Player.vecParty.removeElement(mem);
						}
					}
					else
					{
						bool flag8 = b == 3;
						if (flag8)
						{
							Player.vecParty.removeAllElements();
						}
						else
						{
							bool flag9 = b == 0;
							if (flag9)
							{
								short id3 = msg.reader().readShort();
								string name = msg.reader().readUTF();
								InfoMemList.setTypeEvent((int)id3, 1, name, T.eventParty, 0, 0);
							}
							else
							{
								bool flag10 = b == 7;
								if (flag10)
								{
									short id4 = msg.reader().readShort();
									string name2 = msg.reader().readUTF();
									InfoMemList.setTypeEvent((int)id4, 5, name2, T.xinvaoParty, 0, 0);
								}
							}
						}
					}
				}
			}
			bool flag11 = Player.vecParty.size() != num && GameCanvas.currentScreen == PartyScreen.gI();
			if (flag11)
			{
				PartyScreen.gI().updateInfo();
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CA8 RID: 3240 RVA: 0x000F564C File Offset: 0x000F384C
	public void ChatPopup(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			sbyte tem = msg.reader().readByte();
			MainObject mainObject = MainObject.get_Object((int)id, tem);
			bool flag = mainObject != null;
			if (flag)
			{
				string text = msg.reader().readUTF();
				text = (mainObject.strChatPopup = GameMidlet.fixString(text));
				bool flag2 = mainObject.typeObject == 0;
				if (flag2)
				{
					GameCanvas.chatTabScr.addNewChat(T.tabServer, string.Empty, mainObject.name + ": " + text, 1, false);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CA9 RID: 3241 RVA: 0x000F56F8 File Offset: 0x000F38F8
	public void ChatTab(Message msg)
	{
		try
		{
			string text = msg.reader().readUTF();
			string text2 = msg.reader().readUTF();
			text2 = GameMidlet.fixString(text2);
			bool flag = text2 != null && text2.Trim().Length != 0;
			if (flag)
			{
				bool flag2 = text.CompareTo(T.tabServer) == 0;
				if (flag2)
				{
					GameCanvas.chatTabScr.addNewChat(text, T.thongbao + ": ", text2, 1, false);
				}
				else
				{
					bool flag3 = text.CompareTo(T.cmdEvent) == 0;
					if (flag3)
					{
						GameCanvas.chatTabScr.addNewChat(text, string.Empty, text2, 1, false);
					}
					else
					{
						bool flag4 = text.CompareTo(T.tabPhobang) == 0;
						if (flag4)
						{
							GameCanvas.chatTabScr.addNewChat(text, string.Empty, text2, 1, false);
						}
						else
						{
							bool flag5 = text.CompareTo(T.tabThongBao) == 0;
							if (flag5)
							{
								GameCanvas.chatTabScr.addNewChat(text, string.Empty, text2, 1, false);
							}
							else
							{
								bool flag6 = text.CompareTo(T.tabBangChu) == 0;
								if (flag6)
								{
									GameCanvas.chatTabScr.addNewChat(text, string.Empty, text2, 1, false);
								}
								else
								{
									bool flag7 = text.CompareTo(T.tabBangHoi) == 0;
									if (flag7)
									{
										GameCanvas.chatTabScr.addNewChat(text, string.Empty, text2, 0, false);
									}
									else
									{
										bool flag8 = text.CompareTo(T.party) == 0;
										if (flag8)
										{
											GameCanvas.chatTabScr.addNewChat(text, string.Empty, text2, 0, false);
										}
										else
										{
											GameCanvas.chatTabScr.addNewChatCheckSpam(text, text + ": ", text2, 0, false);
										}
									}
								}
							}
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CAA RID: 3242 RVA: 0x000F58CC File Offset: 0x000F3ACC
	public void charWearing(Message msg)
	{
		string str = string.Empty;
		try
		{
			short id = msg.reader().readShort();
			sbyte b = msg.reader().readByte();
			MainObject mainObject = MainObject.get_Object((int)id, b);
			bool flag = mainObject == null;
			if (!flag)
			{
				str = mainObject.name;
				mSystem.outloi("update charwearing name=" + str);
				short headset = msg.reader().readShort();
				mainObject.sethead(headset);
				mainObject.sethair(msg.reader().readShort());
				sbyte b2 = msg.reader().readByte();
				short[] array = new short[(int)b2];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = -1;
				}
				for (int j = 0; j < (int)b2; j++)
				{
					sbyte b3 = msg.reader().readByte();
					bool flag2 = b3 == 1 && mainObject == GameScreen.player;
					if (flag2)
					{
						MainItem mainItem = this.readUpdateItem(msg, false);
						GameScreen.player.hashEquip.put(string.Empty + j.ToString(), mainItem);
						bool flag3 = mainItem.typeSpec == 1;
						if (flag3)
						{
							GameScreen.player.lvHeart = mainItem.LvUpgrade;
						}
					}
					array[j] = msg.reader().readShort();
				}
				bool flag4 = b == 1;
				if (flag4)
				{
					mainObject.setWearingMon(array);
				}
				else
				{
					mainObject.setWearing(array);
				}
				bool flag5 = mainObject == GameScreen.player;
				if (flag5)
				{
					bool flag6 = GameCanvas.currentScreen == GameCanvas.tabShopScr;
					if (flag6)
					{
						for (int k = 0; k < GameCanvas.tabShopScr.vecTabs.size(); k++)
						{
							MainTab mainTab = (MainTab)GameCanvas.tabShopScr.vecTabs.elementAt(k);
							mainTab.updateTrangBi();
						}
					}
					TabScreen.isRefresh = true;
					Uniform.checkIndexItem(false);
				}
				short bodyBay = -1;
				try
				{
					bodyBay = msg.reader().readShort();
				}
				catch (Exception)
				{
					bodyBay = -1;
				}
				mainObject.setBodyBay(bodyBay);
				short legBay = -1;
				try
				{
					legBay = msg.reader().readShort();
				}
				catch (Exception)
				{
					legBay = -1;
				}
				mainObject.setLegBay(legBay);
				short weaponBay = -1;
				try
				{
					weaponBay = msg.reader().readShort();
				}
				catch (Exception)
				{
					weaponBay = -1;
				}
				mainObject.setWeaponBay(weaponBay);
				short hairBay = -1;
				try
				{
					hairBay = msg.reader().readShort();
				}
				catch (Exception)
				{
					hairBay = -1;
				}
				mainObject.setHairBay(hairBay);
				mSystem.outz(string.Concat(new string[]
				{
					"charWearing name = ",
					mainObject.name,
					" bay : ",
					bodyBay.ToString(),
					" ",
					legBay.ToString(),
					" ",
					weaponBay.ToString(),
					" ",
					hairBay.ToString()
				}));
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CAB RID: 3243 RVA: 0x000F5C4C File Offset: 0x000F3E4C
	public void Save_RMS_Server(Message msg)
	{
		try
		{
			sbyte id = msg.reader().readByte();
			short num = msg.reader().readShort();
			sbyte[] array = null;
			bool flag = num > 0;
			if (flag)
			{
				array = new sbyte[(int)num];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = msg.reader().readByte();
				}
			}
			GameCanvas.saveRms.setLoadRMSServer(id, array);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CAC RID: 3244 RVA: 0x000F5CD4 File Offset: 0x000F3ED4
	public void Learn_Skill(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			bool flag = b == 0 || b == 1;
			if (flag)
			{
				Skill_Info skill_Info = this.readSkillInfo(msg);
				bool flag2 = skill_Info == null;
				if (flag2)
				{
					return;
				}
				bool flag3 = b == 0;
				if (flag3)
				{
					MsgDialog msgDialog = new MsgDialog();
					msgDialog.setinfoSkillInfo(skill_Info);
					GameCanvas.Start_Current_Dialog(msgDialog);
				}
				else
				{
					bool flag4 = b == 1;
					if (flag4)
					{
						Skill_Info skillFromID = Skill_Info.getSkillFromID(skill_Info.ID);
						bool flag5 = skillFromID != null;
						if (flag5)
						{
							skill_Info.indexHotKey = skillFromID.indexHotKey;
							Player.vecListSkill.setElementAt(skill_Info, Player.vecListSkill.indexOf(skillFromID));
						}
						else
						{
							skill_Info.indexHotKey = ReadMessenge.indexHotKeySkill;
							ReadMessenge.indexHotKeySkill += 1;
							Player.vecListSkill.addElement(skill_Info);
						}
						Player.vecListSkill = MainItem.SortVecItem(Player.vecListSkill);
					}
				}
				bool flag6 = b == 1;
				if (flag6)
				{
					bool flag7 = skill_Info.typeSkill == 1;
					if (flag7)
					{
						bool flag8 = skill_Info.Lv_RQ == 1;
						if (flag8)
						{
							bool flag9 = false;
							for (int i = 0; i < Player.hotkeyPlayer[0].Length; i++)
							{
								bool flag10 = flag9;
								if (flag10)
								{
									break;
								}
								Hotkey hotkey = Player.hotkeyPlayer[(int)Player.currentTab][i];
								bool flag11 = hotkey.skill == null;
								if (flag11)
								{
									Player.setHotKey(i, new MainSkill(skill_Info.ID, -1)
									{
										indexHotKey = skill_Info.indexHotKey,
										idIcon = skill_Info.idIcon,
										isBuff = (skill_Info.typeSkill == 2)
									}, null);
									flag9 = true;
								}
							}
						}
						else
						{
							bool flag12 = skill_Info.Lv_RQ > 1;
							if (flag12)
							{
								MainImage image = Skill_Info.getImage(skill_Info.idIcon);
								FrameImage fra = null;
								bool flag13 = image != null && image.img != null;
								if (flag13)
								{
									fra = new FrameImage(image.img, mImage.getImageWidth(image.img.image), mImage.getImageHeight(image.img.image));
								}
								GameScreen.addEffectNumImage(T.lvUp, GameScreen.player.x, GameScreen.player.y - GameScreen.player.hOne, 2, fra, 0);
							}
						}
					}
					Player.setHotKeyBuff();
				}
				bool flag14 = !Player.isSkillready;
				if (flag14)
				{
					bool flag15 = skill_Info.Lv_RQ == -1;
					if (flag15)
					{
						Player.isSkillready = true;
					}
				}
				else
				{
					Player.isSkillready = false;
					for (int j = 0; j < Player.vecListSkill.size(); j++)
					{
						Skill_Info skill_Info2 = (Skill_Info)Player.vecListSkill.elementAt(j);
						bool flag16 = skill_Info2.Lv_RQ == -1 && (skill_Info2.typeSkill != 3 || TabSkill.numCurrentPassive < (int)Player.numPassive);
						if (flag16)
						{
							Player.isSkillready = true;
							break;
						}
					}
				}
			}
			bool flag17 = b == 2;
			if (flag17)
			{
				short id = msg.reader().readShort();
				Skill_Info skillFromID2 = Skill_Info.getSkillFromID(id);
				bool flag18 = skillFromID2 != null;
				if (flag18)
				{
					skillFromID2.percentLv = msg.reader().readShort();
				}
			}
			bool flag19 = b != 3;
			if (!flag19)
			{
				short num = msg.reader().readShort();
				Skill_Info skillFromID3 = Skill_Info.getSkillFromID(num);
				for (int k = 0; k < Player.hotkeyPlayer.Length; k++)
				{
					for (int l = 0; l < Player.hotkeyPlayer[k].Length; l++)
					{
						Hotkey hotkey2 = Player.hotkeyPlayer[k][l];
						bool flag20 = hotkey2.skill != null && hotkey2.skill.ID == num;
						if (flag20)
						{
							hotkey2.skill = null;
						}
					}
				}
				Player.vecListSkill.removeElement(skillFromID3);
				Player.setHotKeyBuff();
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CAD RID: 3245 RVA: 0x000F6100 File Offset: 0x000F4300
	public void Friend(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			bool flag = b == 0;
			if (flag)
			{
				short id = msg.reader().readShort();
				string name = msg.reader().readUTF();
				InfoMemList.setTypeEvent((int)id, 0, name, T.eventAddFriend, 0, 0);
			}
			else
			{
				bool flag2 = b == 1;
				if (flag2)
				{
					int num = msg.reader().readInt();
					for (int i = 0; i < Player.vecFriendList.size(); i++)
					{
						InfoMemList infoMemList = (InfoMemList)Player.vecFriendList.elementAt(i);
						bool flag3 = infoMemList.id == num;
						if (flag3)
						{
							Player.vecFriendList.removeElement(infoMemList);
							break;
						}
					}
				}
				else
				{
					bool flag4 = b == 2;
					if (flag4)
					{
						mVector mVector = new mVector();
						sbyte b2 = msg.reader().readByte();
						for (int j = 0; j < (int)b2; j++)
						{
							InfoMemList infoMemList2 = this.ReadInfoMemList(msg);
							bool flag5 = infoMemList2 != null;
							if (flag5)
							{
								mVector.addElement(infoMemList2);
							}
						}
						Player.vecFriendList = mVector;
						FriendList.isGetListFriend = true;
						FriendList.gI().vecPlayer = Player.vecFriendList;
						FriendList.gI().updateInfo();
						bool flag6 = !MsgSpamSetup.isDontShowFriendList;
						if (flag6)
						{
							FriendList.gI().Show(GameCanvas.gameScr);
						}
						MsgSpamSetup.isDontShowFriendList = false;
					}
					else
					{
						bool flag7 = b == 3;
						if (flag7)
						{
							InfoMemList infoMemList3 = this.ReadInfoMemList(msg);
							bool flag8 = infoMemList3 != null;
							if (flag8)
							{
								Player.vecFriendList.addElement(infoMemList3);
							}
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CAE RID: 3246 RVA: 0x000F62C4 File Offset: 0x000F44C4
	public void ListPlayerServer(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			string name = msg.reader().readUTF();
			sbyte page = msg.reader().readByte();
			mVector mVector = new mVector();
			sbyte b2 = msg.reader().readByte();
			for (int i = 0; i < (int)b2; i++)
			{
				InfoMemList infoMemList = PlayerListServer.typeClan(b) ? this.ReadInfoClanList(msg) : ((b != 9) ? this.ReadInfoMemList(msg) : this.ReadInfoMemListWanted(msg));
				bool flag = infoMemList != null;
				if (flag)
				{
					mVector.addElement(infoMemList);
				}
			}
			bool flag2 = b == 2;
			if (flag2)
			{
				BlackList.instance = new BlackList(b, mVector, name, page);
				BlackList.instance.Show(GameCanvas.gameScr);
				BlackList.instance.isLoad = false;
			}
			else
			{
				bool flag3 = b == 9;
				if (flag3)
				{
					WantedScreen.instance = new WantedScreen(mVector, 0, 0);
					WantedScreen.instance.Show(GameCanvas.gameScr);
				}
				else
				{
					PlayerListServer.instance = new PlayerListServer(b, mVector, name, page);
					PlayerListServer.instance.Show(GameCanvas.gameScr);
					PlayerListServer.instance.isLoad = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CAF RID: 3247 RVA: 0x000F6418 File Offset: 0x000F4618
	public InfoMemList ReadInfoMemList(Message msg)
	{
		InfoMemList infoMemList = null;
		InfoMemList result;
		try
		{
			int id = msg.reader().readInt();
			infoMemList = new InfoMemList(id);
			infoMemList.name = msg.reader().readUTF();
			bool flag = infoMemList.name.CompareTo(GameScreen.player.name) == 0;
			if (flag)
			{
				infoMemList.isMe = true;
			}
			infoMemList.Lv = (int)msg.reader().readShort();
			infoMemList.head = msg.reader().readShort();
			infoMemList.hair = msg.reader().readShort();
			infoMemList.hat = msg.reader().readShort();
			infoMemList.typeOnline = msg.reader().readByte();
			infoMemList.info = msg.reader().readUTF();
			infoMemList.rank = (int)msg.reader().readShort();
			result = infoMemList;
		}
		catch (Exception)
		{
			result = infoMemList;
		}
		return result;
	}

	// Token: 0x06000CB0 RID: 3248 RVA: 0x000F6504 File Offset: 0x000F4704
	public InfoMemList ReadInfoMemListWanted(Message msg)
	{
		InfoMemList infoMemList = null;
		InfoMemList result;
		try
		{
			int id = msg.reader().readInt();
			infoMemList = new InfoMemList(id);
			infoMemList.name = msg.reader().readUTF();
			bool flag = infoMemList.name.CompareTo(GameScreen.player.name) == 0;
			if (flag)
			{
				infoMemList.isMe = true;
			}
			infoMemList.updateChar(msg.reader().readShort(), msg.reader().readShort(), msg.reader().readShort(), msg.reader().readShort(), msg.reader().readShort(), msg.reader().readShort());
			infoMemList.charShow.rankWanted = msg.reader().readInt();
			infoMemList.charShow.wanted = msg.reader().readInt();
			result = infoMemList;
		}
		catch (Exception)
		{
			result = infoMemList;
		}
		return result;
	}

	// Token: 0x06000CB1 RID: 3249 RVA: 0x000F65F0 File Offset: 0x000F47F0
	public InfoMemList ReadInfoClanList(Message msg)
	{
		InfoMemList infoMemList = null;
		InfoMemList result;
		try
		{
			short id = msg.reader().readShort();
			infoMemList = new InfoMemList((int)id);
			string chat = msg.reader().readUTF();
			string text = infoMemList.name = GameMidlet.fixString(chat);
			infoMemList.info = msg.reader().readUTF();
			infoMemList.idmap = msg.reader().readShort();
			infoMemList.rank = (int)msg.reader().readShort();
			result = infoMemList;
		}
		catch (Exception)
		{
			result = infoMemList;
		}
		return result;
	}

	// Token: 0x06000CB2 RID: 3250 RVA: 0x000F6684 File Offset: 0x000F4884
	public void Notify_Server(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			string text = msg.reader().readUTF();
			text = GameMidlet.fixString(text);
			sbyte b2 = msg.reader().readByte();
			InfoShowNotify infoShowNotify = new InfoShowNotify(text, b);
			mFont font = null;
			bool flag = b == 0;
			if (flag)
			{
				font = AvMain.setTextColor((int)b2);
			}
			bool flag2 = b == 1;
			if (flag2)
			{
				font = AvMain.setTextColorName((int)b2);
			}
			infoShowNotify.setFont(font);
			try
			{
				short num = infoShowNotify.iconClan = msg.reader().readShort();
			}
			catch (Exception)
			{
			}
			Interface_Game.addInfoServer(infoShowNotify);
			mSystem.outloi("vao day info server info=" + text);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CB3 RID: 3251 RVA: 0x000F6758 File Offset: 0x000F4958
	public void Check_Data_Ver(Message msg)
	{
		try
		{
			mSystem.outz("vao check data");
			short num = msg.reader().readShort();
			short num2 = msg.reader().readShort();
			bool flag = !GameCanvas.lowGraphic;
			if (flag)
			{
				bool flag2 = num != GlobalService.VerMonster;
				if (flag2)
				{
					GlobalService.gI().get_DATA(15);
				}
				else
				{
					DataInputStream iss = SaveRms.loadData("dataMon");
					CatalogyMonster.LoadDataMon(iss, false);
				}
				bool flag3 = num2 != GlobalService.VerPotion;
				if (flag3)
				{
					GlobalService.gI().get_DATA(28);
				}
				else
				{
					DataInputStream iss2 = SaveRms.loadData("dataPotion");
					Potion.UpdateDataPotion(iss2, false, 4);
				}
			}
			else
			{
				LoadMapScreen.isLoadDataMon = true;
			}
			short num3 = msg.reader().readShort();
			bool flag4 = num3 != GlobalService.VerNameAtribute;
			if (flag4)
			{
				GlobalService.gI().get_DATA(2);
			}
			else
			{
				DataInputStream iss3 = SaveRms.loadData("dataAttri");
				MainItem.LoadNameAttribute(iss3, false);
			}
			short num4 = msg.reader().readShort();
			short num5 = msg.reader().readShort();
			bool flag5 = num5 != GlobalService.VerNameMap;
			if (flag5)
			{
				GlobalService.gI().get_DATA(6);
			}
			else
			{
				DataInputStream iss4 = SaveRms.loadData("dataNameMap");
				LoadMap.LoadNameMap(iss4, false);
			}
			short num6 = msg.reader().readShort();
			bool flag6 = num6 != GlobalService.VerNamePotionQuest;
			if (flag6)
			{
				GlobalService.gI().get_DATA(7);
			}
			else
			{
				DataInputStream iss5 = SaveRms.loadData("dataNamePotionquest");
				MainQuest.LoadNamePotionQuest(iss5, false);
			}
			short num7 = msg.reader().readShort();
			short num8 = msg.reader().readShort();
			bool flag7 = num8 != GlobalService.VerImageSave;
			if (flag7)
			{
				bool flag8 = GlobalService.VerImageSave != -1;
				if (flag8)
				{
					GameMidlet.delRMS();
				}
				GlobalService.VerImageSave = num8;
				SaveRms.saveVer(GlobalService.VerImageSave, "VerdataImageSave");
			}
			short num9 = msg.reader().readShort();
			bool flag9 = num9 != GlobalService.VerDataUpgrade;
			if (flag9)
			{
				GlobalService.gI().get_DATA(12);
			}
			else
			{
				DataInputStream iss6 = SaveRms.loadData("dataUpgradeSave");
				MainDataUpgrade.LoadDataUpgrade(iss6, false);
			}
			short num10 = msg.reader().readShort();
			bool flag10 = num10 != GlobalService.verPotionClan;
			if (flag10)
			{
				GlobalService.gI().get_DATA(29);
			}
			else
			{
				DataInputStream iss7 = SaveRms.loadData("dataPotionClan");
				Potion.UpdateDataPotion(iss7, false, 8);
			}
			LoginScreen.isCheckData = true;
			GameCanvas.end_Dialog();
			bool flag11 = GameCanvas.currentScreen == GameCanvas.loginScr;
			if (flag11)
			{
				GameCanvas.loginScr.doLogin(false, 0, GameCanvas.loginScr.tfUser.getText(), GameCanvas.loginScr.tfPass.getText());
			}
			else
			{
				bool flag12 = GameCanvas.currentScreen == GameCanvas.fristLoginScr;
				if (flag12)
				{
					GameCanvas.fristLoginScr.setNewAcc(true);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CB4 RID: 3252 RVA: 0x000F6A74 File Offset: 0x000F4C74
	public void Open_Box(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			short idChest = -1;
			bool flag = b == 21;
			if (flag)
			{
				idChest = msg.reader().readShort();
			}
			bool isOnChestAdmin = GameScreen.isOnChestAdmin;
			if (isOnChestAdmin)
			{
				idChest = -1;
			}
			string name = msg.reader().readUTF();
			string info = msg.reader().readUTF();
			int num = (int)msg.reader().readByte();
			Item_Drop[] array = new Item_Drop[num];
			for (int i = 0; i < num; i++)
			{
				sbyte type = msg.reader().readByte();
				string name2 = msg.reader().readUTF();
				short idIcon = msg.reader().readShort();
				int num2 = msg.reader().readInt();
				sbyte color = msg.reader().readByte();
				array[i] = new Item_Drop((short)i, type, name2, 0, 0, idIcon, color);
				array[i].num = num2;
			}
			MsgShowGift msgShowGift = new MsgShowGift();
			bool flag2 = b == 23;
			if (flag2)
			{
				GameScreen.addPlayer(new Item_Drop(-1, 4, T.ruongqua, GameScreen.player.x, GameScreen.player.y, 325, 4)
				{
					mItemDrop = array
				});
			}
			else
			{
				bool flag3 = b == 24;
				if (flag3)
				{
					GameScreen.addPlayer(new Item_Drop(-1, 4, T.ruongqua, GameScreen.player.x, GameScreen.player.y, 326, 4)
					{
						mItemDrop = array
					});
				}
				else
				{
					bool flag4 = b == 22;
					if (flag4)
					{
						msgShowGift.setinfoShow_Gift_OnHead(b, name, info, array, idChest, GameScreen.player);
						GameCanvas.showDialog = msgShowGift;
					}
					else
					{
						msgShowGift.setinfoShow_Gift(b, name, info, array, idChest);
						GameCanvas.Start_Current_Dialog(msgShowGift);
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CB5 RID: 3253 RVA: 0x000F6C64 File Offset: 0x000F4E64
	public void Fight(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			bool flag = b == 0;
			if (flag)
			{
				short id = msg.reader().readShort();
				string name = msg.reader().readUTF();
				short priceFight = msg.reader().readShort();
				sbyte typeFight = 0;
				bool flag2 = msg.reader().available() > 0;
				if (flag2)
				{
					typeFight = msg.reader().readByte();
				}
				InfoMemList.setTypeEvent((int)id, 3, name, T.eventFight, (int)priceFight, (int)typeFight);
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CB6 RID: 3254 RVA: 0x000F6D00 File Offset: 0x000F4F00
	public void Buff(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			short typeBuff = msg.reader().readShort();
			short id = msg.reader().readShort();
			sbyte tem = msg.reader().readByte();
			short data = msg.reader().readShort();
			short effBuff = msg.reader().readShort();
			int timeBuff = msg.reader().readInt();
			sbyte tem2 = msg.reader().readByte();
			sbyte b2 = msg.reader().readByte();
			bool flag = b == 1;
			if (flag)
			{
				MainObject mainObject = MainObject.get_Object((int)id, tem);
				bool flag2 = mainObject != null && mainObject != GameScreen.player;
				if (flag2)
				{
					mainObject.addEffBuff(1, effBuff, 0);
				}
			}
			MainBuff mainBuff = new MainBuff(typeBuff);
			mainBuff.setTimeBuff(timeBuff);
			mainBuff.setData(data);
			mVector mVector = new mVector();
			for (int i = 0; i < (int)b2; i++)
			{
				short id2 = msg.reader().readShort();
				MainObject mainObject2 = MainObject.get_Object((int)id2, tem2);
				bool flag3 = mainObject2 == null;
				if (!flag3)
				{
					mVector.addElement(mainObject2);
					bool flag4 = mainObject2 == GameScreen.player;
					if (flag4)
					{
						sbyte b3 = msg.reader().readByte();
						for (int j = 0; j < (int)b3; j++)
						{
							MainInfoItem o = new MainInfoItem(msg.reader().readByte(), (int)msg.reader().readShort());
							mainBuff.vecInfoAtt.addElement(o);
						}
					}
					mainBuff.setObjc(mainObject2);
					mainObject2.AddBuff(mainBuff);
				}
			}
			sbyte b4 = msg.reader().readByte();
			bool flag5 = b4 == 3;
			if (flag5)
			{
				mainBuff.setDevilBuff(msg.reader().readShort(), msg.reader().readShort(), msg.reader().readShort());
				for (int k = 0; k < mVector.size(); k++)
				{
					MainObject mainObject3 = (MainObject)mVector.elementAt(k);
					mainObject3.checkBuffDevil();
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CB7 RID: 3255 RVA: 0x000F6F48 File Offset: 0x000F5148
	public void ChangeArea(Message msg)
	{
		try
		{
			LoadMapScreen.typeChangeMap = 0;
			GameCanvas.loadMapScr.Show();
			GameCanvas.loadmap.idLastMap = GameCanvas.loadmap.idMap;
			GameScreen.RemoveLoadMap();
			GameCanvas.loadMapScr.area = msg.reader().readByte();
			sbyte typeViewPlayer = msg.reader().readByte();
			GameScreen.player.posTransRoad = null;
			GameScreen.player.x = (int)msg.reader().readShort();
			GameScreen.player.y = (int)msg.reader().readShort();
			GameScreen.player.maxHp = msg.reader().readInt();
			GameScreen.player.Hp = msg.reader().readInt();
			GameScreen.player.maxMp = msg.reader().readInt();
			GameScreen.player.Mp = msg.reader().readInt();
			LoadMapScreen.IDBack = msg.reader().readByte();
			LoadMapScreen.HBack = msg.reader().readShort();
			LoadMapScreen.isNextMap = true;
			GameCanvas.gameScr.setTypeViewPlayer(typeViewPlayer);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CB8 RID: 3256 RVA: 0x000F7084 File Offset: 0x000F5284
	public void Skill_Map_Train(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			sbyte b = msg.reader().readByte();
			MainObject mainObject = MainObject.get_Object((int)id, 0);
			mainObject.mSkillMapTrain = new short[(int)b];
			for (int i = 0; i < (int)b; i++)
			{
				mainObject.mSkillMapTrain[i] = msg.reader().readShort();
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CB9 RID: 3257 RVA: 0x000F7100 File Offset: 0x000F5300
	public void AreaStatus(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			sbyte[] array = new sbyte[(int)b];
			for (int i = 0; i < (int)b; i++)
			{
				array[i] = msg.reader().readByte();
			}
			MsgArea msgArea = new MsgArea();
			msgArea.setinfoChangeArea(array, 0);
			GameCanvas.Start_Current_Dialog(msgArea);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CBA RID: 3258 RVA: 0x000F7174 File Offset: 0x000F5374
	public void Register(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			bool flag = b == 0;
			if (flag)
			{
				string info = msg.reader().readUTF();
				GameCanvas.loginScr.type = 0;
				GameCanvas.loginScr.setCmd();
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(info);
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CBB RID: 3259 RVA: 0x000F71DC File Offset: 0x000F53DC
	public void Del_Char(Message msg)
	{
		try
		{
			short num = msg.reader().readShort();
			for (int i = 0; i < ListChar_Screen.vecListChar.size(); i++)
			{
				MainObject mainObject = (MainObject)ListChar_Screen.vecListChar.elementAt(i);
				bool flag = mainObject.ID == num;
				if (flag)
				{
					mainObject.typeSpecCharList = msg.reader().readByte();
					bool flag2 = mainObject.typeSpecCharList != 0;
					if (flag2)
					{
						mainObject.timeDie = (long)msg.reader().readInt();
					}
					else
					{
						mainObject.timeDie = 0L;
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CBC RID: 3260 RVA: 0x000F728C File Offset: 0x000F548C
	public void MonsterDie(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			MainObject mainObject = MainObject.get_Object((int)id, 1);
			bool flag = mainObject != null && (mainObject.x < MainScreen.cameraMain.xCam || mainObject.x > MainScreen.cameraMain.xCam + MotherCanvas.w);
			if (flag)
			{
				mainObject.Hp = 0;
				mainObject.beginDie(null);
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CBD RID: 3261 RVA: 0x000F7310 File Offset: 0x000F5510
	public void NumItemQuest(Message msg)
	{
		try
		{
			short num = msg.reader().readShort();
			sbyte b = msg.reader().readByte();
			short num2 = msg.reader().readShort();
			short num3 = msg.reader().readShort();
			mFont font = mFont.tahoma_7_white;
			bool flag = num2 >= num3;
			if (flag)
			{
				font = mFont.tahoma_7_yellow;
			}
			bool flag2 = b == 1;
			if (flag2)
			{
				CatalogyMonster catalogyMonster = MainMonster.getCatalogyMonster((int)num);
				string str = string.Concat(new string[]
				{
					T.haguc,
					" ",
					catalogyMonster.name,
					": ",
					num2.ToString(),
					"/",
					num3.ToString()
				});
				Interface_Game.addInfoPlayerNormal(str, font);
			}
			else
			{
				bool flag3 = b == 5 && (int)num < DataQuest.nameItemQuest.Length;
				if (flag3)
				{
					string str2 = string.Concat(new string[]
					{
						T.thuthap,
						" ",
						DataQuest.nameItemQuest[(int)num],
						": ",
						num2.ToString(),
						"/",
						num3.ToString()
					});
					Interface_Game.addInfoPlayerNormal(str2, font);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CBE RID: 3262 RVA: 0x000F746C File Offset: 0x000F566C
	public void Teleport_Boss(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			sbyte b = msg.reader().readByte();
			short x = msg.reader().readShort();
			short y = msg.reader().readShort();
			MainObject mainObject = MainObject.get_Object((int)id, b);
			bool flag = mainObject != null && !mainObject.returnAction();
			if (flag)
			{
				GameScreen.addEffectEnd_ObjTo(56, 0, (int)x, (int)y, id, b, (sbyte)mainObject.Dir, mainObject);
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CBF RID: 3263 RVA: 0x000F74FC File Offset: 0x000F56FC
	public void SkillSpec(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			sbyte b = msg.reader().readByte();
			mSystem.outz("SkillSpec cat = " + b.ToString());
			mVector mVector = new mVector();
			mVector mVector2 = new mVector();
			MainObject mainObject = MainObject.get_Object((int)id, b);
			bool flag = mainObject == null || mainObject.returnAction();
			if (!flag)
			{
				short num = msg.reader().readShort();
				Object_Effect_Skill o = new Object_Effect_Skill(mainObject.ID, mainObject.typeObject);
				short timebuff = msg.reader().readShort();
				sbyte b2 = msg.reader().readByte();
				short num2 = num;
				short num3 = num2;
				if (num3 != 10014)
				{
					if (num3 != 10016)
					{
						bool flag2 = b2 != 0 && b2 != 2;
						if (flag2)
						{
							b2 = 0;
						}
						MainSkill mainSkill = new MainSkill(-1, num);
						mainSkill.setTypeBuff(2, 0, timebuff);
						short x = msg.reader().readShort();
						short y = msg.reader().readShort();
						sbyte b3 = msg.reader().readByte();
						for (int i = 0; i < (int)b3; i++)
						{
							Point_Focus o2 = new Point_Focus((int)msg.reader().readShort(), (int)msg.reader().readShort());
							mVector2.addElement(o2);
						}
						mainSkill.setPos((int)x, (int)y, mVector2, b2);
						mVector.addElement(o);
						mainObject.addSkillFire(mainSkill, mVector);
					}
					else
					{
						short num4 = msg.reader().readShort();
						short num5 = msg.reader().readShort();
						sbyte b4 = msg.reader().readByte();
						for (int j = 0; j < (int)b4; j++)
						{
							Point_Focus point_Focus = new Point_Focus((int)msg.reader().readShort(), (int)msg.reader().readShort());
							GameScreen.addEffectEnd_ObjTo(70, 0, point_Focus.x, point_Focus.y, id, b, (sbyte)mainObject.Dir, mainObject);
						}
					}
				}
				else
				{
					GameScreen.addEffectEnd_ObjTo(69, 0, 0, 0, id, b, (sbyte)mainObject.Dir, mainObject);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CC0 RID: 3264 RVA: 0x000F7748 File Offset: 0x000F5948
	public void addHP_EffSkill(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			sbyte tem = msg.reader().readByte();
			int num = msg.reader().readInt();
			int maxHp = msg.reader().readInt();
			short num2 = msg.reader().readShort();
			short time = msg.reader().readShort();
			MainObject mainObject = MainObject.get_Object((int)id, tem);
			bool flag = mainObject != null && !mainObject.returnAction();
			if (flag)
			{
				mainObject.maxHp = maxHp;
				mSystem.outz("add hp eff name=" + mainObject.name + " maxhp=" + mainObject.maxHp.ToString());
				string content = string.Empty + (num - mainObject.Hp).ToString();
				bool flag2 = num > mainObject.Hp;
				if (flag2)
				{
					content = "+" + (num - mainObject.Hp).ToString();
				}
				bool flag3 = num - mainObject.Hp != 0;
				if (flag3)
				{
					GameScreen.addEffectNum(content, mainObject.x, mainObject.y - mainObject.hOne / 4 * 3, 3);
				}
				mainObject.Hp = num;
				bool flag4 = num2 != -1;
				if (flag4)
				{
					mainObject.addEffSpec(num2, time);
				}
				bool flag5 = mainObject == GameScreen.player;
				if (flag5)
				{
					GlobalService.gI().Obj_Move((short)mainObject.x, (short)mainObject.y);
				}
				mSystem.outz(string.Concat(new string[]
				{
					"nhan update HP=",
					num.ToString(),
					"  ",
					maxHp.ToString(),
					" ideff = ",
					num2.ToString()
				}));
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CC1 RID: 3265 RVA: 0x000F7938 File Offset: 0x000F5B38
	public void SaveImageAndroid(Message msg)
	{
		try
		{
			UpdateImageScreen.curNum++;
			string name = msg.reader().readUTF();
			sbyte[] msbyte = new sbyte[msg.reader().available()];
			msg.reader().read(ref msbyte);
			SaveImageRMS.vecSaveImageAndroid.addElement(new idSaveImage(name, msbyte));
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CC2 RID: 3266 RVA: 0x000F79A8 File Offset: 0x000F5BA8
	public void resetValueUpdateImage(Message msg)
	{
		try
		{
			string text = msg.reader().readUTF();
			for (int i = 0; i < T.mStringDownload.Length; i++)
			{
				bool flag = text.CompareTo(T.mStringDownload[i]) == 0;
				if (flag)
				{
					text = T.mStringDownload[i + 1];
					break;
				}
			}
			UpdateImageScreen.setmNamePaint(T.dangtai + text);
			UpdateImageScreen.setValueUpdate(0, (int)msg.reader().readShort());
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CC3 RID: 3267 RVA: 0x000F7A38 File Offset: 0x000F5C38
	public void LoadImageAndroidOk(Message msg)
	{
		try
		{
			UpdateImageScreen.setmNamePaint(T.dangcai);
			UpdateImageScreen.statusUpdate = 3;
			UpdateImageScreen.maxNum = SaveImageRMS.vecSaveImageAndroid.size();
			GameCanvas.saveImage.start();
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CC4 RID: 3268 RVA: 0x000F7A8C File Offset: 0x000F5C8C
	public void comboSkill(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			bool flag = b <= 0;
			if (flag)
			{
				Interface_Game.isCombo = false;
				Player.indexCombo = -1;
				Interface_Game.indexEffCombo = -1;
			}
			else
			{
				Interface_Game.isCombo = true;
				Player.indexCombo = -1;
				Player.mComboSkill = new short[(int)b];
				for (int i = 0; i < (int)b; i++)
				{
					Player.mComboSkill[i] = msg.reader().readShort();
				}
				Interface_Game.timeCombo = 30;
				Interface_Game.indexEffCombo = -1;
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CC5 RID: 3269 RVA: 0x000F7B28 File Offset: 0x000F5D28
	public void ShowInfoPlayer(Message msg)
	{
		try
		{
			MainObject mainObject = new MainObject();
			mainObject.name = msg.reader().readUTF();
			mainObject.maxHp = msg.reader().readInt();
			mainObject.maxMp = msg.reader().readInt();
			mainObject.Hp = msg.reader().readInt();
			mainObject.Mp = msg.reader().readInt();
			mainObject.Lv = (int)msg.reader().readShort();
			mainObject.percentLv = (int)msg.reader().readShort();
			short headset = msg.reader().readShort();
			mainObject.sethead(headset);
			mainObject.sethair(msg.reader().readShort());
			short num = msg.reader().readShort();
			bool flag = num >= 0;
			if (flag)
			{
				mainObject.clan = new MainClan();
				mainObject.clan.ID = num;
				mainObject.clan.idIcon = msg.reader().readShort();
				string text = msg.reader().readUTF();
				text = GameMidlet.fixString(text);
				mainObject.clan.name = text;
			}
			sbyte b = msg.reader().readByte();
			mSystem.outz("size " + b.ToString());
			short[] array = new short[(int)b];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = -1;
			}
			for (int j = 0; j < (int)b; j++)
			{
				sbyte b2 = msg.reader().readByte();
				bool flag2 = b2 == 1;
				if (flag2)
				{
					MainItem v = this.readUpdateItem(msg, false);
					mainObject.hashEquip.put(string.Empty + j.ToString(), v);
					array[j] = msg.reader().readShort();
				}
				mSystem.outz(string.Concat(new string[]
				{
					"isWear ",
					b2.ToString(),
					" mWear ",
					j.ToString(),
					" = ",
					array[j].ToString()
				}));
			}
			mainObject.setWearing(array);
			sbyte b3 = msg.reader().readByte();
			short weaponFashion = msg.reader().readShort();
			bool flag3 = b3 == 0;
			if (flag3)
			{
				mainObject.weaponFashion = weaponFashion;
			}
			mainObject.indexFullSet = msg.reader().readByte();
			mSystem.outz("fullset = " + mainObject.indexFullSet.ToString());
			MsgOtherCharInfo dgl = new MsgOtherCharInfo(mainObject);
			GameCanvas.Start_Current_Dialog(dgl);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CC6 RID: 3270 RVA: 0x000F7DE8 File Offset: 0x000F5FE8
	public void loadDataEff(Message msg)
	{
		try
		{
			sbyte[] dataeff = new sbyte[msg.reader().available()];
			msg.reader().read(ref dataeff);
			EffectAuto.readData(dataeff, true);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CC7 RID: 3271 RVA: 0x000F7E38 File Offset: 0x000F6038
	public void update_Pk_Point(Message msg)
	{
		try
		{
			GameScreen.player.pointPk = msg.reader().readInt();
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CC8 RID: 3272 RVA: 0x000F7E74 File Offset: 0x000F6074
	public void setWeather(Message msg)
	{
		bool flag = GameCanvas.lowGraphic || LoadMapScreen.isSuperBoss;
		if (!flag)
		{
			try
			{
				sbyte b = msg.reader().readByte();
				sbyte level = msg.reader().readByte();
				bool flag2 = b < 0;
				if (flag2)
				{
					GameScreen.effMap = null;
				}
				else
				{
					GameScreen.effMap = new Effect_Map(b, level);
					bool flag3 = b == 9;
					if (flag3)
					{
						GameCanvas.mapBack.setDark();
						LoadMapScreen.isSuperBoss = true;
					}
					else
					{
						bool flag4 = b == 8;
						if (flag4)
						{
							bool flag5 = GameCanvas.mapBack != null;
							if (flag5)
							{
								GameCanvas.mapBack.setSkyDragon();
							}
						}
						else
						{
							bool flag6 = b == 1 && GameCanvas.mapBack != null;
							if (flag6)
							{
								GameCanvas.mapBack.setSkySnow();
							}
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x06000CC9 RID: 3273 RVA: 0x000F7F58 File Offset: 0x000F6158
	public void Upgrade_Item(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			bool flag = b != 7 && ScreenUpgrade.instance == null;
			if (flag)
			{
				ScreenUpgrade.instance = new ScreenUpgrade(5, -1);
			}
			bool flag2 = b == 0;
			if (flag2)
			{
				string info = msg.reader().readUTF();
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(info);
			}
			else
			{
				bool flag3 = b == 1;
				if (flag3)
				{
					string info2 = msg.reader().readUTF();
					int num = msg.reader().readInt();
					short num2 = msg.reader().readShort();
					ReadMessenge.idItemUpgrade = msg.reader().readShort();
					mVector mVector = new mVector();
					bool flag4 = num > 0;
					if (flag4)
					{
						iCommand iCommand = new iCommand(num.ToString() + string.Empty, 1, 1, this);
						iCommand.setFraCaption(AvMain.fraMoney, 1, 0, 0);
						mVector.addElement(iCommand);
					}
					bool flag5 = num2 > 0;
					if (flag5)
					{
						iCommand iCommand2 = new iCommand(num2.ToString() + string.Empty, 1, 2, this);
						iCommand2.setFraCaption(AvMain.fraMoney, 1, 1, 0);
						mVector.addElement(iCommand2);
					}
					iCommand o = new iCommand(T.close, 1, 0, this);
					mVector.addElement(o);
					GameCanvas.Start_Normal_DiaLog(info2, mVector, false);
				}
				else
				{
					bool flag6 = b == 2;
					if (flag6)
					{
						string showServer = msg.reader().readUTF();
						ScreenUpgrade.instance.showServer = showServer;
						ScreenUpgrade.instance.Step = 1;
					}
					else
					{
						bool flag7 = b == 3;
						if (flag7)
						{
							string showServer2 = msg.reader().readUTF();
							ScreenUpgrade.instance.showServer = showServer2;
							ScreenUpgrade.instance.Step = 2;
						}
						else
						{
							bool flag8 = b == 4;
							if (flag8)
							{
								short id = msg.reader().readShort();
								MainItem itemVec = MainItem.getItemVec(3, id, Player.vecInventory);
								bool flag9 = itemVec != null;
								if (flag9)
								{
									MainItem mainItem = new MainItem(3, itemVec.ID, itemVec.idIcon, 1, itemVec.colorName, itemVec.LvUpgrade);
									ScreenUpgrade.mItemUpgrade[0] = mainItem;
									ScreenUpgrade.instance.setDataUpgrade();
								}
								ScreenUpgrade.instance.getMenuActionItem();
							}
							else
							{
								bool flag10 = b == 5;
								if (flag10)
								{
									sbyte b2 = msg.reader().readByte();
									short id2 = msg.reader().readShort();
									bool flag11 = b2 == 0;
									if (flag11)
									{
										ScreenUpgrade.mItemUpgrade[1] = null;
										ScreenUpgrade.valueLucky = 1;
									}
									else
									{
										MainItem itemVec2 = MainItem.getItemVec(7, id2, Player.vecInventory);
										bool flag12 = itemVec2 != null;
										if (flag12)
										{
											bool flag13 = itemVec2.typeMaterial == 4;
											if (flag13)
											{
												ScreenUpgrade.valueLucky = 10;
											}
											else
											{
												bool flag14 = itemVec2.typeMaterial == 2;
												if (flag14)
												{
													ScreenUpgrade.valueLucky = 20;
												}
											}
											MainItem mainItem2 = new MainItem(7, itemVec2.ID, itemVec2.idIcon, 1, itemVec2.colorName, itemVec2.LvUpgrade);
											ScreenUpgrade.mItemUpgrade[1] = mainItem2;
										}
									}
									ScreenUpgrade.instance.getMenuActionItem();
								}
								else
								{
									bool flag15 = b == 6;
									if (flag15)
									{
										sbyte b3 = msg.reader().readByte();
										short id3 = msg.reader().readShort();
										bool flag16 = b3 == 0;
										if (flag16)
										{
											ScreenUpgrade.mItemUpgrade[2] = null;
										}
										else
										{
											MainItem itemVec3 = MainItem.getItemVec(7, id3, Player.vecInventory);
											bool flag17 = itemVec3 != null;
											if (flag17)
											{
												MainItem mainItem3 = new MainItem(7, itemVec3.ID, itemVec3.idIcon, 1, itemVec3.colorName, itemVec3.LvUpgrade);
												ScreenUpgrade.mItemUpgrade[2] = mainItem3;
											}
										}
										ScreenUpgrade.instance.getMenuActionItem();
									}
									else
									{
										bool flag18 = b == 7;
										if (flag18)
										{
											ScreenUpgrade.instance = new ScreenUpgrade(5, -1);
											ScreenUpgrade.instance.Show(GameCanvas.gameScr);
										}
										else
										{
											bool flag19 = b == 15;
											if (flag19)
											{
												bool flag20 = MsgUpdateHeart.instance == null;
												if (flag20)
												{
													MsgUpdateHeart.instance = new MsgUpdateHeart();
												}
												MsgUpdateHeart.instance.Show(GameCanvas.gameScr);
											}
											else
											{
												bool flag21 = b == 16 || b == 17;
												if (flag21)
												{
													string text = msg.reader().readUTF();
													MsgUpdateHeart.instance.updateStepUpgrade(b, text);
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CCA RID: 3274 RVA: 0x000F83C4 File Offset: 0x000F65C4
	public void UpgradeSuper_Item(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			bool flag = b != 7 && ScreenUpgrade.instance == null;
			if (flag)
			{
				ScreenUpgrade.instance = new ScreenUpgrade(15, -1);
			}
			bool flag2 = b == 0;
			if (flag2)
			{
				string info = msg.reader().readUTF();
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(info);
			}
			else
			{
				bool flag3 = b == 1;
				if (flag3)
				{
					string info2 = msg.reader().readUTF();
					int num = msg.reader().readInt();
					short num2 = msg.reader().readShort();
					ReadMessenge.idItemUpgrade = msg.reader().readShort();
					mVector mVector = new mVector();
					bool flag4 = num > 0;
					if (flag4)
					{
						iCommand iCommand = new iCommand(num.ToString() + string.Empty, 12, 1, this);
						iCommand.setFraCaption(AvMain.fraMoney, 1, 0, 0);
						mVector.addElement(iCommand);
					}
					bool flag5 = num2 > 0;
					if (flag5)
					{
						iCommand iCommand2 = new iCommand(num2.ToString() + string.Empty, 12, 2, this);
						iCommand2.setFraCaption(AvMain.fraMoney, 1, 1, 0);
						mVector.addElement(iCommand2);
					}
					iCommand o = new iCommand(T.close, 1, 0, this);
					mVector.addElement(o);
					GameCanvas.Start_Normal_DiaLog(info2, mVector, false);
				}
				else
				{
					bool flag6 = b == 2;
					if (flag6)
					{
						string showServer = msg.reader().readUTF();
						ScreenUpgrade.instance.showServer = showServer;
						ScreenUpgrade.instance.Step = 1;
					}
					else
					{
						bool flag7 = b == 3;
						if (flag7)
						{
							string showServer2 = msg.reader().readUTF();
							ScreenUpgrade.instance.showServer = showServer2;
							ScreenUpgrade.instance.Step = 2;
						}
						else
						{
							bool flag8 = b == 4;
							if (flag8)
							{
								short id = msg.reader().readShort();
								MainItem itemVec = MainItem.getItemVec(3, id, Player.vecInventory);
								bool flag9 = itemVec != null;
								if (flag9)
								{
									MainItem mainItem = new MainItem(3, itemVec.ID, itemVec.idIcon, 1, itemVec.colorName, itemVec.LvUpgrade);
									ScreenUpgrade.mItemUpgrade[0] = mainItem;
								}
								short id2 = msg.reader().readShort();
								short numPotion = msg.reader().readShort();
								MainMaterial mainMaterial = (MainMaterial)MainItem.hashMaterialTem.get(string.Empty + id2.ToString());
								MainItem mainItem2 = new MainItem(7, mainMaterial.idIcon, id2);
								mainItem2.numPotion = numPotion;
								ScreenUpgrade.mItemUpgrade[4] = mainItem2;
								short id3 = msg.reader().readShort();
								short numPotion2 = msg.reader().readShort();
								MainMaterial mainMaterial2 = (MainMaterial)MainItem.hashMaterialTem.get(string.Empty + id3.ToString());
								MainItem mainItem3 = new MainItem(7, mainMaterial2.idIcon, id3);
								mainItem3.numPotion = numPotion2;
								ScreenUpgrade.mItemUpgrade[5] = mainItem3;
							}
							else
							{
								bool flag10 = b == 5;
								if (flag10)
								{
									sbyte b2 = msg.reader().readByte();
									short id4 = msg.reader().readShort();
									bool flag11 = b2 == 0;
									if (flag11)
									{
										ScreenUpgrade.mItemUpgrade[1] = null;
										ScreenUpgrade.valueLucky = 1;
									}
									else
									{
										MainItem itemVec2 = MainItem.getItemVec(7, id4, Player.vecInventory);
										bool flag12 = itemVec2 != null;
										if (flag12)
										{
											bool flag13 = itemVec2.typeMaterial == 4;
											if (flag13)
											{
												ScreenUpgrade.valueLucky = 10;
											}
											else
											{
												bool flag14 = itemVec2.typeMaterial == 2;
												if (flag14)
												{
													ScreenUpgrade.valueLucky = 20;
												}
											}
											MainItem mainItem4 = new MainItem(7, itemVec2.ID, itemVec2.idIcon, 1, itemVec2.colorName, itemVec2.LvUpgrade);
											ScreenUpgrade.mItemUpgrade[1] = mainItem4;
										}
									}
									ScreenUpgrade.instance.getMenuActionItem();
								}
								else
								{
									bool flag15 = b == 6;
									if (flag15)
									{
										sbyte b3 = msg.reader().readByte();
										short id5 = msg.reader().readShort();
										sbyte numPotion3 = msg.reader().readByte();
										bool flag16 = b3 == 0;
										if (flag16)
										{
											ScreenUpgrade.mItemUpgrade[2] = null;
										}
										else
										{
											MainItem itemVec3 = MainItem.getItemVec(7, id5, Player.vecInventory);
											bool flag17 = itemVec3 != null;
											if (flag17)
											{
												MainItem mainItem5 = new MainItem(7, itemVec3.ID, itemVec3.idIcon, 1, itemVec3.colorName, itemVec3.LvUpgrade);
												mainItem5.numPotion = (short)numPotion3;
												ScreenUpgrade.mItemUpgrade[2] = mainItem5;
											}
										}
										ScreenUpgrade.instance.getMenuActionItem();
									}
									else
									{
										bool flag18 = b == 14;
										if (flag18)
										{
											sbyte b4 = msg.reader().readByte();
											short id6 = msg.reader().readShort();
											bool flag19 = b4 == 0;
											if (flag19)
											{
												ScreenUpgrade.mItemUpgrade[3] = null;
											}
											else
											{
												MainItem itemVec4 = MainItem.getItemVec(7, id6, Player.vecInventory);
												bool flag20 = itemVec4 != null;
												if (flag20)
												{
													MainItem mainItem6 = new MainItem(7, itemVec4.ID, itemVec4.idIcon, 1, itemVec4.colorName, itemVec4.LvUpgrade);
													ScreenUpgrade.mItemUpgrade[3] = mainItem6;
												}
											}
											ScreenUpgrade.instance.getMenuActionItem();
										}
										else
										{
											bool flag21 = b == 7;
											if (flag21)
											{
												ScreenUpgrade.instance = new ScreenUpgrade(15, -1);
												ScreenUpgrade.instance.Show(GameCanvas.gameScr);
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CCB RID: 3275 RVA: 0x000F8924 File Offset: 0x000F6B24
	public void Upgrade_Dial(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			mSystem.outz("nhan type upgrade dial =" + b.ToString());
			bool flag = b != 7 && ScreenUpgrade.instance == null;
			if (flag)
			{
				ScreenUpgrade.instance = new ScreenUpgrade(18, -1);
			}
			bool flag2 = b == 0;
			if (flag2)
			{
				string info = msg.reader().readUTF();
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(info);
			}
			else
			{
				bool flag3 = b == 7;
				if (flag3)
				{
					ScreenUpgrade.instance = new ScreenUpgrade(18, -1);
					ScreenUpgrade.instance.Show(GameCanvas.gameScr);
				}
				else
				{
					bool flag4 = b == 4;
					if (flag4)
					{
						short id = msg.reader().readShort();
						MainItem itemVec = MainItem.getItemVec(3, id, Player.vecInventory);
						bool flag5 = itemVec != null;
						if (flag5)
						{
							MainItem mainItem = new MainItem(3, itemVec.ID, itemVec.idIcon, 1, itemVec.colorName, itemVec.LvUpgrade);
							ScreenUpgrade.mItemUpgrade[0] = mainItem;
						}
						sbyte b2 = msg.reader().readByte();
						for (int i = 1; i <= (int)b2; i++)
						{
							short id2 = msg.reader().readShort();
							short numPotion = msg.reader().readShort();
							MainMaterial mainMaterial = (MainMaterial)MainItem.hashMaterialTem.get(string.Empty + id2.ToString());
							MainItem mainItem2 = new MainItem(7, mainMaterial.idIcon, id2);
							mainItem2.numPotion = numPotion;
							ScreenUpgrade.mItemUpgrade[ScreenUpgrade.mItemUpgrade.Length - i] = mainItem2;
						}
						int valueMonney_ = msg.reader().readInt();
						int valueMonney_2 = msg.reader().readInt();
						int valueMonney_3 = msg.reader().readInt();
						sbyte b3 = msg.reader().readByte();
						ScreenUpgrade.instance.valueTileRotCap = (int)b3;
						ScreenUpgrade.instance.valueBaoHiem = 0;
						ScreenUpgrade.instance.valueMayMan = 0;
						ScreenUpgrade.instance.setInfo_money((int)b3, valueMonney_, valueMonney_2, valueMonney_3);
						ScreenUpgrade.instance.getMenuActionItem();
					}
					else
					{
						bool flag6 = b == 1;
						if (flag6)
						{
							string info2 = msg.reader().readUTF();
							ReadMessenge.idItemUpgrade = msg.reader().readShort();
							mVector mVector = new mVector();
							iCommand o = new iCommand(T.chapnhan, 18, 0, this);
							mVector.addElement(o);
							iCommand o2 = new iCommand(T.close, 1, 0, this);
							mVector.addElement(o2);
							GameCanvas.Start_Normal_DiaLog(info2, mVector, false);
						}
						else
						{
							bool flag7 = b == 2;
							if (flag7)
							{
								string showServer = msg.reader().readUTF();
								ScreenUpgrade.instance.showServer = showServer;
								ScreenUpgrade.instance.Step = 1;
							}
							else
							{
								bool flag8 = b == 3;
								if (flag8)
								{
									string showServer2 = msg.reader().readUTF();
									ScreenUpgrade.instance.showServer = showServer2;
									ScreenUpgrade.instance.Step = 2;
								}
								else
								{
									bool flag9 = b == 5;
									if (flag9)
									{
										sbyte b4 = msg.reader().readByte();
										short id3 = msg.reader().readShort();
										sbyte numPotion2 = msg.reader().readByte();
										bool flag10 = b4 == 0;
										if (flag10)
										{
											ScreenUpgrade.mItemUpgrade[1] = null;
											ScreenUpgrade.valueLucky = 1;
										}
										else
										{
											MainItem itemVec2 = MainItem.getItemVec(7, id3, Player.vecInventory);
											bool flag11 = itemVec2 != null;
											if (flag11)
											{
												MainItem mainItem3 = new MainItem(7, itemVec2.ID, itemVec2.idIcon, 1, itemVec2.colorName, itemVec2.LvUpgrade);
												mainItem3.numPotion = (short)numPotion2;
												ScreenUpgrade.mItemUpgrade[1] = mainItem3;
											}
										}
										ScreenUpgrade.instance.valueMayMan = (int)msg.reader().readByte();
										ScreenUpgrade.instance.getMenuActionItem();
									}
									else
									{
										bool flag12 = b == 6;
										if (flag12)
										{
											sbyte b5 = msg.reader().readByte();
											short id4 = msg.reader().readShort();
											sbyte numPotion3 = msg.reader().readByte();
											bool flag13 = b5 == 0;
											if (flag13)
											{
												ScreenUpgrade.mItemUpgrade[2] = null;
											}
											else
											{
												MainItem itemVec3 = MainItem.getItemVec(7, id4, Player.vecInventory);
												bool flag14 = itemVec3 != null;
												if (flag14)
												{
													MainItem mainItem4 = new MainItem(7, itemVec3.ID, itemVec3.idIcon, 1, itemVec3.colorName, itemVec3.LvUpgrade);
													mainItem4.numPotion = (short)numPotion3;
													ScreenUpgrade.mItemUpgrade[2] = mainItem4;
												}
											}
											ScreenUpgrade.instance.valueBaoHiem = (int)msg.reader().readByte();
											ScreenUpgrade.instance.getMenuActionItem();
											mSystem.outz(" valueBaoHiem = " + ScreenUpgrade.instance.valueBaoHiem.ToString());
										}
										else
										{
											bool flag15 = b != 14;
											if (!flag15)
											{
												sbyte b6 = msg.reader().readByte();
												short id5 = msg.reader().readShort();
												bool flag16 = b6 == 0;
												if (flag16)
												{
													ScreenUpgrade.mItemUpgrade[3] = null;
												}
												else
												{
													MainItem itemVec4 = MainItem.getItemVec(7, id5, Player.vecInventory);
													bool flag17 = itemVec4 != null;
													if (flag17)
													{
														MainItem mainItem5 = new MainItem(7, itemVec4.ID, itemVec4.idIcon, 1, itemVec4.colorName, itemVec4.LvUpgrade);
														ScreenUpgrade.mItemUpgrade[3] = mainItem5;
													}
												}
												ScreenUpgrade.instance.getMenuActionItem();
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CCC RID: 3276 RVA: 0x000F8E8C File Offset: 0x000F708C
	public void Upgrade_Skin(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			mSystem.outz("nhan type upgrade skin =" + b.ToString());
			bool flag = b == 0;
			if (flag)
			{
				sbyte b2 = msg.reader().readByte();
				sbyte b3 = msg.reader().readByte();
				mSystem.outz("size skin " + b3.ToString());
				mVector mVector = new mVector();
				for (int i = 0; i < (int)b3; i++)
				{
					short id = msg.reader().readShort();
					string text = msg.reader().readUTF();
					string info = msg.reader().readUTF();
					short idicon = msg.reader().readShort();
					sbyte lvUpgrade = msg.reader().readByte();
					mSystem.outz(string.Concat(new string[]
					{
						id.ToString(),
						" ",
						text,
						" ",
						idicon.ToString(),
						" ",
						lvUpgrade.ToString()
					}));
					ItemFashion itemFashion = new ItemFashion(id, idicon, text, info, null);
					itemFashion.isShop = false;
					itemFashion.LvUpgrade = lvUpgrade;
					itemFashion.setInfoPotion(itemFashion.info);
					bool flag2 = itemFashion.ID == Player.idFashion;
					if (flag2)
					{
						itemFashion.addInfoFrist(T.daTrangBi, 4);
						itemFashion.colorName = 4;
					}
					else
					{
						itemFashion.addInfoFrist(T.dasuhuu, 1);
						itemFashion.colorName = 1;
					}
					mVector.addElement(itemFashion);
				}
				b3 = msg.reader().readByte();
				mSystem.outz("size da kham " + b3.ToString());
				mVector mVector2 = new mVector();
				for (int j = 0; j < (int)b3; j++)
				{
					b2 = msg.reader().readByte();
					short num = msg.reader().readShort();
					short num2 = msg.reader().readShort();
					string text2 = msg.reader().readUTF();
					short idIcon = msg.reader().readShort();
					mSystem.outz(string.Concat(new string[]
					{
						b2.ToString(),
						" ",
						num.ToString(),
						" ",
						num2.ToString(),
						" ",
						text2,
						" ",
						idIcon.ToString()
					}));
					bool flag3 = b2 == 4;
					if (flag3)
					{
						mVector2.addElement(new Potion(b2, num, idIcon, text2, 0)
						{
							numPotion = num2
						});
					}
					else
					{
						bool flag4 = b2 == 7;
						if (flag4)
						{
							MainMaterial mainMaterial = (MainMaterial)MainItem.hashMaterialTem.get(string.Empty + num.ToString());
							MainMaterial o = new MainMaterial(7, (sbyte)num, mainMaterial.name, mainMaterial.typeMaterial, (sbyte)mainMaterial.idIcon, num2, mainMaterial.price, mainMaterial.priceRuby, mainMaterial.isTrade);
							mVector2.addElement(o);
						}
					}
				}
				SkinUpgradeScreen.instance = new SkinUpgradeScreen(22, -1, mVector, mVector2);
				SkinUpgradeScreen.instance.Show(GameCanvas.gameScr);
			}
			else
			{
				bool flag5 = b == 1;
				if (flag5)
				{
					sbyte b4 = msg.reader().readByte();
					short id2 = msg.reader().readShort();
					sbyte perSuc = msg.reader().readByte();
					sbyte b5 = msg.reader().readByte();
					sbyte b6 = msg.reader().readByte();
					mSystem.outz(string.Concat(new string[]
					{
						"nhan upgrade skin ",
						b4.ToString(),
						" ",
						id2.ToString(),
						" ",
						perSuc.ToString(),
						" posItem ",
						b5.ToString(),
						" ",
						b6.ToString()
					}));
					bool flag6 = b6 == 0;
					if (flag6)
					{
						ScreenUpgrade.mItemUpgrade[(int)b5] = null;
					}
					else
					{
						MainItem mainItem = (b4 != 105) ? MainItem.getItemVec(b4, id2, SkinUpgradeScreen.vecDa) : MainItem.getItemVec(b4, id2, SkinUpgradeScreen.vecSkin);
						bool flag7 = mainItem != null;
						if (flag7)
						{
							MainItem mainItem2 = new MainItem(b4, mainItem.ID, mainItem.idIcon, 1, mainItem.colorName, mainItem.LvUpgrade);
							mainItem2.perSuc = perSuc;
							ScreenUpgrade.mItemUpgrade[(int)b5] = mainItem2;
						}
					}
					int valueMonney_ = msg.reader().readInt();
					short valueMonney_2 = msg.reader().readShort();
					int valueMonney_3 = msg.reader().readInt();
					mSystem.outz(string.Concat(new string[]
					{
						"set money ",
						valueMonney_.ToString(),
						" ",
						valueMonney_2.ToString(),
						" ",
						valueMonney_3.ToString()
					}));
					SkinUpgradeScreen.instance.setInfo_money(valueMonney_, valueMonney_2, valueMonney_3);
					SkinUpgradeScreen.instance.getMenuActionItem();
					SkinUpgradeScreen.instance.SetValueMayMan();
				}
				else
				{
					bool flag8 = b == 4;
					if (flag8)
					{
						string text3 = msg.reader().readUTF();
						ReadMessenge.idItemUpgrade = msg.reader().readShort();
						mSystem.outz(ReadMessenge.idItemUpgrade.ToString() + " " + text3);
						mVector mVector3 = new mVector();
						iCommand o2 = new iCommand(T.chapnhan, 15, 0, SkinUpgradeScreen.instance);
						mVector3.addElement(o2);
						iCommand o3 = new iCommand(T.close, 1, 0, this);
						mVector3.addElement(o3);
						GameCanvas.Start_Normal_DiaLog(text3, mVector3, false);
					}
					else
					{
						bool flag9 = b == 3;
						if (flag9)
						{
							sbyte b7 = msg.reader().readByte();
							short num3 = msg.reader().readShort();
							sbyte b8 = msg.reader().readByte();
							string text4 = msg.reader().readUTF();
							mSystem.outz(string.Concat(new string[]
							{
								"ACTION_SUCC ",
								b7.ToString(),
								" ",
								num3.ToString(),
								" ",
								b8.ToString(),
								" ",
								text4
							}));
							SkinUpgradeScreen.instance.showServer = text4;
							bool flag10 = b7 == 0;
							if (flag10)
							{
								SkinUpgradeScreen.instance.Step = 1;
							}
							else
							{
								SkinUpgradeScreen.instance.Step = 2;
							}
						}
						else
						{
							bool flag11 = b == 5;
							if (flag11)
							{
								mSystem.outz("nhan type upgrade skin = ACTION_UPDATE_LIST" + b.ToString());
								sbyte b9 = msg.reader().readByte();
								sbyte b10 = msg.reader().readByte();
								mSystem.outz("size skin " + b10.ToString());
								mVector mVector4 = new mVector();
								for (int k = 0; k < (int)b10; k++)
								{
									short id3 = msg.reader().readShort();
									string text5 = msg.reader().readUTF();
									string info2 = msg.reader().readUTF();
									short idicon2 = msg.reader().readShort();
									sbyte lvUpgrade2 = msg.reader().readByte();
									mSystem.outz(string.Concat(new string[]
									{
										id3.ToString(),
										" ",
										text5,
										" ",
										idicon2.ToString(),
										" ",
										lvUpgrade2.ToString()
									}));
									ItemFashion itemFashion2 = new ItemFashion(id3, idicon2, text5, info2, null);
									itemFashion2.isShop = false;
									itemFashion2.LvUpgrade = lvUpgrade2;
									itemFashion2.setInfoPotion(itemFashion2.info);
									bool flag12 = itemFashion2.ID == Player.idFashion;
									if (flag12)
									{
										itemFashion2.addInfoFrist(T.daTrangBi, 4);
										itemFashion2.colorName = 4;
									}
									else
									{
										itemFashion2.addInfoFrist(T.dasuhuu, 1);
										itemFashion2.colorName = 1;
									}
									mVector4.addElement(itemFashion2);
								}
								b10 = msg.reader().readByte();
								mSystem.outz("size da kham " + b10.ToString());
								mVector mVector5 = new mVector();
								for (int l = 0; l < (int)b10; l++)
								{
									b9 = msg.reader().readByte();
									short num4 = msg.reader().readShort();
									short num5 = msg.reader().readShort();
									string text6 = msg.reader().readUTF();
									short idIcon2 = msg.reader().readShort();
									mSystem.outz(string.Concat(new string[]
									{
										num4.ToString(),
										" ",
										num5.ToString(),
										" ",
										text6,
										" ",
										idIcon2.ToString()
									}));
									bool flag13 = b9 == 4;
									if (flag13)
									{
										mVector5.addElement(new Potion(b9, num4, idIcon2, text6, 0)
										{
											numPotion = num5
										});
									}
									else
									{
										bool flag14 = b9 == 7;
										if (flag14)
										{
											MainMaterial mainMaterial2 = (MainMaterial)MainItem.hashMaterialTem.get(string.Empty + num4.ToString());
											MainMaterial o4 = new MainMaterial(7, (sbyte)num4, mainMaterial2.name, mainMaterial2.typeMaterial, (sbyte)mainMaterial2.idIcon, num5, mainMaterial2.price, mainMaterial2.priceRuby, mainMaterial2.isTrade);
											mVector5.addElement(o4);
										}
									}
								}
								SkinUpgradeScreen.vecSkin = mVector4;
								SkinUpgradeScreen.vecDa = mVector5;
							}
							else
							{
								bool flag15 = b == 6;
								if (flag15)
								{
									SkinUpgradeScreen.instance.valueMayMan = (int)msg.reader().readByte();
									mSystem.outz("valueMayMan " + SkinUpgradeScreen.instance.valueMayMan.ToString());
								}
							}
						}
					}
				}
			}
			mSystem.outz("DONE nhan type upgrade skin =" + b.ToString());
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CCD RID: 3277 RVA: 0x000F98B0 File Offset: 0x000F7AB0
	public void Split_Join_Item(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			bool flag = b == 0;
			if (flag)
			{
				this.Split_Item(msg);
			}
			else
			{
				bool flag2 = b == 1;
				if (flag2)
				{
					this.Join_Item(msg);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CCE RID: 3278 RVA: 0x000F990C File Offset: 0x000F7B0C
	public void Split_Item(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			bool flag = b != 3 && SplitScreen.instance == null;
			if (flag)
			{
				SplitScreen.instance = new SplitScreen(0, -1);
			}
			bool flag2 = b == 0;
			if (flag2)
			{
				short id = msg.reader().readShort();
				sbyte b2 = msg.reader().readByte();
				short num = msg.reader().readShort();
				MainItem itemVec = MainItem.getItemVec(b2, id, Player.vecInventory);
				bool flag3 = itemVec != null;
				if (flag3)
				{
					sbyte color = itemVec.colorName;
					bool flag4 = b2 != 3;
					if (flag4)
					{
						color = 5;
					}
					MainItem mainItem = new MainItem(b2, itemVec.ID, itemVec.idIcon, num, color, itemVec.LvUpgrade);
					ScreenUpgrade.mItemUpgrade[0] = mainItem;
					ScreenUpgrade.mItemUpgrade[1] = null;
				}
			}
			else
			{
				bool flag5 = b == 1;
				if (flag5)
				{
					string showServer = msg.reader().readUTF();
					SplitScreen.instance.showServer = showServer;
					short id2 = msg.reader().readShort();
					sbyte b3 = msg.reader().readByte();
					short num2 = msg.reader().readShort();
					MainItem itemVec2 = MainItem.getItemVec(b3, id2, Player.vecInventory);
					bool flag6 = itemVec2 != null;
					if (flag6)
					{
						sbyte color2 = itemVec2.colorName;
						bool flag7 = b3 != 3;
						if (flag7)
						{
							color2 = 5;
						}
						MainItem mainItem2 = new MainItem(itemVec2.typeObject, itemVec2.ID, itemVec2.idIcon, num2, color2, itemVec2.LvUpgrade);
						ScreenUpgrade.mItemUpgrade[1] = mainItem2;
						ScreenUpgrade.mItemUpgrade[1].isRemove = true;
						SplitScreen.instance.Step = 1;
					}
				}
				else
				{
					bool flag8 = b == 3;
					if (flag8)
					{
						SplitScreen.instance = new SplitScreen(0, -1);
						SplitScreen.instance.Show(GameCanvas.gameScr);
					}
					else
					{
						bool flag9 = b == 2;
						if (flag9)
						{
							string info = msg.reader().readUTF();
							GameCanvas.Start_Normal_Only_CmdClose_DiaLog(info);
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CCF RID: 3279 RVA: 0x000F9B2C File Offset: 0x000F7D2C
	public void Join_Item(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			bool flag = b == 0;
			if (flag)
			{
				string info = msg.reader().readUTF();
				sbyte b2 = msg.reader().readByte();
				MainItem[] array = new MainItem[(int)b2];
				for (int i = 0; i < (int)b2; i++)
				{
					array[i] = new MainItem();
					short num = msg.reader().readShort();
					sbyte b3 = msg.reader().readByte();
					short num2 = msg.reader().readShort();
					MainMaterial mainMaterial = null;
					bool flag2 = b3 == 7;
					if (flag2)
					{
						mainMaterial = (MainMaterial)MainItem.hashMaterialTem.get(string.Empty + num.ToString());
					}
					bool flag3 = mainMaterial != null;
					if (flag3)
					{
						sbyte color = mainMaterial.colorName;
						bool flag4 = b3 != 3;
						if (flag4)
						{
							color = 5;
						}
						MainItem mainItem = array[i] = new MainItem(b3, mainMaterial.ID, mainMaterial.idIcon, num2, color, mainMaterial.LvUpgrade);
					}
				}
				bool flag5 = ScreenJoinItem.instance == null;
				if (flag5)
				{
					ScreenJoinItem.instance = new ScreenJoinItem();
				}
				ScreenJoinItem.instance.setInfoJoin(info, array);
				ScreenJoinItem.instance.Show(GameCanvas.gameScr);
			}
			else
			{
				bool flag6 = b == 1;
				if (flag6)
				{
					GameCanvas.end_Dialog();
					sbyte ishardcode = 0;
					string text = msg.reader().readUTF();
					short num3 = msg.reader().readShort();
					sbyte b4 = msg.reader().readByte();
					bool flag7 = b4 == 7 && num3 == 8;
					if (flag7)
					{
						ishardcode = 1;
					}
					short num4 = msg.reader().readShort();
					MainMaterial mainMaterial2 = null;
					MainItem mainItem2 = null;
					bool flag8 = b4 == 7;
					if (flag8)
					{
						mainMaterial2 = (MainMaterial)MainItem.hashMaterialTem.get(string.Empty + num3.ToString());
					}
					bool flag9 = mainMaterial2 != null;
					if (flag9)
					{
						sbyte color2 = mainMaterial2.colorName;
						bool flag10 = b4 != 3;
						if (flag10)
						{
							color2 = 5;
						}
						mainItem2 = new MainItem(b4, mainMaterial2.ID, mainMaterial2.idIcon, num4, color2, mainMaterial2.LvUpgrade);
					}
					bool flag11 = ScreenJoinItem.instance == null;
					if (flag11)
					{
						ScreenJoinItem.instance = new ScreenJoinItem();
					}
					bool flag12 = mainItem2 != null;
					if (flag12)
					{
						ScreenJoinItem.instance.setItemJoin(mainItem2, ishardcode);
					}
				}
				else
				{
					bool flag13 = b == 2;
					if (flag13)
					{
						string info2 = msg.reader().readUTF();
						GameCanvas.Start_Normal_Only_CmdClose_DiaLog(info2);
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CD0 RID: 3280 RVA: 0x000F9DE8 File Offset: 0x000F7FE8
	public void Trade(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			sbyte b2 = msg.reader().readByte();
			bool flag = b != 0 && TradeScreen.instance == null;
			if (flag)
			{
				TradeScreen.instance = new TradeScreen(6, 1);
			}
			bool flag2 = b == 0;
			if (flag2)
			{
				string nameObjTrade = msg.reader().readUTF();
				TradeScreen.instance = new TradeScreen(6, 1);
				TradeScreen.instance.setNameObjTrade(nameObjTrade);
				TradeScreen.instance.Show(GameCanvas.gameScr);
			}
			else
			{
				bool flag3 = b == 1;
				if (flag3)
				{
					sbyte b3 = msg.reader().readByte();
					bool flag4 = b3 == 6;
					if (flag4)
					{
						int num = msg.reader().readInt();
						bool flag5 = b2 == 0;
						if (flag5)
						{
							TradeScreen.instance.objMain.beli = (long)num;
						}
						else
						{
							bool flag6 = b2 == 1;
							if (flag6)
							{
								TradeScreen.instance.objTrade.beli = (long)num;
							}
						}
					}
					else
					{
						sbyte b4 = msg.reader().readByte();
						MainItem mainItem = null;
						bool flag7 = b4 == 1;
						if (flag7)
						{
							bool flag8 = b3 == 3;
							if (flag8)
							{
								mainItem = this.readUpdateItem(msg, false);
							}
							bool flag9 = b3 == 7;
							if (flag9)
							{
								mainItem = this.readUpdateMaterial(msg, false);
							}
							bool flag10 = b3 == 4;
							if (flag10)
							{
								mainItem = this.readUpdatePotion(msg, false, b3);
							}
						}
						else
						{
							bool flag11 = b4 == 0;
							if (flag11)
							{
								short id = msg.reader().readShort();
								mainItem = new MainItem(b3, id, 0, 1, 0, 0);
							}
						}
						bool flag12 = mainItem != null;
						if (flag12)
						{
							TradeScreen.instance.setItem(b2, b4, mainItem);
						}
					}
				}
				else
				{
					bool flag13 = b == 3;
					if (flag13)
					{
						bool flag14 = b2 == 0;
						if (flag14)
						{
							TradeScreen.instance.objMain.isTrade = 1;
							TradeScreen.instance.setLock();
						}
						else
						{
							bool flag15 = b2 == 1;
							if (flag15)
							{
								TradeScreen.instance.objTrade.isTrade = 1;
							}
						}
					}
					else
					{
						bool flag16 = b == 4;
						if (flag16)
						{
							bool flag17 = b2 == 0;
							if (flag17)
							{
								TradeScreen.instance.objMain.isTrade = 2;
								TradeScreen.instance.setTrade();
							}
							else
							{
								bool flag18 = b2 == 1;
								if (flag18)
								{
									TradeScreen.instance.objTrade.isTrade = 2;
								}
							}
						}
						else
						{
							bool flag19 = b == 2;
							if (flag19)
							{
								string strChatPopup = msg.reader().readUTF();
								bool flag20 = b2 == 0;
								if (flag20)
								{
									TradeScreen.instance.objMain.strChatPopup = strChatPopup;
								}
								else
								{
									bool flag21 = b2 == 1;
									if (flag21)
									{
										TradeScreen.instance.objTrade.strChatPopup = strChatPopup;
									}
								}
							}
							else
							{
								bool flag22 = b == 5;
								if (flag22)
								{
									string info = msg.reader().readUTF();
									GameCanvas.gameScr.Show();
									GameCanvas.Start_Normal_Only_CmdClose_DiaLog(info);
								}
								else
								{
									bool flag23 = b == 6;
									if (flag23)
									{
										short id2 = msg.reader().readShort();
										string name = msg.reader().readUTF();
										InfoMemList.setTypeEvent((int)id2, 4, name, T.eventTrade, 0, 0);
									}
								}
							}
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CD1 RID: 3281 RVA: 0x000FA12C File Offset: 0x000F832C
	public void Ship(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			string info = msg.reader().readUTF();
			bool flag = b == 0;
			if (flag)
			{
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(info);
				short id = msg.reader().readShort();
				MainTabShop.itemShipCur = new MainItem(4, -1, id);
				bool flag2 = GameCanvas.currentScreen == GameCanvas.tabShopScr;
				if (flag2)
				{
					MainTabShop.isUpdateItemShip = true;
				}
			}
			else
			{
				bool flag3 = b == 1;
				if (flag3)
				{
					bool flag4 = GameCanvas.currentScreen == GameCanvas.tabShopScr;
					if (flag4)
					{
						GameCanvas.gameScr.Show();
					}
					GameCanvas.Start_Normal_Only_CmdClose_DiaLog(info);
				}
				else
				{
					bool flag5 = b == 2;
					if (flag5)
					{
						GameCanvas.Start_Normal_Only_CmdClose_DiaLog(info);
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CD2 RID: 3282 RVA: 0x000FA1FC File Offset: 0x000F83FC
	public void Help_From_Server(Message msg)
	{
		try
		{
			short num = msg.reader().readShort();
			MainObject mainObject = MainObject.get_Object((int)num, 2);
			bool flag = mainObject != null && !mainObject.isRemove;
			if (flag)
			{
				string original = msg.reader().readUTF();
				MainObject.strHelp = mFont.split(original, "\b");
				MainObject.StepHelp = 0;
				mVector mVector = new mVector();
				iCommand o = new iCommand(T.next, 3, (int)num, this);
				mVector.addElement(o);
				GameCanvas.menu.startAt_NPC(mVector, MainObject.strHelp[0], (int)num, 2, true, 2, false);
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CD3 RID: 3283 RVA: 0x000FA2A8 File Offset: 0x000F84A8
	public void ghost(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			bool flag = b <= 0;
			if (flag)
			{
				Player.isGhost = false;
				GameScreen.addEffectEnd(84, 0, GameScreen.player.x, GameScreen.player.y - 70, (sbyte)GameScreen.player.Dir, GameScreen.player);
				ObjectData.hashImageItemOther.remove(string.Empty + 999.ToString());
			}
			else
			{
				ObjectData.hashImageItemOther.remove(string.Empty + 999.ToString());
				GameScreen.player.resetAction();
				Player.isGhost = true;
				Player.vecGhostInput.removeAllElements();
				InfoShowNotify infoShowNotify = new InfoShowNotify(T.ghost, 0);
				mFont font = AvMain.setTextColor(0);
				infoShowNotify.setFont(font);
				Interface_Game.addInfoServer(infoShowNotify);
				ObjectData.getImageAll(999, ObjectData.hashImageItemOther, 9000);
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CD4 RID: 3284 RVA: 0x000FA3C0 File Offset: 0x000F85C0
	public void Boat_In_Map(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			for (int i = 0; i < (int)b; i++)
			{
				Boat boat = new Boat(msg.reader().readShort(), (int)msg.reader().readShort(), (int)msg.reader().readShort(), 0, 2);
				ReadMessenge.yBoatMap = boat.y;
				sbyte b2 = msg.reader().readByte();
				bool flag = b2 > 0;
				if (flag)
				{
					short[] array = new short[(int)b2];
					for (int j = 0; j < array.Length; j++)
					{
						array[j] = msg.reader().readShort();
					}
					boat.mPartImage = array;
				}
				GameScreen.addBoatVec_And_mItem(boat, false);
			}
			bool flag2 = GameScreen.player.boatSea != null;
			if (flag2)
			{
				for (int k = 0; k < GameScreen.vecBoat.size(); k++)
				{
					Boat boat2 = (Boat)GameScreen.vecBoat.elementAt(k);
					bool flag3 = boat2.ID == GameScreen.player.boatSea.ID;
					if (flag3)
					{
						GameScreen.removeBoatVec_And_mItem(boat2);
						break;
					}
				}
			}
			CRes.quickSort(LoadMap.mItemMap[3]);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CD5 RID: 3285 RVA: 0x000FA528 File Offset: 0x000F8728
	public void Ok_Change_Map_Link(Message msg)
	{
		try
		{
			bool flag = Player.AutoFireCur <= 0 && GameScreen.player.Action == 0;
			if (flag)
			{
				GlobalService.gI().OkChangeMapLink();
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CD6 RID: 3286 RVA: 0x000FA578 File Offset: 0x000F8778
	public void CMD_test(Message msg)
	{
		try
		{
			ReadMessenge.mtest = new sbyte[msg.reader().available()];
			msg.reader().read(ref ReadMessenge.mtest);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CD7 RID: 3287 RVA: 0x000FA5C8 File Offset: 0x000F87C8
	public void Frist_Login(Message msg)
	{
		try
		{
			string text = msg.reader().readUTF();
			mSystem.outz("CMd -57 team str=" + text);
			ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
			DataOutputStream dataOutputStream = new DataOutputStream(byteArrayOutputStream);
			dataOutputStream.writeUTF(text);
			dataOutputStream.writeByte((sbyte)GameCanvas.IndexServer);
			CRes.saveRMS("MAIN_frist_login", byteArrayOutputStream.toByteArray());
			dataOutputStream.close();
			GameMidlet.delRMS("MAIN_user_pass");
			GameCanvas.loginScr.tfUser.setText(string.Empty);
			GameCanvas.loginScr.tfPass.setText(string.Empty);
			GameMidlet.delRMS("MAIN_user_last");
			SaveRms.userLast = string.Empty;
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CD8 RID: 3288 RVA: 0x000FA690 File Offset: 0x000F8890
	public void Input_server(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			string name = msg.reader().readUTF();
			sbyte b = msg.reader().readByte();
			string[] array = new string[(int)b];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = msg.reader().readUTF();
			}
			GameCanvas.subDialog = GameCanvas.Start_Input_Dialog_Server(array, name, id);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CD9 RID: 3289 RVA: 0x000FA718 File Offset: 0x000F8918
	public void Update_User_Ok(Message msg)
	{
		try
		{
			string text = msg.reader().readUTF();
			string text2 = msg.reader().readUTF();
			GameCanvas.saveRms.saveUserPass(text, text2);
			GameMidlet.delRMS("MAIN_frist_login");
			GameCanvas.Start_Normal_Only_CmdClose_DiaLog(string.Concat(new string[]
			{
				T.registerOk,
				"\n",
				T.username,
				": ",
				text,
				"\n",
				T.password,
				": ",
				text2
			}));
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CDA RID: 3290 RVA: 0x000FA7C4 File Offset: 0x000F89C4
	public void Buy_Item_Shop(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			sbyte type = msg.reader().readByte();
			bool flag = GameCanvas.currentScreen == GameCanvas.tabShopScr;
			if (flag)
			{
				for (int i = 0; i < GameCanvas.tabShopScr.vecTabs.size(); i++)
				{
					MainTab mainTab = (MainTab)GameCanvas.tabShopScr.vecTabs.elementAt(i);
					mainTab.updateBuyItem(id, type);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CDB RID: 3291 RVA: 0x000FA858 File Offset: 0x000F8A58
	public void CountDown_Ticket(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			int countDown = msg.reader().readInt();
			bool flag = b == 0;
			if (flag)
			{
				MainTab.CDTicket.setCountDown(countDown);
			}
			bool flag2 = b == 1;
			if (flag2)
			{
				MainTab.CDKeyBoss.setCountDown(countDown);
			}
			bool flag3 = b == 2;
			if (flag3)
			{
				MainTab.CDPvP.setCountDown(countDown);
			}
			bool flag4 = b == 3;
			if (flag4)
			{
				MainTab.CDx2XP.setCountDown(countDown);
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CDC RID: 3292 RVA: 0x000FA8F4 File Offset: 0x000F8AF4
	public void update_Part_Boat(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			sbyte tem = msg.reader().readByte();
			MainObject mainObject = MainObject.get_Object((int)id, tem);
			bool flag = mainObject == null;
			if (!flag)
			{
				sbyte b = msg.reader().readByte();
				short[] array = new short[(int)b];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = msg.reader().readShort();
				}
				mainObject.myBoat = array;
				bool flag2 = mainObject.boatSea != null && mainObject.boatSea.ID == mainObject.ID;
				if (flag2)
				{
					mainObject.boatSea.setPartImage(array, mainObject.typePirate);
				}
				bool flag3 = GameCanvas.currentScreen == GameCanvas.tabShopScr;
				if (flag3)
				{
					for (int j = 0; j < GameCanvas.tabShopScr.vecTabs.size(); j++)
					{
						MainTab mainTab = (MainTab)GameCanvas.tabShopScr.vecTabs.elementAt(j);
						mainTab.updateTrangBi();
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CDD RID: 3293 RVA: 0x000FAA34 File Offset: 0x000F8C34
	public void login_Ok(Message msg)
	{
		bool flag = ListChar_Screen.IndexCharSelected >= 0;
		if (flag)
		{
			GlobalService.gI().get_DATA(3);
		}
		GameMidlet.loginPlus();
		GameMidlet.loginOk();
		MsgDialog.isAuroReconect = false;
	}

	// Token: 0x06000CDE RID: 3294 RVA: 0x000FAA74 File Offset: 0x000F8C74
	public void PvP(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			bool flag = PvPScreen.instance == null;
			if (flag)
			{
				PvPScreen.instance = new PvPScreen();
			}
			bool flag2 = b == 3;
			if (flag2)
			{
				string name = msg.reader().readUTF();
				sbyte clazz = msg.reader().readByte();
				Other_Player other_Player = new Other_Player(0, 0, name, 0, 0);
				other_Player.clazz = clazz;
				PvPScreen.instance.setObjPvp(other_Player);
			}
			else
			{
				bool flag3 = b == 4;
				if (flag3)
				{
					sbyte b2 = msg.reader().readByte();
					bool flag4 = b2 == 0;
					if (flag4)
					{
						PvPScreen.instance.isMeReady = true;
					}
					else
					{
						PvPScreen.instance.isOtherReady = true;
					}
				}
				else
				{
					bool flag5 = b == 6;
					if (flag5)
					{
						string mstr = msg.reader().readUTF();
						PvPScreen.instance.setMStr(mstr);
					}
					else
					{
						bool flag6 = b == 0;
						if (flag6)
						{
							PvPScreen.instance.numPlayerWait = msg.reader().readShort();
						}
					}
				}
			}
			PvPScreen.instance.setAction(b);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CDF RID: 3295 RVA: 0x000FABAC File Offset: 0x000F8DAC
	public void UpdateNameNPC(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			MainObject mainObject = MainObject.get_Object((int)id, 2);
			bool flag = mainObject != null;
			if (flag)
			{
				mainObject.nameGiaotiep = msg.reader().readUTF();
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CE0 RID: 3296 RVA: 0x000FAC04 File Offset: 0x000F8E04
	public void Buy_Potion_Ok(Message msg)
	{
		try
		{
			string strContent = msg.reader().readUTF();
			EffectNum eff = new EffectNum(strContent, 0, 0, 7);
			MsgDialog.addEff(eff);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CE1 RID: 3297 RVA: 0x000FAC48 File Offset: 0x000F8E48
	public void Party_Buff(Message msg)
	{
		try
		{
			Player.giamCountDownParty = 0;
			GameScreen.player.vecAllInfoParty.removeAllElements();
			sbyte b = msg.reader().readByte();
			for (int i = 0; i < (int)b; i++)
			{
				MainInfoItem mainInfoItem = new MainInfoItem(msg.reader().readByte(), (int)msg.reader().readShort());
				GameScreen.player.vecAllInfoParty.addElement(mainInfoItem);
				bool flag = mainInfoItem.id == 25;
				if (flag)
				{
					Player.giamCountDownParty = (short)mainInfoItem.value;
				}
			}
			Player.SetGiamCountDown();
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CE2 RID: 3298 RVA: 0x000FACF4 File Offset: 0x000F8EF4
	public void UpdatePvpPoint(Message msg)
	{
		try
		{
			GameScreen.player.PointPvP = msg.reader().readInt();
			GameScreen.player.mValuePvP[0] = msg.reader().readInt();
			GameScreen.player.mValuePvP[1] = msg.reader().readInt();
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CE3 RID: 3299 RVA: 0x000FAD60 File Offset: 0x000F8F60
	public void RebuildItem(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			bool flag = b != 0 && SplitScreen.instance == null;
			if (!flag)
			{
				bool flag2 = b == 0;
				if (flag2)
				{
					sbyte typeRebuild = msg.reader().readByte();
					SplitScreen.instance = new SplitScreen(typeRebuild, -1);
					SplitScreen.instance.Show(GameCanvas.gameScr);
				}
				else
				{
					bool flag3 = b == 1;
					if (flag3)
					{
						sbyte b2 = 0;
						short id = msg.reader().readShort();
						sbyte b3 = msg.reader().readByte();
						bool flag4 = (SplitScreen.instance.typeRebuild == 1 || SplitScreen.instance.typeRebuild == 10 || SplitScreen.instance.typeRebuild == 11) && b3 != 3;
						if (flag4)
						{
							b2 = 1;
						}
						short num = msg.reader().readShort();
						MainItem itemVec = MainItem.getItemVec(b3, id, Player.vecInventory);
						bool flag5 = itemVec != null;
						if (flag5)
						{
							sbyte color = itemVec.colorName;
							bool flag6 = b3 != 3;
							if (flag6)
							{
								color = 5;
							}
							MainItem mainItem = new MainItem(b3, itemVec.ID, itemVec.idIcon, num, color, itemVec.LvUpgrade);
							mainItem.numLoKham = itemVec.numLoKham;
							ScreenUpgrade.mItemUpgrade[(int)b2] = mainItem;
						}
						SplitScreen.instance.setSetItem();
					}
					else
					{
						bool flag7 = b == 2;
						if (flag7)
						{
							short num2 = msg.reader().readShort();
							sbyte b4 = msg.reader().readByte();
							for (int i = 0; i < ScreenUpgrade.mItemUpgrade.Length; i++)
							{
								bool flag8 = ScreenUpgrade.mItemUpgrade[i].ID == num2 && ScreenUpgrade.mItemUpgrade[i].typeObject == b4;
								if (flag8)
								{
									ScreenUpgrade.mItemUpgrade[i] = null;
								}
							}
						}
						else
						{
							bool flag9 = b == 3;
							if (flag9)
							{
								string info = msg.reader().readUTF();
								GameCanvas.Start_Normal_Only_CmdClose_DiaLog(info);
							}
							else
							{
								bool flag10 = b == 4;
								if (flag10)
								{
									string showServer = msg.reader().readUTF();
									SplitScreen.instance.updateNewUpgrade();
									SplitScreen.instance.showServer = showServer;
									SplitScreen.instance.Step = 1;
								}
								else
								{
									bool flag11 = b == 5;
									if (flag11)
									{
										string showServer2 = msg.reader().readUTF();
										SplitScreen.instance.updateNewUpgrade();
										short num3 = msg.reader().readShort();
										short id2 = msg.reader().readShort();
										short num4 = msg.reader().readShort();
										sbyte b5 = msg.reader().readByte();
										MainItem itemVec2 = MainItem.getItemVec(b5, id2, Player.vecInventory);
										bool flag12 = itemVec2 != null && num4 > 0;
										if (flag12)
										{
											MainItem mainItem2 = new MainItem(b5, itemVec2.ID, itemVec2.idIcon, num4, itemVec2.colorName, itemVec2.LvUpgrade);
											mainItem2.isRemove = true;
											ScreenUpgrade.mItemUpgrade[1] = mainItem2;
										}
										SplitScreen.instance.showServer = showServer2;
										SplitScreen.instance.Step = 1;
									}
									else
									{
										bool flag13 = b == 6;
										if (flag13)
										{
											string showServer3 = msg.reader().readUTF();
											SplitScreen.instance.updateNewUpgrade();
											SplitScreen.instance.showServer = showServer3;
											SplitScreen.instance.Step = 1;
										}
										else
										{
											bool flag14 = b == 7;
											if (flag14)
											{
												string showServer4 = msg.reader().readUTF();
												SplitScreen.instance.updateNewUpgrade();
												SplitScreen.instance.showServer = showServer4;
												SplitScreen.instance.Step = 1;
											}
											else
											{
												bool flag15 = b == 20 || b == 21 || b == 22 || b == 23;
												if (flag15)
												{
													string showServer5 = msg.reader().readUTF();
													SplitScreen.instance.updateNewUpgrade();
													SplitScreen.instance.showServer = showServer5;
													bool flag16 = b == 20 || b == 22;
													if (flag16)
													{
														SplitScreen.instance.Step = 1;
													}
													else
													{
														SplitScreen.instance.Step = 3;
													}
												}
												else
												{
													bool flag17 = b == 25;
													if (flag17)
													{
														string showServer6 = msg.reader().readUTF();
														SplitScreen.instance.updateNewUpgrade();
														SplitScreen.instance.showServer = showServer6;
														SplitScreen.instance.Step = 1;
													}
													else
													{
														bool flag18 = b == 28 || b == 29;
														if (flag18)
														{
															sbyte b6 = 0;
															bool flag19 = b == 29;
															if (flag19)
															{
																b6 = 1;
															}
															short id3 = msg.reader().readShort();
															sbyte b7 = msg.reader().readByte();
															short num5 = msg.reader().readShort();
															sbyte tile = msg.reader().readByte();
															MainItem itemVec3 = MainItem.getItemVec(b7, id3, Player.vecInventory);
															bool flag20 = itemVec3 != null;
															if (flag20)
															{
																sbyte color2 = itemVec3.colorName;
																bool flag21 = b7 != 3;
																if (flag21)
																{
																	color2 = 5;
																}
																MainItem mainItem3 = new MainItem(b7, itemVec3.ID, itemVec3.idIcon, num5, color2, itemVec3.LvUpgrade);
																ScreenUpgrade.mItemUpgrade[(int)b6] = mainItem3;
															}
															SplitScreen.instance.tile = tile;
														}
														else
														{
															bool flag22 = b == 25;
															if (flag22)
															{
																string showServer7 = msg.reader().readUTF();
																SplitScreen.instance.updateNewUpgrade();
																SplitScreen.instance.showServer = showServer7;
																SplitScreen.instance.Step = 1;
															}
															else
															{
																bool flag23 = b == 27 || b == 30;
																if (flag23)
																{
																	string showServer8 = msg.reader().readUTF();
																	SplitScreen.instance.updateNewUpgrade();
																	SplitScreen.instance.showServer = showServer8;
																	bool flag24 = b == 30;
																	if (flag24)
																	{
																		SplitScreen.instance.Step = 3;
																	}
																	else
																	{
																		SplitScreen.instance.Step = 1;
																	}
																}
																else
																{
																	bool flag25 = b == 31;
																	if (flag25)
																	{
																		string showServer9 = msg.reader().readUTF();
																		SplitScreen.instance.idItem9x = msg.reader().readShort();
																		SplitScreen.instance.updateNewUpgrade();
																		SplitScreen.instance.showServer = showServer9;
																		SplitScreen.instance.Step = 1;
																	}
																	else
																	{
																		bool flag26 = b == 32;
																		if (flag26)
																		{
																			string showServer10 = msg.reader().readUTF();
																			SplitScreen.instance.updateNewUpgrade();
																			SplitScreen.instance.showServer = showServer10;
																			SplitScreen.instance.Step = 3;
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CE4 RID: 3300 RVA: 0x000FB3E4 File Offset: 0x000F95E4
	public void Diaolog_time(Message msg)
	{
		try
		{
			string info = msg.reader().readUTF();
			short time = msg.reader().readShort();
			GameCanvas.Start_Time_DiaLog(info, true, (int)time, null);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CE5 RID: 3301 RVA: 0x000FB430 File Offset: 0x000F9630
	public void updateNumPlayerMap(Message msg)
	{
		try
		{
			LoadMap.numPlayerMap = msg.reader().readByte();
			LoadMap.maxnumPlayerMap = msg.reader().readByte();
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CE6 RID: 3302 RVA: 0x000FB478 File Offset: 0x000F9678
	public void Auto_Revice(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			bool flag = b != 1;
			if (!flag)
			{
				short id = msg.reader().readShort();
				sbyte tem = msg.reader().readByte();
				int timeSafe = msg.reader().readInt();
				MainObject mainObject = MainObject.get_Object((int)id, tem);
				bool flag2 = mainObject != null;
				if (flag2)
				{
					bool flag3 = mainObject == GameScreen.player && Player.AutoFireCur == 0;
					if (flag3)
					{
						Player.AutoFireCur = 1;
					}
					mainObject.timeSafe = timeSafe;
					mainObject.timeBeginSafe = GameCanvas.timeNow;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CE7 RID: 3303 RVA: 0x000FB52C File Offset: 0x000F972C
	public void List_Player_Check(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			ReadMessenge.IDDialogPhoBang = msg.reader().readShort();
			bool flag = b == 0;
			if (flag)
			{
				ListDungeon.isKey = false;
				ListDungeon.vecDungeon.removeAllElements();
				string name = msg.reader().readUTF();
				sbyte b2 = msg.reader().readByte();
				for (int i = 0; i < (int)b2; i++)
				{
					short id = msg.reader().readShort();
					InfoMemList infoMemList = new InfoMemList((int)id);
					infoMemList.updateData(msg.reader().readUTF(), msg.reader().readShort(), 0, 0);
					bool flag2 = i == 0;
					if (flag2)
					{
						infoMemList.typeOnline = 1;
						bool flag3 = infoMemList.id == (int)GameScreen.player.ID;
						if (flag3)
						{
							ListDungeon.isKey = true;
						}
					}
					ListDungeon.vecDungeon.addElement(infoMemList);
				}
				ListDungeon.instance = new ListDungeon(-4, ListDungeon.vecDungeon, name);
				ListDungeon.instance.Show(GameCanvas.gameScr);
			}
			else
			{
				bool flag4 = b == 1;
				if (flag4)
				{
					short num = msg.reader().readShort();
					bool flag5 = ListDungeon.vecDungeon == null;
					if (!flag5)
					{
						for (int j = 0; j < ListDungeon.vecDungeon.size(); j++)
						{
							InfoMemList infoMemList2 = (InfoMemList)ListDungeon.vecDungeon.elementAt(j);
							bool flag6 = infoMemList2.id == (int)num;
							if (flag6)
							{
								infoMemList2.typeOnline = 1;
								break;
							}
						}
					}
				}
				else
				{
					bool flag7 = b == 2;
					if (flag7)
					{
						string info = msg.reader().readUTF();
						ListDungeon.vecDungeon.removeAllElements();
						bool flag8 = GameCanvas.currentScreen != GameCanvas.gameScr;
						if (flag8)
						{
							GameCanvas.gameScr.Show();
						}
						GameCanvas.Start_Normal_Only_CmdClose_DiaLog(info);
					}
					else
					{
						bool flag9 = b != 3;
						if (!flag9)
						{
							short num2 = msg.reader().readShort();
							bool flag10 = ListDungeon.vecDungeon == null;
							if (!flag10)
							{
								for (int k = 0; k < ListDungeon.vecDungeon.size(); k++)
								{
									InfoMemList infoMemList3 = (InfoMemList)ListDungeon.vecDungeon.elementAt(k);
									bool flag11 = infoMemList3.id == (int)num2;
									if (flag11)
									{
										infoMemList3.typeOnline = 2;
										break;
									}
								}
							}
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CE8 RID: 3304 RVA: 0x000FB7C4 File Offset: 0x000F99C4
	public void Red_Line(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			bool flag = b == 0;
			if (flag)
			{
				sbyte b2 = msg.reader().readByte();
				MapOff_RedLine.setTypeMoveredLine(0);
				ReadMessenge.mImgCapredLine = new mImage[(int)b2];
				for (int i = 0; i < (int)b2; i++)
				{
					int num = msg.reader().readInt();
					sbyte[] array = new sbyte[num];
					msg.reader().read(ref array);
					ReadMessenge.mImgCapredLine[i] = mImage.createImage(array, 0, array.Length);
				}
				MapOff_RedLine.timeRedline = msg.reader().readInt();
				MapOff_RedLine.timebegin = GameCanvas.timeNow;
				Player.indexAudition = -1;
				MapOff_RedLine.tickSendDie = 0;
			}
			else
			{
				bool flag2 = b == 1;
				if (flag2)
				{
					ReadMessenge.mImgCapredLine = null;
					Interface_Game.addInfoPlayerNormal(T.RedLineFail, mFont.tahoma_7_white);
					Player.indexAudition = -1;
					MapOff_RedLine.setTypeMoveredLine(1);
				}
				else
				{
					bool flag3 = b == 2;
					if (flag3)
					{
						ReadMessenge.mImgCapredLine = null;
						Interface_Game.addInfoPlayerNormal(T.RedLineFinish, mFont.tahoma_7_white);
						Player.indexAudition = -1;
						MapOff_RedLine.setTypeMoveredLine(2);
					}
					else
					{
						bool flag4 = b == 3;
						if (flag4)
						{
							sbyte b3 = msg.reader().readByte();
							GameScreen.player.typeMoveGotoSky = 1;
							ReadMessenge.mImgCapredLine = new mImage[(int)b3];
							for (int j = 0; j < (int)b3; j++)
							{
								int num2 = msg.reader().readInt();
								sbyte[] array2 = new sbyte[num2];
								msg.reader().read(ref array2);
								ReadMessenge.mImgCapredLine[j] = mImage.createImage(array2, 0, array2.Length);
							}
							MapOff_RedLine.timeRedline = msg.reader().readInt();
							MapOff_RedLine.timebegin = GameCanvas.timeNow;
							Player.indexAudition = -1;
							MapOff_RedLine.tickSendDie = 0;
						}
						else
						{
							bool flag5 = b == 5;
							if (flag5)
							{
								ReadMessenge.mImgCapredLine = null;
								Interface_Game.addInfoPlayerNormal(T.gotoSkyFinish, mFont.tahoma_7_white);
								Player.indexAudition = -1;
								bool flag6 = LoadMap.specMap == 8;
								if (flag6)
								{
									MapGotoSky.setTypeMoveredLine(3);
								}
								else
								{
									bool flag7 = LoadMap.specMap == 12;
									if (flag7)
									{
										MapGotoGod.setTypeMoveredLine(3);
									}
								}
							}
							else
							{
								bool flag8 = b == 4;
								if (flag8)
								{
									ReadMessenge.mImgCapredLine = null;
									Interface_Game.addInfoPlayerNormal(T.gotoSkyFail, mFont.tahoma_7_white);
									Player.indexAudition = -1;
									MapGotoSky.setTypeMoveredLine(2);
								}
							}
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CE9 RID: 3305 RVA: 0x000FBA50 File Offset: 0x000F9C50
	public void TimeShow(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			bool flag = b == 0 || b == 2;
			if (flag)
			{
				short countDown = msg.reader().readShort();
				string strInfo = msg.reader().readUTF();
				Interface_Game.watchMap.setCountDown((int)countDown);
				Interface_Game.watchMap.strInfo = strInfo;
				Interface_Game.watchMap.typeTime = b;
			}
			else
			{
				bool flag2 = b == 1;
				if (flag2)
				{
					Interface_Game.maxHPMap = msg.reader().readInt();
					Interface_Game.HPMap = msg.reader().readInt();
				}
				else
				{
					bool flag3 = b == 3;
					if (flag3)
					{
						short countDown2 = msg.reader().readShort();
						string strInfo2 = msg.reader().readUTF();
						Interface_Game.watchRevice.setCountDown((int)countDown2);
						Interface_Game.watchRevice.strInfo = strInfo2;
						Interface_Game.watchRevice.typeTime = b;
					}
					else
					{
						bool flag4 = b == 4;
						if (flag4)
						{
							Interface_Game.watchMap.typeTime = b;
							short countDown3 = msg.reader().readShort();
							sbyte valueLeft = msg.reader().readByte();
							sbyte valueright = msg.reader().readByte();
							Interface_Game.watchMap.setCountDown((int)countDown3);
							Interface_Game.watchMap.valueLeft = (int)valueLeft;
							Interface_Game.watchMap.valueright = (int)valueright;
						}
						else
						{
							bool flag5 = b == 5;
							if (flag5)
							{
								bool flag6 = MotherCanvas.w >= 300;
								if (flag6)
								{
									GameScreen.isPvPNew = true;
									Interface_Game.watchMap.typeTime = b;
								}
								else
								{
									Interface_Game.watchMap.typeTime = 4;
								}
								short countDown4 = msg.reader().readShort();
								sbyte valueLeft2 = msg.reader().readByte();
								sbyte valueright2 = msg.reader().readByte();
								Interface_Game.watchMap.setCountDown((int)countDown4);
								Interface_Game.watchMap.valueLeft = (int)valueLeft2;
								Interface_Game.watchMap.valueright = (int)valueright2;
								Interface_Game.maxWin = msg.reader().readByte();
							}
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CEA RID: 3306 RVA: 0x000FBC68 File Offset: 0x000F9E68
	public void UpdateInfoMaincharInfo(Message msg)
	{
		try
		{
			Player.idFashion = msg.reader().readShort();
			Player.giamCountDownAtt = msg.reader().readShort();
			Player.SetGiamCountDown();
			Player.TangManaUseSkill = msg.reader().readShort();
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CEB RID: 3307 RVA: 0x000FBCC8 File Offset: 0x000F9EC8
	public void Clan(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			bool flag = b == 0;
			if (flag)
			{
				bool flag2 = GameScreen.player.clan == null;
				if (flag2)
				{
					GameScreen.player.clan = new MainClan(msg.reader().readShort(), msg.reader().readUTF());
				}
				else
				{
					GameScreen.player.clan.ID = msg.reader().readShort();
					GameScreen.player.clan.name = msg.reader().readUTF();
				}
			}
			else
			{
				bool flag3 = b == 1;
				if (flag3)
				{
					bool flag4 = GameScreen.player.clan == null;
					if (flag4)
					{
						GlobalService.gI().Clan_CMD(9, string.Empty, 0, 0);
					}
					else
					{
						string name = msg.reader().readUTF();
						sbyte b2 = msg.reader().readByte();
						InfoMemList memInCLan = Clan_Screen.getMemInCLan(name);
						bool flag5 = memInCLan != null;
						if (flag5)
						{
							memInCLan.chucInClan = b2;
							bool flag6 = memInCLan.name.CompareTo(GameScreen.player.name) == 0;
							if (flag6)
							{
								MainClan.UpdateRankMe(b2);
							}
						}
					}
				}
				else
				{
					bool flag7 = b == 2;
					if (flag7)
					{
						bool flag8 = GameScreen.player.clan == null;
						if (flag8)
						{
							GlobalService.gI().Clan_CMD(9, string.Empty, 0, 0);
						}
						else
						{
							GameScreen.player.clan.setData(msg.reader().readShort(), msg.reader().readUTF(), msg.reader().readShort(), msg.reader().readInt(), msg.reader().readInt(), msg.reader().readByte(), msg.reader().readByte(), msg.reader().readInt(), msg.reader().readUTF());
							bool flag9 = Player.isGetDataClan == 0;
							if (flag9)
							{
								bool flag10 = GameCanvas.ClanScr == null;
								if (flag10)
								{
									GameCanvas.ClanScr = new Clan_Screen(GameScreen.player.clan);
								}
								GameCanvas.ClanScr.Show(GameCanvas.gameScr);
								Player.isGetDataClan = 1;
							}
							GameScreen.player.clan.trungsinh = msg.reader().readByte();
							GameScreen.player.clan.countAction = msg.reader().readInt();
						}
					}
					else
					{
						bool flag11 = b == 3;
						if (flag11)
						{
							bool flag12 = GameScreen.player.clan == null;
							if (flag12)
							{
								GlobalService.gI().Clan_CMD(9, string.Empty, 0, 0);
							}
							else
							{
								sbyte b3 = msg.reader().readByte();
								for (int i = 0; i < (int)b3; i++)
								{
									this.readMemInCLan(msg);
								}
								Clan_Mem.tickupdate = 10;
							}
						}
						else
						{
							bool flag13 = b == 4;
							if (flag13)
							{
								bool flag14 = GameScreen.player.clan == null;
								if (flag14)
								{
									GlobalService.gI().Clan_CMD(9, string.Empty, 0, 0);
								}
								else
								{
									short maxAttri = msg.reader().readShort();
									short pointAttri = msg.reader().readShort();
									short[] array = new short[5];
									for (int j = 0; j < array.Length; j++)
									{
										array[j] = msg.reader().readShort();
									}
									GameScreen.player.clan.pointAttri = (int)pointAttri;
									GameScreen.player.clan.maxAttri = (int)maxAttri;
									GameScreen.player.clan.setAttri(array);
								}
							}
							else
							{
								bool flag15 = b == 5;
								if (flag15)
								{
									short id = msg.reader().readShort();
									MainObject mainObject = MainObject.get_Object((int)id, 0);
									bool flag16 = mainObject != null;
									if (flag16)
									{
										short id2 = msg.reader().readShort();
										short idIcon = msg.reader().readShort();
										sbyte b4 = msg.reader().readByte();
										bool flag17 = mainObject.clan == null;
										if (flag17)
										{
											mainObject.clan = new MainClan(id2, idIcon, b4);
										}
										else
										{
											mainObject.clan.ID = id2;
											mainObject.clan.idIcon = idIcon;
											mainObject.clan.chucvu = (int)b4;
										}
										bool flag18 = mainObject == GameScreen.player;
										if (flag18)
										{
											MainClan.UpdateRankMe(b4);
										}
										sbyte borderIconClan = msg.reader().readByte();
										mainObject.clan.borderIconClan = borderIconClan;
									}
									bool flag19 = mainObject.boatSea != null;
									if (flag19)
									{
										mainObject.boatSea.setIconClan();
									}
								}
								else
								{
									bool flag20 = b == 8;
									if (flag20)
									{
										bool flag21 = GameScreen.player.clan != null && GameCanvas.ClanScr != null;
										if (flag21)
										{
											this.read_Data_Chat(msg, 0);
											GameCanvas.ClanScr.setIsNewTab(GameCanvas.ClanScr.clanchat);
										}
									}
									else
									{
										bool flag22 = b == 7;
										if (flag22)
										{
											int id3 = msg.reader().readInt();
											string name2 = msg.reader().readUTF();
											InfoMemList.setTypeEvent(id3, 6, name2, T.eventMoiClan, 0, 0);
										}
										else
										{
											bool flag23 = b == 9;
											if (flag23)
											{
												bool flag24 = GameScreen.player.clan != null && GameCanvas.ClanScr != null;
												if (flag24)
												{
													GameScreen.player.clan.vecChatCLan.removeAllElements();
													short num = msg.reader().readShort();
													for (int k = 0; k < (int)num; k++)
													{
														this.read_Data_Chat(msg, 0);
													}
												}
											}
											else
											{
												bool flag25 = b == 11;
												if (flag25)
												{
													bool flag26 = GameScreen.player.clan != null && GameCanvas.ClanScr != null;
													if (flag26)
													{
														short id4 = msg.reader().readShort();
														GameCanvas.ClanScr.clanchat.RemoveChat(id4);
													}
												}
												else
												{
													bool flag27 = b == 10;
													if (flag27)
													{
														short id5 = msg.reader().readShort();
														MainObject mainObject2 = MainObject.get_Object((int)id5, 0);
														bool flag28 = mainObject2 != null && mainObject2.clan != null;
														if (flag28)
														{
															mainObject2.clan = null;
														}
														bool flag29 = mainObject2 == GameScreen.player && GameCanvas.currentScreen == GameCanvas.ClanScr;
														if (flag29)
														{
															GameCanvas.gameScr.Show();
															GameCanvas.ClanScr = null;
															Player.isGetDataClan = -1;
														}
													}
													else
													{
														bool flag30 = b == 12;
														if (flag30)
														{
															bool flag31 = GameScreen.player.clan != null && GameCanvas.ClanScr != null;
															if (flag31)
															{
																sbyte b5 = msg.reader().readByte();
																bool flag32 = b5 == 0;
																if (flag32)
																{
																	this.readMemInCLan(msg);
																}
																else
																{
																	bool flag33 = b5 == 1;
																	if (flag33)
																	{
																		string name3 = msg.reader().readUTF();
																		Clan_Screen.getRemoveMemInCLan(name3);
																	}
																}
																GameCanvas.ClanScr.setIsNewTab(GameCanvas.ClanScr.member);
															}
														}
														else
														{
															bool flag34 = b == 13;
															if (flag34)
															{
																int countDown = msg.reader().readInt();
																MainTab.CDDonateClan.setCountDown(countDown);
																int numTangqua = msg.reader().readInt();
																InfoMemList memInCLan2 = Clan_Screen.getMemInCLan(GameScreen.player.ID);
																bool flag35 = memInCLan2 != null;
																if (flag35)
																{
																	memInCLan2.numTangqua = numTangqua;
																}
															}
															else
															{
																bool flag36 = b == 14;
																if (flag36)
																{
																	bool flag37 = GameScreen.player.clan != null && GameCanvas.ClanScr != null;
																	if (flag37)
																	{
																		string text = msg.reader().readUTF();
																		GameScreen.player.clan.strVoice = text;
																		GameCanvas.ClanScr.info.getmStrInfo(text, GameCanvas.ClanScr.info.wCon - 6);
																		GameCanvas.ClanScr.setIsNewTab(GameCanvas.ClanScr.info);
																	}
																}
																else
																{
																	bool flag38 = b == 15;
																	if (flag38)
																	{
																		short[] array2 = new short[5];
																		for (int l = 0; l < 5; l++)
																		{
																			array2[l] = msg.reader().readShort();
																		}
																		for (int m = 0; m < Player.mAttribute.Length; m++)
																		{
																			Main_Attribute main_Attribute = Player.mAttribute[m];
																			bool flag39 = m < array2.Length;
																			if (flag39)
																			{
																				main_Attribute.valuePlus = array2[m];
																			}
																		}
																	}
																	else
																	{
																		bool flag40 = b == 16;
																		if (flag40)
																		{
																			bool flag41 = GameScreen.player.clan != null;
																			if (flag41)
																			{
																				GameScreen.player.clan.isLevelUp = msg.reader().readByte();
																				GameScreen.player.clan.xp = msg.reader().readInt();
																			}
																		}
																		else
																		{
																			bool flag42 = b == 17;
																			if (flag42)
																			{
																				bool flag43 = GameScreen.player.clan != null;
																				if (flag43)
																				{
																					GameScreen.player.clan.rubiClan = msg.reader().readInt();
																					GameScreen.player.clan.beryClan = msg.reader().readInt();
																				}
																			}
																			else
																			{
																				bool flag44 = b == 19;
																				if (flag44)
																				{
																					this.update_Inven_Clan(msg);
																				}
																				else
																				{
																					bool flag45 = b == 20;
																					if (flag45)
																					{
																						bool flag46 = GameScreen.player.clan != null && GameCanvas.ClanScr != null;
																						if (flag46)
																						{
																							GameCanvas.ClanScr.achi.vecDetail.removeAllElements();
																							while (msg.reader().available() > 0)
																							{
																								this.read_Data_Chat(msg, 1);
																							}
																							GameCanvas.ClanScr.setIsNewTab(GameCanvas.ClanScr.achi);
																						}
																					}
																					else
																					{
																						bool flag47 = b == 21;
																						if (flag47)
																						{
																							string info = msg.reader().readUTF();
																							bool flag48 = GameCanvas.currentScreen == GameCanvas.tabShopScr;
																							if (flag48)
																							{
																								GameCanvas.gameScr.Show();
																							}
																							GameCanvas.Start_Normal_Only_CmdClose_DiaLog(info);
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CEC RID: 3308 RVA: 0x000FC6EC File Offset: 0x000FA8EC
	private void readMemInCLan(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			string text = msg.reader().readUTF();
			InfoMemList infoMemList = Clan_Screen.getMemInCLan(text);
			bool flag = false;
			bool flag2 = infoMemList == null;
			if (flag2)
			{
				infoMemList = new InfoMemList((int)id);
				flag = true;
			}
			infoMemList.updateMemClan(text, msg.reader().readShort(), msg.reader().readByte(), msg.reader().readShort(), msg.reader().readShort(), msg.reader().readShort(), msg.reader().readInt());
			infoMemList.updateFace(msg.reader().readShort(), msg.reader().readShort(), msg.reader().readShort());
			infoMemList.typeOnline = msg.reader().readByte();
			bool flag3 = flag;
			if (flag3)
			{
				GameScreen.player.clan.vecMem.addElement(infoMemList);
			}
			bool flag4 = text.CompareTo(GameScreen.player.name) == 0;
			if (flag4)
			{
				Player.ChucInCLan = infoMemList.chucInClan;
			}
			bool flag5 = GameCanvas.ClanScr != null;
			if (flag5)
			{
				GameCanvas.ClanScr.member.updateLimCam();
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CED RID: 3309 RVA: 0x000FC840 File Offset: 0x000FAA40
	public void read_Data_Chat(Message msg, int tab)
	{
		try
		{
			sbyte typeAction = msg.reader().readByte();
			short idchat = msg.reader().readShort();
			short idmem = msg.reader().readShort();
			string name = msg.reader().readUTF();
			string str = msg.reader().readUTF();
			long time = msg.reader().readLong() - GameCanvas.clockServer;
			if (tab != 0)
			{
				if (tab == 1)
				{
					GameCanvas.ClanScr.achi.addOneChat(idchat, idmem, name, str, typeAction, time);
				}
			}
			else
			{
				GameCanvas.ClanScr.clanchat.addOneChat(idchat, idmem, name, str, typeAction, time);
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CEE RID: 3310 RVA: 0x000FC900 File Offset: 0x000FAB00
	public void ChuyenHoa(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			bool flag = b != 0 && SplitScreen.instance == null;
			if (flag)
			{
				SplitScreen.instance = new SplitScreen(7, -1);
			}
			bool flag2 = b == 0;
			if (flag2)
			{
				SplitScreen.instance = new SplitScreen(7, -1);
				SplitScreen.instance.Show(GameCanvas.gameScr);
			}
			else
			{
				bool flag3 = b == 1;
				if (flag3)
				{
					sbyte b2 = msg.reader().readByte();
					short id = msg.reader().readShort();
					MainItem itemVec = MainItem.getItemVec(3, id, Player.vecInventory);
					bool flag4 = itemVec != null;
					if (flag4)
					{
						bool flag5 = b2 == 0;
						if (flag5)
						{
							ReadMessenge.idLvthap = id;
						}
						else
						{
							bool flag6 = b2 == 1;
							if (flag6)
							{
								ReadMessenge.idLvCao = id;
							}
						}
						MainItem mainItem = new MainItem(3, itemVec.ID, itemVec.idIcon, 1, itemVec.colorName, itemVec.LvUpgrade);
						ScreenUpgrade.mItemUpgrade[(int)b2] = mainItem;
					}
				}
				else
				{
					bool flag7 = b == 3;
					if (flag7)
					{
						string showServer = msg.reader().readUTF();
						SplitScreen.instance.showServer = showServer;
						ReadMessenge.numCuonghoa = msg.reader().readByte();
						SplitScreen.instance.Step = 1;
					}
					else
					{
						bool flag8 = b == 2;
						if (flag8)
						{
							SplitScreen.instance.PriceChuyenHoa = (int)msg.reader().readShort();
							mVector mVector = new mVector();
							iCommand iCommand = new iCommand(SplitScreen.instance.PriceChuyenHoa.ToString() + string.Empty, 4, this);
							iCommand.setFraCaption(AvMain.fraMoney, 1, 1, 0);
							mVector.addElement(iCommand);
							iCommand o = new iCommand(T.close, 1, 0, this);
							mVector.addElement(o);
							GameCanvas.Start_Normal_DiaLog(string.Concat(new string[]
							{
								T.textchuyenhoa,
								SplitScreen.instance.PriceChuyenHoa.ToString(),
								" ",
								T.ruby,
								"?"
							}), mVector, false);
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CEF RID: 3311 RVA: 0x000FCB38 File Offset: 0x000FAD38
	public void little_Garden(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			bool flag = b == 0;
			if (flag)
			{
				sbyte type = msg.reader().readByte();
				int maxHP = msg.reader().readInt();
				int maxMP = msg.reader().readInt();
				BigBossLittleGraden bigBossLittleGraden = new BigBossLittleGraden(type);
				bigBossLittleGraden.MaxHP = maxHP;
				bigBossLittleGraden.MaxMP = maxMP;
				GameScreen.vecBigBossLittleGraden.addElement(bigBossLittleGraden);
			}
			else
			{
				bool flag2 = b == 1;
				if (flag2)
				{
					sbyte b2 = msg.reader().readByte();
					int hp = msg.reader().readInt();
					int mp = msg.reader().readInt();
					for (int i = 0; i < GameScreen.vecBigBossLittleGraden.size(); i++)
					{
						BigBossLittleGraden bigBossLittleGraden2 = (BigBossLittleGraden)GameScreen.vecBigBossLittleGraden.elementAt(i);
						bool flag3 = bigBossLittleGraden2.type == (int)b2;
						if (flag3)
						{
							bigBossLittleGraden2.hp = hp;
							bigBossLittleGraden2.mp = mp;
							break;
						}
					}
				}
				else
				{
					bool flag4 = b == 2;
					if (flag4)
					{
						sbyte b3 = msg.reader().readByte();
						int dam = msg.reader().readInt();
						for (int j = 0; j < GameScreen.vecBigBossLittleGraden.size(); j++)
						{
							BigBossLittleGraden bigBossLittleGraden3 = (BigBossLittleGraden)GameScreen.vecBigBossLittleGraden.elementAt(j);
							bool flag5 = bigBossLittleGraden3.type == (int)b3;
							if (flag5)
							{
								bigBossLittleGraden3.setActionBigBoss(1);
								bigBossLittleGraden3.dam = dam;
								break;
							}
						}
					}
					else
					{
						bool flag6 = b != 3;
						if (!flag6)
						{
							sbyte b4 = msg.reader().readByte();
							for (int k = 0; k < GameScreen.vecBigBossLittleGraden.size(); k++)
							{
								BigBossLittleGraden bigBossLittleGraden4 = (BigBossLittleGraden)GameScreen.vecBigBossLittleGraden.elementAt(k);
								bool flag7 = bigBossLittleGraden4.type == (int)b4;
								if (flag7)
								{
									bigBossLittleGraden4.setActionBigBoss(3);
									break;
								}
							}
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CF0 RID: 3312 RVA: 0x000FCD58 File Offset: 0x000FAF58
	public void Pet(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			bool flag = b == 0;
			if (flag)
			{
				short id = msg.reader().readShort();
				short num = msg.reader().readShort();
				short idImage = msg.reader().readShort();
				sbyte type = msg.reader().readByte();
				MainObject mainObject = MainObject.getPet(num);
				bool flag2 = mainObject == null;
				if (flag2)
				{
					mainObject = new Pet(id, num, idImage, type);
					GameScreen.addPlayer(mainObject);
				}
				else
				{
					mainObject.setDataPet(id, idImage, type);
				}
			}
			else
			{
				bool flag3 = b == 1;
				if (flag3)
				{
					short num2 = msg.reader().readShort();
					short idmain = msg.reader().readShort();
					MainObject pet = MainObject.getPet(idmain);
					bool flag4 = pet != null;
					if (flag4)
					{
						pet.isRemove = true;
					}
				}
			}
			bool flag5 = b == 3;
			if (flag5)
			{
				short num3 = msg.reader().readShort();
				mVector mVector = new mVector();
				for (int i = 0; i < (int)num3; i++)
				{
					short id2 = msg.reader().readShort();
					string name = msg.reader().readUTF();
					string info = msg.reader().readUTF();
					short idIcon = msg.reader().readShort();
					sbyte typeItem = msg.reader().readByte();
					mSystem.outz(string.Concat(new string[]
					{
						"PET_INVEN ",
						id2.ToString(),
						" ",
						idIcon.ToString(),
						" ",
						typeItem.ToString()
					}));
					MainItem mainItem = new MainItem(typeItem, id2, idIcon, name, 0);
					mainItem.name = name;
					mainItem.info = info;
					sbyte b2 = msg.reader().readByte();
					bool flag6 = b2 == 1;
					if (flag6)
					{
						mainItem.addInfoFrist(T.daTrangBi, 1);
						mainItem.colorName = 1;
					}
					sbyte b3 = msg.reader().readByte();
					for (int j = 0; j < (int)b3; j++)
					{
						sbyte id3 = msg.reader().readByte();
						short value = msg.reader().readShort();
						mainItem.addInfo((short)id3, (int)value, infoShow.HARDCODE_INFO_CO_BAN, 1);
					}
					mVector.addElement(mainItem);
				}
				GameCanvas.tabShopScr = new TabScreen(MainTab.xTab, 0);
				mVector mVector2 = new mVector();
				GameCanvas.tabShopScr.isShopClan = false;
				GameCanvas.tabInvenClan = new TabInventory(T.khoPet, mVector, 7, MainTab.xTab);
				GameCanvas.tabInvenClan.initCmd();
				mVector2.addElement(GameCanvas.tabInvenClan);
				GameCanvas.tabShopScr.addVecTab(mVector2);
				GameCanvas.tabShopScr.idSelect = 0;
				GameCanvas.tabShopScr.Show(GameCanvas.gameScr);
				GameCanvas.tabShopScr.typeCurrent = 1;
				GameCanvas.tabShopScr.setTabSelect();
			}
			else
			{
				bool flag7 = b == 4;
				if (flag7)
				{
					short idIcon2 = msg.reader().readShort();
					mSystem.outz("action use idIcon " + idIcon2.ToString());
					GameCanvas.tabInvenClan.Use(idIcon2);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CF1 RID: 3313 RVA: 0x000FD09C File Offset: 0x000FB29C
	public void Input_password(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			string name = msg.reader().readUTF();
			sbyte b = msg.reader().readByte();
			string[] array = new string[(int)b];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = msg.reader().readUTF();
			}
			GameCanvas.currentDialog = GameCanvas.Start_Input_Dialog_Server(array, name, id);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CF2 RID: 3314 RVA: 0x000FD124 File Offset: 0x000FB324
	public void registerNew(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			FristLoginScreen.cmdRegister = new iCommand(T.register, 3, GameCanvas.fristLoginScr);
			FristLoginScreen.input = new InputDialog();
			FristLoginScreen.input.setinfo(T.registerNew, T.info, 0, FristLoginScreen.cmdRegister, T.registerCaution);
			bool flag = b == 1;
			if (flag)
			{
				FristLoginScreen.input.setNameDefaul(T.registerDefaul);
			}
			GameCanvas.Start_Sub_Dialog(FristLoginScreen.input);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CF3 RID: 3315 RVA: 0x000FD1BC File Offset: 0x000FB3BC
	public void ChangeMapNonData(Message msg)
	{
		try
		{
			ReadMessenge.actionChangeMap = 0;
			GameCanvas.loadmap.idLastMap = GameCanvas.loadmap.idMap;
			short num = msg.reader().readShort();
			bool flag = this.setMapSea((int)num);
			if (flag)
			{
				this.idMapLuu = num;
				this.msgLuu = msg;
				ReadMessenge.isNondata = true;
			}
			else
			{
				this.readChangeMapNonData(msg, num);
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CF4 RID: 3316 RVA: 0x000FD238 File Offset: 0x000FB438
	public void readChangeMapNonData(Message msg, short idmap)
	{
		try
		{
			GameCanvas.loadMapScr.Show();
			GameScreen.RemoveLoadMap();
			DataMap dataMap = (DataMap)DataMap.hashDataMap.get(string.Empty + idmap.ToString());
			bool flag = dataMap == null;
			if (flag)
			{
				GlobalService.gI().NextMap(idmap);
			}
			else
			{
				GameCanvas.loadmap.idMap = (int)idmap;
				Interface_Game.nameMap = string.Empty;
				GameCanvas.loadMapScr.area = msg.reader().readByte();
				sbyte typeViewPlayer = msg.reader().readByte();
				GameScreen.player.posTransRoad = null;
				GameScreen.player.x = (int)msg.reader().readShort();
				GameScreen.player.y = (int)msg.reader().readShort();
				GameScreen.player.toX = GameScreen.player.x;
				GameScreen.player.toY = GameScreen.player.y;
				GameScreen.player.maxHp = msg.reader().readInt();
				GameScreen.player.Hp = msg.reader().readInt();
				GameScreen.player.maxMp = msg.reader().readInt();
				GameScreen.player.Mp = msg.reader().readInt();
				sbyte b = msg.reader().readByte();
				bool flag2 = LoadMap.specMap == 3;
				if (flag2)
				{
					GameScreen.player.isBeginTrain = false;
				}
				else
				{
					bool flag3 = LoadMap.specMap == 4;
					if (flag3)
					{
						GameCanvas.saveRms.loadHotKey(SaveRms.datahotKeySkill);
					}
				}
				LoadMap.specMap = msg.reader().readByte();
				bool flag4 = LoadMap.specMap == 1 && this.check_IDMap_PVP();
				if (flag4)
				{
					GameScreen.tickPvP = 60;
				}
				bool flag5 = b == 1;
				if (flag5)
				{
					LoadMap.isOnlineMap = true;
					GameCanvas.loadmap.loadmap(dataMap.dataMap);
					GameCanvas.loadMapScr.mItemMap = dataMap.dataItemMap;
					LoadMap.vecPointChange.removeAllElements();
					bool flag6 = GameCanvas.loadmap.idMap != 157 && GameCanvas.loadmap.idMap != 159 && GameCanvas.loadmap.idMap != 161;
					if (flag6)
					{
						for (int i = 0; i < dataMap.vecPointMap.size(); i++)
						{
							Point o = (Point)dataMap.vecPointMap.elementAt(i);
							LoadMap.vecPointChange.addElement(o);
						}
					}
				}
				bool flag7 = b == 0;
				if (flag7)
				{
					LoadMap.isOnlineMap = false;
					bool flag8 = LoadMap.specMap == 5;
					if (flag8)
					{
						this.LoadRedLine(false);
					}
					else
					{
						bool flag9 = LoadMap.specMap == 8;
						if (flag9)
						{
							MapGotoSky.setPos();
						}
						else
						{
							bool flag10 = LoadMap.specMap == 12;
							if (flag10)
							{
								MapGotoGod.setPos();
							}
						}
					}
				}
				LoadMapScreen.IDBack = dataMap.IdBack;
				LoadMapScreen.HBack = dataMap.hBack;
				LoadMapScreen.isNextMap = true;
				bool flag11 = b == 1;
				if (flag11)
				{
					GameCanvas.gameScr.setTypeViewPlayer(typeViewPlayer);
				}
				sbyte b2 = msg.reader().readByte();
				sbyte level = msg.reader().readByte();
				LoadMapScreen.typeChangeMap = msg.reader().readByte();
				bool flag12 = b2 < 0 || GameCanvas.lowGraphic;
				if (flag12)
				{
					GameScreen.effMap = null;
				}
				else
				{
					GameScreen.effMap = new Effect_Map(b2, level);
				}
				bool flag13 = LoadMap.specMap == 3;
				if (flag13)
				{
					GlobalService.gI().Get_Xp_Map_Train(0);
					Player.AutoFireCur = Player.typeAutoFireMain;
					sbyte b3 = msg.reader().readByte();
					MainObject.mPosMapTrain = mSystem.new_M_Int((int)b3, 2);
					for (int j = 0; j < (int)b3; j++)
					{
						for (int k = 0; k < 2; k++)
						{
							MainObject.mPosMapTrain[j][k] = (int)msg.reader().readByte();
						}
					}
					Player.strTimeChange = msg.reader().readUTF();
				}
				Interface_Game.nameMap = dataMap.nameMap;
				bool flag14 = LoadMap.specMap == 4;
				if (flag14)
				{
					GameScreen.player.boatSea = new Boat(GameScreen.player.ID, GameScreen.player.x, GameScreen.player.y, 0, (sbyte)GameScreen.player.type_left_right);
					GameScreen.player.setSpeed(4, 3);
					GameScreen.player.vySea = 4;
					bool flag15 = !GameCanvas.lowGraphic;
					if (flag15)
					{
						GameScreen.effSea = new Effect_Map(4, 0);
					}
				}
				else
				{
					bool flag16 = LoadMap.isOnlineMap && LoadMap.specMap != 5;
					if (flag16)
					{
						GameScreen.player.boatSea = null;
						GameScreen.player.setSpeed(7, 7);
						GameScreen.effSea = null;
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CF5 RID: 3317 RVA: 0x000FD720 File Offset: 0x000FB920
	public void PvP_Thong_Bao(Message msg)
	{
		try
		{
			Interface_Game.setTypePvP(msg.reader().readByte());
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CF6 RID: 3318 RVA: 0x000FD758 File Offset: 0x000FB958
	public void Archi_Daily(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			bool flag = b == 0;
			if (flag)
			{
				string name = msg.reader().readUTF();
				sbyte b2 = msg.reader().readByte();
				mVector mVector = new mVector();
				for (int i = 0; i < (int)b2; i++)
				{
					InfoArchi o = new InfoArchi(msg.reader().readUTF(), msg.reader().readUTF(), msg.reader().readInt(), msg.reader().readInt(), msg.reader().readShort(), msg.reader().readByte());
					mVector.addElement(o);
				}
				MsgArchiDaily dgl = GameCanvas.Start_Archi_Dialog(name, mVector);
				GameCanvas.Start_Sub_Dialog(dgl);
			}
			else
			{
				bool flag2 = b == 1;
				if (flag2)
				{
					sbyte b3 = msg.reader().readByte();
					bool flag3 = MsgArchiDaily.vecArchi != null && b3 >= 0 && (int)b3 < MsgArchiDaily.vecArchi.size();
					if (flag3)
					{
						InfoArchi infoArchi = (InfoArchi)MsgArchiDaily.vecArchi.elementAt((int)b3);
						infoArchi.typeReward = msg.reader().readByte();
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CF7 RID: 3319 RVA: 0x000FD8A8 File Offset: 0x000FBAA8
	public void Table_Match(Message msg)
	{
		try
		{
			mVector mVector = new mVector();
			sbyte b = msg.reader().readByte();
			for (int i = 0; i < (int)b; i++)
			{
				InfoMatch infoMatch = new InfoMatch();
				infoMatch.type = (int)msg.reader().readByte();
				bool flag = infoMatch.type == 0 || infoMatch.type == 2;
				if (flag)
				{
					infoMatch.mname = new string[2];
					infoMatch.mname[0] = msg.reader().readUTF();
					infoMatch.mname[1] = msg.reader().readUTF();
				}
				else
				{
					bool flag2 = infoMatch.type == 1;
					if (flag2)
					{
						infoMatch.mname = new string[4];
						infoMatch.mname[0] = msg.reader().readUTF();
						infoMatch.mname[1] = msg.reader().readUTF();
						infoMatch.mname[2] = msg.reader().readUTF();
						infoMatch.mname[3] = msg.reader().readUTF();
					}
				}
				infoMatch.typeLeftRight = (int)msg.reader().readByte();
				mVector.addElement(infoMatch);
				MainDialog dgl = GameCanvas.Start_Match_Dialog(mVector);
				GameCanvas.Start_Sub_Dialog(dgl);
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CF8 RID: 3320 RVA: 0x000FDA00 File Offset: 0x000FBC00
	public void ReadPartNew(Message msg)
	{
		try
		{
			short num = msg.reader().readShort();
			sbyte type = msg.reader().readByte();
			mPart mPart = new mPart((int)type);
			for (int i = 0; i < mPart.pi.Length; i++)
			{
				mPart.pi[i] = new PartImage();
				mPart.pi[i].id = msg.reader().readShort();
				mPart.pi[i].dx = msg.reader().readByte();
				mPart.pi[i].dy = msg.reader().readByte();
			}
			CharPartInfo.hashMyPart.put(string.Empty + num.ToString(), mPart);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CF9 RID: 3321 RVA: 0x000FDAD4 File Offset: 0x000FBCD4
	public void updateXP_Arena(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			MainObject mainObject = MainObject.get_Object((int)id, 0);
			bool flag = mainObject != null;
			if (flag)
			{
				mainObject.colorXPArena = 0;
				mainObject.xpArena = msg.reader().readInt();
				sbyte b = msg.reader().readByte();
				bool flag2 = b == 1;
				if (flag2)
				{
					mainObject.colorXPArena = 6;
				}
				else
				{
					bool flag3 = b == 2 || b == 3;
					if (flag3)
					{
						mainObject.colorXPArena = 1;
					}
					else
					{
						bool flag4 = b <= 10;
						if (flag4)
						{
							mainObject.colorXPArena = 4;
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CFA RID: 3322 RVA: 0x000FDB88 File Offset: 0x000FBD88
	public void NewDialog(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			string info = msg.reader().readUTF();
			bool flag = b == 0;
			if (flag)
			{
				mVector mVector = new mVector();
				mVector.addElement(TabInventory.cmdSellWhite);
				mVector.addElement(TabInventory.cmdSell_W_G);
				GameCanvas.Start_Normal_DiaLog(info, mVector, true);
			}
			else
			{
				bool flag2 = b == 1;
				if (flag2)
				{
					mVector mVector2 = new mVector();
					sbyte b2 = msg.reader().readByte();
					for (int i = 0; i < (int)b2; i++)
					{
						sbyte typeItem = msg.reader().readByte();
						string name = msg.reader().readUTF();
						short idIcon = msg.reader().readShort();
						mVector2.addElement(new MainItem(typeItem, (short)i, idIcon, 0, 0, 0)
						{
							name = name
						});
					}
					MsgDialog msgDialog = new MsgDialog();
					msgDialog.setinfoItem(info, mVector2, null, true);
					GameCanvas.Start_Current_Dialog(msgDialog);
				}
				else
				{
					bool flag3 = b == 2;
					if (flag3)
					{
						bool flag4 = GameCanvas.currentScreen != GameCanvas.gameScr;
						if (flag4)
						{
							GameCanvas.gameScr.Show();
						}
						GameCanvas.Start_Normal_Only_CmdClose_DiaLog(info);
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CFB RID: 3323 RVA: 0x000FDCE4 File Offset: 0x000FBEE4
	public void TypeNpcEvent(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			MainObject mainObject = MainObject.get_Object((int)id, 2);
			sbyte typeNpcEvent = msg.reader().readByte();
			bool flag = mainObject != null;
			if (flag)
			{
				mainObject.typeNpcEvent = typeNpcEvent;
				mainObject.setPosEvent();
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CFC RID: 3324 RVA: 0x000FDD44 File Offset: 0x000FBF44
	public void TimeItemDrop(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			sbyte tem = msg.reader().readByte();
			MainObject mainObject = MainObject.get_Object((int)id, tem);
			short num = msg.reader().readShort();
			string text = msg.reader().readUTF();
			bool flag = mainObject != null;
			if (flag)
			{
				mainObject.timeItemDropEvent = (int)num;
				bool flag2 = num != -1;
				if (flag2)
				{
					mainObject.timeRemove = (int)num;
				}
				mainObject.timeBeginItemDropEvent = GameCanvas.timeNow;
				mainObject.namePlayer = text;
				mSystem.outz(string.Concat(new string[]
				{
					"item drop id cat ",
					id.ToString(),
					" - ",
					tem.ToString(),
					" namePlayer =",
					text,
					"!"
				}));
				mainObject.isDrop42 = true;
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CFD RID: 3325 RVA: 0x000FDE34 File Offset: 0x000FC034
	public void Weapon_fashion(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			sbyte tem = msg.reader().readByte();
			MainObject mainObject = MainObject.get_Object((int)id, tem);
			bool flag = mainObject != null;
			if (flag)
			{
				sbyte b = msg.reader().readByte();
				short num = msg.reader().readShort();
				bool flag2 = mainObject.name == GameScreen.player.name && b == 0;
				if (flag2)
				{
					mainObject.weaponFashion = num;
				}
				bool flag3 = b == 6;
				if (flag3)
				{
					mainObject.sethead(num);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CFE RID: 3326 RVA: 0x000FDEE4 File Offset: 0x000FC0E4
	public void Market(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			bool flag = b == 2;
			if (flag)
			{
				int num = MotherCanvas.hw - (MainTab.wTab + 130) / 2;
				bool flag2 = num < 0;
				if (flag2)
				{
					num = 0;
				}
				GameCanvas.tabMarketScr = new TabScreen(num, 0);
				mVector mVector = new mVector();
				ScreenMarket o = new ScreenMarket(T.tabHat_Wea, null, GameCanvas.tabMarketScr, 0);
				mVector.addElement(o);
				GameCanvas.tabMarketScr.addVecTab(mVector);
				ScreenMarket o2 = new ScreenMarket(T.tabAo_Quan, null, GameCanvas.tabMarketScr, 1);
				mVector.addElement(o2);
				ScreenMarket o3 = new ScreenMarket(T.tabTranhsuc, null, GameCanvas.tabMarketScr, 2);
				mVector.addElement(o3);
				ScreenMarket o4 = new ScreenMarket(T.tabNguyenLieu, null, GameCanvas.tabMarketScr, 5);
				mVector.addElement(o4);
				ScreenMarket o5 = new ScreenMarket(T.tabVatPham, null, GameCanvas.tabMarketScr, 6);
				mVector.addElement(o5);
				ScreenMarket o6 = new ScreenMarket(T.tabChest, null, GameCanvas.tabMarketScr, 3);
				mVector.addElement(o6);
				GameCanvas.tabInvenMarket = new TabInventory(T.tabInven, Player.vecInventory, 5, num);
				GameCanvas.tabInvenMarket.initCmd();
				mVector.addElement(GameCanvas.tabInvenMarket);
				GameCanvas.tabMarketScr.idSelect = 0;
				GameCanvas.tabMarketScr.Show(GameCanvas.gameScr);
				GameCanvas.tabMarketScr.setTabSelect();
				GameCanvas.tabMarketScr.setCurTypetab(1);
			}
			else
			{
				bool flag3 = b == 3;
				if (flag3)
				{
					bool flag4 = GameCanvas.tabMarketScr != null;
					if (flag4)
					{
						sbyte index = msg.reader().readByte();
						short num2 = msg.reader().readShort();
						mVector mVector2 = new mVector();
						for (int i = 0; i < (int)num2; i++)
						{
							MainItem mainItem = this.readUpdateItem(msg, false);
							mainItem.priceVND = msg.reader().readInt();
							mainItem.setTimeMarket(msg.reader().readInt());
							mainItem.typeMarket = msg.reader().readByte();
							mVector2.addElement(mainItem);
						}
						GameCanvas.tabMarketScr.updateVecDataMarket(index, mVector2);
					}
				}
				else
				{
					bool flag5 = b == 8;
					if (flag5)
					{
						sbyte b2 = msg.reader().readByte();
						sbyte[] array = new sbyte[(int)b2];
						for (int j = 0; j < (int)b2; j++)
						{
							array[j] = 0;
						}
						MsgArea msgArea = new MsgArea();
						msgArea.setinfoChangeArea(array, 1);
						GameCanvas.Start_Current_Dialog(msgArea);
					}
					else
					{
						bool flag6 = b == 9 && GameCanvas.tabMarketScr != null;
						if (flag6)
						{
							sbyte index2 = msg.reader().readByte();
							short num3 = msg.reader().readShort();
							mVector mVector3 = new mVector();
							for (int k = 0; k < (int)num3; k++)
							{
								sbyte b3 = msg.reader().readByte();
								MainItem mainItem2 = (b3 != 3) ? this.readUpdatePotionMarket(msg, b3) : this.readUpdateItem(msg, false);
								mainItem2.priceVND = msg.reader().readInt();
								int timeMarket = msg.reader().readInt();
								mainItem2.setTimeMarket(timeMarket);
								mainItem2.typeMarket = msg.reader().readByte();
								mVector3.addElement(mainItem2);
							}
							GameCanvas.tabMarketScr.updateVecDataMarket(index2, mVector3);
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000CFF RID: 3327 RVA: 0x000FE270 File Offset: 0x000FC470
	public MainItem readUpdatePotionMarket(Message msg, sbyte cat)
	{
		try
		{
			short idmarket = msg.reader().readShort();
			short num = msg.reader().readShort();
			short numPotion = msg.reader().readShort();
			MainItem mainItem = null;
			bool flag = cat == 4;
			if (flag)
			{
				Potion templatePotion = Potion.getTemplatePotion(num);
				mainItem = new MainItem(cat, templatePotion.idIcon, num);
				mainItem.IDMarket = idmarket;
				mainItem.numPotion = numPotion;
				mainItem.name = templatePotion.name;
				mainItem.namepaint = templatePotion.name;
				bool isUpdateTem = templatePotion.isUpdateTem;
				if (isUpdateTem)
				{
					bool flag2 = !mainItem.getInfoPotion(templatePotion.indexInfoPotion);
					if (flag2)
					{
						Potion.vecPotionDonotInfo.addElement(mainItem);
					}
				}
				else
				{
					mainItem.setInfoPotion(templatePotion.info);
				}
			}
			else
			{
				bool flag3 = cat == 7;
				if (flag3)
				{
					MainMaterial mainMaterial = (MainMaterial)MainItem.hashMaterialTem.get(string.Empty + num.ToString());
					mainItem = new MainItem(cat, mainMaterial.idIcon, num);
					mainItem.IDMarket = idmarket;
					mainItem.numPotion = numPotion;
					mainItem.name = mainMaterial.name;
					mainItem.namepaint = mainMaterial.name;
					mainItem.setInfoPotion(mainMaterial.info);
				}
			}
			return mainItem;
		}
		catch (Exception)
		{
		}
		return null;
	}

	// Token: 0x06000D00 RID: 3328 RVA: 0x000FE3DC File Offset: 0x000FC5DC
	public void upgradeDevil(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			bool flag = b == 20;
			if (flag)
			{
				this.openGhepnhieu(msg);
			}
			else
			{
				bool flag2 = b == 21;
				if (flag2)
				{
					sbyte b2 = msg.reader().readByte();
					string showServer = msg.reader().readUTF();
					ScreenUpgrade.instance.showServer = showServer;
					bool flag3 = b2 == 1;
					if (flag3)
					{
						ScreenUpgrade.instance.Step = 1;
					}
					else
					{
						ScreenUpgrade.instance.Step = 2;
					}
				}
				else
				{
					bool flag4 = b == 13;
					if (flag4)
					{
						SplitScreen.instance = new SplitScreen(8, -1);
						SplitScreen.instance.Show(GameCanvas.gameScr);
					}
					else
					{
						bool flag5 = b == 14;
						if (flag5)
						{
							sbyte b3 = msg.reader().readByte();
							short id = msg.reader().readShort();
							sbyte b4 = msg.reader().readByte();
							short num = msg.reader().readShort();
							MainItem itemVec = MainItem.getItemVec(b4, id, Player.vecInventory);
							bool flag6 = itemVec != null;
							if (flag6)
							{
								sbyte color = itemVec.colorName;
								bool flag7 = b4 != 3;
								if (flag7)
								{
									color = 5;
								}
								MainItem mainItem = new MainItem(b4, itemVec.ID, itemVec.idIcon, num, color, itemVec.LvUpgrade);
								ScreenUpgrade.mItemUpgrade[(int)b3] = mainItem;
							}
						}
						else
						{
							bool flag8 = b == 15;
							if (flag8)
							{
								for (int i = 0; i < ScreenUpgrade.mItemUpgrade.Length; i++)
								{
									ScreenUpgrade.mItemUpgrade[i] = null;
								}
							}
							else
							{
								bool flag9 = b == 16;
								if (flag9)
								{
									string info = msg.reader().readUTF();
									GameCanvas.Start_Normal_Only_CmdClose_DiaLog(info);
								}
								else
								{
									bool flag10 = b == 17;
									if (flag10)
									{
										sbyte b5 = msg.reader().readByte();
										string showServer2 = msg.reader().readUTF();
										SplitScreen.instance.showServer = showServer2;
										bool flag11 = b5 == 1;
										if (flag11)
										{
											SplitScreen.instance.Step = 1;
										}
										else
										{
											SplitScreen.instance.Step = 3;
										}
									}
									else
									{
										bool flag12 = b == 19;
										if (flag12)
										{
											sbyte tile = msg.reader().readByte();
											SplitScreen.instance.tile = tile;
										}
										else
										{
											bool flag13 = b == 8;
											if (flag13)
											{
												ScreenUpgradeSkillDevil.instance = new ScreenUpgradeSkillDevil();
												ScreenUpgradeSkillDevil.instance.begin();
												ScreenUpgradeSkillDevil.instance.Show(GameCanvas.gameScr);
											}
											else
											{
												bool flag14 = b == 9;
												if (flag14)
												{
													sbyte b6 = msg.reader().readByte();
													short id2 = msg.reader().readShort();
													sbyte b7 = msg.reader().readByte();
													short num2 = msg.reader().readShort();
													bool flag15 = b7 == 104;
													if (flag15)
													{
														Skill_Info skillFromID = Skill_Info.getSkillFromID(id2);
														MainItem mainItem2 = new MainItem(b7, skillFromID.ID, skillFromID.idIcon, num2, 0, skillFromID.LvUpgrade);
														ScreenUpgrade.mItemUpgrade[(int)b6] = mainItem2;
													}
													else
													{
														MainItem itemVec2 = MainItem.getItemVec(b7, id2, Player.vecInventory);
														bool flag16 = itemVec2 != null;
														if (flag16)
														{
															sbyte color2 = itemVec2.colorName;
															bool flag17 = b7 != 3;
															if (flag17)
															{
																color2 = 5;
															}
															MainItem mainItem3 = new MainItem(b7, itemVec2.ID, itemVec2.idIcon, num2, color2, itemVec2.LvUpgrade);
															ScreenUpgrade.mItemUpgrade[(int)b6] = mainItem3;
														}
													}
												}
												else
												{
													bool flag18 = b == 10;
													if (flag18)
													{
														for (int j = 0; j < ScreenUpgrade.mItemUpgrade.Length; j++)
														{
															ScreenUpgrade.mItemUpgrade[j] = null;
														}
													}
													else
													{
														bool flag19 = b == 11;
														if (flag19)
														{
															string info2 = msg.reader().readUTF();
															GameCanvas.Start_Normal_Only_CmdClose_DiaLog(info2);
														}
														else
														{
															bool flag20 = b == 12;
															if (flag20)
															{
																sbyte b8 = msg.reader().readByte();
																string showServer3 = msg.reader().readUTF();
																ScreenUpgradeSkillDevil.instance.showServer = showServer3;
																bool flag21 = b8 == 1;
																if (flag21)
																{
																	ScreenUpgradeSkillDevil.instance.Step = 1;
																}
																else
																{
																	ScreenUpgradeSkillDevil.instance.Step = 3;
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D01 RID: 3329 RVA: 0x000FE834 File Offset: 0x000FCA34
	public void cmdEvent(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			mSystem.outz(" cmdEvent action = " + b.ToString());
			bool flag = b == 2;
			if (flag)
			{
				bool flag2 = GameCanvas.EventDialog == null;
				if (flag2)
				{
					GameCanvas.EventDialog = new MsgDialogEvent();
					GameCanvas.EventDialog.setInfoMerryCM();
				}
				sbyte b2 = msg.reader().readByte();
				sbyte[] array = new sbyte[(int)b2];
				for (int i = 0; i < (int)b2; i++)
				{
					array[i] = msg.reader().readByte();
				}
				GameCanvas.EventDialog.updateDataCM(array);
			}
			else
			{
				bool flag3 = b == 3;
				if (flag3)
				{
					bool flag4 = GameCanvas.EventDialog == null;
					if (flag4)
					{
						GameCanvas.EventDialog = new MsgDialogEvent();
					}
					GameCanvas.EventDialog.setInfoMerryCM();
					GameCanvas.Start_Sub_Dialog(GameCanvas.EventDialog);
				}
				else
				{
					bool flag5 = b == 1;
					if (flag5)
					{
						GameCanvas.end_Dialog();
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D02 RID: 3330 RVA: 0x000FE948 File Offset: 0x000FCB48
	public void ReadEventTrangTri(Message msg)
	{
		try
		{
			sbyte typeTrangTri = msg.reader().readByte();
			sbyte b = msg.reader().readByte();
			bool flag = b == 2;
			if (flag)
			{
				bool flag2 = GameCanvas.TrangTriDialog == null;
				if (flag2)
				{
					GameCanvas.TrangTriDialog = new MsgDialogTrangTri(typeTrangTri);
					GameCanvas.TrangTriDialog.setInfoTrangTri(null);
				}
				sbyte b2 = msg.reader().readByte();
				short[] array = new short[(int)b2];
				sbyte[] array2 = new sbyte[(int)b2];
				for (int i = 0; i < (int)b2; i++)
				{
					array[i] = msg.reader().readShort();
					array2[i] = msg.reader().readByte();
				}
				GameCanvas.TrangTriDialog.updateDataTrangTri(array, array2);
			}
			else
			{
				bool flag3 = b == 3;
				if (flag3)
				{
					bool flag4 = GameCanvas.TrangTriDialog == null;
					if (flag4)
					{
						GameCanvas.TrangTriDialog = new MsgDialogTrangTri(typeTrangTri);
					}
					short num = msg.reader().readShort();
					short[][] array3 = new short[(int)num][];
					for (int j = 0; j < (int)num; j++)
					{
						short num2 = msg.reader().readShort();
						array3[j] = new short[(int)num2];
						for (int k = 0; k < (int)num2; k++)
						{
							array3[j][k] = msg.reader().readShort();
						}
					}
					GameCanvas.TrangTriDialog.setInfoTrangTri(array3);
					GameCanvas.Start_Sub_Dialog(GameCanvas.TrangTriDialog);
				}
				else
				{
					bool flag5 = b == 1;
					if (flag5)
					{
						GameCanvas.end_Dialog();
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D03 RID: 3331 RVA: 0x000FEAFC File Offset: 0x000FCCFC
	public void ReadTrongCay(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			sbyte tem = msg.reader().readByte();
			MainObject mainObject = MainObject.get_Object((int)id, tem);
			mainObject.timeLeft = (int)msg.reader().readShort();
			mainObject.state = msg.reader().readByte();
			mainObject.timeBegin = mSystem.currentTimeMillis();
			mSystem.outz(string.Concat(new string[]
			{
				"id ",
				id.ToString(),
				" cat ",
				tem.ToString(),
				" time ",
				mainObject.timeLeft.ToString(),
				" state",
				mainObject.state.ToString()
			}));
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D04 RID: 3332 RVA: 0x000FEBD4 File Offset: 0x000FCDD4
	public void getTemplate(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			sbyte[] data = new sbyte[msg.reader().available()];
			msg.reader().read(ref data);
			ByteArrayInputStream bis = new ByteArrayInputStream(data);
			DataInputStream dataInputStream = new DataInputStream(bis);
			bool flag = b == 4;
			if (flag)
			{
				Potion.LoadDataPotionTemplate(dataInputStream, 4);
				Potion.CheckAddDataTemplate();
			}
			else
			{
				bool flag2 = b == 1;
				if (flag2)
				{
					CatalogyMonster.LoadDataMonTemplate(dataInputStream);
				}
				else
				{
					bool flag3 = b == 98;
					if (flag3)
					{
						GameCanvas.loadmap.load_Table_Map(dataInputStream);
						ReadMessenge.timeLoadItemMap = 30;
						LoadMap.demSendTem--;
					}
					else
					{
						bool flag4 = b == 97;
						if (flag4)
						{
							Plash.readDataPlash(dataInputStream);
						}
						else
						{
							bool flag5 = b == 96;
							if (flag5)
							{
								sbyte b2 = dataInputStream.readByte();
								string v = dataInputStream.readUTF();
								MainItem.hashAttriKichAn.put(string.Empty + b2.ToString(), v);
								Item.CheckAddDataKichAn();
							}
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D05 RID: 3333 RVA: 0x000FECF0 File Offset: 0x000FCEF0
	public void disconnect_Why(Message msg)
	{
		try
		{
			GameCanvas.infoDisConnect = msg.reader().readUTF();
			GlobalService.gI().reDisconectWhy();
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D06 RID: 3334 RVA: 0x000FED34 File Offset: 0x000FCF34
	public void Max_Level(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			short num = (short)(Player.pointMaxLevelAttri = (int)msg.reader().readShort());
			bool flag = b == 0;
			if (flag)
			{
				Player.vecMaxLevelAttri.removeAllElements();
				mVector mVector = new mVector();
				sbyte b2 = msg.reader().readByte();
				for (int i = 0; i < (int)b2; i++)
				{
					MaxLevelAttribute o = new MaxLevelAttribute((int)msg.reader().readShort(), msg.reader().readUTF(), (int)msg.reader().readShort(), (int)msg.reader().readShort());
					mVector.addElement(o);
				}
				Player.vecMaxLevelAttri = mVector;
			}
			else
			{
				bool flag2 = b == 1;
				if (flag2)
				{
					short num2 = msg.reader().readShort();
					bool flag3 = Player.vecMaxLevelAttri == null;
					if (!flag3)
					{
						for (int j = 0; j < Player.vecMaxLevelAttri.size(); j++)
						{
							MaxLevelAttribute maxLevelAttribute = (MaxLevelAttribute)Player.vecMaxLevelAttri.elementAt(j);
							bool flag4 = maxLevelAttribute.Id == (int)num2;
							if (flag4)
							{
								maxLevelAttribute.value = (int)msg.reader().readShort();
							}
						}
					}
				}
				else
				{
					bool flag5 = b == 2;
					if (flag5)
					{
						ScreenMaxLevel.gI().setData();
						ScreenMaxLevel.gI().Show(GameCanvas.gameScr);
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D07 RID: 3335 RVA: 0x000FEEC0 File Offset: 0x000FD0C0
	public void Wanted(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			bool flag = b == 4;
			if (flag)
			{
				GameScreen.player.wanted = msg.reader().readInt();
			}
			else
			{
				bool flag2 = RoomWantedScreen.instance == null;
				if (flag2)
				{
					RoomWantedScreen.instance = new RoomWantedScreen();
				}
				bool flag3 = b == 5;
				if (flag3)
				{
					int timeCmdFind = msg.reader().readInt();
					RoomWantedScreen.instance.setTimeCmdFind(timeCmdFind);
				}
				else
				{
					RoomWantedScreen.instance.setAction(b);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D08 RID: 3336 RVA: 0x000FEF60 File Offset: 0x000FD160
	public void ChestWanted(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			bool flag = b == 0;
			if (flag)
			{
				sbyte b2 = msg.reader().readByte();
				short id = msg.reader().readShort();
				short idIcon = msg.reader().readShort();
				sbyte typeItem = msg.reader().readByte();
				string name = msg.reader().readUTF();
				short maxTimeUse = msg.reader().readShort();
				short timeUse = msg.reader().readShort();
				short ruby = msg.reader().readShort();
				Item item = new Item(typeItem, id, idIcon, name, timeUse, maxTimeUse, ruby);
				Player.mChestWanted[(int)b2] = item;
			}
			bool flag2 = b == 1;
			if (flag2)
			{
				sbyte b3 = msg.reader().readByte();
				Player.mChestWanted[(int)b3] = null;
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D09 RID: 3337 RVA: 0x0000BC5B File Offset: 0x00009E5B
	public void OpenMessenger(Message msg)
	{
		GameCanvas.chatTabScr.getCurTab(1);
		GameCanvas.chatTabScr.Show(GameCanvas.currentScreen);
	}

	// Token: 0x06000D0A RID: 3338 RVA: 0x000FF048 File Offset: 0x000FD248
	public void UpdateLoL(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			bool flag = b == 0;
			if (flag)
			{
				sbyte b2 = msg.reader().readByte();
				for (int i = 0; i < (int)b2; i++)
				{
					bool flag2 = i < Interface_Game.mValueLoL.Length;
					if (flag2)
					{
						Interface_Game.mValueLoL[i][1] = (short)msg.reader().readByte();
					}
				}
			}
			else
			{
				bool flag3 = b == 1;
				if (flag3)
				{
					sbyte b3 = msg.reader().readByte();
					for (int j = 0; j < (int)b3; j++)
					{
						short id = msg.reader().readShort();
						sbyte typePK = msg.reader().readByte();
						MainObject mainObject = MainObject.get_Object((int)id, 1);
						bool flag4 = mainObject != null;
						if (flag4)
						{
							mainObject.typePK = typePK;
						}
					}
				}
				else
				{
					bool flag5 = b == 2;
					if (flag5)
					{
						sbyte b4 = msg.reader().readByte();
						sbyte type = msg.reader().readByte();
						string str = msg.reader().readUTF();
						InfoShowNotify o = new InfoShowNotify(str + ": " + T.mChatInLoL[(int)b4], type);
						Interface_Game.vecQuickChatLoL.insertElementAt(o, 0);
					}
					else
					{
						bool flag6 = b == 3;
						if (flag6)
						{
							Interface_Game.killLeft = (int)msg.reader().readShort();
							Interface_Game.truLeft = (int)msg.reader().readShort();
							Interface_Game.killRight = (int)msg.reader().readShort();
							Interface_Game.truRight = (int)msg.reader().readShort();
						}
						else
						{
							bool flag7 = b == 4;
							if (flag7)
							{
								Interface_Game.valueHoiSinhLOL = msg.reader().readByte();
							}
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D0B RID: 3339 RVA: 0x000FF218 File Offset: 0x000FD418
	public void Fire_Object_NEW(Message msg)
	{
		try
		{
			bool isNextMap = LoadMapScreen.isNextMap;
			if (isNextMap)
			{
				bool flag = GameCanvas.lowGraphic && GameScreen.vecObjFire.size() > 20;
				if (flag)
				{
					GameScreen.vecObjFire.removeElementAt(1);
				}
				GameScreen.vecObjFire.addElement(msg);
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D0C RID: 3340 RVA: 0x0000BC7A File Offset: 0x00009E7A
	public void DonotAutoReconnect(Message msg)
	{
		Player.StepAutoRe = 6;
	}

	// Token: 0x06000D0D RID: 3341 RVA: 0x000FF280 File Offset: 0x000FD480
	public void QuickChat(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			sbyte tem = msg.reader().readByte();
			sbyte b = msg.reader().readByte();
			MainObject mainObject = MainObject.get_Object((int)id, tem);
			bool flag = mainObject != null && b >= 0 && (int)b < T.mChatInGame.Length;
			if (flag)
			{
				string text = T.mChatInGame[(int)b];
				text = (mainObject.strChatPopup = GameMidlet.fixString(text));
				bool flag2 = mainObject.typeObject == 0;
				if (flag2)
				{
					GameCanvas.chatTabScr.addNewChat(T.tabServer, string.Empty, mainObject.name + ": " + text, 1, false);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D0E RID: 3342 RVA: 0x000FF348 File Offset: 0x000FD548
	public void getDataInfoPotion(Message msg)
	{
		try
		{
			short index = msg.reader().readShort();
			string text = msg.reader().readUTF();
			Potion.hashInfoPotion.put(string.Empty + index.ToString(), text);
			Potion.checkVecNonInfo(index, text);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D0F RID: 3343 RVA: 0x000FF3AC File Offset: 0x000FD5AC
	public void updatePoint_WorldWar(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			MainObject mainObject = MainObject.get_Object((int)id, 0);
			bool flag = mainObject != null;
			if (flag)
			{
				mainObject.checkWW = (int)msg.reader().readByte();
				mainObject.killWW = (int)msg.reader().readShort();
				mainObject.deadWW = (int)msg.reader().readShort();
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D10 RID: 3344 RVA: 0x000FF424 File Offset: 0x000FD624
	public void update_MP_HP_Eff(Message msg)
	{
		try
		{
			short num = msg.reader().readShort();
			sbyte b = msg.reader().readByte();
			MainObject mainObject = MainObject.get_Object((int)num, b);
			bool flag = mainObject == null || mainObject.returnAction();
			if (!flag)
			{
				sbyte b2 = msg.reader().readByte();
				mainObject.maxHp = msg.reader().readInt();
				int hp = msg.reader().readInt();
				int num2 = msg.reader().readInt();
				bool flag2 = num2 != 0;
				if (flag2)
				{
					string content = string.Empty + num2.ToString();
					bool flag3 = num2 > 0;
					if (flag3)
					{
						content = "+" + num2.ToString();
					}
					mainObject.Hp = hp;
					bool flag4 = b2 == 1;
					if (flag4)
					{
						GameScreen.addEffectNumBig_NEW_AP(num2, 0, mainObject.x, mainObject.y - mainObject.hOne, 20);
					}
					else
					{
						GameScreen.addEffectNum(content, mainObject.x - 12, mainObject.y - mainObject.hOne / 4 * 3 - this.lechYNum, 3);
					}
				}
				bool flag5 = mainObject.Action == 4 && mainObject.Hp > 0;
				if (flag5)
				{
					mainObject.Reveive();
				}
				for (int i = 0; i < Player.vecParty.size(); i++)
				{
					InfoMemList infoMemList = (InfoMemList)Player.vecParty.elementAt(i);
					bool flag6 = infoMemList.id == (int)num && b == 0;
					if (flag6)
					{
						infoMemList.updateHP(hp, mainObject.maxHp, mainObject.Lv);
						break;
					}
				}
				bool flag7 = b != 1;
				if (flag7)
				{
					mainObject.maxMp = msg.reader().readInt();
					int mp = msg.reader().readInt();
					int num3 = msg.reader().readInt();
					bool flag8 = num3 != 0;
					if (flag8)
					{
						string content2 = string.Empty + num3.ToString();
						bool flag9 = num3 > 0;
						if (flag9)
						{
							content2 = "+" + num3.ToString();
						}
						mainObject.Mp = mp;
						GameScreen.addEffectNum(content2, mainObject.x + 12, mainObject.y - mainObject.hOne / 4 * 3 - this.lechYNum, 4);
					}
				}
				this.lechYNum += 10;
				bool flag10 = this.lechYNum > 20;
				if (flag10)
				{
					this.lechYNum = 0;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D11 RID: 3345 RVA: 0x000FF6C8 File Offset: 0x000FD8C8
	public void Eff_Kich_An(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			short num = msg.reader().readShort();
			short id = msg.reader().readShort();
			sbyte tem = msg.reader().readByte();
			sbyte b2 = msg.reader().readByte();
			int num2 = msg.reader().readInt();
			MainObject mainObject = MainObject.get_Object((int)id, tem);
			bool flag = mainObject != null && b != 11;
			if (flag)
			{
				GameScreen.addEffectEnd(143, (int)b, mainObject.x, mainObject.y - 50, 0, mainObject);
				bool flag2 = mainObject == GameScreen.player;
				if (flag2)
				{
					Item_Skill_Eff item_Skill_Eff = new Item_Skill_Eff((short)(400 + (int)b), (short)b, 1500);
					GameScreen.interfaceGame.addEffCurrent(item_Skill_Eff);
					Player.setDelaySkill((int)item_Skill_Eff.indexHotKey, (int)(num * 1000), true, 0);
				}
			}
			short id2 = msg.reader().readShort();
			sbyte tem2 = msg.reader().readByte();
			sbyte type = msg.reader().readByte();
			int num3 = msg.reader().readInt();
			MainObject mainObject2 = MainObject.get_Object((int)id2, tem2);
			switch (b)
			{
			case 0:
			{
				bool flag3 = mainObject != null;
				if (flag3)
				{
					Effect_Spec o = new Effect_Spec(mainObject, 11, (short)num2);
					mainObject.vecEffspec.addElement(o);
				}
				break;
			}
			case 1:
			{
				bool flag4 = mainObject != null;
				if (flag4)
				{
					GameScreen.addEffectNumBig_NEW_AP(num2, 0, mainObject.x, mainObject.y - mainObject.hOne, 21);
				}
				break;
			}
			case 2:
			case 10:
				if (mainObject2 != null)
				{
					mainObject2.addEffSpec((short)type, (short)num3);
				}
				break;
			case 3:
			{
				bool flag5 = mainObject2 != null;
				if (flag5)
				{
					GameScreen.addEffectNumBig_NEW_AP(-num3, 0, mainObject2.x, mainObject2.y - mainObject2.hOne, 22);
				}
				break;
			}
			case 4:
			{
				bool flag6 = mainObject2 != null;
				if (flag6)
				{
					GameScreen.addEffectNumBig_NEW_AP(-num3, 0, mainObject2.x, mainObject2.y - mainObject2.hOne, 21);
				}
				break;
			}
			case 5:
			{
				bool flag7 = mainObject != null;
				if (flag7)
				{
					Effect_Spec o2 = new Effect_Spec(mainObject, 12, (short)num2);
					mainObject.vecEffspec.addElement(o2);
				}
				break;
			}
			case 6:
			{
				bool flag8 = mainObject != null;
				if (flag8)
				{
					GameScreen.addEffectNumBig_NEW_AP(num2, 0, mainObject.x, mainObject.y - mainObject.hOne, 21);
				}
				break;
			}
			case 8:
			case 9:
			{
				bool flag9 = mainObject == null || mainObject != GameScreen.player;
				if (!flag9)
				{
					IDictionaryEnumerator enumerator = Player.delaySkill.GetEnumerator();
					while (enumerator.MoveNext())
					{
						string k = (string)enumerator.Value;
						DelaySkill delaySkill = (DelaySkill)Player.delaySkill.get(k);
						bool flag10 = delaySkill.typeSkill == 1;
						if (flag10)
						{
							delaySkill.value = 0;
						}
					}
				}
				break;
			}
			case 11:
			{
				bool flag11 = mainObject != null;
				if (flag11)
				{
					GameScreen.addEffectNumBig_NEW_AP(num2, 0, mainObject.x, mainObject.y - mainObject.hOne, 21);
				}
				break;
			}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D12 RID: 3346 RVA: 0x000FFA40 File Offset: 0x000FDC40
	public void Count_Kick_Ava(Message msg)
	{
		try
		{
			bool flag = Interface_Game.mCountKichAn == null;
			if (flag)
			{
				Interface_Game.mCountKichAn = new Item_Skill_Eff[20];
			}
			sbyte b = msg.reader().readByte();
			sbyte numPotion = msg.reader().readByte();
			for (int i = 0; i < Interface_Game.mCountKichAn.Length; i++)
			{
				bool flag2 = Interface_Game.mCountKichAn[i] == null;
				if (flag2)
				{
					Interface_Game.mCountKichAn[i] = new Item_Skill_Eff((short)(400 + (int)b), (short)b, 1500);
					Interface_Game.mCountKichAn[i].numPotion = (short)numPotion;
					Interface_Game.mCountKichAn[i].setColorKickAn();
					break;
				}
				bool flag3 = Interface_Game.mCountKichAn[i].ID == (short)b;
				if (flag3)
				{
					Interface_Game.mCountKichAn[i].numPotion = (short)numPotion;
					break;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D13 RID: 3347 RVA: 0x000FFB24 File Offset: 0x000FDD24
	public void GiaoTiep_FormServer(Message msg)
	{
		try
		{
			ReadMessenge.ID_GiaoTiep_Server = msg.reader().readByte();
			ReadMessenge.Str_GiaoTiep_Server = msg.reader().readUTF();
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D14 RID: 3348 RVA: 0x000FFB6C File Offset: 0x000FDD6C
	public void Event(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			sbyte b2 = msg.reader().readByte();
			mSystem.outz("type " + b.ToString() + " action " + b2.ToString());
			bool flag = b == 0;
			if (flag)
			{
				bool flag2 = b2 == 0;
				if (flag2)
				{
					string name = msg.reader().readUTF();
					short time = msg.reader().readShort();
					int tongXiu = msg.reader().readInt();
					int tongTai = msg.reader().readInt();
					int daCuoc = msg.reader().readInt();
					sbyte cua = msg.reader().readByte();
					sbyte kq = msg.reader().readByte();
					sbyte x = msg.reader().readByte();
					sbyte x2 = msg.reader().readByte();
					sbyte x3 = msg.reader().readByte();
					TaiXiuScreen.instance = new TaiXiuScreen(name, tongTai, tongXiu, daCuoc, cua, time);
					TaiXiuScreen.instance.SetXucXac(kq, x, x2, x3, false);
					TaiXiuScreen.instance.Show(GameCanvas.gameScr);
				}
				else
				{
					bool flag3 = b2 == 1;
					if (flag3)
					{
						int tongXiu2 = msg.reader().readInt();
						int tongTai2 = msg.reader().readInt();
						int daCuoc2 = msg.reader().readInt();
						sbyte cua2 = msg.reader().readByte();
						TaiXiuScreen.instance.SetDatCuoc(tongTai2, tongXiu2, daCuoc2, cua2);
					}
					else
					{
						bool flag4 = b2 == 2;
						if (flag4)
						{
							sbyte kq2 = msg.reader().readByte();
							sbyte x4 = msg.reader().readByte();
							sbyte x5 = msg.reader().readByte();
							sbyte x6 = msg.reader().readByte();
							TaiXiuScreen.instance.SetXucXac(kq2, x4, x5, x6, true);
						}
						else
						{
							bool flag5 = b2 == 3;
							if (flag5)
							{
								int tongXiu3 = msg.reader().readInt();
								int tongTai3 = msg.reader().readInt();
								TaiXiuScreen.instance.SetUpdateTaiXiu(tongTai3, tongXiu3);
							}
							else
							{
								bool flag6 = b2 == 4;
								if (flag6)
								{
									sbyte b3 = msg.reader().readByte();
									mVector mVector = new mVector();
									for (int i = 0; i < (int)b3; i++)
									{
										string caption = msg.reader().readUTF();
										mVector.addElement(new iCommand(caption, 100, this));
									}
									GameCanvas.menu.startAt(mVector, 2, T.lichSu);
								}
							}
						}
					}
				}
			}
			else
			{
				bool flag7 = b == 1 && b2 == 0;
				if (flag7)
				{
					mSystem.outz("nau banh");
					GameCanvas.gameScr.setNauBanh(true);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D15 RID: 3349 RVA: 0x000FFE34 File Offset: 0x000FE034
	public void Hanh_Trinh(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			mSystem.outz("Hanh_Trinh>>>>>>>>>>> action=" + b.ToString());
			bool flag = b == 0;
			if (flag)
			{
				short idMinimap = msg.reader().readShort();
				string text = msg.reader().readUTF();
				sbyte b2 = msg.reader().readByte();
				mSystem.outz(string.Concat(new string[]
				{
					"minimap=",
					idMinimap.ToString(),
					" size=",
					b2.ToString(),
					" ten map=",
					text
				}));
				mVector mVector = new mVector();
				for (sbyte b3 = 0; b3 < b2; b3 += 1)
				{
					string namepaint = msg.reader().readUTF();
					sbyte typeItem = msg.reader().readByte();
					short id = msg.reader().readShort();
					int num = (int)msg.reader().readByte();
					short idIcon = msg.reader().readShort();
					Potion potion = new Potion(typeItem, id, idIcon, string.Empty, 0);
					potion.namepaint = namepaint;
					potion.info = msg.reader().readUTF();
					potion.setInfoPotion(potion.info);
					mVector.addElement(potion);
					mSystem.outz(string.Concat(new string[]
					{
						"item ",
						id.ToString(),
						" icon ",
						idIcon.ToString(),
						" info ",
						potion.info
					}));
				}
				SplitScreen.instance = new SplitScreen(21, -1);
				SplitScreen.instance.vecInventory = mVector;
				SplitScreen.instance.getItemCurNew();
				SplitScreen.instance.idMinimap = idMinimap;
				SplitScreen.instance.nameMinimap = text;
				SplitScreen.instance.Show(GameCanvas.gameScr);
			}
			else
			{
				bool flag2 = b == 1;
				if (flag2)
				{
					sbyte b4 = msg.reader().readByte();
					mSystem.outz("size=" + b4.ToString());
					mVector mVector2 = new mVector();
					for (sbyte b5 = 0; b5 < b4; b5 += 1)
					{
						string namepaint2 = msg.reader().readUTF();
						sbyte typeItem2 = msg.reader().readByte();
						short id2 = msg.reader().readShort();
						short idIcon2 = msg.reader().readShort();
						Potion potion2 = new Potion(typeItem2, id2, idIcon2, string.Empty, 0);
						potion2.namepaint = namepaint2;
						potion2.info = msg.reader().readUTF();
						potion2.setInfoPotion(potion2.info);
						mVector2.addElement(potion2);
					}
					SplitScreen.instance.vecDaKhamHanhTrinh = mVector2;
					bool flag3 = b4 == 0;
					if (flag3)
					{
						ScreenUpgrade.mItemUpgrade[0] = null;
					}
					else
					{
						ScreenUpgrade.mItemUpgrade[0] = (MainItem)mVector2.elementAt(0);
					}
					SplitScreen.instance.ChangeCmd();
				}
				else
				{
					bool flag4 = b == 2;
					if (flag4)
					{
						short id3 = msg.reader().readShort();
						mSystem.outz("xoa da id = " + id3.ToString());
						SplitScreen.instance.XoaDa(id3);
					}
					else
					{
						bool flag5 = b == 3;
						if (flag5)
						{
							string namepaint3 = msg.reader().readUTF();
							sbyte typeItem3 = msg.reader().readByte();
							short id4 = msg.reader().readShort();
							int num2 = (int)msg.reader().readByte();
							short idIcon3 = msg.reader().readShort();
							Potion potion3 = new Potion(typeItem3, id4, idIcon3, string.Empty, 0);
							potion3.namepaint = namepaint3;
							potion3.info = msg.reader().readUTF();
							potion3.setInfoPotion(potion3.info);
							SplitScreen.instance.vecInventory.addElement(potion3);
							mSystem.outz(string.Concat(new string[]
							{
								"item ",
								id4.ToString(),
								" icon ",
								idIcon3.ToString(),
								" info ",
								potion3.info
							}));
							ScreenUpgrade.mItemUpgrade[0] = null;
							SplitScreen.instance.ChangeCmd();
						}
						else
						{
							bool flag6 = b == 4;
							if (flag6)
							{
								HanhTrinhScreen.instance = new HanhTrinhScreen();
								HanhTrinhScreen.instance.nameList = msg.reader().readUTF();
								sbyte b6 = msg.reader().readByte();
								mSystem.outz("size=" + b6.ToString());
								HanhTrinhScreen.instance.mTenLang = new string[(int)b6];
								HanhTrinhScreen.instance.mIcon = new short[(int)b6];
								for (sbyte b7 = 0; b7 < b6; b7 += 1)
								{
									HanhTrinhScreen.instance.mTenLang[(int)b7] = msg.reader().readUTF();
									HanhTrinhScreen.instance.mIcon[(int)b7] = msg.reader().readShort();
								}
								HanhTrinhScreen.instance.Show(GameCanvas.gameScr);
							}
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D16 RID: 3350 RVA: 0x00100370 File Offset: 0x000FE570
	public void Quay_So(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			bool flag = b == 0;
			if (flag)
			{
				LuckyScreen.instance = new LuckyScreen();
				LuckyScreen.instance.Show(GameCanvas.gameScr);
				LuckyScreen.instance.mItemShow = null;
				GlobalService.gI().Quayso(3);
				LuckyScreen.mListItemLucky = new mVector();
			}
			else
			{
				bool flag2 = b == 1 || b == 2;
				if (flag2)
				{
					sbyte b2 = msg.reader().readByte();
					LuckyScreen.instance.typeQuay = 0;
					bool flag3 = b2 == 9;
					if (flag3)
					{
						LuckyScreen.instance.typeQuay = 1;
						mSound.playSound(50, mSound.volumeSound);
					}
					else
					{
						mSound.playSound(48, mSound.volumeSound);
					}
					LuckyScreen.instance.StepQuaySo = 1;
					LuckyScreen.instance.tickAction = 0;
					Item_Drop[] array = new Item_Drop[(int)b2];
					for (int i = (int)(b2 - 1); i >= 0; i--)
					{
						sbyte type = msg.reader().readByte();
						string name = msg.reader().readUTF();
						short idIcon = msg.reader().readShort();
						int num = msg.reader().readInt();
						sbyte color = msg.reader().readByte();
						array[i] = new Item_Drop((short)i, type, name, 0, 0, idIcon, color);
						array[i].num = num;
					}
					LuckyScreen.instance.dataDialog(array);
				}
				else
				{
					bool flag4 = b == 3;
					if (flag4)
					{
						LuckyScreen.mListItemLucky.removeAllElements();
						sbyte b3 = msg.reader().readByte();
						for (short num2 = 0; num2 < (short)b3; num2 += 1)
						{
							sbyte type2 = msg.reader().readByte();
							short idIcon2 = msg.reader().readShort();
							MainItem o = new MainItem(type2, idIcon2, num2);
							LuckyScreen.mListItemLucky.addElement(o);
						}
						LuckyScreen.instance.setPosPotion();
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D17 RID: 3351 RVA: 0x00100588 File Offset: 0x000FE788
	public void Quay_WC(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			mSystem.outz("vao nao>>>>>>>>>>> action=" + b.ToString());
			bool flag = b == 0;
			if (flag)
			{
				QuayWCScreen.instance = new QuayWCScreen();
				QuayWCScreen.instance.Show(GameCanvas.gameScr);
				QuayWCScreen.instance.mItemShow = null;
				GlobalService.gI().QuayWC(3);
				LuckyScreen.mListItemLucky = new mVector();
			}
			else
			{
				bool flag2 = b == 1 || b == 2;
				if (flag2)
				{
					sbyte b2 = msg.reader().readByte();
					QuayWCScreen.instance.typeQuay = 0;
					bool flag3 = b2 == 9;
					if (flag3)
					{
						QuayWCScreen.instance.typeQuay = 1;
						mSound.playSound(50, mSound.volumeSound);
					}
					else
					{
						mSound.playSound(48, mSound.volumeSound);
					}
					QuayWCScreen.instance.StepQuaySo = 1;
					QuayWCScreen.instance.tickAction = 0;
					Item_Drop[] array = new Item_Drop[(int)b2];
					for (int i = (int)(b2 - 1); i >= 0; i--)
					{
						sbyte type = msg.reader().readByte();
						string name = msg.reader().readUTF();
						short idIcon = msg.reader().readShort();
						int num = msg.reader().readInt();
						sbyte color = msg.reader().readByte();
						array[i] = new Item_Drop((short)i, type, name, 0, 0, idIcon, color);
						array[i].num = num;
					}
					QuayWCScreen.instance.dataDialog(array);
				}
				else
				{
					bool flag4 = b == 3;
					if (flag4)
					{
						LuckyScreen.mListItemLucky.removeAllElements();
						sbyte b3 = msg.reader().readByte();
						mSystem.outz("vao nao>>>>>>>>>>> size=" + b3.ToString());
						for (short num2 = 0; num2 < (short)b3; num2 += 1)
						{
							sbyte type2 = msg.reader().readByte();
							short idIcon2 = msg.reader().readShort();
							mSystem.outz("vao nao>>>>>>>>>>> cat=" + type2.ToString());
							mSystem.outz("vao nao>>>>>>>>>>> id=" + idIcon2.ToString());
							MainItem o = new MainItem(type2, idIcon2, num2);
							LuckyScreen.mListItemLucky.addElement(o);
						}
						QuayWCScreen.instance.setPosPotion();
					}
					else
					{
						bool flag5 = b == 4;
						if (flag5)
						{
							QuayWCScreen.instance.idIconVongQuay = msg.reader().readShort();
							QuayWCScreen.instance.numVe = msg.reader().readShort();
							QuayWCScreen.instance.numLanDaQuay = msg.reader().readShort();
							mSystem.outz(string.Concat(new string[]
							{
								"nhan ",
								QuayWCScreen.instance.idIconVongQuay.ToString(),
								" ",
								QuayWCScreen.instance.numVe.ToString(),
								" ",
								QuayWCScreen.instance.numLanDaQuay.ToString()
							}));
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D18 RID: 3352 RVA: 0x001008B4 File Offset: 0x000FEAB4
	public void Quay_oc_sen(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			bool flag = b == 0;
			if (flag)
			{
				QuayOcSenScreen.instance = new QuayOcSenScreen();
				QuayOcSenScreen.instance.title = msg.reader().readUTF();
				QuayOcSenScreen.instance.Show(GameCanvas.gameScr);
				QuayOcSenScreen.instance.mItemShow = null;
				GlobalService.gI().Quay_oc_sen(1);
				LuckyScreen.mListItemLucky = new mVector();
			}
			else
			{
				bool flag2 = b == 1;
				if (flag2)
				{
					LuckyScreen.mListItemLucky.removeAllElements();
					sbyte b2 = msg.reader().readByte();
					sbyte[] array = new sbyte[(int)b2];
					for (short num = 0; num < (short)b2; num += 1)
					{
						sbyte id = msg.reader().readByte();
						sbyte type = msg.reader().readByte();
						short idIcon = msg.reader().readShort();
						int num2 = msg.reader().readInt();
						MainItem o = new MainItem(type, idIcon, (short)id, num2);
						LuckyScreen.mListItemLucky.addElement(o);
						sbyte b3 = array[(int)num] = msg.reader().readByte();
					}
					QuayOcSenScreen.instance.SetmNhan(array);
					QuayOcSenScreen.instance.setPosPotion();
				}
				else
				{
					bool flag3 = b == 2;
					if (flag3)
					{
						sbyte indexQuaySo = msg.reader().readByte();
						QuayOcSenScreen.instance.SetIndexQuaySo(indexQuaySo);
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D19 RID: 3353 RVA: 0x00100A40 File Offset: 0x000FEC40
	public void Clan_Fight(Message msg)
	{
		try
		{
			mVector mVector = new mVector();
			sbyte b = msg.reader().readByte();
			bool flag = b == 0;
			if (flag)
			{
				sbyte b2 = msg.reader().readByte();
				for (int i = 0; i < (int)b2; i++)
				{
					short subType = msg.reader().readShort();
					string text = msg.reader().readUTF();
					bool flag2 = text.Length >= 15;
					if (flag2)
					{
						text = text.Substring(0, 12) + "...";
					}
					short idIconClan = msg.reader().readShort();
					short lvClan = msg.reader().readShort();
					iCommand iCommand = new iCommand(string.Concat(new string[]
					{
						text,
						" ",
						T.Lv,
						" ",
						lvClan.ToString()
					}), 11, (int)subType, this);
					iCommand.setIdIconClan(idIconClan);
					iCommand.lvClan = lvClan;
					mVector.addElement(iCommand);
				}
				GameCanvas.menu.startAt(mVector, 2, T.thachDauClan);
			}
			else
			{
				bool flag3 = b == 4;
				if (flag3)
				{
					string info = msg.reader().readUTF();
					GameCanvas.Start_Normal_Only_CmdClose_DiaLog(info);
				}
				else
				{
					bool flag4 = b == 5;
					if (flag4)
					{
						short id = msg.reader().readShort();
						string text2 = msg.reader().readUTF();
						bool flag5 = text2.Length >= 15;
						if (flag5)
						{
							text2 = text2.Substring(0, 12) + "...";
						}
						short num = msg.reader().readShort();
						sbyte typeFight = msg.reader().readByte();
						InfoMemList.setTypeEvent((int)id, 7, string.Concat(new string[]
						{
							text2,
							" ",
							T.Lv,
							" ",
							num.ToString()
						}), T.eventClanFight, 5, (int)typeFight);
					}
					else
					{
						bool flag6 = b == 6;
						if (flag6)
						{
							sbyte b3 = msg.reader().readByte();
							for (int j = 0; j < (int)b3; j++)
							{
								short id2 = msg.reader().readShort();
								string name = msg.reader().readUTF();
								short num2 = msg.reader().readShort();
								mVector.addElement(new InfoMemList((int)id2)
								{
									name = name,
									info = T.Lv + num2.ToString(),
									rank = j
								});
							}
							PlayerListServer.instance = new PlayerListServer(15, mVector, T.listMemClanFight, 0);
							PlayerListServer.instance.Show(GameCanvas.gameScr);
							PlayerListServer.instance.isLoad = false;
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D1A RID: 3354 RVA: 0x00100D30 File Offset: 0x000FEF30
	public void daily_Bonus(Message msg)
	{
		try
		{
			mSystem.outz("vao cmd 60");
			MsgGiftLogin msgGiftLogin = new MsgGiftLogin();
			string name = msg.reader().readUTF();
			string nameCmd = msg.reader().readUTF();
			string empty = string.Empty;
			int num = (int)msg.reader().readByte();
			Item_Drop[] array = new Item_Drop[num];
			for (int i = 0; i < num; i++)
			{
				sbyte type = msg.reader().readByte();
				string name2 = msg.reader().readUTF();
				short idIcon = msg.reader().readShort();
				sbyte color = msg.reader().readByte();
				array[i] = new Item_Drop((short)i, type, name2, 0, 0, idIcon, color);
				array[i].num = (int)msg.reader().readShort();
				array[i].typeGiftDaily = msg.reader().readByte();
			}
			msgGiftLogin.setinfoShow_GiftLogin(0, name, empty, array, 0, nameCmd, null);
			GameCanvas.Start_Current_Dialog(msgGiftLogin);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D1B RID: 3355 RVA: 0x00100E44 File Offset: 0x000FF044
	public void Potion_Choice(Message msg)
	{
		try
		{
			MsgGiftLogin msgGiftLogin = new MsgGiftLogin();
			string name = msg.reader().readUTF();
			string nameCmd = msg.reader().readUTF();
			string empty = string.Empty;
			int num = (int)msg.reader().readByte();
			Item_Drop[] array = new Item_Drop[num];
			for (int i = 0; i < num; i++)
			{
				sbyte type = msg.reader().readByte();
				string name2 = msg.reader().readUTF();
				short idIcon = msg.reader().readShort();
				sbyte color = msg.reader().readByte();
				array[i] = new Item_Drop((short)i, type, name2, 0, 0, idIcon, color);
				array[i].num = (int)msg.reader().readShort();
				array[i].typeGiftDaily = msg.reader().readByte();
			}
			short id = msg.reader().readShort();
			sbyte type2 = msg.reader().readByte();
			msgGiftLogin.setinfoShow_GiftLogin(1, name, empty, array, 0, nameCmd, new MainItem(type2, -1, id)
			{
				name = name
			});
			GameCanvas.Start_Sub_Dialog(msgGiftLogin);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D1C RID: 3356 RVA: 0x0000BC83 File Offset: 0x00009E83
	public void gps(Message msg)
	{
		GameMidlet.instance.CheckPerGPS();
	}

	// Token: 0x06000D1D RID: 3357 RVA: 0x00100F88 File Offset: 0x000FF188
	public void getDamList(Message msg)
	{
		try
		{
			mVector mVector = new mVector();
			sbyte b = msg.reader().readByte();
			for (int i = 0; i < (int)b; i++)
			{
				mVector.addElement(new MainClan
				{
					name = msg.reader().readUTF(),
					idIcon = msg.reader().readShort(),
					xp = msg.reader().readInt()
				});
			}
			Interface_Game.vecClanDam.removeAllElements();
			Interface_Game.vecClanDam = mVector;
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D1E RID: 3358 RVA: 0x00101028 File Offset: 0x000FF228
	public void getInfoClanDao(Message msg)
	{
		try
		{
			GameScreen.ClanDao = new MainClan();
			GameScreen.ClanDao.ID = msg.reader().readShort();
			GameScreen.ClanDao.idIcon = msg.reader().readShort();
			GameScreen.ClanDao.name = msg.reader().readUTF();
			GameScreen.ClanDao.nameCaption = msg.reader().readUTF();
			GameScreen.ClanDao.level = (int)msg.reader().readShort();
			GameScreen.ClanDao.numMem = (int)msg.reader().readByte();
			GameScreen.ClanDao.maxNumMem = (int)msg.reader().readByte();
			GameScreen.ClanDao.rank = msg.reader().readInt();
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D1F RID: 3359 RVA: 0x00101104 File Offset: 0x000FF304
	public void getThanhTich(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			sbyte tem = msg.reader().readByte();
			MainObject mainObject = MainObject.get_Object((int)id, tem);
			bool flag = mainObject != null && !mainObject.returnAction();
			if (flag)
			{
				mainObject.thanhtichPvP = msg.reader().readByte();
				mainObject.thanhtichLv = msg.reader().readByte();
				mainObject.indexFullSet = msg.reader().readByte();
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D20 RID: 3360 RVA: 0x00101194 File Offset: 0x000FF394
	public void check_AFK(Message msg)
	{
		try
		{
			bool flag = GameCanvas.tickAction <= 0;
			if (flag)
			{
				GlobalService.gI().Check_AFK();
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D21 RID: 3361 RVA: 0x001011D8 File Offset: 0x000FF3D8
	public void listGiftArea(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			for (int i = 0; i < (int)b; i++)
			{
				short id = msg.reader().readShort();
				MainObject mainObject = MainObject.get_Object((int)id, 0);
				short idIconChat = msg.reader().readShort();
				sbyte cat = msg.reader().readByte();
				short num = msg.reader().readShort();
				if (mainObject != null)
				{
					mainObject.addChatItem(idIconChat, cat, num);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D22 RID: 3362 RVA: 0x0010126C File Offset: 0x000FF46C
	public void Nap_The(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			bool flag = b == 0;
			if (flag)
			{
				GameCanvas.gameScr.Open_Dialog_Nap();
			}
			else
			{
				bool flag2 = b == 1;
				if (flag2)
				{
					GameCanvas.gameScr.Open_Nap_Store();
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D23 RID: 3363 RVA: 0x001012CC File Offset: 0x000FF4CC
	public void Thanh_Toan(Message msg)
	{
		try
		{
			string str = msg.reader().readUTF();
			GameMidlet.CheckThanhToan(str);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D24 RID: 3364 RVA: 0x00101308 File Offset: 0x000FF508
	public void title_Map_Fight(Message msg)
	{
		try
		{
			Interface_Game.typeTitleRoomFight = msg.reader().readByte();
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D25 RID: 3365 RVA: 0x00101340 File Offset: 0x000FF540
	public void ListDauGia(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			bool flag = b == 0;
			if (flag)
			{
				sbyte b2 = msg.reader().readByte();
				mVector mVector = new mVector();
				for (int i = 0; i < (int)b2; i++)
				{
					sbyte id = msg.reader().readByte();
					InfoMemList infoMemList = new InfoMemList((int)id);
					int money = msg.reader().readInt();
					int time = msg.reader().readInt();
					int giaChot = msg.reader().readInt();
					sbyte cat = msg.reader().readByte();
					string name = msg.reader().readUTF();
					short id2 = msg.reader().readShort();
					short num = msg.reader().readShort();
					sbyte color = msg.reader().readByte();
					sbyte isOwn = msg.reader().readByte();
					infoMemList.item = new ItemQuaNT(name, cat, id2, num, color);
					infoMemList.item.setDauGia(money, time, giaChot);
					infoMemList.isOwn = isOwn;
					bool flag2 = infoMemList != null;
					if (flag2)
					{
						mVector.addElement(infoMemList);
					}
				}
				AuctionScreen.instance = new AuctionScreen(mVector);
				AuctionScreen.instance.Show(GameCanvas.gameScr);
			}
			else
			{
				bool flag3 = b == 1;
				if (flag3)
				{
					AuctionScreen.instance.SetNewValueDauGia(msg.reader().readByte(), msg.reader().readShort(), msg.reader().readInt(), msg.reader().readInt());
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D26 RID: 3366 RVA: 0x001014F4 File Offset: 0x000FF6F4
	public void ListTichNapThe(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			bool flag = b == 0;
			if (flag)
			{
				int ruby = msg.reader().readInt();
				sbyte b2 = msg.reader().readByte();
				mVector mVector = new mVector();
				for (int i = 0; i < (int)b2; i++)
				{
					sbyte id = msg.reader().readByte();
					InfoMemList infoMemList = new InfoMemList((int)id);
					int cost = msg.reader().readInt();
					sbyte status = msg.reader().readByte();
					short num = msg.reader().readShort();
					infoMemList.quaNapThe = new QuaNapThe(cost, status, num);
					mVector mVector2 = new mVector();
					for (int j = 0; j < (int)num; j++)
					{
						ItemQuaNT itemQuaNT = new ItemQuaNT(msg.reader().readUTF(), msg.reader().readByte(), msg.reader().readShort(), msg.reader().readShort(), msg.reader().readByte());
						bool flag2 = itemQuaNT != null;
						if (flag2)
						{
							mVector2.addElement(itemQuaNT);
						}
					}
					infoMemList.quaNapThe.vecQua = mVector2;
					bool flag3 = infoMemList != null;
					if (flag3)
					{
						mVector.addElement(infoMemList);
					}
				}
				NapTheScreen.instance = new NapTheScreen(mVector, ruby);
				NapTheScreen.instance.Show(GameCanvas.gameScr);
			}
			else
			{
				bool flag4 = b == 2;
				if (flag4)
				{
					sbyte cmdDaNhanIndex = msg.reader().readByte();
					NapTheScreen.instance.setCmdDaNhanIndex(cmdDaNhanIndex);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D27 RID: 3367 RVA: 0x001016B0 File Offset: 0x000FF8B0
	public void Read_Sudo(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			mSystem.outz("Read SUDO type = " + b.ToString());
			bool flag = b == 3;
			if (flag)
			{
				mVector mVector = new mVector();
				sbyte b2 = msg.reader().readByte();
				mSystem.outz("Read SUDO chucDanh = " + b2.ToString());
				Player.ChucInSudo = b2;
				bool flag2 = Player.ChucInSudo != 0;
				if (flag2)
				{
					string name = string.Empty;
					name = ((b2 == 2) ? (T.chucDanh + T.deTu) : ((b2 != 1) ? string.Empty : (T.chucDanh + T.suPhu)));
					mVector.addElement(new MainInfoItem(name, 0));
					sbyte value = msg.reader().readByte();
					mSystem.outz("Read SUDO level = " + value.ToString());
					mVector.addElement(new MainInfoItem(T.capDoSudo, (int)value));
					short num = msg.reader().readShort();
					short exp = msg.reader().readShort();
					mSystem.outz("Read SUDO lvExp = " + num.ToString() + " exp = " + exp.ToString());
					mVector.addElement(new MainInfoItem(T.diemSudoCanhan, 0));
					mVector.addElement(new MainInfoItem(T.Lv + ": " + num.ToString(), 0));
					Sudo_Info.instance.exp = exp;
					sbyte b3 = msg.reader().readByte();
					mSystem.outz("Read SUDO sizeAtt = " + b3.ToString());
					for (int i = 0; i < (int)b3; i++)
					{
						string text = msg.reader().readUTF();
						mSystem.outz("Read SUDO nameAtt = " + text);
						mVector.addElement(new MainInfoItem(text, 0));
					}
					Sudo_Info.vecInfoCanhan = mVector;
					Sudo_Info.instance.setHplus();
					GameCanvas.SudoScr.Show(GameCanvas.gameScr);
				}
			}
			else
			{
				bool flag3 = b == 2;
				if (flag3)
				{
					mVector mVector2 = new mVector();
					sbyte b4 = msg.reader().readByte();
					mSystem.outz("Read SUDO sizeList = " + b4.ToString());
					for (int j = 0; j < (int)b4; j++)
					{
						InfoMemList infoMemList = new InfoMemList(-1);
						string text2 = msg.reader().readUTF();
						string text3 = msg.reader().readUTF();
						short head = msg.reader().readShort();
						short hair = msg.reader().readShort();
						short hat = msg.reader().readShort();
						infoMemList.title = text2;
						infoMemList.name = text3;
						infoMemList.updateFace(head, hair, hat);
						mSystem.outz(string.Concat(new string[]
						{
							"Read SUDO ",
							text2,
							" ",
							text3,
							" ",
							head.ToString(),
							" ",
							hair.ToString(),
							" ",
							hat.ToString()
						}));
						infoMemList.chucInSudo = msg.reader().readByte();
						infoMemList.Lv = (int)msg.reader().readShort();
						infoMemList.expSudo = msg.reader().readUTF();
						infoMemList.typeOnline = msg.reader().readByte();
						mVector2.addElement(infoMemList);
						bool flag4 = text3.CompareTo(GameScreen.player.name) == 0;
						if (flag4)
						{
							Player.ChucInSudo = infoMemList.chucInSudo;
						}
					}
					Sudo_Mem.vecSudo = mVector2;
				}
				else
				{
					bool flag5 = b == 0;
					if (flag5)
					{
						bool flag6 = GameScreen.player.clan == null;
						if (flag6)
						{
							GameScreen.player.clan = new MainClan(msg.reader().readShort(), msg.reader().readUTF());
						}
						else
						{
							GameScreen.player.clan.ID = msg.reader().readShort();
							GameScreen.player.clan.name = msg.reader().readUTF();
						}
					}
					else
					{
						bool flag7 = b == 1;
						if (flag7)
						{
							bool flag8 = GameScreen.player.clan == null;
							if (flag8)
							{
								GlobalService.gI().Clan_CMD(9, string.Empty, 0, 0);
							}
							else
							{
								string name2 = msg.reader().readUTF();
								sbyte b5 = msg.reader().readByte();
								InfoMemList memInCLan = Clan_Screen.getMemInCLan(name2);
								bool flag9 = memInCLan != null;
								if (flag9)
								{
									memInCLan.chucInClan = b5;
									bool flag10 = memInCLan.name.CompareTo(GameScreen.player.name) == 0;
									if (flag10)
									{
										MainClan.UpdateRankMe(b5);
									}
								}
							}
						}
						else
						{
							bool flag11 = b == 4;
							if (flag11)
							{
								bool flag12 = GameScreen.player.clan == null;
								if (flag12)
								{
									GlobalService.gI().Clan_CMD(9, string.Empty, 0, 0);
								}
								else
								{
									short maxAttri = msg.reader().readShort();
									short pointAttri = msg.reader().readShort();
									short[] array = new short[5];
									for (int k = 0; k < array.Length; k++)
									{
										array[k] = msg.reader().readShort();
									}
									GameScreen.player.clan.pointAttri = (int)pointAttri;
									GameScreen.player.clan.maxAttri = (int)maxAttri;
									GameScreen.player.clan.setAttri(array);
								}
							}
							else
							{
								bool flag13 = b == 13;
								if (flag13)
								{
									short id = msg.reader().readShort();
									MainObject mainObject = MainObject.get_Object((int)id, 0);
									bool flag14 = mainObject != null;
									if (flag14)
									{
										short id2 = msg.reader().readShort();
										sbyte b6 = msg.reader().readByte();
										bool flag15 = mainObject.sudo == null;
										if (flag15)
										{
											mainObject.sudo = new MainSudo(id2, b6);
										}
										else
										{
											mainObject.sudo.ID = id2;
											mainObject.sudo.chucvu = (int)b6;
										}
										bool flag16 = mainObject == GameScreen.player;
										if (flag16)
										{
											MainSudo.UpdateRankMe(b6);
										}
										short level = msg.reader().readShort();
										string diemSudo = msg.reader().readUTF();
										mainObject.sudo.level = (int)level;
										mainObject.sudo.diemSudo = diemSudo;
									}
								}
								else
								{
									bool flag17 = b == 8;
									if (flag17)
									{
										bool flag18 = GameScreen.player.clan != null && GameCanvas.ClanScr != null;
										if (flag18)
										{
											this.read_Data_Chat(msg, 0);
											GameCanvas.ClanScr.setIsNewTab(GameCanvas.ClanScr.clanchat);
										}
									}
									else
									{
										bool flag19 = b == 7;
										if (flag19)
										{
											int id3 = msg.reader().readInt();
											string name3 = msg.reader().readUTF();
											InfoMemList.setTypeEvent(id3, 8, name3, T.baisu, 0, 0);
										}
										else
										{
											bool flag20 = b == 9;
											if (flag20)
											{
												bool flag21 = GameScreen.player.clan != null && GameCanvas.ClanScr != null;
												if (flag21)
												{
													GameScreen.player.clan.vecChatCLan.removeAllElements();
													short num2 = msg.reader().readShort();
													for (int l = 0; l < (int)num2; l++)
													{
														this.read_Data_Chat(msg, 0);
													}
												}
											}
											else
											{
												bool flag22 = b == 11;
												if (flag22)
												{
													bool flag23 = GameScreen.player.clan != null && GameCanvas.ClanScr != null;
													if (flag23)
													{
														short id4 = msg.reader().readShort();
														GameCanvas.ClanScr.clanchat.RemoveChat(id4);
													}
												}
												else
												{
													bool flag24 = b == 10;
													if (flag24)
													{
														short id5 = msg.reader().readShort();
														MainObject mainObject2 = MainObject.get_Object((int)id5, 0);
														bool flag25 = mainObject2 != null && mainObject2.sudo != null;
														if (flag25)
														{
															mainObject2.sudo = null;
														}
														bool flag26 = mainObject2 == GameScreen.player && GameCanvas.currentScreen == GameCanvas.SudoScr;
														if (flag26)
														{
															GameCanvas.gameScr.Show();
															GameCanvas.SudoScr = null;
															Player.isGetDataClan = -1;
														}
													}
													else
													{
														bool flag27 = b == 12;
														if (flag27)
														{
															bool flag28 = GameScreen.player.clan != null && GameCanvas.ClanScr != null;
															if (flag28)
															{
																sbyte b7 = msg.reader().readByte();
																bool flag29 = b7 == 0;
																if (flag29)
																{
																	this.readMemInCLan(msg);
																}
																else
																{
																	bool flag30 = b7 == 1;
																	if (flag30)
																	{
																		string name4 = msg.reader().readUTF();
																		Clan_Screen.getRemoveMemInCLan(name4);
																	}
																}
																GameCanvas.ClanScr.setIsNewTab(GameCanvas.ClanScr.member);
															}
														}
														else
														{
															bool flag31 = b == 13;
															if (flag31)
															{
																int countDown = msg.reader().readInt();
																MainTab.CDDonateClan.setCountDown(countDown);
																int numTangqua = msg.reader().readInt();
																InfoMemList memInCLan2 = Clan_Screen.getMemInCLan(GameScreen.player.ID);
																bool flag32 = memInCLan2 != null;
																if (flag32)
																{
																	memInCLan2.numTangqua = numTangqua;
																}
															}
															else
															{
																bool flag33 = b == 14;
																if (flag33)
																{
																	bool flag34 = GameScreen.player.clan != null && GameCanvas.ClanScr != null;
																	if (flag34)
																	{
																		string text4 = msg.reader().readUTF();
																		GameScreen.player.clan.strVoice = text4;
																		GameCanvas.ClanScr.info.getmStrInfo(text4, GameCanvas.ClanScr.info.wCon - 6);
																		GameCanvas.ClanScr.setIsNewTab(GameCanvas.ClanScr.info);
																	}
																}
																else
																{
																	bool flag35 = b == 15;
																	if (flag35)
																	{
																		short[] array2 = new short[5];
																		for (int m = 0; m < 5; m++)
																		{
																			array2[m] = msg.reader().readShort();
																		}
																		for (int n = 0; n < Player.mAttribute.Length; n++)
																		{
																			Main_Attribute main_Attribute = Player.mAttribute[n];
																			bool flag36 = n < array2.Length;
																			if (flag36)
																			{
																				main_Attribute.valuePlus = array2[n];
																			}
																		}
																	}
																	else
																	{
																		bool flag37 = b == 16;
																		if (flag37)
																		{
																			bool flag38 = GameScreen.player.clan != null;
																			if (flag38)
																			{
																				GameScreen.player.clan.isLevelUp = msg.reader().readByte();
																				GameScreen.player.clan.xp = msg.reader().readInt();
																			}
																		}
																		else
																		{
																			bool flag39 = b == 17;
																			if (flag39)
																			{
																				bool flag40 = GameScreen.player.clan != null;
																				if (flag40)
																				{
																					GameScreen.player.clan.rubiClan = msg.reader().readInt();
																					GameScreen.player.clan.beryClan = msg.reader().readInt();
																				}
																			}
																			else
																			{
																				bool flag41 = b == 19;
																				if (flag41)
																				{
																					this.update_Inven_Clan(msg);
																				}
																				else
																				{
																					bool flag42 = b == 20;
																					if (flag42)
																					{
																						bool flag43 = GameScreen.player.clan != null && GameCanvas.ClanScr != null;
																						if (flag43)
																						{
																							GameCanvas.ClanScr.achi.vecDetail.removeAllElements();
																							while (msg.reader().available() > 0)
																							{
																								this.read_Data_Chat(msg, 1);
																							}
																							GameCanvas.ClanScr.setIsNewTab(GameCanvas.ClanScr.achi);
																						}
																					}
																					else
																					{
																						bool flag44 = b == 21;
																						if (flag44)
																						{
																							string info = msg.reader().readUTF();
																							bool flag45 = GameCanvas.currentScreen == GameCanvas.tabShopScr;
																							if (flag45)
																							{
																								GameCanvas.gameScr.Show();
																							}
																							GameCanvas.Start_Normal_Only_CmdClose_DiaLog(info);
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D28 RID: 3368 RVA: 0x001022B4 File Offset: 0x001004B4
	public void ListTichCongDon(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			mSystem.outz("type = " + b.ToString());
			bool flag = b == 0;
			if (flag)
			{
				sbyte b2 = msg.reader().readByte();
				mSystem.outz("size = " + b2.ToString());
				mVector mVector = new mVector();
				for (int i = 0; i < (int)b2; i++)
				{
					short cost = msg.reader().readShort();
					int rubyDaNap = msg.reader().readInt();
					mSystem.outz("ruby = " + rubyDaNap.ToString());
					InfoMemList infoMemList = new InfoMemList(i);
					sbyte status = 1;
					sbyte b3 = msg.reader().readByte();
					infoMemList.quaNapThe = new QuaNapThe((int)cost, status, (short)b3);
					infoMemList.quaNapThe.rubyDaNap = rubyDaNap;
					mVector mVector2 = new mVector();
					for (int j = 0; j < (int)b3; j++)
					{
						ItemQuaNT itemQuaNT = new ItemQuaNT(msg.reader().readUTF(), msg.reader().readByte(), msg.reader().readShort(), msg.reader().readShort(), msg.reader().readByte());
						bool flag2 = itemQuaNT != null;
						if (flag2)
						{
							mVector2.addElement(itemQuaNT);
						}
					}
					infoMemList.quaNapThe.vecQua = mVector2;
					bool flag3 = infoMemList != null;
					if (flag3)
					{
						mVector.addElement(infoMemList);
					}
				}
				TichLuyCongDonScr.instance = new TichLuyCongDonScr(mVector);
				TichLuyCongDonScr.instance.Show(GameCanvas.gameScr);
			}
			else
			{
				bool flag4 = b == 2;
				if (flag4)
				{
					short cost2 = msg.reader().readShort();
					int ruby = msg.reader().readInt();
					TichLuyCongDonScr.instance.setUpdateCostRuby(cost2, ruby);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D29 RID: 3369 RVA: 0x001024B8 File Offset: 0x001006B8
	public void ListTichTieu(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			bool flag = b == 0;
			if (flag)
			{
				int ruby = msg.reader().readInt();
				sbyte b2 = msg.reader().readByte();
				mVector mVector = new mVector();
				for (int i = 0; i < (int)b2; i++)
				{
					sbyte id = msg.reader().readByte();
					InfoMemList infoMemList = new InfoMemList((int)id);
					int cost = msg.reader().readInt();
					sbyte status = msg.reader().readByte();
					short num = msg.reader().readShort();
					infoMemList.quaNapThe = new QuaNapThe(cost, status, num);
					mVector mVector2 = new mVector();
					for (int j = 0; j < (int)num; j++)
					{
						ItemQuaNT itemQuaNT = new ItemQuaNT(msg.reader().readUTF(), msg.reader().readByte(), msg.reader().readShort(), msg.reader().readShort(), msg.reader().readByte());
						bool flag2 = itemQuaNT != null;
						if (flag2)
						{
							mVector2.addElement(itemQuaNT);
						}
					}
					infoMemList.quaNapThe.vecQua = mVector2;
					bool flag3 = infoMemList != null;
					if (flag3)
					{
						mVector.addElement(infoMemList);
					}
				}
				TichTieuScreen.instance = new TichTieuScreen(mVector, ruby);
				TichTieuScreen.instance.Show(GameCanvas.gameScr);
			}
			else
			{
				bool flag4 = b == 2;
				if (flag4)
				{
					sbyte cmdDaNhanIndex = msg.reader().readByte();
					TichTieuScreen.instance.setCmdDaNhanIndex(cmdDaNhanIndex);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D2A RID: 3370 RVA: 0x00102674 File Offset: 0x00100874
	public void ListWantedServer(Message msg)
	{
		try
		{
			sbyte type = msg.reader().readByte();
			mVector mVector = new mVector();
			switch (type)
			{
			case 0:
			{
				short num = msg.reader().readShort();
				for (int i = 0; i < (int)num; i++)
				{
					InfoMemList infoMemList = this.ReadInfoMemWantedWarrant(msg);
					infoMemList.typeOnline = msg.reader().readByte();
					bool flag = infoMemList != null;
					if (flag)
					{
						mVector.addElement(infoMemList);
					}
				}
				WantedList.instance = new WantedList(type, mVector);
				WantedList.instance.Show(GameCanvas.gameScr);
				WantedList.instance.isLoad = false;
				break;
			}
			case 1:
			case 4:
			case 5:
				this.ListWantedServerTypeViewInfo(msg, type);
				break;
			case 3:
			{
				short num2 = msg.reader().readShort();
				for (int j = 0; j < (int)num2; j++)
				{
					InfoMemList infoMemList2 = this.ReadInfoMemWantedWarrant(msg);
					infoMemList2.namePlayerNhan = msg.reader().readUTF();
					infoMemList2.isWantedSuccess = msg.reader().readByte();
					infoMemList2.isReceiveGift = msg.reader().readByte();
					bool flag2 = infoMemList2 != null;
					if (flag2)
					{
						mVector.addElement(infoMemList2);
					}
				}
				WantedList.instance = new WantedList(type, mVector);
				WantedList.instance.Show(GameCanvas.gameScr);
				WantedList.instance.isLoad = false;
				break;
			}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D2B RID: 3371 RVA: 0x0010281C File Offset: 0x00100A1C
	public void ListWantedServerTypeViewInfo(Message msg, sbyte type)
	{
		try
		{
			int id = (int)msg.reader().readShort();
			InfoMemList infoMemList = new InfoMemList(id);
			infoMemList.charShow = new MainObject();
			infoMemList.charShow.name = msg.reader().readUTF();
			infoMemList.charShow.wanted = msg.reader().readInt();
			infoMemList.charShow.Lv = (int)msg.reader().readShort();
			short head = msg.reader().readShort();
			short hair = msg.reader().readShort();
			sbyte b = msg.reader().readByte();
			short[] array = new short[(int)b];
			for (sbyte b2 = 0; b2 < b; b2 += 1)
			{
				array[(int)b2] = msg.reader().readShort();
			}
			infoMemList.updateCharFullPart(head, hair, array[1], array[3], array[5], array[0]);
			bool flag = type == 4 || type == 5;
			if (flag)
			{
				infoMemList.isWantedSuccess = msg.reader().readByte();
			}
			bool flag2 = type == 5;
			if (flag2)
			{
				infoMemList.isReceiveGift = msg.reader().readByte();
			}
			WantedPoster.instance = new WantedPoster(type, infoMemList);
			WantedPoster.instance.Show(GameCanvas.gameScr);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D2C RID: 3372 RVA: 0x00102980 File Offset: 0x00100B80
	public InfoMemList ReadInfoMemWantedWarrant(Message msg)
	{
		InfoMemList infoMemList = null;
		InfoMemList result;
		try
		{
			int id = (int)msg.reader().readShort();
			infoMemList = new InfoMemList(id);
			infoMemList.name = msg.reader().readUTF();
			bool flag = infoMemList.name.CompareTo(GameScreen.player.name) == 0;
			if (flag)
			{
				infoMemList.isMe = true;
			}
			bool flag2 = infoMemList.charShow == null;
			if (flag2)
			{
				infoMemList.charShow = new MainObject();
			}
			infoMemList.charShow.wanted = msg.reader().readInt();
			infoMemList.charShow.name = msg.reader().readUTF();
			infoMemList.charShow.Lv = (int)msg.reader().readShort();
			infoMemList.updateCharFace(msg.reader().readShort(), msg.reader().readShort(), msg.reader().readShort());
			result = infoMemList;
		}
		catch (Exception)
		{
			result = infoMemList;
		}
		return result;
	}

	// Token: 0x06000D2D RID: 3373 RVA: 0x00102A7C File Offset: 0x00100C7C
	public void infoFashion(Message msg)
	{
		try
		{
			switch (msg.reader().readByte())
			{
			case 0:
			{
				short num = msg.reader().readShort();
				bool flag = num > 0;
				if (flag)
				{
					MainObject.ListLechHEAD = new short[(int)num];
					for (int i = 0; i < (int)num; i++)
					{
						MainObject.ListLechHEAD[i] = msg.reader().readShort();
					}
				}
				break;
			}
			case 1:
			{
				short num2 = msg.reader().readShort();
				MainItem.ID_POTION_CAN_SELL = new short[(int)num2];
				for (int j = 0; j < (int)num2; j++)
				{
					MainItem.ID_POTION_CAN_SELL[j] = msg.reader().readShort();
				}
				short num3 = msg.reader().readShort();
				MainItem.ID_MATERIAL_CAN_SELL = new short[(int)num3];
				for (int k = 0; k < (int)num3; k++)
				{
					MainItem.ID_MATERIAL_CAN_SELL[k] = msg.reader().readShort();
				}
				break;
			}
			case 2:
			{
				short num4 = msg.reader().readShort();
				MainObject.idEffBody = new short[(int)num4];
				for (int l = 0; l < (int)num4; l++)
				{
					MainObject.idEffBody[l] = msg.reader().readShort();
				}
				short num5 = msg.reader().readShort();
				MainObject.idPlayFrameHead = new short[(int)num5];
				for (int m = 0; m < (int)num5; m++)
				{
					MainObject.idPlayFrameHead[m] = msg.reader().readShort();
				}
				short num6 = msg.reader().readShort();
				MainObject.idWeaponF = new short[(int)num6];
				for (int n = 0; n < (int)num6; n++)
				{
					MainObject.idWeaponF[n] = msg.reader().readShort();
				}
				break;
			}
			case 3:
			{
				short num7 = msg.reader().readShort();
				bool flag2 = num7 > 0;
				if (flag2)
				{
					MainObject.ListKoLechHEAD = new short[(int)num7];
					for (int num8 = 0; num8 < (int)num7; num8++)
					{
						MainObject.ListKoLechHEAD[num8] = msg.reader().readShort();
					}
				}
				break;
			}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D2E RID: 3374 RVA: 0x00102CE4 File Offset: 0x00100EE4
	public void vongsinhtu(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			sbyte b2 = b;
			if (b2 == 0)
			{
				GameCanvas.gameScr.isFullScreen = false;
				GameCanvas.gameScr.xRec = (int)msg.reader().readShort();
				GameCanvas.gameScr.yRec = (int)msg.reader().readShort();
				GameCanvas.gameScr.wRec = (int)msg.reader().readShort();
				GameCanvas.gameScr.hRec = (int)msg.reader().readShort();
				GameCanvas.gameScr.colorRec = msg.reader().readInt();
				bool flag = GameCanvas.gameScr.wRec == 0 && GameCanvas.gameScr.hRec == 0;
				if (flag)
				{
					GameCanvas.gameScr.isFullScreen = true;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D2F RID: 3375 RVA: 0x00102DC8 File Offset: 0x00100FC8
	public void getDataEff(Message msg)
	{
		try
		{
			switch (msg.reader().readByte())
			{
			case 0:
			{
				sbyte[] dataeff = new sbyte[msg.reader().available()];
				msg.reader().read(ref dataeff);
				DataSkillEff.readData(dataeff, true);
				break;
			}
			case 1:
			{
				short id = msg.reader().readShort();
				short id2 = msg.reader().readShort();
				int time = msg.reader().readInt();
				sbyte typemove = msg.reader().readByte();
				sbyte loop = msg.reader().readByte();
				MainObject mainObject = GameScreen.findObjByID(id);
				if (mainObject != null)
				{
					mainObject.addDataEff(id2, time, typemove, loop);
				}
				break;
			}
			case 2:
			{
				short id3 = msg.reader().readShort();
				short id4 = msg.reader().readShort();
				MainObject mainObject2 = GameScreen.findObjByID(id3);
				if (mainObject2 != null)
				{
					mainObject2.removeDataEff(id4);
				}
				break;
			}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D30 RID: 3376 RVA: 0x00102ED0 File Offset: 0x001010D0
	public void openGhepnhieu(Message msg)
	{
		try
		{
			string nameScreen = msg.reader().readUTF();
			sbyte b = msg.reader().readByte();
			MainItem[] array = new MainItem[(int)(b + 1)];
			for (int i = 0; i < (int)b; i++)
			{
				short id = msg.reader().readShort();
				short numPotionNeed = msg.reader().readShort();
				sbyte type = msg.reader().readByte();
				short idIcon = msg.reader().readShort();
				MainItem mainItem = new MainItem(type, idIcon, id);
				mainItem.numPotionNeed = numPotionNeed;
				array[i] = mainItem;
				MainItem itemVec = MainItem.getItemVec(type, id, Player.vecInventory);
				bool flag = itemVec != null;
				if (flag)
				{
					mainItem.numPotion = itemVec.numPotion;
				}
			}
			int valueMonney_ = msg.reader().readInt();
			short valueMonney_2 = msg.reader().readShort();
			int valueMonney_3 = msg.reader().readInt();
			short id2 = msg.reader().readShort();
			short numPotion = msg.reader().readShort();
			sbyte type2 = msg.reader().readByte();
			short idIcon2 = msg.reader().readShort();
			sbyte valueTile = msg.reader().readByte();
			MainItem mainItem2 = new MainItem(type2, idIcon2, id2);
			mainItem2.numPotion = numPotion;
			array[array.Length - 1] = mainItem2;
			ScreenUpgrade.instance = new ScreenUpgrade(20, (int)b);
			ScreenUpgrade.instance.setInfo_money((int)valueTile, valueMonney_, (int)valueMonney_2, valueMonney_3);
			ScreenUpgrade.instance.setInfo(array);
			ScreenUpgrade.instance.nameScreen = nameScreen;
			ScreenUpgrade.instance.Show(GameCanvas.gameScr);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x0400136A RID: 4970
	public const sbyte REMOVE_TELEPORT = 1;

	// Token: 0x0400136B RID: 4971
	public const sbyte REMOVE_LINK_MAP = 2;

	// Token: 0x0400136C RID: 4972
	public const sbyte REMOVE_MAP_SEA = 3;

	// Token: 0x0400136D RID: 4973
	public const sbyte DIALOG_CLOSE = 0;

	// Token: 0x0400136E RID: 4974
	public const sbyte DIALOG_DOWNLOAD = 1;

	// Token: 0x0400136F RID: 4975
	public const sbyte DIALOG_NORMAL = 2;

	// Token: 0x04001370 RID: 4976
	public const sbyte DIALOG_TIME = 3;

	// Token: 0x04001371 RID: 4977
	public const sbyte DIALOG_RUBY = 4;

	// Token: 0x04001372 RID: 4978
	public const sbyte UPDATE_ALL = 0;

	// Token: 0x04001373 RID: 4979
	public const sbyte ADD_REPLACE = 1;

	// Token: 0x04001374 RID: 4980
	public const sbyte DELETE = 2;

	// Token: 0x04001375 RID: 4981
	public const sbyte UPDATE_MONEY = 3;

	// Token: 0x04001376 RID: 4982
	public const sbyte SIZE_CHEST = 6;

	// Token: 0x04001377 RID: 4983
	public const sbyte SHOP_MATERIAL = 6;

	// Token: 0x04001378 RID: 4984
	public const sbyte INVEN = 100;

	// Token: 0x04001379 RID: 4985
	public const sbyte CHEST = 99;

	// Token: 0x0400137A RID: 4986
	public const sbyte SHIP = 101;

	// Token: 0x0400137B RID: 4987
	public const sbyte BOAT = 102;

	// Token: 0x0400137C RID: 4988
	public const sbyte HAIR = 103;

	// Token: 0x0400137D RID: 4989
	public const sbyte FASHION = 105;

	// Token: 0x0400137E RID: 4990
	public const sbyte INVEN_CLAN = 110;

	// Token: 0x0400137F RID: 4991
	public const sbyte SHOP_DA_KHAM = 111;

	// Token: 0x04001380 RID: 4992
	public const sbyte HEAD = 112;

	// Token: 0x04001381 RID: 4993
	public const sbyte FASHION_EVENT = 113;

	// Token: 0x04001382 RID: 4994
	public const sbyte FASHION_GIFT_EVENT = 114;

	// Token: 0x04001383 RID: 4995
	public const sbyte SHOP_EVENT = 116;

	// Token: 0x04001384 RID: 4996
	public const sbyte DIEM_TICH_LUY = 118;

	// Token: 0x04001385 RID: 4997
	public const sbyte EFF_LV_UP = 0;

	// Token: 0x04001386 RID: 4998
	public const sbyte EFF_HOA_THU = 1;

	// Token: 0x04001387 RID: 4999
	public const sbyte EFF_GET_MONEY_VUON_CAM = 2;

	// Token: 0x04001388 RID: 5000
	public const sbyte EFF_SET_NAMI = 3;

	// Token: 0x04001389 RID: 5001
	public const sbyte EFF_BOOM_USSOP = 4;

	// Token: 0x0400138A RID: 5002
	public const sbyte EFF_PHAN_DAM_ZORO = 5;

	// Token: 0x0400138B RID: 5003
	public const sbyte EFF_CHOPPER_BUFF = 6;

	// Token: 0x0400138C RID: 5004
	public const sbyte EFF_LITTLE_BUFF_HP = 7;

	// Token: 0x0400138D RID: 5005
	public const sbyte EFF_LITTLE_BUFF_HP_BOSS = 8;

	// Token: 0x0400138E RID: 5006
	public const sbyte EFF_LITTLE_DAM_BOSS = 9;

	// Token: 0x0400138F RID: 5007
	public const sbyte EFF_WAPOL = 10;

	// Token: 0x04001390 RID: 5008
	public const sbyte EFF_BI_BE = 11;

	// Token: 0x04001391 RID: 5009
	public const sbyte EFF_NEM_POKE_OK = 12;

	// Token: 0x04001392 RID: 5010
	public const sbyte EFF_NEM_POKE_FAIL = 13;

	// Token: 0x04001393 RID: 5011
	public const sbyte EFF_LOL_TRU_TREN = 14;

	// Token: 0x04001394 RID: 5012
	public const sbyte EFF_LOL_TRU_DUOI = 15;

	// Token: 0x04001395 RID: 5013
	public const sbyte EFF_CHOANG = 16;

	// Token: 0x04001396 RID: 5014
	public const sbyte EFF_KIET_SUC = 17;

	// Token: 0x04001397 RID: 5015
	public const sbyte EFF_BAT_TU = 18;

	// Token: 0x04001398 RID: 5016
	public const sbyte EFF_KHANG_TAT_CA = 19;

	// Token: 0x04001399 RID: 5017
	public const sbyte EFF_THA_DEN = 20;

	// Token: 0x0400139A RID: 5018
	public const sbyte EFF_TU_CHOI_TU_THAN = 21;

	// Token: 0x0400139B RID: 5019
	public const sbyte EFF_LIGHTING_RED = 22;

	// Token: 0x0400139C RID: 5020
	public const sbyte EFF_THA_PHAO_HOA = 23;

	// Token: 0x0400139D RID: 5021
	public const sbyte EFF_LAW_HEART = 24;

	// Token: 0x0400139E RID: 5022
	public const sbyte EFF_GOAL = 25;

	// Token: 0x0400139F RID: 5023
	public const sbyte ACTION_LIST = 0;

	// Token: 0x040013A0 RID: 5024
	private const sbyte ACTION_INVEN = 1;

	// Token: 0x040013A1 RID: 5025
	private const sbyte ACTION_USE = 2;

	// Token: 0x040013A2 RID: 5026
	private const sbyte ACTION_MO_HH = 3;

	// Token: 0x040013A3 RID: 5027
	public const sbyte TYPE_MO_HH_MENU = 0;

	// Token: 0x040013A4 RID: 5028
	private const sbyte TYPE_MO_HH_OPEN = 1;

	// Token: 0x040013A5 RID: 5029
	public const sbyte MENU_NORMAL = 0;

	// Token: 0x040013A6 RID: 5030
	public const sbyte MENU_IMAGE = 1;

	// Token: 0x040013A7 RID: 5031
	public const sbyte MENU_NPC = 2;

	// Token: 0x040013A8 RID: 5032
	public const sbyte MENU_ITEM = 3;

	// Token: 0x040013A9 RID: 5033
	public const sbyte MENU_SKILL = 4;

	// Token: 0x040013AA RID: 5034
	public const sbyte MENU_IMAGE_NEW = 5;

	// Token: 0x040013AB RID: 5035
	public const sbyte MENU_IMAGE_COLOR = 6;

	// Token: 0x040013AC RID: 5036
	public const sbyte STATUS_QUEST_MAP = 1;

	// Token: 0x040013AD RID: 5037
	public const sbyte QUEST_ALL = 0;

	// Token: 0x040013AE RID: 5038
	public const sbyte QUEST_ADD = 1;

	// Token: 0x040013AF RID: 5039
	public const sbyte QUEST_DEL = 2;

	// Token: 0x040013B0 RID: 5040
	public const sbyte QUEST_FINISH = 3;

	// Token: 0x040013B1 RID: 5041
	public const sbyte QUEST_ACTION_FINISH = 4;

	// Token: 0x040013B2 RID: 5042
	public const sbyte QUEST_ACTION_SHOW_DIALOG = 5;

	// Token: 0x040013B3 RID: 5043
	public const sbyte PARTY_INVITE = 0;

	// Token: 0x040013B4 RID: 5044
	public const sbyte PARTY_ADD = 1;

	// Token: 0x040013B5 RID: 5045
	public const sbyte PARTY_DEL = 2;

	// Token: 0x040013B6 RID: 5046
	public const sbyte PARTY_CANCEL = 3;

	// Token: 0x040013B7 RID: 5047
	public const sbyte PARTY_APPCEPT = 4;

	// Token: 0x040013B8 RID: 5048
	public const sbyte PARTY_CREATE = 5;

	// Token: 0x040013B9 RID: 5049
	public const sbyte PARTY_APPCEPT_ADD = 6;

	// Token: 0x040013BA RID: 5050
	public const sbyte PARTY_XIN_VAO = 7;

	// Token: 0x040013BB RID: 5051
	public const sbyte SKILL_LEARN = 0;

	// Token: 0x040013BC RID: 5052
	public const sbyte SKILL_ADD = 1;

	// Token: 0x040013BD RID: 5053
	public const sbyte SKILL_UPDATE_XP = 2;

	// Token: 0x040013BE RID: 5054
	public const sbyte SKILL_DEL = 3;

	// Token: 0x040013BF RID: 5055
	public const sbyte UPGRADE_STEP_LOI = 0;

	// Token: 0x040013C0 RID: 5056
	public const sbyte UPGRADE_STEP_HOI = 1;

	// Token: 0x040013C1 RID: 5057
	public const sbyte UPGRADE_STEP_THANH_CONG = 2;

	// Token: 0x040013C2 RID: 5058
	public const sbyte UPGRADE_STEP_THAT_BAI = 3;

	// Token: 0x040013C3 RID: 5059
	public const sbyte UPGRADE_STEP_ITEM = 4;

	// Token: 0x040013C4 RID: 5060
	public const sbyte UPGRADE_STEP_LUCKY = 5;

	// Token: 0x040013C5 RID: 5061
	public const sbyte UPGRADE_STEP_BAOHIEM = 6;

	// Token: 0x040013C6 RID: 5062
	public const sbyte UPGRADE_STEP_OPEN_UPGRADE = 7;

	// Token: 0x040013C7 RID: 5063
	public const sbyte UPGRADE_STEP_OPEN_SHOP_MATERIAL = 8;

	// Token: 0x040013C8 RID: 5064
	public const sbyte UPGRADE_STEP_OPEN_KHAM = 9;

	// Token: 0x040013C9 RID: 5065
	public const sbyte UPGRADE_STEP_OPEN_DUT = 10;

	// Token: 0x040013CA RID: 5066
	public const sbyte UPGRADE_STEP_OPEN_SHOP_DA = 11;

	// Token: 0x040013CB RID: 5067
	public const sbyte UPGRADE_STEP_OPEN_GHEP_DA = 12;

	// Token: 0x040013CC RID: 5068
	public const sbyte UPGRADE_STEP_OPEN_TACH_DA = 13;

	// Token: 0x040013CD RID: 5069
	public const sbyte UPGRADE_STEP_BAO_HIEM_2 = 14;

	// Token: 0x040013CE RID: 5070
	public const sbyte UPGRADE_LAW_HEART = 15;

	// Token: 0x040013CF RID: 5071
	public const sbyte UPGRADE_LAW_HEART_THANH_CONG = 16;

	// Token: 0x040013D0 RID: 5072
	public const sbyte UPGRADE_LAW_HEART_THAT_BAI = 17;

	// Token: 0x040013D1 RID: 5073
	public const sbyte ACTION_OPEN_MENU = 0;

	// Token: 0x040013D2 RID: 5074
	public const sbyte ACTION_SET_ITEM = 1;

	// Token: 0x040013D3 RID: 5075
	public const sbyte ACTION_CUONG_HOA = 2;

	// Token: 0x040013D4 RID: 5076
	public const sbyte ACTION_SUCC = 3;

	// Token: 0x040013D5 RID: 5077
	public const sbyte ACTION_HOI_NANG_CAP = 4;

	// Token: 0x040013D6 RID: 5078
	public const sbyte ACTION_UPDATE_LIST = 5;

	// Token: 0x040013D7 RID: 5079
	public const sbyte ACTION_HE_SO_AN = 6;

	// Token: 0x040013D8 RID: 5080
	public const sbyte SPLIT_TYPE_SPLIT = 0;

	// Token: 0x040013D9 RID: 5081
	public const sbyte SPLIT_TYPE_JOIN = 1;

	// Token: 0x040013DA RID: 5082
	public const sbyte SPLIT_ACTION_BO_VAO = 0;

	// Token: 0x040013DB RID: 5083
	public const sbyte SPLIT_ACTION_XONG = 1;

	// Token: 0x040013DC RID: 5084
	public const sbyte SPLIT_ACTION_LOI = 2;

	// Token: 0x040013DD RID: 5085
	public const sbyte SPLIT_ACTION_OPEN_SPLIT = 3;

	// Token: 0x040013DE RID: 5086
	public const sbyte SPLIT_ACTION_OPEN_MENU_SPLIT = 4;

	// Token: 0x040013DF RID: 5087
	public const sbyte TRADE_OPEN = 0;

	// Token: 0x040013E0 RID: 5088
	public const sbyte TRADE_SET_ITEM = 1;

	// Token: 0x040013E1 RID: 5089
	public const sbyte TRADE_CHAT = 2;

	// Token: 0x040013E2 RID: 5090
	public const sbyte TRADE_LOCK = 3;

	// Token: 0x040013E3 RID: 5091
	public const sbyte TRADE_OK = 4;

	// Token: 0x040013E4 RID: 5092
	public const sbyte TRADE_CANCEL = 5;

	// Token: 0x040013E5 RID: 5093
	public const sbyte TRADE_INVITE = 6;

	// Token: 0x040013E6 RID: 5094
	public const sbyte TRADE_ACTION_DEL = 0;

	// Token: 0x040013E7 RID: 5095
	public const sbyte TRADE_ACTION_SET = 1;

	// Token: 0x040013E8 RID: 5096
	public const sbyte TICKET_BANHMI = 0;

	// Token: 0x040013E9 RID: 5097
	public const sbyte TICKET_BOSS = 1;

	// Token: 0x040013EA RID: 5098
	public const sbyte TICKET_PVP = 2;

	// Token: 0x040013EB RID: 5099
	public const sbyte TICKET_X2XP = 3;

	// Token: 0x040013EC RID: 5100
	public const sbyte RE_ITEM_OPEN = 0;

	// Token: 0x040013ED RID: 5101
	public const sbyte RE_ITEM_SET = 1;

	// Token: 0x040013EE RID: 5102
	public const sbyte RE_ITEM_REMOVE = 2;

	// Token: 0x040013EF RID: 5103
	public const sbyte RE_ITEM_ERROR = 3;

	// Token: 0x040013F0 RID: 5104
	public const sbyte RE_ITEM_OK_KHAM = 4;

	// Token: 0x040013F1 RID: 5105
	public const sbyte RE_ITEM_OK_UPGRADE_DA = 5;

	// Token: 0x040013F2 RID: 5106
	public const sbyte RE_ITEM_OK_TACH_DA = 6;

	// Token: 0x040013F3 RID: 5107
	public const sbyte RE_ITEM_OK_DUC_LO = 7;

	// Token: 0x040013F4 RID: 5108
	public const sbyte RE_ITEM_OK_HOAN_MY = 20;

	// Token: 0x040013F5 RID: 5109
	public const sbyte RE_ITEM_FAIL_HOAN_MY = 21;

	// Token: 0x040013F6 RID: 5110
	public const sbyte RE_ITEM_OK_KICH_AN = 22;

	// Token: 0x040013F7 RID: 5111
	public const sbyte RE_ITEM_FAIL_KICH_AN = 23;

	// Token: 0x040013F8 RID: 5112
	public const sbyte RE_CHE_TAC_CONG_DAP = 24;

	// Token: 0x040013F9 RID: 5113
	public const sbyte RE_CHE_TAC_CONG_OK = 25;

	// Token: 0x040013FA RID: 5114
	public const sbyte RE_DA_SIEU_CAP_DAP = 26;

	// Token: 0x040013FB RID: 5115
	public const sbyte RE_DA_SIEU_CAP_OK = 27;

	// Token: 0x040013FC RID: 5116
	public const sbyte RE_DA_SIEU_SET_DA_SC = 28;

	// Token: 0x040013FD RID: 5117
	public const sbyte RE_DA_SIEU_SET_DA_NL = 29;

	// Token: 0x040013FE RID: 5118
	public const sbyte RE_DA_SIEU_CAP_FAIL = 30;

	// Token: 0x040013FF RID: 5119
	public const sbyte RE_GHEP_DO_OK = 31;

	// Token: 0x04001400 RID: 5120
	public const sbyte RE_GHEP_DO_FAIL = 32;

	// Token: 0x04001401 RID: 5121
	public const sbyte RE_ITEM_OK_DUC_BANG_BUA_THUONG = 33;

	// Token: 0x04001402 RID: 5122
	public const sbyte RE_ITEM_OK_DUC_BANG_BUA_VIP = 34;

	// Token: 0x04001403 RID: 5123
	public const sbyte RE_DEVIL_SKILL_OPEN = 8;

	// Token: 0x04001404 RID: 5124
	public const sbyte RE_DEVIL_SKILL_SET = 9;

	// Token: 0x04001405 RID: 5125
	public const sbyte RE_DEVIL_SKILL_REMOVE = 10;

	// Token: 0x04001406 RID: 5126
	public const sbyte RE_DEVIL_SKILL_ERROR = 11;

	// Token: 0x04001407 RID: 5127
	public const sbyte RE_DEVIL_SKILL_OK_KHAM = 12;

	// Token: 0x04001408 RID: 5128
	public const sbyte RE_DEVIL_ITEM_OPEN = 13;

	// Token: 0x04001409 RID: 5129
	public const sbyte RE_DEVIL_ITEM_SET = 14;

	// Token: 0x0400140A RID: 5130
	public const sbyte RE_DEVIL_ITEM_REMOVE = 15;

	// Token: 0x0400140B RID: 5131
	public const sbyte RE_DEVIL_ITEM_ERROR = 16;

	// Token: 0x0400140C RID: 5132
	public const sbyte RE_DEVIL_ITEM_OK_KHAM = 17;

	// Token: 0x0400140D RID: 5133
	public const sbyte RE_DEVIL_SKILL_TI_LE = 18;

	// Token: 0x0400140E RID: 5134
	public const sbyte RE_DEVIL_ITEM_TI_LE = 19;

	// Token: 0x0400140F RID: 5135
	public const sbyte RE_GHEP_NHIEU_NGLIEU_THANH_1_OPEN = 20;

	// Token: 0x04001410 RID: 5136
	public const sbyte RE_GHEP_NHIEU_NGLIEU_THANH_1_OK = 21;

	// Token: 0x04001411 RID: 5137
	public const sbyte AU_REVICE = 1;

	// Token: 0x04001412 RID: 5138
	public const sbyte CHECK_LIST_PHO_BANG = 0;

	// Token: 0x04001413 RID: 5139
	public const sbyte CHECK_MEM_READY = 1;

	// Token: 0x04001414 RID: 5140
	public const sbyte CHECK_MEM_CANCLE = 2;

	// Token: 0x04001415 RID: 5141
	public const sbyte CHECK_ONE_MEM_CANCLE = 3;

	// Token: 0x04001416 RID: 5142
	public const sbyte CAPCHAR_RED_LINE = 0;

	// Token: 0x04001417 RID: 5143
	public const sbyte CAPCHAR_RED_LINE_FAIL = 1;

	// Token: 0x04001418 RID: 5144
	public const sbyte CAPCHAR_RED_LINE_FINISH = 2;

	// Token: 0x04001419 RID: 5145
	public const sbyte CAPCHAR_GOTO_SKY = 3;

	// Token: 0x0400141A RID: 5146
	public const sbyte CAPCHAR_GOTO_SKY_FAIL = 4;

	// Token: 0x0400141B RID: 5147
	public const sbyte CAPCHAR_GOTO_SKY_FINISH = 5;

	// Token: 0x0400141C RID: 5148
	public const sbyte TIME_PVP_PHO_BANG = 0;

	// Token: 0x0400141D RID: 5149
	public const sbyte TIME_HP_PHO_BANG = 1;

	// Token: 0x0400141E RID: 5150
	public const sbyte TIME_PHO_BANG_LITTLE = 2;

	// Token: 0x0400141F RID: 5151
	public const sbyte TIME_PHO_BANG_LITTLE_REVICE = 3;

	// Token: 0x04001420 RID: 5152
	public const sbyte TIME_SCORE = 4;

	// Token: 0x04001421 RID: 5153
	public const sbyte TIME_SCORE_NEW = 5;

	// Token: 0x04001422 RID: 5154
	public const sbyte CLAN_CREATE_DATA = 0;

	// Token: 0x04001423 RID: 5155
	public const sbyte CLAN_UPDATE_CHUC_VU = 1;

	// Token: 0x04001424 RID: 5156
	public const sbyte CLAN_UPDATE_DATA = 2;

	// Token: 0x04001425 RID: 5157
	public const sbyte CLAN_UPDATE_LIST_MEM = 3;

	// Token: 0x04001426 RID: 5158
	public const sbyte CLAN_ATTRIBUTE = 4;

	// Token: 0x04001427 RID: 5159
	public const sbyte CLAN_INFO_PLAYER = 5;

	// Token: 0x04001428 RID: 5160
	public const sbyte CLAN_CHAT_IN_CLAN = 8;

	// Token: 0x04001429 RID: 5161
	public const sbyte CLAN_MOI_VAO_CLAN = 7;

	// Token: 0x0400142A RID: 5162
	public const sbyte CLAN_ALL_CHAT_IN_CLAN = 9;

	// Token: 0x0400142B RID: 5163
	public const sbyte CLAN_REMOVE_CHAT = 11;

	// Token: 0x0400142C RID: 5164
	public const sbyte CLAN_LEAVE_CLAN = 10;

	// Token: 0x0400142D RID: 5165
	public const sbyte CLAN_ADD_REMOVE_LIST_MEM = 12;

	// Token: 0x0400142E RID: 5166
	public const sbyte CLAN_UPDATE_TIME_DONATE = 13;

	// Token: 0x0400142F RID: 5167
	public const sbyte CLAN_UPDATE_STATUS = 14;

	// Token: 0x04001430 RID: 5168
	public const sbyte CLAN_UPDATE_ATTRIBUTE_PLUS_PLAYER = 15;

	// Token: 0x04001431 RID: 5169
	public const sbyte CLAN_UPDATE_XP = 16;

	// Token: 0x04001432 RID: 5170
	public const sbyte CLAN_UPDATE_MONEY = 17;

	// Token: 0x04001433 RID: 5171
	public const sbyte CLAN_UPDATE_INFO_MEM_CLAN = 18;

	// Token: 0x04001434 RID: 5172
	public const sbyte CLAN_UPDATE_INVEN_CLAN = 19;

	// Token: 0x04001435 RID: 5173
	public const sbyte CLAN_THONGBAO_CUP = 20;

	// Token: 0x04001436 RID: 5174
	public const sbyte CLAN_CLOSE_CREATE_CLAN = 21;

	// Token: 0x04001437 RID: 5175
	public const sbyte UPDATECHAT_ALL = 0;

	// Token: 0x04001438 RID: 5176
	public const sbyte UPDATECHAT_ADD = 1;

	// Token: 0x04001439 RID: 5177
	public const sbyte CHUYENHOA_OPEN = 0;

	// Token: 0x0400143A RID: 5178
	public const sbyte CHUYENHOA_IMPORT_ITEM = 1;

	// Token: 0x0400143B RID: 5179
	public const sbyte CHUYENHOA_END = 3;

	// Token: 0x0400143C RID: 5180
	public const sbyte CHUYENHOA_UPDATE_PRICE = 2;

	// Token: 0x0400143D RID: 5181
	public const sbyte LITTLE_CREATE_BOSS = 0;

	// Token: 0x0400143E RID: 5182
	public const sbyte LITTLE_UPDATE_MP_HP = 1;

	// Token: 0x0400143F RID: 5183
	public const sbyte LITTLE_BOSS_FIGHT = 2;

	// Token: 0x04001440 RID: 5184
	public const sbyte LITTLE_BOSS_DIE = 3;

	// Token: 0x04001441 RID: 5185
	public const sbyte PET_CREATE = 0;

	// Token: 0x04001442 RID: 5186
	public const sbyte PET_REMOVE = 1;

	// Token: 0x04001443 RID: 5187
	public const sbyte PET_USE_SKILL = 2;

	// Token: 0x04001444 RID: 5188
	public const sbyte PET_INVEN = 3;

	// Token: 0x04001445 RID: 5189
	public const sbyte PET_USE = 4;

	// Token: 0x04001446 RID: 5190
	public const sbyte PVP_READY = 0;

	// Token: 0x04001447 RID: 5191
	public const sbyte PVP_3_SECOND = 1;

	// Token: 0x04001448 RID: 5192
	public const sbyte PVP_START = 2;

	// Token: 0x04001449 RID: 5193
	public const sbyte PVP_WIN = 3;

	// Token: 0x0400144A RID: 5194
	public const sbyte PVP_LOSE = 4;

	// Token: 0x0400144B RID: 5195
	public const sbyte MAX_UPDATE_ALL = 0;

	// Token: 0x0400144C RID: 5196
	public const sbyte MAX_UPDATE_ONE = 1;

	// Token: 0x0400144D RID: 5197
	public const sbyte MAX_OPEN = 2;

	// Token: 0x0400144E RID: 5198
	public const sbyte WANTED_OPEN = 0;

	// Token: 0x0400144F RID: 5199
	public const sbyte WANTED_FIND = 1;

	// Token: 0x04001450 RID: 5200
	public const sbyte WANTED_READY = 2;

	// Token: 0x04001451 RID: 5201
	public const sbyte WANTED_CANCLE = 3;

	// Token: 0x04001452 RID: 5202
	public const sbyte WANTED_UPDATE_POINT = 4;

	// Token: 0x04001453 RID: 5203
	public const sbyte WANTED_UPDATE_TIME_NEXT = 5;

	// Token: 0x04001454 RID: 5204
	public const sbyte CHEST_W_UPDATE = 0;

	// Token: 0x04001455 RID: 5205
	public const sbyte CHEST_W_DEL = 1;

	// Token: 0x04001456 RID: 5206
	public const sbyte LOL_CHAT = 2;

	// Token: 0x04001457 RID: 5207
	public const sbyte LOL_UPDATE_TYPE_OBJ = 0;

	// Token: 0x04001458 RID: 5208
	public const sbyte LOL_TYPE_PK = 1;

	// Token: 0x04001459 RID: 5209
	public const sbyte LOL_UPDATE_TRU_KD = 3;

	// Token: 0x0400145A RID: 5210
	public const sbyte LOL_LIST_BUFF = 4;

	// Token: 0x0400145B RID: 5211
	public const sbyte EFF_MP_HP_NOR = 0;

	// Token: 0x0400145C RID: 5212
	public const sbyte EFF_MP_HP_PHAN_DAM = 1;

	// Token: 0x0400145D RID: 5213
	public const sbyte EFF_KICK_BAT_TU = 0;

	// Token: 0x0400145E RID: 5214
	public const sbyte EFF_KICK_LOI_CAM_ON = 1;

	// Token: 0x0400145F RID: 5215
	public const sbyte EFF_KICK_LA_CHAN = 2;

	// Token: 0x04001460 RID: 5216
	public const sbyte EFF_KICK_KHOA_NANG_LUONG = 3;

	// Token: 0x04001461 RID: 5217
	public const sbyte EFF_KICK_BOC_PHA = 4;

	// Token: 0x04001462 RID: 5218
	public const sbyte EFF_KICK_TAP_TRUNG_CAO_DO = 5;

	// Token: 0x04001463 RID: 5219
	public const sbyte EFF_KICK_MA_CA_RONG = 6;

	// Token: 0x04001464 RID: 5220
	public const sbyte EFF_KICK_RESET_COUNTDOWN_KICK = 8;

	// Token: 0x04001465 RID: 5221
	public const sbyte EFF_KICK_RESET_COUNTDOWN_AVA = 9;

	// Token: 0x04001466 RID: 5222
	public const sbyte EFF_KICK_GIAI_PHONG_NANG_LUONG = 10;

	// Token: 0x04001467 RID: 5223
	public const sbyte EFF_KICK_NGUOI_BAT_TU = 11;

	// Token: 0x04001468 RID: 5224
	public const sbyte EVENT_TYPE_TAI_XIU = 0;

	// Token: 0x04001469 RID: 5225
	public const sbyte EVENT_ACTION_OPEN = 0;

	// Token: 0x0400146A RID: 5226
	public const sbyte EVENT_ACTION_TAI_XIU_DAT_CUOC = 1;

	// Token: 0x0400146B RID: 5227
	public const sbyte EVENT_ACTION_TAI_XIU_KET_QUA = 2;

	// Token: 0x0400146C RID: 5228
	public const sbyte EVENT_ACTION_TAI_XIU_UPDATE = 3;

	// Token: 0x0400146D RID: 5229
	public const sbyte EVENT_ACTION_TAI_XIU_LICH_SU_VAN = 4;

	// Token: 0x0400146E RID: 5230
	public const sbyte EVENT_TYPE_NAU_BANH_CHUNG_AUDITION = 1;

	// Token: 0x0400146F RID: 5231
	public const sbyte EVENT_ACTION_NAU_BANH_CHUNG_AUDITION_NAU = 0;

	// Token: 0x04001470 RID: 5232
	public const sbyte EVENT_ACTION_NAU_BANH_CHUNG_AUDITION_VOT_BANH = 1;

	// Token: 0x04001471 RID: 5233
	private const sbyte ACTION_OPEN = 0;

	// Token: 0x04001472 RID: 5234
	private const sbyte ACTION_SEND_INFO_EQUI = 1;

	// Token: 0x04001473 RID: 5235
	private const sbyte ACTION_KHAM_DA = 2;

	// Token: 0x04001474 RID: 5236
	private const sbyte ACTION_TACH_DA = 3;

	// Token: 0x04001475 RID: 5237
	private const sbyte ACTION_HANH_TRINH = 4;

	// Token: 0x04001476 RID: 5238
	public const sbyte TYPE_OPEN = 0;

	// Token: 0x04001477 RID: 5239
	public const sbyte TYPE_SEND_INFO = 1;

	// Token: 0x04001478 RID: 5240
	public const sbyte TYPE_SEND_QUA = 2;

	// Token: 0x04001479 RID: 5241
	public static iCommand cmdOffInterface;

	// Token: 0x0400147A RID: 5242
	public static iCommand cmdOffChat;

	// Token: 0x0400147B RID: 5243
	public static iCommand cmdOffName;

	// Token: 0x0400147C RID: 5244
	public static iCommand cmdOffAll;

	// Token: 0x0400147D RID: 5245
	public static iCommand cmdShowPos;

	// Token: 0x0400147E RID: 5246
	public static iCommand cmdShowSysout;

	// Token: 0x0400147F RID: 5247
	public static iCommand cmdShowIpLocal;

	// Token: 0x04001480 RID: 5248
	public static iCommand cmdShowInTabAdmin;

	// Token: 0x04001481 RID: 5249
	public static iCommand cmdSetSkillEff15;

	// Token: 0x04001482 RID: 5250
	public static iCommand cmdSetSkillEff20;

	// Token: 0x04001483 RID: 5251
	private short[][] hardcodeSkill5 = new short[][]
	{
		new short[]
		{
			33,
			35,
			37
		},
		new short[]
		{
			15,
			29,
			122
		},
		new short[]
		{
			44,
			48,
			50
		},
		new short[]
		{
			51,
			53,
			55
		},
		new short[]
		{
			58,
			66,
			68
		}
	};

	// Token: 0x04001484 RID: 5252
	private short[][] hardcodeSkill10 = new short[][]
	{
		new short[]
		{
			83,
			84,
			85
		},
		new short[]
		{
			86,
			87,
			123
		},
		new short[]
		{
			124,
			125,
			12
		},
		new short[]
		{
			52,
			63,
			56
		},
		new short[]
		{
			126,
			127,
			69
		}
	};

	// Token: 0x04001485 RID: 5253
	private short[][] hardcodeSkill15 = new short[][]
	{
		new short[]
		{
			180,
			181,
			182
		},
		new short[]
		{
			183,
			184,
			185
		},
		new short[]
		{
			186,
			187,
			188
		},
		new short[]
		{
			189,
			190,
			191
		},
		new short[]
		{
			192,
			193,
			194
		}
	};

	// Token: 0x04001486 RID: 5254
	private short[][] hardcodeSkill20 = new short[][]
	{
		new short[]
		{
			212,
			213,
			214
		},
		new short[]
		{
			215,
			216,
			217
		},
		new short[]
		{
			218,
			219,
			220
		},
		new short[]
		{
			221,
			222,
			223
		},
		new short[]
		{
			224,
			225,
			226
		}
	};

	// Token: 0x04001487 RID: 5255
	public Message msgLuu;

	// Token: 0x04001488 RID: 5256
	public short idMapLuu;

	// Token: 0x04001489 RID: 5257
	public static sbyte actionChangeMap;

	// Token: 0x0400148A RID: 5258
	public static bool isNondata;

	// Token: 0x0400148B RID: 5259
	public static short indexHotKeySkill;

	// Token: 0x0400148C RID: 5260
	public static short IdDialog = -1;

	// Token: 0x0400148D RID: 5261
	private int lechYNum;

	// Token: 0x0400148E RID: 5262
	public static short idItemUpgrade;

	// Token: 0x0400148F RID: 5263
	public static int yBoatMap;

	// Token: 0x04001490 RID: 5264
	public static sbyte[] mtest;

	// Token: 0x04001491 RID: 5265
	public static short IDDialogPhoBang = -1;

	// Token: 0x04001492 RID: 5266
	public static mImage[] mImgCapredLine;

	// Token: 0x04001493 RID: 5267
	public static short idLvthap = -1;

	// Token: 0x04001494 RID: 5268
	public static short idLvCao = -1;

	// Token: 0x04001495 RID: 5269
	public static sbyte numCuonghoa;

	// Token: 0x04001496 RID: 5270
	public static int timeLoadItemMap = -1;

	// Token: 0x04001497 RID: 5271
	public static sbyte ID_GiaoTiep_Server = -1;

	// Token: 0x04001498 RID: 5272
	public static string Str_GiaoTiep_Server = string.Empty;
}
