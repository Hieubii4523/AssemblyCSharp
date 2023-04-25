using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200003C RID: 60
public class GPS : MonoBehaviour
{
	// Token: 0x060004EE RID: 1262 RVA: 0x0000A0BF File Offset: 0x000082BF
	private void Start()
	{
		base.StartCoroutine(this.StartLocationService());
	}

	// Token: 0x060004EF RID: 1263 RVA: 0x000090B5 File Offset: 0x000072B5
	private void Update()
	{
	}

	// Token: 0x060004F0 RID: 1264 RVA: 0x0000A0CF File Offset: 0x000082CF
	private IEnumerator StartLocationService()
	{
		bool isEnabledByUser = Input.location.isEnabledByUser;
		if (isEnabledByUser)
		{
			Input.location.Start(1f, 1f);
			int maxWait = 20;
			while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
			{
				yield return new WaitForSeconds(1f);
				int num = maxWait;
				maxWait = num - 1;
			}
			bool flag = maxWait > 0 && Input.location.status != LocationServiceStatus.Failed;
			if (flag)
			{
				GPS.Latitude = Input.location.lastData.latitude.ToString() + string.Empty;
				GPS.Longitude = Input.location.lastData.longitude.ToString() + string.Empty;
				base.StartCoroutine(this.TrackLocation());
			}
		}
		yield break;
	}

	// Token: 0x060004F1 RID: 1265 RVA: 0x0000A0DE File Offset: 0x000082DE
	private IEnumerator TrackLocation()
	{
		for (;;)
		{
			yield return new WaitForSeconds(5f);
			bool flag = Input.location.status == LocationServiceStatus.Running;
			if (flag)
			{
				GPS.Latitude = Input.location.lastData.latitude.ToString() + string.Empty;
				GPS.Longitude = Input.location.lastData.longitude.ToString() + string.Empty;
			}
			Debug.LogWarning("VO DAY ");
		}
		yield break;
	}

	// Token: 0x0400072C RID: 1836
	public static string Latitude = string.Empty;

	// Token: 0x0400072D RID: 1837
	public static string Longitude = string.Empty;
}
