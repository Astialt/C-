using System.Windows.Input;

namespace OrderManagement
{
    public static class OrderCommands
    {
        public static readonly RoutedUICommand AddOrderCommand =
            new RoutedUICommand("Создать заказ", "AddOrderCommand", typeof(OrderCommands));
        public static readonly RoutedUICommand EditOrderCommand =
            new RoutedUICommand("Редактировать заказ", "EditOrderCommand", typeof(OrderCommands));
        public static readonly RoutedUICommand DeleteOrderCommand =
            new RoutedUICommand("Удалить заказ", "DeleteOrderCommand", typeof(OrderCommands));
    }
}
