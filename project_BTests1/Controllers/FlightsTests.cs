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

        [TestMethod()] // Jesse
        public void getLastIDTest()
        {
            Assert.AreEqual(flights.getLastID(), 4);
        }

        [TestMethod()] // Jesse
        public void getIdTest()
        {
            Assert.IsNotNull(flights.getId(3));
            Assert.IsNull(flights.getId(6));
        }

    }
}