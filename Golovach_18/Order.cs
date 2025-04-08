namespace OrderManagementDemo.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public string OrderDate { get; set; }  
        public string Status { get; set; }     

      
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
