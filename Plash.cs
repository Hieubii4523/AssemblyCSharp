using System;

// Token: 0x020000CB RID: 203
public class Plash
{
	// Token: 0x06000B93 RID: 2963 RVA: 0x0000B6E4 File Offset: 0x000098E4
	public Plash()
	{
	}

	// Token: 0x06000B94 RID: 2964 RVA: 0x000DE47C File Offset: 0x000DC67C
	public Plash(MainSkill skill, MainObject obj, mVector vec)
	{
		this.skill = skill;
		this.vecObj = vec;
		this.objFire = obj;
		this.timeEndPlash = skill.timebuff;
		this.isNextf = 0;
		bool flag = skill.timeBegin == 0L;
		if (flag)
		{
			this.timebeginSkill = GameCanvas.timeNow;
		}
		else
		{
			this.timebeginSkill = skill.timeBegin;
		}
		bool flag2 = vec != null && vec.size() > 0;
		if (flag2)
		{
			Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObj.elementAt(0);
			MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
			bool flag3 = mainObject == null;
			if (flag3)
			{
				return;
			}
			bool flag4 = this.objFire != mainObject;
			if (flag4)
			{
				bool flag5 = this.objFire.x < mainObject.x;
				if (flag5)
				{
					this.objFire.Dir = 2;
					this.objFire.type_left_right = 2;
				}
				else
				{
					this.objFire.Dir = 0;
					this.objFire.type_left_right = 0;
				}
			}
		}
		this.getTypePlash(skill.typeEffSkill);
		this.plashdata = this.getPlashData(this.typePlash);
		this.f = -1;
		this.removef = this.plashdata.mDataPlash.Length;
	}

	// Token: 0x06000B95 RID: 2965 RVA: 0x000DE5CC File Offset: 0x000DC7CC
	public Plash(MainSkill skill, MainObject obj, mVector vec, bool isShow)
	{
		this.skill = skill;
		this.vecObj = vec;
		this.objFire = obj;
		this.timeEndPlash = skill.timebuff;
		this.isShow = isShow;
		this.isNextf = 0;
		bool flag = skill.timeBegin == 0L;
		if (flag)
		{
			this.timebeginSkill = GameCanvas.timeNow;
		}
		else
		{
			this.timebeginSkill = skill.timeBegin;
		}
		this.getTypePlash(skill.typeEffSkill);
		this.plashdata = this.getPlashData(this.typePlash);
		this.f = -1;
		this.removef = this.plashdata.mDataPlash.Length;
	}

	// Token: 0x06000B96 RID: 2966 RVA: 0x000090B5 File Offset: 0x000072B5
	public void endArray()
	{
	}

	// Token: 0x06000B97 RID: 2967 RVA: 0x000DE678 File Offset: 0x000DC878
	public Plashdata getPlashData(short index)
	{
		Plashdata plashdata = (Plashdata)Plash.hashPlash.get(string.Empty + index.ToString());
		bool flag = plashdata == null;
		if (flag)
		{
			GlobalService.gI().GetTemplate(97, index);
			plashdata = new Plashdata();
		}
		return plashdata;
	}

	// Token: 0x06000B98 RID: 2968 RVA: 0x000DE6CC File Offset: 0x000DC8CC
	public short getTypePlash(short type)
	{
		switch (type)
		{
		case 1:
		case 37:
		case 112:
		case 270:
			this.typePlash = 0;
			this.fAddEff = 9;
			break;
		case 2:
			this.typePlash = 111;
			this.fAddEff = 0;
			break;
		case 3:
		case 229:
		case 262:
		case 263:
		case 264:
			this.typePlash = 112;
			this.fAddEff = 0;
			break;
		case 4:
		case 230:
		case 246:
		case 253:
			this.typePlash = 113;
			this.fAddEff = 4;
			break;
		case 5:
		case 231:
			this.typePlash = 114;
			this.fAddEff = 4;
			break;
		case 6:
		case 232:
			this.typePlash = 115;
			this.fAddEff = 0;
			break;
		case 7:
			this.typePlash = 4;
			this.fAddEff = 0;
			break;
		case 8:
		case 13:
		case 22:
		case 61:
		case 62:
		case 81:
		case 82:
		case 144:
		case 145:
		case 146:
		case 147:
		case 148:
		case 149:
		case 150:
		case 151:
		case 152:
		case 153:
		case 154:
		case 233:
		case 250:
		case 268:
		case 269:
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
			this.typePlash = 6;
			this.fAddEff = 6;
			break;
		case 10:
		case 234:
			this.typePlash = 116;
			this.fAddEff = 0;
			break;
		case 11:
			this.typePlash = 8;
			this.fAddEff = 0;
			break;
		case 12:
		case 188:
		case 220:
		case 293:
			this.typePlash = 134;
			this.fAddEff = 6;
			break;
		case 14:
		case 44:
			this.typePlash = 12;
			this.fAddEff = 6;
			break;
		case 15:
			this.typePlash = 13;
			this.fAddEff = 2;
			break;
		case 16:
		case 51:
			this.typePlash = 14;
			this.fAddEff = 6;
			break;
		case 17:
			this.typePlash = 133;
			this.fAddEff = 1000;
			this.isNextf = 2;
			break;
		case 18:
			this.typePlash = 118;
			this.fAddEff = 4;
			break;
		case 19:
			this.typePlash = 103;
			this.fAddEff = 0;
			break;
		case 20:
			this.typePlash = 136;
			this.fAddEff = 0;
			break;
		case 21:
		case 33:
			this.typePlash = 19;
			this.fAddEff = 4;
			break;
		case 23:
			this.typePlash = 137;
			this.fAddEff = 5;
			break;
		case 24:
		case 80:
			this.typePlash = 43;
			this.fAddEff = 4;
			break;
		case 25:
		case 235:
			this.typePlash = 138;
			this.fAddEff = 5;
			break;
		case 26:
		case 236:
			this.typePlash = 139;
			this.fAddEff = 0;
			break;
		case 27:
			this.typePlash = 140;
			this.fAddEff = 8;
			break;
		case 28:
			this.typePlash = 141;
			this.fAddEff = 8;
			break;
		case 29:
			this.typePlash = 27;
			this.fAddEff = 10;
			break;
		case 30:
			this.typePlash = 36;
			this.fAddEff = 4;
			break;
		case 31:
		case 55:
			this.typePlash = 28;
			this.fAddEff = 4;
			break;
		case 32:
			this.typePlash = 142;
			this.fAddEff = 4;
			break;
		case 34:
			this.typePlash = 20;
			this.fAddEff = 6;
			break;
		case 35:
			this.typePlash = 29;
			this.fAddEff = 6;
			break;
		case 36:
			this.typePlash = 143;
			this.fAddEff = 3;
			break;
		case 38:
			this.typePlash = 30;
			this.fAddEff = 3;
			break;
		case 39:
			this.typePlash = 144;
			this.fAddEff = 0;
			break;
		case 40:
			this.typePlash = 145;
			this.fAddEff = 0;
			break;
		case 41:
			this.typePlash = 121;
			this.fAddEff = 4;
			break;
		case 42:
			this.typePlash = 101;
			this.fAddEff = 0;
			break;
		case 43:
			this.typePlash = 102;
			this.fAddEff = 0;
			break;
		case 45:
			this.typePlash = 146;
			this.fAddEff = 0;
			break;
		case 46:
			this.typePlash = 31;
			this.fAddEff = 0;
			break;
		case 47:
		case 48:
			this.typePlash = 2;
			this.fAddEff = 6;
			break;
		case 49:
		case 50:
		case 266:
		case 276:
		case 277:
		case 278:
		case 279:
			this.typePlash = 9;
			this.fAddEff = 6;
			break;
		case 52:
		case 189:
		case 221:
		case 311:
			this.typePlash = 125;
			this.fAddEff = 0;
			break;
		case 54:
			this.typePlash = 147;
			this.fAddEff = 5;
			break;
		case 56:
		case 191:
		case 223:
		case 313:
			this.typePlash = 135;
			this.fAddEff = 4;
			break;
		case 57:
		case 58:
			this.typePlash = 33;
			this.fAddEff = 6;
			break;
		case 59:
		case 60:
			this.typePlash = 148;
			this.fAddEff = 4;
			break;
		case 63:
		case 190:
		case 222:
		case 312:
			this.typePlash = 130;
			this.fAddEff = 0;
			break;
		case 64:
		case 66:
			this.typePlash = 5;
			this.fAddEff = 6;
			break;
		case 65:
		case 70:
		case 107:
			this.typePlash = 67;
			this.fAddEff = 6;
			break;
		case 67:
		case 68:
		case 69:
		case 194:
		case 226:
		case 303:
			this.typePlash = 34;
			this.fAddEff = 10;
			break;
		case 71:
			this.typePlash = 37;
			this.fAddEff = 4;
			break;
		case 72:
			this.typePlash = 38;
			this.fAddEff = 6;
			break;
		case 73:
			this.typePlash = 120;
			this.fAddEff = 6;
			break;
		case 74:
			this.typePlash = 119;
			this.fAddEff = 6;
			break;
		case 75:
		case 76:
			this.typePlash = 39;
			this.fAddEff = 6;
			break;
		case 77:
			this.typePlash = 40;
			this.fAddEff = 2;
			break;
		case 78:
			this.typePlash = 42;
			this.fAddEff = 4;
			break;
		case 79:
			this.typePlash = 41;
			this.fAddEff = 4;
			break;
		case 83:
			this.typePlash = 122;
			this.fAddEff = 0;
			break;
		case 84:
		case 181:
		case 213:
		case 272:
			this.typePlash = 127;
			this.fAddEff = 0;
			break;
		case 85:
		case 182:
			this.typePlash = 46;
			this.fAddEff = 0;
			break;
		case 86:
		case 183:
		case 215:
		case 281:
			this.typePlash = 123;
			this.fAddEff = 0;
			break;
		case 87:
		case 184:
		case 216:
			this.typePlash = 48;
			this.fAddEff = 0;
			break;
		case 88:
			this.typePlash = 49;
			this.fAddEff = 0;
			break;
		case 89:
			this.typePlash = 50;
			this.fAddEff = 0;
			break;
		case 90:
			this.typePlash = 51;
			this.fAddEff = 4;
			break;
		case 91:
			this.typePlash = 52;
			this.fAddEff = 4;
			break;
		case 92:
			this.typePlash = 53;
			this.fAddEff = 6;
			break;
		case 93:
			this.typePlash = 54;
			this.fAddEff = 0;
			break;
		case 94:
			this.typePlash = 55;
			this.fAddEff = 6;
			break;
		case 95:
			this.typePlash = 56;
			this.fAddEff = 6;
			break;
		case 96:
			this.typePlash = 57;
			this.fAddEff = 0;
			break;
		case 97:
			this.typePlash = 58;
			this.fAddEff = 5;
			break;
		case 98:
		case 102:
			this.typePlash = 59;
			this.fAddEff = 6;
			break;
		case 99:
			this.typePlash = 60;
			this.fAddEff = 6;
			break;
		case 100:
			this.typePlash = 61;
			this.fAddEff = 6;
			break;
		case 101:
			this.typePlash = 62;
			this.fAddEff = 6;
			break;
		case 103:
			this.typePlash = 63;
			this.fAddEff = 6;
			break;
		case 104:
			this.typePlash = 64;
			this.fAddEff = 6;
			break;
		case 105:
			this.typePlash = 65;
			this.fAddEff = 6;
			break;
		case 106:
			this.typePlash = 66;
			this.fAddEff = 0;
			break;
		case 108:
			this.typePlash = 68;
			this.fAddEff = 0;
			break;
		case 109:
		case 110:
			this.typePlash = 69;
			this.fAddEff = 4;
			break;
		case 111:
			this.typePlash = 70;
			this.fAddEff = 0;
			break;
		case 113:
			this.typePlash = 71;
			this.fAddEff = 0;
			break;
		case 114:
			this.typePlash = 72;
			this.fAddEff = 0;
			break;
		case 115:
			this.typePlash = 73;
			this.fAddEff = 0;
			break;
		case 116:
			this.typePlash = 74;
			this.fAddEff = 6;
			break;
		case 117:
			this.typePlash = 75;
			this.fAddEff = 4;
			break;
		case 118:
			this.typePlash = 76;
			this.fAddEff = 6;
			break;
		case 119:
			this.typePlash = 77;
			this.fAddEff = 4;
			break;
		case 120:
			this.typePlash = 78;
			this.fAddEff = 0;
			break;
		case 121:
			this.typePlash = 79;
			this.fAddEff = 4;
			break;
		case 122:
			this.typePlash = 80;
			this.fAddEff = 4;
			break;
		case 123:
		case 185:
		case 217:
		case 283:
			this.typePlash = 81;
			this.fAddEff = 0;
			break;
		case 124:
		case 186:
		case 218:
		case 291:
			this.typePlash = 124;
			this.fAddEff = 0;
			break;
		case 125:
		case 187:
			this.typePlash = 129;
			this.fAddEff = 0;
			break;
		case 126:
		case 192:
			this.typePlash = 126;
			this.fAddEff = 0;
			break;
		case 127:
		case 193:
		case 225:
		case 302:
			this.typePlash = 91;
			this.fAddEff = 6;
			break;
		case 128:
			this.typePlash = 93;
			this.fAddEff = 7;
			break;
		case 129:
			this.typePlash = 94;
			this.fAddEff = 7;
			break;
		case 130:
			this.typePlash = 95;
			this.fAddEff = 7;
			break;
		case 131:
			this.typePlash = 96;
			this.fAddEff = 6;
			break;
		case 132:
			this.typePlash = 97;
			this.fAddEff = 6;
			break;
		case 133:
			this.typePlash = 98;
			this.fAddEff = 0;
			break;
		case 134:
		case 135:
			this.typePlash = 99;
			this.fAddEff = 0;
			break;
		case 136:
			this.typePlash = 104;
			this.fAddEff = 0;
			break;
		case 137:
		case 138:
			this.typePlash = 105;
			this.fAddEff = 0;
			break;
		case 139:
			this.typePlash = 107;
			this.fAddEff = 0;
			break;
		case 140:
			this.typePlash = 108;
			this.fAddEff = 0;
			break;
		case 141:
			this.typePlash = 109;
			this.fAddEff = 0;
			break;
		case 142:
			this.typePlash = 110;
			this.fAddEff = 0;
			break;
		case 143:
			this.typePlash = 150;
			this.fAddEff = 0;
			break;
		case 155:
			this.typePlash = 3;
			this.fAddEff = 3;
			break;
		case 156:
			this.typePlash = 44;
			this.fAddEff = 4;
			break;
		case 157:
			this.typePlash = 47;
			this.fAddEff = 0;
			break;
		case 158:
			this.typePlash = 88;
			this.fAddEff = 0;
			break;
		case 159:
			this.typePlash = 90;
			this.fAddEff = 6;
			break;
		case 160:
			this.typePlash = 45;
			this.fAddEff = 4;
			break;
		case 161:
			this.typePlash = 128;
			this.fAddEff = 0;
			break;
		case 162:
			this.typePlash = 89;
			this.fAddEff = 0;
			break;
		case 164:
		case 227:
			this.typePlash = 35;
			this.fAddEff = 5;
			break;
		case 165:
			this.typePlash = 131;
			this.fAddEff = 0;
			break;
		case 166:
			this.typePlash = 132;
			this.fAddEff = 0;
			break;
		case 167:
			this.typePlash = 149;
			this.fAddEff = 6;
			break;
		case 168:
		case 258:
			this.typePlash = 154;
			this.fAddEff = 2;
			break;
		case 169:
		case 237:
			this.typePlash = 151;
			this.fAddEff = 2;
			break;
		case 170:
		case 238:
			this.typePlash = 152;
			this.fAddEff = 4;
			break;
		case 171:
		case 172:
		case 239:
		case 240:
			this.typePlash = 153;
			this.fAddEff = 6;
			break;
		case 173:
			this.typePlash = 155;
			this.fAddEff = 6;
			break;
		case 174:
			this.typePlash = 156;
			this.fAddEff = 2;
			break;
		case 175:
			this.typePlash = 157;
			this.fAddEff = 6;
			break;
		case 176:
			this.typePlash = 159;
			this.fAddEff = 4;
			break;
		case 177:
			this.typePlash = 158;
			this.fAddEff = 0;
			break;
		case 178:
			this.typePlash = 160;
			this.fAddEff = 4;
			break;
		case 179:
		case 241:
			this.typePlash = 161;
			this.fAddEff = 1;
			break;
		case 180:
		case 212:
			this.typePlash = 162;
			this.fAddEff = 0;
			break;
		case 195:
			this.typePlash = 163;
			this.fAddEff = 4;
			break;
		case 196:
			this.typePlash = 164;
			this.fAddEff = 0;
			break;
		case 197:
		case 267:
		case 274:
		case 275:
			this.typePlash = 165;
			this.fAddEff = 8;
			break;
		case 198:
			this.typePlash = 166;
			this.fAddEff = 4;
			break;
		case 199:
			this.typePlash = 167;
			this.fAddEff = 4;
			break;
		case 200:
			this.typePlash = 168;
			this.fAddEff = 4;
			break;
		case 201:
			this.typePlash = 169;
			this.fAddEff = 4;
			break;
		case 202:
			this.typePlash = 170;
			this.fAddEff = 4;
			break;
		case 203:
			this.typePlash = 171;
			this.fAddEff = 4;
			break;
		case 204:
			this.typePlash = 172;
			this.fAddEff = 4;
			break;
		case 205:
			this.typePlash = 173;
			this.fAddEff = 3;
			break;
		case 206:
		case 207:
			this.fAddEff = 6;
			this.typePlash = 174;
			break;
		case 208:
			this.typePlash = 175;
			this.fAddEff = 0;
			break;
		case 209:
		case 242:
			this.typePlash = 176;
			this.fAddEff = 6;
			break;
		case 210:
		case 243:
			this.typePlash = 177;
			this.fAddEff = 4;
			break;
		case 211:
		case 244:
			this.typePlash = 177;
			this.fAddEff = 4;
			break;
		case 214:
		case 273:
			this.typePlash = 179;
			this.fAddEff = 0;
			break;
		case 219:
		case 292:
			this.typePlash = 180;
			this.fAddEff = 0;
			break;
		case 224:
		case 301:
			this.typePlash = 181;
			this.fAddEff = 0;
			break;
		case 228:
		case 259:
		case 260:
		case 261:
			this.typePlash = 182;
			this.fAddEff = 0;
			break;
		case 245:
		case 249:
		case 251:
		case 252:
			this.typePlash = 185;
			this.fAddEff = 0;
			break;
		case 247:
		case 254:
			this.typePlash = 183;
			this.fAddEff = 4;
			break;
		case 248:
		case 255:
			this.typePlash = 184;
			this.fAddEff = 4;
			break;
		case 256:
			this.typePlash = 186;
			this.fAddEff = 0;
			break;
		case 257:
			this.typePlash = 187;
			this.fAddEff = 0;
			break;
		case 265:
			this.typePlash = 188;
			this.fAddEff = 0;
			break;
		case 271:
			this.typePlash = 189;
			this.fAddEff = 0;
			break;
		case 280:
			this.typePlash = 191;
			break;
		case 282:
			this.typePlash = 190;
			this.fAddEff = 0;
			break;
		case 400:
		case 401:
		case 402:
		case 403:
			this.typePlash = 151;
			this.fAddEff = 0;
			break;
		default:
			switch (type)
			{
			case 10001:
			case 10005:
			case 10008:
			case 10010:
			case 10013:
			case 10017:
			case 10018:
			case 10020:
			case 10021:
			case 10022:
			case 10024:
			case 10026:
			case 10027:
				this.typePlash = 82;
				this.fAddEff = 0;
				break;
			case 10002:
				this.typePlash = 83;
				this.fAddEff = 0;
				break;
			case 10003:
				this.typePlash = 84;
				this.fAddEff = 0;
				break;
			case 10004:
			case 10007:
			case 10009:
				this.typePlash = 85;
				this.fAddEff = 0;
				break;
			case 10006:
			case 10011:
			case 10012:
			case 10015:
			case 10023:
				this.typePlash = 86;
				this.fAddEff = 0;
				break;
			case 10019:
				this.typePlash = 87;
				this.fAddEff = 0;
				break;
			case 10025:
				this.typePlash = 92;
				this.fAddEff = 0;
				break;
			}
			break;
		}
		return this.typePlash;
	}

	// Token: 0x06000B99 RID: 2969 RVA: 0x000DFC18 File Offset: 0x000DDE18
	public int update()
	{
		try
		{
			bool flag = GameCanvas.gameTick % 25 == 0 && (GameCanvas.timeNow - this.timebeginSkill) / 1000L > 30L;
			if (flag)
			{
				return -1;
			}
			bool flag2 = this.isNextf == 0;
			if (flag2)
			{
				this.f++;
			}
			else
			{
				bool flag3 = this.isNextf == 1;
				if (flag3)
				{
					return (int)this.plashdata.mDataPlash[this.f];
				}
				bool flag4 = this.isNextf == 2;
				if (flag4)
				{
					this.f++;
					bool flag5 = this.f >= this.plashdata.mDataPlash.Length;
					if (flag5)
					{
						this.f = 0;
					}
					bool flag6 = (GameCanvas.timeNow - this.timebeginSkill) / 1000L > (long)this.timeEndPlash;
					if (flag6)
					{
						return -1;
					}
				}
			}
			bool flag7 = this.f >= this.removef;
			if (!flag7)
			{
				bool flag8 = this.isShow;
				if (flag8)
				{
					bool flag9 = this.f == this.fAddEff;
					if (flag9)
					{
						LoginScreen.addEffectEnd(this.skill.typeEffSkill, 0, this.objFire.x, this.objFire.y, (sbyte)this.objFire.Dir, this.objFire);
						this.fAddEff = 10000;
					}
				}
				else
				{
					bool flag10 = this.f == this.fAddEff;
					if (flag10)
					{
						bool flag11 = this.skill.typeBuff == 2;
						if (flag11)
						{
							GameScreen.addEffectSkillSpec(this.skill, this.objFire);
						}
						else
						{
							bool flag12 = this.skill.typeBuff == 1;
							if (flag12)
							{
								GameScreen.addEffectSkill(this.skill, this.objFire, this.vecObj);
							}
							else
							{
								GameScreen.addEffectSkill(this.skill, this.objFire, this.vecObj);
							}
						}
						this.fAddEff = 10000;
					}
				}
				return (int)this.plashdata.mDataPlash[this.f];
			}
			bool flag13 = this.skill.typeBuff == 2 && GameCanvas.timeNow - this.timebeginSkill < (long)this.timeEndPlash;
			if (flag13)
			{
				return (int)this.plashdata.mDataPlash[this.removef - 1];
			}
			return -1;
		}
		catch (Exception)
		{
		}
		return 0;
	}

	// Token: 0x06000B9A RID: 2970 RVA: 0x0000B90B File Offset: 0x00009B0B
	public void setIsNextf(sbyte isnext)
	{
		this.isNextf = isnext;
	}

	// Token: 0x06000B9B RID: 2971 RVA: 0x0000B915 File Offset: 0x00009B15
	public void setf(int f)
	{
		this.f = f;
	}

	// Token: 0x06000B9C RID: 2972 RVA: 0x000DFEBC File Offset: 0x000DE0BC
	public static void readDataPlash(DataInputStream iss)
	{
		try
		{
			short num = iss.readShort();
			sbyte b = iss.readByte();
			Plashdata plashdata = new Plashdata();
			plashdata.mDataPlash = new short[(int)b];
			for (int i = 0; i < (int)b; i++)
			{
				plashdata.mDataPlash[i] = (short)iss.readByte();
			}
			Plash.hashPlash.put(string.Empty + num.ToString(), plashdata);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x0400116A RID: 4458
	public const short LU_SUNGLIENTHANH = 0;

	// Token: 0x0400116B RID: 4459
	public const short LU_SUNGLUC = 1;

	// Token: 0x0400116C RID: 4460
	public const short SAN_DATHUONG = 2;

	// Token: 0x0400116D RID: 4461
	public const short ZORO_BIENHINH = 3;

	// Token: 0x0400116E RID: 4462
	public const short USS_BAN2VIEN = 4;

	// Token: 0x0400116F RID: 4463
	public const short USS_BANTUONGOT = 5;

	// Token: 0x04001170 RID: 4464
	public const short NAMI_BUNGMERANG = 6;

	// Token: 0x04001171 RID: 4465
	public const short NAMI_SET = 7;

	// Token: 0x04001172 RID: 4466
	public const short NAMI_LOCXOAY = 8;

	// Token: 0x04001173 RID: 4467
	public const short SAN_DACHIEULUA = 9;

	// Token: 0x04001174 RID: 4468
	public const short SAN_DAGIO = 10;

	// Token: 0x04001175 RID: 4469
	public const short LU_TRAI_PHAI_CHAN = 11;

	// Token: 0x04001176 RID: 4470
	public const short SAN_CHAN_CHAY = 12;

	// Token: 0x04001177 RID: 4471
	public const short ZORO_CHEM_CHAY_L2 = 13;

	// Token: 0x04001178 RID: 4472
	public const short NAMI_DANH_CHAY = 14;

	// Token: 0x04001179 RID: 4473
	public const short USS_BAN_CHAY = 15;

	// Token: 0x0400117A RID: 4474
	public const short LU_DA_CHE = 16;

	// Token: 0x0400117B RID: 4475
	public const short ZORO_CHEM_GIO = 17;

	// Token: 0x0400117C RID: 4476
	public const short USS_BUA_TA = 18;

	// Token: 0x0400117D RID: 4477
	public const short LU_DAM_2_CAI = 19;

	// Token: 0x0400117E RID: 4478
	public const short LU_DAM_2_TAY = 20;

	// Token: 0x0400117F RID: 4479
	public const short LU_DAM_2_CAI_DAM_2_TAY = 21;

	// Token: 0x04001180 RID: 4480
	public const short LU_BAY_DAM_2_CAI = 22;

	// Token: 0x04001181 RID: 4481
	public const short LU_BAY_DAM_2_CAI_DAM_2_TAY = 23;

	// Token: 0x04001182 RID: 4482
	public const short ZORO_CHEM_2_CAI = 24;

	// Token: 0x04001183 RID: 4483
	public const short ZORO_BAY_CHEM_2_CAI = 25;

	// Token: 0x04001184 RID: 4484
	public const short ZORO_CHEM_ALPHA = 26;

	// Token: 0x04001185 RID: 4485
	public const short ZORO_CHEM_LUOT_QUA = 27;

	// Token: 0x04001186 RID: 4486
	public const short NAMI_BONGBONG_SET = 28;

	// Token: 0x04001187 RID: 4487
	public const short LU_DAM_2_TAY_LV2 = 29;

	// Token: 0x04001188 RID: 4488
	public const short ZORO_CHEM_CHAY_L1 = 30;

	// Token: 0x04001189 RID: 4489
	public const short BUFF_0 = 31;

	// Token: 0x0400118A RID: 4490
	public const short NAMI_BUNGMERANG_2 = 32;

	// Token: 0x0400118B RID: 4491
	public const short USS_BANTUONGOT_2 = 33;

	// Token: 0x0400118C RID: 4492
	public const short USS_BANPHAOHOA = 34;

	// Token: 0x0400118D RID: 4493
	public const short SPE_CAUSU_1 = 35;

	// Token: 0x0400118E RID: 4494
	public const short MON_DAM_1_CAI = 36;

	// Token: 0x0400118F RID: 4495
	public const short MON_PHONG_1_DAO = 37;

	// Token: 0x04001190 RID: 4496
	public const short MON_BAN_1_CAI = 38;

	// Token: 0x04001191 RID: 4497
	public const short MON_DANH_SUNG_1_CAI = 39;

	// Token: 0x04001192 RID: 4498
	public const short ALVIDA_DANH_DA_MUC_TIEU = 40;

	// Token: 0x04001193 RID: 4499
	public const short MON_TAY_1_TRAI_DA = 41;

	// Token: 0x04001194 RID: 4500
	public const short MON_TAY_1_PHAI_TRAI = 42;

	// Token: 0x04001195 RID: 4501
	public const short MON_CHAN_2_CAI_TAY_TRAI = 43;

	// Token: 0x04001196 RID: 4502
	public const short LU_SKILL_1_FINAL = 44;

	// Token: 0x04001197 RID: 4503
	public const short LU_SKILL_2_FINAL = 45;

	// Token: 0x04001198 RID: 4504
	public const short LU_SKILL_3_FINAL = 46;

	// Token: 0x04001199 RID: 4505
	public const short ZORO_SKILL_1_FINAL = 47;

	// Token: 0x0400119A RID: 4506
	public const short ZORO_SKILL_2_FINAL = 48;

	// Token: 0x0400119B RID: 4507
	public const short MORGAN_CHEM_CAI = 49;

	// Token: 0x0400119C RID: 4508
	public const short MORGAN_CHEM_NGANG = 50;

	// Token: 0x0400119D RID: 4509
	public const short HELMEPO_1 = 51;

	// Token: 0x0400119E RID: 4510
	public const short HELMEPO_2 = 52;

	// Token: 0x0400119F RID: 4511
	public const short MON_BAN_SUNG_TRUONG = 53;

	// Token: 0x040011A0 RID: 4512
	public const short MOHJI_1 = 54;

	// Token: 0x040011A1 RID: 4513
	public const short MOHJI_2 = 55;

	// Token: 0x040011A2 RID: 4514
	public const short BUGGY_1 = 56;

	// Token: 0x040011A3 RID: 4515
	public const short BUGGY_2 = 57;

	// Token: 0x040011A4 RID: 4516
	public const short CABAJI_1 = 58;

	// Token: 0x040011A5 RID: 4517
	public const short CABAJI_2 = 59;

	// Token: 0x040011A6 RID: 4518
	public const short NYABAN_1 = 60;

	// Token: 0x040011A7 RID: 4519
	public const short NYABAN_2 = 61;

	// Token: 0x040011A8 RID: 4520
	public const short NYABAN_3 = 62;

	// Token: 0x040011A9 RID: 4521
	public const short KURO_1 = 63;

	// Token: 0x040011AA RID: 4522
	public const short KURO_2 = 64;

	// Token: 0x040011AB RID: 4523
	public const short PEARL_1 = 65;

	// Token: 0x040011AC RID: 4524
	public const short PEARL_2 = 66;

	// Token: 0x040011AD RID: 4525
	public const short GHIN_1 = 67;

	// Token: 0x040011AE RID: 4526
	public const short GHIN_2 = 68;

	// Token: 0x040011AF RID: 4527
	public const short DON_KRIEG_1 = 69;

	// Token: 0x040011B0 RID: 4528
	public const short DON_KRIEG_3 = 70;

	// Token: 0x040011B1 RID: 4529
	public const short HACHI_2 = 71;

	// Token: 0x040011B2 RID: 4530
	public const short CHU_1 = 72;

	// Token: 0x040011B3 RID: 4531
	public const short CHU_2 = 73;

	// Token: 0x040011B4 RID: 4532
	public const short KUROBI_1 = 74;

	// Token: 0x040011B5 RID: 4533
	public const short KUROBI_2 = 75;

	// Token: 0x040011B6 RID: 4534
	public const short ARLONG_1 = 76;

	// Token: 0x040011B7 RID: 4535
	public const short ARLONG_2 = 77;

	// Token: 0x040011B8 RID: 4536
	public const short ARLONG_3 = 78;

	// Token: 0x040011B9 RID: 4537
	public const short ZORO_XOAY_KIEM = 79;

	// Token: 0x040011BA RID: 4538
	public const short ZORO_XOAY_KIEM_2 = 80;

	// Token: 0x040011BB RID: 4539
	public const short ZORO_XOAY_KIEM_3 = 81;

	// Token: 0x040011BC RID: 4540
	public const short PAN_1 = 82;

	// Token: 0x040011BD RID: 4541
	public const short PAN_2 = 83;

	// Token: 0x040011BE RID: 4542
	public const short GALIO_1 = 84;

	// Token: 0x040011BF RID: 4543
	public const short GALIO_2 = 85;

	// Token: 0x040011C0 RID: 4544
	public const short NO_NANG_LUONG = 86;

	// Token: 0x040011C1 RID: 4545
	public const short MON_CHAY_THANG = 87;

	// Token: 0x040011C2 RID: 4546
	public const short SAN_SKILL_1_FINAL = 88;

	// Token: 0x040011C3 RID: 4547
	public const short SAN_SKILL_2_FINAL = 89;

	// Token: 0x040011C4 RID: 4548
	public const short USS_SKILL_1_FINAL = 90;

	// Token: 0x040011C5 RID: 4549
	public const short USS_SKILL_2_FINAL = 91;

	// Token: 0x040011C6 RID: 4550
	public const short MON_NEM_BOOM = 92;

	// Token: 0x040011C7 RID: 4551
	public const short MON_DANH_TAY_TRAI_PHAI_MANH = 93;

	// Token: 0x040011C8 RID: 4552
	public const short MON_DANH_TAY_PHAI_DA_MANH = 94;

	// Token: 0x040011C9 RID: 4553
	public const short MON_DA_TAY_MANH = 95;

	// Token: 0x040011CA RID: 4554
	public const short MON_CHEM_2_CAI = 96;

	// Token: 0x040011CB RID: 4555
	public const short MON_CHEM_3_CAI = 97;

	// Token: 0x040011CC RID: 4556
	public const short LU_SEA_LV1 = 98;

	// Token: 0x040011CD RID: 4557
	public const short LU_SEA_LV2 = 99;

	// Token: 0x040011CE RID: 4558
	public const short LU_SEA_LV3 = 100;

	// Token: 0x040011CF RID: 4559
	public const short ZORO_SEA_LV1 = 101;

	// Token: 0x040011D0 RID: 4560
	public const short ZORO_SEA_LV2 = 102;

	// Token: 0x040011D1 RID: 4561
	public const short ZORO_SEA_LV3 = 103;

	// Token: 0x040011D2 RID: 4562
	public const short SAN_SEA_LV1 = 104;

	// Token: 0x040011D3 RID: 4563
	public const short SAN_SEA_LV2 = 105;

	// Token: 0x040011D4 RID: 4564
	public const short SAN_SEA_LV3 = 106;

	// Token: 0x040011D5 RID: 4565
	public const short NAMI_SEA_LV2 = 107;

	// Token: 0x040011D6 RID: 4566
	public const short NAMI_SEA_LV3 = 108;

	// Token: 0x040011D7 RID: 4567
	public const short USS_SEA_LV2 = 109;

	// Token: 0x040011D8 RID: 4568
	public const short USS_SEA_LV3 = 110;

	// Token: 0x040011D9 RID: 4569
	public const short ACE_1 = 111;

	// Token: 0x040011DA RID: 4570
	public const short ACE_2 = 112;

	// Token: 0x040011DB RID: 4571
	public const short AOKIJI_1 = 113;

	// Token: 0x040011DC RID: 4572
	public const short AOKIJI_2 = 114;

	// Token: 0x040011DD RID: 4573
	public const short SMOKER_1 = 115;

	// Token: 0x040011DE RID: 4574
	public const short SMOKER_2 = 116;

	// Token: 0x040011DF RID: 4575
	public const short MON_SMOKER_1 = 117;

	// Token: 0x040011E0 RID: 4576
	public const short MON_SMOKER_2 = 118;

	// Token: 0x040011E1 RID: 4577
	public const short MON_CHEM_2_CAI_NEW = 119;

	// Token: 0x040011E2 RID: 4578
	public const short MON_DANH_SUNG_DA = 120;

	// Token: 0x040011E3 RID: 4579
	public const short ZORO_CHEM_2_CAI_XA = 121;

	// Token: 0x040011E4 RID: 4580
	public const short LU_S1_L3_SHORT = 122;

	// Token: 0x040011E5 RID: 4581
	public const short ZORO_S1_L3_SHORT = 123;

	// Token: 0x040011E6 RID: 4582
	public const short SAN_S1_L3_SHORT = 124;

	// Token: 0x040011E7 RID: 4583
	public const short NAMI_S1_L3_SHORT = 125;

	// Token: 0x040011E8 RID: 4584
	public const short USS_S1_L3_SHORT = 126;

	// Token: 0x040011E9 RID: 4585
	public const short LU_SKILL_2_FINAL_SHORT = 127;

	// Token: 0x040011EA RID: 4586
	public const short ZORO_SKILL_2_FINAL_SHORT = 128;

	// Token: 0x040011EB RID: 4587
	public const short SAN_SKILL_2_FINAL_SHORT = 129;

	// Token: 0x040011EC RID: 4588
	public const short NAMI_BUNGMERANG_SHORT = 130;

	// Token: 0x040011ED RID: 4589
	public const short BUFF_2 = 131;

	// Token: 0x040011EE RID: 4590
	public const short BUFF_2_END = 132;

	// Token: 0x040011EF RID: 4591
	public const short EFF_GET_MONEY = 133;

	// Token: 0x040011F0 RID: 4592
	public const short SAN_DACHIEULUA_LV3 = 134;

	// Token: 0x040011F1 RID: 4593
	public const short NAMI_BONGBONG_SET_LV3 = 135;

	// Token: 0x040011F2 RID: 4594
	public const short MON_VALENTINE = 136;

	// Token: 0x040011F3 RID: 4595
	public const short MON_MR5_1 = 137;

	// Token: 0x040011F4 RID: 4596
	public const short CROCODILE_1 = 138;

	// Token: 0x040011F5 RID: 4597
	public const short CROCODILE_2 = 139;

	// Token: 0x040011F6 RID: 4598
	public const short CHESS = 140;

	// Token: 0x040011F7 RID: 4599
	public const short KUROMARIMO = 141;

	// Token: 0x040011F8 RID: 4600
	public const short WAPOL_1 = 142;

	// Token: 0x040011F9 RID: 4601
	public const short WAPOL_2 = 143;

	// Token: 0x040011FA RID: 4602
	public const short WAPOL_3 = 144;

	// Token: 0x040011FB RID: 4603
	public const short WAPOL_4 = 145;

	// Token: 0x040011FC RID: 4604
	public const short MR3_1 = 146;

	// Token: 0x040011FD RID: 4605
	public const short MR3_2 = 147;

	// Token: 0x040011FE RID: 4606
	public const short MISS_GOLDEN_WEEKEND = 148;

	// Token: 0x040011FF RID: 4607
	public const short MISS_MS_1 = 149;

	// Token: 0x04001200 RID: 4608
	public const short MON_FIRE = 150;

	// Token: 0x04001201 RID: 4609
	public const short SET_1 = 151;

	// Token: 0x04001202 RID: 4610
	public const short SET_2 = 152;

	// Token: 0x04001203 RID: 4611
	public const short NHAM_THACH_1 = 153;

	// Token: 0x04001204 RID: 4612
	public const short MR1_1 = 154;

	// Token: 0x04001205 RID: 4613
	public const short MR1_2 = 155;

	// Token: 0x04001206 RID: 4614
	public const short DF_1 = 156;

	// Token: 0x04001207 RID: 4615
	public const short DF_2 = 157;

	// Token: 0x04001208 RID: 4616
	public const short MR2_2 = 158;

	// Token: 0x04001209 RID: 4617
	public const short MR2_1 = 159;

	// Token: 0x0400120A RID: 4618
	public const short MR0_1 = 160;

	// Token: 0x0400120B RID: 4619
	public const short PELL_1 = 161;

	// Token: 0x0400120C RID: 4620
	public const short LU_S1_LV4 = 162;

	// Token: 0x0400120D RID: 4621
	public const short ENEL_1 = 163;

	// Token: 0x0400120E RID: 4622
	public const short ENEL_2 = 164;

	// Token: 0x0400120F RID: 4623
	public const short ENEL_3 = 165;

	// Token: 0x04001210 RID: 4624
	public const short SATORI_1 = 166;

	// Token: 0x04001211 RID: 4625
	public const short SATORI_2 = 167;

	// Token: 0x04001212 RID: 4626
	public const short OHM_1 = 168;

	// Token: 0x04001213 RID: 4627
	public const short OHM_2 = 169;

	// Token: 0x04001214 RID: 4628
	public const short GEDATSU_1 = 170;

	// Token: 0x04001215 RID: 4629
	public const short GEDATSU_2 = 171;

	// Token: 0x04001216 RID: 4630
	public const short SHURA_1 = 172;

	// Token: 0x04001217 RID: 4631
	public const short SHURA_2 = 173;

	// Token: 0x04001218 RID: 4632
	public const short LINHTROI_1 = 174;

	// Token: 0x04001219 RID: 4633
	public const short TRU_1 = 175;

	// Token: 0x0400121A RID: 4634
	public const short LUCCI_1 = 176;

	// Token: 0x0400121B RID: 4635
	public const short DONG_DAT_1 = 177;

	// Token: 0x0400121C RID: 4636
	public const short DONG_DAT_2 = 178;

	// Token: 0x0400121D RID: 4637
	public const short LU_S3_L5 = 179;

	// Token: 0x0400121E RID: 4638
	public const short SAN_S2_L5 = 180;

	// Token: 0x0400121F RID: 4639
	public const short USS_S1_L5 = 181;

	// Token: 0x04001220 RID: 4640
	public const short ACE_1_L2 = 182;

	// Token: 0x04001221 RID: 4641
	public const short DEVIL_MR3_L2 = 183;

	// Token: 0x04001222 RID: 4642
	public const short DEVIL_KILO_L1 = 184;

	// Token: 0x04001223 RID: 4643
	public const short DEVIL_DAO_L1 = 185;

	// Token: 0x04001224 RID: 4644
	public const short THA_DEN = 186;

	// Token: 0x04001225 RID: 4645
	public const short THA_PHAO_HOA = 187;

	// Token: 0x04001226 RID: 4646
	public const short LAW_HEART = 188;

	// Token: 0x04001227 RID: 4647
	public const short LUFFY_S1_L6 = 189;

	// Token: 0x04001228 RID: 4648
	public const short ZORO_S2_L6 = 190;

	// Token: 0x04001229 RID: 4649
	public const short GOAL = 191;

	// Token: 0x0400122A RID: 4650
	public const sbyte NEXT_NORMAL = 0;

	// Token: 0x0400122B RID: 4651
	public const sbyte NEXT_STOP = 1;

	// Token: 0x0400122C RID: 4652
	public const sbyte NEXT_AGAIN = 2;

	// Token: 0x0400122D RID: 4653
	public static MyHashTable hashPlash = new MyHashTable();

	// Token: 0x0400122E RID: 4654
	private MainSkill skill;

	// Token: 0x0400122F RID: 4655
	private Plashdata plashdata;

	// Token: 0x04001230 RID: 4656
	public short typePlash;

	// Token: 0x04001231 RID: 4657
	public short timeEndPlash;

	// Token: 0x04001232 RID: 4658
	public int f;

	// Token: 0x04001233 RID: 4659
	public int removef;

	// Token: 0x04001234 RID: 4660
	public int fAddEff;

	// Token: 0x04001235 RID: 4661
	private mVector vecObj;

	// Token: 0x04001236 RID: 4662
	private MainObject objFire;

	// Token: 0x04001237 RID: 4663
	private bool isShow;

	// Token: 0x04001238 RID: 4664
	private sbyte isNextf;

	// Token: 0x04001239 RID: 4665
	private long timebeginSkill;

	// Token: 0x0400123A RID: 4666
	public static short[][] mframePlash = new short[][]
	{
		new short[]
		{
			8,
			8,
			8,
			9,
			9,
			9,
			10,
			10,
			10,
			13,
			13,
			15,
			15,
			13,
			13,
			17,
			17,
			13,
			13,
			15,
			15,
			13,
			13
		},
		new short[]
		{
			37,
			37,
			37,
			37,
			37,
			37,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17
		},
		new short[]
		{
			8,
			8,
			9,
			10,
			27,
			27,
			27,
			27,
			27,
			27,
			27,
			27,
			30,
			30,
			29,
			29,
			27,
			27
		},
		new short[]
		{
			8,
			9,
			10,
			21,
			25,
			25
		},
		new short[]
		{
			8,
			9,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			35,
			37,
			31,
			31,
			33,
			35
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			35,
			35,
			37
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			39,
			39,
			23,
			23,
			25,
			25
		},
		new short[]
		{
			31,
			39,
			31,
			39,
			31,
			39,
			31,
			39,
			31,
			39,
			31,
			39
		},
		new short[]
		{
			31,
			31,
			31,
			39,
			39,
			31,
			31,
			31,
			39,
			39,
			31,
			31,
			31,
			39,
			39
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			27,
			27,
			27,
			27,
			27,
			27,
			30,
			30,
			28,
			28,
			28,
			28,
			29,
			29,
			28,
			28,
			30,
			30
		},
		new short[]
		{
			28,
			29,
			29,
			28,
			28,
			29,
			29,
			28,
			28,
			29,
			29,
			28
		},
		new short[]
		{
			8,
			8,
			17,
			17,
			17,
			14,
			14,
			15,
			15,
			15,
			14,
			14,
			56,
			56,
			56
		},
		new short[]
		{
			8,
			8,
			9,
			10,
			27,
			27,
			29,
			29,
			29,
			27,
			30,
			30,
			30,
			13,
			15,
			15,
			15
		},
		new short[]
		{
			13,
			13,
			13,
			13,
			13,
			13,
			15,
			15,
			15,
			13,
			13,
			15,
			15,
			15,
			13,
			13,
			17,
			17,
			17
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			31,
			31,
			31,
			31,
			31,
			31,
			39,
			39,
			31,
			31,
			31,
			31,
			39,
			39,
			31,
			31,
			31,
			31,
			31
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			31,
			31,
			31,
			31,
			33,
			33,
			33,
			35,
			35,
			37,
			37,
			37,
			31,
			33,
			35,
			37,
			37
		},
		new short[]
		{
			28,
			28,
			28,
			30,
			30,
			30,
			30,
			30,
			30,
			30,
			30,
			55,
			55,
			55,
			56,
			56,
			56,
			27
		},
		new short[]
		{
			10,
			10,
			8,
			8,
			8,
			8,
			9,
			9,
			8,
			8,
			8,
			10,
			10,
			22,
			22,
			22,
			22,
			22,
			22,
			25,
			25
		},
		new short[]
		{
			23,
			23,
			23,
			24,
			22,
			22,
			22,
			22,
			26,
			26,
			25,
			25,
			25,
			25
		},
		new short[]
		{
			8,
			8,
			9,
			10,
			17,
			17,
			17,
			14,
			14,
			15,
			15,
			15
		},
		new short[]
		{
			8,
			8,
			9,
			10,
			45,
			45,
			43,
			44,
			44,
			45,
			46,
			46,
			47,
			26,
			26,
			25,
			25,
			25,
			25
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			17,
			17,
			17,
			14,
			14,
			15,
			15,
			15,
			45,
			45,
			45,
			45,
			43,
			43,
			44,
			45,
			45,
			46,
			47,
			26,
			26,
			25,
			25,
			25,
			25,
			25
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			11,
			11,
			11,
			18,
			18,
			18,
			14,
			14,
			16,
			16,
			16,
			12,
			12
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			11,
			11,
			11,
			18,
			18,
			18,
			14,
			14,
			16,
			16,
			16,
			45,
			45,
			45,
			43,
			43,
			44,
			45,
			46,
			47,
			26,
			26,
			25,
			25,
			25
		},
		new short[]
		{
			13,
			13,
			13,
			19,
			19,
			15,
			15,
			15,
			13,
			13,
			17,
			17,
			17
		},
		new short[]
		{
			14,
			14,
			14,
			20,
			20,
			16,
			16,
			16,
			14,
			14,
			18,
			18,
			18
		},
		new short[]
		{
			25,
			25,
			25,
			25,
			25
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			10,
			23,
			23,
			23,
			23,
			25,
			25,
			25,
			25,
			25
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			31,
			31,
			31,
			31,
			31,
			39,
			39,
			31,
			31,
			31,
			31,
			31,
			31,
			39,
			39,
			31,
			31,
			31,
			31,
			31
		},
		new short[]
		{
			8,
			8,
			9,
			10,
			45,
			45,
			43,
			44,
			45,
			46,
			47,
			26,
			26,
			25,
			25,
			25,
			25
		},
		new short[]
		{
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			15,
			15,
			15,
			13,
			13,
			17,
			17,
			17
		},
		new short[]
		{
			8,
			9,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			39,
			39,
			23,
			23,
			25,
			25,
			8,
			8,
			9,
			9,
			39,
			39,
			23,
			23,
			25,
			25
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			35,
			35,
			37,
			31,
			31,
			33
		},
		new short[]
		{
			8,
			8,
			8,
			9,
			9,
			9,
			9,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			37,
			9,
			9,
			8,
			8
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			13,
			15,
			13,
			17,
			13,
			15,
			13,
			15,
			13,
			17,
			13,
			15,
			13,
			15,
			13,
			17,
			13,
			15,
			13,
			17,
			13,
			15,
			13,
			10,
			10
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			15,
			15,
			15,
			19,
			19,
			19
		},
		new short[]
		{
			8,
			9,
			13,
			13,
			15,
			15,
			15
		},
		new short[]
		{
			8,
			9,
			35,
			35,
			35,
			37,
			37
		},
		new short[]
		{
			8,
			9,
			21,
			21,
			21,
			25,
			25
		},
		new short[]
		{
			8,
			9,
			21,
			21,
			21,
			21,
			21,
			21,
			21,
			21,
			21,
			25,
			25
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			15,
			15,
			15,
			27,
			27,
			28,
			28,
			28,
			27
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			17,
			17,
			17,
			13,
			13,
			16,
			16
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			27,
			28,
			28,
			28,
			27,
			27,
			29,
			29,
			13,
			13,
			15,
			15,
			15,
			15
		},
		new short[]
		{
			8,
			8,
			9,
			10,
			17,
			17,
			17,
			13,
			13,
			15,
			15,
			15,
			13,
			13,
			17,
			17,
			17,
			13,
			13,
			15,
			15,
			15,
			8,
			8,
			8,
			9,
			9,
			9,
			10,
			10,
			10,
			8,
			8,
			8,
			9,
			9,
			9,
			10,
			10,
			13,
			13,
			17,
			18,
			17,
			17
		},
		new short[]
		{
			8,
			9,
			10,
			23,
			23,
			23,
			23,
			23,
			23,
			23,
			23,
			23,
			23,
			25,
			25,
			25,
			25,
			25,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			45,
			43,
			44,
			45,
			46,
			47,
			26,
			26,
			25,
			25,
			25,
			25,
			8
		},
		new short[]
		{
			8,
			8,
			8,
			8,
			9,
			9,
			9,
			9,
			8,
			8,
			8,
			8,
			9,
			9,
			9,
			9,
			10,
			10,
			10,
			10,
			10,
			13,
			13,
			15,
			15,
			13,
			13,
			17,
			17,
			13,
			13,
			15,
			15,
			13,
			13
		},
		new short[]
		{
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			15,
			15,
			15,
			13,
			13,
			17,
			17,
			17,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			15,
			15,
			21,
			21,
			13,
			13,
			14,
			14,
			14,
			14,
			14,
			14,
			16,
			16,
			16,
			14,
			14,
			18,
			18,
			18,
			14,
			14,
			22,
			22,
			26,
			26,
			26,
			14,
			14,
			14,
			14,
			13,
			13
		},
		new short[]
		{
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			14,
			14,
			14,
			16,
			16,
			14,
			14,
			14,
			14,
			14,
			18,
			18,
			18,
			22,
			22,
			22,
			22,
			26,
			26,
			26,
			23,
			23,
			23,
			23,
			23,
			23,
			25,
			25,
			25,
			25
		},
		new short[]
		{
			21,
			21,
			21,
			21,
			21,
			21,
			21,
			21,
			35,
			35,
			35
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			10,
			13,
			13,
			23,
			23,
			31,
			31,
			35
		},
		new short[]
		{
			13,
			13,
			13,
			13,
			15,
			15,
			15
		},
		new short[]
		{
			49,
			49,
			49,
			49,
			17,
			17,
			17
		},
		new short[]
		{
			8,
			9,
			39,
			39,
			39,
			41,
			41
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			10,
			13,
			13,
			13,
			13,
			13,
			13,
			15,
			15,
			15,
			15,
			13,
			13,
			13,
			13,
			17,
			17,
			17,
			17,
			13,
			13,
			13,
			13
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			17,
			17,
			17,
			13,
			13,
			15,
			15,
			15,
			13,
			13
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			35,
			35,
			15,
			15,
			15,
			35
		},
		new short[]
		{
			10,
			10,
			9,
			9,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			35,
			35,
			35,
			35,
			0,
			1,
			0,
			1,
			0,
			1,
			0,
			1,
			0,
			1,
			10,
			10,
			10,
			10,
			9,
			9,
			9,
			8,
			8,
			8,
			8,
			8
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			10,
			25,
			25,
			26,
			26,
			8
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			10,
			49,
			49,
			50,
			50,
			50,
			50,
			50,
			50,
			50,
			50,
			39,
			39,
			40,
			40,
			8
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			10,
			15,
			15,
			15,
			15,
			10,
			10,
			17,
			17,
			17,
			17
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			10,
			22,
			22,
			22,
			22,
			22,
			61,
			61,
			61,
			61,
			61,
			61
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			10,
			11,
			11,
			11,
			11,
			11,
			11,
			15,
			15,
			15,
			15,
			10,
			10,
			17,
			17,
			17,
			17,
			11,
			11,
			11,
			11,
			11,
			11,
			11,
			11,
			11
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			26,
			26,
			26,
			26,
			26,
			26,
			26,
			26,
			26,
			26,
			11,
			11,
			16,
			16,
			16,
			16,
			16,
			11,
			11,
			11
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			16,
			16,
			18,
			18,
			28,
			28,
			16,
			16,
			18,
			18,
			28,
			28,
			16,
			16,
			18,
			18,
			28,
			28,
			16,
			16,
			16,
			16,
			18,
			18,
			28,
			28,
			16,
			16,
			18,
			18,
			0,
			0
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			10,
			23,
			23,
			23,
			23,
			23,
			23,
			23,
			11,
			11,
			25,
			25,
			25
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			10,
			10,
			10,
			10,
			10,
			13,
			13,
			15,
			15,
			13,
			13,
			15,
			15,
			13,
			13,
			15,
			15,
			13,
			13,
			15,
			15,
			13,
			13,
			15,
			15,
			13,
			13,
			10,
			10
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			11,
			11,
			17,
			17,
			17,
			17
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			43,
			43,
			44,
			44,
			45,
			45,
			46,
			46,
			47,
			47,
			48,
			48,
			43,
			43,
			44,
			44,
			45,
			45,
			8,
			8
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			13,
			13,
			15,
			15,
			15,
			15,
			15,
			15,
			15,
			13,
			13,
			15,
			15,
			15
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			10,
			10,
			10,
			10,
			10,
			21,
			21,
			15,
			15,
			15,
			15,
			15,
			15,
			15
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			12,
			12,
			12,
			12
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			10,
			10,
			10,
			11,
			11,
			13,
			13,
			11,
			11,
			13,
			13,
			11,
			11,
			13,
			13,
			10,
			10
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			10,
			10,
			10,
			11,
			11,
			13,
			13,
			11,
			11,
			13,
			13,
			11,
			11,
			13,
			13,
			11,
			11,
			13,
			13,
			11,
			11,
			13,
			13,
			11,
			11,
			13,
			13,
			11,
			11,
			13,
			13,
			11,
			11,
			13,
			13,
			10,
			10
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			10,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			14,
			15,
			15,
			15,
			15,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			11,
			17,
			17,
			17,
			17,
			10,
			10
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			11,
			11,
			11,
			11,
			26,
			26,
			26,
			26,
			26,
			26,
			51,
			51,
			51,
			51,
			51,
			51,
			51,
			56,
			56,
			56,
			60,
			60,
			10
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			10,
			16,
			16,
			16,
			16,
			16,
			16,
			16,
			16,
			10,
			10
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			11,
			11,
			11,
			11
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			10,
			10,
			10,
			19,
			19,
			13,
			13,
			15,
			15,
			10,
			10
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			25
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			25
		},
		new short[]
		{
			8,
			9,
			25,
			25,
			25,
			25,
			26,
			54,
			25,
			26,
			54,
			25,
			26,
			54,
			25,
			26,
			54,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			25
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			10
		},
		new short[]
		{
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			10,
			10
		},
		new short[]
		{
			22,
			22,
			22,
			25,
			25,
			25,
			25,
			25
		},
		new short[]
		{
			10,
			10
		},
		new short[]
		{
			2,
			3,
			3,
			4,
			5,
			6,
			6,
			7
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			10,
			10,
			10,
			10,
			10,
			27,
			27,
			29,
			29,
			27,
			27,
			27,
			27,
			30,
			30,
			14,
			14,
			14,
			14,
			14,
			14,
			14,
			14,
			11,
			11,
			11,
			11,
			11,
			11,
			11,
			11,
			11,
			18,
			18,
			18,
			18,
			14,
			14,
			14,
			14,
			14,
			14,
			14,
			14
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			10,
			10,
			10,
			10,
			10,
			27,
			27,
			29,
			29,
			13,
			13,
			13,
			13,
			15,
			15,
			11,
			11,
			17,
			17,
			7,
			7,
			7,
			7,
			30,
			30,
			27,
			27,
			29,
			29,
			7,
			7,
			7,
			7,
			15,
			15,
			15,
			15,
			10,
			10
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			35,
			35,
			37,
			31,
			33,
			1,
			1,
			35,
			35,
			35,
			37,
			31,
			33,
			1,
			1,
			35,
			35,
			35,
			37,
			31,
			33,
			1,
			1,
			35,
			35,
			35,
			37,
			31,
			33
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			37,
			37
		},
		new short[]
		{
			15,
			15
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			10,
			10,
			10,
			17,
			17,
			13,
			13,
			13,
			13,
			13,
			16,
			16
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			10,
			10,
			10,
			15,
			15,
			27,
			27,
			27,
			27,
			27,
			27,
			29,
			29,
			27,
			27,
			27,
			27,
			28,
			28
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			27,
			27,
			27,
			27,
			28,
			28,
			13,
			13,
			13,
			13,
			13,
			15,
			15,
			10,
			10,
			10,
			10,
			10,
			10,
			17,
			17
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			19,
			19,
			19,
			25,
			25,
			25,
			13,
			13,
			13,
			25,
			25,
			25
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			19,
			19,
			19,
			25,
			25,
			25,
			13,
			13,
			13,
			25,
			25,
			13,
			13,
			13,
			25,
			25
		},
		new short[]
		{
			8,
			9,
			10,
			10,
			13,
			13,
			15,
			15,
			15,
			13,
			13,
			13,
			13,
			13,
			13,
			15,
			15,
			15,
			13,
			13,
			13
		},
		new short[]
		{
			13,
			13,
			15,
			15,
			13,
			13,
			13,
			17,
			17,
			13,
			13,
			14,
			14,
			14,
			16,
			16,
			14,
			14,
			14,
			13
		},
		new short[]
		{
			8,
			9,
			10,
			10,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			15,
			15,
			15,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			17,
			17,
			17,
			13,
			13,
			13,
			14,
			14,
			14,
			14,
			14,
			14,
			14,
			14,
			14,
			14,
			16,
			16,
			16,
			14,
			14,
			14,
			13
		},
		new short[]
		{
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			22,
			22,
			22,
			25,
			25
		},
		new short[]
		{
			21,
			21,
			21,
			22,
			22,
			25,
			25,
			21,
			21,
			21,
			21,
			21,
			21,
			21,
			21,
			22,
			22,
			22,
			25,
			25
		},
		new short[]
		{
			14,
			14,
			14,
			14,
			10,
			22,
			22,
			26,
			26,
			22,
			22,
			22,
			26,
			26,
			10,
			10,
			10,
			10,
			9,
			8
		},
		new short[]
		{
			11,
			11,
			11,
			11,
			27,
			29,
			29,
			27,
			30,
			30,
			11,
			11,
			11,
			11,
			10
		},
		new short[]
		{
			11,
			11,
			11,
			11,
			27,
			29,
			29,
			27,
			30,
			30,
			11,
			11,
			11,
			11,
			27,
			29,
			29,
			27,
			30,
			30
		},
		new short[]
		{
			8,
			9,
			10,
			11,
			11,
			11,
			11,
			11,
			27,
			27,
			29,
			29,
			29,
			29,
			27,
			30,
			30,
			30,
			11,
			11,
			11,
			11,
			11,
			27,
			27,
			29,
			29,
			29,
			29,
			27,
			27,
			30,
			30,
			30,
			11,
			11,
			11,
			11,
			11,
			10
		},
		new short[]
		{
			31,
			31,
			31,
			39,
			39,
			31,
			31,
			31,
			39,
			39,
			31,
			31,
			31,
			39,
			39,
			31,
			31,
			31,
			39,
			39
		},
		new short[]
		{
			31,
			31,
			31,
			39,
			39,
			31,
			31,
			31,
			39,
			39,
			31,
			31,
			31,
			39,
			39,
			31,
			31,
			31,
			39,
			39
		},
		new short[]
		{
			10,
			10,
			10,
			35,
			35,
			37,
			37,
			31,
			31,
			33,
			33,
			33,
			35,
			35,
			37,
			37,
			37,
			31,
			31,
			37
		},
		new short[]
		{
			35,
			35,
			37,
			37,
			31,
			31,
			33,
			33,
			35,
			35,
			37,
			37,
			31,
			31,
			33,
			33,
			35,
			35,
			37,
			37
		},
		new short[]
		{
			9,
			10,
			10,
			10,
			10,
			10,
			38,
			38,
			38,
			38,
			38,
			38,
			38,
			38,
			38,
			38,
			38,
			38,
			38,
			38,
			38,
			38,
			38,
			38,
			38,
			38,
			38,
			38,
			38,
			38
		},
		new short[]
		{
			8,
			9,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10
		},
		new short[]
		{
			8,
			9,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10
		},
		new short[]
		{
			8,
			9,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			23,
			23,
			23,
			23,
			23,
			22,
			21,
			21,
			26,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			10,
			10,
			10,
			10
		},
		new short[]
		{
			8,
			9,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			23,
			23,
			23,
			23,
			23,
			23,
			23,
			25,
			25,
			25,
			25,
			9,
			8
		},
		new short[]
		{
			8,
			9,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			11,
			11,
			11,
			11,
			11,
			11,
			11,
			11,
			11,
			11,
			11,
			9,
			8
		},
		new short[]
		{
			8,
			9,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			11,
			11,
			11,
			11,
			11,
			11,
			11,
			11,
			11,
			11,
			11,
			11,
			10,
			9,
			8
		},
		new short[]
		{
			8,
			9,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			13,
			13,
			13,
			15,
			15,
			15,
			15,
			15,
			15,
			15,
			15,
			15,
			10,
			9,
			8
		},
		new short[]
		{
			8,
			9,
			21,
			21,
			21,
			25,
			25,
			13,
			15,
			15,
			15
		},
		new short[]
		{
			8,
			9,
			21,
			21,
			21,
			25,
			25,
			27,
			27,
			27,
			28,
			28
		},
		new short[]
		{
			8,
			9,
			10,
			10,
			19,
			19,
			18,
			18,
			21,
			21,
			15,
			15,
			10,
			10
		},
		new short[]
		{
			8,
			8,
			9,
			10,
			17,
			17,
			8,
			8,
			8,
			9,
			9,
			10,
			10,
			18,
			17,
			17
		},
		new short[]
		{
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			15,
			22,
			22,
			26,
			26,
			20,
			20,
			16,
			16
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			27,
			28,
			28,
			27,
			30,
			30,
			27,
			29,
			29,
			27,
			10
		},
		new short[]
		{
			31,
			31,
			31,
			39,
			39,
			31,
			31,
			31,
			31,
			39,
			39,
			31,
			31,
			31,
			31,
			31
		},
		new short[]
		{
			35,
			35,
			37,
			31,
			33,
			1,
			1,
			35,
			35,
			35,
			37,
			31,
			33,
			1,
			1,
			35
		},
		new short[]
		{
			10,
			10,
			25,
			25,
			25,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			45,
			43,
			44,
			45,
			46,
			47,
			26,
			26,
			25,
			25,
			25,
			8
		},
		new short[]
		{
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			14,
			14,
			14,
			16,
			16,
			14,
			14,
			14,
			14,
			14,
			18,
			18,
			18,
			22,
			22,
			22,
			22
		},
		new short[]
		{
			27,
			27,
			29,
			27,
			27,
			29,
			13,
			13,
			15,
			15,
			11,
			11,
			17,
			17,
			7,
			7,
			7,
			7,
			30,
			30,
			27,
			27,
			29,
			10
		},
		new short[]
		{
			8,
			8,
			8,
			9,
			9,
			9,
			10,
			10,
			10,
			10,
			39,
			39,
			39,
			39,
			8,
			9,
			9,
			39,
			39,
			39,
			39,
			9,
			9,
			8
		},
		new short[]
		{
			8,
			9,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			9,
			8
		},
		new short[]
		{
			8,
			9,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			9,
			8
		},
		new short[]
		{
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			13,
			13,
			15,
			15,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			8
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			27,
			27,
			27,
			27,
			27,
			27,
			30,
			30,
			28,
			28,
			28,
			28,
			29,
			29,
			28,
			28,
			30,
			30,
			28,
			28,
			29,
			29,
			28,
			28,
			30,
			30
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			31,
			31,
			31,
			31,
			31,
			39,
			39,
			31,
			31,
			31,
			39,
			39,
			31,
			31,
			31,
			31,
			31,
			31,
			39,
			39,
			31,
			31,
			31,
			31,
			31,
			31
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			10,
			10,
			10,
			9
		},
		new short[]
		{
			13,
			13,
			13,
			13,
			13,
			15,
			15,
			15
		},
		new short[]
		{
			8,
			9,
			9,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			13,
			13,
			13,
			15,
			15
		},
		new short[]
		{
			8,
			9,
			9,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10
		},
		new short[]
		{
			8,
			9,
			10,
			35,
			35,
			35,
			35,
			35,
			37,
			37
		},
		new short[]
		{
			8,
			9,
			9,
			10,
			10,
			21,
			21,
			21,
			15,
			15
		},
		new short[]
		{
			8,
			9,
			10,
			23,
			22,
			22,
			22
		},
		new short[]
		{
			8,
			9,
			10,
			25,
			25,
			19,
			19,
			19
		},
		new short[]
		{
			8,
			9,
			10,
			10,
			31,
			31,
			31,
			31,
			31,
			33,
			31,
			31,
			33,
			31,
			31,
			33,
			31,
			31,
			33,
			31,
			31,
			33,
			31,
			31,
			33
		},
		new short[]
		{
			8,
			9,
			10,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35
		},
		new short[]
		{
			8,
			9,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			23,
			23,
			25,
			25
		},
		new short[]
		{
			8,
			9,
			10,
			10,
			23,
			23,
			25,
			25,
			0,
			0,
			1,
			1,
			0,
			0,
			1,
			1,
			23,
			23,
			25,
			25
		},
		new short[]
		{
			8,
			9,
			10,
			10,
			17,
			17,
			19,
			19,
			15,
			15,
			21,
			21,
			10
		},
		new short[]
		{
			37,
			37,
			37,
			37,
			37,
			37,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22
		},
		new short[]
		{
			15,
			15,
			15,
			17,
			17,
			17
		},
		new short[]
		{
			8,
			9,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			25,
			25,
			21,
			21,
			21,
			21,
			21,
			21,
			21,
			21,
			21,
			21
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			10,
			10,
			10,
			10,
			21,
			21,
			21,
			21,
			21,
			21,
			21,
			25,
			25,
			25,
			25,
			10,
			10,
			9
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			21,
			21,
			21,
			21,
			21,
			21,
			10,
			10,
			10,
			10,
			10
		},
		new short[]
		{
			8,
			9,
			30,
			30,
			28,
			28,
			29,
			29,
			29,
			29,
			28,
			28,
			30,
			30,
			10,
			8
		},
		new short[]
		{
			8,
			9,
			10,
			23,
			23,
			23,
			25,
			25,
			25,
			25,
			25,
			25,
			10,
			10
		},
		new short[]
		{
			8,
			9,
			9,
			10,
			10,
			16,
			16,
			16,
			16,
			16,
			16,
			16,
			16,
			16,
			16,
			16,
			16,
			10
		},
		new short[]
		{
			8,
			9,
			10,
			21,
			21,
			21,
			21,
			21,
			26,
			26,
			26,
			9,
			10,
			10
		},
		new short[]
		{
			8,
			8,
			9,
			9,
			10,
			10,
			10,
			10,
			10,
			10,
			27,
			27,
			29,
			29,
			27,
			27,
			27,
			27,
			30,
			30,
			14,
			14,
			14,
			14,
			14,
			14,
			14,
			14,
			27,
			27,
			27,
			27,
			27,
			27,
			27,
			27,
			27,
			28,
			28,
			28,
			28,
			14,
			14,
			14,
			14,
			14,
			14,
			14,
			14
		},
		new short[]
		{
			8,
			8,
			9,
			10,
			17,
			17,
			17,
			14,
			15,
			15,
			27,
			27,
			28,
			28
		},
		new short[]
		{
			8,
			8,
			9,
			10,
			21,
			21,
			21,
			21,
			21,
			21,
			21,
			21,
			21,
			21,
			25,
			25,
			25,
			10,
			10
		},
		new short[]
		{
			8,
			10,
			36,
			36,
			36,
			36,
			36,
			36,
			36,
			36,
			36,
			36,
			36,
			36,
			36,
			36,
			36,
			36,
			36,
			36,
			36,
			36,
			36,
			36,
			36,
			36,
			10
		},
		new short[]
		{
			8,
			8,
			9,
			10,
			17,
			17,
			8,
			8,
			8,
			9,
			9,
			10,
			15,
			15,
			10,
			17,
			17
		},
		new short[]
		{
			8,
			8,
			9,
			10,
			23,
			23,
			23,
			23,
			23,
			23,
			23,
			23,
			23,
			23,
			22,
			22,
			31,
			22,
			22,
			31,
			22,
			22,
			31,
			22,
			22,
			31,
			10
		},
		new short[]
		{
			8,
			8,
			9,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10
		},
		new short[]
		{
			8,
			8,
			9,
			10,
			23,
			23,
			22,
			22,
			31,
			31,
			31,
			31,
			31,
			31,
			31,
			31,
			8
		},
		new short[]
		{
			8,
			8,
			9,
			10,
			39,
			39,
			39,
			39,
			39,
			39,
			39,
			39,
			23,
			23,
			25,
			25,
			25,
			10,
			8
		},
		new short[]
		{
			8,
			8,
			9,
			10,
			0,
			0,
			0,
			0,
			35,
			35,
			35,
			49,
			49,
			0,
			0,
			0,
			0,
			9,
			8
		},
		new short[]
		{
			8,
			9,
			10,
			35,
			35,
			35,
			37,
			37,
			35,
			35,
			37,
			37,
			35,
			35,
			37,
			37,
			35,
			35,
			37,
			37,
			35,
			35,
			37,
			37,
			10,
			8
		},
		new short[]
		{
			8,
			9,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			9
		},
		new short[]
		{
			8,
			9,
			10,
			10,
			21,
			21,
			21,
			21,
			21,
			21,
			21,
			21,
			21,
			21,
			26,
			25,
			25,
			10,
			8
		},
		new short[]
		{
			8,
			9,
			10,
			10,
			14,
			14,
			14,
			14,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			15,
			15,
			15,
			10
		},
		new short[]
		{
			8,
			9,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			21,
			21,
			21,
			35,
			35,
			35,
			10,
			9
		},
		new short[]
		{
			8,
			9,
			10,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			10,
			9
		},
		new short[]
		{
			8,
			9,
			10,
			39,
			39,
			39,
			39,
			40,
			41,
			41,
			39
		},
		new short[4],
		new short[]
		{
			8,
			9,
			10,
			10,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			25,
			25
		},
		new short[]
		{
			8,
			9,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			23,
			23,
			25,
			25
		},
		new short[]
		{
			8,
			9,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10
		},
		new short[]
		{
			11,
			11,
			11,
			11,
			9,
			9,
			9,
			9,
			8,
			8,
			8,
			8,
			9,
			9,
			9,
			9,
			10,
			10,
			10,
			10,
			10,
			13,
			13,
			15,
			15,
			13,
			13,
			17,
			17,
			13,
			13,
			15,
			15,
			13,
			13
		},
		new short[]
		{
			27,
			27,
			27,
			27,
			27,
			27,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			27,
			27,
			27,
			27
		},
		new short[]
		{
			35,
			35,
			37,
			31,
			33,
			35,
			35,
			37,
			31,
			33,
			35,
			35,
			37,
			31,
			33,
			34,
			34,
			34
		},
		new short[]
		{
			9,
			10,
			10,
			10,
			10,
			10,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4
		},
		new short[]
		{
			8,
			9,
			10,
			10,
			21,
			21,
			21,
			21,
			21,
			21,
			21,
			21,
			21,
			21,
			17,
			17,
			21,
			21,
			21,
			21,
			21,
			17,
			17,
			10
		},
		new short[]
		{
			8,
			9,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			22,
			10,
			10,
			10
		},
		new short[]
		{
			8,
			10,
			10,
			10,
			10,
			10,
			14,
			14,
			21,
			25,
			25,
			30,
			29,
			28,
			25,
			19,
			19,
			17,
			19,
			18,
			10,
			10,
			10,
			10
		},
		new short[]
		{
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			37,
			37,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			37,
			37,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			37,
			37,
			35,
			35,
			35,
			35,
			35,
			35,
			35
		},
		new short[]
		{
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			37,
			37,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35,
			35
		},
		new short[]
		{
			1,
			1,
			1,
			1,
			1,
			1,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			9,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			61,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1
		},
		new short[]
		{
			8,
			8,
			8,
			9,
			9,
			9,
			10,
			10,
			10,
			13,
			13,
			17,
			18,
			17,
			17
		},
		new short[]
		{
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			14,
			14,
			14,
			16,
			16,
			14,
			14,
			14,
			14,
			14,
			18,
			18,
			18,
			22,
			22,
			22,
			22,
			26,
			26,
			26,
			23,
			23,
			23,
			23,
			23,
			23,
			25,
			25,
			25,
			25
		},
		new short[]
		{
			8,
			8,
			8,
			9,
			9,
			9,
			10,
			10,
			10,
			13,
			13,
			17,
			18,
			17,
			17
		},
		new short[]
		{
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			14,
			14,
			14,
			16,
			16,
			14,
			14,
			14,
			14,
			14,
			18,
			18,
			18,
			22,
			22,
			22,
			22,
			26,
			26,
			26,
			23,
			23,
			23,
			23,
			23,
			23,
			25,
			25,
			25,
			25
		},
		new short[]
		{
			8,
			8,
			9,
			10,
			27,
			27,
			30,
			30,
			29,
			29,
			27,
			27
		}
	};
}
