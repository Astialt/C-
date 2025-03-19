using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите первое число: ");
        int a = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Введите второе число: ");
        int b = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Введите третье число: ");
        int c = Convert.ToInt32(Console.ReadLine());

        bool hasPair = (a == b) || (a == c) || (b == c);

        Console.WriteLine(hasPair ? "Высказывание истинно: есть хотя бы одна пара совпадающих чисел." 
                                  : "Высказывание ложно: совпадающих чисел нет.");
    }
}
