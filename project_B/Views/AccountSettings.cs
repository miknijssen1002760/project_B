using System;
using project_B.Models;
using project_B.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_B.Views
{
    internal class AccountSettings
    {
        public static User currentUser = Login.ReturnUser();
        public static Users accounts = new Users();
        public static void Settings()
        {
            string[] Settings = { "Delete Account", "Vorig Menu", "exit" };
            int CurrentSelection = MenuCreator.MultipleChoice(true, "===Account Settings===", Settings);

            switch (CurrentSelection)
            {
                case 0:
                    DeleteAccount();
                    break;

                case 1:
                    project_B.MainMenu();
                    break;

                case 2:
                    Environment.Exit(0);
                    break;
            }
        }

        public static void DeleteAccount()
        {
            
            string[] options = { "Yes", "No" };
            int CurrentSelection = MenuCreator.MultipleChoice(true, "Do you want to delete your account?", options);

            switch (CurrentSelection)
            {
                case 0:
                    accounts.remove(currentUser, accounts);
                    project_B.HomeScreen();
                    break;

                case 1:
                    project_B.MainMenu();
                    break;
            }

        }

        public static void ChangeBirthday()
        {
            string[] options = { "Yes", "No" };
            int CurrentSelection = MenuCreator.MultipleChoice(true, "Do you want to change your birthdate?", options);

            switch (CurrentSelection)
            {
                case 0:
                    string Password = askPassword();
                    string NewBirthdate = ToChange("Birthdate");

                    accounts.birthChange(Password, NewBirthdate, currentUser);
                    project_B.HomeScreen();
                    break;

                case 1:
                    project_B.MainMenu();
                    break;
            }
        }

        public static void ChangeName()
        {

        }

        public static void ChangeNumber()
        {

        }

        public static void ChangeEmail()
        {

        }

        public static void ChangePassword()
        {

        }

        public static string askPassword()
        {
            Console.WriteLine("Voer uw wachtwoord in:");
            string Password = Console.ReadLine();
            return Password;

        }

        public static string ToChange(string ToChange)
        {
            Console.WriteLine($"Voer het nieuwe {ToChange} in: ");
            string NewThing = Console.ReadLine();
            return NewThing;
        }
    }
}
