using System;
using UnityEngine;

// Token: 0x02000034 RID: 52
public class GameMidlet
{
	// Token: 0x060003DA RID: 986 RVA: 0x00009C5E File Offset: 0x00007E5E
	public GameMidlet()
	{
		this.initGame();
	}

	// Token: 0x060003DB RID: 987 RVA: 0x00073384 File Offset: 0x00071584
	public void initGame()
	{
		GameMidlet.instance = this;
		MotherCanvas.instance = new MotherCanvas();
		GameMidlet.instance = this;
		MotherCanvas.instance.checkZoomLevel();
		GameMidlet.google_productIds = new string[]
		{
			"htthgem25",
			"htthgem150",
			"htthgem350",
			"htthgem800",
			"htthgem2500"
		};
		GameMidlet.google_listGems = new string[]
		{
			"0,99$ - 20k Extol + 4 Ruby",
			"2,99$ - 60k Extol + 20 Ruby",
			"100$ - 1M Extol + 5k Ruby",
			"650 Gems ($9.99)",
			"1400 Gems ($24.99)",
			"3750 Gems ($49.99)",
			"8000 Gems ($49.99)"
		};
		GameMidlet.google_productIds_Eng = new string[]
		{
			"pwgem25",
			"pwgem150",
			"pwgem350",
			"pwgem800",
			"pwgem2500"
		};
		GameMidlet.gameCanvas = new GameCanvas();
	}

	// Token: 0x060003DC RID: 988 RVA: 0x00009C6F File Offset: 0x00007E6F
	public void exit()
	{
		mSystem.gcc();
		this.notifyDestroyed();
	}

	// Token: 0x060003DD RID: 989 RVA: 0x00009C7F File Offset: 0x00007E7F
	public static void sendSMS(string data, string to, iCommand successAction, iCommand failAction)
	{
		Cout.println("SEND SMS");
	}

	// Token: 0x060003DE RID: 990 RVA: 0x00009C8D File Offset: 0x00007E8D
	public static void flatForm(string url)
	{
		Cout.LogWarning("PLATFORM REQUEST: " + url);
		Application.OpenURL(url);
	}

	// Token: 0x060003DF RID: 991 RVA: 0x00009CA8 File Offset: 0x00007EA8
	public void notifyDestroyed()
	{
		Main.exit();
	}

	// Token: 0x060003E0 RID: 992 RVA: 0x00009CA8 File Offset: 0x00007EA8
	public void destroy()
	{
		Main.exit();
	}

	// Token: 0x060003E1 RID: 993 RVA: 0x00009CB1 File Offset: 0x00007EB1
	public void platformRequest(string url)
	{
		Cout.LogWarning("PLATFORM REQUEST: " + url);
		Application.OpenURL(url);
	}

	// Token: 0x060003E2 RID: 994 RVA: 0x00009CCC File Offset: 0x00007ECC
	public static void openUrl(string url)
	{
		Application.OpenURL(url);
	}

	// Token: 0x060003E3 RID: 995 RVA: 0x00009CD6 File Offset: 0x00007ED6
	public static void saveRMS(string filename, sbyte[] data)
	{
		Rms.saveRMS(filename, data);
	}

	// Token: 0x060003E4 RID: 996 RVA: 0x00073468 File Offset: 0x00071668
	public static sbyte[] loadRMS(string filename)
	{
		return Rms.loadRMS(filename);
	}

	// Token: 0x060003E5 RID: 997 RVA: 0x00073480 File Offset: 0x00071680
	public static string loginPlus()
	{
		return string.Empty;
	}

	// Token: 0x060003E6 RID: 998 RVA: 0x00009CE1 File Offset: 0x00007EE1
	public static void delRMS(string name)
	{
		Rms.deleteRecord(name);
	}

	// Token: 0x060003E7 RID: 999 RVA: 0x00009CEB File Offset: 0x00007EEB
	public static void delRMS()
	{
		Rms.clearRMS();
	}

	// Token: 0x060003E8 RID: 1000 RVA: 0x00073498 File Offset: 0x00071698
	public static DataInputStream openFile(string path)
	{
		try
		{
			return DataInputStream.getResourceAsStream(Main.res + path);
		}
		catch (Exception e)
		{
			Out.printError(e);
		}
		return null;
	}

	// Token: 0x060003E9 RID: 1001 RVA: 0x000734DC File Offset: 0x000716DC
	public static bool isIosNetwork()
	{
		return false;
	}

	// Token: 0x060003EA RID: 1002 RVA: 0x000734F0 File Offset: 0x000716F0
	public static string SubStr(string str, int begin, int end)
	{
		return str.Substring(begin, end - 1);
	}

	// Token: 0x060003EB RID: 1003 RVA: 0x00009CF4 File Offset: 0x00007EF4
	public static void delAllRms()
	{
		Rms.clearAll();
		Rms.clearRMS();
	}

	// Token: 0x060003EC RID: 1004 RVA: 0x000090B5 File Offset: 0x000072B5
	public static void closeApp()
	{
	}

	// Token: 0x060003ED RID: 1005 RVA: 0x0007350C File Offset: 0x0007170C
	public static string format(string strformat, string str)
	{
		object[] args = new string[]
		{
			str
		};
		return string.Format(strformat, args);
	}

	// Token: 0x060003EE RID: 1006 RVA: 0x00073530 File Offset: 0x00071730
	public static string format(string strformat, string[] args)
	{
		try
		{
			return string.Format(strformat, args);
		}
		catch (Exception)
		{
			mSystem.outloi("loi ghep chuoi");
		}
		return "loi ghep chuoi";
	}

	// Token: 0x060003EF RID: 1007 RVA: 0x00073574 File Offset: 0x00071774
	public static string fixString(string chat)
	{
		return chat;
	}

	// Token: 0x060003F0 RID: 1008 RVA: 0x00073588 File Offset: 0x00071788
	public static string connectHTTP(string Url)
	{
		GameMidlet.achttp = new GameMidlet.connectOk();
		Net.connectHTTP(Url, GameMidlet.achttp);
		return string.Empty;
	}

	// Token: 0x060003F1 RID: 1009 RVA: 0x000090B5 File Offset: 0x000072B5
	public void removeEditText()
	{
	}

	// Token: 0x060003F2 RID: 1010 RVA: 0x000735B8 File Offset: 0x000717B8
	public static string getThongBao()
	{
		bool flag = GameCanvas.language != 0;
		string result;
		if (flag)
		{
			result = GameMidlet.strLinkServerCheckENG;
		}
		else
		{
			bool flag2 = GameCanvas.IndexServer == 0;
			if (flag2)
			{
				result = GameMidlet.strLinkServerCheck;
			}
			else
			{
				result = GameMidlet.strLinkServerCheck2;
			}
		}
		return result;
	}

	// Token: 0x060003F3 RID: 1011 RVA: 0x00009D03 File Offset: 0x00007F03
	public void CheckPerGPS()
	{
		GlobalService.gI().send_GPS();
	}

	// Token: 0x060003F4 RID: 1012 RVA: 0x000090B5 File Offset: 0x000072B5
	public static void makePurchase(string str)
	{
	}

	// Token: 0x060003F5 RID: 1013 RVA: 0x000090B5 File Offset: 0x000072B5
	public static void loginOk()
	{
	}

	// Token: 0x060003F6 RID: 1014 RVA: 0x000090B5 File Offset: 0x000072B5
	public static void CheckThanhToan(string str)
	{
	}

	// Token: 0x040005EC RID: 1516
	public const byte JAVA = 0;

	// Token: 0x040005ED RID: 1517
	public const byte ANDROID = 1;

	// Token: 0x040005EE RID: 1518
	public const byte PC = 2;

	// Token: 0x040005EF RID: 1519
	public const byte IOS = 3;

	// Token: 0x040005F0 RID: 1520
	public const byte WP = 4;

	// Token: 0x040005F1 RID: 1521
	public const byte ANDROID_STORE = 5;

	// Token: 0x040005F2 RID: 1522
	public const byte IOS_STORE = 6;

	// Token: 0x040005F3 RID: 1523
	public static string IP = "112.213.94.23";

	// Token: 0x040005F4 RID: 1524
	public static int PORT = 14445;

	// Token: 0x040005F5 RID: 1525
	public static sbyte PROVIDER;

	// Token: 0x040005F6 RID: 1526
	public static string VERSION = "0.8.4";

	// Token: 0x040005F7 RID: 1527
	public static byte DEVICE = 2;

	// Token: 0x040005F8 RID: 1528
	public static int ITOUCH = 2000;

	// Token: 0x040005F9 RID: 1529
	public static byte ZOOM_IOS = 4;

	// Token: 0x040005FA RID: 1530
	public static GameCanvas gameCanvas;

	// Token: 0x040005FB RID: 1531
	public static GameMidlet instance;

	// Token: 0x040005FC RID: 1532
	public static bool isPC;

	// Token: 0x040005FD RID: 1533
	public static string strLinkServerCheckENG = "http://54.255.184.239/service/thongbao.txt";

	// Token: 0x040005FE RID: 1534
	public static string strLinkServerCheck = "http://teamobi.com/services/ht/t.txt";

	// Token: 0x040005FF RID: 1535
	public static string strLinkServerCheck2 = "http://teamobi.com/services/ht/t2.txt";

	// Token: 0x04000600 RID: 1536
	public static string LONG = string.Empty;

	// Token: 0x04000601 RID: 1537
	public static string LAT = string.Empty;

	// Token: 0x04000602 RID: 1538
	public static string[] google_productIds;

	// Token: 0x04000603 RID: 1539
	public static string[] google_listGems;

	// Token: 0x04000604 RID: 1540
	public static string[] google_productIds_Eng;

	// Token: 0x04000605 RID: 1541
	public static bool isBackWindowsPhone;

	// Token: 0x04000606 RID: 1542
	private static GameMidlet.connectOk achttp;

	// Token: 0x02000035 RID: 53
	public class connectOk : IKAction
	{
		// Token: 0x060003F8 RID: 1016 RVA: 0x00009D11 File Offset: 0x00007F11
		public void perform(string text)
		{
			GameCanvas.infoDisConnect = text;
		}
	}
}
