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
            _dsr = new ObservableCollection<Items_DailySale>(SSDailySalesLINQ.GetDSRReport(dsrNumber,ref _salesman, ref _dsrdate));
        }
        
        private ObservableCollection<Items_DailySale> _dsr;
        private string _salesman;
        public string SalesMan { get { return _salesman; } set { _salesman = value; } }
        private DateTime _dsrdate;
        public DateTime DSRDate { get { return _dsrdate; } set { _dsrdate = value; } }
        public ObservableCollection<Items_DailySale> DsrReport { get { return _dsr; } set { _dsr = value; } }
    }
    public class ItemDetail
    {
        public long CTN { get; set; }
        public long PC { get; set; }
        public double KG { get; set; }
        
    }

    public class Items_DailySale
    {
        public Items_DailySale()
        {
            this.IssueDetail = new ObservableCollection<ItemDetail>();
            this.ReturnDetail = new ObservableCollection<ItemDetail>();
            this.SaleDetail = new ObservableCollection<ItemDetail>();
        }
        public long ItemID { get; set; }
        public string ItemName { get; set; }
        public ObservableCollection<ItemDetail> IssueDetail { get; set; }
        public ObservableCollection<ItemDetail> ReturnDetail { get; set; }
        public ObservableCollection<ItemDetail> SaleDetail { get; set; }
        public double ItemNetValue { get; set; }
        public int ItemCtnSize { get; set; }
        public double NetValue { get; set; }
        public double GSTValue { get; set; }
        public double InclTax { get; set; }
    }
}
