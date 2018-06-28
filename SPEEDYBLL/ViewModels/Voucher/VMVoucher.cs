using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL.ViewModels.Voucher
{
    public class VMVoucher
    {
        public VMVoucher()
        {
            Vouchers = new ObservableCollection<SPEEDYDAL.Vouchers>(SSVouchersLINQ.GetVouchers());
        }

        public ObservableCollection<SPEEDYDAL.Vouchers> Vouchers { get; set; }

        public SPEEDYDAL.Vouchers SelectedVoucher { get; set; }
    }
}
