using SPEEDYDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL
{
    public class SSOrderBookersLINQ
    {
        public static List<OrderBooker> GetOrderBookers()
        {
            using (var ssContext = new SPEEDYSOLEntities())
            {
                return ssContext.OrderBookers.ToList();
            }
        }

    }
}
