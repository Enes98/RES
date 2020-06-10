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

namespace SmartHomeEnergySystem.Views
{
    /// <summary>
    /// Interaction logic for eVehicleChargerView.xaml
    /// </summary>
    public partial class eVehicleChargerView : UserControl
    {
        public eVehicleChargerView()
        {
            InitializeComponent();
            this.DataContext = new eVehicleChargerViewModel();
            // listBoxVehicles.ItemsSource = eVehicleChargerViewModel.Vehicles;
            listBoxVehicles1.ItemsSource = eVehicleChargerViewModel.Vehicles;
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
 
            if (!string.IsNullOrEmpty(textBoxCapacitet.Text))
            {
                // eVehicleChargerViewModel.Vehicles[0].Capacity = Double.Parse(textBoxCapacitet.Text);
                double temp = Double.Parse(textBoxCapacitet.Text);

                new Thread(() =>
                {
                    try
                    {
                        if (eVehicleChargerViewModel.Vehicles[0].MaxCapacity >= temp)
                            eVehicleChargerViewModel.Vehicles[0].Capacity = temp;
                        else
                        {
                            eVehicleChargerViewModel.Vehicles[0].Capacity = eVehicleChargerViewModel.Vehicles[0].MaxCapacity;
                        }
                    }
                    catch { }
                }).Start();
            }
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            eVehicleChargerViewModel.Vehicles[0].Connected = Enums.VehicleEnumConnect.CONNECTED;
        }

        private void btnDisconnect_Click(object sender, RoutedEventArgs e)
        {
            eVehicleChargerViewModel.Vehicles[0].Connected = Enums.VehicleEnumConnect.DISCONNECTED;
            eVehicleChargerViewModel.Vehicles[0].Charging = Enums.VehicleEnumCharging.IDLE;
        }

        private void btnStartCharging_Click(object sender, RoutedEventArgs e)
        {
            if((eVehicleChargerViewModel.Vehicles[0].Connected == Enums.VehicleEnumConnect.CONNECTED))
            {
                eVehicleChargerViewModel.punjenje = true;
                eVehicleChargerViewModel.Vehicles[0].Charging = Enums.VehicleEnumCharging.CHARGING;
                eVehicleChargerViewModel.ChargingMethod();
            }
        }

        private void btnStopSCharging_Click(object sender, RoutedEventArgs e)
        {
            eVehicleChargerViewModel.Vehicles[0].Charging = Enums.VehicleEnumCharging.IDLE;
            eVehicleChargerViewModel.punjenje = false;
        }
    }
}
