using System;

// Token: 0x0200004C RID: 76
public interface IMessageHandler
{
	// Token: 0x06000577 RID: 1399
	void onMessage(Message message);

	// Token: 0x06000578 RID: 1400
	void onConnectionFail();

	// Token: 0x06000579 RID: 1401
	void onDisconnected();

	// Token: 0x0600057A RID: 1402
	void onConnectOK();
}
