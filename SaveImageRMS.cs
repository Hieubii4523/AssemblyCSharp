using System;

// Token: 0x020000DF RID: 223
public class SaveImageRMS
{
	// Token: 0x06000D6F RID: 3439 RVA: 0x0000BCD0 File Offset: 0x00009ED0
	public void run()
	{
		SaveImageRMS.SaveImage();
	}

	// Token: 0x06000D70 RID: 3440 RVA: 0x00104D68 File Offset: 0x00102F68
	public static void SaveImage()
	{
		while (SaveImageRMS.vecSaveImage.size() > 0 || SaveImageRMS.vecSaveImageAndroid.size() > 0)
		{
			try
			{
				bool flag = SaveImageRMS.vecSaveImage.size() > 0;
				if (flag)
				{
					idSaveImage idSaveImage = (idSaveImage)SaveImageRMS.vecSaveImage.elementAt(0);
					ObjectData.setToRms(idSaveImage.mbytImage, idSaveImage.id);
					SaveImageRMS.vecSaveImage.removeElementAt(0);
				}
				bool flag2 = SaveImageRMS.vecSaveImageAndroid.size() > 0;
				if (flag2)
				{
					try
					{
						UpdateImageScreen.curNum = UpdateImageScreen.maxNum - SaveImageRMS.vecSaveImageAndroid.size();
						idSaveImage idSaveImage2 = (idSaveImage)SaveImageRMS.vecSaveImageAndroid.elementAt(0);
						ObjectData.saveImageToRmsAndroid(idSaveImage2.mbytImage, idSaveImage2.name);
					}
					catch (Exception)
					{
					}
					SaveImageRMS.vecSaveImageAndroid.removeElementAt(0);
				}
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x06000D71 RID: 3441 RVA: 0x0000BCD0 File Offset: 0x00009ED0
	public void start()
	{
		SaveImageRMS.SaveImage();
	}

	// Token: 0x040014C0 RID: 5312
	public static mVector vecSaveImage = new mVector("SaveImageRMS.vecSaveImage");

	// Token: 0x040014C1 RID: 5313
	public static mVector vecSaveImageAndroid = new mVector("SaveImageRMS.vecSaveImageAndroid");
}
