using project_B.Views;
using project_B.Controllers;
using project_B.Models;
using System;



namespace project_B
{
    public class project_B
    {

        public static void Main(string[] args)
        {
            HomeScreen();
            MainMenu();

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
        public static void MainMenu()
        {
            string[] MainMenu = { "Beschikbare vluchten", "Vlucht Boeken", "Geboekte Vluchten","Account Settings", "Admin Settings", "Exit" };
            int CurrentSelection = MenuCreator.MultipleChoice(true, "===Menu===", MainMenu);

            switch (CurrentSelection)
            {
                case 0:
                    FlightTest.Test();
                    break;

                case 1:
                    MakeReservation.Show();
                    break;

                case 2:
                    Reservations.Show();
                    break;

                case 3:
                    AccountSettings.Settings();
                    break;

                case 4:
                    AdminControl.adminOptions();
                    break;

                case 5:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}