using SmartHomeEnergySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeEnergySystem.ViewModels
{
    public class ChartViewModel
    {
        public static Dictionary<DateTime, ChartModel> Chart { get; set; }

        public ChartViewModel()
        {
            Chart = new Dictionary<DateTime, ChartModel>();

            Chart.Add(new DateTime(2020, 6, 6),
            new ChartModel()
            {
                SolarPanel = 100,
                BatteryConsumption = 90,
                BatteryProduction = 45,
                ExchangePositive = 30,
                ExchangeNegative = -12,
                Consumer = 90,
                Price = 98
            });

            Chart.Add(new DateTime(2020, 6, 21),
            new ChartModel()
            {
                SolarPanel = 10,
                BatteryConsumption = 10,
                BatteryProduction = 10,
                ExchangePositive = 10,
                ExchangeNegative = 10,
                Consumer = 10,
                Price = 10
            }

            );
        }


    }
}
