using System;

// Token: 0x02000083 RID: 131
public class MainPlayer : MainObject
{
	// Token: 0x0600085B RID: 2139 RVA: 0x000AA6F0 File Offset: 0x000A88F0
	public void setMove(bool isAutomove)
	{
		bool flag = this.typeActionBoat != 0;
		if (!flag)
		{
			int tile = GameCanvas.loadmap.getTile(this.x + this.vx, this.y + this.vy);
			bool flag2 = tile == 1;
			if (flag2)
			{
				if (isAutomove)
				{
					this.setAutoMoveNear();
				}
				else
				{
					bool flag3 = this.Action != 4;
					if (flag3)
					{
						this.Action = 0;
					}
					this.vx = 0;
					this.vy = 0;
				}
			}
			else
			{
				bool flag4 = LoadMap.specMap == 4;
				if (flag4)
				{
					this.setMoveSea(this);
				}
			}
			bool flag5 = this.vx != 0 || this.vy != 0;
			if (!flag5)
			{
				int tile2 = GameCanvas.loadmap.getTile(this.x, this.y);
				bool flag6 = !LoadMap.Tile_Stand(tile2);
				if (!flag6)
				{
					int num = 24;
					int num2 = this.x * 1000;
					int num3 = this.y * 1000;
					int num4 = 0;
					bool flag7;
					do
					{
						flag7 = false;
						int num5 = num2 + CRes.getcos(num4) * num;
						int num6 = num3 + CRes.getsin(num4) * num;
						bool flag8 = num5 >= 0 && num6 >= 0;
						if (flag8)
						{
							int tile3 = GameCanvas.loadmap.getTile(num5 / 1000, num6 / 1000);
							bool flag9 = tile3 == 0 || tile3 == 2;
							if (flag9)
							{
								this.x = num5 / 1000;
								this.y = num6 / 1000;
								this.resetAction();
								flag7 = true;
							}
						}
						num4 += 44;
						bool flag10 = num4 >= 360;
						if (flag10)
						{
							num4 = 0;
							num += 24;
						}
					}
					while (!flag7);
				}
			}
		}
	}

	// Token: 0x0600085C RID: 2140 RVA: 0x000AA8CC File Offset: 0x000A8ACC
	private void setMoveSea(MainObject objMain)
	{
		bool flag = objMain.boatSea == null || objMain.ID != objMain.boatSea.ID;
		if (!flag)
		{
			objMain.boatSea.boatSetVaCham(objMain.vx, objMain.vy);
			for (int i = 0; i < GameScreen.vecPlayers.size(); i++)
			{
				MainObject mainObject = (MainObject)GameScreen.vecPlayers.elementAt(i);
				bool flag2 = mainObject == objMain || mainObject.boatSea == null || mainObject.ID != mainObject.boatSea.ID || !base.setIsInScreen(mainObject.x, mainObject.y, 50, 50);
				if (!flag2)
				{
					mainObject.boatSea.boatSetVaCham(0, 0);
					bool flag3 = CRes.setVaCham(objMain.boatSea, mainObject.boatSea) && ((objMain.vx > 0 && objMain.x < mainObject.x) || (objMain.vx < 0 && objMain.x > mainObject.x) || (objMain.vy > 0 && objMain.y <= mainObject.y) || (objMain.vy < 0 && objMain.y > mainObject.y));
					if (flag3)
					{
						bool flag4 = this.Action != 4;
						if (flag4)
						{
							this.Action = 0;
						}
						this.vx = 0;
						this.vy = 0;
						break;
					}
				}
			}
		}
	}

	// Token: 0x0600085D RID: 2141 RVA: 0x000AAA50 File Offset: 0x000A8C50
	public void setAutoMoveNear()
	{
		int index = GameCanvas.loadmap.getIndex(this.x + this.vx, this.y + this.vy);
		bool flag = this.vy != 0;
		if (flag)
		{
			bool flag2 = index % GameCanvas.loadmap.mapW > 0 && (GameCanvas.loadmap.getTile(this.x + this.vx - LoadMap.wTile, this.y + this.vy) == 0 || GameCanvas.loadmap.getTile(this.x + this.vx - LoadMap.wTile, this.y + this.vy) == 2) && (GameCanvas.loadmap.getTile(this.x + this.vx - LoadMap.wTile, this.y) == 0 || GameCanvas.loadmap.getTile(this.x + this.vx - LoadMap.wTile, this.y) == 2);
			if (flag2)
			{
				this.vx = -this.vMax;
				this.Dir = 0;
				this.vy = 0;
			}
			else
			{
				bool flag3 = index % GameCanvas.loadmap.mapW < GameCanvas.loadmap.mapW - 1 && (GameCanvas.loadmap.getTile(this.x + this.vx + LoadMap.wTile, this.y + this.vy) == 0 || GameCanvas.loadmap.getTile(this.x + this.vx + LoadMap.wTile, this.y + this.vy) == 2) && (GameCanvas.loadmap.getTile(this.x + this.vx + LoadMap.wTile, this.y) == 0 || GameCanvas.loadmap.getTile(this.x + this.vx + LoadMap.wTile, this.y) == 2);
				if (flag3)
				{
					this.vx = this.vMax;
					this.Dir = 2;
					this.vy = 0;
				}
				else
				{
					this.vy = 0;
				}
			}
		}
		else
		{
			bool flag4 = this.vx != 0;
			if (flag4)
			{
				bool flag5 = (GameCanvas.loadmap.getTile(this.x + this.vx, this.y + this.vy - LoadMap.wTile) == 0 || GameCanvas.loadmap.getTile(this.x + this.vx, this.y + this.vy - LoadMap.wTile) == 2) && (GameCanvas.loadmap.getTile(this.x, this.y + this.vy - LoadMap.wTile) == 0 || GameCanvas.loadmap.getTile(this.x, this.y + this.vy - LoadMap.wTile) == 2);
				if (flag5)
				{
					this.vy = -this.vMax;
					this.Dir = 1;
					this.vx = 0;
				}
				else
				{
					bool flag6 = (GameCanvas.loadmap.getTile(this.x + this.vx, this.y + this.vy + LoadMap.wTile) == 0 || GameCanvas.loadmap.getTile(this.x + this.vx, this.y + this.vy + LoadMap.wTile) == 2) && (GameCanvas.loadmap.getTile(this.x, this.y + this.vy + LoadMap.wTile) == 0 || GameCanvas.loadmap.getTile(this.x, this.y + this.vy + LoadMap.wTile) == 2);
					if (flag6)
					{
						this.vy = this.vMax;
						this.Dir = 3;
						this.vx = 0;
					}
					else
					{
						this.vx = 0;
					}
				}
			}
		}
		bool flag7 = this.vx == 0 && this.vy == 0 && this.Action != 4;
		if (flag7)
		{
			this.Action = 0;
		}
	}

	// Token: 0x0600085E RID: 2142 RVA: 0x000AAE5C File Offset: 0x000A905C
	public override void resetAction()
	{
		this.vx = (this.vy = 0);
		this.toX = this.x;
		this.toY = this.y;
		bool flag = this.Action != 2 && this.Action != 4;
		if (flag)
		{
			this.Action = 0;
			this.weapon_frame = 0;
		}
	}

	// Token: 0x0600085F RID: 2143 RVA: 0x0000AD30 File Offset: 0x00008F30
	public override void setDataBeginSkill(MainSkill skill, mVector vec)
	{
		this.plashNow = new Plash(skill, this, vec);
		base.resetBeginFire();
		this.Action = 2;
	}

	// Token: 0x06000860 RID: 2144 RVA: 0x000AAEC0 File Offset: 0x000A90C0
	public override void addSkillFire(MainSkill skill, mVector vec)
	{
		bool flag = this.skillCurrent != null;
		if (flag)
		{
			this.skillCurrent.beginSkill();
		}
		this.vecSkillFires.addElement(new Start_Skill(this, vec, skill));
	}

	// Token: 0x06000861 RID: 2145 RVA: 0x000AAF00 File Offset: 0x000A9100
	public virtual void updateMapTrain()
	{
		bool flag = (GameCanvas.gameTick + this.tickMapTrain) % 75 == 0 && CRes.random(3) == 0 && this.Action != 2 && this.skillCurrent != null;
		if (flag)
		{
			int num = CRes.random(MainObject.mPosMapTrain.Length);
			this.toX = MainObject.mPosMapTrain[num][0];
			this.toY = MainObject.mPosMapTrain[num][1];
		}
		else
		{
			this.timeFireMapTrain++;
			bool flag2 = this.timeFireMapTrain <= 80 || this.mSkillMapTrain == null;
			if (!flag2)
			{
				this.timeFireMapTrain = 0;
				this.toX = this.x;
				this.toY = this.y;
				mVector mVector = new mVector();
				for (int i = 0; i < GameScreen.vecPlayers.size(); i++)
				{
					MainObject mainObject = (MainObject)GameScreen.vecPlayers.elementAt(i);
					bool flag3 = MainObject.getDistance(this.x, this.y, mainObject.x, mainObject.y) < Player.wFocus && mainObject.typeObject == 1;
					if (flag3)
					{
						Object_Effect_Skill object_Effect_Skill = new Object_Effect_Skill(mainObject.ID, mainObject.typeObject);
						object_Effect_Skill.setHP(mainObject.maxHp / 10, mainObject.Hp - mainObject.maxHp / 10, 0);
						mVector.addElement(object_Effect_Skill);
						MainSkill skill = new MainSkill(-1, this.mSkillMapTrain[this.indexSkillFireMapTrain]);
						this.addSkillFire(skill, mVector);
						this.indexSkillFireMapTrain++;
						bool flag4 = this.indexSkillFireMapTrain >= this.mSkillMapTrain.Length;
						if (flag4)
						{
							this.indexSkillFireMapTrain = 0;
						}
						break;
					}
				}
			}
		}
	}

	// Token: 0x06000862 RID: 2146 RVA: 0x000AB0D0 File Offset: 0x000A92D0
	public override void updateActionUpBoat()
	{
		bool flag = this.typeActionBoat == 1;
		if (flag)
		{
			this.updateActionUp();
		}
		else
		{
			bool flag2 = this.typeActionBoat == 2;
			if (flag2)
			{
				this.updateActionDown();
			}
			else
			{
				bool flag3 = this.typeActionBoat == 3;
				if (flag3)
				{
					this.updateActionUp_2();
				}
				else
				{
					bool flag4 = this.typeActionBoat == 4;
					if (flag4)
					{
						this.updateActionDown_2();
					}
				}
			}
		}
		this.maxTimeUpsea++;
	}

	// Token: 0x06000863 RID: 2147 RVA: 0x000AB14C File Offset: 0x000A934C
	public override void updateActionDown_2()
	{
		bool flag = this.stepUpboat == 0;
		if (flag)
		{
			bool flag2 = this.Action == 5;
			if (flag2)
			{
				bool flag3 = this.f < 2;
				if (flag3)
				{
					this.dy = (this.f + 1) * 5;
				}
				else
				{
					bool flag4 = this.f == 2 || this.f == 3;
					if (flag4)
					{
						this.dy = 12;
					}
					else
					{
						bool flag5 = this.dy > 3;
						if (flag5)
						{
							this.dy = 12 - (this.f - 3) * 5;
						}
					}
				}
				bool flag6 = this.f == 5;
				if (flag6)
				{
					this.dy = 0;
					this.Action = 0;
					this.vx = 0;
					this.vy = 0;
					this.stepUpboat = 1;
					base.setSpeed(7, 7);
					this.setXtoYto(this.xAnchor, this.yAnchor);
				}
			}
			else
			{
				bool flag7 = this.posTransRoad == null && MainObject.getDistance(this.x, this.y, this.xUpBoat, this.yUpBoat) <= 48;
				if (flag7)
				{
					this.vx = 0;
					this.vy = -12;
					this.f = 0;
					this.Action = 5;
					this.type_left_right = 2;
					this.Dir = 2;
					bool flag8 = this.boatSea != null;
					if (flag8)
					{
						GameScreen.addBoatVec_And_mItem(this.boatSea, true);
						this.boatSea = null;
					}
				}
			}
		}
		else
		{
			bool flag9 = this.stepUpboat == 1 && this.posTransRoad == null && MainObject.getDistance(this.x, this.y, this.xAnchor, this.yAnchor) <= 48;
			if (flag9)
			{
				this.typeActionBoat = 0;
			}
		}
	}

	// Token: 0x06000864 RID: 2148 RVA: 0x000AB310 File Offset: 0x000A9510
	public override void updateActionUp_2()
	{
		bool flag = this.stepUpboat == 0;
		if (flag)
		{
			bool flag2 = this.Action == 5;
			if (flag2)
			{
				bool flag3 = this.f < 2;
				if (flag3)
				{
					this.dy = (this.f + 1) * 5;
				}
				else
				{
					bool flag4 = this.f == 2 || this.f == 3;
					if (flag4)
					{
						this.dy = 12;
					}
					else
					{
						bool flag5 = this.dy > 3;
						if (flag5)
						{
							this.dy = 12 - (this.f - 3) * 5;
						}
					}
				}
				bool flag6 = this.f == 6;
				if (flag6)
				{
					this.x = this.xUpBoat;
					this.y = this.yUpBoat;
					this.dy = 0;
					this.Action = 0;
					this.vx = 0;
					this.vy = 0;
					this.stepUpboat = 1;
					base.setSpeed(3, 3);
					for (int i = 0; i < GameScreen.vecBoat.size(); i++)
					{
						Boat boat = (Boat)GameScreen.vecBoat.elementAt(i);
						bool flag7 = boat.ID == this.ID;
						if (flag7)
						{
							boat.isPaint = false;
							this.boatSea = boat;
							break;
						}
					}
					bool flag8 = this.boatSea == null;
					if (flag8)
					{
						this.setNextSea();
					}
				}
				this.type_left_right = 2;
				this.Dir = 2;
			}
			else
			{
				this.tickTypeActionBoat += 1;
				bool flag9 = this.posTransRoad == null && (MainObject.getDistance(this.x, this.y, this.xUpBoat, this.yUpBoat) <= 72 || this.tickTypeActionBoat > 40);
				if (flag9)
				{
					this.vx = (this.xUpBoat - this.x) / 6;
					this.vy = (this.yUpBoat - this.y) / 6;
					this.f = 0;
					this.Action = 5;
					this.type_left_right = 2;
					this.Dir = 2;
					this.tickTypeActionBoat = 0;
				}
			}
		}
		else
		{
			bool flag10 = this.stepUpboat == 1;
			if (flag10)
			{
				this.tickTypeActionBoat += 1;
				bool flag11 = this.tickTypeActionBoat == 20;
				if (flag11)
				{
					this.setXtoYto(this.x + 120, this.y);
				}
				bool flag12 = this.tickTypeActionBoat == 50;
				if (flag12)
				{
					this.setNextSea();
				}
			}
		}
	}

	// Token: 0x06000865 RID: 2149 RVA: 0x000AB590 File Offset: 0x000A9790
	public override void updateActionDown()
	{
		bool flag = this.stepUpboat == 0;
		if (flag)
		{
			bool flag2 = this.Action == 5;
			if (flag2)
			{
				bool flag3 = this.f == 5;
				if (flag3)
				{
					this.dy = 0;
					this.Action = 0;
					this.vx = 0;
					this.vy = 0;
					this.stepUpboat = 1;
					base.setSpeed(7, 7);
					this.setXtoYto(this.xAnchor, this.yAnchor);
				}
				else
				{
					bool flag4 = this.f < 2;
					if (flag4)
					{
						this.dy = (this.f + 1) * 5;
					}
					else
					{
						bool flag5 = this.f == 2 || this.f == 3;
						if (flag5)
						{
							this.dy = 12;
						}
						else
						{
							bool flag6 = this.f > 3;
							if (flag6)
							{
								this.dy = 12 - (this.f - 3) * 5;
							}
						}
					}
				}
			}
			else
			{
				bool flag7 = this.posTransRoad != null;
				if (!flag7)
				{
					this.tickTypeActionBoat += 1;
					bool flag8 = MainObject.getDistance(this.x, this.y, this.xUpBoat, this.yUpBoat) <= 72 || this.tickTypeActionBoat >= 10;
					if (flag8)
					{
						this.vx = 0;
						this.vy = 6;
						this.f = 0;
						this.Action = 5;
						this.type_left_right = 2;
						this.Dir = 2;
						bool flag9 = this.boatSea != null;
						if (flag9)
						{
							GameScreen.addBoatVec_And_mItem(this.boatSea, true);
							this.boatSea = null;
						}
					}
				}
			}
		}
		else
		{
			bool flag10 = this.stepUpboat == 1 && this.posTransRoad == null && MainObject.getDistance(this.x, this.y, this.xAnchor, this.yAnchor) <= 48;
			if (flag10)
			{
				this.typeActionBoat = 0;
			}
		}
	}

	// Token: 0x06000866 RID: 2150 RVA: 0x000AB77C File Offset: 0x000A997C
	public override void updateActionUp()
	{
		bool flag = this.stepUpboat == 0;
		if (flag)
		{
			bool flag2 = this.Action == 5;
			if (flag2)
			{
				bool flag3 = this.f < 2;
				if (flag3)
				{
					this.dy = (this.f + 1) * 5;
				}
				else
				{
					bool flag4 = this.f == 2 || this.f == 3;
					if (flag4)
					{
						this.dy = 12;
					}
					else
					{
						bool flag5 = this.f > 3;
						if (flag5)
						{
							this.dy = 12 - (this.f - 3) * 5;
						}
					}
				}
				bool flag6 = this.f == 6;
				if (flag6)
				{
					this.x = this.xUpBoat;
					this.y = this.yUpBoat;
					this.toX = this.x;
					this.toY = this.y;
					this.dy = 0;
					this.Action = 0;
					this.vx = 0;
					this.vy = 0;
					this.stepUpboat = 1;
					base.setSpeed(3, 3);
					for (int i = 0; i < GameScreen.vecBoat.size(); i++)
					{
						Boat boat = (Boat)GameScreen.vecBoat.elementAt(i);
						bool flag7 = boat.ID == this.ID;
						if (flag7)
						{
							boat.isPaint = false;
							this.boatSea = boat;
							break;
						}
					}
					bool flag8 = this.boatSea == null;
					if (flag8)
					{
						this.setNextSea();
					}
				}
				this.type_left_right = 2;
				this.Dir = 2;
			}
			else
			{
				this.tickTypeActionBoat += 1;
				bool flag9 = this.posTransRoad == null && (MainObject.getDistance(this.x, this.y, this.xUpBoat, this.yUpBoat) <= 48 || this.tickTypeActionBoat > 40);
				if (flag9)
				{
					this.vx = (this.xUpBoat - this.x) / 6;
					this.vy = (this.yUpBoat - this.y) / 6;
					this.f = 0;
					this.Action = 5;
					this.type_left_right = 2;
					this.Dir = 2;
					this.tickTypeActionBoat = 0;
				}
			}
		}
		else
		{
			bool flag10 = this.stepUpboat == 1;
			if (flag10)
			{
				this.tickTypeActionBoat += 1;
				bool flag11 = this.tickTypeActionBoat == 20;
				if (flag11)
				{
					this.setXtoYto(this.x + 120, this.y);
				}
				bool flag12 = this.tickTypeActionBoat == 50;
				if (flag12)
				{
					this.setNextSea();
				}
			}
		}
	}

	// Token: 0x06000867 RID: 2151 RVA: 0x000ABA14 File Offset: 0x000A9C14
	public override void setActionSea(sbyte type, int xSea, int ySea)
	{
		this.typeActionBoat = type;
		this.tickTypeActionBoat = 0;
		this.posTransRoad = null;
		this.stepUpboat = 0;
		this.xUpBoat = 0;
		this.yUpBoat = 0;
		this.maxTimeUpsea = 0;
		bool flag = this.typeActionBoat == 1;
		if (flag)
		{
			for (int i = 0; i < GameScreen.vecBoat.size(); i++)
			{
				Boat boat = (Boat)GameScreen.vecBoat.elementAt(i);
				bool flag2 = boat.ID == this.ID;
				if (flag2)
				{
					this.xUpBoat = boat.x - ((boat.Dir != 2) ? (-boat.wlech) : boat.wlech);
					this.yUpBoat = boat.y;
					break;
				}
			}
			bool flag3 = this.xUpBoat == 0 || this.yUpBoat == 0;
			if (flag3)
			{
				this.setNextSea();
				this.typeActionBoat = 0;
			}
			else
			{
				this.setPosUpBoat();
			}
		}
		else
		{
			bool flag4 = this.typeActionBoat == 2;
			if (flag4)
			{
				this.xUpBoat = xSea;
				this.yUpBoat = ySea;
				this.xAnchor = this.x;
				this.yAnchor = this.y;
				this.y = this.yUpBoat;
				this.x = this.xUpBoat - 80;
				this.boatSea = new Boat(this.ID, this.x, this.y, 0, (sbyte)this.type_left_right);
				this.boatSea.setPartImage(this.myBoat, this.typePirate);
				this.setPosDownBoat();
				for (int j = 0; j < GameScreen.vecBoat.size(); j++)
				{
					Boat boat2 = (Boat)GameScreen.vecBoat.elementAt(j);
					bool flag5 = boat2.ID == this.ID;
					if (flag5)
					{
						GameScreen.vecBoat.removeElement(boat2);
						break;
					}
				}
				base.setSpeed(3, 3);
				this.vySea = 4;
			}
			else
			{
				bool flag6 = this.typeActionBoat == 3;
				if (flag6)
				{
					for (int k = 0; k < GameScreen.vecBoat.size(); k++)
					{
						Boat boat3 = (Boat)GameScreen.vecBoat.elementAt(k);
						bool flag7 = boat3.ID == this.ID;
						if (flag7)
						{
							this.xUpBoat = boat3.x - ((boat3.Dir != 2) ? (-boat3.wlech) : boat3.wlech);
							this.yUpBoat = boat3.y;
							break;
						}
					}
					bool flag8 = this.xUpBoat == 0 || this.yUpBoat == 0;
					if (flag8)
					{
						this.setNextSea();
						this.typeActionBoat = 0;
					}
					else
					{
						this.setPosUpBoat();
					}
				}
				else
				{
					bool flag9 = this.typeActionBoat != 4;
					if (!flag9)
					{
						this.xUpBoat = xSea;
						this.yUpBoat = ySea;
						this.xAnchor = this.x;
						this.yAnchor = this.y;
						this.y = this.yUpBoat;
						this.x = this.xUpBoat - 80;
						this.setPosDownBoat();
						this.boatSea = new Boat(this.ID, this.x, this.y, 0, (sbyte)this.type_left_right);
						this.boatSea.setPartImage(this.myBoat, this.typePirate);
						for (int l = 0; l < GameScreen.vecBoat.size(); l++)
						{
							Boat boat4 = (Boat)GameScreen.vecBoat.elementAt(l);
							bool flag10 = boat4.ID == this.ID;
							if (flag10)
							{
								GameScreen.vecBoat.removeElement(boat4);
								break;
							}
						}
						base.setSpeed(3, 3);
						this.vySea = 4;
					}
				}
			}
		}
	}

	// Token: 0x06000868 RID: 2152 RVA: 0x000ABDF4 File Offset: 0x000A9FF4
	public void checkRemoveBoat()
	{
		bool flag = this.boatSea != null && LoadMap.specMap != 4 && this.maxTimeUpsea > 120;
		if (flag)
		{
			bool flag2 = this.typeActionBoat == 1 || this.typeActionBoat == 3;
			if (flag2)
			{
				this.setNextSea();
			}
			else
			{
				bool flag3 = this.typeActionBoat == 2 || this.typeActionBoat == 4;
				if (flag3)
				{
					base.setSpeed(7, 7);
					this.boatSea = null;
					this.maxTimeUpsea = 0;
				}
			}
			this.typeActionBoat = 0;
		}
	}

	// Token: 0x06000869 RID: 2153 RVA: 0x0000AD4F File Offset: 0x00008F4F
	public virtual void setPosDownBoat()
	{
		this.toX = this.xUpBoat;
		this.toY = this.yUpBoat;
	}

	// Token: 0x0600086A RID: 2154 RVA: 0x0000AD6A File Offset: 0x00008F6A
	public override void setNextSea()
	{
		this.isRemove = true;
	}

	// Token: 0x0600086B RID: 2155 RVA: 0x000ABE84 File Offset: 0x000AA084
	public virtual void setPosUpBoat()
	{
		bool flag = this.typeActionBoat == 1;
		if (flag)
		{
			this.toX = this.xUpBoat - 24;
			this.toY = this.yUpBoat - 12;
		}
		else
		{
			bool flag2 = this.typeActionBoat == 3;
			if (flag2)
			{
				this.toX = this.xUpBoat - 24;
				this.toY = this.yUpBoat + 12;
			}
		}
	}

	// Token: 0x0600086C RID: 2156 RVA: 0x0000AD74 File Offset: 0x00008F74
	public virtual void setXtoYto(int xto, int yto)
	{
		this.toX = xto;
		this.toY = yto;
	}

	// Token: 0x0600086D RID: 2157 RVA: 0x000ABEF0 File Offset: 0x000AA0F0
	public override iCommand getCenterCmd()
	{
		bool flag = GameCanvas.loadmap.mapLang();
		iCommand result;
		if (flag)
		{
			result = GameScreen.cmdGiaoTiep;
		}
		else
		{
			result = null;
		}
		return result;
	}

	// Token: 0x04000D1A RID: 3354
	public static short[][][] mPosTrainOther = new short[][][]
	{
		new short[][]
		{
			new short[]
			{
				4,
				11
			},
			new short[]
			{
				16,
				10
			},
			new short[]
			{
				24,
				10
			}
		},
		new short[][]
		{
			new short[]
			{
				9,
				9
			},
			new short[]
			{
				16,
				7
			},
			new short[]
			{
				23,
				8
			}
		},
		new short[][]
		{
			new short[]
			{
				11,
				9
			},
			new short[]
			{
				20,
				8
			},
			new short[]
			{
				16,
				7
			}
		},
		new short[][]
		{
			new short[]
			{
				7,
				9
			},
			new short[]
			{
				15,
				13
			},
			new short[]
			{
				24,
				10
			}
		},
		new short[][]
		{
			new short[]
			{
				11,
				11
			},
			new short[]
			{
				16,
				9
			},
			new short[]
			{
				21,
				12
			}
		},
		new short[][]
		{
			new short[]
			{
				10,
				11
			},
			new short[]
			{
				17,
				10
			},
			new short[]
			{
				23,
				12
			}
		}
	};

	// Token: 0x04000D1B RID: 3355
	public int timeStand;

	// Token: 0x04000D1C RID: 3356
	public int timeFireMapTrain;

	// Token: 0x04000D1D RID: 3357
	public int indexSkillFireMapTrain;

	// Token: 0x04000D1E RID: 3358
	public int countAutoMove;

	// Token: 0x04000D1F RID: 3359
	public int xStopMove;

	// Token: 0x04000D20 RID: 3360
	public int yStopMove;

	// Token: 0x04000D21 RID: 3361
	public mVector vecAllInfo = new mVector("MainPlayer.vecAllInfo");

	// Token: 0x04000D22 RID: 3362
	public mVector vecAllInfoParty = new mVector("MainPlayer.vecAllInfoParty");

	// Token: 0x04000D23 RID: 3363
	public int maxTimeUpsea;
}
