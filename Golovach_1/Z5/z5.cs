using System;
class Program
{
    static void Main()
    {
        Console.Write("Введите четырехзначное число: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int firstDigit = number / 1000;          
        int secondDigit = number / 100 % 10;    

        if (firstDigit > secondDigit)
        {
            Console.WriteLine($"Первая цифра ({firstDigit}) больше второй цифры ({secondDigit}).");
        }
        else if (firstDigit < secondDigit)
        {
            Console.WriteLine($"Вторая цифра ({secondDigit}) больше первой цифры ({firstDigit}).");
        }
        else
        {
            Console.WriteLine($"Первая цифра ({firstDigit}) равна второй цифре ({secondDigit}).");
        }
    }
}
