using System;
using TransportStrategyExample;

namespace TransportStrategyExample
{
    public class TransportService
    {
        private ITransportStrategy _transportStrategy;

        public TransportService(ITransportStrategy strategy)
        {
            _transportStrategy = strategy;
        }

        public void SetStrategy(ITransportStrategy strategy)
        {
            _transportStrategy = strategy;
        }

        public void Deliver(string destination)
        {
            _transportStrategy.Deliver(destination);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TransportService service = new TransportService(new CarTransport());
            service.Deliver("Центр города");

            service.SetStrategy(new BikeTransport());
            service.Deliver("Парковая зона");

            service.SetStrategy(new PublicTransport());
            service.Deliver("Пригороды");

            Console.WriteLine("Доставка завершена.");
            Console.ReadLine();
        }
    }
}
