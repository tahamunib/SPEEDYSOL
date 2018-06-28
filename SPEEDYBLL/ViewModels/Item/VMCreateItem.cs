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
        public VMCreateItem(SPEEDYDAL.Items _Item = null)
        {
            ItemManufacturers = new ObservableCollection<SPEEDYDAL.ItemManufacturer>(SSItemsLINQ.GetItemManufacturers());
            ItemBrands = new ObservableCollection<SPEEDYDAL.ItemBrand>(SSItemsLINQ.GetItemBrands());
            ItemGroups = new ObservableCollection<SPEEDYDAL.ItemGroup>(SSItemsLINQ.GetItemGroups());
            if (_Item != null)
                Item = _Item;
            else
                Item = new SPEEDYDAL.Items();
        }
        public SPEEDYDAL.Items Item { get; set; }
        public ObservableCollection<SPEEDYDAL.ItemBrand> ItemBrands { get; set; }
        public ObservableCollection<SPEEDYDAL.ItemGroup> ItemGroups { get; set; }
        public ObservableCollection<SPEEDYDAL.ItemManufacturer> ItemManufacturers { get; set; }
    }
}
