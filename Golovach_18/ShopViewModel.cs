using OrderManagementDemo.Models;
using OrderManagementDemo.Repositories;

namespace OrderManagementDemo.ViewModels
{
    public class ShopViewModel : ProjectViewModel<Order>
    {
        public ShopViewModel() : base(new OrderRepository(new Data.ShopContext()))
        {
        }
    }
}
