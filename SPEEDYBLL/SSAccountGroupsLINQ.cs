using SPEEDYDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL
{
    public class SSAccountGroupsLINQ
    {
        public static bool SaveAccount(AccountGroup accountGroup)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    if (accountGroup.sysSerial > 0)   //Update Case
                    {
                        accountGroup.UpdatedOn = DateTime.UtcNow;
                        ssContext.Entry(accountGroup).State = System.Data.Entity.EntityState.Modified;
                        ssContext.SaveChanges();
                    }
                    else //Insert Case
                    {

                        accountGroup.CreatedOn = DateTime.UtcNow;
                        accountGroup.UpdatedOn = DateTime.UtcNow;

                        ssContext.AccountGroup.Add(accountGroup);
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
        

        public static List<AccountGroup> GetAccountGroups(int skip = 0)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    return ssContext.AccountGroup.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool DeleteAccount(AccountGroup accountGroup)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    if (accountGroup != null)
                    {
                        ssContext.Entry(accountGroup).State = System.Data.Entity.EntityState.Deleted;
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
