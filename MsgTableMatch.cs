using System;

// Token: 0x020000AD RID: 173
public class MsgTableMatch : MsgDialog
{
	// Token: 0x06000A76 RID: 2678 RVA: 0x000D4B3C File Offset: 0x000D2D3C
	public void setinfo(mVector vec)
	{
		bool flag = vec != null && vec.size() != 0;
		if (flag)
		{
			this.vecMatch.removeAllElements();
			this.wDia = 190;
			this.hDia = 200;
			this.wItem = 80;
			bool flag2 = this.wDia > MotherCanvas.w;
			if (flag2)
			{
				this.wDia = MotherCanvas.w;
			}
			bool flag3 = this.hDia > MotherCanvas.h - 26;
			if (flag3)
			{
				this.hDia = GameCanvas.hCommand - 26;
			}
			bool flag4 = vec.size() * this.wItem + 10 < this.hDia;
			if (flag4)
			{
				this.hDia = vec.size() * this.wItem + 10;
				this.list = new ListNew(this.xDia, this.yDia, this.wDia, this.hDia - 16, 0, 0, 0, false);
			}
			else
			{
				this.list = new ListNew(this.xDia, this.yDia, this.wDia, this.hDia - 16, 0, 0, vec.size() * this.wItem - (this.hDia - 15), false);
			}
			this.xDia = MotherCanvas.w / 2 - this.wDia / 2;
			this.yDia = MotherCanvas.h / 2 - this.hDia / 2 + 13;
			this.vecMatch = vec;
			this.cmdClose = new iCommand(T.close, -1, this);
			this.cmdClose = AvMain.setPosCMD(this.cmdClose, 2);
			bool flag5 = GameCanvas.isTouchNoOrPC();
			if (flag5)
			{
				this.right = this.cmdClose;
				this.backCMD = this.cmdClose;
			}
			bool flag6 = AvMain.imgFightMatch == null || AvMain.imgStarMatch == null || AvMain.fraMatch == null;
			if (flag6)
			{
				LoadImageStatic.LoadImgMatch();
			}
		}
	}

	// Token: 0x06000A77 RID: 2679 RVA: 0x000D4D18 File Offset: 0x000D2F18
	public override void commandPointer(int index, int subIndex)
	{
		bool flag = index == -1;
		if (flag)
		{
			GameCanvas.end_Dialog();
		}
	}

	// Token: 0x06000A78 RID: 2680 RVA: 0x000D4D38 File Offset: 0x000D2F38
	public override void paint(mGraphics g)
	{
		base.paintPaper_UpDown(g, this.xDia, this.yDia, this.wDia, this.hDia, this.hDia);
		g.setClip(this.xDia + 10, this.yDia + 8, this.wDia - 20, this.hDia - 16);
		g.saveCanvas();
		g.ClipRec(this.xDia + 10, this.yDia + 8, this.wDia - 20, this.hDia - 16);
		g.translate(0, -this.list.cmx);
		int num = this.yDia;
		int num2 = this.xDia + 5;
		for (int i = 0; i < this.vecMatch.size(); i++)
		{
			InfoMatch infoMatch = (InfoMatch)this.vecMatch.elementAt(i);
			AvMain.fraMatch.drawFrame(infoMatch.type, num2 + this.wDia / 2, num + 20, 0, 3, g);
			int num3 = infoMatch.mname.Length;
			int num4 = num + 20 + 30;
			bool flag = infoMatch.type == 1;
			if (flag)
			{
				num4 = num + 35;
			}
			g.drawImage(AvMain.imgFightMatch, num2 + this.wDia / 2, num + this.wItem / 2 + 18, 3);
			for (int j = 0; j < num3; j++)
			{
				bool flag2 = infoMatch.type == 2;
				if (flag2)
				{
					bool flag3 = j < num3 / 2;
					if (flag3)
					{
						mFont.tahoma_7b_red.drawString(g, T.Clan, num2 + this.wDia / 4, num4 - GameCanvas.hText / 2, 2);
						mFont.tahoma_7b_red.drawString(g, infoMatch.mname[j], num2 + this.wDia / 4, num4 + GameCanvas.hText / 2, 2);
					}
					else
					{
						mFont.tahoma_7b_blue.drawString(g, T.Clan, num2 + this.wDia / 4 * 3, num4 - GameCanvas.hText / 2, 2);
						mFont.tahoma_7b_blue.drawString(g, infoMatch.mname[j], num2 + this.wDia / 4 * 3, num4 + GameCanvas.hText / 2, 2);
					}
				}
				else
				{
					bool flag4 = j < num3 / 2;
					if (flag4)
					{
						bool flag5 = infoMatch.typeLeftRight == 0;
						if (flag5)
						{
							AvMain.FontBorderColor(g, infoMatch.mname[j], num2 + this.wDia / 4, num4 + 30 * (j % (num3 / 2)), 2, 6, 7);
						}
						else
						{
							mFont.tahoma_7b_red.drawString(g, infoMatch.mname[j], num2 + this.wDia / 4, num4 + 30 * (j % (num3 / 2)), 2);
						}
					}
					else
					{
						bool flag6 = infoMatch.typeLeftRight == 1;
						if (flag6)
						{
							AvMain.FontBorderColor(g, infoMatch.mname[j], num2 + this.wDia / 4 * 3, num4 + 30 * (j % (num3 / 2)), 2, 4, 7);
						}
						else
						{
							mFont.tahoma_7b_blue.drawString(g, infoMatch.mname[j], num2 + this.wDia / 4 * 3, num4 + 30 * (j % (num3 / 2)), 2);
						}
					}
				}
			}
			bool flag7 = i < this.vecMatch.size() - 1;
			if (flag7)
			{
				for (int k = 0; k < 3; k++)
				{
					bool flag8 = k == 2;
					if (flag8)
					{
						g.drawRegion(AvMain.imgStarMatch, 0, 0, 38, 5, 0, (float)(num2 + this.wDia / 2 - 60 + k * 40), (float)(num + this.wItem + 4), 0);
					}
					else
					{
						g.drawImage(AvMain.imgStarMatch, num2 + this.wDia / 2 - 60 + k * 40, num + this.wItem + 4, 0);
					}
				}
			}
			num += this.wItem;
		}
		mGraphics.resetTransAndroid(g);
		g.restoreCanvas();
		GameCanvas.resetTrans(g);
		bool flag9 = !GameCanvas.isTouch && this.right != null;
		if (flag9)
		{
			this.right.paint(g, this.right.xCmd, this.right.yCmd);
		}
	}

	// Token: 0x06000A79 RID: 2681 RVA: 0x0000B474 File Offset: 0x00009674
	public override void update()
	{
		this.list.moveCamera();
		this.updatePointer();
		this.updatekey();
	}

	// Token: 0x06000A7A RID: 2682 RVA: 0x000D516C File Offset: 0x000D336C
	public override void updatekey()
	{
		bool flag = false;
		bool flag2 = GameCanvas.keyMove(1);
		if (flag2)
		{
			this.idSelect--;
			GameCanvas.ClearkeyMove(1);
			flag = true;
		}
		else
		{
			bool flag3 = GameCanvas.keyMove(3);
			if (flag3)
			{
				this.idSelect++;
				GameCanvas.ClearkeyMove(3);
				flag = true;
			}
		}
		bool flag4 = flag;
		if (flag4)
		{
			this.idSelect = AvMain.resetSelect(this.idSelect, this.vecMatch.size() - 1, false);
			bool flag5 = GameCanvas.isTouchNoOrPC();
			if (flag5)
			{
				this.list.setToX((this.idSelect + 1) * this.wItem - (this.hDia - 16) / 2);
			}
		}
		base.updatekeyCMD();
	}

	// Token: 0x06000A7B RID: 2683 RVA: 0x000D5228 File Offset: 0x000D3428
	public override void updatePointer()
	{
		this.list.update_Pos_UP_DOWN();
		bool flag = GameCanvas.isPointerSelect && !GameCanvas.isPoint(this.xDia, this.yDia, this.wDia, this.hDia);
		if (flag)
		{
			GameCanvas.end_Dialog();
			GameCanvas.isPointerSelect = false;
		}
	}

	// Token: 0x04001068 RID: 4200
	public mVector vecMatch = new mVector("MsgTableMatch.vecMatch");
}
