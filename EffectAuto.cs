using System;

// Token: 0x02000027 RID: 39
public class EffectAuto : MainItemMap
{
	// Token: 0x0600018F RID: 399 RVA: 0x0001DEF4 File Offset: 0x0001C0F4
	public EffectAuto(string keystr, string value)
	{
		this.TypeItem = 1;
		string[] array = mFont.split(value, ";");
		this.IDItem = short.Parse(array[0]);
		this.IDImage = short.Parse(array[1]);
		this.x = int.Parse(array[2]) * LoadMap.wTile;
		this.y = int.Parse(array[3]) * LoadMap.wTile;
		this.dx = int.Parse(array[4]);
		this.dy = int.Parse(array[5]);
		this.typeEffect = int.Parse(array[6]);
		this.valueEffect = int.Parse(array[7]);
		this.wOne = 70;
		this.hOne = 70;
		this.ySort = this.y;
		this.setDataEff();
	}

	// Token: 0x06000190 RID: 400 RVA: 0x000097BC File Offset: 0x000079BC
	public void setDataEff()
	{
		this.eff = this.loadTemEff(this.IDImage);
		this.timeBegin = GameCanvas.timeNow;
		this.isPaint = true;
		this.setPlaySound();
	}

	// Token: 0x06000191 RID: 401 RVA: 0x0001DFD0 File Offset: 0x0001C1D0
	public override void paint(mGraphics g)
	{
		bool flag = this.eff == null || this.eff.img == null || !this.isPaint;
		if (!flag)
		{
			int num = (int)this.eff.mRunFrame[this.f];
			int num2 = this.eff.mFrame[num].mpart.Length;
			for (int i = 0; i < num2; i++)
			{
				MainPartImage mainPartImage = (MainPartImage)this.eff.hashImage.get(string.Empty + this.eff.mFrame[num].mpart[i].idPartImage.ToString());
				bool flag2 = mainPartImage != null;
				if (flag2)
				{
					g.drawRegion(this.eff.img, (int)mainPartImage.x, (int)mainPartImage.y, (int)mainPartImage.w, (int)mainPartImage.h, 0, (float)(this.x + this.dx + (int)this.eff.mFrame[num].mpart[i].x), (float)(this.y + this.dy + (int)this.eff.mFrame[num].mpart[i].y), 0);
				}
			}
		}
	}

	// Token: 0x06000192 RID: 402 RVA: 0x0001E11C File Offset: 0x0001C31C
	public override void update()
	{
		bool flag = this.eff == null || this.eff.img == null;
		if (flag)
		{
			this.tickupdate++;
			bool flag2 = this.tickupdate > 50;
			if (flag2)
			{
				this.tickupdate = 0;
				this.eff = this.loadTemEff(this.IDImage);
			}
		}
		else
		{
			bool flag3 = this.f >= this.eff.mRunFrame.Length - 1;
			if (flag3)
			{
				switch (this.typeEffect)
				{
				case 0:
				{
					this.nCountReplay++;
					this.isPaint = false;
					bool flag4 = this.nCountReplay >= this.valueEffect;
					if (flag4)
					{
						this.nCountReplay = 0;
						this.isPaint = true;
						this.f = 0;
					}
					break;
				}
				case 1:
					this.f = 0;
					break;
				case 2:
				{
					this.isPaint = false;
					bool flag5 = GameCanvas.gameTick % 5 == 0 && (GameCanvas.timeNow - this.timeBegin) / 1000L > (long)this.valueEffect;
					if (flag5)
					{
						this.timeBegin = GameCanvas.timeNow;
						this.f = 0;
						this.isPaint = true;
					}
					break;
				}
				case 4:
				{
					bool flag6 = CRes.random(this.valueEffect) == 0;
					if (flag6)
					{
						this.f = 0;
						bool flag7 = this.indexSound >= 0 && CRes.random(this.timePlaySound) == 0 && this.isInScreen();
						if (flag7)
						{
							mSound.playSound(this.indexSound, mSound.volumeSound);
						}
					}
					break;
				}
				}
			}
			else
			{
				this.f++;
			}
			this.setBeginSound();
		}
	}

	// Token: 0x06000193 RID: 403 RVA: 0x000090B5 File Offset: 0x000072B5
	private void setBeginSound()
	{
	}

	// Token: 0x06000194 RID: 404 RVA: 0x0001E2E8 File Offset: 0x0001C4E8
	public MainEffectAuto loadTemEff(short id)
	{
		MainEffectAuto mainEffectAuto = (MainEffectAuto)MainEffectAuto.hashTemEffAuto.get(string.Empty + id.ToString());
		bool flag = mainEffectAuto == null;
		if (flag)
		{
			mainEffectAuto = this.checkLoadRMS(id);
			MainEffectAuto.hashTemEffAuto.put(id.ToString() + string.Empty, mainEffectAuto);
		}
		return mainEffectAuto;
	}

	// Token: 0x06000195 RID: 405 RVA: 0x0001E34C File Offset: 0x0001C54C
	public MainEffectAuto checkLoadRMS(short id)
	{
		sbyte[] array = null;
		MainEffectAuto result = new MainEffectAuto();
		bool flag = GameMidlet.DEVICE > 0;
		if (flag)
		{
			array = CRes.loadRMS("SUB_dataeffauto" + id.ToString());
		}
		bool flag2 = array == null;
		if (flag2)
		{
			GlobalService.gI().getDataEffAuto(id);
		}
		else
		{
			result = EffectAuto.readData(array, false);
		}
		return result;
	}

	// Token: 0x06000196 RID: 406 RVA: 0x0001E3B0 File Offset: 0x0001C5B0
	public static MainEffectAuto readData(sbyte[] dataeff, bool isSave)
	{
		MainEffectAuto mainEffectAuto = null;
		MainEffectAuto result;
		try
		{
			ByteArrayInputStream bis = new ByteArrayInputStream(dataeff);
			DataInputStream dataInputStream = new DataInputStream(bis);
			short id = dataInputStream.readShort();
			short num = dataInputStream.readShort();
			sbyte[] data = new sbyte[(int)num];
			dataInputStream.read(ref data);
			ByteArrayInputStream bis2 = new ByteArrayInputStream(data);
			DataInputStream data2 = new DataInputStream(bis2);
			sbyte[] dataImage = new sbyte[dataInputStream.available()];
			dataInputStream.read(ref dataImage);
			mainEffectAuto = new MainEffectAuto(data2, dataImage);
			MainEffectAuto.hashTemEffAuto.put(id.ToString() + string.Empty, mainEffectAuto);
			bool flag = GameMidlet.DEVICE > 0;
			if (flag)
			{
				if (isSave)
				{
					EffectAuto.saveDataEffAuto(dataeff, id);
					result = mainEffectAuto;
				}
				else
				{
					result = mainEffectAuto;
				}
			}
			else
			{
				result = mainEffectAuto;
			}
		}
		catch (Exception)
		{
			result = mainEffectAuto;
		}
		return result;
	}

	// Token: 0x06000197 RID: 407 RVA: 0x0001E488 File Offset: 0x0001C688
	public static void saveDataEffAuto(sbyte[] dataSave, short id)
	{
		try
		{
			CRes.saveRMS("SUB_dataeffauto" + id.ToString(), dataSave);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000198 RID: 408 RVA: 0x0001E4C8 File Offset: 0x0001C6C8
	public void setPlaySound()
	{
		short idimage = this.IDImage;
	}

	// Token: 0x040002AD RID: 685
	private MainEffectAuto eff;

	// Token: 0x040002AE RID: 686
	private int nCountReplay;

	// Token: 0x040002AF RID: 687
	private bool isPaint = true;

	// Token: 0x040002B0 RID: 688
	private int typeEffect;

	// Token: 0x040002B1 RID: 689
	private int valueEffect;

	// Token: 0x040002B2 RID: 690
	private new long timeBegin;

	// Token: 0x040002B3 RID: 691
	private int indexSound = -1;

	// Token: 0x040002B4 RID: 692
	private int timePlaySound = -1;

	// Token: 0x040002B5 RID: 693
	private int tickupdate;

	// Token: 0x040002B6 RID: 694
	public static long timeSoundFIRE;

	// Token: 0x040002B7 RID: 695
	public static long timeSoundWATER;

	// Token: 0x040002B8 RID: 696
	public static long timeSoundPHUNNUOC;

	// Token: 0x040002B9 RID: 697
	public static long timeSoundGIOTNUOC;
}
