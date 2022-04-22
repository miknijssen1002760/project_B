using Login.Controllers;
using Login.Models;
﻿using project_B;
using System;

namespace Login
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
            Users accounts = new Users();
            Console.WriteLine(accounts.users);
            User MainUser = accounts.Login(accounts);
            if (MainUser == null)
            {
                Console.WriteLine("Try again later");
            }
            else
            {
                Console.WriteLine($"Welcome {MainUser.UserName}, what would you like to do today?");
            }
            Flights flightController = new Flights();
            string Destination;
            Console.Write("waar gaat de reis naartoe? ");
            Destination = Console.ReadLine();
            Console.WriteLine($"Bestemming: {Destination}");
            Console.WriteLine(flightController.GetFlights(Destination));
        }


    }
}