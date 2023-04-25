﻿using System;
using System.IO;
using System.Threading;
using UnityEngine;

// Token: 0x020000DC RID: 220
public class Rms
{
	// Token: 0x06000D4A RID: 3402 RVA: 0x00103800 File Offset: 0x00101A00
	public static void saveRMS(string filename, sbyte[] data)
	{
		bool flag = Thread.CurrentThread.Name == Main.mainThreadName;
		if (flag)
		{
			Rms.__saveRMS("x" + mGraphics.zoomLevel.ToString() + filename, data);
		}
		else
		{
			Rms._saveRMS("x" + mGraphics.zoomLevel.ToString() + filename, data);
		}
	}

	// Token: 0x06000D4B RID: 3403 RVA: 0x00103864 File Offset: 0x00101A64
	public static sbyte[] loadRMS(string filename)
	{
		bool flag = Thread.CurrentThread.Name == Main.mainThreadName;
		sbyte[] result;
		if (flag)
		{
			result = Rms.__loadRMS("x" + mGraphics.zoomLevel.ToString() + filename);
		}
		else
		{
			result = Rms._loadRMS("x" + mGraphics.zoomLevel.ToString() + filename);
		}
		return result;
	}

	// Token: 0x06000D4C RID: 3404 RVA: 0x001038C8 File Offset: 0x00101AC8
	public static string loadRMSString(string fileName)
	{
		sbyte[] array = Rms.loadRMS(fileName);
		bool flag = array == null;
		string result;
		if (flag)
		{
			result = null;
		}
		else
		{
			DataInputStream dataInputStream = new DataInputStream(array);
			try
			{
				string result2 = dataInputStream.readUTF();
				dataInputStream.close();
				return result2;
			}
			catch (Exception ex)
			{
				Cout.println(ex.StackTrace);
			}
			result = null;
		}
		return result;
	}

	// Token: 0x06000D4D RID: 3405 RVA: 0x0007F150 File Offset: 0x0007D350
	public static byte[] convertSbyteToByte(sbyte[] var)
	{
		byte[] array = new byte[var.Length];
		for (int i = 0; i < var.Length; i++)
		{
			bool flag = var[i] > 0;
			if (flag)
			{
				array[i] = (byte)var[i];
			}
			else
			{
				array[i] = (byte)((int)var[i] + 256);
			}
		}
		return array;
	}

	// Token: 0x06000D4E RID: 3406 RVA: 0x00103930 File Offset: 0x00101B30
	public static void saveRMSString(string filename, string data)
	{
		DataOutputStream dataOutputStream = new DataOutputStream();
		try
		{
			dataOutputStream.writeUTF(data);
			Rms.saveRMS(filename, dataOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception ex)
		{
			Cout.println(ex.StackTrace);
		}
	}

	// Token: 0x06000D4F RID: 3407 RVA: 0x00103988 File Offset: 0x00101B88
	private static void _saveRMS(string filename, sbyte[] data)
	{
		bool flag = Rms.status != 0;
		if (flag)
		{
			Debug.LogError("Cannot save RMS " + filename + " because current is saving " + Rms.filename);
		}
		else
		{
			Rms.filename = filename;
			Rms.data = data;
			Rms.status = 2;
			int i;
			for (i = 0; i < 500; i++)
			{
				Thread.Sleep(5);
				bool flag2 = Rms.status == 0;
				if (flag2)
				{
					break;
				}
			}
			bool flag3 = i == 500;
			if (flag3)
			{
				Debug.LogError("TOO LONG TO SAVE RMS " + filename);
			}
		}
	}

	// Token: 0x06000D50 RID: 3408 RVA: 0x00103A20 File Offset: 0x00101C20
	private static sbyte[] _loadRMS(string filename)
	{
		bool flag = Rms.status != 0;
		sbyte[] result;
		if (flag)
		{
			Debug.LogError("Cannot load RMS " + filename + " because current is loading " + Rms.filename);
			result = null;
		}
		else
		{
			Rms.filename = filename;
			Rms.data = null;
			Rms.status = 3;
			int i;
			for (i = 0; i < 500; i++)
			{
				Thread.Sleep(5);
				bool flag2 = Rms.status == 0;
				if (flag2)
				{
					break;
				}
			}
			bool flag3 = i == 500;
			if (flag3)
			{
				Debug.LogError("TOO LONG TO LOAD RMS " + filename);
			}
			result = Rms.data;
		}
		return result;
	}

	// Token: 0x06000D51 RID: 3409 RVA: 0x00103AC4 File Offset: 0x00101CC4
	public static void update()
	{
		bool flag = Rms.status == 2;
		if (flag)
		{
			Rms.status = 1;
			Rms.__saveRMS(Rms.filename, Rms.data);
			Rms.status = 0;
		}
		else
		{
			bool flag2 = Rms.status == 3;
			if (flag2)
			{
				Rms.status = 1;
				Rms.data = Rms.__loadRMS(Rms.filename);
				Rms.status = 0;
			}
		}
	}

	// Token: 0x06000D52 RID: 3410 RVA: 0x00103B28 File Offset: 0x00101D28
	public static int loadRMSInt(string file)
	{
		sbyte[] array = Rms.loadRMS(file);
		return (int)((array != null) ? array[0] : -1);
	}

	// Token: 0x06000D53 RID: 3411 RVA: 0x00103B4C File Offset: 0x00101D4C
	public static void saveRMSInt(string file, int x)
	{
		try
		{
			Rms.saveRMS(file, new sbyte[]
			{
				(sbyte)x
			});
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D54 RID: 3412 RVA: 0x00103B88 File Offset: 0x00101D88
	public static string GetiPhoneDocumentsPath()
	{
		return Application.persistentDataPath;
	}

	// Token: 0x06000D55 RID: 3413 RVA: 0x00103BA0 File Offset: 0x00101DA0
	private static void __saveRMS(string filename, sbyte[] data)
	{
		string text = Rms.GetiPhoneDocumentsPath() + "/" + filename;
		FileStream fileStream = new FileStream(text, FileMode.Create);
		fileStream.Write(ArrayCast.cast(data), 0, data.Length);
		fileStream.Flush();
		fileStream.Close();
		Main.setBackupIcloud(text);
	}

	// Token: 0x06000D56 RID: 3414 RVA: 0x00103BF0 File Offset: 0x00101DF0
	private static sbyte[] __loadRMS(string filename)
	{
		sbyte[] result;
		try
		{
			FileStream fileStream = new FileStream(Rms.GetiPhoneDocumentsPath() + "/" + filename, FileMode.Open);
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, array.Length);
			fileStream.Close();
			sbyte[] array2 = ArrayCast.cast(array);
			result = ArrayCast.cast(array);
		}
		catch (Exception)
		{
			result = null;
		}
		return result;
	}

	// Token: 0x06000D57 RID: 3415 RVA: 0x00103C60 File Offset: 0x00101E60
	public static void clearAll()
	{
		Debug.LogWarning("ALL RMS CLEAR");
		PlayerPrefs.DeleteAll();
		FileInfo[] files = new DirectoryInfo(Rms.GetiPhoneDocumentsPath() + "/").GetFiles();
		foreach (FileInfo fileInfo in files)
		{
			fileInfo.Delete();
		}
	}

	// Token: 0x06000D58 RID: 3416 RVA: 0x00103CB8 File Offset: 0x00101EB8
	public static void DeleteStorage(string path)
	{
		try
		{
			File.Delete(Rms.GetiPhoneDocumentsPath() + "/" + path);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D59 RID: 3417 RVA: 0x00103CF8 File Offset: 0x00101EF8
	public static string ByteArrayToString(byte[] ba)
	{
		string text = BitConverter.ToString(ba);
		return text.Replace("-", string.Empty);
	}

	// Token: 0x06000D5A RID: 3418 RVA: 0x00103D24 File Offset: 0x00101F24
	public static byte[] StringToByteArray(string hex)
	{
		int length = hex.Length;
		byte[] array = new byte[length / 2];
		for (int i = 0; i < length; i += 2)
		{
			array[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
		}
		return array;
	}

	// Token: 0x06000D5B RID: 3419 RVA: 0x00103D70 File Offset: 0x00101F70
	public static void deleteRecord(string name)
	{
		try
		{
			PlayerPrefs.DeleteKey(name);
		}
		catch (Exception ex)
		{
			Cout.println("loi xoa RMS --------------------------" + ex.ToString());
		}
	}

	// Token: 0x06000D5C RID: 3420 RVA: 0x00103DB4 File Offset: 0x00101FB4
	public static void clearRMS()
	{
		Rms.deleteRecord("data");
		Rms.deleteRecord("dataVersion");
		Rms.deleteRecord("map");
		Rms.deleteRecord("mapVersion");
		Rms.deleteRecord("skill");
		Rms.deleteRecord("killVersion");
		Rms.deleteRecord("item");
		Rms.deleteRecord("itemVersion");
	}

	// Token: 0x06000D5D RID: 3421 RVA: 0x0000BCC1 File Offset: 0x00009EC1
	public static void saveIP(string strID)
	{
		Rms.saveRMSString("NRIPlink", strID);
	}

	// Token: 0x06000D5E RID: 3422 RVA: 0x00103E1C File Offset: 0x0010201C
	public static string loadIP()
	{
		string text = Rms.loadRMSString("NRIPlink");
		bool flag = text == null;
		string result;
		if (flag)
		{
			result = null;
		}
		else
		{
			result = text;
		}
		return result;
	}

	// Token: 0x0400149F RID: 5279
	private const int INTERVAL = 5;

	// Token: 0x040014A0 RID: 5280
	private const int MAXTIME = 500;

	// Token: 0x040014A1 RID: 5281
	public static int status;

	// Token: 0x040014A2 RID: 5282
	public static sbyte[] data;

	// Token: 0x040014A3 RID: 5283
	public static string filename;
}
