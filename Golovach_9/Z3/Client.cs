public class Client
{
    public string Name { get; set; }
    public decimal Balance { get; set; }

    public Client(string name, decimal balance)
    {
        Name = name;
        Balance = balance;
    }

    public override string ToString()
    {
        return $"{Name}, Balance: {Balance}";
    }
}
