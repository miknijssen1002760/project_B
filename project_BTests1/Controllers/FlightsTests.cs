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
    public class FlightsTests
    {
        Flights flights = new Flights();
        [TestMethod()]
        public void getLastIDTest()
        {
            Assert.AreEqual(flights.getLastID(), 4);
        }
        
    }
}