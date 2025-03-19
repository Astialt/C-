using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите первое число (a): ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите второе число (b): ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите третье число (c): ");
        double c = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine($"a = {a:F2}, b = {b:F2}, c = {c:F2}");
        Console.WriteLine($"({a:F2} + {b:F2}) + {c:F2} = {a:F2} + ({b:F2} + {c:F2})");

        Console.WriteLine("Для продолжения нажмите любую клавишу . . .");
        Console.ReadKey();
    }
}
