using SmartHomeEnergySystem.Models;
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
    /// Interaction logic for ConsumerView.xaml
    /// </summary>
    public partial class ConsumerView : UserControl
    {

        public static ObservableCollection<ConsumerModel> myList = new ObservableCollection<ConsumerModel>();

        public ConsumerView()
        {

            InitializeComponent();

            
            myList.Add(new ConsumerModel { Name = "Sladja", Consumption = 53.69 });
            myList.Add(new ConsumerModel { Name = "Enes", Consumption = 69.77 });
            myList.Add(new ConsumerModel { Name = "Sladja", Consumption = 53.69 });
            myList.Add(new ConsumerModel { Name = "Enes", Consumption = 69.77 });
           
          
            stPerson.ItemsSource = myList;
          

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if ((string.IsNullOrEmpty(textBoxName.Text)) && (string.IsNullOrEmpty(textBoxConsumption.Text)))
                return;

            myList.Add(new ConsumerModel { Name = textBoxName.Text, Consumption = Double.Parse(textBoxConsumption.Text) });
            
           
        }
    }
}
