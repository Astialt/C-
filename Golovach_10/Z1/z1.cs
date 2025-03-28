using System;

class Program
{
    static void Main()
    {
        TaskQueueManager.Instance.AddTask(() => Console.WriteLine("Задача 1 выполнена!"));
        TaskQueueManager.Instance.AddTask(() => Console.WriteLine("Задача 2 выполнена!"));
        TaskQueueManager.Instance.AddTask(() => Console.WriteLine("Задача 3 выполнена!"));

        Console.WriteLine("Выполнение задач...");
        TaskQueueManager.Instance.ExecuteTasks();

        Console.WriteLine("Все задачи выполнены.");
        Console.ReadLine();
    }
}
