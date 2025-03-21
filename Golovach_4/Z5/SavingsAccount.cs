public class SavingsAccount : BankAccount
{
    private double interestRate;
    public SavingsAccount(string accountHolder, double balance, double interestRate)
        : base(accountHolder, balance)
    {
        this.interestRate = interestRate;
    }
    public override void CalculateInterest()
    {
        Balance += Balance * interestRate / 100;
    }
    public override void DisplayBalance()
    {
        Console.WriteLine($"Сберегательный счет - Владелец: {AccountHolder}");
        base.DisplayBalance();
    }
}
