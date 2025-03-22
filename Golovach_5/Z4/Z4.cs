using System;

public interface ICooler
{
    void AdjustTemperature(int degrees);
}

public interface IHeater
{
    void AdjustTemperature(int degrees);
}

public class ClimateControl : ICooler, IHeater
{
    void ICooler.AdjustTemperature(int degrees)
    {
        Console.WriteLine($"Охлаждение: Температура снижена на {degrees} градусов.");
    }
    void IHeater.AdjustTemperature(int degrees)
    {
        Console.WriteLine($"Отопление: Температура повышена на {degrees} градусов.");
    }
}

class Program
{
    static void Main()
    {
        ClimateControl climateControl = new ClimateControl();

        ICooler cooler = climateControl;
        cooler.AdjustTemperature(5);

        IHeater heater = climateControl;
        heater.AdjustTemperature(3);
    }
}
