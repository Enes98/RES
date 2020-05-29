using SmartHomeEnergySystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeEnergySystem.ViewModels
{
    public class BatteryViewModel
    {
        public static ObservableCollection<BatteryModel> batteries { get; set; }
        BatteryModel selectedBattery;

        public BatteryModel SelectedBattery
        {
            get { return selectedBattery; }
            set { selectedBattery = value; }
        }

        public BatteryViewModel()
        {
            loadBatteries();
        }

        public void loadBatteries()
        {
            batteries = new ObservableCollection<BatteryModel>();

            batteries.Add(new BatteryModel("Tesla X", 7, 13.5));
            batteries.Add(new BatteryModel("Tesla S", 9, 15.7));
        }
    }
}
