using Login.Controllers;
using Login.Models;
﻿using project_B.Controllers;
using project_B.Models;
using System;
using System.Collections.Generic;

namespace Program
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
        static void DisplayList(List<Flight> list)
        {
            foreach (Flight flight in list)
            {
                Console.WriteLine(flight.Date);
            }
        }
        static void Main(string[] args)
        {
            EditDestination("London", "London", "New York", "Tokyo");
            Users accounts = new Users();
            Flights flightController = new Flights();
            //Console.WriteLine(accounts.users);
            User MainUser = accounts.Login(accounts);
            if (MainUser == null)
            {
                Console.WriteLine("Try again later");
            }
            else
            {
                Console.WriteLine($"Welcome {MainUser.UserName}, what would you like to do today?");
            }
            Flight currentFlight = flightController.getId(1);
            string Destination;
            Console.Write("waar gaat de reis naartoe? ");
            Destination = Console.ReadLine();
            Console.WriteLine($"Bestemming: {Destination}");
            DisplayList(flightController.GetFlights(Destination));
        }


    }
}
