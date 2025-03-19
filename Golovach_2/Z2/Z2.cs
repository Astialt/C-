using System;
class Program
{
    static void Main()
    {
        int[] numbers = new int[100];
        Random random = new Random();

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = random.Next(1, 101); 
        }
        Console.WriteLine("Массив в обратном порядке (по 6 чисел в строке):");
        for (int i = numbers.Length - 1; i >= 0; i--)
        {
            Console.Write($"{numbers[i],5}");
            if ((numbers.Length - i) % 6 == 0) 
            {
                Console.WriteLine();
            }
        }
        Array.Sort(numbers);

        Console.WriteLine("\nОтсортированный массив:");
        Console.WriteLine(string.Join(", ", numbers));

        Console.Write("\nВведите число k для поиска: ");
        int k = Convert.ToInt32(Console.ReadLine());
        int index = Array.BinarySearch(numbers, k);

        if (index >= 0)
        {
            Console.WriteLine($"Число {k} найдено в массиве на позиции {index + 1} (индекс {index}).");
        }
        else
        {
            Console.WriteLine($"Число {k} не найдено в массиве.");
        }
    }
}
