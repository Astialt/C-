using System;
using System.Collections;

public class Contact
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }

    public Contact(string name, string phoneNumber)
    {
        Name = name;
        PhoneNumber = phoneNumber;
    }

    public override string ToString()
    {
        return $"Имя: {Name}, Телефон: {PhoneNumber}";
    }
}

public class PhoneBook
{
    private Hashtable _contacts;

    public PhoneBook()
    {
        _contacts = new Hashtable();
    }

    public void AddContact(string name, string phoneNumber)
    {
        if (!_contacts.ContainsKey(name))
        {
            _contacts.Add(name, new Contact(name, phoneNumber));
            Console.WriteLine($"Контакт \"{name}\" добавлен.");
        }
        else
        {
            Console.WriteLine($"Контакт с именем \"{name}\" уже существует.");
        }
    }

    public void RemoveContact(string name)
    {
        if (_contacts.ContainsKey(name))
        {
            _contacts.Remove(name);
            Console.WriteLine($"Контакт \"{name}\" удалён.");
        }
        else
        {
            Console.WriteLine($"Контакт с именем \"{name}\" не найден.");
        }
    }

    public void SearchContact(string name)
    {
        if (_contacts.ContainsKey(name))
        {
            Console.WriteLine(_contacts[name]);
        }
        else
        {
            Console.WriteLine($"Контакт с именем \"{name}\" не найден.");
        }
    }

    public void DisplayAllContacts()
    {
        if (_contacts.Count > 0)
        {
            Console.WriteLine("Список всех контактов:");
            foreach (DictionaryEntry entry in _contacts)
            {
                Console.WriteLine(entry.Value);
            }
        }
        else
        {
            Console.WriteLine("Телефонная книга пуста.");
        }
    }
}

class Program
{
    static void Main()
    {
        PhoneBook phoneBook = new PhoneBook();
        phoneBook.AddContact("Иван", "+375291234567");
        phoneBook.AddContact("Мария", "+375297654321");

        phoneBook.AddContact("Иван", "+375441111111");

        phoneBook.DisplayAllContacts();
        phoneBook.SearchContact("Мария");
        phoneBook.RemoveContact("Иван");
        phoneBook.RemoveContact("Анна");
        phoneBook.DisplayAllContacts();
    }
}
