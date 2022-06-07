using Microsoft.VisualStudio.TestTools.UnitTesting;
using project_B.Models;
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

        [TestMethod()]
        public void nameChangeTest()
        {
            User user = users.FindUser("test@test.nl");
            users.nameChange("test123", "persoon", "test", user);
            if (!(user.FirstName == "persoon"))
            {
                Assert.Fail();
            }
            if (!(user.LastName == "test"))
            {
                Assert.Fail();
            }
            users.nameChange("test123", "test", "persoon", user);
        }

        [TestMethod()]
        public void numberChangeTest()
        {
            User user = users.FindUser("test@test.nl");
            users.numberChange("test123", "0000000001", user);
            if (!(user.PhoneNumber == "0000000001"))
            {
                Assert.Fail();
            }
            users.numberChange("test123", "0000000000", user);
        }

        [TestMethod()]
        public void birthChangeTest()
        {
            User user = users.FindUser("test@test.nl");
            users.birthChange("test123", "01/00/0000", user); 
            if (!(user.Birthday == "01/00/0000"))
            {
                Assert.Fail();
            }
            users.birthChange("test123", "00/00/0000", user);
        }
        [TestMethod()]
        public void emailChangeTest()
        {
            User user = users.FindUser("test@test.nl");
            users.emailChange("test123", "testemail@test.nl", user);
            //Assert.IsNull(users.FindUser("test@test.nl"));
            if (!(user.UserName == "testemail@test.nl"))
            {
                Assert.Fail();
            }
            users.emailChange("test123", "test@test.nl", user);
        }

        [TestMethod()]
        public void passChangeTest()
        {
            User user = users.FindUser("test@test.nl");
            users.passChange("test123", "test1234", user);
            if (!(user.Password == "test1234"))
            {
                Assert.Fail();
            }
            users.passChange("test1234", "test123", user);
        }
    }
}