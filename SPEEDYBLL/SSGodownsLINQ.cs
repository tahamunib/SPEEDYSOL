﻿using SPEEDYDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL
{
    public class SSGodownsLINQ
    {
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

        public static Godown GetGodownByName(string godownName)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    var godown = ssContext.Godowns.Where(x => x.Name.Equals(godownName)).FirstOrDefault();
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
                    Godown godown = new Godown();
                    godown.Name = godownName;
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

        

        public static List<Godown> ListGodowns()
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
    }
}
