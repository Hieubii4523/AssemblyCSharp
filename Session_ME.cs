using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

// Token: 0x020000EA RID: 234
public class Session_ME : ISession
{
	// Token: 0x06000E12 RID: 3602 RVA: 0x0000BE2A File Offset: 0x0000A02A
	public Session_ME()
	{
		Debug.Log("init Session_ME");
	}

	// Token: 0x06000E13 RID: 3603 RVA: 0x0000BE3F File Offset: 0x0000A03F
	public void clearSendingMessage()
	{
		Session_ME.sender.sendingMessage.Clear();
	}

	// Token: 0x06000E14 RID: 3604 RVA: 0x001103B0 File Offset: 0x0010E5B0
	public static Session_ME gI()
	{
		bool flag = Session_ME.instance == null;
		if (flag)
		{
			Session_ME.instance = new Session_ME();
		}
		return Session_ME.instance;
	}

	// Token: 0x06000E15 RID: 3605 RVA: 0x001103E0 File Offset: 0x0010E5E0
	public bool isConnected()
	{
		return Session_ME.connected;
	}

	// Token: 0x06000E16 RID: 3606 RVA: 0x0000BE52 File Offset: 0x0000A052
	public void setHandler(IMessageHandler msgHandler)
	{
		Session_ME.messageHandler = msgHandler;
	}

	// Token: 0x06000E17 RID: 3607 RVA: 0x001103F8 File Offset: 0x0010E5F8
	public void connect(string host, int port)
	{
		Debug.Log("connect ...!" + Session_ME.connected.ToString() + "  ::  " + Session_ME.connecting.ToString());
		bool flag = !Session_ME.connected && !Session_ME.connecting;
		if (flag)
		{
			this.host = host;
			this.port = port;
			Session_ME.getKeyComplete = false;
			Session_ME.sc = null;
			Debug.Log("connecting...!");
			Debug.Log("host: " + host);
			Debug.Log("port: " + port.ToString());
			Session_ME.initThread = new Thread(new ThreadStart(this.NetworkInit));
			Session_ME.initThread.Start();
		}
	}

	// Token: 0x06000E18 RID: 3608 RVA: 0x001104B8 File Offset: 0x0010E6B8
	private void NetworkInit()
	{
		string str = "NetworkInit: ";
		IMessageHandler messageHandler = Session_ME.messageHandler;
		Out.printLine(str + ((messageHandler != null) ? messageHandler.ToString() : null));
		Session_ME.isCancel = false;
		Session_ME.connecting = true;
		Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Highest;
		Session_ME.connected = true;
		try
		{
			this.doConnect(this.host, this.port);
			Session_ME.messageHandler.onConnectOK();
		}
		catch (Exception)
		{
			bool flag = Session_ME.messageHandler != null;
			if (flag)
			{
				this.close();
				Session_ME.messageHandler.onConnectionFail();
			}
		}
	}

	// Token: 0x06000E19 RID: 3609 RVA: 0x0011055C File Offset: 0x0010E75C
	public void doConnect(string host, int port)
	{
		try
		{
			Session_ME.isStart = true;
			Session_ME.timeStart = GameCanvas.getTime();
			Session_ME.sc = new TcpClient();
			Session_ME.sc.Connect(host, port);
			Session_ME.dataStream = Session_ME.sc.GetStream();
			Session_ME.isStart = false;
			Session_ME.dis = new BinaryReader(Session_ME.dataStream, new UTF8Encoding());
			Session_ME.dos = new BinaryWriter(Session_ME.dataStream, new UTF8Encoding());
			new Thread(new ThreadStart(Session_ME.sender.run)).Start();
			Session_ME.MessageCollector @object = new Session_ME.MessageCollector();
			Out.printLine("new -----");
			Session_ME.collectorThread = new Thread(new ThreadStart(@object.run));
			Session_ME.collectorThread.Start();
			Session_ME.timeConnected = Session_ME.currentTimeMillis();
			Session_ME.connecting = false;
			Session_ME.doSendMessage(new Message(-27));
		}
		catch (Exception)
		{
			bool flag = Session_ME.messageHandler != null;
			if (flag)
			{
				Session_ME.messageHandler.onConnectionFail();
			}
		}
	}

	// Token: 0x06000E1A RID: 3610 RVA: 0x0000BE5B File Offset: 0x0000A05B
	public void sendMessage(Message message)
	{
		Session_ME.sender.AddMessage(message);
	}

	// Token: 0x06000E1B RID: 3611 RVA: 0x0011066C File Offset: 0x0010E86C
	private static void doSendMessage(Message m)
	{
		sbyte[] data = m.getData();
		int num = 0;
		try
		{
			Session_ME.test = 1.ToString() + " " + m.command.ToString();
			bool flag = Session_ME.getKeyComplete;
			if (flag)
			{
				sbyte value = Session_ME.writeKey(m.command);
				Session_ME.dos.Write(value);
			}
			else
			{
				Session_ME.dos.Write(m.command);
			}
			bool flag2 = data != null;
			if (flag2)
			{
				Session_ME.test = 2.ToString() + " " + m.command.ToString();
				int num2 = data.Length;
				bool flag3 = Session_ME.getKeyComplete;
				if (flag3)
				{
					int num3 = (int)Session_ME.writeKey((sbyte)(num2 >> 8));
					Session_ME.dos.Write((sbyte)num3);
					int num4 = (int)Session_ME.writeKey((sbyte)(num2 & 255));
					Session_ME.dos.Write((sbyte)num4);
				}
				else
				{
					Session_ME.dos.Write((ushort)num2);
				}
				Session_ME.test = 3.ToString() + " " + m.command.ToString();
				bool flag4 = Session_ME.getKeyComplete;
				if (flag4)
				{
					for (int i = 0; i < data.Length; i++)
					{
						sbyte value2 = Session_ME.writeKey(data[i]);
						Session_ME.dos.Write(value2);
					}
				}
				Session_ME.test = 4.ToString() + " " + m.command.ToString();
				Session_ME.sendByteCount += 5 + data.Length;
			}
			else
			{
				Session_ME.test = 5.ToString() + " " + m.command.ToString();
				bool flag5 = Session_ME.getKeyComplete;
				if (flag5)
				{
					int num5 = 0;
					int num6 = (int)Session_ME.writeKey((sbyte)(num5 >> 8));
					Session_ME.dos.Write((sbyte)num6);
					int num7 = (int)Session_ME.writeKey((sbyte)(num5 & 255));
					Session_ME.dos.Write((sbyte)num7);
				}
				else
				{
					Session_ME.dos.Write(0);
				}
				Session_ME.sendByteCount += 5;
				Session_ME.test = 6.ToString() + " " + m.command.ToString();
			}
			Session_ME.dos.Flush();
			Session_ME.test = 7.ToString() + " " + m.command.ToString();
		}
		catch (Exception ex)
		{
			Out.printLine("ERROR SEND MSG: " + num.ToString() + "   " + m.command.ToString());
			Debug.Log(ex.StackTrace);
		}
	}

	// Token: 0x06000E1C RID: 3612 RVA: 0x0011093C File Offset: 0x0010EB3C
	public static sbyte readKey(sbyte b)
	{
		sbyte[] array = Session_ME.key;
		sbyte b2 = Session_ME.curR;
		Session_ME.curR = b2 + 1;
		sbyte result = (sbyte)((array[(int)b2] & 255) ^ ((int)b & 255));
		bool flag = (int)Session_ME.curR >= Session_ME.key.Length;
		if (flag)
		{
			Session_ME.curR %= (sbyte)Session_ME.key.Length;
		}
		return result;
	}

	// Token: 0x06000E1D RID: 3613 RVA: 0x001109A0 File Offset: 0x0010EBA0
	public static sbyte writeKey(sbyte b)
	{
		sbyte[] array = Session_ME.key;
		sbyte b2 = Session_ME.curW;
		Session_ME.curW = b2 + 1;
		sbyte result = (sbyte)((array[(int)b2] & 255) ^ ((int)b & 255));
		bool flag = (int)Session_ME.curW >= Session_ME.key.Length;
		if (flag)
		{
			Session_ME.curW %= (sbyte)Session_ME.key.Length;
		}
		return result;
	}

	// Token: 0x06000E1E RID: 3614 RVA: 0x00110A04 File Offset: 0x0010EC04
	public static void onRecieveMsg(Message msg)
	{
		bool flag = Thread.CurrentThread.Name == Main.mainThreadName;
		if (flag)
		{
			Session_ME.messageHandler.onMessage(msg);
		}
		else
		{
			Session_ME.recieveMsg.addElement(msg);
		}
	}

	// Token: 0x06000E1F RID: 3615 RVA: 0x00110A48 File Offset: 0x0010EC48
	public static void update()
	{
		while (Session_ME.recieveMsg.size() > 0)
		{
			Message message = (Message)Session_ME.recieveMsg.elementAt(0);
			bool flag = message == null;
			if (flag)
			{
				Session_ME.recieveMsg.removeElementAt(0);
				break;
			}
			Session_ME.messageHandler.onMessage(message);
			Session_ME.recieveMsg.removeElementAt(0);
		}
	}

	// Token: 0x06000E20 RID: 3616 RVA: 0x0000BE6A File Offset: 0x0000A06A
	public void close()
	{
		Session_ME.recieveMsg.removeAllElements();
		Session_ME.cleanNetwork();
		Session_ME.isStart = false;
		Session_ME.messageHandler = null;
	}

	// Token: 0x06000E21 RID: 3617 RVA: 0x00110AAC File Offset: 0x0010ECAC
	private static void cleanNetwork()
	{
		Session_ME.key = null;
		Session_ME.curR = 0;
		Session_ME.curW = 0;
		try
		{
			Session_ME.connected = false;
			Session_ME.connecting = false;
			bool flag = Session_ME.sc != null;
			if (flag)
			{
				Session_ME.sc.Close();
				Session_ME.sc = null;
			}
			bool flag2 = Session_ME.dataStream != null;
			if (flag2)
			{
				Session_ME.dataStream.Close();
				Session_ME.dataStream = null;
			}
			bool flag3 = Session_ME.dos != null;
			if (flag3)
			{
				Session_ME.dos.Close();
				Session_ME.dos = null;
			}
			bool flag4 = Session_ME.dis != null;
			if (flag4)
			{
				Session_ME.dis.Close();
				Session_ME.dis = null;
			}
			Session_ME.sendThread = null;
			Session_ME.collectorThread = null;
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000E22 RID: 3618 RVA: 0x00110B7C File Offset: 0x0010ED7C
	public static int currentTimeMillis()
	{
		return Environment.TickCount;
	}

	// Token: 0x06000E23 RID: 3619 RVA: 0x0007F128 File Offset: 0x0007D328
	public static byte convertSbyteToByte(sbyte var)
	{
		bool flag = var > 0;
		byte result;
		if (flag)
		{
			result = (byte)var;
		}
		else
		{
			result = (byte)((int)var + 256);
		}
		return result;
	}

	// Token: 0x06000E24 RID: 3620 RVA: 0x0007F150 File Offset: 0x0007D350
	public static byte[] convertSbyteToByte(sbyte[] var)
	{
		byte[] array = new byte[var.Length];
		for (int i = 0; i < var.Length; i++)
		{
			bool flag = var[i] > 0;
			if (flag)
			{
				array[i] = (byte)var[i];
			}
			else
			{
				array[i] = (byte)((int)var[i] + 256);
			}
		}
		return array;
	}

	// Token: 0x04001585 RID: 5509
	protected static Session_ME instance = new Session_ME();

	// Token: 0x04001586 RID: 5510
	private static NetworkStream dataStream;

	// Token: 0x04001587 RID: 5511
	private static BinaryReader dis;

	// Token: 0x04001588 RID: 5512
	private static BinaryWriter dos;

	// Token: 0x04001589 RID: 5513
	public static IMessageHandler messageHandler;

	// Token: 0x0400158A RID: 5514
	private static TcpClient sc;

	// Token: 0x0400158B RID: 5515
	public static bool connected;

	// Token: 0x0400158C RID: 5516
	public static bool connecting;

	// Token: 0x0400158D RID: 5517
	public static bool isStart;

	// Token: 0x0400158E RID: 5518
	private static Session_ME.Sender sender = new Session_ME.Sender();

	// Token: 0x0400158F RID: 5519
	public static Thread initThread;

	// Token: 0x04001590 RID: 5520
	public static Thread collectorThread;

	// Token: 0x04001591 RID: 5521
	public static Thread sendThread;

	// Token: 0x04001592 RID: 5522
	public static int sendByteCount;

	// Token: 0x04001593 RID: 5523
	public static int recvByteCount;

	// Token: 0x04001594 RID: 5524
	private static bool getKeyComplete;

	// Token: 0x04001595 RID: 5525
	public static sbyte[] key = null;

	// Token: 0x04001596 RID: 5526
	private static sbyte curR;

	// Token: 0x04001597 RID: 5527
	private static sbyte curW;

	// Token: 0x04001598 RID: 5528
	private static int timeConnected;

	// Token: 0x04001599 RID: 5529
	public static string strRecvByteCount = string.Empty;

	// Token: 0x0400159A RID: 5530
	public static bool isCancel;

	// Token: 0x0400159B RID: 5531
	private string host;

	// Token: 0x0400159C RID: 5532
	private int port;

	// Token: 0x0400159D RID: 5533
	public static long timeStart = 0L;

	// Token: 0x0400159E RID: 5534
	private static string test = string.Empty;

	// Token: 0x0400159F RID: 5535
	public static mVector recieveMsg = new mVector();

	// Token: 0x020000EB RID: 235
	public class Sender
	{
		// Token: 0x06000E26 RID: 3622 RVA: 0x0000BE8A File Offset: 0x0000A08A
		public Sender()
		{
			this.sendingMessage = new List<Message>();
		}

		// Token: 0x06000E27 RID: 3623 RVA: 0x0000BE9F File Offset: 0x0000A09F
		public void AddMessage(Message message)
		{
			this.sendingMessage.Add(message);
		}

		// Token: 0x06000E28 RID: 3624 RVA: 0x00110BE0 File Offset: 0x0010EDE0
		public void run()
		{
			while (Session_ME.connected)
			{
				try
				{
					bool getKeyComplete = Session_ME.getKeyComplete;
					if (getKeyComplete)
					{
						while (this.sendingMessage.Count > 0)
						{
							Message m = this.sendingMessage[0];
							Session_ME.doSendMessage(m);
							this.sendingMessage.RemoveAt(0);
						}
					}
					try
					{
						Thread.Sleep(5);
					}
					catch (Exception e)
					{
						Out.printError(e);
					}
				}
				catch (Exception e2)
				{
					Debug.Log("error send message!: " + Session_ME.test);
					Out.printError(e2);
				}
			}
		}

		// Token: 0x040015A0 RID: 5536
		public List<Message> sendingMessage;
	}

	// Token: 0x020000EC RID: 236
	private class MessageCollector
	{
		// Token: 0x06000E29 RID: 3625 RVA: 0x00110CA0 File Offset: 0x0010EEA0
		public void run()
		{
			try
			{
				while (Session_ME.connected)
				{
					Message message = this.readMessage();
					bool flag = message == null;
					if (flag)
					{
						break;
					}
					try
					{
						bool flag2 = message.command == -27;
						if (flag2)
						{
							this.getKey(message);
						}
						else
						{
							Session_ME.onRecieveMsg(message);
						}
					}
					catch (Exception e)
					{
						Out.printError(e);
					}
					try
					{
						Thread.Sleep(5);
					}
					catch (Exception e2)
					{
						Out.printError(e2);
					}
				}
			}
			catch (Exception ex)
			{
				Debug.Log("error read message!");
				Debug.Log(ex.Message.ToString());
			}
			bool flag3 = !Session_ME.connected;
			if (!flag3)
			{
				bool flag4 = Session_ME.messageHandler != null;
				if (flag4)
				{
					bool flag5 = Session_ME.currentTimeMillis() - Session_ME.timeConnected > 500;
					if (flag5)
					{
						Session_ME.messageHandler.onDisconnected();
					}
					else
					{
						Session_ME.messageHandler.onConnectionFail();
					}
				}
				bool flag6 = Session_ME.sc != null;
				if (flag6)
				{
					Session_ME.cleanNetwork();
				}
			}
		}

		// Token: 0x06000E2A RID: 3626 RVA: 0x00110DD8 File Offset: 0x0010EFD8
		private void getKey(Message message)
		{
			try
			{
				sbyte b = message.reader().readSByte();
				Session_ME.key = new sbyte[(int)b];
				for (int i = 0; i < (int)b; i++)
				{
					Session_ME.key[i] = message.reader().readSByte();
				}
				for (int j = 0; j < Session_ME.key.Length - 1; j++)
				{
					ref sbyte ptr = ref Session_ME.key[j + 1];
					ptr ^= Session_ME.key[j];
				}
				Session_ME.getKeyComplete = true;
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000E2B RID: 3627 RVA: 0x00110E7C File Offset: 0x0010F07C
		private Message readMessage()
		{
			try
			{
				sbyte b = Session_ME.dis.ReadSByte();
				bool getKeyComplete = Session_ME.getKeyComplete;
				if (getKeyComplete)
				{
					b = Session_ME.readKey(b);
				}
				bool getKeyComplete2 = Session_ME.getKeyComplete;
				int num;
				if (getKeyComplete2)
				{
					bool flag = b == -39 || b == -101 || b == -93 || b == 76;
					if (flag)
					{
						sbyte b2 = Session_ME.dis.ReadSByte();
						sbyte b3 = Session_ME.dis.ReadSByte();
						sbyte b4 = Session_ME.dis.ReadSByte();
						sbyte b5 = Session_ME.dis.ReadSByte();
						num = (((int)Session_ME.readKey(b2) & 255) << 24 | ((int)Session_ME.readKey(b3) & 255) << 16 | ((int)Session_ME.readKey(b4) & 255) << 8 | ((int)Session_ME.readKey(b5) & 255));
					}
					else
					{
						sbyte b6 = Session_ME.dis.ReadSByte();
						sbyte b7 = Session_ME.dis.ReadSByte();
						num = (((int)Session_ME.readKey(b6) & 255) << 8 | ((int)Session_ME.readKey(b7) & 255));
					}
				}
				else
				{
					bool flag2 = b == -39;
					if (flag2)
					{
						num = Session_ME.dis.ReadInt32();
					}
					else
					{
						sbyte b8 = Session_ME.dis.ReadSByte();
						sbyte b9 = Session_ME.dis.ReadSByte();
						num = (((int)b8 & 65280) | ((int)b9 & 255));
					}
				}
				sbyte[] array = new sbyte[num];
				byte[] src = Session_ME.dis.ReadBytes(num);
				Buffer.BlockCopy(src, 0, array, 0, num);
				Session_ME.recvByteCount += 5 + num;
				int num2 = Session_ME.recvByteCount + Session_ME.sendByteCount;
				Session_ME.strRecvByteCount = (num2 / 1024).ToString() + "." + (num2 % 1024 / 102).ToString() + "Kb";
				bool getKeyComplete3 = Session_ME.getKeyComplete;
				if (getKeyComplete3)
				{
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = Session_ME.readKey(array[i]);
					}
				}
				return new Message(b, array);
			}
			catch (Exception ex)
			{
				Debug.Log(ex.StackTrace.ToString());
			}
			return null;
		}
	}
}
