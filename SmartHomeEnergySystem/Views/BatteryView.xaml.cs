using SmartHomeEnergySystem.Models;
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
    /// Interaction logic for BatteryView.xaml
    /// </summary>
    public partial class BatteryView : UserControl
    {
        public BatteryView()
        {
            InitializeComponent();
            this.DataContext = new BatteryViewModel();
            listBoxBatteries.ItemsSource = BatteryViewModel.Batteries;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(textBoxName.Text)) || (string.IsNullOrWhiteSpace(textBoxMaxPower.Text)) || string.IsNullOrWhiteSpace(textBoxCapacity.Text))
                return;

            lock(BatteryViewModel.Batteries)
            {
                BatteryViewModel.Batteries.Add(new BatteryModel(textBoxName.Text, Double.Parse(textBoxMaxPower.Text), Double.Parse(textBoxCapacity.Text), 0));

                using (dbSHESEntities entity = new dbSHESEntities())
                {
                    BatteryTable bmt = new BatteryTable()
                    {
                        Name = textBoxName.Text,
                        MaxPower = Double.Parse(textBoxMaxPower.Text),
                        Capacity = Double.Parse(textBoxCapacity.Text),
                        CurrentCapacity = 0,
                        CapacityMin = 0,
                        State = Enums.BatteryEnum.IDLE.ToString()
                    };
                    entity.BatteryTables.Add(bmt);
                    entity.SaveChanges();
                }

                BatteryViewModel.Refresh();
            }
        }
    }
}
