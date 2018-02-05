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

        public static bool SaveItem(Item item)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    if (item.sysSerial > 0)
                    {
                        item.UpdatedOn = DateTime.UtcNow;
                        ssContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
                        ssContext.SaveChanges();
                    }
                    else
                    {
                        item.CreatedOn = DateTime.UtcNow;
                        item.UpdatedOn = DateTime.UtcNow;

                        ssContext.Items.Add(item);
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

        public static bool DeleteItem(Item item)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    if (item != null)
                    {
                        ssContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
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
