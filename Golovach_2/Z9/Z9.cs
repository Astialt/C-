using System;
using System.Text;
class Program
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder("Пример текста");

        Console.WriteLine($"До очистки: {sb}");
        sb.Clear();
        Console.WriteLine($"После очистки: {sb}");
    }
}
