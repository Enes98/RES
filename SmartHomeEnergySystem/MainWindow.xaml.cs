using SmartHomeEnergySystem.Models;
using SmartHomeEnergySystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Xml;

namespace SmartHomeEnergySystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public BatteryViewModel bt = new BatteryViewModel();
        public UtilityViewModel ut = new UtilityViewModel();
        public SolarPanelViewModel s = new SolarPanelViewModel();
        public ConsumerViewModel c = new ConsumerViewModel();
        public eVehicleChargerViewModel vehicle = new eVehicleChargerViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Thread t1 = new Thread(() => StartTime());
            t1.IsBackground = true;
            t1.Start();

            SHES shes = new SHES(bt, ut, s, c, vehicle);
        }


        private void StartTime()
        {
            int hour = 0;
            int min = 0;
            int sec = 0;
            XmlDocument xml = new XmlDocument();
            xml.Load("../../Data/Clock.xml");
            XmlNode node = xml.DocumentElement;
            if(node.Name.Equals("Time"))
            {
                hour = Int32.Parse(node.ChildNodes[0].InnerText);
                min = Int32.Parse(node.ChildNodes[1].InnerText);
                sec = Int32.Parse(node.ChildNodes[2].InnerText);
            }
            while(true)
            {
                if((ClockModel.Time.Hour == 24) && (ClockModel.Time.Minute==0))
                {
                    ClockModel.Time.Hour = 0;
                }
                else
                {
                    ClockModel.Time.Second += sec;
                    if(ClockModel.Time.Second == 60)
                    {
                        ClockModel.Time.Second = 0;
                        ClockModel.Time.Minute += min;
                        if(ClockModel.Time.Minute == 60)
                        {
                            ClockModel.Time.Minute = 0;
                            ClockModel.Time.Hour += hour;
                        }
                    }
                    try
                    {
                        textBoxHours.Dispatcher.Invoke(() => { textBoxHours.Text = $"{ClockModel.Time.Hour}"; });
                        textBoxMinutes.Dispatcher.Invoke(() => { textBoxMinutes.Text = $"{ClockModel.Time.Minute}"; });
                        textBoxSeconds.Dispatcher.Invoke(() => { textBoxSeconds.Text = $"{ClockModel.Time.Second}"; });
                        Thread.Sleep(1000);
                    }
                    catch{ }
                }
            }

        }
        #region ActiveUserControl
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            SetActiveUserControl(home);
        }

        private void EvBtn_Click(object sender, RoutedEventArgs e)
        {
            SetActiveUserControl(ev);
        }

        private void UtilityBtn_Click(object sender, RoutedEventArgs e)
        {
            SetActiveUserControl(utility);
        }

        private void BatteryBtn_Click(object sender, RoutedEventArgs e)
        {
            SetActiveUserControl(battery);
        }

        private void ConsumerBtn_Click(object sender, RoutedEventArgs e)
        {
            SetActiveUserControl(consumer);
        }

        private void SolarBtn_Click(object sender, RoutedEventArgs e)
        {
            SetActiveUserControl(solar);
        }

        private void ChartBtn_Click(object sender, RoutedEventArgs e)
        {
            SetActiveUserControl(chart);
        }

        public void SetActiveUserControl(UserControl control)
        {
            home.Visibility = Visibility.Collapsed;
            ev.Visibility = Visibility.Collapsed;
            solar.Visibility = Visibility.Collapsed;
            utility.Visibility = Visibility.Collapsed;
            battery.Visibility = Visibility.Collapsed;
            consumer.Visibility = Visibility.Collapsed;
            chart.Visibility = Visibility.Collapsed;

            control.Visibility = Visibility.Visible;
        }
        #endregion
    }
}
