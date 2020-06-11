using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using SmartHomeEnergySystem.Models;
using SmartHomeEnergySystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        DateTime time = new DateTime();

        public ChartView()
        {
            InitializeComponent();

            time = dateParse();
            //Charting();

            SeriesCollection lista = new SeriesCollection
            {
                new ColumnSeries
                        {
                           // Title = "Solar Panel",
                            //Values = new ChartValues<double> { 10, 50, 39, 50, 6, 234}

                            Values = new ChartValues<double>
                            {
                                0,
                                0,
                                0,
                                0,
                                0,
                                0
                            }
                        }
            };

            Labels = new[] { "Panels", "Battery(+)", "Battery(-)", "Utility(+)", "Utility(-)", "Consumers" };
            //AxisY.LabelFormatter = value => value.ToString("N");
            
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

        private void DateTimeMethod(object sender, SelectionChangedEventArgs e)
        {
            string date = dateTime1.SelectedDate.ToString();
            time = DateTime.Parse(date);
            Charting();
        }

        private void Charting()
        {
           
            labelPrice.Content = ChartViewModel.Chart[time].Price;
            SeriesCollection series= new SeriesCollection
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

            DataChart.Series = series;
        }

    }
}
