using project_B;
using System;

namespace project_B
{
    internal class Program
    {
        static string GetDestination()
        {
            string Destination;
            Console.WriteLine("waar gaat de reis naartoe?");
            Destination = Console.ReadLine();
            Console.WriteLine($"Bestemming: {Destination}");
            return Destination;
        }
        static void Main(string[] args)
        {
            Flights flightController = new Flights();
            Flight currentFlight = flightController.getId(1);
            currentFlight.Destination = "Tokyo";
            currentFlight.writeToFile();
            flightController.displayFlights(GetDestination());
        }
    }
}
