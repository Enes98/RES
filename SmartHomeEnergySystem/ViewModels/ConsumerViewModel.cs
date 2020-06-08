using SmartHomeEnergySystem.Command;
using SmartHomeEnergySystem.Commands;
using SmartHomeEnergySystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeEnergySystem.ViewModels
{
    public class ConsumerViewModel
    {
        public static ObservableCollection<ConsumerModel> consumers { get; set; }
        private ConsumerModel selectedConsumer;

        public static MyICommand DeleteConsumerCommand { get; set; }
        
        public ConsumerModel SelectedConsumer
        {
            get { return selectedConsumer; }
            set
            {
                selectedConsumer = value;
                DeleteConsumerCommand.RaiseCanExecuteChanged();
            }
        }

        public ConsumerViewModel()
        {
            loadConsumers();
            DeleteConsumerCommand = new MyICommand(OnDeleteConsumer, CanDeleteConsumer);
        }

        private void loadConsumers()
        {
            consumers = new ObservableCollection<ConsumerModel>();

            consumers.Add(new ConsumerModel("TV", 20.22));
            consumers.Add(new ConsumerModel("Air-conditioner", 100.6));
        }

        private bool CanDeleteConsumer()
        {
            return SelectedConsumer != null;
        }
        private void OnDeleteConsumer()
        {
            DeleteConsumerCommand deleteCommandC = new DeleteConsumerCommand(SelectedConsumer);
            deleteCommandC.Execute();
        }
    }
}