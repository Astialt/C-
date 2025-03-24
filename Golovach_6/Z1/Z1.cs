using System;

public delegate int[] SortMethod(int[] array);

public class BubbleSort
{
    public int[] Sort(int[] array)
    {
        int n = array.Length;
        int[] result = (int[])array.Clone(); 

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (result[j] > result[j + 1])
                {
                    int temp = result[j];
                    result[j] = result[j + 1];
                    result[j + 1] = temp;
                }
            }
        }
        return result;
    }
}

public class QuickSort
{
    public int[] Sort(int[] array)
    {
        int[] result = (int[])array.Clone();
        QuickSortRecursive(result, 0, result.Length - 1);
        return result;
    }

    private void QuickSortRecursive(int[] array, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(array, left, right);

            QuickSortRecursive(array, left, pivotIndex - 1);
            QuickSortRecursive(array, pivotIndex + 1, right);
        }
    }

    private int Partition(int[] array, int left, int right)
    {
        int pivot = array[right];
        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            if (array[j] <= pivot)
            {
                i++;
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        int temp2 = array[i + 1];
        array[i + 1] = array[right];
        array[right] = temp2;

        return i + 1;
    }
}

class Program
{
    static void Main()
    {
    
        int[] array = { 5, 2, 9, 1, 5, 6 };

        BubbleSort bubbleSort = new BubbleSort();
        QuickSort quickSort = new QuickSort();


        SortMethod sortMethod;

        sortMethod = bubbleSort.Sort;
        int[] bubbleSortedArray = sortMethod(array);
        Console.WriteLine("Пузырьковая сортировка:");
        Console.WriteLine(string.Join(", ", bubbleSortedArray));

        sortMethod = quickSort.Sort;
        int[] quickSortedArray = sortMethod(array);
        Console.WriteLine("Быстрая сортировка:");
        Console.WriteLine(string.Join(", ", quickSortedArray));
    }
}
