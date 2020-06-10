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
            solarPanels = new ObservableCollection<SolarPanelModel>();
    
            using (dbSHESEntities entity = new dbSHESEntities())
            {
                List<SolarPanelTable> cons = entity.SolarPanelTables.ToList<SolarPanelTable>();
                if(cons != null)
                {
                    foreach (var c in cons)
                    {
                        SolarPanelModel consumer = new SolarPanelModel(c.Name, (double)c.MaxPower, (double)c.CurrentPower);
                        solarPanels.Add(consumer);
                    }
                }
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

        public static void Refresh()
        {
            if ((ClockModel.Time.Hour >= 20) && (ClockModel.Time.Hour <= 6))
                SHES.sunPower = 0;

            foreach (SolarPanelModel spm in solarPanels)
            {
                if (SHES.sunPower >= 100)
                    spm.CurrentPower = spm.MaxPower;
                else
                 spm.CurrentPower = spm.MaxPower*SHES.sunPower/100;
            }
        }

        public static double SolarPanelProduction()
        {
            double sum = 0;
            foreach(var panel in solarPanels)
            {
               sum += panel.CurrentPower;
            }
            return sum;
        }
    }
}
