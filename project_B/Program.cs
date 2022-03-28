using project_B;
using System;

namespace project_B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Flights flightController = new Flights();
            /*Flight currentFlight = flightController.getId(1);
            currentFlight.Destination = "Tokyo";
            currentFlight.writeToFile();*/
            flightController.displayFlights("hiroshima");
            //flightController.displayFlights(Console.ReadLine());
        }
    }
}
