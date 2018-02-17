using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL.ViewModels.Salesmen
{
    public class VMSalesmen
    {
        public VMSalesmen()
        {
            Salesmen = new ObservableCollection<SPEEDYDAL.Salesman>(SSSalesManLINQ.GetSalesMen());
        }

        public ObservableCollection<SPEEDYDAL.Salesman> Salesmen { get; set; }

        public SPEEDYDAL.Salesman SelectedSalesman { get; set; }
    }
}
