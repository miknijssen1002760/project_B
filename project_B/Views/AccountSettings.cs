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
        public static Users accounts = new Users();
        public static string currentMail = Login.ReturnUser();
        public static User currentUser = accounts.FindUser(currentMail);
        

        public static void Settings()
        {
            string[] Settings = {"Wijzig Naam", "Wijzig Email", "Wijzig telefoonnummer", "Wijzig geboortedag", "Wijzig wachtwoord", "Verwijder Account", "Vorig Menu", "exit" };
            int CurrentSelection = MenuCreator.MultipleChoice(true, "===Account Settings===", Settings);

            switch (CurrentSelection)
            {
                case 0:
                    ChangeName();
                    break;

                case 1:
                    ChangeEmail();
                    break;

                case 2:
                    ChangeNumber();
                    break;

                case 3:
                    ChangeBirthday();
                    break;

                case 4:
                    DeleteAccount();
                    break;

                case 5:
                    DeleteAccount();
                    break;

                case 6:
                    project_B.MainMenu();
                    break;

                case 7:
                    Environment.Exit(0);
                    break;
            }
        }

        public static void DeleteAccount()
        {
            
            string[] options = { "Ja", "Nee" };
            int CurrentSelection = MenuCreator.MultipleChoice(true, "Wil je je account verwijderen?", options);

            switch (CurrentSelection)
            {
                case 0:
                    Console.Clear();
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
            string[] options = { "Ja", "Nee" };
            int CurrentSelection = MenuCreator.MultipleChoice(true, "Wil je je geboortedag wijzigen?", options);

            switch (CurrentSelection)
            {
                case 0:
                    string Password = askPassword();
                    string newBirthdate = ToChange("geboortedag");

                    accounts.birthChange(Password, newBirthdate, currentUser);
                    project_B.HomeScreen();
                    break;

                case 1:
                    project_B.MainMenu();
                    break;
            }
        }

        public static void ChangeName()
        {
            string[] options = { "Ja", "Nee" };
            int CurrentSelection = MenuCreator.MultipleChoice(true, "Wil je je naam wijzigen?", options);

            switch (CurrentSelection)
            {
                case 0:
                    string Password = askPassword();
                    string newFirstname = ToChange("voornaam");
                    string newLastname = ToChange("achternaam");
                    accounts.nameChange(Password, newFirstname, newLastname, currentUser);
                    project_B.HomeScreen();
                    break;

                case 1:
                    project_B.MainMenu();
                    break;
            }
        }

        public static void ChangeNumber()
        {
            string[] options = { "Ja", "Nee" };
            int CurrentSelection = MenuCreator.MultipleChoice(true, "Wil je je telefoonnummer wijzigen?", options);

            switch (CurrentSelection)
            {
                case 0:
                    string Password = askPassword();
                    string newNumber = ToChange("telefoonnummer");

                    accounts.numberChange(Password, newNumber, currentUser);
                    project_B.HomeScreen();
                    break;

                case 1:
                    project_B.MainMenu();
                    break;
            }
        }

        public static void ChangeEmail()
        {
            string[] options = { "Ja", "Nee" };
            int CurrentSelection = MenuCreator.MultipleChoice(true, "Wil je je email wijzigen?", options);

            switch (CurrentSelection)
            {
                case 0:
                    string Password = askPassword();
                    string newEmail = ToChange("Email");

                    accounts.emailChange(Password, newEmail, currentUser);
                    project_B.HomeScreen();
                    break;

                case 1:
                    project_B.MainMenu();
                    break;
            }
        }

        public static void ChangePassword()
        {
            string[] options = { "Ja", "Nee" };
            int CurrentSelection = MenuCreator.MultipleChoice(true, "Wil je je wachtwoord wijzigen?", options);

            switch (CurrentSelection)
            {
                case 0:
                    string Password = askPassword();
                    string newPassword = ToChange("Wachtwoord: ");

                    accounts.passChange(Password, newPassword, currentUser);
                    project_B.HomeScreen();
                    break;

                case 1:
                    project_B.MainMenu();
                    break;
            }
        }

        public static string askPassword()
        {
            Console.Clear();
            Console.WriteLine("Voer uw wachtwoord in:");
            string Password = Console.ReadLine();
            return Password;

        }

        public static string ToChange(string ToChange)
        {
            Console.Clear();
            Console.WriteLine($"Voer het nieuwe {ToChange} in: ");
            string NewThing = Console.ReadLine();
            return NewThing;
        }
    }
}
