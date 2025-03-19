using System;
class Program
{
    static void Main()
    {
        Console.Write("Введите строку: ");
        string input = Console.ReadLine()!;

        Console.Write("Введите префикс: ");
        string prefix = Console.ReadLine()!;

        if (input.StartsWith(prefix))
        {
            Console.WriteLine($"Строка начинается с префикса \"{prefix}\".");
        }
        else
        {
            Console.WriteLine($"Строка не начинается с префикса \"{prefix}\".");
        }
    }
}
