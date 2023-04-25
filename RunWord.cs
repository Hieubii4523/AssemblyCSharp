using System;

// Token: 0x020000DE RID: 222
public class RunWord
{
	// Token: 0x06000D68 RID: 3432 RVA: 0x001049D4 File Offset: 0x00102BD4
	public void startDialogChain(string dlgChain, int ActionType, int xFocus, int yFocus, int w, mFont f)
	{
		this.f = f;
		this.dlgActionType = ActionType;
		this.dlgFocusX = xFocus;
		this.dlgFocusY = yFocus;
		this.currentDlgStep = 0;
		this.dlgW = w;
		bool flag = this.dlgW > MotherCanvas.w - 10;
		if (flag)
		{
			this.dlgW = MotherCanvas.w - 10;
		}
		this.dlgChainInfo = f.splitFontArray(dlgChain, this.dlgW);
		this.dlgX = this.dlgFocusX;
		this.showDlg = true;
		this.dlgRunX = 0;
		this.dlgRunY = 0;
	}

	// Token: 0x06000D69 RID: 3433 RVA: 0x00104A68 File Offset: 0x00102C68
	public bool checkDlgStep()
	{
		bool flag = this.dlgRunY < this.dlgChainInfo.Length;
		return !flag;
	}

	// Token: 0x06000D6A RID: 3434 RVA: 0x00104A94 File Offset: 0x00102C94
	public bool nextDlgStep()
	{
		bool flag = this.dlgRunY < this.dlgChainInfo.Length;
		bool result;
		if (flag)
		{
			this.dlgRunY = this.dlgChainInfo.Length;
			this.dlgRunX = 0;
			result = false;
		}
		else
		{
			this.dlgRunX = (this.dlgRunY = 0);
			result = true;
		}
		return result;
	}

	// Token: 0x06000D6B RID: 3435 RVA: 0x00104AE8 File Offset: 0x00102CE8
	public void updateDlg()
	{
		bool flag = this.showDlg && this.dlgRunY < this.dlgChainInfo.Length;
		if (flag)
		{
			this.dlgRunX += 2;
			bool flag2 = this.dlgRunX >= this.dlgChainInfo[this.dlgRunY].Length;
			if (flag2)
			{
				this.dlgRunX = 0;
				this.dlgRunY++;
			}
		}
	}

	// Token: 0x06000D6C RID: 3436 RVA: 0x00104B60 File Offset: 0x00102D60
	public void paintText(mGraphics g)
	{
		int num = this.dlgFocusY;
		for (int i = 0; i < this.dlgRunY; i++)
		{
			this.f.drawString(g, this.dlgChainInfo[i], this.dlgX, num + i * GameCanvas.hText, 0);
		}
		bool flag = this.dlgRunY < this.dlgChainInfo.Length;
		if (flag)
		{
			this.f.drawString(g, this.dlgChainInfo[this.dlgRunY].Substring(0, this.dlgRunX), this.dlgX, num + this.dlgRunY * GameCanvas.hText, 0);
		}
	}

	// Token: 0x06000D6D RID: 3437 RVA: 0x00104C04 File Offset: 0x00102E04
	public void paintText(mGraphics g, int archor)
	{
		int num = this.dlgFocusY;
		bool flag = archor == 2;
		if (flag)
		{
			for (int i = 0; i < this.dlgRunY; i++)
			{
				this.f.drawString(g, this.dlgChainInfo[i], this.dlgX + this.dlgW / 2, num + i * GameCanvas.hText, 2);
			}
			bool flag2 = this.dlgRunY < this.dlgChainInfo.Length;
			if (flag2)
			{
				this.f.drawString(g, this.dlgChainInfo[this.dlgRunY].Substring(0, this.dlgRunX), this.dlgX + this.dlgW / 2, num + this.dlgRunY * GameCanvas.hText, 2);
			}
		}
		else
		{
			for (int j = 0; j < this.dlgRunY; j++)
			{
				this.f.drawString(g, this.dlgChainInfo[j], this.dlgX, num + j * GameCanvas.hText, 0);
			}
			bool flag3 = this.dlgRunY < this.dlgChainInfo.Length;
			if (flag3)
			{
				this.f.drawString(g, this.dlgChainInfo[this.dlgRunY].Substring(0, this.dlgRunX), this.dlgX, num + this.dlgRunY * GameCanvas.hText, 0);
			}
		}
	}

	// Token: 0x040014B4 RID: 5300
	public bool showDlg;

	// Token: 0x040014B5 RID: 5301
	public int nStepToShow;

	// Token: 0x040014B6 RID: 5302
	public int currentDlgStep;

	// Token: 0x040014B7 RID: 5303
	public int dlgActionType;

	// Token: 0x040014B8 RID: 5304
	public string[] dlgChainInfo;

	// Token: 0x040014B9 RID: 5305
	public int dlgFocusX;

	// Token: 0x040014BA RID: 5306
	public int dlgFocusY;

	// Token: 0x040014BB RID: 5307
	public int dlgRunX;

	// Token: 0x040014BC RID: 5308
	public int dlgRunY;

	// Token: 0x040014BD RID: 5309
	public int dlgW;

	// Token: 0x040014BE RID: 5310
	public int dlgX;

	// Token: 0x040014BF RID: 5311
	private mFont f;
}
