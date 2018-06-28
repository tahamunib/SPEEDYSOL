using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static SSCommons.Enums.SSEnums;

namespace SPEEDYBLL.ViewModels.Voucher
{
    public class VMCreateVoucher :INotifyPropertyChanged
    {
        public VMCreateVoucher(VoucherType voucherType, SPEEDYDAL.Vouchers _Voucher = null)
        {
            _accounts = new ObservableCollection<SPEEDYDAL.SSAccounts>(SSAccountsLINQ.GetAccounts());
            if (_Voucher != null)
            {
                Voucher = _Voucher;
                SelectedAccount = _accounts.Where(x => x.sysSerial == _Voucher.AcHead).First();
                ACHead = _accounts.Where(x => x.sysSerial == _Voucher.AccountID).First();
            }
            else
            {
                if (voucherType == VoucherType.CashPayment || voucherType == VoucherType.CashReciept)
                {
                    ACHead = _accounts.Where(x => x.CategoryID == 5).FirstOrDefault();
                    if (ACHead == null)
                        throw new Exception("No Account Found with Category \"Cash In Hand\", Please make an account of type Cash In Hand to process Cash Payments/Reciepts.");

                }
                else if (voucherType == VoucherType.BankPayment || voucherType == VoucherType.BankReciept)
                {
                    ACHead = _accounts.Where(x => x.CategoryID == 7).FirstOrDefault();
                    if (ACHead == null)
                        throw new Exception("No Account Found with Category \"Bank\", Please make an account of type Bank to process Bank Payments/Reciepts.");
                }
                Voucher = new SPEEDYDAL.Vouchers();
            }
        }
        public SPEEDYDAL.Vouchers Voucher { get; set; }

        private ObservableCollection<SPEEDYDAL.SSAccounts> _accounts;
        public ObservableCollection<SPEEDYDAL.SSAccounts> Accounts
        {
            get { return _accounts; }
            set
            {
                _accounts = value;
                NotifyPropertyChanged("Accounts");
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        private SPEEDYDAL.SSAccounts _selectedAccount;
        public SPEEDYDAL.SSAccounts SelectedAccount
        {
            get { return _selectedAccount; }
            set
            {
                _selectedAccount = value;
                NotifyPropertyChanged("SelectedAccount");
            }

        }

        private SPEEDYDAL.SSAccounts _acHead;
        public SPEEDYDAL.SSAccounts ACHead { get => _acHead; set => _acHead = value; }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
