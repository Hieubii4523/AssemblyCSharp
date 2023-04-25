using System;

// Token: 0x020000D5 RID: 213
public class QuaNapThe
{
	// Token: 0x06000C35 RID: 3125 RVA: 0x000E9C18 File Offset: 0x000E7E18
	public QuaNapThe(int cost, sbyte status, short sizeQ)
	{
		this.cost = cost;
		this.statusNhan = status;
		this.numQua = sizeQ;
		this.initAnim();
	}

	// Token: 0x06000C36 RID: 3126 RVA: 0x000E9C74 File Offset: 0x000E7E74
	public void paint(mGraphics g, int xpaint, int ypaint)
	{
		bool flag = !this.isRun || this.numQua <= 3;
		if (flag)
		{
			for (int i = 0; i < 3; i++)
			{
				ItemQuaNT itemQuaNT = (ItemQuaNT)this.vecQua.elementAt(i);
				if (itemQuaNT != null)
				{
					itemQuaNT.paint(g, xpaint + (this.sizeItem + 3) * i + this.sizeItem / 2, ypaint + this.sizeItem / 2, this.sizeItem);
				}
			}
		}
		else
		{
			for (int j = 0; j < (int)this.numQua; j++)
			{
				ItemQuaNT itemQuaNT2 = (ItemQuaNT)this.vecQua.elementAt(j);
				itemQuaNT2.paint(g, xpaint - this.xplus + (this.sizeItem + 3) * j + this.sizeItem / 2, ypaint + this.sizeItem / 2, this.sizeItem);
			}
		}
	}

	// Token: 0x06000C37 RID: 3127 RVA: 0x000E9D58 File Offset: 0x000E7F58
	public void update()
	{
		bool flag = this.isRun;
		if (flag)
		{
			this.time++;
			bool flag2 = this.isDelay;
			if (flag2)
			{
				bool flag3 = this.time <= this.t;
				if (flag3)
				{
					return;
				}
				this.isDelay = false;
			}
			bool flag4 = this.time > 10;
			if (flag4)
			{
				bool flag5 = !this.isLeftRight;
				if (flag5)
				{
					this.xplus += this.speed;
				}
				else
				{
					this.xplus -= this.speed;
				}
			}
			bool flag6 = this.xplus > this.limit || this.xplus < 0;
			if (flag6)
			{
				this.isLeftRight = !this.isLeftRight;
				this.isDelay = true;
				this.t = this.time + this.timeDelay;
			}
		}
		else
		{
			this.xplus = 0;
			this.time = 0;
			this.isDelay = false;
		}
	}

	// Token: 0x06000C38 RID: 3128 RVA: 0x000E9E60 File Offset: 0x000E8060
	private void initAnim()
	{
		int num = (this.sizeItem + 3) * (int)this.numQua - 3;
		this.xplus = 0;
		this.time = 0;
		this.isLeftRight = false;
		bool flag = num > this.wPaintQua;
		if (flag)
		{
			this.limit = num - this.wPaintQua;
			this.isRun = true;
		}
		else
		{
			this.isRun = false;
		}
	}

	// Token: 0x0400133F RID: 4927
	public int rubyDaNap;

	// Token: 0x04001340 RID: 4928
	public int cost;

	// Token: 0x04001341 RID: 4929
	public sbyte statusNhan;

	// Token: 0x04001342 RID: 4930
	public short numQua;

	// Token: 0x04001343 RID: 4931
	public mVector vecQua = new mVector();

	// Token: 0x04001344 RID: 4932
	public int xplus;

	// Token: 0x04001345 RID: 4933
	public bool isRun;

	// Token: 0x04001346 RID: 4934
	private bool isLeftRight;

	// Token: 0x04001347 RID: 4935
	private int time;

	// Token: 0x04001348 RID: 4936
	private int speed = 1;

	// Token: 0x04001349 RID: 4937
	private int limit;

	// Token: 0x0400134A RID: 4938
	private int sizeItem = 29;

	// Token: 0x0400134B RID: 4939
	private int wPaintQua = 93;

	// Token: 0x0400134C RID: 4940
	private int timeDelay = 20;

	// Token: 0x0400134D RID: 4941
	private bool isDelay;

	// Token: 0x0400134E RID: 4942
	private int t;
}
