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
            Accounts = new ObservableCollection<SPEEDYDAL.SSAccount>(SSAccountsLINQ.GetAccounts());
        }

        public ObservableCollection<SPEEDYDAL.SSAccount> Accounts { get; set; }

        public SPEEDYDAL.SSAccount SelectedAccount { get; set; }
    }
}
