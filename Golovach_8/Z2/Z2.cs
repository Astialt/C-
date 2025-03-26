using System;
using System.Collections.Generic;

public class MySortedList<TKey, TValue> where TKey : IComparable<TKey>
{
    private List<KeyValuePair<TKey, TValue>> _items;

    public MySortedList()
    {
        _items = new List<KeyValuePair<TKey, TValue>>();
    }

    public void Add(TKey key, TValue value)
    {
        if (key == null)
        {
            throw new ArgumentNullException(nameof(key), "Ключ не может быть null.");
        }
        foreach (var item in _items)
        {
            if (item.Key.CompareTo(key) == 0)
            {
                throw new ArgumentException($"Ключ \"{key}\" уже существует в списке.");
            }
        }

        _items.Add(new KeyValuePair<TKey, TValue>(key, value));
        _items.Sort((pair1, pair2) => pair1.Key.CompareTo(pair2.Key)); // Сортировка по ключу
    }
    public bool Remove(TKey key)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i].Key.CompareTo(key) == 0)
            {
                _items.RemoveAt(i);
                return true;
            }
        }
        return false;
    }
    public TValue Find(TKey key)
    {
        foreach (var item in _items)
        {
            if (item.Key.CompareTo(key) == 0)
            {
                return item.Value;
            }
        }
        throw new KeyNotFoundException($"Ключ \"{key}\" не найден в списке.");
    }
    public void DisplayAll()
    {
        if (_items.Count == 0)
        {
            Console.WriteLine("Список пуст.");
            return;
        }

        Console.WriteLine("Содержимое списка:");
        foreach (var item in _items)
        {
            Console.WriteLine($"Ключ: {item.Key}, Значение: {item.Value}");
        }
    }
}

public class SortedListManager<TKey, TValue> where TKey : IComparable<TKey>
{
    private readonly MySortedList<TKey, TValue> _sortedList;

    public SortedListManager()
    {
        _sortedList = new MySortedList<TKey, TValue>();
    }

    // Добавление элемента
    public void AddElement(TKey key, TValue value)
    {
        try
        {
            _sortedList.Add(key, value);
            Console.WriteLine($"Элемент с ключом \"{key}\" и значением \"{value}\" добавлен.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка добавления: {ex.Message}");
        }
    }

    // Удаление элемента
    public void RemoveElement(TKey key)
    {
        if (_sortedList.Remove(key))
        {
            Console.WriteLine($"Элемент с ключом \"{key}\" удалён.");
        }
        else
        {
            Console.WriteLine($"Элемент с ключом \"{key}\" не найден.");
        }
    }

    // Поиск элемента
    public void FindElement(TKey key)
    {
        try
        {
            TValue value = _sortedList.Find(key);
            Console.WriteLine($"Найден элемент: Ключ: {key}, Значение: {value}");
        }
        catch (KeyNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    // Показать все элементы
    public void DisplayAllElements()
    {
        _sortedList.DisplayAll();
    }
}

class Program
{
    static void Main()
    {
        SortedListManager<int, string> manager = new SortedListManager<int, string>();

        // Добавление элементов
        manager.AddElement(3, "Три");
        manager.AddElement(1, "Один");
        manager.AddElement(2, "Два");

        // Попытка добавить дубликат
        manager.AddElement(1, "Дубликат");

        // Вывод всех элементов
        manager.DisplayAllElements();

        // Поиск элемента
        manager.FindElement(2);

        // Удаление элемента
        manager.RemoveElement(3);

        // Удаление несуществующего элемента
        manager.RemoveElement(10);

        // Вывод всех элементов после удаления
        manager.DisplayAllElements();
    }
}
