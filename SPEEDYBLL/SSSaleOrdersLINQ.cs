using SPEEDYDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL
{
    public class SSSaleOrdersLINQ
    {
        public static List<SaleOrder> GetSaleOrders()
        {
            using (var ssContext = new SPEEDYSOLEntities())
            {
                var saleOrders = ssContext.SaleOrders.Include("Salesman").Include("OrderBooker").Include("SSClient").ToList();
                return saleOrders;
            }
        }
    }
}
