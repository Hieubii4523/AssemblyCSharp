using System;

// Token: 0x02000084 RID: 132
public class MainQuest : AvMain
{
	// Token: 0x06000870 RID: 2160 RVA: 0x0000ADAE File Offset: 0x00008FAE
	public MainQuest(short ID)
	{
		this.ID = ID;
	}

	// Token: 0x06000871 RID: 2161 RVA: 0x000AC0BC File Offset: 0x000AA2BC
	public static MainQuest getQuest(short ID)
	{
		for (int i = 0; i < Player.vecQuest.size(); i++)
		{
			MainQuest mainQuest = (MainQuest)Player.vecQuest.elementAt(i);
			bool flag = mainQuest.ID == ID;
			if (flag)
			{
				return mainQuest;
			}
		}
		return null;
	}

	// Token: 0x06000872 RID: 2162 RVA: 0x000AC110 File Offset: 0x000AA310
	public string getMainSub()
	{
		bool flag = this.typeMainSub == 0;
		string result;
		if (flag)
		{
			result = T.main;
		}
		else
		{
			bool flag2 = this.typeMainSub == 2;
			if (flag2)
			{
				result = T.replay;
			}
			else
			{
				bool flag3 = this.typeMainSub == 3;
				if (flag3)
				{
					result = T.Qclan;
				}
				else
				{
					result = T.sub;
				}
			}
		}
		return result;
	}

	// Token: 0x06000873 RID: 2163 RVA: 0x000AC16C File Offset: 0x000AA36C
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
		{
			bool flag = GameCanvas.menuCur.runText == null || GameCanvas.menuCur.runText.nextDlgStep();
			if (flag)
			{
				this.nextStep();
			}
			break;
		}
		case 1:
		{
			bool flag2 = GameCanvas.menuCur.runText == null || GameCanvas.menuCur.runText.nextDlgStep();
			if (flag2)
			{
				MainObject mainObject = MainObject.get_Object(this.idNPC, 2);
				bool flag3 = mainObject != null;
				if (flag3)
				{
					mainObject.chat = null;
				}
				string text = this.strShowDialog;
				bool flag4 = text == null;
				if (flag4)
				{
				}
				GameScreen.player.chat = null;
				iCommand iCommand = this.setCmdDialog();
				Player.curQuest = null;
				GameCanvas.clearKeyHold();
				GameCanvas.isPointerSelect = false;
				GameCanvas.menuCur.isShowMenu = false;
				iCommand.perform();
			}
			break;
		}
		case 2:
		{
			bool flag5 = this.statusQuest == 0 && GameScreen.player.Lv < (int)this.lvRequest && this.typeMainSub == 0;
			if (flag5)
			{
				GameCanvas.menuCur.doCloseMenu();
				GameCanvas.end_Dialog();
			}
			else
			{
				GameCanvas.menuCur.doCloseMenu();
				GlobalService.gI().quest(1, this.ID);
				GameCanvas.end_Dialog();
				GameCanvas.Start_Waiting_DiaLog(T.pleaseWaiting, true);
			}
			break;
		}
		case 3:
			GameCanvas.end_Dialog();
			GameCanvas.menuCur.doCloseMenu();
			this.step = 0;
			Player.curQuest = this;
			this.nextStep();
			break;
		case 4:
			GameCanvas.menuCur.doCloseMenu();
			GlobalService.gI().quest(4, this.ID);
			GameCanvas.end_Dialog();
			GameCanvas.Start_Waiting_DiaLog(T.pleaseWaiting, true);
			Player.idNPCQuestCur = (short)this.idNPC;
			break;
		}
	}

	// Token: 0x06000874 RID: 2164 RVA: 0x000AC348 File Offset: 0x000AA548
	public iCommand setCmdDialog()
	{
		iCommand result = null;
		bool flag = this.statusQuest == 0;
		if (flag)
		{
			result = new iCommand(T.nhanQuest, 3, this);
		}
		else
		{
			bool flag2 = this.statusQuest == 2;
			if (flag2)
			{
				result = new iCommand(T.traQuest, 3, this);
			}
		}
		return result;
	}

	// Token: 0x06000875 RID: 2165 RVA: 0x000AC398 File Offset: 0x000AA598
	public void beginQuest(short IDObj)
	{
		this.step = 0;
		bool flag = this.idNPC == (int)IDObj;
		if (flag)
		{
			bool flag2 = this.statusQuest == 2 || this.statusQuest == 0;
			if (flag2)
			{
				this.commandPointer(0, 0);
			}
			else
			{
				bool flag3 = this.statusQuest == 1;
				if (flag3)
				{
					MainObject mainObject = MainObject.get_Object(this.idNPC, 2);
					bool flag4 = mainObject != null;
					if (flag4)
					{
						mainObject.strChatPopup = this.strNhacNho;
					}
				}
			}
		}
		else
		{
			bool flag5 = this.statusQuest == 2 && this.idNPC_Sub == (int)IDObj;
			if (flag5)
			{
				MainObject mainObject2 = MainObject.get_Object(this.idNPC_Sub, 2);
				bool flag6 = mainObject2 != null;
				if (flag6)
				{
					mainObject2.strChatPopup = this.strNhacNho;
				}
			}
		}
	}

	// Token: 0x06000876 RID: 2166 RVA: 0x000AC460 File Offset: 0x000AA660
	public void nextStep()
	{
		bool flag = MainObject.get_Object(this.idNPC, 2) == null;
		if (flag)
		{
			Player.curQuest = null;
		}
		else
		{
			bool flag2 = this.mstrTalk == null;
			if (flag2)
			{
				bool flag3 = this.statusQuest == 0 && GameScreen.player.Lv < (int)this.lvRequest && this.typeMainSub == 0;
				if (flag3)
				{
					this.mstrTalk = mFont.split(T.strQuestDe + this.lvRequest.ToString() + ".", ">");
				}
				else
				{
					this.mstrTalk = mFont.split(this.strTalk, ">");
				}
			}
			bool flag4 = this.mstrTalk == null;
			if (flag4)
			{
				Player.curQuest = null;
			}
			else
			{
				bool flag5 = this.mstrTalk[this.step].Trim().StartsWith("0");
				if (flag5)
				{
					MainObject.get_Object(this.idNPC, 2).chat = null;
					mVector mVector = new mVector();
					iCommand o = this.setCmd();
					mVector.addElement(o);
					GameCanvas.menu.startAt_NPC_Quest(mVector, GameMidlet.SubStr(this.mstrTalk[this.step], 1, this.mstrTalk[this.step].Length), (int)GameScreen.player.ID, 0, true, 0);
				}
				else
				{
					GameScreen.player.chat = null;
					mVector mVector2 = new mVector();
					iCommand o2 = this.setCmd();
					mVector2.addElement(o2);
					GameCanvas.menu.startAt_NPC_Quest(mVector2, GameMidlet.SubStr(this.mstrTalk[this.step], 1, this.mstrTalk[this.step].Length), this.idNPC, 2, true, 0);
				}
				this.step++;
			}
		}
	}

	// Token: 0x06000877 RID: 2167 RVA: 0x000AC624 File Offset: 0x000AA824
	public iCommand setCmd()
	{
		bool flag = this.step < this.mstrTalk.Length - 1;
		iCommand result;
		if (flag)
		{
			result = new iCommand(T.next + " >>", 0, this);
		}
		else
		{
			bool flag2 = this.statusQuest == 2;
			if (flag2)
			{
				result = new iCommand(T.next + " >>", 4, this);
			}
			else
			{
				result = new iCommand(T.next + " >>", 2, this);
			}
		}
		return result;
	}

	// Token: 0x06000878 RID: 2168 RVA: 0x000AC6A8 File Offset: 0x000AA8A8
	public iCommand getCmeTabQuest()
	{
		bool flag = this.statusQuest == 0;
		iCommand cmdShow;
		if (flag)
		{
			cmdShow = TabQuest.cmdShow;
		}
		else
		{
			cmdShow = TabQuest.cmdShow;
		}
		return cmdShow;
	}

	// Token: 0x06000879 RID: 2169 RVA: 0x000AC6D8 File Offset: 0x000AA8D8
	public static void updateDataQuestKillMon(short idMonster)
	{
		MainMonster mainMonster = (MainMonster)MainObject.get_Object((int)idMonster, 1);
		bool flag = mainMonster == null;
		if (!flag)
		{
			string empty = string.Empty;
			MainQuest mainQuest = null;
			bool flag2 = false;
			for (int i = 0; i < Player.vecQuest.size(); i++)
			{
				bool flag3 = flag2;
				if (flag3)
				{
					break;
				}
				MainQuest mainQuest2 = (MainQuest)Player.vecQuest.elementAt(i);
				bool flag4 = mainQuest2.statusQuest != 1;
				if (!flag4)
				{
					for (int j = 0; j < mainQuest2.vecTypeQuest.size(); j++)
					{
						DataQuest dataQuest = (DataQuest)mainQuest2.vecTypeQuest.elementAt(j);
						bool flag5 = dataQuest.typeQuest == 1 && (int)dataQuest.IDItem == mainMonster.idCatMonster && dataQuest.numCur < dataQuest.numMax;
						if (flag5)
						{
							mainQuest = mainQuest2;
							bool flag6 = mainQuest2.typeMainSub == 1;
							if (flag6)
							{
								flag2 = true;
							}
							break;
						}
					}
				}
			}
			bool flag7 = mainQuest == null;
			if (!flag7)
			{
				for (int k = 0; k < mainQuest.vecTypeQuest.size(); k++)
				{
					DataQuest dataQuest2 = (DataQuest)mainQuest.vecTypeQuest.elementAt(k);
					bool flag8 = dataQuest2.typeQuest == 1 && (int)dataQuest2.IDItem == mainMonster.idCatMonster && dataQuest2.numCur < dataQuest2.numMax;
					if (flag8)
					{
						DataQuest dataQuest3 = dataQuest2;
						dataQuest3.numCur += 1;
						break;
					}
				}
			}
		}
	}

	// Token: 0x0600087A RID: 2170 RVA: 0x000AC87C File Offset: 0x000AAA7C
	public static void updateDataQuestGetPotion(short id)
	{
		MainQuest mainQuest = null;
		bool flag = false;
		for (int i = 0; i < Player.vecQuest.size(); i++)
		{
			bool flag2 = flag;
			if (flag2)
			{
				break;
			}
			MainQuest mainQuest2 = (MainQuest)Player.vecQuest.elementAt(i);
			bool flag3 = mainQuest2.statusQuest != 1 || (mainQuest != null && mainQuest.typeMainSub < mainQuest2.typeMainSub);
			if (!flag3)
			{
				for (int j = 0; j < mainQuest2.vecTypeQuest.size(); j++)
				{
					DataQuest dataQuest = (DataQuest)mainQuest2.vecTypeQuest.elementAt(j);
					bool flag4 = dataQuest.typeQuest == 2 && dataQuest.IDItem == id && dataQuest.numCur < dataQuest.numMax;
					if (flag4)
					{
						mainQuest = mainQuest2;
						bool flag5 = mainQuest2.typeMainSub == 1;
						if (flag5)
						{
							flag = true;
						}
						break;
					}
				}
			}
		}
		bool flag6 = mainQuest == null;
		if (!flag6)
		{
			for (int k = 0; k < mainQuest.vecTypeQuest.size(); k++)
			{
				DataQuest dataQuest2 = (DataQuest)mainQuest.vecTypeQuest.elementAt(k);
				bool flag7 = dataQuest2.typeQuest == 2 && dataQuest2.IDItem == id && dataQuest2.numCur < dataQuest2.numMax;
				if (flag7)
				{
					DataQuest dataQuest3 = dataQuest2;
					dataQuest3.numCur += 1;
					break;
				}
			}
		}
	}

	// Token: 0x0600087B RID: 2171 RVA: 0x000AC9F8 File Offset: 0x000AABF8
	public static void LoadNamePotionQuest(DataInputStream iss, bool isSave)
	{
		bool flag = iss == null;
		if (flag)
		{
			GlobalService.gI().get_DATA(7);
		}
		else
		{
			try
			{
				short num = iss.readShort();
				DataQuest.nameItemQuest = new string[(int)num];
				for (int i = 0; i < (int)num; i++)
				{
					DataQuest.nameItemQuest[i] = iss.readUTF();
				}
				if (isSave)
				{
					GlobalService.VerNamePotionQuest = iss.readShort();
					SaveRms.saveVer(GlobalService.VerNamePotionQuest, "VerdataNamePotionquest");
				}
				iss.close();
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x04000D24 RID: 3364
	public const int MAIN = 0;

	// Token: 0x04000D25 RID: 3365
	public const int SUB = 1;

	// Token: 0x04000D26 RID: 3366
	public const int REPLAY = 2;

	// Token: 0x04000D27 RID: 3367
	public const int CLAN = 3;

	// Token: 0x04000D28 RID: 3368
	public const int TYPE_ITEM = 0;

	// Token: 0x04000D29 RID: 3369
	public const int TYPE_MONSTER = 1;

	// Token: 0x04000D2A RID: 3370
	public const int NHAN = 0;

	// Token: 0x04000D2B RID: 3371
	public const int TRA = 1;

	// Token: 0x04000D2C RID: 3372
	public const sbyte STATUSQUEST_ADD = 0;

	// Token: 0x04000D2D RID: 3373
	public const sbyte STATUSQUEST_CURRENT = 1;

	// Token: 0x04000D2E RID: 3374
	public const sbyte STATUSQUEST_FINISH = 2;

	// Token: 0x04000D2F RID: 3375
	public const sbyte ACTION_QUEST_TALK = 0;

	// Token: 0x04000D30 RID: 3376
	public const sbyte ACTION_QUEST_KILL_MON = 1;

	// Token: 0x04000D31 RID: 3377
	public const sbyte ACTION_QUEST_GET_ITEM = 2;

	// Token: 0x04000D32 RID: 3378
	public sbyte typeMainSub;

	// Token: 0x04000D33 RID: 3379
	public sbyte statusQuest;

	// Token: 0x04000D34 RID: 3380
	public sbyte typeActionQuest;

	// Token: 0x04000D35 RID: 3381
	public int idNPC;

	// Token: 0x04000D36 RID: 3382
	public int idNPC_Sub = -32000;

	// Token: 0x04000D37 RID: 3383
	public short ID;

	// Token: 0x04000D38 RID: 3384
	public short idMapHelp;

	// Token: 0x04000D39 RID: 3385
	public short lvRequest;

	// Token: 0x04000D3A RID: 3386
	public string name;

	// Token: 0x04000D3B RID: 3387
	public string strTalk;

	// Token: 0x04000D3C RID: 3388
	public string strNhacNho;

	// Token: 0x04000D3D RID: 3389
	public string[] mstrTalk;

	// Token: 0x04000D3E RID: 3390
	public string strShowDialog;

	// Token: 0x04000D3F RID: 3391
	public string strNPC_Map = string.Empty;

	// Token: 0x04000D40 RID: 3392
	public mVector vecTypeQuest = new mVector("MainQuest.vecTypeQuest");

	// Token: 0x04000D41 RID: 3393
	private int step;
}
