using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000096 RID: 150
public class mGraphics
{
	// Token: 0x06000963 RID: 2403 RVA: 0x000C210C File Offset: 0x000C030C
	private void cache(string key, Texture value)
	{
		bool flag = mGraphics.cachedTextures.Count > 400;
		if (flag)
		{
			mGraphics.cachedTextures.Clear();
		}
		bool flag2 = value.width * value.height < MotherCanvas.w * MotherCanvas.h;
		if (flag2)
		{
			mGraphics.cachedTextures.Add(key, value);
		}
	}

	// Token: 0x06000964 RID: 2404 RVA: 0x000C216C File Offset: 0x000C036C
	public void translate(int tx, int ty)
	{
		tx *= mGraphics.zoomLevel;
		ty *= mGraphics.zoomLevel;
		this.translateX += tx;
		this.translateY += ty;
		this.isTranslate = true;
		bool flag = this.translateX == 0 && this.translateY == 0;
		if (flag)
		{
			this.isTranslate = false;
		}
	}

	// Token: 0x06000965 RID: 2405 RVA: 0x000C21D0 File Offset: 0x000C03D0
	public void translate(float x, float y)
	{
		this.translateXf += x;
		this.translateYf += y;
		this.isTranslate = true;
		bool flag = this.translateXf == 0f && this.translateYf == 0f;
		if (flag)
		{
			this.isTranslate = false;
		}
	}

	// Token: 0x06000966 RID: 2406 RVA: 0x000C222C File Offset: 0x000C042C
	public int getTranslateX()
	{
		return this.translateX / mGraphics.zoomLevel;
	}

	// Token: 0x06000967 RID: 2407 RVA: 0x000C224C File Offset: 0x000C044C
	public int getTranslateY()
	{
		return this.translateY / mGraphics.zoomLevel + mGraphics.addYWhenOpenKeyBoard;
	}

	// Token: 0x06000968 RID: 2408 RVA: 0x000C2270 File Offset: 0x000C0470
	public void setClip(int x, int y, int w, int h)
	{
		x *= mGraphics.zoomLevel;
		y *= mGraphics.zoomLevel;
		w *= mGraphics.zoomLevel;
		h *= mGraphics.zoomLevel;
		this.clipTX = this.translateX;
		this.clipTY = this.translateY;
		this.clipX = x;
		this.clipY = y;
		this.clipW = w;
		this.clipH = h;
		this.isClip = true;
	}

	// Token: 0x06000969 RID: 2409 RVA: 0x000C22E0 File Offset: 0x000C04E0
	public void fillRect(int x, int y, int w, int h, int color, int alpha)
	{
		float alpha2 = 0.5f;
		this.setColor(color, alpha2);
		this.fillRect(x, y, w, h, false);
	}

	// Token: 0x0600096A RID: 2410 RVA: 0x0000B15B File Offset: 0x0000935B
	public void fillRect(int x, int y, int w, int h)
	{
		this.fillRect(x, y, w, h, false);
	}

	// Token: 0x0600096B RID: 2411 RVA: 0x000C230C File Offset: 0x000C050C
	public void drawLine(int x1, int y1, int x2, int y2, bool isA)
	{
		x1 *= mGraphics.zoomLevel;
		y1 *= mGraphics.zoomLevel;
		x2 *= mGraphics.zoomLevel;
		y2 *= mGraphics.zoomLevel;
		bool flag = y1 == y2;
		if (flag)
		{
			bool flag2 = x1 > x2;
			if (flag2)
			{
				int num = x2;
				x2 = x1;
				x1 = num;
			}
			this.fillRect(x1, y1, x2 - x1, 1, isA);
		}
		else
		{
			bool flag3 = x1 == x2;
			if (flag3)
			{
				bool flag4 = y1 > y2;
				if (flag4)
				{
					int num2 = y2;
					y2 = y1;
					y1 = num2;
				}
				this.fillRect(x1, y1, 1, y2 - y1, isA);
			}
			else
			{
				bool flag5 = this.isTranslate;
				if (flag5)
				{
					x1 += this.translateX;
					y1 += this.translateY;
					x2 += this.translateX;
					y2 += this.translateY;
				}
				string key = "dl" + this.r.ToString() + this.g.ToString() + this.b.ToString();
				Texture2D texture2D = (Texture2D)mGraphics.cachedTextures[key];
				bool flag6 = texture2D == null;
				if (flag6)
				{
					texture2D = new Texture2D(1, 1);
					Color color = new Color(this.r, this.g, this.b);
					texture2D.SetPixel(0, 0, color);
					texture2D.Apply();
					this.cache(key, texture2D);
				}
				Vector2 vector = new Vector2((float)x1, (float)y1);
				Vector2 vector2 = new Vector2((float)x2, (float)y2);
				Vector2 vector3 = vector2 - vector;
				float num3 = 57.29578f * Mathf.Atan(vector3.y / vector3.x);
				bool flag7 = vector3.x < 0f;
				if (flag7)
				{
					num3 += 180f;
				}
				int num4 = (int)Mathf.Ceil(0f);
				GUIUtility.RotateAroundPivot(num3, vector);
				int num5 = 0;
				int num6 = 0;
				int num7 = 0;
				int num8 = 0;
				bool flag8 = this.isClip;
				if (flag8)
				{
					num5 = this.clipX;
					num6 = this.clipY;
					num7 = this.clipW;
					num8 = this.clipH;
					bool flag9 = this.isTranslate;
					if (flag9)
					{
						num5 += this.clipTX;
						num6 += this.clipTY;
					}
				}
				bool flag10 = this.isClip;
				if (flag10)
				{
					GUI.BeginGroup(new Rect((float)num5, (float)num6, (float)num7, (float)num8));
				}
				Graphics.DrawTexture(new Rect(vector.x - (float)num5, vector.y - (float)num4 - (float)num6, vector3.magnitude, 1f), texture2D);
				bool flag11 = this.isClip;
				if (flag11)
				{
					GUI.EndGroup();
				}
				GUIUtility.RotateAroundPivot(0f - num3, vector);
			}
		}
	}

	// Token: 0x0600096C RID: 2412 RVA: 0x0000B16B File Offset: 0x0000936B
	public void drawLine(int x1, int y1, int x2, int y2)
	{
		this.drawLine(x1, y1, x2, y2, false);
	}

	// Token: 0x0600096D RID: 2413 RVA: 0x000C138C File Offset: 0x000BF58C
	public Color setColorMiniMap(int rgb)
	{
		int num = rgb & 255;
		int num2 = rgb >> 8 & 255;
		int num3 = rgb >> 16 & 255;
		float num4 = (float)num / 256f;
		float num5 = (float)num2 / 256f;
		float num6 = (float)num3 / 256f;
		return new Color(num6, num5, num4);
	}

	// Token: 0x0600096E RID: 2414 RVA: 0x000C25B4 File Offset: 0x000C07B4
	public float[] getRGB(Color cl)
	{
		float num = 256f * cl.r;
		float num2 = 256f * cl.g;
		float num3 = 256f * cl.b;
		return new float[]
		{
			num,
			num2,
			num3
		};
	}

	// Token: 0x0600096F RID: 2415 RVA: 0x000C2600 File Offset: 0x000C0800
	public void drawRect(int x, int y, int w, int h, bool isA)
	{
		int num = 1;
		this.fillRect(x, y, w, num, isA);
		this.fillRect(x, y, num, h, isA);
		this.fillRect(x + w, y, num, h + 1, isA);
		this.fillRect(x, y + h, w + 1, num, isA);
	}

	// Token: 0x06000970 RID: 2416 RVA: 0x000C2650 File Offset: 0x000C0850
	public void drawRect(int x, int y, int w, int h)
	{
		int num = 1;
		this.fillRect(x, y, w, num);
		this.fillRect(x, y, num, h);
		this.fillRect(x + w, y, num, h + 1);
		this.fillRect(x, y + h, w + 1, num);
	}

	// Token: 0x06000971 RID: 2417 RVA: 0x000C2698 File Offset: 0x000C0898
	public void drawArc(int x, int y, int w, int h, int a, int b, bool isA)
	{
		int num = 1;
		this.fillRect(x, y, w, num, isA);
		this.fillRect(x, y, num, h, isA);
		this.fillRect(x + w, y, num, h + 1, isA);
		this.fillRect(x, y + h, w + 1, num, isA);
	}

	// Token: 0x06000972 RID: 2418 RVA: 0x000C26E8 File Offset: 0x000C08E8
	public void fillRect(int x, int y, int w, int h, bool isA)
	{
		x *= mGraphics.zoomLevel;
		y *= mGraphics.zoomLevel;
		w *= mGraphics.zoomLevel;
		h *= mGraphics.zoomLevel;
		bool flag = w < 0 || h < 0;
		if (!flag)
		{
			bool flag2 = this.isTranslate;
			if (flag2)
			{
				x += this.translateX;
				y += this.translateY;
			}
			int width = 1;
			int height = 1;
			string key = string.Concat(new string[]
			{
				"fr",
				width.ToString(),
				height.ToString(),
				this.r.ToString(),
				this.g.ToString(),
				this.b.ToString(),
				this.a.ToString()
			});
			Texture2D texture2D = (Texture2D)mGraphics.cachedTextures[key];
			bool flag3 = texture2D == null;
			if (flag3)
			{
				texture2D = new Texture2D(width, height);
				Color color = new Color(this.r, this.g, this.b, this.a);
				texture2D.SetPixel(0, 0, color);
				texture2D.Apply();
				this.cache(key, texture2D);
			}
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			bool flag4 = this.isClip;
			if (flag4)
			{
				num = this.clipX;
				num2 = this.clipY;
				num3 = this.clipW;
				num4 = this.clipH;
				bool flag5 = this.isTranslate;
				if (flag5)
				{
					num += this.clipTX;
					num2 += this.clipTY;
				}
			}
			bool flag6 = this.isClip;
			if (flag6)
			{
				GUI.BeginGroup(new Rect((float)num, (float)num2, (float)num3, (float)num4));
			}
			GUI.DrawTexture(new Rect((float)(x - num), (float)(y - num2), (float)w, (float)h), texture2D);
			bool flag7 = this.isClip;
			if (flag7)
			{
				GUI.EndGroup();
			}
		}
	}

	// Token: 0x06000973 RID: 2419 RVA: 0x0000B15B File Offset: 0x0000935B
	public void fillArc(int x, int y, int w, int h, int a, int b, bool isSetClip)
	{
		this.fillRect(x, y, w, h, false);
	}

	// Token: 0x06000974 RID: 2420 RVA: 0x000C28D0 File Offset: 0x000C0AD0
	public void setColor(int rgb)
	{
		int num = rgb & 255;
		int num2 = rgb >> 8 & 255;
		int num3 = rgb >> 16 & 255;
		this.b = (float)num / 256f;
		this.g = (float)num2 / 256f;
		this.r = (float)num3 / 256f;
		this.a = 255f;
	}

	// Token: 0x06000975 RID: 2421 RVA: 0x0000B17B File Offset: 0x0000937B
	public void setColor(Color color)
	{
		this.b = color.b;
		this.g = color.g;
		this.r = color.r;
	}

	// Token: 0x06000976 RID: 2422 RVA: 0x000C2930 File Offset: 0x000C0B30
	public void setBgColor(int rgb)
	{
		bool flag = rgb != this.currentBGColor;
		if (flag)
		{
			this.currentBGColor = rgb;
			int num = rgb & 255;
			int num2 = rgb >> 8 & 255;
			int num3 = rgb >> 16 & 255;
			this.b = (float)num / 256f;
			this.g = (float)num2 / 256f;
			this.r = (float)num3 / 256f;
			Main.main.GetComponent<UnityEngine.Camera>().backgroundColor = new Color(this.r, this.g, this.b);
		}
	}

	// Token: 0x06000977 RID: 2423 RVA: 0x000C29C8 File Offset: 0x000C0BC8
	public void drawString(string s, int x, int y, GUIStyle style)
	{
		x *= mGraphics.zoomLevel;
		y *= mGraphics.zoomLevel;
		bool flag = this.isTranslate;
		if (flag)
		{
			x += this.translateX;
			y += this.translateY;
		}
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		bool flag2 = this.isClip;
		if (flag2)
		{
			num = this.clipX;
			num2 = this.clipY;
			num3 = this.clipW;
			num4 = this.clipH;
			bool flag3 = this.isTranslate;
			if (flag3)
			{
				num += this.clipTX;
				num2 += this.clipTY;
			}
		}
		bool flag4 = this.isClip;
		if (flag4)
		{
			GUI.BeginGroup(new Rect((float)num, (float)num2, (float)num3, (float)num4));
		}
		GUI.Label(new Rect((float)(x - num), (float)(y - num2), ScaleGUI.WIDTH, 100f), s, style);
		bool flag5 = this.isClip;
		if (flag5)
		{
			GUI.EndGroup();
		}
	}

	// Token: 0x06000978 RID: 2424 RVA: 0x000C2AB4 File Offset: 0x000C0CB4
	public void drawString(string s, int x, int y, int archor)
	{
		int num = -8;
		mFont.tahoma_7_white.drawString(this, s, x, y + num, archor);
	}

	// Token: 0x06000979 RID: 2425 RVA: 0x000C2AD8 File Offset: 0x000C0CD8
	public void setColor(int rgb, float alpha)
	{
		int num = rgb & 255;
		int num2 = rgb >> 8 & 255;
		int num3 = rgb >> 16 & 255;
		this.b = (float)num / 256f;
		this.g = (float)num2 / 256f;
		this.r = (float)num3 / 256f;
		this.a = alpha;
	}

	// Token: 0x0600097A RID: 2426 RVA: 0x000C2B34 File Offset: 0x000C0D34
	public void drawString(string s, int x, int y, GUIStyle style, int w)
	{
		x *= mGraphics.zoomLevel;
		y *= mGraphics.zoomLevel;
		bool flag = this.isTranslate;
		if (flag)
		{
			x += this.translateX;
			y += this.translateY;
		}
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		bool flag2 = this.isClip;
		if (flag2)
		{
			num = this.clipX;
			num2 = this.clipY;
			num3 = this.clipW;
			num4 = this.clipH;
			bool flag3 = this.isTranslate;
			if (flag3)
			{
				num += this.clipTX;
				num2 += this.clipTY;
			}
		}
		bool flag4 = this.isClip;
		if (flag4)
		{
			GUI.BeginGroup(new Rect((float)num, (float)num2, (float)num3, (float)num4));
		}
		GUI.Label(new Rect((float)(x - num), (float)(y - num2 - 4), (float)w, 100f), s, style);
		bool flag5 = this.isClip;
		if (flag5)
		{
			GUI.EndGroup();
		}
	}

	// Token: 0x0600097B RID: 2427 RVA: 0x000C2C20 File Offset: 0x000C0E20
	private void UpdatePos(int anchor)
	{
		Vector2 vector = new Vector2(0f, 0f);
		if (anchor <= 17)
		{
			if (anchor <= 6)
			{
				if (anchor != 3)
				{
					if (anchor == 6)
					{
						vector = new Vector2(0f, (float)(Screen.height / 2));
					}
				}
				else
				{
					vector = new Vector2(this.size.x / 2f, this.size.y / 2f);
				}
			}
			else if (anchor != 10)
			{
				if (anchor == 17)
				{
					vector = new Vector2((float)(Screen.width / 2), 0f);
				}
			}
			else
			{
				vector = new Vector2((float)Screen.width, (float)(Screen.height / 2));
			}
		}
		else if (anchor <= 24)
		{
			if (anchor != 20)
			{
				if (anchor == 24)
				{
					vector = new Vector2((float)Screen.width, 0f);
				}
			}
			else
			{
				vector = new Vector2(0f, 0f);
			}
		}
		else if (anchor != 33)
		{
			if (anchor != 36)
			{
				if (anchor == 40)
				{
					vector = new Vector2((float)Screen.width, (float)Screen.height);
				}
			}
			else
			{
				vector = new Vector2(0f, (float)Screen.height);
			}
		}
		else
		{
			vector = new Vector2((float)(Screen.width / 2), (float)Screen.height);
		}
		this.pos = vector + this.relativePosition;
		this.rect = new Rect(this.pos.x - this.size.x * 0.5f, this.pos.y - this.size.y * 0.5f, this.size.x, this.size.y);
		this.pivot = new Vector2(this.rect.xMin + this.rect.width * 0.5f, this.rect.yMin + this.rect.height * 0.5f);
	}

	// Token: 0x0600097C RID: 2428 RVA: 0x000C2E40 File Offset: 0x000C1040
	public void drawRegion(Image arg0, int x0, int y0, int w0, int h0, int arg5, int x, int y, int arg8, bool isA)
	{
		x *= mGraphics.zoomLevel;
		y *= mGraphics.zoomLevel;
		x0 *= mGraphics.zoomLevel;
		y0 *= mGraphics.zoomLevel;
		w0 *= mGraphics.zoomLevel;
		h0 *= mGraphics.zoomLevel;
		this._drawRegion(arg0, (float)x0, (float)y0, w0, h0, arg5, x, y, arg8);
	}

	// Token: 0x0600097D RID: 2429 RVA: 0x000C2E40 File Offset: 0x000C1040
	public void drawRegion(Image arg0, int x0, int y0, int w0, int h0, int arg5, int x, int y, int arg8)
	{
		x *= mGraphics.zoomLevel;
		y *= mGraphics.zoomLevel;
		x0 *= mGraphics.zoomLevel;
		y0 *= mGraphics.zoomLevel;
		w0 *= mGraphics.zoomLevel;
		h0 *= mGraphics.zoomLevel;
		this._drawRegion(arg0, (float)x0, (float)y0, w0, h0, arg5, x, y, arg8);
	}

	// Token: 0x0600097E RID: 2430 RVA: 0x000C2EA0 File Offset: 0x000C10A0
	public void drawRegion(mImage arg0, int x0, int y0, int w0, int h0, int arg5, float x, float y, int arg8)
	{
		x *= (float)mGraphics.zoomLevel;
		y *= (float)mGraphics.zoomLevel;
		x0 *= mGraphics.zoomLevel;
		y0 *= mGraphics.zoomLevel;
		w0 *= mGraphics.zoomLevel;
		h0 *= mGraphics.zoomLevel;
		this.__drawRegion(arg0.image, x0, y0, w0, h0, arg5, x, y, arg8);
	}

	// Token: 0x0600097F RID: 2431 RVA: 0x000C2F08 File Offset: 0x000C1108
	public void __drawRegion(Image image, int x0, int y0, int w, int h, int transform, float x, float y, int anchor)
	{
		bool flag = image == null;
		if (!flag)
		{
			bool flag2 = this.isTranslate;
			if (flag2)
			{
				x += (float)this.translateX;
				y += (float)this.translateY;
			}
			float num = (float)w;
			float num2 = (float)h;
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 1f;
			float num6 = 0f;
			int num7 = 1;
			if (transform - 4 <= 3)
			{
				num = (float)h;
				num2 = (float)w;
			}
			int num8 = 0;
			int num9 = 0;
			if (anchor <= 17)
			{
				if (anchor <= 6)
				{
					if (anchor != 3)
					{
						if (anchor == 6)
						{
							num8 = 0;
							num9 = (int)num2 / 2;
						}
					}
					else
					{
						num8 = (int)num / 2;
						num9 = (int)num2 / 2;
					}
				}
				else if (anchor != 10)
				{
					if (anchor == 17)
					{
						num8 = (int)num / 2;
						num9 = 0;
					}
				}
				else
				{
					num8 = (int)num;
					num9 = (int)num2 / 2;
				}
			}
			else if (anchor <= 24)
			{
				if (anchor != 20)
				{
					if (anchor == 24)
					{
						num8 = (int)num;
						num9 = 0;
					}
				}
				else
				{
					num8 = 0;
					num9 = 0;
				}
			}
			else if (anchor != 33)
			{
				if (anchor != 36)
				{
					if (anchor == 40)
					{
						num8 = (int)num;
						num9 = (int)num2;
					}
				}
				else
				{
					num8 = 0;
					num9 = (int)num2;
				}
			}
			else
			{
				num8 = (int)num / 2;
				num9 = (int)num2;
			}
			x -= (float)num8;
			y -= (float)num9;
			int num10 = 0;
			int num11 = 0;
			bool flag3 = this.isClip;
			if (flag3)
			{
				num10 = this.clipX;
				int num12 = this.clipY;
				num11 = this.clipW;
				int num13 = this.clipH;
				bool flag4 = this.isTranslate;
				if (flag4)
				{
					num10 += this.clipTX;
					num12 += this.clipTY;
				}
				Rect r = new Rect(x, y, (float)w, (float)h);
				Rect r2 = new Rect((float)num10, (float)num12, (float)num11, (float)num13);
				Rect rect = this.intersectRect(r, r2);
				bool flag5 = rect.width <= 0f || rect.height <= 0f;
				if (flag5)
				{
					return;
				}
				num = rect.width;
				num2 = rect.height;
				num3 = rect.x - r.x;
				num4 = rect.y - r.y;
			}
			float num14 = 0f;
			float num15 = 0f;
			switch (transform)
			{
			case 1:
				num7 = -1;
				num15 += num2;
				break;
			case 2:
			{
				num14 += num;
				num5 = -1f;
				bool flag6 = this.isClip;
				if (flag6)
				{
					bool flag7 = (float)num10 > x;
					if (flag7)
					{
						num6 = 0f - num3;
					}
					else
					{
						bool flag8 = (float)(num10 + num11) < x + (float)w;
						if (flag8)
						{
							num6 = 0f - ((float)(num10 + num11) - x - (float)w);
						}
					}
				}
				break;
			}
			case 3:
				num7 = -1;
				num15 += num2;
				num5 = -1f;
				num14 += num;
				break;
			}
			int num16 = 0;
			int num17 = 0;
			bool flag9 = transform == 5 || transform == 6 || transform == 4 || transform == 7;
			if (flag9)
			{
				this.matrixBackup = GUI.matrix;
				this.size = new Vector2((float)w, (float)h);
				this.relativePosition = new Vector2(x, y);
				this.UpdatePos(3);
				if (transform != 5)
				{
					if (transform == 6)
					{
						this.UpdatePos(3);
					}
				}
				else
				{
					this.size = new Vector2((float)w, (float)h);
					this.UpdatePos(3);
				}
				switch (transform)
				{
				case 4:
				{
					GUIUtility.RotateAroundPivot(270f, this.pivot);
					num14 += num;
					num5 = -1f;
					bool flag10 = this.isClip;
					if (flag10)
					{
						bool flag11 = (float)num10 > x;
						if (flag11)
						{
							num6 = 0f - num3;
						}
						else
						{
							bool flag12 = (float)(num10 + num11) < x + (float)w;
							if (flag12)
							{
								num6 = 0f - ((float)(num10 + num11) - x - (float)w);
							}
						}
					}
					break;
				}
				case 5:
					GUIUtility.RotateAroundPivot(90f, this.pivot);
					num14 = num2;
					break;
				case 6:
					GUIUtility.RotateAroundPivot(270f, this.pivot);
					break;
				case 7:
					GUIUtility.RotateAroundPivot(270f, this.pivot);
					num7 = -1;
					num15 += num2;
					break;
				}
			}
			Graphics.DrawTexture(new Rect(x + num3 + num14 + (float)num16, y + num4 + (float)num17 + num15, num * num5, num2 * (float)num7), image.texture, new Rect(((float)x0 + num3 + num6) / (float)image.texture.width, ((float)image.texture.height - num2 - ((float)y0 + num4)) / (float)image.texture.height, num / (float)image.texture.width, num2 / (float)image.texture.height), 0, 0, 0, 0);
			bool flag13 = transform == 5 || transform == 6 || transform == 4 || transform == 7;
			if (flag13)
			{
				GUI.matrix = this.matrixBackup;
			}
		}
	}

	// Token: 0x06000980 RID: 2432 RVA: 0x000C3448 File Offset: 0x000C1648
	public void _drawRegion(Image image, float x0, float y0, int w, int h, int transform, int x, int y, int anchor)
	{
		bool flag = image == null;
		if (!flag)
		{
			bool flag2 = this.isTranslate;
			if (flag2)
			{
				x += this.translateX;
				y += this.translateY;
			}
			float num = (float)w;
			float num2 = (float)h;
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 0f;
			float num6 = 0f;
			float num7 = 1f;
			float num8 = 0f;
			int num9 = 1;
			bool flag3 = (anchor & mGraphics.HCENTER) == mGraphics.HCENTER;
			if (flag3)
			{
				num5 -= num / 2f;
			}
			bool flag4 = (anchor & mGraphics.VCENTER) == mGraphics.VCENTER;
			if (flag4)
			{
				num6 -= num2 / 2f;
			}
			bool flag5 = (anchor & mGraphics.RIGHT) == mGraphics.RIGHT;
			if (flag5)
			{
				num5 -= num;
			}
			bool flag6 = (anchor & mGraphics.BOTTOM) == mGraphics.BOTTOM;
			if (flag6)
			{
				num6 -= num2;
			}
			x += (int)num5;
			y += (int)num6;
			int num10 = 0;
			int num11 = 0;
			bool flag7 = this.isClip;
			if (flag7)
			{
				num10 = this.clipX;
				int num12 = this.clipY;
				num11 = this.clipW;
				int num13 = this.clipH;
				bool flag8 = this.isTranslate;
				if (flag8)
				{
					num10 += this.clipTX;
					num12 += this.clipTY;
				}
				Rect r = new Rect((float)x, (float)y, (float)w, (float)h);
				Rect r2 = new Rect((float)num10, (float)num12, (float)num11, (float)num13);
				Rect rect = this.intersectRect(r, r2);
				bool flag9 = rect.width <= 0f || rect.height <= 0f;
				if (flag9)
				{
					return;
				}
				num = rect.width;
				num2 = rect.height;
				num3 = rect.x - r.x;
				num4 = rect.y - r.y;
			}
			float num14 = 0f;
			float num15 = 0f;
			switch (transform)
			{
			case 1:
				num9 = -1;
				num15 += num2;
				break;
			case 2:
			{
				num14 += num;
				num7 = -1f;
				bool flag10 = this.isClip;
				if (flag10)
				{
					bool flag11 = num10 > x;
					if (flag11)
					{
						num8 = 0f - num3;
					}
					else
					{
						bool flag12 = num10 + num11 < x + w;
						if (flag12)
						{
							num8 = (float)(-(float)(num10 + num11 - x - w));
						}
					}
				}
				break;
			}
			case 3:
				num9 = -1;
				num15 += num2;
				num7 = -1f;
				num14 += num;
				break;
			}
			int num16 = 0;
			int num17 = 0;
			bool flag13 = transform == 5 || transform == 6 || transform == 4 || transform == 7;
			if (flag13)
			{
				this.matrixBackup = GUI.matrix;
				this.size = new Vector2((float)w, (float)h);
				this.relativePosition = new Vector2((float)x, (float)y);
				this.UpdatePos(3);
				if (transform != 5)
				{
					if (transform == 6)
					{
						this.UpdatePos(3);
					}
				}
				else
				{
					this.size = new Vector2((float)w, (float)h);
					this.UpdatePos(3);
				}
				switch (transform)
				{
				case 4:
				{
					GUIUtility.RotateAroundPivot(270f, this.pivot);
					num14 += num;
					num7 = -1f;
					bool flag14 = this.isClip;
					if (flag14)
					{
						bool flag15 = num10 > x;
						if (flag15)
						{
							num8 = 0f - num3;
						}
						else
						{
							bool flag16 = num10 + num11 < x + w;
							if (flag16)
							{
								num8 = (float)(-(float)(num10 + num11 - x - w));
							}
						}
					}
					break;
				}
				case 5:
					GUIUtility.RotateAroundPivot(90f, this.pivot);
					break;
				case 6:
					GUIUtility.RotateAroundPivot(270f, this.pivot);
					break;
				case 7:
					GUIUtility.RotateAroundPivot(270f, this.pivot);
					num9 = -1;
					num15 += num2;
					break;
				}
			}
			Graphics.DrawTexture(new Rect((float)x + num3 + num14 + (float)num16, (float)y + num4 + (float)num17 + num15, num * num7, num2 * (float)num9), image.texture, new Rect((x0 + num3 + num8) / (float)image.texture.width, ((float)image.texture.height - num2 - (y0 + num4)) / (float)image.texture.height, num / (float)image.texture.width, num2 / (float)image.texture.height), 0, 0, 0, 0);
			bool flag17 = transform == 5 || transform == 6 || transform == 4 || transform == 7;
			if (flag17)
			{
				GUI.matrix = this.matrixBackup;
			}
		}
	}

	// Token: 0x06000981 RID: 2433 RVA: 0x000C390C File Offset: 0x000C1B0C
	public void drawRegion2(Image image, float x0, float y0, int w, int h, int transform, int x, int y, int anchor)
	{
		GUI.color = image.colorBlend;
		bool flag = this.isTranslate;
		if (flag)
		{
			x += this.translateX;
			y += this.translateY;
		}
		string key = string.Concat(new string[]
		{
			"dg",
			x0.ToString(),
			y0.ToString(),
			w.ToString(),
			h.ToString(),
			transform.ToString(),
			image.GetHashCode().ToString()
		});
		Texture2D texture2D = (Texture2D)mGraphics.cachedTextures[key];
		bool flag2 = texture2D == null;
		if (flag2)
		{
			Image image2 = Image.createImage(image, (int)x0, (int)y0, w, h, transform);
			texture2D = image2.texture;
			this.cache(key, texture2D);
		}
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		float num5 = (float)w;
		float num6 = (float)h;
		float num7 = 0f;
		float num8 = 0f;
		bool flag3 = (anchor & mGraphics.HCENTER) == mGraphics.HCENTER;
		if (flag3)
		{
			num7 -= num5 / 2f;
		}
		bool flag4 = (anchor & mGraphics.VCENTER) == mGraphics.VCENTER;
		if (flag4)
		{
			num8 -= num6 / 2f;
		}
		bool flag5 = (anchor & mGraphics.RIGHT) == mGraphics.RIGHT;
		if (flag5)
		{
			num7 -= num5;
		}
		bool flag6 = (anchor & mGraphics.BOTTOM) == mGraphics.BOTTOM;
		if (flag6)
		{
			num8 -= num6;
		}
		x += (int)num7;
		y += (int)num8;
		bool flag7 = this.isClip;
		if (flag7)
		{
			num = this.clipX;
			num2 = this.clipY;
			num3 = this.clipW;
			num4 = this.clipH;
			bool flag8 = this.isTranslate;
			if (flag8)
			{
				num += this.clipTX;
				num2 += this.clipTY;
			}
		}
		bool flag9 = this.isClip;
		if (flag9)
		{
			GUI.BeginGroup(new Rect((float)num, (float)num2, (float)num3, (float)num4));
		}
		GUI.DrawTexture(new Rect((float)(x - num), (float)(y - num2), (float)w, (float)h), texture2D);
		bool flag10 = this.isClip;
		if (flag10)
		{
			GUI.EndGroup();
		}
		GUI.color = new Color(1f, 1f, 1f, 1f);
	}

	// Token: 0x06000982 RID: 2434 RVA: 0x000C3B5C File Offset: 0x000C1D5C
	public void drawImagaByDrawTexture(Image image, float x, float y)
	{
		x *= (float)mGraphics.zoomLevel;
		y *= (float)mGraphics.zoomLevel;
		GUI.DrawTexture(new Rect(x + (float)this.translateX, y + (float)this.translateY, (float)image.getRealImageWidth(), (float)image.getRealImageHeight()), image.texture);
	}

	// Token: 0x06000983 RID: 2435 RVA: 0x000C3BB0 File Offset: 0x000C1DB0
	public void drawImage(mImage image, int x, int y, int anchor)
	{
		bool flag = image != null && image.image != null;
		if (flag)
		{
			this.drawRegion(image, 0, 0, mImage.getImageWidth(image.image), mImage.getImageHeight(image.image), 0, (float)x, (float)y, anchor);
		}
	}

	// Token: 0x06000984 RID: 2436 RVA: 0x0000B1A2 File Offset: 0x000093A2
	public void drawRoundRect(int x, int y, int w, int h, int arcWidth, int arcHeight)
	{
		this.drawRect(x, y, w, h, false);
	}

	// Token: 0x06000985 RID: 2437 RVA: 0x0000B15B File Offset: 0x0000935B
	public void fillRoundRect(int x, int y, int width, int height, int arcWidth, int arcHeight)
	{
		this.fillRect(x, y, width, height, false);
	}

	// Token: 0x06000986 RID: 2438 RVA: 0x0000B1B2 File Offset: 0x000093B2
	public void reset()
	{
		this.isClip = false;
		this.isTranslate = false;
		this.translateX = 0;
		this.translateY = 0;
	}

	// Token: 0x06000987 RID: 2439 RVA: 0x000C3BFC File Offset: 0x000C1DFC
	public Rect intersectRect(Rect r1, Rect r2)
	{
		float num = r1.x;
		float num2 = r1.y;
		float x = r2.x;
		float y = r2.y;
		float num3 = num;
		num3 += r1.width;
		float num4 = num2;
		num4 += r1.height;
		float num5 = x;
		num5 += r2.width;
		float num6 = y;
		num6 += r2.height;
		bool flag = num < x;
		if (flag)
		{
			num = x;
		}
		bool flag2 = num2 < y;
		if (flag2)
		{
			num2 = y;
		}
		bool flag3 = num3 > num5;
		if (flag3)
		{
			num3 = num5;
		}
		bool flag4 = num4 > num6;
		if (flag4)
		{
			num4 = num6;
		}
		num3 -= num;
		num4 -= num2;
		bool flag5 = num3 < -30000f;
		if (flag5)
		{
			num3 = -30000f;
		}
		bool flag6 = num4 < -30000f;
		if (flag6)
		{
			num4 = -30000f;
		}
		return new Rect(num, num2, (float)((int)num3), (float)((int)num4));
	}

	// Token: 0x06000988 RID: 2440 RVA: 0x000C3CF8 File Offset: 0x000C1EF8
	public void drawImageScale(Image image, int x, int y, int w, int h, int tranform)
	{
		GUI.color = Color.red;
		x *= mGraphics.zoomLevel;
		y *= mGraphics.zoomLevel;
		w *= mGraphics.zoomLevel;
		h *= mGraphics.zoomLevel;
		bool flag = image != null;
		if (flag)
		{
			Graphics.DrawTexture(new Rect((float)(x + this.translateX), (float)(y + this.translateY), (float)((tranform != 0) ? (-(float)w) : w), (float)h), image.texture);
		}
	}

	// Token: 0x06000989 RID: 2441 RVA: 0x000C3D74 File Offset: 0x000C1F74
	public void drawImageSimple(Image image, int x, int y)
	{
		x *= mGraphics.zoomLevel;
		y *= mGraphics.zoomLevel;
		bool flag = image != null;
		if (flag)
		{
			Graphics.DrawTexture(new Rect((float)x, (float)y, (float)image.w, (float)image.h), image.texture);
		}
	}

	// Token: 0x0600098A RID: 2442 RVA: 0x0007FDE8 File Offset: 0x0007DFE8
	public static int getImageWidth(Image image)
	{
		return image.getWidth();
	}

	// Token: 0x0600098B RID: 2443 RVA: 0x0007FE00 File Offset: 0x0007E000
	public static int getImageHeight(Image image)
	{
		return image.getHeight();
	}

	// Token: 0x0600098C RID: 2444 RVA: 0x000C3DC4 File Offset: 0x000C1FC4
	public static bool isNotTranColor(Color color)
	{
		bool flag = color == Color.clear || color == mGraphics.transParentColor;
		return !flag;
	}

	// Token: 0x0600098D RID: 2445 RVA: 0x000C3DFC File Offset: 0x000C1FFC
	public static Image blend(Image img0, float level, int rgb)
	{
		int num = rgb & 255;
		int num2 = rgb >> 8 & 255;
		int num3 = rgb >> 16 & 255;
		float num4 = (float)num / 256f;
		float num5 = (float)num2 / 256f;
		float num6 = (float)num3 / 256f;
		Color color = new Color(num6, num5, num4);
		Color[] pixels = img0.texture.GetPixels();
		float num7 = color.r;
		float num8 = color.g;
		float num9 = color.b;
		for (int i = 0; i < pixels.Length; i++)
		{
			Color color2 = pixels[i];
			bool flag = mGraphics.isNotTranColor(color2);
			if (flag)
			{
				float num10 = (num7 - color2.r) * level + color2.r;
				float num11 = (num8 - color2.g) * level + color2.g;
				float num12 = (num9 - color2.b) * level + color2.b;
				bool flag2 = num10 > 255f;
				if (flag2)
				{
					num10 = 255f;
				}
				bool flag3 = num10 < 0f;
				if (flag3)
				{
					num10 = 0f;
				}
				bool flag4 = num11 > 255f;
				if (flag4)
				{
					num11 = 255f;
				}
				bool flag5 = num11 < 0f;
				if (flag5)
				{
					num11 = 0f;
				}
				bool flag6 = num12 < 0f;
				if (flag6)
				{
					num12 = 0f;
				}
				bool flag7 = num12 > 255f;
				if (flag7)
				{
					num12 = 255f;
				}
				pixels[i].r = num10;
				pixels[i].g = num11;
				pixels[i].b = num12;
			}
		}
		Image image = Image.createImage(img0.getRealImageWidth(), img0.getRealImageHeight());
		image.texture.SetPixels(pixels);
		Image.setTextureQuality(image.texture);
		image.texture.Apply();
		Cout.LogError2("BLEND ----------------------------------------------------");
		return image;
	}

	// Token: 0x0600098E RID: 2446 RVA: 0x0007F218 File Offset: 0x0007D418
	public static Color setColorObj(int rgb)
	{
		int num = rgb & 255;
		int num2 = rgb >> 8 & 255;
		int num3 = rgb >> 16 & 255;
		float num4 = (float)num / 256f;
		float num5 = (float)num2 / 256f;
		float num6 = (float)num3 / 256f;
		return new Color(num6, num5, num4);
	}

	// Token: 0x0600098F RID: 2447 RVA: 0x0000B1D1 File Offset: 0x000093D1
	public void fillTrans(Image imgTrans, int x, int y, int w, int h)
	{
		this.setColor(0, 0.5f);
		this.fillRect(x * mGraphics.zoomLevel, y * mGraphics.zoomLevel, w * mGraphics.zoomLevel, h * mGraphics.zoomLevel, false);
	}

	// Token: 0x06000990 RID: 2448 RVA: 0x000C4008 File Offset: 0x000C2208
	public static int blendColor(float level, int color, int colorBlend)
	{
		Color color2 = mGraphics.setColorObj(colorBlend);
		float num = color2.r * 255f;
		float num2 = color2.g * 255f;
		float num3 = color2.b * 255f;
		Color color3 = mGraphics.setColorObj(color);
		float num4 = (num + color3.r) * level + color3.r;
		float num5 = (num2 + color3.g) * level + color3.g;
		float num6 = (num3 + color3.b) * level + color3.b;
		bool flag = num4 > 255f;
		if (flag)
		{
			num4 = 255f;
		}
		bool flag2 = num4 < 0f;
		if (flag2)
		{
			num4 = 0f;
		}
		bool flag3 = num5 > 255f;
		if (flag3)
		{
			num5 = 255f;
		}
		bool flag4 = num5 < 0f;
		if (flag4)
		{
			num5 = 0f;
		}
		bool flag5 = num6 < 0f;
		if (flag5)
		{
			num6 = 0f;
		}
		bool flag6 = num6 > 255f;
		if (flag6)
		{
			num6 = 255f;
		}
		return (int)num6 & 255 + ((int)num5 << 8) & 255 + ((int)num4 << 16) & 255;
	}

	// Token: 0x06000991 RID: 2449 RVA: 0x000C4144 File Offset: 0x000C2344
	public static int getIntByColor(Color cl)
	{
		float num = cl.r * 255f;
		float num2 = cl.b * 255f;
		float num3 = cl.g * 255f;
		return ((int)num & 255) << 16 | ((int)num3 & 255) << 8 | ((int)num2 & 255);
	}

	// Token: 0x06000992 RID: 2450 RVA: 0x0007FE18 File Offset: 0x0007E018
	public static int getRealImageWidth(Image img)
	{
		return img.w;
	}

	// Token: 0x06000993 RID: 2451 RVA: 0x0007FE30 File Offset: 0x0007E030
	public static int getRealImageHeight(Image img)
	{
		return img.h;
	}

	// Token: 0x06000994 RID: 2452 RVA: 0x0000B207 File Offset: 0x00009407
	public void fillArg(int i, int j, int k, int l, int m, int n)
	{
		this.fillRect(i * mGraphics.zoomLevel, j * mGraphics.zoomLevel, k * mGraphics.zoomLevel, l * mGraphics.zoomLevel, false);
	}

	// Token: 0x06000995 RID: 2453 RVA: 0x000C419C File Offset: 0x000C239C
	public void CreateLineMaterial()
	{
		bool flag = !this.lineMaterial;
		if (flag)
		{
			this.lineMaterial = new Material("Shader \"Lines/Colored Blended\" {SubShader { Pass {  Blend SrcAlpha OneMinusSrcAlpha  ZWrite Off Cull Off Fog { Mode Off }  BindChannels { Bind \"vertex\", vertex Bind \"color\", color }} } }");
			this.lineMaterial.hideFlags = HideFlags.HideAndDontSave;
			this.lineMaterial.shader.hideFlags = HideFlags.HideAndDontSave;
		}
	}

	// Token: 0x06000996 RID: 2454 RVA: 0x000C41F0 File Offset: 0x000C23F0
	public void drawlineGL(mVector totalLine)
	{
		this.lineMaterial.SetPass(0);
		GL.PushMatrix();
		GL.Begin(1);
		for (int i = 0; i < totalLine.size(); i++)
		{
			mLine mLine = (mLine)totalLine.elementAt(i);
			GL.Color(new Color(mLine.r, mLine.g, mLine.b, mLine.a));
			int num = mLine.x1 * mGraphics.zoomLevel;
			int num2 = mLine.y1 * mGraphics.zoomLevel;
			int num3 = mLine.x2 * mGraphics.zoomLevel;
			int num4 = mLine.y2 * mGraphics.zoomLevel;
			bool flag = this.isTranslate;
			if (flag)
			{
				num += this.translateX;
				num2 += this.translateY;
				num3 += this.translateX;
				num4 += this.translateY;
			}
			for (int j = 0; j < mGraphics.zoomLevel; j++)
			{
				GL.Vertex(new Vector2((float)(num + j), (float)(num2 + j)));
				GL.Vertex(new Vector2((float)(num3 + j), (float)(num4 + j)));
				bool flag2 = j > 0;
				if (flag2)
				{
					GL.Vertex(new Vector2((float)(num + j), (float)num2));
					GL.Vertex(new Vector2((float)(num3 + j), (float)num4));
					GL.Vertex(new Vector2((float)num, (float)(num2 + j)));
					GL.Vertex(new Vector2((float)num3, (float)(num4 + j)));
				}
			}
		}
		GL.End();
		GL.PopMatrix();
		totalLine.removeAllElements();
	}

	// Token: 0x06000997 RID: 2455 RVA: 0x000C43AC File Offset: 0x000C25AC
	public void drawLine(mGraphics g, int x, int y, int xTo, int yTo, int nLine, int color)
	{
		mVector mVector = new mVector();
		for (int i = 0; i < nLine; i++)
		{
			mVector.addElement(new mLine(x, y, xTo + i, yTo + i, color));
		}
		g.drawlineGL(mVector);
	}

	// Token: 0x06000998 RID: 2456 RVA: 0x000090B5 File Offset: 0x000072B5
	public void saveCanvas()
	{
	}

	// Token: 0x06000999 RID: 2457 RVA: 0x000090B5 File Offset: 0x000072B5
	public void ClipRec(int x, int i, int win, int hcur)
	{
	}

	// Token: 0x0600099A RID: 2458 RVA: 0x000090B5 File Offset: 0x000072B5
	public static void resetTransAndroid(mGraphics g2)
	{
	}

	// Token: 0x0600099B RID: 2459 RVA: 0x000090B5 File Offset: 0x000072B5
	public void restoreCanvas()
	{
	}

	// Token: 0x0600099C RID: 2460 RVA: 0x000C43F4 File Offset: 0x000C25F4
	public void fillRecAlpla(int x, int y, int w, int h, int color)
	{
		this.drawRecAlpa(0, 0, GameCanvas.loadmap.mapW * 24, y, color);
		this.drawRecAlpa(0, y, x, GameCanvas.loadmap.mapH * 24 - y, color);
		this.drawRecAlpa(x, y + h, GameCanvas.loadmap.mapW * 24 - x, GameCanvas.loadmap.mapH * 24 - (y + h), color);
		this.drawRecAlpa(x + w, y, GameCanvas.loadmap.mapW * 24 - (x + w), h, color);
		int num = 100;
		this.drawRecAlpa(0, -num, GameCanvas.loadmap.mapW * 24, num, color);
	}

	// Token: 0x0600099D RID: 2461 RVA: 0x000C22E0 File Offset: 0x000C04E0
	public void drawRecAlpa(int x, int y, int w, int h, int color)
	{
		float alpha = 0.5f;
		this.setColor(color, alpha);
		this.fillRect(x, y, w, h, false);
	}

	// Token: 0x04000F33 RID: 3891
	public const int BASELINE = 64;

	// Token: 0x04000F34 RID: 3892
	public const int SOLID = 0;

	// Token: 0x04000F35 RID: 3893
	public const int DOTTED = 1;

	// Token: 0x04000F36 RID: 3894
	public const int TRANS_MIRROR = 2;

	// Token: 0x04000F37 RID: 3895
	public const int TRANS_MIRROR_ROT180 = 1;

	// Token: 0x04000F38 RID: 3896
	public const int TRANS_MIRROR_ROT270 = 4;

	// Token: 0x04000F39 RID: 3897
	public const int TRANS_MIRROR_ROT90 = 7;

	// Token: 0x04000F3A RID: 3898
	public const int TRANS_NONE = 0;

	// Token: 0x04000F3B RID: 3899
	public const int TRANS_ROT180 = 3;

	// Token: 0x04000F3C RID: 3900
	public const int TRANS_ROT270 = 6;

	// Token: 0x04000F3D RID: 3901
	public const int TRANS_ROT90 = 5;

	// Token: 0x04000F3E RID: 3902
	public static int HCENTER = 1;

	// Token: 0x04000F3F RID: 3903
	public static int VCENTER = 2;

	// Token: 0x04000F40 RID: 3904
	public static int LEFT = 4;

	// Token: 0x04000F41 RID: 3905
	public static int RIGHT = 8;

	// Token: 0x04000F42 RID: 3906
	public static int TOP = 16;

	// Token: 0x04000F43 RID: 3907
	public static int BOTTOM = 32;

	// Token: 0x04000F44 RID: 3908
	private float r;

	// Token: 0x04000F45 RID: 3909
	private float g;

	// Token: 0x04000F46 RID: 3910
	private float b;

	// Token: 0x04000F47 RID: 3911
	private float a;

	// Token: 0x04000F48 RID: 3912
	public int clipX;

	// Token: 0x04000F49 RID: 3913
	public int clipY;

	// Token: 0x04000F4A RID: 3914
	public int clipW;

	// Token: 0x04000F4B RID: 3915
	public int clipH;

	// Token: 0x04000F4C RID: 3916
	private bool isClip;

	// Token: 0x04000F4D RID: 3917
	private bool isTranslate = true;

	// Token: 0x04000F4E RID: 3918
	private int translateX;

	// Token: 0x04000F4F RID: 3919
	private int translateY;

	// Token: 0x04000F50 RID: 3920
	private float translateXf;

	// Token: 0x04000F51 RID: 3921
	private float translateYf;

	// Token: 0x04000F52 RID: 3922
	public static int zoomLevel = 1;

	// Token: 0x04000F53 RID: 3923
	public static Hashtable cachedTextures = new Hashtable();

	// Token: 0x04000F54 RID: 3924
	public static int addYWhenOpenKeyBoard;

	// Token: 0x04000F55 RID: 3925
	private int clipTX;

	// Token: 0x04000F56 RID: 3926
	private int clipTY;

	// Token: 0x04000F57 RID: 3927
	private int currentBGColor;

	// Token: 0x04000F58 RID: 3928
	private Vector2 pos = new Vector2(0f, 0f);

	// Token: 0x04000F59 RID: 3929
	private Rect rect;

	// Token: 0x04000F5A RID: 3930
	private Matrix4x4 matrixBackup;

	// Token: 0x04000F5B RID: 3931
	private Vector2 pivot;

	// Token: 0x04000F5C RID: 3932
	public Vector2 size = new Vector2(128f, 128f);

	// Token: 0x04000F5D RID: 3933
	public Vector2 relativePosition = new Vector2(0f, 0f);

	// Token: 0x04000F5E RID: 3934
	public static Color transParentColor = new Color(1f, 1f, 1f, 0f);

	// Token: 0x04000F5F RID: 3935
	private Material lineMaterial;
}
