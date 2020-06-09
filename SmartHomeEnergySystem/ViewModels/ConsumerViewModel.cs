using SmartHomeEnergySystem.Command;
using SmartHomeEnergySystem.Commands;
using SmartHomeEnergySystem.Enums;
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
        public static MyICommand TurnOffCommand { get; set; }
        public static MyICommand TurnOnCommand { get; set; }

        public ConsumerModel SelectedConsumer
        {
            get { return selectedConsumer; }
            set
            {
                selectedConsumer = value;
                DeleteConsumerCommand.RaiseCanExecuteChanged();
                TurnOffCommand.RaiseCanExecuteChanged();
                TurnOnCommand.RaiseCanExecuteChanged();
            }
        }

        public ConsumerViewModel()
        {
            loadConsumers();
            DeleteConsumerCommand = new MyICommand(OnDeleteConsumer, CanDeleteConsumer);
            TurnOffCommand = new MyICommand(TurnOff, CanTurnOff);
            TurnOnCommand = new MyICommand(TurnOn, CanTurnOn);
        }

        private void loadConsumers()
        {
            consumers = new ObservableCollection<ConsumerModel>();
            using (dbSHESEntities entity = new dbSHESEntities())
            {
                List<ConsumerTable> cons = entity.ConsumerTables.ToList<ConsumerTable>();
                foreach (var c in cons)
                {
                    ConsumerModel consumer = new ConsumerModel(c.Name, (double)c.Consumption);
                    consumer.State = (ConsumerEnum)Enum.Parse(typeof(ConsumerEnum), c.State);
                    consumers.Add(consumer);
                }
            };
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




        private bool CanTurnOn()
        {
            return (SelectedConsumer != null && SelectedConsumer.State == Enums.ConsumerEnum.OFF);
        }
        private bool CanTurnOff()
        {
            return (SelectedConsumer != null && SelectedConsumer.State == Enums.ConsumerEnum.ON);
        }

        private void TurnOff()
        {
            TurnOffCommand cmd = new TurnOffCommand(SelectedConsumer);
            cmd.Execute();
        }

        private void TurnOn()
        {
            TurnOnCommand cmd = new TurnOnCommand(SelectedConsumer);
            cmd.Execute();
        }

    }
}