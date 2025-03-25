using System;

public class OrderLimitExceededException : Exception
{
    public OrderLimitExceededException() : base("Лимит заказов превышен.") { }
    public OrderLimitExceededException(string message) : base(message) { }

    public OrderLimitExceededException(string message, Exception innerException) : base(message, innerException) { }
}

public class OrderManager
{
    public void PlaceOrder(int itemCount)
    {
        if (itemCount > 100)
        {
            throw new OrderLimitExceededException($"Ошибка: количество заказов ({itemCount}) превышает допустимый лимит (100).");
        }
        Console.WriteLine($"Заказ на {itemCount} единиц принят.");
    }
}

class Program
{
    static void Main()
    {
        OrderManager orderManager = new OrderManager();

        int[] orderCounts = { 50, 120, 100 };

        foreach (int itemCount in orderCounts)
        {
            try
            {
                orderManager.PlaceOrder(itemCount);
            }
            catch (OrderLimitExceededException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Неизвестная ошибка: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Проверка заказа завершена.\n");
            }
        }
    }
}
