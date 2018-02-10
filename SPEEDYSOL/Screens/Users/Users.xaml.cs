using SPEEDYBLL;
using SPEEDYBLL.ViewModels.User;
using SPEEDYDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SPEEDYSOL.Screens.Users
{
    /// <summary>
    /// Interaction logic for Users.xaml
    /// </summary>
    public partial class Users : Page
    {
        MainWindow window;
        VMUser vmUser;
        public Users(MainWindow _window)
        {
            window = _window;
            InitializeComponent();
        }

        

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            window.mainFrame.Navigate(new Screens.Users.CreateUser());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            vmUser = new VMUser();
            this.DataContext = vmUser;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = (SPEEDYDAL.SSUser)usersGrid.SelectedItem;
                window.mainFrame.Navigate(new CreateUser(selectedItem));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = (SPEEDYDAL.SSUser)usersGrid.SelectedItem;
                var result = MessageBox.Show(string.Format("Delete User: LoginID {0} ?", selectedItem.LoginID), "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {

                    if (SSUsersLINQ.DeleteUser(selectedItem))
                    {
                        vmUser.Users.Remove(selectedItem);
                        this.DataContext = vmUser;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnChangePass_Click(object sender, RoutedEventArgs e)
        {
            window.mainFrame.Navigate(new Screens.Users.ChangePassword(vmUser.SelectedUser));
        }

        private void usersGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            SSUser currentRowUser = (SSUser)e.Row.DataContext;
            if(currentRowUser.RoleID == 1)
            {
                var type = e.GetType();
                //btnDelete.Visibility = Visibility.Hidden;
            }
        }
    }
}
