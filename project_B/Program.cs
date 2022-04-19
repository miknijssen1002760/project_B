using project_B;
using System;

namespace project_B
{
    public class Program
    {
        public static string GetDestination()
        {
            string Destination;
            Console.Write("waar gaat de reis naartoe? ");
            Destination = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Bestemming: {Destination}");
            return Destination;
        }
        static void Main(string[] args)
        {
            Flights flightController = new Flights();
            Flight currentFlight = flightController.getId(2);
            currentFlight.Destination = "London";
            currentFlight.writeToFile();
            Console.Write(flightController.GetFlights(GetDestination()));
        }
    }
}
