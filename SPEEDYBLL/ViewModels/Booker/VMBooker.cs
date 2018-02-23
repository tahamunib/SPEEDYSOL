using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL.ViewModels.Booker
{
    public class VMBooker
    {
        public VMBooker()
        {
            Bookers = new ObservableCollection<SPEEDYDAL.OrderBooker>(SSOrderBookersLINQ.GetOrderBookers());
        }

        public ObservableCollection<SPEEDYDAL.OrderBooker> Bookers { get; set; }

        public SPEEDYDAL.OrderBooker SelectedBooker { get; set; }
    }
}
