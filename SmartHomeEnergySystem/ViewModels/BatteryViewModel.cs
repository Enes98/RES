using SmartHomeEnergySystem.Command;
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
        public static ObservableCollection<BatteryModel> Batteries { get; set; }
        public BatteryModel selectedBattery;

        public static MyICommand DeleteCommand { get; set; }

        public BatteryModel SelectedBattery
        {
            get { return selectedBattery; }
            set
            {
                selectedBattery = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }
        

        public BatteryViewModel()
        {
            loadBatteries();
            DeleteCommand = new MyICommand(Delete, CanDelete);
        }

        public void loadBatteries()
        {
            Batteries = new ObservableCollection<BatteryModel>();

          //  Batteries.Add(new BatteryModel("Tesla X", 7, 13.5));
            //Batteries.Add(new BatteryModel("Tesla S", 9, 15.7));
        }

        private void Delete()
        {
            BatteryModel delete = SelectedBattery;
            Batteries.Remove(delete);
        }

        private bool CanDelete()
        {
            return SelectedBattery != null;
        }
    }
}
