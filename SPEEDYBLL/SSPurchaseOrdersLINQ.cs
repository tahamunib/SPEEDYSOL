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

        
    }
}
