using System;

class Program
{
    static void Main()
    {
        // Ввод строки
        Console.Write("Введите строку: ");
        string input = Console.ReadLine()!;

        bool isSingleCase = IsSingleCase(input);

        if (isSingleCase)
        {
            Console.WriteLine("Строка содержит только буквы одного регистра.");
        }
        else
        {
            Console.WriteLine("Строка содержит буквы разного регистра.");
        }
    }

    static bool IsSingleCase(string str)
    {
        bool isAllUpper = true;
        bool isAllLower = true;

        foreach (char c in str)
        {
            if (char.IsLetter(c))
            {
                if (char.IsUpper(c))
                {
                    isAllLower = false; 
                }
                else if (char.IsLower(c))
                {
                    isAllUpper = false; 
                }
            }
        }

        return isAllUpper || isAllLower;
    }
}
