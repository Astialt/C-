using System;
using System.IO;

public class FileManager
{
    public static void CreateFile(string path, string content)
    {
        File.WriteAllText(path, content);
        Console.WriteLine($"Файл \"{path}\" создан с содержимым: \"{content}\".");
    }

    public static void DeleteFile(string path)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
            Console.WriteLine($"Файл \"{path}\" удалён.");
        }
        else
        {
            Console.WriteLine($"Файл \"{path}\" не существует.");
        }
    }

    public static void CopyFile(string sourcePath, string destPath)
    {
        if (File.Exists(sourcePath))
        {
            File.Copy(sourcePath, destPath, true);
            Console.WriteLine($"Файл \"{sourcePath}\" скопирован в \"{destPath}\".");
        }
        else
        {
            Console.WriteLine($"Файл \"{sourcePath}\" не существует.");
        }
    }

    public static void MoveFile(string sourcePath, string destPath)
    {
        if (File.Exists(sourcePath))
        {
            File.Move(sourcePath, destPath);
            Console.WriteLine($"Файл перемещён из \"{sourcePath}\" в \"{destPath}\".");
        }
        else
        {
            Console.WriteLine($"Файл \"{sourcePath}\" не существует.");
        }
    }

    public static void RenameFile(string sourcePath, string newName)
    {
        string directory = Path.GetDirectoryName(sourcePath)!;
        string newPath = Path.Combine(directory, newName);
        MoveFile(sourcePath, newPath);
    }

    public static void DeleteFilesByPattern(string directory, string pattern)
    {
        if (Directory.Exists(directory))
        {
            var files = Directory.GetFiles(directory, pattern);
            foreach (var file in files)
            {
                DeleteFile(file);
            }
            Console.WriteLine($"Все файлы, соответствующие шаблону \"{pattern}\", удалены из папки \"{directory}\".");
        }
        else
        {
            Console.WriteLine($"Папка \"{directory}\" не существует.");
        }
    }

    public static void RestrictWritePermission(string path)
    {
        FileInfo fileInfo = new FileInfo(path);
        fileInfo.Attributes = FileAttributes.ReadOnly;
        Console.WriteLine($"Запись в файл \"{path}\" запрещена.");
    }
}
