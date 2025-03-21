using System;
class Program
{
    static int SumOfDigits(int number)
    {
        if (number == 0)
            return 0;
        return (number % 10) + SumOfDigits(number / 10);
    }

    static void Main()
    {
        int number = 1234;
        Console.WriteLine($"Сумма цифр числа {number} равна: {SumOfDigits(number)}");
    }
}
