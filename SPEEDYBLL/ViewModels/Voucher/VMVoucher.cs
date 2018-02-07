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
            Vouchers = new ObservableCollection<SPEEDYDAL.Voucher>(SSVouchersLINQ.GetVouchers());
        }

        public ObservableCollection<SPEEDYDAL.Voucher> Vouchers { get; set; }

        public SPEEDYDAL.Voucher SelectedVoucher { get; set; }
    }
}
