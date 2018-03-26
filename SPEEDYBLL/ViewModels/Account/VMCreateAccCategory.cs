using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL.ViewModels.Account
{
    public class VMCreateAccCategory
    {
        public VMCreateAccCategory(SPEEDYDAL.AccountCategory _AccCategory = null)
        {
            Groups = new ObservableCollection<SPEEDYDAL.AccountGroup>(SSAccountsLINQ.GetAccountGroups());
            if (_AccCategory != null)
                AccCategory = _AccCategory;
            else
                AccCategory = new SPEEDYDAL.AccountCategory();
        }
        public SPEEDYDAL.AccountCategory AccCategory { get; set; }
        public ObservableCollection<SPEEDYDAL.AccountGroup> Groups { get; set; }
    }
}
