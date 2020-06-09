using SmartHomeEnergySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeEnergySystem.Commands
{
    public class TurnOnCommand : ICommand
    {
        private ConsumerModel consumerOn;

        public TurnOnCommand(ConsumerModel consumer)
        {
            consumerOn = consumer;
        }

        public void Execute()
        {
            consumerOn.State = Enums.ConsumerEnum.ON;
        }
    }
}
