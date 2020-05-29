using SmartHomeEnergySystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeEnergySystem.ViewModels
{
    public class SolarPanelViewModel
    {
        public static ObservableCollection<SolarPanelModel> solarPanels { get; set; }

        public SolarPanelViewModel()
        {
            loadSolarPanels();
        }
        public void loadSolarPanels()
        {
            solarPanels = new ObservableCollection<SolarPanelModel>();

            solarPanels.Add(new SolarPanelModel("Solar panel 1", 15, 7));
            solarPanels.Add(new SolarPanelModel("Solar panel 2", 15, 7.2));
        }
    }
}
