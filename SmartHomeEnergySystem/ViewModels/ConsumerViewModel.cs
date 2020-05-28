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
        //public static ObservableCollection<ConsumerModel> Consumers { get; set; }

     

        //!
        ConsumerModel selected;

        public ConsumerViewModel()
        {
           // Consumers = new ObservableCollection<ConsumerModel>();
            //Consumers.Add(new ConsumerModel { Name="Sladja", Consumption=124.65});

            /*Consumers.Add(new ConsumerModel("ime2", 2213.1));
            Consumers.Add(new ConsumerModel("ime3", 12543.1));
            Consumers.Add(new ConsumerModel("ime4", 92513.1));
            Consumers.Add(new ConsumerModel("ime5", 7213.1));
            Consumers.Add(new ConsumerModel("ime6", 6213.123));
             */

           
        }

        public ConsumerModel Selected
        {
            get { return selected; }
            set
            {
                selected = value;
            }
        }


        //DODALA SLADJA

        /*public void ParameterMethod(ConsumerModel consumer)
        {
            Add(consumer);
        }
        */

    }
}