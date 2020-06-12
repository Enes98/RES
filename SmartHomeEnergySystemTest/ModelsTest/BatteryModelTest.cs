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
    public class BatteryModelTest
    {
        [Test]
        [TestCase()]
        public void ConstructorPrazan()
        {
            BatteryModel battery = new BatteryModel();

            Assert.AreEqual("", battery.Name);
            Assert.AreEqual(0, battery.MaxPower);
            Assert.AreEqual(0, battery.Capacity);
            Assert.AreEqual(0, battery.CurrentCapacity);
            Assert.AreEqual(SmartHomeEnergySystem.Enums.BatteryEnum.IDLE, battery.State);
        }

        [Test]
        [TestCase("Tesla", 10.2, 11.2, 12.3)]
        public void ConstructorDobriParametri(string name, double mp, double c, double cc)
        {
            BatteryModel battery = new BatteryModel(name, mp, c, cc);

            Assert.AreEqual(name, battery.Name);
            Assert.AreEqual(mp, battery.MaxPower);
            Assert.AreEqual(c, battery.Capacity);
            Assert.AreEqual(cc, battery.CurrentCapacity);
        }

        [Test]
        [TestCase(null, -56, 65, 12.3)]
        [TestCase(null, 56, -65, 12.3)]
        [TestCase(null, 56, 65, -12.3)]
        public void ConstructorLosiParametri(string name, double mp, double c, double cc)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                BatteryModel battery = new BatteryModel(name, mp, c, cc);
            });
        }

        [Test]
        [TestCase("", 56, 65, 12.3)]
        [TestCase("test", -56, 65, 12.3)]
        [TestCase("test", 56, -65, 12.3)]
        [TestCase("test", 56, 65, -12.3)]
        public void ConstructorLosiParametri1(string name, double mp, double c, double cc)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                BatteryModel battery = new BatteryModel(name, mp, c, cc);
            });
        }
    }
}
