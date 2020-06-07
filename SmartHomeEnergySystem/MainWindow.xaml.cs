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

namespace SmartHomeEnergySystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
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
