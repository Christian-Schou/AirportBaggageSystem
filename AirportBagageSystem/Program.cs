using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportBagageSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            BaggageHandler provider = new BaggageHandler();
            ArrivalsMonitor observer1 = new ArrivalsMonitor("BaggageClaimMonitor1");
            ArrivalsMonitor observer2 = new ArrivalsMonitor("SecurityExit");

            //Provider = FlightNo, From, Carousel
            provider.BaggageStatus(712, "Billund", 3);
            observer1.Subscribe(provider);
            provider.BaggageStatus(712, "København", 3);
            provider.BaggageStatus(400, "Aalborg", 1);
            provider.BaggageStatus(712, "Aarhus", 3);
            observer2.Subscribe(provider);
            provider.BaggageStatus(511, "Odense", 2);
            provider.BaggageStatus(712);
            observer2.Unsubscribe();
            provider.BaggageStatus(400);
            provider.LastBaggageClaimed();

            //Wait for the user to close the application
            Console.ReadKey();

        }
    }
}
