using SPEEDYBLL;
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

namespace SPEEDYSOL.Screens.Vendor
{
    /// <summary>
    /// Interaction logic for CreateVendor.xaml
    /// </summary>
    public partial class CreateVendor : Page
    {
        SPEEDYDAL.Vendor vendor;
        string _header = "";
        int _Visibilty = 0;
        public CreateVendor(SPEEDYDAL.Vendor _vendor = null)
        {
            if (_vendor != null)
            {
                vendor = _vendor;
                _header = "EDIT VENDOR";
                _Visibilty = (int)Visibility.Visible;
            }
            else
            {
                _Visibilty = (int)Visibility.Hidden;
                vendor = new SPEEDYDAL.Vendor();
                _header = "CREATE VENDOR";
            }
            InitializeComponent();
        }

        private void btnCreateVendor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SSVendorsLINQ.SaveVendor(vendor))
                    MessageBox.Show("Vendor Saved!");
                else
                    MessageBox.Show("Error Occured: Could not save Vendor.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = vendor;
            this.header.Text = _header;
            var visibilityEnumVal = (Visibility)Enum.Parse(typeof(Visibility), Convert.ToString(_Visibilty));
            this.lblCode.Visibility = visibilityEnumVal;
            this.txtCode.Visibility = visibilityEnumVal;
        }
    }
}
