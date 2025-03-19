using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите размер матрицы (N, где N < 10): ");
        int N = Convert.ToInt32(Console.ReadLine());
        if (N >= 10)
        {
            Console.WriteLine("Размер матрицы должен быть меньше 10.");
            return;
        }

        Console.Write("Введите минимальное значение (a): ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите максимальное значение (b): ");
        int b = Convert.ToInt32(Console.ReadLine());
        if (a > b)
        {
            Console.WriteLine("Значение a должно быть меньше или равно b.");
            return;
        }

        int[,] matrix = new int[N, N];
        Random random = new Random();

        Console.WriteLine("\nИсходная матрица:");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                matrix[i, j] = random.Next(a, b + 1);
                Console.Write($"{matrix[i, j],5}"); 
            }
            Console.WriteLine();
        }

        int evenSum = 0;
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (matrix[i, j] % 2 == 0)
                {
                    evenSum += matrix[i, j];
                }
            }
        }
        Console.WriteLine($"\nСумма чётных элементов: {evenSum}");

        Console.WriteLine("\nКоличество положительных элементов в каждом столбце:");
        for (int j = 0; j < N; j++)
        {
            int positiveCount = 0;
            for (int i = 0; i < N; i++)
            {
                if (matrix[i, j] > 0)
                {
                    positiveCount++;
                }
            }
            Console.WriteLine($"Столбец {j + 1}: {positiveCount}");
        }
    }
}
