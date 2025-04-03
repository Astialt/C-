using OrderManagement.Models;
using System.Threading.Tasks;

namespace OrderManagement.Services
{
    public class OrderService
    {
        public async Task ProcessOrderAsync(OrderModel order)
        {
          
            await Task.Delay(3000);
            order.Status = "Выполнен";
        }
    }
}
