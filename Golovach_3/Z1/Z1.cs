using System;

class A
{
    private int a;
    private int b;
    public A(int a, int b)
    {
        this.a = a;
        this.b = b;
    }
    public double CalculateExpression()
    {
        if (a == 0)
        {
            throw new DivideByZeroException("Значение 'a' не должно быть равно нулю.");
        }
        return (-b + 1.0 / a) / 3.0;
    }
    public int CubeSum()
    {
        int sum = a + b;
        return sum * sum * sum;
    }

    public void Display()
    {
        Console.WriteLine($"Значения: a = {a}, b = {b}");
        Console.WriteLine($"Результат выражения: {CalculateExpression()}");
        Console.WriteLine($"Куб суммы a и b: {CubeSum()}");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введите значение a: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите значение b: ");
        int b = Convert.ToInt32(Console.ReadLine());

        A obj = new A(a, b);

    
        try
        {
            obj.Display();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
