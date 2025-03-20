using System;

abstract class Ticket
{
    public string EventName { get; set; }
    public double Price { get; set; }
    public int SeatNumber { get; set; }

    // Конструктор для инициализации полей
    protected Ticket(string eventName, double price, int seatNumber)
    {
        EventName = eventName;
        Price = price;
        SeatNumber = seatNumber;
    }
}

sealed class ConcertTicket : Ticket
{
    public string BandName { get; set; }

    // Конструктор
    public ConcertTicket(string eventName, double price, int seatNumber, string bandName)
        : base(eventName, price, seatNumber)
    {
        BandName = bandName;
    }
}

sealed class TheaterTicket : Ticket
{
    public string PlayTitle { get; set; }

    // Конструктор
    public TheaterTicket(string eventName, double price, int seatNumber, string playTitle)
        : base(eventName, price, seatNumber)
    {
        PlayTitle = playTitle;
    }
}

class TicketOffice
{
    private Ticket[] tickets;

    public TicketOffice(Ticket[] tickets)
    {
        this.tickets = tickets;
    }

    public double GetTotalRevenue()
    {
        double totalRevenue = 0;
        foreach (var ticket in tickets)
        {
            totalRevenue += ticket.Price;
        }
        return totalRevenue;
    }

    public Ticket? GetMostExpensiveTicket()
    {
        if (tickets.Length == 0) return null;

        Ticket mostExpensive = tickets[0];
        foreach (var ticket in tickets)
        {
            if (ticket.Price > mostExpensive.Price)
            {
                mostExpensive = ticket;
            }
        }
        return mostExpensive;
    }
}

class Program
{
    static void Main()
    {
        Ticket[] tickets = new Ticket[]
        {
            new ConcertTicket("Rock Fest", 120.5, 101, "The Rockers"),
            new TheaterTicket("Shakespeare Night", 95.0, 15, "Hamlet"),
            new ConcertTicket("Jazz Evening", 150.0, 202, "Cool Jazz Band"),
            new TheaterTicket("Drama Show", 80.0, 23, "Death of a Salesman")
        };

        TicketOffice office = new TicketOffice(tickets);

        Console.WriteLine($"Общая сумма проданных билетов: {office.GetTotalRevenue()}");

        Ticket mostExpensive = office.GetMostExpensiveTicket()!;
        if (mostExpensive != null)
        {
            Console.WriteLine($"Самый дорогой билет: {mostExpensive.EventName}, Цена: {mostExpensive.Price}, Место: {mostExpensive.SeatNumber}");
        }
    }
}
