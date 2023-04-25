using System;

// Token: 0x02000024 RID: 36
public class DataSkillEff
{
	// Token: 0x06000175 RID: 373 RVA: 0x00009710 File Offset: 0x00007910
	public DataSkillEff(short idEff, sbyte[] data)
	{
	}

	// Token: 0x06000176 RID: 374 RVA: 0x0001C85C File Offset: 0x0001AA5C
	public DataSkillEff(short idEff, int time)
	{
		this.idEff = idEff;
		if (time != -1)
		{
			if (time != 0)
			{
				this.typeupdate = 2;
				this.timelive = mSystem.currentTimeMillis() + (long)time;
			}
			else
			{
				this.typeupdate = 1;
			}
		}
		else
		{
			this.typeupdate = 3;
		}
		this.load();
	}

	// Token: 0x06000177 RID: 375 RVA: 0x0001C8E8 File Offset: 0x0001AAE8
	public DataSkillEff(short idEff, int time, sbyte typemove, sbyte loop)
	{
		this.idEff = idEff;
		this.typeMove = typemove;
		this.waitLoop = loop;
		if (time != -1)
		{
			if (time != 0)
			{
				this.typeupdate = 2;
				this.timelive = mSystem.currentTimeMillis() + (long)time;
			}
			else
			{
				this.typeupdate = 1;
			}
		}
		else
		{
			this.typeupdate = 3;
		}
		this.load();
	}

	// Token: 0x06000178 RID: 376 RVA: 0x0001C980 File Offset: 0x0001AB80
	public DataSkillEff(short ideff, int x, int y)
	{
		this.idEff = ideff;
		this.x = x;
		this.y = y;
		this.typeupdate = 1;
		this.load();
	}

	// Token: 0x06000179 RID: 377 RVA: 0x00009748 File Offset: 0x00007948
	public DataSkillEff(sbyte[] array)
	{
		this.loadData(array);
	}

	// Token: 0x0600017A RID: 378 RVA: 0x0001C9E8 File Offset: 0x0001ABE8
	public void loadData(sbyte[] array)
	{
		bool flag = array == null;
		if (!flag)
		{
			DataInputStream dataInputStream = null;
			try
			{
				bool flag2 = true;
				this.listFrame.removeAllElements();
				this.smallImage = null;
				dataInputStream = new DataInputStream(new ByteArrayInputStream(array));
				int num = (int)dataInputStream.readByte();
				this.smallImage = new SmallImage[num];
				for (int i = 0; i < num; i++)
				{
					this.smallImage[i] = new SmallImage(dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte());
				}
				int num2 = 0;
				int num3 = 10000;
				int num4 = (int)dataInputStream.readShort();
				for (int j = 0; j < num4; j++)
				{
					sbyte b = dataInputStream.readByte();
					mVector mVector = new mVector();
					mVector mVector2 = new mVector();
					for (int k = 0; k < (int)b; k++)
					{
						PartFrame partFrame = new PartFrame((int)dataInputStream.readShort(), (int)dataInputStream.readShort(), (int)dataInputStream.readByte());
						bool flag3 = flag2;
						if (flag3)
						{
							partFrame.flip = dataInputStream.readByte();
							partFrame.onTop = dataInputStream.readByte();
						}
						bool flag4 = partFrame.onTop == 0;
						if (flag4)
						{
							mVector.addElement(partFrame);
						}
						else
						{
							mVector2.addElement(partFrame);
						}
						bool flag5 = num2 < CRes.abs((int)partFrame.dy);
						if (flag5)
						{
							num2 = CRes.abs((int)partFrame.dy);
						}
						bool flag6 = CRes.abs((int)partFrame.dy) < num3;
						if (flag6)
						{
							num3 = CRes.abs((int)partFrame.dy);
						}
					}
					this.listFrame.addElement(new FrameEff(mVector, mVector2));
				}
				this.fw = (int)this.smallImage[0].w;
				this.min = num3;
				this.fh = (int)((short)num2);
				short num5 = (!flag2) ? dataInputStream.readShort() : ((short)dataInputStream.readUnsignedByte());
				this.sequence = new sbyte[(int)num5];
				for (int l = 0; l < (int)num5; l++)
				{
					this.sequence[l] = (sbyte)dataInputStream.readShort();
				}
				bool flag7 = flag2;
				if (flag7)
				{
					dataInputStream.readByte();
					num5 = (short)dataInputStream.readByte();
					this.frameChar[0] = new sbyte[(int)num5];
					for (int m = 0; m < (int)num5; m++)
					{
						this.frameChar[0][m] = dataInputStream.readByte();
					}
					num5 = (short)dataInputStream.readByte();
					this.frameChar[1] = new sbyte[(int)num5];
					for (int n = 0; n < (int)num5; n++)
					{
						this.frameChar[1][n] = dataInputStream.readByte();
					}
					num5 = (short)dataInputStream.readByte();
					this.frameChar[3] = new sbyte[(int)num5];
					for (int num6 = 0; num6 < (int)num5; num6++)
					{
						this.frameChar[3][num6] = dataInputStream.readByte();
					}
				}
				this.isLoadData = true;
				try
				{
					this.indexSplash[0] = (sbyte)(this.frameChar[0].Length - 7);
					this.indexSplash[1] = (sbyte)(this.frameChar[1].Length - 7);
					this.indexSplash[2] = (sbyte)(this.frameChar[3].Length - 7);
					this.indexSplash[3] = (sbyte)(this.frameChar[3].Length - 7);
				}
				catch (Exception)
				{
				}
				this.indexSplash[0] = dataInputStream.readByte();
				this.indexSplash[1] = dataInputStream.readByte();
				this.indexSplash[2] = dataInputStream.readByte();
				this.indexSplash[3] = this.indexSplash[2];
			}
			catch (Exception)
			{
			}
			finally
			{
				try
				{
					dataInputStream.close();
				}
				catch (Exception)
				{
				}
			}
		}
	}

	// Token: 0x0600017B RID: 379 RVA: 0x0001CE14 File Offset: 0x0001B014
	public void load()
	{
		EffectData effectData = (EffectData)DataSkillEff.ALL_EFF_DATA.get(this.idEff.ToString() + string.Empty);
		bool flag = effectData == null;
		if (flag)
		{
			effectData = new EffectData();
			DataSkillEff.ALL_EFF_DATA.put(this.idEff.ToString() + string.Empty, effectData);
			GlobalService.gI().getDataSkillEFf(0, this.idEff);
		}
		bool flag2 = effectData != null && effectData.data != null;
		if (flag2)
		{
			effectData.count = GameCanvas.timeNow / 1000L;
			this.loadData(effectData.data);
			this.isLoadData = true;
		}
	}

	// Token: 0x0600017C RID: 380 RVA: 0x0001CEC8 File Offset: 0x0001B0C8
	public bool isHavedata()
	{
		bool flag = this.isLoadData;
		bool result;
		if (flag)
		{
			result = true;
		}
		else
		{
			this.load();
			result = false;
		}
		return result;
	}

	// Token: 0x0600017D RID: 381 RVA: 0x0001CEF4 File Offset: 0x0001B0F4
	public void paintTopEff(mGraphics g, int x, int y, int hOne)
	{
		bool flag = !this.isHavedata() || (this.typeupdate == 3 && this.Frame == -1) || (int)this.Frame >= this.listFrame.size();
		if (!flag)
		{
			FrameEff frameEff = (FrameEff)this.listFrame.elementAt((int)this.Frame);
			try
			{
				mVector listPartTop = frameEff.listPartTop;
				for (int i = 0; i < listPartTop.size(); i++)
				{
					PartFrame partFrame = (PartFrame)listPartTop.elementAt(i);
					SmallImage smallImage = this.smallImage[(int)partFrame.idSmallImg];
					mImage image = this.getImage();
					bool flag2 = image != null && image.image != null;
					if (flag2)
					{
						int dx = (int)partFrame.dx;
						int num = (int)smallImage.w;
						int num2 = (int)smallImage.h;
						int num3 = (int)smallImage.x;
						int num4 = (int)smallImage.y;
						bool flag3 = num3 > mImage.getImageWidth(image.image);
						if (flag3)
						{
							num3 = 0;
						}
						bool flag4 = num4 > mImage.getImageHeight(image.image);
						if (flag4)
						{
							num4 = 0;
						}
						bool flag5 = num3 + num > mImage.getImageWidth(image.image);
						if (flag5)
						{
							num = mImage.getImageWidth(image.image) - num3;
						}
						bool flag6 = num4 + num2 > mImage.getImageHeight(image.image);
						if (flag6)
						{
							num2 = mImage.getImageHeight(image.image) - num4;
						}
						int num5 = 0;
						bool flag7 = hOne == 62 && this.min >= 50;
						if (flag7)
						{
							num5 = -8;
						}
						g.drawRegion(image, num3, num4, num, num2, (partFrame.flip == 1) ? 2 : 0, (float)(x + dx), (float)(y + (int)partFrame.dy + num5), 0);
					}
				}
			}
			catch (Exception)
			{
				mSystem.println(" loi tai e  " + this.idEff.ToString());
			}
		}
	}

	// Token: 0x0600017E RID: 382 RVA: 0x0001D110 File Offset: 0x0001B310
	public void paintTopEff(mGraphics g)
	{
		bool flag = !this.isHavedata() || (this.typeupdate == 3 && this.Frame == -1) || (int)this.Frame >= this.listFrame.size();
		if (!flag)
		{
			FrameEff frameEff = (FrameEff)this.listFrame.elementAt((int)this.Frame);
			try
			{
				mVector listPartTop = frameEff.listPartTop;
				for (int i = 0; i < listPartTop.size(); i++)
				{
					PartFrame partFrame = (PartFrame)listPartTop.elementAt(i);
					SmallImage smallImage = this.smallImage[(int)partFrame.idSmallImg];
					mImage image = this.getImage();
					bool flag2 = image != null && image.image != null;
					if (flag2)
					{
						int dx = (int)partFrame.dx;
						int num = (int)smallImage.w;
						int num2 = (int)smallImage.h;
						int num3 = (int)smallImage.x;
						int num4 = (int)smallImage.y;
						bool flag3 = num3 > mImage.getImageWidth(image.image);
						if (flag3)
						{
							num3 = 0;
						}
						bool flag4 = num4 > mImage.getImageHeight(image.image);
						if (flag4)
						{
							num4 = 0;
						}
						bool flag5 = num3 + num > mImage.getImageWidth(image.image);
						if (flag5)
						{
							num = mImage.getImageWidth(image.image) - num3;
						}
						bool flag6 = num4 + num2 > mImage.getImageHeight(image.image);
						if (flag6)
						{
							num2 = mImage.getImageHeight(image.image) - num4;
						}
						g.drawRegion(image, num3, num4, num, num2, (partFrame.flip == 1) ? 2 : 0, (float)(this.x + dx), (float)(this.y + (int)partFrame.dy), 0);
					}
				}
			}
			catch (Exception)
			{
				mSystem.println(" loi tai e  " + this.idEff.ToString());
			}
		}
	}

	// Token: 0x0600017F RID: 383 RVA: 0x0001D310 File Offset: 0x0001B510
	public void paint(mGraphics g)
	{
		bool flag = !this.isHavedata() || (int)this.Frame >= this.listFrame.size();
		if (!flag)
		{
			FrameEff frameEff = (FrameEff)this.listFrame.elementAt((int)this.Frame);
			try
			{
				mVector listPartPaint = frameEff.getListPartPaint();
				for (int i = 0; i < listPartPaint.size(); i++)
				{
					PartFrame partFrame = (PartFrame)listPartPaint.elementAt(i);
					SmallImage smallImage = this.smallImage[(int)partFrame.idSmallImg];
					mImage image = this.getImage();
					bool flag2 = image != null && image.image != null;
					if (flag2)
					{
						int dx = (int)partFrame.dx;
						int num = (int)smallImage.w;
						int num2 = (int)smallImage.h;
						int num3 = (int)smallImage.x;
						int num4 = (int)smallImage.y;
						bool flag3 = num3 > mImage.getImageWidth(image.image);
						if (flag3)
						{
							num3 = 0;
						}
						bool flag4 = num4 > mImage.getImageHeight(image.image);
						if (flag4)
						{
							num4 = 0;
						}
						bool flag5 = num3 + num > mImage.getImageWidth(image.image);
						if (flag5)
						{
							num = mImage.getImageWidth(image.image) - num3;
						}
						bool flag6 = num4 + num2 > mImage.getImageHeight(image.image);
						if (flag6)
						{
							num2 = mImage.getImageHeight(image.image) - num4;
						}
						g.drawRegion(image, num3, num4, num, num2, (partFrame.flip == 1) ? 2 : 0, (float)(this.x + dx), (float)(this.y + (int)partFrame.dy), 0);
					}
				}
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x06000180 RID: 384 RVA: 0x0001D4E4 File Offset: 0x0001B6E4
	public void paintBottomEff(mGraphics g, int x, int y, int hOne)
	{
		bool flag = !this.isHavedata() || (this.typeupdate == 3 && this.Frame == -1) || (int)this.Frame >= this.listFrame.size();
		if (!flag)
		{
			FrameEff frameEff = (FrameEff)this.listFrame.elementAt((int)this.Frame);
			try
			{
				mVector listPartBottom = frameEff.listPartBottom;
				for (int i = 0; i < listPartBottom.size(); i++)
				{
					PartFrame partFrame = (PartFrame)listPartBottom.elementAt(i);
					SmallImage smallImage = this.smallImage[(int)partFrame.idSmallImg];
					mImage image = this.getImage();
					bool flag2 = image != null && image.image != null;
					if (flag2)
					{
						int dx = (int)partFrame.dx;
						int num = (int)smallImage.w;
						int num2 = (int)smallImage.h;
						int num3 = (int)smallImage.x;
						int num4 = (int)smallImage.y;
						bool flag3 = num3 > mImage.getImageWidth(image.image);
						if (flag3)
						{
							num3 = 0;
						}
						bool flag4 = num4 > mImage.getImageHeight(image.image);
						if (flag4)
						{
							num4 = 0;
						}
						bool flag5 = num3 + num > mImage.getImageWidth(image.image);
						if (flag5)
						{
							num = mImage.getImageWidth(image.image) - num3;
						}
						bool flag6 = num4 + num2 > mImage.getImageHeight(image.image);
						if (flag6)
						{
							num2 = mImage.getImageHeight(image.image) - num4;
						}
						int num5 = 0;
						bool flag7 = hOne == 62 && this.min >= 50;
						if (flag7)
						{
							num5 = -8;
						}
						g.drawRegion(image, num3, num4, num, num2, (partFrame.flip == 1) ? 2 : 0, (float)(x + dx), (float)(y + (int)partFrame.dy + num5), 0);
					}
				}
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x06000181 RID: 385 RVA: 0x0001D6E8 File Offset: 0x0001B8E8
	public void paintBottomEff(mGraphics g)
	{
		bool flag = !this.isHavedata() || (this.typeupdate == 3 && this.Frame == -1) || (int)this.Frame >= this.listFrame.size();
		if (!flag)
		{
			FrameEff frameEff = (FrameEff)this.listFrame.elementAt((int)this.Frame);
			try
			{
				mVector listPartBottom = frameEff.listPartBottom;
				for (int i = 0; i < listPartBottom.size(); i++)
				{
					PartFrame partFrame = (PartFrame)listPartBottom.elementAt(i);
					SmallImage smallImage = this.smallImage[(int)partFrame.idSmallImg];
					mImage image = this.getImage();
					bool flag2 = image != null && image.image != null;
					if (flag2)
					{
						int dx = (int)partFrame.dx;
						int num = (int)smallImage.w;
						int num2 = (int)smallImage.h;
						int num3 = (int)smallImage.x;
						int num4 = (int)smallImage.y;
						bool flag3 = num3 > mImage.getImageWidth(image.image);
						if (flag3)
						{
							num3 = 0;
						}
						bool flag4 = num4 > mImage.getImageHeight(image.image);
						if (flag4)
						{
							num4 = 0;
						}
						bool flag5 = num3 + num > mImage.getImageWidth(image.image);
						if (flag5)
						{
							num = mImage.getImageWidth(image.image) - num3;
						}
						bool flag6 = num4 + num2 > mImage.getImageHeight(image.image);
						if (flag6)
						{
							num2 = mImage.getImageHeight(image.image) - num4;
						}
						g.drawRegion(image, num3, num4, num, num2, (partFrame.flip == 1) ? 2 : 0, (float)(this.x + dx), (float)(this.y + (int)partFrame.dy), 0);
					}
				}
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x06000182 RID: 386 RVA: 0x00009788 File Offset: 0x00007988
	public void setFrame(int fr)
	{
		this.Frame = (sbyte)fr;
	}

	// Token: 0x06000183 RID: 387 RVA: 0x0001D8CC File Offset: 0x0001BACC
	public mImage getImage()
	{
		EffectData effectData = (EffectData)DataSkillEff.ALL_EFF_DATA.get(this.idEff.ToString() + string.Empty);
		effectData.count = GameCanvas.timeNow / 1000L;
		return effectData.img;
	}

	// Token: 0x06000184 RID: 388 RVA: 0x0001D920 File Offset: 0x0001BB20
	public static EffectData readData(sbyte[] dataeff, bool isSave)
	{
		EffectData effectData = null;
		EffectData result;
		try
		{
			ByteArrayInputStream bis = new ByteArrayInputStream(dataeff);
			DataInputStream dataInputStream = new DataInputStream(bis);
			short id = dataInputStream.readShort();
			short num = dataInputStream.readShort();
			sbyte[] data = new sbyte[(int)num];
			dataInputStream.read(ref data);
			sbyte[] dataImg = new sbyte[dataInputStream.available()];
			dataInputStream.read(ref dataImg);
			effectData = (EffectData)DataSkillEff.ALL_EFF_DATA.get(id.ToString() + string.Empty);
			bool flag = effectData != null;
			if (flag)
			{
				effectData.setData(data, dataImg);
				effectData.count = GameCanvas.timeNow / 1000L;
			}
			DataSkillEff.saveDataSkillEff(dataeff, id);
			result = effectData;
		}
		catch (Exception)
		{
			result = effectData;
		}
		return result;
	}

	// Token: 0x06000185 RID: 389 RVA: 0x0001D9E8 File Offset: 0x0001BBE8
	public static void saveDataSkillEff(sbyte[] dataSave, short id)
	{
		try
		{
			CRes.saveRMS("DataSkillEff" + id.ToString(), dataSave);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000186 RID: 390 RVA: 0x00009793 File Offset: 0x00007993
	public void setLoop(int loop)
	{
		this.loop = loop;
	}

	// Token: 0x06000187 RID: 391 RVA: 0x0001DA28 File Offset: 0x0001BC28
	public void update()
	{
		bool flag = !this.isHavedata() || this.listFrame.size() <= 0;
		if (!flag)
		{
			try
			{
				switch (this.typeupdate)
				{
				case 0:
				{
					this.f += 1;
					bool flag2 = (int)this.f > this.sequence.Length;
					if (flag2)
					{
						bool flag3 = !this.canremove;
						if (flag3)
						{
							this.wantDestroy = true;
						}
						this.f = 0;
					}
					this.Frame = this.sequence[(int)this.f];
					break;
				}
				case 1:
				{
					this.f += 1;
					bool flag4 = (int)this.f > this.sequence.Length;
					if (flag4)
					{
						this.f = 0;
						this.wantDestroy = true;
					}
					this.Frame = this.sequence[(int)this.f];
					break;
				}
				case 2:
				{
					this.f += 1;
					bool flag5 = (int)this.f > this.sequence.Length;
					if (flag5)
					{
						this.f = 0;
					}
					bool flag6 = this.timelive - mSystem.currentTimeMillis() < 0L;
					if (flag6)
					{
						this.wantDestroy = true;
					}
					this.Frame = this.sequence[(int)this.f];
					break;
				}
				case 3:
				{
					this.f += 1;
					bool flag7 = (int)this.f > this.sequence.Length;
					if (flag7)
					{
						bool flag8 = this.waitLoop > 0;
						if (flag8)
						{
							bool flag9 = mSystem.currentTimeMillis() - this.lasttime > (long)((int)this.waitLoop * 1000);
							if (flag9)
							{
								this.lasttime = mSystem.currentTimeMillis();
								this.f = 0;
							}
						}
						else
						{
							this.f = 0;
						}
					}
					bool flag10 = (int)this.f < this.sequence.Length;
					if (flag10)
					{
						this.Frame = this.sequence[(int)this.f];
					}
					else
					{
						this.Frame = -1;
					}
					break;
				}
				}
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x04000287 RID: 647
	public const sbyte NORMAL = 0;

	// Token: 0x04000288 RID: 648
	public const sbyte REMOVE_BY_FRAME = 1;

	// Token: 0x04000289 RID: 649
	public const sbyte REMOVE_BY_TIME = 2;

	// Token: 0x0400028A RID: 650
	public const sbyte NO_REMOVE = 3;

	// Token: 0x0400028B RID: 651
	public const sbyte CHOANG = 1;

	// Token: 0x0400028C RID: 652
	public const sbyte BIENHINH = 2;

	// Token: 0x0400028D RID: 653
	public sbyte Frame;

	// Token: 0x0400028E RID: 654
	public sbyte f;

	// Token: 0x0400028F RID: 655
	public long timeremove;

	// Token: 0x04000290 RID: 656
	public long timeGetBack;

	// Token: 0x04000291 RID: 657
	public mVector listFrame = new mVector();

	// Token: 0x04000292 RID: 658
	public mVector listAnima = new mVector();

	// Token: 0x04000293 RID: 659
	public SmallImage[] smallImage;

	// Token: 0x04000294 RID: 660
	public sbyte[][] frameChar = new sbyte[4][];

	// Token: 0x04000295 RID: 661
	public sbyte[] sequence;

	// Token: 0x04000296 RID: 662
	public int fw;

	// Token: 0x04000297 RID: 663
	public int fh;

	// Token: 0x04000298 RID: 664
	public sbyte[] indexSplash = new sbyte[4];

	// Token: 0x04000299 RID: 665
	private int loop;

	// Token: 0x0400029A RID: 666
	public sbyte waitLoop;

	// Token: 0x0400029B RID: 667
	public bool isLoadData;

	// Token: 0x0400029C RID: 668
	public short idEff;

	// Token: 0x0400029D RID: 669
	public bool canremove;

	// Token: 0x0400029E RID: 670
	public static MyHashTable ALL_EFF_DATA = new MyHashTable();

	// Token: 0x0400029F RID: 671
	public static MyHashTable ALL_IMAGE_EFF_DATA = new MyHashTable();

	// Token: 0x040002A0 RID: 672
	public sbyte typeupdate;

	// Token: 0x040002A1 RID: 673
	public int x;

	// Token: 0x040002A2 RID: 674
	public int y;

	// Token: 0x040002A3 RID: 675
	public sbyte typeMove;

	// Token: 0x040002A4 RID: 676
	public bool isbuff;

	// Token: 0x040002A5 RID: 677
	private int min;

	// Token: 0x040002A6 RID: 678
	public bool wantDestroy;

	// Token: 0x040002A7 RID: 679
	private long lasttime;

	// Token: 0x040002A8 RID: 680
	private long timelive;
}
