using System;

// Token: 0x020000E0 RID: 224
public class SaveRms
{
	// Token: 0x06000D74 RID: 3444 RVA: 0x00104E6C File Offset: 0x0010306C
	public void saveUserPass(string user, string pass)
	{
		bool flag = user.Length == 0 || pass.Length == 0;
		if (!flag)
		{
			ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
			DataOutputStream dataOutputStream = new DataOutputStream(byteArrayOutputStream);
			try
			{
				dataOutputStream.writeUTF(user);
				dataOutputStream.writeUTF(pass);
				dataOutputStream.writeByte(ListChar_Screen.IndexCharSelected);
				dataOutputStream.writeByte((sbyte)GameCanvas.IndexServer);
				CRes.saveRMS("MAIN_user_pass", byteArrayOutputStream.toByteArray());
				dataOutputStream.close();
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x06000D75 RID: 3445 RVA: 0x00104EFC File Offset: 0x001030FC
	public void saveDataeff(short id, sbyte[] data)
	{
		try
		{
			CRes.saveRMS("dataeff_SKILL" + id.ToString(), data);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D76 RID: 3446 RVA: 0x00104F3C File Offset: 0x0010313C
	public bool loadUserPass()
	{
		sbyte[] array = CRes.loadRMS("MAIN_user_pass");
		bool flag = array == null;
		bool result;
		if (flag)
		{
			bool flag2 = GameCanvas.IndexServer > GameCanvas.strListServer[(int)GameCanvas.language].Length;
			if (flag2)
			{
				GameCanvas.IndexServer = 0;
			}
			result = false;
		}
		else
		{
			try
			{
				ByteArrayInputStream bis = new ByteArrayInputStream(array);
				DataInputStream dataInputStream = new DataInputStream(bis);
				GameCanvas.loginScr.tfUser.setText(dataInputStream.readUTF());
				GameCanvas.loginScr.tfPass.setText(dataInputStream.readUTF());
				ListChar_Screen.IndexCharSelected = dataInputStream.readByte();
				bool flag3 = dataInputStream.available() > 0;
				if (flag3)
				{
					GameCanvas.IndexServer = (int)dataInputStream.readByte();
					bool flag4 = GameCanvas.IndexServer > GameCanvas.strListServer[(int)GameCanvas.language].Length;
					if (flag4)
					{
						GameCanvas.IndexServer = 0;
					}
				}
				else
				{
					GameCanvas.IndexServer = GameCanvas.strListServer[(int)GameCanvas.language].Length - 1;
				}
				dataInputStream.close();
			}
			catch (Exception)
			{
			}
			result = true;
		}
		return result;
	}

	// Token: 0x06000D77 RID: 3447 RVA: 0x00105050 File Offset: 0x00103250
	public void saveUserLast(string user)
	{
		bool flag = user.Length == 0;
		if (!flag)
		{
			ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
			DataOutputStream dataOutputStream = new DataOutputStream(byteArrayOutputStream);
			try
			{
				dataOutputStream.writeUTF(user);
				CRes.saveRMS("MAIN_user_last", byteArrayOutputStream.toByteArray());
				dataOutputStream.close();
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x06000D78 RID: 3448 RVA: 0x001050B4 File Offset: 0x001032B4
	public void loadUserLast()
	{
		sbyte[] array = CRes.loadRMS("MAIN_user_last");
		bool flag = array == null;
		if (!flag)
		{
			try
			{
				ByteArrayInputStream bis = new ByteArrayInputStream(array);
				DataInputStream dataInputStream = new DataInputStream(bis);
				SaveRms.userLast = dataInputStream.readUTF();
				dataInputStream.close();
				bool flag2 = SaveRms.userLast.Length >= 10;
				if (flag2)
				{
					SaveRms.userLast.Substring(0, 9);
				}
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x06000D79 RID: 3449 RVA: 0x0010513C File Offset: 0x0010333C
	public void saveIpLast(string ip)
	{
		bool flag = ip.Length == 0;
		if (!flag)
		{
			ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
			DataOutputStream dataOutputStream = new DataOutputStream(byteArrayOutputStream);
			try
			{
				dataOutputStream.writeUTF(ip);
				CRes.saveRMS("MAIN_ip_last", byteArrayOutputStream.toByteArray());
				dataOutputStream.close();
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x06000D7A RID: 3450 RVA: 0x001051A0 File Offset: 0x001033A0
	public static string loadIpLast()
	{
		mSystem.outz("1");
		sbyte[] array = CRes.loadRMS("MAIN_ip_last");
		mSystem.outz("2");
		bool flag = array == null;
		string result;
		if (flag)
		{
			result = string.Empty;
		}
		else
		{
			try
			{
				mSystem.outz("3");
				ByteArrayInputStream bis = new ByteArrayInputStream(array);
				DataInputStream dataInputStream = new DataInputStream(bis);
				mSystem.outz("4");
				string text = dataInputStream.readUTF();
				mSystem.outz("5");
				dataInputStream.close();
				mSystem.outz("ip = " + text);
				result = text;
			}
			catch (Exception)
			{
				mSystem.outz("loi ip");
				result = string.Empty;
			}
		}
		return result;
	}

	// Token: 0x06000D7B RID: 3451 RVA: 0x00105260 File Offset: 0x00103460
	public void loadBeginGame()
	{
		this.loadUserPass();
		GlobalService.VerCharPar = SaveRms.loadVer("VerdataCharPart");
		GlobalService.VerMonster = SaveRms.loadVer("VerdataMon");
		GlobalService.VerNameAtribute = SaveRms.loadVer("VerdataAttri");
		GlobalService.VerPotion = SaveRms.loadVer("VerdataPotion");
		GlobalService.VerNameMap = SaveRms.loadVer("VerdataNameMap");
		GlobalService.VerItemMap = SaveRms.loadVer("VerdataItemMap");
		GlobalService.VerImageSave = SaveRms.loadVer("VerdataImageSave");
		GlobalService.VerNamePotionQuest = SaveRms.loadVer("VerdataNamePotionquest");
		GlobalService.VerDataUpgrade = SaveRms.loadVer("VerdataUpgradeSave");
	}

	// Token: 0x06000D7C RID: 3452 RVA: 0x001052FC File Offset: 0x001034FC
	public void saveHotKey()
	{
		ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
		DataOutputStream dataOutputStream = new DataOutputStream(byteArrayOutputStream);
		try
		{
			for (int i = 0; i < Player.hotkeyPlayer.Length; i++)
			{
				for (int j = 0; j < Player.hotkeyPlayer[i].Length; j++)
				{
					dataOutputStream.writeByte(Player.hotkeyPlayer[i][j].getTypeHotKey());
					bool flag = Player.hotkeyPlayer[i][j].getTypeHotKey() == 0;
					if (flag)
					{
						dataOutputStream.writeShort(Player.hotkeyPlayer[i][j].itemcur.ID);
					}
					else
					{
						bool flag2 = Player.hotkeyPlayer[i][j].getTypeHotKey() == 1;
						if (flag2)
						{
							dataOutputStream.writeShort(Player.hotkeyPlayer[i][j].skill.ID);
						}
					}
				}
			}
			GlobalService.gI().Save_RMS_Server(1, 0, byteArrayOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D7D RID: 3453 RVA: 0x0010540C File Offset: 0x0010360C
	public void loadHotKey(sbyte[] bData)
	{
		bool flag = bData == null;
		if (flag)
		{
			for (int i = 0; i < Player.hotkeyPlayer.Length; i++)
			{
				bool flag2 = Player.vecListSkill.size() > 0;
				if (flag2)
				{
					Skill_Info skill_Info = (Skill_Info)Player.vecListSkill.elementAt(0);
					bool flag3 = skill_Info != null;
					if (flag3)
					{
						MainSkill mainSkill = new MainSkill(skill_Info.ID, -1);
						mainSkill.indexHotKey = skill_Info.indexHotKey;
						mainSkill.idIcon = skill_Info.idIcon;
						mainSkill.isBuff = (skill_Info.typeSkill == 2);
						Player.hotkeyPlayer[i][2].setSkill(mainSkill, mainSkill.idIcon);
					}
				}
			}
		}
		else
		{
			try
			{
				ByteArrayInputStream bis = new ByteArrayInputStream(bData);
				DataInputStream dataInputStream = new DataInputStream(bis);
				for (int j = 0; j < Player.hotkeyPlayer.Length; j++)
				{
					for (int k = 0; k < Player.hotkeyPlayer[j].Length; k++)
					{
						int num = (int)dataInputStream.readByte();
						bool flag4 = num == -1;
						if (!flag4)
						{
							short id = dataInputStream.readShort();
							int num2 = num;
							int num3 = num2;
							if (num3 != 0)
							{
								if (num3 == 1)
								{
									Skill_Info skillFromID = Skill_Info.getSkillFromID(id);
									bool flag5 = skillFromID != null;
									if (flag5)
									{
										MainSkill mainSkill2 = new MainSkill(skillFromID.ID, -1);
										mainSkill2.indexHotKey = skillFromID.indexHotKey;
										mainSkill2.idIcon = skillFromID.idIcon;
										mainSkill2.isBuff = (skillFromID.typeSkill == 2);
										Player.hotkeyPlayer[j][k].setSkill(mainSkill2, mainSkill2.idIcon);
									}
								}
							}
							else
							{
								MainItem itemVec = MainItem.getItemVec(4, id, Player.vecInventory);
								bool flag6 = itemVec != null;
								if (flag6)
								{
									Player.hotkeyPlayer[j][k].setPotion(itemVec);
								}
							}
						}
					}
				}
				dataInputStream.close();
				Skill_Info skill_Info2 = (Skill_Info)Player.vecListSkill.elementAt(0);
				bool flag7 = skill_Info2 == null;
				if (!flag7)
				{
					for (int l = 0; l < Player.hotkeyPlayer.Length; l++)
					{
						bool flag8 = Player.vecListSkill.size() > 0 && (Player.hotkeyPlayer[l][2].skill == null || Player.hotkeyPlayer[l][2].skill.ID != skill_Info2.ID);
						if (flag8)
						{
							MainSkill mainSkill3 = new MainSkill(skill_Info2.ID, -1);
							mainSkill3.indexHotKey = skill_Info2.indexHotKey;
							mainSkill3.idIcon = skill_Info2.idIcon;
							mainSkill3.isBuff = (skill_Info2.typeSkill == 2);
							Player.hotkeyPlayer[l][2].setSkill(mainSkill3, mainSkill3.idIcon);
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x06000D7E RID: 3454 RVA: 0x0010571C File Offset: 0x0010391C
	public void setLoadRMSServer(sbyte id, sbyte[] data)
	{
		bool flag = id == 0;
		if (flag)
		{
			SaveRms.datahotKeySkill = data;
			this.loadHotKey(data);
		}
		else
		{
			bool flag2 = id == 1;
			if (flag2)
			{
				this.loadAutoMp_Hp(data);
			}
			else
			{
				bool flag3 = id == 2;
				if (flag3)
				{
					this.loadAutoGetItem(data);
				}
				else
				{
					bool flag4 = id == 3;
					if (flag4)
					{
						this.loadAutoMaterial(data);
					}
					else
					{
						bool flag5 = id == 4;
						if (flag5)
						{
							bool flag6 = data != null;
							if (flag6)
							{
								try
								{
									ByteArrayInputStream bis = new ByteArrayInputStream(data);
									DataInputStream dataInputStream = new DataInputStream(bis);
									GameScreen.indexHelp = (int)dataInputStream.readShort();
									dataInputStream.close();
									return;
								}
								catch (Exception)
								{
									return;
								}
							}
							GameScreen.indexHelp = 0;
						}
						else
						{
							bool flag7 = id == 5;
							if (flag7)
							{
								this.loadAutoFire(data);
							}
							else
							{
								bool flag8 = id == 6;
								if (flag8)
								{
									this.loadUniform(data);
								}
								else
								{
									bool flag9 = id == 7;
									if (flag9)
									{
										bool flag10 = data != null;
										if (flag10)
										{
											try
											{
												ByteArrayInputStream bis2 = new ByteArrayInputStream(data);
												DataInputStream dataInputStream2 = new DataInputStream(bis2);
												GameScreen.isShowSkillBuff = (dataInputStream2.readByte() == 1);
												dataInputStream2.close();
											}
											catch (Exception)
											{
											}
										}
									}
									else
									{
										bool flag11 = id == 8;
										if (flag11)
										{
											bool flag12 = data != null;
											if (flag12)
											{
												try
												{
													ByteArrayInputStream bis3 = new ByteArrayInputStream(data);
													DataInputStream dataInputStream3 = new DataInputStream(bis3);
													GameScreen.indexHDVaoLang = (int)dataInputStream3.readByte();
													dataInputStream3.close();
												}
												catch (Exception)
												{
												}
											}
										}
										else
										{
											bool flag13 = id == 9;
											if (flag13)
											{
												bool flag14 = data != null;
												if (flag14)
												{
													try
													{
														ByteArrayInputStream bis4 = new ByteArrayInputStream(data);
														DataInputStream dataInputStream4 = new DataInputStream(bis4);
														GameScreen.isShowSkillPlayer = (dataInputStream4.readByte() == 1);
														dataInputStream4.close();
													}
													catch (Exception)
													{
													}
												}
											}
											else
											{
												bool flag15 = id == 10 && data != null;
												if (flag15)
												{
													try
													{
														ByteArrayInputStream bis5 = new ByteArrayInputStream(data);
														DataInputStream dataInputStream5 = new DataInputStream(bis5);
														GameScreen.isShowNhanVat = (dataInputStream5.readByte() == 1);
														dataInputStream5.close();
													}
													catch (Exception)
													{
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

	// Token: 0x06000D7F RID: 3455 RVA: 0x0010597C File Offset: 0x00103B7C
	public void loadAutoMaterial(sbyte[] bData)
	{
		bool flag = bData == null;
		if (!flag)
		{
			try
			{
				ByteArrayInputStream bis = new ByteArrayInputStream(bData);
				DataInputStream dataInputStream = new DataInputStream(bis);
				Player.isAutoMaterial = dataInputStream.readByte();
				dataInputStream.close();
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x06000D80 RID: 3456 RVA: 0x001059D0 File Offset: 0x00103BD0
	public void SaveAutoMaterial()
	{
		ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
		DataOutputStream dataOutputStream = new DataOutputStream(byteArrayOutputStream);
		try
		{
			dataOutputStream.writeByte(Player.isAutoMaterial);
			GlobalService.gI().Save_RMS_Server(1, 3, byteArrayOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D81 RID: 3457 RVA: 0x00105A2C File Offset: 0x00103C2C
	public static void saveVer(short ver, string name)
	{
		ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
		DataOutputStream dataOutputStream = new DataOutputStream(byteArrayOutputStream);
		try
		{
			dataOutputStream.writeShort(ver);
			CRes.saveRMS("MAIN_" + name, byteArrayOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D82 RID: 3458 RVA: 0x00105A88 File Offset: 0x00103C88
	public static short loadVer(string name)
	{
		sbyte[] array = CRes.loadRMS("MAIN_" + name);
		short num = -1;
		short result;
		try
		{
			bool flag = array != null;
			if (flag)
			{
				ByteArrayInputStream bis = new ByteArrayInputStream(array);
				DataInputStream dataInputStream = new DataInputStream(bis);
				num = dataInputStream.readShort();
				dataInputStream.close();
				result = num;
			}
			else
			{
				result = num;
			}
		}
		catch (Exception)
		{
			result = num;
		}
		return result;
	}

	// Token: 0x06000D83 RID: 3459 RVA: 0x00105AF8 File Offset: 0x00103CF8
	public static void saveData(sbyte[] dataSave, string name)
	{
		try
		{
			CRes.saveRMS("MAIN_" + name, dataSave);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D84 RID: 3460 RVA: 0x00105B34 File Offset: 0x00103D34
	public static DataInputStream loadData(string name)
	{
		sbyte[] array = CRes.loadRMS("MAIN_" + name);
		DataInputStream dataInputStream = null;
		bool flag = array == null;
		DataInputStream result;
		if (flag)
		{
			result = null;
		}
		else
		{
			try
			{
				ByteArrayInputStream bis = new ByteArrayInputStream(array);
				dataInputStream = new DataInputStream(bis);
				result = dataInputStream;
			}
			catch (Exception)
			{
				result = dataInputStream;
			}
		}
		return result;
	}

	// Token: 0x06000D85 RID: 3461 RVA: 0x00105B90 File Offset: 0x00103D90
	public void SaveAutoMp_Hp()
	{
		ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
		DataOutputStream dataOutputStream = new DataOutputStream(byteArrayOutputStream);
		try
		{
			dataOutputStream.writeByte(Player.isMPHP ? 1 : 0);
			bool isMPHP = Player.isMPHP;
			if (isMPHP)
			{
				dataOutputStream.writeByte((sbyte)MsgAutoMPHP.mp);
				dataOutputStream.writeByte((sbyte)MsgAutoMPHP.hp);
				dataOutputStream.writeByte((sbyte)MsgAutoMPHP.typeUu);
			}
			GlobalService.gI().Save_RMS_Server(1, 1, byteArrayOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D86 RID: 3462 RVA: 0x00105C24 File Offset: 0x00103E24
	public void loadAutoMp_Hp(sbyte[] bData)
	{
		bool flag = bData == null;
		if (!flag)
		{
			try
			{
				ByteArrayInputStream bis = new ByteArrayInputStream(bData);
				DataInputStream dataInputStream = new DataInputStream(bis);
				Player.isMPHP = (dataInputStream.readByte() == 1);
				bool isMPHP = Player.isMPHP;
				if (isMPHP)
				{
					MsgAutoMPHP.mp = (int)dataInputStream.readByte();
					MsgAutoMPHP.hp = (int)dataInputStream.readByte();
					MsgAutoMPHP.typeUu = (int)dataInputStream.readByte();
				}
				dataInputStream.close();
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x06000D87 RID: 3463 RVA: 0x00105CA8 File Offset: 0x00103EA8
	public void SaveUniform()
	{
		ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
		DataOutputStream dataOutputStream = new DataOutputStream(byteArrayOutputStream);
		try
		{
			dataOutputStream.writeByte((sbyte)Player.vecUniform.size());
			for (int i = 0; i < Player.vecUniform.size(); i++)
			{
				Uniform uniform = (Uniform)Player.vecUniform.elementAt(i);
				dataOutputStream.writeByte(uniform.index);
				dataOutputStream.writeByte(uniform.isSet);
				for (int j = 0; j < 8; j++)
				{
					bool flag = j < uniform.mIdUniform.Length;
					if (flag)
					{
						dataOutputStream.writeShort(uniform.mIdUniform[j]);
					}
					else
					{
						dataOutputStream.writeShort(-1);
					}
				}
			}
			GlobalService.gI().Save_RMS_Server(1, 6, byteArrayOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D88 RID: 3464 RVA: 0x00105D9C File Offset: 0x00103F9C
	public void loadUniform(sbyte[] bData)
	{
		bool flag = bData == null;
		if (!flag)
		{
			try
			{
				ByteArrayInputStream bis = new ByteArrayInputStream(bData);
				DataInputStream dataInputStream = new DataInputStream(bis);
				sbyte b = dataInputStream.readByte();
				for (int i = 0; i < (int)b; i++)
				{
					Uniform uniform = new Uniform();
					uniform.index = dataInputStream.readByte();
					uniform.isSet = dataInputStream.readByte();
					uniform.mIdUniform = new short[8];
					for (int j = 0; j < 8; j++)
					{
						uniform.mIdUniform[j] = dataInputStream.readShort();
					}
					Player.vecUniform.addElement(uniform);
				}
				dataInputStream.close();
				Uniform.checkIndexItem(false);
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x06000D89 RID: 3465 RVA: 0x00105E70 File Offset: 0x00104070
	public void SaveAutoGetItem()
	{
		ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
		DataOutputStream dataOutputStream = new DataOutputStream(byteArrayOutputStream);
		try
		{
			dataOutputStream.writeByte(Player.isGetItem ? 1 : 0);
			bool isGetItem = Player.isGetItem;
			if (isGetItem)
			{
				for (int i = 0; i < MsgAutoGetItem.mValue.Length; i++)
				{
					dataOutputStream.writeByte((sbyte)MsgAutoGetItem.mValue[i]);
				}
			}
			GlobalService.gI().Save_RMS_Server(1, 2, byteArrayOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D8A RID: 3466 RVA: 0x00105F08 File Offset: 0x00104108
	public void SaveShowSkillBuff()
	{
		ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
		DataOutputStream dataOutputStream = new DataOutputStream(byteArrayOutputStream);
		try
		{
			dataOutputStream.writeByte(GameScreen.isShowSkillBuff ? 1 : 0);
			GlobalService.gI().Save_RMS_Server(1, 7, byteArrayOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D8B RID: 3467 RVA: 0x00105F6C File Offset: 0x0010416C
	public void SaveShowSkillPlayer()
	{
		ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
		DataOutputStream dataOutputStream = new DataOutputStream(byteArrayOutputStream);
		try
		{
			dataOutputStream.writeByte(GameScreen.isShowSkillPlayer ? 1 : 0);
			GlobalService.gI().Save_RMS_Server(1, 9, byteArrayOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D8C RID: 3468 RVA: 0x00105FD0 File Offset: 0x001041D0
	public void SaveShowNhanVat()
	{
		ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
		DataOutputStream dataOutputStream = new DataOutputStream(byteArrayOutputStream);
		try
		{
			dataOutputStream.writeByte(GameScreen.isShowNhanVat ? 1 : 0);
			GlobalService.gI().Save_RMS_Server(1, 10, byteArrayOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D8D RID: 3469 RVA: 0x00106034 File Offset: 0x00104234
	public void loadAutoGetItem(sbyte[] bData)
	{
		bool flag = bData == null;
		if (!flag)
		{
			try
			{
				ByteArrayInputStream bis = new ByteArrayInputStream(bData);
				DataInputStream dataInputStream = new DataInputStream(bis);
				Player.isGetItem = (dataInputStream.readByte() == 1);
				bool isGetItem = Player.isGetItem;
				if (isGetItem)
				{
					for (int i = 0; i < MsgAutoGetItem.mValue.Length; i++)
					{
						MsgAutoGetItem.mValue[i] = (int)dataInputStream.readByte();
					}
				}
				dataInputStream.close();
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x06000D8E RID: 3470 RVA: 0x001060C4 File Offset: 0x001042C4
	public void SaveIndexHelp()
	{
		ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
		DataOutputStream dataOutputStream = new DataOutputStream(byteArrayOutputStream);
		try
		{
			dataOutputStream.writeShort((short)GameScreen.indexHelp);
			GlobalService.gI().Save_RMS_Server(1, 4, byteArrayOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D8F RID: 3471 RVA: 0x00106120 File Offset: 0x00104320
	public void SaveAutoFire()
	{
		ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
		DataOutputStream dataOutputStream = new DataOutputStream(byteArrayOutputStream);
		try
		{
			dataOutputStream.writeByte(Player.typeAutoFireMain);
			bool flag = MsgAutoFire.value == null;
			if (flag)
			{
				dataOutputStream.writeByte(0);
			}
			else
			{
				dataOutputStream.writeByte((sbyte)MsgAutoFire.value.Length);
				for (int i = 0; i < MsgAutoFire.value.Length; i++)
				{
					dataOutputStream.writeShort(MsgAutoFire.value[i][0]);
					dataOutputStream.writeByte((sbyte)MsgAutoFire.value[i][1]);
				}
			}
			dataOutputStream.writeByte(Player.AutoRevice);
			GlobalService.gI().Save_RMS_Server(1, 5, byteArrayOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000D90 RID: 3472 RVA: 0x001061EC File Offset: 0x001043EC
	public void loadAutoFire(sbyte[] bData)
	{
		bool flag = bData == null;
		if (!flag)
		{
			try
			{
				ByteArrayInputStream bis = new ByteArrayInputStream(bData);
				DataInputStream dataInputStream = new DataInputStream(bis);
				Player.typeAutoFireMain = dataInputStream.readByte();
				bool flag2 = Player.typeAutoFireMain == -1;
				if (flag2)
				{
					Player.AutoFireCur = -1;
				}
				mSystem.outz("Player autofire type " + Player.typeAutoFireMain.ToString() + " AutoFireCur " + Player.AutoFireCur.ToString());
				Player.typeAutoBuff = 0;
				sbyte b = dataInputStream.readByte();
				bool flag3 = b > 0;
				if (flag3)
				{
					MsgAutoFire.value = new short[(int)b][];
					for (int i = 0; i < (int)b; i++)
					{
						MsgAutoFire.value[i] = new short[2];
						MsgAutoFire.value[i][0] = dataInputStream.readShort();
						MsgAutoFire.value[i][1] = (short)dataInputStream.readByte();
						bool flag4 = MsgAutoFire.value[i][1] == 1;
						if (flag4)
						{
							Player.typeAutoBuff = 1;
						}
					}
				}
				Player.AutoRevice = dataInputStream.readByte();
				dataInputStream.close();
			}
			catch (Exception)
			{
			}
			bool flag5 = Player.AutoRevice == 1;
			if (flag5)
			{
				Interface_Game.addInfoPlayerNormal(T.dangbatauto, mFont.tahoma_7_yellow);
			}
		}
	}

	// Token: 0x040014C2 RID: 5314
	public const sbyte RMS_SER_SKILL = 0;

	// Token: 0x040014C3 RID: 5315
	public const sbyte RMS_SER_AUTO_MP_HP = 1;

	// Token: 0x040014C4 RID: 5316
	public const sbyte RMS_SER_AUTO_GET_ITEM = 2;

	// Token: 0x040014C5 RID: 5317
	public const sbyte RMS_SER_AUTO_MATERIAL = 3;

	// Token: 0x040014C6 RID: 5318
	public const sbyte RMS_SER_INDEX_HELP = 4;

	// Token: 0x040014C7 RID: 5319
	public const sbyte RMS_SER_AUTO_FIRE = 5;

	// Token: 0x040014C8 RID: 5320
	public const sbyte RMS_SER_UNIFORM = 6;

	// Token: 0x040014C9 RID: 5321
	public const sbyte RMS_SER_SKILL_BUFF = 7;

	// Token: 0x040014CA RID: 5322
	public const sbyte RMS_SER_INDEX_LANG = 8;

	// Token: 0x040014CB RID: 5323
	public const sbyte RMS_SER_SKILL_PLAYER = 9;

	// Token: 0x040014CC RID: 5324
	public const sbyte RMS_SER_NHAN_VAT = 10;

	// Token: 0x040014CD RID: 5325
	public static string userLast = string.Empty;

	// Token: 0x040014CE RID: 5326
	public static sbyte[] datahotKeySkill;
}
