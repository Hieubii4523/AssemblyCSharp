using System;

// Token: 0x02000050 RID: 80
public class InfoMemList
{
	// Token: 0x06000580 RID: 1408 RVA: 0x0000A393 File Offset: 0x00008593
	public InfoMemList(int id)
	{
		this.id = id;
		this.Lv = -1;
	}

	// Token: 0x06000581 RID: 1409 RVA: 0x000090B5 File Offset: 0x000072B5
	public void updateXY(int x, int y)
	{
	}

	// Token: 0x06000582 RID: 1410 RVA: 0x0000A3C4 File Offset: 0x000085C4
	public void updateFace(short head, short hair, short hat)
	{
		this.head = head;
		this.hair = hair;
		this.hat = hat;
	}

	// Token: 0x06000583 RID: 1411 RVA: 0x0008014C File Offset: 0x0007E34C
	public void updateChar(short head, short hair, short hat, short body, short leg, short weapon)
	{
		this.charShow = new MainObject();
		this.charShow.sethead(head);
		this.charShow.sethair(hair);
		this.charShow.hat = hat;
		this.charShow.body = body;
		this.charShow.leg = leg;
		this.charShow.weapon = weapon;
	}

	// Token: 0x06000584 RID: 1412 RVA: 0x0000A3DC File Offset: 0x000085DC
	public void updateData(string name, short idMap, sbyte isMain, sbyte idArea)
	{
		this.name = name;
		this.idmap = idMap;
		this.isMain = isMain;
		this.idArea = (short)idArea;
	}

	// Token: 0x06000585 RID: 1413 RVA: 0x0000A3FC File Offset: 0x000085FC
	public void updateHP(int hp, int maxhp, int Lv)
	{
		this.hp = hp;
		this.maxhp = maxhp;
		this.Lv = Lv;
	}

	// Token: 0x06000586 RID: 1414 RVA: 0x000801B4 File Offset: 0x0007E3B4
	public void updateMemClan(string name, short Lv, sbyte levelInClan, short numDonate, short numGopRuby, short numQuest, int numCongHien)
	{
		this.name = name;
		this.Lv = (int)Lv;
		this.chucInClan = levelInClan;
		this.numTangqua = (int)numDonate;
		this.gopRuby = (int)numGopRuby;
		this.numQuest = (int)numQuest;
		this.congHien = numCongHien;
		mSystem.outz(string.Concat(new string[]
		{
			"name=",
			name,
			" lv=",
			Lv.ToString(),
			"chucvu=",
			this.chucInClan.ToString(),
			"numdo=",
			numDonate.ToString(),
			"numq=",
			numQuest.ToString(),
			"numruby=",
			numGopRuby.ToString(),
			"congHien=",
			numCongHien.ToString()
		}));
	}

	// Token: 0x06000587 RID: 1415 RVA: 0x0008028C File Offset: 0x0007E48C
	public static void setTypeEvent(int ID, sbyte typeEvent, string name, string info, int priceFight, int typeFight)
	{
		bool flag = InfoMemList.checkReturnEvent(typeEvent, name);
		if (!flag)
		{
			InfoMemList infoMemList = InfoMemList.getEvent(name, typeEvent);
			bool flag2 = false;
			bool flag3 = infoMemList == null;
			if (flag3)
			{
				infoMemList = new InfoMemList(ID);
				flag2 = true;
			}
			infoMemList.typeEvent = typeEvent;
			infoMemList.name = name;
			infoMemList.isNew = true;
			infoMemList.info = info;
			infoMemList.priceFight = priceFight;
			bool flag4 = infoMemList.typeEvent == 0;
			if (flag4)
			{
				infoMemList.indexIconEvent = 1;
				bool flag5 = flag2;
				if (flag5)
				{
					Interface_Game.addShowEvent(infoMemList);
				}
			}
			else
			{
				bool flag6 = infoMemList.typeEvent == 1;
				if (flag6)
				{
					infoMemList.indexIconEvent = 2;
					bool flag7 = flag2;
					if (flag7)
					{
						Interface_Game.addShowEvent(infoMemList);
					}
				}
				else
				{
					bool flag8 = infoMemList.typeEvent == 2;
					if (flag8)
					{
						infoMemList.indexIconEvent = 0;
						infoMemList.isNew = false;
						bool flag9 = name.CompareTo(T.tabServer) != 0 && info.Length > 0;
						if (flag9)
						{
							bool flag10 = flag2;
							if (flag10)
							{
								Interface_Game.addShowEvent(infoMemList);
							}
							infoMemList.isNew = true;
						}
					}
					else
					{
						bool flag11 = infoMemList.typeEvent == 3;
						if (flag11)
						{
							infoMemList.indexIconEvent = 3;
							infoMemList.typeFight = (sbyte)typeFight;
							bool flag12 = flag2;
							if (flag12)
							{
								Interface_Game.addShowEvent(infoMemList);
							}
						}
						else
						{
							bool flag13 = infoMemList.typeEvent == 4;
							if (flag13)
							{
								infoMemList.indexIconEvent = 4;
								bool flag14 = flag2;
								if (flag14)
								{
									Interface_Game.addShowEvent(infoMemList);
								}
							}
							else
							{
								bool flag15 = infoMemList.typeEvent == 5;
								if (flag15)
								{
									infoMemList.indexIconEvent = 2;
									infoMemList.infoFull = name + info;
									infoMemList.info = name;
									bool flag16 = infoMemList.info.Length > 16;
									if (flag16)
									{
										infoMemList.info = infoMemList.info.Substring(0, 15);
									}
									infoMemList.name = T.xinvao;
									bool flag17 = flag2;
									if (flag17)
									{
										Interface_Game.addShowEvent(infoMemList);
									}
								}
								else
								{
									bool flag18 = infoMemList.typeEvent == 6;
									if (flag18)
									{
										infoMemList.indexIconEvent = 5;
										bool flag19 = flag2;
										if (flag19)
										{
											Interface_Game.addShowEvent(infoMemList);
										}
									}
									else
									{
										bool flag20 = infoMemList.typeEvent == 7;
										if (flag20)
										{
											infoMemList.indexIconEvent = 6;
											infoMemList.typeFight = (sbyte)typeFight;
											bool flag21 = flag2;
											if (flag21)
											{
												Interface_Game.addShowEvent(infoMemList);
											}
										}
									}
								}
							}
						}
					}
				}
			}
			bool flag22 = flag2;
			if (flag22)
			{
				Player.vecEvent.addElement(infoMemList);
			}
			GameScreen.setNumMess();
		}
	}

	// Token: 0x06000588 RID: 1416 RVA: 0x000804F0 File Offset: 0x0007E6F0
	private static bool checkReturnEvent(sbyte type, string name)
	{
		bool flag = type == 0;
		if (flag)
		{
			bool flag2 = MsgSpamSetup.isCheckSpam(2, string.Empty);
			if (flag2)
			{
				GameCanvas.chatTabScr.addNewChat(T.hethong, string.Empty, name + T.mInfoSpamChat[2] + GameCanvas.getTextTime() + "\n", 1, false);
				return true;
			}
		}
		else
		{
			bool flag3 = type == 1;
			if (flag3)
			{
				bool flag4 = MsgSpamSetup.isCheckSpam(3, string.Empty);
				if (flag4)
				{
					GameCanvas.chatTabScr.addNewChat(T.hethong, string.Empty, name + T.mInfoSpamChat[3] + GameCanvas.getTextTime() + "\n", 1, false);
					return true;
				}
			}
			else
			{
				bool flag5 = type == 4;
				if (flag5)
				{
					bool flag6 = MsgSpamSetup.isCheckSpam(4, string.Empty);
					if (flag6)
					{
						GameCanvas.chatTabScr.addNewChat(T.hethong, string.Empty, name + T.mInfoSpamChat[4] + GameCanvas.getTextTime() + "\n", 1, false);
						return true;
					}
				}
				else
				{
					bool flag7 = type == 3 && MsgSpamSetup.isCheckSpam(5, string.Empty);
					if (flag7)
					{
						GameCanvas.chatTabScr.addNewChat(T.hethong, string.Empty, name + T.mInfoSpamChat[5] + GameCanvas.getTextTime() + "\n", 1, false);
						return true;
					}
				}
			}
		}
		return false;
	}

	// Token: 0x06000589 RID: 1417 RVA: 0x0008064C File Offset: 0x0007E84C
	public static InfoMemList getMem(int id, mVector vec)
	{
		for (int i = 0; i < vec.size(); i++)
		{
			InfoMemList infoMemList = (InfoMemList)vec.elementAt(i);
			bool flag = infoMemList.id == id;
			if (flag)
			{
				return infoMemList;
			}
		}
		return null;
	}

	// Token: 0x0600058A RID: 1418 RVA: 0x00080698 File Offset: 0x0007E898
	public void setAction()
	{
		bool flag = this.isNew;
		if (flag)
		{
			this.isNew = false;
		}
		GameScreen.setNumMess();
		mVector mVector = new mVector();
		switch (this.typeEvent)
		{
		case 0:
			mVector.addElement(GameCanvas.eventScr.cmdAddfriend);
			mVector.addElement(GameCanvas.eventScr.cmdDelEvent);
			GameCanvas.Start_Normal_DiaLog(this.name + " " + T.yeucauketban, mVector, true);
			break;
		case 1:
			mVector.addElement(GameCanvas.eventScr.cmdAddParty);
			mVector.addElement(GameCanvas.eventScr.cmdDelEvent);
			GameCanvas.Start_Normal_DiaLog(this.name + T.inviteParty, mVector, true);
			break;
		case 2:
		{
			bool flag2 = GameCanvas.currentScreen != GameCanvas.chatTabScr;
			if (flag2)
			{
				bool flag3 = !GameCanvas.isTouch && this.name.CompareTo(T.tabServer) != 0;
				if (flag3)
				{
					mVector.addElement(GameCanvas.eventScr.cmdTroChuyen);
					mVector.addElement(GameCanvas.eventScr.cmdDelEvent);
					GameCanvas.Start_Normal_DiaLog(T.TroChuyen + " " + this.name, mVector, true);
				}
				else
				{
					GameCanvas.chatTabScr.addNewChat(this.name, string.Empty, string.Empty, 0, true);
					GameCanvas.chatTabScr.Show(GameCanvas.currentScreen);
				}
			}
			break;
		}
		case 3:
		{
			mVector.addElement(MainEvent.cmdFight);
			mVector.addElement(GameCanvas.eventScr.cmdInfoEnemy);
			mVector.addElement(GameCanvas.eventScr.cmdDelEvent);
			string text = string.Empty;
			text = ((this.typeFight != 1) ? GameMidlet.format(T.yeucauthachdauENG, new string[]
			{
				this.name,
				string.Empty + this.priceFight.ToString()
			}) : GameMidlet.format(T.yeucauthachdauENG2, new string[]
			{
				this.name,
				string.Empty + this.priceFight.ToString()
			}));
			GameCanvas.Start_Normal_DiaLog(text, mVector, true);
			break;
		}
		case 4:
			mVector.addElement(GameCanvas.eventScr.cmdTrade);
			mVector.addElement(GameCanvas.eventScr.cmdDelEvent);
			GameCanvas.Start_Normal_DiaLog(this.name + " " + T.yeucaugiaodich, mVector, true);
			break;
		case 5:
			mVector.addElement(GameCanvas.eventScr.cmdAcceptAddParty);
			mVector.addElement(GameCanvas.eventScr.cmdDelEvent);
			GameCanvas.Start_Normal_DiaLog(this.infoFull, mVector, true);
			break;
		case 6:
			mVector.addElement(GameCanvas.eventScr.cmdAcceptClan);
			mVector.addElement(GameCanvas.eventScr.cmdDelEvent);
			GameCanvas.Start_Normal_DiaLog(this.name + T.muonmoivaoClan, mVector, true);
			break;
		case 7:
			mVector.addElement(GameCanvas.eventScr.cmdAcceptFightClan);
			mVector.addElement(GameCanvas.eventScr.cmdCancelFightClan);
			GameCanvas.Start_Normal_DiaLog(this.name + T.thachDauClanText, mVector, true);
			break;
		case 8:
			mVector.addElement(GameCanvas.eventScr.cmdAcceptSudo);
			mVector.addElement(GameCanvas.eventScr.cmdDelEvent);
			GameCanvas.Start_Normal_DiaLog(this.name + T.muonBaisu, mVector, false);
			break;
		}
	}

	// Token: 0x0600058B RID: 1419 RVA: 0x00080A18 File Offset: 0x0007EC18
	public static InfoMemList getEvent(string name, sbyte type)
	{
		for (int i = 0; i < Player.vecEvent.size(); i++)
		{
			InfoMemList infoMemList = (InfoMemList)Player.vecEvent.elementAt(i);
			bool flag = infoMemList.name.CompareTo(name) == 0 && infoMemList.typeEvent == type;
			if (flag)
			{
				return infoMemList;
			}
		}
		return null;
	}

	// Token: 0x0600058C RID: 1420 RVA: 0x00080A7C File Offset: 0x0007EC7C
	public string getCaptionClan(sbyte type)
	{
		bool flag = type == 0;
		string result;
		if (flag)
		{
			result = T.thuyentruong;
		}
		else
		{
			bool flag2 = type == 1;
			if (flag2)
			{
				result = T.thuyenpho;
			}
			else
			{
				bool flag3 = type == 2;
				if (flag3)
				{
					result = T.hoatieu;
				}
				else
				{
					result = T.thanhvien;
				}
			}
		}
		return result;
	}

	// Token: 0x0600058D RID: 1421 RVA: 0x00080AC8 File Offset: 0x0007ECC8
	public string getCaptionSudo(sbyte type)
	{
		bool flag = type == 1;
		string result;
		if (flag)
		{
			result = T.suPhu;
		}
		else
		{
			result = T.deTu;
		}
		return result;
	}

	// Token: 0x0600058E RID: 1422 RVA: 0x00080AF0 File Offset: 0x0007ECF0
	public void updateCharFace(short head, short hair, short hat)
	{
		bool flag = this.charShow == null;
		if (flag)
		{
			this.charShow = new MainObject();
		}
		this.charShow.head = head;
		this.charShow.hair = hair;
		this.charShow.hat = hat;
	}

	// Token: 0x0600058F RID: 1423 RVA: 0x00080B3C File Offset: 0x0007ED3C
	public void updateCharFullPart(short head, short hair, short hat, short body, short leg, short weapon)
	{
		bool flag = this.charShow == null;
		if (flag)
		{
			this.charShow = new MainObject();
		}
		this.charShow.sethead(head);
		this.charShow.sethair(hair);
		this.charShow.hat = hat;
		this.charShow.body = body;
		this.charShow.leg = leg;
		this.charShow.weapon = weapon;
	}

	// Token: 0x040007AB RID: 1963
	public const sbyte ADD_FRIEND = 0;

	// Token: 0x040007AC RID: 1964
	public const sbyte ADD_PARTY = 1;

	// Token: 0x040007AD RID: 1965
	public const sbyte ADD_CHAT = 2;

	// Token: 0x040007AE RID: 1966
	public const sbyte ADD_FIGHT = 3;

	// Token: 0x040007AF RID: 1967
	public const sbyte ADD_TRADE = 4;

	// Token: 0x040007B0 RID: 1968
	public const sbyte ADD_XIN_VAO_PARTY = 5;

	// Token: 0x040007B1 RID: 1969
	public const sbyte ADD_MOI_VAO_CLAN = 6;

	// Token: 0x040007B2 RID: 1970
	public const sbyte ADD_CLAN_FIGHT = 7;

	// Token: 0x040007B3 RID: 1971
	public const sbyte ADD_BAISU = 8;

	// Token: 0x040007B4 RID: 1972
	public const sbyte CAPTION_TRUONG = 0;

	// Token: 0x040007B5 RID: 1973
	public const sbyte CAPTION_PHO = 1;

	// Token: 0x040007B6 RID: 1974
	public const sbyte CAPTION_HOATIEU = 2;

	// Token: 0x040007B7 RID: 1975
	public const sbyte CAPTION_MEM = 10;

	// Token: 0x040007B8 RID: 1976
	public const sbyte CAPTION_SUPHU = 1;

	// Token: 0x040007B9 RID: 1977
	public const sbyte CAPTION_DETU = 2;

	// Token: 0x040007BA RID: 1978
	private int x;

	// Token: 0x040007BB RID: 1979
	private int y;

	// Token: 0x040007BC RID: 1980
	public short idmap;

	// Token: 0x040007BD RID: 1981
	public short idArea;

	// Token: 0x040007BE RID: 1982
	public string name;

	// Token: 0x040007BF RID: 1983
	public string info = string.Empty;

	// Token: 0x040007C0 RID: 1984
	public string infoFull;

	// Token: 0x040007C1 RID: 1985
	public string title;

	// Token: 0x040007C2 RID: 1986
	public string expSudo;

	// Token: 0x040007C3 RID: 1987
	public int id;

	// Token: 0x040007C4 RID: 1988
	public int idEvent;

	// Token: 0x040007C5 RID: 1989
	public int hp;

	// Token: 0x040007C6 RID: 1990
	public int maxhp;

	// Token: 0x040007C7 RID: 1991
	public int Lv;

	// Token: 0x040007C8 RID: 1992
	public int priceFight;

	// Token: 0x040007C9 RID: 1993
	public int numTangqua;

	// Token: 0x040007CA RID: 1994
	public int numQuest;

	// Token: 0x040007CB RID: 1995
	public int rank;

	// Token: 0x040007CC RID: 1996
	public sbyte isMain;

	// Token: 0x040007CD RID: 1997
	public sbyte typeOnline = -1;

	// Token: 0x040007CE RID: 1998
	public sbyte typeEvent;

	// Token: 0x040007CF RID: 1999
	public sbyte indexIconEvent;

	// Token: 0x040007D0 RID: 2000
	public sbyte chucInClan;

	// Token: 0x040007D1 RID: 2001
	public sbyte typeFight;

	// Token: 0x040007D2 RID: 2002
	public sbyte chucInSudo = -1;

	// Token: 0x040007D3 RID: 2003
	public short lvSudo;

	// Token: 0x040007D4 RID: 2004
	public short head;

	// Token: 0x040007D5 RID: 2005
	public short hair;

	// Token: 0x040007D6 RID: 2006
	public short hat;

	// Token: 0x040007D7 RID: 2007
	public short body;

	// Token: 0x040007D8 RID: 2008
	public short leg;

	// Token: 0x040007D9 RID: 2009
	public short weapon;

	// Token: 0x040007DA RID: 2010
	public bool isNew;

	// Token: 0x040007DB RID: 2011
	public bool isMe;

	// Token: 0x040007DC RID: 2012
	public int gopRuby;

	// Token: 0x040007DD RID: 2013
	public int congHien;

	// Token: 0x040007DE RID: 2014
	public MainObject charShow;

	// Token: 0x040007DF RID: 2015
	public string namePlayerNhan;

	// Token: 0x040007E0 RID: 2016
	public sbyte isWantedSuccess;

	// Token: 0x040007E1 RID: 2017
	public sbyte isReceiveGift;

	// Token: 0x040007E2 RID: 2018
	public sbyte isOwn;

	// Token: 0x040007E3 RID: 2019
	public QuaNapThe quaNapThe;

	// Token: 0x040007E4 RID: 2020
	public ItemQuaNT item;
}
