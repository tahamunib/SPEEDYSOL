using SPEEDYBLL;
using SPEEDYBLL.ViewModels.Account;
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
    /// Interaction logic for CreateAccCategory.xaml
    /// </summary>
    public partial class CreateAccCategory : Page
    {
        VMCreateAccCategory accCategory;
        string _header = "";
        int _Visibilty = 0;
        public CreateAccCategory(VMCreateAccCategory _accCategory = null)
        {
            if (_accCategory != null)
            {
                accCategory = _accCategory;
                _header = "EDIT ACCOUNT CATEGORY";
                _Visibilty = (int)Visibility.Visible;
            }
            else
            {
                _Visibilty = (int)Visibility.Hidden;
                accCategory = new VMCreateAccCategory();
                _header = "CREATE ACCOUNT CATEGORY";
            }
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = accCategory;
            this.header.Text = _header;
            var visibilityEnumVal = (Visibility)Enum.Parse(typeof(Visibility), Convert.ToString(_Visibilty));
            this.lblCode.Visibility = visibilityEnumVal;
            this.txtCode.Visibility = visibilityEnumVal;
        }

        private void btnCreateAccCategory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SSAccountsLINQ.SaveAccCategory(accCategory.AccCategory))
                    MessageBox.Show("Account Category Saved!");
                else
                    MessageBox.Show("Error Occured: Could not save Account Category.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
