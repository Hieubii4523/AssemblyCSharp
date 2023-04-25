using System;

// Token: 0x02000094 RID: 148
public class Message
{
	// Token: 0x0600093E RID: 2366 RVA: 0x0000B063 File Offset: 0x00009263
	public Message(int command)
	{
		this.command = (sbyte)command;
		this.dos = new myWriter();
	}

	// Token: 0x0600093F RID: 2367 RVA: 0x0000B080 File Offset: 0x00009280
	public Message()
	{
		this.dos = new myWriter();
	}

	// Token: 0x06000940 RID: 2368 RVA: 0x0000B095 File Offset: 0x00009295
	public Message(sbyte command)
	{
		this.command = command;
		this.dos = new myWriter();
	}

	// Token: 0x06000941 RID: 2369 RVA: 0x0000B0B1 File Offset: 0x000092B1
	public Message(sbyte command, sbyte[] data)
	{
		this.command = command;
		this.dis = new myReader(data);
	}

	// Token: 0x06000942 RID: 2370 RVA: 0x000C0F30 File Offset: 0x000BF130
	public sbyte[] getData()
	{
		return this.dos.getData();
	}

	// Token: 0x06000943 RID: 2371 RVA: 0x000C0F50 File Offset: 0x000BF150
	public myReader reader()
	{
		return this.dis;
	}

	// Token: 0x06000944 RID: 2372 RVA: 0x000C0F68 File Offset: 0x000BF168
	public myWriter writer()
	{
		return this.dos;
	}

	// Token: 0x06000945 RID: 2373 RVA: 0x000C0F80 File Offset: 0x000BF180
	public int readInt3Byte()
	{
		int num = (int)this.dis.readByte() + 128;
		int num2 = (int)this.dis.readByte() + 128;
		int num3 = (int)this.dis.readByte() + 128;
		return (num3 * 256 + num2) * 256 + num;
	}

	// Token: 0x06000946 RID: 2374 RVA: 0x000090B5 File Offset: 0x000072B5
	public void cleanup()
	{
	}

	// Token: 0x04000EE1 RID: 3809
	public sbyte command;

	// Token: 0x04000EE2 RID: 3810
	private myReader dis;

	// Token: 0x04000EE3 RID: 3811
	private myWriter dos;

	// Token: 0x04000EE4 RID: 3812
	public byte isOld;
}
