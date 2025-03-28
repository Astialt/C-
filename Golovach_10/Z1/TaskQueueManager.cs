using System;
using System.Collections.Generic;

public sealed class TaskQueueManager
{
    private static readonly TaskQueueManager _instance = new TaskQueueManager();

    private readonly Queue<Action> _taskQueue;

    private TaskQueueManager()
    {
        _taskQueue = new Queue<Action>();
    }

    public static TaskQueueManager Instance
    {
        get { return _instance; }
    }
    public void AddTask(Action task)
    {
        if (task == null)
            throw new ArgumentNullException(nameof(task));

        lock (_taskQueue)
        {
            _taskQueue.Enqueue(task);
        }
    }

    public void ExecuteTasks()
    {
        while (true)
        {
            Action? task = null;
            lock (_taskQueue)
            {
                if (_taskQueue.Count > 0)
                    task = _taskQueue.Dequeue();
                else
                    break;
            }
            task?.Invoke();
        }
    }
}
