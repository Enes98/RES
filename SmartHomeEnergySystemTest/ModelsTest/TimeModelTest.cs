using NUnit.Framework;
using SmartHomeEnergySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeEnergySystemTest.ModelsTest
{
    [TestFixture]
    public class TimeModelTest
    {
        [Test]
        [TestCase()]
        public void ConstructorPrazan()
        {
            TimeModel time = new TimeModel();
            
            Assert.AreEqual(0, time.Hour);
            Assert.AreEqual(0, time.Minute);
            Assert.AreEqual(0, time.Second);
        }
    }
}
