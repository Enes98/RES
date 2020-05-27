using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeEnergySystem.Models
{
    public class UtilityModel
    {
        double exchangePower;
        double price;

        public double ExchangePower
        {
            get { return exchangePower; }
            set
            {
                exchangePower = value;
            }
        }
        public double Price
        {
            get { return price; }
            set
            {
                price = value;
            }
        }

        public UtilityModel()
        {
            ExchangePower = 0;
            Price = 0;
        }
        public UtilityModel(double cp, double p)
        {
            ExchangePower = cp;
            Price = p;
        }
    }
}
