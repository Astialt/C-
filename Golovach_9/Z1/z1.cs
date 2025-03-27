using System;
using System.IO;

class Program
{
    static void Main()
    {
        string baseDirectory = @"D:\лабы\ПРАКТИКА С#\Golovach_9\Z1";
        Directory.CreateDirectory(baseDirectory); 

        string filePath = Path.Combine(baseDirectory, "golovach.ii");
        string copyPath = Path.Combine(baseDirectory, "golovach_copy.ii");

        FileManager.CreateFile(filePath, "Привет, мир!");
        Console.WriteLine(File.ReadAllText(filePath));
        FileManager.DeleteFile(filePath);
        FileManager.DeleteFile(filePath); 

        FileManager.CreateFile(filePath, "Тестовый файл.");
        FileInfoProvider.GetFileInfo(filePath);

        FileManager.CopyFile(filePath, copyPath);
        FileInfoProvider.GetFileInfo(copyPath);
        string movedPath = Path.Combine(baseDirectory, "moved_golovach.ii");
        FileManager.MoveFile(copyPath, movedPath);
        FileManager.RenameFile(filePath, "golovach.io");
        FileManager.DeleteFile("nonexistent_file.ii");
        FileManager.CreateFile(Path.Combine(baseDirectory, "file1.ii"), "Файл 1.");
        FileManager.CreateFile(Path.Combine(baseDirectory, "file2.ii"), "Файл 2, содержимое длиннее.");
        FileInfoProvider.CompareFileSizes(
            Path.Combine(baseDirectory, "file1.ii"),
            Path.Combine(baseDirectory, "file2.ii")
        );

        FileManager.DeleteFilesByPattern(baseDirectory, "*.ii");

        foreach (var file in Directory.GetFiles(baseDirectory))
        {
            Console.WriteLine($"Файл: {file}");
        }

        FileManager.CreateFile(filePath, "Тест.");
        FileManager.RestrictWritePermission(filePath);
        try
        {
            FileManager.CreateFile(filePath, "Добавление текста после запрета записи.");
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Ошибка записи в файл: {ex.Message}");
        }

        FileInfoProvider.CheckFilePermissions(filePath);
    }
}
