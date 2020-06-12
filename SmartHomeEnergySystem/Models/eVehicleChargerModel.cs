using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeEnergySystem.Models
{
    public class eVehicleChargerModel : INotifyPropertyChanged
    {
        private string name;
        private double maxPower;
        private double maxCapacity;
        private double capacity;
        private Enums.VehicleEnumCharging charging;
        private Enums.VehicleEnumConnect connected;

        public double MaxCapacity
        {
            get { return maxCapacity; }
            set
            {
                maxCapacity = value;
                OnPropertyChanged("MaxCapacity");
            }
        }

        public Enums.VehicleEnumCharging Charging
        {
            get { return charging; }
            set
            {
                charging = value;
                OnPropertyChanged("Charging");
            }
        }

        public Enums.VehicleEnumConnect Connected
        {
            get { return connected; }
            set
            {
                connected = value;
                OnPropertyChanged("Connected");
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

        public eVehicleChargerModel()
        {
            Name = "";
            MaxPower = 0;
            Capacity = 0;
            MaxCapacity = 0;
            Charging = Enums.VehicleEnumCharging.IDLE;
            Connected = Enums.VehicleEnumConnect.DISCONNECTED;

        }
        public eVehicleChargerModel(string n, double mp, double c, double mc)
        {
            if (n == null)
                throw new ArgumentNullException("Name null!");
            else if (n == "")
                throw new ArgumentException("Name empty!");
            else if (c < 0 || mc < 0 || mp < 0)
                throw new ArgumentException("Values must be positive!");

            Name = n;
            MaxPower = mp;
            Capacity = c;
            MaxCapacity = mc;
            Charging = Enums.VehicleEnumCharging.IDLE;
            Connected =Enums.VehicleEnumConnect.DISCONNECTED;
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
