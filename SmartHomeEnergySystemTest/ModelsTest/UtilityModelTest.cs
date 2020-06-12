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
    public class UtilityModelTest
    {
        [Test]
        [TestCase()]
        public void ConstructorPrazan()
        {
            UtilityModel utility = new UtilityModel();

            Assert.AreEqual(0, utility.ExchangePower);
            Assert.AreEqual(0, utility.Price);
            Assert.AreEqual(0, utility.Consumption);
            Assert.AreEqual(0, utility.Production);
        }

        [Test]
        [TestCase(11, 10, 11, 12)]
        [TestCase(11.6, 10.2, 11.2, 12.3)]
        public void ConstructorDobriParametri(double ep, double price, double c, double p)
        {
            UtilityModel utility = new UtilityModel(ep, price, c, p);

            Assert.AreEqual(ep, utility.ExchangePower);
            Assert.AreEqual(price, utility.Price);
            Assert.AreEqual(c, utility.Consumption);
            Assert.AreEqual(p, utility.Production);
        }

        [Test]
        [TestCase(-44, 56, 65, 12.3)]
        [TestCase(44, -56, 65, 12.3)]
        [TestCase(44, 56, -65, 12.3)]
        [TestCase(44, 56, 65, -12.3)]
        public void ConstructorLosiParametri1(double ep, double price, double c, double p)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                UtilityModel utility = new UtilityModel(ep, price, c, p);
            });
        }
    }
}
