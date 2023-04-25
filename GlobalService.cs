using System;
using System.IO;
using System.Threading;
using UnityEngine;

// Token: 0x0200003A RID: 58
public class GlobalService : Cmd_Message
{
	// Token: 0x0600045F RID: 1119 RVA: 0x00009FF3 File Offset: 0x000081F3
	public static GlobalService gI()
	{
		if (GlobalService.instance == null)
		{
			GlobalService.instance = new GlobalService();
		}
		return GlobalService.instance;
	}

	// Token: 0x06000460 RID: 1120 RVA: 0x00078BDC File Offset: 0x00076DDC
	public void Login(string user, string pass, sbyte type)
	{
		base.init(-2);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeUTF(user);
			this.m.writer().writeUTF(pass);
			if (GameCanvas.isSuperLowGraphic)
			{
				this.m.writer().writeByte(0);
			}
			else if (GameCanvas.isIos())
			{
				this.m.writer().writeByte((int)GameMidlet.ZOOM_IOS);
			}
			else
			{
				this.m.writer().writeByte(mGraphics.zoomLevel);
			}
			this.m.writer().writeUTF("1.2.3");
			this.m.writer().writeByte((int)GameMidlet.DEVICE);
			this.m.writer().writeInt(GameMidlet.ITOUCH);
			this.m.writer().writeByte(ListChar_Screen.IndexCharSelected);
			this.m.writer().writeUTF(GameMidlet.loginPlus());
			this.m.writer().writeUTF("checkmodhaitac:android:isolatedSplits=true");
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x06000461 RID: 1121 RVA: 0x00078D18 File Offset: 0x00076F18
	public void Obj_Move(short x, short y)
	{
		base.init(1);
		try
		{
			this.m.writer().writeShort(x);
			this.m.writer().writeShort(y);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x06000462 RID: 1122 RVA: 0x00078D6C File Offset: 0x00076F6C
	public void load_image(short id, short cat)
	{
		if (cat == 10000 && id >= 10000)
		{
			cat = 26000;
			id -= 10000;
		}
		base.init(-51);
		try
		{
			this.m.writer().writeShort((int)(id + cat));
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x06000463 RID: 1123 RVA: 0x00078DD0 File Offset: 0x00076FD0
	public void Load_Image_New(sbyte type, short id)
	{
		base.init(-92);
		try
		{
			this.m.writer().write(type);
			this.m.writer().writeShort(id);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x06000464 RID: 1124 RVA: 0x00078E24 File Offset: 0x00077024
	public void char_info(short id)
	{
		base.init(-5);
		try
		{
			this.m.writer().writeShort(id);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x06000465 RID: 1125 RVA: 0x00078E68 File Offset: 0x00077068
	public void monster_info(short id)
	{
		base.init(4);
		try
		{
			this.m.writer().writeShort(id);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x06000466 RID: 1126 RVA: 0x00078EA8 File Offset: 0x000770A8
	public void get_DATA(sbyte type)
	{
		base.init(-7);
		try
		{
			this.m.writer().writeByte(type);
		}
		catch (Exception)
		{
		}
		base.send();
		mSystem.outz("getdata=" + type.ToString());
	}

	// Token: 0x06000467 RID: 1127 RVA: 0x00078F00 File Offset: 0x00077100
	public void Player_Fire(short idSkill, sbyte CatBeFire, mVector VecBeFire)
	{
		base.init(2);
		try
		{
			this.m.writer().writeShort(idSkill);
			this.m.writer().writeByte(CatBeFire);
			sbyte b = (sbyte)VecBeFire.size();
			this.m.writer().writeByte(b);
			if (b == 0)
			{
				return;
			}
			for (int i = 0; i < (int)b; i++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)VecBeFire.elementAt(i);
				this.m.writer().writeShort(object_Effect_Skill.ID);
			}
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x06000468 RID: 1128 RVA: 0x00078FA0 File Offset: 0x000771A0
	public void Player_Revice(sbyte type)
	{
		base.init(6);
		try
		{
			this.m.writer().writeByte(type);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x06000469 RID: 1129 RVA: 0x00078FE0 File Offset: 0x000771E0
	public void Get_Xp_Map_Train(sbyte type)
	{
		base.init(9);
		try
		{
			this.m.writer().writeByte(type);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x0600046A RID: 1130 RVA: 0x00079024 File Offset: 0x00077224
	public void Select_Char(short id, sbyte type, short idSupport)
	{
		if (GameCanvas.tickSelectChar <= 0)
		{
			base.init(-9);
			try
			{
				this.m.writer().writeShort(id);
				this.m.writer().writeByte(type);
				this.m.writer().writeShort(idSupport);
			}
			catch (Exception)
			{
			}
			base.send();
			GameCanvas.tickSelectChar = 100;
		}
	}

	// Token: 0x0600046B RID: 1131 RVA: 0x00079098 File Offset: 0x00077298
	public void Del_Char(sbyte type, short id)
	{
		base.init(-37);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeShort(id);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x0600046C RID: 1132 RVA: 0x000790EC File Offset: 0x000772EC
	public void Create_Char(string name, sbyte clazz, short head, short hair)
	{
		base.init(-8);
		try
		{
			this.m.writer().writeUTF(name);
			this.m.writer().writeByte(clazz);
			this.m.writer().writeShort(head);
			this.m.writer().writeShort(hair);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x0600046D RID: 1133 RVA: 0x00079164 File Offset: 0x00077364
	public void Choice_Dialog_server(short id, sbyte value)
	{
		base.init(-11);
		try
		{
			this.m.writer().writeShort(id);
			this.m.writer().writeByte(value);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x0600046E RID: 1134 RVA: 0x000791B8 File Offset: 0x000773B8
	public void Get_Item_Map(short id, sbyte cat)
	{
		base.init(12);
		try
		{
			this.m.writer().writeShort(id);
			this.m.writer().writeByte(cat);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x0600046F RID: 1135 RVA: 0x0007920C File Offset: 0x0007740C
	public void Use_Potion(short id)
	{
		base.init(-13);
		try
		{
			this.m.writer().writeShort(id);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x06000470 RID: 1136 RVA: 0x00079250 File Offset: 0x00077450
	public void Set_PK(sbyte type, sbyte action)
	{
		base.init(14);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeByte(action);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x06000471 RID: 1137 RVA: 0x000792A4 File Offset: 0x000774A4
	public void Add_Point_Attribute(sbyte index, short value)
	{
		base.init(-16);
		try
		{
			this.m.writer().writeByte(index);
			this.m.writer().writeShort(value);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x06000472 RID: 1138 RVA: 0x000792F8 File Offset: 0x000774F8
	public void Add_Point_Skill(short ID, short value)
	{
		base.init(-17);
		try
		{
			this.m.writer().writeShort(ID);
			this.m.writer().writeShort(value);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x06000473 RID: 1139 RVA: 0x0007934C File Offset: 0x0007754C
	public void Buy_Item_Potion(sbyte TypeShop, short ID, short value, sbyte cat)
	{
		mSystem.outz("Buy_Item_Potion " + ID.ToString());
		base.init(-18);
		try
		{
			this.m.writer().writeByte(TypeShop);
			this.m.writer().writeShort(ID);
			this.m.writer().writeShort(value);
			if (TypeShop == 116 || TypeShop == 118)
			{
				this.m.writer().writeByte(cat);
			}
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x06000474 RID: 1140 RVA: 0x000793E4 File Offset: 0x000775E4
	public void Dynamic_Menu(short idNPC, sbyte idMenu, sbyte index)
	{
		base.init(-20);
		try
		{
			this.m.writer().writeShort(idNPC);
			this.m.writer().writeByte(idMenu);
			this.m.writer().writeByte(index);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x06000475 RID: 1141 RVA: 0x00079448 File Offset: 0x00077648
	public void shop_NPC(short idNPC)
	{
		if (GameScreen.player != null)
		{
			this.Obj_Move((short)GameScreen.player.x, (short)GameScreen.player.y);
		}
		base.init(-19);
		try
		{
			this.m.writer().writeShort(idNPC);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x06000476 RID: 1142 RVA: 0x000794AC File Offset: 0x000776AC
	public void Use_Item(short idItem, sbyte cat)
	{
		base.init(-22);
		try
		{
			this.m.writer().writeShort(idItem);
			this.m.writer().writeByte(cat);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x06000477 RID: 1143 RVA: 0x00079500 File Offset: 0x00077700
	public void Sell_Item(sbyte type, short idItem, sbyte cat, short num)
	{
		base.init(-21);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeShort(idItem);
			this.m.writer().writeByte(cat);
			this.m.writer().writeShort(num);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x06000478 RID: 1144 RVA: 0x00079578 File Offset: 0x00077778
	public void quest(sbyte action, short id)
	{
		base.init(-23);
		try
		{
			this.m.writer().writeByte(action);
			this.m.writer().writeShort(id);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x06000479 RID: 1145 RVA: 0x000795CC File Offset: 0x000777CC
	public void Get_Info_NPC(short id)
	{
		base.init(-24);
		try
		{
			this.m.writer().writeShort(id);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x0600047A RID: 1146 RVA: 0x00079610 File Offset: 0x00077810
	public void Party(sbyte type, short id)
	{
		base.init(-25);
		try
		{
			this.m.writer().writeByte(type);
			if (type == 0 || type == 2 || type == 4 || type == 6)
			{
				this.m.writer().writeShort(id);
			}
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x0600047B RID: 1147 RVA: 0x00079674 File Offset: 0x00077874
	public void chatPopup(string text)
	{
		if (text.Contains("chat"))
		{
			GameScreen.atchat = !GameScreen.atchat;
			new Thread(new ThreadStart(GameScreen.Autochat)).Start();
		}
		if (text.Contains("speed "))
		{
			Time.timeScale = (float)int.Parse(text.Replace("speed ", ""));
		}
		base.init(17);
		if (text.CompareTo("super") == 0)
		{
			this.checkChangeHair();
		}
		if (GameCanvas.istest)
		{
			if (text.CompareTo("opcchestadmin") == 0)
			{
				GameScreen.isOnChestAdmin = true;
				this.startMenuChest();
				return;
			}
			if (text.CompareTo("onmod123") == 0)
			{
				GameScreen.player.strChatPopup = "Bật Mod";
				GameScreen.typeMod = 1;
				return;
			}
			if (text.CompareTo("offmod123") == 0)
			{
				GameScreen.player.strChatPopup = "Tắt Mod";
				GameScreen.typeMod = 0;
				return;
			}
			if (text.CompareTo("muaruong") == 0)
			{
				HuyHieuClanScreen.instance = new HuyHieuClanScreen();
				HuyHieuClanScreen.instance.Show(GameCanvas.gameScr);
				return;
			}
			if (text.CompareTo("taixiu") == 0)
			{
				TaiXiuScreen.instance = new TaiXiuScreen(string.Empty, 0, 0, 0, 0, 60);
				TaiXiuScreen.instance.Show(GameCanvas.gameScr);
				return;
			}
			if (text.CompareTo("log") == 0)
			{
				GameScreen.isShowText = !GameScreen.isShowText;
				GameCanvas.vecTest.removeAllElements();
				mSystem.outz("clear xong");
			}
			if (text.CompareTo("clear") == 0)
			{
				GameCanvas.vecTest.removeAllElements();
				mSystem.outz("clear xong");
			}
			if (text.CompareTo("login") == 0)
			{
				GameCanvas.loginScr.doLogin(false, 0, GameCanvas.loginScr.tfUser.getText(), GameCanvas.loginScr.tfPass.getText());
			}
			if (text.CompareTo("delrms") == 0)
			{
				GameMidlet.delAllRms();
				mSystem.outz("delete rms xong");
			}
			if (text.CompareTo("goal") == 0)
			{
				GameScreen.addEffectEnd(178, 0, GameScreen.player.x, GameScreen.player.y, 2, GameScreen.player);
			}
			try
			{
				int num = int.Parse(text);
				GameScreen.player.TestSkill((short)num);
			}
			catch (Exception)
			{
			}
		}
		try
		{
			this.m.writer().writeUTF(text);
		}
		catch (Exception)
		{
		}
		base.send();
		GameCanvas.chatTabScr.addNewChat(T.tabServer, string.Empty, GameScreen.player.name + ": " + text, 1, false);
	}

	// Token: 0x0600047C RID: 1148 RVA: 0x00079908 File Offset: 0x00077B08
	private void checkChangeHair()
	{
		if (GameScreen.player.hair == 772 || GameScreen.player.hair == 773 || GameScreen.player.hair == 774)
		{
			base.init(68);
			base.send();
		}
	}

	// Token: 0x0600047D RID: 1149 RVA: 0x00079958 File Offset: 0x00077B58
	public void startMenuChest()
	{
		mVector mVector = new mVector();
		ReadMessenge.cmdOffAll = new iCommand("Off All", 5, 3, GameCanvas.readMess);
		mVector.addElement(ReadMessenge.cmdOffAll);
		ReadMessenge.cmdOffInterface = new iCommand("Off Interface", 5, 0, GameCanvas.readMess);
		mVector.addElement(ReadMessenge.cmdOffInterface);
		ReadMessenge.cmdOffChat = new iCommand("Off Chat", 5, 1, GameCanvas.readMess);
		mVector.addElement(ReadMessenge.cmdOffChat);
		ReadMessenge.cmdOffName = new iCommand("Off Name", 5, 2, GameCanvas.readMess);
		mVector.addElement(ReadMessenge.cmdOffName);
		ReadMessenge.cmdShowPos = new iCommand("Show Pos", 5, 4, GameCanvas.readMess);
		mVector.addElement(ReadMessenge.cmdShowPos);
		ReadMessenge.cmdShowIpLocal = new iCommand("Show Ip Local", 5, 6, GameCanvas.readMess);
		mVector.addElement(ReadMessenge.cmdShowIpLocal);
		ReadMessenge.cmdShowSysout = new iCommand("Show System Out", 5, 5, GameCanvas.readMess);
		mVector.addElement(ReadMessenge.cmdShowSysout);
		ReadMessenge.cmdShowInTabAdmin = new iCommand("Show Info Tab Admin", 5, 7, GameCanvas.readMess);
		mVector.addElement(ReadMessenge.cmdShowInTabAdmin);
		iCommand o = new iCommand("Xét hiệu ứng Skill 5", 14, GameCanvas.readMess);
		mVector.addElement(o);
		iCommand o2 = new iCommand("Xét hiệu ứng Skill 10", 15, GameCanvas.readMess);
		mVector.addElement(o2);
		ReadMessenge.cmdSetSkillEff15 = new iCommand("Xét hiệu ứng Skill 15", 7, GameCanvas.readMess);
		mVector.addElement(ReadMessenge.cmdSetSkillEff15);
		ReadMessenge.cmdSetSkillEff20 = new iCommand("Xét hiệu ứng Skill 20", 9, GameCanvas.readMess);
		mVector.addElement(ReadMessenge.cmdSetSkillEff20);
		GameCanvas.menu.startAt(mVector, 2, "Chest Admin");
	}

	// Token: 0x0600047E RID: 1150 RVA: 0x00079AF8 File Offset: 0x00077CF8
	public void chatTab(string name, string str)
	{
		base.init(18);
		try
		{
			this.m.writer().writeUTF(name);
			this.m.writer().writeUTF(str);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x0600047F RID: 1151 RVA: 0x00079B4C File Offset: 0x00077D4C
	public void Register(string name, string pass)
	{
		base.init(-26);
		try
		{
			this.m.writer().writeUTF(name);
			this.m.writer().writeUTF(pass);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x06000480 RID: 1152 RVA: 0x00079BA0 File Offset: 0x00077DA0
	public void Save_RMS_Server(sbyte type, sbyte id, sbyte[] mdata)
	{
		base.init(-33);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeByte(id);
			if (mdata != null)
			{
				int num = mdata.Length;
				this.m.writer().writeShort(num);
				for (int i = 0; i < num; i++)
				{
					this.m.writer().writeByte(mdata[i]);
				}
			}
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x06000481 RID: 1153 RVA: 0x00079C2C File Offset: 0x00077E2C
	public void Friend(sbyte type, int Id)
	{
		base.init(-29);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeInt(Id);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x06000482 RID: 1154 RVA: 0x00079C80 File Offset: 0x00077E80
	public void ListFromServer(sbyte type, sbyte IdList, sbyte page)
	{
		base.init(-30);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeByte(IdList);
			this.m.writer().writeByte(page);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x06000483 RID: 1155 RVA: 0x00079CE4 File Offset: 0x00077EE4
	public void Chest(sbyte action, short Id, sbyte cat, int num)
	{
		mSystem.outz(string.Concat(new string[]
		{
			"chestList ",
			action.ToString(),
			" ",
			Id.ToString(),
			" ",
			cat.ToString(),
			" ",
			num.ToString()
		}));
		base.init(-32);
		try
		{
			this.m.writer().writeByte(action);
			this.m.writer().writeShort(Id);
			this.m.writer().writeByte(cat);
			this.m.writer().writeInt(num);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x06000484 RID: 1156 RVA: 0x0000A00B File Offset: 0x0000820B
	public void CheckVersion()
	{
		base.init(-6);
		base.send();
	}

	// Token: 0x06000485 RID: 1157 RVA: 0x00079DB4 File Offset: 0x00077FB4
	public void Fight(sbyte type, short Id, sbyte typeFight)
	{
		base.init(-35);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeShort(Id);
			this.m.writer().writeByte(typeFight);
		}
		catch (Exception)
		{
		}
		base.send();
		GameCanvas.tickAction = 4500;
	}

	// Token: 0x06000486 RID: 1158 RVA: 0x00079E24 File Offset: 0x00078024
	public void Buff(short IdBuff, sbyte cat, mVector vec)
	{
		base.init(20);
		try
		{
			this.m.writer().writeShort(IdBuff);
			this.m.writer().writeByte(cat);
			this.m.writer().writeByte(vec.size());
			for (int i = 0; i < vec.size(); i++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)vec.elementAt(i);
				this.m.writer().writeShort(object_Effect_Skill.ID);
			}
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x06000487 RID: 1159 RVA: 0x00079EC0 File Offset: 0x000780C0
	public void Learn_Skill(sbyte typeAction, short Index)
	{
		base.init(-28);
		try
		{
			this.m.writer().writeByte(typeAction);
			this.m.writer().writeShort(Index);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x06000488 RID: 1160 RVA: 0x00079F14 File Offset: 0x00078114
	public void List_Skill_Map_Train(short Id)
	{
		base.init(22);
		try
		{
			this.m.writer().writeShort(Id);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x06000489 RID: 1161 RVA: 0x00079F58 File Offset: 0x00078158
	public void Select_Area(sbyte type, sbyte select)
	{
		base.init(23);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeByte(select);
		}
		catch (Exception)
		{
		}
		base.send();
		GameCanvas.Start_Waiting_DiaLog(T.pleaseWaiting, true);
	}

	// Token: 0x0600048A RID: 1162 RVA: 0x00079FB8 File Offset: 0x000781B8
	public void Move_To_Player(sbyte type, int ID)
	{
		base.init(-36);
		try
		{
			this.m.writer().writeInt(ID);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x0600048B RID: 1163 RVA: 0x00079FFC File Offset: 0x000781FC
	public void Request_Image_Android()
	{
		base.init(-38);
		try
		{
			if (GameCanvas.isIos())
			{
				this.m.writer().writeByte((int)GameMidlet.ZOOM_IOS);
			}
			else
			{
				this.m.writer().writeByte(mGraphics.zoomLevel);
			}
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x0600048C RID: 1164 RVA: 0x0007A060 File Offset: 0x00078260
	public void Show_Player_Info(string name)
	{
		base.init(-42);
		try
		{
			this.m.writer().writeUTF(name);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x0600048D RID: 1165 RVA: 0x0000A01B File Offset: 0x0000821B
	public void Exit_View()
	{
		base.init(-43);
		base.send();
	}

	// Token: 0x0600048E RID: 1166 RVA: 0x0007A0A4 File Offset: 0x000782A4
	public void getDataEffAuto(short id)
	{
		base.init(-44);
		try
		{
			this.m.writer().writeShort(id);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x0600048F RID: 1167 RVA: 0x0007A0E8 File Offset: 0x000782E8
	public void getDataSkillEFf(sbyte type, short id)
	{
		base.init(74);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeShort(id);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x06000490 RID: 1168 RVA: 0x0000A02B File Offset: 0x0000822B
	public void Update_Pk_Point()
	{
		base.init(-45);
		base.send();
	}

	// Token: 0x06000491 RID: 1169 RVA: 0x0007A13C File Offset: 0x0007833C
	public void World_Chanel(sbyte type, string text)
	{
		base.init(-46);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeUTF(text);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x06000492 RID: 1170 RVA: 0x0007A190 File Offset: 0x00078390
	public void Upgrade_Item(sbyte type, short idItem, sbyte bery_gem)
	{
		base.init(-48);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeShort(idItem);
			this.m.writer().writeByte(bery_gem);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x06000493 RID: 1171 RVA: 0x0007A1F4 File Offset: 0x000783F4
	public void Split_Item(sbyte type, sbyte action, short idItem, sbyte cat, short num)
	{
		base.init(-50);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeByte(action);
			this.m.writer().writeShort(idItem);
			this.m.writer().writeByte(cat);
			this.m.writer().writeShort(num);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x06000494 RID: 1172 RVA: 0x0007A27C File Offset: 0x0007847C
	public void Hanh_Trinh(sbyte action, short idItem)
	{
		base.init(79);
		try
		{
			this.m.writer().writeByte(action);
			this.m.writer().writeShort(idItem);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x06000495 RID: 1173 RVA: 0x0007A2D0 File Offset: 0x000784D0
	public void Trade(sbyte action, short Id, sbyte cat, int num, string str)
	{
		base.init(-49);
		try
		{
			this.m.writer().writeByte(action);
			if (action == 1 || action == 6)
			{
				this.m.writer().writeShort(Id);
				this.m.writer().writeByte(cat);
				this.m.writer().writeInt(num);
			}
			else if (action == 2)
			{
				this.m.writer().writeUTF(str);
			}
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x06000496 RID: 1174 RVA: 0x0007A368 File Offset: 0x00078568
	public void Ship(sbyte action)
	{
		base.init(-53);
		try
		{
			this.m.writer().writeByte(action);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x06000497 RID: 1175 RVA: 0x0007A3AC File Offset: 0x000785AC
	public void ghost(sbyte id)
	{
		base.init(-55);
		try
		{
			this.m.writer().writeByte(id);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x06000498 RID: 1176 RVA: 0x0007A3F0 File Offset: 0x000785F0
	public void changeMapOk()
	{
		base.init(0);
		try
		{
			this.m.writer().writeShort(GameCanvas.loadmap.idMap);
			this.m.writer().writeByte(ReadMessenge.actionChangeMap);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x06000499 RID: 1177 RVA: 0x0000A03B File Offset: 0x0000823B
	public void OkChangeMapLink()
	{
		base.init(30);
		base.send();
	}

	// Token: 0x0600049A RID: 1178 RVA: 0x0007A450 File Offset: 0x00078650
	public void Frist_Login(string str)
	{
		base.init(-57);
		try
		{
			this.m.writer().writeUTF(str);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x0600049B RID: 1179 RVA: 0x0007A494 File Offset: 0x00078694
	public void InputServer(short Id, string[] str)
	{
		base.init(-58);
		try
		{
			this.m.writer().writeShort(Id);
			this.m.writer().writeByte(str.Length);
			for (int i = 0; i < str.Length; i++)
			{
				this.m.writer().writeUTF(str[i]);
			}
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x0600049C RID: 1180 RVA: 0x0007A50C File Offset: 0x0007870C
	public void Use_Item_Shop(short id, sbyte typeShop)
	{
		base.init(-60);
		try
		{
			this.m.writer().writeShort(id);
			this.m.writer().writeByte(typeShop);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x0600049D RID: 1181 RVA: 0x0000A04B File Offset: 0x0000824B
	public void Update_Part_Boat()
	{
		base.init(-62);
		base.send();
	}

	// Token: 0x0600049E RID: 1182 RVA: 0x0007A560 File Offset: 0x00078760
	public void PvP(sbyte action)
	{
		base.init(-63);
		try
		{
			this.m.writer().writeByte(action);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x0600049F RID: 1183 RVA: 0x0000A05B File Offset: 0x0000825B
	public void BeginGame()
	{
		base.init(-65);
		base.send();
	}

	// Token: 0x060004A0 RID: 1184 RVA: 0x0007A5A4 File Offset: 0x000787A4
	public void rebuild_Item(sbyte type, sbyte action, short idItem, sbyte cat, short num)
	{
		base.init(-67);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeByte(action);
			this.m.writer().writeShort(idItem);
			this.m.writer().writeByte(cat);
			this.m.writer().writeShort(num);
			this.m.writer().writeShort(-1);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004A1 RID: 1185 RVA: 0x0007A63C File Offset: 0x0007883C
	public void rebuild_Item(sbyte type, sbyte action, short idItem, sbyte cat, short num, short idBua)
	{
		base.init(-67);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeByte(action);
			this.m.writer().writeShort(idItem);
			this.m.writer().writeByte(cat);
			this.m.writer().writeShort(num);
			this.m.writer().writeShort(idBua);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004A2 RID: 1186 RVA: 0x0007A63C File Offset: 0x0007883C
	public void rebuild_Item_DIAL(sbyte type, sbyte action, short idItem, sbyte cat, short num, short hammer)
	{
		base.init(-67);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeByte(action);
			this.m.writer().writeShort(idItem);
			this.m.writer().writeByte(cat);
			this.m.writer().writeShort(num);
			this.m.writer().writeShort(hammer);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004A3 RID: 1187 RVA: 0x0007A6D8 File Offset: 0x000788D8
	public void Buy_Gem(string str1, string str2)
	{
		base.init(-68);
		try
		{
			this.m.writer().writeUTF(str1);
			this.m.writer().writeUTF(str2);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004A4 RID: 1188 RVA: 0x0000A06B File Offset: 0x0000826B
	public void Update_Num_Player_Map()
	{
		base.init(-70);
		base.send();
	}

	// Token: 0x060004A5 RID: 1189 RVA: 0x0007A72C File Offset: 0x0007892C
	public void Auto_revice(sbyte type)
	{
		base.init(-71);
		try
		{
			this.m.writer().writeByte(type);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004A6 RID: 1190 RVA: 0x0007A770 File Offset: 0x00078970
	public void Red_Line(sbyte type, sbyte key)
	{
		base.init(-72);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeByte(key);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004A7 RID: 1191 RVA: 0x0007A7C4 File Offset: 0x000789C4
	public void Check_List_Pho_Bang(sbyte type)
	{
		base.init(-74);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeShort(ReadMessenge.IDDialogPhoBang);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004A8 RID: 1192 RVA: 0x0000A07B File Offset: 0x0000827B
	public void Check_AFK()
	{
		base.init(-102);
		base.send();
	}

	// Token: 0x060004A9 RID: 1193 RVA: 0x0007A81C File Offset: 0x00078A1C
	public void Clan_CMD(sbyte type, string strChat, int id, sbyte chucvu)
	{
		base.init(-52);
		try
		{
			this.m.writer().writeByte(type);
			if (type == 0 || type == 5 || type == 1 || type == 2 || type == 3)
			{
				this.m.writer().writeUTF(strChat);
				this.m.writer().writeByte(chucvu);
			}
			else if (type == 11 || type == 10 || type == 12)
			{
				this.m.writer().writeInt(id);
			}
			else if (type == 6)
			{
				this.m.writer().writeByte(chucvu);
				this.m.writer().writeByte(id);
			}
			else if (type == 7 || type == 16)
			{
				this.m.writer().writeUTF(strChat);
				this.m.writer().writeInt(id);
			}
			else if (type == 14)
			{
				this.m.writer().writeShort(id);
				this.m.writer().writeByte(chucvu);
			}
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004AA RID: 1194 RVA: 0x0007A938 File Offset: 0x00078B38
	public void ChuyenHoa(sbyte type, short idLeft, short idRight)
	{
		base.init(-77);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeShort(idLeft);
			if (type == 2 || type == 3)
			{
				this.m.writer().writeShort(idRight);
			}
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004AB RID: 1195 RVA: 0x0007A9A4 File Offset: 0x00078BA4
	public void RegisterNew(string[] mstr)
	{
		base.init(-103);
		try
		{
			for (int i = 0; i < mstr.Length; i++)
			{
				this.m.writer().writeUTF(mstr[i]);
			}
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004AC RID: 1196 RVA: 0x0007A9F8 File Offset: 0x00078BF8
	public void NextMap(short idMap)
	{
		base.init(34);
		try
		{
			this.m.writer().writeShort(idMap);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004AD RID: 1197 RVA: 0x0007AA3C File Offset: 0x00078C3C
	public void Archi_Daily(sbyte index, sbyte type)
	{
		base.init(37);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeByte(index);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004AE RID: 1198 RVA: 0x0007AA90 File Offset: 0x00078C90
	public void getDataPart(short index)
	{
		base.init(-82);
		try
		{
			this.m.writer().writeShort(index);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004AF RID: 1199 RVA: 0x0007AAD4 File Offset: 0x00078CD4
	public void getDataInfoPotion(short index)
	{
		base.init(-105);
		try
		{
			this.m.writer().writeShort(index);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004B0 RID: 1200 RVA: 0x0007AB18 File Offset: 0x00078D18
	public void EventMoon(short id, sbyte type)
	{
		base.init(41);
		try
		{
			this.m.writer().writeShort(id);
			this.m.writer().writeByte(2);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004B1 RID: 1201 RVA: 0x0007AB6C File Offset: 0x00078D6C
	public static short CheckEmotion(string str)
	{
		if (str.Length >= 3 && str.Substring(0, 2).CompareTo("et") == 0)
		{
			if (str.Length >= 4)
			{
				string text = str.Substring(0, 4);
				if (text.CompareTo("et10") == 0)
				{
					return 30;
				}
				if (text.CompareTo("et11") == 0)
				{
					return 31;
				}
				if (text.CompareTo("et12") == 0)
				{
					return 32;
				}
				if (text.CompareTo("et13") == 0)
				{
					return 33;
				}
				if (text.CompareTo("et14") == 0)
				{
					return 34;
				}
			}
			string text2 = str.Substring(0, 3);
			if (text2.CompareTo("et0") == 0)
			{
				return 20;
			}
			if (text2.CompareTo("et1") == 0)
			{
				return 21;
			}
			if (text2.CompareTo("et2") == 0)
			{
				return 22;
			}
			if (text2.CompareTo("et3") == 0)
			{
				return 23;
			}
			if (text2.CompareTo("et4") == 0)
			{
				return 24;
			}
			if (text2.CompareTo("et5") == 0)
			{
				return 25;
			}
			if (text2.CompareTo("et6") == 0)
			{
				return 26;
			}
			if (text2.CompareTo("et7") == 0)
			{
				return 27;
			}
			if (text2.CompareTo("et8") == 0)
			{
				return 28;
			}
			if (text2.CompareTo("et9") == 0)
			{
				return 29;
			}
		}
		return -1;
	}

	// Token: 0x060004B2 RID: 1202 RVA: 0x0007ACA8 File Offset: 0x00078EA8
	public void Paint_Client(sbyte type, sbyte value)
	{
		base.init(43);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeByte(value);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004B3 RID: 1203 RVA: 0x0007ACFC File Offset: 0x00078EFC
	public void Market(sbyte type, sbyte indexMarket, short ID, sbyte cat, short value)
	{
		base.init(44);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeByte(indexMarket);
			this.m.writer().writeShort(ID);
			this.m.writer().writeByte(cat);
			this.m.writer().writeShort(value);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004B4 RID: 1204 RVA: 0x0007AD84 File Offset: 0x00078F84
	public void checkPlayInMap(mVector vec)
	{
		base.init(46);
		try
		{
			for (int i = 0; i < vec.size(); i++)
			{
				MainObject mainObject = (MainObject)vec.elementAt(i);
				if (mainObject.typeObject == 0)
				{
					this.m.writer().writeShort(mainObject.ID);
				}
			}
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004B5 RID: 1205 RVA: 0x0007ADF0 File Offset: 0x00078FF0
	public void Devil_Upgrade(sbyte action, short idItem, sbyte cat, short num)
	{
		base.init(45);
		try
		{
			this.m.writer().writeByte(action);
			this.m.writer().writeShort(idItem);
			this.m.writer().writeByte(cat);
			this.m.writer().writeShort(num);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004B6 RID: 1206 RVA: 0x0007AE68 File Offset: 0x00079068
	public void cmd_Event(sbyte action)
	{
		base.init(47);
		try
		{
			this.m.writer().writeByte(action);
		}
		catch (Exception)
		{
		}
		base.send();
		mSystem.outz("Send event=" + action.ToString());
	}

	// Token: 0x060004B7 RID: 1207 RVA: 0x0007AEC0 File Offset: 0x000790C0
	public void cmd_TrangTri(sbyte type, sbyte action)
	{
		base.init(75);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeByte(action);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004B8 RID: 1208 RVA: 0x0007AF14 File Offset: 0x00079114
	public void GetTemplate(sbyte type, short value)
	{
		base.init(48);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeShort(value);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004B9 RID: 1209 RVA: 0x0007AF68 File Offset: 0x00079168
	public void One_Point_Max_Level(sbyte action, short id)
	{
		base.init(49);
		try
		{
			this.m.writer().writeByte(action);
			this.m.writer().writeShort(id);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004BA RID: 1210 RVA: 0x0007AFBC File Offset: 0x000791BC
	public void Room_Wanted(sbyte action)
	{
		base.init(-85);
		try
		{
			this.m.writer().writeByte(action);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004BB RID: 1211 RVA: 0x0007B000 File Offset: 0x00079200
	public void Chest_Wanted(sbyte action, short ID)
	{
		base.init(-86);
		try
		{
			this.m.writer().writeByte(action);
			this.m.writer().writeShort(ID);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004BC RID: 1212 RVA: 0x0007B054 File Offset: 0x00079254
	public void Use_Poke(short ID, short IDMon)
	{
		base.init(-87);
		try
		{
			this.m.writer().writeShort(ID);
			this.m.writer().writeShort(IDMon);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004BD RID: 1213 RVA: 0x0000A08B File Offset: 0x0000828B
	public void reDisconectWhy()
	{
		base.init(-84);
		base.send();
	}

	// Token: 0x060004BE RID: 1214 RVA: 0x0007B0A8 File Offset: 0x000792A8
	public void Quick_Chat_LoL(sbyte action, sbyte index, sbyte isCap, string name)
	{
		base.init(51);
		try
		{
			this.m.writer().writeByte(action);
			this.m.writer().writeByte(index);
			this.m.writer().writeByte(isCap);
			this.m.writer().writeUTF(name);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004BF RID: 1215 RVA: 0x0007B120 File Offset: 0x00079320
	public void Quick_Chat_Game(sbyte index)
	{
		base.init(52);
		try
		{
			this.m.writer().writeByte(index);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004C0 RID: 1216 RVA: 0x0007B164 File Offset: 0x00079364
	public void Quayso(sbyte action)
	{
		base.init(54);
		try
		{
			this.m.writer().writeByte(action);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004C1 RID: 1217 RVA: 0x0007B1A8 File Offset: 0x000793A8
	public void QuayWC(sbyte action)
	{
		mSystem.outz("vao nao>>>>>>>>>>> goilen=" + action.ToString());
		base.init(82);
		try
		{
			this.m.writer().writeByte(action);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004C2 RID: 1218 RVA: 0x0007B200 File Offset: 0x00079400
	public void Quay_oc_sen(sbyte action)
	{
		base.init(77);
		try
		{
			this.m.writer().writeByte(action);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004C3 RID: 1219 RVA: 0x0007B244 File Offset: 0x00079444
	public void Huy_hieu(sbyte action, sbyte type, short id)
	{
		mSystem.outz(string.Concat(new string[]
		{
			"QUAY_HUY_HIEU>>>>>>>>>>> goilen=",
			action.ToString(),
			" type = ",
			type.ToString(),
			" id = ",
			id.ToString()
		}));
		base.init(-95);
		try
		{
			this.m.writer().writeByte(action);
			this.m.writer().writeByte(type);
			this.m.writer().writeShort(id);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004C4 RID: 1220 RVA: 0x0007B2F0 File Offset: 0x000794F0
	public void Send_Pet(sbyte action, sbyte type, short id)
	{
		mSystem.outz(string.Concat(new string[]
		{
			"Send_Pet>>>>>>>>>>> goilen=",
			action.ToString(),
			" type = ",
			type.ToString(),
			" id = ",
			id.ToString()
		}));
		base.init(-80);
		try
		{
			this.m.writer().writeByte(action);
			this.m.writer().writeByte(type);
			this.m.writer().writeShort(id);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004C5 RID: 1221 RVA: 0x0007B39C File Offset: 0x0007959C
	public void Send_Pet(sbyte action)
	{
		mSystem.outz("Send_Pet>>>>>>>>>>> goilen=" + action.ToString());
		base.init(-80);
		try
		{
			this.m.writer().writeByte(action);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004C6 RID: 1222 RVA: 0x0007B3F4 File Offset: 0x000795F4
	public void TaiXiu(sbyte type, sbyte action, int tienDatCuoc, sbyte cuaDatCuoc, sbyte isTatTay)
	{
		mSystem.outz(string.Concat(new string[]
		{
			"Tai Xiu >>>>>>>>>>> goilen=",
			action.ToString(),
			" tienDatCuoc = ",
			tienDatCuoc.ToString(),
			" cua = ",
			cuaDatCuoc.ToString()
		}));
		base.init(80);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeByte(action);
			this.m.writer().writeInt(tienDatCuoc);
			this.m.writer().writeByte(cuaDatCuoc);
			this.m.writer().writeByte(isTatTay);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004C7 RID: 1223 RVA: 0x0007B4C4 File Offset: 0x000796C4
	public void TaiXiu(sbyte type, sbyte action)
	{
		mSystem.outz("Tai Xiu >>>>>>>>>>> goilen=" + action.ToString());
		base.init(80);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeByte(action);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004C8 RID: 1224 RVA: 0x0007B52C File Offset: 0x0007972C
	public void VotBanhChung(sbyte type, sbyte action, sbyte status)
	{
		mSystem.outz("Vot banh >>>>>>>>>>> action=" + action.ToString() + " status=" + status.ToString());
		base.init(80);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeByte(action);
			this.m.writer().writeByte(status);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004C9 RID: 1225 RVA: 0x0007B5B4 File Offset: 0x000797B4
	public void Giaotiep_FormServer(sbyte action, short idObj, sbyte cat)
	{
		base.init(59);
		try
		{
			this.m.writer().writeByte(action);
			this.m.writer().writeShort(idObj);
			this.m.writer().writeByte(cat);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004CA RID: 1226 RVA: 0x0007B618 File Offset: 0x00079818
	public void Clan_Fight(sbyte action, short idClan, sbyte typeFight)
	{
		base.init(101);
		try
		{
			this.m.writer().writeByte(action);
			this.m.writer().writeShort(idClan);
			this.m.writer().writeByte(typeFight);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004CB RID: 1227 RVA: 0x0007B67C File Offset: 0x0007987C
	public void Clan_Fight_List_Mem(sbyte action, mVector vec)
	{
		base.init(101);
		try
		{
			this.m.writer().writeByte(action);
			this.m.writer().writeByte(vec.size());
			for (int i = 0; i < vec.size(); i++)
			{
				InfoMemList infoMemList = (InfoMemList)vec.elementAt(i);
				this.m.writer().writeShort(infoMemList.id);
			}
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004CC RID: 1228 RVA: 0x0007B708 File Offset: 0x00079908
	public void Daily_Login(sbyte action)
	{
		base.init(60);
		try
		{
			this.m.writer().writeByte(action);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004CD RID: 1229 RVA: 0x0007B74C File Offset: 0x0007994C
	public void send_GPS()
	{
		base.init(61);
		try
		{
			this.m.writer().writeUTF(GameMidlet.LONG);
			this.m.writer().writeUTF(GameMidlet.LAT);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004CE RID: 1230 RVA: 0x0000A09B File Offset: 0x0000829B
	public void get_Info_Clan_Dao()
	{
		base.init(63);
		base.send();
	}

	// Token: 0x060004CF RID: 1231 RVA: 0x0007B7A8 File Offset: 0x000799A8
	public void Thanh_Toan(string token, string id)
	{
		base.init(99);
		try
		{
			this.m.writer().writeUTF(id);
			this.m.writer().writeUTF(token);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004D0 RID: 1232 RVA: 0x0007B7FC File Offset: 0x000799FC
	public void Upgrade_Super_Item(sbyte type, short idItem, sbyte bery_gem, sbyte num)
	{
		base.init(66);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeShort(idItem);
			this.m.writer().writeByte(bery_gem);
			this.m.writer().writeByte(num);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004D1 RID: 1233 RVA: 0x0007B874 File Offset: 0x00079A74
	public void Upgrade_Dial(sbyte type, short idItem, sbyte bery_gem, sbyte num)
	{
		mSystem.outz(string.Concat(new string[]
		{
			" gui Upgrade dial ",
			type.ToString(),
			" ",
			idItem.ToString(),
			" ",
			bery_gem.ToString(),
			" num = ",
			num.ToString()
		}));
		base.init(-94);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeShort(idItem);
			this.m.writer().writeByte(bery_gem);
			this.m.writer().writeByte(num);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004D2 RID: 1234 RVA: 0x0007B944 File Offset: 0x00079B44
	public void Upgrade_Skin(sbyte type, sbyte cat, short idItem, sbyte posItem, sbyte bovao)
	{
		mSystem.outz(string.Concat(new string[]
		{
			" gui Upgrade skin ",
			type.ToString(),
			" ",
			cat.ToString(),
			" ",
			idItem.ToString(),
			" posItem ",
			posItem.ToString(),
			" ",
			bovao.ToString()
		}));
		base.init(81);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeByte(cat);
			this.m.writer().writeShort(idItem);
			this.m.writer().writeByte(posItem);
			this.m.writer().writeByte(bovao);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004D3 RID: 1235 RVA: 0x0007BA38 File Offset: 0x00079C38
	public void Upgrade_Skin(sbyte type, short idItem)
	{
		mSystem.outz(" gui Upgrade skin  " + idItem.ToString());
		base.init(81);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeShort(idItem);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004D4 RID: 1236 RVA: 0x0007BAA0 File Offset: 0x00079CA0
	public void Upgrade_Skin(sbyte type, mVector listItem)
	{
		mSystem.outz(" gui Upgrade skin size  " + listItem.size().ToString());
		base.init(81);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeByte(listItem.size());
			sbyte b = 0;
			while ((int)b < listItem.size())
			{
				MainItem mainItem = (MainItem)listItem.elementAt((int)b);
				this.m.writer().writeShort(mainItem.ID);
				this.m.writer().writeByte(mainItem.typeObject);
				b += 1;
			}
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004D5 RID: 1237 RVA: 0x0007BB60 File Offset: 0x00079D60
	public void Upgrade_Skin(sbyte type, short idFashion, mVector listItem)
	{
		mSystem.outz(" gui Upgrade skin size  " + listItem.size().ToString() + " idFashion " + idFashion.ToString());
		base.init(81);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeShort(idFashion);
			this.m.writer().writeByte(listItem.size());
			sbyte b = 0;
			while ((int)b < listItem.size())
			{
				MainItem mainItem = (MainItem)listItem.elementAt((int)b);
				this.m.writer().writeShort(mainItem.ID);
				b += 1;
			}
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004D6 RID: 1238 RVA: 0x0007BC28 File Offset: 0x00079E28
	public void Use_Item_BOX_CHOICE(short idItem, sbyte cat, sbyte select)
	{
		base.init(69);
		try
		{
			this.m.writer().writeShort(idItem);
			this.m.writer().writeByte(cat);
			this.m.writer().writeByte(select);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004D7 RID: 1239 RVA: 0x0007BC8C File Offset: 0x00079E8C
	public void Send_Wanted_Poster(sbyte type, short id)
	{
		base.init(-89);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeShort(id);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004D8 RID: 1240 RVA: 0x0007BCE0 File Offset: 0x00079EE0
	public void Send_Wanted_Poster_Action(sbyte type, short id, sbyte action)
	{
		base.init(-89);
		mSystem.outz(string.Concat(new string[]
		{
			"Send wanted action type = ",
			type.ToString(),
			" id ",
			id.ToString(),
			" action ",
			action.ToString()
		}));
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeShort(id);
			this.m.writer().writeByte(action);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004D9 RID: 1241 RVA: 0x0007BD8C File Offset: 0x00079F8C
	public void Send_Nhan_NapTheScr(sbyte type, sbyte id)
	{
		base.init(-90);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeByte(id);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004DA RID: 1242 RVA: 0x0007BDE0 File Offset: 0x00079FE0
	public void Send_Sudo(sbyte type)
	{
		base.init(-108);
		mSystem.outz("SUDO type = " + type.ToString());
		try
		{
			this.m.writer().writeByte(type);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004DB RID: 1243 RVA: 0x0007BE38 File Offset: 0x0007A038
	public void Sudo_CMD(sbyte type, string strChat, int id, sbyte chucvu)
	{
		mSystem.outz(string.Concat(new string[]
		{
			"gời lên Sudo_CMD type=",
			type.ToString(),
			" id=",
			id.ToString(),
			"  name=",
			strChat
		}));
		base.init(-108);
		try
		{
			this.m.writer().writeByte(type);
			if (type == 15 || type == 5 || type == 16 || type == 2 || type == 3)
			{
				this.m.writer().writeUTF(strChat);
				this.m.writer().writeByte(chucvu);
			}
			else if (type == 19 || type == 10 || type == 12)
			{
				this.m.writer().writeInt(id);
			}
			else if (type == 6)
			{
				this.m.writer().writeByte(chucvu);
				this.m.writer().writeByte(id);
			}
			else if (type == 18 || type == 20)
			{
				this.m.writer().writeUTF(strChat);
				this.m.writer().writeInt(id);
			}
			else if (type == 14)
			{
				this.m.writer().writeShort(id);
				this.m.writer().writeByte(chucvu);
			}
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004DC RID: 1244 RVA: 0x0007BF98 File Offset: 0x0007A198
	public void Send_Nhan_TichLuyCongDon(sbyte type, short cost)
	{
		base.init(-97);
		mSystem.outz("TICH_LUY_CONG_DON type = " + type.ToString() + " cost = " + cost.ToString());
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeShort(cost);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004DD RID: 1245 RVA: 0x0007C00C File Offset: 0x0007A20C
	public void Send_Nhan_TichTieuScr(sbyte type, sbyte id)
	{
		base.init(-96);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeByte(id);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004DE RID: 1246 RVA: 0x0007C060 File Offset: 0x0007A260
	public void Send_Type_ID(sbyte cmd, sbyte type, sbyte id)
	{
		base.init(cmd);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeByte(id);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004DF RID: 1247 RVA: 0x0007C0B4 File Offset: 0x0007A2B4
	public void Send_Type(sbyte cmd, sbyte type)
	{
		mSystem.outz("send cmd = " + cmd.ToString() + " type = " + type.ToString());
		base.init(cmd);
		try
		{
			this.m.writer().writeByte(type);
		}
		catch (Exception)
		{
		}
		base.send();
	}

	// Token: 0x060004E1 RID: 1249 RVA: 0x00077C44 File Offset: 0x00075E44
	public static void Autochat()
	{
		while (GameScreen.atchat)
		{
			string text = File.ReadAllText("chat.txt");
			GlobalService.gI().chatPopup(text);
			Thread.Sleep(10000);
		}
	}

	// Token: 0x040006B4 RID: 1716
	public const sbyte DATA_MONSTER = 15;

	// Token: 0x040006B5 RID: 1717
	public const sbyte DATA_POTION = 25;

	// Token: 0x040006B6 RID: 1718
	public const sbyte DATA_NAME_ATTRIBUTES = 2;

	// Token: 0x040006B7 RID: 1719
	public const sbyte DATA_SKILL = 3;

	// Token: 0x040006B8 RID: 1720
	public const sbyte DATA_LOCK_MAP = 4;

	// Token: 0x040006B9 RID: 1721
	public const sbyte DATA_CHAR_PART = 5;

	// Token: 0x040006BA RID: 1722
	public const sbyte DATA_NAME_MAP = 6;

	// Token: 0x040006BB RID: 1723
	public const sbyte DATA_NAME_POTION_QUEST = 7;

	// Token: 0x040006BC RID: 1724
	public const sbyte DATA_SELL_SHOP = 8;

	// Token: 0x040006BD RID: 1725
	public const sbyte DATA_ITEM_MAP = 9;

	// Token: 0x040006BE RID: 1726
	public const sbyte DATA_MAP_LANG = 10;

	// Token: 0x040006BF RID: 1727
	public const sbyte DATA_MATERIAL = 11;

	// Token: 0x040006C0 RID: 1728
	public const sbyte DATA_UPGRADE = 12;

	// Token: 0x040006C1 RID: 1729
	public const sbyte DATA_SEA = 13;

	// Token: 0x040006C2 RID: 1730
	public const sbyte DATA_TILE_CUONGHOA = 19;

	// Token: 0x040006C3 RID: 1731
	public const sbyte DATA_CLOCK_SERVER = 17;

	// Token: 0x040006C4 RID: 1732
	public const sbyte DATA_POTION_CLAN = 18;

	// Token: 0x040006C5 RID: 1733
	public const sbyte DATA_END_TT = 21;

	// Token: 0x040006C6 RID: 1734
	public const sbyte DATA_OFF_NAME = 22;

	// Token: 0x040006C7 RID: 1735
	public const sbyte DATA_PART_IMAGE_NEW = 23;

	// Token: 0x040006C8 RID: 1736
	public const sbyte DATA_POTION_NEW = 24;

	// Token: 0x040006C9 RID: 1737
	public const sbyte DATA_ATTRI_KICH_AN = 26;

	// Token: 0x040006CA RID: 1738
	public const sbyte IS_CHIEM_DAO = 27;

	// Token: 0x040006CB RID: 1739
	public const sbyte UPDATE_DATA_POTION = 28;

	// Token: 0x040006CC RID: 1740
	public const sbyte UP_DATE_DATA_POTION_CLAN = 29;

	// Token: 0x040006CD RID: 1741
	public const sbyte UP_DATE_DATA_SKILL = 30;

	// Token: 0x040006CE RID: 1742
	public const string STRING_MONSTER = "dataMon";

	// Token: 0x040006CF RID: 1743
	public const string STRING_POTION = "dataPotion";

	// Token: 0x040006D0 RID: 1744
	public const string STRING_ATTRI = "dataAttri";

	// Token: 0x040006D1 RID: 1745
	public const string STRING_CHARPART = "dataCharPart";

	// Token: 0x040006D2 RID: 1746
	public const string STRING_NAMEMAP = "dataNameMap";

	// Token: 0x040006D3 RID: 1747
	public const string STRING_NAMEPOTIONQUEST = "dataNamePotionquest";

	// Token: 0x040006D4 RID: 1748
	public const string STRING_ITEMMAP = "dataItemMap";

	// Token: 0x040006D5 RID: 1749
	public const string STRING_IMAGE_SAVE = "dataImageSave";

	// Token: 0x040006D6 RID: 1750
	public const string STRING_DATA_UPGRADE = "dataUpgradeSave";

	// Token: 0x040006D7 RID: 1751
	public const string STRING_POTION_CLAN = "dataPotionClan";

	// Token: 0x040006D8 RID: 1752
	public const sbyte FRIEND_REQUEST = 0;

	// Token: 0x040006D9 RID: 1753
	public const sbyte FRIEND_DEL = 1;

	// Token: 0x040006DA RID: 1754
	public const sbyte FRIEND_LIST = 2;

	// Token: 0x040006DB RID: 1755
	public const sbyte FRIEND_ACCEPT = 3;

	// Token: 0x040006DC RID: 1756
	public const sbyte SET_INVEN_TO_CHEST = 1;

	// Token: 0x040006DD RID: 1757
	public const sbyte GET_CHEST_TO_INVEN = 2;

	// Token: 0x040006DE RID: 1758
	public const sbyte REMOVE_FROM_CHEST = 4;

	// Token: 0x040006DF RID: 1759
	public const sbyte UPGRADE_CHEST = 5;

	// Token: 0x040006E0 RID: 1760
	public const sbyte FIGHT_REQUEST = 0;

	// Token: 0x040006E1 RID: 1761
	public const sbyte FIGHT_ACC = 1;

	// Token: 0x040006E2 RID: 1762
	public const sbyte TYPE_FIGHT_NORMAL = 0;

	// Token: 0x040006E3 RID: 1763
	public const sbyte TYPE_FIGHT_BATTLE = 1;

	// Token: 0x040006E4 RID: 1764
	public const sbyte SHIP_CHANGE = 0;

	// Token: 0x040006E5 RID: 1765
	public const sbyte SHIP_START = 1;

	// Token: 0x040006E6 RID: 1766
	public const sbyte SHIP_ERROR = 2;

	// Token: 0x040006E7 RID: 1767
	public const sbyte CLAN_CHAT_ALL = 0;

	// Token: 0x040006E8 RID: 1768
	public const sbyte CLAN_KICK = 1;

	// Token: 0x040006E9 RID: 1769
	public const sbyte CLAN_DONATE = 2;

	// Token: 0x040006EA RID: 1770
	public const sbyte CLAN_PHONG_CHUC = 3;

	// Token: 0x040006EB RID: 1771
	public const sbyte CLAN_LEAVE = 4;

	// Token: 0x040006EC RID: 1772
	public const sbyte CLAN_STATUS = 5;

	// Token: 0x040006ED RID: 1773
	public const sbyte CLAN_ATTRI = 6;

	// Token: 0x040006EE RID: 1774
	public const sbyte CLAN_ACCEPT_JOIN_CLAN = 7;

	// Token: 0x040006EF RID: 1775
	public const sbyte CLAN_REQUEST_DATA_CLAN = 9;

	// Token: 0x040006F0 RID: 1776
	public const sbyte CLAN_MOI_VAO_CLAN = 10;

	// Token: 0x040006F1 RID: 1777
	public const sbyte CLAN_XIN_VAO_CLAN = 11;

	// Token: 0x040006F2 RID: 1778
	public const sbyte CLAN_NHAN_LOI_MOI = 12;

	// Token: 0x040006F3 RID: 1779
	public const sbyte CLAN_LEVEL_UP = 13;

	// Token: 0x040006F4 RID: 1780
	public const sbyte CLAN_USE_POTION = 14;

	// Token: 0x040006F5 RID: 1781
	public const sbyte CLAN_NAP_TIEN = 15;

	// Token: 0x040006F6 RID: 1782
	public const sbyte CLAN_NO_ACCEPT_JOIN_CLAN = 16;

	// Token: 0x040006F7 RID: 1783
	public const sbyte CLAN_UPDATE_LIST_MEM = 17;

	// Token: 0x040006F8 RID: 1784
	public const sbyte PAINT_HAT = 0;

	// Token: 0x040006F9 RID: 1785
	public const sbyte PAINT_WEAPON_FASHION = 1;

	// Token: 0x040006FA RID: 1786
	public const sbyte MARKET_BUY = 0;

	// Token: 0x040006FB RID: 1787
	public const sbyte MARKET_PAGE = 1;

	// Token: 0x040006FC RID: 1788
	public const sbyte MARKET_OPEN = 2;

	// Token: 0x040006FD RID: 1789
	public const sbyte MARKET_UPDATE = 3;

	// Token: 0x040006FE RID: 1790
	public const sbyte MARKET_SELL = 4;

	// Token: 0x040006FF RID: 1791
	public const sbyte MARKET_SEND_TO_INVEN = 5;

	// Token: 0x04000700 RID: 1792
	public const sbyte MARKET_CANCLE_SELL = 6;

	// Token: 0x04000701 RID: 1793
	public const sbyte MARKET_SELL_CHEST = 7;

	// Token: 0x04000702 RID: 1794
	public const sbyte MARKET_REQUEST_PAGE = 8;

	// Token: 0x04000703 RID: 1795
	public const sbyte MARKET_UPDATE_SHOP_ANY_ITEM = 9;

	// Token: 0x04000704 RID: 1796
	public const sbyte MARKET_SELL_ANY_ITEM_FORM_INVEN = 10;

	// Token: 0x04000705 RID: 1797
	public const sbyte MARKET_SELL_ANY_ITEM_FORM_CHEST = 11;

	// Token: 0x04000706 RID: 1798
	public const sbyte EVENT_MERRY_CM = 0;

	// Token: 0x04000707 RID: 1799
	public const sbyte ACTION_GET_MENU_TRANG_TRI = 0;

	// Token: 0x04000708 RID: 1800
	public const sbyte ACTION_DOI_QUA = 1;

	// Token: 0x04000709 RID: 1801
	public const sbyte ACTION_UPDATE_TRANG_TRI = 2;

	// Token: 0x0400070A RID: 1802
	public const sbyte ACTION_OPEN = 3;

	// Token: 0x0400070B RID: 1803
	public const sbyte ACTION_QUA_THA_TROI = 4;

	// Token: 0x0400070C RID: 1804
	public const sbyte QUAY_1_LAN = 1;

	// Token: 0x0400070D RID: 1805
	public const sbyte QUAY_3_LAN = 2;

	// Token: 0x0400070E RID: 1806
	public const sbyte QUAY_REQUEST = 3;

	// Token: 0x0400070F RID: 1807
	public const sbyte QUAY_BUY = 4;

	// Token: 0x04000710 RID: 1808
	public const sbyte CLAN_FIGHT_REQUEST_LIST_CLAN = 0;

	// Token: 0x04000711 RID: 1809
	public const sbyte CLAN_FIGHT_ACCEPT = 1;

	// Token: 0x04000712 RID: 1810
	public const sbyte CLAN_FIGHT_NO_ACCEPT = 2;

	// Token: 0x04000713 RID: 1811
	public const sbyte CLAN_FIGHT_REQUEST_AUTO = 3;

	// Token: 0x04000714 RID: 1812
	public const sbyte CLAN_FIGHT_ERROR = 4;

	// Token: 0x04000715 RID: 1813
	public const sbyte CLAN_FIGHT_REQUEST_FIGHT_CLAN = 5;

	// Token: 0x04000716 RID: 1814
	public const sbyte CLAN_FIGHT_LIST_MEM_CLAN = 6;

	// Token: 0x04000717 RID: 1815
	public const sbyte SUDO_CHAT_ALL = 15;

	// Token: 0x04000718 RID: 1816
	public const sbyte SUDO_KICK = 16;

	// Token: 0x04000719 RID: 1817
	public const sbyte SUDO_LEAVE = 17;

	// Token: 0x0400071A RID: 1818
	public const sbyte SUDO_ACCEPT_JOIN_CLAN = 18;

	// Token: 0x0400071B RID: 1819
	public const sbyte SUDO_XIN_VAO_CLAN = 19;

	// Token: 0x0400071C RID: 1820
	public const sbyte SUDO_NO_ACCEPT_JOIN_CLAN = 20;

	// Token: 0x0400071D RID: 1821
	protected static GlobalService instance;

	// Token: 0x0400071E RID: 1822
	public static bool isGetMaterial;

	// Token: 0x0400071F RID: 1823
	public static bool isGetKichAn;

	// Token: 0x04000720 RID: 1824
	public static short VerMonster;

	// Token: 0x04000721 RID: 1825
	public static short VerPotion;

	// Token: 0x04000722 RID: 1826
	public static short VerNameAtribute;

	// Token: 0x04000723 RID: 1827
	public static short VerNameMap;

	// Token: 0x04000724 RID: 1828
	public static short VerCharPar;

	// Token: 0x04000725 RID: 1829
	public static short VerNamePotionQuest;

	// Token: 0x04000726 RID: 1830
	public static short VerItemMap;

	// Token: 0x04000727 RID: 1831
	public static short VerImageSave;

	// Token: 0x04000728 RID: 1832
	public static short VerDataUpgrade;

	// Token: 0x04000729 RID: 1833
	public static short verPotionClan;

	// Token: 0x0400072A RID: 1834
	public static bool achat;
}
