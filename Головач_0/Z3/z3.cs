using System;

class Program
{
    static void Main()
    {
        double[] testValues = { 5, 8, 10, 15 };

        Console.WriteLine("Результаты вычислений:");

        foreach (var b in testValues)
        {
            double z1 = Math.Sqrt(2 * b + 2 * Math.Sqrt(b * b - 4)) / (Math.Sqrt(b * b - 4) + b + 2);
            double z2 = 1 / Math.Sqrt(b + 2);

            Console.WriteLine($"b = {b}, z1 = {z1:F6}, z2 = {z2:F6}");
        }
    }
}
