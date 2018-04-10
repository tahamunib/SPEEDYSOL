using SPEEDYDAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL.ViewModels.Sale
{
    public class VMSalesDelChallan
    {
        public VMSalesDelChallan()
        {
            SalesMen = new ObservableCollection<Salesman>(SSSalesManLINQ.GetSalesMen());
            Items = new ObservableCollection<SPEEDYDAL.Item>(SSItemsLINQ.GetItems());
            DailySales = new DailySales();
        }
        public ObservableCollection<Salesman> SalesMen { get; set; }
        public ObservableCollection<SPEEDYDAL.Item> Items { get; set; }
        
        public DailySales DailySales { get; set; }
    }
}
