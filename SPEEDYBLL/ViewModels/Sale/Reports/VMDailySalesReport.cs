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
            _dsr = SSDailySalesLINQ.GetDSR(dsrNumber);
            foreach(var issue in _dsr.SalesDeliveryChallan)
            {
                //issue.
            }
        }
        private SPEEDYDAL.DailySales _dsr;
        public long sysSerial { get; set; }
        public string Name { get; set; }
        public long NetValue { get; set; }
        public long GSTValue { get; set; }
        public long InclTax { get; set; }
        public ObservableCollection<SPEEDYDAL.SalesDeliveryChallanItems> IssueDetail { get; set; }
        public ObservableCollection<SPEEDYDAL.SalesReturnChallan> ReturnDetail { get; set; }
        public ObservableCollection<SPEEDYDAL.SalesDeliveryChallanItems> SaleDetail { get; set; }
    }
    public class ItemDetail_DailySales_Report
    {
        public long sysSerial { get; set; }
        public long CTNs { get; set; }
        public long PCs { get; set; }
        public long KGs { get; set; }
    }
}
