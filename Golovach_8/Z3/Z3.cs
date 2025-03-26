using System;
using System.Collections.Generic;

public interface IFilter<T>
{
    IEnumerable<T> Filter(IEnumerable<T> items, Func<T, bool> predicate);
}

public class SimpleFilter<T> : IFilter<T>
{
    public IEnumerable<T> Filter(IEnumerable<T> items, Func<T, bool> predicate)
    {
        if (items == null)
        {
            throw new ArgumentNullException(nameof(items), "Коллекция не может быть null.");
        }

        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate), "Условие фильтрации не может быть null.");
        }

        List<T> filteredItems = new List<T>();
        foreach (var item in items)
        {
            if (predicate(item))
            {
                filteredItems.Add(item);
            }
        }
        return filteredItems;
    }
}
public class FilterManager<T>
{
    private readonly IFilter<T> _filter;

    public FilterManager(IFilter<T> filter)
    {
        _filter = filter;
    }
    public void PrintFiltered(IEnumerable<T> items, Func<T, bool> predicate)
    {
        var filteredItems = _filter.Filter(items, predicate);

        Console.WriteLine("Отфильтрованные элементы:");
        foreach (var item in filteredItems)
        {
            Console.WriteLine(item);
        }
    }
}

public class Entity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}";
    }
}

class Program
{
    static void Main()
    {
        var entities = new List<Entity>
        {
            new Entity { Id = 1, Name = "Объект1" },
            new Entity { Id = 2, Name = "Объект2" },
            new Entity { Id = 3, Name = "Объект3" },
            new Entity { Id = 4, Name = "Объект4" }
        };

        IFilter<Entity> simpleFilter = new SimpleFilter<Entity>();
        FilterManager<Entity> filterManager = new FilterManager<Entity>(simpleFilter);
        filterManager.PrintFiltered(entities, e => e.Id > 2);
    }
}
