using System;

// Token: 0x02000014 RID: 20
public class ChatTextField : AvMain
{
	// Token: 0x060000BB RID: 187 RVA: 0x00016774 File Offset: 0x00014974
	protected ChatTextField()
	{
		this.tfChat = new TField();
		this.tfChat.isChangeFocus = false;
		this.tfChat.setFocus(true);
		this.init();
		this.tfChat.x = (MotherCanvas.w - this.tfChat.width) / 2;
		bool flag = GameMidlet.DEVICE == 2;
		if (flag)
		{
			this.tfChat.x = 10;
		}
		this.tfChat.setMaxTextLenght(70);
		this.tfChat.setStringNull(T.chat);
		bool flag2 = !GameCanvas.isTouch;
		if (flag2)
		{
			this.left = new iCommand(T.close, 0);
			this.center = new iCommand(T.chat, 1);
			this.right = this.tfChat.setCmdClear();
		}
	}

	// Token: 0x060000BC RID: 188 RVA: 0x00016850 File Offset: 0x00014A50
	public static ChatTextField gI()
	{
		return (ChatTextField.instance != null) ? ChatTextField.instance : (ChatTextField.instance = new ChatTextField());
	}

	// Token: 0x060000BD RID: 189 RVA: 0x0001687C File Offset: 0x00014A7C
	public void setChat()
	{
		ChatTextField.isShow = !ChatTextField.isShow;
		bool flag = ChatTextField.isShow;
		if (flag)
		{
			this.tfChat.setPoiter();
		}
	}

	// Token: 0x060000BE RID: 190 RVA: 0x000168B0 File Offset: 0x00014AB0
	public override void commandTab(int index, int subIndex)
	{
		if (index != 0)
		{
			if (index == 1)
			{
				this.sendChat();
			}
		}
		else
		{
			GameCanvas.clearAll();
			this.tfChat.setText(string.Empty);
			ChatTextField.isShow = false;
			bool flag = !GameCanvas.isTouch;
			if (flag)
			{
				this.tfChat.setFocus(true);
			}
		}
	}

	// Token: 0x060000BF RID: 191 RVA: 0x00016910 File Offset: 0x00014B10
	public void init()
	{
		this.tfChat.y = MotherCanvas.h - iCommand.hButtonCmdNor - this.tfChat.height - 5;
		this.tfChat.width = MotherCanvas.w - TField.xDu * 2 - 20;
		bool flag = GameMidlet.DEVICE == 2;
		if (flag)
		{
			this.tfChat.y = MotherCanvas.h - this.tfChat.height - 10;
			this.tfChat.width = MotherCanvas.w / 2 - 10;
		}
	}

	// Token: 0x060000C0 RID: 192 RVA: 0x00009334 File Offset: 0x00007534
	public void keyPressed(int keyCode)
	{
		this.tfChat.keyPressed(keyCode);
	}

	// Token: 0x060000C1 RID: 193 RVA: 0x00009344 File Offset: 0x00007544
	public override void updatekey()
	{
		this.tfChat.update();
		base.updatekey();
	}

	// Token: 0x060000C2 RID: 194 RVA: 0x0000935A File Offset: 0x0000755A
	public override void paint(mGraphics g)
	{
		base.paint(g);
		this.tfChat.paint(g);
	}

	// Token: 0x060000C3 RID: 195 RVA: 0x00009372 File Offset: 0x00007572
	public override void updatePointer()
	{
		this.tfChat.updatePointer();
		base.updatePointer();
	}

	// Token: 0x060000C4 RID: 196 RVA: 0x000169A0 File Offset: 0x00014BA0
	public void sendChat()
	{
		bool flag = this.tfChat.getText().Length > 0;
		if (flag)
		{
			GameScreen.player.strChatPopup = this.tfChat.getText();
			GlobalService.gI().chatPopup(this.tfChat.getText());
			this.tfChat.setText(string.Empty);
		}
		bool isTouch = GameCanvas.isTouch;
		if (isTouch)
		{
			ChatTextField.isShow = false;
		}
	}

	// Token: 0x04000166 RID: 358
	public TField tfChat;

	// Token: 0x04000167 RID: 359
	public static ChatTextField instance;

	// Token: 0x04000168 RID: 360
	public static bool isShow;
}
