using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL.ViewModels.Sale.Reports
{
    public class VMDailySalesReport
    {
        public long sysSerial { get; set; }
        public string Name { get; set; }
        public long NetValue { get; set; }
        public long GSTValue { get; set; }
        public long InclTax { get; set; }
        public ItemDetail_DailySales_Report Issued { get; set; }
        public ItemDetail_DailySales_Report Returned { get; set; }
        public ItemDetail_DailySales_Report Sale { get; set; }
    }
    public class ItemDetail_DailySales_Report
    {
        public long sysSerial { get; set; }
        public long CTNs { get; set; }
        public long PCs { get; set; }
        public long KGs { get; set; }
    }
}
