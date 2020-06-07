using SmartHomeEnergySystem.Enums;
using SmartHomeEnergySystem.Models;
using SmartHomeEnergySystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartHomeEnergySystem
{
    public class SHES
    {
        //public static bool bateryCharging = false;
        public static BatteryEnum batteryState = BatteryEnum.IDLE;
        public static double solarPanelsPower = 0;

        public BatteryViewModel battery;
        public UtilityViewModel utility;
        public SolarPanelViewModel solar;
        public ConsumerViewModel consumer;
        public eVehicleChargerViewModel vehicle;
        

        public SHES(BatteryViewModel bt, UtilityViewModel ut, SolarPanelViewModel sp, ConsumerViewModel cs, eVehicleChargerViewModel ev)
        {
            battery = bt;
            utility = ut;
            solar = sp;
            consumer = cs;
            vehicle = ev;
            BatteryManagement();
        }


        private void BatteryManagement()
        {
            new Thread(() =>
            {
                while(true)
                {

                    if ((ClockModel.Time.Hour >= 3) && (ClockModel.Time.Hour <= 6))
                    {
                        battery.StartCharging();
                    }
                    else if ((ClockModel.Time.Hour >= 14) && (ClockModel.Time.Hour <= 17))
                    {
                        battery.StartDischarging();
                    }
                    else
                    {
                        battery.StartIdle();
                    }
                    BatteryViewModel.Refresh();
                }
               
            }).Start();


        }

    }
}
