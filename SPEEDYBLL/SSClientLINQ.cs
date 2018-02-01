using SPEEDYDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL
{
    public class SSClientLINQ
    {
        public static List<SSClient> GetClients()
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    return ssContext.SSClients.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
