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

    }
}
