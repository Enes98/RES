using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeEnergySystem.Models
{
    public class ChartModel : INotifyPropertyChanged
    {
        private double solarPanel;
        private double batteryConsumption;
        private double batteryProduction;
        private double exchangePositive;
        private double exchangeNegative;
        private double consumer;
        private double price;

        public double SolarPanel { get => solarPanel; set => solarPanel = value; }
        public double BatteryConsumption { get => batteryConsumption; set => batteryConsumption = value; }
        public double BatteryProduction { get => batteryProduction; set => batteryProduction = value; }
        public double ExchangePositive { get => exchangePositive; set => exchangePositive = value; }
        public double ExchangeNegative { get => exchangeNegative; set => exchangeNegative = value; }
        public double Consumer { get => consumer; set => consumer = value; }
        public double Price { get => price; set => price = value; }

        public ChartModel()
        {

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
