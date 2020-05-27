using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeEnergySystem.Models
{
    public class SolarPanelModel
    {
        string name;
        double maxPower;
        double currentPower;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }
        public double MaxPower
        {
            get { return maxPower; }
            set
            {
                maxPower = value;
            }
        }
        public double CurrentPower
        {
            get { return currentPower; }
            set
            {
                currentPower = value;
            }
        }

        public SolarPanelModel()
        {
            Name = "";
            MaxPower = 0;
            CurrentPower = 0;
        }
        public SolarPanelModel(string n, double mp, double cp)
        {
            Name = n;
            MaxPower = mp;
            CurrentPower = cp;
        }
    }
}
