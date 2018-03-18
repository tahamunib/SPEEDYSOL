using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYSOL.ApplicationLogic
{
    public class UserRoles
    {
        public static long ResolveUserRole()
        {
            return (long)MainWindow.currentlyLoggedInUser.RoleID;
        }
    }
}
