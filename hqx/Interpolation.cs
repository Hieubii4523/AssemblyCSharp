using System;

namespace hqx
{
	// Token: 0x0200011A RID: 282
	public class Interpolation
	{
		// Token: 0x0600101A RID: 4122 RVA: 0x0014F8E8 File Offset: 0x0014DAE8
		public static int Mix3To1(int c1, int c2)
		{
			bool flag = c1 == c2;
			int result;
			if (flag)
			{
				result = c1;
			}
			else
			{
				result = (int)((((long)c1 & 65280L) * 3L + ((long)c2 & 65280L) >> 2 & 65280L) | (((long)c1 & 16711935L) * 3L + ((long)c2 & 16711935L) >> 2 & 16711935L) | ((((long)c1 & (long)((ulong)-16777216)) >> 2) * 3L + (((long)c2 & (long)((ulong)-16777216)) >> 2) & (long)((ulong)-16777216)));
			}
			return result;
		}

		// Token: 0x0600101B RID: 4123 RVA: 0x0014F96C File Offset: 0x0014DB6C
		public static int Mix2To1To1(int c1, int c2, int c3)
		{
			return (int)((((long)c1 & 65280L) * 2L + ((long)c2 & 65280L) + ((long)c3 & 65280L) >> 2 & 65280L) | (((long)c1 & 16711935L) * 2L + ((long)c2 & 16711935L) + ((long)c3 & 16711935L) >> 2 & 16711935L) | ((((long)c1 & (long)((ulong)-16777216)) >> 2) * 2L + (((long)c2 & (long)((ulong)-16777216)) >> 2) + (((long)c3 & (long)((ulong)-16777216)) >> 2) & (long)((ulong)-16777216)));
		}

		// Token: 0x0600101C RID: 4124 RVA: 0x0014FA00 File Offset: 0x0014DC00
		public static int Mix7To1(int c1, int c2)
		{
			bool flag = c1 == c2;
			int result;
			if (flag)
			{
				result = c1;
			}
			else
			{
				result = (int)((((long)c1 & 65280L) * 7L + ((long)c2 & 65280L) >> 3 & 65280L) | (((long)c1 & 16711935L) * 7L + ((long)c2 & 16711935L) >> 3 & 16711935L) | ((((long)c1 & (long)((ulong)-16777216)) >> 3) * 7L + (((long)c2 & (long)((ulong)-16777216)) >> 3) & (long)((ulong)-16777216)));
			}
			return result;
		}

		// Token: 0x0600101D RID: 4125 RVA: 0x0014FA84 File Offset: 0x0014DC84
		public static int Mix2To7To7(int c1, int c2, int c3)
		{
			return (int)((((long)c1 & 65280L) * 2L + ((long)c2 & 65280L) * 7L + ((long)c3 & 65280L) * 7L >> 4 & 65280L) | (((long)c1 & 16711935L) * 2L + ((long)c2 & 16711935L) * 7L + ((long)c3 & 16711935L) * 7L >> 4 & 16711935L) | ((((long)c1 & (long)((ulong)-16777216)) >> 4) * 2L + (((long)c2 & (long)((ulong)-16777216)) >> 4) * 7L + (((long)c3 & (long)((ulong)-16777216)) >> 4) * 7L & (long)((ulong)-16777216)));
		}

		// Token: 0x0600101E RID: 4126 RVA: 0x0014FB2C File Offset: 0x0014DD2C
		public static int MixEven(int c1, int c2)
		{
			bool flag = c1 == c2;
			int result;
			if (flag)
			{
				result = c1;
			}
			else
			{
				result = (int)((((long)c1 & 65280L) + ((long)c2 & 65280L) >> 1 & 65280L) | (((long)c1 & 16711935L) + ((long)c2 & 16711935L) >> 1 & 16711935L) | ((((long)c1 & (long)((ulong)-16777216)) >> 1) + (((long)c2 & (long)((ulong)-16777216)) >> 1) & (long)((ulong)-16777216)));
			}
			return result;
		}

		// Token: 0x0600101F RID: 4127 RVA: 0x0014FBA4 File Offset: 0x0014DDA4
		public static int Mix4To2To1(int c1, int c2, int c3)
		{
			return (int)((((long)c1 & 65280L) * 5L + ((long)c2 & 65280L) * 2L + ((long)c3 & 65280L) >> 3 & 65280L) | (((long)c1 & 16711935L) * 5L + ((long)c2 & 16711935L) * 2L + ((long)c3 & 16711935L) >> 3 & 16711935L) | ((((long)c1 & (long)((ulong)-16777216)) >> 3) * 5L + (((long)c2 & (long)((ulong)-16777216)) >> 3) * 2L + (((long)c3 & (long)((ulong)-16777216)) >> 3) & (long)((ulong)-16777216)));
		}

		// Token: 0x06001020 RID: 4128 RVA: 0x0014FC44 File Offset: 0x0014DE44
		public static int Mix6To1To1(int c1, int c2, int c3)
		{
			return (int)((((long)c1 & 65280L) * 6L + ((long)c2 & 65280L) + ((long)c3 & 65280L) >> 3 & 65280L) | (((long)c1 & 16711935L) * 6L + ((long)c2 & 16711935L) + ((long)c3 & 16711935L) >> 3 & 16711935L) | ((((long)c1 & (long)((ulong)-16777216)) >> 3) * 6L + (((long)c2 & (long)((ulong)-16777216)) >> 3) + (((long)c3 & (long)((ulong)-16777216)) >> 3) & (long)((ulong)-16777216)));
		}

		// Token: 0x06001021 RID: 4129 RVA: 0x0014FCD8 File Offset: 0x0014DED8
		public static int Mix5To3(int c1, int c2)
		{
			bool flag = c1 == c2;
			int result;
			if (flag)
			{
				result = c1;
			}
			else
			{
				result = (int)((((long)c1 & 65280L) * 5L + ((long)c2 & 65280L) * 3L >> 3 & 65280L) | (((long)c1 & 16711935L) * 5L + ((long)c2 & 16711935L) * 3L >> 3 & 16711935L) | ((((long)c1 & (long)((ulong)-16777216)) >> 3) * 5L + (((long)c2 & (long)((ulong)-16777216)) >> 3) * 3L & (long)((ulong)-16777216)));
			}
			return result;
		}

		// Token: 0x06001022 RID: 4130 RVA: 0x0014FD64 File Offset: 0x0014DF64
		public static int Mix2To3To3(int c1, int c2, int c3)
		{
			return (int)((((long)c1 & 65280L) * 2L + ((long)c2 & 65280L) * 3L + ((long)c3 & 65280L) * 3L >> 3 & 65280L) | (((long)c1 & 16711935L) * 2L + ((long)c2 & 16711935L) * 3L + ((long)c3 & 16711935L) * 3L >> 3 & 16711935L) | ((((long)c1 & (long)((ulong)-16777216)) >> 3) * 2L + (((long)c2 & (long)((ulong)-16777216)) >> 3) * 3L + (((long)c3 & (long)((ulong)-16777216)) >> 3) * 3L & (long)((ulong)-16777216)));
		}

		// Token: 0x06001023 RID: 4131 RVA: 0x0014FE0C File Offset: 0x0014E00C
		public static int Mix14To1To1(int c1, int c2, int c3)
		{
			return (int)((((long)c1 & 65280L) * 14L + ((long)c2 & 65280L) + ((long)c3 & 65280L) >> 4 & 65280L) | (((long)c1 & 16711935L) * 14L + ((long)c2 & 16711935L) + ((long)c3 & 16711935L) >> 4 & 16711935L) | ((((long)c1 & (long)((ulong)-16777216)) >> 4) * 14L + (((long)c2 & (long)((ulong)-16777216)) >> 4) + (((long)c3 & (long)((ulong)-16777216)) >> 4) & (long)((ulong)-16777216)));
		}

		// Token: 0x04001A7C RID: 6780
		private const uint Mask4 = 4278190080U;

		// Token: 0x04001A7D RID: 6781
		private const uint Mask2 = 65280U;

		// Token: 0x04001A7E RID: 6782
		private const uint Mask13 = 16711935U;
	}
}
