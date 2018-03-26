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
    /// Interaction logic for CreateAccGroup.xaml
    /// </summary>
    public partial class CreateAccGroup : Page
    {
        AccountGroup accGroup;
        string _header = "";
        int _Visibilty = 0;
        public CreateAccGroup(AccountGroup _accGroup = null)
        {
            if (_accGroup != null)
            {
                accGroup = _accGroup;
                _header = "EDIT ACCOUNT GROUP";
                _Visibilty = (int)Visibility.Visible;
            }
            else
            {
                _Visibilty = (int)Visibility.Hidden;
                accGroup = new AccountGroup();
                _header = "CREATE ACCOUNT GROUP";
            }
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = accGroup;
            this.header.Text = _header;
            var visibilityEnumVal = (Visibility)Enum.Parse(typeof(Visibility), Convert.ToString(_Visibilty));
            this.lblCode.Visibility = visibilityEnumVal;
            this.txtCode.Visibility = visibilityEnumVal;
        }

        private void btnCreateAccGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SSAccountsLINQ.SaveAccGroup(accGroup))
                    MessageBox.Show("Account Group Saved!");
                else
                    MessageBox.Show("Error Occured: Could not save Account Group.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
