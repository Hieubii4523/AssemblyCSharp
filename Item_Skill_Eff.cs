using System;

// Token: 0x02000065 RID: 101
public class Item_Skill_Eff : MainItem
{
	// Token: 0x0600065A RID: 1626 RVA: 0x0008CD08 File Offset: 0x0008AF08
	public Item_Skill_Eff(short idIcon, short id, int hardcode_Index)
	{
		this.indexHotKey = (short)((int)id + hardcode_Index);
		this.idIcon = idIcon;
		this.ID = id;
		this.typeObject = 9;
		bool flag = hardcode_Index == 1500;
		if (flag)
		{
			this.colorName = 6;
		}
		else
		{
			this.colorName = 0;
		}
	}

	// Token: 0x0600065B RID: 1627 RVA: 0x0008CD60 File Offset: 0x0008AF60
	public void setColorKickAn()
	{
		bool flag = this.ID == 9 || this.ID == 10;
		if (flag)
		{
			this.colorName = 1;
		}
		else
		{
			this.colorName = 6;
		}
	}

	// Token: 0x0600065C RID: 1628 RVA: 0x0008CDA0 File Offset: 0x0008AFA0
	public override void paintHotkey(mGraphics g, int x, int y, int w, int ylech)
	{
		MainImage image = this.getImage();
		bool flag = image != null && image.img != null;
		if (flag)
		{
			g.drawImage(image.img, x, y, 3);
		}
		else
		{
			AvMain.imgLoadImage.drawFrame(GameCanvas.gameTick % AvMain.imgLoadImage.nFrame, x, y, 0, 3, g);
		}
	}

	// Token: 0x0600065D RID: 1629 RVA: 0x0008CE00 File Offset: 0x0008B000
	public override MainImage getImage()
	{
		return ObjectData.getImageAll(this.idIcon, ObjectData.hashImageSkillSmall, 4500);
	}
}
