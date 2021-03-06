﻿using SPEEDYDAL;
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
    public class VMCreatePurchaseRecChalan
    {
        public VMCreatePurchaseRecChalan(PurchaseRecievingChallan _PurchaseReceivingChallan = null)
        {
            Vendors = new ObservableCollection<Vendor>(SSVendorsLINQ.GetVendors());
            Items = new ObservableCollection<SPEEDYDAL.Items>(SSItemsLINQ.GetItems());
            Godowns = new ObservableCollection<Godowns>(SSGodownsLINQ.ListGodowns());
            if (_PurchaseReceivingChallan != null)
            {
                PurchaseRecievingChallan = _PurchaseReceivingChallan;
                PurchaseRCDetails = new ObservableCollection<PurchaseRCDetail>(SSPurchaseOrdersLINQ.GetPurchaseRecChallanItems(_PurchaseReceivingChallan.sysSerial));
                SelectedVendor = PurchaseRecievingChallan.Vendor;
                foreach (var item in PurchaseRCDetails)
                {
                    item.SelectedItem = Items.FirstOrDefault(x => x.sysSerial == item.ItemID);
                    TotalCTN = TotalCTN + item.CTN;
                    TotalPcs = TotalPcs + (int)item.PC;
                }

            }
            else
            {
                PurchaseRecievingChallan = new PurchaseRecievingChallan();
                PurchaseRCDetails = new ObservableCollection<PurchaseRCDetail>();
            }


        }
        public int TotalCTN { get; set; }
        public int TotalPcs { get; set; }

        public static ObservableCollection<SPEEDYDAL.Vendor> Vendors { get; set; }
        public static ObservableCollection<SPEEDYDAL.Godowns> Godowns { get; set; }
        public ObservableCollection<PurchaseRCDetail> PurchaseRCDetails
        {
            get;
            set;
        }
        public static ObservableCollection<SPEEDYDAL.Items> Items { get; set; }
        public PurchaseRecievingChallan PurchaseRecievingChallan { get; set; }
        public Vendor SelectedVendor { get; set; }
        public Godowns SelectedGodown { get; set; }
    }

    public class PurchaseRCDetail : INotifyPropertyChanged
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

        private ObservableCollection<SPEEDYDAL.Items> _items = VMCreatePurchaseRecChalan.Items;
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
