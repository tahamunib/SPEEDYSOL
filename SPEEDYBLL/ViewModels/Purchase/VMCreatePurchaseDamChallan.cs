using SPEEDYDAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL.ViewModels.Purchase
{
    public class VMCreatePurchaseDamChallan
    {
        public VMCreatePurchaseDamChallan(PurchaseDamageChallan _PurchaseDamageChallan = null)
        {
            Vendors = new ObservableCollection<Vendor>(SSVendorsLINQ.GetVendors());
            Godowns = new ObservableCollection<Godowns>(SSGodownsLINQ.ListGodowns());
            Items = new ObservableCollection<SPEEDYDAL.Items>(SSItemsLINQ.GetItems());
            if (_PurchaseDamageChallan != null)
            {
                PurchaseDamageChallan = _PurchaseDamageChallan;
                PurchaseDamCDetails = new ObservableCollection<PurchaseRCDetail>(SSPurchaseOrdersLINQ.GetPurchaseDamChallanItems(_PurchaseDamageChallan.sysSerial));
                SelectedVendor = PurchaseDamageChallan.Vendor;
                foreach (var item in PurchaseDamCDetails)
                {
                    item.SelectedItem = Items.FirstOrDefault(x => x.sysSerial == item.ItemID);
                    TotalCTN = TotalCTN + item.CTN;
                    TotalPcs = TotalPcs + (int)item.PC;
                }

            }
            else
            {
                PurchaseDamageChallan = new PurchaseDamageChallan();
                PurchaseDamCDetails = new ObservableCollection<PurchaseRCDetail>();
            }

        }

        public static ObservableCollection<SPEEDYDAL.Vendor> Vendors { get; set; }
        public static ObservableCollection<SPEEDYDAL.Godowns> Godowns { get; set; }
        public ObservableCollection<PurchaseRCDetail> PurchaseDamCDetails
        {
            get;
            set;
        }
        public static ObservableCollection<SPEEDYDAL.Items> Items { get; set; }
        public PurchaseDamageChallan PurchaseDamageChallan { get; set; }
        public Vendor SelectedVendor { get; set; }
        public Godowns SelectedGodown { get; set; }
        public int TotalCTN { get; set; }
        public int TotalPcs { get; set; }
    }
}
