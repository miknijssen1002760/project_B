using Login.Controllers;
using Login.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Login.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void MainTest()
        {
            string name = "GalaxyRacer";
            Users whee = new Users();
            Assert.IsNotNull(whee.FindUser(name));
        }
    }
}