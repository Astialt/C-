using System;

public delegate void DownloadProgressHandler(int percentage);

public class FileDownloader
{
    public event DownloadProgressHandler DownloadProgress;

    public void StartDownload()
    {
        for (int i = 0; i <= 100; i += 20)
        {
            Console.WriteLine($"Загрузка: {i}%");
            OnDownloadProgress(i);
            System.Threading.Thread.Sleep(500);
        }
    }

    protected virtual void OnDownloadProgress(int percentage)
    {
        if (DownloadProgress != null)
        {
            DownloadProgress(percentage);
        }
    }
}
public class ProgressBar
{
    public void UpdateProgress(int percentage)
    {
        Console.WriteLine($"[ProgressBar] Индикатор обновлён: {percentage}%");
    }
}

public class Logger
{
    public void LogProgress(int percentage)
    {
        Console.WriteLine($"[Logger] Запись: загрузка на {percentage}% завершена.");
    }
}
class Program
{
    static void Main()
    {
        FileDownloader fileDownloader = new FileDownloader();
        ProgressBar progressBar = new ProgressBar();
        Logger logger = new Logger();

        fileDownloader.DownloadProgress += progressBar.UpdateProgress;
        fileDownloader.DownloadProgress += logger.LogProgress;

        Console.WriteLine("Начало загрузки файла...");
        fileDownloader.StartDownload();
        Console.WriteLine("Загрузка завершена.");
    }
}
