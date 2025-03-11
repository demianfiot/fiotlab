using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] numbers = { 123, 456, 789, 321, 654 };
        
        double productOfLastDigits = numbers
            .Select(n => n % 10) 
            .Aggregate(1.0, (acc, digit) => acc * digit); 
        
        Console.WriteLine("Твір останніх цифр всіх елементів послідовності: " + productOfLastDigits);
    }
}
