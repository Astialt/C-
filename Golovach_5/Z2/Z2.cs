using System;
using System.Collections.Generic;

public class Citizen
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Citizen(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

public class Infrastructure
{
    public int Hospitals { get; set; }
    public int Schools { get; set; }

    public Infrastructure(int hospitals, int schools)
    {
        Hospitals = hospitals;
        Schools = schools;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Инфраструктура: Больницы - {Hospitals}, Школы - {Schools}");
    }
}

public class City
{
    public string Name { get; set; }
    public List<Citizen> Citizens { get; set; } 
    public Infrastructure Infrastructure { get; private set; } 

    public City(string name, int hospitals, int schools)
    {
        Name = name;
        Citizens = new List<Citizen>();
        Infrastructure = new Infrastructure(hospitals, schools);
    }

    public void AddCitizen(Citizen citizen)
    {
        Citizens.Add(citizen);
    }

    public int GetPopulation()
    {
        return Citizens.Count;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Город: {Name}, Население: {GetPopulation()}");
        Infrastructure.DisplayInfo();
    }
}

public class Country
{
    public string Name { get; set; }
    public List<City> Cities { get; set; } 

    public Country(string name)
    {
        Name = name;
        Cities = new List<City>();
    }

    public void AddCity(City city)
    {
        Cities.Add(city);
    }

    public void ShowPopulation()
    {
        Console.WriteLine($"Страна: {Name}");
        foreach (var city in Cities)
        {
            city.DisplayInfo();
        }
    }
}

class Program
{
    static void Main()
    {
        Country country = new Country("Беларусь");
      
        City city1 = new City("Минск", 10, 20);
        City city2 = new City("Гродно", 5, 10);
        City city3 = new City("Брест", 3, 8);
  
        city1.AddCitizen(new Citizen("Иван", 30));
        city1.AddCitizen(new Citizen("Анна", 25));

        city2.AddCitizen(new Citizen("Сергей", 40));

        city3.AddCitizen(new Citizen("Наталья", 35));
        city3.AddCitizen(new Citizen("Виктор", 45));
        city3.AddCitizen(new Citizen("Ольга", 29));

        country.AddCity(city1);
        country.AddCity(city2);
        country.AddCity(city3);

        country.ShowPopulation();
    }
}
