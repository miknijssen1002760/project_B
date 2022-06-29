using Microsoft.VisualStudio.TestTools.UnitTesting;
using project_B.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_B.Views.Tests
{
    [TestClass()]
    public class AdminControlTests
    {
        [TestMethod()]
        public void chooseOptionTest()
        {
            Assert.AreEqual(AdminControl.chooseOption(), "3");
        }
    }
}