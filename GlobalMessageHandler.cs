using System;

// Token: 0x02000039 RID: 57
public class GlobalMessageHandler : Cmd_Message, IMessageHandler
{
	// Token: 0x06000458 RID: 1112 RVA: 0x00077D98 File Offset: 0x00075F98
	public static GlobalMessageHandler gI()
	{
		bool flag = GlobalMessageHandler.me == null;
		if (flag)
		{
			GlobalMessageHandler.me = new GlobalMessageHandler();
		}
		return GlobalMessageHandler.me;
	}

	// Token: 0x06000459 RID: 1113 RVA: 0x00009FAE File Offset: 0x000081AE
	public void setGameLogicHandler(GlobalLogicHandler gI)
	{
		this.globalLogicHandler = gI;
	}

	// Token: 0x0600045A RID: 1114 RVA: 0x00009FB8 File Offset: 0x000081B8
	public void onConnectOK()
	{
		this.globalLogicHandler.onConnectOK();
	}

	// Token: 0x0600045B RID: 1115 RVA: 0x00009FC7 File Offset: 0x000081C7
	public void onConnectionFail()
	{
		this.globalLogicHandler.onConnectFail();
	}

	// Token: 0x0600045C RID: 1116 RVA: 0x00009FD6 File Offset: 0x000081D6
	public void onDisconnected()
	{
		GlobalLogicHandler.onDisconnect();
	}

	// Token: 0x0600045D RID: 1117 RVA: 0x00077DC8 File Offset: 0x00075FC8
	public void onMessage(Message msg)
	{
		switch (msg.command)
		{
		case -108:
			GameCanvas.readMess.Read_Sudo(msg);
			return;
		case -105:
			GameCanvas.readMess.getDataInfoPotion(msg);
			return;
		case -104:
			GameCanvas.readMess.Weapon_fashion(msg);
			return;
		case -103:
			GameCanvas.readMess.registerNew(msg);
			return;
		case -101:
		case -51:
			GameCanvas.readMess.loadImage(msg);
			return;
		case -100:
			GameCanvas.readMess.CMD_test(msg);
			return;
		case -97:
			GameCanvas.readMess.ListTichCongDon(msg);
			return;
		case -96:
			GameCanvas.readMess.ListTichTieu(msg);
			return;
		case -95:
			GameCanvas.readMess.Shop_IconClanVip(msg);
			return;
		case -94:
			GameCanvas.readMess.Upgrade_Dial(msg);
			return;
		case -93:
		case -92:
			GameCanvas.readMess.LoadImageNew(msg);
			return;
		case -91:
			GameCanvas.readMess.ListDauGia(msg);
			return;
		case -90:
			GameCanvas.readMess.ListTichNapThe(msg);
			return;
		case -89:
			GameCanvas.readMess.ListWantedServer(msg);
			return;
		case -88:
			GameCanvas.readMess.DonotAutoReconnect(msg);
			return;
		case -86:
			GameCanvas.readMess.ChestWanted(msg);
			return;
		case -85:
			GameCanvas.readMess.Wanted(msg);
			return;
		case -84:
			GameCanvas.readMess.disconnect_Why(msg);
			return;
		case -83:
			GameCanvas.readMess.update_MP_HP(msg);
			return;
		case -82:
			GameCanvas.readMess.ReadPartNew(msg);
			return;
		case -81:
			GameCanvas.readMess.Input_password(msg);
			return;
		case -80:
			GameCanvas.readMess.Pet(msg);
			return;
		case -79:
			GameCanvas.readMess.little_Garden(msg);
			return;
		case -78:
			GameCanvas.readMess.readAttribute(msg);
			return;
		case -77:
			GameCanvas.readMess.ChuyenHoa(msg);
			return;
		case -75:
			GameCanvas.readMess.UpdateInfoMaincharInfo(msg);
			return;
		case -74:
			GameCanvas.readMess.List_Player_Check(msg);
			return;
		case -73:
			GameCanvas.readMess.TimeShow(msg);
			return;
		case -72:
			GameCanvas.readMess.Red_Line(msg);
			return;
		case -71:
			GameCanvas.readMess.Auto_Revice(msg);
			return;
		case -70:
			GameCanvas.readMess.updateNumPlayerMap(msg);
			return;
		case -69:
			GameCanvas.readMess.Diaolog_time(msg);
			return;
		case -67:
			GameCanvas.readMess.RebuildItem(msg);
			return;
		case -66:
			GameCanvas.readMess.UpdatePvpPoint(msg);
			return;
		case -64:
			GameCanvas.readMess.Buy_Potion_Ok(msg);
			return;
		case -63:
			GameCanvas.readMess.PvP(msg);
			return;
		case -62:
			GameCanvas.readMess.update_Part_Boat(msg);
			return;
		case -61:
			GameCanvas.readMess.CountDown_Ticket(msg);
			return;
		case -60:
			GameCanvas.readMess.Buy_Item_Shop(msg);
			return;
		case -59:
			GameCanvas.readMess.Update_User_Ok(msg);
			return;
		case -58:
			GameCanvas.readMess.Input_server(msg);
			return;
		case -57:
			GameCanvas.readMess.Frist_Login(msg);
			return;
		case -56:
			GameCanvas.readMess.Boat_In_Map(msg);
			return;
		case -55:
			GameCanvas.readMess.ghost(msg);
			return;
		case -54:
			GameCanvas.readMess.Help_From_Server(msg);
			return;
		case -53:
			GameCanvas.readMess.Ship(msg);
			return;
		case -52:
			GameCanvas.readMess.Clan(msg);
			return;
		case -50:
			GameCanvas.readMess.Split_Join_Item(msg);
			return;
		case -49:
			GameCanvas.readMess.Trade(msg);
			return;
		case -48:
			GameCanvas.readMess.Upgrade_Item(msg);
			return;
		case -47:
			GameCanvas.readMess.setWeather(msg);
			return;
		case -45:
			GameCanvas.readMess.update_Pk_Point(msg);
			return;
		case -44:
			GameCanvas.readMess.loadDataEff(msg);
			return;
		case -42:
			GameCanvas.readMess.ShowInfoPlayer(msg);
			return;
		case -41:
			GameCanvas.readMess.resetValueUpdateImage(msg);
			return;
		case -40:
			GameCanvas.readMess.LoadImageAndroidOk(msg);
			return;
		case -39:
			GameCanvas.readMess.SaveImageAndroid(msg);
			return;
		case -37:
			GameCanvas.readMess.Del_Char(msg);
			return;
		case -35:
			GameCanvas.readMess.Fight(msg);
			return;
		case -34:
			GameCanvas.readMess.Open_Box(msg);
			return;
		case -33:
			GameCanvas.readMess.Save_RMS_Server(msg);
			return;
		case -32:
			GameCanvas.readMess.update_Chest(msg);
			return;
		case -31:
			GameCanvas.readMess.Notify_Server(msg);
			return;
		case -30:
			GameCanvas.readMess.ListPlayerServer(msg);
			return;
		case -29:
			GameCanvas.readMess.Friend(msg);
			return;
		case -28:
			GameCanvas.readMess.Learn_Skill(msg);
			return;
		case -26:
			GameCanvas.readMess.Register(msg);
			return;
		case -25:
			GameCanvas.readMess.Party(msg);
			return;
		case -24:
			GameCanvas.readMess.get_Info_NPC(msg);
			return;
		case -23:
			GameCanvas.readMess.List_Quest(msg);
			return;
		case -20:
			GameCanvas.readMess.Dynamic_Menu(msg);
			return;
		case -19:
			GameCanvas.readMess.Shop_NPC(msg);
			return;
		case -15:
			GameCanvas.readMess.Effect_Obj(msg);
			return;
		case -13:
			GameCanvas.readMess.use_Potion(msg);
			return;
		case -12:
			GameCanvas.readMess.update_Inventory(msg);
			return;
		case -11:
			GameCanvas.readMess.Dialog_More_server(msg);
			return;
		case -10:
			GameCanvas.readMess.Main_char_Info(msg);
			return;
		case -7:
			GameCanvas.readMess.getData(msg);
			return;
		case -6:
			GameCanvas.readMess.Check_Data_Ver(msg);
			return;
		case -5:
			GameCanvas.readMess.char_info(msg);
			return;
		case -4:
			GameCanvas.readMess.ListChar(msg);
			return;
		case -2:
			GameCanvas.readMess.login_Ok(msg);
			return;
		case 0:
			GameCanvas.readMess.ChangeMap(msg);
			return;
		case 1:
			GameCanvas.readMess.ObjectMove(msg);
			return;
		case 2:
			GameCanvas.readMess.Fire_Object(msg);
			return;
		case 3:
			GameCanvas.readMess.remove_Char(msg);
			return;
		case 4:
			GameCanvas.readMess.monsterInfo(msg);
			return;
		case 5:
			GameCanvas.readMess.MonsterNoneFocus(msg);
			return;
		case 6:
			GameCanvas.readMess.Revice_Player(msg);
			return;
		case 7:
			GameCanvas.readMess.diePlayer(msg);
			return;
		case 9:
			GameCanvas.readMess.Get_Xp_Map_Train(msg);
			return;
		case 10:
			GameCanvas.readMess.Set_XP(msg);
			return;
		case 11:
			GameCanvas.readMess.Item_Drop(msg);
			return;
		case 12:
			GameCanvas.readMess.GetItemMap(msg);
			return;
		case 13:
			GameCanvas.readMess.remove_Obj(msg);
			return;
		case 14:
			GameCanvas.readMess.update_PK(msg);
			return;
		case 15:
			GameCanvas.readMess.update_List_Pk(msg);
			return;
		case 16:
			GameCanvas.readMess.List_NPC(msg);
			return;
		case 17:
			GameCanvas.readMess.ChatPopup(msg);
			return;
		case 18:
			GameCanvas.readMess.ChatTab(msg);
			return;
		case 19:
			GameCanvas.readMess.charWearing(msg);
			return;
		case 20:
			GameCanvas.readMess.Buff(msg);
			return;
		case 21:
			GameCanvas.readMess.ChangeArea(msg);
			return;
		case 22:
			GameCanvas.readMess.Skill_Map_Train(msg);
			return;
		case 23:
			GameCanvas.readMess.AreaStatus(msg);
			return;
		case 24:
			GameCanvas.readMess.MonsterDie(msg);
			return;
		case 25:
			GameCanvas.readMess.NumItemQuest(msg);
			return;
		case 26:
			GameCanvas.readMess.Teleport_Boss(msg);
			return;
		case 27:
			GameCanvas.readMess.SkillSpec(msg);
			return;
		case 28:
			GameCanvas.readMess.addHP_EffSkill(msg);
			return;
		case 29:
			GameCanvas.readMess.comboSkill(msg);
			return;
		case 30:
			GameCanvas.readMess.Ok_Change_Map_Link(msg);
			return;
		case 31:
			GameCanvas.readMess.UpdateNameNPC(msg);
			return;
		case 32:
			GameCanvas.readMess.Party_Buff(msg);
			return;
		case 33:
			GameCanvas.readMess.GetItemMapLittle(msg);
			return;
		case 35:
			GameCanvas.readMess.ChangeMapNonData(msg);
			return;
		case 36:
			GameCanvas.readMess.PvP_Thong_Bao(msg);
			return;
		case 37:
			GameCanvas.readMess.Archi_Daily(msg);
			return;
		case 38:
			GameCanvas.readMess.Table_Match(msg);
			return;
		case 39:
			GameCanvas.readMess.updateXP_Arena(msg);
			return;
		case 40:
			GameCanvas.readMess.NewDialog(msg);
			return;
		case 41:
			GameCanvas.readMess.TypeNpcEvent(msg);
			return;
		case 42:
			GameCanvas.readMess.TimeItemDrop(msg);
			return;
		case 44:
			GameCanvas.readMess.Market(msg);
			return;
		case 45:
			GameCanvas.readMess.upgradeDevil(msg);
			return;
		case 47:
			GameCanvas.readMess.cmdEvent(msg);
			return;
		case 48:
			GameCanvas.readMess.getTemplate(msg);
			return;
		case 49:
			GameCanvas.readMess.Max_Level(msg);
			return;
		case 50:
			GameCanvas.readMess.OpenMessenger(msg);
			return;
		case 51:
			GameCanvas.readMess.UpdateLoL(msg);
			return;
		case 52:
			GameCanvas.readMess.QuickChat(msg);
			return;
		case 53:
			GameCanvas.readMess.updatePoint_WorldWar(msg);
			return;
		case 54:
			GameCanvas.readMess.Quay_So(msg);
			return;
		case 55:
			GameCanvas.readMess.update_MP_HP_Eff(msg);
			return;
		case 57:
			GameCanvas.readMess.Eff_Kich_An(msg);
			return;
		case 58:
			GameCanvas.readMess.Count_Kick_Ava(msg);
			return;
		case 59:
			GameCanvas.readMess.GiaoTiep_FormServer(msg);
			return;
		case 60:
			GameCanvas.readMess.daily_Bonus(msg);
			return;
		case 61:
			GameCanvas.readMess.gps(msg);
			return;
		case 62:
			GameCanvas.readMess.getDamList(msg);
			return;
		case 63:
			GameCanvas.readMess.getInfoClanDao(msg);
			return;
		case 64:
			GameCanvas.readMess.listGiftArea(msg);
			return;
		case 65:
			GameCanvas.readMess.getThanhTich(msg);
			return;
		case 66:
			GameCanvas.readMess.UpgradeSuper_Item(msg);
			return;
		case 67:
			GameCanvas.readMess.title_Map_Fight(msg);
			return;
		case 69:
			GameCanvas.readMess.Potion_Choice(msg);
			return;
		case 70:
			GameCanvas.readMess.Set_XP_Skill(msg);
			return;
		case 71:
			GameCanvas.readMess.ReadTrongCay(msg);
			return;
		case 72:
			GameCanvas.readMess.infoFashion(msg);
			return;
		case 73:
			GameCanvas.readMess.vongsinhtu(msg);
			return;
		case 74:
		case 76:
			GameCanvas.readMess.getDataEff(msg);
			return;
		case 75:
			GameCanvas.readMess.ReadEventTrangTri(msg);
			return;
		case 77:
			GameCanvas.readMess.Quay_oc_sen(msg);
			return;
		case 79:
			GameCanvas.readMess.Hanh_Trinh(msg);
			return;
		case 80:
			GameCanvas.readMess.Event(msg);
			return;
		case 81:
			GameCanvas.readMess.Upgrade_Skin(msg);
			return;
		case 82:
			GameCanvas.readMess.Quay_WC(msg);
			return;
		case 99:
			GameCanvas.readMess.Thanh_Toan(msg);
			return;
		case 100:
			GameCanvas.readMess.Fire_Object_NEW(msg);
			return;
		case 101:
			GameCanvas.readMess.Clan_Fight(msg);
			return;
		}
		mSystem.outz(">>>>>>>>client k co cmd=" + msg.command.ToString());
	}

	// Token: 0x040006B1 RID: 1713
	public GlobalLogicHandler globalLogicHandler = new GlobalLogicHandler();

	// Token: 0x040006B2 RID: 1714
	public static GlobalMessageHandler me;

	// Token: 0x040006B3 RID: 1715
	public IMiniGameMsgHandler miniGameMessageHandler;
}
