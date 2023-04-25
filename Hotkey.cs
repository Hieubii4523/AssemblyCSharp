using System;

// Token: 0x02000040 RID: 64
public class Hotkey
{
	// Token: 0x06000505 RID: 1285 RVA: 0x0000A143 File Offset: 0x00008343
	public void setPotion(MainItem item)
	{
		this.itemcur = item;
		this.skill = null;
	}

	// Token: 0x06000506 RID: 1286 RVA: 0x0007CA94 File Offset: 0x0007AC94
	public void setSkill(MainSkill skill, short IdIcon)
	{
		this.skill = skill;
		this.skill.idIcon = IdIcon;
		this.itemcur = null;
		Skill_Info skillFromID = Skill_Info.getSkillFromID(skill.ID);
		bool flag = skillFromID.typeSkill == 2;
		if (flag)
		{
			this.skill.setTypeBuff(1, 46, 0);
		}
		this.skill.lvDevil = skillFromID.LvDevilSkill;
	}

	// Token: 0x06000507 RID: 1287 RVA: 0x0007CAF8 File Offset: 0x0007ACF8
	public int getIndexDelay()
	{
		bool flag = this.skill != null;
		int result;
		if (flag)
		{
			result = (int)this.skill.indexHotKey;
		}
		else
		{
			bool flag2 = this.itemcur != null;
			if (flag2)
			{
				result = (int)this.itemcur.indexHotKey;
			}
			else
			{
				result = -1;
			}
		}
		return result;
	}

	// Token: 0x06000508 RID: 1288 RVA: 0x0007CB44 File Offset: 0x0007AD44
	public void paint(mGraphics g, int x, int y, int w)
	{
		bool flag = this.skill != null;
		if (flag)
		{
			this.skill.paint(g, x, y, this.skill.lvDevil);
		}
		else
		{
			bool flag2 = this.itemcur != null;
			if (flag2)
			{
				this.itemcur.paintHotkey(g, x, y, w, 0);
			}
		}
	}

	// Token: 0x06000509 RID: 1289 RVA: 0x0007CBA0 File Offset: 0x0007ADA0
	public sbyte getTypeHotKey()
	{
		bool flag = this.itemcur != null;
		sbyte result;
		if (flag)
		{
			result = 0;
		}
		else
		{
			bool flag2 = this.skill != null;
			if (flag2)
			{
				result = 1;
			}
			else
			{
				result = -1;
			}
		}
		return result;
	}

	// Token: 0x0600050A RID: 1290 RVA: 0x0007CBD8 File Offset: 0x0007ADD8
	public static void checkUpdatePotion(MainItem itemcheck)
	{
		for (int i = 0; i < Player.hotkeyPlayer.Length; i++)
		{
			for (int j = 0; j < Player.hotkeyPlayer[i].Length; j++)
			{
				bool flag = Player.hotkeyPlayer[i][j].itemcur != null && Player.hotkeyPlayer[i][j].itemcur.typeObject == itemcheck.typeObject && Player.hotkeyPlayer[i][j].itemcur.ID == itemcheck.ID;
				if (flag)
				{
					Player.hotkeyPlayer[i][j].itemcur = itemcheck;
				}
			}
		}
	}

	// Token: 0x04000741 RID: 1857
	public MainItem itemcur;

	// Token: 0x04000742 RID: 1858
	public MainSkill skill;
}
