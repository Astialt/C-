using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Таблица перевода (while):");
        int inchesWhile = 2;
        while (inchesWhile <= 24)
        {
            double cm = inchesWhile * 25.4;
            Console.WriteLine($"{inchesWhile} дюймов = {cm:F2} сантиметров");
            inchesWhile += 2;
        }

        Console.WriteLine("\nТаблица перевода (do while):");
        int inchesDoWhile = 2;
        do
        {
            double cm = inchesDoWhile * 25.4;
            Console.WriteLine($"{inchesDoWhile} дюймов = {cm:F2} сантиметров");
            inchesDoWhile += 2;
        } while (inchesDoWhile <= 24);

        Console.WriteLine("\nТаблица перевода (for):");
        for (int inchesFor = 2; inchesFor <= 24; inchesFor += 2)
        {
            double cm = inchesFor * 25.4;
            Console.WriteLine($"{inchesFor} дюймов = {cm:F2} сантиметров");
        }
    }
}
