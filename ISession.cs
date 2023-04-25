using System;

// Token: 0x0200005A RID: 90
public interface ISession
{
	// Token: 0x06000610 RID: 1552
	bool isConnected();

	// Token: 0x06000611 RID: 1553
	void setHandler(IMessageHandler messageHandler);

	// Token: 0x06000612 RID: 1554
	void connect(string host, int port);

	// Token: 0x06000613 RID: 1555
	void sendMessage(Message message);

	// Token: 0x06000614 RID: 1556
	void close();
}
