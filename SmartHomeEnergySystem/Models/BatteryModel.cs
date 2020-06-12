using SmartHomeEnergySystem.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeEnergySystem.Models
{
    public class BatteryModel : INotifyPropertyChanged
    {
        private string name;
        private double maxPower;
        private double capacity;
        private BatteryEnum state;
        private double currentCapacity;
        private double capacityMin;

        public double CapacityMin
        {
            get { return capacityMin; }
            set
            {
                capacityMin = value;
                OnPropertyChanged("CapacityMin");
            }
        }

        public double CurrentCapacity
        {
            get { return currentCapacity; }
            set
            {
                currentCapacity = value;
                OnPropertyChanged("CurrentCapacity");
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public double MaxPower
        {
            get { return maxPower; }
            set
            {
                maxPower = value;
                OnPropertyChanged("MaxPower");
            }
        }
        public double Capacity
        {
            get { return capacity; }
            set
            {
                capacity = value;
                OnPropertyChanged("Capacity");
            }
        }
        
        public BatteryEnum State
        {
            get { return state; }
            set
            {
                state = value;
                OnPropertyChanged("State");
            }
        }

        public BatteryModel()
        {
            Name = "";
            MaxPower = 0;
            Capacity = 0;
            CurrentCapacity = 0;
            State = BatteryEnum.IDLE;
        }
        
        public BatteryModel(string n, double mp, double c, double cc)
        {
            if (n == "")
                throw new ArgumentException("No name!");
            else if (n == null)
                throw new ArgumentNullException("No name!");
            else if(mp < 0 || c < 0 || cc < 0)
                throw new ArgumentException("Values must be positive!");

            Name = n;
            MaxPower = mp;
            Capacity = c;
            CurrentCapacity = cc;
            State = BatteryEnum.IDLE;
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
