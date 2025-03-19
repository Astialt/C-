using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите длину прямоугольника (a): ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите ширину прямоугольника (b): ");
        double b = Convert.ToDouble(Console.ReadLine());

        double perimeter = 2 * (a + b);
        double area = a * b;
        double diagonal = Math.Sqrt(a * a + b * b);

        Console.WriteLine($"Периметр P: {perimeter:F2}");
        Console.WriteLine($"Площадь S: {area:F2}");
        Console.WriteLine($"Длина диагонали: {diagonal:F2}");
    }
}
