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

         
            var initialItem = StatusComboBox.Items
                .Cast<ComboBoxItem>()
                .FirstOrDefault(item => item.Content.ToString() == order.Status.ToString());
            if (initialItem != null)
            {
                StatusComboBox.SelectedItem = initialItem;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
   
            string selectedStatus = (StatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            if (Enum.TryParse(selectedStatus, out OrderStatus newStatus))
            {
                Order.Status = newStatus;
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Выберите корректный статус");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
