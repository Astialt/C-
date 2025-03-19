using System;
class Program
{
    static void Main()
    {
        double[] numbers = { -3.2, 4.1, -7.5, 2.0, -1.1, 6.3, 0 };
        int negativeCount = 0;
        
        foreach (double number in numbers)
        {
            if (number < 0)
            {
                negativeCount++;
            }
        }
        Console.WriteLine($"Количество отрицательных элементов в массиве: {negativeCount}");
    }
}
