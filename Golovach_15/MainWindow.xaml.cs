using OrderManagement.ViewModels;
using System.Windows;

namespace OrderManagement
{
    public partial class MainWindow : Window
    {
        public ShopViewModel ViewModel { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new ShopViewModel();
            DataContext = ViewModel;
        }
    }
}
