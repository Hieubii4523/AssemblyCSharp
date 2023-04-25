using System;

// Token: 0x02000022 RID: 34
public class DataOutputStream
{
	// Token: 0x06000167 RID: 359 RVA: 0x000095D0 File Offset: 0x000077D0
	public DataOutputStream(ByteArrayOutputStream bos)
	{
		this.bos = bos;
	}

	// Token: 0x06000168 RID: 360 RVA: 0x000095EC File Offset: 0x000077EC
	public DataOutputStream()
	{
	}

	// Token: 0x06000169 RID: 361 RVA: 0x00009601 File Offset: 0x00007801
	public void writeShort(short i)
	{
		this.w.writeShort(i);
		this.bos.arr = this.w.getData();
	}

	// Token: 0x0600016A RID: 362 RVA: 0x00009627 File Offset: 0x00007827
	public void writeInt(int i)
	{
		this.w.writeInt(i);
		this.bos.arr = this.w.getData();
	}

	// Token: 0x0600016B RID: 363 RVA: 0x0000964D File Offset: 0x0000784D
	public void write(sbyte[] data)
	{
		this.w.writeSByte(data);
		this.bos.arr = this.w.getData();
	}

	// Token: 0x0600016C RID: 364 RVA: 0x0001C720 File Offset: 0x0001A920
	public sbyte[] toByteArray()
	{
		return this.w.getData();
	}

	// Token: 0x0600016D RID: 365 RVA: 0x00009673 File Offset: 0x00007873
	public void close()
	{
		this.w.Close();
	}

	// Token: 0x0600016E RID: 366 RVA: 0x00009682 File Offset: 0x00007882
	public void writeByte(sbyte b)
	{
		this.w.writeByte(b);
		this.bos.arr = this.w.getData();
	}

	// Token: 0x0600016F RID: 367 RVA: 0x000096A8 File Offset: 0x000078A8
	public void writeUTF(string name)
	{
		this.w.writeUTF(name);
		this.bos.arr = this.w.getData();
	}

	// Token: 0x06000170 RID: 368 RVA: 0x000096CE File Offset: 0x000078CE
	public void writeBoolean(bool b)
	{
		this.w.writeBoolean(b);
		this.bos.arr = this.w.getData();
	}

	// Token: 0x0400027B RID: 635
	private myWriter w = new myWriter();

	// Token: 0x0400027C RID: 636
	private ByteArrayOutputStream bos;
}
