namespace OrderManagement
{
    public enum OrderStatus
    {
        �����,
        ����������,
        ��������
    }

    public class Order
    {
        public int ID { get; set; }
        public string Client { get; set; }
        public OrderStatus Status { get; set; }
        public decimal Amount { get; set; }
    }
}
