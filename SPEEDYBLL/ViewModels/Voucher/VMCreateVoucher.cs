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
            dbAccounts = new ObservableCollection<SPEEDYDAL.SSAccounts>(SSAccountsLINQ.GetAccounts());
            if (_Voucher != null)
            {
                if (voucherType == VoucherType.CashPayment || voucherType == VoucherType.CashReciept)
                {
                    _accHeads = _accounts = new ObservableCollection<SPEEDYDAL.SSAccounts>(dbAccounts.Where(x => x.CategoryID == 5));
                }
                else if(voucherType == VoucherType.BankPayment || voucherType == VoucherType.BankReciept)
                {
                    _accHeads = _accounts = new ObservableCollection<SPEEDYDAL.SSAccounts>(dbAccounts.Where(x => x.CategoryID == 7));
                }
                _Voucher.VoucherTypeID = (int)voucherType;
                Voucher = _Voucher;
                _selectedAccount = _accounts.Where(x => x.sysSerial == _Voucher.AccountID).First();
                _selectedAcHead = _accHeads.Where(x => x.sysSerial == _Voucher.AcHead).First();

            }
            else
            {
                if (voucherType == VoucherType.CashPayment || voucherType == VoucherType.CashReciept)
                {

                    _accHeads  = new ObservableCollection<SPEEDYDAL.SSAccounts>(dbAccounts.Where(x => x.CategoryID == 5));
                    if (AccHeads == null)
                        throw new Exception("No Account Found with Category \"Cash In Hand\", Please make an account of type Cash In Hand to process Cash Payments/Reciepts.");
                    _selectedAcHead = _accHeads.Where(x => x.CategoryID == 5).FirstOrDefault();
                    
                }
                else if (voucherType == VoucherType.BankPayment || voucherType == VoucherType.BankReciept)
                {
                    _accHeads = new ObservableCollection<SPEEDYDAL.SSAccounts>(dbAccounts.Where(x => x.CategoryID == 7));
                    if (AccHeads == null)
                        throw new Exception("No Account Found with Category \"Bank\", Please make an account of type Bank to process Bank Payments/Reciepts.");
                }

                Voucher = new SPEEDYDAL.Vouchers();
                _accounts = dbAccounts;
                Voucher.AcHead = _selectedAcHead != null && _selectedAcHead.sysSerial > 0 ? _selectedAcHead.sysSerial : 0;
                Voucher.VoucherTypeID = (int)voucherType;
            }
        }

        private ObservableCollection<SPEEDYDAL.SSAccounts> dbAccounts;
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

        private SPEEDYDAL.SSAccounts _selectedAcHead;
        public SPEEDYDAL.SSAccounts SelectedACHead { get => _selectedAcHead; set => _selectedAcHead = value; }

        private ObservableCollection<SPEEDYDAL.SSAccounts> _accHeads;
        public ObservableCollection<SPEEDYDAL.SSAccounts> AccHeads
        {
            get { return _accHeads; }
            set
            {
                _accHeads = value;
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
