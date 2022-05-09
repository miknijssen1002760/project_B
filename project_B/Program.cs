using project_B.FridayPrototype;
using System;

namespace project_B
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HomeScreen();
            FlightMenu();
        }
        public static void HomeScreen()
        {
            Console.WriteLine("====account====");
            Console.WriteLine("\r1. Sign in");
            Console.WriteLine("\r2. register");
            Console.Write("\nChoose an option: ");

            bool valid = false;
            while (valid == false)
            {
                valid = true;
                switch (Console.ReadLine())
                {
                    case "1":

                        Registeren.Show();
                        break;

                    case "2":
                        Login.Show();

                        break;

                    default:
                        valid = false;
                        Console.Write("This is not a valid option please try again: ");
                        break;
                }
            }
        }
        public static void FlightMenu()
        {
            Console.WriteLine("press enter to continue");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("====menu====");
            Console.WriteLine("1. beschikbare vluchten");
            Console.WriteLine("2. vlucht boeken");
            Console.WriteLine("3. geboekte vluchten");
            Console.WriteLine("4. Exit");
            Console.Write("\nChoose an option: ");

            bool valid = false;
            while (valid == false)
            {
                valid = true;
                switch (Console.ReadLine())
                {
                    case "1":
                        AvailableFlights.Show();
                        break;

                    case "2":
                        ;
                        MakeReservation.Show();
                        break;

                    case "3":
                        Reservations.Show();
                        break;

                    case "4":
                        Environment.Exit(0);
                        break;
                        
                    default:
                        valid = false;
                        Console.WriteLine("This is not a valid option please try again: ");
                        break;

                }
            }
            Console.ReadLine();
            Console.Clear();

        }
    }
}