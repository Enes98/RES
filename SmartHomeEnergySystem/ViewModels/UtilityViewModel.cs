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
    public class UtilityViewModel
    {
        public static ObservableCollection<UtilityModel> Utilities { get; set; }

        private UtilityModel selectedUtility;

        public UtilityModel SelectedUtility
        {
            get { return selectedUtility; }
            set
            {
                selectedUtility = value;
            }
        }
        
        public UtilityViewModel()
        {
            Utilities = new ObservableCollection<UtilityModel>()
            {
                new UtilityModel()
            };

            CalculateProduction();            
        }

        public void CalculateProduction()
        {
            new Thread(()=>
            {
                while (true)
                {
                    
                    Thread.Sleep(500);
                    double product = SolarPanelViewModel.SolarPanelProduction() + BatteryViewModel.BatteryProduction();
                    double cons = ConsumerViewModel.ConsumerConsumption() + BatteryViewModel.BatteryConsumption() + eVehicleChargerViewModel.VehicleConsumption();

                    Utilities[0].Production = product;
                    Utilities[0].Consumption = cons;
                    Utilities[0].ExchangePower = product - cons;
                    Utilities[0].Price = Utilities[0].ExchangePower * 0.2;

                    Thread.Sleep(500);
                }
            }).Start();
        }
    }
}
