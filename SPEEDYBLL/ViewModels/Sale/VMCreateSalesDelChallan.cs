﻿using SPEEDYDAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL.ViewModels.Sale
{
    public class VMCreateSalesDelChallan
    {
        public VMCreateSalesDelChallan()
        {
            SalesMen = new ObservableCollection<Salesman>(SSSalesManLINQ.GetSalesMen());
            Items = new ObservableCollection<SPEEDYDAL.Item>(SSItemsLINQ.GetItems());
            SalesDeliveryChallan = new SalesDeliveryChallan();
            SaleDCDetails = new ObservableCollection<SaleDCDetail>();
            DailySale = new DailySales();
            
        }
        public ObservableCollection<SaleDCDetail> SaleDCDetails
        {
            get;
            set;
        }
        public ObservableCollection<Salesman> SalesMen { get; set; }
        public static ObservableCollection<SPEEDYDAL.Item> Items { get; set; }
        public SalesDeliveryChallan SalesDeliveryChallan { get; set; }
        public SPEEDYDAL.Salesman SelectedSalesMan { get; set; }
        public DailySales DailySale { get; set; }
    }

    public class SaleDCDetail : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public long ItemID { get; set; }
        public int CTN { get; set; }
        public Nullable<int> PC { get; set; }

        private SPEEDYDAL.Item _selectedItem;
        public SPEEDYDAL.Item SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                NotifyPropertyChanged("SelectedItem");
            }

        }

        private ObservableCollection<SPEEDYDAL.Item> _items = VMCreateSalesDelChallan.Items;
        public ObservableCollection<SPEEDYDAL.Item> Items
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