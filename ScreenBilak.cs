using System;

// Token: 0x020000E2 RID: 226
public class ScreenBilak : MainScreen
{
	// Token: 0x06000D9A RID: 3482 RVA: 0x00106504 File Offset: 0x00104704
	public ScreenBilak()
	{
		this.valuePlay = mSystem.new_M_Int(ScreenBilak.strListPlayer.Length, 2);
		ScreenBilak.valueWin = new int[ScreenBilak.strListPlayer.Length];
		for (int i = 0; i < ScreenBilak.valueWin.Length; i++)
		{
			ScreenBilak.valueWin[i] = 0;
		}
		for (int j = 0; j < this.valuePlay.Length; j++)
		{
			this.valuePlay[j] = new int[2];
			this.valuePlay[j][0] = 1;
			this.valuePlay[j][1] = 0;
		}
		this.cmdSetTop = new iCommand("Set Top", 0, this);
		this.cmdSetTop.setPos(MotherCanvas.hw, 15, null, this.cmdSetTop.caption);
		this.cmdSetTop.isSelect = true;
		this.cmdOff = new iCommand("Off", 1, this);
		this.cmdOff.setPos(MotherCanvas.hw, 45, null, this.cmdOff.caption);
		this.cmdMyRandom = new iCommand("Fight", 2, this);
		this.cmdMyRandom.setPos(MotherCanvas.hw, 75, null, this.cmdMyRandom.caption);
		this.cmdTableAfter = new iCommand("Lần Trước", 3, this);
		this.cmdTableAfter.setPos(MotherCanvas.hw + iCommand.wButtonCmd + 5, 15, null, this.cmdTableAfter.caption);
		this.cmdSetCongWin = new iCommand("+ Win", 4, this);
		this.cmdSetCongWin.setPos(MotherCanvas.hw + iCommand.wButtonCmd + 5, 45, null, this.cmdSetCongWin.caption);
		this.cmdSetTruWin = new iCommand("- Win", 5, this);
		this.cmdSetTruWin.setPos(MotherCanvas.hw + iCommand.wButtonCmd + 5, 75, null, this.cmdSetTruWin.caption);
		this.cmdTop6 = new iCommand("Auto Top 6", 6, this);
		this.cmdTop6.setPos(MotherCanvas.hw + iCommand.wButtonCmd * 2 + 10, 15, null, this.cmdTop6.caption);
		this.cmdOffTable = new iCommand("Off Table", 7, this);
		this.cmdOffTable.setPos(MotherCanvas.hw + iCommand.wButtonCmd * 2 + 10, 45, null, this.cmdOffTable.caption);
		this.vecCmd.addElement(this.cmdSetTop);
		this.vecCmd.addElement(this.cmdOff);
		this.vecCmd.addElement(this.cmdMyRandom);
		this.vecCmd.addElement(this.cmdTableAfter);
		this.vecCmd.addElement(this.cmdSetCongWin);
		this.vecCmd.addElement(this.cmdSetTruWin);
		this.vecCmd.addElement(this.cmdTop6);
		this.vecCmd.addElement(this.cmdOffTable);
		ScreenBilak.demNG = ScreenBilak.strListPlayer.Length;
		this.strSoNguoi = "Số người chơi: " + ScreenBilak.demNG.ToString();
		sbyte[] array = CRes.loadRMS("SUB_BILAK");
		try
		{
			bool flag = array != null;
			if (flag)
			{
				ByteArrayInputStream bis = new ByteArrayInputStream(array);
				DataInputStream dataInputStream = new DataInputStream(bis);
				this.strRMS = dataInputStream.readUTF();
				dataInputStream.close();
			}
		}
		catch (Exception)
		{
		}
		sbyte[] data = CRes.loadRMS("SUB_BILAK_TOP");
		try
		{
			bool flag2 = array != null;
			if (flag2)
			{
				ByteArrayInputStream bis2 = new ByteArrayInputStream(data);
				DataInputStream dataInputStream2 = new DataInputStream(bis2);
				for (int k = 0; k < ScreenBilak.valueWin.Length; k++)
				{
					ScreenBilak.valueWin[k] = (int)dataInputStream2.readByte();
				}
				dataInputStream2.close();
			}
		}
		catch (Exception)
		{
		}
		this.autoSetTop6();
		this.strTop = "Số Top: " + ScreenBilak.demTop.ToString();
	}

	// Token: 0x06000D9B RID: 3483 RVA: 0x0010693C File Offset: 0x00104B3C
	private void autoSetTop6()
	{
		int num = 0;
		for (int i = 0; i < ScreenBilak.strListPlayer.Length; i++)
		{
			int num2 = 0;
			for (int j = 0; j < ScreenBilak.strListPlayer.Length; j++)
			{
				bool flag = i != j && ScreenBilak.valueWin[i] < ScreenBilak.valueWin[j];
				if (flag)
				{
					num2++;
				}
			}
			bool flag2 = num2 < 6;
			if (flag2)
			{
				this.valuePlay[i][1] = 1;
				num++;
			}
			else
			{
				this.valuePlay[i][1] = 0;
			}
			bool flag3 = num >= ScreenBilak.strListPlayer.Length / 2;
			if (flag3)
			{
				break;
			}
		}
		ScreenBilak.demTop = num;
	}

	// Token: 0x06000D9C RID: 3484 RVA: 0x001069F4 File Offset: 0x00104BF4
	public new void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
			ScreenBilak.ValueAction = 0;
			return;
		case 1:
			ScreenBilak.ValueAction = 1;
			return;
		case 2:
		{
			this.strSauCheck = new string[ScreenBilak.demNG];
			bool flag = this.strSauCheck.Length % 2 == 1;
			if (flag)
			{
				mSystem.outz("Danh sach nguoi choi le: " + this.strSauCheck.Length.ToString());
				this.strLe = "Danh sach nguoi choi le: " + this.strSauCheck.Length.ToString();
				return;
			}
			this.strLe = string.Empty;
			this.getStrSauCheck();
			bool flag2 = ScreenBilak.demTop >= this.strSauCheck.Length / 2;
			if (flag2)
			{
				mSystem.outz("Top đang quá nữa danh sách" + ScreenBilak.demTop.ToString() + "/" + this.strSauCheck.Length.ToString());
				this.strLe = "Top đang quá nữa danh sách" + ScreenBilak.demTop.ToString() + "/" + this.strSauCheck.Length.ToString();
				return;
			}
			ScreenBilak.valueTeam = new int[this.strSauCheck.Length];
			for (int i = 0; i < ScreenBilak.valueTeam.Length; i++)
			{
				bool flag3 = i == ScreenBilak.demTop;
				if (flag3)
				{
					for (int j = 0; j < ScreenBilak.demTop; j++)
					{
						bool flag4 = CRes.random(2) == 0;
						if (flag4)
						{
							ScreenBilak.valueTeam[j]++;
						}
					}
				}
				bool flag5 = i < ScreenBilak.demTop;
				if (flag5)
				{
					ScreenBilak.valueTeam[i] = CRes.random(this.strSauCheck.Length / 2) * 2;
					bool flag6 = i <= 0;
					if (!flag6)
					{
						bool flag7 = false;
						while (!flag7)
						{
							bool flag8 = false;
							for (int k = 0; k < i; k++)
							{
								bool flag9 = ScreenBilak.valueTeam[i] == ScreenBilak.valueTeam[k];
								if (flag9)
								{
									flag8 = true;
								}
							}
							bool flag10 = !flag8;
							if (flag10)
							{
								flag7 = true;
							}
							else
							{
								ScreenBilak.valueTeam[i] = CRes.random(this.strSauCheck.Length / 2) * 2;
							}
						}
					}
				}
				else
				{
					bool flag11 = false;
					ScreenBilak.valueTeam[i] = CRes.random(this.strSauCheck.Length);
					while (!flag11)
					{
						bool flag12 = false;
						for (int l = 0; l < i; l++)
						{
							bool flag13 = ScreenBilak.valueTeam[i] == ScreenBilak.valueTeam[l];
							if (flag13)
							{
								flag12 = true;
							}
						}
						bool flag14 = !flag12;
						if (flag14)
						{
							flag11 = true;
						}
						else
						{
							ScreenBilak.valueTeam[i] = CRes.random(this.strSauCheck.Length);
						}
					}
				}
			}
			this.stListPlayerFight = new string[this.strSauCheck.Length];
			for (int m = 0; m < this.stListPlayerFight.Length; m++)
			{
				for (int n = 0; n < ScreenBilak.valueTeam.Length; n++)
				{
					bool flag15 = ScreenBilak.valueTeam[n] == m;
					if (flag15)
					{
						this.stListPlayerFight[m] = this.strSauCheck[n];
					}
				}
			}
			this.strRMS = string.Empty;
			mSystem.outz("===--- Chia Doi ---===");
			for (int num = 0; num < ScreenBilak.valueTeam.Length / 4; num++)
			{
				string text = string.Concat(new string[]
				{
					this.stListPlayerFight[num * 4],
					"-",
					this.stListPlayerFight[num * 4 + 1],
					" VS ",
					this.stListPlayerFight[num * 4 + 2],
					"-",
					this.stListPlayerFight[num * 4 + 3]
				});
				mSystem.outz(text);
				this.strRMS = this.strRMS + text + "\n";
			}
			bool flag16 = ScreenBilak.valueTeam.Length / 2 % 2 == 1;
			if (flag16)
			{
				string text2 = "Doi le " + this.stListPlayerFight[this.stListPlayerFight.Length - 1] + "-" + this.stListPlayerFight[this.stListPlayerFight.Length - 2];
				mSystem.outz(text2);
				this.strRMS += text2;
			}
			ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
			DataOutputStream dataOutputStream = new DataOutputStream(byteArrayOutputStream);
			try
			{
				dataOutputStream.writeUTF(this.strRMS);
				CRes.saveRMS("SUB_BILAK", byteArrayOutputStream.toByteArray());
				dataOutputStream.close();
				return;
			}
			catch (Exception)
			{
				return;
			}
			break;
		}
		case 3:
			break;
		case 4:
			ScreenBilak.ValueAction = 2;
			return;
		case 5:
			ScreenBilak.ValueAction = 3;
			return;
		case 6:
			this.autoSetTop6();
			return;
		case 7:
			this.stListPlayerFight = null;
			return;
		default:
			return;
		}
		string info = "Không có dữ liệu";
		bool flag17 = this.strRMS.Length > 0;
		if (flag17)
		{
			info = this.strRMS;
		}
		GameCanvas.Start_Normal_Only_CmdClose_DiaLog(info);
	}

	// Token: 0x06000D9D RID: 3485 RVA: 0x00106F4C File Offset: 0x0010514C
	private void getStrSauCheck()
	{
		int num = 0;
		for (int i = 0; i < ScreenBilak.strListPlayer.Length; i++)
		{
			bool flag = this.valuePlay[i][0] == 1 && this.valuePlay[i][1] == 1;
			if (flag)
			{
				this.strSauCheck[num] = ScreenBilak.strListPlayer[i];
				num++;
			}
		}
		for (int j = 0; j < ScreenBilak.strListPlayer.Length; j++)
		{
			bool flag2 = this.valuePlay[j][1] == 0 && this.valuePlay[j][0] == 1;
			if (flag2)
			{
				this.strSauCheck[num] = ScreenBilak.strListPlayer[j];
				num++;
			}
		}
	}

	// Token: 0x06000D9E RID: 3486 RVA: 0x00107004 File Offset: 0x00105204
	public new void paint(mGraphics g)
	{
		g.setColor(0);
		g.fillRect(0, 0, MotherCanvas.w, MotherCanvas.h);
		for (int i = 0; i < ScreenBilak.strListPlayer.Length; i++)
		{
			g.setColor(728640);
			bool flag = this.valuePlay[i][0] == 1;
			if (flag)
			{
				bool flag2 = this.valuePlay[i][1] == 1;
				if (flag2)
				{
					g.setColor(12200257);
				}
				else
				{
					g.setColor(5159465);
				}
			}
			g.fillRect(2 + i / 10 * 60, 2 + i % 10 * 24, 50, 20);
			mFont.tahoma_7b_yellow.drawString(g, string.Empty + ScreenBilak.valueWin[i].ToString(), 9 + i / 10 * 60, 6 + i % 10 * 24, 2);
			mFont.tahoma_7b_white.drawString(g, ScreenBilak.strListPlayer[i], 16 + i / 10 * 60, 6 + i % 10 * 24, 0);
		}
		mFont.tahoma_7b_green.drawString(g, this.strSoNguoi, MotherCanvas.hw, 105, 2);
		mFont.tahoma_7b_red.drawString(g, this.strTop, MotherCanvas.hw, 125, 2);
		int num = 155;
		bool flag3 = this.stListPlayerFight != null;
		if (flag3)
		{
			int num2 = num + ScreenBilak.valueTeam.Length / 4 * 24 + 24;
			bool flag4 = ScreenBilak.valueTeam.Length / 2 % 2 == 1;
			if (flag4)
			{
				num2 += 24;
			}
			bool flag5 = num2 > MotherCanvas.h;
			if (flag5)
			{
				num -= num2 - MotherCanvas.h;
			}
			g.setColor(8882193);
			g.fillRect(MotherCanvas.hw - 60, num - 5, 120, 20);
			mFont.tahoma_7b_white.drawString(g, "Chia Cặp", MotherCanvas.hw, num, 2);
			num += 24;
			for (int j = 0; j < ScreenBilak.valueTeam.Length / 4; j++)
			{
				g.setColor(8882221);
				g.fillRect(MotherCanvas.hw - 100, num - 5, 200, 20);
				mFont.tahoma_7b_white.drawString(g, this.stListPlayerFight[j * 4] + "-" + this.stListPlayerFight[j * 4 + 1] + " VS", MotherCanvas.hw, num, 1);
				mFont.tahoma_7b_white.drawString(g, " " + this.stListPlayerFight[j * 4 + 2] + "-" + this.stListPlayerFight[j * 4 + 3], MotherCanvas.hw, num, 0);
				num += 24;
			}
			bool flag6 = ScreenBilak.valueTeam.Length / 2 % 2 == 1;
			if (flag6)
			{
				g.setColor(8882221);
				g.fillRect(MotherCanvas.hw - 80, num - 5, 160, 20);
				mFont.tahoma_7b_white.drawString(g, "Đội lẻ " + this.stListPlayerFight[this.stListPlayerFight.Length - 1] + "-" + this.stListPlayerFight[this.stListPlayerFight.Length - 2], MotherCanvas.hw, num, 2);
			}
		}
		else
		{
			bool flag7 = this.strLe.Length > 0;
			if (flag7)
			{
				mFont.tahoma_7b_white.drawString(g, this.strLe, MotherCanvas.hw, num, 2);
			}
		}
		for (int k = 0; k < this.vecCmd.size(); k++)
		{
			iCommand iCommand = (iCommand)this.vecCmd.elementAt(k);
			iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
		}
		base.paint(g);
	}

	// Token: 0x06000D9F RID: 3487 RVA: 0x001073C0 File Offset: 0x001055C0
	public new void updatePointer()
	{
		bool flag = false;
		for (int i = 0; i < ScreenBilak.strListPlayer.Length; i++)
		{
			bool flag2 = !GameCanvas.isPointerSelect || !GameCanvas.isPoint(2 + i / 10 * 60, 2 + i % 10 * 24, 50, 20);
			if (!flag2)
			{
				bool flag3 = ScreenBilak.ValueAction == 1;
				if (flag3)
				{
					bool flag4 = this.valuePlay[i][1] == 1;
					if (flag4)
					{
						this.valuePlay[i][1] = 0;
					}
					bool flag5 = this.valuePlay[i][0] == 1;
					if (flag5)
					{
						this.valuePlay[i][0] = 0;
					}
					else
					{
						this.valuePlay[i][0] = 1;
					}
				}
				else
				{
					bool flag6 = ScreenBilak.ValueAction == 0;
					if (flag6)
					{
						bool flag7 = this.valuePlay[i][0] == 0;
						if (flag7)
						{
							this.valuePlay[i][0] = 1;
						}
						bool flag8 = this.valuePlay[i][1] == 1;
						if (flag8)
						{
							this.valuePlay[i][1] = 0;
						}
						else
						{
							this.valuePlay[i][1] = 1;
						}
					}
					else
					{
						bool flag9 = ScreenBilak.ValueAction == 2;
						if (flag9)
						{
							ScreenBilak.valueWin[i]++;
						}
						else
						{
							bool flag10 = ScreenBilak.ValueAction == 3;
							if (flag10)
							{
								ScreenBilak.valueWin[i]--;
							}
						}
						ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
						DataOutputStream dataOutputStream = new DataOutputStream(byteArrayOutputStream);
						try
						{
							for (int j = 0; j < ScreenBilak.valueWin.Length; j++)
							{
								dataOutputStream.writeByte((sbyte)ScreenBilak.valueWin[j]);
							}
							CRes.saveRMS("SUB_BILAK_TOP", byteArrayOutputStream.toByteArray());
							dataOutputStream.close();
						}
						catch (Exception)
						{
						}
					}
				}
				GameCanvas.isPointerSelect = false;
				flag = true;
			}
		}
		bool flag11 = flag;
		if (flag11)
		{
			ScreenBilak.demNG = 0;
			ScreenBilak.demTop = 0;
			for (int k = 0; k < ScreenBilak.strListPlayer.Length; k++)
			{
				bool flag12 = this.valuePlay[k][0] == 1;
				if (flag12)
				{
					ScreenBilak.demNG++;
				}
				bool flag13 = this.valuePlay[k][1] == 1;
				if (flag13)
				{
					ScreenBilak.demTop++;
				}
			}
			this.strSoNguoi = "Số người chơi: " + ScreenBilak.demNG.ToString();
			this.strTop = "Số Top: " + ScreenBilak.demTop.ToString();
		}
		for (int l = 0; l < this.vecCmd.size(); l++)
		{
			iCommand iCommand = (iCommand)this.vecCmd.elementAt(l);
			iCommand.updatePointer();
		}
		base.updatePointer();
	}

	// Token: 0x040014D3 RID: 5331
	private mVector vecCmd = new mVector();

	// Token: 0x040014D4 RID: 5332
	private iCommand cmdSetTop;

	// Token: 0x040014D5 RID: 5333
	private iCommand cmdOff;

	// Token: 0x040014D6 RID: 5334
	private iCommand cmdMyRandom;

	// Token: 0x040014D7 RID: 5335
	private iCommand cmdTableAfter;

	// Token: 0x040014D8 RID: 5336
	private iCommand cmdSetCongWin;

	// Token: 0x040014D9 RID: 5337
	private iCommand cmdSetTruWin;

	// Token: 0x040014DA RID: 5338
	private iCommand cmdTop6;

	// Token: 0x040014DB RID: 5339
	private iCommand cmdOffTable;

	// Token: 0x040014DC RID: 5340
	private int[][] valuePlay;

	// Token: 0x040014DD RID: 5341
	private string strSoNguoi = "Số người chơi: ";

	// Token: 0x040014DE RID: 5342
	private string strTop = "Số Top: ";

	// Token: 0x040014DF RID: 5343
	private string strLe = string.Empty;

	// Token: 0x040014E0 RID: 5344
	private string strRMS = string.Empty;

	// Token: 0x040014E1 RID: 5345
	private string[] strSauCheck;

	// Token: 0x040014E2 RID: 5346
	public static string[] strListPlayer = new string[]
	{
		"Phong",
		"Trung",
		"Hanh",
		"Hieu",
		"Vu de",
		"Lam",
		"Jacky",
		"Thang",
		"Khoi",
		"Quan",
		"Thai",
		"Giang",
		"Xuan",
		"Phi",
		"Trong",
		"Carot",
		"Vu ca",
		"Tri"
	};

	// Token: 0x040014E3 RID: 5347
	public static int[] valueTeam;

	// Token: 0x040014E4 RID: 5348
	public static int[] valueWin;

	// Token: 0x040014E5 RID: 5349
	public static int ValueAction = 0;

	// Token: 0x040014E6 RID: 5350
	private string[] stListPlayerFight;

	// Token: 0x040014E7 RID: 5351
	public static int demNG;

	// Token: 0x040014E8 RID: 5352
	public static int demTop;
}
