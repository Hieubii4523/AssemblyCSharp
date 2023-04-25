using System;

// Token: 0x02000069 RID: 105
public class ListChar_Screen : MainScreen
{
	// Token: 0x0600066A RID: 1642 RVA: 0x0008D3A0 File Offset: 0x0008B5A0
	public static ListChar_Screen gI()
	{
		bool flag = GameCanvas.listCharScr == null;
		if (flag)
		{
			GameCanvas.listCharScr = new ListChar_Screen();
		}
		return GameCanvas.listCharScr;
	}

	// Token: 0x0600066B RID: 1643 RVA: 0x000092E5 File Offset: 0x000074E5
	public override void setxyPlus12()
	{
		GameCanvas.xPlus12 = 2;
		GameCanvas.yPlus12 = 2;
	}

	// Token: 0x0600066C RID: 1644 RVA: 0x0008D3D0 File Offset: 0x0008B5D0
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
		{
			bool flag = ListChar_Screen.isDelChar;
			if (flag)
			{
				ListChar_Screen.isDelChar = false;
				this.setCmd();
			}
			else
			{
				bool flag2 = this.selectChar > ListChar_Screen.vecListChar.size() - 1;
				if (flag2)
				{
					CreateChar_Screen.gI().Show(this);
				}
				else
				{
					Other_Player other_Player = (Other_Player)ListChar_Screen.vecListChar.elementAt(this.selectChar);
					bool flag3 = other_Player.typeSpecCharList == 1;
					if (flag3)
					{
						GlobalService.gI().Del_Char(1, other_Player.ID);
					}
					else
					{
						bool flag4 = this.typeSelect == 0;
						if (flag4)
						{
							ListChar_Screen.IndexCharSelected = (sbyte)this.selectChar;
							ListChar_Screen.IDChar = other_Player.ID;
							other_Player.Action = 2;
							other_Player.f = 0;
							this.typeSelect = 2;
							this.setCmd();
						}
						else
						{
							bool flag5 = this.typeSelect == 1;
							if (flag5)
							{
								bool flag6 = other_Player.ID != ListChar_Screen.IDChar;
								if (flag6)
								{
									other_Player.Action = 2;
									other_Player.f = 0;
									this.typeSelect = 2;
									other_Player.strChatPopup = T.toisegiup;
								}
							}
							else
							{
								bool flag7 = this.typeSelect == 2;
								if (flag7)
								{
									GlobalService.gI().Select_Char(ListChar_Screen.IDChar, 1, other_Player.ID);
									GlobalService.gI().get_DATA(3);
									GameCanvas.Start_Waiting_DiaLog(T.pleaseWaiting, false);
									GameCanvas.saveRms.saveUserPass(GameCanvas.loginScr.tfUser.getText(), GameCanvas.loginScr.tfPass.getText());
								}
							}
						}
					}
				}
			}
			break;
		}
		case 1:
			GameCanvas.loginScr.Show();
			break;
		case 2:
		{
			bool flag8 = ListChar_Screen.isDelChar;
			if (flag8)
			{
				bool flag9 = !GameCanvas.isTouch;
				if (flag9)
				{
					this.commandPointer(4, this.selectChar);
				}
			}
			else
			{
				GameCanvas.Start_Normal_DiaLog(T.hoiXoaChar, new iCommand("Ok", 3, this), true);
			}
			break;
		}
		case 3:
			ListChar_Screen.isDelChar = true;
			this.setCmd();
			GameCanvas.end_Dialog();
			break;
		case 4:
		{
			this.selectChar = subIndex;
			bool flag10 = this.selectChar < 0 || this.selectChar >= ListChar_Screen.vecListChar.size();
			if (flag10)
			{
				return;
			}
			Other_Player other_Player2 = (Other_Player)ListChar_Screen.vecListChar.elementAt(this.selectChar);
			GlobalService.gI().Del_Char(0, other_Player2.ID);
			GameCanvas.Start_Waiting_DiaLog(T.pleaseWaiting, true);
			break;
		}
		case 5:
			GlobalService.gI().Select_Char(ListChar_Screen.IDChar, 0, 0);
			GlobalService.gI().get_DATA(3);
			GameCanvas.saveRms.saveUserPass(GameCanvas.loginScr.tfUser.getText(), GameCanvas.loginScr.tfPass.getText());
			break;
		}
		base.commandPointer(index, subIndex);
	}

	// Token: 0x0600066D RID: 1645 RVA: 0x0008D6C4 File Offset: 0x0008B8C4
	public override void Show()
	{
		this.center = null;
		this.left = null;
		this.right = null;
		this.okCMD = null;
		this.typeSelect = 0;
		ListChar_Screen.isDelChar = false;
		this.timeSpec = 0;
		this.mPosShow = mSystem.new_M_Int(3, 2);
		this.mPosShow[0][0] = MotherCanvas.hw;
		this.mPosShow[0][1] = MotherCanvas.h - 50;
		this.mPosShow[1][0] = MotherCanvas.hw - 60;
		this.mPosShow[1][1] = MotherCanvas.h - 40;
		this.mPosShow[2][0] = MotherCanvas.hw + 60;
		this.mPosShow[2][1] = MotherCanvas.h - 40;
		this.cmdSelect = new iCommand(T.select, 0, this);
		this.cmdExit = new iCommand(T.exit, 1, this);
		this.cmdExit = AvMain.setPosCMD(this.cmdExit, 1);
		this.cmdStart = new iCommand(T.startgame, 5, this);
		this.cmdStart = AvMain.setPosCMD(this.cmdStart, 0);
		bool flag = !GameCanvas.isTouch;
		if (flag)
		{
			this.cmdStart = AvMain.setPosCMD(this.cmdStart, 2);
		}
		this.cmdDelChar = new iCommand(T.delChar, 2, this);
		this.cmdDelChar = AvMain.setPosCMD(this.cmdDelChar, 2);
		this.setCmd();
		for (int i = 0; i < ListChar_Screen.vecListChar.size(); i++)
		{
			Other_Player other_Player = (Other_Player)ListChar_Screen.vecListChar.elementAt(i);
			other_Player.x = this.mPosShow[i][0];
			other_Player.y = this.mPosShow[i][1];
		}
		GameScreen.player = null;
		bool flag2 = GameCanvas.mapBack == null;
		if (flag2)
		{
			GameCanvas.mapBack = new MapBackGround();
		}
		bool flag3 = GameCanvas.currentScreen != GameCanvas.loginScr && GameCanvas.currentScreen != CreateChar_Screen.gI();
		if (flag3)
		{
			GameCanvas.mapBack.setBGLogin();
		}
		bool flag4 = GameCanvas.currentScreen == GameCanvas.loginScr;
		if (flag4)
		{
			this.selectChar = 0;
		}
		this.boat.isPaint = true;
		bool flag5 = LoadMapScreen.isMapSky != 0;
		if (flag5)
		{
			LoadMapScreen.isMapSky = 0;
			LoadImageStatic.loadImageEffBoat();
		}
		base.Show();
		GameCanvas.clearAll();
	}

	// Token: 0x0600066E RID: 1646 RVA: 0x0008D90C File Offset: 0x0008BB0C
	public override void paint(mGraphics g)
	{
		try
		{
			bool flag = GameCanvas.mapBack != null;
			if (flag)
			{
				GameCanvas.mapBack.paintBgLogin(g);
				GameCanvas.mapBack.paintObjFristLogin(g);
			}
		}
		catch (Exception)
		{
		}
		LoginScreen.paintLogo(g, MotherCanvas.hw);
		for (int i = 0; i < this.vecDelButton.size(); i++)
		{
			iCommand iCommand = (iCommand)this.vecDelButton.elementAt(i);
			iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
		}
		bool isPaint = this.boat.isPaint;
		if (isPaint)
		{
			this.boat.paintFrist(g);
			this.boat.paintBuom(g);
			this.boat.paintLast(g, GameCanvas.Day_Night);
		}
		for (int j = 0; j < 3; j++)
		{
			bool flag2 = j < ListChar_Screen.vecListChar.size();
			if (flag2)
			{
				Other_Player other_Player = (Other_Player)ListChar_Screen.vecListChar.elementAt(j);
				other_Player.paintShadow(g, other_Player.x);
				int y = other_Player.y - other_Player.dy;
				bool flag3 = other_Player.boatSea != null;
				if (flag3)
				{
					other_Player.boatSea.paintFrist(g);
					other_Player.boatSea.paintBuom(g);
					y = other_Player.y - this.dySea / 10;
				}
				other_Player.paintCharSelect(g, other_Player.x, y, other_Player.type_left_right, other_Player.frame);
				bool flag4 = other_Player.boatSea != null;
				if (flag4)
				{
					other_Player.boatSea.paintLast(g, GameCanvas.Day_Night);
				}
			}
			else
			{
				bool flag5 = !ListChar_Screen.isDelChar;
				if (flag5)
				{
					g.drawImage(MainObject.imgShadow, this.mPosShow[j][0] + 1, this.mPosShow[j][1], 3);
					bool flag6 = j < 2 || ListChar_Screen.vecListChar.size() > 1;
					if (flag6)
					{
						AvMain.paintRect(g, this.mPosShow[j][0] - 18, this.mPosShow[j][1] - 32, 36, 16, 1, 4);
						mFont.tahoma_7b_white.drawString(g, T.create, this.mPosShow[j][0], this.mPosShow[j][1] - 30, 2);
					}
				}
			}
			bool flag7 = j == this.selectChar && GameCanvas.isTouchNoOrPC();
			if (flag7)
			{
				bool flag8 = ListChar_Screen.isDelChar;
				if (flag8)
				{
					g.drawImage(AvMain.imgIconDel, this.mPosShow[j][0], this.mPosShow[j][1] - 52, 3);
				}
				else
				{
					this.paintFocus(g, this.mPosShow[j][0], this.mPosShow[j][1] - 52);
				}
			}
		}
		bool flag9 = GameCanvas.mapBack != null;
		if (flag9)
		{
			GameCanvas.mapBack.paintObjLastLogin(g);
		}
		for (int k = 0; k < ListChar_Screen.vecListChar.size(); k++)
		{
			bool flag10 = k < ListChar_Screen.vecListChar.size();
			if (flag10)
			{
				Other_Player other_Player2 = (Other_Player)ListChar_Screen.vecListChar.elementAt(k);
				sbyte color = 0;
				bool flag11 = other_Player2.typeSpecCharList == 1;
				if (flag11)
				{
					color = 6;
				}
				else
				{
					bool flag12 = other_Player2.typeSpecCharList == 2;
					if (flag12)
					{
						color = 3;
					}
				}
				other_Player2.paintName(g, color, -1);
				other_Player2.paintLV(g, color);
				bool flag13 = other_Player2.chat != null;
				if (flag13)
				{
					other_Player2.chat.paint(g);
				}
			}
		}
		bool flag14 = this.right != null;
		if (flag14)
		{
			this.right.paint(g, this.right.xCmd, this.right.yCmd);
		}
	}

	// Token: 0x0600066F RID: 1647 RVA: 0x0008DD00 File Offset: 0x0008BF00
	public void paintFocus(mGraphics g, int x, int y)
	{
		bool flag = AvMain.fraIconfocus.nFrame == 1;
		if (flag)
		{
			g.drawImage(AvMain.fraIconfocus.imgFrame, x, y - GameCanvas.gameTick % 5, 3);
		}
		else
		{
			bool flag2 = ListChar_Screen.isNextFrame;
			if (flag2)
			{
				bool flag3 = GameCanvas.gameTick % 3 == 0;
				if (flag3)
				{
					ListChar_Screen.frameIconfocus++;
				}
				bool flag4 = ListChar_Screen.frameIconfocus >= AvMain.fraIconfocus.nFrame - 1;
				if (flag4)
				{
					ListChar_Screen.isNextFrame = false;
				}
			}
			else
			{
				bool flag5 = GameCanvas.gameTick % 3 == 0;
				if (flag5)
				{
					ListChar_Screen.frameIconfocus--;
				}
				bool flag6 = ListChar_Screen.frameIconfocus <= 0;
				if (flag6)
				{
					ListChar_Screen.isNextFrame = true;
				}
			}
			AvMain.fraIconfocus.drawFrame(ListChar_Screen.frameIconfocus, x, y - 3, 0, 3, g);
		}
	}

	// Token: 0x06000670 RID: 1648 RVA: 0x0008DDDC File Offset: 0x0008BFDC
	public override void update()
	{
		LoginScreen.updateYPaintLogo(LoginScreen.hLogo);
		bool flag = ListChar_Screen.vecListChar.size() > 1;
		if (flag)
		{
			CRes.quickSort(ListChar_Screen.vecListChar);
		}
		this.boat.updateXY(MotherCanvas.w / 7 * 4, MotherCanvas.h - 105, this.dySea / 10, (sbyte)this.boat.Dir);
		this.updateDySea();
		bool flag2 = GameCanvas.mapBack != null;
		if (flag2)
		{
			GameCanvas.mapBack.updateCloudLogin();
		}
		bool flag3 = this.timeSpec % 100 == 0;
		if (flag3)
		{
			int num = this.timeSpec / 100 % 3;
			bool flag4 = num < ListChar_Screen.vecListChar.size();
			if (flag4)
			{
				Other_Player other_Player = (Other_Player)ListChar_Screen.vecListChar.elementAt(num);
				bool flag5 = other_Player.typeSpecCharList == 1;
				if (flag5)
				{
					other_Player.strChatPopup = T.chatXoaChar + " " + CRes.getDay((int)other_Player.timeDie);
				}
				else
				{
					bool flag6 = other_Player.typeSpecCharList == 2;
					if (flag6)
					{
						other_Player.strChatPopup = T.chatKhoaChar + " " + CRes.getDay((int)other_Player.timeDie);
					}
					else
					{
						this.timeSpec += 90;
					}
				}
			}
		}
		int i = 0;
		while (i < ListChar_Screen.vecListChar.size())
		{
			Other_Player other_Player2 = (Other_Player)ListChar_Screen.vecListChar.elementAt(i);
			other_Player2.ySort = other_Player2.y;
			other_Player2.updateChatPopup(14);
			other_Player2.updateDirPaint();
			other_Player2.f++;
			bool flag7 = other_Player2.Action == 0;
			if (flag7)
			{
				bool flag8 = other_Player2.f > other_Player2.feStand.Length - 1;
				if (flag8)
				{
					other_Player2.f = 0;
				}
				other_Player2.frame = other_Player2.feStand[other_Player2.f];
			}
			else
			{
				bool flag9 = other_Player2.Action == 2;
				if (flag9)
				{
					bool flag10 = other_Player2.f > this.mActionFire.Length - 1;
					if (flag10)
					{
						other_Player2.f = 0;
						other_Player2.Action = 1;
						other_Player2.toX = this.boat.x - 10;
						other_Player2.toY = this.boat.y + 24;
						bool flag11 = this.typeSelect == 2;
						if (flag11)
						{
							this.cmdSelect.perform();
						}
					}
					else
					{
						other_Player2.frame = this.mActionFire[other_Player2.f];
					}
				}
				else
				{
					bool flag12 = other_Player2.Action == 1;
					if (flag12)
					{
						bool flag13 = other_Player2.f > other_Player2.feRun.Length - 1;
						if (flag13)
						{
							other_Player2.f = 0;
						}
						other_Player2.frame = other_Player2.feRun[other_Player2.f];
						other_Player2.x += other_Player2.vx;
						other_Player2.y += other_Player2.vy;
						bool flag14 = MainObject.getDistance(other_Player2.x, other_Player2.y, other_Player2.toX, other_Player2.toY) < 12;
						if (flag14)
						{
							other_Player2.vx = 0;
							other_Player2.vy = 0;
							other_Player2.Action = 5;
							bool flag15 = this.typeSelect == 1;
							if (flag15)
							{
								other_Player2.vx = (this.boat.x - 10 - other_Player2.x) / 6;
								other_Player2.vy = (this.boat.y - other_Player2.y) / 6;
							}
							else
							{
								other_Player2.vx = (this.boat.x - 10 - other_Player2.x) / 6;
								other_Player2.vy = (this.boat.y - 2 - other_Player2.y) / 6;
							}
							other_Player2.f = 0;
							other_Player2.type_left_right = 2;
							other_Player2.Dir = 2;
						}
						else
						{
							other_Player2.move_to_XY_Normal();
						}
					}
					else
					{
						bool flag16 = other_Player2.Action != 5;
						if (!flag16)
						{
							other_Player2.x += other_Player2.vx;
							other_Player2.y += other_Player2.vy;
							other_Player2.frame = 60;
							bool flag17 = other_Player2.f < 2;
							if (flag17)
							{
								other_Player2.dy = (other_Player2.f + 1) * 5;
							}
							else
							{
								bool flag18 = other_Player2.f == 2 || other_Player2.f == 3;
								if (flag18)
								{
									other_Player2.dy = 12;
								}
								else
								{
									bool flag19 = other_Player2.dy > 3;
									if (flag19)
									{
										other_Player2.dy = 12 - (other_Player2.f - 3) * 5;
									}
								}
							}
							bool flag20 = other_Player2.f != 5;
							if (!flag20)
							{
								other_Player2.dy = 0;
								other_Player2.Action = 0;
								other_Player2.vx = 0;
								other_Player2.vy = 0;
								bool flag21 = this.typeSelect == 1;
								if (flag21)
								{
									other_Player2.x = this.boat.x - 10;
									other_Player2.y = this.boat.y;
									this.boat.isPaint = false;
									other_Player2.boatSea = this.boat;
									bool flag22 = ListChar_Screen.vecListChar.size() > 1;
									if (flag22)
									{
										other_Player2.strChatPopup = T.chonhotro;
									}
								}
								else
								{
									other_Player2.x = this.boat.x - 30;
									other_Player2.y = this.boat.y - 2;
								}
								bool flag23 = ListChar_Screen.vecListChar.size() == 1;
								if (flag23)
								{
									GlobalService.gI().Select_Char(ListChar_Screen.IDChar, 0, other_Player2.ID);
									GlobalService.gI().get_DATA(3);
									GameCanvas.Start_Waiting_DiaLog(T.pleaseWaiting, false);
								}
								break;
							}
						}
					}
				}
			}
			IL_5E2:
			i++;
			continue;
			goto IL_5E2;
		}
		this.timeSpec++;
		bool flag24 = this.typeSelect != 1 || ListChar_Screen.vecListChar.size() <= 1;
		if (!flag24)
		{
			bool flag25 = this.selectChar >= 0 && this.selectChar < ListChar_Screen.vecListChar.size();
			if (flag25)
			{
				bool flag26 = this.selectChar == (int)ListChar_Screen.IndexCharSelected;
				if (flag26)
				{
					this.selectChar++;
				}
			}
			else
			{
				this.selectChar++;
			}
		}
	}

	// Token: 0x06000671 RID: 1649 RVA: 0x0008E478 File Offset: 0x0008C678
	public override void updatekey()
	{
		bool flag = this.typeSelect == 2;
		if (!flag)
		{
			bool flag2 = GameCanvas.keyMove(0);
			if (flag2)
			{
				bool flag3 = this.typeSelect == 1 && ListChar_Screen.IndexCharSelected == 1;
				if (flag3)
				{
					bool flag4 = this.selectChar == 2;
					if (flag4)
					{
						this.selectChar = 0;
					}
				}
				else
				{
					bool flag5 = this.selectChar == 0 || ListChar_Screen.vecListChar.size() > 1;
					if (flag5)
					{
						bool flag6 = this.selectChar == 0;
						if (flag6)
						{
							this.selectChar = 1;
						}
						else
						{
							bool flag7 = this.selectChar == 1;
							if (flag7)
							{
								this.selectChar = 2;
							}
							else
							{
								bool flag8 = this.selectChar == 2;
								if (flag8)
								{
									this.selectChar = 0;
								}
							}
						}
					}
				}
				GameCanvas.ClearkeyMove(0);
			}
			else
			{
				bool flag9 = GameCanvas.keyMove(2);
				if (flag9)
				{
					bool flag10 = this.typeSelect == 1 && ListChar_Screen.IndexCharSelected == 0;
					if (flag10)
					{
						bool flag11 = this.selectChar == 1;
						if (flag11)
						{
							this.selectChar = 2;
						}
					}
					else
					{
						bool flag12 = this.selectChar == 1 || ListChar_Screen.vecListChar.size() > 1;
						if (flag12)
						{
							bool flag13 = this.selectChar == 0;
							if (flag13)
							{
								this.selectChar = 2;
							}
							else
							{
								bool flag14 = this.selectChar == 1;
								if (flag14)
								{
									this.selectChar = 0;
								}
								else
								{
									bool flag15 = this.selectChar == 2;
									if (flag15)
									{
										this.selectChar = 1;
									}
								}
							}
						}
					}
					GameCanvas.ClearkeyMove(2);
				}
			}
			bool flag16 = ListChar_Screen.isDelChar;
			if (flag16)
			{
				this.selectChar = AvMain.resetSelect(this.selectChar, ListChar_Screen.vecListChar.size() - 1, true);
			}
			else
			{
				this.selectChar = AvMain.resetSelect(this.selectChar, 2, true);
			}
			base.updatekey();
		}
	}

	// Token: 0x06000672 RID: 1650 RVA: 0x0008E658 File Offset: 0x0008C858
	public override void updatePointer()
	{
		bool flag = this.typeSelect == 2;
		if (!flag)
		{
			bool isPointerSelect = GameCanvas.isPointerSelect;
			if (isPointerSelect)
			{
				for (int i = 0; i < this.mPosShow.Length; i++)
				{
					bool flag2 = !GameCanvas.isPoint(this.mPosShow[i][0] - this.wpl / 2, this.mPosShow[i][1] - this.hpl + 10, this.wpl, this.hpl);
					if (!flag2)
					{
						bool flag3 = ListChar_Screen.isDelChar;
						if (flag3)
						{
							bool flag4 = i < ListChar_Screen.vecListChar.size();
							if (flag4)
							{
								this.selectChar = i;
								this.cmdDelChar.perform();
							}
						}
						else
						{
							bool flag5 = i <= ListChar_Screen.vecListChar.size();
							if (flag5)
							{
								this.selectChar = i;
								this.cmdSelect.perform();
							}
						}
						GameCanvas.isPointerSelect = false;
						break;
					}
				}
			}
			for (int j = 0; j < this.vecDelButton.size(); j++)
			{
				iCommand iCommand = (iCommand)this.vecDelButton.elementAt(j);
				iCommand.updatePointer();
			}
			base.updatePointer();
		}
	}

	// Token: 0x06000673 RID: 1651 RVA: 0x0008E798 File Offset: 0x0008C998
	public void setCmd()
	{
		this.vecDelButton.removeAllElements();
		bool flag = ListChar_Screen.isDelChar;
		if (flag)
		{
			bool flag2 = GameCanvas.isTouchNoOrPC();
			if (flag2)
			{
				this.cmdDelChar = new iCommand(T.delChar, 2, this);
				this.center = this.cmdDelChar;
			}
			this.cmdSelect = new iCommand(T.back, 0, this);
			this.cmdSelect = AvMain.setPosCMD(this.cmdSelect, 2);
			this.right = this.cmdSelect;
			this.left = this.cmdExit;
			bool isTouch = GameCanvas.isTouch;
			if (isTouch)
			{
				for (int i = 0; i < ListChar_Screen.vecListChar.size(); i++)
				{
					Other_Player other_Player = (Other_Player)ListChar_Screen.vecListChar.elementAt(i);
					iCommand iCommand = new iCommand(T.del, 4, i, this);
					iCommand.setPos(other_Player.x, other_Player.y - 92, null, iCommand.caption);
					iCommand.levelSmall = 3;
					this.vecDelButton.addElement(iCommand);
				}
			}
		}
		else
		{
			bool flag3 = this.typeSelect == 0;
			if (flag3)
			{
				this.cmdSelect = new iCommand(T.select, 0, this);
				bool flag4 = GameCanvas.isTouchNoOrPC();
				if (flag4)
				{
					this.center = this.cmdSelect;
				}
			}
			else
			{
				bool flag5 = this.typeSelect == 1;
				if (flag5)
				{
					bool flag6 = ListChar_Screen.vecListChar.size() > 1;
					if (flag6)
					{
						this.cmdSelect = new iCommand(T.support, 0, this);
						bool flag7 = GameCanvas.isTouchNoOrPC();
						if (flag7)
						{
							this.center = this.cmdSelect;
						}
						this.left = null;
						this.right = this.cmdStart;
					}
					else
					{
						this.center = null;
						this.left = null;
						this.right = null;
					}
				}
				else
				{
					bool flag8 = this.typeSelect == 2;
					if (flag8)
					{
						this.center = null;
						this.left = null;
						this.right = null;
					}
				}
			}
		}
	}

	// Token: 0x06000674 RID: 1652 RVA: 0x0008E990 File Offset: 0x0008CB90
	private void updateDySea()
	{
		bool flag = CRes.random(40) == 0;
		if (flag)
		{
			bool flag2 = CRes.random(2) == 0;
			if (flag2)
			{
				this.vySea = 4;
			}
			else
			{
				this.vySea = -4;
			}
		}
		bool flag3 = this.dySea > 0 && this.vySea > 0;
		if (flag3)
		{
			this.vySea = -4;
		}
		else
		{
			bool flag4 = this.dySea < -50 && this.vySea < 0;
			if (flag4)
			{
				this.vySea = 4;
			}
		}
		this.dySea += this.vySea;
	}

	// Token: 0x06000675 RID: 1653 RVA: 0x0008EA2C File Offset: 0x0008CC2C
	public override bool keyBack()
	{
		bool flag = !base.keyBack() && this.cmdExit != null;
		if (flag)
		{
			this.cmdExit.perform();
		}
		return false;
	}

	// Token: 0x04000934 RID: 2356
	public const sbyte CHAR_DEL = 1;

	// Token: 0x04000935 RID: 2357
	public const sbyte CHAR_LOCK = 2;

	// Token: 0x04000936 RID: 2358
	public const sbyte SELECT_CHAR = 0;

	// Token: 0x04000937 RID: 2359
	public const sbyte SELECT_SUPPORT = 1;

	// Token: 0x04000938 RID: 2360
	public const sbyte SELECT_OK = 2;

	// Token: 0x04000939 RID: 2361
	private int selectChar;

	// Token: 0x0400093A RID: 2362
	public static mVector vecListChar = new mVector("ListChar_Screen.vecListChar");

	// Token: 0x0400093B RID: 2363
	public int[][] mPosShow;

	// Token: 0x0400093C RID: 2364
	private iCommand cmdSelect;

	// Token: 0x0400093D RID: 2365
	private iCommand cmdExit;

	// Token: 0x0400093E RID: 2366
	private iCommand cmdDelChar;

	// Token: 0x0400093F RID: 2367
	private iCommand cmdStart;

	// Token: 0x04000940 RID: 2368
	public static sbyte IndexCharSelected = -1;

	// Token: 0x04000941 RID: 2369
	public static short IDChar = 0;

	// Token: 0x04000942 RID: 2370
	public static bool isDelChar = false;

	// Token: 0x04000943 RID: 2371
	private int timeSpec;

	// Token: 0x04000944 RID: 2372
	private mVector vecDelButton = new mVector("ListChar_Screen.vecDelButton");

	// Token: 0x04000945 RID: 2373
	private sbyte typeSelect;

	// Token: 0x04000946 RID: 2374
	private int[] mActionFire = new int[]
	{
		8,
		8,
		8,
		9,
		9,
		9,
		10,
		10,
		10,
		10,
		10,
		10,
		10,
		10,
		10
	};

	// Token: 0x04000947 RID: 2375
	private Boat boat = new Boat(0, MotherCanvas.w / 7 * 4, MotherCanvas.h - 105, 0, 2);

	// Token: 0x04000948 RID: 2376
	private static int frameIconfocus = 0;

	// Token: 0x04000949 RID: 2377
	private static bool isNextFrame = true;

	// Token: 0x0400094A RID: 2378
	private int wpl = 40;

	// Token: 0x0400094B RID: 2379
	private int hpl = 80;

	// Token: 0x0400094C RID: 2380
	private int vySea = 4;

	// Token: 0x0400094D RID: 2381
	private int dySea;
}
