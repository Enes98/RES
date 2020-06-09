using SmartHomeEnergySystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeEnergySystem.ViewModels
{
    public class eVehicleChargerViewModel
    {
        public static ObservableCollection<eVehicleChargerModel> Vehicles { get; set; }

        public eVehicleChargerViewModel()
        {
            loadVehicles();
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


    }
}
