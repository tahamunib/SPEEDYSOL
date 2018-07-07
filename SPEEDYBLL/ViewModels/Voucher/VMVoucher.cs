using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SSCommons.Enums.SSEnums;

namespace SPEEDYBLL.ViewModels.Voucher
{
    public class VMVoucher
    {
        public VMVoucher(VoucherType voucherType)
        {
            Vouchers = new ObservableCollection<SPEEDYDAL.Vouchers>(SSVouchersLINQ.GetVouchers(voucherType));
        }

        public ObservableCollection<SPEEDYDAL.Vouchers> Vouchers { get; set; }

        public SPEEDYDAL.Vouchers SelectedVoucher { get; set; }
    }
}
