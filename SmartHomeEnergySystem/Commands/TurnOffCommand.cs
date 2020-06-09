using SmartHomeEnergySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeEnergySystem.Commands
{
    public class TurnOffCommand : ICommand
    {
        private ConsumerModel consumerOff;

        public TurnOffCommand(ConsumerModel consumer)
        {
            consumerOff = consumer;
        }

        public void Execute()
        {
            consumerOff.State = Enums.ConsumerEnum.OFF;
        }
    }
}
