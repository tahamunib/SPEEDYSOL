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

        public static bool DeleteItem(OrderBooker selectedItem)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    if (selectedItem != null)
                    {
                        ssContext.Entry(selectedItem).State = System.Data.Entity.EntityState.Deleted;
                        ssContext.SaveChanges();
                        return true;
                    }
                    else
                        return false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool SaveBooker(OrderBooker booker)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    if (booker.sysSerial > 0)
                    {
                        booker.UpdatedOn = DateTime.UtcNow;
                        ssContext.Entry(booker).State = System.Data.Entity.EntityState.Modified;
                        ssContext.SaveChanges();
                    }
                    else
                    {
                        booker.CreatedOn = DateTime.UtcNow;
                        booker.UpdatedOn = DateTime.UtcNow;

                        ssContext.OrderBookers.Add(booker);
                        ssContext.SaveChanges();
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
