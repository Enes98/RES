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
    /// Interaction logic for SolarPanelView.xaml
    /// </summary>
    public partial class SolarPanelView : UserControl
    {
        public SolarPanelView()
        {
            InitializeComponent();
            this.DataContext = new SolarPanelViewModel();
            listBoxPanels.ItemsSource = SolarPanelViewModel.solarPanels;
            //listBoxPanels.ItemSource = SolarPanelViewModel.solarPanels;
            //treba napraviti izgled ----> Djo kreni
        }

        private void ButtonAddPanel_Click(object sender, RoutedEventArgs e)
        {
            if ((string.IsNullOrEmpty(textBoxName.Text)) || (string.IsNullOrEmpty(textBoxMaxPower.Text)))
                return;

            SolarPanelViewModel.solarPanels.Add(new SolarPanelModel(textBoxName.Text, Double.Parse(textBoxMaxPower.Text)));
        }
    }
}

