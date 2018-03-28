using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL.ViewModels.Item
{
    public class VMBrands
    {
        public VMBrands()
        {
            Brands = new ObservableCollection<SPEEDYDAL.ItemBrand>(SSItemsLINQ.GetItemBrands());
        }

        public ObservableCollection<SPEEDYDAL.ItemBrand> Brands { get; set; }

        public SPEEDYDAL.ItemBrand SelectedBrand { get; set; }
    }
}
