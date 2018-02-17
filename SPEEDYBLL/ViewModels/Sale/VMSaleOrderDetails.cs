using SPEEDYDAL;
using SSCommons.Enums;
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
    public class VMSaleOrderDetail
    {
        public VMSaleOrderDetail()
        {
            SalesMen = new ObservableCollection<Salesman>(SSSalesManLINQ.GetSalesMen());
            Bookers = new ObservableCollection<OrderBooker>(SSOrderBookersLINQ.GetOrderBookers());
            Clients = new ObservableCollection<SSClient>(SSClientLINQ.GetClients());
            Posted = new ObservableCollection<object>(Enum.GetValues(typeof(SSEnums.Posted))
                .Cast<object>()
                .Select(x => new { Value = (int)x, DisplayName = x.ToString() }));
            Items = new ObservableCollection<SPEEDYDAL.Item>(SSItemsLINQ.GetItems());

            SaleOrderDetails = new ObservableCollection<SaleOrderDetailVM>();

            sOrder = new SaleOrder();

        }
        public ObservableCollection<Salesman> SalesMen { get; set; }
        public ObservableCollection<OrderBooker> Bookers { get; set; }
        public ObservableCollection<SSClient> Clients { get; set; }
        public ObservableCollection<object> Posted { get; set; }
        public static ObservableCollection<SPEEDYDAL.Item> Items { get; set; }
        public ObservableCollection<SaleOrderDetailVM> SaleOrderDetails
        {
            get;
            set;
        }

        public Salesman SelectedSalesMan { get; set; }
        public OrderBooker SelectedBooker { get; set; }
        public SSClient SelectedSSClient { get; set; }
        public object SelectedPosted { get; set; }

        public long salesmanID { get; set; }
        public long bookerID { get; set; }

        public SaleOrder sOrder { get; set; }

    }

    public class SaleOrderDetailVM : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public long SOrderID { get; set; }
        public long ItemID { get; set; }
        public int Qty { get; set; }
        public int Bonus { get; set; }
        public long TotalDisc { get; set; }
        public long ExtraDiscount { get; set; }
        public long SaleTO { get; set; }
        public long Total { get; set; }
        public int DiscountPercentage { get; set; }

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

        private ObservableCollection<SPEEDYDAL.Item> _items = VMSaleOrderDetail.Items;
        public ObservableCollection<SPEEDYDAL.Item> SItems
        {
            get { return _items; }
            set
            {
                _items = value;
                NotifyPropertyChanged("SItems");
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }


}

