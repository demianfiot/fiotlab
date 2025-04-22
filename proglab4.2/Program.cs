using System;
using System.Collections.Generic;
using System.Linq;


public abstract class Flower
{
    public string Name { get; }
    public double Price { get; }
    public int FreshnessLevel { get; } 
        public double StemLength { get; }

    protected Flower(string name, double price, int freshnessLevel, double stemLength)
    {
        Name = name;
        Price = price;
        FreshnessLevel = freshnessLevel;
        StemLength = stemLength;
    }

    public override string ToString()
    {
        return $"{Name} | Ціна: {Price} грн | Свіжість: {FreshnessLevel} | Довжина стебла: {StemLength} см";
    }
}


public class Rose : Flower
{
    public string Color { get; }

    public Rose(string color, double price, int freshness, double stemLength)
        : base("Троянда", price, freshness, stemLength)
    {
        Color = color;
    }

    public override string ToString()
    {
        return base.ToString() + $" | Колір: {Color}";
    }
}

public class Chamomile : Flower
{
    public string Color { get; }

    public Chamomile(string color, double price, int freshness, double stemLength)
        : base("Ромашка", price, freshness, stemLength)
    {
        Color = color;
    }

    public override string ToString()
    {
        return base.ToString() + $" | Колір: {Color}";
    }
}

public class Accessory
{
    public string Name { get; }
    public double Price { get; }

    public Accessory(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public override string ToString()
    {
        return $"{Name} (вартість: {Price} грн)";
    }
}

public class Bouquet
{
    private List<Flower> flowers = new List<Flower>();
    public List<Flower> Flowers { get { return flowers; } }

    private List<Accessory> accessories = new List<Accessory>();
    public List<Accessory> Accessories { get { return accessories; } }

    public void AddFlower(Flower flower) { flowers.Add(flower); }
    public void AddAccessory(Accessory accessory) { accessories.Add(accessory); }

    public double GetTotalPrice()
    {
        double flowerSum = flowers.Sum(f => f.Price);
        double accessorySum = accessories.Sum(a => a.Price);
        return flowerSum + accessorySum;
    }

    public void SortByFreshness()
    {
        flowers.Sort((a, b) => a.FreshnessLevel.CompareTo(b.FreshnessLevel));
    }

    public Flower FindByStemLength(double min, double max)
    {
        return flowers.FirstOrDefault(f => f.StemLength >= min && f.StemLength <= max);
    }

    public void PrintBouquet()
    {
        Console.WriteLine("Букет складається з:");
        foreach (var flower in flowers)
            Console.WriteLine($"- {flower}");
        foreach (var accessory in accessories)
            Console.WriteLine($"- аксесуар: {accessory}");

        Console.WriteLine($"Загальна вартість: {GetTotalPrice()} грн");
    }
}

class Program
{
    static void Main()
    {
        var bouquet = new Bouquet();

       
        bouquet.AddFlower(new Rose("Червоний", 50, 2, 40));
        bouquet.AddFlower(new Chamomile("Білий", 25, 4, 35));
        bouquet.AddFlower(new Rose("Рожевий", 45, 1, 38));

      
        bouquet.AddAccessory(new Accessory("Стрічка", 10));
        bouquet.AddAccessory(new Accessory("Упаковка", 15));

        bouquet.PrintBouquet();

        Console.WriteLine("\nВідсортовано за свіжістю:");
        bouquet.SortByFreshness();
        bouquet.PrintBouquet();

        Console.WriteLine("\nВведіть діапазон довжини стебла для пошуку квітки:");
        Console.Write("Мінімум (см): ");
        double min = Convert.ToDouble(Console.ReadLine());
        Console.Write("Максимум (см): ");
        double max = Convert.ToDouble(Console.ReadLine());

        var found = bouquet.FindByStemLength(min, max);
        Console.WriteLine(found != null ? "\nЗнайдено квітку:\n" + found.ToString() : "Квітку не знайдено в заданому діапазоні.");
    }
}
