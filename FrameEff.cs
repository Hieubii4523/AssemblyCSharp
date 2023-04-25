using System;

// Token: 0x0200002F RID: 47
public class FrameEff
{
	// Token: 0x0600036C RID: 876 RVA: 0x00009AB3 File Offset: 0x00007CB3
	public FrameEff(mVector listtop, mVector listbottom)
	{
		this.listPartTop = listtop;
		this.listPartBottom = listbottom;
	}

	// Token: 0x0600036D RID: 877 RVA: 0x0006F58C File Offset: 0x0006D78C
	public mVector getListPartPaint()
	{
		mVector mVector = new mVector();
		for (int i = 0; i < this.listPartBottom.size(); i++)
		{
			mVector.addElement(this.listPartBottom.elementAt(i));
		}
		for (int j = 0; j < this.listPartTop.size(); j++)
		{
			mVector.addElement(this.listPartTop.elementAt(j));
		}
		return mVector;
	}

	// Token: 0x04000561 RID: 1377
	public mVector listPartTop = new mVector();

	// Token: 0x04000562 RID: 1378
	public mVector listPartBottom = new mVector();

	// Token: 0x04000563 RID: 1379
	public sbyte xShadow;

	// Token: 0x04000564 RID: 1380
	public sbyte yShadow;
}
