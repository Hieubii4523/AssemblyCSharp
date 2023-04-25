using System;
using System.Collections;

// Token: 0x020000B3 RID: 179
public class MyHashTable
{
	// Token: 0x06000AD2 RID: 2770 RVA: 0x0000B653 File Offset: 0x00009853
	public MyHashTable()
	{
		this.h = new Hashtable();
	}

	// Token: 0x06000AD3 RID: 2771 RVA: 0x0000B67E File Offset: 0x0000987E
	public MyHashTable(string strlink)
	{
		this.h = new Hashtable();
		this.linkImage = strlink;
	}

	// Token: 0x06000AD4 RID: 2772 RVA: 0x000D6FBC File Offset: 0x000D51BC
	public object get(object k)
	{
		return this.h[k];
	}

	// Token: 0x06000AD5 RID: 2773 RVA: 0x0000B6B0 File Offset: 0x000098B0
	public void clear()
	{
		this.h.Clear();
	}

	// Token: 0x06000AD6 RID: 2774 RVA: 0x000D6FDC File Offset: 0x000D51DC
	public IDictionaryEnumerator GetEnumerator()
	{
		return this.h.GetEnumerator();
	}

	// Token: 0x06000AD7 RID: 2775 RVA: 0x000D6FFC File Offset: 0x000D51FC
	public int size()
	{
		return this.h.Count;
	}

	// Token: 0x06000AD8 RID: 2776 RVA: 0x000D701C File Offset: 0x000D521C
	public void put(object k, object v)
	{
		bool flag = this.h.ContainsKey(k);
		if (flag)
		{
			this.h.Remove(k);
		}
		this.h.Add(k, v);
	}

	// Token: 0x06000AD9 RID: 2777 RVA: 0x0000B6BF File Offset: 0x000098BF
	public void remove(object k)
	{
		this.h.Remove(k);
	}

	// Token: 0x06000ADA RID: 2778 RVA: 0x0000B6BF File Offset: 0x000098BF
	public void Remove(string key)
	{
		this.h.Remove(key);
	}

	// Token: 0x06000ADB RID: 2779 RVA: 0x000D7058 File Offset: 0x000D5258
	public bool containsKey(object key)
	{
		return this.h.ContainsKey(key);
	}

	// Token: 0x040010A3 RID: 4259
	public Hashtable h = new Hashtable();

	// Token: 0x040010A4 RID: 4260
	public string linkImage = string.Empty;
}
