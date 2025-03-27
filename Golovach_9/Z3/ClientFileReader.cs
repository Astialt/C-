using System;
using System.Collections.Generic;
using System.IO;

public class ClientFileReader
{
    private readonly string _filePath;

    public ClientFileReader(string filePath)
    {
        _filePath = filePath;
    }
    public List<Client> ReadClients()
{
    List<Client> clients = new List<Client>();

    if (File.Exists(_filePath))
    {
        Console.WriteLine($"Файл найден: {_filePath}. Начинаем чтение...");

        var lines = File.ReadAllLines(_filePath);
        foreach (var line in lines)
        {
            Console.WriteLine($"Чтение строки: {line}");

            var parts = line.Split(',');
            if (parts.Length == 2 && decimal.TryParse(parts[1], System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out decimal balance))
            {
                clients.Add(new Client(parts[0], balance));
                Console.WriteLine($"Добавлен клиент: {parts[0]}, Баланс: {balance}");
            }
            else
            {
                Console.WriteLine($"Ошибка обработки строки: {line}");
            }
        }
    }
    else
    {
        Console.WriteLine($"Файл \"{_filePath}\" не найден. Убедитесь, что файл существует.");
    }

    return clients;
}

}
