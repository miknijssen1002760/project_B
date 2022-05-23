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

            Console.WriteLine("Enter password: ");
            string pass = Console.ReadLine();

            currentUser = accounts.Create(mail, pass, accounts);
            if (currentUser == null)
            {
                Console.WriteLine("Invalid email or email is already in use");
                Thread.Sleep(1500);
                Register();
            }
        }
    }
}


