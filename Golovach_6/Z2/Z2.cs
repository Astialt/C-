using System;
public delegate string DateFormatter(DateTime date);

public class DateHandler
{
    public string FormatDate(DateTime date, DateFormatter formatter)
    {
        return formatter(date);
    }
    public string ShortFormat(DateTime date)
    {
        return date.ToString("MM/dd/yyyy");
    }

    public string LongFormat(DateTime date)
    {
        return date.ToString("dddd, dd MMMM yyyy");
    }
}

class Program
{
    static void Main()
    {
        DateHandler dateHandler = new DateHandler();
        
        DateTime currentDate = DateTime.Now;

        DateFormatter shortFormatter = dateHandler.ShortFormat;
        string shortFormattedDate = dateHandler.FormatDate(currentDate, shortFormatter);
        Console.WriteLine("Краткий формат даты:");
        Console.WriteLine(shortFormattedDate);

        DateFormatter longFormatter = dateHandler.LongFormat;
        string longFormattedDate = dateHandler.FormatDate(currentDate, longFormatter);
        Console.WriteLine("Полный формат даты:");
        Console.WriteLine(longFormattedDate);
    }
}
