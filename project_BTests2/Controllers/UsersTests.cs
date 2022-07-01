﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using project_B.Controllers;
using project_B.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_B.Controllers.Tests
{
    //Sem Hirschbein
    [TestClass()]
    public class UsersTests
    {
        Users user = new Users();
        [TestMethod()]
        public void UserCreateTest()
        {
            user.Create("TeStiNg@CrEate.com", "test1", "test", "creation", "29/11/2003", "0638603401");
            Assert.IsNotNull(user.FindUser("testing@create.com"));
        }

        [TestMethod()]
        public void EmailChangeTest()
        {
            User currentUser = user.FindUser("Testing@create.com");
            user.emailChange("test1", "TesTed@Create.com", currentUser);
            Assert.IsNotNull(user.FindUser("tested@create.com"));
        }


    }
}