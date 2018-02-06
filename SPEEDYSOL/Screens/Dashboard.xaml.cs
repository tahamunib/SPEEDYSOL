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
using System.Windows.Shapes;

namespace SPEEDYSOL.Screens
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        MainWindow window;

        public Dashboard(MainWindow _window)
        {
            window = _window;
            window.windowButtons.Visibility = Visibility.Visible;
            
            InitializeComponent();
            
        }

        private void SaleOrder_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void PurchaseOrder_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void createSalesOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void listSalesOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSales_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPurchase_Click(object sender, RoutedEventArgs e)
        {
            window.mainFrame.Navigate(new Screens.Purchases.PurchaseOrder(window));
        }

        private void btnVouchers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGodowns_Click(object sender, RoutedEventArgs e)
        {
            window.mainFrame.Navigate(new Screens.Godowns.GodownList(window));
        }

        private void btnItems_Click(object sender, RoutedEventArgs e)
        {
            window.mainFrame.Navigate(new Screens.Items.Items(window));
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAccount_Click(object sender, RoutedEventArgs e)
        {
            window.mainFrame.Navigate(new Accounts.Accounts(window));
        }
    }
}
