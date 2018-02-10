using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEEDYBLL.ViewModels.User
{
    public class VMCreateUser
    {
        public VMCreateUser(SPEEDYDAL.SSUser _User = null)
        {
            Roles = new ObservableCollection<SPEEDYDAL.SSUsersRole>(SSUsersLINQ.GetUserRoles());
            if (_User != null)
                User = _User;
            else
                User = new SPEEDYDAL.SSUser();
        }
        public SPEEDYDAL.SSUser User { get; set; }
        public ObservableCollection<SPEEDYDAL.SSUsersRole> Roles { get; set; }
    }
}
