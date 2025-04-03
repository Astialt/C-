using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace OrderManagement
{
    public partial class CreateOrderWindow : Window
    {
        public Order NewOrder { get; private set; }

        public CreateOrderWindow()
        {
            InitializeComponent();
            // Выбираем статус по умолчанию
            StatusComboBox.SelectedIndex = 0;
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
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

            // Создаем новый заказ (ID будет назначено в главном окне)
            NewOrder = new Order
            {
                Client = client,
                Product = product,
                Quantity = quantity,
                DeliveryStatus = selectedStatus
            };

            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
