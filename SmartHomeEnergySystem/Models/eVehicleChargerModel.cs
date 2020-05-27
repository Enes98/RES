using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeEnergySystem.Models
{
    public class eVehicleChargerModel
    {
        string name;
        double maxPower;
        double capacity;

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
        public double Capacity
        {
            get { return capacity; }
            set
            {
                capacity = value;
            }
        }

        public eVehicleChargerModel()
        {
            Name = "";
            MaxPower = 0;
            Capacity = 0;
        }
        public eVehicleChargerModel(string n, double mp, double c)
        {
            Name = n;
            MaxPower = mp;
            Capacity = c;
        }
    }
}
