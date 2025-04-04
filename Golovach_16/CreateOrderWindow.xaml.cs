using OrderManagement.Models;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace OrderManagement.Views
{
    public partial class CreateOrderWindow : Window
    {
        public OrderModel NewOrder { get; set; }

        public CreateOrderWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем заполнение всех полей
            if (string.IsNullOrWhiteSpace(ProductTextBox.Text) || string.IsNullOrWhiteSpace(QuantityTextBox.Text) || StatusComboBox.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Проверяем, что количество является корректным числом
            if (!int.TryParse(QuantityTextBox.Text, NumberStyles.Integer, CultureInfo.InvariantCulture, out int quantity))
            {
                MessageBox.Show("Введите корректное количество!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Извлекаем выбранный статус
            var selectedStatus = (StatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            // Создаём новый заказ
            NewOrder = new OrderModel
            {
                Product = ProductTextBox.Text.Trim(),
                Quantity = quantity,
                Status = selectedStatus // Устанавливаем выбранный статус
            };

            // Закрываем окно и возвращаем результат
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
