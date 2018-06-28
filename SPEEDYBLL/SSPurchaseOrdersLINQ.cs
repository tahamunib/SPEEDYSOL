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
                var purchaseOrders = ssContext.PurchaseOrder.Include("Godowns").Include("SSClients").ToList();
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

        public static List<PurchaseRetCDetail> GetPurchaseRetChallanItems(int prcID)
        {
            using (var ssContext = new SPEEDYSOLEntities())
            {
                var items = ssContext.PurchaseReturnChallanItems.Where(x=>x.PRCID == prcID).ToList();
                List<PurchaseRetCDetail> vmList = new List<PurchaseRetCDetail>();
                if(items.Count > 0)
                {
                    foreach(var item in items)
                    {
                        PurchaseRetCDetail prcDetail = new PurchaseRetCDetail
                        {
                            sysSerial = item.sysSerial,
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

        public static List<PurchaseRCDetail> GetPurchaseRecChallanItems(long prcID)
        {
            using (var ssContext = new SPEEDYSOLEntities())
            {
                var items = ssContext.PurchaseRecievingChallanItems.Where(x => x.PRCID == prcID).ToList();
                List<PurchaseRCDetail> vmList = new List<PurchaseRCDetail>();
                if (items.Count > 0)
                {
                    foreach (var item in items)
                    {
                        PurchaseRCDetail prcDetail = new PurchaseRCDetail
                        {
                            sysSerial = item.sysSerial,
                            ItemID = item.ItemID,
                            CTN = (int)item.Ctn,
                            PC = (int)item.Pcs
                        };
                        vmList.Add(prcDetail);
                    }

                }
                return vmList;
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

        public static List<PurchaseRCDetail> GetPurchaseDamChallanItems(long pdcID)
        {
            using (var ssContext = new SPEEDYSOLEntities())
            {
                var items = ssContext.PurchaseDamageChallanItems.Where(x => x.PDamCID == pdcID).ToList();
                List<PurchaseRCDetail> vmList = new List<PurchaseRCDetail>();
                if (items.Count > 0)
                {
                    foreach (var item in items)
                    {
                        PurchaseRCDetail prcDetail = new PurchaseRCDetail
                        {
                            sysSerial = item.sysSerial,
                            ItemID = item.ItemID,
                            CTN = (int)item.CTN,
                            PC = (int)item.PC
                        };
                        vmList.Add(prcDetail);
                    }

                }
                return vmList;
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
                    ssContext.PurchaseOrder.Add(purchaseOrder);
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
            viewModel.pOrder.PurchaseOrderDetail = (ICollection<PurchaseOrderDetail>)viewModel.PurchaseOrderDetails;

            pOrder = viewModel.pOrder;

            pOrder.ClientID = viewModel.SelectedSSClient.sysSerial;
            pOrder.GodownID = viewModel.SelectedGodown.sysSerial;

            var InvType = (SSEnums.InvType)viewModel.SelectedInvType;
            pOrder.InvType = InvType.ToString();

            var Posted = (SSEnums.Posted)viewModel.SelectedPosted;
            pOrder.isPosted = Posted == SSEnums.Posted.Yes ? true : false;

            pOrder.Remarks = viewModel.pOrder.Remarks;
            pOrder.PurchaseOrderDetail = (ICollection<PurchaseOrderDetail>)viewModel.PurchaseOrderDetails;
            pOrder.TotalDiscountPercentage = viewModel.pOrder.TotalDiscountPercentage;

            return pOrder;
        }

        public static void CreatePurRecChallan(ViewModels.Purchase.VMCreatePurchaseRecChalan purchaseRC)
        {
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    if (purchaseRC.PurchaseRecievingChallan.sysSerial > 0)
                    {
                        purchaseRC.PurchaseRecievingChallan.UpdatedOn = DateTime.UtcNow;
                        ssContext.Entry(purchaseRC.PurchaseRecievingChallan).State = System.Data.Entity.EntityState.Modified;
                        ssContext.SaveChanges();

                        foreach (var item in purchaseRC.PurchaseRCDetails)
                        {
                            PurchaseRecievingChallanItems prcItem = ssContext.PurchaseRecievingChallanItems.Where(x => x.sysSerial == item.sysSerial).FirstOrDefault();
                            if (prcItem == null)
                            {
                                List<PurchaseRecievingChallanItems> prcItems = new List<PurchaseRecievingChallanItems>();
                                prcItem.Ctn = item.CTN;
                                prcItem.ItemID = item.SelectedItem.sysSerial;
                                prcItem.Pcs = item.PC != null ? (int)item.PC : 0;
                                prcItem.PRCID = purchaseRC.PurchaseRecievingChallan.sysSerial;

                                var gItem = ssContext.GodownItems.Where(x => x.itemID == prcItem.ItemID).FirstOrDefault();

                                if (gItem == null)
                                {
                                    throw new Exception("Item not found in Godown, Please add this item in godown");
                                }
                                else
                                {
                                    var purchasedPcs = (item.SelectedItem.CTNSize * item.CTN) + prcItem.Pcs;
                                    var stockPcs = (gItem.CTN * item.SelectedItem.CTNSize) + gItem.Pcs;
                                    var resultingPcs = stockPcs + purchasedPcs;
                                    long updatedCTN = (long)resultingPcs / item.SelectedItem.CTNSize;
                                    int updatedPcs = (int)resultingPcs % item.SelectedItem.CTNSize;

                                    gItem.CTN = updatedCTN;
                                    gItem.Pcs = updatedPcs;
                                    ssContext.SaveChanges();

                                    prcItems.Add(prcItem);
                                }



                                ssContext.PurchaseRecievingChallanItems.AddRange(prcItems);
                                ssContext.SaveChanges();
                            }
                            else
                            {
                                prcItem.ItemID = item.ItemID;
                                prcItem.Ctn = item.CTN;
                                prcItem.Pcs = (int)item.PC;

                                ssContext.Entry(prcItem).State = System.Data.Entity.EntityState.Modified;

                                var gItem = ssContext.GodownItems.Where(x => x.itemID == prcItem.ItemID).FirstOrDefault();

                                if (gItem == null)
                                {
                                    throw new Exception("Item not found in Godown, Please add this item in godown");
                                }
                                else
                                {
                                    var purchasedPcs = (item.SelectedItem.CTNSize * item.CTN) + prcItem.Pcs;
                                    var stockPcs = (gItem.CTN * item.SelectedItem.CTNSize) + gItem.Pcs;
                                    var resultingPcs = stockPcs - purchasedPcs;
                                    long updatedCTN = (long)resultingPcs / item.SelectedItem.CTNSize;
                                    int updatedPcs = (int)resultingPcs % item.SelectedItem.CTNSize;

                                    gItem.CTN = updatedCTN;
                                    gItem.Pcs = updatedPcs;

                                }
                                ssContext.SaveChanges();


                            }

                        }
                    }
                    else
                    {
                        PurchaseRecievingChallan prc = new PurchaseRecievingChallan();
                        prc.Code = SSCommons.SSHelper.GenerateSystemCode();
                        prc.VendorID = purchaseRC.SelectedVendor.sysSerial;
                        prc.CreatedOn = DateTime.UtcNow.Date;
                        prc.GodownID = purchaseRC.SelectedGodown.sysSerial;

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

                            var gItem = ssContext.GodownItems.Where(x => x.itemID == prcItem.ItemID && x.godownID == prc.GodownID).FirstOrDefault();


                            if (gItem == null)
                            {
                                GodownItems newGodownItem = new GodownItems();
                                newGodownItem.CTN = prcItem.Ctn;
                                newGodownItem.Pcs = (int)prcItem.Pcs;
                                newGodownItem.itemID = prcItem.ItemID;
                                newGodownItem.godownID = prc.GodownID;

                                ssContext.GodownItems.Add(newGodownItem);
                            }
                            else
                            {
                                var purchasedPcs = (item.SelectedItem.CTNSize * item.CTN) + prcItem.Pcs;
                                var stockPcs = (gItem.CTN * item.SelectedItem.CTNSize) + gItem.Pcs;
                                var resultingPcs = stockPcs + purchasedPcs;
                                long updatedCTN = (long)resultingPcs / item.SelectedItem.CTNSize;
                                int updatedPcs = (int)resultingPcs % item.SelectedItem.CTNSize;

                                gItem.CTN = updatedCTN;
                                gItem.Pcs = updatedPcs;
                                ssContext.SaveChanges();

                                prcItems.Add(prcItem);
                            }

                        }

                        ssContext.PurchaseRecievingChallanItems.AddRange(prcItems);
                        ssContext.SaveChanges();
                    }

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
                    if (purchaseRC.PurchaseReturnChallan.sysSerial > 0)
                    {
                        purchaseRC.PurchaseReturnChallan.UpdatedOn = DateTime.UtcNow;
                        ssContext.Entry(purchaseRC.PurchaseReturnChallan).State = System.Data.Entity.EntityState.Modified;
                        ssContext.SaveChanges();

                        foreach (var item in purchaseRC.PurchaseRCDetails)
                        {
                            PurchaseReturnChallanItems prcItem = ssContext.PurchaseReturnChallanItems.Where(x => x.sysSerial == item.sysSerial).FirstOrDefault();
                            if (prcItem == null)
                            {
                                List<PurchaseReturnChallanItems> prcItems = new List<PurchaseReturnChallanItems>();
                                prcItem.CTN = item.CTN;
                                prcItem.ItemID = item.SelectedItem.sysSerial;
                                prcItem.PC = item.PC != null ? (int)item.PC : 0;
                                prcItem.PRCID = purchaseRC.PurchaseReturnChallan.sysSerial;
                                
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

                                    prcItems.Add(prcItem);
                                }



                                ssContext.PurchaseReturnChallanItems.AddRange(prcItems);
                                ssContext.SaveChanges();
                            }
                            else
                            {
                                prcItem.ItemID = item.ItemID;
                                prcItem.CTN = item.CTN;
                                prcItem.PC = item.PC;
                                
                                ssContext.Entry(prcItem).State = System.Data.Entity.EntityState.Modified;

                                var gItem = ssContext.GodownItems.Where(x => x.itemID == prcItem.ItemID).FirstOrDefault();

                                if (gItem == null)
                                {
                                    throw new Exception("Item not found in Godown, Please add this item in godown");
                                }
                                else
                                {
                                    var purchasedPcs = (item.SelectedItem.CTNSize * item.CTN) + prcItem.PC;
                                    var stockPcs = (gItem.CTN * item.SelectedItem.CTNSize) + gItem.Pcs;
                                    var resultingPcs = stockPcs - purchasedPcs;
                                    long updatedCTN = (long)resultingPcs / item.SelectedItem.CTNSize;
                                    int updatedPcs = (int)resultingPcs % item.SelectedItem.CTNSize;

                                    gItem.CTN = updatedCTN;
                                    gItem.Pcs = updatedPcs;
                                    
                                }
                                ssContext.SaveChanges();


                            }

                        }
                    }
                    else
                    {
                        PurchaseReturnChallan prc = new PurchaseReturnChallan();
                        prc.Code = SSCommons.SSHelper.GenerateSystemCode();
                        prc.VendorID = purchaseRC.SelectedVendor.sysSerial;
                        prc.CreatedOn = DateTime.UtcNow.Date;
                        prc.GodownID = purchaseRC.SelectedGodown.sysSerial;

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

                            var gItem = ssContext.GodownItems.Where(x => x.itemID == prcItem.ItemID && x.godownID == prc.GodownID).FirstOrDefault();


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

                                prcItems.Add(prcItem);
                            }

                        }

                        ssContext.PurchaseReturnChallanItems.AddRange(prcItems);
                        ssContext.SaveChanges();
                    }

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
                    if (purchaseDC.PurchaseDamageChallan.sysSerial > 0)
                    {
                        purchaseDC.PurchaseDamageChallan.UpdatedOn = DateTime.UtcNow;
                        ssContext.Entry(purchaseDC.PurchaseDamageChallan).State = System.Data.Entity.EntityState.Modified;
                        ssContext.SaveChanges();

                        foreach (var item in purchaseDC.PurchaseDamCDetails)
                        {
                            PurchaseDamageChallanItems prdItem = ssContext.PurchaseDamageChallanItems.Where(x => x.sysSerial == item.sysSerial).FirstOrDefault();
                            if (prdItem == null)
                            {
                                List<PurchaseDamageChallanItems> prdItems = new List<PurchaseDamageChallanItems>();
                                prdItem.CTN = item.CTN;
                                prdItem.ItemID = item.SelectedItem.sysSerial;
                                prdItem.PC = item.PC != null ? (int)item.PC : 0;
                                prdItem.PDamCID = purchaseDC.PurchaseDamageChallan.sysSerial;

                                var gItem = ssContext.GodownItems.Where(x => x.itemID == prdItem.ItemID).FirstOrDefault();

                                if (gItem == null)
                                {
                                    throw new Exception("Item not found in Godown, Please add this item in godown");
                                }
                                else
                                {
                                    var purchasedPcs = (item.SelectedItem.CTNSize * item.CTN) + prdItem.PC;
                                    var stockPcs = (gItem.CTN * item.SelectedItem.CTNSize) + gItem.Pcs;
                                    var resultingPcs = stockPcs + purchasedPcs;
                                    long updatedCTN = (long)resultingPcs / item.SelectedItem.CTNSize;
                                    int updatedPcs = (int)resultingPcs % item.SelectedItem.CTNSize;

                                    gItem.CTN = updatedCTN;
                                    gItem.Pcs = updatedPcs;
                                    ssContext.SaveChanges();

                                    prdItems.Add(prdItem);
                                }



                                ssContext.PurchaseDamageChallanItems.AddRange(prdItems);
                                ssContext.SaveChanges();
                            }
                            else
                            {
                                prdItem.ItemID = item.ItemID;
                                prdItem.CTN = item.CTN;
                                prdItem.PC = item.PC;

                                ssContext.Entry(prdItem).State = System.Data.Entity.EntityState.Modified;

                                var gItem = ssContext.GodownItems.Where(x => x.itemID == prdItem.ItemID).FirstOrDefault();

                                if (gItem == null)
                                {
                                    throw new Exception("Item not found in Godown, Please add this item in godown");
                                }
                                else
                                {
                                    var purchasedPcs = (item.SelectedItem.CTNSize * item.CTN) + prdItem.PC;
                                    var stockPcs = (gItem.CTN * item.SelectedItem.CTNSize) + gItem.Pcs;
                                    var resultingPcs = stockPcs - purchasedPcs;
                                    long updatedCTN = (long)resultingPcs / item.SelectedItem.CTNSize;
                                    int updatedPcs = (int)resultingPcs % item.SelectedItem.CTNSize;

                                    gItem.CTN = updatedCTN;
                                    gItem.Pcs = updatedPcs;

                                }
                                ssContext.SaveChanges();


                            }

                        }
                    }
                    else
                    {
                        PurchaseDamageChallan prd = new PurchaseDamageChallan();
                        prd.Code = SSCommons.SSHelper.GenerateSystemCode();
                        prd.VendorID = purchaseDC.SelectedVendor.sysSerial;
                        prd.CreatedOn = DateTime.UtcNow.Date;
                        prd.GodownID = purchaseDC.SelectedGodown.sysSerial;
                        

                        ssContext.PurchaseDamageChallan.Add(prd);
                        ssContext.SaveChanges();


                        List<PurchaseDamageChallanItems> prdItems = new List<PurchaseDamageChallanItems>();
                        foreach (var item in purchaseDC.PurchaseDamCDetails)
                        {
                            PurchaseDamageChallanItems prdItem = new PurchaseDamageChallanItems();
                            prdItem.CTN = item.CTN;
                            prdItem.ItemID = item.SelectedItem.sysSerial;
                            prdItem.PC = item.PC != null ? (int)item.PC : 0;
                            prdItem.PDamCID = prd.sysSerial;

                            var gItem = ssContext.GodownItems.Where(x => x.itemID == prdItem.ItemID && x.godownID == prd.GodownID).FirstOrDefault();


                            if (gItem == null)
                            {
                                throw new Exception("Item not found in Godown, Please add this item in godown");
                            }
                            else
                            {
                                var purchasedPcs = (item.SelectedItem.CTNSize * item.CTN) + prdItem.PC;
                                var stockPcs = (gItem.CTN * item.SelectedItem.CTNSize) + gItem.Pcs;
                                var resultingPcs = stockPcs + purchasedPcs;
                                long updatedCTN = (long)resultingPcs / item.SelectedItem.CTNSize;
                                int updatedPcs = (int)resultingPcs % item.SelectedItem.CTNSize;

                                gItem.CTN = updatedCTN;
                                gItem.Pcs = updatedPcs;
                                ssContext.SaveChanges();

                                prdItems.Add(prdItem);
                            }

                        }

                        ssContext.PurchaseDamageChallanItems.AddRange(prdItems);
                        ssContext.SaveChanges();
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool DeletePurRetChallan(PurchaseReturnChallan challan)
        {
            bool res = false;
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    var challanItems = ssContext.PurchaseReturnChallanItems.Where(x => x.PRCID == challan.sysSerial).ToList();
                    foreach(var item in challanItems)
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
            catch(Exception e)
            {
                res = false;
                throw e;
            }
            return res;
        }

        public static bool DeletePurRecChallan(PurchaseRecievingChallan challan)
        {
            bool res = false;
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    var challanItems = ssContext.PurchaseRecievingChallanItems.Where(x => x.PRCID == challan.sysSerial).ToList();
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

        public static bool DeletePurDamChallan(PurchaseDamageChallan challan)
        {
            bool res = false;
            try
            {
                using (var ssContext = new SPEEDYSOLEntities())
                {
                    var challanItems = ssContext.PurchaseDamageChallanItems.Where(x => x.PDamCID == challan.sysSerial).ToList();
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
