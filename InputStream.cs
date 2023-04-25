using System;

// Token: 0x02000054 RID: 84
public class InputStream : myReader
{
	// Token: 0x060005A6 RID: 1446 RVA: 0x0000A47E File Offset: 0x0000867E
	public InputStream()
	{
	}

	// Token: 0x060005A7 RID: 1447 RVA: 0x0000A488 File Offset: 0x00008688
	public InputStream(sbyte[] data)
	{
		this.buffer = data;
	}

	// Token: 0x060005A8 RID: 1448 RVA: 0x0000A499 File Offset: 0x00008699
	public InputStream(string filename) : base(filename)
	{
	}
}
