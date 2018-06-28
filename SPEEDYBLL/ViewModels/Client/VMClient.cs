using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL.ViewModels.Client
{
    public class VMClient
    {
        public VMClient()
        {
            Clients = new ObservableCollection<SPEEDYDAL.SSClients>(SSClientLINQ.GetClients());
        }

        public ObservableCollection<SPEEDYDAL.SSClients> Clients { get; set; }

        public SPEEDYDAL.SSClients SelectedClient { get; set; }
    }
}
