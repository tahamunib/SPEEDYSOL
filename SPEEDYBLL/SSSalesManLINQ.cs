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
                return ssContext.Salesman.ToList();
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
                        salesman.Code = SSCommons.SSHelper.GenerateSystemCode(nameof(Salesman));
                        salesman.CreatedOn = DateTime.UtcNow;
                        salesman.UpdatedOn = DateTime.UtcNow;

                        ssContext.Salesman.Add(salesman);
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
        /// <summary>
        /// Creates DSRNumber if not created and returns it.
        /// </summary>
        /// <param name="salesmanID"></param>
        /// <param name="dsrCode"></param>
        /// <returns>DSRNumber</returns>
        public static string isDSRCreated(long salesmanID,string dsrCode)
        {
            string dsrNum = "";
            using(var sscontext =new SPEEDYSOLEntities())
            {
                if (!String.IsNullOrEmpty(dsrCode))
                {
                    var dsr = sscontext.DailySales.Where(x => x.SalesManID == salesmanID && x.CreatedOn.ToString() == DateTime.Today.Date.ToString()).FirstOrDefault();
                    if (dsr != null)
                    {
                        dsrNum = dsr.DSRNumber;
                    }
                    else
                    {
                        dsrNum = string.Format("{0}-{1}", dsrCode, DateTime.Now.ToString("yyMMdd"));
                    }
                }
            }
            return dsrNum;
        }

        public static bool isDSRCodeExists(string dsrCode)
        {
            using (var sscontext = new SPEEDYSOLEntities())
            {
                return sscontext.Salesman.Any(x => x.DSRCode == dsrCode);
            }
        }
    }
}
