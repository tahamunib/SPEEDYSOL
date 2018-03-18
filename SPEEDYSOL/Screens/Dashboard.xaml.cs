using SPEEDYSOL.ApplicationLogic;
using SSCommons.Enums;
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
        

        private void btnSales_Click(object sender, RoutedEventArgs e)
        {
            Screens.Sales.CreateOrder_Sales createPOrder = new Sales.CreateOrder_Sales();
            createPOrder.Show();
        }

        private void btnPurchase_Click(object sender, RoutedEventArgs e)
        {
            window.mainFrame.Navigate(new Screens.Purchases.PurchaseOrder(window));
        }

        private void btnVouchers_Click(object sender, RoutedEventArgs e)
        {
            window.mainFrame.Navigate(new Screens.Vouchers.Vouchers(window));
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
            window.mainFrame.Navigate(new Screens.Users.Users(window));
        }

        private void btnAccount_Click(object sender, RoutedEventArgs e)
        {
            window.mainFrame.Navigate(new Accounts.Accounts(window));
        }

        private void btnClients_Click(object sender, RoutedEventArgs e)
        {
            window.mainFrame.Navigate(new Clients.Clients(window));
        }

        private void btnSalesMan_Click(object sender, RoutedEventArgs e)
        {
            window.mainFrame.Navigate(new SalesMen.SalesMen(window));
        }

        private void btnBookers_Click(object sender, RoutedEventArgs e)
        {
            window.mainFrame.Navigate(new Bookers.Bookers(window));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ResolvePermission();
        }

        private void ResolvePermission()
        {
            if (UserRoles.ResolveUserRole() == (long)SSEnums.UserRoles.billing)
            {
                btnAccount.Visibility = Visibility.Hidden;
                btnBookers.Visibility = Visibility.Hidden;
                btnClients.Visibility = Visibility.Hidden;
                btnGodowns.Visibility = Visibility.Hidden;
                btnSalesMan.Visibility = Visibility.Hidden;
                btnUsers.Visibility = Visibility.Hidden;
                btnVouchers.Visibility = Visibility.Hidden;
                btnItems.Visibility = Visibility.Hidden;
            }
        }
    }
}
