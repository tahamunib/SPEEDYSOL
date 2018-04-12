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


    }
}
