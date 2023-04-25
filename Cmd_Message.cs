using System;

// Token: 0x0200001A RID: 26
public class Cmd_Message
{
	// Token: 0x06000104 RID: 260 RVA: 0x0001A7CC File Offset: 0x000189CC
	protected void writeInt(int mint)
	{
		try
		{
			this.m.writer().writeInt(mint);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000105 RID: 261 RVA: 0x0001A808 File Offset: 0x00018A08
	protected void writeByte(int by)
	{
		try
		{
			this.m.writer().writeByte(by);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000106 RID: 262 RVA: 0x0001A844 File Offset: 0x00018A44
	protected void writeShort(int by)
	{
		try
		{
			this.m.writer().writeShort(by);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000107 RID: 263 RVA: 0x0001A880 File Offset: 0x00018A80
	public void writeUTF(string str)
	{
		try
		{
			this.m.writer().writeUTF(str);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000108 RID: 264 RVA: 0x0001A8BC File Offset: 0x00018ABC
	protected void writeBoolean(bool boo)
	{
		try
		{
			this.m.writer().writeBoolean(boo);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000109 RID: 265 RVA: 0x00009454 File Offset: 0x00007654
	public void setSession(ISession gi)
	{
		this.session = null;
		this.session = gi;
	}

	// Token: 0x0600010A RID: 266 RVA: 0x00009465 File Offset: 0x00007665
	public void send()
	{
		this.session.sendMessage(this.m);
		this.m.cleanup();
	}

	// Token: 0x0600010B RID: 267 RVA: 0x00009486 File Offset: 0x00007686
	public void init(sbyte cmd)
	{
		this.m = new Message(cmd);
	}

	// Token: 0x04000195 RID: 405
	public const sbyte GET_SESSION_ID = -27;

	// Token: 0x04000196 RID: 406
	public const sbyte SUDO = -108;

	// Token: 0x04000197 RID: 407
	public const sbyte GET_DATA_INFO_POTION = -105;

	// Token: 0x04000198 RID: 408
	public const sbyte WEAPON_FASHION = -104;

	// Token: 0x04000199 RID: 409
	public const sbyte REGISTER_NEW = -103;

	// Token: 0x0400019A RID: 410
	public const sbyte CHECK_AFK = -102;

	// Token: 0x0400019B RID: 411
	public const sbyte LOAD_IMAGE_BIG = -101;

	// Token: 0x0400019C RID: 412
	public const sbyte TEST_CMD = -100;

	// Token: 0x0400019D RID: 413
	public const sbyte LOGIN_PLUS = -99;

	// Token: 0x0400019E RID: 414
	public const sbyte TICH_LUY_CONG_DON = -97;

	// Token: 0x0400019F RID: 415
	public const sbyte TICH_TIEU = -96;

	// Token: 0x040001A0 RID: 416
	public const sbyte HUY_HIEU_CLAN_VIP = -95;

	// Token: 0x040001A1 RID: 417
	public const sbyte UPGRADE_DIAL = -94;

	// Token: 0x040001A2 RID: 418
	public const sbyte LOAD_IMAGE_BIG_NEW = -93;

	// Token: 0x040001A3 RID: 419
	public const sbyte LOAD_IMAGE_NEW = -92;

	// Token: 0x040001A4 RID: 420
	public const sbyte DAU_GIA = -91;

	// Token: 0x040001A5 RID: 421
	public const sbyte TICH_LUY_NAP_THE = -90;

	// Token: 0x040001A6 RID: 422
	public const sbyte LENH_TRUY_NA = -89;

	// Token: 0x040001A7 RID: 423
	public const sbyte DONOT_AUTO_RE = -88;

	// Token: 0x040001A8 RID: 424
	public const sbyte EVENT_POKE = -87;

	// Token: 0x040001A9 RID: 425
	public const sbyte CHEST_WANTED = -86;

	// Token: 0x040001AA RID: 426
	public const sbyte ROOM_WANTED = -85;

	// Token: 0x040001AB RID: 427
	public const sbyte DISCONNECT_WHY = -84;

	// Token: 0x040001AC RID: 428
	public const sbyte UPDATE_MP_HP_NEW = -83;

	// Token: 0x040001AD RID: 429
	public const sbyte GET_DATA_PART = -82;

	// Token: 0x040001AE RID: 430
	public const sbyte INPUT_PASSWORD = -81;

	// Token: 0x040001AF RID: 431
	public const sbyte PET = -80;

	// Token: 0x040001B0 RID: 432
	public const sbyte LITTLE_GARDEN = -79;

	// Token: 0x040001B1 RID: 433
	public const sbyte ATTRIBUTE_PLAYER = -78;

	// Token: 0x040001B2 RID: 434
	public const sbyte CHUYEN_HOA = -77;

	// Token: 0x040001B3 RID: 435
	public const sbyte UPDATE_INFO_MAIN_CHAR_INFO = -75;

	// Token: 0x040001B4 RID: 436
	public const sbyte CHECK_LIST_PHO_BANG = -74;

	// Token: 0x040001B5 RID: 437
	public const sbyte TIME_SHOW = -73;

	// Token: 0x040001B6 RID: 438
	public const sbyte RED_LINE = -72;

	// Token: 0x040001B7 RID: 439
	public const sbyte AUTO_REVICE = -71;

	// Token: 0x040001B8 RID: 440
	public const sbyte NUM_PLAYER_MAP = -70;

	// Token: 0x040001B9 RID: 441
	public const sbyte DIALOG_TIME = -69;

	// Token: 0x040001BA RID: 442
	public const sbyte BUY_GEM = -68;

	// Token: 0x040001BB RID: 443
	public const sbyte REBUILD_ITEM = -67;

	// Token: 0x040001BC RID: 444
	public const sbyte UPDATE_PVP_POINT = -66;

	// Token: 0x040001BD RID: 445
	public const sbyte BEGIN_GAME = -65;

	// Token: 0x040001BE RID: 446
	public const sbyte BUY_POTION_OK = -64;

	// Token: 0x040001BF RID: 447
	public const sbyte PVP = -63;

	// Token: 0x040001C0 RID: 448
	public const sbyte UPDATE_PART_BOAT = -62;

	// Token: 0x040001C1 RID: 449
	public const sbyte COUNT_DOWN_TICKET = -61;

	// Token: 0x040001C2 RID: 450
	public const sbyte BUY_ITEM_SHOP = -60;

	// Token: 0x040001C3 RID: 451
	public const sbyte UPDATE_CREATE_USER_OK = -59;

	// Token: 0x040001C4 RID: 452
	public const sbyte INPUT_SERVER = -58;

	// Token: 0x040001C5 RID: 453
	public const sbyte FRIST_LOGIN = -57;

	// Token: 0x040001C6 RID: 454
	public const sbyte BOAT_IN_MAP = -56;

	// Token: 0x040001C7 RID: 455
	public const sbyte GHOST = -55;

	// Token: 0x040001C8 RID: 456
	public const sbyte HELP_SERVER = -54;

	// Token: 0x040001C9 RID: 457
	public const sbyte SHIP = -53;

	// Token: 0x040001CA RID: 458
	public const sbyte CLAN = -52;

	// Token: 0x040001CB RID: 459
	public const sbyte LOAD_IMAGE = -51;

	// Token: 0x040001CC RID: 460
	public const sbyte SPLIT_ITEM = -50;

	// Token: 0x040001CD RID: 461
	public const sbyte TRADE = -49;

	// Token: 0x040001CE RID: 462
	public const sbyte UPGRADE_ITEM = -48;

	// Token: 0x040001CF RID: 463
	public const sbyte SET_WEATHER = -47;

	// Token: 0x040001D0 RID: 464
	public const sbyte WORLD_CHANEL = -46;

	// Token: 0x040001D1 RID: 465
	public const sbyte UPDATE_PK_POINT = -45;

	// Token: 0x040001D2 RID: 466
	public const sbyte EFF_AUTO = -44;

	// Token: 0x040001D3 RID: 467
	public const sbyte EXIT_VIEW = -43;

	// Token: 0x040001D4 RID: 468
	public const sbyte SHOW_PLAYER_INFO = -42;

	// Token: 0x040001D5 RID: 469
	public const sbyte SET_SHOW_IMAGE_ANDROID = -41;

	// Token: 0x040001D6 RID: 470
	public const sbyte OK_IMAGE_ANDROID = -40;

	// Token: 0x040001D7 RID: 471
	public const sbyte SAVE_IMAGE_ANDROID = -39;

	// Token: 0x040001D8 RID: 472
	public const sbyte REQUEST_IMAGE_ANDROID = -38;

	// Token: 0x040001D9 RID: 473
	public const sbyte DEL_CHAR = -37;

	// Token: 0x040001DA RID: 474
	public const sbyte MOVE_TO_PLAYER = -36;

	// Token: 0x040001DB RID: 475
	public const sbyte FIGHT = -35;

	// Token: 0x040001DC RID: 476
	public const sbyte SHOW_GIFT = -34;

	// Token: 0x040001DD RID: 477
	public const sbyte SAVE_RMS = -33;

	// Token: 0x040001DE RID: 478
	public const sbyte CHEST = -32;

	// Token: 0x040001DF RID: 479
	public const sbyte NOTIFY_SERVER = -31;

	// Token: 0x040001E0 RID: 480
	public const sbyte LIST_FROM_SERVER = -30;

	// Token: 0x040001E1 RID: 481
	public const sbyte FRIEND = -29;

	// Token: 0x040001E2 RID: 482
	public const sbyte LEARN_SKILL = -28;

	// Token: 0x040001E3 RID: 483
	public const sbyte REGISTER = -26;

	// Token: 0x040001E4 RID: 484
	public const sbyte PARTY = -25;

	// Token: 0x040001E5 RID: 485
	public const sbyte GET_INFO_NPC = -24;

	// Token: 0x040001E6 RID: 486
	public const sbyte QUEST = -23;

	// Token: 0x040001E7 RID: 487
	public const sbyte USE_ITEM = -22;

	// Token: 0x040001E8 RID: 488
	public const sbyte SELL_ITEM = -21;

	// Token: 0x040001E9 RID: 489
	public const sbyte DYNAMIC_MENU = -20;

	// Token: 0x040001EA RID: 490
	public const sbyte SHOP_NPC = -19;

	// Token: 0x040001EB RID: 491
	public const sbyte BUY_ITEM_POTION = -18;

	// Token: 0x040001EC RID: 492
	public const sbyte ADD_POINT_SKILL = -17;

	// Token: 0x040001ED RID: 493
	public const sbyte ADD_POINT_ATTRIBUTE = -16;

	// Token: 0x040001EE RID: 494
	public const sbyte EFF_OBJ = -15;

	// Token: 0x040001EF RID: 495
	public const sbyte UPDATE_MP_HP = -14;

	// Token: 0x040001F0 RID: 496
	public const sbyte USE_POTION = -13;

	// Token: 0x040001F1 RID: 497
	public const sbyte UPDATE_INVENTORY = -12;

	// Token: 0x040001F2 RID: 498
	public const sbyte DIALOG_SERVER = -11;

	// Token: 0x040001F3 RID: 499
	public const sbyte MAIN_CHAR_INFO = -10;

	// Token: 0x040001F4 RID: 500
	public const sbyte SELECT_CHAR = -9;

	// Token: 0x040001F5 RID: 501
	public const sbyte CREATE_CHAR = -8;

	// Token: 0x040001F6 RID: 502
	public const sbyte GET_DATA = -7;

	// Token: 0x040001F7 RID: 503
	public const sbyte CHECK_DATA_VERSION = -6;

	// Token: 0x040001F8 RID: 504
	public const sbyte CHAR_INFO = -5;

	// Token: 0x040001F9 RID: 505
	public const sbyte LIST_CHAR = -4;

	// Token: 0x040001FA RID: 506
	public const sbyte LOGIN = -2;

	// Token: 0x040001FB RID: 507
	public const sbyte CHANGE_MAP = 0;

	// Token: 0x040001FC RID: 508
	public const sbyte OBJ_MOVE = 1;

	// Token: 0x040001FD RID: 509
	public const sbyte PLAYER_FIRE = 2;

	// Token: 0x040001FE RID: 510
	public const sbyte REMOVE_CHAR = 3;

	// Token: 0x040001FF RID: 511
	public const sbyte MONSTER_INFO = 4;

	// Token: 0x04000200 RID: 512
	public const sbyte MONSTER_NONE_FOCUS = 5;

	// Token: 0x04000201 RID: 513
	public const sbyte PLAYER_REVICE = 6;

	// Token: 0x04000202 RID: 514
	public const sbyte PLAYER_DIE = 7;

	// Token: 0x04000203 RID: 515
	public const sbyte GET_XP_MAP_TRAIN = 9;

	// Token: 0x04000204 RID: 516
	public const sbyte UPDATE_XP = 10;

	// Token: 0x04000205 RID: 517
	public const sbyte ITEM_DROP = 11;

	// Token: 0x04000206 RID: 518
	public const sbyte GET_ITEM_MAP = 12;

	// Token: 0x04000207 RID: 519
	public const sbyte REMOVE_OBJ = 13;

	// Token: 0x04000208 RID: 520
	public const sbyte PK = 14;

	// Token: 0x04000209 RID: 521
	public const sbyte LIST_PK = 15;

	// Token: 0x0400020A RID: 522
	public const sbyte LIST_NPC = 16;

	// Token: 0x0400020B RID: 523
	public const sbyte CHAT_POPUP = 17;

	// Token: 0x0400020C RID: 524
	public const sbyte CHAT_TAB = 18;

	// Token: 0x0400020D RID: 525
	public const sbyte CHAR_WEARING = 19;

	// Token: 0x0400020E RID: 526
	public const sbyte BUFF = 20;

	// Token: 0x0400020F RID: 527
	public const sbyte CHANGE_AREA = 21;

	// Token: 0x04000210 RID: 528
	public const sbyte SKILL_PLAYER_MAP_TRAIN = 22;

	// Token: 0x04000211 RID: 529
	public const sbyte STATUS_AREA = 23;

	// Token: 0x04000212 RID: 530
	public const sbyte DIE_MONSTER = 24;

	// Token: 0x04000213 RID: 531
	public const sbyte NUM_ITEM_QUEST = 25;

	// Token: 0x04000214 RID: 532
	public const sbyte TELEPORT_BOSS = 26;

	// Token: 0x04000215 RID: 533
	public const sbyte BUFF_SPEC = 27;

	// Token: 0x04000216 RID: 534
	public const sbyte ADD_HP_EFF = 28;

	// Token: 0x04000217 RID: 535
	public const sbyte COMBO_SKILL = 29;

	// Token: 0x04000218 RID: 536
	public const sbyte OK_CHANGE_MAP_LINK = 30;

	// Token: 0x04000219 RID: 537
	public const sbyte UPDATE_NAME_NPC = 31;

	// Token: 0x0400021A RID: 538
	public const sbyte PARTY_BUFF = 32;

	// Token: 0x0400021B RID: 539
	public const sbyte GET_ITEM_MAP_LITTLE = 33;

	// Token: 0x0400021C RID: 540
	public const sbyte NEXT_MAP = 34;

	// Token: 0x0400021D RID: 541
	public const sbyte CHANGE_MAP_NON_DATA = 35;

	// Token: 0x0400021E RID: 542
	public const sbyte PVP_TYPE = 36;

	// Token: 0x0400021F RID: 543
	public const sbyte ARCHI_DAILY = 37;

	// Token: 0x04000220 RID: 544
	public const sbyte TABLE_MATCH = 38;

	// Token: 0x04000221 RID: 545
	public const sbyte UPDATE_XP_ARENA = 39;

	// Token: 0x04000222 RID: 546
	public const sbyte NEW_DIALOG = 40;

	// Token: 0x04000223 RID: 547
	public const sbyte TYPE_NPC_EVENT = 41;

	// Token: 0x04000224 RID: 548
	public const sbyte TIME_ITEM_DROP = 42;

	// Token: 0x04000225 RID: 549
	public const sbyte PAINT_CLIENT = 43;

	// Token: 0x04000226 RID: 550
	public const sbyte MARKET = 44;

	// Token: 0x04000227 RID: 551
	public const sbyte DEVIL_UPGRADE = 45;

	// Token: 0x04000228 RID: 552
	public const sbyte CHECK_PLAYER_IN_MAP = 46;

	// Token: 0x04000229 RID: 553
	public const sbyte CMD_EVENT = 47;

	// Token: 0x0400022A RID: 554
	public const sbyte CMD_GET_TEMPLATE = 48;

	// Token: 0x0400022B RID: 555
	public const sbyte ONE_POINT_MAX_LEVEL = 49;

	// Token: 0x0400022C RID: 556
	public const sbyte OPEN_MESSENGER = 50;

	// Token: 0x0400022D RID: 557
	public const sbyte UPDATE_LOL = 51;

	// Token: 0x0400022E RID: 558
	public const sbyte QUICK_CHAT = 52;

	// Token: 0x0400022F RID: 559
	public const sbyte UPDATE_POINT_WW = 53;

	// Token: 0x04000230 RID: 560
	public const sbyte QUAY_SO = 54;

	// Token: 0x04000231 RID: 561
	public const sbyte UPDATE_MP_HP_EFF = 55;

	// Token: 0x04000232 RID: 562
	public const sbyte EFF_KICH_AN = 57;

	// Token: 0x04000233 RID: 563
	public const sbyte COUNT_KICK_AVA = 58;

	// Token: 0x04000234 RID: 564
	public const sbyte GIAOTIEP_FORMSERVER = 59;

	// Token: 0x04000235 RID: 565
	public const sbyte DAILY_LOGIN = 60;

	// Token: 0x04000236 RID: 566
	public const sbyte GPS_GIFTCODE = 61;

	// Token: 0x04000237 RID: 567
	public const sbyte CLAN_DAMAGE_LIST = 62;

	// Token: 0x04000238 RID: 568
	public const sbyte GET_INFO_CLAN_DAO = 63;

	// Token: 0x04000239 RID: 569
	public const sbyte LIST_ITEM_GIFT_AREA = 64;

	// Token: 0x0400023A RID: 570
	public const sbyte GET_TOP_PLAYER = 65;

	// Token: 0x0400023B RID: 571
	public const sbyte UPGRADE_SUPER_ITEM = 66;

	// Token: 0x0400023C RID: 572
	public const sbyte TITLE_ROOM_FIGHT = 67;

	// Token: 0x0400023D RID: 573
	public const sbyte CHANGE_HAIR = 68;

	// Token: 0x0400023E RID: 574
	public const sbyte USE_ITEM_SELECT_ONE_ON_MORE = 69;

	// Token: 0x0400023F RID: 575
	public const sbyte UPDATE_XP_SKILL = 70;

	// Token: 0x04000240 RID: 576
	public const sbyte TRONG_CAY = 71;

	// Token: 0x04000241 RID: 577
	public const sbyte INFO_BODY_FASHION = 72;

	// Token: 0x04000242 RID: 578
	public const sbyte VONG_SINH_TU = 73;

	// Token: 0x04000243 RID: 579
	public const sbyte GET_BYTE_DATA_EFF = 74;

	// Token: 0x04000244 RID: 580
	public const sbyte TRANG_TRI = 75;

	// Token: 0x04000245 RID: 581
	public const sbyte GET_BYTE_DATA_EFF_BIG = 76;

	// Token: 0x04000246 RID: 582
	public const sbyte QUAY_OC_SEN = 77;

	// Token: 0x04000247 RID: 583
	public const sbyte HANH_TRINH = 79;

	// Token: 0x04000248 RID: 584
	public const sbyte EVENT = 80;

	// Token: 0x04000249 RID: 585
	public const sbyte UPGRADE_SKIN = 81;

	// Token: 0x0400024A RID: 586
	public const sbyte QUAY_WC = 82;

	// Token: 0x0400024B RID: 587
	public const sbyte GOOGLE_CMD = 99;

	// Token: 0x0400024C RID: 588
	public const sbyte FIRE_NEW = 100;

	// Token: 0x0400024D RID: 589
	public const sbyte CLAN_FIGHT = 101;

	// Token: 0x0400024E RID: 590
	public const sbyte NAP_THE = 102;

	// Token: 0x0400024F RID: 591
	public const sbyte TANG_RUBY = 103;

	// Token: 0x04000250 RID: 592
	public ISession session = Session_ME.gI();

	// Token: 0x04000251 RID: 593
	protected Message m;
}
