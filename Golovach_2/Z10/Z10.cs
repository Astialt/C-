using System;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        Console.Write("Введите строку: ");
        string input = Console.ReadLine()!;
        string pattern = @"\b\d{3}[-.\s]?\d{3}[-.\s]?\d{4}\b"; 
       
        MatchCollection matches = Regex.Matches(input, pattern);

        Console.WriteLine("\nНайденные номера телефонов:");
        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
        }
        if (matches.Count == 0)
        {
            Console.WriteLine("Номеров телефонов не найдено.");
        }
    }
}
