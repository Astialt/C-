using System;
class Program
{
    static void Main()
    {
        int[,] trainSeats = new int[18, 36];

        Random random = new Random();
        for (int i = 0; i < 18; i++)
        {
            for (int j = 0; j < 36; j++)
            {
                trainSeats[i, j] = random.Next(0, 2); // 0 или 1
            }
        }

        Console.WriteLine("Проверка свободных мест в вагонах:");
        for (int i = 0; i < 18; i++)
        {
            bool hasFreeSeat = false;

            for (int j = 0; j < 36; j++)
            {
                if (trainSeats[i, j] == 0) 
                {
                    hasFreeSeat = true;
                    break;
                }
            }
            if (hasFreeSeat)
            {
                Console.WriteLine($"Вагон {i + 1}: имеются свободные места.");
            }
            else
            {
                Console.WriteLine($"Вагон {i + 1}: все места заняты.");
            }
        }
    }
}
