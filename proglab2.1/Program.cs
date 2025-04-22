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

<<<<<<< HEAD

=======
    // Метод для нормалізації часу (переведення зайвих секунд і хвилин)
>>>>>>> 04d8897be827d41680fce0245f8fc531103d1da4
    private void NormalizeTime()
    {
        Minutes += Seconds / 60;
        Seconds %= 60;
        Hours += Minutes / 60;
        Minutes %= 60;
<<<<<<< HEAD
        Hours %= 24;
    }


    public static int DifferenceBetween(Time t1, Time t2)
    {
        int t1Seconds = t1.Hours * 3600 + t1.Minutes * 60 + t1.Seconds;
        int t2Seconds = t2.Hours * 3600 + t2.Minutes * 60 + t2.Seconds;
        return Math.Abs(t1Seconds - t2Seconds);
    }

=======
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
>>>>>>> 04d8897be827d41680fce0245f8fc531103d1da4
    public void AddSeconds(int seconds)
    {
        Seconds += seconds;
        NormalizeTime();
    }

<<<<<<< HEAD
=======
    // Метод для зміщення часу на задану кількість хвилин
>>>>>>> 04d8897be827d41680fce0245f8fc531103d1da4
    public void AddMinutes(int minutes)
    {
        Minutes += minutes;
        NormalizeTime();
    }

<<<<<<< HEAD
    public string FormatTime()
=======
    // Вивід часу у форматі HH:MM:SS
    public override string ToString()
>>>>>>> 04d8897be827d41680fce0245f8fc531103d1da4
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

<<<<<<< HEAD
        Console.WriteLine($"Час 1: {time1.FormatTime()}");
        Console.WriteLine($"Час 2: {time2.FormatTime()}");
        Console.WriteLine($"Різниця в секундах: {Time.DifferenceBetween(time1, time2)}");

        time1.AddSeconds(500);
        Console.WriteLine($"Час 1 після додавання 500 секунд: {time1.FormatTime()}");

        time2.AddMinutes(20);
        Console.WriteLine($"Час 2 після додавання 20 хвилин: {time2.FormatTime()}");
=======
        Console.WriteLine($"Час 1: {time1}");
        Console.WriteLine($"Час 2: {time2}");
        Console.WriteLine($"Різниця в секундах: {time1.DifferenceInSeconds(time2)}");

        time1.AddSeconds(500);
        Console.WriteLine($"Час 1 після додавання 500 секунд: {time1}");

        time2.AddMinutes(20);
        Console.WriteLine($"Час 2 після додавання 20 хвилин: {time2}");
>>>>>>> 04d8897be827d41680fce0245f8fc531103d1da4
    }
}
