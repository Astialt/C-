using OrderManagement.ViewModels;
using System.Windows;
using OrderManagement.Views;

namespace OrderManagement
{
    public partial class MainWindow : Window
    {
        public ShopViewModel ShopVM { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            ShopVM = new ShopViewModel();
            DataContext = ShopVM;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow { Owner = this };
            loginWindow.ShowDialog();
        }

        private void OpenChat_Click(object sender, RoutedEventArgs e)
        {
            var chatWindow = new ChatWindow { Owner = this };
            chatWindow.Show();
        }
    }
}
