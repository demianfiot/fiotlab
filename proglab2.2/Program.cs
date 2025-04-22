using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Time
{
    public int Hours { get; set; }
    public int Minutes { get; set; }
    public int Seconds { get; set; }

<<<<<<< HEAD

=======
    public Time() { }
>>>>>>> 04d8897be827d41680fce0245f8fc531103d1da4

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

<<<<<<< HEAD
    public static int DifferenceBetween(Time t1, Time t2)
    {
        int t1Seconds = t1.Hours * 3600 + t1.Minutes * 60 + t1.Seconds;
        int t2Seconds = t2.Hours * 3600 + t2.Minutes * 60 + t2.Seconds;
        return Math.Abs(t1Seconds - t2Seconds);
    }
=======
    public int DifferenceInSeconds(Time other)
    {
        int thisTotalSeconds = Hours * 3600 + Minutes * 60 + Seconds;
        int otherTotalSeconds = other.Hours * 3600 + other.Minutes * 60 + other.Seconds;
        return Math.Abs(thisTotalSeconds - otherTotalSeconds);
    }

>>>>>>> 04d8897be827d41680fce0245f8fc531103d1da4
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

<<<<<<< HEAD

=======
    // 🔹 Метод: Зберегти список Time у JSON
>>>>>>> 04d8897be827d41680fce0245f8fc531103d1da4
    public static void SaveTimeListToJsonFile(List<Time> timeList, string filePath)
    {
        string json = JsonSerializer.Serialize(timeList, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }

<<<<<<< HEAD

=======
    // 🔹 Метод: Зчитати список Time з JSON
>>>>>>> 04d8897be827d41680fce0245f8fc531103d1da4
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

<<<<<<< HEAD
        Time time1 = new Time(10, 15, 30);
        Time time2 = new Time(12, 45, 15);

=======
        // Створюємо два об'єкти часу
        Time time1 = new Time(10, 15, 30);
        Time time2 = new Time(12, 45, 15);

        // Зберігаємо в файл
>>>>>>> 04d8897be827d41680fce0245f8fc531103d1da4
        var timeListToSave = new List<Time> { time1, time2 };
        Time.SaveTimeListToJsonFile(timeListToSave, filePath);
        Console.WriteLine("Збережено два об'єкти часу у файл JSON.\n");

<<<<<<< HEAD
=======
        // Зчитуємо назад
>>>>>>> 04d8897be827d41680fce0245f8fc531103d1da4
        List<Time> loadedTimes = Time.LoadTimeListFromJsonFile(filePath);

        if (loadedTimes.Count >= 2)
        {
            Time loadedTime1 = loadedTimes[0];
            Time loadedTime2 = loadedTimes[1];

            Console.WriteLine($"Час 1: {loadedTime1}");
            Console.WriteLine($"Час 2: {loadedTime2}");

<<<<<<< HEAD
            int difference = Time.DifferenceBetween(loadedTime1, loadedTime2);
            Console.WriteLine($"Різниця в секундах: {difference}");

=======
            int difference = loadedTime1.DifferenceInSeconds(loadedTime2);
            Console.WriteLine($"Різниця між часами в секундах: {difference}");
>>>>>>> 04d8897be827d41680fce0245f8fc531103d1da4

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
