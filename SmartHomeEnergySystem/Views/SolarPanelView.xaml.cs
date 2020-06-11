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

namespace SmartHomeEnergySystem.Views
{
    /// <summary>
    /// Interaction logic for SolarPanelView.xaml
    /// </summary>
    public partial class SolarPanelView : UserControl
    {
        public SolarPanelView()
        {
            InitializeComponent();
            this.DataContext = new SolarPanelViewModel();
            listBoxPanels.ItemsSource = SolarPanelViewModel.solarPanels;
        }

        private void ButtonAddPanel_Click(object sender, RoutedEventArgs e)
        {

            if(Validate(textBoxName) && Validate(textBoxMaxPower))
            {
                double maxPower = 0;
                bool uspelo = false;
                uspelo = double.TryParse(textBoxMaxPower.Text, out maxPower);
                if(uspelo && maxPower > 0)
                {
                    SolarPanelViewModel.solarPanels.Add(new SolarPanelModel(textBoxName.Text, maxPower, (SHES.sunPower * maxPower) / 100));

                    using (dbSHESEntities entity = new dbSHESEntities())
                    {
                        SolarPanelTable spmt = new SolarPanelTable()
                        {
                            Name = textBoxName.Text,
                            MaxPower = maxPower,
                            CurrentPower = 0
                        };
                        entity.SolarPanelTables.Add(spmt);
                        entity.SaveChanges();
                    }
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

        private void BtnApply_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(textBoxSunPower.Text))
                SHES.sunPower = 0;

            if (Validate(textBoxSunPower))
            {
                double result = 0;
                bool uspelo = false;
                uspelo = double.TryParse(textBoxSunPower.Text, out result);
                if (uspelo && result >= 0)
                {
                    //SHES.sunPower = double.Parse(textBoxSunPower.Text);
                    SHES.sunPower = result;
                    new Thread(() =>
                    {
                        //while(true)
                        //{
                        try
                        {
                            SolarPanelViewModel.Refresh();
                        }
                        catch { }
                        // }
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

