using System;

public class OverheatException : Exception
{
    public OverheatException() : base("Температура превышает допустимое значение!") { }
    public OverheatException(string message) : base(message) { }
    public OverheatException(string message, Exception innerException) : base(message, innerException) { }
}
public class Thermostat
{
        public void CheckTemperature(int temperature)
    {
        if (temperature > 100)
        {
            throw new OverheatException($"Температура {temperature}°C превышает допустимый предел!");
        }
        Console.WriteLine($"Температура {temperature}°C в норме.");
    }
}

class Program
{
    static void Main()
    {
        Thermostat thermostat = new Thermostat();

        int[] temperatures = { 80, 100, 120 };

        foreach (int temp in temperatures)
        {
            try
            {
                thermostat.CheckTemperature(temp);
            }
            catch (OverheatException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Неизвестная ошибка: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Проверка завершена.\n");
            }
        }
    }
}
