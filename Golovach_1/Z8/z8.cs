using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите число K (1 <= K <= 100): ");
        int K = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите число N (1 <= N <= 100): ");
        int N = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < N; i++)
        {
            Console.WriteLine(K);
        }
    }
}
