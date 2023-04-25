using System;

// Token: 0x0200006B RID: 107
public class ListNew
{
	// Token: 0x0600067C RID: 1660 RVA: 0x0000A782 File Offset: 0x00008982
	public ListNew()
	{
	}

	// Token: 0x0600067D RID: 1661 RVA: 0x0008ECA8 File Offset: 0x0008CEA8
	public ListNew(int x, int y, int maxW, int maxH, int itemH, int maxSize, int limX, bool isLim0)
	{
		this.x = x;
		this.y = y;
		this.maxW = maxW;
		this.maxH = maxH;
		this.itemH = itemH;
		this.maxSize = maxSize;
		this.cmxLim = limX;
		bool flag = isLim0 && this.cmxLim < 0;
		if (flag)
		{
			this.cmxLim = 0;
		}
	}

	// Token: 0x0600067E RID: 1662 RVA: 0x0008ED1C File Offset: 0x0008CF1C
	public void updateMenuKey()
	{
		bool flag = false;
		bool flag2 = GameCanvas.keyMyPressed[2];
		if (flag2)
		{
			flag = true;
			this.value--;
			bool flag3 = this.value < 0;
			if (flag3)
			{
				this.value = this.maxSize - 1;
			}
			GameCanvas.clearKeyPressed(2);
			GameCanvas.clearKeyPressed(4);
		}
		else
		{
			bool flag4 = GameCanvas.keyMyPressed[8];
			if (flag4)
			{
				flag = true;
				this.value++;
				bool flag5 = this.value > this.maxSize - 1;
				if (flag5)
				{
					this.value = this.maxSize - 1;
				}
				GameCanvas.clearKeyPressed(6);
				GameCanvas.clearKeyPressed(8);
			}
		}
		bool flag6 = flag;
		if (flag6)
		{
			this.cmtoX = (this.value + 1) * this.itemH - this.maxH / 2;
			bool flag7 = this.cmtoX > this.cmxLim;
			if (flag7)
			{
				this.cmtoX = this.cmxLim;
			}
			bool flag8 = this.cmtoX < 0;
			if (flag8)
			{
				this.cmtoX = 0;
			}
			bool flag9 = this.value == this.maxSize - 1 || this.value == 0;
			if (flag9)
			{
				this.cmx = this.cmtoX;
			}
		}
		this.update_Pos_UP_DOWN();
	}

	// Token: 0x0600067F RID: 1663 RVA: 0x0008EE64 File Offset: 0x0008D064
	public void update_Pos_UP_DOWN()
	{
		bool isPointerDown = GameCanvas.isPointerDown;
		if (isPointerDown)
		{
			bool flag = !this.pointerIsDowning && GameCanvas.isPointer(this.x, this.y, this.maxW, this.maxH);
			if (flag)
			{
				for (int i = 0; i < this.pointerDownLastX.Length; i++)
				{
					this.pointerDownLastX[0] = GameCanvas.py;
				}
				this.pointerDownFirstX = GameCanvas.py;
				this.pointerIsDowning = true;
				this.isDownWhenRunning = (this.cmRun != 0);
				this.cmRun = 0;
			}
			else
			{
				bool flag2 = this.pointerIsDowning;
				if (flag2)
				{
					this.pointerDownTime++;
					bool flag3 = this.pointerDownTime > 5 && this.pointerDownFirstX == GameCanvas.py && !this.isDownWhenRunning;
					if (flag3)
					{
						this.pointerDownFirstX = -1000;
					}
					int num = GameCanvas.py - this.pointerDownLastX[0];
					bool flag4 = num != 0 && this.value != -1;
					if (flag4)
					{
						this.value = -1;
					}
					for (int j = this.pointerDownLastX.Length - 1; j > 0; j--)
					{
						this.pointerDownLastX[j] = this.pointerDownLastX[j - 1];
					}
					this.pointerDownLastX[0] = GameCanvas.py;
					this.cmtoX -= num;
					bool flag5 = this.cmtoX < 0;
					if (flag5)
					{
						this.cmtoX = 0;
					}
					bool flag6 = this.cmtoX > this.cmxLim;
					if (flag6)
					{
						this.cmtoX = this.cmxLim;
					}
					bool flag7 = this.cmx < 0 || this.cmx > this.cmxLim;
					if (flag7)
					{
						num /= 2;
					}
					this.cmx -= num;
				}
			}
		}
		bool flag8 = !GameCanvas.isPointerClick || !this.pointerIsDowning;
		if (!flag8)
		{
			int a = GameCanvas.py - this.pointerDownLastX[0];
			GameCanvas.isPointerClick = false;
			bool flag9 = CRes.abs(a) < 20 && CRes.abs(GameCanvas.py - this.pointerDownFirstX) < 20 && !this.isDownWhenRunning && GameCanvas.isPointerSelect;
			if (flag9)
			{
				this.cmRun = 0;
				this.cmtoX = this.cmx;
				this.pointerDownFirstX = -1000;
				this.pointerDownTime = 0;
			}
			else
			{
				bool flag10 = this.value != -1 && this.pointerDownTime > 5;
				if (flag10)
				{
					this.pointerDownTime = 0;
				}
				else
				{
					bool flag11 = this.value == -1 && !this.isDownWhenRunning;
					if (flag11)
					{
						bool flag12 = this.cmx < 0;
						if (flag12)
						{
							this.cmtoX = 0;
						}
						else
						{
							bool flag13 = this.cmx > this.cmxLim;
							if (flag13)
							{
								this.cmtoX = this.cmxLim;
							}
							else
							{
								int num2 = GameCanvas.py - this.pointerDownLastX[0] + (this.pointerDownLastX[0] - this.pointerDownLastX[1]) + (this.pointerDownLastX[1] - this.pointerDownLastX[2]);
								num2 = ((num2 > 10) ? 10 : ((num2 < -10) ? -10 : 0));
								this.cmRun = -num2 * 100;
							}
						}
					}
				}
			}
			this.pointerIsDowning = false;
			this.pointerDownTime = 0;
			GameCanvas.isPointerClick = false;
		}
	}

	// Token: 0x06000680 RID: 1664 RVA: 0x0008F1D4 File Offset: 0x0008D3D4
	public void updatePos_LEFT_RIGHT()
	{
		bool isPointerDown = GameCanvas.isPointerDown;
		if (isPointerDown)
		{
			bool flag = !this.pointerIsDowning && GameCanvas.isPointer(this.x, this.y, this.maxW, this.maxH);
			if (flag)
			{
				for (int i = 0; i < this.pointerDownLastX.Length; i++)
				{
					this.pointerDownLastX[0] = GameCanvas.px;
				}
				this.pointerDownFirstX = GameCanvas.px;
				this.pointerIsDowning = true;
				this.isDownWhenRunning = (this.cmRun != 0);
				this.cmRun = 0;
			}
			else
			{
				bool flag2 = this.pointerIsDowning;
				if (flag2)
				{
					this.pointerDownTime++;
					bool flag3 = this.pointerDownTime > 5 && this.pointerDownFirstX == GameCanvas.px && !this.isDownWhenRunning;
					if (flag3)
					{
						this.pointerDownFirstX = -1000;
					}
					int num = GameCanvas.px - this.pointerDownLastX[0];
					bool flag4 = num != 0 && this.value != -1;
					if (flag4)
					{
						this.value = -1;
					}
					for (int j = this.pointerDownLastX.Length - 1; j > 0; j--)
					{
						this.pointerDownLastX[j] = this.pointerDownLastX[j - 1];
					}
					this.pointerDownLastX[0] = GameCanvas.px;
					this.cmtoX -= num;
					bool flag5 = this.cmtoX < 0;
					if (flag5)
					{
						this.cmtoX = 0;
					}
					bool flag6 = this.cmtoX > this.cmxLim;
					if (flag6)
					{
						this.cmtoX = this.cmxLim;
					}
					bool flag7 = this.cmx < 0 || this.cmx > this.cmxLim;
					if (flag7)
					{
						num /= 2;
					}
					this.cmx -= num;
				}
			}
		}
		bool flag8 = !GameCanvas.isPointerClick || !this.pointerIsDowning;
		if (!flag8)
		{
			int a = GameCanvas.px - this.pointerDownLastX[0];
			GameCanvas.isPointerClick = false;
			bool flag9 = CRes.abs(a) < 20 && CRes.abs(GameCanvas.px - this.pointerDownFirstX) < 20 && !this.isDownWhenRunning && GameCanvas.isPointerSelect;
			if (flag9)
			{
				this.cmRun = 0;
				this.cmtoX = this.cmx;
				this.pointerDownFirstX = -1000;
				this.pointerDownTime = 0;
			}
			else
			{
				bool flag10 = this.value != -1 && this.pointerDownTime > 5;
				if (flag10)
				{
					this.pointerDownTime = 0;
				}
				else
				{
					bool flag11 = this.value == -1 && !this.isDownWhenRunning;
					if (flag11)
					{
						bool flag12 = this.cmx < 0;
						if (flag12)
						{
							this.cmtoX = 0;
						}
						else
						{
							bool flag13 = this.cmx > this.cmxLim;
							if (flag13)
							{
								this.cmtoX = this.cmxLim;
							}
							else
							{
								int num2 = GameCanvas.px - this.pointerDownLastX[0] + (this.pointerDownLastX[0] - this.pointerDownLastX[1]) + (this.pointerDownLastX[1] - this.pointerDownLastX[2]);
								num2 = ((num2 > 10) ? 10 : ((num2 < -10) ? -10 : 0));
								this.cmRun = -num2 * 100;
							}
						}
					}
				}
			}
			this.pointerIsDowning = false;
			this.pointerDownTime = 0;
			GameCanvas.isPointerClick = false;
		}
	}

	// Token: 0x06000681 RID: 1665 RVA: 0x0008F544 File Offset: 0x0008D744
	public void moveCamera()
	{
		bool flag = this.cmRun != 0 && !this.pointerIsDowning;
		if (flag)
		{
			this.cmtoX += this.cmRun / 100;
			bool flag2 = this.cmtoX < 0;
			if (flag2)
			{
				this.cmtoX = 0;
			}
			else
			{
				bool flag3 = this.cmtoX > this.cmxLim;
				if (flag3)
				{
					this.cmtoX = this.cmxLim;
				}
				else
				{
					this.cmx = this.cmtoX;
				}
			}
			this.cmRun = this.cmRun * 9 / 10;
			bool flag4 = this.cmRun < 100 && this.cmRun > -100;
			if (flag4)
			{
				this.cmRun = 0;
			}
		}
		bool flag5 = this.cmx != this.cmtoX && !this.pointerIsDowning;
		if (flag5)
		{
			this.cmvx = this.cmtoX - this.cmx << 2;
			this.cmdx += this.cmvx;
			this.cmx += this.cmdx >> 4;
			this.cmdx &= 15;
		}
	}

	// Token: 0x06000682 RID: 1666 RVA: 0x0000A798 File Offset: 0x00008998
	public void updateMenu()
	{
		this.moveCamera();
		this.updateMenuKey();
	}

	// Token: 0x06000683 RID: 1667 RVA: 0x0008F674 File Offset: 0x0008D874
	public void setToX(int value)
	{
		bool flag = value < 0;
		if (flag)
		{
			value = 0;
		}
		bool flag2 = value > this.cmxLim;
		if (flag2)
		{
			value = this.cmxLim;
		}
		this.cmtoX = value;
	}

	// Token: 0x04000953 RID: 2387
	public int maxW;

	// Token: 0x04000954 RID: 2388
	public int itemH;

	// Token: 0x04000955 RID: 2389
	public int maxH;

	// Token: 0x04000956 RID: 2390
	public int maxSize;

	// Token: 0x04000957 RID: 2391
	public int x;

	// Token: 0x04000958 RID: 2392
	public int y;

	// Token: 0x04000959 RID: 2393
	public int value;

	// Token: 0x0400095A RID: 2394
	public int cmtoX;

	// Token: 0x0400095B RID: 2395
	public int cmx;

	// Token: 0x0400095C RID: 2396
	public int cmdy;

	// Token: 0x0400095D RID: 2397
	public int cmvy;

	// Token: 0x0400095E RID: 2398
	public int cmxLim;

	// Token: 0x0400095F RID: 2399
	private int pointerDownTime;

	// Token: 0x04000960 RID: 2400
	private int pointerDownFirstX;

	// Token: 0x04000961 RID: 2401
	private int[] pointerDownLastX = new int[3];

	// Token: 0x04000962 RID: 2402
	public bool pointerIsDowning;

	// Token: 0x04000963 RID: 2403
	public bool isDownWhenRunning;

	// Token: 0x04000964 RID: 2404
	private int cmRun;

	// Token: 0x04000965 RID: 2405
	private mVector vecCmd;

	// Token: 0x04000966 RID: 2406
	public int w;

	// Token: 0x04000967 RID: 2407
	private int cmvx;

	// Token: 0x04000968 RID: 2408
	private int cmdx;
}
