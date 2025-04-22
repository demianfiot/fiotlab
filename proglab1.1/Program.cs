using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int> { -3, 5, -1, 7, -6, 2, -8, 4 };
        Console.WriteLine("Початковий список:");
        PrintList(numbers);
        
        sort(numbers);
        
        Console.WriteLine("Список після перестановки:");
        PrintList(numbers);
    }

    static void sort(List<int> list)
    {
        int index = 0; 

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] >= 0)
            {
                (list[i], list[index]) = (list[index], list[i]);
                index++;
            }
        }

    }

    static void PrintList(List<int> list)
    {
        Console.WriteLine(string.Join(", ", list));
    }
}
