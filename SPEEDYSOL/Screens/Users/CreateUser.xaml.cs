using SPEEDYAuthorization;
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
    /// Interaction logic for CreateUser.xaml
    /// </summary>
    public partial class CreateUser : Page
    {
        VMCreateUser user;
        string _header = "";
        bool isEdit = false;
        public CreateUser(SSUsers _user = null)
        {
            if (_user != null)
            {
                user = new VMCreateUser(_user);
                _header = "EDIT USER";
                isEdit = true;
            }
            else
            {
                user = new VMCreateUser();
                _header = "CREATE USER";
                isEdit = false;
            }
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = user;
            this.header.Text = _header;
            if (isEdit)
            {
                txtPassword.Visibility = Visibility.Hidden;
                lblPassword.Visibility = Visibility.Hidden;
                txtConfirmPass.Visibility = Visibility.Hidden;
                lblConfPass.Visibility = Visibility.Hidden;
            }
            else
            {
                txtPassword.Visibility = Visibility.Visible;
                lblPassword.Visibility = Visibility.Visible;
                txtConfirmPass.Visibility = Visibility.Visible;
                lblConfPass.Visibility = Visibility.Visible;
            }
            
        }

        private void cmbRoles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnCreateUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidateInput(user.User,isEdit))
                {
                    if (!isEdit) 
                        user.User.Password = SSAuthorization.GetHash(txtPassword.Password);

                    if (SSUsersLINQ.SaveUser(user.User))
                        MessageBox.Show("User Saved!");
                    else
                        MessageBox.Show("Error Ocuured: Could not save user.");
                }
                else
                {
                    MessageBox.Show("Error Validating Input, Please provide valid input.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool ValidateInput(SSUsers user,bool isEdit)
        {
            bool isValidate = false;
            if(user.RoleID == 0)
            {
                isValidate = false;
            }
            if(!(string.IsNullOrEmpty(txtLoginID.Text) && string.IsNullOrEmpty(txtName.Text)))
            {
                if (isEdit)
                {
                    isValidate = true;
                }
                else
                {
                    if (!(string.IsNullOrEmpty(txtPassword.Password)) && txtPassword.Password.Length > 5)
                    {
                        if (txtConfirmPass.Visibility == Visibility.Visible)
                        {
                            if (!string.IsNullOrEmpty(txtConfirmPass.Password))
                            {
                                if (txtPassword.Password.Equals(txtConfirmPass.Password))
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
                        isValidate = true;
                    }
                }
            }
            else
            {
                isValidate = false;
            }
            
            
            return isValidate;
        }

        private void txtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txtConfirmPass.Visibility == Visibility.Hidden && lblConfPass.Visibility == Visibility.Hidden)
            {
                txtConfirmPass.Visibility = Visibility.Visible;
                lblConfPass.Visibility = Visibility.Visible;
            }
        }
    }
}
