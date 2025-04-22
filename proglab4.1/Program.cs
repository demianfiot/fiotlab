using System;
using System.Collections.Generic;
using System.Linq;

public class Element
{
    public int Value { get; set; }

    public Element(int value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    public override bool Equals(object obj)
    {
        if (obj is Element el)
            return this.Value == el.Value;
        return false;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}

public class Array
{
    protected List<Element> Elements;

    public Array()
    {
        Elements = new List<Element>();
    }

    public virtual void Create(int[] values)
    {
        Elements.Clear();
        foreach (var val in values)
        {
            Elements.Add(new Element(val));
        }
    }

    public virtual void Print(string title)
    {
        Console.WriteLine(title);
        foreach (var el in Elements)
        {
            Console.Write(el + " ");
        }
        Console.WriteLine();
    }

    public override string ToString()
    {
        return string.Join(", ", Elements.Select(e => e.Value));
    }

    public override bool Equals(object obj)
    {
        if (obj is Array arr)
            return this.Elements.SequenceEqual(arr.Elements);
        return false;
    }

    public override int GetHashCode()
    {
        return Elements.Select(e => e.GetHashCode()).Aggregate(0, (acc, h) => acc ^ h);
    }
}

public class OneDimensionalArray : Array
{
    public OneDimensionalArray() : base() { }

    public OneDimensionalArray Add(OneDimensionalArray other)
    {
        var result = new OneDimensionalArray();
        int length = Math.Min(this.Elements.Count, other.Elements.Count);
        int[] sum = new int[length];
        for (int i = 0; i < length; i++)
        {
            sum[i] = this.Elements[i].Value + other.Elements[i].Value;
        }
        result.Create(sum);
        return result;
    }

    public OneDimensionalArray Subtract(OneDimensionalArray other)
    {
        var result = new OneDimensionalArray();
        int length = Math.Min(this.Elements.Count, other.Elements.Count);
        int[] diff = new int[length];
        for (int i = 0; i < length; i++)
        {
            diff[i] = this.Elements[i].Value - other.Elements[i].Value;
        }
        result.Create(diff);
        return result;
    }

    public OneDimensionalArray Multiply(OneDimensionalArray other)
    {
        var result = new OneDimensionalArray();
        int length = Math.Min(this.Elements.Count, other.Elements.Count);
        int[] prod = new int[length];
        for (int i = 0; i < length; i++)
        {
            prod[i] = this.Elements[i].Value * other.Elements[i].Value;
        }
        result.Create(prod);
        return result;
    }
}


class Program
{
    static void Main()
    {
        var array1 = new OneDimensionalArray();
        array1.Create(new int[] { 1, 2, 3 });
        array1.Print("Початковий масив 1:");

        var array2 = new OneDimensionalArray();
        array2.Create(new int[] { 4, 5, 6 });
        array2.Print("Початковий масив 2:");

        var sum = array1.Add(array2);
        sum.Print("Доданий масив:");

        var diff = array1.Subtract(array2);
        diff.Print("Віднятий масив:");

        var prod = array1.Multiply(array2);
        prod.Print("Помножений масив:");
    }
}
