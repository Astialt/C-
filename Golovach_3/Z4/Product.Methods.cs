namespace Store.Models
{
    public partial class Product
    {

        public void DisplayProductInfo()
        {
            Console.WriteLine($"Название: {Name}, Категория: {Category}, Цена: {Price}, Остаток: {Stock}");
        }
    }
}
