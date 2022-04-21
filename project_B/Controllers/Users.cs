using Login.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Login.Controllers
{
    public class Users
    {
        public List<User> users;
        string Path = @"Data/Users.json";
        public int i = 3; 

        public Users()
        {
            Load();
        }

        public void Load()
        {
            string JsonString = File.ReadAllText(Path);
            users = JsonSerializer.Deserialize<List<User>>(JsonString);
        }

        public User FindUser(string name)
        {
            return users.Find(i => i.UserName == name);
        }

        public User Create()
        {
            User newUser = new User();
            newUser.Id = i;
            Console.WriteLine("Enter Username: ");
            newUser.UserName = Console.ReadLine();
            Console.WriteLine("Enter Password");
            newUser.Password = Console.ReadLine();
            i += 1;
            users.Add(newUser);
            Write();
            return newUser;

        }
        public void Write()
        {
            File.WriteAllText(Path, JsonSerializer.Serialize<List<User>>(users));
        }

        public bool PassCheck(string pass)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Enter password");
                string passAttempt = Console.ReadLine();
                if (passAttempt == pass)
                {
                    return true;
                }
                else 
                    Console.WriteLine("Wrong password");
            }
            Console.WriteLine("Too many wrong attempts");
            return false;
        }

        public User Login(Users x)
        {
            Console.WriteLine("Username: ");
            User CurrentUser = x.FindUser(Console.ReadLine());
            if (CurrentUser == null)
            {
                Console.WriteLine("No account found, would you like to make one? [y/n]");
                string ans = Console.ReadLine();
                if (ans == "y")
                {
                    CurrentUser = Create();
                    return CurrentUser;
                }
            }
            if (x.PassCheck(CurrentUser.Password))
            {
                return CurrentUser;
            }
            else
            {
                return null;
            }
        }
    }

}
