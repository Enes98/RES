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
    public class eVehicleChargerModelTest
    {
        [Test]
        [TestCase()]
        public void ConstructorPrazan()
        {
            eVehicleChargerModel vehicle = new eVehicleChargerModel();

            Assert.AreEqual("", vehicle.Name);
            Assert.AreEqual(0, vehicle.MaxPower);
            Assert.AreEqual(0, vehicle.Capacity);
            Assert.AreEqual(0, vehicle.MaxCapacity);
            Assert.AreEqual(SmartHomeEnergySystem.Enums.VehicleEnumCharging.IDLE, vehicle.Charging);
            Assert.AreEqual(SmartHomeEnergySystem.Enums.VehicleEnumConnect.DISCONNECTED, vehicle.Connected);
        }

        [Test]
        [TestCase("name", 2, 2, 2)]
        [TestCase("name", 2, 2.45, 2)]
        [TestCase("name", 2, 2, 2)]
        [TestCase("name", 2, 2.45, 2)]
        public void ConstructorParams(string n, double mp, double cap, double maxcap)
        {
            eVehicleChargerModel vehicle = new eVehicleChargerModel(n, mp, cap, maxcap);

            Assert.AreEqual(n, vehicle.Name);
            Assert.AreEqual(mp, vehicle.MaxPower);
            Assert.AreEqual(cap, vehicle.Capacity);
            Assert.AreEqual(maxcap, vehicle.MaxPower);
        }

        [Test]
        [TestCase(null, 2, 2, 2)]
        [TestCase(null, -2, 22, 2.1)]
        [TestCase(null, 2.54, 2, -2)]
        public void ConstructorLosiParametri(string n, double mp, double cap, double maxcap)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                eVehicleChargerModel vehicle = new eVehicleChargerModel(n, mp, cap, maxcap);
            });
        }

        [Test]
        [TestCase("", 2, 2, 2)]
        [TestCase("test", -2, 22, 2.1)]
        public void ConstructorLosiParametri1(string n, double mp, double cap, double maxcap)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                eVehicleChargerModel vehicle = new eVehicleChargerModel(n, mp, cap, maxcap);
            });
        }
    }
}
