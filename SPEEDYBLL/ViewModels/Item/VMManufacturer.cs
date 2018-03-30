using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL.ViewModels.Item
{
    public class VMManufacturer
    {
        public VMManufacturer()
        {
            Manufacturers = new ObservableCollection<SPEEDYDAL.ItemManufacturer>(SSItemsLINQ.GetItemManufacturers());
        }

        public ObservableCollection<SPEEDYDAL.ItemManufacturer> Manufacturers { get; set; }

        public SPEEDYDAL.ItemManufacturer SelectedManufacturer { get; set; }
    }

}
