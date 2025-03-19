using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите число: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int hundreds = number / 100;        
        int tens = number / 10 % 10;      
        int units = number % 10;           

        int reversedNumber = units * 100 + tens * 10 + hundreds;

        Console.WriteLine($"Число, прочитанное справа налево: {reversedNumber}");
    }
}
