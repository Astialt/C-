using System;

class Program
{
    static void Main()
    {
        double A = 0;    
        double B = 1;     
        int M = 20;        

        double H = (B - A) / M;

        Console.WriteLine("Табулирование функции F(x) = arctg(x)");

        for (int i = 0; i <= M; i++)
        {
            double x = A + i * H;            
            double F = Math.Atan(x);          

            Console.WriteLine($"x = {x:F2}, F(x) = {F:F6}"); 
        }
    }
}
