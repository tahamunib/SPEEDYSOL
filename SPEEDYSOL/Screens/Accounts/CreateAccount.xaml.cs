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

namespace SPEEDYSOL.Screens.Accounts
{
    /// <summary>
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Page
    {
        SSAccount account;
        string _header = "";
        int _Visibilty = 0;
        public CreateAccount(SSAccount _account = null)
        {
            if(_account != null)
            {
                account = _account;
                _header = "EDIT ACCOUNT";
                _Visibilty = (int)Visibility.Visible;
            }
            else
            {
                _Visibilty = (int)Visibility.Hidden;
                account = new SSAccount();
                _header = "CREATE ACCOUNT";
            }
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = account;
            this.header.Text = _header;
            var visibilityEnumVal = (Visibility)Enum.Parse(typeof(Visibility), Convert.ToString(_Visibilty));
            this.lblAccNo.Visibility = visibilityEnumVal;
            this.txtAccNo.Visibility = visibilityEnumVal;
        }

        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SSAccountsLINQ.SaveAccount(account))
                    MessageBox.Show("Account Saved!");
                else
                    MessageBox.Show("Error Ocuured: Could not save item.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
