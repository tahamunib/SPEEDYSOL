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
                                var resultingPcs = requestedPcs - stockPcs;
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
                            sdcItem.ItemID = item.ItemID;
                            sdcItem.PC = item.PC;
                            sdcItem.DCID = sdc.sysSerial;
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
    }
}
