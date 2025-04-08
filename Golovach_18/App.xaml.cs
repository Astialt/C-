using System.Linq;
using System.Windows;
using OrderManagementDemo.Data;
using OrderManagementDemo.Models;

namespace OrderManagementDemo
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Создаем базу, если еще не существует, с помощью EnsureCreated()
            using (var context = new ShopContext())
            {
                context.Database.EnsureCreated();

                // Если таблица Orders пуста, заполняем тестовыми данными
                if (!context.Orders.Any())
                {
                    var order1 = new Order
                    {
                        Customer = "Анна",
                        OrderDate = "2025-04-03",
                        Status = "Новый"
                    };
                    var order2 = new Order
                    {
                        Customer = "Борис",
                        OrderDate = "2025-04-04",
                        Status = "Выполнен"
                    };

                    context.Orders.Add(order1);
                    context.Orders.Add(order2);
                    // Первичное сохранение для генерации Id заказов
                    context.SaveChanges();

                    context.OrderItems.Add(new OrderItem
                    {
                        OrderId = order1.Id,
                        Product = "Ноутбук",
                        Quantity = 1,
                        Price = 1200.00
                    });
                    context.OrderItems.Add(new OrderItem
                    {
                        OrderId = order1.Id,
                        Product = "Мышь",
                        Quantity = 2,
                        Price = 25.50
                    });
                    context.OrderItems.Add(new OrderItem
                    {
                        OrderId = order2.Id,
                        Product = "Клавиатура",
                        Quantity = 1,
                        Price = 45.00
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
