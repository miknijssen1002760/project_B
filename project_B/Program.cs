using project_B.Views;
using project_B.Controllers;
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
            string[] LoginMenu = { "Login", "Register", "Exit" };
            int CurrentSelection = MenuCreator.MultipleChoice(true, "===Account===", LoginMenu);

            switch (CurrentSelection)
            {
                case 0:
                    Login.LoginFun();
                    break;
                case 1:
                    Registreren.Register();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;


            }
        }
        public static void FlightMenu()
        {
            string[] FlightMenu = { "Beschikbare vluchten", "Vlucht Boeken", "Geboekte Vluchten","Account Settings", "Exit" };
            int CurrentSelection = MenuCreator.MultipleChoice(true, "===Menu===", FlightMenu);

            switch (CurrentSelection)
            {
                case 0:
                    AvailableFlights.Show();
                    break;

                case 1:
                    MakeReservation.Show();
                    break;

                case 2:
                    Reservations.Show();
                    break;

                case 3:
                    break;

                case 4:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}