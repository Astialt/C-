// ClientFileWriter.cs
using System;
using System.Collections.Generic;
using System.IO;

public class ClientFileWriter
{
    private readonly string _filePath;

    public ClientFileWriter(string filePath)
    {
        _filePath = filePath;
    }

    public void OverwriteClients(List<Client> clients)
    {
        using (StreamWriter writer = new StreamWriter(_filePath, false)) 
        {
            foreach (var client in clients)
            {
                writer.WriteLine($"{client.Name},{client.Balance}");
            }
        }
        Console.WriteLine($"Файл \"{_filePath}\" перезаписан с новыми данными.");
    }

    public void DisplayFileContents()
    {
        if (File.Exists(_filePath))
        {
            Console.WriteLine($"Содержимое файла \"{_filePath}\":");
            foreach (var line in File.ReadAllLines(_filePath))
            {
                Console.WriteLine(line);
            }
        }
        else
        {
            Console.WriteLine($"Файл \"{_filePath}\" не найден.");
        }
    }
}
