using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Time
{
    public int Hours { get; set; }
    public int Minutes { get; set; }
    public int Seconds { get; set; }

    public Time() { }

    public Time(int hours, int minutes, int seconds)
    {
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
        NormalizeTime();
    }

    private void NormalizeTime()
    {
        Minutes += Seconds / 60;
        Seconds %= 60;
        Hours += Minutes / 60;
        Minutes %= 60;
        Hours %= 24;
    }

    public int DifferenceInSeconds(Time other)
    {
        int thisTotalSeconds = Hours * 3600 + Minutes * 60 + Seconds;
        int otherTotalSeconds = other.Hours * 3600 + other.Minutes * 60 + other.Seconds;
        return Math.Abs(thisTotalSeconds - otherTotalSeconds);
    }

    public void AddSeconds(int seconds)
    {
        Seconds += seconds;
        NormalizeTime();
    }

    public void AddMinutes(int minutes)
    {
        Minutes += minutes;
        NormalizeTime();
    }

    public override string ToString()
    {
        return $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";
    }

    // 🔹 Метод: Зберегти список Time у JSON
    public static void SaveTimeListToJsonFile(List<Time> timeList, string filePath)
    {
        string json = JsonSerializer.Serialize(timeList, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }

    // 🔹 Метод: Зчитати список Time з JSON
    public static List<Time> LoadTimeListFromJsonFile(string filePath)
    {
        string json = File.ReadAllText(filePath);
        var timeList = JsonSerializer.Deserialize<List<Time>>(json);
        return timeList ?? new List<Time>();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        string filePath = "times.json";

        // Створюємо два об'єкти часу
        Time time1 = new Time(10, 15, 30);
        Time time2 = new Time(12, 45, 15);

        // Зберігаємо в файл
        var timeListToSave = new List<Time> { time1, time2 };
        Time.SaveTimeListToJsonFile(timeListToSave, filePath);
        Console.WriteLine("Збережено два об'єкти часу у файл JSON.\n");

        // Зчитуємо назад
        List<Time> loadedTimes = Time.LoadTimeListFromJsonFile(filePath);

        if (loadedTimes.Count >= 2)
        {
            Time loadedTime1 = loadedTimes[0];
            Time loadedTime2 = loadedTimes[1];

            Console.WriteLine($"Час 1: {loadedTime1}");
            Console.WriteLine($"Час 2: {loadedTime2}");

            int difference = loadedTime1.DifferenceInSeconds(loadedTime2);
            Console.WriteLine($"Різниця між часами в секундах: {difference}");

            loadedTime1.AddSeconds(120);
            Console.WriteLine($"Час 1 після +120 секунд: {loadedTime1}");

            loadedTime2.AddMinutes(15);
            Console.WriteLine($"Час 2 після +15 хвилин: {loadedTime2}");
        }
        else
        {
            Console.WriteLine("Не вдалося зчитати обидва об'єкти часу з файлу.");
        }
    }
}
