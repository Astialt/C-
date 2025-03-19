using System;
class Program
{
    static void Main()
    {
        int[][] array1 = {
            new int[] { 1, 2, 3 },
            new int[] { 4, 5 },
            new int[] { 6 }
        };

        int[][] array2 = {
            new int[] { 7, 8 },
            new int[] { 9 },
            new int[] { 10, 11, 12 }
        };

        int[][] mergedArray = new int[array1.Length + array2.Length][];
        
        for (int i = 0; i < array1.Length; i++)
        {
            mergedArray[i] = array1[i];
        }

        for (int i = 0; i < array2.Length; i++)
        {
            mergedArray[array1.Length + i] = array2[i];
        }

        Console.WriteLine("Объединённый массив:");
        foreach (var subArray in mergedArray)
        {
            Console.WriteLine(string.Join(", ", subArray));
        }
    }
}
