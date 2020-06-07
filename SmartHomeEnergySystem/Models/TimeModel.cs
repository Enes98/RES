using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeEnergySystem.Models
{
    public class TimeModel
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
        public TimeModel()
        {
            Hour = 0;
            Minute = 0;
            Second = 0;
        }

    }
}
