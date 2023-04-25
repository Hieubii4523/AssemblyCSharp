using System;

// Token: 0x020000D1 RID: 209
public class PopupChat : AvMain
{
	// Token: 0x06000C00 RID: 3072 RVA: 0x000E7738 File Offset: 0x000E5938
	public void setChat(string strContent, bool isStop)
	{
		this.isStop = isStop;
		this.isEmotion = 0;
		strContent = strContent.Trim();
		this.w = mFont.tahoma_7_black.getWidth(strContent);
		bool flag = this.w > 100;
		if (flag)
		{
			this.w = 100;
		}
		else
		{
			bool flag2 = this.w < 20;
			if (flag2)
			{
				this.w = 20;
			}
		}
		this.dy = 8;
		this.strChat = mFont.tahoma_7_black.splitFontArray(strContent, this.w);
		this.h = this.strChat.Length * GameCanvas.hText;
		bool flag3 = this.strChat.Length <= 2;
		if (flag3)
		{
			this.timeOff = 100;
		}
		else
		{
			this.timeOff = 160;
		}
	}

	// Token: 0x06000C01 RID: 3073 RVA: 0x0000BA63 File Offset: 0x00009C63
	public void setChat(short id)
	{
		this.isStop = true;
		this.isEmotion = 1;
		this.w = 22;
		this.h = 22;
		this.dy = 8;
		this.idEmotion = id;
		this.timeOff = 200;
	}

	// Token: 0x06000C02 RID: 3074 RVA: 0x000E77FC File Offset: 0x000E59FC
	public void setChatItem(short id, sbyte cat, short num)
	{
		this.isStop = true;
		this.isEmotion = 2;
		this.w = 22;
		this.h = 22;
		this.dy = 8;
		this.item = new MainItem(cat, id, id);
		this.item.numPotion = num;
		this.timeOff = 100;
	}

	// Token: 0x06000C03 RID: 3075 RVA: 0x000E7854 File Offset: 0x000E5A54
	public override void paint(mGraphics g)
	{
		bool flag = this.dy > 0;
		if (flag)
		{
			this.dy -= 2;
		}
		this.paintPopup(g);
	}

	// Token: 0x06000C04 RID: 3076 RVA: 0x0000BA9D File Offset: 0x00009C9D
	public void updatePos(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	// Token: 0x06000C05 RID: 3077 RVA: 0x000E7888 File Offset: 0x000E5A88
	public bool setOff()
	{
		this.timeOff--;
		return this.timeOff <= 0 && this.isStop;
	}

	// Token: 0x06000C06 RID: 3078 RVA: 0x000E78C4 File Offset: 0x000E5AC4
	public void paintPopup(mGraphics g)
	{
		try
		{
			int num = this.y - this.h + this.dy;
			int num2 = this.x - this.w / 2;
			g.setColor(this.color[0]);
			g.fillRect(num2 - 3, num, this.w + 6, this.h);
			g.fillRect(num2, num - 3, this.w, this.h + 6);
			g.setColor(this.color[1]);
			g.fillRect(num2, num - 2, this.w, this.h + 4);
			g.fillRect(num2 - 2, num, this.w + 4, this.h);
			g.drawRegion(PopupChat.mPopup[0], 0, 0, 3, 3, 0, (float)(num2 - 3), (float)(num - 3), 0);
			g.drawRegion(PopupChat.mPopup[0], 0, 3, 3, 3, 0, (float)(num2 + this.w), (float)(num - 3), 0);
			g.drawRegion(PopupChat.mPopup[0], 0, 9, 3, 3, 0, (float)(num2 - 3), (float)(num + this.h), 0);
			g.drawRegion(PopupChat.mPopup[0], 0, 6, 3, 3, 0, (float)(num2 + this.w), (float)(num + this.h), 0);
			bool flag = this.indexpaint == 1;
			if (flag)
			{
				g.drawRegion(PopupChat.mPopup[1], 0, 0, 7, 7, 3, (float)(num2 + this.w / 2 - 3), (float)(num - 9), 0);
			}
			else
			{
				g.drawImage(PopupChat.mPopup[1], num2 + this.w / 2 - 3, num + this.h + 2, 0);
			}
			bool flag2 = this.isEmotion != 0;
			if (flag2)
			{
				bool flag3 = this.isEmotion == 1;
				if (flag3)
				{
					MainImage imageAll = ObjectData.getImageAll(this.idEmotion, ObjectData.hashImageItemOther, 9000);
					bool flag4 = imageAll.img != null && imageAll.frame == -1;
					if (flag4)
					{
						imageAll.set_Frame(24);
					}
					int num3 = (int)(imageAll.frame + 1);
					bool flag5 = num3 == 0;
					if (flag5)
					{
						num3 = 1;
					}
					int num4 = GameCanvas.gameTick / 8 % num3;
					bool flag6 = num4 >= (int)imageAll.frame;
					if (flag6)
					{
						num4 = (int)(imageAll.frame - 1);
					}
					g.drawRegion(imageAll.img, 0, num4 * 24, 24, 24, 0, (float)(num2 + this.w / 2), (float)(num + this.h / 2), 3);
				}
				else
				{
					bool flag7 = this.isEmotion == 2 && this.item != null;
					if (flag7)
					{
						this.item.paintAllItem(g, num2 + this.w / 2, num + this.h / 2, 22, 0, 0);
					}
				}
			}
			else
			{
				bool flag8 = this.strChat != null;
				if (flag8)
				{
					for (int i = 0; i < this.strChat.Length; i++)
					{
						mFont.tahoma_7_black.drawString(g, this.strChat[i], num2 + this.w / 2, num + 1 + i * GameCanvas.hText, 2);
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x040012F3 RID: 4851
	public const sbyte E_NONE = 0;

	// Token: 0x040012F4 RID: 4852
	public const sbyte E_EMOTION = 1;

	// Token: 0x040012F5 RID: 4853
	public const sbyte E_ITEM = 2;

	// Token: 0x040012F6 RID: 4854
	private int x = MotherCanvas.hw;

	// Token: 0x040012F7 RID: 4855
	private int y = MotherCanvas.hh;

	// Token: 0x040012F8 RID: 4856
	private int dy;

	// Token: 0x040012F9 RID: 4857
	public int h;

	// Token: 0x040012FA RID: 4858
	public int w;

	// Token: 0x040012FB RID: 4859
	public int timeOff;

	// Token: 0x040012FC RID: 4860
	public int indexpaint;

	// Token: 0x040012FD RID: 4861
	public short idEmotion;

	// Token: 0x040012FE RID: 4862
	public string[] strChat;

	// Token: 0x040012FF RID: 4863
	public static mImage[] mPopup = new mImage[2];

	// Token: 0x04001300 RID: 4864
	private bool isStop = true;

	// Token: 0x04001301 RID: 4865
	private sbyte isEmotion;

	// Token: 0x04001302 RID: 4866
	private MainItem item;

	// Token: 0x04001303 RID: 4867
	private int[] color = new int[]
	{
		3349556,
		16760428
	};
}
