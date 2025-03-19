using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите цену одного килограмма яблок (руб.): ");
        double pricePerKg = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите вес яблок (кг): ");
        double weight = Convert.ToDouble(Console.ReadLine());

        double totalCost = pricePerKg * weight;

        Console.WriteLine($"Стоимость покупки: {totalCost:F2} руб.");
    }
}
