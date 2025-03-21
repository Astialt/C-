using System;
class Program
{
    static void InvDigits(ref int K)
    {
        char[] digits = K.ToString().ToCharArray();
        Array.Reverse(digits);
        K = int.Parse(new string(digits));
    }
    static void Main()
    {
        int[] numbers = { 12345, 6789, 102, 4005, 7890 };

        Console.WriteLine("Исходные числа:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }

        for (int i = 0; i < numbers.Length; i++)
        {
            InvDigits(ref numbers[i]);
        }

        Console.WriteLine("\nЧисла после изменения порядка цифр:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}
