using System;
using System.Collections.Generic;

public abstract class EducationInstitution
{
    public string Name { get; set; }
    public EducationInstitution(string name)
    {
        Name = name;
    }
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Учебное заведение: {Name}");
    }
}

public interface IHasOnlineCourses
{
    void OfferOnlineCourses();
}
public interface IHasCampus
{
    void OfferCampusEducation();
}

public class OnlineSchool : EducationInstitution, IHasOnlineCourses
{
    public OnlineSchool(string name) : base(name) { }

    public void OfferOnlineCourses()
    {
        Console.WriteLine($"{Name} предлагает онлайн-курсы.");
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Онлайн-школа: {Name}");
    }
}
public class University : EducationInstitution, IHasCampus
{
    public University(string name) : base(name) { }
    public void OfferCampusEducation()
    {
        Console.WriteLine($"{Name} предлагает обучение в кампусе.");
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Университет: {Name}");
    }
}

class Program
{
    static void Main()
    {
        EducationInstitution[] institutions = new EducationInstitution[]
        {
            new OnlineSchool("Coursera"),
            new University("MIT"),
            new OnlineSchool("Udemy"),
            new University("Harvard")
        };

        Console.WriteLine("Все учебные заведения:");
        foreach (var institution in institutions)
        {
            institution.DisplayInfo();
        }

        Console.WriteLine();

        Console.WriteLine("Только онлайн-школы:");
        foreach (var institution in institutions)
        {
            if (institution is IHasOnlineCourses onlineSchool)
            {
                onlineSchool.OfferOnlineCourses();
            }
        }
    }
}