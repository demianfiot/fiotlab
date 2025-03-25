using System;

class Time
{
    public int Hours { get; set; }
    public int Minutes { get; set; }
    public int Seconds { get; set; }

    public Time(int hours, int minutes, int seconds)
    {
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
        NormalizeTime();
    }

    // Метод для нормалізації часу (переведення зайвих секунд і хвилин)
    private void NormalizeTime()
    {
        Minutes += Seconds / 60;
        Seconds %= 60;
        Hours += Minutes / 60;
        Minutes %= 60;
        Hours %= 24; // Обмежуємо години до 24
    }

    // Метод для обчислення різниці в секундах між двома об'єктами
    public int DifferenceInSeconds(Time other)
    {
        int thisTotalSeconds = Hours * 3600 + Minutes * 60 + Seconds;
        int otherTotalSeconds = other.Hours * 3600 + other.Minutes * 60 + other.Seconds;
        return Math.Abs(thisTotalSeconds - otherTotalSeconds);
    }

    // Метод для зміщення часу на задану кількість секунд
    public void AddSeconds(int seconds)
    {
        Seconds += seconds;
        NormalizeTime();
    }

    // Метод для зміщення часу на задану кількість хвилин
    public void AddMinutes(int minutes)
    {
        Minutes += minutes;
        NormalizeTime();
    }

    // Вивід часу у форматі HH:MM:SS
    public override string ToString()
    {
        return $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";
    }
}

class Program
{
    static void Main()
    {
        Time time1 = new Time(12, 30, 45);
        Time time2 = new Time(14, 45, 30);

        Console.WriteLine($"Час 1: {time1}");
        Console.WriteLine($"Час 2: {time2}");
        Console.WriteLine($"Різниця в секундах: {time1.DifferenceInSeconds(time2)}");

        time1.AddSeconds(500);
        Console.WriteLine($"Час 1 після додавання 500 секунд: {time1}");

        time2.AddMinutes(20);
        Console.WriteLine($"Час 2 після додавання 20 хвилин: {time2}");
    }
}
