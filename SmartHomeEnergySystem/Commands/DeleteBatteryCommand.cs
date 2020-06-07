using SmartHomeEnergySystem.Command;
using SmartHomeEnergySystem.Models;
using SmartHomeEnergySystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SmartHomeEnergySystem.Commands
{
    public class DeleteBatteryCommand : ICommand
    {
        private BatteryModel batteryToDelete;

        public DeleteBatteryCommand(BatteryModel batteryToDelete)
        {
            this.batteryToDelete = batteryToDelete;
        }

        public void Execute()
        {
            BatteryViewModel.Batteries.Remove(batteryToDelete);   //program ne dodje dovde
        }
    }
}
