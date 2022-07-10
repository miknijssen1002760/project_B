using Microsoft.VisualStudio.TestTools.UnitTesting;
using project_B.Controllers;
using project_B.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_B.Controllers.Tests
{
    [TestClass()]
    public class UsersTests2
    {
        Users user = new Users();
        [TestMethod()] // Sem
        public void UserCreateTest()
        {
            user.Create("TeStiNg@CrEate.com", "test1", "test", "creation", "29/11/2003", "0638603401");
            Assert.IsNotNull(user.FindUser("testing@create.com"));
        }

        [TestMethod()] // Sem
        public void EmailChangeTest()
        {
            User currentUser = user.FindUser("testing@create.com");
            user.emailChange("test1", "TesTed@Create.com", currentUser);
            Assert.IsNotNull(user.FindUser("tested@create.com"));
            user.emailChange("test1", "testing@create.com", currentUser);
        }
       
        [TestMethod()] // Sem
        public void NameChangeTest()
        {
            User currentUser = user.FindUser("testing@create.com");
            user.nameChange("test1", "changeTest", "testedChange", currentUser);
            Assert.IsTrue(currentUser.FirstName == "changeTest" && currentUser.LastName == "testedChange");
            user.nameChange("test1", "test", "creation", currentUser);


        }

    }

}

