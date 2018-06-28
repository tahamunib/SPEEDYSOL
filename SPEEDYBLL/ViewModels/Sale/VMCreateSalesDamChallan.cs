using SPEEDYDAL;
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
    public class VMCreateSalesDamChallan
    {
        public VMCreateSalesDamChallan()
        {
            SalesMen = new ObservableCollection<Salesman>(SSSalesManLINQ.GetSalesMen());
            Items = new ObservableCollection<SPEEDYDAL.Items>(SSItemsLINQ.GetItems());
            SalesDamageChallan = new SalesDamageChallan();
            SaleDamCDetails = new ObservableCollection<SaleDamCDetail>();
            DailySale = new DailySales();

        }
        public ObservableCollection<SaleDamCDetail> SaleDamCDetails
        {
            get;
            set;
        }
        public ObservableCollection<Salesman> SalesMen { get; set; }
        public ObservableCollection<Godowns> Godowns { get; set; }
        public static ObservableCollection<SPEEDYDAL.Items> Items { get; set; }
        public SalesDamageChallan SalesDamageChallan { get; set; }
        public SPEEDYDAL.Salesman SelectedSalesMan { get; set; }
        public SPEEDYDAL.Godowns SelectedGodown { get; set; }
        public DailySales DailySale { get; set; }
    }

    public class SaleDamCDetail : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
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

        private ObservableCollection<SPEEDYDAL.Items> _items = VMCreateSalesDamChallan.Items;
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
