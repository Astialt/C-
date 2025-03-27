using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string filePath = "D:/лабы/ПРАКТИКА С#/Golovach_9/Z3/file.data";

        ClientFileReader reader = new ClientFileReader(filePath);

        List<Client> clients = reader.ReadClients();

        Console.WriteLine("\nВсе клиенты:");
        foreach (var client in clients)
        {
            Console.WriteLine(client);
        }
        ClientProcessor processor = new ClientProcessor(clients);

        List<Client> debtors = processor.FindDebtors();

        Console.WriteLine("\nДолжники (отрицательный баланс):");
        if (debtors.Count > 0)
        {
            foreach (var debtor in debtors)
            {
                Console.WriteLine(debtor);
            }
        }
        else
        {
            Console.WriteLine("Нет клиентов с отрицательным балансом.");
        }
    }
}
