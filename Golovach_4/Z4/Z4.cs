using System;
using System.Collections.Generic;

public static class ListExtensions
{
    public static double Median(this List<int> numbers)
    {
        if (numbers == null || numbers.Count == 0)
        {
            throw new InvalidOperationException("Список пуст или null.");
        }

        for (int i = 0; i < numbers.Count - 1; i++)
        {
            for (int j = i + 1; j < numbers.Count; j++)
            {
                if (numbers[i] > numbers[j])
                {
                    int temp = numbers[i];
                    numbers[i] = numbers[j];
                    numbers[j] = temp;
                }
            }
        }

        int count = numbers.Count;
        int middle = count / 2;

        if (count % 2 != 0)
        {
            return numbers[middle];
        }
        return (numbers[middle - 1] + numbers[middle]) / 2.0;
    }
}

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int> { 3, 1, 4, 1, 5, 9 };

        double median = numbers.Median();

        Console.WriteLine($"Медиана: {median}");
    }
}
