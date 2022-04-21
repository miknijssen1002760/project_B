using project_B;
using System;

namespace project_B
{
    public class Program
    {
        static void Main(string[] args)
        {
            Flights flightController = new Flights();
            //Flight currentFlight = flightController.getId(4);
            //currentFlight.Destination = "New York";
            //currentFlight.writeToFile();
            string Destination;
            Console.Write("waar gaat de reis naartoe? ");
            Destination = Console.ReadLine();
            Console.WriteLine($"Bestemming: {Destination}");
            Console.WriteLine(flightController.GetFlights(Destination));
        }
    }
}