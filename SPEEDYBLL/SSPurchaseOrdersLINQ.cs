using SPEEDYBLL.ViewModels.Purchase;
using SPEEDYDAL;
using SSCommons.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL
{
    public class SSPurchaseOrdersLINQ
    {
        public static List<PurchaseOrder> GetPurchaseOrders()
        {
            using (var ssContext = new SPEEDYSOLEntities())
            {
                var purchaseOrders = ssContext.PurchaseOrders.Include("Godown").Include("SSClient").ToList();
                return purchaseOrders;
            }
        }

        public static List<PurchaseReturnChallan> GetPurchaseRetChallans()
        {
            using (var ssContext = new SPEEDYSOLEntities())
            {
                var challans = ssContext.PurchaseReturnChallan.Include("Vendor").ToList();
                return challans;
            }
        }

        public static List<PurchaseRCDetail> GetPurchaseRetChallanItems(int prcID)
        {
            using (var ssContext = new SPEEDYSOLEntities())
            {
                var items = ssContext.PurchaseReturnChallanItems.Where(x=>x.PRCID == prcID).ToList();
                List<PurchaseRCDetail> vmList = new List<PurchaseRCDetail>();
                if(items.Count > 0)
                {
                    foreach(var item in items)
                    {
                        PurchaseRCDetail prcDetail = new PurchaseRCDetail
                        {
                            ItemID = item.ItemID,
                            CTN = item.CTN,
                            PC = item.PC
                        };
                        vmList.Add(prcDetail);
                    }
                    
                }
                return vmList;
            }
        }

        public static List<PurchaseRecievingChallan> GetPurchaseRecChallans()
        {
            using (var ssContext = new SPEEDYSOLEntities())
            {
                var challans = ssContext.PurchaseRecievingChallan.Include("Vendor").ToList();
                return challans;
            }
        }

        public static List<PurchaseRecievingChallanItems> GetPurchaseRecChallanItems(long prcID)
        {
            using (var ssContext = new SPEEDYSOLEntities())
            {
                var items = ssContext.PurchaseRecievingChallanItems.Where(x => x.PRCID == prcID).ToList();
                return items;
            }
        }

        public static List<PurchaseDamageChallan> GetPurchaseDamChallans()
        {
            using (var ssContext = new SPEEDYSOLEntities())
            {
                var challans = ssContext.PurchaseDamageChallan.Include("Vendor").ToList();
                return challans;
            }
        }

        public static List<PurchaseDamageChallanItems> GetPurchaseDamChallanItems(long pdcID)
        {
            using (var ssContext = new SPEEDYSOLEntities())
            {
                var items = ssContext.PurchaseDamageChallanItems.Where(x => x.PDamCID == pdcID).ToList();
                return items;
            }
        }

        public static bool CreatePurchaseOrder(ViewModels.Purchase.VMPurchaseOrderDetail viewModel)
        {
            try
            {
                var purchaseOrder = GeneratePurchaseOrderFromVM(viewModel);
                bool created = false;
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    ssContext.PurchaseOrders.Add(purchaseOrder);
                    ssContext.SaveChanges();

                    created = true;
                }
                return created;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private static PurchaseOrder GeneratePurchaseOrderFromVM(ViewModels.Purchase.VMPurchaseOrderDetail viewModel)
        {
            PurchaseOrder pOrder = new PurchaseOrder();
            viewModel.pOrder.PurchaseOrderDetails = (ICollection<PurchaseOrderDetail>)viewModel.PurchaseOrderDetails;

            pOrder = viewModel.pOrder;

            pOrder.ClientID = viewModel.SelectedSSClient.sysSerial;
            pOrder.GodownID = viewModel.SelectedGodown.sysSerial;

            var InvType = (SSEnums.InvType)viewModel.SelectedInvType;
            pOrder.InvType = InvType.ToString();

            var Posted = (SSEnums.Posted)viewModel.SelectedPosted;
            pOrder.isPosted = Posted == SSEnums.Posted.Yes ? true : false;

            pOrder.Remarks = viewModel.pOrder.Remarks;
            pOrder.PurchaseOrderDetails = (ICollection<PurchaseOrderDetail>)viewModel.PurchaseOrderDetails;
            pOrder.TotalDiscountPercentage = viewModel.pOrder.TotalDiscountPercentage;

            return pOrder;
        }

        public static void CreatePurRecChallan(ViewModels.Purchase.VMCreatePurchaseRecChalan purchaseRC)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {

                    PurchaseRecievingChallan prc = new PurchaseRecievingChallan();
                    prc.Code = SSCommons.SSHelper.GenerateSystemCode();
                    prc.VendorID = purchaseRC.SelectedVendor.sysSerial;
                    prc.CreatedOn = DateTime.UtcNow.Date;

                    ssContext.PurchaseRecievingChallan.Add(prc);
                    ssContext.SaveChanges();


                    List<PurchaseRecievingChallanItems> prcItems = new List<PurchaseRecievingChallanItems>();
                    foreach (var item in purchaseRC.PurchaseRCDetails)
                    {
                        PurchaseRecievingChallanItems prcItem = new PurchaseRecievingChallanItems();
                        prcItem.Ctn = item.CTN;
                        prcItem.ItemID = item.SelectedItem.sysSerial;
                        prcItem.Pcs = item.PC != null ? (int)item.PC : 0;
                        prcItem.PRCID = prc.sysSerial;

                        var gItem = ssContext.GodownItems.Where(x => x.itemID == prcItem.ItemID).FirstOrDefault();


                        if (gItem == null)
                        {
                            throw new Exception("Item not found in Godown, Please add this item in godown");
                        }
                        else
                        {
                            var purchasedPcs = (item.SelectedItem.CTNSize * item.CTN) + item.PC;
                            var stockPcs = (gItem.CTN * item.SelectedItem.CTNSize) + gItem.Pcs;
                            var resultingPcs = stockPcs + purchasedPcs;
                            long updatedCTN = (long)resultingPcs / item.SelectedItem.CTNSize;
                            int updatedPcs = (int)resultingPcs % item.SelectedItem.CTNSize;

                            gItem.CTN = updatedCTN;
                            gItem.Pcs = updatedPcs;
                            ssContext.SaveChanges();
                        }

                    }

                    ssContext.PurchaseRecievingChallanItems.AddRange(prcItems);
                    ssContext.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void CreatePurRetChallan(ViewModels.Purchase.VMCreatePurchaseRetChallan purchaseRC)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {

                    PurchaseReturnChallan prc = new PurchaseReturnChallan();
                    prc.Code = SSCommons.SSHelper.GenerateSystemCode();
                    prc.VendorID = purchaseRC.SelectedVendor.sysSerial;
                    prc.CreatedOn = DateTime.UtcNow.Date;

                    ssContext.PurchaseReturnChallan.Add(prc);
                    ssContext.SaveChanges();


                    List<PurchaseReturnChallanItems> prcItems = new List<PurchaseReturnChallanItems>();
                    foreach (var item in purchaseRC.PurchaseRCDetails)
                    {
                        PurchaseReturnChallanItems prcItem = new PurchaseReturnChallanItems();
                        prcItem.CTN = item.CTN;
                        prcItem.ItemID = item.SelectedItem.sysSerial;
                        prcItem.PC = item.PC != null ? (int)item.PC : 0;
                        prcItem.PRCID = prc.sysSerial;

                        var gItem = ssContext.GodownItems.Where(x => x.itemID == prcItem.ItemID).FirstOrDefault();


                        if (gItem == null)
                        {
                            throw new Exception("Item not found in Godown, Please add this item in godown");
                        }
                        else
                        {
                            var purchasedPcs = (item.SelectedItem.CTNSize * item.CTN) + prcItem.PC;
                            var stockPcs = (gItem.CTN * item.SelectedItem.CTNSize) + gItem.Pcs;
                            var resultingPcs = stockPcs + purchasedPcs;
                            long updatedCTN = (long)resultingPcs / item.SelectedItem.CTNSize;
                            int updatedPcs = (int)resultingPcs % item.SelectedItem.CTNSize;

                            gItem.CTN = updatedCTN;
                            gItem.Pcs = updatedPcs;
                            ssContext.SaveChanges();
                        }

                    }

                    ssContext.PurchaseReturnChallanItems.AddRange(prcItems);
                    ssContext.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void CreatePurDamChallan(ViewModels.Purchase.VMCreatePurchaseDamChallan purchaseDC)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {

                    PurchaseDamageChallan pdc = new PurchaseDamageChallan();
                    pdc.Code = SSCommons.SSHelper.GenerateSystemCode();
                    pdc.VendorID = purchaseDC.SelectedVendor.sysSerial;
                    pdc.CreatedOn = DateTime.UtcNow.Date;

                    ssContext.PurchaseDamageChallan.Add(pdc);
                    ssContext.SaveChanges();


                    List<PurchaseDamageChallanItems> pdcItems = new List<PurchaseDamageChallanItems>();
                    foreach (var item in purchaseDC.PurchaseDamCDetails)
                    {
                        PurchaseDamageChallanItems pdcItem = new PurchaseDamageChallanItems();
                        pdcItem.CTN = item.CTN;
                        pdcItem.ItemID = item.SelectedItem.sysSerial;
                        pdcItem.PC = item.PC != null ? (int)item.PC : 0;
                        pdcItem.PDamCID = pdc.sysSerial;

                        var gItem = ssContext.GodownItems.Where(x => x.itemID == pdcItem.ItemID).FirstOrDefault();


                        if (gItem == null)
                        {
                            throw new Exception("Item not found in Godown, Please add this item in godown");
                        }
                        else
                        {
                            var purchasedPcs = (item.SelectedItem.CTNSize * item.CTN) + pdcItem.PC;
                            var stockPcs = (gItem.CTN * item.SelectedItem.CTNSize) + gItem.Pcs;
                            var resultingPcs = stockPcs + purchasedPcs;
                            long updatedCTN = (long)resultingPcs / item.SelectedItem.CTNSize;
                            int updatedPcs = (int)resultingPcs % item.SelectedItem.CTNSize;

                            gItem.CTN = updatedCTN;
                            gItem.Pcs = updatedPcs;
                            ssContext.SaveChanges();
                        }

                    }

                    ssContext.PurchaseDamageChallanItems.AddRange(pdcItems);
                    ssContext.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
