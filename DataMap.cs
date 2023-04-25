using System;

// Token: 0x02000021 RID: 33
public class DataMap
{
	// Token: 0x06000162 RID: 354 RVA: 0x00009597 File Offset: 0x00007797
	public void setDataMap(sbyte[] mdata)
	{
		this.dataMap = mdata;
	}

	// Token: 0x06000163 RID: 355 RVA: 0x000095A1 File Offset: 0x000077A1
	public void setDataItemMap(sbyte[] mdata)
	{
		this.dataItemMap = mdata;
	}

	// Token: 0x06000164 RID: 356 RVA: 0x0001C694 File Offset: 0x0001A894
	public void setAddVecPointMap(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			for (int i = 0; i < (int)b; i++)
			{
				Point point = new Point();
				point.name = msg.reader().readUTF();
				point.x = (int)msg.reader().readShort();
				point.y = (int)msg.reader().readShort();
				this.vecPointMap.addElement(point);
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x04000274 RID: 628
	public static MyHashTable hashDataMap = new MyHashTable();

	// Token: 0x04000275 RID: 629
	public sbyte[] dataItemMap;

	// Token: 0x04000276 RID: 630
	public sbyte[] dataMap;

	// Token: 0x04000277 RID: 631
	public mVector vecPointMap = new mVector("DataMap.vecPointMap");

	// Token: 0x04000278 RID: 632
	public short hBack;

	// Token: 0x04000279 RID: 633
	public sbyte IdBack;

	// Token: 0x0400027A RID: 634
	public string nameMap;
}
