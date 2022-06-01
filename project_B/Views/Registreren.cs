using System;
using project_B.Controllers;
using project_B.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace project_B.Views
{
    public static class Registreren
    {
        public static void Register()
        {
            Console.Clear();
            Users accounts = new Users();
            User currentUser = new User();

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
    }
}


