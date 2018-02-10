using SPEEDYAuthorization;
using SPEEDYDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL
{
    public class SSUsersLINQ
    {

        public static bool AuthenticateUser(string username,string password)
        {
            using (var ssContext = new SPEEDYSOLEntities())
            {
                string passwordHash = SSAuthorization.GetHash(password);
                var user = ssContext.SSUsers.Where(x => x.LoginID == username && x.Password == passwordHash).FirstOrDefault();
                return user != null ? true : false;
            }
        }

        public static List<SSUser> GetUsers()
        {
            using (var ssContext = new SPEEDYSOLEntities())
            {
                return ssContext.SSUsers.Include("SSUsersRole").ToList();
            }
        }

        public static List<SSUsersRole> GetUserRoles()
        {
            using (var ssContext = new SPEEDYSOLEntities())
            {
                return ssContext.SSUsersRoles.ToList();
            }
        }

        public static bool SaveUser(SSUser user)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    if (user.sysSerial > 0)
                    {
                        user.UpdatedOn = DateTime.UtcNow;
                        ssContext.Entry(user).State = System.Data.Entity.EntityState.Modified;
                        ssContext.SaveChanges();
                    }
                    else
                    {
                        user.CreatedOn = DateTime.UtcNow;

                        ssContext.SSUsers.Add(user);
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

        public static bool DeleteUser(SSUser user)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    if (user != null)
                    {
                        ssContext.Entry(user).State = System.Data.Entity.EntityState.Deleted;
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
