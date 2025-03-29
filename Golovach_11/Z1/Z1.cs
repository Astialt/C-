using System;

class Program
{
    public interface IPayment
    {
        void Pay(decimal amount);
    }

    public class CashPayment : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Оплата наличными на сумму: {amount} BYN");
        }
    }
    public class CardPayment : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Оплата картой на сумму: {amount} BYN");
        }
    }
    public class CryptoPayment : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Оплата криптовалютой на сумму: {amount} BYN");
        }
    }

    public abstract class PaymentFactory
    {
        public abstract IPayment CreatePayment();
    }

    public class CashFactory : PaymentFactory
    {
        public override IPayment CreatePayment()
        {
            return new CashPayment();
        }
    }
    public class CardFactory : PaymentFactory
    {
        public override IPayment CreatePayment()
        {
            return new CardPayment();
        }
    }
    public class CryptoFactory : PaymentFactory
    {
        public override IPayment CreatePayment()
        {
            return new CryptoPayment();
        }
    }
    static void Main()
    {
        PaymentFactory cashFactory = new CashFactory();
        PaymentFactory cardFactory = new CardFactory();
        PaymentFactory cryptoFactory = new CryptoFactory();

        IPayment cashPayment = cashFactory.CreatePayment();
        IPayment cardPayment = cardFactory.CreatePayment();
        IPayment cryptoPayment = cryptoFactory.CreatePayment();

        cashPayment.Pay(100.00m);
        cardPayment.Pay(250.50m);
        cryptoPayment.Pay(500.75m);

        Console.WriteLine("\nВсе операции оплаты завершены.");
    }
}
