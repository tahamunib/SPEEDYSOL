using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL.ViewModels.Vendors
{
    public class VMVendors
    {
        public VMVendors()
        {
            Vendors = new ObservableCollection<SPEEDYDAL.Vendor>(SSVendorsLINQ.GetVendors());
        }

        public ObservableCollection<SPEEDYDAL.Vendor> Vendors { get; set; }

        public SPEEDYDAL.Vendor SelectedVendor { get; set; }
    }
}
