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
 
            if (Validate(textBoxCapacitet))
            {
                bool uspelo = false;
                double result = 0;
                uspelo = double.TryParse(textBoxCapacitet.Text, out result);
                if(uspelo && result >= 0)
                {
                    new Thread(() =>
                    {
                        try
                        {
                            if (eVehicleChargerViewModel.Vehicles[0].MaxCapacity >= result)
                                eVehicleChargerViewModel.Vehicles[0].Capacity = result;
                            else
                            {
                                eVehicleChargerViewModel.Vehicles[0].Capacity = eVehicleChargerViewModel.Vehicles[0].MaxCapacity;
                            }
                        }
                        catch { }
                    }).Start();
                }
                else
                {
                    MessageBox.Show("Incorrect input", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Incorrect input", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

        public bool Validate(TextBox check)
        {

            if (!string.IsNullOrEmpty(check.Text))
            {
                return true;
            }
            return false;
        }
    }
}
