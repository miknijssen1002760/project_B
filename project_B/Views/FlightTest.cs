using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project_B.Models;
using project_B.Controllers;

namespace project_B.Views
{
    static class FlightTest
    {

        public static void EditDestination(string dest1, string dest2, string dest3, string dest4)
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
        public static void DisplayList(List<Flight> list)
        {
            foreach (Flight flight in list)
            {
                Console.WriteLine(flight.Date);
            }
        }

        public static void Test()
        {
            Console.Clear();
            EditDestination("London", "London", "New York", "Tokyo");
            Users accounts = new Users();
            Flights flightController = new Flights();
            Flight currentFlight = flightController.getId(1);
            Console.Write("waar gaat de reis naartoe? \n");
            string Destination = Console.ReadLine();
            Console.WriteLine($"Bestemming: {Destination}");
            DisplayList(flightController.GetFlights(Destination));
        }


    }
}

