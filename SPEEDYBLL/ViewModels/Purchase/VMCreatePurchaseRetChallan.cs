﻿using SPEEDYDAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL.ViewModels.Purchase
{
    public class VMCreatePurchaseRetChallan
    {
        public VMCreatePurchaseRetChallan()
        {
            Vendors = new ObservableCollection<Vendor>(SSVendorsLINQ.GetVendors());
            Items = new ObservableCollection<SPEEDYDAL.Item>(SSItemsLINQ.GetItems());
            PurchaseReturnChallan = new PurchaseReturnChallan();
            PurchaseRCDetails = new ObservableCollection<PurchaseRCDetail>();

        }

        public static ObservableCollection<SPEEDYDAL.Vendor> Vendors { get; set; }
        public ObservableCollection<PurchaseRCDetail> PurchaseRCDetails
        {
            get;
            set;
        }
        public static ObservableCollection<SPEEDYDAL.Item> Items { get; set; }
        public PurchaseReturnChallan PurchaseReturnChallan { get; set; }
        public Vendor SelectedVendor { get; set; }
    }
    
}