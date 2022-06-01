﻿using project_B.Controllers;
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
        }
    }
}
