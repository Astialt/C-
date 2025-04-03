using System.ComponentModel;

namespace OrderManagement
{
    public class Order : INotifyPropertyChanged
    {
        public int ID { get; set; }

        private string _client;
        public string Client
        {
            get => _client;
            set { _client = value; OnPropertyChanged(nameof(Client)); }
        }

        private string _product;
        public string Product
        {
            get => _product;
            set { _product = value; OnPropertyChanged(nameof(Product)); }
        }

        private int _quantity;
        public int Quantity
        {
            get => _quantity;
            set { _quantity = value; OnPropertyChanged(nameof(Quantity)); }
        }

        private string _deliveryStatus;
        public string DeliveryStatus
        {
            get => _deliveryStatus;
            set { _deliveryStatus = value; OnPropertyChanged(nameof(DeliveryStatus)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
