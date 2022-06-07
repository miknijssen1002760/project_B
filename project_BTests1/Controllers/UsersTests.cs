using Microsoft.VisualStudio.TestTools.UnitTesting;
using project_B.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_B.Controllers.Tests
{
    [TestClass()]
    public class UsersTests
    {
        Users users = new Users();
        [TestMethod()]
        public void FindUserTest()
        {
            Assert.IsNotNull(users.FindUser("test@test.nl"));
            Assert.IsNull(users.FindUser("test12@test.nl"));
        }

        [TestMethod()]
        public void CreateTest()
        {
            users.Create("test123@test.nl", "test123", "test123", "persoon", "00/00/0000", "0000000000");
            Assert.IsNotNull(users.FindUser("test123@test.nl"));
        }

        [TestMethod()]
        public void PassCheckTest()
        {
            Assert.IsTrue(users.PassCheck("test", "test"));
            Assert.IsFalse(users.PassCheck("test", "test123"));
        }

        [TestMethod()]
        public void LoginTest()
        {
            Assert.IsNotNull(users.Login(users, "test@test.nl", "test123"));
            Assert.IsNull(users.Login(users, "test@test.com", "test123"));
        }

        [TestMethod()]
        public void emailCheckTest()
        {
            Assert.IsTrue(users.emailCheck("test1@test.nl"));
            Assert.IsFalse(users.emailCheck("testtest.nl"));
            Assert.IsFalse(users.emailCheck("test@test.nl"));
        }

        [TestMethod()]
        public void removeTest()
        {
            users.remove(users.FindUser("test123@test.nl"));
            Assert.IsNull(users.FindUser("test123@test.nl"));
        }

        [TestMethod()]
        public void removeTest1()
        {
            users.Create("test123@test.nl", "test123", "test123", "persoon", "00/00/0000", "0000000000");
            users.remove(users.FindUser("test123@test.nl"), users);
            Assert.IsNull(users.FindUser("test123@test.nl"));
        }

        [TestMethod()]
        public void logoutTest()
        {
            Assert.IsNull(users.logout());
        }
    }
}