using System;
class Program
{
    static void Main()
    {
        Console.Write("Введите номер телевизионного канала: ");
        int channelNumber = Convert.ToInt32(Console.ReadLine());
        switch (channelNumber)
        {
            case 1:
                Console.WriteLine("Популярные программы канала 1:");
                Console.WriteLine("- Новости");
                Console.WriteLine("- Утреннее шоу");
                break;
            case 2:
                Console.WriteLine("Популярные программы канала 2:");
                Console.WriteLine("- Ток-шоу");
                Console.WriteLine("- Кулинарные рецепты");
                break;
            case 3:
                Console.WriteLine("Популярные программы канала 3:");
                Console.WriteLine("- Документальные фильмы");
                Console.WriteLine("- Исторические передачи");
                break;
            case 4:
                Console.WriteLine("Популярные программы канала 4:");
                Console.WriteLine("- Музыкальные клипы");
                Console.WriteLine("- Концерты");
                break;
            default:
                Console.WriteLine("Канал с данным номером не найден.");
                break;
        }
    }
}
