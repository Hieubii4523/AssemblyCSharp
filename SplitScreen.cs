using System;

// Token: 0x020000F3 RID: 243
public class SplitScreen : ScreenUpgrade
{
	// Token: 0x06000E63 RID: 3683 RVA: 0x0000BF37 File Offset: 0x0000A137
	public SplitScreen(sbyte typeRebuild, int size) : base(typeRebuild, size)
	{
	}

	// Token: 0x06000E64 RID: 3684 RVA: 0x00114240 File Offset: 0x00112440
	public override void setStart(sbyte typeRebuild, int size)
	{
		this.typeRebuild = typeRebuild;
		int num = this.x + this.wInven + (this.w - this.lech * 3 - this.wInven) / 6 + 4;
		int num2 = this.y + this.h / 2 - this.wItem / 2;
		this.potionBua = null;
		this.isPaintrectPlus = false;
		bool flag = typeRebuild == 21;
		if (flag)
		{
			this.posUp = mSystem.new_M_Int(1, 2);
			this.posUp[0][0] = num + this.wItem * 3 / 2;
			this.posUp[0][1] = num2 + this.wItem * 2 / 3;
		}
		else
		{
			this.posUp = mSystem.new_M_Int(2, 2);
			this.posUp[0][0] = num;
			this.posUp[0][1] = num2;
			this.posUp[1][0] = num + (this.w - this.lech * 3 - this.wInven) / 6 * 4;
			this.posUp[1][1] = num2;
			bool flag2 = typeRebuild == 19;
			if (flag2)
			{
				this.posUp[0][1] = num2 + this.wItem - 5;
			}
		}
		this.maxNumItemW = this.wInven / this.wItem;
		int limX = ((Player.maxInventory - 1) / this.maxNumItemW + 1) * this.wItem - this.hInven;
		this.list = new ListNew(this.xInven, this.yInven, this.wInven, this.hInven, 0, 0, limX, true);
		this.cmdBovao = new iCommand(T.bovao, 0, this);
		this.cmdUpgrade = new iCommand(T.split, 1, this);
		this.cmdMenu = new iCommand(T.menu, 10, this);
		this.nameScreen = T.SplitItem;
		bool flag3 = typeRebuild == 1;
		if (flag3)
		{
			this.typeShowItem = 2;
			this.cmdUpgrade = new iCommand(T.kham, 2, this);
			this.nameScreen = T.tabkhamda;
		}
		else
		{
			bool flag4 = typeRebuild == 21;
			if (flag4)
			{
				this.typeShowItem = 1;
				this.cmdUpgrade = new iCommand(T.kham, 22, this);
				this.nameScreen = T.tabkhamda;
			}
			else
			{
				bool flag5 = typeRebuild == 2;
				if (flag5)
				{
					this.typeShowItem = 4;
					this.cmdUpgrade = new iCommand(T.duclo, 3, this);
					this.nameScreen = T.tabdutlo;
				}
				else
				{
					bool flag6 = typeRebuild == 3;
					if (flag6)
					{
						this.typeShowItem = 2;
						this.cmdUpgrade = new iCommand(T.laydara, 4, this);
						this.nameScreen = T.tablayda;
					}
					else
					{
						bool flag7 = typeRebuild == 4;
						if (flag7)
						{
							this.typeShowItem = 1;
							this.cmdUpgrade = new iCommand(T.cmdghepda, 5, this);
							this.cmdBoVaoAll = new iCommand(T.allMaterial, 8, this);
							this.nameScreen = T.tabupgradeDa;
						}
						else
						{
							bool flag8 = typeRebuild == 7;
							if (flag8)
							{
								this.typeShowItem = 3;
								this.cmdUpgrade = new iCommand(T.cmdChuyenHoa, 7, this);
								this.nameScreen = T.tabChuyenHoa;
							}
							else
							{
								bool flag9 = typeRebuild == 8;
								if (flag9)
								{
									this.cmdUpgrade = new iCommand(T.Upgrade, 12, this);
									this.nameScreen = T.tabDevilUpgrade;
								}
								else
								{
									bool flag10 = typeRebuild == 10;
									if (flag10)
									{
										this.typeShowItem = 2;
										this.cmdUpgrade = new iCommand(T.hoanmy, 13, this);
										this.nameScreen = T.tabHoanMy;
									}
									else
									{
										bool flag11 = typeRebuild == 11;
										if (flag11)
										{
											this.typeShowItem = 2;
											this.cmdUpgrade = new iCommand(T.kichAn, 14, this);
											this.nameScreen = T.taKichAn;
										}
										else
										{
											bool flag12 = typeRebuild == 12;
											if (flag12)
											{
												this.typeShowItem = 3;
												this.cmdUpgrade = new iCommand(T.dapCheTac, 15, this);
												this.nameScreen = T.tabCongCheTac;
												this.posUp = mSystem.new_M_Int(1, 2);
												this.posUp[0][0] = this.x + this.wInven + (this.w - this.lech * 3 - this.wInven) / 2;
												this.posUp[0][1] = num2;
											}
											else
											{
												bool flag13 = typeRebuild == 13;
												if (flag13)
												{
													this.typeShowItem = 1;
													this.cmdUpgrade = new iCommand(T.dapCheTac, 18, this);
													this.nameScreen = T.taDaSieuCap;
												}
												else
												{
													bool flag14 = typeRebuild == 14;
													if (flag14)
													{
														this.cmdUpgrade = new iCommand(T.ghepDo, 19, this);
														this.nameScreen = T.tabGhepDo;
													}
													else
													{
														bool flag15 = typeRebuild == 15;
														if (flag15)
														{
															this.typeShowItem = 5;
															this.cmdUpgrade = new iCommand(T.duclo, 20, this);
															this.nameScreen = T.tabdutlo;
														}
														else
														{
															bool flag16 = typeRebuild == 19;
															if (flag16)
															{
																this.typeShowItem = 5;
																this.cmdUpgrade = new iCommand(T.duclo, 3, this);
																this.nameScreen = T.tabdutlo;
																this.isPaintrectPlus = true;
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		AvMain.setPosCMD(this.cmdMenu, 2);
		bool flag17 = typeRebuild != 19 && typeRebuild != 21;
		if (flag17)
		{
			this.vecCmd.addElement(this.cmdMenu);
		}
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.cmdUpgrade.setPos(this.x + this.wInven + (this.w - this.lech * 3 - this.wInven) / 2 + this.wItem * 3 / 4, this.y + this.h - iCommand.hButtonCmdNor / 2 - 10, null, this.cmdUpgrade.caption);
			this.vecCmd.addElement(this.cmdUpgrade);
		}
		ScreenUpgrade.mItemUpgrade = new MainItem[this.posUp.Length];
		bool flag18 = !GameCanvas.isTouch;
		if (flag18)
		{
			AvMain.setPosCMD(this.cmdUpgrade, 1);
			this.cmdClose.caption = T.close + " " + T.hientai;
			bool flag19 = typeRebuild != 19 && typeRebuild != 21;
			if (flag19)
			{
				this.right = this.cmdMenu;
			}
			this.left = this.cmdUpgrade;
		}
		bool flag20 = GameCanvas.isTouchNoOrPC();
		if (flag20)
		{
			this.backCMD = this.cmdClose;
			this.okCMD = this.cmdUpgrade;
		}
		bool flag21 = this.IdSelect >= 0 && typeRebuild != 21;
		if (flag21)
		{
			this.getItemCurNew();
		}
	}

	// Token: 0x06000E65 RID: 3685 RVA: 0x001148B8 File Offset: 0x00112AB8
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case -1:
		{
			bool flag = this.lastScreen != null;
			if (flag)
			{
				this.lastScreen.Show(this.lastScreen.lastScreen);
			}
			else
			{
				GameCanvas.gameScr.Show();
			}
			break;
		}
		case 0:
		{
			bool flag2 = this.itemCur == null;
			if (!flag2)
			{
				bool flag3 = this.typeRebuild == 21;
				if (flag3)
				{
					ScreenUpgrade.mItemUpgrade[0] = this.itemCur;
				}
				else
				{
					bool flag4 = this.typeRebuild == 0;
					if (flag4)
					{
						GlobalService.gI().Split_Item(0, 0, this.itemCur.ID, this.itemCur.typeObject, 1);
					}
					else
					{
						bool flag5 = this.typeRebuild == 4;
						if (flag5)
						{
							bool flag6 = this.cmdBoVaoAll == null;
							if (flag6)
							{
								this.cmdBoVaoAll = new iCommand(T.allMaterial, 8, this);
							}
							mVector mVector = new mVector();
							mVector.addElement(this.cmdBoVaoAll);
							mVector.addElement(new iCommand(T.soluong, 9, this));
							GameCanvas.Start_Normal_DiaLog(T.nhapsoluong, mVector, true);
						}
						else
						{
							bool flag7 = this.typeRebuild == 7;
							if (flag7)
							{
								GlobalService.gI().ChuyenHoa(1, this.itemCur.ID, 0);
							}
							else
							{
								bool flag8 = this.typeRebuild == 8;
								if (flag8)
								{
									GlobalService.gI().Devil_Upgrade(14, this.itemCur.ID, this.itemCur.typeObject, 1);
								}
								else
								{
									bool flag9 = this.typeRebuild == 13;
									if (flag9)
									{
										mVector mVector2 = new mVector();
										mVector2.addElement(new iCommand(T.daSieuCap, 17, 28, this));
										mVector2.addElement(new iCommand(T.daNguyenLieu, 17, 29, this));
										GameCanvas.menuCur.startAt(mVector2, 2, T.taDaSieuCap);
									}
									else
									{
										bool flag10 = this.typeRebuild == 2;
										if (flag10)
										{
											bool flag11 = this.itemCur.typeObject == 3;
											if (flag11)
											{
												GlobalService.gI().rebuild_Item(this.typeRebuild, 1, this.itemCur.ID, this.itemCur.typeObject, (short)subIndex);
											}
											else
											{
												bool flag12 = this.itemCur.typeObject == 4;
												if (flag12)
												{
													bool flag13 = this.potionBua != null && this.itemCur.ID == this.potionBua.ID;
													if (flag13)
													{
														this.potionBua = null;
													}
													else
													{
														bool flag14 = this.itemCur.ID == 323 || this.itemCur.ID == 339;
														if (flag14)
														{
															this.potionBua = this.itemCur;
														}
													}
												}
											}
										}
										else
										{
											bool flag15 = this.typeRebuild == 19;
											if (flag15)
											{
												bool flag16 = this.itemCur.typeObject == 3;
												if (flag16)
												{
													GlobalService.gI().rebuild_Item(this.typeRebuild, 1, this.itemCur.ID, this.itemCur.typeObject, (short)subIndex);
												}
												else
												{
													bool flag17 = this.itemCur.typeObject == 4;
													if (flag17)
													{
														bool flag18 = this.potionBua != null && this.itemCur.ID == this.potionBua.ID;
														if (flag18)
														{
															this.potionBua = null;
														}
														else
														{
															bool flag19 = this.itemCur.ID == 457;
															if (flag19)
															{
																this.potionBua = this.itemCur;
															}
														}
													}
												}
											}
											else
											{
												bool flag20 = this.typeRebuild == 15;
												if (flag20)
												{
													bool flag21 = this.itemCur.typeObject == 3;
													if (flag21)
													{
														GlobalService.gI().rebuild_Item(this.typeRebuild, 1, this.itemCur.ID, this.itemCur.typeObject, (short)subIndex);
													}
													else
													{
														bool flag22 = this.itemCur.typeObject == -8;
														if (flag22)
														{
															bool flag23 = this.potionBua != null && this.itemCur.ID == this.potionBua.ID;
															if (flag23)
															{
																this.potionBua = null;
															}
															else
															{
																this.potionBua = this.itemCur;
															}
														}
													}
												}
												else
												{
													GlobalService.gI().rebuild_Item(this.typeRebuild, 1, this.itemCur.ID, this.itemCur.typeObject, (short)subIndex);
													bool flag24 = (this.typeRebuild == 2 || this.typeRebuild == 3 || this.typeRebuild == 4 || this.typeRebuild == 15) && ScreenUpgrade.mItemUpgrade[1] != null;
													if (flag24)
													{
														ScreenUpgrade.mItemUpgrade[1] = null;
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			break;
		}
		case 1:
		{
			bool flag25 = ScreenUpgrade.mItemUpgrade[0] == null;
			if (flag25)
			{
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.nullItemUpgrade);
			}
			else
			{
				GlobalService.gI().Split_Item(0, 1, ScreenUpgrade.mItemUpgrade[0].ID, ScreenUpgrade.mItemUpgrade[0].typeObject, 1);
			}
			break;
		}
		case 2:
		{
			bool flag26 = ScreenUpgrade.mItemUpgrade[0] == null;
			if (flag26)
			{
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.nullItem);
			}
			else
			{
				bool flag27 = ScreenUpgrade.mItemUpgrade[1] == null;
				if (flag27)
				{
					GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.nulldakham);
				}
				else
				{
					GlobalService.gI().rebuild_Item(this.typeRebuild, 4, 0, 0, 0);
				}
			}
			break;
		}
		case 3:
		{
			bool flag28 = ScreenUpgrade.mItemUpgrade[0] == null;
			if (flag28)
			{
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.nullItem);
			}
			else
			{
				bool flag29 = ScreenUpgrade.mItemUpgrade[1] != null;
				if (flag29)
				{
					ScreenUpgrade.mItemUpgrade[1] = null;
				}
				bool flag30 = this.potionBua != null;
				if (flag30)
				{
					bool flag31 = this.potionBua.ID == 339;
					if (flag31)
					{
						GlobalService.gI().rebuild_Item(this.typeRebuild, 33, ScreenUpgrade.mItemUpgrade[0].ID, ScreenUpgrade.mItemUpgrade[0].typeObject, 1);
					}
					else
					{
						bool flag32 = this.potionBua.ID == 323;
						if (flag32)
						{
							GlobalService.gI().rebuild_Item(this.typeRebuild, 34, ScreenUpgrade.mItemUpgrade[0].ID, ScreenUpgrade.mItemUpgrade[0].typeObject, 1);
						}
						else
						{
							bool flag33 = this.typeRebuild == 19;
							if (flag33)
							{
								mSystem.outz(" potionBua id = " + this.potionBua.ID.ToString());
								GlobalService.gI().rebuild_Item(this.typeRebuild, 7, ScreenUpgrade.mItemUpgrade[0].ID, ScreenUpgrade.mItemUpgrade[0].typeObject, 1, this.potionBua.ID);
							}
						}
					}
				}
				else
				{
					GlobalService.gI().rebuild_Item(this.typeRebuild, 7, ScreenUpgrade.mItemUpgrade[0].ID, ScreenUpgrade.mItemUpgrade[0].typeObject, 1);
				}
			}
			break;
		}
		case 4:
		{
			bool flag34 = ScreenUpgrade.mItemUpgrade[0] == null;
			if (flag34)
			{
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.nullItem);
			}
			else
			{
				bool flag35 = ScreenUpgrade.mItemUpgrade[1] != null;
				if (flag35)
				{
					ScreenUpgrade.mItemUpgrade[1] = null;
				}
				GlobalService.gI().rebuild_Item(this.typeRebuild, 6, ScreenUpgrade.mItemUpgrade[0].ID, ScreenUpgrade.mItemUpgrade[0].typeObject, 1);
			}
			break;
		}
		case 5:
		{
			bool flag36 = ScreenUpgrade.mItemUpgrade[0] == null;
			if (flag36)
			{
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.nullItem);
			}
			else
			{
				bool flag37 = ScreenUpgrade.mItemUpgrade[1] != null;
				if (flag37)
				{
					ScreenUpgrade.mItemUpgrade[1] = null;
				}
				GlobalService.gI().rebuild_Item(this.typeRebuild, 5, ScreenUpgrade.mItemUpgrade[0].ID, ScreenUpgrade.mItemUpgrade[0].typeObject, ScreenUpgrade.mItemUpgrade[0].numPotion);
			}
			break;
		}
		case 6:
		{
			int num = 1;
			try
			{
				num = int.Parse(this.input.tfInput.getText());
				bool flag38 = num < 0;
				if (flag38)
				{
					num = 1;
				}
			}
			catch (Exception)
			{
				num = 1;
			}
			this.sendUpgradeDa(num);
			GameCanvas.end_Dialog();
			break;
		}
		case 7:
		{
			bool flag39 = ScreenUpgrade.mItemUpgrade[0] != null && ScreenUpgrade.mItemUpgrade[1] != null;
			if (flag39)
			{
				GlobalService.gI().ChuyenHoa(2, ScreenUpgrade.mItemUpgrade[0].ID, ScreenUpgrade.mItemUpgrade[1].ID);
			}
			break;
		}
		case 8:
		{
			bool flag40 = this.itemCur != null;
			if (flag40)
			{
				this.sendUpgradeDa((int)this.itemCur.numPotion);
			}
			GameCanvas.end_Dialog();
			break;
		}
		case 9:
			GameCanvas.end_Dialog();
			this.input = GameCanvas.Start_Input_Dialog(T.nhapsoluong, new iCommand(T.strconfirm, 6, 0, this), true, T.tabupgradeDa);
			GameCanvas.subDialog = this.input;
			break;
		case 10:
			this.getMenu();
			break;
		case 11:
			GlobalService.gI().Upgrade_Item((sbyte)subIndex, 0, 0);
			break;
		case 12:
		{
			bool flag41 = ScreenUpgrade.mItemUpgrade[0] != null && ScreenUpgrade.mItemUpgrade[1] != null;
			if (flag41)
			{
				GlobalService.gI().Devil_Upgrade(17, ScreenUpgrade.mItemUpgrade[0].ID, ScreenUpgrade.mItemUpgrade[0].typeObject, ScreenUpgrade.mItemUpgrade[0].numPotion);
			}
			break;
		}
		case 13:
		{
			bool flag42 = ScreenUpgrade.mItemUpgrade[0] == null;
			if (flag42)
			{
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.nullItem);
			}
			else
			{
				bool flag43 = ScreenUpgrade.mItemUpgrade[1] == null;
				if (flag43)
				{
					GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.nullHaiThach);
				}
				else
				{
					GlobalService.gI().rebuild_Item(this.typeRebuild, 20, 0, 0, 0);
				}
			}
			break;
		}
		case 14:
		{
			bool flag44 = ScreenUpgrade.mItemUpgrade[0] == null;
			if (flag44)
			{
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.nullItem);
			}
			else
			{
				bool flag45 = ScreenUpgrade.mItemUpgrade[1] == null;
				if (flag45)
				{
					GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.nullHaiThach);
				}
				else
				{
					GlobalService.gI().rebuild_Item(this.typeRebuild, 22, 0, 0, 0);
				}
			}
			break;
		}
		case 15:
		{
			bool flag46 = ScreenUpgrade.mItemUpgrade[0] == null;
			if (flag46)
			{
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.nullItem);
			}
			else
			{
				GlobalService.gI().rebuild_Item(this.typeRebuild, 24, 0, 0, 0);
			}
			break;
		}
		case 16:
		{
			bool flag47 = ScreenUpgrade.mItemUpgrade[0] == null;
			if (flag47)
			{
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.nullItem);
			}
			else
			{
				GlobalService.gI().rebuild_Item(this.typeRebuild, 26, 0, 0, 0);
			}
			break;
		}
		case 17:
		{
			bool flag48 = this.itemCur != null;
			if (flag48)
			{
				GlobalService.gI().rebuild_Item(this.typeRebuild, (sbyte)subIndex, this.itemCur.ID, this.itemCur.typeObject, 0);
			}
			break;
		}
		case 18:
		{
			bool flag49 = ScreenUpgrade.mItemUpgrade[0] == null || ScreenUpgrade.mItemUpgrade[1] == null;
			if (flag49)
			{
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.nullDaSieuCap);
			}
			else
			{
				GlobalService.gI().rebuild_Item(this.typeRebuild, 26, 0, 0, 0);
			}
			break;
		}
		case 19:
		{
			bool flag50 = ScreenUpgrade.mItemUpgrade[0] == null;
			if (flag50)
			{
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.nullDaSieuCap);
			}
			else
			{
				bool flag51 = ScreenUpgrade.mItemUpgrade[1] != null;
				if (flag51)
				{
					ScreenUpgrade.mItemUpgrade[1].isRemove = true;
				}
				GlobalService.gI().rebuild_Item(this.typeRebuild, 31, 0, 0, 0);
			}
			break;
		}
		case 20:
		{
			bool flag52 = ScreenUpgrade.mItemUpgrade[0] == null;
			if (flag52)
			{
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.nullItem);
			}
			else
			{
				bool flag53 = ScreenUpgrade.mItemUpgrade[1] != null;
				if (flag53)
				{
					ScreenUpgrade.mItemUpgrade[1] = null;
				}
				bool flag54 = this.potionBua != null;
				if (flag54)
				{
					GlobalService.gI().rebuild_Item_DIAL(this.typeRebuild, 7, ScreenUpgrade.mItemUpgrade[0].ID, ScreenUpgrade.mItemUpgrade[0].typeObject, 1, this.potionBua.ID);
				}
				else
				{
					GlobalService.gI().rebuild_Item_DIAL(this.typeRebuild, 7, ScreenUpgrade.mItemUpgrade[0].ID, ScreenUpgrade.mItemUpgrade[0].typeObject, 1, -1);
				}
			}
			break;
		}
		case 22:
		{
			bool flag55 = ScreenUpgrade.mItemUpgrade[0] == null;
			if (flag55)
			{
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.nullItem);
			}
			else
			{
				bool flag56 = this.typeRebuild == 21;
				if (flag56)
				{
					GlobalService.gI().Hanh_Trinh(2, ScreenUpgrade.mItemUpgrade[0].ID);
					mSound.playSound(26, mSound.volumeSound);
					base.createEff(53, 0, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2);
				}
			}
			break;
		}
		case 23:
		{
			bool flag57 = ScreenUpgrade.mItemUpgrade[0] != null && this.typeRebuild == 21;
			if (flag57)
			{
				GlobalService.gI().Hanh_Trinh(3, ScreenUpgrade.mItemUpgrade[0].ID);
			}
			break;
		}
		}
	}

	// Token: 0x06000E66 RID: 3686 RVA: 0x00115624 File Offset: 0x00113824
	private void getMenu()
	{
		mVector mVector = new mVector();
		bool flag = !GameCanvas.isTouch;
		if (flag)
		{
			mVector.addElement(this.cmdClose);
		}
		bool flag2 = this.typeRebuild != 1;
		if (flag2)
		{
			iCommand o = new iCommand(T.tabkhamda, 11, 9, this);
			mVector.addElement(o);
		}
		bool flag3 = this.typeRebuild != 4;
		if (flag3)
		{
			iCommand o2 = new iCommand(T.tabupgradeDa, 11, 12, this);
			mVector.addElement(o2);
		}
		bool flag4 = this.typeRebuild != 2;
		if (flag4)
		{
			iCommand o3 = new iCommand(T.tabdutlo, 11, 10, this);
			mVector.addElement(o3);
		}
		bool flag5 = this.typeRebuild != 19;
		if (flag5)
		{
			iCommand o4 = new iCommand(T.tabdutlo, 11, 10, this);
			mVector.addElement(o4);
		}
		bool flag6 = this.typeRebuild != 3;
		if (flag6)
		{
			iCommand o5 = new iCommand(T.tablayda, 11, 13, this);
			mVector.addElement(o5);
		}
		bool flag7 = this.typeRebuild != 6;
		if (flag7)
		{
			iCommand o6 = new iCommand(T.shopDa, 11, 11, this);
			mVector.addElement(o6);
		}
		bool flag8 = this.typeRebuild != 15;
		if (flag8)
		{
			iCommand o7 = new iCommand(T.tabdutlo, 11, 10, this);
			mVector.addElement(o7);
		}
		GameCanvas.menuCur.startAt(mVector, 2, T.menu);
	}

	// Token: 0x06000E67 RID: 3687 RVA: 0x001157A8 File Offset: 0x001139A8
	private void sendUpgradeDa(int t)
	{
		MainItem itemVec = MainItem.getItemVec(this.itemCur.typeObject, this.itemCur.ID, this.vecInventory);
		bool flag = itemVec != null;
		if (flag)
		{
			bool flag2 = t > (int)itemVec.numPotion;
			if (flag2)
			{
				t = (int)itemVec.numPotion;
			}
			bool flag3 = this.itemCur != null;
			if (flag3)
			{
				GlobalService.gI().rebuild_Item(this.typeRebuild, 1, this.itemCur.ID, this.itemCur.typeObject, (short)t);
			}
		}
	}

	// Token: 0x06000E68 RID: 3688 RVA: 0x00115834 File Offset: 0x00113A34
	public override void paintTiLe(mGraphics g)
	{
		bool flag = this.typeRebuild == 4;
		if (flag)
		{
			bool flag2 = ScreenUpgrade.mItemUpgrade[0] != null;
			if (flag2)
			{
				int num = (int)((ScreenUpgrade.mItemUpgrade[0].ID - 44) % 6);
				bool flag3 = ScreenUpgrade.mItemUpgrade[0].ID >= 221;
				if (flag3)
				{
					num = (int)((ScreenUpgrade.mItemUpgrade[0].ID - 221) % 6);
				}
				bool flag4 = num + 1 < ScreenUpgrade.mTileGhepĐa.Length;
				if (flag4)
				{
					mFont.tahoma_7b_black.drawString(g, T.tile + ScreenUpgrade.mTileGhepĐa[num + 1].ToString() + "%", this.xTiLe, this.yInven, 0);
				}
			}
		}
		else
		{
			bool flag5 = this.typeRebuild == 7;
			if (flag5)
			{
				bool flag6 = this.Step == 0;
				if (flag6)
				{
					bool flag7 = AvMain.imgJoin == null;
					if (flag7)
					{
						AvMain.imgJoin = mImage.createImage("/interface/muiten.png");
					}
					else
					{
						g.drawRegion(AvMain.imgJoin, 20, 0, 33, 14, 0, (float)(this.x + this.wInven + (this.w - this.wInven) / 2 - 2), (float)(this.posUp[0][1] + this.wItem), 33);
					}
				}
			}
			else
			{
				bool flag8 = this.typeRebuild == 8;
				if (flag8)
				{
					bool flag9 = ScreenUpgrade.mItemUpgrade[0] != null;
					if (flag9)
					{
						mFont.tahoma_7b_black.drawString(g, T.tile + this.tile.ToString() + "%", this.xTiLe, this.yInven, 0);
					}
				}
				else
				{
					bool flag10 = this.typeRebuild == 8;
					if (flag10)
					{
						bool flag11 = ScreenUpgrade.mItemUpgrade[0] != null;
						if (flag11)
						{
							mFont.tahoma_7b_black.drawString(g, T.tile + this.tile.ToString() + "%", this.xTiLe, this.yInven, 0);
						}
					}
					else
					{
						bool flag12 = this.typeRebuild == 11 || this.typeRebuild == 10;
						if (flag12)
						{
							bool flag13 = ScreenUpgrade.mItemUpgrade[1] != null;
							if (flag13)
							{
								string str = "< 5";
								bool flag14 = ScreenUpgrade.mItemUpgrade[1].ID == 226;
								if (flag14)
								{
									str = "25";
								}
								mFont.tahoma_7b_black.drawString(g, T.tile + str + "%", this.xTiLe, this.yInven, 0);
								bool flag15 = ScreenUpgrade.mItemUpgrade[1].ID >= 221 && ScreenUpgrade.mItemUpgrade[1].ID <= 226;
								if (flag15)
								{
									mFont.tahoma_7b_black.drawString(g, T.truCheTac + T.mTiLeKichAn[(int)(ScreenUpgrade.mItemUpgrade[1].ID - 221)], this.xTiLe, this.yInven + GameCanvas.hText, 0);
								}
							}
						}
						else
						{
							bool flag16 = this.typeRebuild == 13 && ScreenUpgrade.mItemUpgrade[0] != null && ScreenUpgrade.mItemUpgrade[1] != null;
							if (flag16)
							{
								mFont.tahoma_7b_black.drawString(g, T.tile + this.tile.ToString() + "%", this.xTiLe, this.yInven, 0);
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x06000E69 RID: 3689 RVA: 0x00115BA4 File Offset: 0x00113DA4
	public override void paintRectPlus(mGraphics g)
	{
		bool flag = this.typeRebuild == 19;
		if (flag)
		{
			AvMain.paintRect(g, this.posUp[0][0], this.posUp[0][1] - 2 * this.wItem + 5, this.wItem, this.wItem, 1, 3);
			bool flag2 = this.potionBua != null;
			if (flag2)
			{
				this.potionBua.paintAllItem_Num1(g, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2 - 2 * this.wItem + 5, this.wItem, 0, this.potionBua.colorName, 1);
			}
		}
		else
		{
			bool flag3 = this.isPaintrectPlus;
			if (flag3)
			{
				AvMain.paintRect(g, this.posUp[0][0], this.posUp[0][1] - this.wItem - 3, this.wItem, this.wItem, 1, 3);
				bool flag4 = this.potionBua != null;
				if (flag4)
				{
					this.potionBua.paintAllItem_Num1(g, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2 - this.wItem - 3, this.wItem, 0, this.potionBua.colorName, 1);
				}
			}
		}
	}

	// Token: 0x06000E6A RID: 3690 RVA: 0x00115D00 File Offset: 0x00113F00
	public override void paintIconUpgrade(mGraphics g, int x, int y, MainItem item)
	{
		bool flag = ScreenUpgrade.mItemUpgrade[0] != null && ScreenUpgrade.mItemUpgrade[0].ID == item.ID && ScreenUpgrade.mItemUpgrade[0].typeObject == item.typeObject;
		if (flag)
		{
			g.drawImage(AvMain.imgcheck, x, y - this.wItem / 2 + 2, mGraphics.BOTTOM | mGraphics.LEFT);
		}
	}

	// Token: 0x06000E6B RID: 3691 RVA: 0x000734DC File Offset: 0x000716DC
	public override bool isGetItemUpgrade(short Id, sbyte cat)
	{
		return false;
	}

	// Token: 0x06000E6C RID: 3692 RVA: 0x0000BF67 File Offset: 0x0000A167
	public override void updateNewUpgrade()
	{
		this.isShowInfo = false;
		this.getItemCurNew();
	}

	// Token: 0x06000E6D RID: 3693 RVA: 0x00115D70 File Offset: 0x00113F70
	public override mVector getMenuActionItem()
	{
		mVector result = null;
		MainItem mainItem = (MainItem)this.vecInventory.elementAt(this.IdSelect);
		bool flag = mainItem != null;
		if (flag)
		{
			this.itemCur = mainItem;
			this.cmdBovao.caption = T.bovao;
			this.cmdBovao.subIndex = 1;
			bool flag2 = this.isGetItemUpgrade(this.itemCur.ID, this.itemCur.typeObject);
			if (flag2)
			{
				this.cmdBovao.caption = T.layra;
				this.cmdBovao.subIndex = 0;
			}
		}
		bool flag3 = this.itemCur != null;
		if (flag3)
		{
			result = this.itemCur.getActionSplit();
		}
		return result;
	}

	// Token: 0x06000E6E RID: 3694 RVA: 0x00115E28 File Offset: 0x00114028
	public override void setStep()
	{
		bool flag = this.typeRebuild == 0;
		if (flag)
		{
			this.updateSplit();
		}
		else
		{
			bool flag2 = this.typeRebuild == 1 || this.typeRebuild == 10 || this.typeRebuild == 11 || this.typeRebuild == 13 || this.typeRebuild == 8 || this.typeRebuild == 21;
			if (flag2)
			{
				base.updateKHAM();
			}
			else
			{
				bool flag3 = this.typeRebuild == 2 || this.typeRebuild == 19 || this.typeRebuild == 3 || this.typeRebuild == 4 || this.typeRebuild == 7 || this.typeRebuild == 14 || this.typeRebuild == 15;
				if (flag3)
				{
					this.updateLAY();
				}
				else
				{
					bool flag4 = this.typeRebuild == 12;
					if (flag4)
					{
						this.updateCONG_CHE_TAC();
					}
				}
			}
		}
	}

	// Token: 0x06000E6F RID: 3695 RVA: 0x00115F08 File Offset: 0x00114108
	private void updateCONG_CHE_TAC()
	{
		bool flag = this.Step == 1;
		if (flag)
		{
			this.tickStep++;
			bool flag2 = this.tickStep == 2;
			if (flag2)
			{
				mSound.playSound(28, mSound.volumeSound);
				base.createEff(76, 0, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2);
				base.createEff(53, 0, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2);
			}
			bool flag3 = this.tickStep >= 30;
			if (flag3)
			{
				this.Step = 0;
				this.tickStep = 0;
				GameCanvas.Start_Normal_Only_CmdClose_DiaLog(this.showServer);
			}
		}
	}

	// Token: 0x06000E70 RID: 3696 RVA: 0x00116030 File Offset: 0x00114230
	private void updateLAY()
	{
		bool flag = this.Step == 1;
		if (flag)
		{
			this.tickStep++;
			bool flag2 = this.tickStop == 0;
			if (flag2)
			{
				mSound.playSound(26, mSound.volumeSound);
				mSound.playSound(27, mSound.volumeSound);
				int num = 0;
				bool flag3 = this.typeRebuild == 7;
				if (flag3)
				{
					ScreenUpgrade.mItemUpgrade[0].LvUpgrade = 0;
					num = this.wItem / 4;
				}
				else
				{
					ScreenUpgrade.mItemUpgrade[0].isRemove = true;
				}
				base.createEff(75, 0, this.posUp[0][0] + this.wItem / 2 + num, this.posUp[0][1] + this.wItem / 2 + num, this.posUp[1][0] + this.wItem / 2 + num, this.posUp[1][1] + this.wItem / 2 + num);
				bool flag4 = this.potionBua != null;
				if (flag4)
				{
					base.createEff(75, 0, this.posUp[0][0] + this.wItem / 2 + num, this.posUp[0][1] + this.wItem / 2 + num - this.wItem - 2, this.posUp[1][0] + this.wItem / 2 + num, this.posUp[1][1] + this.wItem / 2 + num);
					this.potionBua = null;
				}
				this.tickStop = this.tickStep + 11 + (this.w - num * 3 - this.wInven) / 6 * 4 / 5;
			}
			else
			{
				bool flag5 = this.tickStep < this.tickStop;
				if (!flag5)
				{
					mSound.playSound(26, mSound.volumeSound);
					int num2 = 0;
					bool flag6 = this.typeRebuild == 7;
					if (flag6)
					{
						num2 = this.wItem / 4;
					}
					base.createEff(53, 0, this.posUp[1][0] + this.wItem / 2 + num2, this.posUp[1][1] + this.wItem / 2 + num2, this.posUp[1][0] + this.wItem / 2 + num2, this.posUp[1][1] + this.wItem / 2 + num2);
					this.Step = 2;
					this.tickStep = 0;
					this.tickStop = 0;
					bool flag7 = ScreenUpgrade.mItemUpgrade[0] != null;
					if (flag7)
					{
						bool flag8 = this.typeRebuild == 7;
						if (flag8)
						{
							ScreenUpgrade.mItemUpgrade[1].LvUpgrade = ReadMessenge.numCuonghoa;
						}
						else
						{
							bool flag9 = this.typeRebuild != 4;
							if (flag9)
							{
								ScreenUpgrade.mItemUpgrade[1] = ScreenUpgrade.mItemUpgrade[0];
							}
							bool flag10 = ScreenUpgrade.mItemUpgrade[1] != null;
							if (flag10)
							{
								ScreenUpgrade.mItemUpgrade[1].isRemove = false;
							}
							ScreenUpgrade.mItemUpgrade[0] = null;
							this.potionBua = null;
						}
					}
					bool flag11 = this.typeRebuild != 14;
					if (!flag11)
					{
						for (int i = 0; i < this.vecInventory.size(); i++)
						{
							MainItem mainItem = (MainItem)this.vecInventory.elementAt(i);
							bool flag12 = mainItem.typeObject == 3 && mainItem.ID == this.idItem9x;
							if (flag12)
							{
								MainItem mainItem2 = new MainItem(3, mainItem.ID, mainItem.idIcon, 0, mainItem.colorName, mainItem.LvUpgrade);
								ScreenUpgrade.mItemUpgrade[1] = mainItem2;
							}
						}
					}
				}
			}
		}
		else
		{
			bool flag13 = this.Step == 2;
			if (flag13)
			{
				this.tickStep++;
				bool flag14 = this.tickStep >= 20;
				if (flag14)
				{
					this.Step = 0;
					this.tickStep = 0;
					this.tickStop = 0;
					GameCanvas.Start_Normal_Only_CmdClose_DiaLog(this.showServer);
				}
			}
		}
	}

	// Token: 0x06000E71 RID: 3697 RVA: 0x0011640C File Offset: 0x0011460C
	private void updateSplit()
	{
		bool flag = this.Step != 1;
		if (!flag)
		{
			this.tickStep++;
			bool flag2 = this.tickStep % 5 != 0;
			if (!flag2)
			{
				bool flag3 = this.tickStop == 0;
				if (flag3)
				{
					mSound.playSound(26, mSound.volumeSound);
					mSound.playSound(27, mSound.volumeSound);
					base.createEff(75, 0, this.posUp[0][0] + this.wItem / 2, this.posUp[0][1] + this.wItem / 2, this.posUp[1][0] + this.wItem / 2, this.posUp[1][1] + this.wItem / 2);
					ScreenUpgrade.mItemUpgrade[0].isRemove = true;
					this.tickStop = this.tickStep + 11 + (this.w - this.lech * 3 - this.wInven) / 6 * 4 / 5;
				}
				else
				{
					bool flag4 = this.tickStep >= this.tickStop;
					if (flag4)
					{
						mSound.playSound(26, mSound.volumeSound);
						base.createEff(53, 0, this.posUp[1][0] + this.wItem / 2, this.posUp[1][1] + this.wItem / 2, this.posUp[1][0] + this.wItem / 2, this.posUp[1][1] + this.wItem / 2);
						this.Step = 0;
						this.tickStep = 0;
						this.tickStop = 0;
						ScreenUpgrade.mItemUpgrade[0] = null;
						bool flag5 = ScreenUpgrade.mItemUpgrade[1] != null;
						if (flag5)
						{
							ScreenUpgrade.mItemUpgrade[1].isRemove = false;
						}
					}
				}
			}
		}
	}

	// Token: 0x06000E72 RID: 3698 RVA: 0x001165CC File Offset: 0x001147CC
	public void setSetItem()
	{
		bool flag = this.typeRebuild == 2;
		if (flag)
		{
			this.isPaintrectPlus = false;
			bool flag2 = ScreenUpgrade.mItemUpgrade[0] != null;
			if (flag2)
			{
				bool flag3 = ScreenUpgrade.mItemUpgrade[0].numLoKham >= 4;
				if (flag3)
				{
					this.isPaintrectPlus = true;
				}
				else
				{
					this.potionBua = null;
				}
			}
		}
		else
		{
			bool flag4 = this.typeRebuild == 19;
			if (flag4)
			{
				this.isPaintrectPlus = false;
				bool flag5 = ScreenUpgrade.mItemUpgrade[0] != null;
				if (flag5)
				{
					this.isPaintrectPlus = true;
				}
			}
			else
			{
				bool flag6 = this.typeRebuild == 15;
				if (flag6)
				{
					this.isPaintrectPlus = false;
					bool flag7 = ScreenUpgrade.mItemUpgrade[0] != null;
					if (flag7)
					{
						this.isPaintrectPlus = true;
					}
				}
			}
		}
	}

	// Token: 0x06000E73 RID: 3699 RVA: 0x00116690 File Offset: 0x00114890
	public override iCommand getCmdShopMore()
	{
		bool flag = this.typeRebuild == 19 || this.typeRebuild == 21;
		iCommand result;
		if (flag)
		{
			result = null;
		}
		else
		{
			result = this.cmdMenu;
		}
		return result;
	}

	// Token: 0x06000E74 RID: 3700 RVA: 0x001166C8 File Offset: 0x001148C8
	public void XoaDa(short id)
	{
		for (int i = 0; i < this.vecInventory.size(); i++)
		{
			MainItem mainItem = (MainItem)this.vecInventory.elementAt(i);
			bool flag = mainItem.ID == id;
			if (flag)
			{
				this.vecInventory.removeElementAt(i);
				break;
			}
		}
	}

	// Token: 0x06000E75 RID: 3701 RVA: 0x00116724 File Offset: 0x00114924
	public void ChangeCmd()
	{
		bool flag = ScreenUpgrade.mItemUpgrade[0] == null;
		if (flag)
		{
			this.cmdUpgrade.caption = T.kham;
			this.cmdUpgrade.indexMenu = 22;
		}
		else
		{
			this.cmdUpgrade.caption = T.laydara;
			this.cmdUpgrade.indexMenu = 23;
		}
	}

	// Token: 0x0400161D RID: 5661
	public const sbyte RE_SPLIT = 0;

	// Token: 0x0400161E RID: 5662
	public const sbyte RE_KHAM = 1;

	// Token: 0x0400161F RID: 5663
	public const sbyte RE_DUT = 2;

	// Token: 0x04001620 RID: 5664
	public const sbyte RE_LAY = 3;

	// Token: 0x04001621 RID: 5665
	public const sbyte RE_NANGCAPDA = 4;

	// Token: 0x04001622 RID: 5666
	public const sbyte RE_NANGCAPITEM = 5;

	// Token: 0x04001623 RID: 5667
	public const sbyte RE_TRADE = 6;

	// Token: 0x04001624 RID: 5668
	public const sbyte RE_CHUYEN_HOA = 7;

	// Token: 0x04001625 RID: 5669
	public const sbyte RE_DEVIL_CHEST = 8;

	// Token: 0x04001626 RID: 5670
	public const sbyte RE_DEVIL_SKILL = 9;

	// Token: 0x04001627 RID: 5671
	public const sbyte RE_HOAN_MY = 10;

	// Token: 0x04001628 RID: 5672
	public const sbyte RE_KICH_AN = 11;

	// Token: 0x04001629 RID: 5673
	public const sbyte RE_CONG_CHE_TAC = 12;

	// Token: 0x0400162A RID: 5674
	public const sbyte RE_DA_SIEU_CAP = 13;

	// Token: 0x0400162B RID: 5675
	public const sbyte RE_DO_9X = 14;

	// Token: 0x0400162C RID: 5676
	public const sbyte RE_SIEU_NANGCAPITEM = 15;

	// Token: 0x0400162D RID: 5677
	public const sbyte RE_CUONG_HOA_DIAL = 18;

	// Token: 0x0400162E RID: 5678
	public const sbyte RE_DUC_LO_DIAL = 19;

	// Token: 0x0400162F RID: 5679
	public const sbyte RE_GHEP_NHIEU_NGLIEU_THANH_1 = 20;

	// Token: 0x04001630 RID: 5680
	public const sbyte RE_HANH_TRINH = 21;

	// Token: 0x04001631 RID: 5681
	public const sbyte RE_CUONG_HOA_SKIN = 22;

	// Token: 0x04001632 RID: 5682
	public new static SplitScreen instance;

	// Token: 0x04001633 RID: 5683
	public short idItem9x = -1;

	// Token: 0x04001634 RID: 5684
	public MainItem potionBua;

	// Token: 0x04001635 RID: 5685
	private bool isPaintrectPlus;

	// Token: 0x04001636 RID: 5686
	private InputDialog input;

	// Token: 0x04001637 RID: 5687
	public int PriceChuyenHoa;

	// Token: 0x04001638 RID: 5688
	public sbyte tile;

	// Token: 0x04001639 RID: 5689
	public mVector vecDaKhamHanhTrinh = new mVector();

	// Token: 0x0400163A RID: 5690
	public short idMinimap = -1;

	// Token: 0x0400163B RID: 5691
	public string nameMinimap = string.Empty;
}
