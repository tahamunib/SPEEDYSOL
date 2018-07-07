using SPEEDYDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSCommons
{
    public class SSHelper
    {
        private const string ACCOUNT_CODE_FORMAT = "ACC-{0}";
        private const string ACCOUNT_CATEGORY_CODE_FORMAT = "ACC-CAT-{0}";
        private const string ACCOUNT_GROUP_CODE_FORMAT = "ACC-GRP-{0}";

        private const string GODOWN_CODE_FORMAT = "GDN-{0}";

        private const string ITEM_BRAND_CODE_FORMAT = "ITM-BRN-{0}";
        private const string ITEM_GROUP_CODE_FORMAT = "ITM-GRP-{0}";
        private const string ITEM_MANUFACTURER_CODE_FORMAT = "ITM-MFC-{0}";
        private const string ITEM_CODE_FORMAT = "ITM-{0}";

        private const string ORDER_BOOKER_CODE_FORMAT = "BKR-{0}";

        private const string PURCAHSE_DAMAGE_CHALLAN_CODE_FORMAT = "PDGC-{0}";
        private const string PURCHASE_RECIEVING_CHALLAN_CODE_FORMAT = "PRCC-{0}";
        private const string PURCHASE_RETURN_CHALLAN_CODE_FORMAT = "PRTC-{0}";

        private const string SALES_DAMAGE_CHALLAN_CODE_FORMAT = "SDGC-{0}";
        private const string SALES_DELIVERY_CHALLAN_CODE_FORMAT = "SDLC-{0}";
        private const string SALES_RETURN_CHALLAN_CODE_FORMAT = "SRTC-{0}";

        private const string SALESMAN_CODE_FORMAT = "SMN-{0}";

        private const string CLIENT_CODE_FORMAT = "CLT-{0}";

        private const string USER_CODE_FORMAT = "USR-{0}";
        private const string USER_ROLE_CODE_FORMAT = "USRR-{0}";

        private const string VENDOR_CODE_FORMAT = "VDR-{0}";

        private const string VOUCHER_CODE_FORMAT = "VCR-{0}";
        private const string VOUCHER_TYPE_CODE_FORMAT = "VCRT-{0}";

        public static string GenerateSystemCode(string entityType)
        {
            string currenDateSuffix = DateTime.UtcNow.ToString("yyMMddhhmmss");
            switch (entityType)
            {
                case nameof(Vouchers):
                    return string.Format(VOUCHER_CODE_FORMAT, currenDateSuffix);
                case nameof(AccountCategory):
                    return string.Format(ACCOUNT_CATEGORY_CODE_FORMAT, currenDateSuffix);
                case nameof(AccountGroup):
                    return string.Format(ACCOUNT_GROUP_CODE_FORMAT, currenDateSuffix);
                case nameof(SSAccounts):
                    return string.Format(ACCOUNT_CODE_FORMAT, currenDateSuffix);
                case nameof(SSClients):
                    return string.Format(CLIENT_CODE_FORMAT, currenDateSuffix);
                case nameof(SSUsers):
                    return string.Format(USER_CODE_FORMAT, currenDateSuffix);
                case nameof(SSUsersRoles):
                    return string.Format(USER_ROLE_CODE_FORMAT, currenDateSuffix);
                case nameof(PurchaseDamageChallan):
                    return string.Format(PURCAHSE_DAMAGE_CHALLAN_CODE_FORMAT, currenDateSuffix);
                case nameof(PurchaseRecievingChallan):
                    return string.Format(PURCHASE_RECIEVING_CHALLAN_CODE_FORMAT, currenDateSuffix);
                case nameof(PurchaseReturnChallan):
                    return string.Format(PURCHASE_RETURN_CHALLAN_CODE_FORMAT, currenDateSuffix);
                case nameof(SalesDeliveryChallan):
                    return string.Format(SALES_DELIVERY_CHALLAN_CODE_FORMAT, currenDateSuffix);
                case nameof(SalesDamageChallan):
                    return string.Format(SALES_DAMAGE_CHALLAN_CODE_FORMAT, currenDateSuffix);
                case nameof(SalesReturnChallan):
                    return string.Format(SALES_RETURN_CHALLAN_CODE_FORMAT, currenDateSuffix);
                case nameof(Salesman):
                    return string.Format(SALESMAN_CODE_FORMAT, currenDateSuffix);
                case nameof(OrderBooker):
                    return string.Format(ORDER_BOOKER_CODE_FORMAT, currenDateSuffix);
                case nameof(ItemBrand):
                    return string.Format(ITEM_BRAND_CODE_FORMAT, currenDateSuffix);
                case nameof(ItemGroup):
                    return string.Format(ITEM_GROUP_CODE_FORMAT, currenDateSuffix);
                case nameof(ItemManufacturer):
                    return string.Format(ITEM_MANUFACTURER_CODE_FORMAT, currenDateSuffix);
                case nameof(Items):
                    return string.Format(ITEM_CODE_FORMAT, currenDateSuffix);
                case nameof(Godowns):
                    return string.Format(GODOWN_CODE_FORMAT, currenDateSuffix);
                case nameof(Vendor):
                    return string.Format(VENDOR_CODE_FORMAT, currenDateSuffix);
            }
            return DateTime.Now.Ticks.ToString();
        }
        public static string GetAccCodeFormat()
        {
            return ACCOUNT_CODE_FORMAT;
        }


        
    }
}
