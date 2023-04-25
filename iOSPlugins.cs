using System;
using System.Runtime.InteropServices;
using UnityEngine;

// Token: 0x02000056 RID: 86
public class iOSPlugins
{
	// Token: 0x060005FC RID: 1532
	[DllImport("__Internal")]
	private static extern void _SMSsend(string tophone, string withtext, int n);

	// Token: 0x060005FD RID: 1533
	[DllImport("__Internal")]
	private static extern int _unpause();

	// Token: 0x060005FE RID: 1534
	[DllImport("__Internal")]
	private static extern int _checkRotation();

	// Token: 0x060005FF RID: 1535
	[DllImport("__Internal")]
	private static extern int _back();

	// Token: 0x06000600 RID: 1536
	[DllImport("__Internal")]
	private static extern int _Send();

	// Token: 0x06000601 RID: 1537
	[DllImport("__Internal")]
	private static extern void _purchaseItem(string itemID, string userName, string gameID);

	// Token: 0x06000602 RID: 1538 RVA: 0x0008A484 File Offset: 0x00088684
	public static int Check()
	{
		bool flag = Application.platform == RuntimePlatform.IPhonePlayer;
		int result;
		if (flag)
		{
			result = iOSPlugins.checkCanSendSMS();
		}
		else
		{
			iOSPlugins.devide = iPhoneSettings.generation.ToString();
			string a = string.Empty + iOSPlugins.devide[2].ToString();
			bool flag2 = a == "h" && iOSPlugins.devide.Length > 6;
			if (flag2)
			{
				iOSPlugins.Myname = SystemInfo.operatingSystem.ToString();
				string a2 = string.Empty + iOSPlugins.Myname[10].ToString();
				bool flag3 = a2 != "2" && a2 != "3";
				if (flag3)
				{
					result = 0;
				}
				else
				{
					result = 1;
				}
			}
			else
			{
				Cout.println(iOSPlugins.devide + "  loai");
				bool flag4 = iOSPlugins.devide == "Unknown" && ScaleGUI.WIDTH * ScaleGUI.HEIGHT < 786432f;
				if (flag4)
				{
					result = 0;
				}
				else
				{
					result = -1;
				}
			}
		}
		return result;
	}

	// Token: 0x06000603 RID: 1539 RVA: 0x0008A5A8 File Offset: 0x000887A8
	public static int checkCanSendSMS()
	{
		bool flag = iPhoneSettings.generation == iPhoneGeneration.iPhone3GS || iPhoneSettings.generation == iPhoneGeneration.iPhone4 || iPhoneSettings.generation == iPhoneGeneration.iPhone4S || iPhoneSettings.generation == iPhoneGeneration.iPhone5;
		int result;
		if (flag)
		{
			result = 0;
		}
		else
		{
			result = -1;
		}
		return result;
	}

	// Token: 0x06000604 RID: 1540 RVA: 0x0008A5EC File Offset: 0x000887EC
	public static void SMSsend(string phonenumber, string bodytext, int n)
	{
		bool flag = Application.platform > RuntimePlatform.OSXEditor;
		if (flag)
		{
			iOSPlugins._SMSsend(phonenumber, bodytext, n);
		}
	}

	// Token: 0x06000605 RID: 1541 RVA: 0x0008A614 File Offset: 0x00088814
	public static void back()
	{
		bool flag = Application.platform > RuntimePlatform.OSXEditor;
		if (flag)
		{
			iOSPlugins._back();
		}
	}

	// Token: 0x06000606 RID: 1542 RVA: 0x0008A638 File Offset: 0x00088838
	public static void Send()
	{
		bool flag = Application.platform > RuntimePlatform.OSXEditor;
		if (flag)
		{
			iOSPlugins._Send();
		}
	}

	// Token: 0x06000607 RID: 1543 RVA: 0x0008A65C File Offset: 0x0008885C
	public static int unpause()
	{
		bool flag = Application.platform > RuntimePlatform.OSXEditor;
		int result;
		if (flag)
		{
			result = iOSPlugins._unpause();
		}
		else
		{
			result = 0;
		}
		return result;
	}

	// Token: 0x06000608 RID: 1544 RVA: 0x0008A684 File Offset: 0x00088884
	public static int checkRotation()
	{
		bool flag = Application.platform > RuntimePlatform.OSXEditor;
		int result;
		if (flag)
		{
			result = iOSPlugins._checkRotation();
		}
		else
		{
			result = 0;
		}
		return result;
	}

	// Token: 0x06000609 RID: 1545 RVA: 0x0008A6AC File Offset: 0x000888AC
	public static void purchaseItem(string itemID, string userName, string gameID)
	{
		bool flag = Application.platform > RuntimePlatform.OSXEditor;
		if (flag)
		{
			iOSPlugins._purchaseItem(itemID, userName, gameID);
		}
	}

	// Token: 0x040008BF RID: 2239
	public static string devide;

	// Token: 0x040008C0 RID: 2240
	public static string Myname;
}
