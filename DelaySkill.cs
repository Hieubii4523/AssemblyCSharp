using System;

// Token: 0x02000025 RID: 37
public class DelaySkill
{
	// Token: 0x06000189 RID: 393 RVA: 0x0001DC64 File Offset: 0x0001BE64
	public void paint(mGraphics g, int x, int y, int w)
	{
		FrameImage frameImage = AvMain.fraDelay;
		bool flag = w > 32;
		if (flag)
		{
			w = 32;
		}
		bool flag2 = w <= 24;
		if (flag2)
		{
			frameImage = AvMain.fraDelay2;
		}
		bool flag3 = this.limit <= 0;
		if (!flag3)
		{
			bool flag4 = this.value > 0;
			if (flag4)
			{
				int num = 4 - this.value / (this.limit / 5);
				bool flag5 = num >= 0 && num <= 5;
				if (flag5)
				{
					g.drawRegion(frameImage.imgFrame, frameImage.frameWidth / 2 - w / 2, frameImage.frameWidth / 2 - w / 2 + num * frameImage.frameHeight, w, w, 0, (float)x, (float)y, 0);
				}
				int num2 = this.value / 1000;
				string st = string.Empty;
				st = ((num2 != 0) ? (string.Empty + num2.ToString()) : ("0." + (this.value % 1000 / 100).ToString()));
				mFont.tahoma_7_white.drawString(g, st, x + w / 2, y + w / 2 - 5, 2);
			}
			else
			{
				bool flag6 = this.value > -150;
				if (flag6)
				{
					g.setColor(15658700);
					g.fillRoundRect(x + 1, y + 1, w - 2, w - 2, 4, 4);
				}
			}
		}
	}

	// Token: 0x0600018A RID: 394 RVA: 0x0001DDD4 File Offset: 0x0001BFD4
	public void paintOnlytime(mGraphics g, int x, int y, int w, sbyte color)
	{
		int num = this.value / 1000;
		string st = string.Empty;
		st = ((num != 0) ? (string.Empty + num.ToString()) : ("0." + (this.value % 1000 / 100).ToString()));
		AvMain.setTextColor((int)color).drawString(g, st, x + w / 2, y + w / 2 - 5, 2);
	}

	// Token: 0x0600018B RID: 395 RVA: 0x0001DE4C File Offset: 0x0001C04C
	public bool isCoolDown()
	{
		bool flag = this.value > 0;
		return !flag;
	}

	// Token: 0x0600018C RID: 396 RVA: 0x0001DE74 File Offset: 0x0001C074
	public static DelaySkill getDelay(int index)
	{
		DelaySkill delaySkill = (DelaySkill)Player.delaySkill.get(string.Empty + index.ToString());
		bool flag = delaySkill == null;
		if (flag)
		{
			delaySkill = new DelaySkill();
			delaySkill.value = -150;
			delaySkill.limit = 0;
			delaySkill.timebegin = GameCanvas.timeNow;
			Player.delaySkill.put(string.Empty + index.ToString(), delaySkill);
		}
		return delaySkill;
	}

	// Token: 0x040002A9 RID: 681
	public sbyte typeSkill;

	// Token: 0x040002AA RID: 682
	public long timebegin;

	// Token: 0x040002AB RID: 683
	public int value;

	// Token: 0x040002AC RID: 684
	public int limit;
}
