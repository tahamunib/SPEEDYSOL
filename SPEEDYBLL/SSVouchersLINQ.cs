using SPEEDYDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL
{
    public class SSVouchersLINQ
    {
        public static List<Vouchers> GetVouchers()
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    return ssContext.Vouchers.Include("SSAccounts").ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool SaveVoucher(Vouchers voucher)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    if (voucher.sysSerial > 0)
                    {
                        voucher.UpdatedOn = DateTime.UtcNow;
                        ssContext.Entry(voucher).State = System.Data.Entity.EntityState.Modified;
                        ssContext.SaveChanges();
                    }
                    else
                    {
                        voucher.VoucherCode = GenerateUniqueVoucherCode();
                        voucher.CreatedOn = DateTime.UtcNow;

                        ssContext.Vouchers.Add(voucher);
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
        private static string GenerateUniqueVoucherCode()
        {
            var voucherCOde = string.Format("{0}", Guid.NewGuid().ToString());
            return voucherCOde;
        }

        public static bool DeleteVoucher(Vouchers voucher)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    if (voucher != null)
                    {
                        ssContext.Entry(voucher).State = System.Data.Entity.EntityState.Deleted;
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
