using SPEEDYAuthorization;
using SPEEDYDAL;
using SSCommons;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL
{
    public class SSUsersLINQ
    {

        public static SSUser AuthenticateUser(string username,string password)
        {
            //using (var ssContext = new SPEEDYSOLEntities())
            //{
                string passwordHash = SSAuthorization.GetHash(password);
            //    var user = ssContext.SSUsers.Where(x => x.LoginID == username).FirstOrDefault();
            //    if (user.Password == passwordHash)
            //        return user;
            //    else
            //        return null;
            //}
            using (SqlConnection conn = new SqlConnection("Server=(local);DataBase=SPEEDYSOL;Integrated Security=SSPI"))
            {
                conn.Open();
                SSUser user = new SSUser();
                // 1.  create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand("dbo.uspGetUser", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@loginid", username));

                // execute the command
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // iterate through results, printing each to console
                    while (rdr.Read())
                    {
                        if(!string.IsNullOrEmpty(rdr["LoginID"].ToString()))
                            user.LoginID = (string)rdr["LoginID"];
                        if (!string.IsNullOrEmpty(rdr["Name"].ToString()))
                            user.Name = (string)rdr["Name"];
                        if (!string.IsNullOrEmpty(rdr["Password"].ToString()))
                            user.Password = (string)rdr["Password"];
                        if (!string.IsNullOrEmpty(rdr["RoleID"].ToString()))
                            user.RoleID = (long)rdr["RoleID"];
                        if (!string.IsNullOrEmpty(rdr["sysSerial"].ToString()))
                            user.sysSerial = (long)rdr["sysSerial"];
                        if (!string.IsNullOrEmpty(rdr["ContactNum"].ToString()))
                            user.ContactNum = (string)rdr["ContactNum"];
                        if (!string.IsNullOrEmpty(rdr["CreatedOn"].ToString()))
                            user.CreatedOn = (DateTime)rdr["CreatedOn"];
                        if (!string.IsNullOrEmpty(rdr["UpdatedOn"].ToString()))
                            user.UpdatedOn = (DateTime)rdr["UpdatedOn"];
                    }
                }
                if (user.Password == passwordHash)
                    return user;
                else
                    return null;
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
                        user.Code = SSHelper.GenerateSystemCode();
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
