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
            Clients = new ObservableCollection<SPEEDYDAL.SSClient>(SSClientLINQ.GetClients());
        }

        public ObservableCollection<SPEEDYDAL.SSClient> Clients { get; set; }

        public SPEEDYDAL.SSClient SelectedClient { get; set; }
    }
}
