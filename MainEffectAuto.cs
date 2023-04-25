using System;

// Token: 0x02000077 RID: 119
public class MainEffectAuto
{
	// Token: 0x06000720 RID: 1824 RVA: 0x0000A967 File Offset: 0x00008B67
	public MainEffectAuto()
	{
	}

	// Token: 0x06000721 RID: 1825 RVA: 0x0000A97C File Offset: 0x00008B7C
	public MainEffectAuto(DataInputStream data, sbyte[] dataImage)
	{
		this.setEffAuto(data);
		this.img = mImage.createImage(dataImage, 0, dataImage.Length);
	}

	// Token: 0x06000722 RID: 1826 RVA: 0x00099E50 File Offset: 0x00098050
	public void setEffAuto(DataInputStream msg)
	{
		try
		{
			sbyte b = msg.readByte();
			for (int i = 0; i < (int)b; i++)
			{
				MainPartImage mainPartImage = new MainPartImage(msg.readByte(), msg.readByte(), msg.readByte(), msg.readByte(), msg.readByte());
				this.hashImage.put(string.Empty + mainPartImage.ID.ToString(), mainPartImage);
			}
			short num = msg.readShort();
			this.mFrame = new MainFrameEff[(int)num];
			for (int j = 0; j < (int)num; j++)
			{
				sbyte b2 = msg.readByte();
				this.mFrame[j] = new MainFrameEff();
				this.mFrame[j].mpart = new Part[(int)b2];
				for (int k = 0; k < (int)b2; k++)
				{
					this.mFrame[j].mpart[k] = new Part();
					this.mFrame[j].mpart[k].x = msg.readShort();
					this.mFrame[j].mpart[k].y = msg.readShort();
					this.mFrame[j].mpart[k].idPartImage = msg.readByte();
				}
			}
			short num2 = msg.readShort();
			this.mRunFrame = new short[(int)num2];
			for (int l = 0; l < (int)num2; l++)
			{
				this.mRunFrame[l] = msg.readShort();
			}
			msg.readByte();
			msg.readByte();
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x04000AD4 RID: 2772
	public static MyHashTable hashTemEffAuto = new MyHashTable();

	// Token: 0x04000AD5 RID: 2773
	public MyHashTable hashImage = new MyHashTable();

	// Token: 0x04000AD6 RID: 2774
	public MainFrameEff[] mFrame;

	// Token: 0x04000AD7 RID: 2775
	public short[] mRunFrame;

	// Token: 0x04000AD8 RID: 2776
	public mImage img;
}
