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
                        salesman.Code = SSCommons.SSHelper.GenerateSystemCode();
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

        public static long isDSRCreated(long salesmanID)
        {
            long dsrNumber = 0;
            using(var sscontext =new SPEEDYSOLEntities())
            {
                if (salesmanID > 0)
                {
                    var dsr = sscontext.DailySales.Where(x => x.SalesManID == salesmanID && x.CreatedOn.ToString() == DateTime.Today.Date.ToString()).FirstOrDefault();
                    if (dsr != null)
                    {
                        dsrNumber = dsr.DSRNumber;
                    }
                    else
                    {
                        dsrNumber = long.Parse(salesmanID.ToString()+DateTime.Now.ToString("yyMMdd"));
                    }
                }
            }
            return dsrNumber;
        }
    }
}
