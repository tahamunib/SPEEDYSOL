using SPEEDYDAL;
using System;
using System.Collections.Generic;
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

                        ssContext.DailySales.Add(ds);
                        ssContext.SaveChanges();

                        SalesDeliveryChallan sdc = new SalesDeliveryChallan();
                        sdc.Code = SSCommons.SSHelper.GenerateSystemCode();
                        sdc.DSRNumber = ds.sysSerial;
                        sdc.CreatedOn = DateTime.UtcNow.Date;
                        sdc.GodownID = salesDC.SelectedGodown.sysSerial;

                        ssContext.SalesDeliveryChallan.Add(sdc);
                        ssContext.SaveChanges();


                        List<SalesDeliveryChallanItems> sdcItems = new List<SalesDeliveryChallanItems>();
                        foreach (var item in salesDC.SaleDCDetails)
                        {
                            SalesDeliveryChallanItems sdcItem = new SalesDeliveryChallanItems();
                            sdcItem.CTN = item.CTN;
                            sdcItem.ItemID = item.SelectedItem.sysSerial;
                            sdcItem.PC = item.PC != null ? item.PC : 0;
                            sdcItem.DCID = sdc.sysSerial;

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
                                    throw new Exception($"Requested Item {item.SelectedItem.Name} Quantity exceeds stock: {gItem.CTN} CTN and {gItem.Pcs} Pcs!");
                                var resultingPcs = stockPcs - requestedPcs;
                                long remainingCtn = (long)resultingPcs / item.SelectedItem.CTNSize;
                                int remainingPC = (int)resultingPcs % item.SelectedItem.CTNSize;

                                gItem.CTN = remainingCtn;
                                gItem.Pcs = remainingPC;
                                ssContext.SaveChanges();
                            }
                            
                        }

                        ssContext.SalesDeliveryChallanItems.AddRange(sdcItems);
                        ssContext.SaveChanges();
                    }
                    else
                    {
                        SalesDeliveryChallan sdc = new SalesDeliveryChallan();
                        sdc.Code = SSCommons.SSHelper.GenerateSystemCode();
                        sdc.DSRNumber = dailySale.sysSerial;
                        sdc.CreatedOn = DateTime.UtcNow.Date;
                        sdc.GodownID = salesDC.SelectedGodown.sysSerial;

                        ssContext.SalesDeliveryChallan.Add(sdc);
                        ssContext.SaveChanges();


                        List<SalesDeliveryChallanItems> sdcItems = new List<SalesDeliveryChallanItems>();
                        foreach (var item in salesDC.SaleDCDetails)
                        {
                            SalesDeliveryChallanItems sdcItem = new SalesDeliveryChallanItems();
                            sdcItem.CTN = item.CTN;
                            sdcItem.ItemID = item.SelectedItem.sysSerial;
                            sdcItem.PC = item.PC;
                            sdcItem.DCID = sdc.sysSerial;

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
                                    throw new Exception($"Requested Item {item.SelectedItem.Name} Quantity exceeds stock: {gItem.CTN} CTN and {gItem.Pcs} Pcs!");
                                var resultingPcs = stockPcs - requestedPcs;
                                long remainingCtn = (long)resultingPcs / item.SelectedItem.CTNSize;
                                int remainingPC = (int)resultingPcs % item.SelectedItem.CTNSize;

                                gItem.CTN = remainingCtn;
                                gItem.Pcs = remainingPC;
                                ssContext.SaveChanges();
                            }
                        }

                        ssContext.SalesDeliveryChallanItems.AddRange(sdcItems);
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
                        src.Code = SSCommons.SSHelper.GenerateSystemCode();
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
                        sdc.Code = SSCommons.SSHelper.GenerateSystemCode();
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
                        sdc.Code = SSCommons.SSHelper.GenerateSystemCode();
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
                        sdc.Code = SSCommons.SSHelper.GenerateSystemCode();
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
    }

    
}
