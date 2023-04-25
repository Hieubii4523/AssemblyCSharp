using System;

// Token: 0x02000038 RID: 56
public class GlobalLogicHandler
{
	// Token: 0x06000453 RID: 1107 RVA: 0x00077C7C File Offset: 0x00075E7C
	public static GlobalLogicHandler gI()
	{
		bool flag = GlobalLogicHandler.instance == null;
		if (flag)
		{
			GlobalLogicHandler.instance = new GlobalLogicHandler();
		}
		return GlobalLogicHandler.instance;
	}

	// Token: 0x06000454 RID: 1108 RVA: 0x00077CAC File Offset: 0x00075EAC
	public void onConnectFail()
	{
		bool flag = GameCanvas.currentScreen == GameCanvas.updateImageAndroidScr;
		if (!flag)
		{
			bool flag2 = GameMidlet.DEVICE == 0;
			if (flag2)
			{
				string info = T.connectfail;
				bool flag3 = GameCanvas.infoDisConnect != null && GameCanvas.infoDisConnect.Length > 10;
				if (flag3)
				{
					info = GameCanvas.infoDisConnect;
					GameCanvas.infoDisConnect = string.Empty;
				}
				GameScreen.cmdCheckServer = new iCommand(T.kiemtra, 46, GameCanvas.gameScr);
				GameCanvas.Start_Normal_DiaLog(info, GameScreen.cmdCheckServer, true);
			}
			else
			{
				string info2 = T.connectfail;
				bool flag4 = GameCanvas.getHourTime() == 5 && GameCanvas.language == 0;
				if (flag4)
				{
					info2 = T.baotridinhky;
				}
				bool flag5 = GameCanvas.infoDisConnect != null && GameCanvas.infoDisConnect.Length > 10;
				if (flag5)
				{
					info2 = GameCanvas.infoDisConnect;
					GameCanvas.infoDisConnect = string.Empty;
				}
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(info2);
			}
		}
	}

	// Token: 0x06000455 RID: 1109 RVA: 0x000090B5 File Offset: 0x000072B5
	public void onConnectOK()
	{
	}

	// Token: 0x06000456 RID: 1110 RVA: 0x00009F9A File Offset: 0x0000819A
	public static void onDisconnect()
	{
		mSystem.outz("disconect global");
		GameCanvas.dialogDisconect();
	}

	// Token: 0x040006B0 RID: 1712
	public static GlobalLogicHandler instance;
}
