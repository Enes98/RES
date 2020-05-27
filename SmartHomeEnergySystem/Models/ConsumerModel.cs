using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeEnergySystem.Models
{
    public class ConsumerModel
    {
        string name;
        double consumption;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }
        public double Consumption
        {
            get { return consumption; }
            set
            {
                consumption = value;

            }
        }

        public ConsumerModel()
        {
            Name = "";
            Consumption = 0;
        }
        public ConsumerModel(string n, double c)
        {
            Name = n;
            Consumption = c;
        }
    }
}
