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

            Console.WriteLine("Enter email: ");
            string mail = Console.ReadLine().ToLower();
            if (accounts.FindUser(mail) == null)
            {
                string[] RegisterAnswer = { "Yes", "No", "Exit" };
                int CurrentSelection = MenuCreator.MultipleChoice(true, "No account found, would you like to make one?", RegisterAnswer);

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
                Console.WriteLine("Enter password: ");
                string pass = Console.ReadLine();
                currentUser = accounts.Login(accounts, mail, pass);
                if (currentUser == null)
                {
                    Console.WriteLine("Password Incorrect please try again");
                    Thread.Sleep(1500);
                    Login.LoginFun();
                }
            }
        }
        public static void Register()
        {
            Console.Clear();
            Users accounts = new Users();
            

            Console.WriteLine("Enter email: ");
            string mail = Console.ReadLine();

            Console.WriteLine("What is your first name: ");
            string firstname = Console.ReadLine();

            Console.WriteLine("What is your last name: ");
            string lastname = Console.ReadLine();

            Console.WriteLine("What is your birthday DD/MM/YYYY: ");
            string birthday = Console.ReadLine();

            Console.WriteLine("What is your phone number: ");
            string phonenumber = Console.ReadLine();

            Console.WriteLine("Enter password: ");
            string pass = Console.ReadLine();


            currentUser = accounts.Create(mail, pass, firstname, lastname, birthday, phonenumber);
            if (currentUser == null)
            {
                Console.WriteLine("Invalid email or email is already in use");
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
