using project_B.Models;
using project_B.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace project_B.Controllers

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

        public User Create(string mail, string pass, string firstname, string lastname, DateTime birthday, string phonenumber)
        {
            User newUser = new User();
            if (emailCheck(mail))
            {
                newUser.UserName = mail;
                newUser.Password = pass;
                newUser.FirstName = firstname;
                newUser.LastName = lastname;
                newUser.Birthday = birthday;
                newUser.PhoneNumber = phonenumber;
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

        public bool emailCheck(string email)
        {
            return (email.Contains("@") && FindUser(email) == null);
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

        public bool emailChange(string Password, string email, User x)
        {
            if (Password == x.Password)
            {
                if (emailCheck(email))
                {
                    x.UserName = email;
                    Write();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool nameChange(string Password, string newFirstname, string newLastname, User x)
        {
            if (Password == x.Password)
            {
                x.FirstName = newFirstname;
                x.LastName = newLastname;
                Write();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool birthChange(string Password, DateTime newBirth, User x)
        {
            if (Password == x.Password)
            {
                x.Birthday = newBirth;
                Write();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool numberChange(string Password, string newNum, User x)
        {
            if (Password == x.Password)
            {
                x.PhoneNumber = newNum;
                Write();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool passChange(string Password, string newPass, User x)
        {
            if (Password == x.Password)
            {
                x.Password = newPass;
                Write();
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}