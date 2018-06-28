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
        public VMCreateUser(SPEEDYDAL.SSUsers _User = null)
        {
            Roles = new ObservableCollection<SPEEDYDAL.SSUsersRoles>(SSUsersLINQ.GetUserRoles());
            if (_User != null)
                User = _User;
            else
                User = new SPEEDYDAL.SSUsers();
        }
        public SPEEDYDAL.SSUsers User { get; set; }
        public ObservableCollection<SPEEDYDAL.SSUsersRoles> Roles { get; set; }
    }
}
