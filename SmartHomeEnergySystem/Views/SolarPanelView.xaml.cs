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
            if ((string.IsNullOrEmpty(textBoxName.Text)) || (string.IsNullOrEmpty(textBoxMaxPower.Text)))
                return;

            SolarPanelViewModel.solarPanels.Add(new SolarPanelModel(textBoxName.Text, Double.Parse(textBoxMaxPower.Text), 0));

            using (dbSHESEntities entity = new dbSHESEntities())
            {
                SolarPanelTable spmt = new SolarPanelTable()
                {
                    Name = textBoxName.Text,
                    MaxPower = Double.Parse(textBoxMaxPower.Text),
                    CurrentPower = 0
                };
                entity.SolarPanelTables.Add(spmt);
                entity.SaveChanges();
            }

        }

        private void BtnApply_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(textBoxSunPower.Text))
                SHES.sunPower = 0;
            SHES.sunPower = double.Parse(textBoxSunPower.Text);
            new Thread(() =>
            {
                while(true)
                {
                    try
                    {
                        SolarPanelViewModel.Refresh();
                    }
                    catch { }
                }
            }).Start();
            
        }
    }
}

