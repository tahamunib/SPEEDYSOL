using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL.ViewModels.Sale.Reports
{
    public class VMDailySalesReport
    {
        public VMDailySalesReport(string dsrNumber)
        {
            _dsr = new ObservableCollection<Items_DailySale>(SSDailySalesLINQ.GetDSRReport(dsrNumber));
        }
        private ObservableCollection<Items_DailySale> _dsr;
        public long sysSerial { get; set; }
        public string Name { get; set; }
        public long NetValue { get; set; }
        public long GSTValue { get; set; }
        public long InclTax { get; set; }
        public ObservableCollection<Items_DailySale> DsrReport { get { return _dsr; } set { _dsr = value; } }
    }
    public class ItemDetail
    {
        public long CTN { get; set; }
        public long PC { get; set; }
        public long KG { get; set; }
    }

    public class Items_DailySale
    {
        public long ItemID { get; set; }
        public string ItemName { get; set; }
        public ItemDetail IssueDetail { get; set; }
        public ItemDetail ReturnDetail { get; set; }
        public ItemDetail SaleDetail { get; set; }
    }
}
