using SmartHomeEnergySystem.Command;
using SmartHomeEnergySystem.Commands;
using SmartHomeEnergySystem.Enums;
using SmartHomeEnergySystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartHomeEnergySystem.ViewModels
{
    public class BatteryViewModel
    {
        public static ObservableCollection<BatteryModel> Batteries { get; set; }
        public BatteryModel selectedBattery;

        public static MyICommand DeleteBatteryCommand { get; set; }

        public BatteryModel SelectedBattery
        {
            get { return selectedBattery; }
            set
            {
                selectedBattery = value;
                DeleteBatteryCommand.RaiseCanExecuteChanged();   //ovde stane program
            }
        }

        public BatteryViewModel()
        {
            loadBatteries();
            DeleteBatteryCommand = new MyICommand(OnDeleteBattery, CanDeleteBattery);
        }

        public void loadBatteries()
        {
            Batteries = new ObservableCollection<BatteryModel>
            {
                new BatteryModel("Tesla X", 7, 150, 0),
                new BatteryModel("Tesla S", 9, 150, 0)
            };
        }

        private bool CanDeleteBattery() 
        {
            return SelectedBattery != null;
        }
        private void OnDeleteBattery()
        {
            DeleteBatteryCommand deleteCommand = new DeleteBatteryCommand(SelectedBattery);
            deleteCommand.Execute();
        }

        public void StartCharging()
        {
            SHES.batteryState = BatteryEnum.CHARGING;

            if (CalculateCurrentCapacity() < CalculateMaxCapacity())
            {
                foreach(BatteryModel bat in Batteries)
                {
                    if(bat.CurrentCapacity < bat.Capacity)
                    {
                        bat.CapacityMin += ClockModel.Time.Minute;
                    }
                    if (bat.CapacityMin == 60)
                    {
                        bat.CurrentCapacity += 1;
                        bat.CapacityMin = 0;
                    }
                }
            }
            Thread.Sleep(1000);
        }
        public void StartDischarging()
        {
            SHES.batteryState= BatteryEnum.DISCHARGING;

            if (CalculateCurrentCapacity() > 0)
            {
                foreach (BatteryModel bat in Batteries)
                {
                    if (bat.CapacityMin >= 0)
                    {
                        bat.CapacityMin -= ClockModel.Time.Minute;
                        if(bat.CapacityMin <= 0)
                        {
                            if(bat.CurrentCapacity > 0)
                            {
                                bat.CurrentCapacity--;
                                bat.CapacityMin = 59 + bat.CapacityMin;
                            }
                            else
                            {
                                bat.CurrentCapacity = 0;
                                bat.CapacityMin = 0;
                            }
                        }
                    }
                }
            }
            Thread.Sleep(1000);
        }
        public void StartIdle()
        {
            SHES.batteryState = BatteryEnum.IDLE;
        }

        private double CalculateMaxCapacity()
        {
            double sum = 0;
            foreach(var battery in Batteries)
            {
                sum += battery.Capacity;
                
            }
            return sum;
        }
        private double CalculateCurrentCapacity()
        {
            double sum = 0;
            foreach (var battery in Batteries)
            {
                sum += battery.CurrentCapacity;

            }
            return sum;
        }

        public static void Refresh()
        {
            foreach(BatteryModel bat in Batteries)
            {
                bat.State = SHES.batteryState;
            }
        }
    }
}
