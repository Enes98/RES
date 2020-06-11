using SmartHomeEnergySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartHomeEnergySystem.ViewModels
{
    public class ChartViewModel
    {
        public static Dictionary<DateTime, ChartModel> Chart { get; set; }

        public ChartViewModel()
        {
            Chart = new Dictionary<DateTime, ChartModel>();
            loadCharts();
            Chart.Add(new DateTime(2020, 6, 10),
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

            Chart.Add(new DateTime(2020, 6, 11),
            new ChartModel()
            {
                SolarPanel = 10,
                BatteryConsumption = 10,
                BatteryProduction = 10,
                ExchangePositive = 10,
                ExchangeNegative = 10,
                Consumer = 10,
                Price = 10
            });
            CalculateChartProduction();

        }

        private void loadCharts()
        {
            Chart = new Dictionary<DateTime, ChartModel>();
            using (dbSHESEntities entity = new dbSHESEntities())
            {
                List<ChartTable> charts = entity.ChartTables.ToList<ChartTable>();
                foreach (var c in charts)
                {
                    ChartModel ch = new ChartModel()
                    {
                        SolarPanel = (double)c.SolarPanel,
                        BatteryConsumption = (double)c.BatteryConsumption,
                        BatteryProduction = (double)c.BaterryProduction,
                        ExchangePositive = (double)c.ExchangePositive,
                        ExchangeNegative = (double)c.ExchangeNegative,
                        Consumer = (double)c.Consumer,
                        Price = (double)c.Price
                    };
                    Chart.Add(new DateTime(2020, 6, int.Parse(c.Date)), ch);
                }
            };
        }

        public void CalculateChartProduction()
        {
            int date = DateTime.Now.Date.Day;
            double panels = 0;
            double product = 0;
            double cons = 0;
            double batteryPositive = 0;
            double batteryNegative = 0;
            double exhangePositive = 0;
            double exhangeNegative = 0;
            double consumers = 0;
            double price = 0;
            double temp = 0;
            double cnt = 0;
            new Thread(() =>
            {
                while (true)
                {
                    if (temp == 60)
                    {
                        temp = 0;
                        cnt++;
                    }
                    else
                    {
                        temp += ClockModel.Time.Minute;
                    }
                    if(cnt == 23)
                    {
                        cnt = 0;
                        temp = 0;
                        using (dbSHESEntities entity = new dbSHESEntities())
                        {
                            ChartTable ct = new ChartTable()
                            {
                                Date = date.ToString(),
                                SolarPanel = price,
                                BaterryProduction = batteryPositive,
                                BatteryConsumption = batteryNegative,
                                ExchangePositive = exhangePositive,
                                ExchangeNegative = exhangeNegative,
                                Consumer = consumers,
                                Price = price
                            };
                            entity.ChartTables.Add(ct);
                            entity.SaveChanges();
                        }
                        date++;
                    }
                    panels += SolarPanelViewModel.SolarPanelProduction();
                    product = SolarPanelViewModel.SolarPanelProduction() + BatteryViewModel.BatteryProduction();
                    cons = ConsumerViewModel.ConsumerConsumption() + BatteryViewModel.BatteryConsumption() + eVehicleChargerViewModel.VehicleConsumption();
                    exhangePositive += product;
                    exhangeNegative += cons;
                    batteryPositive += BatteryViewModel.BatteryProduction();
                    batteryNegative += BatteryViewModel.BatteryConsumption();
                    consumers += ConsumerViewModel.ConsumerConsumption();
                    price = price + (product - cons) * 0.2;
                    Thread.Sleep(1000);
                }
            }).Start();
        }
    }
}
