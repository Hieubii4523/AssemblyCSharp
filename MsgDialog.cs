using System;

// Token: 0x020000A2 RID: 162
public class MsgDialog : MainDialog
{
	// Token: 0x06000A05 RID: 2565 RVA: 0x000CA1F0 File Offset: 0x000C83F0
	public override void commandPointer(int index, int subIndex)
	{
		GameCanvas.clearAll();
		switch (index)
		{
		case -1:
			GameCanvas.end_Dialog();
			break;
		case 0:
		{
			bool flag = this.linkDownLoad.Length > 0;
			if (flag)
			{
				GameMidlet.openUrl(this.linkDownLoad);
			}
			break;
		}
		case 1:
		{
			bool flag2 = this.quest != null;
			if (flag2)
			{
				GlobalService.gI().quest(2, this.quest.ID);
				GameCanvas.end_Dialog();
			}
			break;
		}
		case 2:
		{
			this.isClose = true;
			bool flag3 = this.type == 2 && GameScreen.indexHelp == 18;
			if (flag3)
			{
				MainHelp.setNextHelp(false);
			}
			break;
		}
		case 5:
		{
			bool flag4 = this.skill != null;
			if (flag4)
			{
				GlobalService.gI().Learn_Skill(0, this.skill.indexSkillInServer);
				GameCanvas.end_Dialog();
			}
			break;
		}
		case 10:
		{
			GameCanvas.end_Cur_Dialog();
			bool flag5 = Player.questMainNew != null && (int)Player.idNPCQuestCur == Player.questMainNew.idNPC;
			if (flag5)
			{
				GameCanvas.menuCur.isShowMenu = false;
				GameCanvas.menuCur.runText = null;
				Player.questMainNew.beginQuest((short)Player.questMainNew.idNPC);
				Player.idNPCQuestCur = -1;
			}
			break;
		}
		case 11:
		{
			bool flag6 = MsgShowGift.gift != null;
			if (flag6)
			{
				GlobalService.gI().Use_Potion(MsgShowGift.gift.ID);
			}
			GameCanvas.end_Dialog();
			break;
		}
		case 14:
			GlobalService.gI().Daily_Login((sbyte)subIndex);
			break;
		case 15:
			GameCanvas.end_Dialog();
			MsgSpamSetup.saveClose();
			break;
		}
	}

	// Token: 0x06000A06 RID: 2566 RVA: 0x000CA3C8 File Offset: 0x000C85C8
	public void beginDia()
	{
		this.left = null;
		this.right = null;
		this.center = null;
		this.isNewShop = false;
		this.cmdList.removeAllElements();
		MsgDialog.vecEff.removeAllElements();
		bool flag = GameScreen.player != null;
		if (flag)
		{
			GameScreen.player.resetAction();
		}
	}

	// Token: 0x06000A07 RID: 2567 RVA: 0x000CA424 File Offset: 0x000C8624
	public void setinfoDownload(string info, string link)
	{
		this.linkDownLoad = link;
		mVector mVector = new mVector();
		mVector.addElement(new iCommand(T.download, 0, this));
		this.setinfo(info, mVector, true, 0);
	}

	// Token: 0x06000A08 RID: 2568 RVA: 0x000CA460 File Offset: 0x000C8660
	public void setinfo(string info, mVector vecCmd, bool isCmdClose, sbyte type)
	{
		this.beginDia();
		this.type = (int)type;
		bool flag = type == 9 && Player.StepAutoRe != 6;
		if (flag)
		{
			MsgDialog.isAuroReconect = true;
		}
		bool flag2 = vecCmd != null;
		if (flag2)
		{
			this.cmdList = vecCmd;
		}
		else
		{
			this.cmdList = new mVector();
		}
		if (isCmdClose)
		{
			this.cmdClose = new iCommand(T.close, 2, this);
			this.cmdList.addElement(this.cmdClose);
			this.backCMD = this.cmdClose;
		}
		else
		{
			this.isBack = false;
		}
		bool flag3 = this.cmdList.size() == 0;
		if (flag3)
		{
			GameCanvas.end_Dialog();
		}
		else
		{
			this.wDia = MotherCanvas.w - 30;
			bool flag4 = this.wDia > 200;
			if (flag4)
			{
				this.wDia = 200;
			}
			this.maxWShow = this.wDia;
			bool flag5 = GameCanvas.currentDialog == null;
			if (flag5)
			{
				this.wShowPaper = 5;
			}
			else
			{
				this.wShowPaper = this.maxWShow;
			}
			int num = this.cmdList.size();
			this.strinfo = this.fontDia.splitFontArray(info, this.wDia - 20);
			this.hDia = GameCanvas.hText * this.strinfo.Length + MsgDialog.hPlus + ((num - 1) / 2 + 1) * (iCommand.hButtonCmdNor + 5);
			this.xDia = MotherCanvas.hw - this.wDia / 2;
			this.yDia = MotherCanvas.h - GameCanvas.hCommand * 2 - this.hDia - 5;
			this.setPosCmdNew(0, false);
		}
	}

	// Token: 0x06000A09 RID: 2569 RVA: 0x000CA60C File Offset: 0x000C880C
	public void setinfoItem(string info, mVector vecitem, mVector vecCmd, bool isCmdClose)
	{
		this.beginDia();
		this.type = 7;
		this.isNewShop = true;
		this.vecItem = vecitem;
		bool flag = vecCmd != null;
		if (flag)
		{
			this.cmdList = vecCmd;
		}
		else
		{
			this.cmdList = new mVector();
		}
		if (isCmdClose)
		{
			this.cmdClose = new iCommand(T.close, 2, this);
			this.cmdList.addElement(this.cmdClose);
			this.backCMD = this.cmdClose;
		}
		else
		{
			this.isBack = false;
		}
		bool flag2 = this.cmdList.size() == 0;
		if (flag2)
		{
			GameCanvas.end_Dialog();
		}
		else
		{
			this.wItem = 22;
			this.wDia = MotherCanvas.w - 30;
			bool flag3 = this.wDia > 180;
			if (flag3)
			{
				this.wDia = 180;
			}
			this.maxWShow = this.wDia;
			bool flag4 = GameCanvas.currentDialog == null;
			if (flag4)
			{
				this.wShowPaper = 5;
			}
			else
			{
				this.wShowPaper = this.maxWShow;
			}
			int num = this.cmdList.size();
			this.strinfo = this.fontDia.splitFontArray(info, this.wDia - 20);
			this.hDia = GameCanvas.hText * this.strinfo.Length + (this.vecItem.size() - 1) * this.wItem + (((num - 1) / 2 + 1) * (iCommand.hButtonCmdNor + 5) + 5);
			this.xDia = MotherCanvas.hw - this.wDia / 2;
			this.yDia = MotherCanvas.h - GameCanvas.hCommand * 2 - this.hDia - 5;
			this.setPosCmdNew(0, false);
		}
	}

	// Token: 0x06000A0A RID: 2570 RVA: 0x000CA7BC File Offset: 0x000C89BC
	public void setinfoNew(string info, mVector vecCmd, bool isCmdClose, string nameDia)
	{
		bool flag = !GameCanvas.isTouch;
		if (flag)
		{
			this.setinfo(info, vecCmd, isCmdClose, 0);
		}
		else
		{
			this.beginDia();
			this.isNewShop = true;
			this.nameDialog = nameDia;
			this.type = 0;
			bool flag2 = vecCmd != null;
			if (flag2)
			{
				this.cmdList = vecCmd;
			}
			else
			{
				this.cmdList = new mVector();
			}
			this.wDia = MotherCanvas.w - 30;
			bool flag3 = this.wDia > 200;
			if (flag3)
			{
				this.wDia = 200;
			}
			this.maxWShow = this.wDia;
			bool flag4 = GameCanvas.currentDialog == null;
			if (flag4)
			{
				this.wShowPaper = 5;
			}
			else
			{
				this.wShowPaper = this.maxWShow;
			}
			int num = this.cmdList.size();
			this.strinfo = this.fontDia.splitFontArray(info, this.wDia - 20);
			this.hDia = GameCanvas.hText * this.strinfo.Length + MsgDialog.hPlus + (iCommand.hButtonCmdNor + 5);
			this.xDia = MotherCanvas.hw - this.wDia / 2;
			this.yDia = MotherCanvas.h - GameCanvas.hCommand * 2 - this.hDia - 5;
			int wButtonCmd = iCommand.wButtonCmd;
			int num2 = 0;
			bool flag5 = num % 2 == 0;
			if (flag5)
			{
				num2 = wButtonCmd / 2;
			}
			for (int i = 0; i < num; i++)
			{
				iCommand iCommand = (iCommand)this.cmdList.elementAt(i);
				iCommand.isSelect = false;
				iCommand.setPos(MotherCanvas.hw - this.cmdList.size() / 2 * wButtonCmd + i * wButtonCmd + num2, this.yDia + this.hDia - GameCanvas.hCommand, null, iCommand.caption);
				bool flag6 = i == 0 && GameCanvas.isTouchNoOrPC();
				if (flag6)
				{
					iCommand.isSelect = true;
				}
			}
			if (isCmdClose)
			{
				this.cmdClose = new iCommand(T.close, 2, this);
				this.cmdClose.setPos(MotherCanvas.hw + (this.wDia - 50) / 2, this.yDia - GameCanvas.hCommand / 2 + 7, MainTab.fraCloseTab, string.Empty);
				this.cmdList.addElement(this.cmdClose);
				this.backCMD = this.cmdClose;
			}
			else
			{
				this.isBack = false;
			}
		}
		MsgDialog.xEFF = this.xDia + this.wDia / 2;
		MsgDialog.yEFF = this.yDia + this.hDia - GameCanvas.hCommand * 3;
	}

	// Token: 0x06000A0B RID: 2571 RVA: 0x000CAA58 File Offset: 0x000C8C58
	public void setWaitinginfo(string info, mVector vecCmd, bool isCmdClose, sbyte type, int time)
	{
		this.beginDia();
		this.type = (int)type;
		bool flag = vecCmd != null;
		if (flag)
		{
			this.cmdList = vecCmd;
		}
		else
		{
			this.cmdList = new mVector();
		}
		if (isCmdClose)
		{
			this.cmdClose = new iCommand(T.close, 2, this);
			this.cmdList.addElement(this.cmdClose);
			this.backCMD = this.cmdClose;
		}
		else
		{
			this.isBack = false;
		}
		this.wDia = MotherCanvas.w - 30;
		bool flag2 = this.wDia > 200;
		if (flag2)
		{
			this.wDia = 200;
		}
		this.maxWShow = this.wDia;
		this.wShowPaper = this.maxWShow;
		this.strinfo = this.fontDia.splitFontArray(info, this.wDia - 20);
		this.hDia = GameCanvas.hText * this.strinfo.Length + (isCmdClose ? iCommand.hButtonCmdNor : 0) + 28 + MsgDialog.hPlus;
		bool flag3 = time > 0;
		if (flag3)
		{
			this.hDia += 24;
			this.timeDialog = new CountDownTicket();
			this.timeDialog.setCountDown(time);
		}
		this.xDia = MotherCanvas.hw - this.wDia / 2;
		this.yDia = MotherCanvas.h - GameCanvas.hCommand * 2 - this.hDia - 5;
		int num = this.cmdList.size();
		int wButtonCmd = iCommand.wButtonCmd;
		int num2 = 0;
		bool flag4 = num % 2 == 0;
		if (flag4)
		{
			num2 = wButtonCmd / 2;
		}
		for (int i = 0; i < num; i++)
		{
			iCommand iCommand = (iCommand)this.cmdList.elementAt(i);
			iCommand.isSelect = false;
			iCommand.setPos(MotherCanvas.hw - this.cmdList.size() / 2 * wButtonCmd + i * wButtonCmd + num2, this.yDia + this.hDia - GameCanvas.hCommand, null, iCommand.caption);
			bool flag5 = i == 0 && GameCanvas.isTouchNoOrPC();
			if (flag5)
			{
				iCommand.isSelect = true;
			}
		}
		this.setPosCmdNew(0, false);
	}

	// Token: 0x06000A0C RID: 2572 RVA: 0x000CAC8C File Offset: 0x000C8E8C
	public void setinfoQuest(MainQuest quest, bool isNew)
	{
		this.quest = quest;
		this.fontDia = mFont.tahoma_7_black;
		this.beginDia();
		this.type = 2;
		this.cmdList = new mVector();
		this.cmdClose = new iCommand(T.close, 2, this);
		this.cmdClose.levelSmall = 1;
		bool flag = quest.typeMainSub != 0 && quest.statusQuest != 0 && !isNew;
		if (flag)
		{
			iCommand iCommand = new iCommand(T.cancelQuest, 1, this);
			iCommand.levelSmall = 1;
			this.cmdList.addElement(iCommand);
		}
		this.cmdList.addElement(this.cmdClose);
		this.backCMD = this.cmdClose;
		this.wDia = MotherCanvas.w - 30;
		bool flag2 = this.wDia > 160;
		if (flag2)
		{
			this.wDia = 160;
		}
		this.maxWShow = this.wDia;
		bool flag3 = GameCanvas.currentDialog == null;
		if (flag3)
		{
			this.wShowPaper = 5;
		}
		else
		{
			this.wShowPaper = this.maxWShow;
		}
		int num = this.cmdList.size();
		this.nameDialog = T.questInfo;
		string text = string.Empty;
		bool flag4 = quest.statusQuest == 0;
		if (flag4)
		{
			this.nameDialog = T.newquest + ((quest.typeMainSub != 0) ? string.Empty : quest.getMainSub());
			text = GameMidlet.format(T.helpQuestENG, quest.strNPC_Map);
		}
		else
		{
			bool flag5 = quest.statusQuest == 2;
			if (flag5)
			{
				text = quest.name + "\n" + quest.strShowDialog;
				bool flag6 = false;
				for (int i = 0; i < quest.vecTypeQuest.size(); i++)
				{
					DataQuest dataQuest = (DataQuest)quest.vecTypeQuest.elementAt(i);
					bool flag7 = dataQuest.typeQuest == 2 || dataQuest.typeQuest == 1;
					if (flag7)
					{
						text = text + "\n " + T.daHoanthanh;
						flag6 = true;
						break;
					}
				}
				bool flag8 = flag6;
				if (flag8)
				{
					text = text + "\n " + T.traNvtai + quest.strNPC_Map;
				}
			}
			else
			{
				text = quest.name + "\n" + quest.strShowDialog;
				bool flag9 = false;
				for (int j = 0; j < quest.vecTypeQuest.size(); j++)
				{
					DataQuest dataQuest2 = (DataQuest)quest.vecTypeQuest.elementAt(j);
					bool flag10 = dataQuest2.typeQuest != 2 && dataQuest2.typeQuest != 1;
					if (!flag10)
					{
						bool flag11 = !flag9;
						if (flag11)
						{
							bool flag12 = quest.typeMainSub != 2 && quest.typeMainSub != 3;
							if (flag12)
							{
								text = text + "(" + LoadMap.getNameMap((int)quest.idMapHelp) + ")";
							}
							text = text + "\n " + T.mucdoHoanthanh;
							flag9 = true;
						}
						bool flag13 = dataQuest2.typeQuest == 2;
						if (flag13)
						{
							string text2 = text;
							text = string.Concat(new string[]
							{
								text2,
								"\n  ",
								dataQuest2.nameItem,
								": ",
								dataQuest2.numCur.ToString(),
								"/",
								dataQuest2.numMax.ToString()
							});
						}
						bool flag14 = dataQuest2.typeQuest == 1;
						if (flag14)
						{
							bool flag15 = dataQuest2.nameItem != null && dataQuest2.nameItem.Length == 0;
							if (flag15)
							{
								dataQuest2.loadNameAgain();
							}
							string text3 = text;
							text = string.Concat(new string[]
							{
								text3,
								"\n  ",
								dataQuest2.nameItem,
								": ",
								dataQuest2.numCur.ToString(),
								"/",
								dataQuest2.numMax.ToString()
							});
						}
					}
				}
			}
		}
		this.strinfo = this.fontDia.splitFontArray(text, this.wDia - 20);
		this.hDia = GameCanvas.hText * this.strinfo.Length + MsgDialog.hPlus + ((num - 1) / 2 + 1) * (iCommand.hButtonCmdNor + 5);
		this.hDia += GameCanvas.hCommand;
		this.xDia = MotherCanvas.hw - this.wDia / 2;
		this.yDia = MotherCanvas.h / 2 - this.hDia / 2;
		this.setPosCmdNew(0, true);
	}

	// Token: 0x06000A0D RID: 2573 RVA: 0x000CB128 File Offset: 0x000C9328
	public void setNhanTraQuest(MainQuest quest, iCommand cmd)
	{
		this.quest = quest;
		this.fontDia = mFont.tahoma_7_black;
		this.beginDia();
		this.type = 2;
		this.cmdList = new mVector();
		this.cmdClose = new iCommand(T.close, 2, this);
		this.cmdClose.levelSmall = 1;
		cmd.levelSmall = 1;
		this.cmdList.addElement(cmd);
		this.cmdList.addElement(this.cmdClose);
		this.backCMD = this.cmdClose;
		this.wDia = MotherCanvas.w - 30;
		bool flag = this.wDia > 160;
		if (flag)
		{
			this.wDia = 160;
		}
		this.maxWShow = this.wDia;
		bool flag2 = GameCanvas.currentDialog == null;
		if (flag2)
		{
			this.wShowPaper = 5;
		}
		else
		{
			this.wShowPaper = this.maxWShow;
		}
		int num = this.cmdList.size();
		this.nameDialog = T.quest + " " + T.main;
		bool flag3 = quest.typeMainSub == 1;
		if (flag3)
		{
			this.nameDialog = T.quest + " " + T.sub;
		}
		else
		{
			bool flag4 = quest.typeMainSub == 2;
			if (flag4)
			{
				this.nameDialog = T.quest + " " + T.replay;
			}
		}
		string name = quest.name;
		this.strinfo = this.fontDia.splitFontArray(name, this.wDia - 20);
		this.hDia = GameCanvas.hText * this.strinfo.Length + MsgDialog.hPlus + ((num - 1) / 2 + 1) * (iCommand.hButtonCmdNor + 5);
		this.hDia += GameCanvas.hCommand;
		this.xDia = MotherCanvas.hw - this.wDia / 2;
		this.yDia = MotherCanvas.hh - this.hDia / 2;
		this.setPosCmdNew(0, false);
	}

	// Token: 0x06000A0E RID: 2574 RVA: 0x000CB31C File Offset: 0x000C951C
	public void setinfoSkillInfo(Skill_Info skill)
	{
		this.skill = skill;
		this.fontDia = mFont.tahoma_7_black;
		this.beginDia();
		this.type = 4;
		this.cmdList = new mVector();
		iCommand iCommand = new iCommand(T.learn, 5, this);
		iCommand.levelSmall = 1;
		this.cmdList.addElement(iCommand);
		this.cmdClose = new iCommand(T.close, -1, this);
		this.cmdClose.levelSmall = 1;
		this.cmdList.addElement(this.cmdClose);
		this.backCMD = this.cmdClose;
		this.wDia = MotherCanvas.w - 30;
		bool flag = this.wDia > 160;
		if (flag)
		{
			this.wDia = 160;
		}
		this.maxWShow = this.wDia;
		int num = this.cmdList.size();
		skill.setVecInfo(this.wDia);
		this.hDia = GameCanvas.hText * skill.vecInfo.size() + MsgDialog.hPlus + ((num - 1) / 2 + 1) * (iCommand.hButtonCmdNor + 5);
		this.hDia += GameCanvas.hCommand;
		int num2 = 0;
		bool flag2 = this.hDia > MotherCanvas.h - GameCanvas.hCommand * 2;
		if (flag2)
		{
			num2 = this.hDia - (MotherCanvas.h - GameCanvas.hCommand * 2);
			this.hDia = MotherCanvas.h - GameCanvas.hCommand * 2;
		}
		this.xDia = MotherCanvas.hw - this.wDia / 2;
		this.yDia = MotherCanvas.hh - this.hDia / 2;
		bool flag3 = num2 > 0;
		if (flag3)
		{
			this.list = new ListNew(this.xDia, this.yDia, this.wDia, this.hDia, 0, 0, num2, true);
		}
		this.wShowPaper = this.maxWShow;
		this.setPosCmdNew(0, false);
		this.okCMD = this.cmdClose;
	}

	// Token: 0x06000A0F RID: 2575 RVA: 0x000CB508 File Offset: 0x000C9708
	public void setinfoParty(mVector att)
	{
		bool flag = att != null && att.size() != 0;
		if (flag)
		{
			this.beginDia();
			this.fontDia = mFont.tahoma_7_white;
			this.nameDialog = T.AttriParty;
			this.type = 5;
			this.cmdClose = new iCommand(T.close, 2, this);
			this.cmdList.addElement(this.cmdClose);
			this.backCMD = this.cmdClose;
			this.wDia = MotherCanvas.w - 30;
			bool flag2 = this.wDia > 160;
			if (flag2)
			{
				this.wDia = 160;
			}
			this.maxWShow = this.wDia;
			bool flag3 = GameCanvas.currentDialog == null;
			if (flag3)
			{
				this.wShowPaper = 5;
			}
			else
			{
				this.wShowPaper = this.maxWShow;
			}
			int num = this.cmdList.size();
			this.strinfo = new string[att.size()];
			for (int i = 0; i < att.size(); i++)
			{
				MainInfoItem info = (MainInfoItem)att.elementAt(i);
				this.strinfo[i] = MainItem.getInfoEveryWhere(info);
			}
			this.hDia = GameCanvas.hText * this.strinfo.Length + MsgDialog.hPlus + ((num - 1) / 2 + 1) * (iCommand.hButtonCmdNor + 15);
			bool isTouch = GameCanvas.isTouch;
			if (isTouch)
			{
				this.hDia = GameCanvas.hText * this.strinfo.Length + MsgDialog.hPlus + 20;
			}
			this.xDia = MotherCanvas.hw - this.wDia / 2;
			this.yDia = MotherCanvas.hh - this.hDia / 2;
			bool isTouch2 = GameCanvas.isTouch;
			if (isTouch2)
			{
				this.cmdClose.setPos(this.xDia + this.wDia - 25, this.yDia + 4 + 8, MainTab.fraCloseTab, string.Empty);
			}
			else
			{
				this.setPosCmdNew(0, false);
			}
		}
	}

	// Token: 0x06000A10 RID: 2576 RVA: 0x000CB700 File Offset: 0x000C9900
	public void setinfoClan(MainClan Clan)
	{
		this.clanpaint = Clan;
		this.posValueName = new int[T.mNameClan.Length];
		this.wItem = GameCanvas.hText + 4;
		for (int i = 0; i < T.mNameClan.Length; i++)
		{
			this.posValueName[i] = mFont.tahoma_7_white.getWidth(T.mNameClan[i]);
		}
		this.beginDia();
		this.isNewShop = true;
		this.nameDialog = T.Clan + " " + this.clanpaint.name;
		this.type = 10;
		this.cmdList = new mVector();
		this.wDia = MotherCanvas.w - 30;
		bool flag = this.wDia > 180;
		if (flag)
		{
			this.wDia = 180;
		}
		this.maxWShow = this.wDia;
		bool flag2 = GameCanvas.currentDialog == null;
		if (flag2)
		{
			this.wShowPaper = 5;
		}
		else
		{
			this.wShowPaper = this.maxWShow;
		}
		this.hDia = 120;
		this.xDia = MotherCanvas.hw - this.wDia / 2;
		this.yDia = MotherCanvas.h / 2 - this.hDia / 2 - 5;
		this.cmdClose = new iCommand(T.close, 2, this);
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			this.cmdClose.setPos(MotherCanvas.hw + (this.wDia - 50) / 2, this.yDia + 4 + 7, MainTab.fraCloseTab, string.Empty);
		}
		else
		{
			this.cmdClose = AvMain.setPosCMD(this.cmdClose, 2);
		}
		this.cmdList.addElement(this.cmdClose);
		this.backCMD = this.cmdClose;
		MsgDialog.xEFF = this.xDia + this.wDia / 2;
		MsgDialog.yEFF = this.yDia + this.hDia - GameCanvas.hCommand * 3;
	}

	// Token: 0x06000A11 RID: 2577 RVA: 0x000CB8EC File Offset: 0x000C9AEC
	public void setPosCmdNew(int yplus, bool isLast)
	{
		this.idCommand = 0;
		bool flag = this.cmdList.size() <= 0;
		if (!flag)
		{
			int num = this.cmdList.size();
			int num2 = num;
			int num3 = num2;
			if (num3 != 1)
			{
				if (num3 != 2)
				{
					this.w2cmd = 10;
					this.xBegin = this.xDia + this.wDia / 2 - this.w2cmd / 2 - iCommand.wButtonCmd / 2;
				}
				else
				{
					this.w2cmd = 10;
					this.xBegin = this.xDia + this.wDia / 2 - this.w2cmd / 2 - iCommand.wButtonCmd / 2;
				}
			}
			else
			{
				this.xBegin = this.xDia + this.wDia / 2;
				this.w2cmd = 0;
			}
			for (int i = 0; i < num; i++)
			{
				iCommand iCommand = (iCommand)this.cmdList.elementAt(i);
				iCommand.isSelect = false;
				bool flag2 = num == 3 && i == 2;
				if (flag2)
				{
					iCommand.setPos(this.xDia + this.wDia / 2, this.yDia + this.hDia - iCommand.hButtonCmdNor - (num - 1) / 2 * (iCommand.hButtonCmdNor + 5) + iCommand.hButtonCmdNor / 2 + 2 + i / 2 * (iCommand.hButtonCmdNor + 5) + yplus - 8, null, iCommand.caption);
				}
				else
				{
					iCommand.setPos(this.xBegin + i % 2 * (iCommand.wButtonCmd + this.w2cmd), this.yDia + this.hDia - iCommand.hButtonCmdNor / 2 - (num - 1) / 2 * (iCommand.hButtonCmdNor + 5) + 2 + i / 2 * (iCommand.hButtonCmdNor + 5) + yplus - 8, null, iCommand.caption);
				}
				if (isLast)
				{
					bool flag3 = i == num - 1 && GameCanvas.isTouchNoOrPC();
					if (flag3)
					{
						iCommand.isSelect = true;
						this.idCommand = i;
					}
				}
				else
				{
					bool flag4 = i == 0 && GameCanvas.isTouchNoOrPC();
					if (flag4)
					{
						iCommand.isSelect = true;
						this.idCommand = 0;
					}
				}
			}
		}
	}

	// Token: 0x06000A12 RID: 2578 RVA: 0x000CBB18 File Offset: 0x000C9D18
	public override void paint(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		int num = 0;
		switch (this.type)
		{
		case 0:
		case 9:
		{
			bool flag = this.isNewShop;
			if (flag)
			{
				num = GameCanvas.hCommand;
			}
			base.paintPaper(g, MotherCanvas.hw - this.wShowPaper / 2, this.yDia - this.miniItem - num, this.wShowPaper, this.hDia + this.miniItem * 2 + num, this.maxWShow, (int)AvMain.PAPER_NORMAL);
			g.setClip(MotherCanvas.hw - this.wShowPaper / 2, 0, this.wShowPaper, MotherCanvas.h);
			g.saveCanvas();
			g.ClipRec(MotherCanvas.hw - this.wShowPaper / 2, 0, this.wShowPaper, MotherCanvas.h);
			bool flag2 = this.isNewShop;
			if (flag2)
			{
				g.setColor(15972174);
				g.fillRoundRect(this.xDia + 25, this.yDia - num + 12, this.wDia - 50, 16, 4, 4);
				AvMain.FontBorderColor(g, this.nameDialog, this.xDia + this.wDia / 2, this.yDia + 15 - num, 2, 6, 5);
			}
			for (int i = 0; i < this.strinfo.Length; i++)
			{
				this.fontDia.drawString(g, this.strinfo[i], MotherCanvas.w / 2, this.yDia + 10 + i * GameCanvas.hText, 2);
			}
			for (int j = 0; j < MsgDialog.vecEff.size(); j++)
			{
				MainEffect mainEffect = (MainEffect)MsgDialog.vecEff.elementAt(j);
				mainEffect.paint(g);
			}
			bool flag3 = this.cmdList != null;
			if (flag3)
			{
				for (int k = 0; k < this.cmdList.size(); k++)
				{
					iCommand iCommand = (iCommand)this.cmdList.elementAt(k);
					iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
				}
			}
			g.restoreCanvas();
			break;
		}
		case 1:
		case 6:
		case 8:
		{
			base.paintPaper(g, MotherCanvas.hw - this.wShowPaper / 2, this.yDia - this.miniItem, this.wShowPaper, this.hDia + this.miniItem * 2, this.maxWShow, (int)AvMain.PAPER_NORMAL);
			g.setClip(MotherCanvas.hw - this.wShowPaper / 2, 0, this.wShowPaper, MotherCanvas.h);
			g.saveCanvas();
			g.ClipRec(MotherCanvas.hw - this.wShowPaper / 2, 0, this.wShowPaper, MotherCanvas.h);
			for (int l = 0; l < this.strinfo.Length; l++)
			{
				this.fontDia.drawString(g, this.strinfo[l], MotherCanvas.w / 2, this.yDia + 10 + l * GameCanvas.hText, 2);
			}
			bool flag4 = this.type == 1 || this.type == 8;
			if (flag4)
			{
				MsgDialog.fraImgWaiting.drawFrame(this.fWait / 2 % MsgDialog.fraImgWaiting.nFrame, MotherCanvas.hw, this.yDia + 22 + this.strinfo.Length * GameCanvas.hText, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
			}
			else
			{
				bool flag5 = this.type == 6 && this.timeDialog != null;
				if (flag5)
				{
					this.timeDialog.paintCountDownTicket(g, mFont.tahoma_7b_black, MotherCanvas.hw, this.yDia + 12 + this.strinfo.Length * GameCanvas.hText, 2);
				}
			}
			bool flag6 = this.cmdList != null;
			if (flag6)
			{
				for (int m = 0; m < this.cmdList.size(); m++)
				{
					iCommand iCommand2 = (iCommand)this.cmdList.elementAt(m);
					iCommand2.paint(g, iCommand2.xCmd, iCommand2.yCmd);
				}
			}
			g.restoreCanvas();
			break;
		}
		case 2:
		{
			base.paintPaper(g, MotherCanvas.hw - this.wShowPaper / 2, this.yDia, this.wShowPaper, this.hDia, this.maxWShow, (int)AvMain.PAPER_NORMAL);
			GameCanvas.resetTrans(g);
			g.setClip(MotherCanvas.hw - this.wShowPaper / 2, 0, this.wShowPaper, MotherCanvas.h);
			g.saveCanvas();
			g.ClipRec(MotherCanvas.hw - this.wShowPaper / 2, 0, this.wShowPaper, MotherCanvas.h);
			g.setColor(15972174);
			g.fillRoundRect(this.xDia + 10, this.yDia + 12, this.wDia - 20, 16, 4, 4);
			bool flag7 = this.quest != null;
			if (flag7)
			{
				AvMain.FontBorderColor(g, this.nameDialog, this.xDia + this.wDia / 2, this.yDia + 15, 2, 6, 5);
			}
			for (int n = 0; n < this.strinfo.Length; n++)
			{
				bool flag8 = n == 0 && this.quest.statusQuest != 0;
				if (flag8)
				{
					mFont.tahoma_7b_black.drawString(g, this.strinfo[n], MotherCanvas.w / 2, this.yDia + GameCanvas.hCommand + 10 + n * GameCanvas.hText, 2);
				}
				else
				{
					this.fontDia.drawString(g, this.strinfo[n], this.xDia + 10, this.yDia + GameCanvas.hCommand + 10 + n * GameCanvas.hText, 0);
				}
			}
			bool flag9 = this.cmdList != null;
			if (flag9)
			{
				for (int num2 = 0; num2 < this.cmdList.size(); num2++)
				{
					iCommand iCommand3 = (iCommand)this.cmdList.elementAt(num2);
					iCommand3.paint(g, iCommand3.xCmd, iCommand3.yCmd);
				}
			}
			g.restoreCanvas();
			break;
		}
		case 4:
		{
			base.paintPaper(g, MotherCanvas.hw - this.wShowPaper / 2, this.yDia, this.wShowPaper, this.hDia, this.maxWShow, (int)AvMain.PAPER_NORMAL);
			g.setColor(14203529);
			g.fillRoundRect(this.xDia + 10, this.yDia + 12, this.wDia - 20, 16, 4, 4);
			bool flag10 = this.skill != null;
			if (flag10)
			{
				AvMain.PaintName_Image(g, this.skill.idIcon, this.skill.name, this.xDia + this.wDia / 2, this.yDia + 15, 2, 3, 5);
				g.setClip(this.xDia, this.yDia + GameCanvas.hCommand + 10, this.wDia, this.hDia - (GameCanvas.hCommand + iCommand.hButtonCmdNor + 20));
				g.saveCanvas();
				g.ClipRec(this.xDia, this.yDia + GameCanvas.hCommand + 10, this.wDia, this.hDia - (GameCanvas.hCommand + iCommand.hButtonCmdNor + 20));
				bool flag11 = this.list != null;
				if (flag11)
				{
					g.translate(0, -this.list.cmx);
				}
				for (int num3 = 0; num3 < this.skill.vecInfo.size(); num3++)
				{
					infoShow infoShow = (infoShow)this.skill.vecInfo.elementAt(num3);
					this.fontDia.drawString(g, infoShow.strShow, this.xDia + 12, this.yDia + GameCanvas.hCommand + 10 + num3 * GameCanvas.hText, 0);
				}
				mGraphics.resetTransAndroid(g);
				g.restoreCanvas();
			}
			GameCanvas.resetTrans(g);
			bool flag12 = this.cmdList != null;
			if (flag12)
			{
				for (int num4 = 0; num4 < this.cmdList.size(); num4++)
				{
					iCommand iCommand4 = (iCommand)this.cmdList.elementAt(num4);
					iCommand4.paint(g, iCommand4.xCmd, iCommand4.yCmd);
				}
			}
			break;
		}
		case 5:
		{
			AvMain.paintRect(g, MotherCanvas.hw - this.wShowPaper / 2, this.yDia - this.miniItem - num, this.wShowPaper, this.hDia + this.miniItem * 2 + num - 5, 1, 4);
			g.setClip(MotherCanvas.hw - this.wShowPaper / 2, 0, this.wShowPaper, MotherCanvas.h);
			g.saveCanvas();
			g.ClipRec(MotherCanvas.hw - this.wShowPaper / 2, 0, this.wShowPaper, MotherCanvas.h);
			g.setColor(15972174);
			g.fillRoundRect(this.xDia + 25, this.yDia - num + 4, this.wDia - 50, 16, 4, 4);
			AvMain.FontBorderColor(g, this.nameDialog, this.xDia + this.wDia / 2, this.yDia + 7 - num, 2, 6, 5);
			for (int num5 = 0; num5 < this.strinfo.Length; num5++)
			{
				this.fontDia.drawString(g, this.strinfo[num5], this.xDia + 4, this.yDia + 27 + num5 * GameCanvas.hText, 0);
			}
			bool flag13 = this.cmdList != null;
			if (flag13)
			{
				for (int num6 = 0; num6 < this.cmdList.size(); num6++)
				{
					iCommand iCommand5 = (iCommand)this.cmdList.elementAt(num6);
					iCommand5.paint(g, iCommand5.xCmd, iCommand5.yCmd);
				}
			}
			g.restoreCanvas();
			break;
		}
		case 7:
		{
			bool flag14 = this.isNewShop;
			if (flag14)
			{
				num = GameCanvas.hCommand;
			}
			base.paintPaper(g, MotherCanvas.hw - this.wShowPaper / 2, this.yDia - this.miniItem - num, this.wShowPaper, this.hDia + this.miniItem * 2 + num, this.maxWShow, (int)AvMain.PAPER_NORMAL);
			g.setClip(MotherCanvas.hw - this.wShowPaper / 2, 0, this.wShowPaper, MotherCanvas.h);
			g.saveCanvas();
			g.ClipRec(MotherCanvas.hw - this.wShowPaper / 2, 0, this.wShowPaper, MotherCanvas.h);
			bool flag15 = this.vecItem != null;
			if (flag15)
			{
				bool flag16 = this.isNewShop;
				if (flag16)
				{
					g.setColor(15972174);
					g.fillRoundRect(this.xDia + 25, this.yDia - num + 10, this.wDia - 50, 20, 4, 4);
					MainItem mainItem = (MainItem)this.vecItem.elementAt(0);
					int width = mFont.tahoma_7b_black.getWidth(mainItem.name);
					mainItem.paintAllItem(g, this.xDia + this.wDia / 2 - width / 2, this.yDia + 9 + this.wItem / 2 - num, this.wItem, 0, 0);
					AvMain.FontBorderColor(g, mainItem.name, this.xDia + this.wDia / 2 + this.wItem / 2, this.yDia + 15 - num, 2, 6, 5);
				}
				int num7 = this.yDia + 10;
				for (int num8 = 0; num8 < this.strinfo.Length; num8++)
				{
					this.fontDia.drawString(g, this.strinfo[num8], MotherCanvas.w / 2, num7, 2);
					num7 += GameCanvas.hText;
				}
				for (int num9 = 1; num9 < this.vecItem.size(); num9++)
				{
					MainItem mainItem2 = (MainItem)this.vecItem.elementAt(num9);
					mainItem2.paintAllItem(g, this.xDia + 10 + this.wItem / 2, num7 + 5 + (num9 - 1) * this.wItem, this.wItem, 0, 0);
					mFont.tahoma_7b_black.drawString(g, mainItem2.name, this.xDia + 11 + this.wItem, num7 + (num9 - 1) * this.wItem, 0);
				}
			}
			bool flag17 = this.cmdList != null;
			if (flag17)
			{
				for (int num10 = 0; num10 < this.cmdList.size(); num10++)
				{
					iCommand iCommand6 = (iCommand)this.cmdList.elementAt(num10);
					iCommand6.paint(g, iCommand6.xCmd, iCommand6.yCmd);
				}
			}
			g.restoreCanvas();
			break;
		}
		case 10:
		{
			base.paintPaper(g, MotherCanvas.hw - this.wShowPaper / 2, this.yDia - this.miniItem - num, this.wShowPaper, this.hDia + this.miniItem * 2 + num, this.maxWShow, (int)AvMain.PAPER_NORMAL);
			g.setClip(MotherCanvas.hw - this.wShowPaper / 2, 0, this.wShowPaper, MotherCanvas.h);
			g.saveCanvas();
			g.ClipRec(MotherCanvas.hw - this.wShowPaper / 2, 0, this.wShowPaper, MotherCanvas.h);
			g.setColor(15972174);
			g.fillRoundRect(this.xDia + 25, this.yDia - num + 4, this.wDia - 50, 16, 4, 4);
			AvMain.FontBorderColor(g, this.nameDialog, this.xDia + this.wDia / 2, this.yDia + 7 - num, 2, 6, 5);
			int num11 = this.yDia + 10 - num + GameCanvas.hText;
			int num12 = this.xDia + 10;
			for (int num13 = 1; num13 < 6; num13++)
			{
				mFont.tahoma_7_black.drawString(g, T.mNameClan[num13], num12, num11, 0);
				switch (num13)
				{
				case 1:
					mFont.tahoma_7b_brown.drawString(g, this.clanpaint.nameCaption, num12 + this.posValueName[num13], num11, 0);
					break;
				case 2:
				{
					MainImage iconClanBig = Potion.getIconClanBig(this.clanpaint.idIcon);
					bool flag18 = iconClanBig == null || iconClanBig.img == null;
					if (!flag18)
					{
						bool flag19 = iconClanBig.frame == -1;
						if (flag19)
						{
							iconClanBig.set_Frame();
						}
						bool flag20 = iconClanBig.frame <= 1;
						if (flag20)
						{
							g.drawImage(iconClanBig.img, num12 + this.posValueName[num13] + 14, num11 + 4, 3);
						}
						else
						{
							int num14 = (this.framepaint < (int)(iconClanBig.frame - 1)) ? 3 : 15;
							bool flag21 = CRes.abs(GameCanvas.gameTick - this.lastTick) > num14;
							if (flag21)
							{
								this.framepaint++;
								bool flag22 = this.framepaint >= (int)iconClanBig.frame;
								if (flag22)
								{
									this.framepaint = 0;
								}
								this.lastTick = GameCanvas.gameTick;
							}
							g.drawRegion(iconClanBig.img, 0, this.framepaint * (int)iconClanBig.w, (int)iconClanBig.w, (int)iconClanBig.w, 0, (float)(num12 + this.posValueName[num13] + 14), (float)(num11 + 4), 3);
						}
					}
					break;
				}
				case 3:
					mFont.tahoma_7b_brown.drawString(g, this.clanpaint.level.ToString() + string.Empty, num12 + this.posValueName[3], num11, 0);
					break;
				case 4:
					mFont.tahoma_7b_brown.drawString(g, this.clanpaint.numMem.ToString() + "/" + this.clanpaint.maxNumMem.ToString(), num12 + this.posValueName[4], num11, 0);
					break;
				case 5:
					mFont.tahoma_7b_brown.drawString(g, this.clanpaint.trungsinh.ToString() + string.Empty, num12 + this.posValueName[5], num11, 0);
					break;
				}
				num11 += this.wItem;
			}
			bool flag23 = this.cmdList != null;
			if (flag23)
			{
				for (int num15 = 0; num15 < this.cmdList.size(); num15++)
				{
					iCommand iCommand7 = (iCommand)this.cmdList.elementAt(num15);
					iCommand7.paint(g, iCommand7.xCmd, iCommand7.yCmd);
				}
			}
			g.restoreCanvas();
			break;
		}
		}
	}

	// Token: 0x06000A13 RID: 2579 RVA: 0x000CCC3C File Offset: 0x000CAE3C
	public void updateOpen()
	{
		bool flag = this.wShowPaper >= this.maxWShow;
		if (!flag)
		{
			this.wShowPaper += this.vShow;
			bool flag2 = this.wShowPaper > this.maxWShow;
			if (flag2)
			{
				this.wShowPaper = this.maxWShow;
				this.vShow = 15;
			}
			bool flag3 = this.vShow < 100;
			if (flag3)
			{
				this.vShow += 15;
				bool flag4 = this.vShow > 100;
				if (flag4)
				{
					this.vShow = 100;
				}
			}
		}
	}

	// Token: 0x06000A14 RID: 2580 RVA: 0x000CCCD4 File Offset: 0x000CAED4
	public void updateClose()
	{
		bool flag = this.wShowPaper <= 0;
		if (!flag)
		{
			bool flag2 = this.wShowPaper <= 5;
			if (flag2)
			{
				this.closeDialog();
			}
			this.wShowPaper -= this.vShow;
			bool flag3 = this.wShowPaper < 5;
			if (flag3)
			{
				this.wShowPaper = 5;
				this.vShow = 15;
			}
			bool flag4 = this.vShow < 100;
			if (flag4)
			{
				this.vShow += 15;
				bool flag5 = this.vShow > 100;
				if (flag5)
				{
					this.vShow = 100;
				}
			}
		}
	}

	// Token: 0x06000A15 RID: 2581 RVA: 0x000CCD7C File Offset: 0x000CAF7C
	public override void update()
	{
		bool flag = this.isClose;
		if (flag)
		{
			this.updateClose();
		}
		else
		{
			bool flag2 = this.type == 1 || this.type == 8;
			if (flag2)
			{
				this.fWait++;
				bool flag3 = this.type == 8 && this.fWait == 200 && GameMidlet.DEVICE > 0;
				if (flag3)
				{
					try
					{
						GameCanvas.infoDisConnect = GameMidlet.connectHTTP(GameMidlet.getThongBao());
					}
					catch (Exception)
					{
					}
				}
				else
				{
					bool flag4 = this.fWait > 1200;
					if (flag4)
					{
						this.closeDialog();
						bool flag5 = Session_ME.gI().isConnected() && GameCanvas.currentScreen != GameCanvas.loginScr && GameCanvas.currentScreen != GameCanvas.loadMapScr;
						if (flag5)
						{
							GameCanvas.Start_Normal_Only_CmdClose_DiaLog(T.getdatafail);
						}
						else
						{
							mSystem.outz("disconect MsgDialog");
							GameCanvas.dialogDisconect();
						}
					}
				}
			}
			else
			{
				bool flag6 = this.type == 6;
				if (flag6)
				{
					bool flag7 = this.timeDialog != null;
					if (flag7)
					{
						this.timeDialog.updateTimeCountDownTicket();
						bool flag8 = this.timeDialog.timeCountDown <= 0;
						if (flag8)
						{
							this.closeDialog();
						}
					}
					else
					{
						this.closeDialog();
					}
				}
				else
				{
					bool flag9 = this.type == 9;
					if (flag9)
					{
						this.fWait++;
						bool flag10 = this.fWait >= 500 && MsgDialog.isAuroReconect;
						if (flag10)
						{
							GameScreen.cmdReConnect.perform();
							this.fWait = 0;
						}
					}
				}
			}
			bool flag11 = this.type == 4;
			if (flag11)
			{
				bool flag12 = this.list != null;
				if (flag12)
				{
					this.list.moveCamera();
				}
			}
			else
			{
				this.updateOpen();
			}
			this.updatekey();
			this.updatePointer();
			for (int i = 0; i < MsgDialog.vecEff.size(); i++)
			{
				MainEffect mainEffect = (MainEffect)MsgDialog.vecEff.elementAt(i);
				mainEffect.update();
				bool isStop = mainEffect.isStop;
				if (isStop)
				{
					MsgDialog.vecEff.removeElement(mainEffect);
					i--;
				}
			}
		}
	}

	// Token: 0x06000A16 RID: 2582 RVA: 0x000CCFE0 File Offset: 0x000CB1E0
	public override void updatekey()
	{
		bool flag = this.isClose;
		if (!flag)
		{
			bool flag2 = this.type == 4 && this.list != null;
			if (flag2)
			{
				bool flag3 = GameCanvas.keyMove(1);
				if (flag3)
				{
					GameCanvas.ClearkeyMove(1);
					this.list.setToX(this.list.cmtoX - GameCanvas.hText);
				}
				else
				{
					bool flag4 = GameCanvas.keyMove(3);
					if (flag4)
					{
						GameCanvas.ClearkeyMove(3);
						this.list.setToX(this.list.cmtoX + GameCanvas.hText);
					}
				}
			}
			bool flag5 = this.cmdList != null;
			if (flag5)
			{
				int num = this.cmdList.size();
				bool flag6 = GameCanvas.isTouchNoOrPC() && num > 0;
				if (flag6)
				{
					int num2 = this.idCommand;
					bool flag7 = GameCanvas.keyMove(0);
					if (flag7)
					{
						this.idCommand--;
						GameCanvas.ClearkeyMove(0);
					}
					else
					{
						bool flag8 = GameCanvas.keyMove(2);
						if (flag8)
						{
							this.idCommand++;
							GameCanvas.ClearkeyMove(2);
						}
					}
					bool flag9 = this.list == null || this.list.cmxLim <= 0;
					if (flag9)
					{
						bool flag10 = GameCanvas.keyMove(1);
						if (flag10)
						{
							GameCanvas.ClearkeyMove(1);
							this.idCommand -= 2;
						}
						else
						{
							bool flag11 = GameCanvas.keyMove(3);
							if (flag11)
							{
								GameCanvas.ClearkeyMove(3);
								this.idCommand += 2;
							}
						}
					}
					this.idCommand = AvMain.resetSelect(this.idCommand, num - 1, false);
					bool flag12 = num2 != this.idCommand && GameCanvas.isTouchNoOrPC();
					if (flag12)
					{
						iCommand iCommand = (iCommand)this.cmdList.elementAt(this.idCommand);
						bool flag13 = iCommand.caption.Length == 0;
						if (flag13)
						{
							this.idCommand = 0;
						}
						for (int i = 0; i < num; i++)
						{
							iCommand iCommand2 = (iCommand)this.cmdList.elementAt(i);
							bool flag14 = i == this.idCommand;
							if (flag14)
							{
								iCommand2.isSelect = true;
							}
							else
							{
								iCommand2.isSelect = false;
							}
						}
					}
				}
			}
			bool flag15 = GameCanvas.keyMyHold[5] && this.cmdList != null && this.idCommand < this.cmdList.size();
			if (flag15)
			{
				((iCommand)this.cmdList.elementAt(this.idCommand)).perform();
				GameCanvas.clearKeyHold(5);
			}
			base.updatekey();
			this.updatekeyPC();
		}
	}

	// Token: 0x06000A17 RID: 2583 RVA: 0x000CD290 File Offset: 0x000CB490
	public override void updatePointer()
	{
		bool flag = this.isClose;
		if (!flag)
		{
			bool flag2 = this.type == 4;
			if (flag2)
			{
				this.list.update_Pos_UP_DOWN();
			}
			bool flag3 = this.cmdList != null;
			if (flag3)
			{
				for (int i = 0; i < this.cmdList.size(); i++)
				{
					iCommand iCommand = (iCommand)this.cmdList.elementAt(i);
					iCommand.updatePointer();
				}
			}
		}
	}

	// Token: 0x06000A18 RID: 2584 RVA: 0x00080FB4 File Offset: 0x0007F1B4
	public void closeDialog()
	{
		bool flag = GameCanvas.currentDialog != null;
		if (flag)
		{
			GameCanvas.currentDialog = null;
		}
		else
		{
			GameCanvas.subDialog = null;
		}
	}

	// Token: 0x06000A19 RID: 2585 RVA: 0x000CD310 File Offset: 0x000CB510
	public static void addEff(MainEffect eff)
	{
		bool flag = eff != null;
		if (flag)
		{
			eff.x = MsgDialog.xEFF;
			eff.y = MsgDialog.yEFF;
			MsgDialog.vecEff.addElement(eff);
		}
	}

	// Token: 0x06000A1A RID: 2586 RVA: 0x0000B34B File Offset: 0x0000954B
	public void setInfoHelp(string str)
	{
		this.infoHelp = str;
		this.wInfoHelp = mFont.tahoma_7_white.getWidth(str) + 6;
		this.tickCloseInfoHelp = 100;
	}

	// Token: 0x06000A1B RID: 2587 RVA: 0x000CD34C File Offset: 0x000CB54C
	public void paintInfoHelp(mGraphics g)
	{
		bool flag = this.infoHelp.Length > 0;
		if (flag)
		{
			Interface_Game.paintBackInfoServer(g, this.xDia + this.wDia / 2, this.yDia + this.hDia + 5, this.wInfoHelp);
			mFont.tahoma_7_white.drawString(g, this.infoHelp, this.xDia + this.wDia / 2, this.yDia + this.hDia + 10, 2);
		}
	}

	// Token: 0x06000A1C RID: 2588 RVA: 0x000CD3CC File Offset: 0x000CB5CC
	public void updateInfoHelp()
	{
		bool flag = this.infoHelp.Length > 0;
		if (flag)
		{
			this.tickCloseInfoHelp--;
			bool flag2 = this.tickCloseInfoHelp == 0;
			if (flag2)
			{
				this.infoHelp = string.Empty;
			}
		}
	}

	// Token: 0x06000A1D RID: 2589 RVA: 0x000092D1 File Offset: 0x000074D1
	public virtual void updatekeyCMD()
	{
		base.updatekey();
	}

	// Token: 0x04000FB2 RID: 4018
	public const sbyte CMD_CLOSE = -1;

	// Token: 0x04000FB3 RID: 4019
	public const sbyte CMD_DOWNLOAD = 0;

	// Token: 0x04000FB4 RID: 4020
	public const sbyte CMD_CANCEL_QUEST = 1;

	// Token: 0x04000FB5 RID: 4021
	public const sbyte CMD_CLOSE_QUEST = 2;

	// Token: 0x04000FB6 RID: 4022
	public const sbyte CMD_CHANGE_EQUIP = 3;

	// Token: 0x04000FB7 RID: 4023
	public const sbyte CMD_OK_AUTO_MP_HP = 4;

	// Token: 0x04000FB8 RID: 4024
	public const sbyte CMD_LEARN_SKILL = 5;

	// Token: 0x04000FB9 RID: 4025
	public const sbyte CMD_OK_AUTO_GET_ITEM = 6;

	// Token: 0x04000FBA RID: 4026
	public const sbyte CMD_JOIN_ITEM = 7;

	// Token: 0x04000FBB RID: 4027
	public const sbyte CMD_JOIN_ITEM_OK = 8;

	// Token: 0x04000FBC RID: 4028
	public const sbyte CMD_OK_AUTO_FIRE = 9;

	// Token: 0x04000FBD RID: 4029
	public const sbyte CMD_CLOSE_GIFT = 10;

	// Token: 0x04000FBE RID: 4030
	public const sbyte CMD_OPEN_NEXT = 11;

	// Token: 0x04000FBF RID: 4031
	public const sbyte CMD_CLOSE_SOUND = 12;

	// Token: 0x04000FC0 RID: 4032
	public const sbyte CMD_REWARD = 13;

	// Token: 0x04000FC1 RID: 4033
	public const sbyte CMD_DAILY_LOGIN = 14;

	// Token: 0x04000FC2 RID: 4034
	public const sbyte CMD_CLOSE_MSG_SPAM = 15;

	// Token: 0x04000FC3 RID: 4035
	public const sbyte CMD_CONFIRM_DOI_QUA = 16;

	// Token: 0x04000FC4 RID: 4036
	public const sbyte NORMAL = 0;

	// Token: 0x04000FC5 RID: 4037
	public const sbyte WAITING = 1;

	// Token: 0x04000FC6 RID: 4038
	public const sbyte QUEST = 2;

	// Token: 0x04000FC7 RID: 4039
	public const sbyte SKILL_INFO = 4;

	// Token: 0x04000FC8 RID: 4040
	public const sbyte NORMAL_2 = 5;

	// Token: 0x04000FC9 RID: 4041
	public const sbyte TIME = 6;

	// Token: 0x04000FCA RID: 4042
	public const sbyte NORMAL_ITEM = 7;

	// Token: 0x04000FCB RID: 4043
	public const sbyte WAITING_CONNECT = 8;

	// Token: 0x04000FCC RID: 4044
	public const sbyte RE_CONNECT = 9;

	// Token: 0x04000FCD RID: 4045
	public const sbyte INFO_CLAN = 10;

	// Token: 0x04000FCE RID: 4046
	public int idCommand;

	// Token: 0x04000FCF RID: 4047
	public mVector cmdList = new mVector();

	// Token: 0x04000FD0 RID: 4048
	public static mVector vecEff = new mVector("MsgDialog.vecEff");

	// Token: 0x04000FD1 RID: 4049
	public mVector vecEffUni = new mVector("MsgShowGift.vecEffUni");

	// Token: 0x04000FD2 RID: 4050
	public iCommand cmdClose;

	// Token: 0x04000FD3 RID: 4051
	public iCommand cmdChangeEquip;

	// Token: 0x04000FD4 RID: 4052
	public mFont fontDia = mFont.tahoma_7_black;

	// Token: 0x04000FD5 RID: 4053
	public static FrameImage fraImgWaiting;

	// Token: 0x04000FD6 RID: 4054
	public static FrameImage fraAutoMpHp;

	// Token: 0x04000FD7 RID: 4055
	public int fWait;

	// Token: 0x04000FD8 RID: 4056
	public int wItem;

	// Token: 0x04000FD9 RID: 4057
	public int idSelect;

	// Token: 0x04000FDA RID: 4058
	public static int hPlus;

	// Token: 0x04000FDB RID: 4059
	public MainQuest quest;

	// Token: 0x04000FDC RID: 4060
	public bool isClose;

	// Token: 0x04000FDD RID: 4061
	public bool isNewShop;

	// Token: 0x04000FDE RID: 4062
	public ListNew list = new ListNew();

	// Token: 0x04000FDF RID: 4063
	public string nameDialog = string.Empty;

	// Token: 0x04000FE0 RID: 4064
	public static int xEFF;

	// Token: 0x04000FE1 RID: 4065
	public static int yEFF;

	// Token: 0x04000FE2 RID: 4066
	public string infoHelp = string.Empty;

	// Token: 0x04000FE3 RID: 4067
	public int wInfoHelp;

	// Token: 0x04000FE4 RID: 4068
	public int tickCloseInfoHelp;

	// Token: 0x04000FE5 RID: 4069
	private CountDownTicket timeDialog;

	// Token: 0x04000FE6 RID: 4070
	public mVector vecItem;

	// Token: 0x04000FE7 RID: 4071
	public static bool isAuroReconect = false;

	// Token: 0x04000FE8 RID: 4072
	private MainClan clanpaint;

	// Token: 0x04000FE9 RID: 4073
	private string linkDownLoad = string.Empty;

	// Token: 0x04000FEA RID: 4074
	public int wShowPaper;

	// Token: 0x04000FEB RID: 4075
	public int maxWShow = 160;

	// Token: 0x04000FEC RID: 4076
	public int vShow = 6;

	// Token: 0x04000FED RID: 4077
	private Skill_Info skill;

	// Token: 0x04000FEE RID: 4078
	private int[] posValueName;

	// Token: 0x04000FEF RID: 4079
	public int xBegin;

	// Token: 0x04000FF0 RID: 4080
	public int w2cmd;

	// Token: 0x04000FF1 RID: 4081
	public int miniItem = 5;

	// Token: 0x04000FF2 RID: 4082
	private int lastTick;

	// Token: 0x04000FF3 RID: 4083
	private int framepaint;
}
