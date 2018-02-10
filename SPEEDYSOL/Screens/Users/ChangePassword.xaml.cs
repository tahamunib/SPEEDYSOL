using SPEEDYAuthorization;
using SPEEDYBLL;
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
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Page
    {
        SSUser user;
        
        public ChangePassword(SSUser _user)
        {
            user = _user;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = user;
        }

        private void btnSavePassword_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    
                    if (SSAuthorization.IsOldPasswordMatch(user.Password, txtOldPassword.Password))
                    {
                        user.Password = SSAuthorization.GetHash(txtNewPassword.Password);
                        if (SSUsersLINQ.SaveUser(user))
                        {
                            MessageBox.Show("Successfully changed password.", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
                        else
                        {
                            MessageBox.Show("Could not change password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("You have entered wrong old password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool ValidateInput()
        {
            bool isValidate = false;
            
            if (!(string.IsNullOrEmpty(txtLoginID.Text) && string.IsNullOrEmpty(txtOldPassword.Password) && string.IsNullOrEmpty(txtNewPassword.Password)) && txtNewPassword.Password.Length > 5 && txtOldPassword.Password.Length > 5)
            {
                if (txtConfirmPass.Visibility == Visibility.Visible)
                {
                    if (!string.IsNullOrEmpty(txtConfirmPass.Password))
                    {
                        if (txtNewPassword.Password.Equals(txtConfirmPass.Password))
                        {
                            isValidate = true;
                        }
                        else
                        {
                            isValidate = false;
                        }
                    }
                    else
                    {
                        isValidate = false;
                    }
                }
                else
                {
                    isValidate = true;
                }
            }
            else
            {
                isValidate = false;
            }


            return isValidate;
        }
    }
}
