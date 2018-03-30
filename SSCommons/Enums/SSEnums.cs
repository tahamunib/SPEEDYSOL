using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSCommons.Enums
{
    public class SSEnums
    {
        public enum InvType
        {
            Credit = 0,
            Debit = 1

        }
        public enum Posted
        {
            Yes = 0,
            No = 1
        }

        public enum UserRoles
        {
            admin = 1,
            billing = 2,
            stockKeeper = 3
        }

        
    }
    
}
