using System;
using System.IO;

public class MathException : Exception
{
    public MathException() : base("Ошибка при выполнении математической операции.") { }
    public MathException(string message) : base(message) { }
    public MathException(string message, Exception innerException) : base(message, innerException) { }
}

public class MathOperations
{
    public int Divide(int a, int b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Деление на ноль невозможно.");
        }
        return a / b;
    }
}
public class CalculationManager
{
    private readonly MathOperations _mathOperations;

    public CalculationManager()
    {
        _mathOperations = new MathOperations();
    }
    public int PerformDivision(int a, int b)
    {
        try
        {
            return _mathOperations.Divide(a, b);
        }
        catch (DivideByZeroException ex)
        {
            LogException(ex);
            throw new MathException("Ошибка при выполнении операции деления.", ex);
        }
    }

    private void LogException(Exception ex)
    {
        string logMessage = $"[{DateTime.Now}] Исключение: {ex.Message}\nСтек вызовов:\n{ex.StackTrace}\n";
        File.AppendAllText("error_log.txt", logMessage);
        Console.WriteLine("Исключение записано в лог.");
    }
}

class Program
{
    static void Main()
    {
        CalculationManager calculationManager = new CalculationManager();

        try
        {
            Console.WriteLine("Результат деления: " + calculationManager.PerformDivision(10, 2));

            Console.WriteLine("Результат деления: " + calculationManager.PerformDivision(10, 0));
        }
        catch (MathException ex)
        {
            Console.WriteLine($"Обработка MathException: {ex.Message}");
            if (ex.InnerException != null)
            {
                Console.WriteLine($"Внутреннее исключение: {ex.InnerException.Message}");
            }
        }
        finally
        {
            Console.WriteLine("Программа завершена.");
        }
    }
}
