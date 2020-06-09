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
    /// Interaction logic for ConsumerView.xaml
    /// </summary>
    public partial class ConsumerView : UserControl
    {
        public static ObservableCollection<ConsumerModel> myList = new ObservableCollection<ConsumerModel>();

        public ConsumerView()
        {
            InitializeComponent();
            this.DataContext = new ConsumerViewModel();
            listBoxConsumers.ItemsSource = ConsumerViewModel.consumers;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if ((string.IsNullOrEmpty(textBoxName.Text)) || (string.IsNullOrEmpty(textBoxConsumption.Text)))
                return;

            ConsumerViewModel.consumers.Add(new ConsumerModel(textBoxName.Text, Double.Parse(textBoxConsumption.Text)));
            using (dbSHESEntities entity = new dbSHESEntities())
            {
                ConsumerTable cmt = new ConsumerTable()
                {
                    Name = textBoxName.Text,
                    Consumption = Double.Parse(textBoxConsumption.Text),
                    State = Enums.ConsumerEnum.OFF.ToString()
                };
                entity.ConsumerTables.Add(cmt);
                entity.SaveChanges();
            }
        }
    }
}
