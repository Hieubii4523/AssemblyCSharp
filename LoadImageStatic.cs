using System;

// Token: 0x0200006C RID: 108
public class LoadImageStatic
{
	// Token: 0x06000684 RID: 1668 RVA: 0x0008F6B0 File Offset: 0x0008D8B0
	public static void LoadAllImage()
	{
		SmallImage.loadBigRMS();
		Interface_Game.imgInfoServer = LoadImageStatic.LoadNewInterface("/backinfo.png");
		AvMain.imgBgnum = LoadImageStatic.LoadNewInterface("/bgnum.png");
		AvMain.imgBgnum2 = LoadImageStatic.LoadNewInterface("/bgnum2.png");
		MainObject.imgShadow = LoadImageStatic.LoadNewInterface("/shadow.png");
		AvMain.imgCombo = LoadImageStatic.LoadNewInterface("/combo.png");
		AvMain.imgNenfocus = LoadImageStatic.LoadNewInterface("/nenfocus.png");
		AvMain.imgShadowSmall = LoadImageStatic.LoadNewInterface("/shadowsmall.png");
		AvMain.imgDelay = LoadImageStatic.LoadNewInterface("/delayskill.png");
		AvMain.fraIconMenu = new FrameImage(mImage.createImage("/point/iconmenu.png"), 30, 30);
		AvMain.fraIconHome = new FrameImage(mImage.createImage("/point/iconhome.png"), 30, 30);
		AvMain.fraEffOpen = new FrameImage(mImage.createImage("/interface/effopen.png"), 25, 25);
		AvMain.fraEffDasieucap = new FrameImage(mImage.createImage("/interface/eff_dasieucap.png"), 20, 20);
		try
		{
			AvMain.fraPlus = new FrameImage(mImage.createImage("/interface/iconplus.png"), 24, 24);
		}
		catch (Exception)
		{
		}
		AvMain.fraUniform = new FrameImage(mImage.createImage("/interface/coloruniform.png"), 8, 8);
		AvMain.fraBtLogin = new FrameImage(mImage.createImage("/interface/btlogin.png"), 19, 19);
		AvMain.fraNew = new FrameImage(mImage.createImage("/interface/franew.png"), 27, 21);
		AvMain.fraDelay2 = new FrameImage(LoadImageStatic.LoadNewInterface("/delayskill3.png"), 24, 24);
		AvMain.fraDelay = new FrameImage(LoadImageStatic.LoadNewInterface("/delayskill2.png"), 32, 32);
		GameScreen.interfaceGame.load_Image_Pointer();
		Interface_Game.imgIconMPHP = mImage.createImage("/interface/iconmphp.png");
		Interface_Game.imgIconMPHP2 = mImage.createImage("/interface/iconmphp2.png");
		MsgDialog.fraImgWaiting = new FrameImage(mImage.createImage("/interface/waiting2.png"), 21, 21);
		AvMain.imgSelect = mImage.createImage("/interface/selected_hand.png");
		AvMain.imgHotKey = mImage.createImage("/interface/hotkey.png");
		AvMain.imgEffCur = mImage.createImage("/interface/effcur.png");
		Interface_Game.imgBorderNoti = mImage.createImage("/interface/bordernoti.png");
		Interface_Game.imgBorderNoti2 = mImage.createImage("/interface/bordernoti2.png");
		Interface_Game.fraBorderNoti = new FrameImage(mImage.createImage("/interface/bordernoti3.png"), 27, 27);
		Interface_Game.fraBorderNoti4 = new FrameImage(mImage.createImage("/interface/bordernoti4.png"), 21, 17);
		bool flag = !GameCanvas.isTouch;
		if (flag)
		{
			AvMain.imgMess = mImage.createImage("/interface/mess2.png");
		}
		else
		{
			AvMain.imgMess = mImage.createImage("/interface/mess.png");
		}
		AvMain.imgChat = mImage.createImage("/interface/chat2.png");
		AvMain.imgBorderCombo = mImage.createImage("/interface/bordercombo.png");
		AvMain.imgDaKham = mImage.createImage("/interface/slot.png");
		AvMain.imgDonateClan = mImage.createImage("/interface/donateclan.png");
		AvMain.imgLvClan = mImage.createImage("/interface/lvclan.png");
		AvMain.imgBannerClan = mImage.createImage("/interface/bannerclan.png");
		AvMain.imgPlusClan = mImage.createImage("/interface/plusclan.png");
		AvMain.imgBorderIcon = mImage.createImage("/interface/bordericon.png");
		AvMain.imgReward = mImage.createImage("/interface/reward.png");
		AvMain.imgTabClan = mImage.createImage("/interface/tabclan.png");
		AvMain.imgChatClan = mImage.createImage("/interface/chatclan.png");
		AvMain.fraIconNpc = new FrameImage(mImage.createImage("/interface/iconnpc.png"), 18, 18);
		AvMain.fraShadowFocus = new FrameImage(mImage.createImage("/interface/shadowfocus.png"), 30, 16);
		AvMain.imgEye = mImage.createImage("/interface/eye.png");
		AvMain.imgXp = mImage.createImage("/interface/iconxp.png");
		AvMain.imgcheck = mImage.createImage("/interface/iconcheck.png");
		AvMain.fraIconfocus = new FrameImage(mImage.createImage("/interface/iconfocus.png"), 14, 14);
		AvMain.fraStatusOnline = new FrameImage(mImage.createImage("/interface/statusonline.png"), 5, 5);
		AvMain.imgIconDel = mImage.createImage("/interface/icondel.png");
		AvMain.imgDieChar = mImage.createImage("/interface/icondie.png");
		AvMain.imgBeri = mImage.createImage("/interface/wanted14.png");
		AvMain.imgArrowListServer = mImage.createImage("/interface/arrowlist.png");
		AvMain.imgInfoLock = mImage.createImage("/interface/infolock.png");
		AvMain.imgInfoClass = mImage.createImage("/interface/infoclass.png");
		AvMain.imgInfoStar = mImage.createImage("/interface/infostar.png");
		AvMain.imgBannerRuong = mImage.createImage("/interface/bannerruong0.png");
		AvMain.imgLoadImage = new FrameImage(mImage.createImage("/interface/loadimg.png"), 16, 16);
		AvMain.fraComboSkill = new FrameImage(mImage.createImage("/interface/g0.png"), 14, 14);
		AvMain.imgButton = new mImage[2];
		for (int i = 0; i < AvMain.imgButton.Length; i++)
		{
			AvMain.imgButton[i] = mImage.createImage("/interface/button" + i.ToString() + ".png");
		}
		AvMain.imgLock = mImage.createImage("/interface/lock.png");
		AvMain.imgHinhnhan = mImage.createImage("/interface/hinhnhan.png");
		AvMain.imgLvDevilSkill = mImage.createImage("/interface/lvdevilskill.png");
		MainTab.mImgTab = new mImage[2];
		for (int j = 0; j < MainTab.mImgTab.Length; j++)
		{
			MainTab.mImgTab[j] = mImage.createImage("/interface/tab" + j.ToString() + ".png");
		}
		MainTab.fraCloseTab = new FrameImage(mImage.createImage("/point/closetab.png"), 18, 18);
		MainTab.fraCloseTab2 = new FrameImage(mImage.createImage("/interface/xclose.png"), 18, 18);
		MainTab.fraCloseTab3 = new FrameImage(mImage.createImage("/point/closetab3.png"), 18, 18);
		MainTab.fraCmdMo = new FrameImage(mImage.createImage("/point/cmd_mo.png"), 71, 26);
		AvMain.fraMoney = new FrameImage(mImage.createImage("/interface/money.png"), 12, 12);
		AvMain.fraPk = new FrameImage(mImage.createImage("/interface/iconpk.png"), 12, 12);
		AvMain.fraPk2 = new FrameImage(mImage.createImage("/interface/iconpk2.png"), 16, 16);
		AvMain.fraPirate = new FrameImage(mImage.createImage("/interface/iconpirate.png"), 11, 14);
		AvMain.fraDiePlayer = new FrameImage(mImage.createImage("/interface/icondie.png"), 38, 44);
		AvMain.fraQuest = new FrameImage(mImage.createImage("/interface/quest.png"), 13, 19);
		AvMain.fratf = new FrameImage(mImage.createImage("/interface/tf.png"), 6, 6);
		AvMain.fraIconWanted = new FrameImage(mImage.createImage("/interface/iconwanted.png"), 16, 16);
		AvMain.fratf1 = new FrameImage(mImage.createImage("/interface/tf1.png"), 6, 6);
		AvMain.fraCheck = new FrameImage(mImage.createImage("/interface/check.png"), 13, 13);
		AvMain.fraTwoTab = new FrameImage(mImage.createImage("/interface/two_tab.png"), 11, 16);
		AvMain.fraIconClan = new FrameImage(mImage.createImage("/interface/iconclan.png"), 23, 16);
		AvMain.fraBorderClan = new FrameImage(mImage.createImage("/interface/borderclan.png"), 4, 4);
		AvMain.fraBorderClan2 = new FrameImage(mImage.createImage("/interface/borderclan2.png"), 20, 26, 5);
		AvMain.fraEffItem = new FrameImage(mImage.createImage("/interface/effitem.png"), 7, 7);
		AvMain.fraEffItem2 = new FrameImage(mImage.createImage("/interface/effitem_2.png"), 9, 9);
		AvMain.fraBorderSkill = new FrameImage(mImage.createImage("/interface/borderskill.png"), 26, 26);
		AvMain.fraEventMoon = new FrameImage(253, 20, 20, 3);
		for (int k = 0; k < PopupChat.mPopup.Length; k++)
		{
			PopupChat.mPopup[k] = mImage.createImage("/interface/chatpopup" + k.ToString() + ".png");
		}
		AvMain.mImgThanhTich = new mImage[2];
		for (int l = 0; l < 2; l++)
		{
			AvMain.mImgThanhTich[l] = mImage.createImage("/interface/thanhtich" + l.ToString() + ".png");
		}
		Item_Drop.imgMainIconXp = new MainImage(mImage.createImage("/interface/iconxp.png"));
		MainEvent.fraEvent = new FrameImage(mImage.createImage("/interface/event.png"), 22, 22);
		MainEvent.imgNew = mImage.createImage("/interface/new.png");
		MainItem.imgColorItem = mImage.createImage("/interface/coloritem.png");
		Boat.fraPirateUnity = new FrameImage(mImage.createImage("/bg/pirate.png"), 18, 15);
		Boat.imgShip = mImage.createImage("/bg/ship.png");
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			AvMain.fraMoveTo = new FrameImage(mImage.createImage("/interface/moveto.png"), 32, 11);
			AvMain.fraAutoFire = new FrameImage(mImage.createImage("/point/other_10.png"), 18, 18);
		}
		LoadImageStatic.loadImageLanguage();
		LoadImageStatic.LoadLowGraphic();
		LoadImageStatic.LoadWantedPaperSrcImg();
	}

	// Token: 0x06000685 RID: 1669 RVA: 0x0008FF0C File Offset: 0x0008E10C
	public static void LoadImgMatch()
	{
		AvMain.imgFightMatch = mImage.createImage("/interface/fightmatch.png");
		AvMain.imgStarMatch = mImage.createImage("/interface/starmatch.png");
		bool flag = GameCanvas.language == 1;
		if (flag)
		{
			AvMain.fraMatch = new FrameImage(mImage.createImage("/interface/match_e.png"), 93, 23);
		}
		else
		{
			AvMain.fraMatch = new FrameImage(mImage.createImage("/interface/match.png"), 93, 23);
		}
	}

	// Token: 0x06000686 RID: 1670 RVA: 0x0008FF7C File Offset: 0x0008E17C
	public static void loadImageLanguage()
	{
		Interface_Game.mImgPvPType = null;
		bool flag = GameCanvas.language == 1;
		if (flag)
		{
			AvMain.imgLg = mImage.createImage("/interface/lgv_e.png");
		}
		else
		{
			bool flag2 = MotherCanvas.h >= 240;
			if (flag2)
			{
				AvMain.imgLg = mImage.createImage("/interface/lgv.png");
			}
			else
			{
				AvMain.imgLg = mImage.createImage("/interface/lgv_2.png");
			}
		}
		LoginScreen.hLogo = mImage.getImageHeight(AvMain.imgLg.image) / 2;
	}

	// Token: 0x06000687 RID: 1671 RVA: 0x0008FFFC File Offset: 0x0008E1FC
	public static mImage LoadImageNew(string str)
	{
		return mImage.createImage(str);
	}

	// Token: 0x06000688 RID: 1672 RVA: 0x00090014 File Offset: 0x0008E214
	public static mImage LoadNewInterface(string str)
	{
		string text = string.Empty;
		text = ((!GameCanvas.lowGraphic) ? "/interface" : "/w_interface");
		text += str;
		return mImage.createImage(text);
	}

	// Token: 0x06000689 RID: 1673 RVA: 0x0000A7A9 File Offset: 0x000089A9
	public static void LoadImgPvP()
	{
		AvMain.imgPvpVs = mImage.createImage("/interface/pvpvs.png");
		AvMain.imgPvpOk = mImage.createImage("/interface/pvpok.png");
		AvMain.imgPvpObjdef = mImage.createImage("/interface/pvpobjdef.png");
	}

	// Token: 0x0600068A RID: 1674 RVA: 0x00090050 File Offset: 0x0008E250
	public static void LoadLowGraphic()
	{
		bool lowGraphic = GameCanvas.lowGraphic;
		if (!lowGraphic)
		{
			AvMain.imgPaperDoc = new mImage[8];
			for (int i = 0; i < AvMain.imgPaperDoc.Length; i++)
			{
				AvMain.imgPaperDoc[i] = mImage.createImage("/interface/paper_" + i.ToString() + ".png");
			}
			AvMain.mimgBgA = new mImage[26];
			for (int j = 0; j < AvMain.mimgBgA.Length; j++)
			{
				AvMain.mimgBgA[j] = mImage.createImage("/interface/bga" + j.ToString() + ".png");
			}
			bool flag = GameMidlet.DEVICE == 0;
			if (flag)
			{
				AvMain.mimgWanted = new mImage[18];
				for (int k = 0; k < AvMain.mimgWanted.Length; k++)
				{
					AvMain.mimgWanted[k] = mImage.createImage("/interface/wanted" + k.ToString() + ".png");
				}
			}
			else
			{
				AvMain.imgWanted = mImage.createImage("/interface/wanted.png");
			}
			AvMain.fraImgEffOnMap0 = new FrameImage(LoadImageStatic.LoadNewInterface("/eff_inmap0.png"), 12, 12);
			AvMain.imgPaper = new mImage[8];
			for (int l = 0; l < AvMain.imgPaper.Length; l++)
			{
				AvMain.imgPaper[l] = mImage.createImage("/interface/paper" + l.ToString() + ".png");
			}
			Boat.imgEffSea = mImage.createImage("/bg/boateff.png");
			Boat.imgEffSea2 = mImage.createImage("/bg/boateff2.png");
			Boat.fraEffSea = new FrameImage(mImage.createImage("/bg/sea4.png"), 24, 24);
			Boat.fraEffSea2 = new FrameImage(mImage.createImage("/bg/sea5.png"), 72, 13);
			Boat.fraEffSea3 = new FrameImage(mImage.createImage("/bg/sea6.png"), 45, 13);
			Interface_Game.imgHoavan = mImage.createImage("/interface/hoavan.png");
			MsgDialog.fraAutoMpHp = new FrameImage(mImage.createImage("/interface/automphp.png"), 20, 20);
			LoadImageStatic.loadImageEffBoat();
			AvMain.fraIconServer = new FrameImage(mImage.createImage("/interface/iconserver.png"), 37, 45);
			AvMain.fraBtBanhlai = new FrameImage(mImage.createImage("/interface/frabanhlai.png"), 53, 53);
			AvMain.fraBorderWanted = new FrameImage(mImage.createImage("/interface/borderwanted.png"), 13, 28);
			AvMain.fraButtonTiemNang = new FrameImage(mImage.createImage("/interface/button_tiemnang.png"), 30, 28);
			AvMain.fraEffBoss = new FrameImage(mImage.createImage("/interface/effboss.png"), 32, 22);
			Interface_Game.imgInfo = mImage.createImage("/interface/info.png");
			AvMain.mImgRoomW = new mImage[5];
			for (int m = 0; m < AvMain.mImgRoomW.Length; m++)
			{
				AvMain.mImgRoomW[m] = mImage.createImage("/interface/roomw" + m.ToString() + ".png");
			}
			AvMain.fraEquip = new FrameImage(mImage.createImage("/interface/equip.png"), 18, 19);
			AvMain.fraThongThao = new FrameImage(mImage.createImage("/interface/thong_thao.png"), 89, 21);
			AvMain.fraBanhLai = new FrameImage(mImage.createImage("/interface/banh_lai.png"), 33, 33);
			AvMain.mimgWanted2 = new mImage[29];
		}
	}

	// Token: 0x0600068B RID: 1675 RVA: 0x00090388 File Offset: 0x0008E588
	public static void loadImageEffBoat()
	{
		bool flag = !GameCanvas.lowGraphic;
		if (flag)
		{
			bool flag2 = LoadMapScreen.isMapSky == 1;
			if (flag2)
			{
				Boat.imgEffSea = mImage.createImage("/bg/boateff4.png");
				Boat.fraEffSea = new FrameImage(mImage.createImage("/bg/sea4fly.png"), 24, 24);
				Boat.fraEffSea2 = new FrameImage(mImage.createImage("/bg/sea5fly.png"), 72, 13);
				Boat.fraEffSea3 = new FrameImage(mImage.createImage("/bg/sea6fly.png"), 45, 13);
			}
			else
			{
				Boat.imgEffSea = mImage.createImage("/bg/boateff.png");
				Boat.imgEffSea2 = mImage.createImage("/bg/boateff2.png");
				Boat.imgEffSea3 = mImage.createImage("/bg/boateff3.png");
				Boat.fraEffSea = new FrameImage(mImage.createImage("/bg/sea4.png"), 24, 24);
				Boat.fraEffSea2 = new FrameImage(mImage.createImage("/bg/sea5.png"), 72, 13);
				Boat.fraEffSea3 = new FrameImage(mImage.createImage("/bg/sea6.png"), 45, 13);
				Boat.fraEffSea4 = new FrameImage(mImage.createImage("/bg/sea7.png"), 24, 24);
			}
		}
	}

	// Token: 0x0600068C RID: 1676 RVA: 0x000904A0 File Offset: 0x0008E6A0
	public static void loadImageBgB()
	{
		bool flag = !GameCanvas.lowGraphic;
		if (flag)
		{
			AvMain.mimgBgB = new mImage[9];
			for (int i = 0; i < AvMain.mimgBgB.Length; i++)
			{
				AvMain.mimgBgB[i] = mImage.createImage("/interface/bgb" + i.ToString() + ".png");
			}
		}
	}

	// Token: 0x0600068D RID: 1677 RVA: 0x00090504 File Offset: 0x0008E704
	public static void loadImageBgC()
	{
		bool flag = !GameCanvas.lowGraphic;
		if (flag)
		{
			AvMain.mimgBgC = new mImage[9];
			for (int i = 0; i < AvMain.mimgBgC.Length; i++)
			{
				AvMain.mimgBgC[i] = mImage.createImage("/interface/bgc" + i.ToString() + ".png");
			}
		}
	}

	// Token: 0x0600068E RID: 1678 RVA: 0x00090568 File Offset: 0x0008E768
	public static FrameImage loadFraImage(string link, int w, int h)
	{
		return new FrameImage(mImage.createImage(link), w, h);
	}

	// Token: 0x0600068F RID: 1679 RVA: 0x00090588 File Offset: 0x0008E788
	private static void LoadWantedPaperSrcImg()
	{
		AvMain.imgDemoWanted = mImage.createImage("/interface/0_demo1.png");
		AvMain.imgTrangTri = mImage.createImage("/interface/1_wanted.png");
		AvMain.imgDuoi = new mImage[4];
		for (int i = 0; i < AvMain.imgDuoi.Length; i++)
		{
			AvMain.imgDuoi[i] = mImage.createImage("/interface/4_duoi_" + (i + 1).ToString() + ".png");
		}
		AvMain.imgGiua = new mImage[4];
		for (int j = 0; j < AvMain.imgGiua.Length; j++)
		{
			AvMain.imgGiua[j] = mImage.createImage("/interface/4_giua_" + (j + 1).ToString() + ".png");
		}
		AvMain.imgPhai = new mImage[5];
		for (int k = 0; k < AvMain.imgPhai.Length; k++)
		{
			AvMain.imgPhai[k] = mImage.createImage("/interface/4_phai_" + (k + 1).ToString() + ".png");
		}
		AvMain.imgTrai = new mImage[5];
		for (int l = 0; l < AvMain.imgTrai.Length; l++)
		{
			AvMain.imgTrai[l] = mImage.createImage("/interface/4_trai_" + (l + 1).ToString() + ".png");
		}
		AvMain.imgTren = new mImage[4];
		for (int m = 0; m < AvMain.imgTren.Length; m++)
		{
			AvMain.imgTren[m] = mImage.createImage("/interface/4_tren_" + (m + 1).ToString() + ".png");
		}
		AvMain.imgGoc = new mImage[4];
		AvMain.imgGoc[0] = mImage.createImage("/interface/4_giay_tren_trai.png");
		AvMain.imgGoc[1] = mImage.createImage("/interface/4_giay_tren_phai.png");
		AvMain.imgGoc[2] = mImage.createImage("/interface/4_giay_duoi_trai.png");
		AvMain.imgGoc[3] = mImage.createImage("/interface/4_giay_duoi_phai.png");
		AvMain.imgKhung = new mImage[2];
		AvMain.imgKhung[0] = mImage.createImage("/interface/khung.png");
		AvMain.imgKhung[1] = mImage.createImage("/interface/khung_1.png");
		AvMain.imgComplete = mImage.createImage("/interface/complete.png");
		AvMain.imgKhungMem = mImage.createImage("/interface/1.png");
		AvMain.imgKhungItem = mImage.createImage("/interface/03.png");
		AvMain.fraCmdNhanNapThe = new FrameImage(mImage.createImage("/interface/04.png"), 52, 20);
		AvMain.fraNauBanh = new FrameImage(mImage.createImage("/interface/pvpnew1.png"), 3);
		AvMain.fraTrongCay = new FrameImage(mImage.createImage("/interface/typecay.png"), 3);
		AvMain.imgDialogTrangTri = new mImage[17];
		for (int n = 0; n < 17; n++)
		{
			bool flag = n < 10;
			if (flag)
			{
				AvMain.imgDialogTrangTri[n] = mImage.createImage("/interface/tt0" + n.ToString() + ".png");
			}
			else
			{
				AvMain.imgDialogTrangTri[n] = mImage.createImage("/interface/tt" + n.ToString() + ".png");
			}
		}
	}
}
