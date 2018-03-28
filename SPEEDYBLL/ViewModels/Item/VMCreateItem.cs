using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL.ViewModels.Item
{
    public class VMCreateItem
    {
        public VMCreateItem(SPEEDYDAL.Item _Item = null)
        {
            ItemManufacturer = new ObservableCollection<SPEEDYDAL.ItemManufacturer>(SSItemsLINQ.GetItemManufacturers());
            ItemBrand = new ObservableCollection<SPEEDYDAL.ItemBrand>(SSItemsLINQ.GetItemBrands());
            ItemGroup = new ObservableCollection<SPEEDYDAL.ItemGroup>(SSItemsLINQ.GetItemGroups());
            if (_Item != null)
                Item = _Item;
            else
                Item = new SPEEDYDAL.Item();
        }
        public SPEEDYDAL.Item Item { get; set; }
        public ObservableCollection<SPEEDYDAL.ItemBrand> ItemBrand { get; set; }
        public ObservableCollection<SPEEDYDAL.ItemGroup> ItemGroup { get; set; }
        public ObservableCollection<SPEEDYDAL.ItemManufacturer> ItemManufacturer { get; set; }
    }
}
