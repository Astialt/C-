using System;
class Program
{
    static void Main()
    {
        Console.Write("Введите значение x: ");
        double x = Convert.ToDouble(Console.ReadLine());
        double y;
        if (x < 0.1)
        {
            y = Math.Sqrt(Math.Abs(2 * Math.Pow(x, 2) + Math.Sin(x) + 1));
        }
        else if (x == 0.1)
        {
            y = 2 * x + Math.Exp(x);
        }
        else
        {
            Console.WriteLine("Функция не определена для данного значения x.");
            return;
        }

        Console.WriteLine($"Значение функции y: {y:F6}");
    }
}
