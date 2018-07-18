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
            //foreach(var issue in _dsr.SalesDeliveryChallan)
            //{
            //    //issue.
            //}
        }
        private ObservableCollection<Items_DailySale> _dsr;
        public long sysSerial { get; set; }
        public string Name { get; set; }
        public long NetValue { get; set; }
        public long GSTValue { get; set; }
        public long InclTax { get; set; }
        public ObservableCollection<Items_DailySale> DsrReport { get { return _dsr; } set { _dsr = value; } }
    }
    public class ItemDetail_DailySales_Report
    {
        public long sysSerial { get; set; }
        public long CTNs { get; set; }
        public long PCs { get; set; }
        public long KGs { get; set; }
    }

    public class Items_DailySale
    {
        public long ItemID { get; set; }
        public string ItemName { get; set; }
        public int IssuedCtn { get; set; }
        public int IssuedPcs { get; set; }
        public int IssuedKgs { get; set; }
        public int ReturnedCtns { get; set; }
        public int ReturnedPcs { get; set; }
        public int ReturnedKgs { get; set; }
        public int DamagedCtns { get; set; }
        public int DamagedPcs { get; set; }
        public int DamagedKgs { get; set; }
    }
}
