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
    public class planesTests
    {
        planes planes = new planes();
        [TestMethod()]
        public void getLastIDTest()
        {
            Assert.AreEqual(planes.getLastID(),2);
        }

        [TestMethod()]
        public void getIdTest()
        {
            Assert.IsNotNull(planes.getId(2));
            Assert.IsNull(planes.getId(3));
        }
    }
}