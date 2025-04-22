using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main()
    {
        Dictionary<string, List<int>> numbersDict = new Dictionary<string, List<int>>
        {
            { "A", new List<int> { 1, 2, 3 } },
            { "B", new List<int> { 4, 5, 6 } },
            { "C", new List<int> { 7, 8, 9 } }
        };
        
        Console.WriteLine("Початковий словник:");
        PrintDictionary(numbersDict);
        
        Dictionary<string, int> summedDict = SumDictionaryValues(numbersDict);
        
        Console.WriteLine("Словник після заміни значень на їхню суму:");
        PrintDictionary(summedDict);
        
        SaveToJson(summedDict, "result.json");
        Console.WriteLine("Результат збережено у result.json");
    }

    static Dictionary<string, int> SumDictionaryValues(Dictionary<string, List<int>> dict)
    {
        Dictionary<string, int> result = new Dictionary<string, int>();
        foreach (var pair in dict)
        {
            result[pair.Key] = pair.Value.Sum();
        }
        return result;
    }

    static void SaveToJson(Dictionary<string, int> dict, string filePath)
    {
        string json = JsonSerializer.Serialize(dict, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }
    static void PrintDictionary<T>(Dictionary<string, T> dict)
    {
        foreach (var pair in dict)
        {
            if (pair.Value is List<int> list)
                Console.WriteLine($"{pair.Key}: [{string.Join(", ", list)}]");
            else
                Console.WriteLine($"{pair.Key}: {pair.Value}"); 
        }
    }

}
