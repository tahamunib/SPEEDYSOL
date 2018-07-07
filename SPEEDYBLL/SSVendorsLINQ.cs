using SPEEDYDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL
{
    public class SSVendorsLINQ
    {
        public static bool SaveVendor(Vendor vendor)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    if (vendor.sysSerial > 0)
                    {
                        vendor.UpdatedOn = DateTime.UtcNow;
                        ssContext.Entry(vendor).State = System.Data.Entity.EntityState.Modified;
                        ssContext.SaveChanges();
                    }
                    else
                    {
                        vendor.Code = SSCommons.SSHelper.GenerateSystemCode(nameof(Vendor));
                        vendor.CreatedOn = DateTime.UtcNow;
                        vendor.UpdatedOn = DateTime.UtcNow;

                        ssContext.Vendor.Add(vendor);
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

        public static List<Vendor> GetVendors()
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    return ssContext.Vendor.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool DeleteVendor(Vendor vendor)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    if (vendor != null)
                    {
                        ssContext.Entry(vendor).State = System.Data.Entity.EntityState.Deleted;
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
