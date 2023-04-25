using System;
using UnityEngine;

// Token: 0x020000B2 RID: 178
public class MyAudioClip
{
	// Token: 0x06000ACF RID: 2767 RVA: 0x0000B60D File Offset: 0x0000980D
	public MyAudioClip(string filename)
	{
		this.clip = (AudioClip)Resources.Load(filename);
		this.name = filename;
	}

	// Token: 0x06000AD0 RID: 2768 RVA: 0x0000B62F File Offset: 0x0000982F
	public void Play()
	{
		Main.main.GetComponent<AudioSource>().PlayOneShot(this.clip);
		this.timeStart = mSystem.currentTimeMillis();
	}

	// Token: 0x06000AD1 RID: 2769 RVA: 0x000734DC File Offset: 0x000716DC
	public bool isPlaying()
	{
		return false;
	}

	// Token: 0x040010A0 RID: 4256
	public string name;

	// Token: 0x040010A1 RID: 4257
	public AudioClip clip;

	// Token: 0x040010A2 RID: 4258
	public long timeStart;
}
