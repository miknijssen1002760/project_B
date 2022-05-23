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

        public User Create(string name, string pass, Users x)
        {
            User newUser = new User();
            newUser.Id = 3;
            if (emailCheck(name, x))
            {
                newUser.UserName = name;
                newUser.Password = pass;
                users.Add(newUser);
                Write();
                return newUser;
            }
            else
            {
                return null;
            }
        }
        public void Write()
        {
            File.WriteAllText(Path, JsonSerializer.Serialize<List<User>>(users));
        }

        public bool PassCheck(string pass, string passAttempt)
        {
            if (passAttempt == pass)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public User Login(Users x, string userName, string passWord)
        {
            User CurrentUser = x.FindUser(userName);
            if (CurrentUser == null)
            {
                return null;
            }
            else
            {
                if (x.PassCheck(CurrentUser.Password, passWord))
                {
                    return CurrentUser;
                }
                else
                {
                    return null;
                }
            }

        }

        public bool emailCheck(string email, Users x)
        {
            return (email.Contains("@") && x.FindUser(email) == null);
        }

        public void remove(User user, Users x)
        {
            users.Remove(user);
            Write();
        }

        public User logout()
        {
            return null;
        }
    }

}
