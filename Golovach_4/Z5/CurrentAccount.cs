public class CurrentAccount : BankAccount
{
    private double serviceFee;
    public CurrentAccount(string accountHolder, double balance, double serviceFee)
        : base(accountHolder, balance)
    {
        this.serviceFee = serviceFee;
    }
    public override void CalculateInterest()
    {
        Balance -= serviceFee;
    }
    public override void DisplayBalance()
    {
        Console.WriteLine($"Текущий счет - Владелец: {AccountHolder}");
        base.DisplayBalance();
    }
}
