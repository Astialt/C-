using OrderManagement.Commands;
using OrderManagement.Models;
using OrderManagement.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OrderManagement.ViewModels
{
    public class ShopViewModel : ViewModelBase
    {
        private readonly OrderService _orderService;

        public ObservableCollection<OrderModel> Orders { get; set; }
        public ObservableCollection<ProductModel> Products { get; set; }
        public ICommand PlaceOrderCommand { get; }

        private bool _isProcessing;
        public bool IsProcessing
        {
            get => _isProcessing;
            set { _isProcessing = value; OnPropertyChanged(nameof(IsProcessing)); }
        }

        public ShopViewModel()
        {
            _orderService = new OrderService();
            Orders = new ObservableCollection<OrderModel>();
            Products = new ObservableCollection<ProductModel>
            {
                new ProductModel { ID = 1, Name = "Ноутбук", Price = 1000 },
                new ProductModel { ID = 2, Name = "Смартфон", Price = 800 },
                new ProductModel { ID = 3, Name = "Планшет", Price = 500 }
            };

            // Команда оформления заказа инициирует асинхронную обработку
            PlaceOrderCommand = new RelayCommand(async param => await PlaceOrderAsync(), param => !IsProcessing);
        }

        private async Task PlaceOrderAsync()
        {
            if (Products.Count == 0)
            {
                MessageBox.Show("Нет доступных продуктов для заказа.");
                return;
            }

            IsProcessing = true;

            // Создаем новый заказ (для простоты выбираем первый продукт)
            var order = new OrderModel
            {
                ID = Orders.Count + 1,
                Product = Products[0].Name,
                Quantity = 1,
                Status = "Обработка..."
            };

            Orders.Add(order);

            // Асинхронная обработка заказа через OrderService
            await _orderService.ProcessOrderAsync(order);

            MessageBox.Show("Заказ успешно обработан!");
            IsProcessing = false;
        }
    }
}
