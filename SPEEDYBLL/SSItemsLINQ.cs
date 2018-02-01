using SPEEDYDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL
{
    public class SSItemsLINQ
    {
        public static List<Item> GetItems()
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    return ssContext.Items.ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }   
}
