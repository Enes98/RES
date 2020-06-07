using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeEnergySystem.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private BatteryViewModel battery = new BatteryViewModel();
        private UtilityViewModel utility = new UtilityViewModel();
        private SolarPanelViewModel solar = new SolarPanelViewModel();
        private ConsumerViewModel consumer = new ConsumerViewModel();
        private eVehicleChargerViewModel vehicle = new eVehicleChargerViewModel();
        private SHES shes;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);
                this.PropertyChanged(this, args);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;


        public MainWindowViewModel()
        {
           shes = new SHES(battery, utility, solar, consumer, vehicle);
        }


    }
}
