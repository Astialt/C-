using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string filePath = @"file.data";

        ClientFileWriter writer = new ClientFileWriter(filePath);
        List<Client> clients = new List<Client>
        {
            new Client("Иван Иванов", 1000.50m),
            new Client("Пётр Петров", 2000.75m),
            new Client("Анна Смирнова", 1500.20m)
        };

        writer.OverwriteClients(clients);

        writer.DisplayFileContents();
    }
}
