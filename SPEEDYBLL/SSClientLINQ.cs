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

        public static bool SaveClient(SSClient client)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    if (client.sysSerial > 0)
                    {
                        client.UpdatedOn = DateTime.UtcNow;
                        ssContext.Entry(client).State = System.Data.Entity.EntityState.Modified;
                        ssContext.SaveChanges();
                    }
                    else
                    {

                        client.CreatedOn = DateTime.UtcNow;
                        client.UpdatedOn = DateTime.UtcNow;

                        ssContext.SSClients.Add(client);
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

        public static bool DeleteClient(SSClient client)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    if (client != null)
                    {
                        ssContext.Entry(client).State = System.Data.Entity.EntityState.Deleted;
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
