﻿using Login.Controllers;
using Login.Models;
﻿using project_B;
using System;

namespace Login
{
    public class Program
    {
        public static void Main(string[] args)
        {
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
            Flight currentFlight = flightController.getId(2);
            currentFlight.Destination = "London";
            currentFlight.writeToFile();
            Console.Write(flightController.GetFlights(GetDestination()));
        }


    }
}