using System;

class Program
{
    static void Main()
    {
        string directoryToWatch = @"D:\лабы\ПРАКТИКА С#\Golovach_9\Z4";

        FileWatcher watcher = new FileWatcher(directoryToWatch);

        watcher.StartWatching();
    }
}
