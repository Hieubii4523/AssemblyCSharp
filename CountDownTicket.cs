using System;

// Token: 0x0200001C RID: 28
public class CountDownTicket
{
	// Token: 0x0600010E RID: 270 RVA: 0x000094A9 File Offset: 0x000076A9
	public void setCountDown(int time)
	{
		this.timeCountDown = time;
		this.tickBeginCount = GameCanvas.timeNow;
	}

	// Token: 0x0600010F RID: 271 RVA: 0x0001A8F8 File Offset: 0x00018AF8
	public int CheckUpdate()
	{
		bool flag = this.timeCountDown > 0;
		int result;
		if (flag)
		{
			this.updateTimeCountDownTicket();
			bool flag2 = this.timeCountDown > 0;
			if (flag2)
			{
				result = 1;
			}
			else
			{
				result = 0;
			}
		}
		else
		{
			result = -1;
		}
		return result;
	}

	// Token: 0x06000110 RID: 272 RVA: 0x0001A938 File Offset: 0x00018B38
	public void updateTimeCountDownTicket()
	{
		bool flag = this.timeCountDown > 0;
		if (flag)
		{
			bool flag2 = GameCanvas.timeNow - this.tickBeginCount > 2000L;
			if (flag2)
			{
				short num = (short)((GameCanvas.timeNow - this.tickBeginCount) / 1000L);
				this.timeCountDown -= (int)num;
				this.tickBeginCount += (long)(num * 1000);
			}
			bool flag3 = GameCanvas.timeNow - this.tickBeginCount > 1000L;
			if (flag3)
			{
				this.timeCountDown--;
				this.tickBeginCount += 1000L;
			}
		}
	}

	// Token: 0x06000111 RID: 273 RVA: 0x0001A9E8 File Offset: 0x00018BE8
	public void paintCountDownTicket(mGraphics g, mFont f, int x, int y, int anchor)
	{
		int time = 0;
		bool flag = this.timeCountDown > 0;
		if (flag)
		{
			time = this.timeCountDown;
		}
		f.drawString(g, CountDownTicket.timeShow(time), x, y, anchor);
	}

	// Token: 0x06000112 RID: 274 RVA: 0x0001AA24 File Offset: 0x00018C24
	public void paintCountDownTicketHour(mGraphics g, mFont f, int x, int y, int anchor)
	{
		bool flag = this.timeCountDown >= 3600;
		if (flag)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			int num = this.timeCountDown / 60;
			int num2 = num / 60;
			int num3 = num % 60;
			text = ((num2 >= 10) ? (string.Empty + num2.ToString()) : ("0" + num2.ToString()));
			f.drawString(g, text, x, y, anchor);
			int width = f.getWidth(text);
			bool flag2 = GameCanvas.gameTick % 25 < 20;
			if (flag2)
			{
				f.drawString(g, ":", x + width + 1, y, anchor);
			}
			text2 = ((num3 >= 10) ? (text2 + string.Empty + num3.ToString()) : (text2 + "0" + num3.ToString()));
			f.drawString(g, text2, x + width + 4, y, anchor);
		}
		else
		{
			f.drawString(g, CountDownTicket.timeShow(this.timeCountDown), x, y, anchor);
		}
	}

	// Token: 0x06000113 RID: 275 RVA: 0x0001AB38 File Offset: 0x00018D38
	public static string timeShow(int time)
	{
		string str = string.Empty;
		bool flag = time >= 3600;
		string result;
		if (flag)
		{
			int num = time / 60;
			str += (num / 60).ToString();
			str = ((GameCanvas.gameTick % 25 >= 20) ? (str + " ") : (str + ":"));
			bool flag2 = num % 60 < 10;
			if (flag2)
			{
				result = str + "0" + (num % 60).ToString();
			}
			else
			{
				result = str + string.Empty + (num % 60).ToString();
			}
		}
		else
		{
			str = ((time < 60) ? (str + "00") : ((time >= 600) ? (str + (time / 60).ToString()) : (str + "0" + (time / 60).ToString())));
			bool flag3 = time % 60 < 10;
			if (flag3)
			{
				result = str + ":0" + (time % 60).ToString();
			}
			else
			{
				result = str + ":" + (time % 60).ToString();
			}
		}
		return result;
	}

	// Token: 0x04000252 RID: 594
	public int timeCountDown;

	// Token: 0x04000253 RID: 595
	public long tickBeginCount;

	// Token: 0x04000254 RID: 596
	public string strInfo = string.Empty;

	// Token: 0x04000255 RID: 597
	public sbyte typeTime;

	// Token: 0x04000256 RID: 598
	public int valueLeft;

	// Token: 0x04000257 RID: 599
	public int valueright;
}
