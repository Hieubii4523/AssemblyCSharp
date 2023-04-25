using System;

// Token: 0x02000111 RID: 273
public class UpdateImageScreen : MainScreen
{
	// Token: 0x06000FC0 RID: 4032 RVA: 0x0012F928 File Offset: 0x0012DB28
	public UpdateImageScreen()
	{
		this.maxwPaint = 122;
		this.hpaint = 14;
		this.x = MotherCanvas.hw;
		this.y = MotherCanvas.h / 5 * 4 - 7;
		bool flag = GameCanvas.isIos();
		if (flag)
		{
			this.isCheckIOSZoom = true;
		}
		else
		{
			this.beginLoadImage();
		}
		this.timeBegin = mSystem.currentTimeMillis();
		UpdateImageScreen.statusUpdate = 0;
		UpdateImageScreen.setmNamePaint(T.pleaseWaiting);
		this.loadImage();
	}

	// Token: 0x06000FC1 RID: 4033 RVA: 0x0012F9B0 File Offset: 0x0012DBB0
	public void loadImage()
	{
		bool flag = GameCanvas.language == 1;
		if (flag)
		{
			this.imglogo = mImage.createImage("/new/lgv_e.png");
		}
		else
		{
			this.imglogo = mImage.createImage("/new/lgv.png");
		}
		this.imgloading1 = mImage.createImage("/new/koload.png");
		this.imgloading2 = mImage.createImage("/new/load.png");
		this.imgloading3 = mImage.createImage("/new/thuyen.png");
		this.imgsea = mImage.createImageAll("/up0.png");
		this.imgsky = mImage.createImageAll("/up1.png");
		this.wSky = mImage.getImageWidth(this.imgsky.image);
		this.hSky = mImage.getImageHeight(this.imgsky.image);
		this.wSea = mImage.getImageWidth(this.imgsea.image);
		this.hSea = mImage.getImageHeight(this.imgsea.image);
	}

	// Token: 0x06000FC2 RID: 4034 RVA: 0x0012FA98 File Offset: 0x0012DC98
	public override void paint(mGraphics g)
	{
		g.setColor(6014975);
		g.fillRect(0, 0, MotherCanvas.w, MotherCanvas.h / 2);
		g.setColor(16765819);
		g.fillRect(0, MotherCanvas.h / 2, MotherCanvas.w, MotherCanvas.h / 2);
		for (int i = 0; i <= MotherCanvas.w / this.wSky; i++)
		{
			g.drawImage(this.imgsky, i * this.wSky, MotherCanvas.hh - this.hSky / 2, 0);
		}
		for (int j = 0; j <= MotherCanvas.w / this.wSea; j++)
		{
			g.drawImage(this.imgsea, j * this.wSea, MotherCanvas.hh + this.hSky / 2, 0);
		}
		bool flag = this.imglogo != null;
		if (flag)
		{
			g.drawImage(this.imglogo, MotherCanvas.hw, MotherCanvas.h / 5, 3);
		}
		g.setColor(0);
		bool flag2 = this.isCheckIOSZoom;
		if (flag2)
		{
			g.drawString(T.ZoomIos1, MotherCanvas.hw, this.y - 20 + 7, 2);
			g.drawString(T.ZoomIos2, MotherCanvas.hw, this.y - 5 + 7, 2);
			g.setColor(0);
			g.fillRect(MotherCanvas.hw - 50, this.y - 5 + 7 + 20 - 10, 30, 20);
			g.fillRect(MotherCanvas.hw - 15, this.y - 5 + 7 + 20 - 10, 30, 20);
			g.fillRect(MotherCanvas.hw + 20, this.y - 5 + 7 + 20 - 10, 30, 20);
			g.setColor(16777215);
			g.fillRect(MotherCanvas.hw - 50 + 1, this.y - 5 + 7 + 20 - 10 + 1, 28, 18);
			g.fillRect(MotherCanvas.hw - 15 + 1, this.y - 5 + 7 + 20 - 10 + 1, 28, 18);
			g.fillRect(MotherCanvas.hw + 20 + 1, this.y - 5 + 7 + 20 - 10 + 1, 28, 18);
			g.drawString(T.ratThap, MotherCanvas.hw - 35, this.y + 5 + 20, 2);
			g.drawString(T.Thap, MotherCanvas.hw, this.y + 5 + 20, 2);
			g.drawString(T.Cao, MotherCanvas.hw + 35, this.y + 5 + 20, 2);
		}
		else
		{
			g.drawString(UpdateImageScreen.strPaint, MotherCanvas.hw, this.y - 20 + 7, 2);
			bool flag3 = UpdateImageScreen.statusUpdate == 2 || UpdateImageScreen.statusUpdate == 3;
			if (flag3)
			{
				g.drawImage(this.imgloading1, this.x - 61, this.y - 8, 0);
				bool flag4 = this.wpaint >= 0;
				if (flag4)
				{
					g.drawRegion(this.imgloading2, 0, 0, this.wpaint, 16, 0, (float)(this.x - 61), (float)(this.y - 8), 0);
				}
				int num = this.wpaint;
				bool flag5 = num < 10;
				if (flag5)
				{
					num = 10;
				}
				bool flag6 = num > this.maxwPaint - 12;
				if (flag6)
				{
					num = this.maxwPaint - 12;
				}
				g.drawString(UpdateImageScreen.curNum.ToString() + " / " + UpdateImageScreen.maxNum.ToString(), MotherCanvas.hw, this.y + 4, 2);
				g.drawImage(this.imgloading3, this.x - 60 + num, this.y, 3);
			}
		}
	}

	// Token: 0x06000FC3 RID: 4035 RVA: 0x0012FE70 File Offset: 0x0012E070
	public override void update()
	{
		bool flag = this.isCheckIOSZoom;
		if (!flag)
		{
			bool flag2 = UpdateImageScreen.maxNum > 0;
			if (flag2)
			{
				this.wpaint = this.maxwPaint * UpdateImageScreen.curNum / UpdateImageScreen.maxNum;
				bool flag3 = this.wpaint > this.maxwPaint;
				if (flag3)
				{
					this.wpaint = this.maxwPaint;
				}
			}
			bool flag4 = UpdateImageScreen.statusUpdate == 0 && (GameCanvas.timeNow - this.timeBegin) / 1000L > 15L;
			if (flag4)
			{
				bool flag5 = GameCanvas.indexdownload == 0;
				if (flag5)
				{
					Session_ME.gI().close();
					GameCanvas.indexdownload++;
					GameCanvas.connectDownload();
					GlobalService.gI().Request_Image_Android();
					this.timeBegin = GameCanvas.timeNow;
				}
				else
				{
					UpdateImageScreen.setmNamePaint(T.disconnectUpdateImage);
					UpdateImageScreen.statusUpdate = 1;
				}
			}
			bool flag6 = UpdateImageScreen.statusUpdate == 3 && SaveImageRMS.vecSaveImageAndroid.size() == 0;
			if (flag6)
			{
				GameCanvas.instance.beginGame();
				this.saveVer();
			}
		}
	}

	// Token: 0x06000FC4 RID: 4036 RVA: 0x0012FF88 File Offset: 0x0012E188
	public override void updatePointer()
	{
		bool flag = this.isCheckIOSZoom;
		if (flag)
		{
			bool flag2 = GameCanvas.isPoint(MotherCanvas.hw - 50, this.y - 5 + 7 + 20 - 10, 30, 20);
			if (flag2)
			{
				GameMidlet.ZOOM_IOS = 1;
				GameCanvas.instance.beginGame();
				this.saveVer();
				CRes.saveRMS("SUB_ZOOMIOS", new sbyte[]
				{
					(sbyte)GameMidlet.ZOOM_IOS
				});
			}
			bool flag3 = GameCanvas.isPoint(MotherCanvas.hw - 15, this.y - 5 + 7 + 20 - 10, 30, 20);
			if (flag3)
			{
				GameMidlet.ZOOM_IOS = 2;
				GameCanvas.instance.beginGame();
				this.saveVer();
				CRes.saveRMS("SUB_ZOOMIOS", new sbyte[]
				{
					(sbyte)GameMidlet.ZOOM_IOS
				});
			}
			else
			{
				bool flag4 = GameCanvas.isPoint(MotherCanvas.hw + 20, this.y - 5 + 7 + 20 - 10, 30, 20);
				if (flag4)
				{
					GameCanvas.instance.beginGame();
					this.saveVer();
				}
			}
		}
		else
		{
			bool flag5 = UpdateImageScreen.statusUpdate == 1 && GameCanvas.isPointerDown;
			if (flag5)
			{
				Session_ME.gI().close();
				GameCanvas.indexdownload++;
				GameCanvas.connectDownload();
				GlobalService.gI().Request_Image_Android();
				this.timeBegin = GameCanvas.timeNow;
				UpdateImageScreen.statusUpdate = 0;
				UpdateImageScreen.setmNamePaint(T.pleaseWaiting);
			}
			base.updatePointer();
		}
	}

	// Token: 0x06000FC5 RID: 4037 RVA: 0x001300FC File Offset: 0x0012E2FC
	public static void setValueUpdate(int cur, int max)
	{
		UpdateImageScreen.curNum = cur;
		bool flag = max >= 0;
		if (flag)
		{
			UpdateImageScreen.maxNum = max;
		}
		UpdateImageScreen.statusUpdate = 2;
	}

	// Token: 0x06000FC6 RID: 4038 RVA: 0x0000C292 File Offset: 0x0000A492
	public static void setmNamePaint(string str)
	{
		UpdateImageScreen.strPaint = str;
	}

	// Token: 0x06000FC7 RID: 4039 RVA: 0x0013012C File Offset: 0x0012E32C
	public void saveVer()
	{
		ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
		DataOutputStream dataOutputStream = new DataOutputStream(byteArrayOutputStream);
		try
		{
			dataOutputStream.writeUTF("1.2.3");
			CRes.saveRMS("Main_Load_Image_Android_OK", byteArrayOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000FC8 RID: 4040 RVA: 0x0000C29B File Offset: 0x0000A49B
	public void beginLoadImage()
	{
		this.isCheckIOSZoom = false;
		Session_ME.gI().close();
		GameCanvas.connectDownload();
		GlobalService.gI().Request_Image_Android();
	}

	// Token: 0x04001A36 RID: 6710
	public const sbyte CONNECT = 0;

	// Token: 0x04001A37 RID: 6711
	public const sbyte FAIL = 1;

	// Token: 0x04001A38 RID: 6712
	public const sbyte LOADING = 2;

	// Token: 0x04001A39 RID: 6713
	public const sbyte LOADING_OK = 3;

	// Token: 0x04001A3A RID: 6714
	public static int maxNum;

	// Token: 0x04001A3B RID: 6715
	public static int curNum;

	// Token: 0x04001A3C RID: 6716
	private int wpaint = -1;

	// Token: 0x04001A3D RID: 6717
	private int maxwPaint;

	// Token: 0x04001A3E RID: 6718
	private int x;

	// Token: 0x04001A3F RID: 6719
	private int y;

	// Token: 0x04001A40 RID: 6720
	private int hpaint;

	// Token: 0x04001A41 RID: 6721
	private long timeBegin;

	// Token: 0x04001A42 RID: 6722
	public static sbyte statusUpdate;

	// Token: 0x04001A43 RID: 6723
	public static string strPaint = string.Empty;

	// Token: 0x04001A44 RID: 6724
	private mImage imglogo;

	// Token: 0x04001A45 RID: 6725
	private mImage imgsea;

	// Token: 0x04001A46 RID: 6726
	private mImage imgsky;

	// Token: 0x04001A47 RID: 6727
	private mImage imgloading1;

	// Token: 0x04001A48 RID: 6728
	private mImage imgloading2;

	// Token: 0x04001A49 RID: 6729
	private mImage imgloading3;

	// Token: 0x04001A4A RID: 6730
	private int wSky;

	// Token: 0x04001A4B RID: 6731
	private int wSea;

	// Token: 0x04001A4C RID: 6732
	private int hSky;

	// Token: 0x04001A4D RID: 6733
	private int hSea;

	// Token: 0x04001A4E RID: 6734
	private bool isCheckIOSZoom;
}
