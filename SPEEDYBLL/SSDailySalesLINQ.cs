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
                    var dailySale = ssContext.DailySales.Where(x => x.DSRNumber == salesDC.SalesDeliveryChallan.DSRNumber).FirstOrDefault();
                    if (dailySale == null)
                    {
                        DailySales ds = new DailySales();
                        ds.DSRNumber = salesDC.SalesDeliveryChallan.DSRNumber;
                        ds.SalesManID = salesDC.DailySale.SalesManID;
                        ds.CreatedOn = DateTime.UtcNow.Date;

                        ssContext.DailySales.Add(ds);

                        SalesDeliveryChallan sdc = new SalesDeliveryChallan();
                        sdc.Code = SSCommons.SSHelper.GenerateSystemCode();
                        sdc.DSRNumber = salesDC.SalesDeliveryChallan.DSRNumber;
                        sdc.CreatedOn = DateTime.UtcNow.Date;

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

                            var gItem = ssContext.GodownItems.Where(x => x.itemID == sdcItem.ItemID).FirstOrDefault();

                            var requestedPcs = (item.SelectedItem.CTNSize * item.CTN) + item.PC;
                            var stockPcs = (gItem.CTN * item.SelectedItem.CTNSize) + gItem.Pcs;
                            if (gItem == null || requestedPcs > stockPcs)
                            {
                                throw new Exception("Requested Item not present in Godown or Quantity exceeds stock!");
                            }
                            else
                            {
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
                        sdc.DSRNumber = dailySale.DSRNumber;
                        sdc.CreatedOn = DateTime.UtcNow.Date;

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

                            var gItem = ssContext.GodownItems.Where(x => x.itemID == sdcItem.ItemID).FirstOrDefault();

                            var requestedPcs = (item.SelectedItem.CTNSize * item.CTN) + item.PC;
                            var stockPcs = (gItem.CTN * item.SelectedItem.CTNSize) + gItem.Pcs;
                            if (gItem == null || requestedPcs > stockPcs)
                            {
                                throw new Exception("Requested Item not present in Godown or Quantity exceeds stock!");
                            }
                            else
                            {
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
                    var dailySale = ssContext.DailySales.Where(x => x.DSRNumber == salesRC.SalesReturnChallan.DSRNumber).FirstOrDefault();
                    if (dailySale == null)
                    {
                        DailySales ds = new DailySales();
                        ds.DSRNumber = salesRC.SalesReturnChallan.DSRNumber;
                        ds.SalesManID = salesRC.DailySale.SalesManID;
                        ds.CreatedOn = DateTime.UtcNow.Date;

                        ssContext.DailySales.Add(ds);

                        SalesReturnChallan src = new SalesReturnChallan();
                        src.Code = SSCommons.SSHelper.GenerateSystemCode();
                        src.DSRNumber = salesRC.SalesReturnChallan.DSRNumber;
                        src.CreatedOn = DateTime.UtcNow.Date;

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

                            var gItem = ssContext.GodownItems.Where(x => x.itemID == srcItem.ItemID).FirstOrDefault();

                            var returnedPcs = (item.SelectedItem.CTNSize * item.CTN) + item.PC;
                            var stockPcs = (gItem.CTN * item.SelectedItem.CTNSize) + gItem.Pcs;
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
                        sdc.DSRNumber = dailySale.DSRNumber;
                        sdc.CreatedOn = DateTime.UtcNow.Date;

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

                            var returnedPcs = (item.SelectedItem.CTNSize * item.CTN) + item.PC;
                            var stockPcs = (gItem.CTN * item.SelectedItem.CTNSize) + gItem.Pcs;
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
                    var dailySale = ssContext.DailySales.Where(x => x.DSRNumber == salesDC.SalesDamageChallan.DSRNumber).FirstOrDefault();
                    if (dailySale == null)
                    {
                        DailySales ds = new DailySales();
                        ds.DSRNumber = salesDC.SalesDamageChallan.DSRNumber;
                        ds.SalesManID = salesDC.DailySale.SalesManID;
                        ds.CreatedOn = DateTime.UtcNow.Date;

                        ssContext.DailySales.Add(ds);

                        SalesDamageChallan sdc = new SalesDamageChallan();
                        sdc.Code = SSCommons.SSHelper.GenerateSystemCode();
                        sdc.DSRNumber = salesDC.SalesDamageChallan.DSRNumber;
                        sdc.CreatedOn = DateTime.UtcNow.Date;

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

                            var gItem = ssContext.GodownItems.Where(x => x.itemID == sdcItem.ItemID).FirstOrDefault();

                            var requestedPcs = (item.SelectedItem.CTNSize * item.CTN) + item.PC;
                            var stockPcs = (gItem.CTN * item.SelectedItem.CTNSize) + gItem.Pcs;
                            if (gItem == null || requestedPcs > stockPcs)
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
                        sdc.DSRNumber = salesDC.SalesDamageChallan.DSRNumber;
                        sdc.CreatedOn = DateTime.UtcNow.Date;

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

                            var gItem = ssContext.GodownItems.Where(x => x.itemID == sdcItem.ItemID).FirstOrDefault();

                            var requestedPcs = (item.SelectedItem.CTNSize * item.CTN) + item.PC;
                            var stockPcs = (gItem.CTN * item.SelectedItem.CTNSize) + gItem.Pcs;
                            if (gItem == null || requestedPcs > stockPcs)
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
    }
}
