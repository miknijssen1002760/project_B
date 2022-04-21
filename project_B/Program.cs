using project_B;
using System;

namespace project_B
{
    public class Program
    {
        static void EditDestination(string dest1, string dest2, string dest3, string dest4)
        {
            Flights flightController = new Flights();
            Flight currentFlight = flightController.getId(1);
            currentFlight.Destination = dest1;
            currentFlight.writeToFile();
            currentFlight = flightController.getId(2);
            currentFlight.Destination = dest2;
            currentFlight.writeToFile();
            currentFlight = flightController.getId(3);
            currentFlight.Destination = dest3;
            currentFlight.writeToFile();
            currentFlight = flightController.getId(4);
            currentFlight.Destination = dest4;
            currentFlight.writeToFile();
        }
        static void Main(string[] args)
        {
            EditDestination("Tokyo", "London", "New York", "Tokyo");
            Flights flightController = new Flights();
            string Destination;
            Console.Write("waar gaat de reis naartoe? ");
            Destination = Console.ReadLine();
            Console.WriteLine($"Bestemming: {Destination}");
            Console.WriteLine(flightController.GetFlights(Destination));
        }
    }
}