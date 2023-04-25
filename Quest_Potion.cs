using System;

// Token: 0x020000D8 RID: 216
public class Quest_Potion : MainItem
{
	// Token: 0x06000C4B RID: 3147 RVA: 0x0000BBD2 File Offset: 0x00009DD2
	public Quest_Potion(sbyte typeItem, short ID, string name) : base(typeItem, ID, ID, name, 0)
	{
		this.indexSort = 2;
		this.isTrade = 1;
		this.namepaint = name;
	}

	// Token: 0x06000C4C RID: 3148 RVA: 0x0000BBF6 File Offset: 0x00009DF6
	public override void addInfo(string str, sbyte color, sbyte colorMain)
	{
		this.vecInfo.addElement(new infoShow(-1, 0, str, color, colorMain));
	}

	// Token: 0x06000C4D RID: 3149 RVA: 0x0000AB20 File Offset: 0x00008D20
	public override void paint(mGraphics g, int x, int y, int w)
	{
		base.paint(g, x, y, w);
		this.paintPotion(g, x, y, w);
	}

	// Token: 0x06000C4E RID: 3150 RVA: 0x000EB8A8 File Offset: 0x000E9AA8
	public override MainImage getImage()
	{
		MainImage mainImage = null;
		MainImage result;
		try
		{
			mainImage = ObjectData.getImageAll(this.idIcon, ObjectData.hashImageQuestPotion, 6000);
			result = mainImage;
		}
		catch (Exception)
		{
			result = mainImage;
		}
		return result;
	}
}
