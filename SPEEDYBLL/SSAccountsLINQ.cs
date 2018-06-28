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
        public static bool SaveAccount(SSAccounts account)
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
                        account.CreatedOn = DateTime.UtcNow.Date;
                        account.UpdatedOn = DateTime.UtcNow.Date;

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

        private static string GenerateUniqueAccNo(SSAccounts account)
        {
            var accNO = string.Format("{0}-{1}", account.Name.ToUpper(), Guid.NewGuid().ToString());
            return accNO;
        }

        public static List<SSAccounts> GetAccounts()
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    return ssContext.SSAccounts.Include(nameof(AccountCategory)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<AccountCategory> GetAccountCategories()
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    return ssContext.AccountCategory.Include(nameof(AccountGroup)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool DeleteAccount(SSAccounts account)
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

        public static bool SaveAccGroup(AccountGroup accGroup)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    if (accGroup.sysSerial > 0)
                    {
                        accGroup.UpdatedOn = DateTime.UtcNow;
                        ssContext.Entry(accGroup).State = System.Data.Entity.EntityState.Modified;
                        ssContext.SaveChanges();
                    }
                    else
                    {
                        accGroup.Code = SSCommons.SSHelper.GenerateSystemCode();
                        accGroup.CreatedOn = DateTime.UtcNow.Date;
                        accGroup.UpdatedOn = DateTime.UtcNow.Date;

                        ssContext.AccountGroup.Add(accGroup);
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
        public static List<AccountGroup> GetAccountGroups()
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

        public static bool DeleteAccGroup(AccountGroup accGroup)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    if (accGroup != null)
                    {
                        ssContext.Entry(accGroup).State = System.Data.Entity.EntityState.Deleted;
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
        public static bool SaveAccCategory(AccountCategory accCategory)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    if (accCategory.sysSerial > 0)
                    {
                        accCategory.UpdatedOn = DateTime.UtcNow;
                        ssContext.Entry(accCategory).State = System.Data.Entity.EntityState.Modified;
                        ssContext.SaveChanges();
                    }
                    else
                    {
                        accCategory.Code = SSCommons.SSHelper.GenerateSystemCode();
                        accCategory.CreatedOn = DateTime.UtcNow.Date;
                        accCategory.UpdatedOn = DateTime.UtcNow.Date;

                        ssContext.AccountCategory.Add(accCategory);
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

        public static bool DeleteAccCategory(AccountCategory accCategory)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    if (accCategory != null)
                    {
                        ssContext.Entry(accCategory).State = System.Data.Entity.EntityState.Deleted;
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
