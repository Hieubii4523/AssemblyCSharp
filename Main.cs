using System;
using System.Net.NetworkInformation;
using System.Threading;
using UnityEngine;

// Token: 0x02000071 RID: 113
public class Main : MonoBehaviour
{
	// Token: 0x060006E0 RID: 1760 RVA: 0x000969BC File Offset: 0x00094BBC
	private void Start()
	{
		bool flag = !Main.started;
		if (flag)
		{
			bool flag2 = Thread.CurrentThread.Name != "Main";
			if (flag2)
			{
				Thread.CurrentThread.Name = "Main";
			}
			Main.mainThreadName = Thread.CurrentThread.Name;
			GameMidlet.isPC = true;
			Main.started = true;
			bool flag3 = this.lv == 0;
			if (flag3)
			{
				Screen.SetResolution(600, 355, false);
			}
			else
			{
				Screen.SetResolution(1024, 550, false);
			}
			GameCanvas.language = this.language;
		}
	}

	// Token: 0x060006E1 RID: 1761 RVA: 0x0000A853 File Offset: 0x00008A53
	private void SetInit()
	{
		base.enabled = true;
	}

	// Token: 0x060006E2 RID: 1762 RVA: 0x00096A60 File Offset: 0x00094C60
	private void OnHideUnity(bool isGameShown)
	{
		bool flag = !isGameShown;
		if (flag)
		{
			Time.timeScale = 0f;
		}
		else
		{
			Time.timeScale = 1f;
		}
	}

	// Token: 0x060006E3 RID: 1763 RVA: 0x00096A94 File Offset: 0x00094C94
	private void OnGUI()
	{
		bool flag = this.count >= 10;
		if (flag)
		{
			this.checkInput();
			Session_ME.update();
			bool flag2 = Event.current.type.Equals(EventType.Repaint);
			if (flag2)
			{
				GameMidlet.gameCanvas.paint(Main.g);
				this.paintCount++;
				Main.g.reset();
			}
		}
	}

	// Token: 0x060006E4 RID: 1764 RVA: 0x00096B10 File Offset: 0x00094D10
	public void setsizeChange()
	{
		bool flag = !this.isRun;
		if (flag)
		{
			Screen.orientation = ScreenOrientation.LandscapeLeft;
			Application.runInBackground = true;
			Application.targetFrameRate = 30;
			base.useGUILayout = false;
			Main.isCompactDevice = Main.detectCompactDevice();
			bool flag2 = Main.main == null;
			if (flag2)
			{
				Main.main = this;
			}
			this.isRun = true;
			ScaleGUI.initScaleGUI();
			bool isPC = GameMidlet.isPC;
			if (isPC)
			{
				Main.IMEI = SystemInfo.deviceUniqueIdentifier;
			}
			else
			{
				Main.IMEI = this.GetMacAddress();
			}
			GameMidlet.isPC = true;
			bool isPC2 = GameMidlet.isPC;
			if (isPC2)
			{
				Screen.fullScreen = false;
			}
			bool flag3 = Main.isWindowsPhone;
			if (flag3)
			{
				Main.typeClient = 6;
			}
			bool isPC3 = GameMidlet.isPC;
			if (isPC3)
			{
				Main.typeClient = 4;
			}
			bool iphoneVersionApp = Main.IphoneVersionApp;
			if (iphoneVersionApp)
			{
				Main.typeClient = 5;
			}
			bool flag4 = iPhoneSettings.generation == iPhoneGeneration.iPodTouch4Gen;
			if (flag4)
			{
				Main.isIpod = true;
			}
			bool flag5 = iPhoneSettings.generation == iPhoneGeneration.iPhone4;
			if (flag5)
			{
				Main.isIphone4 = true;
			}
			Main.g = new mGraphics();
			Main.midlet = new GameMidlet();
			Key.mapKeyPC();
			Main.g.CreateLineMaterial();
		}
	}

	// Token: 0x060006E5 RID: 1765 RVA: 0x000090B5 File Offset: 0x000072B5
	public static void setBackupIcloud(string path)
	{
	}

	// Token: 0x060006E6 RID: 1766 RVA: 0x00096C44 File Offset: 0x00094E44
	public string GetMacAddress()
	{
		string empty = string.Empty;
		NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
		for (int i = 0; i < allNetworkInterfaces.Length; i++)
		{
			PhysicalAddress physicalAddress = allNetworkInterfaces[i].GetPhysicalAddress();
			bool flag = physicalAddress.ToString() != string.Empty;
			if (flag)
			{
				return physicalAddress.ToString();
			}
		}
		return string.Empty;
	}

	// Token: 0x060006E7 RID: 1767 RVA: 0x000090B5 File Offset: 0x000072B5
	public void doClearRMS()
	{
	}

	// Token: 0x060006E8 RID: 1768 RVA: 0x00096CAC File Offset: 0x00094EAC
	public static void closeKeyBoard()
	{
		bool visible = global::TouchScreenKeyboard.visible;
		if (visible)
		{
			TField.kb.active = false;
			TField.kb = null;
		}
	}

	// Token: 0x060006E9 RID: 1769 RVA: 0x00096CD8 File Offset: 0x00094ED8
	private void FixedUpdate()
	{
		Rms.update();
		this.count++;
		bool flag = this.count < 10;
		if (!flag)
		{
			Image.update();
			this.setsizeChange();
			this.updateCount++;
			ipKeyboard.update();
			GameMidlet.gameCanvas.update();
			DataInputStream.update();
			SMS.update();
			Net.update();
			Main.f++;
			bool flag2 = Main.f > 8;
			if (flag2)
			{
				Main.f = 0;
			}
			bool flag3 = !GameMidlet.isPC;
			if (flag3)
			{
				int num = 1 / Main.a;
			}
			bool isDisConnect = GameCanvas.isDisConnect;
			if (isDisConnect)
			{
				GameCanvas.isDisConnect = false;
				string info = T.disconnect;
				bool flag4 = GameCanvas.infoDisConnect != null && GameCanvas.infoDisConnect.Length > 10;
				if (flag4)
				{
					info = GameCanvas.infoDisConnect;
					GameCanvas.infoDisConnect = string.Empty;
				}
				bool flag5 = false;
				mVector mVector = new mVector();
				bool flag6 = GameCanvas.currentScreen != GameCanvas.loginScr && GameCanvas.currentScreen != GameCanvas.loadMapScr;
				if (flag6)
				{
					mVector.addElement(GameScreen.cmdReConnect);
					flag5 = true;
				}
				mVector.addElement(GameCanvas.gameScr.cmdExit);
				bool flag7 = flag5;
				if (flag7)
				{
					GameCanvas.Start_ReConect_DiaLog(info, mVector, false);
				}
				else
				{
					GameCanvas.Start_Normal_DiaLog(info, mVector, false);
				}
			}
		}
	}

	// Token: 0x060006EA RID: 1770 RVA: 0x000090B5 File Offset: 0x000072B5
	private void Update()
	{
	}

	// Token: 0x060006EB RID: 1771 RVA: 0x00096E48 File Offset: 0x00095048
	private void checkInput()
	{
		bool flag = Input.GetMouseButtonDown(0) && this.valueKey == 0;
		if (flag)
		{
			this.valueKey = 1;
			Vector3 mousePosition = Input.mousePosition;
			GameMidlet.gameCanvas.onPointerPressed((int)(mousePosition.x / (float)mGraphics.zoomLevel), (int)(((float)Screen.height - mousePosition.y) / (float)mGraphics.zoomLevel) + mGraphics.addYWhenOpenKeyBoard);
			this.lastMousePos.x = mousePosition.x / (float)mGraphics.zoomLevel;
			this.lastMousePos.y = mousePosition.y / (float)mGraphics.zoomLevel + (float)mGraphics.addYWhenOpenKeyBoard;
		}
		bool mouseButton = Input.GetMouseButton(0);
		if (mouseButton)
		{
			Vector3 mousePosition2 = Input.mousePosition;
			GameMidlet.gameCanvas.onPointerDragged((int)(mousePosition2.x / (float)mGraphics.zoomLevel), (int)(((float)Screen.height - mousePosition2.y) / (float)mGraphics.zoomLevel) + mGraphics.addYWhenOpenKeyBoard);
			this.lastMousePos.x = mousePosition2.x / (float)mGraphics.zoomLevel;
			this.lastMousePos.y = mousePosition2.y / (float)mGraphics.zoomLevel + (float)mGraphics.addYWhenOpenKeyBoard;
		}
		bool flag2 = Input.GetMouseButtonUp(0) && this.valueKey == 1;
		if (flag2)
		{
			this.valueKey = 0;
			Vector3 mousePosition3 = Input.mousePosition;
			this.lastMousePos.x = mousePosition3.x / (float)mGraphics.zoomLevel;
			this.lastMousePos.y = mousePosition3.y / (float)mGraphics.zoomLevel + (float)mGraphics.addYWhenOpenKeyBoard;
			GameMidlet.gameCanvas.onPointerReleased((int)(mousePosition3.x / (float)mGraphics.zoomLevel), (int)(((float)Screen.height - mousePosition3.y) / (float)mGraphics.zoomLevel) + mGraphics.addYWhenOpenKeyBoard);
		}
		bool flag3 = Input.anyKeyDown && Event.current.type == EventType.KeyDown;
		if (flag3)
		{
			int num = MyKeyMap.map(Event.current.keyCode);
			bool flag4 = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
			if (flag4)
			{
				KeyCode keyCode = Event.current.keyCode;
				KeyCode keyCode2 = keyCode;
				if (keyCode2 != KeyCode.Minus)
				{
					if (keyCode2 == KeyCode.Alpha2)
					{
						num = 64;
					}
				}
				else
				{
					num = 95;
				}
			}
			bool flag5 = num != 0;
			if (flag5)
			{
				GameMidlet.gameCanvas.keyPressed(num);
			}
		}
		bool flag6 = Event.current.type == EventType.KeyUp;
		if (flag6)
		{
			int num2 = MyKeyMap.map(Event.current.keyCode);
			bool flag7 = num2 != 0;
			if (flag7)
			{
				GameMidlet.gameCanvas.keyReleased(num2);
			}
		}
		bool isPC = GameMidlet.isPC;
		if (isPC)
		{
			float x = Input.mousePosition.x;
			float y = Input.mousePosition.y;
			int num3 = (int)x / mGraphics.zoomLevel;
			int num4 = (Screen.height - (int)y) / mGraphics.zoomLevel;
		}
	}

	// Token: 0x060006EC RID: 1772 RVA: 0x00097118 File Offset: 0x00095318
	private void OnApplicationQuit()
	{
		Debug.LogWarning("APP QUIT");
		Session_ME.gI().close();
		bool isPC = GameMidlet.isPC;
		if (isPC)
		{
			Application.Quit();
		}
	}

	// Token: 0x060006ED RID: 1773 RVA: 0x00097150 File Offset: 0x00095350
	private void OnApplicationPause(bool paused)
	{
		Main.isResume = false;
		if (paused)
		{
			Main.isQuitApp = true;
		}
		else
		{
			Main.isResume = true;
		}
		bool visible = global::TouchScreenKeyboard.visible;
		if (visible)
		{
			TField.kb.active = false;
			TField.kb = null;
		}
		bool flag = Main.isQuitApp;
		if (flag)
		{
			Application.Quit();
		}
	}

	// Token: 0x060006EE RID: 1774 RVA: 0x000971A8 File Offset: 0x000953A8
	public static void exit()
	{
		bool isPC = GameMidlet.isPC;
		if (isPC)
		{
			Main.main.OnApplicationQuit();
		}
		else
		{
			Main.a = 0;
		}
	}

	// Token: 0x060006EF RID: 1775 RVA: 0x000971D8 File Offset: 0x000953D8
	public static bool detectCompactDevice()
	{
		bool flag = iPhoneSettings.generation == iPhoneGeneration.iPhone || iPhoneSettings.generation == iPhoneGeneration.iPhone3G || iPhoneSettings.generation == iPhoneGeneration.iPodTouch1Gen || iPhoneSettings.generation == iPhoneGeneration.iPodTouch2Gen;
		return !flag;
	}

	// Token: 0x060006F0 RID: 1776 RVA: 0x00097218 File Offset: 0x00095418
	public static bool checkCanSendSMS()
	{
		return iPhoneSettings.generation == iPhoneGeneration.iPhone3GS || iPhoneSettings.generation == iPhoneGeneration.iPhone4 || iPhoneSettings.generation > iPhoneGeneration.iPodTouch4Gen;
	}

	// Token: 0x04000A17 RID: 2583
	public const sbyte PC_VERSION = 4;

	// Token: 0x04000A18 RID: 2584
	public const sbyte IP_APPSTORE = 5;

	// Token: 0x04000A19 RID: 2585
	public const sbyte WINDOWSPHONE = 6;

	// Token: 0x04000A1A RID: 2586
	public const sbyte IP_JB = 3;

	// Token: 0x04000A1B RID: 2587
	public static Main main;

	// Token: 0x04000A1C RID: 2588
	public static mGraphics g;

	// Token: 0x04000A1D RID: 2589
	public static GameMidlet midlet;

	// Token: 0x04000A1E RID: 2590
	public static string res = "res";

	// Token: 0x04000A1F RID: 2591
	public static string mainThreadName;

	// Token: 0x04000A20 RID: 2592
	public static bool started;

	// Token: 0x04000A21 RID: 2593
	public static bool isIpod;

	// Token: 0x04000A22 RID: 2594
	public static bool isIphone4;

	// Token: 0x04000A23 RID: 2595
	public static bool isWindowsPhone;

	// Token: 0x04000A24 RID: 2596
	public static bool isIPhone;

	// Token: 0x04000A25 RID: 2597
	public static bool IphoneVersionApp;

	// Token: 0x04000A26 RID: 2598
	public static string IMEI;

	// Token: 0x04000A27 RID: 2599
	public static int versionIp;

	// Token: 0x04000A28 RID: 2600
	public static int numberQuit = 1;

	// Token: 0x04000A29 RID: 2601
	public static int typeClient = 4;

	// Token: 0x04000A2A RID: 2602
	public int lv = 1;

	// Token: 0x04000A2B RID: 2603
	public sbyte language;

	// Token: 0x04000A2C RID: 2604
	private int updateCount;

	// Token: 0x04000A2D RID: 2605
	private int paintCount;

	// Token: 0x04000A2E RID: 2606
	private int count;

	// Token: 0x04000A2F RID: 2607
	private bool isRun;

	// Token: 0x04000A30 RID: 2608
	public static int waitTick;

	// Token: 0x04000A31 RID: 2609
	public static int f;

	// Token: 0x04000A32 RID: 2610
	private int valueKey;

	// Token: 0x04000A33 RID: 2611
	public static bool isResume;

	// Token: 0x04000A34 RID: 2612
	public static bool isMiniApp = true;

	// Token: 0x04000A35 RID: 2613
	public static bool isQuitApp;

	// Token: 0x04000A36 RID: 2614
	private Vector2 lastMousePos = default(Vector2);

	// Token: 0x04000A37 RID: 2615
	public static int a = 1;

	// Token: 0x04000A38 RID: 2616
	public static bool isCompactDevice = true;
}
