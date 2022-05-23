using Login.Controllers;
using Login.Models;
using System;

namespace Login
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Users accounts = new Users();
            User currentUser = new User();
            Console.WriteLine("Welcome\nWhat would you like to do:\n[1] Log In\n[2] Sign Up");
            string ans = Console.ReadLine();
            if(ans == "1")
            {
                Console.WriteLine("Enter email: ");
                string mail = Console.ReadLine();
                Console.WriteLine("Enter password: ");
                string pass = Console.ReadLine();
                currentUser = accounts.Login(accounts, mail, pass);
            }
            else if(ans == "2")
            {
                Console.WriteLine("Enter email: ");
                string mail = Console.ReadLine();
                Console.WriteLine("Enter password: ");
                string pass = Console.ReadLine();
                currentUser = accounts.Create(mail, pass, accounts);
                if (currentUser == null)
                {
                    Console.WriteLine("Invalid email or email is already in use");
                }
            }
            else
            {
                Console.WriteLine("Invalid character");
            }

            Console.WriteLine($"Hello {currentUser.UserName}, what would you like to do today?");
            Console.WriteLine("[1] Book Flight\n[2] Check Flights\n[3] Log Out\n[4] Delete Account");
            string ans2 = Console.ReadLine();
            if(ans2 == "1")
            {
                Console.WriteLine();
            }
            if (ans2 == "2")
            {
                Console.WriteLine();
            }
            if (ans2 == "3")
            {
                currentUser = accounts.logout();
            }
            if (ans2 == "4")
            {
                Console.WriteLine("Are you sure you want to remove your account? [y/n]");
                string ans3 = Console.ReadLine();
                if (ans3 == "y")
                {
                    accounts.remove(currentUser, accounts);
                }
                else if (ans3 == "n")
                {
                    Console.WriteLine("Bruh");
                }
                else
                {
                    Console.WriteLine("Invalid Character");
                }
            }
            if (ans2 == "5")
            {
                Console.WriteLine("Enter old password");
                string old = Console.ReadLine();
                Console.WriteLine("Enter new password");
                string newp = Console.ReadLine();
                accounts.passwordChange(old, newp, currentUser);
            }
        }


    }
}