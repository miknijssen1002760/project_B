using project_B.Controllers;
using project_B.Models;
using System;
using System.Threading;
using System.Collections.Generic;

namespace project_B.Views
{
    public class Login

    {
        public static User currentUser;
        public static void LoginFun()
        {
            Console.Clear();
            Users accounts = new Users();

            Console.WriteLine("Voer in email: ");
            string mail = Console.ReadLine().ToLower();
            if (accounts.FindUser(mail) == null)
            {
                string[] RegisterAnswer = { "Ja", "Nee", "Exit" };
                int CurrentSelection = MenuCreator.MultipleChoice(true, "Geen account gevonden, wil je er één aanmaken?", RegisterAnswer);

                switch (CurrentSelection)
                {
                    case 0:
                        Register();
                        break;

                    case 1:
                        LoginFun();  
                        break;

                    case 2:
                        Environment.Exit(0);
                        break;

                }
            }

            else
            {
                Console.WriteLine("Voer in wachtwoord: ");
                string pass = Console.ReadLine();
                currentUser = accounts.Login(accounts, mail, pass);
                if (currentUser == null)
                {
                    Console.WriteLine("Verkeerd wactwoord, probeer opnieuw");
                    Thread.Sleep(1500);
                    Login.LoginFun();
                }
                project_B.MainMenu();
            }
        }
        public static void Register()
        {
            Console.Clear();
            Users accounts = new Users();
            

            Console.WriteLine("Voer in email: ");
            string mail = Console.ReadLine();

            Console.WriteLine("Wat is je voornaam: ");
            string firstname = Console.ReadLine();

            Console.WriteLine("Wat is je achternaam: ");
            string lastname = Console.ReadLine();

            Console.WriteLine("Wat is je verjaardag DD/MM/YYYY: ");
            string birthday = Console.ReadLine();

            Console.WriteLine("Wat is je telefoonnummer: ");
            string phonenumber = Console.ReadLine();

            Console.WriteLine("Voer in wachtwoord: ");
            string pass = Console.ReadLine();


            currentUser = accounts.Create(mail, pass, firstname, lastname, birthday, phonenumber);
            project_B.MainMenu();
            if (currentUser == null)
            {
                Console.WriteLine("Onvalide email of email is al in gebruik");
                Thread.Sleep(1500);
                Register();
            }
        }
    
    public static string[] IsAdmin()
        {
            
            if (currentUser.IsAdmin == true)
            {
                string[] Options = { "Beschikbare vluchten", "Vlucht Boeken", "Geboekte Vluchten", "Account Settings", "Exit", "Admin Settings" };
                return Options;
            }
            else
            {
                string[] Options = { "Beschikbare vluchten", "Vlucht Boeken", "Geboekte Vluchten", "Account Settings", "Exit"};
                return Options;
            }
             
        }

    public static string ReturnUser()
        {
            return currentUser.UserName;
    }
        
    }
}
