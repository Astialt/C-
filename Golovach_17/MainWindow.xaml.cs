using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace OrderManagementDemo
{
    public partial class OrdersWindow : Window
    {
        public ObservableCollection<Order> Orders { get; set; }
        public ObservableCollection<string> StatusList { get; set; }

        public OrdersWindow()
        {
            InitializeComponent();


            Orders = new ObservableCollection<Order>()
            {
                new Order { Product = "Товар А", Quantity = 10, Status = "Новый" },
                new Order { Product = "Товар Б", Quantity = 5, Status = "В обработке" },
                new Order { Product = "Товар В", Quantity = 2, Status = "Завершен" }
            };
            StatusList = new ObservableCollection<string>()
            {
                "Новый", "В обработке", "Завершен", "Отменен"
            };

            DataContext = this;
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            var newOrder = new Order { Product = "Новый товар", Quantity = 1, Status = "Новый" };
            Orders.Add(newOrder);
        }


        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (OrdersDataGrid.SelectedItem is Order selectedOrder)
            {
    
                selectedOrder.Quantity += 1;
  
                OrdersDataGrid.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Выберите заказ для редактирования.");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (OrdersDataGrid.SelectedItem is Order selectedOrder)
            {
                Orders.Remove(selectedOrder);
            }
            else
            {
                MessageBox.Show("Выберите заказ для удаления.");
            }
        }
    }
    public class Order
    {
        public string Product { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
    }
}
