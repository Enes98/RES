using SmartHomeEnergySystem.Enums;
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

        private BatteryViewModel battery;
        private UtilityViewModel utility;
        private SolarPanelViewModel solar;
        private ConsumerViewModel consumer;
        private eVehicleChargerViewModel vehicle;
        

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
            int b = 5;
            new Thread(() =>
            {

                while(true)
                {
                    if (b == 5 || b == 6)
                    {

                        foreach (var bat in BatteryViewModel.Batteries)
                        {
                            bat.State = BatteryEnum.DISCHARGING;

                        }
                    }

                }


            }).Start();


        }   
    }
}
