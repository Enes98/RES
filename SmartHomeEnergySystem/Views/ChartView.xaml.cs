using LiveCharts;
using LiveCharts.Wpf;
using SmartHomeEnergySystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartHomeEnergySystem.Views
{
    /// <summary>
    /// Interaction logic for ChartView.xaml
    /// </summary>
    public partial class ChartView : UserControl
    {
        public ChartView()
        {
            InitializeComponent();

           
            DateTime time = dateParse();
            labelPrice.Content = ChartViewModel.Chart[time].Price;

            SeriesCollection = new SeriesCollection
                {
                    new ColumnSeries
                    {
                       // Title = "Solar Panel",
                        //Values = new ChartValues<double> { 10, 50, 39, 50, 6, 234}

                        Values = new ChartValues<double>
                        {
                            ChartViewModel.Chart[time].SolarPanel,
                            ChartViewModel.Chart[time].BatteryConsumption,
                            ChartViewModel.Chart[time].BatteryProduction,
                            ChartViewModel.Chart[time].ExchangeNegative,
                            ChartViewModel.Chart[time].ExchangePositive,
                            ChartViewModel.Chart[time].Consumer
                        }
                    }
                };

            Labels = new[] { "Panels", "Battery(+)", "Battery(-)", "Utility(+)", "Utility(-)", "Consumers" };
            Formatter = value => value.ToString("N");

            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        private DateTime dateParse()
        {
            DateTime dt = new DateTime();
            string date = dateTime1.SelectedDate.ToString();
            if (date == "")
            {
                return new DateTime(2020, 6, 6);
            }

            return dt;
        }



    }
}
