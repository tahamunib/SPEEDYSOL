﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL.ViewModels.Account
{
    public class VMCreateAccount
    {
        public VMCreateAccount(SPEEDYDAL.SSAccount _Account = null)
        {
            Categories = new ObservableCollection<SPEEDYDAL.AccountCategory>(SSAccountsLINQ.GetAccountCategories());
            if (_Account != null)
                Account = _Account;
            else
                Account = new SPEEDYDAL.SSAccount();
        }
        public SPEEDYDAL.SSAccount Account { get; set; }
        public ObservableCollection<SPEEDYDAL.AccountCategory> Categories { get; set; }
    }
}