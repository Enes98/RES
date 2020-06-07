using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeEnergySystem.Models
{
    public class SolarPanelModel : INotifyPropertyChanged
    {
        string name;
        double maxPower;
        double currentPower;

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
        public double CurrentPower
        {
            get { return currentPower; }
            set
            {
                currentPower = value;
                OnPropertyChanged("CurrentPower");
            }
        }

        public SolarPanelModel()
        {
            Name = "";
            MaxPower = 0;
            CurrentPower = 0;
        }
        public SolarPanelModel(string n, double mp, double cp)
        {
            Name = n;
            MaxPower = mp;
            CurrentPower = cp;
        }

        public SolarPanelModel(string n, double mp)
        {
            Name = n;
            MaxPower = mp;
            CurrentPower = 0;
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
