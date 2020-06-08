﻿using SmartHomeEnergySystem.Command;
using SmartHomeEnergySystem.Commands;
using SmartHomeEnergySystem.Enums;
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
                new BatteryModel("Tesla X", 7, 13.5),
                new BatteryModel("Tesla S", 9, 15.7)
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

        public double StartCharging()
        {
            SHES.batteryState = BatteryEnum.CHARGING;
            return 0;
           // return CalculateCapacity();
        }
        public double StartDischarging()
        {
            SHES.batteryState= BatteryEnum.DISCHARGING;
            return 0;
        }
        public double StartIdle()
        {
            SHES.batteryState = BatteryEnum.IDLE;
            return 0;
        }

        private double CalculateCapacity()
        {
            double sum = 0;
            foreach(var battery in Batteries)
            {
                sum += battery.Capacity;
                
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
