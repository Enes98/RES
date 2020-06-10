using SmartHomeEnergySystem.Command;
using SmartHomeEnergySystem.Commands;
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
    public class eVehicleChargerViewModel
    {
        public static ObservableCollection<eVehicleChargerModel> Vehicles { get; set; }

        private eVehicleChargerModel selectedVehicle;
        public static MyICommand ConnectCommand { get; set; }
        public static MyICommand DisconnectCommand { get; set; }
        public static MyICommand StartChargingCommand { get; set; }
        public static MyICommand StopChargingCommand { get; set; }

        public static bool punjenje;


        public eVehicleChargerModel SelectedVehicle
        {
            get { return selectedVehicle; }
            set
            {
                selectedVehicle = value;
            }
        }


        public eVehicleChargerViewModel()
        {
            loadVehicles();
           // SelectedVehicle = Vehicles[0];
        }

        public void loadVehicles()
        {

            Vehicles = new ObservableCollection<eVehicleChargerModel>();
            using (dbSHESEntities entity = new dbSHESEntities())
            {
                List<eVehicleTable> lista = entity.eVehicleTables.ToList<eVehicleTable>();
                foreach(var item in lista)
                {
                    eVehicleChargerModel vehicle = new eVehicleChargerModel(item.Name, (double)item.MaxPower, (double)item.Capacity, (double)item.MaxCapacity);
                    Vehicles.Add(vehicle);
                }

            }
        }


        public static void ChargingMethod()
        {
            double temp = 0;
            new Thread(() =>
            {
                while (true)
                {
                    if ((eVehicleChargerViewModel.Vehicles[0].Charging == Enums.VehicleEnumCharging.CHARGING) && (eVehicleChargerViewModel.Vehicles[0].Capacity < eVehicleChargerViewModel.Vehicles[0].MaxCapacity))
                    {
                        temp += ClockModel.Time.Minute;
                        if (temp == 60)
                        {
                            eVehicleChargerViewModel.Vehicles[0].Capacity++;
                            temp = 0; 
                        }
                    }
                    Thread.Sleep(1000);
                }
            }).Start();

        }


        public static double VehicleConsumption()
        {
           
            if(Vehicles[0].Charging == Enums.VehicleEnumCharging.CHARGING)
            {
                return Vehicles[0].MaxPower;
            }
            return 0;
        }


    }
}
