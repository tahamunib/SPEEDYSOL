using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL.ViewModels.User
{
    public class VMUser
    {
        public VMUser()
        {
            Users = new ObservableCollection<SPEEDYDAL.SSUsers>(SSUsersLINQ.GetUsers());
        }

        public ObservableCollection<SPEEDYDAL.SSUsers> Users { get; set; }

        public SPEEDYDAL.SSUsers SelectedUser { get; set; }
    }
}
