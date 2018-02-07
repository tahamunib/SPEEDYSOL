using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL.ViewModels.Voucher
{
    public class VMCreateVoucher
    {
        public VMCreateVoucher(SPEEDYDAL.Voucher _Voucher = null)
        {
            Accounts = new ObservableCollection<SPEEDYDAL.SSAccount>(SSAccountsLINQ.GetAccounts());
            if (_Voucher != null)
                Voucher = _Voucher;
            else
                Voucher = new SPEEDYDAL.Voucher();
        }
        public SPEEDYDAL.Voucher Voucher { get; set; }
        public ObservableCollection<SPEEDYDAL.SSAccount> Accounts { get; set; }
    }
}
