using SPEEDYDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL
{
    public class SSGodownsLINQ
    {
        public static Godowns GetGodown(long sysSerial)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    var godown = ssContext.Godowns.Include("GodownItems").Where(x => x.sysSerial == sysSerial).FirstOrDefault();
                    return godown;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool isGodownExists(string godownName)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    var godown = ssContext.Godowns.Where(x => x.Name.Equals(godownName)).FirstOrDefault();
                    return godown != null;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static Godowns GetGodownByName(string godownName)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    var godown = ssContext.Godowns.Include("GodownItems.Items").Where(x => x.Name.Equals(godownName)).FirstOrDefault();
                    return godown;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool UpdateGodown(long sysSerial, string godownName)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    var godown = ssContext.Godowns.Where(x => x.sysSerial == sysSerial).FirstOrDefault();
                    godown.Name = godownName;
                    godown.UpdatedOn = DateTime.UtcNow;
                    ssContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AddGodown(string godownName)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    Godowns godown = new Godowns();
                    godown.Name = godownName;
                    godown.Code = SSCommons.SSHelper.GenerateSystemCode(nameof(Godowns));
                    godown.CreatedOn = DateTime.Now;
                    godown.UpdatedOn = DateTime.Now;

                    ssContext.Godowns.Add(godown);
                    ssContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

        public static List<Godowns> ListGodowns()
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    return ssContext.Godowns.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static bool DeleteGodown(long sysSerial)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    var godown = ssContext.Godowns.Where(x => x.sysSerial == sysSerial).FirstOrDefault();
                    if (godown != null)
                    {
                        ssContext.Godowns.Remove(godown);
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

        //public static List<GodownItem> GodownDetail(long godownID)
        //{
        //    try
        //    {
        //        using (var ssContext = new SPEEDYSOLEntities())
        //        {
        //            var godownDetails = ssContext.Godowns.Where(x=>x.GodownItems.)
        //        }
        //    }
        //    catch(Exception ex)
        //    {

        //    }
        //}
    }
}
