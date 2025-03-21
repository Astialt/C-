using System;
public static class ArrayUtilities
{
    public static void SortAscending(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i] > array[j])
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }
    }
}

class Program
{
    static void Main()
    {
        int[] numbers = { 5, 2, 9, 1, 5, 6 };

        Console.WriteLine("Исходный массив:");
        Console.WriteLine(string.Join(", ", numbers));

        ArrayUtilities.SortAscending(numbers);

        Console.WriteLine("Отсортированный массив по возрастанию:");
        Console.WriteLine(string.Join(", ", numbers));
    }
}
