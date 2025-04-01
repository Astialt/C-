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
            // По умолчанию выбираем статус "Новый"
            StatusComboBox.SelectedIndex = 0;
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            string client = ClientTextBox.Text.Trim();
            if (string.IsNullOrEmpty(client))
            {
                MessageBox.Show("Введите имя клиента!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!decimal.TryParse(AmountTextBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal amount))
            {
                MessageBox.Show("Введите корректное значение суммы!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string selectedStatus = (StatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            if (!Enum.TryParse(selectedStatus, out OrderStatus status))
            {
                MessageBox.Show("Выберите корректный статус!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }

            // Создаем новый объект заказа (ID будет присвоено позже)
            NewOrder = new Order
            {
                Client = client,
                Amount = amount,
                Status = status
            };

            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
