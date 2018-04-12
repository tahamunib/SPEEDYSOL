using SPEEDYBLL;
using SPEEDYBLL.ViewModels.Vendors;
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
    /// Interaction logic for Vendors.xaml
    /// </summary>
    public partial class Vendors : Page
    {
        MainWindow window;
        VMVendors vmVendors;
        public Vendors(MainWindow _window)
        {
            window = _window;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            vmVendors = new VMVendors();
            this.DataContext = vmVendors;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = (SPEEDYDAL.Vendor)vendorsGrid.SelectedItem;

                window.mainFrame.Navigate(new CreateVendor(selectedItem));
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
                var result = MessageBox.Show("Delete Vendor?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    var selectedItem = (SPEEDYDAL.Vendor)vendorsGrid.SelectedItem;
                    if (SSVendorsLINQ.DeleteVendor(selectedItem))
                    {
                        vmVendors.Vendors.Remove(selectedItem);
                        this.DataContext = vmVendors;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddVendor_Click(object sender, RoutedEventArgs e)
        {
            window.mainFrame.Navigate(new CreateVendor());
        }
    }
}
