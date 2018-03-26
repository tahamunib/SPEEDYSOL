using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL.ViewModels.Account
{
    public class VMAccGroup
    {
        public VMAccGroup()
        {
            AccGroups = new ObservableCollection<SPEEDYDAL.AccountGroup>(SSAccountsLINQ.GetAccountGroups());
        }
        public ObservableCollection<SPEEDYDAL.AccountGroup> AccGroups { get; set; }

        public SPEEDYDAL.AccountGroup SelectedAccGroup { get; set; }
    }
}
