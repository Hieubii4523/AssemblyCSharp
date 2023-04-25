using System;

// Token: 0x02000110 RID: 272
public class Uniform
{
	// Token: 0x06000FBC RID: 4028 RVA: 0x0012F528 File Offset: 0x0012D728
	public void setUniform(sbyte index)
	{
		this.index = index;
		this.mIdUniform = new short[8];
		for (int i = 0; i < this.mIdUniform.Length; i++)
		{
			MainItem mainItem = (MainItem)GameScreen.player.hashEquip.get(string.Empty + i.ToString());
			bool flag = mainItem != null;
			if (flag)
			{
				this.mIdUniform[i] = mainItem.ID;
			}
			else
			{
				this.mIdUniform[i] = -1;
			}
		}
		for (int j = 0; j < Player.vecUniform.size(); j++)
		{
			Uniform uniform = (Uniform)Player.vecUniform.elementAt(j);
			uniform.isSet = 0;
		}
		this.isSet = 1;
		Interface_Game.addInfoPlayerNormal(T.mColorUniform[(int)index] + T.settingEquipOk, mFont.tahoma_7_yellow);
	}

	// Token: 0x06000FBD RID: 4029 RVA: 0x0012F60C File Offset: 0x0012D80C
	public void getUniform()
	{
		for (int i = 0; i < this.mIdUniform.Length; i++)
		{
			bool flag = this.mIdUniform[i] < 0;
			if (!flag)
			{
				bool flag2 = false;
				for (int j = 0; j < Player.vecInventory.size(); j++)
				{
					bool flag3 = flag2;
					if (flag3)
					{
						break;
					}
					MainItem mainItem = (MainItem)Player.vecInventory.elementAt(j);
					bool flag4 = mainItem.typeObject == 3 && mainItem.ID == this.mIdUniform[i];
					if (flag4)
					{
						GlobalService.gI().Use_Item(this.mIdUniform[i], 3);
						flag2 = true;
					}
				}
			}
		}
		this.isSet = 1;
		Interface_Game.addInfoPlayerNormal(T.mColorUniform[(int)this.index] + T.changeEquipOk, mFont.tahoma_7_yellow);
	}

	// Token: 0x06000FBE RID: 4030 RVA: 0x0012F6EC File Offset: 0x0012D8EC
	public static void checkIndexItem(bool isRemove)
	{
		bool flag = Player.vecUniform.size() == 0 && !isRemove;
		if (!flag)
		{
			for (int i = 0; i < Player.vecInventory.size(); i++)
			{
				MainItem mainItem = (MainItem)Player.vecInventory.elementAt(i);
				mainItem.indexUniform = -1;
				bool flag2 = isRemove || mainItem.typeObject != 3;
				if (!flag2)
				{
					for (int j = 0; j < Player.vecUniform.size(); j++)
					{
						Uniform uniform = (Uniform)Player.vecUniform.elementAt(j);
						for (int k = 0; k < uniform.mIdUniform.Length; k++)
						{
							bool flag3 = mainItem.ID == uniform.mIdUniform[k];
							if (flag3)
							{
								bool flag4 = mainItem.indexUniform == -1;
								if (flag4)
								{
									mainItem.indexUniform = uniform.index;
								}
								else
								{
									mainItem.indexUniform = 2;
								}
							}
						}
					}
				}
			}
			for (int l = 0; l < 8; l++)
			{
				MainItem mainItem2 = (MainItem)GameScreen.player.hashEquip.get(string.Empty + l.ToString());
				bool flag5 = mainItem2 == null;
				if (!flag5)
				{
					mainItem2.indexUniform = -1;
					bool flag6 = isRemove || mainItem2.typeObject != 3;
					if (!flag6)
					{
						for (int m = 0; m < Player.vecUniform.size(); m++)
						{
							Uniform uniform2 = (Uniform)Player.vecUniform.elementAt(m);
							for (int n = 0; n < uniform2.mIdUniform.Length; n++)
							{
								bool flag7 = mainItem2.ID == uniform2.mIdUniform[n];
								if (flag7)
								{
									bool flag8 = mainItem2.indexUniform == -1;
									if (flag8)
									{
										mainItem2.indexUniform = uniform2.index;
									}
									else
									{
										mainItem2.indexUniform = 2;
									}
								}
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x04001A33 RID: 6707
	public sbyte index = -1;

	// Token: 0x04001A34 RID: 6708
	public sbyte isSet;

	// Token: 0x04001A35 RID: 6709
	public short[] mIdUniform;
}
