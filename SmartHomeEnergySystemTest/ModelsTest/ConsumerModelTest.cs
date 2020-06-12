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
    public class ConsumerModelTest
    {
        [Test]
        [TestCase()]
        public void ConstructorPrazan()
        {
            ConsumerModel cons = new ConsumerModel();

            Assert.AreEqual("", cons.Name);
            Assert.AreEqual(0, cons.Consumption);
            Assert.AreEqual(SmartHomeEnergySystem.Enums.ConsumerEnum.OFF, cons.State);
        }

        [Test]
        [TestCase("Consumer", 20)]
        [TestCase("Consumer", 20.2)]
        public void ConstructorParams(string n, double consumption)
        {
            ConsumerModel cons = new ConsumerModel(n, consumption);

            Assert.AreEqual(n, cons.Name);
            Assert.AreEqual(consumption, cons.Consumption);
            Assert.AreEqual(SmartHomeEnergySystem.Enums.ConsumerEnum.OFF, cons.State);
        }

        [Test]
        [TestCase(null, 20.2)]
        public void ConstructorLosiParametri(string name, double consumption)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                ConsumerModel battery = new ConsumerModel(name, consumption);
            });
        }

        [Test]
        [TestCase("", 20.2)]
        [TestCase("sdad", -2)]
        [TestCase("", -5)]
        [TestCase("sad", -5)]
        public void ConstructorLosiParametri1(string name, double consumption)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ConsumerModel battery = new ConsumerModel(name, consumption);
            });
        }
    }
}
