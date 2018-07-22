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
        public static List<Items> GetItems()
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    return ssContext.Items.Include(nameof(ItemBrand)).Include(nameof(ItemGroup)).Include(nameof(ItemManufacturer)).ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static List<Items> GetItems(long godownID)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    var itemIDs = ssContext.GodownItems.Where(x => x.godownID == godownID).Select(x => x.itemID).ToArray();
                    return ssContext.Items.Include(nameof(ItemBrand)).Include(nameof(ItemGroup)).Include(nameof(ItemManufacturer)).Where(x=>itemIDs.Contains(x.sysSerial)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ItemManufacturer> GetItemManufacturers()
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    return ssContext.ItemManufacturer.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ItemBrand> GetItemBrands()
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    return ssContext.ItemBrand.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ItemGroup> GetItemGroups()
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    return ssContext.ItemGroup.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool SaveItem(Items item)
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
                        item.Code = SSCommons.SSHelper.GenerateSystemCode(nameof(Items));
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

        public static bool DeleteItem(Items item)
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

        public static bool SaveItemBrand(ItemBrand itemBrand)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    if (itemBrand.sysSerial > 0)
                    {
                        itemBrand.UpdatedOn = DateTime.UtcNow;
                        ssContext.Entry(itemBrand).State = System.Data.Entity.EntityState.Modified;
                        ssContext.SaveChanges();
                    }
                    else
                    {
                        itemBrand.Code = SSCommons.SSHelper.GenerateSystemCode(nameof(ItemBrand));
                        itemBrand.CreatedOn = DateTime.UtcNow;
                        itemBrand.UpdatedOn = DateTime.UtcNow;

                        ssContext.ItemBrand.Add(itemBrand);
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

        public static bool DeleteItemBrand(ItemBrand itemBrand)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    if (itemBrand != null)
                    {
                        ssContext.Entry(itemBrand).State = System.Data.Entity.EntityState.Deleted;
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

        public static bool DeleteItemManufacturer(ItemManufacturer itemManufacturer)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    if (itemManufacturer != null)
                    {
                        ssContext.Entry(itemManufacturer).State = System.Data.Entity.EntityState.Deleted;
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

        public static bool SaveItemManufacturer(ItemManufacturer itemManufacturer)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    if (itemManufacturer.sysSerial > 0)
                    {
                        itemManufacturer.UpdatedOn = DateTime.UtcNow;
                        ssContext.Entry(itemManufacturer).State = System.Data.Entity.EntityState.Modified;
                        ssContext.SaveChanges();
                    }
                    else
                    {
                        itemManufacturer.Code = SSCommons.SSHelper.GenerateSystemCode(nameof(ItemManufacturer));
                        itemManufacturer.CreatedOn = DateTime.UtcNow;
                        itemManufacturer.UpdatedOn = DateTime.UtcNow;

                        ssContext.ItemManufacturer.Add(itemManufacturer);
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

        public static bool SaveItemGroup(ItemGroup itemGroup)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    if (itemGroup.sysSerial > 0)
                    {
                        itemGroup.UpdatedOn = DateTime.UtcNow;
                        ssContext.Entry(itemGroup).State = System.Data.Entity.EntityState.Modified;
                        ssContext.SaveChanges();
                    }
                    else
                    {
                        itemGroup.Code = SSCommons.SSHelper.GenerateSystemCode(nameof(ItemGroup));
                        itemGroup.CreatedOn = DateTime.UtcNow;
                        itemGroup.UpdatedOn = DateTime.UtcNow;

                        ssContext.ItemGroup.Add(itemGroup);
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

        public static bool DeleteItemGroup(ItemGroup itemGroup)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    if (itemGroup != null)
                    {
                        ssContext.Entry(itemGroup).State = System.Data.Entity.EntityState.Deleted;
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
