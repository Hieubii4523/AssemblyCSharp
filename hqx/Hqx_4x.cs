using System;

namespace hqx
{
	// Token: 0x02000119 RID: 281
	public class Hqx_4x : Hqx
	{
		// Token: 0x06000FFC RID: 4092 RVA: 0x0013FACC File Offset: 0x0013DCCC
		public static void hq4x_32_rb(int[] sp, int[] dp, int Xres, int Yres)
		{
			Hqx_4x.hq4x_32_rb(sp, dp, Xres, Yres, 48, 7, 6, 0, false, false);
		}

		// Token: 0x06000FFD RID: 4093 RVA: 0x0013FAEC File Offset: 0x0013DCEC
		private static void case0(int[] dp, int dpIdx, int dpL, int[] w)
		{
			dp[dpIdx] = Interpolation.Mix2To1To1(w[4], w[1], w[3]);
			dp[dpIdx + 1] = Interpolation.Mix4To2To1(w[4], w[1], w[3]);
			dp[dpIdx + 2] = Interpolation.Mix4To2To1(w[4], w[1], w[5]);
			dp[dpIdx + 3] = Interpolation.Mix2To1To1(w[4], w[1], w[5]);
			dp[dpIdx + dpL] = Interpolation.Mix4To2To1(w[4], w[3], w[1]);
			dp[dpIdx + dpL + 1] = Interpolation.Mix6To1To1(w[4], w[3], w[1]);
			dp[dpIdx + dpL + 2] = Interpolation.Mix6To1To1(w[4], w[5], w[1]);
			dp[dpIdx + dpL + 3] = Interpolation.Mix4To2To1(w[4], w[5], w[1]);
			dp[dpIdx + dpL + dpL] = Interpolation.Mix4To2To1(w[4], w[3], w[7]);
			dp[dpIdx + dpL + dpL + 1] = Interpolation.Mix6To1To1(w[4], w[3], w[7]);
			dp[dpIdx + dpL + dpL + 2] = Interpolation.Mix6To1To1(w[4], w[5], w[7]);
			dp[dpIdx + dpL + dpL + 3] = Interpolation.Mix4To2To1(w[4], w[5], w[7]);
			dp[dpIdx + dpL + dpL + dpL] = Interpolation.Mix2To1To1(w[4], w[7], w[3]);
			dp[dpIdx + dpL + dpL + dpL + 1] = Interpolation.Mix4To2To1(w[4], w[7], w[3]);
			dp[dpIdx + dpL + dpL + dpL + 2] = Interpolation.Mix4To2To1(w[4], w[7], w[5]);
			dp[dpIdx + dpL + dpL + dpL + 3] = Interpolation.Mix2To1To1(w[4], w[7], w[5]);
		}

		// Token: 0x06000FFE RID: 4094 RVA: 0x0013FC54 File Offset: 0x0013DE54
		private static void case2(int[] dp, int dpIdx, int dpL, int[] w)
		{
			dp[dpIdx] = Interpolation.Mix5To3(w[4], w[0]);
			dp[dpIdx + 1] = Interpolation.Mix3To1(w[4], w[0]);
			dp[dpIdx + 2] = Interpolation.Mix3To1(w[4], w[2]);
			dp[dpIdx + 3] = Interpolation.Mix5To3(w[4], w[2]);
			dp[dpIdx + dpL] = Interpolation.Mix4To2To1(w[4], w[3], w[0]);
			dp[dpIdx + dpL + 1] = Interpolation.Mix7To1(w[4], w[0]);
			dp[dpIdx + dpL + 2] = Interpolation.Mix7To1(w[4], w[2]);
			dp[dpIdx + dpL + 3] = Interpolation.Mix4To2To1(w[4], w[5], w[2]);
			dp[dpIdx + dpL + dpL] = Interpolation.Mix4To2To1(w[4], w[3], w[7]);
			dp[dpIdx + dpL + dpL + 1] = Interpolation.Mix6To1To1(w[4], w[3], w[7]);
			dp[dpIdx + dpL + dpL + 2] = Interpolation.Mix6To1To1(w[4], w[5], w[7]);
			dp[dpIdx + dpL + dpL + 3] = Interpolation.Mix4To2To1(w[4], w[5], w[7]);
			dp[dpIdx + dpL + dpL + dpL] = Interpolation.Mix2To1To1(w[4], w[7], w[3]);
			dp[dpIdx + dpL + dpL + dpL + 1] = Interpolation.Mix4To2To1(w[4], w[7], w[3]);
			dp[dpIdx + dpL + dpL + dpL + 2] = Interpolation.Mix4To2To1(w[4], w[7], w[5]);
			dp[dpIdx + dpL + dpL + dpL + 3] = Interpolation.Mix2To1To1(w[4], w[7], w[5]);
		}

		// Token: 0x06000FFF RID: 4095 RVA: 0x0013FDA8 File Offset: 0x0013DFA8
		private static void case16(int[] dp, int dpIdx, int dpL, int[] w)
		{
			dp[dpIdx] = Interpolation.Mix2To1To1(w[4], w[1], w[3]);
			dp[dpIdx + 1] = Interpolation.Mix4To2To1(w[4], w[1], w[3]);
			dp[dpIdx + 2] = Interpolation.Mix4To2To1(w[4], w[1], w[2]);
			dp[dpIdx + 3] = Interpolation.Mix5To3(w[4], w[2]);
			dp[dpIdx + dpL] = Interpolation.Mix4To2To1(w[4], w[3], w[1]);
			dp[dpIdx + dpL + 1] = Interpolation.Mix6To1To1(w[4], w[3], w[1]);
			dp[dpIdx + dpL + 2] = Interpolation.Mix7To1(w[4], w[2]);
			dp[dpIdx + dpL + 3] = Interpolation.Mix3To1(w[4], w[2]);
			dp[dpIdx + dpL + dpL] = Interpolation.Mix4To2To1(w[4], w[3], w[7]);
			dp[dpIdx + dpL + dpL + 1] = Interpolation.Mix6To1To1(w[4], w[3], w[7]);
			dp[dpIdx + dpL + dpL + 2] = Interpolation.Mix7To1(w[4], w[8]);
			dp[dpIdx + dpL + dpL + 3] = Interpolation.Mix3To1(w[4], w[8]);
			dp[dpIdx + dpL + dpL + dpL] = Interpolation.Mix2To1To1(w[4], w[7], w[3]);
			dp[dpIdx + dpL + dpL + dpL + 1] = Interpolation.Mix4To2To1(w[4], w[7], w[3]);
			dp[dpIdx + dpL + dpL + dpL + 2] = Interpolation.Mix4To2To1(w[4], w[7], w[8]);
			dp[dpIdx + dpL + dpL + dpL + 3] = Interpolation.Mix5To3(w[4], w[8]);
		}

		// Token: 0x06001000 RID: 4096 RVA: 0x0013FEFC File Offset: 0x0013E0FC
		private static void case64(int[] dp, int dpIdx, int dpL, int[] w)
		{
			dp[dpIdx] = Interpolation.Mix2To1To1(w[4], w[1], w[3]);
			dp[dpIdx + 1] = Interpolation.Mix4To2To1(w[4], w[1], w[3]);
			dp[dpIdx + 2] = Interpolation.Mix4To2To1(w[4], w[1], w[5]);
			dp[dpIdx + 3] = Interpolation.Mix2To1To1(w[4], w[1], w[5]);
			dp[dpIdx + dpL] = Interpolation.Mix4To2To1(w[4], w[3], w[1]);
			dp[dpIdx + dpL + 1] = Interpolation.Mix6To1To1(w[4], w[3], w[1]);
			dp[dpIdx + dpL + 2] = Interpolation.Mix6To1To1(w[4], w[5], w[1]);
			dp[dpIdx + dpL + 3] = Interpolation.Mix4To2To1(w[4], w[5], w[1]);
			dp[dpIdx + dpL + dpL] = Interpolation.Mix4To2To1(w[4], w[3], w[6]);
			dp[dpIdx + dpL + dpL + 1] = Interpolation.Mix7To1(w[4], w[6]);
			dp[dpIdx + dpL + dpL + 2] = Interpolation.Mix7To1(w[4], w[8]);
			dp[dpIdx + dpL + dpL + 3] = Interpolation.Mix4To2To1(w[4], w[5], w[8]);
			dp[dpIdx + dpL + dpL + dpL] = Interpolation.Mix5To3(w[4], w[6]);
			dp[dpIdx + dpL + dpL + dpL + 1] = Interpolation.Mix3To1(w[4], w[6]);
			dp[dpIdx + dpL + dpL + dpL + 2] = Interpolation.Mix3To1(w[4], w[8]);
			dp[dpIdx + dpL + dpL + dpL + 3] = Interpolation.Mix5To3(w[4], w[8]);
		}

		// Token: 0x06001001 RID: 4097 RVA: 0x00140050 File Offset: 0x0013E250
		private static void case8(int[] dp, int dpIdx, int dpL, int[] w)
		{
			dp[dpIdx] = Interpolation.Mix5To3(w[4], w[0]);
			dp[dpIdx + 1] = Interpolation.Mix4To2To1(w[4], w[1], w[0]);
			dp[dpIdx + 2] = Interpolation.Mix4To2To1(w[4], w[1], w[5]);
			dp[dpIdx + 3] = Interpolation.Mix2To1To1(w[4], w[1], w[5]);
			dp[dpIdx + dpL] = Interpolation.Mix3To1(w[4], w[0]);
			dp[dpIdx + dpL + 1] = Interpolation.Mix7To1(w[4], w[0]);
			dp[dpIdx + dpL + 2] = Interpolation.Mix6To1To1(w[4], w[5], w[1]);
			dp[dpIdx + dpL + 3] = Interpolation.Mix4To2To1(w[4], w[5], w[1]);
			dp[dpIdx + dpL + dpL] = Interpolation.Mix3To1(w[4], w[6]);
			dp[dpIdx + dpL + dpL + 1] = Interpolation.Mix7To1(w[4], w[6]);
			dp[dpIdx + dpL + dpL + 2] = Interpolation.Mix6To1To1(w[4], w[5], w[7]);
			dp[dpIdx + dpL + dpL + 3] = Interpolation.Mix4To2To1(w[4], w[5], w[7]);
			dp[dpIdx + dpL + dpL + dpL] = Interpolation.Mix5To3(w[4], w[6]);
			dp[dpIdx + dpL + dpL + dpL + 1] = Interpolation.Mix4To2To1(w[4], w[7], w[6]);
			dp[dpIdx + dpL + dpL + dpL + 2] = Interpolation.Mix4To2To1(w[4], w[7], w[5]);
			dp[dpIdx + dpL + dpL + dpL + 3] = Interpolation.Mix2To1To1(w[4], w[7], w[5]);
		}

		// Token: 0x06001002 RID: 4098 RVA: 0x001401A4 File Offset: 0x0013E3A4
		private static void case3(int[] dp, int dpIdx, int dpL, int[] w)
		{
			dp[dpIdx] = Interpolation.Mix5To3(w[4], w[3]);
			dp[dpIdx + 1] = Interpolation.Mix7To1(w[4], w[3]);
			dp[dpIdx + 2] = Interpolation.Mix3To1(w[4], w[2]);
			dp[dpIdx + 3] = Interpolation.Mix5To3(w[4], w[2]);
			dp[dpIdx + dpL] = Interpolation.Mix5To3(w[4], w[3]);
			dp[dpIdx + dpL + 1] = Interpolation.Mix7To1(w[4], w[3]);
			dp[dpIdx + dpL + 2] = Interpolation.Mix7To1(w[4], w[2]);
			dp[dpIdx + dpL + 3] = Interpolation.Mix4To2To1(w[4], w[5], w[2]);
			dp[dpIdx + dpL + dpL] = Interpolation.Mix4To2To1(w[4], w[3], w[7]);
			dp[dpIdx + dpL + dpL + 1] = Interpolation.Mix6To1To1(w[4], w[3], w[7]);
			dp[dpIdx + dpL + dpL + 2] = Interpolation.Mix6To1To1(w[4], w[5], w[7]);
			dp[dpIdx + dpL + dpL + 3] = Interpolation.Mix4To2To1(w[4], w[5], w[7]);
			dp[dpIdx + dpL + dpL + dpL] = Interpolation.Mix2To1To1(w[4], w[7], w[3]);
			dp[dpIdx + dpL + dpL + dpL + 1] = Interpolation.Mix4To2To1(w[4], w[7], w[3]);
			dp[dpIdx + dpL + dpL + dpL + 2] = Interpolation.Mix4To2To1(w[4], w[7], w[5]);
			dp[dpIdx + dpL + dpL + dpL + 3] = Interpolation.Mix2To1To1(w[4], w[7], w[5]);
		}

		// Token: 0x06001003 RID: 4099 RVA: 0x001402F8 File Offset: 0x0013E4F8
		private static void case6(int[] dp, int dpIdx, int dpL, int[] w)
		{
			dp[dpIdx] = Interpolation.Mix5To3(w[4], w[0]);
			dp[dpIdx + 1] = Interpolation.Mix3To1(w[4], w[0]);
			dp[dpIdx + 2] = Interpolation.Mix7To1(w[4], w[5]);
			dp[dpIdx + 3] = Interpolation.Mix5To3(w[4], w[5]);
			dp[dpIdx + dpL] = Interpolation.Mix4To2To1(w[4], w[3], w[0]);
			dp[dpIdx + dpL + 1] = Interpolation.Mix7To1(w[4], w[0]);
			dp[dpIdx + dpL + 2] = Interpolation.Mix7To1(w[4], w[5]);
			dp[dpIdx + dpL + 3] = Interpolation.Mix5To3(w[4], w[5]);
			dp[dpIdx + dpL + dpL] = Interpolation.Mix4To2To1(w[4], w[3], w[7]);
			dp[dpIdx + dpL + dpL + 1] = Interpolation.Mix6To1To1(w[4], w[3], w[7]);
			dp[dpIdx + dpL + dpL + 2] = Interpolation.Mix6To1To1(w[4], w[5], w[7]);
			dp[dpIdx + dpL + dpL + 3] = Interpolation.Mix4To2To1(w[4], w[5], w[7]);
			dp[dpIdx + dpL + dpL + dpL] = Interpolation.Mix2To1To1(w[4], w[7], w[3]);
			dp[dpIdx + dpL + dpL + dpL + 1] = Interpolation.Mix4To2To1(w[4], w[7], w[3]);
			dp[dpIdx + dpL + dpL + dpL + 2] = Interpolation.Mix4To2To1(w[4], w[7], w[5]);
			dp[dpIdx + dpL + dpL + dpL + 3] = Interpolation.Mix2To1To1(w[4], w[7], w[5]);
		}

		// Token: 0x06001004 RID: 4100 RVA: 0x0014044C File Offset: 0x0013E64C
		private static void case20(int[] dp, int dpIdx, int dpL, int[] w)
		{
			dp[dpIdx] = Interpolation.Mix2To1To1(w[4], w[1], w[3]);
			dp[dpIdx + 1] = Interpolation.Mix4To2To1(w[4], w[1], w[3]);
			dp[dpIdx + 2] = Interpolation.Mix5To3(w[4], w[1]);
			dp[dpIdx + 3] = Interpolation.Mix5To3(w[4], w[1]);
			dp[dpIdx + dpL] = Interpolation.Mix4To2To1(w[4], w[3], w[1]);
			dp[dpIdx + dpL + 1] = Interpolation.Mix6To1To1(w[4], w[3], w[1]);
			dp[dpIdx + dpL + 2] = Interpolation.Mix7To1(w[4], w[1]);
			dp[dpIdx + dpL + 3] = Interpolation.Mix7To1(w[4], w[1]);
			dp[dpIdx + dpL + dpL] = Interpolation.Mix4To2To1(w[4], w[3], w[7]);
			dp[dpIdx + dpL + dpL + 1] = Interpolation.Mix6To1To1(w[4], w[3], w[7]);
			dp[dpIdx + dpL + dpL + 2] = Interpolation.Mix7To1(w[4], w[8]);
			dp[dpIdx + dpL + dpL + 3] = Interpolation.Mix3To1(w[4], w[8]);
			dp[dpIdx + dpL + dpL + dpL] = Interpolation.Mix2To1To1(w[4], w[7], w[3]);
			dp[dpIdx + dpL + dpL + dpL + 1] = Interpolation.Mix4To2To1(w[4], w[7], w[3]);
			dp[dpIdx + dpL + dpL + dpL + 2] = Interpolation.Mix4To2To1(w[4], w[7], w[8]);
			dp[dpIdx + dpL + dpL + dpL + 3] = Interpolation.Mix5To3(w[4], w[8]);
		}

		// Token: 0x06001005 RID: 4101 RVA: 0x001405A0 File Offset: 0x0013E7A0
		private static void case144(int[] dp, int dpIdx, int dpL, int[] w)
		{
			dp[dpIdx] = Interpolation.Mix2To1To1(w[4], w[1], w[3]);
			dp[dpIdx + 1] = Interpolation.Mix4To2To1(w[4], w[1], w[3]);
			dp[dpIdx + 2] = Interpolation.Mix4To2To1(w[4], w[1], w[2]);
			dp[dpIdx + 3] = Interpolation.Mix5To3(w[4], w[2]);
			dp[dpIdx + dpL] = Interpolation.Mix4To2To1(w[4], w[3], w[1]);
			dp[dpIdx + dpL + 1] = Interpolation.Mix6To1To1(w[4], w[3], w[1]);
			dp[dpIdx + dpL + 2] = Interpolation.Mix7To1(w[4], w[2]);
			dp[dpIdx + dpL + 3] = Interpolation.Mix3To1(w[4], w[2]);
			dp[dpIdx + dpL + dpL] = Interpolation.Mix4To2To1(w[4], w[3], w[7]);
			dp[dpIdx + dpL + dpL + 1] = Interpolation.Mix6To1To1(w[4], w[3], w[7]);
			dp[dpIdx + dpL + dpL + 2] = Interpolation.Mix7To1(w[4], w[7]);
			dp[dpIdx + dpL + dpL + 3] = Interpolation.Mix7To1(w[4], w[7]);
			dp[dpIdx + dpL + dpL + dpL] = Interpolation.Mix2To1To1(w[4], w[7], w[3]);
			dp[dpIdx + dpL + dpL + dpL + 1] = Interpolation.Mix4To2To1(w[4], w[7], w[3]);
			dp[dpIdx + dpL + dpL + dpL + 2] = Interpolation.Mix5To3(w[4], w[7]);
			dp[dpIdx + dpL + dpL + dpL + 3] = Interpolation.Mix5To3(w[4], w[7]);
		}

		// Token: 0x06001006 RID: 4102 RVA: 0x001406F4 File Offset: 0x0013E8F4
		private static void case192(int[] dp, int dpIdx, int dpL, int[] w)
		{
			dp[dpIdx] = Interpolation.Mix2To1To1(w[4], w[1], w[3]);
			dp[dpIdx + 1] = Interpolation.Mix4To2To1(w[4], w[1], w[3]);
			dp[dpIdx + 2] = Interpolation.Mix4To2To1(w[4], w[1], w[5]);
			dp[dpIdx + 3] = Interpolation.Mix2To1To1(w[4], w[1], w[5]);
			dp[dpIdx + dpL] = Interpolation.Mix4To2To1(w[4], w[3], w[1]);
			dp[dpIdx + dpL + 1] = Interpolation.Mix6To1To1(w[4], w[3], w[1]);
			dp[dpIdx + dpL + 2] = Interpolation.Mix6To1To1(w[4], w[5], w[1]);
			dp[dpIdx + dpL + 3] = Interpolation.Mix4To2To1(w[4], w[5], w[1]);
			dp[dpIdx + dpL + dpL] = Interpolation.Mix4To2To1(w[4], w[3], w[6]);
			dp[dpIdx + dpL + dpL + 1] = Interpolation.Mix7To1(w[4], w[6]);
			dp[dpIdx + dpL + dpL + 2] = Interpolation.Mix7To1(w[4], w[5]);
			dp[dpIdx + dpL + dpL + 3] = Interpolation.Mix5To3(w[4], w[5]);
			dp[dpIdx + dpL + dpL + dpL] = Interpolation.Mix5To3(w[4], w[6]);
			dp[dpIdx + dpL + dpL + dpL + 1] = Interpolation.Mix3To1(w[4], w[6]);
			dp[dpIdx + dpL + dpL + dpL + 2] = Interpolation.Mix7To1(w[4], w[5]);
			dp[dpIdx + dpL + dpL + dpL + 3] = Interpolation.Mix5To3(w[4], w[5]);
		}

		// Token: 0x06001007 RID: 4103 RVA: 0x00140848 File Offset: 0x0013EA48
		private static void case96(int[] dp, int dpIdx, int dpL, int[] w)
		{
			dp[dpIdx] = Interpolation.Mix2To1To1(w[4], w[1], w[3]);
			dp[dpIdx + 1] = Interpolation.Mix4To2To1(w[4], w[1], w[3]);
			dp[dpIdx + 2] = Interpolation.Mix4To2To1(w[4], w[1], w[5]);
			dp[dpIdx + 3] = Interpolation.Mix2To1To1(w[4], w[1], w[5]);
			dp[dpIdx + dpL] = Interpolation.Mix4To2To1(w[4], w[3], w[1]);
			dp[dpIdx + dpL + 1] = Interpolation.Mix6To1To1(w[4], w[3], w[1]);
			dp[dpIdx + dpL + 2] = Interpolation.Mix6To1To1(w[4], w[5], w[1]);
			dp[dpIdx + dpL + 3] = Interpolation.Mix4To2To1(w[4], w[5], w[1]);
			dp[dpIdx + dpL + dpL] = Interpolation.Mix5To3(w[4], w[3]);
			dp[dpIdx + dpL + dpL + 1] = Interpolation.Mix7To1(w[4], w[3]);
			dp[dpIdx + dpL + dpL + 2] = Interpolation.Mix7To1(w[4], w[8]);
			dp[dpIdx + dpL + dpL + 3] = Interpolation.Mix4To2To1(w[4], w[5], w[8]);
			dp[dpIdx + dpL + dpL + dpL] = Interpolation.Mix5To3(w[4], w[3]);
			dp[dpIdx + dpL + dpL + dpL + 1] = Interpolation.Mix7To1(w[4], w[3]);
			dp[dpIdx + dpL + dpL + dpL + 2] = Interpolation.Mix3To1(w[4], w[8]);
			dp[dpIdx + dpL + dpL + dpL + 3] = Interpolation.Mix5To3(w[4], w[8]);
		}

		// Token: 0x06001008 RID: 4104 RVA: 0x0014099C File Offset: 0x0013EB9C
		private static void case40(int[] dp, int dpIdx, int dpL, int[] w)
		{
			dp[dpIdx] = Interpolation.Mix5To3(w[4], w[0]);
			dp[dpIdx + 1] = Interpolation.Mix4To2To1(w[4], w[1], w[0]);
			dp[dpIdx + 2] = Interpolation.Mix4To2To1(w[4], w[1], w[5]);
			dp[dpIdx + 3] = Interpolation.Mix2To1To1(w[4], w[1], w[5]);
			dp[dpIdx + dpL] = Interpolation.Mix3To1(w[4], w[0]);
			dp[dpIdx + dpL + 1] = Interpolation.Mix7To1(w[4], w[0]);
			dp[dpIdx + dpL + 2] = Interpolation.Mix6To1To1(w[4], w[5], w[1]);
			dp[dpIdx + dpL + 3] = Interpolation.Mix4To2To1(w[4], w[5], w[1]);
			dp[dpIdx + dpL + dpL] = Interpolation.Mix7To1(w[4], w[7]);
			dp[dpIdx + dpL + dpL + 1] = Interpolation.Mix7To1(w[4], w[7]);
			dp[dpIdx + dpL + dpL + 2] = Interpolation.Mix6To1To1(w[4], w[5], w[7]);
			dp[dpIdx + dpL + dpL + 3] = Interpolation.Mix4To2To1(w[4], w[5], w[7]);
			dp[dpIdx + dpL + dpL + dpL] = Interpolation.Mix5To3(w[4], w[7]);
			dp[dpIdx + dpL + dpL + dpL + 1] = Interpolation.Mix5To3(w[4], w[7]);
			dp[dpIdx + dpL + dpL + dpL + 2] = Interpolation.Mix4To2To1(w[4], w[7], w[5]);
			dp[dpIdx + dpL + dpL + dpL + 3] = Interpolation.Mix2To1To1(w[4], w[7], w[5]);
		}

		// Token: 0x06001009 RID: 4105 RVA: 0x00140AF0 File Offset: 0x0013ECF0
		private static void case9(int[] dp, int dpIdx, int dpL, int[] w)
		{
			dp[dpIdx] = Interpolation.Mix5To3(w[4], w[1]);
			dp[dpIdx + 1] = Interpolation.Mix5To3(w[4], w[1]);
			dp[dpIdx + 2] = Interpolation.Mix4To2To1(w[4], w[1], w[5]);
			dp[dpIdx + 3] = Interpolation.Mix2To1To1(w[4], w[1], w[5]);
			dp[dpIdx + dpL] = Interpolation.Mix7To1(w[4], w[1]);
			dp[dpIdx + dpL + 1] = Interpolation.Mix7To1(w[4], w[1]);
			dp[dpIdx + dpL + 2] = Interpolation.Mix6To1To1(w[4], w[5], w[1]);
			dp[dpIdx + dpL + 3] = Interpolation.Mix4To2To1(w[4], w[5], w[1]);
			dp[dpIdx + dpL + dpL] = Interpolation.Mix3To1(w[4], w[6]);
			dp[dpIdx + dpL + dpL + 1] = Interpolation.Mix7To1(w[4], w[6]);
			dp[dpIdx + dpL + dpL + 2] = Interpolation.Mix6To1To1(w[4], w[5], w[7]);
			dp[dpIdx + dpL + dpL + 3] = Interpolation.Mix4To2To1(w[4], w[5], w[7]);
			dp[dpIdx + dpL + dpL + dpL] = Interpolation.Mix5To3(w[4], w[6]);
			dp[dpIdx + dpL + dpL + dpL + 1] = Interpolation.Mix4To2To1(w[4], w[7], w[6]);
			dp[dpIdx + dpL + dpL + dpL + 2] = Interpolation.Mix4To2To1(w[4], w[7], w[5]);
			dp[dpIdx + dpL + dpL + dpL + 3] = Interpolation.Mix2To1To1(w[4], w[7], w[5]);
		}

		// Token: 0x0600100A RID: 4106 RVA: 0x00140C44 File Offset: 0x0013EE44
		private static void case66(int[] dp, int dpIdx, int dpL, int[] w)
		{
			dp[dpIdx] = Interpolation.Mix5To3(w[4], w[0]);
			dp[dpIdx + 1] = Interpolation.Mix3To1(w[4], w[0]);
			dp[dpIdx + 2] = Interpolation.Mix3To1(w[4], w[2]);
			dp[dpIdx + 3] = Interpolation.Mix5To3(w[4], w[2]);
			dp[dpIdx + dpL] = Interpolation.Mix4To2To1(w[4], w[3], w[0]);
			dp[dpIdx + dpL + 1] = Interpolation.Mix7To1(w[4], w[0]);
			dp[dpIdx + dpL + 2] = Interpolation.Mix7To1(w[4], w[2]);
			dp[dpIdx + dpL + 3] = Interpolation.Mix4To2To1(w[4], w[5], w[2]);
			dp[dpIdx + dpL + dpL] = Interpolation.Mix4To2To1(w[4], w[3], w[6]);
			dp[dpIdx + dpL + dpL + 1] = Interpolation.Mix7To1(w[4], w[6]);
			dp[dpIdx + dpL + dpL + 2] = Interpolation.Mix7To1(w[4], w[8]);
			dp[dpIdx + dpL + dpL + 3] = Interpolation.Mix4To2To1(w[4], w[5], w[8]);
			dp[dpIdx + dpL + dpL + dpL] = Interpolation.Mix5To3(w[4], w[6]);
			dp[dpIdx + dpL + dpL + dpL + 1] = Interpolation.Mix3To1(w[4], w[6]);
			dp[dpIdx + dpL + dpL + dpL + 2] = Interpolation.Mix3To1(w[4], w[8]);
			dp[dpIdx + dpL + dpL + dpL + 3] = Interpolation.Mix5To3(w[4], w[8]);
		}

		// Token: 0x0600100B RID: 4107 RVA: 0x00140D88 File Offset: 0x0013EF88
		private static void case24(int[] dp, int dpIdx, int dpL, int[] w)
		{
			dp[dpIdx] = Interpolation.Mix5To3(w[4], w[0]);
			dp[dpIdx + 1] = Interpolation.Mix4To2To1(w[4], w[1], w[0]);
			dp[dpIdx + 2] = Interpolation.Mix4To2To1(w[4], w[1], w[2]);
			dp[dpIdx + 3] = Interpolation.Mix5To3(w[4], w[2]);
			dp[dpIdx + dpL] = Interpolation.Mix3To1(w[4], w[0]);
			dp[dpIdx + dpL + 1] = Interpolation.Mix7To1(w[4], w[0]);
			dp[dpIdx + dpL + 2] = Interpolation.Mix7To1(w[4], w[2]);
			dp[dpIdx + dpL + 3] = Interpolation.Mix3To1(w[4], w[2]);
			dp[dpIdx + dpL + dpL] = Interpolation.Mix3To1(w[4], w[6]);
			dp[dpIdx + dpL + dpL + 1] = Interpolation.Mix7To1(w[4], w[6]);
			dp[dpIdx + dpL + dpL + 2] = Interpolation.Mix7To1(w[4], w[8]);
			dp[dpIdx + dpL + dpL + 3] = Interpolation.Mix3To1(w[4], w[8]);
			dp[dpIdx + dpL + dpL + dpL] = Interpolation.Mix5To3(w[4], w[6]);
			dp[dpIdx + dpL + dpL + dpL + 1] = Interpolation.Mix4To2To1(w[4], w[7], w[6]);
			dp[dpIdx + dpL + dpL + dpL + 2] = Interpolation.Mix4To2To1(w[4], w[7], w[8]);
			dp[dpIdx + dpL + dpL + dpL + 3] = Interpolation.Mix5To3(w[4], w[8]);
		}

		// Token: 0x0600100C RID: 4108 RVA: 0x00140ECC File Offset: 0x0013F0CC
		private static void case7(int[] dp, int dpIdx, int dpL, int[] w)
		{
			dp[dpIdx] = Interpolation.Mix5To3(w[4], w[3]);
			dp[dpIdx + 1] = Interpolation.Mix7To1(w[4], w[3]);
			dp[dpIdx + 2] = Interpolation.Mix7To1(w[4], w[5]);
			dp[dpIdx + 3] = Interpolation.Mix5To3(w[4], w[5]);
			dp[dpIdx + dpL] = Interpolation.Mix5To3(w[4], w[3]);
			dp[dpIdx + dpL + 1] = Interpolation.Mix7To1(w[4], w[3]);
			dp[dpIdx + dpL + 2] = Interpolation.Mix7To1(w[4], w[5]);
			dp[dpIdx + dpL + 3] = Interpolation.Mix5To3(w[4], w[5]);
			dp[dpIdx + dpL + dpL] = Interpolation.Mix4To2To1(w[4], w[3], w[7]);
			dp[dpIdx + dpL + dpL + 1] = Interpolation.Mix6To1To1(w[4], w[3], w[7]);
			dp[dpIdx + dpL + dpL + 2] = Interpolation.Mix6To1To1(w[4], w[5], w[7]);
			dp[dpIdx + dpL + dpL + 3] = Interpolation.Mix4To2To1(w[4], w[5], w[7]);
			dp[dpIdx + dpL + dpL + dpL] = Interpolation.Mix2To1To1(w[4], w[7], w[3]);
			dp[dpIdx + dpL + dpL + dpL + 1] = Interpolation.Mix4To2To1(w[4], w[7], w[3]);
			dp[dpIdx + dpL + dpL + dpL + 2] = Interpolation.Mix4To2To1(w[4], w[7], w[5]);
			dp[dpIdx + dpL + dpL + dpL + 3] = Interpolation.Mix2To1To1(w[4], w[7], w[5]);
		}

		// Token: 0x0600100D RID: 4109 RVA: 0x0014101C File Offset: 0x0013F21C
		private static void case148(int[] dp, int dpIdx, int dpL, int[] w)
		{
			dp[dpIdx] = Interpolation.Mix2To1To1(w[4], w[1], w[3]);
			dp[dpIdx + 1] = Interpolation.Mix4To2To1(w[4], w[1], w[3]);
			dp[dpIdx + 2] = Interpolation.Mix5To3(w[4], w[1]);
			dp[dpIdx + 3] = Interpolation.Mix5To3(w[4], w[1]);
			dp[dpIdx + dpL] = Interpolation.Mix4To2To1(w[4], w[3], w[1]);
			dp[dpIdx + dpL + 1] = Interpolation.Mix6To1To1(w[4], w[3], w[1]);
			dp[dpIdx + dpL + 2] = Interpolation.Mix7To1(w[4], w[1]);
			dp[dpIdx + dpL + 3] = Interpolation.Mix7To1(w[4], w[1]);
			dp[dpIdx + dpL + dpL] = Interpolation.Mix4To2To1(w[4], w[3], w[7]);
			dp[dpIdx + dpL + dpL + 1] = Interpolation.Mix6To1To1(w[4], w[3], w[7]);
			dp[dpIdx + dpL + dpL + 2] = Interpolation.Mix7To1(w[4], w[7]);
			dp[dpIdx + dpL + dpL + 3] = Interpolation.Mix7To1(w[4], w[7]);
			dp[dpIdx + dpL + dpL + dpL] = Interpolation.Mix2To1To1(w[4], w[7], w[3]);
			dp[dpIdx + dpL + dpL + dpL + 1] = Interpolation.Mix4To2To1(w[4], w[7], w[3]);
			dp[dpIdx + dpL + dpL + dpL + 2] = Interpolation.Mix5To3(w[4], w[7]);
			dp[dpIdx + dpL + dpL + dpL + 3] = Interpolation.Mix5To3(w[4], w[7]);
		}

		// Token: 0x0600100E RID: 4110 RVA: 0x0014116C File Offset: 0x0013F36C
		private static void case224(int[] dp, int dpIdx, int dpL, int[] w)
		{
			dp[dpIdx] = Interpolation.Mix2To1To1(w[4], w[1], w[3]);
			dp[dpIdx + 1] = Interpolation.Mix4To2To1(w[4], w[1], w[3]);
			dp[dpIdx + 2] = Interpolation.Mix4To2To1(w[4], w[1], w[5]);
			dp[dpIdx + 3] = Interpolation.Mix2To1To1(w[4], w[1], w[5]);
			dp[dpIdx + dpL] = Interpolation.Mix4To2To1(w[4], w[3], w[1]);
			dp[dpIdx + dpL + 1] = Interpolation.Mix6To1To1(w[4], w[3], w[1]);
			dp[dpIdx + dpL + 2] = Interpolation.Mix6To1To1(w[4], w[5], w[1]);
			dp[dpIdx + dpL + 3] = Interpolation.Mix4To2To1(w[4], w[5], w[1]);
			dp[dpIdx + dpL + dpL] = Interpolation.Mix5To3(w[4], w[3]);
			dp[dpIdx + dpL + dpL + 1] = Interpolation.Mix7To1(w[4], w[3]);
			dp[dpIdx + dpL + dpL + 2] = Interpolation.Mix7To1(w[4], w[5]);
			dp[dpIdx + dpL + dpL + 3] = Interpolation.Mix5To3(w[4], w[5]);
			dp[dpIdx + dpL + dpL + dpL] = Interpolation.Mix5To3(w[4], w[3]);
			dp[dpIdx + dpL + dpL + dpL + 1] = Interpolation.Mix7To1(w[4], w[3]);
			dp[dpIdx + dpL + dpL + dpL + 2] = Interpolation.Mix7To1(w[4], w[5]);
			dp[dpIdx + dpL + dpL + dpL + 3] = Interpolation.Mix5To3(w[4], w[5]);
		}

		// Token: 0x0600100F RID: 4111 RVA: 0x001412BC File Offset: 0x0013F4BC
		private static void case41(int[] dp, int dpIdx, int dpL, int[] w)
		{
			dp[dpIdx] = Interpolation.Mix5To3(w[4], w[1]);
			dp[dpIdx + 1] = Interpolation.Mix5To3(w[4], w[1]);
			dp[dpIdx + 2] = Interpolation.Mix4To2To1(w[4], w[1], w[5]);
			dp[dpIdx + 3] = Interpolation.Mix2To1To1(w[4], w[1], w[5]);
			dp[dpIdx + dpL] = Interpolation.Mix7To1(w[4], w[1]);
			dp[dpIdx + dpL + 1] = Interpolation.Mix7To1(w[4], w[1]);
			dp[dpIdx + dpL + 2] = Interpolation.Mix6To1To1(w[4], w[5], w[1]);
			dp[dpIdx + dpL + 3] = Interpolation.Mix4To2To1(w[4], w[5], w[1]);
			dp[dpIdx + dpL + dpL] = Interpolation.Mix7To1(w[4], w[7]);
			dp[dpIdx + dpL + dpL + 1] = Interpolation.Mix7To1(w[4], w[7]);
			dp[dpIdx + dpL + dpL + 2] = Interpolation.Mix6To1To1(w[4], w[5], w[7]);
			dp[dpIdx + dpL + dpL + 3] = Interpolation.Mix4To2To1(w[4], w[5], w[7]);
			dp[dpIdx + dpL + dpL + dpL] = Interpolation.Mix5To3(w[4], w[7]);
			dp[dpIdx + dpL + dpL + dpL + 1] = Interpolation.Mix5To3(w[4], w[7]);
			dp[dpIdx + dpL + dpL + dpL + 2] = Interpolation.Mix4To2To1(w[4], w[7], w[5]);
			dp[dpIdx + dpL + dpL + dpL + 3] = Interpolation.Mix2To1To1(w[4], w[7], w[5]);
		}

		// Token: 0x06001010 RID: 4112 RVA: 0x0014140C File Offset: 0x0013F60C
		private static void case67(int[] dp, int dpIdx, int dpL, int[] w)
		{
			dp[dpIdx] = Interpolation.Mix5To3(w[4], w[3]);
			dp[dpIdx + 1] = Interpolation.Mix7To1(w[4], w[3]);
			dp[dpIdx + 2] = Interpolation.Mix3To1(w[4], w[2]);
			dp[dpIdx + 3] = Interpolation.Mix5To3(w[4], w[2]);
			dp[dpIdx + dpL] = Interpolation.Mix5To3(w[4], w[3]);
			dp[dpIdx + dpL + 1] = Interpolation.Mix7To1(w[4], w[3]);
			dp[dpIdx + dpL + 2] = Interpolation.Mix7To1(w[4], w[2]);
			dp[dpIdx + dpL + 3] = Interpolation.Mix4To2To1(w[4], w[5], w[2]);
			dp[dpIdx + dpL + dpL] = Interpolation.Mix4To2To1(w[4], w[3], w[6]);
			dp[dpIdx + dpL + dpL + 1] = Interpolation.Mix7To1(w[4], w[6]);
			dp[dpIdx + dpL + dpL + 2] = Interpolation.Mix7To1(w[4], w[8]);
			dp[dpIdx + dpL + dpL + 3] = Interpolation.Mix4To2To1(w[4], w[5], w[8]);
			dp[dpIdx + dpL + dpL + dpL] = Interpolation.Mix5To3(w[4], w[6]);
			dp[dpIdx + dpL + dpL + dpL + 1] = Interpolation.Mix3To1(w[4], w[6]);
			dp[dpIdx + dpL + dpL + dpL + 2] = Interpolation.Mix3To1(w[4], w[8]);
			dp[dpIdx + dpL + dpL + dpL + 3] = Interpolation.Mix5To3(w[4], w[8]);
		}

		// Token: 0x06001011 RID: 4113 RVA: 0x0014154C File Offset: 0x0013F74C
		private static void case70(int[] dp, int dpIdx, int dpL, int[] w)
		{
			dp[dpIdx] = Interpolation.Mix5To3(w[4], w[0]);
			dp[dpIdx + 1] = Interpolation.Mix3To1(w[4], w[0]);
			dp[dpIdx + 2] = Interpolation.Mix7To1(w[4], w[5]);
			dp[dpIdx + 3] = Interpolation.Mix5To3(w[4], w[5]);
			dp[dpIdx + dpL] = Interpolation.Mix4To2To1(w[4], w[3], w[0]);
			dp[dpIdx + dpL + 1] = Interpolation.Mix7To1(w[4], w[0]);
			dp[dpIdx + dpL + 2] = Interpolation.Mix7To1(w[4], w[5]);
			dp[dpIdx + dpL + 3] = Interpolation.Mix5To3(w[4], w[5]);
			dp[dpIdx + dpL + dpL] = Interpolation.Mix4To2To1(w[4], w[3], w[6]);
			dp[dpIdx + dpL + dpL + 1] = Interpolation.Mix7To1(w[4], w[6]);
			dp[dpIdx + dpL + dpL + 2] = Interpolation.Mix7To1(w[4], w[8]);
			dp[dpIdx + dpL + dpL + 3] = Interpolation.Mix4To2To1(w[4], w[5], w[8]);
			dp[dpIdx + dpL + dpL + dpL] = Interpolation.Mix5To3(w[4], w[6]);
			dp[dpIdx + dpL + dpL + dpL + 1] = Interpolation.Mix3To1(w[4], w[6]);
			dp[dpIdx + dpL + dpL + dpL + 2] = Interpolation.Mix3To1(w[4], w[8]);
			dp[dpIdx + dpL + dpL + dpL + 3] = Interpolation.Mix5To3(w[4], w[8]);
		}

		// Token: 0x06001012 RID: 4114 RVA: 0x0014168C File Offset: 0x0013F88C
		private static void case28(int[] dp, int dpIdx, int dpL, int[] w)
		{
			dp[dpIdx] = Interpolation.Mix5To3(w[4], w[0]);
			dp[dpIdx + 1] = Interpolation.Mix4To2To1(w[4], w[1], w[0]);
			dp[dpIdx + 2] = Interpolation.Mix5To3(w[4], w[1]);
			dp[dpIdx + 3] = Interpolation.Mix5To3(w[4], w[1]);
			dp[dpIdx + dpL] = Interpolation.Mix3To1(w[4], w[0]);
			dp[dpIdx + dpL + 1] = Interpolation.Mix7To1(w[4], w[0]);
			dp[dpIdx + dpL + 2] = Interpolation.Mix7To1(w[4], w[1]);
			dp[dpIdx + dpL + 3] = Interpolation.Mix7To1(w[4], w[1]);
			dp[dpIdx + dpL + dpL] = Interpolation.Mix3To1(w[4], w[6]);
			dp[dpIdx + dpL + dpL + 1] = Interpolation.Mix7To1(w[4], w[6]);
			dp[dpIdx + dpL + dpL + 2] = Interpolation.Mix7To1(w[4], w[8]);
			dp[dpIdx + dpL + dpL + 3] = Interpolation.Mix3To1(w[4], w[8]);
			dp[dpIdx + dpL + dpL + dpL] = Interpolation.Mix5To3(w[4], w[6]);
			dp[dpIdx + dpL + dpL + dpL + 1] = Interpolation.Mix4To2To1(w[4], w[7], w[6]);
			dp[dpIdx + dpL + dpL + dpL + 2] = Interpolation.Mix4To2To1(w[4], w[7], w[8]);
			dp[dpIdx + dpL + dpL + dpL + 3] = Interpolation.Mix5To3(w[4], w[8]);
		}

		// Token: 0x06001013 RID: 4115 RVA: 0x001417CC File Offset: 0x0013F9CC
		private static void case152(int[] dp, int dpIdx, int dpL, int[] w)
		{
			dp[dpIdx] = Interpolation.Mix5To3(w[4], w[0]);
			dp[dpIdx + 1] = Interpolation.Mix4To2To1(w[4], w[1], w[0]);
			dp[dpIdx + 2] = Interpolation.Mix4To2To1(w[4], w[1], w[2]);
			dp[dpIdx + 3] = Interpolation.Mix5To3(w[4], w[2]);
			dp[dpIdx + dpL] = Interpolation.Mix3To1(w[4], w[0]);
			dp[dpIdx + dpL + 1] = Interpolation.Mix7To1(w[4], w[0]);
			dp[dpIdx + dpL + 2] = Interpolation.Mix7To1(w[4], w[2]);
			dp[dpIdx + dpL + 3] = Interpolation.Mix3To1(w[4], w[2]);
			dp[dpIdx + dpL + dpL] = Interpolation.Mix3To1(w[4], w[6]);
			dp[dpIdx + dpL + dpL + 1] = Interpolation.Mix7To1(w[4], w[6]);
			dp[dpIdx + dpL + dpL + 2] = Interpolation.Mix7To1(w[4], w[7]);
			dp[dpIdx + dpL + dpL + 3] = Interpolation.Mix7To1(w[4], w[7]);
			dp[dpIdx + dpL + dpL + dpL] = Interpolation.Mix5To3(w[4], w[6]);
			dp[dpIdx + dpL + dpL + dpL + 1] = Interpolation.Mix4To2To1(w[4], w[7], w[6]);
			dp[dpIdx + dpL + dpL + dpL + 2] = Interpolation.Mix5To3(w[4], w[7]);
			dp[dpIdx + dpL + dpL + dpL + 3] = Interpolation.Mix5To3(w[4], w[7]);
		}

		// Token: 0x06001014 RID: 4116 RVA: 0x0014190C File Offset: 0x0013FB0C
		private static void case194(int[] dp, int dpIdx, int dpL, int[] w)
		{
			dp[dpIdx] = Interpolation.Mix5To3(w[4], w[0]);
			dp[dpIdx + 1] = Interpolation.Mix3To1(w[4], w[0]);
			dp[dpIdx + 2] = Interpolation.Mix3To1(w[4], w[2]);
			dp[dpIdx + 3] = Interpolation.Mix5To3(w[4], w[2]);
			dp[dpIdx + dpL] = Interpolation.Mix4To2To1(w[4], w[3], w[0]);
			dp[dpIdx + dpL + 1] = Interpolation.Mix7To1(w[4], w[0]);
			dp[dpIdx + dpL + 2] = Interpolation.Mix7To1(w[4], w[2]);
			dp[dpIdx + dpL + 3] = Interpolation.Mix4To2To1(w[4], w[5], w[2]);
			dp[dpIdx + dpL + dpL] = Interpolation.Mix4To2To1(w[4], w[3], w[6]);
			dp[dpIdx + dpL + dpL + 1] = Interpolation.Mix7To1(w[4], w[6]);
			dp[dpIdx + dpL + dpL + 2] = Interpolation.Mix7To1(w[4], w[5]);
			dp[dpIdx + dpL + dpL + 3] = Interpolation.Mix5To3(w[4], w[5]);
			dp[dpIdx + dpL + dpL + dpL] = Interpolation.Mix5To3(w[4], w[6]);
			dp[dpIdx + dpL + dpL + dpL + 1] = Interpolation.Mix3To1(w[4], w[6]);
			dp[dpIdx + dpL + dpL + dpL + 2] = Interpolation.Mix7To1(w[4], w[5]);
			dp[dpIdx + dpL + dpL + dpL + 3] = Interpolation.Mix5To3(w[4], w[5]);
		}

		// Token: 0x06001015 RID: 4117 RVA: 0x00141A4C File Offset: 0x0013FC4C
		private static void case98(int[] dp, int dpIdx, int dpL, int[] w)
		{
			dp[dpIdx] = Interpolation.Mix5To3(w[4], w[0]);
			dp[dpIdx + 1] = Interpolation.Mix3To1(w[4], w[0]);
			dp[dpIdx + 2] = Interpolation.Mix3To1(w[4], w[2]);
			dp[dpIdx + 3] = Interpolation.Mix5To3(w[4], w[2]);
			dp[dpIdx + dpL] = Interpolation.Mix4To2To1(w[4], w[3], w[0]);
			dp[dpIdx + dpL + 1] = Interpolation.Mix7To1(w[4], w[0]);
			dp[dpIdx + dpL + 2] = Interpolation.Mix7To1(w[4], w[2]);
			dp[dpIdx + dpL + 3] = Interpolation.Mix4To2To1(w[4], w[5], w[2]);
			dp[dpIdx + dpL + dpL] = Interpolation.Mix5To3(w[4], w[3]);
			dp[dpIdx + dpL + dpL + 1] = Interpolation.Mix7To1(w[4], w[3]);
			dp[dpIdx + dpL + dpL + 2] = Interpolation.Mix7To1(w[4], w[8]);
			dp[dpIdx + dpL + dpL + 3] = Interpolation.Mix4To2To1(w[4], w[5], w[8]);
			dp[dpIdx + dpL + dpL + dpL] = Interpolation.Mix5To3(w[4], w[3]);
			dp[dpIdx + dpL + dpL + dpL + 1] = Interpolation.Mix7To1(w[4], w[3]);
			dp[dpIdx + dpL + dpL + dpL + 2] = Interpolation.Mix3To1(w[4], w[8]);
			dp[dpIdx + dpL + dpL + dpL + 3] = Interpolation.Mix5To3(w[4], w[8]);
		}

		// Token: 0x06001016 RID: 4118 RVA: 0x00141B8C File Offset: 0x0013FD8C
		private static void case56(int[] dp, int dpIdx, int dpL, int[] w)
		{
			dp[dpIdx] = Interpolation.Mix5To3(w[4], w[0]);
			dp[dpIdx + 1] = Interpolation.Mix4To2To1(w[4], w[1], w[0]);
			dp[dpIdx + 2] = Interpolation.Mix4To2To1(w[4], w[1], w[2]);
			dp[dpIdx + 3] = Interpolation.Mix5To3(w[4], w[2]);
			dp[dpIdx + dpL] = Interpolation.Mix3To1(w[4], w[0]);
			dp[dpIdx + dpL + 1] = Interpolation.Mix7To1(w[4], w[0]);
			dp[dpIdx + dpL + 2] = Interpolation.Mix7To1(w[4], w[2]);
			dp[dpIdx + dpL + 3] = Interpolation.Mix3To1(w[4], w[2]);
			dp[dpIdx + dpL + dpL] = Interpolation.Mix7To1(w[4], w[7]);
			dp[dpIdx + dpL + dpL + 1] = Interpolation.Mix7To1(w[4], w[7]);
			dp[dpIdx + dpL + dpL + 2] = Interpolation.Mix7To1(w[4], w[8]);
			dp[dpIdx + dpL + dpL + 3] = Interpolation.Mix3To1(w[4], w[8]);
			dp[dpIdx + dpL + dpL + dpL] = Interpolation.Mix5To3(w[4], w[7]);
			dp[dpIdx + dpL + dpL + dpL + 1] = Interpolation.Mix5To3(w[4], w[7]);
			dp[dpIdx + dpL + dpL + dpL + 2] = Interpolation.Mix4To2To1(w[4], w[7], w[8]);
			dp[dpIdx + dpL + dpL + dpL + 3] = Interpolation.Mix5To3(w[4], w[8]);
		}

		// Token: 0x06001017 RID: 4119 RVA: 0x00141CCC File Offset: 0x0013FECC
		private static void case25(int[] dp, int dpIdx, int dpL, int[] w)
		{
			dp[dpIdx] = Interpolation.Mix5To3(w[4], w[1]);
			dp[dpIdx + 1] = Interpolation.Mix5To3(w[4], w[1]);
			dp[dpIdx + 2] = Interpolation.Mix4To2To1(w[4], w[1], w[2]);
			dp[dpIdx + 3] = Interpolation.Mix5To3(w[4], w[2]);
			dp[dpIdx + dpL] = Interpolation.Mix7To1(w[4], w[1]);
			dp[dpIdx + dpL + 1] = Interpolation.Mix7To1(w[4], w[1]);
			dp[dpIdx + dpL + 2] = Interpolation.Mix7To1(w[4], w[2]);
			dp[dpIdx + dpL + 3] = Interpolation.Mix3To1(w[4], w[2]);
			dp[dpIdx + dpL + dpL] = Interpolation.Mix3To1(w[4], w[6]);
			dp[dpIdx + dpL + dpL + 1] = Interpolation.Mix7To1(w[4], w[6]);
			dp[dpIdx + dpL + dpL + 2] = Interpolation.Mix7To1(w[4], w[8]);
			dp[dpIdx + dpL + dpL + 3] = Interpolation.Mix3To1(w[4], w[8]);
			dp[dpIdx + dpL + dpL + dpL] = Interpolation.Mix5To3(w[4], w[6]);
			dp[dpIdx + dpL + dpL + dpL + 1] = Interpolation.Mix4To2To1(w[4], w[7], w[6]);
			dp[dpIdx + dpL + dpL + dpL + 2] = Interpolation.Mix4To2To1(w[4], w[7], w[8]);
			dp[dpIdx + dpL + dpL + dpL + 3] = Interpolation.Mix5To3(w[4], w[8]);
		}

		// Token: 0x06001018 RID: 4120 RVA: 0x00141E0C File Offset: 0x0014000C
		public static void hq4x_32_rb(int[] sp, int[] dp, int Xres, int Yres, int trY, int trU, int trV, int trA, bool wrapX, bool wrapY)
		{
			int num = 0;
			int num2 = 0;
			trY <<= 16;
			trU <<= 8;
			int num3 = Xres * 4;
			int[] array = new int[9];
			int num8;
			for (int i = 0; i < Yres; i = num8 + 1)
			{
				int num4 = (i > 0) ? (-Xres) : (wrapY ? (Xres * (Yres - 1)) : 0);
				int num5 = (i < Yres - 1) ? Xres : (wrapY ? (-(Xres * (Yres - 1))) : 0);
				for (int j = 0; j < Xres; j = num8 + 1)
				{
					array[1] = sp[num + num4];
					array[4] = sp[num];
					array[7] = sp[num + num5];
					bool flag = j > 0;
					if (flag)
					{
						array[0] = sp[num + num4 - 1];
						array[3] = sp[num - 1];
						array[6] = sp[num + num5 - 1];
					}
					else if (wrapX)
					{
						array[0] = sp[num + num4 + Xres - 1];
						array[3] = sp[num + Xres - 1];
						array[6] = sp[num + num5 + Xres - 1];
					}
					else
					{
						array[0] = array[1];
						array[3] = array[4];
						array[6] = array[7];
					}
					bool flag2 = j < Xres - 1;
					if (flag2)
					{
						array[2] = sp[num + num4 + 1];
						array[5] = sp[num + 1];
						array[8] = sp[num + num5 + 1];
					}
					else if (wrapX)
					{
						array[2] = sp[num + num4 - Xres + 1];
						array[5] = sp[num - Xres + 1];
						array[8] = sp[num + num5 - Xres + 1];
					}
					else
					{
						array[2] = array[1];
						array[5] = array[4];
						array[8] = array[7];
					}
					int num6 = 0;
					int num7 = 1;
					for (int k = 0; k < 9; k = num8 + 1)
					{
						bool flag3 = k != 4;
						if (flag3)
						{
							bool flag4 = array[k] != array[4] && Hqx.diff(array[4], array[k], trY, trU, trV, trA);
							if (flag4)
							{
								num6 |= num7;
							}
							num7 <<= 1;
						}
						num8 = k;
					}
					switch (num6)
					{
					case 0:
					case 1:
					case 4:
					case 5:
					case 32:
					case 33:
					case 36:
					case 37:
					case 128:
					case 129:
					case 132:
					case 133:
					case 160:
					case 161:
					case 164:
					case 165:
						Hqx_4x.case0(dp, num2, num3, array);
						break;
					case 2:
					case 34:
					case 130:
					case 162:
						Hqx_4x.case2(dp, num2, num3, array);
						break;
					case 3:
					case 35:
					case 131:
					case 163:
						Hqx_4x.case3(dp, num2, num3, array);
						break;
					case 6:
					case 38:
					case 134:
					case 166:
						Hqx_4x.case6(dp, num2, num3, array);
						break;
					case 7:
					case 39:
					case 135:
						Hqx_4x.case7(dp, num2, num3, array);
						break;
					case 8:
					case 12:
					case 136:
					case 140:
						Hqx_4x.case8(dp, num2, num3, array);
						break;
					case 9:
					case 13:
					case 137:
					case 141:
						Hqx_4x.case9(dp, num2, num3, array);
						break;
					case 10:
					case 138:
					{
						bool flag5 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag5)
						{
							dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
							dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
							dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
							dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						}
						else
						{
							dp[num2] = Interpolation.MixEven(array[1], array[3]);
							dp[num2 + 1] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + num3] = Interpolation.MixEven(array[3], array[4]);
							dp[num2 + num3 + 1] = array[4];
						}
						dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[2]);
						dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix6To1To1(array[4], array[5], array[7]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[7]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix4To2To1(array[4], array[7], array[6]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix4To2To1(array[4], array[7], array[5]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix2To1To1(array[4], array[7], array[5]);
						break;
					}
					case 11:
					case 139:
					{
						bool flag6 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag6)
						{
							dp[num2] = array[4];
							dp[num2 + 1] = array[4];
							dp[num2 + num3] = array[4];
						}
						else
						{
							dp[num2] = Interpolation.MixEven(array[1], array[3]);
							dp[num2 + 1] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + num3] = Interpolation.MixEven(array[3], array[4]);
						}
						dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3 + 1] = array[4];
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[2]);
						dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix6To1To1(array[4], array[5], array[7]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[7]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix4To2To1(array[4], array[7], array[6]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix4To2To1(array[4], array[7], array[5]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix2To1To1(array[4], array[7], array[5]);
						break;
					}
					case 14:
					case 142:
					{
						bool flag7 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag7)
						{
							dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
							dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
							dp[num2 + 2] = Interpolation.Mix7To1(array[4], array[5]);
							dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[5]);
							dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
							dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						}
						else
						{
							dp[num2] = Interpolation.MixEven(array[1], array[3]);
							dp[num2 + 1] = Interpolation.Mix5To3(array[1], array[3]);
							dp[num2 + 2] = Interpolation.Mix3To1(array[1], array[4]);
							dp[num2 + 3] = Interpolation.Mix3To1(array[4], array[1]);
							dp[num2 + num3] = Interpolation.Mix2To1To1(array[3], array[4], array[1]);
							dp[num2 + num3 + 1] = Interpolation.Mix6To1To1(array[4], array[3], array[1]);
						}
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix6To1To1(array[4], array[5], array[7]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[7]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix4To2To1(array[4], array[7], array[6]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix4To2To1(array[4], array[7], array[5]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix2To1To1(array[4], array[7], array[5]);
						break;
					}
					case 15:
					case 143:
					{
						bool flag8 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag8)
						{
							dp[num2] = array[4];
							dp[num2 + 1] = array[4];
							dp[num2 + 2] = Interpolation.Mix7To1(array[4], array[5]);
							dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[5]);
							dp[num2 + num3] = array[4];
							dp[num2 + num3 + 1] = array[4];
						}
						else
						{
							dp[num2] = Interpolation.MixEven(array[1], array[3]);
							dp[num2 + 1] = Interpolation.Mix5To3(array[1], array[3]);
							dp[num2 + 2] = Interpolation.Mix3To1(array[1], array[4]);
							dp[num2 + 3] = Interpolation.Mix3To1(array[4], array[1]);
							dp[num2 + num3] = Interpolation.Mix2To1To1(array[3], array[4], array[1]);
							dp[num2 + num3 + 1] = Interpolation.Mix6To1To1(array[4], array[3], array[1]);
						}
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix6To1To1(array[4], array[5], array[7]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[7]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix4To2To1(array[4], array[7], array[6]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix4To2To1(array[4], array[7], array[5]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix2To1To1(array[4], array[7], array[5]);
						break;
					}
					case 16:
					case 17:
					case 48:
					case 49:
						Hqx_4x.case16(dp, num2, num3, array);
						break;
					case 18:
					case 50:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
						bool flag9 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag9)
						{
							dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
							dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
							dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
							dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						}
						else
						{
							dp[num2 + 2] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + 3] = Interpolation.MixEven(array[1], array[5]);
							dp[num2 + num3 + 2] = array[4];
							dp[num2 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
						}
						dp[num2 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[7]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix6To1To1(array[4], array[3], array[7]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix2To1To1(array[4], array[7], array[3]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix4To2To1(array[4], array[7], array[3]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix4To2To1(array[4], array[7], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					}
					case 19:
					case 51:
					{
						bool flag10 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag10)
						{
							dp[num2] = Interpolation.Mix5To3(array[4], array[3]);
							dp[num2 + 1] = Interpolation.Mix7To1(array[4], array[3]);
							dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
							dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
							dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
							dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						}
						else
						{
							dp[num2] = Interpolation.Mix3To1(array[4], array[1]);
							dp[num2 + 1] = Interpolation.Mix3To1(array[1], array[4]);
							dp[num2 + 2] = Interpolation.Mix5To3(array[1], array[5]);
							dp[num2 + 3] = Interpolation.MixEven(array[1], array[5]);
							dp[num2 + num3 + 2] = Interpolation.Mix6To1To1(array[4], array[5], array[1]);
							dp[num2 + num3 + 3] = Interpolation.Mix2To1To1(array[5], array[4], array[1]);
						}
						dp[num2 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[7]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix6To1To1(array[4], array[3], array[7]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix2To1To1(array[4], array[7], array[3]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix4To2To1(array[4], array[7], array[3]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix4To2To1(array[4], array[7], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					}
					case 20:
					case 21:
					case 52:
					case 53:
						Hqx_4x.case20(dp, num2, num3, array);
						break;
					case 22:
					case 54:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
						bool flag11 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag11)
						{
							dp[num2 + 2] = array[4];
							dp[num2 + 3] = array[4];
							dp[num2 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + 2] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + 3] = Interpolation.MixEven(array[1], array[5]);
							dp[num2 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
						}
						dp[num2 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + 2] = array[4];
						dp[num2 + num3 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[7]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix6To1To1(array[4], array[3], array[7]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix2To1To1(array[4], array[7], array[3]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix4To2To1(array[4], array[7], array[3]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix4To2To1(array[4], array[7], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					}
					case 23:
					case 55:
					{
						bool flag12 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag12)
						{
							dp[num2] = Interpolation.Mix5To3(array[4], array[3]);
							dp[num2 + 1] = Interpolation.Mix7To1(array[4], array[3]);
							dp[num2 + 2] = array[4];
							dp[num2 + 3] = array[4];
							dp[num2 + num3 + 2] = array[4];
							dp[num2 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2] = Interpolation.Mix3To1(array[4], array[1]);
							dp[num2 + 1] = Interpolation.Mix3To1(array[1], array[4]);
							dp[num2 + 2] = Interpolation.Mix5To3(array[1], array[5]);
							dp[num2 + 3] = Interpolation.MixEven(array[1], array[5]);
							dp[num2 + num3 + 2] = Interpolation.Mix6To1To1(array[4], array[5], array[1]);
							dp[num2 + num3 + 3] = Interpolation.Mix2To1To1(array[5], array[4], array[1]);
						}
						dp[num2 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[7]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix6To1To1(array[4], array[3], array[7]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix2To1To1(array[4], array[7], array[3]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix4To2To1(array[4], array[7], array[3]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix4To2To1(array[4], array[7], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					}
					case 24:
						Hqx_4x.case24(dp, num2, num3, array);
						break;
					case 25:
						Hqx_4x.case25(dp, num2, num3, array);
						break;
					case 26:
					case 31:
					{
						bool flag13 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag13)
						{
							dp[num2] = array[4];
							dp[num2 + 1] = array[4];
							dp[num2 + num3] = array[4];
						}
						else
						{
							dp[num2] = Interpolation.MixEven(array[1], array[3]);
							dp[num2 + 1] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + num3] = Interpolation.MixEven(array[3], array[4]);
						}
						bool flag14 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag14)
						{
							dp[num2 + 2] = array[4];
							dp[num2 + 3] = array[4];
							dp[num2 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + 2] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + 3] = Interpolation.MixEven(array[1], array[5]);
							dp[num2 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
						}
						dp[num2 + num3 + 1] = array[4];
						dp[num2 + num3 + 2] = array[4];
						dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix4To2To1(array[4], array[7], array[6]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix4To2To1(array[4], array[7], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					}
					case 27:
					{
						bool flag15 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag15)
						{
							dp[num2] = array[4];
							dp[num2 + 1] = array[4];
							dp[num2 + num3] = array[4];
						}
						else
						{
							dp[num2] = Interpolation.MixEven(array[1], array[3]);
							dp[num2 + 1] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + num3] = Interpolation.MixEven(array[3], array[4]);
						}
						dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3 + 1] = array[4];
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix4To2To1(array[4], array[7], array[6]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix4To2To1(array[4], array[7], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					}
					case 28:
						Hqx_4x.case28(dp, num2, num3, array);
						break;
					case 29:
						dp[num2] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 1] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 2] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + num3] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 3] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix4To2To1(array[4], array[7], array[6]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix4To2To1(array[4], array[7], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					case 30:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
						bool flag16 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag16)
						{
							dp[num2 + 2] = array[4];
							dp[num2 + 3] = array[4];
							dp[num2 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + 2] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + 3] = Interpolation.MixEven(array[1], array[5]);
							dp[num2 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
						}
						dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + 2] = array[4];
						dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix4To2To1(array[4], array[7], array[6]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix4To2To1(array[4], array[7], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					}
					case 40:
					case 44:
					case 168:
					case 172:
						Hqx_4x.case40(dp, num2, num3, array);
						break;
					case 41:
					case 45:
					case 169:
						Hqx_4x.case41(dp, num2, num3, array);
						break;
					case 42:
					case 170:
					{
						bool flag17 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag17)
						{
							dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
							dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
							dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
							dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
							dp[num2 + num3 + num3] = Interpolation.Mix7To1(array[4], array[7]);
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[7]);
						}
						else
						{
							dp[num2] = Interpolation.MixEven(array[1], array[3]);
							dp[num2 + 1] = Interpolation.Mix2To1To1(array[1], array[4], array[3]);
							dp[num2 + num3] = Interpolation.Mix5To3(array[3], array[1]);
							dp[num2 + num3 + 1] = Interpolation.Mix6To1To1(array[4], array[3], array[1]);
							dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[3], array[4]);
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix3To1(array[4], array[3]);
						}
						dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[2]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix6To1To1(array[4], array[5], array[7]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[7]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix4To2To1(array[4], array[7], array[5]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix2To1To1(array[4], array[7], array[5]);
						break;
					}
					case 43:
					case 171:
					{
						bool flag18 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag18)
						{
							dp[num2] = array[4];
							dp[num2 + 1] = array[4];
							dp[num2 + num3] = array[4];
							dp[num2 + num3 + 1] = array[4];
							dp[num2 + num3 + num3] = Interpolation.Mix7To1(array[4], array[7]);
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[7]);
						}
						else
						{
							dp[num2] = Interpolation.MixEven(array[1], array[3]);
							dp[num2 + 1] = Interpolation.Mix2To1To1(array[1], array[4], array[3]);
							dp[num2 + num3] = Interpolation.Mix5To3(array[3], array[1]);
							dp[num2 + num3 + 1] = Interpolation.Mix6To1To1(array[4], array[3], array[1]);
							dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[3], array[4]);
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix3To1(array[4], array[3]);
						}
						dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[2]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix6To1To1(array[4], array[5], array[7]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[7]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix4To2To1(array[4], array[7], array[5]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix2To1To1(array[4], array[7], array[5]);
						break;
					}
					case 46:
					case 174:
					{
						bool flag19 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag19)
						{
							dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
							dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
							dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
							dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						}
						else
						{
							dp[num2] = Interpolation.Mix2To1To1(array[4], array[1], array[3]);
							dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[1]);
							dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[3]);
							dp[num2 + num3 + 1] = array[4];
						}
						dp[num2 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3 + num3] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix6To1To1(array[4], array[5], array[7]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[7]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix4To2To1(array[4], array[7], array[5]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix2To1To1(array[4], array[7], array[5]);
						break;
					}
					case 47:
					case 175:
					{
						bool flag20 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag20)
						{
							dp[num2] = array[4];
						}
						else
						{
							dp[num2] = Interpolation.Mix2To1To1(array[4], array[1], array[3]);
						}
						dp[num2 + 1] = array[4];
						dp[num2 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3] = array[4];
						dp[num2 + num3 + 1] = array[4];
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3 + num3] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix6To1To1(array[4], array[5], array[7]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[7]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix4To2To1(array[4], array[7], array[5]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix2To1To1(array[4], array[7], array[5]);
						break;
					}
					case 56:
						Hqx_4x.case56(dp, num2, num3, array);
						break;
					case 57:
						dp[num2] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 1] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 2] = Interpolation.Mix4To2To1(array[4], array[1], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + num3 + num3] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix4To2To1(array[4], array[7], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					case 58:
					{
						bool flag21 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag21)
						{
							dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
							dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
							dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
							dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						}
						else
						{
							dp[num2] = Interpolation.Mix2To1To1(array[4], array[1], array[3]);
							dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[1]);
							dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[3]);
							dp[num2 + num3 + 1] = array[4];
						}
						bool flag22 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag22)
						{
							dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
							dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
							dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
							dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						}
						else
						{
							dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[1]);
							dp[num2 + 3] = Interpolation.Mix2To1To1(array[4], array[1], array[5]);
							dp[num2 + num3 + 2] = array[4];
							dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[5]);
						}
						dp[num2 + num3 + num3] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix4To2To1(array[4], array[7], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					}
					case 59:
					{
						bool flag23 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag23)
						{
							dp[num2] = array[4];
							dp[num2 + 1] = array[4];
							dp[num2 + num3] = array[4];
						}
						else
						{
							dp[num2] = Interpolation.MixEven(array[1], array[3]);
							dp[num2 + 1] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + num3] = Interpolation.MixEven(array[3], array[4]);
						}
						bool flag24 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag24)
						{
							dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
							dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
							dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
							dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						}
						else
						{
							dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[1]);
							dp[num2 + 3] = Interpolation.Mix2To1To1(array[4], array[1], array[5]);
							dp[num2 + num3 + 2] = array[4];
							dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[5]);
						}
						dp[num2 + num3 + 1] = array[4];
						dp[num2 + num3 + num3] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix4To2To1(array[4], array[7], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					}
					case 60:
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix4To2To1(array[4], array[1], array[0]);
						dp[num2 + 2] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 3] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + num3] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix4To2To1(array[4], array[7], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					case 61:
						dp[num2] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 1] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 2] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + num3] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 3] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + num3] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix4To2To1(array[4], array[7], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					case 62:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
						bool flag25 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag25)
						{
							dp[num2 + 2] = array[4];
							dp[num2 + 3] = array[4];
							dp[num2 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + 2] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + 3] = Interpolation.MixEven(array[1], array[5]);
							dp[num2 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
						}
						dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + 2] = array[4];
						dp[num2 + num3 + num3] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix4To2To1(array[4], array[7], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					}
					case 63:
					{
						bool flag26 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag26)
						{
							dp[num2] = array[4];
						}
						else
						{
							dp[num2] = Interpolation.Mix2To1To1(array[4], array[1], array[3]);
						}
						dp[num2 + 1] = array[4];
						bool flag27 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag27)
						{
							dp[num2 + 2] = array[4];
							dp[num2 + 3] = array[4];
							dp[num2 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + 2] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + 3] = Interpolation.MixEven(array[1], array[5]);
							dp[num2 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
						}
						dp[num2 + num3] = array[4];
						dp[num2 + num3 + 1] = array[4];
						dp[num2 + num3 + 2] = array[4];
						dp[num2 + num3 + num3] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix4To2To1(array[4], array[7], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					}
					case 64:
					case 65:
					case 68:
					case 69:
						Hqx_4x.case64(dp, num2, num3, array);
						break;
					case 66:
						Hqx_4x.case66(dp, num2, num3, array);
						break;
					case 67:
						Hqx_4x.case67(dp, num2, num3, array);
						break;
					case 70:
						Hqx_4x.case70(dp, num2, num3, array);
						break;
					case 71:
						dp[num2] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[8]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					case 72:
					case 76:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix4To2To1(array[4], array[1], array[0]);
						dp[num2 + 2] = Interpolation.Mix4To2To1(array[4], array[1], array[5]);
						dp[num2 + 3] = Interpolation.Mix2To1To1(array[4], array[1], array[5]);
						dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + 2] = Interpolation.Mix6To1To1(array[4], array[5], array[1]);
						dp[num2 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[1]);
						bool flag28 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag28)
						{
							dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
							dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						}
						else
						{
							dp[num2 + num3 + num3] = Interpolation.MixEven(array[3], array[4]);
							dp[num2 + num3 + num3 + 1] = array[4];
							dp[num2 + num3 + num3 + num3] = Interpolation.MixEven(array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.MixEven(array[7], array[4]);
						}
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[8]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					}
					case 73:
					case 77:
					{
						bool flag29 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag29)
						{
							dp[num2] = Interpolation.Mix5To3(array[4], array[1]);
							dp[num2 + num3] = Interpolation.Mix7To1(array[4], array[1]);
							dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
							dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						}
						else
						{
							dp[num2] = Interpolation.Mix3To1(array[4], array[3]);
							dp[num2 + num3] = Interpolation.Mix3To1(array[3], array[4]);
							dp[num2 + num3 + num3] = Interpolation.Mix5To3(array[3], array[7]);
							dp[num2 + num3 + num3 + 1] = Interpolation.Mix6To1To1(array[4], array[3], array[7]);
							dp[num2 + num3 + num3 + num3] = Interpolation.MixEven(array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix2To1To1(array[7], array[4], array[3]);
						}
						dp[num2 + 1] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 2] = Interpolation.Mix4To2To1(array[4], array[1], array[5]);
						dp[num2 + 3] = Interpolation.Mix2To1To1(array[4], array[1], array[5]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 2] = Interpolation.Mix6To1To1(array[4], array[5], array[1]);
						dp[num2 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[1]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[8]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					}
					case 74:
					case 107:
					{
						bool flag30 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag30)
						{
							dp[num2] = array[4];
							dp[num2 + 1] = array[4];
							dp[num2 + num3] = array[4];
						}
						else
						{
							dp[num2] = Interpolation.MixEven(array[1], array[3]);
							dp[num2 + 1] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + num3] = Interpolation.MixEven(array[3], array[4]);
						}
						dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3 + 1] = array[4];
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[2]);
						bool flag31 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag31)
						{
							dp[num2 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3 + 1] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3] = Interpolation.MixEven(array[3], array[4]);
							dp[num2 + num3 + num3 + num3] = Interpolation.MixEven(array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.MixEven(array[7], array[4]);
						}
						dp[num2 + num3 + num3 + 1] = array[4];
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[8]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					}
					case 75:
					{
						bool flag32 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag32)
						{
							dp[num2] = array[4];
							dp[num2 + 1] = array[4];
							dp[num2 + num3] = array[4];
						}
						else
						{
							dp[num2] = Interpolation.MixEven(array[1], array[3]);
							dp[num2 + 1] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + num3] = Interpolation.MixEven(array[3], array[4]);
						}
						dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3 + 1] = array[4];
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[2]);
						dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[8]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					}
					case 78:
					{
						bool flag33 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag33)
						{
							dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
							dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
							dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
							dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						}
						else
						{
							dp[num2] = Interpolation.Mix2To1To1(array[4], array[1], array[3]);
							dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[1]);
							dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[3]);
							dp[num2 + num3 + 1] = array[4];
						}
						dp[num2 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						bool flag34 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag34)
						{
							dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
							dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						}
						else
						{
							dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[3]);
							dp[num2 + num3 + num3 + 1] = array[4];
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix2To1To1(array[4], array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[7]);
						}
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[8]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					}
					case 79:
					{
						bool flag35 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag35)
						{
							dp[num2] = array[4];
							dp[num2 + 1] = array[4];
							dp[num2 + num3] = array[4];
						}
						else
						{
							dp[num2] = Interpolation.MixEven(array[1], array[3]);
							dp[num2 + 1] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + num3] = Interpolation.MixEven(array[3], array[4]);
						}
						dp[num2 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3 + 1] = array[4];
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						bool flag36 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag36)
						{
							dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
							dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						}
						else
						{
							dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[3]);
							dp[num2 + num3 + num3 + 1] = array[4];
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix2To1To1(array[4], array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[7]);
						}
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[8]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					}
					case 80:
					case 81:
					{
						dp[num2] = Interpolation.Mix2To1To1(array[4], array[1], array[3]);
						dp[num2 + 1] = Interpolation.Mix4To2To1(array[4], array[1], array[3]);
						dp[num2 + 2] = Interpolation.Mix4To2To1(array[4], array[1], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[1]);
						dp[num2 + num3 + 1] = Interpolation.Mix6To1To1(array[4], array[3], array[1]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + num3 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						bool flag37 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag37)
						{
							dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						}
						else
						{
							dp[num2 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.MixEven(array[7], array[4]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.MixEven(array[7], array[5]);
						}
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						break;
					}
					case 82:
					case 214:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
						bool flag38 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag38)
						{
							dp[num2 + 2] = array[4];
							dp[num2 + 3] = array[4];
							dp[num2 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + 2] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + 3] = Interpolation.MixEven(array[1], array[5]);
							dp[num2 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
						}
						dp[num2 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + 2] = array[4];
						dp[num2 + num3 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 2] = array[4];
						bool flag39 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag39)
						{
							dp[num2 + num3 + num3 + 3] = array[4];
							dp[num2 + num3 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.MixEven(array[7], array[4]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.MixEven(array[7], array[5]);
						}
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						break;
					}
					case 83:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						bool flag40 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag40)
						{
							dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
							dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
							dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
							dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						}
						else
						{
							dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[1]);
							dp[num2 + 3] = Interpolation.Mix2To1To1(array[4], array[1], array[5]);
							dp[num2 + num3 + 2] = array[4];
							dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[5]);
						}
						dp[num2 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						bool flag41 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag41)
						{
							dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						}
						else
						{
							dp[num2 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[5]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[7]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix2To1To1(array[4], array[7], array[5]);
						}
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						break;
					}
					case 84:
					case 85:
					{
						dp[num2] = Interpolation.Mix2To1To1(array[4], array[1], array[3]);
						dp[num2 + 1] = Interpolation.Mix4To2To1(array[4], array[1], array[3]);
						dp[num2 + 2] = Interpolation.Mix5To3(array[4], array[1]);
						bool flag42 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag42)
						{
							dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[1]);
							dp[num2 + num3 + 3] = Interpolation.Mix7To1(array[4], array[1]);
							dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						}
						else
						{
							dp[num2 + 3] = Interpolation.Mix3To1(array[4], array[5]);
							dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[5], array[4]);
							dp[num2 + num3 + num3 + 2] = Interpolation.Mix6To1To1(array[4], array[5], array[7]);
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix5To3(array[5], array[7]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix2To1To1(array[7], array[4], array[5]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.MixEven(array[7], array[5]);
						}
						dp[num2 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[1]);
						dp[num2 + num3 + 1] = Interpolation.Mix6To1To1(array[4], array[3], array[1]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						break;
					}
					case 86:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
						bool flag43 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag43)
						{
							dp[num2 + 2] = array[4];
							dp[num2 + 3] = array[4];
							dp[num2 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + 2] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + 3] = Interpolation.MixEven(array[1], array[5]);
							dp[num2 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
						}
						dp[num2 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + 2] = array[4];
						dp[num2 + num3 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					}
					case 87:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						bool flag44 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag44)
						{
							dp[num2 + 2] = array[4];
							dp[num2 + 3] = array[4];
							dp[num2 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + 2] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + 3] = Interpolation.MixEven(array[1], array[5]);
							dp[num2 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
						}
						dp[num2 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + 2] = array[4];
						dp[num2 + num3 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						bool flag45 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag45)
						{
							dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						}
						else
						{
							dp[num2 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[5]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[7]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix2To1To1(array[4], array[7], array[5]);
						}
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						break;
					}
					case 88:
					case 248:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix4To2To1(array[4], array[1], array[0]);
						dp[num2 + 2] = Interpolation.Mix4To2To1(array[4], array[1], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						bool flag46 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag46)
						{
							dp[num2 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3 + 1] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3] = Interpolation.MixEven(array[3], array[4]);
							dp[num2 + num3 + num3 + num3] = Interpolation.MixEven(array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.MixEven(array[7], array[4]);
						}
						dp[num2 + num3 + num3 + 1] = array[4];
						dp[num2 + num3 + num3 + 2] = array[4];
						bool flag47 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag47)
						{
							dp[num2 + num3 + num3 + 3] = array[4];
							dp[num2 + num3 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.MixEven(array[7], array[4]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.MixEven(array[7], array[5]);
						}
						break;
					}
					case 89:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 1] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 2] = Interpolation.Mix4To2To1(array[4], array[1], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						bool flag48 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag48)
						{
							dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
							dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						}
						else
						{
							dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[3]);
							dp[num2 + num3 + num3 + 1] = array[4];
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix2To1To1(array[4], array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[7]);
						}
						bool flag49 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag49)
						{
							dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						}
						else
						{
							dp[num2 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[5]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[7]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix2To1To1(array[4], array[7], array[5]);
						}
						break;
					}
					case 90:
					{
						bool flag50 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag50)
						{
							dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
							dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
							dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
							dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						}
						else
						{
							dp[num2] = Interpolation.Mix2To1To1(array[4], array[1], array[3]);
							dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[1]);
							dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[3]);
							dp[num2 + num3 + 1] = array[4];
						}
						bool flag51 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag51)
						{
							dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
							dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
							dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
							dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						}
						else
						{
							dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[1]);
							dp[num2 + 3] = Interpolation.Mix2To1To1(array[4], array[1], array[5]);
							dp[num2 + num3 + 2] = array[4];
							dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[5]);
						}
						bool flag52 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag52)
						{
							dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
							dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						}
						else
						{
							dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[3]);
							dp[num2 + num3 + num3 + 1] = array[4];
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix2To1To1(array[4], array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[7]);
						}
						bool flag53 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag53)
						{
							dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						}
						else
						{
							dp[num2 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[5]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[7]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix2To1To1(array[4], array[7], array[5]);
						}
						break;
					}
					case 91:
					{
						bool flag54 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag54)
						{
							dp[num2] = array[4];
							dp[num2 + 1] = array[4];
							dp[num2 + num3] = array[4];
						}
						else
						{
							dp[num2] = Interpolation.MixEven(array[1], array[3]);
							dp[num2 + 1] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + num3] = Interpolation.MixEven(array[3], array[4]);
						}
						bool flag55 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag55)
						{
							dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
							dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
							dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
							dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						}
						else
						{
							dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[1]);
							dp[num2 + 3] = Interpolation.Mix2To1To1(array[4], array[1], array[5]);
							dp[num2 + num3 + 2] = array[4];
							dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[5]);
						}
						dp[num2 + num3 + 1] = array[4];
						bool flag56 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag56)
						{
							dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
							dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						}
						else
						{
							dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[3]);
							dp[num2 + num3 + num3 + 1] = array[4];
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix2To1To1(array[4], array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[7]);
						}
						bool flag57 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag57)
						{
							dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						}
						else
						{
							dp[num2 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[5]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[7]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix2To1To1(array[4], array[7], array[5]);
						}
						break;
					}
					case 92:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix4To2To1(array[4], array[1], array[0]);
						dp[num2 + 2] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 3] = Interpolation.Mix7To1(array[4], array[1]);
						bool flag58 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag58)
						{
							dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
							dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						}
						else
						{
							dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[3]);
							dp[num2 + num3 + num3 + 1] = array[4];
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix2To1To1(array[4], array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[7]);
						}
						bool flag59 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag59)
						{
							dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						}
						else
						{
							dp[num2 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[5]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[7]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix2To1To1(array[4], array[7], array[5]);
						}
						break;
					}
					case 93:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 1] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 2] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + num3] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 3] = Interpolation.Mix7To1(array[4], array[1]);
						bool flag60 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag60)
						{
							dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
							dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						}
						else
						{
							dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[3]);
							dp[num2 + num3 + num3 + 1] = array[4];
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix2To1To1(array[4], array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[7]);
						}
						bool flag61 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag61)
						{
							dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						}
						else
						{
							dp[num2 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[5]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[7]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix2To1To1(array[4], array[7], array[5]);
						}
						break;
					}
					case 94:
					{
						bool flag62 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag62)
						{
							dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
							dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
							dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
							dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						}
						else
						{
							dp[num2] = Interpolation.Mix2To1To1(array[4], array[1], array[3]);
							dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[1]);
							dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[3]);
							dp[num2 + num3 + 1] = array[4];
						}
						bool flag63 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag63)
						{
							dp[num2 + 2] = array[4];
							dp[num2 + 3] = array[4];
							dp[num2 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + 2] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + 3] = Interpolation.MixEven(array[1], array[5]);
							dp[num2 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
						}
						dp[num2 + num3 + 2] = array[4];
						bool flag64 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag64)
						{
							dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
							dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						}
						else
						{
							dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[3]);
							dp[num2 + num3 + num3 + 1] = array[4];
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix2To1To1(array[4], array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[7]);
						}
						bool flag65 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag65)
						{
							dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						}
						else
						{
							dp[num2 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[5]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[7]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix2To1To1(array[4], array[7], array[5]);
						}
						break;
					}
					case 95:
					{
						bool flag66 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag66)
						{
							dp[num2] = array[4];
							dp[num2 + 1] = array[4];
							dp[num2 + num3] = array[4];
						}
						else
						{
							dp[num2] = Interpolation.MixEven(array[1], array[3]);
							dp[num2 + 1] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + num3] = Interpolation.MixEven(array[3], array[4]);
						}
						bool flag67 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag67)
						{
							dp[num2 + 2] = array[4];
							dp[num2 + 3] = array[4];
							dp[num2 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + 2] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + 3] = Interpolation.MixEven(array[1], array[5]);
							dp[num2 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
						}
						dp[num2 + num3 + 1] = array[4];
						dp[num2 + num3 + 2] = array[4];
						dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					}
					case 96:
					case 97:
					case 100:
					case 101:
						Hqx_4x.case96(dp, num2, num3, array);
						break;
					case 98:
						Hqx_4x.case98(dp, num2, num3, array);
						break;
					case 99:
						dp[num2] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[2]);
						dp[num2 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[8]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					case 102:
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
						dp[num2 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[8]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					case 103:
						dp[num2] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[8]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					case 104:
					case 108:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix4To2To1(array[4], array[1], array[0]);
						dp[num2 + 2] = Interpolation.Mix4To2To1(array[4], array[1], array[5]);
						dp[num2 + 3] = Interpolation.Mix2To1To1(array[4], array[1], array[5]);
						dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + 2] = Interpolation.Mix6To1To1(array[4], array[5], array[1]);
						dp[num2 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[1]);
						bool flag68 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag68)
						{
							dp[num2 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3 + 1] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3] = Interpolation.MixEven(array[3], array[4]);
							dp[num2 + num3 + num3 + num3] = Interpolation.MixEven(array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.MixEven(array[7], array[4]);
						}
						dp[num2 + num3 + num3 + 1] = array[4];
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[8]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					}
					case 105:
					case 109:
					{
						bool flag69 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag69)
						{
							dp[num2] = Interpolation.Mix5To3(array[4], array[1]);
							dp[num2 + num3] = Interpolation.Mix7To1(array[4], array[1]);
							dp[num2 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + 1] = array[4];
							dp[num2 + num3 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3 + 1] = array[4];
						}
						else
						{
							dp[num2] = Interpolation.Mix3To1(array[4], array[3]);
							dp[num2 + num3] = Interpolation.Mix3To1(array[3], array[4]);
							dp[num2 + num3 + num3] = Interpolation.Mix5To3(array[3], array[7]);
							dp[num2 + num3 + num3 + 1] = Interpolation.Mix6To1To1(array[4], array[3], array[7]);
							dp[num2 + num3 + num3 + num3] = Interpolation.MixEven(array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix2To1To1(array[7], array[4], array[3]);
						}
						dp[num2 + 1] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 2] = Interpolation.Mix4To2To1(array[4], array[1], array[5]);
						dp[num2 + 3] = Interpolation.Mix2To1To1(array[4], array[1], array[5]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 2] = Interpolation.Mix6To1To1(array[4], array[5], array[1]);
						dp[num2 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[1]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[8]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					}
					case 106:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
						dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[2]);
						bool flag70 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag70)
						{
							dp[num2 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3 + 1] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3] = Interpolation.MixEven(array[3], array[4]);
							dp[num2 + num3 + num3 + num3] = Interpolation.MixEven(array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.MixEven(array[7], array[4]);
						}
						dp[num2 + num3 + num3 + 1] = array[4];
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[8]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					}
					case 110:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
						dp[num2 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						bool flag71 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag71)
						{
							dp[num2 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3 + 1] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3] = Interpolation.MixEven(array[3], array[4]);
							dp[num2 + num3 + num3 + num3] = Interpolation.MixEven(array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.MixEven(array[7], array[4]);
						}
						dp[num2 + num3 + num3 + 1] = array[4];
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[8]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					}
					case 111:
					{
						bool flag72 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag72)
						{
							dp[num2] = array[4];
						}
						else
						{
							dp[num2] = Interpolation.Mix2To1To1(array[4], array[1], array[3]);
						}
						dp[num2 + 1] = array[4];
						dp[num2 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3] = array[4];
						dp[num2 + num3 + 1] = array[4];
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						bool flag73 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag73)
						{
							dp[num2 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3 + 1] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3] = Interpolation.MixEven(array[3], array[4]);
							dp[num2 + num3 + num3 + num3] = Interpolation.MixEven(array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.MixEven(array[7], array[4]);
						}
						dp[num2 + num3 + num3 + 1] = array[4];
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[8]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					}
					case 112:
					case 113:
					{
						dp[num2] = Interpolation.Mix2To1To1(array[4], array[1], array[3]);
						dp[num2 + 1] = Interpolation.Mix4To2To1(array[4], array[1], array[3]);
						dp[num2 + 2] = Interpolation.Mix4To2To1(array[4], array[1], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[1]);
						dp[num2 + num3 + 1] = Interpolation.Mix6To1To1(array[4], array[3], array[1]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						bool flag74 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag74)
						{
							dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						}
						else
						{
							dp[num2 + num3 + num3 + 2] = Interpolation.Mix6To1To1(array[4], array[5], array[7]);
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix2To1To1(array[5], array[4], array[7]);
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix3To1(array[4], array[7]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[7], array[4]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix5To3(array[7], array[5]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.MixEven(array[7], array[5]);
						}
						break;
					}
					case 114:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
						bool flag75 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag75)
						{
							dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
							dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
							dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
							dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						}
						else
						{
							dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[1]);
							dp[num2 + 3] = Interpolation.Mix2To1To1(array[4], array[1], array[5]);
							dp[num2 + num3 + 2] = array[4];
							dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[5]);
						}
						dp[num2 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						bool flag76 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag76)
						{
							dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						}
						else
						{
							dp[num2 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[5]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[7]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix2To1To1(array[4], array[7], array[5]);
						}
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						break;
					}
					case 115:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						bool flag77 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag77)
						{
							dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
							dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
							dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
							dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						}
						else
						{
							dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[1]);
							dp[num2 + 3] = Interpolation.Mix2To1To1(array[4], array[1], array[5]);
							dp[num2 + num3 + 2] = array[4];
							dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[5]);
						}
						dp[num2 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						bool flag78 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag78)
						{
							dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						}
						else
						{
							dp[num2 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[5]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[7]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix2To1To1(array[4], array[7], array[5]);
						}
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						break;
					}
					case 116:
					case 117:
					{
						dp[num2] = Interpolation.Mix2To1To1(array[4], array[1], array[3]);
						dp[num2 + 1] = Interpolation.Mix4To2To1(array[4], array[1], array[3]);
						dp[num2 + 2] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[1]);
						dp[num2 + num3 + 1] = Interpolation.Mix6To1To1(array[4], array[3], array[1]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 3] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						bool flag79 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag79)
						{
							dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						}
						else
						{
							dp[num2 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[5]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[7]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix2To1To1(array[4], array[7], array[5]);
						}
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						break;
					}
					case 118:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
						bool flag80 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag80)
						{
							dp[num2 + 2] = array[4];
							dp[num2 + 3] = array[4];
							dp[num2 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + 2] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + 3] = Interpolation.MixEven(array[1], array[5]);
							dp[num2 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
						}
						dp[num2 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + 2] = array[4];
						dp[num2 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					}
					case 119:
					{
						bool flag81 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag81)
						{
							dp[num2] = Interpolation.Mix5To3(array[4], array[3]);
							dp[num2 + 1] = Interpolation.Mix7To1(array[4], array[3]);
							dp[num2 + 2] = array[4];
							dp[num2 + 3] = array[4];
							dp[num2 + num3 + 2] = array[4];
							dp[num2 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2] = Interpolation.Mix3To1(array[4], array[1]);
							dp[num2 + 1] = Interpolation.Mix3To1(array[1], array[4]);
							dp[num2 + 2] = Interpolation.Mix5To3(array[1], array[5]);
							dp[num2 + 3] = Interpolation.MixEven(array[1], array[5]);
							dp[num2 + num3 + 2] = Interpolation.Mix6To1To1(array[4], array[5], array[1]);
							dp[num2 + num3 + 3] = Interpolation.Mix2To1To1(array[5], array[4], array[1]);
						}
						dp[num2 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					}
					case 120:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix4To2To1(array[4], array[1], array[0]);
						dp[num2 + 2] = Interpolation.Mix4To2To1(array[4], array[1], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						bool flag82 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag82)
						{
							dp[num2 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3 + 1] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3] = Interpolation.MixEven(array[3], array[4]);
							dp[num2 + num3 + num3 + num3] = Interpolation.MixEven(array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.MixEven(array[7], array[4]);
						}
						dp[num2 + num3 + num3 + 1] = array[4];
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					}
					case 121:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 1] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 2] = Interpolation.Mix4To2To1(array[4], array[1], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						bool flag83 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag83)
						{
							dp[num2 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3 + 1] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3] = Interpolation.MixEven(array[3], array[4]);
							dp[num2 + num3 + num3 + num3] = Interpolation.MixEven(array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.MixEven(array[7], array[4]);
						}
						dp[num2 + num3 + num3 + 1] = array[4];
						bool flag84 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag84)
						{
							dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						}
						else
						{
							dp[num2 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[5]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[7]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix2To1To1(array[4], array[7], array[5]);
						}
						break;
					}
					case 122:
					{
						bool flag85 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag85)
						{
							dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
							dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
							dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
							dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						}
						else
						{
							dp[num2] = Interpolation.Mix2To1To1(array[4], array[1], array[3]);
							dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[1]);
							dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[3]);
							dp[num2 + num3 + 1] = array[4];
						}
						bool flag86 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag86)
						{
							dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
							dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
							dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
							dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						}
						else
						{
							dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[1]);
							dp[num2 + 3] = Interpolation.Mix2To1To1(array[4], array[1], array[5]);
							dp[num2 + num3 + 2] = array[4];
							dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[5]);
						}
						bool flag87 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag87)
						{
							dp[num2 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3 + 1] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3] = Interpolation.MixEven(array[3], array[4]);
							dp[num2 + num3 + num3 + num3] = Interpolation.MixEven(array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.MixEven(array[7], array[4]);
						}
						dp[num2 + num3 + num3 + 1] = array[4];
						bool flag88 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag88)
						{
							dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						}
						else
						{
							dp[num2 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[5]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[7]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix2To1To1(array[4], array[7], array[5]);
						}
						break;
					}
					case 123:
					{
						bool flag89 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag89)
						{
							dp[num2] = array[4];
							dp[num2 + 1] = array[4];
							dp[num2 + num3] = array[4];
						}
						else
						{
							dp[num2] = Interpolation.MixEven(array[1], array[3]);
							dp[num2 + 1] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + num3] = Interpolation.MixEven(array[3], array[4]);
						}
						dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3 + 1] = array[4];
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						bool flag90 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag90)
						{
							dp[num2 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3 + 1] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3] = Interpolation.MixEven(array[3], array[4]);
							dp[num2 + num3 + num3 + num3] = Interpolation.MixEven(array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.MixEven(array[7], array[4]);
						}
						dp[num2 + num3 + num3 + 1] = array[4];
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					}
					case 124:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix4To2To1(array[4], array[1], array[0]);
						dp[num2 + 2] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 3] = Interpolation.Mix7To1(array[4], array[1]);
						bool flag91 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag91)
						{
							dp[num2 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3 + 1] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3] = Interpolation.MixEven(array[3], array[4]);
							dp[num2 + num3 + num3 + num3] = Interpolation.MixEven(array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.MixEven(array[7], array[4]);
						}
						dp[num2 + num3 + num3 + 1] = array[4];
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					}
					case 125:
					{
						bool flag92 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag92)
						{
							dp[num2] = Interpolation.Mix5To3(array[4], array[1]);
							dp[num2 + num3] = Interpolation.Mix7To1(array[4], array[1]);
							dp[num2 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + 1] = array[4];
							dp[num2 + num3 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3 + 1] = array[4];
						}
						else
						{
							dp[num2] = Interpolation.Mix3To1(array[4], array[3]);
							dp[num2 + num3] = Interpolation.Mix3To1(array[3], array[4]);
							dp[num2 + num3 + num3] = Interpolation.Mix5To3(array[3], array[7]);
							dp[num2 + num3 + num3 + 1] = Interpolation.Mix6To1To1(array[4], array[3], array[7]);
							dp[num2 + num3 + num3 + num3] = Interpolation.MixEven(array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix2To1To1(array[7], array[4], array[3]);
						}
						dp[num2 + 1] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 2] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 3] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					}
					case 126:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
						bool flag93 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag93)
						{
							dp[num2 + 2] = array[4];
							dp[num2 + 3] = array[4];
							dp[num2 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + 2] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + 3] = Interpolation.MixEven(array[1], array[5]);
							dp[num2 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
						}
						dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + 2] = array[4];
						bool flag94 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag94)
						{
							dp[num2 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3 + 1] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3] = Interpolation.MixEven(array[3], array[4]);
							dp[num2 + num3 + num3 + num3] = Interpolation.MixEven(array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.MixEven(array[7], array[4]);
						}
						dp[num2 + num3 + num3 + 1] = array[4];
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					}
					case 127:
					{
						bool flag95 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag95)
						{
							dp[num2] = array[4];
						}
						else
						{
							dp[num2] = Interpolation.Mix2To1To1(array[4], array[1], array[3]);
						}
						dp[num2 + 1] = array[4];
						bool flag96 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag96)
						{
							dp[num2 + 2] = array[4];
							dp[num2 + 3] = array[4];
							dp[num2 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + 2] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + 3] = Interpolation.MixEven(array[1], array[5]);
							dp[num2 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
						}
						dp[num2 + num3] = array[4];
						dp[num2 + num3 + 1] = array[4];
						dp[num2 + num3 + 2] = array[4];
						bool flag97 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag97)
						{
							dp[num2 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3 + 1] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3] = Interpolation.MixEven(array[3], array[4]);
							dp[num2 + num3 + num3 + num3] = Interpolation.MixEven(array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.MixEven(array[7], array[4]);
						}
						dp[num2 + num3 + num3 + 1] = array[4];
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[8]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[4], array[8]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[8]);
						break;
					}
					case 144:
					case 145:
					case 176:
					case 177:
						Hqx_4x.case144(dp, num2, num3, array);
						break;
					case 146:
					case 178:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
						bool flag98 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag98)
						{
							dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
							dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
							dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
							dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix7To1(array[4], array[7]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[7]);
						}
						else
						{
							dp[num2 + 2] = Interpolation.Mix2To1To1(array[1], array[4], array[5]);
							dp[num2 + 3] = Interpolation.MixEven(array[1], array[5]);
							dp[num2 + num3 + 2] = Interpolation.Mix6To1To1(array[4], array[5], array[1]);
							dp[num2 + num3 + 3] = Interpolation.Mix5To3(array[5], array[1]);
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[5], array[4]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[5]);
						}
						dp[num2 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[7]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix6To1To1(array[4], array[3], array[7]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix2To1To1(array[4], array[7], array[3]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix4To2To1(array[4], array[7], array[3]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix5To3(array[4], array[7]);
						break;
					}
					case 147:
					case 179:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						bool flag99 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag99)
						{
							dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
							dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
							dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
							dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						}
						else
						{
							dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[1]);
							dp[num2 + 3] = Interpolation.Mix2To1To1(array[4], array[1], array[5]);
							dp[num2 + num3 + 2] = array[4];
							dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[5]);
						}
						dp[num2 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[7]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix6To1To1(array[4], array[3], array[7]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix2To1To1(array[4], array[7], array[3]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix4To2To1(array[4], array[7], array[3]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[7]);
						break;
					}
					case 148:
					case 149:
					case 180:
						Hqx_4x.case148(dp, num2, num3, array);
						break;
					case 150:
					case 182:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
						bool flag100 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag100)
						{
							dp[num2 + 2] = array[4];
							dp[num2 + 3] = array[4];
							dp[num2 + num3 + 2] = array[4];
							dp[num2 + num3 + 3] = array[4];
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix7To1(array[4], array[7]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[7]);
						}
						else
						{
							dp[num2 + 2] = Interpolation.Mix2To1To1(array[1], array[4], array[5]);
							dp[num2 + 3] = Interpolation.MixEven(array[1], array[5]);
							dp[num2 + num3 + 2] = Interpolation.Mix6To1To1(array[4], array[5], array[1]);
							dp[num2 + num3 + 3] = Interpolation.Mix5To3(array[5], array[1]);
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[5], array[4]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[5]);
						}
						dp[num2 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[7]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix6To1To1(array[4], array[3], array[7]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix2To1To1(array[4], array[7], array[3]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix4To2To1(array[4], array[7], array[3]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix5To3(array[4], array[7]);
						break;
					}
					case 151:
					case 183:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + 2] = array[4];
						bool flag101 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag101)
						{
							dp[num2 + 3] = array[4];
						}
						else
						{
							dp[num2 + 3] = Interpolation.Mix2To1To1(array[4], array[1], array[5]);
						}
						dp[num2 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + 2] = array[4];
						dp[num2 + num3 + 3] = array[4];
						dp[num2 + num3 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[7]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix6To1To1(array[4], array[3], array[7]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix2To1To1(array[4], array[7], array[3]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix4To2To1(array[4], array[7], array[3]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[7]);
						break;
					}
					case 152:
						Hqx_4x.case152(dp, num2, num3, array);
						break;
					case 153:
						dp[num2] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 1] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 2] = Interpolation.Mix4To2To1(array[4], array[1], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix4To2To1(array[4], array[7], array[6]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[7]);
						break;
					case 154:
					{
						bool flag102 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag102)
						{
							dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
							dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
							dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
							dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						}
						else
						{
							dp[num2] = Interpolation.Mix2To1To1(array[4], array[1], array[3]);
							dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[1]);
							dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[3]);
							dp[num2 + num3 + 1] = array[4];
						}
						bool flag103 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag103)
						{
							dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
							dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
							dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
							dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						}
						else
						{
							dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[1]);
							dp[num2 + 3] = Interpolation.Mix2To1To1(array[4], array[1], array[5]);
							dp[num2 + num3 + 2] = array[4];
							dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[5]);
						}
						dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix4To2To1(array[4], array[7], array[6]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[7]);
						break;
					}
					case 155:
					{
						bool flag104 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag104)
						{
							dp[num2] = array[4];
							dp[num2 + 1] = array[4];
							dp[num2 + num3] = array[4];
						}
						else
						{
							dp[num2] = Interpolation.MixEven(array[1], array[3]);
							dp[num2 + 1] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + num3] = Interpolation.MixEven(array[3], array[4]);
						}
						dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3 + 1] = array[4];
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix4To2To1(array[4], array[7], array[6]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[7]);
						break;
					}
					case 156:
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix4To2To1(array[4], array[1], array[0]);
						dp[num2 + 2] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 3] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix4To2To1(array[4], array[7], array[6]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[7]);
						break;
					case 157:
						dp[num2] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 1] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 2] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + num3] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 3] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix4To2To1(array[4], array[7], array[6]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[7]);
						break;
					case 158:
					{
						bool flag105 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag105)
						{
							dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
							dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
							dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
							dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						}
						else
						{
							dp[num2] = Interpolation.Mix2To1To1(array[4], array[1], array[3]);
							dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[1]);
							dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[3]);
							dp[num2 + num3 + 1] = array[4];
						}
						bool flag106 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag106)
						{
							dp[num2 + 2] = array[4];
							dp[num2 + 3] = array[4];
							dp[num2 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + 2] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + 3] = Interpolation.MixEven(array[1], array[5]);
							dp[num2 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
						}
						dp[num2 + num3 + 2] = array[4];
						dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix4To2To1(array[4], array[7], array[6]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[7]);
						break;
					}
					case 159:
					{
						bool flag107 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag107)
						{
							dp[num2] = array[4];
							dp[num2 + 1] = array[4];
							dp[num2 + num3] = array[4];
						}
						else
						{
							dp[num2] = Interpolation.MixEven(array[1], array[3]);
							dp[num2 + 1] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + num3] = Interpolation.MixEven(array[3], array[4]);
						}
						dp[num2 + 2] = array[4];
						bool flag108 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag108)
						{
							dp[num2 + 3] = array[4];
						}
						else
						{
							dp[num2 + 3] = Interpolation.Mix2To1To1(array[4], array[1], array[5]);
						}
						dp[num2 + num3 + 1] = array[4];
						dp[num2 + num3 + 2] = array[4];
						dp[num2 + num3 + 3] = array[4];
						dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix4To2To1(array[4], array[7], array[6]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[7]);
						break;
					}
					case 167:
						dp[num2] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[7]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix6To1To1(array[4], array[3], array[7]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix6To1To1(array[4], array[5], array[7]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[7]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix2To1To1(array[4], array[7], array[3]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix4To2To1(array[4], array[7], array[3]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix4To2To1(array[4], array[7], array[5]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix2To1To1(array[4], array[7], array[5]);
						break;
					case 173:
						dp[num2] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 1] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 2] = Interpolation.Mix4To2To1(array[4], array[1], array[5]);
						dp[num2 + 3] = Interpolation.Mix2To1To1(array[4], array[1], array[5]);
						dp[num2 + num3] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 2] = Interpolation.Mix6To1To1(array[4], array[5], array[1]);
						dp[num2 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[1]);
						dp[num2 + num3 + num3] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix6To1To1(array[4], array[5], array[7]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[7]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix4To2To1(array[4], array[7], array[5]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix2To1To1(array[4], array[7], array[5]);
						break;
					case 181:
						dp[num2] = Interpolation.Mix2To1To1(array[4], array[1], array[3]);
						dp[num2 + 1] = Interpolation.Mix4To2To1(array[4], array[1], array[3]);
						dp[num2 + 2] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[1]);
						dp[num2 + num3 + 1] = Interpolation.Mix6To1To1(array[4], array[3], array[1]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 3] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[7]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix6To1To1(array[4], array[3], array[7]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix2To1To1(array[4], array[7], array[3]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix4To2To1(array[4], array[7], array[3]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[7]);
						break;
					case 184:
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix4To2To1(array[4], array[1], array[0]);
						dp[num2 + 2] = Interpolation.Mix4To2To1(array[4], array[1], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + num3 + num3] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[7]);
						break;
					case 185:
						dp[num2] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 1] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 2] = Interpolation.Mix4To2To1(array[4], array[1], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + num3 + num3] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[7]);
						break;
					case 186:
					{
						bool flag109 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag109)
						{
							dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
							dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
							dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
							dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						}
						else
						{
							dp[num2] = Interpolation.Mix2To1To1(array[4], array[1], array[3]);
							dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[1]);
							dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[3]);
							dp[num2 + num3 + 1] = array[4];
						}
						bool flag110 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag110)
						{
							dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
							dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
							dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
							dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						}
						else
						{
							dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[1]);
							dp[num2 + 3] = Interpolation.Mix2To1To1(array[4], array[1], array[5]);
							dp[num2 + num3 + 2] = array[4];
							dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[5]);
						}
						dp[num2 + num3 + num3] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[7]);
						break;
					}
					case 187:
					{
						bool flag111 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag111)
						{
							dp[num2] = array[4];
							dp[num2 + 1] = array[4];
							dp[num2 + num3] = array[4];
							dp[num2 + num3 + 1] = array[4];
							dp[num2 + num3 + num3] = Interpolation.Mix7To1(array[4], array[7]);
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[7]);
						}
						else
						{
							dp[num2] = Interpolation.MixEven(array[1], array[3]);
							dp[num2 + 1] = Interpolation.Mix2To1To1(array[1], array[4], array[3]);
							dp[num2 + num3] = Interpolation.Mix5To3(array[3], array[1]);
							dp[num2 + num3 + 1] = Interpolation.Mix6To1To1(array[4], array[3], array[1]);
							dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[3], array[4]);
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix3To1(array[4], array[3]);
						}
						dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[7]);
						break;
					}
					case 188:
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix4To2To1(array[4], array[1], array[0]);
						dp[num2 + 2] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 3] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + num3] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[7]);
						break;
					case 189:
						dp[num2] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 1] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 2] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + num3] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 3] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + num3] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[7]);
						break;
					case 190:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
						bool flag112 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag112)
						{
							dp[num2 + 2] = array[4];
							dp[num2 + 3] = array[4];
							dp[num2 + num3 + 2] = array[4];
							dp[num2 + num3 + 3] = array[4];
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix7To1(array[4], array[7]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[7]);
						}
						else
						{
							dp[num2 + 2] = Interpolation.Mix2To1To1(array[1], array[4], array[5]);
							dp[num2 + 3] = Interpolation.MixEven(array[1], array[5]);
							dp[num2 + num3 + 2] = Interpolation.Mix6To1To1(array[4], array[5], array[1]);
							dp[num2 + num3 + 3] = Interpolation.Mix5To3(array[5], array[1]);
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix3To1(array[5], array[4]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[5]);
						}
						dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + num3] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix5To3(array[4], array[7]);
						break;
					}
					case 191:
					{
						bool flag113 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag113)
						{
							dp[num2] = array[4];
						}
						else
						{
							dp[num2] = Interpolation.Mix2To1To1(array[4], array[1], array[3]);
						}
						dp[num2 + 1] = array[4];
						dp[num2 + 2] = array[4];
						bool flag114 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag114)
						{
							dp[num2 + 3] = array[4];
						}
						else
						{
							dp[num2 + 3] = Interpolation.Mix2To1To1(array[4], array[1], array[5]);
						}
						dp[num2 + num3] = array[4];
						dp[num2 + num3 + 1] = array[4];
						dp[num2 + num3 + 2] = array[4];
						dp[num2 + num3 + 3] = array[4];
						dp[num2 + num3 + num3] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix7To1(array[4], array[7]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix5To3(array[4], array[7]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[7]);
						break;
					}
					case 192:
					case 193:
					case 196:
					case 197:
						Hqx_4x.case192(dp, num2, num3, array);
						break;
					case 194:
						Hqx_4x.case194(dp, num2, num3, array);
						break;
					case 195:
						dp[num2] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[2]);
						dp[num2 + num3 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						break;
					case 198:
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
						dp[num2 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						break;
					case 199:
						dp[num2] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						break;
					case 200:
					case 204:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix4To2To1(array[4], array[1], array[0]);
						dp[num2 + 2] = Interpolation.Mix4To2To1(array[4], array[1], array[5]);
						dp[num2 + 3] = Interpolation.Mix2To1To1(array[4], array[1], array[5]);
						dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + 2] = Interpolation.Mix6To1To1(array[4], array[5], array[1]);
						dp[num2 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[1]);
						bool flag115 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag115)
						{
							dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
							dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						}
						else
						{
							dp[num2 + num3 + num3] = Interpolation.Mix2To1To1(array[3], array[4], array[7]);
							dp[num2 + num3 + num3 + 1] = Interpolation.Mix6To1To1(array[4], array[3], array[7]);
							dp[num2 + num3 + num3 + num3] = Interpolation.MixEven(array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix5To3(array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[7], array[4]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[7]);
						}
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						break;
					}
					case 201:
					case 205:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 1] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 2] = Interpolation.Mix4To2To1(array[4], array[1], array[5]);
						dp[num2 + 3] = Interpolation.Mix2To1To1(array[4], array[1], array[5]);
						dp[num2 + num3] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 2] = Interpolation.Mix6To1To1(array[4], array[5], array[1]);
						dp[num2 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[1]);
						bool flag116 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag116)
						{
							dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
							dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						}
						else
						{
							dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[3]);
							dp[num2 + num3 + num3 + 1] = array[4];
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix2To1To1(array[4], array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[7]);
						}
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						break;
					}
					case 202:
					{
						bool flag117 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag117)
						{
							dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
							dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
							dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
							dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						}
						else
						{
							dp[num2] = Interpolation.Mix2To1To1(array[4], array[1], array[3]);
							dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[1]);
							dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[3]);
							dp[num2 + num3 + 1] = array[4];
						}
						dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[2]);
						bool flag118 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag118)
						{
							dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
							dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						}
						else
						{
							dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[3]);
							dp[num2 + num3 + num3 + 1] = array[4];
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix2To1To1(array[4], array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[7]);
						}
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						break;
					}
					case 203:
					{
						bool flag119 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag119)
						{
							dp[num2] = array[4];
							dp[num2 + 1] = array[4];
							dp[num2 + num3] = array[4];
						}
						else
						{
							dp[num2] = Interpolation.MixEven(array[1], array[3]);
							dp[num2 + 1] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + num3] = Interpolation.MixEven(array[3], array[4]);
						}
						dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3 + 1] = array[4];
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[2]);
						dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						break;
					}
					case 206:
					{
						bool flag120 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag120)
						{
							dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
							dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
							dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
							dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						}
						else
						{
							dp[num2] = Interpolation.Mix2To1To1(array[4], array[1], array[3]);
							dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[1]);
							dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[3]);
							dp[num2 + num3 + 1] = array[4];
						}
						dp[num2 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						bool flag121 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag121)
						{
							dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
							dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						}
						else
						{
							dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[3]);
							dp[num2 + num3 + num3 + 1] = array[4];
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix2To1To1(array[4], array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[7]);
						}
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						break;
					}
					case 207:
					{
						bool flag122 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag122)
						{
							dp[num2] = array[4];
							dp[num2 + 1] = array[4];
							dp[num2 + 2] = Interpolation.Mix7To1(array[4], array[5]);
							dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[5]);
							dp[num2 + num3] = array[4];
							dp[num2 + num3 + 1] = array[4];
						}
						else
						{
							dp[num2] = Interpolation.MixEven(array[1], array[3]);
							dp[num2 + 1] = Interpolation.Mix5To3(array[1], array[3]);
							dp[num2 + 2] = Interpolation.Mix3To1(array[1], array[4]);
							dp[num2 + 3] = Interpolation.Mix3To1(array[4], array[1]);
							dp[num2 + num3] = Interpolation.Mix2To1To1(array[3], array[4], array[1]);
							dp[num2 + num3 + 1] = Interpolation.Mix6To1To1(array[4], array[3], array[1]);
						}
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						break;
					}
					case 208:
					case 209:
					{
						dp[num2] = Interpolation.Mix2To1To1(array[4], array[1], array[3]);
						dp[num2 + 1] = Interpolation.Mix4To2To1(array[4], array[1], array[3]);
						dp[num2 + 2] = Interpolation.Mix4To2To1(array[4], array[1], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[1]);
						dp[num2 + num3 + 1] = Interpolation.Mix6To1To1(array[4], array[3], array[1]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + num3 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 2] = array[4];
						bool flag123 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag123)
						{
							dp[num2 + num3 + num3 + 3] = array[4];
							dp[num2 + num3 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.MixEven(array[7], array[4]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.MixEven(array[7], array[5]);
						}
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						break;
					}
					case 210:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
						dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + num3 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 2] = array[4];
						bool flag124 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag124)
						{
							dp[num2 + num3 + num3 + 3] = array[4];
							dp[num2 + num3 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.MixEven(array[7], array[4]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.MixEven(array[7], array[5]);
						}
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						break;
					}
					case 211:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + num3 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 2] = array[4];
						bool flag125 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag125)
						{
							dp[num2 + num3 + num3 + 3] = array[4];
							dp[num2 + num3 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.MixEven(array[7], array[4]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.MixEven(array[7], array[5]);
						}
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						break;
					}
					case 212:
					case 213:
					{
						dp[num2] = Interpolation.Mix2To1To1(array[4], array[1], array[3]);
						dp[num2 + 1] = Interpolation.Mix4To2To1(array[4], array[1], array[3]);
						dp[num2 + 2] = Interpolation.Mix5To3(array[4], array[1]);
						bool flag126 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag126)
						{
							dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[1]);
							dp[num2 + num3 + 3] = Interpolation.Mix7To1(array[4], array[1]);
							dp[num2 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + 3] = array[4];
							dp[num2 + num3 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + 3] = Interpolation.Mix3To1(array[4], array[5]);
							dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[5], array[4]);
							dp[num2 + num3 + num3 + 2] = Interpolation.Mix6To1To1(array[4], array[5], array[7]);
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix5To3(array[5], array[7]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix2To1To1(array[7], array[4], array[5]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.MixEven(array[7], array[5]);
						}
						dp[num2 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[1]);
						dp[num2 + num3 + 1] = Interpolation.Mix6To1To1(array[4], array[3], array[1]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						break;
					}
					case 215:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + 2] = array[4];
						bool flag127 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag127)
						{
							dp[num2 + 3] = array[4];
						}
						else
						{
							dp[num2 + 3] = Interpolation.Mix2To1To1(array[4], array[1], array[5]);
						}
						dp[num2 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + 2] = array[4];
						dp[num2 + num3 + 3] = array[4];
						dp[num2 + num3 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 2] = array[4];
						bool flag128 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag128)
						{
							dp[num2 + num3 + num3 + 3] = array[4];
							dp[num2 + num3 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.MixEven(array[7], array[4]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.MixEven(array[7], array[5]);
						}
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						break;
					}
					case 216:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix4To2To1(array[4], array[1], array[0]);
						dp[num2 + 2] = Interpolation.Mix4To2To1(array[4], array[1], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 2] = array[4];
						bool flag129 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag129)
						{
							dp[num2 + num3 + num3 + 3] = array[4];
							dp[num2 + num3 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.MixEven(array[7], array[4]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.MixEven(array[7], array[5]);
						}
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						break;
					}
					case 217:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 1] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 2] = Interpolation.Mix4To2To1(array[4], array[1], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 2] = array[4];
						bool flag130 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag130)
						{
							dp[num2 + num3 + num3 + 3] = array[4];
							dp[num2 + num3 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.MixEven(array[7], array[4]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.MixEven(array[7], array[5]);
						}
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						break;
					}
					case 218:
					{
						bool flag131 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag131)
						{
							dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
							dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
							dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
							dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						}
						else
						{
							dp[num2] = Interpolation.Mix2To1To1(array[4], array[1], array[3]);
							dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[1]);
							dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[3]);
							dp[num2 + num3 + 1] = array[4];
						}
						bool flag132 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag132)
						{
							dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
							dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
							dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
							dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						}
						else
						{
							dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[1]);
							dp[num2 + 3] = Interpolation.Mix2To1To1(array[4], array[1], array[5]);
							dp[num2 + num3 + 2] = array[4];
							dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[5]);
						}
						bool flag133 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag133)
						{
							dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
							dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						}
						else
						{
							dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[3]);
							dp[num2 + num3 + num3 + 1] = array[4];
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix2To1To1(array[4], array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[7]);
						}
						dp[num2 + num3 + num3 + 2] = array[4];
						bool flag134 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag134)
						{
							dp[num2 + num3 + num3 + 3] = array[4];
							dp[num2 + num3 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.MixEven(array[7], array[4]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.MixEven(array[7], array[5]);
						}
						break;
					}
					case 219:
					{
						bool flag135 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag135)
						{
							dp[num2] = array[4];
							dp[num2 + 1] = array[4];
							dp[num2 + num3] = array[4];
						}
						else
						{
							dp[num2] = Interpolation.MixEven(array[1], array[3]);
							dp[num2 + 1] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + num3] = Interpolation.MixEven(array[3], array[4]);
						}
						dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3 + 1] = array[4];
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 2] = array[4];
						bool flag136 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag136)
						{
							dp[num2 + num3 + num3 + 3] = array[4];
							dp[num2 + num3 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.MixEven(array[7], array[4]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.MixEven(array[7], array[5]);
						}
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						break;
					}
					case 220:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix4To2To1(array[4], array[1], array[0]);
						dp[num2 + 2] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 3] = Interpolation.Mix7To1(array[4], array[1]);
						bool flag137 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag137)
						{
							dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
							dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						}
						else
						{
							dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[3]);
							dp[num2 + num3 + num3 + 1] = array[4];
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix2To1To1(array[4], array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[7]);
						}
						dp[num2 + num3 + num3 + 2] = array[4];
						bool flag138 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag138)
						{
							dp[num2 + num3 + num3 + 3] = array[4];
							dp[num2 + num3 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.MixEven(array[7], array[4]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.MixEven(array[7], array[5]);
						}
						break;
					}
					case 221:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 1] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 2] = Interpolation.Mix5To3(array[4], array[1]);
						bool flag139 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag139)
						{
							dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[1]);
							dp[num2 + num3 + 3] = Interpolation.Mix7To1(array[4], array[1]);
							dp[num2 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + 3] = array[4];
							dp[num2 + num3 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + 3] = Interpolation.Mix3To1(array[4], array[5]);
							dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[5], array[4]);
							dp[num2 + num3 + num3 + 2] = Interpolation.Mix6To1To1(array[4], array[5], array[7]);
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix5To3(array[5], array[7]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix2To1To1(array[7], array[4], array[5]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.MixEven(array[7], array[5]);
						}
						dp[num2 + num3] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						break;
					}
					case 222:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
						bool flag140 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag140)
						{
							dp[num2 + 2] = array[4];
							dp[num2 + 3] = array[4];
							dp[num2 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + 2] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + 3] = Interpolation.MixEven(array[1], array[5]);
							dp[num2 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
						}
						dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + 2] = array[4];
						dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 2] = array[4];
						bool flag141 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag141)
						{
							dp[num2 + num3 + num3 + 3] = array[4];
							dp[num2 + num3 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.MixEven(array[7], array[4]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.MixEven(array[7], array[5]);
						}
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						break;
					}
					case 223:
					{
						bool flag142 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag142)
						{
							dp[num2] = array[4];
							dp[num2 + 1] = array[4];
							dp[num2 + num3] = array[4];
						}
						else
						{
							dp[num2] = Interpolation.MixEven(array[1], array[3]);
							dp[num2 + 1] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + num3] = Interpolation.MixEven(array[3], array[4]);
						}
						dp[num2 + 2] = array[4];
						bool flag143 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag143)
						{
							dp[num2 + 3] = array[4];
						}
						else
						{
							dp[num2 + 3] = Interpolation.Mix2To1To1(array[4], array[1], array[5]);
						}
						dp[num2 + num3 + 1] = array[4];
						dp[num2 + num3 + 2] = array[4];
						dp[num2 + num3 + 3] = array[4];
						dp[num2 + num3 + num3] = Interpolation.Mix3To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[6]);
						dp[num2 + num3 + num3 + 2] = array[4];
						bool flag144 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag144)
						{
							dp[num2 + num3 + num3 + 3] = array[4];
							dp[num2 + num3 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.MixEven(array[7], array[4]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.MixEven(array[7], array[5]);
						}
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[6]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[4], array[6]);
						break;
					}
					case 224:
					case 225:
					case 228:
						Hqx_4x.case224(dp, num2, num3, array);
						break;
					case 226:
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
						dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[2]);
						dp[num2 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						break;
					case 227:
						dp[num2] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[2]);
						dp[num2 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						break;
					case 229:
						dp[num2] = Interpolation.Mix2To1To1(array[4], array[1], array[3]);
						dp[num2 + 1] = Interpolation.Mix4To2To1(array[4], array[1], array[3]);
						dp[num2 + 2] = Interpolation.Mix4To2To1(array[4], array[1], array[5]);
						dp[num2 + 3] = Interpolation.Mix2To1To1(array[4], array[1], array[5]);
						dp[num2 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[1]);
						dp[num2 + num3 + 1] = Interpolation.Mix6To1To1(array[4], array[3], array[1]);
						dp[num2 + num3 + 2] = Interpolation.Mix6To1To1(array[4], array[5], array[1]);
						dp[num2 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[1]);
						dp[num2 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						break;
					case 230:
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
						dp[num2 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						break;
					case 231:
						dp[num2] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						break;
					case 232:
					case 236:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix4To2To1(array[4], array[1], array[0]);
						dp[num2 + 2] = Interpolation.Mix4To2To1(array[4], array[1], array[5]);
						dp[num2 + 3] = Interpolation.Mix2To1To1(array[4], array[1], array[5]);
						dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + 2] = Interpolation.Mix6To1To1(array[4], array[5], array[1]);
						dp[num2 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[1]);
						bool flag145 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag145)
						{
							dp[num2 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + 1] = array[4];
							dp[num2 + num3 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3 + 1] = array[4];
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						}
						else
						{
							dp[num2 + num3 + num3] = Interpolation.Mix2To1To1(array[3], array[4], array[7]);
							dp[num2 + num3 + num3 + 1] = Interpolation.Mix6To1To1(array[4], array[3], array[7]);
							dp[num2 + num3 + num3 + num3] = Interpolation.MixEven(array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix5To3(array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[7], array[4]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[7]);
						}
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						break;
					}
					case 233:
					case 237:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 1] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 2] = Interpolation.Mix4To2To1(array[4], array[1], array[5]);
						dp[num2 + 3] = Interpolation.Mix2To1To1(array[4], array[1], array[5]);
						dp[num2 + num3] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 2] = Interpolation.Mix6To1To1(array[4], array[5], array[1]);
						dp[num2 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[1]);
						dp[num2 + num3 + num3] = array[4];
						dp[num2 + num3 + num3 + 1] = array[4];
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						bool flag146 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag146)
						{
							dp[num2 + num3 + num3 + num3] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix2To1To1(array[4], array[7], array[3]);
						}
						dp[num2 + num3 + num3 + num3 + 1] = array[4];
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						break;
					}
					case 234:
					{
						bool flag147 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag147)
						{
							dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
							dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
							dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
							dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						}
						else
						{
							dp[num2] = Interpolation.Mix2To1To1(array[4], array[1], array[3]);
							dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[1]);
							dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[3]);
							dp[num2 + num3 + 1] = array[4];
						}
						dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[2]);
						bool flag148 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag148)
						{
							dp[num2 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3 + 1] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3] = Interpolation.MixEven(array[3], array[4]);
							dp[num2 + num3 + num3 + num3] = Interpolation.MixEven(array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.MixEven(array[7], array[4]);
						}
						dp[num2 + num3 + num3 + 1] = array[4];
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						break;
					}
					case 235:
					{
						bool flag149 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag149)
						{
							dp[num2] = array[4];
							dp[num2 + 1] = array[4];
							dp[num2 + num3] = array[4];
						}
						else
						{
							dp[num2] = Interpolation.MixEven(array[1], array[3]);
							dp[num2 + 1] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + num3] = Interpolation.MixEven(array[3], array[4]);
						}
						dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3 + 1] = array[4];
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix4To2To1(array[4], array[5], array[2]);
						dp[num2 + num3 + num3] = array[4];
						dp[num2 + num3 + num3 + 1] = array[4];
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						bool flag150 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag150)
						{
							dp[num2 + num3 + num3 + num3] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix2To1To1(array[4], array[7], array[3]);
						}
						dp[num2 + num3 + num3 + num3 + 1] = array[4];
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						break;
					}
					case 238:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
						dp[num2 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						bool flag151 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag151)
						{
							dp[num2 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + 1] = array[4];
							dp[num2 + num3 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3 + 1] = array[4];
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						}
						else
						{
							dp[num2 + num3 + num3] = Interpolation.Mix2To1To1(array[3], array[4], array[7]);
							dp[num2 + num3 + num3 + 1] = Interpolation.Mix6To1To1(array[4], array[3], array[7]);
							dp[num2 + num3 + num3 + num3] = Interpolation.MixEven(array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix5To3(array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix3To1(array[7], array[4]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix3To1(array[4], array[7]);
						}
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						break;
					}
					case 239:
					{
						bool flag152 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag152)
						{
							dp[num2] = array[4];
						}
						else
						{
							dp[num2] = Interpolation.Mix2To1To1(array[4], array[1], array[3]);
						}
						dp[num2 + 1] = array[4];
						dp[num2 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3] = array[4];
						dp[num2 + num3 + 1] = array[4];
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						dp[num2 + num3 + num3] = array[4];
						dp[num2 + num3 + num3 + 1] = array[4];
						dp[num2 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						bool flag153 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag153)
						{
							dp[num2 + num3 + num3 + num3] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix2To1To1(array[4], array[7], array[3]);
						}
						dp[num2 + num3 + num3 + num3 + 1] = array[4];
						dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix7To1(array[4], array[5]);
						dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix5To3(array[4], array[5]);
						break;
					}
					case 240:
					case 241:
					{
						dp[num2] = Interpolation.Mix2To1To1(array[4], array[1], array[3]);
						dp[num2 + 1] = Interpolation.Mix4To2To1(array[4], array[1], array[3]);
						dp[num2 + 2] = Interpolation.Mix4To2To1(array[4], array[1], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[1]);
						dp[num2 + num3 + 1] = Interpolation.Mix6To1To1(array[4], array[3], array[1]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						bool flag154 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag154)
						{
							dp[num2 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + 3] = array[4];
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
							dp[num2 + num3 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3 + 2] = Interpolation.Mix6To1To1(array[4], array[5], array[7]);
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix2To1To1(array[5], array[4], array[7]);
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix3To1(array[4], array[7]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[7], array[4]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix5To3(array[7], array[5]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.MixEven(array[7], array[5]);
						}
						break;
					}
					case 242:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
						bool flag155 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag155)
						{
							dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
							dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
							dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
							dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						}
						else
						{
							dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[1]);
							dp[num2 + 3] = Interpolation.Mix2To1To1(array[4], array[1], array[5]);
							dp[num2 + num3 + 2] = array[4];
							dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[5]);
						}
						dp[num2 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + num3 + 2] = array[4];
						bool flag156 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag156)
						{
							dp[num2 + num3 + num3 + 3] = array[4];
							dp[num2 + num3 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.MixEven(array[7], array[4]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.MixEven(array[7], array[5]);
						}
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						break;
					}
					case 243:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						bool flag157 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag157)
						{
							dp[num2 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + 3] = array[4];
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
							dp[num2 + num3 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3 + 2] = Interpolation.Mix6To1To1(array[4], array[5], array[7]);
							dp[num2 + num3 + num3 + 3] = Interpolation.Mix2To1To1(array[5], array[4], array[7]);
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix3To1(array[4], array[7]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix3To1(array[7], array[4]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.Mix5To3(array[7], array[5]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.MixEven(array[7], array[5]);
						}
						break;
					}
					case 244:
					case 245:
					{
						dp[num2] = Interpolation.Mix2To1To1(array[4], array[1], array[3]);
						dp[num2 + 1] = Interpolation.Mix4To2To1(array[4], array[1], array[3]);
						dp[num2 + 2] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[1]);
						dp[num2 + num3 + 1] = Interpolation.Mix6To1To1(array[4], array[3], array[1]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 3] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + num3 + 2] = array[4];
						dp[num2 + num3 + num3 + 3] = array[4];
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + num3 + num3 + 2] = array[4];
						bool flag158 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag158)
						{
							dp[num2 + num3 + num3 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix2To1To1(array[4], array[7], array[5]);
						}
						break;
					}
					case 246:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
						bool flag159 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag159)
						{
							dp[num2 + 2] = array[4];
							dp[num2 + 3] = array[4];
							dp[num2 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + 2] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + 3] = Interpolation.MixEven(array[1], array[5]);
							dp[num2 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
						}
						dp[num2 + num3] = Interpolation.Mix4To2To1(array[4], array[3], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + 2] = array[4];
						dp[num2 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + num3 + 2] = array[4];
						dp[num2 + num3 + num3 + 3] = array[4];
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + num3 + num3 + 2] = array[4];
						bool flag160 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag160)
						{
							dp[num2 + num3 + num3 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix2To1To1(array[4], array[7], array[5]);
						}
						break;
					}
					case 247:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + 2] = array[4];
						bool flag161 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag161)
						{
							dp[num2 + 3] = array[4];
						}
						else
						{
							dp[num2 + 3] = Interpolation.Mix2To1To1(array[4], array[1], array[5]);
						}
						dp[num2 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + 2] = array[4];
						dp[num2 + num3 + 3] = array[4];
						dp[num2 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + num3 + 2] = array[4];
						dp[num2 + num3 + num3 + 3] = array[4];
						dp[num2 + num3 + num3 + num3] = Interpolation.Mix5To3(array[4], array[3]);
						dp[num2 + num3 + num3 + num3 + 1] = Interpolation.Mix7To1(array[4], array[3]);
						dp[num2 + num3 + num3 + num3 + 2] = array[4];
						bool flag162 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag162)
						{
							dp[num2 + num3 + num3 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix2To1To1(array[4], array[7], array[5]);
						}
						break;
					}
					case 249:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 1] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 2] = Interpolation.Mix4To2To1(array[4], array[1], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + num3 + num3] = array[4];
						dp[num2 + num3 + num3 + 1] = array[4];
						dp[num2 + num3 + num3 + 2] = array[4];
						bool flag163 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag163)
						{
							dp[num2 + num3 + num3 + 3] = array[4];
							dp[num2 + num3 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.MixEven(array[7], array[4]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.MixEven(array[7], array[5]);
						}
						bool flag164 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag164)
						{
							dp[num2 + num3 + num3 + num3] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix2To1To1(array[4], array[7], array[3]);
						}
						dp[num2 + num3 + num3 + num3 + 1] = array[4];
						break;
					}
					case 250:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
						dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						bool flag165 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag165)
						{
							dp[num2 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3 + 1] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3] = Interpolation.MixEven(array[3], array[4]);
							dp[num2 + num3 + num3 + num3] = Interpolation.MixEven(array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.MixEven(array[7], array[4]);
						}
						dp[num2 + num3 + num3 + 1] = array[4];
						dp[num2 + num3 + num3 + 2] = array[4];
						bool flag166 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag166)
						{
							dp[num2 + num3 + num3 + 3] = array[4];
							dp[num2 + num3 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.MixEven(array[7], array[4]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.MixEven(array[7], array[5]);
						}
						break;
					}
					case 251:
					{
						bool flag167 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag167)
						{
							dp[num2] = array[4];
							dp[num2 + 1] = array[4];
							dp[num2 + num3] = array[4];
						}
						else
						{
							dp[num2] = Interpolation.MixEven(array[1], array[3]);
							dp[num2 + 1] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + num3] = Interpolation.MixEven(array[3], array[4]);
						}
						dp[num2 + 2] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[2]);
						dp[num2 + num3 + 1] = array[4];
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[2]);
						dp[num2 + num3 + 3] = Interpolation.Mix3To1(array[4], array[2]);
						dp[num2 + num3 + num3] = array[4];
						dp[num2 + num3 + num3 + 1] = array[4];
						dp[num2 + num3 + num3 + 2] = array[4];
						bool flag168 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag168)
						{
							dp[num2 + num3 + num3 + 3] = array[4];
							dp[num2 + num3 + num3 + num3 + 2] = array[4];
							dp[num2 + num3 + num3 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
							dp[num2 + num3 + num3 + num3 + 2] = Interpolation.MixEven(array[7], array[4]);
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.MixEven(array[7], array[5]);
						}
						bool flag169 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag169)
						{
							dp[num2 + num3 + num3 + num3] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix2To1To1(array[4], array[7], array[3]);
						}
						dp[num2 + num3 + num3 + num3 + 1] = array[4];
						break;
					}
					case 252:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix4To2To1(array[4], array[1], array[0]);
						dp[num2 + 2] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 3] = Interpolation.Mix7To1(array[4], array[1]);
						bool flag170 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag170)
						{
							dp[num2 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3 + 1] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3] = Interpolation.MixEven(array[3], array[4]);
							dp[num2 + num3 + num3 + num3] = Interpolation.MixEven(array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.MixEven(array[7], array[4]);
						}
						dp[num2 + num3 + num3 + 1] = array[4];
						dp[num2 + num3 + num3 + 2] = array[4];
						dp[num2 + num3 + num3 + 3] = array[4];
						dp[num2 + num3 + num3 + num3 + 2] = array[4];
						bool flag171 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag171)
						{
							dp[num2 + num3 + num3 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix2To1To1(array[4], array[7], array[5]);
						}
						break;
					}
					case 253:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 1] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 2] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + 3] = Interpolation.Mix5To3(array[4], array[1]);
						dp[num2 + num3] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 2] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + 3] = Interpolation.Mix7To1(array[4], array[1]);
						dp[num2 + num3 + num3] = array[4];
						dp[num2 + num3 + num3 + 1] = array[4];
						dp[num2 + num3 + num3 + 2] = array[4];
						dp[num2 + num3 + num3 + 3] = array[4];
						bool flag172 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag172)
						{
							dp[num2 + num3 + num3 + num3] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix2To1To1(array[4], array[7], array[3]);
						}
						dp[num2 + num3 + num3 + num3 + 1] = array[4];
						dp[num2 + num3 + num3 + num3 + 2] = array[4];
						bool flag173 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag173)
						{
							dp[num2 + num3 + num3 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix2To1To1(array[4], array[7], array[5]);
						}
						break;
					}
					case 254:
					{
						dp[num2] = Interpolation.Mix5To3(array[4], array[0]);
						dp[num2 + 1] = Interpolation.Mix3To1(array[4], array[0]);
						bool flag174 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag174)
						{
							dp[num2 + 2] = array[4];
							dp[num2 + 3] = array[4];
							dp[num2 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + 2] = Interpolation.MixEven(array[1], array[4]);
							dp[num2 + 3] = Interpolation.MixEven(array[1], array[5]);
							dp[num2 + num3 + 3] = Interpolation.MixEven(array[5], array[4]);
						}
						dp[num2 + num3] = Interpolation.Mix3To1(array[4], array[0]);
						dp[num2 + num3 + 1] = Interpolation.Mix7To1(array[4], array[0]);
						dp[num2 + num3 + 2] = array[4];
						bool flag175 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag175)
						{
							dp[num2 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3] = array[4];
							dp[num2 + num3 + num3 + num3 + 1] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3] = Interpolation.MixEven(array[3], array[4]);
							dp[num2 + num3 + num3 + num3] = Interpolation.MixEven(array[7], array[3]);
							dp[num2 + num3 + num3 + num3 + 1] = Interpolation.MixEven(array[7], array[4]);
						}
						dp[num2 + num3 + num3 + 1] = array[4];
						dp[num2 + num3 + num3 + 2] = array[4];
						dp[num2 + num3 + num3 + 3] = array[4];
						dp[num2 + num3 + num3 + num3 + 2] = array[4];
						bool flag176 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag176)
						{
							dp[num2 + num3 + num3 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix2To1To1(array[4], array[7], array[5]);
						}
						break;
					}
					case 255:
					{
						bool flag177 = Hqx.diff(array[3], array[1], trY, trU, trV, trA);
						if (flag177)
						{
							dp[num2] = array[4];
						}
						else
						{
							dp[num2] = Interpolation.Mix2To1To1(array[4], array[1], array[3]);
						}
						dp[num2 + 1] = array[4];
						dp[num2 + 2] = array[4];
						bool flag178 = Hqx.diff(array[1], array[5], trY, trU, trV, trA);
						if (flag178)
						{
							dp[num2 + 3] = array[4];
						}
						else
						{
							dp[num2 + 3] = Interpolation.Mix2To1To1(array[4], array[1], array[5]);
						}
						dp[num2 + num3] = array[4];
						dp[num2 + num3 + 1] = array[4];
						dp[num2 + num3 + 2] = array[4];
						dp[num2 + num3 + 3] = array[4];
						dp[num2 + num3 + num3] = array[4];
						dp[num2 + num3 + num3 + 1] = array[4];
						dp[num2 + num3 + num3 + 2] = array[4];
						dp[num2 + num3 + num3 + 3] = array[4];
						bool flag179 = Hqx.diff(array[7], array[3], trY, trU, trV, trA);
						if (flag179)
						{
							dp[num2 + num3 + num3 + num3] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3 + num3] = Interpolation.Mix2To1To1(array[4], array[7], array[3]);
						}
						dp[num2 + num3 + num3 + num3 + 1] = array[4];
						dp[num2 + num3 + num3 + num3 + 2] = array[4];
						bool flag180 = Hqx.diff(array[5], array[7], trY, trU, trV, trA);
						if (flag180)
						{
							dp[num2 + num3 + num3 + num3 + 3] = array[4];
						}
						else
						{
							dp[num2 + num3 + num3 + num3 + 3] = Interpolation.Mix2To1To1(array[4], array[7], array[5]);
						}
						break;
					}
					}
					num8 = num;
					num = num8 + 1;
					num2 += 4;
					num8 = j;
				}
				num2 += num3 * 3;
				num8 = i;
			}
		}
	}
}
