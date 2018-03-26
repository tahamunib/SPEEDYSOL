using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL.ViewModels.Account
{
    public class VMAccCategory
    {
        public VMAccCategory()
        {
            AccCategories = new ObservableCollection<SPEEDYDAL.AccountCategory>(SSAccountsLINQ.GetAccountCategories());
        }
        public ObservableCollection<SPEEDYDAL.AccountCategory> AccCategories { get; set; }

        public SPEEDYDAL.AccountCategory SelectedAccCategory { get; set; }
    }
}
