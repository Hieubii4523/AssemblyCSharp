using System;
using System.IO;
using System.Threading;

// Token: 0x02000037 RID: 55
public class GameScreen : MainScreen
{
	// Token: 0x06000401 RID: 1025 RVA: 0x000737B4 File Offset: 0x000719B4
	public GameScreen()
	{
		this.cmdNextFocus = new iCommand(T.next, 0, this);
		this.cmdHoiSinh = new iCommand(T.revice, 1, this);
		this.cmdVeLang = new iCommand(T.gohome, 2, 0, this);
		this.cmdGetXpMapTrain = new iCommand(T.getXp, 3, 1, this);
		this.cmdThoatFormMapTrain = new iCommand(T.exit, 27, 2, this);
		this.cmdInfoPlayer = new iCommand(T.info, 28, this);
		this.cmdInfoMe = new iCommand(T.menu, 6, 0, this);
		this.cmdSetPk = new iCommand(T.Pk, 7, 0, this);
		this.cmdSetDosat = new iCommand(T.Dosat, 8, 0, this);
		GameScreen.cmdGiaoTiep = new iCommand(T.Giaotiep, 9, 0, this);
		this.cmdParty = new iCommand(T.party, 10, 0, this);
		this.cmdInviteParty = new iCommand(T.cmdloimoiParty, 11, 0, this);
		GameScreen.cmdReConnect = new iCommand(T.again, 12, 0, this);
		this.cmdLogOut = new iCommand(T.logout, 13, 0, this);
		this.cmdExit = new iCommand(T.exit, 13, 0, this);
		this.cmdTrochuyen = new iCommand(T.TroChuyen, 14, 0, this);
		this.cmdChatPlayer = new iCommand(T.TroChuyen, 15, 0, this);
		this.cmdAuto = new iCommand(T.setting, 16, 0, this);
		this.cmdChatPopup = new iCommand(T.chat, 17, 0, this);
		this.cmdAddFriend = new iCommand(T.addFriend, 20, this);
		this.cmdFriendList = new iCommand(T.friendList, 21, this);
		this.cmdBlackList = new iCommand(T.blackList, 22, this);
		this.cmdEvent = new iCommand(T.cmdEvent, 23, this);
		this.cmdEvent.hardcodeEvent = true;
		this.cmdChangeTouch = new iCommand(T.keypad, 24, this);
		this.cmdFight = new iCommand(T.fight, 26, this);
		this.cmdSettingView = new iCommand(T.setting, 29, this);
		if (GameCanvas.isTouch)
		{
			this.cmdSettingView = AvMain.setPosCMD(this.cmdSettingView, 1);
		}
		this.cmdExitView = new iCommand(T.exit, 30, this);
		this.cmdShowWC = new iCommand(T.WorldChanel, 33, this);
		this.cmdInviteTrade = new iCommand(T.trade, 35, this);
		this.cmdBuyGem = new iCommand(T.cmdBuy + " " + T.ruby, 36, this);
		this.cmdSendSerial_Mathe = new iCommand(T.napthe, 37, this);
		this.cmdHoiExit = new iCommand(T.exit, 38, this);
		this.cmdMenuPk = new iCommand(T.chonco, 39, this);
		this.cmdClan = new iCommand(T.Clan, 40, this);
		this.cmdMoiVaoClan = new iCommand(T.moivaoclan, 41, this);
		this.cmdXinVaoClan = new iCommand(T.xinvaoclan, 42, this);
		this.cmdShowName = new iCommand(T.showname, 43, this);
		this.cmdInfoDoithu = new iCommand(T.info, 47, this);
		this.cmdUniform = new iCommand(T.changeEquip, 48, this);
		this.cmdQuickChat = new iCommand(T.quickChat, 49, this);
		this.cmdGiaotiepServer = new iCommand(T.Giaotiep, 52, this);
		this.cmdLockChat = new iCommand("LockChat", 53, this);
		this.cmdShowSkillBuff = new iCommand(T.showSkillBuff, 55, this);
		this.cmdSpam = new iCommand(T.spamSetup, 57, this);
		this.cmdTangRuby = new iCommand(T.tangRuby, 58, this);
		this.cmdDauGia = new iCommand(T.dauGia, 59, this);
		this.cmdShowSkillPlayer = new iCommand(T.showSkillPlayer, 60, this);
		this.cmdShowNhanVat = new iCommand(T.showNhanVat, 61, this);
		GameScreen.cmdVotBanh = new iCommand(T.votBanh, 62, this);
		this.cmdSudo = new iCommand(T.suPhu, 63, this);
		this.cmdBaisu = new iCommand(T.baisu, 64, this);
		this.cmdPet = new iCommand(T.pet, 65, this);
		if (!GameCanvas.isTouch)
		{
			this.right = this.cmdNextFocus;
			this.left = this.cmdInfoMe;
		}
		if (GameMidlet.DEVICE == 0)
		{
			new Effect_Skill();
		}
	}

	// Token: 0x06000402 RID: 1026 RVA: 0x00073C3C File Offset: 0x00071E3C
	public override void Show()
	{
		GameCanvas.gameScr.left = null;
		GameCanvas.gameScr.right = null;
		GameCanvas.gameScr.center = null;
		Interface_Game.timeShowNear = 0;
		base.Show();
		GameCanvas.mapLogin = null;
		this.setTypeViewPlayer(GameScreen.typeViewPlayer);
		GameScreen.vecEffOnMap.removeAllElements();
		if (GameCanvas.loadmap.mapLang())
		{
			if (Player.isAutoMaterial == 1 || Player.isAutoMaterial == 3)
			{
				Player.SetMaterialToChest(7);
			}
			if (Player.isAutoMaterial == 2 || Player.isAutoMaterial == 3)
			{
				Player.SetDiamondToChest();
			}
		}
		this.cmdInfoDoithu = null;
		GameScreen.setNumMess();
		Clan_Screen.isNew = false;
		this.setNewEventCLan();
	}

	// Token: 0x06000403 RID: 1027 RVA: 0x00009D23 File Offset: 0x00007F23
	public void setNauBanh(bool isNauBanh)
	{
		GameScreen.player.isNauBanh = isNauBanh;
		GameScreen.player.tickNauBanh = 0;
		if (isNauBanh)
		{
			this.center = GameScreen.cmdVotBanh;
			return;
		}
		this.center = null;
	}

	// Token: 0x06000404 RID: 1028 RVA: 0x00009D51 File Offset: 0x00007F51
	public override void setxyPlus12()
	{
		GameCanvas.xPlus12 = 2;
		GameCanvas.yPlus12 = 2;
	}

	// Token: 0x06000405 RID: 1029 RVA: 0x00073CE0 File Offset: 0x00071EE0
	private void setNewEventCLan()
	{
		if (GameScreen.player.clan != null && GameCanvas.ClanScr != null)
		{
			for (int i = 0; i < GameCanvas.ClanScr.vecTabChat.size(); i++)
			{
				if (((ChatDetail)GameCanvas.ClanScr.vecTabChat.elementAt(i)).isNew)
				{
					Clan_Screen.isNew = true;
					return;
				}
			}
		}
	}

	// Token: 0x06000406 RID: 1030 RVA: 0x00073D40 File Offset: 0x00071F40
	public static void setNumMess()
	{
		GameScreen.numMess = 0;
		if (GameCanvas.eventScr != null && GameCanvas.eventScr.vecPlayer != null)
		{
			for (int i = 0; i < GameCanvas.eventScr.vecPlayer.size(); i++)
			{
				if (((InfoMemList)GameCanvas.eventScr.vecPlayer.elementAt(i)).isNew)
				{
					GameScreen.numMess++;
				}
			}
		}
	}

	// Token: 0x06000407 RID: 1031 RVA: 0x00073DA8 File Offset: 0x00071FA8
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
			if (GameScreen.objFocus != null && !GameScreen.objFocus.returnAction())
			{
				GameScreen.player.nextFocus();
				return;
			}
			break;
		case 1:
			this.setRevice();
			return;
		case 2:
			switch (subIndex)
			{
			case 0:
				GameCanvas.Start_Normal_DiaLog(T.hoiGoHome, new iCommand(T.gohome, 2, 2, this), true);
				return;
			case 1:
				GlobalService.gI().Player_Revice(1);
				GameCanvas.end_Dialog();
				return;
			case 2:
				GlobalService.gI().Player_Revice(0);
				GameCanvas.end_Dialog();
				return;
			default:
				return;
			}
			break;
		case 3:
			GlobalService.gI().Get_Xp_Map_Train((sbyte)subIndex);
			return;
		case 4:
			GameCanvas.menu.startAt(this.getMenu(), 2, T.menu);
			return;
		case 5:
			GlobalService.gI().Set_PK((sbyte)subIndex, 0);
			GameCanvas.end_Dialog();
			return;
		case 6:
			GlobalService.gI().Update_Pk_Point();
			GameCanvas.tabInven.setTypeInven(0);
			GameCanvas.tabAllScr.Show(this);
			GameScreen.player.resetAction();
			GameCanvas.clearAll();
			if (GameScreen.indexHelp == 10 || GameScreen.indexHelp == 14 || GameScreen.indexHelp == 15 || GameScreen.indexHelp == 16)
			{
				MainHelp.setNextHelp(true);
				return;
			}
			break;
		case 7:
		{
			if (GameScreen.player.Hp <= 0)
			{
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.trongthuong);
				return;
			}
			mVector mVector = new mVector();
			for (int i = -1; i < 6; i++)
			{
				iCommand iCommand;
				if (i == -1)
				{
					iCommand = new iCommand(T.thaoco, 5, -1, this);
				}
				else
				{
					iCommand = new iCommand(T.mTypePk[3 + i], 5, 3 + i, this);
					iCommand.setFraCaption(AvMain.fraPk, 3, (3 + i) * 3, 0);
				}
				mVector.addElement(iCommand);
			}
			GameCanvas.menu.startAt(mVector, 2, T.Pk);
			return;
		}
		case 8:
			if (GameScreen.player.Hp <= 0)
			{
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.trongthuong);
				return;
			}
			if (GameScreen.player.typePK == 0)
			{
				GlobalService.gI().Set_PK(-1, 0);
				Interface_Game.addInfoPlayerNormal(T.tatdosat, mFont.tahoma_7_yellow);
				return;
			}
			GlobalService.gI().Set_PK(0, 0);
			Interface_Game.addInfoPlayerNormal(T.batdosat, mFont.tahoma_7_yellow);
			return;
		case 9:
			if (GameScreen.objFocus != null)
			{
				GameScreen.objFocus.Giaotiep();
				return;
			}
			break;
		case 10:
			if (Player.vecParty.size() > 0)
			{
				PartyScreen.gI().setCamera();
				PartyScreen.gI().Show(GameCanvas.gameScr);
				return;
			}
			break;
		case 11:
			if (GameScreen.objGiaotiep != null)
			{
				GlobalService.gI().Party(0, GameScreen.objGiaotiep.ID);
				return;
			}
			break;
		case 12:
			GameCanvas.loginScr.Show();
			if (GameCanvas.loginScr.tfUser.getText().Length > 0)
			{
				mSystem.outz("5");
				GameCanvas.loginScr.doLogin(false, 0, GameCanvas.loginScr.tfUser.getText(), GameCanvas.loginScr.tfPass.getText());
				return;
			}
			GameCanvas.fristLoginScr.cmdBegin.perform();
			return;
		case 13:
			ListChar_Screen.IndexCharSelected = -1;
			GameCanvas.loginScr.Show();
			return;
		case 14:
			GameCanvas.chatTabScr.Show(GameCanvas.gameScr);
			return;
		case 15:
			if (GameScreen.objGiaotiep != null)
			{
				this.ShowChatTab(GameScreen.objGiaotiep.name);
				return;
			}
			break;
		case 16:
		{
			mVector menuGameNew = this.getMenuGameNew();
			GameCanvas.menu.startAt(menuGameNew, 2, T.setting);
			return;
		}
		case 17:
			if (GameCanvas.currentScreen == this && !GameCanvas.menuCur.isShowMenu && GameCanvas.currentDialog == null && !Player.isGhost)
			{
				ChatTextField.gI().setChat();
				return;
			}
			break;
		case 18:
		{
			if (Player.isMPHP)
			{
				Player.isMPHP = false;
				GameCanvas.saveRms.SaveAutoMp_Hp();
				this.setCaptionCmdAutoGetItem();
				return;
			}
			MsgAutoMPHP msgAutoMPHP = new MsgAutoMPHP();
			msgAutoMPHP.setinfoAuto_MP_HP();
			GameCanvas.Start_Current_Dialog(msgAutoMPHP);
			return;
		}
		case 19:
		{
			MsgAutoFire msgAutoFire = new MsgAutoFire();
			msgAutoFire.setinfoAuto_Fire();
			GameCanvas.Start_Current_Dialog(msgAutoFire);
			return;
		}
		case 20:
			if (GameScreen.objGiaotiep != null)
			{
				GlobalService.gI().Friend(0, (int)GameScreen.objGiaotiep.ID);
				return;
			}
			break;
		case 21:
			if (FriendList.isGetListFriend)
			{
				FriendList.gI().Show(this);
				return;
			}
			GlobalService.gI().Friend(2, 0);
			return;
		case 22:
			GlobalService.gI().ListFromServer(2, 2, 0);
			return;
		case 23:
			GameCanvas.eventScr.Show(this);
			return;
		case 24:
			if (Interface_Game.typeTouch == 0)
			{
				Interface_Game.typeTouch = 1;
			}
			else
			{
				Interface_Game.typeTouch = 0;
			}
			this.cmdChangeTouch.caption = T.keypad;
			if (Interface_Game.typeTouch == 0)
			{
				this.cmdChangeTouch.caption = T.touch;
				Interface_Game.addInfoPlayerNormal(T.chuyenkeypad, mFont.tahoma_7_yellow);
			}
			else
			{
				Interface_Game.addInfoPlayerNormal(T.chuyentouch, mFont.tahoma_7_yellow);
			}
			try
			{
				CRes.saveRMS("SUB_TYPETOUCH", new sbyte[]
				{
					Interface_Game.typeTouch
				});
			}
			catch (Exception)
			{
			}
			GameScreen.interfaceGame.setPosSkill();
			Interface_Game.setPosTouch();
			return;
		case 25:
		{
			if (Player.isGetItem)
			{
				Player.isGetItem = false;
				GameCanvas.saveRms.SaveAutoGetItem();
				this.setCaptionCmdAutoGetItem();
				return;
			}
			MsgAutoGetItem msgAutoGetItem = new MsgAutoGetItem();
			msgAutoGetItem.setinfoAuto_Get_Item();
			GameCanvas.Start_Current_Dialog(msgAutoGetItem);
			return;
		}
		case 26:
		{
			mVector mVector2 = new mVector();
			mVector2.addElement(new iCommand(T.giaohuu, 54, 0, this));
			mVector2.addElement(new iCommand(T.thachdau, 54, 1, this));
			GameCanvas.menu.startAt(mVector2, 2, T.fight);
			return;
		}
		case 27:
			GameCanvas.Start_Normal_DiaLog(T.hoiThoatMapTrain, this.cmdLogOut, true);
			return;
		case 28:
			if (GameScreen.objGiaotiep != null)
			{
				this.ShowInfoOtherPlayer(GameScreen.objGiaotiep.name);
				return;
			}
			break;
		case 29:
			if (GameScreen.typeViewPlayer != 0)
			{
				this.doMenuSettingView();
				return;
			}
			break;
		case 30:
			if (GameScreen.typeViewPlayer != 0)
			{
				GlobalService.gI().Exit_View();
				return;
			}
			break;
		case 31:
			GameScreen.objView = MainObject.get_Object(subIndex, 0);
			return;
		case 32:
			GameScreen.objView = null;
			return;
		case 33:
			if (this.input == null)
			{
				this.input = new InputDialog();
				iCommand cmd = new iCommand(T.chat, 34, this);
				this.input.setinfo(T.nhapNoiDung, cmd, false, T.WorldChanel);
			}
			else
			{
				this.input.tfInput.setText(string.Empty);
			}
			GameCanvas.Start_Current_Dialog(this.input);
			return;
		case 34:
			GlobalService.gI().World_Chanel(0, this.input.tfInput.getText());
			return;
		case 35:
			if (GameScreen.objGiaotiep != null)
			{
				GlobalService.gI().Trade(6, GameScreen.objGiaotiep.ID, GameScreen.objGiaotiep.typeObject, 0, string.Empty);
				return;
			}
			break;
		case 36:
			if (GameCanvas.isDeviceStore() && GameMidlet.DEVICE != 4)
			{
				this.Open_Nap_Store();
				return;
			}
			this.Open_Dialog_Nap();
			return;
		case 37:
			if (this.input.mtfInput != null)
			{
				string[] array = new string[this.input.mtfInput.Length];
				for (int j = 0; j < this.input.mtfInput.Length; j++)
				{
					array[j] = this.input.mtfInput[j].getText();
				}
				if (array.Length >= 2)
				{
					GlobalService.gI().Buy_Gem(array[0], array[1]);
				}
			}
			GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.dangnapthe);
			return;
		case 38:
			GameCanvas.Start_Normal_DiaLog(T.doitaikhoan, this.cmdExit, true);
			return;
		case 39:
		{
			mVector mVector3 = new mVector();
			mVector3.addElement(GameCanvas.gameScr.cmdSetPk);
			mVector3.addElement(GameCanvas.gameScr.cmdSetDosat);
			GameCanvas.menu.startAt(mVector3, 2, T.chonco);
			return;
		}
		case 40:
			if (Player.isGetDataClan != 1)
			{
				GlobalService.gI().Clan_CMD(9, string.Empty, 0, 0);
				GameCanvas.Start_Waiting_DiaLog(T.pleaseWaiting, true);
				Player.isGetDataClan = 0;
				return;
			}
			if (GameScreen.player.clan != null)
			{
				if (GameCanvas.ClanScr == null)
				{
					GameCanvas.ClanScr = new Clan_Screen(GameScreen.player.clan);
				}
				GameCanvas.ClanScr.Show(this);
				return;
			}
			break;
		case 41:
			if (GameScreen.objGiaotiep != null)
			{
				GlobalService.gI().Clan_CMD(10, string.Empty, (int)GameScreen.objGiaotiep.ID, 0);
				return;
			}
			break;
		case 42:
			if (GameScreen.objGiaotiep != null && GameScreen.objGiaotiep.clan != null)
			{
				GlobalService.gI().Clan_CMD(11, string.Empty, (int)GameScreen.objFocus.clan.ID, 0);
				return;
			}
			break;
		case 43:
			GameScreen.isShowNameSetting = !GameScreen.isShowNameSetting;
			return;
		case 44:
			GlobalService.gI().Paint_Client(0, (sbyte)subIndex);
			return;
		case 45:
			GlobalService.gI().Paint_Client(1, (sbyte)subIndex);
			return;
		case 46:
		{
			string text = string.Empty;
			try
			{
				text = GameMidlet.connectHTTP(GameMidlet.getThongBao());
			}
			catch (Exception)
			{
			}
			if (text != null && text.Length > 10)
			{
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(text);
				return;
			}
			GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.connectfail);
			return;
		}
		case 47:
			for (int k = 0; k < GameScreen.vecPlayers.size(); k++)
			{
				MainObject mainObject = (MainObject)GameScreen.vecPlayers.elementAt(k);
				if (mainObject != GameScreen.player)
				{
					this.ShowInfoOtherPlayer(mainObject.name);
					return;
				}
			}
			return;
		case 48:
			if (Player.vecUniform.size() == 0)
			{
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.noneUniform);
				return;
			}
			if (Player.vecUniform.size() == 1)
			{
				for (int l = 0; l < Player.vecUniform.size(); l++)
				{
					((Uniform)Player.vecUniform.elementAt(l)).getUniform();
				}
				return;
			}
			for (int m = 0; m < Player.vecUniform.size(); m++)
			{
				Uniform uniform = (Uniform)Player.vecUniform.elementAt(m);
				if (uniform.isSet == 0)
				{
					uniform.getUniform();
				}
				else
				{
					uniform.isSet = 0;
				}
			}
			return;
		case 49:
		{
			mVector menuItems = (LoadMap.specMap != 10) ? this.getVecQuickChatGame() : this.getVecQuickChatLOL();
			GameCanvas.menu.startAt(menuItems, 2, T.quickChat);
			return;
		}
		case 50:
		{
			sbyte b = 3;
			if (Player.ChucInCLan == 0)
			{
				b = 4;
			}
			GlobalService.gI().Quick_Chat_LoL(2, (sbyte)subIndex, b, GameScreen.player.name);
			InfoShowNotify o = new InfoShowNotify(GameScreen.player.name + ": " + T.mChatInLoL[subIndex], b);
			Interface_Game.vecQuickChatLoL.insertElementAt(o, 0);
			return;
		}
		case 51:
			if (subIndex >= 0 && subIndex < T.mChatInGame.Length)
			{
				GameScreen.player.strChatPopup = T.mChatInGame[subIndex];
				GlobalService.gI().chatPopup(T.mChatInGame[subIndex]);
				return;
			}
			break;
		case 52:
			if (GameScreen.objGiaotiep != null)
			{
				GlobalService.gI().Giaotiep_FormServer(ReadMessenge.ID_GiaoTiep_Server, GameScreen.objGiaotiep.ID, GameScreen.objGiaotiep.typeObject);
				return;
			}
			break;
		case 53:
			if (GameScreen.objGiaotiep != null)
			{
				GlobalService.gI().chatPopup("ops lockchat " + GameScreen.objGiaotiep.name);
				return;
			}
			break;
		case 54:
			if (GameScreen.objGiaotiep != null)
			{
				GlobalService.gI().Fight(0, GameScreen.objGiaotiep.ID, (sbyte)subIndex);
				return;
			}
			break;
		case 55:
			GameScreen.isShowSkillBuff = !GameScreen.isShowSkillBuff;
			GameCanvas.saveRms.SaveShowSkillBuff();
			return;
		case 56:
			if (subIndex >= 0 && subIndex < GameMidlet.google_productIds.Length)
			{
				GameMidlet.makePurchase(GameMidlet.google_productIds[subIndex]);
				return;
			}
			break;
		case 57:
		{
			MsgSpamSetup msgSpamSetup = new MsgSpamSetup();
			msgSpamSetup.setinfo();
			GameCanvas.Start_Sub_Dialog(msgSpamSetup);
			return;
		}
		case 58:
			if (GameScreen.objGiaotiep != null)
			{
				GlobalService.gI().Giaotiep_FormServer(2, GameScreen.objGiaotiep.ID, GameScreen.objGiaotiep.typeObject);
				return;
			}
			break;
		case 59:
			GlobalService.gI().Send_Type(-91, 0);
			return;
		case 60:
			GameScreen.isShowSkillPlayer = !GameScreen.isShowSkillPlayer;
			return;
		case 61:
			GameScreen.isShowNhanVat = !GameScreen.isShowNhanVat;
			return;
		case 62:
			mSystem.outz("vot banh");
			if (GameScreen.player.tickNauBanh >= 63 && GameScreen.player.tickNauBanh <= 65)
			{
				GlobalService.gI().VotBanhChung(1, 1, 1);
			}
			else if (GameScreen.player.tickNauBanh >= 66 && GameScreen.player.tickNauBanh <= 87)
			{
				GlobalService.gI().VotBanhChung(1, 1, 2);
			}
			else
			{
				GlobalService.gI().VotBanhChung(1, 1, 0);
			}
			GameCanvas.gameScr.setNauBanh(false);
			return;
		case 63:
			GameCanvas.SudoScr = new Sudo_Screen(GameScreen.player.sudo);
			return;
		case 64:
			if (GameScreen.objGiaotiep != null)
			{
				GlobalService.gI().Sudo_CMD(19, string.Empty, (int)GameScreen.objGiaotiep.ID, 0);
				return;
			}
			break;
		case 65:
			GlobalService.gI().Send_Pet(3);
			return;
		default:
			return;
		}
	}

	// Token: 0x06000408 RID: 1032 RVA: 0x00074A3C File Offset: 0x00072C3C
	public void Open_Nap_Store()
	{
		mVector mVector = new mVector();
		for (int i = 0; i < GameMidlet.google_listGems.Length; i++)
		{
			iCommand iCommand = new iCommand(GameMidlet.google_listGems[i], 56, i, this);
			iCommand.setFraCaption(AvMain.fraMoney, 1, 7, 2);
			mVector.addElement(iCommand);
		}
		GameCanvas.menu.startAt(mVector, 2, T.napthe);
	}

	// Token: 0x06000409 RID: 1033 RVA: 0x00009D5F File Offset: 0x00007F5F
	public void Open_Dialog_Nap()
	{
		if (GameCanvas.language == 1)
		{
			GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.danglam);
			return;
		}
		this.input = GameCanvas.Start_Input_Dialog_Server(T.mbuygem, T.napthe, this.cmdSendSerial_Mathe);
		GameCanvas.Start_Current_Dialog(this.input);
	}

	// Token: 0x0600040A RID: 1034 RVA: 0x00074A98 File Offset: 0x00072C98
	private mVector getVecQuickChatLOL()
	{
		mVector mVector = new mVector();
		for (int i = 0; i < T.mChatInLoL.Length; i++)
		{
			iCommand o = new iCommand(T.mChatInLoL[i], 50, i, this);
			mVector.addElement(o);
		}
		return mVector;
	}

	// Token: 0x0600040B RID: 1035 RVA: 0x00074AD8 File Offset: 0x00072CD8
	private mVector getVecQuickChatGame()
	{
		mVector mVector = new mVector();
		for (int i = 0; i < T.mChatInGame.Length; i++)
		{
			iCommand o = new iCommand(T.mChatInGame[i], 51, i, this);
			mVector.addElement(o);
		}
		return mVector;
	}

	// Token: 0x0600040C RID: 1036 RVA: 0x00074B18 File Offset: 0x00072D18
	private mVector getMenuGameNew()
	{
		mVector mVector = new mVector();
		this.cmdGetItem = new iCommand(T.on + T.autoGetItem, 25, this);
		if (Player.isGetItem)
		{
			this.cmdGetItem.caption = T.off + T.autoGetItem;
			this.cmdGetItem.isDonotCloseMenu = true;
		}
		this.cmdMPHP = new iCommand(T.on + T.autoMPHP, 18, this);
		if (Player.isMPHP)
		{
			this.cmdMPHP.caption = T.off + T.autoMPHP;
			this.cmdMPHP.isDonotCloseMenu = true;
		}
		if (GameScreen.isShowNameSetting)
		{
			this.cmdShowName.caption = T.off + T.showname;
		}
		else
		{
			this.cmdShowName.caption = T.on + T.showname;
		}
		iCommand o = new iCommand(T.autoFire, 19, this);
		mVector.addElement(o);
		mVector.addElement(this.cmdMPHP);
		mVector.addElement(this.cmdGetItem);
		mVector.addElement(this.cmdSpam);
		mVector.addElement(this.cmdShowName);
		this.cmdDonotShowHat = new iCommand(T.off + T.showHat, 44, 1, this);
		if (GameScreen.player.isDonotShowHat != 0)
		{
			this.cmdDonotShowHat = new iCommand(T.on + T.showHat, 44, 0, this);
		}
		if (Player.idFashion >= 0)
		{
			this.cmdDonotShowWeaponF = new iCommand(T.off + T.showWeaponF, 45, 1, this);
			if (GameScreen.player.isDonotShowWeaponF != 0)
			{
				this.cmdDonotShowWeaponF = new iCommand(T.on + T.showWeaponF, 45, 0, this);
			}
			mVector.addElement(this.cmdDonotShowWeaponF);
		}
		mVector.addElement(this.cmdDonotShowHat);
		if (GameScreen.isShowSkillBuff)
		{
			this.cmdShowSkillBuff.caption = T.off + T.showSkillBuff;
		}
		else
		{
			this.cmdShowSkillBuff.caption = T.on + T.showSkillBuff;
		}
		mVector.addElement(this.cmdShowSkillBuff);
		if (GameScreen.isShowSkillPlayer)
		{
			this.cmdShowSkillPlayer.caption = T.off + T.showSkillPlayer;
		}
		else
		{
			this.cmdShowSkillPlayer.caption = T.on + T.showSkillPlayer;
		}
		mVector.addElement(this.cmdShowSkillPlayer);
		if (GameScreen.isShowNhanVat)
		{
			this.cmdShowNhanVat.caption = T.off + T.showNhanVat;
		}
		else
		{
			this.cmdShowNhanVat.caption = T.on + T.showNhanVat;
		}
		mVector.addElement(this.cmdShowNhanVat);
		if (GameMidlet.DEVICE > 0)
		{
			mVector.addElement(LoginScreen.cmdSound);
		}
		return mVector;
	}

	// Token: 0x0600040D RID: 1037 RVA: 0x00009D9A File Offset: 0x00007F9A
	private void setCaptionCmdAutoGetItem()
	{
		GameCanvas.menuCur.updateMenuGame(this.getMenuGameNew());
	}

	// Token: 0x0600040E RID: 1038 RVA: 0x00074DE0 File Offset: 0x00072FE0
	private void doMenuSettingView()
	{
		mVector mVector = new mVector();
		iCommand o = new iCommand(T.free, 32, this);
		mVector.addElement(o);
		for (int i = 0; i < GameScreen.vecPlayers.size(); i++)
		{
			MainObject mainObject = (MainObject)GameScreen.vecPlayers.elementAt(i);
			if (mainObject.indexTeam != 0)
			{
				iCommand o2 = new iCommand(T.theo + mainObject.name, 31, (int)mainObject.ID, this);
				mVector.addElement(o2);
			}
		}
		GameCanvas.menu.startAt(mVector, 2, T.camera);
	}

	// Token: 0x0600040F RID: 1039 RVA: 0x00009DAC File Offset: 0x00007FAC
	public override void commandMenu(int index, int subIndex)
	{
	}

	// Token: 0x06000410 RID: 1040 RVA: 0x00074E70 File Offset: 0x00073070
	public mVector getMenu()
	{
		GameScreen.player.resetAction();
		mVector mVector = new mVector();
		mVector.addElement(this.cmdFriendList);
		mVector.addElement(this.cmdBlackList);
		mVector.addElement(this.cmdUniform);
		mVector.addElement(this.cmdQuickChat);
		mVector.addElement(this.cmdSudo);
		mVector.addElement(this.cmdPet);
		mVector.addElement(this.cmdDauGia);
		mVector.addElement(this.cmdEvent);
		mVector.addElement(this.cmdMenuPk);
		if (Player.vecParty.size() > 0)
		{
			mVector.addElement(this.cmdParty);
		}
		if (GameScreen.player.clan != null)
		{
			mVector.addElement(this.cmdClan);
		}
		mVector.addElement(this.cmdTrochuyen);
		mVector.addElement(this.cmdAuto);
		mVector.addElement(this.cmdShowWC);
		mVector.addElement(this.cmdLogOut);
		return mVector;
	}

	// Token: 0x06000411 RID: 1041 RVA: 0x00074F5C File Offset: 0x0007315C
	public void setRevice()
	{
		mVector mVector = new mVector();
		mVector.addElement(new iCommand(T.revice, 2, 1, this));
		mVector.addElement(this.cmdVeLang);
		GameCanvas.Start_Normal_DiaLog(T.hoiRevice, mVector, true);
	}

	// Token: 0x06000412 RID: 1042 RVA: 0x00074F9C File Offset: 0x0007319C
	public override void paint(mGraphics g)
	{
		GameScreen.dx = 0;
		GameScreen.dy = 0;
		if (LoadMap.timeVibrateScreen > 0)
		{
			if (LoadMap.timeVibrateScreen > 100)
			{
				GameScreen.dy = CRes.random_Am_0(3);
				if (LoadMap.timeVibrateScreen == 101)
				{
					LoadMap.timeVibrateScreen = 0;
				}
			}
			else
			{
				GameScreen.dy = CRes.random_Am_0(3);
				GameScreen.dx = CRes.random_Am(0, 2);
			}
			LoadMap.timeVibrateScreen--;
		}
		g.translate(GameScreen.dx, GameScreen.dy);
		g.translate(-MainScreen.cameraMain.xCam, -MainScreen.cameraMain.yCam);
		if (GameScreen.typePaintGameScreen == 0)
		{
			if (LoadMap.isOnlineMap)
			{
				this.paintNormal(g);
			}
			else
			{
				GameScreen.paintMapOffLine(g);
			}
		}
		else
		{
			this.paintSpec(g);
		}
		GameScreen.interfaceGame.paintShowtime(g);
	}

	// Token: 0x06000413 RID: 1043 RVA: 0x00009DAE File Offset: 0x00007FAE
	public static void paintMapOffLine(mGraphics g)
	{
		if (LoadMap.specMap == 5)
		{
			MapOff_RedLine.paintRedLine(g);
		}
		if (LoadMap.specMap == 8)
		{
			MapGotoSky.paint(g);
		}
		if (LoadMap.specMap == 12)
		{
			MapGotoGod.paint(g);
		}
	}

	// Token: 0x06000414 RID: 1044 RVA: 0x00075064 File Offset: 0x00073264
	private void paintSpec(mGraphics g)
	{
		this.paintRectSpec(g);
		for (int i = 0; i < GameScreen.VecEffect.size(); i++)
		{
			MainEffect mainEffect = (MainEffect)GameScreen.VecEffect.elementAt(i);
			if (mainEffect != null && mainEffect.objMainEff != null && mainEffect.objMainEff == GameScreen.player && mainEffect.levelPaint == -1 && !mainEffect.isRemove && !mainEffect.isStop)
			{
				mainEffect.paint(g);
			}
		}
		CRes.quickSort(GameScreen.vecPlayers);
		for (int j = 0; j < GameScreen.vecPlayers.size(); j++)
		{
			MainObject mainObject = (MainObject)GameScreen.vecPlayers.elementAt(j);
			if (!mainObject.isRemove && !mainObject.isStop && (mainObject.isPaintSpec || mainObject == GameScreen.player))
			{
				mainObject.paint(g);
			}
		}
		for (int k = 0; k < GameScreen.VecEffect.size(); k++)
		{
			MainEffect mainEffect2 = (MainEffect)GameScreen.VecEffect.elementAt(k);
			if (mainEffect2 != null && mainEffect2.objMainEff != null && mainEffect2.objMainEff == GameScreen.player && mainEffect2.levelPaint >= 0 && !mainEffect2.isRemove && !mainEffect2.isStop)
			{
				mainEffect2.paint(g);
			}
		}
	}

	// Token: 0x06000415 RID: 1045 RVA: 0x00075198 File Offset: 0x00073398
	public void paintRectSpec(mGraphics g)
	{
		g.setColor(3278096);
		g.fillRect(MainScreen.cameraMain.xCam, MainScreen.cameraMain.yCam, MotherCanvas.w, MotherCanvas.h);
		g.setColor(16079230);
		g.fillRect(MainScreen.cameraMain.xCam, MainScreen.cameraMain.yCam + MotherCanvas.h / 4 * 3 - GameScreen.size, MotherCanvas.w, GameScreen.size * 2);
		g.setColor(16086933);
		g.fillRect(MainScreen.cameraMain.xCam, MainScreen.cameraMain.yCam + MotherCanvas.h / 4 * 3 - GameScreen.size / 2, MotherCanvas.w, GameScreen.size);
		g.setColor(13242941);
		g.fillRect(MainScreen.cameraMain.xCam, MainScreen.cameraMain.yCam + MotherCanvas.h / 4 * 3 - GameScreen.size - 8, MotherCanvas.w, 8);
		g.fillRect(MainScreen.cameraMain.xCam, MainScreen.cameraMain.yCam + MotherCanvas.h / 4 * 3 + GameScreen.size, MotherCanvas.w, 8);
		g.setColor(11538486);
		g.fillRect(MainScreen.cameraMain.xCam, MainScreen.cameraMain.yCam + MotherCanvas.h / 4 * 3 - GameScreen.size - 12, MotherCanvas.w, 4);
		g.fillRect(MainScreen.cameraMain.xCam, MainScreen.cameraMain.yCam + MotherCanvas.h / 4 * 3 + GameScreen.size + 8, MotherCanvas.w, 4);
		g.setColor(15963050);
		for (int i = MotherCanvas.h / 4 * 3 - GameScreen.size - 12; i < MotherCanvas.h / 4 * 3 + GameScreen.size + 12; i += 12)
		{
			g.fillRect(MainScreen.cameraMain.xCam, MainScreen.cameraMain.yCam + i, MotherCanvas.w, 1);
		}
		for (int j = 0; j < GameScreen.vecEffSkillSpec.size(); j++)
		{
			Point point = (Point)GameScreen.vecEffSkillSpec.elementAt(j);
			if (point.dis <= 1)
			{
				g.setColor(point.color);
				g.fillRect(MainScreen.cameraMain.xCam + point.x - point.w / 2, MainScreen.cameraMain.yCam + point.y - point.h / 2, point.w, point.h);
			}
		}
	}

	// Token: 0x06000416 RID: 1046 RVA: 0x00075410 File Offset: 0x00073610
	public void paintNormal(mGraphics g)
	{
		if (GameCanvas.mapBack != null)
		{
			GameCanvas.mapBack.paint(g);
		}
		for (int i = 0; i < GameScreen.vecBigBossLittleGraden.size(); i++)
		{
			((BigBossLittleGraden)GameScreen.vecBigBossLittleGraden.elementAt(i)).paint(g, MainScreen.cameraMain.xCam);
		}
		this.paintTree(g, 0);
		this.paintTree(g, 1);
		GameCanvas.loadmap.paint(g);
		if (this.isFullScreen)
		{
			g.drawRecAlpa(0, 0, GameCanvas.loadmap.mapW * 24, GameCanvas.loadmap.mapH * 24, this.colorRec);
		}
		else if (this.wRec > 0)
		{
			g.fillRecAlpla(this.xRec, this.yRec, this.wRec, this.hRec, this.colorRec);
		}
		if (GameCanvas.mapBack != null)
		{
			GameCanvas.mapBack.paintLast(g);
		}
		if (GameScreen.effSea != null)
		{
			GameScreen.effSea.paintSea(g);
		}
		for (int j = 0; j < GameScreen.vecEffOnMap.size(); j++)
		{
			Point point = (Point)GameScreen.vecEffOnMap.elementAt(j);
			if (point.fSmall == 0)
			{
				AvMain.fraImgEffOnMap0.drawFrame(point.subType * 3 + point.frame, point.x, point.y, point.dis, 3, g);
			}
		}
		Interface_Game.paintMoveTo(g);
		if (LoadMap.specMap == 10 && !GameCanvas.lowGraphic)
		{
			for (int k = 0; k < GameScreen.vecPlayers.size(); k++)
			{
				MainObject mainObject = (MainObject)GameScreen.vecPlayers.elementAt(k);
				if (mainObject.isTru() && !mainObject.isDie)
				{
					if (Interface_Game.imgRankSkill == null)
					{
						Interface_Game.imgRankSkill = mImage.createImage("/interface/lol11.png");
						Interface_Game.imgRankSkill.setWH();
					}
					g.drawRegion(Interface_Game.imgRankSkill, 0, 0, Interface_Game.imgRankSkill.w, Interface_Game.imgRankSkill.h, 0, (float)(mainObject.xAnchor - Interface_Game.imgRankSkill.w / 2), (float)mainObject.yAnchor, 3);
					g.drawRegion(Interface_Game.imgRankSkill, 0, 0, Interface_Game.imgRankSkill.w, Interface_Game.imgRankSkill.h, 2, (float)(mainObject.xAnchor + Interface_Game.imgRankSkill.w / 2), (float)mainObject.yAnchor, 3);
				}
			}
		}
		this.paintTree(g, 2);
		if (GameScreen.isShowSkillPlayer)
		{
			for (int l = 0; l < GameScreen.VecEffect.size(); l++)
			{
				MainEffect mainEffect = (MainEffect)GameScreen.VecEffect.elementAt(l);
				if (mainEffect != null && (GameScreen.isShowSkillPlayer || (mainEffect.objFireMain != null && mainEffect.objFireMain.ID == GameScreen.player.ID)) && mainEffect.levelPaint == -1 && !mainEffect.isRemove && !mainEffect.isStop)
				{
					mainEffect.paint(g);
				}
			}
			for (int m = 0; m < GameScreen.vecHighDataEff.size(); m++)
			{
				DataSkillEff dataSkillEff = (DataSkillEff)GameScreen.vecHighDataEff.elementAt(m);
				if (dataSkillEff != null)
				{
					dataSkillEff.paintBottomEff(g);
				}
			}
		}
		CRes.quickSort(GameScreen.vecPlayers);
		this.nump = 0;
		this.numo = 0;
		this.maxob.y = 10000;
		GameScreen.maxtr.y = 10000;
		while (this.nump < GameScreen.vecPlayers.size() || this.numo < LoadMap.mItemMap[3].size())
		{
			try
			{
				this.ob = this.maxob;
				GameScreen.tr = GameScreen.maxtr;
				if (this.nump < GameScreen.vecPlayers.size())
				{
					this.ob = (MainObject)GameScreen.vecPlayers.elementAt(this.nump);
				}
				if (this.numo < LoadMap.mItemMap[3].size())
				{
					GameScreen.tr = (MainItemMap)LoadMap.mItemMap[3].elementAt(this.numo);
				}
				if (GameScreen.tr == null || (GameScreen.tr.TypeItem != 1 && this.ob.y + this.ob.ysai < GameScreen.tr.y + LoadMap.wTile) || (GameScreen.tr.TypeItem == 1 && this.ob.y + this.ob.ysai < GameScreen.tr.y))
				{
					this.nump++;
					if (GameScreen.tr == null)
					{
						this.numo++;
					}
					if (this.checkPaintLow(this.ob))
					{
						this.ob.paintOnlyShadown(g);
					}
					else if (this.checkPaintOB(this.ob))
					{
						if (this.disLowPaintOnlyShadow(this.ob))
						{
							this.ob.paintOnlyShadown(g);
						}
						else if (this.ob.ID != GameScreen.player.ID && this.ob.typeObject == 0 && !GameScreen.isShowNhanVat)
						{
							this.ob.paintHideAvatar(g);
						}
						else
						{
							this.ob.paint(g);
						}
					}
				}
				else
				{
					this.numo++;
					if (GameScreen.tr.isInScreen())
					{
						GameScreen.tr.paint(g);
					}
				}
			}
			catch (Exception)
			{
			}
		}
		if (GameScreen.effMap != null)
		{
			GameScreen.effMap.paintLast(g);
		}
		for (int n = 0; n < LoadMap.vecPointChange.size(); n++)
		{
			Point point2 = (Point)LoadMap.vecPointChange.elementAt(n);
			g.drawRegion(AvMain.imgSelect, 0, 0, 12, 16, LoadMap.mTranPointChangeMap[point2.dis], (float)(point2.x + GameCanvas.gameTick % 6 * point2.vx), (float)(point2.y + GameCanvas.gameTick % 6 * point2.vy), 3);
			AvMain.Font3dWhite(g, point2.name, point2.x2 + GameCanvas.gameTick % 6 * point2.vx, point2.y2 + GameCanvas.gameTick % 6 * point2.vy, point2.f);
		}
		if (GameScreen.isShowSkillPlayer)
		{
			for (int num = 0; num < GameScreen.VecEffect.size(); num++)
			{
				MainEffect mainEffect2 = (MainEffect)GameScreen.VecEffect.elementAt(num);
				if (mainEffect2 != null && (GameScreen.isShowSkillPlayer || (mainEffect2.objFireMain != null && mainEffect2.objFireMain.ID == GameScreen.player.ID)) && mainEffect2.levelPaint == 0 && !mainEffect2.isRemove && !mainEffect2.isStop)
				{
					mainEffect2.paint(g);
				}
			}
			for (int num2 = 0; num2 < GameScreen.vecHighDataEff.size(); num2++)
			{
				DataSkillEff dataSkillEff2 = (DataSkillEff)GameScreen.vecHighDataEff.elementAt(num2);
				if (dataSkillEff2 != null)
				{
					dataSkillEff2.paintTopEff(g);
				}
			}
			for (int num3 = 0; num3 < GameScreen.VecNum.size(); num3++)
			{
				MainEffect mainEffect3 = (MainEffect)GameScreen.VecNum.elementAt(num3);
				if (mainEffect3 != null && mainEffect3.levelPaint == 0 && !mainEffect3.isRemove && !mainEffect3.isStop)
				{
					mainEffect3.paint(g);
				}
			}
			for (int num4 = 0; num4 < GameScreen.VecNum.size(); num4++)
			{
				MainEffect mainEffect4 = (MainEffect)GameScreen.VecNum.elementAt(num4);
				if (mainEffect4 != null && mainEffect4.levelPaint == 1 && !mainEffect4.isRemove && !mainEffect4.isStop)
				{
					mainEffect4.paint(g);
				}
			}
		}
		if (GameCanvas.showDialog != null)
		{
			GameCanvas.showDialog.paint(g);
		}
		this.paintTree(g, 4);
		this.paintTree(g, 5);
		if (GameScreen.isShowSkillPlayer)
		{
			for (int num5 = 0; num5 < GameScreen.VecEffect.size(); num5++)
			{
				MainEffect mainEffect5 = (MainEffect)GameScreen.VecEffect.elementAt(num5);
				if (mainEffect5 != null && (GameScreen.isShowSkillPlayer || (mainEffect5.objFireMain != null && mainEffect5.objFireMain.ID == GameScreen.player.ID)) && mainEffect5.levelPaint == 1 && !mainEffect5.isRemove && !mainEffect5.isStop)
				{
					mainEffect5.paint(g);
				}
			}
		}
		if (!GameScreen.getIsOffAdmin(1) && GameScreen.objFocus != null && GameScreen.typeViewPlayer == 0)
		{
			if (GameScreen.objFocus.typeObject == 0 || GameScreen.objFocus.typeObject == 2)
			{
				GameScreen.objFocus.paintName(g, GameScreen.objFocus.colorName, 1);
			}
			if (GameScreen.objFocus.Action != 4 && (GameScreen.objFocus.typeObject == 0 || GameScreen.objFocus.typeObject == 1))
			{
				GameScreen.objFocus.paintHPFocus(g);
			}
		}
		if (!GameScreen.getIsOffAdmin(2))
		{
			for (int num6 = 0; num6 < GameScreen.vecPlayers.size(); num6++)
			{
				MainObject mainObject2 = (MainObject)GameScreen.vecPlayers.elementAt(num6);
				if (mainObject2 == GameScreen.player && Player.isGhost)
				{
					Player.paintGhost(g, GameScreen.player.x, GameScreen.player.y - GameScreen.player.hOne);
				}
				else if (mainObject2.chat != null)
				{
					mainObject2.chat.paint(g);
				}
			}
		}
		Interface_Game.paintShowHelp(g, true);
		if (GameCanvas.currentScreen == this)
		{
			if (GameScreen.typeViewPlayer == 0)
			{
				if (LoadMap.specMap != 3 && !GameScreen.getIsOffAdmin(1))
				{
					Interface_Game.paintIconFocus(g);
				}
				GameCanvas.resetTrans(g);
				if (GameCanvas.currentScreen == GameCanvas.gameScr && LoadMap.specMap != 3 && !GameScreen.getIsOffAdmin(1) && !GameCanvas.menuCur.isShowMenu && GameCanvas.currentDialog == null && GameCanvas.subDialog == null)
				{
					Interface_Game.paintNumMess(g, 0, 0);
					GameScreen.interfaceGame.paintInGame(g);
					GameScreen.interfaceGame.paintVecEffKickAn(g);
				}
				if (LoadMap.specMap == 3)
				{
					Interface_Game.PaintLoadData(g, LoadMap.currentXp, LoadMap.maxXp, MotherCanvas.hw - 47, MotherCanvas.h / 8, 100, 12, 15);
					mFont.tahoma_7b_black.drawString(g, Player.strTimeChange, MotherCanvas.hw, MotherCanvas.h / 8 - 10, 2);
				}
				else if (!GameScreen.getIsOffAdmin(1))
				{
					if (!GameScreen.isPvPNew)
					{
						GameScreen.interfaceGame.paintInfoFocus(g);
						bool isborder = true;
						if (GameCanvas.isSmallScreen)
						{
							isborder = false;
						}
						Interface_Game.paintInfoPlayer(g, 3, 3 + GameScreen.h12plus, isborder, mFont.tahoma_7_black);
					}
					else
					{
						Interface_Game.paintPvPNew(g, GameScreen.player, GameScreen.objPvPNew);
					}
				}
			}
			else if (GameCanvas.currentScreen == GameCanvas.gameScr && !GameCanvas.menuCur.isShowMenu && GameCanvas.currentDialog == null)
			{
				GameCanvas.resetTrans(g);
				GameScreen.interfaceGame.paintViewGame(g);
				if (GameCanvas.isTouch)
				{
					base.paintCmd(g);
				}
			}
			GameCanvas.resetTrans(g);
			if (!GameScreen.getIsOffAdmin(1))
			{
				GameScreen.interfaceGame.paintShowNameMap(g);
			}
			if (GameCanvas.currentDialog == null && GameCanvas.subDialog == null && !GameCanvas.menuCur.isShowMenu)
			{
				if (GameCanvas.isTouch)
				{
					base.paintCmd(g);
				}
				else
				{
					base.paintOnlyCaption(g);
				}
			}
			Interface_Game.paintShowNear(g);
			if (Interface_Game.eventcur == null)
			{
				Interface_Game.paintEffShowMoney(g, MotherCanvas.hw - Interface_Game.wMoneyEff / 2, GameScreen.h12plus, false, Interface_Game.typeShowMoney);
			}
			if (!GameScreen.getIsOffAdmin(1))
			{
				for (int num7 = 0; num7 < GameScreen.vecBigBossLittleGraden.size(); num7++)
				{
					((BigBossLittleGraden)GameScreen.vecBigBossLittleGraden.elementAt(num7)).paintINFO(g);
				}
			}
		}
	}

	// Token: 0x06000417 RID: 1047 RVA: 0x00075F60 File Offset: 0x00074160
	public bool disLowPaintOnlyShadow(MainObject obj)
	{
		bool result;
		if (!GameCanvas.isSuperLowGraphic)
		{
			result = false;
		}
		else if (obj == null)
		{
			result = true;
		}
		else if (MainObject.getDistance(GameScreen.player.x, GameScreen.player.y, obj.x, obj.y) >= 120)
		{
			if (obj.demDonotPaint < 20)
			{
				obj.demDonotPaint += 1;
				result = false;
			}
			else
			{
				result = true;
			}
		}
		else
		{
			obj.demDonotPaint = 0;
			result = false;
		}
		return result;
	}

	// Token: 0x06000418 RID: 1048 RVA: 0x00075FD4 File Offset: 0x000741D4
	public bool checkPaintLow(MainObject obj)
	{
		return GameCanvas.lowGraphic && obj != null && (GameScreen.objFocus == null || obj != GameScreen.objFocus) && MainObject.getDistance(obj.x, obj.y, GameScreen.player.x, GameScreen.player.y) >= 120;
	}

	// Token: 0x06000419 RID: 1049 RVA: 0x00009DDB File Offset: 0x00007FDB
	public bool checkPaintOB(MainObject obj)
	{
		return obj != null && (MainObject.isInScreen(obj) || obj.isTru());
	}

	// Token: 0x0600041A RID: 1050 RVA: 0x00076028 File Offset: 0x00074228
	public void paintTree(mGraphics g, int index)
	{
		for (int i = 0; i < LoadMap.mItemMap[index].size(); i++)
		{
			GameScreen.tr = (MainItemMap)LoadMap.mItemMap[index].elementAt(i);
			if (GameScreen.tr.isInScreen())
			{
				GameScreen.tr.paint(g);
			}
		}
	}

	// Token: 0x0600041B RID: 1051 RVA: 0x0007607C File Offset: 0x0007427C
	public void updateOfflineMap()
	{
		if (LoadMap.specMap == 5)
		{
			MapOff_RedLine.updateRedLine();
		}
		if (LoadMap.specMap == 8)
		{
			MapGotoSky.update();
			for (int i = 0; i < GameScreen.vecObjMove.size(); i++)
			{
				ObjMove objMove = (ObjMove)GameScreen.vecObjMove.elementAt(i);
				if (!objMove.isRemove)
				{
					this.updateMoveObj(objMove);
				}
				GameScreen.vecObjMove.removeElementAt(i);
				i--;
			}
		}
		if (LoadMap.specMap == 12)
		{
			MapGotoGod.update();
			for (int j = 0; j < GameScreen.vecObjMove.size(); j++)
			{
				ObjMove objMove2 = (ObjMove)GameScreen.vecObjMove.elementAt(j);
				if (!objMove2.isRemove)
				{
					this.updateMoveObj(objMove2);
				}
				GameScreen.vecObjMove.removeElementAt(j);
				j--;
			}
		}
	}

	// Token: 0x0600041C RID: 1052 RVA: 0x0007613C File Offset: 0x0007433C
	public override void update()
	{
		if (!LoadMap.isOnlineMap)
		{
			this.updateOfflineMap();
			return;
		}
		if (GameCanvas.showDialog != null)
		{
			GameCanvas.showDialog.update();
		}
		for (int i = 0; i < GameScreen.vecBigBossLittleGraden.size(); i++)
		{
			((BigBossLittleGraden)GameScreen.vecBigBossLittleGraden.elementAt(i)).update();
		}
		if (Interface_Game.timeShowNear > -5)
		{
			Interface_Game.updateShowNear();
		}
		if (GameCanvas.mapBack != null)
		{
			GameCanvas.mapBack.updateCloud();
			GameCanvas.mapBack.update();
		}
		for (int j = 0; j < LoadMap.mItemMap[3].size(); j++)
		{
			MainItemMap mainItemMap = (MainItemMap)LoadMap.mItemMap[3].elementAt(j);
			if (mainItemMap.TypeItem == 1 || mainItemMap.TypeItem == 1)
			{
				mainItemMap.update();
			}
		}
		for (int k = 0; k < GameScreen.vecObjMove.size(); k++)
		{
			ObjMove objMove = (ObjMove)GameScreen.vecObjMove.elementAt(k);
			if (!objMove.isRemove)
			{
				this.updateMoveObj(objMove);
			}
			GameScreen.vecObjMove.removeElementAt(k);
			k--;
		}
		this.readVecFire();
		for (int l = 0; l < GameScreen.vecPlayers.size(); l++)
		{
			MainObject mainObject = (MainObject)GameScreen.vecPlayers.elementAt(l);
			if (mainObject == null || mainObject.isRemove)
			{
				if (GameCanvas.lowGraphic)
				{
					GameScreen.vecPlayers.removeElementAt(l);
					l--;
				}
				else if (mainObject == null || mainObject.timeEffRemoveChar <= 0)
				{
					GameScreen.vecPlayers.removeElementAt(l);
					l--;
				}
				else
				{
					mainObject.timeEffRemoveChar--;
					mainObject.update();
					mainObject.ySort = mainObject.y + mainObject.ysai;
				}
			}
			else
			{
				mainObject.update();
				mainObject.ySort = mainObject.y + mainObject.ysai;
				if (mainObject.typeObject == 0)
				{
					if (this.checkPaintOB(mainObject))
					{
						mainObject.timeOutScreen = 0;
					}
					else
					{
						mainObject.timeOutScreen++;
						if (mainObject.timeOutScreen >= 1000)
						{
							mainObject.isRemove = true;
						}
					}
					if (GameScreen.isPvPNew && mainObject != GameScreen.player && GameScreen.objPvPNew == null)
					{
						GameScreen.objPvPNew = mainObject;
					}
				}
			}
		}
		for (int m = 0; m < GameScreen.vecHighDataEff.size(); m++)
		{
			DataSkillEff dataSkillEff = (DataSkillEff)GameScreen.vecHighDataEff.elementAt(m);
			if (dataSkillEff != null)
			{
				dataSkillEff.update();
				if (dataSkillEff.wantDestroy)
				{
					GameScreen.vecHighDataEff.removeElementAt(m);
				}
			}
		}
		GameScreen.numEff = 0;
		for (int n = 0; n < GameScreen.VecEffect.size(); n++)
		{
			MainEffect mainEffect = (MainEffect)GameScreen.VecEffect.elementAt(n);
			if (mainEffect == null || mainEffect.isRemove)
			{
				GameScreen.VecEffect.removeElementAt(n);
				n--;
			}
			else if (!mainEffect.isStop)
			{
				GameScreen.numEff++;
				mainEffect.update();
			}
		}
		for (int num = 0; num < GameScreen.VecNum.size(); num++)
		{
			MainEffect mainEffect2 = (MainEffect)GameScreen.VecNum.elementAt(num);
			if (mainEffect2 != null && !mainEffect2.isRemove && !mainEffect2.isStop)
			{
				mainEffect2.update();
			}
		}
		if (GameScreen.tickPvP > 0)
		{
			GameScreen.tickPvP--;
			if (GameScreen.tickPvP == 0 && this.center == this.cmdInfoDoithu)
			{
				this.center = null;
			}
		}
		if (GameScreen.isMoveCamera)
		{
			MainScreen.cameraMain.setCameraWithLim(GameScreen.xCur - GameScreen.xMoveCam, GameScreen.yCur - GameScreen.yMoveCam, GameScreen.isRoom());
		}
		else if (GameScreen.typeViewPlayer == 0)
		{
			if (!GameScreen.isMoveCamEff)
			{
				bool flag = false;
				if (GameScreen.tickPvP > 0 && GameScreen.vecPlayers.size() > 1)
				{
					for (int num2 = 0; num2 < GameScreen.vecPlayers.size(); num2++)
					{
						MainObject mainObject2 = (MainObject)GameScreen.vecPlayers.elementAt(num2);
						if (GameCanvas.loadmap.idMap == 59)
						{
							if (mainObject2.typeObject == 1)
							{
								MainScreen.cameraMain.moveCamera(mainObject2.x - MotherCanvas.w / 2, mainObject2.y - MotherCanvas.h / 3 * 2);
								flag = true;
								break;
							}
						}
						else if (mainObject2 != GameScreen.player)
						{
							MainScreen.cameraMain.moveCamera(mainObject2.x - MotherCanvas.w / 2, mainObject2.y - MotherCanvas.h / 3 * 2);
							flag = true;
							break;
						}
					}
					if (this.cmdInfoDoithu == null && GameCanvas.loadmap.idMap != 59)
					{
						this.cmdInfoDoithu = new iCommand(T.info, 47, this);
						GameCanvas.gameScr.center = GameCanvas.gameScr.cmdInfoDoithu;
						GameCanvas.gameScr.cmdInfoDoithu = AvMain.setPosCMD(GameCanvas.gameScr.cmdInfoDoithu, 0);
					}
				}
				if (!flag)
				{
					if (LoadMap.specMap == 7)
					{
						MainScreen.cameraMain.moveCamera(GameScreen.player.x - MotherCanvas.w / 2, GameScreen.player.y - MotherCanvas.h / 5 * 4);
					}
					else
					{
						MainScreen.cameraMain.moveCamera(GameScreen.player.x - MotherCanvas.w / 2, GameScreen.player.y - MotherCanvas.h / 3 * 2);
					}
				}
			}
		}
		else if (GameScreen.objView == null)
		{
			MainScreen.cameraMain.setCameraWithLim(GameScreen.xCur - GameScreen.xMoveCam, GameScreen.yCur - GameScreen.yMoveCam, GameScreen.isRoom());
		}
		else
		{
			MainScreen.cameraMain.moveCamera(GameScreen.objView.x - MotherCanvas.w / 2, GameScreen.objView.y - MotherCanvas.h / 3 * 2);
		}
		MainScreen.cameraMain.UpdateCameraGameScreen();
		if (GameScreen.objFocus != null && GameScreen.objFocus.returnAction())
		{
			GameScreen.objFocus = null;
			this.center = null;
		}
		int num3 = GameScreen.vecEffTam.size();
		for (int num4 = 0; num4 < num3; num4++)
		{
			MainEffect mainEffect3 = (MainEffect)GameScreen.vecEffTam.elementAt(0);
			if (mainEffect3.CreateEffectSkill())
			{
				int num5 = GameScreen.find_Index_Stop(GameScreen.VecEffect);
				if (num5 == GameScreen.VecEffect.size())
				{
					GameScreen.VecEffect.addElement(mainEffect3);
				}
				else
				{
					GameScreen.VecEffect.setElementAt(mainEffect3, num5);
				}
			}
			GameScreen.vecEffTam.removeElementAt(0);
		}
		Interface_Game.updateNumMess();
		Interface_Game.updateMoveTo();
		GameScreen.interfaceGame.updateShowNameMap();
		if (GameScreen.effMap != null)
		{
			GameScreen.effMap.update();
		}
		if (GameScreen.effSea != null)
		{
			GameScreen.effSea.updateSea();
		}
		for (int num6 = 0; num6 < GameScreen.vecEffOnMap.size(); num6++)
		{
			Point point = (Point)GameScreen.vecEffOnMap.elementAt(num6);
			point.f++;
			if (point.fSmall == 0)
			{
				if (point.f == point.fRe / 6 * 4)
				{
					point.frame = 1;
				}
				if (point.f == point.fRe / 6 * 5)
				{
					point.frame = 2;
				}
				if ((point.f >= point.fRe && GameScreen.vecEffOnMap.size() > 20) || point.f > point.fRe + point.fRe / 2 || point.f >= 100)
				{
					GameScreen.vecEffOnMap.removeElement(point);
					num6--;
				}
			}
		}
		if (GameScreen.typePaintGameScreen != 0)
		{
			for (int num7 = 0; num7 < GameScreen.vecEffSkillSpec.size(); num7++)
			{
				Point point2 = (Point)GameScreen.vecEffSkillSpec.elementAt(num7);
				point2.update();
				if (point2.x < -10)
				{
					point2.x = MotherCanvas.w + CRes.random(MotherCanvas.w / 4);
					point2.y = 5 + num7 * 10 + CRes.random_Am_0(4);
					point2 = GameScreen.createPoint(point2);
				}
			}
		}
		if (GameCanvas.isTypeSpam == 1)
		{
			if (GameCanvas.currentDialog == null && GameCanvas.currentScreen == this)
			{
				GameScreen.tickSpam++;
			}
			if (GameScreen.tickSpam >= 50)
			{
				GameCanvas.isTypeSpam = 0;
				GameCanvas.gameScr.cmdSpam.perform();
			}
		}
		int num8 = GameCanvas.gameTick % 4000;
		if (num8 <= 2000)
		{
			if (num8 != 1000)
			{
				if (num8 == 2000)
				{
					GameScreen.checkRemoveImage(3, false);
				}
			}
			else
			{
				GameScreen.checkRemoveImage(2, false);
			}
		}
		else if (num8 != 2100)
		{
			if (num8 != 3000)
			{
				if (num8 == 3999)
				{
					GameScreen.checkRemoveImage(1, false);
				}
			}
			else
			{
				GameScreen.checkRemoveImage(4, false);
			}
		}
		else
		{
			GlobalService.gI().checkPlayInMap(GameScreen.vecPlayers);
		}
		if (ReadMessenge.timeLoadItemMap > 0)
		{
			if (LoadMap.demSendTem == 1000)
			{
				LoadMap.demSendTem = 0;
				GameCanvas.loadmap.checkSetItemMap();
			}
			ReadMessenge.timeLoadItemMap--;
			if (ReadMessenge.timeLoadItemMap == 10)
			{
				GameCanvas.loadmap.checkSetItemMap();
				for (int num9 = 0; num9 < LoadMap.mItemMap.Length; num9++)
				{
					CRes.quickSort(LoadMap.mItemMap[num9]);
				}
			}
		}
	}

	// Token: 0x0600041D RID: 1053 RVA: 0x00009DF2 File Offset: 0x00007FF2
	public static bool checkAddEff()
	{
		return (!GameCanvas.lowGraphic || GameScreen.numEff <= 20) && GameScreen.numEff <= 100;
	}

	// Token: 0x0600041E RID: 1054 RVA: 0x00076A3C File Offset: 0x00074C3C
	public static void checkObjRemoveInVecMove(short id, sbyte cat)
	{
		for (int i = 0; i < GameScreen.vecObjMove.size(); i++)
		{
			ObjMove objMove = (ObjMove)GameScreen.vecObjMove.elementAt(i);
			if (id == objMove.id && objMove.typeObj == cat)
			{
				objMove.isRemove = true;
			}
		}
	}

	// Token: 0x0600041F RID: 1055 RVA: 0x00076A88 File Offset: 0x00074C88
	public static void checkRemoveImage(int type, bool isTrue)
	{
		bool isTrue2 = false;
		if (type == 0 || type == 1)
		{
			ObjectData.checkDelHash_Data(DataSkillEff.ALL_EFF_DATA, 120, isTrue2);
			ObjectData.checkDelHash(ObjectData.HashImageItemMap, 120, isTrue2);
			ObjectData.checkDelHash(ObjectData.hashImageIconClan, 120, isTrue2);
			ObjectData.checkDelHash(ObjectData.hashImageIconClanBig, 120, isTrue2);
			for (int i = 0; i < GameScreen.VecEffect.size(); i++)
			{
				MainEffect mainEffect = (MainEffect)GameScreen.VecEffect.elementAt(i);
				if (mainEffect.isStop)
				{
					mainEffect.isRemove = true;
				}
			}
		}
		else if (type == 0 || type == 2)
		{
			ObjectData.checkDelHash(ObjectData.hashImagePotion, 120, isTrue2);
			ObjectData.checkDelHash(ObjectData.HashImageMonster, 120, isTrue2);
			CharPartInfo.checkDelHashCharPart(CharPartInfo.hashMyPart, 240);
			ObjectData.checkDelHash(ObjectData.hashImageItemOther, 120, isTrue2);
		}
		else if (type == 0 || type == 3)
		{
			ObjectData.checkDelHash(ObjectData.hashImageNPC, 120, isTrue2);
			ObjectData.checkDelHash(ObjectData.HashImageCharPart, 120, isTrue2);
			ObjectData.checkDelHash(ObjectData.hashImageItem, 120, isTrue2);
			ObjectData.checkDelHash(ObjectData.hashImageMaterialPotion, 120, isTrue2);
			for (int j = 0; j < GameScreen.VecNum.size(); j++)
			{
				MainEffect mainEffect2 = (MainEffect)GameScreen.VecNum.elementAt(j);
				if (mainEffect2.isStop)
				{
					mainEffect2.isRemove = true;
				}
			}
		}
		else if (type == 0 || type == 4)
		{
			ObjectData.checkDelHash(ObjectData.HashImageEffClient, 120, isTrue2);
			ObjectData.checkDelHash(ObjectData.HashImageOtherNew, 120, isTrue2);
			ObjectData.checkDelHash(ObjectData.hashImageBoat, 120, isTrue2);
			ObjectData.checkDelHash(ObjectData.HashImageFashion, 120, isTrue2);
		}
		mSystem.gc();
	}

	// Token: 0x06000420 RID: 1056 RVA: 0x00076C04 File Offset: 0x00074E04
	private void updateMoveObj(ObjMove obj)
	{
		MainObject mainObject = MainObject.get_Object((int)obj.id, obj.typeObj);
		if (mainObject == null)
		{
			if (obj.typeObj == 1)
			{
				MainMonster mainMonster = new MainMonster(obj.id, (int)obj.x, (int)obj.y);
				GameScreen.addPlayer(mainMonster);
				GlobalService.gI().monster_info(obj.id);
				mainMonster.timeLoadInfo = GameCanvas.timeNow;
				return;
			}
			if (obj.typeObj == 0 || obj.typeObj == 2)
			{
				Other_Player other_Player = new Other_Player(obj.id, obj.typeObj, string.Empty, (int)obj.x, (int)obj.y);
				other_Player.Dir = ((CRes.random(2) != 0) ? 2 : 0);
				GameScreen.addPlayer(other_Player);
				GlobalService.gI().char_info(obj.id);
				other_Player.timeLoadInfo = GameCanvas.timeNow;
				return;
			}
		}
		else if (MainObject.getDistance(mainObject.toX, mainObject.toY, (int)obj.x, (int)obj.y) >= mainObject.vMax)
		{
			if (mainObject == GameScreen.player)
			{
				mainObject.toX = (int)obj.x;
				mainObject.toY = (int)obj.y;
				mainObject.isMoveNor = true;
				return;
			}
			if (mainObject.Action != 2 && mainObject.Action != 4 && mainObject.skillCurrent == null)
			{
				if (mainObject.timeBeginUpdateMove < 0)
				{
					mainObject.timeBeginUpdateMove = GameCanvas.gameTick % 10 + 1;
				}
				mainObject.toXNew = (int)obj.x;
				mainObject.toYNew = (int)obj.y;
			}
		}
	}

	// Token: 0x06000421 RID: 1057 RVA: 0x00076D6C File Offset: 0x00074F6C
	public override void updatekey()
	{
		if (GameScreen.player.isNauBanh && GameCanvas.keyMyHold[5] && this.center != null)
		{
			GameCanvas.clearKeyPressed(5);
			GameCanvas.clearKeyHold(5);
			this.center.perform();
		}
		if (GameScreen.typeViewPlayer == 0)
		{
			if (GameScreen.player != null)
			{
				GameScreen.player.updateKey();
			}
		}
		else
		{
			this.updateKeyView();
		}
		base.updatekey();
	}

	// Token: 0x06000422 RID: 1058 RVA: 0x00076DD4 File Offset: 0x00074FD4
	private void updateKeyView()
	{
		bool flag = false;
		if (GameCanvas.keyMove(0))
		{
			GameScreen.xMoveCam += 10;
			flag = true;
		}
		else if (GameCanvas.keyMove(2))
		{
			GameScreen.xMoveCam -= 10;
			flag = true;
		}
		else if (GameCanvas.keyMove(1))
		{
			GameScreen.yMoveCam += 10;
			flag = true;
		}
		else if (GameCanvas.keyMove(3))
		{
			GameScreen.yMoveCam -= 10;
			flag = true;
		}
		if (flag)
		{
			GameScreen.timeResetCam = 40;
			if (!GameScreen.isMoveCamera)
			{
				GameScreen.xCur = MainScreen.cameraMain.xCam;
				GameScreen.yCur = MainScreen.cameraMain.yCam;
				GameScreen.xMoveCam = 0;
				GameScreen.yMoveCam = 0;
				GameScreen.isMoveCamera = true;
				return;
			}
			if (GameScreen.xCur - GameScreen.xMoveCam <= 0)
			{
				GameScreen.xMoveCam = GameScreen.xCur;
			}
			if (GameScreen.xCur - GameScreen.xMoveCam >= MainScreen.cameraMain.xLimit)
			{
				GameScreen.xMoveCam = GameScreen.xCur - MainScreen.cameraMain.xLimit;
			}
			if (GameScreen.yCur - GameScreen.yMoveCam <= 0)
			{
				GameScreen.yMoveCam = GameScreen.yCur;
			}
			if (GameScreen.yCur - GameScreen.yMoveCam >= MainScreen.cameraMain.yLimit)
			{
				GameScreen.yMoveCam = GameScreen.yCur - MainScreen.cameraMain.yLimit;
			}
		}
	}

	// Token: 0x06000423 RID: 1059 RVA: 0x00009E12 File Offset: 0x00008012
	public override void updatePointer()
	{
		base.updatePointer();
		if (!LoadMap.isOnlineMap)
		{
			this.updatePointerMapOffLine();
			return;
		}
		if (GameCanvas.currentScreen == GameCanvas.gameScr)
		{
			if (GameScreen.typeViewPlayer == 0)
			{
				GameScreen.interfaceGame.updateInGame();
				return;
			}
			GameScreen.interfaceGame.updateViewKhanGia();
		}
	}

	// Token: 0x06000424 RID: 1060 RVA: 0x00009E50 File Offset: 0x00008050
	private void updatePointerMapOffLine()
	{
		if (LoadMap.specMap == 5 || LoadMap.specMap == 8 || LoadMap.specMap == 12)
		{
			MapOff_RedLine.moveTypeKeypad();
		}
	}

	// Token: 0x06000425 RID: 1061 RVA: 0x00009E70 File Offset: 0x00008070
	public static void addBoatVec_And_mItem(Boat boat, bool isSort)
	{
		GameScreen.vecBoat.addElement(boat);
		LoadMap.mItemMap[3].addElement(boat);
		if (isSort)
		{
			CRes.quickSort(LoadMap.mItemMap[3]);
		}
	}

	// Token: 0x06000426 RID: 1062 RVA: 0x00009E99 File Offset: 0x00008099
	public static void removeBoatVec_And_mItem(Boat boat)
	{
		GameScreen.vecBoat.removeElement(boat);
		LoadMap.mItemMap[3].removeElement(boat);
	}

	// Token: 0x06000427 RID: 1063 RVA: 0x00009EB3 File Offset: 0x000080B3
	public static void addPlayer(MainObject obj)
	{
		GameScreen.vecPlayers.addElement(obj);
	}

	// Token: 0x06000428 RID: 1064 RVA: 0x00009EC0 File Offset: 0x000080C0
	public static MainItemMap addEffectAuto(string key, string value)
	{
		return new EffectAuto(key, value);
	}

	// Token: 0x06000429 RID: 1065 RVA: 0x00076F14 File Offset: 0x00075114
	public static void RemoveLoadMap()
	{
		for (int i = 0; i < GameScreen.vecPlayers.size(); i++)
		{
			MainObject mainObject = (MainObject)GameScreen.vecPlayers.elementAt(i);
			if (mainObject != GameScreen.player && (mainObject.typeObject != 10 || mainObject.IDMainShiper != GameScreen.player.ID))
			{
				mainObject.isRemove = true;
			}
		}
		GameScreen.vecBoat.removeAllElements();
		GameCanvas.gameScr.resetRecAlpha();
	}

	// Token: 0x0600042A RID: 1066 RVA: 0x00076F88 File Offset: 0x00075188
	public static void RemoveAllNPC()
	{
		for (int i = 0; i < GameScreen.vecPlayers.size(); i++)
		{
			MainObject mainObject = (MainObject)GameScreen.vecPlayers.elementAt(i);
			if (mainObject.typeObject == 2)
			{
				GameScreen.vecPlayers.removeElement(mainObject);
				i--;
			}
		}
	}

	// Token: 0x0600042B RID: 1067 RVA: 0x00076FD4 File Offset: 0x000751D4
	public static int find_Index_Stop(mVector vec)
	{
		int result = vec.size();
		for (int i = 0; i < vec.size(); i++)
		{
			MainEffect mainEffect = (MainEffect)vec.elementAt(i);
			if (mainEffect.isStop && !mainEffect.isRemove)
			{
				return i;
			}
		}
		return result;
	}

	// Token: 0x0600042C RID: 1068 RVA: 0x0007701C File Offset: 0x0007521C
	public static void addLazer(sbyte type, int x, int y, int xto, int yto)
	{
		Lazer o = new Lazer(0, x, y, xto, yto);
		GameScreen.vecEffTam.addElement(o);
	}

	// Token: 0x0600042D RID: 1069 RVA: 0x00077040 File Offset: 0x00075240
	public static void addEffectEnd(short type, int subtype, int x, int y, int time, sbyte dir, MainObject objEff)
	{
		if (objEff == GameScreen.player || GameScreen.checkAddEff())
		{
			Effect_End o = new Effect_End(type, (sbyte)subtype, x, y, time, dir, objEff);
			GameScreen.vecEffTam.addElement(o);
		}
	}

	// Token: 0x0600042E RID: 1070 RVA: 0x0007707C File Offset: 0x0007527C
	public static void addEffectEnd(short type, int subtype, int x, int y, sbyte dir, MainObject objEff)
	{
		if (objEff == GameScreen.player || GameScreen.checkAddEff())
		{
			Effect_End o = new Effect_End(type, (sbyte)subtype, x, y, dir, objEff);
			GameScreen.vecEffTam.addElement(o);
		}
	}

	// Token: 0x0600042F RID: 1071 RVA: 0x000770B4 File Offset: 0x000752B4
	public static void addEffectEnd_ToX_ToY(short type, int subtype, int x, int y, int xTo, int yTo, sbyte dir, MainObject objEff)
	{
		if (objEff == GameScreen.player || GameScreen.checkAddEff())
		{
			Effect_End o = new Effect_End(type, (sbyte)subtype, x, y, xTo, yTo, dir, objEff);
			GameScreen.vecEffTam.addElement(o);
		}
	}

	// Token: 0x06000430 RID: 1072 RVA: 0x000770F0 File Offset: 0x000752F0
	public static void addEffectEnd_ObjTo(short type, int subType, int x, int y, short Id, sbyte cat, sbyte dir, MainObject objEff)
	{
		if (objEff == GameScreen.player || GameScreen.checkAddEff())
		{
			Effect_End o = new Effect_End(type, (sbyte)subType, x, y, Id, cat, dir, objEff, 0);
			GameScreen.vecEffTam.addElement(o);
		}
	}

	// Token: 0x06000431 RID: 1073 RVA: 0x0007712C File Offset: 0x0007532C
	public static MainEffect createEffectEnd_ObjTo(short type, int subType, int x, int y, short Id, sbyte cat, sbyte dir, MainObject objEff)
	{
		return new Effect_End(type, (sbyte)subType, x, y, Id, cat, dir, objEff, 0);
	}

	// Token: 0x06000432 RID: 1074 RVA: 0x0007714C File Offset: 0x0007534C
	public static void addEffectEnd_Time(short type, int subType, int x, int y, short Id, sbyte cat, sbyte dir, MainObject objEff, int time)
	{
		if (objEff == GameScreen.player || GameScreen.checkAddEff())
		{
			Effect_End o = new Effect_End(type, (sbyte)subType, x, y, Id, cat, dir, objEff, time);
			GameScreen.vecEffTam.addElement(o);
		}
	}

	// Token: 0x06000433 RID: 1075 RVA: 0x0007718C File Offset: 0x0007538C
	public static void addEffectSkill(MainSkill skill, MainObject objkill, mVector vecObjsBeFire)
	{
		Effect_Skill o = new Effect_Skill((int)skill.typeEffSkill, (int)skill.typeSub, objkill, vecObjsBeFire);
		GameScreen.vecEffTam.addElement(o);
	}

	// Token: 0x06000434 RID: 1076 RVA: 0x000771B8 File Offset: 0x000753B8
	public static void addEffectSkill2(short typeEffSkill, MainObject objkill, Object_Effect_Skill objbekill, int x, int y)
	{
		mVector mVector = new mVector();
		mVector.addElement(objbekill);
		Effect_Skill o = new Effect_Skill((int)typeEffSkill, 0, objkill, mVector, x, y);
		GameScreen.vecEffTam.addElement(o);
	}

	// Token: 0x06000435 RID: 1077 RVA: 0x000771EC File Offset: 0x000753EC
	public static void addEffectSkill(MainSkill skill, MainObject objkill)
	{
		Effect_Skill o = new Effect_Skill(skill, objkill);
		GameScreen.vecEffTam.addElement(o);
	}

	// Token: 0x06000436 RID: 1078 RVA: 0x0007720C File Offset: 0x0007540C
	public static void addEffectSkillSpec(MainSkill skill, MainObject objkill)
	{
		Effect_Skill o = new Effect_Skill(skill, objkill, skill.x, skill.y, skill.vecPos);
		GameScreen.vecEffTam.addElement(o);
	}

	// Token: 0x06000437 RID: 1079 RVA: 0x00077240 File Offset: 0x00075440
	public static void addEffectNum(string content, int x, int y, sbyte typeColor)
	{
		EffectNum effectNum = new EffectNum(content, x, y, (int)typeColor);
		int num = GameScreen.find_Index_Stop(GameScreen.VecNum);
		if (num == GameScreen.VecNum.size())
		{
			GameScreen.VecNum.addElement(effectNum);
			return;
		}
		GameScreen.VecNum.setElementAt(effectNum, num);
	}

	// Token: 0x06000438 RID: 1080 RVA: 0x00077288 File Offset: 0x00075488
	public static void addEffectNumImage(string content, int x, int y, sbyte typeColor, FrameImage fra, int frame)
	{
		EffectNum effectNum = new EffectNum(content, x, y, (int)typeColor, fra, frame);
		int num = GameScreen.find_Index_Stop(GameScreen.VecNum);
		if (num == GameScreen.VecNum.size())
		{
			GameScreen.VecNum.addElement(effectNum);
			return;
		}
		GameScreen.VecNum.setElementAt(effectNum, num);
	}

	// Token: 0x06000439 RID: 1081 RVA: 0x000772D4 File Offset: 0x000754D4
	public static void addEffectNumBig_NEW_AP(int value, int valueAP, int x, int y, sbyte typeColor)
	{
		EffectNum effectNum = new EffectNum(value, valueAP, x, y, (int)typeColor);
		int num = GameScreen.find_Index_Stop(GameScreen.VecNum);
		if (num == GameScreen.VecNum.size())
		{
			GameScreen.VecNum.addElement(effectNum);
			return;
		}
		GameScreen.VecNum.setElementAt(effectNum, num);
	}

	// Token: 0x0600043A RID: 1082 RVA: 0x00009EC9 File Offset: 0x000080C9
	public static MainEffect CreateEffectEnd(short type, int subtype, int x, int y, sbyte dir, MainObject objEff)
	{
		return new Effect_End(type, (sbyte)subtype, x, y, dir, objEff);
	}

	// Token: 0x0600043B RID: 1083 RVA: 0x00009ED9 File Offset: 0x000080D9
	public static MainEffect createEffEnd(short type, int subtype, int x, int y, int xto, int yto)
	{
		return new Effect_End(type, (sbyte)subtype, x, y, xto, yto, 0, null);
	}

	// Token: 0x0600043C RID: 1084 RVA: 0x00009EEB File Offset: 0x000080EB
	public static MainEffect createEffectEndTime(short type, int subtype, int x, int y, int time, sbyte dir, MainObject objEff)
	{
		return new Effect_End(type, (sbyte)subtype, x, y, time, dir, objEff);
	}

	// Token: 0x0600043D RID: 1085 RVA: 0x00077320 File Offset: 0x00075520
	public static void isPaintNormal()
	{
		GameScreen.typePaintGameScreen = 0;
		GameScreen.vecEffSkillSpec.removeAllElements();
		for (int i = 0; i < GameScreen.vecPlayers.size(); i++)
		{
			MainObject mainObject = (MainObject)GameScreen.vecPlayers.elementAt(i);
			if (mainObject.isPaintSpec)
			{
				mainObject.isPaintSpec = false;
			}
		}
	}

	// Token: 0x0600043E RID: 1086 RVA: 0x00077374 File Offset: 0x00075574
	public static void beginPaintSpec()
	{
		int num = MotherCanvas.h / 10;
		GameScreen.typePaintGameScreen = 1;
		GameScreen.vecEffSkillSpec.removeAllElements();
		for (int i = 0; i < num; i++)
		{
			Point point = new Point();
			GameScreen.createPoint(point);
			GameScreen.vecEffSkillSpec.addElement(point);
		}
	}

	// Token: 0x0600043F RID: 1087 RVA: 0x000773C0 File Offset: 0x000755C0
	public static Point createPoint(Point p)
	{
		p.vx = -CRes.random(25, 35);
		p.w = CRes.random(16, 30);
		p.h = CRes.random(2, 7) / 2;
		p.color = 15970753;
		if (CRes.random(4) == 3)
		{
			p.color = 15791467;
		}
		if (p.y >= MotherCanvas.h / 4 * 3 - GameScreen.size - 12 && p.y <= MotherCanvas.h / 4 * 3 + GameScreen.size + 12)
		{
			p.dis = CRes.random(4);
		}
		else
		{
			p.dis = CRes.random(10);
		}
		return p;
	}

	// Token: 0x06000440 RID: 1088 RVA: 0x0007746C File Offset: 0x0007566C
	public void setTypeViewPlayer(sbyte type)
	{
		GameScreen.typeViewPlayer = type;
		GameScreen.isMoveCamera = false;
		GameScreen.xMoveCam = 0;
		GameScreen.yMoveCam = 0;
		if (GameScreen.typeViewPlayer != 0)
		{
			GameScreen.isSetObjdDefault = true;
			GameScreen.objView = null;
			this.center = null;
			this.left = this.cmdSettingView;
			this.right = this.cmdExitView;
			MainScreen.cameraMain.moveCamera(GameScreen.player.x - MotherCanvas.w / 2, GameScreen.player.y - MotherCanvas.h / 3 * 2);
			GameScreen.xCur = MainScreen.cameraMain.xTo;
			GameScreen.yCur = MainScreen.cameraMain.yTo;
		}
	}

	// Token: 0x06000441 RID: 1089 RVA: 0x00009EFD File Offset: 0x000080FD
	public static void setIsMoveEff(bool ismove)
	{
		GameScreen.isMoveCamEff = ismove;
	}

	// Token: 0x06000442 RID: 1090 RVA: 0x00077514 File Offset: 0x00075714
	public static void CreateEffOnMap(sbyte type, int x, int y, int dir, sbyte subtype)
	{
		if (!GameCanvas.lowGraphic && GameScreen.vecEffOnMap.size() <= 100)
		{
			Point point = new Point(x + CRes.random_Am_0(2), y + CRes.random_Am_0(2));
			point.fSmall = (int)type;
			point.subType = (int)(subtype % 2);
			if (GameMidlet.DEVICE > 0)
			{
				if (GameScreen.vecEffOnMap.size() < 50)
				{
					point.fRe = CRes.random(50, 70);
				}
				else
				{
					point.fRe = CRes.random(20, 30);
				}
			}
			else if (GameScreen.vecEffOnMap.size() < 50)
			{
				point.fRe = CRes.random(15, 25);
			}
			else
			{
				point.fRe = CRes.random(8, 15);
			}
			point.dis = dir;
			GameScreen.vecEffOnMap.addElement(point);
		}
	}

	// Token: 0x06000443 RID: 1091 RVA: 0x00009F05 File Offset: 0x00008105
	public static void CreateEffOnMapFullset(short type, int x, int y, int dir, sbyte subtype)
	{
		GameScreen.addEffectEnd(type, 0, x, y, (sbyte)dir, null);
	}

	// Token: 0x06000444 RID: 1092 RVA: 0x000775DC File Offset: 0x000757DC
	public static void addHelp(int type, int typeSub)
	{
		MainHelp o = new MainHelp(type, typeSub);
		GameScreen.vecHelp.addElement(o);
	}

	// Token: 0x06000445 RID: 1093 RVA: 0x00009F13 File Offset: 0x00008113
	public override bool keyBack()
	{
		if (!base.keyBack() && this.cmdHoiExit != null)
		{
			this.cmdHoiExit.perform();
		}
		return false;
	}

	// Token: 0x06000446 RID: 1094 RVA: 0x00009F31 File Offset: 0x00008131
	public void ShowInfoOtherPlayer(string name)
	{
		GlobalService.gI().Show_Player_Info(name);
	}

	// Token: 0x06000447 RID: 1095 RVA: 0x000775FC File Offset: 0x000757FC
	public void ShowChatTab(string name)
	{
		GameCanvas.chatTabScr.addNewChat(name, string.Empty, string.Empty, 0, true);
		if (MsgSpamSetup.isCheckSpam(1, name))
		{
			GameCanvas.chatTabScr.addNewChat(name, string.Empty, T.dangbatspamchat, 0, true);
		}
		InfoMemList.setTypeEvent(-1, 2, name, string.Empty, 0, 0);
		GameCanvas.chatTabScr.Show(GameCanvas.gameScr);
	}

	// Token: 0x06000448 RID: 1096 RVA: 0x00009F3E File Offset: 0x0000813E
	public static void setSuperEffect(sbyte type, sbyte tick)
	{
		GameScreen.typeSuperEffect = type;
		GameScreen.tickSuperEffect = (int)tick;
	}

	// Token: 0x06000449 RID: 1097 RVA: 0x00009F4C File Offset: 0x0000814C
	public static bool getIsOffAdmin(sbyte type)
	{
		return GameScreen.isOffAll || (type == 0 && !GameScreen.isShowName) || (type == 1 && !GameScreen.isPaintInterface) || (type == 2 && !GameScreen.isShowChat);
	}

	// Token: 0x0600044A RID: 1098 RVA: 0x00009F7A File Offset: 0x0000817A
	public static bool isRoom()
	{
		return GameCanvas.loadmap.idMap == 100 || GameCanvas.loadmap.idMap == 101;
	}

	// Token: 0x0600044B RID: 1099 RVA: 0x00077660 File Offset: 0x00075860
	public static short checkPokemon()
	{
		short result;
		if (GameScreen.objFocus != null && GameScreen.objFocus.isPokemon > 0)
		{
			result = GameScreen.objFocus.ID;
		}
		else
		{
			for (int i = 0; i < GameScreen.vecPlayers.size(); i++)
			{
				MainObject mainObject = (MainObject)GameScreen.vecPlayers.elementAt(i);
				if (!mainObject.isRemove && mainObject.isPokemon > 0 && MainObject.getDistance(GameScreen.player.x, GameScreen.player.y, mainObject.x, mainObject.y) <= 160)
				{
					return mainObject.ID;
				}
			}
			result = -1;
		}
		return result;
	}

	// Token: 0x0600044C RID: 1100 RVA: 0x000776FC File Offset: 0x000758FC
	public void readVecFire()
	{
		try
		{
			int i = 0;
			while (i < GameScreen.vecObjFire.size())
			{
				Message message = (Message)GameScreen.vecObjFire.elementAt(i);
				try
				{
					if (!LoadMapScreen.isNextMap)
					{
						break;
					}
					int id = (int)message.reader().readShort();
					sbyte tem = message.reader().readByte();
					MainObject mainObject = MainObject.get_Object(id, tem);
					if (mainObject == null || (GameCanvas.lowGraphic && GameScreen.player != mainObject && MainObject.getDistance(GameScreen.player.x, GameScreen.player.y, mainObject.x, mainObject.y) >= 240))
					{
						break;
					}
					if (mainObject.timeDragon <= 0)
					{
						mainObject.frameOneStep = 20;
					}
					mainObject.timeDragon = 150;
					mainObject.Hp = message.reader().readInt();
					mainObject.Mp = message.reader().readInt();
					short typeEff = message.reader().readShort();
					sbyte b = message.reader().readByte();
					if (b > 0)
					{
						mVector mVector = new mVector();
						for (int j = 0; j < (int)b; j++)
						{
							short id2 = message.reader().readShort();
							sbyte tem2 = message.reader().readByte();
							Object_Effect_Skill object_Effect_Skill = new Object_Effect_Skill(id2, tem2);
							int hpShow = message.reader().readInt();
							int hpMagic = 0;
							if (message.isOld == 0)
							{
								hpMagic = message.reader().readInt();
							}
							int hpLast = message.reader().readInt();
							sbyte b2 = message.reader().readByte();
							object_Effect_Skill.mEffTypePlus = new int[(int)b2];
							object_Effect_Skill.mEff_HP_Plus = new int[(int)b2];
							object_Effect_Skill.mEff_Time_Plus = new int[(int)b2];
							for (int k = 0; k < (int)b2; k++)
							{
								object_Effect_Skill.mEffTypePlus[k] = (int)message.reader().readShort();
								object_Effect_Skill.mEff_HP_Plus[k] = (int)message.reader().readShort();
								object_Effect_Skill.mEff_Time_Plus[k] = (int)message.reader().readShort();
							}
							object_Effect_Skill.setHP(hpShow, hpLast, hpMagic);
							mVector.addElement(object_Effect_Skill);
						}
						MainSkill skill = new MainSkill(-1, typeEff);
						mainObject.addSkillFire(skill, mVector);
						goto IL_223;
					}
					GameScreen.vecObjFire.removeElementAt(i);
					i--;
				}
				catch (Exception)
				{
					goto IL_223;
				}
				IL_21D:
				i++;
				continue;
				IL_223:
				GameScreen.vecObjFire.removeElementAt(i);
				i--;
				goto IL_21D;
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x0600044D RID: 1101 RVA: 0x00077988 File Offset: 0x00075B88
	public static void addHightDataeff(short type, int x, int y)
	{
		DataSkillEff o = new DataSkillEff(type, x, y);
		GameScreen.vecHighDataEff.addElement(o);
	}

	// Token: 0x0600044E RID: 1102 RVA: 0x000779AC File Offset: 0x00075BAC
	public static ObjMove getObjMove(short id, sbyte cat)
	{
		for (int i = 0; i < GameScreen.vecObjMove.size(); i++)
		{
			ObjMove objMove = (ObjMove)GameScreen.vecObjMove.elementAt(i);
			if (!objMove.isRemove && objMove.id == id && objMove.typeObj == cat)
			{
				return objMove;
			}
		}
		return null;
	}

	// Token: 0x0600044F RID: 1103 RVA: 0x000779FC File Offset: 0x00075BFC
	public static MainObject findObjByID(short id)
	{
		for (int i = 0; i < GameScreen.vecPlayers.size(); i++)
		{
			MainObject mainObject = (MainObject)GameScreen.vecPlayers.elementAt(i);
			if (mainObject != null && mainObject.ID == id)
			{
				return mainObject;
			}
		}
		return null;
	}

	// Token: 0x06000450 RID: 1104 RVA: 0x00077A40 File Offset: 0x00075C40
	public void resetRecAlpha()
	{
		GameCanvas.gameScr.colorRec = 0;
		GameCanvas.gameScr.xRec = 0;
		GameCanvas.gameScr.yRec = 0;
		GameCanvas.gameScr.wRec = 0;
		GameCanvas.gameScr.hRec = 0;
		GameCanvas.gameScr.isFullScreen = false;
	}

	// Token: 0x06000452 RID: 1106 RVA: 0x00077C44 File Offset: 0x00075E44
	public static void Autochat()
	{
		while (GameScreen.atchat)
		{
			string text = File.ReadAllText("chat.txt");
			GlobalService.gI().chatPopup(text);
			Thread.Sleep(10000);
		}
	}

	// Token: 0x0400061E RID: 1566
	public const sbyte VIEW_NORMAL = 0;

	// Token: 0x0400061F RID: 1567
	public const sbyte VIEW_KHANGIA = 1;

	// Token: 0x04000620 RID: 1568
	public const sbyte FOOT = 0;

	// Token: 0x04000621 RID: 1569
	public const sbyte LIGHT = 0;

	// Token: 0x04000622 RID: 1570
	public const sbyte ADMIN_OFF_NAME = 0;

	// Token: 0x04000623 RID: 1571
	public const sbyte ADMIN_OFF_INTERFACE = 1;

	// Token: 0x04000624 RID: 1572
	public const sbyte ADMIN_OFF_CHAT = 2;

	// Token: 0x04000625 RID: 1573
	public static Player player = new Player();

	// Token: 0x04000626 RID: 1574
	public static MainObject objFocus = null;

	// Token: 0x04000627 RID: 1575
	public static MainObject objGiaotiep;

	// Token: 0x04000628 RID: 1576
	public static MainObject objPvPNew = null;

	// Token: 0x04000629 RID: 1577
	public static mVector vecPlayers = new mVector("GameScreen.vecPlayers");

	// Token: 0x0400062A RID: 1578
	public static mVector vecEffTam = new mVector("GameScreen.vecEffTam");

	// Token: 0x0400062B RID: 1579
	public static mVector VecEffect = new mVector("GameScreen.vecEffect");

	// Token: 0x0400062C RID: 1580
	public static mVector VecNum = new mVector("GameScreen.vecNum");

	// Token: 0x0400062D RID: 1581
	public static mVector vecBoat = new mVector("GameScreen.vecBoat");

	// Token: 0x0400062E RID: 1582
	public static mVector vecObjMove = new mVector("GameScreen.vecObjMove");

	// Token: 0x0400062F RID: 1583
	public static mVector vecObjFire = new mVector("GameScreen.vecObjFire");

	// Token: 0x04000630 RID: 1584
	public static mVector vecHighDataEff = new mVector();

	// Token: 0x04000631 RID: 1585
	private int nump;

	// Token: 0x04000632 RID: 1586
	private int numo;

	// Token: 0x04000633 RID: 1587
	private MainObject ob;

	// Token: 0x04000634 RID: 1588
	private MainObject maxob = new MainObject();

	// Token: 0x04000635 RID: 1589
	public static MainItemMap tr;

	// Token: 0x04000636 RID: 1590
	public static MainItemMap maxtr = new MainItemMap();

	// Token: 0x04000637 RID: 1591
	public static Interface_Game interfaceGame = new Interface_Game();

	// Token: 0x04000638 RID: 1592
	public iCommand cmdNextFocus;

	// Token: 0x04000639 RID: 1593
	public iCommand cmdHoiSinh;

	// Token: 0x0400063A RID: 1594
	public iCommand cmdGetXpMapTrain;

	// Token: 0x0400063B RID: 1595
	public iCommand cmdThoatFormMapTrain;

	// Token: 0x0400063C RID: 1596
	public iCommand cmdInfoMe;

	// Token: 0x0400063D RID: 1597
	public iCommand cmdSetPk;

	// Token: 0x0400063E RID: 1598
	public iCommand cmdSetDosat;

	// Token: 0x0400063F RID: 1599
	public iCommand cmdParty;

	// Token: 0x04000640 RID: 1600
	public iCommand cmdInviteParty;

	// Token: 0x04000641 RID: 1601
	public iCommand cmdLogOut;

	// Token: 0x04000642 RID: 1602
	public iCommand cmdTrochuyen;

	// Token: 0x04000643 RID: 1603
	public iCommand cmdChatPlayer;

	// Token: 0x04000644 RID: 1604
	public iCommand cmdAuto;

	// Token: 0x04000645 RID: 1605
	public iCommand cmdChatPopup;

	// Token: 0x04000646 RID: 1606
	public iCommand cmdAddFriend;

	// Token: 0x04000647 RID: 1607
	public iCommand cmdFriendList;

	// Token: 0x04000648 RID: 1608
	public iCommand cmdBlackList;

	// Token: 0x04000649 RID: 1609
	public iCommand cmdEvent;

	// Token: 0x0400064A RID: 1610
	public iCommand cmdChangeTouch;

	// Token: 0x0400064B RID: 1611
	public iCommand cmdFight;

	// Token: 0x0400064C RID: 1612
	public iCommand cmdVeLang;

	// Token: 0x0400064D RID: 1613
	public iCommand cmdInfoPlayer;

	// Token: 0x0400064E RID: 1614
	public iCommand cmdSettingView;

	// Token: 0x0400064F RID: 1615
	public iCommand cmdExitView;

	// Token: 0x04000650 RID: 1616
	public iCommand cmdExit;

	// Token: 0x04000651 RID: 1617
	public iCommand cmdWC;

	// Token: 0x04000652 RID: 1618
	public iCommand cmdShowWC;

	// Token: 0x04000653 RID: 1619
	public iCommand cmdInviteTrade;

	// Token: 0x04000654 RID: 1620
	public iCommand cmdBuyGem;

	// Token: 0x04000655 RID: 1621
	public iCommand cmdSendSerial_Mathe;

	// Token: 0x04000656 RID: 1622
	public iCommand cmdHoiExit;

	// Token: 0x04000657 RID: 1623
	public iCommand cmdMenuPk;

	// Token: 0x04000658 RID: 1624
	public iCommand cmdClan;

	// Token: 0x04000659 RID: 1625
	public iCommand cmdXinVaoClan;

	// Token: 0x0400065A RID: 1626
	public iCommand cmdMoiVaoClan;

	// Token: 0x0400065B RID: 1627
	public iCommand cmdShowName;

	// Token: 0x0400065C RID: 1628
	public iCommand cmdMPHP;

	// Token: 0x0400065D RID: 1629
	public iCommand cmdGetItem;

	// Token: 0x0400065E RID: 1630
	public iCommand cmdDonotShowHat;

	// Token: 0x0400065F RID: 1631
	public iCommand cmdDonotShowWeaponF;

	// Token: 0x04000660 RID: 1632
	public iCommand cmdInfoDoithu;

	// Token: 0x04000661 RID: 1633
	public iCommand cmdUniform;

	// Token: 0x04000662 RID: 1634
	public iCommand cmdQuickChat;

	// Token: 0x04000663 RID: 1635
	public iCommand cmdGiaotiepServer;

	// Token: 0x04000664 RID: 1636
	public iCommand cmdLockChat;

	// Token: 0x04000665 RID: 1637
	public iCommand cmdShowSkillBuff;

	// Token: 0x04000666 RID: 1638
	public iCommand cmdSpam;

	// Token: 0x04000667 RID: 1639
	public iCommand cmdTangRuby;

	// Token: 0x04000668 RID: 1640
	public iCommand cmdDauGia;

	// Token: 0x04000669 RID: 1641
	public iCommand cmdShowSkillPlayer;

	// Token: 0x0400066A RID: 1642
	public iCommand cmdShowNhanVat;

	// Token: 0x0400066B RID: 1643
	public iCommand cmdSudo;

	// Token: 0x0400066C RID: 1644
	public iCommand cmdBaisu;

	// Token: 0x0400066D RID: 1645
	public iCommand cmdPet;

	// Token: 0x0400066E RID: 1646
	public static iCommand cmdGiaoTiep;

	// Token: 0x0400066F RID: 1647
	public static iCommand cmdVotBanh;

	// Token: 0x04000670 RID: 1648
	public static iCommand cmdCheckServer;

	// Token: 0x04000671 RID: 1649
	public static iCommand cmdReConnect;

	// Token: 0x04000672 RID: 1650
	public static int numMess = 0;

	// Token: 0x04000673 RID: 1651
	public static bool isMoveCamera = false;

	// Token: 0x04000674 RID: 1652
	public static bool isMoveCamEff = false;

	// Token: 0x04000675 RID: 1653
	public static bool isPvPNew = false;

	// Token: 0x04000676 RID: 1654
	public static int xMoveCam;

	// Token: 0x04000677 RID: 1655
	public static int yMoveCam;

	// Token: 0x04000678 RID: 1656
	public static int xCur;

	// Token: 0x04000679 RID: 1657
	public static int yCur;

	// Token: 0x0400067A RID: 1658
	public static int timeResetCam;

	// Token: 0x0400067B RID: 1659
	public static int typeMod = 0;

	// Token: 0x0400067C RID: 1660
	public static Effect_Map effMap;

	// Token: 0x0400067D RID: 1661
	public static Effect_Map effSea;

	// Token: 0x0400067E RID: 1662
	public static sbyte typeViewPlayer = 0;

	// Token: 0x0400067F RID: 1663
	public static MainObject objView = null;

	// Token: 0x04000680 RID: 1664
	public static bool isSetObjdDefault = false;

	// Token: 0x04000681 RID: 1665
	public static bool isShowFocusTK = false;

	// Token: 0x04000682 RID: 1666
	public static bool isShowSkillBuff = true;

	// Token: 0x04000683 RID: 1667
	public static bool isShowSkillPlayer = true;

	// Token: 0x04000684 RID: 1668
	public static bool isShowNhanVat = true;

	// Token: 0x04000685 RID: 1669
	private InputDialog input;

	// Token: 0x04000686 RID: 1670
	public static mVector vecHelp;

	// Token: 0x04000687 RID: 1671
	public static int indexHelp = -1;

	// Token: 0x04000688 RID: 1672
	public static int indexHDVaoLang = 0;

	// Token: 0x04000689 RID: 1673
	public static int tickPvP;

	// Token: 0x0400068A RID: 1674
	public static int h12plus = 0;

	// Token: 0x0400068B RID: 1675
	public static mVector vecBigBossLittleGraden = new mVector("GameScreen.vecBigBossLittleGraden");

	// Token: 0x0400068C RID: 1676
	public static mVector vecGetItemLittle = new mVector("GameScreen.getItemLittle");

	// Token: 0x0400068D RID: 1677
	public static bool isShowNameSUPER_BOSS = true;

	// Token: 0x0400068E RID: 1678
	public static bool isShowNameXpArena = false;

	// Token: 0x0400068F RID: 1679
	public static bool isShowNameSetting = true;

	// Token: 0x04000690 RID: 1680
	public static bool isShowNameWW = false;

	// Token: 0x04000691 RID: 1681
	public static bool isPaintInterface = true;

	// Token: 0x04000692 RID: 1682
	public static bool isShowChat = true;

	// Token: 0x04000693 RID: 1683
	public static bool isOffAll = false;

	// Token: 0x04000694 RID: 1684
	public static bool isShowName = true;

	// Token: 0x04000695 RID: 1685
	public static bool isOnChestAdmin = false;

	// Token: 0x04000696 RID: 1686
	public static bool isShowIndex = false;

	// Token: 0x04000697 RID: 1687
	public static bool isIP_Local = false;

	// Token: 0x04000698 RID: 1688
	public static bool isShowText = false;

	// Token: 0x04000699 RID: 1689
	public static bool isShowTextTab = false;

	// Token: 0x0400069A RID: 1690
	public static MainClan ClanDao;

	// Token: 0x0400069B RID: 1691
	public static bool isOpenDao;

	// Token: 0x0400069C RID: 1692
	public int xRec;

	// Token: 0x0400069D RID: 1693
	public int yRec;

	// Token: 0x0400069E RID: 1694
	public int wRec;

	// Token: 0x0400069F RID: 1695
	public int hRec;

	// Token: 0x040006A0 RID: 1696
	public int colorRec;

	// Token: 0x040006A1 RID: 1697
	public bool isFullScreen;

	// Token: 0x040006A2 RID: 1698
	public static sbyte typePaintGameScreen = 0;

	// Token: 0x040006A3 RID: 1699
	public static int dx = 0;

	// Token: 0x040006A4 RID: 1700
	public static int dy = 0;

	// Token: 0x040006A5 RID: 1701
	private int xWT2 = MotherCanvas.hw - AvMain.wWanted / 2;

	// Token: 0x040006A6 RID: 1702
	private int yWT2 = MotherCanvas.hh - AvMain.hWanted / 2;

	// Token: 0x040006A7 RID: 1703
	public static mVector vecEffSkillSpec = new mVector();

	// Token: 0x040006A8 RID: 1704
	private static int size = MotherCanvas.h / 6;

	// Token: 0x040006A9 RID: 1705
	private long timeBeginAfk;

	// Token: 0x040006AA RID: 1706
	public static int numEff;

	// Token: 0x040006AB RID: 1707
	public static int tickSpam = 0;

	// Token: 0x040006AC RID: 1708
	public static mVector vecEffOnMap = new mVector();

	// Token: 0x040006AD RID: 1709
	public static sbyte typeSuperEffect = -1;

	// Token: 0x040006AE RID: 1710
	public static int tickSuperEffect = 0;

	// Token: 0x040006AF RID: 1711
	public static bool atchat;
}
