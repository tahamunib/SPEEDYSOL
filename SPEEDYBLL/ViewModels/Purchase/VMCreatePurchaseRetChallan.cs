using SPEEDYDAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL.ViewModels.Purchase
{
    public class VMCreatePurchaseRetChallan
    {
        public VMCreatePurchaseRetChallan(PurchaseReturnChallan _PurchaseReturnChallan = null)
        {
            Vendors = new ObservableCollection<Vendor>(SSVendorsLINQ.GetVendors());
            Items = new ObservableCollection<SPEEDYDAL.Items>(SSItemsLINQ.GetItems());
            if (_PurchaseReturnChallan != null)
            {
                PurchaseReturnChallan = _PurchaseReturnChallan;
                PurchaseRCDetails = new ObservableCollection<PurchaseRetCDetail>(SSPurchaseOrdersLINQ.GetPurchaseRetChallanItems(_PurchaseReturnChallan.sysSerial));
                SelectedVendor = PurchaseReturnChallan.Vendor;
                foreach(var item in PurchaseRCDetails)
                {
                    item.SelectedItem = Items.FirstOrDefault(x => x.sysSerial == item.ItemID);
                    TotalCTN = TotalCTN + item.CTN;
                    TotalPcs = TotalPcs + (int)item.PC;
                }
                
            }
            else
            {
                PurchaseReturnChallan = new PurchaseReturnChallan();
                PurchaseRCDetails = new ObservableCollection<PurchaseRetCDetail>();
            }
        }

        public static ObservableCollection<SPEEDYDAL.Vendor> Vendors { get; set; }
        public static ObservableCollection<SPEEDYDAL.Godowns> Godowns { get; set; }
        public ObservableCollection<PurchaseRetCDetail> PurchaseRCDetails
        {
            get;
            set;
        }
        public static ObservableCollection<SPEEDYDAL.Items> Items { get; set; }
        public PurchaseReturnChallan PurchaseReturnChallan { get; set; }
        public Vendor SelectedVendor { get; set; }
        public Godowns SelectedGodown { get; set; }

        public int TotalCTN { get; set; }
        public int TotalPcs { get; set; }
    }

    public class PurchaseRetCDetail : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public long sysSerial { get; set; }
        public long ItemID { get; set; }
        public int CTN { get; set; }
        public Nullable<int> PC { get; set; }

        private SPEEDYDAL.Items _selectedItem;
        public SPEEDYDAL.Items SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                NotifyPropertyChanged("SelectedItem");
            }

        }

        private ObservableCollection<SPEEDYDAL.Items> _items = VMCreatePurchaseRetChallan.Items;
        public ObservableCollection<SPEEDYDAL.Items> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                NotifyPropertyChanged("Items");
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}
