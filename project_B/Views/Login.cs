using project_B.Controllers;
using project_B.Models;
using System;
using System.Threading;
using System.Collections.Generic;

namespace project_B.Views
{
    public class Login
    {
        public static void LoginFun()
        {
            Console.Clear();
            Users accounts = new Users();
            User currentUser = new User();

            Console.WriteLine("Enter email: ");
            string mail = Console.ReadLine();
            if (accounts.FindUser(mail) == null)
            {
                string[] RegisterAnswer = { "Yes", "No", "Exit" };
                int CurrentSelection = MenuCreator.MultipleChoice(true, "No account found, would you like to make one?", RegisterAnswer);

                switch (CurrentSelection)
                {
                    case 0:
                        Registreren.Register();
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







                //Console.WriteLine($"Hello {currentUser.UserName}, what would you like to do today?");
                //Console.WriteLine("[1] Book Flight\n[2] Check Flights\n[3] Log Out\n[4] Delete Account");
                //string ans2 = Console.ReadLine();
                //if (ans2 == "1")
                //{
                //    Console.WriteLine();
                //}

                //if (ans2 == "2")
                //{
                //    Console.WriteLine();
                //}

                //if (ans2 == "3")
                //{
                //    currentUser = accounts.logout();
                //}

                //if (ans2 == "4")
                //{
                //    Console.WriteLine("Are you sure you want to remove your account? [y/n]");
                //    string ans3 = Console.ReadLine();
                //    if (ans3 == "y")
                //    {
                //        accounts.remove(currentUser, accounts);
                //    }
                //    else if (ans3 == "n")
                //    {
                //        Console.WriteLine("Bruh");
                //    }
                //    else
                //    {
                //        Console.WriteLine("Invalid Character");
                //    }
                //}
            }
        }
    }
