using System;
class Program
{
    static void Main()
    {
        Console.Write("Введите число A (1 <= A < B <= 100): ");
        int A = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите число B (A < B <= 100): ");
        int B = Convert.ToInt32(Console.ReadLine());

        if (A >= 1 && B <= 100 && A < B)
        {
            int sum = 0;
            for (int i = A; i <= B; i++)
            {
                sum += i;
            }

            Console.WriteLine($"Сумма всех целых чисел от {A} до {B} включительно: {sum}");
        }
        else
        {
            Console.WriteLine("Ошибка: некорректный ввод чисел.");
        }
    }
}
