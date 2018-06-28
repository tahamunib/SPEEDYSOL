using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL.ViewModels.Account
{
    public class VMAccount
    {
        public VMAccount()
        {
            Accounts = new ObservableCollection<SPEEDYDAL.SSAccounts>(SSAccountsLINQ.GetAccounts());
        }

        public ObservableCollection<SPEEDYDAL.SSAccounts> Accounts { get; set; }

        public SPEEDYDAL.SSAccounts SelectedAccount { get; set; }
    }
}
