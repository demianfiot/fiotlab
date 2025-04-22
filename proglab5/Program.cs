using System;
using System.Collections.Generic;
using System.Linq;

// Інтерфейс для запуску
interface IExecutable
{
    void Execute();
}

// Абстрактний клас Диск
abstract class DiskObject
{
    public string Name { get; set; }
    public double SizeMB { get; set; } // Розмір в МБ
    public DiskObject(string name, double sizeMB)
    {
        Name = name;
        SizeMB = sizeMB;
    }

    public abstract void ShowInfo();
}

// Базовий клас Файл
abstract class File : DiskObject, IExecutable
{
    public File(string name, double sizeMB) : base(name, sizeMB) { }

    public virtual void Execute()
    {
        Console.WriteLine($"Файл {Name} запущено.");
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Файл: {Name}, Розмір: {SizeMB} МБ");
    }
}

// Клас Mp3-файл
class Mp3 : File
{
    public string Artist { get; set; }

    public Mp3(string name, double sizeMB, string artist) : base(name, sizeMB)
    {
        Artist = artist;
    }

    public override void Execute()
    {
        Console.WriteLine($"Відтворення MP3: {Name} - Виконавець: {Artist}");
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"MP3: {Name}, Виконавець: {Artist}, Розмір: {SizeMB} МБ");
    }
}

// Текстовий файл
class TextFile : File
{
    public int WordCount { get; set; }

    public TextFile(string name, double sizeMB, int wordCount) : base(name, sizeMB)
    {
        WordCount = wordCount;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Текстовий файл: {Name}, Слів: {WordCount}, Розмір: {SizeMB} МБ");
    }
}

// Архів
class Archive : File
{
    public int FileCount { get; set; }

    public Archive(string name, double sizeMB, int fileCount) : base(name, sizeMB)
    {
        FileCount = fileCount;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Архів: {Name}, Кількість файлів: {FileCount}, Розмір: {SizeMB} МБ");
    }
}

// Директорія
class Directory : DiskObject
{
    public List<DiskObject> Contents { get; private set; }

    public Directory(string name) : base(name, 0)
    {
        Contents = new List<DiskObject>();
    }

    public void Add(DiskObject obj)
    {
        Contents.Add(obj);
        SizeMB += obj.SizeMB;
    }

    public int CountMp3Files()
    {
        return Contents.OfType<Mp3>().Count();
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Директорія: {Name}, Розмір: {SizeMB} МБ");
        Console.WriteLine("Містить:");
        foreach (var obj in Contents)
        {
            obj.ShowInfo();
        }
        Console.WriteLine($"Кількість MP3-файлів: {CountMp3Files()}");
    }
}

// Тестова програма
class Program
{
    static void Main()
    {
        Directory root = new Directory("Моя директорія");

        root.Add(new Mp3("Пісня1", 4.5, "Artist1"));
        root.Add(new Mp3("Пісня2", 5.2, "Artist2"));
        root.Add(new TextFile("Документ", 1.1, 350));
        root.Add(new Archive("Архів.zip", 15.0, 5));

        root.ShowInfo();

        Console.WriteLine("\nСимуляція запуску файлів:");
        foreach (var obj in root.Contents)
        {
            if (obj is IExecutable exe)
                exe.Execute();
        }
    }
}
