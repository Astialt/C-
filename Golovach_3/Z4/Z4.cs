using Store.Models;
using Store.Services;
using System;

namespace Store
{
    class Program
    {
        static void Main()
        {
            Product[] products = new Product[]
            {
                new Product("Яблоко", "Фрукты", 1.5, 50),
                new Product("Хлеб", "Выпечка", 0.8, 0),  // Нет в наличии
                new Product("Молоко", "Молочные продукты", 1.2, 20),
                new Product("Сыр", "Молочные продукты", 3.5, 10),
                new Product("Томат", "Овощи", 1.0, 0)   // Нет в наличии
            };

            Warehouse warehouse = new Warehouse(products);

            Console.WriteLine("Все товары:");
            warehouse.DisplayAllProducts();

            Console.WriteLine("\nТовары, которых нет в наличии:");
            Product[] outOfStockProducts = warehouse.GetOutOfStockProducts();
            foreach (var product in outOfStockProducts)
            {
                Console.WriteLine($"Название: {product.Name}");
            }

       
            Product mostExpensiveProduct = warehouse.GetMostExpensiveProduct()!;
            if (mostExpensiveProduct != null)
            {
                Console.WriteLine("\nСамый дорогой товар:");
                mostExpensiveProduct.DisplayProductInfo();
            }
        }
    }
}
