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
        string name;
        double maxPower;
        double capacity;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(Name);
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

        public BatteryModel()
        {
            Name = "";
            MaxPower = 0;
            Capacity = 0;
        }
        public BatteryModel(string n, double mp, double c)
        {
            Name = n;
            MaxPower = mp;
            Capacity = c;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);
                this.PropertyChanged(this, args);
            }
        }
    }
}
