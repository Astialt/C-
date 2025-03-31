using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace OrderManagement
{
    public partial class MainWindow : Window
    {
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
            OrdersDataGrid.ItemsSource = OrdersList;
            StatusFilterComboBox.SelectedIndex = 0;
        }

        private void NewOrder_Click(object sender, RoutedEventArgs e)
        {
            int newId = OrdersList.Count > 0 ? OrdersList.Max(o => o.ID) + 1 : 1;
            OrdersList.Add(new Order { ID = newId, Client = "Новый клиент", Status = OrderStatus.Новый, Amount = 0 });
        }

        private void EditOrder_Click(object sender, RoutedEventArgs e)
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

        private void DeleteOrder_Click(object sender, RoutedEventArgs e)
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

        private void StatusFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedStatus = (StatusFilterComboBox.SelectedItem as ComboBoxItem).Content.ToString();
            if (selectedStatus == "Все")
            {
                OrdersDataGrid.ItemsSource = OrdersList;
            }
            else
            {
                OrderStatus filterStatus;
                if (Enum.TryParse(selectedStatus, out filterStatus))
                {
                    var filtered = OrdersList.Where(o => o.Status == filterStatus);
                    OrdersDataGrid.ItemsSource = new ObservableCollection<Order>(filtered);
                }
            }
        }

        private void ViewDetails_Click(object sender, RoutedEventArgs e)
        {
            if (OrdersDataGrid.SelectedItem is Order selectedOrder)
            {
                MessageBox.Show($"Детали заказа {selectedOrder.ID}:\n" +
                                $"Клиент: {selectedOrder.Client}\n" +
                                $"Статус: {selectedOrder.Status}\n" +
                                $"Сумма: {selectedOrder.Amount}");
            }
        }

        private void SetStatusNew_Click(object sender, RoutedEventArgs e)
        {
            SetSelectedOrderStatus(OrderStatus.Новый);
        }

        private void SetStatusInProgress_Click(object sender, RoutedEventArgs e)
        {
            SetSelectedOrderStatus(OrderStatus.ВОбработке);
        }

        private void SetStatusCompleted_Click(object sender, RoutedEventArgs e)
        {
            SetSelectedOrderStatus(OrderStatus.Выполнен);
        }

        private void SetSelectedOrderStatus(OrderStatus status)
        {
            if (OrdersDataGrid.SelectedItem is Order selectedOrder)
            {
                selectedOrder.Status = status;
                OrdersDataGrid.Items.Refresh(); // Обновляем отображение DataGrid
            }
            else
            {
                MessageBox.Show("Выберите заказ для изменения статуса");
            }
        }
    }
}
