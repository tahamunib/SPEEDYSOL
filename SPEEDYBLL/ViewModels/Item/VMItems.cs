using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL.ViewModels.Item
{
    public class VMItems 
    {
        public VMItems()
        {
            Items = new ObservableCollection<SPEEDYDAL.Items>(SSItemsLINQ.GetItems());
        }

        public ObservableCollection<SPEEDYDAL.Items> Items { get; set; }

        public SPEEDYDAL.Items SelectedItem { get; set; }

    }
}
