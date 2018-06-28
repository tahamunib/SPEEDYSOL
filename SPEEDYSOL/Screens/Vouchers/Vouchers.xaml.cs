using SPEEDYBLL;
using SPEEDYBLL.ViewModels.Voucher;
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

namespace SPEEDYSOL.Screens.Vouchers
{
    /// <summary>
    /// Interaction logic for Vouchers.xaml
    /// </summary>
    public partial class Vouchers : Page
    {
        MainWindow window;
        VMVoucher vmVoucher;
        public Vouchers(MainWindow _mainWindow)
        {
            window = _mainWindow;
            InitializeComponent();
        }

        

        private void btnIssueVoucher_Click(object sender, RoutedEventArgs e)
        {
            window.mainFrame.Navigate(new Screens.Vouchers.CreateVoucher());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            vmVoucher = new VMVoucher();
            this.DataContext = vmVoucher;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = (SPEEDYDAL.Vouchers)vouchersGrid.SelectedItem;
                window.mainFrame.Navigate(new CreateVoucher(selectedItem));
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
                var selectedItem = (SPEEDYDAL.Vouchers)vouchersGrid.SelectedItem;
                var result = MessageBox.Show(string.Format("Delete Voucher: Code {0} ?", selectedItem.VoucherCode), "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {

                    if (SSVouchersLINQ.DeleteVoucher(selectedItem))
                    {
                        vmVoucher.Vouchers.Remove(selectedItem);
                        this.DataContext = vmVoucher;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
