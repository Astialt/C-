public abstract class BankAccount
{
    public string AccountHolder { get; set; }
    public double Balance { get; protected set; }
    public BankAccount(string accountHolder, double balance)
    {
        AccountHolder = accountHolder;
        Balance = balance;
    }
    public abstract void CalculateInterest();
    public virtual void DisplayBalance()
    {
        Console.WriteLine($"Баланс счета: {Balance:C}");
    }
}
