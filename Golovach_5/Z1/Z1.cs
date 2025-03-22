using System;
public abstract class OutputDevice
{
    public abstract void DisplayInfo();
}

public class Monitor : OutputDevice
{
    public string Resolution { get; set; } 

    public Monitor(string resolution)
    {
        Resolution = resolution;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Устройство: Монитор. Разрешение: {Resolution}.");
    }
}

public class Printer : OutputDevice
{
    public string PaperSize { get; set; } 

    public Printer(string paperSize)
    {
        PaperSize = paperSize;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Устройство: Принтер. Формат бумаги: {PaperSize}.");
    }
}

public class Projector : OutputDevice
{
    public int Lumens { get; set; } 

    public Projector(int lumens)
    {
        Lumens = lumens;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Устройство: Проектор. Яркость: {Lumens} люмен.");
    }
}

class Program
{
    static void Main()
    {
        OutputDevice[] devices = new OutputDevice[]
        {
            new Monitor("1920x1080"),   
            new Printer("A4"),           
            new Projector(3000)          
        };

        Console.WriteLine("Информация об устройствах вывода:");
        foreach (var device in devices)
        {
            device.DisplayInfo();
        }
    }
}
