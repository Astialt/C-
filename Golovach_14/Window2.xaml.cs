using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace OrderManagement
{
    public partial class EditOrderWindow : Window
    {
        public Order Order { get; private set; }

        public EditOrderWindow(Order order)
        {
            InitializeComponent();
            Order = order;

            // Заполнение полей текущими данными заказа
            IdTextBlock.Text = Order.ID.ToString();
            ClientTextBox.Text = Order.Client;
            ProductTextBox.Text = Order.Product;
            QuantityTextBox.Text = Order.Quantity.ToString();
            var initialItem = StatusComboBox.Items
                .OfType<ComboBoxItem>()
                .FirstOrDefault(item => item.Content.ToString() == Order.DeliveryStatus);
            if (initialItem != null)
                StatusComboBox.SelectedItem = initialItem;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string client = ClientTextBox.Text.Trim();
            string product = ProductTextBox.Text.Trim();
            if (string.IsNullOrEmpty(client) || string.IsNullOrEmpty(product))
            {
                MessageBox.Show("Введите имя клиента и наименование товара!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!int.TryParse(QuantityTextBox.Text.Trim(), out int quantity))
            {
                MessageBox.Show("Введите корректное количество товара!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string selectedStatus = (StatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            if (string.IsNullOrEmpty(selectedStatus))
            {
                MessageBox.Show("Выберите корректный статус доставки!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Обновляем заказ
            Order.Client = client;
            Order.Product = product;
            Order.Quantity = quantity;
            Order.DeliveryStatus = selectedStatus;

            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e) =>
            DialogResult = false;
    }
}
