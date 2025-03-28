using System;

namespace TransportStrategyExample
{
    public interface ITransportStrategy
    {
        void Deliver(string destination);
    }
    public class CarTransport : ITransportStrategy
    {
        public void Deliver(string destination)
        {
            Console.WriteLine("Доставка на автомобиле до " + destination);
        }
    }
    public class BikeTransport : ITransportStrategy
    {
        public void Deliver(string destination)
        {
            Console.WriteLine("Доставка на велосипеде до " + destination);
        }
    }

    public class PublicTransport : ITransportStrategy
    {
        public void Deliver(string destination)
        {
            Console.WriteLine("Доставка с использованием общественного транспорта до " + destination);
        }
    }
}
