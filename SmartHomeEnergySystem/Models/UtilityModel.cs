using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeEnergySystem.Models
{
    public class UtilityModel : INotifyPropertyChanged
    {
        private double exchangePower;
        private double price;
        private double consumption;
        private double production;

        public double Consumption
        {
            get { return consumption; }
            set
            {
                consumption = value;
                OnPropertyChanged("Consumption");
            }
        }
        public double Production
        {
            get { return production; }
            set
            {
                production = value;
                OnPropertyChanged("Production");
            }
        }

        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }
        public double ExchangePower
        {
            get { return exchangePower; }
            set
            {
                exchangePower = value;
                OnPropertyChanged("ExchangePower");
            }
        }

        public UtilityModel()
        {
            ExchangePower = 0;
            Price = 0;
            Consumption = 0;
            Production = 0;
        }
        public UtilityModel(double ep, double price, double consumption, double production)
        {
            ExchangePower = ep;
            Price = price;
            Consumption = consumption;
            Production = production;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);
                this.PropertyChanged(this, args);
            }
        }
    }
}
