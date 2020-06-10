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
        public static double sunPower = SolarPanelViewModel.solarPanels[0].CurrentPower;

        public BatteryViewModel battery;
        public UtilityViewModel utility;
        public SolarPanelViewModel solar;
        public ConsumerViewModel consumer;
        public eVehicleChargerViewModel vehicle;
        public ChartViewModel chart;

        public SHES(BatteryViewModel bt, UtilityViewModel ut, SolarPanelViewModel sp, ConsumerViewModel cs, eVehicleChargerViewModel ev, ChartViewModel ch)
        {
            battery = bt;
            utility = ut;
            solar = sp;
            consumer = cs;
            vehicle = ev;
            chart = ch;
            BatteryManagement();
            eVehicleManagement();
            
        }

        private void BatteryManagement()
        {
            new Thread(() =>
            {
                while(true)
                {
                    if ((ClockModel.Time.Hour >= 3) && (ClockModel.Time.Hour < 6))
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
                    lock(BatteryViewModel.Batteries)
                    {
                    BatteryViewModel.Refresh();
                    }
                }
            }).Start();
        }

       
        private void eVehicleManagement()
        {
            double temp = 0;
            new Thread(() =>
            {
                while (true)
                {
                    if ((ClockModel.Time.Hour >= 3) && (ClockModel.Time.Hour < 6))
                    {
                        if ((eVehicleChargerViewModel.Vehicles[0].Connected == Enums.VehicleEnumConnect.CONNECTED) && (eVehicleChargerViewModel.Vehicles[0].Capacity < eVehicleChargerViewModel.Vehicles[0].MaxCapacity))
                        {
                            eVehicleChargerViewModel.Vehicles[0].Charging = Enums.VehicleEnumCharging.CHARGING;
                            
                           temp += ClockModel.Time.Minute;
                           if (temp == 60)
                           {
                                eVehicleChargerViewModel.Vehicles[0].Capacity++;
                                temp = 0;
                           }
                             Thread.Sleep(1000);    
                        }
                    }
                    else if((eVehicleChargerViewModel.punjenje != true))
                    {
                        eVehicleChargerViewModel.Vehicles[0].Charging = Enums.VehicleEnumCharging.IDLE;
                    }

                   // eVehicleChargerViewModel.Vehicles[0].Charging = Enums.VehicleEnumCharging.IDLE;
                }
            }
            ).Start();
        }



    }
}
