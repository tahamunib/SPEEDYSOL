using SPEEDYBLL.ViewModels.Sale.Reports;
using SPEEDYDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL
{
    public class SSDailySalesLINQ
    {
        public static void CreateSalesDelChallan(ViewModels.Sale.VMCreateSalesDelChallan salesDC)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    var dailySale = ssContext.DailySales.Where(x => x.DSRNumber == salesDC.DailySale.DSRNumber).FirstOrDefault();
                    if (dailySale == null)
                    {
                        DailySales ds = new DailySales();
                        ds.DSRNumber = salesDC.DailySale.DSRNumber;
                        ds.SalesManID = salesDC.DailySale.SalesManID;
                        ds.CreatedOn = DateTime.UtcNow.Date;
                        
                        

                        SalesDeliveryChallan sdc = new SalesDeliveryChallan();
                        sdc.Code = SSCommons.SSHelper.GenerateSystemCode(nameof(SalesDeliveryChallan));
                        sdc.CreatedOn = DateTime.UtcNow.Date;
                        sdc.GodownID = salesDC.SelectedGodown.sysSerial;

                        


                        //List<SalesDeliveryChallanItems> sdcItems = new List<SalesDeliveryChallanItems>();
                        foreach (var item in salesDC.SaleDCDetails)
                        {
                            SalesDeliveryChallanItems sdcItem = new SalesDeliveryChallanItems();
                            sdcItem.CTN = item.CTN;
                            sdcItem.ItemID = item.SelectedItem.sysSerial;
                            sdcItem.PC = item.PC != null ? item.PC : 0;
                            

                            var gItem = ssContext.GodownItems.Where(x => x.itemID == sdcItem.ItemID && x.godownID == sdc.GodownID).FirstOrDefault();

                            if (gItem == null)
                            {
                                throw new Exception("Requested Item not present in Godown!");
                                
                            }
                            else
                            {
                                var requestedPcs = (item.SelectedItem.CTNSize * item.CTN) + item.PC != null ? (int)item.PC : 0;
                                var stockPcs = (gItem.CTN * item.SelectedItem.CTNSize) + (int)gItem.Pcs;

                                if (requestedPcs > stockPcs)
                                    throw new Exception($"Requested Item {item.SelectedItem.Name} Quantity exceeds stock: {gItem.CTN} CTN and {gItem.Pcs} Pcs!");
                                var resultingPcs = stockPcs - requestedPcs;
                                long remainingCtn = (long)resultingPcs / item.SelectedItem.CTNSize;
                                int remainingPC = (int)resultingPcs % item.SelectedItem.CTNSize;

                                gItem.CTN = remainingCtn;
                                gItem.Pcs = remainingPC;
                                ssContext.SaveChanges();

                                sdc.SalesDeliveryChallanItems.Add(sdcItem);
                            }
                            
                        }

                        ds.SalesDeliveryChallan.Add(sdc);

                        ssContext.DailySales.Add(ds);
                        ssContext.SaveChanges();
                    }
                    else
                    {
                        SalesDeliveryChallan sdc = new SalesDeliveryChallan();
                        sdc.Code = SSCommons.SSHelper.GenerateSystemCode(nameof(SalesDeliveryChallan));
                        sdc.CreatedOn = DateTime.UtcNow.Date;
                        sdc.GodownID = salesDC.SelectedGodown.sysSerial;
                        
                        //List<SalesDeliveryChallanItems> sdcItems = new List<SalesDeliveryChallanItems>();
                        foreach (var item in salesDC.SaleDCDetails)
                        {
                            SalesDeliveryChallanItems sdcItem = new SalesDeliveryChallanItems();
                            sdcItem.CTN = item.CTN;
                            sdcItem.ItemID = item.SelectedItem.sysSerial;
                            sdcItem.PC = item.PC;

                            var gItem = ssContext.GodownItems.Where(x => x.itemID == sdcItem.ItemID && x.godownID == sdc.GodownID).FirstOrDefault();

                            if (gItem == null)
                            {

                                throw new Exception("Requested Item not present in Godown!");
                            }
                            else
                            {
                                var requestedPcs = (item.SelectedItem.CTNSize * item.CTN) + (int)item.PC;
                                var stockPcs = (gItem.CTN * item.SelectedItem.CTNSize) + (int)gItem.Pcs;

                                if (requestedPcs > stockPcs)
                                    throw new Exception($"Requested Item: {item.SelectedItem.Name}`s Quantity exceeds stock: {gItem.CTN} CTN and {gItem.Pcs} Pcs!");
                                var resultingPcs = stockPcs - requestedPcs;
                                long remainingCtn = (long)resultingPcs / item.SelectedItem.CTNSize;
                                int remainingPC = (int)resultingPcs % item.SelectedItem.CTNSize;

                                gItem.CTN = remainingCtn;
                                gItem.Pcs = remainingPC;
                                ssContext.SaveChanges();

                                sdc.SalesDeliveryChallanItems.Add(sdcItem);
                            }
                        }

                        dailySale.SalesDeliveryChallan.Add(sdc);
                        ssContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void CreateSalesRetChallan(ViewModels.Sale.VMCreateSalesRetChallan salesRC)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    var dailySale = ssContext.DailySales.Where(x => x.DSRNumber == salesRC.DailySale.DSRNumber).FirstOrDefault();
                    if (dailySale == null)
                    {
                        DailySales ds = new DailySales();
                        ds.DSRNumber = salesRC.DailySale.DSRNumber;
                        ds.SalesManID = salesRC.DailySale.SalesManID;
                        ds.CreatedOn = DateTime.UtcNow.Date;

                        ssContext.DailySales.Add(ds);
                        ssContext.SaveChanges();

                        SalesReturnChallan src = new SalesReturnChallan();
                        src.Code = SSCommons.SSHelper.GenerateSystemCode(nameof(SalesReturnChallan));
                        src.DSRNumber = ds.sysSerial;
                        src.CreatedOn = DateTime.UtcNow.Date;
                        src.GodownID = salesRC.SelectedGodown.sysSerial;

                        ssContext.SalesReturnChallan.Add(src);
                        ssContext.SaveChanges();


                        List<SalesReturnChallanItems> srcItems = new List<SalesReturnChallanItems>();
                        foreach (var item in salesRC.SaleRCDetails)
                        {
                            SalesReturnChallanItems srcItem = new SalesReturnChallanItems();
                            srcItem.CTN = item.CTN;
                            srcItem.ItemID = item.SelectedItem.sysSerial;
                            srcItem.PC = item.PC != null ? (int)item.PC : 0;
                            srcItem.RCID = src.sysSerial;

                            var gItem = ssContext.GodownItems.Where(x => x.itemID == srcItem.ItemID && x.itemID == src.GodownID).FirstOrDefault();

                            var returnedPcs = (item.SelectedItem.CTNSize * item.CTN) + (int)item.PC;
                            var stockPcs = (gItem.CTN * item.SelectedItem.CTNSize) + (int)gItem.Pcs;
                            if (gItem == null)
                            {
                                throw new Exception("Requested Item not present in Godown!");
                            }
                            else
                            {
                                var resultingPcs = stockPcs + returnedPcs;
                                long updatedCTN = (long)resultingPcs / item.SelectedItem.CTNSize;
                                int updatedPcs = (int)resultingPcs % item.SelectedItem.CTNSize;

                                gItem.CTN = updatedCTN;
                                gItem.Pcs = updatedPcs;
                                ssContext.SaveChanges();
                            }

                        }

                        ssContext.SalesReturnChallanItems.AddRange(srcItems);
                        ssContext.SaveChanges();
                    }
                    else
                    {
                        SalesDeliveryChallan sdc = new SalesDeliveryChallan();
                        sdc.Code = SSCommons.SSHelper.GenerateSystemCode(nameof(SalesDeliveryChallan));
                        sdc.DSRNumber = dailySale.sysSerial;
                        sdc.CreatedOn = DateTime.UtcNow.Date;
                        sdc.GodownID = salesRC.SelectedGodown.sysSerial;

                        ssContext.SalesDeliveryChallan.Add(sdc);
                        ssContext.SaveChanges();


                        List<SalesReturnChallanItems> srcItems = new List<SalesReturnChallanItems>();
                        foreach (var item in salesRC.SaleRCDetails)
                        {
                            SalesReturnChallanItems srcItem = new SalesReturnChallanItems();
                            srcItem.CTN = item.CTN;
                            srcItem.ItemID = item.SelectedItem.sysSerial;
                            srcItem.PC = (int)item.PC;
                            srcItem.RCID = sdc.sysSerial;

                            var gItem = ssContext.GodownItems.Where(x => x.itemID == srcItem.ItemID).FirstOrDefault();

                            var returnedPcs = (item.SelectedItem.CTNSize * item.CTN) + (int)item.PC;
                            var stockPcs = (gItem.CTN * item.SelectedItem.CTNSize) + (int)gItem.Pcs;
                            if (gItem == null)
                            {
                                throw new Exception("Requested Item not present in Godown");
                            }
                            else
                            {
                                var resultingPcs = stockPcs + returnedPcs;
                                long updatedCtn = (long)resultingPcs / item.SelectedItem.CTNSize;
                                int updatedPcs = (int)resultingPcs % item.SelectedItem.CTNSize;

                                gItem.CTN = updatedCtn;
                                gItem.Pcs = updatedPcs;
                                ssContext.SaveChanges();
                            }
                        }

                        ssContext.SalesReturnChallanItems.AddRange(srcItems);
                        ssContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void CreateSalesDamChallan(ViewModels.Sale.VMCreateSalesDamChallan salesDC)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    var dailySale = ssContext.DailySales.Where(x => x.DSRNumber == salesDC.DailySale.DSRNumber).FirstOrDefault();
                    if (dailySale == null)
                    {
                        DailySales ds = new DailySales();
                        ds.DSRNumber = salesDC.DailySale.DSRNumber;
                        ds.SalesManID = salesDC.DailySale.SalesManID;
                        ds.CreatedOn = DateTime.UtcNow.Date;

                        ssContext.DailySales.Add(ds);
                        ssContext.SaveChanges();

                        SalesDamageChallan sdc = new SalesDamageChallan();
                        sdc.Code = SSCommons.SSHelper.GenerateSystemCode(nameof(SalesDamageChallan));
                        sdc.DSRNumber = ds.sysSerial;
                        sdc.CreatedOn = DateTime.UtcNow.Date;
                        sdc.GodownID = salesDC.SelectedGodown.sysSerial;

                        ssContext.SalesDamageChallan.Add(sdc);
                        ssContext.SaveChanges();


                        List<SalesDamageChallanItems> sdcItems = new List<SalesDamageChallanItems>();
                        foreach (var item in salesDC.SaleDamCDetails)
                        {
                            SalesDamageChallanItems sdcItem = new SalesDamageChallanItems();
                            sdcItem.CTN = item.CTN;
                            sdcItem.ItemID = item.SelectedItem.sysSerial;
                            sdcItem.PC = item.PC != null ? item.PC : 0;
                            sdcItem.DamCID = sdc.sysSerial;

                            var gItem = ssContext.GodownItems.Where(x => x.itemID == sdcItem.ItemID && x.godownID == sdc.GodownID).FirstOrDefault();

                            var requestedPcs = (item.SelectedItem.CTNSize * item.CTN) + (int)item.PC;
                            var stockPcs = (gItem.CTN * item.SelectedItem.CTNSize) + (int)gItem.Pcs;
                            if (gItem == null)
                            {
                                throw new Exception("Requested Item not present in Godown !");
                            }
                            else
                            {
                                var resultingPcs = stockPcs + requestedPcs;
                                long updatedCTN = (long)resultingPcs / item.SelectedItem.CTNSize;
                                int updatedPcs = (int)resultingPcs % item.SelectedItem.CTNSize;

                                gItem.CTN = updatedCTN;
                                gItem.Pcs = updatedPcs;
                                ssContext.SaveChanges();
                            }

                        }

                        ssContext.SalesDamageChallanItems.AddRange(sdcItems);
                        ssContext.SaveChanges();
                    }
                    else
                    {
                        SalesDamageChallan sdc = new SalesDamageChallan();
                        sdc.Code = SSCommons.SSHelper.GenerateSystemCode(nameof(SalesDamageChallan));
                        sdc.DSRNumber = dailySale.sysSerial;
                        sdc.CreatedOn = DateTime.UtcNow.Date;
                        sdc.GodownID = salesDC.SelectedGodown.sysSerial;

                        ssContext.SalesDamageChallan.Add(sdc);
                        ssContext.SaveChanges();


                        List<SalesDamageChallanItems> sdcItems = new List<SalesDamageChallanItems>();
                        foreach (var item in salesDC.SaleDamCDetails)
                        {
                            SalesDamageChallanItems sdcItem = new SalesDamageChallanItems();
                            sdcItem.CTN = item.CTN;
                            sdcItem.ItemID = item.SelectedItem.sysSerial;
                            sdcItem.PC = item.PC != null ? item.PC : 0;
                            sdcItem.DamCID = sdc.sysSerial;

                            var gItem = ssContext.GodownItems.Where(x => x.itemID == sdcItem.ItemID && x.itemID == sdc.GodownID).FirstOrDefault();

                            var requestedPcs = (item.SelectedItem.CTNSize * item.CTN) + (int)item.PC;
                            var stockPcs = (gItem.CTN * item.SelectedItem.CTNSize) + (int)gItem.Pcs;
                            if (gItem == null)
                            {
                                throw new Exception("Requested Item not present in Godown !");
                            }
                            else
                            {
                                var resultingPcs = stockPcs + requestedPcs;
                                long updatedCTN = (long)resultingPcs / item.SelectedItem.CTNSize;
                                int updatedPcs = (int)resultingPcs % item.SelectedItem.CTNSize;

                                gItem.CTN = updatedCTN;
                                gItem.Pcs = updatedPcs;
                                ssContext.SaveChanges();
                            }

                        }

                        ssContext.SalesDamageChallanItems.AddRange(sdcItems);
                        ssContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<SalesReturnChallan> GetSalesReturnChallans()
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    return ssContext.SalesReturnChallan.ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static List<SalesDeliveryChallan> GetSalesDelChallans()
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    return ssContext.SalesDeliveryChallan.Include(nameof(DailySales)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool DeleteSalesRetChallan(SalesReturnChallan challan)
        {
            bool res = false;
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    var challanItems = ssContext.SalesReturnChallanItems.Where(x => x.RCID == challan.sysSerial).ToList();
                    foreach (var item in challanItems)
                    {
                        ssContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    }
                    if (challan != null)
                    {
                        ssContext.Entry(challan).State = System.Data.Entity.EntityState.Deleted;
                        ssContext.SaveChanges();
                        res = true;
                    }
                    else
                        res = false;
                }
            }
            catch (Exception e)
            {
                res = false;
                throw e;
            }
            return res;
        }

        public static bool DeleteSalesDelChallan(SalesDeliveryChallan challan)
        {
            bool res = false;
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    var challanItems = ssContext.SalesDeliveryChallanItems.Where(x => x.DCID == challan.sysSerial).ToList();
                    foreach (var item in challanItems)
                    {
                        ssContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    }
                    if (challan != null)
                    {
                        ssContext.Entry(challan).State = System.Data.Entity.EntityState.Deleted;
                        ssContext.SaveChanges();
                        res = true;
                    }
                    else
                        res = false;
                }
            }
            catch (Exception e)
            {
                res = false;
                throw e;
            }
            return res;
        }

        public static DailySales GetDSR(string dsrNumber)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    return ssContext.DailySales.Include(nameof(SalesDeliveryChallan)).Include(nameof(SalesDamageChallanItems)).Include(nameof(SalesReturnChallan)).Include(nameof(SalesReturnChallanItems)).Include(nameof(SalesDamageChallan)).Include(nameof(SalesDamageChallanItems)).Where(x=>x.DSRNumber == dsrNumber).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Items_DailySale> GetDSRReport(string dsrSysSerial,ref string salesman,ref DateTime dsrdate)
        {
            try
            {
                List<Items_DailySale> dsrReport = new List<Items_DailySale>();
                using (SqlConnection conn = new SqlConnection("Server=(local);DataBase=SPEEDYSOL;Integrated Security=SSPI"))
                {
                    conn.Open();
                    
                    // 1.  create a command object identifying the stored procedure
                    SqlCommand cmd = new SqlCommand("dbo.sp_GetDailySales_Report", conn);

                    // 2. set the command object so it knows to execute a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 3. add parameter to command, which will be passed to the stored procedure
                    cmd.Parameters.Add(new SqlParameter("@DsrNumber", dsrSysSerial));

                    // execute the command
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        // iterate through results, printing each to console
                        while (rdr.Read())
                        {
                            Items_DailySale itemSale = new Items_DailySale();
                            ItemDetail IssueDetail = new ItemDetail();
                            ItemDetail ReturnDetail = new ItemDetail();
                            ItemDetail SaleDetail = new ItemDetail();

                            if (!string.IsNullOrEmpty(rdr["ItemId"].ToString()))
                                itemSale.ItemID = (long)rdr["ItemId"];
                            if (!string.IsNullOrEmpty(rdr["ItemName"].ToString()))
                                itemSale.ItemName = (string)rdr["ItemName"];
                            if (!string.IsNullOrEmpty(rdr["IssuedCtns"].ToString()))
                                IssueDetail.CTN = (int)rdr["IssuedCtns"];
                            if (!string.IsNullOrEmpty(rdr["IssuedPcs"].ToString()))
                                IssueDetail.PC = (int)rdr["IssuedPcs"];
                            if (!string.IsNullOrEmpty(rdr["IssuedKgs"].ToString()))
                                IssueDetail.KG = (double)rdr["IssuedKgs"];
                            if (!string.IsNullOrEmpty(rdr["ReturnedCtns"].ToString()))
                                ReturnDetail.CTN = (int)rdr["ReturnedCtns"];
                            if (!string.IsNullOrEmpty(rdr["ReturnedPcs"].ToString()))
                                ReturnDetail.PC = (int)rdr["ReturnedPcs"];
                            if (!string.IsNullOrEmpty(rdr["ReturnedKgs"].ToString()))
                                ReturnDetail.KG = (double)rdr["ReturnedKgs"];
                            if (!string.IsNullOrEmpty(rdr["DamagedCtns"].ToString()))
                                ReturnDetail.CTN = ReturnDetail.CTN +(int)rdr["DamagedCtns"];
                            if (!string.IsNullOrEmpty(rdr["DamagedPcs"].ToString()))
                                ReturnDetail.PC = ReturnDetail.PC +(int)rdr["DamagedPcs"];
                            if (!string.IsNullOrEmpty(rdr["DamagedKgs"].ToString()))
                                ReturnDetail.KG = ReturnDetail.KG +(double)rdr["DamagedKgs"];
                            if (!string.IsNullOrEmpty(rdr["ItemNetValue"].ToString()))
                                itemSale.ItemNetValue = (double)rdr["ItemNetValue"];
                            if (!string.IsNullOrEmpty(rdr["ItemCtnSize"].ToString()))
                                itemSale.ItemCtnSize = (int)rdr["ItemCtnSize"];

                            if (!string.IsNullOrEmpty(rdr["DSRDate"].ToString()))
                                dsrdate = (DateTime)rdr["DSRDate"];
                            if (!string.IsNullOrEmpty(rdr["SalesMan"].ToString()))
                                salesman = (string)rdr["SalesMan"];


                            SaleDetail.CTN = IssueDetail.CTN - ReturnDetail.CTN;
                            SaleDetail.PC = IssueDetail.PC - ReturnDetail.PC;
                            SaleDetail.KG = IssueDetail.KG - ReturnDetail.KG;

                            itemSale.NetValue = itemSale.ItemNetValue * ((itemSale.ItemCtnSize * SaleDetail.CTN) + SaleDetail.PC);
                            itemSale.GSTValue = itemSale.NetValue * 0.13;
                            itemSale.InclTax = itemSale.NetValue + itemSale.GSTValue;

                            itemSale.IssueDetail.Add(IssueDetail);
                            itemSale.ReturnDetail.Add(ReturnDetail);
                            itemSale.SaleDetail.Add(SaleDetail);

                            dsrReport.Add(itemSale);
                        }
                    }
                    
                }
                return dsrReport;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static long GetDSRID(string dsrNumber)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    return ssContext.DailySales.Where(x => x.DSRNumber == dsrNumber).Select(x=>x.sysSerial).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    
}
