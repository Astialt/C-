using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите трехзначное число: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int hundreds = number / 100;        
        int tens = number / 10 % 10;      
        int units = number % 10;           

        int newNumber = tens * 100 + hundreds * 10 + units;

        Console.WriteLine($"Число с перестановкой первой и второй цифр: {newNumber}");
    }
}
