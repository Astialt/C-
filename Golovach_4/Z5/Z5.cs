using System;

class Program
{
    static void Main()
    {
        SavingsAccount savings = new SavingsAccount("Иван Иванов", 1000, 5);
        CurrentAccount current = new CurrentAccount("Петр Петров", 1500, 10);

        savings.DisplayBalance();
        savings.CalculateInterest();
        savings.DisplayBalance();

        Console.WriteLine();

        current.DisplayBalance();
        current.CalculateInterest();
        current.DisplayBalance();
    }
}
