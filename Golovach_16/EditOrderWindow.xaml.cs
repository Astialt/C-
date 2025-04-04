using OrderManagement.Models;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace OrderManagement.Views
{
    public partial class EditOrderWindow : Window
    {
        public OrderModel EditedOrder { get; set; }

        public EditOrderWindow(OrderModel order)
        {
            InitializeComponent();

            // Инициализируем данные заказа
            EditedOrder = new OrderModel
            {
                ID = order.ID,
                Product = order.Product,
                Quantity = order.Quantity,
                Status = order.Status
            };

            // Заполняем поля
            ProductTextBox.Text = EditedOrder.Product;
            QuantityTextBox.Text = EditedOrder.Quantity.ToString(CultureInfo.InvariantCulture);

            foreach (ComboBoxItem item in StatusComboBox.Items)
            {
                if (item.Content.ToString() == EditedOrder.Status)
                {
                    StatusComboBox.SelectedItem = item; // Устанавливаем текущий статус
                    break;
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ProductTextBox.Text) || string.IsNullOrWhiteSpace(QuantityTextBox.Text) || StatusComboBox.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(QuantityTextBox.Text, NumberStyles.Integer, CultureInfo.InvariantCulture, out int quantity))
            {
                MessageBox.Show("Введите корректное количество!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            EditedOrder.Product = ProductTextBox.Text.Trim();
            EditedOrder.Quantity = quantity;
            EditedOrder.Status = (StatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

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
