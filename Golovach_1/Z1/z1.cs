using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество секунд с начала суток: ");
        int seconds = Convert.ToInt32(Console.ReadLine());

        int fullHours = seconds / 3600;

        Console.WriteLine($"Полных часов прошло с начала суток: {fullHours}");
    }
}
