using System;

public static class MathOperations
{
    public static double Sum(double[] numbers)
    {
        double sum = 0;
        foreach (double number in numbers)
        {
            sum += number; 
        }
        return sum;
    }
}

class Program
{
    static void Main()
    {
        
        double[] numbers = { 1.2, 2.5, 3.8, 4.4, 5.1 };

        double result = MathOperations.Sum(numbers);

        Console.WriteLine($"Сумма чисел в массиве: {result}");
    }
}
