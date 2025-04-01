using System;
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

            // Заполняем поля значениями из заказа
            IdTextBlock.Text = Order.ID.ToString();
            ClientTextBox.Text = Order.Client;
            AmountTextBox.Text = Order.Amount.ToString(CultureInfo.InvariantCulture);

            // Устанавливаем выбранный элемент ComboBox в соответствии со статусом заказа
            var initialItem = StatusComboBox.Items
                .OfType<ComboBoxItem>()
                .FirstOrDefault(item => item.Content.ToString() == Order.Status.ToString());
            if (initialItem != null)
            {
                StatusComboBox.SelectedItem = initialItem;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, что имя клиента введено
            string clientName = ClientTextBox.Text.Trim();
            if (string.IsNullOrEmpty(clientName))
            {
                MessageBox.Show("Введите имя клиента!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Парсим сумму заказа
            if (!decimal.TryParse(AmountTextBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal amount))
            {
                MessageBox.Show("Введите корректное значение суммы!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Определяем выбранный статус
            string selectedStatus = (StatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            if (!Enum.TryParse(selectedStatus, out OrderStatus newStatus))
            {
                MessageBox.Show("Выберите корректный статус!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Записываем изменения в заказ
            Order.Client = clientName;
            Order.Amount = amount;
            Order.Status = newStatus;

            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
