using SPEEDYDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL
{
    public class SSAccountsLINQ
    {
        public static bool SaveAccount(SSAccount account)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    if (account.sysSerial > 0)
                    {
                        account.UpdatedOn = DateTime.UtcNow;
                        ssContext.Entry(account).State = System.Data.Entity.EntityState.Modified;
                        ssContext.SaveChanges();
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(account.Remarks))
                            account.Remarks = "";
                        account.AccNo = GenerateUniqueAccNo(account);
                        account.CreatedOn = DateTime.UtcNow;
                        account.UpdatedOn = DateTime.UtcNow;

                        ssContext.SSAccounts.Add(account);
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

        private static string GenerateUniqueAccNo(SSAccount account)
        {
            var accNO = string.Format("{0}-{1}", account.Name.ToUpper(), Guid.NewGuid().ToString());
            return accNO;
        }

        public static List<SSAccount> GetAccounts()
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    return ssContext.SSAccounts.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool DeleteAccount(SSAccount account)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    if (account != null)
                    {
                        ssContext.Entry(account).State = System.Data.Entity.EntityState.Deleted;
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
