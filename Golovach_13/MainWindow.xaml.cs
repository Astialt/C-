using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace OrderManagement
{
    public partial class MainWindow : Window
    {
        public static readonly RoutedUICommand AddOrderCommand = new RoutedUICommand("Создать заказ", "AddOrderCommand", typeof(MainWindow));
        public static readonly RoutedUICommand EditOrderCommand = new RoutedUICommand("Редактировать заказ", "EditOrderCommand", typeof(MainWindow));
        public static readonly RoutedUICommand DeleteOrderCommand = new RoutedUICommand("Удалить заказ", "DeleteOrderCommand", typeof(MainWindow));

        public ObservableCollection<Order> OrdersList { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            OrdersList = new ObservableCollection<Order>
            {
                new Order { ID = 1, Client = "Иванов", Status = OrderStatus.Новый, Amount = 1200.50m },
                new Order { ID = 2, Client = "Петров", Status = OrderStatus.ВОбработке, Amount = 800.00m },
                new Order { ID = 3, Client = "Сидоров", Status = OrderStatus.Выполнен, Amount = 1500.00m }
            };
            DataContext = this;
        }

        private void AddOrderCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CreateOrderWindow createWindow = new CreateOrderWindow();
            if (createWindow.ShowDialog() == true)
            {
                int newId = OrdersList.Any() ? OrdersList.Max(o => o.ID) + 1 : 1;
                createWindow.NewOrder.ID = newId;
                OrdersList.Add(createWindow.NewOrder);
            }
        }
        private void AddOrderCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void EditOrderCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (OrdersDataGrid.SelectedItem is Order selectedOrder)
            {
                EditOrderWindow editWindow = new EditOrderWindow(selectedOrder);
                if (editWindow.ShowDialog() == true)
                {
                    OrdersDataGrid.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Выберите заказ для редактирования");
            }
        }
        private void EditOrderCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = OrdersDataGrid?.SelectedItem != null;
        }

        private void DeleteOrderCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (OrdersDataGrid.SelectedItem is Order selectedOrder)
            {
                if (MessageBox.Show("Удалить выбранный заказ?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    OrdersList.Remove(selectedOrder);
                }
            }
            else
            {
                MessageBox.Show("Выберите заказ для удаления");
            }
        }
        private void DeleteOrderCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = OrdersDataGrid?.SelectedItem != null;
        }
    }
}
