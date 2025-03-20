using Store.Models;
using System;

namespace Store.Services
{
    public class Warehouse
    {
        private Product[] products;

        public Warehouse(Product[] products)
        {
            this.products = products;
        }

        public Product[] GetOutOfStockProducts()
        {
            int count = 0;

            foreach (var product in products)
            {
                if (product.Stock == 0)
                    count++;
            }

            Product[] outOfStock = new Product[count];
            int index = 0;

            foreach (var product in products)
            {
                if (product.Stock == 0)
                {
                    outOfStock[index] = product;
                    index++;
                }
            }

            return outOfStock;
        }
        public Product? GetMostExpensiveProduct()
        {
            if (products.Length == 0) return null;

            Product mostExpensive = products[0];

            foreach (var product in products)
            {
                if (product.Price > mostExpensive.Price)
                {
                    mostExpensive = product;
                }
            }

            return mostExpensive;
        }
        public void DisplayAllProducts()
        {
            foreach (var product in products)
            {
                product.DisplayProductInfo();
            }
        }
    }
}
