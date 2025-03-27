using System;
using System.IO;

public class FileWatcher
{
    private readonly string _directoryPath;
    private readonly string _filter;

    public FileWatcher(string directoryPath, string filter = "*.config")
    {
        _directoryPath = directoryPath;
        _filter = filter;
    }

    public void StartWatching()
    {
        if (!Directory.Exists(_directoryPath))
        {
            Console.WriteLine($"Папка \"{_directoryPath}\" не существует. Проверьте путь.");
            return;
        }

        Console.WriteLine($"Начато отслеживание папки \"{_directoryPath}\" для файлов \"{_filter}\".");

        FileSystemWatcher watcher = new FileSystemWatcher
        {
            Path = _directoryPath,
            Filter = _filter,
            NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite,
            EnableRaisingEvents = true,
            IncludeSubdirectories = false 
        };

        watcher.Created += OnCreated;
        watcher.Deleted += OnDeleted;
        watcher.Changed += OnChanged;
        watcher.Renamed += OnRenamed;

        Console.WriteLine("Нажмите Enter для остановки...");
        Console.ReadLine(); 
    }

    private void OnCreated(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"[Создан] Файл: {e.FullPath}");
    }

    private void OnDeleted(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"[Удалён] Файл: {e.FullPath}");
    }

    private void OnChanged(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"[Изменён] Файл: {e.FullPath}");
        if (Path.GetExtension(e.FullPath) == ".config")
        {
            Console.WriteLine("Внимание: Конфигурация изменена!");
        }
    }

    private void OnRenamed(object sender, RenamedEventArgs e)
    {
        Console.WriteLine($"[Переименован] Файл: {e.OldFullPath} -> {e.FullPath}");
    }
}
