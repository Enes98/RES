using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeEnergySystem.Models
{
    public class ConsumerModel : INotifyPropertyChanged
    {
        string name;
        double consumption;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(Name);
            }
        }
        public double Consumption
        {
            get { return consumption; }
            set
            {
                consumption = value;
              //  OnPropertyChanged("Consumption");
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);
                this.PropertyChanged(this, args);
            }
        }

        public override string ToString()
        {
            return Name + " " + Consumption;
        }


    }
}
