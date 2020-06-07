using SmartHomeEnergySystem.Models;
using SmartHomeEnergySystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeEnergySystem.Commands
{
    public class DeleteConsumerCommand : ICommand
    {
        private ConsumerModel consumerToDelete;

        public DeleteConsumerCommand(ConsumerModel consumerToDelete)
        {
            this.consumerToDelete = consumerToDelete;
        }

        public void Execute()
        {
            ConsumerViewModel.consumers.Remove(consumerToDelete);   
        }
    }
}
