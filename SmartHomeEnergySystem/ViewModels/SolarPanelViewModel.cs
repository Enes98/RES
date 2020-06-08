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
    public class SolarPanelViewModel
    {
        public static ObservableCollection<SolarPanelModel> solarPanels { get; set; }
        private SolarPanelModel selectedPanel;

        public static MyICommand DeleteSolarPanelCommand { get; set; }

        public SolarPanelModel SelectedPanel
        {
            get { return selectedPanel; }
            set
            {
                selectedPanel = value;
                DeleteSolarPanelCommand.RaiseCanExecuteChanged();
            }
        }

        public SolarPanelViewModel()
        {
            loadSolarPanels();
            DeleteSolarPanelCommand = new MyICommand(OnDeletePanel, CanDeletePanel);
        }

        public void loadSolarPanels()
        {
            solarPanels = new ObservableCollection<SolarPanelModel>
            {
                new SolarPanelModel("Solar panel 1", 15, 7),
                new SolarPanelModel("Solar panel 2", 15, 7.2)
            };
        }

        private bool CanDeletePanel()
        {
            return SelectedPanel != null;
        }
        private void OnDeletePanel()
        {
            DeleteSolarPanelCommand deleteCommandP = new DeleteSolarPanelCommand(SelectedPanel);
            deleteCommandP.Execute();
        }
    }
}
