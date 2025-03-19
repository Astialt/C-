using System;
class Program
{
    static void Main()
    {
        Console.Write("Введите число: ");
        int number = Convert.ToInt32(Console.ReadLine());

        bool isAscending = true;
        int lastDigit = number % 10;
        number /= 10;

        while (number > 0)
        {
            int currentDigit = number % 10;
            if (currentDigit < lastDigit)
            {
                isAscending = false;
                break;
            }
            lastDigit = currentDigit;
            number /= 10;
        }

        if (isAscending)
        {
            Console.WriteLine("Цифры числа упорядочены по возрастанию справа налево.");
        }
        else
        {
            Console.WriteLine("Цифры числа не упорядочены по возрастанию справа налево.");
        }
    }
}
