using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL.ViewModels.Item
{
    public class VMItemGroups
    {
        public VMItemGroups()
        {
            Groups = new ObservableCollection<SPEEDYDAL.ItemGroup>(SSItemsLINQ.GetItemGroups());
        }

        public ObservableCollection<SPEEDYDAL.ItemGroup> Groups { get; set; }

        public SPEEDYDAL.ItemGroup SelectedGroup { get; set; }
    }
}
