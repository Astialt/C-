using System;
using System.Collections.Generic;

public class ClientProcessor
{
    private readonly List<Client> _clients;

    public ClientProcessor(List<Client> clients)
    {
        _clients = clients;
    }

    public List<Client> FindDebtors()
    {
        List<Client> debtors = new List<Client>();

        Console.WriteLine("Начинаем поиск должников...");
        foreach (var client in _clients)
        {
            Console.WriteLine($"Проверка клиента: {client.Name}, Баланс: {client.Balance}");

            if (client.Balance < 0)
            {
                debtors.Add(client);
                Console.WriteLine($"Найден должник: {client.Name}, Баланс: {client.Balance}");
            }
        }

        return debtors;
    }
}
