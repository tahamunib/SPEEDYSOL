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
            Items = new ObservableCollection<SPEEDYDAL.Item>(SSItemsLINQ.GetItems());
        }

        public ObservableCollection<SPEEDYDAL.Item> Items { get; set; }

        public SPEEDYDAL.Item SelectedItem { get; set; }

    }
}
