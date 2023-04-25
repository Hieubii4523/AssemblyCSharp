using System;

// Token: 0x0200002C RID: 44
public class Effect_Skill : MainEffect
{
	// Token: 0x060001FF RID: 511 RVA: 0x00032D30 File Offset: 0x00030F30
	public Effect_Skill(MainSkill skill, MainObject objEffFire, int x, int y, mVector vec)
	{
		int[][][] array = new int[4][][];
		array[0] = new int[][]
		{
			new int[]
			{
				4,
				-26,
				-23
			},
			new int[]
			{
				1,
				-10,
				20
			}
		};
		array[1] = new int[][]
		{
			new int[]
			{
				3,
				-15,
				-43
			},
			new int[]
			{
				1,
				5,
				-26
			},
			new int[]
			{
				3,
				-28,
				-4
			},
			new int[]
			{
				4,
				-28,
				10
			}
		};
		array[2] = new int[][]
		{
			new int[]
			{
				0,
				-27,
				-90
			},
			new int[]
			{
				3,
				-27,
				-76
			},
			new int[]
			{
				4,
				-22,
				-58
			},
			new int[]
			{
				2,
				-10,
				-30
			},
			new int[]
			{
				1,
				0,
				-14
			}
		};
		int num = 3;
		int[][] array2 = new int[4][];
		array2[0] = new int[]
		{
			3,
			-44,
			-70
		};
		array2[1] = new int[]
		{
			0,
			-44,
			-45
		};
		array2[2] = new int[]
		{
			4,
			-36,
			-21
		};
		int num2 = 3;
		int[] array3 = new int[3];
		array3[0] = 3;
		array3[1] = -24;
		array2[num2] = array3;
		array[num] = array2;
		this.skillZoro3 = array;
		this.Mr1 = new int[][]
		{
			new int[]
			{
				3,
				-15,
				-35
			},
			new int[]
			{
				4,
				-25,
				-32
			},
			new int[]
			{
				5,
				-25,
				-27
			},
			new int[]
			{
				0,
				-30,
				-20
			},
			new int[]
			{
				1,
				-30,
				-20
			},
			new int[]
			{
				2,
				-30,
				-20
			}
		};
		this.VecEff = new mVector();
		this.VecSubEff = new mVector();
		this.vecPos = new mVector();
		this.vectargetPos = new mVector();
		this.posSmock = new short[]
		{
			0,
			50,
			75,
			100,
			20,
			110,
			30
		};
		this.radian = new int[]
		{
			0,
			30,
			60,
			90,
			120,
			150,
			180,
			210,
			240,
			270,
			300,
			330
		};
		this.CR = 15;
		base..ctor();
		this.indexObjBefire = 0;
		this.valueEffect = 0;
		bool isNextMap = LoadMapScreen.isNextMap;
		if (isNextMap)
		{
			this.x = x;
			this.y = y;
			this.vecPos = vec;
			this.Dir = skill.Dirbuff;
			bool flag = this.vecPos != null && this.vecPos.size() > 0;
			if (flag)
			{
				Point_Focus point_Focus = (Point_Focus)this.vecPos.elementAt(0);
				this.toX = point_Focus.x;
				this.toY = point_Focus.y;
			}
			else
			{
				this.toX = x;
				this.toY = y;
			}
			this.timeAddNum = -1;
			this.objBeFireMain = objEffFire;
			this.isStop = false;
			this.isRemove = false;
			this.f = -1;
			this.ysai = 0;
			this.typeEffect = (int)skill.typeEffSkill;
			this.subType = (int)skill.typeEffBuff;
			this.timeBegin = skill.timeBegin;
			this.timeEnd = skill.timebuff;
			this.objFireMain = objEffFire;
			this.isEff = true;
			this.numNextFrame = 1;
		}
	}

	// Token: 0x06000200 RID: 512 RVA: 0x0003308C File Offset: 0x0003128C
	public Effect_Skill(MainSkill skill, MainObject objEffFire)
	{
		int[][][] array = new int[4][][];
		array[0] = new int[][]
		{
			new int[]
			{
				4,
				-26,
				-23
			},
			new int[]
			{
				1,
				-10,
				20
			}
		};
		array[1] = new int[][]
		{
			new int[]
			{
				3,
				-15,
				-43
			},
			new int[]
			{
				1,
				5,
				-26
			},
			new int[]
			{
				3,
				-28,
				-4
			},
			new int[]
			{
				4,
				-28,
				10
			}
		};
		array[2] = new int[][]
		{
			new int[]
			{
				0,
				-27,
				-90
			},
			new int[]
			{
				3,
				-27,
				-76
			},
			new int[]
			{
				4,
				-22,
				-58
			},
			new int[]
			{
				2,
				-10,
				-30
			},
			new int[]
			{
				1,
				0,
				-14
			}
		};
		int num = 3;
		int[][] array2 = new int[4][];
		array2[0] = new int[]
		{
			3,
			-44,
			-70
		};
		array2[1] = new int[]
		{
			0,
			-44,
			-45
		};
		array2[2] = new int[]
		{
			4,
			-36,
			-21
		};
		int num2 = 3;
		int[] array3 = new int[3];
		array3[0] = 3;
		array3[1] = -24;
		array2[num2] = array3;
		array[num] = array2;
		this.skillZoro3 = array;
		this.Mr1 = new int[][]
		{
			new int[]
			{
				3,
				-15,
				-35
			},
			new int[]
			{
				4,
				-25,
				-32
			},
			new int[]
			{
				5,
				-25,
				-27
			},
			new int[]
			{
				0,
				-30,
				-20
			},
			new int[]
			{
				1,
				-30,
				-20
			},
			new int[]
			{
				2,
				-30,
				-20
			}
		};
		this.VecEff = new mVector();
		this.VecSubEff = new mVector();
		this.vecPos = new mVector();
		this.vectargetPos = new mVector();
		this.posSmock = new short[]
		{
			0,
			50,
			75,
			100,
			20,
			110,
			30
		};
		this.radian = new int[]
		{
			0,
			30,
			60,
			90,
			120,
			150,
			180,
			210,
			240,
			270,
			300,
			330
		};
		this.CR = 15;
		base..ctor();
		this.indexObjBefire = 0;
		this.valueEffect = 0;
		bool isNextMap = LoadMapScreen.isNextMap;
		if (isNextMap)
		{
			this.timeAddNum = -1;
			this.objBeFireMain = objEffFire;
			this.isStop = false;
			this.isRemove = false;
			this.f = -1;
			this.ysai = 0;
			this.typeEffect = (int)skill.typeEffSkill;
			this.subType = (int)skill.typeEffBuff;
			this.timeBegin = skill.timeBegin;
			this.objFireMain = objEffFire;
			this.isEff = true;
			this.numNextFrame = 1;
		}
	}

	// Token: 0x06000201 RID: 513 RVA: 0x0003335C File Offset: 0x0003155C
	public Effect_Skill()
	{
		int[][][] array = new int[4][][];
		array[0] = new int[][]
		{
			new int[]
			{
				4,
				-26,
				-23
			},
			new int[]
			{
				1,
				-10,
				20
			}
		};
		array[1] = new int[][]
		{
			new int[]
			{
				3,
				-15,
				-43
			},
			new int[]
			{
				1,
				5,
				-26
			},
			new int[]
			{
				3,
				-28,
				-4
			},
			new int[]
			{
				4,
				-28,
				10
			}
		};
		array[2] = new int[][]
		{
			new int[]
			{
				0,
				-27,
				-90
			},
			new int[]
			{
				3,
				-27,
				-76
			},
			new int[]
			{
				4,
				-22,
				-58
			},
			new int[]
			{
				2,
				-10,
				-30
			},
			new int[]
			{
				1,
				0,
				-14
			}
		};
		int num = 3;
		int[][] array2 = new int[4][];
		array2[0] = new int[]
		{
			3,
			-44,
			-70
		};
		array2[1] = new int[]
		{
			0,
			-44,
			-45
		};
		array2[2] = new int[]
		{
			4,
			-36,
			-21
		};
		int num2 = 3;
		int[] array3 = new int[3];
		array3[0] = 3;
		array3[1] = -24;
		array2[num2] = array3;
		array[num] = array2;
		this.skillZoro3 = array;
		this.Mr1 = new int[][]
		{
			new int[]
			{
				3,
				-15,
				-35
			},
			new int[]
			{
				4,
				-25,
				-32
			},
			new int[]
			{
				5,
				-25,
				-27
			},
			new int[]
			{
				0,
				-30,
				-20
			},
			new int[]
			{
				1,
				-30,
				-20
			},
			new int[]
			{
				2,
				-30,
				-20
			}
		};
		this.VecEff = new mVector();
		this.VecSubEff = new mVector();
		this.vecPos = new mVector();
		this.vectargetPos = new mVector();
		this.posSmock = new short[]
		{
			0,
			50,
			75,
			100,
			20,
			110,
			30
		};
		this.radian = new int[]
		{
			0,
			30,
			60,
			90,
			120,
			150,
			180,
			210,
			240,
			270,
			300,
			330
		};
		this.CR = 15;
		base..ctor();
	}

	// Token: 0x06000202 RID: 514 RVA: 0x000335B0 File Offset: 0x000317B0
	public Effect_Skill(int typeKill, int subtype, MainObject objEffFire, mVector vec)
	{
		int[][][] array = new int[4][][];
		array[0] = new int[][]
		{
			new int[]
			{
				4,
				-26,
				-23
			},
			new int[]
			{
				1,
				-10,
				20
			}
		};
		array[1] = new int[][]
		{
			new int[]
			{
				3,
				-15,
				-43
			},
			new int[]
			{
				1,
				5,
				-26
			},
			new int[]
			{
				3,
				-28,
				-4
			},
			new int[]
			{
				4,
				-28,
				10
			}
		};
		array[2] = new int[][]
		{
			new int[]
			{
				0,
				-27,
				-90
			},
			new int[]
			{
				3,
				-27,
				-76
			},
			new int[]
			{
				4,
				-22,
				-58
			},
			new int[]
			{
				2,
				-10,
				-30
			},
			new int[]
			{
				1,
				0,
				-14
			}
		};
		int num = 3;
		int[][] array2 = new int[4][];
		array2[0] = new int[]
		{
			3,
			-44,
			-70
		};
		array2[1] = new int[]
		{
			0,
			-44,
			-45
		};
		array2[2] = new int[]
		{
			4,
			-36,
			-21
		};
		int num2 = 3;
		int[] array3 = new int[3];
		array3[0] = 3;
		array3[1] = -24;
		array2[num2] = array3;
		array[num] = array2;
		this.skillZoro3 = array;
		this.Mr1 = new int[][]
		{
			new int[]
			{
				3,
				-15,
				-35
			},
			new int[]
			{
				4,
				-25,
				-32
			},
			new int[]
			{
				5,
				-25,
				-27
			},
			new int[]
			{
				0,
				-30,
				-20
			},
			new int[]
			{
				1,
				-30,
				-20
			},
			new int[]
			{
				2,
				-30,
				-20
			}
		};
		this.VecEff = new mVector();
		this.VecSubEff = new mVector();
		this.vecPos = new mVector();
		this.vectargetPos = new mVector();
		this.posSmock = new short[]
		{
			0,
			50,
			75,
			100,
			20,
			110,
			30
		};
		this.radian = new int[]
		{
			0,
			30,
			60,
			90,
			120,
			150,
			180,
			210,
			240,
			270,
			300,
			330
		};
		this.CR = 15;
		base..ctor();
		this.indexObjBefire = 0;
		this.valueEffect = 0;
		bool flag = !LoadMapScreen.isNextMap;
		if (!flag)
		{
			this.timeAddNum = -1;
			this.objBeFireMain = null;
			this.subType = subtype;
			this.isStop = false;
			this.isRemove = false;
			bool flag2 = vec == null || vec.size() == 0;
			if (!flag2)
			{
				this.vecObjsBeFire = vec;
				this.f = -1;
				this.ysai = 0;
				this.typeEffect = typeKill;
				this.timeBegin = GameCanvas.timeNow;
				this.objFireMain = objEffFire;
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(0);
				bool flag3 = object_Effect_Skill != null;
				if (flag3)
				{
					this.objBeFireMain = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
				}
				bool flag4 = this.objBeFireMain != null && this.objFireMain != null;
				if (flag4)
				{
					this.isEff = false;
					bool flag5 = this.objFireMain == GameScreen.player && LoadMap.specMap != 3;
					if (flag5)
					{
						this.isEff = true;
					}
					this.numNextFrame = 1;
					this.x = this.objFireMain.x;
					this.y = this.objFireMain.y - this.objFireMain.hOne / 2;
					this.toX = this.objBeFireMain.x;
					this.toY = this.objBeFireMain.y - this.objBeFireMain.hOne / 2;
					bool flag6 = this.objFireMain != this.objBeFireMain;
					if (flag6)
					{
						base.setAngle();
						this.objFireMain.type_left_right = (int)this.Dir;
						this.objFireMain.Dir = (int)this.Dir;
					}
				}
			}
		}
	}

	// Token: 0x06000203 RID: 515 RVA: 0x000339BC File Offset: 0x00031BBC
	public Effect_Skill(int typeKill, int subtype, MainObject objEffFire, mVector vec, int x, int y)
	{
		int[][][] array = new int[4][][];
		array[0] = new int[][]
		{
			new int[]
			{
				4,
				-26,
				-23
			},
			new int[]
			{
				1,
				-10,
				20
			}
		};
		array[1] = new int[][]
		{
			new int[]
			{
				3,
				-15,
				-43
			},
			new int[]
			{
				1,
				5,
				-26
			},
			new int[]
			{
				3,
				-28,
				-4
			},
			new int[]
			{
				4,
				-28,
				10
			}
		};
		array[2] = new int[][]
		{
			new int[]
			{
				0,
				-27,
				-90
			},
			new int[]
			{
				3,
				-27,
				-76
			},
			new int[]
			{
				4,
				-22,
				-58
			},
			new int[]
			{
				2,
				-10,
				-30
			},
			new int[]
			{
				1,
				0,
				-14
			}
		};
		int num = 3;
		int[][] array2 = new int[4][];
		array2[0] = new int[]
		{
			3,
			-44,
			-70
		};
		array2[1] = new int[]
		{
			0,
			-44,
			-45
		};
		array2[2] = new int[]
		{
			4,
			-36,
			-21
		};
		int num2 = 3;
		int[] array3 = new int[3];
		array3[0] = 3;
		array3[1] = -24;
		array2[num2] = array3;
		array[num] = array2;
		this.skillZoro3 = array;
		this.Mr1 = new int[][]
		{
			new int[]
			{
				3,
				-15,
				-35
			},
			new int[]
			{
				4,
				-25,
				-32
			},
			new int[]
			{
				5,
				-25,
				-27
			},
			new int[]
			{
				0,
				-30,
				-20
			},
			new int[]
			{
				1,
				-30,
				-20
			},
			new int[]
			{
				2,
				-30,
				-20
			}
		};
		this.VecEff = new mVector();
		this.VecSubEff = new mVector();
		this.vecPos = new mVector();
		this.vectargetPos = new mVector();
		this.posSmock = new short[]
		{
			0,
			50,
			75,
			100,
			20,
			110,
			30
		};
		this.radian = new int[]
		{
			0,
			30,
			60,
			90,
			120,
			150,
			180,
			210,
			240,
			270,
			300,
			330
		};
		this.CR = 15;
		base..ctor();
		this.indexObjBefire = 0;
		this.valueEffect = 0;
		bool flag = !LoadMapScreen.isNextMap;
		if (!flag)
		{
			this.timeAddNum = -1;
			this.objBeFireMain = null;
			this.subType = subtype;
			this.isStop = false;
			this.isRemove = false;
			bool flag2 = vec == null || vec.size() == 0;
			if (!flag2)
			{
				this.vecObjsBeFire = vec;
				this.f = -1;
				this.ysai = 0;
				this.typeEffect = typeKill;
				this.timeBegin = GameCanvas.timeNow;
				this.objFireMain = objEffFire;
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(0);
				bool flag3 = object_Effect_Skill != null;
				if (flag3)
				{
					this.objBeFireMain = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
				}
				bool flag4 = this.objBeFireMain != null && this.objFireMain != null;
				if (flag4)
				{
					this.isEff = false;
					bool flag5 = this.objFireMain == GameScreen.player && LoadMap.specMap != 3;
					if (flag5)
					{
						this.isEff = true;
					}
					this.numNextFrame = 1;
					this.x = x;
					this.y = y;
					this.toX = this.objBeFireMain.x;
					this.toY = this.objBeFireMain.y - this.objBeFireMain.hOne / 2;
					bool flag6 = this.objFireMain != this.objBeFireMain;
					if (flag6)
					{
						base.setAngle();
						this.objFireMain.type_left_right = (int)this.Dir;
						this.objFireMain.Dir = (int)this.Dir;
					}
				}
			}
		}
	}

	// Token: 0x06000204 RID: 516 RVA: 0x00033DA8 File Offset: 0x00031FA8
	public override bool CreateEffectSkill()
	{
		bool flag = this.objFireMain == null || this.objBeFireMain == null || this.objFireMain.returnAction() || this.objBeFireMain.returnAction();
		bool result;
		if (flag)
		{
			result = false;
		}
		else
		{
			bool flag2 = this.objFireMain == GameScreen.player || CRes.random(3) == 0;
			if (flag2)
			{
				this.isAddSound = true;
			}
			this.objMainEff = this.objFireMain;
			this.am_duong = -1;
			bool flag3 = GameCanvas.lowGraphic && this.objFireMain != GameScreen.player;
			if (flag3)
			{
				bool flag4 = MainObject.getDistance(GameScreen.player.x, GameScreen.player.y, this.objFireMain.x, this.objFireMain.y) > 120;
				if (flag4)
				{
					this.removeEff();
					return true;
				}
				bool flag5 = GameMidlet.DEVICE == 0 && GameScreen.vecObjFire.size() > 30;
				if (flag5)
				{
					this.removeEff();
					return true;
				}
			}
			bool flag6 = this.Dir == 2;
			if (flag6)
			{
				this.am_duong = 1;
			}
			int typeEffect = this.typeEffect;
			int num = typeEffect;
			switch (num)
			{
			case -1:
				this.fRemove = 60;
				this.fraImgEff = new FrameImage(mImage.createImage("/eff/n1.png"), 14, 15);
				this.fraImgSubEff = new FrameImage(mImage.createImage("/eff/n1.png"), 14, 15);
				this.vMax = 16000;
				this.createDanFocus();
				this.frame = base.setFrameAngle(this.gocT_Arc);
				break;
			case 0:
				this.createNormal();
				break;
			case 1:
			case 37:
				this.createLuffy1();
				break;
			case 2:
			case 228:
			case 259:
			case 260:
			case 261:
				this.create_Devil_FIRE1();
				break;
			case 3:
			case 229:
			case 262:
			case 263:
			case 264:
				this.create_Devil_FIRE2();
				break;
			case 4:
			case 230:
				this.create_Devil_ICE1();
				break;
			case 5:
			case 231:
				this.create_Devil_ICE2();
				break;
			case 6:
			case 232:
				this.create_Devil_Smoker1();
				break;
			case 7:
				this.createUssopSea1();
				break;
			case 8:
			case 256:
			case 257:
			case 265:
			case 284:
			case 285:
			case 286:
			case 287:
			case 288:
			case 289:
			case 290:
			case 294:
			case 295:
			case 296:
			case 297:
			case 298:
			case 299:
			case 300:
			case 304:
			case 305:
			case 306:
			case 307:
			case 308:
			case 309:
			case 310:
			case 314:
			case 315:
			case 316:
			case 317:
			case 318:
			case 319:
			case 320:
			case 321:
			case 322:
			case 323:
			case 324:
			case 325:
			case 326:
			case 327:
			case 328:
			case 329:
			case 330:
			case 331:
			case 332:
			case 333:
			case 334:
			case 335:
			case 336:
			case 337:
			case 338:
			case 339:
			case 340:
			case 341:
			case 342:
			case 343:
			case 344:
			case 345:
			case 346:
			case 347:
			case 348:
			case 349:
			case 350:
			case 351:
			case 352:
			case 353:
			case 354:
			case 355:
			case 356:
			case 357:
			case 358:
			case 359:
			case 360:
			case 361:
			case 362:
			case 363:
			case 364:
			case 365:
			case 366:
			case 367:
			case 368:
			case 369:
			case 370:
			case 371:
			case 372:
			case 373:
			case 374:
			case 375:
			case 376:
			case 377:
			case 378:
			case 379:
			case 380:
			case 381:
			case 382:
			case 383:
			case 384:
			case 385:
			case 386:
			case 387:
			case 388:
			case 389:
			case 390:
			case 391:
			case 392:
			case 393:
			case 394:
			case 395:
			case 396:
			case 397:
			case 398:
			case 399:
				break;
			case 9:
			case 53:
			case 163:
				this.createNami1();
				break;
			case 10:
			case 234:
				this.create_Devil_Smoker2();
				break;
			case 11:
				this.fRemove = 15;
				this.createNamiSea1_2();
				break;
			case 12:
			case 49:
			case 50:
			case 188:
			case 220:
			case 293:
				this.createSanji2();
				break;
			case 13:
			case 258:
				this.createSmoker1();
				break;
			case 14:
			case 44:
				this.fRemove = 9;
				break;
			case 15:
			case 38:
				this.createZoro3();
				break;
			case 16:
			case 51:
				this.createNamiSkill1();
				break;
			case 17:
				this.isEff = true;
				this.Dir = (sbyte)this.objFireMain.type_left_right;
				this.addSoundBuff();
				this.y = this.objFireMain.y;
				this.objFireMain.toX = this.objFireMain.x;
				this.objFireMain.toY = this.objFireMain.y;
				this.fraImgEff = new FrameImage(101, 40, 47);
				this.fRemove = 20;
				return true;
			case 18:
				this.createSmoker2();
				break;
			case 19:
				this.createZoro4();
				break;
			case 20:
				this.fRemove = 24;
				this.levelPaint = -1;
				this.fraImgEff = new FrameImage(171, 153, 84, 100, 54);
				GameScreen.addEffectEnd(30, 0, this.x, this.objFireMain.y - this.objFireMain.hOne / 2, 600, this.Dir, this.objMainEff);
				this.y = this.objFireMain.y + 20;
				break;
			case 21:
			case 33:
			case 176:
				this.fRemove = 8;
				break;
			case 22:
			case 98:
				this.createCabaji_2();
				break;
			case 23:
			{
				this.fRemove = 3;
				this.fraImgEff = new FrameImage(20, 10, 10);
				this.vMax = 18;
				this.y -= 5;
				bool flag7 = this.Dir == 0;
				if (flag7)
				{
					this.x -= 10;
				}
				else
				{
					this.x += 10;
				}
				int xdich = this.toX - this.x;
				int ydich = this.toY - this.y;
				base.create_Speed(xdich, ydich, null);
				GameScreen.addEffectEnd(3, 0, this.x, this.y, this.Dir, this.objMainEff);
				this.fPlayFrameSuper = this.fRemove;
				bool flag8 = this.fRemove < 5;
				if (flag8)
				{
					this.fRemove = 5;
				}
				break;
			}
			case 24:
			case 80:
				this.fRemove = 14;
				break;
			case 25:
			case 235:
				this.create_Crocodile_1();
				break;
			case 26:
			case 236:
			{
				this.addVir(10, 5, 10, true);
				this.fRemove = 20;
				this.fraImgEff = new FrameImage(99, 32, 32);
				this.y = this.objFireMain.y;
				bool flag9 = this.isAddSound;
				if (flag9)
				{
					this.addSoundBuff();
				}
				break;
			}
			case 27:
				this.createChess();
				break;
			case 28:
				this.createKuromarimo();
				break;
			case 29:
				this.createZoro8();
				break;
			case 30:
				this.createMon_1();
				break;
			case 31:
			case 55:
			case 56:
			case 191:
			case 223:
			case 313:
				this.createNamiSkill3();
				break;
			case 32:
				this.createWapol();
				break;
			case 34:
			case 35:
				this.createLuffy6();
				break;
			case 36:
				this.createWapol2();
				break;
			case 39:
				this.createWapol3();
				break;
			case 40:
				this.create_Wapol4();
				break;
			case 41:
				this.createZoro_S2_L1_New();
				break;
			case 42:
				this.fRemove = 15;
				this.createZoroSkill3_Lv1();
				break;
			case 43:
				this.fRemove = 20;
				this.createZoroSkill3_Lv1();
				break;
			case 45:
				this.createMr3_1();
				break;
			case 46:
			{
				this.addSoundBuff();
				this.objFireMain.toX = this.objFireMain.x;
				this.objFireMain.toY = this.objFireMain.y;
				bool flag10 = this.objFireMain.posTransRoad != null;
				if (flag10)
				{
					this.objFireMain.posTransRoad = null;
				}
				GameScreen.addEffectEnd(85, 0, this.x, this.y, 500, this.Dir, this.objMainEff);
				this.isEff = true;
				this.fRemove = 1;
				return true;
			}
			case 47:
			case 48:
				this.createSanji1();
				break;
			case 52:
			case 189:
			case 221:
			case 311:
				this.createNamiSkill1_L3();
				break;
			case 54:
				this.createMr3_2();
				break;
			case 57:
			case 64:
			case 66:
			case 206:
			case 207:
				this.createUssop2();
				break;
			case 58:
				this.createUssopSkill1_Lv3();
				break;
			case 59:
			case 60:
				this.createMissGold_1();
				break;
			case 61:
				this.createLapin();
				break;
			case 62:
				this.createMon29();
				break;
			case 63:
			case 190:
			case 222:
			case 312:
				this.createNami1_SHORT();
				break;
			case 65:
			case 70:
			case 107:
				this.createGhin_1();
				break;
			case 67:
			case 68:
			case 69:
			case 194:
			case 226:
				this.createPhaohoa();
				break;
			case 71:
			case 145:
			case 146:
			case 147:
			case 148:
				this.createMon2();
				break;
			case 72:
			case 92:
				this.createMon3();
				break;
			case 73:
			case 74:
				this.createMon_4_5();
				break;
			case 75:
				this.createMon6();
				break;
			case 76:
				this.createAlvida1();
				break;
			case 77:
				this.createAlvida2();
				break;
			case 78:
				this.fRemove = 6;
				break;
			case 79:
				this.fRemove = 8;
				break;
			case 81:
			case 143:
			case 149:
				this.createMon_10();
				break;
			case 82:
			case 144:
				this.createMon_11();
				break;
			case 83:
			{
				this.fRemove = 16;
				bool flag11 = this.objFireMain.type_left_right == 0;
				if (flag11)
				{
					this.Dir = 0;
				}
				else
				{
					this.Dir = 2;
				}
				break;
			}
			case 84:
			case 181:
			case 213:
			case 272:
				this.createLuffy_New2_SHORT();
				break;
			case 85:
			case 182:
			case 214:
			case 273:
				this.createLuffy_New3();
				break;
			case 86:
			case 183:
			case 215:
				this.createZoro_S1_L3_SHORT();
				break;
			case 87:
			case 184:
			case 216:
				this.createZoro_New2();
				break;
			case 88:
				GameScreen.addEffectEnd(30, 0, this.x, this.y - 30, 300, this.Dir, this.objMainEff);
				this.fRemove = 8;
				this.addSound(3);
				break;
			case 89:
				this.createMorgan_2();
				break;
			case 90:
			case 91:
				this.fRemove = 1;
				break;
			case 93:
				this.toY = this.objBeFireMain.y;
				this.fRemove = 32;
				this.fraImgEff = new FrameImage(8, 40, 47, 40, 47);
				break;
			case 94:
				this.createMohji_2();
				break;
			case 95:
				this.createBuggy_1();
				break;
			case 96:
				this.createBuggy_2();
				break;
			case 97:
				this.createCabaji_1();
				break;
			case 99:
				this.createNyaban_1();
				break;
			case 100:
				this.createNyaban_2();
				break;
			case 101:
				this.createNyaban_3();
				break;
			case 102:
				this.createJango_1();
				break;
			case 103:
				this.createKuro_1();
				break;
			case 104:
				this.createKuro_2();
				break;
			case 105:
				this.createPearl_1();
				break;
			case 106:
				this.createPearl_2();
				break;
			case 108:
				this.createGhin_2();
				break;
			case 109:
				this.createDonKrieg_1();
				break;
			case 110:
				this.createDonKrieg_2();
				break;
			case 111:
				this.createDonKrieg_3();
				break;
			case 112:
			{
				this.numNextFrame = 2;
				this.fraImgEff = new FrameImage(140, 70, 70);
				bool flag12 = this.Dir == 0;
				if (flag12)
				{
					this.x -= 20;
				}
				else
				{
					this.x += 20;
				}
				this.fRemove = 15;
				break;
			}
			case 113:
			case 150:
			case 151:
			case 152:
			case 153:
				this.createHachi_2();
				break;
			case 114:
				this.createChu_1();
				break;
			case 115:
				this.createChu_2();
				break;
			case 116:
				this.createKurobi_1();
				break;
			case 117:
				this.createKurobi_2();
				break;
			case 118:
				this.createArlong_1();
				break;
			case 119:
				this.createArlong_2();
				break;
			case 120:
				this.createArlong_3();
				break;
			case 121:
				this.createZoroS3_L1_New();
				break;
			case 122:
				this.createZoroS3_L2_New();
				break;
			case 123:
			case 185:
			case 217:
			case 283:
				this.createZoroLv3();
				break;
			case 124:
			case 186:
			case 218:
				this.createSanji_s1_l3_SHORT();
				break;
			case 125:
			case 187:
				this.createSanji_s2_l3_New_SHORT();
				break;
			case 126:
			case 192:
				this.createUssopSkill1_Lv3_SHORT();
				break;
			case 127:
			case 193:
			case 225:
			case 302:
				this.createUssopS2_Le_New();
				break;
			case 128:
				this.fRemove = 10;
				break;
			case 129:
			case 130:
				this.fRemove = 16;
				break;
			case 131:
				this.fRemove = 6;
				break;
			case 132:
				this.fRemove = 10;
				break;
			case 133:
				this.fraImgEff = new FrameImage(193, 25, 15);
				this.fraImgSubEff = new FrameImage(68, 28, 44);
				this.fRemove = 15;
				this.vMax = 18;
				break;
			case 134:
			case 135:
			{
				this.fraImgEff = new FrameImage(193, 25, 15);
				this.fraImgSubEff = new FrameImage(68, 28, 44);
				this.fraImgSub2Eff = new FrameImage(194, 48, 34, 1);
				bool flag13 = this.typeEffect == 135;
				if (flag13)
				{
					this.fraImgSub3Eff = new FrameImage(30, 38, 38);
				}
				this.fRemove = 20;
				this.vMax = 18;
				break;
			}
			case 136:
				this.fraImgEff = new FrameImage(183, 20, 54);
				this.fraImgSubEff = new FrameImage(8, 40, 47, 40, 47);
				this.fRemove = 15;
				this.y = this.objFireMain.y;
				break;
			case 137:
			case 138:
				this.fraImgEff = new FrameImage(183, 20, 54);
				this.fraImgSubEff = new FrameImage(8, 40, 47, 40, 47);
				this.fRemove = 20;
				this.y = this.objFireMain.y;
				break;
			case 139:
				this.fRemove = 20;
				this.createNamiSea1_2();
				break;
			case 140:
				this.fRemove = 40;
				this.createNamiSea3();
				break;
			case 141:
				this.createUssopSea2();
				break;
			case 142:
				this.createUssopSea3();
				break;
			case 154:
				this.createZoro1();
				break;
			case 155:
				this.createZoro2();
				break;
			case 156:
				this.fRemove = 33;
				break;
			case 157:
				this.createZoro_New1();
				break;
			case 158:
			case 177:
				this.createSanji_s1_l3_New();
				break;
			case 159:
				this.createUssopSkill1_Lv3_New();
				break;
			case 160:
				this.createLuffy_New2();
				break;
			case 161:
				this.createZoro_New2_SHORT();
				break;
			case 162:
				this.createSanji_s2_l3_New();
				break;
			case 164:
			case 227:
				this.createCausu_1();
				break;
			case 165:
				this.addSoundBuff();
				this.isEff = true;
				this.Dir = (sbyte)this.objFireMain.type_left_right;
				this.addSoundBuff();
				GameScreen.addEffectEnd(85, 0, this.x, this.y, 900, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(85, 0, this.x, this.y, 900, this.Dir, this.objMainEff);
				this.y = this.objFireMain.y;
				this.objFireMain.toX = this.objFireMain.x;
				this.objFireMain.toY = this.objFireMain.y;
				this.fraImgEff = new FrameImage(101, 40, 47);
				this.fRemove = 40;
				return true;
			case 166:
				this.isEff = true;
				this.Dir = (sbyte)this.objFireMain.type_left_right;
				this.addSoundBuff();
				this.y = this.objFireMain.y;
				this.objFireMain.toX = this.objFireMain.x;
				this.objFireMain.toY = this.objFireMain.y;
				this.fraImgEff = new FrameImage(101, 40, 47);
				this.fRemove = 20;
				return true;
			case 167:
				this.fraImgEff = new FrameImage(152, 25, 21);
				this.fraImgSubEff = new FrameImage(201, 64, 50, 45, 35);
				this.fraImgSub2Eff = new FrameImage(217, 39, 18);
				this.fraImgSub3Eff = new FrameImage(92, 64, 126, 45, 89, 1);
				this.fraImgSub4Eff = new FrameImage(218, 64, 64);
				this.x = this.objFireMain.x;
				this.y = this.objFireMain.y + 10;
				this.fRemove = 30;
				this.x1000 = this.x;
				this.y1000 = this.y;
				this.levelPaint = -1;
				break;
			case 168:
				this.fRemove = 10;
				this.fraImgEff = new FrameImage(255, 42, 50, 3);
				this.y = this.objFireMain.y;
				break;
			case 169:
			case 237:
				this.fraImgEff = new FrameImage(240, 30, 73, 1);
				this.fraImgSubEff = new FrameImage(241, 40, 27, 2);
				this.fraImgSub2Eff = new FrameImage(104, 30, 30);
				this.fraImgSub3Eff = new FrameImage(242, 49, 28, 2);
				this.fraImgSub4Eff = new FrameImage(243, 36, 39);
				this.fRemove = 33;
				this.x = this.objBeFireMain.x;
				this.y = this.objBeFireMain.y;
				this.y1000 = 240;
				break;
			case 170:
			case 238:
			{
				this.fraImgEff = new FrameImage(244, 20, 37, 3);
				this.fraImgSubEff = new FrameImage(152, 25, 21);
				this.fraImgSub4Eff = new FrameImage(243, 36, 39);
				this.fraImgSub2Eff = new FrameImage(240, 30, 73, 1);
				this.fraImgSub3Eff = new FrameImage(241, 40, 27, 2);
				this.fRemove = 43;
				this.vMax = 30;
				bool flag14 = this.isAddSound;
				if (flag14)
				{
					this.addSoundBuffShort();
				}
				break;
			}
			case 171:
			case 239:
				this.y = this.objBeFireMain.y;
				this.x = this.objBeFireMain.x;
				this.fraImgEff = new FrameImage(118, 62, 64, 47, 48);
				this.fraImgSubEff = new FrameImage(174, 40, 40);
				this.fraImgSub2Eff = new FrameImage(247, 49, 28);
				this.fraImgSub3Eff = new FrameImage(254, 30, 40);
				this.vMax = 16;
				this.fRemove = 24;
				break;
			case 172:
			case 240:
			{
				this.fRemove = 24;
				this.fraImgEff = new FrameImage(254, 30, 40);
				bool flag15 = this.isAddSound;
				if (flag15)
				{
					this.addSoundBuffShort();
				}
				break;
			}
			case 173:
				this.fRemove = 8;
				this.fraImgEff = new FrameImage(257, 15, 51);
				this.fraImgSubEff = new FrameImage(3, 30, 50);
				this.vMax = 12;
				this.x += this.am_duong * 30;
				break;
			case 174:
				this.fRemove = 12;
				this.fraImgEff = new FrameImage(219, 47, 7);
				this.vMax = 7;
				break;
			case 175:
				this.levelPaint = -1;
				this.fRemove = 8;
				this.fraImgEff = new FrameImage(258, 35, 28);
				break;
			case 178:
				this.fraImgEff = new FrameImage(266, 80, 100, 64, 80, 2);
				this.fraImgSubEff = new FrameImage(201, 64, 50, 45, 35);
				this.fRemove = 35;
				GameScreen.addEffectEnd(30, 0, this.x, this.objFireMain.y - this.objFireMain.hOne, 200, this.Dir, this.objMainEff);
				this.x -= this.am_duong * 15;
				this.y = this.objFireMain.y;
				this.vMax = 10;
				this.frame = -1;
				break;
			case 179:
			case 241:
			{
				this.fRemove = 26;
				bool flag16 = this.objFireMain.vecBuffCur != null;
				if (flag16)
				{
					for (int i = 0; i < this.objFireMain.vecBuffCur.size(); i++)
					{
						MainBuff mainBuff = (MainBuff)this.objFireMain.vecBuffCur.elementAt(i);
						bool flag17 = mainBuff.IdBuff == 2037;
						if (flag17)
						{
							this.fraImgEff = new FrameImage(267, 46, 53);
							this.fraImgSubEff = new FrameImage(270, 80, 47);
							this.fraImgSub2Eff = new FrameImage(271, 130, 80, 3);
							this.fraImgSub3Eff = new FrameImage(272, 50, 24);
							bool flag18 = this.typeEffect == 241;
							if (flag18)
							{
								this.fraImgSub4Eff = new FrameImage(224, 22, 28);
							}
							this.frame = 1;
							break;
						}
					}
				}
				bool flag19 = this.fraImgEff == null;
				if (flag19)
				{
					this.fraImgEff = new FrameImage(10, 40, 47);
					this.fraImgSubEff = new FrameImage(260, 54, 54, 1);
					this.frame = 0;
				}
				bool flag20 = this.typeEffect == 241;
				if (flag20)
				{
					this.step = 1;
				}
				break;
			}
			case 180:
			case 212:
			{
				this.fRemove = 20;
				bool flag21 = this.objFireMain.type_left_right == 0;
				if (flag21)
				{
					this.Dir = 0;
				}
				else
				{
					this.Dir = 2;
				}
				bool flag22 = this.typeEffect == 212;
				if (flag22)
				{
					this.fraImgEff = new FrameImage(61, 24, 30);
				}
				break;
			}
			case 195:
				this.fraImgEff = new FrameImage(238, 30, 73);
				this.fraImgSubEff = new FrameImage(195, 40, 27);
				this.fRemove = 20;
				GameScreen.addEffectEnd(30, 0, this.x - this.am_duong * 20, this.objFireMain.y - this.objFireMain.hOne / 2 - 5, 300, this.Dir, this.objMainEff);
				break;
			case 196:
				this.fraImgEff = new FrameImage(225, 24, 32);
				this.fraImgSubEff = new FrameImage(286, 50, 100);
				this.fraImgSub2Eff = new FrameImage(98, 78, 70);
				GameScreen.addEffectEnd(30, 0, this.x, this.objFireMain.y - this.objFireMain.hOne / 2, 800, this.Dir, this.objMainEff);
				this.fRemove = 25;
				break;
			case 197:
				this.fraImgEff = new FrameImage(287, 76, 27);
				this.fRemove = 8;
				this.x += this.am_duong * 20;
				this.y -= 10;
				break;
			case 198:
				this.fraImgEff = new FrameImage(288, 30, 30);
				this.fRemove = 20;
				this.vMax = 12;
				this.x += this.am_duong * 25;
				break;
			case 199:
				this.fraImgEff = new FrameImage(291, 47, 48);
				this.fRemove = 16;
				this.y = this.objMainEff.y;
				break;
			case 200:
			{
				this.Dir = (sbyte)this.objFireMain.type_left_right;
				this.am_duong = -1;
				bool flag23 = this.Dir == 2;
				if (flag23)
				{
					this.am_duong = 1;
				}
				this.fraImgEff = new FrameImage(292, 78, 24);
				this.fraImgSubEff = new FrameImage(293, 50, 14);
				this.fRemove = 16;
				this.vMax = 10;
				this.objFireMain.isPaintWeapon = false;
				this.x += this.am_duong * 30;
				this.y -= 5;
				GameScreen.addEffectEnd(30, 0, this.x, this.y, 800, this.Dir, this.objMainEff);
				break;
			}
			case 201:
				this.fRemove = 16;
				this.vMax = 10;
				GameScreen.addEffectEnd(30, 0, this.x, this.y, 400, this.Dir, this.objMainEff);
				this.y = this.objFireMain.y;
				break;
			case 202:
				this.fraImgEff = new FrameImage(295, 34, 24);
				this.vMax = 12;
				GameScreen.addEffectEnd(30, 0, this.x, this.objFireMain.y - this.objFireMain.hOne - 10, 400, this.Dir, this.objMainEff);
				this.fRemove = 16;
				break;
			case 203:
				this.fraImgEff = new FrameImage(296, 36, 63);
				this.fRemove = 16;
				this.y = this.objMainEff.y;
				break;
			case 204:
				this.fRemove = 26;
				this.fraImgSubEff = new FrameImage(297, 83, 47);
				this.fraImgSub2Eff = new FrameImage(272, 50, 24);
				break;
			case 205:
				this.fraImgEff = new FrameImage(224, 22, 28);
				this.fraImgSubEff = new FrameImage(32, 45, 45);
				this.fRemove = 60;
				break;
			case 208:
				this.create_Eff_Tru();
				break;
			case 209:
			case 242:
				this.create_Eff_Lucci_1();
				break;
			case 210:
			case 243:
				this.create_Eff_Dong_Dat_1();
				break;
			case 211:
			case 244:
				this.create_Eff_Dong_Dat_2();
				break;
			case 219:
				this.fraImgEff = new FrameImage(323, 92, 64);
				this.fraImgSubEff = new FrameImage(183, 20, 54);
				this.fRemove = 26;
				GameScreen.addEffectEnd(30, 0, this.x + this.am_duong * 15, this.y, 200, this.Dir, this.objMainEff);
				this.mframe = new int[]
				{
					-1,
					-1,
					-1,
					-1,
					-1,
					0,
					0,
					1,
					1,
					-1,
					2,
					2,
					2,
					4,
					4,
					5,
					5,
					-1,
					6,
					6,
					7,
					-1
				};
				this.x1000 = this.objFireMain.x;
				this.y1000 = this.objFireMain.y;
				break;
			case 224:
			case 301:
				this.createUssopS1_L5();
				break;
			case 233:
				this.fraImgEff = new FrameImage(107, 50, 54);
				this.fRemove = 20;
				break;
			case 245:
			case 251:
			{
				this.fraImgEff = new FrameImage(357, 100, 100, 2);
				this.fraImgSubEff = new FrameImage(358, 51, 22);
				this.fRemove = 22;
				this.x += this.am_duong * 30;
				int[][] array = new int[12][];
				array[0] = new int[3];
				int num2 = 1;
				int[] array2 = new int[3];
				array2[1] = 10;
				array[num2] = array2;
				int num3 = 2;
				int[] array3 = new int[3];
				array3[1] = 25;
				array[num3] = array3;
				array[3] = new int[]
				{
					1,
					0,
					-15
				};
				array[4] = new int[]
				{
					1,
					10,
					-5
				};
				array[5] = new int[]
				{
					1,
					20,
					5
				};
				int num4 = 6;
				int[] array4 = new int[3];
				array4[0] = 2;
				array4[1] = 10;
				array[num4] = array4;
				array[7] = new int[]
				{
					2,
					15,
					5
				};
				array[8] = new int[]
				{
					2,
					30,
					15
				};
				int num5 = 9;
				int[] array5 = new int[3];
				array5[0] = 3;
				array[num5] = array5;
				int num6 = 10;
				int[] array6 = new int[3];
				array6[0] = 3;
				array6[1] = 10;
				array[num6] = array6;
				int num7 = 11;
				int[] array7 = new int[3];
				array7[0] = 3;
				array7[1] = 30;
				array[num7] = array7;
				this.mframeSuper = array;
				break;
			}
			case 246:
			case 253:
			{
				this.fraImgEff = new FrameImage(351, 35, 62);
				this.fraImgSubEff = new FrameImage(354, 40, 47);
				this.fRemove = 26;
				bool flag24 = this.isAddSound;
				if (flag24)
				{
					this.addSoundBuffShort();
				}
				GameScreen.addEffectEnd(30, 0, this.x, this.y, 400, this.Dir, this.objMainEff);
				break;
			}
			case 247:
			case 254:
			{
				this.y = this.objFireMain.y - this.objFireMain.hOne + 8;
				this.fraImgEff = new FrameImage(352, 52, 15);
				this.fraImgSubEff = new FrameImage(353, 9, 7);
				this.fraImgSub2Eff = new FrameImage(355, 9, 10);
				this.fraImgSub3Eff = new FrameImage(224, 22, 28);
				this.fRemove = 24;
				GameScreen.addEffectEnd(30, 0, this.x, this.y, 400, this.Dir, this.objMainEff);
				this.vMax = 140;
				bool flag25 = CRes.abs(this.objFireMain.x - this.objBeFireMain.x) < 32;
				if (flag25)
				{
					this.objFireMain.x -= this.am_duong * 32;
				}
				break;
			}
			case 248:
			case 255:
				this.createKilo_1();
				break;
			case 249:
			case 252:
			{
				this.fraImgEff = new FrameImage(357, 100, 100, 2);
				this.fraImgSubEff = new FrameImage(359, 64, 64);
				this.fraImgSub2Eff = new FrameImage(183, 20, 54);
				this.fRemove = 22;
				this.x += this.am_duong * 30;
				this.addSoundBuffShort();
				int[][] array8 = new int[12][];
				array8[0] = new int[3];
				int num8 = 1;
				int[] array9 = new int[3];
				array9[1] = 10;
				array8[num8] = array9;
				int num9 = 2;
				int[] array10 = new int[3];
				array10[1] = 35;
				array8[num9] = array10;
				array8[3] = new int[]
				{
					1,
					0,
					-15
				};
				array8[4] = new int[]
				{
					1,
					10,
					-5
				};
				array8[5] = new int[]
				{
					1,
					30,
					5
				};
				int num10 = 6;
				int[] array11 = new int[3];
				array11[0] = 2;
				array11[1] = 10;
				array8[num10] = array11;
				array8[7] = new int[]
				{
					2,
					15,
					5
				};
				array8[8] = new int[]
				{
					2,
					40,
					15
				};
				int num11 = 9;
				int[] array12 = new int[3];
				array12[0] = 3;
				array8[num11] = array12;
				int num12 = 10;
				int[] array13 = new int[3];
				array13[0] = 3;
				array13[1] = 10;
				array8[num12] = array13;
				int num13 = 11;
				int[] array14 = new int[3];
				array14[0] = 3;
				array14[1] = 40;
				array8[num13] = array14;
				this.mframeSuper = array8;
				break;
			}
			case 250:
				this.create_Eff_Tru_2();
				break;
			case 266:
				this.createRankyaku();
				break;
			case 267:
				this.createShigan();
				break;
			case 268:
			case 269:
				this.createDoor();
				break;
			case 270:
			{
				this.numNextFrame = 2;
				this.fraImgEff = new FrameImage(427, 4);
				bool flag26 = this.Dir == 0;
				if (flag26)
				{
					this.x -= 20;
				}
				else
				{
					this.x += 20;
				}
				this.fRemove = 15;
				break;
			}
			case 271:
			{
				this.fRemove = 15;
				bool flag27 = this.objFireMain.type_left_right == 0;
				if (flag27)
				{
					this.Dir = 0;
				}
				else
				{
					this.Dir = 2;
				}
				this.fraImgEff = new FrameImage(61, 24, 30);
				break;
			}
			case 274:
			case 275:
				this.fRemove = 15;
				this.fraImgEff = new FrameImage(431, 2);
				break;
			case 276:
			case 277:
				this.createSoi();
				break;
			case 278:
			case 279:
				this.createHuou();
				break;
			case 280:
			{
				this.fraImgEff = new FrameImage(mImage.createImage("/eff/khungthanh.png"), 1);
				this.fraImgSubEff = new FrameImage(mImage.createImage("/eff/ball.png"), 4);
				this.x = this.objFireMain.x;
				this.y = this.objFireMain.y;
				this.toX = this.x + 200;
				this.toY = this.y - 30;
				this.vx = 5;
				this.vy = -1;
				this.vMax = 10;
				int xdich2 = this.toX - this.x;
				int ydich2 = this.toY - this.y - CRes.random(20);
				base.create_Speed(xdich2, ydich2, null);
				this.fRemove = 40;
				this.objFireMain.Dir = 2;
				break;
			}
			case 281:
				this.createZoro_S1_L6();
				break;
			case 282:
			{
				this.fRemove = 34;
				this.vMax = 12;
				this.fraImgEff = new FrameImage(413, 91, 73);
				bool flag28 = this.isAddSound;
				if (flag28)
				{
					mSound.playSound(8, mSound.volumeSound);
				}
				GameScreen.addEffectEnd(30, 0, this.x, this.y, 300, this.Dir, this.objMainEff);
				this.fraImgSubEff = new FrameImage(415, 3);
				break;
			}
			case 291:
				this.fraImgEff = new FrameImage(323, 92, 64);
				this.fraImgSubEff = new FrameImage(183, 20, 54);
				this.fRemove = 18;
				GameScreen.addEffectEnd(30, 0, this.x + this.am_duong * 15, this.y, 200, this.Dir, this.objMainEff);
				this.mframe = new int[]
				{
					4,
					4,
					5,
					5,
					4,
					4,
					5,
					5,
					4,
					4,
					5,
					5,
					4,
					4,
					5,
					5,
					6,
					6,
					6,
					-1
				};
				this.x1000 = this.objFireMain.x;
				this.y1000 = this.objFireMain.y;
				break;
			case 292:
				this.fraImgEff = new FrameImage(323, 92, 64);
				this.fraImgSubEff = new FrameImage(183, 20, 54);
				this.fRemove = 26;
				GameScreen.addEffectEnd(30, 0, this.x + this.am_duong * 15, this.y, 200, this.Dir, this.objMainEff);
				this.mframe = new int[]
				{
					4,
					4,
					5,
					5,
					4,
					4,
					5,
					5,
					4,
					4,
					5,
					5,
					6,
					6,
					0,
					0,
					0,
					0,
					0,
					0,
					1,
					1,
					1,
					1,
					1,
					1
				};
				this.x1000 = this.objFireMain.x;
				this.y1000 = this.objFireMain.y;
				break;
			case 303:
				this.createPhaohoa_L6();
				break;
			case 400:
				for (int j = 0; j < this.vecObjsBeFire.size(); j++)
				{
					Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(j);
					bool flag29 = object_Effect_Skill != null;
					if (flag29)
					{
						MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
						bool flag30 = mainObject != null;
						if (flag30)
						{
							GameScreen.addHightDataeff(2, mainObject.x, mainObject.y);
							LoadMap.timeVibrateScreen = CRes.random(6, 20);
							GameScreen.addEffectEnd(112, 0, mainObject.x, mainObject.y, this.Dir, this.objMainEff);
							this.VecSubEff.addElement(new Point(mainObject.x, mainObject.y));
						}
					}
				}
				break;
			case 401:
				this.levelPaint = 1;
				this.x = this.objBeFireMain.x;
				this.y = this.objBeFireMain.y;
				GameScreen.addHightDataeff(4, this.x, this.y);
				GameScreen.addEffectEnd(63, 0, this.x, this.y, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(110, 0, this.x, this.y, this.Dir, this.objMainEff);
				LoadMap.timeVibrateScreen = CRes.random(1, 5);
				this.removeEff();
				break;
			case 402:
				this.VecSubEff = new mVector();
				for (int k = 0; k < this.vecObjsBeFire.size(); k++)
				{
					Object_Effect_Skill object_Effect_Skill2 = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(k);
					bool flag31 = object_Effect_Skill2 != null;
					if (flag31)
					{
						MainObject mainObject2 = MainObject.get_Object((int)object_Effect_Skill2.ID, object_Effect_Skill2.tem);
						bool flag32 = mainObject2 != null;
						if (flag32)
						{
							GameScreen.addHightDataeff(2, mainObject2.x, mainObject2.y);
							LoadMap.timeVibrateScreen = CRes.random(6, 20);
							GameScreen.addEffectEnd(112, 0, mainObject2.x, mainObject2.y, this.Dir, this.objMainEff);
							this.VecSubEff.addElement(new Point(mainObject2.x, mainObject2.y));
						}
					}
				}
				this.frameSuper = 4;
				this.fraImgEff = new FrameImage(32, 45, 45, 5, this.frameSuper);
				this.fRemove = 30;
				this.vMax = 12;
				this.y = this.objFireMain.y;
				break;
			case 403:
				this.levelPaint = 1;
				this.x = this.objBeFireMain.x;
				this.y = this.objBeFireMain.y;
				GameScreen.addHightDataeff(8, this.x, this.y);
				GameScreen.addEffectEnd(63, 0, this.x, this.y, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(110, 0, this.x, this.y, this.Dir, this.objMainEff);
				LoadMap.timeVibrateScreen = CRes.random(1, 5);
				this.removeEff();
				break;
			default:
				switch (num)
				{
				case 10001:
					this.fraImgEff = new FrameImage(173, 70, 42, 50, 30);
					this.fraImgSubEff = new FrameImage(172, 60, 43);
					this.x = this.objFireMain.x;
					this.y = this.objFireMain.y - this.objFireMain.hOne / 2;
					this.levelPaint = -1;
					break;
				case 10002:
					this.fraImgEff = new FrameImage(76, 32, 70);
					this.fraImgSubEff = new FrameImage(129, 40, 80);
					this.x = this.objFireMain.x;
					this.y = this.objFireMain.y;
					this.fRemove = 22;
					break;
				case 10003:
					this.fraImgEff = new FrameImage(77, 64, 75, 43, 50);
					this.x = this.objFireMain.x;
					this.y = this.objFireMain.y - this.objFireMain.hOne / 4;
					break;
				case 10004:
					this.fraImgEff = new FrameImage(174, 40, 40);
					this.fraImgSubEff = new FrameImage(26, 40, 40);
					this.x = this.objFireMain.x;
					this.y = this.objFireMain.y;
					this.fRemove = 30;
					break;
				case 10005:
					this.objFireMain.Dir = (int)this.Dir;
					this.x = this.objFireMain.x;
					this.y = this.objFireMain.y - this.objFireMain.hOne / 2;
					break;
				case 10006:
				case 10011:
					this.fraImgSubEff = new FrameImage(172, 60, 43);
					this.levelPaint = -1;
					break;
				case 10007:
					this.fraImgEff = new FrameImage(118, 62, 64, 47, 48);
					this.fraImgSubEff = new FrameImage(173, 70, 42, 50, 30);
					break;
				case 10008:
					this.levelPaint = -1;
					this.fraImgEff = new FrameImage(175, 13, 11);
					this.objFireMain.Dir = (int)this.Dir;
					this.x = this.objFireMain.x;
					this.y = this.objFireMain.y - this.objFireMain.hOne / 2;
					break;
				case 10009:
					this.objFireMain.Dir = (int)this.Dir;
					this.fRemove = 30;
					break;
				case 10010:
				case 10013:
					this.x = this.objFireMain.x;
					this.y = this.objFireMain.y - this.objFireMain.hOne / 2;
					this.fraImgEff = new FrameImage(178, 70, 65);
					this.numNextFrame = 2;
					break;
				case 10012:
					this.createXerath3();
					break;
				case 10015:
					this.createUrgot3();
					break;
				case 10017:
					this.objFireMain.Dir = (int)this.Dir;
					this.x = this.objFireMain.x;
					this.y = this.objFireMain.y - this.objFireMain.hOne / 4;
					this.fraImgEff = new FrameImage(180, 32, 63);
					this.numNextFrame = 3;
					break;
				case 10018:
					this.objFireMain.Dir = (int)this.Dir;
					this.x = this.objFireMain.x;
					this.y = this.objFireMain.y;
					this.fraImgEff = new FrameImage(8, 40, 47, 40, 47);
					break;
				case 10019:
					this.objFireMain.Dir = (int)this.Dir;
					this.x = this.objFireMain.x;
					this.y = this.objFireMain.y;
					this.fRemove = 8;
					break;
				case 10020:
					this.objFireMain.Dir = (int)this.Dir;
					this.x = this.objFireMain.x;
					this.y = this.objFireMain.y - this.objFireMain.hOne / 2;
					this.fraImgEff = new FrameImage(189, 37, 62);
					this.numNextFrame = 3;
					this.levelPaint = -1;
					break;
				case 10021:
				case 10022:
					this.objFireMain.Dir = (int)this.Dir;
					this.x = this.objFireMain.x;
					this.y = this.objFireMain.y - this.objFireMain.hOne / 2;
					this.fraImgEff = new FrameImage(181, 47, 63, 38, 51);
					this.numNextFrame = 3;
					this.levelPaint = -1;
					break;
				case 10023:
					this.fRemove = 4;
					break;
				case 10024:
					base.setAngle();
					this.objFireMain.Dir = (int)this.Dir;
					this.x = this.objFireMain.x;
					this.y = this.objFireMain.y - this.objFireMain.hOne / 2;
					this.fraImgEff = new FrameImage(181, 47, 63, 38, 51);
					this.fraImgSubEff = new FrameImage(172, 60, 43);
					this.numNextFrame = 3;
					this.levelPaint = -1;
					break;
				case 10025:
					base.setAngle();
					this.objFireMain.Dir = (int)this.Dir;
					this.createMonster_NEM_BOOM_2();
					break;
				case 10026:
					this.x = this.objFireMain.x;
					this.y = this.objFireMain.y - this.objFireMain.hOne / 2;
					this.fraImgEff = new FrameImage(182, 56, 80, 40, 57);
					this.numNextFrame = 2;
					this.levelPaint = -1;
					break;
				case 10027:
					for (int l = 0; l < this.vecPos.size(); l++)
					{
						Point_Focus point_Focus = (Point_Focus)this.vecPos.elementAt(l);
						GameScreen.addEffectEnd_ObjTo(22, 0, point_Focus.x, point_Focus.y - 30, this.objFireMain.ID, this.objFireMain.typeObject, (sbyte)this.objFireMain.Dir, this.objMainEff);
					}
					this.fRemove = 10;
					break;
				case 10028:
					this.fraImgSub3Eff = new FrameImage(242, 49, 28, 2);
					this.fRemove = 33;
					this.x = this.objBeFireMain.x;
					this.y = this.objBeFireMain.y;
					this.y1000 = 240;
					for (int m = 0; m < this.vecObjsBeFire.size(); m++)
					{
						Object_Effect_Skill object_Effect_Skill3 = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(m);
						bool flag33 = object_Effect_Skill3 != null;
						if (flag33)
						{
							GameScreen.addEffectSkill2(-1, this.objFireMain, object_Effect_Skill3, this.x + (int)this.posSmock[CRes.random(this.posSmock.Length - 1)], this.y - 200 + CRes.random_Am(-10, 10));
							GameScreen.addEffectSkill2(-1, this.objFireMain, object_Effect_Skill3, this.x + (int)this.posSmock[CRes.random(this.posSmock.Length - 1)], this.y - 200 + CRes.random_Am(-10, 10));
							GameScreen.addEffectSkill2(-1, this.objFireMain, object_Effect_Skill3, this.x + (int)this.posSmock[CRes.random(this.posSmock.Length - 1)], this.y - 200 + CRes.random_Am(-10, 10));
						}
					}
					GameScreen.addEffectEnd(112, 0, this.x, this.y + 10, this.Dir, this.objMainEff);
					break;
				case 10030:
					this.create_ho_den_vu_tru();
					break;
				}
				break;
			}
			bool flag34 = this.objFireMain == GameScreen.player;
			if (flag34)
			{
				for (int n = 0; n < this.vecObjsBeFire.size(); n++)
				{
					Object_Effect_Skill object_Effect_Skill4 = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(n);
					bool flag35 = object_Effect_Skill4 == null;
					if (!flag35)
					{
						bool flag36 = GameScreen.typePaintGameScreen == 1;
						if (flag36)
						{
							MainObject mainObject3 = MainObject.get_Object((int)object_Effect_Skill4.ID, object_Effect_Skill4.tem);
							bool flag37 = mainObject3 != null;
							if (flag37)
							{
								mainObject3.isPaintSpec = true;
							}
						}
						else
						{
							MainObject mainObject4 = MainObject.get_Object((int)object_Effect_Skill4.ID, object_Effect_Skill4.tem);
							bool flag38 = mainObject4 == null || mainObject4.typeObject != 1;
							if (!flag38)
							{
								int num14 = CRes.abs(this.objFireMain.x - mainObject4.x);
								bool flag39 = num14 < 32;
								if (flag39)
								{
									mainObject4.x += this.am_duong * (num14 - 32 + 10);
									mainObject4.vXEffAva = (54 - num14) / 2 * this.am_duong;
									bool flag40 = mainObject4.Action != 4 && mainObject4.Action != 2 && mainObject4.Hp > 0;
									if (flag40)
									{
										mainObject4.Action = 3;
										mainObject4.f = 0;
										mainObject4.resetAction();
									}
									else
									{
										mainObject4.vXEffAva = 0;
										mainObject4.dy = 0;
									}
								}
							}
						}
					}
				}
			}
			bool flag41 = !this.isEff;
			if (flag41)
			{
				Effect_Skill.setHP_New(this.vecObjsBeFire, this.objFireMain, false);
				bool flag42 = this.vecObjsBeFire.size() == 0;
				if (flag42)
				{
					this.isStop = true;
					return false;
				}
			}
			result = true;
		}
		return result;
	}

	// Token: 0x06000205 RID: 517 RVA: 0x00037098 File Offset: 0x00035298
	public void createDanFocus()
	{
		switch (CRes.random(4))
		{
		case 0:
			this.gocT_Arc = 90;
			break;
		case 1:
			this.gocT_Arc = 270;
			break;
		case 2:
			this.gocT_Arc = 180;
			break;
		case 3:
			this.gocT_Arc = 0;
			break;
		}
		this.va = 4096;
		this.vx = 0;
		this.vy = 0;
		this.life = 0;
		this.vX1000 = this.va * CRes.getcos(this.gocT_Arc) >> 10;
		this.vY1000 = this.va * CRes.getsin(this.gocT_Arc) >> 10;
	}

	// Token: 0x06000206 RID: 518 RVA: 0x0003714C File Offset: 0x0003534C
	private void create_Eff_Tru_2()
	{
		this.fraImgEff = new FrameImage(100, 15, 20);
		this.y = this.objFireMain.y - 55;
		bool flag = this.objFireMain.IdIcon == 58;
		if (flag)
		{
			this.fraImgEff = new FrameImage(366, 15, 20);
			this.y = this.objFireMain.y - 80;
		}
		this.vMax = 20;
		for (int i = 0; i < this.vecObjsBeFire.size(); i++)
		{
			Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(i);
			bool flag2 = object_Effect_Skill == null;
			if (!flag2)
			{
				MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
				bool flag3 = mainObject != null;
				if (flag3)
				{
					Point_Focus point_Focus = new Point_Focus(this.x, this.y);
					int xdich = mainObject.x - this.x;
					int ydich = mainObject.y - mainObject.hOne / 2 - this.y;
					base.create_Speed(xdich, ydich, point_Focus, this.x, this.y, mainObject.x, mainObject.y - mainObject.hOne / 2);
					point_Focus.dis = 0;
					bool flag4 = mainObject.x > this.x;
					if (flag4)
					{
						point_Focus.dis = 2;
					}
					this.VecEff.addElement(point_Focus);
				}
			}
		}
	}

	// Token: 0x06000207 RID: 519 RVA: 0x000372C8 File Offset: 0x000354C8
	private void createKilo_1()
	{
		this.fraImgEff = new FrameImage(356, 40, 80);
		this.fraImgSubEff = new FrameImage(183, 20, 54);
		this.toY = this.objBeFireMain.y;
		this.fRemove = 22;
	}

	// Token: 0x06000208 RID: 520 RVA: 0x00037318 File Offset: 0x00035518
	private void create_Crocodile_1()
	{
		this.fRemove = 20;
		this.y = this.objFireMain.y;
		this.fraImgEff = new FrameImage(200, 54, 70, 40, 52);
		this.objFireMain.isTanHinh = true;
		bool flag = this.isAddSound;
		if (flag)
		{
			mSound.playSound(42, mSound.volumeSound);
		}
		bool flag2 = this.typeEffect == 235;
		if (flag2)
		{
			this.vMax = 120;
			this.fraImgSubEff = new FrameImage(118, 62, 64);
		}
	}

	// Token: 0x06000209 RID: 521 RVA: 0x000373A8 File Offset: 0x000355A8
	private void createUssopS1_L5()
	{
		this.fraImgEff = new FrameImage(183, 20, 54);
		this.fraImgSubEff = new FrameImage(330, 46, 49);
		this.mframeSuper = new int[][]
		{
			new int[]
			{
				-5,
				-15
			},
			new int[]
			{
				5,
				15
			},
			new int[]
			{
				15,
				-5
			},
			new int[]
			{
				-15,
				5
			},
			new int[]
			{
				-10,
				-10
			},
			new int[]
			{
				10,
				10
			}
		};
		this.y = this.objFireMain.y;
		this.fRemove = 18;
		this.vMax = 24;
		bool flag = this.typeEffect == 301;
		if (flag)
		{
			this.x1000 = this.x + 30 * this.am_duong;
			this.xLight1 = this.x1000;
			this.xLight2 = this.x1000;
			this.fraImgSub2Eff = new FrameImage(416, 4);
			int xdich = this.x1000 - this.x;
			int ydich = 0;
			this.VecSubEff.addElement(base.create_Speed(xdich, ydich, new Point_Focus(), this.x, this.y - this.objFireMain.hOne / 4 * 3, this.toX, this.toY));
			this.VecSubEff.addElement(base.create_Speed(xdich, ydich, new Point_Focus(), this.x, this.y - this.objFireMain.hOne / 2, this.toX, this.toY));
		}
	}

	// Token: 0x0600020A RID: 522 RVA: 0x00037560 File Offset: 0x00035760
	private void create_Eff_Dong_Dat_2()
	{
		this.fraImgEff = new FrameImage(118, 62, 64);
		bool flag = this.typeEffect == 244;
		if (flag)
		{
			this.fraImgSubEff = new FrameImage(138, 62, 64);
		}
		this.fRemove = 30;
		GameScreen.addEffectEnd(30, 0, this.x + 10, this.objFireMain.y - this.objFireMain.hOne / 2, 600, this.Dir, this.objMainEff);
		GameScreen.addEffectEnd(30, 0, this.x - 10, this.objFireMain.y - this.objFireMain.hOne / 2, 600, this.Dir, this.objMainEff);
		this.y = this.objFireMain.y;
		bool flag2 = this.isAddSound;
		if (flag2)
		{
			this.addSoundBuffShort();
		}
	}

	// Token: 0x0600020B RID: 523 RVA: 0x0003764C File Offset: 0x0003584C
	private void create_Eff_Dong_Dat_1()
	{
		this.fraImgEff = new FrameImage(310, 73, 59);
		this.fraImgSubEff = new FrameImage(311, 149, 179);
		GameScreen.addEffectEnd(30, 0, this.x + 10, this.objFireMain.y - this.objFireMain.hOne / 2, 400, this.Dir, this.objMainEff);
		GameScreen.addEffectEnd(30, 0, this.x - 10, this.objFireMain.y - this.objFireMain.hOne / 2, 400, this.Dir, this.objMainEff);
		this.fRemove = 50;
		bool flag = this.objFireMain == GameScreen.player;
		if (flag)
		{
			this.fRemove = 70;
		}
		bool flag2 = this.isAddSound;
		if (flag2)
		{
			this.addSoundBuffShort();
		}
	}

	// Token: 0x0600020C RID: 524 RVA: 0x00037738 File Offset: 0x00035938
	private void create_Eff_Lucci_1()
	{
		this.fraImgEff = new FrameImage(274, 23, 74, 3);
		this.frame = 0;
		this.vx = this.am_duong * 12;
		this.x1000 = this.x;
		GameScreen.addEffectEnd(30, 0, this.x + this.am_duong * 20, this.objFireMain.y - this.objFireMain.hOne / 2, 400, this.Dir, this.objMainEff);
		this.x = this.x1000 - this.am_duong * 24;
		this.fRemove = 20;
		bool flag = this.isAddSound;
		if (flag)
		{
			mSound.playSound(42, mSound.volumeSound);
			this.addSoundBuffShort();
		}
		bool flag2 = this.objFireMain.vecBuffCur != null;
		if (flag2)
		{
			for (int i = 0; i < this.objFireMain.vecBuffCur.size(); i++)
			{
				MainBuff mainBuff = (MainBuff)this.objFireMain.vecBuffCur.elementAt(i);
				bool flag3 = mainBuff.IdBuff == 2040 || mainBuff.IdBuff == 2064;
				if (flag3)
				{
					this.fraImgSubEff = new FrameImage(273, 24, 24, 4);
					this.frame = 1;
					break;
				}
				bool flag4 = mainBuff.IdBuff == 2061;
				if (flag4)
				{
					this.fraImgSubEff = new FrameImage(273, 24, 24, 4);
					this.frame = 3;
					break;
				}
			}
		}
		bool flag5 = this.frame == 0;
		if (flag5)
		{
			this.mframe = new int[]
			{
				1,
				0,
				1,
				0,
				1,
				0,
				0,
				1,
				1,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2
			};
		}
		else
		{
			this.mframe = new int[]
			{
				1,
				0,
				1,
				0,
				1,
				0,
				0,
				1,
				2,
				2,
				3,
				3,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4
			};
		}
		bool flag6 = this.typeEffect == 242;
		if (flag6)
		{
			GameScreen.addEffectEnd(147, (int)((sbyte)this.frame), this.x + this.am_duong * 120, this.objFireMain.y - this.objFireMain.hOne / 2, 400, this.Dir, this.objMainEff);
		}
	}

	// Token: 0x0600020D RID: 525 RVA: 0x00037970 File Offset: 0x00035B70
	private void create_Eff_Tru()
	{
		this.fraImgEff = new FrameImage(100, 15, 20);
		this.vMax = 20;
		this.y = this.objFireMain.y - 55;
		int xdich = this.toX - this.x;
		int ydich = this.toY - this.y;
		base.create_Speed(xdich, ydich, null);
	}

	// Token: 0x0600020E RID: 526 RVA: 0x000098B5 File Offset: 0x00007AB5
	private void createMon29()
	{
		this.fraImgEff = new FrameImage(118, 62, 64, 47, 48);
		this.toY = this.objBeFireMain.y + 5;
		this.numNextFrame = 2;
		this.fRemove = 8;
	}

	// Token: 0x0600020F RID: 527 RVA: 0x000379D4 File Offset: 0x00035BD4
	private void createLapin()
	{
		this.vMax = 16;
		this.fraImgEff = new FrameImage(213, 15, 15);
		int xdich = this.toX - this.x;
		int ydich = this.toY - this.y;
		base.create_Speed(xdich, ydich, null);
	}

	// Token: 0x06000210 RID: 528 RVA: 0x00037A24 File Offset: 0x00035C24
	public override void paint(mGraphics g)
	{
		try
		{
			int typeEffect = this.typeEffect;
			int num = typeEffect;
			switch (num)
			{
			case -1:
			{
				int num2;
				for (int i = 0; i < this.VecEff.size(); i = num2 + 1)
				{
					Point point = (Point)this.VecEff.elementAt(i);
					this.fraImgSubEff.drawFrame(point.f / 2 % this.fraImgSubEff.nFrame, point.x, point.y, 0, 3, g);
					num2 = i;
				}
				break;
			}
			case 0:
			case 36:
			case 61:
			case 71:
			case 76:
			case 81:
			case 143:
			case 145:
			case 146:
			case 148:
				this.fraImgEff.drawFrame(this.f / (int)this.numNextFrame % this.fraImgEff.nFrame, this.x, this.y, (int)this.Dir, 3, g);
				break;
			case 1:
			case 37:
			{
				this.fraImgEff.drawFrame(this.f / (int)this.numNextFrame % this.fraImgEff.nFrame, this.x, this.y, (int)this.Dir, 3, g);
				int num2;
				for (int j = 0; j < this.VecEff.size(); j = num2 + 1)
				{
					Point point2 = (Point)this.VecEff.elementAt(j);
					this.fraImgSubEff.drawFrame(point2.f % this.fraImgSubEff.nFrame, point2.x, point2.y, (int)this.Dir, 3, g);
					num2 = j;
				}
				break;
			}
			case 2:
			{
				int num2;
				for (int k = 0; k < this.VecEff.size(); k = num2 + 1)
				{
					Point point3 = (Point)this.VecEff.elementAt(k);
					this.fraImgEff.drawFrameNew(point3.frame, point3.x, point3.y, 0, 33, g);
					num2 = k;
				}
				break;
			}
			case 3:
			case 229:
			case 262:
			case 263:
			case 264:
			{
				int num2;
				for (int l = 0; l < this.VecEff.size(); l = num2 + 1)
				{
					Point point4 = (Point)this.VecEff.elementAt(l);
					bool flag = point4.frame == 0;
					if (flag)
					{
						int idx = (point4.f >= point4.fRe - 3) ? (this.fraImgSubEff.maxNumFrame - (point4.fRe - point4.f)) : (point4.f % 2);
						this.fraImgSubEff.drawFrameNew_BeginSuper(idx, point4.x / 1000, point4.y / 1000, 0, 3, g);
					}
					else
					{
						int idx2 = (point4.f >= point4.fRe - 3) ? (this.fraImgEff.maxNumFrame - (point4.fRe - point4.f)) : ((point4.f + point4.fSmall) % 3);
						this.fraImgEff.drawFrameNew_BeginSuper(idx2, point4.x / 1000, point4.y / 1000, 0, 3, g);
					}
					num2 = l;
				}
				for (int m = 0; m < this.VecSubEff.size(); m = num2 + 1)
				{
					Point point5 = (Point)this.VecSubEff.elementAt(m);
					bool flag2 = point5.frame == 0;
					if (flag2)
					{
						this.fraImgSubEff.drawFrameNew_BeginSuper(point5.f % this.fraImgSubEff.maxNumFrame, point5.x, point5.y, 0, 3, g);
					}
					else
					{
						bool flag3 = point5.frame == 1;
						if (flag3)
						{
							this.fraImgSub2Eff.drawFrameNew_BeginSuper(point5.f / 2 % 3, point5.x, point5.y, 0, 33, g);
						}
					}
					num2 = m;
				}
				bool flag4 = this.f >= 13 && this.f <= 23;
				if (flag4)
				{
					this.fraImgSub3Eff.drawFrameNew_BeginSuper(this.f / 2 % 3, this.x, this.y + 8, 0, 33, g);
				}
				else
				{
					bool flag5 = this.f >= 8 && this.f <= 28;
					if (flag5)
					{
						this.fraImgEff.drawFrameNew_BeginSuper(this.f % 5, this.x, this.y + 3, 0, 33, g);
					}
				}
				break;
			}
			case 4:
			case 230:
			{
				bool flag6 = this.f >= 0 && this.f < this.mframe.Length;
				if (flag6)
				{
					this.fraImgSub2Eff.drawFrame(this.mframe[this.f], this.x, this.y + 4, 0, 33, g);
				}
				int num2;
				for (int n = 0; n < this.VecSubEff.size(); n = num2 + 1)
				{
					Point point6 = (Point)this.VecSubEff.elementAt(n);
					this.fraImgSub3Eff.drawFrame(point6.f / 2 % this.fraImgSub3Eff.nFrame, point6.x, point6.y, 0, 3, g);
					num2 = n;
				}
				for (int num3 = 0; num3 < this.VecEff.size(); num3 = num2 + 1)
				{
					Point point7 = (Point)this.VecEff.elementAt(num3);
					bool flag7 = point7.f >= point7.fSmall;
					if (flag7)
					{
						bool flag8 = point7.frame == 0;
						if (flag8)
						{
							this.fraImgEff.drawFrame(0, point7.x, point7.y, 0, 3, g);
						}
						else
						{
							bool flag9 = point7.frame == 1 && this.fraImgEff.getImageFrame() != null;
							if (flag9)
							{
								g.drawRegion(this.fraImgEff.getImageFrame(), 0, 0, this.fraImgEff.frameWidth, this.fraImgEff.frameHeight - point7.dis, 0, (float)point7.x, (float)point7.y, 33);
							}
						}
					}
					num2 = num3;
				}
				break;
			}
			case 5:
			case 231:
			{
				int num2;
				for (int num4 = 0; num4 < this.VecSubEff.size(); num4 = num2 + 1)
				{
					Point point8 = (Point)this.VecSubEff.elementAt(num4);
					this.fraImgSub3Eff.drawFrame(point8.f / 2 % this.fraImgSub3Eff.nFrame, point8.x, point8.y, 0, 3, g);
					num2 = num4;
				}
				bool flag10 = this.f >= 10 && this.f <= 15;
				if (flag10)
				{
					this.fraImgEff.drawFrame(0, this.x + this.plusxy[0][0] * this.am_duong, this.y + this.plusxy[0][1], (int)this.Dir, 3, g);
				}
				bool flag11 = this.f > 15 && this.f <= 17;
				if (flag11)
				{
					this.fraImgEff.drawFrame(1, this.x + this.plusxy[1][0] * this.am_duong, this.y + this.plusxy[1][1], (int)this.Dir, 3, g);
				}
				bool flag12 = this.f > 17 && this.f <= 26;
				if (flag12)
				{
					this.fraImgSubEff.drawFrame((this.f - 18) / 3, this.x + this.plusxy[2][0] * this.am_duong, this.y + this.plusxy[2][1], (int)this.Dir, 3, g);
				}
				break;
			}
			case 6:
			case 232:
			{
				bool flag13 = this.f >= 20 && this.f <= 24;
				if (flag13)
				{
					this.fraImgEff.drawFrame((this.f - 30) / 2, this.x, this.y, (int)this.Dir, 3, g);
				}
				int num2;
				for (int num5 = 0; num5 < this.VecSubEff.size(); num5 = num2 + 1)
				{
					Point point9 = (Point)this.VecSubEff.elementAt(num5);
					bool flag14 = point9.frame == 1;
					if (flag14)
					{
						this.fraImgSub3Eff.drawFrame(3 + point9.f % 3, point9.x, point9.y, 0, 3, g);
					}
					else
					{
						this.fraImgSub2Eff.drawFrame(point9.f % this.fraImgSub2Eff.nFrame, point9.x, point9.y, 0, 3, g);
					}
					num2 = num5;
				}
				for (int num6 = 0; num6 < this.VecEff.size(); num6 = num2 + 1)
				{
					Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(num6);
					this.fraImgSubEff.drawFrame(point_Focus.frame / 2, point_Focus.x, point_Focus.y, (int)this.Dir, 3, g);
					num2 = num6;
				}
				break;
			}
			case 7:
			case 141:
			{
				int num2;
				for (int num7 = 0; num7 < this.VecEff.size(); num7 = num2 + 1)
				{
					Point_Focus point_Focus2 = (Point_Focus)this.VecEff.elementAt(num7);
					base.paint_Bullet(g, this.fraImgEff, point_Focus2.frame, point_Focus2.x, point_Focus2.y, false, 0);
					num2 = num7;
				}
				break;
			}
			case 8:
			case 14:
			case 15:
			case 17:
			case 21:
			case 24:
			case 33:
			case 38:
			case 41:
			case 42:
			case 43:
			case 44:
			case 46:
			case 47:
			case 48:
			case 78:
			case 79:
			case 80:
			case 83:
			case 88:
			case 89:
			case 90:
			case 91:
			case 105:
			case 128:
			case 129:
			case 130:
			case 131:
			case 132:
			case 156:
			case 176:
			case 180:
			case 201:
			case 233:
			case 256:
			case 257:
			case 265:
			case 284:
			case 285:
			case 286:
			case 287:
			case 288:
			case 289:
			case 290:
			case 294:
			case 295:
			case 296:
			case 297:
			case 298:
			case 299:
			case 300:
			case 304:
			case 305:
			case 306:
			case 307:
			case 308:
			case 309:
			case 310:
			case 314:
			case 315:
			case 316:
			case 317:
			case 318:
			case 319:
			case 320:
			case 321:
			case 322:
			case 323:
			case 324:
			case 325:
			case 326:
			case 327:
			case 328:
			case 329:
			case 330:
			case 331:
			case 332:
			case 333:
			case 334:
			case 335:
			case 336:
			case 337:
			case 338:
			case 339:
			case 340:
			case 341:
			case 342:
			case 343:
			case 344:
			case 345:
			case 346:
			case 347:
			case 348:
			case 349:
			case 350:
			case 351:
			case 352:
			case 353:
			case 354:
			case 355:
			case 356:
			case 357:
			case 358:
			case 359:
			case 360:
			case 361:
			case 362:
			case 363:
			case 364:
			case 365:
			case 366:
			case 367:
			case 368:
			case 369:
			case 370:
			case 371:
			case 372:
			case 373:
			case 374:
			case 375:
			case 376:
			case 377:
			case 378:
			case 379:
			case 380:
			case 381:
			case 382:
			case 383:
			case 384:
			case 385:
			case 386:
			case 387:
			case 388:
			case 389:
			case 390:
			case 391:
			case 392:
			case 393:
			case 394:
			case 395:
			case 396:
			case 397:
			case 398:
			case 399:
			case 400:
			case 401:
				break;
			case 9:
			case 53:
			case 163:
			{
				bool flag15 = this.f < 3;
				if (flag15)
				{
					this.fraImgEff.drawFrame(this.f, this.x, this.y, (int)this.Dir, 3, g);
				}
				else
				{
					int num2;
					for (int num8 = 0; num8 < this.VecEff.size(); num8 = num2 + 1)
					{
						Point_Focus point_Focus3 = (Point_Focus)this.VecEff.elementAt(num8);
						this.fraImgSubEff.drawFrameNew(this.indexEff_1 * this.fraImgSubEff.maxNumFrame + point_Focus3.f % this.fraImgSubEff.maxNumFrame, point_Focus3.x, point_Focus3.y, 0, 3, g);
						bool flag16 = this.typeEffect != 9;
						if (flag16)
						{
							this.fraImgSub2Eff.drawFrame(CRes.random(this.fraImgSub2Eff.nFrame), point_Focus3.x, point_Focus3.y, 0, 3, g);
						}
						num2 = num8;
					}
				}
				break;
			}
			case 10:
			case 234:
			{
				bool flag17 = !this.checkNullObject(1);
				if (flag17)
				{
					bool flag18 = this.f >= 7;
					if (flag18)
					{
						this.fraImgEff.drawFrame((this.f - 7) / 2, this.objFireMain.x, this.objFireMain.y, (int)this.Dir, 33, g);
					}
					bool flag19 = this.f >= 7 && this.f <= 16;
					if (flag19)
					{
						this.fraImgSubEff.drawFrame((this.f - 11) / 2 % this.fraImgSubEff.nFrame, this.objFireMain.x, this.objFireMain.y - this.objFireMain.dy + 5, (int)this.Dir, 33, g);
					}
					bool flag20 = this.f >= 24 && this.f <= 29;
					if (flag20)
					{
						this.fraImgSubEff.drawFrame((2 - (this.f - 34)) / 2 % this.fraImgSubEff.nFrame, this.objFireMain.x, this.objFireMain.y - this.objFireMain.dy + 5, (int)this.Dir, 33, g);
					}
				}
				int num2;
				for (int num9 = 0; num9 < this.VecSubEff.size(); num9 = num2 + 1)
				{
					Point point10 = (Point)this.VecSubEff.elementAt(num9);
					bool flag21 = point10.frame == 1;
					if (flag21)
					{
						this.fraImgSub4Eff.drawFrame(3 + point10.f % 3, point10.x, point10.y, 0, 3, g);
					}
					else
					{
						this.fraImgSub3Eff.drawFrame(point10.f % this.fraImgSub3Eff.nFrame, point10.x, point10.y, 0, 3, g);
					}
					num2 = num9;
				}
				for (int num10 = 0; num10 < this.VecEff.size(); num10 = num2 + 1)
				{
					Point_Focus point_Focus4 = (Point_Focus)this.VecEff.elementAt(num10);
					this.fraImgSub2Eff.drawFrame(point_Focus4.f / 2 % this.fraImgSub2Eff.nFrame, point_Focus4.x, point_Focus4.y, (int)this.Dir, 3, g);
					num2 = num10;
				}
				break;
			}
			case 11:
			{
				bool flag22 = this.f > 3 && this.f < 12;
				if (flag22)
				{
					this.fraImgSub2Eff.drawFrameNew(this.indexEff_1 * this.fraImgSub2Eff.maxNumFrame + this.f % this.fraImgSub2Eff.maxNumFrame, this.xplus, this.yplus, (int)this.Dir, 3, g);
					this.fraImgSub3Eff.drawFrame(CRes.random(this.fraImgSub3Eff.nFrame), this.xplus, this.yplus, (int)this.Dir, 3, g);
					this.fraImgSubEff.drawFrame(this.f % this.fraImgSubEff.nFrame, this.x, this.y, 0, 33, g);
				}
				int num2;
				for (int num11 = 0; num11 < this.VecEff.size(); num11 = num2 + 1)
				{
					Point_Focus point_Focus5 = (Point_Focus)this.VecEff.elementAt(num11);
					this.fraImgEff.drawFrame(point_Focus5.f % this.fraImgEff.nFrame, point_Focus5.x, point_Focus5.y, 0, 33, g);
					num2 = num11;
				}
				break;
			}
			case 12:
			case 49:
			case 50:
			case 188:
			case 220:
			case 293:
				this.paintSanji_3(g);
				break;
			case 13:
			case 258:
			{
				bool flag23 = !this.checkNullObject(1);
				if (flag23)
				{
					bool flag24 = this.f >= 7 && this.f <= 12;
					if (flag24)
					{
						this.fraImgEff.drawFrame((this.f - 7) / 2, this.objFireMain.x, this.objFireMain.y, (int)this.Dir, 33, g);
					}
					bool flag25 = this.f >= 9 && this.f <= 11;
					if (flag25)
					{
						this.fraImgSubEff.drawFrame((this.f - 9) % this.fraImgSubEff.nFrame, this.objFireMain.x, this.objFireMain.y - this.objFireMain.dy + 5, (int)this.Dir, 33, g);
					}
					bool flag26 = this.f >= 18 && this.f <= 20;
					if (flag26)
					{
						this.fraImgSubEff.drawFrame((2 - (this.f - 18)) % this.fraImgSubEff.nFrame, this.objFireMain.x, this.objFireMain.y - this.objFireMain.dy + 5, (int)this.Dir, 33, g);
					}
				}
				int num2;
				for (int num12 = 0; num12 < this.VecEff.size(); num12 = num2 + 1)
				{
					Point_Focus point_Focus6 = (Point_Focus)this.VecEff.elementAt(num12);
					bool flag27 = this.typeEffect == 13;
					if (flag27)
					{
						this.fraImgSub2Eff.drawFrame(0, point_Focus6.x, point_Focus6.y, (int)this.Dir, 3, g);
					}
					else
					{
						bool flag28 = this.fraImgSub2Eff.getImageFrame() != null;
						if (flag28)
						{
							g.drawRegion(this.fraImgSub2Eff.getImageFrame(), 0, 0, this.fraImgSub2Eff.frameWidth, 62, 0, (float)point_Focus6.x, (float)point_Focus6.y, 33);
						}
					}
					num2 = num12;
				}
				for (int num13 = 0; num13 < this.VecSubEff.size(); num13 = num2 + 1)
				{
					Point point11 = (Point)this.VecSubEff.elementAt(num13);
					this.fraImgSub3Eff.drawFrame(point11.f % this.fraImgSub3Eff.nFrame, point11.x, point11.y, 0, 3, g);
					num2 = num13;
				}
				break;
			}
			case 16:
			case 51:
			{
				bool flag29 = this.f < this.fRemove;
				if (flag29)
				{
					this.fraImgSubEff.drawFrameNew(this.indexEff_1 * this.fraImgSubEff.maxNumFrame + this.f % this.fraImgSubEff.maxNumFrame, this.x, this.y, (int)this.Dir, 3, g);
					bool flag30 = this.fraImgEff != null;
					if (flag30)
					{
						this.fraImgEff.drawFrameNew(this.indexEff_1 * this.fraImgEff.maxNumFrame + CRes.random(this.fraImgEff.maxNumFrame), this.x, this.y, (int)this.Dir, 3, g);
					}
				}
				break;
			}
			case 18:
			{
				int num2;
				for (int num14 = 0; num14 < this.VecSubEff.size(); num14 = num2 + 1)
				{
					Point point12 = (Point)this.VecSubEff.elementAt(num14);
					this.fraImgSubEff.drawFrame(point12.f / 2 % this.fraImgSubEff.nFrame, point12.x, point12.y, (int)this.Dir, 3, g);
					num2 = num14;
				}
				for (int num15 = 0; num15 < this.VecEff.size(); num15 = num2 + 1)
				{
					Point_Focus point_Focus7 = (Point_Focus)this.VecEff.elementAt(num15);
					this.fraImgEff.drawFrame(0, point_Focus7.x, point_Focus7.y, this.frame, 3, g);
					num2 = num15;
				}
				break;
			}
			case 19:
			{
				bool flag31 = !this.checkNullObject(1) && this.f >= 1 && this.f <= 12;
				if (flag31)
				{
					this.fraImgEff.drawFrame(this.f / 2 % this.fraImgEff.nFrame, this.objFireMain.x, this.objFireMain.y, 0, 33, g);
				}
				break;
			}
			case 20:
			{
				bool flag32 = this.f >= 17 && this.f <= 24;
				if (flag32)
				{
					this.fraImgEff.drawFrame((this.f - 17) / 2, this.x, this.y, (int)this.Dir, 33, g);
				}
				break;
			}
			case 22:
			case 98:
			{
				bool flag33 = !this.checkNullObject(1);
				if (flag33)
				{
					bool flag34 = this.f < 5;
					if (flag34)
					{
						this.fraImgSubEff.drawFrame(this.f % this.fraImgSubEff.nFrame, this.objFireMain.x, this.objFireMain.y - this.objFireMain.dy, 0, 33, g);
					}
					bool flag35 = this.f >= 10 && this.f <= 14;
					if (flag35)
					{
						this.fraImgEff.drawFrame(this.f % this.fraImgEff.nFrame, this.objFireMain.x, this.objFireMain.y - this.objFireMain.dy, 0, 33, g);
					}
				}
				break;
			}
			case 23:
			{
				bool flag36 = this.f < this.fPlayFrameSuper;
				if (flag36)
				{
					this.fraImgEff.drawFrame(3, this.x, this.y, 0, 3, g);
				}
				break;
			}
			case 25:
			case 235:
				this.paintCrocodile1(g);
				break;
			case 26:
			case 236:
				this.paintCrocodile2(g);
				break;
			case 27:
			{
				bool flag37 = this.f % 4 < 2;
				if (flag37)
				{
					base.paint_Bullet(g, this.fraImgEff, this.frame, this.x, this.y, false, 0);
				}
				else
				{
					base.paint_Bullet(g, this.fraImgSubEff, this.frame, this.x, this.y, false, 0);
				}
				break;
			}
			case 28:
				this.fraImgEff.drawFrame(this.f / 2 % this.fraImgEff.nFrame, this.x, this.y, 0, 3, g);
				break;
			case 29:
				this.fraImgEff.drawFrame(this.f % this.fraImgEff.nFrame, this.objFireMain.x, this.objFireMain.y + 5, (int)this.Dir, 33, g);
				break;
			case 30:
			{
				bool flag38 = this.f < 3;
				if (flag38)
				{
					this.fraImgEff.drawFrame(this.f / (int)this.numNextFrame % this.fraImgEff.nFrame, this.x, this.y, (int)this.Dir, 3, g);
				}
				else
				{
					this.fraImgSubEff.drawFrame(0, this.x1000, this.y1000, (int)this.Dir, 3, g);
				}
				break;
			}
			case 31:
			case 55:
			case 56:
			case 191:
			case 223:
			case 313:
			{
				bool flag39 = this.f < this.fRemove;
				if (flag39)
				{
					this.fraImgSubEff.drawFrameNew(this.indexEff_1 * this.fraImgSubEff.maxNumFrame + this.f % this.fraImgSubEff.maxNumFrame, this.x, this.y, (int)this.Dir, 3, g);
					bool flag40 = this.fraImgSub2Eff != null;
					if (flag40)
					{
						this.fraImgSub2Eff.drawFrame(this.f % this.fraImgSubEff.nFrame, this.x, this.y, (int)this.Dir, 3, g);
					}
				}
				int num2;
				for (int num16 = 0; num16 < this.VecEff.size(); num16 = num2 + 1)
				{
					Point_Focus point_Focus8 = (Point_Focus)this.VecEff.elementAt(num16);
					this.fraImgEff.drawFrame(point_Focus8.f % this.fraImgEff.nFrame, point_Focus8.x, point_Focus8.y, (int)this.Dir, 3, g);
					bool flag41 = this.fraImgSub2Eff != null;
					if (flag41)
					{
						this.fraImgSub2Eff.drawFrame(point_Focus8.f % this.fraImgSub2Eff.nFrame, point_Focus8.x, point_Focus8.y, (int)this.Dir, 3, g);
					}
					num2 = num16;
				}
				break;
			}
			case 32:
			{
				int num2;
				for (int num17 = 0; num17 < this.VecEff.size(); num17 = num2 + 1)
				{
					Point point13 = (Point)this.VecEff.elementAt(num17);
					bool flag42 = point13.frame == 0;
					if (flag42)
					{
						this.fraImgEff.drawFrame(0, point13.x, point13.y, (int)this.Dir, 33, g);
					}
					else
					{
						this.fraImgSubEff.drawFrame(point13.f / 2 % this.fraImgSubEff.nFrame, point13.x, point13.y, (int)this.Dir, 33, g);
					}
					num2 = num17;
				}
				break;
			}
			case 34:
			{
				bool flag43 = this.f <= 1 && this.objFireMain != null;
				if (flag43)
				{
					bool flag44 = this.f == 0;
					if (flag44)
					{
						this.fraImgSubEff.drawFrame(this.f, this.x, this.y + this.objFireMain.hOne / 2, (int)this.Dir, 33, g);
					}
					else
					{
						this.fraImgSubEff.drawFrame(this.f, this.objFireMain.x, this.objFireMain.y, (int)this.Dir, 33, g);
					}
				}
				bool flag45 = this.f >= 7 && this.objFireMain != null;
				if (flag45)
				{
					int num18 = 16;
					bool flag46 = this.Dir == 0;
					if (flag46)
					{
						num18 = -16;
					}
					this.fraImgEff.drawFrame(2, this.objFireMain.x + num18, this.objFireMain.y - this.objFireMain.hOne / 2 + 2, (int)this.Dir, 3, g);
				}
				break;
			}
			case 35:
			{
				bool flag47 = this.f == 0 && this.objFireMain != null;
				if (flag47)
				{
					this.fraImgSubEff.drawFrame(0, this.x, this.y + this.objFireMain.hOne / 2, (int)this.Dir, 33, g);
				}
				bool flag48 = this.f >= 5 && this.objFireMain != null;
				if (flag48)
				{
					int num19 = 16;
					bool flag49 = this.Dir == 0;
					if (flag49)
					{
						num19 = -16;
					}
					this.fraImgEff.drawFrame(2, this.objFireMain.x + num19, this.objFireMain.y - this.objFireMain.hOne / 2 + 2, (int)this.Dir, 3, g);
				}
				int num2;
				for (int num20 = 0; num20 < this.VecEff.size(); num20 = num2 + 1)
				{
					Point point14 = (Point)this.VecEff.elementAt(num20);
					this.fraImgSubEff.drawFrame(point14.f / 2, point14.x, point14.y, (int)this.Dir, 33, g);
					num2 = num20;
				}
				break;
			}
			case 39:
			{
				int num2;
				for (int num21 = 0; num21 < this.VecEff.size(); num21 = num2 + 1)
				{
					Point_Focus point_Focus9 = (Point_Focus)this.VecEff.elementAt(num21);
					this.fraImgEff.drawFrame(2, point_Focus9.x, point_Focus9.y, (int)this.Dir, 33, g);
					num2 = num21;
				}
				break;
			}
			case 40:
			{
				bool flag50 = this.Dir == 0;
				if (flag50)
				{
					g.setColor(15956504);
					g.fillRect(this.x, this.y - 3, this.x1000 - this.x, 6);
					g.setColor(15985419);
					g.fillRect(this.x, this.y - 2, this.x1000 - this.x, 4);
					g.setColor(16777215);
					g.fillRect(this.x, this.y - 1, this.x1000 - this.x, 2);
				}
				else
				{
					g.setColor(15956504);
					g.fillRect(this.x1000, this.y - 3, this.x, 6);
					g.setColor(15985419);
					g.fillRect(this.x1000, this.y - 2, this.x, 4);
					g.setColor(16777215);
					g.fillRect(this.x1000, this.y - 1, this.x, 2);
				}
				break;
			}
			case 45:
			{
				int num2;
				for (int num22 = 0; num22 < this.VecEff.size(); num22 = num2 + 1)
				{
					Point_Focus point_Focus10 = (Point_Focus)this.VecEff.elementAt(num22);
					this.fraImgEff.drawFrame(1, point_Focus10.x, point_Focus10.y, point_Focus10.dis, 3, g);
					num2 = num22;
				}
				break;
			}
			case 52:
			case 189:
			case 221:
			case 311:
			{
				bool flag51 = this.f < this.fRemove;
				if (flag51)
				{
					this.fraImgSubEff.drawFrameNew(this.indexEff_1 * this.fraImgSubEff.maxNumFrame + this.f % this.fraImgSubEff.maxNumFrame, this.x, this.y, (int)this.Dir, 3, g);
					int num23 = 12 + CRes.random(this.fraImgEff.maxNumFrame);
					bool flag52 = (this.typeEffect == 221 || this.typeEffect == 311) && CRes.random(2) == 0;
					if (flag52)
					{
						num23 -= 4;
					}
					this.fraImgEff.drawFrameNew(num23, this.x, this.y, (int)this.Dir, 3, g);
				}
				int num2;
				for (int num24 = 0; num24 < this.VecEff.size(); num24 = num2 + 1)
				{
					Point point15 = (Point)this.VecEff.elementAt(num24);
					this.fraImgEff.drawFrameNew(12 - point15.frame * 4 + point15.f, point15.x, point15.y, (int)this.Dir, 3, g);
					num2 = num24;
				}
				break;
			}
			case 54:
			{
				int num2;
				for (int num25 = 0; num25 < this.VecEff.size(); num25 = num2 + 1)
				{
					Point_Focus point_Focus11 = (Point_Focus)this.VecEff.elementAt(num25);
					bool flag53 = point_Focus11.frame == 0;
					if (flag53)
					{
						this.fraImgEff.drawFrame(0, point_Focus11.x, point_Focus11.y, point_Focus11.dis, 3, g);
					}
					else
					{
						this.fraImgSub2Eff.drawFrame(point_Focus11.f / 2 % 3, point_Focus11.x, point_Focus11.y, point_Focus11.dis, 3, g);
					}
					num2 = num25;
				}
				for (int num26 = 0; num26 < this.VecSubEff.size(); num26 = num2 + 1)
				{
					Point point16 = (Point)this.VecSubEff.elementAt(num26);
					bool flag54 = point16.obj != null && !point16.obj.returnAction();
					if (flag54)
					{
						bool flag55 = point16.frame == 0;
						if (flag55)
						{
							this.fraImgEff.drawFrame(2, point16.obj.x, point16.obj.y - point16.obj.hOne / 2, point16.dis, 3, g);
						}
						else
						{
							bool flag56 = point16.frame == 1;
							if (flag56)
							{
								this.fraImgSubEff.drawFrame(point16.f / 2 % this.fraImgSubEff.nFrame, point16.obj.x, point16.obj.y - point16.obj.hOne / 2 + 5, point16.dis, 33, g);
							}
						}
					}
					num2 = num26;
				}
				break;
			}
			case 57:
			case 64:
			case 66:
			{
				bool flag57 = this.f < this.fPlayFrameSuper;
				if (flag57)
				{
					this.fraImgEff.drawFrame(0, this.x, this.y, 0, 3, g);
				}
				break;
			}
			case 58:
				this.fraImgEff.drawFrame(2, this.x, this.y, 0, 3, g);
				break;
			case 59:
			{
				bool flag58 = !this.checkNullObject(2);
				if (flag58)
				{
					bool flag59 = this.f < 6;
					if (flag59)
					{
						this.fraImgEff.drawFrame(this.f / 2, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2, 0, 3, g);
					}
					else
					{
						bool flag60 = this.f % 4 < 2;
						if (flag60)
						{
							this.fraImgEff.drawFrame(3, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2, 0, 3, g);
						}
					}
				}
				break;
			}
			case 60:
			{
				bool flag61 = !this.checkNullObject(2);
				if (flag61)
				{
					bool flag62 = this.f < 9;
					if (flag62)
					{
						this.fraImgEff.drawFrame(4 + this.f / 3, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2, 0, 3, g);
					}
					else
					{
						bool flag63 = this.f % 4 < 3;
						if (flag63)
						{
							this.fraImgEff.drawFrame(7, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2, 0, 3, g);
						}
					}
				}
				break;
			}
			case 62:
				this.fraImgEff.drawFrame(this.f / (int)this.numNextFrame % this.fraImgEff.nFrame, this.toX, this.toY, 0, 33, g);
				break;
			case 63:
			case 190:
			case 222:
			case 312:
			{
				bool flag64 = (this.f >= 20 && this.f < 23) || (this.f >= 10 && this.f < 13);
				if (flag64)
				{
					this.fraImgEff.drawFrame(this.f % 10, this.x, this.y, (int)this.Dir, 3, g);
				}
				bool flag65 = this.typeEffect == 222 || this.typeEffect == 312;
				int num2;
				if (flag65)
				{
					for (int num27 = 0; num27 < this.VecSubEff.size(); num27 = num2 + 1)
					{
						Point point17 = (Point)this.VecSubEff.elementAt(num27);
						this.fraImgSub3Eff.drawFrame(point17.f / 2, point17.x, point17.y, 0, 3, g);
						num2 = num27;
					}
				}
				for (int num28 = 0; num28 < this.VecEff.size(); num28 = num2 + 1)
				{
					Point_Focus point_Focus12 = (Point_Focus)this.VecEff.elementAt(num28);
					this.fraImgSubEff.drawFrameNew(this.indexEff_1 * this.fraImgSubEff.maxNumFrame + point_Focus12.f % this.fraImgSubEff.maxNumFrame, point_Focus12.x, point_Focus12.y, 0, 3, g);
					this.fraImgSub2Eff.drawFrame(CRes.random(this.fraImgSub2Eff.nFrame), point_Focus12.x, point_Focus12.y, 0, 3, g);
					num2 = num28;
				}
				break;
			}
			case 65:
			case 107:
			{
				bool flag66 = this.f < 4;
				if (flag66)
				{
					this.fraImgEff.drawFrame(this.f / 2, this.x, this.y, (int)this.Dir, 33, g);
				}
				break;
			}
			case 67:
			case 68:
			case 69:
			case 194:
			case 226:
			{
				bool flag67 = this.f >= 10 && this.f <= this.fRemove;
				if (flag67)
				{
					base.paint_Bullet(g, this.fraImgEff, this.frame, this.x, this.y, false, this.f % 2 * 3);
				}
				break;
			}
			case 70:
			{
				bool flag68 = this.f < 4;
				if (flag68)
				{
					this.fraImgEff.drawFrame(this.f / 2, this.x, this.y, (int)this.Dir, 33, g);
				}
				else
				{
					this.fraImgSubEff.drawFrame(this.f % this.fraImgSubEff.nFrame, this.x, this.y, (int)this.Dir, 33, g);
				}
				break;
			}
			case 72:
			case 92:
				this.fraImgEff.drawFrame(3, this.x, this.y, (int)this.Dir, 3, g);
				break;
			case 73:
			case 74:
			{
				bool flag69 = this.f < 2;
				if (flag69)
				{
					this.fraImgEff.drawFrame(0, this.x, this.y, (int)this.Dir, 3, g);
				}
				break;
			}
			case 75:
			{
				bool flag70 = this.f < 2;
				if (flag70)
				{
					this.fraImgSubEff.drawFrame(0, this.x1000, this.y1000, (int)this.Dir, 3, g);
				}
				this.fraImgEff.drawFrame(this.frame, this.x, this.y, (int)this.Dir, 3, g);
				break;
			}
			case 77:
			{
				int x = this.x;
				int num29 = this.y;
				bool flag71 = this.f > 7;
				if (flag71)
				{
					this.fraImgEff.drawFrame(0, x, num29, (int)this.Dir, 3, g);
					num29 += 15;
					this.fraImgSubEff.drawFrame(0, x, num29, (int)this.Dir, 3, g);
				}
				break;
			}
			case 82:
			case 144:
			{
				bool flag72 = this.f <= this.fRemove;
				if (flag72)
				{
					this.fraImgEff.drawFrame(this.f / (int)this.numNextFrame % this.fraImgEff.nFrame, this.x, this.y, (int)this.Dir, 3, g);
				}
				break;
			}
			case 84:
			case 181:
			case 213:
			case 272:
				this.paintLuffy_New2_SHORT(g);
				break;
			case 85:
			case 182:
			case 214:
			case 273:
				this.paintLuffy_New3(g);
				break;
			case 86:
			case 157:
			case 183:
			case 215:
			{
				int num2;
				for (int num30 = 0; num30 < this.VecEff.size(); num30 = num2 + 1)
				{
					Point_Focus point_Focus13 = (Point_Focus)this.VecEff.elementAt(num30);
					int num31 = point_Focus13.f * this.fraImgEff.frameHeight / 3 + this.fraImgEff.frameHeight / 3;
					bool flag73 = num31 > this.fraImgEff.frameHeight;
					if (flag73)
					{
						num31 = this.fraImgEff.frameHeight;
					}
					bool flag74 = this.fraImgEff.getImageFrame() != null;
					if (flag74)
					{
						g.drawRegion(this.fraImgEff.getImageFrame(), 0, this.fraImgEff.frameHeight - num31 + point_Focus13.f % this.fraImgEff.nFrame * this.fraImgEff.frameHeight, this.fraImgEff.frameWidth, num31, 0, (float)point_Focus13.x, (float)point_Focus13.y, 33);
					}
					num2 = num30;
				}
				break;
			}
			case 87:
			case 184:
			case 216:
			{
				bool flag75 = this.f > 12 && this.f < 15;
				if (flag75)
				{
					this.fraImgEff.drawFrame(this.f - 13, this.objFireMain.x, this.objFireMain.y - 10, (int)this.Dir, 33, g);
				}
				else
				{
					bool flag76 = this.f > 22 && this.f < 25;
					if (flag76)
					{
						this.fraImgEff.drawFrame(this.f - 23, this.objFireMain.x, this.objFireMain.y - 10, (int)this.Dir, 33, g);
					}
					else
					{
						bool flag77 = this.f > 28 && this.f < 31;
						if (flag77)
						{
							this.fraImgEff.drawFrame(this.f - 29, this.objFireMain.x, this.objFireMain.y - 10, (int)this.Dir, 33, g);
						}
						else
						{
							bool flag78 = this.f > 34 && this.f < 37;
							if (flag78)
							{
								this.fraImgEff.drawFrame(this.f - 35, this.objFireMain.x, this.objFireMain.y - 10, (int)this.Dir, 33, g);
							}
						}
					}
				}
				break;
			}
			case 93:
			{
				bool flag79 = this.f > 2 && this.f < 6;
				if (flag79)
				{
					this.fraImgEff.drawFrame(this.f - 3, this.objFireMain.x, this.objFireMain.y - 10, (int)this.Dir, 33, g);
				}
				bool flag80 = this.f > 8 && this.f < 12;
				if (flag80)
				{
					this.fraImgEff.drawFrame(11 - this.f, this.objFireMain.x, this.objFireMain.y - 10, (int)this.Dir, 33, g);
				}
				bool flag81 = this.f > 26 && this.f < 29;
				if (flag81)
				{
					this.fraImgEff.drawFrame(this.f - 27, this.objFireMain.x, this.objFireMain.y - 10, (int)this.Dir, 33, g);
				}
				break;
			}
			case 94:
			{
				bool flag82 = this.f <= 3;
				if (flag82)
				{
					this.fraImgEff.drawFrame(this.f / 2, this.x, this.y, (int)this.Dir, 33, g);
				}
				bool flag83 = this.f > 3 && this.f <= 7;
				if (flag83)
				{
					this.fraImgEff.drawFrame((this.f - 4) / 2, this.x, this.y, (this.Dir == 0) ? 2 : 0, 33, g);
				}
				break;
			}
			case 95:
			{
				bool flag84 = this.f < 2;
				if (flag84)
				{
					this.fraImgEff.drawFrame(this.f, this.x, this.y + 3, (int)this.Dir, 3, g);
				}
				int num2;
				for (int num32 = 0; num32 < this.VecEff.size(); num32 = num2 + 1)
				{
					Point_Focus point_Focus14 = (Point_Focus)this.VecEff.elementAt(num32);
					this.fraImgEff.drawFrame(point_Focus14.frame, point_Focus14.x, point_Focus14.y, (int)this.Dir, 3, g);
					num2 = num32;
				}
				break;
			}
			case 96:
				this.paintBuggy_2(g);
				break;
			case 97:
			{
				bool flag85 = this.f < 4;
				if (flag85)
				{
					this.fraImgSub2Eff.drawFrame(this.f, this.x, this.y, (int)this.Dir, 3, g);
				}
				int num2;
				for (int num33 = 0; num33 < this.VecEff.size(); num33 = num2 + 1)
				{
					Point_Focus point_Focus15 = (Point_Focus)this.VecEff.elementAt(num33);
					bool flag86 = point_Focus15.frame == 0;
					if (flag86)
					{
						this.fraImgEff.drawFrame(this.f % this.fraImgEff.nFrame, point_Focus15.x, point_Focus15.y, (int)this.Dir, 3, g);
					}
					else
					{
						this.fraImgSubEff.drawFrame(this.f % this.fraImgSubEff.nFrame, point_Focus15.x, point_Focus15.y, (int)this.Dir, 3, g);
					}
					num2 = num33;
				}
				break;
			}
			case 99:
			{
				int num34 = this.f % 4;
				bool flag87 = num34 < 4 && this.f < 8;
				if (flag87)
				{
					this.fraImgEff.drawFrame(num34, this.x, this.y - num34 * 2 + 5, (int)this.Dir, 3, g);
					int trans = 1;
					bool flag88 = this.Dir == 2;
					if (flag88)
					{
						trans = 3;
					}
					this.fraImgEff.drawFrame(num34, this.x, this.y - num34 * 2 - 15, trans, 3, g);
				}
				break;
			}
			case 100:
			{
				bool flag89 = this.f >= 5 && this.f <= 11;
				if (flag89)
				{
					this.fraImgEff.drawFrame(0, this.objFireMain.x, this.objFireMain.y, (int)this.Dir, 33, g);
				}
				break;
			}
			case 101:
			{
				bool flag90 = this.f >= 6 && this.f <= 15;
				if (flag90)
				{
					int num35 = (this.f - 2) % 4;
					this.fraImgEff.drawFrame(num35, this.objFireMain.x + this.x1000, this.objFireMain.y - this.objFireMain.hOne / 2 - num35 * 2 + 5, (int)this.Dir, 3, g);
					int trans2 = 1;
					bool flag91 = this.Dir == 2;
					if (flag91)
					{
						trans2 = 3;
					}
					this.fraImgEff.drawFrame(num35, this.objFireMain.x + this.x1000, this.objFireMain.y - this.objFireMain.hOne / 2 - num35 * 2 - 15, trans2, 3, g);
				}
				break;
			}
			case 102:
			{
				bool flag92 = this.f < 4;
				if (flag92)
				{
					this.fraImgSub2Eff.drawFrame(this.f, this.x, this.y, (int)this.Dir, 3, g);
				}
				int num2;
				for (int num36 = 0; num36 < this.VecEff.size(); num36 = num2 + 1)
				{
					Point_Focus point_Focus16 = (Point_Focus)this.VecEff.elementAt(num36);
					this.fraImgEff.drawFrame(point_Focus16.f % this.fraImgEff.nFrame, point_Focus16.x, point_Focus16.y, (int)this.Dir, 3, g);
					num2 = num36;
				}
				for (int num37 = 0; num37 < this.VecSubEff.size(); num37 = num2 + 1)
				{
					Point point18 = (Point)this.VecSubEff.elementAt(num37);
					this.fraImgSubEff.drawFrame((point18.f + point18.frame) % this.fraImgSubEff.nFrame, point18.x, point18.y, (int)this.Dir, 3, g);
					num2 = num37;
				}
				break;
			}
			case 103:
			{
				bool flag93 = this.f < 4;
				if (flag93)
				{
					this.fraImgSubEff.drawFrame(0, this.x, this.y, (int)this.Dir, 33, g);
				}
				int num2;
				for (int num38 = 0; num38 < this.VecEff.size(); num38 = num2 + 1)
				{
					Point point19 = (Point)this.VecEff.elementAt(num38);
					int trans3 = (int)this.Dir;
					bool flag94 = point19.frame == 2;
					if (flag94)
					{
						trans3 = 5;
					}
					this.fraImgEff.drawFrame(point19.frame, point19.x, point19.y, trans3, 3, g);
					num2 = num38;
				}
				break;
			}
			case 104:
			{
				bool flag95 = this.f < 8 && this.f % 2 == 1;
				if (flag95)
				{
					this.fraImgSubEff.drawFrame(0, this.x, this.y, (int)this.Dir, 33, g);
				}
				int num2;
				for (int num39 = 0; num39 < this.VecEff.size(); num39 = num2 + 1)
				{
					Point point20 = (Point)this.VecEff.elementAt(num39);
					bool flag96 = point20.frame == 4;
					if (flag96)
					{
						this.fraImgSubEff.drawFrame(0, point20.x, point20.y, (int)this.Dir, 33, g);
					}
					else
					{
						int trans4 = point20.dis;
						int idx3 = point20.frame;
						bool flag97 = point20.frame == 2;
						if (flag97)
						{
							trans4 = 5;
						}
						else
						{
							bool flag98 = point20.frame == 3;
							if (flag98)
							{
								idx3 = 2;
							}
						}
						this.fraImgEff.drawFrame(idx3, point20.x, point20.y, trans4, 3, g);
					}
					num2 = num39;
				}
				break;
			}
			case 106:
			{
				bool flag99 = this.f < 10 || this.f % 4 > 1;
				int num2;
				if (flag99)
				{
					for (int num40 = 0; num40 < this.VecEff.size(); num40 = num2 + 1)
					{
						Point point21 = (Point)this.VecEff.elementAt(num40);
						this.fraImgEff.drawFrame((this.f / 2 + point21.frame) % 3, point21.x, point21.y, (int)this.Dir, 3, g);
						num2 = num40;
					}
				}
				for (int num41 = 0; num41 < this.VecSubEff.size(); num41 = num2 + 1)
				{
					Point_Focus point_Focus17 = (Point_Focus)this.VecSubEff.elementAt(num41);
					this.fraImgEff.drawFrame((this.f + point_Focus17.frame) % 3, point_Focus17.x, point_Focus17.y - 4, (int)this.Dir, 3, g);
					bool flag100 = point_Focus17.f % 2 == 0;
					if (flag100)
					{
						this.fraImgSubEff.drawFrame(0, point_Focus17.x, point_Focus17.y + 4, (int)this.Dir, 3, g);
					}
					num2 = num41;
				}
				break;
			}
			case 108:
			{
				int num2;
				for (int num42 = 0; num42 < this.VecEff.size(); num42 = num2 + 1)
				{
					Point point22 = (Point)this.VecEff.elementAt(num42);
					this.fraImgEff.drawFrame((point22.frame + this.f / point22.dis) % this.fraImgEff.nFrame, point22.x, point22.y, (int)this.Dir, 3, g);
					num2 = num42;
				}
				break;
			}
			case 109:
				this.paintDonKrieg_1(g);
				break;
			case 110:
				this.paintDonKrieg_2(g);
				break;
			case 111:
				this.paintDonKrieg_3(g);
				break;
			case 112:
			case 270:
				this.fraImgEff.drawFrame(this.f / (int)this.numNextFrame % this.fraImgEff.nFrame, this.x, this.y, (int)this.Dir, 3, g);
				break;
			case 113:
			case 150:
			{
				int num2;
				for (int num43 = 0; num43 < this.VecEff.size(); num43 = num2 + 1)
				{
					Point_Focus point_Focus18 = (Point_Focus)this.VecEff.elementAt(num43);
					this.fraImgEff.drawFrame(this.f % this.fraImgEff.nFrame, point_Focus18.x, point_Focus18.y, (int)this.Dir, 3, g);
					num2 = num43;
				}
				break;
			}
			case 114:
			case 115:
			{
				int num2;
				for (int num44 = 0; num44 < this.VecEff.size(); num44 = num2 + 1)
				{
					Point_Focus point_Focus19 = (Point_Focus)this.VecEff.elementAt(num44);
					this.fraImgEff.drawFrame(4, point_Focus19.x, point_Focus19.y, (int)this.Dir, 3, g);
					num2 = num44;
				}
				break;
			}
			case 116:
			{
				bool flag101 = this.f >= 11 && this.f <= 16;
				if (flag101)
				{
					this.fraImgEff.drawFrame((this.f - 11) / 3, this.x + this.x1000, this.y, (int)this.Dir, 3, g);
				}
				else
				{
					bool flag102 = this.f >= 26 && this.f <= 31;
					if (flag102)
					{
						this.fraImgEff.drawFrame((this.f - 26) / 3, this.x + this.x1000, this.y, (int)this.Dir, 3, g);
					}
				}
				break;
			}
			case 117:
				this.paintKurobi_2(g);
				break;
			case 118:
			{
				bool flag103 = this.vecObjsBeFire.size() > 1;
				if (flag103)
				{
					int num2;
					for (int num45 = 0; num45 < this.VecEff.size(); num45 = num2 + 1)
					{
						Point point23 = (Point)this.VecEff.elementAt(num45);
						this.fraImgEff.drawFrame(point23.f / 2, point23.x, point23.y, point23.dis, 3, g);
						num2 = num45;
					}
				}
				else
				{
					this.fraImgEff.drawFrame(this.f / 2, this.x, this.y, (int)this.Dir, 3, g);
				}
				break;
			}
			case 119:
			{
				int num2;
				for (int num46 = 0; num46 < this.VecEff.size(); num46 = num2 + 1)
				{
					Point_Focus point_Focus20 = (Point_Focus)this.VecEff.elementAt(num46);
					this.fraImgEff.drawFrame(0, point_Focus20.x, point_Focus20.y, point_Focus20.dis, 3, g);
					this.fraImgSubEff.drawFrame(0, point_Focus20.x, point_Focus20.y + 30, point_Focus20.dis, 3, g);
					bool flag104 = this.f % 2 == 0;
					if (flag104)
					{
						bool flag105 = point_Focus20.dis == 0;
						if (flag105)
						{
							this.fraImgSub2Eff.drawFrame(CRes.random(2), point_Focus20.x - 25, point_Focus20.y, 0, 3, g);
						}
						else
						{
							bool flag106 = point_Focus20.dis == 2;
							if (flag106)
							{
								this.fraImgSub2Eff.drawFrame(CRes.random(2), point_Focus20.x + 25, point_Focus20.y, 2, 3, g);
							}
						}
					}
					num2 = num46;
				}
				break;
			}
			case 120:
			{
				bool flag107 = this.f <= 9;
				if (flag107)
				{
					this.fraImgSubEff.drawFrame(0, this.x + this.plusxy[2][0], this.y + this.plusxy[2][1], (int)this.Dir, 3, g);
				}
				else
				{
					bool flag108 = this.f >= 10 && this.f <= 11;
					if (flag108)
					{
						this.fraImgEff.drawFrame(0, this.x + this.plusxy[0][0], this.y + this.plusxy[0][1], (int)this.Dir, 3, g);
						this.fraImgSubEff.drawFrame(1, this.x + this.plusxy[3][0], this.y + this.plusxy[3][1], (int)this.Dir, 3, g);
					}
					else
					{
						bool flag109 = this.f >= 12 && this.f <= 13;
						if (flag109)
						{
							this.fraImgEff.drawFrame(1, this.x + this.plusxy[1][0], this.y + this.plusxy[1][1], (int)this.Dir, 3, g);
							this.fraImgSubEff.drawFrame(2, this.x + this.plusxy[4][0], this.y + this.plusxy[4][1], (int)this.Dir, 3, g);
						}
					}
				}
				int num2;
				for (int num47 = 0; num47 < this.VecEff.size(); num47 = num2 + 1)
				{
					Point point24 = (Point)this.VecEff.elementAt(num47);
					this.fraImgSub2Eff.drawFrame(point24.frame, point24.x, point24.y, (int)this.Dir, 33, g);
					num2 = num47;
				}
				break;
			}
			case 121:
			{
				bool flag110 = this.f >= 13;
				if (flag110)
				{
					this.fraImgEff.drawFrame(this.f / 2 % this.fraImgEff.nFrame, this.x, this.y, (int)this.Dir, 3, g);
				}
				break;
			}
			case 122:
			{
				bool flag111 = this.f >= 16;
				if (flag111)
				{
					this.fraImgEff.drawFrame(this.f / 2 % this.fraImgEff.nFrame, this.x, this.y, (int)this.Dir, 3, g);
					this.fraImgSubEff.drawFrame(this.f / 2 % 2, this.x1000, this.y1000, (int)this.Dir, 0, g);
				}
				int num2;
				for (int num48 = 0; num48 < this.VecEff.size(); num48 = num2 + 1)
				{
					Point_Focus point_Focus21 = (Point_Focus)this.VecEff.elementAt(num48);
					this.fraImgSub2Eff.drawFrame(point_Focus21.f % this.fraImgSub2Eff.nFrame, point_Focus21.x, point_Focus21.y, (int)this.Dir, 33, g);
					num2 = num48;
				}
				break;
			}
			case 123:
			case 185:
			case 217:
			case 283:
			{
				bool flag112 = (this.f >= 9 && this.f <= 11) || (this.f >= 24 && this.f <= 26);
				if (flag112)
				{
					this.fraImgSub4Eff.drawFrame(0, this.objFireMain.x, this.objFireMain.y, (int)this.Dir, 33, g);
				}
				bool flag113 = this.f <= 11 || this.f >= 26;
				if (flag113)
				{
					bool flag114 = this.typeEffect == 185 || this.typeEffect == 217 || this.typeEffect == 283;
					if (flag114)
					{
						int num49 = this.f / 2 % this.fraImgEff.nFrame;
						bool flag115 = this.typeEffect == 217 || this.typeEffect == 283;
						if (flag115)
						{
							num49 += 2;
						}
						this.fraImgEff.drawFrameNew(num49, this.x + this.am_duong * 5, this.y, (int)this.Dir, 3, g);
					}
					else
					{
						this.fraImgEff.drawFrame(this.f / 2 % this.fraImgEff.nFrame, this.x, this.y, (int)this.Dir, 3, g);
					}
					this.fraImgSubEff.drawFrame(this.f / 2 % 2, this.x1000, this.y1000, (int)this.Dir, 0, g);
				}
				bool flag116 = this.typeEffect == 283;
				if (flag116)
				{
					int num2;
					for (int num50 = 0; num50 < this.VecEff.size(); num50 = num2 + 1)
					{
						Point_Focus point_Focus22 = (Point_Focus)this.VecEff.elementAt(num50);
						this.fraImgSub2Eff.drawFrame(point_Focus22.f % this.fraImgSub2Eff.nFrame, point_Focus22.x, point_Focus22.y, (int)this.Dir, 33, g);
						num2 = num50;
					}
				}
				else
				{
					int num2;
					for (int num51 = 0; num51 < this.VecEff.size(); num51 = num2 + 1)
					{
						Point point25 = (Point)this.VecEff.elementAt(num51);
						bool flag117 = point25.f >= 3 && (point25.f - 3) / 2 < 3;
						if (flag117)
						{
							this.fraImgSub2Eff.drawFrame((point25.f - 3) / 2, point25.x, point25.y, (int)this.Dir, 3, g);
						}
						bool flag118 = point25.f / 2 < 3;
						if (flag118)
						{
							this.fraImgSub3Eff.drawFrame(point25.f / 2, point25.x, point25.y, (int)this.Dir, 3, g);
						}
						num2 = num51;
					}
				}
				break;
			}
			case 124:
			case 186:
			case 218:
			{
				bool flag119 = this.f >= 0 && this.f <= 5;
				if (flag119)
				{
					this.fraImgEff.drawFrame(0, this.objFireMain.x, this.objFireMain.y - this.objFireMain.dy, (int)this.Dir, 33, g);
				}
				break;
			}
			case 125:
			case 162:
			case 187:
			{
				bool isTanHinh = this.objFireMain.isTanHinh;
				if (isTanHinh)
				{
					this.fraImgEff.drawFrame(0, this.objFireMain.x, this.objFireMain.y - this.objFireMain.dy, (int)this.Dir, 33, g);
				}
				break;
			}
			case 126:
			case 159:
			case 192:
			{
				int num2;
				for (int num52 = 0; num52 < this.VecEff.size(); num52 = num2 + 1)
				{
					this.fraImgEff.drawFrame(2, this.x, this.y, 0, 3, g);
					num2 = num52;
				}
				bool isTanHinh2 = this.objFireMain.isTanHinh;
				if (isTanHinh2)
				{
					this.fraImgSubEff.drawFrame(0, this.objFireMain.x, this.objFireMain.y - this.objFireMain.dy, (int)this.Dir, 33, g);
				}
				break;
			}
			case 127:
			case 193:
			case 225:
			case 302:
			{
				bool flag120 = this.typeEffect == 302 && this.f > 2 && this.f < 15;
				if (flag120)
				{
					Point_Focus point_Focus23 = (Point_Focus)this.VecEff.elementAt(0);
					this.fraImgSub3Eff.drawFrame((this.f / 3 >= this.fraImgSub3Eff.nFrame) ? (this.fraImgSub3Eff.nFrame - 1) : (this.f / 3), point_Focus23.x, point_Focus23.y, (int)(this.Dir ^ 2), 3, g);
				}
				bool flag121 = this.f >= 7 && this.f <= 15;
				if (flag121)
				{
					this.fraImgEff.drawFrame(this.f / 2 % this.fraImgEff.nFrame, this.objFireMain.x + this.am_duong * 40, this.objFireMain.y - this.objFireMain.hOne / 2 - 10, (int)this.Dir, 3, g);
				}
				bool flag122 = this.f >= 15;
				if (flag122)
				{
					this.fraImgSub2Eff.drawFrame(0, this.x, this.y + 50, (int)this.Dir, 3, g);
					this.fraImgSubEff.drawFrame(this.mframe[this.f / 2 % this.mframe.Length], this.x, this.y, (int)this.Dir, 3, g);
				}
				break;
			}
			case 133:
			{
				int num2;
				for (int num53 = 0; num53 < this.VecEff.size(); num53 = num2 + 1)
				{
					Point_Focus point_Focus24 = (Point_Focus)this.VecEff.elementAt(num53);
					this.fraImgEff.drawFrame((point_Focus24.frame + point_Focus24.f / 2) % this.fraImgEff.nFrame, point_Focus24.x + CRes.random_Am_0(3), point_Focus24.y + CRes.random_Am_0(3), point_Focus24.dis, 3, g);
					num2 = num53;
				}
				bool flag123 = this.f >= 2 && this.f <= 4;
				if (flag123)
				{
					this.fraImgSubEff.drawFrame(this.f - 7, this.x + this.am_duong * 17, this.y, (this.Dir != 2) ? 2 : 0, 3, g);
				}
				bool flag124 = this.f >= 10 && this.f <= 12;
				if (flag124)
				{
					this.fraImgSubEff.drawFrame(this.f - 15, this.x + this.am_duong * 17, this.y, (this.Dir != 2) ? 2 : 0, 3, g);
				}
				break;
			}
			case 134:
			case 135:
			{
				bool flag125 = this.fraImgSub3Eff != null;
				int num2;
				if (flag125)
				{
					for (int num54 = 0; num54 < this.VecSubEff.size(); num54 = num2 + 1)
					{
						Point point26 = (Point)this.VecSubEff.elementAt(num54);
						this.fraImgSub3Eff.drawFrame(1 + point26.f / 2, point26.x, point26.y, 0, 3, g);
						num2 = num54;
					}
				}
				for (int num55 = 0; num55 < this.VecEff.size(); num55 = num2 + 1)
				{
					Point_Focus point_Focus25 = (Point_Focus)this.VecEff.elementAt(num55);
					bool flag126 = point_Focus25.maxdis == 1;
					if (flag126)
					{
						this.fraImgSub2Eff.drawFrameNew(point_Focus25.frame % this.fraImgSub2Eff.nFrame, point_Focus25.x + CRes.random_Am_0(5), point_Focus25.y + CRes.random_Am_0(5), point_Focus25.dis, 3, g);
					}
					else
					{
						this.fraImgEff.drawFrame((point_Focus25.frame + point_Focus25.f / 2) % this.fraImgEff.nFrame, point_Focus25.x + CRes.random_Am_0(5), point_Focus25.y + CRes.random_Am_0(5), point_Focus25.dis, 3, g);
					}
					num2 = num55;
				}
				bool flag127 = this.f >= 2 && this.f <= 4;
				if (flag127)
				{
					this.fraImgSubEff.drawFrame(this.f - 7, this.x + this.am_duong * 17, this.y, (this.Dir != 2) ? 2 : 0, 3, g);
				}
				bool flag128 = this.f >= 5 && this.f <= 7;
				if (flag128)
				{
					this.fraImgSubEff.drawFrame(this.f - 15, this.x + this.am_duong * 17, this.y, (this.Dir != 2) ? 2 : 0, 3, g);
				}
				bool flag129 = !this.checkNullObject(1) && this.f >= 10 && this.f <= 13;
				if (flag129)
				{
					this.fraImgSubEff.drawFrame(this.f - 15, this.x + this.am_duong * 17, this.y - this.objFireMain.dy, (this.Dir != 2) ? 2 : 0, 3, g);
				}
				break;
			}
			case 136:
			{
				bool flag130 = this.f == 4 || this.f == 10 || this.f == 14;
				if (flag130)
				{
					this.fraImgSubEff.drawFrame(0, this.objFireMain.x, this.objFireMain.y, (int)this.Dir, 33, g);
				}
				bool flag131 = this.f == 1 || this.f == 3 || this.f == 11 || this.f == 13;
				if (flag131)
				{
					this.fraImgEff.drawFrame(0, this.objFireMain.x, this.objFireMain.y, 0, 33, g);
				}
				break;
			}
			case 137:
			case 138:
			{
				bool flag132 = this.f == 2 || this.f == 13 || this.f == 18;
				if (flag132)
				{
					this.fraImgSubEff.drawFrame(0, this.objFireMain.x, this.objFireMain.y, (int)this.Dir, 33, g);
				}
				bool flag133 = this.f == 3 || this.f == 12 || this.f == 19;
				if (flag133)
				{
					this.fraImgEff.drawFrame(0, this.objFireMain.x, this.objFireMain.y, 0, 33, g);
				}
				break;
			}
			case 139:
			{
				bool flag134 = this.f > 2 && this.f < 16;
				if (flag134)
				{
					this.fraImgSub2Eff.drawFrameNew(this.indexEff_1 * this.fraImgSub2Eff.maxNumFrame + this.f % this.fraImgSub2Eff.maxNumFrame, this.xplus, this.yplus, (int)this.Dir, 3, g);
					this.fraImgSub3Eff.drawFrame(CRes.random(this.fraImgSub3Eff.nFrame), this.xplus, this.yplus, (int)this.Dir, 3, g);
					this.fraImgSubEff.drawFrame(this.f % this.fraImgSubEff.nFrame, this.x, this.y, 0, 33, g);
				}
				int num2;
				for (int num56 = 0; num56 < this.VecEff.size(); num56 = num2 + 1)
				{
					Point_Focus point_Focus26 = (Point_Focus)this.VecEff.elementAt(num56);
					this.fraImgEff.drawFrame(point_Focus26.f % this.fraImgEff.nFrame, point_Focus26.x, point_Focus26.y, 0, 33, g);
					this.fraImgSub3Eff.drawFrame(CRes.random(this.fraImgSub3Eff.nFrame), point_Focus26.x + CRes.random_Am_0(10), point_Focus26.y - CRes.random(10), 0, 33, g);
					num2 = num56;
				}
				break;
			}
			case 140:
			{
				bool flag135 = this.f > 2 && this.f < 18;
				if (flag135)
				{
					this.fraImgSub2Eff.drawFrameNew(this.indexEff_1 * this.fraImgSub2Eff.maxNumFrame + this.f % this.fraImgSub2Eff.maxNumFrame, this.xplus, this.yplus, (int)this.Dir, 3, g);
					this.fraImgSub3Eff.drawFrame(CRes.random(this.fraImgSub3Eff.nFrame), this.xplus, this.yplus, (int)this.Dir, 3, g);
				}
				int num2;
				for (int num57 = 0; num57 < this.VecEff.size(); num57 = num2 + 1)
				{
					Point_Focus point_Focus27 = (Point_Focus)this.VecEff.elementAt(num57);
					this.mImgframe[2].drawFrame(point_Focus27.f % this.mImgframe[2].nFrame, point_Focus27.x, point_Focus27.y, 0, 3, g);
					num2 = num57;
				}
				bool flag136 = this.f >= 32 && this.f <= 36 && !this.checkNullObject(2) && CRes.random(4) != 0;
				if (flag136)
				{
					int num58 = CRes.random(1, 5);
					for (int num59 = 0; num59 < num58; num59 = num2 + 1)
					{
						int x2 = CRes.random_Am(0, 25) + this.objBeFireMain.x;
						this.mImgframe[1].drawFrame(CRes.random(this.mImgframe[1].nFrame), x2, this.objBeFireMain.y - 70, 0, 0, g);
						num2 = num59;
					}
				}
				bool flag137 = this.f >= 20 && this.f <= 38;
				if (flag137)
				{
					bool flag138 = this.f < 24 || this.f >= 36;
					if (flag138)
					{
						this.mImgframe[0].drawFrame(0, this.objBeFireMain.x, this.objBeFireMain.y - 60, 0, 33, g);
					}
					else
					{
						bool flag139 = this.f < 28;
						if (flag139)
						{
							this.mImgframe[0].drawFrame(1, this.objBeFireMain.x, this.objBeFireMain.y - 60, 0, 33, g);
						}
						else
						{
							bool flag140 = this.f < 36;
							if (flag140)
							{
								this.mImgframe[0].drawFrame(2, this.objBeFireMain.x, this.objBeFireMain.y - 60, 0, 33, g);
							}
						}
					}
				}
				break;
			}
			case 142:
			{
				int num2;
				for (int num60 = 0; num60 < this.VecEff.size(); num60 = num2 + 1)
				{
					Point_Focus point_Focus28 = (Point_Focus)this.VecEff.elementAt(num60);
					this.fraImgEff.drawFrame((point_Focus28.frame + this.f) % this.fraImgEff.nFrame, point_Focus28.x / 10, point_Focus28.y / 10, point_Focus28.dis, 3, g);
					num2 = num60;
				}
				break;
			}
			case 147:
				this.fraImgEff.drawFrame(5, this.x, this.y, (int)this.Dir, 3, g);
				break;
			case 149:
			{
				int num61 = this.f;
				bool flag141 = num61 > 2;
				if (flag141)
				{
					num61 = 2;
				}
				this.fraImgEff.drawFrame(num61, this.x, this.y, (int)this.Dir, 3, g);
				break;
			}
			case 151:
			case 152:
			case 153:
			{
				int num2;
				for (int num62 = 0; num62 < this.VecEff.size(); num62 = num2 + 1)
				{
					Point_Focus point_Focus29 = (Point_Focus)this.VecEff.elementAt(num62);
					this.fraImgEff.drawFrame(this.frame * 3 + this.f / 2 % 2, point_Focus29.x, point_Focus29.y, (int)this.Dir, 3, g);
					num2 = num62;
				}
				break;
			}
			case 154:
				this.fraImgEff.drawFrame(this.f % this.fraImgEff.nFrame, this.x, this.y, (int)this.Dir, 3, g);
				break;
			case 155:
			{
				bool flag142 = this.f < 2 || this.f > 5;
				if (flag142)
				{
					this.fraImgEff.drawFrame(this.f % this.fraImgEff.nFrame, this.x + this.xplus, this.y, (int)this.Dir, 3, g);
				}
				bool flag143 = this.f < 6 && this.f > 1;
				if (flag143)
				{
					this.fraImgSubEff.drawFrame((this.f + ((this.f > 3) ? 1 : 0)) % 2, this.x + this.xplus, this.y, 0, 3, g);
				}
				break;
			}
			case 158:
			case 177:
			{
				bool flag144 = this.f >= 20 && this.f <= 25;
				if (flag144)
				{
					this.fraImgEff.drawFrame(0, this.objFireMain.x, this.objFireMain.y - this.objFireMain.dy, (int)this.Dir, 33, g);
				}
				break;
			}
			case 160:
				this.paintLuffy_New2(g);
				break;
			case 161:
				this.paintZoroS2_L3_SHORT(g);
				break;
			case 164:
			case 227:
			{
				int num2;
				for (int num63 = 0; num63 < this.VecEff.size(); num63 = num2 + 1)
				{
					Point point27 = (Point)this.VecEff.elementAt(num63);
					bool flag145 = point27.dis == 0;
					if (flag145)
					{
						this.fraImgEff.drawFrame(point27.frame, point27.x, point27.y, (int)this.Dir, 3, g);
					}
					else
					{
						this.fraImgSubEff.drawFrame(point27.frame, point27.x, point27.y, (int)this.Dir, 3, g);
					}
					num2 = num63;
				}
				break;
			}
			case 165:
			case 166:
			{
				int num64 = this.f / 2 % 6;
				bool flag146 = num64 < 2;
				if (flag146)
				{
					this.fraImgEff.drawFrame(num64, this.x, this.y, (int)this.Dir, 33, g);
				}
				break;
			}
			case 167:
			{
				int num2;
				for (int num65 = 0; num65 < this.VecSubEff.size(); num65 = num2 + 1)
				{
					Point point28 = (Point)this.VecSubEff.elementAt(num65);
					this.fraImgSub2Eff.drawFrame(point28.frame, point28.x, point28.y, 0, 33, g);
					num2 = num65;
				}
				for (int num66 = 0; num66 < this.VecEff.size(); num66 = num2 + 1)
				{
					Point point29 = (Point)this.VecEff.elementAt(num66);
					this.fraImgSub3Eff.drawFrameNew(point29.f / 3, point29.x, point29.y, 0, 33, g);
					num2 = num66;
				}
				bool flag147 = this.f >= 4 && this.f <= 5;
				if (flag147)
				{
					g.drawRegion(this.fraImgSub4Eff.getImageFrame(), 0, 0, this.fraImgSub4Eff.frameWidth, this.fraImgSub4Eff.frameHeight / (this.f - 3), 0, (float)this.x1000, (float)this.y1000, 33);
				}
				bool flag148 = this.f > 4;
				if (flag148)
				{
					bool flag149 = this.f > this.fRemove - 4;
					if (flag149)
					{
						this.fraImgSub2Eff.drawFrame(this.fRemove - this.f, this.x1000, this.y1000, 0, 33, g);
					}
					else
					{
						this.fraImgSub2Eff.drawFrame(3, this.x1000, this.y1000, 0, 33, g);
					}
				}
				bool flag150 = this.f < 8;
				if (flag150)
				{
					this.fraImgSubEff.drawFrame(this.f / 2, this.x1000, this.y1000, 0, 33, g);
				}
				break;
			}
			case 168:
			{
				bool flag151 = this.f < 12;
				if (flag151)
				{
					int num67 = this.Mr1[this.f / 2][1];
					int num68 = this.Mr1[this.f / 2][2];
					int trans5 = 0;
					bool flag152 = !this.checkNullObject(1) && this.objFireMain.Dir == 2;
					if (flag152)
					{
						trans5 = 2;
						num67 = -this.Mr1[this.f / 2][1];
					}
					this.fraImgEff.drawFrameNew(this.f / 2 % this.fraImgEff.nFrame, this.x + num67, this.y + num68, trans5, 3, g);
				}
				break;
			}
			case 169:
			case 237:
			{
				bool flag153 = this.f <= 20 && !this.checkNullObject(1);
				if (flag153)
				{
					this.fraImgSub4Eff.drawFrame(CRes.random(this.fraImgSub4Eff.nFrame), this.objFireMain.x, this.objFireMain.y - this.objFireMain.hOne / 2 + 3, 0, 3, g);
				}
				int num2;
				for (int num69 = 0; num69 < this.VecSubEff.size(); num69 = num2 + 1)
				{
					bool flag154 = num69 % 2 == 1;
					if (flag154)
					{
						Point point30 = (Point)this.VecSubEff.elementAt(num69);
						this.fraImgSubEff.drawFrameNew(point30.frame * this.fraImgSubEff.maxNumFrame + GameCanvas.gameTick / 2 % this.fraImgSubEff.maxNumFrame, point30.x / 10, point30.y / 10, 0, 3, g);
						for (int num70 = 0; num70 < 4; num70 = num2 + 1)
						{
							this.fraImgEff.drawFrameNew(point30.frame * this.fraImgEff.maxNumFrame, point30.x / 10, point30.y / 10 - num70 * 73, (CRes.random(2) != 0) ? 2 : 0, 33, g);
							num2 = num70;
						}
					}
					num2 = num69;
				}
				bool flag155 = this.f > 16;
				if (flag155)
				{
					int num71 = -4;
					int num72 = GameCanvas.gameTick % 2 * 2;
					bool flag156 = this.y1000 == 0;
					if (flag156)
					{
						this.fraImgSub3Eff.drawFrameNew(GameCanvas.gameTick / 3 % this.fraImgSub3Eff.nFrame, this.x, this.y + 7, 0, 3, g);
					}
					g.setColor(407521);
					g.fillRect(this.x - 20 - num71, this.y - 350 - this.y1000, 40 + num71 * 2, 360);
					g.setColor(31983);
					g.fillRect(this.x - 18 - num71, this.y - 350 - this.y1000, 36 + num71 * 2, 360);
					g.setColor(11661052);
					g.fillRect(this.x - 16 - num71, this.y - 350 - this.y1000, 32 + num71 * 2, 360);
					g.setColor(31983);
					g.fillRect(this.x - 14 - num71 + num72, this.y - 350 - this.y1000, 28 + num71 * 2 - num72 * 2, 360);
					g.setColor(11661052);
					g.fillRect(this.x - 12 - num71 + num72, this.y - 350 - this.y1000, 24 + num71 * 2 - num72 * 2, 360);
					g.setColor(16514814);
					g.fillRect(this.x - 10 - num71 + num72, this.y - 350 - this.y1000, 20 + num71 * 2 - num72 * 2, 360);
				}
				for (int num73 = 0; num73 < this.VecEff.size(); num73 = num2 + 1)
				{
					Point point31 = (Point)this.VecEff.elementAt(num73);
					this.fraImgSub2Eff.drawFrame(point31.f / 2, point31.x, point31.y, 0, 3, g);
					num2 = num73;
				}
				for (int num74 = 0; num74 < this.VecSubEff.size(); num74 = num2 + 1)
				{
					bool flag157 = num74 % 2 == 0;
					if (flag157)
					{
						Point point32 = (Point)this.VecSubEff.elementAt(num74);
						this.fraImgSubEff.drawFrameNew(point32.frame * this.fraImgSubEff.maxNumFrame + GameCanvas.gameTick / 2 % this.fraImgSubEff.maxNumFrame, point32.x / 10, point32.y / 10, 0, 3, g);
						for (int num75 = 0; num75 < 4; num75 = num2 + 1)
						{
							this.fraImgEff.drawFrameNew(point32.frame * this.fraImgEff.maxNumFrame, point32.x / 10, point32.y / 10 - num75 * 73, (CRes.random(2) != 0) ? 2 : 0, 33, g);
							num2 = num75;
						}
					}
					num2 = num74;
				}
				break;
			}
			case 170:
			case 238:
			{
				bool flag158 = this.f <= 20 && !this.checkNullObject(1);
				if (flag158)
				{
					this.fraImgSub4Eff.drawFrame(CRes.random(this.fraImgSub4Eff.nFrame), this.objFireMain.x, this.objFireMain.y - this.objFireMain.hOne / 2 + 3, 0, 3, g);
				}
				int num2;
				for (int num76 = 0; num76 < this.VecEff.size(); num76 = num2 + 1)
				{
					Point_Focus point_Focus30 = (Point_Focus)this.VecEff.elementAt(num76);
					int num77 = 0;
					bool flag159 = this.Dir == 2;
					if (flag159)
					{
						num77 = 2;
					}
					bool flag160 = point_Focus30.f >= point_Focus30.fRe;
					if (flag160)
					{
						bool flag161 = this.fraImgEff.getImageFrame() != null && point_Focus30.f % 5 != 2 && point_Focus30.f < point_Focus30.fRe + 8;
						if (flag161)
						{
							g.drawRegion(this.fraImgEff.getImageFrame(), point_Focus30.typeSpec * this.fraImgEff.frameWidth, point_Focus30.frame * this.fraImgEff.frameHeight, this.fraImgEff.frameWidth, point_Focus30.maxdis, num77, (float)point_Focus30.x, (float)point_Focus30.y, 33);
						}
					}
					else
					{
						bool flag162 = point_Focus30.f % 5 != 2;
						if (flag162)
						{
							this.fraImgEff.drawFrameNew(point_Focus30.typeSpec * this.fraImgEff.maxNumFrame + point_Focus30.frame, point_Focus30.x, point_Focus30.y, num77, 3, g);
						}
					}
					num2 = num76;
				}
				for (int num78 = 0; num78 < this.VecSubEff.size(); num78 = num2 + 1)
				{
					Point point33 = (Point)this.VecSubEff.elementAt(num78);
					this.fraImgSub3Eff.drawFrameNew(point33.frame * this.fraImgSub3Eff.maxNumFrame + GameCanvas.gameTick / 2 % this.fraImgSub3Eff.maxNumFrame, point33.x / 10, point33.y / 10, 0, 3, g);
					for (int num79 = 0; num79 < 4; num79 = num2 + 1)
					{
						this.fraImgSub2Eff.drawFrameNew(point33.frame * this.fraImgSub2Eff.maxNumFrame, point33.x / 10, point33.y / 10 - num79 * 73, (CRes.random(2) != 0) ? 2 : 0, 33, g);
						num2 = num79;
					}
					num2 = num78;
				}
				break;
			}
			case 171:
			case 239:
			{
				bool flag163 = this.f < 20 && !this.checkNullObject(1) && (this.f <= 8 || this.f >= 13);
				if (flag163)
				{
					this.fraImgSub3Eff.drawFrame(this.f / 2 % this.fraImgSub3Eff.nFrame, this.objFireMain.x, this.objFireMain.y + this.objFireMain.dy, (int)this.Dir, 33, g);
				}
				int num2;
				for (int num80 = this.VecEff.size() - 1; num80 >= 0; num80 = num2 - 1)
				{
					Point point34 = (Point)this.VecEff.elementAt(num80);
					bool flag164 = point34.frame == 0 && point34.fSmall >= 2;
					if (flag164)
					{
						this.fraImgEff.drawFrame(point34.f / 2 % this.fraImgEff.nFrame, point34.x / 1000, point34.y / 1000, 0, 33, g);
					}
					else
					{
						bool flag165 = point34.frame == 1 && point34.fSmall == 3;
						if (flag165)
						{
							this.fraImgSubEff.drawFrame(point34.f / 2 % this.fraImgSubEff.nFrame, point34.x / 1000, point34.y / 1000, 0, 33, g);
						}
					}
					num2 = num80;
				}
				bool flag166 = this.f > 6 && this.f < this.fRemove;
				if (flag166)
				{
					int num81 = -4;
					int num82 = GameCanvas.gameTick % 2 * 2;
					this.fraImgSub2Eff.drawFrame(GameCanvas.gameTick / 3 % this.fraImgSub2Eff.nFrame, this.x, this.y - 3, 0, 3, g);
					g.setColor(16722432);
					g.fillRect(this.x - 20 - num81, this.y - this.y1000, 40 + num81 * 2, this.y1000);
					g.setColor(16745472);
					g.fillRect(this.x - 18 - num81, this.y - this.y1000, 36 + num81 * 2, this.y1000);
					g.setColor(16765184);
					g.fillRect(this.x - 16 - num81, this.y - this.y1000, 32 + num81 * 2, this.y1000);
					g.setColor(16745472);
					g.fillRect(this.x - 14 - num81 + num82, this.y - this.y1000, 28 + num81 * 2 - num82 * 2, this.y1000);
					g.setColor(16765184);
					g.fillRect(this.x - 12 - num81 + num82, this.y - this.y1000, 24 + num81 * 2 - num82 * 2, this.y1000);
					g.setColor(16777085);
					g.fillRect(this.x - 10 - num81 + num82, this.y - this.y1000, 20 + num81 * 2 - num82 * 2, this.y1000);
				}
				for (int num83 = this.VecEff.size() - 1; num83 >= 0; num83 = num2 - 1)
				{
					Point point35 = (Point)this.VecEff.elementAt(num83);
					bool flag167 = point35.frame == 0 && point35.fSmall < 2;
					if (flag167)
					{
						this.fraImgEff.drawFrame(point35.f / 2 % this.fraImgEff.nFrame, point35.x / 1000, point35.y / 1000, 0, 33, g);
					}
					else
					{
						bool flag168 = point35.frame == 1 && point35.fSmall != 3;
						if (flag168)
						{
							this.fraImgSubEff.drawFrame(point35.f / 2 % this.fraImgSubEff.nFrame, point35.x / 1000, point35.y / 1000, 0, 33, g);
						}
					}
					num2 = num83;
				}
				break;
			}
			case 172:
			case 240:
			{
				bool flag169 = this.f < 20 && !this.checkNullObject(1) && (this.f <= 8 || this.f >= 13);
				if (flag169)
				{
					this.fraImgEff.drawFrame(this.f / 2 % this.fraImgEff.nFrame, this.objFireMain.x, this.objFireMain.y + this.objFireMain.dy, (int)this.Dir, 33, g);
				}
				break;
			}
			case 173:
				this.paintEff_Mr1_2(g);
				break;
			case 174:
			{
				bool flag170 = this.f >= 4 && this.f <= this.fRemove && !this.checkNullObject(1);
				if (flag170)
				{
					int idx4 = 1;
					bool flag171 = this.f < 6;
					if (flag171)
					{
						idx4 = 0;
					}
					this.fraImgEff.drawFrame(idx4, this.objFireMain.x + this.am_duong * 36, this.objFireMain.y - 25, this.objFireMain.type_left_right, 3, g);
				}
				break;
			}
			case 175:
				this.paintEff_Df_2(g);
				break;
			case 178:
				this.paintEff_Mr0_1(g);
				break;
			case 179:
			case 241:
			{
				bool flag172 = (this.f >= 1 && this.f <= 2) || (this.f >= 24 && this.f <= 25);
				if (flag172)
				{
					this.fraImgEff.drawFrame(0, this.x + this.am_duong * 5, this.y, (int)this.Dir, 3, g);
				}
				int num2;
				for (int num84 = 0; num84 < this.VecSubEff.size(); num84 = num2 + 1)
				{
					Point point36 = (Point)this.VecSubEff.elementAt(num84);
					bool flag173 = point36.frame == 0;
					if (flag173)
					{
						bool flag174 = this.frame == 1;
						if (flag174)
						{
							this.fraImgSub4Eff.drawFrameNew(point36.f / 2 % this.fraImgSub4Eff.nFrame, point36.x, point36.y, point36.dis, 3, g);
						}
						else
						{
							this.fraImgSubEff.drawFrameNew((point36.f + point36.frame) % this.fraImgSubEff.nFrame, point36.x, point36.y, point36.dis, 3, g);
						}
					}
					num2 = num84;
				}
				for (int num85 = 0; num85 < this.VecEff.size(); num85 = num2 + 1)
				{
					Point point37 = (Point)this.VecEff.elementAt(num85);
					bool flag175 = this.frame == 1;
					if (flag175)
					{
						this.fraImgSubEff.drawFrame(point37.f % this.fraImgSubEff.nFrame, point37.x, point37.y, point37.dis, 3, g);
						this.fraImgSub3Eff.drawFrame(0, point37.x, point37.y + 60, point37.dis, 3, g);
						bool flag176 = point37.f % 2 == 0;
						if (flag176)
						{
							this.fraImgSub2Eff.drawFrameNew(this.step * this.fraImgSub2Eff.maxNumFrame + point37.f / 3 % this.fraImgSub2Eff.maxNumFrame, point37.x + this.am_duong * 10, point37.y + 5, point37.dis, 3, g);
						}
					}
					else
					{
						this.fraImgSubEff.drawFrameNew(point37.f % this.fraImgSubEff.nFrame, point37.x, point37.y, point37.dis, 3, g);
					}
					num2 = num85;
				}
				for (int num86 = 0; num86 < this.VecSubEff.size(); num86 = num2 + 1)
				{
					Point point38 = (Point)this.VecSubEff.elementAt(num86);
					bool flag177 = point38.frame == 1 && this.frame == 1;
					if (flag177)
					{
						this.fraImgSub4Eff.drawFrameNew(point38.f / 2 % this.fraImgSub4Eff.nFrame, point38.x, point38.y, point38.dis, 3, g);
					}
					num2 = num86;
				}
				break;
			}
			case 195:
			{
				int num2;
				for (int num87 = 0; num87 < this.VecEff.size(); num87 = num2 + 1)
				{
					Point point39 = (Point)this.VecEff.elementAt(num87);
					for (int num88 = 0; num88 < 4; num88 = num2 + 1)
					{
						this.fraImgEff.drawFrame(0, point39.x / 10, point39.y / 10 - 73 - num88 * 73, CRes.random(2) * 2, 0, g);
						num2 = num88;
					}
					this.fraImgSubEff.drawFrame(point39.f / 2 % this.fraImgSubEff.nFrame, point39.x / 10 + 15, point39.y / 10 + 4, CRes.random(2) * 2, 33, g);
					num2 = num87;
				}
				break;
			}
			case 196:
			{
				int num2;
				for (int num89 = 0; num89 < this.VecEff.size(); num89 = num2 + 1)
				{
					Point point40 = (Point)this.VecEff.elementAt(num89);
					this.fraImgEff.drawFrame(point40.f % this.fraImgEff.nFrame, point40.x, point40.y, (int)this.Dir, 3, g);
					num2 = num89;
				}
				for (int num90 = 0; num90 < this.VecSubEff.size(); num90 = num2 + 1)
				{
					Point point41 = (Point)this.VecSubEff.elementAt(num90);
					bool flag178 = point41.frame == 0;
					if (flag178)
					{
						this.fraImgSub2Eff.drawFrame(point41.f % this.fraImgSub2Eff.nFrame, point41.x, point41.y, (int)this.Dir, 3, g);
					}
					else
					{
						this.fraImgSubEff.drawFrame(point41.f / 2 % this.fraImgSubEff.nFrame, point41.x - 50, point41.y - 50, 0, 0, g);
						this.fraImgSubEff.drawFrame(point41.f / 2 % this.fraImgSubEff.nFrame, point41.x, point41.y - 50, 2, 0, g);
					}
					num2 = num90;
				}
				break;
			}
			case 197:
			{
				int num91 = 30 + this.f / 2 * 15;
				int num92 = 0;
				bool flag179 = num91 > 76;
				if (flag179)
				{
					num91 = 76;
				}
				bool flag180 = this.Dir == 0;
				if (flag180)
				{
					num92 = num91;
				}
				bool flag181 = this.fraImgEff.getImageFrame() != null;
				if (flag181)
				{
					g.drawRegion(this.fraImgEff.getImageFrame(), 0, 0, num91, 27, (int)this.Dir, (float)(this.x - num92), (float)(this.y - 13), 0);
				}
				break;
			}
			case 198:
			{
				bool flag182 = this.f < 8;
				if (flag182)
				{
					this.fraImgEff.drawFrame(this.f / 4, this.x, this.y, (int)this.Dir, 3, g);
				}
				int num2;
				for (int num93 = 0; num93 < this.VecEff.size(); num93 = num2 + 1)
				{
					Point_Focus point_Focus31 = (Point_Focus)this.VecEff.elementAt(num93);
					this.fraImgEff.drawFrame(point_Focus31.frame, point_Focus31.x, point_Focus31.y, 0, 3, g);
					num2 = num93;
				}
				break;
			}
			case 199:
			{
				bool flag183 = !this.checkNullObject(1) && this.objFireMain.isTanHinh;
				if (flag183)
				{
					this.fraImgEff.drawFrame(0, this.x, this.y, (int)this.Dir, 33, g);
				}
				break;
			}
			case 200:
			{
				bool flag184 = this.f < 20;
				if (flag184)
				{
					this.fraImgSubEff.drawFrame(this.f / 2 % this.fraImgSubEff.nFrame, this.x + 4 * this.am_duong, this.y - this.f % 4 / 2 * 3 + 2, (int)this.Dir, 3, g);
				}
				int num2;
				for (int num94 = 0; num94 < this.VecEff.size(); num94 = num2 + 1)
				{
					Point_Focus point_Focus32 = (Point_Focus)this.VecEff.elementAt(num94);
					this.fraImgEff.drawFrame((point_Focus32.frame + point_Focus32.f) % this.fraImgEff.nFrame, point_Focus32.x, point_Focus32.y, (int)this.Dir, 3, g);
					num2 = num94;
				}
				break;
			}
			case 202:
			{
				int num2;
				for (int num95 = 0; num95 < this.VecEff.size(); num95 = num2 + 1)
				{
					Point_Focus point_Focus33 = (Point_Focus)this.VecEff.elementAt(num95);
					this.fraImgEff.drawFrame(point_Focus33.f / 2 % 2, point_Focus33.x, point_Focus33.y, 0, 3, g);
					num2 = num95;
				}
				bool flag185 = !this.checkNullObject(1);
				if (flag185)
				{
					bool flag186 = this.f < 10;
					if (flag186)
					{
						this.fraImgEff.drawFrame(this.f / 2, this.x, this.objFireMain.y - this.objFireMain.hOne - 15, 0, 3, g);
					}
					else
					{
						bool flag187 = this.f < 12;
						if (flag187)
						{
							this.fraImgEff.drawFrame(2, this.x + this.am_duong * 20, this.objFireMain.y - this.objFireMain.hOne / 2 - 20, 0, 3, g);
						}
					}
				}
				break;
			}
			case 203:
			{
				bool flag188 = !this.checkNullObject(1) && this.objFireMain.isTanHinh;
				if (flag188)
				{
					this.fraImgEff.drawFrame(0, this.x, this.y, (int)this.Dir, 33, g);
				}
				break;
			}
			case 204:
			{
				int num2;
				for (int num96 = 0; num96 < this.VecEff.size(); num96 = num2 + 1)
				{
					Point point42 = (Point)this.VecEff.elementAt(num96);
					this.fraImgSubEff.drawFrame(point42.f % this.fraImgSubEff.nFrame, point42.x, point42.y, point42.dis, 3, g);
					this.fraImgSub2Eff.drawFrame(0, point42.x, point42.y + 60, point42.dis, 3, g);
					num2 = num96;
				}
				break;
			}
			case 205:
			{
				bool flag189 = this.f > 10 && this.f <= this.fRemove;
				if (flag189)
				{
					this.fraImgEff.drawFrame(0, this.x + this.x1000 / 1000, this.y + this.y1000 / 1000, 0, 3, g);
				}
				int num2;
				for (int num97 = 0; num97 < this.VecEff.size(); num97 = num2 + 1)
				{
					Point point43 = (Point)this.VecEff.elementAt(num97);
					this.fraImgEff.drawFrame(1 + point43.f / 3, point43.x, point43.y, 0, 3, g);
					num2 = num97;
				}
				break;
			}
			case 206:
			{
				bool flag190 = this.f < this.fPlayFrameSuper;
				if (flag190)
				{
					base.paint_Bullet(g, this.fraImgEff, this.frame, this.x, this.y, false, 0);
				}
				int num2;
				for (int num98 = 0; num98 < this.VecEff.size(); num98 = num2 + 1)
				{
					Point point44 = (Point)this.VecEff.elementAt(num98);
					this.fraImgSubEff.drawFrame(point44.f / 2 % this.fraImgSubEff.nFrame, point44.x, point44.y, 0, 3, g);
					num2 = num98;
				}
				break;
			}
			case 207:
			{
				bool flag191 = this.f < this.fPlayFrameSuper;
				if (flag191)
				{
					this.fraImgEff.drawFrame(3, this.x, this.y, 0, 3, g);
				}
				int num2;
				for (int num99 = 0; num99 < this.VecEff.size(); num99 = num2 + 1)
				{
					Point point45 = (Point)this.VecEff.elementAt(num99);
					this.fraImgSubEff.drawFrame(point45.f / 2 % this.fraImgSubEff.nFrame, point45.x, point45.y, 0, 3, g);
					num2 = num99;
				}
				break;
			}
			case 208:
				this.paintEffTru(g);
				break;
			case 209:
			case 242:
			{
				bool flag192 = this.typeEffect == 242 && this.objFireMain != null && this.f < 11;
				if (flag192)
				{
					this.objFireMain.paintBody(g, this.objFireMain.x + this.am_duong * 120, this.objFireMain.y, this.objFireMain.frame, (this.objFireMain.type_left_right == 0) ? 2 : 0, true);
				}
				bool flag193 = this.frame == 1;
				if (flag193)
				{
					int num2;
					for (int num100 = 0; num100 < this.VecEff.size(); num100 = num2 + 1)
					{
						Point point46 = (Point)this.VecEff.elementAt(num100);
						bool flag194 = this.fraImgSubEff != null && this.fraImgSubEff.imgFrame != null;
						if (flag194)
						{
							this.fraImgSubEff.drawFrameNew(CRes.random(this.fraImgSubEff.maxNumFrame), point46.x, point46.y, 0, 3, g);
						}
						this.fraImgEff.drawFrameNew(6 + point46.frame, point46.x, point46.y, 0, 3, g);
						num2 = num100;
					}
				}
				else
				{
					int num2;
					for (int num101 = 0; num101 < this.VecEff.size(); num101 = num2 + 1)
					{
						Point point47 = (Point)this.VecEff.elementAt(num101);
						this.fraImgEff.drawFrameNew(6 + point47.frame, point47.x, point47.y, 0, 3, g);
						num2 = num101;
					}
				}
				bool flag195 = this.f < this.fRemove;
				if (flag195)
				{
					this.fraImgEff.drawFrameNew(6 + this.mframe[this.f], this.x, this.y, (int)this.Dir, 3, g);
				}
				break;
			}
			case 210:
			case 243:
				this.paint_Dong_Dat_1(g);
				break;
			case 211:
			case 244:
				this.paint_Dong_Dat_2(g);
				break;
			case 212:
			case 271:
			case 274:
			case 275:
			{
				int num2;
				for (int num102 = 0; num102 < this.VecSubEff.size(); num102 = num2 + 1)
				{
					Point point48 = (Point)this.VecSubEff.elementAt(num102);
					this.fraImgEff.drawFrame(point48.f % this.fraImgEff.nFrame, point48.x, point48.y, 0, 3, g);
					num2 = num102;
				}
				break;
			}
			case 219:
			case 292:
			{
				bool flag196 = this.f == 4;
				if (flag196)
				{
					this.fraImgSubEff.drawFrame(0, this.x, this.y, (int)this.Dir, 3, g);
				}
				bool flag197 = this.f == 24;
				if (flag197)
				{
					this.fraImgSubEff.drawFrame(0, this.x1000, this.y1000, (int)this.Dir, 33, g);
				}
				bool flag198 = this.mframe[this.f] >= 0;
				if (flag198)
				{
					this.fraImgEff.drawFrame(this.mframe[this.f], this.x, this.y + 5, (int)this.Dir, 33, g);
				}
				break;
			}
			case 224:
			{
				bool flag199 = this.f == 1 || this.f == 15;
				if (flag199)
				{
					this.fraImgEff.drawFrame(0, this.x, this.y, 0, 33, g);
				}
				bool isTanHinh3 = this.objFireMain.isTanHinh;
				if (isTanHinh3)
				{
					this.fraImgSubEff.drawFrame(this.f / 2 % this.fraImgSubEff.nFrame, this.x + this.mframeSuper[(this.f - 2) / 2][0], this.y + this.mframeSuper[(this.f - 2) / 2][1], (int)this.Dir, 33, g);
				}
				break;
			}
			case 228:
			case 259:
			case 260:
			case 261:
			{
				int num2;
				for (int num103 = 0; num103 < this.VecSubEff.size(); num103 = num2 + 1)
				{
					Point point49 = (Point)this.VecSubEff.elementAt(num103);
					this.fraImgSub2Eff.drawFrameNew_BeginSuper(point49.f, point49.x, point49.y, 0, 3, g);
					num2 = num103;
				}
				for (int num104 = 0; num104 < this.VecEff.size(); num104 = num2 + 1)
				{
					Point point50 = (Point)this.VecEff.elementAt(num104);
					this.fraImgEff.drawFrameNew_BeginSuper(point50.frame, point50.x, point50.y, 0, 33, g);
					num2 = num104;
				}
				bool flag200 = !this.checkNullObject(1) && this.f >= 4 && this.f <= 12;
				if (flag200)
				{
					this.fraImgSubEff.drawFrameNew_BeginSuper(this.f % this.fraImgSubEff.maxNumFrame, this.objFireMain.x - this.am_duong * 20, this.objFireMain.y - this.objFireMain.dy - 15, this.objFireMain.type_left_right, 3, g);
				}
				break;
			}
			case 245:
			case 251:
			{
				bool flag201 = !this.checkNullObject(1) && this.f >= 8 && this.f <= 19 && this.f - 8 < this.mframeSuper.Length;
				if (flag201)
				{
					this.fraImgEff.drawFrameNew(this.mframeSuper[this.f - 8][0], this.objFireMain.x + this.am_duong * (this.mframeSuper[this.f - 8][1] + 20), this.objFireMain.y - this.objFireMain.hOne / 2 - this.mframeSuper[this.f - 8][2] - this.objFireMain.dy, this.objFireMain.type_left_right, 3, g);
				}
				int num2;
				for (int num105 = 0; num105 < this.VecEff.size(); num105 = num2 + 1)
				{
					Point point51 = (Point)this.VecEff.elementAt(num105);
					this.fraImgSubEff.drawFrame(point51.f / 2 % this.fraImgSubEff.nFrame, point51.x, point51.y, point51.dis, 3, g);
					num2 = num105;
				}
				break;
			}
			case 246:
			case 253:
			{
				bool flag202 = this.f >= 10 && this.f <= this.fRemove - 4 && this.f % 3 != 2;
				if (flag202)
				{
					this.fraImgSubEff.drawFrame(this.f / 2 % this.fraImgSubEff.nFrame, this.x, this.y + 3, (int)this.Dir, 3, g);
				}
				int num2;
				for (int num106 = 0; num106 < this.VecEff.size(); num106 = num2 + 1)
				{
					Point point52 = (Point)this.VecEff.elementAt(num106);
					bool flag203 = point52.frame == 0;
					if (flag203)
					{
						this.fraImgEff.drawFrame(0, point52.x, point52.y, 0, 3, g);
					}
					else
					{
						bool flag204 = point52.frame == 1;
						if (flag204)
						{
							bool flag205 = this.fraImgEff.getImageFrame() != null;
							if (flag205)
							{
								g.drawRegion(this.fraImgEff.getImageFrame(), 0, 0, this.fraImgEff.frameWidth, this.fraImgEff.frameHeight - point52.dis, 0, (float)point52.x, (float)point52.y, 33);
							}
						}
						else
						{
							bool flag206 = (point52.frame == 2 || point52.frame == 3) && this.fraImgEff.getImageFrame() != null;
							if (flag206)
							{
								g.drawRegion(this.fraImgEff.getImageFrame(), 0, (point52.frame - 1) * this.fraImgEff.frameHeight, this.fraImgEff.frameWidth, this.fraImgEff.frameHeight - point52.dis, 0, (float)point52.x, (float)point52.y, 33);
							}
						}
					}
					num2 = num106;
				}
				break;
			}
			case 247:
			case 254:
			{
				bool flag207 = this.f >= 5 && this.f <= 7;
				if (flag207)
				{
					bool flag208 = this.fraImgEff.getImageFrame() != null;
					if (flag208)
					{
						g.drawRegion(this.fraImgEff.getImageFrame(), 0, 0, this.fraImgEff.frameWidth / 4 * (this.f - 4), this.fraImgEff.frameHeight, (int)this.Dir, (float)this.x, (float)this.y, 3);
					}
					bool flag209 = !this.checkNullObject(1);
					if (flag209)
					{
						this.fraImgSub2Eff.drawFrame(0, this.x - this.am_duong * 10, this.objFireMain.y - this.objFireMain.hOne + 10, (int)this.Dir, 3, g);
					}
				}
				bool flag210 = this.f == 7 || this.f == 8 || this.f == 14 || this.f == 15;
				if (flag210)
				{
					this.fraImgEff.drawFrame(this.f / 2 % this.fraImgEff.nFrame, this.x - this.am_duong * 14, this.y, (int)this.Dir, 3, g);
					bool flag211 = !this.checkNullObject(1);
					if (flag211)
					{
						this.fraImgSub2Eff.drawFrame(0, this.x - this.am_duong * 10, this.objFireMain.y - this.objFireMain.hOne + 10, (int)this.Dir, 3, g);
					}
				}
				int num2;
				for (int num107 = 0; num107 < this.VecEff.size(); num107 = num2 + 1)
				{
					Point_Focus point_Focus34 = (Point_Focus)this.VecEff.elementAt(num107);
					bool flag212 = this.typeEffect == 254 && CRes.random(2) == 0;
					if (flag212)
					{
						this.fraImgSub3Eff.drawFrame(CRes.random(5), point_Focus34.x / 10 + CRes.random_Am_0(5) + this.am_duong * 5, point_Focus34.y / 10 - 8, (int)point_Focus34.Dir, 3, g);
					}
					this.fraImgEff.drawFrame(point_Focus34.f / 2 % this.fraImgEff.nFrame, point_Focus34.x / 10, point_Focus34.y / 10, (int)point_Focus34.Dir, 3, g);
					bool flag213 = this.typeEffect == 254 && CRes.random(2) == 0;
					if (flag213)
					{
						this.fraImgSub3Eff.drawFrame(CRes.random(5), point_Focus34.x / 10 + CRes.random_Am_0(5) + this.am_duong * 20, point_Focus34.y / 10 - 8, (int)point_Focus34.Dir, 3, g);
					}
					num2 = num107;
				}
				for (int num108 = 0; num108 < this.VecSubEff.size(); num108 = num2 + 1)
				{
					Point point53 = (Point)this.VecSubEff.elementAt(num108);
					bool flag214 = point53.fRe == 5;
					if (flag214)
					{
						this.fraImgSub3Eff.drawFrame(point53.f % this.fraImgSub3Eff.nFrame, point53.x, point53.y, 0, 3, g);
					}
					else
					{
						this.fraImgSubEff.drawFrame(point53.f % this.fraImgSubEff.nFrame, point53.x, point53.y, 0, 3, g);
					}
					num2 = num108;
				}
				break;
			}
			case 248:
			case 255:
			{
				bool flag215 = !this.checkNullObject(1);
				if (flag215)
				{
					bool flag216 = this.f == 5 || this.f == 6 || this.f == 10 || this.f == 11 || this.f == 14;
					if (flag216)
					{
						this.fraImgSubEff.drawFrame(0, this.objFireMain.x, this.objFireMain.y - this.objFireMain.dy, 0, 33, g);
					}
					bool flag217 = this.f >= 15 && this.f <= 19;
					if (flag217)
					{
						this.fraImgEff.drawFrame(this.f / 2 % this.fraImgEff.nFrame, this.objFireMain.x, this.objFireMain.y - this.objFireMain.dy, 0, 33, g);
					}
				}
				break;
			}
			case 249:
			case 252:
			{
				bool flag218 = !this.checkNullObject(1) && (this.f == 6 || this.f == 8 || this.f == 19 || this.f == 21);
				if (flag218)
				{
					this.fraImgSub2Eff.drawFrame(0, this.objFireMain.x, this.objFireMain.y, 0, 33, g);
				}
				int num2;
				for (int num109 = 0; num109 < this.VecEff.size(); num109 = num2 + 1)
				{
					Point point54 = (Point)this.VecEff.elementAt(num109);
					int num110 = (point54.f + point54.frame) % this.mframeSuper.Length;
					this.fraImgSubEff.drawFrameNew(point54.f % this.fraImgSubEff.nFrame, point54.x, point54.y - point54.limitY, point54.dis, 3, g);
					this.fraImgEff.drawFrameNew(this.mframeSuper[num110][0], point54.x + point54.fSmall * (this.mframeSuper[num110][1] + 20), point54.y - this.mframeSuper[num110][2] - point54.limitY, point54.dis, 3, g);
					num2 = num109;
				}
				break;
			}
			case 250:
				this.paintEffTru2(g);
				break;
			case 266:
			{
				int num2;
				for (int num111 = 0; num111 < this.VecEff.size(); num111 = num2 + 1)
				{
					bool flag219 = this.f > 3 + num111 * 4;
					if (flag219)
					{
						Point_Focus point_Focus35 = (Point_Focus)this.VecEff.elementAt(num111);
						int trans6 = 0;
						bool flag220 = this.Dir == 2;
						if (flag220)
						{
							trans6 = 2;
						}
						this.fraImgEff.drawFrame(0, point_Focus35.x, point_Focus35.y, trans6, 3, g);
					}
					num2 = num111;
				}
				break;
			}
			case 267:
			{
				bool flag221 = this.f <= 2;
				if (!flag221)
				{
					int num2;
					for (int num112 = 0; num112 < this.VecEff.size(); num112 = num2 + 1)
					{
						Point_Focus point_Focus36 = (Point_Focus)this.VecEff.elementAt(num112);
						int trans7 = 0;
						bool flag222 = this.Dir == 2;
						if (flag222)
						{
							trans7 = 2;
						}
						this.fraImgEff.drawFrame(0, point_Focus36.x, point_Focus36.y - 5, trans7, 3, g);
						num2 = num112;
					}
				}
				break;
			}
			case 268:
			{
				bool flag223 = (this.f >= 2 && this.f <= 11) || (this.f >= 16 && this.f <= 25);
				if (flag223)
				{
					this.fraImgEff.drawFrame(GameCanvas.gameTickChia4 % 2, this.x1000, this.y + 3, 0, 3, g);
				}
				break;
			}
			case 269:
			{
				int num2;
				for (int num113 = 0; num113 < this.VecEff.size(); num113 = num2 + 1)
				{
					Point point55 = (Point)this.VecEff.elementAt(num113);
					this.fraImgEff.drawFrame(GameCanvas.gameTickChia4 % 2, point55.x, point55.y, (int)this.Dir, 3, g);
					num2 = num113;
				}
				break;
			}
			case 276:
			case 277:
			{
				int num2;
				for (int num114 = 0; num114 < this.VecEff.size(); num114 = num2 + 1)
				{
					Point_Focus point_Focus37 = (Point_Focus)this.VecEff.elementAt(num114);
					this.fraImgEff.drawFrame((point_Focus37.frame + point_Focus37.f) % this.fraImgEff.nFrame, point_Focus37.x, point_Focus37.y, (int)this.Dir, 3, g);
					num2 = num114;
				}
				break;
			}
			case 278:
			case 279:
			{
				int num2;
				for (int num115 = 0; num115 < this.VecEff.size(); num115 = num2 + 1)
				{
					Point point56 = (Point)this.VecEff.elementAt(num115);
					this.fraImgEff.drawFrameNew(point56.frame + point56.dis * 5, this.objBeFireMain.x + point56.x, this.y + point56.y, 0, 3, g);
					num2 = num115;
				}
				for (int num116 = 0; num116 < this.VecSubEff.size(); num116 = num2 + 1)
				{
					Point point57 = (Point)this.VecSubEff.elementAt(num116);
					this.fraImgSubEff.drawFrameNew(point57.frame + point57.dis * 4, this.objBeFireMain.x + point57.x, this.y + point57.y, 0, 3, g);
					num2 = num116;
				}
				break;
			}
			case 280:
				this.fraImgSubEff.drawFrame(this.f % this.fraImgSubEff.nFrame, this.x, this.y, 0, 3, g);
				this.fraImgEff.drawFrame(0, this.toX, this.toY, 0, 3, g);
				break;
			case 281:
			{
				int num2;
				for (int num117 = 0; num117 < this.VecEff.size(); num117 = num2 + 1)
				{
					Point_Focus point_Focus38 = (Point_Focus)this.VecEff.elementAt(num117);
					int num118 = point_Focus38.f * this.fraImgEff.frameHeight / 3 + this.fraImgEff.frameHeight / 3;
					bool flag224 = num118 > this.fraImgEff.frameHeight;
					if (flag224)
					{
						num118 = this.fraImgEff.frameHeight;
					}
					bool flag225 = this.fraImgEff.getImageFrame() != null;
					if (flag225)
					{
						g.drawRegion(this.fraImgEff.getImageFrame(), 0, this.fraImgEff.frameHeight - num118 + point_Focus38.f % this.fraImgEff.nFrame * this.fraImgEff.frameHeight, this.fraImgEff.frameWidth, num118, 0, (float)point_Focus38.x, (float)point_Focus38.y, 33);
					}
					num2 = num117;
				}
				for (int num119 = 0; num119 < this.VecSubEff.size(); num119 = num2 + 1)
				{
					bool flag226 = this.f > 8 + num119 * 4;
					if (flag226)
					{
						Point_Focus point_Focus39 = (Point_Focus)this.VecSubEff.elementAt(num119);
						int trans8 = 0;
						bool flag227 = this.Dir == 2;
						if (flag227)
						{
							trans8 = 2;
						}
						this.fraImgSub2Eff.drawFrame(this.f % this.fraImgSub2Eff.nFrame, point_Focus39.x, point_Focus39.y, trans8, 3, g);
					}
					num2 = num119;
				}
				break;
			}
			case 282:
			{
				bool flag228 = this.f > 12 && this.f < 15;
				if (flag228)
				{
					this.fraImgEff.drawFrame(this.f - 13, this.objFireMain.x, this.objFireMain.y - 10, (int)this.Dir, 33, g);
				}
				else
				{
					bool flag229 = this.f > 22 && this.f < 25;
					if (flag229)
					{
						this.fraImgEff.drawFrame(this.f - 23, this.objFireMain.x, this.objFireMain.y - 10, (int)this.Dir, 33, g);
					}
					else
					{
						bool flag230 = this.f > 28 && this.f < 31;
						if (flag230)
						{
							this.fraImgEff.drawFrame(this.f - 29, this.objFireMain.x, this.objFireMain.y - 10, (int)this.Dir, 33, g);
						}
						else
						{
							bool flag231 = this.f > 34 && this.f < 37;
							if (flag231)
							{
								this.fraImgEff.drawFrame(this.f - 35, this.objFireMain.x, this.objFireMain.y - 10, (int)this.Dir, 33, g);
							}
						}
					}
				}
				int num2;
				for (int num120 = 0; num120 < this.VecEff.size(); num120 = num2 + 1)
				{
					Point point58 = (Point)this.VecEff.elementAt(num120);
					int trans9 = point58.dis;
					int idx5 = point58.frame;
					bool flag232 = point58.frame == 2;
					if (flag232)
					{
						trans9 = 5;
					}
					else
					{
						bool flag233 = point58.frame == 3;
						if (flag233)
						{
							idx5 = 2;
						}
					}
					this.fraImgSubEff.drawFrame(idx5, point58.x, point58.y, trans9, 3, g);
					num2 = num120;
				}
				break;
			}
			case 291:
			{
				bool flag234 = this.f == 4;
				if (flag234)
				{
					this.fraImgSubEff.drawFrame(0, this.x1000, this.y1000, (int)this.Dir, 33, g);
				}
				bool flag235 = this.mframe[this.f] >= 0;
				if (flag235)
				{
					this.fraImgEff.drawFrame(this.mframe[this.f], this.objBeFireMain.x - this.am_duong * 30, this.objBeFireMain.y + 5, (int)this.Dir, 33, g);
				}
				break;
			}
			case 301:
			{
				bool flag236 = this.f == 1 || this.f == 15;
				if (flag236)
				{
					this.fraImgEff.drawFrame(0, this.x, this.y, 0, 33, g);
				}
				bool isTanHinh4 = this.objFireMain.isTanHinh;
				if (isTanHinh4)
				{
					this.fraImgSubEff.drawFrame(this.f / 2 % this.fraImgSubEff.nFrame, this.x + this.mframeSuper[(this.f - 2) / 2][0], this.y + this.mframeSuper[(this.f - 2) / 2][1], (int)this.Dir, 33, g);
				}
				int num2;
				for (int num121 = 0; num121 < this.VecSubEff.size(); num121 = num2 + 1)
				{
					bool flag237 = this.f > num121 * 4;
					if (flag237)
					{
						Point_Focus point_Focus40 = (Point_Focus)this.VecSubEff.elementAt(num121);
						int trans10 = 0;
						bool flag238 = this.Dir == 0;
						if (flag238)
						{
							trans10 = 2;
						}
						this.fraImgSub2Eff.drawFrame(this.f % this.fraImgSub2Eff.nFrame, point_Focus40.x, point_Focus40.y, trans10, 3, g);
					}
					num2 = num121;
				}
				break;
			}
			case 303:
			{
				bool flag239 = this.f >= 10 && this.f <= this.fRemove;
				if (flag239)
				{
					base.paint_Bullet(g, this.fraImgEff, this.frame, this.x, this.y, false, 0);
					base.paint_Bullet(g, this.fraImgEff, this.frame1, this.rocket1.x, this.rocket1.y, false, 0);
					base.paint_Bullet(g, this.fraImgEff, this.frame2, this.rocket2.x, this.rocket2.y, false, 0);
				}
				break;
			}
			case 402:
			{
				int num2;
				for (int num122 = 0; num122 < this.VecEff.size(); num122 = num2 + 1)
				{
					Point point59 = (Point)this.VecEff.elementAt(num122);
					bool flag240 = point59.frame != 0;
					if (flag240)
					{
						int idx6 = (point59.f >= point59.fRe - 3) ? (this.fraImgEff.maxNumFrame - (point59.fRe - point59.f)) : ((point59.f + point59.fSmall) % 3);
						this.fraImgEff.drawFrameNew_BeginSuper(idx6, point59.x / 1000, point59.y / 1000, 0, 3, g);
					}
					num2 = num122;
				}
				break;
			}
			default:
				switch (num)
				{
				case 10001:
					this.paintPan_1(g);
					break;
				case 10002:
				{
					bool flag241 = this.f < 6;
					if (flag241)
					{
						this.fraImgEff.drawFrame(this.f % this.fraImgEff.nFrame, this.x, this.y - this.objFireMain.dy, (int)this.Dir, 33, g);
					}
					bool flag242 = this.f >= 13 && this.f <= 18;
					if (flag242)
					{
						this.fraImgSubEff.drawFrame(this.f % this.fraImgSubEff.nFrame, this.objFireMain.x, this.objFireMain.y - this.objFireMain.dy, (int)this.Dir, 33, g);
					}
					break;
				}
				case 10003:
					this.paintGalio_1(g);
					break;
				case 10004:
				{
					bool flag243 = this.f < 4;
					if (flag243)
					{
						this.fraImgSubEff.drawFrame(this.f / 2 % this.fraImgSubEff.nFrame, this.x, this.y, (int)this.Dir, 3, g);
					}
					int num2;
					for (int num123 = 0; num123 < this.VecEff.size(); num123 = num2 + 1)
					{
						Point point60 = (Point)this.VecEff.elementAt(num123);
						this.fraImgEff.drawFrame(point60.f / 2 % this.fraImgEff.nFrame, point60.x, point60.y, (int)this.Dir, 33, g);
						num2 = num123;
					}
					break;
				}
				case 10006:
				case 10011:
				{
					int num2;
					for (int num124 = 0; num124 < this.vecPos.size(); num124 = num2 + 1)
					{
						Point_Focus point_Focus41 = (Point_Focus)this.vecPos.elementAt(num124);
						this.fraImgSubEff.drawFrame(point_Focus41.frame + point_Focus41.f / 3 % 2, point_Focus41.x, point_Focus41.y, 0, mGraphics.BOTTOM | mGraphics.RIGHT, g);
						this.fraImgSubEff.drawFrame(point_Focus41.frame + point_Focus41.f / 3 % 2, point_Focus41.x, point_Focus41.y, 2, mGraphics.BOTTOM | mGraphics.LEFT, g);
						this.fraImgSubEff.drawFrame(point_Focus41.frame + point_Focus41.f / 3 % 2, point_Focus41.x, point_Focus41.y, 1, mGraphics.TOP | mGraphics.RIGHT, g);
						this.fraImgSubEff.drawFrame(point_Focus41.frame + point_Focus41.f / 3 % 2, point_Focus41.x, point_Focus41.y, 3, 0, g);
						g.setColor(0);
						g.fillRect(point_Focus41.x - 1, point_Focus41.y - 1, 3, 3);
						num2 = num124;
					}
					break;
				}
				case 10007:
				{
					int num2;
					for (int num125 = 0; num125 < this.vecPos.size(); num125 = num2 + 1)
					{
						Point_Focus point_Focus42 = (Point_Focus)this.vecPos.elementAt(num125);
						this.fraImgEff.drawFrame(point_Focus42.f / 2 % this.fraImgEff.nFrame, point_Focus42.x, point_Focus42.y, (int)this.Dir, 33, g);
						this.fraImgSubEff.drawFrame(point_Focus42.f / 2 % this.fraImgSubEff.nFrame, point_Focus42.x, point_Focus42.y, (int)this.Dir, 3, g);
						num2 = num125;
					}
					break;
				}
				case 10008:
				{
					int num2;
					for (int num126 = 0; num126 < this.VecSubEff.size(); num126 = num2 + 1)
					{
						Point point61 = (Point)this.VecSubEff.elementAt(num126);
						this.fraImgEff.drawFrame(point61.frame, point61.x, point61.y, (int)this.Dir, 3, g);
						num2 = num126;
					}
					break;
				}
				case 10010:
				case 10013:
					this.fraImgEff.drawFrame(GameCanvas.gameTick / (int)this.numNextFrame % this.fraImgEff.nFrame, this.objFireMain.x, this.objFireMain.y - this.objFireMain.hOne / 2, (int)this.Dir, 3, g);
					break;
				case 10012:
				{
					bool flag244 = this.f <= this.fRemove;
					if (flag244)
					{
						this.fraImgEff.drawFrame(1, this.x1000 / 1000, this.y1000, (int)this.Dir, 3, g);
					}
					int num2;
					for (int num127 = 0; num127 < this.VecEff.size(); num127 = num2 + 1)
					{
						Point point62 = (Point)this.VecEff.elementAt(num127);
						point62.fraImgEff.drawFrame(point62.f / 2, point62.x, point62.y, (int)this.Dir, 3, g);
						num2 = num127;
					}
					break;
				}
				case 10015:
				{
					int num2;
					for (int num128 = 0; num128 < this.VecEff.size(); num128 = num2 + 1)
					{
						Point point63 = (Point)this.VecEff.elementAt(num128);
						this.fraImgEff.drawFrame(point63.frame, this.objFireMain.x, this.objFireMain.y + point63.y, (int)this.Dir, 33, g);
						num2 = num128;
					}
					break;
				}
				case 10017:
					this.fraImgEff.drawFrame(GameCanvas.gameTick / (int)this.numNextFrame % this.fraImgEff.nFrame, this.objFireMain.x, this.objFireMain.y - this.objFireMain.hOne / 4, (int)this.Dir, 3, g);
					break;
				case 10018:
				{
					int num2;
					for (int num129 = 0; num129 < this.VecEff.size(); num129 = num2 + 1)
					{
						Point point64 = (Point)this.VecEff.elementAt(num129);
						this.fraImgEff.drawFrame(point64.frame, point64.x, point64.y, (int)this.Dir, 33, g);
						num2 = num129;
					}
					break;
				}
				case 10020:
				case 10021:
				case 10022:
				case 10026:
					this.fraImgEff.drawFrame(GameCanvas.gameTick / (int)this.numNextFrame % this.fraImgEff.nFrame, this.objFireMain.x, this.objFireMain.y - this.objFireMain.hOne / 2, (int)this.Dir, 3, g);
					break;
				case 10024:
				{
					this.fraImgEff.drawFrame(GameCanvas.gameTick / (int)this.numNextFrame % this.fraImgEff.nFrame, this.objFireMain.x, this.objFireMain.y - this.objFireMain.hOne / 2, (int)this.Dir, 3, g);
					int num2;
					for (int num130 = 0; num130 < this.vecPos.size(); num130 = num2 + 1)
					{
						Point_Focus point_Focus43 = (Point_Focus)this.vecPos.elementAt(num130);
						this.fraImgSubEff.drawFrame(point_Focus43.frame + point_Focus43.f / 3 % 2, point_Focus43.x, point_Focus43.y, 0, mGraphics.BOTTOM | mGraphics.RIGHT, g);
						this.fraImgSubEff.drawFrame(point_Focus43.frame + point_Focus43.f / 3 % 2, point_Focus43.x, point_Focus43.y, 2, mGraphics.BOTTOM | mGraphics.LEFT, g);
						this.fraImgSubEff.drawFrame(point_Focus43.frame + point_Focus43.f / 3 % 2, point_Focus43.x, point_Focus43.y, 1, mGraphics.TOP | mGraphics.RIGHT, g);
						this.fraImgSubEff.drawFrame(point_Focus43.frame + point_Focus43.f / 3 % 2, point_Focus43.x, point_Focus43.y, 3, 0, g);
						num2 = num130;
					}
					break;
				}
				case 10025:
					this.fraImgEff.drawFrame(this.f / 2 % this.fraImgEff.nFrame, this.x, this.y, (int)this.Dir, 3, g);
					break;
				case 10028:
				{
					bool flag245 = this.f > 16;
					if (flag245)
					{
						int num131 = -4;
						int num132 = GameCanvas.gameTick % 2 * 2;
						bool flag246 = this.y1000 == 0;
						if (flag246)
						{
							this.fraImgSub3Eff.drawFrameNew(GameCanvas.gameTick / 3 % this.fraImgSub3Eff.nFrame, this.x, this.y + 7, 0, 3, g);
						}
						g.setColor(1513500);
						g.fillRect(this.x - 20 - num131, this.y - 350 - this.y1000, 40 + num131 * 2, 360);
						g.setColor(1908256);
						g.fillRect(this.x - 18 - num131, this.y - 350 - this.y1000, 36 + num131 * 2, 360);
						g.setColor(7040880);
						g.fillRect(this.x - 16 - num131, this.y - 350 - this.y1000, 32 + num131 * 2, 360);
						g.setColor(2500651);
						g.fillRect(this.x - 14 - num131 + num132, this.y - 350 - this.y1000, 28 + num131 * 2 - num132 * 2, 360);
						g.setColor(9540757);
						g.fillRect(this.x - 12 - num131 + num132, this.y - 350 - this.y1000, 24 + num131 * 2 - num132 * 2, 360);
						g.setColor(16514814);
						g.fillRect(this.x - 10 - num131 + num132, this.y - 350 - this.y1000, 20 + num131 * 2 - num132 * 2, 360);
					}
					break;
				}
				}
				break;
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000211 RID: 529 RVA: 0x00041F90 File Offset: 0x00040190
	private void paintEffTru2(mGraphics g)
	{
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(i);
			this.fraImgEff.drawFrame(0, point_Focus.x, point_Focus.y, 0, 3, g);
		}
		for (int j = 0; j < this.VecSubEff.size(); j++)
		{
			Point point = (Point)this.VecSubEff.elementAt(j);
			this.fraImgEff.drawFrame(point.f, point.x, point.y, 0, 3, g);
		}
	}

	// Token: 0x06000212 RID: 530 RVA: 0x00042040 File Offset: 0x00040240
	private void paint_Dong_Dat_2(mGraphics g)
	{
		for (int i = 0; i < this.VecSubEff.size(); i++)
		{
			Point point = (Point)this.VecSubEff.elementAt(i);
			bool flag = point.frame == 0 && this.typeEffect == 244;
			if (flag)
			{
				this.fraImgSubEff.drawFrameNew(point.f / 3 % this.fraImgSubEff.nFrame, point.x, point.y, (int)this.Dir, 33, g);
			}
			else
			{
				this.fraImgEff.drawFrameNew(point.f / 3 % this.fraImgEff.nFrame, point.x, point.y, (int)this.Dir, 33, g);
			}
		}
	}

	// Token: 0x06000213 RID: 531 RVA: 0x00042110 File Offset: 0x00040310
	private void paint_Dong_Dat_1(mGraphics g)
	{
		bool flag = this.f > 20 && this.fraImgEff.getImageFrame() != null;
		if (flag)
		{
			int num = 1;
			bool flag2 = this.f < 24;
			int num2;
			int x;
			if (flag2)
			{
				num = 3;
				num2 = this.fraImgEff.frameWidth / num;
				x = this.fraImgEff.frameWidth / 2 - num2 / 2;
			}
			else
			{
				bool flag3 = this.f < 27;
				if (flag3)
				{
					num = 2;
					num2 = this.fraImgEff.frameWidth / num;
					x = this.fraImgEff.frameWidth / 2 - num2 / 2;
				}
				else
				{
					num2 = this.fraImgEff.frameWidth;
					x = 0;
				}
			}
			g.drawRegion(this.fraImgEff.getImageFrame(), x, 0, num2, this.fraImgEff.frameHeight, 0, (float)(MainScreen.cameraMain.xCam + this.x), (float)(MainScreen.cameraMain.yCam + this.y), 3);
			bool flag4 = this.f < 24;
			if (flag4)
			{
				num2 = this.fraImgSubEff.frameWidth / num;
				x = this.fraImgSubEff.frameWidth / 2 - num2 / 2;
			}
			else
			{
				bool flag5 = this.f < 27;
				if (flag5)
				{
					num2 = this.fraImgSubEff.frameWidth / num;
					x = this.fraImgSubEff.frameWidth / 2 - num2 / 2;
				}
				else
				{
					num2 = this.fraImgSubEff.frameWidth;
					x = 0;
				}
			}
			g.drawRegion(this.fraImgSubEff.getImageFrame(), x, 0, num2, this.fraImgSubEff.frameHeight, 0, (float)(MainScreen.cameraMain.xCam + this.x1000), (float)(MainScreen.cameraMain.yCam + this.y1000), 3);
		}
	}

	// Token: 0x06000214 RID: 532 RVA: 0x000422C8 File Offset: 0x000404C8
	private void paintEffTru(mGraphics g)
	{
		bool flag = this.f <= this.fRemove;
		if (flag)
		{
			this.fraImgEff.drawFrame(0, this.x, this.y, 0, 3, g);
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point = (Point)this.VecEff.elementAt(i);
			this.fraImgEff.drawFrame(point.f, point.x, point.y, 0, 3, g);
		}
	}

	// Token: 0x06000215 RID: 533 RVA: 0x00042358 File Offset: 0x00040558
	private void paintEff_Mr0_1(mGraphics g)
	{
		int num = 14;
		bool flag = this.frame == 0;
		if (flag)
		{
			this.fraImgEff.drawFrameNew(4, this.x - this.am_duong * 4, this.y + num - 4 - 8, (int)this.Dir, 33, g);
			this.fraImgEff.drawFrameNew(4, this.x + this.am_duong * 4, this.y + num - 2 - 8, (int)this.Dir, 33, g);
			this.fraImgEff.drawFrameNew(5, this.x + this.am_duong * 8, this.y + num - 8, (int)this.Dir, 33, g);
			this.fraImgEff.drawFrameNew(5, this.x + this.am_duong * 12, this.y + num + 2 - 8, (int)this.Dir, 33, g);
		}
		else
		{
			bool flag2 = this.frame == 1;
			if (flag2)
			{
				this.fraImgEff.drawFrameNew(2, this.x - this.am_duong * 5, this.y - 6 - 24, (int)this.Dir, 33, g);
				this.fraImgEff.drawFrameNew(2, this.x + this.am_duong * 5, this.y - 3 - 16, (int)this.Dir, 33, g);
				this.fraImgEff.drawFrameNew(3, this.x + this.am_duong * 15, this.y + 2 - 10, (int)this.Dir, 33, g);
				this.fraImgEff.drawFrameNew(3, this.x + this.am_duong * 25, this.y + 13 - 10, (int)this.Dir, 33, g);
			}
			else
			{
				bool flag3 = this.frame == 2;
				if (flag3)
				{
					this.fraImgEff.drawFrameNew(0, this.x - this.am_duong * 5, this.y - 6 - 24, (int)this.Dir, 33, g);
					this.fraImgEff.drawFrameNew(0, this.x + this.am_duong * 5, this.y - 3 - 6 - 10, (int)this.Dir, 33, g);
					this.fraImgEff.drawFrameNew(0, this.x + this.am_duong * 15, this.y + 2 - 10, (int)this.Dir, 33, g);
					this.fraImgEff.drawFrameNew(0, this.x + this.am_duong * 25, this.y + 13 - 10, (int)this.Dir, 33, g);
				}
			}
		}
		bool flag4 = this.f >= 10 && this.f < 14 && !this.checkNullObject(1);
		if (flag4)
		{
			this.fraImgSubEff.drawFrameNew(2 + (this.f - 10) / 2, this.objFireMain.x + this.am_duong * 20, this.objFireMain.y - 50, (int)this.Dir, 3, g);
		}
	}

	// Token: 0x06000216 RID: 534 RVA: 0x00042664 File Offset: 0x00040864
	private void paintEff_Df_2(mGraphics g)
	{
		for (int i = this.VecEff.size() - 1; i >= 0; i--)
		{
			Point point = (Point)this.VecEff.elementAt(i);
			this.fraImgEff.drawFrame(point.frame, point.x, point.y, (int)this.Dir, 33, g);
		}
	}

	// Token: 0x06000217 RID: 535 RVA: 0x000426CC File Offset: 0x000408CC
	private void paintEff_Mr1_2(mGraphics g)
	{
		int trans = 0;
		bool flag = !this.checkNullObject(1) && this.objFireMain.Dir == 2;
		if (flag)
		{
			trans = 2;
		}
		bool flag2 = this.f < 6;
		if (flag2)
		{
			this.fraImgSubEff.drawFrameNew(this.f / 2 % this.fraImgSubEff.nFrame, this.x - 10 * this.am_duong, this.y, trans, 3, g);
		}
		for (int i = this.VecEff.size() - 1; i >= 0; i--)
		{
			Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(i);
			this.fraImgEff.drawFrame(point_Focus.f / 2 % this.fraImgEff.nFrame, point_Focus.x, point_Focus.y, (int)this.Dir, 3, g);
		}
	}

	// Token: 0x06000218 RID: 536 RVA: 0x000427B4 File Offset: 0x000409B4
	private void paintCrocodile2(mGraphics g)
	{
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point = (Point)this.VecEff.elementAt(i);
			this.fraImgEff.drawFrame(2 + point.f % 3, point.x, point.y, (int)this.Dir, 33, g);
		}
	}

	// Token: 0x06000219 RID: 537 RVA: 0x0004281C File Offset: 0x00040A1C
	private void paintCrocodile1(mGraphics g)
	{
		for (int i = 0; i < this.VecSubEff.size(); i++)
		{
			Point point = (Point)this.VecSubEff.elementAt(i);
			this.fraImgSubEff.drawFrame(point.f % this.fraImgSubEff.nFrame, point.x / 10, point.y / 10, 0, 33, g);
		}
		bool flag = this.f <= 2;
		if (flag)
		{
			this.fraImgEff.drawFrame(this.f, this.x, this.y, 0, 33, g);
		}
		bool flag2 = this.f >= 10 && this.f <= 12;
		if (flag2)
		{
			this.fraImgEff.drawFrame(12 - this.f, this.x, this.y, 0, 33, g);
		}
	}

	// Token: 0x0600021A RID: 538 RVA: 0x00042908 File Offset: 0x00040B08
	private void paintZoroS2_L3_SHORT(mGraphics g)
	{
		bool flag = this.f > 2 && this.f < 5;
		if (flag)
		{
			this.fraImgEff.drawFrame(this.f - 13, this.objFireMain.x, this.objFireMain.y - 10, (int)this.Dir, 33, g);
		}
		else
		{
			bool flag2 = this.f > 12 && this.f < 15;
			if (flag2)
			{
				this.fraImgEff.drawFrame(this.f - 23, this.objFireMain.x, this.objFireMain.y - 10, (int)this.Dir, 33, g);
			}
			else
			{
				bool flag3 = this.f > 18 && this.f < 21;
				if (flag3)
				{
					this.fraImgEff.drawFrame(this.f - 29, this.objFireMain.x, this.objFireMain.y - 10, (int)this.Dir, 33, g);
				}
			}
		}
	}

	// Token: 0x0600021B RID: 539 RVA: 0x00042A18 File Offset: 0x00040C18
	public override void update()
	{
		bool flag = this.objFireMain != null && (this.objFireMain.returnAction() || this.objFireMain.Action == 4);
		if (flag)
		{
			this.removeEff();
		}
		else
		{
			base.update();
			int typeEffect = this.typeEffect;
			int num = typeEffect;
			switch (num)
			{
			case -1:
			{
				bool flag2 = this.f < this.fRemove;
				if (flag2)
				{
					this.updateAngleXP();
					this.frame = base.setFrameAngle(this.gocT_Arc);
				}
				bool flag3 = this.VecEff.size() == 0 && this.f > this.fRemove;
				if (flag3)
				{
					this.removeEff();
				}
				int num2;
				for (int i = 0; i < this.VecEff.size(); i = num2 + 1)
				{
					Point point = (Point)this.VecEff.elementAt(i);
					Point point2 = point;
					Point point3 = point2;
					num2 = point2.f;
					point3.f = num2 + 1;
					bool flag4 = point.f / 2 > 3;
					if (flag4)
					{
						this.VecEff.removeElement(point);
						num2 = i;
						i = num2 - 1;
					}
					num2 = i;
				}
				bool flag5 = this.f == this.fRemove;
				if (flag5)
				{
					GameScreen.addEffectEnd(108, 0, this.x, this.y + 10, this.Dir, this.objMainEff);
				}
				break;
			}
			case 0:
				base.updateAngleNormal(this.objBeFireMain, 0);
				break;
			case 1:
			case 37:
				this.updateLuffy1();
				break;
			case 2:
				this.update_Ace_1();
				break;
			case 3:
			case 229:
			case 262:
			case 263:
			case 264:
				this.update_Ace_2();
				break;
			case 4:
			case 230:
				this.update_Aokiji_1();
				break;
			case 5:
			case 231:
				this.update_Aokiji_2();
				break;
			case 6:
			case 232:
				this.update_Smoker_1();
				break;
			case 7:
				this.updateUssopSea1();
				break;
			case 8:
			case 233:
			case 256:
			case 257:
			case 265:
			case 284:
			case 285:
			case 286:
			case 287:
			case 288:
			case 289:
			case 290:
			case 294:
			case 295:
			case 296:
			case 297:
			case 298:
			case 299:
			case 300:
			case 304:
			case 305:
			case 306:
			case 307:
			case 308:
			case 309:
			case 310:
			case 314:
			case 315:
			case 316:
			case 317:
			case 318:
			case 319:
			case 320:
			case 321:
			case 322:
			case 323:
			case 324:
			case 325:
			case 326:
			case 327:
			case 328:
			case 329:
			case 330:
			case 331:
			case 332:
			case 333:
			case 334:
			case 335:
			case 336:
			case 337:
			case 338:
			case 339:
			case 340:
			case 341:
			case 342:
			case 343:
			case 344:
			case 345:
			case 346:
			case 347:
			case 348:
			case 349:
			case 350:
			case 351:
			case 352:
			case 353:
			case 354:
			case 355:
			case 356:
			case 357:
			case 358:
			case 359:
			case 360:
			case 361:
			case 362:
			case 363:
			case 364:
			case 365:
			case 366:
			case 367:
			case 368:
			case 369:
			case 370:
			case 371:
			case 372:
			case 373:
			case 374:
			case 375:
			case 376:
			case 377:
			case 378:
			case 379:
			case 380:
			case 381:
			case 382:
			case 383:
			case 384:
			case 385:
			case 386:
			case 387:
			case 388:
			case 389:
			case 390:
			case 391:
			case 392:
			case 393:
			case 394:
			case 395:
			case 396:
			case 397:
			case 398:
			case 399:
			case 400:
			case 401:
				break;
			case 9:
			case 53:
			case 163:
				this.updateNami1();
				break;
			case 10:
			case 234:
				this.update_Smoker_2();
				break;
			case 11:
				this.updateNamiSea1();
				break;
			case 12:
			case 188:
			case 220:
			case 293:
				this.updateSanji2();
				break;
			case 13:
			case 258:
				this.update_Mon_Smoker_1();
				break;
			case 14:
			case 44:
				this.updateSanji4();
				break;
			case 15:
			case 38:
				this.updateZoro3();
				break;
			case 16:
			case 51:
				this.updateNami4();
				break;
			case 17:
			case 165:
			case 166:
			{
				bool flag6 = this.f >= this.fRemove;
				if (flag6)
				{
					bool flag7 = !this.checkNullObject(1);
					if (flag7)
					{
						this.objFireMain.isTanHinh = false;
					}
					this.removeEff();
				}
				break;
			}
			case 18:
				this.update_Mon_Smoker_2();
				break;
			case 19:
				this.updateZoroSea3();
				break;
			case 20:
				this.update_Mon_Valentine();
				break;
			case 21:
			case 33:
			case 176:
				this.updateLuffyS1();
				break;
			case 22:
			case 98:
				this.updateCabaji_2();
				break;
			case 23:
				this.update_Mon_Mr5();
				break;
			case 24:
			case 80:
			{
				bool flag8 = this.f == 7 || this.f == 2 || this.f == 12;
				if (flag8)
				{
					bool flag9 = !this.checkNullObject(1);
					if (flag9)
					{
						this.objFireMain.isPaintWeapon = true;
					}
					GameScreen.addEffectEnd(1, 0, this.toX + CRes.random_Am_0(15), this.toY + CRes.random_Am_0(15), this.Dir, this.objMainEff);
					bool flag10 = this.typeEffect == 24 && !this.checkNullObject(2);
					if (flag10)
					{
						GameScreen.addEffectEnd(4, 0, this.objBeFireMain.x + CRes.random_Am_0(15), this.objBeFireMain.y - CRes.random(0, this.objBeFireMain.hOne / 4 * 3) - 10, this.Dir, this.objMainEff);
					}
				}
				bool flag11 = this.f >= this.fRemove;
				if (flag11)
				{
					this.removeEff();
				}
				break;
			}
			case 25:
			case 235:
				this.update_Crocodile_1();
				break;
			case 26:
			case 236:
				this.update_Crocodile_2();
				break;
			case 27:
			{
				bool flag12 = this.f >= this.fRemove;
				if (flag12)
				{
					bool flag13 = !this.checkNullObject(2);
					if (flag13)
					{
						base.setAva(0, this.objBeFireMain);
						GameScreen.addEffectEnd(36, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
					}
					this.removeEff();
				}
				break;
			}
			case 28:
			{
				bool flag14 = this.f >= this.fRemove;
				if (flag14)
				{
					bool flag15 = !this.checkNullObject(2);
					if (flag15)
					{
						base.setAva(0, this.objBeFireMain);
						GameScreen.addEffectEnd_ObjTo(102, this.subType, this.toX, this.toY, this.objBeFireMain.ID, this.objBeFireMain.typeObject, this.Dir, null);
					}
					this.removeEff();
				}
				break;
			}
			case 29:
				this.updateZoro8();
				break;
			case 30:
			{
				bool flag16 = this.f >= this.fRemove;
				if (flag16)
				{
					GameScreen.addEffectEnd(3, 0, this.x, this.y, this.Dir, this.objMainEff);
					this.removeEff();
				}
				break;
			}
			case 31:
			case 55:
			case 56:
			case 191:
			case 223:
				this.updateNami5();
				break;
			case 32:
				this.updateWapol_1();
				break;
			case 34:
				this.updateLuffy6();
				break;
			case 35:
				this.updateLuffy_S2_L2();
				break;
			case 36:
			{
				bool flag17 = this.f >= this.fRemove;
				if (flag17)
				{
					base.setAva(1, this.objBeFireMain);
					this.removeEff();
				}
				break;
			}
			case 39:
				this.updateWapol_3();
				break;
			case 40:
				this.update_Wapol_4();
				break;
			case 41:
				this.updateZoroS2_L1_NEW();
				break;
			case 42:
				this.updateZoroSea1();
				break;
			case 43:
				this.updateZoroSea2();
				break;
			case 45:
				this.updateMr3_1();
				break;
			case 46:
			{
				bool flag18 = this.f >= this.fRemove;
				if (flag18)
				{
					this.removeEff();
				}
				break;
			}
			case 47:
			case 48:
				this.updateSanji1();
				break;
			case 49:
			case 50:
				this.updateSanjiSkill3_Lv1();
				break;
			case 52:
			case 189:
			case 221:
			case 311:
				this.updateNamiSkill1_Lv3();
				break;
			case 54:
				this.updateMr3_2();
				break;
			case 57:
				this.updateUssop2();
				break;
			case 58:
				this.updateUssopSkill1_Lv3();
				break;
			case 59:
			case 60:
			case 62:
			{
				bool flag19 = this.f >= this.fRemove;
				if (flag19)
				{
					this.removeEff();
				}
				break;
			}
			case 61:
			{
				bool flag20 = this.f >= this.fRemove;
				if (flag20)
				{
					GameScreen.addEffectEnd(60, 2, this.toX, this.toY, this.Dir, this.objMainEff);
					this.removeEff();
				}
				break;
			}
			case 63:
			case 190:
			case 222:
			case 312:
				this.updateNami1_SHORT();
				break;
			case 64:
			case 66:
				this.updateUssop_Skill2();
				break;
			case 65:
			{
				bool flag21 = this.f >= this.fRemove;
				if (flag21)
				{
					this.addSound(5);
					this.addVir(3, 5, 10, false);
					GameScreen.addEffectEnd(35, 0, this.toX, this.toY, this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(21, 0, this.toX, this.toY, this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(107, 0, this.toX, this.toY, this.Dir, this.objMainEff);
					base.setAva(2, this.objBeFireMain);
					this.removeEff();
				}
				break;
			}
			case 67:
			case 68:
			case 69:
			case 194:
				this.updateUssopSkill3();
				break;
			case 70:
			{
				bool flag22 = this.f == 4;
				if (flag22)
				{
					this.x += this.am_duong * 20;
					this.y -= 10;
					int xdich = this.toX - this.x;
					int ydich = this.toY - this.y;
					base.create_Speed(xdich, ydich, null);
					this.fRemove += 4;
				}
				bool flag23 = this.f >= this.fRemove;
				if (flag23)
				{
					GameScreen.addEffectEnd(4, 0, this.toX + CRes.random_Am_0(15), this.toY + CRes.random_Am_0(15), this.Dir, this.objMainEff);
					this.removeEff();
				}
				break;
			}
			case 71:
			case 72:
			case 75:
			case 92:
			case 145:
			case 146:
			case 147:
			case 148:
			{
				bool flag24 = this.f >= this.fRemove;
				if (flag24)
				{
					bool flag25 = !this.checkNullObject(1);
					if (flag25)
					{
						this.objFireMain.isPaintWeapon = true;
					}
					GameScreen.addEffectEnd(1, 0, this.toX + CRes.random_Am_0(15), this.toY + CRes.random_Am_0(15), this.Dir, this.objMainEff);
					this.removeEff();
				}
				break;
			}
			case 73:
			case 78:
			{
				bool flag26 = this.f == 5 || this.f == 0;
				if (flag26)
				{
					bool flag27 = !this.checkNullObject(1);
					if (flag27)
					{
						this.objFireMain.isPaintWeapon = true;
					}
					GameScreen.addEffectEnd(1, 0, this.toX + CRes.random_Am_0(15), this.toY + CRes.random_Am_0(15), this.Dir, this.objMainEff);
				}
				bool flag28 = this.f >= this.fRemove;
				if (flag28)
				{
					this.removeEff();
				}
				break;
			}
			case 74:
				this.update_Mon_5();
				break;
			case 76:
			{
				bool flag29 = this.f >= this.fRemove;
				if (flag29)
				{
					GameScreen.addEffectEnd(8, 0, this.toX, this.toY, this.Dir, this.objMainEff);
					this.removeEff();
				}
				break;
			}
			case 77:
				this.updateAlvida2();
				break;
			case 79:
			{
				bool flag30 = this.f == 6 || this.f == 0;
				if (flag30)
				{
					bool flag31 = !this.checkNullObject(1);
					if (flag31)
					{
						this.objFireMain.isPaintWeapon = true;
					}
					GameScreen.addEffectEnd(1, 0, this.toX + CRes.random_Am_0(15), this.toY + CRes.random_Am_0(15), this.Dir, this.objMainEff);
				}
				bool flag32 = this.f >= this.fRemove;
				if (flag32)
				{
					this.removeEff();
				}
				break;
			}
			case 81:
			case 143:
			case 149:
				this.updateMon10();
				break;
			case 82:
			case 144:
				this.updateMon11();
				break;
			case 83:
			case 180:
			case 212:
				this.updateLuffyS1_L3_SHORT();
				break;
			case 84:
			case 181:
			case 213:
			case 272:
				this.updateLuffyS2_NEW_SHORT();
				break;
			case 85:
			case 182:
				this.updateLuffyS3_New();
				break;
			case 86:
			case 183:
			case 215:
				this.updateZoro_S1_L3_SHORT();
				break;
			case 87:
			case 184:
			case 216:
				this.updateZoroS2_New();
				break;
			case 88:
				this.updateMorgan_1();
				break;
			case 89:
				this.updateMorgan_2();
				break;
			case 90:
			case 91:
			{
				bool flag33 = this.f > this.fRemove;
				if (flag33)
				{
					this.addSound(2);
					GameScreen.addEffectEnd(3, 0, this.toX, this.toY, this.Dir, this.objMainEff);
					this.removeEff();
				}
				break;
			}
			case 93:
				this.updateMohji_1();
				break;
			case 94:
				this.updateMohji_2();
				break;
			case 95:
				this.updateBuggy_1();
				break;
			case 96:
				this.updateBuggy_2();
				break;
			case 97:
				this.updateCabaji_1();
				break;
			case 99:
			{
				bool flag34 = this.f == 2;
				if (flag34)
				{
					this.addSound(10);
				}
				bool flag35 = this.f == 2 || this.f == 8;
				if (flag35)
				{
					GameScreen.addEffectEnd(3, 0, this.toX, this.toY, this.Dir, this.objMainEff);
				}
				bool flag36 = this.f > this.fRemove;
				if (flag36)
				{
					base.setAva(0, this.objBeFireMain);
					this.removeEff();
				}
				break;
			}
			case 100:
				this.updateNyaban_2();
				break;
			case 101:
				this.updateNyaban_3();
				break;
			case 102:
				this.updateJango_1();
				break;
			case 103:
				this.updateKuro_1();
				break;
			case 104:
				this.updateKuro_2();
				break;
			case 105:
			case 107:
			{
				bool flag37 = this.f >= this.fRemove;
				if (flag37)
				{
					this.addSound(14);
					this.addVir(3, 5, 10, false);
					GameScreen.addEffectEnd(35, 0, this.x, this.y, this.Dir, this.objMainEff);
					base.setAva(1, this.objBeFireMain);
					this.removeEff();
				}
				break;
			}
			case 106:
				this.updatePearl_2();
				break;
			case 108:
				this.updateGhin_2();
				break;
			case 109:
				this.updateDonKrieg_1();
				break;
			case 110:
				this.updateDonKrieg_2();
				break;
			case 111:
				this.updateDonKrieg_3();
				break;
			case 112:
			case 270:
				this.updateHachi_1();
				break;
			case 113:
			case 150:
			case 151:
			case 152:
			case 153:
				this.updateHachi_2();
				break;
			case 114:
				this.updateChu_1();
				break;
			case 115:
				this.updateChu_2();
				break;
			case 116:
				this.updateKurobi_1();
				break;
			case 117:
				this.updateKurobi_2();
				break;
			case 118:
				this.updateArlong_1();
				break;
			case 119:
				this.updateArlong_2();
				break;
			case 120:
				this.updateArlong_3();
				break;
			case 121:
				this.update_Zoro_s3_l1_New();
				break;
			case 122:
				this.update_Zoro_s3_l2_New();
				break;
			case 123:
			case 185:
			case 217:
				this.update_Zoro_s3_l3_New();
				break;
			case 124:
			case 186:
			case 218:
				this.updateSanji_S1_L3_SHORT();
				break;
			case 125:
			case 187:
				this.updateSanji_S2_L3_New_SHORT();
				break;
			case 126:
			case 192:
				this.updateUssopSkill1_Lv3_SHORT();
				break;
			case 127:
			case 193:
			case 225:
				this.updateUssop_S2_L3_New();
				break;
			case 128:
			{
				bool flag38 = this.f == 0 || this.f == 8;
				if (flag38)
				{
					GameScreen.addEffectEnd(8, 0, this.toX + CRes.random_Am_0(15), this.toY + CRes.random_Am_0(15), this.Dir, this.objMainEff);
				}
				bool flag39 = this.f >= this.fRemove;
				if (flag39)
				{
					this.removeEff();
				}
				break;
			}
			case 129:
			case 130:
			{
				bool flag40 = this.f == 0 || this.f == 8 || this.f == 14;
				if (flag40)
				{
					GameScreen.addEffectEnd(8, 0, this.toX + CRes.random_Am_0(15), this.toY + CRes.random_Am_0(15), this.Dir, this.objMainEff);
				}
				bool flag41 = this.f >= this.fRemove;
				if (flag41)
				{
					this.removeEff();
				}
				break;
			}
			case 131:
			case 132:
				this.updateLuffyMon16_17();
				break;
			case 133:
				this.updateLuffySea1();
				break;
			case 134:
			case 135:
				this.updateLuffySea2();
				break;
			case 136:
				this.updateSanjiSea1();
				break;
			case 137:
			case 138:
				this.updateSanjiSea2();
				break;
			case 139:
				this.updateNamiSea2();
				break;
			case 140:
				this.updateNamiSea3();
				break;
			case 141:
				this.updateUssopSea2();
				break;
			case 142:
				this.updateUssopSea3();
				break;
			case 154:
				this.updateZoro1();
				break;
			case 155:
				this.updateZoro2();
				break;
			case 156:
				this.updateLuffyS1_NEW();
				break;
			case 157:
				this.updateZoroS1_New();
				break;
			case 158:
			case 177:
				this.updateSanji_S1_L3_New();
				break;
			case 159:
				this.updateUssopSkill1_Lv3_New();
				break;
			case 160:
				this.updateLuffyS2_NEW();
				break;
			case 161:
				this.updateZoroS2_New_SHORT();
				break;
			case 162:
				this.updateSanji_S2_L3_New();
				break;
			case 164:
			case 227:
			{
				int num2;
				for (int j = 0; j < this.VecEff.size(); j = num2 + 1)
				{
					Point point4 = (Point)this.VecEff.elementAt(j);
					point4.update();
					Point point2 = point4;
					Point point5 = point2;
					num2 = point2.frame;
					point5.frame = num2 + 1;
					bool flag42 = point4.dis == 0;
					if (flag42)
					{
						bool flag43 = point4.frame >= this.fraImgEff.nFrame;
						if (flag43)
						{
							point4.frame = 0;
						}
					}
					else
					{
						bool flag44 = point4.frame >= this.fraImgSubEff.nFrame;
						if (flag44)
						{
							point4.frame = 0;
						}
					}
					bool flag45 = point4.f >= point4.fRe;
					if (flag45)
					{
						bool flag46 = CRes.random(2) == 1;
						if (flag46)
						{
							base.setAva(0, this.objBeFireMain);
						}
						this.VecEff.removeElement(point4);
						num2 = j;
						j = num2 - 1;
					}
					num2 = j;
				}
				bool flag47 = this.f <= this.fRemove - 5 && this.f % 3 == 0;
				if (flag47)
				{
					Point point6 = new Point();
					point6.x = this.x + this.am_duong * 15;
					point6.y = this.y;
					point6.vx = this.am_duong * (5 + CRes.random(2));
					bool flag48 = this.typeEffect == 227;
					if (flag48)
					{
						point6.vx = this.am_duong * (5 + CRes.random(2));
					}
					point6.vy = CRes.random_Am_0(2);
					point6.fRe = 6 + CRes.random(3);
					point6.dis = ((CRes.random(3) != 0) ? 1 : 0);
					this.VecEff.addElement(point6);
					bool flag49 = CRes.random(2) == 0;
					if (flag49)
					{
						this.addSound(4);
						bool flag50 = !this.checkNullObject(2);
						if (flag50)
						{
							GameScreen.addEffectEnd(108, 1, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
						}
					}
				}
				bool flag51 = this.f >= this.fRemove && this.VecEff.size() == 0;
				if (flag51)
				{
					this.removeEff();
				}
				break;
			}
			case 167:
				this.updateMissMS_1();
				break;
			case 168:
				this.update_Mr1_1();
				break;
			case 169:
			case 237:
				this.updateSet_1();
				break;
			case 170:
			case 238:
				this.updateSet_2();
				break;
			case 171:
			case 239:
				this.updateNamThach_1();
				break;
			case 172:
			case 240:
				this.update_Nham_thach_2();
				break;
			case 173:
				this.update_Mr1_2();
				break;
			case 174:
				this.update_DF_1();
				break;
			case 175:
				this.update_DF_2();
				break;
			case 178:
				this.update_Mr0_1();
				break;
			case 179:
			case 241:
				this.update_Pell_1();
				break;
			case 195:
				this.update_Enel_1();
				break;
			case 196:
				this.update_Enel_2();
				break;
			case 197:
				this.update_Enel_3();
				break;
			case 198:
				this.update_Satori_1();
				break;
			case 199:
				this.update_Satori_2();
				break;
			case 200:
				this.update_Ohm_1();
				break;
			case 201:
				this.update_Ohm_2();
				break;
			case 202:
				this.update_Gedatsu_1();
				break;
			case 203:
				this.update_Gedatsu_2();
				break;
			case 204:
				this.update_Shura_1();
				break;
			case 205:
				this.update_Shura_2();
				break;
			case 206:
			case 207:
				this.update_Linh_Troi();
				break;
			case 208:
				this.update_Tru_1();
				break;
			case 209:
			case 242:
				this.update_Lucci_1();
				break;
			case 210:
			case 243:
				this.update_Dong_Dat_1();
				break;
			case 211:
			case 244:
				this.update_Dong_Dat_2();
				break;
			case 214:
			case 273:
				this.updateLuffyS3_L5();
				break;
			case 219:
			{
				bool flag52 = this.f >= this.fRemove || this.checkNullObject(3);
				if (flag52)
				{
					this.objFireMain.isTanHinh = false;
					this.removeEff();
				}
				bool flag53 = this.f == 5 || this.f == 14;
				if (flag53)
				{
					bool flag54 = MainObject.getDistance(this.objFireMain.x, this.objFireMain.y, this.objBeFireMain.x, this.objBeFireMain.y) < 160;
					if (flag54)
					{
						this.objFireMain.x = this.objBeFireMain.x;
						this.objFireMain.y = this.objBeFireMain.y;
					}
					this.objFireMain.isTanHinh = true;
					this.changeDir();
					this.am_duong = -1;
					bool flag55 = this.Dir == 2;
					if (flag55)
					{
						this.am_duong = 1;
					}
					this.objFireMain.Dir = (int)this.Dir;
					this.x = this.objBeFireMain.x + this.am_duong * 30;
					this.y = this.objBeFireMain.y;
				}
				bool flag56 = this.f == 9 || this.f == 19;
				if (flag56)
				{
					this.objFireMain.isTanHinh = true;
					this.changeDir();
					this.am_duong = -1;
					bool flag57 = this.Dir == 2;
					if (flag57)
					{
						this.am_duong = 1;
					}
					this.objFireMain.Dir = (int)this.Dir;
					this.x = this.objBeFireMain.x + this.am_duong * 30;
					this.y = this.objBeFireMain.y;
				}
				bool flag58 = this.f == 6 || this.f == 11 || this.f == 15 || this.f == 20;
				if (flag58)
				{
					sbyte subtype = 0;
					bool flag59 = this.f == 6 || this.f == 15;
					if (flag59)
					{
						bool flag60 = this.isAddSound;
						if (flag60)
						{
							mSound.playSound(14, mSound.volumeSound);
						}
						subtype = 1;
					}
					GameScreen.addEffectEnd(108, 7, this.objBeFireMain.x - this.am_duong * 5, this.objBeFireMain.y - this.objBeFireMain.hOne / 2 + CRes.random_Am_0(10), this.Dir, this.objMainEff);
					this.addVir(5, 5, 10, true);
					GameScreen.addEffectEnd(36, (int)subtype, this.objBeFireMain.x - this.am_duong * 5, this.objBeFireMain.y - this.objBeFireMain.hOne / 2 + CRes.random_Am_0(10), this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(25, 4, this.objBeFireMain.x - this.am_duong * 5, this.objBeFireMain.y - this.objBeFireMain.hOne / 2 + CRes.random_Am_0(10), this.Dir, this.objMainEff);
					base.setAva(1, this.objBeFireMain);
				}
				bool flag61 = this.f == 24;
				if (flag61)
				{
					this.objFireMain.isTanHinh = false;
					this.objFireMain.x = this.x1000;
					this.objFireMain.y = this.y1000;
				}
				break;
			}
			case 224:
			case 301:
				this.updateUssopS1_L5();
				break;
			case 226:
				this.updateUssopS3_L5();
				break;
			case 228:
			case 259:
			case 260:
			case 261:
				this.update_Ace_1_L2();
				break;
			case 245:
			case 251:
			{
				int num2;
				for (int k = 0; k < this.VecEff.size(); k = num2 + 1)
				{
					Point point7 = (Point)this.VecEff.elementAt(k);
					Point point2 = point7;
					Point point8 = point2;
					num2 = point2.f;
					point8.f = num2 + 1;
					bool flag62 = point7.f >= point7.fRe;
					if (flag62)
					{
						this.VecEff.removeElementAt(k);
						num2 = k;
						k = num2 - 1;
					}
					num2 = k;
				}
				bool flag63 = this.f == 6 && !this.checkNullObject(1);
				if (flag63)
				{
					this.objFireMain.isTanHinh = true;
					Point point9 = new Point(this.objFireMain.x + this.am_duong * 30, this.objFireMain.y - this.objFireMain.hOne / 2);
					point9.fRe = 6;
					point9.dis = this.objFireMain.type_left_right;
					this.VecEff.addElement(point9);
				}
				bool flag64 = this.f == 7 && MainObject.getDistance(this.objMainEff.x, this.objMainEff.y, this.objBeFireMain.x, this.objBeFireMain.y) < 260 && !this.checkNullObject(3);
				if (flag64)
				{
					this.objFireMain.x = this.objBeFireMain.x - this.am_duong * 30;
					this.objFireMain.y = this.objBeFireMain.y;
					Point point10 = new Point(this.objFireMain.x - this.am_duong * 30, this.objFireMain.y - this.objFireMain.hOne / 2);
					point10.fRe = 6;
					point10.dis = this.objFireMain.type_left_right;
					this.VecEff.addElement(point10);
				}
				bool flag65 = this.f == 8 && !this.checkNullObject(1);
				if (flag65)
				{
					this.objFireMain.isTanHinh = false;
				}
				bool flag66 = this.typeEffect == 251 && this.f >= 8 && this.f <= 20 && !this.checkNullObject(3);
				if (flag66)
				{
					this.objFireMain.dy = (this.f - 8) / 3 * 12;
					this.objBeFireMain.dy = this.objFireMain.dy;
				}
				bool flag67 = !this.checkNullObject(2) && (this.f == 9 || this.f == 12 || this.f == 15 || this.f == 18);
				if (flag67)
				{
					bool flag68 = this.isAddSound;
					if (flag68)
					{
						mSound.playSound(7, mSound.volumeSound);
					}
					GameScreen.addEffectEnd(10, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.dy - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
					bool flag69 = this.f == 9 || this.f == 15;
					if (flag69)
					{
						base.setAva(1, this.objBeFireMain);
					}
				}
				bool flag70 = this.f >= this.fRemove && this.VecEff.size() == 0;
				if (flag70)
				{
					this.removeEff();
				}
				break;
			}
			case 246:
			case 253:
			{
				int num2;
				for (int l = 0; l < this.VecEff.size(); l = num2 + 1)
				{
					Point point11 = (Point)this.VecEff.elementAt(l);
					point11.update();
					bool flag71 = point11.frame == 0 && point11.f == point11.fRe;
					if (flag71)
					{
						point11.frame = 1;
						point11.vx = 0;
						point11.vy = 0;
						point11.fSmall = CRes.random(16, 24);
						GameScreen.addEffectEnd(133, 1, point11.x, point11.y, this.Dir, this.objMainEff);
						GameScreen.addEffectEnd(59, 0, point11.x, point11.y + 5, this.Dir, this.objMainEff);
						bool flag72 = point11.obj != null;
						if (flag72)
						{
							base.setAva(1, point11.obj);
						}
					}
					bool flag73 = point11.frame == 1 && point11.f == point11.fRe + point11.fSmall;
					if (flag73)
					{
						point11.frame = 2;
						point11.f = 0;
					}
					bool flag74 = point11.frame == 2 && point11.f == 4;
					if (flag74)
					{
						point11.frame = 3;
						point11.f = 0;
					}
					bool flag75 = point11.frame == 3 && point11.f == 2;
					if (flag75)
					{
						this.VecEff.removeElement(point11);
						num2 = l;
						l = num2 - 1;
					}
					num2 = l;
				}
				bool flag76 = this.f == 12;
				if (flag76)
				{
					bool flag77 = this.isAddSound;
					if (flag77)
					{
						this.addSound(14);
					}
					for (int m = 0; m < this.vecObjsBeFire.size(); m = num2 + 1)
					{
						Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(m);
						bool flag78 = object_Effect_Skill == null;
						if (!flag78)
						{
							MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
							bool flag79 = mainObject == null;
							if (!flag79)
							{
								Point point12 = new Point();
								point12.vy = CRes.random(30, 40);
								point12.dis = CRes.random(14, 26);
								point12.fRe = 4 + m;
								point12.x = mainObject.x;
								point12.y = mainObject.y + CRes.random(5);
								bool flag80 = this.typeEffect == 253;
								if (flag80)
								{
									for (int n = 0; n < 2; n = num2 + 1)
									{
										Point point13 = new Point();
										point13.vy = CRes.random(30, 40);
										point13.dis = point12.dis + 10;
										point13.fRe = 5 + m + n;
										point13.x = mainObject.x - 25 + n * 50;
										point13.y = point12.y - point13.vy * point13.fRe;
										point13.frame = 0;
										this.VecEff.addElement(point13);
										num2 = n;
									}
								}
								Point point2 = point12;
								point2.y += -point12.vy * point12.fRe;
								point12.frame = 0;
								point12.obj = mainObject;
								this.VecEff.addElement(point12);
							}
						}
						num2 = m;
					}
					bool flag81 = !this.checkNullObject(1);
					if (flag81)
					{
						int num3 = CRes.random(1, 3);
						for (int num4 = 0; num4 < num3; num4 = num2 + 1)
						{
							Point point14 = new Point();
							point14.vy = CRes.random(30, 40);
							point14.dis = CRes.random(14, 26);
							point14.fRe = 4 + this.vecObjsBeFire.size() + num4;
							point14.x = this.objBeFireMain.x + CRes.random_Am_0(100);
							point14.y = this.objBeFireMain.y + CRes.random_Am_0(80);
							point14.frame = 0;
							bool flag82 = GameCanvas.loadmap.getTile(point14.x, point14.y) == 0;
							if (flag82)
							{
								Point point2 = point14;
								point2.y += -(point14.vy * point14.fRe) + CRes.random(5);
								this.VecEff.addElement(point14);
							}
							num2 = num4;
						}
					}
				}
				bool flag83 = this.f >= this.fRemove && this.VecEff.size() == 0;
				if (flag83)
				{
					this.removeEff();
				}
				break;
			}
			case 247:
			case 254:
			{
				int num2;
				for (int num5 = 0; num5 < this.VecSubEff.size(); num5 = num2 + 1)
				{
					Point point15 = (Point)this.VecSubEff.elementAt(num5);
					Point point2 = point15;
					Point point16 = point2;
					num2 = point2.f;
					point16.f = num2 + 1;
					bool flag84 = point15.f >= point15.fRe;
					if (flag84)
					{
						this.VecSubEff.removeElement(point15);
					}
					num2 = num5;
				}
				for (int num6 = 0; num6 < this.VecEff.size(); num6 = num2 + 1)
				{
					Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(num6);
					point_Focus.update_Vx_Vy();
					bool flag85 = point_Focus.f >= point_Focus.fRe + 10;
					if (flag85)
					{
						this.VecEff.removeElement(point_Focus);
					}
					else
					{
						int num7 = CRes.random(1, 4);
						for (int num8 = 0; num8 < num7; num8 = num2 + 1)
						{
							Point point17 = new Point(point_Focus.x / 10 + CRes.random_Am_0(4) - point_Focus.vx / 10, point_Focus.y / 10 + CRes.random_Am_0(4) - point_Focus.vy / 10);
							point17.fRe = 4;
							bool flag86 = this.typeEffect == 254 && num8 == 0 && CRes.random(3) == 0;
							if (flag86)
							{
								point17.fRe = 5;
							}
							this.VecSubEff.addElement(point17);
							num2 = num8;
						}
					}
					bool flag87 = point_Focus.f == point_Focus.fRe && !this.checkNullObject(2);
					if (flag87)
					{
						base.setAva(1, this.objBeFireMain);
						GameScreen.addEffectEnd(8, 0, point_Focus.x / 10, point_Focus.y / 10, this.Dir, this.objMainEff);
						bool flag88 = this.typeEffect == 254;
						if (flag88)
						{
							GameScreen.addEffectEnd(108, 1, point_Focus.x / 10, point_Focus.y / 10 + CRes.random_Am_0(10), this.Dir, this.objMainEff);
						}
					}
					num2 = num6;
				}
				bool flag89 = this.f == 10 || this.f == 15;
				if (flag89)
				{
					bool flag90 = this.isAddSound;
					if (flag90)
					{
						this.addSound(18);
					}
					Point_Focus point_Focus2 = new Point_Focus(this.x * 10, this.y * 10);
					bool flag91 = !this.checkNullObject(2);
					if (flag91)
					{
						int num9 = this.objBeFireMain.x - this.x;
						int num10 = this.objBeFireMain.y - this.objBeFireMain.hOne / 2 - this.y;
						point_Focus2 = base.create_Speed(num9 * 10, num10 * 10, point_Focus2, this.x * 10, this.y * 10, this.objBeFireMain.x * 10, (this.objBeFireMain.y - this.objBeFireMain.hOne / 2) * 10);
						point_Focus2.Dir = 0;
						bool flag92 = num9 > 0;
						if (flag92)
						{
							point_Focus2.Dir = 2;
						}
						this.VecEff.addElement(point_Focus2);
					}
				}
				bool flag93 = this.f >= this.fRemove && this.VecEff.size() == 0;
				if (flag93)
				{
					this.removeEff();
				}
				break;
			}
			case 248:
			case 255:
			{
				bool flag94 = !this.checkNullObject(1);
				if (flag94)
				{
					bool flag95 = this.f == 6 || this.f == 11;
					if (flag95)
					{
						this.objFireMain.isTanHinh = true;
					}
					bool flag96 = this.f == 7;
					if (flag96)
					{
						this.objFireMain.isTanHinh = false;
					}
					bool flag97 = this.f == 12;
					if (flag97)
					{
						bool flag98 = this.isAddSound;
						if (flag98)
						{
							this.addSound(51);
						}
						bool flag99 = MainObject.getDistance(this.objFireMain.x, this.objFireMain.y, this.objBeFireMain.x, this.objBeFireMain.y) < 260;
						if (flag99)
						{
							this.objFireMain.x = this.objBeFireMain.x;
							this.objFireMain.y = this.objBeFireMain.y + 5;
							this.objFireMain.dy = 400;
						}
					}
					bool flag100 = this.f == 14;
					if (flag100)
					{
						this.objFireMain.isTanHinh = false;
						this.objFireMain.dy = 400;
					}
					bool flag101 = this.f >= 15 && this.f <= 19;
					if (flag101)
					{
						bool flag102 = this.typeEffect == 255;
						if (flag102)
						{
							GameScreen.addEffectEnd(108, 5, this.objFireMain.x, this.objFireMain.y - this.objFireMain.dy, this.Dir, this.objMainEff);
							GameScreen.addEffectEnd(108, 5, this.objFireMain.x, this.objFireMain.y - this.objFireMain.dy + 40, this.Dir, this.objMainEff);
						}
						bool flag103 = this.objFireMain.dy >= 0;
						if (flag103)
						{
							MainObject objFireMain = this.objFireMain;
							objFireMain.dy -= 80;
						}
					}
					bool flag104 = this.f == 19;
					if (flag104)
					{
						bool flag105 = this.isAddSound;
						if (flag105)
						{
							this.addSound(5);
						}
						this.objFireMain.dy = 0;
						base.setAva(1, this.objBeFireMain);
						GameScreen.addEffectEnd(148, 0, this.objFireMain.x, this.objFireMain.y, this.Dir, this.objMainEff);
						bool flag106 = this.typeEffect == 255;
						if (flag106)
						{
							GameScreen.addEffectEnd(54, 12, this.objFireMain.x, this.objFireMain.y, this.Dir, this.objMainEff);
						}
						GameScreen.addEffectEnd(45, 0, this.objFireMain.x, this.objFireMain.y + 25, this.Dir, this.objMainEff);
					}
				}
				bool flag107 = this.f > this.fRemove;
				if (flag107)
				{
					this.removeEff();
				}
				break;
			}
			case 249:
			case 252:
			{
				int num2;
				for (int num11 = 0; num11 < this.VecEff.size(); num11 = num2 + 1)
				{
					Point point18 = (Point)this.VecEff.elementAt(num11);
					Point point2 = point18;
					Point point19 = point2;
					num2 = point2.f;
					point19.f = num2 + 1;
					bool flag108 = this.typeEffect == 252;
					if (flag108)
					{
						point18.limitY = (point18.f - 1) / 3 * 12;
						point18.obj.dy = point18.limitY;
					}
					bool flag109 = point18.f == 1 || point18.f == 4 || point18.f == 7 || point18.f == 10;
					if (flag109)
					{
						GameScreen.addEffectEnd(10, 0, point18.obj.x, point18.obj.y - point18.obj.dy - point18.obj.hOne / 2, this.Dir, this.objMainEff);
						bool flag110 = point18.f == 1 || point18.f == 7;
						if (flag110)
						{
							base.setAva(1, point18.obj);
						}
					}
					bool flag111 = point18.f >= point18.fRe;
					if (flag111)
					{
						this.VecEff.removeElementAt(num11);
						num2 = num11;
						num11 = num2 - 1;
					}
					num2 = num11;
				}
				bool flag112 = this.f == 7 && !this.checkNullObject(1);
				if (flag112)
				{
					this.objFireMain.isTanHinh = true;
				}
				bool flag113 = this.f == 8;
				if (flag113)
				{
					for (int num12 = 0; num12 < this.vecObjsBeFire.size(); num12 = num2 + 1)
					{
						Object_Effect_Skill object_Effect_Skill2 = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(num12);
						bool flag114 = object_Effect_Skill2 == null;
						if (!flag114)
						{
							MainObject mainObject2 = MainObject.get_Object((int)object_Effect_Skill2.ID, object_Effect_Skill2.tem);
							bool flag115 = mainObject2 != null;
							if (flag115)
							{
								Point point20 = new Point();
								point20.dis = CRes.random(2) * 2;
								point20.fSmall = -1;
								bool flag116 = point20.dis == 2;
								if (flag116)
								{
									point20.fSmall = 1;
								}
								int num13 = 30 * point20.fSmall;
								point20.x = mainObject2.x - num13;
								point20.fRe = this.mframeSuper.Length;
								point20.y = mainObject2.y - mainObject2.hOne / 2;
								point20.frame = CRes.random(4) * 3;
								point20.obj = mainObject2;
								this.VecEff.addElement(point20);
							}
						}
						num2 = num12;
					}
				}
				bool flag117 = !this.checkNullObject(2) && (this.f == 9 || this.f == 12 || this.f == 15 || this.f == 18);
				if (flag117)
				{
					bool flag118 = this.isAddSound;
					if (flag118)
					{
						mSound.playSound(7, mSound.volumeSound);
					}
					bool flag119 = CRes.random(2) == 0;
					if (flag119)
					{
						mSound.playSound(9, mSound.volumeSound);
					}
				}
				bool flag120 = this.f == 20 && !this.checkNullObject(1);
				if (flag120)
				{
					this.objFireMain.isTanHinh = false;
				}
				bool flag121 = this.f >= this.fRemove && this.VecEff.size() == 0;
				if (flag121)
				{
					this.removeEff();
				}
				break;
			}
			case 250:
				this.update_Tru_2();
				break;
			case 266:
				this.updateRankyaku();
				break;
			case 267:
				this.updateShigan();
				break;
			case 268:
				this.updateDoor();
				break;
			case 269:
				this.updateDoor2();
				break;
			case 271:
				this.update_Luffy_S1_L6();
				break;
			case 274:
			case 275:
				this.updateXaPhong();
				break;
			case 276:
				this.updateSoi();
				break;
			case 277:
				this.updateSoi2();
				break;
			case 278:
			case 279:
				this.updateHuou();
				break;
			case 280:
			{
				bool flag122 = this.x > this.toX;
				if (flag122)
				{
					this.x = this.toX;
					bool flag123 = this.y < this.toY + 20;
					if (flag123)
					{
						this.y += 5;
					}
				}
				bool flag124 = this.f == 15;
				if (flag124)
				{
					GameScreen.addEffectEnd(178, 0, this.toX, this.toY - 55, this.Dir, this.objMainEff);
				}
				bool flag125 = this.f == 10;
				if (flag125)
				{
					GameScreen.addEffectEnd(119, 4, this.objFireMain.x + 20, this.objFireMain.y - this.objFireMain.hOne / 2 + 2, this.Dir, this.objMainEff);
				}
				bool flag126 = this.f >= this.fRemove;
				if (flag126)
				{
					this.removeEff();
				}
				break;
			}
			case 281:
				this.updateZoro_S1_L6();
				break;
			case 282:
				this.updateZoroS2_L6();
				break;
			case 283:
				this.update_Zoro_s3_l6();
				break;
			case 291:
			{
				bool flag127 = this.f >= this.fRemove || this.checkNullObject(3);
				if (flag127)
				{
					this.objFireMain.isTanHinh = false;
					this.removeEff();
				}
				bool flag128 = this.f == 0 || this.f == 8 || this.f == 15 || this.f == 25;
				if (flag128)
				{
					this.objFireMain.isTanHinh = true;
					this.am_duong = -1;
					bool flag129 = this.Dir == 2;
					if (flag129)
					{
						this.am_duong = 1;
					}
					this.objFireMain.Dir = (int)this.Dir;
					this.x = this.objBeFireMain.x + this.am_duong * 30;
					this.y = this.objBeFireMain.y;
					bool flag130 = this.f == 8 || this.f == 15;
					if (flag130)
					{
						GameScreen.addEffectEnd(119, 4, this.objBeFireMain.x + this.am_duong * 10, this.objBeFireMain.y - this.objBeFireMain.hOne / 2 - 5, this.Dir, this.objMainEff);
					}
				}
				bool flag131 = this.f != 6 && this.f != 11 && this.f != 15 && this.f != 20;
				if (!flag131)
				{
					sbyte subtype2 = 0;
					bool flag132 = this.f == 6 || this.f == 15;
					if (flag132)
					{
						bool flag133 = this.isAddSound;
						if (flag133)
						{
							mSound.playSound(14, mSound.volumeSound);
						}
						subtype2 = 1;
					}
					GameScreen.addEffectEnd(108, 7, this.objBeFireMain.x - this.am_duong * 5, this.objBeFireMain.y - this.objBeFireMain.hOne / 2 + CRes.random_Am_0(10), this.Dir, this.objMainEff);
					this.addVir(5, 5, 10, true);
					GameScreen.addEffectEnd(36, (int)subtype2, this.objBeFireMain.x - this.am_duong * 5, this.objBeFireMain.y - this.objBeFireMain.hOne / 2 + CRes.random_Am_0(10), this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(25, 4, this.objBeFireMain.x - this.am_duong * 5, this.objBeFireMain.y - this.objBeFireMain.hOne / 2 + CRes.random_Am_0(10), this.Dir, this.objMainEff);
					base.setAva(1, this.objBeFireMain);
				}
				break;
			}
			case 292:
			{
				bool flag134 = this.f >= this.fRemove || this.checkNullObject(3);
				if (flag134)
				{
					this.objFireMain.isTanHinh = false;
					this.removeEff();
				}
				bool flag135 = this.f == 0 || this.f == 8 || this.f == 15 || this.f == 25;
				if (flag135)
				{
					bool flag136 = MainObject.getDistance(this.objFireMain.x, this.objFireMain.y, this.objBeFireMain.x, this.objBeFireMain.y) < 160;
					if (flag136)
					{
						this.objFireMain.x = this.objBeFireMain.x;
						this.objFireMain.y = this.objBeFireMain.y;
					}
					this.objFireMain.isTanHinh = true;
					this.changeDir();
					this.am_duong = -1;
					bool flag137 = this.Dir == 2;
					if (flag137)
					{
						this.am_duong = 1;
					}
					this.objFireMain.Dir = (int)this.Dir;
					this.x = this.objBeFireMain.x + this.am_duong * 30;
					this.y = this.objBeFireMain.y;
				}
				bool flag138 = this.f >= 15 && this.f <= 19;
				if (flag138)
				{
					this.y -= 12 * (this.f - 14);
					this.objFireMain.isTanHinh = true;
				}
				bool flag139 = this.f >= 20 && this.f <= 24;
				if (flag139)
				{
					this.y += 12 * (this.f - 19);
					this.objFireMain.isTanHinh = true;
				}
				bool flag140 = this.f == 25;
				if (flag140)
				{
					GameScreen.addEffectEnd(172, 0, this.objBeFireMain.x, this.y + 5, this.Dir, this.objMainEff);
				}
				bool flag141 = this.f != 6 && this.f != 11 && this.f != 15 && this.f != 20;
				if (!flag141)
				{
					sbyte subtype3 = 0;
					bool flag142 = this.f == 6 || this.f == 15;
					if (flag142)
					{
						bool flag143 = this.isAddSound;
						if (flag143)
						{
							mSound.playSound(14, mSound.volumeSound);
						}
						subtype3 = 1;
					}
					GameScreen.addEffectEnd(108, 7, this.objBeFireMain.x - this.am_duong * 5, this.objBeFireMain.y - this.objBeFireMain.hOne / 2 + CRes.random_Am_0(10), this.Dir, this.objMainEff);
					this.addVir(5, 5, 10, true);
					GameScreen.addEffectEnd(36, (int)subtype3, this.objBeFireMain.x - this.am_duong * 5, this.objBeFireMain.y - this.objBeFireMain.hOne / 2 + CRes.random_Am_0(10), this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(25, 4, this.objBeFireMain.x - this.am_duong * 5, this.objBeFireMain.y - this.objBeFireMain.hOne / 2 + CRes.random_Am_0(10), this.Dir, this.objMainEff);
					base.setAva(1, this.objBeFireMain);
				}
				break;
			}
			case 302:
				this.updateUssop_S2_L6();
				break;
			case 303:
				this.updateUssopS3_L6();
				break;
			case 313:
				this.updateNami6();
				break;
			case 402:
				this.update_Blackhole();
				break;
			default:
				switch (num)
				{
				case 10001:
					this.update_Pan1();
					break;
				case 10002:
					this.updatePan2();
					break;
				case 10003:
				case 10017:
				case 10020:
				case 10021:
				case 10022:
				case 10026:
				{
					bool flag144 = GameCanvas.timeNow - this.timeBegin >= (long)this.timeEnd;
					if (flag144)
					{
						this.removeEff();
					}
					break;
				}
				case 10004:
					this.updateGalio2();
					break;
				case 10005:
					this.updateNoNangLuong1();
					break;
				case 10006:
					this.updateNoNangLuong2();
					break;
				case 10007:
					this.updateNoNangLuong3();
					break;
				case 10008:
					this.updateNoTheoHuong_1();
					break;
				case 10009:
					this.updateNoTheoHuong_2();
					break;
				case 10010:
				case 10013:
					this.updateXerath1();
					break;
				case 10011:
				case 10024:
					this.updateXerath2();
					break;
				case 10012:
					this.updatexerath3();
					break;
				case 10015:
					this.updateUrgot3();
					break;
				case 10018:
					this.updateMonster_Chay_Thang();
					break;
				case 10019:
				{
					bool flag145 = !this.checkNullObject(1);
					if (flag145)
					{
						this.objFireMain.vx = this.am_duong * 15;
					}
					bool flag146 = this.f >= this.fRemove;
					if (flag146)
					{
						bool flag147 = !this.checkNullObject(1);
						if (flag147)
						{
							this.objFireMain.vx = 0;
						}
						this.removeEff();
					}
					break;
				}
				case 10023:
					this.updateMonster_DanhTron();
					break;
				case 10025:
				{
					bool flag148 = this.f >= this.fRemove;
					if (flag148)
					{
						GameScreen.addEffectEnd(57, 0, this.toX, this.toY, this.Dir, this.objMainEff);
						this.removeEff();
					}
					break;
				}
				case 10027:
				{
					bool flag149 = this.f >= this.fRemove;
					if (flag149)
					{
						this.removeEff();
					}
					break;
				}
				case 10028:
					this.updateHoDen();
					break;
				case 10030:
					this.update_ho_den_vu_tru();
					break;
				}
				break;
			}
		}
	}

	// Token: 0x0600021C RID: 540 RVA: 0x000463CC File Offset: 0x000445CC
	public void updateAngleXP()
	{
		bool flag = this.typeEffect == -1;
		if (flag)
		{
			Point point = new Point();
			point.x = this.x;
			point.y = this.y;
			this.VecEff.addElement(point);
		}
		bool flag2 = this.objBeFireMain == null || this.objBeFireMain.isRemove || this.f >= this.fRemove || this.objBeFireMain.isStop;
		if (flag2)
		{
			this.f = this.fRemove;
		}
		else
		{
			int num = this.objBeFireMain.x - this.x;
			int num2 = this.objBeFireMain.y - (this.objBeFireMain.hOne >> 1) - this.y;
			this.life++;
			bool flag3 = (CRes.abs(num) < 16 && CRes.abs(num2) < 16) || this.life > this.fRemove;
			if (flag3)
			{
				this.f = this.fRemove;
			}
			else
			{
				int num3 = CRes.angle(num, num2);
				bool flag4 = CRes.abs(num3 - this.gocT_Arc) < 90 || num * num + num2 * num2 > 4096;
				if (flag4)
				{
					bool flag5 = CRes.abs(num3 - this.gocT_Arc) < 15;
					if (flag5)
					{
						this.gocT_Arc = num3;
					}
					else
					{
						bool flag6 = (num3 - this.gocT_Arc >= 0 && num3 - this.gocT_Arc < 180) || num3 - this.gocT_Arc < -180;
						if (flag6)
						{
							this.gocT_Arc = CRes.fixangle(this.gocT_Arc + 15);
						}
						else
						{
							this.gocT_Arc = CRes.fixangle(this.gocT_Arc - 15);
						}
					}
				}
				bool flag7 = this.va < 8192;
				if (flag7)
				{
					this.va += 3096;
				}
				this.vX1000 = this.va * CRes.getcos(this.gocT_Arc) >> 10;
				this.vY1000 = this.va * CRes.getsin(this.gocT_Arc) >> 10;
				num += this.vX1000;
				int num4 = num >> 10;
				this.x += num4;
				num &= 1023;
				num2 += this.vY1000;
				int num5 = num2 >> 10;
				this.y += num5;
				num2 &= 1023;
				bool flag8 = this.typeEffect != -1;
				if (flag8)
				{
					Point point2 = new Point();
					point2.x = this.x;
					point2.y = this.y;
					this.VecEff.addElement(point2);
				}
			}
		}
	}

	// Token: 0x0600021D RID: 541 RVA: 0x00046684 File Offset: 0x00044884
	private void update_Tru_2()
	{
		for (int i = 0; i < this.VecSubEff.size(); i++)
		{
			Point point = (Point)this.VecSubEff.elementAt(i);
			point.f++;
			bool flag = point.f >= point.fRe;
			if (flag)
			{
				this.VecSubEff.removeElementAt(i);
				i--;
			}
		}
		for (int j = 0; j < this.VecEff.size(); j++)
		{
			Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(j);
			point_Focus.update_Vx_Vy();
			bool flag2 = point_Focus.f >= point_Focus.fRe;
			if (flag2)
			{
				GameScreen.addEffectEnd(25, 4, point_Focus.x, point_Focus.y, (sbyte)point_Focus.dis, this.objMainEff);
				this.VecEff.removeElementAt(j);
				j--;
			}
			else
			{
				Point point2 = new Point(point_Focus.x, point_Focus.y);
				point2.fRe = 5;
				this.VecSubEff.addElement(point2);
			}
		}
		bool flag3 = this.f >= this.fRemove && this.VecSubEff.size() == 0;
		if (flag3)
		{
			this.removeEff();
		}
	}

	// Token: 0x0600021E RID: 542 RVA: 0x000467EC File Offset: 0x000449EC
	private void update_Dong_Dat_2()
	{
		for (int i = 0; i < this.VecSubEff.size(); i++)
		{
			Point point = (Point)this.VecSubEff.elementAt(i);
			point.f++;
			bool flag = point.frame == 1 && point.f >= 6;
			if (flag)
			{
				point.frame = 0;
				point.f = 0;
			}
			bool flag2 = point.f / 3 >= 4;
			if (flag2)
			{
				this.VecSubEff.removeElement(point);
				i--;
			}
		}
		bool flag3 = this.f >= 12 && this.f % 2 == 0 && this.f <= 30;
		if (flag3)
		{
			int num = (this.f - 12) / 4;
			int num2 = 4 + num;
			int num3 = 30 + 35 * num;
			int num4 = 100 / num2;
			bool flag4 = this.f % 4 == 0;
			if (flag4)
			{
				int num5 = 180 + num2 * num4 / 2;
				for (int j = 0; j < num2; j++)
				{
					Point point2 = new Point();
					point2.x = this.x + CRes.getcos(CRes.fixangle(num5)) * num3 / 1000;
					point2.y = this.y + CRes.getsin(CRes.fixangle(num5)) * num3 / 1000;
					bool flag5 = this.typeEffect == 244;
					if (flag5)
					{
						point2.frame = 1;
					}
					int tile = GameCanvas.loadmap.getTile(point2.x, point2.y);
					bool flag6 = tile == 0 || tile == 2;
					if (flag6)
					{
						this.VecSubEff.addElement(point2);
						bool flag7 = j % 2 == 0;
						if (flag7)
						{
							GameScreen.addEffectEnd(110, 0, point2.x, point2.y, this.Dir, this.objMainEff);
						}
						GameScreen.addEffectEnd(63, 0, point2.x, point2.y + 5, this.Dir, this.objMainEff);
					}
					num5 -= num4;
				}
			}
			bool flag8 = this.f % 4 == 2;
			if (flag8)
			{
				num3 += 15;
				int num6 = 360 - num2 * num4 / 2;
				for (int k = 0; k < num2; k++)
				{
					Point point3 = new Point();
					point3.x = this.x + CRes.getcos(CRes.fixangle(num6)) * num3 / 1000;
					point3.y = this.y + CRes.getsin(CRes.fixangle(num6)) * num3 / 1000;
					bool flag9 = this.typeEffect == 244;
					if (flag9)
					{
						point3.frame = 1;
					}
					int tile2 = GameCanvas.loadmap.getTile(point3.x, point3.y);
					bool flag10 = tile2 == 0 || tile2 == 2;
					if (flag10)
					{
						this.VecSubEff.addElement(point3);
						bool flag11 = k % 2 == 0;
						if (flag11)
						{
							GameScreen.addEffectEnd(110, 0, point3.x, point3.y, this.Dir, this.objMainEff);
						}
						GameScreen.addEffectEnd(63, 0, point3.x, point3.y + 5, this.Dir, this.objMainEff);
					}
					num6 += num4;
				}
			}
			bool flag12 = this.isAddSound && this.f % 4 == 0;
			if (flag12)
			{
				mSound.playSound(41, mSound.volumeSound);
			}
		}
		bool flag13 = this.f >= this.fRemove && this.VecSubEff.size() == 0;
		if (flag13)
		{
			this.removeEff();
		}
	}

	// Token: 0x0600021F RID: 543 RVA: 0x00046BD0 File Offset: 0x00044DD0
	private void update_Ace_1()
	{
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point = (Point)this.VecEff.elementAt(i);
			point.update();
			bool flag = point.f >= point.fRe;
			if (flag)
			{
				bool flag2 = CRes.random(2) == 0;
				if (flag2)
				{
					this.addSound(5);
				}
				this.VecEff.removeElement(point);
				GameScreen.addEffectEnd(2, 0, point.x, point.y, this.Dir, this.objMainEff);
				bool flag3 = CRes.random(4) == 0;
				if (flag3)
				{
					GameScreen.addEffectEnd(110, 1, point.x, point.y, this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(63, 0, point.x, point.y + 5, this.Dir, this.objMainEff);
				}
				i--;
			}
		}
		bool flag4 = this.f >= 7 && this.f <= 12 && !this.checkNullObject(1);
		if (flag4)
		{
			this.objFireMain.dy = (this.f - 6) * 30;
		}
		bool flag5 = this.f >= 14 && this.f <= 26;
		if (flag5)
		{
			bool flag6 = this.f == 14 && !this.checkNullObject(3);
			if (flag6)
			{
				this.toY = this.objBeFireMain.y;
				this.toX = this.objBeFireMain.x;
				this.x1000 = this.objFireMain.x;
				this.y1000 = this.objFireMain.y;
			}
			bool flag7 = !this.checkNullObject(1);
			if (flag7)
			{
				this.objFireMain.isTanHinh = true;
			}
			bool flag8 = this.f > 15 && this.f < 26 && this.f % 5 == 0;
			if (flag8)
			{
				this.addSound(15);
			}
			bool flag9 = this.f > 15 && this.f % 2 == 1 && this.f <= 25;
			if (flag9)
			{
				int num = CRes.random(2, 4);
				for (int j = 0; j < num; j++)
				{
					Point point2 = new Point();
					point2.vy = CRes.random(25, 35);
					point2.x = this.toX + CRes.random_Am(0, 50);
					point2.y = this.toY - point2.vy * 3 + CRes.random_Am(0, 20) + 5;
					point2.frame = CRes.random(this.fraImgEff.maxNumFrame);
					point2.fRe = 3;
					this.VecEff.addElement(point2);
				}
			}
			bool flag10 = this.f % 6 == 1;
			if (flag10)
			{
				base.setAva(0, this.objBeFireMain);
				this.addVir(1, 6, 12, false);
			}
		}
		bool flag11 = this.f == 27 && !this.checkNullObject(1);
		if (flag11)
		{
			this.objFireMain.dy = 80;
			this.objFireMain.isTanHinh = false;
		}
		bool flag12 = this.f > 27 && this.f <= 30 && !this.checkNullObject(1);
		if (flag12)
		{
			this.objFireMain.dy = 80 - (this.f - 27) * 20;
		}
		bool flag13 = this.f >= this.fRemove;
		if (flag13)
		{
			bool flag14 = !this.checkNullObject(1);
			if (flag14)
			{
				this.objFireMain.isTanHinh = false;
			}
			this.removeEff();
		}
	}

	// Token: 0x06000220 RID: 544 RVA: 0x00046FA4 File Offset: 0x000451A4
	private void update_Ace_1_L2()
	{
		for (int i = 0; i < this.VecSubEff.size(); i++)
		{
			Point point = (Point)this.VecSubEff.elementAt(i);
			point.f++;
			point.y += point.vy;
			bool flag = point.f >= this.fraImgSub2Eff.maxNumFrame;
			if (flag)
			{
				this.VecSubEff.removeElementAt(i);
				i--;
			}
		}
		for (int j = 0; j < this.VecEff.size(); j++)
		{
			Point point2 = (Point)this.VecEff.elementAt(j);
			Point point3 = new Point(point2.x, point2.y - 30);
			point3.vy = -4;
			this.VecSubEff.addElement(point3);
			point2.update();
			bool flag2 = point2.f < point2.fRe;
			if (!flag2)
			{
				bool flag3 = CRes.random(2) == 0;
				if (flag3)
				{
					this.addSound(5);
				}
				this.VecEff.removeElement(point2);
				bool flag4 = CRes.random(2) == 0;
				if (flag4)
				{
					sbyte subtype = this.frameSuper + 1;
					bool flag5 = this.typeEffect == 228;
					if (flag5)
					{
						subtype = 0;
					}
					GameScreen.addEffectEnd(141, (int)subtype, point2.x, point2.y, this.Dir, this.objMainEff);
				}
				else
				{
					GameScreen.addEffectEnd(2, 0, point2.x, point2.y, this.Dir, this.objMainEff);
				}
				bool flag6 = CRes.random(2) == 0;
				if (flag6)
				{
					GameScreen.addEffectEnd(110, 1, point2.x, point2.y, this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(63, 0, point2.x, point2.y + 5, this.Dir, this.objMainEff);
				}
				j--;
			}
		}
		bool flag7 = this.f >= 4 && this.f <= 26;
		if (flag7)
		{
			this.objFireMain.isPaintLeg = false;
		}
		bool flag8 = this.f >= 7 && this.f <= 12 && !this.checkNullObject(1);
		if (flag8)
		{
			this.objFireMain.dy = (this.f - 6) * 40;
		}
		bool flag9 = this.f >= 14 && this.f <= 26;
		if (flag9)
		{
			bool flag10 = this.f == 14 && !this.checkNullObject(3);
			if (flag10)
			{
				this.toY = this.objBeFireMain.y;
				this.toX = this.objBeFireMain.x;
				this.x1000 = this.objFireMain.x;
				this.y1000 = this.objFireMain.y;
			}
			bool flag11 = !this.checkNullObject(1);
			if (flag11)
			{
				this.objFireMain.isTanHinh = true;
			}
			bool flag12 = this.f > 15 && this.f < 26 && this.f % 5 == 0;
			if (flag12)
			{
				this.addSound(15);
			}
			bool flag13 = this.f > 15 && this.f % 2 == 1 && this.f <= 25;
			if (flag13)
			{
				int num = CRes.random(2, 4);
				for (int k = 0; k < num; k++)
				{
					Point point4 = new Point();
					point4.vy = CRes.random(25, 35);
					point4.x = this.toX + CRes.random_Am(0, 50);
					point4.y = this.toY - point4.vy * 3 + CRes.random_Am(0, 20) + 5;
					point4.frame = CRes.random(this.fraImgEff.maxNumFrame);
					point4.fRe = 3;
					this.VecEff.addElement(point4);
				}
			}
			bool flag14 = this.f % 6 == 1;
			if (flag14)
			{
				base.setAva(0, this.objBeFireMain);
				this.addVir(1, 6, 12, false);
			}
		}
		bool flag15 = this.f == 27 && !this.checkNullObject(1);
		if (flag15)
		{
			this.objFireMain.dy = 80;
			this.objFireMain.isTanHinh = false;
			this.objFireMain.isPaintLeg = true;
		}
		bool flag16 = this.f > 27 && this.f <= 30 && !this.checkNullObject(1);
		if (flag16)
		{
			this.objFireMain.dy = 80 - (this.f - 27) * 20;
		}
		bool flag17 = this.f >= this.fRemove;
		if (flag17)
		{
			bool flag18 = !this.checkNullObject(1);
			if (flag18)
			{
				this.objFireMain.isTanHinh = false;
			}
			this.removeEff();
		}
	}

	// Token: 0x06000221 RID: 545 RVA: 0x000474D0 File Offset: 0x000456D0
	private void update_Ace_2()
	{
		for (int i = 0; i < this.VecSubEff.size(); i++)
		{
			Point point = (Point)this.VecSubEff.elementAt(i);
			point.update();
			bool flag = point.frame == 0;
			if (flag)
			{
				bool flag2 = point.f / 2 >= 5;
				if (flag2)
				{
					this.VecSubEff.removeElement(point);
					i--;
				}
			}
			else
			{
				bool flag3 = point.f >= point.fRe;
				if (flag3)
				{
					this.VecSubEff.removeElement(point);
					i--;
				}
			}
		}
		for (int j = 0; j < this.VecEff.size(); j++)
		{
			Point point2 = (Point)this.VecEff.elementAt(j);
			point2.update();
			bool flag4 = point2.frame == 1 && this.f % 4 == 0;
			if (flag4)
			{
				Point point3 = new Point();
				point3.x = point2.x / 1000;
				point3.y = point2.y / 1000;
				point3.frame = 1;
				point3.fRe = CRes.random(8, 10);
				point3.f = CRes.random(3);
				point3.fRe += point3.f;
				this.VecSubEff.addElement(point3);
			}
			bool flag5 = point2.f >= point2.fRe;
			if (flag5)
			{
				this.addSound(15);
				this.VecEff.removeElement(point2);
				j--;
			}
		}
		bool flag6 = this.f <= 10 && CRes.random(2) == 0;
		if (flag6)
		{
			Point point4 = new Point();
			point4.x = this.x + CRes.random_Am_0(10);
			point4.y = this.y - 10 - CRes.random(20);
			point4.vx = CRes.random_Am_0(3);
			point4.vy = -CRes.random(3, 7);
			this.VecSubEff.addElement(point4);
		}
		bool flag7 = this.f == 15;
		if (flag7)
		{
			this.addSound(15);
			int num = 12;
			bool flag8 = this.typeEffect != 3;
			if (flag8)
			{
				num = 16;
			}
			int num2 = 0;
			for (int k = 0; k < num; k++)
			{
				num2 %= 360;
				Point point5 = new Point(this.x * 1000, this.y * 1000);
				point5.vx = CRes.getcos(num2) * this.vMax;
				point5.vy = CRes.getsin(num2) * (this.vMax / 2);
				point5.fRe = 7;
				point5.frame = 0;
				this.VecEff.addElement(point5);
				num2 += 360 / num;
			}
		}
		bool flag9 = this.f == 20;
		if (flag9)
		{
			this.addSound(15);
			this.addVir(1, 6, 12, true);
			int num3 = 15;
			int num4 = 16;
			bool flag10 = this.typeEffect != 3;
			if (flag10)
			{
				num4 = 20;
			}
			for (int l = 0; l < num4; l++)
			{
				num3 %= 360;
				Point point6 = new Point(this.x * 1000, this.y * 1000);
				point6.vx = CRes.getcos(num3) * this.vMax;
				point6.vy = CRes.getsin(num3) * (this.vMax / 2);
				point6.fRe = 12;
				point6.fSmall = CRes.random(this.fraImgEff.maxNumFrame);
				point6.frame = 1;
				this.VecEff.addElement(point6);
				num3 += 360 / num4;
			}
		}
		bool flag11 = this.typeEffect != 3 && this.f == 23;
		if (flag11)
		{
			this.addSound(15);
			this.addVir(1, 6, 12, true);
			int num5 = 30;
			int num6 = 24;
			for (int m = 0; m < num6; m++)
			{
				num5 %= 360;
				Point point7 = new Point(this.x * 1000, this.y * 1000);
				point7.vx = CRes.getcos(num5) * this.vMax;
				point7.vy = CRes.getsin(num5) * (this.vMax / 2);
				point7.fRe = 16;
				point7.fSmall = CRes.random(this.fraImgEff.maxNumFrame);
				point7.frame = 1;
				this.VecEff.addElement(point7);
				num5 += 360 / num6;
			}
		}
		bool flag12 = this.f == 26;
		if (flag12)
		{
			for (int n = 0; n < this.vecObjsBeFire.size(); n++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(n);
				bool flag13 = object_Effect_Skill != null;
				if (flag13)
				{
					MainObject obj = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					base.setAva(1, obj);
				}
			}
		}
		bool flag14 = this.f >= this.fRemove && this.VecEff.size() == 0 && this.VecSubEff.size() == 0;
		if (flag14)
		{
			bool flag15 = !this.checkNullObject(1);
			if (flag15)
			{
				this.objFireMain.isTanHinh = false;
			}
			this.removeEff();
		}
	}

	// Token: 0x06000222 RID: 546 RVA: 0x00047AA8 File Offset: 0x00045CA8
	private void update_Blackhole()
	{
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point = (Point)this.VecEff.elementAt(i);
			point.update();
			bool flag = point.f >= point.fRe;
			if (flag)
			{
				this.addSound(15);
				this.VecEff.removeElement(point);
				i--;
			}
		}
		bool flag2 = this.f == 7;
		if (flag2)
		{
			this.addSound(15);
			int num = 12;
			bool flag3 = this.typeEffect != 3;
			if (flag3)
			{
				num = 16;
			}
			int num2 = 0;
			for (int j = 0; j < this.VecSubEff.size(); j++)
			{
				Point point2 = (Point)this.VecSubEff.elementAt(j);
				for (int k = 0; k < num; k++)
				{
					num2 %= 360;
					Point point3 = new Point(point2.x * 1000, point2.y * 1000);
					point3.vx = CRes.getcos(num2) * this.vMax;
					point3.vy = CRes.getsin(num2) * (this.vMax / 2);
					point3.fRe = 7;
					point3.frame = 0;
					this.VecEff.addElement(point3);
					num2 += 360 / num;
				}
			}
		}
		bool flag4 = this.f == 12;
		if (flag4)
		{
			this.addSound(15);
			this.addVir(1, 6, 12, true);
			int num3 = 15;
			int num4 = 16;
			bool flag5 = this.typeEffect != 3;
			if (flag5)
			{
				num4 = 20;
			}
			for (int l = 0; l < this.VecSubEff.size(); l++)
			{
				Point point4 = (Point)this.VecSubEff.elementAt(l);
				for (int m = 0; m < num4; m++)
				{
					num3 %= 360;
					Point point5 = new Point(point4.x * 1000, point4.y * 1000);
					point5.vx = CRes.getcos(num3) * this.vMax;
					point5.vy = CRes.getsin(num3) * (this.vMax / 2);
					point5.fRe = 12;
					point5.fSmall = CRes.random(this.fraImgEff.maxNumFrame);
					point5.frame = 1;
					this.VecEff.addElement(point5);
					num3 += 360 / num4;
				}
			}
		}
		bool flag6 = this.f == 26;
		if (flag6)
		{
			for (int n = 0; n < this.vecObjsBeFire.size(); n++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(n);
				bool flag7 = object_Effect_Skill != null;
				if (flag7)
				{
					MainObject obj = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					base.setAva(1, obj);
				}
			}
		}
		bool flag8 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag8)
		{
			bool flag9 = !this.checkNullObject(1);
			if (flag9)
			{
				this.objFireMain.isTanHinh = false;
			}
			this.removeEff();
		}
	}

	// Token: 0x06000223 RID: 547 RVA: 0x00047E34 File Offset: 0x00046034
	private void create_Ice_Arc()
	{
		this.fRemove = 25;
		this.vMax = 5;
		for (int i = 0; i < 16; i++)
		{
			Point point = new Point();
			point.x = this.x * 1000;
			point.y = this.y * 1000;
			point.vx = 2 * CRes.getcos(225 * i / 10) * this.vMax;
			point.vy = CRes.getsin(225 * i / 10) * this.vMax;
			point.f = 0;
			this.VecEff.addElement(point);
		}
	}

	// Token: 0x06000224 RID: 548 RVA: 0x00047EE0 File Offset: 0x000460E0
	private void update_ho_den_vu_tru()
	{
		this.CR += 5;
		this.t2++;
		bool flag = this.t2 % 2 == 0;
		if (flag)
		{
			for (int i = 0; i < this.radian.Length; i++)
			{
				GameScreen.addEffectEnd(166, 0, 2 * (CRes.getcos(this.radian[i]) * this.CR) / 1024 + this.x, CRes.getsin(this.radian[i]) * this.CR / 1024 + this.y, this.Dir, this.objMainEff);
				this.radian[i] += 15;
				bool flag2 = this.radian[i] > 360;
				if (flag2)
				{
					this.radian[i] = (this.radian[i] = 360);
				}
			}
		}
		this.Ctick++;
		bool flag3 = this.Ctick % 5 == 0;
		if (flag3)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000225 RID: 549 RVA: 0x00048004 File Offset: 0x00046204
	private void update_Aokiji_1()
	{
		for (int i = 0; i < this.VecSubEff.size(); i++)
		{
			Point point = (Point)this.VecSubEff.elementAt(i);
			point.update();
			bool flag = point.f >= point.fRe;
			if (flag)
			{
				this.VecSubEff.removeElement(point);
				i--;
			}
		}
		for (int j = 0; j < this.VecEff.size(); j++)
		{
			Point point2 = (Point)this.VecEff.elementAt(j);
			bool flag2 = point2.f >= point2.fSmall;
			if (flag2)
			{
				bool flag3 = this.typeEffect == 230;
				if (flag3)
				{
					Point point3 = new Point(point2.x, point2.y - 25);
					point3.vy = -4;
					point3.f = CRes.random(2);
					point3.fRe = 6;
					this.VecSubEff.addElement(point3);
				}
				point2.update();
			}
			else
			{
				point2.f++;
			}
			bool flag4 = point2.frame == 0;
			if (flag4)
			{
				bool flag5 = point2.f >= point2.fRe;
				if (flag5)
				{
					point2.vy = 0;
					point2.frame = 1;
					point2.fRe = CRes.random(10, 12);
					point2.f = 0;
					GameScreen.addEffectEnd(17, CRes.random(20, 30), point2.x, point2.y, this.Dir, this.objMainEff);
					bool flag6 = CRes.random(2) == 0;
					if (flag6)
					{
						GameScreen.addEffectEnd(110, 2, point2.x, point2.y, this.Dir, this.objMainEff);
					}
				}
			}
			else
			{
				bool flag7 = point2.frame == 1 && point2.f == point2.fRe;
				if (flag7)
				{
					GameScreen.addEffectEnd(14, 0, point2.x, point2.y, this.Dir, this.objMainEff);
					this.VecEff.removeElement(point2);
					j--;
				}
			}
		}
		bool flag8 = this.f <= 25 && CRes.random(4) == 0;
		if (flag8)
		{
			Point point4 = new Point();
			point4.x = this.x + CRes.random_Am_0(15);
			point4.y = this.y - CRes.random(20);
			point4.vx = CRes.random_Am_0(3);
			point4.vy = -CRes.random(3, 7);
			point4.fRe = 10;
			this.VecSubEff.addElement(point4);
		}
		bool flag9 = this.typeEffect == 230 && this.f >= 16 && this.f < 20;
		if (flag9)
		{
			Point point5 = new Point();
			point5.vy = CRes.random(30, 40);
			point5.dis = CRes.random(25, 35);
			point5.fSmall = 10;
			point5.x = this.objFireMain.x + CRes.random_Am_0(MotherCanvas.w / 2);
			point5.y = this.objFireMain.y - point5.vy * 4 - 60;
			point5.frame = 0;
			point5.fRe = 5 + point5.fSmall + CRes.random(3);
			this.VecEff.addElement(point5);
		}
		bool flag10 = this.f == 20;
		if (flag10)
		{
			this.addSound(15);
			for (int k = 0; k < this.vecObjsBeFire.size(); k++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(k);
				bool flag11 = object_Effect_Skill != null;
				if (flag11)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					bool flag12 = mainObject != null;
					if (flag12)
					{
						Point point6 = new Point();
						point6.vy = CRes.random(30, 40);
						point6.dis = CRes.random(25, 35);
						point6.fRe = 4;
						point6.x = mainObject.x;
						point6.y = mainObject.y - point6.vy * point6.fRe + CRes.random(5);
						point6.frame = 0;
						this.VecEff.addElement(point6);
					}
				}
			}
			bool flag13 = !this.checkNullObject(1);
			if (flag13)
			{
				for (int l = 0; l < 5; l++)
				{
					Point point7 = new Point();
					point7.vy = CRes.random(30, 40);
					point7.dis = CRes.random(25, 35);
					point7.fSmall = l * 3;
					point7.x = this.objFireMain.x + CRes.random_Am_0(MotherCanvas.w / 2);
					point7.y = this.objFireMain.y - point7.vy * 4 - 60;
					point7.frame = 0;
					point7.fRe = 5 + point7.fSmall + CRes.random(3);
					this.VecEff.addElement(point7);
				}
			}
		}
		bool flag14 = this.f == 24;
		if (flag14)
		{
			this.addVir(1, 6, 12, true);
			for (int m = 0; m < this.vecObjsBeFire.size(); m++)
			{
				Object_Effect_Skill object_Effect_Skill2 = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(m);
				bool flag15 = object_Effect_Skill2 != null;
				if (flag15)
				{
					MainObject obj = MainObject.get_Object((int)object_Effect_Skill2.ID, object_Effect_Skill2.tem);
					base.setAva(1, obj);
				}
			}
		}
		bool flag16 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag16)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000226 RID: 550 RVA: 0x00048620 File Offset: 0x00046820
	private void update_Aokiji_2()
	{
		for (int i = 0; i < this.VecSubEff.size(); i++)
		{
			Point point = (Point)this.VecSubEff.elementAt(i);
			point.update();
			bool flag = point.f / 2 >= 5;
			if (flag)
			{
				this.VecSubEff.removeElement(point);
				i--;
			}
		}
		for (int j = 0; j < this.VecEff.size(); j++)
		{
			Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(j);
			point_Focus.update_Vx_Vy();
			Point point2 = new Point(point_Focus.x, point_Focus.y);
			point2.vx = CRes.random_Am_0(3);
			point2.vy = -CRes.random(3, 7);
			this.VecSubEff.addElement(point2);
			bool flag2 = point_Focus.f != point_Focus.fRe;
			if (!flag2)
			{
				bool flag3 = !this.checkNullObject(2);
				if (flag3)
				{
					base.setAva(1, this.objBeFireMain);
				}
				bool flag4 = this.typeEffect == 231;
				if (flag4)
				{
					bool flag5 = !this.checkNullObject(3) && MainObject.getDistance(this.objFireMain.x, this.objFireMain.y, this.objBeFireMain.x, this.objBeFireMain.y) < 60;
					if (flag5)
					{
						GameScreen.addEffectEnd(142, 1, point_Focus.x - 30, point_Focus.y + 8, this.Dir, this.objMainEff);
						GameScreen.addEffectEnd(142, 1, point_Focus.x + 30, point_Focus.y + 8, this.Dir, this.objMainEff);
					}
					else
					{
						int num = 1;
						bool flag6 = point_Focus.vy < 0;
						if (flag6)
						{
							num = -1;
						}
						bool flag7 = point_Focus.vy == 0;
						if (flag7)
						{
							num = 0;
						}
						GameScreen.addEffectEnd(142, 0, point_Focus.x - 40 * this.am_duong, point_Focus.y + 8 - num * 15, this.Dir, this.objMainEff);
						GameScreen.addEffectEnd(142, 1, point_Focus.x - 20 * this.am_duong, point_Focus.y + 8 - num * 7, this.Dir, this.objMainEff);
					}
				}
				GameScreen.addEffectEnd(88, 0, point_Focus.x, point_Focus.y + 8, this.Dir, this.objMainEff);
				this.addVir(2, 6, 12, true);
				this.VecEff.removeElement(point_Focus);
				j--;
			}
		}
		bool flag8 = this.f <= 15 && CRes.random(4) == 0;
		if (flag8)
		{
			Point point3 = new Point();
			point3.x = this.x + CRes.random_Am_0(15);
			point3.y = this.y - CRes.random(20);
			point3.vx = CRes.random_Am_0(3);
			point3.vy = -CRes.random(3, 7);
			this.VecSubEff.addElement(point3);
		}
		bool flag9 = this.f == 18;
		if (flag9)
		{
			bool flag10 = !this.checkNullObject(2);
			if (flag10)
			{
				this.toX = this.objBeFireMain.x;
				this.toY = this.objBeFireMain.y;
			}
			Point_Focus point_Focus2 = new Point_Focus();
			int xdich = this.toX - (this.x + this.am_duong * 75);
			int ydich = this.toY - this.y;
			point_Focus2 = base.create_Speed(xdich, ydich, point_Focus2, this.x + this.am_duong * 75, this.y, this.toX, this.toY);
			this.VecEff.addElement(point_Focus2);
			this.addVir(2, 6, 12, true);
			GameScreen.addEffectEnd(110, 2, point_Focus2.x, point_Focus2.y, this.Dir, this.objMainEff);
			GameScreen.addEffectEnd(110, 2, point_Focus2.x, point_Focus2.y, this.Dir, this.objMainEff);
		}
		bool flag11 = this.f >= this.fRemove && this.VecSubEff.size() == 0;
		if (flag11)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000227 RID: 551 RVA: 0x00048A98 File Offset: 0x00046C98
	private void update_Smoker_1()
	{
		for (int i = 0; i < this.VecSubEff.size(); i++)
		{
			Point point = (Point)this.VecSubEff.elementAt(i);
			point.update();
			bool flag = point.f >= point.fRe;
			if (flag)
			{
				this.VecSubEff.removeElement(point);
				i--;
			}
		}
		for (int j = 0; j < this.VecEff.size(); j++)
		{
			Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(j);
			point_Focus.update_Vx_Vy();
			bool flag2 = this.typeEffect == 232 && this.f % 2 == 0 && !GameCanvas.lowGraphic;
			if (flag2)
			{
				Point point2 = new Point();
				point2.x = point_Focus.x;
				point2.y = point_Focus.y;
				point2.fRe = 7;
				point2.frame = 1;
				this.VecSubEff.addElement(point2);
			}
			Point point3 = new Point();
			point3.x = point_Focus.x + CRes.random_Am_0(5);
			point3.y = point_Focus.y;
			point3.vx = 0;
			point3.vy = -CRes.random(1, 4);
			point3.fRe = CRes.random(4, 7);
			this.VecSubEff.addElement(point3);
			point_Focus.frame++;
			bool flag3 = point_Focus.f >= point_Focus.fRe;
			if (flag3)
			{
				point_Focus.vx = 0;
				point_Focus.vy = 0;
				point_Focus.x = point_Focus.toX;
				point_Focus.y = point_Focus.toY;
			}
			else
			{
				bool flag4 = point_Focus.frame / 2 > this.fraImgSubEff.nFrame - 1;
				if (flag4)
				{
					point_Focus.frame = (this.fraImgSubEff.nFrame - 1) * 2;
				}
			}
			bool flag5 = point_Focus.f >= point_Focus.fRe && point_Focus.frame >= this.fraImgSubEff.nFrame;
			if (flag5)
			{
				bool flag6 = !this.checkNullObject(2);
				if (flag6)
				{
					base.setAva(2, this.objBeFireMain);
				}
				this.addSound(15);
				GameScreen.addEffectEnd(18, 0, point_Focus.x, point_Focus.y, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(108, 4, point_Focus.x, point_Focus.y, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(54, 3, this.toX, this.toY, this.Dir, this.objMainEff);
				bool flag7 = this.typeEffect == 232;
				if (flag7)
				{
					GameScreen.addEffectEnd(146, 0, this.toX, this.toY, this.Dir, this.objMainEff);
				}
				this.VecEff.removeElement(point_Focus);
				j--;
			}
		}
		bool flag8 = this.f <= 10 || (this.f > 20 && this.f < 26);
		if (flag8)
		{
			bool flag9 = CRes.random(4) == 0;
			if (flag9)
			{
				Point point4 = new Point();
				point4.x = this.x + CRes.random_Am_0(15);
				point4.y = this.y + CRes.random(20);
				point4.vx = CRes.random_Am_0(3);
				point4.vy = -CRes.random(3, 7);
				point4.fRe = CRes.random(6, 10);
				this.VecSubEff.addElement(point4);
			}
		}
		else
		{
			bool flag10 = this.f <= 20 && CRes.random(2) == 0;
			if (flag10)
			{
				Point point5 = new Point();
				point5.x = this.x + CRes.random_Am_0(15) - this.am_duong * 10;
				point5.y = this.y + CRes.random(20);
				point5.vx = CRes.random_Am_0(4);
				point5.vy = -CRes.random(4, 8);
				point5.fRe = CRes.random(8, 14);
				this.VecSubEff.addElement(point5);
			}
		}
		bool flag11 = this.f == 24;
		if (flag11)
		{
			this.addSound(32);
			bool flag12 = !this.checkNullObject(2);
			if (flag12)
			{
				this.toX = this.objBeFireMain.x;
				this.toY = this.objBeFireMain.y - this.objBeFireMain.hOne / 2;
			}
			Point_Focus point_Focus2 = new Point_Focus();
			int xdich = this.toX - this.x;
			int ydich = this.toY - this.y;
			point_Focus2 = base.create_Speed(xdich, ydich, point_Focus2, this.x, this.y, this.toX, this.toY);
			this.VecEff.addElement(point_Focus2);
			this.addVir(5, 6, 12, true);
		}
		bool flag13 = this.f >= this.fRemove && this.VecEff.size() == 0 && this.VecSubEff.size() == 0;
		if (flag13)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000228 RID: 552 RVA: 0x00048FF0 File Offset: 0x000471F0
	private void update_Smoker_2()
	{
		for (int i = 0; i < this.VecSubEff.size(); i++)
		{
			Point point = (Point)this.VecSubEff.elementAt(i);
			point.update();
			bool flag = point.f >= point.fRe;
			if (flag)
			{
				this.VecSubEff.removeElement(point);
				i--;
			}
		}
		for (int j = 0; j < this.VecEff.size(); j++)
		{
			Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(j);
			point_Focus.update_Vx_Vy();
			bool flag2 = this.typeEffect == 234 && !GameCanvas.lowGraphic;
			if (flag2)
			{
				Point point2 = new Point();
				point2.x = point_Focus.x;
				point2.y = point_Focus.y;
				point2.fRe = 3;
				point2.frame = 1;
				this.VecSubEff.addElement(point2);
			}
			Point point3 = new Point();
			point3.x = point_Focus.x;
			point3.y = point_Focus.y;
			point3.vx = 0;
			point3.vy = -CRes.random(1, 3);
			point3.fRe = CRes.random(3, 6);
			this.VecSubEff.addElement(point3);
			bool flag3 = point_Focus.f >= point_Focus.fRe;
			if (flag3)
			{
				this.addVir(5, 6, 12, true);
				LoadMap.timeVibrateScreen = CRes.random(6, 12);
				GameScreen.addEffectEnd(18, 0, point_Focus.x, point_Focus.y, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(63, 0, point_Focus.x, point_Focus.y, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(110, 0, point_Focus.x, point_Focus.y, this.Dir, this.objMainEff);
				this.VecEff.removeElement(point_Focus);
				j--;
			}
		}
		bool flag4 = this.f <= 5 && CRes.random(3) == 0;
		if (flag4)
		{
			Point point4 = new Point();
			point4.x = this.x + CRes.random_Am_0(15);
			point4.y = this.y + CRes.random(20);
			point4.vx = CRes.random_Am_0(3);
			point4.vy = -CRes.random(3, 7);
			point4.fRe = CRes.random(6, 10);
			this.VecSubEff.addElement(point4);
		}
		bool flag5 = this.f == 8 && !this.checkNullObject(1);
		if (flag5)
		{
			this.objFireMain.isPaintLeg = false;
		}
		bool flag6 = this.f == 10 && !this.checkNullObject(1);
		if (flag6)
		{
			this.objFireMain.isTanHinh = true;
		}
		bool flag7 = this.f == 15 || this.f == 20 || ((this.f == 12 || this.f == 17) && this.typeEffect == 234 && !GameCanvas.lowGraphic);
		if (flag7)
		{
			this.addSound(15);
			int num = this.x - this.am_duong * 40 + CRes.random_Am_0(30);
			int num2 = this.y - 160 + CRes.random_Am_0(20);
			for (int k = 0; k < this.vecObjsBeFire.size(); k++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(k);
				bool flag8 = object_Effect_Skill != null;
				if (flag8)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					bool flag9 = mainObject != null;
					if (flag9)
					{
						Point_Focus point_Focus2 = new Point_Focus();
						int num3 = CRes.random_Am_0(15);
						int num4 = CRes.random_Am_0(10);
						int xdich = mainObject.x + num3 - num;
						int ydich = mainObject.y + num4 - num2;
						point_Focus2 = base.create_Speed(xdich, ydich, point_Focus2, num, num2, mainObject.x + num3, mainObject.y + num4);
						this.VecEff.addElement(point_Focus2);
					}
				}
			}
		}
		bool flag10 = this.f == 26 && !this.checkNullObject(1);
		if (flag10)
		{
			this.objFireMain.dy = 0;
			this.objFireMain.isTanHinh = false;
			this.objFireMain.isPaintLeg = true;
		}
		bool flag11 = this.f >= this.fRemove && this.VecEff.size() == 0 && this.VecSubEff.size() == 0;
		if (flag11)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000229 RID: 553 RVA: 0x000494C4 File Offset: 0x000476C4
	private void update_Mon_Smoker_1()
	{
		for (int i = 0; i < this.VecSubEff.size(); i++)
		{
			Point point = (Point)this.VecSubEff.elementAt(i);
			point.update();
			bool flag = point.f >= point.fRe;
			if (flag)
			{
				this.VecSubEff.removeElement(point);
				i--;
			}
		}
		for (int j = 0; j < this.VecEff.size(); j++)
		{
			Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(j);
			point_Focus.update_Vx_Vy();
			Point point2 = new Point();
			point2.x = point_Focus.x;
			point2.y = point_Focus.y;
			point2.vx = 0;
			point2.vy = -CRes.random(1, 3);
			point2.fRe = CRes.random(3, 6);
			this.VecSubEff.addElement(point2);
			bool flag2 = point_Focus.f >= point_Focus.fRe;
			if (flag2)
			{
				this.addSound(5);
				this.addVir(5, 5, 10, false);
				GameScreen.addEffectEnd(18, 0, point_Focus.x, point_Focus.y, this.Dir, this.objMainEff);
				this.VecEff.removeElement(point_Focus);
				j--;
			}
		}
		bool flag3 = this.f <= 7 && CRes.random(4) == 0;
		if (flag3)
		{
			Point point3 = new Point();
			point3.x = this.x + CRes.random_Am_0(15);
			point3.y = this.y + CRes.random(20);
			point3.vx = CRes.random_Am_0(3);
			point3.vy = -CRes.random(3, 7);
			point3.fRe = CRes.random(6, 10);
			this.VecSubEff.addElement(point3);
		}
		bool flag4 = this.f == 9 && !this.checkNullObject(1);
		if (flag4)
		{
			this.objFireMain.isPaintLeg = false;
		}
		bool flag5 = this.f == 11;
		if (flag5)
		{
			this.addSound(3);
			bool flag6 = !this.checkNullObject(1);
			if (flag6)
			{
				this.objFireMain.isTanHinh = true;
			}
		}
		bool flag7 = this.f == 15;
		if (flag7)
		{
			int num = this.y - 160 + CRes.random_Am_0(20);
			for (int k = 0; k < this.vecObjsBeFire.size(); k++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(k);
				bool flag8 = object_Effect_Skill != null;
				if (flag8)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					bool flag9 = mainObject != null;
					if (flag9)
					{
						Point_Focus point_Focus2 = new Point_Focus();
						int num2 = CRes.random_Am_0(15);
						int num3 = CRes.random_Am_0(10);
						int xdich = mainObject.x + num2 - mainObject.x;
						int ydich = mainObject.y + num3 - num;
						point_Focus2 = base.create_Speed(xdich, ydich, point_Focus2, mainObject.x, num, mainObject.x + num2, mainObject.y + num3);
						this.VecEff.addElement(point_Focus2);
					}
				}
			}
		}
		bool flag10 = this.f == 18 && !this.checkNullObject(1);
		if (flag10)
		{
			this.objFireMain.dy = 0;
			this.objFireMain.isTanHinh = false;
			this.objFireMain.isPaintLeg = true;
		}
		bool flag11 = this.f >= this.fRemove && this.VecEff.size() == 0 && this.VecSubEff.size() == 0;
		if (flag11)
		{
			this.removeEff();
		}
	}

	// Token: 0x0600022A RID: 554 RVA: 0x000498A8 File Offset: 0x00047AA8
	private void update_Mon_Smoker_2()
	{
		for (int i = 0; i < this.VecSubEff.size(); i++)
		{
			Point point = (Point)this.VecSubEff.elementAt(i);
			point.f++;
			bool flag = point.f / 2 >= this.fraImgSubEff.nFrame;
			if (flag)
			{
				this.VecSubEff.removeElement(point);
				i--;
			}
		}
		for (int j = 0; j < this.VecEff.size(); j++)
		{
			Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(j);
			point_Focus.update_Vx_Vy();
			bool flag2 = this.f % 2 == 0;
			if (flag2)
			{
				Point point2 = new Point();
				point2.x = point_Focus.x;
				point2.y = point_Focus.y;
				this.VecSubEff.addElement(point2);
			}
			bool flag3 = point_Focus.f == point_Focus.fRe;
			if (flag3)
			{
				this.addSound(14);
				GameScreen.addEffectEnd(18, 0, point_Focus.x, point_Focus.y, this.Dir, this.objMainEff);
				this.VecEff.removeElement(point_Focus);
				j--;
			}
		}
		bool flag4 = this.f == 8;
		if (flag4)
		{
			this.addSound(19);
			for (int k = 0; k < this.vecObjsBeFire.size(); k++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(k);
				bool flag5 = object_Effect_Skill != null;
				if (flag5)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					bool flag6 = mainObject != null;
					if (flag6)
					{
						Point_Focus point_Focus2 = new Point_Focus();
						int xdich = mainObject.x - this.x;
						int ydich = mainObject.y - mainObject.hOne / 2 - this.y;
						point_Focus2 = base.create_Speed(xdich, ydich, point_Focus2, this.x, this.y, mainObject.x, mainObject.y - mainObject.hOne / 2);
						this.VecEff.addElement(point_Focus2);
					}
				}
			}
		}
		bool flag7 = this.f >= this.fRemove && this.VecEff.size() == 0 && this.VecSubEff.size() == 0;
		if (flag7)
		{
			this.removeEff();
		}
	}

	// Token: 0x0600022B RID: 555 RVA: 0x00049B38 File Offset: 0x00047D38
	private void update_Mon_5()
	{
		bool flag = this.f == 3 && !this.checkNullObject(1);
		if (flag)
		{
			int num = 20;
			bool flag2 = this.Dir == 0;
			if (flag2)
			{
				num = -20;
			}
			GameScreen.addEffectEnd(72, 2, this.x + num, this.objFireMain.y - this.objFireMain.hOne / 2, this.Dir, this.objMainEff);
		}
		bool flag3 = this.f >= this.fRemove;
		if (flag3)
		{
			bool flag4 = !this.checkNullObject(1);
			if (flag4)
			{
				this.objFireMain.isPaintWeapon = true;
			}
			GameScreen.addEffectEnd(1, 0, this.toX + CRes.random_Am_0(15), this.toY + CRes.random_Am_0(15), this.Dir, this.objMainEff);
			this.removeEff();
		}
	}

	// Token: 0x0600022C RID: 556 RVA: 0x00049C1C File Offset: 0x00047E1C
	private void update_Mon_Valentine()
	{
		bool flag = this.f == 16;
		if (flag)
		{
			for (int i = 0; i < this.vecObjsBeFire.size(); i++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(i);
				bool flag2 = object_Effect_Skill != null;
				if (flag2)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					bool flag3 = mainObject != null;
					if (flag3)
					{
						GameScreen.addEffectEnd(63, 0, mainObject.x, mainObject.y, this.Dir, this.objMainEff);
						GameScreen.addEffectEnd(59, 0, mainObject.x, mainObject.y, this.Dir, this.objMainEff);
						base.setAva(1, mainObject);
					}
				}
			}
			LoadMap.timeVibrateScreen = 10;
			bool flag4 = !this.checkNullObject(1);
			if (flag4)
			{
				this.objFireMain.y += 4;
			}
		}
		bool flag5 = this.f >= this.fRemove;
		if (flag5)
		{
			this.removeEff();
		}
	}

	// Token: 0x0600022D RID: 557 RVA: 0x00049D3C File Offset: 0x00047F3C
	private void update_Mon_Mr5()
	{
		bool flag = this.f < this.fRemove;
		if (!flag)
		{
			this.removeEff();
			for (int i = 0; i < this.vecObjsBeFire.size(); i++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(i);
				bool flag2 = object_Effect_Skill != null;
				if (flag2)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					bool flag3 = mainObject != null;
					if (flag3)
					{
						GameScreen.addEffectEnd(4, 0, mainObject.x + CRes.random_Am_0(15), mainObject.y - CRes.random(0, mainObject.hOne / 4 * 3) - 10, this.Dir, this.objMainEff);
						base.setAva(1, mainObject);
					}
				}
			}
		}
	}

	// Token: 0x0600022E RID: 558 RVA: 0x00049E14 File Offset: 0x00048014
	private void update_Crocodile_1()
	{
		for (int i = 0; i < this.VecSubEff.size(); i++)
		{
			Point point = (Point)this.VecSubEff.elementAt(i);
			point.update();
			bool flag = point.f >= point.fRe;
			if (flag)
			{
				this.VecSubEff.removeElementAt(i);
				i--;
			}
		}
		for (int j = 0; j < this.VecEff.size(); j++)
		{
			Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(j);
			point_Focus.update_Vx_Vy();
			bool flag2 = point_Focus.f % 2 == 0;
			if (flag2)
			{
				Point point2 = new Point(point_Focus.x, point_Focus.y);
				point2.fRe = 4;
				this.VecSubEff.addElement(point2);
			}
			bool flag3 = point_Focus.f >= point_Focus.fRe;
			if (flag3)
			{
				this.VecEff.removeElementAt(j);
				j--;
			}
		}
		bool flag4 = this.f == 9 && !this.checkNullObject(2);
		if (flag4)
		{
			bool flag5 = this.typeEffect == 235 && !GameCanvas.lowGraphic;
			if (flag5)
			{
				int num = this.objBeFireMain.x - this.am_duong * 48 - this.objFireMain.x;
				int num2 = this.objBeFireMain.y - this.objFireMain.y;
				Point_Focus point_Focus2 = new Point_Focus(this.objFireMain.x * 10, this.objFireMain.y * 10);
				base.create_Speed(num * 10, num2 * 10, point_Focus2, this.objFireMain.x * 10, this.objFireMain.y * 10, (this.objBeFireMain.x - this.am_duong * 48) * 10, this.objBeFireMain.y);
				this.VecEff.addElement(point_Focus2);
			}
			this.objFireMain.x = this.objBeFireMain.x - this.am_duong * 48;
			this.objFireMain.y = this.objBeFireMain.y;
		}
		bool flag6 = this.f == 12 && !this.checkNullObject(1);
		if (flag6)
		{
			this.objFireMain.isTanHinh = false;
		}
		bool flag7 = this.f == 15;
		if (flag7)
		{
			bool flag8 = !this.checkNullObject(2);
			if (flag8)
			{
				bool flag9 = this.isAddSound;
				if (flag9)
				{
					mSound.playSound(5, mSound.volumeSound);
				}
				this.addVir(10, 5, 10, true);
				bool flag10 = this.vecObjsBeFire.size() > 1;
				if (flag10)
				{
					for (int k = 0; k < this.vecObjsBeFire.size(); k++)
					{
						Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(k);
						bool flag11 = object_Effect_Skill != null;
						if (flag11)
						{
							MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
							bool flag12 = mainObject != null;
							if (flag12)
							{
								GameScreen.addEffectEnd(63, 0, mainObject.x + 10, mainObject.y, this.Dir, mainObject);
								GameScreen.addEffectEnd(98, 0, mainObject.x, mainObject.y + 5, this.Dir, mainObject);
								GameScreen.addEffectEnd(110, 0, mainObject.x, mainObject.y + 5, this.Dir, mainObject);
								GameScreen.addEffectEnd(108, 5, mainObject.x, mainObject.y - mainObject.hOne / 2, this.Dir, mainObject);
								base.setAva(1, mainObject);
							}
						}
					}
				}
				else
				{
					GameScreen.addEffectEnd(63, 0, this.objBeFireMain.x, this.objBeFireMain.y, this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(63, 0, this.objBeFireMain.x - 10, this.objBeFireMain.y, this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(63, 0, this.objBeFireMain.x + 10, this.objBeFireMain.y, this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(98, 0, this.objBeFireMain.x, this.objBeFireMain.y + 5, this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(59, 0, this.objBeFireMain.x, this.objBeFireMain.y + 5, this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(110, 0, this.objBeFireMain.x, this.objBeFireMain.y + 5, this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(108, 5, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
				}
				bool flag13 = this.typeEffect == 235 && !GameCanvas.lowGraphic;
				if (flag13)
				{
					GameScreen.addEffectEnd(54, 10, this.objBeFireMain.x, this.objBeFireMain.y, this.Dir, this.objMainEff);
				}
			}
			base.setAva(2, this.objBeFireMain);
		}
		bool flag14 = this.f >= this.fRemove;
		if (flag14)
		{
			bool flag15 = !this.checkNullObject(1);
			if (flag15)
			{
				this.objFireMain.isTanHinh = false;
			}
			this.removeEff();
		}
	}

	// Token: 0x0600022F RID: 559 RVA: 0x0004A3F0 File Offset: 0x000485F0
	private void update_Crocodile_2()
	{
		bool flag = this.f % 2 == 0 && this.f <= this.fRemove - 3;
		if (flag)
		{
			Point point = new Point(this.x + CRes.random_Am_0(10), this.y + 10 + CRes.random_Am_0(10));
			point.vx = CRes.random_Am_0(3);
			point.vy = -CRes.random(3, 5);
			point.fRe = CRes.random(10, 14);
			this.VecEff.addElement(point);
		}
		bool flag2 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag2)
		{
			this.removeEff();
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point2 = (Point)this.VecEff.elementAt(i);
			point2.update();
			bool flag3 = point2.f >= point2.fRe;
			if (flag3)
			{
				this.VecEff.removeElement(point2);
				i--;
			}
		}
		bool flag4 = this.f == 13 && !this.checkNullObject(1);
		if (flag4)
		{
			sbyte subtype = 1;
			bool flag5 = this.typeEffect == 236 && !GameCanvas.lowGraphic;
			if (flag5)
			{
				subtype = 11;
			}
			GameScreen.addEffectEnd(54, (int)subtype, this.objFireMain.x, this.objFireMain.y - this.objFireMain.hOne / 2, this.Dir, this.objMainEff);
		}
		bool flag6 = this.f == 15;
		if (flag6)
		{
			for (int j = 0; j < this.vecObjsBeFire.size(); j++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(j);
				bool flag7 = object_Effect_Skill != null;
				if (flag7)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					bool flag8 = mainObject != null;
					if (flag8)
					{
						GameScreen.addEffectEnd(63, 0, this.objBeFireMain.x, this.objBeFireMain.y, this.Dir, this.objMainEff);
						GameScreen.addEffectEnd(99, 0, mainObject.x, mainObject.y, this.Dir, this.objMainEff);
						GameScreen.addEffectEnd(59, 0, mainObject.x, mainObject.y, this.Dir, this.objMainEff);
						base.setAva(1, mainObject);
					}
				}
			}
		}
		bool flag9 = this.isAddSound && (this.f == 14 || this.f == 17 || this.f == 20);
		if (flag9)
		{
			mSound.playSound(5, mSound.volumeSound);
		}
	}

	// Token: 0x06000230 RID: 560 RVA: 0x0004A6D0 File Offset: 0x000488D0
	private void update_Wapol_4()
	{
		bool flag = this.f == 5 && !this.checkNullObject(2);
		if (flag)
		{
			GameScreen.addEffectEnd(57, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
			base.setAva(1, this.objBeFireMain);
		}
		bool flag2 = this.f == 8;
		if (flag2)
		{
			this.vx = 0;
		}
		bool flag3 = this.f >= this.fRemove;
		if (flag3)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000231 RID: 561 RVA: 0x0004A778 File Offset: 0x00048978
	private void update_Nham_thach_2()
	{
		bool flag = this.f > 10 && this.f % 3 == 0;
		if (flag)
		{
			sbyte subtype = 0;
			bool flag2 = this.typeEffect == 240;
			if (flag2)
			{
				subtype = 1;
			}
			bool flag3 = this.indexObjBefire < this.vecObjsBeFire.size();
			if (flag3)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(this.indexObjBefire);
				this.indexObjBefire++;
				bool flag4 = object_Effect_Skill != null;
				if (flag4)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					bool flag5 = mainObject != null;
					if (flag5)
					{
						GameScreen.addEffectEnd(113, (int)subtype, mainObject.x, mainObject.y, this.Dir, this.objMainEff);
						base.setAva(2, mainObject);
					}
				}
			}
			else
			{
				bool flag6 = CRes.random(2) == 0;
				if (flag6)
				{
					GameScreen.addEffectEnd(113, (int)subtype, this.objBeFireMain.x + CRes.random_Am_0(160), this.objBeFireMain.y + CRes.random_Am_0(80), this.Dir, this.objMainEff);
				}
			}
			bool flag7 = this.f % 6 == 0;
			if (flag7)
			{
				this.addSound(15);
			}
			this.addVir(3, 5, 10, false);
		}
		bool flag8 = this.f >= this.fRemove;
		if (flag8)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000232 RID: 562 RVA: 0x0004A8F8 File Offset: 0x00048AF8
	private void update_Mr1_1()
	{
		bool flag = this.f >= this.fRemove;
		if (flag)
		{
			this.removeEff();
		}
		else
		{
			bool flag2 = this.f % 4 != 0;
			if (!flag2)
			{
				for (int i = 0; i < this.vecObjsBeFire.size(); i++)
				{
					Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(i);
					bool flag3 = object_Effect_Skill == null;
					if (!flag3)
					{
						MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
						bool flag4 = mainObject != null;
						if (flag4)
						{
							base.setAva(1, mainObject);
							bool flag5 = !this.checkNullObject(2);
							if (flag5)
							{
								GameScreen.addEffectEnd(1, 0, mainObject.x + CRes.random_Am_0(10), mainObject.y - mainObject.hOne / 2 + CRes.random_Am_0(10), this.Dir, this.objMainEff);
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x06000233 RID: 563 RVA: 0x0004A9FC File Offset: 0x00048BFC
	private void update_Mr1_2()
	{
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(i);
			point_Focus.update_Vx_Vy();
			bool flag = point_Focus.f == point_Focus.fRe;
			if (flag)
			{
				GameScreen.addEffectEnd(1, 0, point_Focus.x + CRes.random_Am_0(10), point_Focus.y + CRes.random_Am_0(10), this.Dir, this.objMainEff);
				base.setAva(1, point_Focus.objMain);
			}
			bool flag2 = point_Focus.f >= point_Focus.fRe + 6;
			if (flag2)
			{
				this.VecEff.removeElement(point_Focus);
				i--;
			}
		}
		bool flag3 = this.f == 2;
		if (flag3)
		{
			for (int j = 0; j < this.vecObjsBeFire.size(); j++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(j);
				bool flag4 = object_Effect_Skill == null;
				if (!flag4)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					bool flag5 = mainObject != null;
					if (flag5)
					{
						Point_Focus point_Focus2 = new Point_Focus();
						point_Focus2.x = this.x;
						point_Focus2.y = this.y;
						int xdich = mainObject.x - point_Focus2.x;
						int ydich = mainObject.y - mainObject.hOne / 2 - point_Focus2.y;
						point_Focus2 = base.create_Speed(xdich, ydich, point_Focus2);
						point_Focus2.objMain = mainObject;
						point_Focus2.dis = 0;
						bool flag6 = this.x < mainObject.x;
						if (flag6)
						{
							point_Focus2.dis = 2;
						}
						this.VecEff.addElement(point_Focus2);
					}
				}
			}
		}
		bool flag7 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag7)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000234 RID: 564 RVA: 0x0004AC10 File Offset: 0x00048E10
	private void update_DF_1()
	{
		bool flag = !this.checkNullObject(1);
		if (flag)
		{
			bool flag2 = this.f >= 4 && this.f <= 10;
			if (flag2)
			{
				this.objFireMain.vx = this.vMax * this.am_duong;
			}
			else
			{
				this.objFireMain.vx = 0;
			}
		}
		bool flag3 = this.f >= this.fRemove;
		if (flag3)
		{
			bool flag4 = !this.checkNullObject(2);
			if (flag4)
			{
				GameScreen.addEffectEnd(10, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.dy - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
			}
			this.removeEff();
		}
	}

	// Token: 0x06000235 RID: 565 RVA: 0x0004ACE8 File Offset: 0x00048EE8
	private void update_DF_2()
	{
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point = (Point)this.VecEff.elementAt(i);
			point.update();
			bool flag = point.f < 4;
			if (flag)
			{
				point.frame = point.f / 2;
			}
			else
			{
				bool flag2 = point.f >= 4 && point.f <= point.fRe - 2;
				if (flag2)
				{
					point.frame = 2;
				}
				else
				{
					point.frame = point.fRe - point.f;
				}
			}
			bool flag3 = point.f >= point.fRe;
			if (flag3)
			{
				this.VecEff.removeElementAt(i);
				i--;
			}
		}
		bool flag4 = this.f == 2;
		if (flag4)
		{
			for (int j = 0; j < this.vecObjsBeFire.size(); j++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(j);
				bool flag5 = object_Effect_Skill != null;
				if (flag5)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					bool flag6 = mainObject != null;
					if (flag6)
					{
						Point point2 = new Point();
						point2.x = mainObject.x;
						point2.y = mainObject.y + 4;
						point2.fRe = 30 + CRes.random(12);
						GameScreen.addEffectEnd(10, 0, mainObject.x, mainObject.y - mainObject.dy - mainObject.hOne / 2, this.Dir, this.objMainEff);
						this.VecEff.addElement(point2);
					}
				}
			}
			bool flag7 = this.objBeFireMain != null;
			if (flag7)
			{
				for (int k = 0; k < 4; k++)
				{
					Point point3 = new Point();
					point3.x = this.objBeFireMain.x + CRes.random_Am_0(160);
					point3.y = this.objBeFireMain.y + 4 + CRes.random_Am_0(80);
					point3.fRe = 30 + CRes.random(12);
					this.VecEff.addElement(point3);
				}
			}
		}
		bool flag8 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag8)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000236 RID: 566 RVA: 0x0004AF70 File Offset: 0x00049170
	private void update_Mr0_1()
	{
		bool flag = this.f == 10 && !this.checkNullObject(2);
		if (flag)
		{
			this.vx = this.am_duong * this.vMax;
		}
		bool flag2 = this.f == 15;
		if (flag2)
		{
			GameScreen.addEffectEnd_ToX_ToY(62, 0, this.x, this.y - 30, this.x + this.vx * 20, this.y - 30, this.Dir, this.objMainEff);
			GameScreen.addEffectEnd_ToX_ToY(62, 0, this.x + 10 * this.am_duong, this.y - 20, this.x + this.vx * 20, this.y - 20, this.Dir, this.objMainEff);
			GameScreen.addEffectEnd_ToX_ToY(62, 0, this.x + 20 * this.am_duong, this.y - 10, this.x + this.vx * 20, this.y - 10, this.Dir, this.objMainEff);
			GameScreen.addEffectEnd_ToX_ToY(62, 0, this.x + 30 * this.am_duong, this.y, this.x + this.vx * 20, this.y, this.Dir, this.objMainEff);
		}
		bool flag3 = this.f < 10;
		if (flag3)
		{
			this.frame = -1;
		}
		else
		{
			bool flag4 = this.f < 14;
			if (flag4)
			{
				this.frame = 0;
			}
			else
			{
				bool flag5 = this.f < 30;
				if (flag5)
				{
					this.frame = 1;
				}
				else
				{
					bool flag6 = this.f < 35;
					if (flag6)
					{
						this.frame = 2;
					}
				}
			}
		}
		bool flag7 = this.f < this.fRemove;
		if (!flag7)
		{
			this.removeEff();
			for (int i = 0; i < this.vecObjsBeFire.size(); i++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(i);
				bool flag8 = object_Effect_Skill != null;
				if (flag8)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					bool flag9 = mainObject != null;
					if (flag9)
					{
						base.setAva(2, mainObject);
					}
				}
			}
		}
	}

	// Token: 0x06000237 RID: 567 RVA: 0x0004B1C0 File Offset: 0x000493C0
	private void update_Pell_1()
	{
		bool flag = this.f > 1 && this.f < 26;
		if (flag)
		{
			this.objFireMain.isTanHinh = true;
		}
		else
		{
			this.objFireMain.isTanHinh = false;
		}
		for (int i = 0; i < this.VecSubEff.size(); i++)
		{
			Point point = (Point)this.VecSubEff.elementAt(i);
			point.update();
			bool flag2 = this.frame == 1;
			if (flag2)
			{
				point.frame = CRes.random(2);
			}
			bool flag3 = point.f >= point.fRe;
			if (flag3)
			{
				this.VecSubEff.removeElement(point);
				i--;
			}
		}
		for (int j = 0; j < this.VecEff.size(); j++)
		{
			Point point2 = (Point)this.VecEff.elementAt(j);
			point2.update();
			bool flag4 = this.typeEffect == 241;
			if (flag4)
			{
				Point point3 = new Point(point2.x, point2.y);
				bool flag5 = this.frame == 1;
				if (flag5)
				{
					point3.x = point2.x + point2.vx + CRes.random_Am_0(5);
					point3.y = point2.y + point2.vy + 5 + CRes.random_Am_0(15);
					point3.fRe = 10;
					point3.vx = CRes.random_Am_0(2);
					point3.vy = -CRes.random_Am(2, 5);
					Point point4 = new Point(point2.x + point2.vx + CRes.random_Am_0(5), point2.y + point2.vy + 5 + CRes.random_Am_0(15));
					point4.fRe = 10;
					point4.vx = CRes.random_Am_0(2);
					point4.vy = -CRes.random_Am(2, 5);
					this.VecSubEff.addElement(point4);
				}
				else
				{
					point3.fRe = 3;
					point3.frame = CRes.random(3);
				}
				this.VecSubEff.addElement(point3);
			}
			bool flag6 = point2.f > 10;
			if (flag6)
			{
				point2.vy -= 2;
			}
			else
			{
				point2.vy--;
			}
			bool flag7 = point2.f == 10 && !this.checkNullObject(2);
			if (flag7)
			{
				bool flag8 = this.frame == 1;
				if (flag8)
				{
					GameScreen.addEffectEnd(118, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(54, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
				}
				else
				{
					GameScreen.addEffectEnd(1, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
				}
				base.setAva(2, this.objBeFireMain);
			}
			bool flag9 = point2.f >= point2.fRe;
			if (flag9)
			{
				this.VecEff.removeElement(point2);
				j--;
			}
		}
		bool flag10 = this.f == 4;
		if (flag10)
		{
			bool flag11 = this.isAddSound;
			if (flag11)
			{
				bool flag12 = this.frame == 0;
				if (flag12)
				{
					mSound.playSound(13, mSound.volumeSound);
				}
				else
				{
					mSound.playSound(23, mSound.volumeSound);
				}
			}
			Point point5 = new Point();
			int num = this.toX;
			int num2 = this.toY;
			bool flag13 = !this.checkNullObject(2);
			if (flag13)
			{
				num = this.objBeFireMain.x;
				num2 = this.objBeFireMain.y - this.objBeFireMain.hOne / 2;
			}
			point5.x = num - this.am_duong * 240;
			point5.vx = 24 * this.am_duong;
			point5.y = num2 - 55;
			point5.vy = 9;
			point5.dis = (int)this.Dir;
			point5.fRe = 20;
			this.VecEff.addElement(point5);
		}
		bool flag14 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag14)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000238 RID: 568 RVA: 0x0004B67C File Offset: 0x0004987C
	private void update_Enel_1()
	{
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point = (Point)this.VecEff.elementAt(i);
			point.update();
			bool flag = point.f >= point.fRe;
			if (flag)
			{
				this.VecEff.removeElementAt(i);
				i--;
			}
		}
		bool flag2 = this.f > 10 && this.f < this.fRemove && this.f % 2 == 0;
		if (flag2)
		{
			bool flag3 = this.indexObjBefire < this.vecObjsBeFire.size();
			if (flag3)
			{
				for (int j = 0; j < this.vecObjsBeFire.size(); j++)
				{
					Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(this.indexObjBefire);
					bool flag4 = object_Effect_Skill != null;
					if (flag4)
					{
						MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
						bool flag5 = mainObject != null;
						if (flag5)
						{
							Point point2 = new Point();
							point2.x = mainObject.x * 10;
							point2.y = (mainObject.y + 4) * 10;
							point2.vx = CRes.random_Am_0(30);
							point2.vy = CRes.random_Am_0(30);
							point2.fRe = 15 + CRes.random(6);
							GameScreen.addEffectEnd(10, 0, mainObject.x, mainObject.y - mainObject.dy - mainObject.hOne / 2, this.Dir, this.objMainEff);
							base.setAva(2, mainObject);
							this.VecEff.addElement(point2);
						}
					}
					this.indexObjBefire++;
				}
			}
			else
			{
				Point point3 = new Point();
				point3.x = (this.objBeFireMain.x + CRes.random_Am_0(100)) * 10;
				point3.y = (this.objBeFireMain.y + CRes.random_Am_0(80)) * 10;
				point3.vx = CRes.random_Am_0(30);
				point3.vy = CRes.random_Am_0(30);
				point3.fRe = 10 + CRes.random(6);
				this.VecEff.addElement(point3);
			}
		}
		bool flag6 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag6)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000239 RID: 569 RVA: 0x0004B90C File Offset: 0x00049B0C
	private void update_Enel_2()
	{
		bool flag = this.f >= this.fRemove;
		if (flag)
		{
			this.removeEff();
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point = (Point)this.VecEff.elementAt(i);
			point.f++;
			bool flag2 = point.f >= 3;
			if (flag2)
			{
				this.VecEff.removeElement(point);
				i--;
			}
		}
		for (int j = 0; j < this.VecSubEff.size(); j++)
		{
			Point point2 = (Point)this.VecSubEff.elementAt(j);
			point2.f++;
			bool flag3 = point2.f >= point2.fRe;
			if (flag3)
			{
				this.VecSubEff.removeElement(point2);
				j--;
			}
		}
		bool flag4 = this.f == 0 || this.f == 9;
		if (flag4)
		{
			int num = 0;
			for (int k = 0; k < 8; k++)
			{
				Point o = new Point(this.x + CRes.getcos(num) * 30 / 1000, this.y + CRes.getsin(num) * 25 / 1000);
				this.VecEff.addElement(o);
				num += 45;
			}
		}
		bool flag5 = this.f == 3 || this.f == 12;
		if (flag5)
		{
			int num2 = 0;
			for (int l = 0; l < 12; l++)
			{
				Point o2 = new Point(this.x + CRes.getcos(num2) * 40 / 1000, this.y + CRes.getsin(num2) * 30 / 1000);
				this.VecEff.addElement(o2);
				num2 += 30;
			}
		}
		int num3 = 0;
		bool flag6 = this.f == 15;
		if (flag6)
		{
			int num4 = 0;
			for (int m = 0; m < 16; m++)
			{
				num3++;
				Point o3 = new Point(this.x + CRes.getcos(num4) * 55 / 1000, this.y + CRes.getsin(num4) * 35 / 1000);
				this.VecEff.addElement(o3);
				num4 += 22;
			}
			Point point3 = new Point(this.x, this.y);
			point3.frame = 0;
			point3.fRe = 4;
			this.VecSubEff.addElement(point3);
		}
		bool flag7 = this.f == 18;
		if (flag7)
		{
			Point point4 = new Point(this.x, this.y);
			point4.frame = 1;
			point4.fRe = 4;
			this.VecSubEff.addElement(point4);
		}
		bool flag8 = this.f != 22;
		if (!flag8)
		{
			for (int n = 0; n < this.vecObjsBeFire.size(); n++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(n);
				bool flag9 = object_Effect_Skill != null;
				if (flag9)
				{
					MainObject obj = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					base.setAva(2, obj);
				}
			}
			GameScreen.addEffectEnd(121, 0, this.x, this.y, this.Dir, this.objMainEff);
		}
	}

	// Token: 0x0600023A RID: 570 RVA: 0x0004BCA8 File Offset: 0x00049EA8
	private void update_Enel_3()
	{
		bool flag = this.f == 4;
		if (flag)
		{
			this.vx = this.am_duong * 8;
			for (int i = 0; i < this.vecObjsBeFire.size(); i++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(i);
				bool flag2 = object_Effect_Skill != null;
				if (flag2)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					bool flag3 = mainObject != null;
					if (flag3)
					{
						base.setAva(2, mainObject);
						GameScreen.addEffectEnd(42, 0, mainObject.x, mainObject.y, this.Dir, mainObject);
					}
				}
			}
		}
		bool flag4 = this.f >= this.fRemove;
		if (flag4)
		{
			this.removeEff();
		}
	}

	// Token: 0x0600023B RID: 571 RVA: 0x0004BD7C File Offset: 0x00049F7C
	private void update_Satori_1()
	{
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(i);
			point_Focus.update_Vx_Vy();
			point_Focus.frame = 2 + point_Focus.f % 2;
			bool flag = point_Focus.f >= point_Focus.fRe;
			if (flag)
			{
				GameScreen.addEffectEnd(122, 0, point_Focus.x, point_Focus.y, this.Dir, this.objMainEff);
				this.VecEff.removeElementAt(i);
				i--;
			}
		}
		bool flag2 = this.f == 8;
		if (flag2)
		{
			for (int j = 0; j < this.vecObjsBeFire.size(); j++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(j);
				bool flag3 = object_Effect_Skill != null;
				if (flag3)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					bool flag4 = mainObject != null;
					if (flag4)
					{
						Point_Focus point_Focus2 = new Point_Focus();
						point_Focus2.x = this.x;
						point_Focus2.y = this.y;
						int xdich = mainObject.x - point_Focus2.x;
						int ydich = mainObject.y - mainObject.hOne / 2 - point_Focus2.y;
						point_Focus2 = base.create_Speed(xdich, ydich, point_Focus2);
						point_Focus2.objMain = mainObject;
						point_Focus2.frame = 1;
						bool flag5 = point_Focus2.fRe < 3;
						if (flag5)
						{
							point_Focus2.fRe = 3;
						}
						this.VecEff.addElement(point_Focus2);
					}
				}
				this.indexObjBefire++;
			}
			for (int k = this.indexObjBefire; k < 5; k++)
			{
				Point_Focus point_Focus3 = new Point_Focus();
				point_Focus3.x = this.x;
				point_Focus3.y = this.y;
				int xdich2 = 110 * this.am_duong + CRes.random_Am_0(50);
				int ydich2 = CRes.random_Am_0(40);
				point_Focus3 = base.create_Speed(xdich2, ydich2, point_Focus3);
				point_Focus3.objMain = null;
				point_Focus3.frame = 1;
				bool flag6 = point_Focus3.fRe < 3;
				if (flag6)
				{
					point_Focus3.fRe = 3;
				}
				this.VecEff.addElement(point_Focus3);
			}
		}
		bool flag7 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag7)
		{
			this.removeEff();
		}
	}

	// Token: 0x0600023C RID: 572 RVA: 0x0004C018 File Offset: 0x0004A218
	private void update_Satori_2()
	{
		bool flag = this.f < 4 || (this.f >= 9 && this.f < 13);
		if (flag)
		{
			this.objFireMain.isTanHinh = true;
		}
		else
		{
			this.objFireMain.isTanHinh = false;
		}
		bool flag2 = this.f == 2 && !this.checkNullObject(3);
		if (flag2)
		{
			this.x1000 = this.objFireMain.x;
			this.y1000 = this.objFireMain.y;
			this.objFireMain.x = this.objBeFireMain.x - this.am_duong * 30;
			this.objFireMain.y = this.objBeFireMain.y;
			this.x = this.objFireMain.x;
			this.y = this.objFireMain.y;
		}
		bool flag3 = this.f == 11 && !this.checkNullObject(3);
		if (flag3)
		{
			this.objFireMain.x = this.x1000;
			this.objFireMain.y = this.y1000;
			this.x = this.objFireMain.x;
			this.y = this.objFireMain.y;
		}
		bool flag4 = this.f == 7;
		if (flag4)
		{
			GameScreen.addEffectEnd(123, 1, this.objBeFireMain.x + CRes.random_Am_0(15), this.objBeFireMain.y - this.objBeFireMain.hOne / 2 - 10 + CRes.random_Am_0(15), this.Dir, this.objMainEff);
			base.setAva(2, this.objBeFireMain);
		}
		bool flag5 = this.f >= this.fRemove;
		if (flag5)
		{
			this.removeEff();
		}
	}

	// Token: 0x0600023D RID: 573 RVA: 0x0004C1EC File Offset: 0x0004A3EC
	private void update_Ohm_1()
	{
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(i);
			point_Focus.update_Vx_Vy();
			bool flag = point_Focus.f == point_Focus.fRe && point_Focus.objMain != null;
			if (flag)
			{
				GameScreen.addEffectEnd(123, 3, point_Focus.x, point_Focus.y, this.Dir, this.objMainEff);
				base.setAva(2, point_Focus.objMain);
			}
			bool flag2 = point_Focus.f >= point_Focus.fRe + 3;
			if (flag2)
			{
				this.VecEff.removeElementAt(i);
				i--;
			}
		}
		bool flag3 = this.f >= 10 && this.f % 2 == 0 && this.f < 20;
		if (flag3)
		{
			bool flag4 = this.indexObjBefire < this.vecObjsBeFire.size();
			if (flag4)
			{
				for (int j = 0; j < this.vecObjsBeFire.size(); j++)
				{
					Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(j);
					bool flag5 = object_Effect_Skill != null;
					if (flag5)
					{
						MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
						bool flag6 = mainObject != null;
						if (flag6)
						{
							Point_Focus point_Focus2 = new Point_Focus();
							point_Focus2.x = this.x;
							point_Focus2.y = this.y;
							int xdich = mainObject.x - point_Focus2.x;
							int ydich = mainObject.y - mainObject.hOne / 2 - point_Focus2.y;
							point_Focus2 = base.create_Speed(xdich, ydich, point_Focus2);
							point_Focus2.objMain = mainObject;
							point_Focus2.frame = CRes.random(4);
							this.VecEff.addElement(point_Focus2);
						}
						this.indexObjBefire++;
					}
				}
			}
			else
			{
				Point_Focus point_Focus3 = new Point_Focus();
				point_Focus3.x = this.x;
				point_Focus3.y = this.y;
				int xdich2 = 150 * this.am_duong + CRes.random_Am_0(50);
				int ydich2 = CRes.random_Am_0(40);
				point_Focus3 = base.create_Speed(xdich2, ydich2, point_Focus3);
				point_Focus3.objMain = null;
				point_Focus3.frame = CRes.random(4);
				point_Focus3.fRe += 5;
				this.VecEff.addElement(point_Focus3);
			}
		}
		bool flag7 = this.f == 20;
		if (flag7)
		{
			this.objFireMain.isPaintWeapon = true;
		}
		bool flag8 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag8)
		{
			this.removeEff();
		}
	}

	// Token: 0x0600023E RID: 574 RVA: 0x0004C4CC File Offset: 0x0004A6CC
	private void update_Ohm_2()
	{
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(i);
			point_Focus.update_Vx_Vy();
			bool flag = point_Focus.f % 2 == 1;
			if (flag)
			{
				GameScreen.addEffectEnd(66, 0, point_Focus.x, point_Focus.y, this.Dir, this.objMainEff);
			}
			bool flag2 = point_Focus.f == point_Focus.fRe;
			if (flag2)
			{
				int tile = GameCanvas.loadmap.getTile(point_Focus.x, point_Focus.y);
				bool flag3 = tile == 0 || tile == 2;
				if (flag3)
				{
					GameScreen.addEffectEnd(124, 0, point_Focus.x, point_Focus.y, this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(125, 0, point_Focus.x, point_Focus.y + 8, this.Dir, this.objMainEff);
				}
				bool flag4 = point_Focus.objMain != null;
				if (flag4)
				{
					base.setAva(2, point_Focus.objMain);
				}
				this.VecEff.removeElementAt(i);
				i--;
			}
		}
		bool flag5 = this.f == 10;
		if (flag5)
		{
			for (int j = 0; j < this.vecObjsBeFire.size(); j++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(j);
				bool flag6 = object_Effect_Skill != null;
				if (flag6)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					bool flag7 = mainObject != null;
					if (flag7)
					{
						Point_Focus point_Focus2 = new Point_Focus();
						point_Focus2.x = this.x;
						point_Focus2.y = this.y;
						int xdich = mainObject.x - point_Focus2.x;
						int ydich = mainObject.y - mainObject.hOne / 2 - point_Focus2.y;
						point_Focus2 = base.create_Speed(xdich, ydich, point_Focus2);
						point_Focus2.objMain = mainObject;
						point_Focus2.frame = 1;
						bool flag8 = point_Focus2.fRe < 3;
						if (flag8)
						{
							point_Focus2.fRe = 3;
						}
						this.VecEff.addElement(point_Focus2);
					}
				}
				this.indexObjBefire++;
			}
			for (int k = this.indexObjBefire; k < 5; k++)
			{
				Point_Focus point_Focus3 = new Point_Focus();
				point_Focus3.x = this.x;
				point_Focus3.y = this.y;
				int xdich2 = CRes.random_Am(60, 140);
				int ydich2 = CRes.random_Am_0(60);
				point_Focus3 = base.create_Speed(xdich2, ydich2, point_Focus3);
				point_Focus3.objMain = null;
				point_Focus3.frame = 1;
				bool flag9 = point_Focus3.fRe < 3;
				if (flag9)
				{
					point_Focus3.fRe = 3;
				}
				this.VecEff.addElement(point_Focus3);
			}
		}
		bool flag10 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag10)
		{
			this.removeEff();
		}
	}

	// Token: 0x0600023F RID: 575 RVA: 0x0004C7F8 File Offset: 0x0004A9F8
	private void update_Gedatsu_1()
	{
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(i);
			point_Focus.update_Vx_Vy();
			bool flag = point_Focus.f > point_Focus.fRe && point_Focus.objMain != null;
			if (flag)
			{
				point_Focus.x = point_Focus.objMain.x;
				point_Focus.y = point_Focus.objMain.y - point_Focus.objMain.hOne / 2;
			}
			bool flag2 = point_Focus.f > point_Focus.fRe + 5;
			if (flag2)
			{
				GameScreen.addEffectEnd(123, 0, point_Focus.x, point_Focus.y, this.Dir, this.objMainEff);
				base.setAva(2, point_Focus.objMain);
				this.VecEff.removeElementAt(i);
				i--;
			}
			bool flag3 = point_Focus.f == point_Focus.fRe;
			if (flag3)
			{
				bool flag4 = point_Focus.objMain == null;
				if (flag4)
				{
					GameScreen.addEffectEnd(123, 0, point_Focus.x, point_Focus.y, this.Dir, this.objMainEff);
					this.VecEff.removeElementAt(i);
					i--;
				}
				else
				{
					point_Focus.vx = 0;
					point_Focus.vy = 0;
					point_Focus.x = point_Focus.objMain.x;
					point_Focus.y = point_Focus.objMain.y - point_Focus.objMain.hOne / 2;
				}
			}
		}
		bool flag5 = this.f == 11 && !this.checkNullObject(1);
		if (flag5)
		{
			for (int j = 0; j < this.vecObjsBeFire.size(); j++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(j);
				bool flag6 = object_Effect_Skill != null;
				if (flag6)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					bool flag7 = mainObject != null;
					if (flag7)
					{
						Point_Focus point_Focus2 = new Point_Focus();
						point_Focus2.x = this.objFireMain.x + this.am_duong * 30;
						point_Focus2.y = this.objFireMain.y - this.objFireMain.hOne / 2 - 10;
						int xdich = mainObject.x - point_Focus2.x;
						int ydich = mainObject.y - mainObject.hOne / 2 - point_Focus2.y;
						point_Focus2 = base.create_Speed(xdich, ydich, point_Focus2);
						point_Focus2.objMain = mainObject;
						point_Focus2.frame = 1;
						this.VecEff.addElement(point_Focus2);
					}
				}
				this.indexObjBefire++;
			}
			for (int k = this.indexObjBefire; k < 5; k++)
			{
				Point_Focus point_Focus3 = new Point_Focus();
				point_Focus3.x = this.objFireMain.x + this.am_duong * 30;
				point_Focus3.y = this.objFireMain.y - this.objFireMain.hOne / 2 - 10;
				int xdich2 = CRes.random_Am(60, 140);
				int ydich2 = CRes.random_Am_0(60);
				point_Focus3 = base.create_Speed(xdich2, ydich2, point_Focus3);
				point_Focus3.objMain = null;
				point_Focus3.frame = 0;
				bool flag8 = point_Focus3.fRe < 3;
				if (flag8)
				{
					point_Focus3.fRe = 3;
				}
				this.VecEff.addElement(point_Focus3);
			}
		}
		bool flag9 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag9)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000240 RID: 576 RVA: 0x0004CBBC File Offset: 0x0004ADBC
	private void update_Gedatsu_2()
	{
		bool flag = this.f < 4;
		if (flag)
		{
			this.objFireMain.isTanHinh = true;
		}
		else
		{
			this.objFireMain.isTanHinh = false;
		}
		bool flag2 = this.f == 2 && !this.checkNullObject(3);
		if (flag2)
		{
			this.x1000 = this.objFireMain.x;
			this.y1000 = this.objFireMain.y;
			bool flag3 = !this.checkNullObject(2);
			if (flag3)
			{
				this.objFireMain.x = this.objBeFireMain.x - this.am_duong * 30;
				this.objFireMain.y = this.objBeFireMain.y;
				this.x = this.objFireMain.x;
				this.y = this.objFireMain.y;
			}
			GameScreen.addEffectEnd(30, 0, this.x, this.y - this.objFireMain.hOne / 2 - 10, 140, this.Dir, this.objMainEff);
		}
		bool flag4 = this.f == 14;
		if (flag4)
		{
			GameScreen.addEffectEnd(123, 0, this.objBeFireMain.x + CRes.random_Am_0(15), this.objBeFireMain.y - this.objBeFireMain.hOne / 2 - 15 + CRes.random_Am_0(15), this.Dir, this.objMainEff);
			base.setAva(2, this.objBeFireMain);
		}
		bool flag5 = this.f >= this.fRemove;
		if (flag5)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000241 RID: 577 RVA: 0x0004CD60 File Offset: 0x0004AF60
	private void update_Shura_1()
	{
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point = (Point)this.VecEff.elementAt(i);
			point.update();
			bool flag = point.f > 10;
			if (flag)
			{
				point.vy -= 2;
			}
			else
			{
				point.vy--;
			}
			bool flag2 = point.f == 10 && !this.checkNullObject(2);
			if (flag2)
			{
				GameScreen.addEffectEnd(123, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
				base.setAva(2, this.objBeFireMain);
			}
			bool flag3 = point.f >= point.fRe;
			if (flag3)
			{
				this.VecEff.removeElement(point);
				i--;
			}
		}
		bool flag4 = this.f == 10;
		if (flag4)
		{
			Point point2 = new Point();
			int num = this.toX;
			int num2 = this.toY;
			bool flag5 = !this.checkNullObject(2);
			if (flag5)
			{
				num = this.objBeFireMain.x;
				num2 = this.objBeFireMain.y - this.objBeFireMain.hOne / 2;
			}
			point2.x = num - this.am_duong * 240;
			point2.vx = 24 * this.am_duong;
			point2.y = num2 - 55;
			point2.vy = 9;
			point2.dis = (int)this.Dir;
			point2.fRe = 20;
			this.VecEff.addElement(point2);
		}
		bool flag6 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag6)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000242 RID: 578 RVA: 0x0004CF5C File Offset: 0x0004B15C
	private void update_Shura_2()
	{
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point = (Point)this.VecEff.elementAt(i);
			point.f++;
			bool flag = point.f >= point.fRe;
			if (flag)
			{
				this.VecEff.removeElementAt(i);
				i--;
			}
		}
		bool flag2 = this.f == 10;
		if (flag2)
		{
			this.x += this.am_duong * 20;
			bool flag3 = this.Dir == 0;
			if (flag3)
			{
				this.x -= 30;
			}
			this.vMax = 5;
			this.vx = this.am_duong * this.vMax;
		}
		bool flag4 = this.f > 10;
		if (flag4)
		{
			int num = 360 - this.f % 12 * 30;
			int num2 = 26 + this.f / 4 * 3;
			this.x1000 = CRes.getcos(CRes.fixangle(num)) * (num2 * 2 / 3);
			this.y1000 = CRes.getsin(CRes.fixangle(num)) * num2;
			bool flag5 = this.f < this.fRemove;
			if (flag5)
			{
				Point point2 = new Point(this.x + this.x1000 / 1000, this.y + this.y1000 / 1000);
				point2.fRe = 12;
				this.VecEff.addElement(point2);
			}
		}
		bool flag6 = this.f == 20;
		if (flag6)
		{
			for (int j = 0; j < this.vecObjsBeFire.size(); j++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(j);
				bool flag7 = object_Effect_Skill != null;
				if (flag7)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					bool flag8 = mainObject != null;
					if (flag8)
					{
						base.setAva(1, mainObject);
					}
				}
			}
		}
		bool flag9 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag9)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000243 RID: 579 RVA: 0x0004D1A0 File Offset: 0x0004B3A0
	private void update_Linh_Troi()
	{
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point = (Point)this.VecEff.elementAt(i);
			point.update();
			bool flag = point.f >= point.fRe;
			if (flag)
			{
				this.VecEff.removeElementAt(i);
				i--;
			}
		}
		bool flag2 = this.f == this.fPlayFrameSuper;
		if (flag2)
		{
			GameScreen.addEffectEnd(1, 0, this.toX + CRes.random_Am_0(12), this.toY + CRes.random_Am_0(12), this.Dir, this.objMainEff);
		}
		else
		{
			bool flag3 = this.f < this.fPlayFrameSuper;
			if (flag3)
			{
				Point point2 = new Point();
				point2.x = this.x;
				point2.y = this.y;
				point2.fRe = 6;
				this.VecEff.addElement(point2);
			}
		}
		bool flag4 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag4)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000244 RID: 580 RVA: 0x0004D2D0 File Offset: 0x0004B4D0
	private void update_Tru_1()
	{
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point = (Point)this.VecEff.elementAt(i);
			point.f++;
			bool flag = point.f >= point.fRe;
			if (flag)
			{
				this.VecEff.removeElementAt(i);
				i--;
			}
		}
		bool flag2 = this.f < this.fRemove;
		if (flag2)
		{
			Point point2 = new Point(this.x, this.y);
			point2.fRe = 5;
			this.VecEff.addElement(point2);
		}
		bool flag3 = this.f == this.fRemove;
		if (flag3)
		{
			GameScreen.addEffectEnd(25, 4, this.toX, this.toY, this.Dir, this.objMainEff);
		}
		bool flag4 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag4)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000245 RID: 581 RVA: 0x0004D3E8 File Offset: 0x0004B5E8
	private void update_Lucci_1()
	{
		bool flag = this.f == 2 || this.f == 4 || this.f == 6;
		if (flag)
		{
			this.x = this.x1000 - this.am_duong * 24;
		}
		bool flag2 = this.f >= 7 && this.vx <= 20;
		if (flag2)
		{
			this.vx += this.am_duong * 2;
		}
		bool flag3 = this.f == 6 && this.isAddSound;
		if (flag3)
		{
			mSound.playSound(39, mSound.volumeSound);
			bool flag4 = this.frame == 1;
			if (flag4)
			{
				mSound.playSound(17, mSound.volumeSound);
			}
		}
		bool flag5 = this.f == 8;
		if (flag5)
		{
			base.setAva(2, this.objBeFireMain);
			GameScreen.addEffectEnd(132, (int)((sbyte)this.frame), this.x + this.am_duong * 10, this.objFireMain.y - this.objFireMain.hOne / 2 - 5, 0, this.Dir, this.objMainEff);
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point = (Point)this.VecEff.elementAt(i);
			point.update();
			bool flag6 = this.frame == 0 && point.f == 2;
			if (flag6)
			{
				point.frame = 0;
			}
			bool flag7 = point.f >= point.fRe;
			if (flag7)
			{
				this.VecEff.removeElement(point);
				i--;
			}
		}
		bool flag8 = this.f < this.fRemove;
		if (flag8)
		{
			bool flag9 = this.frame == 1;
			if (flag9)
			{
				for (int j = 0; j <= this.mframe[this.f]; j++)
				{
					Point point2 = new Point();
					point2.x = this.x;
					point2.y = this.y - this.mframe[this.f] * 10 + j * 20;
					bool flag10 = this.mframe[this.f] < 2;
					if (flag10)
					{
						point2.fRe = 2;
					}
					else
					{
						bool flag11 = this.mframe[this.f] == 2;
						if (flag11)
						{
							bool flag12 = j == 1;
							if (flag12)
							{
								point2.fRe = 4;
							}
							else
							{
								point2.fRe = 2;
							}
						}
						else
						{
							bool flag13 = this.mframe[this.f] == 3;
							if (flag13)
							{
								bool flag14 = j == 1 || j == 2;
								if (flag14)
								{
									point2.fRe = 4;
								}
								else
								{
									point2.fRe = 2;
								}
							}
							else
							{
								switch (j)
								{
								case 1:
								case 3:
									point2.fRe = 4;
									break;
								case 2:
									point2.fRe = 6;
									break;
								default:
									point2.fRe = 2;
									break;
								}
							}
						}
					}
					this.VecEff.addElement(point2);
				}
			}
			else
			{
				bool flag15 = this.mframe[this.f] == 2;
				if (flag15)
				{
					Point point3 = new Point();
					point3.x = this.x;
					point3.y = this.y;
					point3.frame = 1;
					point3.fRe = 4;
					this.VecEff.addElement(point3);
				}
			}
		}
		bool flag16 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag16)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000246 RID: 582 RVA: 0x0004D7B0 File Offset: 0x0004B9B0
	private void update_Dong_Dat_1()
	{
		bool flag = this.f >= 2 && this.f <= 22;
		if (flag)
		{
			this.addVir(2, 5, 12, true);
		}
		bool flag2 = this.f == 15;
		if (flag2)
		{
			bool flag3 = this.isAddSound;
			if (flag3)
			{
				mSound.playSound(40, mSound.volumeSound);
				mSound.playSound(41, mSound.volumeSound);
			}
			int num = this.objFireMain.x - GameScreen.player.x;
			int num2 = (this.objFireMain.y - GameScreen.player.y) / 2;
			this.x = MotherCanvas.hw + 30 + CRes.random_Am_0(10) + num;
			this.y = MotherCanvas.hh + CRes.random_Am_0(10) + num2;
			this.x1000 = this.x - 90 + CRes.random_Am_0(10);
			this.y1000 = this.y + CRes.random_Am_0(10);
		}
		bool flag4 = this.f == 22;
		if (flag4)
		{
			GameScreen.addEffectEnd(133, 0, this.objFireMain.x, this.objFireMain.y, this.Dir, this.objMainEff);
			bool flag5 = this.typeEffect == 243;
			if (flag5)
			{
				GameScreen.addEffectEnd(113, 2, this.objFireMain.x, this.objFireMain.y, this.Dir, this.objMainEff);
			}
			this.objFireMain.y += 3;
		}
		int subtype = 0;
		bool flag6 = this.f >= 22 && this.f % 2 == 0 && this.f <= 32;
		if (flag6)
		{
			bool flag7 = this.indexObjBefire < this.vecObjsBeFire.size();
			if (flag7)
			{
				for (int i = 0; i < this.vecObjsBeFire.size(); i++)
				{
					Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(this.indexObjBefire);
					bool flag8 = this.typeEffect == 243 && CRes.random(2) == 0;
					if (flag8)
					{
						subtype = 1;
					}
					bool flag9 = object_Effect_Skill != null;
					if (flag9)
					{
						MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
						bool flag10 = mainObject != null;
						if (flag10)
						{
							base.setAva(2, mainObject);
							GameScreen.addEffectEnd(134, subtype, mainObject.x, mainObject.y, this.Dir, this.objMainEff);
						}
					}
					this.indexObjBefire++;
				}
			}
			else
			{
				bool flag11 = this.typeEffect == 243 && CRes.random(2) == 0;
				if (flag11)
				{
					subtype = 1;
				}
				int x = this.objFireMain.x + CRes.random_Am(110, 140);
				int y = this.objFireMain.y + CRes.random_Am(10, 40);
				GameScreen.addEffectEnd(134, subtype, x, y, this.Dir, this.objMainEff);
			}
		}
		bool flag12 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag12)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000247 RID: 583 RVA: 0x000090B5 File Offset: 0x000072B5
	public void endUpdate()
	{
	}

	// Token: 0x06000248 RID: 584 RVA: 0x0004DB08 File Offset: 0x0004BD08
	private void updateNamThach_1()
	{
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point = (Point)this.VecEff.elementAt(i);
			point.f++;
			bool flag = point.f == 1;
			if (flag)
			{
				bool flag2 = point.dis == 0;
				if (flag2)
				{
					int tile = GameCanvas.loadmap.getTile(point.x / 1000, point.y / 1000);
					bool flag3 = tile == 0 || tile == 2;
					if (flag3)
					{
						bool flag4 = point.frame == 0;
						if (flag4)
						{
							GameScreen.addEffectEnd(63, 0, point.x / 1000, point.y / 1000, this.Dir, this.objMainEff);
						}
						bool flag5 = point.frame == 1;
						if (flag5)
						{
							GameScreen.addEffectEnd(63, 3, point.x / 1000, point.y / 1000, this.Dir, this.objMainEff);
						}
					}
					else
					{
						point.isRemove = true;
					}
				}
				bool flag6 = CRes.random(6) == 0;
				if (flag6)
				{
					GameScreen.addEffectEnd(110, point.frame, point.x / 1000, point.y / 1000, this.Dir, this.objMainEff);
				}
			}
			bool flag7 = point.f / 2 >= this.fraImgEff.nFrame || point.isRemove;
			if (flag7)
			{
				this.VecEff.removeElement(point);
				i--;
			}
		}
		bool flag8 = this.f < 7;
		if (flag8)
		{
			int num = 0;
			bool flag9 = this.typeEffect == 239;
			if (flag9)
			{
				num = this.f * 10;
			}
			Point point2 = new Point();
			point2.x = this.x * 1000 + CRes.getcos(35 + num) * (6 - this.f) * this.vMax;
			point2.y = this.y * 1000 + CRes.getsin(35 + num) * (6 - this.f) * (this.vMax - 4);
			point2.dis = this.f % 2;
			point2.fSmall = 0;
			this.VecEff.addElement(point2);
			Point point3 = new Point();
			point3.x = this.x * 1000 + CRes.getcos(145 + num) * (6 - this.f) * this.vMax;
			point3.y = this.y * 1000 + CRes.getsin(145 + num) * (6 - this.f) * (this.vMax - 4);
			point3.dis = this.f % 2;
			point3.fSmall = 1;
			this.VecEff.addElement(point3);
			Point point4 = new Point();
			point4.x = this.x * 1000 + CRes.getcos(215 + num) * (6 - this.f) * this.vMax;
			point4.y = this.y * 1000 + CRes.getsin(215 + num) * (6 - this.f) * (this.vMax - 4);
			point4.dis = this.f % 2;
			point4.fSmall = 2;
			this.VecEff.addElement(point4);
			Point point5 = new Point();
			point5.x = this.x * 1000 + CRes.getcos(CRes.fixangle(325 + num)) * (6 - this.f) * this.vMax;
			point5.y = this.y * 1000 + CRes.getsin(CRes.fixangle(325 + num)) * (6 - this.f) * (this.vMax - 4);
			point5.dis = this.f % 2;
			point5.fSmall = 3;
			this.VecEff.addElement(point5);
			bool flag10 = point2.f % 2 == 1;
			if (flag10)
			{
				int tile2 = GameCanvas.loadmap.getTile(point2.x / 10, point2.y / 10);
				bool flag11 = tile2 == 0 || tile2 == 2;
				if (flag11)
				{
					GameScreen.addEffectEnd(63, 0, point2.x / 10, point2.y / 10, this.Dir, this.objMainEff);
				}
			}
			bool flag12 = this.f % 4 == 2 && this.isAddSound;
			if (flag12)
			{
				mSound.playSound(4, mSound.volumeSound);
			}
		}
		else
		{
			bool flag13 = this.f < 20;
			if (flag13)
			{
				bool flag14 = this.f == 7 && !this.checkNullObject(2);
				if (flag14)
				{
					base.setAva(2, this.objBeFireMain);
					bool flag15 = this.isAddSound;
					if (flag15)
					{
						mSound.playSound(43, mSound.volumeSound);
					}
				}
				GameScreen.addEffectEnd(108, 7, this.x, this.y - CRes.random(240), this.Dir, this.objMainEff);
				bool flag16 = CRes.random(3) == 0;
				if (flag16)
				{
					GameScreen.addEffectEnd(110, 1, this.x, this.y, this.Dir, this.objMainEff);
				}
				this.y1000 += 60;
				bool flag17 = this.y1000 > 480;
				if (flag17)
				{
					this.y1000 = 480;
				}
				bool flag18 = this.f % 2 == 1;
				if (flag18)
				{
					int num2 = 0;
					bool flag19 = this.typeEffect == 239;
					if (flag19)
					{
						num2 = (this.f - 7) / 2 * 5;
					}
					this.disHard++;
					Point point6 = new Point();
					point6.x = this.x * 1000 + CRes.getcos(CRes.fixangle(num2)) * ((this.f - 5) / 2) * this.vMax;
					point6.y = this.y * 1000 + CRes.getsin(CRes.fixangle(num2)) * ((this.f - 5) / 2) * (this.vMax - 4);
					point6.frame = 1;
					point6.dis = this.disHard % 2;
					point6.fSmall = 0;
					this.VecEff.addElement(point6);
					Point point7 = new Point();
					point7.x = this.x * 1000 + CRes.getcos(90 + num2) * ((this.f - 5) / 2) * this.vMax;
					point7.y = this.y * 1000 + CRes.getsin(90 + num2) * ((this.f - 5) / 2) * (this.vMax - 4);
					point7.frame = 1;
					point7.fSmall = 1;
					point7.dis = this.disHard % 2;
					this.VecEff.addElement(point7);
					Point point8 = new Point();
					point8.x = this.x * 1000 + CRes.getcos(180 + num2) * ((this.f - 5) / 2) * this.vMax;
					point8.y = this.y * 1000 + CRes.getsin(180 + num2) * ((this.f - 5) / 2) * (this.vMax - 4);
					point8.frame = 1;
					point8.dis = this.disHard % 2;
					point8.fSmall = 2;
					this.VecEff.addElement(point8);
					Point point9 = new Point();
					point9.x = this.x * 1000 + CRes.getcos(CRes.fixangle(270 + num2)) * ((this.f - 5) / 2) * this.vMax;
					point9.y = this.y * 1000 + CRes.getsin(CRes.fixangle(270 + num2)) * ((this.f - 5) / 2) * (this.vMax - 4);
					point9.frame = 1;
					point9.fSmall = 3;
					point9.dis = this.disHard % 2;
					this.VecEff.addElement(point9);
				}
			}
		}
		bool flag20 = this.f == this.fRemove - 5;
		if (flag20)
		{
			base.setAva(2, this.objBeFireMain);
			GameScreen.addEffectEnd(112, 1, this.x, this.y, this.Dir, this.objMainEff);
		}
		bool flag21 = this.f >= this.fRemove;
		if (flag21)
		{
			this.removeEff();
		}
		else
		{
			bool flag22 = this.f % 4 == 0;
			if (flag22)
			{
				LoadMap.timeVibrateScreen = 105;
				GameScreen.addEffectEnd(59, 0, this.x + CRes.random_Am_0(15), this.y + 5 + CRes.random_Am_0(5), this.Dir, this.objMainEff);
			}
		}
	}

	// Token: 0x06000249 RID: 585 RVA: 0x0004E430 File Offset: 0x0004C630
	private void updateWapol_1()
	{
		bool flag = this.f < this.fRemove;
		if (flag)
		{
			bool flag2 = !this.checkNullObject(1);
			if (flag2)
			{
				this.objFireMain.x = this.x;
				this.objFireMain.y = this.y;
				this.objFireMain.dy = 4;
			}
			bool flag3 = this.f % 2 == 1;
			if (flag3)
			{
				Point point = new Point(this.x, this.y);
				point.frame = 0;
				this.VecEff.addElement(point);
			}
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point2 = (Point)this.VecEff.elementAt(i);
			point2.f++;
			bool flag4 = point2.f >= 4;
			if (flag4)
			{
				this.VecEff.removeElement(point2);
				i--;
			}
		}
		bool flag5 = this.f == this.fRemove;
		if (flag5)
		{
			this.objFireMain.plashNow.setIsNextf(0);
			this.vx = 0;
			this.vy = 0;
			bool flag6 = !this.checkNullObject(1);
			if (flag6)
			{
				this.objFireMain.dy = 0;
			}
			Point point3 = new Point(this.toX, this.toY - 24);
			point3.frame = 1;
			this.VecEff.addElement(point3);
		}
		bool flag7 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag7)
		{
			this.removeEff();
		}
	}

	// Token: 0x0600024A RID: 586 RVA: 0x0004E5E4 File Offset: 0x0004C7E4
	private void updateWapol_3()
	{
		bool flag = this.f == 4;
		if (flag)
		{
			GameScreen.addEffectEnd(30, 0, this.x, this.y, 200, this.Dir, this.objMainEff);
		}
		bool flag2 = this.f >= 9 && this.f <= this.fRemove && this.f % 3 == 0;
		if (flag2)
		{
			bool flag3 = this.indexObjBefire < this.vecObjsBeFire.size();
			if (flag3)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(this.indexObjBefire);
				this.indexObjBefire++;
				bool flag4 = object_Effect_Skill != null;
				if (flag4)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					bool flag5 = mainObject != null;
					if (flag5)
					{
						Point_Focus point_Focus = new Point_Focus();
						int xdich = mainObject.x - this.x;
						int ydich = mainObject.y - mainObject.hOne / 2 - this.y;
						point_Focus = base.create_Speed(xdich, ydich, point_Focus);
						this.VecEff.addElement(point_Focus);
					}
				}
			}
			else
			{
				Point_Focus point_Focus2 = new Point_Focus();
				int num = 120 + CRes.random_Am_0(30);
				int ydich2 = CRes.random_Am_0(50);
				bool flag6 = this.Dir == 0;
				if (flag6)
				{
					num = -num;
				}
				point_Focus2 = base.create_Speed(num, ydich2, point_Focus2);
				this.VecEff.addElement(point_Focus2);
			}
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus3 = (Point_Focus)this.VecEff.elementAt(i);
			point_Focus3.update_Vx_Vy();
			bool flag7 = point_Focus3.f >= point_Focus3.fRe;
			if (flag7)
			{
				GameScreen.addEffectEnd(57, 0, point_Focus3.x, point_Focus3.y, this.Dir, this.objMainEff);
				this.VecEff.removeElement(point_Focus3);
				i--;
			}
		}
		bool flag8 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag8)
		{
			this.removeEff();
		}
	}

	// Token: 0x0600024B RID: 587 RVA: 0x0004E824 File Offset: 0x0004CA24
	private void updateMr3_1()
	{
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(i);
			point_Focus.update_Vx_Vy();
			bool flag = point_Focus.f >= point_Focus.fRe;
			if (flag)
			{
				GameScreen.addEffectEnd(103, 0, point_Focus.toX, point_Focus.toY, this.Dir, this.objMainEff);
				bool flag2 = point_Focus.objMain != null;
				if (flag2)
				{
					base.setAva(2, point_Focus.objMain);
					GameScreen.addEffectEnd(8, 0, point_Focus.objMain.x, point_Focus.objMain.y - point_Focus.objMain.hOne / 2, this.Dir, point_Focus.objMain);
				}
				this.VecEff.removeElement(point_Focus);
				i--;
			}
		}
		bool flag3 = this.f == 9 && !this.checkNullObject(2);
		if (flag3)
		{
			bool flag4 = this.vecObjsBeFire.size() > 1;
			if (flag4)
			{
				this.fRemove = 25;
				for (int j = 0; j < this.vecObjsBeFire.size(); j++)
				{
					Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(j);
					bool flag5 = object_Effect_Skill != null;
					if (flag5)
					{
						MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
						bool flag6 = mainObject != null;
						if (flag6)
						{
							Point_Focus point_Focus2 = new Point_Focus();
							int xdich = mainObject.x - this.x;
							int ydich = mainObject.y - this.y;
							point_Focus2 = base.create_Speed(xdich, ydich, point_Focus2, this.x, this.y, mainObject.x, mainObject.y);
							point_Focus2.dis = (int)this.Dir;
							point_Focus2.objMain = mainObject;
							this.VecEff.addElement(point_Focus2);
						}
					}
				}
			}
			else
			{
				bool flag7 = this.Dir == 0;
				if (flag7)
				{
					this.toX = this.objBeFireMain.x + 10;
				}
				else
				{
					this.toX = this.objBeFireMain.x - 10;
				}
				this.toY = this.objBeFireMain.y + 5;
				int xdich2 = this.toX - this.x;
				int ydich2 = this.toY - this.y;
				Point_Focus point_Focus3 = new Point_Focus();
				point_Focus3 = base.create_Speed(xdich2, ydich2, point_Focus3);
				point_Focus3.dis = (int)this.Dir;
				point_Focus3.objMain = this.objBeFireMain;
				this.VecEff.addElement(point_Focus3);
				this.fRemove = 15 + point_Focus3.fRe;
			}
		}
		bool flag8 = this.f >= this.fRemove;
		if (flag8)
		{
			this.removeEff();
		}
	}

	// Token: 0x0600024C RID: 588 RVA: 0x0004EB18 File Offset: 0x0004CD18
	private void updateMr3_2()
	{
		bool flag = this.f == 1 || this.f == 10;
		if (flag)
		{
			for (int i = 0; i < this.vecObjsBeFire.size(); i++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(i);
				bool flag2 = object_Effect_Skill == null;
				if (!flag2)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					bool flag3 = mainObject != null;
					if (flag3)
					{
						Point_Focus point_Focus = new Point_Focus();
						point_Focus.objMain = mainObject;
						int xdich = mainObject.x - this.x;
						int ydich = mainObject.y - mainObject.hOne / 2 - this.y;
						point_Focus = base.create_Speed(xdich, ydich, point_Focus);
						bool flag4 = this.f == 1;
						if (flag4)
						{
							point_Focus.frame = 0;
						}
						bool flag5 = this.f == 10;
						if (flag5)
						{
							point_Focus.frame = 1;
						}
						this.VecEff.addElement(point_Focus);
					}
				}
			}
		}
		bool flag6 = this.f == 6 && !this.checkNullObject(1);
		if (flag6)
		{
			this.objFireMain.addChat(T.haha, true);
		}
		for (int j = 0; j < this.VecEff.size(); j++)
		{
			Point_Focus point_Focus2 = (Point_Focus)this.VecEff.elementAt(j);
			point_Focus2.update_Vx_Vy();
			bool flag7 = point_Focus2.f >= point_Focus2.fRe;
			if (flag7)
			{
				bool flag8 = point_Focus2.frame == 0;
				if (flag8)
				{
					Point point = new Point();
					point.frame = point_Focus2.frame;
					point.fRe = point_Focus2.fRe * 2 + 10;
					point.obj = point_Focus2.objMain;
					this.VecSubEff.addElement(point);
				}
				else
				{
					Point point2 = new Point();
					point2.frame = point_Focus2.frame;
					point2.fRe = CRes.random(12, 20);
					point2.obj = point_Focus2.objMain;
					this.VecSubEff.addElement(point2);
				}
				this.VecEff.removeElement(point_Focus2);
				j--;
			}
		}
		for (int k = 0; k < this.VecSubEff.size(); k++)
		{
			Point point3 = (Point)this.VecSubEff.elementAt(k);
			point3.update();
			bool flag9 = point3.f >= point3.fRe;
			if (flag9)
			{
				this.VecSubEff.removeElement(point3);
				k--;
			}
		}
		bool flag10 = this.f >= this.fRemove && this.VecEff.size() == 0 && this.VecSubEff.size() == 0;
		if (flag10)
		{
			this.removeEff();
		}
	}

	// Token: 0x0600024D RID: 589 RVA: 0x0004EE1C File Offset: 0x0004D01C
	private void updateMissMS_1()
	{
		bool flag = this.f >= 30;
		if (flag)
		{
			bool flag2 = !this.checkNullObject(1) && this.f == 30;
			if (flag2)
			{
				this.objFireMain.isTanHinh = false;
				this.objFireMain.isPaintLeg = false;
				this.objFireMain.dy = -20;
			}
			bool flag3 = !this.checkNullObject(1) && this.f == 31;
			if (flag3)
			{
				this.objFireMain.isTanHinh = false;
				this.objFireMain.isPaintLeg = false;
				this.objFireMain.dy = -10;
			}
			bool flag4 = !this.checkNullObject(1) && this.f == 32;
			if (flag4)
			{
				this.objFireMain.isTanHinh = false;
				this.objFireMain.isPaintLeg = true;
				this.objFireMain.dy = 10;
			}
			bool flag5 = !this.checkNullObject(1) && this.f == 33;
			if (flag5)
			{
				this.objFireMain.isTanHinh = false;
				this.objFireMain.isPaintLeg = true;
				this.objFireMain.dy = 20;
			}
		}
		else
		{
			bool flag6 = this.f >= 2 && this.f < 30 && !this.checkNullObject(1);
			if (flag6)
			{
				this.objFireMain.isTanHinh = true;
			}
		}
		bool flag7 = this.f >= 8 && this.f % 5 == 0 && this.indexObjBefire < this.vecObjsBeFire.size();
		if (flag7)
		{
			this.addSound(15);
			Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(this.indexObjBefire);
			this.indexObjBefire++;
			bool flag8 = object_Effect_Skill != null;
			if (flag8)
			{
				MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
				bool flag9 = mainObject != null;
				if (flag9)
				{
					Point point = new Point();
					point.x = mainObject.x;
					point.y = mainObject.y;
					point.fRe = 12;
					this.VecEff.addElement(point);
					Point point2 = new Point();
					point2.x = mainObject.x;
					point2.y = mainObject.y + 10;
					point2.fRe = 20;
					this.VecSubEff.addElement(point2);
					base.setAva(2, mainObject);
				}
			}
			this.addVir(3, 5, 10, false);
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point3 = (Point)this.VecEff.elementAt(i);
			point3.update();
			bool flag10 = point3.f >= point3.fRe;
			if (flag10)
			{
				this.VecEff.removeElement(point3);
				i--;
			}
		}
		for (int j = 0; j < this.VecSubEff.size(); j++)
		{
			Point point4 = (Point)this.VecSubEff.elementAt(j);
			point4.update();
			bool flag11 = point4.f < 3;
			if (flag11)
			{
				point4.frame = point4.f;
			}
			bool flag12 = point4.f > point4.fRe - 3;
			if (flag12)
			{
				point4.frame = point4.fRe - point4.f;
			}
			bool flag13 = point4.f >= point4.fRe;
			if (flag13)
			{
				this.VecSubEff.removeElement(point4);
				j--;
			}
		}
		bool flag14 = this.f >= this.fRemove;
		if (flag14)
		{
			bool flag15 = !this.checkNullObject(1);
			if (flag15)
			{
				this.objFireMain.isTanHinh = false;
			}
			this.removeEff();
		}
	}

	// Token: 0x0600024E RID: 590 RVA: 0x0004F210 File Offset: 0x0004D410
	private void updateHoDen()
	{
		bool flag = GameCanvas.gameTick % 20 == 0;
		if (flag)
		{
			for (int i = 0; i < this.vecObjsBeFire.size(); i++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(i);
				bool flag2 = object_Effect_Skill != null;
				if (flag2)
				{
					GameScreen.addEffectSkill2(-1, this.objFireMain, object_Effect_Skill, this.x + (int)this.posSmock[CRes.random(this.posSmock.Length - 1)], this.y - 200 + CRes.random_Am(-10, 10));
					GameScreen.addEffectSkill2(-1, this.objFireMain, object_Effect_Skill, this.x + (int)this.posSmock[CRes.random(this.posSmock.Length - 1)], this.y - 200 + CRes.random_Am(-10, 10));
				}
			}
		}
		bool flag3 = this.f == 16 && this.tickadd <= 1;
		if (flag3)
		{
			this.tickadd++;
			GameScreen.addEffectEnd(164, 0, this.x, this.y, this.Dir, this.objMainEff);
		}
		bool flag4 = this.f == 10 || this.f == 16;
		if (flag4)
		{
			for (int j = 0; j < 4; j++)
			{
				Point point = new Point();
				switch (j)
				{
				case 0:
					point.x = (this.x - 80) * 10;
					point.y = this.y * 10;
					point.vx = CRes.random(30, 50);
					point.vy = CRes.random(30, 50);
					break;
				case 1:
					point.x = this.x * 10;
					point.y = (this.y - 40) * 10;
					point.vx = -CRes.random(40, 60);
					point.vy = CRes.random(20, 40);
					break;
				case 2:
					point.x = this.x * 10;
					point.y = (this.y + 40) * 10;
					point.vx = CRes.random(40, 60);
					point.vy = -CRes.random(25, 45);
					break;
				case 3:
					point.x = (this.x + 80) * 10;
					point.y = this.y * 10;
					point.vx = -CRes.random(30, 50);
					point.vy = -CRes.random(30, 50);
					break;
				}
				bool flag5 = (j % 2 == 1 && this.f == 10) || (j % 2 == 0 && this.f == 16);
				if (flag5)
				{
					point.frame = 1;
				}
				point.fRe = 22;
				this.VecSubEff.addElement(point);
			}
		}
		bool flag6 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag6)
		{
			this.removeEff();
		}
		for (int k = 0; k < this.VecEff.size(); k++)
		{
			Point point2 = (Point)this.VecEff.elementAt(k);
			point2.f++;
			bool flag7 = point2.f >= 6;
			if (flag7)
			{
				this.VecEff.removeElement(point2);
				k--;
			}
		}
		bool flag8 = this.f <= 16;
		if (!flag8)
		{
			bool flag9 = this.y1000 > 0;
			if (flag9)
			{
				this.y1000 -= 120;
				bool flag10 = this.y1000 < 0;
				if (flag10)
				{
					this.y1000 = 0;
				}
			}
			bool flag11 = this.y1000 == 0 && this.f < this.fRemove;
			if (flag11)
			{
				bool flag12 = CRes.random(2) == 0;
				if (flag12)
				{
					Point o = new Point(this.x + CRes.random_Am_0(20), this.y + 5 + CRes.random_Am_0(10));
					this.VecEff.addElement(o);
				}
				bool flag13 = this.f % 4 == 0;
				if (flag13)
				{
					LoadMap.timeVibrateScreen = 105;
				}
			}
		}
	}

	// Token: 0x0600024F RID: 591 RVA: 0x0004F690 File Offset: 0x0004D890
	private void updateSet_1()
	{
		bool flag = this.f == 10 || (this.f == 16 && this.typeEffect == 237);
		if (flag)
		{
			for (int i = 0; i < 4; i++)
			{
				Point point = new Point();
				switch (i)
				{
				case 0:
					point.x = (this.x - 80) * 10;
					point.y = this.y * 10;
					point.vx = CRes.random(30, 50);
					point.vy = CRes.random(30, 50);
					break;
				case 1:
					point.x = this.x * 10;
					point.y = (this.y - 40) * 10;
					point.vx = -CRes.random(40, 60);
					point.vy = CRes.random(20, 40);
					break;
				case 2:
					point.x = this.x * 10;
					point.y = (this.y + 40) * 10;
					point.vx = CRes.random(40, 60);
					point.vy = -CRes.random(25, 45);
					break;
				case 3:
					point.x = (this.x + 80) * 10;
					point.y = this.y * 10;
					point.vx = -CRes.random(30, 50);
					point.vy = -CRes.random(30, 50);
					break;
				}
				bool flag2 = this.typeEffect == 237 && ((i % 2 == 1 && this.f == 10) || (i % 2 == 0 && this.f == 16));
				if (flag2)
				{
					point.frame = 1;
				}
				point.fRe = 22;
				this.VecSubEff.addElement(point);
			}
			bool flag3 = this.isAddSound;
			if (flag3)
			{
				mSound.playSound(38, mSound.volumeSound);
			}
		}
		bool flag4 = this.f == this.fRemove - 5;
		if (flag4)
		{
			base.setAva(2, this.objBeFireMain);
			GameScreen.addEffectEnd(112, 0, this.x, this.y + 10, this.Dir, this.objMainEff);
		}
		bool flag5 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag5)
		{
			this.removeEff();
		}
		for (int j = 0; j < this.VecEff.size(); j++)
		{
			Point point2 = (Point)this.VecEff.elementAt(j);
			point2.f++;
			bool flag6 = point2.f >= this.fraImgSub2Eff.nFrame * 2;
			if (flag6)
			{
				this.VecEff.removeElement(point2);
				j--;
			}
		}
		for (int k = 0; k < this.VecSubEff.size(); k++)
		{
			Point point3 = (Point)this.VecSubEff.elementAt(k);
			point3.update();
			bool flag7 = point3.f % 5 == 0;
			if (flag7)
			{
				int tile = GameCanvas.loadmap.getTile(point3.x / 10, point3.y / 10);
				bool flag8 = tile == 0 || tile == 2;
				if (flag8)
				{
					GameScreen.addEffectEnd(63, 0, point3.x / 10, point3.y / 10, this.Dir, this.objMainEff);
				}
			}
			bool flag9 = point3.f >= point3.fRe;
			if (flag9)
			{
				this.VecSubEff.removeElement(point3);
				k--;
			}
		}
		bool flag10 = this.f == 16 && this.isAddSound;
		if (flag10)
		{
			mSound.playSound(37, mSound.volumeSound);
		}
		bool flag11 = this.f <= 16;
		if (!flag11)
		{
			bool flag12 = this.y1000 > 0;
			if (flag12)
			{
				this.y1000 -= 120;
				bool flag13 = this.y1000 < 0;
				if (flag13)
				{
					this.y1000 = 0;
				}
			}
			bool flag14 = this.y1000 == 0 && this.f < this.fRemove;
			if (flag14)
			{
				GameScreen.addEffectEnd(108, 6, this.x, this.y - CRes.random(240), this.Dir, this.objMainEff);
				bool flag15 = CRes.random(2) == 0;
				if (flag15)
				{
					Point o = new Point(this.x + CRes.random_Am_0(20), this.y + 5 + CRes.random_Am_0(10));
					this.VecEff.addElement(o);
				}
				bool flag16 = this.f % 4 == 0;
				if (flag16)
				{
					LoadMap.timeVibrateScreen = 105;
					GameScreen.addEffectEnd(110, 0, this.x + CRes.random_Am_0(15), this.y + 5 + CRes.random_Am_0(5), this.Dir, this.objMainEff);
				}
			}
		}
	}

	// Token: 0x06000250 RID: 592 RVA: 0x0004FBC0 File Offset: 0x0004DDC0
	private void updateSet_2()
	{
		bool flag = this.f >= 10 && this.f <= 20;
		if (flag)
		{
			bool flag2 = this.isAddSound && this.f % 3 == 0;
			if (flag2)
			{
				mSound.playSound(17, mSound.volumeSound);
			}
			bool flag3 = this.indexObjBefire < this.vecObjsBeFire.size();
			if (flag3)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(this.indexObjBefire);
				this.indexObjBefire++;
				bool flag4 = object_Effect_Skill != null;
				if (flag4)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					bool flag5 = mainObject != null;
					if (flag5)
					{
						int num = 1 + CRes.random(2);
						for (int i = 0; i < num; i++)
						{
							Point_Focus point_Focus = new Point_Focus();
							point_Focus.x = mainObject.x + 300;
							bool flag6 = this.Dir == 2;
							if (flag6)
							{
								point_Focus.x = mainObject.x - 300;
							}
							point_Focus.y = mainObject.y - 400;
							point_Focus.toX = mainObject.x + CRes.random_Am_0(20);
							point_Focus.toY = mainObject.y + CRes.random_Am_0(10);
							point_Focus = base.create_Speed(point_Focus.toX - point_Focus.x, point_Focus.toY - point_Focus.y, point_Focus, point_Focus.x, point_Focus.y, point_Focus.toX, point_Focus.toY);
							point_Focus.dis = CRes.random(16, 30);
							point_Focus.maxdis = CRes.random(10, 25);
							point_Focus.frame = CRes.random(this.fraImgEff.nFrame);
							bool flag7 = i == 0;
							if (flag7)
							{
								point_Focus.goc = 1;
							}
							bool flag8 = this.typeEffect == 238 && CRes.random(2) == 0;
							if (flag8)
							{
								point_Focus.typeSpec = 1;
							}
							this.VecEff.addElement(point_Focus);
						}
					}
				}
			}
			else
			{
				bool flag9 = !this.checkNullObject(2);
				if (flag9)
				{
					int num2 = 1 + CRes.random(4) / 3;
					for (int j = 0; j < num2; j++)
					{
						Point_Focus point_Focus2 = new Point_Focus();
						point_Focus2.x = this.objBeFireMain.x + 300;
						bool flag10 = this.Dir == 2;
						if (flag10)
						{
							point_Focus2.x = this.objBeFireMain.x - 300;
						}
						point_Focus2.y = this.objBeFireMain.y - 400;
						point_Focus2.toX = this.objBeFireMain.x + CRes.random_Am_0(160);
						point_Focus2.toY = this.objBeFireMain.y + CRes.random_Am_0(80);
						point_Focus2 = base.create_Speed(point_Focus2.toX - point_Focus2.x, point_Focus2.toY - point_Focus2.y, point_Focus2, point_Focus2.x, point_Focus2.y, point_Focus2.toX, point_Focus2.toY);
						point_Focus2.dis = CRes.random(16, 30);
						point_Focus2.maxdis = CRes.random(10, 25);
						point_Focus2.frame = CRes.random(this.fraImgEff.nFrame);
						bool flag11 = this.typeEffect == 238 && CRes.random(2) == 0;
						if (flag11)
						{
							point_Focus2.typeSpec = 1;
						}
						this.VecEff.addElement(point_Focus2);
					}
				}
			}
		}
		for (int k = 0; k < this.VecEff.size(); k++)
		{
			Point_Focus point_Focus3 = (Point_Focus)this.VecEff.elementAt(k);
			point_Focus3.update_Vx_Vy();
			bool flag12 = point_Focus3.f == point_Focus3.fRe;
			if (flag12)
			{
				point_Focus3.vx = 0;
				point_Focus3.vy = 0;
				point_Focus3.x = point_Focus3.toX;
				point_Focus3.y = point_Focus3.toY;
				bool flag13 = CRes.random(3) == 0 || point_Focus3.goc == 1;
				if (flag13)
				{
					Point point = new Point();
					point.x = point_Focus3.x * 10;
					point.y = point_Focus3.y * 10;
					point.vx = CRes.random_Am_0(30);
					point.vy = CRes.random_Am_0(30);
					point.fRe = 14 + CRes.random(6);
					point.frame = point_Focus3.typeSpec;
					this.VecSubEff.addElement(point);
					GameScreen.addEffectEnd(59, 0, point_Focus3.x, point_Focus3.y, this.Dir, this.objMainEff);
				}
				int tile = GameCanvas.loadmap.getTile(point_Focus3.x, point_Focus3.y);
				bool flag14 = tile == -1;
				if (flag14)
				{
					point_Focus3.isSpeedUp = true;
				}
				else
				{
					GameScreen.addEffectEnd(63, 0, point_Focus3.x, point_Focus3.y, this.Dir, this.objMainEff);
				}
			}
			bool flag15 = point_Focus3.f % 2 == 0;
			if (flag15)
			{
				point_Focus3.frame++;
				bool flag16 = point_Focus3.frame >= this.fraImgEff.maxNumFrame;
				if (flag16)
				{
					point_Focus3.frame = 0;
				}
			}
			bool flag17 = point_Focus3.f >= point_Focus3.fRe + point_Focus3.dis || point_Focus3.isSpeedUp;
			if (flag17)
			{
				this.VecEff.removeElement(point_Focus3);
				k--;
			}
		}
		for (int l = 0; l < this.VecSubEff.size(); l++)
		{
			Point point2 = (Point)this.VecSubEff.elementAt(l);
			point2.update();
			bool flag18 = point2.f % 8 == 0;
			if (flag18)
			{
				int tile2 = GameCanvas.loadmap.getTile(point2.x / 10, point2.y / 10);
				bool flag19 = tile2 == 0 || tile2 == 2;
				if (flag19)
				{
					GameScreen.addEffectEnd(63, 0, point2.x / 10, point2.y / 10, this.Dir, this.objMainEff);
				}
			}
			bool flag20 = point2.f >= point2.fRe;
			if (flag20)
			{
				this.VecSubEff.removeElement(point2);
				l--;
			}
		}
		bool flag21 = this.f >= this.fRemove && this.VecEff.size() == 0 && this.VecSubEff.size() == 0;
		if (flag21)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000251 RID: 593 RVA: 0x000502C8 File Offset: 0x0004E4C8
	private void updateZoroS2_L1_NEW()
	{
		bool flag = this.f == 1;
		if (flag)
		{
			bool flag2 = this.isAddSound;
			if (flag2)
			{
				mSound.playSound(7, mSound.volumeSound);
			}
			GameScreen.addEffectEnd(16, 0, this.objFireMain.x, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 2, this.Dir, this.objMainEff);
		}
		bool flag3 = this.f == 2;
		if (flag3)
		{
			GameScreen.addEffectEnd(26, 1, this.objBeFireMain.x, this.objBeFireMain.y, 0, this.objMainEff);
		}
		bool flag4 = this.f == 4;
		if (flag4)
		{
			bool flag5 = this.isAddSound;
			if (flag5)
			{
				mSound.playSound(7, mSound.volumeSound);
			}
			int num = 10;
			bool flag6 = this.Dir == 0;
			if (flag6)
			{
				num = -10;
			}
			GameScreen.addEffectEnd(16, 1, this.objFireMain.x + num, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 2, this.Dir, this.objMainEff);
		}
		bool flag7 = this.f == 5;
		if (flag7)
		{
			GameScreen.addEffectEnd(26, 1, this.objBeFireMain.x, this.objBeFireMain.y, 2, this.objMainEff);
		}
		bool flag8 = this.f >= this.fRemove;
		if (flag8)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000252 RID: 594 RVA: 0x000098EE File Offset: 0x00007AEE
	public override void stopUpdateNormal()
	{
		this.removeEff();
	}

	// Token: 0x06000253 RID: 595 RVA: 0x00050458 File Offset: 0x0004E658
	public override void removeEff()
	{
		bool flag = this.objFireMain == GameScreen.player && GameScreen.typePaintGameScreen == 1;
		if (flag)
		{
			GameScreen.isPaintNormal();
		}
		bool flag2 = !this.isEff;
		if (flag2)
		{
			this.AddNumAndEffPlus(this.vecObjsBeFire);
		}
		this.VecEff.removeAllElements();
		this.VecSubEff.removeAllElements();
		this.isStop = true;
		this.f = -1;
	}

	// Token: 0x06000254 RID: 596 RVA: 0x000504CC File Offset: 0x0004E6CC
	private void AddNumAndEffPlus(mVector vec)
	{
		bool flag = vec == null || vec.size() == 0;
		if (!flag)
		{
			for (int i = 0; i < vec.size(); i++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)vec.elementAt(i);
				MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
				bool flag2 = mainObject == null || mainObject.returnAction();
				if (!flag2)
				{
					bool flag3 = Effect_Skill.setAddEffPlus(object_Effect_Skill, mainObject, this.objFireMain, this.objMainEff);
					bool flag4 = mainObject.Hp <= 0 && mainObject.Action != 4;
					if (flag4)
					{
						mainObject.beginDie(this.objFireMain);
					}
					sbyte typeColor = 15;
					bool flag5 = !this.checkNullObject(1) && this.objFireMain == GameScreen.player;
					if (flag5)
					{
						typeColor = 13;
					}
					int num = object_Effect_Skill.hpShow;
					bool flag6 = this.objFireMain.typeObject == 1;
					if (flag6)
					{
						typeColor = 14;
						num = -num;
					}
					bool flag7 = this.objFireMain != GameScreen.player && mainObject != GameScreen.player && GameCanvas.lowGraphic;
					if (!flag7)
					{
						bool flag8 = object_Effect_Skill.hpShow == 0;
						if (flag8)
						{
							GameScreen.addEffectNumBig_NEW_AP(num, object_Effect_Skill.hpMagic, mainObject.x, mainObject.y - mainObject.hOne, 17);
						}
						else
						{
							bool flag9 = flag3;
							if (flag9)
							{
								typeColor = 16;
							}
							GameScreen.addEffectNumBig_NEW_AP(num, object_Effect_Skill.hpMagic, mainObject.x, mainObject.y - mainObject.hOne, typeColor);
						}
						int num2 = Effect_Skill.HasHapThuEffPlus(object_Effect_Skill, mainObject, this.objFireMain, this.objMainEff);
						bool flag10 = num2 >= 0 && object_Effect_Skill.mEff_HP_Plus[num2] > 0;
						if (flag10)
						{
							GameScreen.addEffectNumBig_NEW_AP(object_Effect_Skill.mEff_HP_Plus[num2], object_Effect_Skill.hpMagic, mainObject.x, mainObject.y - mainObject.hOne, 25);
						}
					}
				}
			}
			bool flag11 = this.objFireMain != GameScreen.player && this.objFireMain.Hp <= 0 && this.objFireMain.Action != 4;
			if (flag11)
			{
				this.objFireMain.beginDie(this.objFireMain);
			}
		}
	}

	// Token: 0x06000255 RID: 597 RVA: 0x000090B5 File Offset: 0x000072B5
	private void beginCreate()
	{
	}

	// Token: 0x06000256 RID: 598 RVA: 0x00050714 File Offset: 0x0004E914
	public void createNormal()
	{
		this.fRemove = 60;
		bool flag = this.subType == 0;
		if (flag)
		{
			this.fraImgEff = new FrameImage(0, 14, 14);
		}
		this.vMax = 8000;
		this.numNextFrame = 2;
		base.setInfoNormal(this.objFireMain);
	}

	// Token: 0x06000257 RID: 599 RVA: 0x00050768 File Offset: 0x0004E968
	public void createPhaohoa()
	{
		this.y -= 6;
		bool flag = this.Dir == 0;
		if (flag)
		{
			this.x -= 30;
		}
		else
		{
			this.x += 30;
		}
		this.fRemove = 20;
		this.vMax = 10;
		this.numNextFrame = 2;
		this.fraImgEff = new FrameImage(111, 40, 30, 40, 30);
		GameScreen.addEffectEnd(30, 0, this.x, this.objFireMain.y - this.objFireMain.hOne / 2 - 3, 300, this.Dir, this.objMainEff);
		bool flag2 = this.isAddSound;
		if (flag2)
		{
			mSound.playSound(24, mSound.volumeSound);
		}
	}

	// Token: 0x06000258 RID: 600 RVA: 0x00050838 File Offset: 0x0004EA38
	public void createPhaohoa_L6()
	{
		this.y -= 6;
		this.x += 30 * this.am_duong;
		this.fRemove = 20;
		this.vMax = 10;
		this.numNextFrame = 2;
		this.fraImgEff = new FrameImage(418, 6);
		GameScreen.addEffectEnd(53, 0, this.x, this.objFireMain.y - this.objFireMain.hOne / 2 - 3, 300, this.Dir, this.objMainEff);
		GameScreen.addEffectEnd(30, 0, this.x, this.objFireMain.y - this.objFireMain.hOne / 2 - 3, 300, this.Dir, this.objMainEff);
		bool flag = this.isAddSound;
		if (flag)
		{
			mSound.playSound(24, mSound.volumeSound);
		}
	}

	// Token: 0x06000259 RID: 601 RVA: 0x00050924 File Offset: 0x0004EB24
	public void createLuffy1()
	{
		this.fRemove = this.vecObjsBeFire.size() * 3 + 6;
		bool flag = this.fRemove < 12;
		if (flag)
		{
			this.fRemove = 12;
		}
		this.fraImgEff = new FrameImage(1, 80, 40);
		bool flag2 = this.typeEffect == 37;
		if (flag2)
		{
			this.fraImgSubEff = new FrameImage(27, 24, 32);
		}
		bool flag3 = this.Dir == 0;
		if (flag3)
		{
			this.x -= 20;
		}
		else
		{
			this.x += 20;
		}
		bool flag4 = this.isAddSound;
		if (flag4)
		{
			mSound.playSound(4, mSound.volumeSound);
		}
	}

	// Token: 0x0600025A RID: 602 RVA: 0x000098F8 File Offset: 0x00007AF8
	public void createSanji1()
	{
		this.y = this.objFireMain.y;
		this.fRemove = 12;
	}

	// Token: 0x0600025B RID: 603 RVA: 0x000509DC File Offset: 0x0004EBDC
	public void createZoro1()
	{
		this.fraImgEff = new FrameImage(10, 40, 47);
		int a = this.objFireMain.x - this.objBeFireMain.x;
		bool flag = CRes.abs(a) > 50;
		if (flag)
		{
			this.fRemove = 5;
			this.vx = (CRes.abs(a) - 24) / 5;
		}
		else
		{
			bool flag2 = CRes.abs(a) > 24;
			if (flag2)
			{
				this.vx = 5;
				this.fRemove = (CRes.abs(a) - 24) / 5;
			}
			else
			{
				this.fRemove = 1;
				this.vx = 0;
			}
		}
		bool flag3 = this.Dir == 0;
		if (flag3)
		{
			this.xplus = 20;
			this.vx = -this.vx;
		}
		else
		{
			this.xplus = -20;
		}
	}

	// Token: 0x0600025C RID: 604 RVA: 0x00050AA8 File Offset: 0x0004ECA8
	public void createZoro2()
	{
		this.fraImgEff = new FrameImage(10, 40, 47);
		this.fraImgSubEff = new FrameImage(11, 40, 50);
		this.fRemove = 7;
		this.yplus = this.objBeFireMain.hOne / 2;
		bool flag = this.objFireMain != null;
		if (flag)
		{
			this.objFireMain.isTanHinh = true;
			bool flag2 = this.objFireMain.plashNow != null;
			if (flag2)
			{
				this.objFireMain.plashNow.setIsNextf(1);
			}
		}
		bool flag3 = this.Dir == 0;
		if (flag3)
		{
			this.toX += 30;
		}
		else
		{
			this.toX -= 30;
		}
	}

	// Token: 0x0600025D RID: 605 RVA: 0x00050B64 File Offset: 0x0004ED64
	public void createUssopSea1()
	{
		this.fraImgEff = new FrameImage(12, 15, 15);
		this.vMax = 24;
		this.fRemove = 15;
		this.y -= 6;
		bool flag = this.Dir == 0;
		if (flag)
		{
			this.x -= 20;
		}
		else
		{
			this.x += 20;
		}
		GameScreen.addEffectEnd(30, 0, this.x, this.objFireMain.y - this.objFireMain.hOne / 2, 300, this.Dir, this.objMainEff);
	}

	// Token: 0x0600025E RID: 606 RVA: 0x00050C0C File Offset: 0x0004EE0C
	public void createUssopSea2()
	{
		this.fraImgEff = new FrameImage(196, 15, 15);
		this.vMax = 24;
		this.fRemove = 20;
		this.y -= 6;
		bool flag = this.Dir == 0;
		if (flag)
		{
			this.x -= 20;
		}
		else
		{
			this.x += 20;
		}
	}

	// Token: 0x0600025F RID: 607 RVA: 0x00050C80 File Offset: 0x0004EE80
	public void createUssopSea3()
	{
		this.fraImgEff = new FrameImage(197, 15, 10);
		this.Dir = (sbyte)this.objFireMain.type_left_right;
		this.vMax = 12;
		this.fRemove = 20;
		this.y -= 6;
		bool flag = this.Dir == 0;
		if (flag)
		{
			this.x -= 20;
		}
		else
		{
			this.x += 20;
		}
		GameScreen.addEffectEnd(30, 0, this.x, this.objFireMain.y - this.objFireMain.hOne / 2, 600, this.Dir, this.objMainEff);
	}

	// Token: 0x06000260 RID: 608 RVA: 0x00050D3C File Offset: 0x0004EF3C
	public void createUssop1()
	{
		bool flag = this.typeEffect == 64;
		if (flag)
		{
			this.fraImgEff = new FrameImage(20, 10, 10);
		}
		else
		{
			bool flag2 = this.typeEffect == 66;
			if (flag2)
			{
				this.fraImgEff = new FrameImage(20, 10, 10);
			}
		}
		this.vMax = 24;
		this.fRemove = 5;
		GameScreen.addEffectEnd(3, 0, this.x, this.y, this.Dir, this.objMainEff);
	}

	// Token: 0x06000261 RID: 609 RVA: 0x00050DC0 File Offset: 0x0004EFC0
	public void createUssop2()
	{
		this.fraImgEff = new FrameImage(20, 10, 10);
		this.vMax = 24;
		bool flag = this.typeEffect == 206;
		if (flag)
		{
			base.setAngle();
			this.fraImgEff = new FrameImage(305, 16, 12);
			this.fraImgSubEff = new FrameImage(304, 10, 7);
			this.vMax = 16;
		}
		else
		{
			bool flag2 = this.typeEffect == 207;
			if (flag2)
			{
				base.setAngle();
				this.fraImgEff = new FrameImage(20, 10, 10);
				this.fraImgSubEff = new FrameImage(304, 10, 7);
				this.vMax = 16;
			}
		}
		this.fRemove = 5;
		this.y -= 6;
		bool flag3 = this.Dir == 0;
		if (flag3)
		{
			this.x -= 30;
		}
		else
		{
			this.x += 30;
		}
		int num = this.toX - this.x;
		int num2 = this.toY - this.y;
		base.create_Speed(num, num2, null);
		bool flag4 = this.typeEffect == 206;
		if (flag4)
		{
			int frameAngle = CRes.angle(num, num2);
			this.frame = base.setFrameAngle(frameAngle);
		}
		GameScreen.addEffectEnd(3, 0, this.x, this.y, this.Dir, this.objMainEff);
		this.fPlayFrameSuper = this.fRemove;
		bool flag5 = this.fRemove < 5;
		if (flag5)
		{
			this.fRemove = 5;
		}
	}

	// Token: 0x06000262 RID: 610 RVA: 0x00050F58 File Offset: 0x0004F158
	public void createUssopSkill1_Lv3()
	{
		this.fraImgEff = new FrameImage(53, 9, 9);
		this.fraImgSubEff = new FrameImage(20, 10, 10);
		this.vMax = 24;
		this.fRemove = 5;
		this.y -= 6;
		bool flag = this.Dir == 0;
		if (flag)
		{
			this.x -= 30;
		}
		else
		{
			this.x += 30;
		}
		int xdich = this.toX - this.x;
		int ydich = this.toY - this.y;
		Point_Focus point_Focus = new Point_Focus();
		point_Focus = base.create_Speed(xdich, ydich, point_Focus);
		point_Focus.frame = 1;
		GameScreen.addEffectEnd(1, 0, this.x, this.y, this.Dir, this.objMainEff);
		this.VecEff.addElement(point_Focus);
	}

	// Token: 0x06000263 RID: 611 RVA: 0x00051038 File Offset: 0x0004F238
	public void createNami1()
	{
		this.fraImgEff = new FrameImage(22, 70, 50);
		this.fraImgSubEff = new FrameImage(298, 24, 24, 6);
		this.fRemove = 10;
		bool flag = this.typeEffect == 53 || this.typeEffect == 163;
		if (flag)
		{
			this.fraImgSub2Eff = new FrameImage(27, 24, 24);
		}
		this.indexEff_1 = (int)this.objFireMain.indexEff_1;
		this.vMax = 12;
		this.y += 5;
		int num = 0;
		int xdich = this.toX - this.x;
		int ydich = this.toY - num - this.y;
		Point_Focus point_Focus = new Point_Focus();
		point_Focus = base.create_Speed(xdich, ydich, point_Focus);
		point_Focus.frame = 0;
		this.VecEff.addElement(point_Focus);
		bool flag2 = this.isAddSound;
		if (flag2)
		{
			mSound.playSound(18, mSound.volumeSound);
		}
	}

	// Token: 0x06000264 RID: 612 RVA: 0x00051130 File Offset: 0x0004F330
	public void createNami1_SHORT()
	{
		this.fraImgEff = new FrameImage(22, 70, 50);
		this.fraImgSubEff = new FrameImage(298, 24, 24, 6);
		bool flag = this.typeEffect == 190 || this.typeEffect == 222 || this.typeEffect == 312;
		if (flag)
		{
			this.fraImgSubEff = new FrameImage(299, 26, 26, 2);
			bool flag2 = this.typeEffect == 222 || this.typeEffect == 312;
			if (flag2)
			{
				this.fraImgEff = new FrameImage(324, 70, 50);
				this.fraImgSub3Eff = new FrameImage(326, 26, 26, 3);
			}
		}
		this.indexEff_1 = (int)this.objFireMain.indexEff_1;
		this.fRemove = 24;
		this.fraImgSub2Eff = new FrameImage(27, 24, 24);
		this.vMax = 12;
		bool flag3 = this.isAddSound;
		if (flag3)
		{
			mSound.playSound(22, mSound.volumeSound);
		}
		int num = (this.Dir != 0) ? -15 : 15;
		GameScreen.addEffectEnd(30, 0, this.x + num, this.objFireMain.y - this.objFireMain.hOne / 2, 500, this.Dir, this.objMainEff);
	}

	// Token: 0x06000265 RID: 613 RVA: 0x0005128C File Offset: 0x0004F48C
	public void createNamiSea1_2()
	{
		this.yplus = this.y;
		this.y += this.objFireMain.hOne / 2;
		this.vMax = 12;
		this.fraImgEff = new FrameImage(28, 46, 50, 46, 50);
		this.fraImgSubEff = new FrameImage(29, 28, 30, 28, 30);
		this.fraImgSub2Eff = new FrameImage(298, 24, 24, 6);
		this.indexEff_1 = (int)this.objFireMain.indexEff_1;
		bool flag = this.Dir == 0;
		if (flag)
		{
			this.xplus = this.x - 20;
		}
		else
		{
			this.xplus = this.x + 20;
		}
		bool flag2 = this.Dir == 0;
		if (flag2)
		{
			this.x -= 30;
		}
		else
		{
			this.x += 30;
		}
		bool flag3 = this.typeEffect == 139;
		if (flag3)
		{
			this.fraImgSub3Eff = new FrameImage(27, 24, 24);
			GameScreen.addEffectEnd(30, 0, this.x, this.objFireMain.y - this.objFireMain.hOne / 2, 500, this.Dir, this.objMainEff);
		}
		else
		{
			this.fraImgSub3Eff = new FrameImage(13, 24, 24);
			GameScreen.addEffectEnd(30, 0, this.x, this.objFireMain.y - this.objFireMain.hOne / 2, 300, this.Dir, this.objMainEff);
		}
		bool flag4 = this.isAddSound;
		if (flag4)
		{
			mSound.playSound(18, mSound.volumeSound);
		}
	}

	// Token: 0x06000266 RID: 614 RVA: 0x00051440 File Offset: 0x0004F640
	public void createNamiSea3()
	{
		this.yplus = this.y;
		this.y += this.objFireMain.hOne / 2;
		this.vMax = 12;
		this.fraImgSub2Eff = new FrameImage(298, 24, 24, 6);
		this.indexEff_1 = (int)this.objFireMain.indexEff_1;
		bool flag = this.Dir == 0;
		if (flag)
		{
			this.xplus = this.x - 20;
		}
		else
		{
			this.xplus = this.x + 20;
		}
		bool flag2 = this.Dir == 0;
		if (flag2)
		{
			this.x -= 30;
		}
		else
		{
			this.x += 30;
		}
		bool flag3 = this.isAddSound;
		if (flag3)
		{
			mSound.playSound(18, mSound.volumeSound);
		}
		this.fraImgSub3Eff = new FrameImage(27, 24, 24);
		GameScreen.addEffectEnd(30, 0, this.x, this.objFireMain.y - this.objFireMain.hOne / 2, 500, this.Dir, this.objMainEff);
		this.mImgframe = new FrameImage[3];
		this.mImgframe[0] = new FrameImage(25, 80, 40, 60, 30);
		this.mImgframe[1] = new FrameImage(24, 15, 60);
		this.mImgframe[2] = new FrameImage(81, 24, 24);
	}

	// Token: 0x06000267 RID: 615 RVA: 0x000515B0 File Offset: 0x0004F7B0
	public void createSanji2()
	{
		this.numNextFrame = 2;
		this.vMax = 16;
		this.fRemove = 16;
		this.fraImgEff = new FrameImage(31, 70, 70);
		this.Dir = (sbyte)this.objFireMain.type_left_right;
		int time = 300;
		bool flag = this.typeEffect == 12;
		if (flag)
		{
			this.fraImgSubEff = new FrameImage(77, 64, 75, 43, 50);
			this.fraImgSub2Eff = new FrameImage(224, 22, 28);
			this.fraImgSub3Eff = new FrameImage(78, 22, 28);
			this.fRemove = 24;
			time = 600;
		}
		else
		{
			bool flag2 = this.typeEffect == 188 || this.typeEffect == 220 || this.typeEffect == 293;
			if (flag2)
			{
				this.fraImgSubEff = new FrameImage(282, 64, 75);
				bool flag3 = this.typeEffect == 293;
				if (flag3)
				{
					this.fraImgSub2Eff = new FrameImage(406, 42, 34);
					this.fraImgSub4Eff = new FrameImage(283, 22, 28);
					this.fraImgSubEff = new FrameImage(412, 64, 75);
				}
				else
				{
					bool flag4 = this.typeEffect == 220;
					if (flag4)
					{
						this.fraImgSub2Eff = new FrameImage(325, 32, 31);
						this.fraImgSub4Eff = new FrameImage(224, 22, 28);
					}
					else
					{
						this.fraImgSub2Eff = new FrameImage(224, 22, 28);
					}
				}
				this.fraImgSub3Eff = new FrameImage(283, 22, 28);
				this.fraImgEff = new FrameImage(284, 70, 70);
				this.fRemove = 24;
				time = 600;
			}
			else
			{
				bool flag5 = this.typeEffect == 49;
				if (flag5)
				{
					this.fraImgSubEff = new FrameImage(78, 22, 28);
					this.fraImgSub2Eff = new FrameImage(102, 35, 19);
				}
				else
				{
					bool flag6 = this.typeEffect == 50;
					if (flag6)
					{
						this.fraImgSub2Eff = new FrameImage(103, 35, 19, 35, 19);
						this.fraImgSubEff = new FrameImage(78, 22, 28);
					}
				}
			}
		}
		this.x1000 = this.x;
		this.y1000 = this.objFireMain.y;
		bool flag7 = this.Dir == 0;
		if (flag7)
		{
			this.x -= 16;
		}
		else
		{
			this.x += 16;
		}
		bool flag8 = this.isAddSound;
		if (flag8)
		{
			mSound.playSound(16, mSound.volumeSound);
		}
		GameScreen.addEffectEnd(30, 0, this.x, this.objFireMain.y - this.objFireMain.hOne / 3 * 2, time, this.Dir, this.objMainEff);
	}

	// Token: 0x06000268 RID: 616 RVA: 0x00051890 File Offset: 0x0004FA90
	public void createRankyaku()
	{
		this.vMax = 16;
		this.fRemove = 22;
		this.Dir = (sbyte)this.objFireMain.type_left_right;
		this.fraImgEff = new FrameImage(428, 1);
		this.x1000 = this.x + 30 * this.am_duong;
		int xdich = this.x1000 - this.x;
		this.VecEff.addElement(base.create_Speed(xdich, 0, new Point_Focus(), this.x, this.y, this.toX, this.toY));
		this.VecEff.addElement(base.create_Speed(xdich, -7, new Point_Focus(), this.x, this.y, this.toX, this.toY));
		this.VecEff.addElement(base.create_Speed(xdich, 7, new Point_Focus(), this.x, this.y, this.toX, this.toY));
	}

	// Token: 0x06000269 RID: 617 RVA: 0x0005198C File Offset: 0x0004FB8C
	public void createSoi()
	{
		this.vMax = 12;
		this.fRemove = 20;
		this.Dir = (sbyte)this.objFireMain.type_left_right;
		this.fraImgEff = new FrameImage(429, 4);
		bool flag = this.typeEffect == 277;
		if (flag)
		{
			this.fraImgEff = new FrameImage(430, 4);
		}
	}

	// Token: 0x0600026A RID: 618 RVA: 0x000519F4 File Offset: 0x0004FBF4
	public void createShigan()
	{
		this.vMax = 17;
		this.fRemove = 14;
		this.Dir = (sbyte)this.objFireMain.type_left_right;
		this.fraImgEff = new FrameImage(75, 1);
		this.x1000 = this.x + 30 * this.am_duong;
		int xdich = this.x1000 - this.x;
		this.VecEff.addElement(base.create_Speed(xdich, 0, new Point_Focus(), this.x, this.y, this.toX, this.toY));
		GameScreen.addEffectEnd(30, 0, this.x + 15 * this.am_duong, this.objFireMain.y - this.objFireMain.hOne / 3 * 2, 200, this.Dir, this.objMainEff);
	}

	// Token: 0x0600026B RID: 619 RVA: 0x00009914 File Offset: 0x00007B14
	public void createDoor()
	{
		this.fRemove = 26;
		this.fraImgEff = new FrameImage(426, 2);
		this.levelPaint = -1;
	}

	// Token: 0x0600026C RID: 620 RVA: 0x00051ACC File Offset: 0x0004FCCC
	public void createHuou()
	{
		this.fRemove = 20;
		this.fraImgEff = new FrameImage(176, 3, 25, 1);
		this.fraImgSubEff = new FrameImage(220, 9, 9, 4);
		this.size1 = 30;
		bool flag = this.typeEffect == 279;
		if (flag)
		{
			this.size1 = 60;
		}
		bool flag2 = GameCanvas.isLowGraOrWP_PvP();
		if (flag2)
		{
			this.size1 = 10;
		}
		for (int i = 0; i < this.size1; i++)
		{
			Point point = new Point();
			this.createPointHuou(point);
			point.vy = 20;
			this.VecEff.addElement(point);
		}
	}

	// Token: 0x0600026D RID: 621 RVA: 0x00051B80 File Offset: 0x0004FD80
	private Point createPointHuou(Point p)
	{
		p.frame = CRes.random(5);
		bool flag = this.typeEffect == 279;
		if (flag)
		{
			p.x = CRes.random_Am_0(60);
			p.y = -10 - CRes.random(60);
			p.dis = CRes.random(6);
		}
		else
		{
			p.x = CRes.random_Am_0(40);
			p.y = -10 - CRes.random(60);
			p.dis = 2;
		}
		return p;
	}

	// Token: 0x0600026E RID: 622 RVA: 0x00051C04 File Offset: 0x0004FE04
	public void createZoro3()
	{
		this.fRemove = 12;
		bool flag = this.typeEffect == 15;
		if (flag)
		{
			this.fRemove = 15;
		}
	}

	// Token: 0x0600026F RID: 623 RVA: 0x00009937 File Offset: 0x00007B37
	public void createZoro4()
	{
		this.fraImgSub2Eff = new FrameImage(71, 64, 25);
		this.fraImgEff = new FrameImage(88, 32, 70);
		this.fRemove = 20;
		this.vMax = 12;
	}

	// Token: 0x06000270 RID: 624 RVA: 0x0000996C File Offset: 0x00007B6C
	public void createZoroSkill3_Lv1()
	{
		this.vMax = 12;
		this.y = this.objFireMain.y + 5;
	}

	// Token: 0x06000271 RID: 625 RVA: 0x00051C34 File Offset: 0x0004FE34
	public void createZoro8()
	{
		this.fraImgEff = new FrameImage(8, 40, 47, 40, 47);
		this.objFireMain.isTanHinh = true;
		bool flag = this.objFireMain.plashNow != null;
		if (flag)
		{
			this.objFireMain.plashNow.setIsNextf(1);
		}
		this.x = this.objFireMain.x;
		this.y = this.objFireMain.y;
		this.toX = this.objBeFireMain.x;
		this.toY = this.objBeFireMain.y;
		this.vMax = 20;
		int num = this.toX - this.x;
		int num2 = this.toY - this.y;
		int num3 = 90;
		int a = CRes.angle(num, num2);
		this.toX = this.x + num3 * CRes.getcos(a) / 1000;
		this.toY = this.y + num3 * CRes.getsin(a) / 1000;
		num = this.toX - this.x;
		num2 = this.toY - this.y;
		bool flag2 = num2 == 0;
		if (flag2)
		{
			num2 = 1;
		}
		bool flag3 = num == 0;
		if (flag3)
		{
			num = 1;
		}
		int num4 = MainObject.getDistance(num, num2) / this.vMax;
		bool flag4 = num4 == 0;
		if (flag4)
		{
			num4 = 1;
		}
		int num5 = num / num4;
		int num6 = num2 / num4;
		bool flag5 = CRes.abs(num5) > CRes.abs(num);
		if (flag5)
		{
			num5 = num;
		}
		bool flag6 = CRes.abs(num6) > CRes.abs(num2);
		if (flag6)
		{
			num6 = num2;
		}
		this.vx = num5;
		this.vy = num6;
		this.fRemove = num4;
		bool flag7 = this.fRemove > 0;
		if (flag7)
		{
			this.timeAddNum = (int)((sbyte)(this.fRemove / 2));
		}
	}

	// Token: 0x06000272 RID: 626 RVA: 0x00051E10 File Offset: 0x00050010
	public void createLuffy6()
	{
		bool flag = this.objFireMain == GameScreen.player;
		if (flag)
		{
			GameScreen.setIsMoveEff(true);
		}
		this.fRemove = 11;
		bool flag2 = !this.checkNullObject(3);
		if (flag2)
		{
			this.objFireMain.x = this.objBeFireMain.x + this.objFireMain.vMax * 3 * 7;
			bool flag3 = this.Dir == 2;
			if (flag3)
			{
				this.objFireMain.x = this.objBeFireMain.x - this.objFireMain.vMax * 3 * 7;
			}
			this.objFireMain.y = this.objBeFireMain.y;
		}
		this.fraImgEff = new FrameImage(4, 20, 20);
		this.fraImgSubEff = new FrameImage(8, 40, 47, 40, 47);
	}

	// Token: 0x06000273 RID: 627 RVA: 0x00051EE8 File Offset: 0x000500E8
	public void createNamiSkill1_L3()
	{
		this.Dir = (sbyte)this.objFireMain.type_left_right;
		for (int i = 0; i < 2; i++)
		{
			int a = 25;
			bool flag = this.objFireMain.hOne > 1;
			if (flag)
			{
				a = this.objFireMain.hOne / 2;
			}
			Point o = new Point(this.x + CRes.random_Am_0(20), this.y + CRes.random_Am_0(a));
			this.VecEff.addElement(o);
		}
		this.fRemove = 16;
		bool flag2 = this.Dir == 0;
		if (flag2)
		{
			this.x -= 20;
		}
		else
		{
			this.x += 20;
		}
		this.fraImgSubEff = new FrameImage(299, 26, 26, 2);
		this.fraImgEff = new FrameImage(273, 24, 24, 4);
		this.indexEff_1 = (int)this.objFireMain.indexEff_1;
		bool flag3 = this.isAddSound;
		if (flag3)
		{
			mSound.playSound(10, mSound.volumeSound);
		}
	}

	// Token: 0x06000274 RID: 628 RVA: 0x00052000 File Offset: 0x00050200
	public void createNamiSkill3()
	{
		this.fRemove = 20;
		this.vMax = 10;
		this.x1000 = this.x;
		bool flag = this.objFireMain.Dir == 0;
		if (flag)
		{
			this.x -= 20;
		}
		else
		{
			this.x += 20;
		}
		this.indexEff_1 = (int)this.objFireMain.indexEff_1;
		bool flag2 = this.typeEffect == 31;
		if (flag2)
		{
			this.fraImgEff = new FrameImage(83, 14, 14);
			this.fraImgSubEff = new FrameImage(298, 24, 24, 6);
		}
		else
		{
			bool flag3 = this.typeEffect == 55 || this.typeEffect == 56 || this.typeEffect == 191 || this.typeEffect == 223 || this.typeEffect == 313;
			if (flag3)
			{
				this.fraImgEff = new FrameImage(81, 24, 24);
				this.fraImgSubEff = new FrameImage(299, 26, 26, 2);
				this.fraImgSub2Eff = new FrameImage(27, 24, 24);
				bool flag4 = this.typeEffect == 56 || this.typeEffect == 191 || this.typeEffect == 223 || this.typeEffect == 313;
				if (flag4)
				{
					GameScreen.addEffectEnd(30, 0, this.x, this.objFireMain.y - this.objFireMain.hOne / 3 * 2, 1000, this.Dir, this.objMainEff);
					this.fRemove = 26;
				}
			}
		}
		bool flag5 = this.isAddSound;
		if (flag5)
		{
			mSound.playSound(10, mSound.volumeSound);
		}
	}

	// Token: 0x06000275 RID: 629 RVA: 0x000521C4 File Offset: 0x000503C4
	public void createNamiSkill1()
	{
		this.fRemove = 16;
		bool flag = this.Dir == 0;
		if (flag)
		{
			this.x -= 20;
		}
		else
		{
			this.x += 20;
		}
		this.indexEff_1 = (int)this.objFireMain.indexEff_1;
		this.fraImgSubEff = new FrameImage(298, 24, 24, 6);
		bool flag2 = this.typeEffect == 51;
		if (flag2)
		{
			this.fraImgEff = new FrameImage(299, 26, 26, 2);
		}
		bool flag3 = this.isAddSound;
		if (flag3)
		{
			mSound.playSound(10, mSound.volumeSound);
		}
	}

	// Token: 0x06000276 RID: 630 RVA: 0x00052270 File Offset: 0x00050470
	public void createAlvida2()
	{
		bool flag = this.Dir == 0;
		if (flag)
		{
			this.x -= 30;
		}
		else
		{
			this.x += 30;
		}
		this.y -= 15;
		this.fraImgEff = new FrameImage(116, 38, 53);
		this.fraImgSubEff = new FrameImage(117, 38, 22);
		this.fRemove = 10;
		int num = this.x;
		num = ((this.Dir != 0) ? (num - 45) : (num + 45));
		GameScreen.addEffectEnd(30, 0, num, this.y - 30, 300, this.Dir, this.objMainEff);
	}

	// Token: 0x06000277 RID: 631 RVA: 0x00052328 File Offset: 0x00050528
	public void createAlvida1()
	{
		bool flag = this.Dir == 0;
		if (flag)
		{
			this.x -= 26;
		}
		else
		{
			this.x += 26;
		}
		this.y -= 15;
		this.fraImgEff = new FrameImage(116, 38, 53);
		this.fRemove = 2;
		this.addSound(2);
	}

	// Token: 0x06000278 RID: 632 RVA: 0x00052398 File Offset: 0x00050598
	public void createMon_4_5()
	{
		bool flag = this.Dir == 0;
		if (flag)
		{
			this.x -= 14;
		}
		else
		{
			this.x += 14;
		}
		this.y -= 10;
		this.fRemove = 6;
		bool flag2 = this.typeEffect == 73;
		if (flag2)
		{
			this.fraImgEff = new FrameImage(115, 34, 27);
		}
		else
		{
			this.fraImgEff = new FrameImage(35, 34, 27);
		}
	}

	// Token: 0x06000279 RID: 633 RVA: 0x00052424 File Offset: 0x00050624
	public void createMon6()
	{
		bool flag = this.Dir == 0;
		if (flag)
		{
			this.x -= 14;
		}
		else
		{
			this.x += 14;
		}
		this.x1000 = this.x;
		this.y1000 = this.y - 10;
		this.vMax = 14;
		this.fraImgEff = new FrameImage(47, 41, 14);
		this.fraImgSubEff = new FrameImage(35, 34, 27);
		int xdich = this.toX - this.x;
		int ydich = this.toY - this.y;
		base.create_Speed(xdich, ydich, null);
		this.frame = CRes.random(this.fraImgSubEff.nFrame);
	}

	// Token: 0x0600027A RID: 634 RVA: 0x000524E4 File Offset: 0x000506E4
	public void createMon3()
	{
		bool flag = this.Dir == 0;
		if (flag)
		{
			this.x -= 25;
		}
		else
		{
			this.x += 25;
		}
		this.vMax = 14;
		this.fraImgEff = new FrameImage(20, 10, 10);
		int xdich = this.toX - this.x;
		int ydich = this.toY - this.y;
		base.create_Speed(xdich, ydich, null);
		GameScreen.addEffectEnd(3, 0, this.x, this.y, this.Dir, this.objMainEff);
	}

	// Token: 0x0600027B RID: 635 RVA: 0x00052584 File Offset: 0x00050784
	public void createMon2()
	{
		this.vMax = 12;
		bool flag = this.typeEffect == 145;
		if (flag)
		{
			this.fraImgEff = new FrameImage(60, 15, 15);
		}
		else
		{
			bool flag2 = this.typeEffect == 146;
			if (flag2)
			{
				this.fraImgEff = new FrameImage(59, 23, 23);
			}
			else
			{
				bool flag3 = this.typeEffect == 147;
				if (flag3)
				{
					this.fraImgEff = new FrameImage(20, 10, 10);
				}
				else
				{
					bool flag4 = this.typeEffect == 148;
					if (flag4)
					{
						this.fraImgEff = new FrameImage(73, 20, 20);
						this.numNextFrame = 2;
						this.vMax = 14;
					}
					else
					{
						this.fraImgEff = new FrameImage(114, 21, 14);
					}
				}
			}
		}
		int xdich = this.toX - this.x;
		int ydich = this.toY - this.y;
		base.create_Speed(xdich, ydich, null);
		this.objFireMain.isPaintWeapon = false;
	}

	// Token: 0x0600027C RID: 636 RVA: 0x00052690 File Offset: 0x00050890
	public void createZoro_New2()
	{
		this.fRemove = 44;
		this.vMax = 12;
		this.fraImgEff = new FrameImage(8, 40, 47, 40, 47);
		bool flag = this.isAddSound;
		if (flag)
		{
			mSound.playSound(8, mSound.volumeSound);
		}
		GameScreen.addEffectEnd(30, 0, this.x, this.y, 300, this.Dir, this.objMainEff);
	}

	// Token: 0x0600027D RID: 637 RVA: 0x0000998A File Offset: 0x00007B8A
	public void createZoro_New1()
	{
		this.fRemove = 50;
		this.vMax = 12;
		this.fraImgEff = new FrameImage(88, 32, 70);
		this.y = this.objFireMain.y;
	}

	// Token: 0x0600027E RID: 638 RVA: 0x00052700 File Offset: 0x00050900
	public void createZoro_S1_L3_SHORT()
	{
		this.fRemove = 16;
		bool flag = this.typeEffect == 183 || this.typeEffect == 215;
		if (flag)
		{
			this.fRemove = 18;
		}
		this.vMax = 12;
		this.fraImgEff = new FrameImage(88, 32, 70);
		bool flag2 = this.typeEffect == 215;
		if (flag2)
		{
			this.fraImgEff = new FrameImage(319, 32, 70);
		}
		this.y = this.objFireMain.y;
	}

	// Token: 0x0600027F RID: 639 RVA: 0x00052794 File Offset: 0x00050994
	public void createZoro_S1_L6()
	{
		this.fRemove = 20;
		this.vMax = 18;
		this.fraImgEff = new FrameImage(422, 32, 70);
		this.y = this.objFireMain.y;
		this.x1000 = this.x + 30 * this.am_duong;
		this.xLight1 = this.x1000;
		this.xLight2 = this.x1000;
		this.fraImgSub2Eff = new FrameImage(417, 3);
		int xdich = this.x1000 - this.x;
		int ydich = 0;
		this.VecSubEff.addElement(base.create_Speed(xdich, ydich, new Point_Focus(), this.x, this.y - this.objFireMain.hOne - 20, this.toX, this.toY));
		this.VecSubEff.addElement(base.create_Speed(xdich, ydich, new Point_Focus(), this.x, this.y - this.objFireMain.hOne - 15, this.toX, this.toY));
	}

	// Token: 0x06000280 RID: 640 RVA: 0x000528A8 File Offset: 0x00050AA8
	public void createLuffy_New3()
	{
		this.levelPaint = -1;
		this.fRemove = 30;
		bool flag = this.typeEffect == 182;
		if (flag)
		{
			this.fraImgEff = new FrameImage(276, 90, 50);
		}
		else
		{
			bool flag2 = this.typeEffect == 214 || this.typeEffect == 273;
			if (flag2)
			{
				this.fraImgEff = new FrameImage(317, 90, 50);
				this.levelPaint = 0;
			}
			else
			{
				this.fraImgEff = new FrameImage(1, 80, 40);
			}
		}
		this.fraImgSubEff = new FrameImage(27, 24, 32);
		this.fraImgSub2Eff = new FrameImage(8, 40, 47, 40, 47);
		this.Dir = (sbyte)this.objFireMain.type_left_right;
	}

	// Token: 0x06000281 RID: 641 RVA: 0x00052978 File Offset: 0x00050B78
	public void createLuffy_New2()
	{
		bool flag = this.objFireMain == GameScreen.player;
		if (flag)
		{
			GameScreen.setIsMoveEff(true);
		}
		bool flag2 = !this.checkNullObject(3);
		if (flag2)
		{
			this.objFireMain.x = this.objBeFireMain.x + 30;
			bool flag3 = this.Dir == 2;
			if (flag3)
			{
				this.objFireMain.x = this.objBeFireMain.x - 30;
			}
			this.objFireMain.y = this.objBeFireMain.y;
		}
		int num = -15;
		bool flag4 = this.Dir == 0;
		if (flag4)
		{
			num = 15;
		}
		GameScreen.addEffectEnd(30, 0, this.x + num, this.y, 300, this.Dir, this.objMainEff);
		this.fraImgEff = new FrameImage(4, 20, 20);
		this.fraImgSubEff = new FrameImage(8, 40, 47, 40, 47);
		this.fraImgSub2Eff = new FrameImage(11, 40, 50);
		this.fRemove = 34;
	}

	// Token: 0x06000282 RID: 642 RVA: 0x00052A84 File Offset: 0x00050C84
	public void createLuffy_New2_SHORT()
	{
		bool flag = this.objFireMain == GameScreen.player;
		if (flag)
		{
			GameScreen.setIsMoveEff(true);
		}
		bool flag2 = !this.checkNullObject(3);
		if (flag2)
		{
			this.objFireMain.x = this.objBeFireMain.x + 30;
			bool flag3 = this.Dir == 2;
			if (flag3)
			{
				this.objFireMain.x = this.objBeFireMain.x - 30;
			}
			this.objFireMain.y = this.objBeFireMain.y;
		}
		this.fraImgEff = new FrameImage(4, 20, 20);
		this.fraImgSubEff = new FrameImage(8, 40, 47, 40, 47);
		this.fraImgSub2Eff = new FrameImage(11, 40, 50);
		bool flag4 = this.typeEffect == 213 || this.typeEffect == 272;
		if (flag4)
		{
			this.fraImgSub3Eff = new FrameImage(316, 44, 47);
		}
		this.fRemove = 24;
	}

	// Token: 0x06000283 RID: 643 RVA: 0x00052B88 File Offset: 0x00050D88
	public void createMon_1()
	{
		bool flag = this.Dir == 0;
		if (flag)
		{
			this.x1000 = this.x - 10;
			this.x -= 20;
		}
		else
		{
			this.x1000 = this.x + 10;
			this.x += 20;
		}
		this.y1000 = this.y - 12;
		this.fraImgEff = new FrameImage(114, 16, 13);
		this.fraImgSubEff = new FrameImage(35, 34, 27);
		this.fRemove = 6;
		this.vx = 3 * this.am_duong;
	}

	// Token: 0x06000284 RID: 644 RVA: 0x00052C2C File Offset: 0x00050E2C
	public void createMon_10()
	{
		this.fRemove = 5;
		this.fraImgEff = new FrameImage(120, 50, 25);
		bool flag = this.typeEffect == 143;
		if (flag)
		{
			this.fraImgEff = new FrameImage(2, 53, 29);
		}
		bool flag2 = this.typeEffect == 149;
		if (flag2)
		{
			this.fraImgEff = new FrameImage(68, 28, 44);
		}
		this.numNextFrame = 1;
		bool flag3 = this.Dir == 0;
		if (flag3)
		{
			this.x -= 10;
		}
		else
		{
			this.x += 10;
		}
		bool flag4 = this.Dir == 0;
		if (flag4)
		{
			this.vx = -8;
		}
		else
		{
			this.vx = 8;
		}
	}

	// Token: 0x06000285 RID: 645 RVA: 0x00052CF4 File Offset: 0x00050EF4
	public void createMon_11()
	{
		this.numNextFrame = 1;
		bool flag = this.Dir == 0;
		if (flag)
		{
			this.x -= 10;
		}
		else
		{
			this.x += 10;
		}
		bool flag2 = this.Dir == 0;
		if (flag2)
		{
			this.vx1000 = -12;
		}
		else
		{
			this.vx1000 = 12;
		}
		this.vMax = 12;
		this.fraImgEff = new FrameImage(120, 50, 25);
		bool flag3 = this.typeEffect == 144;
		if (flag3)
		{
			this.fraImgEff = new FrameImage(2, 53, 29);
		}
		int xdich = this.toX - this.x;
		int ydich = this.toY - this.y;
		base.create_Speed(xdich, ydich, null);
	}

	// Token: 0x06000286 RID: 646 RVA: 0x00052DC4 File Offset: 0x00050FC4
	public void createCausu_1()
	{
		this.fRemove = 26;
		bool flag = this.typeEffect == 227;
		if (flag)
		{
			this.fraImgEff = new FrameImage(317, 90, 50);
			this.fraImgSubEff = new FrameImage(334, 75, 42);
		}
		else
		{
			this.fraImgEff = new FrameImage(1, 80, 40);
			this.fraImgSubEff = new FrameImage(62, 48, 34);
		}
		bool flag2 = !this.checkNullObject(3);
		if (flag2)
		{
			this.objFireMain.x = this.objBeFireMain.x - this.am_duong * 48;
			this.objFireMain.y = this.objBeFireMain.y;
			this.x = this.objFireMain.x;
			this.y = this.objFireMain.y - this.objFireMain.hOne / 2;
		}
		for (int i = 0; i < 2; i++)
		{
			Point point = new Point();
			point.x = this.x + this.am_duong * 15;
			point.y = this.y;
			point.vx = this.am_duong * (5 + CRes.random(2));
			point.vy = CRes.random_Am_0(2);
			point.fRe = 6 + CRes.random(3);
			point.dis = ((CRes.random(3) != 0) ? 1 : 0);
			this.VecEff.addElement(point);
		}
	}

	// Token: 0x06000287 RID: 647 RVA: 0x00052F40 File Offset: 0x00051140
	public void createMorgan_2()
	{
		int num = 20;
		bool flag = this.Dir == 2;
		if (flag)
		{
			num = -20;
		}
		GameScreen.addEffectEnd(30, 0, this.x + num, this.y, 300, this.Dir, this.objMainEff);
		this.fRemove = 8;
		this.addSound(7);
	}

	// Token: 0x06000288 RID: 648 RVA: 0x00052F9C File Offset: 0x0005119C
	public void createCabaji_1()
	{
		this.fRemove = 5;
		this.fraImgEff = new FrameImage(186, 19, 22);
		this.fraImgSubEff = new FrameImage(187, 20, 20);
		this.fraImgSub2Eff = new FrameImage(120, 50, 25);
		this.vMax = 14;
		int num = -14;
		bool flag = this.Dir == 2;
		if (flag)
		{
			num = 14;
		}
		this.x += num;
	}

	// Token: 0x06000289 RID: 649 RVA: 0x00053018 File Offset: 0x00051218
	public void createBuggy_2()
	{
		this.fraImgEff = new FrameImage(125, 60, 44, 60, 44);
		this.fraImgSubEff = new FrameImage(126, 45, 45);
		this.fraImgSub2Eff = new FrameImage(3, 30, 50);
		this.fraImgSub3Eff = new FrameImage(128, 16, 16);
		this.vMax = 24;
		int num = -14;
		bool flag = this.Dir == 2;
		if (flag)
		{
			num = 14;
		}
		this.x1000 = this.x + num;
		this.y1000 = this.y + 14;
		this.fRemove = 49;
	}

	// Token: 0x0600028A RID: 650 RVA: 0x000530B4 File Offset: 0x000512B4
	public void createBuggy_1()
	{
		this.fRemove = 5;
		int num = -25;
		bool flag = this.Dir == 2;
		if (flag)
		{
			num = 25;
		}
		this.x += num;
		this.fraImgEff = new FrameImage(124, 27, 22);
		this.vMax = 10;
	}

	// Token: 0x0600028B RID: 651 RVA: 0x00053108 File Offset: 0x00051308
	public void createMohji_2()
	{
		this.fRemove = 8;
		this.fraImgEff = new FrameImage(120, 50, 25);
		int num = -25;
		bool flag = this.Dir == 2;
		if (flag)
		{
			num = 25;
		}
		this.x += num;
		this.y += 10;
	}

	// Token: 0x0600028C RID: 652 RVA: 0x00053160 File Offset: 0x00051360
	public void createKuro_1()
	{
		this.fraImgEff = new FrameImage(45, 80, 25);
		this.fraImgSubEff = new FrameImage(8, 40, 47, 40, 47);
		this.fRemove = 18;
		this.objFireMain.isTanHinh = true;
		this.toY = this.objBeFireMain.y;
		this.y = this.objFireMain.y;
	}

	// Token: 0x0600028D RID: 653 RVA: 0x000531CC File Offset: 0x000513CC
	public void createJango_1()
	{
		this.fRemove = 5;
		this.fraImgEff = new FrameImage(131, 20, 10);
		this.fraImgSubEff = new FrameImage(27, 12, 12);
		this.fraImgSub2Eff = new FrameImage(120, 50, 25);
		this.vMax = 14;
		int num = -14;
		bool flag = this.Dir == 2;
		if (flag)
		{
			num = 14;
		}
		this.x += num;
	}

	// Token: 0x0600028E RID: 654 RVA: 0x00053244 File Offset: 0x00051444
	public void createNyaban_3()
	{
		this.fraImgEff = new FrameImage(120, 50, 25);
		this.fRemove = 27;
		this.x1000 = -15;
		bool flag = this.Dir == 2;
		if (flag)
		{
			this.x1000 = 15;
		}
		this.vx = (this.toX - (this.x + this.x1000)) / 5;
	}

	// Token: 0x0600028F RID: 655 RVA: 0x000099BF File Offset: 0x00007BBF
	public void createNyaban_2()
	{
		this.fraImgEff = new FrameImage(130, 48, 39);
		this.fRemove = 12;
		this.vx = (this.toX - this.x) / 5;
	}

	// Token: 0x06000290 RID: 656 RVA: 0x000532A8 File Offset: 0x000514A8
	public void createNyaban_1()
	{
		this.fRemove = 10;
		this.fraImgEff = new FrameImage(120, 50, 25);
		int num = -14;
		bool flag = this.Dir == 2;
		if (flag)
		{
			num = 14;
		}
		this.x += num;
	}

	// Token: 0x06000291 RID: 657 RVA: 0x000532F4 File Offset: 0x000514F4
	public void createCabaji_2()
	{
		this.fraImgEff = new FrameImage(129, 40, 80);
		this.fraImgSubEff = new FrameImage(76, 32, 70);
		this.toY = this.objBeFireMain.y;
		this.fRemove = 15;
	}

	// Token: 0x06000292 RID: 658 RVA: 0x00053340 File Offset: 0x00051540
	public void createKurobi_1()
	{
		this.fRemove = 32;
		this.fraImgEff = new FrameImage(144, 37, 55);
		this.x1000 = -30;
		bool flag = this.Dir == 2;
		if (flag)
		{
			this.x1000 = 30;
		}
		this.y -= 5;
		GameScreen.addEffectEnd(30, 0, this.x, this.y, 300, this.Dir, this.objMainEff);
	}

	// Token: 0x06000293 RID: 659 RVA: 0x000533C0 File Offset: 0x000515C0
	public void createChu_2()
	{
		this.vMax = 14;
		this.fraImgEff = new FrameImage(20, 10, 10);
		this.fRemove = 40;
		this.y -= 5;
		int num = 10;
		bool flag = this.Dir == 2;
		if (flag)
		{
			num = -10;
		}
		this.x += num;
		GameScreen.addEffectEnd(30, 0, this.x, this.y, 300, this.Dir, this.objMainEff);
	}

	// Token: 0x06000294 RID: 660 RVA: 0x00053448 File Offset: 0x00051648
	public void createChu_1()
	{
		this.vMax = 14;
		this.fraImgEff = new FrameImage(20, 10, 10);
		this.fRemove = 20;
		this.y -= 5;
		int num = 10;
		bool flag = this.Dir == 2;
		if (flag)
		{
			num = -10;
		}
		this.x += num;
	}

	// Token: 0x06000295 RID: 661 RVA: 0x000534A8 File Offset: 0x000516A8
	public void createHachi_2()
	{
		this.vMax = 14;
		this.fraImgEff = new FrameImage(81, 24, 24);
		bool flag = this.typeEffect == 150;
		if (flag)
		{
			this.fraImgEff = new FrameImage(83, 14, 14);
		}
		else
		{
			bool flag2 = this.typeEffect == 151;
			if (flag2)
			{
				this.fraImgEff = new FrameImage(80, 30, 15);
				this.frame = 0;
			}
			else
			{
				bool flag3 = this.typeEffect == 152;
				if (flag3)
				{
					this.fraImgEff = new FrameImage(80, 30, 15);
					this.frame = 1;
				}
				else
				{
					bool flag4 = this.typeEffect == 153;
					if (flag4)
					{
						this.fraImgEff = new FrameImage(80, 30, 15);
						this.frame = 2;
					}
				}
			}
		}
		this.fRemove = 24;
		this.y -= 10;
		int num = 10;
		bool flag5 = this.Dir == 2;
		if (flag5)
		{
			num = -10;
		}
		bool flag6 = this.typeEffect == 113;
		if (flag6)
		{
			GameScreen.addEffectEnd(30, 0, this.x, this.y, 600, this.Dir, this.objMainEff);
		}
		else
		{
			this.fRemove = 8;
			this.vMax = 16;
		}
		this.x += num;
		this.addSound(32);
	}

	// Token: 0x06000296 RID: 662 RVA: 0x00053610 File Offset: 0x00051810
	public void createDonKrieg_3()
	{
		this.fRemove = 30;
		this.fraImgEff = new FrameImage(137, 75, 65);
		this.plusxy = new int[2][];
		this.plusxy[0] = new int[2];
		this.plusxy[1] = new int[2];
		this.plusxy[0][0] = 0;
		this.plusxy[0][1] = -37;
		this.plusxy[1][0] = -28;
		this.plusxy[1][1] = -28;
		int num = 25;
		bool flag = this.Dir == 2;
		if (flag)
		{
			this.plusxy[1][0] = 28;
			num = -25;
		}
		GameScreen.addEffectEnd(30, 0, this.x + num, this.y, 300, this.Dir, this.objMainEff);
	}

	// Token: 0x06000297 RID: 663 RVA: 0x000536DC File Offset: 0x000518DC
	public void createDonKrieg_1()
	{
		this.fraImgEff = new FrameImage(134, 30, 42);
		this.fraImgSubEff = new FrameImage(135, 20, 20);
		this.vMax = 12;
		int num = 10;
		this.x1000 = 15;
		this.xplus = -10;
		bool flag = this.Dir == 0;
		if (flag)
		{
			num = -10;
			this.x1000 = -15;
			this.xplus = 10;
		}
		this.x += num;
		this.y -= 5;
		this.fRemove = 22;
	}

	// Token: 0x06000298 RID: 664 RVA: 0x00053774 File Offset: 0x00051974
	public void createDonKrieg_2()
	{
		this.fraImgEff = new FrameImage(134, 30, 42);
		this.fraImgSubEff = new FrameImage(136, 16, 12);
		this.fraImgSub2Eff = new FrameImage(131, 20, 10);
		this.vMax = 8;
		int num = 10;
		this.x1000 = 15;
		this.xplus = -10;
		bool flag = this.Dir == 0;
		if (flag)
		{
			num = -10;
			this.x1000 = -15;
			this.xplus = 10;
		}
		this.x += num;
		this.y -= 5;
		this.fRemove = 22;
		this.xArchor = this.x;
		this.yArchor = this.y;
	}

	// Token: 0x06000299 RID: 665 RVA: 0x00053838 File Offset: 0x00051A38
	public void createGhin_2()
	{
		this.objFireMain.isPaintWeapon = false;
		this.fRemove = 30;
		this.fraImgEff = new FrameImage(133, 36, 44);
		int num = 3;
		this.vx = -8;
		bool flag = this.Dir == 2;
		if (flag)
		{
			num = -3;
			this.vx = 8;
		}
		Point point = new Point(this.x - 15, this.y + num);
		point.frame = 0;
		point.dis = 4;
		this.VecEff.addElement(point);
		Point point2 = new Point(this.x + 15, this.y - num);
		point2.frame = 1;
		point2.dis = 4;
		this.VecEff.addElement(point2);
	}

	// Token: 0x0600029A RID: 666 RVA: 0x000538F8 File Offset: 0x00051AF8
	public void createGhin_1()
	{
		this.fraImgEff = new FrameImage(132, 60, 35);
		int num = 25;
		int num2 = 10;
		bool flag = this.Dir == 0;
		if (flag)
		{
			num = -25;
		}
		bool flag2 = this.typeEffect == 65 || this.typeEffect == 70;
		if (flag2)
		{
			this.fraImgEff = new FrameImage(215, 60, 35);
			bool flag3 = this.typeEffect == 70;
			if (flag3)
			{
				this.vMax = 16;
				this.fraImgSubEff = new FrameImage(216, 18, 18);
			}
			num = 28;
			bool flag4 = this.Dir == 0;
			if (flag4)
			{
				num = -28;
			}
			num2 = 13;
			this.levelPaint = -1;
		}
		this.fRemove = 6;
		this.x += num;
		this.y += num2;
	}

	// Token: 0x0600029B RID: 667 RVA: 0x000539D8 File Offset: 0x00051BD8
	public void createPearl_2()
	{
		this.fRemove = 34;
		this.vMax = 12;
		this.fraImgEff = new FrameImage(78, 22, 28);
		this.fraImgSubEff = new FrameImage(20, 10, 10);
		int num = 10;
		Point point = new Point(this.x - 18, this.y - num);
		point.frame = CRes.random(3);
		this.VecEff.addElement(point);
		Point point2 = new Point(this.x + 18, this.y - num);
		point2.frame = CRes.random(3);
		this.VecEff.addElement(point2);
	}

	// Token: 0x0600029C RID: 668 RVA: 0x00053A7C File Offset: 0x00051C7C
	public void createPearl_1()
	{
		this.fRemove = 10;
		int num = 15;
		bool flag = this.Dir == 0;
		if (flag)
		{
			num = -15;
		}
		GameScreen.addEffectEnd(30, 0, this.x - num, this.y, 300, this.Dir, this.objMainEff);
		this.x += num;
	}

	// Token: 0x0600029D RID: 669 RVA: 0x00053AE0 File Offset: 0x00051CE0
	public void createKuro_2()
	{
		this.fraImgEff = new FrameImage(45, 80, 25);
		this.fraImgSubEff = new FrameImage(8, 40, 47, 40, 47);
		this.fRemove = 38;
		this.y = this.objFireMain.y;
		this.x1000 = this.x;
		this.y1000 = this.y;
	}

	// Token: 0x0600029E RID: 670 RVA: 0x00053B44 File Offset: 0x00051D44
	public void createArlong_3()
	{
		this.fraImgEff = new FrameImage(148, 104, 85);
		this.fraImgSubEff = new FrameImage(149, 73, 73);
		this.fraImgSub2Eff = new FrameImage(150, 66, 70, 42, 45);
		this.objFireMain.isTanHinh = false;
		this.plusxy = new int[5][];
		this.plusxy[0] = new int[2];
		this.plusxy[1] = new int[2];
		this.plusxy[2] = new int[2];
		this.plusxy[3] = new int[2];
		this.plusxy[4] = new int[2];
		this.plusxy[0][0] = -15;
		this.plusxy[0][1] = -30;
		this.plusxy[1][0] = -30;
		this.plusxy[1][1] = 10;
		this.plusxy[2][0] = 38;
		this.plusxy[2][1] = -30;
		this.plusxy[3][0] = -30;
		this.plusxy[3][1] = -20;
		this.plusxy[4][0] = -20;
		this.plusxy[4][1] = 20;
		bool flag = this.Dir == 2;
		if (flag)
		{
			for (int i = 0; i < this.plusxy.Length; i++)
			{
				this.plusxy[i][0] = -this.plusxy[i][0];
			}
		}
		GameScreen.addEffectEnd(30, 0, this.x + this.plusxy[2][0], this.y + this.plusxy[2][1], 350, this.Dir, this.objMainEff);
		this.fRemove = 20;
	}

	// Token: 0x0600029F RID: 671 RVA: 0x00053CEC File Offset: 0x00051EEC
	public void createArlong_2()
	{
		this.fraImgEff = new FrameImage(146, 96, 24);
		this.fraImgSubEff = new FrameImage(147, 48, 12);
		this.fraImgSub2Eff = new FrameImage(256, 80, 40);
		this.objFireMain.isTanHinh = false;
		this.fRemove = 40;
		this.vMax = 30;
	}

	// Token: 0x060002A0 RID: 672 RVA: 0x00053D54 File Offset: 0x00051F54
	public void createArlong_1()
	{
		this.fraImgEff = new FrameImage(145, 80, 80, 60, 60);
		this.fRemove = 12;
		this.objFireMain.isTanHinh = false;
		bool flag = this.vecObjsBeFire.size() > 1;
		if (flag)
		{
			for (int i = 0; i < this.vecObjsBeFire.size(); i++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(i);
				bool flag2 = object_Effect_Skill == null;
				if (!flag2)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					bool flag3 = mainObject != null;
					if (flag3)
					{
						Point point = new Point(mainObject.x, mainObject.y - mainObject.hOne / 2);
						bool flag4 = this.x < point.x;
						if (flag4)
						{
							point.dis = 2;
						}
						else
						{
							point.dis = 0;
						}
						this.VecEff.addElement(point);
					}
				}
			}
		}
		else
		{
			int num = -15;
			bool flag5 = this.Dir == 2;
			if (flag5)
			{
				num = 15;
			}
			this.x += num;
			this.y -= 10;
		}
	}

	// Token: 0x060002A1 RID: 673 RVA: 0x00053E98 File Offset: 0x00052098
	public void createKurobi_2()
	{
		this.fraImgEff = new FrameImage(144, 37, 55);
		this.fRemove = 30;
		this.x1000 = -25;
		this.y1000 = -25;
		bool flag = this.Dir == 2;
		if (flag)
		{
			this.x1000 = 25;
		}
		this.vx = (this.toX - (this.x + this.x1000)) / 5;
		GameScreen.addEffectEnd(30, 0, this.x, this.y, 300, this.Dir, this.objMainEff);
	}

	// Token: 0x060002A2 RID: 674 RVA: 0x00053F2C File Offset: 0x0005212C
	public void createUrgot3()
	{
		this.fRemove = 40;
		this.fraImgEff = new FrameImage(179, 54, 25);
		for (int i = 0; i < 5; i++)
		{
			Point point = new Point();
			point.y = -CRes.random(30);
			point.vy = CRes.random_Am(3, 8);
			point.frame = CRes.random(3);
			this.VecEff.addElement(point);
		}
	}

	// Token: 0x060002A3 RID: 675 RVA: 0x00053FA4 File Offset: 0x000521A4
	public void createXerath3()
	{
		this.xplus = 4;
		this.yplus = 6;
		int num = 0;
		for (int i = 1; i <= this.yplus; i++)
		{
			num -= i * this.xplus;
		}
		this.fraImgEff = new FrameImage(83, 14, 14);
		this.fraImgSubEff = new FrameImage(51, 9, 9);
		this.fraImgSub2Eff = new FrameImage(52, 5, 5);
		this.x = this.objFireMain.x;
		this.y = this.objFireMain.y - this.objFireMain.hOne / 2;
		this.x1000 = this.x * 1000;
		this.y1000 = this.y;
		int num2 = num - (this.toY - this.y);
		int num3 = this.yplus - 1;
		bool flag = num2 < 0;
		if (flag)
		{
			for (int j = 1; j < 60; j++)
			{
				num2 += j * this.xplus;
				bool flag2 = num2 >= 0;
				if (flag2)
				{
					num3 += j;
					break;
				}
			}
		}
		this.vy1000 = -(this.xplus * this.yplus);
		this.vx1000 = (this.toX - this.x) * 1000 / num3;
		this.fRemove = num3;
	}

	// Token: 0x060002A4 RID: 676 RVA: 0x00054100 File Offset: 0x00052300
	public void createZoroS3_L2_New()
	{
		this.fraImgEff = new FrameImage(165, 27, 50);
		this.fraImgSubEff = new FrameImage(167, 78, 22);
		this.fraImgSub2Eff = new FrameImage(166, 50, 60);
		this.fRemove = 36;
		this.vMax = 12;
		bool flag = this.isAddSound;
		if (flag)
		{
			mSound.playSound(8, mSound.volumeSound);
		}
		GameScreen.addEffectEnd(30, 0, this.x, this.y, 500, this.Dir, this.objMainEff);
		int num = -15;
		this.x1000 = this.x + 15;
		this.y1000 = this.objFireMain.y - 22;
		bool flag2 = this.Dir == 2;
		if (flag2)
		{
			num = 15;
			this.x1000 = this.x - 63;
		}
		this.x += num;
		this.y -= 5;
	}

	// Token: 0x060002A5 RID: 677 RVA: 0x000541FC File Offset: 0x000523FC
	public void createZoroS3_L1_New()
	{
		this.fraImgEff = new FrameImage(165, 27, 50);
		this.fRemove = 30;
		bool flag = this.isAddSound;
		if (flag)
		{
			mSound.playSound(8, mSound.volumeSound);
		}
		GameScreen.addEffectEnd(30, 0, this.x, this.y, 400, this.Dir, this.objMainEff);
		int num = -15;
		bool flag2 = this.Dir == 2;
		if (flag2)
		{
			num = 15;
		}
		this.x += num;
		this.y -= 5;
	}

	// Token: 0x060002A6 RID: 678 RVA: 0x00054298 File Offset: 0x00052498
	public void createMonster_NEM_BOOM_2()
	{
		this.fraImgEff = new FrameImage(188, 9, 16);
		this.vMax = 12;
		this.y = this.objFireMain.y - this.objBeFireMain.hOne / 2;
		bool flag = this.Dir == 0;
		if (flag)
		{
			this.x -= 15;
		}
		else
		{
			this.x += 15;
		}
		int xdich = this.toX - this.x;
		int ydich = this.toY - this.y;
		base.create_Speed(xdich, ydich, null);
	}

	// Token: 0x060002A7 RID: 679 RVA: 0x00054338 File Offset: 0x00052538
	public void createUssopS2_Le_New()
	{
		this.vMax = 12;
		this.fRemove = 34;
		GameScreen.addEffectEnd(30, 0, this.x + this.am_duong * 25, this.y - 5, 400, this.Dir, this.objMainEff);
		this.fraImgEff = new FrameImage(185, 55, 25);
		bool flag = this.typeEffect == 193;
		if (flag)
		{
			this.fraImgSubEff = new FrameImage(285, 111, 90);
			this.mframe = new int[]
			{
				0,
				1,
				2,
				1
			};
		}
		else
		{
			bool flag2 = this.typeEffect == 225;
			if (flag2)
			{
				this.fRemove = 40;
				this.fraImgEff = new FrameImage(333, 55, 25);
				this.fraImgSubEff = new FrameImage(332, 111, 90);
				this.mframe = new int[]
				{
					0,
					1,
					2,
					1
				};
			}
			else
			{
				bool flag3 = this.typeEffect == 302;
				if (flag3)
				{
					this.fraImgEff = new FrameImage(419, 2);
					this.fraImgSubEff = new FrameImage(404, 3);
					this.mframe = new int[]
					{
						0,
						1,
						2,
						1
					};
					this.fraImgSub3Eff = new FrameImage(405, 3);
					int num = this.x - 50 * this.am_duong;
					int xdich = num - this.x;
					int ydich = 0;
					this.VecEff.addElement(base.create_Speed(xdich, ydich, new Point_Focus(), this.x, this.y, num, this.y));
				}
				else
				{
					this.fraImgSubEff = new FrameImage(184, 111, 70, 79, 50);
					this.mframe = new int[]
					{
						0,
						1
					};
				}
			}
		}
		this.fraImgSub2Eff = new FrameImage(251, 52, 21);
	}

	// Token: 0x060002A8 RID: 680 RVA: 0x0005452C File Offset: 0x0005272C
	public void createUssopSkill1_Lv3_New()
	{
		this.fraImgEff = new FrameImage(53, 9, 9);
		this.fraImgSubEff = new FrameImage(183, 20, 54);
		this.vMax = 24;
		this.fRemove = 25;
		this.y -= 6;
		bool flag = this.Dir == 0;
		if (flag)
		{
			this.x -= 30;
		}
		else
		{
			this.x += 30;
		}
		int xdich = this.toX - this.x;
		int ydich = this.toY - this.y;
		Point_Focus point_Focus = new Point_Focus();
		point_Focus = base.create_Speed(xdich, ydich, point_Focus);
		point_Focus.frame = 1;
		GameScreen.addEffectEnd(1, 0, this.x, this.y, this.Dir, this.objMainEff);
		this.VecEff.addElement(point_Focus);
		this.xArchor = this.objFireMain.x;
		this.yArchor = this.objFireMain.y;
	}

	// Token: 0x060002A9 RID: 681 RVA: 0x00054630 File Offset: 0x00052830
	public void createUssopSkill1_Lv3_SHORT()
	{
		this.fraImgEff = new FrameImage(53, 9, 9);
		this.fraImgSubEff = new FrameImage(183, 20, 54);
		this.vMax = 24;
		this.fRemove = 16;
		this.y -= 6;
		bool flag = this.Dir == 0;
		if (flag)
		{
			this.x -= 30;
		}
		else
		{
			this.x += 30;
		}
		int xdich = this.toX - this.x;
		int ydich = this.toY - this.y;
		Point_Focus point_Focus = new Point_Focus();
		point_Focus = base.create_Speed(xdich, ydich, point_Focus);
		point_Focus.frame = 1;
		GameScreen.addEffectEnd(1, 0, this.x, this.y, this.Dir, this.objMainEff);
		this.VecEff.addElement(point_Focus);
		this.xArchor = this.objFireMain.x;
		this.yArchor = this.objFireMain.y;
	}

	// Token: 0x060002AA RID: 682 RVA: 0x00054734 File Offset: 0x00052934
	public void createSanji_s2_l3_New()
	{
		this.y = this.objFireMain.y;
		this.fraImgEff = new FrameImage(183, 20, 54);
		this.fRemove = 44;
		GameScreen.addEffectEnd(30, 0, this.x, this.y - this.objFireMain.hOne / 2, 300, this.Dir, this.objMainEff);
	}

	// Token: 0x060002AB RID: 683 RVA: 0x000099F3 File Offset: 0x00007BF3
	public void createSanji_s2_l3_New_SHORT()
	{
		this.y = this.objFireMain.y;
		this.fraImgEff = new FrameImage(183, 20, 54);
		this.fRemove = 24;
	}

	// Token: 0x060002AC RID: 684 RVA: 0x000547A4 File Offset: 0x000529A4
	public void createSanji_s1_l3_New()
	{
		this.fraImgEff = new FrameImage(183, 20, 54);
		bool flag = this.typeEffect == 177;
		if (flag)
		{
			this.fraImgEff = new FrameImage(265, 20, 54);
		}
		this.fRemove = 50;
		GameScreen.addEffectEnd(30, 0, this.x, this.y, 300, this.Dir, this.objMainEff);
	}

	// Token: 0x060002AD RID: 685 RVA: 0x00009A23 File Offset: 0x00007C23
	public void createSanji_s1_l3_SHORT()
	{
		this.fraImgEff = new FrameImage(183, 20, 54);
		this.fRemove = 16;
	}

	// Token: 0x060002AE RID: 686 RVA: 0x0005481C File Offset: 0x00052A1C
	public bool checkNullObject(int type)
	{
		bool flag = type == 1 && (this.objFireMain == null || this.objFireMain.returnAction());
		bool result;
		if (flag)
		{
			result = true;
		}
		else
		{
			bool flag2 = type == 2 && (this.objBeFireMain == null || this.objBeFireMain.returnAction());
			if (flag2)
			{
				result = true;
			}
			else
			{
				bool flag3 = type == 3 && (this.objFireMain == null || this.objFireMain.returnAction() || this.objBeFireMain == null || this.objBeFireMain.returnAction());
				result = flag3;
			}
		}
		return result;
	}

	// Token: 0x060002AF RID: 687 RVA: 0x000548B8 File Offset: 0x00052AB8
	public Point createPointCausu1(Point p)
	{
		p.x = this.x + this.am_duong * (5 + CRes.random_Am_0(20));
		p.y = this.y - 10 + CRes.random_Am_0(25);
		p.vx = this.am_duong * CRes.random(7, 18);
		p.fRe = CRes.random(2, 5);
		p.frame = CRes.random(this.fraImgEff.nFrame);
		p.dis = (int)this.Dir;
		return p;
	}

	// Token: 0x060002B0 RID: 688 RVA: 0x00054944 File Offset: 0x00052B44
	public void create_Sanji_Sea_Lv3()
	{
		this.fraImgEff = new FrameImage(183, 20, 54);
		this.fraImgSubEff = new FrameImage(8, 40, 47, 40, 47);
		this.fRemove = 40;
		this.y = this.objFireMain.y;
	}

	// Token: 0x060002B1 RID: 689 RVA: 0x00054994 File Offset: 0x00052B94
	public void create_Devil_FIRE1()
	{
		this.addSoundBuff();
		bool flag = this.typeEffect == 259 || this.typeEffect == 260 || this.typeEffect == 261;
		if (flag)
		{
			bool flag2 = this.typeEffect == 259;
			if (flag2)
			{
				this.frameSuper = 1;
			}
			else
			{
				bool flag3 = this.typeEffect == 260;
				if (flag3)
				{
					this.frameSuper = 2;
				}
				else
				{
					bool flag4 = this.typeEffect == 261;
					if (flag4)
					{
						this.frameSuper = 3;
					}
				}
			}
			this.fraImgSubEff = new FrameImage(336, 74, 30, 3, this.frameSuper);
			this.fraImgSub2Eff = new FrameImage(78, 22, 28, 5, this.frameSuper);
			this.fraImgEff = new FrameImage(7, 34, 64, 2, this.frameSuper);
		}
		else
		{
			this.fraImgEff = new FrameImage(7, 34, 64, 2);
			bool flag5 = this.typeEffect == 228;
			if (flag5)
			{
				this.fraImgSubEff = new FrameImage(336, 74, 30, 3);
				this.fraImgSub2Eff = new FrameImage(78, 22, 28, 5);
			}
		}
		this.fRemove = 30;
		GameScreen.addEffectEnd(30, 0, this.x, this.y, 250, this.Dir, this.objMainEff);
		this.toY = this.objBeFireMain.y;
	}

	// Token: 0x060002B2 RID: 690 RVA: 0x00054B08 File Offset: 0x00052D08
	public void create_Devil_FIRE2()
	{
		this.addSoundBuff();
		this.frameSuper = 0;
		bool flag = this.typeEffect == 262;
		if (flag)
		{
			this.frameSuper = 1;
		}
		else
		{
			bool flag2 = this.typeEffect == 263;
			if (flag2)
			{
				this.frameSuper = 2;
			}
			else
			{
				bool flag3 = this.typeEffect == 264;
				if (flag3)
				{
					this.frameSuper = 3;
				}
			}
		}
		this.fraImgEff = new FrameImage(32, 45, 45, 5, this.frameSuper);
		this.fraImgSubEff = new FrameImage(78, 22, 28, 5, this.frameSuper);
		this.fraImgSub2Eff = new FrameImage(224, 22, 28, 5, this.frameSuper);
		this.fraImgSub3Eff = new FrameImage(38, 50, 80, 3, this.frameSuper);
		this.fRemove = 30;
		this.vMax = 12;
		this.y = this.objFireMain.y;
		GameScreen.addEffectEnd(30, 0, this.x, this.y - this.objFireMain.hOne / 2, 1200, this.Dir, this.objMainEff);
	}

	// Token: 0x060002B3 RID: 691 RVA: 0x00054C30 File Offset: 0x00052E30
	public void create_ho_den_vu_tru()
	{
		Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(0);
		bool flag = object_Effect_Skill != null;
		if (flag)
		{
			MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
			bool flag2 = mainObject != null;
			if (flag2)
			{
				this.x = mainObject.x;
				this.y = mainObject.y;
			}
		}
		for (int i = 0; i < this.radian.Length; i++)
		{
			GameScreen.addEffectEnd(166, 0, 2 * (CRes.getcos(this.radian[i]) * this.CR) / 1024 + this.x, CRes.getsin(this.radian[i]) * this.CR / 1024 + this.y, this.Dir, this.objMainEff);
		}
	}

	// Token: 0x060002B4 RID: 692 RVA: 0x00054D0C File Offset: 0x00052F0C
	public void create_Devil_ICE1()
	{
		this.addSoundBuff();
		this.fraImgEff = new FrameImage(37, 31, 74);
		this.fraImgSub2Eff = new FrameImage(40, 63, 20);
		this.fraImgSub3Eff = new FrameImage(41, 40, 40);
		this.y = this.objFireMain.y;
		GameScreen.addEffectEnd(30, 0, this.x, this.y - this.objFireMain.hOne / 2, 1200, this.Dir, this.objMainEff);
		this.mframe = new int[]
		{
			-1,
			-1,
			-1,
			-1,
			0,
			0,
			0,
			0,
			1,
			1,
			1,
			1,
			2,
			2,
			2,
			2,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			2,
			2,
			2,
			2,
			1,
			1,
			1,
			0,
			0,
			0
		};
		this.fRemove = 30;
	}

	// Token: 0x060002B5 RID: 693 RVA: 0x00054DBC File Offset: 0x00052FBC
	public void create_Devil_ICE2()
	{
		this.addSoundBuff();
		this.fraImgEff = new FrameImage(5, 80, 50);
		this.fraImgSub3Eff = new FrameImage(41, 40, 40);
		this.fraImgSubEff = new FrameImage(43, 84, 110);
		this.plusxy = new int[3][];
		this.plusxy[0] = new int[2];
		this.plusxy[1] = new int[2];
		this.plusxy[2] = new int[2];
		this.plusxy[0][0] = -40;
		this.plusxy[0][1] = (int)(-35 + this.objFireMain.lechYHead);
		this.plusxy[1][0] = 20;
		this.plusxy[1][1] = -67;
		this.plusxy[2][0] = 47;
		this.plusxy[2][1] = (int)(-50 + this.objFireMain.lechYHead);
		this.fRemove = 30;
		this.vMax = 10;
		this.y = this.objFireMain.y;
		GameScreen.addEffectEnd(30, 0, this.x, this.y - this.objFireMain.hOne / 2, 1200, this.Dir, this.objMainEff);
	}

	// Token: 0x060002B6 RID: 694 RVA: 0x00054EF0 File Offset: 0x000530F0
	public void create_Devil_Smoker1()
	{
		this.addSoundBuff();
		this.fraImgEff = new FrameImage(58, 40, 27);
		this.fraImgSubEff = new FrameImage(57, 42, 50, 32, 38);
		this.fraImgSub2Eff = new FrameImage(61, 24, 30);
		bool flag = this.typeEffect == 232;
		if (flag)
		{
			this.fraImgSub3Eff = new FrameImage(85, 34, 34, 28, 28);
		}
		this.fRemove = 30;
		this.vMax = 12;
	}

	// Token: 0x060002B7 RID: 695 RVA: 0x00054F74 File Offset: 0x00053174
	public void create_Devil_Smoker2()
	{
		this.addSoundBuff();
		this.fraImgEff = new FrameImage(64, 50, 45);
		this.fraImgSubEff = new FrameImage(63, 71, 60, 50, 40);
		this.fraImgSub2Eff = new FrameImage(65, 59, 65);
		this.fraImgSub3Eff = new FrameImage(61, 24, 30);
		bool flag = this.typeEffect == 234;
		if (flag)
		{
			this.fraImgSub4Eff = new FrameImage(85, 34, 34, 28, 28);
		}
		this.fRemove = 30;
		this.vMax = 26;
	}

	// Token: 0x060002B8 RID: 696 RVA: 0x0005500C File Offset: 0x0005320C
	public void createSmoker1()
	{
		this.fraImgEff = new FrameImage(64, 50, 45);
		this.fraImgSubEff = new FrameImage(63, 71, 60, 51, 43);
		this.fraImgSub2Eff = new FrameImage(86, 32, 79);
		this.fraImgSub3Eff = new FrameImage(61, 24, 30);
		GameScreen.addEffectEnd(30, 0, this.x, this.y, 100, this.Dir, this.objMainEff);
		this.fRemove = 20;
		this.vMax = 26;
	}

	// Token: 0x060002B9 RID: 697 RVA: 0x00055098 File Offset: 0x00053298
	public void createSmoker2()
	{
		this.fraImgEff = new FrameImage(86, 32, 79);
		this.fraImgSubEff = new FrameImage(87, 35, 35, 28, 28);
		GameScreen.addEffectEnd(30, 0, this.x, this.y, 100, this.Dir, this.objMainEff);
		this.frame = 5;
		bool flag = this.Dir == 2;
		if (flag)
		{
			this.frame = 6;
		}
		this.fRemove = 20;
		this.vMax = 14;
	}

	// Token: 0x060002BA RID: 698 RVA: 0x00009A42 File Offset: 0x00007C42
	public void createZoro_S2_L1_New()
	{
		this.fRemove = 6;
	}

	// Token: 0x060002BB RID: 699 RVA: 0x00009A4C File Offset: 0x00007C4C
	private void createMissGold_1()
	{
		this.fraImgEff = new FrameImage(212, 33, 24);
		this.fRemove = 24;
	}

	// Token: 0x060002BC RID: 700 RVA: 0x0005511C File Offset: 0x0005331C
	private void createMr3_2()
	{
		this.fraImgEff = new FrameImage(211, 35, 22);
		this.fraImgSubEff = new FrameImage(32, 45, 45, 34, 34);
		this.fraImgSub2Eff = new FrameImage(160, 9, 14);
		this.fRemove = 20;
		this.vMax = 16;
	}

	// Token: 0x060002BD RID: 701 RVA: 0x00055178 File Offset: 0x00053378
	private void createMr3_1()
	{
		this.fraImgEff = new FrameImage(211, 35, 22);
		GameScreen.addEffectEnd(30, 0, this.x, this.y, 300, this.Dir, this.objMainEff);
		this.fRemove = 20;
		this.vMax = 16;
	}

	// Token: 0x060002BE RID: 702 RVA: 0x000551D0 File Offset: 0x000533D0
	private void create_Wapol4()
	{
		this.fraImgEff = new FrameImage(20, 10, 10);
		bool flag = this.Dir == 0;
		if (flag)
		{
			this.x -= 25;
			this.vx = -48;
		}
		else
		{
			this.x += 25;
			this.vx = 48;
		}
		this.y += 7;
		this.x1000 = this.x;
		this.fRemove = 20;
	}

	// Token: 0x060002BF RID: 703 RVA: 0x00055254 File Offset: 0x00053454
	private void createWapol3()
	{
		this.fraImgEff = new FrameImage(20, 10, 10);
		bool flag = this.Dir == 0;
		if (flag)
		{
			this.x -= 5;
		}
		else
		{
			this.x += 5;
		}
		this.y += 7;
		this.fRemove = 25;
		this.vMax = 14;
	}

	// Token: 0x060002C0 RID: 704 RVA: 0x000552C0 File Offset: 0x000534C0
	private void createWapol2()
	{
		this.fraImgEff = new FrameImage(209, 32, 46);
		bool flag = this.Dir == 0;
		if (flag)
		{
			this.x -= 10;
		}
		else
		{
			this.x += 10;
		}
		this.y -= 5;
		this.numNextFrame = 2;
		this.vy = -3;
		this.fRemove = 4;
	}

	// Token: 0x060002C1 RID: 705 RVA: 0x00055338 File Offset: 0x00053538
	private void createWapol()
	{
		this.levelPaint = -1;
		this.fraImgEff = new FrameImage(208, 50, 57);
		this.fraImgSubEff = new FrameImage(144, 37, 55);
		this.vMax = 14;
		this.y = this.objFireMain.y;
		this.toY = this.objBeFireMain.y;
		bool flag = this.objFireMain.plashNow != null;
		if (flag)
		{
			this.objFireMain.plashNow.setIsNextf(1);
		}
		int xdich = this.toX - this.x;
		int ydich = this.toY - this.y;
		base.create_Speed(xdich, ydich, null);
	}

	// Token: 0x060002C2 RID: 706 RVA: 0x000553EC File Offset: 0x000535EC
	private void createKuromarimo()
	{
		this.fraImgEff = new FrameImage(207, 14, 14);
		this.vMax = 14;
		bool flag = this.Dir == 0;
		if (flag)
		{
			this.x -= 5;
		}
		else
		{
			this.x += 5;
		}
		this.y -= 20;
		bool flag2 = CRes.random(2) == 0;
		if (flag2)
		{
			this.subType = 0;
			this.toX += 6;
		}
		else
		{
			this.subType = 1;
			this.toX -= 6;
		}
		bool flag3 = !this.checkNullObject(2);
		if (flag3)
		{
			this.toY = this.objBeFireMain.y - this.objBeFireMain.hOne / 2;
		}
		this.toY += 14;
		int xdich = this.toX - this.x;
		int ydich = this.toY - this.y;
		base.create_Speed(xdich, ydich, null);
	}

	// Token: 0x060002C3 RID: 707 RVA: 0x000554F8 File Offset: 0x000536F8
	private void createChess()
	{
		this.fraImgEff = new FrameImage(205, 20, 20);
		this.fraImgSubEff = new FrameImage(206, 20, 20);
		this.vMax = 18;
		bool flag = this.Dir == 0;
		if (flag)
		{
			this.x -= 10;
		}
		else
		{
			this.x += 10;
		}
		this.y -= 10;
		int num = this.toX - this.x;
		int num2 = this.toY - this.y;
		int frameAngle = CRes.angle(num, num2);
		base.create_Speed(num, num2, null);
		this.frame = base.setFrameAngle(frameAngle);
	}

	// Token: 0x060002C4 RID: 708 RVA: 0x000555B4 File Offset: 0x000537B4
	private void createZoroLv3()
	{
		this.Dir = (sbyte)this.objFireMain.type_left_right;
		bool flag = this.typeEffect == 185 || this.typeEffect == 217;
		if (flag)
		{
			this.fraImgEff = new FrameImage(280, 50, 74, 2);
		}
		else
		{
			this.fraImgEff = new FrameImage(165, 27, 50);
		}
		this.fraImgSubEff = new FrameImage(167, 78, 22);
		this.fraImgSub2Eff = new FrameImage(16, 55, 55);
		this.fraImgSub3Eff = new FrameImage(17, 55, 55);
		this.fraImgSub4Eff = new FrameImage(8, 40, 47, 40, 47);
		this.fRemove = 30;
		this.vMax = 12;
		bool flag2 = this.typeEffect == 283;
		if (flag2)
		{
			this.fraImgEff = new FrameImage(421, 50, 74, 2);
			this.fraImgSub2Eff = new FrameImage(409, 4);
		}
		int num = -15;
		this.xArchor = this.objFireMain.x;
		this.yArchor = this.objFireMain.y;
		this.x1000 = this.x - 5;
		this.y1000 = this.objFireMain.y - 22;
		this.objFireMain.dy = 0;
		bool flag3 = this.Dir == 2;
		if (flag3)
		{
			num = 15;
			this.x1000 = this.x - 73;
		}
		this.x += num;
		this.y -= 5;
	}

	// Token: 0x060002C5 RID: 709 RVA: 0x00009A6B File Offset: 0x00007C6B
	private void createZoro_New2_SHORT()
	{
		this.fRemove = 24;
		this.vMax = 12;
		this.fraImgEff = new FrameImage(8, 40, 47, 40, 47);
	}

	// Token: 0x060002C6 RID: 710 RVA: 0x000090B5 File Offset: 0x000072B5
	private void beginUpdate()
	{
	}

	// Token: 0x060002C7 RID: 711 RVA: 0x00055748 File Offset: 0x00053948
	public void updateLuffy1()
	{
		bool flag = this.objBeFireMain != null && this.f % 3 == 0 && this.indexObjBefire < this.vecObjsBeFire.size();
		if (flag)
		{
			Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(this.indexObjBefire);
			this.indexObjBefire++;
			bool flag2 = object_Effect_Skill != null;
			if (flag2)
			{
				MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
				bool flag3 = mainObject != null;
				if (flag3)
				{
					sbyte dir = 0;
					bool flag4 = this.objFireMain.x < mainObject.x;
					if (flag4)
					{
						dir = 2;
					}
					int num = 12;
					bool flag5 = this.Dir == 0;
					if (flag5)
					{
						num = -12;
					}
					sbyte b = 0;
					bool flag6 = this.typeEffect == 37;
					if (flag6)
					{
						b = 2;
					}
					GameScreen.addEffectEnd_ObjTo(13, (int)b, this.objFireMain.x + num, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 3 * 2 + 10, mainObject.ID, mainObject.typeObject, dir, this.objMainEff);
				}
			}
		}
		bool flag7 = this.f >= this.fRemove;
		if (flag7)
		{
			bool flag8 = this.VecEff.size() == 0;
			if (flag8)
			{
				this.removeEff();
			}
		}
		else
		{
			bool flag9 = this.typeEffect == 37 && this.f % 2 == 0;
			if (flag9)
			{
				Point o = new Point(this.x + CRes.random_Am_0(15), this.y + CRes.random_Am_0(20));
				this.VecEff.addElement(o);
			}
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point = (Point)this.VecEff.elementAt(i);
			point.f++;
			bool flag10 = point.f >= 3;
			if (flag10)
			{
				this.VecEff.removeElement(point);
				i--;
			}
		}
	}

	// Token: 0x060002C8 RID: 712 RVA: 0x0005597C File Offset: 0x00053B7C
	public void updateSanji1()
	{
		bool flag = this.f == 1;
		if (flag)
		{
			bool flag2 = this.isAddSound;
			if (flag2)
			{
				mSound.playSound(16, mSound.volumeSound);
			}
			int num = 15;
			bool flag3 = this.Dir == 0;
			if (flag3)
			{
				num = -15;
			}
			GameScreen.addEffectEnd(30, 0, this.x + num, this.y - this.objFireMain.hOne / 2, 300, this.Dir, this.objMainEff);
		}
		bool flag4 = this.f == 8 && this.objFireMain != null;
		if (flag4)
		{
			int num2 = 27;
			bool flag5 = this.Dir == 0;
			if (flag5)
			{
				num2 = -27;
			}
			bool flag6 = this.typeEffect == 47 || this.typeEffect == 48;
			if (flag6)
			{
				sbyte b = 0;
				bool flag7 = this.typeEffect == 48;
				if (flag7)
				{
					b = 1;
				}
				bool flag8 = !this.checkNullObject(2);
				if (flag8)
				{
					GameScreen.addEffectEnd_ObjTo(37, (int)b, this.x + num2, this.y - this.objFireMain.hOne / 2, this.objBeFireMain.ID, this.objBeFireMain.typeObject, this.Dir, this.objMainEff);
				}
			}
		}
		bool flag9 = this.f >= this.fRemove;
		if (flag9)
		{
			this.objFireMain.dx = 0;
			this.removeEff();
		}
	}

	// Token: 0x060002C9 RID: 713 RVA: 0x00055AF4 File Offset: 0x00053CF4
	public void updateZoro1()
	{
		bool flag = !this.checkNullObject(1);
		if (flag)
		{
			this.objFireMain.isTanHinh = true;
			this.objFireMain.Action = 2;
			this.objFireMain.vx = this.vx;
		}
		bool flag2 = this.f >= this.fRemove;
		if (flag2)
		{
			bool flag3 = !this.checkNullObject(1);
			if (flag3)
			{
				this.objFireMain.isTanHinh = false;
				this.objFireMain.Action = 0;
			}
			GameScreen.addEffectEnd(86, 0, this.x + ((this.Dir != 0) ? -20 : 20), this.y, this.Dir, this.objMainEff);
			GameScreen.addEffectEnd(9, 0, this.toX, this.toY + 25, this.Dir, this.objMainEff);
			this.removeEff();
		}
	}

	// Token: 0x060002CA RID: 714 RVA: 0x00055BD8 File Offset: 0x00053DD8
	public void updateZoro2()
	{
		bool flag = this.f < 2;
		if (flag)
		{
			this.xplus = -3 + this.f * 3;
		}
		bool flag2 = this.f == 4;
		if (flag2)
		{
			bool flag3 = !this.checkNullObject(1) && this.objFireMain == GameScreen.player;
			if (flag3)
			{
				this.sendMove(this.x, this.toX, this.y, this.toY + this.fraImgEff.frameHeight / 2);
			}
			this.xplus = 0;
			this.x = this.toX;
			this.y = this.toY;
		}
		bool flag4 = this.f > 5;
		if (flag4)
		{
			this.xplus = 3 - (this.f - 5) * 3;
		}
		bool flag5 = this.f < this.fRemove;
		if (!flag5)
		{
			bool flag6 = !this.checkNullObject(1);
			if (flag6)
			{
				this.objFireMain.isTanHinh = false;
				bool flag7 = this.objFireMain.plashNow != null;
				if (flag7)
				{
					this.objFireMain.plashNow.setIsNextf(0);
				}
			}
			bool flag8 = !this.checkNullObject(2);
			if (flag8)
			{
				GameScreen.addEffectEnd(9, 0, this.objBeFireMain.x, this.objBeFireMain.y + 25, this.Dir, this.objMainEff);
			}
			GameScreen.addEffectEnd(86, 0, this.x + ((this.Dir != 0) ? 10 : -10), this.y - 25, this.Dir, this.objMainEff);
			this.removeEff();
		}
	}

	// Token: 0x060002CB RID: 715 RVA: 0x00055D7C File Offset: 0x00053F7C
	public void updateUssopSea1()
	{
		bool flag = (this.f == 8 || this.f == 12) && this.isAddSound;
		if (flag)
		{
			mSound.playSound(25, mSound.volumeSound);
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(i);
			point_Focus.update_Vx_Vy();
			bool flag2 = point_Focus.f >= point_Focus.fRe;
			if (flag2)
			{
				this.VecEff.removeElement(point_Focus);
				GameScreen.addEffectEnd(1, 0, point_Focus.toX, point_Focus.toY, this.Dir, this.objMainEff);
				i--;
			}
		}
		bool flag3 = this.f == 10 || this.f == 13 || this.f == 15;
		if (flag3)
		{
			bool flag4 = !this.checkNullObject(2);
			if (flag4)
			{
				this.toX = this.objBeFireMain.x;
				this.toY = this.objBeFireMain.y - this.objBeFireMain.hOne / 2 + CRes.random_Am_0(8);
			}
			base.setAngle();
			bool flag5 = !this.checkNullObject(1);
			if (flag5)
			{
				this.objFireMain.Dir = (int)this.Dir;
			}
			int num = this.toX - this.x;
			int num2 = this.toY - this.y;
			int frameAngle = CRes.angle(num, num2);
			Point_Focus point_Focus2 = new Point_Focus();
			point_Focus2 = base.create_Speed(num, num2, point_Focus2);
			point_Focus2.frame = base.setFrameAngle(frameAngle);
			this.VecEff.addElement(point_Focus2);
			GameScreen.addEffectEnd(3, 0, this.x, this.y, this.Dir, this.objMainEff);
			GameScreen.addEffectEnd(93, 2, this.x, this.y, this.Dir, this.objMainEff);
		}
		bool flag6 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag6)
		{
			this.removeEff();
		}
	}

	// Token: 0x060002CC RID: 716 RVA: 0x00055FA4 File Offset: 0x000541A4
	public void updateUssopSea2()
	{
		bool flag = (this.f == 8 || this.f == 12) && this.isAddSound;
		if (flag)
		{
			mSound.playSound(25, mSound.volumeSound);
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(i);
			point_Focus.update_Vx_Vy();
			bool flag2 = point_Focus.f >= point_Focus.fRe;
			if (flag2)
			{
				GameScreen.addEffectEnd(81, 0, point_Focus.toX, point_Focus.toY, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(1, 0, point_Focus.toX, point_Focus.toY, this.Dir, this.objMainEff);
				this.VecEff.removeElement(point_Focus);
				i--;
			}
		}
		bool flag3 = this.f == 4 || this.f == 9 || this.f == 14 || this.f == 19;
		if (flag3)
		{
			bool flag4 = !this.checkNullObject(3);
			if (flag4)
			{
				this.toX = this.objBeFireMain.x;
				this.toY = this.objBeFireMain.y - this.objBeFireMain.hOne / 2 + CRes.random_Am_0(8);
				this.y = this.objFireMain.y - this.objFireMain.hOne / 2 - 6;
				bool flag5 = this.Dir == 0;
				if (flag5)
				{
					this.x = this.objFireMain.x - 22;
				}
				else
				{
					this.x = this.objFireMain.x + 22;
				}
			}
			GameScreen.addEffectEnd(3, 0, this.x, this.y, this.Dir, this.objMainEff);
			base.setAngle();
			bool flag6 = !this.checkNullObject(1);
			if (flag6)
			{
				this.objFireMain.Dir = (int)this.Dir;
			}
			int num = 1;
			bool flag7 = this.f == 9 || this.f == 19;
			if (flag7)
			{
				num = 2;
			}
			for (int j = 0; j < num; j++)
			{
				bool flag8 = j == 1;
				if (flag8)
				{
					this.y -= 10;
				}
				int num2 = this.toX - this.x;
				int num3 = this.toY - this.y;
				int frameAngle = CRes.angle(num2, num3);
				Point_Focus point_Focus2 = new Point_Focus();
				point_Focus2 = base.create_Speed(num2, num3, point_Focus2);
				point_Focus2.frame = base.setFrameAngle(frameAngle);
				this.VecEff.addElement(point_Focus2);
			}
		}
		bool flag9 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag9)
		{
			this.removeEff();
		}
	}

	// Token: 0x060002CD RID: 717 RVA: 0x00056298 File Offset: 0x00054498
	public void updateUssopSea3()
	{
		bool flag = (this.f == 4 || this.f == 8 || this.f == 12 || this.f == 16) && this.isAddSound;
		if (flag)
		{
			mSound.playSound(25, mSound.volumeSound);
			bool flag2 = this.f == 8 || this.f == 16;
			if (flag2)
			{
				mSound.playSound(15, mSound.volumeSound);
			}
		}
		bool flag3 = this.f == 10 && !this.checkNullObject(2);
		if (flag3)
		{
			GameScreen.addEffectEnd(108, 1, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(i);
			point_Focus.update_Vx_Vy();
			bool flag4 = point_Focus.f >= point_Focus.fRe;
			if (flag4)
			{
				this.VecEff.removeElement(point_Focus);
				i--;
			}
		}
		bool flag5 = this.f > 4 && this.f % 3 == 0 && this.f <= 19;
		if (flag5)
		{
			GameScreen.addEffectEnd(3, 0, this.x, this.y, this.Dir, this.objMainEff);
			int num = CRes.random(6, 9);
			for (int j = 0; j < num; j++)
			{
				Point_Focus point_Focus2 = new Point_Focus();
				point_Focus2.x = this.x * 10;
				point_Focus2.y = this.y * 10;
				point_Focus2.vx = this.vMax * 10 * this.am_duong + CRes.random_Am_0(7);
				point_Focus2.vy = -(num * 13) / 2 + 13 * j;
				point_Focus2.frame = 0;
				point_Focus2.fRe = 16;
				point_Focus2.dis = (int)this.Dir;
				this.VecEff.addElement(point_Focus2);
			}
			this.addVir(5, 5, 10, true);
		}
		bool flag6 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag6)
		{
			this.removeEff();
		}
	}

	// Token: 0x060002CE RID: 718 RVA: 0x00056504 File Offset: 0x00054704
	public void updateUssop2()
	{
		bool flag = this.f == 3;
		if (flag)
		{
			GameScreen.addEffectEnd(3, 0, this.x, this.y, this.Dir, this.objMainEff);
		}
		int a = 12;
		bool flag2 = (this.f == 0 || this.f == 3) && this.isAddSound;
		if (flag2)
		{
			mSound.playSound(21, mSound.volumeSound);
		}
		bool flag3 = this.f == this.fRemove - 2;
		if (flag3)
		{
			GameScreen.addEffectEnd(1, 0, this.toX + CRes.random_Am_0(a), this.toY + CRes.random_Am_0(a), this.Dir, this.objMainEff);
			GameScreen.addEffectEnd(93, 1, this.toX + CRes.random_Am_0(a), this.toY + CRes.random_Am_0(a), this.Dir, this.objMainEff);
		}
		bool flag4 = this.f >= this.fRemove;
		if (flag4)
		{
			GameScreen.addEffectEnd(1, 0, this.toX + CRes.random_Am_0(a), this.toY + CRes.random_Am_0(a), this.Dir, this.objMainEff);
			GameScreen.addEffectEnd(93, 1, this.toX + CRes.random_Am_0(a), this.toY + CRes.random_Am_0(a), this.Dir, this.objMainEff);
			this.removeEff();
		}
	}

	// Token: 0x060002CF RID: 719 RVA: 0x00056664 File Offset: 0x00054864
	public void updateUssop_Skill2()
	{
		bool flag = this.f == 3 && this.isAddSound;
		if (flag)
		{
			mSound.playSound(20, mSound.volumeSound);
		}
		bool flag2 = this.f == 1;
		if (flag2)
		{
			GameScreen.addEffectEnd(5, 0, this.x, this.y, this.Dir, this.objMainEff);
		}
		bool flag3 = this.f < this.fRemove;
		if (!flag3)
		{
			int a = 12;
			GameScreen.addEffectEnd(1, 0, this.toX + CRes.random_Am_0(a), this.toY + CRes.random_Am_0(a), this.Dir, this.objMainEff);
			bool flag4 = this.typeEffect == 64;
			if (flag4)
			{
				bool flag5 = this.isAddSound;
				if (flag5)
				{
					mSound.playSound(19, mSound.volumeSound);
				}
				GameScreen.addEffectEnd(12, 1, this.toX + CRes.random_Am_0(a), this.toY + CRes.random_Am_0(a), this.Dir, this.objMainEff);
			}
			else
			{
				bool flag6 = this.typeEffect == 66;
				if (flag6)
				{
					bool flag7 = this.isAddSound;
					if (flag7)
					{
						mSound.playSound(14, mSound.volumeSound);
					}
					base.setAva(1, this.objBeFireMain);
					GameScreen.addEffectEnd(4, 2, this.toX + CRes.random_Am_0(a), this.toY + CRes.random_Am_0(a), this.Dir, this.objMainEff);
				}
			}
			GameScreen.addEffectEnd(93, 2, this.toX + CRes.random_Am_0(a), this.toY + CRes.random_Am_0(a), this.Dir, this.objMainEff);
			this.removeEff();
		}
	}

	// Token: 0x060002D0 RID: 720 RVA: 0x0005680C File Offset: 0x00054A0C
	public void updateNami1()
	{
		bool flag = this.f <= 1;
		if (!flag)
		{
			for (int i = 0; i < this.VecEff.size(); i++)
			{
				Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(i);
				point_Focus.update_Vx_Vy();
				bool flag2 = point_Focus.f < point_Focus.fRe;
				if (!flag2)
				{
					bool flag3 = this.isAddSound;
					if (flag3)
					{
						mSound.playSound(19, mSound.volumeSound);
					}
					base.setAva(1, this.objBeFireMain);
					sbyte subtype = 0;
					bool flag4 = this.typeEffect == 9;
					if (flag4)
					{
						GameScreen.addEffectEnd(3, 0, this.toX, this.toY, this.Dir, this.objMainEff);
					}
					else
					{
						bool flag5 = this.typeEffect == 53;
						if (flag5)
						{
							GameScreen.addEffectEnd(38, 1, this.toX, this.toY, this.Dir, this.objMainEff);
							subtype = 1;
						}
						else
						{
							bool flag6 = this.typeEffect == 163;
							if (flag6)
							{
								bool flag7 = this.isAddSound;
								if (flag7)
								{
									mSound.playSound(17, mSound.volumeSound);
								}
								this.addVir(5, 5, 10, true);
								GameScreen.addEffectEnd(42, 0, this.toX, this.toY, this.Dir, this.objMainEff);
								subtype = 1;
							}
						}
					}
					GameScreen.addEffectEnd(6, (int)subtype, this.toX, this.toY, this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(93, 1, this.toX, this.toY, this.Dir, this.objMainEff);
					this.VecEff.removeElement(point_Focus);
					i--;
				}
			}
			bool flag8 = this.VecEff.size() == 0;
			if (flag8)
			{
				this.removeEff();
			}
		}
	}

	// Token: 0x060002D1 RID: 721 RVA: 0x000569F0 File Offset: 0x00054BF0
	public void updateNami1_SHORT()
	{
		bool flag = this.f == 12 || this.f == 22;
		if (flag)
		{
			this.y += 5;
			int num = 0;
			int xdich = this.toX - this.x;
			int ydich = this.toY - num - this.y;
			Point_Focus point_Focus = new Point_Focus();
			point_Focus = base.create_Speed(xdich, ydich, point_Focus);
			bool flag2 = this.f == 22;
			if (flag2)
			{
				point_Focus.frame = 1;
			}
			this.VecEff.addElement(point_Focus);
			bool flag3 = this.isAddSound;
			if (flag3)
			{
				mSound.playSound(18, mSound.volumeSound);
			}
		}
		bool flag4 = this.typeEffect == 222 || this.typeEffect == 312;
		if (flag4)
		{
			for (int i = 0; i < this.VecSubEff.size(); i++)
			{
				Point point = (Point)this.VecSubEff.elementAt(i);
				point.f++;
				bool flag5 = point.f / 2 >= this.fraImgSub3Eff.nFrame;
				if (flag5)
				{
					this.VecSubEff.removeElementAt(i);
					i--;
				}
			}
		}
		bool flag6 = this.f > 1;
		if (flag6)
		{
			for (int j = 0; j < this.VecEff.size(); j++)
			{
				Point_Focus point_Focus2 = (Point_Focus)this.VecEff.elementAt(j);
				bool flag7 = (this.typeEffect == 222 || this.typeEffect == 312) && !GameCanvas.lowGraphic;
				if (flag7)
				{
					Point o = new Point(point_Focus2.x, point_Focus2.y);
					this.VecSubEff.addElement(o);
				}
				point_Focus2.update_Vx_Vy();
				bool flag8 = point_Focus2.f <= point_Focus2.fRe;
				if (!flag8)
				{
					bool flag9 = this.isAddSound;
					if (flag9)
					{
						mSound.playSound(19, mSound.volumeSound);
					}
					base.setAva(1, this.objBeFireMain);
					sbyte subtype = 1;
					bool flag10 = this.typeEffect == 190;
					if (flag10)
					{
						subtype = 2;
					}
					else
					{
						bool flag11 = this.typeEffect == 222 || this.typeEffect == 312;
						if (flag11)
						{
							subtype = 3;
						}
					}
					bool flag12 = this.isAddSound;
					if (flag12)
					{
						mSound.playSound(17, mSound.volumeSound);
					}
					this.addVir(5, 5, 10, true);
					bool flag13 = point_Focus2.frame == 1;
					if (flag13)
					{
						int subtype2 = 2;
						bool flag14 = this.typeEffect == 190 || this.typeEffect == 222 || this.typeEffect == 312;
						if (flag14)
						{
							subtype2 = 8;
							GameScreen.addEffectEnd(108, 3, this.toX, this.toY, this.Dir, this.objMainEff);
						}
						GameScreen.addEffectEnd(54, subtype2, this.toX, this.toY, this.Dir, this.objMainEff);
					}
					else
					{
						bool flag15 = !GameCanvas.lowGraphic;
						if (flag15)
						{
							bool flag16 = this.typeEffect == 222;
							if (flag16)
							{
								GameScreen.addEffectEnd(139, 0, this.toX, this.toY, this.Dir, this.objMainEff);
							}
							bool flag17 = this.typeEffect == 312;
							if (flag17)
							{
								GameScreen.addEffectEnd(139, 1, this.objBeFireMain.x, this.objBeFireMain.y, this.Dir, this.objMainEff);
							}
						}
					}
					GameScreen.addEffectEnd(42, 0, this.toX, this.toY, this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(6, (int)subtype, this.toX, this.toY, this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(108, 8, this.toX, this.toY, this.Dir, this.objMainEff);
					this.VecEff.removeElement(point_Focus2);
					j--;
				}
			}
		}
		bool flag18 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag18)
		{
			this.removeEff();
		}
	}

	// Token: 0x060002D2 RID: 722 RVA: 0x00056E64 File Offset: 0x00055064
	public void updateNamiSea1()
	{
		bool flag = this.f == 4 && this.isAddSound;
		if (flag)
		{
			mSound.playSound(18, mSound.volumeSound);
		}
		bool flag2 = this.f == 10 && !this.checkNullObject(2);
		if (flag2)
		{
			int xdich = this.objBeFireMain.x - this.x;
			int ydich = this.objBeFireMain.y - this.y;
			Point_Focus point_Focus = new Point_Focus();
			point_Focus = base.create_Speed(xdich, ydich, point_Focus);
			this.VecEff.addElement(point_Focus);
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus2 = (Point_Focus)this.VecEff.elementAt(i);
			point_Focus2.update_Vx_Vy();
			bool flag3 = point_Focus2.f >= point_Focus2.fRe;
			if (flag3)
			{
				this.VecEff.removeElement(point_Focus2);
				i--;
			}
		}
		bool flag4 = this.f < this.fRemove || this.VecEff.size() != 0;
		if (!flag4)
		{
			bool flag5 = !this.checkNullObject(2);
			if (flag5)
			{
				bool flag6 = this.isAddSound;
				if (flag6)
				{
					mSound.playSound(19, mSound.volumeSound);
				}
				GameScreen.addEffectEnd(8, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(93, 1, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
			}
			this.removeEff();
		}
	}

	// Token: 0x060002D3 RID: 723 RVA: 0x0005703C File Offset: 0x0005523C
	public void updateNamiSea2()
	{
		bool flag = this.f == 8 && this.isAddSound;
		if (flag)
		{
			mSound.playSound(18, mSound.volumeSound);
		}
		bool flag2 = this.f >= 2 && this.f <= 16;
		if (flag2)
		{
			bool flag3 = !this.checkNullObject(1);
			if (flag3)
			{
				this.objFireMain.isPaintWeapon = false;
			}
		}
		else
		{
			this.objFireMain.isPaintWeapon = true;
		}
		bool flag4 = this.f == 14 && !this.checkNullObject(2);
		if (flag4)
		{
			int xdich = this.objBeFireMain.x - this.x;
			int ydich = this.objBeFireMain.y - this.y;
			Point_Focus point_Focus = new Point_Focus();
			point_Focus = base.create_Speed(xdich, ydich, point_Focus);
			this.VecEff.addElement(point_Focus);
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus2 = (Point_Focus)this.VecEff.elementAt(i);
			point_Focus2.update_Vx_Vy();
			bool flag5 = point_Focus2.f >= point_Focus2.fRe;
			if (flag5)
			{
				this.VecEff.removeElement(point_Focus2);
				i--;
			}
		}
		bool flag6 = this.f < this.fRemove || this.VecEff.size() != 0;
		if (!flag6)
		{
			bool flag7 = !this.checkNullObject(2);
			if (flag7)
			{
				bool flag8 = this.isAddSound;
				if (flag8)
				{
					mSound.playSound(19, mSound.volumeSound);
				}
				GameScreen.addEffectEnd(41, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(8, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
			}
			this.removeEff();
		}
	}

	// Token: 0x060002D4 RID: 724 RVA: 0x00057264 File Offset: 0x00055464
	public void updateNamiSea3()
	{
		bool flag = this.f == 2 && this.isAddSound;
		if (flag)
		{
			mSound.playSound(18, mSound.volumeSound);
		}
		bool flag2 = this.f >= 2 && this.f <= 16;
		if (flag2)
		{
			bool flag3 = !this.checkNullObject(1);
			if (flag3)
			{
				this.objFireMain.isPaintWeapon = false;
			}
		}
		else
		{
			this.objFireMain.isPaintWeapon = true;
		}
		bool flag4 = this.f >= 24 && this.f <= 34 && !this.checkNullObject(2) && CRes.random(4) != 0;
		if (flag4)
		{
			int num = CRes.random(1, 3);
			for (int i = 0; i < num; i++)
			{
				int x = CRes.random_Am(0, 25) + this.objBeFireMain.x;
				GameScreen.addEffectEnd(90, 1, x, this.objBeFireMain.y - 10, this.Dir, this.objMainEff);
			}
		}
		for (int j = 0; j < this.VecEff.size(); j++)
		{
			Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(j);
			point_Focus.update_Vx_Vy();
			bool flag5 = point_Focus.f >= point_Focus.fRe;
			if (flag5)
			{
				this.VecEff.removeElement(point_Focus);
				j--;
			}
		}
		bool flag6 = (this.f == 10 || this.f == 16) && !this.checkNullObject(3);
		if (flag6)
		{
			int xdich = this.objBeFireMain.x - this.x;
			int ydich = this.objBeFireMain.y - 60 - this.y;
			Point_Focus point_Focus2 = new Point_Focus();
			point_Focus2 = base.create_Speed(xdich, ydich, point_Focus2, this.x, this.objFireMain.y - this.objFireMain.hOne / 2, this.objBeFireMain.x, this.objBeFireMain.y - 70);
			point_Focus2.frame = 1;
			this.VecEff.addElement(point_Focus2);
		}
		bool flag7 = this.f < this.fRemove || this.VecEff.size() != 0;
		if (!flag7)
		{
			bool flag8 = !this.checkNullObject(2);
			if (flag8)
			{
				bool flag9 = this.isAddSound;
				if (flag9)
				{
					mSound.playSound(17, mSound.volumeSound);
				}
				this.addVir(5, 5, 10, true);
				GameScreen.addEffectEnd(41, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(8, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(108, 8, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
			}
			this.removeEff();
		}
	}

	// Token: 0x060002D5 RID: 725 RVA: 0x000575B0 File Offset: 0x000557B0
	public void updateSanji2()
	{
		bool flag = this.f == 4;
		if (flag)
		{
			this.addVir(5, 5, 10, true);
		}
		bool flag2 = this.f >= 6 && this.f <= this.fRemove;
		if (flag2)
		{
			bool flag3 = !this.checkNullObject(1) && CRes.random(2) == 0;
			if (flag3)
			{
				this.objFireMain.dx = CRes.random_Am_0(2);
				this.xplus = this.objFireMain.dx;
			}
			bool flag4 = this.f % 3 == 0;
			if (flag4)
			{
				bool flag5 = this.isAddSound;
				if (flag5)
				{
					mSound.playSound(15, mSound.volumeSound);
				}
				bool flag6 = this.indexObjBefire < this.vecObjsBeFire.size();
				if (flag6)
				{
					Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(this.indexObjBefire);
					this.indexObjBefire++;
					bool flag7 = object_Effect_Skill != null;
					if (flag7)
					{
						MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
						bool flag8 = mainObject != null;
						if (flag8)
						{
							int xdich = mainObject.x - this.x;
							int ydich = mainObject.y - this.objFireMain.hOne / 2 - this.y;
							Point_Focus point_Focus = new Point_Focus();
							int y = this.y;
							this.y += CRes.random_Am_0(15);
							point_Focus = base.create_Speed(xdich, ydich, point_Focus);
							this.y = y;
							point_Focus.dis = 1;
							point_Focus.maxdis = 0;
							bool flag9 = this.typeEffect == 220 || this.typeEffect == 293;
							if (flag9)
							{
								point_Focus.maxdis = 5;
							}
							point_Focus.frame = this.indexObjBefire % 2;
							this.VecEff.addElement(point_Focus);
						}
					}
				}
				else
				{
					bool flag10 = !GameCanvas.lowGraphic;
					if (flag10)
					{
						this.indexObjBefire++;
						int xdich2 = this.am_duong * 140 + CRes.random_Am_0(20);
						int ydich2 = CRes.random_Am_0(80);
						Point_Focus point_Focus2 = new Point_Focus();
						int y2 = this.y;
						this.y += CRes.random_Am_0(15);
						point_Focus2 = base.create_Speed(xdich2, ydich2, point_Focus2);
						this.y = y2;
						point_Focus2.dis = 0;
						bool flag11 = this.typeEffect == 220 || this.typeEffect == 293;
						if (flag11)
						{
							point_Focus2.maxdis = 5;
						}
						point_Focus2.frame = this.indexObjBefire % 2;
						this.VecEff.addElement(point_Focus2);
					}
				}
			}
		}
		bool flag12 = this.f >= this.fRemove && this.VecSubEff.size() == 0;
		if (flag12)
		{
			bool flag13 = !this.checkNullObject(1);
			if (flag13)
			{
				this.objFireMain.dx = 0;
			}
			this.removeEff();
		}
		for (int i = 0; i < this.VecSubEff.size(); i++)
		{
			Point point = (Point)this.VecSubEff.elementAt(i);
			point.f++;
			bool flag14 = point.f >= this.fraImgSub3Eff.nFrame;
			if (flag14)
			{
				this.VecSubEff.removeElement(point);
				i--;
			}
		}
		for (int j = 0; j < this.VecEff.size(); j++)
		{
			Point_Focus point_Focus3 = (Point_Focus)this.VecEff.elementAt(j);
			point_Focus3.update_Vx_Vy();
			Point point2 = new Point(point_Focus3.x, point_Focus3.y);
			point2.frame = point_Focus3.frame;
			this.VecSubEff.addElement(point2);
			bool flag15 = point_Focus3.f == point_Focus3.fRe && point_Focus3.dis == 1;
			if (flag15)
			{
				GameScreen.addEffectEnd(35, 0, point_Focus3.x, point_Focus3.y, this.Dir, this.objMainEff);
				int subtype = 7;
				bool flag16 = this.typeEffect == 293;
				if (flag16)
				{
					subtype = 0;
				}
				GameScreen.addEffectEnd(108, subtype, point_Focus3.x, point_Focus3.y, this.Dir, this.objMainEff);
			}
			bool flag17 = point_Focus3.f >= point_Focus3.fRe + point_Focus3.maxdis;
			if (flag17)
			{
				this.VecEff.removeElement(point_Focus3);
				j--;
			}
		}
	}

	// Token: 0x060002D6 RID: 726 RVA: 0x00057A6C File Offset: 0x00055C6C
	public void updateRankyaku()
	{
		bool flag = this.f >= 3 && this.isAddSound;
		if (flag)
		{
			mSound.playSound(13, mSound.volumeSound);
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			bool flag2 = this.f > 3 + i * 4;
			if (flag2)
			{
				Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(i);
				point_Focus.update_Vx_Vy();
				bool flag3 = i == 0 & point_Focus.f == point_Focus.fRe;
				if (flag3)
				{
					GameScreen.addEffectEnd(19, 0, point_Focus.toX, point_Focus.toY, this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(108, 8, point_Focus.toX, point_Focus.toY, this.Dir, this.objMainEff);
				}
				bool flag4 = point_Focus.f >= point_Focus.fRe + 15;
				if (flag4)
				{
					this.VecEff.removeElementAt(i);
					i--;
				}
			}
		}
		bool flag5 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag5)
		{
			GameScreen.addEffectEnd(1, 0, this.toX, this.toY, this.Dir, this.objMainEff);
			this.removeEff();
		}
	}

	// Token: 0x060002D7 RID: 727 RVA: 0x00057BCC File Offset: 0x00055DCC
	public void updateSoi()
	{
		bool flag = this.f >= 2 && this.isAddSound;
		if (flag)
		{
			mSound.playSound(13, mSound.volumeSound);
		}
		this.x1000 = this.x + 30 * this.am_duong;
		int xdich = this.x1000 - this.x;
		bool flag2 = this.f == 2;
		if (flag2)
		{
			this.VecEff.addElement(base.create_Speed(xdich, -8, new Point_Focus(), this.x1000, this.y, this.toX, this.toY));
			this.VecEff.addElement(base.create_Speed(xdich, 8, new Point_Focus(), this.x1000, this.y, this.toX, this.toY));
		}
		bool flag3 = this.f == 4;
		if (flag3)
		{
			this.VecEff.addElement(base.create_Speed(xdich, 0, new Point_Focus(), this.x1000, this.y, this.toX, this.toY));
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(i);
			point_Focus.update_Vx_Vy();
			bool flag4 = i == 0 & point_Focus.f == point_Focus.fRe;
			if (flag4)
			{
				GameScreen.addEffectEnd(123, 3, point_Focus.toX, point_Focus.toY, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(108, 3, point_Focus.toX, point_Focus.toY, this.Dir, this.objMainEff);
			}
			bool flag5 = point_Focus.f >= point_Focus.fRe + 25;
			if (flag5)
			{
				this.VecEff.removeElementAt(i);
				i--;
			}
		}
		bool flag6 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag6)
		{
			GameScreen.addEffectEnd(1, 0, this.toX, this.toY, this.Dir, this.objMainEff);
			this.removeEff();
		}
	}

	// Token: 0x060002D8 RID: 728 RVA: 0x00057E00 File Offset: 0x00056000
	public void updateSoi2()
	{
		bool flag = this.f >= 2 && this.isAddSound;
		if (flag)
		{
			mSound.playSound(13, mSound.volumeSound);
		}
		this.x1000 = this.x + 30 * this.am_duong;
		int xdich = this.x1000 - this.x;
		bool flag2 = this.f == 2;
		if (flag2)
		{
			this.VecEff.addElement(base.create_Speed(xdich, -14, new Point_Focus(), this.x1000, this.y, this.toX, this.toY));
			this.VecEff.addElement(base.create_Speed(xdich, 14, new Point_Focus(), this.x1000, this.y, this.toX, this.toY));
		}
		bool flag3 = this.f == 4;
		if (flag3)
		{
			this.VecEff.addElement(base.create_Speed(xdich, -8, new Point_Focus(), this.x1000, this.y, this.toX, this.toY));
			this.VecEff.addElement(base.create_Speed(xdich, 8, new Point_Focus(), this.x1000, this.y, this.toX, this.toY));
		}
		bool flag4 = this.f == 6;
		if (flag4)
		{
			this.VecEff.addElement(base.create_Speed(xdich, 0, new Point_Focus(), this.x1000, this.y, this.toX, this.toY));
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(i);
			point_Focus.update_Vx_Vy();
			bool flag5 = i == 0 & point_Focus.f == point_Focus.fRe;
			if (flag5)
			{
				GameScreen.addEffectEnd(19, 0, point_Focus.toX, point_Focus.toY, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(108, 7, point_Focus.toX, point_Focus.toY, this.Dir, this.objMainEff);
			}
			bool flag6 = point_Focus.f >= point_Focus.fRe + 25;
			if (flag6)
			{
				this.VecEff.removeElementAt(i);
				i--;
			}
		}
		bool flag7 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag7)
		{
			GameScreen.addEffectEnd(1, 0, this.toX, this.toY, this.Dir, this.objMainEff);
			this.removeEff();
		}
	}

	// Token: 0x060002D9 RID: 729 RVA: 0x000580A8 File Offset: 0x000562A8
	public void updateHuou()
	{
		bool flag = this.f >= 4 && this.isAddSound;
		if (flag)
		{
			mSound.playSound(13, mSound.volumeSound);
		}
		bool flag2 = this.f == 5;
		if (flag2)
		{
			GameScreen.addEffectEnd(19, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point = (Point)this.VecEff.elementAt(i);
			point.x += point.vx;
			point.y += point.vy;
			bool flag3 = point.y < 40;
			if (!flag3)
			{
				bool flag4 = i >= this.size1;
				if (flag4)
				{
					this.VecEff.removeElementAt(i);
					i--;
				}
				else
				{
					this.createPointHuou(point);
					Point point2 = new Point();
					point2.x = CRes.random_Am_0(40);
					point2.y = CRes.random_Am_0(30);
					point2.dis = 5;
					bool flag5 = this.typeEffect == 279;
					if (flag5)
					{
						point2.dis = CRes.random(10);
					}
					point2.frame = 0;
					point2.maxframe = 3;
					this.VecSubEff.addElement(point2);
				}
			}
		}
		for (int j = 0; j < this.VecSubEff.size(); j++)
		{
			Point point3 = (Point)this.VecSubEff.elementAt(j);
			point3.frame++;
			bool flag6 = point3.frame >= point3.maxframe;
			if (flag6)
			{
				this.VecSubEff.removeElementAt(j);
				j--;
			}
		}
		bool flag7 = this.f >= this.fRemove;
		if (flag7)
		{
			this.removeEff();
		}
	}

	// Token: 0x060002DA RID: 730 RVA: 0x000582C4 File Offset: 0x000564C4
	public void updateShigan()
	{
		bool flag = this.f > 2;
		if (flag)
		{
			for (int i = 0; i < this.VecEff.size(); i++)
			{
				Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(0);
				point_Focus.update_Vx_Vy();
				bool flag2 = this.f == 4;
				if (flag2)
				{
					GameScreen.addEffectEnd(35, 0, point_Focus.toX, point_Focus.toY, this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(108, 5, point_Focus.toX, point_Focus.toY, this.Dir, this.objMainEff);
				}
			}
		}
		bool flag3 = this.f >= this.fRemove;
		if (flag3)
		{
			GameScreen.addEffectEnd(1, 0, this.toX, this.toY, this.Dir, this.objMainEff);
			this.removeEff();
		}
	}

	// Token: 0x060002DB RID: 731 RVA: 0x000583B0 File Offset: 0x000565B0
	public void updateDoor()
	{
		bool flag = this.f == 1;
		if (flag)
		{
			this.x1000 = this.x;
		}
		bool flag2 = this.f == 15;
		if (flag2)
		{
			this.x1000 = this.objBeFireMain.x + 40 * this.am_duong;
		}
		bool flag3 = this.f == 6;
		if (flag3)
		{
			this.objFireMain.isTanHinh = true;
			GameScreen.addEffectEnd(80, 0, this.objFireMain.x, this.y, this.Dir, this.objMainEff);
		}
		bool flag4 = this.f == 20;
		if (flag4)
		{
			this.objFireMain.x = this.x1000;
			this.changeDir();
			this.objFireMain.Dir = (int)this.Dir;
			GameScreen.addEffectEnd(80, 0, this.objFireMain.x, this.y, this.Dir, this.objMainEff);
			this.objFireMain.isTanHinh = false;
		}
		bool flag5 = this.f == 23;
		if (flag5)
		{
			GameScreen.addEffectEnd(123, 2, this.objBeFireMain.x, this.y, this.Dir, this.objMainEff);
		}
		bool flag6 = this.f >= this.fRemove;
		if (flag6)
		{
			this.removeEff();
		}
	}

	// Token: 0x060002DC RID: 732 RVA: 0x00058508 File Offset: 0x00056708
	private void addPoint(int x, int y)
	{
		Point point = new Point();
		point.x = x;
		point.y = y;
		this.VecEff.addElement(point);
	}

	// Token: 0x060002DD RID: 733 RVA: 0x00058538 File Offset: 0x00056738
	public void updateDoor2()
	{
		bool flag = this.f >= 2 && this.f <= 20;
		if (flag)
		{
			bool flag2 = this.f == 2;
			if (flag2)
			{
				this.addPoint(this.x, this.y);
			}
			bool flag3 = this.f == 6;
			if (flag3)
			{
				this.addPoint(this.objBeFireMain.x + 90 * this.am_duong, this.y - 60);
			}
			bool flag4 = this.f == 8;
			if (flag4)
			{
				this.addPoint(this.objBeFireMain.x - 90 * this.am_duong, this.y - 60);
			}
			bool flag5 = this.f == 12;
			if (flag5)
			{
				this.addPoint(this.objBeFireMain.x + 90 * this.am_duong, this.y + 60);
			}
			bool flag6 = this.f == 16;
			if (flag6)
			{
				this.addPoint(this.objBeFireMain.x - 90 * this.am_duong, this.y + 60);
			}
			bool flag7 = this.f == 20;
			if (flag7)
			{
				this.addPoint(this.objBeFireMain.x + 40 * this.am_duong, this.y);
			}
		}
		bool flag8 = this.f >= 4 && this.f <= 25 && (this.f - 4) % 4 == 0;
		if (flag8)
		{
			Point point = (Point)this.VecEff.elementAt((this.f - 4) / 4);
			this.objFireMain.isTanHinh = true;
			GameScreen.addEffectEnd(80, 0, point.x, point.y, this.Dir, this.objMainEff);
		}
		bool flag9 = this.f == 25;
		if (flag9)
		{
			this.objFireMain.x = this.objBeFireMain.x + 40 * this.am_duong;
			this.changeDir();
			this.objFireMain.Dir = (int)this.Dir;
			this.objFireMain.isTanHinh = false;
			GameScreen.addEffectEnd(80, 0, this.objFireMain.x, this.y, this.Dir, this.objMainEff);
		}
		bool flag10 = this.f == 23;
		if (flag10)
		{
			GameScreen.addEffectEnd(123, 2, this.objBeFireMain.x, this.y, this.Dir, this.objMainEff);
		}
		bool flag11 = this.f >= this.fRemove;
		if (flag11)
		{
			this.removeEff();
		}
	}

	// Token: 0x060002DE RID: 734 RVA: 0x000587E0 File Offset: 0x000569E0
	public void updateSanji4()
	{
		bool flag = this.objBeFireMain != null && this.objBeFireMain.hOne > 0;
		if (flag)
		{
			bool flag2 = this.f == 1 && this.isAddSound;
			if (flag2)
			{
				mSound.playSound(13, mSound.volumeSound);
			}
			bool flag3 = this.f % 4 == 0;
			if (flag3)
			{
				bool flag4 = this.typeEffect == 14;
				if (flag4)
				{
					base.setAva(0, this.objBeFireMain);
				}
				bool flag5 = !this.checkNullObject(2);
				if (flag5)
				{
					GameScreen.addEffectEnd(1, 0, this.objBeFireMain.x + CRes.random_Am_0(15), this.objBeFireMain.y - CRes.random(0, this.objBeFireMain.hOne / 4 * 3), this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(93, 2, this.objBeFireMain.x + CRes.random_Am_0(15), this.objBeFireMain.y - CRes.random(0, this.objBeFireMain.hOne / 4 * 3), this.Dir, this.objMainEff);
				}
				bool flag6 = this.typeEffect == 44;
				if (flag6)
				{
					base.setAva(1, this.objBeFireMain);
					bool flag7 = !this.checkNullObject(2);
					if (flag7)
					{
						GameScreen.addEffectEnd(1, 0, this.objBeFireMain.x + CRes.random_Am_0(15), this.objBeFireMain.y - CRes.random(0, this.objBeFireMain.hOne / 4 * 3), this.Dir, this.objMainEff);
					}
					int num = 25;
					bool flag8 = this.Dir == 0;
					if (flag8)
					{
						num = -25;
					}
					bool flag9 = !this.checkNullObject(1);
					if (flag9)
					{
						GameScreen.addEffectEnd(35, 0, this.objFireMain.x + num, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 3 * 2 + 10, this.Dir, this.objMainEff);
					}
				}
			}
		}
		bool flag10 = this.f >= this.fRemove;
		if (flag10)
		{
			this.removeEff();
		}
	}

	// Token: 0x060002DF RID: 735 RVA: 0x00058A24 File Offset: 0x00056C24
	public void updateZoroSea3()
	{
		bool flag = (this.f == 4 || this.f == 10) && !this.checkNullObject(1);
		if (flag)
		{
			GameScreen.addEffectEnd(30, 0, this.objFireMain.x, this.objFireMain.y - this.objFireMain.hOne / 2, 200, this.Dir, this.objMainEff);
		}
		bool flag2 = this.f >= 1 && this.f <= 4 && !this.checkNullObject(1);
		if (flag2)
		{
			this.objFireMain.dy = this.f * 14;
		}
		bool flag3 = this.f >= 5 && this.f <= 13 && !this.checkNullObject(1);
		if (flag3)
		{
			this.objFireMain.dy = 56;
		}
		bool flag4 = this.f >= 14 && this.f <= 17 && !this.checkNullObject(1);
		if (flag4)
		{
			this.objFireMain.dy = (17 - this.f) * 14;
		}
		bool flag5 = this.f == 5 || this.f == 11;
		if (flag5)
		{
			bool flag6 = this.isAddSound;
			if (flag6)
			{
				mSound.playSound(12, mSound.volumeSound);
			}
			int num = 20;
			bool flag7 = this.Dir == 0;
			if (flag7)
			{
				num = -20;
			}
			bool flag8 = !this.checkNullObject(1);
			if (flag8)
			{
				GameScreen.addEffectEnd(16, 0, this.x, this.objFireMain.y - this.objFireMain.hOne / 2 - 10 - this.objFireMain.dy, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(16, 1, this.x + num, this.objFireMain.y - this.objFireMain.hOne / 2 - 10 - this.objFireMain.dy, this.Dir, this.objMainEff);
			}
		}
		bool flag9 = !this.checkNullObject(3) && (this.f == 6 || this.f == 12);
		if (flag9)
		{
			this.addVir(5, 5, 10, true);
			sbyte dir = 0;
			bool flag10 = this.objFireMain.x < this.objBeFireMain.x;
			if (flag10)
			{
				dir = 2;
			}
			int num2 = 18;
			bool flag11 = this.Dir == 0;
			if (flag11)
			{
				num2 = -18;
			}
			sbyte b = 2;
			GameScreen.addEffectEnd_ObjTo(27, (int)b, this.objFireMain.x + num2, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 2, this.objBeFireMain.ID, this.objBeFireMain.typeObject, dir, this.objMainEff);
		}
		bool flag12 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag12)
		{
			bool flag13 = !this.checkNullObject(1);
			if (flag13)
			{
				this.objFireMain.dy = 0;
			}
			GameScreen.addEffectEnd(1, 0, this.toX, this.toY, this.Dir, this.objMainEff);
			this.removeEff();
		}
	}

	// Token: 0x060002E0 RID: 736 RVA: 0x00058D78 File Offset: 0x00056F78
	public void updateZoroSea1()
	{
		bool flag = this.f == 1 && !this.checkNullObject(1);
		if (flag)
		{
			GameScreen.addEffectEnd(30, 0, this.objFireMain.x, this.objFireMain.y - this.objFireMain.hOne / 2, 300, this.Dir, this.objMainEff);
		}
		bool flag2 = this.f == 11;
		if (flag2)
		{
			bool flag3 = this.isAddSound;
			if (flag3)
			{
				mSound.playSound(12, mSound.volumeSound);
			}
			int num = 20;
			bool flag4 = this.Dir == 0;
			if (flag4)
			{
				num = -20;
			}
			bool flag5 = !this.checkNullObject(1);
			if (flag5)
			{
				GameScreen.addEffectEnd(16, 0, this.x, this.objFireMain.y - this.objFireMain.hOne / 2 - 10, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(16, 1, this.x + num, this.objFireMain.y - this.objFireMain.hOne / 2 - 10, this.Dir, this.objMainEff);
			}
		}
		bool flag6 = !this.checkNullObject(3) && this.f == 12;
		if (flag6)
		{
			sbyte dir = 0;
			bool flag7 = this.objFireMain.x < this.objBeFireMain.x;
			if (flag7)
			{
				dir = 2;
			}
			int num2 = 18;
			bool flag8 = this.Dir == 0;
			if (flag8)
			{
				num2 = -18;
			}
			sbyte b = 0;
			GameScreen.addEffectEnd_ObjTo(27, (int)b, this.objFireMain.x + num2, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 2, this.objBeFireMain.ID, this.objBeFireMain.typeObject, dir, this.objMainEff);
		}
		bool flag9 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag9)
		{
			GameScreen.addEffectEnd(1, 0, this.toX, this.toY, this.Dir, this.objMainEff);
			this.removeEff();
		}
	}

	// Token: 0x060002E1 RID: 737 RVA: 0x00058FB4 File Offset: 0x000571B4
	public void updateZoroSea2()
	{
		bool flag = this.f == 7 && !this.checkNullObject(1);
		if (flag)
		{
			GameScreen.addEffectEnd(30, 0, this.objFireMain.x, this.objFireMain.y - this.objFireMain.hOne, 250, this.Dir, this.objMainEff);
		}
		bool flag2 = this.f == 4 || this.f == 16;
		if (flag2)
		{
			bool flag3 = this.isAddSound;
			if (flag3)
			{
				mSound.playSound(12, mSound.volumeSound);
			}
			bool flag4 = !this.checkNullObject(1);
			if (flag4)
			{
				int num = 20;
				bool flag5 = this.Dir == 0;
				if (flag5)
				{
					num = -20;
				}
				bool flag6 = !this.checkNullObject(1);
				if (flag6)
				{
					GameScreen.addEffectEnd(16, 0, this.x, this.objFireMain.y - this.objFireMain.hOne / 2 - 10, this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(16, 1, this.x + num, this.objFireMain.y - this.objFireMain.hOne / 2 - 10, this.Dir, this.objMainEff);
				}
			}
		}
		bool flag7 = !this.checkNullObject(3) && (this.f == 5 || this.f == 17);
		if (flag7)
		{
			sbyte dir = 0;
			bool flag8 = this.objFireMain.x < this.objBeFireMain.x;
			if (flag8)
			{
				dir = 2;
			}
			int num2 = 18;
			bool flag9 = this.Dir == 0;
			if (flag9)
			{
				num2 = -18;
			}
			sbyte b = 1;
			GameScreen.addEffectEnd_ObjTo(27, (int)b, this.objFireMain.x + num2, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 2, this.objBeFireMain.ID, this.objBeFireMain.typeObject, dir, this.objMainEff);
		}
		bool flag10 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag10)
		{
			GameScreen.addEffectEnd(1, 0, this.toX, this.toY, this.Dir, this.objMainEff);
			this.removeEff();
		}
	}

	// Token: 0x060002E2 RID: 738 RVA: 0x0005921C File Offset: 0x0005741C
	public void updateZoro3()
	{
		int num = 5;
		bool flag = this.f == 5;
		if (flag)
		{
			bool flag2 = this.isAddSound;
			if (flag2)
			{
				mSound.playSound(7, mSound.volumeSound);
			}
			int num2 = 20;
			bool flag3 = this.Dir == 0;
			if (flag3)
			{
				num2 = -20;
			}
			base.setAva(0, this.objBeFireMain);
			bool flag4 = !this.checkNullObject(2);
			if (flag4)
			{
				GameScreen.addEffectEnd(10, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(93, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
			}
			bool flag5 = !this.checkNullObject(1);
			if (flag5)
			{
				GameScreen.addEffectEnd(16, 1, this.x + num2, this.objFireMain.y - this.objFireMain.hOne / 2 - 10 + num, this.Dir, this.objMainEff);
			}
		}
		bool flag6 = this.f == 10;
		if (flag6)
		{
			bool flag7 = this.isAddSound;
			if (flag7)
			{
				mSound.playSound(7, mSound.volumeSound);
			}
			int num3 = 30;
			bool flag8 = this.Dir == 0;
			if (flag8)
			{
				num3 = -30;
			}
			base.setAva(0, this.objBeFireMain);
			bool flag9 = !this.checkNullObject(2);
			if (flag9)
			{
				GameScreen.addEffectEnd(10, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(93, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
			}
			bool flag10 = !this.checkNullObject(1);
			if (flag10)
			{
				GameScreen.addEffectEnd(16, 2, this.x + num3, this.objFireMain.y - this.objFireMain.hOne / 2 + num, this.Dir, this.objMainEff);
			}
		}
		bool flag11 = this.f == 15;
		if (flag11)
		{
			bool flag12 = this.isAddSound;
			if (flag12)
			{
				mSound.playSound(7, mSound.volumeSound);
			}
			int num4 = 20;
			bool flag13 = this.Dir == 0;
			if (flag13)
			{
				num4 = -20;
			}
			base.setAva(1, this.objBeFireMain);
			bool flag14 = !this.checkNullObject(2);
			if (flag14)
			{
				GameScreen.addEffectEnd(19, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(93, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
			}
			bool flag15 = !this.checkNullObject(1);
			if (flag15)
			{
				GameScreen.addEffectEnd(16, 1, this.x + num4, this.objFireMain.y - this.objFireMain.hOne / 2 - 10 + num, this.Dir, this.objMainEff);
			}
		}
		bool flag16 = this.f >= this.fRemove;
		if (flag16)
		{
			this.removeEff();
		}
	}

	// Token: 0x060002E3 RID: 739 RVA: 0x000595BC File Offset: 0x000577BC
	public void updateLuffy6()
	{
		bool flag = this.f >= this.fRemove || this.checkNullObject(1);
		if (flag)
		{
			this.removeEff();
			bool flag2 = this.objFireMain == GameScreen.player;
			if (flag2)
			{
				GameScreen.setIsMoveEff(false);
			}
		}
		bool flag3 = this.f < 7;
		if (flag3)
		{
			bool flag4 = this.Dir == 0;
			if (flag4)
			{
				this.objFireMain.vx = -this.objFireMain.vMax * 3;
			}
			else
			{
				this.objFireMain.vx = this.objFireMain.vMax * 3;
			}
		}
		else
		{
			this.objFireMain.vx = 0;
		}
		bool flag5 = this.f == 7;
		if (flag5)
		{
			base.setAva(1, this.objBeFireMain);
			int num = 20;
			bool flag6 = this.Dir == 0;
			if (flag6)
			{
				num = -20;
			}
			GameScreen.addEffectEnd(1, 0, this.objBeFireMain.x + CRes.random_Am_0(15), this.objBeFireMain.y - CRes.random(0, this.objBeFireMain.hOne / 4 * 3), this.Dir, this.objMainEff);
			bool flag7 = this.isAddSound;
			if (flag7)
			{
				mSound.playSound(3, mSound.volumeSound);
			}
			GameScreen.addEffectEnd(93, 0, this.objBeFireMain.x + CRes.random_Am_0(15), this.objBeFireMain.y - CRes.random(0, this.objBeFireMain.hOne / 4 * 3), this.Dir, this.objMainEff);
			GameScreen.addEffectEnd(0, 0, this.objFireMain.x + num, this.objFireMain.y - this.objFireMain.hOne / 2 + 2, this.Dir, this.objMainEff);
		}
	}

	// Token: 0x060002E4 RID: 740 RVA: 0x00059790 File Offset: 0x00057990
	public void updateLuffy_S2_L2()
	{
		bool flag = this.f >= this.fRemove || this.checkNullObject(1);
		if (flag)
		{
			this.removeEff();
			bool flag2 = this.objFireMain == GameScreen.player;
			if (flag2)
			{
				GameScreen.setIsMoveEff(false);
			}
		}
		else
		{
			bool flag3 = this.f < 6;
			if (flag3)
			{
				bool flag4 = this.Dir == 0;
				if (flag4)
				{
					this.objFireMain.vx = -this.objFireMain.vMax * 3;
				}
				else
				{
					this.objFireMain.vx = this.objFireMain.vMax * 3;
				}
				bool flag5 = this.f % 2 == 1;
				if (flag5)
				{
					Point o = new Point(this.objFireMain.x - this.objFireMain.vx / 2, this.objFireMain.y);
					this.VecEff.addElement(o);
				}
			}
			else
			{
				this.objFireMain.vx = 0;
			}
			for (int i = 0; i < this.VecEff.size(); i++)
			{
				Point point = (Point)this.VecEff.elementAt(i);
				point.f++;
				bool flag6 = point.f / 2 >= 3;
				if (flag6)
				{
					this.VecEff.removeElement(point);
					i--;
				}
			}
			bool flag7 = this.f == 6;
			if (flag7)
			{
				bool flag8 = this.isAddSound;
				if (flag8)
				{
					mSound.playSound(3, mSound.volumeSound);
				}
				base.setAva(2, this.objBeFireMain);
				int num = 20;
				bool flag9 = this.Dir == 0;
				if (flag9)
				{
					num = -20;
				}
				GameScreen.addEffectEnd(8, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objFireMain.hOne / 2, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(0, 0, this.objFireMain.x + num, this.objFireMain.y - this.objFireMain.hOne / 2 + 2, this.Dir, this.objMainEff);
			}
		}
	}

	// Token: 0x060002E5 RID: 741 RVA: 0x000599D0 File Offset: 0x00057BD0
	public void updateNami5()
	{
		bool flag = !this.checkNullObject(1);
		if (flag)
		{
			bool flag2 = this.objFireMain.Dir == 0;
			if (flag2)
			{
				this.x = this.x1000 - 20;
			}
			else
			{
				this.x = this.x1000 + 20;
			}
		}
		bool flag3 = this.f > 5 && (this.typeEffect == 55 || this.typeEffect == 31 || this.f >= 10) && this.f % 3 == 0 && this.f <= this.fRemove;
		if (flag3)
		{
			bool flag4 = this.indexObjBefire < this.vecObjsBeFire.size();
			if (flag4)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(this.indexObjBefire);
				this.indexObjBefire++;
				bool flag5 = object_Effect_Skill != null;
				if (flag5)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					bool flag6 = mainObject != null;
					if (flag6)
					{
						int num = mainObject.hOne / 2;
						bool flag7 = this.typeEffect == 56 || this.typeEffect == 191 || this.typeEffect == 223;
						if (flag7)
						{
							num = mainObject.hOne + 20;
						}
						int xdich = mainObject.x - this.x;
						int ydich = mainObject.y - num - this.y;
						Point_Focus point_Focus = new Point_Focus();
						point_Focus = base.create_Speed(xdich, ydich, point_Focus);
						point_Focus.objMain = mainObject;
						this.VecEff.addElement(point_Focus);
					}
				}
			}
			else
			{
				bool flag8 = this.typeEffect == 223 && !GameCanvas.lowGraphic;
				if (flag8)
				{
					int xdich2 = CRes.random_Am_0(100);
					int ydich2 = -50 + CRes.random_Am_0(60);
					Point_Focus point_Focus2 = new Point_Focus();
					point_Focus2 = base.create_Speed(xdich2, ydich2, point_Focus2);
					this.VecEff.addElement(point_Focus2);
				}
			}
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus3 = (Point_Focus)this.VecEff.elementAt(i);
			point_Focus3.update_Vx_Vy();
			bool flag9 = point_Focus3.f < point_Focus3.fRe;
			if (!flag9)
			{
				bool flag10 = this.isAddSound;
				if (flag10)
				{
					mSound.playSound(19, mSound.volumeSound);
				}
				bool flag11 = this.typeEffect == 31;
				if (flag11)
				{
					GameScreen.addEffectEnd(38, 0, point_Focus3.x, point_Focus3.y, this.Dir, this.objMainEff);
				}
				else
				{
					bool flag12 = this.typeEffect == 55;
					if (flag12)
					{
						GameScreen.addEffectEnd(41, 0, point_Focus3.x, point_Focus3.y, this.Dir, this.objMainEff);
					}
					else
					{
						bool flag13 = this.typeEffect == 56 || this.typeEffect == 191 || this.typeEffect == 191 || this.typeEffect == 223;
						if (flag13)
						{
							bool flag14 = this.isAddSound;
							if (flag14)
							{
								mSound.playSound(17, mSound.volumeSound);
							}
							this.addVir(5, 5, 10, true);
							sbyte subtype = 0;
							bool flag15 = this.typeEffect == 191;
							if (flag15)
							{
								subtype = 1;
							}
							else
							{
								bool flag16 = this.typeEffect == 223;
								if (flag16)
								{
									subtype = 2;
								}
							}
							bool flag17 = point_Focus3.objMain == null;
							if (flag17)
							{
								GameScreen.addEffectEnd(39, (int)subtype, point_Focus3.x, point_Focus3.y, this.Dir, this.objMainEff);
							}
							else
							{
								GameScreen.addEffectEnd_ObjTo(39, (int)subtype, point_Focus3.objMain.x, point_Focus3.objMain.y - point_Focus3.objMain.hOne - 20, point_Focus3.objMain.ID, point_Focus3.objMain.typeObject, 0, this.objMainEff);
							}
						}
					}
				}
				GameScreen.addEffectEnd(93, 1, point_Focus3.x, point_Focus3.y, this.Dir, this.objMainEff);
				this.VecEff.removeElement(point_Focus3);
				i--;
			}
		}
		bool flag18 = this.f > this.fRemove && this.VecEff.size() == 0;
		if (flag18)
		{
			this.removeEff();
		}
	}

	// Token: 0x060002E6 RID: 742 RVA: 0x00059E58 File Offset: 0x00058058
	public void updateNami6()
	{
		bool flag = !this.checkNullObject(1);
		if (flag)
		{
			bool flag2 = this.objFireMain.Dir == 0;
			if (flag2)
			{
				this.x = this.x1000 - 20;
			}
			else
			{
				this.x = this.x1000 + 20;
			}
		}
		bool flag3 = this.f == 10;
		if (flag3)
		{
			int num = this.objFireMain.hOne + 50;
			int xdich = 0;
			int ydich = -num;
			Point_Focus point_Focus = new Point_Focus();
			point_Focus = base.create_Speed(xdich, ydich, point_Focus);
			this.VecEff.addElement(point_Focus);
		}
		bool flag4 = this.f >= 10 && this.f <= 19;
		if (flag4)
		{
			int num2 = this.objFireMain.hOne + 50;
			int num3 = 100 * CRes.getcos((this.f - 10) * 360 / 10) / 1000;
			int num4 = -num2 + 30 * CRes.getsin((this.f - 10) * 360 / 10) / 1000;
			Point_Focus point_Focus2 = new Point_Focus();
			point_Focus2 = base.create_Speed(num3, num4, point_Focus2, this.x, this.y, num3 - this.x, num4 - this.y);
			point_Focus2.objMain = this.objFireMain;
			this.VecEff.addElement(point_Focus2);
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus3 = (Point_Focus)this.VecEff.elementAt(i);
			point_Focus3.update_Vx_Vy();
			bool flag5 = point_Focus3.f >= point_Focus3.fRe;
			if (flag5)
			{
				bool flag6 = this.isAddSound;
				if (flag6)
				{
					mSound.playSound(19, mSound.volumeSound);
				}
				bool flag7 = this.isAddSound;
				if (flag7)
				{
					mSound.playSound(17, mSound.volumeSound);
				}
				this.addVir(5, 5, 10, true);
				sbyte subtype = 2;
				bool flag8 = point_Focus3.objMain == null;
				if (flag8)
				{
					subtype = 3;
				}
				GameScreen.addEffectEnd(39, (int)subtype, point_Focus3.x, point_Focus3.y, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(93, 1, point_Focus3.x, point_Focus3.y, this.Dir, this.objMainEff);
				this.VecEff.removeElement(point_Focus3);
				i--;
			}
		}
		bool flag9 = this.f <= this.fRemove || this.VecEff.size() != 0;
		if (!flag9)
		{
			for (int j = 0; j < this.vecObjsBeFire.size(); j++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(j);
				bool flag10 = object_Effect_Skill != null;
				if (flag10)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					bool flag11 = mainObject != null;
					if (flag11)
					{
						GameScreen.addEffectEnd(42, 0, mainObject.x, mainObject.y - mainObject.hOne / 2, this.Dir, mainObject);
						GameScreen.addEffectEnd(41, 0, mainObject.x, mainObject.y - mainObject.hOne / 2, this.Dir, mainObject);
						GameScreen.addEffectEnd(8, 0, mainObject.x, mainObject.y - mainObject.hOne / 2, this.Dir, mainObject);
						GameScreen.addEffectEnd(108, 8, mainObject.x, mainObject.y - mainObject.hOne / 2, this.Dir, mainObject);
					}
				}
			}
			this.removeEff();
		}
	}

	// Token: 0x060002E7 RID: 743 RVA: 0x0005A220 File Offset: 0x00058420
	public void updateNami4()
	{
		bool flag = this.f == 8 && this.isAddSound;
		if (flag)
		{
			mSound.playSound(10, mSound.volumeSound);
		}
		bool flag2 = this.f >= this.fRemove;
		if (flag2)
		{
			this.removeEff();
		}
		else
		{
			bool flag3 = this.f > 4 && this.f % 5 == 0 && !this.checkNullObject(2);
			if (flag3)
			{
				bool flag4 = this.typeEffect == 16;
				if (flag4)
				{
					base.setAva(0, this.objBeFireMain);
					GameScreen.addEffectEnd(3, 0, this.objBeFireMain.x + CRes.random_Am_0(15), this.objBeFireMain.y - CRes.random(0, this.objBeFireMain.hOne / 4 * 3), this.Dir, this.objMainEff);
				}
				else
				{
					bool flag5 = this.typeEffect == 51;
					if (flag5)
					{
						base.setAva(1, this.objBeFireMain);
						GameScreen.addEffectEnd(1, 0, this.objBeFireMain.x + CRes.random_Am_0(15), this.objBeFireMain.y - CRes.random(0, this.objBeFireMain.hOne / 4 * 3), this.Dir, this.objMainEff);
					}
				}
				GameScreen.addEffectEnd(93, 1, this.objBeFireMain.x + CRes.random_Am_0(15), this.objBeFireMain.y - CRes.random(0, this.objBeFireMain.hOne / 4 * 3), this.Dir, this.objMainEff);
			}
		}
	}

	// Token: 0x060002E8 RID: 744 RVA: 0x0005A3B8 File Offset: 0x000585B8
	public void updateZoro8()
	{
		bool flag = this.f >= this.fRemove || this.checkNullObject(1);
		if (flag)
		{
			bool flag2 = !this.checkNullObject(1);
			if (flag2)
			{
				this.objFireMain.vx = 0;
				this.objFireMain.vy = 0;
				this.objFireMain.isTanHinh = false;
				bool flag3 = this.objFireMain.plashNow != null;
				if (flag3)
				{
					this.objFireMain.plashNow.setIsNextf(0);
				}
			}
			int num = 30;
			bool flag4 = this.Dir == 0;
			if (flag4)
			{
				num = -30;
			}
			bool flag5 = !this.checkNullObject(1);
			if (flag5)
			{
				bool flag6 = this.isAddSound;
				if (flag6)
				{
					mSound.playSound(9, mSound.volumeSound);
				}
				bool flag7 = this.typeEffect == 29;
				if (flag7)
				{
					base.setAva(2, this.objBeFireMain);
					GameScreen.addEffectEnd(26, 0, this.objFireMain.x + num, this.objFireMain.y - 5, this.Dir, this.objMainEff);
				}
				else
				{
					GameScreen.addEffectEnd(19, 0, this.objFireMain.x + num, this.objFireMain.y - this.objFireMain.hOne / 2, this.Dir, this.objMainEff);
					base.setAva(1, this.objBeFireMain);
				}
				GameScreen.addEffectEnd(93, 0, this.objFireMain.x + num, this.objFireMain.y - this.objFireMain.hOne / 2, this.Dir, this.objMainEff);
			}
			this.removeEff();
		}
		else
		{
			this.objFireMain.vx = this.vx;
			this.objFireMain.vy = this.vy;
			bool flag8 = LoadMap.Tile_Stand(GameCanvas.loadmap.getTile(this.objFireMain.x + this.objFireMain.vx, this.objFireMain.y + this.objFireMain.vy));
			if (flag8)
			{
				this.objFireMain.vx = 0;
				this.objFireMain.vy = 0;
			}
		}
	}

	// Token: 0x060002E9 RID: 745 RVA: 0x0005A5EC File Offset: 0x000587EC
	public void updateUssopSkill1_Lv3()
	{
		bool flag = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag)
		{
			this.removeEff();
		}
		bool flag2 = (this.f == 0 || this.f == 3) && this.isAddSound;
		if (flag2)
		{
			mSound.playSound(21, mSound.volumeSound);
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(i);
			point_Focus.update_Vx_Vy();
			bool flag3 = point_Focus.f >= point_Focus.fRe;
			if (flag3)
			{
				bool flag4 = this.isAddSound;
				if (flag4)
				{
					mSound.playSound(19, mSound.volumeSound);
				}
				bool flag5 = point_Focus.frame == 0;
				if (flag5)
				{
					GameScreen.addEffectEnd(1, 0, this.toX + CRes.random_Am_0(20), this.toY + CRes.random_Am_0(20), this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(35, 0, this.toX, this.toY, this.Dir, this.objMainEff);
				}
				else
				{
					bool flag6 = point_Focus.frame == 1;
					if (flag6)
					{
						GameScreen.addEffectEnd(1, 0, this.toX + CRes.random_Am_0(20), this.toY + CRes.random_Am_0(20), this.Dir, this.objMainEff);
						GameScreen.addEffectEnd(35, 0, this.toX, this.toY, this.Dir, this.objMainEff);
					}
				}
				this.VecEff.removeElement(point_Focus);
				i--;
			}
		}
		bool flag7 = this.f == 3;
		if (flag7)
		{
			int xdich = this.toX - this.x;
			int ydich = this.toY - this.y;
			Point_Focus point_Focus2 = new Point_Focus();
			point_Focus2 = base.create_Speed(xdich, ydich, point_Focus2);
			point_Focus2.frame = 1;
			GameScreen.addEffectEnd(1, 0, this.x, this.y, this.Dir, this.objMainEff);
			this.VecEff.addElement(point_Focus2);
		}
	}

	// Token: 0x060002EA RID: 746 RVA: 0x0005A818 File Offset: 0x00058A18
	public void updateUssopSkill1_Lv3_New()
	{
		bool flag = (this.f >= this.fRemove && this.VecEff.size() == 0) || this.checkNullObject(1);
		if (flag)
		{
			this.removeEff();
		}
		bool flag2 = (this.f == 0 || this.f == 3 || this.f == 10 || this.f == 13 || this.f == 20 || this.f == 23) && this.isAddSound;
		if (flag2)
		{
			mSound.playSound(21, mSound.volumeSound);
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(i);
			point_Focus.update_Vx_Vy();
			bool flag3 = point_Focus.f >= point_Focus.fRe;
			if (flag3)
			{
				this.addVir(5, 5, 10, true);
				bool flag4 = point_Focus.frame == 0;
				if (flag4)
				{
					GameScreen.addEffectEnd(1, 0, point_Focus.toX + CRes.random_Am_0(20), point_Focus.toY + CRes.random_Am_0(20), this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(35, 0, point_Focus.toX, point_Focus.toY, this.Dir, this.objMainEff);
				}
				else
				{
					bool flag5 = point_Focus.frame == 1;
					if (flag5)
					{
						GameScreen.addEffectEnd(1, 0, point_Focus.toX + CRes.random_Am_0(20), point_Focus.toY + CRes.random_Am_0(20), this.Dir, this.objMainEff);
						GameScreen.addEffectEnd(35, 0, point_Focus.toX, point_Focus.toY, this.Dir, this.objMainEff);
					}
				}
				this.VecEff.removeElement(point_Focus);
				i--;
			}
		}
		bool flag6 = this.f == 5 || this.f == 15;
		if (flag6)
		{
			this.objFireMain.isTanHinh = true;
		}
		bool flag7 = this.f == 7;
		if (flag7)
		{
			this.objFireMain.x -= this.am_duong * 10;
			this.objFireMain.y += CRes.random_Am(1, 2) * 20;
			this.y = this.objFireMain.y - this.objFireMain.hOne / 2;
			this.x = this.objFireMain.x;
			this.y -= 6;
			bool flag8 = this.Dir == 0;
			if (flag8)
			{
				this.x -= 30;
			}
			else
			{
				this.x += 30;
			}
		}
		bool flag9 = this.f == 9 || this.f == 19;
		if (flag9)
		{
			this.objFireMain.isTanHinh = false;
		}
		bool flag10 = this.f == 17;
		if (flag10)
		{
			this.objFireMain.x = this.xArchor;
			this.objFireMain.y = this.yArchor;
			this.y = this.objFireMain.y - this.objFireMain.hOne / 2;
			this.x = this.objFireMain.x;
			this.y -= 6;
			bool flag11 = this.Dir == 0;
			if (flag11)
			{
				this.x -= 30;
			}
			else
			{
				this.x += 30;
			}
		}
		bool flag12 = (this.f == 3 || this.f == 10 || this.f == 13 || this.f == 20 || this.f == 13) && !this.checkNullObject(3);
		if (flag12)
		{
			int num = 30;
			bool flag13 = this.Dir == 0;
			if (flag13)
			{
				num = -30;
			}
			int xdich = this.objBeFireMain.x - (this.objFireMain.x + num);
			int ydich = this.objBeFireMain.y - this.objBeFireMain.hOne / 2 - (this.objFireMain.y - this.objFireMain.hOne / 2);
			Point_Focus point_Focus2 = new Point_Focus();
			point_Focus2 = base.create_Speed(xdich, ydich, point_Focus2, this.objFireMain.x + num, this.objFireMain.y - this.objFireMain.hOne / 2, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2);
			point_Focus2.frame = 1;
			GameScreen.addEffectEnd(1, 0, this.x, this.y, this.Dir, this.objMainEff);
			this.VecEff.addElement(point_Focus2);
		}
	}

	// Token: 0x060002EB RID: 747 RVA: 0x0005ACEC File Offset: 0x00058EEC
	public void updateUssopSkill1_Lv3_SHORT()
	{
		bool flag = (this.f >= this.fRemove && this.VecEff.size() == 0) || this.checkNullObject(1);
		if (flag)
		{
			this.removeEff();
		}
		bool flag2 = (this.f == 0 || this.f == 3 || this.f == 10 || this.f == 13) && this.isAddSound;
		if (flag2)
		{
			mSound.playSound(21, mSound.volumeSound);
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(i);
			point_Focus.update_Vx_Vy();
			bool flag3 = point_Focus.f < point_Focus.fRe;
			if (!flag3)
			{
				this.addVir(5, 5, 10, true);
				bool flag4 = this.typeEffect == 192;
				if (flag4)
				{
					GameScreen.addEffectEnd(25, 4, point_Focus.toX + CRes.random_Am_0(20), point_Focus.toY + CRes.random_Am_0(20), this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(108, 7, point_Focus.toX, point_Focus.toY, this.Dir, this.objMainEff);
				}
				else
				{
					GameScreen.addEffectEnd(1, 0, point_Focus.toX + CRes.random_Am_0(20), point_Focus.toY + CRes.random_Am_0(20), this.Dir, this.objMainEff);
					bool flag5 = point_Focus.frame == 2;
					if (flag5)
					{
						GameScreen.addEffectEnd(108, 5, point_Focus.toX, point_Focus.toY, this.Dir, this.objMainEff);
					}
				}
				GameScreen.addEffectEnd(35, 0, point_Focus.toX, point_Focus.toY, this.Dir, this.objMainEff);
				this.VecEff.removeElement(point_Focus);
				i--;
			}
		}
		bool flag6 = this.f == 5 || this.f == 14;
		if (flag6)
		{
			this.objFireMain.isTanHinh = true;
		}
		bool flag7 = this.f == 7;
		if (flag7)
		{
			this.objFireMain.x -= this.am_duong * 10;
			this.objFireMain.y += CRes.random_Am(1, 2) * 20;
			this.y = this.objFireMain.y - this.objFireMain.hOne / 2;
			this.x = this.objFireMain.x;
			this.y -= 6;
			bool flag8 = this.Dir == 0;
			if (flag8)
			{
				this.x -= 30;
			}
			else
			{
				this.x += 30;
			}
		}
		bool flag9 = this.f == 15;
		if (flag9)
		{
			this.objFireMain.x = this.xArchor;
			this.objFireMain.y = this.yArchor;
			this.y = this.objFireMain.y - this.objFireMain.hOne / 2;
			this.x = this.objFireMain.x;
			this.y -= 6;
			bool flag10 = this.Dir == 0;
			if (flag10)
			{
				this.x -= 30;
			}
			else
			{
				this.x += 30;
			}
		}
		bool flag11 = this.f == 9 || this.f == 15;
		if (flag11)
		{
			this.objFireMain.isTanHinh = false;
		}
		bool flag12 = (this.f == 3 || this.f == 10 || this.f == 13) && !this.checkNullObject(3);
		if (flag12)
		{
			int num = 30;
			bool flag13 = this.Dir == 0;
			if (flag13)
			{
				num = -30;
			}
			int xdich = this.objBeFireMain.x - (this.objFireMain.x + num);
			int ydich = this.objBeFireMain.y - this.objBeFireMain.hOne / 2 - (this.objFireMain.y - this.objFireMain.hOne / 2);
			Point_Focus point_Focus2 = new Point_Focus();
			point_Focus2 = base.create_Speed(xdich, ydich, point_Focus2, this.objFireMain.x + num, this.objFireMain.y - this.objFireMain.hOne / 2, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2);
			point_Focus2.frame = 1;
			bool flag14 = this.f == 10;
			if (flag14)
			{
				point_Focus2.frame = 2;
			}
			GameScreen.addEffectEnd(1, 0, this.x, this.y, this.Dir, this.objMainEff);
			this.VecEff.addElement(point_Focus2);
		}
	}

	// Token: 0x060002EC RID: 748 RVA: 0x0005B1D8 File Offset: 0x000593D8
	public void updateUssopS1_L5()
	{
		bool flag = (this.f >= this.fRemove && this.VecEff.size() == 0) || this.checkNullObject(1);
		if (flag)
		{
			bool flag2 = this.objFireMain != null;
			if (flag2)
			{
				this.objFireMain.isTanHinh = false;
			}
			this.removeEff();
		}
		bool flag3 = (this.f == 2 || this.f == 6 || this.f == 10 || this.f == 14) && this.isAddSound;
		if (flag3)
		{
			mSound.playSound(21, mSound.volumeSound);
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(i);
			point_Focus.update_Vx_Vy();
			bool flag4 = point_Focus.f >= point_Focus.fRe;
			if (flag4)
			{
				this.addVir(5, 5, 10, true);
				sbyte subtype = 4;
				bool flag5 = point_Focus.frame == 2;
				if (flag5)
				{
					subtype = 3;
				}
				GameScreen.addEffectEnd(25, (int)subtype, point_Focus.toX + CRes.random_Am_0(20), point_Focus.toY + CRes.random_Am_0(20), this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(108, 7, point_Focus.toX, point_Focus.toY, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(35, 0, point_Focus.toX, point_Focus.toY, this.Dir, this.objMainEff);
				this.VecEff.removeElement(point_Focus);
				i--;
			}
		}
		bool flag6 = this.f == 2;
		if (flag6)
		{
			this.objFireMain.isTanHinh = true;
		}
		else
		{
			bool flag7 = this.f == 15;
			if (flag7)
			{
				this.objFireMain.isTanHinh = false;
			}
		}
		bool flag8 = this.f > 3 && this.f % 2 == 0 && !this.checkNullObject(3);
		if (flag8)
		{
			int num = 25;
			int num2 = (this.f - 2) / 2;
			bool flag9 = num2 >= this.mframeSuper.Length;
			if (flag9)
			{
				return;
			}
			bool flag10 = this.Dir == 0;
			if (flag10)
			{
				num = -25;
			}
			int xdich = this.objFireMain.x + this.mframeSuper[num2][0] - this.objBeFireMain.x + num;
			int ydich = this.objFireMain.y - this.objFireMain.hOne / 2 + this.mframeSuper[num2][0] - (this.objBeFireMain.y - this.objBeFireMain.hOne / 2);
			Point_Focus point_Focus2 = new Point_Focus();
			point_Focus2 = base.create_Speed(xdich, ydich, point_Focus2, this.objFireMain.x + this.mframeSuper[num2][0] + num, this.objFireMain.y - this.objFireMain.hOne / 2 + this.mframeSuper[num2][0], this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2);
			point_Focus2.frame = 1;
			bool flag11 = this.f == 8 || this.f == 14;
			if (flag11)
			{
				point_Focus2.frame = 2;
			}
			GameScreen.addEffectEnd(1, 0, this.objFireMain.x + this.mframeSuper[num2][0] + num, this.objFireMain.y - this.objFireMain.hOne / 2 + this.mframeSuper[num2][0] - 10, this.Dir, this.objMainEff);
			this.VecEff.addElement(point_Focus2);
		}
		bool flag12 = this.typeEffect != 301;
		if (!flag12)
		{
			for (int j = 0; j < this.VecSubEff.size(); j++)
			{
				bool flag13 = this.f > j * 4;
				if (flag13)
				{
					Point_Focus point_Focus3 = (Point_Focus)this.VecSubEff.elementAt(j);
					point_Focus3.update_Vx_Vy();
				}
			}
		}
	}

	// Token: 0x060002ED RID: 749 RVA: 0x0005B608 File Offset: 0x00059808
	public void updateUssopS1_L6()
	{
		bool flag = (this.f >= this.fRemove && this.VecEff.size() == 0) || this.checkNullObject(1);
		if (flag)
		{
			bool flag2 = this.objFireMain != null;
			if (flag2)
			{
				this.objFireMain.isTanHinh = false;
			}
			this.removeEff();
		}
		bool flag3 = (this.f == 2 || this.f == 6 || this.f == 10 || this.f == 14) && this.isAddSound;
		if (flag3)
		{
			mSound.playSound(21, mSound.volumeSound);
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(i);
			point_Focus.update_Vx_Vy();
			bool flag4 = point_Focus.f >= point_Focus.fRe;
			if (flag4)
			{
				this.addVir(5, 5, 10, true);
				sbyte subtype = 4;
				bool flag5 = point_Focus.frame == 2;
				if (flag5)
				{
					subtype = 3;
				}
				GameScreen.addEffectEnd(25, (int)subtype, point_Focus.toX + CRes.random_Am_0(20), point_Focus.toY + CRes.random_Am_0(20), this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(108, 7, point_Focus.toX, point_Focus.toY, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(35, 0, point_Focus.toX, point_Focus.toY, this.Dir, this.objMainEff);
				this.VecEff.removeElement(point_Focus);
				i--;
			}
		}
		bool flag6 = this.f == 2;
		if (flag6)
		{
			this.objFireMain.isTanHinh = true;
		}
		else
		{
			bool flag7 = this.f == 15;
			if (flag7)
			{
				this.objFireMain.isTanHinh = false;
			}
		}
		for (int j = 0; j < this.VecSubEff.size(); j++)
		{
			bool flag8 = this.f > j * 4;
			if (flag8)
			{
				Point_Focus point_Focus2 = (Point_Focus)this.VecSubEff.elementAt(j);
				point_Focus2.update_Vx_Vy();
			}
		}
		bool flag9 = this.f <= 3 || this.f % 2 != 0 || this.checkNullObject(3);
		if (!flag9)
		{
			int num = 25;
			int num2 = (this.f - 2) / 2;
			bool flag10 = num2 < this.mframeSuper.Length;
			if (flag10)
			{
				bool flag11 = this.Dir == 0;
				if (flag11)
				{
					num = -25;
				}
				int xdich = this.objFireMain.x + this.mframeSuper[num2][0] - this.objBeFireMain.x + num;
				int ydich = this.objFireMain.y - this.objFireMain.hOne / 2 + this.mframeSuper[num2][0] - (this.objBeFireMain.y - this.objBeFireMain.hOne / 2);
				Point_Focus point_Focus3 = new Point_Focus();
				point_Focus3 = base.create_Speed(xdich, ydich, point_Focus3, this.objFireMain.x + this.mframeSuper[num2][0] + num, this.objFireMain.y - this.objFireMain.hOne / 2 + this.mframeSuper[num2][0], this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2);
				point_Focus3.frame = 1;
				bool flag12 = this.f == 8 || this.f == 14;
				if (flag12)
				{
					point_Focus3.frame = 2;
				}
				GameScreen.addEffectEnd(1, 0, this.objFireMain.x + this.mframeSuper[num2][0] + num, this.objFireMain.y - this.objFireMain.hOne / 2 + this.mframeSuper[num2][0] - 10, this.Dir, this.objMainEff);
				this.VecEff.addElement(point_Focus3);
			}
		}
	}

	// Token: 0x060002EE RID: 750 RVA: 0x0005BA18 File Offset: 0x00059C18
	public void updateNamiSkill1_Lv3()
	{
		bool flag = this.f >= this.fRemove;
		if (flag)
		{
			this.removeEff();
		}
		else
		{
			bool flag2 = this.isAddSound && this.f == 8;
			if (flag2)
			{
				mSound.playSound(10, mSound.volumeSound);
			}
			bool flag3 = (this.f == 5 || this.f == 15) && this.isAddSound;
			if (flag3)
			{
				mSound.playSound(17, mSound.volumeSound);
			}
			bool flag4 = this.f == 5 && this.typeEffect == 311;
			if (flag4)
			{
				GameScreen.addEffectEnd(174, 0, this.objBeFireMain.x, this.objBeFireMain.y, this.Dir, this.objBeFireMain);
			}
			bool flag5 = this.f > 4 && this.f % 5 == 0 && this.objBeFireMain != null;
			if (flag5)
			{
				this.addVir(5, 5, 10, true);
				base.setAva(1, this.objBeFireMain);
				sbyte subtype = 1;
				bool flag6 = (this.typeEffect == 221 || this.typeEffect == 311) && CRes.random(2) == 0;
				if (flag6)
				{
					subtype = 3;
				}
				GameScreen.addEffectEnd(38, (int)subtype, this.objBeFireMain.x + CRes.random_Am_0(15), this.objBeFireMain.y - CRes.random(0, this.objBeFireMain.hOne / 4 * 3), this.Dir, this.objMainEff);
				bool flag7 = this.f == 10 || this.typeEffect == 221 || this.typeEffect == 311;
				if (flag7)
				{
					subtype = 3;
					bool flag8 = (this.typeEffect == 221 || this.typeEffect == 311) && CRes.random(2) == 0;
					if (flag8)
					{
						subtype = 8;
					}
					GameScreen.addEffectEnd(108, (int)subtype, this.objBeFireMain.x + CRes.random_Am_0(15), this.objBeFireMain.y - CRes.random(0, this.objBeFireMain.hOne / 4 * 3), this.Dir, this.objMainEff);
				}
			}
			bool flag9 = (this.typeEffect == 189 || this.typeEffect == 221 || this.typeEffect == 311) && this.f > 4 && this.f % 3 == 0 && this.objBeFireMain != null;
			if (flag9)
			{
				short type = 38;
				bool flag10 = (this.typeEffect == 221 || this.typeEffect == 311) && CRes.random(2) == 0;
				if (flag10)
				{
					type = 138;
				}
				GameScreen.addEffectEnd(type, 2, this.objBeFireMain.x + CRes.random_Am_0(15), this.objBeFireMain.y - CRes.random(0, this.objBeFireMain.hOne / 4 * 3), this.Dir, this.objMainEff);
			}
			bool flag11 = this.objFireMain != null && !GameCanvas.lowGraphic;
			if (flag11)
			{
				int num = this.x - 20;
				bool flag12 = this.Dir == 0;
				if (flag12)
				{
					num = this.x + 20;
				}
				int a = 25;
				bool flag13 = this.objFireMain.hOne > 1;
				if (flag13)
				{
					a = this.objFireMain.hOne / 2;
				}
				Point point = new Point(num + CRes.random_Am_0(20), this.y + CRes.random_Am_0(a));
				bool flag14 = (this.typeEffect == 221 || this.typeEffect == 311) && CRes.random(2) == 0;
				if (flag14)
				{
					point.frame = 1;
				}
				this.VecEff.addElement(point);
			}
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point2 = (Point)this.VecEff.elementAt(i);
			point2.f++;
			bool flag15 = point2.f >= 4;
			if (flag15)
			{
				this.VecEff.removeElement(point2);
				i--;
			}
		}
	}

	// Token: 0x060002EF RID: 751 RVA: 0x0005BE74 File Offset: 0x0005A074
	public void updateSanjiSkill3_Lv1()
	{
		bool flag = this.f >= 4;
		if (flag)
		{
			bool flag2 = this.isAddSound;
			if (flag2)
			{
				mSound.playSound(13, mSound.volumeSound);
			}
			bool flag3 = this.objFireMain != null && CRes.random(2) == 0;
			if (flag3)
			{
				this.objFireMain.dx = CRes.random_Am_0(2);
				this.xplus = this.objFireMain.dx;
			}
			bool flag4 = this.f % 2 == 0 && this.indexObjBefire < this.vecObjsBeFire.size();
			if (flag4)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(this.indexObjBefire);
				this.indexObjBefire++;
				bool flag5 = object_Effect_Skill != null;
				if (flag5)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					bool flag6 = mainObject != null;
					if (flag6)
					{
						int xdich = mainObject.x - this.x;
						int ydich = mainObject.y - this.objFireMain.hOne / 2 - this.y;
						Point_Focus point_Focus = new Point_Focus();
						point_Focus = base.create_Speed(xdich, ydich, point_Focus);
						point_Focus.frame = CRes.random(6);
						this.VecEff.addElement(point_Focus);
					}
				}
			}
		}
		bool flag7 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag7)
		{
			bool flag8 = this.objFireMain != null;
			if (flag8)
			{
				this.objFireMain.dx = 0;
			}
			this.removeEff();
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus2 = (Point_Focus)this.VecEff.elementAt(i);
			point_Focus2.update_Vx_Vy();
			bool flag9 = point_Focus2.f >= point_Focus2.fRe;
			if (flag9)
			{
				bool flag10 = this.typeEffect == 49;
				if (flag10)
				{
					GameScreen.addEffectEnd(1, 0, point_Focus2.x, point_Focus2.y, this.Dir, this.objMainEff);
				}
				else
				{
					bool flag11 = this.typeEffect == 50;
					if (flag11)
					{
						GameScreen.addEffectEnd(35, 0, point_Focus2.x, point_Focus2.y, this.Dir, this.objMainEff);
					}
				}
				GameScreen.addEffectEnd(93, 2, point_Focus2.x, point_Focus2.y, this.Dir, this.objMainEff);
				this.VecEff.removeElement(point_Focus2);
				i--;
			}
		}
	}

	// Token: 0x060002F0 RID: 752 RVA: 0x0005C11C File Offset: 0x0005A31C
	public void updateLuffyS1()
	{
		bool flag = this.objBeFireMain != null && this.objBeFireMain.hOne > 0 && this.f % 5 == 0;
		if (flag)
		{
			sbyte b = 0;
			bool flag2 = this.typeEffect == 33;
			if (flag2)
			{
				b = 2;
				bool flag3 = !this.checkNullObject(2);
				if (flag3)
				{
					GameScreen.addEffectEnd(8, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
				}
			}
			base.setAva((int)b, this.objBeFireMain);
			bool flag4 = !this.checkNullObject(1);
			if (flag4)
			{
				int num = 28;
				bool flag5 = this.objFireMain.Dir == 0;
				if (flag5)
				{
					num = -28;
				}
				bool flag6 = this.isAddSound;
				if (flag6)
				{
					mSound.playSound(2, mSound.volumeSound);
				}
				bool flag7 = this.typeEffect == 176;
				if (flag7)
				{
					GameScreen.addEffectEnd(114, 0, this.objFireMain.x + num - this.am_duong * 8, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 3 * 2 + 5, (sbyte)this.objFireMain.Dir, this.objMainEff);
					GameScreen.addEffectEnd(10, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.dy - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
				}
				else
				{
					GameScreen.addEffectEnd(25, (int)b, this.objFireMain.x + num, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 3 * 2 + 10, this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(93, 0, this.objFireMain.x + num, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 3 * 2 + 10, this.Dir, this.objMainEff);
				}
			}
		}
		bool flag8 = this.f >= this.fRemove;
		if (flag8)
		{
			bool flag9 = this.typeEffect == 176 && !this.checkNullObject(1);
			if (flag9)
			{
				GameScreen.addEffectEnd(10, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.dy - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
			}
			this.removeEff();
		}
	}

	// Token: 0x060002F1 RID: 753 RVA: 0x0005C3F0 File Offset: 0x0005A5F0
	public void updateLuffyS1_NEW()
	{
		bool flag = this.f < 20 && this.f % 5 == 0;
		if (flag)
		{
			bool flag2 = this.isAddSound;
			if (flag2)
			{
				mSound.playSound(2, mSound.volumeSound);
			}
			int num = 28;
			bool flag3 = this.Dir == 0;
			if (flag3)
			{
				num = -28;
			}
			bool flag4 = !this.checkNullObject(2);
			if (flag4)
			{
				base.setDy(-6, this.objBeFireMain);
				bool flag5 = this.objBeFireMain.typeObject == 1 && this.objBeFireMain.Action != 4;
				if (flag5)
				{
					this.objBeFireMain.Action = 3;
				}
				GameScreen.addEffectEnd(8, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objFireMain.hOne / 2, this.Dir, this.objMainEff);
			}
			bool flag6 = !this.checkNullObject(1);
			if (flag6)
			{
				GameScreen.addEffectEnd(25, 2, this.objFireMain.x + num, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 3 * 2 + 10, this.Dir, this.objMainEff);
			}
		}
		bool flag7 = this.f == 20;
		if (flag7)
		{
			bool flag8 = this.isAddSound;
			if (flag8)
			{
				mSound.playSound(6, mSound.volumeSound);
			}
			int num2 = -15;
			bool flag9 = this.Dir == 0;
			if (flag9)
			{
				num2 = 15;
			}
			GameScreen.addEffectEnd(171, 0, this.x + num2, this.y, 450, this.Dir, this.objMainEff);
		}
		bool flag10 = this.f == 32;
		if (flag10)
		{
			bool flag11 = this.isAddSound;
			if (flag11)
			{
				mSound.playSound(5, mSound.volumeSound);
			}
			this.addVir(5, 5, 10, true);
			base.setAva(2, this.objBeFireMain);
			int num3 = 28;
			bool flag12 = this.Dir == 0;
			if (flag12)
			{
				num3 = -28;
			}
			bool flag13 = !this.checkNullObject(2);
			if (flag13)
			{
				GameScreen.addEffectEnd(8, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objFireMain.hOne / 2, this.Dir, this.objMainEff);
			}
			bool flag14 = !this.checkNullObject(1);
			if (flag14)
			{
				GameScreen.addEffectEnd(54, 2, this.objFireMain.x + num3, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 3 * 2 + 10, this.Dir, this.objMainEff);
			}
		}
		bool flag15 = this.f >= this.fRemove;
		if (flag15)
		{
			this.removeEff();
		}
	}

	// Token: 0x060002F2 RID: 754 RVA: 0x0005C6D8 File Offset: 0x0005A8D8
	public void updateLuffyS1_L3_SHORT()
	{
		bool flag = this.f == 4;
		if (flag)
		{
			bool flag2 = this.isAddSound;
			if (flag2)
			{
				mSound.playSound(2, mSound.volumeSound);
			}
			int num = 28;
			bool flag3 = this.Dir == 0;
			if (flag3)
			{
				num = -28;
			}
			bool flag4 = !this.checkNullObject(2);
			if (flag4)
			{
				base.setDy(-6, this.objBeFireMain);
				bool flag5 = this.objBeFireMain.typeObject == 1 && this.objBeFireMain.Action != 4;
				if (flag5)
				{
					this.objBeFireMain.Action = 3;
				}
				GameScreen.addEffectEnd(8, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objFireMain.hOne / 2, this.Dir, this.objMainEff);
			}
			bool flag6 = !this.checkNullObject(1);
			if (flag6)
			{
				GameScreen.addEffectEnd(25, 2, this.objFireMain.x + num, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 3 * 2 + 10, this.Dir, this.objMainEff);
			}
		}
		bool flag7 = this.f == 5;
		if (flag7)
		{
			bool flag8 = this.isAddSound;
			if (flag8)
			{
				mSound.playSound(6, mSound.volumeSound);
			}
			int num2 = -15;
			bool flag9 = this.Dir == 0;
			if (flag9)
			{
				num2 = 15;
			}
			GameScreen.addEffectEnd(30, 0, this.x + num2, this.y, 150, this.Dir, this.objMainEff);
		}
		bool flag10 = this.typeEffect == 83;
		if (flag10)
		{
			bool flag11 = this.f == 15;
			if (flag11)
			{
				bool flag12 = this.isAddSound;
				if (flag12)
				{
					mSound.playSound(5, mSound.volumeSound);
				}
				this.addVir(5, 5, 10, true);
				base.setAva(2, this.objBeFireMain);
				int num3 = 28;
				bool flag13 = this.Dir == 0;
				if (flag13)
				{
					num3 = -28;
				}
				bool flag14 = !this.checkNullObject(2);
				if (flag14)
				{
					GameScreen.addEffectEnd(8, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objFireMain.hOne / 2, this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(108, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objFireMain.hOne / 2, this.Dir, this.objMainEff);
				}
				bool flag15 = !this.checkNullObject(1);
				if (flag15)
				{
					GameScreen.addEffectEnd(25, 2, this.objFireMain.x + num3, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 3 * 2 + 10, this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(54, 0, this.objFireMain.x + num3, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 3 * 2 + 10, this.Dir, this.objMainEff);
				}
			}
		}
		else
		{
			bool flag16 = this.typeEffect == 180;
			if (flag16)
			{
				bool flag17 = this.f == 13 || this.f == 17;
				if (flag17)
				{
					bool flag18 = this.isAddSound;
					if (flag18)
					{
						mSound.playSound(5, mSound.volumeSound);
					}
					this.addVir(5, 5, 10, true);
					base.setAva(2, this.objBeFireMain);
					int num4 = 28;
					bool flag19 = this.Dir == 0;
					if (flag19)
					{
						num4 = -28;
					}
					bool flag20 = !this.checkNullObject(2);
					if (flag20)
					{
						GameScreen.addEffectEnd(8, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objFireMain.hOne / 2, this.Dir, this.objMainEff);
						GameScreen.addEffectEnd(108, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objFireMain.hOne / 2, this.Dir, this.objMainEff);
					}
					bool flag21 = !this.checkNullObject(1);
					if (flag21)
					{
						GameScreen.addEffectEnd(25, 2, this.objFireMain.x + num4, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 3 * 2 + 10, this.Dir, this.objMainEff);
						GameScreen.addEffectEnd(54, (this.f != 13) ? 6 : 7, this.objFireMain.x + num4, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 3 * 2 + 10, this.Dir, this.objMainEff);
					}
				}
			}
			else
			{
				bool flag22 = this.typeEffect == 212;
				if (flag22)
				{
					for (int i = 0; i < this.VecSubEff.size(); i++)
					{
						Point point = (Point)this.VecSubEff.elementAt(i);
						point.update();
						bool flag23 = point.f >= point.fRe;
						if (flag23)
						{
							this.VecSubEff.removeElement(point);
							i--;
						}
					}
					bool flag24 = this.f < this.fRemove && this.f % 3 == 0 && !GameCanvas.lowGraphic;
					if (flag24)
					{
						Point point2 = new Point();
						point2.x = this.x + CRes.random_Am_0(15);
						point2.y = this.y + 15 + CRes.random_Am_0(5);
						point2.vx = CRes.random_Am_0(2);
						point2.vy = -CRes.random(1, 4);
						point2.fRe = CRes.random(10, 14);
						this.VecSubEff.addElement(point2);
					}
					bool flag25 = this.f == 13 || this.f == 17;
					if (flag25)
					{
						bool flag26 = this.isAddSound;
						if (flag26)
						{
							mSound.playSound(5, mSound.volumeSound);
						}
						this.addVir(5, 5, 10, true);
						base.setAva(2, this.objBeFireMain);
						int num5 = 28;
						bool flag27 = this.Dir == 0;
						if (flag27)
						{
							num5 = -28;
						}
						bool flag28 = !this.checkNullObject(2);
						if (flag28)
						{
							GameScreen.addEffectEnd(8, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objFireMain.hOne / 2, this.Dir, this.objMainEff);
							GameScreen.addEffectEnd(108, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objFireMain.hOne / 2, this.Dir, this.objMainEff);
						}
						bool flag29 = !this.checkNullObject(1);
						if (flag29)
						{
							GameScreen.addEffectEnd(25, 2, this.objFireMain.x + num5, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 3 * 2 + 10, this.Dir, this.objMainEff);
							GameScreen.addEffectEnd(54, (this.f != 13) ? 9 : 7, this.objFireMain.x + num5, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 3 * 2 + 10, this.Dir, this.objMainEff);
						}
					}
				}
			}
		}
		bool flag30 = this.f >= this.fRemove && (this.typeEffect != 212 || this.VecSubEff.size() == 0);
		if (flag30)
		{
			this.removeEff();
		}
	}

	// Token: 0x060002F3 RID: 755 RVA: 0x0005CF04 File Offset: 0x0005B104
	public void update_Luffy_S1_L6()
	{
		bool flag = this.f >= this.fRemove && this.VecSubEff.size() == 0;
		if (flag)
		{
			this.removeEff();
		}
		bool flag2 = this.f == 1;
		if (flag2)
		{
			bool flag3 = this.isAddSound;
			if (flag3)
			{
				mSound.playSound(6, mSound.volumeSound);
			}
			int num = -15;
			bool flag4 = this.Dir == 0;
			if (flag4)
			{
				num = 15;
			}
			GameScreen.addEffectEnd(171, 0, this.x + num, this.y, 450, this.Dir, this.objMainEff);
		}
		bool flag5 = this.f == 10;
		if (flag5)
		{
			bool flag6 = this.isAddSound;
			if (flag6)
			{
				mSound.playSound(5, mSound.volumeSound);
			}
			this.addVir(5, 5, 10, true);
			base.setAva(2, this.objBeFireMain);
			int num2 = 28;
			bool flag7 = this.Dir == 0;
			if (flag7)
			{
				num2 = -28;
			}
			bool flag8 = !this.checkNullObject(2);
			if (flag8)
			{
				GameScreen.addEffectEnd(8, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objFireMain.hOne / 2, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(108, 5, this.objBeFireMain.x, this.objBeFireMain.y - this.objFireMain.hOne / 2, this.Dir, this.objMainEff);
			}
			bool flag9 = !this.checkNullObject(1);
			if (flag9)
			{
				GameScreen.addEffectEnd(54, 5, this.objFireMain.x + num2, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 3 * 2 + 10, this.Dir, this.objMainEff);
			}
			GameScreen.addEffectEnd(119, 3, this.objFireMain.x + this.am_duong * 20, this.objFireMain.y - this.objFireMain.hOne / 2 + 2, this.Dir, this.objMainEff);
		}
		bool flag10 = this.f == 14;
		if (flag10)
		{
			int num3 = 28;
			bool flag11 = this.Dir == 0;
			if (flag11)
			{
				num3 = -28;
			}
			bool flag12 = !this.checkNullObject(1);
			if (flag12)
			{
				GameScreen.addEffectEnd(54, 6, this.objFireMain.x + num3, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 3 * 2 + 10, this.Dir, this.objMainEff);
			}
		}
		for (int i = 0; i < this.VecSubEff.size(); i++)
		{
			Point point = (Point)this.VecSubEff.elementAt(i);
			point.update();
			bool flag13 = point.f >= point.fRe;
			if (flag13)
			{
				this.VecSubEff.removeElement(point);
				i--;
			}
		}
		bool flag14 = this.f < this.fRemove && this.f % 3 == 0 && !GameCanvas.lowGraphic;
		if (flag14)
		{
			Point point2 = new Point();
			point2.x = this.x + CRes.random_Am_0(15);
			point2.y = this.y + 15 + CRes.random_Am_0(5);
			point2.vx = CRes.random_Am_0(2);
			point2.vy = -CRes.random(1, 4);
			point2.fRe = CRes.random(10, 14);
			this.VecSubEff.addElement(point2);
		}
	}

	// Token: 0x060002F4 RID: 756 RVA: 0x0005D2C0 File Offset: 0x0005B4C0
	public void updateXaPhong()
	{
		bool flag = this.f >= this.fRemove && this.VecSubEff.size() == 0;
		if (flag)
		{
			this.removeEff();
		}
		for (int i = 0; i < this.VecSubEff.size(); i++)
		{
			Point point = (Point)this.VecSubEff.elementAt(i);
			point.update();
			bool flag2 = point.f < point.fRe;
			if (!flag2)
			{
				int num = CRes.random(3) + 1;
				bool flag3 = this.typeEffect == 274;
				if (flag3)
				{
					num = 2;
				}
				bool flag4 = num == 2;
				if (flag4)
				{
					GameScreen.addEffectEnd(71, 0, point.x, point.y, this.Dir, this.objMainEff);
					bool flag5 = CRes.random(4) == 0;
					if (flag5)
					{
						GameScreen.addEffectEnd(108, 4, point.x, point.y, this.Dir, this.objMainEff);
					}
				}
				else
				{
					GameScreen.addEffectEnd(38, num, point.x, point.y, this.Dir, this.objMainEff);
					bool flag6 = CRes.random(4) == 0;
					if (flag6)
					{
						bool flag7 = num == 1;
						if (flag7)
						{
							GameScreen.addEffectEnd(108, 3, point.x, point.y, this.Dir, this.objMainEff);
						}
						else
						{
							GameScreen.addEffectEnd(108, 8, point.x, point.y, this.Dir, this.objMainEff);
						}
					}
				}
				this.VecSubEff.removeElement(point);
				i--;
			}
		}
		bool flag8 = this.f < this.fRemove && !GameCanvas.lowGraphic;
		if (flag8)
		{
			for (int j = 0; j < 2; j++)
			{
				Point point2 = new Point();
				point2.x = this.objBeFireMain.x + CRes.random_Am_0(15);
				point2.y = this.objBeFireMain.y - this.objBeFireMain.hOne / 2 + CRes.random_Am_0(10);
				point2.vx = CRes.random_Am_0(4);
				point2.vy = CRes.random_Am_0(5);
				point2.fRe = CRes.random(10, 14);
				this.VecSubEff.addElement(point2);
			}
		}
	}

	// Token: 0x060002F5 RID: 757 RVA: 0x0005D530 File Offset: 0x0005B730
	public void updateMorgan_1()
	{
		bool flag = this.f < this.fRemove;
		if (!flag)
		{
			bool flag2 = !this.checkNullObject(1);
			if (flag2)
			{
				int num = -10;
				int num2 = 20;
				bool flag3 = this.Dir == 0;
				if (flag3)
				{
					num2 = -20;
				}
				GameScreen.addEffectEnd(16, 1, this.objFireMain.x + num2, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 2 + num, this.Dir, this.objMainEff);
				num2 = 13;
				bool flag4 = this.Dir == 0;
				if (flag4)
				{
					num2 = -13;
				}
				GameScreen.addEffectEnd(16, 1, this.objFireMain.x + num2, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 2 + num, this.Dir, this.objMainEff);
				num2 = 5;
				bool flag5 = this.Dir == 0;
				if (flag5)
				{
					num2 = -5;
				}
				GameScreen.addEffectEnd(16, 1, this.objFireMain.x + num2, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 2 + num, this.Dir, this.objMainEff);
			}
			bool flag6 = !this.checkNullObject(2);
			if (flag6)
			{
				this.addVir(3, 5, 10, false);
				base.setAva(1, this.objBeFireMain);
				GameScreen.addEffectEnd(10, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.dy - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
			}
			this.removeEff();
		}
	}

	// Token: 0x060002F6 RID: 758 RVA: 0x0005D704 File Offset: 0x0005B904
	public void updateMorgan_2()
	{
		bool flag = this.f < this.fRemove;
		if (!flag)
		{
			bool flag2 = !this.checkNullObject(1);
			if (flag2)
			{
				int num = -10;
				int num2 = 20;
				bool flag3 = this.Dir == 0;
				if (flag3)
				{
					num2 = -20;
				}
				GameScreen.addEffectEnd(16, 0, this.objFireMain.x + num2, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 2 + num, this.Dir, this.objMainEff);
				num2 = 15;
				num += 3;
				bool flag4 = this.Dir == 0;
				if (flag4)
				{
					num2 = -13;
				}
				GameScreen.addEffectEnd(16, 0, this.objFireMain.x + num2, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 2 + num, this.Dir, this.objMainEff);
				num2 = 10;
				num += 3;
				bool flag5 = this.Dir == 0;
				if (flag5)
				{
					num2 = -5;
				}
				GameScreen.addEffectEnd(16, 0, this.objFireMain.x + num2, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 2 + num, this.Dir, this.objMainEff);
			}
			bool flag6 = !this.checkNullObject(2);
			if (flag6)
			{
				base.setAva(1, this.objBeFireMain);
				GameScreen.addEffectEnd(10, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.dy - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
			}
			this.removeEff();
		}
	}

	// Token: 0x060002F7 RID: 759 RVA: 0x0005D8D4 File Offset: 0x0005BAD4
	public void updateZoroS2_New()
	{
		bool flag = this.f >= this.fRemove || this.checkNullObject(3);
		if (flag)
		{
			bool flag2 = this.isAddSound;
			if (flag2)
			{
				mSound.playSound(9, mSound.volumeSound);
			}
			bool flag3 = !this.checkNullObject(2);
			if (flag3)
			{
				base.setAva(2, this.objBeFireMain);
				GameScreen.addEffectEnd(19, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.dy - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
			}
			bool flag4 = !this.checkNullObject(1);
			if (flag4)
			{
				int num = 30;
				int num2 = 0;
				bool flag5 = this.Dir == 0;
				if (flag5)
				{
					num = -30;
				}
				int subtype = 0;
				bool flag6 = this.typeEffect == 184;
				if (flag6)
				{
					subtype = 2;
					num2 = 10;
				}
				else
				{
					bool flag7 = this.typeEffect == 216;
					if (flag7)
					{
						subtype = 3;
						num2 = 10;
					}
				}
				GameScreen.addEffectEnd(26, subtype, this.objFireMain.x + num, this.objFireMain.y - 5 + num2, this.Dir, this.objMainEff);
				this.objFireMain.vx = 0;
				this.objFireMain.vy = 0;
				this.objFireMain.toX = this.objFireMain.x;
				this.objFireMain.toY = this.objFireMain.y;
				this.objFireMain.isTanHinh = false;
			}
			this.removeEff();
		}
		else
		{
			bool flag8 = (this.f > 12 && this.f < 20) || (this.f > 22 && this.f < 26) || (this.f > 28 && this.f < 32) || (this.f > 34 && this.f < 38);
			if (flag8)
			{
				this.objFireMain.isTanHinh = true;
			}
			else
			{
				this.objFireMain.isTanHinh = false;
			}
			int num3 = 5;
			bool flag9 = this.f == 17;
			if (flag9)
			{
				this.objFireMain.y = this.objBeFireMain.y;
				this.giatocFly = 8;
			}
			bool flag10 = this.f < 20 && this.f >= 17;
			if (flag10)
			{
				this.objBeFireMain.dy += this.giatocFly;
				this.giatocFly /= 2;
			}
			bool flag11 = this.f >= 20 && this.f < 26;
			if (flag11)
			{
				this.giatocFly = 0;
				this.objBeFireMain.dy = 20;
				this.objFireMain.dy = 15;
			}
			bool flag12 = this.f == 20;
			if (flag12)
			{
				bool flag13 = this.isAddSound;
				if (flag13)
				{
					mSound.playSound(7, mSound.volumeSound);
				}
				this.addVir(5, 5, 10, true);
				int num4 = 20;
				bool flag14 = this.Dir == 0;
				if (flag14)
				{
					num4 = -20;
				}
				this.objFireMain.x = this.toX - num4;
				this.objFireMain.y = this.toY + this.objBeFireMain.hOne / 2;
				base.setAva(0, this.objBeFireMain);
				GameScreen.addEffectEnd(10, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.dy - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
				int subtype2 = 1;
				bool flag15 = this.typeEffect == 184 || this.typeEffect == 216;
				if (flag15)
				{
					subtype2 = -1;
					num4 = 10;
					bool flag16 = this.Dir == 0;
					if (flag16)
					{
						num4 = -10;
					}
				}
				GameScreen.addEffectEnd(16, subtype2, this.objFireMain.x + num4, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 2 - 10 + num3, this.Dir, this.objMainEff);
				bool flag17 = this.typeEffect == 216;
				if (flag17)
				{
					GameScreen.addEffectEnd(136, 0, this.objFireMain.x + num4, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 2 - 10 + num3, this.Dir, this.objMainEff);
				}
			}
			bool flag18 = this.f >= 26 && this.f < 32;
			if (flag18)
			{
				this.objBeFireMain.dy = 30;
				this.objFireMain.dy = 25;
			}
			bool flag19 = this.f == 26;
			if (flag19)
			{
				bool flag20 = this.isAddSound;
				if (flag20)
				{
					mSound.playSound(7, mSound.volumeSound);
				}
				this.addVir(5, 5, 10, true);
				this.changeDir();
				this.objFireMain.Dir = (int)this.Dir;
				int num5 = 30;
				bool flag21 = this.Dir == 0;
				if (flag21)
				{
					num5 = -30;
				}
				this.objFireMain.x = this.toX - num5;
				this.objFireMain.y = this.toY + this.objBeFireMain.hOne / 2;
				base.setAva(0, this.objBeFireMain);
				GameScreen.addEffectEnd(10, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.dy - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
				int subtype3 = 2;
				bool flag22 = this.typeEffect == 184 || this.typeEffect == 216;
				if (flag22)
				{
					subtype3 = -2;
					num5 = 15;
					bool flag23 = this.Dir == 0;
					if (flag23)
					{
						num5 = -15;
					}
				}
				GameScreen.addEffectEnd(16, subtype3, this.objFireMain.x + num5, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 2 + num3, this.Dir, this.objMainEff);
			}
			bool flag24 = this.f == 32;
			if (flag24)
			{
				bool flag25 = this.isAddSound;
				if (flag25)
				{
					mSound.playSound(7, mSound.volumeSound);
				}
				this.changeDir();
				this.objFireMain.Dir = (int)this.Dir;
				int num6 = 20;
				bool flag26 = this.Dir == 0;
				if (flag26)
				{
					num6 = -20;
				}
				this.objFireMain.x = this.toX - num6;
				this.objFireMain.y = this.toY + this.objBeFireMain.hOne / 2;
				base.setAva(0, this.objBeFireMain);
				this.objBeFireMain.dy = 40;
				this.objFireMain.dy = 35;
				GameScreen.addEffectEnd(19, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.dy - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
				int subtype4 = 1;
				bool flag27 = this.typeEffect == 184 || this.typeEffect == 216;
				if (flag27)
				{
					subtype4 = -1;
					num6 = 10;
					bool flag28 = this.Dir == 0;
					if (flag28)
					{
						num6 = -10;
					}
				}
				GameScreen.addEffectEnd(16, subtype4, this.objFireMain.x + num6, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 2 - 10 + num3, this.Dir, this.objMainEff);
			}
			bool flag29 = this.f == 38;
			if (flag29)
			{
				this.changeDir();
				this.objFireMain.Dir = (int)this.Dir;
				Point_Focus point_Focus = new Point_Focus();
				int num7 = 20;
				bool flag30 = this.Dir == 0;
				if (flag30)
				{
					num7 = -20;
				}
				int toX = this.toX;
				int toY = this.toY;
				this.toX = this.x;
				this.toY = this.y;
				this.x = toX;
				this.y = toY;
				int xdich = this.toX - (this.x - num7);
				int ydich = this.toY - this.y;
				this.objFireMain.x = this.x - num7;
				this.objFireMain.y = this.y;
				this.objFireMain.dy = 0;
				this.objBeFireMain.dy = 0;
				base.create_Speed(xdich, ydich, point_Focus);
				this.objFireMain.vx = point_Focus.vx;
				this.objFireMain.vy = -point_Focus.vy;
				this.objFireMain.toX = point_Focus.toX;
				this.objFireMain.toY = point_Focus.toY;
			}
			bool flag31 = this.f > 38 && MainObject.getDistance(this.objFireMain.x, this.objFireMain.y, this.objFireMain.toX, this.objFireMain.toY) < this.vMax;
			if (flag31)
			{
				this.objFireMain.vx = 0;
				this.objFireMain.vy = 0;
				this.objFireMain.toX = this.objFireMain.x;
				this.objFireMain.toY = this.objFireMain.y;
			}
		}
	}

	// Token: 0x060002F8 RID: 760 RVA: 0x0005E298 File Offset: 0x0005C498
	public void updateZoroS2_L6()
	{
		bool flag = this.f >= this.fRemove || this.checkNullObject(3);
		if (flag)
		{
			bool flag2 = this.isAddSound;
			if (flag2)
			{
				mSound.playSound(9, mSound.volumeSound);
			}
			bool flag3 = !this.checkNullObject(2);
			if (flag3)
			{
				base.setAva(2, this.objBeFireMain);
				GameScreen.addEffectEnd(19, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.dy - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
			}
			bool flag4 = !this.checkNullObject(1);
			if (flag4)
			{
				int num = 30;
				bool flag5 = this.Dir == 0;
				if (flag5)
				{
					num = -30;
				}
				int subtype = 4;
				int num2 = 10;
				GameScreen.addEffectEnd(26, subtype, this.objFireMain.x + num, this.objFireMain.y - 5 + num2, this.Dir, this.objMainEff);
				this.objFireMain.vx = 0;
				this.objFireMain.vy = 0;
				this.objFireMain.toX = this.objFireMain.x;
				this.objFireMain.toY = this.objFireMain.y;
				this.objFireMain.isTanHinh = false;
			}
			this.removeEff();
		}
		else
		{
			bool flag6 = (this.f > 12 && this.f < 20) || (this.f > 22 && this.f < 26) || (this.f > 28 && this.f < 32) || (this.f > 34 && this.f < 38);
			if (flag6)
			{
				this.objFireMain.isTanHinh = true;
			}
			else
			{
				this.objFireMain.isTanHinh = false;
			}
			bool flag7 = this.f == 17;
			if (flag7)
			{
				this.objFireMain.y = this.objBeFireMain.y;
				this.giatocFly = 8;
			}
			bool flag8 = this.f < 20 && this.f >= 17;
			if (flag8)
			{
				this.objBeFireMain.dy += this.giatocFly;
				this.giatocFly /= 2;
			}
			bool flag9 = this.f >= 20 && this.f < 26;
			if (flag9)
			{
				this.giatocFly = 0;
				this.objBeFireMain.dy = 20;
				this.objFireMain.dy = 15;
			}
			bool flag10 = this.f == 10;
			if (flag10)
			{
				bool flag11 = this.isAddSound;
				if (flag11)
				{
					mSound.playSound(7, mSound.volumeSound);
				}
				this.addVir(5, 5, 10, true);
				int num3 = 20;
				bool flag12 = this.Dir == 0;
				if (flag12)
				{
					num3 = -20;
				}
				this.objFireMain.x = this.toX - num3;
				this.objFireMain.y = this.toY + this.objBeFireMain.hOne / 2;
				base.setAva(0, this.objBeFireMain);
				GameScreen.addEffectEnd(10, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.dy - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
				this.createSkillZoro2(1, this.toX + CRes.random_Am_0(5), this.toY - 20, 2);
			}
			bool flag13 = this.f >= 16 && this.f < 22;
			if (flag13)
			{
				this.objBeFireMain.dy = 30;
				this.objFireMain.dy = 25;
			}
			bool flag14 = this.f == 16;
			if (flag14)
			{
				bool flag15 = this.isAddSound;
				if (flag15)
				{
					mSound.playSound(7, mSound.volumeSound);
				}
				this.addVir(5, 5, 10, true);
				this.changeDir();
				this.objFireMain.Dir = (int)this.Dir;
				int num4 = 30;
				bool flag16 = this.Dir == 0;
				if (flag16)
				{
					num4 = -30;
				}
				this.objFireMain.x = this.toX - num4;
				this.objFireMain.y = this.toY + this.objBeFireMain.hOne / 2;
				base.setAva(0, this.objBeFireMain);
				GameScreen.addEffectEnd(10, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.dy - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
				this.createSkillZoro2(0, this.toX + CRes.random_Am_0(5), this.toY - 20, 2);
			}
			bool flag17 = this.f == 22;
			if (flag17)
			{
				bool flag18 = this.isAddSound;
				if (flag18)
				{
					mSound.playSound(7, mSound.volumeSound);
				}
				this.changeDir();
				this.objFireMain.Dir = (int)this.Dir;
				int num5 = 20;
				bool flag19 = this.Dir == 0;
				if (flag19)
				{
					num5 = -20;
				}
				this.objFireMain.x = this.toX - num5;
				this.objFireMain.y = this.toY + this.objBeFireMain.hOne / 2;
				base.setAva(0, this.objBeFireMain);
				this.objBeFireMain.dy = 40;
				this.objFireMain.dy = 35;
				GameScreen.addEffectEnd(19, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.dy - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
				this.createSkillZoro2(1, this.toX + CRes.random_Am_0(5), this.toY - 20, 2);
			}
			bool flag20 = this.f == 28;
			if (flag20)
			{
				this.changeDir();
				this.objFireMain.Dir = (int)this.Dir;
				Point_Focus point_Focus = new Point_Focus();
				int num6 = 20;
				bool flag21 = this.Dir == 0;
				if (flag21)
				{
					num6 = -20;
				}
				int toX = this.toX;
				int toY = this.toY;
				this.toX = this.x;
				this.toY = this.y;
				this.x = toX;
				this.y = toY;
				int xdich = this.toX - (this.x - num6);
				int ydich = this.toY - this.y;
				this.objFireMain.x = this.x - num6;
				this.objFireMain.y = this.y;
				this.objFireMain.dy = 0;
				this.objBeFireMain.dy = 0;
				base.create_Speed(xdich, ydich, point_Focus);
				this.objFireMain.vx = point_Focus.vx;
				this.objFireMain.vy = -point_Focus.vy;
				this.objFireMain.toX = point_Focus.toX;
				this.objFireMain.toY = point_Focus.toY;
			}
			bool flag22 = this.f > 28 && MainObject.getDistance(this.objFireMain.x, this.objFireMain.y, this.objFireMain.toX, this.objFireMain.toY) < this.vMax;
			if (flag22)
			{
				this.objFireMain.vx = 0;
				this.objFireMain.vy = 0;
				this.objFireMain.toX = this.objFireMain.x;
				this.objFireMain.toY = this.objFireMain.y;
			}
			for (int i = 0; i < this.VecEff.size(); i++)
			{
				Point point = (Point)this.VecEff.elementAt(i);
				point.update();
				bool flag23 = point.f >= point.fRe;
				if (flag23)
				{
					this.VecEff.removeElement(point);
					i--;
				}
			}
		}
	}

	// Token: 0x060002F9 RID: 761 RVA: 0x0005EAD8 File Offset: 0x0005CCD8
	private void addShadow_Zoro_S1_L6()
	{
		Point point = new Point(this.objFireMain.x, this.objFireMain.y + 2);
		point.frame = (this.f - 12) / 2;
		bool flag = point.frame >= this.fraImgSubEff.nFrame;
		if (flag)
		{
			point.frame = this.fraImgSubEff.nFrame - 1;
		}
		this.VecSubEff.addElement(point);
		bool flag2 = this.Dir == 0;
		if (flag2)
		{
			this.objFireMain.vx = -this.objFireMain.vMax * 4;
		}
		else
		{
			this.objFireMain.vx = this.objFireMain.vMax * 4;
		}
	}

	// Token: 0x060002FA RID: 762 RVA: 0x0005EB98 File Offset: 0x0005CD98
	public void updateZoroS2_New_SHORT()
	{
		bool flag = this.f >= this.fRemove || this.checkNullObject(3);
		if (flag)
		{
			bool flag2 = !this.checkNullObject(1);
			if (flag2)
			{
				int num = 30;
				bool flag3 = this.Dir == 0;
				if (flag3)
				{
					num = -30;
				}
				int subtype = 0;
				bool flag4 = this.typeEffect == 184;
				if (flag4)
				{
					subtype = 2;
				}
				GameScreen.addEffectEnd(26, subtype, this.objFireMain.x + num, this.objFireMain.y - 5, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(108, 3, this.objFireMain.x + num, this.objFireMain.y - 35, this.Dir, this.objMainEff);
				this.objFireMain.vx = 0;
				this.objFireMain.vy = 0;
				this.objFireMain.toX = this.objFireMain.x;
				this.objFireMain.toY = this.objFireMain.y;
				this.objFireMain.isTanHinh = false;
			}
			this.removeEff();
		}
		else
		{
			bool flag5 = (this.f > 2 && this.f < 10) || (this.f > 12 && this.f < 16) || (this.f > 18 && this.f < 22);
			if (flag5)
			{
				this.objFireMain.isTanHinh = true;
			}
			else
			{
				this.objFireMain.isTanHinh = false;
			}
			int num2 = 5;
			bool flag6 = this.f == 7;
			if (flag6)
			{
				this.objFireMain.y = this.objBeFireMain.y;
				this.giatocFly = 8;
			}
			bool flag7 = this.f < 10 && this.f >= 7;
			if (flag7)
			{
				this.objBeFireMain.dy += this.giatocFly;
				this.giatocFly /= 2;
			}
			bool flag8 = this.f >= 10 && this.f < 16;
			if (flag8)
			{
				this.giatocFly = 0;
				this.objBeFireMain.dy = 20;
				this.objFireMain.dy = 15;
			}
			bool flag9 = this.f == 10;
			if (flag9)
			{
				bool flag10 = this.isAddSound;
				if (flag10)
				{
					mSound.playSound(7, mSound.volumeSound);
				}
				this.addVir(5, 5, 10, true);
				int num3 = 20;
				bool flag11 = this.Dir == 0;
				if (flag11)
				{
					num3 = -20;
				}
				this.objFireMain.x = this.toX - num3;
				this.objFireMain.y = this.toY + this.objBeFireMain.hOne / 2;
				base.setAva(0, this.objBeFireMain);
				GameScreen.addEffectEnd(10, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.dy - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(16, 1, this.objFireMain.x + num3, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 2 - 10 + num2, this.Dir, this.objMainEff);
			}
			bool flag12 = this.f >= 16 && this.f < 22;
			if (flag12)
			{
				this.objBeFireMain.dy = 30;
				this.objFireMain.dy = 25;
			}
			bool flag13 = this.f == 16;
			if (flag13)
			{
				bool flag14 = this.isAddSound;
				if (flag14)
				{
					mSound.playSound(7, mSound.volumeSound);
				}
				this.addVir(5, 5, 10, true);
				this.changeDir();
				this.objFireMain.Dir = (int)this.Dir;
				int num4 = 30;
				bool flag15 = this.Dir == 0;
				if (flag15)
				{
					num4 = -30;
				}
				this.objFireMain.x = this.toX - num4;
				this.objFireMain.y = this.toY + this.objBeFireMain.hOne / 2;
				base.setAva(0, this.objBeFireMain);
				GameScreen.addEffectEnd(10, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.dy - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(16, 2, this.objFireMain.x + num4, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 2 + num2, this.Dir, this.objMainEff);
			}
			bool flag16 = this.f == 22;
			if (flag16)
			{
				bool flag17 = this.isAddSound;
				if (flag17)
				{
					mSound.playSound(7, mSound.volumeSound);
				}
				this.changeDir();
				this.objFireMain.Dir = (int)this.Dir;
				int num5 = 20;
				bool flag18 = this.Dir == 0;
				if (flag18)
				{
					num5 = -20;
				}
				this.objFireMain.x = this.toX - num5;
				this.objFireMain.y = this.toY + this.objBeFireMain.hOne / 2;
				base.setAva(0, this.objBeFireMain);
				this.objBeFireMain.dy = 40;
				this.objFireMain.dy = 35;
				GameScreen.addEffectEnd(19, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.dy - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(16, 1, this.objFireMain.x + num5, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 2 - 10 + num2, this.Dir, this.objMainEff);
				bool flag19 = this.isAddSound;
				if (flag19)
				{
					mSound.playSound(9, mSound.volumeSound);
				}
				bool flag20 = !this.checkNullObject(2);
				if (flag20)
				{
					base.setAva(2, this.objBeFireMain);
					GameScreen.addEffectEnd(19, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.dy - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
				}
			}
			bool flag21 = this.f > 23 && MainObject.getDistance(this.objFireMain.x, this.objFireMain.y, this.objFireMain.toX, this.objFireMain.toY) < this.vMax;
			if (flag21)
			{
				this.objFireMain.vx = 0;
				this.objFireMain.vy = 0;
				this.objFireMain.toX = this.objFireMain.x;
				this.objFireMain.toY = this.objFireMain.y;
			}
		}
	}

	// Token: 0x060002FB RID: 763 RVA: 0x0005F2E0 File Offset: 0x0005D4E0
	public void updateZoroS1_New()
	{
		bool flag = this.f >= this.fRemove || this.checkNullObject(3);
		if (flag)
		{
			bool flag2 = !this.checkNullObject(1);
			if (flag2)
			{
				this.objFireMain.vx = 0;
				this.objFireMain.dy = 0;
			}
			this.removeEff();
		}
		else
		{
			for (int i = 0; i < this.VecEff.size(); i++)
			{
				Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(i);
				point_Focus.update_Vx_Vy();
				bool flag3 = point_Focus.f == point_Focus.fRe + 1;
				if (flag3)
				{
					point_Focus.vx = 0;
					point_Focus.vy = 0;
					point_Focus.x = this.objBeFireMain.x;
					point_Focus.y = this.objBeFireMain.y;
				}
				bool flag4 = point_Focus.f > point_Focus.fRe + 10;
				if (flag4)
				{
					this.VecEff.removeElement(point_Focus);
					i--;
				}
			}
			int num = 5;
			bool flag5 = this.f <= this.fRemove;
			if (flag5)
			{
				bool flag6 = this.f == 21;
				if (flag6)
				{
					this.giatocFly = 12;
				}
				bool flag7 = this.f >= 21 && this.f <= 26;
				if (flag7)
				{
					this.objBeFireMain.dy += this.giatocFly;
					this.giatocFly -= 2;
				}
				bool flag8 = this.f > 26;
				if (flag8)
				{
					this.giatocFly = 0;
					base.setAva(-1, this.objBeFireMain);
					this.objFireMain.y = this.objBeFireMain.y;
					this.objFireMain.vx = 0;
					this.objFireMain.dy = 40;
					this.objBeFireMain.dy = 45;
				}
				else
				{
					bool flag9 = this.f == 24;
					if (flag9)
					{
						base.setAva(-1, this.objBeFireMain);
						int num2 = this.objBeFireMain.x - 10;
						bool flag10 = this.Dir == 0;
						if (flag10)
						{
							num2 = this.objBeFireMain.x + 10;
						}
						int num3 = num2 - this.objFireMain.x;
						this.objFireMain.vx = num3 / 4;
					}
					else
					{
						bool flag11 = this.f >= 22;
						if (flag11)
						{
							base.setAva(-1, this.objBeFireMain);
						}
					}
				}
			}
			bool flag12 = this.f == 5 || this.f == 37;
			if (flag12)
			{
				bool flag13 = this.isAddSound;
				if (flag13)
				{
					mSound.playSound(7, mSound.volumeSound);
				}
				this.addVir(5, 5, 10, true);
				bool flag14 = this.f == 5;
				if (flag14)
				{
					base.setAva(0, this.objBeFireMain);
				}
				int num4 = 20;
				bool flag15 = this.Dir == 0;
				if (flag15)
				{
					num4 = -20;
				}
				GameScreen.addEffectEnd(10, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.dy - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(16, 1, this.objFireMain.x + num4, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 2 - 10 + num, this.Dir, this.objMainEff);
			}
			bool flag16 = this.f == 10 || this.f == 42;
			if (flag16)
			{
				bool flag17 = this.isAddSound;
				if (flag17)
				{
					mSound.playSound(7, mSound.volumeSound);
				}
				bool flag18 = this.f == 10;
				if (flag18)
				{
					base.setAva(0, this.objBeFireMain);
				}
				int num5 = 30;
				bool flag19 = this.Dir == 0;
				if (flag19)
				{
					num5 = -30;
				}
				GameScreen.addEffectEnd(10, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.dy - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(16, 2, this.objFireMain.x + num5, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 2 + num, this.Dir, this.objMainEff);
			}
			bool flag20 = this.f == 47;
			if (flag20)
			{
				bool flag21 = this.isAddSound;
				if (flag21)
				{
					mSound.playSound(7, mSound.volumeSound);
				}
				int num6 = 20;
				bool flag22 = this.Dir == 0;
				if (flag22)
				{
					num6 = -20;
				}
				GameScreen.addEffectEnd(19, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.dy - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(16, 1, this.objFireMain.x + num6, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 2 - 10 + num, this.Dir, this.objMainEff);
			}
			bool flag23 = this.f == 12;
			if (flag23)
			{
				GameScreen.addEffectEnd(30, 0, this.objFireMain.x, this.objFireMain.y - this.objFireMain.hOne / 2, 300, this.Dir, this.objMainEff);
			}
			bool flag24 = this.f == 22;
			if (flag24)
			{
				bool flag25 = this.isAddSound;
				if (flag25)
				{
					mSound.playSound(8, mSound.volumeSound);
					mSound.playSound(7, mSound.volumeSound);
				}
				this.addVir(5, 5, 10, true);
				int num7 = 20;
				bool flag26 = this.Dir == 0;
				if (flag26)
				{
					num7 = -20;
				}
				base.setAva(0, this.objBeFireMain);
				GameScreen.addEffectEnd(19, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.dy - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(16, 1, this.x + num7, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 2 - 10 + num, this.Dir, this.objMainEff);
				int xdich = this.objBeFireMain.x - this.x;
				int ydich = this.objBeFireMain.y - this.y;
				Point_Focus point_Focus2 = new Point_Focus();
				point_Focus2 = base.create_Speed(xdich, ydich, point_Focus2);
				this.VecEff.addElement(point_Focus2);
			}
		}
	}

	// Token: 0x060002FC RID: 764 RVA: 0x0005F9FC File Offset: 0x0005DBFC
	public void updateZoro_S1_L3_SHORT()
	{
		bool flag = this.f >= this.fRemove || this.checkNullObject(3);
		if (flag)
		{
			bool flag2 = !this.checkNullObject(1);
			if (flag2)
			{
				this.objFireMain.vx = 0;
				this.objFireMain.dy = 0;
			}
			this.removeEff();
		}
		else
		{
			for (int i = 0; i < this.VecEff.size(); i++)
			{
				Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(i);
				point_Focus.update_Vx_Vy();
				bool flag3 = point_Focus.f == point_Focus.fRe + 1;
				if (flag3)
				{
					point_Focus.vx = 0;
					point_Focus.vy = 0;
					bool flag4 = this.typeEffect == 183 || this.typeEffect == 215;
					if (flag4)
					{
						point_Focus.vy = -4;
					}
					point_Focus.x = this.objBeFireMain.x;
					point_Focus.y = this.objBeFireMain.y;
				}
				bool flag5 = this.typeEffect == 183 || this.typeEffect == 215;
				if (flag5)
				{
					bool flag6 = point_Focus.f > point_Focus.fRe + 7;
					if (flag6)
					{
						this.VecEff.removeElement(point_Focus);
						i--;
					}
				}
				else
				{
					bool flag7 = point_Focus.f > point_Focus.fRe + 5;
					if (flag7)
					{
						this.VecEff.removeElement(point_Focus);
						i--;
					}
				}
			}
			int num = 5;
			bool flag8 = this.f <= 14;
			if (flag8)
			{
				bool flag9 = this.f == 1;
				if (flag9)
				{
					this.giatocFly = 12;
				}
				bool flag10 = this.f >= 1 && this.f <= 6;
				if (flag10)
				{
					this.objBeFireMain.dy += this.giatocFly;
					this.giatocFly -= 2;
				}
				bool flag11 = this.f > 6;
				if (flag11)
				{
					this.giatocFly = 0;
					base.setAva(-1, this.objBeFireMain);
					this.objFireMain.y = this.objBeFireMain.y;
					this.objFireMain.vx = 0;
					this.objFireMain.dy = 40;
					this.objBeFireMain.dy = 45;
				}
				else
				{
					bool flag12 = this.f == 4;
					if (flag12)
					{
						base.setAva(-1, this.objBeFireMain);
						int num2 = this.objBeFireMain.x - 10;
						bool flag13 = this.Dir == 0;
						if (flag13)
						{
							num2 = this.objBeFireMain.x + 10;
						}
						int num3 = num2 - this.objFireMain.x;
						this.objFireMain.vx = num3 / 4;
					}
					else
					{
						bool flag14 = this.f >= 2;
						if (flag14)
						{
							base.setAva(-1, this.objBeFireMain);
						}
					}
				}
			}
			bool flag15 = this.f == 8 || this.f == 12;
			if (flag15)
			{
				bool flag16 = this.isAddSound;
				if (flag16)
				{
					mSound.playSound(7, mSound.volumeSound);
				}
				this.addVir(5, 5, 10, true);
				base.setAva(1, this.objBeFireMain);
				int num4 = 20;
				bool flag17 = this.Dir == 0;
				if (flag17)
				{
					num4 = -20;
				}
				int subtype = 1;
				bool flag18 = this.typeEffect == 183;
				if (flag18)
				{
					subtype = -1;
				}
				GameScreen.addEffectEnd(10, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.dy - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(108, 2, this.objFireMain.x + num4, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 2 - 10 + num, this.Dir, this.objMainEff);
				bool flag19 = this.typeEffect == 215;
				if (flag19)
				{
					GameScreen.addEffectEnd(135, 0, this.objFireMain.x + num4, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 2 - 5 + num, this.Dir, this.objMainEff);
				}
				else
				{
					GameScreen.addEffectEnd(16, subtype, this.objFireMain.x + num4, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 2 - 10 + num, this.Dir, this.objMainEff);
				}
			}
			bool flag20 = this.f == 1;
			if (flag20)
			{
				int xdich = this.objBeFireMain.x - this.x;
				int ydich = this.objBeFireMain.y - this.y;
				Point_Focus point_Focus2 = new Point_Focus();
				point_Focus2 = base.create_Speed(xdich, ydich, point_Focus2);
				this.VecEff.addElement(point_Focus2);
			}
		}
	}

	// Token: 0x060002FD RID: 765 RVA: 0x0005FF38 File Offset: 0x0005E138
	public void updateZoro_S1_L6()
	{
		bool flag = this.f >= this.fRemove || this.checkNullObject(3);
		if (flag)
		{
			bool flag2 = !this.checkNullObject(1);
			if (flag2)
			{
				this.objFireMain.vx = 0;
				this.objFireMain.dy = 0;
				this.objFireMain.isTanHinh = false;
			}
			this.removeEff();
		}
		else
		{
			for (int i = 0; i < this.VecEff.size(); i++)
			{
				Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(i);
				point_Focus.update_Vx_Vy();
				bool flag3 = point_Focus.f == point_Focus.fRe + 1;
				if (flag3)
				{
					point_Focus.vx = 0;
					point_Focus.vy = -4;
				}
				bool flag4 = point_Focus.f > point_Focus.fRe + 7;
				if (flag4)
				{
					this.VecEff.removeElement(point_Focus);
					i--;
				}
			}
			int num = 5;
			bool flag5 = this.f <= 14;
			if (flag5)
			{
				bool flag6 = this.f == 1;
				if (flag6)
				{
					this.giatocFly = 12;
				}
				bool flag7 = this.f >= 1 && this.f <= 6;
				if (flag7)
				{
					this.objBeFireMain.dy += this.giatocFly;
					this.giatocFly -= 2;
				}
				bool flag8 = this.f > 6;
				if (flag8)
				{
					this.giatocFly = 0;
					base.setAva(-1, this.objBeFireMain);
					this.objFireMain.y = this.objBeFireMain.y;
					this.objFireMain.vx = 0;
					this.objFireMain.dy = 40;
					this.objBeFireMain.dy = 45;
				}
				else
				{
					bool flag9 = this.f == 4;
					if (flag9)
					{
						base.setAva(-1, this.objBeFireMain);
						int num2 = this.objBeFireMain.x - 10;
						bool flag10 = this.Dir == 0;
						if (flag10)
						{
							num2 = this.objBeFireMain.x + 10;
						}
						int num3 = num2 - this.objFireMain.x;
					}
					else
					{
						bool flag11 = this.f >= 2;
						if (flag11)
						{
							base.setAva(-1, this.objBeFireMain);
						}
					}
				}
			}
			bool flag12 = this.f == 8 || this.f == 12;
			if (flag12)
			{
				bool flag13 = this.isAddSound;
				if (flag13)
				{
					mSound.playSound(7, mSound.volumeSound);
				}
				this.addVir(5, 5, 10, true);
				base.setAva(1, this.objBeFireMain);
				int num4 = 20;
				bool flag14 = this.Dir == 0;
				if (flag14)
				{
					num4 = -20;
				}
				GameScreen.addEffectEnd(10, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.dy - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(108, 2, this.objFireMain.x + num4, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 2 - 10 + num, this.Dir, this.objMainEff);
			}
			bool flag15 = this.f == 1;
			if (flag15)
			{
				int xdich = 0;
				int ydich = this.objBeFireMain.y - this.y;
				Point_Focus point_Focus2 = new Point_Focus();
				point_Focus2 = base.create_Speed(xdich, ydich, point_Focus2);
				point_Focus2.x = this.objBeFireMain.x;
				point_Focus2.y = this.objBeFireMain.y;
				this.VecEff.addElement(point_Focus2);
				int num5 = (this.Dir != 0) ? -5 : 5;
				GameScreen.addEffectEnd(170, 0, this.objFireMain.x + num5, this.objFireMain.y + 22, this.Dir, this.objMainEff);
			}
			for (int j = 0; j < this.VecSubEff.size(); j++)
			{
				bool flag16 = this.f > 8 + j * 4;
				if (flag16)
				{
					Point_Focus point_Focus3 = (Point_Focus)this.VecSubEff.elementAt(j);
					point_Focus3.update_Vx_Vy();
				}
			}
		}
	}

	// Token: 0x060002FE RID: 766 RVA: 0x000603A8 File Offset: 0x0005E5A8
	public void updateLuffyS3_New()
	{
		bool flag = (this.f >= this.fRemove && this.VecEff.size() == 0) || this.checkNullObject(1);
		if (flag)
		{
			this.removeEff();
		}
		else
		{
			bool flag2 = this.f == 5;
			if (flag2)
			{
				int num = 30;
				bool flag3 = this.Dir == 2;
				if (flag3)
				{
					num = -30;
				}
				Point o = new Point(this.objFireMain.x + num, this.objFireMain.y);
				this.VecSubEff.addElement(o);
			}
			bool flag4 = this.f == 10;
			if (flag4)
			{
				int num2 = -10;
				bool flag5 = this.Dir == 2;
				if (flag5)
				{
					num2 = 10;
				}
				Point o2 = new Point(this.objFireMain.x + num2, this.objFireMain.y - 35);
				this.VecSubEff.addElement(o2);
			}
			bool flag6 = this.f == 15;
			if (flag6)
			{
				int num3 = -10;
				bool flag7 = this.Dir == 2;
				if (flag7)
				{
					num3 = 10;
				}
				Point o3 = new Point(this.objFireMain.x + num3, this.objFireMain.y + 35);
				this.VecSubEff.addElement(o3);
			}
			bool flag8 = (this.f == 22 || this.f == 25) && this.isAddSound;
			if (flag8)
			{
				mSound.playSound(4, mSound.volumeSound);
			}
			bool flag9 = this.f >= 18;
			if (flag9)
			{
				bool flag10 = this.f % 3 == 0;
				if (flag10)
				{
					bool flag11 = this.indexObjBefire < this.vecObjsBeFire.size();
					if (flag11)
					{
						Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(this.indexObjBefire);
						this.indexObjBefire++;
						bool flag12 = object_Effect_Skill != null;
						if (flag12)
						{
							MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
							bool flag13 = mainObject != null;
							if (flag13)
							{
								sbyte dir = 0;
								bool flag14 = this.objFireMain.x < mainObject.x;
								if (flag14)
								{
									dir = 2;
								}
								int num4 = 12;
								bool flag15 = this.Dir == 0;
								if (flag15)
								{
									num4 = -12;
								}
								int num5 = 2;
								bool flag16 = this.typeEffect == 182;
								if (flag16)
								{
									num5 = 3;
								}
								GameScreen.addEffectEnd_ObjTo(13, num5, this.objFireMain.x + num4, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 3 * 2 + 10, mainObject.ID, mainObject.typeObject, dir, this.objMainEff);
								for (int i = 0; i < this.VecSubEff.size(); i++)
								{
									Point point = (Point)this.VecSubEff.elementAt(i);
									int num6 = -20;
									bool flag17 = this.Dir == 2;
									if (flag17)
									{
										num6 = 20;
									}
									GameScreen.addEffectEnd_ObjTo(13, num5, point.x + num4 + num6, point.y - this.objFireMain.hOne / 2, mainObject.ID, mainObject.typeObject, dir, this.objMainEff);
								}
							}
						}
					}
					else
					{
						int num7 = 12;
						bool flag18 = this.Dir == 0;
						if (flag18)
						{
							num7 = -12;
						}
						int num8 = 0;
						bool flag19 = this.typeEffect == 182;
						if (flag19)
						{
							num8 = 3;
						}
						bool flag20 = CRes.random(3) == 0;
						if (flag20)
						{
							int xTo = this.objFireMain.x + num7 + this.am_duong * 120 + CRes.random_Am_0(20);
							int yTo = this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 3 * 2 + 10 - this.objFireMain.hOne / 2 + CRes.random_Am_0(80);
							GameScreen.addEffectEnd_ToX_ToY(13, (int)((sbyte)num8), this.objFireMain.x + num7, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 3 * 2 + 10, xTo, yTo, this.Dir, this.objMainEff);
						}
						for (int j = 0; j < this.VecSubEff.size(); j++)
						{
							Point point2 = (Point)this.VecSubEff.elementAt(j);
							bool flag21 = CRes.random(3) == 0;
							if (flag21)
							{
								int num9 = -20;
								bool flag22 = this.Dir == 2;
								if (flag22)
								{
									num9 = 20;
								}
								int xTo2 = point2.x + num7 + num9 + this.am_duong * 120 + CRes.random_Am_0(20);
								int yTo2 = point2.y - this.objFireMain.hOne / 2 + CRes.random_Am_0(80);
								GameScreen.addEffectEnd_ToX_ToY(13, (int)((sbyte)num8), point2.x + num7 + num9, point2.y - this.objFireMain.hOne / 2, xTo2, yTo2, this.Dir, this.objMainEff);
							}
						}
					}
				}
				this.addVir(15, 5, 10, true);
			}
			for (int k = 0; k < this.VecSubEff.size(); k++)
			{
				Point point3 = (Point)this.VecSubEff.elementAt(k);
				point3.f++;
			}
			for (int l = 0; l < this.VecEff.size(); l++)
			{
				Point point4 = (Point)this.VecEff.elementAt(l);
				point4.f++;
				bool flag23 = point4.f >= 3;
				if (flag23)
				{
					this.VecEff.removeElement(point4);
					l--;
				}
			}
		}
	}

	// Token: 0x060002FF RID: 767 RVA: 0x000609BC File Offset: 0x0005EBBC
	public void updateLuffyS3_L5()
	{
		bool flag = (this.f >= this.fRemove && this.VecEff.size() == 0) || this.checkNullObject(1);
		if (flag)
		{
			this.removeEff();
		}
		else
		{
			bool flag2 = this.f < 4;
			if (flag2)
			{
				this.objFireMain.vx = -(this.am_duong * 7);
				this.objFireMain.dy += 20 - this.f * 3;
			}
			else
			{
				bool flag3 = this.f < this.fRemove - 3;
				if (flag3)
				{
					this.objFireMain.dy = 60;
					this.objFireMain.vx = 0;
				}
				else
				{
					bool flag4 = this.objFireMain.dy <= 10;
					if (flag4)
					{
						this.objFireMain.dy = 0;
					}
					bool flag5 = this.objFireMain.dy != 0;
					if (flag5)
					{
						this.objFireMain.dy /= 3;
					}
				}
			}
			bool flag6 = this.f == 5;
			if (flag6)
			{
				int num = 40;
				bool flag7 = this.Dir == 2;
				if (flag7)
				{
					num = -40;
				}
				Point o = new Point(this.objFireMain.x + num, this.objFireMain.y - this.objFireMain.dy);
				this.VecSubEff.addElement(o);
			}
			bool flag8 = this.typeEffect == 273;
			if (flag8)
			{
				bool flag9 = this.f == 10;
				if (flag9)
				{
					int num2 = 15;
					bool flag10 = this.Dir == 2;
					if (flag10)
					{
						num2 = -15;
					}
					Point o2 = new Point(this.objFireMain.x + num2, this.objFireMain.y - this.objFireMain.dy - 45);
					this.VecSubEff.addElement(o2);
					Point o3 = new Point(this.objFireMain.x + num2, this.objFireMain.y - this.objFireMain.dy + 45);
					this.VecSubEff.addElement(o3);
				}
				bool flag11 = this.f == 15;
				if (flag11)
				{
					int num3 = 40;
					bool flag12 = this.Dir == 2;
					if (flag12)
					{
						num3 = -40;
					}
					Point o4 = new Point(this.objFireMain.x + num3, this.objFireMain.y - this.objFireMain.dy - 90);
					this.VecSubEff.addElement(o4);
					Point o5 = new Point(this.objFireMain.x + num3, this.objFireMain.y - this.objFireMain.dy + 90);
					this.VecSubEff.addElement(o5);
				}
			}
			else
			{
				bool flag13 = this.f == 10;
				if (flag13)
				{
					int num4 = 15;
					bool flag14 = this.Dir == 2;
					if (flag14)
					{
						num4 = -15;
					}
					Point o6 = new Point(this.objFireMain.x + num4, this.objFireMain.y - this.objFireMain.dy - 45);
					this.VecSubEff.addElement(o6);
				}
				bool flag15 = this.f == 15;
				if (flag15)
				{
					int num5 = 15;
					bool flag16 = this.Dir == 2;
					if (flag16)
					{
						num5 = -15;
					}
					Point o7 = new Point(this.objFireMain.x + num5, this.objFireMain.y - this.objFireMain.dy + 45);
					this.VecSubEff.addElement(o7);
				}
			}
			bool flag17 = (this.f == 22 || this.f == 25) && this.isAddSound;
			if (flag17)
			{
				mSound.playSound(4, mSound.volumeSound);
			}
			bool flag18 = this.f >= 18;
			if (flag18)
			{
				bool flag19 = this.f % 3 == 0;
				if (flag19)
				{
					bool flag20 = this.indexObjBefire < this.vecObjsBeFire.size();
					if (flag20)
					{
						Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(this.indexObjBefire);
						this.indexObjBefire++;
						bool flag21 = object_Effect_Skill != null;
						if (flag21)
						{
							MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
							bool flag22 = mainObject != null;
							if (flag22)
							{
								sbyte dir = 0;
								bool flag23 = this.objFireMain.x < mainObject.x;
								if (flag23)
								{
									dir = 2;
								}
								int num6 = 12;
								bool flag24 = this.Dir == 0;
								if (flag24)
								{
									num6 = -12;
								}
								int num7 = 4;
								bool flag25 = this.typeEffect == 273;
								if (flag25)
								{
									num7 = 5;
								}
								GameScreen.addEffectEnd_ObjTo(13, num7, this.objFireMain.x + num6, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 3 * 2 + 10, mainObject.ID, mainObject.typeObject, dir, this.objMainEff);
								for (int i = 0; i < this.VecSubEff.size(); i++)
								{
									Point point = (Point)this.VecSubEff.elementAt(i);
									int num8 = -20;
									bool flag26 = this.Dir == 2;
									if (flag26)
									{
										num8 = 20;
									}
									GameScreen.addEffectEnd_ObjTo(13, num7, point.x + num6 + num8, point.y - this.objFireMain.hOne / 2, mainObject.ID, mainObject.typeObject, dir, this.objMainEff);
								}
							}
						}
					}
					else
					{
						bool flag27 = !GameCanvas.lowGraphic;
						if (flag27)
						{
							int num9 = 12;
							bool flag28 = this.Dir == 0;
							if (flag28)
							{
								num9 = -12;
							}
							int num10 = 4;
							bool flag29 = this.typeEffect == 273;
							if (flag29)
							{
								num10 = 5;
							}
							bool flag30 = CRes.random(3) == 0;
							if (flag30)
							{
								int xTo = this.objFireMain.x + num9 + this.am_duong * 120 + CRes.random_Am_0(20);
								int yTo = this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 3 * 2 + 10 - this.objFireMain.hOne / 2 + CRes.random_Am_0(80);
								GameScreen.addEffectEnd_ToX_ToY(13, (int)((sbyte)num10), this.objFireMain.x + num9, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 3 * 2 + 10, xTo, yTo, this.Dir, this.objMainEff);
							}
							for (int j = 0; j < this.VecSubEff.size(); j++)
							{
								Point point2 = (Point)this.VecSubEff.elementAt(j);
								bool flag31 = CRes.random(3) == 0;
								if (flag31)
								{
									int num11 = -20;
									bool flag32 = this.Dir == 2;
									if (flag32)
									{
										num11 = 20;
									}
									int xTo2 = point2.x + num9 + num11 + this.am_duong * 120 + CRes.random_Am_0(20);
									int yTo2 = point2.y - this.objFireMain.hOne / 2 + CRes.random_Am_0(80);
									GameScreen.addEffectEnd_ToX_ToY(13, (int)((sbyte)num10), point2.x + num9 + num11, point2.y - this.objFireMain.hOne / 2, xTo2, yTo2, this.Dir, this.objMainEff);
								}
							}
						}
					}
				}
				this.addVir(15, 5, 10, true);
			}
			for (int k = 0; k < this.VecSubEff.size(); k++)
			{
				Point point3 = (Point)this.VecSubEff.elementAt(k);
				point3.f++;
			}
			for (int l = 0; l < this.VecEff.size(); l++)
			{
				Point point4 = (Point)this.VecEff.elementAt(l);
				point4.f++;
				bool flag33 = point4.f >= 3;
				if (flag33)
				{
					this.VecEff.removeElement(point4);
					l--;
				}
			}
		}
	}

	// Token: 0x06000300 RID: 768 RVA: 0x00061240 File Offset: 0x0005F440
	public void updateLuffyS2_NEW()
	{
		bool flag = this.f >= this.fRemove || this.checkNullObject(1);
		if (flag)
		{
			this.removeEff();
			bool flag2 = this.objFireMain == GameScreen.player;
			if (flag2)
			{
				GameScreen.setIsMoveEff(true);
			}
		}
		else
		{
			bool flag3 = this.f >= 12 && this.f <= 20;
			if (flag3)
			{
				this.objFireMain.isTanHinh = true;
				bool flag4 = this.objFireMain == GameScreen.player;
				if (flag4)
				{
					Player.isSendMove = false;
				}
			}
			else
			{
				this.objFireMain.isTanHinh = false;
			}
			bool flag5 = this.f == 16;
			if (flag5)
			{
				int num = 220;
				bool flag6 = this.Dir == 0;
				if (flag6)
				{
					num = -220;
				}
				this.objFireMain.x += num;
				this.x = this.objFireMain.x;
				this.Dir = ((this.Dir == 0) ? 2 : 0);
				this.objFireMain.Dir = (int)this.Dir;
			}
			bool flag7 = this.f == 12;
			if (flag7)
			{
				base.setDy(-10, this.objBeFireMain);
				int num2 = 20;
				bool flag8 = this.Dir == 0;
				if (flag8)
				{
					num2 = -20;
				}
				GameScreen.addEffectEnd(0, 0, this.objFireMain.x + num2, this.objFireMain.y - this.objFireMain.hOne / 2 + 2, this.Dir, this.objMainEff);
				bool flag9 = this.isAddSound;
				if (flag9)
				{
					mSound.playSound(3, mSound.volumeSound);
				}
			}
			bool flag10 = this.f == 29;
			if (flag10)
			{
				this.addVir(5, 5, 10, true);
				base.setAva(2, this.objBeFireMain);
				int num3 = 20;
				bool flag11 = this.Dir == 0;
				if (flag11)
				{
					num3 = -20;
				}
				bool flag12 = !this.checkNullObject(2);
				if (flag12)
				{
					GameScreen.addEffectEnd(8, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
				}
				GameScreen.addEffectEnd(0, 0, this.objFireMain.x + num3, this.objFireMain.y - this.objFireMain.hOne / 2 + 2, this.Dir, this.objMainEff);
				bool flag13 = this.isAddSound;
				if (flag13)
				{
					mSound.playSound(3, mSound.volumeSound);
				}
			}
			bool flag14 = this.f <= 20;
			if (!flag14)
			{
				bool flag15 = this.f < 27;
				if (flag15)
				{
					bool flag16 = this.Dir == 0;
					if (flag16)
					{
						this.objFireMain.vx = -this.objFireMain.vMax * 4;
					}
					else
					{
						this.objFireMain.vx = this.objFireMain.vMax * 4;
					}
					bool flag17 = this.f % 2 == 0 || this.typeEffect == 35;
					if (flag17)
					{
						Point o = new Point(this.objFireMain.x - this.objFireMain.vx / 2, this.objFireMain.y);
						this.VecEff.addElement(o);
					}
				}
				else
				{
					bool flag18 = this.objFireMain == GameScreen.player;
					if (flag18)
					{
						Player.isSendMove = true;
					}
					this.objFireMain.vx = 0;
				}
				for (int i = 0; i < this.VecEff.size(); i++)
				{
					Point point = (Point)this.VecEff.elementAt(i);
					point.f++;
					bool flag19 = point.f / 2 >= 3;
					if (flag19)
					{
						this.VecEff.removeElement(point);
						i--;
					}
				}
			}
		}
	}

	// Token: 0x06000301 RID: 769 RVA: 0x00061644 File Offset: 0x0005F844
	public void updateLuffyS2_NEW_SHORT()
	{
		bool flag = (this.f >= this.fRemove && (this.typeEffect != 213 || this.typeEffect == 272 || this.VecSubEff.size() == 0)) || this.checkNullObject(1);
		if (flag)
		{
			this.removeEff();
			bool flag2 = this.objFireMain == GameScreen.player;
			if (flag2)
			{
				GameScreen.setIsMoveEff(true);
			}
		}
		else
		{
			bool flag3 = this.f >= 4 && this.f <= 11;
			if (flag3)
			{
				this.objFireMain.isTanHinh = true;
				bool flag4 = this.objFireMain == GameScreen.player;
				if (flag4)
				{
					Player.isSendMove = false;
				}
			}
			else
			{
				this.objFireMain.isTanHinh = false;
			}
			bool flag5 = this.f == 7;
			if (flag5)
			{
				int num = 220;
				bool flag6 = this.Dir == 0;
				if (flag6)
				{
					num = -220;
				}
				this.objFireMain.x += num;
				this.x = this.objFireMain.x;
				this.Dir = ((this.Dir == 0) ? 2 : 0);
				this.objFireMain.Dir = (int)this.Dir;
			}
			bool flag7 = this.f == 3;
			if (flag7)
			{
				base.setDy(-10, this.objBeFireMain);
				int num2 = 20;
				bool flag8 = this.Dir == 0;
				if (flag8)
				{
					num2 = -20;
				}
				GameScreen.addEffectEnd(0, 0, this.objFireMain.x + num2, this.objFireMain.y - this.objFireMain.hOne / 2 + 2, this.Dir, this.objMainEff);
				bool flag9 = this.isAddSound;
				if (flag9)
				{
					mSound.playSound(3, mSound.volumeSound);
				}
			}
			bool flag10 = this.f == 20;
			if (flag10)
			{
				this.addVir(5, 5, 10, true);
				base.setAva(2, this.objBeFireMain);
				int num3 = 20;
				bool flag11 = this.Dir == 0;
				if (flag11)
				{
					num3 = -20;
				}
				bool flag12 = !this.checkNullObject(2);
				if (flag12)
				{
					GameScreen.addEffectEnd(8, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
					int subtype = 5;
					bool flag13 = this.typeEffect == 272;
					if (flag13)
					{
						subtype = 3;
					}
					GameScreen.addEffectEnd(108, subtype, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
				}
				bool flag14 = !this.checkNullObject(1);
				if (flag14)
				{
					GameScreen.addEffectEnd(0, 0, this.objFireMain.x + num3, this.objFireMain.y - this.objFireMain.hOne / 2 + 2, this.Dir, this.objMainEff);
					bool flag15 = this.typeEffect == 181 || this.typeEffect == 213 || this.typeEffect == 272;
					if (flag15)
					{
						num3 = 10;
						bool flag16 = this.Dir == 0;
						if (flag16)
						{
							num3 = -10;
						}
						int subtype2 = 0;
						bool flag17 = this.typeEffect == 213;
						if (flag17)
						{
							subtype2 = 3;
						}
						else
						{
							bool flag18 = this.typeEffect == 272;
							if (flag18)
							{
								subtype2 = 4;
							}
						}
						GameScreen.addEffectEnd(119, subtype2, this.objFireMain.x + num3, this.objFireMain.y - this.objFireMain.hOne / 2 + 2, this.Dir, this.objMainEff);
					}
				}
				bool flag19 = this.isAddSound;
				if (flag19)
				{
					mSound.playSound(3, mSound.volumeSound);
				}
			}
			bool flag20 = this.f == 22 && this.typeEffect == 272;
			if (flag20)
			{
				int num4 = 10;
				bool flag21 = this.Dir == 0;
				if (flag21)
				{
					num4 = -10;
				}
				GameScreen.addEffectEnd(173, 0, this.objFireMain.x + num4, this.objFireMain.y - this.objFireMain.hOne / 2 + 2, this.Dir, this.objMainEff);
			}
			bool flag22 = this.f <= 11;
			if (!flag22)
			{
				bool flag23 = this.f < 18;
				if (flag23)
				{
					bool flag24 = this.Dir == 0;
					if (flag24)
					{
						this.objFireMain.vx = -this.objFireMain.vMax * 4;
					}
					else
					{
						this.objFireMain.vx = this.objFireMain.vMax * 4;
					}
					bool flag25 = this.f % 2 == 0 || this.typeEffect == 35;
					if (flag25)
					{
						Point o = new Point(this.objFireMain.x - this.objFireMain.vx / 2, this.objFireMain.y);
						this.VecEff.addElement(o);
					}
					bool flag26 = !this.checkNullObject(1);
					if (flag26)
					{
						GameScreen.addEffectEnd(109, 0, this.objFireMain.x, this.objFireMain.y + 5, this.Dir, this.objMainEff);
					}
					bool flag27 = this.typeEffect == 213 || this.typeEffect == 272;
					if (flag27)
					{
						Point point = new Point(this.objFireMain.x, this.objFireMain.y + 2);
						point.frame = (this.f - 12) / 2;
						bool flag28 = point.frame >= this.fraImgSub3Eff.nFrame;
						if (flag28)
						{
							point.frame = this.fraImgSub3Eff.nFrame - 1;
						}
						this.VecSubEff.addElement(point);
					}
				}
				else
				{
					bool flag29 = this.objFireMain == GameScreen.player;
					if (flag29)
					{
						Player.isSendMove = true;
					}
					this.objFireMain.vx = 0;
				}
				for (int i = 0; i < this.VecEff.size(); i++)
				{
					Point point2 = (Point)this.VecEff.elementAt(i);
					point2.f++;
					bool flag30 = point2.f / 2 >= 3;
					if (flag30)
					{
						this.VecEff.removeElement(point2);
						i--;
					}
				}
				bool flag31 = this.typeEffect != 213 && this.typeEffect != 272;
				if (!flag31)
				{
					for (int j = 0; j < this.VecSubEff.size(); j++)
					{
						Point point3 = (Point)this.VecSubEff.elementAt(j);
						point3.f++;
						bool flag32 = point3.f >= 5;
						if (flag32)
						{
							this.VecSubEff.removeElementAt(j);
							j--;
						}
					}
				}
			}
		}
	}

	// Token: 0x06000302 RID: 770 RVA: 0x00061D84 File Offset: 0x0005FF84
	public void updateMon11()
	{
		bool flag = !this.checkNullObject(1);
		if (flag)
		{
			bool flag2 = this.f < 2;
			if (flag2)
			{
				this.objFireMain.vx = this.vx1000;
			}
			else
			{
				bool flag3 = this.f < 5;
				if (flag3)
				{
					this.objFireMain.vx = -this.vx1000;
				}
				else
				{
					this.objFireMain.vx = 0;
				}
			}
		}
		bool flag4 = this.f == this.fRemove;
		if (flag4)
		{
			bool flag5 = !this.checkNullObject(1);
			if (flag5)
			{
				this.objFireMain.vx = 0;
			}
			bool flag6 = this.typeEffect == 144;
			if (flag6)
			{
				GameScreen.addEffectEnd(11, 0, this.toX + CRes.random_Am_0(5), this.toY + CRes.random_Am_0(10), this.Dir, this.objMainEff);
				base.setAva(0, this.objBeFireMain);
			}
			else
			{
				GameScreen.addEffectEnd(1, 0, this.toX + CRes.random_Am_0(15), this.toY + CRes.random_Am_0(15), this.Dir, this.objMainEff);
			}
			bool flag7 = this.fRemove >= 4;
			if (flag7)
			{
				bool flag8 = !this.checkNullObject(1);
				if (flag8)
				{
					this.objFireMain.vx = 0;
				}
				this.removeEff();
			}
		}
		bool flag9 = this.fRemove < 4 && this.f == 4;
		if (flag9)
		{
			bool flag10 = !this.checkNullObject(1);
			if (flag10)
			{
				this.objFireMain.vx = 0;
			}
			this.removeEff();
		}
	}

	// Token: 0x06000303 RID: 771 RVA: 0x00061F2C File Offset: 0x0006012C
	public void updateMon10()
	{
		bool flag = !this.checkNullObject(1);
		if (flag)
		{
			bool flag2 = this.f < 2;
			if (flag2)
			{
				this.objFireMain.vx = this.vx;
			}
			else
			{
				this.objFireMain.vx = -this.vx;
			}
		}
		bool flag3 = this.f >= this.fRemove;
		if (flag3)
		{
			bool flag4 = !this.checkNullObject(1);
			if (flag4)
			{
				this.objFireMain.vx = 0;
			}
			bool flag5 = this.typeEffect == 149;
			if (flag5)
			{
				GameScreen.addEffectEnd(8, 0, this.toX + CRes.random_Am_0(5), this.toY + CRes.random_Am_0(10), this.Dir, this.objMainEff);
				base.setAva(0, this.objBeFireMain);
			}
			else
			{
				bool flag6 = this.typeEffect == 143;
				if (flag6)
				{
					GameScreen.addEffectEnd(11, 0, this.toX + CRes.random_Am_0(5), this.toY + CRes.random_Am_0(10), this.Dir, this.objMainEff);
					base.setAva(0, this.objBeFireMain);
				}
				else
				{
					GameScreen.addEffectEnd(1, 0, this.toX + CRes.random_Am_0(15), this.toY + CRes.random_Am_0(15), this.Dir, this.objMainEff);
				}
			}
			this.removeEff();
		}
	}

	// Token: 0x06000304 RID: 772 RVA: 0x0006209C File Offset: 0x0006029C
	public void updateAlvida2()
	{
		bool flag = this.f == 7;
		if (flag)
		{
			this.addSound(14);
			int num = this.x;
			num = ((this.Dir != 0) ? (num + 15) : (num - 15));
			GameScreen.addEffectEnd(89, 0, num, this.y + 20, this.Dir, this.objMainEff);
		}
		bool flag2 = this.f >= 7;
		if (flag2)
		{
			this.vy = 6;
		}
		bool flag3 = this.f < this.fRemove;
		if (!flag3)
		{
			this.addVir(3, 5, 10, false);
			for (int i = 0; i < this.vecObjsBeFire.size(); i++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(i);
				bool flag4 = object_Effect_Skill != null;
				if (flag4)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					bool flag5 = mainObject != null;
					if (flag5)
					{
						GameScreen.addEffectEnd(52, 0, mainObject.x, mainObject.y + 10, this.Dir, this.objMainEff);
						GameScreen.addEffectEnd(8, 0, mainObject.x, mainObject.y - mainObject.hOne / 2, this.Dir, this.objMainEff);
					}
				}
			}
			this.removeEff();
		}
	}

	// Token: 0x06000305 RID: 773 RVA: 0x000621FC File Offset: 0x000603FC
	public void updateUssopS3_L5()
	{
		bool flag = this.f == 1;
		if (flag)
		{
			this.mframeSuper = new int[][]
			{
				new int[]
				{
					34,
					-30,
					1
				},
				new int[]
				{
					67,
					-44,
					1
				},
				new int[]
				{
					100,
					-42,
					2
				},
				new int[]
				{
					126,
					-17,
					1
				}
			};
		}
		bool flag2 = this.f == 10 && !this.checkNullObject(3);
		if (flag2)
		{
			int num = this.toX - this.x;
			int num2 = this.toY - this.objBeFireMain.hOne - this.y - 50;
			base.create_Speed(num, num2, null);
			int frameAngle = CRes.angle(num, num2);
			this.frame = base.setFrameAngle(frameAngle);
			this.fRemove += 10;
		}
		bool flag3 = this.f == this.fRemove;
		if (flag3)
		{
			this.addVir(5, 5, 10, true);
			GameScreen.addEffectEnd(120, 0, this.x, this.y, this.Dir, this.objMainEff);
			for (int i = 0; i < this.vecObjsBeFire.size(); i++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(i);
				bool flag4 = object_Effect_Skill != null;
				if (flag4)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					bool flag5 = mainObject != null;
					if (flag5)
					{
						GameScreen.addEffectEnd(93, 2, mainObject.x + CRes.random_Am_0(10), mainObject.y - mainObject.hOne + CRes.random_Am_0(10), this.Dir, this.objMainEff);
					}
				}
			}
			this.indexObjBefire = 0;
			this.vx = 0;
			this.vy = 0;
		}
		bool flag6 = this.f <= this.fRemove || this.f % 2 != 1;
		if (!flag6)
		{
			bool flag7 = !GameCanvas.lowGraphic;
			if (flag7)
			{
				for (int j = 0; j < 2; j++)
				{
					GameScreen.addEffectEnd(120, this.mframeSuper[this.indexObjBefire][2], this.x + this.mframeSuper[this.indexObjBefire][0] * ((j == 0) ? 1 : -1), this.y + this.mframeSuper[this.indexObjBefire][1], this.Dir, this.objMainEff);
				}
			}
			this.indexObjBefire++;
			bool flag8 = this.indexObjBefire >= this.mframeSuper.Length;
			if (flag8)
			{
				this.removeEff();
			}
		}
	}

	// Token: 0x06000306 RID: 774 RVA: 0x000624CC File Offset: 0x000606CC
	public void updateUssopS3_L6()
	{
		bool flag = this.f == 1;
		if (flag)
		{
			this.mframeSuper = new int[][]
			{
				new int[]
				{
					40,
					-60,
					CRes.random(2, 4)
				},
				new int[]
				{
					80,
					-25,
					CRes.random(1, 3)
				},
				new int[]
				{
					120,
					-60,
					CRes.random(2, 4)
				},
				new int[]
				{
					160,
					-25,
					CRes.random(2, 4)
				}
			};
		}
		bool flag2 = this.f == 10 && !this.checkNullObject(3);
		if (flag2)
		{
			int num = this.toX - this.x;
			int num2 = this.toY - this.objBeFireMain.hOne - this.y - 50;
			base.create_Speed(num, num2, null);
			int frameAngle = CRes.angle(num, num2);
			this.frame = base.setFrameAngle(frameAngle);
			this.fRemove += 10;
			this.vMax = 14;
			this.rocket1 = base.create_Speed(this.toX + 80 - this.x, num2, new Point_Focus());
			this.rocket2 = base.create_Speed(this.toX - 80 - this.x, num2, new Point_Focus());
			frameAngle = CRes.angle(this.toX + 80 - this.x, num2);
			this.frame1 = base.setFrameAngle(frameAngle);
			frameAngle = CRes.angle(this.toX - 80 - this.x, num2);
			this.frame2 = base.setFrameAngle(frameAngle);
		}
		bool flag3 = this.f > 10 && this.f < this.fRemove;
		if (flag3)
		{
			this.rocket1.update_Vx_Vy();
			this.rocket2.update_Vx_Vy();
		}
		bool flag4 = this.f == this.fRemove;
		if (flag4)
		{
			this.addVir(5, 5, 10, true);
			GameScreen.addEffectEnd(168, 1, this.x, this.y, this.Dir, this.objMainEff);
			for (int i = 0; i < this.vecObjsBeFire.size(); i++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(i);
				bool flag5 = object_Effect_Skill != null;
				if (flag5)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					bool flag6 = mainObject != null;
					if (flag6)
					{
						GameScreen.addEffectEnd(93, 2, mainObject.x + CRes.random_Am_0(10), mainObject.y - mainObject.hOne + CRes.random_Am_0(10), this.Dir, this.objMainEff);
					}
				}
			}
			this.indexObjBefire = 0;
			this.vx = 0;
			this.vy = 0;
		}
		bool flag7 = this.f <= this.fRemove || this.f % 2 != 1;
		if (!flag7)
		{
			bool flag8 = !GameCanvas.lowGraphic;
			if (flag8)
			{
				for (int j = 0; j < 2; j++)
				{
					GameScreen.addEffectEnd(168, this.mframeSuper[this.indexObjBefire][2], this.x + this.mframeSuper[this.indexObjBefire][0] * ((j == 0) ? 1 : -1), this.y + this.mframeSuper[this.indexObjBefire][1], this.Dir, this.objMainEff);
				}
			}
			this.indexObjBefire++;
			bool flag9 = this.indexObjBefire >= this.mframeSuper.Length;
			if (flag9)
			{
				this.removeEff();
			}
		}
	}

	// Token: 0x06000307 RID: 775 RVA: 0x000628A0 File Offset: 0x00060AA0
	public void updateUssopSkill3()
	{
		bool flag = this.f == 10 && !this.checkNullObject(3);
		if (flag)
		{
			int num = this.toX - this.x;
			int num2 = this.toY - this.objBeFireMain.hOne - this.y - 30;
			base.create_Speed(num, num2, null);
			int frameAngle = CRes.angle(num, num2);
			this.frame = base.setFrameAngle(frameAngle);
			bool flag2 = this.typeEffect != 69 && this.typeEffect != 194;
			if (flag2)
			{
				GameScreen.addEffectEnd(5, 0, this.x, this.y, this.Dir, this.objMainEff);
			}
			this.fRemove += 10;
		}
		bool flag3 = this.f < this.fRemove;
		if (!flag3)
		{
			sbyte subtype = 0;
			bool flag4 = this.typeEffect == 68;
			if (flag4)
			{
				subtype = 1;
			}
			else
			{
				bool flag5 = this.typeEffect == 69;
				if (flag5)
				{
					this.addVir(5, 5, 10, true);
					subtype = 2;
					GameScreen.addEffectEnd(48, 0, this.x - 30 + CRes.random_Am_0(10), this.y - 30 + CRes.random_Am_0(10), this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(48, 0, this.x + 30 + CRes.random_Am_0(10), this.y - 30 + CRes.random_Am_0(10), this.Dir, this.objMainEff);
				}
				else
				{
					bool flag6 = this.typeEffect == 194;
					if (flag6)
					{
						this.addVir(5, 5, 10, true);
						subtype = 2;
						GameScreen.addEffectEnd(120, 0, this.x - 30 + CRes.random_Am_0(10), this.y - 30 + CRes.random_Am_0(10), this.Dir, this.objMainEff);
						GameScreen.addEffectEnd(120, 0, this.x + 30 + CRes.random_Am_0(10), this.y - 30 + CRes.random_Am_0(10), this.Dir, this.objMainEff);
						GameScreen.addEffectEnd(120, 0, this.x - 60 + CRes.random_Am_0(10), this.y + CRes.random_Am_0(10), this.Dir, this.objMainEff);
						GameScreen.addEffectEnd(120, 0, this.x + 60 + CRes.random_Am_0(10), this.y + CRes.random_Am_0(10), this.Dir, this.objMainEff);
					}
				}
			}
			GameScreen.addEffectEnd(48, (int)subtype, this.x, this.y, this.Dir, this.objMainEff);
			for (int i = 0; i < this.vecObjsBeFire.size(); i++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(i);
				bool flag7 = object_Effect_Skill == null;
				if (!flag7)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					bool flag8 = mainObject == null;
					if (!flag8)
					{
						bool flag9 = this.typeEffect == 67;
						if (flag9)
						{
							bool flag10 = this.isAddSound;
							if (flag10)
							{
								mSound.playSound(14, mSound.volumeSound);
							}
							base.setAva(0, mainObject);
							GameScreen.addEffectEnd(1, 0, mainObject.x, mainObject.y - mainObject.hOne / 2, this.Dir, this.objMainEff);
						}
						else
						{
							bool flag11 = this.typeEffect == 68;
							if (flag11)
							{
								bool flag12 = this.isAddSound;
								if (flag12)
								{
									mSound.playSound(14, mSound.volumeSound);
								}
								base.setAva(1, mainObject);
								GameScreen.addEffectEnd(1, 0, mainObject.x + CRes.random_Am_0(10), mainObject.y - mainObject.hOne / 2 + CRes.random_Am_0(10), this.Dir, this.objMainEff);
								GameScreen.addEffectEnd(1, 0, mainObject.x + CRes.random_Am_0(10), mainObject.y - mainObject.hOne / 2 + CRes.random_Am_0(10), this.Dir, this.objMainEff);
							}
							else
							{
								bool flag13 = this.typeEffect == 69;
								if (flag13)
								{
									bool flag14 = this.isAddSound;
									if (flag14)
									{
										mSound.playSound(15, mSound.volumeSound);
									}
									bool flag15 = i == 0;
									if (flag15)
									{
										base.setAva(2, mainObject);
									}
									else
									{
										GameScreen.addEffectEnd_ObjTo(49, 0, this.x, this.y, mainObject.ID, mainObject.typeObject, this.Dir, this.objMainEff);
									}
								}
							}
						}
						GameScreen.addEffectEnd(93, 2, mainObject.x + CRes.random_Am_0(10), mainObject.y - mainObject.hOne / 2 + CRes.random_Am_0(10), this.Dir, this.objMainEff);
					}
				}
			}
			this.removeEff();
		}
	}

	// Token: 0x06000308 RID: 776 RVA: 0x00062DA0 File Offset: 0x00060FA0
	public void updateMohji_1()
	{
		bool flag = this.f >= this.fRemove || this.checkNullObject(1);
		if (flag)
		{
			bool flag2 = !this.checkNullObject(1);
			if (flag2)
			{
				this.objFireMain.isTanHinh = false;
			}
			this.removeEff();
		}
		else
		{
			bool flag3 = (this.f >= 3 && this.f <= 11) || (this.f >= 26 && this.f <= 30);
			if (flag3)
			{
				this.objFireMain.isTanHinh = true;
			}
			else
			{
				this.objFireMain.isTanHinh = false;
			}
			bool flag4 = this.f == 8;
			if (flag4)
			{
				int num = 20;
				bool flag5 = this.Dir == 2;
				if (flag5)
				{
					num = -20;
				}
				this.objFireMain.x = this.toX + num;
				this.objFireMain.y = this.toY;
			}
			bool flag6 = this.f == 12 || this.f == 16;
			if (flag6)
			{
				this.addSound(7);
			}
			bool flag7 = this.f == 12;
			if (flag7)
			{
				GameScreen.addEffectEnd(1, 0, this.toX + CRes.random_Am_0(10), this.toY - 5 + CRes.random_Am_0(10), this.Dir, this.objMainEff);
			}
			bool flag8 = this.f == 20;
			if (flag8)
			{
				GameScreen.addEffectEnd(1, 0, this.toX + CRes.random_Am_0(10), this.toY - 5 + CRes.random_Am_0(10), this.Dir, this.objMainEff);
				base.setAva(0, this.objBeFireMain);
			}
			bool flag9 = this.f == 30;
			if (flag9)
			{
				this.objFireMain.x = this.x;
				this.objFireMain.y = this.y;
			}
		}
	}

	// Token: 0x06000309 RID: 777 RVA: 0x00062F84 File Offset: 0x00061184
	public void updateMohji_2()
	{
		bool flag = this.f == 2;
		if (flag)
		{
			this.addSound(7);
			GameScreen.addEffectEnd(1, 0, this.toX + CRes.random_Am_0(10), this.toY + CRes.random_Am_0(10), this.Dir, this.objMainEff);
			base.setAva(0, this.objBeFireMain);
		}
		bool flag2 = this.f == 6;
		if (flag2)
		{
			GameScreen.addEffectEnd(1, 0, this.toX + CRes.random_Am_0(10), this.toY + CRes.random_Am_0(10), this.Dir, this.objMainEff);
			base.setAva(0, this.objBeFireMain);
		}
		bool flag3 = this.f >= this.fRemove;
		if (flag3)
		{
			this.removeEff();
		}
	}

	// Token: 0x0600030A RID: 778 RVA: 0x00063054 File Offset: 0x00061254
	public void updateBuggy_1()
	{
		bool flag = this.f == 2;
		if (flag)
		{
			this.addSound(19);
			bool flag2 = !this.checkNullObject(1) && this.objFireMain.plashNow != null;
			if (flag2)
			{
				this.objFireMain.plashNow.setIsNextf(1);
			}
			Point_Focus point_Focus = new Point_Focus();
			int xdich = this.toX - this.x;
			int ydich = this.toY - this.y;
			point_Focus.Dir = this.Dir;
			point_Focus.frame = 1;
			base.create_Speed(xdich, ydich, point_Focus);
			this.VecEff.addElement(point_Focus);
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus2 = (Point_Focus)this.VecEff.elementAt(i);
			point_Focus2.update_Vx_Vy();
			bool flag3 = point_Focus2.f >= point_Focus2.fRe;
			if (flag3)
			{
				bool flag4 = point_Focus2.frame == 1;
				if (flag4)
				{
					this.addSound(7);
					Point_Focus point_Focus3 = new Point_Focus();
					GameScreen.addEffectEnd(1, 0, this.toX, this.toY, this.Dir, this.objMainEff);
					base.setAva(1, this.objBeFireMain);
					int x = this.x;
					int y = this.y;
					this.x = this.toX;
					this.y = this.toY;
					this.toX = x;
					this.toY = y;
					int xdich2 = this.toX - this.x;
					int ydich2 = this.toY - this.y;
					point_Focus3.Dir = this.Dir;
					point_Focus3.frame = 2;
					base.create_Speed(xdich2, ydich2, point_Focus3);
					this.VecEff.addElement(point_Focus3);
				}
				this.VecEff.removeElement(point_Focus2);
				i--;
			}
		}
		bool flag5 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag5)
		{
			bool flag6 = !this.checkNullObject(1) && this.objFireMain.plashNow != null;
			if (flag6)
			{
				this.objFireMain.plashNow.setIsNextf(0);
			}
			this.removeEff();
		}
	}

	// Token: 0x0600030B RID: 779 RVA: 0x000632B0 File Offset: 0x000614B0
	public void updateBuggy_2()
	{
		bool flag = this.f == 18;
		if (flag)
		{
			GameScreen.addEffectEnd(30, 0, this.x1000, this.y1000, 300, this.Dir, this.objMainEff);
		}
		bool flag2 = this.f == 28;
		if (flag2)
		{
			this.addSound(15);
			this.addVir(2, 6, 10, false);
			Point_Focus point_Focus = new Point_Focus();
			int xdich = -260;
			bool flag3 = this.Dir == 2;
			if (flag3)
			{
				xdich = 260;
			}
			point_Focus = base.create_Speed(xdich, 0, point_Focus);
			point_Focus.y = this.y1000;
			this.VecEff.addElement(point_Focus);
		}
		bool flag4 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag4)
		{
			this.removeEff();
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus2 = (Point_Focus)this.VecEff.elementAt(i);
			point_Focus2.update_Vx_Vy();
			bool flag5 = point_Focus2.f >= point_Focus2.fRe;
			if (flag5)
			{
				this.VecEff.removeElement(point_Focus2);
				i--;
			}
		}
		bool flag6 = this.f <= 28;
		if (!flag6)
		{
			this.addSound(19);
			bool flag7 = this.f % 2 != 0 || this.indexObjBefire >= this.vecObjsBeFire.size();
			if (!flag7)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(this.indexObjBefire);
				this.indexObjBefire++;
				bool flag8 = object_Effect_Skill != null;
				if (flag8)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					bool flag9 = mainObject != null;
					if (flag9)
					{
						base.setAva(1, mainObject);
						GameScreen.addEffectEnd(48, 1, mainObject.x, mainObject.y - mainObject.hOne / 2, this.Dir, this.objMainEff);
					}
				}
			}
		}
	}

	// Token: 0x0600030C RID: 780 RVA: 0x000634D8 File Offset: 0x000616D8
	public void updateCabaji_1()
	{
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(i);
			point_Focus.update_Vx_Vy();
			bool flag = point_Focus.f >= point_Focus.fRe;
			if (flag)
			{
				GameScreen.addEffectEnd(1, 0, point_Focus.objMain.x + CRes.random_Am_0(5), point_Focus.objMain.y - point_Focus.objMain.hOne / 2 + CRes.random_Am_0(5), this.Dir, this.objMainEff);
				this.VecEff.removeElement(point_Focus);
				i--;
			}
		}
		bool flag2 = this.f == 2;
		if (flag2)
		{
			this.addSound(18);
			for (int j = 0; j < this.vecObjsBeFire.size(); j++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(j);
				bool flag3 = object_Effect_Skill != null;
				if (flag3)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					bool flag4 = mainObject != null;
					if (flag4)
					{
						Point_Focus point_Focus2 = new Point_Focus();
						int xdich = mainObject.x - this.x;
						int ydich = mainObject.y - mainObject.hOne / 2 - this.y;
						point_Focus2 = base.create_Speed(xdich, ydich, point_Focus2);
						point_Focus2.objMain = mainObject;
						point_Focus2.frame = CRes.random(2);
						this.VecEff.addElement(point_Focus2);
					}
				}
			}
		}
		bool flag5 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag5)
		{
			this.removeEff();
		}
	}

	// Token: 0x0600030D RID: 781 RVA: 0x000636AC File Offset: 0x000618AC
	public void updateDonKrieg_3()
	{
		bool flag = this.f == 18;
		if (flag)
		{
			this.addSound(15);
			int num = -45;
			bool flag2 = this.Dir == 2;
			if (flag2)
			{
				num = 45;
			}
			GameScreen.addEffectEnd(57, 0, this.x + num, this.y + 12, this.Dir, this.objMainEff);
		}
		bool flag3 = this.f > 18 && this.f < 28;
		if (flag3)
		{
			bool flag4 = this.f == 20 || this.f == 26;
			if (flag4)
			{
				this.addSound(14);
			}
			bool flag5 = this.f % 2 == 1;
			if (flag5)
			{
				int num2 = -40 - ((this.f - 18) / 2 + 1) * 30;
				bool flag6 = this.Dir == 2;
				if (flag6)
				{
					num2 = 40 + ((this.f - 18) / 2 + 1) * 30;
				}
				GameScreen.addEffectEnd(58, 0, this.x + num2, this.y + 30, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(59, 0, this.x + num2, this.y + 30, this.Dir, this.objMainEff);
				this.addVir(2, 5, 10, false);
			}
		}
		bool flag7 = this.f >= this.fRemove;
		if (flag7)
		{
			this.removeEff();
		}
	}

	// Token: 0x0600030E RID: 782 RVA: 0x00063824 File Offset: 0x00061A24
	public void updateDonKrieg_2()
	{
		bool flag = this.f == 2;
		if (flag)
		{
			this.xArchor += this.x1000;
		}
		bool flag2 = this.f == 10;
		if (flag2)
		{
			this.addSound(32);
			bool flag3 = !this.checkNullObject(2);
			if (flag3)
			{
				this.addVir(3, 5, 10, false);
				Point_Focus point_Focus = new Point_Focus();
				int xdich = this.objBeFireMain.x - this.x;
				int ydich = this.objBeFireMain.y - this.objBeFireMain.hOne / 2 - this.y;
				point_Focus = base.create_Speed(xdich, ydich, point_Focus);
				GameScreen.addEffectEnd(12, 1, this.x, this.y, this.Dir, this.objMainEff);
				this.VecEff.addElement(point_Focus);
			}
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus2 = (Point_Focus)this.VecEff.elementAt(i);
			point_Focus2.update_Vx_Vy();
			bool flag4 = point_Focus2.f < point_Focus2.fRe;
			if (!flag4)
			{
				this.x = point_Focus2.x;
				this.y = point_Focus2.y;
				for (int j = 0; j < this.vecObjsBeFire.size(); j++)
				{
					Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(j);
					bool flag5 = object_Effect_Skill != null;
					if (flag5)
					{
						MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
						bool flag6 = mainObject != null;
						if (flag6)
						{
							this.vMax = 8 + CRes.random(5);
							Point_Focus point_Focus3 = new Point_Focus();
							int xdich2 = mainObject.x - this.x;
							int ydich2 = mainObject.y - mainObject.hOne / 2 - this.y;
							point_Focus3 = base.create_Speed(xdich2, ydich2, point_Focus3);
							point_Focus3.objMain = mainObject;
							this.VecSubEff.addElement(point_Focus3);
						}
					}
				}
				GameScreen.addEffectEnd(57, 0, this.x, this.y, this.Dir, this.objMainEff);
				bool flag7 = this.VecSubEff.size() < 8;
				if (flag7)
				{
					for (int k = 0; k < 8 - this.VecEff.size(); k++)
					{
						this.vMax = 8 + CRes.random(5);
						Point_Focus point_Focus4 = new Point_Focus();
						int xdich3 = CRes.random_Am_0(120);
						int ydich3 = CRes.random_Am_0(50);
						point_Focus4 = base.create_Speed(xdich3, ydich3, point_Focus4);
						this.VecSubEff.addElement(point_Focus4);
					}
				}
				this.VecEff.removeElement(point_Focus2);
				i--;
			}
		}
		for (int l = 0; l < this.VecSubEff.size(); l++)
		{
			Point_Focus point_Focus5 = (Point_Focus)this.VecSubEff.elementAt(l);
			point_Focus5.update_Vx_Vy();
			bool flag8 = point_Focus5.f == point_Focus5.fRe && point_Focus5.objMain != null;
			if (flag8)
			{
				GameScreen.addEffectEnd(1, 0, point_Focus5.x + CRes.random_Am_0(5), point_Focus5.y + CRes.random_Am_0(5), this.Dir, this.objMainEff);
				base.setAva(0, point_Focus5.objMain);
			}
			bool flag9 = point_Focus5.f > point_Focus5.fRe + 8;
			if (flag9)
			{
				this.VecSubEff.removeElement(point_Focus5);
				l--;
			}
		}
		bool flag10 = this.f >= this.fRemove && this.VecSubEff.size() == 0 && this.VecEff.size() == 0;
		if (flag10)
		{
			this.removeEff();
		}
	}

	// Token: 0x0600030F RID: 783 RVA: 0x00063C14 File Offset: 0x00061E14
	public void updateDonKrieg_1()
	{
		bool flag = this.f == 2;
		if (flag)
		{
			this.x += this.x1000;
			this.x1000 = this.x;
			this.y1000 = this.y;
		}
		bool flag2 = this.f == 10;
		if (flag2)
		{
			this.addSound(32);
			for (int i = 0; i < this.vecObjsBeFire.size(); i++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(i);
				bool flag3 = object_Effect_Skill == null;
				if (!flag3)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					bool flag4 = mainObject == null;
					if (!flag4)
					{
						for (int j = 0; j < 2; j++)
						{
							Point_Focus point_Focus = new Point_Focus();
							bool flag5 = this.Dir == 0;
							if (flag5)
							{
								this.x += CRes.random(10);
							}
							else
							{
								this.x -= CRes.random(10);
							}
							this.y += CRes.random_Am_0(25);
							int num = mainObject.x - this.x;
							int num2 = mainObject.y - mainObject.hOne / 2 - this.y;
							point_Focus = base.create_Speed(num, num2, point_Focus);
							int frameAngle = CRes.angle(num, num2);
							point_Focus.frame = base.setFrameAngle(frameAngle);
							GameScreen.addEffectEnd(3, 0, this.x, this.y, this.Dir, this.objMainEff);
							bool flag6 = j == 0;
							if (flag6)
							{
								point_Focus.objMain = mainObject;
							}
							this.VecEff.addElement(point_Focus);
							this.x = this.x1000;
							this.y = this.y1000;
						}
					}
				}
			}
			bool flag7 = this.VecEff.size() < 8;
			if (flag7)
			{
				for (int k = 0; k < 8 - this.VecEff.size(); k++)
				{
					Point_Focus point_Focus2 = new Point_Focus();
					bool flag8 = this.Dir == 0;
					if (flag8)
					{
						this.x += CRes.random(10);
					}
					else
					{
						this.x -= CRes.random(10);
					}
					this.y += CRes.random_Am_0(25);
					int num3 = 120 + CRes.random_Am_0(30);
					int num4 = CRes.random_Am_0(50);
					bool flag9 = this.Dir == 0;
					if (flag9)
					{
						num3 = -num3;
					}
					point_Focus2 = base.create_Speed(num3, num4, point_Focus2);
					int frameAngle2 = CRes.angle(num3, num4);
					point_Focus2.frame = base.setFrameAngle(frameAngle2);
					GameScreen.addEffectEnd(3, 0, this.x, this.y, this.Dir, this.objMainEff);
					this.VecEff.addElement(point_Focus2);
					this.x = this.x1000;
					this.y = this.y1000;
				}
			}
		}
		for (int l = 0; l < this.VecEff.size(); l++)
		{
			Point_Focus point_Focus3 = (Point_Focus)this.VecEff.elementAt(l);
			point_Focus3.update_Vx_Vy();
			bool flag10 = point_Focus3.f == point_Focus3.fRe && point_Focus3.objMain != null;
			if (flag10)
			{
				GameScreen.addEffectEnd(1, 0, point_Focus3.x + CRes.random_Am_0(5), point_Focus3.y + CRes.random_Am_0(5), this.Dir, this.objMainEff);
				base.setAva(0, point_Focus3.objMain);
			}
			bool flag11 = point_Focus3.f > point_Focus3.fRe + 10;
			if (flag11)
			{
				this.VecEff.removeElement(point_Focus3);
				l--;
			}
		}
		bool flag12 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag12)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000310 RID: 784 RVA: 0x00064040 File Offset: 0x00062240
	public void updateKuro_2()
	{
		bool flag = (this.f >= this.fRemove && this.VecEff.size() == 0) || this.checkNullObject(1);
		if (flag)
		{
			bool flag2 = !this.checkNullObject(1);
			if (flag2)
			{
				this.objFireMain.isTanHinh = false;
			}
			this.removeEff();
		}
		bool flag3 = this.f == 10 || this.f == 24;
		if (flag3)
		{
			this.addSound(10);
		}
		bool flag4 = this.f == 32 || this.f == 18;
		if (flag4)
		{
			this.addSound(7);
		}
		bool flag5 = this.f <= 8;
		if (flag5)
		{
			bool flag6 = this.f == 0 || this.f == 4;
			if (flag6)
			{
				this.objFireMain.x = this.x + 3;
			}
			bool flag7 = this.f == 2 || this.f == 8;
			if (flag7)
			{
				this.objFireMain.x = this.x - 3;
			}
		}
		else
		{
			bool flag8 = this.f < this.fRemove;
			if (flag8)
			{
				bool flag9 = this.f == 10;
				if (flag9)
				{
					this.createSkillKuro(0, this.toX + CRes.random_Am_0(30), this.toY - 10 + CRes.random_Am_0(30), CRes.random(2, 5));
					base.setAva(0, this.objBeFireMain);
				}
				else
				{
					bool flag10 = this.f % 4 == 0;
					if (flag10)
					{
						this.createSkillKuro(CRes.random(4), this.toX + CRes.random_Am_0(30), this.toY - 10 + CRes.random_Am_0(30), CRes.random(2, 5));
						base.setAva(0, this.objBeFireMain);
					}
				}
				bool isTanHinh = this.objFireMain.isTanHinh;
				if (isTanHinh)
				{
					bool flag11 = CRes.random(5) == 0;
					if (flag11)
					{
						this.objFireMain.isTanHinh = false;
					}
				}
				else
				{
					bool flag12 = CRes.random(3) == 0;
					if (flag12)
					{
						this.objFireMain.isTanHinh = true;
						this.objFireMain.x = this.toX + CRes.random_Am_0(30);
						this.objFireMain.y = this.toY + CRes.random_Am_0(30);
					}
				}
				bool flag13 = CRes.random(5) == 0;
				if (flag13)
				{
					Point point = new Point();
					point.x = this.toX + CRes.random_Am_0(30);
					point.y = this.toY + CRes.random_Am_0(30);
					point.frame = 4;
					point.fRe = 3;
					point.dis = ((CRes.random(2) != 0) ? 2 : 0);
					this.VecEff.addElement(point);
					this.addVir(3, 5, 10, false);
				}
			}
		}
		bool flag14 = this.f == this.fRemove - 2;
		if (flag14)
		{
			Point point2 = new Point();
			point2.x = this.x1000;
			point2.y = this.y1000;
			point2.frame = 4;
			point2.fRe = 2;
			point2.dis = (int)this.Dir;
			this.VecEff.addElement(point2);
		}
		bool flag15 = this.f == this.fRemove;
		if (flag15)
		{
			this.objFireMain.isTanHinh = false;
			this.objFireMain.x = this.x1000;
			this.objFireMain.y = this.y1000;
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point3 = (Point)this.VecEff.elementAt(i);
			point3.update();
			bool flag16 = point3.f >= point3.fRe;
			if (flag16)
			{
				this.VecEff.removeElement(point3);
				i--;
			}
		}
	}

	// Token: 0x06000311 RID: 785 RVA: 0x00064434 File Offset: 0x00062634
	public void createSkillKuro(int type, int x, int y, int size)
	{
		switch (type)
		{
		case 0:
			for (int i = 0; i < size; i++)
			{
				Point point = new Point();
				point.y = y;
				bool flag = this.Dir == 2;
				if (flag)
				{
					point.x = x + 7 * i;
				}
				else
				{
					point.x = x - 7 * i;
				}
				point.vy = -7;
				point.frame = 2;
				point.fRe = 5;
				point.dis = ((CRes.random(2) != 0) ? 2 : 0);
				this.VecEff.addElement(point);
			}
			break;
		case 1:
			for (int j = 0; j < size; j++)
			{
				Point point2 = new Point();
				point2.y = y + j * 7;
				point2.x = x;
				point2.vx = -5;
				point2.frame = 3;
				point2.fRe = 5;
				point2.dis = ((CRes.random(2) != 0) ? 2 : 0);
				this.VecEff.addElement(point2);
			}
			break;
		case 2:
			for (int k = 0; k < size; k++)
			{
				Point point3 = new Point();
				point3.y = y + k * 7;
				point3.x = x;
				point3.vx = -3;
				bool flag2 = this.Dir == 0;
				if (flag2)
				{
					point3.vx = 3;
				}
				point3.frame = 0;
				point3.fRe = 4;
				point3.dis = ((CRes.random(2) != 0) ? 2 : 0);
				this.VecEff.addElement(point3);
			}
			break;
		case 3:
			for (int l = 0; l < size; l++)
			{
				Point point4 = new Point();
				point4.y = y + l * 7;
				point4.x = x;
				point4.vx = -3;
				bool flag3 = this.Dir == 0;
				if (flag3)
				{
					point4.vx = 3;
				}
				point4.frame = 1;
				point4.fRe = 4;
				point4.dis = ((CRes.random(2) != 0) ? 2 : 0);
				this.VecEff.addElement(point4);
			}
			break;
		}
	}

	// Token: 0x06000312 RID: 786 RVA: 0x00064680 File Offset: 0x00062880
	public void createSkillZoro2(int type, int x, int y, int size)
	{
		if (type != 0)
		{
			if (type == 1)
			{
				for (int i = 0; i < size; i++)
				{
					Point point = new Point();
					point.y = y + i * 15;
					point.x = x;
					point.vx = -5;
					point.frame = 3;
					point.fRe = 4;
					point.dis = ((CRes.random(2) != 0) ? 2 : 0);
					this.VecEff.addElement(point);
				}
			}
		}
		else
		{
			for (int j = 0; j < size; j++)
			{
				Point point2 = new Point();
				point2.y = y;
				bool flag = this.Dir == 2;
				if (flag)
				{
					point2.x = x + 15 * j;
				}
				else
				{
					point2.x = x - 15 * j;
				}
				point2.vy = -7;
				point2.frame = 2;
				point2.fRe = 4;
				point2.dis = ((CRes.random(2) != 0) ? 2 : 0);
				this.VecEff.addElement(point2);
			}
		}
	}

	// Token: 0x06000313 RID: 787 RVA: 0x000647A0 File Offset: 0x000629A0
	public void updateKuro_1()
	{
		bool flag = this.f == 2;
		if (flag)
		{
			int num = 14;
			bool flag2 = this.Dir == 2;
			if (flag2)
			{
				num = -14;
			}
			this.x = this.toX + num;
			this.y = this.toY - this.objFireMain.hOne / 2;
			this.objFireMain.x = this.x;
			this.objFireMain.y = this.toY;
		}
		bool flag3 = this.f == 4;
		if (flag3)
		{
			this.objFireMain.isTanHinh = false;
		}
		bool flag4 = this.f == 5;
		if (flag4)
		{
			int num2 = -14;
			bool flag5 = this.Dir == 2;
			if (flag5)
			{
				num2 = 14;
			}
			this.x += num2;
			for (int i = 0; i < 3; i++)
			{
				Point point = new Point();
				point.y = this.y;
				bool flag6 = this.Dir == 2;
				if (flag6)
				{
					point.x = this.x + 7 * i;
				}
				else
				{
					point.x = this.x - 7 * i;
				}
				point.vy = -10;
				point.frame = 2;
				point.fRe = 5;
				this.VecEff.addElement(point);
			}
		}
		bool flag7 = this.f > 5;
		if (flag7)
		{
			bool flag8 = this.f < 11;
			if (flag8)
			{
				this.objFireMain.dy = 10 * (this.f - 6);
				this.objBeFireMain.dy = 12 * (this.f - 6);
			}
			else
			{
				bool flag9 = this.f < 15;
				if (flag9)
				{
					this.objFireMain.dy = 50;
					this.objBeFireMain.dy = 60;
					this.objFireMain.vx = -5;
					bool flag10 = this.Dir == 0;
					if (flag10)
					{
						this.objFireMain.vx = 5;
					}
				}
			}
		}
		bool flag11 = this.f == 8;
		if (flag11)
		{
			this.addSound(7);
			base.setAva(0, this.objBeFireMain);
		}
		for (int j = 0; j < this.VecEff.size(); j++)
		{
			Point point2 = (Point)this.VecEff.elementAt(j);
			point2.update();
			bool flag12 = point2.f >= point2.fRe;
			if (flag12)
			{
				this.VecEff.removeElement(point2);
				j--;
			}
		}
		bool flag13 = this.f == 13;
		if (flag13)
		{
			this.addSound(7);
			base.setAva(1, this.objBeFireMain);
			for (int k = 0; k < 3; k++)
			{
				Point point3 = new Point();
				point3.y = this.y - this.objFireMain.dy + k * 7;
				point3.x = this.x;
				point3.vx = -3;
				bool flag14 = this.Dir == 0;
				if (flag14)
				{
					point3.vx = 3;
				}
				point3.frame = 0;
				point3.fRe = 4;
				this.VecEff.addElement(point3);
			}
		}
		bool flag15 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag15)
		{
			this.addVir(3, 5, 10, false);
			this.objFireMain.dy = 0;
			this.removeEff();
		}
	}

	// Token: 0x06000314 RID: 788 RVA: 0x00064B40 File Offset: 0x00062D40
	public void updateNyaban_2()
	{
		bool flag = this.f > this.fRemove || this.checkNullObject(1);
		if (flag)
		{
			bool flag2 = !this.checkNullObject(1);
			if (flag2)
			{
				this.objFireMain.toX = this.x;
				this.objFireMain.isTanHinh = false;
				this.objFireMain.dy = 0;
			}
			base.setAva(0, this.objBeFireMain);
			this.removeEff();
		}
		else
		{
			bool flag3 = this.f == 1;
			if (flag3)
			{
				this.addSound(3);
			}
			bool flag4 = this.f < 5;
			if (flag4)
			{
				this.objFireMain.dy = 40 * this.f;
				this.objFireMain.vx = this.vx;
			}
			else
			{
				bool flag5 = this.f < 8;
				if (flag5)
				{
					this.objFireMain.isTanHinh = true;
				}
			}
			bool flag6 = this.f == 5;
			if (flag6)
			{
				this.objFireMain.x = this.toX;
				this.objFireMain.vx = 0;
				this.objFireMain.dy = 100;
			}
			bool flag7 = this.f == 6;
			if (flag7)
			{
				this.addSound(14);
				this.addVir(2, 5, 10, false);
				this.objFireMain.dy = 0;
				base.setAva(1, this.objBeFireMain);
				GameScreen.addEffectEnd(1, 0, this.toX + CRes.random_Am_0(5), this.objBeFireMain.y - this.objBeFireMain.hOne / 2 + CRes.random_Am_0(5), this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(90, 0, this.toX, this.objBeFireMain.y + 10, this.Dir, this.objMainEff);
			}
		}
	}

	// Token: 0x06000315 RID: 789 RVA: 0x00064D10 File Offset: 0x00062F10
	public void updateNyaban_3()
	{
		bool flag = this.f > this.fRemove || this.checkNullObject(1);
		if (flag)
		{
			bool flag2 = !this.checkNullObject(1);
			if (flag2)
			{
				this.objFireMain.toX = this.x;
				this.objFireMain.dy = 0;
				this.objFireMain.vx = 0;
			}
			this.removeEff();
		}
		bool flag3 = this.f < 3;
		if (flag3)
		{
			this.objFireMain.dy = 10 * this.f;
			this.objFireMain.vx = this.vx;
		}
		else
		{
			bool flag4 = this.f < 6;
			if (flag4)
			{
				this.objFireMain.dy = 10 * (6 - this.f);
				this.objFireMain.vx = this.vx;
			}
		}
		bool flag5 = this.f == 6;
		if (flag5)
		{
			this.objFireMain.dy = 0;
			this.objFireMain.vx = 0;
		}
		bool flag6 = this.f == 17;
		if (flag6)
		{
			this.objFireMain.Dir = ((this.objFireMain.Dir == 0) ? 2 : 0);
			this.vx = 20;
			bool flag7 = this.objFireMain.Dir == 0;
			if (flag7)
			{
				this.vx = -20;
			}
			base.setAva(0, this.objBeFireMain);
		}
		bool flag8 = this.f == 8 || this.f == 13;
		if (flag8)
		{
			this.addSound(7);
			GameScreen.addEffectEnd(1, 0, this.toX + CRes.random_Am_0(5), this.objBeFireMain.y - this.objBeFireMain.hOne / 2 + CRes.random_Am_0(5), this.Dir, this.objMainEff);
		}
		bool flag9 = this.f > 17;
		if (flag9)
		{
			bool flag10 = this.f < 22;
			if (flag10)
			{
				this.objFireMain.dy = 5 * (this.f - 17);
				this.objFireMain.vx = this.vx;
			}
			else
			{
				bool flag11 = this.f < 26;
				if (flag11)
				{
					this.objFireMain.dy = 5 * (25 - this.f);
					this.objFireMain.vx = this.vx;
				}
			}
		}
	}

	// Token: 0x06000316 RID: 790 RVA: 0x00064F60 File Offset: 0x00063160
	public void updateJango_1()
	{
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(i);
			Point point = new Point(point_Focus.x, point_Focus.y);
			point.frame = CRes.random(this.fraImgSubEff.nFrame);
			this.VecSubEff.addElement(point);
			point_Focus.update_Vx_Vy();
			bool flag = point_Focus.f >= point_Focus.fRe;
			if (flag)
			{
				GameScreen.addEffectEnd(1, 0, point_Focus.objMain.x + CRes.random_Am_0(5), point_Focus.objMain.y - point_Focus.objMain.hOne / 2 + CRes.random_Am_0(5), this.Dir, this.objMainEff);
				this.VecEff.removeElement(point_Focus);
				i--;
			}
		}
		for (int j = 0; j < this.VecSubEff.size(); j++)
		{
			Point point2 = (Point)this.VecSubEff.elementAt(j);
			point2.f++;
			bool flag2 = point2.f >= 2;
			if (flag2)
			{
				this.VecSubEff.removeElement(point2);
				j--;
			}
		}
		bool flag3 = this.f == 2;
		if (flag3)
		{
			this.addSound(18);
			for (int k = 0; k < this.vecObjsBeFire.size(); k++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(k);
				bool flag4 = object_Effect_Skill != null;
				if (flag4)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					bool flag5 = mainObject != null;
					if (flag5)
					{
						Point_Focus point_Focus2 = new Point_Focus();
						int xdich = mainObject.x - this.x;
						int ydich = mainObject.y - mainObject.hOne / 2 - this.y;
						point_Focus2 = base.create_Speed(xdich, ydich, point_Focus2);
						point_Focus2.objMain = mainObject;
						this.VecEff.addElement(point_Focus2);
					}
				}
			}
		}
		bool flag6 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag6)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000317 RID: 791 RVA: 0x000651C8 File Offset: 0x000633C8
	public void updateCabaji_2()
	{
		bool flag = this.f >= this.fRemove || this.checkNullObject(1);
		if (flag)
		{
			bool flag2 = !this.checkNullObject(1);
			if (flag2)
			{
				this.objFireMain.toX = this.x;
			}
			this.removeEff();
		}
		else
		{
			bool flag3 = this.f == 1;
			if (flag3)
			{
				this.addSound(3);
			}
			bool flag4 = this.f < 5;
			if (flag4)
			{
				this.objFireMain.dy = 70 * this.f;
			}
			else
			{
				bool flag5 = this.f >= 5 && this.f <= 10;
				if (flag5)
				{
					this.objFireMain.dy = 330;
				}
				else
				{
					bool flag6 = this.f <= 13;
					if (flag6)
					{
						this.objFireMain.dy = (13 - this.f) * 110;
					}
				}
			}
			bool flag7 = this.f == 10;
			if (flag7)
			{
				this.objFireMain.x = this.toX;
				this.objFireMain.y = this.toY;
			}
			bool flag8 = this.f == 13;
			if (flag8)
			{
				this.addSound(15);
				this.addVir(3, 5, 10, false);
				this.objFireMain.dy = 0;
				bool flag9 = !this.checkNullObject(2);
				if (flag9)
				{
					GameScreen.addEffectEnd(1, 0, this.toX + CRes.random_Am_0(5), this.objBeFireMain.y - this.objBeFireMain.hOne / 2 + CRes.random_Am_0(5), this.Dir, this.objMainEff);
				}
				GameScreen.addEffectEnd(9, 0, this.toX, this.toY, this.Dir, this.objMainEff);
				base.setAva(2, this.objBeFireMain);
				bool flag10 = this.typeEffect == 22;
				if (flag10)
				{
					GameScreen.addEffectEnd(45, 0, this.toX, this.toY + 20, this.Dir, this.objMainEff);
				}
			}
		}
	}

	// Token: 0x06000318 RID: 792 RVA: 0x000653E0 File Offset: 0x000635E0
	public void updateArlong_3()
	{
		bool flag = this.f == 12;
		if (flag)
		{
			this.addSound(15);
			bool flag2 = this.vecObjsBeFire.size() > 1;
			if (flag2)
			{
				for (int i = 0; i < this.vecObjsBeFire.size(); i++)
				{
					Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(i);
					bool flag3 = object_Effect_Skill != null;
					if (flag3)
					{
						MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
						bool flag4 = mainObject != null;
						if (flag4)
						{
							base.setAva(1, mainObject);
						}
					}
				}
			}
			else
			{
				base.setAva(1, this.objBeFireMain);
			}
			GameScreen.addEffectEnd(8, 0, this.toX, this.toY, this.Dir, this.objMainEff);
			Point point = new Point(this.x + this.plusxy[4][0], this.y + 30);
			point.vx = -10;
			bool flag5 = this.Dir == 2;
			if (flag5)
			{
				point.vx = 10;
			}
			point.fRe = 12;
			this.VecEff.addElement(point);
		}
		bool flag6 = this.f == 18 || this.f == 22;
		if (flag6)
		{
			this.addSound(14);
		}
		bool flag7 = this.f == 13;
		if (flag7)
		{
			this.addVir(1, 6, 12, false);
			int num = -10;
			bool flag8 = this.Dir == 2;
			if (flag8)
			{
				num = 10;
			}
			GameScreen.addEffectEnd_ToX_ToY(62, 0, this.x + this.plusxy[4][0], this.y + 30, this.x + this.plusxy[4][0] + num * 12, this.y + 30, this.Dir, this.objMainEff);
		}
		for (int j = 0; j < this.VecEff.size(); j++)
		{
			Point point2 = (Point)this.VecEff.elementAt(j);
			point2.update();
			bool flag9 = point2.f < point2.fRe - 2;
			if (flag9)
			{
				point2.frame = CRes.random(2);
			}
			else
			{
				point2.frame = 2;
			}
			bool flag10 = this.f % 3 == 0;
			if (flag10)
			{
				GameScreen.addEffectEnd(59, 0, point2.x, point2.y, this.Dir, this.objMainEff);
			}
			bool flag11 = point2.f >= point2.fRe;
			if (flag11)
			{
				this.VecEff.removeElement(point2);
				j--;
			}
		}
		bool flag12 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag12)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000319 RID: 793 RVA: 0x000656C8 File Offset: 0x000638C8
	public void updateArlong_2()
	{
		bool flag = (this.f >= this.fRemove && this.VecEff.size() == 0) || this.checkNullObject(3);
		if (flag)
		{
			bool flag2 = !this.checkNullObject(1) && this.objFireMain.plashNow != null;
			if (flag2)
			{
				this.objFireMain.plashNow.setIsNextf(0);
			}
			this.removeEff();
		}
		bool flag3 = this.f == 2 || this.f == 12 || this.f == 22;
		if (flag3)
		{
			this.addSound(19);
		}
		bool flag4 = this.f == 2;
		if (flag4)
		{
			this.addVir(3, 5, 10, false);
			this.objFireMain.isTanHinh = true;
			bool flag5 = this.objFireMain.plashNow != null;
			if (flag5)
			{
				this.objFireMain.plashNow.setIsNextf(1);
			}
			Point_Focus point_Focus = new Point_Focus();
			int xdich = this.objBeFireMain.x - this.x;
			int ydich = this.objBeFireMain.y - this.objBeFireMain.hOne / 2 - this.y;
			point_Focus.objMain = this.objBeFireMain;
			point_Focus = base.create_Speed(xdich, ydich, point_Focus);
			point_Focus.frame = 0;
			point_Focus.dis = (int)this.Dir;
			this.VecEff.addElement(point_Focus);
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus2 = (Point_Focus)this.VecEff.elementAt(i);
			point_Focus2.update_Vx_Vy();
			bool flag6 = point_Focus2.f >= point_Focus2.fRe;
			if (flag6)
			{
				bool flag7 = point_Focus2.frame == 2;
				if (flag7)
				{
					this.objFireMain.isTanHinh = false;
					bool flag8 = this.objFireMain.plashNow != null;
					if (flag8)
					{
						this.objFireMain.plashNow.setIsNextf(0);
					}
					this.VecEff.removeElement(point_Focus2);
					i--;
				}
				else
				{
					bool flag9 = point_Focus2.f == point_Focus2.fRe;
					if (flag9)
					{
						GameScreen.addEffectEnd(8, 0, this.toX, this.toY, this.Dir, this.objMainEff);
						base.setAva(1, this.objBeFireMain);
					}
				}
			}
			bool flag10 = point_Focus2.frame == 0 && point_Focus2.f >= 8;
			if (flag10)
			{
				Point_Focus point_Focus3 = new Point_Focus();
				int xdich2 = this.objBeFireMain.x - point_Focus2.x;
				int ydich2 = this.objBeFireMain.y - this.objBeFireMain.hOne / 2 - point_Focus2.y;
				point_Focus3.objMain = this.objBeFireMain;
				point_Focus3 = base.create_Speed(xdich2, ydich2, point_Focus3, point_Focus2.x, point_Focus2.y, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2);
				point_Focus3.frame = 1;
				point_Focus3.dis = ((this.Dir == 0) ? 2 : 0);
				this.VecEff.addElement(point_Focus3);
				this.VecEff.removeElement(point_Focus2);
				i--;
			}
			else
			{
				bool flag11 = point_Focus2.f >= 22 && point_Focus2.frame == 1;
				if (flag11)
				{
					this.vMax = 20;
					Point_Focus point_Focus4 = new Point_Focus();
					int xdich3 = this.x - point_Focus2.x;
					int ydich3 = this.y - point_Focus2.y;
					point_Focus4 = base.create_Speed(xdich3, ydich3, point_Focus4, point_Focus2.x, point_Focus2.y, this.x, this.y);
					point_Focus4.frame = 2;
					point_Focus4.dis = (int)this.Dir;
					this.VecEff.addElement(point_Focus4);
					this.VecEff.removeElement(point_Focus2);
					i--;
				}
			}
		}
	}

	// Token: 0x0600031A RID: 794 RVA: 0x00065AE0 File Offset: 0x00063CE0
	public void updateArlong_1()
	{
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point = (Point)this.VecEff.elementAt(i);
			point.f++;
		}
		bool flag = this.f == 6;
		if (flag)
		{
			this.addSound(33);
			this.addVir(3, 5, 10, false);
			bool flag2 = this.vecObjsBeFire.size() > 1;
			if (flag2)
			{
				for (int j = 0; j < this.vecObjsBeFire.size(); j++)
				{
					Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(j);
					bool flag3 = object_Effect_Skill != null;
					if (flag3)
					{
						MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
						bool flag4 = mainObject != null;
						if (flag4)
						{
							GameScreen.addEffectEnd(8, 0, mainObject.x, mainObject.y - mainObject.hOne / 2, this.Dir, this.objMainEff);
							base.setAva(1, mainObject);
						}
					}
				}
			}
			else
			{
				GameScreen.addEffectEnd(8, 0, this.toX, this.toY, this.Dir, this.objMainEff);
				base.setAva(1, this.objBeFireMain);
			}
		}
		bool flag5 = this.f >= this.fRemove;
		if (flag5)
		{
			this.removeEff();
		}
	}

	// Token: 0x0600031B RID: 795 RVA: 0x00065C60 File Offset: 0x00063E60
	public void updateKurobi_2()
	{
		bool flag = this.f >= this.fRemove || this.checkNullObject(1);
		if (flag)
		{
			this.removeEff();
		}
		else
		{
			bool flag2 = this.f >= 10 && this.f <= 16;
			if (flag2)
			{
				bool flag3 = this.f < 13;
				if (flag3)
				{
					this.objFireMain.dy = 10 * (this.f - 10);
					this.objFireMain.vx = this.vx;
				}
				else
				{
					bool flag4 = this.f < 16;
					if (flag4)
					{
						this.objFireMain.dy = 10 * (16 - this.f);
						this.objFireMain.vx = this.vx;
					}
				}
				bool flag5 = this.f == 16;
				if (flag5)
				{
					bool flag6 = !this.checkNullObject(2);
					if (flag6)
					{
						GameScreen.addEffectEnd(25, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 3 * 2 + 10, this.Dir, this.objMainEff);
					}
					this.objFireMain.dy = 0;
					this.objFireMain.vx = 0;
					base.setAva(1, this.objBeFireMain);
				}
			}
			bool flag7 = this.f == 18;
			if (flag7)
			{
				GameScreen.addEffectEnd(30, 0, this.x, this.y + 10, 200, this.Dir, this.objMainEff);
			}
			bool flag8 = this.f == 26;
			if (flag8)
			{
				this.addSound(5);
				bool flag9 = !this.checkNullObject(2);
				if (flag9)
				{
					this.addVir(2, 5, 10, false);
					GameScreen.addEffectEnd(25, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 3 * 2 + 5, this.Dir, this.objMainEff);
				}
				this.objFireMain.dy = 0;
				this.objFireMain.vx = 0;
				base.setAva(1, this.objBeFireMain);
			}
		}
	}

	// Token: 0x0600031C RID: 796 RVA: 0x00065E90 File Offset: 0x00064090
	public void updateKurobi_1()
	{
		bool flag = this.f == 12 || this.f == 27;
		if (flag)
		{
			this.addSound(13);
			bool flag2 = !this.checkNullObject(2);
			if (flag2)
			{
				this.addVir(2, 5, 10, false);
				GameScreen.addEffectEnd(25, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 3 * 2 + 10, this.Dir, this.objMainEff);
				base.setAva(0, this.objBeFireMain);
			}
		}
		bool flag3 = this.f == 15;
		if (flag3)
		{
			GameScreen.addEffectEnd(30, 0, this.x, this.y, 300, this.Dir, this.objMainEff);
		}
		bool flag4 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag4)
		{
			this.removeEff();
		}
	}

	// Token: 0x0600031D RID: 797 RVA: 0x00065F90 File Offset: 0x00064190
	public void updateChu_2()
	{
		bool flag = this.f >= 10 && this.f < this.fRemove && this.f % 4 == 0;
		if (flag)
		{
			bool flag2 = this.f % 8 == 0 && this.indexObjBefire < this.vecObjsBeFire.size();
			if (flag2)
			{
				this.addSound(21);
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(this.indexObjBefire);
				this.indexObjBefire++;
				bool flag3 = object_Effect_Skill != null;
				if (flag3)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					bool flag4 = mainObject != null;
					if (flag4)
					{
						Point_Focus point_Focus = new Point_Focus();
						int xdich = mainObject.x - this.x;
						int ydich = mainObject.y - mainObject.hOne / 2 - this.y;
						point_Focus.objMain = mainObject;
						point_Focus = base.create_Speed(xdich, ydich, point_Focus);
						this.VecEff.addElement(point_Focus);
					}
				}
				this.addVir(3, 5, 10, false);
			}
			else
			{
				for (int i = 0; i < 2; i++)
				{
					Point_Focus point_Focus2 = new Point_Focus();
					int num = 120 + CRes.random_Am_0(30);
					int ydich2 = CRes.random_Am_0(50);
					bool flag5 = this.Dir == 0;
					if (flag5)
					{
						num = -num;
					}
					point_Focus2 = base.create_Speed(num, ydich2, point_Focus2);
					this.VecEff.addElement(point_Focus2);
				}
			}
		}
		for (int j = 0; j < this.VecEff.size(); j++)
		{
			Point_Focus point_Focus3 = (Point_Focus)this.VecEff.elementAt(j);
			point_Focus3.update_Vx_Vy();
			bool flag6 = point_Focus3.f >= point_Focus3.fRe;
			if (flag6)
			{
				GameScreen.addEffectEnd(61, 0, point_Focus3.x, point_Focus3.y, this.Dir, this.objMainEff);
				bool flag7 = point_Focus3.objMain != null;
				if (flag7)
				{
					base.setAva(0, point_Focus3.objMain);
				}
				this.VecEff.removeElement(point_Focus3);
				j--;
			}
		}
		bool flag8 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag8)
		{
			this.removeEff();
		}
	}

	// Token: 0x0600031E RID: 798 RVA: 0x00066200 File Offset: 0x00064400
	public void updateChu_1()
	{
		bool flag = this.f == 10 || this.f == 14 || this.f == 18;
		if (flag)
		{
			this.addSound(21);
			bool flag2 = !this.checkNullObject(2);
			if (flag2)
			{
				Point_Focus point_Focus = new Point_Focus();
				int xdich = this.objBeFireMain.x - this.x;
				int ydich = this.objBeFireMain.y - this.objBeFireMain.hOne / 2 - this.y;
				point_Focus = base.create_Speed(xdich, ydich, point_Focus);
				this.VecEff.addElement(point_Focus);
			}
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus2 = (Point_Focus)this.VecEff.elementAt(i);
			point_Focus2.update_Vx_Vy();
			bool flag3 = point_Focus2.f >= point_Focus2.fRe;
			if (flag3)
			{
				GameScreen.addEffectEnd(61, 0, point_Focus2.x, point_Focus2.y, this.Dir, this.objMainEff);
				bool flag4 = CRes.random(3) == 0;
				if (flag4)
				{
					base.setAva(0, this.objBeFireMain);
				}
				this.VecEff.removeElement(point_Focus2);
				i--;
			}
		}
		bool flag5 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag5)
		{
			this.removeEff();
		}
	}

	// Token: 0x0600031F RID: 799 RVA: 0x00066384 File Offset: 0x00064584
	public void updateHachi_2()
	{
		bool flag = this.f == this.fRemove - 4 && !this.checkNullObject(2);
		if (flag)
		{
			Point_Focus point_Focus = new Point_Focus();
			int xdich = this.objBeFireMain.x - this.x;
			int ydich = this.objBeFireMain.y - this.objBeFireMain.hOne / 2 - this.y;
			point_Focus = base.create_Speed(xdich, ydich, point_Focus);
			this.VecEff.addElement(point_Focus);
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus2 = (Point_Focus)this.VecEff.elementAt(i);
			point_Focus2.update_Vx_Vy();
			sbyte b = 0;
			bool flag2 = this.typeEffect == 150;
			if (flag2)
			{
				b = 1;
			}
			else
			{
				bool flag3 = this.typeEffect != 113;
				if (flag3)
				{
					b = 2;
				}
			}
			bool flag4 = point_Focus2.f >= point_Focus2.fRe;
			if (flag4)
			{
				bool flag5 = b < 2;
				if (flag5)
				{
					GameScreen.addEffectEnd(60, (int)b, point_Focus2.x, point_Focus2.y, this.Dir, this.objMainEff);
				}
				else
				{
					GameScreen.addEffectEnd(34, 0, point_Focus2.x, point_Focus2.y, this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(87, this.frame, point_Focus2.x, point_Focus2.y, this.Dir, this.objMainEff);
				}
				this.VecEff.removeElement(point_Focus2);
				i--;
			}
		}
		bool flag6 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag6)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000320 RID: 800 RVA: 0x00066560 File Offset: 0x00064760
	public void updateHachi_1()
	{
		bool flag = this.f == 1;
		if (flag)
		{
			this.addSound(4);
		}
		bool flag2 = this.f < 10 && this.f % 3 == 0;
		if (flag2)
		{
			base.setAva(0, this.objBeFireMain);
			GameScreen.addEffectEnd(1, 0, this.toX + CRes.random_Am_0(15), this.toY + CRes.random_Am_0(15), this.Dir, this.objMainEff);
			this.addVir(3, 5, 10, false);
		}
		bool flag3 = this.f >= this.fRemove;
		if (flag3)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000321 RID: 801 RVA: 0x0006660C File Offset: 0x0006480C
	public void updateGhin_2()
	{
		bool flag = this.f == 1 || this.f == 8;
		if (flag)
		{
			this.addSound(10);
		}
		bool flag2 = this.f == 4;
		if (flag2)
		{
			for (int i = 0; i < this.VecEff.size(); i++)
			{
				Point point = (Point)this.VecEff.elementAt(i);
				point.dis = 2;
			}
		}
		bool flag3 = this.f == 12;
		if (flag3)
		{
			for (int j = 0; j < this.VecEff.size(); j++)
			{
				Point point2 = (Point)this.VecEff.elementAt(j);
				bool flag4 = !this.checkNullObject(1);
				if (flag4)
				{
					bool flag5 = this.Dir == 0;
					if (flag5)
					{
						point2.x = this.objFireMain.x + 20;
					}
					else
					{
						point2.x = this.objFireMain.x - 20;
					}
				}
				else
				{
					point2.x = this.x;
				}
				point2.y = this.objFireMain.y - 28 + 4 * j;
				point2.vx = this.vx;
			}
		}
		for (int k = 0; k < this.VecEff.size(); k++)
		{
			Point point3 = (Point)this.VecEff.elementAt(k);
			point3.update();
			bool flag6 = !this.checkNullObject(2) && k == 0 && this.f % 4 == 0 && CRes.abs(point3.x - this.objBeFireMain.x) < 30;
			if (flag6)
			{
				GameScreen.addEffectEnd(1, 0, this.objBeFireMain.x + CRes.random_Am_0(5), this.objBeFireMain.y - this.objBeFireMain.hOne / 2 + CRes.random_Am_0(5), this.Dir, this.objMainEff);
				base.setAva(0, this.objBeFireMain);
			}
		}
		bool flag7 = this.f >= this.fRemove;
		if (flag7)
		{
			bool flag8 = !this.checkNullObject(1);
			if (flag8)
			{
				this.objFireMain.isPaintWeapon = true;
				this.objFireMain.vx = 0;
			}
			this.removeEff();
		}
		else
		{
			bool flag9 = this.f >= 12 && !this.checkNullObject(1);
			if (flag9)
			{
				this.objFireMain.vx = this.vx;
			}
		}
	}

	// Token: 0x06000322 RID: 802 RVA: 0x000668B0 File Offset: 0x00064AB0
	public void updatePearl_2()
	{
		bool flag = this.f > 10 && this.f < this.fRemove && this.f % 4 == 0;
		if (flag)
		{
			this.addSound(19);
			bool flag2 = this.indexObjBefire < this.vecObjsBeFire.size();
			if (flag2)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(this.indexObjBefire);
				this.indexObjBefire++;
				bool flag3 = object_Effect_Skill != null;
				if (flag3)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					int xdich = mainObject.x - this.x;
					int ydich = mainObject.y - mainObject.hOne / 2 - this.y;
					Point_Focus point_Focus = new Point_Focus();
					point_Focus = base.create_Speed(xdich, ydich, point_Focus);
					point_Focus.frame = CRes.random(3);
					point_Focus.objMain = mainObject;
					this.VecSubEff.addElement(point_Focus);
				}
			}
			else
			{
				bool flag4 = !this.checkNullObject(2);
				if (flag4)
				{
					int xdich2 = this.objBeFireMain.x + CRes.random_Am_0(30) - this.x;
					int ydich2 = this.objBeFireMain.y + CRes.random_Am_0(30) - this.objBeFireMain.hOne / 2 - this.y;
					Point_Focus point_Focus2 = new Point_Focus();
					point_Focus2 = base.create_Speed(xdich2, ydich2, point_Focus2);
					point_Focus2.frame = CRes.random(3);
					this.VecSubEff.addElement(point_Focus2);
				}
			}
		}
		for (int i = 0; i < this.VecSubEff.size(); i++)
		{
			Point_Focus point_Focus3 = (Point_Focus)this.VecSubEff.elementAt(i);
			point_Focus3.update_Vx_Vy();
			bool flag5 = point_Focus3.f >= point_Focus3.fRe;
			if (flag5)
			{
				bool flag6 = point_Focus3.objMain != null;
				if (flag6)
				{
					GameScreen.addEffectEnd_ObjTo(55, 0, point_Focus3.objMain.x, point_Focus3.objMain.y - point_Focus3.objMain.hOne / 2, point_Focus3.objMain.ID, point_Focus3.objMain.typeObject, this.Dir, this.objMainEff);
				}
				else
				{
					GameScreen.addEffectEnd(55, 0, point_Focus3.x, point_Focus3.y, this.Dir, this.objMainEff);
				}
				this.VecSubEff.removeElement(point_Focus3);
				i--;
			}
		}
		bool flag7 = this.f >= this.fRemove && this.VecSubEff.size() == 0;
		if (flag7)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000323 RID: 803 RVA: 0x00066B78 File Offset: 0x00064D78
	public void updateUrgot3()
	{
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point = (Point)this.VecEff.elementAt(i);
			bool flag = (point.vy > 0 && point.y >= 0) || (point.vy < 0 && point.y <= -30);
			if (flag)
			{
				point.vy = -point.vy;
			}
			point.y += point.vy;
		}
		bool flag2 = this.f == 30 && !this.checkNullObject(1);
		if (flag2)
		{
			this.objFireMain.x = this.toX;
			this.objFireMain.y = this.toY;
		}
		bool flag3 = this.f >= this.fRemove;
		if (flag3)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000324 RID: 804 RVA: 0x00066C6C File Offset: 0x00064E6C
	public void updatexerath3()
	{
		this.vy1000 += this.xplus;
		this.x1000 += this.vx1000;
		this.y1000 += this.vy1000;
		bool flag = this.f == this.fRemove;
		if (flag)
		{
			this.x1000 = this.toX * 1000;
			this.y1000 = this.toY;
			GameScreen.addEffectEnd(68, 0, this.toX, this.toY + 10, this.Dir, this.objMainEff);
		}
		bool flag2 = this.f >= this.fRemove;
		if (flag2)
		{
			bool flag3 = this.VecEff.size() == 0;
			if (flag3)
			{
				this.removeEff();
			}
		}
		else
		{
			for (int i = 0; i < 1; i++)
			{
				Point point = new Point();
				point.x = this.x1000 / 1000;
				point.y = this.y1000;
				bool flag4 = CRes.random(3) == 0;
				if (flag4)
				{
					point.fraImgEff = this.fraImgSubEff;
				}
				else
				{
					point.fraImgEff = this.fraImgSub2Eff;
				}
				this.VecEff.addElement(point);
			}
		}
		for (int j = 0; j < this.VecEff.size(); j++)
		{
			Point point2 = (Point)this.VecEff.elementAt(j);
			point2.f++;
			bool flag5 = point2.f >= 8;
			if (flag5)
			{
				this.VecEff.removeElement(point2);
				j--;
			}
		}
	}

	// Token: 0x06000325 RID: 805 RVA: 0x00066E28 File Offset: 0x00065028
	public void updateXerath2()
	{
		bool flag = this.f > 10;
		if (flag)
		{
			for (int i = 0; i < this.vecPos.size(); i++)
			{
				Point_Focus point_Focus = (Point_Focus)this.vecPos.elementAt(i);
				point_Focus.f++;
			}
		}
		bool flag2 = GameCanvas.timeNow - this.timeBegin >= (long)this.timeEnd;
		if (flag2)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000326 RID: 806 RVA: 0x00066EAC File Offset: 0x000650AC
	public void updateXerath1()
	{
		bool flag = this.f == 5 && !this.checkNullObject(1);
		if (flag)
		{
			GameScreen.addEffectEnd(30, 2, this.objFireMain.x, this.objFireMain.y - this.objFireMain.hOne / 2, (int)((short)((long)this.timeEnd - (GameCanvas.timeNow - this.timeBegin) - 200L)), this.Dir, this.objMainEff);
		}
		bool flag2 = GameCanvas.timeNow - this.timeBegin >= (long)this.timeEnd;
		if (flag2)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000327 RID: 807 RVA: 0x00066F50 File Offset: 0x00065150
	public void updateNoTheoHuong_1()
	{
		bool flag = this.f == 5 && !this.checkNullObject(1);
		if (flag)
		{
			GameScreen.addEffectEnd(30, 2, this.objFireMain.x, this.objFireMain.y - this.objFireMain.hOne / 2, (int)((short)((long)this.timeEnd - (GameCanvas.timeNow - this.timeBegin) - 200L)), this.Dir, this.objMainEff);
			this.x = this.objFireMain.x;
			this.y = this.objFireMain.y;
		}
		bool flag2 = this.f == 20 || this.f == 40;
		if (flag2)
		{
			for (int i = 0; i < 4; i++)
			{
				Point point = new Point();
				point.x = this.x + this.am_duong * 20;
				point.y = this.y - 30 + i * 20;
				point.vx = this.am_duong * 40;
				this.VecEff.addElement(point);
			}
		}
		for (int j = 0; j < this.VecSubEff.size(); j++)
		{
			Point point2 = (Point)this.VecSubEff.elementAt(j);
			point2.f++;
			bool flag3 = point2.f > 6 && point2.f % 2 == 0;
			if (flag3)
			{
				point2.frame++;
			}
			bool flag4 = point2.frame > 2;
			if (flag4)
			{
				this.VecSubEff.removeElement(point2);
				j--;
			}
		}
		for (int k = 0; k < this.VecEff.size(); k++)
		{
			Point point3 = (Point)this.VecEff.elementAt(k);
			point3.f++;
			bool flag5 = point3.f % 3 == 1;
			if (flag5)
			{
				Point point4 = new Point();
				point4.x = point3.x;
				point4.y = point3.y;
				this.VecSubEff.addElement(point4);
				point3.x += point3.vx;
			}
			bool flag6 = point3.f > 13;
			if (flag6)
			{
				this.VecEff.removeElement(point3);
			}
		}
		bool flag7 = GameCanvas.timeNow - this.timeBegin >= (long)this.timeEnd;
		if (flag7)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000328 RID: 808 RVA: 0x000671FC File Offset: 0x000653FC
	public void updateNoTheoHuong_2()
	{
		bool flag = this.f < 30 && this.f % 6 == 3;
		if (flag)
		{
			this.addVir(3, 5, 10, false);
			for (int i = 0; i < 4; i++)
			{
				GameScreen.addEffectEnd(52, 0, this.x + this.am_duong * 20 + this.am_duong * (this.f / 6) * 40, this.y - 30 + i * 20, this.Dir, this.objMainEff);
			}
		}
		bool flag2 = this.f >= this.fRemove;
		if (flag2)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000329 RID: 809 RVA: 0x000672AC File Offset: 0x000654AC
	public void updateNoNangLuong3()
	{
		for (int i = 0; i < this.vecPos.size(); i++)
		{
			Point_Focus point_Focus = (Point_Focus)this.vecPos.elementAt(i);
			bool flag = point_Focus.f == 0;
			if (flag)
			{
				this.addVir(2, 6, 10, false);
				GameScreen.addEffectEnd(63, 0, point_Focus.x, point_Focus.y, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(59, 0, point_Focus.x, point_Focus.y, this.Dir, this.objMainEff);
			}
			point_Focus.f++;
			bool flag2 = point_Focus.f >= 8;
			if (flag2)
			{
				this.vecPos.removeElement(point_Focus);
				i--;
			}
		}
		bool flag3 = this.f >= this.fRemove && this.vecPos.size() == 0;
		if (flag3)
		{
			this.removeEff();
		}
	}

	// Token: 0x0600032A RID: 810 RVA: 0x000673AC File Offset: 0x000655AC
	public void updateNoNangLuong2()
	{
		bool flag = this.f > 25;
		if (flag)
		{
			for (int i = 0; i < this.vecPos.size(); i++)
			{
				Point_Focus point_Focus = (Point_Focus)this.vecPos.elementAt(i);
				point_Focus.f++;
			}
		}
		bool flag2 = GameCanvas.timeNow - this.timeBegin >= (long)this.timeEnd;
		if (flag2)
		{
			this.removeEff();
		}
	}

	// Token: 0x0600032B RID: 811 RVA: 0x00067430 File Offset: 0x00065630
	public void updateNoNangLuong1()
	{
		bool flag = this.f == 5;
		if (flag)
		{
			GameScreen.addEffectEnd(30, 2, this.objFireMain.x, this.objFireMain.y - this.objFireMain.hOne / 2, (int)((short)((long)this.timeEnd - (GameCanvas.timeNow - this.timeBegin) - 200L)), this.Dir, this.objMainEff);
		}
		bool flag2 = CRes.random(6) == 0;
		if (flag2)
		{
			for (int i = this.indexObjBefire; i < GameScreen.vecPlayers.size(); i++)
			{
				MainObject mainObject = (MainObject)GameScreen.vecPlayers.elementAt(i);
				bool flag3 = this.indexObjBefire == GameScreen.vecPlayers.size() - 1;
				if (flag3)
				{
					this.indexObjBefire = 0;
				}
				bool flag4 = mainObject != this.objFireMain && MainObject.getDistance(this.objFireMain.x, this.objFireMain.y, mainObject.x, mainObject.y) <= 220;
				if (flag4)
				{
					this.indexObjBefire = i + 1;
					bool flag5 = this.indexObjBefire >= GameScreen.vecPlayers.size();
					if (flag5)
					{
						this.indexObjBefire = 0;
					}
					GameScreen.addEffectEnd_ObjTo(22, 0, mainObject.x, mainObject.y - mainObject.hOne / 2, this.objFireMain.ID, this.objFireMain.typeObject, (sbyte)this.objFireMain.Dir, this.objMainEff);
					break;
				}
			}
		}
		bool flag6 = GameCanvas.timeNow - this.timeBegin >= (long)this.timeEnd || this.checkNullObject(1);
		if (flag6)
		{
			this.removeEff();
		}
	}

	// Token: 0x0600032C RID: 812 RVA: 0x000675F8 File Offset: 0x000657F8
	public void updateGalio2()
	{
		bool flag = this.f == 2;
		if (flag)
		{
			int num = 0;
			for (int i = 0; i < 8; i++)
			{
				num %= 360;
				Point point = new Point(this.x + CRes.getcos(num) * 43 / 1000, this.y + CRes.getsin(num) * 23 / 1000);
				this.VecEff.addElement(point);
				GameScreen.addEffectEnd(66, 0, point.x, point.y, this.Dir, this.objMainEff);
				num += 45;
			}
		}
		bool flag2 = this.f == 8;
		if (flag2)
		{
			int num2 = 22;
			for (int j = 0; j < 12; j++)
			{
				num2 %= 360;
				Point point2 = new Point(this.x + CRes.getcos(num2) * 65 / 1000, this.y + CRes.getsin(num2) * 40 / 1000);
				this.VecEff.addElement(point2);
				GameScreen.addEffectEnd(66, 0, point2.x, point2.y, this.Dir, this.objMainEff);
				num2 += 30;
			}
		}
		bool flag3 = this.f == 14;
		if (flag3)
		{
			int num3 = 45;
			this.addVir(2, 6, 12, false);
			for (int k = 0; k < 16; k++)
			{
				num3 %= 360;
				Point point3 = new Point(this.x + CRes.getcos(num3) * 100 / 1000, this.y + CRes.getsin(num3) * 65 / 1000);
				this.VecEff.addElement(point3);
				GameScreen.addEffectEnd(66, 0, point3.x, point3.y, this.Dir, this.objMainEff);
				num3 += 22;
			}
		}
		for (int l = 0; l < this.VecEff.size(); l++)
		{
			Point point4 = (Point)this.VecEff.elementAt(l);
			point4.f++;
			bool flag4 = point4.f >= 8;
			if (flag4)
			{
				this.VecEff.removeElement(point4);
				l--;
			}
		}
		bool flag5 = this.f >= this.fRemove;
		if (flag5)
		{
			this.removeEff();
		}
	}

	// Token: 0x0600032D RID: 813 RVA: 0x0006788C File Offset: 0x00065A8C
	public void updatePan2()
	{
		bool flag = this.f >= this.fRemove || this.checkNullObject(1);
		if (flag)
		{
			this.removeEff();
		}
		else
		{
			bool flag2 = this.f < 6;
			if (flag2)
			{
				this.objFireMain.dy = this.f * 40;
			}
			bool flag3 = this.f >= 6 && this.f <= 12;
			if (flag3)
			{
				this.objFireMain.dy = 480;
				this.objFireMain.isTanHinh = true;
			}
			bool flag4 = this.f == 13;
			if (flag4)
			{
				this.objFireMain.isTanHinh = false;
				this.objFireMain.x = this.toX;
				this.objFireMain.y = this.toY;
			}
			bool flag5 = this.f > 13 && this.f < 18;
			if (flag5)
			{
				this.objFireMain.dy = (17 - this.f) * 120;
			}
			bool flag6 = this.f >= 18;
			if (flag6)
			{
				this.objFireMain.dy = 0;
			}
			bool flag7 = this.f == 18;
			if (flag7)
			{
				this.addVir(2, 6, 10, false);
				GameScreen.addEffectEnd(65, 0, this.objFireMain.x, this.objFireMain.y + 22, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(59, 0, this.objFireMain.x + CRes.random_Am_0(10), this.objFireMain.y, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(59, 0, this.objFireMain.x + CRes.random_Am_0(10), this.objFireMain.y, this.Dir, this.objMainEff);
			}
		}
	}

	// Token: 0x0600032E RID: 814 RVA: 0x00067A6C File Offset: 0x00065C6C
	public void update_Pan1()
	{
		bool flag = this.f == 15;
		if (flag)
		{
			Point o = new Point(this.toX, this.toY);
			this.VecEff.addElement(o);
		}
		bool flag2 = GameCanvas.timeNow - this.timeBegin >= (long)this.timeEnd;
		if (flag2)
		{
			this.removeEff();
		}
		bool flag3 = this.f == 17;
		if (flag3)
		{
			Point point = new Point(this.toX, this.toY);
			point.frame = 2;
			this.VecEff.addElement(point);
		}
		bool flag4 = this.f != 19 && this.f != 21 && this.f <= 25;
		if (!flag4)
		{
			for (int i = 0; i < this.VecEff.size(); i++)
			{
				Point point2 = (Point)this.VecEff.elementAt(i);
				bool flag5 = this.f >= 25;
				if (flag5)
				{
					point2.f++;
				}
				else
				{
					bool flag6 = point2.frame == 2 || point2.frame == 4;
					if (flag6)
					{
						point2.frame += 2;
					}
				}
			}
		}
	}

	// Token: 0x0600032F RID: 815 RVA: 0x00067BC4 File Offset: 0x00065DC4
	public void update_Zoro_s3_l3_New()
	{
		bool flag = this.f >= this.fRemove || this.checkNullObject(1);
		if (flag)
		{
			bool flag2 = this.isAddSound;
			if (flag2)
			{
				mSound.playSound(9, mSound.volumeSound);
			}
			this.addVir(10, 5, 10, true);
			for (int i = 0; i < this.VecEff.size(); i++)
			{
				Point point = (Point)this.VecEff.elementAt(i);
				int subtype = 0;
				bool flag3 = this.typeEffect == 185;
				if (flag3)
				{
					subtype = 1;
				}
				GameScreen.addEffectEnd(64, subtype, point.x, point.y, this.Dir, this.objMainEff);
				base.setAva(1, point.obj);
			}
			this.removeEff();
		}
		else
		{
			this.x1000 += this.vx;
			bool flag4 = this.f == 6;
			if (flag4)
			{
				this.vx = 8;
				bool flag5 = this.Dir == 0;
				if (flag5)
				{
					this.vx = -8;
				}
				this.objFireMain.vx = this.vx;
			}
			bool flag6 = this.f == 10 && this.typeEffect == 217 && !GameCanvas.lowGraphic;
			if (flag6)
			{
				GameScreen.addEffectEnd(137, 0, this.objFireMain.x, this.objFireMain.y + 10, this.Dir, this.objMainEff);
			}
			bool flag7 = this.f == 12;
			if (flag7)
			{
				this.objFireMain.isTanHinh = true;
			}
			bool flag8 = this.f == 14;
			if (flag8)
			{
				this.vx = 0;
				this.objFireMain.vx = this.vx;
				this.objFireMain.isTanHinh = true;
			}
			bool flag9 = this.f == 20;
			if (flag9)
			{
				for (int j = 0; j < this.vecObjsBeFire.size(); j++)
				{
					Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(j);
					bool flag10 = object_Effect_Skill != null;
					if (flag10)
					{
						MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
						bool flag11 = mainObject != null;
						if (flag11)
						{
							GameScreen.addEffectEnd(108, 1, mainObject.x, mainObject.y - mainObject.hOne / 2, this.Dir, this.objMainEff);
							GameScreen.addEffectEnd_ObjTo(24, 0, mainObject.x, mainObject.y, mainObject.ID, mainObject.typeObject, 0, null);
						}
					}
				}
			}
			bool flag12 = this.f >= 16 && this.f % 3 == 0 && this.indexObjBefire < this.vecObjsBeFire.size();
			if (flag12)
			{
				Object_Effect_Skill object_Effect_Skill2 = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(this.indexObjBefire);
				this.indexObjBefire++;
				bool flag13 = object_Effect_Skill2 != null;
				if (flag13)
				{
					MainObject mainObject2 = MainObject.get_Object((int)object_Effect_Skill2.ID, object_Effect_Skill2.tem);
					bool flag14 = mainObject2 != null;
					if (flag14)
					{
						Point point2 = new Point(mainObject2.x, mainObject2.y - mainObject2.hOne / 2);
						point2.obj = mainObject2;
						this.VecEff.addElement(point2);
					}
				}
			}
			for (int k = 0; k < this.VecEff.size(); k++)
			{
				Point point3 = (Point)this.VecEff.elementAt(k);
				point3.f++;
				point3.x = point3.obj.x;
				point3.y = point3.obj.y - point3.obj.hOne / 2;
			}
			bool flag15 = this.f == 24;
			if (flag15)
			{
				this.changeDir();
				this.objFireMain.Dir = (int)this.Dir;
				this.objFireMain.x = this.xArchor;
				this.objFireMain.y = this.yArchor;
				this.x = this.objFireMain.x;
				this.y = this.objFireMain.y - this.objFireMain.hOne / 2;
				this.x1000 = this.x - 15;
				this.y1000 = this.objFireMain.y - 22;
				int num = -15;
				bool flag16 = this.Dir == 2;
				if (flag16)
				{
					num = 15;
					this.x1000 = this.x - 63;
				}
				this.x += num;
				this.y -= 5;
			}
			bool flag17 = this.f == 26;
			if (flag17)
			{
				this.objFireMain.isTanHinh = false;
			}
		}
	}

	// Token: 0x06000330 RID: 816 RVA: 0x000680B8 File Offset: 0x000662B8
	public void update_Zoro_s3_l6()
	{
		bool flag = this.f >= this.fRemove || this.checkNullObject(1);
		if (flag)
		{
			bool flag2 = this.isAddSound;
			if (flag2)
			{
				mSound.playSound(9, mSound.volumeSound);
			}
			this.addVir(10, 5, 10, true);
			for (int i = 0; i < this.VecEff.size(); i++)
			{
				Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(i);
				int subtype = 2;
				GameScreen.addEffectEnd(64, subtype, point_Focus.x, point_Focus.y - point_Focus.objMain.hOne / 2, this.Dir, this.objMainEff);
				base.setAva(1, point_Focus.objMain);
			}
			this.removeEff();
		}
		else
		{
			this.x1000 += this.vx;
			bool flag3 = this.f == 6;
			if (flag3)
			{
				this.vx = 8;
				bool flag4 = this.Dir == 0;
				if (flag4)
				{
					this.vx = -8;
				}
				this.objFireMain.vx = this.vx;
			}
			bool flag5 = this.f == 10 && !GameCanvas.lowGraphic;
			if (flag5)
			{
				GameScreen.addEffectEnd(137, 1, this.objFireMain.x, this.objFireMain.y + 10, this.Dir, this.objMainEff);
			}
			bool flag6 = this.f == 12;
			if (flag6)
			{
				this.objFireMain.isTanHinh = true;
			}
			bool flag7 = this.f == 14;
			if (flag7)
			{
				this.vx = 0;
				this.objFireMain.vx = this.vx;
				this.objFireMain.isTanHinh = true;
			}
			bool flag8 = this.f == 20;
			if (flag8)
			{
				for (int j = 0; j < this.vecObjsBeFire.size(); j++)
				{
					Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(j);
					bool flag9 = object_Effect_Skill != null;
					if (flag9)
					{
						MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
						bool flag10 = mainObject != null;
						if (flag10)
						{
							GameScreen.addEffectEnd(108, 1, mainObject.x, mainObject.y - mainObject.hOne / 2, this.Dir, this.objMainEff);
						}
					}
				}
			}
			bool flag11 = this.f >= 10 && this.f % 3 == 0 && this.indexObjBefire < this.vecObjsBeFire.size();
			if (flag11)
			{
				Object_Effect_Skill object_Effect_Skill2 = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(this.indexObjBefire);
				this.indexObjBefire++;
				bool flag12 = object_Effect_Skill2 != null;
				if (flag12)
				{
					MainObject mainObject2 = MainObject.get_Object((int)object_Effect_Skill2.ID, object_Effect_Skill2.tem);
					bool flag13 = mainObject2 != null;
					if (flag13)
					{
						Point_Focus point_Focus2 = new Point_Focus();
						int y = this.y;
						bool flag14 = !this.checkNullObject(1);
						if (flag14)
						{
							y = this.objFireMain.y;
						}
						int xdich = mainObject2.x - this.x;
						int ydich = mainObject2.y - y;
						point_Focus2 = base.create_Speed(xdich, ydich, point_Focus2, this.x, y, mainObject2.x, mainObject2.y);
						point_Focus2.objMain = mainObject2;
						this.VecEff.addElement(point_Focus2);
					}
				}
			}
			for (int k = 0; k < this.VecEff.size(); k++)
			{
				Point_Focus point_Focus3 = (Point_Focus)this.VecEff.elementAt(k);
				point_Focus3.update_Vx_Vy();
				bool flag15 = point_Focus3.f == point_Focus3.fRe;
				if (flag15)
				{
					base.setAva(1, point_Focus3.objMain);
					point_Focus3.vx = 0;
					point_Focus3.vy = 0;
					point_Focus3.x = point_Focus3.objMain.x;
					point_Focus3.y = point_Focus3.objMain.y;
				}
				bool flag16 = point_Focus3.f > point_Focus3.fRe;
				if (flag16)
				{
					point_Focus3.objMain.dy = CRes.random(20, 30);
					bool flag17 = point_Focus3.f < point_Focus3.fRe + 4;
					if (flag17)
					{
						base.setAva(-1, point_Focus3.objMain);
					}
				}
			}
			bool flag18 = this.f == 24;
			if (flag18)
			{
				this.changeDir();
				this.objFireMain.Dir = (int)this.Dir;
				this.objFireMain.x = this.xArchor;
				this.objFireMain.y = this.yArchor;
				this.x = this.objFireMain.x;
				this.y = this.objFireMain.y - this.objFireMain.hOne / 2;
				this.x1000 = this.x - 15;
				this.y1000 = this.objFireMain.y - 22;
				int num = -15;
				bool flag19 = this.Dir == 2;
				if (flag19)
				{
					num = 15;
					this.x1000 = this.x - 63;
				}
				this.x += num;
				this.y -= 5;
			}
			bool flag20 = this.f == 26;
			if (flag20)
			{
				this.objFireMain.isTanHinh = false;
			}
		}
	}

	// Token: 0x06000331 RID: 817 RVA: 0x00009A92 File Offset: 0x00007C92
	public void changeDir()
	{
		this.Dir = ((this.Dir != 2) ? 2 : 0);
	}

	// Token: 0x06000332 RID: 818 RVA: 0x0006863C File Offset: 0x0006683C
	public void addVir(int ran, int min, int max, bool isPlayer)
	{
		bool flag = (!isPlayer || (!this.checkNullObject(1) && this.objFireMain == GameScreen.player)) && CRes.random(ran) == 0;
		if (flag)
		{
			LoadMap.timeVibrateScreen = CRes.random(min, max);
		}
	}

	// Token: 0x06000333 RID: 819 RVA: 0x00068684 File Offset: 0x00066884
	public void sendMove(int x, int xto, int y, int yto)
	{
		bool flag = this.objFireMain != GameScreen.player;
		if (flag)
		{
			this.objFireMain.x = xto;
			this.objFireMain.y = yto;
		}
		else
		{
			bool flag2 = MainObject.getDistance(x, y, x, y) <= 30;
			if (flag2)
			{
				this.objFireMain.x = xto;
				this.objFireMain.y = yto;
			}
			int num = CRes.abs(x - xto);
			bool flag3 = num < CRes.abs(y - yto);
			if (flag3)
			{
				num = CRes.abs(y - yto);
			}
			int num2 = num / 20;
			bool flag4 = num2 == 0;
			if (flag4)
			{
				num2 = 1;
			}
			int num3 = (xto - x) / num2;
			int num4 = (xto - x) / num2;
			for (int i = 0; i < num2; i++)
			{
				this.objFireMain.x += num3;
				this.objFireMain.y += num4;
				GlobalService.gI().Obj_Move((short)this.objFireMain.x, (short)this.objFireMain.y);
			}
			this.objFireMain.x = xto;
			this.objFireMain.y = yto;
			GlobalService.gI().Obj_Move((short)this.objFireMain.x, (short)this.objFireMain.y);
		}
	}

	// Token: 0x06000334 RID: 820 RVA: 0x000687DC File Offset: 0x000669DC
	private void update_Zoro_s3_l2_New()
	{
		bool flag = (this.f == 13 || this.f == 20) && this.isAddSound;
		if (flag)
		{
			mSound.playSound(10, mSound.volumeSound);
		}
		bool flag2 = this.f == 15;
		if (flag2)
		{
			for (int i = 0; i < this.vecObjsBeFire.size(); i++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(i);
				bool flag3 = object_Effect_Skill != null;
				if (flag3)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					bool flag4 = mainObject != null;
					if (flag4)
					{
						GameScreen.addEffectEnd_ObjTo(24, 0, mainObject.x, mainObject.y, mainObject.ID, mainObject.typeObject, 0, null);
					}
				}
			}
		}
		bool flag5 = this.f > 20 && this.f % 3 == 0 && this.indexObjBefire < this.vecObjsBeFire.size();
		if (flag5)
		{
			Object_Effect_Skill object_Effect_Skill2 = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(this.indexObjBefire);
			this.indexObjBefire++;
			bool flag6 = object_Effect_Skill2 != null;
			if (flag6)
			{
				MainObject mainObject2 = MainObject.get_Object((int)object_Effect_Skill2.ID, object_Effect_Skill2.tem);
				bool flag7 = mainObject2 != null;
				if (flag7)
				{
					Point_Focus point_Focus = new Point_Focus();
					int y = this.y;
					bool flag8 = !this.checkNullObject(1);
					if (flag8)
					{
						y = this.objFireMain.y;
					}
					int xdich = mainObject2.x - this.x;
					int ydich = mainObject2.y - y;
					point_Focus = base.create_Speed(xdich, ydich, point_Focus, this.x, y, mainObject2.x, mainObject2.y);
					point_Focus.objMain = mainObject2;
					this.VecEff.addElement(point_Focus);
				}
			}
		}
		for (int j = 0; j < this.VecEff.size(); j++)
		{
			Point_Focus point_Focus2 = (Point_Focus)this.VecEff.elementAt(j);
			point_Focus2.update_Vx_Vy();
			bool flag9 = point_Focus2.f == point_Focus2.fRe;
			if (flag9)
			{
				base.setAva(1, point_Focus2.objMain);
				point_Focus2.vx = 0;
				point_Focus2.vy = 0;
				point_Focus2.x = point_Focus2.objMain.x;
				point_Focus2.y = point_Focus2.objMain.y;
			}
			bool flag10 = point_Focus2.f > point_Focus2.fRe;
			if (flag10)
			{
				point_Focus2.objMain.dy = CRes.random(20, 30);
				bool flag11 = point_Focus2.f < point_Focus2.fRe + 4;
				if (flag11)
				{
					base.setAva(-1, point_Focus2.objMain);
				}
				bool flag12 = point_Focus2.f >= point_Focus2.fRe + 8;
				if (flag12)
				{
					this.VecEff.removeElement(point_Focus2);
					j--;
				}
			}
		}
		bool flag13 = this.f >= this.fRemove;
		if (flag13)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000335 RID: 821 RVA: 0x00068B10 File Offset: 0x00066D10
	private void update_Zoro_s3_l1_New()
	{
		bool flag = (this.f == 13 || this.f == 20) && this.isAddSound;
		if (flag)
		{
			mSound.playSound(10, mSound.volumeSound);
		}
		bool flag2 = this.f == 15;
		if (flag2)
		{
			for (int i = 0; i < this.vecObjsBeFire.size(); i++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(i);
				bool flag3 = object_Effect_Skill != null;
				if (flag3)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					bool flag4 = mainObject != null;
					if (flag4)
					{
						GameScreen.addEffectEnd_ObjTo(24, 0, mainObject.x, mainObject.y, mainObject.ID, mainObject.typeObject, 0, null);
					}
				}
			}
		}
		bool flag5 = this.f == 23;
		if (flag5)
		{
			for (int j = 0; j < this.vecObjsBeFire.size(); j++)
			{
				Object_Effect_Skill object_Effect_Skill2 = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(j);
				bool flag6 = object_Effect_Skill2 != null;
				if (flag6)
				{
					MainObject mainObject2 = MainObject.get_Object((int)object_Effect_Skill2.ID, object_Effect_Skill2.tem);
					bool flag7 = mainObject2 != null;
					if (flag7)
					{
						GameScreen.addEffectEnd(11, 0, mainObject2.x, mainObject2.y - mainObject2.hOne / 2, this.Dir, this.objMainEff);
						base.setAva(0, mainObject2);
					}
				}
			}
		}
		bool flag8 = this.f >= this.fRemove;
		if (flag8)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000336 RID: 822 RVA: 0x00068CBC File Offset: 0x00066EBC
	private void updateLuffyMon16_17()
	{
		bool flag = this.f == 1 || this.f == 5 || this.f == 10;
		if (flag)
		{
			int num = 20;
			bool flag2 = this.Dir == 0;
			if (flag2)
			{
				num = -20;
			}
			base.setAva(0, this.objBeFireMain);
			bool flag3 = !this.checkNullObject(2);
			if (flag3)
			{
				GameScreen.addEffectEnd(35, 0, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
			}
			bool flag4 = !this.checkNullObject(1);
			if (flag4)
			{
				GameScreen.addEffectEnd(72, (this.f != 5) ? 1 : 2, this.x + num, this.objFireMain.y - this.objFireMain.hOne / 2, this.Dir, this.objMainEff);
			}
		}
		bool flag5 = this.f >= this.fRemove;
		if (flag5)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000337 RID: 823 RVA: 0x00068DD4 File Offset: 0x00066FD4
	private void updateLuffySea1()
	{
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(i);
			point_Focus.update_Vx_Vy();
			bool flag = point_Focus.f >= point_Focus.fRe;
			if (flag)
			{
				GameScreen.addEffectEnd(93, 0, point_Focus.x, point_Focus.y, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(8, 0, point_Focus.x, point_Focus.y, this.Dir, this.objMainEff);
				this.VecEff.removeElement(point_Focus);
				i--;
			}
		}
		bool flag2 = this.f == 3 || this.f == 11;
		if (flag2)
		{
			bool flag3 = this.isAddSound;
			if (flag3)
			{
				mSound.playSound(11, mSound.volumeSound);
			}
			bool flag4 = !this.checkNullObject(2);
			if (flag4)
			{
				for (int j = 0; j < 2; j++)
				{
					Point_Focus point_Focus2 = new Point_Focus(this.x, this.y);
					int xdich = this.objBeFireMain.x - this.x;
					int ydich = this.objBeFireMain.y - this.objBeFireMain.hOne / 2 - this.y;
					point_Focus2 = base.create_Speed(xdich, ydich, point_Focus2);
					point_Focus2.frame = CRes.random(3);
					point_Focus2.dis = (int)this.Dir;
					this.VecEff.addElement(point_Focus2);
				}
			}
		}
		bool flag5 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag5)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000338 RID: 824 RVA: 0x00068FA4 File Offset: 0x000671A4
	private void updateLuffySea2()
	{
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(i);
			point_Focus.update_Vx_Vy();
			bool flag = point_Focus.f >= point_Focus.fRe;
			if (flag)
			{
				GameScreen.addEffectEnd(8, 0, point_Focus.x, point_Focus.y, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(108, 4, point_Focus.x, point_Focus.y, this.Dir, this.objMainEff);
				this.VecEff.removeElement(point_Focus);
				i--;
			}
			else
			{
				bool flag2 = this.typeEffect == 135;
				if (flag2)
				{
					Point o = new Point(point_Focus.x, point_Focus.y);
					this.VecSubEff.addElement(o);
				}
			}
		}
		for (int j = 0; j < this.VecSubEff.size(); j++)
		{
			Point point = (Point)this.VecSubEff.elementAt(j);
			point.f++;
			bool flag3 = point.f >= 4;
			if (flag3)
			{
				this.VecSubEff.removeElement(point);
				j--;
			}
		}
		bool flag4 = this.f >= 10 && this.f <= 13 && !this.checkNullObject(1);
		if (flag4)
		{
			this.objFireMain.dy = (this.f - 9) * 8;
		}
		bool flag5 = this.f >= 14 && this.f <= 16 && !this.checkNullObject(1);
		if (flag5)
		{
			this.objFireMain.dy = 32;
		}
		bool flag6 = this.f >= 17 && this.f <= 20 && !this.checkNullObject(1);
		if (flag6)
		{
			this.objFireMain.dy = (20 - this.f) * 8;
		}
		bool flag7 = this.f == 3 || this.f == 6;
		if (flag7)
		{
			bool flag8 = this.isAddSound;
			if (flag8)
			{
				mSound.playSound(11, mSound.volumeSound);
			}
			bool flag9 = !this.checkNullObject(2);
			if (flag9)
			{
				for (int k = 0; k < 2; k++)
				{
					Point_Focus point_Focus2 = new Point_Focus(this.x, this.y);
					int xdich = this.objBeFireMain.x - this.x;
					int ydich = this.objBeFireMain.y - this.objBeFireMain.hOne / 2 - this.y;
					point_Focus2 = base.create_Speed(xdich, ydich, point_Focus2);
					point_Focus2.frame = CRes.random(3);
					point_Focus2.dis = (int)this.Dir;
					bool flag10 = this.typeEffect == 135;
					if (flag10)
					{
						point_Focus2.maxdis = 1;
					}
					this.VecEff.addElement(point_Focus2);
				}
			}
		}
		bool flag11 = this.f == 12 && this.isAddSound;
		if (flag11)
		{
			mSound.playSound(6, mSound.volumeSound);
		}
		bool flag12 = this.f == 15 && !this.checkNullObject(3);
		if (flag12)
		{
			Point_Focus point_Focus3 = new Point_Focus(this.x, this.y);
			int xdich2 = this.objBeFireMain.x - this.x;
			int ydich2 = this.objBeFireMain.y - this.objBeFireMain.hOne / 2 - (this.y - this.objFireMain.dy);
			point_Focus3 = base.create_Speed(xdich2, ydich2, point_Focus3, this.x, this.y - this.objFireMain.dy, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2);
			point_Focus3.maxdis = 1;
			point_Focus3.frame = CRes.random(4);
			point_Focus3.dis = (int)this.Dir;
			this.VecEff.addElement(point_Focus3);
		}
		bool flag13 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag13)
		{
			bool flag14 = !this.checkNullObject(1);
			if (flag14)
			{
				this.objFireMain.dy = 0;
			}
			this.removeEff();
		}
	}

	// Token: 0x06000339 RID: 825 RVA: 0x00069420 File Offset: 0x00067620
	private void updateLuffySea3()
	{
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(i);
			point_Focus.update_Vx_Vy();
			bool flag = point_Focus.f >= point_Focus.fRe;
			if (flag)
			{
				this.addVir(5, 5, 10, true);
				GameScreen.addEffectEnd(8, 0, point_Focus.x, point_Focus.y, this.Dir, this.objMainEff);
				this.VecEff.removeElement(point_Focus);
				i--;
			}
		}
		bool flag2 = this.f >= 22 && this.f <= 25 && !this.checkNullObject(1);
		if (flag2)
		{
			this.objFireMain.dy = (this.f - 21) * 10;
		}
		bool flag3 = this.f >= 26 && this.f <= 35 && !this.checkNullObject(1);
		if (flag3)
		{
			this.objFireMain.dy = 40;
		}
		bool flag4 = this.f >= 36 && this.f <= 39 && !this.checkNullObject(1);
		if (flag4)
		{
			this.objFireMain.dy = (39 - this.f) * 10;
		}
		bool flag5 = this.f == 10 || this.f == 20 || this.f == 34;
		if (flag5)
		{
			bool flag6 = this.isAddSound;
			if (flag6)
			{
				mSound.playSound(6, mSound.volumeSound);
			}
			bool flag7 = !this.checkNullObject(3);
			if (flag7)
			{
				Point_Focus point_Focus2 = new Point_Focus(this.x, this.y);
				int xdich = this.objBeFireMain.x - this.x;
				int ydich = this.objBeFireMain.y - this.objBeFireMain.hOne / 2 - (this.y - this.objFireMain.dy);
				point_Focus2 = base.create_Speed(xdich, ydich, point_Focus2, this.x, this.y - this.objFireMain.dy, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2);
				point_Focus2.frame = CRes.random(4);
				point_Focus2.dis = (int)this.Dir;
				this.VecEff.addElement(point_Focus2);
			}
		}
		bool flag8 = this.f == 1 || this.f == 11 || this.f == 26;
		if (flag8)
		{
			GameScreen.addEffectEnd(30, 0, this.x, this.y - this.objFireMain.dy, 250, this.Dir, this.objMainEff);
		}
		bool flag9 = this.f >= this.fRemove && this.VecEff.size() == 0;
		if (flag9)
		{
			bool flag10 = !this.checkNullObject(1);
			if (flag10)
			{
				this.objFireMain.dy = 0;
			}
			this.removeEff();
		}
	}

	// Token: 0x0600033A RID: 826 RVA: 0x00069738 File Offset: 0x00067938
	private void updateSanjiSea1()
	{
		bool flag = this.f <= 4 || (this.f >= 11 && this.f <= 15);
		if (flag)
		{
			bool flag2 = !this.checkNullObject(1);
			if (flag2)
			{
				this.objFireMain.isTanHinh = true;
			}
		}
		else
		{
			bool flag3 = !this.checkNullObject(1);
			if (flag3)
			{
				this.objFireMain.isTanHinh = false;
			}
		}
		bool flag4 = this.f == 2 && !this.checkNullObject(3);
		if (flag4)
		{
			int x = this.objBeFireMain.x - 20;
			bool flag5 = this.Dir == 0;
			if (flag5)
			{
				x = this.objBeFireMain.x + 20;
			}
			this.objFireMain.x = x;
			this.objFireMain.y = this.objBeFireMain.y;
		}
		bool flag6 = this.f == 12 && !this.checkNullObject(1);
		if (flag6)
		{
			this.objFireMain.x = this.x;
			this.objFireMain.y = this.y;
		}
		bool flag7 = this.objBeFireMain != null && this.objBeFireMain.hOne > 0 && (this.f == 6 || this.f == 9);
		if (flag7)
		{
			bool flag8 = this.isAddSound && this.f == 6;
			if (flag8)
			{
				mSound.playSound(2, mSound.volumeSound);
			}
			bool flag9 = !this.checkNullObject(2);
			if (flag9)
			{
				GameScreen.addEffectEnd(1, 0, this.objBeFireMain.x + CRes.random_Am_0(15), this.objBeFireMain.y - CRes.random(0, this.objBeFireMain.hOne / 4 * 3), this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(93, 2, this.objBeFireMain.x + CRes.random_Am_0(15), this.objBeFireMain.y - CRes.random(0, this.objBeFireMain.hOne / 4 * 3), this.Dir, this.objMainEff);
			}
		}
		bool flag10 = this.f >= this.fRemove;
		if (flag10)
		{
			bool flag11 = !this.checkNullObject(1);
			if (flag11)
			{
				this.objFireMain.x = this.x;
				this.objFireMain.y = this.y;
			}
			this.removeEff();
		}
	}

	// Token: 0x0600033B RID: 827 RVA: 0x000699BC File Offset: 0x00067BBC
	private void updateSanjiSea2()
	{
		bool flag = this.f <= 4 || (this.f >= 8 && this.f <= 13) || this.f == 19;
		if (flag)
		{
			bool flag2 = !this.checkNullObject(1);
			if (flag2)
			{
				this.objFireMain.isTanHinh = true;
			}
		}
		else
		{
			bool flag3 = !this.checkNullObject(1);
			if (flag3)
			{
				this.objFireMain.isTanHinh = false;
			}
		}
		bool flag4 = this.f == 2 && !this.checkNullObject(3);
		if (flag4)
		{
			int x = this.objBeFireMain.x - 20;
			bool flag5 = this.Dir == 0;
			if (flag5)
			{
				x = this.objBeFireMain.x + 20;
			}
			this.objFireMain.x = x;
			this.objFireMain.y = this.objBeFireMain.y;
			this.objFireMain.Dir = (int)this.Dir;
		}
		bool flag6 = this.f == 12 && !this.checkNullObject(3);
		if (flag6)
		{
			int x2 = this.objBeFireMain.x + 20;
			bool flag7 = this.Dir == 0;
			if (flag7)
			{
				x2 = this.objBeFireMain.x - 20;
			}
			this.objFireMain.x = x2;
			this.objFireMain.y = this.objBeFireMain.y;
			this.objFireMain.Dir = ((this.Dir == 0) ? 2 : 0);
		}
		bool flag8 = this.f == 19 && !this.checkNullObject(1);
		if (flag8)
		{
			this.objFireMain.x = this.x;
			this.objFireMain.y = this.y;
			this.objFireMain.Dir = (int)this.Dir;
		}
		bool flag9 = this.objBeFireMain != null && this.objBeFireMain.hOne > 0 && (this.f == 4 || this.f == 6 || this.f == 14 || this.f == 16);
		if (flag9)
		{
			bool flag10 = this.isAddSound && (this.f == 4 || this.f == 14);
			if (flag10)
			{
				mSound.playSound(2, mSound.volumeSound);
			}
			bool flag11 = !this.checkNullObject(3);
			if (flag11)
			{
				bool flag12 = this.objFireMain.hOne > 0;
				if (flag12)
				{
					int num = 25;
					bool flag13 = this.objFireMain.Dir == 0;
					if (flag13)
					{
						num = -25;
					}
					GameScreen.addEffectEnd(36, 0, this.objFireMain.x + num, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 3 * 2 + 10, this.Dir, this.objMainEff);
				}
				bool flag14 = this.typeEffect == 137;
				if (flag14)
				{
					GameScreen.addEffectEnd(1, 0, this.objBeFireMain.x + CRes.random_Am_0(15), this.objBeFireMain.y - CRes.random(0, this.objBeFireMain.hOne / 4 * 3), this.Dir, this.objMainEff);
				}
				else
				{
					GameScreen.addEffectEnd(4, 0, this.objBeFireMain.x + CRes.random_Am_0(15), this.objBeFireMain.y - CRes.random(0, this.objBeFireMain.hOne / 4 * 3) - 10, this.Dir, this.objMainEff);
					this.addVir(5, 5, 10, true);
				}
			}
		}
		bool flag15 = this.f >= this.fRemove;
		if (flag15)
		{
			bool flag16 = !this.checkNullObject(1);
			if (flag16)
			{
				this.objFireMain.x = this.x;
				this.objFireMain.y = this.y;
				this.objFireMain.Dir = (int)this.Dir;
				this.objFireMain.isTanHinh = false;
			}
			this.removeEff();
		}
	}

	// Token: 0x0600033C RID: 828 RVA: 0x00069DD4 File Offset: 0x00067FD4
	private void updateSanjiSea3()
	{
		bool flag = (this.f >= 4 && this.f <= 8) || (this.f >= 19 && this.f <= 23) || (this.f >= 35 && this.f <= 39);
		if (flag)
		{
			bool flag2 = !this.checkNullObject(1);
			if (flag2)
			{
				this.objFireMain.isTanHinh = true;
			}
		}
		else
		{
			bool flag3 = !this.checkNullObject(1);
			if (flag3)
			{
				this.objFireMain.isTanHinh = false;
			}
		}
		bool flag4 = this.f == 6 && !this.checkNullObject(3);
		if (flag4)
		{
			int x = this.objBeFireMain.x - 25;
			bool flag5 = this.Dir == 0;
			if (flag5)
			{
				x = this.objBeFireMain.x + 25;
			}
			this.objFireMain.x = x;
			this.objFireMain.y = this.objBeFireMain.y;
			this.objFireMain.Dir = (int)this.Dir;
		}
		bool flag6 = this.f == 21 && !this.checkNullObject(3);
		if (flag6)
		{
			int x2 = this.objBeFireMain.x + 25;
			bool flag7 = this.Dir == 0;
			if (flag7)
			{
				x2 = this.objBeFireMain.x - 25;
			}
			this.objFireMain.x = x2;
			this.objFireMain.y = this.objBeFireMain.y;
			this.objFireMain.Dir = ((this.Dir == 0) ? 2 : 0);
		}
		bool flag8 = this.f == 37 && !this.checkNullObject(1);
		if (flag8)
		{
			this.objFireMain.x = this.x;
			this.objFireMain.y = this.y;
			this.objFireMain.Dir = (int)this.Dir;
		}
		bool flag9 = this.objBeFireMain != null && this.objBeFireMain.hOne > 0 && (this.f == 11 || this.f == 15 || this.f == 25 || this.f == 29);
		if (flag9)
		{
			bool flag10 = this.isAddSound && (this.f == 11 || this.f == 25);
			if (flag10)
			{
				mSound.playSound(14, mSound.volumeSound);
			}
			bool flag11 = !this.checkNullObject(3);
			if (flag11)
			{
				bool flag12 = this.objFireMain.hOne > 0;
				if (flag12)
				{
					int num = 30;
					bool flag13 = this.objFireMain.Dir == 0;
					if (flag13)
					{
						num = -30;
					}
					GameScreen.addEffectEnd(36, 0, this.objFireMain.x + num, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 3 * 2 + 10, this.Dir, this.objMainEff);
				}
				GameScreen.addEffectEnd(4, 0, this.objBeFireMain.x + CRes.random_Am_0(15), this.objBeFireMain.y - CRes.random(0, this.objBeFireMain.hOne / 4 * 3) - 10, this.Dir, this.objMainEff);
				this.addVir(5, 5, 10, true);
			}
		}
		bool flag14 = this.f >= this.fRemove;
		if (flag14)
		{
			bool flag15 = !this.checkNullObject(1);
			if (flag15)
			{
				this.objFireMain.x = this.x;
				this.objFireMain.y = this.y;
				this.objFireMain.Dir = (int)this.Dir;
			}
			this.removeEff();
		}
	}

	// Token: 0x0600033D RID: 829 RVA: 0x0006A19C File Offset: 0x0006839C
	private void updateMonster_DanhTron()
	{
		bool flag = this.f == 1 && !this.checkNullObject(1);
		if (flag)
		{
			for (int i = 0; i < GameScreen.vecPlayers.size(); i++)
			{
				MainObject mainObject = (MainObject)GameScreen.vecPlayers.elementAt(i);
				bool flag2 = mainObject.typeObject == 0 && MainObject.getDistance(mainObject.x, mainObject.y, this.objFireMain.x, this.objFireMain.y) <= 60;
				if (flag2)
				{
					base.setAva(-1, mainObject);
					GameScreen.addEffectEnd(3, 0, mainObject.x, mainObject.y - mainObject.hOne / 2, this.Dir, this.objMainEff);
				}
			}
		}
		bool flag3 = this.f >= this.fRemove;
		if (flag3)
		{
			this.removeEff();
		}
	}

	// Token: 0x0600033E RID: 830 RVA: 0x0006A290 File Offset: 0x00068490
	private void updateUssop_S2_L3_New()
	{
		bool flag = this.f >= this.fRemove;
		if (flag)
		{
			this.removeEff();
		}
		else
		{
			bool flag2 = this.f == 15;
			if (flag2)
			{
				bool flag3 = this.isAddSound;
				if (flag3)
				{
					mSound.playSound(23, mSound.volumeSound);
				}
				this.toX = this.objBeFireMain.x;
				this.toY = this.objBeFireMain.y - this.objBeFireMain.hOne / 2;
				this.y -= 6;
				bool flag4 = this.Dir == 0;
				if (flag4)
				{
					this.x -= 30;
				}
				else
				{
					this.x += 30;
				}
				bool flag5 = this.toX > this.x;
				if (flag5)
				{
					this.vx = 12;
				}
				else
				{
					this.vx = -12;
				}
				bool flag6 = this.toY > this.y;
				if (flag6)
				{
					this.vy = 2;
				}
				else
				{
					this.vy = -2;
				}
				base.setAngle();
				GameScreen.addEffectEnd(57, 0, this.x, this.y, this.Dir, this.objMainEff);
				this.addVir(5, 5, 10, true);
			}
			bool flag7 = this.f > 15 && this.f < this.fRemove && this.typeEffect == 225 && !GameCanvas.lowGraphic;
			if (flag7)
			{
				GameScreen.addEffectEnd(140, 0, this.x, this.y + 40, this.Dir, this.objMainEff);
			}
			bool flag8 = (this.typeEffect != 225 && this.f == this.fRemove - 10) || (this.typeEffect == 225 && this.f == this.fRemove - 16);
			if (flag8)
			{
				base.setAva(2, this.objBeFireMain);
				bool flag9 = !this.checkNullObject(2);
				if (flag9)
				{
					int a = 12;
					GameScreen.addEffectEnd(4, 2, this.objBeFireMain.x + CRes.random_Am_0(a), this.objBeFireMain.y - this.objBeFireMain.hOne / 2 + CRes.random_Am_0(a), this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(108, 7, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
				}
			}
		}
	}

	// Token: 0x0600033F RID: 831 RVA: 0x0006A538 File Offset: 0x00068738
	private void updateUssop_S2_L6()
	{
		bool flag = this.f >= this.fRemove;
		if (flag)
		{
			this.objFireMain.isTanHinh = false;
			this.removeEff();
		}
		else
		{
			bool flag2 = this.f == 15;
			if (flag2)
			{
				bool flag3 = this.isAddSound;
				if (flag3)
				{
					mSound.playSound(23, mSound.volumeSound);
				}
				this.toX = this.objBeFireMain.x;
				this.toY = this.objBeFireMain.y - this.objBeFireMain.hOne / 2;
				this.y -= 6;
				bool flag4 = this.Dir == 0;
				if (flag4)
				{
					this.x -= 30;
				}
				else
				{
					this.x += 30;
				}
				bool flag5 = this.toX > this.x;
				if (flag5)
				{
					this.vx = 12;
				}
				else
				{
					this.vx = -12;
				}
				bool flag6 = this.toY > this.y;
				if (flag6)
				{
					this.vy = 2;
				}
				else
				{
					this.vy = -2;
				}
				base.setAngle();
				GameScreen.addEffectEnd(168, 2, this.x, this.y, this.Dir, this.objMainEff);
				this.addVir(5, 5, 10, true);
			}
			bool flag7 = this.f > 15 && this.f < this.fRemove && !GameCanvas.lowGraphic;
			if (flag7)
			{
				GameScreen.addEffectEnd(167, 0, this.x, this.y + 40, this.Dir, this.objMainEff);
			}
			bool flag8 = this.f == this.fRemove - 10 || this.f == this.fRemove - 16;
			if (flag8)
			{
				base.setAva(2, this.objBeFireMain);
				bool flag9 = !this.checkNullObject(2);
				if (flag9)
				{
					int a = 12;
					GameScreen.addEffectEnd(4, 2, this.objBeFireMain.x + CRes.random_Am_0(a), this.objBeFireMain.y - this.objBeFireMain.hOne / 2 + CRes.random_Am_0(a), this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(108, 7, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
				}
			}
			bool flag10 = this.f > 2 && this.f < 6;
			if (flag10)
			{
				Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(0);
				point_Focus.update();
			}
			bool flag11 = this.f > 2 && this.f < 15;
			if (flag11)
			{
				this.objFireMain.isTanHinh = true;
			}
			else
			{
				this.objFireMain.isTanHinh = false;
			}
		}
	}

	// Token: 0x06000340 RID: 832 RVA: 0x0006A838 File Offset: 0x00068A38
	private void updateUssop_S2_L6_old()
	{
		bool flag = this.f >= this.fRemove;
		if (flag)
		{
			bool flag2 = this.objFireMain != null;
			if (flag2)
			{
				this.objFireMain.isTanHinh = false;
			}
			this.removeEff();
		}
		else
		{
			bool flag3 = this.f == 1 || this.f == 10;
			if (flag3)
			{
				GameScreen.addEffectEnd(5, 0, this.x, this.y, this.Dir, this.objMainEff);
			}
			bool flag4 = this.f == 2;
			if (flag4)
			{
				this.objFireMain.isTanHinh = true;
			}
			else
			{
				bool flag5 = this.f == this.fPre;
				if (flag5)
				{
					this.objFireMain.isTanHinh = false;
				}
			}
			bool flag6 = this.VecEff.size() > 0 && this.f < this.fPre;
			if (flag6)
			{
				for (int i = 0; i < this.VecEff.size(); i++)
				{
					Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(i);
					int num = this.f - this.fPre * i / 3;
					bool flag7 = num > 0 && num < point_Focus.fRe;
					if (flag7)
					{
						point_Focus.update();
					}
					int a = 12;
					bool flag8 = num == point_Focus.fRe;
					if (flag8)
					{
						GameScreen.addEffectEnd(1, 0, this.toX + CRes.random_Am_0(a), this.toY + CRes.random_Am_0(a), this.Dir, this.objMainEff);
						GameScreen.addEffectEnd(4, 2, this.toX + CRes.random_Am_0(a), this.toY + CRes.random_Am_0(a), this.Dir, this.objMainEff);
						GameScreen.addEffectEnd(93, 2, this.toX + CRes.random_Am_0(a), this.toY + CRes.random_Am_0(a), this.Dir, this.objMainEff);
					}
				}
			}
			bool flag9 = this.f == 8 + this.fPre;
			if (flag9)
			{
				bool flag10 = this.isAddSound;
				if (flag10)
				{
					mSound.playSound(23, mSound.volumeSound);
				}
				this.toX = this.objBeFireMain.x;
				this.toY = this.objBeFireMain.y - this.objBeFireMain.hOne / 2;
				this.y = this.objFireMain.y - this.objFireMain.hOne / 2;
				bool flag11 = this.Dir == 0;
				if (flag11)
				{
					this.x = this.objFireMain.x - 30;
				}
				else
				{
					this.x = this.objFireMain.x + 30;
				}
				bool flag12 = this.toX > this.x;
				if (flag12)
				{
					this.vx = 12;
				}
				else
				{
					this.vx = -12;
				}
				bool flag13 = this.toY > this.y;
				if (flag13)
				{
					this.vy = 2;
				}
				else
				{
					this.vy = -2;
				}
				base.setAngle();
				GameScreen.addEffectEnd(57, 0, this.x, this.y, this.Dir, this.objMainEff);
				this.addVir(5, 5, 10, true);
			}
			bool flag14 = this.f > 8 + this.fPre && this.f < this.fRemove && !GameCanvas.lowGraphic;
			if (flag14)
			{
				GameScreen.addEffectEnd(167, 0, this.x, this.y + 40, this.Dir, this.objMainEff);
			}
			bool flag15 = this.f == this.fRemove - 16;
			if (flag15)
			{
				base.setAva(2, this.objBeFireMain);
				bool flag16 = !this.checkNullObject(2);
				if (flag16)
				{
					int a2 = 12;
					GameScreen.addEffectEnd(4, 2, this.objBeFireMain.x + CRes.random_Am_0(a2), this.objBeFireMain.y - this.objBeFireMain.hOne / 2 + CRes.random_Am_0(a2), this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(108, 7, this.objBeFireMain.x, this.objBeFireMain.y - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
				}
			}
		}
	}

	// Token: 0x06000341 RID: 833 RVA: 0x0006ACAC File Offset: 0x00068EAC
	private void updateMonster_Chay_Thang()
	{
		bool flag = this.f > 12 && this.f % 12 == 0;
		if (flag)
		{
			Point point = new Point();
			point.vx = this.am_duong * 15;
			bool flag2 = !this.checkNullObject(1);
			if (flag2)
			{
				point.y = this.objFireMain.y;
				point.x = this.objFireMain.x + point.vx;
			}
			else
			{
				point.y = this.y;
				point.x = this.x + point.vx;
			}
			this.VecEff.addElement(point);
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point2 = (Point)this.VecEff.elementAt(i);
			point2.update();
			bool flag3 = point2.f > 6;
			if (flag3)
			{
				point2.frame++;
			}
			bool flag4 = point2.frame >= 3;
			if (flag4)
			{
				this.VecEff.removeElement(point2);
				i--;
			}
		}
		bool flag5 = GameCanvas.timeNow - this.timeBegin >= (long)this.timeEnd;
		if (flag5)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000342 RID: 834 RVA: 0x0006AE04 File Offset: 0x00069004
	private void updateSanji_S2_L3_New()
	{
		bool flag = this.f >= this.fRemove || this.checkNullObject(3);
		if (flag)
		{
			bool flag2 = !this.checkNullObject(1);
			if (flag2)
			{
				this.objFireMain.isTanHinh = false;
			}
			this.removeEff();
		}
		else
		{
			bool flag3 = (this.f % 10 > 9 || this.f % 10 <= 1) && this.f > 5 && this.f < 35;
			if (flag3)
			{
				this.objFireMain.isTanHinh = true;
			}
			else
			{
				this.objFireMain.isTanHinh = false;
			}
			bool flag4 = this.f == 10 || this.f == 20 || this.f == 30;
			if (flag4)
			{
				bool flag5 = this.f > 10;
				if (flag5)
				{
					this.changeDir();
					this.am_duong = -1;
					bool flag6 = this.Dir == 2;
					if (flag6)
					{
						this.am_duong = 1;
					}
					this.objFireMain.Dir = (int)this.Dir;
				}
				this.objFireMain.x = this.objBeFireMain.x - this.am_duong * 30;
				this.objFireMain.y = this.objBeFireMain.y;
			}
			bool flag7 = this.f < 40 && this.f >= 10 && (this.f % 10 == 2 || this.f % 10 == 7);
			if (flag7)
			{
				bool flag8 = this.isAddSound && this.f % 10 == 2;
				if (flag8)
				{
					mSound.playSound(14, mSound.volumeSound);
				}
				this.addVir(5, 5, 10, true);
				GameScreen.addEffectEnd(36, 0, this.objFireMain.x + this.am_duong * 25, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 3 * 2 + 10, this.Dir, this.objMainEff);
				GameScreen.addEffectEnd(25, 0, this.objBeFireMain.x - this.am_duong * 5, this.objBeFireMain.y - this.objBeFireMain.hOne / 2 + CRes.random_Am_0(10), this.Dir, this.objMainEff);
				base.setAva(0, this.objBeFireMain);
			}
			bool flag9 = this.f == 42;
			if (flag9)
			{
				this.objFireMain.isTanHinh = true;
				this.changeDir();
				this.am_duong = -1;
				bool flag10 = this.Dir == 2;
				if (flag10)
				{
					this.am_duong = 1;
				}
				this.objFireMain.Dir = (int)this.Dir;
				this.objFireMain.x = this.x;
				this.objFireMain.y = this.y;
			}
		}
	}

	// Token: 0x06000343 RID: 835 RVA: 0x0006B0EC File Offset: 0x000692EC
	private void updateSanji_S2_L3_New_SHORT()
	{
		bool flag = this.f >= this.fRemove || this.checkNullObject(3);
		if (flag)
		{
			bool flag2 = !this.checkNullObject(1);
			if (flag2)
			{
				this.objFireMain.isTanHinh = false;
			}
			this.removeEff();
		}
		else
		{
			bool flag3 = (this.f % 10 > 9 || this.f % 10 <= 1) && this.f > 5 && this.f < 25;
			if (flag3)
			{
				this.objFireMain.isTanHinh = true;
			}
			else
			{
				this.objFireMain.isTanHinh = false;
			}
			bool flag4 = this.f == 1 || this.f == 10 || this.f == 20;
			if (flag4)
			{
				this.changeDir();
				this.am_duong = -1;
				bool flag5 = this.Dir == 2;
				if (flag5)
				{
					this.am_duong = 1;
				}
				this.objFireMain.Dir = (int)this.Dir;
				this.objFireMain.x = this.objBeFireMain.x - this.am_duong * 30;
				this.objFireMain.y = this.objBeFireMain.y;
			}
			bool flag6 = this.f < 24 && (this.f % 10 == 2 || this.f % 10 == 7);
			if (flag6)
			{
				bool flag7 = this.isAddSound && this.f % 10 == 2;
				if (flag7)
				{
					mSound.playSound(14, mSound.volumeSound);
				}
				bool flag8 = this.f % 10 == 2 || this.typeEffect == 187;
				if (flag8)
				{
					GameScreen.addEffectEnd(108, 7, this.objBeFireMain.x - this.am_duong * 5, this.objBeFireMain.y - this.objBeFireMain.hOne / 2 + CRes.random_Am_0(10), this.Dir, this.objMainEff);
				}
				this.addVir(5, 5, 10, true);
				GameScreen.addEffectEnd(36, 0, this.objFireMain.x + this.am_duong * 25, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 3 * 2 + 10, this.Dir, this.objMainEff);
				int subtype = 0;
				bool flag9 = this.typeEffect == 187;
				if (flag9)
				{
					subtype = 4;
				}
				GameScreen.addEffectEnd(25, subtype, this.objBeFireMain.x - this.am_duong * 5, this.objBeFireMain.y - this.objBeFireMain.hOne / 2 + CRes.random_Am_0(10), this.Dir, this.objMainEff);
				bool flag10 = this.typeEffect == 187;
				if (flag10)
				{
					GameScreen.addEffectEnd(119, 2, this.objFireMain.x + this.am_duong * 25, this.objFireMain.y - this.objFireMain.hOne / 2 + 2, (sbyte)this.objFireMain.Dir, this.objMainEff);
				}
				base.setAva(0, this.objBeFireMain);
			}
			bool flag11 = this.f == 22;
			if (flag11)
			{
				this.objFireMain.isTanHinh = true;
				this.changeDir();
				this.am_duong = -1;
				bool flag12 = this.Dir == 2;
				if (flag12)
				{
					this.am_duong = 1;
				}
				this.objFireMain.Dir = (int)this.Dir;
				this.objFireMain.x = this.x;
				this.objFireMain.y = this.y;
			}
		}
	}

	// Token: 0x06000344 RID: 836 RVA: 0x0006B49C File Offset: 0x0006969C
	private void updateSanji_S1_L3_New()
	{
		bool flag = this.f >= this.fRemove || this.checkNullObject(3);
		if (flag)
		{
			bool flag2 = !this.checkNullObject(3);
			if (flag2)
			{
				this.objFireMain.isTanHinh = false;
				this.objBeFireMain.vx = 0;
			}
			this.removeEff();
		}
		else
		{
			bool flag3 = this.f == 10;
			if (flag3)
			{
				this.objFireMain.x = this.objBeFireMain.x - this.am_duong * 30;
				this.objFireMain.y = this.objBeFireMain.y;
			}
			bool flag4 = this.f == 12 || this.f == 17;
			if (flag4)
			{
				bool flag5 = this.isAddSound;
				if (flag5)
				{
					mSound.playSound(2, mSound.volumeSound);
				}
				bool flag6 = this.typeEffect == 177;
				if (flag6)
				{
					GameScreen.addEffectEnd(19, 0, this.objFireMain.x + this.am_duong * 25, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 3 * 2 + 10, this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(108, 1, this.objFireMain.x + this.am_duong * 25, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 3 * 2 + 10, this.Dir, this.objMainEff);
				}
				else
				{
					GameScreen.addEffectEnd(36, 0, this.objFireMain.x + this.am_duong * 25, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 3 * 2 + 10, this.Dir, this.objMainEff);
				}
				GameScreen.addEffectEnd(25, 0, this.objBeFireMain.x - this.am_duong * 5, this.objBeFireMain.y - this.objBeFireMain.hOne / 2 + CRes.random_Am_0(10), this.Dir, this.objMainEff);
			}
			bool flag7 = this.f == 20;
			if (flag7)
			{
				this.vy1000 = 35;
				this.objFireMain.isTanHinh = true;
			}
			bool flag8 = this.f >= 20 && this.f <= 27;
			if (flag8)
			{
				this.objBeFireMain.dy = this.yplus;
				this.yplus += this.vy1000;
				bool flag9 = this.vy1000 > 0;
				if (flag9)
				{
					this.vy1000 -= 5;
				}
				base.setAva(-1, this.objBeFireMain);
			}
			bool flag10 = this.f == 25;
			if (flag10)
			{
				this.objFireMain.isTanHinh = false;
			}
			bool flag11 = this.f == 23;
			if (flag11)
			{
				this.objFireMain.dy = 105;
				this.changeDir();
				this.am_duong = -1;
				bool flag12 = this.Dir == 2;
				if (flag12)
				{
					this.am_duong = 1;
				}
				this.objFireMain.Dir = (int)this.Dir;
				this.objFireMain.x = this.objBeFireMain.x - this.am_duong * 30;
				GameScreen.addEffectEnd(30, 0, this.objFireMain.x - this.am_duong * 5, this.objFireMain.y - this.objFireMain.hOne / 2 - this.objFireMain.dy, 400, this.Dir, this.objMainEff);
			}
			bool flag13 = this.f >= 23 && this.f <= 40;
			if (flag13)
			{
				this.objFireMain.dy = 105;
				bool flag14 = this.f >= 27;
				if (flag14)
				{
					this.objBeFireMain.dy = 105;
				}
				base.setAva(-1, this.objBeFireMain);
			}
			bool flag15 = this.f == 40;
			if (flag15)
			{
				bool flag16 = this.isAddSound;
				if (flag16)
				{
					mSound.playSound(15, mSound.volumeSound);
				}
				this.addVir(5, 5, 10, true);
				bool flag17 = this.typeEffect == 177;
				if (flag17)
				{
					GameScreen.addEffectEnd(19, 0, this.objFireMain.x + this.am_duong * 25, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 3 * 2 + 10, this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(108, 1, this.objFireMain.x + this.am_duong * 25, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 3 * 2 + 10, this.Dir, this.objMainEff);
				}
				else
				{
					GameScreen.addEffectEnd(36, 0, this.objFireMain.x + this.am_duong * 25, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 3 * 2 + 10, this.Dir, this.objMainEff);
					GameScreen.addEffectEnd(35, 0, this.objBeFireMain.x - this.am_duong * 5, this.objBeFireMain.y - this.objBeFireMain.dy - this.objBeFireMain.hOne / 2, this.Dir, this.objMainEff);
				}
				this.vy1000 = 10;
				this.yplus = 120;
			}
			bool flag18 = this.f >= 41 && this.f <= 46;
			if (flag18)
			{
				this.yplus -= this.vy1000;
				this.objBeFireMain.dy = this.yplus;
				this.vy1000 += 5;
				bool flag19 = this.objBeFireMain.dy < 0;
				if (flag19)
				{
					this.objBeFireMain.dy = 0;
				}
				this.objBeFireMain.vx = this.am_duong * 15;
				this.objFireMain.updateDy();
			}
			bool flag20 = this.f > 47;
			if (flag20)
			{
				this.objBeFireMain.vx = 0;
			}
		}
	}

	// Token: 0x06000345 RID: 837 RVA: 0x0006BB28 File Offset: 0x00069D28
	private void updateSanji_S1_L3_SHORT()
	{
		bool flag = this.f >= this.fRemove || this.checkNullObject(3);
		if (flag)
		{
			bool flag2 = !this.checkNullObject(3);
			if (flag2)
			{
				this.objFireMain.isTanHinh = false;
				this.objBeFireMain.vx = 0;
			}
			this.removeEff();
		}
		else
		{
			bool flag3 = this.f == 1;
			if (flag3)
			{
				this.objFireMain.x = this.objBeFireMain.x - this.am_duong * 30;
				this.objFireMain.y = this.objBeFireMain.y;
			}
			bool flag4 = this.f != 7 && this.f != 10 && this.f != 13;
			if (!flag4)
			{
				bool flag5 = this.isAddSound;
				if (flag5)
				{
					mSound.playSound(2, mSound.volumeSound);
				}
				base.setAva(0, this.objBeFireMain);
				sbyte subtype = 1;
				bool flag6 = this.typeEffect != 218 || this.f == 10;
				if (flag6)
				{
					subtype = 0;
				}
				GameScreen.addEffectEnd(36, (int)subtype, this.objFireMain.x + this.am_duong * 25, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 3 * 2 + 10, this.Dir, this.objMainEff);
				subtype = 0;
				bool flag7 = this.typeEffect == 186;
				if (flag7)
				{
					subtype = 4;
				}
				GameScreen.addEffectEnd(25, (int)subtype, this.objBeFireMain.x - this.am_duong * 5, this.objBeFireMain.y - this.objBeFireMain.hOne / 2 + CRes.random_Am_0(10), this.Dir, this.objMainEff);
				bool flag8 = this.f == 10;
				if (flag8)
				{
					GameScreen.addEffectEnd(108, 7, this.objFireMain.x + this.am_duong * 25, this.objFireMain.y - this.objFireMain.dy - this.objFireMain.hOne / 3 * 2 + 10, this.Dir, this.objMainEff);
					bool flag9 = this.typeEffect == 186;
					if (flag9)
					{
						GameScreen.addEffectEnd(119, 1, this.objFireMain.x + this.am_duong * 25, this.objFireMain.y - this.objFireMain.hOne / 2 + 2, this.Dir, this.objMainEff);
					}
					bool flag10 = this.typeEffect == 218;
					if (flag10)
					{
						GameScreen.addEffectEnd(119, 4, this.objFireMain.x + this.am_duong * 20, this.objFireMain.y - this.objFireMain.hOne / 2 + 2, this.Dir, this.objMainEff);
					}
				}
			}
		}
	}

	// Token: 0x06000346 RID: 838 RVA: 0x000090B5 File Offset: 0x000072B5
	private void beginPaint()
	{
	}

	// Token: 0x06000347 RID: 839 RVA: 0x0006BE20 File Offset: 0x0006A020
	public void addSound(sbyte idS)
	{
		bool flag = this.isAddSound;
		if (flag)
		{
			mSound.playSound((int)idS, mSound.volumeSound);
		}
	}

	// Token: 0x06000348 RID: 840 RVA: 0x0006BE48 File Offset: 0x0006A048
	public void addSoundBuff()
	{
		bool flag = this.objFireMain.clazz == 1;
		if (flag)
		{
			this.addSound(6);
		}
		else
		{
			bool flag2 = this.objFireMain.clazz == 2;
			if (flag2)
			{
				this.addSound(8);
			}
			else
			{
				bool flag3 = this.objFireMain.clazz == 3;
				if (flag3)
				{
					this.addSound(16);
				}
				else
				{
					bool flag4 = this.objFireMain.clazz == 4;
					if (flag4)
					{
						this.addSound(22);
					}
					else
					{
						bool flag5 = this.objFireMain.clazz == 5;
						if (flag5)
						{
							this.addSound(34);
						}
					}
				}
			}
		}
	}

	// Token: 0x06000349 RID: 841 RVA: 0x0006BEF0 File Offset: 0x0006A0F0
	public void addSoundBuffShort()
	{
		bool flag = this.objFireMain.clazz == 1;
		if (flag)
		{
			this.addSound(44);
		}
		else
		{
			bool flag2 = this.objFireMain.clazz == 2;
			if (flag2)
			{
				this.addSound(45);
			}
			else
			{
				bool flag3 = this.objFireMain.clazz == 3;
				if (flag3)
				{
					this.addSound(46);
				}
				else
				{
					bool flag4 = this.objFireMain.clazz == 4;
					if (flag4)
					{
						this.addSound(22);
					}
					else
					{
						bool flag5 = this.objFireMain.clazz == 5;
						if (flag5)
						{
							this.addSound(34);
						}
					}
				}
			}
		}
	}

	// Token: 0x0600034A RID: 842 RVA: 0x0006BF9C File Offset: 0x0006A19C
	public void paintKurobi_2(mGraphics g)
	{
		bool flag = this.f >= 15 && this.f <= 20;
		if (flag)
		{
			this.fraImgEff.drawFrame((this.f - 11) / 3, this.objFireMain.x + this.x1000, this.objFireMain.y + this.y1000, (int)this.Dir, 3, g);
		}
		else
		{
			bool flag2 = this.f >= 25 && this.f <= 30;
			if (flag2)
			{
				this.fraImgEff.drawFrame((this.f - 25) / 3, this.objFireMain.x + this.x1000, this.objFireMain.y + this.y1000 + 10, (int)this.Dir, 3, g);
			}
		}
	}

	// Token: 0x0600034B RID: 843 RVA: 0x0006C078 File Offset: 0x0006A278
	public void paintDonKrieg_3(mGraphics g)
	{
		bool flag = this.f > 10 && this.f < 18;
		if (flag)
		{
			int x = this.x + this.plusxy[1][0];
			int y = this.y + this.plusxy[1][1];
			int idx = 1;
			bool flag2 = this.f < 13;
			if (flag2)
			{
				x = this.x + this.plusxy[0][0];
				y = this.y + this.plusxy[0][1];
				idx = 0;
			}
			this.fraImgEff.drawFrame(idx, x, y, (int)this.Dir, 3, g);
		}
	}

	// Token: 0x0600034C RID: 844 RVA: 0x0006C118 File Offset: 0x0006A318
	public void paintDonKrieg_2(mGraphics g)
	{
		bool flag = this.f < this.fRemove;
		if (flag)
		{
			int x = this.xArchor;
			int num = this.f / 2;
			bool flag2 = this.f > 16;
			if (flag2)
			{
				num = 22 - this.f;
				bool flag3 = this.f > 20;
				if (flag3)
				{
					x = this.xArchor + this.xplus * 2;
				}
				else
				{
					bool flag4 = this.f > 18;
					if (flag4)
					{
						x = this.xArchor + this.xplus;
					}
				}
			}
			else
			{
				bool flag5 = this.f >= 4;
				if (flag5)
				{
					num = 2;
				}
			}
			bool flag6 = num == 2;
			if (flag6)
			{
				num = 3;
			}
			bool flag7 = this.f >= 10 && this.f <= 12;
			if (flag7)
			{
				x = this.xArchor + this.xplus;
			}
			this.fraImgEff.drawFrame(num, x, this.y, (int)this.Dir, 3, g);
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(i);
			this.fraImgSubEff.drawFrame(0, point_Focus.x, point_Focus.y, (int)this.Dir, 3, g);
		}
		for (int j = 0; j < this.VecSubEff.size(); j++)
		{
			Point_Focus point_Focus2 = (Point_Focus)this.VecSubEff.elementAt(j);
			this.fraImgSub2Eff.drawFrame(point_Focus2.f % this.fraImgSub2Eff.nFrame, point_Focus2.x, point_Focus2.y, (int)this.Dir, 3, g);
		}
	}

	// Token: 0x0600034D RID: 845 RVA: 0x0006C2E4 File Offset: 0x0006A4E4
	public void paintDonKrieg_1(mGraphics g)
	{
		bool flag = this.f < this.fRemove;
		if (flag)
		{
			int x = this.x;
			int idx = this.f / 2;
			bool flag2 = this.f > 16;
			if (flag2)
			{
				idx = 22 - this.f;
				bool flag3 = this.f > 20;
				if (flag3)
				{
					x = this.x + this.xplus * 2;
				}
				else
				{
					bool flag4 = this.f > 18;
					if (flag4)
					{
						x = this.x + this.xplus;
					}
				}
			}
			else
			{
				bool flag5 = this.f >= 4;
				if (flag5)
				{
					idx = 2;
				}
			}
			bool flag6 = this.f >= 10 && this.f <= 12;
			if (flag6)
			{
				x = this.x + this.xplus;
			}
			this.fraImgEff.drawFrame(idx, x, this.y, (int)this.Dir, 3, g);
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(i);
			base.paint_Bullet(g, this.fraImgSubEff, point_Focus.frame, point_Focus.x, point_Focus.y, false, 0);
		}
	}

	// Token: 0x0600034E RID: 846 RVA: 0x0006C438 File Offset: 0x0006A638
	public void paintBuggy_2(mGraphics g)
	{
		int num = 0;
		int num2 = 5;
		bool flag = this.f == 28;
		if (flag)
		{
			num = -6;
		}
		else
		{
			bool flag2 = this.f > 28;
			if (flag2)
			{
				num = 0;
				num2 *= 2;
			}
			else
			{
				num2 = 0;
			}
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(i);
			bool flag3 = this.Dir == 2;
			if (flag3)
			{
				g.setColor(15956504);
				g.fillRect(this.x1000 - num2, this.y1000 - 7, CRes.abs(point_Focus.x - this.x1000) + num2, 14);
				g.setColor(15985419);
				g.fillRect(this.x1000 - num2, this.y1000 - 6, CRes.abs(point_Focus.x - this.x1000) + num2, 12);
				g.setColor(16645629);
				g.fillRect(this.x1000 - num2, this.y1000 - 4, CRes.abs(point_Focus.x - this.x1000) + num2, 8);
			}
			else
			{
				g.setColor(15956504);
				g.fillRect(this.x1000 - CRes.abs(point_Focus.x - this.x1000), this.y1000 - 7, CRes.abs(point_Focus.x - this.x1000) + num2, 14);
				g.setColor(15985419);
				g.fillRect(this.x1000 - CRes.abs(point_Focus.x - this.x1000), this.y1000 - 6, CRes.abs(point_Focus.x - this.x1000) + num2, 12);
				g.setColor(16645629);
				g.fillRect(this.x1000 - CRes.abs(point_Focus.x - this.x1000), this.y1000 - 4, CRes.abs(point_Focus.x - this.x1000) + num2, 8);
			}
			this.fraImgSub3Eff.drawFrame(0, point_Focus.x, point_Focus.y, (int)this.Dir, 3, g);
		}
		bool flag4 = this.f > 8 && this.f < 42;
		if (flag4)
		{
			bool flag5 = this.Dir == 2;
			if (flag5)
			{
				num2 = -num2;
			}
			int idx = 0;
			bool flag6 = this.f < 16;
			if (flag6)
			{
				idx = 2;
			}
			else
			{
				bool flag7 = this.f == 16 || this.f == 17;
				if (flag7)
				{
					idx = 1;
				}
			}
			this.fraImgSubEff.drawFrame(idx, this.x + num2, this.y + 38 + num, (int)this.Dir, 33, g);
		}
		bool flag8 = this.f >= 18 && this.f <= 20;
		if (flag8)
		{
			this.fraImgSub2Eff.drawFrame(this.f % this.fraImgSub2Eff.nFrame, this.x1000, this.y1000, (int)this.Dir, 3, g);
		}
		bool flag9 = this.f < 12;
		if (flag9)
		{
			int idx2 = 1 + this.f / 2 % 2;
			bool flag10 = this.f < 2 || this.f > 9;
			if (flag10)
			{
				idx2 = 0;
			}
			this.fraImgEff.drawFrame(idx2, this.x, this.y, (int)this.Dir, mGraphics.TOP | mGraphics.HCENTER, g);
		}
		bool flag11 = this.f > 40;
		if (flag11)
		{
			int idx3 = 1 + this.f / 2 % 2;
			bool flag12 = this.f > 46;
			if (flag12)
			{
				idx3 = 0;
			}
			this.fraImgEff.drawFrame(idx3, this.x, this.y, (int)this.Dir, mGraphics.TOP | mGraphics.HCENTER, g);
		}
	}

	// Token: 0x0600034F RID: 847 RVA: 0x0006C840 File Offset: 0x0006AA40
	public void paintLuffy_New3(mGraphics g)
	{
		for (int i = 0; i < this.VecSubEff.size(); i++)
		{
			Point point = (Point)this.VecSubEff.elementAt(i);
			bool flag = point.f < 3;
			if (flag)
			{
				this.fraImgSub2Eff.drawFrame(2 - point.f, point.x, point.y, (int)this.Dir, 33, g);
			}
			else
			{
				this.objFireMain.paintBody(g, point.x, point.y, this.objFireMain.frame, this.objFireMain.Dir, true);
			}
			int num = -20;
			bool flag2 = this.Dir == 2;
			if (flag2)
			{
				num = 20;
			}
			bool flag3 = this.f > 20;
			if (flag3)
			{
				this.fraImgEff.drawFrame(this.f / (int)this.numNextFrame % this.fraImgEff.nFrame, point.x + num, point.y - this.objFireMain.hOne / 2, (int)this.Dir, 3, g);
			}
		}
		bool flag4 = this.f > 20;
		if (flag4)
		{
			this.fraImgEff.drawFrame(this.f / (int)this.numNextFrame % this.fraImgEff.nFrame, this.x, this.y, (int)this.Dir, 3, g);
		}
	}

	// Token: 0x06000350 RID: 848 RVA: 0x0006C9B0 File Offset: 0x0006ABB0
	public void paintLuffy_New2(mGraphics g)
	{
		bool flag = this.objFireMain != null;
		if (flag)
		{
			bool flag2 = this.f == 1;
			if (flag2)
			{
				this.fraImgSubEff.drawFrame(0, this.x, this.y + this.objFireMain.hOne / 2, (int)this.Dir, 33, g);
			}
			bool flag3 = (this.f >= 9 && this.f <= 11) || (this.f > 25 && this.f < 33);
			if (flag3)
			{
				int num = 16;
				bool flag4 = this.Dir == 0;
				if (flag4)
				{
					num = -16;
				}
				this.fraImgEff.drawFrame(2, this.objFireMain.x + num, this.objFireMain.y - this.objFireMain.hOne / 2 + 2, (int)this.Dir, 3, g);
			}
		}
		bool flag5 = this.f >= 12 && this.f <= 15;
		if (flag5)
		{
			this.fraImgSubEff.drawFrame((this.f - 12) / 2, this.x, this.y, (int)this.Dir, 3, g);
		}
		bool flag6 = this.f >= 17 && this.f <= 20;
		if (flag6)
		{
			this.fraImgSub2Eff.drawFrame((this.f - 17) / 2, this.x, this.y, (int)this.Dir, 3, g);
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point = (Point)this.VecEff.elementAt(i);
			this.fraImgSubEff.drawFrame(point.f / 2, point.x, point.y, (int)this.Dir, 33, g);
		}
	}

	// Token: 0x06000351 RID: 849 RVA: 0x0006CB94 File Offset: 0x0006AD94
	public void paintLuffy_New2_SHORT(mGraphics g)
	{
		bool flag = this.objFireMain != null && ((this.f >= 2 && this.f <= 3) || (this.f > 16 && this.f < 22));
		if (flag)
		{
			int num = 16;
			bool flag2 = this.Dir == 0;
			if (flag2)
			{
				num = -16;
			}
			this.fraImgEff.drawFrame(2, this.objFireMain.x + num, this.objFireMain.y - this.objFireMain.hOne / 2 + 2 - this.objFireMain.dy, (int)this.Dir, 3, g);
		}
		bool flag3 = this.f >= 3 && this.f <= 6;
		if (flag3)
		{
			this.fraImgSubEff.drawFrame((this.f - 12) / 2, this.x, this.y, (int)this.Dir, 3, g);
		}
		bool flag4 = this.f >= 8 && this.f <= 11;
		if (flag4)
		{
			this.fraImgSub2Eff.drawFrame((this.f - 17) / 2, this.x, this.y, (int)this.Dir, 3, g);
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point = (Point)this.VecEff.elementAt(i);
			this.fraImgSubEff.drawFrame(point.f / 2, point.x, point.y, (int)this.Dir, 33, g);
		}
		bool flag5 = this.typeEffect == 213 || this.typeEffect == 272;
		if (flag5)
		{
			for (int j = 0; j < this.VecSubEff.size(); j++)
			{
				Point point2 = (Point)this.VecSubEff.elementAt(j);
				this.fraImgSub3Eff.drawFrame(point2.frame, point2.x, point2.y, (int)this.Dir, 33, g);
			}
		}
	}

	// Token: 0x06000352 RID: 850 RVA: 0x0006CDBC File Offset: 0x0006AFBC
	public void paintSanji_3(mGraphics g)
	{
		bool flag = this.f >= 4 && this.f < this.fRemove;
		if (flag)
		{
			this.fraImgEff.drawFrame((this.f - 4) / (int)this.numNextFrame % this.fraImgEff.nFrame, this.x - this.xplus, this.y, (int)this.Dir, 3, g);
		}
		bool flag2 = this.typeEffect == 49 || this.typeEffect == 50;
		if (flag2)
		{
			for (int i = 0; i < this.VecEff.size(); i++)
			{
				Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(i);
				bool flag3 = this.fraImgSubEff != null;
				if (flag3)
				{
					this.fraImgSubEff.drawFrame(point_Focus.f % this.fraImgSubEff.nFrame, point_Focus.x, point_Focus.y, (int)this.Dir, 3, g);
				}
				this.fraImgSub2Eff.drawFrame((point_Focus.f + point_Focus.frame) % this.fraImgSub2Eff.nFrame, point_Focus.x, point_Focus.y, (int)this.Dir, 3, g);
			}
		}
		else
		{
			bool flag4 = this.typeEffect == 220 || this.typeEffect == 293;
			if (flag4)
			{
				bool flag5 = this.f > 1 && this.f < this.fRemove - 1 && this.fraImgSubEff != null;
				if (flag5)
				{
					this.fraImgSubEff.drawFrame(this.f / 2 % this.fraImgSubEff.nFrame, this.x1000, this.y1000 + 5, (int)this.Dir, 33, g);
				}
				for (int j = 0; j < this.VecSubEff.size(); j++)
				{
					Point point = (Point)this.VecSubEff.elementAt(j);
					bool flag6 = point.f == 0;
					if (flag6)
					{
						this.fraImgSub2Eff.drawFrame(point.frame, point.x + this.am_duong * 5, point.y + 4, (int)this.Dir, 3, g);
					}
					else
					{
						bool flag7 = point.frame == 0;
						if (flag7)
						{
							this.fraImgSub3Eff.drawFrame(point.f, point.x, point.y, (int)this.Dir, 3, g);
						}
						else
						{
							this.fraImgSub4Eff.drawFrame(point.f, point.x, point.y, (int)this.Dir, 3, g);
						}
					}
				}
			}
			else
			{
				bool flag8 = this.f > 1 && this.f < this.fRemove - 1 && this.fraImgSubEff != null;
				if (flag8)
				{
					this.fraImgSubEff.drawFrame(this.f / 2 % this.fraImgSubEff.nFrame, this.x1000, this.y1000 + 5, (int)this.Dir, 33, g);
				}
				for (int k = 0; k < this.VecSubEff.size(); k++)
				{
					Point point2 = (Point)this.VecSubEff.elementAt(k);
					bool flag9 = point2.f == 0;
					if (flag9)
					{
						this.fraImgSub2Eff.drawFrame(point2.f, point2.x, point2.y, (int)this.Dir, 3, g);
					}
					else
					{
						this.fraImgSub3Eff.drawFrame(point2.f, point2.x, point2.y, (int)this.Dir, 3, g);
					}
				}
			}
		}
	}

	// Token: 0x06000353 RID: 851 RVA: 0x0006D188 File Offset: 0x0006B388
	public void paintGalio_1(mGraphics g)
	{
		int num = 2;
		this.numNextFrame = 4;
		bool flag = this.f > 40;
		if (flag)
		{
			num = this.fraImgEff.nFrame;
			this.numNextFrame = 2;
		}
		this.fraImgEff.drawFrame(this.f / (int)this.numNextFrame % num, this.objFireMain.x, this.objFireMain.y - this.objFireMain.hOne / 2, (int)this.Dir, 3, g);
	}

	// Token: 0x06000354 RID: 852 RVA: 0x0006D20C File Offset: 0x0006B40C
	public void paintPan_1(mGraphics g)
	{
		int num = 3;
		bool flag = this.f > 20;
		if (flag)
		{
			num = this.fraImgEff.nFrame;
		}
		this.fraImgEff.drawFrame(this.f / 2 % num, this.objFireMain.x, this.objFireMain.y, (int)this.Dir, 3, g);
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point = (Point)this.VecEff.elementAt(i);
			this.fraImgSubEff.drawFrame(point.frame + point.f / 3 % 2, point.x, point.y, 0, mGraphics.BOTTOM | mGraphics.RIGHT, g);
			this.fraImgSubEff.drawFrame(point.frame + point.f / 3 % 2, point.x, point.y, 2, mGraphics.BOTTOM | mGraphics.LEFT, g);
			this.fraImgSubEff.drawFrame(point.frame + point.f / 3 % 2, point.x, point.y, 1, mGraphics.TOP | mGraphics.RIGHT, g);
			this.fraImgSubEff.drawFrame(point.frame + point.f / 3 % 2, point.x, point.y, 3, 0, g);
		}
	}

	// Token: 0x06000355 RID: 853 RVA: 0x0006D370 File Offset: 0x0006B570
	public override void replaceHP(mVector vec)
	{
		for (int i = 0; i < this.vecObjsBeFire.size(); i++)
		{
			Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjsBeFire.elementAt(i);
			bool flag = object_Effect_Skill == null;
			if (!flag)
			{
				for (int j = 0; j < vec.size(); j++)
				{
					Object_Effect_Skill object_Effect_Skill2 = (Object_Effect_Skill)vec.elementAt(i);
					bool flag2 = object_Effect_Skill2 != null && object_Effect_Skill.ID == object_Effect_Skill2.ID;
					if (flag2)
					{
						bool isShowTextTab = GameScreen.isShowTextTab;
						if (isShowTextTab)
						{
							GameCanvas.chatTabScr.addNewChat(T.tabTestAdmin, "+DAM: ", string.Empty + object_Effect_Skill.hpShow.ToString(), 1, false);
						}
						object_Effect_Skill.hpShow = object_Effect_Skill2.hpShow;
						object_Effect_Skill.hpMagic = object_Effect_Skill2.hpMagic;
						object_Effect_Skill.mEffTypePlus = new int[object_Effect_Skill2.mEffTypePlus.Length];
						object_Effect_Skill.mEff_HP_Plus = new int[object_Effect_Skill2.mEffTypePlus.Length];
						object_Effect_Skill.mEff_Time_Plus = new int[object_Effect_Skill2.mEffTypePlus.Length];
						for (int k = 0; k < object_Effect_Skill.mEffTypePlus.Length; k++)
						{
							object_Effect_Skill.mEffTypePlus[k] = object_Effect_Skill2.mEffTypePlus[k];
							object_Effect_Skill.mEff_HP_Plus[k] = object_Effect_Skill2.mEff_HP_Plus[k];
							object_Effect_Skill.mEff_Time_Plus[k] = object_Effect_Skill2.mEff_Time_Plus[k];
						}
						break;
					}
				}
			}
		}
	}

	// Token: 0x06000356 RID: 854 RVA: 0x0006D4F8 File Offset: 0x0006B6F8
	public static void setHP_New(mVector vec, MainObject objFire, bool isAdd)
	{
		int i = 0;
		while (i < vec.size())
		{
			Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)vec.elementAt(i);
			MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
			bool flag = mainObject == null;
			if (flag)
			{
				vec.removeElement(object_Effect_Skill);
				i--;
			}
			else
			{
				bool flag2 = mainObject.Action == 4;
				if (!flag2)
				{
					bool flag3 = object_Effect_Skill.hpLast < mainObject.Hp;
					if (flag3)
					{
						mainObject.Hp = object_Effect_Skill.hpLast;
					}
					bool flag4 = !isAdd;
					if (!flag4)
					{
						bool flag5 = Effect_Skill.setAddEffPlus(object_Effect_Skill, mainObject, objFire, objFire);
						sbyte typeColor = 15;
						int num = object_Effect_Skill.hpShow;
						bool flag6 = objFire == GameScreen.player;
						if (flag6)
						{
							typeColor = 13;
						}
						bool flag7 = objFire.typeObject == 1;
						if (flag7)
						{
							typeColor = 14;
							num = -num;
						}
						bool flag8 = objFire == GameScreen.player && GameScreen.isShowTextTab;
						if (flag8)
						{
							GameCanvas.chatTabScr.addNewChat(T.tabTestAdmin, "+DAM: ", string.Empty + object_Effect_Skill.hpShow.ToString(), 1, false);
						}
						bool flag9 = objFire == GameScreen.player || mainObject == GameScreen.player || !GameCanvas.lowGraphic;
						if (flag9)
						{
							bool flag10 = object_Effect_Skill.hpShow == 0;
							if (flag10)
							{
								GameScreen.addEffectNumBig_NEW_AP(num, object_Effect_Skill.hpMagic, mainObject.x, mainObject.y - mainObject.hOne, 17);
							}
							else
							{
								bool flag11 = flag5;
								if (flag11)
								{
									typeColor = 16;
								}
								GameScreen.addEffectNumBig_NEW_AP(num, object_Effect_Skill.hpMagic, mainObject.x, mainObject.y - mainObject.hOne, typeColor);
							}
						}
						bool flag12 = mainObject.Hp <= 0;
						if (flag12)
						{
							mainObject.beginDie(objFire);
						}
					}
				}
			}
			IL_1BE:
			i++;
			continue;
			goto IL_1BE;
		}
	}

	// Token: 0x06000357 RID: 855 RVA: 0x0006D6DC File Offset: 0x0006B8DC
	public void setFlyFire(int begin, int end, int maxfly, int speedfly)
	{
		bool flag = this.objFireMain != null && !this.objFireMain.returnAction() && this.f >= begin && this.f < end;
		if (flag)
		{
			this.objFireMain.dy += speedfly;
			bool flag2 = this.objFireMain.dy > maxfly;
			if (flag2)
			{
				this.objFireMain.dy = maxfly;
			}
		}
	}

	// Token: 0x06000358 RID: 856 RVA: 0x0006D750 File Offset: 0x0006B950
	public void setDownFire(int begin, int end, int speedfly)
	{
		bool flag = this.objFireMain != null && !this.objFireMain.returnAction() && this.f >= begin && this.f < end;
		if (flag)
		{
			this.objFireMain.dy -= speedfly;
			bool flag2 = this.objFireMain.dy < 0;
			if (flag2)
			{
				this.objFireMain.dy = 0;
			}
		}
	}

	// Token: 0x06000359 RID: 857 RVA: 0x0006D7C4 File Offset: 0x0006B9C4
	public static bool setAddEffPlus(Object_Effect_Skill objEff, MainObject obj, MainObject objFire, MainObject OBJMainEff)
	{
		bool flag = objEff == null || obj == null || objFire == null;
		bool result;
		if (flag)
		{
			result = false;
		}
		else
		{
			bool flag2 = false;
			for (int i = 0; i < objEff.mEffTypePlus.Length; i++)
			{
				int num = objEff.mEffTypePlus[i];
				int num2 = num;
				switch (num2)
				{
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
				case 15:
				case 16:
				case 17:
					obj.addEffSpec((short)objEff.mEffTypePlus[i], (short)objEff.mEff_Time_Plus[i]);
					break;
				case 11:
				case 13:
				case 14:
					break;
				case 12:
					GameScreen.addEffectNum(objEff.hpShow.ToString() + T.chuan, obj.x, obj.y - obj.hOne, 11);
					break;
				default:
					switch (num2)
					{
					case 1010:
					{
						bool flag3 = objEff.hpShow <= 1;
						if (flag3)
						{
							return false;
						}
						GameScreen.addEffectEnd(20, 0, obj.x, obj.y - obj.hOne / 2, (sbyte)obj.Dir, OBJMainEff);
						flag2 = true;
						break;
					}
					case 1011:
					case 1012:
						break;
					case 1013:
						GameScreen.addEffectEnd(21, 0, obj.x, obj.y - obj.hOne / 2, (sbyte)obj.Dir, OBJMainEff);
						break;
					case 1014:
						GameScreen.addEffectEnd_ToX_ToY(23, 0, obj.x, obj.y - obj.hOne / 2, objFire.x, objFire.y - objFire.hOne / 2, (sbyte)obj.Dir, OBJMainEff);
						break;
					default:
						if (num2 - 1021 <= 1)
						{
							GameScreen.addEffectEnd_ObjTo(22, (objEff.mEffTypePlus[i] == 1021) ? 1 : 0, obj.x, obj.y - obj.hOne / 2, objFire.ID, objFire.typeObject, (sbyte)objFire.Dir, OBJMainEff);
						}
						break;
					}
					break;
				}
			}
			result = flag2;
		}
		return result;
	}

	// Token: 0x0600035A RID: 858 RVA: 0x0006D9EC File Offset: 0x0006BBEC
	public void CreateSpeedEff(int xS, int yS, int xToS, int yToS, int time, int vyBegin)
	{
		int num = (xToS - xS) * 1000 / time;
		int num2 = CRes.abs(vyBegin / (time / 2));
		this.speedEff = new int[time][];
		int num3 = yS;
		for (int i = 0; i < this.speedEff.Length - 1; i++)
		{
			this.speedEff[i] = new int[2];
			this.speedEff[i][0] = xS + num * i / 1000;
			this.speedEff[i][1] = num3 + vyBegin / 1000;
			vyBegin += num2;
			num3 = this.speedEff[i][1];
		}
		this.speedEff[time - 1][0] = xToS;
		this.speedEff[time - 1][1] = yToS;
	}

	// Token: 0x0600035B RID: 859 RVA: 0x0006DAA8 File Offset: 0x0006BCA8
	public void CreateSuperFrameCausu1()
	{
		int[][] array = new int[6][];
		int num = 0;
		int[] array2 = new int[2];
		array2[0] = 1;
		array[num] = array2;
		int num2 = 1;
		int[] array3 = new int[3];
		array3[0] = 1;
		array3[1] = 1;
		array[num2] = array3;
		int num3 = 2;
		int[] array4 = new int[3];
		array4[0] = 1;
		array4[1] = 1;
		array[num3] = array4;
		int num4 = 3;
		int[] array5 = new int[3];
		array5[0] = 1;
		array5[1] = 1;
		array[num4] = array5;
		int num5 = 4;
		int[] array6 = new int[2];
		array6[0] = 1;
		array[num5] = array6;
		array[5] = new int[]
		{
			1,
			2
		};
		this.mframeSuper = array;
	}

	// Token: 0x0600035C RID: 860 RVA: 0x0006DB20 File Offset: 0x0006BD20
	public static int HasHapThuEffPlus(Object_Effect_Skill objEff, MainObject obj, MainObject objFire, MainObject OBJMainEff)
	{
		bool flag = objEff == null || obj == null || objFire == null;
		int result;
		if (flag)
		{
			result = -1;
		}
		else
		{
			for (int i = 0; i < objEff.mEffTypePlus.Length; i++)
			{
				int num = objEff.mEffTypePlus[i];
				bool flag2 = num == 1058;
				if (flag2)
				{
					GameScreen.addEffectEnd(20, 0, obj.x, obj.y - obj.hOne / 2, (sbyte)obj.Dir, OBJMainEff);
					return i;
				}
			}
			result = -1;
		}
		return result;
	}

	// Token: 0x040003C4 RID: 964
	public const sbyte EFF_NORMAL = 0;

	// Token: 0x040003C5 RID: 965
	public const short EFF_ZORO_1 = 154;

	// Token: 0x040003C6 RID: 966
	public const short EFF_TASHIGI_2 = 155;

	// Token: 0x040003C7 RID: 967
	public const sbyte EFF_LUFFY_S1_L1 = 21;

	// Token: 0x040003C8 RID: 968
	public const sbyte EFF_LUFFY_S1_L2 = 33;

	// Token: 0x040003C9 RID: 969
	public const short EFF_LUFFY_S1_L3 = 83;

	// Token: 0x040003CA RID: 970
	public const short EFF_LUFFY_S1_L4 = 180;

	// Token: 0x040003CB RID: 971
	public const short EFF_LUFFY_S1_L5 = 212;

	// Token: 0x040003CC RID: 972
	public const short EFF_LUFFY_S1_L6 = 271;

	// Token: 0x040003CD RID: 973
	public const sbyte EFF_LUFFY_S2_L1 = 34;

	// Token: 0x040003CE RID: 974
	public const sbyte EFF_LUFFY_S2_L2 = 35;

	// Token: 0x040003CF RID: 975
	public const short EFF_LUFFY_S2_L3 = 84;

	// Token: 0x040003D0 RID: 976
	public const short EFF_LUFFY_S2_L4 = 181;

	// Token: 0x040003D1 RID: 977
	public const short EFF_LUFFY_S2_L5 = 213;

	// Token: 0x040003D2 RID: 978
	public const short EFF_LUFFY_S2_L6 = 272;

	// Token: 0x040003D3 RID: 979
	public const sbyte EFF_LUFFY_S3_L1 = 1;

	// Token: 0x040003D4 RID: 980
	public const sbyte EFF_LUFFY_S3_L2 = 37;

	// Token: 0x040003D5 RID: 981
	public const short EFF_LUFFY_S3_L3 = 85;

	// Token: 0x040003D6 RID: 982
	public const short EFF_LUFFY_S3_L4 = 182;

	// Token: 0x040003D7 RID: 983
	public const short EFF_LUFFY_S3_L5 = 214;

	// Token: 0x040003D8 RID: 984
	public const short EFF_LUFFY_S3_L6 = 273;

	// Token: 0x040003D9 RID: 985
	public const short EFF_LUFFY_SEA_L1 = 133;

	// Token: 0x040003DA RID: 986
	public const short EFF_LUFFY_SEA_L2 = 134;

	// Token: 0x040003DB RID: 987
	public const short EFF_LUFFY_SEA_L3 = 135;

	// Token: 0x040003DC RID: 988
	public const sbyte EFF_ZORO_S1_L1 = 38;

	// Token: 0x040003DD RID: 989
	public const sbyte EFF_ZORO_S1_L2 = 15;

	// Token: 0x040003DE RID: 990
	public const short EFF_ZORO_S1_L3 = 86;

	// Token: 0x040003DF RID: 991
	public const short EFF_ZORO_S1_L4 = 183;

	// Token: 0x040003E0 RID: 992
	public const short EFF_ZORO_S1_L5 = 215;

	// Token: 0x040003E1 RID: 993
	public const short EFF_ZORO_S1_L6 = 281;

	// Token: 0x040003E2 RID: 994
	public const sbyte EFF_ZORO_S2_L1 = 41;

	// Token: 0x040003E3 RID: 995
	public const sbyte EFF_ZORO_S2_L2 = 29;

	// Token: 0x040003E4 RID: 996
	public const short EFF_ZORO_S2_L3 = 87;

	// Token: 0x040003E5 RID: 997
	public const short EFF_ZORO_S2_L4 = 184;

	// Token: 0x040003E6 RID: 998
	public const short EFF_ZORO_S2_L5 = 216;

	// Token: 0x040003E7 RID: 999
	public const short EFF_ZORO_S2_L6 = 282;

	// Token: 0x040003E8 RID: 1000
	public const sbyte EFF_ZORO_S3_L1 = 121;

	// Token: 0x040003E9 RID: 1001
	public const sbyte EFF_ZORO_S3_L2 = 122;

	// Token: 0x040003EA RID: 1002
	public const short EFF_ZORO_S3_L3 = 123;

	// Token: 0x040003EB RID: 1003
	public const short EFF_ZORO_S3_L4 = 185;

	// Token: 0x040003EC RID: 1004
	public const short EFF_ZORO_S3_L5 = 217;

	// Token: 0x040003ED RID: 1005
	public const short EFF_ZORO_S3_L6 = 283;

	// Token: 0x040003EE RID: 1006
	public const sbyte EFF_ZORO_SEA_L1 = 42;

	// Token: 0x040003EF RID: 1007
	public const sbyte EFF_ZORO_SEA_L2 = 43;

	// Token: 0x040003F0 RID: 1008
	public const sbyte EFF_ZORO_SEA_L3 = 19;

	// Token: 0x040003F1 RID: 1009
	public const sbyte EFF_SANJI_S1_L1 = 14;

	// Token: 0x040003F2 RID: 1010
	public const sbyte EFF_SANJI_S1_L2 = 44;

	// Token: 0x040003F3 RID: 1011
	public const short EFF_SANJI_S1_L3 = 124;

	// Token: 0x040003F4 RID: 1012
	public const short EFF_SANJI_S1_L4 = 186;

	// Token: 0x040003F5 RID: 1013
	public const short EFF_SANJI_S1_L5 = 218;

	// Token: 0x040003F6 RID: 1014
	public const short EFF_SANJI_S1_L6 = 291;

	// Token: 0x040003F7 RID: 1015
	public const sbyte EFF_SANJI_S2_L1 = 47;

	// Token: 0x040003F8 RID: 1016
	public const sbyte EFF_SANJI_S2_L2 = 48;

	// Token: 0x040003F9 RID: 1017
	public const short EFF_SANJI_S2_L3 = 125;

	// Token: 0x040003FA RID: 1018
	public const short EFF_SANJI_S2_L4 = 187;

	// Token: 0x040003FB RID: 1019
	public const short EFF_SANJI_S2_L5 = 219;

	// Token: 0x040003FC RID: 1020
	public const short EFF_SANJI_S2_L6 = 292;

	// Token: 0x040003FD RID: 1021
	public const sbyte EFF_SANJI_S3_L1 = 49;

	// Token: 0x040003FE RID: 1022
	public const sbyte EFF_SANJI_S3_L2 = 50;

	// Token: 0x040003FF RID: 1023
	public const short EFF_SANJI_S3_L3 = 12;

	// Token: 0x04000400 RID: 1024
	public const short EFF_SANJI_S3_L4 = 188;

	// Token: 0x04000401 RID: 1025
	public const short EFF_SANJI_S3_L5 = 220;

	// Token: 0x04000402 RID: 1026
	public const short EFF_SANJI_S3_L6 = 293;

	// Token: 0x04000403 RID: 1027
	public const short EFF_SANJI_SEA_L1 = 136;

	// Token: 0x04000404 RID: 1028
	public const short EFF_SANJI_SEA_L2 = 137;

	// Token: 0x04000405 RID: 1029
	public const short EFF_SANJI_SEA_L3 = 138;

	// Token: 0x04000406 RID: 1030
	public const sbyte EFF_NAMI_S1_L1 = 16;

	// Token: 0x04000407 RID: 1031
	public const sbyte EFF_NAMI_S1_L2 = 51;

	// Token: 0x04000408 RID: 1032
	public const short EFF_NAMI_S1_L3 = 52;

	// Token: 0x04000409 RID: 1033
	public const short EFF_NAMI_S1_L4 = 189;

	// Token: 0x0400040A RID: 1034
	public const short EFF_NAMI_S1_L5 = 221;

	// Token: 0x0400040B RID: 1035
	public const short EFF_NAMI_S1_L6 = 311;

	// Token: 0x0400040C RID: 1036
	public const sbyte EFF_NAMI_S2_L1 = 9;

	// Token: 0x0400040D RID: 1037
	public const sbyte EFF_NAMI_S2_L2 = 53;

	// Token: 0x0400040E RID: 1038
	public const short EFF_NAMI_S2_L3 = 63;

	// Token: 0x0400040F RID: 1039
	public const short EFF_NAMI_S2_L4 = 190;

	// Token: 0x04000410 RID: 1040
	public const short EFF_NAMI_S2_L5 = 222;

	// Token: 0x04000411 RID: 1041
	public const short EFF_NAMI_S2_L6 = 312;

	// Token: 0x04000412 RID: 1042
	public const sbyte EFF_NAMI_S3_L1 = 31;

	// Token: 0x04000413 RID: 1043
	public const sbyte EFF_NAMI_S3_L2 = 55;

	// Token: 0x04000414 RID: 1044
	public const short EFF_NAMI_S3_L3 = 56;

	// Token: 0x04000415 RID: 1045
	public const short EFF_NAMI_S3_L4 = 191;

	// Token: 0x04000416 RID: 1046
	public const short EFF_NAMI_S3_L5 = 223;

	// Token: 0x04000417 RID: 1047
	public const short EFF_NAMI_S3_L6 = 313;

	// Token: 0x04000418 RID: 1048
	public const sbyte EFF_NAMI_SEA_L1 = 11;

	// Token: 0x04000419 RID: 1049
	public const short EFF_NAMI_SEA_L2 = 139;

	// Token: 0x0400041A RID: 1050
	public const short EFF_NAMI_SEA_L3 = 140;

	// Token: 0x0400041B RID: 1051
	public const sbyte EFF_USSOP_S1_L1 = 57;

	// Token: 0x0400041C RID: 1052
	public const sbyte EFF_USSOP_S1_L2 = 58;

	// Token: 0x0400041D RID: 1053
	public const short EFF_USSOP_S1_L3 = 126;

	// Token: 0x0400041E RID: 1054
	public const short EFF_USSOP_S1_L4 = 192;

	// Token: 0x0400041F RID: 1055
	public const short EFF_USSOP_S1_L5 = 224;

	// Token: 0x04000420 RID: 1056
	public const short EFF_USSOP_S1_L6 = 301;

	// Token: 0x04000421 RID: 1057
	public const sbyte EFF_USSOP_S2_L1 = 64;

	// Token: 0x04000422 RID: 1058
	public const sbyte EFF_USSOP_S2_L2 = 66;

	// Token: 0x04000423 RID: 1059
	public const short EFF_USSOP_S2_L3 = 127;

	// Token: 0x04000424 RID: 1060
	public const short EFF_USSOP_S2_L4 = 193;

	// Token: 0x04000425 RID: 1061
	public const short EFF_USSOP_S2_L5 = 225;

	// Token: 0x04000426 RID: 1062
	public const short EFF_USSOP_S2_L6 = 302;

	// Token: 0x04000427 RID: 1063
	public const sbyte EFF_USSOP_S3_L1 = 67;

	// Token: 0x04000428 RID: 1064
	public const sbyte EFF_USSOP_S3_L2 = 68;

	// Token: 0x04000429 RID: 1065
	public const short EFF_USSOP_S3_L3 = 69;

	// Token: 0x0400042A RID: 1066
	public const short EFF_USSOP_S3_L4 = 194;

	// Token: 0x0400042B RID: 1067
	public const short EFF_USSOP_S3_L5 = 226;

	// Token: 0x0400042C RID: 1068
	public const short EFF_USSOP_S3_L6 = 303;

	// Token: 0x0400042D RID: 1069
	public const sbyte EFF_USSOP_SEA_L1 = 7;

	// Token: 0x0400042E RID: 1070
	public const short EFF_USSOP_SEA_L2 = 141;

	// Token: 0x0400042F RID: 1071
	public const short EFF_USSOP_SEA_L3 = 142;

	// Token: 0x04000430 RID: 1072
	public const short EFF_LUFFY_S1_L3_OLD = 156;

	// Token: 0x04000431 RID: 1073
	public const short EFF_LUFFY_S2_L3_OLD = 160;

	// Token: 0x04000432 RID: 1074
	public const short EFF_ZORO_S1_L3_OLD = 157;

	// Token: 0x04000433 RID: 1075
	public const short EFF_ZORO_S2_L3_SHORT_OLD = 161;

	// Token: 0x04000434 RID: 1076
	public const short EFF_SANJI_S1_L3_OLD = 158;

	// Token: 0x04000435 RID: 1077
	public const short EFF_SANJI_S2_L3_OLD = 162;

	// Token: 0x04000436 RID: 1078
	public const short EFF_NAMI_S2_L3_OLD = 163;

	// Token: 0x04000437 RID: 1079
	public const short EFF_USSOP_S1_L3_OLD = 159;

	// Token: 0x04000438 RID: 1080
	public const sbyte EFF_BUFF = 46;

	// Token: 0x04000439 RID: 1081
	public const short EFF_BUFF_2 = 165;

	// Token: 0x0400043A RID: 1082
	public const short EFF_END_BUFF_2 = 166;

	// Token: 0x0400043B RID: 1083
	public const short EFF_GET_MONEY = 17;

	// Token: 0x0400043C RID: 1084
	public const short EFF_CAUSU_1 = 164;

	// Token: 0x0400043D RID: 1085
	public const short EFF_CAUSU_1_L2 = 227;

	// Token: 0x0400043E RID: 1086
	public const sbyte EFF_ACE_1 = 2;

	// Token: 0x0400043F RID: 1087
	public const short EFF_ACE_1_L2 = 228;

	// Token: 0x04000440 RID: 1088
	public const short EFF_ACE_1_L2_SUPER_1 = 259;

	// Token: 0x04000441 RID: 1089
	public const short EFF_ACE_1_L2_SUPER_2 = 260;

	// Token: 0x04000442 RID: 1090
	public const short EFF_ACE_1_L2_SUPER_3 = 261;

	// Token: 0x04000443 RID: 1091
	public const sbyte EFF_ACE_2 = 3;

	// Token: 0x04000444 RID: 1092
	public const short EFF_ACE_2_L2 = 229;

	// Token: 0x04000445 RID: 1093
	public const short EFF_ACE_2_L2_SUPER_1 = 262;

	// Token: 0x04000446 RID: 1094
	public const short EFF_ACE_2_L2_SUPER_2 = 263;

	// Token: 0x04000447 RID: 1095
	public const short EFF_ACE_2_L2_SUPER_3 = 264;

	// Token: 0x04000448 RID: 1096
	public const sbyte EFF_AOKIJI_1 = 4;

	// Token: 0x04000449 RID: 1097
	public const short EFF_AOKIJI_1_L2 = 230;

	// Token: 0x0400044A RID: 1098
	public const sbyte EFF_AOKIJI_2 = 5;

	// Token: 0x0400044B RID: 1099
	public const short EFF_AOKIJI_2_L2 = 231;

	// Token: 0x0400044C RID: 1100
	public const sbyte EFF_SMOKER_1 = 6;

	// Token: 0x0400044D RID: 1101
	public const short EFF_SMOKER_1_L2 = 232;

	// Token: 0x0400044E RID: 1102
	public const sbyte EFF_SMOKER_2 = 10;

	// Token: 0x0400044F RID: 1103
	public const short EFF_SMOKER_2_L2 = 234;

	// Token: 0x04000450 RID: 1104
	public const sbyte EFF_CROCODILE_1 = 25;

	// Token: 0x04000451 RID: 1105
	public const short EFF_CROCODILE_1_L2 = 235;

	// Token: 0x04000452 RID: 1106
	public const sbyte EFF_CROCODILE_2 = 26;

	// Token: 0x04000453 RID: 1107
	public const short EFF_CROCODILE_2_L2 = 236;

	// Token: 0x04000454 RID: 1108
	public const short EFF_SET_1 = 169;

	// Token: 0x04000455 RID: 1109
	public const short EFF_SET_1_L2 = 237;

	// Token: 0x04000456 RID: 1110
	public const short EFF_SET_2 = 170;

	// Token: 0x04000457 RID: 1111
	public const short EFF_SET_2_L2 = 238;

	// Token: 0x04000458 RID: 1112
	public const short EFF_NHAM_THACH_1 = 171;

	// Token: 0x04000459 RID: 1113
	public const short EFF_NHAM_THACH_1_L2 = 239;

	// Token: 0x0400045A RID: 1114
	public const short EFF_NHAM_THACH_2 = 172;

	// Token: 0x0400045B RID: 1115
	public const short EFF_NHAM_THACH_2_L2 = 240;

	// Token: 0x0400045C RID: 1116
	public const short EFF_PELL_1 = 179;

	// Token: 0x0400045D RID: 1117
	public const short EFF_PELL_1_L2 = 241;

	// Token: 0x0400045E RID: 1118
	public const short EFF_LUCCI_1 = 209;

	// Token: 0x0400045F RID: 1119
	public const short EFF_LUCCI_1_L2 = 242;

	// Token: 0x04000460 RID: 1120
	public const short EFF_DONG_DAT_1 = 210;

	// Token: 0x04000461 RID: 1121
	public const short EFF_DONG_DAT_1_L2 = 243;

	// Token: 0x04000462 RID: 1122
	public const short EFF_DONG_DAT_2 = 211;

	// Token: 0x04000463 RID: 1123
	public const short EFF_DONG_DAT_2_L2 = 244;

	// Token: 0x04000464 RID: 1124
	public const short EFF_MR5_1 = 233;

	// Token: 0x04000465 RID: 1125
	public const short EFF_DAO_1 = 245;

	// Token: 0x04000466 RID: 1126
	public const short EFF_DAO_1_L2 = 251;

	// Token: 0x04000467 RID: 1127
	public const short EFF_SAP_1 = 246;

	// Token: 0x04000468 RID: 1128
	public const short EFF_SAP_1_L2 = 253;

	// Token: 0x04000469 RID: 1129
	public const short EFF_SAP_2 = 247;

	// Token: 0x0400046A RID: 1130
	public const short EFF_SAP_2_L2 = 254;

	// Token: 0x0400046B RID: 1131
	public const short EFF_KILO_1 = 248;

	// Token: 0x0400046C RID: 1132
	public const short EFF_KILO_1_L2 = 255;

	// Token: 0x0400046D RID: 1133
	public const short EFF_DAO_2 = 249;

	// Token: 0x0400046E RID: 1134
	public const short EFF_DAO_2_L2 = 252;

	// Token: 0x0400046F RID: 1135
	public const short EFF_RANKYAKU = 266;

	// Token: 0x04000470 RID: 1136
	public const short EFF_SHIGAN = 267;

	// Token: 0x04000471 RID: 1137
	public const short EFF_DOOR = 268;

	// Token: 0x04000472 RID: 1138
	public const short EFF_DOOR_L2 = 269;

	// Token: 0x04000473 RID: 1139
	public const short EFF_KUMADORI = 270;

	// Token: 0x04000474 RID: 1140
	public const short EFF_XA_PHONG = 274;

	// Token: 0x04000475 RID: 1141
	public const short EFF_XA_PHONG_L2 = 275;

	// Token: 0x04000476 RID: 1142
	public const short EFF_SOI = 276;

	// Token: 0x04000477 RID: 1143
	public const short EFF_SOI_L2 = 277;

	// Token: 0x04000478 RID: 1144
	public const short EFF_HUOU = 278;

	// Token: 0x04000479 RID: 1145
	public const short EFF_HUOU_L2 = 279;

	// Token: 0x0400047A RID: 1146
	public const short EFF_GOAL = 280;

	// Token: 0x0400047B RID: 1147
	public const sbyte EFF_MON_1 = 30;

	// Token: 0x0400047C RID: 1148
	public const sbyte EFF_MON_2 = 71;

	// Token: 0x0400047D RID: 1149
	public const sbyte EFF_MON_3 = 72;

	// Token: 0x0400047E RID: 1150
	public const sbyte EFF_MON_4 = 73;

	// Token: 0x0400047F RID: 1151
	public const sbyte EFF_MON_5 = 74;

	// Token: 0x04000480 RID: 1152
	public const sbyte EFF_MON_6 = 75;

	// Token: 0x04000481 RID: 1153
	public const sbyte EFF_ALVIDA_1 = 76;

	// Token: 0x04000482 RID: 1154
	public const sbyte EFF_ALVIDA_2 = 77;

	// Token: 0x04000483 RID: 1155
	public const sbyte EFF_MON_7 = 78;

	// Token: 0x04000484 RID: 1156
	public const sbyte EFF_MON_8 = 79;

	// Token: 0x04000485 RID: 1157
	public const sbyte EFF_MON_9 = 80;

	// Token: 0x04000486 RID: 1158
	public const sbyte EFF_MON_10 = 81;

	// Token: 0x04000487 RID: 1159
	public const sbyte EFF_MON_11 = 82;

	// Token: 0x04000488 RID: 1160
	public const sbyte EFF_MORGAN_1 = 88;

	// Token: 0x04000489 RID: 1161
	public const sbyte EFF_MORGAN_2 = 89;

	// Token: 0x0400048A RID: 1162
	public const sbyte EFF_HELMEPO_1 = 90;

	// Token: 0x0400048B RID: 1163
	public const sbyte EFF_HELMEPO_2 = 91;

	// Token: 0x0400048C RID: 1164
	public const sbyte EFF_MON_12 = 92;

	// Token: 0x0400048D RID: 1165
	public const sbyte EFF_MOHJI_1 = 93;

	// Token: 0x0400048E RID: 1166
	public const sbyte EFF_MOHJI_2 = 94;

	// Token: 0x0400048F RID: 1167
	public const sbyte EFF_BUGGY_1 = 95;

	// Token: 0x04000490 RID: 1168
	public const sbyte EFF_BUGGY_2 = 96;

	// Token: 0x04000491 RID: 1169
	public const sbyte EFF_CABAJI_1 = 97;

	// Token: 0x04000492 RID: 1170
	public const sbyte EFF_CABAJI_2 = 98;

	// Token: 0x04000493 RID: 1171
	public const sbyte EFF_NYABAN_1 = 99;

	// Token: 0x04000494 RID: 1172
	public const sbyte EFF_NYABAN_2 = 100;

	// Token: 0x04000495 RID: 1173
	public const sbyte EFF_NYABAN_3 = 101;

	// Token: 0x04000496 RID: 1174
	public const sbyte EFF_JANGO_1 = 102;

	// Token: 0x04000497 RID: 1175
	public const sbyte EFF_KURO_1 = 103;

	// Token: 0x04000498 RID: 1176
	public const sbyte EFF_KURO_2 = 104;

	// Token: 0x04000499 RID: 1177
	public const sbyte EFF_PEARL_1 = 105;

	// Token: 0x0400049A RID: 1178
	public const sbyte EFF_PEARL_2 = 106;

	// Token: 0x0400049B RID: 1179
	public const sbyte EFF_GHIN_1 = 107;

	// Token: 0x0400049C RID: 1180
	public const sbyte EFF_GHIN_2 = 108;

	// Token: 0x0400049D RID: 1181
	public const sbyte EFF_DON_KRIEG_1 = 109;

	// Token: 0x0400049E RID: 1182
	public const sbyte EFF_DON_KRIEG_2 = 110;

	// Token: 0x0400049F RID: 1183
	public const sbyte EFF_DON_KRIEG_3 = 111;

	// Token: 0x040004A0 RID: 1184
	public const sbyte EFF_HACHI_1 = 112;

	// Token: 0x040004A1 RID: 1185
	public const sbyte EFF_HACHI_2 = 113;

	// Token: 0x040004A2 RID: 1186
	public const sbyte EFF_CHU_1 = 114;

	// Token: 0x040004A3 RID: 1187
	public const sbyte EFF_CHU_2 = 115;

	// Token: 0x040004A4 RID: 1188
	public const sbyte EFF_KUROBI_1 = 116;

	// Token: 0x040004A5 RID: 1189
	public const sbyte EFF_KUROBI_2 = 117;

	// Token: 0x040004A6 RID: 1190
	public const sbyte EFF_ARLONG_1 = 118;

	// Token: 0x040004A7 RID: 1191
	public const sbyte EFF_ARLONG_2 = 119;

	// Token: 0x040004A8 RID: 1192
	public const sbyte EFF_ARLONG_3 = 120;

	// Token: 0x040004A9 RID: 1193
	public const short EFF_MON_13 = 128;

	// Token: 0x040004AA RID: 1194
	public const short EFF_MON_14 = 129;

	// Token: 0x040004AB RID: 1195
	public const short EFF_MON_15 = 130;

	// Token: 0x040004AC RID: 1196
	public const short EFF_MON_16 = 131;

	// Token: 0x040004AD RID: 1197
	public const short EFF_MON_17 = 132;

	// Token: 0x040004AE RID: 1198
	public const short EFF_MON_18 = 143;

	// Token: 0x040004AF RID: 1199
	public const short EFF_MON_19 = 144;

	// Token: 0x040004B0 RID: 1200
	public const short EFF_MON_20 = 145;

	// Token: 0x040004B1 RID: 1201
	public const short EFF_MON_21 = 146;

	// Token: 0x040004B2 RID: 1202
	public const short EFF_MON_22 = 147;

	// Token: 0x040004B3 RID: 1203
	public const short EFF_MON_23 = 148;

	// Token: 0x040004B4 RID: 1204
	public const short EFF_MON_24 = 149;

	// Token: 0x040004B5 RID: 1205
	public const short EFF_MON_25 = 150;

	// Token: 0x040004B6 RID: 1206
	public const short EFF_MON_26 = 151;

	// Token: 0x040004B7 RID: 1207
	public const short EFF_MON_27 = 152;

	// Token: 0x040004B8 RID: 1208
	public const short EFF_MON_28 = 153;

	// Token: 0x040004B9 RID: 1209
	public const short EFF_MON_SMOKER_1 = 13;

	// Token: 0x040004BA RID: 1210
	public const short EFF_MON_SMOKER_2 = 18;

	// Token: 0x040004BB RID: 1211
	public const short EFF_MON_VALENTINE = 20;

	// Token: 0x040004BC RID: 1212
	public const short EFF_MON_VALENTINE_2 = 22;

	// Token: 0x040004BD RID: 1213
	public const short EFF_MON_MR5 = 23;

	// Token: 0x040004BE RID: 1214
	public const short EFF_MON_MR5_2 = 24;

	// Token: 0x040004BF RID: 1215
	public const short EFF_MON_CHESS = 27;

	// Token: 0x040004C0 RID: 1216
	public const short EFF_MON_KUROMARIMO = 28;

	// Token: 0x040004C1 RID: 1217
	public const short EFF_WAPOL_1 = 32;

	// Token: 0x040004C2 RID: 1218
	public const short EFF_WAPOL_2 = 36;

	// Token: 0x040004C3 RID: 1219
	public const short EFF_WAPOL_3 = 39;

	// Token: 0x040004C4 RID: 1220
	public const short EFF_WAPOL_4 = 40;

	// Token: 0x040004C5 RID: 1221
	public const short EFF_MR3_1 = 45;

	// Token: 0x040004C6 RID: 1222
	public const short EFF_MR3_2 = 54;

	// Token: 0x040004C7 RID: 1223
	public const short EFF_MISS_GOLDEN_WEEKEND_1 = 59;

	// Token: 0x040004C8 RID: 1224
	public const short EFF_MISS_GOLDEN_WEEKEND_2 = 60;

	// Token: 0x040004C9 RID: 1225
	public const short EFF_LAPIN = 61;

	// Token: 0x040004CA RID: 1226
	public const short EFF_MON_29 = 62;

	// Token: 0x040004CB RID: 1227
	public const sbyte EFF_MR4_1 = 65;

	// Token: 0x040004CC RID: 1228
	public const sbyte EFF_MR4_2 = 70;

	// Token: 0x040004CD RID: 1229
	public const short EFF_MISS_MS_1 = 167;

	// Token: 0x040004CE RID: 1230
	public const short EFF_MR1_1 = 168;

	// Token: 0x040004CF RID: 1231
	public const short EFF_MR1_2 = 173;

	// Token: 0x040004D0 RID: 1232
	public const short EFF_DF_1 = 174;

	// Token: 0x040004D1 RID: 1233
	public const short EFF_DF_2 = 175;

	// Token: 0x040004D2 RID: 1234
	public const short EFF_MR2_1 = 176;

	// Token: 0x040004D3 RID: 1235
	public const short EFF_MR2_2 = 177;

	// Token: 0x040004D4 RID: 1236
	public const short EFF_MR0_1 = 178;

	// Token: 0x040004D5 RID: 1237
	public const short EFF_ENEL_1 = 195;

	// Token: 0x040004D6 RID: 1238
	public const short EFF_ENEL_2 = 196;

	// Token: 0x040004D7 RID: 1239
	public const short EFF_ENEL_3 = 197;

	// Token: 0x040004D8 RID: 1240
	public const short EFF_SATORI_1 = 198;

	// Token: 0x040004D9 RID: 1241
	public const short EFF_SATORI_2 = 199;

	// Token: 0x040004DA RID: 1242
	public const short EFF_OHM_1 = 200;

	// Token: 0x040004DB RID: 1243
	public const short EFF_OHM_2 = 201;

	// Token: 0x040004DC RID: 1244
	public const short EFF_GEDATSU_1 = 202;

	// Token: 0x040004DD RID: 1245
	public const short EFF_GEDATSU_2 = 203;

	// Token: 0x040004DE RID: 1246
	public const short EFF_SHURA_1 = 204;

	// Token: 0x040004DF RID: 1247
	public const short EFF_SHURA_2 = 205;

	// Token: 0x040004E0 RID: 1248
	public const short EFF_LINH_TROI_1 = 206;

	// Token: 0x040004E1 RID: 1249
	public const short EFF_LINH_TROI_2 = 207;

	// Token: 0x040004E2 RID: 1250
	public const short EFF_TRU_1 = 208;

	// Token: 0x040004E3 RID: 1251
	public const short EFF_TRU_2_LAN = 250;

	// Token: 0x040004E4 RID: 1252
	public const short EFF_THA_DEN = 256;

	// Token: 0x040004E5 RID: 1253
	public const short EFF_THA_PHAO_HOA = 257;

	// Token: 0x040004E6 RID: 1254
	public const short EFF_SNOW_DOWN = 258;

	// Token: 0x040004E7 RID: 1255
	public const short EFF_LAW_HEART = 265;

	// Token: 0x040004E8 RID: 1256
	public const short EFF_PANTHEONG_1 = 10001;

	// Token: 0x040004E9 RID: 1257
	public const short EFF_PANTHEONG_2 = 10002;

	// Token: 0x040004EA RID: 1258
	public const short EFF_GALIO_1 = 10003;

	// Token: 0x040004EB RID: 1259
	public const short EFF_GALIO_2 = 10004;

	// Token: 0x040004EC RID: 1260
	public const short EFF_NO_NANG_LUONG_1 = 10005;

	// Token: 0x040004ED RID: 1261
	public const short EFF_NO_NANG_LUONG_2 = 10006;

	// Token: 0x040004EE RID: 1262
	public const short EFF_NO_NANG_LUONG_3 = 10007;

	// Token: 0x040004EF RID: 1263
	public const short EFF_NO_THEO_HUONG_1 = 10008;

	// Token: 0x040004F0 RID: 1264
	public const short EFF_NO_THEO_HUONG_2 = 10009;

	// Token: 0x040004F1 RID: 1265
	public const short EFF_XERATH_1 = 10010;

	// Token: 0x040004F2 RID: 1266
	public const short EFF_XERATH_2 = 10011;

	// Token: 0x040004F3 RID: 1267
	public const short EFF_XERATH_3 = 10012;

	// Token: 0x040004F4 RID: 1268
	public const short EFF_URGOT_1 = 10013;

	// Token: 0x040004F5 RID: 1269
	public const short EFF_URGOT_2 = 10014;

	// Token: 0x040004F6 RID: 1270
	public const short EFF_URGOT_3 = 10015;

	// Token: 0x040004F7 RID: 1271
	public const short EFF_URGOT_4 = 10016;

	// Token: 0x040004F8 RID: 1272
	public const short EFF_MONSTER_HUT_MAU = 10017;

	// Token: 0x040004F9 RID: 1273
	public const short EFF_MONSTER_CHAY_THANG_1 = 10018;

	// Token: 0x040004FA RID: 1274
	public const short EFF_MONSTER_CHAY_THANG_2 = 10019;

	// Token: 0x040004FB RID: 1275
	public const short EFF_MONSTER_GIAP_GAI = 10020;

	// Token: 0x040004FC RID: 1276
	public const short EFF_MONSTER_HUT_MANA = 10021;

	// Token: 0x040004FD RID: 1277
	public const short EFF_MONSTER_DANH_TRON_1 = 10022;

	// Token: 0x040004FE RID: 1278
	public const short EFF_MONSTER_DANH_TRON_2 = 10023;

	// Token: 0x040004FF RID: 1279
	public const short EFF_MONSTER_NEM_BOOM_1 = 10024;

	// Token: 0x04000500 RID: 1280
	public const short EFF_MONSTER_NEM_BOOM_2 = 10025;

	// Token: 0x04000501 RID: 1281
	public const short EFF_MONSTER_KHONG_DANH_1 = 10026;

	// Token: 0x04000502 RID: 1282
	public const short EFF_MONSTER_KHONG_DANH_2 = 10027;

	// Token: 0x04000503 RID: 1283
	public const short EFF_TRAI_AC_QUY_HO_DEN_VU_TRU = 10028;

	// Token: 0x04000504 RID: 1284
	public const short EFF_BLACK_HOLE_1 = 400;

	// Token: 0x04000505 RID: 1285
	public const short EFF_TRAI_AC_QUY_HO_DEN_VU_TRU_3 = 10030;

	// Token: 0x04000506 RID: 1286
	public const short EFF_BLACK_HOLE_2 = 401;

	// Token: 0x04000507 RID: 1287
	public const short EFF_BLACK_HOLE_1_LV5 = 402;

	// Token: 0x04000508 RID: 1288
	public const short EFF_BLACK_HOLE_2_LV5 = 403;

	// Token: 0x04000509 RID: 1289
	public const sbyte EFF_DAN_FOCUS = -1;

	// Token: 0x0400050A RID: 1290
	public const short EFF_SPEC_CRI = 1010;

	// Token: 0x0400050B RID: 1291
	public const short EFF_SPEC_GIAP = 1013;

	// Token: 0x0400050C RID: 1292
	public const short EFF_SPEC_PHAN = 1014;

	// Token: 0x0400050D RID: 1293
	public const short EFF_SPEC_HUT_HP = 1021;

	// Token: 0x0400050E RID: 1294
	public const short EFF_SPEC_HUT_MP = 1022;

	// Token: 0x0400050F RID: 1295
	public const short EFF_SPEC_HAP_THU = 1058;

	// Token: 0x04000510 RID: 1296
	public int[][][] skillZoro3;

	// Token: 0x04000511 RID: 1297
	public int[][] Mr1;

	// Token: 0x04000512 RID: 1298
	public int[][] speedEff;

	// Token: 0x04000513 RID: 1299
	public int subType;

	// Token: 0x04000514 RID: 1300
	public int waitTick;

	// Token: 0x04000515 RID: 1301
	public int indexObjBefire;

	// Token: 0x04000516 RID: 1302
	public int xArchor;

	// Token: 0x04000517 RID: 1303
	public int yArchor;

	// Token: 0x04000518 RID: 1304
	public int[][] plusxy;

	// Token: 0x04000519 RID: 1305
	public int[][] mframeSuper;

	// Token: 0x0400051A RID: 1306
	public int fPlayFrameSuper;

	// Token: 0x0400051B RID: 1307
	public int fPre;

	// Token: 0x0400051C RID: 1308
	public FrameImage[] mImgframe;

	// Token: 0x0400051D RID: 1309
	public bool isAddSound;

	// Token: 0x0400051E RID: 1310
	public bool isaddEff;

	// Token: 0x0400051F RID: 1311
	public MainObject objBeFireMain;

	// Token: 0x04000520 RID: 1312
	public mVector VecEff;

	// Token: 0x04000521 RID: 1313
	public mVector VecSubEff;

	// Token: 0x04000522 RID: 1314
	public mVector vecPos;

	// Token: 0x04000523 RID: 1315
	public mVector vectargetPos;

	// Token: 0x04000524 RID: 1316
	public short[] posSmock;

	// Token: 0x04000525 RID: 1317
	private int vXTam;

	// Token: 0x04000526 RID: 1318
	private int vYTam;

	// Token: 0x04000527 RID: 1319
	private new int x1000;

	// Token: 0x04000528 RID: 1320
	private new int y1000;

	// Token: 0x04000529 RID: 1321
	private int vX1000;

	// Token: 0x0400052A RID: 1322
	private int vY1000;

	// Token: 0x0400052B RID: 1323
	private int xEff;

	// Token: 0x0400052C RID: 1324
	private int yEff;

	// Token: 0x0400052D RID: 1325
	private int angle;

	// Token: 0x0400052E RID: 1326
	private int R;

	// Token: 0x0400052F RID: 1327
	private int size1;

	// Token: 0x04000530 RID: 1328
	private int[][] mTamgiac;

	// Token: 0x04000531 RID: 1329
	private int lT_Arc;

	// Token: 0x04000532 RID: 1330
	private int gocT_Arc;

	// Token: 0x04000533 RID: 1331
	private int r;

	// Token: 0x04000534 RID: 1332
	public int[] radian;

	// Token: 0x04000535 RID: 1333
	public int CR;

	// Token: 0x04000536 RID: 1334
	public int Ctick;

	// Token: 0x04000537 RID: 1335
	public int t2;

	// Token: 0x04000538 RID: 1336
	private int disHard;

	// Token: 0x04000539 RID: 1337
	private int tickadd;

	// Token: 0x0400053A RID: 1338
	private Point_Focus rocket1;

	// Token: 0x0400053B RID: 1339
	private Point_Focus rocket2;

	// Token: 0x0400053C RID: 1340
	private int frame1;

	// Token: 0x0400053D RID: 1341
	private int frame2;

	// Token: 0x0400053E RID: 1342
	private int xLight1;

	// Token: 0x0400053F RID: 1343
	private int xLight2;

	// Token: 0x04000540 RID: 1344
	private int giatocFly;

	// Token: 0x04000541 RID: 1345
	private int fSpeedTest;
}
