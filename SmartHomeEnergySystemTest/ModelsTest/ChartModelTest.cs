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
    public class ChartModelTest
    {
        [Test]
        [TestCase()]
        public void ConstructorPrazan()
        {
            ChartModel chart = new ChartModel();

            Assert.AreEqual(0, chart.SolarPanel);
            Assert.AreEqual(0, chart.BatteryConsumption);
            Assert.AreEqual(0, chart.BatteryProduction);
            Assert.AreEqual(0, chart.ExchangePositive);
            Assert.AreEqual(0, chart.ExchangeNegative);
            Assert.AreEqual(0, chart.Consumer);
            Assert.AreEqual(0, chart.Price);
        }
        [Test]
        [TestCase(1, 2, 3, 4, 5, 6, 7)]
        public void ConstructorDobriParametri(double first, double second, double third, double fourth, double fifth, double sixth, double seventh)
        {
            ChartModel chart = new ChartModel
            {
                SolarPanel = first,
                BatteryConsumption = second,
                BatteryProduction = third,
                ExchangePositive = fourth,
                ExchangeNegative = fifth,
                Consumer = sixth,
                Price = seventh
            };

            Assert.AreEqual(first, chart.SolarPanel);
            Assert.AreEqual(second, chart.BatteryConsumption);
            Assert.AreEqual(third, chart.BatteryProduction);
            Assert.AreEqual(fourth, chart.ExchangePositive);
            Assert.AreEqual(fifth, chart.ExchangeNegative);
            Assert.AreEqual(sixth, chart.Consumer);
            Assert.AreEqual(seventh, chart.Price);
        }
    }
}
