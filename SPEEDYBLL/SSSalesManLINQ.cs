using SPEEDYDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL
{
    public class SSSalesManLINQ
    {
        public static List<Salesman> GetSalesMen()
        {
            using (var ssContext = new SPEEDYSOLEntities())
            {
                return ssContext.Salesmen.ToList();
            }
        }

        public static bool SaveSalesman(Salesman salesman)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    if (salesman.sysSerial > 0)
                    {
                        salesman.UpdatedOn = DateTime.UtcNow;
                        ssContext.Entry(salesman).State = System.Data.Entity.EntityState.Modified;
                        ssContext.SaveChanges();
                    }
                    else
                    {
                        salesman.CreatedOn = DateTime.UtcNow;
                        salesman.UpdatedOn = DateTime.UtcNow;

                        ssContext.Salesmen.Add(salesman);
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

        public static bool DeleteItem(Salesman selectedItem)
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
    }
}
