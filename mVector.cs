using System;
using System.Collections;

// Token: 0x020000B1 RID: 177
public class mVector
{
	// Token: 0x06000ABF RID: 2751 RVA: 0x0000B5A7 File Offset: 0x000097A7
	public mVector()
	{
		this.a = new ArrayList();
	}

	// Token: 0x06000AC0 RID: 2752 RVA: 0x0000B5A7 File Offset: 0x000097A7
	public mVector(string s)
	{
		this.a = new ArrayList();
	}

	// Token: 0x06000AC1 RID: 2753 RVA: 0x0000B5BC File Offset: 0x000097BC
	public mVector(ArrayList a)
	{
		this.a = a;
	}

	// Token: 0x06000AC2 RID: 2754 RVA: 0x0000B5CD File Offset: 0x000097CD
	public void addElement(object o)
	{
		this.a.Add(o);
	}

	// Token: 0x06000AC3 RID: 2755 RVA: 0x000D6E14 File Offset: 0x000D5014
	public bool contains(object o)
	{
		return this.a.Contains(o);
	}

	// Token: 0x06000AC4 RID: 2756 RVA: 0x000D6E3C File Offset: 0x000D503C
	public int size()
	{
		bool flag = this.a == null;
		int result;
		if (flag)
		{
			result = 0;
		}
		else
		{
			result = this.a.Count;
		}
		return result;
	}

	// Token: 0x06000AC5 RID: 2757 RVA: 0x000D6E6C File Offset: 0x000D506C
	public object elementAt(int index)
	{
		bool flag = index > -1 && index < this.a.Count;
		object result;
		if (flag)
		{
			result = this.a[index];
		}
		else
		{
			result = null;
		}
		return result;
	}

	// Token: 0x06000AC6 RID: 2758 RVA: 0x000D6EA8 File Offset: 0x000D50A8
	public void set(int index, object obj)
	{
		bool flag = index > -1 && index < this.a.Count;
		if (flag)
		{
			this.a[index] = obj;
		}
	}

	// Token: 0x06000AC7 RID: 2759 RVA: 0x000D6EE0 File Offset: 0x000D50E0
	public void setElementAt(object obj, int index)
	{
		bool flag = index > -1 && index < this.a.Count;
		if (flag)
		{
			this.a[index] = obj;
		}
	}

	// Token: 0x06000AC8 RID: 2760 RVA: 0x000D6F18 File Offset: 0x000D5118
	public int indexOf(object o)
	{
		return this.a.IndexOf(o);
	}

	// Token: 0x06000AC9 RID: 2761 RVA: 0x000D6F38 File Offset: 0x000D5138
	public void removeElementAt(int index)
	{
		bool flag = index > -1 && index < this.a.Count;
		if (flag)
		{
			this.a.RemoveAt(index);
		}
	}

	// Token: 0x06000ACA RID: 2762 RVA: 0x0000B5DD File Offset: 0x000097DD
	public void removeElement(object o)
	{
		this.a.Remove(o);
	}

	// Token: 0x06000ACB RID: 2763 RVA: 0x0000B5ED File Offset: 0x000097ED
	public void removeAllElements()
	{
		this.a.Clear();
	}

	// Token: 0x06000ACC RID: 2764 RVA: 0x0000B5FC File Offset: 0x000097FC
	public void insertElementAt(object o, int i)
	{
		this.a.Insert(i, o);
	}

	// Token: 0x06000ACD RID: 2765 RVA: 0x000D6F70 File Offset: 0x000D5170
	public object firstElement()
	{
		return this.a[0];
	}

	// Token: 0x06000ACE RID: 2766 RVA: 0x000D6F90 File Offset: 0x000D5190
	public object lastElement()
	{
		return this.a[this.a.Count - 1];
	}

	// Token: 0x0400109F RID: 4255
	private ArrayList a;
}
