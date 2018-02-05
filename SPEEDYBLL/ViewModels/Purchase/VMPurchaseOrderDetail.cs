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

namespace SPEEDYBLL.ViewModels.Purchase
{
    public class VMPurchaseOrderDetail
    {
        public VMPurchaseOrderDetail()
        {
            Godowns = new ObservableCollection<Godown>(SSGodownsLINQ.ListGodowns());
            Clients = new ObservableCollection<SSClient>(SSClientLINQ.GetClients());
            InvType = new ObservableCollection<object>(Enum.GetValues(typeof(SSEnums.InvType))
                .Cast<object>()
                .Select(x=> new { Value = (int)x, DisplayName = x.ToString()}));
            Posted = new ObservableCollection<object>(Enum.GetValues(typeof(SSEnums.Posted))
                .Cast<object>()
                .Select(x=> new { Value = (int)x, DisplayName = x.ToString()}));
            Items = new ObservableCollection<SPEEDYDAL.Item>(SSItemsLINQ.GetItems());

            PurchaseOrderDetails = new ObservableCollection<PurchaseOrderDetailVM>();

            pOrder = new PurchaseOrder();
            
        }
        public ObservableCollection<Godown> Godowns { get; set; }
        public ObservableCollection<SSClient> Clients { get; set; }
        public ObservableCollection<object> InvType { get; set; }
        public ObservableCollection<object> Posted { get; set; }
        public static ObservableCollection<SPEEDYDAL.Item> Items { get; set; }
        public ObservableCollection<PurchaseOrderDetailVM> PurchaseOrderDetails {
            get;
            set;
        }
        
        public Godown SelectedGodown { get; set; }
        public SSClient SelectedSSClient { get; set; }
        public object SelectedInvType { get; set; }
        public object SelectedPosted { get; set; }

        public int godownID { get; set; }

        public PurchaseOrder pOrder { get; set; }

    }

    public class PurchaseOrderDetailVM : INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;
        public long POrderID { get; set; }
        public long ItemID { get; set; }
        public long FlatDiscount { get; set; }
        public long GSTPercentage { get; set; }
        public long GSTValue { get; set; }
        public long MarginPercentage { get; set; }
        public long MarkupPercentage { get; set; }
        public long NetRate { get; set; }
        public int Qty { get; set; }
        public int Bonus { get; set; }
        public long TotalDisc { get; set; }
        public long DiscAfterTax { get; set; }
        public long TP { get; set; }
        public long GrossAmount { get; set; }
        public int DiscPercentage { get; set; }

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

        private ObservableCollection<SPEEDYDAL.Item> _items = VMPurchaseOrderDetail.Items;
        public ObservableCollection<SPEEDYDAL.Item> PItems { get { return _items; }
            set {
                _items = value;
                NotifyPropertyChanged("PItems");
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }


}

