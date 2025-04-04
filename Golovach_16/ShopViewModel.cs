using OrderManagement.Commands;
using OrderManagement.Models;
using OrderManagement.Services;
using OrderManagement.Views;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OrderManagement.ViewModels
{
    public class ShopViewModel : ViewModelBase
    {
        private readonly DataStoreService _dataStore;
        private readonly NotificationService _notificationService;
        public ObservableCollection<OrderModel> Orders { get; set; }
        public ObservableCollection<ProductModel> Products { get; set; }
        public ObservableCollection<ClientModel> Clients { get; set; }

        private OrderModel _selectedOrder;
        public OrderModel SelectedOrder
        {
            get => _selectedOrder;
            set { _selectedOrder = value; OnPropertyChanged(nameof(SelectedOrder)); }
        }

        public ICommand AddOrderCommand { get; }
        public ICommand EditOrderCommand { get; }
        public ICommand DeleteOrderCommand { get; }

        private bool _isProcessing;
        public bool IsProcessing
        {
            get => _isProcessing;
            set { _isProcessing = value; OnPropertyChanged(nameof(IsProcessing)); }
        }

        public ShopViewModel()
        {
            _dataStore = new DataStoreService();
            _notificationService = new NotificationService();
            Orders = new ObservableCollection<OrderModel>();
            Products = new ObservableCollection<ProductModel>();
            Clients = new ObservableCollection<ClientModel>();

            AddOrderCommand = new RelayCommand(async p => await AddOrderAsync(), p => !IsProcessing);
            EditOrderCommand = new RelayCommand(async p => await EditOrderAsync(), p => SelectedOrder != null && !IsProcessing);
            DeleteOrderCommand = new RelayCommand(async p => await DeleteOrderAsync(), p => SelectedOrder != null && !IsProcessing);

            LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var storeData = await _dataStore.LoadStoreDataAsync();
            if (storeData != null)
            {
                foreach (var p in storeData.Products)
                    Products.Add(p);
                foreach (var o in storeData.Orders)
                    Orders.Add(o);
                foreach (var c in storeData.Clients)
                    Clients.Add(c);
            }
        }

        private async Task AddOrderAsync()
        {
            var createOrderWindow = new CreateOrderWindow { Owner = Application.Current.MainWindow };
            if (createOrderWindow.ShowDialog() == true && createOrderWindow.NewOrder != null)
            {
                OrderModel newOrder = createOrderWindow.NewOrder;
                newOrder.ID = Orders.Count + 1;
                Orders.Add(newOrder);
                await _dataStore.SaveStoreDataAsync(new StoreData
                {
                    Products = new List<ProductModel>(Products),
                    Orders = new List<OrderModel>(Orders),
                    Clients = new List<ClientModel>(Clients)
                });
                _notificationService.WriteNotification($"Новый заказ: {newOrder.ID} - {newOrder.Product}");
                MessageBox.Show("Заказ успешно добавлен!");
            }
        }

        private async Task EditOrderAsync()
        {
            if (SelectedOrder == null)
            {
                MessageBox.Show("Выберите заказ для редактирования!");
                return;
            }
            var editOrderWindow = new EditOrderWindow(SelectedOrder) { Owner = Application.Current.MainWindow };
            if (editOrderWindow.ShowDialog() == true)
            {
                // Обновляем выбранный заказ с данными из окна редактирования
                SelectedOrder.Product = editOrderWindow.EditedOrder.Product;
                SelectedOrder.Quantity = editOrderWindow.EditedOrder.Quantity;
                SelectedOrder.Status = editOrderWindow.EditedOrder.Status;
                await _dataStore.SaveStoreDataAsync(new StoreData
                {
                    Products = new List<ProductModel>(Products),
                    Orders = new List<OrderModel>(Orders),
                    Clients = new List<ClientModel>(Clients)
                });
                MessageBox.Show("Заказ отредактирован!");
            }
        }

        private async Task DeleteOrderAsync()
        {
            if (SelectedOrder == null)
            {
                MessageBox.Show("Выберите заказ для удаления!");
                return;
            }
            if (MessageBox.Show("Удалить выбранный заказ?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Orders.Remove(SelectedOrder);
                await _dataStore.SaveStoreDataAsync(new StoreData
                {
                    Products = new List<ProductModel>(Products),
                    Orders = new List<OrderModel>(Orders),
                    Clients = new List<ClientModel>(Clients)
                });
                MessageBox.Show("Заказ удалён!");
            }
        }
    }
}
