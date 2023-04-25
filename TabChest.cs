using System;

// Token: 0x020000FC RID: 252
public class TabChest : MainTabShop
{
	// Token: 0x06000EC0 RID: 3776 RVA: 0x0000C033 File Offset: 0x0000A233
	public TabChest(string name, mVector vec, int xTab) : base(name, vec, Player.maxChest, xTab)
	{
		this.indexIconTab = 7;
		TabChest.cmdUpgrade = new iCommand(T.morong, 8, this);
	}

	// Token: 0x06000EC1 RID: 3777 RVA: 0x0011C4C4 File Offset: 0x0011A6C4
	public void initCmd()
	{
		TabChest.cmdRemove = new iCommand(T.del, 2, this);
		TabChest.cmdGetItem = new iCommand(T.cmdget, 4, this);
		TabChest.cmdGetPotion = new iCommand(T.cmdget, 11, this);
		TabChest.cmdGetAllMaterial = new iCommand(T.laytatca, 7, this);
		TabChest.cmdChucnang = new iCommand(T.cmdChucNang, 9, this);
		this.cmdMenu = new iCommand(T.select, 10, this);
		TabChest.cmdGetAllDiamond = new iCommand(T.laytatcaDa, 13, this);
	}

	// Token: 0x06000EC2 RID: 3778 RVA: 0x0011C550 File Offset: 0x0011A750
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 2:
		{
			bool flag = this.itemCur != null;
			if (flag)
			{
				string info = GameMidlet.format(T.HoiRemoveENG, new string[]
				{
					string.Empty + this.itemCur.numPotion.ToString(),
					this.itemCur.name
				});
				GameCanvas.Start_Normal_DiaLog(info, new iCommand(T.remove, 3, 1, this), true);
			}
			break;
		}
		case 3:
		{
			bool flag2 = this.itemCur != null;
			if (flag2)
			{
				GlobalService.gI().Chest(4, this.itemCur.ID, this.itemCur.typeObject, 1);
			}
			break;
		}
		case 4:
		{
			bool flag3 = this.itemCur != null;
			if (flag3)
			{
				GlobalService.gI().Chest(2, this.itemCur.ID, this.itemCur.typeObject, 1);
			}
			break;
		}
		case 5:
		{
			GameCanvas.end_Dialog();
			bool flag4 = this.itemCur != null;
			if (flag4)
			{
				bool flag5 = this.itemCur.numPotion == 1;
				if (flag5)
				{
					GlobalService.gI().Chest(2, this.itemCur.ID, this.itemCur.typeObject, 1);
				}
				else
				{
					this.input = GameCanvas.Start_Input_Dialog(T.nhapsoluong, new iCommand(T.cmdget, 6, 0, this), true, this.itemCur.namepaint);
				}
				GameCanvas.subDialog = this.input;
			}
			break;
		}
		case 6:
		{
			bool flag6 = this.itemCur == null;
			if (!flag6)
			{
				int num = 1;
				try
				{
					num = int.Parse(this.input.tfInput.getText());
					bool flag7 = num < 0;
					if (flag7)
					{
						num = 1;
					}
				}
				catch (Exception)
				{
					num = 1;
				}
				MainItem itemVec = MainItem.getItemVec(this.itemCur.typeObject, this.itemCur.ID, Player.vecChest);
				bool flag8 = itemVec != null;
				if (flag8)
				{
					bool flag9 = num > (int)itemVec.numPotion;
					if (flag9)
					{
						num = (int)itemVec.numPotion;
					}
					GameCanvas.end_Dialog();
					GlobalService.gI().Chest(2, this.itemCur.ID, this.itemCur.typeObject, num);
				}
			}
			break;
		}
		case 7:
			Player.SetMaterialToInven(7);
			break;
		case 8:
			GlobalService.gI().Chest(5, 0, 0, 0);
			break;
		case 9:
		{
			mVector mVector = new mVector();
			mVector.addElement(TabChest.cmdUpgrade);
			mVector.addElement(TabChest.cmdGetAllMaterial);
			mVector.addElement(TabChest.cmdGetAllDiamond);
			GameCanvas.menu.startAt(mVector, 2, T.menu);
			break;
		}
		case 10:
		{
			mVector menuActionItem = this.getMenuActionItem();
			bool flag10 = menuActionItem != null;
			if (flag10)
			{
				GameCanvas.menu.startAt(menuActionItem, 2, T.menu);
			}
			break;
		}
		case 11:
		{
			bool flag11 = this.itemCur != null;
			if (flag11)
			{
				bool flag12 = this.itemCur.numPotion == 1;
				if (flag12)
				{
					GlobalService.gI().Chest(2, this.itemCur.ID, this.itemCur.typeObject, 1);
				}
				else
				{
					mVector mVector2 = new mVector();
					iCommand o = new iCommand(T.allMaterial, 12, 0, this);
					mVector2.addElement(o);
					iCommand o2 = new iCommand(T.soluong, 5, 0, this);
					mVector2.addElement(o2);
					GameCanvas.Start_Normal_DiaLog_New(T.muonlayrabaonhieu + this.itemCur.namepaint, mVector2, true, this.itemCur.name);
				}
			}
			break;
		}
		case 12:
		{
			bool flag13 = this.itemCur != null;
			if (flag13)
			{
				bool flag14 = subIndex == 0;
				if (flag14)
				{
					GlobalService.gI().Chest(2, this.itemCur.ID, this.itemCur.typeObject, (int)this.itemCur.numPotion);
				}
				GameCanvas.end_Dialog();
			}
			break;
		}
		case 13:
			Player.SetDiamondToInven();
			break;
		}
	}

	// Token: 0x06000EC3 RID: 3779 RVA: 0x0011C980 File Offset: 0x0011AB80
	public override mVector getMenuActionItem()
	{
		mVector result = null;
		MainItem mainItem = (MainItem)Player.vecChest.elementAt(this.IdSelect);
		bool flag = mainItem != null;
		if (flag)
		{
			this.itemCur = mainItem;
			result = this.itemCur.getActionChest();
		}
		return result;
	}

	// Token: 0x06000EC4 RID: 3780 RVA: 0x0011C9C8 File Offset: 0x0011ABC8
	public override iCommand setCmdEndInfo()
	{
		return TabChest.cmdUpgrade;
	}

	// Token: 0x040018EC RID: 6380
	public static iCommand cmdRemove;

	// Token: 0x040018ED RID: 6381
	public static iCommand cmdGetItem;

	// Token: 0x040018EE RID: 6382
	public static iCommand cmdGetPotion;

	// Token: 0x040018EF RID: 6383
	public static iCommand cmdGetAllMaterial;

	// Token: 0x040018F0 RID: 6384
	public static iCommand cmdUpgrade;

	// Token: 0x040018F1 RID: 6385
	public static iCommand cmdChucnang;

	// Token: 0x040018F2 RID: 6386
	public static iCommand cmdGetAllDiamond;
}
