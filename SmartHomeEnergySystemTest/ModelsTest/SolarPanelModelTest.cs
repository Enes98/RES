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
    public class SolarPanelModelTest
    {
        [Test]
        [TestCase()]
        public void ConstructorPrazan()
        {
            SolarPanelModel panel = new SolarPanelModel();

            Assert.AreEqual("", panel.Name);
            Assert.AreEqual(0, panel.MaxPower);
            Assert.AreEqual(0, panel.CurrentPower);
        }

        [Test]
        [TestCase("name", 2, 2)]
        [TestCase("name", 2, 2.1)]
        public void ConstructorParams(string n, double mp, double cp)
        {
            SolarPanelModel panel = new SolarPanelModel(n, mp, cp);

            Assert.AreEqual(n, panel.Name);
            Assert.AreEqual(mp, panel.MaxPower);
            Assert.AreEqual(cp, panel.CurrentPower);
        }

        [Test]
        [TestCase("name", 2)]
        [TestCase("name", 2.2)]
        public void ConstructorParams(string n, double mp)
        {
            SolarPanelModel panel = new SolarPanelModel(n, mp);

            Assert.AreEqual(n, panel.Name);
            Assert.AreEqual(mp, panel.MaxPower);
            Assert.AreEqual(0, panel.CurrentPower);
        }

        [Test]
        [TestCase(null, 2, 2)]
        [TestCase(null, -2, 2)]
        [TestCase(null, 2, -2)]
        public void ConstructorLosiParametri(string n, double mp, double cp)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                SolarPanelModel panel = new SolarPanelModel(n, mp, cp);
            });
        }

        [Test]
        [TestCase("", 2, 2)]
        [TestCase("", -2, 2)]
        [TestCase("", 2, -2)]
        [TestCase("test", -2, 2.6)]
        [TestCase("test", 2, -2.4)]
        public void ConstructorLosiParametri1(string n, double mp, double cp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                SolarPanelModel panel = new SolarPanelModel(n, mp, cp);
            });
        }

        [Test]
        [TestCase(null, 2)]
        [TestCase(null, -2)]
        public void ConstructorLosiParametri(string n, double mp)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                SolarPanelModel panel = new SolarPanelModel(n, mp);
            });
        }

        [Test]
        [TestCase("", 2)]
        [TestCase("", -2)]
        [TestCase("test", -2)]
        public void ConstructorLosiParametri1(string n, double mp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                SolarPanelModel panel = new SolarPanelModel(n, mp);
            });
        }
    }
}
