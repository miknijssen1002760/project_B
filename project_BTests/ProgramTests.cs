using Login.Controllers;
using Login.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Login.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void MainTest()
        {
            Users whee = new Users();
            whee.Create("Geoff@suckmyass.com", "Yaboi", whee);
            User current = whee.FindUser("Geoff@suckmyass.com");
            Console.WriteLine(current.Password);
            whee.passwordChange(Console.ReadLine(), current);
            Console.WriteLine(current.Password);
        }
    }
}