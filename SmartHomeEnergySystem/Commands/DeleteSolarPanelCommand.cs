using SmartHomeEnergySystem.Models;
using SmartHomeEnergySystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeEnergySystem.Commands
{
    public class DeleteSolarPanelCommand : ICommand
    {
        private SolarPanelModel panelToDelete;

        public DeleteSolarPanelCommand(SolarPanelModel panelToDelete)
        {
            this.panelToDelete = panelToDelete;
        }

        public void Execute()
        {
            SolarPanelViewModel.solarPanels.Remove(panelToDelete);
            using (dbSHESEntities entity = new dbSHESEntities())
            {

                SolarPanelTable spmt = entity.SolarPanelTables.Where(x => x.Name == panelToDelete.Name).SingleOrDefault();
                if (spmt != null)
                {
                    entity.SolarPanelTables.Remove(spmt);
                    entity.SaveChanges();
                }
            };
        }
    }
}
