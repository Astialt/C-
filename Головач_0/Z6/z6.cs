using System;

class Program
{
    static void Main()
    {
        double x = 6.4;

        double term1 = Math.Exp(x) / Math.Cos(Math.Sqrt(x - 1));
        double term2 = 2 * Math.Atan(x * x) / (1 - x);

        double y = term1 + term2;

        Console.WriteLine($"Значение функции для x = {x:F1} равно: {y:F6}");
    }
}
