using System;

// Token: 0x020000F5 RID: 245
public class Start_Skill
{
	// Token: 0x06000E77 RID: 3703 RVA: 0x00116780 File Offset: 0x00114980
	public Start_Skill(MainObject objMain, mVector vec, MainSkill skill)
	{
		this.objFire = objMain;
		this.vecObjBeFire = vec;
		this.skill = skill;
		Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjBeFire.elementAt(0);
		this.objBefire = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
		bool flag = skill.typeBuff == 0;
		if (flag)
		{
			bool flag2 = this.objFire == null || this.objFire.returnAction() || ((this.vecObjBeFire == null || this.vecObjBeFire.size() == 0) && skill.typeBuff != 3) || this.objBefire == null || this.objBefire.returnAction();
			if (flag2)
			{
				this.isRemove = true;
			}
			else
			{
				bool flag3 = this.objFire != GameScreen.player;
				if (flag3)
				{
					this.skill.getData();
					objMain.timeBeginUpdateMove = -1;
				}
			}
		}
	}

	// Token: 0x06000E78 RID: 3704 RVA: 0x00116868 File Offset: 0x00114A68
	public void setMoveFire()
	{
		bool flag = this.skill.typeBuff != 0;
		if (flag)
		{
			this.beginSkill();
		}
		else
		{
			bool flag2 = this.objBefire == null || this.isVeryFar;
			if (flag2)
			{
				this.isRemove = true;
			}
			else
			{
				int distance = MainObject.getDistance(this.objFire.x, this.objFire.y, this.objBefire.x, this.objBefire.y);
				int goc = CRes.angle(this.objFire.x - this.objBefire.x, this.objFire.y - this.objBefire.y);
				bool flag3 = (CRes.abs(distance) < this.skill.range && this.setGoc(goc) && this.objFire.posTransRoad == null) || this.indexMove >= 2;
				if (flag3)
				{
					this.beginSkill();
				}
				else
				{
					this.indexMove++;
					int num = 0;
					int num2 = 0;
					int num3 = 64;
					bool flag4 = num3 > this.skill.range - 8;
					if (flag4)
					{
						num3 = this.skill.range - 8;
					}
					int num4 = 90;
					int num5 = num4 / 12;
					int num6 = 0;
					int num7 = 360 + num6;
					bool flag5 = this.objFire.x < this.objBefire.x;
					if (flag5)
					{
						num7 = 180 - num6;
					}
					int num8;
					int num9;
					for (;;)
					{
						num8 = this.objBefire.x + CRes.getcos(CRes.fixangle(num7 + num2)) * num3 / 1000;
						num9 = this.objBefire.y + CRes.getsin(CRes.fixangle(num7 + num2)) * num3 / 1000;
						int tile = GameCanvas.loadmap.getTile(num8, num9);
						num2 = ((num % 2 != 0) ? (-(num % 6 + 1) * num5) : ((num % 6 + 1) * num5));
						num++;
						bool flag6 = num == 6;
						if (flag6)
						{
							num3 = 40;
							bool flag7 = num3 > this.skill.range - 8;
							if (flag7)
							{
								num3 = this.skill.range - 8;
							}
							num7 = ((num7 != 180) ? (180 - num6) : (360 + num6));
							num2 = 0;
						}
						bool flag8 = num > 12;
						if (flag8)
						{
							break;
						}
						bool flag9 = num % 2 == 0 && num3 < this.skill.range - 8 - LoadMap.wTile / 2;
						if (flag9)
						{
							num3 += LoadMap.wTile / 2;
						}
						if (tile != -1 && tile != 1)
						{
							goto IL_2FD;
						}
					}
					num8 = this.objBefire.x + CRes.getcos(CRes.fixangle(0)) * num3 / 1000;
					num9 = this.objBefire.y + CRes.getsin(CRes.fixangle(0)) * num3 / 1000;
					this.objFire.posTransRoad = null;
					IL_2FD:
					bool flag10 = this.objFire == GameScreen.player;
					if (flag10)
					{
						this.objBefire.timeBeFire = 10;
						this.movePlayer(distance, num8, num9);
					}
					else
					{
						this.objFire.toX = num8;
						this.objFire.toY = num9;
					}
				}
			}
		}
	}

	// Token: 0x06000E79 RID: 3705 RVA: 0x00116BC0 File Offset: 0x00114DC0
	public bool setGoc(int gocCur)
	{
		int num = 45;
		int num2 = 45;
		return (CRes.fixangle(gocCur) <= 180 + num && CRes.fixangle(gocCur) >= 180 - num2) || CRes.fixangle(gocCur) >= 360 - num || CRes.fixangle(gocCur) <= num2;
	}

	// Token: 0x06000E7A RID: 3706 RVA: 0x00116C24 File Offset: 0x00114E24
	public void beginSkill()
	{
		bool flag = this.objFire == null;
		if (flag)
		{
			this.isRemove = true;
		}
		else
		{
			bool flag2 = this.skill.typeBuff == 3;
			if (flag2)
			{
				this.objFire.setDataBeginSkill(this.skill, this.vecObjBeFire);
				this.isRemove = true;
			}
			else
			{
				bool flag3 = this.skill.typeBuff == 0 && LoadMap.specMap != 4 && this.objBefire != null;
				if (flag3)
				{
					int distance = MainObject.getDistance(this.objFire.x, this.objFire.y, this.objBefire.x, this.objBefire.y);
					bool flag4 = distance <= 32 || (distance <= 48 && this.objFire.clazz == 5);
					if (flag4)
					{
						bool flag5 = CRes.random(8) == 0;
						if (flag5)
						{
							bool flag6 = this.objFire.clazz == 5;
							if (flag6)
							{
								bool flag7 = this.objFire.x < this.objBefire.x;
								if (flag7)
								{
									this.objFire.x = this.objBefire.x + 48;
								}
								else
								{
									this.objFire.x = this.objBefire.x - 48;
								}
							}
							else
							{
								bool flag8 = this.objFire.x < this.objBefire.x;
								if (flag8)
								{
									this.objFire.x = this.objBefire.x + 32;
								}
								else
								{
									this.objFire.x = this.objBefire.x - 32;
								}
							}
							this.objFire.type_left_right = ((this.objFire.type_left_right == 0) ? 2 : 0);
							GameScreen.addEffectEnd_ObjTo(56, 0, this.objFire.x, this.objFire.y, this.objFire.ID, this.objFire.typeObject, (sbyte)this.objFire.type_left_right, this.objFire);
						}
						else
						{
							bool flag9 = this.objFire.clazz == 5;
							if (flag9)
							{
								bool flag10 = this.objFire.x < this.objBefire.x;
								if (flag10)
								{
									this.objFire.x = this.objBefire.x - 48;
								}
								else
								{
									this.objFire.x = this.objBefire.x + 48;
								}
							}
							else
							{
								bool flag11 = this.objFire.x < this.objBefire.x;
								if (flag11)
								{
									this.objBefire.x = this.objFire.x + 32;
								}
								else
								{
									this.objBefire.x = this.objFire.x - 32;
								}
							}
						}
					}
				}
				bool flag12 = this.objFire == GameScreen.player && LoadMap.specMap != 3;
				if (flag12)
				{
					GameScreen.player.setUseMana(this.skill.mana);
					Player.setDelaySkill((int)this.skill.indexHotKey, this.skill.timeDelay, this.skill.isBuffSpecNew, 1);
					bool flag13 = this.skill.typeBuff != 0;
					if (flag13)
					{
						bool flag14 = this.objBefire != null;
						if (flag14)
						{
							GlobalService.gI().Buff(this.skill.ID, this.objBefire.typeObject, this.vecObjBeFire);
						}
					}
					else
					{
						bool flag15 = this.objBefire != null;
						if (flag15)
						{
							GlobalService.gI().Obj_Move((short)GameScreen.player.x, (short)GameScreen.player.y);
							GlobalService.gI().Player_Fire(this.skill.ID, this.objBefire.typeObject, this.vecObjBeFire);
						}
						bool flag16 = this.skill.typeDevil == 0;
						if (flag16)
						{
							Player.indexCombo++;
							Interface_Game.indexEffCombo = Player.indexCombo;
							Interface_Game.frameCombo = 0;
						}
					}
				}
				this.objFire.setDataBeginSkill(this.skill, this.vecObjBeFire);
				this.isRemove = true;
			}
		}
	}

	// Token: 0x06000E7B RID: 3707 RVA: 0x00117070 File Offset: 0x00115270
	public void movePlayer(int distant, int toX, int toY)
	{
		GameScreen.player.xStopMove = 0;
		GameScreen.player.yStopMove = 0;
		GameScreen.player.toX = GameScreen.player.x;
		GameScreen.player.toY = GameScreen.player.y;
		GameScreen.player.countAutoMove = 0;
		bool flag = GameScreen.player.posTransRoad != null;
		if (flag)
		{
			GameScreen.player.countAutoMove = 1;
		}
		GameScreen.player.posTransRoad = GameCanvas.loadmap.updateFindRoad(toX / LoadMap.wTile, toY / LoadMap.wTile, GameScreen.player.x / LoadMap.wTile, GameScreen.player.y / LoadMap.wTile, 16, GameScreen.player);
		bool flag2 = GameScreen.player.posTransRoad != null && GameScreen.player.posTransRoad.Length > 16;
		if (flag2)
		{
			this.isVeryFar = true;
			GameScreen.player.posTransRoad = null;
		}
		else
		{
			bool flag3 = GameScreen.player.posTransRoad == null;
			if (flag3)
			{
				GameScreen.player.toX = toX;
				GameScreen.player.toY = toY;
				bool flag4 = MainObject.getDistance(GameScreen.player.x, GameScreen.player.y, GameScreen.player.toX, GameScreen.player.toY) < GameScreen.player.vMax * 2;
				if (flag4)
				{
					GameScreen.player.x = toX;
					GameScreen.player.y = toY;
					this.beginSkill();
				}
				else
				{
					GameScreen.player.isMoveNor = true;
				}
			}
			bool flag5 = toX > GameScreen.player.x;
			if (flag5)
			{
				GameScreen.player.Dir = 2;
			}
			else
			{
				GameScreen.player.Dir = 0;
			}
		}
	}

	// Token: 0x06000E7C RID: 3708 RVA: 0x0000BF78 File Offset: 0x0000A178
	public void InviMove()
	{
		this.objFire.isTanHinh = true;
		this.objFire.timeInviMove = 2;
	}

	// Token: 0x06000E7D RID: 3709 RVA: 0x00117234 File Offset: 0x00115434
	public void setMonsterMoveFire()
	{
		bool flag = this.skill.typeBuff != 0;
		if (flag)
		{
			bool flag2 = this.skill.typeBuff == 2;
			if (flag2)
			{
				bool flag3 = this.indexMove == 0;
				if (flag3)
				{
					this.indexMove = 1;
					this.objFire.toX = this.skill.x;
					this.objFire.toY = this.skill.y;
				}
				else
				{
					bool flag4 = MainObject.getDistance(this.objFire.x, this.objFire.y, this.skill.x, this.skill.y) >= 24;
					if (flag4)
					{
						GameScreen.addEffectEnd_ObjTo(56, 0, this.skill.x, this.skill.y, this.objFire.ID, this.objFire.typeObject, (sbyte)this.objFire.Dir, this.objFire);
					}
					this.beginSkill();
				}
			}
			else
			{
				this.beginSkill();
			}
		}
		else
		{
			bool flag5 = this.objBefire == null;
			if (flag5)
			{
				this.isRemove = true;
			}
			else
			{
				bool flag6 = this.indexMove == 1 || this.objFire.vecSkillFires.size() >= 1;
				if (flag6)
				{
					this.beginSkill();
					this.objFire.toX = this.objFire.x;
					this.objFire.toY = this.objFire.y;
				}
				else
				{
					int distance = MainObject.getDistance(this.objFire.x, this.objFire.y, this.objBefire.x, this.objBefire.y);
					int goc = CRes.angle(this.objFire.x - this.objBefire.x, this.objFire.y - this.objBefire.y);
					bool flag7 = CRes.abs(distance) < this.skill.range && this.setGoc(goc);
					if (flag7)
					{
						this.beginSkill();
					}
					else
					{
						this.indexMove = 1;
						int angle = 180;
						int num = this.skill.range - 5;
						bool flag8 = CRes.random(2) == 0;
						if (flag8)
						{
							angle = 0;
						}
						int toX = this.objBefire.x + CRes.getcos(CRes.fixangle(angle)) * num / 1000;
						int toY = this.objBefire.y + CRes.getsin(CRes.fixangle(angle)) * num / 1000;
						this.objFire.toX = toX;
						this.objFire.toY = toY;
					}
				}
			}
		}
	}

	// Token: 0x04001644 RID: 5700
	public MainObject objFire;

	// Token: 0x04001645 RID: 5701
	public MainObject objBefire;

	// Token: 0x04001646 RID: 5702
	public mVector vecObjBeFire;

	// Token: 0x04001647 RID: 5703
	public MainSkill skill;

	// Token: 0x04001648 RID: 5704
	public bool isRemove;

	// Token: 0x04001649 RID: 5705
	private bool isVeryFar;

	// Token: 0x0400164A RID: 5706
	private int indexMove;
}
