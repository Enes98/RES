using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeEnergySystem.Models
{
    public class UtilityModel /*: INotifyPropertyChanged*/
    {
        double exchangePower;
        public double Price { get; set; }

        public double ExchangePower
        {
            get { return exchangePower; }
            set
            {
                exchangePower = value;
              //  OnPropertyChanged("ExchangePower");
            }
        }
        /*
        public double Price
        {
            get { return price; }
            set
            {
                price = value;
              //  OnPropertyChanged("Price");
            }
        }
        */
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

        /*
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);
                this.PropertyChanged(this, args);
            }
        }
        */
    }
}
