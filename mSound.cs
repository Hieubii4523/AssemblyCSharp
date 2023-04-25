using System;
using System.Threading;
using UnityEngine;

// Token: 0x020000AF RID: 175
public class mSound
{
	// Token: 0x06000A85 RID: 2693 RVA: 0x0000B4AA File Offset: 0x000096AA
	public static void stopAll()
	{
		mSound.stopAllz();
	}

	// Token: 0x06000A86 RID: 2694 RVA: 0x000734DC File Offset: 0x000716DC
	public static bool isPlaying()
	{
		return false;
	}

	// Token: 0x06000A87 RID: 2695 RVA: 0x000D64B0 File Offset: 0x000D46B0
	public static void init()
	{
		GameObject gameObject = new GameObject();
		gameObject.name = "Audio Player";
		gameObject.transform.position = Vector3.zero;
		gameObject.AddComponent<AudioListener>();
		mSound.SoundBGLoop = gameObject.AddComponent<AudioSource>();
	}

	// Token: 0x06000A88 RID: 2696 RVA: 0x000D64F4 File Offset: 0x000D46F4
	public static void init(int musicID, int sID)
	{
		bool flag = mSound.player == null && mSound.music == null;
		if (flag)
		{
			mSound.init();
			mSound.l1 = musicID;
			mSound.player = new GameObject[musicID + sID];
			mSound.music = new AudioClip[musicID + sID];
			for (int i = 0; i < mSound.player.Length; i++)
			{
				string fileName = (i >= mSound.l1) ? ("/sound/s" + (i - mSound.l1).ToString()) : ("/sound/m" + i.ToString());
				mSound.getAssetSoundFile(fileName, i);
			}
		}
	}

	// Token: 0x06000A89 RID: 2697 RVA: 0x000D6598 File Offset: 0x000D4798
	public static void playSound(int id, float volume)
	{
		bool flag = mSound.isSound && id >= 0 && id <= mSound.music.Length - mSound.l1 - 1;
		if (flag)
		{
			mSound.play(id + mSound.l1, volume);
		}
	}

	// Token: 0x06000A8A RID: 2698 RVA: 0x0000B4B3 File Offset: 0x000096B3
	public static void playSound1(int id, float volume)
	{
		mSound.play(id, volume);
	}

	// Token: 0x06000A8B RID: 2699 RVA: 0x000D65E0 File Offset: 0x000D47E0
	public static void getAssetSoundFile(string fileName, int pos)
	{
		mSound.stop(pos);
		string filename = string.Empty;
		filename = Main.res + fileName;
		mSound.load(filename, pos);
	}

	// Token: 0x06000A8C RID: 2700 RVA: 0x000D6610 File Offset: 0x000D4810
	public static void stopSoundAll()
	{
		for (int i = 0; i < mSound.music.Length; i++)
		{
			mSound.stop(i);
		}
	}

	// Token: 0x06000A8D RID: 2701 RVA: 0x000D6640 File Offset: 0x000D4840
	public static void stopAllz()
	{
		for (int i = 0; i < mSound.music.Length; i++)
		{
			mSound.stop(i);
		}
		for (int j = 0; j < mSound.l1; j++)
		{
			mSound.sTopSoundBG(j);
		}
	}

	// Token: 0x06000A8E RID: 2702 RVA: 0x000D668C File Offset: 0x000D488C
	public static void stopAllBg()
	{
		for (int i = 0; i < mSound.music.Length; i++)
		{
			mSound.stop(i);
		}
		mSound.sTopSoundBG(0);
		mSound.sTopSoundRun();
		mSound.stopSoundNatural(0);
	}

	// Token: 0x06000A8F RID: 2703 RVA: 0x000090B5 File Offset: 0x000072B5
	public static void update()
	{
	}

	// Token: 0x06000A90 RID: 2704 RVA: 0x0000B4BE File Offset: 0x000096BE
	public static void stopMusic(int x)
	{
		mSound.stop(x);
	}

	// Token: 0x06000A91 RID: 2705 RVA: 0x0000B4C8 File Offset: 0x000096C8
	public static void play(int id, float volume)
	{
		mSound.start(volume, id);
	}

	// Token: 0x06000A92 RID: 2706 RVA: 0x000D66D0 File Offset: 0x000D48D0
	public static void playSoundRun(int id, float volume)
	{
		bool flag = !(mSound.SoundRun == null);
		if (flag)
		{
			mSound.SoundRun.GetComponent<AudioSource>().loop = true;
			mSound.SoundRun.GetComponent<AudioSource>().clip = mSound.music[id];
			mSound.SoundRun.GetComponent<AudioSource>().volume = volume;
			mSound.SoundRun.GetComponent<AudioSource>().Play();
		}
	}

	// Token: 0x06000A93 RID: 2707 RVA: 0x0000B4D3 File Offset: 0x000096D3
	public static void sTopSoundRun()
	{
		mSound.SoundRun.GetComponent<AudioSource>().Stop();
	}

	// Token: 0x06000A94 RID: 2708 RVA: 0x000D673C File Offset: 0x000D493C
	public static bool isPlayingSound()
	{
		bool flag = mSound.SoundRun == null;
		return !flag && mSound.SoundRun.GetComponent<AudioSource>().isPlaying;
	}

	// Token: 0x06000A95 RID: 2709 RVA: 0x000D6774 File Offset: 0x000D4974
	public static void playSoundNatural(int id, float volume, bool isLoop)
	{
		bool flag = !(mSound.SoundBGLoop == null);
		if (flag)
		{
			mSound.SoundWater.GetComponent<AudioSource>().loop = isLoop;
			mSound.SoundWater.GetComponent<AudioSource>().clip = mSound.music[id];
			mSound.SoundWater.GetComponent<AudioSource>().volume = volume;
			mSound.SoundWater.GetComponent<AudioSource>().Play();
		}
	}

	// Token: 0x06000A96 RID: 2710 RVA: 0x0000B4E6 File Offset: 0x000096E6
	public static void stopSoundNatural(int id)
	{
		mSound.SoundWater.GetComponent<AudioSource>().Stop();
	}

	// Token: 0x06000A97 RID: 2711 RVA: 0x000D67E0 File Offset: 0x000D49E0
	public static bool isPlayingSoundatural(int id)
	{
		bool flag = mSound.SoundWater == null;
		return !flag && mSound.SoundWater.GetComponent<AudioSource>().isPlaying;
	}

	// Token: 0x06000A98 RID: 2712 RVA: 0x000D6818 File Offset: 0x000D4A18
	public static void playMus(int type, float vl, bool loop)
	{
		bool flag = mSound.isMusic && type >= 0 && type <= mSound.l1 - 1;
		if (flag)
		{
			mSound.playSoundBGLoop(type, vl);
		}
	}

	// Token: 0x06000A99 RID: 2713 RVA: 0x000D6850 File Offset: 0x000D4A50
	public static void playSoundBGLoop(int id, float volume)
	{
		bool flag = !(mSound.SoundBGLoop == null) && id != mSound.idCurent;
		if (flag)
		{
			mSound.SoundBGLoop.GetComponent<AudioSource>().loop = true;
			mSound.SoundBGLoop.GetComponent<AudioSource>().clip = mSound.music[id];
			mSound.SoundBGLoop.GetComponent<AudioSource>().volume = volume;
			mSound.SoundBGLoop.GetComponent<AudioSource>().Play();
			mSound.idCurent = id;
		}
	}

	// Token: 0x06000A9A RID: 2714 RVA: 0x0000B4F9 File Offset: 0x000096F9
	public static void sTopSoundBG(int id)
	{
		mSound.SoundBGLoop.GetComponent<AudioSource>().Stop();
	}

	// Token: 0x06000A9B RID: 2715 RVA: 0x000D68D0 File Offset: 0x000D4AD0
	public static bool isPlayingSoundBG(int id)
	{
		bool flag = mSound.SoundBGLoop == null;
		return !flag && mSound.SoundBGLoop.GetComponent<AudioSource>().isPlaying;
	}

	// Token: 0x06000A9C RID: 2716 RVA: 0x000D6908 File Offset: 0x000D4B08
	public static void load(string filename, int pos)
	{
		bool flag = Thread.CurrentThread.Name == Main.mainThreadName;
		if (flag)
		{
			mSound.__load(filename, pos);
		}
		else
		{
			mSound._load(filename, pos);
		}
	}

	// Token: 0x06000A9D RID: 2717 RVA: 0x000D6944 File Offset: 0x000D4B44
	private static void _load(string filename, int pos)
	{
		bool flag = mSound.status != 0;
		if (flag)
		{
			Cout.LogError("CANNOT LOAD AUDIO " + filename + " WHEN LOADING " + mSound.filenametemp);
		}
		else
		{
			mSound.filenametemp = filename;
			mSound.postem = pos;
			mSound.status = 2;
			int i;
			for (i = 0; i < 100; i++)
			{
				Thread.Sleep(5);
				bool flag2 = mSound.status == 0;
				if (flag2)
				{
					break;
				}
			}
			bool flag3 = i == 100;
			if (flag3)
			{
				Cout.LogError("TOO LONG FOR LOAD AUDIO " + filename);
			}
			else
			{
				Cout.Log(string.Concat(new string[]
				{
					"Load Audio ",
					filename,
					" done in ",
					(i * 5).ToString(),
					"ms"
				}));
			}
		}
	}

	// Token: 0x06000A9E RID: 2718 RVA: 0x0000B50C File Offset: 0x0000970C
	private static void __load(string filename, int pos)
	{
		mSound.music[pos] = (AudioClip)Resources.Load(filename, typeof(AudioClip));
		GameObject.Find("Main Camera").AddComponent<AudioSource>();
		mSound.player[pos] = GameObject.Find("Main Camera");
	}

	// Token: 0x06000A9F RID: 2719 RVA: 0x000D6A18 File Offset: 0x000D4C18
	public static void start(float volume, int pos)
	{
		bool flag = Thread.CurrentThread.Name == Main.mainThreadName;
		if (flag)
		{
			mSound.__start(volume, pos);
		}
		else
		{
			mSound._start(volume, pos);
		}
	}

	// Token: 0x06000AA0 RID: 2720 RVA: 0x000D6A54 File Offset: 0x000D4C54
	public static void _start(float volume, int pos)
	{
		bool flag = mSound.status != 0;
		if (flag)
		{
			Debug.LogError("CANNOT START AUDIO WHEN STARTING");
		}
		else
		{
			mSound.volumetem = volume;
			mSound.postem = pos;
			mSound.status = 3;
			int i;
			for (i = 0; i < 100; i++)
			{
				Thread.Sleep(5);
				bool flag2 = mSound.status == 0;
				if (flag2)
				{
					break;
				}
			}
			bool flag3 = i == 100;
			if (flag3)
			{
				Debug.LogError("TOO LONG FOR START AUDIO");
			}
			else
			{
				Debug.Log("Start Audio done in " + (i * 5).ToString() + "ms");
			}
		}
	}

	// Token: 0x06000AA1 RID: 2721 RVA: 0x000D6AF4 File Offset: 0x000D4CF4
	public static void __start(float volume, int pos)
	{
		bool flag = !(mSound.player[pos] == null);
		if (flag)
		{
			mSound.player[pos].GetComponent<AudioSource>().PlayOneShot(mSound.music[pos], volume);
		}
	}

	// Token: 0x06000AA2 RID: 2722 RVA: 0x000D6B34 File Offset: 0x000D4D34
	public static void stop(int pos)
	{
		bool flag = Thread.CurrentThread.Name == Main.mainThreadName;
		if (flag)
		{
			mSound.__stop(pos);
		}
		else
		{
			mSound._stop(pos);
		}
	}

	// Token: 0x06000AA3 RID: 2723 RVA: 0x000D6B70 File Offset: 0x000D4D70
	public static void _stop(int pos)
	{
		bool flag = mSound.status != 0;
		if (flag)
		{
			Debug.LogError("CANNOT STOP AUDIO WHEN STOPPING");
		}
		else
		{
			mSound.postem = pos;
			mSound.status = 4;
			int i;
			for (i = 0; i < 100; i++)
			{
				Thread.Sleep(5);
				bool flag2 = mSound.status == 0;
				if (flag2)
				{
					break;
				}
			}
			bool flag3 = i == 100;
			if (flag3)
			{
				Debug.LogError("TOO LONG FOR STOP AUDIO");
			}
			else
			{
				Debug.Log("Stop Audio done in " + (i * 5).ToString() + "ms");
			}
		}
	}

	// Token: 0x06000AA4 RID: 2724 RVA: 0x000D6C0C File Offset: 0x000D4E0C
	public static void __stop(int pos)
	{
		bool flag = mSound.player[pos] != null;
		if (flag)
		{
			mSound.player[pos].GetComponent<AudioSource>().Stop();
		}
	}

	// Token: 0x04001080 RID: 4224
	private const int INTERVAL = 5;

	// Token: 0x04001081 RID: 4225
	private const int MAXTIME = 100;

	// Token: 0x04001082 RID: 4226
	public static int status;

	// Token: 0x04001083 RID: 4227
	public static int postem;

	// Token: 0x04001084 RID: 4228
	public static int timestart;

	// Token: 0x04001085 RID: 4229
	private static string filenametemp;

	// Token: 0x04001086 RID: 4230
	private static float volumetem;

	// Token: 0x04001087 RID: 4231
	public static bool isSound = true;

	// Token: 0x04001088 RID: 4232
	public static bool isMusic = true;

	// Token: 0x04001089 RID: 4233
	public static bool isNotPlay;

	// Token: 0x0400108A RID: 4234
	public static AudioSource SoundWater;

	// Token: 0x0400108B RID: 4235
	public static AudioSource SoundRun;

	// Token: 0x0400108C RID: 4236
	public static AudioSource SoundBGLoop;

	// Token: 0x0400108D RID: 4237
	public static float volumeSound = 0.7f;

	// Token: 0x0400108E RID: 4238
	public static float volumeMusic = 0.8f;

	// Token: 0x0400108F RID: 4239
	public static AudioClip[] music;

	// Token: 0x04001090 RID: 4240
	public static GameObject[] player;

	// Token: 0x04001091 RID: 4241
	public static int l1;

	// Token: 0x04001092 RID: 4242
	public static int idCurent = -1;
}
