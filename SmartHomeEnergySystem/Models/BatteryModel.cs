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
            State = BatteryEnum.IDLE;
        }
        
        public BatteryModel(string n, double mp, double c)
        {
            Name = n;
            MaxPower = mp;
            Capacity = c;
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
