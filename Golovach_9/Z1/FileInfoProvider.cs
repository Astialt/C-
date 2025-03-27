using System;
using System.IO;

public class FileInfoProvider
{
    public static void GetFileInfo(string path)
    {
        if (File.Exists(path))
        {
            FileInfo fileInfo = new FileInfo(path);
            Console.WriteLine($"Файл: {fileInfo.Name}");
            Console.WriteLine($"Полный путь: {fileInfo.FullName}");
            Console.WriteLine($"Размер: {fileInfo.Length} байт");
            Console.WriteLine($"Дата создания: {fileInfo.CreationTime}");
            Console.WriteLine($"Дата последнего изменения: {fileInfo.LastWriteTime}");
        }
        else
        {
            Console.WriteLine($"Файл \"{path}\" не найден.");
        }
    }

    public static void CompareFileSizes(string path1, string path2)
    {
        if (File.Exists(path1) && File.Exists(path2))
        {
            FileInfo file1 = new FileInfo(path1);
            FileInfo file2 = new FileInfo(path2);

            if (file1.Length > file2.Length)
            {
                Console.WriteLine($"Файл \"{file1.Name}\" больше, чем файл \"{file2.Name}\".");
            }
            else if (file1.Length < file2.Length)
            {
                Console.WriteLine($"Файл \"{file2.Name}\" больше, чем файл \"{file1.Name}\".");
            }
            else
            {
                Console.WriteLine($"Оба файла имеют одинаковый размер.");
            }
        }
        else
        {
            Console.WriteLine("Один или оба файла не существуют.");
        }
    }

    public static void CheckFilePermissions(string path)
    {
        if (File.Exists(path))
        {
            FileInfo fileInfo = new FileInfo(path);
            Console.WriteLine($"Права к файлу \"{fileInfo.Name}\":");
            Console.WriteLine($"Только для чтения: {fileInfo.IsReadOnly}");
            Console.WriteLine($"Атрибуты: {fileInfo.Attributes}");
        }
        else
        {
            Console.WriteLine($"Файл \"{path}\" не найден.");
        }
    }
}
