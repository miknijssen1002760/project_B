using Microsoft.VisualStudio.TestTools.UnitTesting;
using project_B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_B.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void GetFlightsTest()
        {
            string name = "London";
            Flights whee = new Flights();
            Assert.IsNotNull(whee.GetFlights(name));
        }
    }
}